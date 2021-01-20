Public Class Form2
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2, DsCmb1, DsCmb2, DsCmb3, DsCmb4, DsCmb5, DsCmb6 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, Err_F, WK_Err_msg As String
    Dim i, j, r, k As Integer
    'Dim div1, div2, div3 As Integer
    'Dim mod1, mod2, mod3 As Integer

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
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents MSG As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label00 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date4 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date3 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Number6 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number4 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number3 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Number5 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number7 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number8 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit6 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit7 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit8 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit9 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit10 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit11 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit12 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit13 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents L_Err_seq As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Date4 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Date3 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Number6 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number4 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number3 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Date2 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.MSG = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label00 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Date1 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Number5 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number7 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number8 = New GrapeCity.Win.Input.Interop.Number()
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit3 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit4 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit5 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit6 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit7 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit8 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit9 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit10 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit11 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit12 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit13 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Mask1 = New GrapeCity.Win.Input.Interop.Mask()
        Me.L_Err_seq = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label48 = New System.Windows.Forms.Label()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(12, 304)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(96, 24)
        Me.Label47.TabIndex = 194
        Me.Label47.Text = "元伝No"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(12, 528)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(96, 24)
        Me.Label46.TabIndex = 193
        Me.Label46.Text = "TEL"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date4
        '
        Me.Date4.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date4.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date4.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date4.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date4.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date4.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date4.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date4.Location = New System.Drawing.Point(508, 432)
        Me.Date4.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2090, 12, 31, 23, 59, 59, 0))
        Me.Date4.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date4.Name = "Date4"
        Me.Date4.Size = New System.Drawing.Size(104, 24)
        Me.Date4.TabIndex = 27
        Me.Date4.Value = Nothing
        '
        'Date3
        '
        Me.Date3.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date3.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date3.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date3.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date3.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date3.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date3.Location = New System.Drawing.Point(112, 272)
        Me.Date3.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2090, 12, 31, 23, 59, 59, 0))
        Me.Date3.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date3.Name = "Date3"
        Me.Date3.Size = New System.Drawing.Size(104, 24)
        Me.Date3.TabIndex = 8
        Me.Date3.Value = Nothing
        '
        'Number6
        '
        Me.Number6.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number6.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number6.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number6.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number6.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number6.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number6.HighlightText = True
        Me.Number6.Location = New System.Drawing.Point(508, 560)
        Me.Number6.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number6.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number6.Name = "Number6"
        Me.Number6.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number6.Size = New System.Drawing.Size(96, 24)
        Me.Number6.TabIndex = 31
        Me.Number6.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Number4
        '
        Me.Number4.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number4.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,##0", "", "", "-", "", "", "")
        Me.Number4.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number4.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number4.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number4.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,##0", "", "", "-", "", "", "")
        Me.Number4.HighlightText = True
        Me.Number4.Location = New System.Drawing.Point(508, 368)
        Me.Number4.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number4.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number4.Name = "Number4"
        Me.Number4.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number4.Size = New System.Drawing.Size(104, 24)
        Me.Number4.TabIndex = 25
        Me.Number4.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Number3
        '
        Me.Number3.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number3.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,##0", "", "", "-", "", "", "")
        Me.Number3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number3.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number3.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number3.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,##0", "", "", "-", "", "", "")
        Me.Number3.HighlightText = True
        Me.Number3.Location = New System.Drawing.Point(508, 336)
        Me.Number3.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number3.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number3.Name = "Number3"
        Me.Number3.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number3.Size = New System.Drawing.Size(104, 24)
        Me.Number3.TabIndex = 24
        Me.Number3.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Number2
        '
        Me.Number2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number2.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number2.HighlightText = True
        Me.Number2.Location = New System.Drawing.Point(508, 304)
        Me.Number2.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Name = "Number2"
        Me.Number2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Size = New System.Drawing.Size(104, 24)
        Me.Number2.TabIndex = 23
        Me.Number2.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Date2
        '
        Me.Date2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date2.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date2.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date2.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date2.Location = New System.Drawing.Point(112, 240)
        Me.Date2.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2090, 12, 31, 23, 59, 59, 0))
        Me.Date2.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date2.Name = "Date2"
        Me.Date2.Size = New System.Drawing.Size(104, 24)
        Me.Date2.TabIndex = 7
        Me.Date2.Value = Nothing
        '
        'MSG
        '
        Me.MSG.ForeColor = System.Drawing.Color.Red
        Me.MSG.Location = New System.Drawing.Point(116, 640)
        Me.MSG.Name = "MSG"
        Me.MSG.Size = New System.Drawing.Size(488, 24)
        Me.MSG.TabIndex = 186
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(616, 636)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 32)
        Me.Button2.TabIndex = 34
        Me.Button2.TabStop = False
        Me.Button2.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 636)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 32)
        Me.Button1.TabIndex = 33
        Me.Button1.TabStop = False
        Me.Button1.Text = "更新"
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(396, 436)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(108, 24)
        Me.Label39.TabIndex = 182
        Me.Label39.Text = "ﾃﾞｰﾀ処理日"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(396, 564)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(108, 24)
        Me.Label38.TabIndex = 180
        Me.Label38.Text = "保証料"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(12, 272)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 24)
        Me.Label37.TabIndex = 178
        Me.Label37.Text = "取消日"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(396, 244)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(108, 24)
        Me.Label33.TabIndex = 170
        Me.Label33.Text = "商品ｺｰﾄﾞ"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(396, 276)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(108, 24)
        Me.Label32.TabIndex = 168
        Me.Label32.Text = "型式"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(396, 372)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(108, 24)
        Me.Label23.TabIndex = 150
        Me.Label23.Text = "購入数量"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(508, 212)
        Me.ComboBox4.MaxDropDownItems = 10
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(200, 24)
        Me.ComboBox4.TabIndex = 20
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(396, 116)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 24)
        Me.Label20.TabIndex = 144
        Me.Label20.Text = "大分類"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(12, 208)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 24)
        Me.Label19.TabIndex = 142
        Me.Label19.Text = "受注日"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(396, 340)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 24)
        Me.Label18.TabIndex = 141
        Me.Label18.Text = "税額"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(396, 308)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 24)
        Me.Label17.TabIndex = 138
        Me.Label17.Text = "売価"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label00
        '
        Me.Label00.ForeColor = System.Drawing.Color.Red
        Me.Label00.Location = New System.Drawing.Point(248, 12)
        Me.Label00.Name = "Label00"
        Me.Label00.Size = New System.Drawing.Size(516, 24)
        Me.Label00.TabIndex = 135
        Me.Label00.Text = "Label00"
        Me.Label00.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox5
        '
        Me.ComboBox5.Location = New System.Drawing.Point(508, 400)
        Me.ComboBox5.MaxDropDownItems = 10
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(200, 24)
        Me.ComboBox5.TabIndex = 26
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(396, 404)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 24)
        Me.Label15.TabIndex = 133
        Me.Label15.Text = "店舗"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Yellow
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(12, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 24)
        Me.Label14.TabIndex = 131
        Me.Label14.Text = "Error SEQ："
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(396, 596)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 24)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "保証月数"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(396, 500)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 24)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "保証商品コード"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 432)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 24)
        Me.Label11.TabIndex = 128
        Me.Label11.Text = "郵便番号"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(12, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 24)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "保証種類"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 24)
        Me.Label9.TabIndex = 125
        Me.Label9.Text = "システム区分"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 496)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 24)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "住所2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 464)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 24)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "住所1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 400)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 24)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "顧客名"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(396, 532)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 24)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "保証商品型式"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 368)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 24)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "顧客番号"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "行№"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 24)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "受注№"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox6
        '
        Me.ComboBox6.BackColor = System.Drawing.Color.White
        Me.ComboBox6.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ComboBox6.Items.AddRange(New Object() {"A", "C"})
        Me.ComboBox6.Location = New System.Drawing.Point(112, 112)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(176, 24)
        Me.ComboBox6.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "取引種類"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadioButton1
        '
        Me.RadioButton1.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton1.Location = New System.Drawing.Point(8, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "B"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton2.Location = New System.Drawing.Point(84, 12)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Y"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'Date1
        '
        Me.Date1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date1.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(112, 208)
        Me.Date1.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2090, 12, 31, 23, 59, 59, 0))
        Me.Date1.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(104, 24)
        Me.Date1.TabIndex = 6
        Me.Date1.Value = Nothing
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(12, 240)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(96, 24)
        Me.Label49.TabIndex = 198
        Me.Label49.Text = "完了日"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(12, 336)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(96, 24)
        Me.Label50.TabIndex = 201
        Me.Label50.Text = "赤伝No"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(508, 112)
        Me.ComboBox1.MaxDropDownItems = 10
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(200, 24)
        Me.ComboBox1.TabIndex = 17
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(396, 148)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(108, 24)
        Me.Label51.TabIndex = 202
        Me.Label51.Text = "中分類"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(508, 144)
        Me.ComboBox2.MaxDropDownItems = 10
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(200, 24)
        Me.ComboBox2.TabIndex = 18
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(396, 180)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(108, 24)
        Me.Label52.TabIndex = 204
        Me.Label52.Text = "小分類"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(508, 176)
        Me.ComboBox3.MaxDropDownItems = 10
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(200, 24)
        Me.ComboBox3.TabIndex = 19
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(396, 212)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(108, 24)
        Me.Label53.TabIndex = 206
        Me.Label53.Text = "メーカー"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(396, 468)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(108, 24)
        Me.Label21.TabIndex = 208
        Me.Label21.Text = "データ連番"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Number5
        '
        Me.Number5.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number5.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number5.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number5.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number5.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number5.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number5.HighlightText = True
        Me.Number5.Location = New System.Drawing.Point(508, 464)
        Me.Number5.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number5.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number5.Name = "Number5"
        Me.Number5.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number5.Size = New System.Drawing.Size(72, 24)
        Me.Number5.TabIndex = 28
        Me.Number5.Value = Nothing
        '
        'Number7
        '
        Me.Number7.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number7.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,##0", "", "", "-", "", "", "")
        Me.Number7.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number7.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number7.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number7.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,##0", "", "", "-", "", "", "")
        Me.Number7.HighlightText = True
        Me.Number7.Location = New System.Drawing.Point(508, 592)
        Me.Number7.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number7.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number7.Name = "Number7"
        Me.Number7.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number7.Size = New System.Drawing.Size(96, 24)
        Me.Number7.TabIndex = 32
        Me.Number7.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Number8
        '
        Me.Number8.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number8.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,##0", "", "", "-", "", "", "")
        Me.Number8.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number8.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number8.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number8.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,##0", "", "", "-", "", "", "")
        Me.Number8.HighlightText = True
        Me.Number8.Location = New System.Drawing.Point(112, 176)
        Me.Number8.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number8.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number8.Name = "Number8"
        Me.Number8.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number8.Size = New System.Drawing.Size(32, 24)
        Me.Number8.TabIndex = 5
        Me.Number8.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Edit1
        '
        Me.Edit1.Location = New System.Drawing.Point(112, 144)
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Size = New System.Drawing.Size(144, 24)
        Me.Edit1.TabIndex = 3
        Me.Edit1.Text = "Edit1"
        '
        'Edit2
        '
        Me.Edit2.Location = New System.Drawing.Point(260, 144)
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Size = New System.Drawing.Size(28, 24)
        Me.Edit2.TabIndex = 4
        Me.Edit2.Text = "Edit2"
        Me.Edit2.Visible = False
        '
        'Edit3
        '
        Me.Edit3.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit3.Location = New System.Drawing.Point(112, 304)
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Size = New System.Drawing.Size(180, 24)
        Me.Edit3.TabIndex = 9
        Me.Edit3.Text = "Edit3"
        '
        'Edit4
        '
        Me.Edit4.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit4.Location = New System.Drawing.Point(112, 336)
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Size = New System.Drawing.Size(180, 24)
        Me.Edit4.TabIndex = 10
        Me.Edit4.Text = "Edit4"
        '
        'Edit5
        '
        Me.Edit5.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit5.Location = New System.Drawing.Point(112, 368)
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Size = New System.Drawing.Size(180, 24)
        Me.Edit5.TabIndex = 11
        Me.Edit5.Text = "Edit5"
        '
        'Edit6
        '
        Me.Edit6.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit6.Location = New System.Drawing.Point(112, 400)
        Me.Edit6.Name = "Edit6"
        Me.Edit6.Size = New System.Drawing.Size(272, 24)
        Me.Edit6.TabIndex = 12
        Me.Edit6.Text = "Edit6"
        '
        'Edit7
        '
        Me.Edit7.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit7.Location = New System.Drawing.Point(112, 464)
        Me.Edit7.Name = "Edit7"
        Me.Edit7.Size = New System.Drawing.Size(272, 24)
        Me.Edit7.TabIndex = 14
        Me.Edit7.Text = "Edit7"
        '
        'Edit8
        '
        Me.Edit8.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit8.Location = New System.Drawing.Point(112, 496)
        Me.Edit8.Name = "Edit8"
        Me.Edit8.Size = New System.Drawing.Size(272, 24)
        Me.Edit8.TabIndex = 15
        Me.Edit8.Text = "Edit8"
        '
        'Edit9
        '
        Me.Edit9.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit9.Location = New System.Drawing.Point(112, 528)
        Me.Edit9.Name = "Edit9"
        Me.Edit9.Size = New System.Drawing.Size(184, 24)
        Me.Edit9.TabIndex = 16
        Me.Edit9.Text = "Edit9"
        '
        'Edit10
        '
        Me.Edit10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit10.Location = New System.Drawing.Point(508, 240)
        Me.Edit10.Name = "Edit10"
        Me.Edit10.Size = New System.Drawing.Size(200, 24)
        Me.Edit10.TabIndex = 21
        Me.Edit10.Text = "Edit10"
        '
        'Edit11
        '
        Me.Edit11.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit11.Location = New System.Drawing.Point(508, 272)
        Me.Edit11.Name = "Edit11"
        Me.Edit11.Size = New System.Drawing.Size(200, 24)
        Me.Edit11.TabIndex = 22
        Me.Edit11.Text = "Edit11"
        '
        'Edit12
        '
        Me.Edit12.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit12.Location = New System.Drawing.Point(508, 496)
        Me.Edit12.Name = "Edit12"
        Me.Edit12.Size = New System.Drawing.Size(196, 24)
        Me.Edit12.TabIndex = 29
        Me.Edit12.Text = "Edit12"
        '
        'Edit13
        '
        Me.Edit13.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit13.Location = New System.Drawing.Point(508, 528)
        Me.Edit13.Name = "Edit13"
        Me.Edit13.Size = New System.Drawing.Size(196, 24)
        Me.Edit13.TabIndex = 30
        Me.Edit13.Text = "Edit13"
        '
        'Mask1
        '
        Me.Mask1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Mask1.Format = New GrapeCity.Win.Input.Interop.MaskFormat("\D{3}-\D{4}", "", "")
        Me.Mask1.Location = New System.Drawing.Point(112, 432)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.Size = New System.Drawing.Size(84, 24)
        Me.Mask1.TabIndex = 13
        Me.Mask1.Value = ""
        '
        'L_Err_seq
        '
        Me.L_Err_seq.ForeColor = System.Drawing.Color.Red
        Me.L_Err_seq.Location = New System.Drawing.Point(128, 12)
        Me.L_Err_seq.Name = "L_Err_seq"
        Me.L_Err_seq.Size = New System.Drawing.Size(112, 24)
        Me.L_Err_seq.TabIndex = 226
        Me.L_Err_seq.Text = "L_Err_seq"
        Me.L_Err_seq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(220, 208)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 24)
        Me.Label16.TabIndex = 227
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(220, 240)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 24)
        Me.Label22.TabIndex = 228
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(220, 272)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 24)
        Me.Label24.TabIndex = 229
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(536, 48)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 24)
        Me.Label25.TabIndex = 230
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(612, 432)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 24)
        Me.Label26.TabIndex = 231
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadioButton5
        '
        Me.RadioButton5.Location = New System.Drawing.Point(164, 12)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(96, 20)
        Me.RadioButton5.TabIndex = 2
        Me.RadioButton5.Text = "キャンセル"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(8, 12)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(64, 20)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.Text = "受注"
        '
        'RadioButton4
        '
        Me.RadioButton4.Location = New System.Drawing.Point(84, 12)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(64, 20)
        Me.RadioButton4.TabIndex = 1
        Me.RadioButton4.Text = "完了"
        '
        'RadioButton6
        '
        Me.RadioButton6.Location = New System.Drawing.Point(276, 12)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(132, 20)
        Me.RadioButton6.TabIndex = 3
        Me.RadioButton6.Text = "完了キャンセル"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(536, 84)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 24)
        Me.Label27.TabIndex = 234
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(712, 112)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 24)
        Me.Label28.TabIndex = 235
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(712, 144)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 24)
        Me.Label29.TabIndex = 236
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Red
        Me.Label30.Location = New System.Drawing.Point(712, 176)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(56, 24)
        Me.Label30.TabIndex = 237
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Red
        Me.Label31.Location = New System.Drawing.Point(712, 212)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 24)
        Me.Label31.TabIndex = 238
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(712, 400)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 24)
        Me.Label34.TabIndex = 239
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Red
        Me.Label35.Location = New System.Drawing.Point(292, 112)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(56, 24)
        Me.Label35.TabIndex = 240
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(616, 304)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(92, 24)
        Me.Label36.TabIndex = 241
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Red
        Me.Label40.Location = New System.Drawing.Point(616, 336)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(92, 24)
        Me.Label40.TabIndex = 242
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Red
        Me.Label41.Location = New System.Drawing.Point(616, 368)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(92, 24)
        Me.Label41.TabIndex = 243
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Red
        Me.Label42.Location = New System.Drawing.Point(584, 464)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(100, 24)
        Me.Label42.TabIndex = 244
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Red
        Me.Label43.Location = New System.Drawing.Point(608, 560)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(92, 24)
        Me.Label43.TabIndex = 245
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Red
        Me.Label44.Location = New System.Drawing.Point(608, 592)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(92, 24)
        Me.Label44.TabIndex = 246
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Red
        Me.Label45.Location = New System.Drawing.Point(148, 180)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(144, 24)
        Me.Label45.TabIndex = 247
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(112, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 36)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton5)
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Controls.Add(Me.RadioButton6)
        Me.GroupBox2.Location = New System.Drawing.Point(112, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(420, 36)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label48.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Red
        Me.Label48.Location = New System.Drawing.Point(752, 144)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(28, 24)
        Me.Label48.TabIndex = 248
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label48.Visible = False
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(782, 675)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.L_Err_seq)
        Me.Controls.Add(Me.Mask1)
        Me.Controls.Add(Me.Edit13)
        Me.Controls.Add(Me.Edit12)
        Me.Controls.Add(Me.Edit11)
        Me.Controls.Add(Me.Edit10)
        Me.Controls.Add(Me.Edit9)
        Me.Controls.Add(Me.Edit8)
        Me.Controls.Add(Me.Edit7)
        Me.Controls.Add(Me.Edit6)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.Edit4)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Number8)
        Me.Controls.Add(Me.Number7)
        Me.Controls.Add(Me.Number5)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Date4)
        Me.Controls.Add(Me.Date3)
        Me.Controls.Add(Me.Number6)
        Me.Controls.Add(Me.Number4)
        Me.Controls.Add(Me.Number3)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.MSG)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label00)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Best エラー修正"
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '***************************************************************************
    '** 起動時
    '***************************************************************************
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        L_Err_seq.Text = P_Pram
        Label00.Text = P_Pram2

        DsList1.Clear()
        strSQL = "SELECT *"
        strSQL += " FROM Error_data_new"
        strSQL += " WHERE (Error_seq = " & P_Pram & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "Error_data_new")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("Error_data_new"), "", "", DataViewRowState.CurrentRows)

        Label25.Text = DtView1(0)("BY_cls")
        Select Case DtView1(0)("BY_cls")
            Case Is = "B"
                RadioButton1.Checked = True

            Case Is = "Y"
                RadioButton2.Checked = True
            Case Else
        End Select

        Edit1.Text = DtView1(0)("ordr_no") : Edit2.Text = Nothing
        If IsDate(DtView1(0)("prch_date")) = True Then
            Date1.Text = DtView1(0)("prch_date")
        Else
            Label16.Text = DtView1(0)("prch_date")
        End If
        If IsDate(DtView1(0)("fin_date")) = True Then
            Date2.Text = DtView1(0)("fin_date")
        Else
            Label22.Text = DtView1(0)("fin_date")
        End If
        If IsDate(DtView1(0)("cxl_date")) = True Then
            Date3.Text = DtView1(0)("cxl_date")
        Else
            Label24.Text = DtView1(0)("cxl_date")
        End If
        Edit3.Text = DtView1(0)("org_ordr_no")
        Edit4.Text = DtView1(0)("aka_ordr_no")
        Edit5.Text = DtView1(0)("cust_no")
        Edit6.Text = DtView1(0)("cust_lname")
        Mask1.Value = DtView1(0)("zip_code")
        Edit7.Text = DtView1(0)("adrs1")
        Edit8.Text = DtView1(0)("adrs2")
        Edit9.Text = DtView1(0)("srch_phn")
        If IsNumeric(DtView1(0)("line_no")) = True Then
            Number8.Value = DtView1(0)("line_no")
        Else
            Label45.Text = DtView1(0)("line_no")
        End If

        ComboBox1_set() '大分類
        WK_DtView1 = New DataView(DsCmb1.Tables("Cat_mtr"), "cd1 = '" & DtView1(0)("item_cat_code1") & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            ComboBox1.SelectedValue = DtView1(0)("item_cat_code1")
        Else
            Label28.Text = DtView1(0)("item_cat_code1")
        End If
        ComboBox2_set() '中分類
        WK_DtView1 = New DataView(DsCmb2.Tables("Cat_mtr"), "cd2 = '" & DtView1(0)("item_cat_code2") & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            ComboBox2.SelectedValue = DtView1(0)("item_cat_code2")
        Else
            Label29.Text = DtView1(0)("item_cat_code2")
        End If
        ComboBox3_set() '小分類
        WK_DtView1 = New DataView(DsCmb3.Tables("Cat_mtr"), "cd3 = '" & DtView1(0)("item_cat_code3") & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            ComboBox3.SelectedValue = DtView1(0)("item_cat_code3")
        Else
            Label30.Text = DtView1(0)("item_cat_code3")
        End If

        ComboBox4_set() 'メーカー
        WK_DtView1 = New DataView(DsCmb4.Tables("vdr_mtr"), "vdr_code = '" & DtView1(0)("bend_code") & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            ComboBox4.SelectedValue = DtView1(0)("bend_code")
        Else
            Label31.Text = DtView1(0)("bend_code")
        End If

        Edit10.Text = DtView1(0)("pos_code")
        Edit11.Text = DtView1(0)("model_name")

        If IsNumeric(DtView1(0)("prch_price")) = True Then
            Number2.Value = DtView1(0)("prch_price")
        Else
            Label36.Text = DtView1(0)("prch_price")
        End If
        If IsNumeric(DtView1(0)("prch_tax")) = True Then
            Number3.Value = DtView1(0)("prch_tax")
        Else
            Label40.Text = DtView1(0)("prch_tax")
        End If
        If IsNumeric(DtView1(0)("prch_unit")) = True Then
            Number4.Value = DtView1(0)("prch_unit")
        Else
            Label41.Text = DtView1(0)("prch_unit")
        End If

        ComboBox5_set() '店舗
        WK_DtView1 = New DataView(DsCmb5.Tables("Shop_mtr"), "shop_code = '" & DtView1(0)("shop_code") & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            ComboBox5.SelectedValue = DtView1(0)("shop_code")
        Else
            Label34.Text = DtView1(0)("shop_code")
        End If

        If IsDate(DtView1(0)("op_date")) = True Then
            Date4.Text = DtView1(0)("op_date")
        Else
            Label26.Text = DtView1(0)("op_date")
        End If
        If IsNumeric(DtView1(0)("data_seq")) = True Then
            Number5.Value = DtView1(0)("data_seq")
        Else
            Label42.Text = DtView1(0)("data_seq")
        End If

        Label27.Text = DtView1(0)("cont_code")
        Select Case DtView1(0)("cont_code")
            Case Is = "1"
                RadioButton3.Checked = True
            Case Is = "2"
                RadioButton4.Checked = True
            Case Is = "3"
                RadioButton5.Checked = True
            Case Is = "4"
                RadioButton6.Checked = True
            Case Else
        End Select

        Edit12.Text = DtView1(0)("wrn_item_code")
        Edit13.Text = DtView1(0)("wrn_item_name")
        If IsNumeric(DtView1(0)("wrn_fee")) = True Then
            Number6.Value = DtView1(0)("wrn_fee")
        Else
            Label43.Text = DtView1(0)("wrn_fee")
        End If
        If IsNumeric(DtView1(0)("wrn_prod")) = True Then
            Number7.Value = DtView1(0)("wrn_prod")
        Else
            Label44.Text = DtView1(0)("wrn_prod")
        End If

        ComboBox6_set() '保証種類
        WK_DtView1 = New DataView(DsCmb6.Tables("cls_016"), "CLS_CODE = '" & DtView1(0)("wrn_cls") & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            ComboBox6.SelectedValue = DtView1(0)("wrn_cls")
        Else
            Label35.Text = DtView1(0)("wrn_cls")
        End If

        F_chk()
    End Sub

    Sub ComboBox1_set() '大分類
        DsCmb1.Clear()
        strSQL = "SELECT cd1, cd1 + ':' + [品種名(漢字)] AS cat_name1, [品種名(漢字)] AS cat_name1_n"
        strSQL += " FROM Cat_mtr"
        strSQL += " WHERE (BY_cls = '" & Label25.Text & "')"
        strSQL += " AND (cd2 = '00')"
        strSQL += " AND (cd3 = '00')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCmb1, "Cat_mtr")
        DB_CLOSE()

        '大分類
        ComboBox1.DataSource = DsCmb1.Tables("Cat_mtr")
        ComboBox1.DisplayMember = "cat_name1"
        ComboBox1.ValueMember = "cd1"
        ComboBox1.Text = Nothing
    End Sub

    Sub ComboBox2_set() '中分類
        DsCmb2.Clear()
        strSQL = "SELECT cd2, cd2 + ':' + [品種名(漢字)] AS cat_name2, [品種名(漢字)] AS cat_name2_n, avlbty, wrn_prod"
        strSQL += " FROM Cat_mtr"
        strSQL += " WHERE (BY_cls = '" & Label25.Text & "')"
        strSQL += " AND (cd1 = '" & ComboBox1.SelectedValue & "')"
        strSQL += " AND (cd3 = '00')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCmb2, "Cat_mtr")
        DB_CLOSE()

        '中分類
        ComboBox2.DataSource = DsCmb2.Tables("Cat_mtr")
        ComboBox2.DisplayMember = "cat_name2"
        ComboBox2.ValueMember = "cd2"
        ComboBox2.Text = Nothing
    End Sub

    Sub ComboBox3_set() '小分類
        DsCmb3.Clear()
        strSQL = "SELECT cd3, cd3 + ':' + [品種名(漢字)] AS cat_name3, [品種名(漢字)] AS cat_name3_n"
        strSQL += " FROM Cat_mtr"
        strSQL += " WHERE (BY_cls = '" & Label25.Text & "')"
        strSQL += " AND (cd1 = '" & ComboBox1.SelectedValue & "')"
        strSQL += " AND (cd2 = '" & ComboBox2.SelectedValue & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCmb3, "Cat_mtr")
        DB_CLOSE()

        '小分類
        ComboBox3.DataSource = DsCmb3.Tables("Cat_mtr")
        ComboBox3.DisplayMember = "cat_name3"
        ComboBox3.ValueMember = "cd3"
        ComboBox3.Text = Nothing
    End Sub

    Sub ComboBox4_set() 'メーカー
        DsCmb4.Clear()
        strSQL = "SELECT vdr_code, vdr_code + ':' + vdr_name AS vdr_name, vdr_name AS vdr_name_n"
        strSQL += " FROM vdr_mtr"
        strSQL += " WHERE (BY_cls = '" & Label25.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCmb4, "vdr_mtr")
        DB_CLOSE()

        'メーカー
        ComboBox4.DataSource = DsCmb4.Tables("vdr_mtr")
        ComboBox4.DisplayMember = "vdr_name"
        ComboBox4.ValueMember = "vdr_code"
        ComboBox4.Text = Nothing
    End Sub

    Sub ComboBox5_set() '店舗
        DsCmb5.Clear()
        strSQL = "SELECT shop_code, shop_code + ':' + [店舗名(漢字)] AS shop_name, close_date, [店舗名(漢字)] AS shop_name_n"
        strSQL += " FROM Shop_mtr"
        strSQL += " WHERE (BY_cls = '" & Label25.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCmb5, "Shop_mtr")
        DB_CLOSE()

        '店舗
        ComboBox5.DataSource = DsCmb5.Tables("Shop_mtr")
        ComboBox5.DisplayMember = "shop_name"
        ComboBox5.ValueMember = "shop_code"
        ComboBox5.Text = Nothing
    End Sub

    Sub ComboBox6_set() '保証種類
        DsCmb6.Clear()
        strSQL = "SELECT CLS_CODE, CLS_CODE + ':' + CLS_CODE_NAME AS CLS_CODE_NAME, CLS_CODE_NAME AS CLS_CODE_NAME_n"
        strSQL += " FROM V_cls_016"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCmb6, "cls_016")
        DB_CLOSE()

        '保証種類
        ComboBox6.DataSource = DsCmb6.Tables("cls_016")
        ComboBox6.DisplayMember = "CLS_CODE_NAME"
        ComboBox6.ValueMember = "CLS_CODE"
        ComboBox6.Text = Nothing
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        by_chg()
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        by_chg()
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        '受注
        Date1.Enabled = True        '受注日
        Date2.Enabled = True        '完了日
        Date3.Enabled = False        '取消日
        Date4.Enabled = True        'ﾃﾞｰﾀ処理日

        Edit3.Enabled = False        '元伝No
        Edit4.Enabled = False        '赤伝No
        Edit5.Enabled = True        '顧客番号
        Edit6.Enabled = True        '顧客名
        Edit7.Enabled = True        '住所1
        Edit8.Enabled = True        '住所2
        Edit9.Enabled = True        'TEL
        Edit10.Enabled = True       '商品ｺｰﾄﾞ
        Edit11.Enabled = True       '型式
        Edit12.Enabled = True       '保証商品コード
        Edit13.Enabled = True       '保証商品型式

        Number2.Enabled = True      '売価
        Number3.Enabled = True      '税額
        Number4.Enabled = True      '購入数量
        Number5.Enabled = True      'データ連番
        Number6.Enabled = True      '保証料
        Number7.Enabled = True      '保証月数
        Number8.Enabled = True      '行№

        Mask1.Enabled = True        '郵便番号

        ComboBox1.Enabled = True    '大分類
        ComboBox2.Enabled = True    '中分類
        ComboBox3.Enabled = True    '小分類
        ComboBox4.Enabled = True    'メーカー
        ComboBox5.Enabled = True    '店舗
        ComboBox6.Enabled = True    '保証種類
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        '完了
        Date1.Enabled = False        '受注日
        Date2.Enabled = True        '完了日
        Date3.Enabled = False        '取消日
        Date4.Enabled = True        'ﾃﾞｰﾀ処理日

        Edit3.Enabled = False        '元伝No
        Edit4.Enabled = False        '赤伝No
        Edit5.Enabled = False        '顧客番号
        Edit6.Enabled = False        '顧客名
        Edit7.Enabled = False        '住所1
        Edit8.Enabled = False        '住所2
        Edit9.Enabled = False        'TEL
        Edit10.Enabled = False       '商品ｺｰﾄﾞ
        Edit11.Enabled = False       '型式
        Edit12.Enabled = False       '保証商品コード
        Edit13.Enabled = False       '保証商品型式

        Number2.Enabled = False      '売価
        Number3.Enabled = False      '税額
        Number4.Enabled = False      '購入数量
        Number5.Enabled = False      'データ連番
        Number6.Enabled = False      '保証料
        Number7.Enabled = False      '保証月数
        Number8.Enabled = True      '行№

        Mask1.Enabled = False        '郵便番号

        ComboBox1.Enabled = False    '大分類
        ComboBox2.Enabled = False    '中分類
        ComboBox3.Enabled = False    '小分類
        ComboBox4.Enabled = False    'メーカー
        ComboBox5.Enabled = False    '店舗
        ComboBox6.Enabled = True    '保証種類
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        'キャンセル
        Date1.Enabled = False        '受注日
        Date2.Enabled = False        '完了日
        Date3.Enabled = True        '取消日
        Date4.Enabled = False        'ﾃﾞｰﾀ処理日

        Edit3.Enabled = False        '元伝No
        Edit4.Enabled = True        '赤伝No
        Edit5.Enabled = False        '顧客番号
        Edit6.Enabled = False        '顧客名
        Edit7.Enabled = False        '住所1
        Edit8.Enabled = False        '住所2
        Edit9.Enabled = False        'TEL
        Edit10.Enabled = False       '商品ｺｰﾄﾞ
        Edit11.Enabled = False       '型式
        Edit12.Enabled = False       '保証商品コード
        Edit13.Enabled = False       '保証商品型式

        Number2.Enabled = False      '売価
        Number3.Enabled = False      '税額
        Number4.Enabled = True      '購入数量
        Number5.Enabled = False      'データ連番
        Number6.Enabled = False      '保証料
        Number7.Enabled = False      '保証月数
        Number8.Enabled = True      '行№

        Mask1.Enabled = False        '郵便番号

        ComboBox1.Enabled = False    '大分類
        ComboBox2.Enabled = False    '中分類
        ComboBox3.Enabled = False    '小分類
        ComboBox4.Enabled = False    'メーカー
        ComboBox5.Enabled = True    '店舗
        ComboBox6.Enabled = True    '保証種類
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        '完了キャンセル
        Date1.Enabled = True        '受注日
        Date2.Enabled = False        '完了日
        Date3.Enabled = False        '取消日
        Date4.Enabled = False        'ﾃﾞｰﾀ処理日

        Edit3.Enabled = False        '元伝No
        Edit4.Enabled = False        '赤伝No
        Edit5.Enabled = False        '顧客番号
        Edit6.Enabled = False        '顧客名
        Edit7.Enabled = False        '住所1
        Edit8.Enabled = False        '住所2
        Edit9.Enabled = False        'TEL
        Edit10.Enabled = False       '商品ｺｰﾄﾞ
        Edit11.Enabled = False       '型式
        Edit12.Enabled = False       '保証商品コード
        Edit13.Enabled = False       '保証商品型式

        Number2.Enabled = False      '売価
        Number3.Enabled = False      '税額
        Number4.Enabled = False      '購入数量
        Number5.Enabled = False      'データ連番
        Number6.Enabled = False      '保証料
        Number7.Enabled = False      '保証月数
        Number8.Enabled = True      '行№

        Mask1.Enabled = False        '郵便番号

        ComboBox1.Enabled = False    '大分類
        ComboBox2.Enabled = False    '中分類
        ComboBox3.Enabled = False    '小分類
        ComboBox4.Enabled = False    'メーカー
        ComboBox5.Enabled = False    '店舗
        ComboBox6.Enabled = True    '保証種類
    End Sub

    Sub by_chg()
        If RadioButton1.Checked = True Then
            Label25.Text = "B"
        Else
            Label25.Text = "Y"
        End If
        ComboBox1_set() '大分類
        ComboBox2_set() '中分類
        ComboBox3_set() '小分類
        ComboBox4_set() 'メーカー
        ComboBox5_set() '店舗
    End Sub

    '***************************************************************************
    '** 項目チェック
    '***************************************************************************
    Sub F_chk()
        Err_F = "0"
        MSG.Text = Nothing

        chk_RadioButton1()  'システム区分(B:BEST Y:YAMADA)
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_RadioButton3()  '取引種類(1:受注 2:完了 3:キャンセル 4:完了キャンセル)
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_ComboBox6()     '保証種類
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit1()         '伝票番号
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Number8()       '対象商品行NO
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Date1()         '受注日
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Date2()         '完了日
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Date3()         '取消日
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit3()         '元伝No
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit4()         '赤伝No
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit5()         '顧客番号
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit6()         '顧客名
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Mask1()         '郵便番号
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit7()         '住所１
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit8()         '住所２
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit9()         '電話番号
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_ComboBox1()     '大分類
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_ComboBox2()     '中分類
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_ComboBox3()     '小分類
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_ComboBox4()     'メーカー
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit10()        '商品コード
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit11()        '型式
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Number4()       '購入数量
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_ComboBox5()     '店番
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Date4()         'データ処理日
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit12()         '保証商品コード
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Edit13()         '保証商品型式
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Number6()       '保証金額
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

        chk_Number7()       '保証期間
        If WK_Err_msg <> Nothing Then
            If MSG.Text = Nothing Then MSG.Text = WK_Err_msg
        End If

    End Sub
    Sub chk_RadioButton1()  'システム区分(B:BEST Y:YAMADA)
        WK_Err_msg = Nothing
        RadioButton1.BackColor = System.Drawing.SystemColors.Control
        RadioButton2.BackColor = System.Drawing.SystemColors.Control

        If RadioButton1.Checked = False _
            And RadioButton2.Checked = False Then
            WK_Err_msg = "システム区分 未入力"
            RadioButton1.BackColor = System.Drawing.Color.Red
            RadioButton2.BackColor = System.Drawing.Color.Red
            Err_F = "1"
        End If
    End Sub
    Sub chk_RadioButton3()  '取引種類(1:受注 2:完了 3:キャンセル 4:完了キャンセル)
        WK_Err_msg = Nothing
        RadioButton3.BackColor = System.Drawing.SystemColors.Control
        RadioButton4.BackColor = System.Drawing.SystemColors.Control
        RadioButton5.BackColor = System.Drawing.SystemColors.Control
        RadioButton6.BackColor = System.Drawing.SystemColors.Control

        If RadioButton3.Checked = False _
            And RadioButton4.Checked = False _
            And RadioButton5.Checked = False _
            And RadioButton6.Checked = False Then
            WK_Err_msg = "取引種類 未入力"
            RadioButton3.BackColor = System.Drawing.Color.Red
            RadioButton4.BackColor = System.Drawing.Color.Red
            RadioButton5.BackColor = System.Drawing.Color.Red
            RadioButton6.BackColor = System.Drawing.Color.Red
            Err_F = "1"
        End If
    End Sub
    Sub chk_ComboBox6()     '保証種類
        WK_Err_msg = Nothing
        ComboBox6.BackColor = System.Drawing.SystemColors.Window

        If ComboBox6.Text = Nothing Then
            WK_Err_msg = "保証種類 未入力"
            ComboBox6.BackColor = System.Drawing.Color.Red
        Else
            WK_DtView1 = New DataView(DsCmb6.Tables("cls_016"), "CLS_CODE_NAME = '" & ComboBox6.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                WK_Err_msg = "保証種類 エラー"
                ComboBox6.BackColor = System.Drawing.Color.Red
            End If
        End If
    End Sub
    Sub chk_Edit1()         '伝票番号
        WK_Err_msg = Nothing
        Edit1.BackColor = System.Drawing.SystemColors.Window
        Edit1.Text = Trim(Edit1.Text)

        If Edit1.Text = Nothing Then
            WK_Err_msg = "伝票番号 未入力"
            Edit1.BackColor = System.Drawing.Color.Red
        Else
            If LenB(Edit1.Text) > 13 Then
                WK_Err_msg = "伝票番号 桁数オーバー"
                Edit1.BackColor = System.Drawing.Color.Red
            Else
                If RadioButton3.Checked = True Then '受注
                Else
                    If RadioButton4.Checked = True _
                        Or RadioButton5.Checked = True _
                        Or RadioButton6.Checked = True Then '完了 'キャンセル '完了キャンセル
                        WK_DsList1.Clear()
                        If Mid(ComboBox6.Text, 1, 4) = "0100" Or Mid(ComboBox6.Text, 1, 4) = "0200" Or Mid(ComboBox6.Text, 1, 4) = "0210" Then    '個人、法人、企業保証
                            strSQL = "SELECT ordr_no FROM Wrn_mtr WHERE (ordr_no = '" & Edit1.Text & "')"
                        Else
                            strSQL = "SELECT ordr_no FROM All8_Wrn_mtr WHERE (ordr_no = '" & Edit1.Text & "')"
                        End If
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                        DB_CLOSE()
                        If r = 0 Then
                            WK_Err_msg = "該当する受注なし"
                            Edit1.BackColor = System.Drawing.Color.Red
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Sub chk_Number8()       '対象商品行NO
        WK_Err_msg = Nothing
        Number8.BackColor = System.Drawing.SystemColors.Window

        If Number8.Value = 0 Then
            WK_Err_msg = "対象商品行NO 未入力"
            Number8.BackColor = System.Drawing.Color.Red
        Else
            If Number8.Value > 99 Then
                WK_Err_msg = "対象商品行NO 桁数オーバー"
                Number8.BackColor = System.Drawing.Color.Red
            Else
                If RadioButton3.Checked = True Then '受注
                    WK_DsList1.Clear()
                    If Mid(ComboBox6.Text, 1, 4) = "0100" Or Mid(ComboBox6.Text, 1, 4) = "0200" Or Mid(ComboBox6.Text, 1, 4) = "0210" Then    '個人、法人、企業保証
                        strSQL = "SELECT ordr_no, line_no FROM Wrn_sub WHERE (ordr_no = '" & Edit1.Text & "') AND (line_no = '" & Format(Number8.Value, "00") & "')"
                    Else
                        strSQL = "SELECT ordr_no, line_no FROM All8_Wrn_sub WHERE (ordr_no = '" & Edit1.Text & "') AND (line_no = '" & Format(Number8.Value, "00") & "')"
                    End If
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    r = DaList1.Fill(WK_DsList1, "Wrn_sub")
                    DB_CLOSE()
                    If r <> 0 Then
                        WK_Err_msg = "登録済みの伝票番号・行Noです。"
                        Number8.BackColor = System.Drawing.Color.Red
                    End If
                Else
                    If RadioButton4.Checked = True _
                        Or RadioButton5.Checked = True _
                        Or RadioButton6.Checked = True Then '完了 'キャンセル '完了キャンセル
                        WK_DsList1.Clear()
                        If Mid(ComboBox6.Text, 1, 4) = "0100" Or Mid(ComboBox6.Text, 1, 4) = "0200" Or Mid(ComboBox6.Text, 1, 4) = "0210" Then    '個人、法人、企業保証
                            strSQL = "SELECT ordr_no, line_no FROM Wrn_sub WHERE (ordr_no = '" & Edit1.Text & "') AND (line_no = '" & Format(Number8.Value, "00") & "')"
                        Else
                            strSQL = "SELECT ordr_no, line_no FROM All8_Wrn_sub WHERE (ordr_no = '" & Edit1.Text & "') AND (line_no = '" & Format(Number8.Value, "00") & "')"
                        End If
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                        DB_CLOSE()
                        If r = 0 Then
                            WK_Err_msg = "該当する受注なし"
                            Number8.BackColor = System.Drawing.Color.Red
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Sub chk_Date1()         '受注日
        WK_Err_msg = Nothing
        Date1.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If Date1.Number = 0 Then
                WK_Err_msg = "受注日 未入力"
                Date1.BackColor = System.Drawing.Color.Red
            Else
                If IsDate(Date1.Text) = False Then
                    WK_Err_msg = "受注日 エラー"
                    Date1.BackColor = System.Drawing.Color.Red
                End If
            End If
        Else
            If RadioButton4.Checked = True _
                Or RadioButton5.Checked = True Then '完了 'キャンセル 
                If Date1.Number = 0 Then
                Else
                    If IsDate(Date1.Text) = False Then
                        WK_Err_msg = "受注日 エラー"
                        Date1.BackColor = System.Drawing.Color.Red
                    End If
                End If
            End If
        End If
    End Sub
    Sub chk_Date2()         '完了日
        WK_Err_msg = Nothing
        Date2.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If Date2.Number = 0 Then
            Else
                If IsDate(Date2.Text) = False Then
                    WK_Err_msg = "完了日 エラー"
                    Date2.BackColor = System.Drawing.Color.Red
                End If
            End If
        Else
            If RadioButton4.Checked = True Then '完了
                If Date2.Number = 0 Then
                    WK_Err_msg = "完了日 未入力"
                    Date2.BackColor = System.Drawing.Color.Red
                Else
                    If IsDate(Date2.Text) = False Then
                        WK_Err_msg = "完了日 エラー"
                        Date2.BackColor = System.Drawing.Color.Red
                    End If
                End If
            Else
                If RadioButton5.Checked = True Then 'キャンセル
                    If Date2.Number <> 0 Then
                        WK_Err_msg = "完了日 入力エラー"
                        Date2.BackColor = System.Drawing.Color.Red
                    End If
                End If
            End If
        End If
    End Sub
    Sub chk_Date3()         '取消日
        WK_Err_msg = Nothing
        Date3.BackColor = System.Drawing.SystemColors.Window

        If RadioButton5.Checked = True Then 'キャンセル
            If Date3.Number = 0 Then
                WK_Err_msg = "取消日 未入力"
                Date3.BackColor = System.Drawing.Color.Red
            Else
                If IsDate(Date3.Text) = False Then
                    WK_Err_msg = "取消日 エラー"
                    Date3.BackColor = System.Drawing.Color.Red
                End If
            End If

        End If
    End Sub
    Sub chk_Edit3()         '元伝No
        WK_Err_msg = Nothing
        Edit3.BackColor = System.Drawing.SystemColors.Window
        Edit3.Text = Trim(Edit3.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit3.Text = "0" Then Edit3.Text = Nothing
            If Edit3.Text = Nothing Then
            Else
                If LenB(Edit3.Text) > 13 Then
                    WK_Err_msg = "元伝No 桁数オーバー"
                    Edit3.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Edit4()         '赤伝No
        WK_Err_msg = Nothing
        Edit4.BackColor = System.Drawing.SystemColors.Window
        Edit4.Text = Trim(Edit4.Text)

        If Edit4.Text = "0" Then Edit4.Text = ""
        If RadioButton5.Checked = True Then 'キャンセル
            If Edit4.Text = Nothing Then
                WK_Err_msg = "赤伝No未入力"
                Edit4.BackColor = System.Drawing.Color.Red
            Else
                If LenB(Edit4.Text) > 13 Then
                    WK_Err_msg = "赤伝No 桁数オーバー"
                    Edit4.BackColor = System.Drawing.Color.Red
                End If
            End If
        Else
            If Edit4.Text <> Nothing Then
                WK_Err_msg = "赤伝No入力エラー"
                Edit4.BackColor = System.Drawing.Color.Red
            End If
        End If
    End Sub
    Sub chk_Edit5()         '顧客番号
        WK_Err_msg = Nothing
        Edit5.BackColor = System.Drawing.SystemColors.Window
        Edit5.Text = Trim(Edit5.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit5.Text = "0" Then Edit5.Text = ""
            If Edit5.Text = Nothing Then
            Else
                If LenB(Edit5.Text) > 15 Then
                    WK_Err_msg = "顧客番号 桁数オーバー"
                    Edit5.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Edit6()         '顧客名
        WK_Err_msg = Nothing
        Edit6.BackColor = System.Drawing.SystemColors.Window
        Edit6.Text = Trim(Edit6.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit6.Text = Nothing Then
            Else
                If LenB(Edit6.Text) > 120 Then
                    WK_Err_msg = "顧客名 桁数オーバー"
                    Edit6.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Mask1()         '郵便番号
        WK_Err_msg = Nothing
        Mask1.BackColor = System.Drawing.SystemColors.Window

        'If RadioButton3.Checked = True Then '受注
        '    If DtView1(k)("郵便番号") = Nothing Then
        '    End If
        'End If
    End Sub
    Sub chk_Edit7()         '住所１
        WK_Err_msg = Nothing
        Edit7.BackColor = System.Drawing.SystemColors.Window
        Edit7.Text = Trim(Edit7.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit7.Text = Nothing Then
            Else
                If LenB(Edit7.Text) > 120 Then
                    WK_Err_msg = "住所１ 桁数オーバー"
                    Edit7.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Edit8()         '住所２
        WK_Err_msg = Nothing
        Edit8.BackColor = System.Drawing.SystemColors.Window
        Edit8.Text = Trim(Edit8.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit8.Text = Nothing Then
            Else
                If LenB(Edit8.Text) > 120 Then
                    WK_Err_msg = "住所２ 桁数オーバー"
                    Edit8.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Edit9()         '電話番号
        WK_Err_msg = Nothing
        Edit9.BackColor = System.Drawing.SystemColors.Window
        Edit9.Text = Trim(Edit9.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit9.Text = Nothing Then
            Else
                If LenB(Edit9.Text) > 15 Then
                    WK_Err_msg = "電話番号 桁数オーバー"
                    Edit9.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_ComboBox1()     '大分類
        WK_Err_msg = Nothing
        ComboBox1.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If ComboBox1.Text = Nothing Then
                WK_Err_msg = "大分類 未入力"
                ComboBox1.BackColor = System.Drawing.Color.Red
            Else
                WK_DtView1 = New DataView(DsCmb1.Tables("Cat_mtr"), "cat_name1 = '" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    WK_Err_msg = "大分類 エラー"
                    ComboBox1.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_ComboBox2()     '中分類
        WK_Err_msg = Nothing
        ComboBox2.BackColor = System.Drawing.SystemColors.Window
        Label48.Text = "0"

        If RadioButton3.Checked = True Then '受注
            If ComboBox1.Text = Nothing Then
                WK_Err_msg = "中分類 未入力"
                ComboBox2.BackColor = System.Drawing.Color.Red
            Else
                WK_DtView1 = New DataView(DsCmb2.Tables("Cat_mtr"), "cat_name2 = '" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    WK_Err_msg = "中分類 エラー"
                    ComboBox2.BackColor = System.Drawing.Color.Red
                Else
                    Label48.Text = WK_DtView1(0)("wrn_prod")
                    If IsDBNull(WK_DtView1(0)("avlbty")) Then
                        WK_Err_msg = "対象外品種"
                        ComboBox2.BackColor = System.Drawing.Color.Red
                    Else
                        If WK_DtView1(0)("avlbty") <> "対象" Then
                            WK_Err_msg = "対象外品種"
                            ComboBox2.BackColor = System.Drawing.Color.Red
                        End If
                    End If

                End If
            End If
        End If
    End Sub
    Sub chk_ComboBox3()     '小分類
        WK_Err_msg = Nothing
        ComboBox3.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If ComboBox1.Text = Nothing Then
                WK_Err_msg = "小分類 未入力"
                ComboBox3.BackColor = System.Drawing.Color.Red
            Else
                WK_DtView1 = New DataView(DsCmb3.Tables("Cat_mtr"), "cat_name3 = '" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    WK_Err_msg = "小分類 エラー"
                    ComboBox3.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_ComboBox4()     'メーカー
        WK_Err_msg = Nothing
        ComboBox4.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If ComboBox1.Text = Nothing Then
                WK_Err_msg = "メーカー 未入力"
                ComboBox4.BackColor = System.Drawing.Color.Red
            Else
                WK_DtView1 = New DataView(DsCmb4.Tables("vdr_mtr"), "vdr_name = '" & ComboBox4.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    WK_Err_msg = "メーカー エラー"
                    ComboBox4.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Edit10()         '商品コード
        WK_Err_msg = Nothing
        Edit10.BackColor = System.Drawing.SystemColors.Window
        Edit10.Text = Trim(Edit10.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit10.Text = Nothing Then
            Else
                If LenB(Edit10.Text) > 10 Then
                    WK_Err_msg = "商品コード 桁数オーバー"
                    Edit10.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Edit11()         '型式
        WK_Err_msg = Nothing
        Edit11.BackColor = System.Drawing.SystemColors.Window
        Edit11.Text = Trim(Edit11.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit11.Text = Nothing Then
            Else
                If LenB(Edit11.Text) > 30 Then
                    WK_Err_msg = "型式 桁数オーバー"
                    Edit11.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Number2()       '売価
        WK_Err_msg = Nothing
        Number2.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If Number2.Value = 0 Then
                WK_Err_msg = "売価 未入力"
                Number2.BackColor = System.Drawing.Color.Red
            Else
                If Number2.Value > 999999999 Then
                    WK_Err_msg = "売価 桁数オーバー"
                    Number2.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Number3()       '税額
        WK_Err_msg = Nothing
        Number3.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If Number3.Value = 0 Then
                WK_Err_msg = "税額 未入力"
                Number3.BackColor = System.Drawing.Color.Red
            Else
                If Number3.Value > 9999999 Then
                    WK_Err_msg = "税額 桁数オーバー"
                    Number3.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Number4()       '購入数量
        WK_Err_msg = Nothing
        Number4.BackColor = System.Drawing.SystemColors.Window

        If RadioButton6.Checked = False Then '完了キャンセル以外
            If Number4.Value = 0 Then
                WK_Err_msg = "購入数量 未入力"
                Number4.BackColor = System.Drawing.Color.Red
            Else
                If Number4.Value > 9999 Then
                    WK_Err_msg = "購入数量 桁数オーバー"
                    Number4.BackColor = System.Drawing.Color.Red
                Else
                    If RadioButton4.Checked = True Then '完了
                        WK_DsList1.Clear()
                        If Mid(ComboBox6.Text, 1, 4) = "0100" Or Mid(ComboBox6.Text, 1, 4) = "0200" Or Mid(ComboBox6.Text, 1, 4) = "0210" Then    '個人、法人、企業保証
                            strSQL = "SELECT ordr_no, line_no FROM Wrn_sub"
                        Else
                            strSQL = "SELECT ordr_no, line_no FROM All8_Wrn_sub"
                        End If
                        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                        strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                        strSQL += " (cont_flg = 'A') AND (prch_date IS NULL)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                        DB_CLOSE()
                        If Number4.Value > r Then
                            WK_Err_msg = "受注数＜完了数　エラー"
                            Number4.BackColor = System.Drawing.Color.Red
                        End If
                    Else
                        If RadioButton5.Checked = True Then 'キャンセル
                            WK_DsList1.Clear()
                            If Mid(ComboBox6.Text, 1, 4) = "0100" Or Mid(ComboBox6.Text, 1, 4) = "0200" Or Mid(ComboBox6.Text, 1, 4) = "0210" Then    '個人、法人、企業保証
                                strSQL = "SELECT ordr_no, line_no FROM Wrn_sub"
                            Else
                                strSQL = "SELECT ordr_no, line_no FROM All8_Wrn_sub"
                            End If
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                            strSQL += " AND (cont_flg = 'A')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN()
                            r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                            DB_CLOSE()
                            If Number4.Value > r Then
                                WK_Err_msg = "受注数＜キャンセル数　エラー"
                                Number4.BackColor = System.Drawing.Color.Red
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Sub chk_ComboBox5()     '店舗
        WK_Err_msg = Nothing
        ComboBox5.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True _
            Or RadioButton5.Checked = True Then '受注'キャンセル
            If ComboBox5.Text = Nothing Then
                WK_Err_msg = "店舗 未入力"
                ComboBox5.BackColor = System.Drawing.Color.Red
            Else
                WK_DtView1 = New DataView(DsCmb5.Tables("Shop_mtr"), "shop_name = '" & ComboBox5.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    WK_Err_msg = "店舗 エラー"
                    ComboBox5.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Date4()         'データ処理日
        WK_Err_msg = Nothing
        Date4.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If Date4.Number = 0 Then
                WK_Err_msg = "データ処理日 未入力"
                Date4.BackColor = System.Drawing.Color.Red
            Else
                If IsDate(Date4.Text) = False Then
                    WK_Err_msg = "データ処理日 エラー"
                    Date4.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Edit12()         '保証商品コード
        WK_Err_msg = Nothing
        Edit12.BackColor = System.Drawing.SystemColors.Window
        Edit12.Text = Trim(Edit12.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit12.Text = Nothing Then
            Else
                If LenB(Edit12.Text) > 10 Then
                    WK_Err_msg = "保証商品コード 桁数オーバー"
                    Edit12.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Edit13()         '保証商品型式
        WK_Err_msg = Nothing
        Edit13.BackColor = System.Drawing.SystemColors.Window
        Edit13.Text = Trim(Edit13.Text)

        If RadioButton3.Checked = True Then '受注
            If Edit13.Text = Nothing Then
            Else
                If LenB(Edit13.Text) > 30 Then
                    WK_Err_msg = "保証商品型式 桁数オーバー"
                    Edit13.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Number6()       '保証金額
        WK_Err_msg = Nothing
        Number6.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If Number6.Value = 0 Then
                WK_Err_msg = "保証金額 未入力"
                Number6.BackColor = System.Drawing.Color.Red
            Else
                If Number6.Value > 999999999 Then
                    WK_Err_msg = "保証金額 桁数オーバー"
                    Number6.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Sub chk_Number7()       '保証期間
        WK_Err_msg = Nothing
        Number7.BackColor = System.Drawing.SystemColors.Window

        If RadioButton3.Checked = True Then '受注
            If Number7.Value = 0 Then
                WK_Err_msg = "保証期間 未入力"
                Number7.BackColor = System.Drawing.Color.Red
            Else
                If Number7.Value > 999 Then
                    WK_Err_msg = "保証期間 桁数オーバー"
                    Number7.BackColor = System.Drawing.Color.Red
                Else
                    If Number7.Value <> Label48.Text Then
                        WK_Err_msg = "保証期間 エラー"
                        Number7.BackColor = System.Drawing.Color.Red
                    End If
                End If
            End If
        End If
    End Sub

    '***************************************************************************
    '** LostFocus
    '***************************************************************************
    Private Sub ComboBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.LostFocus
        chk_ComboBox6()     '保証種類
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        chk_Edit1()         '伝票番号
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Number8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number8.LostFocus
        chk_Number8()       '対象商品行NO
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Date1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.LostFocus
        chk_Date1()         '受注日
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Date2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.LostFocus
        chk_Date2()         '完了日
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Date3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date3.LostFocus
        chk_Date3()         '取消日
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit3.LostFocus
        chk_Edit3()         '元伝No
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit4.LostFocus
        chk_Edit4()         '赤伝No
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit5.LostFocus
        chk_Edit5()         '顧客番号
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit6.LostFocus
        chk_Edit6()         '顧客名
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Mask1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.LostFocus
        chk_Mask1()         '郵便番号
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit7.LostFocus
        chk_Edit7()         '住所１
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit8.LostFocus
        chk_Edit8()         '住所２
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit9.LostFocus
        chk_Edit9()         '電話番号
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.LostFocus
        chk_ComboBox1()     '大分類
        MSG.Text = WK_Err_msg
        ComboBox2_set() '中分類
        ComboBox3_set() '小分類
    End Sub
    Private Sub ComboBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.LostFocus
        chk_ComboBox2()     '中分類
        MSG.Text = WK_Err_msg
        ComboBox3_set() '小分類
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub ComboBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.LostFocus
        chk_ComboBox3()     '小分類
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub ComboBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.LostFocus
        chk_ComboBox4()     'メーカー
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit10.LostFocus
        chk_Edit10()        '商品コード
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit11.LostFocus
        chk_Edit11()        '型式
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Number4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number4.LostFocus
        chk_Number4()       '購入数量
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub ComboBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.LostFocus
        chk_ComboBox5()     '店番
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Date4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date4.LostFocus
        chk_Date4()         'データ処理日
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit12.LostFocus
        chk_Edit12()         '保証商品コード
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Edit13_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit13.LostFocus
        chk_Edit13()         '保証商品型式
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Number6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number6.LostFocus
        chk_Number6()       '保証金額
        MSG.Text = WK_Err_msg
    End Sub
    Private Sub Number7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number7.LostFocus
        chk_Number7()       '保証期間
        MSG.Text = WK_Err_msg
    End Sub

    '***************************************************************************
    '** 更新
    '***************************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_chk()
        If Err_F = "0" Then

            If Mid(ComboBox6.Text, 1, 4) = "0100" Or Mid(ComboBox6.Text, 1, 4) = "0200" Or Mid(ComboBox6.Text, 1, 4) = "0210" Then    '個人、法人、企業保証
                upd_best()  'ベスト分更新
            Else
                upd_all()   'オール電化分更新
            End If

            'エラーデータ更新
            strSQL = "UPDATE Error_data_new"
            strSQL += " SET Upd_ordr_no = '" & Edit1.Text & "'"
            strSQL += ", Upd_line_no = '" & Format(Number8.Value, "00") & "'"
            strSQL += ", Fixed_flg = '1'"
            strSQL += ", Fixed_date = CONVERT(DATETIME, '" & Now & "', 102)"
            strSQL += " WHERE (Error_seq = " & L_Err_seq.Text & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN()
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        MsgBox("更新しました。")
        P_Rtn = "1"
        Me.Close()
    End Sub
    Sub upd_best()  'ベスト分更新

        'Wrn_mtr
        WK_DsList1.Clear()
        strSQL = "SELECT ordr_no FROM Wrn_mtr WHERE (ordr_no = '" & Edit1.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "Wrn_mtr")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            strSQL = "INSERT INTO  Wrn_mtr"
            strSQL += " (ordr_no, cust_no, cust_fname, cust_lname, adrs1, adrs2, city_name, pref_code"
            strSQL += ", zip_code, srch_phn, disp_phn, cid, shop_code, empl_code, org_ordr_no, corp_flg"
            strSQL += ", entry_date, entry_flg, s_flg, old_comp_flg, b_flg, aka_ordr_no, BY_cls)"
            strSQL += " VALUES ('" & Edit1.Text & "'"
            strSQL += ", '" & Edit5.Text & "'"
            strSQL += ", ''"
            strSQL += ", '" & Edit6.Text & "'"
            strSQL += ", '" & Edit7.Text & "'"
            strSQL += ", '" & Edit8.Text & "'"
            strSQL += ", ''"
            strSQL += ", ''"
            strSQL += ", '" & Mask1.Value & "'"
            strSQL += ", '" & Edit9.Text & "'"
            strSQL += ", '" & Edit9.Text & "'"
            strSQL += ", ''"
            strSQL += ", '" & ComboBox5.SelectedValue & "'"
            strSQL += ", ''"
            strSQL += ", '" & Edit3.Text & "'"
            strSQL += ", '0'"   '未使用
            strSQL += ", CONVERT(DATETIME, '" & Now & "', 102)"
            strSQL += ", '0'"
            strSQL += ", 0"
            strSQL += ", 0"
            strSQL += ", 0"     '未使用
            strSQL += ", '" & Edit4.Text & "'"
            If RadioButton1.Checked = True Then
                strSQL += ", 'B')"
            Else
                strSQL += ", 'Y')"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN()
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
        Else
            If RadioButton5.Checked = True Then   'キャンセル
                strSQL = "UPDATE Wrn_mtr"
                strSQL += " SET aka_ordr_no = '" & Edit4.Text & "'"
                strSQL += " WHERE (ordr_no = '" & WK_DtView1(0)("ordr_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            End If
        End If

        'Wrn_sub, Wrn_sub_2
        If RadioButton3.Checked = True Then   '受注
            'div1 = Number2.Value / Number4.Value
            'mod1 = Number2.Value Mod Number4.Value

            'div2 = Number3.Value / Number4.Value
            'mod2 = Number3.Value Mod Number4.Value

            'div3 = Number6.Value / Number4.Value
            'mod3 = Number6.Value Mod Number4.Value

            For j = 1 To Number4.Value
                strSQL = "INSERT INTO Wrn_sub"
                strSQL += " (ordr_no, line_no, seq, prch_price, prch_tax, prch_date, item_cat_code, cat_name, prvd_cls"
                strSQL += ", prch_unit, dlvr_cls, f_full, wrn_prod, wrn_part_prod, wrn_comp_prod, prm_comp_prod"
                strSQL += ", cont_flg, bend_code, brnd_name, model_name, pos_code, ser_no, bend_wrn_prod, wrn_fee"
                strSQL += ", op_date, total_loss_flg, corp_flg, b_flg, fin_date"
                strSQL += ", item_cat_code1, item_cat_code1_name, item_cat_code2, item_cat_code2_name, item_cat_code3"
                strSQL += ", item_cat_code3_name, data_seq, wrn_item_code, wrn_item_name, BY_cls)"
                strSQL += " VALUES ('" & Edit1.Text & "'"
                strSQL += ", '" & Format(Number8.Value, "00") & "'"
                strSQL += ", " & j
                'If j = 1 Then strSQL += ", " & div1 + mod1 Else strSQL += ", " & div1
                'If j = 1 Then strSQL += ", " & div2 + mod2 Else strSQL += ", " & div2
                strSQL += ", " & Number2.Value
                strSQL += ", " & Number3.Value
                strSQL += ", CONVERT(DATETIME, '" & Date1.Text & "', 102)"
                strSQL += ", '" & ComboBox1.SelectedValue & ComboBox2.SelectedValue & "'"
                WK_DtView1 = New DataView(DsCmb2.Tables("Cat_mtr"), "cat_name2 = '" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & MidB(Trim(WK_DtView1(0)("cat_name2_n")), 1, 15) & "'"
                strSQL += ", ''"
                strSQL += ", '1'"
                strSQL += ", ''"
                strSQL += ", ''"
                strSQL += ", '0'"
                strSQL += ", '0'"
                strSQL += ", '0'"
                strSQL += ", '0'"
                strSQL += ", 'A'"
                strSQL += ", '" & ComboBox4.SelectedValue & "'"
                WK_DtView1 = New DataView(DsCmb4.Tables("vdr_mtr"), "vdr_name = '" & ComboBox4.Text & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & MidB(WK_DtView1(0)("vdr_name_n"), 1, 10) & "'"
                strSQL += ", '" & Edit11.Text & "'"
                strSQL += ", '" & Edit10.Text & "'"
                strSQL += ", ''"
                strSQL += ", '0'"
                'If j = 1 Then strSQL += ", " & div3 + mod3 Else strSQL += ", " & div3
                strSQL += ", " & Number6.Value
                strSQL += ", CONVERT(DATETIME, '" & Date4.Text & "', 102)"
                strSQL += ", '0'"
                Select Case ComboBox6.SelectedValue '法人ﾌﾗｸﾞ
                    Case Is = "0200"
                        strSQL += ", '1'"
                    Case Is = "0210"
                        strSQL += ", '2'"
                    Case Else
                        strSQL += ", '0'"
                End Select
                strSQL += ", 0"
                If Date2.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date2.Text & "', 102)" Else strSQL += ", NULL"
                strSQL += ", '" & ComboBox1.SelectedValue & "'"
                WK_DtView1 = New DataView(DsCmb1.Tables("Cat_mtr"), "cat_name1 = '" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & MidB(Trim(WK_DtView1(0)("cat_name1_n")), 1, 10) & "'"
                strSQL += ", '" & ComboBox2.SelectedValue & "'"
                WK_DtView1 = New DataView(DsCmb2.Tables("Cat_mtr"), "cat_name2 = '" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & MidB(Trim(WK_DtView1(0)("cat_name2_n")), 1, 10) & "'"
                strSQL += ", '" & ComboBox3.SelectedValue & "'"
                WK_DtView1 = New DataView(DsCmb3.Tables("Cat_mtr"), "cat_name3 = '" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & MidB(Trim(WK_DtView1(0)("cat_name3_n")), 1, 10) & "'"
                strSQL += ", " & Number5.Value
                strSQL += ", '" & Edit12.Text & "'"
                strSQL += ", '" & Edit13.Text & "'"
                If RadioButton1.Checked = True Then
                    strSQL += ", 'B')"
                Else
                    strSQL += ", 'Y')"
                End If
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                WK_DsList2.Clear()
                strSQL = "SELECT * FROM Wrn_sub_2"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                strSQL += " AND (seq = " & j & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                r = DaList1.Fill(WK_DsList2, "Wrn_sub_2")
                DB_CLOSE()

                If r = 0 Then
                    strSQL = "INSERT INTO Wrn_sub_2"
                    strSQL += " (ordr_no, line_no, seq, item_cat_code3, wrn_pos_code, ordr_no2, wrn_prod2)"
                    strSQL += " VALUES ('" & Edit1.Text & "'"
                    strSQL += ", '" & Format(Number8.Value, "00") & "'"
                    strSQL += ", " & j
                    strSQL += ", '" & ComboBox3.SelectedValue & "'"
                    strSQL += ", '" & Edit12.Text & "'"
                    strSQL += ", '" & Edit3.Text & "'"
                    strSQL += ", '" & Format(Number7.Value, "000") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If
            Next
        End If

        If RadioButton4.Checked = True Then   '完了
            strSQL = "SELECT seq FROM Wrn_sub"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
            strSQL += " AND (cont_flg = 'A') AND (fin_date IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "Wrn_sub")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To WK_DtView1.Count - 1
                strSQL = "UPDATE Wrn_sub"
                strSQL += " SET fin_date = CONVERT(DATETIME, '" & Date2.Text & "', 102)"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next

            '完了の時、オール電化の判断ができないので両方に検索更新
            strSQL = "SELECT seq FROM All8_Wrn_sub"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
            strSQL += " AND (cont_flg = 'A') AND (fin_date IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To WK_DtView1.Count - 1
                strSQL = "UPDATE All8_Wrn_sub"
                strSQL += " SET fin_date = CONVERT(DATETIME, '" & Date2.Text & "', 102)"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next
        End If

        If RadioButton5.Checked = True Then   'キャンセル
            strSQL = "SELECT seq, close_date FROM Wrn_sub"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
            strSQL += " AND (cont_flg = 'A')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "Wrn_sub")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To Number4.Value - 1
                strSQL = "UPDATE Wrn_sub"
                strSQL += " SET cxl_shop_code = '" & ComboBox5.SelectedValue & "'"
                strSQL += ", cxl_date = CONVERT(DATETIME, '" & Date3.Text & "', 102)"
                strSQL += ", cxl_op_date = CONVERT(DATETIME, '" & Date4.Text & "', 102)"
                strSQL += ", cont_flg = 'C'"
                strSQL += ", close_date = NULL, close_cont_flg = NULL"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                strSQL += " AND (cont_flg = 'A')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                If Not IsDBNull(WK_DtView1(j)("close_date")) Then
                    strSQL = "SELECT * FROM fst_close_date"
                    strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                    strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                    strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    r = DaList1.Fill(WK_DsList1, "fst_close_date")
                    DB_CLOSE()
                    If r = 0 Then
                        strSQL = "INSERT INTO fst_close_date"
                        strSQL += " (ordr_no, line_no, seq, fst_close_date)"
                        strSQL += " VALUES ('" & Edit1.Text & "'"
                        strSQL += ", '" & Format(Number8.Value, "00") & "'"
                        strSQL += ", " & WK_DtView1(j)("seq")
                        strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(j)("close_date") & "', 102))"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN()
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                End If
            Next
        End If

        If RadioButton6.Checked = True Then   '完了キャンセル
            strSQL = "SELECT seq FROM Wrn_sub"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
            strSQL += " AND (cont_flg = 'A') AND (fin_date IS NOT NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "Wrn_sub")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To WK_DtView1.Count - 1
                strSQL = "UPDATE Wrn_sub"
                strSQL += " SET fin_date = NULL"
                strSQL += ", close_date = NULL, close_cont_flg = NULL"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                strSQL += " AND (cont_flg = 'A') AND (fin_date IS NOT NULL)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next
        End If

    End Sub
    Sub upd_all()   'オール電化分更新

        'All8_Wrn_mtr
        WK_DsList1.Clear()
        strSQL = "SELECT ordr_no FROM All8_Wrn_mtr WHERE (ordr_no = '" & Edit1.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "All8_Wrn_mtr")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            strSQL = "INSERT INTO All8_Wrn_mtr"
            strSQL += " (ordr_no, cust_no, cust_fname, cust_lname, city_name, pref_code, zip_code, srch_phn"
            strSQL += ", disp_phn, shop_code, target_ym, ordr_no_aka, ordr_no_moto, op_date, snd_date, adrs1"
            strSQL += ", adrs2, BY_cls)"
            strSQL += " VALUES ('" & Edit1.Text & "'"
            strSQL += ", '" & Edit5.Text & "'"
            strSQL += ", ''"
            strSQL += ", '" & Edit6.Text & "'"
            strSQL += ", ''"
            strSQL += ", ''"
            strSQL += ", '" & Mask1.Value & "'"
            strSQL += ", '" & Edit9.Text & "'"
            strSQL += ", '" & Edit9.Text & "'"
            strSQL += ", '" & ComboBox5.SelectedValue & "'"
            strSQL += ", N'" & Format(Now.Date, "yyyyMM") & "'"
            strSQL += ", '" & Edit4.Text & "'"
            strSQL += ", '" & Edit3.Text & "'"
            strSQL += ", CONVERT(DATETIME, '" & Date4.Text & "', 102)"
            strSQL += ", CONVERT(DATETIME, '" & Date4.Text & "', 102)"
            strSQL += ", '" & Edit7.Text & "'"
            strSQL += ", '" & Edit8.Text & "'"
            If RadioButton1.Checked = True Then
                strSQL += ", 'B')"
            Else
                strSQL += ", 'Y')"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN()
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
        Else
            If RadioButton5.Checked = True Then   'キャンセル
                strSQL = "UPDATE All8_Wrn_mtr"
                strSQL += " SET ordr_no_aka = '" & Edit3.Text & "'"
                strSQL += " WHERE (ordr_no = '" & WK_DtView1(0)("ordr_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            End If
        End If

        'All8_Wrn_sub
        If RadioButton3.Checked = True Then   '受注
            'div1 = Number2.Value / Number4.Value
            'mod1 = Number2.Value Mod Number4.Value

            'div2 = Number3.Value / Number4.Value
            'mod2 = Number3.Value Mod Number4.Value

            'div3 = Number6.Value / Number4.Value
            'mod3 = Number6.Value Mod Number4.Value

            For j = 1 To Number4.Value
                strSQL = "INSERT INTO All8_Wrn_sub"
                strSQL += " (ordr_no, line_no, seq, cont_flg, item_cat_code, bend_code, pos_code, model_name, prch_unit"
                strSQL += ", prch_price, prch_price_tax, wrn_fee, wrn_fee_tax, wrn_fee_ORG, wrn_fee_tax_ORG, prvd_cls"
                strSQL += ", prch_date, fin_date, wrn_prod, txt_ID, kbn_cd, rcv_flg"
                strSQL += ", item_cat_code1, item_cat_code1_name, item_cat_code2, item_cat_code2_name, item_cat_code3"
                strSQL += ", item_cat_code3_name, data_seq, wrn_item_code, wrn_item_name, BY_cls)"
                strSQL += " VALUES ('" & Edit1.Text & "'"
                strSQL += ", '" & Format(Number8.Value, "00") & "'"
                strSQL += ", " & j
                strSQL += ", 'A'"
                strSQL += ", '" & ComboBox1.SelectedValue & ComboBox2.SelectedValue & ComboBox3.SelectedValue & "'"
                strSQL += ", '" & ComboBox4.SelectedValue & "'"
                strSQL += ", '" & Edit10.Text & "'"
                strSQL += ", '" & Edit11.Text & "'"
                strSQL += ", 1"
                'If j = 1 Then strSQL += ", " & div1 + mod1 Else strSQL += ", " & div1
                'If j = 1 Then strSQL += ", " & div1 + mod1 + div2 + mod2 Else strSQL += ", " & div1 + div2
                'If j = 1 Then strSQL += ", " & div3 + mod3 Else strSQL += ", " & div3
                'If j = 1 Then strSQL += ", " & RoundDOWN((div3 + mod3) * 1.05, 0) Else strSQL += ", " & RoundDOWN(div3 * 1.05, 0)
                'If j = 1 Then strSQL += ", " & div3 + mod3 Else strSQL += ", " & div3
                'If j = 1 Then strSQL += ", " & RoundDOWN((div3 + mod3) * 1.05, 0) Else strSQL += ", " & RoundDOWN(div3 * 1.05, 0)
                strSQL += ", " & Number2.Value
                strSQL += ", " & Number2.Value + Number3.Value
                strSQL += ", " & Number6.Value
                strSQL += ", " & RoundDOWN(Number6.Value * 1.1, 0) '消費税10%対応　2019/10/18
                strSQL += ", " & Number6.Value
                strSQL += ", " & RoundDOWN(Number6.Value * 1.1, 0) '消費税10%対応　2019/10/18
                strSQL += ", ''"
                strSQL += ", CONVERT(DATETIME, '" & Date1.Text & "', 102)"
                If Date2.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date2.Text & "', 102)" Else strSQL += ", NULL"
                strSQL += ", " & Number7.Value
                strSQL += ", 0"
                strSQL += ", N'" & ComboBox6.SelectedValue & "'"
                strSQL += ", '0'"
                strSQL += ", '" & ComboBox1.SelectedValue & "'"
                WK_DtView1 = New DataView(DsCmb1.Tables("Cat_mtr"), "cat_name1 = '" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & MidB(Trim(WK_DtView1(0)("cat_name1_n")), 1, 10) & "'"
                strSQL += ", '" & ComboBox2.SelectedValue & "'"
                WK_DtView1 = New DataView(DsCmb2.Tables("Cat_mtr"), "cat_name2 = '" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & MidB(Trim(WK_DtView1(0)("cat_name2_n")), 1, 10) & "'"
                strSQL += ", '" & ComboBox3.SelectedValue & "'"
                WK_DtView1 = New DataView(DsCmb3.Tables("Cat_mtr"), "cat_name3 = '" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & MidB(Trim(WK_DtView1(0)("cat_name3_n")), 1, 10) & "'"
                strSQL += ", " & Number5.Value
                strSQL += ", '" & Edit12.Text & "'"
                strSQL += ", '" & Edit13.Text & "'"
                If RadioButton1.Checked = True Then
                    strSQL += ", 'B')"
                Else
                    strSQL += ", 'Y')"
                End If
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next
        End If

        If RadioButton4.Checked = True Then   '完了
            strSQL = "SELECT seq FROM All8_Wrn_sub"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
            strSQL += " AND (cont_flg = 'A') AND (fin_date IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To WK_DtView1.Count - 1
                strSQL = "UPDATE All8_Wrn_sub"
                strSQL += " SET fin_date = CONVERT(DATETIME, '" & Date2.Text & "', 102)"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next

            '完了の時、オール電化の判断ができないので両方に検索更新
            strSQL = "SELECT seq FROM Wrn_sub"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
            strSQL += " AND (cont_flg = 'A') AND (fin_date IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "Wrn_sub")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To WK_DtView1.Count - 1
                strSQL = "UPDATE Wrn_sub"
                strSQL += " SET fin_date = CONVERT(DATETIME, '" & Date2.Text & "', 102)"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next
        End If

        If RadioButton5.Checked = True Then   'キャンセル
            strSQL = "SELECT seq, close_date FROM All8_Wrn_sub"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
            strSQL += " AND (cont_flg = 'A')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For j = 0 To CInt(Number4.Value) - 1
                    strSQL = "UPDATE All8_Wrn_sub"
                    strSQL += " SET cxl_shop_code = '" & ComboBox5.SelectedValue & "'"
                    strSQL += ", cxl_date = CONVERT(DATETIME, '" & Date3.Text & "', 102)"
                    strSQL += ", cont_flg = 'C'"
                    strSQL += ", close_date = NULL, close_cont_flg = NULL"
                    strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                    strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                    strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                    strSQL += " AND (cont_flg = 'A')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    If Not IsDBNull(WK_DtView1(j)("close_date")) Then
                        strSQL = "SELECT * FROM All8_fst_close_date"
                        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                        strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                        strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "All8_fst_close_date")
                        DB_CLOSE()
                        If r = 0 Then
                            strSQL = "INSERT INTO All8_fst_close_date"
                            strSQL += " (ordr_no, line_no, seq, fst_close_date)"
                            strSQL += " VALUES ('" & Edit1.Text & "'"
                            strSQL += ", '" & Format(Number8.Value, "00") & "'"
                            strSQL += ", " & WK_DtView1(j)("seq")
                            strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(j)("close_date") & "', 102))"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DB_OPEN()
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()
                        End If
                    End If
                Next
            End If
        End If

        If RadioButton6.Checked = True Then   '完了キャンセル
            strSQL = "SELECT seq FROM All8_Wrn_sub"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
            strSQL += " AND (cont_flg = 'A') AND (fin_date IS NOT NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To WK_DtView1.Count - 1
                strSQL = "UPDATE All8_Wrn_sub"
                strSQL += " SET fin_date = NULL"
                strSQL += ", close_date = NULL, close_cont_flg = NULL"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Format(Number8.Value, "00") & "')"
                strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                strSQL += " AND (cont_flg = 'A') AND (fin_date IS NOT NULL)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next
        End If
    End Sub

    '***************************************************************************
    '** 戻る
    '***************************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        DsCmb1.Clear()
        DsCmb2.Clear()
        DsCmb3.Clear()
        DsCmb4.Clear()
        DsCmb5.Clear()
        DsCmb6.Clear()
        P_Rtn = "0"
        Me.Close()
    End Sub
End Class
