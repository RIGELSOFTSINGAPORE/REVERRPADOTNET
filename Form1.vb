Imports Excel = Microsoft.Office.Interop.Excel
Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DsExport As New DataSet
    Dim DtView1, WK_DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim waitDlg As WaitDialog

    Dim strSQL, Err_F As String
    Dim BR_BY_cls, BR_Shop, BR_GRP, BR_Corp, WK_Shop_Name, WK_bnrui_name As String
    Dim Dtl(8), sum(8), ttl3(9, 8), ttl5(9, 8), Gttl(9, 8), WK_Long As Long '小計,合計計
    Dim ttl10(9, 8) As Long '2015/08/05 家電保10年対応
    Dim ttl_KG(9, 8) As Long '2016/01/12 企業保証対応
    Dim Line As Integer = 1     '行
    Dim r, i, j, k, l As Integer
    Dim WK_GRP, WK_str As String
    Dim WK_int, WK_price As Integer
    Dim sonia_fee As Integer

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents GroupBox0 As System.Windows.Forms.GroupBox
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button52 As System.Windows.Forms.Button
    Friend WithEvents Button51 As System.Windows.Forms.Button
    Friend WithEvents Button53 As System.Windows.Forms.Button
    Friend WithEvents Button43 As System.Windows.Forms.Button
    Friend WithEvents Button33 As System.Windows.Forms.Button
    Friend WithEvents Button32 As System.Windows.Forms.Button
    Friend WithEvents Button31 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button63 As System.Windows.Forms.Button
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button72 As System.Windows.Forms.Button
    Friend WithEvents Button71 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button99 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.GroupBox0 = New System.Windows.Forms.GroupBox()
        Me.Button72 = New System.Windows.Forms.Button()
        Me.Button71 = New System.Windows.Forms.Button()
        Me.Button63 = New System.Windows.Forms.Button()
        Me.Button52 = New System.Windows.Forms.Button()
        Me.Button51 = New System.Windows.Forms.Button()
        Me.Button53 = New System.Windows.Forms.Button()
        Me.Button43 = New System.Windows.Forms.Button()
        Me.Button33 = New System.Windows.Forms.Button()
        Me.Button32 = New System.Windows.Forms.Button()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.Date1 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox0.SuspendLayout()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(808, 544)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 50
        Me.Button99.Text = "終 了"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button12.Location = New System.Drawing.Point(200, 24)
        Me.Button12.Name = "Button12"
        Me.Button12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button12.Size = New System.Drawing.Size(160, 48)
        Me.Button12.TabIndex = 12
        Me.Button12.Text = "延長保証料総括表" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前月解約処理分"
        Me.Button12.UseVisualStyleBackColor = False
        Me.Button12.Enabled = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button11.Location = New System.Drawing.Point(24, 24)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(160, 48)
        Me.Button11.TabIndex = 11
        Me.Button11.Text = "延長保証料総括表(Excel)"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 23)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "処理年月"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "csv"
        Me.SaveFileDialog1.Filter = "CSV形式(*.csv)|*.csv|すべて(*.*)|*.*"
        '
        'Button13
        '
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Enabled = False
        Me.Button13.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button13.Location = New System.Drawing.Point(376, 24)
        Me.Button13.Name = "Button13"
        Me.Button13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button13.Size = New System.Drawing.Size(160, 48)
        Me.Button13.TabIndex = 13
        Me.Button13.Text = "加入者データ"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button24)
        Me.GroupBox2.Controls.Add(Me.Button23)
        Me.GroupBox2.Controls.Add(Me.Button22)
        Me.GroupBox2.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(904, 88)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "法人"
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.SystemColors.Control
        Me.Button24.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button24.Enabled = False
        Me.Button24.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button24.Location = New System.Drawing.Point(552, 24)
        Me.Button24.Name = "Button24"
        Me.Button24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button24.Size = New System.Drawing.Size(160, 48)
        Me.Button24.TabIndex = 24
        Me.Button24.Text = "加入者データ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(外商部)"
        Me.Button24.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.SystemColors.Control
        Me.Button23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button23.Enabled = False
        Me.Button23.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button23.Location = New System.Drawing.Point(376, 24)
        Me.Button23.Name = "Button23"
        Me.Button23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button23.Size = New System.Drawing.Size(160, 48)
        Me.Button23.TabIndex = 23
        Me.Button23.Text = "店舗別明細"
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.SystemColors.Control
        Me.Button22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button22.Enabled = False
        Me.Button22.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button22.Location = New System.Drawing.Point(200, 24)
        Me.Button22.Name = "Button22"
        Me.Button22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button22.Size = New System.Drawing.Size(160, 48)
        Me.Button22.TabIndex = 22
        Me.Button22.Text = "加入者データ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(朝日火災)"
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(464, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 23)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Safety5 Management Center"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button15)
        Me.GroupBox1.Controls.Add(Me.Button14)
        Me.GroupBox1.Controls.Add(Me.Button11)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.Button13)
        Me.GroupBox1.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(904, 144)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "個人"
        '
        'Button15
        '
        Me.Button15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button15.Enabled = False
        Me.Button15.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button15.Location = New System.Drawing.Point(728, 24)
        Me.Button15.Name = "Button15"
        Me.Button15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button15.Size = New System.Drawing.Size(160, 48)
        Me.Button15.TabIndex = 15
        Me.Button15.Text = "加入者データ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(朝日)"
        '
        'Button14
        '
        Me.Button14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button14.Enabled = False
        Me.Button14.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button14.Location = New System.Drawing.Point(552, 24)
        Me.Button14.Name = "Button14"
        Me.Button14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button14.Size = New System.Drawing.Size(160, 48)
        Me.Button14.TabIndex = 14
        Me.Button14.Text = "加入者データ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エース)"
        '
        'GroupBox0
        '
        Me.GroupBox0.Controls.Add(Me.Button72)
        Me.GroupBox0.Controls.Add(Me.Button71)
        Me.GroupBox0.Controls.Add(Me.Button63)
        Me.GroupBox0.Controls.Add(Me.Button52)
        Me.GroupBox0.Controls.Add(Me.Button51)
        Me.GroupBox0.Controls.Add(Me.Button53)
        Me.GroupBox0.Controls.Add(Me.Button43)
        Me.GroupBox0.Controls.Add(Me.Button33)
        Me.GroupBox0.Controls.Add(Me.Button32)
        Me.GroupBox0.Controls.Add(Me.Button31)
        Me.GroupBox0.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox0.Location = New System.Drawing.Point(16, 328)
        Me.GroupBox0.Name = "GroupBox0"
        Me.GroupBox0.Size = New System.Drawing.Size(903, 200)
        Me.GroupBox0.TabIndex = 30
        Me.GroupBox0.TabStop = False
        Me.GroupBox0.Text = "共通"
        '
        'Button72
        '
        Me.Button72.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button72.Enabled = False
        Me.Button72.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button72.Location = New System.Drawing.Point(728, 80)
        Me.Button72.Name = "Button72"
        Me.Button72.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button72.Size = New System.Drawing.Size(160, 48)
        Me.Button72.TabIndex = 45
        Me.Button72.Text = "請求明細　           (無料保証含む)"
        '
        'Button71
        '
        Me.Button71.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button71.Enabled = False
        Me.Button71.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button71.Location = New System.Drawing.Point(728, 24)
        Me.Button71.Name = "Button71"
        Me.Button71.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button71.Size = New System.Drawing.Size(160, 48)
        Me.Button71.TabIndex = 44
        Me.Button71.Text = "加入者データ　     (無料保証含む)"
        '
        'Button63
        '
        Me.Button63.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button63.Enabled = False
        Me.Button63.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button63.Location = New System.Drawing.Point(552, 80)
        Me.Button63.Name = "Button63"
        Me.Button63.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button63.Size = New System.Drawing.Size(160, 48)
        Me.Button63.TabIndex = 41
        Me.Button63.Text = "請求明細(法人)"
        '
        'Button52
        '
        Me.Button52.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button52.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button52.Location = New System.Drawing.Point(376, 80)
        Me.Button52.Name = "Button52"
        Me.Button52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button52.Size = New System.Drawing.Size(160, 48)
        Me.Button52.TabIndex = 38
        Me.Button52.Text = "請求明細" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(カコイエレクトロ)"
        '
        'Button51
        '
        Me.Button51.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button51.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button51.Location = New System.Drawing.Point(376, 24)
        Me.Button51.Name = "Button51"
        Me.Button51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button51.Size = New System.Drawing.Size(160, 48)
        Me.Button51.TabIndex = 37
        Me.Button51.Text = "加入者データ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(カコイエレクトロ)"
        '
        'Button53
        '
        Me.Button53.BackColor = System.Drawing.SystemColors.Control
        Me.Button53.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button53.Enabled = False
        Me.Button53.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button53.Location = New System.Drawing.Point(376, 136)
        Me.Button53.Name = "Button53"
        Me.Button53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button53.Size = New System.Drawing.Size(160, 48)
        Me.Button53.TabIndex = 39
        Me.Button53.Text = "請求ｷｬﾝｾﾙ明細" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(カコイエレクトロ)"
        Me.Button53.UseVisualStyleBackColor = False
        '
        'Button43
        '
        Me.Button43.BackColor = System.Drawing.SystemColors.Control
        Me.Button43.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button43.Enabled = False
        Me.Button43.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button43.Location = New System.Drawing.Point(200, 136)
        Me.Button43.Name = "Button43"
        Me.Button43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button43.Size = New System.Drawing.Size(160, 48)
        Me.Button43.TabIndex = 36
        Me.Button43.Text = "店舗別" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "請求ｷｬﾝｾﾙ明細"
        Me.Button43.UseVisualStyleBackColor = False
        '
        'Button33
        '
        Me.Button33.BackColor = System.Drawing.SystemColors.Control
        Me.Button33.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button33.Enabled = False
        Me.Button33.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button33.Location = New System.Drawing.Point(24, 136)
        Me.Button33.Name = "Button33"
        Me.Button33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button33.Size = New System.Drawing.Size(160, 48)
        Me.Button33.TabIndex = 33
        Me.Button33.Text = "請求ｷｬﾝｾﾙ明細"
        Me.Button33.UseVisualStyleBackColor = False
        '
        'Button32
        '
        Me.Button32.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button32.Enabled = False
        Me.Button32.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button32.Location = New System.Drawing.Point(24, 80)
        Me.Button32.Name = "Button32"
        Me.Button32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button32.Size = New System.Drawing.Size(160, 48)
        Me.Button32.TabIndex = 32
        Me.Button32.Text = "請求明細"
        '
        'Button31
        '
        Me.Button31.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button31.Enabled = False
        Me.Button31.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button31.Location = New System.Drawing.Point(24, 24)
        Me.Button31.Name = "Button31"
        Me.Button31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button31.Size = New System.Drawing.Size(160, 48)
        Me.Button31.TabIndex = 31
        Me.Button31.Text = "加入者データ"
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date1.Font = New System.Drawing.Font("MS PGothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM", "", "")
        Me.Date1.Location = New System.Drawing.Point(120, 16)
        Me.Date1.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2020, 12, 31, 0, 0, 0, 0))
        Me.Date1.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1990, 1, 1, 0, 0, 0, 0))
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(88, 24)
        Me.Date1.TabIndex = 51
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2007, 9, 18, 17, 22, 2, 0))
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(216, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "未締め分"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(296, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "未締めFLG"
        Me.Label4.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(938, 583)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.GroupBox0)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "S5 管理センター"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox0.ResumeLayout(False)
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************************************************
    '** 起動時
    '**********************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DB_INIT()

        DsList1.Clear()
        strSQL = "SELECT * FROM CLS_CODE WHERE (CLS_NO = '999')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3000
        DB_OPEN("best_wrn")
        DaList1.Fill(DsList1, "CLS_CODE")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_CODE='3'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Date1.Text = Format(CDate(Trim(DtView1(0)("CLS_CODE_NAME"))), "yyyy/MM")
            Label3.Text = Format(DateAdd(DateInterval.Month, 1, CDate(Trim(DtView1(0)("CLS_CODE_NAME")))), "yyyy/MM")
        End If
    End Sub

    '**********************************************************************
    '** 入力チェック
    '**********************************************************************
    Sub F_Check()
        Err_F = "0"

        '処理年月
        If Date1.Number = 0 Then
            Err_F = "1" : Beep() : Date1.Focus()
            MessageBox.Show("処理年月を入力してください。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            '未来日付
            If Date1.Text & "/01" > Date.Now Then
                Err_F = "1" : Beep() : Date1.Focus()
                MessageBox.Show("未来日付は入力できません。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Date1.Text < "2010/11" Then
                    Err_F = "1" : Beep() : Date1.Focus()
                    MessageBox.Show("2010/11以前の入力できません。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If Date1.Text = Label3.Text Then
                        Label4.Text = "1"   '未締め分
                    Else
                        Label4.Text = "0"
                    End If
                    P_From_Date = Date1.Text & "/" & "01"
                    P_To_Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, P_From_Date))
                    P_nx_Date = DateAdd(DateInterval.Month, 1, P_From_Date)
                End If
            End If
        End If
    End Sub

    '**********************************************************************
    '** 延長保証料総括表(個人)_Excel出力
    '**********************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_Check()
        If Err_F = "0" Then
            Me.Enabled = False                      ' オーナーのフォームを無効にする

            waitDlg = New WaitDialog                ' 進行状況ダイアログ
            waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = "延長保証料総括表"    ' 処理の概要を表示
            waitDlg.ProgressMsg = "データ抽出中"    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0               ' 最初の件数を設定
            waitDlg.Show()                          ' 進行状況ダイアログを表示する
            Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

            DB_OPEN("best_wrn")
            DsExport.Clear()

            strSQL = "SELECT Wrn_sub.ordr_no, Wrn_sub.line_no, Wrn_sub.seq, Wrn_mtr.shop_code, Wrn_sub.prch_price"
            '2014/05/16 消費税対策 start
            strSQL += ", Wrn_sub.fin_date"  '完了日
            '2014/05/16 消費税対策 end
            strSQL += ", Wrn_sub.prch_tax, Wrn_sub.wrn_fee, Wrn_sub.prch_date, V_Cat_mtr.GRP"
            strSQL += ", Wrn_sub_2.wrn_prod2 AS wrn_prod, Wrn_sub.wrn_prod AS wrn_prod_old, Wrn_mtr.BY_cls, Wrn_sub.corp_flg, Wrn_sub.wrn_item_code"
            strSQL += " FROM Wrn_mtr INNER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no LEFT OUTER JOIN"
            strSQL += " V_Cat_mtr ON Wrn_sub.item_cat_code = V_Cat_mtr.cd12 AND Wrn_sub.BY_cls = V_Cat_mtr.BY_cls LEFT OUTER JOIN"
            strSQL += " Wrn_sub_2 ON Wrn_sub.ordr_no = Wrn_sub_2.ordr_no AND Wrn_sub.line_no = Wrn_sub_2.line_no AND"
            strSQL += " Wrn_sub.seq = Wrn_sub_2.seq"
            strSQL += " WHERE (Wrn_sub.corp_flg = '0' OR Wrn_sub.corp_flg = '2')"
            If Label4.Text = "0" Then
                strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " AND (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
                strSQL += " AND (fin_date < CONVERT(DATETIME, '" & P_nx_Date & "', 102))"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 7200
            r = DaList1.Fill(DsExport, "XLS")

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Activate()
                waitDlg.Close()
                Me.Enabled = True
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
            DtView1 = New DataView(DsExport.Tables("XLS"), "", "", DataViewRowState.CurrentRows)
            For k = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(k)("GRP")) Then
                    DtView1(k)("GRP") = "C"
                End If
            Next

            strSQL = "SELECT Shop_mtr.BY_cls, Shop_mtr.shop_code, Shop_mtr.[店舗名(ｶﾅ)], Shop_mtr.分類CD, V_cls_010.CLS_CODE_NAME"
            strSQL += " FROM Shop_mtr INNER JOIN V_cls_010 ON Shop_mtr.分類CD = V_cls_010.CLS_CODE"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(DsExport, "Shop_mtr")
            DB_CLOSE()

            DtView1 = New DataView(DsExport.Tables("XLS"), "", "BY_cls, shop_code, GRP", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
            End If

            'GoTo GRP
            '店舗毎

            waitDlg.MainMsg = "Excel作成中（店舗毎）"   ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            BR_BY_cls = Trim(DtView1(0)("BY_cls"))
            BR_Shop = Trim(DtView1(0)("shop_code"))

            Shop_TTL()          '店舗計出力
            For k = 1 To 8
                sum(k) = 0      '店舗計クリア
                For l = 0 To 9
                    ttl3(l, k) = 0 : ttl5(l, k) = 0 : Gttl(l, k) = 0
                    ttl10(l, k) = 0 '2015/08/05 家電保10年対応
                    ttl_KG(l, k) = 0 '2016/01/12 企業保証対応
                Next
            Next

            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object

            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add

            Line = 1
            oSheet = oBook.Worksheets(1)
            oSheet.Range("A1").Value = "店舗コード"
            oSheet.Range("B1").Value = "店舗名"
            oSheet.Range("C1").Value = "店舗区分"
            oSheet.Range("D1").Value = "件数"
            '            oSheet.Range("E1").Value = "購入価格(税込)"
            oSheet.Range("E1").Value = "購入価格(税抜)"
            oSheet.Range("F1").Value = "販売保証料"
            oSheet.Range("G1").Value = "店舗手数料"
            oSheet.Range("H1").Value = "保証引受額"
            oSheet.Range("I1").Value = "保証引当額"
            oSheet.Range("J1").Value = "ｿﾆｱ手数料(税抜)"
            '            oSheet.Range("K1").Value = "RD手数料(税込)"
            oSheet.Range("K1").Value = "RD手数料(税抜)"
            oSheet.Range("A1:K1").Interior.Color = RGB(0, 255, 255)

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If IsDBNull(DtView1(i)("wrn_prod")) Then
                    If IsDBNull(DtView1(i)("wrn_prod_old")) Then
                        DtView1(i)("wrn_prod") = "1"
                    Else
                        DtView1(i)("wrn_prod") = DtView1(i)("wrn_prod_old")
                    End If
                End If

                If DtView1(i)("shop_code") <> BR_Shop Or DtView1(i)("BY_cls") <> BR_BY_cls Then
                    Shop_TTL()          '店舗計出力
                    oSheet.Range("A" & Line).Value = Chr(39) & BR_Shop.ToString '店舗コード
                    oSheet.Range("B" & Line).Value = WK_Shop_Name               '店舗名
                    oSheet.Range("C" & Line).Value = WK_bnrui_name              '店舗区分
                    oSheet.Range("D" & Line).Value = sum(1)                     '件数
                    oSheet.Range("E" & Line).Value = Format(sum(2), "##0,00")   '購入価格(税抜)
                    oSheet.Range("F" & Line).Value = Format(sum(3), "##0,00")   '販売保証料
                    oSheet.Range("G" & Line).Value = Format(sum(4), "##0,00")   '店舗手数料
                    oSheet.Range("H" & Line).Value = Format(sum(5), "##0,00")   '保証引受額
                    oSheet.Range("I" & Line).Value = Format(sum(6), "##0,00")   '保証引当額
                    '2014/05/16 消費税対策 start
                    '                    oSheet.Range("J" & Line).Value = Format(sum(7), "##0,00")   'ｿﾆｱ手数料(税込)
                    oSheet.Range("J" & Line).Value = "－"    'ｿﾆｱ手数料(税込)
                    oSheet.Range("J" & Line).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    '2014/05/16 消費税対策 end
                    oSheet.Range("K" & Line).Value = Format(sum(8), "##0,00")   'RD手数料(税込)
                    oSheet.Range("D" & Line & ":K" & Line).Font.Name = "Arial"

                    For k = 1 To 8
                        sum(k) = 0    '店舗計クリア
                    Next

                    BR_BY_cls = DtView1(i)("BY_cls")
                    BR_Shop = DtView1(i)("shop_code")
                End If

                Dtl(1) = 1                                                          '件数


                '2014/6/20 手数料算出基準の税込から税抜への変更
                'WK_price = DtView1(i)("prch_price") + DtView1(i)("prch_tax")
                WK_price = DtView1(i)("prch_price")

                Dtl(2) = WK_price                                   '購入価格(税抜)

                '2016/03/30 業務用対応　Start
                Dim wrn_item_code As String
                If Not IsDBNull(DtView1(i)("wrn_item_code")) Then wrn_item_code = DtView1(i)("wrn_item_code") Else wrn_item_code = Nothing
                Select Case wrn_item_code
                    Case Is = "85118901", "85120701", "90028550"                '３年保証
                        Dtl(3) = RoundDOWN(WK_price * 5.0 / 100, 0)     '販売保証料 5.000%
                        Dtl(4) = RoundDOWN(WK_price * 1.24 / 100, 0)    '店舗手数料 1.240%
                        Dtl(5) = RoundDOWN(WK_price * 3.76 / 100, 0)    '保証引受額 3.760%
                        Dtl(6) = RoundDOWN(WK_price * 3.082 / 100, 0)   '保証引当額 3.082%
                    Case Is = "85069901", "90028560"                            '５年保証
                        Dtl(3) = RoundDOWN(WK_price * 5.0 / 100, 0)     '販売保証料 5.000%
                        Dtl(4) = RoundDOWN(WK_price * 1.525 / 100, 0)   '店舗手数料 1.525%
                        Dtl(5) = RoundDOWN(WK_price * 3.475 / 100, 0)   '保証引受額 3.475%
                        Dtl(6) = RoundDOWN(WK_price * 2.812 / 100, 0)   '保証引当額 2.812%
                    Case Is = "85121401", "90028570"                            '10年保証
                        Dtl(3) = RoundDOWN(WK_price * 8.0 / 100, 0)     '販売保証料 8.000%
                        Dtl(4) = RoundDOWN(WK_price * 3.0 / 100, 0)     '店舗手数料 3.000%
                        Dtl(5) = RoundDOWN(WK_price * 5.0 / 100, 0)     '保証引受額 5.000%
                        Dtl(6) = RoundDOWN(WK_price * 3.0 / 100, 0)     '保証引当額 3.000%
                    Case Is = "85121901", "85124001", "85123801", "85124201"    '企業保証
                        Dtl(3) = RoundDOWN(WK_price * 10.0 / 100, 0)    '販売保証料 10.000%
                        Dtl(4) = RoundDOWN(WK_price * 4.5 / 100, 0)     '店舗手数料 4.500%
                        Dtl(5) = RoundDOWN(WK_price * 5.5 / 100, 0)     '保証引受額 5.500%
                        Dtl(6) = RoundDOWN(WK_price * 5.0 / 100, 0)     '保証引当額 5.000%
                    Case Else
                        '2015/08/05 家電保10年対応　Start
                        If DtView1(i)("corp_flg") = "2" Then
                            Dtl(3) = RoundDOWN(WK_price * 10.0 / 100, 0)    '販売保証料 10.000%
                            Dtl(4) = RoundDOWN(WK_price * 4.5 / 100, 0)     '店舗手数料 4.500%
                            Dtl(5) = RoundDOWN(WK_price * 5.5 / 100, 0)     '保証引受額 5.500%
                            Dtl(6) = RoundDOWN(WK_price * 5.0 / 100, 0)     '保証引当額 5.000%

                        ElseIf DtView1(i)("wrn_prod") = 36 Then                 '３年保証
                            Dtl(3) = RoundDOWN(WK_price * 5.0 / 100, 0)     '販売保証料 5.000%
                            Dtl(4) = RoundDOWN(WK_price * 1.24 / 100, 0)    '店舗手数料 1.240%
                            Dtl(5) = RoundDOWN(WK_price * 3.76 / 100, 0)    '保証引受額 3.760%
                            Dtl(6) = RoundDOWN(WK_price * 3.082 / 100, 0)   '保証引当額 3.082%

                        ElseIf DtView1(i)("wrn_prod") = 60 Then             '５年保証
                            Dtl(3) = RoundDOWN(WK_price * 5.0 / 100, 0)     '販売保証料 5.000%
                            Dtl(4) = RoundDOWN(WK_price * 1.525 / 100, 0)   '店舗手数料 1.525%
                            Dtl(5) = RoundDOWN(WK_price * 3.475 / 100, 0)   '保証引受額 3.475%
                            Dtl(6) = RoundDOWN(WK_price * 2.812 / 100, 0)   '保証引当額 2.812%

                        ElseIf DtView1(i)("wrn_prod") = 120 Then            '１０年保証
                            Dtl(3) = RoundDOWN(WK_price * 8.0 / 100, 0)     '販売保証料 8.000%
                            Dtl(4) = RoundDOWN(WK_price * 3.0 / 100, 0)     '店舗手数料 3.000%
                            Dtl(5) = RoundDOWN(WK_price * 5.0 / 100, 0)     '保証引受額 5.000%
                            Dtl(6) = RoundDOWN(WK_price * 3.0 / 100, 0)     '保証引当額 3.000%
                        Else
                        End If
                        '2015/08/05 家電保10年対応　End 
                End Select
                '2016/03/30 家業務用対応　End

                'Dtl(3) = RoundDOWN(WK_price * 4.762 / 100, 0)       '販売保証料
                'Dtl(3) = RoundDOWN(WK_price * 5.0 / 100, 0)         '販売保証料
                'If DtView1(i)("wrn_prod") = 36 Then
                '                    Dtl(4) = RoundDOWN(WK_price * 1.181 / 100, 0)   '店舗手数料
                '                    Dtl(5) = RoundDOWN(WK_price * 3.581 / 100, 0)   '保証引受額
                'Dtl(4) = RoundDOWN(WK_price * 1.24 / 100, 0)    '店舗手数料
                'Dtl(5) = RoundDOWN(WK_price * 3.76 / 100, 0)    '保証引受額
                'Dtl(6) = RoundDOWN(WK_price * 3.082 / 100, 0)   '保証引当額
                'Else
                '                    Dtl(4) = RoundDOWN(WK_price * 1.452 / 100, 0)   '店舗手数料
                '                    Dtl(5) = RoundDOWN(WK_price * 3.31 / 100, 0)    '保証引受額
                '   Dtl(4) = RoundDOWN(WK_price * 1.525 / 100, 0)   '店舗手数料
                '  Dtl(5) = RoundDOWN(WK_price * 3.475 / 100, 0)    '保証引受額
                ' Dtl(6) = RoundDOWN(WK_price * 2.812 / 100, 0)   '保証引当額
                'End If

                '2014/05/16 消費税対策 start
                '                Dtl(7) = 115                                                        'ｿﾆｱ手数料(税込)
                '                Dtl(8) = 31                                                         'RD手数料(税込)

                'Dtl(7)は明細は出力しないが、処理変更を少なくするため0を設定　※ｿﾆｱ手数料は、購入価格(税込)総合計の0.3%で算出するため
                Dtl(7) = 0 'ｿﾆｱ手数料(税込)
                '                Dtl(8) = RoundDOWN(30 * (1 + GetTaxRate(DtView1(i)("fin_date"))), 0)     'RD手数料(税込) cf)税抜30円 完了日を基準に税率設定 
                '2014/05/16 消費税対策 end


                '2014/6/20 手数料算出基準の税込から税抜への変更
                Dtl(8) = 30 'RD手数料(税込)

                For k = 1 To 8
                    sum(k) = sum(k) + Dtl(k)    '店舗計
                Next

                '2016/03/30 業務用対応　Start
                Select Case wrn_item_code
                    Case Is = "85118901", "85120701", "90028550"                '３年保証
                        For k = 1 To 8
                            ttl3(0, k) = ttl3(0, k) + Dtl(k)        '3年計
                        Next
                    Case Is = "85069901", "90028560"                            '５年保証
                        For k = 1 To 8
                            ttl5(0, k) = ttl5(0, k) + Dtl(k)        '5年計
                        Next
                    Case Is = "85121401", "90028570"                            '10年保証
                        For k = 1 To 8
                            ttl10(0, k) = ttl10(0, k) + Dtl(k)      '10年計
                        Next
                    Case Is = "85121901", "85124001", "85123801", "85124201"    '企業保証
                        For k = 1 To 8
                            ttl_KG(0, k) = ttl_KG(0, k) + Dtl(k)    '企業保証計
                        Next
                    Case Else
                        '2015/08/05 家電保10年対応　Start
                        'If DtView1(i)("wrn_prod") = 36 Then
                        'For k = 1 To 8
                        'ttl3(0, k) = ttl3(0, k) + Dtl(k)        '3年計
                        'Next
                        'Else
                        'For k = 1 To 8
                        'ttl5(0, k) = ttl5(0, k) + Dtl(k)        '5年計
                        'Next
                        'End If
                        If DtView1(i)("corp_flg") = "2" Then
                            For k = 1 To 8
                                ttl_KG(0, k) = ttl_KG(0, k) + Dtl(k)    '企業保証計
                            Next

                        ElseIf DtView1(i)("wrn_prod") = 36 Then
                            For k = 1 To 8
                                ttl3(0, k) = ttl3(0, k) + Dtl(k)        '3年計
                            Next

                        ElseIf DtView1(i)("wrn_prod") = 60 Then
                            For k = 1 To 8
                                ttl5(0, k) = ttl5(0, k) + Dtl(k)        '5年計
                            Next

                        ElseIf DtView1(i)("wrn_prod") = 120 Then
                            For k = 1 To 8
                                ttl10(0, k) = ttl10(0, k) + Dtl(k)      '10年計
                            Next

                        End If
                        '2015/08/05 家電保10年対応　End
                End Select
                '2016/03/30 家業務用対応　End


                For k = 1 To 8
                    Gttl(0, k) = Gttl(0, k) + Dtl(k)            '総合計
                Next
            Next

            Shop_TTL()  '店舗計出力
            oSheet.Range("A" & Line).Value = Chr(39) & BR_Shop.ToString '店舗コード
            oSheet.Range("B" & Line).Value = WK_Shop_Name               '店舗名
            oSheet.Range("C" & Line).Value = WK_bnrui_name              '店舗区分
            oSheet.Range("D" & Line).Value = sum(1)                     '件数
            oSheet.Range("E" & Line).Value = Format(sum(2), "##0,00")   '購入価格(税抜)
            oSheet.Range("F" & Line).Value = Format(sum(3), "##0,00")   '販売保証料
            oSheet.Range("G" & Line).Value = Format(sum(4), "##0,00")   '店舗手数料
            oSheet.Range("H" & Line).Value = Format(sum(5), "##0,00")   '保証引当額
            oSheet.Range("I" & Line).Value = Format(sum(6), "##0,00")   '朝日保険料
            '2014/05/16 消費税対策 start
            '            oSheet.Range("J" & Line).Value = Format(sum(7), "##0,00")   'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).Value = "－"    'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            '2014/05/16 消費税対策 end
            oSheet.Range("K" & Line).Value = Format(sum(8), "##0,00")   'RD手数料(税抜)
            oSheet.Range("D" & Line & ":K" & Line).Font.Name = "Arial"

            '総合計出力
            Line = Line + 1
            oSheet.Range("D" & Line).Value = "=SUM(D2:D" & Line - 1 & ")"
            oSheet.Range("E" & Line).Value = "=SUM(E2:E" & Line - 1 & ")"
            oSheet.Range("F" & Line).Value = "=SUM(F2:F" & Line - 1 & ")"
            oSheet.Range("G" & Line).Value = "=SUM(G2:G" & Line - 1 & ")"
            oSheet.Range("H" & Line).Value = "=SUM(H2:H" & Line - 1 & ")"
            oSheet.Range("I" & Line).Value = "=SUM(I2:I" & Line - 1 & ")"
            '2014/05/16 消費税対策 start
            '            oSheet.Range("J" & Line).Value = "=SUM(J2:J" & Line - 1 & ")"
            oSheet.Range("J" & Line).Value = "－"    'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            '2014/05/16 消費税対策 end
            oSheet.Range("K" & Line).Value = "=SUM(K2:K" & Line - 1 & ")"
            oSheet.Range("D" & Line & ":K" & Line).Font.Name = "Arial"

            '３年保証
            Line = Line + 2
            oSheet.Range("B" & Line).Value = "３年保証"
            oSheet.Range("C" & Line).Value = "全店計"
            oSheet.Range("D" & Line).Value = ttl3(0, 1)                    '件数
            oSheet.Range("E" & Line).Value = Format(ttl3(0, 2), "##0,00")  '購入価格(税抜)
            oSheet.Range("F" & Line).Value = Format(ttl3(0, 3), "##0,00")  '販売保証料
            oSheet.Range("G" & Line).Value = Format(ttl3(0, 4), "##0,00")  '店舗手数料
            oSheet.Range("H" & Line).Value = Format(ttl3(0, 5), "##0,00")  '保証引受額
            oSheet.Range("I" & Line).Value = Format(ttl3(0, 6), "##0,00")  '保証引当額
            '2014/05/16 消費税対策 start
            '            oSheet.Range("J" & Line).Value = Format(ttl3(0, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).Value = "－"    'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            '2014/05/16 消費税対策 end
            oSheet.Range("K" & Line).Value = Format(ttl3(0, 8), "##0,00")  'RD手数料(税抜)
            oSheet.Range("D" & Line & ":K" & Line).Font.Name = "Arial"

            '５年保証
            Line = Line + 2
            oSheet.Range("B" & Line).Value = "５年保証"
            oSheet.Range("C" & Line).Value = "全店計"
            oSheet.Range("D" & Line).Value = ttl5(0, 1)                    '件数
            oSheet.Range("E" & Line).Value = Format(ttl5(0, 2), "##0,00")  '購入価格(税抜)
            oSheet.Range("F" & Line).Value = Format(ttl5(0, 3), "##0,00")  '販売保証料
            oSheet.Range("G" & Line).Value = Format(ttl5(0, 4), "##0,00")  '店舗手数料
            oSheet.Range("H" & Line).Value = Format(ttl5(0, 5), "##0,00")  '保証引受額
            oSheet.Range("I" & Line).Value = Format(ttl5(0, 6), "##0,00")  '保証引当額
            '2014/05/16 消費税対策 start
            '            oSheet.Range("J" & Line).Value = Format(ttl5(0, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).Value = "－"  'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            '2014/05/16 消費税対策 end
            oSheet.Range("K" & Line).Value = Format(ttl5(0, 8), "##0,00")  'RD手数料(税抜)
            oSheet.Range("D" & Line & ":K" & Line).Font.Name = "Arial"

            '2014/08/05 家電保10年追加対応 start
            '10年保証
            Line = Line + 2
            oSheet.Range("B" & Line).Value = "１０年保証"
            oSheet.Range("C" & Line).Value = "全店計"
            oSheet.Range("D" & Line).Value = ttl10(0, 1)                    '件数
            oSheet.Range("E" & Line).Value = Format(ttl10(0, 2), "##0,00")  '購入価格(税抜)
            oSheet.Range("F" & Line).Value = Format(ttl10(0, 3), "##0,00")  '販売保証料
            oSheet.Range("G" & Line).Value = Format(ttl10(0, 4), "##0,00")  '店舗手数料
            oSheet.Range("H" & Line).Value = Format(ttl10(0, 5), "##0,00")  '保証引受額
            oSheet.Range("I" & Line).Value = Format(ttl10(0, 6), "##0,00")  '保証引当額
            oSheet.Range("J" & Line).Value = "－"                          'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("K" & Line).Value = Format(ttl10(0, 8), "##0,00")  'RD手数料(税抜)
            oSheet.Range("D" & Line & ":K" & Line).Font.Name = "Arial"
            '2014/08/05 家電保10年追加対応 End

            '2016/01/12 企業保証追加対応 start
            '企業保証
            Line = Line + 2
            oSheet.Range("B" & Line).Value = "企業保証"
            oSheet.Range("C" & Line).Value = "全店計"
            oSheet.Range("D" & Line).Value = ttl_KG(0, 1)                    '件数
            oSheet.Range("E" & Line).Value = Format(ttl_KG(0, 2), "##0,00")  '購入価格(税抜)
            oSheet.Range("F" & Line).Value = Format(ttl_KG(0, 3), "##0,00")  '販売保証料
            oSheet.Range("G" & Line).Value = Format(ttl_KG(0, 4), "##0,00")  '店舗手数料
            oSheet.Range("H" & Line).Value = Format(ttl_KG(0, 5), "##0,00")  '保証引受額
            oSheet.Range("I" & Line).Value = Format(ttl_KG(0, 6), "##0,00")  '保証引当額
            oSheet.Range("J" & Line).Value = "－"                          'ｿﾆｱ手数料(税込)
            oSheet.Range("J" & Line).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("K" & Line).Value = Format(ttl_KG(0, 8), "##0,00")  'RD手数料(税抜)
            oSheet.Range("D" & Line & ":K" & Line).Font.Name = "Arial"
            '2016/01/12 企業保証追加対応 End

            '全保証年
            Line = Line + 2
            oSheet.Range("B" & Line).Value = "全保証年"
            oSheet.Range("C" & Line).Value = "全店計"
            oSheet.Range("D" & Line).Value = Gttl(0, 1)                    '件数
            oSheet.Range("E" & Line).Value = Format(Gttl(0, 2), "##0,00")  '購入価格(税抜)
            oSheet.Range("F" & Line).Value = Format(Gttl(0, 3), "##0,00")  '販売保証料
            oSheet.Range("G" & Line).Value = Format(Gttl(0, 4), "##0,00")  '店舗手数料
            oSheet.Range("H" & Line).Value = Format(Gttl(0, 5), "##0,00")  '保証引受額
            oSheet.Range("I" & Line).Value = Format(Gttl(0, 6), "##0,00")  '保証引当額
            '2014/05/16 消費税対策 start
            '            oSheet.Range("J" & Line).Value = Format(Gttl(0, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet.Range("J" & Line).Value = Format(RoundDOWN(Gttl(0, 2) * 0.003D, 0), "##0,00")    'ｿﾆｱ手数料は、購入価格(税込)総合計の0.3%
            sonia_fee = RoundDOWN(Gttl(0, 2) * 0.003D, 0)
            'If sonia_fee < 1296000 Then
            '    sonia_fee = 1296000
            'End If
            oSheet.Range("J" & Line).Value = Format(sonia_fee, "##0,00")    'ｿﾆｱ手数料は、購入価格(税込)総合計の0.3%

            '2014/05/16 消費税対策 end
            oSheet.Range("K" & Line).Value = Format(Gttl(0, 8), "##0,00")  'RD手数料(税抜)
            oSheet.Range("D" & Line & ":K" & Line).Font.Name = "Arial"
            '2014/05/16 消費税対策 start
            oSheet.Range("A" & Line & ":K" & Line).Font.bold = True     '太字表示
            '2014/05/16 消費税対策 end

            oSheet.Range("A1:K" & Line).EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

            '［名前を付けて保存］ダイアログボックスを表示
            SaveFileDialog1.FileName = "延長保証料総括表_個人.xls"
            SaveFileDialog1.Filter = "Excelファイル|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
            Try
                oBook.SaveAs(SaveFileDialog1.FileName)
            Catch ex As System.Exception
                GoTo end_prc2
            End Try
