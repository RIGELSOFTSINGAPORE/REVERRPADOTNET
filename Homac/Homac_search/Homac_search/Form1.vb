Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, AND_F, WK_str, WK_str2 As String
    Dim i, r, r2, wrn_fee As Integer

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
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents cnt As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Edit00 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lbl_wrnttl As System.Windows.Forms.Label
    Friend WithEvents lbl_shop As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Edit09 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit08 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_zip As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date_ent As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Edit10 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.cnt = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Edit00 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lbl_wrnttl = New System.Windows.Forms.Label()
        Me.lbl_shop = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Edit09 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit08 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit07 = New GrapeCity.Win.Input.Interop.Edit()
        Me.txt_zip = New GrapeCity.Win.Input.Interop.Mask()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Date_ent = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Button99 = New System.Windows.Forms.Button()
        Me.Edit10 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_zip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "行"
        Me.DataGridTextBoxColumn1.MappingName = "line_no"
        Me.DataGridTextBoxColumn1.Width = 25
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "メーカー"
        Me.DataGridTextBoxColumn2.MappingName = "vdr_name"
        Me.DataGridTextBoxColumn2.Width = 135
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "商品名"
        Me.DataGridTextBoxColumn3.MappingName = "item_name"
        Me.DataGridTextBoxColumn3.Width = 180
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = "##,##0"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "本体価格(税込)"
        Me.DataGridTextBoxColumn4.MappingName = "prch_price"
        Me.DataGridTextBoxColumn4.Width = 105
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "##,##0"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "保証料(税込)"
        Me.DataGridTextBoxColumn5.MappingName = "wrn_fee"
        Me.DataGridTextBoxColumn5.Width = 95
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(13, 227)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(995, 268)
        Me.DataGrid1.TabIndex = 12
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "WRN_SUB"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = "yyyy/MM"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "計上月"
        Me.DataGridTextBoxColumn8.MappingName = "close_date"
        Me.DataGridTextBoxColumn8.Width = 70
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "規格名"
        Me.DataGridTextBoxColumn9.MappingName = "standard_name"
        Me.DataGridTextBoxColumn9.Width = 200
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "保証開始日"
        Me.DataGridTextBoxColumn6.MappingName = "wrn_date"
        Me.DataGridTextBoxColumn6.Width = 95
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "保証期間"
        Me.DataGridTextBoxColumn7.MappingName = "wrn_prod"
        Me.DataGridTextBoxColumn7.Width = 70
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Enabled = False
        Me.Button5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(901, 183)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 32)
        Me.Button5.TabIndex = 20
        Me.Button5.Text = "商品詳細"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'cnt
        '
        Me.cnt.BackColor = System.Drawing.SystemColors.Control
        Me.cnt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cnt.ForeColor = System.Drawing.Color.Black
        Me.cnt.Location = New System.Drawing.Point(904, 503)
        Me.cnt.Name = "cnt"
        Me.cnt.Size = New System.Drawing.Size(104, 28)
        Me.cnt.TabIndex = 10089
        Me.cnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(901, 131)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 32)
        Me.Button4.TabIndex = 19
        Me.Button4.Text = "メモ"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Edit05
        '
        Me.Edit05.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit05.ExitOnLastChar = True
        Me.Edit05.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(413, 83)
        Me.Edit05.MaxLength = 40
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Size = New System.Drawing.Size(192, 25)
        Me.Edit05.TabIndex = 6
        Me.Edit05.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit06
        '
        Me.Edit06.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit06.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit06.Format = "9"
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit06.Location = New System.Drawing.Point(413, 115)
        Me.Edit06.MaxLength = 11
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Size = New System.Drawing.Size(192, 25)
        Me.Edit06.TabIndex = 7
        '
        'Edit04
        '
        Me.Edit04.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit04.ExitOnLastChar = True
        Me.Edit04.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(413, 59)
        Me.Edit04.MaxLength = 40
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Size = New System.Drawing.Size(192, 25)
        Me.Edit04.TabIndex = 5
        Me.Edit04.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(317, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 24)
        Me.Label4.TabIndex = 10093
        Me.Label4.Text = "申込者（カナ）"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(317, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 24)
        Me.Label5.TabIndex = 10092
        Me.Label5.Text = "申込者（漢字）"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkBlue
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(317, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 24)
        Me.Label6.TabIndex = 10091
        Me.Label6.Text = "電話番号"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit02
        '
        Me.Edit02.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit02.ExitOnLastChar = True
        Me.Edit02.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(109, 83)
        Me.Edit02.MaxLength = 40
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Size = New System.Drawing.Size(192, 25)
        Me.Edit02.TabIndex = 3
        Me.Edit02.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(140, 48)
        Me.PictureBox1.TabIndex = 10090
        Me.PictureBox1.TabStop = False
        '
        'Edit00
        '
        Me.Edit00.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit00.ExitOnLastChar = True
        Me.Edit00.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit00.Format = "A9"
        Me.Edit00.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit00.LengthAsByte = True
        Me.Edit00.Location = New System.Drawing.Point(848, 19)
        Me.Edit00.MaxLength = 15
        Me.Edit00.Name = "Edit00"
        Me.Edit00.Size = New System.Drawing.Size(160, 25)
        Me.Edit00.TabIndex = 0
        Me.Edit00.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit00.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(673, 543)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "検 索"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(144, 532)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 32)
        Me.Label1.TabIndex = 10088
        Me.Label1.Text = "店舗名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.DarkBlue
        Me.Label24.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(596, 500)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 24)
        Me.Label24.TabIndex = 10087
        Me.Label24.Text = "保証料合計"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_wrnttl
        '
        Me.lbl_wrnttl.BackColor = System.Drawing.Color.White
        Me.lbl_wrnttl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wrnttl.ForeColor = System.Drawing.Color.Black
        Me.lbl_wrnttl.Location = New System.Drawing.Point(708, 500)
        Me.lbl_wrnttl.Name = "lbl_wrnttl"
        Me.lbl_wrnttl.Size = New System.Drawing.Size(104, 24)
        Me.lbl_wrnttl.TabIndex = 15
        Me.lbl_wrnttl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_shop
        '
        Me.lbl_shop.BackColor = System.Drawing.Color.White
        Me.lbl_shop.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shop.ForeColor = System.Drawing.Color.Black
        Me.lbl_shop.Location = New System.Drawing.Point(216, 532)
        Me.lbl_shop.Name = "lbl_shop"
        Me.lbl_shop.Size = New System.Drawing.Size(248, 32)
        Me.lbl_shop.TabIndex = 14
        Me.lbl_shop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkBlue
        Me.Label22.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(8, 532)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 32)
        Me.Label22.TabIndex = 10086
        Me.Label22.Text = "店コード"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit09
        '
        Me.Edit09.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Edit09.ExitOnLastChar = True
        Me.Edit09.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit09.Format = "9"
        Me.Edit09.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit09.LengthAsByte = True
        Me.Edit09.Location = New System.Drawing.Point(80, 532)
        Me.Edit09.MaxLength = 6
        Me.Edit09.Name = "Edit09"
        Me.Edit09.ReadOnly = True
        Me.Edit09.Size = New System.Drawing.Size(64, 32)
        Me.Edit09.TabIndex = 13
        Me.Edit09.TabStop = False
        Me.Edit09.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit09.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit03
        '
        Me.Edit03.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit03.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit03.Format = "9"
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit03.Location = New System.Drawing.Point(109, 115)
        Me.Edit03.MaxLength = 11
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Size = New System.Drawing.Size(192, 25)
        Me.Edit03.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkBlue
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(13, 147)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 72)
        Me.Label19.TabIndex = 10085
        Me.Label19.Text = "住所"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit01
        '
        Me.Edit01.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit01.ExitOnLastChar = True
        Me.Edit01.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(109, 59)
        Me.Edit01.MaxLength = 40
        Me.Edit01.Name = "Edit01"
        Me.Edit01.Size = New System.Drawing.Size(192, 25)
        Me.Edit01.TabIndex = 2
        Me.Edit01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit08
        '
        Me.Edit08.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Edit08.ExitOnLastChar = True
        Me.Edit08.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit08.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Edit08.LengthAsByte = True
        Me.Edit08.Location = New System.Drawing.Point(109, 195)
        Me.Edit08.MaxLength = 132
        Me.Edit08.Name = "Edit08"
        Me.Edit08.ReadOnly = True
        Me.Edit08.Size = New System.Drawing.Size(747, 25)
        Me.Edit08.TabIndex = 11
        Me.Edit08.TabStop = False
        Me.Edit08.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit08.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit07
        '
        Me.Edit07.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Edit07.ExitOnLastChar = True
        Me.Edit07.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit07.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(109, 171)
        Me.Edit07.MaxLength = 160
        Me.Edit07.Name = "Edit07"
        Me.Edit07.ReadOnly = True
        Me.Edit07.Size = New System.Drawing.Size(747, 25)
        Me.Edit07.TabIndex = 10
        Me.Edit07.TabStop = False
        Me.Edit07.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit07.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_zip
        '
        Me.txt_zip.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_zip.ExitOnLastChar = True
        Me.txt_zip.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_zip.Format = New GrapeCity.Win.Input.Interop.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.txt_zip.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_zip.Location = New System.Drawing.Point(109, 147)
        Me.txt_zip.Name = "txt_zip"
        Me.txt_zip.ReadOnly = True
        Me.txt_zip.Size = New System.Drawing.Size(88, 25)
        Me.txt_zip.TabIndex = 9
        Me.txt_zip.TabStop = False
        Me.txt_zip.Value = ""
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DarkBlue
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(800, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 24)
        Me.Label17.TabIndex = 10084
        Me.Label17.Text = "No."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DarkBlue
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(13, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 24)
        Me.Label16.TabIndex = 10083
        Me.Label16.Text = "使用者（カナ）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkBlue
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(13, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 24)
        Me.Label15.TabIndex = 10082
        Me.Label15.Text = "使用者（漢字）"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(13, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 24)
        Me.Label13.TabIndex = 10081
        Me.Label13.Text = "電話番号"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(793, 543)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "クリア"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(797, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 10080
        Me.Label2.Text = "登録日"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_ent
        '
        Me.Date_ent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Date_ent.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date_ent.DropDownCalendar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.DropDownCalendar.Size = New System.Drawing.Size(291, 205)
        Me.Date_ent.ExitOnLastChar = True
        Me.Date_ent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Date_ent.Location = New System.Drawing.Point(885, 80)
        Me.Date_ent.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        Me.Date_ent.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        Me.Date_ent.Name = "Date_ent"
        Me.Date_ent.ReadOnly = True
        Me.Date_ent.Size = New System.Drawing.Size(120, 25)
        Me.Date_ent.TabIndex = 8
        Me.Date_ent.TabStop = False
        Me.Date_ent.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_ent.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date_ent.Value = Nothing
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(905, 543)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 18
        Me.Button99.Text = "終了"
        '
        'Edit10
        '
        Me.Edit10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit10.ExitOnLastChar = True
        Me.Edit10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit10.Format = "9"
        Me.Edit10.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit10.LengthAsByte = True
        Me.Edit10.Location = New System.Drawing.Point(848, 48)
        Me.Edit10.MaxLength = 9
        Me.Edit10.Name = "Edit10"
        Me.Edit10.Size = New System.Drawing.Size(160, 25)
        Me.Edit10.TabIndex = 1
        Me.Edit10.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit10.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(712, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 24)
        Me.Label3.TabIndex = 10095
        Me.Label3.Text = "表示用伝票番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1018, 579)
        Me.Controls.Add(Me.Edit10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.cnt)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Edit00)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lbl_wrnttl)
        Me.Controls.Add(Me.lbl_shop)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Edit09)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Edit08)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.txt_zip)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date_ent)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac 検索"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_zip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        'Label3.Visible = False 'SM 2021/03/31 commented VJ 2021/04/05
        'Edit10.Visible = False 'SM 2021/03/31 commented VJ 2021/04/05
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Call DB_INIT()

        DsList1.Clear()
        strSQL = "SELECT WRN_SUB.*, '' AS item_name, '' AS standard_name, '' AS vdr_name, '' AS section_name, '' AS line_name, '' AS cls_name, '' AS sub_cls_name FROM WRN_SUB WHERE (wrn_no = '0')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN()
        DaList1.Fill(DsList1, "WRN_SUB")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("WRN_SUB")
        DataGrid1.DataSource = tbl

        Call CLR()      '** クリア

    End Sub

    '******************************************************************
    '** クリア
    '******************************************************************
    Sub CLR()
        Edit00.Text = Nothing
        Edit01.Text = Nothing
        Edit02.Text = Nothing
        Edit03.Text = Nothing
        Edit04.Text = Nothing
        Edit05.Text = Nothing
        Edit06.Text = Nothing
        Edit07.Text = Nothing
        Edit08.Text = Nothing
        Edit09.Text = Nothing
        Edit10.Text = Nothing
        Date_ent.Text = Nothing
        txt_zip.Text = Nothing
        lbl_wrnttl.Text = Nothing
        lbl_shop.Text = Nothing
        cnt.Text = Nothing

        Button4.Enabled = False
        Button4.BackColor = System.Drawing.SystemColors.Control

        DsList1.Clear()
        Edit00.Focus()
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        If Edit00.Text = Nothing _
            And Edit01.Text = Nothing _
            And Edit02.Text = Nothing _
            And Edit03.Text = Nothing _
            And Edit04.Text = Nothing _
            And Edit05.Text = Nothing _
            And Edit06.Text = Nothing _
            And Edit10.Text = Nothing Then
            Edit00.Focus()
            MessageBox.Show("検索条件が入力されていません。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Err_F = "1"
        End If
    End Sub

    '******************************************************************
    '** メモ
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        P_PRAM1 = Edit00.Text

        Dim frmform3 As New Form3
        frmform3.ShowDialog()

        If P_RTN = "1" Then
            Button4.BackColor = System.Drawing.Color.Yellow
        Else
            Button4.BackColor = System.Drawing.SystemColors.Control
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 商品詳細
    '******************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub

    '******************************************************************
    '** 検索
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** 項目チェック
        If Err_F = "0" Then
re:
            P_DsList1.Clear()
            'strSQL = "SELECT WRN_MAIN.*,wrn_sub.close_date, Shop_mtr.shop_name, WRN_MAIN.adrs1 + WRN_MAIN.adrs2 AS adrs1_2, SUBSTRING(WRN_MAIN.wrn_no, 7, 9) AS dsp_wrn_no, SUBSTRING(dbo.WRN_MAIN.wrn_no, 1, 4) + SUBSTRING(dbo.WRN_MAIN.wrn_no, 11, 5) AS dsp_wrn_no_new"
            strSQL = "SELECT WRN_MAIN.wrn_no, WRN_MAIN.user_name_KANA, WRN_MAIN.user_name, WRN_MAIN.user_tel_no, WRN_MAIN.appl_name_KANA, WRN_MAIN.appl_name, WRN_MAIN.appl_tel_no, WRN_MAIN.zip, WRN_MAIN.adrs1, WRN_MAIN.adrs2, WRN_MAIN.adrs3, WRN_MAIN.floor, WRN_MAIN.room_name, WRN_MAIN.livi_togr, WRN_MAIN.shop_code, WRN_MAIN.rcpt_empl_code, WRN_MAIN.rcpt_empl_name, WRN_MAIN.input_date, WRN_MAIN.new_txt, Shop_mtr.shop_name, WRN_MAIN.adrs1 + WRN_MAIN.adrs2 AS adrs1_2, SUBSTRING(WRN_MAIN.wrn_no, 7, 9) AS dsp_wrn_no, SUBSTRING(WRN_MAIN.wrn_no, 1, 4) + SUBSTRING(WRN_MAIN.wrn_no, 11, 5) AS dsp_wrn_no_new, MAX(WRN_SUB.close_date) AS close_date"
            strSQL = strSQL & " FROM WRN_MAIN INNER JOIN"
            strSQL = strSQL & " Shop_mtr ON WRN_MAIN.shop_code = Shop_mtr.shop_code"
            strSQL = strSQL & " INNER JOIN wrn_sub ON WRN_MAIN.wrn_no = wrn_sub.wrn_no"
            strSQL = strSQL & " GROUP BY WRN_MAIN.wrn_no, WRN_MAIN.user_name_KANA, WRN_MAIN.user_name, WRN_MAIN.user_tel_no, WRN_MAIN.appl_name_KANA, WRN_MAIN.appl_name, WRN_MAIN.appl_tel_no, WRN_MAIN.zip, WRN_MAIN.adrs1, WRN_MAIN.adrs2, WRN_MAIN.adrs3, WRN_MAIN.floor, WRN_MAIN.room_name, WRN_MAIN.livi_togr, WRN_MAIN.shop_code, WRN_MAIN.rcpt_empl_code, WRN_MAIN.rcpt_empl_name, WRN_MAIN.input_date, WRN_MAIN.new_txt, Shop_mtr.shop_name, WRN_MAIN.adrs1 + WRN_MAIN.adrs2, SUBSTRING(WRN_MAIN.wrn_no, 7, 9), SUBSTRING(WRN_MAIN.wrn_no, 1, 4) + SUBSTRING(WRN_MAIN.wrn_no, 11, 5)"
            strSQL = strSQL & " HAVING"
            'strSQL = strSQL & " WHERE"
            AND_F = "0"
            If Edit00.Text <> Nothing Then
                If AND_F = "1" Then strSQL = strSQL & " AND"
                AND_F = "1"
                strSQL = strSQL & " (WRN_MAIN.wrn_no LIKE '" & Edit00.Text & "%')"
            End If
            If Edit01.Text <> Nothing Then
                If AND_F = "1" Then strSQL = strSQL & " AND"
                AND_F = "1"
                strSQL = strSQL & " (WRN_MAIN.user_name LIKE '%" & Edit01.Text & "%')"
            End If
            If Edit02.Text <> Nothing Then
                If AND_F = "1" Then strSQL = strSQL & " AND"
                AND_F = "1"
                strSQL = strSQL & " (WRN_MAIN.user_name_KANA LIKE '%" & Edit02.Text & "%')"
            End If
            If Edit03.Text <> Nothing Then
                If AND_F = "1" Then strSQL = strSQL & " AND"
                AND_F = "1"
                strSQL = strSQL & " (WRN_MAIN.user_tel_no LIKE '%" & Edit03.Text & "%')"
            End If
            If Edit04.Text <> Nothing Then
                If AND_F = "1" Then strSQL = strSQL & " AND"
                AND_F = "1"
                strSQL = strSQL & " (WRN_MAIN.appl_name LIKE '%" & Edit04.Text & "%')"
            End If
            If Edit05.Text <> Nothing Then
                If AND_F = "1" Then strSQL = strSQL & " AND"
                AND_F = "1"
                strSQL = strSQL & " (WRN_MAIN.appl_name_KANA LIKE '%" & Edit05.Text & "%')"
            End If
            If Edit06.Text <> Nothing Then
                If AND_F = "1" Then strSQL = strSQL & " AND"
                AND_F = "1"
                strSQL = strSQL & " (WRN_MAIN.appl_tel_no LIKE '%" & Edit06.Text & "%')"
            End If
            If Edit10.Text <> Nothing Then
                If AND_F = "1" Then strSQL = strSQL & " AND"
                AND_F = "1"
                strSQL = strSQL & " ((SUBSTRING(dbo.WRN_MAIN.wrn_no, 7, 9) LIKE '" & Edit10.Text & "%') OR (SUBSTRING(WRN_MAIN.wrn_no, 1, 4) + SUBSTRING(WRN_MAIN.wrn_no, 11, 5) LIKE '" & Edit10.Text & "%'))"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DB_OPEN()
            r = DaList1.Fill(P_DsList1, "scan")
            DB_CLOSE()

            Select Case r
                Case Is = 0
                    Edit00.Focus()
                    MessageBox.Show("対象データがありません。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case Is = 1
                    DtView1 = New DataView(P_DsList1.Tables("scan"), "", "", DataViewRowState.CurrentRows)

                    Date_ent.Text = DtView1(0)("input_date")

                    Edit00.Text = DtView1(0)("wrn_no")
                    Edit01.Text = DtView1(0)("user_name")
                    Edit02.Text = DtView1(0)("user_name_KANA")
                    Edit03.Text = DtView1(0)("user_tel_no")
                    Edit04.Text = DtView1(0)("appl_name")
                    Edit05.Text = DtView1(0)("appl_name_KANA")
                    Edit06.Text = DtView1(0)("appl_tel_no")
                    txt_zip.Value = DtView1(0)("zip")
                    Edit07.Text = DtView1(0)("adrs1_2")
                    Edit08.Text = DtView1(0)("adrs3") & DtView1(0)("room_name") & DtView1(0)("livi_togr")
                    Edit09.Text = DtView1(0)("shop_code")
                    'SM 2021/03/31
                    If (CDate(DtView1(0)("close_date")) >= CDate("03/01/2021")) Then
                        Label3.Visible = False
                        Edit10.Visible = False
                    Else
                        Label3.Visible = True
                        Edit10.Visible = True
                    End If
                    'SM 2021/03/31
                    If DtView1(0)("new_txt") = "1" Then
                        Edit10.Text = DtView1(0)("dsp_wrn_no_new")
                    Else
                        Edit10.Text = DtView1(0)("dsp_wrn_no")
                    End If
                    lbl_shop.Text = DtView1(0)("shop_name")

                    '商品情報
                    DsList1.Clear()
                    strSQL = "SELECT WRN_SUB.wrn_no, WRN_SUB.close_date, WRN_SUB.line_no, WRN_SUB.item_name"
                    strSQL = strSQL & ", WRN_SUB.standard_name, WRN_SUB.prch_price, WRN_SUB.wrn_date, WRN_SUB.wrn_fee"
                    strSQL = strSQL & ", WRN_SUB.wrn_prod, vdr_mtr.vdr_name"
                    strSQL = strSQL & " FROM vdr_mtr RIGHT OUTER JOIN"
                    strSQL = strSQL & " WRN_SUB ON vdr_mtr.vdr_code = WRN_SUB.vdr_code"
                    strSQL = strSQL & " WHERE (WRN_SUB.dlt_f = 0) AND (WRN_SUB.dsp_f = 1)"
                    strSQL = strSQL & " AND (WRN_SUB.wrn_no = '" & DtView1(0)("wrn_no") & "')"
                    strSQL = strSQL & " ORDER BY WRN_SUB.close_date, WRN_SUB.line_no, WRN_SUB.aka_kuro DESC, WRN_SUB.prch_price"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN()
                    DaList1.Fill(DsList1, "WRN_SUB")
                    DB_CLOSE()

                    WK_DtView1 = New DataView(DsList1.Tables("WRN_SUB"), "", "", DataViewRowState.CurrentRows)
                    wrn_fee = 0
                    For i = 0 To WK_DtView1.Count - 1
                        WK_str = Trim(WK_DtView1(i)("item_name"))
                        If Not IsDBNull(WK_DtView1(i)("vdr_name")) Then
                            WK_str2 = Trim(WK_DtView1(i)("vdr_name"))
                            WK_str = Trim(WK_str.Replace(WK_str2, ""))
                        Else
                            WK_str2 = Nothing
                        End If
                        WK_DtView1(i)("item_name") = WK_str
                        wrn_fee = wrn_fee + WK_DtView1(i)("wrn_fee")
                        '** ↓↓ 2021/05/14 追加
                        If IsDBNull(WK_DtView1(i)("vdr_name")) Then
                            WK_DtView1(i)("vdr_name") = ""
                        End If
                        '** ↑↑ 2021/05/14 追加
                    Next
                    lbl_wrnttl.Text = Format(wrn_fee, "##,##0")
                    cnt.Text = WK_DtView1.Count & " 件"

                    strSQL = "SELECT * FROM Memo WHERE (wrn_no = '" & DtView1(0)("wrn_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN()
                    r2 = DaList1.Fill(P_DsList1, "Memo")
                    DB_CLOSE()
                    If r2 <> 0 Then
                        Button4.BackColor = System.Drawing.Color.Yellow
                    Else
                        Button4.BackColor = System.Drawing.SystemColors.Control
                    End If
                    Button4.Enabled = True

                Case Else
                    Cursor = System.Windows.Forms.Cursors.WaitCursor

                    Dim Form2 As New Form2
                    Form2.ShowDialog()

                    If P_RTN = "1" Then
                        Call CLR()      '** クリア
                        Edit00.Text = P_PRAM1
                        GoTo re
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
            End Select
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** クリア
    '******************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call CLR()      '** クリア
        Label3.Visible = True 'VJ 2021/04/01  VJ 2021/04/05
        Edit10.Visible = True 'VJ 2021/04/01  VJ 2021/04/05
    End Sub

    '******************************************************************
    '** 終了
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit00_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit00.LostFocus
        Edit00.Text = Trim(Edit00.Text)
    End Sub
    Private Sub Edit01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.LostFocus
        Edit01.Text = Trim(Edit01.Text)
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Edit02.Text = Trim(Edit02.Text)
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Edit03.Text = Trim(Edit03.Text)
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Edit04.Text = Trim(Edit04.Text)
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Edit05.Text = Trim(Edit05.Text)
    End Sub
    Private Sub Edit06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit06.LostFocus
        Edit06.Text = Trim(Edit06.Text)
    End Sub
End Class
