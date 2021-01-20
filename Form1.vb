Public Class Form1
    Inherits System.Windows.Forms.Form

    Private objMutex As System.Threading.Mutex
    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCmb As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, ini_F As String
    Dim i, r As Integer

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn22 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn23 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn24 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn25 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn26 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn27 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn22 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn23 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn24 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn25 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn26 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn27 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderFont = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 40)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(976, 540)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Error_data_new"
        Me.DataGridTableStyle1.RowHeaderWidth = 10
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Error_seq"
        Me.DataGridTextBoxColumn1.MappingName = "Error_seq"
        Me.DataGridTextBoxColumn1.Width = 60
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "ｴﾗｰﾒｯｾｰｼﾞ"
        Me.DataGridTextBoxColumn2.MappingName = "Error_msg"
        Me.DataGridTextBoxColumn2.Width = 120
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "伝票番号"
        Me.DataGridTextBoxColumn3.MappingName = "ordr_no"
        Me.DataGridTextBoxColumn3.Width = 99
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "受注日"
        Me.DataGridTextBoxColumn4.MappingName = "prch_date"
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "完了日"
        Me.DataGridTextBoxColumn5.MappingName = "fin_date"
        Me.DataGridTextBoxColumn5.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "ｷｬﾝｾﾙ日"
        Me.DataGridTextBoxColumn6.MappingName = "cxl_date"
        Me.DataGridTextBoxColumn6.Width = 80
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "顧客番号"
        Me.DataGridTextBoxColumn7.MappingName = "cust_no"
        Me.DataGridTextBoxColumn7.Width = 99
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "顧客名"
        Me.DataGridTextBoxColumn8.MappingName = "cust_lname"
        Me.DataGridTextBoxColumn8.Width = 120
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn9.MappingName = "srch_phn"
        Me.DataGridTextBoxColumn9.Width = 80
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "行No"
        Me.DataGridTextBoxColumn10.MappingName = "line_no"
        Me.DataGridTextBoxColumn10.Width = 40
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "大分類No"
        Me.DataGridTextBoxColumn11.MappingName = "item_cat_code1"
        Me.DataGridTextBoxColumn11.Width = 70
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "中分類No"
        Me.DataGridTextBoxColumn12.MappingName = "item_cat_code2"
        Me.DataGridTextBoxColumn12.Width = 70
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "小分類No"
        Me.DataGridTextBoxColumn13.MappingName = "item_cat_code3"
        Me.DataGridTextBoxColumn13.Width = 70
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "ﾒｰｶｺｰﾄﾞ"
        Me.DataGridTextBoxColumn14.MappingName = "bend_code"
        Me.DataGridTextBoxColumn14.Width = 60
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn15.MappingName = "pos_code"
        Me.DataGridTextBoxColumn15.Width = 70
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "型式"
        Me.DataGridTextBoxColumn16.MappingName = "model_name"
        Me.DataGridTextBoxColumn16.Width = 99
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn17.Format = "##,##0"
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "売価"
        Me.DataGridTextBoxColumn17.MappingName = "prch_price"
        Me.DataGridTextBoxColumn17.Width = 50
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn18.Format = "##,##0"
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "税額"
        Me.DataGridTextBoxColumn18.MappingName = "prch_tax"
        Me.DataGridTextBoxColumn18.Width = 50
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn19.Format = "##,##0"
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "数量"
        Me.DataGridTextBoxColumn19.MappingName = "prch_unit"
        Me.DataGridTextBoxColumn19.Width = 50
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "店番"
        Me.DataGridTextBoxColumn20.MappingName = "shop_code"
        Me.DataGridTextBoxColumn20.Width = 50
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "処理日"
        Me.DataGridTextBoxColumn21.MappingName = "op_date"
        Me.DataGridTextBoxColumn21.Width = 80
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "取引種類"
        Me.DataGridTextBoxColumn22.MappingName = "cont_code"
        Me.DataGridTextBoxColumn22.Width = 65
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.HeaderText = "保証商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn23.MappingName = "wrn_item_code"
        Me.DataGridTextBoxColumn23.Width = 90
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.HeaderText = "保証商品型式"
        Me.DataGridTextBoxColumn24.MappingName = "wrn_item_name"
        Me.DataGridTextBoxColumn24.Width = 90
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn25.Format = "##,##0"
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.HeaderText = "保証額"
        Me.DataGridTextBoxColumn25.MappingName = "wrn_fee"
        Me.DataGridTextBoxColumn25.Width = 60
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn26.Format = ""
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.HeaderText = "保証期間"
        Me.DataGridTextBoxColumn26.MappingName = "wrn_prod"
        Me.DataGridTextBoxColumn26.Width = 65
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.HeaderText = "保証種類"
        Me.DataGridTextBoxColumn27.MappingName = "wrn_cls"
        Me.DataGridTextBoxColumn27.Width = 65
        '
        'Button99
        '
        Me.Button99.Location = New System.Drawing.Point(896, 592)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(96, 36)
        Me.Button99.TabIndex = 1
        Me.Button99.Text = "終　了"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(880, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 24)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "件数"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "取込み日時"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(124, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(184, 24)
        Me.ComboBox1.TabIndex = 95
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(688, 592)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 40)
        Me.Button1.TabIndex = 97
        Me.Button1.Text = "CSV出力"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1010, 639)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入エラー修正 Var 2.0"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '***************************************************************************
    '** 起動時
    '***************************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_err_mnt")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        DB_INIT()
        cmb_set()
        Dsp_Set()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("Error_data_new")
        DataGrid1.DataSource = tbl

        ini_F = "1"
    End Sub

    Sub cmb_set()

        DsCmb.Clear()
        strSQL = "SELECT imp_date FROM Error_data_new WHERE (Fixed_flg = '0') GROUP BY imp_date ORDER BY imp_date DESC"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCmb, "Error_data_new")
        DB_CLOSE()

        '取込み日時
        ComboBox1.DataSource = DsCmb.Tables("Error_data_new")
        ComboBox1.DisplayMember = "imp_date"
        ComboBox1.ValueMember = "imp_date"

    End Sub

    Sub Dsp_Set()
        DsList1.Clear()
        strSQL = "SELECT * FROM Error_data_new WHERE (Fixed_flg = '0')"
        If ComboBox1.Text <> Nothing Then strSQL += " AND (imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(DsList1, "Error_data_new")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("Error_data_new"), "", "", DataViewRowState.CurrentRows)

        Label3.Text = Format(r, "##,##0") & " 件"
    End Sub

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim hitinfo As DataGrid.HitTestInfo

        hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
        If hitinfo.Row >= 0 Then

            If DataGrid1.CurrentRowIndex <= DtView1.Count - 1 Then
                P_Pram = DataGrid1(hitinfo.Row, 0)
                P_Pram2 = DataGrid1(hitinfo.Row, 1)
                Dim Form2 As New Form2
                Form2.ShowDialog()

                If P_Rtn = "1" Then
                    Dsp_Set()     '再表示
                End If
            End If
        End If
        'Try
        'Catch ex As System.Exception
        'End Try

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        If ini_F = "1" Then
            Dsp_Set()
        End If
    End Sub
    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.LostFocus
        If ComboBox1.Text = Nothing Then
            Dsp_Set()
        End If
    End Sub

    '***************************************************************************
    '** CSV出力
    '***************************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        Dim i As Integer                  'カウンタ
        Dim sbuf As String                'ファイルに出力するデータ

        Me.Enabled = False                      ' オーナーのフォームを無効にする

        waitDlg = New WaitDialog                ' 進行状況ダイアログ
        waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = "エラーデータ"        ' 処理の概要を表示
        waitDlg.ProgressMsg = "データ出力中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0               ' 最初の件数を設定
        waitDlg.Show()                          ' 進行状況ダイアログを表示する
        Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

        DtView1 = New DataView(DsList1.Tables("Error_data_new"), "", "", DataViewRowState.CurrentRows)
        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        waitDlg.MainMsg = "データ出力中"            ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = DtView1.Count               ' 全体の処理件数を設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

        sbuf = "Error_seq,エラーメッセージ,システム区分,伝票番号,受注日,完了日,キャンセル日,元伝No,赤伝No,顧客番号,顧客名"
        sbuf += ",郵便番号,住所1,住所2,電話番号,行No,大分類No,大分類名,中分類No,中分類名,小分類No,小分類名"
        sbuf += ",メーカーコード,メーカー名,商品コード,型式,売価,税額,購入数量,店番,店名,データ処理日,データ連番"
        sbuf += ",取引種類,保証商品コード,保証商品型式,保証金額,保証期間,保証種類"
        sw.WriteLine(sbuf)

        For i = 0 To DtView1.Count - 1

            waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            sbuf = DtView1(i)("Error_seq")
            sbuf += "," & DtView1(i)("Error_msg")
            sbuf += "," & DtView1(i)("BY_cls")
            sbuf += "," & DtView1(i)("ordr_no")
            sbuf += "," & DtView1(i)("prch_date")
            sbuf += "," & DtView1(i)("fin_date")
            sbuf += "," & DtView1(i)("cxl_date")
            sbuf += "," & DtView1(i)("org_ordr_no")
            sbuf += "," & DtView1(i)("aka_ordr_no")
            sbuf += "," & DtView1(i)("cust_no")
            sbuf += "," & DtView1(i)("cust_lname")
            sbuf += "," & DtView1(i)("zip_code")
            sbuf += "," & DtView1(i)("adrs1")
            sbuf += "," & DtView1(i)("adrs2")
            sbuf += "," & DtView1(i)("srch_phn")
            sbuf += "," & DtView1(i)("line_no")
            sbuf += "," & DtView1(i)("item_cat_code1")
            sbuf += "," & DtView1(i)("item_cat_code1_name")
            sbuf += "," & DtView1(i)("item_cat_code2")
            sbuf += "," & DtView1(i)("item_cat_code2_name")
            sbuf += "," & DtView1(i)("item_cat_code3")
            sbuf += "," & DtView1(i)("item_cat_code3_name")
            sbuf += "," & DtView1(i)("bend_code")
            sbuf += "," & DtView1(i)("brnd_name")
            sbuf += "," & DtView1(i)("pos_code")
            sbuf += "," & DtView1(i)("model_name")
            sbuf += "," & DtView1(i)("prch_price")
            sbuf += "," & DtView1(i)("prch_tax")
            sbuf += "," & DtView1(i)("prch_unit")
            sbuf += "," & DtView1(i)("shop_code")
            sbuf += "," & DtView1(i)("shop_name")
            sbuf += "," & DtView1(i)("op_date")
            sbuf += "," & DtView1(i)("data_seq")
            sbuf += "," & DtView1(i)("cont_code")
            sbuf += "," & DtView1(i)("wrn_item_code")
            sbuf += "," & DtView1(i)("wrn_item_name")
            sbuf += "," & DtView1(i)("wrn_fee")
            sbuf += "," & DtView1(i)("wrn_prod")
            sbuf += "," & DtView1(i)("wrn_cls")
            sw.WriteLine(sbuf)
        Next

        sw.Close()
        Me.Activate()
        waitDlg.Close()

        '［名前を付けて保存］ダイアログボックスを表示
        If ComboBox1.Text <> "" Then
            SaveFileDialog1.FileName = "Error_data_" & Format(CDate(ComboBox1.Text), "yyyyMMddhhmmss") & ".csv"
        Else
            SaveFileDialog1.FileName = "Error_data_.csv"
        End If
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Me.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '***************************************************************************
    '** 終了
    '***************************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub
End Class