end_prc:

            ' 終了処理　
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
            GC.Collect()

GRP:
            ''店舗・グループ毎

            'waitDlg.MainMsg = "Excel作成中（店舗・グループ毎）" ' 進行状況ダイアログのメーターを設定
            'waitDlg.ProgressMax = DtView1.Count                 ' 全体の処理件数を設定
            'waitDlg.ProgressValue = 0                           ' 最初の件数を設定
            'Application.DoEvents()                              ' メッセージ処理を促して表示を更新する

            'BR_BY_cls = DtView1(0)("BY_cls")
            'BR_Shop = DtView1(0)("shop_code")
            'If IsDBNull(DtView1(0)("GRP")) Then BR_GRP = "C" Else BR_GRP = DtView1(0)("GRP")

            'For k = 1 To 8
            '    sum(k) = 0    '店舗計クリア
            '    For l = 0 To 9
            '        ttl3(l, k) = 0 : ttl5(l, k) = 0 : Gttl(l, k) = 0
            '    Next
            'Next

            'Dim oExcel2 As Object
            'Dim oBook2 As Object
            'Dim oSheet2 As Object

            'oExcel2 = CreateObject("Excel.Application")
            'oBook2 = oExcel2.Workbooks.Add

            'Line = 1
            'oSheet2 = oBook2.Worksheets(1)
            'oSheet2.Range("A1").Value = "店舗コード"
            'oSheet2.Range("B1").Value = "店舗名"
            'oSheet2.Range("C1").Value = "店舗区分"
            'oSheet2.Range("D1").Value = "区分"
            'oSheet2.Range("E1").Value = "件数"
            'oSheet2.Range("F1").Value = "購入価格(税込)"
            'oSheet2.Range("G1").Value = "販売保証料"
            'oSheet2.Range("H1").Value = "店舗手数料"
            'oSheet2.Range("I1").Value = "保証引受額"
            'oSheet2.Range("J1").Value = "保証引当額"
            'oSheet2.Range("K1").Value = "ｿﾆｱ手数料(税込)"
            'oSheet2.Range("L1").Value = "RD手数料(税込)"
            'oSheet2.Range("A1:L1").Interior.Color = RGB(0, 255, 255)

            'For i = 0 To DtView1.Count - 1
            '    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
            '    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            '    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            '    If IsDBNull(DtView1(i)("GRP")) Then DtView1(i)("GRP") = "C"

            '    If DtView1(i)("shop_code") <> BR_Shop Or BR_GRP <> DtView1(i)("GRP") Or BR_BY_cls <> DtView1(i)("BY_cls") Then
            '        Shop_TTL()          '店舗計出力
            '        oSheet2.Range("A" & Line).Value = Chr(39) & BR_Shop.ToString    '店舗コード
            '        oSheet2.Range("B" & Line).Value = WK_Shop_Name                  '店舗名
            '        oSheet2.Range("C" & Line).Value = WK_bnrui_name                 '店舗区分
            '        oSheet2.Range("D" & Line).Value = BR_GRP                        '区分
            '        oSheet2.Range("E" & Line).Value = sum(1)                        '件数
            '        oSheet2.Range("F" & Line).Value = Format(sum(2), "##0,00")      '購入価格(税込)
            '        oSheet2.Range("G" & Line).Value = Format(sum(3), "##0,00")      '販売保証料
            '        oSheet2.Range("H" & Line).Value = Format(sum(4), "##0,00")      '店舗手数料
            '        oSheet2.Range("I" & Line).Value = Format(sum(5), "##0,00")      '保証引受額
            '        oSheet2.Range("J" & Line).Value = Format(sum(6), "##0,00")      '保証引当額
            '        oSheet2.Range("K" & Line).Value = Format(sum(7), "##0,00")      'ｿﾆｱ手数料(税込)
            '        oSheet2.Range("L" & Line).Value = Format(sum(8), "##0,00")      'RD手数料(税込)
            '        oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            '        For k = 1 To 8
            '            sum(k) = 0    '店舗計クリア
            '        Next

            '        BR_BY_cls = DtView1(i)("BY_cls")
            '        BR_Shop = DtView1(i)("shop_code")
            '        If IsDBNull(DtView1(i)("GRP")) Then BR_GRP = "C" Else BR_GRP = DtView1(i)("GRP")
            '    End If

            '    Dtl(1) = 1                                                          '件数
            '    WK_price = DtView1(i)("prch_price") + DtView1(i)("prch_tax")
            '    Dtl(2) = WK_price                                   '購入価格(税込)
            '    Dtl(3) = RoundDOWN(WK_price * 4.762 / 100, 0)       '販売保証料
            '    If DtView1(i)("wrn_prod") = 36 Then
            '        Dtl(4) = RoundDOWN(WK_price * 1.181 / 100, 0)   '店舗手数料
            '        Dtl(5) = RoundDOWN(WK_price * 3.581 / 100, 0)   '保証引受額
            '        Dtl(6) = RoundDOWN(WK_price * 3.082 / 100, 0)   '保証引当額
            '    Else
            '        Dtl(4) = RoundDOWN(WK_price * 1.452 / 100, 0)   '店舗手数料
            '        Dtl(5) = RoundDOWN(WK_price * 3.31 / 100, 0)    '保証引受額
            '        Dtl(6) = RoundDOWN(WK_price * 2.812 / 100, 0)   '保証引当額
            '    End If
            '    Dtl(7) = 115                                                        'ｿﾆｱ手数料(税込)
            '    Dtl(8) = 31                                                         'RD手数料(税込)

            '    For k = 1 To 8
            '        sum(k) = sum(k) + Dtl(k)    '店舗計
            '    Next

            '    If DtView1(i)("wrn_prod") = 36 Then
            '        Select Case DtView1(i)("GRP")
            '            Case Is = "A"
            '                For k = 1 To 8
            '                    ttl3(7, k) = ttl3(7, k) + Dtl(k)    '3年全店計 A
            '                Next
            '            Case Is = "B"
            '                For k = 1 To 8
            '                    ttl3(8, k) = ttl3(8, k) + Dtl(k)    '3年全店計 B
            '                Next
            '            Case Else
            '                For k = 1 To 8
            '                    ttl3(9, k) = ttl3(9, k) + Dtl(k)    '3年全店計 C
            '                Next
            '        End Select
            '    Else
            '        Select Case DtView1(i)("GRP")
            '            Case Is = "A"
            '                For k = 1 To 8
            '                    ttl5(7, k) = ttl5(7, k) + Dtl(k)    '5年全店計 A
            '                Next
            '            Case Is = "B"
            '                For k = 1 To 8
            '                    ttl5(8, k) = ttl5(8, k) + Dtl(k)    '5年全店計 B
            '                Next
            '            Case Else
            '                For k = 1 To 8
            '                    ttl5(9, k) = ttl5(9, k) + Dtl(k)    '5年全店計 C
            '                Next
            '        End Select
            '    End If
            '    Select Case DtView1(i)("GRP")
            '        Case Is = "A"
            '            For k = 1 To 8
            '                Gttl(7, k) = Gttl(7, k) + Dtl(k)    '全保証年全店計 A
            '            Next
            '        Case Is = "B"
            '            For k = 1 To 8
            '                Gttl(8, k) = Gttl(8, k) + Dtl(k)    '全保証年全店計 B
            '            Next
            '        Case Else
            '            For k = 1 To 8
            '                Gttl(9, k) = Gttl(9, k) + Dtl(k)    '全保証年全店計 C
            '            Next
            '    End Select

            'Next
            'Shop_TTL()  '店舗計出力
            'oSheet2.Range("A" & Line).Value = Chr(39) & BR_Shop.ToString    '店舗コード
            'oSheet2.Range("B" & Line).Value = WK_Shop_Name                  '店舗名
            'oSheet2.Range("C" & Line).Value = WK_bnrui_name                 '店舗区分
            'oSheet2.Range("D" & Line).Value = BR_GRP                        '区分
            'oSheet2.Range("E" & Line).Value = sum(1)                        '件数
            'oSheet2.Range("F" & Line).Value = Format(sum(2), "##0,00")      '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(sum(3), "##0,00")      '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(sum(4), "##0,00")      '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(sum(5), "##0,00")      '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(sum(6), "##0,00")      '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(sum(7), "##0,00")      'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(sum(8), "##0,00")      'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''総合計出力
            'Line = Line + 1
            'oSheet2.Range("E" & Line).Value = "=SUM(E2:E" & Line - 1 & ")"
            'oSheet2.Range("F" & Line).Value = "=SUM(F2:F" & Line - 1 & ")"
            'oSheet2.Range("G" & Line).Value = "=SUM(G2:G" & Line - 1 & ")"
            'oSheet2.Range("H" & Line).Value = "=SUM(H2:H" & Line - 1 & ")"
            'oSheet2.Range("I" & Line).Value = "=SUM(I2:I" & Line - 1 & ")"
            'oSheet2.Range("J" & Line).Value = "=SUM(J2:J" & Line - 1 & ")"
            'oSheet2.Range("K" & Line).Value = "=SUM(K2:K" & Line - 1 & ")"
            'oSheet2.Range("L" & Line).Value = "=SUM(L2:L" & Line - 1 & ")"
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''３年保証全店計
            ''A
            'Line = Line + 2
            'oSheet2.Range("B" & Line).Value = "３年保証"
            'oSheet2.Range("C" & Line).Value = "全店計"
            'oSheet2.Range("D" & Line).Value = "A"
            'oSheet2.Range("E" & Line).Value = ttl3(7, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(ttl3(7, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(ttl3(7, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(ttl3(7, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(ttl3(7, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(ttl3(7, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(ttl3(7, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(ttl3(7, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''B
            'Line = Line + 1
            'oSheet2.Range("D" & Line).Value = "B"
            'oSheet2.Range("E" & Line).Value = ttl3(8, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(ttl3(8, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(ttl3(8, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(ttl3(8, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(ttl3(8, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(ttl3(8, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(ttl3(8, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(ttl3(8, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''C
            'Line = Line + 1
            'oSheet2.Range("D" & Line).Value = "C"
            'oSheet2.Range("E" & Line).Value = ttl3(9, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(ttl3(9, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(ttl3(9, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(ttl3(9, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(ttl3(9, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(ttl3(9, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(ttl3(9, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(ttl3(9, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''５年保証全店計
            ''A
            'Line = Line + 2
            'oSheet2.Range("B" & Line).Value = "５年保証"
            'oSheet2.Range("C" & Line).Value = "全店計"
            'oSheet2.Range("D" & Line).Value = "A"
            'oSheet2.Range("E" & Line).Value = ttl5(7, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(ttl5(7, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(ttl5(7, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(ttl5(7, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(ttl5(7, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(ttl5(7, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(ttl5(7, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(ttl5(7, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''B
            'Line = Line + 1
            'oSheet2.Range("D" & Line).Value = "B"
            'oSheet2.Range("E" & Line).Value = ttl5(8, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(ttl5(8, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(ttl5(8, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(ttl5(8, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(ttl5(8, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(ttl5(8, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(ttl5(8, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(ttl5(8, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''C
            'Line = Line + 1
            'oSheet2.Range("D" & Line).Value = "C"
            'oSheet2.Range("E" & Line).Value = ttl5(9, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(ttl5(9, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(ttl5(9, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(ttl5(9, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(ttl5(9, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(ttl5(9, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(ttl5(9, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(ttl5(9, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''全保証年全店計
            ''A
            'Line = Line + 2
            'oSheet2.Range("B" & Line).Value = "全保証年"
            'oSheet2.Range("C" & Line).Value = "全店計"
            'oSheet2.Range("D" & Line).Value = "A"
            'oSheet2.Range("E" & Line).Value = Gttl(7, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(Gttl(7, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(Gttl(7, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(Gttl(7, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(Gttl(7, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(Gttl(7, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(Gttl(7, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(Gttl(7, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''B
            'Line = Line + 1
            'oSheet2.Range("D" & Line).Value = "B"
            'oSheet2.Range("E" & Line).Value = Gttl(8, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(Gttl(8, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(Gttl(8, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(Gttl(8, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(Gttl(8, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(Gttl(8, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(Gttl(8, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(Gttl(8, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            ''C
            'Line = Line + 1
            'oSheet2.Range("D" & Line).Value = "C"
            'oSheet2.Range("E" & Line).Value = Gttl(9, 1)                    '件数
            'oSheet2.Range("F" & Line).Value = Format(Gttl(9, 2), "##0,00")  '購入価格(税込)
            'oSheet2.Range("G" & Line).Value = Format(Gttl(9, 3), "##0,00")  '販売保証料
            'oSheet2.Range("H" & Line).Value = Format(Gttl(9, 4), "##0,00")  '店舗手数料
            'oSheet2.Range("I" & Line).Value = Format(Gttl(9, 5), "##0,00")  '保証引当額
            'oSheet2.Range("J" & Line).Value = Format(Gttl(9, 6), "##0,00")  '朝日保険料
            'oSheet2.Range("K" & Line).Value = Format(Gttl(9, 7), "##0,00")  'ｿﾆｱ手数料(税込)
            'oSheet2.Range("L" & Line).Value = Format(Gttl(9, 8), "##0,00")  'RD手数料(税込)
            'oSheet2.Range("E" & Line & ":L" & Line).Font.Name = "Arial"

            'oSheet2.Range("A1:O" & Line).EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

            Me.Activate()
            waitDlg.Close()

            ''［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.FileName = "延長保証料総括表_個人_ｸﾞﾙｰﾌﾟ別.xls"
            'SaveFileDialog1.Filter = "Excelファイル|*.xls"
            'SaveFileDialog1.OverwritePrompt = False
            'If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc2
            'Try
            '    oSheet2.SaveAs(SaveFileDialog1.FileName)
            'Catch ex As System.Exception
            '    GoTo end_prc2
            'End Try
