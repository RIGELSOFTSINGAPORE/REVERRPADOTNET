Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objMutex As System.Threading.Mutex
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsExp As New DataSet
    Dim DtView1 As DataView

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Dim strSQL, Err_F, ptn_F, inz_F As String
    Dim i, j As Integer

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Button99 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS PGothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 40)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(752, 504)
        Me.DataGrid1.TabIndex = 2
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Shop_mtr"
        Me.DataGridTableStyle1.ReadOnly = True
        Me.DataGridTableStyle1.RowHeaderWidth = 10
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "店舗ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn1.MappingName = "shop_code"
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "店舗名(ｶﾅ)"
        Me.DataGridTextBoxColumn2.MappingName = "店舗名(ｶﾅ)"
        Me.DataGridTextBoxColumn2.Width = 150
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "店舗名(漢字)"
        Me.DataGridTextBoxColumn3.MappingName = "店舗名(漢字)"
        Me.DataGridTextBoxColumn3.Width = 200
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "分類"
        Me.DataGridTextBoxColumn4.MappingName = "分類名"
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "会社GRP"
        Me.DataGridTextBoxColumn5.MappingName = "会社GRP"
        Me.DataGridTextBoxColumn5.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "閉鎖日"
        Me.DataGridTextBoxColumn6.MappingName = "close_date"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button99.Location = New System.Drawing.Point(640, 552)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 99
        Me.Button99.Text = "終了"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(16, 552)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 90
        Me.Button1.Text = "新規登録"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(512, 552)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 32)
        Me.Button5.TabIndex = 100
        Me.Button5.Text = "ﾃﾞｰﾀ出力"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "システム区分"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(120, 8)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(72, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "ベスト"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(192, 8)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(72, 24)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "ヤマダ"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(272, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 24)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(770, 591)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "店舗ﾏｽﾀﾒﾝﾃﾅﾝｽ"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_mnt_shop")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        Call DB_INIT()

        RadioButton1.Checked = True
        Label2.Text = "B"

        'Call DsSet()
        inz_F = "1"
        Call DspSet1()
    End Sub

    Sub DspSet1()
        P_DsList1.Clear()

        '店舗マスタ
        strSQL = "SELECT * FROM Shop_mtr"
        strSQL += " WHERE (BY_cls = '" & Label2.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(P_DsList1, "Shop_mtr")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = P_DsList1.Tables("Shop_mtr")
        DataGrid1.DataSource = tbl

    End Sub

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                P_BY_cls = Label2.Text
                P_shop_code = DataGrid1(hitinfo.Row, 0)

                Dim frmform2 As New Form2
                frmform2.ShowDialog()

                If P_Rtn = "1" Then
                    Call DspSet1()
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub XLS_OUT()

        '延長修理OK分
        waitDlg.MainMsg = "店舗マスタ"              ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()
        '旧加入分
        strSQL = "SELECT * FROM Shop_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsExp, "Shop_mtr")
        DB_CLOSE()

        DtView1 = New DataView(DsExp.Tables("Shop_mtr"), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        'xlApp.Visible = True
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Add
        Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(1), Excel.Worksheet)
        Dim xlCells As Excel.Range
        Dim xlRange As Excel.Range = xlSheet.Rows

        xlCells = xlSheet.Cells
        xlRange = xlCells(1, 1) : xlRange.Value = "システム区分" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 2) : xlRange.Value = "店舗ｺｰﾄﾞ" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 3) : xlRange.Value = "店舗名(ｶﾅ)" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 4) : xlRange.Value = "店舗名(漢字)" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 5) : xlRange.Value = "分類CD" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 6) : xlRange.Value = "分類名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 7) : xlRange.Value = "会社GRP" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 8) : xlRange.Value = "住所CD" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 9) : xlRange.Value = "郵便番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 10) : xlRange.Value = "都道府県名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 11) : xlRange.Value = "市区町村名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 12) : xlRange.Value = "住所１" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 13) : xlRange.Value = "住所２" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 14) : xlRange.Value = "TEL(市外)" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 15) : xlRange.Value = "TEL(市内)" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 16) : xlRange.Value = "TEL(番号)" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 17) : xlRange.Value = "FAX(市外)" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 18) : xlRange.Value = "FAX(市内)" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 19) : xlRange.Value = "FAX(番号)" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 20) : xlRange.Value = "閉鎖日" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)

        Dim Hs As Excel.HPageBreaks = xlSheet.HPageBreaks
        Dim H As Excel.HPageBreak

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        For i = 0 To DtView1.Count - 1

            waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
            waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"

            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            j = i + 2  'セル行

            xlRange = xlCells(j, 1) : xlRange.Value = Chr(39) & DtView1(i)("BY_cls").ToString : MRComObject(xlRange)
            xlRange = xlCells(j, 2) : xlRange.Value = Chr(39) & DtView1(i)("shop_code").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("店舗名(ｶﾅ)")) Then xlRange = xlCells(j, 3) : xlRange.Value = Trim(DtView1(i)("店舗名(ｶﾅ)")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("店舗名(漢字)")) Then xlRange = xlCells(j, 4) : xlRange.Value = Trim(DtView1(i)("店舗名(漢字)")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("分類CD")) Then xlRange = xlCells(j, 5) : xlRange.Value = Chr(39) & DtView1(i)("分類CD").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("分類名")) Then xlRange = xlCells(j, 6) : xlRange.Value = Trim(DtView1(i)("分類名")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("会社GRP")) Then xlRange = xlCells(j, 7) : xlRange.Value = Chr(39) & DtView1(i)("会社GRP").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("住所CD")) Then xlRange = xlCells(j, 8) : xlRange.Value = Chr(39) & DtView1(i)("住所CD").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("郵便番号")) Then xlRange = xlCells(j, 9) : xlRange.Value = Chr(39) & DtView1(i)("郵便番号").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("都道府県名")) Then xlRange = xlCells(j, 10) : xlRange.Value = Trim(DtView1(i)("都道府県名")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("市区町村名")) Then xlRange = xlCells(j, 11) : xlRange.Value = Trim(DtView1(i)("市区町村名")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("住所１")) Then xlRange = xlCells(j, 12) : xlRange.Value = Trim(DtView1(i)("住所１")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("住所２")) Then xlRange = xlCells(j, 13) : xlRange.Value = Trim(DtView1(i)("住所２")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("TEL(市外)")) Then xlRange = xlCells(j, 14) : xlRange.Value = Chr(39) & DtView1(i)("TEL(市外)").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("TEL(市内)")) Then xlRange = xlCells(j, 15) : xlRange.Value = Chr(39) & DtView1(i)("TEL(市内)").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("TEL(番号)")) Then xlRange = xlCells(j, 16) : xlRange.Value = Chr(39) & DtView1(i)("TEL(番号)").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("FAX(市外)")) Then xlRange = xlCells(j, 17) : xlRange.Value = Chr(39) & DtView1(i)("FAX(市外)").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("FAX(市内)")) Then xlRange = xlCells(j, 18) : xlRange.Value = Chr(39) & DtView1(i)("FAX(市内)").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("FAX(番号)")) Then xlRange = xlCells(j, 19) : xlRange.Value = Chr(39) & DtView1(i)("FAX(番号)").ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("close_date")) Then xlRange = xlCells(j, 20) : xlRange.Value = DtView1(i)("close_date") : MRComObject(xlRange)
        Next

        xlCells.EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

        MRComObject(xlCells)

        Me.Activate()
        waitDlg.Close()

        '［名前を付けて保存］ダイアログボックスを表示
        'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
        SaveFileDialog1.FileName = "店舗マスタ.xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Try
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try

        Me.Enabled = True

        ' 終了処理　
        MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)              'xlApp を開放

    End Sub

    Private Sub MRComObject(ByVal objXl As Object)
        'Excel 終了処理時のプロシージャ
        Try
            '提供されたランタイム呼び出し可能ラッパーの参照カウントをデクリメントします
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objXl)
        Catch
        Finally
            objXl = Nothing
        End Try
    End Sub

    '新規登録ボタン
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_BY_cls = Label2.Text
        P_shop_code = Nothing

        Dim frmform2 As New Form2
        frmform2.ShowDialog()

        If P_Rtn = "1" Then
            Call DspSet1()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    'データ出力ボタン
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

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

        Call XLS_OUT()

        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True               ' オーナーのフォームを有効にする

        MsgBox("出力しました。", , "")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '終了ボタン
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Label2.Text = "B"
        If inz_F = "1" Then DspSet1()
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Label2.Text = "Y"
        If inz_F = "1" Then DspSet1()
    End Sub
End Class
