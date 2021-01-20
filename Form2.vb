Public Class Form2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim DtView1 As DataView

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
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.Label53 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
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
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(20, 8)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(664, 24)
        Me.Label53.TabIndex = 1004
        Me.Label53.Text = "該当する加入データが複数あります。選択してください。"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.Color.Silver
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Button98.Location = New System.Drawing.Point(772, 520)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(104, 32)
        Me.Button98.TabIndex = 1013
        Me.Button98.Text = "戻る"
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(12, 36)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(864, 480)
        Me.DataGrid1.TabIndex = 1014
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Wrn"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "保証番号"
        Me.DataGridTextBoxColumn1.MappingName = "ordr_no"
        Me.DataGridTextBoxColumn1.Width = 120
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "行№"
        Me.DataGridTextBoxColumn2.MappingName = "line_no"
        Me.DataGridTextBoxColumn2.Width = 45
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "SEQ"
        Me.DataGridTextBoxColumn3.MappingName = "seq"
        Me.DataGridTextBoxColumn3.Width = 40
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "顧客名"
        Me.DataGridTextBoxColumn4.MappingName = "cust_name"
        Me.DataGridTextBoxColumn4.Width = 210
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "型式"
        Me.DataGridTextBoxColumn5.MappingName = "model_name"
        Me.DataGridTextBoxColumn5.Width = 160
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "購入日"
        Me.DataGridTextBoxColumn6.MappingName = "prch_date"
        Me.DataGridTextBoxColumn6.Width = 95
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "##,##0"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "購入価格"
        Me.DataGridTextBoxColumn7.MappingName = "prch_price"
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "状況"
        Me.DataGridTextBoxColumn8.MappingName = "cont_flg"
        Me.DataGridTextBoxColumn8.Width = 40
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "全損"
        Me.DataGridTextBoxColumn9.MappingName = "total_loss_flg"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 40
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(890, 559)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請求データ登録／修正  Ver 1.1.18"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************
    '** 起動時
    '**********************************
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        DtView1 = New DataView(P_DsList1.Tables("Wrn"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1
            If Not IsDBNull(DtView1(i)("total_loss_flg")) Then
                If DtView1(i)("total_loss_flg") = "0" Then
                    DtView1(i)("total_loss_flg") = Nothing
                End If
            End If
        Next

        Dim tbl As New DataTable
        tbl = P_DsList1.Tables("Wrn")
        DataGrid1.DataSource = tbl

    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGrid1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGrid1.Paint
        If DataGrid1.CurrentRowIndex >= 0 Then
            DataGrid1.Select(DataGrid1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo
        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                P_rtn = "1"
                P_PRAM1 = DataGrid1(DataGrid1.CurrentRowIndex, 0)
                P_PRAM2 = DataGrid1(DataGrid1.CurrentRowIndex, 1)
                P_PRAM3 = DataGrid1(DataGrid1.CurrentRowIndex, 2)
                Close()
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '**********************************
    '** 戻るボタン
    '**********************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_rtn = "9"
        Close()
    End Sub
End Class
