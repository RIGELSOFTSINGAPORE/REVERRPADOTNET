Public Class F05_Form06
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, INZ_F As String

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents msg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F05_Form06))
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.msg = New System.Windows.Forms.Label
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 598)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "新規"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "ラインコード"
        Me.DataGridTextBoxColumn1.MappingName = "line_code"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 110
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "ライン名"
        Me.DataGridTextBoxColumn2.MappingName = "line_name"
        Me.DataGridTextBoxColumn2.Width = 370
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "DEL"
        Me.DataGridBoolColumn1.MappingName = "delt_flg"
        Me.DataGridBoolColumn1.NullValue = CType(resources.GetObject("DataGridBoolColumn1.NullValue"), Object)
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 40
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 40)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(596, 548)
        Me.DataGrid1.TabIndex = 1
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridBoolColumn1})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "line_mtr"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(524, 596)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(76, 28)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "戻る"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 24)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "部門"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(136, 8)
        Me.ComboBox1.MaxDropDownItems = 15
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(332, 24)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "ComboBox1"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(100, 600)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(404, 24)
        Me.msg.TabIndex = 1212
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F05_Form06
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(610, 633)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F05_Form06"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac ラインマスタメンテ"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F05_Form06_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call DspSet()   '** 画面セット
        INZ_F = "1"
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
    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN()

        '部門
        strSQL = "SELECT section_code, section_code + ':' + RTRIM(section_name) AS section_name"
        strSQL = strSQL & " FROM section_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "section_mtr")

        ComboBox1.DataSource = DsCMB.Tables("section_mtr")
        ComboBox1.DisplayMember = "section_name"
        ComboBox1.ValueMember = "section_code"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        DsSet()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("line_mtr")
        DataGrid1.DataSource = tbl
    End Sub

    '********************************************************************
    '**  データセット
    '********************************************************************
    Sub DsSet()
        DsList1.Clear()

        'ラインマスタ
        strSQL = "SELECT * FROM line_mtr"
        strSQL = strSQL & " WHERE (section_code = '" & Mid(ComboBox1.Text, 1, 3) & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "line_mtr")
        DB_CLOSE()

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
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGrid1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        CHK_ComboBox1()
        If Err_F = "1" Then Exit Sub

        Dim hitinfo As DataGrid.HitTestInfo
        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                If Trim(ComboBox1.Text) <> Nothing Then P_PRAM1 = Mid(ComboBox1.Text, 1, 3) Else P_PRAM1 = Nothing
                P_PRAM2 = DataGrid1(DataGrid1.CurrentRowIndex, 0)

                Dim F05_Form06_2 As New F05_Form06_2
                F05_Form06_2.ShowDialog()

                If P_RTN = "1" Then '**  画面セット
                    WK_DsList1.Clear()
                    strSQL = "SELECT * FROM line_mtr"
                    If Trim(ComboBox1.Text) <> Nothing Then
                        strSQL = strSQL & " WHERE (section_code  = '" & Mid(ComboBox1.Text, 1, 3) & "')"
                    End If
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    DaList1.Fill(WK_DsList1, "line_mtr")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("line_mtr"), "line_code = '" & P_PRAM2 & "'", "", DataViewRowState.CurrentRows)
                    DtView1 = New DataView(DsList1.Tables("line_mtr"), "line_code = '" & P_PRAM2 & "'", "", DataViewRowState.CurrentRows)

                    DtView1(0)("line_name") = WK_DtView1(0)("line_name")
                    DtView1(0)("delt_flg") = WK_DtView1(0)("delt_flg")
                End If
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub CHK_ComboBox1()
        Err_F = "0"
        msg.Text = Nothing

        ComboBox1.Text = Trim(ComboBox1.Text)
        If ComboBox1.Text = Nothing Then
            ComboBox1.BackColor = System.Drawing.Color.Red
            msg.Text = "部門が選択されていません。"
            Err_F = "1" : Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("section_mtr"), "section_name = '" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                ComboBox1.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する部門がありません。"
                Err_F = "1" : Exit Sub
            End If
        End If
        ComboBox1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** コンボボックス変更
    '******************************************************************
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox1.BackColor = System.Drawing.SystemColors.Window
        If INZ_F = "1" Then
            DsSet()
        End If
    End Sub

    '******************************************************************
    '** 新規
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CHK_ComboBox1()
        If Err_F = "1" Then Exit Sub
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        If Trim(ComboBox1.Text) <> Nothing Then P_PRAM1 = Mid(ComboBox1.Text, 1, 3) Else P_PRAM1 = Nothing
        P_PRAM2 = Nothing
        P_PRAM3 = ComboBox1.Text

        Dim F05_Form06_2 As New F05_Form06_2
        F05_Form06_2.ShowDialog()

        If P_RTN = "1" Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Call DspSet()   '** 画面セット
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 戻る
    '******************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB.Clear()
        Close()
    End Sub
End Class
