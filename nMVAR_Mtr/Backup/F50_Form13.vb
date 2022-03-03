Public Class F50_Form13
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

    Dim strSQL As String
    Dim i, j, k As Integer

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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F50_Form13))
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 616)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(960, 24)
        Me.msg.TabIndex = 1277
        Me.msg.Text = "msg"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(916, 648)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "戻る"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "データ取込"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(136, 64)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(48, 20)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.Text = "HP"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(24, 64)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(92, 20)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Apple/iOS"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(236, 60)
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
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(16, 124)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(972, 480)
        Me.DataGridEx1.TabIndex = 1279
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M40_PART"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "部品番号"
        Me.DataGridTextBoxColumn1.MappingName = "part_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "部品名"
        Me.DataGridTextBoxColumn2.MappingName = "part_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 250
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = "##,##0"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "買取価格"
        Me.DataGridTextBoxColumn4.MappingName = "stc_amnt"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 90
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "##,##0"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "交換価格"
        Me.DataGridTextBoxColumn5.MappingName = "exc_amnt"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 90
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Labor Tier"
        Me.DataGridTextBoxColumn6.MappingName = "labor_tier"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "代替部品番号"
        Me.DataGridTextBoxColumn7.MappingName = "sub_part_code"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 90
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "製品名"
        Me.DataGridTextBoxColumn3.MappingName = "part_dtl"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 240
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(116, 648)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 32)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "クリア"
        '
        'F50_Form13
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F50_Form13"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部品データ取込"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='513'", "", DataViewRowState.CurrentRows)
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
        strSQL = "SELECT * FROM M40_PART WHERE (part_code IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsGRD, "M40_PART")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsGRD.Tables("M40_PART")
        DataGridEx1.DataSource = tbl
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
            .Filter = "Excel ﾌｧｲﾙ(*.xls)|*.xls|すべてのファイル(*.*)|*.*"
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
                waitDlg.Show()                  ' 進行状況ダイアログを表示する

                waitDlg.MainMsg = "部品ﾃﾞｰﾀ取込準備中"      ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMsg = ""                    ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMax = 0                     ' 全体の処理件数を設定
                waitDlg.ProgressValue = 0                   ' 最初の件数を設定
                Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

                Dim s As String
                Dim fnm As String = Trim(TextBox1.Text)

                Dim exl As Object
                exl = CreateObject("Excel.Application")
                exl.Application.Visible = False
                exl.Application.Workbooks.Open(FileName:=fnm)

                Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
                Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
                Dim xlBook As Excel.Workbook = xlBooks.Add
                Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
                Dim xlCells As Excel.Range
                Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(1), Excel.Worksheet)
                Dim xlRange As Excel.Range = xlSheet.Rows

                j = 0
                For k = 2 To 65536
                    xlRange = exl.Cells(k, 1) : s = xlRange.Value : If s = "" Then Exit For
                    j = k
                Next
                If j = 0 Then
                    msg.Text = "対象データがありません。"
                    Button1.Enabled = False
                    Button2.Enabled = True
                    Button3.Enabled = True
                    Button4.Enabled = False
                    Button98.Enabled = True
                Else
                    waitDlg.MainMsg = "部品ﾃﾞｰﾀ取込中"          ' 進行状況ダイアログのメーターを設定
                    waitDlg.ProgressMax = j - 1                 ' 全体の処理件数を設定

                    For k = 2 To j
                        waitDlg.ProgressMsg = Fix((k - 1) * 100 / (j - 1)) & "%　" & "（" & Format((k - 1), "##,##0") & " / " & Format((j - 1), "##,##0") & " 件）"
                        waitDlg.Text = "実行中・・・" & Fix((k - 1) * 100 / (j - 1)) & "%　"
                        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                        xlRange = exl.Cells(k, 1) : s = xlRange.Value : If s = "" Then Exit For

                        dttable = DsGRD.Tables("M40_PART")
                        dtRow = dttable.NewRow

                        If RadioButton1.Checked = True Then 'Apple
                            xlRange = exl.Cells(k, 2) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_code") = s Else dtRow("part_code") = ""
                            xlRange = exl.Cells(k, 3) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_name") = s.Replace(Chr(39), " ") Else dtRow("part_name") = ""
                            xlRange = exl.Cells(k, 1) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_dtl") = s.Replace(Chr(39), " ") Else dtRow("part_dtl") = ""
                            xlRange = exl.Cells(k, 7) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("stc_amnt") = s Else dtRow("stc_amnt") = 0
                            xlRange = exl.Cells(k, 8) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("exc_amnt") = s Else dtRow("exc_amnt") = 0
                            xlRange = exl.Cells(k, 5) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("labor_tier") = s.Replace(Chr(39), " ") Else dtRow("labor_tier") = ""
                            xlRange = exl.Cells(k, 10) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("sub_part_code") = s.Replace(Chr(39), " ") Else dtRow("sub_part_code") = ""
                        Else               'HP
                            xlRange = exl.Cells(k, 1) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_code") = s Else dtRow("part_code") = ""
                            xlRange = exl.Cells(k, 2) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_name") = s.Replace(Chr(39), " ") Else dtRow("part_name") = ""
                            dtRow("part_dtl") = ""
                            xlRange = exl.Cells(k, 3) : s = xlRange.Value : If IsNumeric(Trim(s)) = True Then dtRow("stc_amnt") = s Else dtRow("stc_amnt") = 0
                            xlRange = exl.Cells(k, 4) : s = xlRange.Value : If IsNumeric(Trim(s)) = True Then dtRow("exc_amnt") = s Else dtRow("exc_amnt") = 0
                            dtRow("labor_tier") = ""
                            dtRow("sub_part_code") = ""
                        End If
                        dttable.Rows.Add(dtRow)
                    Next

                    Button1.Enabled = True
                    Button2.Enabled = False
                    Button3.Enabled = False
                    Button4.Enabled = True
                    Button98.Enabled = True
                End If
                waitDlg.Close()                 ' 進行状況ダイアログを閉じる

                exl.Application.DisplayAlerts = False
                exl.Application.Quit()
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
        Button4.Enabled = False
        Button98.Enabled = True
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.GotFocus
        RadioButton1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.GotFocus
        RadioButton2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub RadioButton1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.LostFocus
        RadioButton1.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.LostFocus
        RadioButton2.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        DtView1 = New DataView(DsGRD.Tables("M40_PART"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
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
            waitDlg.Show()                  ' 進行状況ダイアログを表示する

            waitDlg.MainMsg = "部品ﾃﾞｰﾀ更新準備中"      ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMsg = ""                    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            DB_OPEN("nMVAR")
            strSQL = "DELETE FROM M40_PART"
            If RadioButton1.Checked = True Then 'Apple
                strSQL += " WHERE vndr_code = '01' OR  vndr_code = '20'"
            Else
                strSQL += " WHERE vndr_code = '03'"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            waitDlg.MainMsg = "部品ﾃﾞｰﾀ更新中"          ' 進行状況ダイアログのメーターを設定

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　" & "（" & Format((i + 1), "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strSQL = "INSERT INTO M40_PART"
                strSQL += " (vndr_code, part_code, part_name, part_dtl, stc_amnt, exc_amnt, labor_tier, sub_part_code)"
                If RadioButton1.Checked = True Then 'Apple/iOS
                    strSQL += " VALUES ('01'"
                Else
                    strSQL += " VALUES ('03'"
                End If
                strSQL += ", '" & DtView1(i)("part_code") & "'"
                strSQL += ", '" & Trim(DtView1(i)("part_name")) & "'"
                strSQL += ", '" & Trim(DtView1(i)("part_dtl")) & "'"
                strSQL += ", " & DtView1(i)("stc_amnt")
                strSQL += ", " & DtView1(i)("exc_amnt")
                strSQL += ", '" & DtView1(i)("labor_tier") & "'"
                strSQL += ", '" & DtView1(i)("sub_part_code") & "'"
                strSQL += ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                If RadioButton1.Checked = True Then 'Apple/iOS
                    strSQL = "INSERT INTO M40_PART"
                    strSQL += " (vndr_code, part_code, part_name, part_dtl, stc_amnt, exc_amnt, labor_tier, sub_part_code)"
                    strSQL += " VALUES ('20'"
                    strSQL += ", '" & DtView1(i)("part_code") & "'"
                    strSQL += ", '" & Trim(DtView1(i)("part_name")) & "'"
                    strSQL += ", '" & Trim(DtView1(i)("part_dtl")) & "'"
                    strSQL += ", " & DtView1(i)("stc_amnt")
                    strSQL += ", " & DtView1(i)("exc_amnt")
                    strSQL += ", '" & DtView1(i)("labor_tier") & "'"
                    strSQL += ", '" & DtView1(i)("sub_part_code") & "'"
                    strSQL += ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                End If

            Next
            DB_CLOSE()
            waitDlg.Close()                 ' 進行状況ダイアログを閉じる
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = True
            Button98.Enabled = True
        End If
        msg.Text = "更新しました。"
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
        DsGRD.Clear()
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
