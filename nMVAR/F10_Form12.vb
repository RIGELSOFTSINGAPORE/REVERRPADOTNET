Public Class F10_Form12
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL As String
    Dim i, WK_tax As Integer

#Region " Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ê∂ê¨Ç≥ÇÍÇΩÉRÅ[Éh "

    Public Sub New()
        MyBase.New()

        ' Ç±ÇÃåƒÇ—èoÇµÇÕ Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ïKóvÇ≈Ç∑ÅB
        InitializeComponent()

        ' InitializeComponent() åƒÇ—èoÇµÇÃå„Ç…èâä˙âªÇí«â¡ÇµÇ‹Ç∑ÅB

    End Sub

    ' Form ÇÕÅAÉRÉìÉ|Å[ÉlÉìÉgàÍóóÇ…å„èàóùÇé¿çsÇ∑ÇÈÇΩÇﬂÇ… dispose ÇÉIÅ[ÉoÅ[ÉâÉCÉhÇµÇ‹Ç∑ÅB
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ïKóvÇ≈Ç∑ÅB
    Private components As System.ComponentModel.IContainer

    ' ÉÅÉÇ : à»â∫ÇÃÉvÉçÉVÅ[ÉWÉÉÇÕÅAWindows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ïKóvÇ≈Ç∑ÅB
    'Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇégÇ¡ÇƒïœçXÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB  
    ' ÉRÅ[Éh ÉGÉfÉBÉ^ÇégÇ¡ÇƒïœçXÇµÇ»Ç¢Ç≈Ç≠ÇæÇ≥Ç¢ÅB
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button0 As System.Windows.Forms.Button
    Friend WithEvents Edit000 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Number029 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number019 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number016 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Number015 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number025 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number024 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number017 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Number032 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number012 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number031 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number022 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number011 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number014 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents Number021 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number033 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label22_1 As System.Windows.Forms.Label
    Friend WithEvents Label23_1 As System.Windows.Forms.Label
    Friend WithEvents Number037 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number036 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number035 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number034 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents Number023 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number013 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Number027 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Number038 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number028 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number018 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number026 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Date004 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents calc_cls As System.Windows.Forms.Label
    Friend WithEvents tax_rate As System.Windows.Forms.Label
    Friend WithEvents Label001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F10_Form12))
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button0 = New System.Windows.Forms.Button
        Me.Edit000 = New GrapeCity.Win.Input.Interop.Edit
        Me.Button5 = New System.Windows.Forms.Button
        Me.Edit005 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label010 = New System.Windows.Forms.Label
        Me.Number029 = New GrapeCity.Win.Input.Interop.Number
        Me.Number019 = New GrapeCity.Win.Input.Interop.Number
        Me.Number016 = New GrapeCity.Win.Input.Interop.Number
        Me.Label133 = New System.Windows.Forms.Label
        Me.Label132 = New System.Windows.Forms.Label
        Me.Number015 = New GrapeCity.Win.Input.Interop.Number
        Me.Number025 = New GrapeCity.Win.Input.Interop.Number
        Me.Number024 = New GrapeCity.Win.Input.Interop.Number
        Me.Number017 = New GrapeCity.Win.Input.Interop.Number
        Me.Label11 = New System.Windows.Forms.Label
        Me.Number032 = New GrapeCity.Win.Input.Interop.Number
        Me.Number012 = New GrapeCity.Win.Input.Interop.Number
        Me.Number031 = New GrapeCity.Win.Input.Interop.Number
        Me.Number022 = New GrapeCity.Win.Input.Interop.Number
        Me.Number011 = New GrapeCity.Win.Input.Interop.Number
        Me.Number014 = New GrapeCity.Win.Input.Interop.Number
        Me.Label131 = New System.Windows.Forms.Label
        Me.Label130 = New System.Windows.Forms.Label
        Me.Label129 = New System.Windows.Forms.Label
        Me.Label128 = New System.Windows.Forms.Label
        Me.Number021 = New GrapeCity.Win.Input.Interop.Number
        Me.Number033 = New GrapeCity.Win.Input.Interop.Number
        Me.Label22_1 = New System.Windows.Forms.Label
        Me.Label23_1 = New System.Windows.Forms.Label
        Me.Number037 = New GrapeCity.Win.Input.Interop.Number
        Me.Number036 = New GrapeCity.Win.Input.Interop.Number
        Me.Number035 = New GrapeCity.Win.Input.Interop.Number
        Me.Number034 = New GrapeCity.Win.Input.Interop.Number
        Me.Label191 = New System.Windows.Forms.Label
        Me.Number023 = New GrapeCity.Win.Input.Interop.Number
        Me.Number013 = New GrapeCity.Win.Input.Interop.Number
        Me.Label138 = New System.Windows.Forms.Label
        Me.Number027 = New GrapeCity.Win.Input.Interop.Number
        Me.Label1 = New System.Windows.Forms.Label
        Me.Number038 = New GrapeCity.Win.Input.Interop.Number
        Me.Number028 = New GrapeCity.Win.Input.Interop.Number
        Me.Number018 = New GrapeCity.Win.Input.Interop.Number
        Me.Number026 = New GrapeCity.Win.Input.Interop.Number
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Date004 = New GrapeCity.Win.Input.Interop.Date
        Me.Label36 = New System.Windows.Forms.Label
        Me.calc_cls = New System.Windows.Forms.Label
        Me.tax_rate = New System.Windows.Forms.Label
        Me.Label001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label003 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number029, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number019, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number016, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number025, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number024, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number017, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number032, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number031, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number022, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number011, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number014, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number021, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number033, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number037, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number036, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number035, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number034, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number023, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number027, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number038, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number028, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number018, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number026, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(20, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 1723
        Me.Label9.Text = "éÛïtî‘çÜ"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button0
        '
        Me.Button0.BackColor = System.Drawing.SystemColors.Control
        Me.Button0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button0.Location = New System.Drawing.Point(172, 20)
        Me.Button0.Name = "Button0"
        Me.Button0.Size = New System.Drawing.Size(28, 20)
        Me.Button0.TabIndex = 1722
        Me.Button0.TabStop = False
        Me.Button0.Text = "ÅH"
        '
        'Edit000
        '
        Me.Edit000.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit000.Format = "A9"
        Me.Edit000.HighlightText = True
        Me.Edit000.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit000.LengthAsByte = True
        Me.Edit000.Location = New System.Drawing.Point(100, 20)
        Me.Edit000.MaxLength = 9
        Me.Edit000.Name = "Edit000"
        Me.Edit000.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit000.Size = New System.Drawing.Size(68, 20)
        Me.Edit000.TabIndex = 0
        Me.Edit000.Text = "AS1234567"
        Me.Edit000.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit000.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(24, 208)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "å©êœèë"
        '
        'Edit005
        '
        Me.Edit005.BackColor = System.Drawing.SystemColors.Control
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.Enabled = False
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(100, 48)
        Me.Edit005.MaxLength = 30
        Me.Edit005.Name = "Edit005"
        Me.Edit005.ReadOnly = True
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(196, 20)
        Me.Edit005.TabIndex = 1725
        Me.Edit005.TabStop = False
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label010
        '
        Me.Label010.BackColor = System.Drawing.Color.Navy
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.ForeColor = System.Drawing.Color.White
        Me.Label010.Location = New System.Drawing.Point(20, 48)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(80, 20)
        Me.Label010.TabIndex = 1726
        Me.Label010.Text = "Ç®ãqólñº"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number029
        '
        Me.Number029.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number029.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number029.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number029.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number029.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number029.Enabled = False
        Me.Number029.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number029.HighlightText = True
        Me.Number029.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number029.Location = New System.Drawing.Point(524, 140)
        Me.Number029.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number029.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number029.Name = "Number029"
        Me.Number029.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number029.Size = New System.Drawing.Size(104, 20)
        Me.Number029.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number029.TabIndex = 1877
        Me.Number029.TabStop = False
        Me.Number029.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number029.Value = New Decimal(New Integer() {29, 0, 0, 0})
        '
        'Number019
        '
        Me.Number019.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number019.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number019.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number019.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number019.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number019.Enabled = False
        Me.Number019.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number019.HighlightText = True
        Me.Number019.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number019.Location = New System.Drawing.Point(524, 120)
        Me.Number019.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number019.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number019.Name = "Number019"
        Me.Number019.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number019.Size = New System.Drawing.Size(104, 20)
        Me.Number019.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number019.TabIndex = 1876
        Me.Number019.TabStop = False
        Me.Number019.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number019.Value = New Decimal(New Integer() {19, 0, 0, 0})
        '
        'Number016
        '
        Me.Number016.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number016.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number016.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number016.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number016.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number016.Enabled = False
        Me.Number016.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number016.HighlightText = True
        Me.Number016.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number016.Location = New System.Drawing.Point(360, 120)
        Me.Number016.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number016.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number016.Name = "Number016"
        Me.Number016.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number016.Size = New System.Drawing.Size(52, 20)
        Me.Number016.TabIndex = 1846
        Me.Number016.TabStop = False
        Me.Number016.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number016.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'Label133
        '
        Me.Label133.BackColor = System.Drawing.Color.Navy
        Me.Label133.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label133.ForeColor = System.Drawing.Color.White
        Me.Label133.Location = New System.Drawing.Point(20, 160)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(80, 20)
        Me.Label133.TabIndex = 1866
        Me.Label133.Text = "ÉRÉXÉg"
        Me.Label133.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.Color.Navy
        Me.Label132.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label132.ForeColor = System.Drawing.Color.White
        Me.Label132.Location = New System.Drawing.Point(20, 120)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(80, 20)
        Me.Label132.TabIndex = 1865
        Me.Label132.Text = "åvè„äz"
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number015
        '
        Me.Number015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number015.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number015.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number015.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number015.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number015.Enabled = False
        Me.Number015.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number015.HighlightText = True
        Me.Number015.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number015.Location = New System.Drawing.Point(308, 120)
        Me.Number015.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number015.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number015.Name = "Number015"
        Me.Number015.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number015.Size = New System.Drawing.Size(52, 20)
        Me.Number015.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number015.TabIndex = 1844
        Me.Number015.TabStop = False
        Me.Number015.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number015.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Number025
        '
        Me.Number025.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number025.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number025.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number025.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number025.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number025.Enabled = False
        Me.Number025.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number025.HighlightText = True
        Me.Number025.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number025.Location = New System.Drawing.Point(308, 140)
        Me.Number025.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number025.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number025.Name = "Number025"
        Me.Number025.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number025.Size = New System.Drawing.Size(52, 20)
        Me.Number025.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number025.TabIndex = 1851
        Me.Number025.TabStop = False
        Me.Number025.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number025.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'Number024
        '
        Me.Number024.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number024.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number024.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number024.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number024.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number024.Enabled = False
        Me.Number024.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number024.HighlightText = True
        Me.Number024.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number024.Location = New System.Drawing.Point(256, 140)
        Me.Number024.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number024.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number024.Name = "Number024"
        Me.Number024.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number024.Size = New System.Drawing.Size(52, 20)
        Me.Number024.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number024.TabIndex = 1850
        Me.Number024.TabStop = False
        Me.Number024.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number024.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'Number017
        '
        Me.Number017.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number017.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number017.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number017.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number017.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number017.Enabled = False
        Me.Number017.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number017.HighlightText = True
        Me.Number017.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number017.Location = New System.Drawing.Point(412, 120)
        Me.Number017.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number017.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number017.Name = "Number017"
        Me.Number017.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number017.Size = New System.Drawing.Size(52, 20)
        Me.Number017.TabIndex = 1847
        Me.Number017.TabStop = False
        Me.Number017.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number017.Value = New Decimal(New Integer() {17, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(524, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 20)
        Me.Label11.TabIndex = 1871
        Me.Label11.Text = "êfífóøÅiÉLÉÉÉìÉZÉãÅj"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number032
        '
        Me.Number032.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number032.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number032.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number032.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number032.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number032.Enabled = False
        Me.Number032.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number032.HighlightText = True
        Me.Number032.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number032.Location = New System.Drawing.Point(152, 160)
        Me.Number032.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number032.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number032.Name = "Number032"
        Me.Number032.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number032.Size = New System.Drawing.Size(52, 20)
        Me.Number032.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number032.TabIndex = 1853
        Me.Number032.TabStop = False
        Me.Number032.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number032.Value = New Decimal(New Integer() {32, 0, 0, 0})
        '
        'Number012
        '
        Me.Number012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number012.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number012.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number012.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number012.Enabled = False
        Me.Number012.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number012.HighlightText = True
        Me.Number012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number012.Location = New System.Drawing.Point(152, 120)
        Me.Number012.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number012.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number012.Name = "Number012"
        Me.Number012.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number012.Size = New System.Drawing.Size(52, 20)
        Me.Number012.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.TabIndex = 1841
        Me.Number012.TabStop = False
        Me.Number012.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number012.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'Number031
        '
        Me.Number031.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number031.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number031.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number031.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number031.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number031.Enabled = False
        Me.Number031.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number031.HighlightText = True
        Me.Number031.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number031.Location = New System.Drawing.Point(100, 160)
        Me.Number031.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number031.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number031.Name = "Number031"
        Me.Number031.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number031.Size = New System.Drawing.Size(52, 20)
        Me.Number031.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number031.TabIndex = 1852
        Me.Number031.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number031.Value = New Decimal(New Integer() {31, 0, 0, 0})
        '
        'Number022
        '
        Me.Number022.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number022.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number022.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number022.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number022.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number022.Enabled = False
        Me.Number022.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number022.HighlightText = True
        Me.Number022.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number022.Location = New System.Drawing.Point(152, 140)
        Me.Number022.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number022.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number022.Name = "Number022"
        Me.Number022.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number022.Size = New System.Drawing.Size(52, 20)
        Me.Number022.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number022.TabIndex = 1848
        Me.Number022.TabStop = False
        Me.Number022.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number022.Value = New Decimal(New Integer() {22, 0, 0, 0})
        '
        'Number011
        '
        Me.Number011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number011.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number011.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number011.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number011.Enabled = False
        Me.Number011.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number011.HighlightText = True
        Me.Number011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number011.Location = New System.Drawing.Point(100, 120)
        Me.Number011.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number011.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number011.Name = "Number011"
        Me.Number011.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number011.Size = New System.Drawing.Size(52, 20)
        Me.Number011.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.TabIndex = 1840
        Me.Number011.TabStop = False
        Me.Number011.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number011.Value = New Decimal(New Integer() {11, 0, 0, 0})
        '
        'Number014
        '
        Me.Number014.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number014.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number014.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number014.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number014.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number014.Enabled = False
        Me.Number014.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number014.HighlightText = True
        Me.Number014.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number014.Location = New System.Drawing.Point(256, 120)
        Me.Number014.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number014.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number014.Name = "Number014"
        Me.Number014.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number014.Size = New System.Drawing.Size(52, 20)
        Me.Number014.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number014.TabIndex = 1843
        Me.Number014.TabStop = False
        Me.Number014.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number014.Value = New Decimal(New Integer() {14, 0, 0, 0})
        '
        'Label131
        '
        Me.Label131.BackColor = System.Drawing.Color.Navy
        Me.Label131.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label131.ForeColor = System.Drawing.Color.White
        Me.Label131.Location = New System.Drawing.Point(464, 100)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(52, 20)
        Me.Label131.TabIndex = 1864
        Me.Label131.Text = "çáÅ@åv"
        Me.Label131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label130
        '
        Me.Label130.BackColor = System.Drawing.Color.Navy
        Me.Label130.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label130.ForeColor = System.Drawing.Color.White
        Me.Label130.Location = New System.Drawing.Point(412, 100)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(52, 20)
        Me.Label130.TabIndex = 1863
        Me.Label130.Text = "è¡îÔê≈"
        Me.Label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label129
        '
        Me.Label129.BackColor = System.Drawing.Color.Navy
        Me.Label129.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label129.ForeColor = System.Drawing.Color.White
        Me.Label129.Location = New System.Drawing.Point(308, 100)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(52, 20)
        Me.Label129.TabIndex = 1862
        Me.Label129.Text = "ëóÅ@óø"
        Me.Label129.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label128
        '
        Me.Label128.BackColor = System.Drawing.Color.Navy
        Me.Label128.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label128.ForeColor = System.Drawing.Color.White
        Me.Label128.Location = New System.Drawing.Point(256, 100)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(52, 20)
        Me.Label128.TabIndex = 1861
        Me.Label128.Text = "ÇªÇÃëº"
        Me.Label128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number021
        '
        Me.Number021.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number021.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number021.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number021.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number021.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number021.Enabled = False
        Me.Number021.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number021.HighlightText = True
        Me.Number021.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number021.Location = New System.Drawing.Point(100, 140)
        Me.Number021.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number021.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number021.Name = "Number021"
        Me.Number021.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number021.Size = New System.Drawing.Size(52, 20)
        Me.Number021.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number021.TabIndex = 1845
        Me.Number021.TabStop = False
        Me.Number021.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number021.Value = New Decimal(New Integer() {21, 0, 0, 0})
        '
        'Number033
        '
        Me.Number033.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number033.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number033.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number033.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number033.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number033.Enabled = False
        Me.Number033.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number033.HighlightText = True
        Me.Number033.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number033.Location = New System.Drawing.Point(204, 160)
        Me.Number033.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number033.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number033.Name = "Number033"
        Me.Number033.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number033.Size = New System.Drawing.Size(52, 20)
        Me.Number033.TabIndex = 1854
        Me.Number033.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number033.Value = New Decimal(New Integer() {33, 0, 0, 0})
        '
        'Label22_1
        '
        Me.Label22_1.BackColor = System.Drawing.Color.Navy
        Me.Label22_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22_1.ForeColor = System.Drawing.Color.White
        Me.Label22_1.Location = New System.Drawing.Point(100, 100)
        Me.Label22_1.Name = "Label22_1"
        Me.Label22_1.Size = New System.Drawing.Size(52, 20)
        Me.Label22_1.TabIndex = 1869
        Me.Label22_1.Text = "ãZèp"
        Me.Label22_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23_1
        '
        Me.Label23_1.BackColor = System.Drawing.Color.Navy
        Me.Label23_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23_1.ForeColor = System.Drawing.Color.White
        Me.Label23_1.Location = New System.Drawing.Point(204, 100)
        Me.Label23_1.Name = "Label23_1"
        Me.Label23_1.Size = New System.Drawing.Size(52, 20)
        Me.Label23_1.TabIndex = 1870
        Me.Label23_1.Text = "ïîïi"
        Me.Label23_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number037
        '
        Me.Number037.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number037.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number037.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number037.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number037.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number037.Enabled = False
        Me.Number037.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number037.HighlightText = True
        Me.Number037.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number037.Location = New System.Drawing.Point(412, 160)
        Me.Number037.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number037.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number037.Name = "Number037"
        Me.Number037.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number037.Size = New System.Drawing.Size(52, 20)
        Me.Number037.TabIndex = 1860
        Me.Number037.TabStop = False
        Me.Number037.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number037.Value = New Decimal(New Integer() {37, 0, 0, 0})
        '
        'Number036
        '
        Me.Number036.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number036.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number036.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number036.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number036.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number036.Enabled = False
        Me.Number036.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number036.HighlightText = True
        Me.Number036.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number036.Location = New System.Drawing.Point(360, 160)
        Me.Number036.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number036.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number036.Name = "Number036"
        Me.Number036.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number036.Size = New System.Drawing.Size(52, 20)
        Me.Number036.TabIndex = 1859
        Me.Number036.TabStop = False
        Me.Number036.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number036.Value = New Decimal(New Integer() {36, 0, 0, 0})
        '
        'Number035
        '
        Me.Number035.BackColor = System.Drawing.Color.White
        Me.Number035.DisabledForeColor = System.Drawing.Color.Black
        Me.Number035.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number035.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number035.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number035.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number035.Enabled = False
        Me.Number035.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number035.HighlightText = True
        Me.Number035.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number035.Location = New System.Drawing.Point(308, 160)
        Me.Number035.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number035.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number035.Name = "Number035"
        Me.Number035.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number035.Size = New System.Drawing.Size(52, 20)
        Me.Number035.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number035.TabIndex = 1856
        Me.Number035.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number035.Value = New Decimal(New Integer() {35, 0, 0, 0})
        '
        'Number034
        '
        Me.Number034.BackColor = System.Drawing.Color.White
        Me.Number034.DisabledForeColor = System.Drawing.Color.Black
        Me.Number034.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number034.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number034.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number034.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number034.Enabled = False
        Me.Number034.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number034.HighlightText = True
        Me.Number034.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number034.Location = New System.Drawing.Point(256, 160)
        Me.Number034.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number034.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number034.Name = "Number034"
        Me.Number034.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number034.Size = New System.Drawing.Size(52, 20)
        Me.Number034.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number034.TabIndex = 1855
        Me.Number034.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number034.Value = New Decimal(New Integer() {34, 0, 0, 0})
        '
        'Label191
        '
        Me.Label191.BackColor = System.Drawing.Color.Navy
        Me.Label191.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label191.ForeColor = System.Drawing.Color.White
        Me.Label191.Location = New System.Drawing.Point(20, 140)
        Me.Label191.Name = "Label191"
        Me.Label191.Size = New System.Drawing.Size(80, 20)
        Me.Label191.TabIndex = 1868
        Me.Label191.Text = "EUâøäi"
        Me.Label191.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number023
        '
        Me.Number023.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number023.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number023.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number023.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number023.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number023.Enabled = False
        Me.Number023.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number023.HighlightText = True
        Me.Number023.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number023.Location = New System.Drawing.Point(204, 140)
        Me.Number023.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number023.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number023.Name = "Number023"
        Me.Number023.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number023.Size = New System.Drawing.Size(52, 20)
        Me.Number023.TabIndex = 1849
        Me.Number023.TabStop = False
        Me.Number023.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number023.Value = New Decimal(New Integer() {23, 0, 0, 0})
        '
        'Number013
        '
        Me.Number013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number013.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number013.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number013.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number013.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number013.Enabled = False
        Me.Number013.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number013.HighlightText = True
        Me.Number013.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number013.Location = New System.Drawing.Point(204, 120)
        Me.Number013.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number013.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number013.Name = "Number013"
        Me.Number013.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number013.Size = New System.Drawing.Size(52, 20)
        Me.Number013.TabIndex = 1842
        Me.Number013.TabStop = False
        Me.Number013.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number013.Value = New Decimal(New Integer() {13, 0, 0, 0})
        '
        'Label138
        '
        Me.Label138.BackColor = System.Drawing.Color.Navy
        Me.Label138.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label138.ForeColor = System.Drawing.Color.White
        Me.Label138.Location = New System.Drawing.Point(360, 100)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(52, 20)
        Me.Label138.TabIndex = 1867
        Me.Label138.Text = "è¨åv"
        Me.Label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number027
        '
        Me.Number027.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number027.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number027.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number027.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number027.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number027.Enabled = False
        Me.Number027.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number027.HighlightText = True
        Me.Number027.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number027.Location = New System.Drawing.Point(412, 140)
        Me.Number027.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number027.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number027.Name = "Number027"
        Me.Number027.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number027.Size = New System.Drawing.Size(52, 20)
        Me.Number027.TabIndex = 1858
        Me.Number027.TabStop = False
        Me.Number027.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number027.Value = New Decimal(New Integer() {27, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(152, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 20)
        Me.Label1.TabIndex = 1875
        Me.Label1.Text = "AP SE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number038
        '
        Me.Number038.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number038.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number038.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number038.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number038.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number038.Enabled = False
        Me.Number038.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number038.HighlightText = True
        Me.Number038.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number038.Location = New System.Drawing.Point(464, 160)
        Me.Number038.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number038.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number038.Name = "Number038"
        Me.Number038.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number038.Size = New System.Drawing.Size(52, 20)
        Me.Number038.TabIndex = 1874
        Me.Number038.TabStop = False
        Me.Number038.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number038.Value = New Decimal(New Integer() {38, 0, 0, 0})
        '
        'Number028
        '
        Me.Number028.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number028.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number028.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number028.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number028.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number028.Enabled = False
        Me.Number028.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number028.HighlightText = True
        Me.Number028.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number028.Location = New System.Drawing.Point(464, 140)
        Me.Number028.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number028.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number028.Name = "Number028"
        Me.Number028.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number028.Size = New System.Drawing.Size(52, 20)
        Me.Number028.TabIndex = 1873
        Me.Number028.TabStop = False
        Me.Number028.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number028.Value = New Decimal(New Integer() {28, 0, 0, 0})
        '
        'Number018
        '
        Me.Number018.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number018.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number018.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number018.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number018.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number018.Enabled = False
        Me.Number018.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number018.HighlightText = True
        Me.Number018.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number018.Location = New System.Drawing.Point(464, 120)
        Me.Number018.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number018.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number018.Name = "Number018"
        Me.Number018.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number018.Size = New System.Drawing.Size(52, 20)
        Me.Number018.TabIndex = 1872
        Me.Number018.TabStop = False
        Me.Number018.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number018.Value = New Decimal(New Integer() {18, 0, 0, 0})
        '
        'Number026
        '
        Me.Number026.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number026.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number026.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number026.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number026.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number026.Enabled = False
        Me.Number026.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number026.HighlightText = True
        Me.Number026.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number026.Location = New System.Drawing.Point(360, 140)
        Me.Number026.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number026.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number026.Name = "Number026"
        Me.Number026.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number026.Size = New System.Drawing.Size(52, 20)
        Me.Number026.TabIndex = 1857
        Me.Number026.TabStop = False
        Me.Number026.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number026.Value = New Decimal(New Integer() {26, 0, 0, 0})
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(540, 208)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "ñﬂÇÈ"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(124, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "ÉNÉäÉA"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(24, 184)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(604, 16)
        Me.msg.TabIndex = 1880
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date004
        '
        Me.Date004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date004.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date004.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date004.Enabled = False
        Me.Date004.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date004.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date004.Location = New System.Drawing.Point(544, 44)
        Me.Date004.Name = "Date004"
        Me.Date004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date004.Size = New System.Drawing.Size(88, 20)
        Me.Date004.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date004.TabIndex = 1881
        Me.Date004.TabStop = False
        Me.Date004.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date004.Value = Nothing
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Navy
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(464, 44)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(80, 20)
        Me.Label36.TabIndex = 1882
        Me.Label36.Text = "å©êœì˙"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'calc_cls
        '
        Me.calc_cls.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.calc_cls.Location = New System.Drawing.Point(580, 160)
        Me.calc_cls.Name = "calc_cls"
        Me.calc_cls.Size = New System.Drawing.Size(40, 16)
        Me.calc_cls.TabIndex = 1883
        Me.calc_cls.Text = "1"
        Me.calc_cls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.calc_cls.Visible = False
        '
        'tax_rate
        '
        Me.tax_rate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.tax_rate.Location = New System.Drawing.Point(536, 160)
        Me.tax_rate.Name = "tax_rate"
        Me.tax_rate.Size = New System.Drawing.Size(40, 16)
        Me.tax_rate.TabIndex = 1884
        Me.tax_rate.Text = "1"
        Me.tax_rate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tax_rate.Visible = False
        '
        'Label001
        '
        Me.Label001.BackColor = System.Drawing.SystemColors.Control
        Me.Label001.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label001.Enabled = False
        Me.Label001.HighlightText = True
        Me.Label001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Label001.LengthAsByte = True
        Me.Label001.Location = New System.Drawing.Point(156, 72)
        Me.Label001.MaxLength = 40
        Me.Label001.Name = "Label001"
        Me.Label001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Label001.Size = New System.Drawing.Size(296, 20)
        Me.Label001.TabIndex = 1887
        Me.Label001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label003
        '
        Me.Label003.BackColor = System.Drawing.Color.Navy
        Me.Label003.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label003.ForeColor = System.Drawing.Color.White
        Me.Label003.Location = New System.Drawing.Point(20, 72)
        Me.Label003.Name = "Label003"
        Me.Label003.Size = New System.Drawing.Size(80, 20)
        Me.Label003.TabIndex = 1886
        Me.Label003.Text = "îÃé–"
        Me.Label003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.AllowSpace = False
        Me.Edit001.BackColor = System.Drawing.SystemColors.Control
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Enabled = False
        Me.Edit001.Format = "9"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(100, 72)
        Me.Edit001.MaxLength = 4
        Me.Edit001.Name = "Edit001"
        Me.Edit001.ReadOnly = True
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(48, 20)
        Me.Edit001.TabIndex = 1885
        Me.Edit001.TabStop = False
        Me.Edit001.Text = "9999"
        Me.Edit001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'F10_Form12
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(638, 240)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.calc_cls)
        Me.Controls.Add(Me.tax_rate)
        Me.Controls.Add(Me.Date004)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Number029)
        Me.Controls.Add(Me.Number019)
        Me.Controls.Add(Me.Number016)
        Me.Controls.Add(Me.Label133)
        Me.Controls.Add(Me.Label132)
        Me.Controls.Add(Me.Number015)
        Me.Controls.Add(Me.Number025)
        Me.Controls.Add(Me.Number024)
        Me.Controls.Add(Me.Number017)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Number032)
        Me.Controls.Add(Me.Number012)
        Me.Controls.Add(Me.Number031)
        Me.Controls.Add(Me.Number022)
        Me.Controls.Add(Me.Number011)
        Me.Controls.Add(Me.Number014)
        Me.Controls.Add(Me.Label131)
        Me.Controls.Add(Me.Label130)
        Me.Controls.Add(Me.Label129)
        Me.Controls.Add(Me.Label128)
        Me.Controls.Add(Me.Number021)
        Me.Controls.Add(Me.Number033)
        Me.Controls.Add(Me.Label22_1)
        Me.Controls.Add(Me.Label23_1)
        Me.Controls.Add(Me.Number037)
        Me.Controls.Add(Me.Number036)
        Me.Controls.Add(Me.Number035)
        Me.Controls.Add(Me.Number034)
        Me.Controls.Add(Me.Label191)
        Me.Controls.Add(Me.Number023)
        Me.Controls.Add(Me.Number013)
        Me.Controls.Add(Me.Label138)
        Me.Controls.Add(Me.Number027)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Number038)
        Me.Controls.Add(Me.Number028)
        Me.Controls.Add(Me.Number018)
        Me.Controls.Add(Me.Number026)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button0)
        Me.Controls.Add(Me.Edit000)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F10_Form12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "å©êœèëàÛç¸"
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number029, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number019, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number016, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number025, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number024, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number017, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number032, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number031, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number022, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number011, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number014, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number021, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number033, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number037, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number036, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number035, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number034, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number023, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number027, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number038, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number028, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number018, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number026, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  ãNìÆéû
    '********************************************************************
    Private Sub F10_Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  èâä˙èàóù
        Inz_Dsp()   '**  èâä˙âÊñ ÉZÉbÉg

    End Sub

    '********************************************************************
    '**  èâä˙èàóù
    '********************************************************************
    Sub inz()
        'Å~ï¬Ç∂ÇÈÇégópïsâ¬
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '008')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "tax")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("tax"), "", "", DataViewRowState.CurrentRows)
        WK_tax = DtView1(0)("cls_code_name")

    End Sub

    '********************************************************************
    '**  èâä˙âÊñ ÉZÉbÉg
    '********************************************************************
    Sub Inz_Dsp()
        P_PRT_F = "0"   'ïîïiâøäiñ‚çáÇπï[àÛç¸ÉtÉâÉO
        msg.Text = Nothing
        Edit000.Text = Nothing : Edit000.ReadOnly = False 'éÛïtî‘çÜ
        Edit000.BackColor = System.Drawing.SystemColors.Window
        Edit005.Text = Nothing
        Edit001.Text = Nothing
        Label001.Text = Nothing

        Button0.Enabled = True
        Button2.Enabled = False
        Button5.Enabled = False

        Number011.Enabled = False : Number011.Value = 0 : Number011.BackColor = System.Drawing.SystemColors.Window
        Number012.Enabled = False : Number012.Value = 0 : Number012.BackColor = System.Drawing.SystemColors.Window
        Number013.Enabled = False : Number013.Value = 0 : Number013.BackColor = System.Drawing.SystemColors.Window
        Number014.Enabled = False : Number014.Value = 0 : Number014.BackColor = System.Drawing.SystemColors.Window
        Number015.Enabled = False : Number015.Value = 0 : Number015.BackColor = System.Drawing.SystemColors.Window
        Number016.Enabled = False : Number016.Value = 0 : Number016.BackColor = System.Drawing.SystemColors.Window
        Number017.Enabled = False : Number017.Value = 0 : Number017.BackColor = System.Drawing.SystemColors.Window
        Number018.Enabled = False : Number018.Value = 0 : Number018.BackColor = System.Drawing.SystemColors.Window
        Number021.Enabled = False : Number021.Value = 0 : Number021.BackColor = System.Drawing.SystemColors.Window
        Number022.Enabled = False : Number022.Value = 0 : Number022.BackColor = System.Drawing.SystemColors.Window
        Number023.Enabled = False : Number023.Value = 0 : Number023.BackColor = System.Drawing.SystemColors.Window
        Number024.Enabled = False : Number024.Value = 0 : Number024.BackColor = System.Drawing.SystemColors.Window
        Number025.Enabled = False : Number025.Value = 0 : Number025.BackColor = System.Drawing.SystemColors.Window
        Number026.Enabled = False : Number026.Value = 0 : Number026.BackColor = System.Drawing.SystemColors.Window
        Number027.Enabled = False : Number027.Value = 0 : Number027.BackColor = System.Drawing.SystemColors.Window
        Number028.Enabled = False : Number028.Value = 0 : Number028.BackColor = System.Drawing.SystemColors.Window
        Number031.Enabled = False : Number031.Value = 0 : Number031.BackColor = System.Drawing.SystemColors.Window
        Number032.Enabled = False : Number032.Value = 0 : Number032.BackColor = System.Drawing.SystemColors.Window
        Number033.Enabled = False : Number033.Value = 0 : Number033.BackColor = System.Drawing.SystemColors.Window
        Number034.Enabled = False : Number034.Value = 0 : Number034.BackColor = System.Drawing.SystemColors.Window
        Number035.Enabled = False : Number035.Value = 0 : Number035.BackColor = System.Drawing.SystemColors.Window
        Number036.Enabled = False : Number036.Value = 0 : Number036.BackColor = System.Drawing.SystemColors.Window
        Number037.Enabled = False : Number037.Value = 0 : Number037.BackColor = System.Drawing.SystemColors.Window
        Number038.Enabled = False : Number038.Value = 0 : Number038.BackColor = System.Drawing.SystemColors.Window

        Number019.Enabled = False : Number019.Value = 0 : Number019.BackColor = System.Drawing.SystemColors.Window
        Number029.Enabled = False : Number029.Value = 0 : Number029.BackColor = System.Drawing.SystemColors.Window

        DsList1.Clear()

        Edit000.Focus()
    End Sub

    '********************************************************************
    '**  éÛïtî‘çÜEnter
    '********************************************************************
    Private Sub Edit000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Edit000.KeyDown
        If e.KeyCode = Keys.Enter Then
            rep_scan()  '** èCóùèÓïÒÇfÇdÇs
        End If
    End Sub

    '********************************************************************
    '** ÅHéÛïtî‘çÜåüçı
    '********************************************************************
    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form04 As New F00_Form04
        F00_Form04.ShowDialog()

        If P_RTN = "1" Then
            Edit000.Text = P_PRAM1
            rep_scan()  '** èCóùèÓïÒÇfÇdÇs
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '** èCóùèÓïÒÇfÇdÇs(SQL)
    '********************************************************************
    Sub rep_sql()
        DB_OPEN("nMVAR")

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_T01_REP_MTR_U", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = Edit000.Text
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "T01_REP_MTR_U")
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)

        SqlCmd1 = New SqlClient.SqlCommand("sp_T01_REP_MTR_M", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram2.Value = Edit000.Text
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "T01_REP_MTR_M")
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)

        'å©êœì‡óe
        strSQL = "SELECT T03_REP_CMNT.rcpt_no, T03_REP_CMNT.kbn, T03_REP_CMNT.seq, T03_REP_CMNT.cls_code1"
        strSQL += ", T03_REP_CMNT.cmnt_code1, T03_REP_CMNT.cmnt_code1 + ':' + M10_CMNT.cmnt AS cmnt_name1"
        strSQL += " FROM T03_REP_CMNT LEFT OUTER JOIN"
        strSQL += " M10_CMNT ON T03_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND"
        strSQL += " T03_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
        strSQL += " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
        strSQL += " AND (T03_REP_CMNT.kbn = '2')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T03_REP_CMNT_2")

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** èCóùèÓïÒÇfÇdÇs
    '********************************************************************
    Sub rep_scan()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Edit000.BackColor = System.Drawing.SystemColors.Window
        msg.Text = Nothing

        Edit000.Text = Trim(Edit000.Text)
        rep_sql()   '** èCóùèÓïÒÇfÇdÇs(SQL)

        If DtView1.Count = 0 Then
            Edit000.BackColor = System.Drawing.Color.Red
            msg.Text = "äYìñÇ∑ÇÈéÛïtî‘çÜÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
        Else
            Button0.Enabled = False
            Button2.Enabled = True
            Edit000.ReadOnly = True : Edit000.TabStop = False : Edit000.BackColor = System.Drawing.SystemColors.Control
            Edit005.Text = DtView1(0)("user_name")
            If Not IsDBNull(DtView1(0)("store_code")) Then Edit001.Text = DtView1(0)("store_code") Else Edit001.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_name")) Then Label001.Text = DtView1(0)("store_name") Else Label001.Text = Nothing

            If Not IsDBNull(DtView2(0)("tax_rate")) Then tax_rate.Text = DtView2(0)("tax_rate") Else tax_rate.Text = WK_tax
            If Not IsDBNull(DtView1(0)("calc_cls")) Then calc_cls.Text = DtView1(0)("calc_cls") Else calc_cls.Text = "1"

            'å©êœèÓïÒ **********************************

            If Not IsDBNull(DtView2(0)("etmt_date")) Then
                Date004.Text = DtView2(0)("etmt_date")
                Button5.Enabled = True
            Else
                Button5.Enabled = False
            End If

            If Not IsDBNull(DtView2(0)("etmt_shop_tech_chrg")) Then Number011.Value = DtView2(0)("etmt_shop_tech_chrg") Else Number011.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_apes")) Then Number012.Value = DtView2(0)("etmt_shop_apes") Else Number012.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_part_chrg")) Then Number013.Value = DtView2(0)("etmt_shop_part_chrg") Else Number013.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_fee")) Then Number014.Value = DtView2(0)("etmt_shop_fee") Else Number014.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_pstg")) Then Number015.Value = DtView2(0)("etmt_shop_pstg") Else Number015.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_ttl")) Then
                Number016.Value = DtView2(0)("etmt_shop_ttl")
            Else
                Number016.Value = Number011.Value + Number012.Value + Number013.Value + Number014.Value + Number015.Value
            End If
            Select Case calc_cls.Text
                Case Is = "0"   'éléÃå‹ì¸
                    Number017.Value = Round(Number016.Value * tax_rate.Text / 100, 0)
                Case Is = "1"   'êÿéÃÇƒ
                    Number017.Value = RoundDOWN(Number016.Value * tax_rate.Text / 100, 0)
                Case Is = "2"   'êÿè„Ç∞
                    Number017.Value = RoundUP(Number016.Value * tax_rate.Text / 100, 0)
            End Select
            Number018.Value = Number016.Value + Number017.Value
            If Not IsDBNull(DtView2(0)("etmt_shop_cxl")) Then Number019.Value = DtView2(0)("etmt_shop_cxl") Else Number019.Value = 0

            If Not IsDBNull(DtView2(0)("etmt_eu_tech_chrg")) Then Number021.Value = DtView2(0)("etmt_eu_tech_chrg") Else Number021.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_apes")) Then Number022.Value = DtView2(0)("etmt_eu_apes") Else Number022.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_part_chrg")) Then Number023.Value = DtView2(0)("etmt_eu_part_chrg") Else Number023.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_fee")) Then Number024.Value = DtView2(0)("etmt_eu_fee") Else Number024.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_pstg")) Then Number025.Value = DtView2(0)("etmt_eu_pstg") Else Number025.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_ttl")) Then
                Number026.Value = DtView2(0)("etmt_eu_ttl")
            Else
                Number026.Value = Number021.Value + Number023.Value + Number024.Value + Number025.Value
            End If
            Select Case calc_cls.Text
                Case Is = "0"   'éléÃå‹ì¸
                    Number027.Value = Round(Number026.Value * tax_rate.Text / 100, 0)
                Case Is = "1"   'êÿéÃÇƒ
                    Number027.Value = RoundDOWN(Number026.Value * tax_rate.Text / 100, 0)
                Case Is = "2"   'êÿè„Ç∞
                    Number027.Value = RoundUP(Number026.Value * tax_rate.Text / 100, 0)
            End Select
            Number028.Value = Number026.Value + Number027.Value
            If Not IsDBNull(DtView2(0)("etmt_eu_cxl")) Then Number029.Value = DtView2(0)("etmt_eu_cxl") Else Number029.Value = 0

            If Not IsDBNull(DtView2(0)("etmt_cost_tech_chrg")) Then Number031.Value = DtView2(0)("etmt_cost_tech_chrg") Else Number031.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_apes")) Then Number032.Value = DtView2(0)("etmt_cost_apes") Else Number032.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_part_chrg")) Then Number033.Value = DtView2(0)("etmt_cost_part_chrg") Else Number033.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_fee")) Then Number034.Value = DtView2(0)("etmt_cost_fee") Else Number034.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_pstg")) Then Number035.Value = DtView2(0)("etmt_cost_pstg") Else Number035.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_ttl")) Then
                Number036.Value = DtView2(0)("etmt_cost_ttl")
            Else
                Number036.Value = Number031.Value + Number032.Value + Number033.Value + Number034.Value + Number035.Value
            End If
            Select Case calc_cls.Text
                Case Is = "0"   'éléÃå‹ì¸
                    Number037.Value = Round(Number036.Value * tax_rate.Text / 100, 0)
                Case Is = "1"   'êÿéÃÇƒ
                    Number037.Value = RoundDOWN(Number036.Value * tax_rate.Text / 100, 0)
                Case Is = "2"   'êÿè„Ç∞
                    Number037.Value = RoundUP(Number036.Value * tax_rate.Text / 100, 0)
            End Select
            Number038.Value = Number036.Value + Number037.Value

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ÉNÉäÉA
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Inz_Dsp()   '**  èâä˙âÊñ ÉZÉbÉg
    End Sub

    '********************************************************************
    '**  Ç®å©êœèëàÛç¸
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        P_PRAM1 = Edit000.Text  'éÛïtî‘çÜ
        P_PRAM2 = Edit001.Text  'îÃé–
        Dim F00_Form12 As New F00_Form12
        F00_Form12.ShowDialog()

        If P_RTN = "1" Then
            msg.Text = "Ç®å©êœèëÇàÛç¸ÇµÇ‹ÇµÇΩÅB"
        End If
    End Sub


    '********************************************************************
    '**  ñﬂÇÈ
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        Close()
    End Sub
End Class