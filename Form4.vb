Public Class Form4
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DG_DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F, CHG_F As String
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
    Friend WithEvents DataGridEx1 As MrMax_Import.DataGridEx
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Number2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
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
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridBoolColumn2 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridBoolColumn3 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Number3 As GrapeCity.Win.Input.Interop.Number
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form4))
        Me.DataGridEx1 = New MrMax_Import.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn2 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridBoolColumn3 = New System.Windows.Forms.DataGridBoolColumn
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Number2 = New GrapeCity.Win.Input.Interop.Number
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        Me.Button2 = New System.Windows.Forms.Button
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Edit3 = New GrapeCity.Win.Input.Interop.Edit
        Me.Number3 = New GrapeCity.Win.Input.Interop.Number
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 84)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(1152, 496)
        Me.DataGridEx1.TabIndex = 5
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridBoolColumn1, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn10, Me.DataGridBoolColumn2, Me.DataGridBoolColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "02_売上データ"
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
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "氏名"
        Me.DataGridTextBoxColumn2.MappingName = "氏名"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 95
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "行"
        Me.DataGridTextBoxColumn3.MappingName = "行番号"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 30
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
        Me.DataGridTextBoxColumn5.Width = 130
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "分類"
        Me.DataGridTextBoxColumn6.MappingName = "分類ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 40
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "##,##0"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "単価"
        Me.DataGridTextBoxColumn7.MappingName = "単価2"
        Me.DataGridTextBoxColumn7.Width = 50
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "数量"
        Me.DataGridTextBoxColumn9.MappingName = "分割数量"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 40
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "SEQ"
        Me.DataGridTextBoxColumn8.MappingName = "SEQ"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 50
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "赤黒SEQ"
        Me.DataGridTextBoxColumn11.MappingName = "赤黒SEQ"
        Me.DataGridTextBoxColumn11.Width = 60
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn12.Format = "##,##0"
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "sprice"
        Me.DataGridTextBoxColumn12.MappingName = "sprice"
        Me.DataGridTextBoxColumn12.Width = 50
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "WSEQ1"
        Me.DataGridTextBoxColumn13.MappingName = "WSEQ1"
        Me.DataGridTextBoxColumn13.Width = 50
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "WSEQ2"
        Me.DataGridTextBoxColumn14.MappingName = "WSEQ2"
        Me.DataGridTextBoxColumn14.Width = 50
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "ERR"
        Me.DataGridTextBoxColumn15.MappingName = "ERR_F"
        Me.DataGridTextBoxColumn15.Width = 40
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "法人"
        Me.DataGridBoolColumn1.MappingName = "法人"
        Me.DataGridBoolColumn1.NullValue = CType(resources.GetObject("DataGridBoolColumn1.NullValue"), Object)
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 40
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn16.Format = "yyyy/MM"
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "処理日"
        Me.DataGridTextBoxColumn16.MappingName = "処理日"
        Me.DataGridTextBoxColumn16.ReadOnly = True
        Me.DataGridTextBoxColumn16.Width = 60
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn10.Format = "yyyy/MM/dd"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "処理日2"
        Me.DataGridTextBoxColumn10.MappingName = "処理日2"
        Me.DataGridTextBoxColumn10.Width = 60
        '
        'DataGridBoolColumn2
        '
        Me.DataGridBoolColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn2.FalseValue = False
        Me.DataGridBoolColumn2.HeaderText = "削除flg"
        Me.DataGridBoolColumn2.MappingName = "dlt_f"
        Me.DataGridBoolColumn2.NullValue = CType(resources.GetObject("DataGridBoolColumn2.NullValue"), Object)
        Me.DataGridBoolColumn2.TrueValue = True
        Me.DataGridBoolColumn2.Width = 40
        '
        'DataGridBoolColumn3
        '
        Me.DataGridBoolColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn3.FalseValue = False
        Me.DataGridBoolColumn3.HeaderText = "追加flg"
        Me.DataGridBoolColumn3.MappingName = "wrn_add_f"
        Me.DataGridBoolColumn3.NullValue = CType(resources.GetObject("DataGridBoolColumn3.NullValue"), Object)
        Me.DataGridBoolColumn3.TrueValue = True
        Me.DataGridBoolColumn3.Width = 40
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(76, 592)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(920, 16)
        Me.msg.TabIndex = 1374
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(4, 584)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "更　新"
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(1000, 584)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(64, 32)
        Me.Button99.TabIndex = 7
        Me.Button99.Text = "戻　る"
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Navy
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(12, 16)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(76, 20)
        Me.Label46.TabIndex = 1473
        Me.Label46.Text = "絞込み条件"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(292, 16)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(76, 60)
        Me.Label44.TabIndex = 1472
        Me.Label44.Text = "SEQ"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(100, 16)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(76, 60)
        Me.Label43.TabIndex = 1471
        Me.Label43.Text = "伝票NO"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number2
        '
        Me.Number2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("########0", "", "", "-", "", "", "0")
        Me.Number2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("########0", "", "", "-", "", "", "")
        Me.Number2.Location = New System.Drawing.Point(368, 36)
        Me.Number2.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Name = "Number2"
        Me.Number2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number2.Size = New System.Drawing.Size(68, 20)
        Me.Number2.TabIndex = 3
        Me.Number2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number2.Value = Nothing
        '
        'Edit1
        '
        Me.Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Edit1.Location = New System.Drawing.Point(176, 16)
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(112, 20)
        Me.Edit1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(472, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "検索"
        '
        'Edit2
        '
        Me.Edit2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Edit2.Location = New System.Drawing.Point(176, 36)
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(112, 20)
        Me.Edit2.TabIndex = 1
        '
        'Number1
        '
        Me.Number1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("########0", "", "", "-", "", "", "0")
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number1.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("########0", "", "", "-", "", "", "")
        Me.Number1.Location = New System.Drawing.Point(368, 16)
        Me.Number1.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(68, 20)
        Me.Number1.TabIndex = 2
        Me.Number1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number1.Value = Nothing
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(952, 12)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1475
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(980, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1474
        Me.CheckBox1.Visible = False
        '
        'Edit3
        '
        Me.Edit3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Edit3.Location = New System.Drawing.Point(176, 56)
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(112, 20)
        Me.Edit3.TabIndex = 1476
        '
        'Number3
        '
        Me.Number3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Number3.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("########0", "", "", "-", "", "", "0")
        Me.Number3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number3.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number3.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("########0", "", "", "-", "", "", "")
        Me.Number3.Location = New System.Drawing.Point(368, 56)
        Me.Number3.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number3.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number3.Name = "Number3"
        Me.Number3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number3.Size = New System.Drawing.Size(68, 20)
        Me.Number3.TabIndex = 1477
        Me.Number3.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number3.Value = Nothing
        '
        'Form4
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1162, 620)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Number3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGridEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "エラー修正(手入力)"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msg.Text = Nothing

        DtGrd_set()

        Dim tbl As New DataTable
        tbl = DG_DsList1.Tables("02_売上データ")
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

    End Sub

    '********************************************************************
    '**  検索
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DtGrd_set()
        msg.Text = Nothing
    End Sub

    Sub DtGrd_set()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        DG_DsList1.Clear()
        strSQL = "SELECT * FROM [02_売上データ]"
        strSQL += " WHERE (SEQ = 0)"
        If Edit1.Text <> Nothing Then strSQL += " or (伝票NO LIKE '" & Edit1.Text & "%')"
        If Edit2.Text <> Nothing Then strSQL += " or (伝票NO LIKE '" & Edit2.Text & "%')"
        If Edit3.Text <> Nothing Then strSQL += " or (伝票NO LIKE '" & Edit3.Text & "%')"
        If Number1.Value <> 0 Then strSQL += " or (SEQ = " & Number1.Value & ")"
        If Number2.Value <> 0 Then strSQL += " or (SEQ = " & Number2.Value & ")"
        If Number3.Value <> 0 Then strSQL += " or (SEQ = " & Number3.Value & ")"
        strSQL += "ORDER BY 伝票NO, 行番号"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(DG_DsList1, "02_売上データ")
        DB_CLOSE()

        If r = 0 Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'Private Sub DataGridEx1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
    '    If DataGridEx1.CurrentRowIndex >= 0 Then
    '        DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
    '    End If
    'End Sub

    'Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
    '    If DataGridEx1.CurrentRowIndex <= r - 1 Then
    '        Select Case keyData
    '            Case Is = Keys.Return
    '            Case Is = Keys.Space
    '                'If DataGridEx1(DataGridEx1.CurrentRowIndex, 14) = "False" Then
    '                '    DataGridEx1(DataGridEx1.CurrentRowIndex, 14) = CheckBox1.Checked
    '                'Else
    '                '    DataGridEx1(DataGridEx1.CurrentRowIndex, 14) = CheckBox2.Checked
    '                'End If
    '                'If DataGridEx1(DataGridEx1.CurrentRowIndex, 17) = "False" Then
    '                '    DataGridEx1(DataGridEx1.CurrentRowIndex, 17) = CheckBox1.Checked
    '                'Else
    '                '    DataGridEx1(DataGridEx1.CurrentRowIndex, 17) = CheckBox2.Checked
    '                'End If
    '                'If DataGridEx1(DataGridEx1.CurrentRowIndex, 18) = "False" Then
    '                '    DataGridEx1(DataGridEx1.CurrentRowIndex, 18) = CheckBox1.Checked
    '                'Else
    '                '    DataGridEx1(DataGridEx1.CurrentRowIndex, 18) = CheckBox2.Checked
    '                'End If
    '            Case Is = Keys.Delete
    '            Case Is = Keys.Right
    '            Case Is = Keys.Left
    '        End Select
    '    End If
    'End Sub

    Private Sub DataGridEx1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))

            If hitinfo.Column = 14 Then  'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                If DataGridEx1.CurrentRowIndex <= r - 1 Then
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 14) = "False" Then
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 14) = CheckBox1.Checked
                    Else
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 14) = CheckBox2.Checked
                    End If
                End If
            End If
            If hitinfo.Column = 17 Then  'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                If DataGridEx1.CurrentRowIndex <= r - 1 Then
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 17) = "False" Then
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 17) = CheckBox1.Checked
                    Else
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 17) = CheckBox2.Checked
                    End If
                End If
            End If
            If hitinfo.Column = 18 Then  'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                If DataGridEx1.CurrentRowIndex <= r - 1 Then
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 18) = "False" Then
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 18) = CheckBox1.Checked
                    Else
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 18) = CheckBox2.Checked
                    End If
                End If
            End If


        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()

        DtView1 = New DataView(DG_DsList1.Tables("02_売上データ"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1

            strSQL = "UPDATE [02_売上データ]"
            strSQL += " SET 単価2 = " & DtView1(i)("単価2") & ""
            strSQL += ", 赤黒SEQ = " & DtView1(i)("赤黒SEQ") & ""
            strSQL += ", sprice = " & DtView1(i)("sprice") & ""
            strSQL += ", WSEQ1 = " & DtView1(i)("WSEQ1") & ""
            strSQL += ", WSEQ2 = " & DtView1(i)("WSEQ2") & ""
            strSQL += ", ERR_F = '" & DtView1(i)("ERR_F") & "'"
            strSQL += ", 処理日2 = '" & DtView1(i)("処理日2") & "'"
            If DtView1(i)("法人") = "True" Then
                strSQL += ", 法人 = 1"
            Else
                strSQL += ", 法人 = 0"
            End If
            If DtView1(i)("dlt_f") = "True" Then
                strSQL += ", dlt_f = 1"
            Else
                strSQL += ", dlt_f = 0"
            End If
            If DtView1(i)("wrn_add_f") = "True" Then
                strSQL += ", wrn_add_f = 1"
            Else
                strSQL += ", wrn_add_f = 0"
            End If
            strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        Next

        DB_CLOSE()
        msg.Text = "修正しました。"
        DtGrd_set()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DG_DsList1.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class
