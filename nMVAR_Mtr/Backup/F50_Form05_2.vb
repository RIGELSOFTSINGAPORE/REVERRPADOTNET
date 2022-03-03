Imports GrapeCity.Win.Input

Public Class F50_Form05_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim WK_DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim i, r, chg_itm As Integer
    Dim M_CLS As String = "M06"
    Dim M_CLS2 As String = "M07"
    Dim WK_str, WK_str2 As String
    Dim WK_int, WK_int2 As Integer

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.Furigana = Me.Edit002.Ime

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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents CheckBox002 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Edit
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Mask
    Friend WithEvents Edit007 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Edit
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Edit008 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Edit009 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Edit010 As GrapeCity.Win.Input.Edit
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button_S5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.msg = New System.Windows.Forms.Label
        Me.CheckBox002 = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Edit003 = New GrapeCity.Win.Input.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Edit002 = New GrapeCity.Win.Input.Edit
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit007 = New GrapeCity.Win.Input.Edit
        Me.Label5 = New System.Windows.Forms.Label
        Me.Edit006 = New GrapeCity.Win.Input.Edit
        Me.Label3 = New System.Windows.Forms.Label
        Me.Edit004 = New GrapeCity.Win.Input.Edit
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGrid1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Edit005 = New GrapeCity.Win.Input.Edit
        Me.Mask1 = New GrapeCity.Win.Input.Mask
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Edit008 = New GrapeCity.Win.Input.Edit
        Me.Label12 = New System.Windows.Forms.Label
        Me.Edit009 = New GrapeCity.Win.Input.Edit
        Me.Label13 = New System.Windows.Forms.Label
        Me.Edit010 = New GrapeCity.Win.Input.Edit
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.Label14 = New System.Windows.Forms.Label
        Me.Button_S5 = New System.Windows.Forms.Button
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 584)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(800, 24)
        Me.msg.TabIndex = 1229
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox002
        '
        Me.CheckBox002.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox002.Location = New System.Drawing.Point(140, 80)
        Me.CheckBox002.Name = "CheckBox002"
        Me.CheckBox002.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox002.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(24, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 24)
        Me.Label2.TabIndex = 1227
        Me.Label2.Text = "自社"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(664, 616)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(68, 32)
        Me.Button80.TabIndex = 20
        Me.Button80.Text = "履歴"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 616)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "更新"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(24, 176)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 24)
        Me.Label9.TabIndex = 1226
        Me.Label9.Text = "カナ"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit003
        '
        Me.Edit003.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.Format = "KA#a"
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(140, 176)
        Me.Edit003.MaxLength = 50
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(360, 24)
        Me.Edit003.TabIndex = 4
        Me.Edit003.Text = "ｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱ"
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(24, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 24)
        Me.Label6.TabIndex = 1225
        Me.Label6.Text = "修理会社名"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(24, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 24)
        Me.Label11.TabIndex = 1224
        Me.Label11.Text = "修理会社ｺｰﾄﾞ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Format = "9"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(140, 40)
        Me.Edit001.MaxLength = 2
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(32, 24)
        Me.Edit001.TabIndex = 0
        Me.Edit001.Text = "00"
        Me.Edit001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit002
        '
        Me.Edit002.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(140, 144)
        Me.Edit002.MaxLength = 50
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(360, 24)
        Me.Edit002.TabIndex = 3
        Me.Edit002.Text = "ああああああああああ"
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(140, 552)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 17
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(716, 8)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1223
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(24, 552)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(116, 24)
        Me.Label52.TabIndex = 1222
        Me.Label52.Text = "削除フラグ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(628, 8)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1221
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(744, 616)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 21
        Me.Button98.Text = "戻る"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(24, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 24)
        Me.Label7.TabIndex = 1236
        Me.Label7.Text = "ＦＡＸ"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit007
        '
        Me.Edit007.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit007.Format = "9#"
        Me.Edit007.HighlightText = True
        Me.Edit007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit007.LengthAsByte = True
        Me.Edit007.Location = New System.Drawing.Point(140, 328)
        Me.Edit007.MaxLength = 14
        Me.Edit007.Name = "Edit007"
        Me.Edit007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit007.Size = New System.Drawing.Size(128, 24)
        Me.Edit007.TabIndex = 10
        Me.Edit007.Text = "03-9999-9999"
        Me.Edit007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(24, 296)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 24)
        Me.Label5.TabIndex = 1235
        Me.Label5.Text = "ＴＥＬ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit006
        '
        Me.Edit006.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.Format = "9#"
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(140, 296)
        Me.Edit006.MaxLength = 14
        Me.Edit006.Name = "Edit006"
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(128, 24)
        Me.Edit006.TabIndex = 9
        Me.Edit006.Text = "03-9999-9999"
        Me.Edit006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(24, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 24)
        Me.Label3.TabIndex = 1234
        Me.Label3.Text = "住所"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit004
        '
        Me.Edit004.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit004.LengthAsByte = True
        Me.Edit004.Location = New System.Drawing.Point(140, 236)
        Me.Edit004.MaxLength = 40
        Me.Edit004.Name = "Edit004"
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(360, 24)
        Me.Edit004.TabIndex = 7
        Me.Edit004.Text = "ああああああああああああああああああああ"
        Me.Edit004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Navy
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(24, 360)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(116, 24)
        Me.Label48.TabIndex = 1238
        Me.Label48.Text = "FAX送信時刻"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(24, 392)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 24)
        Me.Label10.TabIndex = 1240
        Me.Label10.Text = "締日"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(188, 396)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 20)
        Me.Label1.TabIndex = 1241
        Me.Label1.Text = "（月末は99）"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.CaptionText = "修理可能設定"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(508, 40)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(312, 536)
        Me.DataGrid1.TabIndex = 18
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridBoolColumn1, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M07_RPAR_COMP_SCAN"
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.AllowNull = False
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "対象"
        Me.DataGridBoolColumn1.MappingName = "delt_flg"
        Me.DataGridBoolColumn1.NullValue = "False"
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 50
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "メーカー"
        Me.DataGridTextBoxColumn1.MappingName = "name"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 99
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "エリア"
        Me.DataGridTextBoxColumn2.MappingName = "area_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 99
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.MappingName = "rpar_comp_code"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 0
        '
        'Date001
        '
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("HH:mm", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("HH:mm", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Date001.Location = New System.Drawing.Point(140, 360)
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(72, 24)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 11
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date001.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2008, 5, 15, 11, 14, 18, 0))
        '
        'Number001
        '
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("##", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(234, 221)
        Me.Number001.Format = New GrapeCity.Win.Input.NumberFormat("##", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(140, 392)
        Me.Number001.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(40, 24)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 12
        Me.Number001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = Nothing
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(560, 12)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1246
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(588, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1245
        Me.CheckBox1.Visible = False
        '
        'Edit005
        '
        Me.Edit005.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(140, 264)
        Me.Edit005.MaxLength = 40
        Me.Edit005.Name = "Edit005"
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(360, 24)
        Me.Edit005.TabIndex = 8
        Me.Edit005.Text = "住所2"
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Mask1
        '
        Me.Mask1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Mask1.Format = New GrapeCity.Win.Input.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask1.Location = New System.Drawing.Point(140, 208)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(88, 24)
        Me.Mask1.TabIndex = 5
        Me.Mask1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Mask1.Value = ""
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(440, 88)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(60, 24)
        Me.CL001.TabIndex = 1249
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(140, 112)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(360, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 2
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(24, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 24)
        Me.Label4.TabIndex = 1248
        Me.Label4.Text = "会社/部署"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(24, 424)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 24)
        Me.Label8.TabIndex = 1251
        Me.Label8.Text = "Apple修理店番号"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit008
        '
        Me.Edit008.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit008.Format = "9Aa"
        Me.Edit008.HighlightText = True
        Me.Edit008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit008.LengthAsByte = True
        Me.Edit008.Location = New System.Drawing.Point(140, 424)
        Me.Edit008.MaxLength = 8
        Me.Edit008.Name = "Edit008"
        Me.Edit008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit008.Size = New System.Drawing.Size(128, 24)
        Me.Edit008.TabIndex = 13
        Me.Edit008.Text = "039999"
        Me.Edit008.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(24, 456)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 24)
        Me.Label12.TabIndex = 1253
        Me.Label12.Text = "IBM納品先ｺｰﾄﾞ"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit009
        '
        Me.Edit009.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit009.Format = "9"
        Me.Edit009.HighlightText = True
        Me.Edit009.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit009.LengthAsByte = True
        Me.Edit009.Location = New System.Drawing.Point(140, 456)
        Me.Edit009.MaxLength = 5
        Me.Edit009.Name = "Edit009"
        Me.Edit009.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit009.Size = New System.Drawing.Size(128, 24)
        Me.Edit009.TabIndex = 14
        Me.Edit009.Text = "0399"
        Me.Edit009.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(24, 488)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 24)
        Me.Label13.TabIndex = 1255
        Me.Label13.Text = "Hp出荷先ｺｰﾄﾞ"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit010
        '
        Me.Edit010.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit010.Format = "9"
        Me.Edit010.HighlightText = True
        Me.Edit010.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit010.LengthAsByte = True
        Me.Edit010.Location = New System.Drawing.Point(140, 488)
        Me.Edit010.MaxLength = 6
        Me.Edit010.Name = "Edit010"
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(128, 24)
        Me.Edit010.TabIndex = 15
        Me.Edit010.Text = "03999"
        Me.Edit010.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Number002
        '
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,##0", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number002.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number002.Format = New GrapeCity.Win.Input.NumberFormat("#,##0", "", "", "-", "", "", "")
        Me.Number002.HighlightText = True
        Me.Number002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number002.Location = New System.Drawing.Point(140, 520)
        Me.Number002.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number002.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number002.Name = "Number002"
        Me.Number002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number002.Size = New System.Drawing.Size(128, 24)
        Me.Number002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.TabIndex = 16
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = Nothing
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(24, 520)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 24)
        Me.Label14.TabIndex = 1295
        Me.Label14.Text = "表示順"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_S5
        '
        Me.Button_S5.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_S5.Location = New System.Drawing.Point(236, 212)
        Me.Button_S5.Name = "Button_S5"
        Me.Button_S5.Size = New System.Drawing.Size(64, 20)
        Me.Button_S5.TabIndex = 6
        Me.Button_S5.Text = "〒→住所"
        '
        'F50_Form05_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(844, 656)
        Me.Controls.Add(Me.Button_S5)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Edit010)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Edit009)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Edit008)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.Mask1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit007)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Edit006)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.CheckBox002)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form05_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修理会社マスタ"
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form05_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        CmbSet()    '**  コンボボックスセット
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

        P_RTN = "0"
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  権限チェック
    '********************************************************************
    Sub ACES()

        SqlCmd1 = New SqlClient.SqlCommand("sp_ACES_CHK", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram1.Value = P_ACES_brch_code
        Pram2.Value = P_ACES_post_code
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ACES_CHK")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='505'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "2"
                CheckBox001.Enabled = False
                Button1.Enabled = False
            Case Is = "3"
                CheckBox001.Enabled = False
                Button1.Enabled = True
            Case Is = "4"
                CheckBox001.Enabled = True
                Button1.Enabled = True
        End Select
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")

        '部署
        strSQL = "SELECT M03_BRCH.brch_code, M03_BRCH.brch_code + ':' + cls002.cls_code_name_abbr + '/' + M03_BRCH.name AS name"
        strSQL +=  ", M03_BRCH.comp_code, M03_BRCH.name AS name2, M03_BRCH.name_kana, M03_BRCH.zip"
        strSQL +=  ", M03_BRCH.adrs1, M03_BRCH.adrs2, M03_BRCH.tel, M03_BRCH.fax"
        strSQL +=  " FROM M03_BRCH INNER JOIN"
        strSQL +=  " (SELECT cls_code, cls_code_name_abbr FROM M21_CLS_CODE WHERE (cls_no = '002')) cls002 ON"
        strSQL +=  " M03_BRCH.comp_code = cls002.cls_code COLLATE Japanese_CI_AS"
        strSQL +=  " WHERE (M03_BRCH.delt_flg = 0)"
        strSQL +=  " ORDER BY cls002.cls_code_name_abbr, M03_BRCH.name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M03_BRCH")

        Combo001.DataSource = DsCMB.Tables("M03_BRCH")
        Combo001.DisplayMember = "name"
        Combo001.ValueMember = "brch_code"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        If P_PRAM1 = Nothing Then   '新規
            Button1.Text = "登録"
            Button80.Enabled = False
            Edit001.Text = Nothing
            Edit002.Text = Nothing
            Edit003.Text = Nothing
            Mask1.Text = Nothing
            Edit004.Text = Nothing
            Edit005.Text = Nothing
            Edit006.Text = Nothing
            Edit007.Text = Nothing
            Edit008.Text = Nothing
            Edit009.Text = Nothing
            Edit010.Text = Nothing
            Date001.Text = Nothing
            Number001.Value = 0
            Number002.Value = 0
            CheckBox001.Checked = False
            CheckBox002.Checked = False
            Label001.Text = Nothing
            Combo001.Text = Nothing
            Label4.Visible = False : Combo001.Visible = False

        Else                        '修正
            Button1.Text = "更新"
            Button80.Enabled = True
            Edit001.Enabled = False
            DsList1.Clear()

            SqlCmd1 = New SqlClient.SqlCommand("sp_M06_RPAR_COMP_2", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
            Pram1.Value = P_PRAM1
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "M06_RPAR_COMP")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M06_RPAR_COMP"), "", "", DataViewRowState.CurrentRows)

            Edit001.Text = DtView1(0)("rpar_comp_code")
            Edit002.Text = DtView1(0)("name")
            Edit003.Text = DtView1(0)("name_kana")
            If Not IsDBNull(DtView1(0)("zip")) Then Mask1.Value = DtView1(0)("zip") Else Mask1.Text = Nothing
            If Not IsDBNull(DtView1(0)("adrs1")) Then Edit004.Text = DtView1(0)("adrs1") Else Edit004.Text = Nothing
            If Not IsDBNull(DtView1(0)("adrs2")) Then Edit005.Text = DtView1(0)("adrs2") Else Edit005.Text = Nothing
            If Not IsDBNull(DtView1(0)("tel")) Then Edit006.Text = DtView1(0)("tel") Else Edit006.Text = Nothing
            If Not IsDBNull(DtView1(0)("fax")) Then Edit007.Text = DtView1(0)("fax") Else Edit007.Text = Nothing
            If Not IsDBNull(DtView1(0)("apl_rep_shp_code")) Then Edit008.Text = DtView1(0)("apl_rep_shp_code") Else Edit008.Text = Nothing
            If Not IsDBNull(DtView1(0)("ibm_dlvr_code")) Then Edit009.Text = DtView1(0)("ibm_dlvr_code") Else Edit009.Text = Nothing
            If Not IsDBNull(DtView1(0)("hp_ship_code")) Then Edit010.Text = DtView1(0)("hp_ship_code") Else Edit010.Text = Nothing
            If Not IsDBNull(DtView1(0)("fax_snd_time")) Then
                Dim WK As String = DtView1(0)("fax_snd_time")
                If Len(WK) = 10 Then
                    Date001.Text = "00:00"
                Else
                    Date001.Text = Mid(DtView1(0)("fax_snd_time"), 12, 5)
                End If
            Else
                Date001.Text = Nothing
            End If
            Number001.Text = DtView1(0)("cls_date")
            If Not IsDBNull(DtView1(0)("dsp_seq")) Then Number002.Text = DtView1(0)("dsp_seq") Else Number002.Value = 0
            If DtView1(0)("own_flg") = "1" Then
                CheckBox002.Checked = True
                Combo001.Text = DtView1(0)("brch_code") & ":" & DtView1(0)("comp_name") & "/" & DtView1(0)("brch_name")
                Label4.Visible = True : Combo001.Visible = True
            Else
                CheckBox002.Checked = False
                Combo001.Text = Nothing
                Label4.Visible = False : Combo001.Visible = False
            End If
            If DtView1(0)("delt_flg") = "1" Then
                CheckBox001.Checked = True
            Else
                CheckBox001.Checked = False
            End If
            Label001.Text = DtView1(0)("reg_date")
        End If

        '修理会社エリア
        SqlCmd1 = New SqlClient.SqlCommand("sp_M07_RPAR_COMP_SCAN", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        If P_PRAM1 = Nothing Then   '新規
            Pram2.Value = ""
        Else
            Pram2.Value = P_PRAM1
        End If
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M07_RPAR_COMP_SCAN")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M07_RPAR_COMP_SCAN")
        DataGrid1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGrid1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

        DtView2 = New DataView(DsList1.Tables("M07_RPAR_COMP_SCAN"), "", "", DataViewRowState.CurrentRows)
        If DtView2.Count <> 0 Then
            For i = 0 To DtView2.Count - 1
                If IsDBNull(DtView2(i)("rpar_comp_code")) Then
                    DtView2(i)("delt_flg") = "False"
                Else
                    DtView2(i)("delt_flg") = "True"
                End If
            Next
        End If
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
    '**  データグリッド　スペース
    '********************************************************************
    Private Sub DataGrid1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGrid1.CmdKeyEvent
        If DataGrid1.CurrentRowIndex <= DtView2.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                Case Is = Keys.Space
                    If DataGrid1(DataGrid1.CurrentRowIndex, 0) = "False" Then
                        DataGrid1(DataGrid1.CurrentRowIndex, 0) = CheckBox1.Checked
                    Else
                        DataGrid1(DataGrid1.CurrentRowIndex, 0) = CheckBox2.Checked
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
    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))

            If hitinfo.Column = 0 Then  'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                If DataGrid1.CurrentRowIndex <= DtView2.Count - 1 Then
                    If DataGrid1(DataGrid1.CurrentRowIndex, 0) = "False" Then
                        DataGrid1(DataGrid1.CurrentRowIndex, 0) = CheckBox1.Checked
                    Else
                        DataGrid1(DataGrid1.CurrentRowIndex, 0) = CheckBox2.Checked
                    End If
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Edit001()   '修理会社コード
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "修理会社コードが入力されていません。"
            Exit Sub
        Else
            If Len(Edit001.Text) <> 2 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "修理会社コードは2桁で入力してください。"
                Exit Sub
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT rpar_comp_code"
                strSQL +=  " FROM M06_RPAR_COMP"
                strSQL +=  " WHERE (rpar_comp_code = '" & Edit001.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "M06_RPAR_COMP")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("M06_RPAR_COMP"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Edit001.BackColor = System.Drawing.Color.Red
                    msg.Text = "修理会社コードが既に登録されています。"
                    Exit Sub
                End If
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Combo001()   '部署
        msg.Text = Nothing
        If Combo001.Visible = True Then

            Combo001.Text = Trim(Combo001.Text)
            If Combo001.Text = Nothing Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "部署が入力されていません。"
                Exit Sub
            Else
                WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "name ='" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Combo001.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当する部署がありません。"
                    Exit Sub
                Else
                    CL001.Text = WK_DtView1(0)("brch_code")
                    Edit002.Text = WK_DtView1(0)("name2")
                    Edit003.Text = WK_DtView1(0)("name_kana")
                    If Not IsDBNull(WK_DtView1(0)("zip")) Then Mask1.Value = WK_DtView1(0)("zip") Else Mask1.Text = Nothing
                    If Not IsDBNull(WK_DtView1(0)("adrs1")) Then Edit004.Text = WK_DtView1(0)("adrs1") Else Edit004.Text = Nothing
                    If Not IsDBNull(WK_DtView1(0)("adrs2")) Then Edit005.Text = WK_DtView1(0)("adrs2") Else Edit005.Text = Nothing
                    If Not IsDBNull(WK_DtView1(0)("tel")) Then Edit006.Text = WK_DtView1(0)("tel") Else Edit006.Text = Nothing
                    If Not IsDBNull(WK_DtView1(0)("fax")) Then Edit007.Text = WK_DtView1(0)("fax") Else Edit007.Text = Nothing
                End If
            End If
            Combo001.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Sub CHK_Edit002()   '名前
        msg.Text = Nothing

        Edit002.Text = Trim(Edit002.Text)
        If Edit002.Text = Nothing Then
            Edit002.BackColor = System.Drawing.Color.Red
            msg.Text = "名前が入力されていません。"
            Exit Sub
        End If
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit003()   'カナ
        msg.Text = Nothing

        Edit003.Text = Trim(Edit003.Text)
        If Edit003.Text = Nothing Then
            Edit003.BackColor = System.Drawing.Color.Red
            msg.Text = "カナが入力されていません。"
            Exit Sub
        End If
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Mask1()     '郵便番号
        msg.Text = Nothing

        If Mask1.Value = Nothing Then
        Else
            If Len(Mask1.Value) <> 7 Then
                Mask1.BackColor = System.Drawing.Color.Red
                msg.Text = "郵便番号は7桁入力してください。"
                Exit Sub
            End If
        End If
        Mask1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Date001()   'FAX送信時刻
        msg.Text = Nothing

        If Date001.Number = 0 Then
            Date001.BackColor = System.Drawing.Color.Red
            msg.Text = "FAX送信時刻が入力されていません。"
            Exit Sub
        End If
        Date001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Number001() '締日
        msg.Text = Nothing

        If Number001.Value = 0 Then
            Number001.BackColor = System.Drawing.Color.Red
            msg.Text = "締切日が入力されていません。"
            Exit Sub
        End If
        Number001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        If P_PRAM1 = Nothing Then   '新規
            CHK_Edit001() '修理会社コード
            If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub
        End If

        CHK_Combo001() '部署
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Edit002() '名前
        If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub

        CHK_Edit003() 'カナ
        If msg.Text <> Nothing Then Err_F = "1" : Edit003.Focus() : Exit Sub

        CHK_Mask1()     '郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask1.Focus() : Exit Sub

        CHK_Date001() 'FAX送信時刻
        If msg.Text <> Nothing Then Err_F = "1" : Date001.Focus() : Exit Sub

        CHK_Number001() '締日
        If msg.Text <> Nothing Then Err_F = "1" : Number001.Focus() : Exit Sub

    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.GotFocus
        Edit002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.GotFocus
        Edit004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Edit004.SelectionStart = Len(Edit004.Text)
    End Sub
    Private Sub Edit005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.GotFocus
        Edit005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.GotFocus
        Edit006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit007.GotFocus
        Edit007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit008_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit008.GotFocus
        Edit008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit009_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit009.GotFocus
        Edit009.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit010_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit010.GotFocus
        Edit010.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Mask1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.GotFocus
        Mask1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.GotFocus
        Combo001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.GotFocus
        Date001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001.GotFocus
        Number001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.GotFocus
        Number002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.GotFocus
        CheckBox001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.GotFocus
        CheckBox002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '修理会社コード
    End Sub
    Private Sub Edit002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.LostFocus
        CHK_Edit002()   '名前
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        CHK_Edit003()   'カナ
    End Sub
    Private Sub Edit004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.LostFocus
        Edit004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.LostFocus
        Edit005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.LostFocus
        Edit006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit007.LostFocus
        Edit007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit008.LostFocus
        Edit008.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit009_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit009.LostFocus
        Edit009.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit010_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit010.LostFocus
        Edit010.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Mask1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.LostFocus
        CHK_Mask1()     '郵便番号
    End Sub
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001() '部署
    End Sub
    Private Sub Date001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.LostFocus
        CHK_Date001() 'FAX送信時刻
    End Sub
    Private Sub Number001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001.LostFocus
        CHK_Number001() '締日
    End Sub
    Private Sub Number002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.LostFocus
        Number002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        CheckBox001.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.LostFocus
        CheckBox002.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub CheckBox002_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.Click
        If CheckBox002.Checked = True Then
            Label4.Visible = True : Combo001.Visible = True
        Else
            Label4.Visible = False : Combo001.Visible = False
            Combo001.Text = Nothing
        End If
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.ResultStringEventArgs) Handles Furigana.ResultString
        ' 取得したふりがなを表示します。
        Edit003.Text += e.ReadString
    End Sub

    '********************************************************************
    '**  変更履歴
    '********************************************************************
    Sub CHG_HSTY()
        DtView1 = New DataView(DsList1.Tables("M06_RPAR_COMP"), "", "", DataViewRowState.CurrentRows)

        If DtView1(0)("own_flg") = "1" Then
            If CheckBox002.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "自社", "対象", "対象外")
            End If
        Else
            If CheckBox002.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "自社", "対象外", "対象")
            End If
        End If

        Dim a1, a2 As String
        a1 = DtView1(0)("brch_code") & ":" & DtView1(0)("comp_name") & "/" & DtView1(0)("brch_name")

        If Not IsDBNull(DtView1(0)("brch_code")) Then WK_str = DtView1(0)("brch_code") & ":" & DtView1(0)("comp_name") & "/" & DtView1(0)("brch_name") Else WK_str = Nothing

        If Combo001.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "部署", WK_str, Combo001.Text)
        End If

        If Edit002.Text <> DtView1(0)("name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "修理会社名", DtView1(0)("name"), Edit002.Text)
        End If

        If Edit003.Text <> DtView1(0)("name_kana") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "カナ", DtView1(0)("name_kana"), Edit003.Text)
        End If

        If Not IsDBNull(DtView1(0)("zip")) Then WK_str = Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) Else WK_str = Nothing
        If WK_str = "-" Then WK_str = Nothing
        If Mask1.Value <> Nothing Then WK_str2 = Mid(Mask1.Text, 3, 8) Else WK_str2 = Nothing
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "郵便番号", WK_str, WK_str2)
        End If

        If Not IsDBNull(DtView1(0)("adrs1")) Then WK_str = DtView1(0)("adrs1") Else WK_str = Nothing
        If Edit004.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "住所1", WK_str, Edit004.Text)
        End If

        If Not IsDBNull(DtView1(0)("adrs2")) Then WK_str = DtView1(0)("adrs2") Else WK_str = Nothing
        If Edit005.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "住所2", WK_str, Edit005.Text)
        End If

        If Not IsDBNull(DtView1(0)("tel")) Then WK_str = DtView1(0)("tel") Else WK_str = Nothing
        If Edit006.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "ＴＥＬ", WK_str, Edit006.Text)
        End If

        If Not IsDBNull(DtView1(0)("fax")) Then WK_str = DtView1(0)("fax") Else WK_str = Nothing
        If Edit007.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "ＦＡＸ", WK_str, Edit007.Text)
        End If

        If Not IsDBNull(DtView1(0)("fax_snd_time")) Then
            Dim WK As String = DtView1(0)("fax_snd_time")
            If Len(WK) = 10 Then
                WK_str = "00:00"
            Else
                WK_str = Mid(DtView1(0)("fax_snd_time"), 12, 5)
            End If
        Else
            WK_str = "__:__"
        End If
        If Date001.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "FAX送信時刻", WK_str, Date001.Text)
        End If

        If Number001.Value <> DtView1(0)("cls_date") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "締日", DtView1(0)("cls_date"), Number001.Value)
        End If

        If Not IsDBNull(DtView1(0)("apl_rep_shp_code")) Then WK_str = DtView1(0)("apl_rep_shp_code") Else WK_str = Nothing
        If Edit008.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "Apple修理店番号", WK_str, Edit008.Text)
        End If

        If Not IsDBNull(DtView1(0)("ibm_dlvr_code")) Then WK_str = DtView1(0)("ibm_dlvr_code") Else WK_str = Nothing
        If Edit009.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "IBM納品先ｺｰﾄﾞ", WK_str, Edit009.Text)
        End If

        If Not IsDBNull(DtView1(0)("hp_ship_code")) Then WK_str = DtView1(0)("hp_ship_code") Else WK_str = Nothing
        If Edit010.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "Hp出荷先ｺｰﾄﾞ", WK_str, Edit010.Text)
        End If

        If Not IsDBNull(DtView1(0)("dsp_seq")) Then WK_int = DtView1(0)("dsp_seq") Else WK_int = 0
        If Number002.Value <> WK_int Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "表示順", WK_int, Number002.Value)
        End If

        If DtView1(0)("delt_flg") = "1" Then
            If CheckBox001.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "削除フラグ", "削除", "")
            End If
        Else
            If CheckBox001.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "削除フラグ", "", "削除")
            End If
        End If

    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        chg_itm = 0
        P_HSTY_DATE = Now
        F_Check()   '**  項目チェック
        If Err_F = "0" Then
            If P_PRAM1 = Nothing Then   '新規
                Label001.Text = Now.Date

                '修理会社マスタ
                strSQL = "INSERT INTO M06_RPAR_COMP"
                strSQL +=  " (rpar_comp_code, name, name_kana, own_flg, brch_code, zip, adrs1, adrs2, tel, fax, fax_snd_time, cls_date, apl_rep_shp_code, ibm_dlvr_code, hp_ship_code, dsp_seq, reg_date, delt_flg)"
                strSQL +=  " VALUES ('" & Edit001.Text & "'"
                strSQL +=  ", '" & Edit002.Text & "'"
                strSQL +=  ", '" & Edit003.Text & "'"
                If CheckBox002.Checked = True Then
                    strSQL +=  ", 1"
                    strSQL +=  ", '" & CL001.Text & "'"
                Else
                    strSQL +=  ", 0"
                    strSQL +=  ", NULL"
                End If
                strSQL +=  ", '" & Mask1.Value & "'"
                strSQL +=  ", '" & Edit004.Text & "'"
                strSQL +=  ", '" & Edit005.Text & "'"
                strSQL +=  ", '" & Edit006.Text & "'"
                strSQL +=  ", '" & Edit007.Text & "'"
                If Date001.Text <> "__:__" Then strSQL +=  ", '1900/01/01 " & Date001.Text & ":00'" Else strSQL +=  ", NULL"
                strSQL +=  ", " & Number001.Value & ""
                strSQL +=  ", '" & Edit008.Text & "'"
                strSQL +=  ", '" & Edit009.Text & "'"
                strSQL +=  ", '" & Edit010.Text & "'"
                strSQL +=  ", " & Number002.Value & ""
                strSQL +=  ", '" & CDate(Label001.Text) & "'"
                If CheckBox001.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                strSQL += ")"
                DB_OPEN("nMVAR")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                '修理会社エリアマスタ
                WK_DtView1 = New DataView(DsList1.Tables("M07_RPAR_COMP_SCAN"), "delt_flg = 'True'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    For i = 0 To WK_DtView1.Count - 1
                        strSQL = "INSERT INTO M07_RPAR_COMP_SCAN"
                        strSQL += " (rpar_comp_code, vndr_code, area_code, reg_date)"
                        strSQL += " VALUES ('" & Edit001.Text & "'"
                        strSQL += ", '" & WK_DtView1(i)("vndr_code") & "'"
                        strSQL += ", '" & WK_DtView1(i)("area_code") & "'"
                        strSQL += ", '" & CDate(Label001.Text) & "'"
                        strSQL += ")"
                        DB_OPEN("nMVAR")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    Next
                End If

                add_MTR_hsty(M_CLS, Edit001.Text, "新規登録", "", "")
                msg.Text = "登録しました。"
                P_RTN = "1"
                P_PRAM1 = Edit001.Text
                DspSet()    '**  画面セット
            Else                        '修正

                CHG_HSTY()  '**  変更履歴
                If chg_itm <> 0 Then
                    '修理会社マスタ
                    strSQL = "UPDATE M06_RPAR_COMP"
                    strSQL +=  " SET name = '" & Edit002.Text & "'"
                    strSQL +=  ", name_kana = '" & Edit003.Text & "'"
                    If CheckBox002.Checked = True Then
                        strSQL +=  ", own_flg = 1"
                        strSQL +=  ", brch_code = '" & CL001.Text & "'"
                    Else
                        strSQL +=  ", own_flg = 0"
                        strSQL +=  ", brch_code = NULL"
                    End If
                    strSQL +=  ", zip = '" & Mask1.Value & "'"
                    strSQL +=  ", adrs1 = '" & Edit004.Text & "'"
                    strSQL +=  ", adrs2 = '" & Edit005.Text & "'"
                    strSQL +=  ", tel = '" & Edit006.Text & "'"
                    strSQL +=  ", fax = '" & Edit007.Text & "'"
                    If Date001.Text <> "__:__" Then strSQL +=  ", fax_snd_time = '1900/01/01 " & Date001.Text & ":00'" Else strSQL +=  ", fax_snd_time = NULL"
                    strSQL +=  ", cls_date = " & Number001.Value & ""
                    strSQL +=  ", apl_rep_shp_code = '" & Edit008.Text & "'"
                    strSQL +=  ", ibm_dlvr_code = '" & Edit009.Text & "'"
                    strSQL +=  ", hp_ship_code = '" & Edit010.Text & "'"
                    strSQL +=  ", dsp_seq = " & Number002.Value & ""
                    If CheckBox001.Checked = True Then strSQL +=  ", delt_flg = 1" Else strSQL +=  ", delt_flg = 0"
                    strSQL +=  " WHERE (rpar_comp_code = '" & P_PRAM1 & "')"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If

                '修理会社エリアマスタ
                WK_DtView1 = New DataView(DsList1.Tables("M07_RPAR_COMP_SCAN"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    For i = 0 To WK_DtView1.Count - 1
                        If WK_DtView1(i)("delt_flg") = "True" Then    '対象
                            If IsDBNull(WK_DtView1(i)("rpar_comp_code")) Then
                                'ins
                                strSQL = "INSERT INTO M07_RPAR_COMP_SCAN"
                                strSQL +=  " (rpar_comp_code, vndr_code, area_code, reg_date)"
                                strSQL +=  " VALUES ('" & Edit001.Text & "'"
                                strSQL +=  ", '" & WK_DtView1(i)("vndr_code") & "'"
                                strSQL +=  ", '" & WK_DtView1(i)("area_code") & "'"
                                strSQL += ", '" & CDate(Label001.Text) & "'"
                                strSQL += ")"
                                DB_OPEN("nMVAR")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS2, Edit001.Text, "修理会社エリア / " & WK_DtView1(i)("name") & "/" & WK_DtView1(i)("area_name"), "対象外", "対象")
                            End If
                        Else
                            If Not IsDBNull(WK_DtView1(i)("rpar_comp_code")) Then
                                'del
                                strSQL = "DELETE FROM M07_RPAR_COMP_SCAN"
                                strSQL +=  " WHERE (rpar_comp_code = '" & Edit001.Text & "')"
                                strSQL +=  " AND (vndr_code = '" & WK_DtView1(i)("vndr_code") & "')"
                                strSQL +=  " AND (area_code = '" & WK_DtView1(i)("area_code") & "')"
                                DB_OPEN("nMVAR")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS2, Edit001.Text, "修理会社エリア / " & WK_DtView1(i)("name") & "/" & WK_DtView1(i)("area_name"), "対象", "対象外")
                            End If
                        End If
                    Next
                End If

                If chg_itm = 0 Then
                    msg.Text = "変更箇所がありません。"
                Else
                    msg.Text = "更新しました。"
                    DspSet()    '**  画面セット
                End If
                P_RTN = "1"
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  履歴
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '変更履歴
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L02_MTR_HSTY_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 3)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 20)
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 3)
        Pram3.Value = M_CLS
        Pram4.Value = P_PRAM1
        Pram5.Value = M_CLS2
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button_S5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S5.Click
        '郵便番号->住所
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_DsList1.Clear()
        strSQL = "SELECT adrs FROM M15_ZIP"
        strSQL +=  " WHERE (zip = '" & Mask1.Value & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(P_DsList1, "M15_ZIP")
        DB_CLOSE()

        Select Case r
            Case Is = 0
                msg.Text = "該当郵便番号なし"
                Mask1.Focus()
            Case Is = 1
                WK_DtView1 = New DataView(P_DsList1.Tables("M15_ZIP"), "", "", DataViewRowState.CurrentRows)
                Edit004.Text = Trim(WK_DtView1(0)("adrs"))
                Edit004.Focus()
            Case Else
                Dim F00_Form15 As New F00_Form15
                F00_Form15.ShowDialog()

                If P_RTN <> Nothing Then Edit004.Text = P_RTN : Edit004.Focus()
        End Select

        Cursor = System.Windows.Forms.Cursors.Default
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
End Class
