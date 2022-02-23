Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsCMB As New DataSet
    'Dim DtView1 As DataView
    Dim DtTbl1 As DataTable

    Dim strSQL, Err_F As String
    Dim r As Integer

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
    Friend WithEvents DataGridEx1 As MrMAX_INQUIRY.DataGridEx
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ComboBox12 As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ComboBox11 As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ComboBox10 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button01 As System.Windows.Forms.Button
    Friend WithEvents Button06 As System.Windows.Forms.Button
    Friend WithEvents Date3 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date4 As GrapeCity.Win.Input.Interop.Date
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
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.DataGridEx1 = New MrMAX_INQUIRY.DataGridEx
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
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.ComboBox12 = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.ComboBox11 = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.ComboBox10 = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.ComboBox9 = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ComboBox8 = New System.Windows.Forms.ComboBox
        Me.ComboBox7 = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Button01 = New System.Windows.Forms.Button
        Me.Label104 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.Date2 = New GrapeCity.Win.Input.Interop.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit
        Me.Button06 = New System.Windows.Forms.Button
        Me.Date3 = New GrapeCity.Win.Input.Interop.Date
        Me.Date4 = New GrapeCity.Win.Input.Interop.Date
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(20, 236)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(908, 304)
        Me.DataGridEx1.TabIndex = 15
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn16})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "scan"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "問合せ№"
        Me.DataGridTextBoxColumn1.MappingName = "Q_NO"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 65
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "問合せ日時"
        Me.DataGridTextBoxColumn2.MappingName = "Q_DATE"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 130
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "相手先"
        Me.DataGridTextBoxColumn3.MappingName = "CUST_CLS_name"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 80
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "性別"
        Me.DataGridTextBoxColumn4.MappingName = "SEX_name"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 40
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "年齢層"
        Me.DataGridTextBoxColumn5.MappingName = "AGE_CLS_name"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 60
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "地域"
        Me.DataGridTextBoxColumn6.MappingName = "AREA_CLS_name"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 60
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "商品ｶﾃｺﾞﾘｰ"
        Me.DataGridTextBoxColumn7.MappingName = "CAT_NAME"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 105
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "購入店舗"
        Me.DataGridTextBoxColumn8.MappingName = "SHOP_NAME"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 115
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "購入後 年"
        Me.DataGridTextBoxColumn9.MappingName = "YEAR_CLS_name"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "月"
        Me.DataGridTextBoxColumn10.MappingName = "MONTHS_CLS_name"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 20
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "対応者"
        Me.DataGridTextBoxColumn16.MappingName = "EMPL_NAME"
        Me.DataGridTextBoxColumn16.ReadOnly = True
        Me.DataGridTextBoxColumn16.Width = 90
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Button99.Location = New System.Drawing.Point(828, 192)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(96, 30)
        Me.Button99.TabIndex = 16
        Me.Button99.TabStop = False
        Me.Button99.Text = "閉じる"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(24, 208)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 24)
        Me.Label19.TabIndex = 1050
        Me.Label19.Text = "問合せ内容"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox12
        '
        Me.ComboBox12.Location = New System.Drawing.Point(476, 180)
        Me.ComboBox12.MaxDropDownItems = 12
        Me.ComboBox12.Name = "ComboBox12"
        Me.ComboBox12.Size = New System.Drawing.Size(224, 23)
        Me.ComboBox12.TabIndex = 1035
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(372, 180)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(104, 23)
        Me.Label27.TabIndex = 1049
        Me.Label27.Text = "対応結果２"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(372, 68)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(136, 23)
        Me.Label26.TabIndex = 1048
        Me.Label26.Text = "コール内容"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox11
        '
        Me.ComboBox11.Location = New System.Drawing.Point(476, 152)
        Me.ComboBox11.MaxDropDownItems = 12
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(224, 23)
        Me.ComboBox11.TabIndex = 12
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(372, 152)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 23)
        Me.Label25.TabIndex = 1047
        Me.Label25.Text = "対応結果１"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(500, 40)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 23)
        Me.Label24.TabIndex = 1046
        Me.Label24.Text = "　　　　　 月"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox10
        '
        Me.ComboBox10.Location = New System.Drawing.Point(508, 124)
        Me.ComboBox10.MaxDropDownItems = 12
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(192, 23)
        Me.ComboBox10.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(404, 124)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 23)
        Me.Label22.TabIndex = 1045
        Me.Label22.Text = "意見・要望系"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox9
        '
        Me.ComboBox9.Location = New System.Drawing.Point(508, 96)
        Me.ComboBox9.MaxDropDownItems = 12
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(192, 23)
        Me.ComboBox9.TabIndex = 10
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(404, 96)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 23)
        Me.Label23.TabIndex = 1044
        Me.Label23.Text = "不具合系"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox8
        '
        Me.ComboBox8.Location = New System.Drawing.Point(604, 40)
        Me.ComboBox8.MaxDropDownItems = 12
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(64, 23)
        Me.ComboBox8.TabIndex = 4
        '
        'ComboBox7
        '
        Me.ComboBox7.Location = New System.Drawing.Point(428, 40)
        Me.ComboBox7.MaxDropDownItems = 12
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(64, 23)
        Me.ComboBox7.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(324, 40)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 23)
        Me.Label21.TabIndex = 1043
        Me.Label21.Text = "購入後　年"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox6
        '
        Me.ComboBox6.Location = New System.Drawing.Point(128, 180)
        Me.ComboBox6.MaxDropDownItems = 26
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(240, 23)
        Me.ComboBox6.TabIndex = 9
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(24, 180)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 23)
        Me.Label20.TabIndex = 1042
        Me.Label20.Text = "購入店舗"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(128, 152)
        Me.ComboBox4.MaxDropDownItems = 26
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(240, 23)
        Me.ComboBox4.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(24, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 23)
        Me.Label17.TabIndex = 1041
        Me.Label17.Text = "商品ｶﾃｺﾞﾘｰ"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(128, 124)
        Me.ComboBox3.MaxDropDownItems = 12
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(160, 23)
        Me.ComboBox3.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(24, 124)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 23)
        Me.Label16.TabIndex = 1040
        Me.Label16.Text = "地　域"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(24, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 23)
        Me.Label15.TabIndex = 1039
        Me.Label15.Text = "性　別"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(128, 96)
        Me.ComboBox2.MaxDropDownItems = 12
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(160, 23)
        Me.ComboBox2.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(24, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 1038
        Me.Label7.Text = "年齢層"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(128, 40)
        Me.ComboBox1.MaxDropDownItems = 12
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(160, 23)
        Me.ComboBox1.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(24, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 23)
        Me.Label18.TabIndex = 1037
        Me.Label18.Text = "相手先"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButton4)
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Location = New System.Drawing.Point(136, 64)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(180, 28)
        Me.Panel2.TabIndex = 5
        '
        'RadioButton4
        '
        Me.RadioButton4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.Location = New System.Drawing.Point(128, 0)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(40, 24)
        Me.RadioButton4.TabIndex = 2
        Me.RadioButton4.Text = "女"
        '
        'RadioButton3
        '
        Me.RadioButton3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(72, 0)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(48, 24)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.Text = "男"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(8, 0)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(52, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "両方"
        '
        'Button01
        '
        Me.Button01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button01.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button01.Location = New System.Drawing.Point(828, 36)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(96, 30)
        Me.Button01.TabIndex = 14
        Me.Button01.Text = "検　索"
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.White
        Me.Label104.Location = New System.Drawing.Point(24, 12)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(104, 24)
        Me.Label104.TabIndex = 1051
        Me.Label104.Text = "検索範囲"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/M/d", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyy/M/d", "", "")
        Me.Date1.Location = New System.Drawing.Point(128, 12)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(112, 24)
        Me.Date1.TabIndex = 0
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2010, 9, 10, 16, 36, 0, 0))
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/M/d", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyy/M/d", "", "")
        Me.Date2.Location = New System.Drawing.Point(280, 12)
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(112, 24)
        Me.Date2.TabIndex = 1
        Me.Date2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date2.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2010, 9, 10, 16, 36, 0, 0))
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(244, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 24)
        Me.Label1.TabIndex = 1053
        Me.Label1.Text = "～"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit2
        '
        Me.Edit2.HighlightText = True
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit2.Location = New System.Drawing.Point(128, 208)
        Me.Edit2.MaxLength = 1000
        Me.Edit2.Multiline = True
        Me.Edit2.Name = "Edit2"
        Me.Edit2.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(572, 24)
        Me.Edit2.TabIndex = 13
        Me.Edit2.Text = "Edit2"
        '
        'Button06
        '
        Me.Button06.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button06.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button06.Location = New System.Drawing.Point(828, 112)
        Me.Button06.Name = "Button06"
        Me.Button06.Size = New System.Drawing.Size(96, 30)
        Me.Button06.TabIndex = 1054
        Me.Button06.Text = "クリア"
        '
        'Date3
        '
        Me.Date3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Date3.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/M/d", "", "")
        Me.Date3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date3.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date3.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyy/M/d", "", "")
        Me.Date3.Location = New System.Drawing.Point(404, 12)
        Me.Date3.Name = "Date3"
        Me.Date3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date3.Size = New System.Drawing.Size(112, 24)
        Me.Date3.TabIndex = 1055
        Me.Date3.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date3.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date3.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2010, 9, 10, 16, 36, 0, 0))
        Me.Date3.Visible = False
        '
        'Date4
        '
        Me.Date4.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Date4.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/M/d", "", "")
        Me.Date4.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date4.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date4.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyy/M/d", "", "")
        Me.Date4.Location = New System.Drawing.Point(520, 12)
        Me.Date4.Name = "Date4"
        Me.Date4.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date4.Size = New System.Drawing.Size(112, 24)
        Me.Date4.TabIndex = 1056
        Me.Date4.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date4.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date4.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2010, 9, 10, 16, 36, 0, 0))
        Me.Date4.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(816, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1094
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(938, 547)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date4)
        Me.Controls.Add(Me.Date3)
        Me.Controls.Add(Me.Button06)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.ComboBox12)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.ComboBox11)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.ComboBox10)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ComboBox9)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.ComboBox8)
        Me.Controls.Add(Me.ComboBox7)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button01)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "その他問合せ検索"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*************************************************
    '** 起動時
    '*************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DB_INIT()

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Call CmbSet()   '** コンボセット
        F_clr()         '** クリア

    End Sub

    '*************************************************
    '** コンボセット
    '*************************************************
    Sub CmbSet()
        DB_OPEN()
        DsCMB.Clear()

        '相手先属性
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '003' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CUST_CLS")
        ComboBox1.DataSource = DsCMB.Tables("CUST_CLS")
        ComboBox1.DisplayMember = "NAME"
        ComboBox1.ValueMember = "CLS_CODE"
        ComboBox1.Text = Nothing

        '年齢層
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '014' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "AGE_CLS")
        ComboBox2.DataSource = DsCMB.Tables("AGE_CLS")
        ComboBox2.DisplayMember = "NAME"
        ComboBox2.ValueMember = "CLS_CODE"
        ComboBox2.Text = Nothing

        '地域
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '015' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "AREA_CLS")
        ComboBox3.DataSource = DsCMB.Tables("AREA_CLS")
        ComboBox3.DisplayMember = "NAME"
        ComboBox3.ValueMember = "CLS_CODE"
        ComboBox3.Text = Nothing

        '部門
        strSQL = "SELECT CAT_CODE, CAT_CODE + ' : ' + RTRIM(CAT_NAME) AS CAT_NAME"
        strSQL = strSQL & " FROM M_category"
        strSQL = strSQL & " ORDER BY CAT_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M_category")
        ComboBox4.DataSource = DsCMB.Tables("M_category")
        ComboBox4.DisplayMember = "CAT_NAME"
        ComboBox4.ValueMember = "CAT_CODE"
        ComboBox4.Text = Nothing

        '受付店舗
        strSQL = "SELECT SHOP_CODE, SHOP_CODE + ' : ' + SHOP_NAME AS SHOP_NAME"
        strSQL = strSQL & " FROM SHOP"
        strSQL = strSQL & " WHERE delt_flg = 0"
        strSQL = strSQL & " ORDER BY SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "SHOP")
        ComboBox6.DataSource = DsCMB.Tables("SHOP")
        ComboBox6.DisplayMember = "SHOP_NAME"
        ComboBox6.ValueMember = "SHOP_CODE"
        ComboBox6.Text = Nothing

        '年
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '016' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "YEAR_CLS")
        ComboBox7.DataSource = DsCMB.Tables("YEAR_CLS")
        ComboBox7.DisplayMember = "NAME"
        ComboBox7.ValueMember = "CLS_CODE"
        ComboBox7.Text = Nothing

        '月
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '017' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "MONTHS_CLS")
        ComboBox8.DataSource = DsCMB.Tables("MONTHS_CLS")
        ComboBox8.DisplayMember = "NAME"
        ComboBox8.ValueMember = "CLS_CODE"
        ComboBox8.Text = Nothing

        '不具合
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '018' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CALL1_CLS")
        ComboBox9.DataSource = DsCMB.Tables("CALL1_CLS")
        ComboBox9.DisplayMember = "NAME"
        ComboBox9.ValueMember = "CLS_CODE"
        ComboBox9.Text = Nothing

        '意見
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '019' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CALL2_CLS")
        ComboBox10.DataSource = DsCMB.Tables("CALL2_CLS")
        ComboBox10.DisplayMember = "NAME"
        ComboBox10.ValueMember = "CLS_CODE"
        ComboBox10.Text = Nothing

        '結果１
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '020' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "RPLY_CLS1")
        ComboBox11.DataSource = DsCMB.Tables("RPLY_CLS1")
        ComboBox11.DisplayMember = "NAME"
        ComboBox11.ValueMember = "CLS_CODE"
        ComboBox11.Text = Nothing

        '結果２
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '021' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "RPLY_CLS2")
        ComboBox12.DataSource = DsCMB.Tables("RPLY_CLS2")
        ComboBox12.DisplayMember = "NAME"
        ComboBox12.ValueMember = "CLS_CODE"
        ComboBox12.Text = Nothing

        DB_CLOSE()
    End Sub

    '*********************************************************
    '** クリア
    '*********************************************************
    Sub F_clr()
        Date1.Text = Nothing : Date2.Text = Nothing
        Date3.Text = "2000/01/01" : Date4.Text = "2099/12/31"

        ComboBox1.Text = Nothing : ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing : ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing : ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing : ComboBox4.Text = Nothing
        ComboBox6.Text = Nothing : ComboBox6.Text = Nothing
        ComboBox7.Text = Nothing : ComboBox7.Text = Nothing
        ComboBox8.Text = Nothing : ComboBox8.Text = Nothing
        ComboBox9.Text = Nothing : ComboBox9.Text = Nothing
        ComboBox10.Text = Nothing : ComboBox10.Text = Nothing
        ComboBox11.Text = Nothing : ComboBox11.Text = Nothing
        ComboBox12.Text = Nothing : ComboBox12.Text = Nothing
        Edit2.Text = Nothing
        RadioButton1.Checked = True
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
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                Me.Cursor.Current = Cursors.WaitCursor
                P_Q_NO = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)

                Dim Form2 As New Form2
                Form2.ShowDialog()

                Me.Cursor.Current = Cursors.Default
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '*********************************************************
    '** LostFocus
    '*********************************************************
    Private Sub Date1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.LostFocus
        If Date1.Number = 0 Then
            Date3.Text = "2000/01/01"
        Else
            Date3.Text = Date1.Text
        End If
    End Sub
    Private Sub Date2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.LostFocus
        If Date2.Number = 0 Then
            Date4.Text = "2099/12/31"
        Else
            Date4.Text = Date2.Text
        End If
    End Sub

    '*********************************************************
    '** クリア
    '*********************************************************
    Private Sub Button06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button06.Click
        F_clr()     '** クリア
    End Sub

    '*********************************************************
    '** 検索
    '*********************************************************
    Private Sub Button01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button01.Click
        Me.Cursor.Current = Cursors.WaitCursor

        P_DsList1.Clear()
        strSQL = "SELECT INQUIRY_DATA.Q_NO, INQUIRY_DATA.Q_DATE, INQUIRY_DATA.CUST_CLS, V_cls_003.CLS_CODE_NAME AS CUST_CLS_name"
        strSQL = strSQL & ", INQUIRY_DATA.SEX, V_cls_006.CLS_CODE_NAME AS SEX_name, INQUIRY_DATA.AGE_CLS"
        strSQL = strSQL & ", V_cls_014.CLS_CODE_NAME AS AGE_CLS_name, INQUIRY_DATA.AREA_CLS"
        strSQL = strSQL & ", V_cls_015.CLS_CODE_NAME AS AREA_CLS_name, INQUIRY_DATA.CAT_CODE, M_category.CAT_NAME"
        strSQL = strSQL & ", INQUIRY_DATA.SHOP_CODE, SHOP.SHOP_NAME, INQUIRY_DATA.YEAR_CLS"
        strSQL = strSQL & ", V_cls_016.CLS_CODE_NAME AS YEAR_CLS_name, INQUIRY_DATA.MONTHS_CLS"
        strSQL = strSQL & ", V_cls_017.CLS_CODE_NAME AS MONTHS_CLS_name, INQUIRY_DATA.CALL1_CLS"
        strSQL = strSQL & ", V_cls_018.CLS_CODE_NAME AS CALL1_CLS_name, INQUIRY_DATA.CALL2_CLS"
        strSQL = strSQL & ", V_cls_019.CLS_CODE_NAME AS CALL2_CLS_name, INQUIRY_DATA.RPLY_CLS1"
        strSQL = strSQL & ", V_cls_020.CLS_CODE_NAME AS RPLY_CLS1_name, INQUIRY_DATA.RPLY_CLS2"
        strSQL = strSQL & ", V_cls_021.CLS_CODE_NAME AS RPLY_CLS2_name, INQUIRY_DATA.EMPL_CODE"
        strSQL = strSQL & ", EMPL.EMPL_NAME, INQUIRY_DATA.ASKING"
        strSQL = strSQL & " FROM INQUIRY_DATA LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_003 ON"
        strSQL = strSQL & " INQUIRY_DATA.CUST_CLS = V_cls_003.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " EMPL ON"
        strSQL = strSQL & " INQUIRY_DATA.EMPL_CODE = EMPL.EMPL_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_021 ON"
        strSQL = strSQL & " INQUIRY_DATA.RPLY_CLS2 = V_cls_021.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_020 ON"
        strSQL = strSQL & " INQUIRY_DATA.RPLY_CLS1 = V_cls_020.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_019 ON"
        strSQL = strSQL & " INQUIRY_DATA.CALL2_CLS = V_cls_019.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_018 ON"
        strSQL = strSQL & " INQUIRY_DATA.CALL1_CLS = V_cls_018.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_017 ON"
        strSQL = strSQL & " INQUIRY_DATA.MONTHS_CLS = V_cls_017.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_016 ON"
        strSQL = strSQL & " INQUIRY_DATA.YEAR_CLS = V_cls_016.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " SHOP ON"
        strSQL = strSQL & " INQUIRY_DATA.SHOP_CODE = SHOP.SHOP_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " M_category ON"
        strSQL = strSQL & " INQUIRY_DATA.CAT_CODE = M_category.CAT_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_015 ON"
        strSQL = strSQL & " INQUIRY_DATA.AREA_CLS = V_cls_015.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_014 ON"
        strSQL = strSQL & " INQUIRY_DATA.AGE_CLS = V_cls_014.CLS_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " V_cls_006 ON INQUIRY_DATA.SEX = V_cls_006.CLS_CODE"
        strSQL = strSQL & " WHERE (INQUIRY_DATA.Q_DATE >= CONVERT(DATETIME, '" & Date3.Text & "', 102)"
        strSQL = strSQL & " AND INQUIRY_DATA.Q_DATE <= CONVERT(DATETIME, '" & Date4.Text & "', 102))"
        If Trim(ComboBox1.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.CUST_CLS = '" & ComboBox1.SelectedValue & "')"
        If RadioButton3.Checked = True Then strSQL = strSQL & " AND (INQUIRY_DATA.SEX = '1')"
        If RadioButton4.Checked = True Then strSQL = strSQL & " AND (INQUIRY_DATA.SEX = '2')"
        If Trim(ComboBox2.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.AGE_CLS = '" & ComboBox2.SelectedValue & "')"
        If Trim(ComboBox3.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.AREA_CLS = '" & ComboBox3.SelectedValue & "')"
        If Trim(ComboBox4.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.CAT_CODE = '" & ComboBox4.SelectedValue & "')"
        If Trim(ComboBox6.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.SHOP_CODE = '" & ComboBox6.SelectedValue & "')"
        If Trim(ComboBox7.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.YEAR_CLS = '" & ComboBox7.SelectedValue & "')"
        If Trim(ComboBox8.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.MONTHS_CLS = '" & ComboBox8.SelectedValue & "')"
        If Trim(ComboBox9.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.CALL1_CLS = '" & ComboBox9.SelectedValue & "')"
        If Trim(ComboBox10.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.CALL2_CLS = '" & ComboBox10.SelectedValue & "')"
        If Trim(ComboBox11.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.RPLY_CLS1 = '" & ComboBox11.SelectedValue & "')"
        If Trim(ComboBox12.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.RPLY_CLS2 = '" & ComboBox12.SelectedValue & "')"
        If Trim(Edit2.Text) <> Nothing Then strSQL = strSQL & " AND (INQUIRY_DATA.ASKING LIKE N'%" & Edit2.Text & "%')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(P_DsList1, "scan")
        DB_CLOSE()

        Label2.Text = r & " 件"

        DtTbl1 = P_DsList1.Tables("scan")
        DataGridEx1.DataSource = DtTbl1

        Me.Cursor.Current = Cursors.Default
    End Sub

    '*********************************************************
    '** 閉じる
    '*********************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub
End Class
