Public Class F00_Form22_01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList0, DsList1, WK_DsList1 As New DataSet
    Dim DsCMB1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, SET_F, ANS, WK_code As String
    Dim i, r, r2, WK_wrn_fee, WK_SUI As Integer

    Dim WK_wrn_tem, WK_wrn_range, WK_ittpan As String

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
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cmb08 As System.Windows.Forms.Label
    Friend WithEvents cmb07 As System.Windows.Forms.Label
    Friend WithEvents Combo08 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Combo07 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Number01 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cmb01 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents Combo09 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Combo01 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cnt As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ittpan As System.Windows.Forms.Label
    Friend WithEvents ittpan2 As System.Windows.Forms.Label
    Friend WithEvents re_no As System.Windows.Forms.Label
    Friend WithEvents code2 As System.Windows.Forms.Label
    Friend WithEvents code As System.Windows.Forms.Label
    Friend WithEvents nendo As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button99 = New System.Windows.Forms.Button
        Me.cmb08 = New System.Windows.Forms.Label
        Me.cmb07 = New System.Windows.Forms.Label
        Me.Combo08 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo07 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label17 = New System.Windows.Forms.Label
        Me.Number01 = New GrapeCity.Win.Input.Interop.Number
        Me.Label16 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.cmb01 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.Combo09 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Combo01 = New GrapeCity.Win.Input.Interop.Combo
        Me.cnt = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ittpan = New System.Windows.Forms.Label
        Me.ittpan2 = New System.Windows.Forms.Label
        Me.re_no = New System.Windows.Forms.Label
        Me.code2 = New System.Windows.Forms.Label
        Me.code = New System.Windows.Forms.Label
        Me.nendo = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(12, 8)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(980, 548)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGrid1.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn9})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "T01_member"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "加入番号"
        Me.DataGridTextBoxColumn1.MappingName = "code"
        Me.DataGridTextBoxColumn1.Width = 105
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "お客様名"
        Me.DataGridTextBoxColumn2.MappingName = "user_name"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 150
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = "##,##0"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "購入金額"
        Me.DataGridTextBoxColumn4.MappingName = "prch_amnt"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "保証期間"
        Me.DataGridTextBoxColumn5.MappingName = "wrn_tem_name"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "保証範囲"
        Me.DataGridTextBoxColumn6.MappingName = "wrn_range_name"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 110
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "##,##0"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "加入料金(税別)"
        Me.DataGridTextBoxColumn3.MappingName = "wrn_fee"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 85
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "大学名"
        Me.DataGridTextBoxColumn8.MappingName = "univ_name"
        Me.DataGridTextBoxColumn8.Width = 110
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "取扱店名"
        Me.DataGridTextBoxColumn7.MappingName = "shop_name"
        Me.DataGridTextBoxColumn7.Width = 220
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "修理番号"
        Me.DataGridTextBoxColumn9.MappingName = "rcpt_no"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(916, 652)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 8
        Me.Button99.Text = "閉じる"
        '
        'cmb08
        '
        Me.cmb08.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb08.Location = New System.Drawing.Point(432, 640)
        Me.cmb08.Name = "cmb08"
        Me.cmb08.Size = New System.Drawing.Size(52, 16)
        Me.cmb08.TabIndex = 1460
        Me.cmb08.Text = "cmb08"
        Me.cmb08.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb08.Visible = False
        '
        'cmb07
        '
        Me.cmb07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb07.Location = New System.Drawing.Point(264, 596)
        Me.cmb07.Name = "cmb07"
        Me.cmb07.Size = New System.Drawing.Size(52, 16)
        Me.cmb07.TabIndex = 1459
        Me.cmb07.Text = "cmb07"
        Me.cmb07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb07.Visible = False
        '
        'Combo08
        '
        Me.Combo08.AutoSelect = True
        Me.Combo08.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo08.Location = New System.Drawing.Point(140, 620)
        Me.Combo08.MaxDropDownItems = 35
        Me.Combo08.Name = "Combo08"
        Me.Combo08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo08.Size = New System.Drawing.Size(232, 24)
        Me.Combo08.TabIndex = 3
        Me.Combo08.Value = "Combo08"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(12, 620)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 24)
        Me.Label18.TabIndex = 1458
        Me.Label18.Text = "保証範囲"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo07
        '
        Me.Combo07.AutoSelect = True
        Me.Combo07.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo07.Location = New System.Drawing.Point(140, 592)
        Me.Combo07.MaxDropDownItems = 35
        Me.Combo07.Name = "Combo07"
        Me.Combo07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo07.Size = New System.Drawing.Size(124, 24)
        Me.Combo07.TabIndex = 2
        Me.Combo07.Value = "Combo07"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(12, 592)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 24)
        Me.Label17.TabIndex = 1457
        Me.Label17.Text = "保証期間"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number01
        '
        Me.Number01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number01.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number01.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number01.HighlightText = True
        Me.Number01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number01.Location = New System.Drawing.Point(140, 564)
        Me.Number01.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01.Name = "Number01"
        Me.Number01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number01.Size = New System.Drawing.Size(124, 24)
        Me.Number01.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number01.TabIndex = 1
        Me.Number01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number01.Value = Nothing
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(12, 564)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 24)
        Me.Label16.TabIndex = 1456
        Me.Label16.Text = "購入金額（税別）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(728, 652)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "変更"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 660)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(664, 20)
        Me.msg.TabIndex = 1462
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb01
        '
        Me.cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb01.Location = New System.Drawing.Point(836, 568)
        Me.cmb01.Name = "cmb01"
        Me.cmb01.Size = New System.Drawing.Size(52, 16)
        Me.cmb01.TabIndex = 1470
        Me.cmb01.Text = "cmb01"
        Me.cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb01.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(892, 568)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1469
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'Combo09
        '
        Me.Combo09.AutoSelect = True
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(516, 620)
        Me.Combo09.MaxDropDownItems = 35
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(432, 24)
        Me.Combo09.TabIndex = 5
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(436, 620)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(76, 24)
        Me.Label23.TabIndex = 1468
        Me.Label23.Text = "取扱店"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(436, 592)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 24)
        Me.Label9.TabIndex = 1467
        Me.Label9.Text = "大学"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo01
        '
        Me.Combo01.AutoSelect = True
        Me.Combo01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo01.Location = New System.Drawing.Point(516, 592)
        Me.Combo01.MaxDropDownItems = 35
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo01.Size = New System.Drawing.Size(332, 24)
        Me.Combo01.TabIndex = 4
        Me.Combo01.Value = "Combo01"
        '
        'cnt
        '
        Me.cnt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.cnt.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cnt.ForeColor = System.Drawing.Color.White
        Me.cnt.Location = New System.Drawing.Point(840, 9)
        Me.cnt.Name = "cnt"
        Me.cnt.Size = New System.Drawing.Size(140, 20)
        Me.cnt.TabIndex = 1471
        Me.cnt.Text = "cnt"
        Me.cnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button4.Location = New System.Drawing.Point(824, 652)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 28)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "削除"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(952, 620)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 24)
        Me.Label1.TabIndex = 1472
        Me.Label1.Text = "一般"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'ittpan
        '
        Me.ittpan.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.ittpan.Location = New System.Drawing.Point(940, 564)
        Me.ittpan.Name = "ittpan"
        Me.ittpan.Size = New System.Drawing.Size(60, 16)
        Me.ittpan.TabIndex = 1473
        Me.ittpan.Text = "ittpan"
        Me.ittpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ittpan.Visible = False
        '
        'ittpan2
        '
        Me.ittpan2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.ittpan2.Location = New System.Drawing.Point(940, 584)
        Me.ittpan2.Name = "ittpan2"
        Me.ittpan2.Size = New System.Drawing.Size(60, 16)
        Me.ittpan2.TabIndex = 1474
        Me.ittpan2.Text = "ittpan2"
        Me.ittpan2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ittpan2.Visible = False
        '
        're_no
        '
        Me.re_no.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.re_no.Location = New System.Drawing.Point(732, 560)
        Me.re_no.Name = "re_no"
        Me.re_no.Size = New System.Drawing.Size(52, 16)
        Me.re_no.TabIndex = 1475
        Me.re_no.Text = "re_no"
        Me.re_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.re_no.Visible = False
        '
        'code2
        '
        Me.code2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.code2.Location = New System.Drawing.Point(348, 596)
        Me.code2.Name = "code2"
        Me.code2.Size = New System.Drawing.Size(52, 16)
        Me.code2.TabIndex = 1477
        Me.code2.Text = "code2"
        Me.code2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.code2.Visible = False
        '
        'code
        '
        Me.code.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.code.Location = New System.Drawing.Point(348, 576)
        Me.code.Name = "code"
        Me.code.Size = New System.Drawing.Size(52, 16)
        Me.code.TabIndex = 1476
        Me.code.Text = "code"
        Me.code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.code.Visible = False
        '
        'nendo
        '
        Me.nendo.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.nendo.Location = New System.Drawing.Point(472, 560)
        Me.nendo.Name = "nendo"
        Me.nendo.Size = New System.Drawing.Size(52, 16)
        Me.nendo.TabIndex = 1478
        Me.nendo.Text = "nendo"
        Me.nendo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.nendo.Visible = False
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(376, 620)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 24)
        Me.Label27.TabIndex = 1479
        Me.Label27.Text = "課税"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F00_Form22_01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.nendo)
        Me.Controls.Add(Me.code2)
        Me.Controls.Add(Me.code)
        Me.Controls.Add(Me.re_no)
        Me.Controls.Add(Me.ittpan2)
        Me.Controls.Add(Me.ittpan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cnt)
        Me.Controls.Add(Me.cmb01)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.Combo09)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmb08)
        Me.Controls.Add(Me.cmb07)
        Me.Controls.Add(Me.Combo08)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Combo07)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Number01)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form22_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "取込データ一括修正"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form22_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call sql()      '** SQL

    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = "対象データの一括変更が行えます。"
        P_RTN = "0"

    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()
        DB_OPEN("nQGCare")

        '保証期間
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSK') ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "cls_HSK")
        Combo07.DataSource = DsCMB1.Tables("cls_HSK")
        Combo07.DisplayMember = "cls_code_name"
        Combo07.ValueMember = "cls_code"
        Combo07.Text = Nothing

        '保証範囲
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSY') ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "cls_HSY")
        Combo08.DataSource = DsCMB1.Tables("cls_HSY")
        Combo08.DisplayMember = "cls_code_name"
        Combo08.ValueMember = "cls_code"
        Combo08.Text = Nothing
        Label27.Text = Nothing

        '大学
        strSQL = "SELECT univ_code, univ_name FROM M01_univ WHERE (delt_flg = 0) ORDER BY univ_name_kana, univ_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M01_univ")
        Combo01.DataSource = DsCMB1.Tables("M01_univ")
        Combo01.DisplayMember = "univ_name"
        Combo01.ValueMember = "univ_code"
        Combo01.Text = Nothing

        '販売店
        strSQL = "SELECT shop_code, shop_name, ittpan FROM M04_shop WHERE (shop_code <> 0) AND (delt_flg = 0) ORDER BY shop_name_kana, shop_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M04_shop")
        Combo09.DataSource = DsCMB1.Tables("M04_shop")
        Combo09.DisplayMember = "shop_name"
        Combo09.ValueMember = "shop_code"
        Combo09.Text = Nothing

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** SQL
    '********************************************************************
    Sub sql()
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DsList1.Clear()
        strSQL = "SELECT T01_member.code, T01_member.user_name, T01_member.prch_amnt"
        strSQL += ", T01_member.wrn_tem, V_M02_HSK.cls_code_name AS wrn_tem_name"
        strSQL += ", T01_member.wrn_range, V_M02_HSY.cls_code_name AS wrn_range_name"
        strSQL += ", T01_member.makr_code, T01_member.wrn_fee, M04_shop.ittpan"
        strSQL += ", M04_shop.shop_name, M01_univ.univ_name, T01_member.suisen_flg"
        strSQL += ", T01_member.nendo, T01_member.makr_wrn_stat, '' AS rcpt_no"
        strSQL += " FROM T01_member LEFT OUTER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code LEFT OUTER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code"
        strSQL += " WHERE (T01_member.delt_flg = 0)"
        'strSQL += " AND (T01_member.nendo = " & P_proc_y & ")"
        strSQL += " AND (M04_shop.shop_name = '" & P_PRAM1 & "')"
        strSQL += " AND (T01_member.Part_date = CONVERT(DATETIME, '" & P_PRAM2 & "', 102))"
        strSQL += " AND (T01_member.imp_seq = " & P_PRAM3 & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "T01_member")
        DB_CLOSE()

        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
            If Mid(DtView1(0)("code"), 1, 1) = "E" Then ittpan.Text = "True" Else ittpan.Text = "False"
            code.Text = Mid(DtView1(0)("code"), 1, 1) & Mid(DtView1(0)("code"), 3, 2)
            nendo.Text = DtView1(0)("nendo")
            For i = 0 To DtView1.Count - 1
                WK_DsList1.Clear()
                strSQL = "SELECT rcpt_no FROM T01_REP_MTR WHERE (qg_care_no = '" & DtView1(i)("code") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    DtView1(i)("rcpt_no") = WK_DtView1(0)("rcpt_no")
                End If
            Next

            '推薦加入料金
            strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'SUI') AND (cls_code = " & nendo.Text & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r2 = DaList1.Fill(DsList1, "cls_SUI")
            DB_CLOSE()
            If r2 <> 0 Then
                WK_DtView1 = New DataView(DsList1.Tables("cls_SUI"), "", "", DataViewRowState.CurrentRows)
                WK_SUI = WK_DtView1(0)("cls_code_name")
            Else
                WK_SUI = 0
            End If

        End If

        Dim tbl1 As New DataTable
        tbl1 = DsList1.Tables("T01_member")
        DataGrid1.DataSource = tbl1

        cnt.Text = Format(r, "##,##0") & " 件"

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_CHK()
        msg.Text = Nothing
        Err_F = "0"

        Call CK_Number01()   '購入金額
        If msg.Text <> Nothing Then Err_F = "1" : Number01.Focus() : Exit Sub

        Call CK_Combo07()    '保証期間
        If msg.Text <> Nothing Then Err_F = "1" : Combo07.Focus() : Exit Sub

        Call CK_Combo08()    '保証範囲
        If msg.Text <> Nothing Then Err_F = "1" : Combo08.Focus() : Exit Sub

        Call CK_Combo01()    '大学
        If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

        Call CK_Combo09()    '取扱店
        If msg.Text <> Nothing Then Err_F = "1" : Combo09.Focus() : Exit Sub

        If Number01.Value = 0 _
            And cmb07.Text = Nothing _
            And cmb08.Text = Nothing _
            And cmb01.Text = Nothing _
            And cmb09.Text = Nothing Then
            msg.Text = "変更項目の入力がありません。"
            Err_F = "1"
        End If

    End Sub
    Sub CK_Number01()   '購入金額
        Number01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo07()    '保証期間
        cmb07.Text = Nothing
        Combo07.Text = Trim(Combo07.Text)

        If Combo07.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB1.Tables("cls_HSK"), "cls_code_name ='" & Combo07.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb07.Text = DtView1(0)("cls_code")
            Else
                msg.Text = "該当の保証期間はありません。"
                Combo07.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo08()    '保証範囲
        cmb08.Text = Nothing
        Label27.Text = Nothing
        code2.Text = code.Text
        Combo08.Text = Trim(Combo08.Text)

        If Combo08.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB1.Tables("cls_HSY"), "cls_code_name ='" & Combo08.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb08.Text = DtView1(0)("cls_code")
                Select Case cmb08.Text
                    Case Is = "7"           '延長保証
                        code2.Text = "A03"
                    Case Is = "11", "12"    'セーフティプラス、セーフティⅡプラス
                        code2.Text = "M01"
                    Case Else
                        code2.Text = "A01"
                End Select

                'WK_DsList1.Clear()
                'strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HST') AND (cls_code = '" & cmb08.Text & "')"
                'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                'DaList1.SelectCommand = SqlCmd1
                'DB_OPEN("nQGCare")
                'r = DaList1.Fill(WK_DsList1, "cls_HST")
                'DB_CLOSE()
                'If r <> 0 Then
                '    WK_DtView1 = New DataView(WK_DsList1.Tables("cls_HST"), "", "", DataViewRowState.CurrentRows)
                '    If WK_DtView1(0)("cls_code_name") = "1" Then
                '        Label27.Text = "課税"
                '    Else
                '        Label27.Text = "非課税"
                '    End If
                'End If
            Else
                msg.Text = "該当の保証範囲はありません。"
                Combo08.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo08.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo01()    '大学
        cmb01.Text = Nothing
        Combo01.Text = Trim(Combo01.Text)

        If Combo01.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB1.Tables("M01_univ"), "univ_name ='" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb01.Text = DtView1(0)("univ_code")
            Else
                msg.Text = "該当の大学はありません。"
                Combo01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo09()    '取扱店
        cmb09.Text = Nothing
        WK_ittpan = Nothing
        ittpan2.Text = Nothing
        Combo09.Text = Trim(Combo09.Text)
        Label1.Visible = False

        If Combo09.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB1.Tables("M04_shop"), "shop_name ='" & Combo09.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb09.Text = DtView1(0)("shop_code")
                WK_ittpan = DtView1(0)("ittpan")
                ittpan2.Text = DtView1(0)("ittpan")
                If DtView1(0)("ittpan") = "1" Then Label1.Visible = True
            Else
                msg.Text = "該当の取扱店はありません。"
                Combo09.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub WRing()
        re_no.Text = "0"
        If Combo09.Text = Nothing Then
        Else
            If ittpan.Text <> ittpan2.Text Then
                msg.Text = "加入番号の変更をします。"
                re_no.Text = "1"
            End If
        End If
        If Combo08.Text = Nothing Then
        Else
            If code.Text <> code2.Text Then
                msg.Text = "加入番号の変更をします。"
                re_no.Text = "1"
            End If
        End If
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Number01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.LostFocus
        Call CK_Number01()   '購入金額
    End Sub
    Private Sub Combo07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo07.LostFocus
        Call CK_Combo07()    '保証期間
    End Sub
    Private Sub Combo08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo08.LostFocus
        Call CK_Combo08()    '保証範囲
    End Sub
    Private Sub Combo01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.LostFocus
        Call CK_Combo01()    '大学
    End Sub
    Private Sub Combo09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.LostFocus
        Call CK_Combo09()    '取扱店
    End Sub

    '******************************************************************
    '** 変更
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call F_CHK()    '** 項目チェック
        If Err_F = "0" Then

            Call WRing()    '取扱店
            If msg.Text <> Nothing Then
                ANS = MessageBox.Show("加入番号の変更をします。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then Cursor = System.Windows.Forms.Cursors.Default : Exit Sub 'いいえ
            End If

            DtView1 = New DataView(DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                If cmb07.Text <> Nothing Then WK_wrn_tem = cmb07.Text Else WK_wrn_tem = DtView1(i)("wrn_tem")
                If cmb08.Text <> Nothing Then WK_wrn_range = cmb08.Text Else WK_wrn_range = DtView1(i)("wrn_range")
                If cmb09.Text = Nothing Then WK_ittpan = DtView1(i)("ittpan")

                If DtView1(i)("suisen_flg") = "True" Then '推薦
                    WK_wrn_fee = WK_SUI
                Else
                    WK_wrn_fee = wrn_fee_Get(WK_ittpan, DtView1(i)("makr_code"), WK_wrn_tem, WK_wrn_range, DtView1(i)("nendo"))
                End If

                'T01_member
                strSQL = "UPDATE T01_member"
                strSQL += " SET wrn_fee = " & WK_wrn_fee
                If Number01.Value <> 0 Then
                    strSQL += ", prch_amnt = " & Number01.Value
                End If
                If cmb07.Text <> Nothing Then
                    strSQL += ", wrn_tem = " & cmb07.Text
                    If DtView1(i)("suisen_flg") = "True" Then '推薦
                    Else
                        strSQL += ", wrn_end = CONVERT(DATETIME, '" & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, CInt(DtView1(i)("wrn_tem")), DtView1(i)("makr_wrn_stat"))) & "', 102)"
                    End If
                End If
                If cmb08.Text <> Nothing Then
                    strSQL += ", wrn_range = " & cmb08.Text
                End If
                If cmb01.Text <> Nothing Then
                    strSQL += ", univ_code = " & cmb01.Text
                End If
                If cmb09.Text <> Nothing Then
                    strSQL += ", shop_code = " & cmb09.Text
                End If



                If re_no.Text = "1" Then
                    If ittpan2.Text = "True" Then
                        WK_code = Count_Get("E" & Mid(nendo.Text, Len(P_proc_y), 1) & Mid(code2.Text, 2, 2))
                    Else
                        WK_code = Count_Get(Mid(code2.Text, 1, 1) & Mid(nendo.Text, Len(P_proc_y), 1) & Mid(code2.Text, 2, 2))
                    End If
                    strSQL += ", code = '" & WK_code & "'"
                End If
                strSQL += " WHERE (code = '" & DtView1(i)("code") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
                'T02_clct
                strSQL = "UPDATE T02_clct"
                strSQL += " SET invc_amnt = " & WK_wrn_fee
                If re_no.Text = "1" Then
                    strSQL += ", code = '" & WK_code & "'"
                End If
                strSQL += " WHERE (code = '" & DtView1(i)("code") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                If re_no.Text = "1" Then DtView1(i)("code") = WK_code
                If Number01.Value <> 0 Then DtView1(i)("prch_amnt") = Number01.Value
                If cmb07.Text <> Nothing Then DtView1(i)("wrn_tem_name") = Combo07.Text
                If cmb08.Text <> Nothing Then DtView1(i)("wrn_range_name") = Combo08.Text
                If cmb01.Text <> Nothing Then DtView1(i)("univ_name") = Combo01.Text
                If cmb09.Text <> Nothing Then DtView1(i)("shop_name") = Combo09.Text

                DtView1(i)("wrn_fee") = WK_wrn_fee
                P_PRAM1 = DtView1(i)("shop_name")
            Next

            code.Text = code2.Text
            If ittpan2.Text <> Nothing Then ittpan.Text = ittpan2.Text
            msg.Text = Nothing
            MessageBox.Show("変更しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            P_RTN = "1"
        End If
    End Sub

    '******************************************************************
    '** 削除
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        P_PRAM2 = Nothing

        Dim F00_Form10_03 As New F00_Form10_03
        F00_Form10_03.ShowDialog()

        If P_RTN = "1" Then
            'ANS = MessageBox.Show("対象のデータを削除します。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            'If ANS = "2" Then Cursor = System.Windows.Forms.Cursors.Default : Exit Sub 'いいえ

            DtView1 = New DataView(DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                strSQL = "UPDATE T01_member"
                strSQL += " SET delt_flg = 1"
                strSQL += ", upd_date = CONVERT(DATETIME, '" & Now & "', 102)"
                strSQL += " WHERE (code = '" & DtView1(i)("code") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO T04_del"
                strSQL += " (code, del_Reason, del_date, empl_code)"
                strSQL += " VALUES ('" & DtView1(i)("code") & "'"
                strSQL += ", '" & P_PRAM3 & "'"
                strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
                strSQL += ", " & P_EMPL_NO & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            Next

            DsList1.Clear()
            Button1.Enabled = False
            Button4.Enabled = False
            MessageBox.Show("削除しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            P_RTN = "4"
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
