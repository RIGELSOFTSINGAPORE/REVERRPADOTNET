Public Class Form2
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DtView1, DtView2 As DataView

    Dim strSQL, Err_F As String


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
    Friend WithEvents MSG As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit7 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Edit8 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit6 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Number2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.MSG = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button98 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Date1 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Edit3 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit4 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit5 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit8 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit7 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit6 = New GrapeCity.Win.Input.Interop.Edit()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Mask1 = New GrapeCity.Win.Input.Interop.Mask()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Number2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MSG
        '
        Me.MSG.ForeColor = System.Drawing.Color.Red
        Me.MSG.Location = New System.Drawing.Point(8, 448)
        Me.MSG.Name = "MSG"
        Me.MSG.Size = New System.Drawing.Size(664, 24)
        Me.MSG.TabIndex = 981
        Me.MSG.Text = "MSG"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 472)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 982
        Me.Button1.Text = "çXêV"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(576, 472)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(104, 32)
        Me.Button98.TabIndex = 983
        Me.Button98.Text = "ñﬂÇÈ"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 984
        Me.Label2.Text = "ìXï‹ÉRÅ[Éh"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit1.Format = "9#"
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit1.Location = New System.Drawing.Point(144, 48)
        Me.Edit1.MaxLength = 4
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Size = New System.Drawing.Size(48, 25)
        Me.Edit1.TabIndex = 10
        Me.Edit1.Text = "9999"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(16, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 24)
        Me.Label1.TabIndex = 985
        Me.Label1.Text = "ìXï‹ñºÅi∂≈Åj"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label3.Location = New System.Drawing.Point(16, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 24)
        Me.Label3.TabIndex = 986
        Me.Label3.Text = "ìXï‹ñºÅiäøéöÅj"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label4.Location = New System.Drawing.Point(16, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 24)
        Me.Label4.TabIndex = 987
        Me.Label4.Text = "ï™óﬁ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label5.Location = New System.Drawing.Point(16, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 24)
        Me.Label5.TabIndex = 988
        Me.Label5.Text = "âÔé–ÉOÉãÅ[Év"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkBlue
        Me.Label6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label6.Location = New System.Drawing.Point(16, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 24)
        Me.Label6.TabIndex = 989
        Me.Label6.Text = "èZèäCD"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkBlue
        Me.Label7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label7.Location = New System.Drawing.Point(272, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 24)
        Me.Label7.TabIndex = 990
        Me.Label7.Text = "óXï÷î‘çÜ"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkBlue
        Me.Label8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label8.Location = New System.Drawing.Point(16, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 24)
        Me.Label8.TabIndex = 991
        Me.Label8.Text = "ìsìπï{åßñº"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkBlue
        Me.Label9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label9.Location = New System.Drawing.Point(16, 280)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 24)
        Me.Label9.TabIndex = 992
        Me.Label9.Text = "ésãÊí¨ë∫ñº"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkBlue
        Me.Label10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label10.Location = New System.Drawing.Point(16, 312)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 24)
        Me.Label10.TabIndex = 993
        Me.Label10.Text = "èZèäÇP"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkBlue
        Me.Label11.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label11.Location = New System.Drawing.Point(16, 344)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 24)
        Me.Label11.TabIndex = 994
        Me.Label11.Text = "èZèäÇQ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DarkBlue
        Me.Label12.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label12.Location = New System.Drawing.Point(16, 376)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 24)
        Me.Label12.TabIndex = 995
        Me.Label12.Text = "ÇsÇdÇk"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label13.Location = New System.Drawing.Point(320, 376)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 24)
        Me.Label13.TabIndex = 996
        Me.Label13.Text = "ÇeÇ`Çw"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label14.Location = New System.Drawing.Point(16, 408)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 24)
        Me.Label14.TabIndex = 997
        Me.Label14.Text = "ï¬çΩì˙"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.TextBox1.Location = New System.Drawing.Point(144, 88)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(352, 23)
        Me.TextBox1.TabIndex = 20
        Me.TextBox1.Text = "TextBox1"
        '
        'TextBox2
        '
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox2.Location = New System.Drawing.Point(144, 120)
        Me.TextBox2.MaxLength = 30
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(352, 23)
        Me.TextBox2.TabIndex = 30
        Me.TextBox2.Text = "TextBox2"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(144, 152)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 24)
        Me.ComboBox1.TabIndex = 40
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Number1
        '
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####0", "", "", "-", "", "", "0")
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number1.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####0", "", "", "-", "", "", "")
        Me.Number1.HighlightText = True
        Me.Number1.Location = New System.Drawing.Point(144, 184)
        Me.Number1.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Name = "Number1"
        Me.Number1.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Size = New System.Drawing.Size(88, 24)
        Me.Number1.TabIndex = 50
        Me.Number1.Value = Nothing
        '
        'TextBox4
        '
        Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox4.Location = New System.Drawing.Point(144, 248)
        Me.TextBox4.MaxLength = 10
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(112, 23)
        Me.TextBox4.TabIndex = 80
        Me.TextBox4.Text = "TextBox4"
        '
        'TextBox5
        '
        Me.TextBox5.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox5.Location = New System.Drawing.Point(144, 280)
        Me.TextBox5.MaxLength = 10
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(352, 23)
        Me.TextBox5.TabIndex = 90
        Me.TextBox5.Text = "TextBox5"
        '
        'TextBox6
        '
        Me.TextBox6.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox6.Location = New System.Drawing.Point(144, 312)
        Me.TextBox6.MaxLength = 10
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(352, 23)
        Me.TextBox6.TabIndex = 100
        Me.TextBox6.Text = "TextBox6"
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date1.Format = Nothing
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(144, 408)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(96, 24)
        Me.Date1.TabIndex = 180
        Me.Date1.Text = ""
        Me.Date1.Value = Nothing
        '
        'Edit3
        '
        Me.Edit3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit3.Format = "9#"
        Me.Edit3.HighlightText = True
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit3.Location = New System.Drawing.Point(144, 376)
        Me.Edit3.MaxLength = 5
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Size = New System.Drawing.Size(48, 25)
        Me.Edit3.TabIndex = 120
        Me.Edit3.Text = "99999"
        '
        'Edit4
        '
        Me.Edit4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit4.Format = "9#"
        Me.Edit4.HighlightText = True
        Me.Edit4.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit4.Location = New System.Drawing.Point(200, 376)
        Me.Edit4.MaxLength = 4
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Size = New System.Drawing.Size(48, 25)
        Me.Edit4.TabIndex = 130
        Me.Edit4.Text = "9999"
        '
        'Edit5
        '
        Me.Edit5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit5.Format = "9#"
        Me.Edit5.HighlightText = True
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit5.Location = New System.Drawing.Point(256, 376)
        Me.Edit5.MaxLength = 4
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Size = New System.Drawing.Size(48, 25)
        Me.Edit5.TabIndex = 140
        Me.Edit5.Text = "9999"
        '
        'Edit8
        '
        Me.Edit8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit8.Format = "9#"
        Me.Edit8.HighlightText = True
        Me.Edit8.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit8.Location = New System.Drawing.Point(560, 376)
        Me.Edit8.MaxLength = 4
        Me.Edit8.Name = "Edit8"
        Me.Edit8.Size = New System.Drawing.Size(48, 25)
        Me.Edit8.TabIndex = 170
        Me.Edit8.Text = "9999"
        '
        'Edit7
        '
        Me.Edit7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit7.Format = "9#"
        Me.Edit7.HighlightText = True
        Me.Edit7.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit7.Location = New System.Drawing.Point(504, 376)
        Me.Edit7.MaxLength = 4
        Me.Edit7.Name = "Edit7"
        Me.Edit7.Size = New System.Drawing.Size(48, 25)
        Me.Edit7.TabIndex = 160
        Me.Edit7.Text = "9999"
        '
        'Edit6
        '
        Me.Edit6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit6.Format = "9#"
        Me.Edit6.HighlightText = True
        Me.Edit6.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit6.Location = New System.Drawing.Point(448, 376)
        Me.Edit6.MaxLength = 5
        Me.Edit6.Name = "Edit6"
        Me.Edit6.Size = New System.Drawing.Size(48, 25)
        Me.Edit6.TabIndex = 150
        Me.Edit6.Text = "99999"
        '
        'TextBox7
        '
        Me.TextBox7.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox7.Location = New System.Drawing.Point(144, 344)
        Me.TextBox7.MaxLength = 10
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(352, 23)
        Me.TextBox7.TabIndex = 110
        Me.TextBox7.Text = "TextBox7"
        '
        'Mask1
        '
        Me.Mask1.Format = New GrapeCity.Win.Input.Interop.MaskFormat("\D{3}-\D{4}", "", "")
        Me.Mask1.Location = New System.Drawing.Point(400, 216)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.Size = New System.Drawing.Size(96, 24)
        Me.Mask1.TabIndex = 70
        Me.Mask1.Value = ""
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(288, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 24)
        Me.Label17.TabIndex = 1001
        Me.Label17.Text = "Label17"
        Me.Label17.Visible = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(248, 408)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 24)
        Me.Label15.TabIndex = 1002
        Me.Label15.Text = "Label15"
        Me.Label15.Visible = False
        '
        'Number2
        '
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##########0", "", "", "-", "", "", "0")
        Me.Number2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number2.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##########0", "", "", "-", "", "", "")
        Me.Number2.HighlightText = True
        Me.Number2.Location = New System.Drawing.Point(144, 216)
        Me.Number2.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Name = "Number2"
        Me.Number2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Size = New System.Drawing.Size(112, 24)
        Me.Number2.TabIndex = 60
        Me.Number2.Value = Nothing
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(144, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 24)
        Me.Label16.TabIndex = 1004
        Me.Label16.Text = "Label16"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(16, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 24)
        Me.Label18.TabIndex = 1003
        Me.Label18.Text = "ÉVÉXÉeÉÄãÊï™"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(272, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 24)
        Me.Label19.TabIndex = 1005
        Me.Label19.Text = "Label19"
        Me.Label19.Visible = False
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(690, 511)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Mask1)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Edit8)
        Me.Controls.Add(Me.Edit7)
        Me.Controls.Add(Me.Edit6)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.Edit4)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
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
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MSG)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ìXï‹œΩ¿“›√≈›Ω"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MSG.Text = Nothing
        Edit1.Text = P_shop_code
        Label19.Text = P_BY_cls
        If P_BY_cls = "B" Then Label16.Text = "ÉxÉXÉg" Else Label16.Text = "ÉÑÉ}É_"
        Call CmbSet()
        Call DspSet()
    End Sub

    Sub CmbSet()
        P_DsCMB.Clear()
        'ï™óﬁ
        strSQL = "SELECT CLS_CODE, CLS_CODE_NAME, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME2"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '010')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(P_DsCMB, "CLS_CODE_010")
        DB_CLOSE()

        ComboBox1.DataSource = P_DsCMB.Tables("CLS_CODE_010")
        ComboBox1.DisplayMember = "CLS_CODE_NAME2"
        ComboBox1.ValueMember = "CLS_CODE"
    End Sub

    Sub DspSet()
        If P_shop_code = Nothing Then   'ìoò^
            Button1.Text = "ìoò^"
            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            Number1.Value = 0
            Number2.Text = 0
            Mask1.Text = Nothing
            TextBox4.Text = Nothing
            TextBox5.Text = Nothing
            TextBox6.Text = Nothing
            TextBox7.Text = Nothing
            Edit3.Text = Nothing
            Edit4.Text = Nothing
            Edit5.Text = Nothing
            Edit6.Text = Nothing
            Edit7.Text = Nothing
            Edit8.Text = Nothing
            Date1.Text = Nothing
            Label15.Text = "2090/12/31"
        Else                            'èCê≥
            Edit1.Enabled = False
            DtView1 = New DataView(P_DsList1.Tables("Shop_mtr"), "shop_code='" & Edit1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                If Not IsDBNull(Trim(DtView1(0)("ìXï‹ñº(∂≈)"))) Then TextBox1.Text = Trim(DtView1(0)("ìXï‹ñº(∂≈)")) Else TextBox1.Text = Nothing
                If Not IsDBNull(Trim(DtView1(0)("ìXï‹ñº(äøéö)"))) Then TextBox2.Text = Trim(DtView1(0)("ìXï‹ñº(äøéö)")) Else TextBox2.Text = Nothing
                ComboBox1.SelectedValue = DtView1(0)("ï™óﬁCD")
                DtView2 = New DataView(P_DsCMB.Tables("CLS_CODE_010"), "CLS_CODE_NAME2='" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView2.Count <> 0 Then
                    Label17.Text = DtView2(0)("CLS_CODE_NAME")
                Else
                    Label17.Text = Nothing
                End If
                If Not IsDBNull(DtView1(0)("âÔé–GRP")) Then Number1.Value = DtView1(0)("âÔé–GRP") Else Number1.Value = 0
                If Not IsDBNull(DtView1(0)("èZèäCD")) Then Number2.Value = DtView1(0)("èZèäCD") Else Number2.Value = 0
                If Not IsDBNull(DtView1(0)("óXï÷î‘çÜ")) Then Mask1.Value = DtView1(0)("óXï÷î‘çÜ") Else Mask1.Value = Nothing
                If Not IsDBNull(DtView1(0)("ìsìπï{åßñº")) Then TextBox4.Text = Trim(DtView1(0)("ìsìπï{åßñº")) Else TextBox4.Text = Nothing
                If Not IsDBNull(DtView1(0)("ésãÊí¨ë∫ñº")) Then TextBox5.Text = Trim(DtView1(0)("ésãÊí¨ë∫ñº")) Else TextBox5.Text = Nothing
                If Not IsDBNull(DtView1(0)("èZèäÇP")) Then TextBox6.Text = Trim(DtView1(0)("èZèäÇP")) Else TextBox6.Text = Nothing
                If Not IsDBNull(DtView1(0)("èZèäÇQ")) Then TextBox7.Text = Trim(DtView1(0)("èZèäÇQ")) Else TextBox7.Text = Nothing
                If Not IsDBNull(DtView1(0)("TEL(ésäO)")) Then Edit3.Text = DtView1(0)("TEL(ésäO)") Else Edit3.Text = Nothing
                If Not IsDBNull(DtView1(0)("TEL(ésì‡)")) Then Edit4.Text = DtView1(0)("TEL(ésì‡)") Else Edit4.Text = Nothing
                If Not IsDBNull(DtView1(0)("TEL(î‘çÜ)")) Then Edit5.Text = DtView1(0)("TEL(î‘çÜ)") Else Edit5.Text = Nothing
                If Not IsDBNull(DtView1(0)("FAX(ésäO)")) Then Edit6.Text = DtView1(0)("FAX(ésäO)") Else Edit6.Text = Nothing
                If Not IsDBNull(DtView1(0)("FAX(ésì‡)")) Then Edit7.Text = DtView1(0)("FAX(ésì‡)") Else Edit7.Text = Nothing
                If Not IsDBNull(DtView1(0)("FAX(î‘çÜ)")) Then Edit8.Text = DtView1(0)("FAX(î‘çÜ)") Else Edit8.Text = Nothing
                If Not IsDBNull(Trim(DtView1(0)("close_date"))) Then Date1.Text = DtView1(0)("close_date") Else Date1.Text = Nothing
                Label15.Text = Date1.Text
            End If
        End If
    End Sub

    'ì¸óÕå„
    Private Sub Edit1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.Leave
        MSG.Text = Nothing
        Call Edit1_chk()
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        MSG.Text = Nothing
        Call TextBox1_chk()
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        MSG.Text = Nothing
        Call TextBox2_chk()
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        MSG.Text = Nothing
        Call ComboBox1_chk()
    End Sub

    Private Sub Number1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Number2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number2.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Mask1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub TextBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub TextBox6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Edit3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit3.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Edit4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit4.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Edit5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit5.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Edit6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit6.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Edit7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit7.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Edit8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit8.Leave
        MSG.Text = Nothing
    End Sub

    Private Sub Date1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.Leave
        MSG.Text = Nothing
        Call Date1_chk()
    End Sub

    Sub Edit1_chk()
        If Trim(Edit1.Text) = Nothing Then
            MSG.Text = "ìXï‹ÉRÅ[ÉhÇÕì¸óÕïKê{Ç≈Ç∑ÅB"
            Err_F = "1"
        Else
            DtView1 = New DataView(P_DsList1.Tables("Shop_mtr"), "BY_cls ='" & Label19.Text & "' AND shop_code='" & Edit1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                MSG.Text = "ìXï‹ÉRÅ[ÉhÇÕä˘Ç…ìoò^Ç≥ÇÍÇƒÇ¢Ç‹Ç∑ÅB"
                Err_F = "1"
            End If
        End If
    End Sub

    Sub TextBox1_chk()
        If Trim(TextBox1.Text) = Nothing Then
            MSG.Text = "ìXï‹ñºÅi∂≈ÅjÇÕì¸óÕïKê{Ç≈Ç∑ÅB"
            Err_F = "1"
        End If
    End Sub

    Sub TextBox2_chk()
        If Trim(TextBox2.Text) = Nothing Then
            MSG.Text = "ìXï‹ñºÅiäøéöÅjÇÕì¸óÕïKê{Ç≈Ç∑ÅB"
            Err_F = "1"
        End If
    End Sub

    Sub ComboBox1_chk()
        If Trim(ComboBox1.Text) = Nothing Then
            MSG.Text = "ï™óﬁÇÕì¸óÕïKê{Ç≈Ç∑ÅB"
            Err_F = "1"
        Else
            DtView1 = New DataView(P_DsCMB.Tables("CLS_CODE_010"), "CLS_CODE_NAME2='" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MSG.Text = "ï™óﬁÇÃì¸óÕÇ…åÎÇËÇ™Ç†ÇËÇ‹Ç∑ÅB"
                Err_F = "1"
            Else
                ComboBox1.SelectedValue = DtView1(0)("CLS_CODE")
                Label17.Text = DtView1(0)("CLS_CODE_NAME")
            End If
        End If
    End Sub

    Sub Date1_chk()
        If Date1.Number = 0 Then
            Label15.Text = "2090/12/31"
        Else
            Label15.Text = Date1.Text
        End If
    End Sub

    Sub F_Check()
        Err_F = "0"
        If P_shop_code = Nothing Then   'ìoò^
            Call Edit1_chk()
            If Err_F = "1" Then Edit1.Focus() : Exit Sub
        End If
        Call TextBox1_chk()
        If Err_F = "1" Then TextBox1.Focus() : Exit Sub
        Call TextBox2_chk()
        If Err_F = "1" Then TextBox2.Focus() : Exit Sub
        Call ComboBox1_chk()
        If Err_F = "1" Then ComboBox1.Focus() : Exit Sub
    End Sub

    Private Sub Date1_ValueChanged(sender As Object, e As EventArgs) Handles Date1.ValueChanged

    End Sub

    'çXêVÉ{É^Éì
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_Check()
        If Err_F = "1" Then
            Beep()
        Else
            If P_shop_code = Nothing Then   'ìoò^
                strSQL = "INSERT INTO Shop_mtr"
                strSQL = strSQL & " (BY_cls, shop_code, [ìXï‹ñº(∂≈)], [ìXï‹ñº(äøéö)], ï™óﬁCD, ï™óﬁñº, âÔé–GRP, èZèäCD"
                strSQL = strSQL & ", óXï÷î‘çÜ, ìsìπï{åßñº, ésãÊí¨ë∫ñº, èZèäÇP, èZèäÇQ, [TEL(ésäO)], [TEL(ésì‡)]"
                strSQL = strSQL & ", [TEL(î‘çÜ)], [FAX(ésäO)], [FAX(ésì‡)], [FAX(î‘çÜ)], close_date)"
                strSQL = strSQL & " VALUES ('" & Label19.Text & "'"
                strSQL = strSQL & ", N'" & Edit1.Text & "'"
                strSQL = strSQL & ", N'" & TextBox1.Text & "'"
                strSQL = strSQL & ", N'" & TextBox2.Text & "'"
                strSQL = strSQL & ", N'" & ComboBox1.SelectedValue & "'"
                strSQL = strSQL & ", N'" & Label17.Text & "'"
                strSQL = strSQL & ", " & Number1.Value & ""
                strSQL = strSQL & ", " & Number2.Text & ""
                strSQL = strSQL & ", N'" & Mask1.Value & "'"
                strSQL = strSQL & ", N'" & TextBox4.Text & "'"
                strSQL = strSQL & ", N'" & TextBox5.Text & "'"
                strSQL = strSQL & ", N'" & TextBox6.Text & "'"
                strSQL = strSQL & ", N'" & TextBox7.Text & "'"
                strSQL = strSQL & ", N'" & Edit3.Text & "'"
                strSQL = strSQL & ", N'" & Edit4.Text & "'"
                strSQL = strSQL & ", N'" & Edit5.Text & "'"
                strSQL = strSQL & ", N'" & Edit6.Text & "'"
                strSQL = strSQL & ", N'" & Edit7.Text & "'"
                strSQL = strSQL & ", N'" & Edit8.Text & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Label15.Text & "', 102))"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                MsgBox("ìoò^ÇµÇ‹ÇµÇΩ", , "")
            Else                            'èCê≥
                strSQL = "UPDATE Shop_mtr"
                strSQL = strSQL & " SET [ìXï‹ñº(∂≈)] = N'" & TextBox1.Text & "'"
                strSQL = strSQL & ", [ìXï‹ñº(äøéö)] = N'" & TextBox2.Text & "'"
                strSQL = strSQL & ", ï™óﬁCD = N'" & ComboBox1.SelectedValue & "'"
                strSQL = strSQL & ", ï™óﬁñº = N'" & Label17.Text & "'"
                strSQL = strSQL & ", âÔé–GRP = " & Number1.Value & ""
                strSQL = strSQL & ", èZèäCD = " & Number2.Text & ""
                strSQL = strSQL & ", óXï÷î‘çÜ = N'" & Mask1.Value & "'"
                strSQL = strSQL & ", ìsìπï{åßñº = N'" & TextBox4.Text & "'"
                strSQL = strSQL & ", ésãÊí¨ë∫ñº = N'" & TextBox5.Text & "'"
                strSQL = strSQL & ", èZèäÇP = N'" & TextBox6.Text & "'"
                strSQL = strSQL & ", èZèäÇQ = N'" & TextBox7.Text & "'"
                strSQL = strSQL & ", [TEL(ésäO)] = N'" & Edit3.Text & "'"
                strSQL = strSQL & ", [TEL(ésì‡)] = N'" & Edit4.Text & "'"
                strSQL = strSQL & ", [TEL(î‘çÜ)] = N'" & Edit5.Text & "'"
                strSQL = strSQL & ", [FAX(ésäO)] = N'" & Edit6.Text & "'"
                strSQL = strSQL & ", [FAX(ésì‡)] = N'" & Edit7.Text & "'"
                strSQL = strSQL & ", [FAX(î‘çÜ)] = N'" & Edit8.Text & "'"
                strSQL = strSQL & ", close_date = CONVERT(DATETIME, '" & Label15.Text & "', 102)"
                strSQL = strSQL & " WHERE (BY_cls = '" & Label19.Text & "')"
                strSQL = strSQL & " AND (shop_code = N'" & Edit1.Text & "')"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                MsgBox("èCê≥ÇµÇ‹ÇµÇΩ", , "")
            End If
            P_Rtn = "1"
            Me.Close()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'ñﬂÇÈÉ{É^Éì
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_Rtn = "0"
        Me.Close()
    End Sub
End Class