end_prc2:
            Me.Enabled = True

            '' 終了処理　
            'oSheet2 = Nothing
            'oBook2 = Nothing
            'oExcel2.Quit()
            'oExcel2 = Nothing
            'GC.Collect()

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '店舗計出力
    Sub Shop_TTL()
        Line = Line + 1
        WK_DtView1 = New DataView(DsExport.Tables("Shop_mtr"), "BY_cls = '" & BR_BY_cls & "' AND shop_code = '" & BR_Shop & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            WK_Shop_Name = Trim(WK_DtView1(0)("店舗名(ｶﾅ)"))
            WK_bnrui_name = Trim(WK_DtView1(0)("CLS_CODE_NAME"))
        Else
            WK_Shop_Name = Nothing
            WK_bnrui_name = Nothing
        End If
    End Sub

    '**********************************************************************
    '** 延長保証料総括表　前月解約処理分(個人)
    '**********************************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'F_Check()
        'If Err_F = "0" Then
        Dim frmFormP2 As New FormP2
        frmFormP2.ShowDialog()
        'End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 加入者データ
    '**********************************************************************
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            Me.Enabled = False                      ' オーナーのフォームを無効にする

            waitDlg = New WaitDialog                ' 進行状況ダイアログ
            waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = "加入者データ"  ' 処理の概要を表示
            waitDlg.ProgressMsg = "データ抽出中"    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0               ' 最初の件数を設定
            waitDlg.Show()                          ' 進行状況ダイアログを表示する
            Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT RTRIM(Wrn_mtr.ordr_no) AS 保証番号, Wrn_sub.line_no AS 行番号"
            strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS 顧客名"
            strSQL += ", RTRIM(Wrn_mtr.city_name) + ' ' + RTRIM(Wrn_mtr.adrs2) + ' ' + RTRIM(Wrn_mtr.adrs1) AS 住所"
            strSQL += ", RTRIM(Wrn_mtr.srch_phn) AS 電話番号, Wrn_sub.prch_date AS 購入日, Wrn_sub.prch_date AS 申込日"
            strSQL += ", Wrn_sub.prch_price AS 購入価格, Wrn_sub.prch_tax AS 消費税, Wrn_sub.wrn_fee AS 保証料"
            strSQL += ", RTRIM(Wrn_sub.brnd_name) AS [ﾒｰｶｰ名（仮名）], RTRIM(Wrn_sub.model_name) AS 型番"
            strSQL += ", Wrn_mtr.old_comp_flg, Wrn_sub.item_cat_code, V_Cat_mtr.GRP"
            strSQL += " FROM Wrn_mtr INNER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN"
            strSQL += " V_Cat_mtr ON Wrn_sub.item_cat_code = V_Cat_mtr.cd12"
            strSQL += " WHERE (Wrn_sub.corp_flg = '0')"
            If Label4.Text = "0" Then
                strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " AND (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1

            Try
                SqlCmd1.CommandTimeout = 7200
                DB_OPEN("best_wrn")
                r = DaList1.Fill(DsExport, "CSV")
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Activate()
                waitDlg.Close()
                Me.Enabled = True
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                'ファイルに出力
                sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

                waitDlg.MainMsg = "CSV作成中"           ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMax = DtView1.Count     ' 全体の処理件数を設定
                Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

                sbuf = "保証番号,行番号,顧客名,住所,電話番号,購入日,申込日,購入価格,保険料,ﾒｰｶｰ名,型番,品種,品種区分"
                sw.WriteLine(sbuf)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    sbuf = Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                    WK_str = DtView1(i)("顧客名")
                    sbuf = sbuf & Chr(34) & WK_str.Replace(Chr(34), "ﾞ") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                    sbuf = sbuf & DtView1(i)("購入日") & ","
                    sbuf = sbuf & DtView1(i)("申込日") & ","
                    sbuf = sbuf & DtView1(i)("購入価格") + DtView1(i)("消費税") & ","

                    '保険料
                    If DtView1(i)("購入日") >= "2007/07/01" Then
                        If IsDBNull(DtView1(i)("GRP")) Then
                            WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.024, 0))
                            If WK_int < 800 Then WK_int = 800
                            sbuf = sbuf & WK_int & ","
                        Else
                            Select Case DtView1(i)("GRP")
                                Case "A"
                                    WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.0295, 0))
                                    If WK_int < 800 Then WK_int = 800
                                    sbuf = sbuf & WK_int & ","
                                Case "B"
                                    WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.0373, 0))
                                    If WK_int < 800 Then WK_int = 800
                                    sbuf = sbuf & WK_int & ","
                                Case "C"
                                    WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.024, 0))
                                    If WK_int < 800 Then WK_int = 800
                                    sbuf = sbuf & WK_int & ","
                                Case Else
                                    sbuf = sbuf & "0,"
                            End Select
                        End If
                    Else
                        Select Case DtView1(i)("GRP")
                            Case "A"
                                WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.002176, 0))
                                sbuf = sbuf & WK_int & ","
                            Case "B", "C"
                                WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.0022, 0))
                                sbuf = sbuf & WK_int & ","
                            Case Else
                                sbuf = sbuf & "0,"
                        End Select
                    End If
                    sbuf = sbuf & Chr(34) & DtView1(i)("ﾒｰｶｰ名（仮名）") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("item_cat_code") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("GRP") & Chr(34)
                    sw.WriteLine(sbuf)
                Next
            End If
            sw.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "wrn.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                    sub_csv(SaveFileDialog1.FileName, "A")
                    sub_csv(SaveFileDialog1.FileName, "B")
                    sub_csv(SaveFileDialog1.FileName, "C")
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                    sub_csv(SaveFileDialog1.FileName, "A")
                    sub_csv(SaveFileDialog1.FileName, "B")
                    sub_csv(SaveFileDialog1.FileName, "C")
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Activate()
            waitDlg.Close()
            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub sub_csv(ByVal Path As String, ByVal GRP As String)
        Dim strData As String                'ファイルに出力するデータ
        Dim strFLD, strFile As String

        strFile = Mid(Path, 1, Path.LastIndexOf(".")) & "_" & GRP & Path.Substring(Path.LastIndexOf("."))
        Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        'データを書き込む
        strData = "保証番号,行番号,顧客名,住所,電話番号,購入日,申込日,購入価格,保険料,ﾒｰｶｰ名,型番,品種,品種区分"
        swFile.WriteLine(strData)

        If GRP <> "C" Then
            DtView1 = New DataView(DsExport.Tables("CSV"), "GRP = '" & GRP & "'", "保証番号,行番号", DataViewRowState.CurrentRows)
        Else
            DtView1 = New DataView(DsExport.Tables("CSV"), "GRP = '" & GRP & "' OR GRP IS NULL", "保証番号,行番号", DataViewRowState.CurrentRows)
        End If

        waitDlg.MainMsg = "グループ" & GRP & "　CSV出力中"           ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = DtView1.Count     ' 全体の処理件数を設定
        Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

        If DtView1.Count <> 0 Then
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = (CType(Fix((i + 1) * 100 / DtView1.Count), Integer)).ToString() & "%　（" & i + 1 & " / " & DtView1.Count & " 件）"
                waitDlg.Text = "実行中・・・" & (CType(Fix((i + 1) * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                WK_str = DtView1(i)("顧客名")
                strData = strData & Chr(34) & WK_str.Replace(Chr(34), "ﾞ") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("住所") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                strData = strData & DtView1(i)("購入日") & ","
                strData = strData & DtView1(i)("申込日") & ","
                strData = strData & DtView1(i)("購入価格") + DtView1(i)("消費税") & ","

                '保険料
                If IsDBNull(DtView1(i)("GRP")) Then
                    WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.024, 0))
                    If WK_int < 800 Then WK_int = 800
                    strData = strData & WK_int & ","
                Else
                    Select Case DtView1(i)("GRP")
                        Case "A"
                            WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.0295, 0))
                            If WK_int < 800 Then WK_int = 800
                            strData = strData & WK_int & ","
                        Case "B"
                            WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.0373, 0))
                            If WK_int < 800 Then WK_int = 800
                            strData = strData & WK_int & ","
                        Case "C"
                            WK_int = CInt(RoundDOWN((DtView1(i)("購入価格") + DtView1(i)("消費税")) * 0.024, 0))
                            If WK_int < 800 Then WK_int = 800
                            strData = strData & WK_int & ","
                        Case Else
                            strData = strData & "0,"
                    End Select
                End If
                strData = strData & Chr(34) & DtView1(i)("ﾒｰｶｰ名（仮名）") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("item_cat_code") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("GRP") & Chr(34)

                swFile.WriteLine(strData)
            Next
        End If
        swFile.Close()  'ファイルを閉じる

    End Sub

    '**********************************************************************
    '** 加入者データ(エース)
    '**********************************************************************
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            Me.Enabled = False                      ' オーナーのフォームを無効にする

            waitDlg = New WaitDialog                ' 進行状況ダイアログ
            waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = "加入者データ(エース)"    ' 処理の概要を表示
            waitDlg.ProgressMsg = "データ抽出中"    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0               ' 最初の件数を設定
            waitDlg.Show()                          ' 進行状況ダイアログを表示する
            Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS 顧客名"
            strSQL += ", RTRIM(Wrn_mtr.city_name) + ' ' + RTRIM(Wrn_mtr.adrs2) + ' ' + RTRIM(Wrn_mtr.adrs1) AS 住所"
            strSQL += ", RTRIM(Wrn_mtr.srch_phn) AS 電話番号"
            strSQL += ", Wrn_sub.prch_date AS 購入日"
            strSQL += ", Wrn_sub.prch_date AS 申込日"
            strSQL += ", Wrn_sub.prch_price + Wrn_sub.prch_tax AS 購入価格"
            strSQL += ", RTRIM(Wrn_sub.brnd_name) AS [ﾒｰｶｰ名（仮名）]"
            strSQL += ", RTRIM(Wrn_sub.model_name) AS 型番"
            strSQL += ", Old_Rate.ordr_no AS Old_Rate_ordr_no, Wrn_sub.item_cat_code, Cat_mtr.GRP"
            strSQL += " FROM Wrn_mtr INNER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN"
            strSQL += " (SELECT cd12, GRP FROM Cat_mtr WHERE (cd3 = '00')) Cat_mtr ON"
            strSQL += " Wrn_sub.item_cat_code = Cat_mtr.cd12 COLLATE Japanese_CI_AS LEFT OUTER JOIN"
            strSQL += " Old_Rate ON Wrn_sub.ordr_no = Old_Rate.ordr_no AND"
            strSQL += " Wrn_sub.line_no = Old_Rate.line_no"
            strSQL += " WHERE (Wrn_sub.corp_flg = '0')"
            If Label4.Text = "0" Then
                strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " AND (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
            End If
            strSQL += " AND (dbo.Wrn_sub.prch_date >= CONVERT(DATETIME, '2007-04-01 00:00:00', 102))"
            strSQL += " AND (dbo.Wrn_sub.prch_date < CONVERT(DATETIME, '2008-07-01 00:00:00', 102))"

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1

            Try
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                r = DaList1.Fill(DsExport, "CSV")
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Activate()
                waitDlg.Close()
                Me.Enabled = True
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            'ファイルに出力
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

            waitDlg.MainMsg = "CSV作成中"             ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            sbuf = "保証番号,行番号,顧客名,住所,電話番号,購入日,申込日,購入価格,保険料,ﾒｰｶｰ名,型番,品種,品種区分"
            sw.WriteLine(sbuf)

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                sbuf = Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                WK_str = DtView1(i)("顧客名")
                sbuf = sbuf & Chr(34) & WK_str.Replace(Chr(34), "ﾞ") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("住所") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                sbuf = sbuf & DtView1(i)("購入日") & ","
                sbuf = sbuf & DtView1(i)("申込日") & ","
                sbuf = sbuf & DtView1(i)("購入価格") & ","

                If IsDBNull(DtView1(i)("GRP")) Then
                    sbuf = sbuf & RoundDOWN(DtView1(i)("購入価格") * 0.0022, 0) & ","
                Else
                    If DtView1(i)("購入日") < "2007/11/01" Then
                        sbuf = sbuf & RoundDOWN(DtView1(i)("購入価格") * 0.0022, 0) & ","
                    Else
                        If DtView1(i)("GRP") = "A" Then
                            If IsDBNull(DtView1(i)("Old_Rate_ordr_no")) Then
                                sbuf = sbuf & RoundDOWN(DtView1(i)("購入価格") * 0.002176, 0) & ","
                            Else
                                sbuf = sbuf & RoundDOWN(DtView1(i)("購入価格") * 0.0022, 0) & ","
                            End If
                        End If
                    End If
                End If

                sbuf = sbuf & Chr(34) & DtView1(i)("ﾒｰｶｰ名（仮名）") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("item_cat_code") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("GRP") & Chr(34)
                sw.WriteLine(sbuf)
            Next
            sw.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "ace.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                    sub_csv2(SaveFileDialog1.FileName, "A")
                    sub_csv2(SaveFileDialog1.FileName, "B")
                    sub_csv2(SaveFileDialog1.FileName, "C")
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                    sub_csv2(SaveFileDialog1.FileName, "A")
                    sub_csv2(SaveFileDialog1.FileName, "B")
                    sub_csv2(SaveFileDialog1.FileName, "C")
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Activate()
            waitDlg.Close()
            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Sub sub_csv2(ByVal Path As String, ByVal GRP As String)
        Dim strData As String                'ファイルに出力するデータ
        Dim strFLD, strFile As String

        strFile = Mid(Path, 1, Path.LastIndexOf(".")) & "_" & GRP & Path.Substring(Path.LastIndexOf("."))
        Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        'データを書き込む
        strData = "保証番号,行番号,顧客名,住所,電話番号,購入日,申込日,購入価格,保険料,ﾒｰｶｰ名,型番,品種,品種区分"
        swFile.WriteLine(strData)

        If GRP <> "C" Then
            DtView1 = New DataView(DsExport.Tables("CSV"), "GRP = '" & GRP & "'", "保証番号,行番号", DataViewRowState.CurrentRows)
        Else
            DtView1 = New DataView(DsExport.Tables("CSV"), "GRP = '" & GRP & "' OR GRP IS NULL", "保証番号,行番号", DataViewRowState.CurrentRows)
        End If

        waitDlg.MainMsg = "グループ" & GRP & "　CSV出力中"           ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = DtView1.Count     ' 全体の処理件数を設定
        Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

        If DtView1.Count <> 0 Then
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = (CType(Fix((i + 1) * 100 / DtView1.Count), Integer)).ToString() & "%　（" & i + 1 & " / " & DtView1.Count & " 件）"
                waitDlg.Text = "実行中・・・" & (CType(Fix((i + 1) * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                WK_str = DtView1(i)("顧客名")
                strData = strData & Chr(34) & WK_str.Replace(Chr(34), "ﾞ") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("住所") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                strData = strData & DtView1(i)("購入日") & ","
                strData = strData & DtView1(i)("申込日") & ","
                strData = strData & DtView1(i)("購入価格") & ","
                If IsDBNull(DtView1(i)("GRP")) Then
                    strData = strData & RoundDOWN((DtView1(i)("prch_price") + DtView1(i)("prch_tax")) * 0.0022, 0) & ","
                Else
                    If DtView1(i)("GRP") <> "A" Then
                        strData = strData & RoundDOWN((DtView1(i)("prch_price") + DtView1(i)("prch_tax")) * 0.0022, 0) & ","
                    Else
                        If DtView1(i)("購入日") < "2007/11/01" Then
                            strData = strData & RoundDOWN((DtView1(i)("prch_price") + DtView1(i)("prch_tax")) * 0.0022, 0) & ","
                        Else
                            If IsDBNull(DtView1(i)("Old_Rate_ordr_no")) Then
                                strData = strData & RoundDOWN((DtView1(i)("prch_price") + DtView1(i)("prch_tax")) * 0.002176, 0) & ","
                            Else
                                strData = strData & RoundDOWN((DtView1(i)("prch_price") + DtView1(i)("prch_tax")) * 0.0022, 0) & ","
                            End If
                        End If

                    End If
                End If
                strData = strData & Chr(34) & DtView1(i)("ﾒｰｶｰ名（仮名）") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("item_cat_code") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("GRP") & Chr(34)

                swFile.WriteLine(strData)
            Next
        End If
        swFile.Close()  'ファイルを閉じる

    End Sub

    '**********************************************************************
    '** 加入者データ(朝日)
    '**********************************************************************
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            Me.Enabled = False                      ' オーナーのフォームを無効にする

            waitDlg = New WaitDialog                ' 進行状況ダイアログ
            waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = "加入者データ(朝日)"    ' 処理の概要を表示
            waitDlg.ProgressMsg = "データ抽出中"    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0               ' 最初の件数を設定
            waitDlg.Show()                          ' 進行状況ダイアログを表示する
            Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT RTRIM(Wrn_mtr.ordr_no) AS 保証番号, Wrn_sub.line_no AS 行番号"
            strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS 顧客名"
            strSQL += ", RTRIM(Wrn_mtr.city_name) + ' ' + RTRIM(Wrn_mtr.adrs2) + ' ' + RTRIM(Wrn_mtr.adrs1) AS 住所"
            strSQL += ", RTRIM(Wrn_mtr.srch_phn) AS 電話番号, Wrn_sub.prch_date AS 購入日, Wrn_sub.prch_date AS 申込日"
            strSQL += ", Wrn_sub.prch_price + Wrn_sub.prch_tax AS 購入価格, RTRIM(Wrn_sub.brnd_name) AS [ﾒｰｶｰ名（仮名）]"
            strSQL += ", RTRIM(Wrn_sub.model_name) AS 型番, Wrn_sub.item_cat_code, V_Cat_mtr.GRP"
            strSQL += " FROM Wrn_mtr INNER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN"
            strSQL += " V_Cat_mtr ON Wrn_sub.item_cat_code = V_Cat_mtr.cd12"
            strSQL += " WHERE (Wrn_sub.corp_flg = '0')"
            If Label4.Text = "0" Then
                strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " AND (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
            End If

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1

            Try
                SqlCmd1.CommandTimeout = 7200
                DB_OPEN("best_wrn")
                r = DaList1.Fill(DsExport, "CSV")
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Activate()
                waitDlg.Close()
                Me.Enabled = True
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            'ファイルに出力
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

            waitDlg.MainMsg = "CSV作成中"             ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            sbuf = "保証番号,行番号,顧客名,住所,電話番号,購入日,申込日,購入価格,保険料,ﾒｰｶｰ名,型番,品種,品種区分"
            sw.WriteLine(sbuf)

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                sbuf = Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                WK_str = DtView1(i)("顧客名")
                sbuf = sbuf & Chr(34) & WK_str.Replace(Chr(34), "ﾞ") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("住所") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                sbuf = sbuf & DtView1(i)("購入日") & ","
                sbuf = sbuf & DtView1(i)("申込日") & ","
                sbuf = sbuf & DtView1(i)("購入価格") & ","
                If DtView1(i)("申込日") < "2012/02/01" Then
                    If IsDBNull(DtView1(i)("GRP")) Then
                        sbuf = sbuf & RoundDOWN(DtView1(i)("購入価格") * 0.22 / 100, 0) & ","
                    Else
                        If DtView1(i)("GRP") <> "A" Then
                            sbuf = sbuf & RoundDOWN(DtView1(i)("購入価格") * 0.22 / 100, 0) & ","
                        Else
                            sbuf = sbuf & RoundDOWN(DtView1(i)("購入価格") * 0.2176 / 100, 0) & ","
                        End If
                    End If
                Else
                    sbuf = sbuf & "0,"
                End If
                sbuf = sbuf & Chr(34) & DtView1(i)("ﾒｰｶｰ名（仮名）") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("item_cat_code") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("GRP") & Chr(34)
                sw.WriteLine(sbuf)
            Next
            sw.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            SaveFileDialog1.FileName = "ASAHI.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                    sub_csv3(SaveFileDialog1.FileName, "A")
                    sub_csv3(SaveFileDialog1.FileName, "B")
                    sub_csv3(SaveFileDialog1.FileName, "C")
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                    sub_csv3(SaveFileDialog1.FileName, "A")
                    sub_csv3(SaveFileDialog1.FileName, "B")
                    sub_csv3(SaveFileDialog1.FileName, "C")
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Activate()
            waitDlg.Close()
            Me.Enabled = True

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub sub_csv3(ByVal Path As String, ByVal GRP As String)
        Dim strData As String                'ファイルに出力するデータ
        Dim strFLD, strFile As String

        strFile = Mid(Path, 1, Path.LastIndexOf(".")) & "_" & GRP & Path.Substring(Path.LastIndexOf("."))
        Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        'データを書き込む
        strData = "保証番号,行番号,顧客名,住所,電話番号,購入日,申込日,購入価格,保険料,ﾒｰｶｰ名,型番,品種,品種区分"
        swFile.WriteLine(strData)

        If GRP <> "C" Then
            DtView1 = New DataView(DsExport.Tables("CSV"), "GRP = '" & GRP & "'", "保証番号,行番号", DataViewRowState.CurrentRows)
        Else
            DtView1 = New DataView(DsExport.Tables("CSV"), "GRP = '" & GRP & "' OR GRP IS NULL", "保証番号,行番号", DataViewRowState.CurrentRows)
        End If

        waitDlg.MainMsg = "グループ" & GRP & "　CSV出力中"           ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = DtView1.Count     ' 全体の処理件数を設定
        Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

        If DtView1.Count <> 0 Then
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = (CType(Fix((i + 1) * 100 / DtView1.Count), Integer)).ToString() & "%　（" & i + 1 & " / " & DtView1.Count & " 件）"
                waitDlg.Text = "実行中・・・" & (CType(Fix((i + 1) * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                WK_str = DtView1(i)("顧客名")
                strData = strData & Chr(34) & WK_str.Replace(Chr(34), "ﾞ") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("住所") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                strData = strData & DtView1(i)("購入日") & ","
                strData = strData & DtView1(i)("申込日") & ","
                strData = strData & DtView1(i)("購入価格") & ","
                If DtView1(i)("申込日") < "2012/02/01" Then
                    If IsDBNull(DtView1(i)("GRP")) Then
                        strData = strData & RoundDOWN(DtView1(i)("購入価格") * 0.2176 / 100, 0) & ","
                    Else
                        If DtView1(i)("GRP") <> "A" Then
                            strData = strData & RoundDOWN(DtView1(i)("購入価格") * 0.22 / 100, 0) & ","
                        Else
                            strData = strData & RoundDOWN(DtView1(i)("購入価格") * 0.2176 / 100, 0) & ","
                        End If
                    End If
                Else
                    strData = strData & "0,"
                End If
                strData = strData & Chr(34) & DtView1(i)("ﾒｰｶｰ名（仮名）") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("item_cat_code") & Chr(34) & ","
                strData = strData & Chr(34) & DtView1(i)("GRP") & Chr(34)

                swFile.WriteLine(strData)
            Next
        End If
        swFile.Close()  'ファイルを閉じる

    End Sub

    '**********************************************************************
    '** 加入データ_法人(xls)
    '**********************************************************************
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            Me.Enabled = False                      ' オーナーのフォームを無効にする

            waitDlg = New WaitDialog                ' 進行状況ダイアログ
            waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = "加入者データ(朝日火災)"    ' 処理の概要を表示
            waitDlg.ProgressMsg = "データ抽出中"    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0               ' 最初の件数を設定
            waitDlg.Show()                          ' 進行状況ダイアログを表示する
            Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

            DsExport.Clear()
            strSQL = "SELECT RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no as 行"
            strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS 顧客名"
            strSQL += ", Wrn_sub.cat_name"
            strSQL += ", Wrn_sub.prch_date"
            strSQL += ", (Wrn_sub.prch_price + Wrn_sub.prch_tax) AS prch_incld"
            strSQL += " FROM Wrn_mtr INNER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
            strSQL += " WHERE (Wrn_sub.close_cont_flg = 'A')"
            strSQL += " AND (Wrn_sub.corp_flg = '1')"
            strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1

            Try
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                r = DaList1.Fill(DsExport, "XLS")
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Activate()
                waitDlg.Close()
                Me.Enabled = True
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            DtView1 = New DataView(DsExport.Tables("XLS"), "", "保証番号,行", DataViewRowState.CurrentRows)

            waitDlg.MainMsg = "Excel作成中"             ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object

            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add

            oSheet = oBook.Worksheets(1)
            oSheet.Range("A1").Value = "保証番号"
            oSheet.Range("B1").Value = "行"
            oSheet.Range("C1").Value = "顧客法人名"
            oSheet.Range("D1").Value = "対象商品"
            oSheet.Range("E1").Value = "購入年月"
            oSheet.Range("F1").Value = "保障責任開始日"
            oSheet.Range("G1").Value = "保険金額"
            oSheet.Range("H1").Value = "支払保険料"

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める
                oSheet.Range("A" & i + 2).Value = Chr(39) & DtView1(i)("保証番号").ToString
                oSheet.Range("B" & i + 2).Value = Chr(39) & DtView1(i)("行").ToString
                oSheet.Range("C" & i + 2).Value = DtView1(i)("顧客名").ToString
                oSheet.Range("D" & i + 2).Value = DtView1(i)("cat_name").ToString
                oSheet.Range("E" & i + 2).Value = DtView1(i)("prch_date")
                oSheet.Range("F" & i + 2).Value = DtView1(i)("prch_date")
                oSheet.Range("G" & i + 2).Value = DtView1(i)("prch_incld")
                oSheet.Range("H" & i + 2).Value = RoundDOWN(DtView1(i)("prch_incld") * 0.22 / 100, 0)
            Next
            oSheet.Range("A1:H" & Line).EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

            Me.Activate()
            waitDlg.Close()                 '進行状況ダイアログを閉じる

            '［名前を付けて保存］ダイアログボックスを表示
            SaveFileDialog1.FileName = "Wrn_Biz.xls"
            SaveFileDialog1.Filter = "Excelファイル|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
            Try
                oBook.SaveAs(SaveFileDialog1.FileName)
            Catch ex As System.Exception
                GoTo end_prc
            End Try
end_prc:
            Me.Enabled = True

            ' 終了処理　
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
            GC.Collect()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 店舗別明細_法人(xls)
    '**********************************************************************
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            Me.Enabled = False                      ' オーナーのフォームを無効にする

            waitDlg = New WaitDialog                ' 進行状況ダイアログ
            waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = "店舗別明細_法人"    ' 処理の概要を表示
            waitDlg.ProgressMsg = "データ抽出中"    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0               ' 最初の件数を設定
            waitDlg.Show()                          ' 進行状況ダイアログを表示する
            Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code, Wrn_sub.prch_price, Wrn_sub.prch_tax, Wrn_sub.wrn_fee"
            strSQL += ", ROUND((Wrn_sub.prch_price + Wrn_sub.prch_tax) * 0.022 / 100, 0, 1) AS pay_wrn_fee"
            strSQL += " FROM Wrn_mtr LEFT OUTER JOIN Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
            strSQL += " WHERE (Wrn_sub.corp_flg = '1')"
            strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
            strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            DaList1.Fill(DsExport, "WK_XLS")
            DB_CLOSE()

            DtView1 = New DataView(DsExport.Tables("WK_XLS"), "", "shop_code", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Activate()
                waitDlg.Close()
                Me.Enabled = True
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            strSQL = "SELECT '' AS 店舗コード, '' AS [店舗名(ｶﾅ)], 0 AS 購入価格, 0 AS 販売保証料"
            strSQL += ", 0 AS 支払保険料, 0 AS 件数, 0 AS 事務手数料, 0 AS 事務手数料_税込"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsExport, "XLS")
            DsExport.Tables("XLS").Clear()

            strSQL = "SELECT shop_code, [店舗名(ｶﾅ)] FROM Shop_mtr"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            DaList1.Fill(DsExport, "Shop_mtr")
            DB_CLOSE()

            BR_Shop = Trim(DtView1(0)("shop_code"))
            For j = 1 To 6
                sum(j) = 0
            Next

            For i = 0 To DtView1.Count - 1
                If BR_Shop <> Trim(DtView1(i)("shop_code")) Then

                    dttable = DsExport.Tables("XLS")
                    dtRow = dttable.NewRow
                    dtRow("店舗コード") = BR_Shop
                    WK_DtView1 = New DataView(DsExport.Tables("Shop_mtr"), "shop_code ='" & BR_Shop & "'", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then dtRow("店舗名(ｶﾅ)") = WK_DtView1(0)("店舗名(ｶﾅ)") Else dtRow("店舗名(ｶﾅ)") = Nothing
                    dtRow("購入価格") = sum(1)
                    dtRow("販売保証料") = sum(2)
                    dtRow("支払保険料") = sum(3)
                    dtRow("件数") = sum(4)
                    dtRow("事務手数料") = sum(5)
                    dtRow("事務手数料_税込") = sum(6)
                    dttable.Rows.Add(dtRow)

                    For j = 1 To 6
                        sum(j) = 0
                    Next
                End If

                BR_Shop = Trim(DtView1(i)("shop_code"))
                sum(1) = sum(1) + DtView1(i)("prch_price")
                sum(2) = sum(2) + DtView1(i)("wrn_fee")
                sum(3) = sum(3) + DtView1(i)("pay_wrn_fee")
                sum(4) = sum(4) + 1
                If Date1.Text < "2009/06" Then
                    sum(5) = sum(4) * 60
                    sum(6) = sum(4) * 63
                Else
                    sum(5) = sum(4) * 50
                    sum(6) = sum(4) * 52
                End If
            Next

            dttable = DsExport.Tables("XLS")
            dtRow = dttable.NewRow
            dtRow("店舗コード") = BR_Shop
            WK_DtView1 = New DataView(DsExport.Tables("Shop_mtr"), "shop_code ='" & BR_Shop & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then dtRow("店舗名(ｶﾅ)") = WK_DtView1(0)("店舗名(ｶﾅ)") Else dtRow("店舗名(ｶﾅ)") = Nothing
            dtRow("購入価格") = sum(1)
            dtRow("販売保証料") = sum(2)
            dtRow("支払保険料") = sum(3)
            dtRow("件数") = sum(4)
            dtRow("事務手数料") = sum(5)
            dtRow("事務手数料_税込") = sum(6)
            dttable.Rows.Add(dtRow)

            Dim dttbl As DataTable
            dttbl = DsExport.Tables("XLS")

            waitDlg.ProgressMax = dttbl.Rows.Count - 1
            waitDlg.Show()
            waitDlg.MainMsg = "Excelデータを出力しています。"

            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object

            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add

            oSheet = oBook.Worksheets(1)
            oSheet.Range("A1").Value = "店舗コード"
            oSheet.Range("B1").Value = "店舗名(ｶﾅ)"
            oSheet.Range("C1").Value = "件数"
            oSheet.Range("D1").Value = "購入価格"
            oSheet.Range("E1").Value = "販売保証料"
            oSheet.Range("F1").Value = "支払保険料"
            oSheet.Range("G1").Value = "事務手数料"
            oSheet.Range("H1").Value = "事務手数料(税込)"

            waitDlg.MainMsg = "Excel作成中"             ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = dttbl.Rows.Count      ' 全体の処理件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            For i = 0 To dttbl.Rows.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / dttbl.Rows.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(dttbl.Rows.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める
                oSheet.Range("A" & i + 2).Value = Chr(39) & dttbl.Rows(i)("店舗コード").ToString
                oSheet.Range("B" & i + 2).Value = Chr(39) & dttbl.Rows(i)("店舗名(ｶﾅ)").ToString
                oSheet.Range("C" & i + 2).Value = dttbl.Rows(i)("件数").ToString
                oSheet.Range("D" & i + 2).Value = Format(dttbl.Rows(i)("購入価格"), "##0,00").ToString
                oSheet.Range("E" & i + 2).Value = Format(dttbl.Rows(i)("販売保証料"), "##0,00").ToString
                oSheet.Range("F" & i + 2).Value = Format(dttbl.Rows(i)("支払保険料"), "##0,00").ToString
                oSheet.Range("G" & i + 2).Value = Format(dttbl.Rows(i)("事務手数料"), "##0,00").ToString
                oSheet.Range("H" & i + 2).Value = Format(dttbl.Rows(i)("事務手数料_税込"), "##0,00").ToString
            Next
            oSheet.Range("A1:H" & Line).EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            SaveFileDialog1.FileName = "Shop_Biz.xls"
            SaveFileDialog1.Filter = "Excelファイル|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
            Try
                oBook.SaveAs(SaveFileDialog1.FileName)
            Catch ex As System.Exception
                GoTo end_prc
            End Try
end_prc:
            Me.Enabled = True               'オーナーのフォームを有効にする

            ' 終了処理　
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
            GC.Collect()

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 加入データ_法人_外商部(CSV)
    '**********************************************************************
    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS 顧客名"
            strSQL += ", Wrn_mtr.zip_code AS 郵便番号"
            strSQL += ", Pref_mtr.pref_kana AS 住所１"
            strSQL += ", RTRIM(Wrn_mtr.city_name) AS 住所２"
            strSQL += ", RTRIM(Wrn_mtr.adrs2) + RTRIM(Wrn_mtr.adrs1) AS 住所３"
            strSQL += ", RTRIM(Wrn_mtr.srch_phn) AS 電話番号"
            strSQL += ", '110' AS CID"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_date AS 購入日"
            strSQL += ", Wrn_sub.prch_price AS [購入価格（税抜）]"
            strSQL += ", Wrn_sub.prch_price + Wrn_sub.prch_tax AS [購入価格（税込）]"
            strSQL += ", Wrn_sub.prch_tax AS 消費税"
            strSQL += ", Wrn_sub.prch_date AS 保証開始日"
            strSQL += ", RTRIM(Wrn_sub.brnd_name) AS [メーカー名]"
            strSQL += ", RTRIM(Wrn_sub.model_name) AS 型番"
            strSQL += ", Wrn_sub.pos_code AS [予備・備考（POS番号）]"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", Wrn_sub.corp_flg"
            strSQL += ", Wrn_sub.wrn_prod AS wrn_prod_old"
            strSQL += ", Wrn_sub_2.wrn_prod2 AS wrn_prod"
            strSQL += " FROM Wrn_sub_2 RIGHT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_sub_2.ordr_no = Wrn_sub.ordr_no AND Wrn_sub_2.line_no = Wrn_sub.line_no AND"
            strSQL += " Wrn_sub_2.seq = Wrn_sub.seq RIGHT OUTER JOIN"
            strSQL += " Pref_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Pref_mtr.pref_code = Wrn_mtr.pref_code LEFT OUTER JOIN"
            strSQL += " Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code ON Wrn_sub.ordr_no = Wrn_mtr.ordr_no"
            strSQL += " WHERE Wrn_sub.corp_flg = '1'"
            strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsExport, "CSV")
            DB_CLOSE()

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                'ファイルに出力
                sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

                waitDlg = New WaitDialog
                waitDlg.Owner = Me
                waitDlg.ProgressMax = DtView1.Count - 1
                waitDlg.ProgressMin = 0
                waitDlg.ProgressStep = 1
                waitDlg.ProgressValue = 0
                Me.Enabled = False
                waitDlg.Show()
                waitDlg.MainMsg = "CSVデータを出力しています。"

                'sbuf = "店舗コード,店舗名,顧客名,郵便番号,住所１,住所２,住所３,電話番号,CID,保証番号,行番号,購入日,購入価格（税抜）"
                'sbuf = sbuf & ",消費税,購入価格（税込）,保証開始日,満期日,メーカー名,型番,予備・備考（POS番号）,ステータス"
                'sw.WriteLine(sbuf)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressValue = i
                    Application.DoEvents()

                    If IsDBNull(DtView1(i)("wrn_prod")) Then
                        If IsDBNull(DtView1(i)("wrn_prod_old")) Then
                            DtView1(i)("wrn_prod") = "1"
                        Else
                            DtView1(i)("wrn_prod") = DtView1(i)("wrn_prod_old")
                        End If
                    End If

                    sbuf = DtView1(i)("店舗コード") & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("店舗名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("顧客名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("郵便番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所１") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所２") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所３") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("CID") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                    sbuf = sbuf & DtView1(i)("購入日") & ","
                    sbuf = sbuf & DtView1(i)("購入価格（税抜）") & ","
                    sbuf = sbuf & DtView1(i)("消費税") & ","
                    sbuf = sbuf & DtView1(i)("購入価格（税込）") & ","
                    sbuf = sbuf & DtView1(i)("保証開始日") & ","
                    sbuf = sbuf & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, DtView1(i)("wrn_prod"), DtView1(i)("購入日"))) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("メーカー名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("予備・備考（POS番号）") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("ステータス") & Chr(34) & ","
                    If DtView1(i)("corp_flg") = "0" Then
                        sbuf = sbuf & "2.6,"
                    ElseIf DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & "0.22,"
                    End If
                    If DtView1(i)("corp_flg") = "0" Then
                        sbuf = sbuf & Chr(34) & "0100" & Chr(34)
                    ElseIf DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & Chr(34) & "0200" & Chr(34)
                    End If
                    sw.WriteLine(sbuf)
                Next
            End If
            sw.Close()

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            SaveFileDialog1.FileName = "Wrn_Data_Biz.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 加入者データ
    '**********************************************************************
    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS 顧客名"
            strSQL += ", Wrn_mtr.zip_code AS 郵便番号"
            strSQL += ", Pref_mtr.pref_kana AS 住所１"
            strSQL += ", RTRIM(Wrn_mtr.city_name) AS 住所２"
            strSQL += ", RTRIM(Wrn_mtr.adrs2) + RTRIM(Wrn_mtr.adrs1) AS 住所３"
            strSQL += ", RTRIM(Wrn_mtr.srch_phn) AS 電話番号"
            strSQL += ", '110' AS CID"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_date AS 購入日"
            strSQL += ", Wrn_sub.prch_price AS [購入価格（税抜）]"
            strSQL += ", Wrn_sub.prch_date AS 保証開始日"
            strSQL += ", RTRIM(Wrn_sub.brnd_name) AS [メーカー名]"
            strSQL += ", RTRIM(Wrn_sub.model_name) AS 型番"
            strSQL += ", Wrn_sub.pos_code AS [予備・備考（POS番号）]"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", Wrn_sub.item_cat_code AS 品種"
            strSQL += ", Wrn_sub.corp_flg"
            strSQL += ", Wrn_mtr.cust_no"
            strSQL += ", Wrn_sub.wrn_prod AS wrn_prod_old"
            strSQL += ", Wrn_sub_2.wrn_prod2 AS wrn_prod"
            strSQL += " FROM Wrn_sub_2 RIGHT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_sub_2.ordr_no = Wrn_sub.ordr_no AND Wrn_sub_2.line_no = Wrn_sub.line_no AND"
            strSQL += " Wrn_sub_2.seq = Wrn_sub.seq RIGHT OUTER JOIN"
            strSQL += " Pref_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Pref_mtr.pref_code = Wrn_mtr.pref_code LEFT OUTER JOIN"
            strSQL += " Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code ON Wrn_sub.ordr_no = Wrn_mtr.ordr_no"
            strSQL += " WHERE (Wrn_sub.corp_flg = '0' OR Wrn_sub.corp_flg = '1')"

            If Label4.Text = "0" Then
                strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " AND (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsExport, "CSV")
            DB_CLOSE()

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                'ファイルに出力
                sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

                waitDlg = New WaitDialog
                waitDlg.Owner = Me
                waitDlg.ProgressMax = DtView1.Count - 1
                waitDlg.ProgressMin = 0
                waitDlg.ProgressStep = 1
                waitDlg.ProgressValue = 0
                Me.Enabled = False
                waitDlg.Show()
                waitDlg.MainMsg = "CSVデータを出力しています。"

                'sbuf = "店舗コード,店舗名,顧客名,郵便番号,住所１,住所２,住所３,電話番号,CID,保証番号,行番号,購入日,購入価格（税抜）,保証開始日,満期日,メーカー名,型番,予備・備考（POS番号）,ステータス,品種,保険料率,データ区分,顧客絶対番号,予備"
                'sw.WriteLine(sbuf)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressValue = i
                    Application.DoEvents()

                    If IsDBNull(DtView1(i)("wrn_prod")) Then
                        If IsDBNull(DtView1(i)("wrn_prod_old")) Then
                            DtView1(i)("wrn_prod") = "1"
                        Else
                            DtView1(i)("wrn_prod") = DtView1(i)("wrn_prod_old")
                        End If
                    End If

                    sbuf = DtView1(i)("店舗コード") & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("店舗名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("顧客名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("郵便番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所１") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所２") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所３") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("CID") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                    sbuf = sbuf & DtView1(i)("購入日") & ","
                    sbuf = sbuf & DtView1(i)("購入価格（税抜）") & ","
                    sbuf = sbuf & DtView1(i)("保証開始日") & ","
                    sbuf = sbuf & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, DtView1(i)("wrn_prod"), DtView1(i)("購入日"))) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("メーカー名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("予備・備考（POS番号）") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("ステータス") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("品種") & Chr(34) & ","
                    If DtView1(i)("corp_flg") = "0" Then
                        sbuf = sbuf & "2.6,"
                    ElseIf DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & "4.5,"
                    End If
                    If DtView1(i)("corp_flg") = "0" Then
                        sbuf = sbuf & Chr(34) & "0100" & Chr(34)
                    ElseIf DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & Chr(34) & "0200" & Chr(34)
                    End If
                    If P_To_Date > "2012/08/31" Then
                        sbuf = sbuf & "," & Chr(34) & DtView1(i)("cust_no") & Chr(34)
                    End If
                    sw.WriteLine(sbuf)
                Next
            End If
            sw.Close()

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "Wrn_Data.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 請求明細
    '**********************************************************************
    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_price, Wrn_sub.prch_tax, Wrn_sub.wrn_fee"
            strSQL += ", Wrn_sub.wrn_fee AS 保証料"
            If Date1.Text < "2009/06" Then
                strSQL += ", 60 AS [事務手数料（税抜）]"
            Else
                strSQL += ", 50 AS [事務手数料（税抜）]"
            End If
            strSQL += ", Wrn_sub.prch_date AS 申込日"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", '" & P_To_Date & "' AS 請求日"
            strSQL += ", Wrn_sub.corp_flg, Wrn_sub.item_cat_code"
            strSQL += " FROM Shop_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Shop_mtr.shop_code = Wrn_mtr.shop_code LEFT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
            strSQL += " WHERE (Wrn_sub.corp_flg = '0' OR Wrn_sub.corp_flg = '1')"
            If Label4.Text = "0" Then
                strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " AND (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
            End If

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsExport, "CSV")
            DB_CLOSE()

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                'ファイルに出力
                sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

                waitDlg = New WaitDialog
                waitDlg.Owner = Me
                waitDlg.ProgressMax = DtView1.Count - 1
                waitDlg.ProgressMin = 0
                waitDlg.ProgressStep = 1
                waitDlg.ProgressValue = 0
                Me.Enabled = False
                waitDlg.Show()
                waitDlg.MainMsg = "CSVデータを出力しています。"

                'sbuf = "店舗コード,店舗名,保証番号,行番号,購入価格,保証料（税込）,保険料,事務手数料（税抜）,申込日,ステータス,請求日,,品種"
                'sw.WriteLine(sbuf)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressValue = i
                    Application.DoEvents()
                    sbuf = DtView1(i)("店舗コード")
                    sbuf = sbuf & "," & Chr(34) & DtView1(i)("店舗名") & Chr(34)
                    sbuf = sbuf & "," & Chr(34) & DtView1(i)("保証番号") & Chr(34)
                    sbuf = sbuf & "," & Chr(34) & DtView1(i)("行番号") & Chr(34)
                    '購入価格(個人:税別、法人:税込)
                    If DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & "," & DtView1(i)("prch_price") + DtView1(i)("prch_tax")
                    Else
                        sbuf = sbuf & "," & DtView1(i)("prch_price")
                    End If
                    If DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & "," & Round(CInt(DtView1(i)("wrn_fee")) * 1.05, 0)
                    Else
                        sbuf = sbuf & "," & CInt(DtView1(i)("wrn_fee"))
                    End If
                    '保険料
                    If DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & "," & RoundDOWN((DtView1(i)("prch_price") + DtView1(i)("prch_tax")) * 0.045, 0)
                    Else
                        sbuf = sbuf & "," & Round(DtView1(i)("prch_price") * 0.026, 0)
                    End If
                    sbuf = sbuf & "," & DtView1(i)("事務手数料（税抜）")
                    sbuf = sbuf & "," & DtView1(i)("申込日")
                    sbuf = sbuf & "," & Chr(34) & DtView1(i)("ステータス") & Chr(34)
                    sbuf = sbuf & "," & DtView1(i)("請求日")
                    Select Case DtView1(i)("corp_flg")
                        Case Is = "0"
                            sbuf = sbuf & "," & Chr(34) & "0100" & Chr(34)
                        Case Is = "1"
                            sbuf = sbuf & "," & Chr(34) & "0200" & Chr(34)
                        Case Is = "4"
                            sbuf = sbuf & "," & Chr(34) & "0400" & Chr(34)
                        Case Is = "5"
                            sbuf = sbuf & "," & Chr(34) & "0500" & Chr(34)
                        Case Else
                            sbuf = sbuf & "," & Chr(34) & "0000" & Chr(34)
                    End Select
                    If Date1.Text > "2007/10" Then
                        sbuf = sbuf & "," & Chr(34) & DtView1(i)("item_cat_code") & Chr(34)
                    End If
                    sw.WriteLine(sbuf)
                Next
            End If
            sw.Close()

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "Invc.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 請求ｷｬﾝｾﾙ明細
    '**********************************************************************
    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_price AS [購入価格（税抜）]"
            strSQL += ", Wrn_sub.wrn_fee AS [保証料（税込）]"
            If Date1.Text < "2009/06" Then
                strSQL += ", 60 AS [事務手数料（税抜）]"
            Else
                strSQL += ", 50 AS [事務手数料（税抜）]"
            End If
            strSQL += ", Wrn_sub.prch_date AS 申込日"
            strSQL += ", Wrn_sub.corp_flg"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", DATEADD(d, - 1, DATEADD(m, 2, CONVERT(datetime, DATENAME(yy, Wrn_sub.op_date) + '/' + DATENAME(mm, Wrn_sub.op_date) + '/01'))) AS 請求日"
            strSQL += " FROM Shop_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Shop_mtr.shop_code = Wrn_mtr.shop_code LEFT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
            strSQL += " WHERE (Wrn_mtr.entry_flg = '0')"
            strSQL += " AND (Wrn_sub.close_cont_flg = 'C')"
            strSQL += " AND (Wrn_sub.op_date < '" & P_From_Date & "')"
            strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"

            Try
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                r = DaList1.Fill(DsExport, "CSV")
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                'ファイルに出力
                sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

                waitDlg = New WaitDialog
                waitDlg.Owner = Me
                waitDlg.ProgressMax = DtView1.Count - 1
                waitDlg.ProgressMin = 0
                waitDlg.ProgressStep = 1
                waitDlg.ProgressValue = 0
                Me.Enabled = False
                waitDlg.Show()
                waitDlg.MainMsg = "CSVデータを出力しています。"

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressValue = i
                    Application.DoEvents()
                    sbuf = DtView1(i)("店舗コード") & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("店舗名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                    sbuf = sbuf & DtView1(i)("購入価格（税抜）") & ","
                    sbuf = sbuf & DtView1(i)("保証料（税込）") & ","
                    '保険料
                    If DtView1(i)("corp_flg") = "0" Then
                        sbuf = sbuf & Round(DtView1(i)("購入価格（税抜）") * 0.026, 0) & ","
                    ElseIf DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & RoundDOWN(DtView1(i)("購入価格（税抜）") * 0.045, 0) & ","
                    End If
                    sbuf = sbuf & DtView1(i)("事務手数料（税抜）") & ","
                    sbuf = sbuf & DtView1(i)("申込日") & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("ステータス") & Chr(34) & ","
                    sbuf = sbuf & DtView1(i)("請求日") & ","
                    If DtView1(i)("corp_flg") = "0" Then
                        sbuf = sbuf & Chr(34) & "0100" & Chr(34)
                    ElseIf DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & Chr(34) & "0200" & Chr(34)
                    End If
                    sw.WriteLine(sbuf)
                Next
            End If
            sw.Close()

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "AC.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '店舗計出力
    Sub Shop_TTL2()
        Line = Line + 1
        WK_DtView1 = New DataView(DsExport.Tables("Shop_mtr"), "shop_code = '" & BR_Shop & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            WK_Shop_Name = Trim(WK_DtView1(0)("店舗名(ｶﾅ)"))
        Else
            WK_Shop_Name = Nothing
        End If
    End Sub

    '**********************************************************************
    '** 店舗別ｷｬﾝｾﾙ明細(xls)
    '**********************************************************************


    '**********************************************************************
    '** 店舗別請求ｷｬﾝｾﾙ明細(xls)
    '**********************************************************************
    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            strSQL = "SELECT Wrn_mtr.shop_code AS 店舗コード, Shop_mtr.[店舗名(ｶﾅ)], COUNT(*) AS 件数"
            If Date1.Text < "2009/06" Then
                strSQL += ", COUNT(*) * 60 AS 事務手数料"
            Else
                strSQL += ", COUNT(*) * 50 AS 事務手数料"
            End If
            strSQL += " FROM Wrn_mtr LEFT OUTER JOIN"
            strSQL += " Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code LEFT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
            strSQL += " WHERE (Wrn_sub.close_cont_flg = 'C')"
            strSQL += " AND (Wrn_sub.op_date < '" & P_From_Date & "')"
            strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"

            strSQL += " GROUP BY Wrn_mtr.shop_code, Shop_mtr.[店舗名(ｶﾅ)]"
            strSQL += " ORDER BY Wrn_mtr.shop_code"
            DsExport.Clear()
            Try
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                r = DaList1.Fill(DsExport, "XLS")
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try

            Dim dttbl As DataTable

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            dttbl = DsExport.Tables("XLS")

            waitDlg = New WaitDialog
            waitDlg.Owner = Me
            waitDlg.ProgressMax = dttbl.Rows.Count - 1
            waitDlg.ProgressMin = 0
            waitDlg.ProgressStep = 1
            waitDlg.ProgressValue = 0
            Me.Enabled = False
            waitDlg.Show()
            waitDlg.MainMsg = "Excelデータを出力しています。"

            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object

            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add

            oSheet = oBook.Worksheets(1)
            oSheet.Range("A1").Value = "店舗コード"
            oSheet.Range("B1").Value = "店舗名(ｶﾅ)"
            oSheet.Range("C1").Value = "件数"
            oSheet.Range("D1").Value = "事務手数料"

            For i = 0 To dttbl.Rows.Count - 1
                waitDlg.ProgressValue = i
                Application.DoEvents()
                oSheet.Range("A" & i + 2).Value = Chr(39) & dttbl.Rows(i)("店舗コード").ToString
                oSheet.Range("B" & i + 2).Value = dttbl.Rows(i)("店舗名(ｶﾅ)").ToString
                oSheet.Range("C" & i + 2).Value = dttbl.Rows(i)("件数").ToString
                oSheet.Range("D" & i + 2).Value = Format(dttbl.Rows(i)("事務手数料"), "##0,00").ToString
            Next

            oSheet.Range("A1:D" & Line).EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "Shop_AC.xls"
            SaveFileDialog1.Filter = "Excelファイル|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
            Try
                'xlBook.SaveAs(SaveFileDialog1.FileName)
                oBook.SaveAs(SaveFileDialog1.FileName)
            Catch ex As System.Exception
                GoTo end_prc
            End Try
end_prc:
            Me.Enabled = True

            ' 終了処理　
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
            GC.Collect()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 加入者データ(KAKOI)
    '**********************************************************************
    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS 顧客名"
            strSQL += ", Wrn_mtr.zip_code AS 郵便番号"
            strSQL += ", Pref_mtr.pref_kana AS 住所１"
            strSQL += ", RTRIM(Wrn_mtr.city_name) AS 住所２"
            strSQL += ", RTRIM(Wrn_mtr.adrs2) + RTRIM(Wrn_mtr.adrs1) AS 住所３"
            strSQL += ", RTRIM(Wrn_mtr.srch_phn) AS 電話番号"
            strSQL += ", '110' AS CID"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_date AS 購入日"
            strSQL += ", Wrn_sub.prch_price AS [購入価格（税抜）]"
            strSQL += ", Wrn_sub.prch_date AS 保証開始日"
            strSQL += ", RTRIM(Wrn_sub.brnd_name) AS [メーカー名]"
            strSQL += ", RTRIM(Wrn_sub.model_name) AS 型番"
            strSQL += ", Wrn_sub.pos_code AS [予備・備考（POS番号）]"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", Wrn_sub.corp_flg"
            strSQL += ", Wrn_mtr.cust_no"
            strSQL += ", Wrn_sub.wrn_prod AS wrn_prod_old"
            strSQL += ", Wrn_sub_2.wrn_prod2 AS wrn_prod"
            strSQL += " FROM Wrn_sub_2 RIGHT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_sub_2.ordr_no = Wrn_sub.ordr_no AND Wrn_sub_2.line_no = Wrn_sub.line_no AND"
            strSQL += " Wrn_sub_2.seq = Wrn_sub.seq RIGHT OUTER JOIN"
            strSQL += " Shop_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Shop_mtr.BY_cls = Wrn_mtr.BY_cls AND Shop_mtr.shop_code = Wrn_mtr.shop_code LEFT OUTER JOIN"
            strSQL += " Pref_mtr ON Wrn_mtr.pref_code = Pref_mtr.pref_code ON Wrn_sub.ordr_no = Wrn_mtr.ordr_no"
            strSQL += " WHERE (Shop_mtr.会社GRP = 203)"
            If Label4.Text = "0" Then
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
                strSQL += " AND (fin_date < CONVERT(DATETIME, '" & P_nx_Date & "', 102))"
            End If

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsExport, "CSV")
            DB_CLOSE()

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                'ファイルに出力
                sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

                waitDlg = New WaitDialog
                waitDlg.Owner = Me
                waitDlg.ProgressMax = DtView1.Count - 1
                waitDlg.ProgressMin = 0
                waitDlg.ProgressStep = 1
                waitDlg.ProgressValue = 0
                Me.Enabled = False
                waitDlg.Show()
                waitDlg.MainMsg = "CSVデータを出力しています。"

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressValue = i
                    Application.DoEvents()

                    If IsDBNull(DtView1(i)("wrn_prod")) Then
                        If IsDBNull(DtView1(i)("wrn_prod_old")) Then
                            DtView1(i)("wrn_prod") = "1"
                        Else
                            DtView1(i)("wrn_prod") = DtView1(i)("wrn_prod_old")
                        End If
                    End If

                    sbuf = DtView1(i)("店舗コード") & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("店舗名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("顧客名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("郵便番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所１") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所２") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所３") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("CID") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                    sbuf = sbuf & DtView1(i)("購入日") & ","
                    sbuf = sbuf & DtView1(i)("購入価格（税抜）") & ","
                    sbuf = sbuf & DtView1(i)("保証開始日") & ","
                    sbuf = sbuf & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, DtView1(i)("wrn_prod"), DtView1(i)("購入日"))) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("メーカー名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("予備・備考（POS番号）") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("ステータス") & Chr(34) & ","
                    If DtView1(i)("corp_flg") = "0" Then
                        sbuf = sbuf & "2.6,"
                    ElseIf DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & "4.5,"
                    End If
                    If DtView1(i)("corp_flg") = "0" Then
                        sbuf = sbuf & Chr(34) & "0100" & Chr(34)
                    ElseIf DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & Chr(34) & "0200" & Chr(34)
                    End If
                    If P_To_Date > "2012/08/31" Then
                        sbuf = sbuf & "," & Chr(34) & DtView1(i)("cust_no") & Chr(34)
                    End If
                    sw.WriteLine(sbuf)
                Next
            End If
            sw.Close()

            Me.Activate()
            waitDlg.Close()                 '進行状況ダイアログを閉じる

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "Wrn_Data_kakoi.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 請求明細(KAKOI)
    '**********************************************************************
    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button52.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_price"
            strSQL += ", Wrn_sub.wrn_fee"
            strSQL += ", 110 AS [事務手数料（税抜）]"
            strSQL += ", Wrn_sub.prch_date AS 申込日"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", DATEADD(d, - 1, DATEADD(m, 2, CONVERT(datetime, DATENAME(yy, Wrn_sub.op_date) + '/' + DATENAME(mm, Wrn_sub.op_date) + '/01'))) AS 請求日"
            strSQL += ", Wrn_sub.corp_flg, Wrn_sub.item_cat_code"
            strSQL += " FROM Shop_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Shop_mtr.BY_cls = Wrn_mtr.BY_cls AND Shop_mtr.shop_code = Wrn_mtr.shop_code LEFT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
            strSQL += " WHERE (Shop_mtr.会社GRP = 203)"
            If Label4.Text = "0" Then
                strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " AND (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
                strSQL += " AND (Wrn_sub.fin_date < CONVERT(DATETIME, '" & P_nx_Date & "', 102))"
            End If

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsExport, "CSV")
            DB_CLOSE()
            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            'ファイルに出力
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

            waitDlg = New WaitDialog
            waitDlg.Owner = Me
            waitDlg.ProgressMax = DtView1.Count - 1
            waitDlg.ProgressMin = 0
            waitDlg.ProgressStep = 1
            waitDlg.ProgressValue = 0
            Me.Enabled = False
            waitDlg.Show()
            waitDlg.MainMsg = "CSVデータを出力しています。"

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressValue = i
                Application.DoEvents()
                sbuf = DtView1(i)("店舗コード") & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("店舗名") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                sbuf = sbuf & DtView1(i)("prch_price") & ","
                sbuf = sbuf & DtView1(i)("wrn_fee") & ","
                '保険料
                If DtView1(i)("corp_flg") = "1" Then
                    sbuf = sbuf & RoundDOWN(DtView1(i)("prch_price") * 0.045, 0) & ","
                Else
                    sbuf = sbuf & Round(DtView1(i)("prch_price") * 0.026, 0) & ","
                End If
                sbuf = sbuf & DtView1(i)("事務手数料（税抜）") & ","
                sbuf = sbuf & DtView1(i)("申込日") & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("ステータス") & Chr(34) & ","
                sbuf = sbuf & DtView1(i)("請求日") & ","
                If DtView1(i)("corp_flg") = "1" Then
                    sbuf = sbuf & Chr(34) & "0200" & Chr(34) & ","
                Else
                    sbuf = sbuf & Chr(34) & "0100" & Chr(34) & ","
                End If
                If Date1.Text > "2007/10" Then
                    sbuf = sbuf & Chr(34) & DtView1(i)("item_cat_code") & Chr(34)
                End If
                sw.WriteLine(sbuf)
            Next
            sw.Close()

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "invc_kakoi.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 請求ｷｬﾝｾﾙ明細(KAKOI)
    '**********************************************************************
    Private Sub Button53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button53.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_price AS [購入価格（税抜）]"
            strSQL += ", Wrn_sub.wrn_fee AS [保証料（税込）]"
            strSQL += ", ROUND(Wrn_sub.prch_price * 0.026, 0) AS 保険料"
            If Date1.Text < "2009/06" Then
                strSQL += ", 60 AS [事務手数料（税抜）]"
            Else
                strSQL += ", 50 AS [事務手数料（税抜）]"
            End If
            strSQL += ", Wrn_sub.prch_date AS 申込日"
            strSQL += ", Wrn_sub.corp_flg"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", DATEADD(d, - 1, DATEADD(m, 2, CONVERT(datetime, DATENAME(yy, Wrn_sub.op_date) + '/' + DATENAME(mm, Wrn_sub.op_date) + '/01'))) AS 請求日"
            strSQL += " FROM Shop_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Shop_mtr.shop_code = Wrn_mtr.shop_code LEFT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
            strSQL += " WHERE (Shop_mtr.会社GRP = 203)"
            strSQL += " AND (Wrn_mtr.entry_flg = '0')"
            strSQL += " AND (Wrn_sub.close_cont_flg = 'C')"
            strSQL += " AND (Wrn_sub.op_date < '" & P_From_Date & "')"
            strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsExport, "CSV")
            DB_CLOSE()

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            'ファイルに出力
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

            waitDlg = New WaitDialog
            waitDlg.Owner = Me
            waitDlg.ProgressMax = DtView1.Count - 1
            waitDlg.ProgressMin = 0
            waitDlg.ProgressStep = 1
            waitDlg.ProgressValue = 0
            Me.Enabled = False
            waitDlg.Show()
            waitDlg.MainMsg = "CSVデータを出力しています。"

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressValue = i
                Application.DoEvents()
                sbuf = DtView1(i)("店舗コード") & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("店舗名") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                sbuf = sbuf & DtView1(i)("購入価格（税抜）") & ","
                sbuf = sbuf & DtView1(i)("保証料（税込）") & ","
                sbuf = sbuf & CInt(DtView1(i)("保険料")) & ","
                sbuf = sbuf & DtView1(i)("事務手数料（税抜）") & ","
                sbuf = sbuf & DtView1(i)("申込日") & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("ステータス") & Chr(34) & ","
                sbuf = sbuf & DtView1(i)("請求日") & ","
                If DtView1(i)("corp_flg") = "0" Then
                    sbuf = sbuf & Chr(34) & "0100" & Chr(34)
                ElseIf DtView1(i)("corp_flg") = "1" Then
                    sbuf = sbuf & Chr(34) & "0200" & Chr(34)
                End If
                sw.WriteLine(sbuf)
            Next
            sw.Close()

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "AC_kakoi.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 加入者データ(無償保証含む)
    '**********************************************************************
    Private Sub Button71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button71.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS 顧客名"
            strSQL += ", Wrn_mtr.zip_code AS 郵便番号"
            strSQL += ", Pref_mtr.pref_kana AS 住所１"
            strSQL += ", RTRIM(Wrn_mtr.city_name) AS 住所２"
            strSQL += ", RTRIM(Wrn_mtr.adrs2) + RTRIM(Wrn_mtr.adrs1) AS 住所３"
            strSQL += ", RTRIM(Wrn_mtr.srch_phn) AS 電話番号"
            strSQL += ", '110' AS CID"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_date AS 購入日"
            strSQL += ", Wrn_sub.prch_price"
            strSQL += ", Wrn_sub.prch_tax"
            strSQL += ", Wrn_sub.prch_date AS 保証開始日"
            strSQL += ", RTRIM(Wrn_sub.brnd_name) AS [メーカー名]"
            strSQL += ", RTRIM(Wrn_sub.model_name) AS 型番"
            strSQL += ", Wrn_sub.pos_code AS [予備・備考（POS番号）]"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", Wrn_sub.item_cat_code AS 品種"
            strSQL += ", Wrn_sub.corp_flg"
            strSQL += ", Wrn_mtr.cust_no"
            strSQL += ", Wrn_sub.wrn_fee"
            strSQL += ", Wrn_sub.wrn_prod AS wrn_prod_old"
            strSQL += ", Wrn_sub_2.wrn_prod2 AS wrn_prod"
            strSQL += " FROM Wrn_sub_2 RIGHT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_sub_2.ordr_no = Wrn_sub.ordr_no AND Wrn_sub_2.line_no = Wrn_sub.line_no AND"
            strSQL += " Wrn_sub_2.seq = Wrn_sub.seq RIGHT OUTER JOIN"
            strSQL += " Pref_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Pref_mtr.pref_code = Wrn_mtr.pref_code LEFT OUTER JOIN"
            strSQL += " Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code ON Wrn_sub.ordr_no = Wrn_mtr.ordr_no"
            If Label4.Text = "0" Then
                strSQL += " WHERE (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " WHERE (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsExport, "CSV")
            DB_CLOSE()

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                'ファイルに出力
                sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

                waitDlg = New WaitDialog
                waitDlg.Owner = Me
                waitDlg.ProgressMax = DtView1.Count - 1
                waitDlg.ProgressMin = 0
                waitDlg.ProgressStep = 1
                waitDlg.ProgressValue = 0
                Me.Enabled = False
                waitDlg.Show()
                waitDlg.MainMsg = "CSVデータを出力しています。"

                'sbuf = "店舗コード,店舗名,顧客名,郵便番号,住所１,住所２,住所３,電話番号,CID,保証番号,行番号,購入日,購入価格（税抜）,保証開始日,満期日,メーカー名,型番,予備・備考（POS番号）,ステータス,品種"
                'sw.WriteLine(sbuf)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressValue = i
                    Application.DoEvents()

                    If IsDBNull(DtView1(i)("wrn_prod")) Then
                        If IsDBNull(DtView1(i)("wrn_prod_old")) Then
                            DtView1(i)("wrn_prod") = "1"
                        Else
                            DtView1(i)("wrn_prod") = DtView1(i)("wrn_prod_old")
                        End If
                    End If

                    sbuf = DtView1(i)("店舗コード") & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("店舗名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("顧客名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("郵便番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所１") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所２") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("住所３") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("電話番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("CID") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("保証番号") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("行番号") & Chr(34) & ","
                    sbuf = sbuf & DtView1(i)("購入日") & ","
                    sbuf = sbuf & DtView1(i)("prch_price") & ","
                    sbuf = sbuf & DtView1(i)("保証開始日") & ","
                    sbuf = sbuf & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, DtView1(i)("wrn_prod"), DtView1(i)("購入日"))) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("メーカー名") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("型番") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("予備・備考（POS番号）") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("ステータス") & Chr(34) & ","
                    sbuf = sbuf & Chr(34) & DtView1(i)("品種") & Chr(34) & ","
                    Select Case DtView1(i)("corp_flg")
                        Case Is = "0"
                            sbuf = sbuf & "2.6,"
                            sbuf = sbuf & Chr(34) & "0100" & Chr(34)
                        Case Is = "1"
                            sbuf = sbuf & "4.5,"
                            sbuf = sbuf & Chr(34) & "0200" & Chr(34)
                        Case Is = "4"
                            sbuf = sbuf & "2.6,"
                            sbuf = sbuf & Chr(34) & "0400" & Chr(34)
                        Case Is = "5"
                            sbuf = sbuf & "2.6,"
                            sbuf = sbuf & Chr(34) & "0500" & Chr(34)
                        Case Else
                            sbuf = sbuf & ","
                            sbuf = sbuf & Chr(34) & "0000" & Chr(34)
                    End Select
                    If P_To_Date > "2012/08/31" Then
                        sbuf = sbuf & "," & Chr(34) & DtView1(i)("cust_no") & Chr(34)
                    End If
                    sw.WriteLine(sbuf)
                Next
            End If
            sw.Close()

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "Wrn_Data.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************************
    '** 請求明細
    '**********************************************************************
    Private Sub Button72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button72.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
            Dim i As Integer                  'カウンタ
            Dim sbuf As String                'ファイルに出力するデータ

            DsExport.Clear()
            strSQL = "SELECT Wrn_mtr.shop_code AS [店舗コード]"
            strSQL += ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
            strSQL += ", RTRIM(Wrn_mtr.ordr_no) AS 保証番号"
            strSQL += ", Wrn_sub.line_no AS 行番号"
            strSQL += ", Wrn_sub.prch_price, Wrn_sub.prch_tax, Wrn_sub.wrn_fee"
            If Date1.Text < "2009/06" Then
                strSQL += ", 60 AS [事務手数料（税抜）]"
            Else
                strSQL += ", 50 AS [事務手数料（税抜）]"
            End If
            strSQL += ", Wrn_sub.prch_date AS 申込日"
            strSQL += ", Wrn_sub.close_cont_flg AS [ステータス]"
            strSQL += ", '" & P_To_Date & "' AS 請求日"
            strSQL += ", Wrn_sub.corp_flg, Wrn_sub.item_cat_code"
            strSQL += " FROM Shop_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr ON Shop_mtr.shop_code = Wrn_mtr.shop_code LEFT OUTER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
            If Label4.Text = "0" Then
                strSQL += " WHERE (Wrn_sub.close_cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date = CONVERT(DATETIME, '" & P_To_Date & "', 102))"
            Else
                strSQL += " WHERE (Wrn_sub.cont_flg = 'A')"
                strSQL += " AND (Wrn_sub.close_date IS NULL)"
            End If

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsExport, "CSV")
            DB_CLOSE()

            If r = 0 Then
                MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                'ファイルに出力
                sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsExport.Tables("CSV"), "", "保証番号,行番号", DataViewRowState.CurrentRows)

                waitDlg = New WaitDialog
                waitDlg.Owner = Me
                waitDlg.ProgressMax = DtView1.Count - 1
                waitDlg.ProgressMin = 0
                waitDlg.ProgressStep = 1
                waitDlg.ProgressValue = 0
                Me.Enabled = False
                waitDlg.Show()
                waitDlg.MainMsg = "CSVデータを出力しています。"

                'sbuf = "店舗コード,店舗名,保証番号,行番号,購入価格,保証料（税込）,保険料,事務手数料（税抜）,申込日,ステータス,請求日,,品種"
                'sw.WriteLine(sbuf)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressValue = i
                    Application.DoEvents()
                    sbuf = DtView1(i)("店舗コード")
                    sbuf = sbuf & "," & Chr(34) & DtView1(i)("店舗名") & Chr(34)
                    sbuf = sbuf & "," & Chr(34) & DtView1(i)("保証番号") & Chr(34)
                    sbuf = sbuf & "," & Chr(34) & DtView1(i)("行番号") & Chr(34)
                    '購入価格(個人:税別、法人:税込)
                    If DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & "," & DtView1(i)("prch_price") + DtView1(i)("prch_tax")
                        sbuf = sbuf & "," & Round(CInt(DtView1(i)("wrn_fee")) * 1.05, 0)
                    Else
                        sbuf = sbuf & "," & DtView1(i)("prch_price")
                        sbuf = sbuf & "," & CInt(DtView1(i)("wrn_fee"))
                    End If
                    '保険料
                    If DtView1(i)("corp_flg") = "1" Then
                        sbuf = sbuf & "," & RoundDOWN((DtView1(i)("prch_price") + DtView1(i)("prch_tax")) * 0.045, 0)
                    Else
                        sbuf = sbuf & "," & Round(DtView1(i)("prch_price") * 0.026, 0)
                    End If
                    sbuf = sbuf & "," & DtView1(i)("事務手数料（税抜）")
                    sbuf = sbuf & "," & DtView1(i)("申込日")
                    sbuf = sbuf & "," & Chr(34) & DtView1(i)("ステータス") & Chr(34)
                    sbuf = sbuf & "," & DtView1(i)("請求日")
                    Select Case DtView1(i)("corp_flg")
                        Case Is = "0"
                            sbuf = sbuf & "," & Chr(34) & "0100" & Chr(34)
                        Case Is = "1"
                            sbuf = sbuf & "," & Chr(34) & "0200" & Chr(34)
                        Case Is = "4"
                            sbuf = sbuf & "," & Chr(34) & "0400" & Chr(34)
                        Case Is = "5"
                            sbuf = sbuf & "," & Chr(34) & "0500" & Chr(34)
                        Case Else
                            sbuf = sbuf & "," & Chr(34) & "0000" & Chr(34)
                    End Select
                    If Date1.Text > "2007/10" Then
                        sbuf = sbuf & "," & Chr(34) & DtView1(i)("item_cat_code") & Chr(34)
                    End If
                    sw.WriteLine(sbuf)
                Next
            End If
            sw.Close()

            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "Invc.csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Me.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '終了
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub

    Private Sub MRComObject(ByVal objXl As Object)
        'Excel 終了処理時のプロシージャ
        Try
            '提供されたランタイム呼び出し可能ラッパーの参照カウントをデクリメントします
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objXl)
        Catch
        Finally
            objXl = Nothing
        End Try
    End Sub
End Class
