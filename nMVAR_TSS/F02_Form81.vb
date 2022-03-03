Public Class F02_Form81
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, ANS As String
    Dim i, j As Integer

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
    Friend WithEvents DataGridEx1 As nMVAR_TSS.DataGridEx
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
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
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn22 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn23 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn24 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn25 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn26 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn27 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn28 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn29 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents f04 As System.Windows.Forms.Button
    ' Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.Interop.FunctionKey
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F02_Form81))
        Me.DataGridEx1 = New nMVAR_TSS.DataGridEx
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
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn22 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn23 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn24 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn25 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn26 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn27 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn28 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn29 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.msg = New System.Windows.Forms.Label
        Me.f04 = New System.Windows.Forms.Button
        Me.f12 = New System.Windows.Forms.Button
        'Me.FunctionKey1 = New GrapeCity.Win.Input.Interop.FunctionKey
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 48)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(988, 604)
        Me.DataGridEx1.TabIndex = 0
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridBoolColumn1, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27, Me.DataGridTextBoxColumn28, Me.DataGridTextBoxColumn29})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "TSS_REP_INF"
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "削除"
        Me.DataGridBoolColumn1.MappingName = "delt_flg"
        Me.DataGridBoolColumn1.NullValue = CType(resources.GetObject("DataGridBoolColumn1.NullValue"), Object)
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 40
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "id"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "区分"
        Me.DataGridTextBoxColumn2.MappingName = "cls_name"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 40
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "ｶﾙﾃ番号"
        Me.DataGridTextBoxColumn3.MappingName = "cust_repr_no"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 95
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = "yyyy/MM/dd"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "受付日"
        Me.DataGridTextBoxColumn4.MappingName = "accp_date"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "店舗ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn5.MappingName = "cust_code"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 60
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "受付店舗名"
        Me.DataGridTextBoxColumn6.MappingName = "cust_name"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 110
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "追加案件"
        Me.DataGridTextBoxColumn7.MappingName = "add_item"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "顧客申告内容"
        Me.DataGridTextBoxColumn8.MappingName = "cust_rept"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 110
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "商品名"
        Me.DataGridTextBoxColumn9.MappingName = "model_name"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "ﾒｰｶｰ名"
        Me.DataGridTextBoxColumn10.MappingName = "vndr_name"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "部門名"
        Me.DataGridTextBoxColumn11.MappingName = "cat_name"
        Me.DataGridTextBoxColumn11.NullText = ""
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "製造番号"
        Me.DataGridTextBoxColumn12.MappingName = "body_no"
        Me.DataGridTextBoxColumn12.NullText = ""
        Me.DataGridTextBoxColumn12.ReadOnly = True
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "購入日"
        Me.DataGridTextBoxColumn13.MappingName = "prch_date"
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.ReadOnly = True
        Me.DataGridTextBoxColumn13.Width = 80
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "見積限度額"
        Me.DataGridTextBoxColumn14.MappingName = "limt_amnt"
        Me.DataGridTextBoxColumn14.NullText = ""
        Me.DataGridTextBoxColumn14.ReadOnly = True
        Me.DataGridTextBoxColumn14.Width = 75
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "保証情報"
        Me.DataGridTextBoxColumn15.MappingName = "wrn_inf"
        Me.DataGridTextBoxColumn15.NullText = ""
        Me.DataGridTextBoxColumn15.ReadOnly = True
        Me.DataGridTextBoxColumn15.Width = 75
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "付属品"
        Me.DataGridTextBoxColumn16.MappingName = "atch_item"
        Me.DataGridTextBoxColumn16.NullText = ""
        Me.DataGridTextBoxColumn16.ReadOnly = True
        Me.DataGridTextBoxColumn16.Width = 110
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "顧客名_姓"
        Me.DataGridTextBoxColumn17.MappingName = "user_l_name"
        Me.DataGridTextBoxColumn17.NullText = ""
        Me.DataGridTextBoxColumn17.ReadOnly = True
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "顧客名_名"
        Me.DataGridTextBoxColumn18.MappingName = "user_f_name"
        Me.DataGridTextBoxColumn18.NullText = ""
        Me.DataGridTextBoxColumn18.ReadOnly = True
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "顧客名_姓ｶﾅ"
        Me.DataGridTextBoxColumn19.MappingName = "user_l_name_kana"
        Me.DataGridTextBoxColumn19.NullText = ""
        Me.DataGridTextBoxColumn19.ReadOnly = True
        Me.DataGridTextBoxColumn19.Width = 75
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "顧客名_名ｶﾅ"
        Me.DataGridTextBoxColumn20.MappingName = "user_f_name_kana"
        Me.DataGridTextBoxColumn20.NullText = ""
        Me.DataGridTextBoxColumn20.ReadOnly = True
        Me.DataGridTextBoxColumn20.Width = 75
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "連絡先電話番号"
        Me.DataGridTextBoxColumn21.MappingName = "tel1"
        Me.DataGridTextBoxColumn21.NullText = ""
        Me.DataGridTextBoxColumn21.ReadOnly = True
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn22.MappingName = "tel2"
        Me.DataGridTextBoxColumn22.NullText = ""
        Me.DataGridTextBoxColumn22.ReadOnly = True
        Me.DataGridTextBoxColumn22.Width = 75
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.HeaderText = "携帯番号"
        Me.DataGridTextBoxColumn23.MappingName = "tel3"
        Me.DataGridTextBoxColumn23.NullText = ""
        Me.DataGridTextBoxColumn23.ReadOnly = True
        Me.DataGridTextBoxColumn23.Width = 75
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.HeaderText = "郵便番号"
        Me.DataGridTextBoxColumn24.MappingName = "zip_code"
        Me.DataGridTextBoxColumn24.NullText = ""
        Me.DataGridTextBoxColumn24.ReadOnly = True
        Me.DataGridTextBoxColumn24.Width = 75
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Format = ""
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.HeaderText = "都道府県"
        Me.DataGridTextBoxColumn25.MappingName = "pref_name"
        Me.DataGridTextBoxColumn25.NullText = ""
        Me.DataGridTextBoxColumn25.ReadOnly = True
        Me.DataGridTextBoxColumn25.Width = 75
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Format = ""
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.HeaderText = "市区町村"
        Me.DataGridTextBoxColumn26.MappingName = "city_name"
        Me.DataGridTextBoxColumn26.NullText = ""
        Me.DataGridTextBoxColumn26.ReadOnly = True
        Me.DataGridTextBoxColumn26.Width = 75
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.HeaderText = "町名番地"
        Me.DataGridTextBoxColumn27.MappingName = "town_name"
        Me.DataGridTextBoxColumn27.NullText = ""
        Me.DataGridTextBoxColumn27.ReadOnly = True
        Me.DataGridTextBoxColumn27.Width = 75
        '
        'DataGridTextBoxColumn28
        '
        Me.DataGridTextBoxColumn28.Format = ""
        Me.DataGridTextBoxColumn28.FormatInfo = Nothing
        Me.DataGridTextBoxColumn28.HeaderText = "ﾋﾞﾙ号名"
        Me.DataGridTextBoxColumn28.MappingName = "buil_name"
        Me.DataGridTextBoxColumn28.NullText = ""
        Me.DataGridTextBoxColumn28.ReadOnly = True
        Me.DataGridTextBoxColumn28.Width = 75
        '
        'DataGridTextBoxColumn29
        '
        Me.DataGridTextBoxColumn29.Format = ""
        Me.DataGridTextBoxColumn29.FormatInfo = Nothing
        Me.DataGridTextBoxColumn29.HeaderText = "備考"
        Me.DataGridTextBoxColumn29.MappingName = "remarks"
        Me.DataGridTextBoxColumn29.NullText = ""
        Me.DataGridTextBoxColumn29.ReadOnly = True
        Me.DataGridTextBoxColumn29.Width = 75
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(8, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1150
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(36, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1149
        Me.CheckBox1.Visible = False
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(24, 660)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(892, 24)
        Me.msg.TabIndex = 1154
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'f04
        '
        Me.f04.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f04.Location = New System.Drawing.Point(784, 8)
        Me.f04.Name = "f04"
        Me.f04.Size = New System.Drawing.Size(96, 32)
        Me.f04.TabIndex = 1152
        Me.f04.Text = "f04:削除"
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(896, 8)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 1153
        Me.f12.Text = "F12:閉じる"
        '
        'FunctionKey1
        '
        'Me.FunctionKey1.ActiveKeySet = "Default"
        'Me.FunctionKey1.Location = New System.Drawing.Point(0, 688)
        'Me.FunctionKey1.Name = "FunctionKey1"
        'Me.FunctionKey1.Size = New System.Drawing.Size(1002, 0)
        'Me.FunctionKey1.TabIndex = 1155
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(304, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 1156
        Me.Label1.Text = "取込みデータ削除"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F02_Form81
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Label1)
        'Me.Controls.Add(Me.FunctionKey1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.f04)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F02_Form81"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "取込みデータ削除"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F02_Form81_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        DsList1.Clear()

        strSQL = "SELECT TSS_REP_INF.*, V_cls_039.cls_code_name AS cls_name"
        strSQL = strSQL & " FROM TSS_REP_INF LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_039 ON TSS_REP_INF.cls = V_cls_039.cls_code"
        strSQL = strSQL & " WHERE (TSS_REP_INF.rcpt_no IS NULL) AND (TSS_REP_INF.delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "TSS_REP_INF")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("TSS_REP_INF"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                DtView1(i)("delt_flg") = "True"
            Next
        End If

        Dim tbl As New DataTable
        tbl = DsList1.Tables("TSS_REP_INF")
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

        DtView1 = New DataView(DsList1.Tables("TSS_REP_INF"), "", "", DataViewRowState.CurrentRows)
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGridEx1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        If DataGridEx1.CurrentRowIndex >= 0 Then
            DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　スペース
    '********************************************************************
    Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                Case Is = Keys.Space
                    msg.Text = Nothing
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
    Private Sub DataGridEx1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))

            If hitinfo.Column = 0 Then  'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
                    msg.Text = Nothing
                    If IsDBNull(DataGridEx1(DataGridEx1.CurrentRowIndex, 0)) Then
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox2.Checked
                    Else
                        If DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = "False" Then
                            DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox1.Checked
                        Else
                            DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox2.Checked
                        End If
                    End If
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  削除
    '********************************************************************
    Private Sub f04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f04.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        WK_DtView1 = New DataView(DsList1.Tables("TSS_REP_INF"), "delt_flg = 'True'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then

            ANS = MessageBox.Show(WK_DtView1.Count & "件のデータを削除します。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            If ANS = "2" Then GoTo end_tab 'いいえ

            For j = 0 To WK_DtView1.Count - 1
                strSQL = "UPDATE TSS_REP_INF SET delt_flg = 1"
                strSQL = strSQL & " WHERE (id = " & WK_DtView1(j)("id") & ")"
                DB_OPEN("nMVAR")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next
            DspSet()    '**  画面セット
            msg.Text = j & "件　削除しました。"

        Else
            msg.Text = "削除設定がありません。"
        End If
end_tab:
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  ファンクションキー
    '********************************************************************
    'Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.Interop.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

    '    e.Handled = True        'ファンクションキーに割り付けられた設定を無効にします。
    '    Select Case e.KeyIndex  'ファンクションキーが押下された場合の処理を行います。
    '        Case 0  'F1
    '        Case 1  'F2
    '        Case 2  'F3
    '        Case 3  'F4
    '            If f04.Enabled = True Then f04.Focus() : f04_Click(sender, e)
    '        Case 4  'F5
    '        Case 5  'F6
    '        Case 6  'F7
    '        Case 7  'F8
    '        Case 8  'F9
    '        Case 9  'F10
    '        Case 10 'F11
    '        Case 11 'F12
    '            f12_Click(sender, e)
    '    End Select
    'End Sub

End Class
