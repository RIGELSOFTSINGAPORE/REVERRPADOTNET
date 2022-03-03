Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Export.Pdf
Public Class F10_Form51
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim DtView1, DtView2, WK_DtView1 As DataView

    Dim strSQL, Err_F, Mach_F As String
    Dim i As Integer
    Dim cd(10), prt(10), moji(10) As String
    Dim up_mg(10), lt_mg(10), WK_mg As Decimal

    Dim WK_p As String
    Dim int1 As Integer
    Friend WithEvents Combo01 As ComboBox
    Friend WithEvents CL01 As Label
    Friend WithEvents Combo02 As ComboBox
    Friend WithEvents CL02 As Label
    Friend WithEvents Combo03 As ComboBox
    Friend WithEvents CL03 As Label
    Friend WithEvents Combo04 As ComboBox
    Friend WithEvents CL04 As Label
    Friend WithEvents Combo05 As ComboBox
    Friend WithEvents CL05 As Label
    Friend WithEvents Combo06 As ComboBox
    Friend WithEvents CL06 As Label
    Friend WithEvents Combo07 As ComboBox
    Friend WithEvents CL07 As Label
    Dim printer As String

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
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Number01 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label03 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Number02_2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number02 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number01_2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number03_2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number03 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number04_2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number04 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label04 As System.Windows.Forms.Label
    Friend WithEvents Number05_2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number05 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label05 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents Button01 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents Number06_2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number06 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label06 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents Number07_2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number07 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label07 As System.Windows.Forms.Label
    Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10_Form51))
        Me.Number02_2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number02 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number01_2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Number01 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label03 = New System.Windows.Forms.Label()
        Me.Label02 = New System.Windows.Forms.Label()
        Me.Label01 = New System.Windows.Forms.Label()
        Me.msg = New System.Windows.Forms.Label()
        Me.Button01 = New System.Windows.Forms.Button()
        Me.Button98 = New System.Windows.Forms.Button()
        Me.Number03_2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number03 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number04_2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number04 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label04 = New System.Windows.Forms.Label()
        Me.Number05_2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number05 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label05 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PdfExport1 = New DataDynamics.ActiveReports.Export.Pdf.PdfExport()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.Number06_2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number06 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label06 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.Number07_2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number07 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label07 = New System.Windows.Forms.Label()
        Me.Combo01 = New System.Windows.Forms.ComboBox()
        Me.CL01 = New System.Windows.Forms.Label()
        Me.Combo02 = New System.Windows.Forms.ComboBox()
        Me.CL02 = New System.Windows.Forms.Label()
        Me.Combo03 = New System.Windows.Forms.ComboBox()
        Me.CL03 = New System.Windows.Forms.Label()
        Me.Combo04 = New System.Windows.Forms.ComboBox()
        Me.CL04 = New System.Windows.Forms.Label()
        Me.Combo05 = New System.Windows.Forms.ComboBox()
        Me.CL05 = New System.Windows.Forms.Label()
        Me.Combo06 = New System.Windows.Forms.ComboBox()
        Me.CL06 = New System.Windows.Forms.Label()
        Me.Combo07 = New System.Windows.Forms.ComboBox()
        Me.CL07 = New System.Windows.Forms.Label()
        CType(Me.Number02_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number01_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number03_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number04_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number05_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number06_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number07_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number07, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Number02_2
        '
        Me.Number02_2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number02_2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number02_2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number02_2.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number02_2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number02_2.HighlightText = True
        Me.Number02_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number02_2.Location = New System.Drawing.Point(920, 131)
        Me.Number02_2.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number02_2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02_2.Name = "Number02_2"
        Me.Number02_2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02_2.Size = New System.Drawing.Size(60, 29)
        Me.Number02_2.TabIndex = 6
        Me.Number02_2.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Number02
        '
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number02.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number02.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number02.HighlightText = True
        Me.Number02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number02.Location = New System.Drawing.Point(850, 131)
        Me.Number02.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02.Name = "Number02"
        Me.Number02.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02.Size = New System.Drawing.Size(60, 29)
        Me.Number02.TabIndex = 5
        Me.Number02.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Number01_2
        '
        Me.Number01_2.BackColor = System.Drawing.SystemColors.Control
        Me.Number01_2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number01_2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number01_2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number01_2.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number01_2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number01_2.HighlightText = True
        Me.Number01_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number01_2.Location = New System.Drawing.Point(920, 92)
        Me.Number01_2.MaxValue = New Decimal(New Integer() {10, 0, 0, 65536})
        Me.Number01_2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01_2.Name = "Number01_2"
        Me.Number01_2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01_2.Size = New System.Drawing.Size(60, 29)
        Me.Number01_2.TabIndex = 2
        Me.Number01_2.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        Me.Number01_2.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Navy
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(850, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(130, 29)
        Me.Label17.TabIndex = 201
        Me.Label17.Text = "余白(ｲﾝﾁ)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Navy
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(920, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 29)
        Me.Label16.TabIndex = 200
        Me.Label16.Text = "上"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(850, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 29)
        Me.Label15.TabIndex = 199
        Me.Label15.Text = "左"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number01
        '
        Me.Number01.BackColor = System.Drawing.SystemColors.Control
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number01.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number01.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number01.HighlightText = True
        Me.Number01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number01.Location = New System.Drawing.Point(850, 92)
        Me.Number01.MaxValue = New Decimal(New Integer() {10, 0, 0, 65536})
        Me.Number01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01.Name = "Number01"
        Me.Number01.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01.Size = New System.Drawing.Size(60, 29)
        Me.Number01.TabIndex = 1
        Me.Number01.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        Me.Number01.Visible = False
        '
        'Label03
        '
        Me.Label03.BackColor = System.Drawing.Color.Navy
        Me.Label03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label03.ForeColor = System.Drawing.Color.White
        Me.Label03.Location = New System.Drawing.Point(20, 169)
        Me.Label03.Name = "Label03"
        Me.Label03.Size = New System.Drawing.Size(180, 30)
        Me.Label03.TabIndex = 185
        Me.Label03.Text = "Label03"
        Me.Label03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.Color.Navy
        Me.Label02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label02.ForeColor = System.Drawing.Color.White
        Me.Label02.Location = New System.Drawing.Point(20, 131)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(180, 29)
        Me.Label02.TabIndex = 184
        Me.Label02.Text = "Label02"
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.Color.Navy
        Me.Label01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label01.ForeColor = System.Drawing.Color.White
        Me.Label01.Location = New System.Drawing.Point(20, 92)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(180, 29)
        Me.Label01.TabIndex = 165
        Me.Label01.Text = "Label01"
        Me.Label01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 426)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(1115, 29)
        Me.msg.TabIndex = 1153
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button01
        '
        Me.Button01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button01.Location = New System.Drawing.Point(20, 465)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(85, 39)
        Me.Button01.TabIndex = 50
        Me.Button01.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(1050, 465)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(85, 39)
        Me.Button98.TabIndex = 60
        Me.Button98.Text = "戻る"
        '
        'Number03_2
        '
        Me.Number03_2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number03_2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number03_2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number03_2.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number03_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number03_2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number03_2.HighlightText = True
        Me.Number03_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number03_2.Location = New System.Drawing.Point(920, 169)
        Me.Number03_2.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number03_2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number03_2.Name = "Number03_2"
        Me.Number03_2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number03_2.Size = New System.Drawing.Size(60, 30)
        Me.Number03_2.TabIndex = 10
        Me.Number03_2.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Number03
        '
        Me.Number03.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number03.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number03.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number03.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number03.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number03.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number03.HighlightText = True
        Me.Number03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number03.Location = New System.Drawing.Point(850, 169)
        Me.Number03.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number03.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number03.Name = "Number03"
        Me.Number03.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number03.Size = New System.Drawing.Size(60, 30)
        Me.Number03.TabIndex = 9
        Me.Number03.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Number04_2
        '
        Me.Number04_2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number04_2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number04_2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number04_2.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number04_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number04_2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number04_2.HighlightText = True
        Me.Number04_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number04_2.Location = New System.Drawing.Point(920, 208)
        Me.Number04_2.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number04_2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number04_2.Name = "Number04_2"
        Me.Number04_2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number04_2.Size = New System.Drawing.Size(60, 29)
        Me.Number04_2.TabIndex = 14
        Me.Number04_2.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Number04
        '
        Me.Number04.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number04.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number04.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number04.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number04.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number04.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number04.HighlightText = True
        Me.Number04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number04.Location = New System.Drawing.Point(850, 208)
        Me.Number04.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number04.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number04.Name = "Number04"
        Me.Number04.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number04.Size = New System.Drawing.Size(60, 29)
        Me.Number04.TabIndex = 13
        Me.Number04.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Label04
        '
        Me.Label04.BackColor = System.Drawing.Color.Navy
        Me.Label04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label04.ForeColor = System.Drawing.Color.White
        Me.Label04.Location = New System.Drawing.Point(20, 208)
        Me.Label04.Name = "Label04"
        Me.Label04.Size = New System.Drawing.Size(180, 29)
        Me.Label04.TabIndex = 1160
        Me.Label04.Text = "Label04"
        Me.Label04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number05_2
        '
        Me.Number05_2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number05_2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number05_2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number05_2.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number05_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number05_2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number05_2.HighlightText = True
        Me.Number05_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number05_2.Location = New System.Drawing.Point(920, 247)
        Me.Number05_2.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number05_2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number05_2.Name = "Number05_2"
        Me.Number05_2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number05_2.Size = New System.Drawing.Size(60, 29)
        Me.Number05_2.TabIndex = 18
        Me.Number05_2.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Number05
        '
        Me.Number05.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number05.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number05.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number05.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number05.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number05.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number05.HighlightText = True
        Me.Number05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number05.Location = New System.Drawing.Point(850, 247)
        Me.Number05.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number05.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number05.Name = "Number05"
        Me.Number05.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number05.Size = New System.Drawing.Size(60, 29)
        Me.Number05.TabIndex = 17
        Me.Number05.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Label05
        '
        Me.Label05.BackColor = System.Drawing.Color.Navy
        Me.Label05.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label05.ForeColor = System.Drawing.Color.White
        Me.Label05.Location = New System.Drawing.Point(20, 247)
        Me.Label05.Name = "Label05"
        Me.Label05.Size = New System.Drawing.Size(180, 29)
        Me.Label05.TabIndex = 1165
        Me.Label05.Text = "Label05"
        Me.Label05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(200, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(640, 29)
        Me.Label1.TabIndex = 1168
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(20, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 29)
        Me.Label2.TabIndex = 1167
        Me.Label2.Text = "ローカルPC名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.Location = New System.Drawing.Point(990, 92)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(55, 29)
        Me.CheckBox1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(985, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 58)
        Me.Label3.TabIndex = 1169
        Me.Label3.Text = "文字化け"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox2
        '
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.Location = New System.Drawing.Point(990, 131)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(55, 29)
        Me.CheckBox2.TabIndex = 7
        '
        'CheckBox3
        '
        Me.CheckBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox3.Location = New System.Drawing.Point(990, 169)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(55, 30)
        Me.CheckBox3.TabIndex = 11
        '
        'CheckBox4
        '
        Me.CheckBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox4.Location = New System.Drawing.Point(990, 208)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(55, 29)
        Me.CheckBox4.TabIndex = 15
        '
        'CheckBox5
        '
        Me.CheckBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox5.Location = New System.Drawing.Point(990, 247)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(55, 29)
        Me.CheckBox5.TabIndex = 19
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1050, 131)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 29)
        Me.Button2.TabIndex = 1170
        Me.Button2.TabStop = False
        Me.Button2.Text = "ﾃｽﾄ印刷"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(1050, 169)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(85, 30)
        Me.Button3.TabIndex = 1171
        Me.Button3.TabStop = False
        Me.Button3.Text = "ﾃｽﾄ印刷"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(1050, 208)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(85, 29)
        Me.Button4.TabIndex = 1172
        Me.Button4.TabStop = False
        Me.Button4.Text = "ﾃｽﾄ印刷"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(1050, 247)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(85, 29)
        Me.Button5.TabIndex = 1173
        Me.Button5.TabStop = False
        Me.Button5.Text = "ﾃｽﾄ印刷"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1050, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 29)
        Me.Button1.TabIndex = 1174
        Me.Button1.TabStop = False
        Me.Button1.Text = "ﾃｽﾄ印刷"
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(1050, 286)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(85, 29)
        Me.Button6.TabIndex = 1181
        Me.Button6.TabStop = False
        Me.Button6.Text = "ﾃｽﾄ印刷"
        '
        'CheckBox6
        '
        Me.CheckBox6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox6.Location = New System.Drawing.Point(990, 286)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(55, 29)
        Me.CheckBox6.TabIndex = 23
        '
        'Number06_2
        '
        Me.Number06_2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number06_2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number06_2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number06_2.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number06_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number06_2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number06_2.HighlightText = True
        Me.Number06_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number06_2.Location = New System.Drawing.Point(920, 286)
        Me.Number06_2.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number06_2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number06_2.Name = "Number06_2"
        Me.Number06_2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number06_2.Size = New System.Drawing.Size(60, 29)
        Me.Number06_2.TabIndex = 22
        Me.Number06_2.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Number06
        '
        Me.Number06.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number06.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number06.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number06.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number06.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number06.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number06.HighlightText = True
        Me.Number06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number06.Location = New System.Drawing.Point(850, 286)
        Me.Number06.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number06.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number06.Name = "Number06"
        Me.Number06.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number06.Size = New System.Drawing.Size(60, 29)
        Me.Number06.TabIndex = 21
        Me.Number06.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Label06
        '
        Me.Label06.BackColor = System.Drawing.Color.Navy
        Me.Label06.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label06.ForeColor = System.Drawing.Color.White
        Me.Label06.Location = New System.Drawing.Point(20, 286)
        Me.Label06.Name = "Label06"
        Me.Label06.Size = New System.Drawing.Size(180, 29)
        Me.Label06.TabIndex = 1179
        Me.Label06.Text = "Label06"
        Me.Label06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(1051, 324)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(85, 29)
        Me.Button7.TabIndex = 1188
        Me.Button7.TabStop = False
        Me.Button7.Text = "ﾃｽﾄ印刷"
        '
        'CheckBox7
        '
        Me.CheckBox7.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox7.Location = New System.Drawing.Point(991, 324)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(55, 29)
        Me.CheckBox7.TabIndex = 1185
        '
        'Number07_2
        '
        Me.Number07_2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number07_2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number07_2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number07_2.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number07_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number07_2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number07_2.HighlightText = True
        Me.Number07_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number07_2.Location = New System.Drawing.Point(921, 324)
        Me.Number07_2.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number07_2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number07_2.Name = "Number07_2"
        Me.Number07_2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number07_2.Size = New System.Drawing.Size(60, 29)
        Me.Number07_2.TabIndex = 26
        Me.Number07_2.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Number07
        '
        Me.Number07.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number07.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number07.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number07.DropDownCalculator.Size = New System.Drawing.Size(302, 272)
        Me.Number07.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Number07.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.0", "", "", "", "", "0.0", "0.0")
        Me.Number07.HighlightText = True
        Me.Number07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number07.Location = New System.Drawing.Point(851, 324)
        Me.Number07.MaxValue = New Decimal(New Integer() {50, 0, 0, 65536})
        Me.Number07.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number07.Name = "Number07"
        Me.Number07.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number07.Size = New System.Drawing.Size(60, 29)
        Me.Number07.TabIndex = 25
        Me.Number07.Value = New Decimal(New Integer() {0, 0, 0, 65536})
        '
        'Label07
        '
        Me.Label07.BackColor = System.Drawing.Color.Navy
        Me.Label07.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label07.ForeColor = System.Drawing.Color.White
        Me.Label07.Location = New System.Drawing.Point(21, 324)
        Me.Label07.Name = "Label07"
        Me.Label07.Size = New System.Drawing.Size(180, 29)
        Me.Label07.TabIndex = 1186
        Me.Label07.Text = "Label07"
        Me.Label07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo01
        '
        Me.Combo01.FormattingEnabled = True
        Me.Combo01.Location = New System.Drawing.Point(207, 92)
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Size = New System.Drawing.Size(637, 31)
        Me.Combo01.TabIndex = 1189
        '
        'CL01
        '
        Me.CL01.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CL01.Location = New System.Drawing.Point(735, 92)
        Me.CL01.Name = "CL01"
        Me.CL01.Size = New System.Drawing.Size(60, 29)
        Me.CL01.TabIndex = 1190
        Me.CL01.Text = "CL01"
        Me.CL01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL01.Visible = False
        '
        'Combo02
        '
        Me.Combo02.FormattingEnabled = True
        Me.Combo02.Location = New System.Drawing.Point(207, 134)
        Me.Combo02.Name = "Combo02"
        Me.Combo02.Size = New System.Drawing.Size(637, 31)
        Me.Combo02.TabIndex = 1191
        '
        'CL02
        '
        Me.CL02.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CL02.Location = New System.Drawing.Point(735, 134)
        Me.CL02.Name = "CL02"
        Me.CL02.Size = New System.Drawing.Size(60, 29)
        Me.CL02.TabIndex = 1192
        Me.CL02.Text = "CL02"
        Me.CL02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL02.Visible = False
        '
        'Combo03
        '
        Me.Combo03.FormattingEnabled = True
        Me.Combo03.Location = New System.Drawing.Point(207, 172)
        Me.Combo03.Name = "Combo03"
        Me.Combo03.Size = New System.Drawing.Size(639, 31)
        Me.Combo03.TabIndex = 1193
        '
        'CL03
        '
        Me.CL03.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CL03.Location = New System.Drawing.Point(736, 173)
        Me.CL03.Name = "CL03"
        Me.CL03.Size = New System.Drawing.Size(60, 30)
        Me.CL03.TabIndex = 1194
        Me.CL03.Text = "CL03"
        Me.CL03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL03.Visible = False
        '
        'Combo04
        '
        Me.Combo04.FormattingEnabled = True
        Me.Combo04.Location = New System.Drawing.Point(207, 211)
        Me.Combo04.Name = "Combo04"
        Me.Combo04.Size = New System.Drawing.Size(639, 31)
        Me.Combo04.TabIndex = 1195
        '
        'CL04
        '
        Me.CL04.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CL04.Location = New System.Drawing.Point(735, 215)
        Me.CL04.Name = "CL04"
        Me.CL04.Size = New System.Drawing.Size(60, 29)
        Me.CL04.TabIndex = 1196
        Me.CL04.Text = "CL04"
        Me.CL04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL04.Visible = False
        '
        'Combo05
        '
        Me.Combo05.FormattingEnabled = True
        Me.Combo05.Location = New System.Drawing.Point(207, 249)
        Me.Combo05.Name = "Combo05"
        Me.Combo05.Size = New System.Drawing.Size(639, 31)
        Me.Combo05.TabIndex = 1197
        '
        'CL05
        '
        Me.CL05.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CL05.Location = New System.Drawing.Point(735, 251)
        Me.CL05.Name = "CL05"
        Me.CL05.Size = New System.Drawing.Size(60, 29)
        Me.CL05.TabIndex = 1198
        Me.CL05.Text = "CL05"
        Me.CL05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL05.Visible = False
        '
        'Combo06
        '
        Me.Combo06.FormattingEnabled = True
        Me.Combo06.Location = New System.Drawing.Point(207, 287)
        Me.Combo06.Name = "Combo06"
        Me.Combo06.Size = New System.Drawing.Size(639, 31)
        Me.Combo06.TabIndex = 1199
        '
        'CL06
        '
        Me.CL06.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CL06.Location = New System.Drawing.Point(735, 289)
        Me.CL06.Name = "CL06"
        Me.CL06.Size = New System.Drawing.Size(60, 29)
        Me.CL06.TabIndex = 1200
        Me.CL06.Text = "CL06"
        Me.CL06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL06.Visible = False
        '
        'Combo07
        '
        Me.Combo07.FormattingEnabled = True
        Me.Combo07.Location = New System.Drawing.Point(208, 327)
        Me.Combo07.Name = "Combo07"
        Me.Combo07.Size = New System.Drawing.Size(638, 31)
        Me.Combo07.TabIndex = 1201
        '
        'CL07
        '
        Me.CL07.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CL07.Location = New System.Drawing.Point(735, 329)
        Me.CL07.Name = "CL07"
        Me.CL07.Size = New System.Drawing.Size(60, 29)
        Me.CL07.TabIndex = 1202
        Me.CL07.Text = "CL07"
        Me.CL07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL07.Visible = False
        '
        'F10_Form51
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 23)
        Me.ClientSize = New System.Drawing.Size(1179, 539)
        Me.Controls.Add(Me.CL07)
        Me.Controls.Add(Me.Combo07)
        Me.Controls.Add(Me.CL06)
        Me.Controls.Add(Me.Combo06)
        Me.Controls.Add(Me.CL05)
        Me.Controls.Add(Me.Combo05)
        Me.Controls.Add(Me.CL04)
        Me.Controls.Add(Me.Combo04)
        Me.Controls.Add(Me.CL03)
        Me.Controls.Add(Me.Combo03)
        Me.Controls.Add(Me.CL02)
        Me.Controls.Add(Me.Combo02)
        Me.Controls.Add(Me.CL01)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.CheckBox7)
        Me.Controls.Add(Me.Number07_2)
        Me.Controls.Add(Me.Number07)
        Me.Controls.Add(Me.Label07)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.CheckBox6)
        Me.Controls.Add(Me.Number06_2)
        Me.Controls.Add(Me.Number06)
        Me.Controls.Add(Me.Label06)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Number05_2)
        Me.Controls.Add(Me.Number05)
        Me.Controls.Add(Me.Label05)
        Me.Controls.Add(Me.Number04_2)
        Me.Controls.Add(Me.Number04)
        Me.Controls.Add(Me.Label04)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button01)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Number03_2)
        Me.Controls.Add(Me.Number03)
        Me.Controls.Add(Me.Number02_2)
        Me.Controls.Add(Me.Number02)
        Me.Controls.Add(Me.Number01_2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Number01)
        Me.Controls.Add(Me.Label03)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label01)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F10_Form51"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "プリンタ設定"
        CType(Me.Number02_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number01_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number03_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number04_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number05_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number06_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number07_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number07, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F10_Form51_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
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

        msg.Text = Nothing
        Label1.Text = P_PC_NAME
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        'コンピュータにインストールされているすべてのプリンタの名前を取得
        DB_OPEN("nMVAR")
        DsCMB.Clear()
        For Each p As String In Printing.PrinterSettings.InstalledPrinters

            Dim int1 As Integer
            int1 = p.LastIndexOf("(リダイレクト")
            WK_p = Trim(PRT_NAME(p))

            If P_PC_NAME2 = "" Then 'Local
                Combo01.Items.Add(WK_p)
                Combo02.Items.Add(WK_p)
                Combo03.Items.Add(WK_p)
                Combo04.Items.Add(WK_p)
                Combo05.Items.Add(WK_p)
                Combo06.Items.Add(WK_p)
                Combo07.Items.Add(WK_p)
            Else                    'TS
                If int1 <> -1 Then  'リダイレクト
                    Combo01.Items.Add(WK_p)
                Else
                    Combo02.Items.Add(WK_p)
                    Combo03.Items.Add(WK_p)
                    Combo04.Items.Add(WK_p)
                    Combo05.Items.Add(WK_p)
                    Combo06.Items.Add(WK_p)
                    Combo07.Items.Add(WK_p)
                End If
            End If

        Next
        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        DsList1.Clear()
        DB_OPEN("nMVAR")

        '印刷物
        strSQL = "SELECT cls_code AS print_cls, cls_code_name AS print_name, cls_code_name_abbr"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '017') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "CLS_CODE_017")

        '印刷設定
        strSQL = "SELECT * FROM M11_PRINTER WHERE (pc_name = '" & P_PC_NAME & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "M11_PRINTER")

        DtView1 = New DataView(DsList1.Tables("CLS_CODE_017"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1

                DtView2 = New DataView(DsList1.Tables("M11_PRINTER"), "print_id ='" & DtView1(i)("print_cls") & "'", "", DataViewRowState.CurrentRows)

                Select Case i
                    Case Is = 0
                        CL01.Text = DtView1(i)("print_cls")
                        Label01.Text = DtView1(i)("print_name")
                        If DtView2.Count <> 0 Then
                            Combo01.Text = DtView2(0)("printer_name")
                            Number01.Value = DtView2(0)("left_mrgn")
                            Number01_2.Value = DtView2(0)("uppr_mrgn")
                            CheckBox1.Checked = False
                            If Not IsDBNull(DtView2(0)("mojibake")) Then
                                If DtView2(0)("mojibake") = "1" Then
                                    CheckBox1.Checked = True
                                End If
                            End If
                        Else
                            Combo01.Text = Nothing
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 1, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number01.Value = WK_mg Else Number01.Value = 0
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 4, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number01_2.Value = WK_mg Else Number01_2.Value = 0
                            CheckBox1.Checked = False
                        End If
                    Case Is = 1
                        CL02.Text = DtView1(i)("print_cls")
                        Label02.Text = DtView1(i)("print_name")
                        If DtView2.Count <> 0 Then
                            Combo02.Text = DtView2(0)("printer_name")
                            Number02.Value = DtView2(0)("left_mrgn")
                            Number02_2.Value = DtView2(0)("uppr_mrgn")
                            CheckBox2.Checked = False
                            If Not IsDBNull(DtView2(0)("mojibake")) Then
                                If DtView2(0)("mojibake") = "1" Then
                                    CheckBox2.Checked = True
                                End If
                            End If
                        Else
                            Combo02.Text = Nothing
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 1, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number02.Value = WK_mg Else Number02.Value = 0
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 4, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number02_2.Value = WK_mg Else Number02_2.Value = 0
                            CheckBox2.Checked = False
                        End If
                    Case Is = 2
                        CL03.Text = DtView1(i)("print_cls")
                        Label03.Text = DtView1(i)("print_name")
                        If DtView2.Count <> 0 Then
                            Combo03.Text = DtView2(0)("printer_name")
                            Number03.Value = DtView2(0)("left_mrgn")
                            Number03_2.Value = DtView2(0)("uppr_mrgn")
                            CheckBox3.Checked = False
                            If Not IsDBNull(DtView2(0)("mojibake")) Then
                                If DtView2(0)("mojibake") = "1" Then
                                    CheckBox3.Checked = True
                                End If
                            End If
                        Else
                            Combo03.Text = Nothing
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 1, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number03.Value = WK_mg Else Number03.Value = 0
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 4, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number03_2.Value = WK_mg Else Number03_2.Value = 0
                            CheckBox3.Checked = False
                        End If
                    Case Is = 3
                        CL04.Text = DtView1(i)("print_cls")
                        Label04.Text = DtView1(i)("print_name")
                        If DtView2.Count <> 0 Then
                            Combo04.Text = DtView2(0)("printer_name")
                            Number04.Value = DtView2(0)("left_mrgn")
                            Number04_2.Value = DtView2(0)("uppr_mrgn")
                            CheckBox4.Checked = False
                            If Not IsDBNull(DtView2(0)("mojibake")) Then
                                If DtView2(0)("mojibake") = "1" Then
                                    CheckBox4.Checked = True
                                End If
                            End If
                        Else
                            Combo04.Text = Nothing
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 1, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number04.Value = WK_mg Else Number04.Value = 0
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 4, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number04_2.Value = WK_mg Else Number04_2.Value = 0
                            CheckBox4.Checked = False
                        End If
                    Case Is = 4
                        CL05.Text = DtView1(i)("print_cls")
                        Label05.Text = DtView1(i)("print_name")
                        If DtView2.Count <> 0 Then
                            Combo05.Text = DtView2(0)("printer_name")
                            Number05.Value = DtView2(0)("left_mrgn")
                            Number05_2.Value = DtView2(0)("uppr_mrgn")
                            CheckBox5.Checked = False
                            If Not IsDBNull(DtView2(0)("mojibake")) Then
                                If DtView2(0)("mojibake") = "1" Then
                                    CheckBox5.Checked = True
                                End If
                            End If
                        Else
                            Combo05.Text = Nothing
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 1, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number05.Value = WK_mg Else Number05.Value = 0
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 4, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number05_2.Value = WK_mg Else Number05_2.Value = 0
                            CheckBox5.Checked = False
                        End If
                    Case Is = 5
                        CL06.Text = DtView1(i)("print_cls")
                        Label06.Text = DtView1(i)("print_name")
                        If DtView2.Count <> 0 Then
                            Combo06.Text = DtView2(0)("printer_name")
                            Number06.Value = DtView2(0)("left_mrgn")
                            Number06_2.Value = DtView2(0)("uppr_mrgn")
                            CheckBox6.Checked = False
                            If Not IsDBNull(DtView2(0)("mojibake")) Then
                                If DtView2(0)("mojibake") = "1" Then
                                    CheckBox6.Checked = True
                                End If
                            End If
                        Else
                            Combo06.Text = Nothing
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 1, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number06.Value = WK_mg Else Number06.Value = 0
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 4, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number06_2.Value = WK_mg Else Number06_2.Value = 0
                            CheckBox6.Checked = False
                        End If
                    Case Is = 6
                        CL07.Text = DtView1(i)("print_cls")
                        Label07.Text = DtView1(i)("print_name")
                        If DtView2.Count <> 0 Then
                            Combo07.Text = DtView2(0)("printer_name")
                            Number07.Value = DtView2(0)("left_mrgn")
                            Number07_2.Value = DtView2(0)("uppr_mrgn")
                            CheckBox7.Checked = False
                            If Not IsDBNull(DtView2(0)("mojibake")) Then
                                If DtView2(0)("mojibake") = "1" Then
                                    CheckBox7.Checked = True
                                End If
                            End If
                        Else
                            Combo07.Text = Nothing
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 1, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number07.Value = WK_mg Else Number07.Value = 0
                            WK_mg = Mid(DtView1(i)("cls_code_name_abbr"), 4, 3)
                            If WK_mg >= 0 And WK_mg <= 1 Then Number07_2.Value = WK_mg Else Number07_2.Value = 0
                            CheckBox7.Checked = False
                        End If
                End Select
            Next
        End If
        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Combo01()
        msg.Text = Nothing

        Combo01.Text = Trim(Combo01.Text)
        If Combo01.Text <> Nothing Then
            If Mid(Combo01.Text, 1, 1) = "\" Then
                If LenB(Combo01.Text) > 100 Then
                    Combo01.BackColor = System.Drawing.Color.Red
                    msg.Text = "プリンタ名は100文字までです。"
                    Exit Sub
                End If
            Else
                Mach_F = "0"
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    Dim int1 As Integer
                    int1 = p.LastIndexOf("(リダイレクト")
                    If int1 <> -1 Or P_PC_NAME2 = "" Then
                        If Combo01.Text = Trim(PRT_NAME(p)) Then Mach_F = "1" : Exit For
                    End If
                Next
                If Mach_F <> "1" Then
                    Combo01.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当プリンタが存在しません。"
                    Exit Sub
                End If
            End If
        End If
        Combo01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo02()
        msg.Text = Nothing

        Combo02.Text = Trim(Combo02.Text)
        If Combo02.Text <> Nothing Then
            If Mid(Combo02.Text, 1, 1) = "\" Then
                If LenB(Combo02.Text) > 100 Then
                    Combo02.BackColor = System.Drawing.Color.Red
                    msg.Text = "プリンタ名は100文字までです。"
                    Exit Sub
                End If
            Else
                Mach_F = "0"
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    Dim int1 As Integer
                    int1 = p.LastIndexOf("(リダイレクト")
                    If int1 <> -1 Or P_PC_NAME2 = "" Then
                        If Combo02.Text = Trim(PRT_NAME(p)) Then Mach_F = "1" : Exit For
                    End If
                Next
                If Mach_F <> "1" Then
                    Combo02.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当プリンタが存在しません。"
                    Exit Sub
                End If
            End If
        End If
        Combo02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo03()
        msg.Text = Nothing

        Combo03.Text = Trim(Combo03.Text)
        If Combo03.Text <> Nothing Then
            If Mid(Combo03.Text, 1, 1) = "\" Then
                If LenB(Combo03.Text) > 100 Then
                    Combo03.BackColor = System.Drawing.Color.Red
                    msg.Text = "プリンタ名は100文字までです。"
                    Exit Sub
                End If
            Else
                Mach_F = "0"
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    Dim int1 As Integer
                    int1 = p.LastIndexOf("(リダイレクト")
                    If int1 <> -1 Or P_PC_NAME2 = "" Then
                        If Combo03.Text = Trim(PRT_NAME(p)) Then Mach_F = "1" : Exit For
                    End If
                Next
                If Mach_F <> "1" Then
                    Combo03.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当プリンタが存在しません。"
                    Exit Sub
                End If
            End If
        End If
        Combo03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo04()
        msg.Text = Nothing

        Combo04.Text = Trim(Combo04.Text)
        If Combo04.Text <> Nothing Then
            If Mid(Combo04.Text, 1, 1) = "\" Then
                If LenB(Combo04.Text) > 100 Then
                    Combo04.BackColor = System.Drawing.Color.Red
                    msg.Text = "プリンタ名は100文字までです。"
                    Exit Sub
                End If
            Else
                Mach_F = "0"
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    Dim int1 As Integer
                    int1 = p.LastIndexOf("(リダイレクト")
                    If int1 <> -1 Or P_PC_NAME2 = "" Then
                        If Combo04.Text = Trim(PRT_NAME(p)) Then Mach_F = "1" : Exit For
                    End If
                Next
                If Mach_F <> "1" Then
                    Combo04.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当プリンタが存在しません。"
                    Exit Sub
                End If
            End If
        End If
        Combo04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo05()
        msg.Text = Nothing

        Combo05.Text = Trim(Combo05.Text)
        If Combo05.Text <> Nothing Then
            If Mid(Combo05.Text, 1, 1) = "\" Then
                If LenB(Combo05.Text) > 100 Then
                    Combo05.BackColor = System.Drawing.Color.Red
                    msg.Text = "プリンタ名は100文字までです。"
                    Exit Sub
                End If
            Else
                Mach_F = "0"
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    Dim int1 As Integer
                    int1 = p.LastIndexOf("(リダイレクト")
                    If int1 <> -1 Or P_PC_NAME2 = "" Then
                        If Combo05.Text = Trim(PRT_NAME(p)) Then Mach_F = "1" : Exit For
                    End If
                Next
                If Mach_F <> "1" Then
                    Combo05.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当プリンタが存在しません。"
                    Exit Sub
                End If
            End If
        End If
        Combo05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo06()
        msg.Text = Nothing

        Combo06.Text = Trim(Combo06.Text)
        If Combo06.Text <> Nothing Then
            If Mid(Combo06.Text, 1, 1) = "\" Then
                If LenB(Combo06.Text) > 100 Then
                    Combo06.BackColor = System.Drawing.Color.Red
                    msg.Text = "プリンタ名は100文字までです。"
                    Exit Sub
                End If
            Else
                Mach_F = "0"
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    Dim int1 As Integer
                    int1 = p.LastIndexOf("(リダイレクト")
                    If int1 <> -1 Or P_PC_NAME2 = "" Then
                        If Combo06.Text = Trim(PRT_NAME(p)) Then Mach_F = "1" : Exit For
                    End If
                Next
                If Mach_F <> "1" Then
                    Combo06.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当プリンタが存在しません。"
                    Exit Sub
                End If
            End If
        End If
        Combo06.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo07()
        msg.Text = Nothing

        Combo07.Text = Trim(Combo07.Text)
        If Combo07.Text <> Nothing Then
            If Mid(Combo07.Text, 1, 1) = "\" Then
                If LenB(Combo07.Text) > 100 Then
                    Combo07.BackColor = System.Drawing.Color.Red
                    msg.Text = "プリンタ名は100文字までです。"
                    Exit Sub
                End If
            Else
                Mach_F = "0"
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    Dim int1 As Integer
                    int1 = p.LastIndexOf("(リダイレクト")
                    If int1 <> -1 Or P_PC_NAME2 = "" Then
                        If Combo07.Text = Trim(PRT_NAME(p)) Then Mach_F = "1" : Exit For
                    End If
                Next
                If Mach_F <> "1" Then
                    Combo07.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当プリンタが存在しません。"
                    Exit Sub
                End If
            End If
        End If
        Combo07.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        CHK_Combo01()
        If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

        CHK_Combo02()
        If msg.Text <> Nothing Then Err_F = "1" : Combo02.Focus() : Exit Sub

        CHK_Combo03()
        If msg.Text <> Nothing Then Err_F = "1" : Combo03.Focus() : Exit Sub

        CHK_Combo04()
        If msg.Text <> Nothing Then Err_F = "1" : Combo04.Focus() : Exit Sub

        CHK_Combo05()
        If msg.Text <> Nothing Then Err_F = "1" : Combo05.Focus() : Exit Sub

        CHK_Combo06()
        If msg.Text <> Nothing Then Err_F = "1" : Combo06.Focus() : Exit Sub

        CHK_Combo07()
        If msg.Text <> Nothing Then Err_F = "1" : Combo07.Focus() : Exit Sub

    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Combo01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo02_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo03_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo03.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo04_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo04.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo05_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo06_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo06.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo07_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.GotFocus
        Number01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number01_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01_2.GotFocus
        Number01_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number02_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.GotFocus
        Number02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number02_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02_2.GotFocus
        Number02_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number03_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03.GotFocus
        Number03.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number03_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03_2.GotFocus
        Number03_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number04_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04.GotFocus
        Number04.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number04_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04_2.GotFocus
        Number04_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number05_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05.GotFocus
        Number05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number05_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05_2.GotFocus
        Number05_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.GotFocus
        CheckBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.GotFocus
        CheckBox2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.GotFocus
        CheckBox3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.GotFocus
        CheckBox4.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox5.GotFocus
        CheckBox5.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CHK_Combo01()
    End Sub
    Private Sub Combo02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CHK_Combo02()
    End Sub
    Private Sub Combo03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CHK_Combo03()
    End Sub
    Private Sub Combo04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CHK_Combo04()
    End Sub
    Private Sub Combo05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CHK_Combo05()
    End Sub
    Private Sub Combo06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CHK_Combo06()
    End Sub
    Private Sub Combo07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CHK_Combo07()
    End Sub
    Private Sub Number01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.LostFocus
        Number01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number01_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01_2.LostFocus
        Number01_2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.LostFocus
        Number02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number02_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02_2.LostFocus
        Number02_2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03.LostFocus
        Number03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number03_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03_2.LostFocus
        Number03_2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04.LostFocus
        Number04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number04_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04_2.LostFocus
        Number04_2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05.LostFocus
        Number05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number05_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05_2.LostFocus
        Number05_2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub CheckBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.LostFocus
        CheckBox1.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.LostFocus
        CheckBox2.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.LostFocus
        CheckBox3.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.LostFocus
        CheckBox4.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox5.LostFocus
        CheckBox5.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button01.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  項目チェック
        If Err_F = "0" Then

            cd(1) = CL01.Text : prt(1) = Combo01.Text : up_mg(1) = 0 : lt_mg(1) = 0 : moji(1) = CheckBox1.Checked
            cd(2) = CL02.Text : prt(2) = Combo02.Text : up_mg(2) = Number02_2.Value : lt_mg(2) = Number02.Value : moji(2) = CheckBox2.Checked
            cd(3) = CL03.Text : prt(3) = Combo03.Text : up_mg(3) = Number03_2.Value : lt_mg(3) = Number03.Value : moji(3) = CheckBox3.Checked
            cd(4) = CL04.Text : prt(4) = Combo04.Text : up_mg(4) = Number04_2.Value : lt_mg(4) = Number04.Value : moji(4) = CheckBox4.Checked
            cd(5) = CL05.Text : prt(5) = Combo05.Text : up_mg(5) = Number05_2.Value : lt_mg(5) = Number05.Value : moji(5) = CheckBox5.Checked
            cd(6) = CL06.Text : prt(6) = Combo06.Text : up_mg(6) = Number06_2.Value : lt_mg(6) = Number06.Value : moji(6) = CheckBox6.Checked
            cd(7) = CL07.Text : prt(7) = Combo07.Text : up_mg(7) = Number07_2.Value : lt_mg(7) = Number07.Value : moji(7) = CheckBox7.Checked
            DB_OPEN("nMVAR")

            For i = 1 To 7
                DtView1 = New DataView(DsList1.Tables("M11_PRINTER"), "print_id ='" & cd(i) & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    strSQL = "INSERT INTO M11_PRINTER"
                    strSQL += " (pc_name, print_id, printer_name, uppr_mrgn, left_mrgn, mojibake)"
                    strSQL += " VALUES ('" & P_PC_NAME & "'"
                    strSQL += ", '" & cd(i) & "'"
                    strSQL += ", '" & prt(i) & "'"
                    strSQL += ", " & up_mg(i)
                    strSQL += ", " & lt_mg(i) & ""
                    If moji(i) = "True" Then strSQL += ", 1)"
                    If moji(i) = "False" Then strSQL += ", 0)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                Else
                    strSQL = "UPDATE M11_PRINTER"
                    strSQL += " SET printer_name = '" & prt(i) & "'"
                    strSQL += ", uppr_mrgn = " & up_mg(i)
                    strSQL += ", left_mrgn = " & lt_mg(i)
                    If moji(i) = "True" Then strSQL += ", mojibake = 1"
                    If moji(i) = "False" Then strSQL += ", mojibake = 0"
                    strSQL += " WHERE (pc_name = '" & P_PC_NAME & "')"
                    strSQL += " AND (print_id = '" & cd(i) & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                End If
            Next

            DB_CLOSE()
            msg.Text = "更新しました。"
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        DsCMB.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  ﾃｽﾄ印刷
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        printer = Nothing
        P_DsPRT.Clear()

        'メインデータ
        strSQL = "SELECT 'Ａｐｐｌｅ' AS vndr_name, 'ABC1234' AS store_repr_no, 'AP000000' AS rcpt_no, '2008/10/01' AS accp_date"
        strSQL += ", '10月01日' AS accp_date2, '001' AS rpar_cls, '有償' AS cls_code_name, 'OW' AS cls_code_name_abbr"
        strSQL += ", '01' AS arvl_cls, '持込（一般）' AS arvl_cls_name, 999 AS arvl_empl, 'ＧＳＳ　太郎' AS arvl_empl_name"
        strSQL += ", '01' AS rcpt_cls, '通常' AS rcpt_cls_name, 'model_1' AS model_1, 'model_2' AS model_2, 's_n123456789' AS s_n"
        strSQL += ", '05' AS rpar_comp_code, 'QG秋葉原' AS rpar_comp_name, 'ＸＸ販社' AS store_name, '03-1111-2222' AS tel"
        strSQL += ", '03-1111-3333' AS fax, '芝浦　一郎' AS user_name, '03-4444-5555' AS tel1"
        strSQL += ", '起動してもブルー画面で作動せず。' AS user_trbl, 'データ消去了承済みです。' AS rcpt_comn, 0 AS idvd_flg"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        '付属品データ
        strSQL = "SELECT 1 AS seq, 1 AS item_code, '保証書' AS item_name, 1 AS amnt, '枚' AS item_unit"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print02")

        '受付内容データ
        strSQL = "SELECT 1 AS seq, '電源は入るが起動しない。' AS cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        printer = PRT_test_GET(Combo01.Text, CheckBox1.Checked, "1")  '**  プリンタ名編集

        Dim rpt As New SectionReport_R_Azukari_Sheet
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            ' PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "お預かりシート"
            rpt.Document.Print(False, False, False)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        printer = Nothing
        P_DsPRT.Clear()

        'メインデータ
        strSQL = "SELECT 'ＸＸ販社　○○店' AS Expr01, '12345' AS Expr02, 'ＸＸ販社　○○店' AS Expr03, '67890' AS Expr04"
        strSQL += ", '10' AS Expr05, 'グローバルソリューションサービス㈱' AS Expr06, 'FQG' AS Expr07"
        strSQL += ", '〒141-0031 東京都品川区西五反田７－２２－１７ TOCビル６Ｆ' AS Expr08"
        strSQL += ", 'TEL : 03-5740-0196 FAX : 03-5719-6148' AS Expr09, 'AP0000000' AS Expr10, 'Ａｐｐｌｅ' AS Expr11"
        strSQL += ", '機種名' AS Expr12, 's_n123456789' AS Expr13, '999999' AS Expr14, '0000' AS Expr15, 'ＸＸ販社　○○店' AS Expr16"
        strSQL += ", 'AP0000000' AS Expr17, '機種名' AS Expr18, '芝浦　一郎 様分' AS Expr19"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        printer = PRT_test_GET(Combo02.Text, CheckBox2.Checked, "0")  '**  プリンタ名編集

        Dim rpt As New SectionReport_R_NEVA
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.PageSettings.Margins.Left = Number02.Value
        rpt.PageSettings.Margins.Top = Number02_2.Value
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            ' PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
        Else
            MsgBox(printer)
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "ネバ伝"
            rpt.Document.Print(False, False, False)
        End If
        'PdfExport1.Export(rpt.Document, "\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        printer = Nothing
        P_DsPRT.Clear()

        'メインデータ
        strSQL = "SELECT 'ＸＸ販社' AS Expr01, '○○店' AS Expr02, '999999' AS Expr03, '00-02' AS Expr04, 'ＧＳＳ　太郎' AS Expr05"
        strSQL += ", 'ｸﾞﾛｰﾊﾞﾙｿﾘｭｰｼｮﾝｻｰﾋﾞｽ㈱' AS Expr06, 'ＱＧ渋谷' AS Expr07"
        strSQL += ", '〒141-0031 東京都品川区西五反田７－２２－１７ TOCビル６Ｆ' AS Expr08"
        strSQL += ", '03-5740-0196' AS Expr09, '03-5719-6148' AS Expr10"
        strSQL += ", '09/08/01' AS Expr11, '09/08/31' AS Expr12"
        strSQL += ", 'Ａｐｐｌｅ 修理品' AS Expr21, 'AP0000000' AS Expr22, '芝浦　一郎 様分' AS Expr23"
        strSQL += ", '機種名' AS Expr24, '通常　自己負担分' AS Expr25, '予備' AS Expr26, 'ＸＸ販社' AS Expr27"
        strSQL += ", '999999' AS Expr31"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        printer = PRT_test_GET(Combo03.Text, CheckBox3.Checked, "0")  '**  プリンタ名編集

        Dim rpt As New SectionReport_R_CSTD_Normal
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.PageSettings.Margins.Left = Number03.Value
        rpt.PageSettings.Margins.Top = Number03_2.Value
        'rpt.Document.Printer.PrinterName = ""
        'rpt.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")

            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "チェーンストア伝票"
            rpt.Document.Print(False, False, False)
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        printer = Nothing
        DsList1.Clear()

        'メインデータ
        strSQL = "SELECT 'AP0000000' AS rcpt_no, '芝浦　一郎' AS user_name, '4228017' AS zip, '静岡市駿河区大谷' AS adrs1"
        strSQL += ", '' AS adrs2, '090-1123-4567' AS tel1, '14' AS brch_code, 'GSS QG西梅田' AS brch_name"
        strSQL += ", '5530003' AS brch_zip, '大阪府大阪市福島区福島７－２０－１' AS brch_adrs1"
        strSQL += ", 'ＫＭ西梅田ビル１０Ｆ' AS brch_adrs2, '06-4799-7296' AS brch_tel, '0123' AS store_code"
        strSQL += ", 'ＸＸ販社　○○店' AS store_name, '2760047' AS store_zip, '千葉県八千代市吉橋' AS store_adrs1"
        strSQL += ", '' AS store_adrs2, '047-1111-2222' AS store_tel, 'abc000000' AS store_repr_no, '01' AS comp_code"
        strSQL += ", 'グローバルソリューションサービス㈱' AS comp_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")
        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)

        printer = PRT_test_GET(Combo04.Text, CheckBox4.Checked, "0")  '**  プリンタ名編集

        Dim rpt As New SectionReport_R_Haiso_Meitetu_Ren_EU_QG
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.PageSettings.Margins.Left = Number04.Value
        rpt.PageSettings.Margins.Top = Number04_2.Value
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "送り状"
            rpt.Document.Print(False, False, False)
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        printer = Nothing
        P_DsPRT.Clear()

        'メインデータ
        strSQL = "SELECT 'AP0000000' AS rcpt_no, '千葉県八千代市吉橋' AS adrs1, '' AS adrs2, 'ＸＸ販社　○○店' AS store_name"
        strSQL += ", 'model_1' AS model_1, 'model_2' AS model_2, '芝浦　一郎' AS user_name, 'GSS QG西梅田' AS brch_name"
        strSQL += ", '6244' AS uca_code, 'ＧＳＳ　太郎' AS mngr_empl_name, 999999 AS comp_shop_tech_chrg"
        strSQL += ", 999999 AS comp_shop_part_chrg, 999999 AS comp_shop_fee, 999999 AS comp_shop_pstg, 99999 AS comp_shop_tax"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        '部品データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = "1"
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(P_DsPRT, "Print05")
        DB_CLOSE()

        printer = PRT_test_GET(Combo05.Text, CheckBox5.Checked, "0")  '**  プリンタ名編集

        Dim rpt As New SectionReport_R_NCR_CCAR
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.PageSettings.Margins.Left = Number05.Value
        rpt.PageSettings.Margins.Top = Number05_2.Value
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            '  PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "ＣＣＡＲ"
            rpt.Document.Print(False, False, False)
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        printer = Nothing
        P_DsPRT.Clear()

        'メインデータ
        strSQL = "SELECT 'AP0000000' AS rcpt_no, 'model_1' AS model_1, 'model_2' AS model_2, 's/n9999999999' AS s_n"
        strSQL += ", '芝浦　一郎' AS user_name, '千葉県八千代市吉橋' AS adrs1, 'XXビル1F' AS adrs2, '090-1111-2222' AS tel1"
        strSQL += ", '2008/10/01' AS accp_date, '2008/09/01' AS vndr_wrn_date, '2008/10/10' AS comp_date"
        strSQL += ", 10000 AS comp_eu_tech_chrg, 20000 AS comp_eu_part_chrg, 1000 AS comp_eu_fee, 2000 AS comp_eu_pstg, 1650 AS comp_eu_tax"
        strSQL += ", '起動してもブルー画面で作動せず。' AS user_trbl, 'マルチメディアリーダーを交換しました。' AS comp_meas"
        strSQL += ", 'ＧＳＳ　太郎' AS repr_empl_name, 'GSS QG西梅田' AS brch_name, '山田　太郎' AS mngr_name"
        strSQL += ", '06-4799-7296' AS tel, '06-6450-0068' AS fax, '20' AS accp_date2_y, '10' AS accp_date2_m"
        strSQL += ", '01' AS accp_date2_d, '20' AS vndr_wrn_date2_y, '09' AS vndr_wrn_date2_m, '01' AS vndr_wrn_date2_d"
        strSQL += ", '20' AS comp_date2_y, '10' AS comp_date2_m, '10' AS comp_date2_d, '123456789' AS atri_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        '受付内容データ
        strSQL = "SELECT 1 AS seq, '電源は入るが起動しない。' AS cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '修理内容データ
        strSQL = "SELECT 1 AS seq, 'OSインストールいたしました。' AS cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print06")

        '部品データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = "1"
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(P_DsPRT, "Print05")
        DB_CLOSE()

        printer = PRT_test_GET(Combo06.Text, CheckBox6.Checked, "0")  '**  プリンタ名編集

        Dim rpt As New SectionReport_R_IBM_IW_Report
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.PageSettings.Margins.Left = Number06.Value
        rpt.PageSettings.Margins.Top = Number06_2.Value
        rpt.Run(False)
        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            ''PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "IBM保証報告書"
            rpt.Document.Print(False, False, False)
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        printer = Nothing
        P_DsPRT.Clear()

        'メインデータ
        strSQL = "SELECT 'AP0000000' AS rcpt_no, 'model_1' AS model_1, 'model_2' AS model_2, 's/n9999999999' AS s_n"
        strSQL += ", '芝浦　一郎' AS user_name, '千葉県八千代市吉橋' AS adrs1, 'XXビル1F' AS adrs2, '090-1111-2222' AS tel1"
        strSQL += ", '2008/10/01' AS accp_date, '2008/09/01' AS vndr_wrn_date, '2008/10/10' AS comp_date"
        strSQL += ", 10000 AS comp_eu_tech_chrg, 20000 AS comp_eu_part_chrg, 1000 AS comp_eu_fee, 2000 AS comp_eu_pstg, 1650 AS comp_eu_tax"
        strSQL += ", '起動してもブルー画面で作動せず。' AS user_trbl, 'マルチメディアリーダーを交換しました。' AS comp_meas"
        strSQL += ", 'ＧＳＳ　太郎' AS repr_empl_name, 'GSS QG西梅田' AS brch_name, '山田　太郎' AS mngr_name"
        strSQL += ", '06-4799-7296' AS tel, '06-6450-0068' AS fax, '2008' AS accp_date2_y, '10' AS accp_date2_m"
        strSQL += ", '01' AS accp_date2_d, '2008' AS vndr_wrn_date2_y, '09' AS vndr_wrn_date2_m, '01' AS vndr_wrn_date2_d"
        strSQL += ", '2008' AS comp_date2_y, '10' AS comp_date2_m, '10' AS comp_date2_d, '123456789' AS atri_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        '受付内容データ
        strSQL = "SELECT 1 AS seq, '電源は入るが起動しない。' AS cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '修理内容データ
        strSQL = "SELECT 1 AS seq, 'OSインストールいたしました。' AS cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print06")

        '部品データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = "1"
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(P_DsPRT, "Print05")
        DB_CLOSE()

        printer = PRT_test_GET(Combo07.Text, CheckBox7.Checked, "0")  '**  プリンタ名編集

        Dim rpt As New SectionReport_R_HP_Exc_TAG
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.PageSettings.Margins.Left = Number07.Value
        rpt.PageSettings.Margins.Top = Number07_2.Value
        rpt.Run(False)
        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            ' PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "Hp TAG"
            rpt.Document.Print(False, False, False)
        End If
    End Sub
End Class