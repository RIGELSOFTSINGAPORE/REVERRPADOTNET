Public Class F50_Form50
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim WK_DsList1, WK_DsList2 As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, Err_F As String
    Dim i, j As Integer
    Dim M_CLS As String = "M30"
    Dim WK_int, WK_int2, WK_int3, WK_int4, WK_int5 As Integer
    Dim WK_shinki As String = "0"

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
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label002 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Private WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Private WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Private WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label002 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(116, 12)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(416, 24)
        Me.Label001.TabIndex = 1095
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(28, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 1094
        Me.Label3.Text = "販社"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label002
        '
        Me.Label002.Location = New System.Drawing.Point(116, 40)
        Me.Label002.Name = "Label002"
        Me.Label002.Size = New System.Drawing.Size(416, 24)
        Me.Label002.TabIndex = 1097
        Me.Label002.Text = "Label002"
        Me.Label002.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(28, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 24)
        Me.Label5.TabIndex = 1096
        Me.Label5.Text = "メーカー"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGridEx1.CaptionFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(20, 68)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.Size = New System.Drawing.Size(964, 576)
        Me.DataGridEx1.TabIndex = 1098
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M30_TECH_AMNT"
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "QG_Care"
        Me.DataGridTextBoxColumn8.MappingName = "qg_cls_name"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 170
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "種類"
        Me.DataGridTextBoxColumn1.MappingName = "pc_cls_name"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "修理会社"
        Me.DataGridTextBoxColumn2.MappingName = "own_cls_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 85
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "難易度"
        Me.DataGridTextBoxColumn3.MappingName = "tier_name"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 99
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = "##,##0"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "技術料金"
        Me.DataGridTextBoxColumn4.MappingName = "tech_amnt"
        Me.DataGridTextBoxColumn4.NullText = "0"
        Me.DataGridTextBoxColumn4.Width = 85
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "##,##0"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "ｷｬﾝｾﾙ料(計上)"
        Me.DataGridTextBoxColumn5.MappingName = "cxl_amnt"
        Me.DataGridTextBoxColumn5.NullText = "0"
        Me.DataGridTextBoxColumn5.Width = 119
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn9.Format = "##,##0"
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "ｷｬﾝｾﾙ料(見積)"
        Me.DataGridTextBoxColumn9.MappingName = "cxl_amnt2"
        Me.DataGridTextBoxColumn9.NullText = "0"
        Me.DataGridTextBoxColumn9.Width = 119
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn6.Format = "##,##0"
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "定額"
        Me.DataGridTextBoxColumn6.MappingName = "fix_amnt"
        Me.DataGridTextBoxColumn6.NullText = "0"
        Me.DataGridTextBoxColumn6.Width = 72
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "##,##0"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "定額２"
        Me.DataGridTextBoxColumn7.MappingName = "fix_amnt2"
        Me.DataGridTextBoxColumn7.NullText = "0"
        Me.DataGridTextBoxColumn7.Width = 77
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(812, 652)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(68, 28)
        Me.Button80.TabIndex = 1263
        Me.Button80.Text = "履歴"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 652)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 28)
        Me.Button1.TabIndex = 1262
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(912, 652)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 28)
        Me.Button98.TabIndex = 1264
        Me.Button98.Text = "戻る"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(110, 656)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(690, 20)
        Me.msg.TabIndex = 1270
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(536, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(216, 24)
        Me.CheckBox1.TabIndex = 1271
        Me.CheckBox1.Text = "グループ全てに反映する"
        '
        'F50_Form50
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 18)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form50"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "技術料マスタ"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form50_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        P_RTN2 = "0"
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()

        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT name FROM M08_STORE WHERE (store_code = '" & P_PRAM2 & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "M08_STORE")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        Label001.Text = P_PRAM2 & ":" & WK_DtView1(0)("name")

        SqlCmd1 = New SqlClient.SqlCommand("SELECT name FROM M05_VNDR WHERE (vndr_code  = '" & P_PRAM3 & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "M05_VNDR")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)
        Label002.Text = P_PRAM3 & ":" & WK_DtView1(0)("name")

        '技術料マスタ
        DsList1.Clear()
        strSQL = "SELECT main.qg_cls, main.qg_cls_name, main.pc_cls, main.pc_cls_name, main.own_cls, main.own_cls_name, main.tier"
        strSQL +=  ", main.tier_name, M30_TECH_AMNT.tech_amnt, M30_TECH_AMNT.cxl_amnt, M30_TECH_AMNT.cxl_amnt2"
        strSQL +=  ", M30_TECH_AMNT.fix_amnt, M30_TECH_AMNT.fix_amnt2"
        strSQL +=  " FROM (SELECT V_cls_026.cls_code AS qg_cls, V_cls_026.cls_code_name AS qg_cls_name, V_cls_011.cls_code AS pc_cls"
        If P_PRAM3 = "01" Then  'Apple
            strSQL +=  ", V_cls_011.cls_code_name_abbr AS pc_cls_name"
        Else
            strSQL +=  ", V_cls_011.cls_code_name AS pc_cls_name"
        End If
        strSQL +=  ", V_cls_012.cls_code AS own_cls, V_cls_012.cls_code_name AS own_cls_name"
        strSQL +=  ", V_cls_013.cls_code AS tier, V_cls_013.cls_code_name AS tier_name"
        strSQL +=  " FROM V_cls_013 CROSS JOIN V_cls_011 CROSS JOIN V_cls_012 CROSS JOIN V_cls_026) AS main LEFT OUTER JOIN"
        strSQL +=  " (SELECT store_code, vndr_code, qgcare_kbn, note_kbn, own_rpat_kbn, tier, tech_amnt, cxl_amnt, cxl_amnt2"
        strSQL +=  ", fix_amnt, fix_amnt2, reg_date, delt_flg"
        strSQL +=  " FROM M30_TECH_AMNT AS M30_TECH_AMNT_1"
        strSQL +=  " WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "')) AS M30_TECH_AMNT ON"
        strSQL +=  " main.qg_cls = M30_TECH_AMNT.qgcare_kbn AND main.pc_cls = M30_TECH_AMNT.note_kbn AND"
        strSQL +=  " main.own_cls = M30_TECH_AMNT.own_rpat_kbn AND main.tier = M30_TECH_AMNT.tier"
        strSQL +=  " ORDER BY main.qg_cls, main.pc_cls, main.own_cls, main.tier"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M30_TECH_AMNT")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M30_TECH_AMNT")
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

        DtView1 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "", "", DataViewRowState.CurrentRows)
    End Sub

    '********************************************************************
    '**  変更履歴
    '********************************************************************
    Sub CHG_HSTY()

        '技術料
        If WK_int <> WK_DtView1(0)("tech_amnt") Then
            add_MTR_hsty(M_CLS, WK_DtView2(j)("store_code") & P_PRAM3, DtView1(i)("qg_cls_name") & " / " & DtView1(i)("pc_cls_name") & " / " & DtView1(i)("own_cls_name") & " / " & DtView1(i)("tier_name") & " / " & "技術料", WK_DtView1(0)("tech_amnt"), WK_int)
        End If

        'キャンセル料
        If WK_int3 <> WK_DtView1(0)("cxl_amnt") Then
            add_MTR_hsty(M_CLS, WK_DtView2(j)("store_code") & P_PRAM3, DtView1(i)("qg_cls_name") & " / " & DtView1(i)("pc_cls_name") & " / " & DtView1(i)("own_cls_name") & " / " & DtView1(i)("tier_name") & " / " & "キャンセル料", WK_DtView1(0)("cxl_amnt"), WK_int3)
        End If

        'キャンセル料2
        If WK_int5 <> WK_DtView1(0)("cxl_amnt2") Then
            add_MTR_hsty(M_CLS, WK_DtView2(j)("store_code") & P_PRAM3, DtView1(i)("qg_cls_name") & " / " & DtView1(i)("pc_cls_name") & " / " & DtView1(i)("own_cls_name") & " / " & DtView1(i)("tier_name") & " / " & "キャンセル料2", WK_DtView1(0)("cxl_amnt2"), WK_int5)
        End If

        '定額
        If WK_int4 <> WK_DtView1(0)("fix_amnt") Then
            add_MTR_hsty(M_CLS, WK_DtView2(j)("store_code") & P_PRAM3, DtView1(i)("qg_cls_name") & " / " & DtView1(i)("pc_cls_name") & " / " & DtView1(i)("own_cls_name") & " / " & DtView1(i)("tier_name") & " / " & "定額", WK_DtView1(0)("fix_amnt"), WK_int4)
        End If

        '定額2
        If WK_int2 <> WK_DtView1(0)("fix_amnt2") Then
            add_MTR_hsty(M_CLS, WK_DtView2(j)("store_code") & P_PRAM3, DtView1(i)("qg_cls_name") & " / " & DtView1(i)("pc_cls_name") & " / " & DtView1(i)("own_cls_name") & " / " & DtView1(i)("tier_name") & " / " & "定額2", WK_DtView1(0)("fix_amnt2"), WK_int2)
        End If

    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_HSTY_DATE = Now

        WK_DsList2.Clear()
        If CheckBox1.Checked = False Then
            strSQL = "SELECT store_code FROM M08_STORE WHERE (store_code = '" & P_PRAM2 & "')"
        Else
            strSQL = "SELECT M08_STORE_1.store_code"
            strSQL +=  " FROM M08_STORE INNER JOIN M08_STORE M08_STORE_1 ON M08_STORE.grup_code = M08_STORE_1.grup_code"
            strSQL +=  " WHERE (M08_STORE.store_code = '" & P_PRAM2 & "')"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList2, "M08_STORE")
        DB_CLOSE()
        WK_DtView2 = New DataView(WK_DsList2.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        For j = 0 To WK_DtView2.Count - 1

            DtView1 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                WK_shinki = "1" '新規
                For i = 0 To DtView1.Count - 1
                    WK_int = 0
                    If Not IsDBNull(DtView1(i)("tech_amnt")) Then
                        WK_int = DtView1(i)("tech_amnt")
                    End If
                    WK_int3 = 0
                    If Not IsDBNull(DtView1(i)("cxl_amnt")) Then
                        WK_int3 = DtView1(i)("cxl_amnt")
                    End If
                    WK_int5 = 0
                    If Not IsDBNull(DtView1(i)("cxl_amnt2")) Then
                        WK_int5 = DtView1(i)("cxl_amnt2")
                    End If
                    WK_int4 = 0
                    If Not IsDBNull(DtView1(i)("fix_amnt")) Then
                        WK_int4 = DtView1(i)("fix_amnt")
                    End If
                    WK_int2 = 0
                    If Not IsDBNull(DtView1(i)("fix_amnt2")) Then
                        WK_int2 = DtView1(i)("fix_amnt2")
                    End If

                    If WK_int3 <> WK_int5 And WK_int5 = 0 Then
                        WK_int5 = WK_int3
                    End If

                    WK_DsList1.Clear()
                    strSQL = "SELECT * FROM M30_TECH_AMNT"
                    strSQL +=  " WHERE (store_code = '" & WK_DtView2(j)("store_code") & "')"
                    strSQL +=  " AND (vndr_code = '" & P_PRAM3 & "')"
                    strSQL +=  " AND (qgcare_kbn = '" & DtView1(i)("qg_cls") & "')"
                    strSQL +=  " AND (note_kbn = '" & DtView1(i)("pc_cls") & "')"
                    strSQL +=  " AND (own_rpat_kbn = '" & DtView1(i)("own_cls") & "')"
                    strSQL +=  " AND (tier = '" & DtView1(i)("tier") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(WK_DsList1, "M30_TECH_AMNT")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M30_TECH_AMNT"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count = 0 Then

                        strSQL = "INSERT INTO M30_TECH_AMNT"
                        strSQL +=  " (store_code, vndr_code, qgcare_kbn, note_kbn, own_rpat_kbn, tier, tech_amnt, cxl_amnt, cxl_amnt2, fix_amnt, fix_amnt2, reg_date, delt_flg)"
                        strSQL +=  " VALUES ('" & WK_DtView2(j)("store_code") & "'"
                        strSQL +=  ", '" & P_PRAM3 & "'"
                        strSQL +=  ", '" & DtView1(i)("qg_cls") & "'"
                        strSQL +=  ", '" & DtView1(i)("pc_cls") & "'"
                        strSQL +=  ", '" & DtView1(i)("own_cls") & "'"
                        strSQL +=  ", '" & DtView1(i)("tier") & "'"
                        strSQL +=  ", " & WK_int
                        strSQL +=  ", " & WK_int3
                        strSQL +=  ", " & WK_int5
                        strSQL +=  ", " & WK_int4
                        strSQL +=  ", " & WK_int2
                        strSQL +=  ", '" & Now.Date & "'"
                        strSQL += ", 0"
                        strSQL += ")"
                        DB_OPEN("nMVAR")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    Else

                        strSQL = "UPDATE M30_TECH_AMNT"
                        strSQL +=  " SET tech_amnt = " & WK_int
                        strSQL +=  ", cxl_amnt = " & WK_int3
                        strSQL +=  ", cxl_amnt2 = " & WK_int5
                        strSQL +=  ", fix_amnt = " & WK_int4
                        strSQL +=  ", fix_amnt2 = " & WK_int2
                        strSQL +=  ", delt_flg = 0"
                        strSQL +=  " WHERE (store_code = '" & WK_DtView2(j)("store_code") & "')"
                        strSQL +=  " AND (vndr_code = '" & P_PRAM3 & "')"
                        strSQL +=  " AND (qgcare_kbn = '" & DtView1(i)("qg_cls") & "')"
                        strSQL +=  " AND (note_kbn = '" & DtView1(i)("pc_cls") & "')"
                        strSQL +=  " AND (own_rpat_kbn = '" & DtView1(i)("own_cls") & "')"
                        strSQL +=  " AND (tier = '" & DtView1(i)("tier") & "')"
                        DB_OPEN("nMVAR")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        CHG_HSTY()  '**  変更履歴
                        WK_shinki = "0" '新規
                    End If
                Next
                If WK_shinki = "1" Then
                    add_MTR_hsty(M_CLS, WK_DtView2(j)("store_code") & P_PRAM3, "新規登録", "", "")
                End If
            End If
        Next

        MessageBox.Show("更新しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        P_RTN2 = "1"
        Button98_Click(sender, e)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  履歴
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '変更履歴
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L02_MTR_HSTY", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 3)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 20)
        Pram3.Value = M_CLS
        Pram4.Value = P_PRAM2 & P_PRAM3
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsCMB.Clear()
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub CheckBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.GotFocus
        CheckBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub CheckBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.LostFocus
        CheckBox1.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
