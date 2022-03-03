Public Class F90_Form03
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, inz_F As String
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Combo01 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb01 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents br_cmb01 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Combo01 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb01 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.br_cmb01 = New System.Windows.Forms.Label
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 652)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "新規"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(488, 652)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 3
        Me.Button99.Text = "閉じる"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M02_cls"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 48)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(552, 596)
        Me.DataGrid1.TabIndex = 1
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn1.MappingName = "cls_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "名称"
        Me.DataGridTextBoxColumn2.MappingName = "cls_code_name"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 330
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "表示順"
        Me.DataGridTextBoxColumn4.MappingName = "dsp_seq"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 60
        '
        'Combo01
        '
        Me.Combo01.Location = New System.Drawing.Point(92, 12)
        Me.Combo01.MaxDropDownItems = 15
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Size = New System.Drawing.Size(368, 24)
        Me.Combo01.TabIndex = 0
        Me.Combo01.Text = "Combo01"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 1358
        Me.Label2.Text = "項目"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb01
        '
        Me.cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb01.Location = New System.Drawing.Point(464, 12)
        Me.cmb01.Name = "cmb01"
        Me.cmb01.Size = New System.Drawing.Size(52, 16)
        Me.cmb01.TabIndex = 1359
        Me.cmb01.Text = "cmb01"
        Me.cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb01.Visible = False
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(96, 656)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(384, 20)
        Me.msg.TabIndex = 1363
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'br_cmb01
        '
        Me.br_cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb01.Location = New System.Drawing.Point(92, -4)
        Me.br_cmb01.Name = "br_cmb01"
        Me.br_cmb01.Size = New System.Drawing.Size(364, 16)
        Me.br_cmb01.TabIndex = 1364
        Me.br_cmb01.Text = "br_cmb01"
        Me.br_cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb01.Visible = False
        '
        'F90_Form03
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(570, 683)
        Me.Controls.Add(Me.br_cmb01)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.cmb01)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F90_Form03"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "テーブル・マスタ"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F90_Form03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call sql()      '** 画面セット
        inz_F = "1"
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
        DsCMB1.Clear()
        DB_OPEN("nQGCare")

        '項目
        strSQL = "SELECT cls, cls_name FROM M02_cls GROUP BY cls, cls_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M02_cls")
        Combo01.DataSource = DsCMB1.Tables("M02_cls")
        Combo01.DisplayMember = "cls_name"
        Combo01.ValueMember = "cls"

        DtView1 = New DataView(DsCMB1.Tables("M02_cls"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            cmb01.Text = DtView1(0)("cls")
            br_cmb01.Text = Combo01.Text
        Else
            cmb01.Text = Nothing
            br_cmb01.Text = Nothing
        End If

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** 画面セット
    '********************************************************************
    Sub sql()

        DsList1.Clear()
        strSQL = "SELECT cls_code, cls_code_name, dsp_seq"
        strSQL += " FROM M02_cls"
        strSQL += " WHERE (cls = '" & cmb01.Text & "')"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsList1, "M02_cls")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M02_cls")
        DataGrid1.DataSource = tbl

    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_CHK()
        Err_F = "0"

        Call CK_Combo01()   '項目
        If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

    End Sub
    Sub CK_Combo01()
        msg.Text = Nothing
        Combo01.BackColor = System.Drawing.SystemColors.Window
        Combo01.Text = Trim(Combo01.Text)
        If br_cmb01.Text <> Combo01.Text Then
            cmb01.Text = Nothing

            If Combo01.Text = Nothing Then
                msg.Text = "項目の入力がありません。"
                Combo01.BackColor = System.Drawing.Color.Red
            Else
                DtView1 = New DataView(DsCMB1.Tables("M02_cls"), "cls_name ='" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    cmb01.Text = DtView1(0)("cls")
                Else
                    msg.Text = "該当の項目はありません。"
                    Combo01.BackColor = System.Drawing.Color.Red
                End If
            End If
            Call sql()      '** 画面セット
            br_cmb01.Text = Combo01.Text
        End If
    End Sub

    '******************************************************************
    '** SelectedIndexChanged
    '******************************************************************
    Private Sub Combo01_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.SelectedIndexChanged
        If inz_F = "1" Then
            Call CK_Combo01()   '項目
        End If
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Combo01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.LostFocus
        Call CK_Combo01()   '項目
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
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                P_PRAM1 = cmb01.Text
                P_PRAM2 = Combo01.Text
                P_PRAM3 = DataGrid1(DataGrid1.CurrentRowIndex, 0)

                Dim F90_Form03_01 As New F90_Form03_01
                F90_Form03_01.ShowDialog()

                If P_RTN = "1" Then

                    DtView1 = New DataView(DsList1.Tables("M02_cls"), "cls_code = " & P_PRAM3, "", DataViewRowState.CurrentRows)

                    WK_DsList1.Clear()
                    strSQL = "SELECT * FROM M02_cls"
                    strSQL += " WHERE (cls = '" & P_PRAM1 & "')"
                    strSQL += " AND (cls_code = '" & P_PRAM3 & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nQGCare")
                    DaList1.Fill(WK_DsList1, "M02_cls")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M02_cls"), "", "", DataViewRowState.CurrentRows)

                    DtView1(0)("cls_code_name") = WK_DtView1(0)("cls_code_name")
                    DtView1(0)("dsp_seq") = WK_DtView1(0)("dsp_seq")

                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '******************************************************************
    '** 新規
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call F_CHK()    '** 項目チェック
        If Err_F = "0" Then
            P_PRAM1 = cmb01.Text
            P_PRAM2 = Combo01.Text
            P_PRAM3 = Nothing

            Dim F90_Form03_01 As New F90_Form03_01
            F90_Form03_01.ShowDialog()

            If P_RTN = "1" Then

                strSQL = "SELECT * FROM M02_cls"
                strSQL += " WHERE (cls = '" & P_PRAM1 & "')"
                strSQL += " AND (cls_code = " & P_PRAM3 & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nQGCare")
                DaList1.Fill(DsList1, "M02_cls")
                DB_CLOSE()

            End If

        End If
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        DsCMB1.Clear()
        Close()
    End Sub
End Class
