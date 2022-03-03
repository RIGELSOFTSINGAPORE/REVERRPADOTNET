Public Class F00_Form03
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim WK_DsList1 As New DataSet
    Dim WK_DtView1, WK_DtView2 As DataView

    Dim DtView1, DtView2 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim test As Integer = 0
    Dim strSQL, Err_F, tbl_name, ANS As String
    Dim i, en, Line_No1 As Integer
    Dim WK_SEQ, WK_ID As Integer

    '部品
    Private label(99, 1) As label
    Private edit(99, 6) As GrapeCity.Win.Input.Interop.Edit
    Private nbrBox(99, 8) As GrapeCity.Win.Input.Interop.Number
    Private chkBox(99, 3) As CheckBox

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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Q_ptn As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Number001 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number002 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number003 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F00_Form03))
        Me.msg = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Q_ptn = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Interop.Number
        Me.Number002 = New GrapeCity.Win.Input.Interop.Number
        Me.Number003 = New GrapeCity.Win.Input.Interop.Number
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 388)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(1000, 20)
        Me.msg.TabIndex = 1235
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(936, 416)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 28)
        Me.Button98.TabIndex = 30
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 416)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 28)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "決定"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(5, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1003, 336)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(716, 416)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(196, 28)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "部品価格問合せ印刷"
        Me.Button2.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(8, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 32)
        Me.Label9.TabIndex = 1721
        Me.Label9.Text = "部品番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter



        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(104, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 32)
        Me.Label1.TabIndex = 1722
        Me.Label1.Text = "部品名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(292, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 32)
        Me.Label2.TabIndex = 1723
        Me.Label2.Text = "単価"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(340, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 32)
        Me.Label3.TabIndex = 1724
        Me.Label3.Text = "数量"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Q_ptn
        '
        Me.Q_ptn.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Q_ptn.Location = New System.Drawing.Point(264, 432)
        Me.Q_ptn.Name = "Q_ptn"
        Me.Q_ptn.Size = New System.Drawing.Size(56, 16)
        Me.Q_ptn.TabIndex = 1725
        Me.Q_ptn.Text = "Q_ptn"
        Me.Q_ptn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Q_ptn.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(868, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 32)
        Me.Label4.TabIndex = 1726
        Me.Label4.Text = "IBM 緊急"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(380, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 32)
        Me.Label5.TabIndex = 1727
        Me.Label5.Text = "GSS    計上"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(432, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 32)
        Me.Label6.TabIndex = 1728
        Me.Label6.Text = "EU価"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(528, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 32)
        Me.Label7.TabIndex = 1729
        Me.Label7.Text = "発注番号"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(636, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 32)
        Me.Label8.TabIndex = 1730
        Me.Label8.Text = "発受注番"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '
        'Number001
        '
        Me.Number001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number001.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001.Enabled = False
        Me.Number001.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(440, 432)
        Me.Number001.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(56, 16)
        Me.Number001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1754
        Me.Number001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Number001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number001.Value = Nothing
        Me.Number001.Visible = False
        '
        'Number002
        '
        Me.Number002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number002.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number002.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number002.Enabled = False
        Me.Number002.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.Number002.HighlightText = True
        Me.Number002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number002.Location = New System.Drawing.Point(328, 432)
        Me.Number002.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.Number002.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number002.Name = "Number002"
        Me.Number002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number002.Size = New System.Drawing.Size(56, 16)
        Me.Number002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.TabIndex = 1752
        Me.Number002.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Number002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number002.Value = Nothing
        Me.Number002.Visible = False
        '
        'Number003
        '
        Me.Number003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number003.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number003.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number003.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number003.Enabled = False
        Me.Number003.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number003.HighlightText = True
        Me.Number003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number003.Location = New System.Drawing.Point(384, 432)
        Me.Number003.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number003.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number003.Name = "Number003"
        Me.Number003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number003.Size = New System.Drawing.Size(56, 16)
        Me.Number003.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.TabIndex = 1751
        Me.Number003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number003.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.Number003.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Maroon
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(440, 412)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 20)
        Me.Label10.TabIndex = 1755
        Me.Label10.Text = "EU掛率"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Maroon
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(328, 412)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 20)
        Me.Label11.TabIndex = 1756
        Me.Label11.Text = "計上掛率"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Maroon
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(384, 412)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 20)
        Me.Label12.TabIndex = 1757
        Me.Label12.Text = "ﾌﾟﾗｽ"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label12.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Maroon
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(264, 412)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 20)
        Me.Label14.TabIndex = 1760
        Me.Label14.Text = "印刷ﾊﾟﾀﾝ"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label14.Visible = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(908, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 32)
        Me.Label13.TabIndex = 1761
        Me.Label13.Text = "在庫使用"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(480, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 32)
        Me.Label15.TabIndex = 1762
        Me.Label15.Text = "コスト"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Navy
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(948, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 32)
        Me.Label16.TabIndex = 1763
        Me.Label16.Text = "消耗品"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Navy
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(744, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 32)
        Me.Label17.TabIndex = 1764
        Me.Label17.Text = "シリアル№"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Maroon
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(496, 412)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(172, 20)
        Me.Label18.TabIndex = 1766
        Me.Label18.Text = "加算ｆｌｇ"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label18.Visible = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label19.Location = New System.Drawing.Point(496, 432)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(172, 16)
        Me.Label19.TabIndex = 1767
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label19.Visible = False
        '
        'F00_Form03
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(1014, 452)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Q_ptn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F00_Form03"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部品入力"
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        '↓↓↓↓↓↓ 2021/04/05 得意先グループの設定により加算する & 2行目以降も加算する
        kasan()     '**  加算フラグセット
        '↑↑↑↑↑↑ 2021/04/05 得意先グループの設定により加算する & 2行目以降も加算する


        DspSet()    '** 画面セット

        If P_DBG = "True" Then 'デバック表示
            Label10.Visible = True : Q_ptn.Visible = True
            Label11.Visible = True : Number001.Visible = True
            Label12.Visible = True : Number002.Visible = True
            Label14.Visible = True : Number003.Visible = True
            '↓↓↓↓↓↓ 2021/04/05 得意先グループの設定により加算する & 2行目以降も加算する
            Label18.Visible = True : Label19.Visible = True
            '↑↑↑↑↑↑ 2021/04/05 得意先グループの設定により加算する & 2行目以降も加算する

        End If

    End Sub

    '↓↓↓↓↓↓ 2021/04/05 得意先グループの設定により加算する & 2行目以降も加算する
    '********************************************************************
    '**  加算フラグセット
    '********************************************************************
    Sub kasan()
        WK_DsList1.Clear()
        strSQL = "SELECT cls_code_name_abbr"
        strSQL += " FROM V_cls_006"
        strSQL += " WHERE (cls_code = '" & P6_F00_Form03 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "cls006")
        DB_CLOSE()
        DtView1 = New DataView(WK_DsList1.Tables("cls006"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            If Not IsDBNull(DtView1(0)("cls_code_name_abbr")) Then
                Label19.Text = DtView1(0)("cls_code_name_abbr")
            End If
        End If
    End Sub
    '↑↑↑↑↑↑ 2021/04/05 得意先グループの設定により加算する & 2行目以降も加算する


    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Number001.Value = P_part_rate1

        If P2_F00_Form03 = "1" Then   '見積

            tbl_name = "T04_REP_PART"

            Q_ptn.Text = Nothing
            WK_DsList1.Clear()
            strSQL = "SELECT part_amnt_q_ptn FROM M05_VNDR WHERE (vndr_code = '" & P1_F00_Form03 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "M05_VNDR")
            DB_CLOSE()
            DtView1 = New DataView(WK_DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                If Not IsDBNull(DtView1(0)("part_amnt_q_ptn")) Then
                    Q_ptn.Text = DtView1(0)("part_amnt_q_ptn")
                    Button2.Visible = True
                End If
            End If
        Else                        '完了
            tbl_name = "T04_REP_PART_2"
            Button2.Visible = False
        End If

        msg.Text = Nothing
        P_RTN = "0"
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()

        '基準点
        label(0, 0) = New Label
        label(0, 0).Location = New System.Drawing.Point(0, 0)
        label(0, 0).Size = New System.Drawing.Size(0, 0)
        label(0, 0).Text = Nothing
        Panel1.Controls.Add(label(0, 0))

        DtView1 = New DataView(P_DsList1.Tables(tbl_name), "", "seq", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For Line_No1 = 0 To DtView1.Count - 1
                add_line("1")    '使用部品
            Next
            Line_No1 = Line_No1 - 1
        Else
            Line_No1 = -1
        End If
        add_line("0")    '使用部品
    End Sub

    '見積内容
    Sub add_line(ByVal flg)
        If flg = "0" Then Line_No1 = Line_No1 + 1

        '部品コード
        en = 1
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(0, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(96, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 20
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            edit(Line_No1, en).Text = DtView1(Line_No1)("part_code")
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit1_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit1_LostFocus

        '部品コード(変更前)
        en = 5
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(0, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(0, 0)
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        edit(Line_No1, en).Visible = False
        If flg = "1" Then
            edit(Line_No1, en).Text = DtView1(Line_No1)("part_code")
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))

        '部品名
        en = 2
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(96, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(188, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 100
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            edit(Line_No1, en).Text = DtView1(Line_No1)("part_name")
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit2_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit2_LostFocus

        '単価
        en = 1
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(284, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(48, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("part_amnt")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox1_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox1_LostFocus

        '数量
        en = 2
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(332, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {99, 0, 0, -2147483648})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(40, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("use_qty")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox2_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox2_LostFocus

        'GSS計上
        en = 4
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(372, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(52, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("shop_chrg")) Then
                nbrBox(Line_No1, en).Value = DtView1(Line_No1)("shop_chrg")
            Else
                nbrBox(Line_No1, en).Value = 0
            End If
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox4_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox4_LostFocus

        'EU価
        en = 5
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(424, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(48, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("eu_chrg")) Then
                nbrBox(Line_No1, en).Value = DtView1(Line_No1)("eu_chrg")
            Else
                nbrBox(Line_No1, en).Value = 0
            End If
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox5_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox5_LostFocus

        'コスト
        en = 8
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(472, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(48, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("cost_chrg")) Then
                nbrBox(Line_No1, en).Value = DtView1(Line_No1)("cost_chrg")
            Else
                nbrBox(Line_No1, en).Value = 0
            End If
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox8_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox8_LostFocus

        '発注番号
        en = 3
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(520, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(108, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 15
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("ordr_no")) Then
                edit(Line_No1, en).Text = DtView1(Line_No1)("ordr_no")
            Else
                edit(Line_No1, en).Text = Nothing
            End If
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit3_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit3_LostFocus

        '発受注番
        en = 4
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(628, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(108, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 15
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("ordr_no2")) Then
                edit(Line_No1, en).Text = DtView1(Line_No1)("ordr_no2")
            Else
                edit(Line_No1, en).Text = Nothing
            End If
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit4_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit4_LostFocus

        's_n
        en = 6
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(736, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(124, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 25
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("s_n")) Then
                edit(Line_No1, en).Text = DtView1(Line_No1)("s_n")
            Else
                edit(Line_No1, en).Text = Nothing
            End If
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit6_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit6_LostFocus

        'IBM緊急
        en = 2
        chkBox(Line_No1, en) = New CheckBox
        chkBox(Line_No1, en).Location = New System.Drawing.Point(860, 25 * Line_No1 + label(0, 0).Location.Y)
        chkBox(Line_No1, en).Size = New System.Drawing.Size(40, 25)
        chkBox(Line_No1, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No1, en).Text = Nothing
        chkBox(Line_No1, en).TabIndex = Line_No1
        chkBox(Line_No1, en).Tag = Line_No1
        If P1_F00_Form03 = "02" Then    'IBM
            chkBox(Line_No1, en).Visible = True
            If flg = "1" Then
                If Not IsDBNull(DtView1(Line_No1)("ibm_flg")) Then
                    If DtView1(Line_No1)("ibm_flg") = "True" Then
                        chkBox(Line_No1, en).Checked = True
                    Else
                        chkBox(Line_No1, en).Checked = False
                    End If
                Else
                    chkBox(Line_No1, en).Checked = False
                End If
            Else
                chkBox(Line_No1, en).Checked = False
            End If
        Else
            chkBox(Line_No1, en).Visible = False
            chkBox(Line_No1, en).Checked = False
        End If
        Panel1.Controls.Add(chkBox(Line_No1, en))
        AddHandler chkBox(Line_No1, en).GotFocus, AddressOf CHK2_GotFocus
        AddHandler chkBox(Line_No1, en).LostFocus, AddressOf CHK2_LostFocus
        AddHandler chkBox(Line_No1, en).Click, AddressOf CHK2_Click

        '在庫使用
        en = 1
        chkBox(Line_No1, en) = New CheckBox
        chkBox(Line_No1, en).Location = New System.Drawing.Point(900, 25 * Line_No1 + label(0, 0).Location.Y)
        chkBox(Line_No1, en).Size = New System.Drawing.Size(40, 25)
        chkBox(Line_No1, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No1, en).Text = Nothing
        chkBox(Line_No1, en).TabIndex = Line_No1
        chkBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("zaiko_flg")) Then
                If DtView1(Line_No1)("zaiko_flg") = "True" Then
                    chkBox(Line_No1, en).Checked = True
                Else
                    chkBox(Line_No1, en).Checked = False
                End If
            Else
                chkBox(Line_No1, en).Checked = False
            End If
        Else
            chkBox(Line_No1, en).Checked = False
        End If
        If P2_F00_Form03 = "1" Then   '見積
            chkBox(Line_No1, en).Visible = False
        Else
            chkBox(Line_No1, en).Visible = True
        End If
        Panel1.Controls.Add(chkBox(Line_No1, en))
        AddHandler chkBox(Line_No1, en).GotFocus, AddressOf CHK_GotFocus
        AddHandler chkBox(Line_No1, en).LostFocus, AddressOf CHK_LostFocus

        '消耗品
        en = 3
        chkBox(Line_No1, en) = New CheckBox
        chkBox(Line_No1, en).Location = New System.Drawing.Point(940, 25 * Line_No1 + label(0, 0).Location.Y)
        chkBox(Line_No1, en).Size = New System.Drawing.Size(40, 25)
        chkBox(Line_No1, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No1, en).Text = Nothing
        chkBox(Line_No1, en).TabIndex = Line_No1
        chkBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("exp_flg")) Then
                If DtView1(Line_No1)("exp_flg") = "True" Then
                    chkBox(Line_No1, en).Checked = True
                Else
                    chkBox(Line_No1, en).Checked = False
                End If
            Else
                chkBox(Line_No1, en).Checked = False
            End If
        Else
            chkBox(Line_No1, en).Checked = False
        End If
        'If P2_F00_Form03 = "1" Then   '見積
        '    chkBox(Line_No1, en).Visible = False
        'Else
        '    chkBox(Line_No1, en).Visible = True
        'End If
        Panel1.Controls.Add(chkBox(Line_No1, en))
        AddHandler chkBox(Line_No1, en).GotFocus, AddressOf CHK3_GotFocus
        AddHandler chkBox(Line_No1, en).LostFocus, AddressOf CHK3_LostFocus

        'ID
        en = 3
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(972, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(25, 25)
        nbrBox(Line_No1, en).Visible = True
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("ID_NO")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        'SEQ
        en = 1
        label(Line_No1, en) = New Label
        label(Line_No1, en).Location = New System.Drawing.Point(1005, 25 * Line_No1 + label(0, 0).Location.Y)
        label(Line_No1, en).Size = New System.Drawing.Size(25, 25)
        label(Line_No1, en).Visible = True
        If flg = "1" Then
            label(Line_No1, en).Text = DtView1(Line_No1)("seq")
        Else
            label(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(label(Line_No1, en))


        part_rate_get(nbrBox(Line_No1, 1).Value)

        '計上掛率
        en = 6
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####0.#####", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####0.#####", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(1030, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 196608})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147287040})
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(50, 25)
        nbrBox(Line_No1, en).Tag = Line_No1
        nbrBox(Line_No1, en).Visible = False
        nbrBox(Line_No1, en).Value = Number002.Value
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        '調整
        en = 7
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(1080, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(50, 25)
        nbrBox(Line_No1, en).Tag = Line_No1
        nbrBox(Line_No1, en).Visible = False
        nbrBox(Line_No1, en).Value = Number003.Value
        Panel1.Controls.Add(nbrBox(Line_No1, en))

    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_edit1(ByVal seq As Integer, ByVal flg As String) '部品コード
        msg.Text = Nothing

        edit(seq, 1).Text = Trim(edit(seq, 1).Text)
        'If edit(seq, 1).Text <> Nothing _
        '    Or edit(seq, 2).Text <> Nothing _
        '    Or nbrBox(seq, 1).Value <> 0 _
        '    Or nbrBox(seq, 2).Value <> 0 Then
        '    If edit(seq, 1).Text = Nothing Then
        '        edit(seq, 1).BackColor = System.Drawing.Color.Red
        '        msg.Text = "部品コードの入力がありません。"
        '        Exit Sub
        '    End If
        'End If
        If edit(seq, 5).Text <> edit(seq, 1).Text Then

            If edit(seq, 1).Text <> Nothing Then
                WK_DsList1.Clear()
                strSQL = "SELECT part_code, part_name, stc_amnt, exc_amnt"
                strSQL += " FROM M40_PART"
                strSQL += " WHERE (vndr_code = '" & P1_F00_Form03 & "')"
                strSQL += " GROUP BY part_code, part_name, stc_amnt, exc_amnt"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "M40_PART")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("M40_PART"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M40_PART"), "part_code = '" & edit(seq, 1).Text & "'", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        edit(seq, 2).Text = WK_DtView1(0)("part_name")

                        If P5_F00_Form03 <> "02" Then  'メーカー保証以外
                            If flg = "1" Then
                                If WK_DtView1(0)("stc_amnt") <> 0 Then
                                    If WK_DtView1(0)("exc_amnt") <> 0 Then
                                        nbrBox(seq, 1).Focus()
                                        '選択
                                        P1_F00_Form03_2 = WK_DtView1(0)("stc_amnt")
                                        P2_F00_Form03_2 = WK_DtView1(0)("exc_amnt")
                                        P3_F00_Form03_2 = WK_DtView1(0)("part_name")

                                        Dim F00_Form03_2 As New F00_Form03_2
                                        F00_Form03_2.ShowDialog()

                                        nbrBox(seq, 1).Value = P1_F00_Form03_2
                                    Else
                                        nbrBox(seq, 1).Value = WK_DtView1(0)("stc_amnt")
                                    End If
                                Else
                                    If WK_DtView1(0)("exc_amnt") <> 0 Then
                                        nbrBox(seq, 1).Value = WK_DtView1(0)("exc_amnt")
                                    End If
                                End If
                                nbrBox(seq, 8).Value = nbrBox(seq, 1).Value
                            End If
                        End If
                        'Else
                        '    edit(seq, 2).Text = Nothing
                        '    edit(seq, 1).BackColor = System.Drawing.Color.Red
                        '    msg.Text = "部品コードがマスタにありません。"
                        '    Exit Sub
                    End If
                End If
            End If
            edit(seq, 5).Text = edit(seq, 1).Text
        End If
        edit(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_edit2(ByVal seq As Integer) '部品名
        msg.Text = Nothing

        edit(seq, 2).Text = Trim(edit(seq, 2).Text)
        If edit(seq, 1).Text <> Nothing _
            Or edit(seq, 2).Text <> Nothing _
            Or nbrBox(seq, 1).Value <> 0 _
            Or nbrBox(seq, 2).Value <> 0 Then
            If edit(seq, 2).Text = Nothing Then
                edit(seq, 2).BackColor = System.Drawing.Color.Red
                msg.Text = "部品名の入力がありません。"
                Exit Sub
            End If
        End If
        edit(seq, 2).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_edit3(ByVal seq As Integer) '発注番号
        msg.Text = Nothing

        edit(seq, 3).Text = Trim(edit(seq, 3).Text)
        'If edit(seq, 1).Text <> Nothing _
        '    Or edit(seq, 2).Text <> Nothing _
        '    Or nbrBox(seq, 1).Value <> 0 _
        '    Or nbrBox(seq, 2).Value <> 0 Then
        '    If edit(seq, 3).Text = Nothing Then
        '        edit(seq, 3).BackColor = System.Drawing.Color.Red
        '        msg.Text = "発注番号の入力がありません。"
        '        Exit Sub
        '    End If
        'End If
        edit(seq, 3).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_edit4(ByVal seq As Integer) '発受注番
        msg.Text = Nothing

        edit(seq, 4).Text = Trim(edit(seq, 4).Text)
        'If edit(seq, 1).Text <> Nothing _
        '    Or edit(seq, 2).Text <> Nothing _
        '    Or nbrBox(seq, 1).Value <> 0 _
        '    Or nbrBox(seq, 2).Value <> 0 Then
        '    If edit(seq, 4).Text = Nothing Then
        '        edit(seq, 4).BackColor = System.Drawing.Color.Red
        '        msg.Text = "発受注番の入力がありません。"
        '        Exit Sub
        '    End If
        'End If
        edit(seq, 4).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_edit6(ByVal seq As Integer) 's_n
        msg.Text = Nothing

        edit(seq, 6).Text = Trim(edit(seq, 6).Text)
        'If edit(seq, 1).Text <> Nothing _
        '    Or edit(seq, 2).Text <> Nothing _
        '    Or nbrBox(seq, 1).Value <> 0 _
        '    Or nbrBox(seq, 2).Value <> 0 Then
        '    If edit(seq, 5).Text = Nothing Then
        '        edit(seq, 5).BackColor = System.Drawing.Color.Red
        '        msg.Text = "発受注番の入力がありません。"
        '        Exit Sub
        '    End If
        'End If
        edit(seq, 6).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox1(ByVal seq As Integer) '単価
        msg.Text = Nothing

        'If edit(seq, 1).Text <> Nothing _
        '  Or edit(seq, 2).Text <> Nothing _
        '  Or nbrBox(seq, 1).Value <> 0 _
        '  Or nbrBox(seq, 2).Value <> 0 Then
        '    If nbrBox(seq, 1).Value = 0 Then
        '        nbrBox(seq, 1).BackColor = System.Drawing.Color.Red
        '        msg.Text = "単価の入力がありません。"
        '        Exit Sub
        '    End If
        'End If
        nbrBox(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox2(ByVal seq As Integer) '数量
        msg.Text = Nothing

        If edit(seq, 1).Text <> Nothing _
           Or edit(seq, 2).Text <> Nothing _
           Or nbrBox(seq, 1).Value <> 0 _
           Or nbrBox(seq, 2).Value <> 0 Then
            If nbrBox(seq, 2).Value = 0 Then
                nbrBox(seq, 2).BackColor = System.Drawing.Color.Red
                msg.Text = "数量の入力がありません。"
                Exit Sub
            End If
        End If
        nbrBox(seq, 2).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox4(ByVal seq As Integer) 'GSS計上
        msg.Text = Nothing

        'If edit(seq, 1).Text <> Nothing _
        '  Or edit(seq, 2).Text <> Nothing _
        '  Or nbrBox(seq, 1).Value <> 0 _
        '  Or nbrBox(seq, 2).Value <> 0 Then
        '    If nbrBox(seq, 3).Value = 0 Then
        '        nbrBox(seq, 3).BackColor = System.Drawing.Color.Red
        '        msg.Text = "GSS計上の入力がありません。"
        '        Exit Sub
        '    End If
        'End If
        nbrBox(seq, 4).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox5(ByVal seq As Integer) 'EU価
        msg.Text = Nothing

        'If edit(seq, 1).Text <> Nothing _
        '  Or edit(seq, 2).Text <> Nothing _
        '  Or nbrBox(seq, 1).Value <> 0 _
        '  Or nbrBox(seq, 2).Value <> 0 Then
        '    If nbrBox(seq, 4).Value = 0 Then
        '        nbrBox(seq, 4).BackColor = System.Drawing.Color.Red
        '        msg.Text = "EU価の入力がありません。"
        '        Exit Sub
        '    End If
        'End If
        nbrBox(seq, 5).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox8(ByVal seq As Integer) 'COST
        msg.Text = Nothing

        If edit(seq, 1).Text <> Nothing _
          Or edit(seq, 2).Text <> Nothing _
          Or nbrBox(seq, 1).Value <> 0 _
          Or nbrBox(seq, 2).Value <> 0 Then
            If nbrBox(seq, 8).Value = 0 Then
                nbrBox(seq, 8).BackColor = System.Drawing.Color.Red
                msg.Text = "コストの入力がありません。"
                Exit Sub
            End If
        End If
        nbrBox(seq, 8).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        For i = 0 To Line_No1

            CHK_edit1(i, "0") '部品コード
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 1).Focus() : Exit Sub

            CHK_edit2(i) '部品名
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 2).Focus() : Exit Sub

            CHK_nbrBox1(i) '単価
            If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 1).Focus() : Exit Sub

            CHK_nbrBox2(i) '数量
            If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 2).Focus() : Exit Sub

            CHK_nbrBox4(i) 'GSS計上
            If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 4).Focus() : Exit Sub

            CHK_nbrBox5(i) 'EU価
            If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 5).Focus() : Exit Sub

            'CHK_nbrBox8(i) 'COST
            'If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 8).Focus() : Exit Sub

            CHK_edit3(i) '発注番号
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 3).Focus() : Exit Sub

            CHK_edit4(i) '発受注番
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 4).Focus() : Exit Sub

            CHK_edit6(i) 's_n
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 6).Focus() : Exit Sub

        Next
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 2).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 3).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 4).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 6).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 2).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox4_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 4).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 5).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox8_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 8).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 2).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 3).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub edit1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit1(Lin.Tag, "1") '部品コード
    End Sub
    Private Sub edit2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit2(Lin.Tag) '部品名
    End Sub
    Private Sub edit3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit3(Lin.Tag) '発注番号
    End Sub
    Private Sub edit4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit4(Lin.Tag) '発受注番
    End Sub
    Private Sub edit6_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit6(Lin.Tag) 's_n
        If P2_F00_Form03 = "1" Then   '見積
            If Line_No1 = Lin.Tag Then
                If edit(Lin.Tag, 1).Text <> Nothing Then
                    add_line("0")    '使用部品
                    edit(Lin.Tag + 1, 1).Focus()
                End If
            End If
        End If
    End Sub
    Private Sub nbrBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox1(nbr.Tag) '単価
        part_rate_get(nbrBox(nbr.Tag, 1).Value * nbrBox(nbr.Tag, 2).Value)
        keijo(nbr.Tag)
        EU(nbr.Tag)
    End Sub
    Private Sub nbrBox2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox2(nbr.Tag) '数量
        part_rate_get(nbrBox(nbr.Tag, 1).Value * nbrBox(nbr.Tag, 2).Value)
        keijo(nbr.Tag)
        EU(nbr.Tag)
    End Sub
    Private Sub nbrBox4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox4(nbr.Tag) '単価
    End Sub
    Private Sub nbrBox5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox5(nbr.Tag) '数量
    End Sub
    Private Sub nbrBox8_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox8(nbr.Tag) '数量
    End Sub
    Private Sub CHK2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        chkBox(Lin.Tag, 2).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CHK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        'If P2_F00_Form03 = "2" Then   '完了
        '    If Line_No1 = Lin.Tag Then
        '        If nbrBox(Lin.Tag, 2).Value <> 0 Then
        '            add_line("0")    '使用部品
        '            edit(Lin.Tag + 1, 1).Focus()
        '        End If
        '    End If
        'End If
        chkBox(Lin.Tag, 1).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CHK3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        If P2_F00_Form03 = "2" Then   '完了
            If Line_No1 = Lin.Tag Then
                If nbrBox(Lin.Tag, 2).Value <> 0 Then
                    add_line("0")    '使用部品
                    edit(Lin.Tag + 1, 1).Focus()
                End If
            End If
        End If
        chkBox(Lin.Tag, 3).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Sub part_rate_get(ByVal amnt As Integer)

        Select Case P4_F00_Form03

            Case Is = "Z"   'NEC Zero
                Number002.Value = 0
                Number003.Value = 0

            Case Is = "1"  'イレギュラー処理（ソフマップでHP有償修理取次時）、Fujitsu 1
                Number002.Value = 1
                Number003.Value = 1

            Case Else
                Number002.Value = 0
                Number003.Value = 0

                WK_DsList1.Clear()
                strSQL = "SELECT M06_RPAR_COMP.own_flg, M31_PART_RATE.own_rpat_kbn, M31_PART_RATE.strt_amnt, M31_PART_RATE.end_amnt"
                strSQL += ", M31_PART_RATE.part_rate, M31_PART_RATE.part_amnt"
                strSQL += " FROM T01_REP_MTR INNER JOIN"
                strSQL += " M31_PART_RATE ON"
                strSQL += " T01_REP_MTR.store_code = M31_PART_RATE.store_code AND"
                strSQL += " T01_REP_MTR.vndr_code = M31_PART_RATE.vndr_code AND"
                strSQL += " T01_REP_MTR.note_kbn = M31_PART_RATE.note_kbn INNER JOIN"
                strSQL += " M06_RPAR_COMP ON"
                strSQL += " T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code"
                strSQL += " WHERE (M31_PART_RATE.delt_flg = 0)"
                strSQL += " AND (M06_RPAR_COMP.delt_flg = 0"
                strSQL += ") AND (T01_REP_MTR.rcpt_no = '" & P3_F00_Form03 & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    If WK_DtView1(0)("own_flg") = "1" Then
                        WK_DtView2 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "own_rpat_kbn = '01' AND strt_amnt <= " & amnt & " AND end_amnt >= " & amnt, "", DataViewRowState.CurrentRows)
                    Else
                        WK_DtView2 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "own_rpat_kbn = '02' AND strt_amnt <= " & amnt & " AND end_amnt >= " & amnt, "", DataViewRowState.CurrentRows)
                    End If
                    If WK_DtView2.Count <> 0 Then
                        Number002.Value = WK_DtView2(0)("part_rate")
                        Number003.Value = WK_DtView2(0)("part_amnt")
                    End If
                End If
        End Select
    End Sub

    Private Sub CHK2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        part_rate_get(nbrBox(Lin.Tag, 1).Value * nbrBox(Lin.Tag, 2).Value)
        keijo(Lin.Tag)
        EU(Lin.Tag)
    End Sub

    Sub keijo(ByVal seq)
        Dim Fst_F As String = "0"
        nbrBox(seq, 6).Value = Number002.Value    '計上掛率
        nbrBox(seq, 7).Value = Number003.Value    '調整額

        If P1_F00_Form03 = "04" And P8_F00_Form03 = "True" Then    'Gateway、自社
            For i = 0 To Line_No1
                If nbrBox(i, 7).Value = 0 Then
                    nbrBox(i, 4).Value = RoundUP(nbrBox(i, 1).Value * nbrBox(i, 2).Value * nbrBox(i, 6).Value, -2)
                Else
                    nbrBox(i, 4).Value = RoundUP(nbrBox(i, 1).Value * nbrBox(i, 2).Value * nbrBox(i, 6).Value + nbrBox(i, 7).Value, -2)
                End If
            Next
        Else
            If (P1_F00_Form03 = "01" Or P1_F00_Form03 = "06") And P7_F00_Form03 = "True" Then    'Apple定額
                For i = 0 To Line_No1
                    nbrBox(i, 4).Value = RoundUP(nbrBox(i, 1).Value * nbrBox(i, 2).Value * nbrBox(i, 6).Value, -2)
                Next
            Else
                For i = 0 To Line_No1
                    nbrBox(i, 4).Value = RoundUP(nbrBox(i, 1).Value * nbrBox(i, 2).Value * nbrBox(i, 6).Value, -2)

                    If nbrBox(i, 7).Value <> 0 Then

                        '↓↓↓↓↓↓ 2021/04/05 得意先グループの設定により加算する & 2行目以降も加算する
                        If P1_F00_Form03 = "01" Then    'APPLE
                            If Fst_F = "0" Then
                                nbrBox(i, 4).Value = RoundUP(nbrBox(i, 1).Value * nbrBox(i, 2).Value * nbrBox(i, 6).Value + nbrBox(i, 7).Value, -2)
                                Fst_F = "1"
                            Else
                                If Label19.Text = "tyouseigakukasan3k=yes" Then
                                    nbrBox(i, 4).Value = RoundUP(nbrBox(i, 1).Value * nbrBox(i, 2).Value * nbrBox(i, 6).Value + nbrBox(i, 7).Value, -2)
                                End If
                            End If
                        Else
                            If nbrBox(i, 1).Value * nbrBox(i, 2).Value >= 5000 Then
                                If Fst_F = "0" Then
                                    nbrBox(i, 4).Value = RoundUP(nbrBox(i, 1).Value * nbrBox(i, 2).Value * nbrBox(i, 6).Value + nbrBox(i, 7).Value, -2)
                                    Fst_F = "1"
                                End If
                            End If
                        End If
                        '↑↑↑↑↑↑ 2021/04/05 得意先グループの設定により加算する & 2行目以降も加算する

                    End If

                    If chkBox(i, 2).Checked = True Then
                        nbrBox(i, 4).Value = nbrBox(i, 4).Value + 3000
                    End If
                Next
            End If
        End If
    End Sub

    Sub EU(ByVal seq)
        For i = 0 To Line_No1
            If P6_F00_Form03 = "18" Or P6_F00_Form03 = "52" Then  'BIC
                nbrBox(i, 5).Value = RoundUP(nbrBox(i, 4).Value * Number001.Value, 0)
            Else
                nbrBox(i, 5).Value = RoundUP(nbrBox(i, 4).Value * Number001.Value, -2)
            End If
        Next
        'If P6_F00_Form03 = "18" Or P6_F00_Form03 = "52" Then  'BIC
        '    nbrBox(seq, 5).Value = RoundUP(nbrBox(seq, 4).Value * Number001.Value, 0)
        'Else
        '    nbrBox(seq, 5).Value = RoundUP(nbrBox(seq, 4).Value * Number001.Value, -2)
        'End If
    End Sub

    '********************************************************************
    '** 決定
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  項目チェック
        If Err_F = "0" Then

            For i = 0 To Line_No1
                CHK_nbrBox8(i) 'COST
                If msg.Text <> Nothing Then
                    ANS = MessageBox.Show("コスト「\0」です。更新してよろしいですか", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                    If ANS = "2" Then GoTo end_tb 'いいえ
                End If
            Next
            'PRABU COMMEND #2021-03-17
            If test = 0 Then
                upd()   'DS更新
            Else

            End If
            WK_DsList1.Clear()
                P_RTN = "1"
                Close()
            End If
end_tb:
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub upd()   'DS更新
        For i = 0 To Line_No1

            If label(i, 1).Text = Nothing Then
                If nbrBox(i, 2).Value <> 0 Then
                    '追加
                    DtView2 = New DataView(P_DsList1.Tables(tbl_name), "", "seq DESC", DataViewRowState.CurrentRows)
                    If DtView2.Count = 0 Then
                        WK_SEQ = 1
                    Else
                        WK_SEQ = DtView2(0)("seq") + 1
                    End If
                    DtView2 = New DataView(P_DsList1.Tables(tbl_name), "", "ID_NO DESC", DataViewRowState.CurrentRows)
                    If DtView2.Count = 0 Then
                        WK_ID = 0
                    Else
                        WK_ID = DtView2(0)("ID_NO") + 1
                    End If

                    dttable = P_DsList1.Tables(tbl_name)
                    dtRow = dttable.NewRow
                    dtRow("part_code") = edit(i, 1).Text
                    dtRow("part_name") = edit(i, 2).Text
                    dtRow("part_amnt") = nbrBox(i, 1).Value
                    dtRow("use_qty") = nbrBox(i, 2).Value
                    dtRow("zaiko_flg") = chkBox(i, 1).Checked
                    dtRow("shop_chrg") = nbrBox(i, 4).Value
                    dtRow("eu_chrg") = nbrBox(i, 5).Value
                    dtRow("cost_chrg") = nbrBox(i, 8).Value
                    dtRow("ordr_no") = edit(i, 3).Text
                    dtRow("ordr_no2") = edit(i, 4).Text
                    dtRow("ibm_flg") = chkBox(i, 2).Checked
                    dtRow("exp_flg") = chkBox(i, 3).Checked
                    dtRow("seq") = WK_SEQ
                    dtRow("ID_NO") = WK_ID
                    dtRow("s_n") = edit(i, 6).Text
                    dttable.Rows.Add(dtRow)

                End If
            Else
                If nbrBox(i, 2).Value <> 0 Then
                    '変更
                    DtView2 = New DataView(P_DsList1.Tables(tbl_name), "seq =" & label(i, 1).Text, "", DataViewRowState.CurrentRows)
                    DtView2(0)("part_code") = edit(i, 1).Text
                    DtView2(0)("part_name") = edit(i, 2).Text
                    DtView2(0)("part_amnt") = nbrBox(i, 1).Value
                    DtView2(0)("use_qty") = nbrBox(i, 2).Value
                    DtView2(0)("zaiko_flg") = chkBox(i, 1).Checked
                    DtView2(0)("shop_chrg") = nbrBox(i, 4).Value
                    DtView2(0)("eu_chrg") = nbrBox(i, 5).Value
                    DtView2(0)("cost_chrg") = nbrBox(i, 8).Value
                    DtView2(0)("ordr_no") = edit(i, 3).Text
                    DtView2(0)("ordr_no2") = edit(i, 4).Text
                    DtView2(0)("ibm_flg") = chkBox(i, 2).Checked
                    DtView2(0)("exp_flg") = chkBox(i, 3).Checked
                    DtView2(0)("s_n") = edit(i, 6).Text
                Else
                    '削除
                    Dim myDataTable As DataTable
                    Dim myDataRowCollection As DataRowCollection
                    Dim myDataRow As DataRow
                    myDataTable = P_DsList1.Tables(tbl_name)
                    myDataRowCollection = myDataTable.Rows                      'テーブルの行全てを取得
                    myDataRow = myDataRowCollection.Item(nbrBox(i, 3).Value)    '対象の行を取得　インデックスは0から
                    myDataRow.Delete()                                          '注　行のRowState が Added の場合は、行がテーブルから削除されます。
                    myDataRow = Nothing
                    myDataRowCollection = Nothing
                    myDataTable = Nothing
                End If
            End If

        Next
    End Sub

    '********************************************************************
    '**  部品価格問合せ印刷
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  項目チェック

        If Err_F = "0" Then

            upd()   'DS更新
            test = 1
            Select Case Q_ptn.Text
                Case Is = "01"
                    PRT_PRAM1 = "Print_R_NEC_Parts_Inq" '部品価格問合せ印刷
                    PRT_PRAM2 = P3_F00_Form03
                    Dim F70_Form01 As New F70_Form01
                    F70_Form01.ShowDialog()

                Case Is = "02"
                    PRT_PRAM1 = "Print_R_Fujitsu_Parts_Inq" '部品価格問合せ印刷
                    PRT_PRAM2 = P3_F00_Form03
                    Dim F70_Form01 As New F70_Form01
                    F70_Form01.ShowDialog()

            End Select
            P_RTN = "1"
            P_PRT_F = "1"
            msg.Text = "印刷しました。"
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        Close()
    End Sub
End Class