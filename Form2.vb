Public Class Form2
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL As String
    Dim i As Integer

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridEx1 As MrMax_Import.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents DataGridBoolColumn2 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.Button99 = New System.Windows.Forms.Button
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.DataGridEx1 = New MrMax_Import.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn2 = New System.Windows.Forms.DataGridBoolColumn
        Me.Button1 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit3 = New GrapeCity.Win.Input.Interop.Edit
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(696, 668)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(64, 32)
        Me.Button99.TabIndex = 4
        Me.Button99.Text = "戻　る"
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(656, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1250
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(684, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1249
        Me.CheckBox1.Visible = False
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 28)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(752, 632)
        Me.DataGridEx1.TabIndex = 2
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridBoolColumn1, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridBoolColumn2})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "sp_biz_list"
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "法人"
        Me.DataGridBoolColumn1.MappingName = "法人"
        Me.DataGridBoolColumn1.NullValue = CType(resources.GetObject("DataGridBoolColumn1.NullValue"), Object)
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 50
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "伝票NO"
        Me.DataGridTextBoxColumn1.MappingName = "伝票NO"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 90
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "SEQ"
        Me.DataGridTextBoxColumn2.MappingName = "SEQ"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 50
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "氏名"
        Me.DataGridTextBoxColumn3.MappingName = "氏名"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 110
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn4.MappingName = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 90
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "品名"
        Me.DataGridTextBoxColumn5.MappingName = "品名漢字"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 120
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "品種ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn6.MappingName = "品種ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "##,##0"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "単価2"
        Me.DataGridTextBoxColumn7.MappingName = "単価2"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 60
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "数量"
        Me.DataGridTextBoxColumn8.MappingName = "分割数量"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 30
        '
        'DataGridBoolColumn2
        '
        Me.DataGridBoolColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn2.FalseValue = False
        Me.DataGridBoolColumn2.HeaderText = "Del"
        Me.DataGridBoolColumn2.MappingName = "dlt_f"
        Me.DataGridBoolColumn2.NullValue = CType(resources.GetObject("DataGridBoolColumn2.NullValue"), Object)
        Me.DataGridBoolColumn2.ReadOnly = True
        Me.DataGridBoolColumn2.TrueValue = True
        Me.DataGridBoolColumn2.Width = 30
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 668)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 32)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "更　新"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(84, 676)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(600, 16)
        Me.msg.TabIndex = 1251
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit1
        '
        Me.Edit1.Format = "9"
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(80, 4)
        Me.Edit1.MaxLength = 14
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(88, 20)
        Me.Edit1.TabIndex = 0
        '
        'Edit2
        '
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit2.LengthAsByte = True
        Me.Edit2.Location = New System.Drawing.Point(220, 4)
        Me.Edit2.MaxLength = 100
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(112, 20)
        Me.Edit2.TabIndex = 1
        '
        'Edit3
        '
        Me.Edit3.Format = "9"
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit3.LengthAsByte = True
        Me.Edit3.Location = New System.Drawing.Point(172, 4)
        Me.Edit3.MaxLength = 14
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(48, 20)
        Me.Edit3.TabIndex = 1252
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(766, 708)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button99)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "法人選択"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msg.Text = Nothing
        sql()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("sp_biz_list")
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

    End Sub

    Sub sql()
        msg.Text = Nothing

        DsList1.Clear()
        strSQL = "SELECT * FROM [02_売上データ]"
        strSQL += " WHERE ([分類ｺｰﾄﾞ] = '30' OR [分類ｺｰﾄﾞ] = '91') AND (分割元SEQ = 0)"
        strSQL += " AND (処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
        If Trim(Edit1.Text) <> Nothing Then
            strSQL += " AND (伝票NO LIKE '" & Trim(Edit1.Text) & "%')"
        End If
        If Trim(Edit2.Text) <> Nothing Then
            strSQL += " AND (氏名 LIKE '" & Trim(Edit2.Text) & "%')"
        End If
        If Trim(Edit3.Text) <> Nothing Then
            strSQL += " AND (SEQ = " & Trim(Edit3.Text) & ")"
        End If
        strSQL += " ORDER BY 法人 DESC, 伝票NO"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "sp_biz_list")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("sp_biz_list"), "", "", DataViewRowState.CurrentRows)

        'SqlCmd1 = New SqlClient.SqlCommand("sp_biz_list", cnsqlclient)
        'SqlCmd1.CommandType = CommandType.StoredProcedure
        'Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        'Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 14)
        'Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 100)
        'Pram1.Value = P_DATE
        'Pram2.Value = Trim(Edit1.Text)
        'Pram3.Value = Trim(Edit2.Text)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN()
        'DaList1.Fill(DsList1, "sp_biz_list")
        'DB_CLOSE()
        'DtView1 = New DataView(DsList1.Tables("sp_biz_list"), "", "", DataViewRowState.CurrentRows)
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGrid1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        If DataGridEx1.CurrentRowIndex >= 0 Then
            DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　スペース
    '********************************************************************
    Private Sub DataGrid1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                Case Is = Keys.Space
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = "False" Then
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox1.Checked
                    Else
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox2.Checked
                    End If
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))

            If hitinfo.Column = 0 Then  'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = "False" Then
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox1.Checked
                    Else
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox2.Checked
                    End If
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '** 更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        DtView1 = New DataView(DsList1.Tables("sp_biz_list"), "", "", DataViewRowState.CurrentRows)
        DB_OPEN()
        For i = 0 To DtView1.Count - 1
            strSQL = "UPDATE [02_売上データ]"
            If DtView1(i)("法人") = "True" Then
                strSQL += " SET 法人 = 1"
            Else
                strSQL += " SET 法人 = 0"
            End If
            strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        Next
        DB_CLOSE()

        msg.Text = "更新しました。"
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Edit1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.TextChanged
        sql()
    End Sub
    Private Sub Edit2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit2.TextChanged
        sql()
    End Sub
    Private Sub Edit3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit3.TextChanged
        sql()
    End Sub
End Class
