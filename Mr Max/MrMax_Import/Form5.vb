Public Class Form5
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2 As New DataSet
    Dim DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, CHG_F As String
    Dim i, r, n As Integer

    Dim BR_Edit1 As String
    Dim BR_Edit02, BR_Edit03, BR_Edit04, BR_Edit05, BR_Edit06, BR_Edit07, BR_Edit08, BR_Edit09, BR_Edit10, BR_Edit11 As String
    Dim BR_Combo07, BR_Combo08 As String
    Dim BR_Number1, BR_Number2, BR_Number3, BR_Number4, BR_Number5, BR_Number6, BR_Number7 As Integer
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
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label016 As System.Windows.Forms.Label
    Friend WithEvents Label015 As System.Windows.Forms.Label
    Friend WithEvents Label014 As System.Windows.Forms.Label
    Friend WithEvents Label013 As System.Windows.Forms.Label
    Friend WithEvents Label012 As System.Windows.Forms.Label
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Label009 As System.Windows.Forms.Label
    Friend WithEvents Label008 As System.Windows.Forms.Label
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit09 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit10 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit11 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Combo07 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo08 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number3 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number4 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number5 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number6 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number7 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents cmb07 As System.Windows.Forms.Label
    Friend WithEvents cmb08 As System.Windows.Forms.Label
    Friend WithEvents cnt As System.Windows.Forms.Label
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
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label03 As System.Windows.Forms.Label
    Friend WithEvents Label05 As System.Windows.Forms.Label
    Friend WithEvents Label07 As System.Windows.Forms.Label
    Friend WithEvents Label08 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label09 As System.Windows.Forms.Label
    Friend WithEvents Label06 As System.Windows.Forms.Label
    Friend WithEvents Label04 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label017 As System.Windows.Forms.Label
    Friend WithEvents Label190 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label43 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label016 = New System.Windows.Forms.Label
        Me.Label015 = New System.Windows.Forms.Label
        Me.Label014 = New System.Windows.Forms.Label
        Me.Label013 = New System.Windows.Forms.Label
        Me.Label012 = New System.Windows.Forms.Label
        Me.Label011 = New System.Windows.Forms.Label
        Me.Label010 = New System.Windows.Forms.Label
        Me.Label009 = New System.Windows.Forms.Label
        Me.Label008 = New System.Windows.Forms.Label
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Label003 = New System.Windows.Forms.Label
        Me.Label120 = New System.Windows.Forms.Label
        Me.Label110 = New System.Windows.Forms.Label
        Me.Label100 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label03 = New System.Windows.Forms.Label
        Me.Label05 = New System.Windows.Forms.Label
        Me.Label07 = New System.Windows.Forms.Label
        Me.Label08 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label09 = New System.Windows.Forms.Label
        Me.Label06 = New System.Windows.Forms.Label
        Me.Label04 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit09 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit10 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit11 = New GrapeCity.Win.Input.Interop.Edit
        Me.Combo07 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo08 = New GrapeCity.Win.Input.Interop.Combo
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
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number
        Me.Number2 = New GrapeCity.Win.Input.Interop.Number
        Me.Number3 = New GrapeCity.Win.Input.Interop.Number
        Me.Number4 = New GrapeCity.Win.Input.Interop.Number
        Me.Number5 = New GrapeCity.Win.Input.Interop.Number
        Me.Number6 = New GrapeCity.Win.Input.Interop.Number
        Me.Number7 = New GrapeCity.Win.Input.Interop.Number
        Me.cmb07 = New System.Windows.Forms.Label
        Me.cmb08 = New System.Windows.Forms.Label
        Me.cnt = New System.Windows.Forms.Label
        Me.Label017 = New System.Windows.Forms.Label
        Me.Label190 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(8, 8)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(76, 20)
        Me.Label43.TabIndex = 1473
        Me.Label43.Text = "伝票NO"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Edit1.Format = "9"
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(84, 8)
        Me.Edit1.MaxLength = 20
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(124, 20)
        Me.Edit1.TabIndex = 0
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(80, 592)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(920, 16)
        Me.msg.TabIndex = 1476
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 584)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 32)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "登　録"
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(1004, 584)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(64, 32)
        Me.Button99.TabIndex = 20
        Me.Button99.Text = "戻　る"
        '
        'Label016
        '
        Me.Label016.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label016.Location = New System.Drawing.Point(752, 116)
        Me.Label016.Name = "Label016"
        Me.Label016.Size = New System.Drawing.Size(116, 20)
        Me.Label016.TabIndex = 1522
        Me.Label016.Text = "Label016"
        Me.Label016.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label015
        '
        Me.Label015.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label015.Location = New System.Drawing.Point(752, 96)
        Me.Label015.Name = "Label015"
        Me.Label015.Size = New System.Drawing.Size(116, 20)
        Me.Label015.TabIndex = 1521
        Me.Label015.Text = "Label015"
        Me.Label015.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label014
        '
        Me.Label014.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label014.Location = New System.Drawing.Point(344, 116)
        Me.Label014.Name = "Label014"
        Me.Label014.Size = New System.Drawing.Size(316, 20)
        Me.Label014.TabIndex = 1520
        Me.Label014.Text = "Label014"
        Me.Label014.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label013
        '
        Me.Label013.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label013.Location = New System.Drawing.Point(344, 96)
        Me.Label013.Name = "Label013"
        Me.Label013.Size = New System.Drawing.Size(316, 20)
        Me.Label013.TabIndex = 1519
        Me.Label013.Text = "Label013"
        Me.Label013.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label012
        '
        Me.Label012.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label012.Location = New System.Drawing.Point(344, 76)
        Me.Label012.Name = "Label012"
        Me.Label012.Size = New System.Drawing.Size(316, 20)
        Me.Label012.TabIndex = 1518
        Me.Label012.Text = "Label012"
        Me.Label012.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label011
        '
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.Location = New System.Drawing.Point(344, 56)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(316, 20)
        Me.Label011.TabIndex = 1517
        Me.Label011.Text = "Label011"
        Me.Label011.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label010
        '
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.Location = New System.Drawing.Point(344, 36)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(316, 20)
        Me.Label010.TabIndex = 1516
        Me.Label010.Text = "Label010"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label009
        '
        Me.Label009.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label009.Location = New System.Drawing.Point(92, 96)
        Me.Label009.Name = "Label009"
        Me.Label009.Size = New System.Drawing.Size(160, 20)
        Me.Label009.TabIndex = 1515
        Me.Label009.Text = "Label009"
        Me.Label009.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label008
        '
        Me.Label008.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label008.Location = New System.Drawing.Point(92, 76)
        Me.Label008.Name = "Label008"
        Me.Label008.Size = New System.Drawing.Size(160, 20)
        Me.Label008.TabIndex = 1514
        Me.Label008.Text = "Label008"
        Me.Label008.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label007
        '
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.Location = New System.Drawing.Point(92, 56)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(160, 20)
        Me.Label007.TabIndex = 1513
        Me.Label007.Text = "Label007"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label006
        '
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.Location = New System.Drawing.Point(92, 36)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(160, 20)
        Me.Label006.TabIndex = 1512
        Me.Label006.Text = "Label006"
        Me.Label006.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label005
        '
        Me.Label005.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label005.Location = New System.Drawing.Point(752, 76)
        Me.Label005.Name = "Label005"
        Me.Label005.Size = New System.Drawing.Size(116, 20)
        Me.Label005.TabIndex = 1511
        Me.Label005.Text = "Label005"
        Me.Label005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label004
        '
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.Location = New System.Drawing.Point(752, 56)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(116, 20)
        Me.Label004.TabIndex = 1510
        Me.Label004.Text = "Label004"
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label003
        '
        Me.Label003.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label003.Location = New System.Drawing.Point(752, 36)
        Me.Label003.Name = "Label003"
        Me.Label003.Size = New System.Drawing.Size(116, 20)
        Me.Label003.TabIndex = 1509
        Me.Label003.Text = "Label003"
        Me.Label003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label120
        '
        Me.Label120.BackColor = System.Drawing.Color.Navy
        Me.Label120.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label120.ForeColor = System.Drawing.Color.White
        Me.Label120.Location = New System.Drawing.Point(668, 116)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(84, 20)
        Me.Label120.TabIndex = 1487
        Me.Label120.Text = "完了日"
        Me.Label120.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label110
        '
        Me.Label110.BackColor = System.Drawing.Color.Navy
        Me.Label110.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label110.ForeColor = System.Drawing.Color.White
        Me.Label110.Location = New System.Drawing.Point(668, 96)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(84, 20)
        Me.Label110.TabIndex = 1486
        Me.Label110.Text = "販売者ｺｰﾄﾞ"
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label100
        '
        Me.Label100.BackColor = System.Drawing.Color.Navy
        Me.Label100.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label100.ForeColor = System.Drawing.Color.White
        Me.Label100.Location = New System.Drawing.Point(260, 36)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(84, 100)
        Me.Label100.TabIndex = 1485
        Me.Label100.Text = "住所"
        Me.Label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(8, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 1484
        Me.Label9.Text = "郵便番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(8, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 1483
        Me.Label8.Text = "TEL2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(8, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 1482
        Me.Label7.Text = "TEL1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 1481
        Me.Label6.Text = "氏名"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(668, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 1480
        Me.Label5.Text = "一般売掛区分"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(668, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 1479
        Me.Label4.Text = "配送店ｺｰﾄﾞ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(668, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 1478
        Me.Label3.Text = "発行日"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1116, 108)
        Me.Label1.TabIndex = 1524
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(592, 192)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 20)
        Me.Label14.TabIndex = 1579
        Me.Label14.Text = "税区分"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Navy
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(768, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 20)
        Me.Label17.TabIndex = 1544
        Me.Label17.Text = "値引額"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Navy
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(768, 172)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 20)
        Me.Label18.TabIndex = 1543
        Me.Label18.Text = "単価2"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Navy
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(592, 232)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 20)
        Me.Label16.TabIndex = 1542
        Me.Label16.Text = "割引率"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(592, 212)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 20)
        Me.Label15.TabIndex = 1541
        Me.Label15.Text = "値引割引区分"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(300, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 20)
        Me.Label11.TabIndex = 1540
        Me.Label11.Text = "ﾚｼｰﾄ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label03
        '
        Me.Label03.BackColor = System.Drawing.Color.Navy
        Me.Label03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label03.ForeColor = System.Drawing.Color.White
        Me.Label03.Location = New System.Drawing.Point(8, 172)
        Me.Label03.Name = "Label03"
        Me.Label03.Size = New System.Drawing.Size(84, 20)
        Me.Label03.TabIndex = 1539
        Me.Label03.Text = "品名漢字"
        Me.Label03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label05
        '
        Me.Label05.BackColor = System.Drawing.Color.Navy
        Me.Label05.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label05.ForeColor = System.Drawing.Color.White
        Me.Label05.Location = New System.Drawing.Point(8, 212)
        Me.Label05.Name = "Label05"
        Me.Label05.Size = New System.Drawing.Size(84, 20)
        Me.Label05.TabIndex = 1538
        Me.Label05.Text = "型番漢字"
        Me.Label05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label07
        '
        Me.Label07.BackColor = System.Drawing.Color.Navy
        Me.Label07.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label07.ForeColor = System.Drawing.Color.White
        Me.Label07.Location = New System.Drawing.Point(300, 152)
        Me.Label07.Name = "Label07"
        Me.Label07.Size = New System.Drawing.Size(84, 20)
        Me.Label07.TabIndex = 1537
        Me.Label07.Text = "分類ｺｰﾄﾞ"
        Me.Label07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label08
        '
        Me.Label08.BackColor = System.Drawing.Color.Navy
        Me.Label08.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label08.ForeColor = System.Drawing.Color.White
        Me.Label08.Location = New System.Drawing.Point(300, 172)
        Me.Label08.Name = "Label08"
        Me.Label08.Size = New System.Drawing.Size(84, 20)
        Me.Label08.TabIndex = 1536
        Me.Label08.Text = "品種ｺｰﾄﾞ"
        Me.Label08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(592, 152)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 20)
        Me.Label12.TabIndex = 1535
        Me.Label12.Text = "売上数"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(592, 172)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 1534
        Me.Label13.Text = "ﾏｽﾀ単価"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(300, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 1533
        Me.Label10.Text = "ｻｲｽﾞ"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label09
        '
        Me.Label09.BackColor = System.Drawing.Color.Navy
        Me.Label09.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label09.ForeColor = System.Drawing.Color.White
        Me.Label09.Location = New System.Drawing.Point(300, 192)
        Me.Label09.Name = "Label09"
        Me.Label09.Size = New System.Drawing.Size(84, 20)
        Me.Label09.TabIndex = 1532
        Me.Label09.Text = "ｶﾗｰ"
        Me.Label09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label06
        '
        Me.Label06.BackColor = System.Drawing.Color.Navy
        Me.Label06.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label06.ForeColor = System.Drawing.Color.White
        Me.Label06.Location = New System.Drawing.Point(8, 232)
        Me.Label06.Name = "Label06"
        Me.Label06.Size = New System.Drawing.Size(84, 20)
        Me.Label06.TabIndex = 1531
        Me.Label06.Text = "型番ｶﾅ"
        Me.Label06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label04
        '
        Me.Label04.BackColor = System.Drawing.Color.Navy
        Me.Label04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label04.ForeColor = System.Drawing.Color.White
        Me.Label04.Location = New System.Drawing.Point(8, 192)
        Me.Label04.Name = "Label04"
        Me.Label04.Size = New System.Drawing.Size(84, 20)
        Me.Label04.TabIndex = 1530
        Me.Label04.Text = "品名ｶﾅ"
        Me.Label04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.Color.Navy
        Me.Label02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label02.ForeColor = System.Drawing.Color.White
        Me.Label02.Location = New System.Drawing.Point(8, 152)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(84, 20)
        Me.Label02.TabIndex = 1529
        Me.Label02.Text = "商品ｺｰﾄﾞ"
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit02
        '
        Me.Edit02.Format = "9"
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(92, 152)
        Me.Edit02.MaxLength = 13
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(200, 20)
        Me.Edit02.TabIndex = 1
        Me.Edit02.Text = "02"
        '
        'Edit03
        '
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(92, 172)
        Me.Edit03.MaxLength = 100
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(200, 20)
        Me.Edit03.TabIndex = 2
        Me.Edit03.Text = "Edit03"
        '
        'Edit04
        '
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(92, 192)
        Me.Edit04.MaxLength = 100
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(200, 20)
        Me.Edit04.TabIndex = 3
        Me.Edit04.Text = "Edit04"
        '
        'Edit05
        '
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(92, 212)
        Me.Edit05.MaxLength = 100
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(200, 20)
        Me.Edit05.TabIndex = 4
        Me.Edit05.Text = "Edit05"
        '
        'Edit06
        '
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(92, 232)
        Me.Edit06.MaxLength = 100
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(200, 20)
        Me.Edit06.TabIndex = 5
        Me.Edit06.Text = "Edit06"
        '
        'Edit09
        '
        Me.Edit09.LengthAsByte = True
        Me.Edit09.Location = New System.Drawing.Point(384, 192)
        Me.Edit09.MaxLength = 100
        Me.Edit09.Name = "Edit09"
        Me.Edit09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit09.Size = New System.Drawing.Size(200, 20)
        Me.Edit09.TabIndex = 8
        Me.Edit09.Text = "Edit09"
        '
        'Edit10
        '
        Me.Edit10.LengthAsByte = True
        Me.Edit10.Location = New System.Drawing.Point(384, 212)
        Me.Edit10.MaxLength = 100
        Me.Edit10.Name = "Edit10"
        Me.Edit10.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit10.Size = New System.Drawing.Size(200, 20)
        Me.Edit10.TabIndex = 9
        Me.Edit10.Text = "Edit10"
        '
        'Edit11
        '
        Me.Edit11.LengthAsByte = True
        Me.Edit11.Location = New System.Drawing.Point(384, 232)
        Me.Edit11.MaxLength = 100
        Me.Edit11.Name = "Edit11"
        Me.Edit11.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit11.Size = New System.Drawing.Size(200, 20)
        Me.Edit11.TabIndex = 10
        Me.Edit11.Text = "Edit11"
        '
        'Combo07
        '
        Me.Combo07.Location = New System.Drawing.Point(384, 152)
        Me.Combo07.MaxDropDownItems = 20
        Me.Combo07.Name = "Combo07"
        Me.Combo07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo07.Size = New System.Drawing.Size(200, 20)
        Me.Combo07.TabIndex = 6
        Me.Combo07.Value = "Combo07"
        '
        'Combo08
        '
        Me.Combo08.Location = New System.Drawing.Point(384, 172)
        Me.Combo08.MaxDropDownItems = 20
        Me.Combo08.Name = "Combo08"
        Me.Combo08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo08.Size = New System.Drawing.Size(200, 20)
        Me.Combo08.TabIndex = 7
        Me.Combo08.Value = "Combo08"
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGrid1.CaptionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGrid1.CaptionText = "ﾋﾝﾄ"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 256)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(1144, 324)
        Me.DataGrid1.TabIndex = 18
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "02_売上データ"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn1.MappingName = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "品名漢字"
        Me.DataGridTextBoxColumn2.MappingName = "品名漢字"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "品名ｶﾅ"
        Me.DataGridTextBoxColumn3.MappingName = "品名ｶﾅ"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "型番漢字"
        Me.DataGridTextBoxColumn4.MappingName = "型番漢字"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "型番ｶﾅ"
        Me.DataGridTextBoxColumn5.MappingName = "型番ｶﾅ"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "分類ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn6.MappingName = "分類ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "品種ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn7.MappingName = "品種ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "ｶﾗｰ"
        Me.DataGridTextBoxColumn8.MappingName = "ｶﾗｰ"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "ｻｲｽﾞ"
        Me.DataGridTextBoxColumn9.MappingName = "ｻｲｽﾞ"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "ﾚｼｰﾄ"
        Me.DataGridTextBoxColumn10.MappingName = "ﾚｼｰﾄ"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "売上数"
        Me.DataGridTextBoxColumn11.MappingName = "売上数"
        Me.DataGridTextBoxColumn11.NullText = ""
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "ﾏｽﾀ単価"
        Me.DataGridTextBoxColumn12.MappingName = "ﾏｽﾀ単価"
        Me.DataGridTextBoxColumn12.NullText = ""
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "税区分"
        Me.DataGridTextBoxColumn13.MappingName = "税区分"
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "値引割引区分"
        Me.DataGridTextBoxColumn14.MappingName = "値引割引区分"
        Me.DataGridTextBoxColumn14.NullText = ""
        Me.DataGridTextBoxColumn14.Width = 75
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "割引率"
        Me.DataGridTextBoxColumn15.MappingName = "割引率"
        Me.DataGridTextBoxColumn15.NullText = ""
        Me.DataGridTextBoxColumn15.Width = 75
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "値引額"
        Me.DataGridTextBoxColumn16.MappingName = "値引額"
        Me.DataGridTextBoxColumn16.NullText = ""
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "単価2"
        Me.DataGridTextBoxColumn17.MappingName = "単価2"
        Me.DataGridTextBoxColumn17.NullText = ""
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'Number1
        '
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number1.Location = New System.Drawing.Point(676, 152)
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(84, 20)
        Me.Number1.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.TabIndex = 11
        Me.Number1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number2
        '
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,##0", "", "", "-", "", "", "0")
        Me.Number2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,##0", "", "", "-", "", "", "0")
        Me.Number2.Location = New System.Drawing.Point(676, 172)
        Me.Number2.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Name = "Number2"
        Me.Number2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number2.Size = New System.Drawing.Size(84, 20)
        Me.Number2.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.TabIndex = 12
        Me.Number2.Value = Nothing
        '
        'Number3
        '
        Me.Number3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number3.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number3.Location = New System.Drawing.Point(676, 192)
        Me.Number3.Name = "Number3"
        Me.Number3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number3.Size = New System.Drawing.Size(84, 20)
        Me.Number3.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number3.TabIndex = 13
        Me.Number3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number4
        '
        Me.Number4.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number4.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number4.Location = New System.Drawing.Point(676, 212)
        Me.Number4.Name = "Number4"
        Me.Number4.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number4.Size = New System.Drawing.Size(84, 20)
        Me.Number4.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number4.TabIndex = 14
        Me.Number4.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number5
        '
        Me.Number5.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number5.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number5.Location = New System.Drawing.Point(676, 232)
        Me.Number5.Name = "Number5"
        Me.Number5.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number5.Size = New System.Drawing.Size(84, 20)
        Me.Number5.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number5.TabIndex = 15
        Me.Number5.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number6
        '
        Me.Number6.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number6.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number6.Location = New System.Drawing.Point(852, 152)
        Me.Number6.Name = "Number6"
        Me.Number6.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number6.Size = New System.Drawing.Size(84, 20)
        Me.Number6.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number6.TabIndex = 16
        Me.Number6.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number7
        '
        Me.Number7.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,##0", "", "", "-", "", "", "0")
        Me.Number7.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number7.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number7.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,##0", "", "", "-", "", "", "0")
        Me.Number7.Location = New System.Drawing.Point(852, 172)
        Me.Number7.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number7.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number7.Name = "Number7"
        Me.Number7.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number7.Size = New System.Drawing.Size(84, 20)
        Me.Number7.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number7.TabIndex = 17
        Me.Number7.Value = Nothing
        '
        'cmb07
        '
        Me.cmb07.Location = New System.Drawing.Point(972, 168)
        Me.cmb07.Name = "cmb07"
        Me.cmb07.Size = New System.Drawing.Size(48, 16)
        Me.cmb07.TabIndex = 1606
        Me.cmb07.Text = "cmb07"
        Me.cmb07.Visible = False
        '
        'cmb08
        '
        Me.cmb08.Location = New System.Drawing.Point(972, 188)
        Me.cmb08.Name = "cmb08"
        Me.cmb08.Size = New System.Drawing.Size(48, 16)
        Me.cmb08.TabIndex = 1607
        Me.cmb08.Text = "cmb08"
        Me.cmb08.Visible = False
        '
        'cnt
        '
        Me.cnt.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.cnt.Location = New System.Drawing.Point(1044, 260)
        Me.cnt.Name = "cnt"
        Me.cnt.Size = New System.Drawing.Size(100, 12)
        Me.cnt.TabIndex = 1608
        Me.cnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label017
        '
        Me.Label017.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label017.Location = New System.Drawing.Point(960, 36)
        Me.Label017.Name = "Label017"
        Me.Label017.Size = New System.Drawing.Size(116, 20)
        Me.Label017.TabIndex = 1610
        Me.Label017.Text = "Label017"
        Me.Label017.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label190
        '
        Me.Label190.BackColor = System.Drawing.Color.Navy
        Me.Label190.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label190.ForeColor = System.Drawing.Color.White
        Me.Label190.Location = New System.Drawing.Point(876, 36)
        Me.Label190.Name = "Label190"
        Me.Label190.Size = New System.Drawing.Size(84, 20)
        Me.Label190.TabIndex = 1609
        Me.Label190.Text = "処理日"
        Me.Label190.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(768, 192)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 20)
        Me.Label19.TabIndex = 1612
        Me.Label19.Text = "計上日"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.Location = New System.Drawing.Point(852, 192)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(100, 20)
        Me.Date1.TabIndex = 18
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2012, 1, 17, 17, 14, 49, 0))
        '
        'Form5
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1162, 620)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label017)
        Me.Controls.Add(Me.Label190)
        Me.Controls.Add(Me.cnt)
        Me.Controls.Add(Me.cmb08)
        Me.Controls.Add(Me.cmb07)
        Me.Controls.Add(Me.Number7)
        Me.Controls.Add(Me.Number6)
        Me.Controls.Add(Me.Number5)
        Me.Controls.Add(Me.Number4)
        Me.Controls.Add(Me.Number3)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Combo08)
        Me.Controls.Add(Me.Combo07)
        Me.Controls.Add(Me.Edit11)
        Me.Controls.Add(Me.Edit10)
        Me.Controls.Add(Me.Edit09)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label03)
        Me.Controls.Add(Me.Label05)
        Me.Controls.Add(Me.Label07)
        Me.Controls.Add(Me.Label08)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label09)
        Me.Controls.Add(Me.Label06)
        Me.Controls.Add(Me.Label04)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label016)
        Me.Controls.Add(Me.Label015)
        Me.Controls.Add(Me.Label014)
        Me.Controls.Add(Me.Label013)
        Me.Controls.Add(Me.Label012)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Label009)
        Me.Controls.Add(Me.Label008)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label120)
        Me.Controls.Add(Me.Label110)
        Me.Controls.Add(Me.Label100)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Edit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "機種登録"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CMB_SET() '** コンボボックスセット

        DsList2.Clear()
        strSQL = "SELECT *"
        strSQL += " FROM [02_売上データ]"
        strSQL += " WHERE (削除ﾌﾗｸﾞ = '1')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList2, "02_売上データ")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList2.Tables("02_売上データ")
        DataGrid1.DataSource = tbl

        clr()

    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CMB_SET()
        DsCMB.Clear()

        '分類
        strSQL = "SELECT CLS_CODE, CLS_CODE + ':' + CLS_CODE_NAME AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '022')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "CLS_022")
        DB_CLOSE()

        Combo07.DataSource = DsCMB.Tables("CLS_022")
        Combo07.DisplayMember = "CLS_CODE_NAME"
        Combo07.ValueMember = "CLS_CODE"

        '品種
        strSQL = "SELECT CAT_CODE, CAT_CODE + ':' + ITEM_NAME AS ITEM_NAME"
        strSQL += " FROM M08_KBN_CAT"
        strSQL += " ORDER BY CAT_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "M08_KBN_CAT")
        DB_CLOSE()

        Combo08.DataSource = DsCMB.Tables("M08_KBN_CAT")
        Combo08.DisplayMember = "ITEM_NAME"
        Combo08.ValueMember = "CAT_CODE"

    End Sub

    '********************************************************************
    '**  取込み情報取得
    '********************************************************************
    Sub scan()
        msg.Text = Nothing
        clr()

        DsList1.Clear()
        strSQL = "SELECT *"
        strSQL += " FROM [02_売上データ]"
        strSQL += " WHERE (伝票NO = '" & Edit1.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(DsList1, "02_売上データ")
        DB_CLOSE()

        If r = 0 Then
            msg.Text = "該当なし"
        Else
            Label1.Visible = False
            DtView1 = New DataView(DsList1.Tables("02_売上データ"), "", "", DataViewRowState.CurrentRows)
            Label003.Text = DtView1(0)("発行日")
            Label004.Text = DtView1(0)("配送店ｺｰﾄﾞ")
            Label005.Text = DtView1(0)("一般売掛区分")
            Label006.Text = DtView1(0)("氏名")
            Label007.Text = DtView1(0)("TEL1")
            Label008.Text = DtView1(0)("TEL2")
            Label009.Text = DtView1(0)("郵便番号")
            Label010.Text = DtView1(0)("住所1")
            Label011.Text = DtView1(0)("住所2")
            Label012.Text = DtView1(0)("住所3")
            Label013.Text = DtView1(0)("住所4")
            Label014.Text = DtView1(0)("住所5")
            Label015.Text = DtView1(0)("販売者ｺｰﾄﾞ")
            Label016.Text = DtView1(0)("完了日")
            Label017.Text = DtView1(0)("処理日")
            Date1.Text = P_DATE

            Label02.Visible = True : Edit02.Visible = True : Edit02.Focus()
            Label03.Visible = True : Edit03.Visible = True
            Label04.Visible = True : Edit04.Visible = True
            Label05.Visible = True : Edit05.Visible = True
            Label06.Visible = True : Edit06.Visible = True
            Label07.Visible = True : Combo07.Visible = True
            Label08.Visible = True : Combo08.Visible = True
            Label09.Visible = True : Edit09.Visible = True
            Label10.Visible = True : Edit10.Visible = True
            Label11.Visible = True : Edit11.Visible = True
            Label12.Visible = True : Number1.Visible = True
            Label13.Visible = True : Number2.Visible = True
            Label14.Visible = True : Number3.Visible = True
            Label15.Visible = True : Number4.Visible = True
            Label16.Visible = True : Number5.Visible = True
            Label17.Visible = True : Number6.Visible = True
            Label18.Visible = True : Number7.Visible = True
            Label19.Visible = True : Date1.Visible = True

            DataGrid1.Visible = True : cnt.Visible = True

            Button1.Enabled = True
        End If

    End Sub

    Sub clr()
        msg.Text = Nothing
        DsList2.Clear()
        cnt.Text = Nothing
        Label1.Visible = True

        Edit02.Text = Nothing
        Edit03.Text = Nothing
        Edit04.Text = Nothing
        Edit05.Text = Nothing
        Edit06.Text = Nothing
        Combo07.Text = Nothing : cmb07.Text = Nothing
        Combo08.Text = Nothing : cmb08.Text = Nothing
        Edit09.Text = Nothing
        Edit10.Text = Nothing
        Edit11.Text = Nothing
        Number1.Value = 0
        Number2.Value = 0
        Number3.Value = 0
        Number4.Value = 0
        Number5.Value = 0
        Number6.Value = 0
        Number7.Value = 0

        Label02.Visible = False : Edit02.Visible = False
        Label03.Visible = False : Edit03.Visible = False
        Label04.Visible = False : Edit04.Visible = False
        Label05.Visible = False : Edit05.Visible = False
        Label06.Visible = False : Edit06.Visible = False
        Label07.Visible = False : Combo07.Visible = False
        Label08.Visible = False : Combo08.Visible = False
        Label09.Visible = False : Edit09.Visible = False
        Label10.Visible = False : Edit10.Visible = False
        Label11.Visible = False : Edit11.Visible = False
        Label12.Visible = False : Number1.Visible = False
        Label13.Visible = False : Number2.Visible = False
        Label14.Visible = False : Number3.Visible = False
        Label15.Visible = False : Number4.Visible = False
        Label16.Visible = False : Number5.Visible = False
        Label17.Visible = False : Number6.Visible = False
        Label18.Visible = False : Number7.Visible = False
        Label19.Visible = False : Date1.Visible = False

        DataGrid1.Visible = False : cnt.Visible = False

        Button1.Enabled = False
    End Sub

    '********************************************************************
    '** ヒント情報取得
    '********************************************************************
    Sub hinto_scan()
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DsList2.Clear()
        strSQL = "SELECT *"
        strSQL += " FROM [02_売上データ]"
        strSQL += " WHERE (分類ｺｰﾄﾞ <> '30' AND 分類ｺｰﾄﾞ <> '91')"
        If Edit02.Text <> Nothing Then strSQL += " AND (商品ｺｰﾄﾞ = '" & Edit02.Text & "')"
        If Edit03.Text <> Nothing Then strSQL += " AND (品名漢字 LIKE '%" & Edit03.Text & "%')"
        If Edit04.Text <> Nothing Then strSQL += " AND (品名ｶﾅ LIKE '%" & Edit04.Text & "%')"
        If Edit05.Text <> Nothing Then strSQL += " AND (型番漢字 LIKE '%" & Edit05.Text & "%')"
        If Edit06.Text <> Nothing Then strSQL += " AND (型番ｶﾅ LIKE '%" & Edit06.Text & "%')"
        If cmb07.Text <> Nothing Then strSQL += " AND (分類ｺｰﾄﾞ = '" & cmb07.Text & "')"
        If cmb08.Text <> Nothing Then strSQL += " AND (品種ｺｰﾄﾞ = '" & cmb08.Text & "')"
        If Edit09.Text <> Nothing Then strSQL += " AND (ｶﾗｰ = '" & Edit09.Text & "')"
        If Edit10.Text <> Nothing Then strSQL += " AND (ｻｲｽﾞ = '" & Edit10.Text & "')"
        If Edit11.Text <> Nothing Then strSQL += " AND (ﾚｼｰﾄ = '" & Edit11.Text & "')"
        If Number1.Value <> 0 Then strSQL += " AND (売上数 = " & Number1.Value & ")"
        If Number2.Value <> 0 Then strSQL += " AND (ﾏｽﾀ単価 = " & Number2.Value & ")"
        If Number3.Value <> 0 Then strSQL += " AND (税区分 = '" & Number3.Value & "')"
        If Number4.Value <> 0 Then strSQL += " AND (値引割引区分 = '" & Number4.Value & "')"
        If Number5.Value <> 0 Then strSQL += " AND (割引率 = " & Number5.Value & ")"
        If Number6.Value <> 0 Then strSQL += " AND (値引額 = " & Number6.Value & ")"
        If Number7.Value <> 0 Then strSQL += " AND (単価2 = " & Number7.Value & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        n = DaList1.Fill(DsList2, "02_売上データ")
        DB_CLOSE()

        cnt.Text = n & "件"
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '** 項目チェック
    '********************************************************************
    Sub F_chk()
        Err_F = "0"

        CK_Edit02()
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

        CK_Edit03()
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        CK_Edit04()
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        CK_Edit05()
        If msg.Text <> Nothing Then Err_F = "1" : Edit05.Focus() : Exit Sub

        CK_Edit06()
        If msg.Text <> Nothing Then Err_F = "1" : Edit06.Focus() : Exit Sub

        CK_Combo07()
        If msg.Text <> Nothing Then Err_F = "1" : Combo07.Focus() : Exit Sub

        CK_Combo08()
        If msg.Text <> Nothing Then Err_F = "1" : Combo08.Focus() : Exit Sub

        CK_Number1()
        If msg.Text <> Nothing Then Err_F = "1" : Number1.Focus() : Exit Sub

        CK_Number7()
        If msg.Text <> Nothing Then Err_F = "1" : Number7.Focus() : Exit Sub


    End Sub
    Sub CK_Edit02()
        msg.Text = Nothing

        If Edit02.Text = Nothing Then
            msg.Text = "商品ｺｰﾄﾞ入力必須"
        Else
            If LenB(Edit02.Text) <> 13 Then
                msg.Text = "商品ｺｰﾄﾞは13桁"
            End If
        End If
    End Sub
    Sub CK_Edit03()
        msg.Text = Nothing

        If Edit03.Text = Nothing Then
            msg.Text = "品名漢字入力必須"
        End If
    End Sub
    Sub CK_Edit04()
        msg.Text = Nothing

        If Edit04.Text = Nothing Then
            msg.Text = "品名ｶﾅ入力必須"
        End If
    End Sub
    Sub CK_Edit05()
        msg.Text = Nothing

        If Edit05.Text = Nothing Then
            msg.Text = "型番漢字入力必須"
        End If
    End Sub
    Sub CK_Edit06()
        msg.Text = Nothing

        If Edit06.Text = Nothing Then
            msg.Text = "型番ｶﾅ入力必須"
        End If
    End Sub
    Sub CK_Combo07()
        msg.Text = Nothing
        cmb07.Text = Nothing

        WK_DtView1 = New DataView(DsCMB.Tables("CLS_022"), "CLS_CODE_NAME ='" & Combo07.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            msg.Text = "分類の該当なし"
        Else
            cmb07.Text = WK_DtView1(0)("CLS_CODE")
        End If
    End Sub
    Sub CK_Combo08()
        msg.Text = Nothing
        cmb08.Text = Nothing

        WK_DtView1 = New DataView(DsCMB.Tables("M08_KBN_CAT"), "ITEM_NAME ='" & Combo08.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            msg.Text = "品種の該当なし"
        Else
            cmb08.Text = WK_DtView1(0)("CAT_CODE")
        End If
    End Sub
    Sub CK_Number1()
        msg.Text = Nothing

        If Number1.Value = 0 Then
            msg.Text = "売上数入力必須"
        End If
    End Sub
    Sub CK_Number7()
        msg.Text = Nothing

        If Number7.Value = 0 Then
            msg.Text = "単価2入力必須"
        End If
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        Edit1.Text = Trim(Edit1.Text)
        If BR_Edit1 <> Edit1.Text Then
            scan()    '**  取込み情報取得
            BR_Edit1 = Edit1.Text
        End If
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Edit02.Text = Trim(Edit02.Text)
        If BR_Edit02 <> Edit02.Text Then
            hinto_scan()
            BR_Edit02 = Edit02.Text
        End If
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Edit03.Text = Trim(Edit03.Text)
        If BR_Edit03 <> Edit03.Text Then
            hinto_scan()
            BR_Edit03 = Edit03.Text
        End If
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Edit04.Text = Trim(Edit04.Text)
        If BR_Edit04 <> Edit04.Text Then
            hinto_scan()
            BR_Edit04 = Edit04.Text
        End If
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Edit05.Text = Trim(Edit05.Text)
        If BR_Edit05 <> Edit05.Text Then
            hinto_scan()
            BR_Edit05 = Edit05.Text
        End If
    End Sub
    Private Sub Edit06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit06.LostFocus
        Edit06.Text = Trim(Edit06.Text)
        If BR_Edit06 <> Edit06.Text Then
            hinto_scan()
            BR_Edit06 = Edit06.Text
        End If
    End Sub
    Private Sub Combo07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo07.LostFocus
        Combo07.Text = Trim(Combo07.Text)
        If BR_Combo07 <> Combo07.Text Then
            CK_Combo07()
            hinto_scan()
            BR_Combo07 = Combo07.Text
        End If
    End Sub
    Private Sub Combo08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo08.LostFocus
        Combo08.Text = Trim(Combo08.Text)
        If BR_Combo08 <> Combo08.Text Then
            CK_Combo08()
            hinto_scan()
            BR_Combo08 = Combo08.Text
        End If
    End Sub
    Private Sub Edit09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit09.LostFocus
        Edit09.Text = Trim(Edit09.Text)
        If BR_Edit09 <> Edit09.Text Then
            hinto_scan()
            BR_Edit09 = Edit09.Text
        End If
    End Sub
    Private Sub Edit10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit10.LostFocus
        Edit10.Text = Trim(Edit10.Text)
        If BR_Edit10 <> Edit10.Text Then
            hinto_scan()
            BR_Edit10 = Edit10.Text
        End If
    End Sub
    Private Sub Edit11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit11.LostFocus
        Edit11.Text = Trim(Edit11.Text)
        If BR_Edit11 <> Edit11.Text Then
            hinto_scan()
            BR_Edit11 = Edit11.Text
        End If
    End Sub
    Private Sub Number1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.LostFocus
        If BR_Number1 <> Number1.Value Then
            hinto_scan()
            BR_Number1 = Number1.Value
        End If
    End Sub
    Private Sub Number2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number2.LostFocus
        If BR_Number2 <> Number2.Value Then
            hinto_scan()
            BR_Number2 = Number2.Value
        End If
    End Sub
    Private Sub Number3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number3.LostFocus
        If BR_Number3 <> Number3.Value Then
            hinto_scan()
            BR_Number3 = Number3.Value
        End If
    End Sub
    Private Sub Number4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number4.LostFocus
        If BR_Number4 <> Number4.Value Then
            hinto_scan()
            BR_Number4 = Number4.Value
        End If
    End Sub
    Private Sub Number5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number5.LostFocus
        If BR_Number5 <> Number5.Value Then
            hinto_scan()
            BR_Number5 = Number5.Value
        End If
    End Sub
    Private Sub Number6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number6.LostFocus
        If BR_Number6 <> Number6.Value Then
            hinto_scan()
            BR_Number6 = Number6.Value
        End If
    End Sub
    Private Sub Number7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number7.LostFocus
        If BR_Number7 <> Number7.Value Then
            hinto_scan()
            BR_Number7 = Number7.Value
        End If
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
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then

                Edit02.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 0))
                Edit03.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 1))
                Edit04.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 2))
                Edit05.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 3))
                Edit06.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 4))

                cmb07.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 5))
                WK_DtView1 = New DataView(DsCMB.Tables("CLS_022"), "CLS_CODE ='" & cmb07.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then Combo07.Text = Nothing Else Combo07.Text = Trim(WK_DtView1(0)("CLS_CODE_NAME"))

                cmb08.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 6))
                WK_DtView1 = New DataView(DsCMB.Tables("M08_KBN_CAT"), "CAT_CODE ='" & cmb08.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then Combo08.Text = Nothing Else Combo08.Text = Trim(WK_DtView1(0)("ITEM_NAME"))

                If Not IsDBNull(DataGrid1(DataGrid1.CurrentRowIndex, 7)) Then
                    Edit09.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 7))
                Else
                    Edit09.Text = Nothing
                End If
                If Not IsDBNull(DataGrid1(DataGrid1.CurrentRowIndex, 8)) Then
                    Edit10.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 8))
                Else
                    Edit10.Text = Nothing
                End If
                If Not IsDBNull(DataGrid1(DataGrid1.CurrentRowIndex, 9)) Then
                    Edit11.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 9))
                Else
                    Edit11.Text = Nothing
                End If

                Number1.Value = DataGrid1(DataGrid1.CurrentRowIndex, 10)
                Number2.Value = DataGrid1(DataGrid1.CurrentRowIndex, 11)
                Number3.Value = DataGrid1(DataGrid1.CurrentRowIndex, 12)
                Number4.Value = DataGrid1(DataGrid1.CurrentRowIndex, 13)
                Number5.Value = DataGrid1(DataGrid1.CurrentRowIndex, 14)
                Number6.Value = DataGrid1(DataGrid1.CurrentRowIndex, 15)
                Number7.Value = DataGrid1(DataGrid1.CurrentRowIndex, 16)


            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  登録
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_chk()
        If Err_F = "0" Then

            strSQL = "INSERT INTO [02_売上データ]"
            strSQL += " (伝票NO, 発行日, 配送店ｺｰﾄﾞ, 一般売掛区分, 氏名, TEL1, TEL2, 郵便番号, 住所1, 住所2"
            strSQL += ", 住所3, 住所4, 住所5, 販売者ｺｰﾄﾞ, 完了日, 削除ﾌﾗｸﾞ, 行番号, 行区分, 商品ｺｰﾄﾞ, 品名ｶﾅ"
            strSQL += ", 型番ｶﾅ, ｶﾗｰ, ｻｲｽﾞ, ﾚｼｰﾄ, 品名漢字, 型番漢字, 分類ｺｰﾄﾞ, 品種ｺｰﾄﾞ, 売上数, ﾏｽﾀ単価, 単価"
            strSQL += ", 税区分, 値引割引区分, 割引率, 値引額, 単価2, 商品ｺｰﾄﾞ_元, 分割数量, 分割元SEQ, 赤黒SEQ"
            strSQL += ", sprice, WSEQ1, WSEQ2, ERR_F, 法人, 集計区分, 処理日, 処理日2, 元SEQ, dlt_f, wrn_add_f)"
            strSQL += " VALUES ('" & Edit1.Text & "'"       '伝票NO
            strSQL += ", N'" & Label003.Text & "'"          '発行日
            strSQL += ", '" & Label004.Text & "'"           '配送店ｺｰﾄﾞ
            strSQL += ", '" & Label005.Text & "'"           '一般売掛区分
            strSQL += ", '" & Label006.Text & "'"           '氏名
            strSQL += ", '" & Label007.Text & "'"           'TEL1
            strSQL += ", '" & Label008.Text & "'"           'TEL2
            strSQL += ", '" & Label009.Text & "'"           '郵便番号
            strSQL += ", '" & Label010.Text & "'"           '住所1
            strSQL += ", '" & Label011.Text & "'"           '住所2
            strSQL += ", '" & Label012.Text & "'"           '住所3
            strSQL += ", '" & Label013.Text & "'"           '住所4
            strSQL += ", '" & Label014.Text & "'"           '住所5
            strSQL += ", '" & Label015.Text & "'"           '販売者ｺｰﾄﾞ
            strSQL += ", N'" & Label016.Text & "'"          '完了日
            strSQL += ", '0'"                               '削除ﾌﾗｸﾞ
            strSQL += ", 0"                                 '行番号
            strSQL += ", '0'"                               '行区分
            strSQL += ", '" & Edit02.Text & "'"             '商品ｺｰﾄﾞ
            strSQL += ", '" & Edit04.Text & "'"             '品名ｶﾅ
            strSQL += ", '" & Edit06.Text & "'"             '型番ｶﾅ
            strSQL += ", '" & Edit09.Text & "'"             'ｶﾗｰ
            strSQL += ", '" & Edit10.Text & "'"             'ｻｲｽﾞ
            strSQL += ", '" & Edit11.Text & "'"             'ﾚｼｰﾄ
            strSQL += ", '" & Edit03.Text & "'"             '品名漢字
            strSQL += ", '" & Edit05.Text & "'"             '型番漢字
            strSQL += ", '" & cmb07.Text & "'"              '分類ｺｰﾄﾞ
            strSQL += ", '" & cmb08.Text & "'"              '品種ｺｰﾄﾞ
            strSQL += ", " & Number1.Value                  '売上数
            strSQL += ", " & Number2.Value                  'ﾏｽﾀ単価
            strSQL += ", " & Number2.Value                  '単価
            strSQL += ", '" & Number3.Value & "'"           '税区分
            strSQL += ", '" & Number4.Value & "'"           '値引割引区分
            strSQL += ", " & Number5.Value                  '割引率
            strSQL += ", " & Number6.Value                  '値引額
            strSQL += ", " & Number7.Value                  '単価2
            strSQL += ", ''"                                '商品ｺｰﾄﾞ_元
            strSQL += ", " & Number1.Value                  '分割数量
            strSQL += ", 0"                                 '分割元SEQ
            strSQL += ", 0"                                 '赤黒SEQ
            strSQL += ", 0"                                 'sprice
            strSQL += ", 0"                                 'WSEQ1
            strSQL += ", 0"                                 'WSEQ2
            strSQL += ", '0'"                               'ERR_F
            strSQL += ", 0"                                 '法人
            strSQL += ", ''"                                '集計区分
            strSQL += ", N'" & Label017.Text & "'"          '処理日
            strSQL += ", N'" & Date1.Text & "'"             '処理日2
            strSQL += ", 0"                                 '元SEQ
            strSQL += ", 0"                                 'dlt_f
            strSQL += ", 0)"                                'wrn_add_f
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN()
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            MsgBox("登録しました")
            clr()

            Edit1.Text = Nothing
            BR_Edit1 = "Null"

        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        DsList2.Clear()
        DsCMB.Clear()
        Close()
    End Sub
End Class
