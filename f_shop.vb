Public Class f_shop
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL As String

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
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.f12 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(16, 548)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 677
        Me.Button1.TabStop = False
        Me.Button1.Text = "新規登録"
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f12.Location = New System.Drawing.Point(660, 544)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 676
        Me.f12.TabStop = False
        Me.f12.Text = "閉じる"
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 8)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(744, 528)
        Me.DataGrid1.TabIndex = 675
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "SHOP"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "店舗コード"
        Me.DataGridTextBoxColumn1.MappingName = "SHOP_CODE"
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "店舗名"
        Me.DataGridTextBoxColumn2.MappingName = "SHOP_NAME"
        Me.DataGridTextBoxColumn2.Width = 200
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "住所"
        Me.DataGridTextBoxColumn3.MappingName = "SHOP_ADRS"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 150
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn4.MappingName = "TEL_NO"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 90
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "開店"
        Me.DataGridTextBoxColumn5.MappingName = "OPEN_TIME"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "店舗種別"
        Me.DataGridTextBoxColumn6.MappingName = "CLS_CODE_NAME"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 90
        '
        'f_shop
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(776, 585)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "f_shop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "店舗マスタメンテ"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub f_shop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        DspSet()    '**  画面セット
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
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        P_DsMent1.Clear()

        '店舗マスタ
        strSQL = "SELECT SHOP.SHOP_CODE, SHOP.SHOP_NAME, SHOP.SHOP_ADRS, SHOP.TEL_NO, SHOP.OPEN_TIME, V_cls024.CLS_CODE_NAME"
        strSQL += " FROM SHOP LEFT OUTER JOIN"
        strSQL += " V_cls024 ON SHOP.bk_kbn = V_cls024.CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(P_DsMent1, "SHOP")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = P_DsMent1.Tables("SHOP")
        DataGrid1.DataSource = tbl

    End Sub

    'ｸﾞﾘｯﾄﾞ ｸﾘｯｸ
    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                P_shop_code2 = DataGrid1(hitinfo.Row, 0)

                Dim f_shop_2 As New f_shop_2
                f_shop_2.ShowDialog()

                If P_RTN = "1" Then
                    DsList1.Clear()
                    strSQL = "SELECT SHOP.SHOP_CODE, SHOP.SHOP_NAME, SHOP.SHOP_ADRS, SHOP.TEL_NO, SHOP.OPEN_TIME, V_cls024.CLS_CODE_NAME"
                    strSQL += " FROM SHOP LEFT OUTER JOIN"
                    strSQL += " V_cls024 ON SHOP.bk_kbn = V_cls024.CLS_CODE"
                    strSQL += " WHERE (SHOP.SHOP_CODE = '" & P_shop_code2 & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    DaList1.Fill(DsList1, "SHOP")
                    DB_CLOSE()
                    DtView1 = New DataView(DsList1.Tables("SHOP"), "", "", DataViewRowState.CurrentRows)

                    DtView2 = New DataView(P_DsMent1.Tables("SHOP"), "SHOP_CODE = '" & P_shop_code2 & "'", "", DataViewRowState.CurrentRows)
                    DtView2(0)("SHOP_NAME") = DtView1(0)("SHOP_NAME")
                    DtView2(0)("SHOP_ADRS") = DtView1(0)("SHOP_ADRS")
                    DtView2(0)("TEL_NO") = DtView1(0)("TEL_NO")
                    DtView2(0)("OPEN_TIME") = DtView1(0)("OPEN_TIME")
                    DtView2(0)("CLS_CODE_NAME") = DtView1(0)("CLS_CODE_NAME")
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  新規登録 ボタン
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_shop_code2 = Nothing

        Dim f_shop_2 As New f_shop_2
        f_shop_2.ShowDialog()

        If P_RTN = "1" Then Call DspSet()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        Close()
        Dim f_menu As New f_menu
        f_menu.ShowDialog()
    End Sub
End Class
