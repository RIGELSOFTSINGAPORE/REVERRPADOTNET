Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Private objMutex As System.Threading.Mutex

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsSearch2 As New DataSet
    Dim DsCMB, DsCMB6, DsCMB7, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, DtView3 As DataView

    Dim strSQL, Err_F, str_ANS, inz_F As String
    'Dim i, en As Integer
    Dim Data_F05 As String
    Dim NO_MNT_F As String
    Dim WK_nen As Integer

    Dim BR_date2 As Date

    Dim namedif_f As Boolean    '顧客名チェックフラグ：登録名と請求情報の相違有の場合、true

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
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Date4 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Number3 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox11 As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Number8 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Date5 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Number10 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number9 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number7 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number6 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Date3 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents ComboBox12 As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Date6 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Number5 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents TextBox4 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents TextBox5 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Date7 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Edit4 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit3 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.TextBox4 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Date6 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Date4 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Date1 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Number3 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ComboBox11 = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Number8 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Date5 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Number10 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number9 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number7 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number6 = New GrapeCity.Win.Input.Interop.Number()
        Me.Date3 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Date2 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.ComboBox12 = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Number5 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button98 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Edit5 = New GrapeCity.Win.Input.Interop.Edit()
        Me.TextBox5 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Date7 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Date7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(256, 568)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 32)
        Me.Button3.TabIndex = 996
        Me.Button3.Text = "クリア"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.ForeColor = System.Drawing.Color.Yellow
        Me.Button4.Location = New System.Drawing.Point(376, 568)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 32)
        Me.Button4.TabIndex = 997
        Me.Button4.Text = "削除"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label82.Location = New System.Drawing.Point(824, 8)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(64, 24)
        Me.Label82.TabIndex = 1099
        Me.Label82.Text = "Label82"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label82.Visible = False
        '
        'Label81
        '
        Me.Label81.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label81.Location = New System.Drawing.Point(784, 88)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(88, 24)
        Me.Label81.TabIndex = 1098
        Me.Label81.Text = "Label81"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label81.Visible = False
        '
        'Edit4
        '
        Me.Edit4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit4.DisabledBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit4.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit4.HighlightText = True
        Me.Edit4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit4.LengthAsByte = True
        Me.Edit4.Location = New System.Drawing.Point(128, 80)
        Me.Edit4.MaxLength = 20
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Size = New System.Drawing.Size(312, 24)
        Me.Edit4.TabIndex = 30
        Me.Edit4.Text = "EDIT4"
        '
        'Edit3
        '
        Me.Edit3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit3.DisabledBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit3.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit3.HighlightText = True
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit3.LengthAsByte = True
        Me.Edit3.Location = New System.Drawing.Point(128, 48)
        Me.Edit3.MaxLength = 20
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Size = New System.Drawing.Size(208, 24)
        Me.Edit3.TabIndex = 20
        Me.Edit3.Text = "EDIT3"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(864, 344)
        Me.Label12.TabIndex = 1076
        '
        'Label80
        '
        Me.Label80.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label80.Location = New System.Drawing.Point(480, 8)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(48, 24)
        Me.Label80.TabIndex = 1097
        Me.Label80.Text = "Label80"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label80.Visible = False
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label79.Location = New System.Drawing.Point(416, 8)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(48, 24)
        Me.Label79.TabIndex = 1096
        Me.Label79.Text = "Label79"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label79.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox4.LengthAsByte = True
        Me.TextBox4.Location = New System.Drawing.Point(152, 312)
        Me.TextBox4.MaxLength = 30
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(232, 24)
        Me.TextBox4.TabIndex = 85
        Me.TextBox4.Text = "TextBox4"
        '
        'Label78
        '
        Me.Label78.Location = New System.Drawing.Point(136, 144)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(96, 24)
        Me.Label78.TabIndex = 1095
        Me.Label78.Text = "Label78"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label77
        '
        Me.Label77.BackColor = System.Drawing.Color.DarkBlue
        Me.Label77.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label77.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label77.Location = New System.Drawing.Point(24, 144)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(104, 24)
        Me.Label77.TabIndex = 1094
        Me.Label77.Text = "期間区分"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label76
        '
        Me.Label76.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label76.Location = New System.Drawing.Point(336, 56)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(120, 24)
        Me.Label76.TabIndex = 1092
        Me.Label76.Text = "Label76"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label76.Visible = False
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label75.Location = New System.Drawing.Point(336, 32)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(120, 24)
        Me.Label75.TabIndex = 1091
        Me.Label75.Text = "Label75"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label75.Visible = False
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label74.Location = New System.Drawing.Point(440, 72)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(104, 24)
        Me.Label74.TabIndex = 1090
        Me.Label74.Text = "Label74"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label74.Visible = False
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label73.Location = New System.Drawing.Point(440, 48)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(104, 24)
        Me.Label73.TabIndex = 1089
        Me.Label73.Text = "Label73"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label73.Visible = False
        '
        'Label65
        '
        Me.Label65.Font = New System.Drawing.Font("MS PGothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.Red
        Me.Label65.Location = New System.Drawing.Point(552, 72)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(312, 16)
        Me.Label65.TabIndex = 1088
        Me.Label65.Text = "Label65"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label64
        '
        Me.Label64.Font = New System.Drawing.Font("MS PGothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.Red
        Me.Label64.Location = New System.Drawing.Point(552, 56)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(312, 16)
        Me.Label64.TabIndex = 1087
        Me.Label64.Text = "Label64"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date6
        '
        Me.Date6.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Date6.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date6.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy.MM", "", "")
        Me.Date6.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date6.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date6.DropDownCalendar.Size = New System.Drawing.Size(340, 237)
        Me.Date6.Font = New System.Drawing.Font("MS PGothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date6.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy.MM", "", "")
        Me.Date6.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date6.Location = New System.Drawing.Point(552, 32)
        Me.Date6.Name = "Date6"
        Me.Date6.Size = New System.Drawing.Size(96, 24)
        Me.Date6.TabIndex = 1084
        Me.Date6.TabStop = False
        Me.Date6.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date6.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date6.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 24, 11, 17, 5, 0))
        '
        'Label71
        '
        Me.Label71.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label71.Location = New System.Drawing.Point(704, 32)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(104, 23)
        Me.Label71.TabIndex = 1086
        Me.Label71.Text = "Label71"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label71.Visible = False
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("MS PGothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label72.Location = New System.Drawing.Point(648, 32)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(56, 24)
        Me.Label72.TabIndex = 1085
        Me.Label72.Text = "月度"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit1
        '
        Me.Edit1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit1.DisabledBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit1.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit1.Format = "9A"
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(128, 16)
        Me.Edit1.MaxLength = 14
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Size = New System.Drawing.Size(128, 24)
        Me.Edit1.TabIndex = 10
        Me.Edit1.Text = "EDIT1"
        '
        'Label70
        '
        Me.Label70.ForeColor = System.Drawing.Color.Red
        Me.Label70.Location = New System.Drawing.Point(176, 120)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(72, 24)
        Me.Label70.TabIndex = 1083
        Me.Label70.Text = "Label70"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Date4.Location = New System.Drawing.Point(736, 312)
        Me.Date4.Name = "Date4"
        Me.Date4.Size = New System.Drawing.Size(112, 24)
        Me.Date4.TabIndex = 310
        Me.Date4.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.DarkBlue
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label35.Location = New System.Drawing.Point(640, 312)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 24)
        Me.Label35.TabIndex = 1081
        Me.Label35.Text = "処理日"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(608, 448)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 24)
        Me.Label13.TabIndex = 1077
        Me.Label13.Text = "Label13"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label13.Visible = False
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(832, 144)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(64, 24)
        Me.Label61.TabIndex = 1071
        Me.Label61.Text = "Label61"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label61.Visible = False
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label62.Location = New System.Drawing.Point(832, 168)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(64, 24)
        Me.Label62.TabIndex = 1070
        Me.Label62.Text = "Label62"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label62.Visible = False
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label60.Location = New System.Drawing.Point(832, 120)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(64, 24)
        Me.Label60.TabIndex = 1067
        Me.Label60.Text = "Label60"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label60.Visible = False
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(592, 168)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(304, 24)
        Me.Label59.TabIndex = 1066
        Me.Label59.Text = "Label59"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(592, 144)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(304, 24)
        Me.Label58.TabIndex = 1065
        Me.Label58.Text = "Label58"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(592, 120)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(304, 24)
        Me.Label57.TabIndex = 1064
        Me.Label57.Text = "Label57"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.DarkBlue
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label47.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label47.Location = New System.Drawing.Point(472, 168)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(112, 24)
        Me.Label47.TabIndex = 1045
        Me.Label47.Text = "品種"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.DarkBlue
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label48.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label48.Location = New System.Drawing.Point(472, 144)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(112, 24)
        Me.Label48.TabIndex = 1044
        Me.Label48.Text = "ﾒｰｶｰ名"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.DarkBlue
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label26.Location = New System.Drawing.Point(472, 120)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 24)
        Me.Label26.TabIndex = 1024
        Me.Label26.Text = "修理品購入店"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(8, 200)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(856, 2)
        Me.PictureBox2.TabIndex = 1015
        Me.PictureBox2.TabStop = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(336, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 24)
        Me.Label17.TabIndex = 1014
        Me.Label17.Text = "Label17"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label17.Visible = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DarkBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label16.Location = New System.Drawing.Point(24, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 24)
        Me.Label16.TabIndex = 1013
        Me.Label16.Text = "契約状況"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(264, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 24)
        Me.Label15.TabIndex = 1012
        Me.Label15.Text = "Label15"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Visible = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(128, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 24)
        Me.Label10.TabIndex = 1008
        Me.Label10.Text = "Label10"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(352, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 24)
        Me.Label9.TabIndex = 1007
        Me.Label9.Text = "Label9"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(352, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 24)
        Me.Label8.TabIndex = 1006
        Me.Label8.Text = "Label8"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(352, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 24)
        Me.Label7.TabIndex = 1005
        Me.Label7.Text = "Label7"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(128, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 24)
        Me.Label6.TabIndex = 1004
        Me.Label6.Text = "Label6"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label5.Location = New System.Drawing.Point(248, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 24)
        Me.Label5.TabIndex = 1003
        Me.Label5.Text = "保証限度額"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label4.Location = New System.Drawing.Point(248, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 24)
        Me.Label4.TabIndex = 1002
        Me.Label4.Text = "購入価格"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label3.Location = New System.Drawing.Point(248, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 1001
        Me.Label3.Text = "購入日"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(24, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 1000
        Me.Label1.Text = "Bﾃﾞｰﾀ処理日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label2.Location = New System.Drawing.Point(24, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 992
        Me.Label2.Text = "保証番号"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label14.Location = New System.Drawing.Point(24, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 24)
        Me.Label14.TabIndex = 993
        Me.Label14.Text = "顧客名称"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label18.Location = New System.Drawing.Point(24, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 24)
        Me.Label18.TabIndex = 994
        Me.Label18.Text = "型式"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(8, 112)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(856, 2)
        Me.PictureBox1.TabIndex = 999
        Me.PictureBox1.TabStop = False
        '
        'ComboBox7
        '
        Me.ComboBox7.Location = New System.Drawing.Point(152, 528)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox7.TabIndex = 160
        Me.ComboBox7.Text = "ComboBox7"
        '
        'ComboBox6
        '
        Me.ComboBox6.Location = New System.Drawing.Point(152, 480)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox6.TabIndex = 150
        Me.ComboBox6.Text = "ComboBox6"
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(152, 384)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox4.TabIndex = 110
        Me.ComboBox4.Text = "ComboBox4"
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.DarkBlue
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label63.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label63.Location = New System.Drawing.Point(24, 312)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(128, 24)
        Me.Label63.TabIndex = 1073
        Me.Label63.Text = "顧客名称"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(152, 264)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox2.TabIndex = 70
        Me.ComboBox2.Text = "ComboBox2"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(152, 360)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox1.TabIndex = 100
        Me.ComboBox1.Text = "ComboBox1"
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
        Me.Date1.Location = New System.Drawing.Point(152, 336)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(88, 24)
        Me.Date1.TabIndex = 90
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'Number3
        '
        Me.Number3.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number3.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0000", "", "", "-", "", "", "")
        Me.Number3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number3.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number3.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number3.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0000", "", "", "-", "", "", "")
        Me.Number3.HighlightText = True
        Me.Number3.Location = New System.Drawing.Point(152, 408)
        Me.Number3.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number3.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number3.Name = "Number3"
        Me.Number3.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number3.Size = New System.Drawing.Size(48, 24)
        Me.Number3.TabIndex = 120
        Me.Number3.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Number3.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number3.Value = Nothing
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.DarkBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label24.Location = New System.Drawing.Point(24, 504)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(128, 48)
        Me.Label24.TabIndex = 1026
        Me.Label24.Text = "修理完了店"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkBlue
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label25.Location = New System.Drawing.Point(24, 456)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 48)
        Me.Label25.TabIndex = 1025
        Me.Label25.Text = "修理受付店"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.DarkBlue
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label27.Location = New System.Drawing.Point(24, 384)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(128, 24)
        Me.Label27.TabIndex = 1023
        Me.Label27.Text = "全損ﾌﾗｸﾞ"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.DarkBlue
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label28.Location = New System.Drawing.Point(24, 432)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(128, 24)
        Me.Label28.TabIndex = 1022
        Me.Label28.Text = "項目有無ﾌﾗｸﾞ"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.DarkBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label29.Location = New System.Drawing.Point(24, 264)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(128, 24)
        Me.Label29.TabIndex = 1021
        Me.Label29.Text = "事故状況ﾌﾗｸﾞ"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(152, 432)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox3.TabIndex = 130
        Me.ComboBox3.Text = "ComboBox3"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.DarkBlue
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label31.Location = New System.Drawing.Point(24, 336)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(128, 24)
        Me.Label31.TabIndex = 1019
        Me.Label31.Text = "事故日"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.DarkBlue
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label32.Location = New System.Drawing.Point(24, 408)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(128, 24)
        Me.Label32.TabIndex = 1018
        Me.Label32.Text = "承認番号"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label19.Location = New System.Drawing.Point(24, 240)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 24)
        Me.Label19.TabIndex = 1016
        Me.Label19.Text = "請求番号"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number1
        '
        Me.Number1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######", "", "", "-", "", "", "")
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number1.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######", "", "", "-", "", "", "")
        Me.Number1.HighlightText = True
        Me.Number1.Location = New System.Drawing.Point(152, 240)
        Me.Number1.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Name = "Number1"
        Me.Number1.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Size = New System.Drawing.Size(64, 24)
        Me.Number1.TabIndex = 60
        Me.Number1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Number1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number1.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        '
        'TextBox3
        '
        Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox3.Location = New System.Drawing.Point(152, 288)
        Me.TextBox3.MaxLength = 15
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(232, 24)
        Me.TextBox3.TabIndex = 80
        Me.TextBox3.Text = "TextBox3"
        '
        'ComboBox11
        '
        Me.ComboBox11.BackColor = System.Drawing.Color.White
        Me.ComboBox11.Location = New System.Drawing.Point(152, 208)
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(120, 24)
        Me.ComboBox11.TabIndex = 50
        Me.ComboBox11.Text = "ComboBox11"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.DarkBlue
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label34.Location = New System.Drawing.Point(24, 208)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(128, 24)
        Me.Label34.TabIndex = 1058
        Me.Label34.Text = "請求区分"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.DarkBlue
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label30.Location = New System.Drawing.Point(24, 360)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(128, 24)
        Me.Label30.TabIndex = 1020
        Me.Label30.Text = "事故場所"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(288, 208)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 24)
        Me.Label11.TabIndex = 1074
        Me.Label11.Text = "Label11"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.DarkBlue
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label45.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label45.Location = New System.Drawing.Point(24, 288)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(128, 24)
        Me.Label45.TabIndex = 1047
        Me.Label45.Text = "修理品製造番号"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox8
        '
        Me.ComboBox8.Location = New System.Drawing.Point(512, 240)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox8.TabIndex = 170
        Me.ComboBox8.Text = "ComboBox8"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DarkBlue
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label20.Location = New System.Drawing.Point(400, 288)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 24)
        Me.Label20.TabIndex = 1030
        Me.Label20.Text = "電話番号"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label22.Location = New System.Drawing.Point(400, 264)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 24)
        Me.Label22.TabIndex = 1028
        Me.Label22.Text = "修理伝票番号"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.DarkBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label23.Location = New System.Drawing.Point(400, 240)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 24)
        Me.Label23.TabIndex = 1027
        Me.Label23.Text = "伝票区分"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number8
        '
        Me.Number8.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number8.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number8.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number8.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number8.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number8.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number8.HighlightText = True
        Me.Number8.Location = New System.Drawing.Point(512, 408)
        Me.Number8.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number8.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number8.Name = "Number8"
        Me.Number8.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number8.Size = New System.Drawing.Size(80, 24)
        Me.Number8.TabIndex = 260
        Me.Number8.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number8.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number8.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number2
        '
        Me.Number2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number2.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number2.HighlightText = True
        Me.Number2.Location = New System.Drawing.Point(512, 504)
        Me.Number2.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number2.Name = "Number2"
        Me.Number2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Size = New System.Drawing.Size(80, 24)
        Me.Number2.TabIndex = 295
        Me.Number2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number2.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.DarkBlue
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label56.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label56.Location = New System.Drawing.Point(400, 504)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(112, 24)
        Me.Label56.TabIndex = 1063
        Me.Label56.Text = "見積額"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date5
        '
        Me.Date5.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date5.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date5.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date5.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date5.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date5.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date5.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date5.Location = New System.Drawing.Point(736, 360)
        Me.Date5.Name = "Date5"
        Me.Date5.Size = New System.Drawing.Size(112, 24)
        Me.Date5.TabIndex = 330
        Me.Date5.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label21.Location = New System.Drawing.Point(640, 360)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 24)
        Me.Label21.TabIndex = 1060
        Me.Label21.Text = "取消日"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number10
        '
        Me.Number10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number10.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number10.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number10.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number10.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number10.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number10.HighlightText = True
        Me.Number10.Location = New System.Drawing.Point(512, 456)
        Me.Number10.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number10.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number10.Name = "Number10"
        Me.Number10.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number10.Size = New System.Drawing.Size(80, 24)
        Me.Number10.TabIndex = 280
        Me.Number10.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number10.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number10.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number9
        '
        Me.Number9.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number9.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number9.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number9.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number9.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number9.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number9.HighlightText = True
        Me.Number9.Location = New System.Drawing.Point(512, 432)
        Me.Number9.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number9.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number9.Name = "Number9"
        Me.Number9.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number9.Size = New System.Drawing.Size(80, 24)
        Me.Number9.TabIndex = 270
        Me.Number9.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number9.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number9.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number7
        '
        Me.Number7.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number7.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number7.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number7.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number7.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number7.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number7.HighlightText = True
        Me.Number7.Location = New System.Drawing.Point(512, 384)
        Me.Number7.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number7.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number7.Name = "Number7"
        Me.Number7.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number7.Size = New System.Drawing.Size(80, 24)
        Me.Number7.TabIndex = 250
        Me.Number7.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number7.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number7.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number6
        '
        Me.Number6.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number6.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "")
        Me.Number6.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number6.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number6.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number6.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "")
        Me.Number6.HighlightText = True
        Me.Number6.Location = New System.Drawing.Point(512, 360)
        Me.Number6.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number6.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number6.Name = "Number6"
        Me.Number6.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number6.Size = New System.Drawing.Size(80, 24)
        Me.Number6.TabIndex = 240
        Me.Number6.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number6.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number6.Value = New Decimal(New Integer() {999999, 0, 0, 0})
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
        Me.Date3.Location = New System.Drawing.Point(512, 336)
        Me.Date3.Name = "Date3"
        Me.Date3.Size = New System.Drawing.Size(96, 24)
        Me.Date3.TabIndex = 230
        Me.Date3.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
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
        Me.Date2.Location = New System.Drawing.Point(512, 312)
        Me.Date2.Name = "Date2"
        Me.Date2.Size = New System.Drawing.Size(96, 24)
        Me.Date2.TabIndex = 220
        Me.Date2.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'ComboBox12
        '
        Me.ComboBox12.Location = New System.Drawing.Point(736, 336)
        Me.ComboBox12.Name = "ComboBox12"
        Me.ComboBox12.Size = New System.Drawing.Size(128, 24)
        Me.ComboBox12.TabIndex = 320
        Me.ComboBox12.Text = "ComboBox12"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.DarkBlue
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label33.Location = New System.Drawing.Point(640, 336)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(96, 24)
        Me.Label33.TabIndex = 1059
        Me.Label33.Text = "掛種ｺｰﾄﾞ"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.DarkBlue
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label36.Location = New System.Drawing.Point(640, 288)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(96, 24)
        Me.Label36.TabIndex = 1056
        Me.Label36.Text = "修理番号"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.DarkBlue
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label37.Location = New System.Drawing.Point(400, 480)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(112, 24)
        Me.Label37.TabIndex = 1055
        Me.Label37.Text = "請求額"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.DarkBlue
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label38.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label38.Location = New System.Drawing.Point(400, 456)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(112, 24)
        Me.Label38.TabIndex = 1054
        Me.Label38.Text = "請求除外金額"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.DarkBlue
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label39.Location = New System.Drawing.Point(400, 432)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(112, 24)
        Me.Label39.TabIndex = 1053
        Me.Label39.Text = "値引き額"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.DarkBlue
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label40.Location = New System.Drawing.Point(400, 408)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(112, 24)
        Me.Label40.TabIndex = 1052
        Me.Label40.Text = "部品計料"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.DarkBlue
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label41.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label41.Location = New System.Drawing.Point(400, 384)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(112, 24)
        Me.Label41.TabIndex = 1051
        Me.Label41.Text = "作業料"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.DarkBlue
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label42.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label42.Location = New System.Drawing.Point(400, 360)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(112, 24)
        Me.Label42.TabIndex = 1050
        Me.Label42.Text = "出張料"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.DarkBlue
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label43.Location = New System.Drawing.Point(400, 336)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(112, 24)
        Me.Label43.TabIndex = 1049
        Me.Label43.Text = "修理完了日"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.DarkBlue
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label44.Location = New System.Drawing.Point(400, 312)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(112, 24)
        Me.Label44.TabIndex = 1048
        Me.Label44.Text = "修理受付日"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(704, 432)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(128, 32)
        Me.Button5.TabIndex = 340
        Me.Button5.Text = "故障状況入力"
        '
        'Edit2
        '
        Me.Edit2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit2.Format = "9#"
        Me.Edit2.HighlightText = True
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit2.Location = New System.Drawing.Point(512, 288)
        Me.Edit2.MaxLength = 15
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Size = New System.Drawing.Size(120, 24)
        Me.Edit2.TabIndex = 190
        Me.Edit2.Text = "2"
        '
        'CheckBox1
        '
        Me.CheckBox1.ForeColor = System.Drawing.Color.Red
        Me.CheckBox1.Location = New System.Drawing.Point(600, 480)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(184, 24)
        Me.CheckBox1.TabIndex = 1093
        Me.CheckBox1.TabStop = False
        Me.CheckBox1.Text = "限度額ﾁｪｯｸをしない"
        '
        'Number5
        '
        Me.Number5.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number5.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number5.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number5.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number5.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number5.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number5.HighlightText = True
        Me.Number5.Location = New System.Drawing.Point(512, 480)
        Me.Number5.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number5.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number5.Name = "Number5"
        Me.Number5.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number5.Size = New System.Drawing.Size(80, 24)
        Me.Number5.TabIndex = 290
        Me.Number5.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number5.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number5.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Label84
        '
        Me.Label84.Font = New System.Drawing.Font("MS PGothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.Red
        Me.Label84.Location = New System.Drawing.Point(384, 312)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(16, 176)
        Me.Label84.TabIndex = 1101
        Me.Label84.Text = "前回不一致ﾁｪｯｸをしない"
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CheckBox2
        '
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.ForeColor = System.Drawing.Color.Red
        Me.CheckBox2.Location = New System.Drawing.Point(384, 288)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(16, 24)
        Me.CheckBox2.TabIndex = 1100
        Me.CheckBox2.TabStop = False
        Me.CheckBox2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.Color.Silver
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button98.Location = New System.Drawing.Point(768, 568)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(104, 32)
        Me.Button98.TabIndex = 998
        Me.Button98.Text = "終了"
        Me.Button98.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(136, 568)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 995
        Me.Button2.Text = "検索"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 568)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 994
        Me.Button1.Text = "登録"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label83
        '
        Me.Label83.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label83.Location = New System.Drawing.Point(544, 576)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(104, 16)
        Me.Label83.TabIndex = 999
        Me.Label83.Text = "手入力"
        Me.Label83.Visible = False
        '
        'Edit5
        '
        Me.Edit5.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit5.Format = "9"
        Me.Edit5.HighlightText = True
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit5.Location = New System.Drawing.Point(512, 264)
        Me.Edit5.MaxLength = 13
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Size = New System.Drawing.Size(120, 24)
        Me.Edit5.TabIndex = 180
        Me.Edit5.Text = "2"
        '
        'TextBox5
        '
        Me.TextBox5.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox5.Format = "9"
        Me.TextBox5.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox5.LengthAsByte = True
        Me.TextBox5.Location = New System.Drawing.Point(736, 288)
        Me.TextBox5.MaxLength = 13
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(112, 24)
        Me.TextBox5.TabIndex = 300
        Me.TextBox5.Text = "5"
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(552, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(48, 24)
        Me.Label46.TabIndex = 1102
        Me.Label46.Text = "46"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label46.Visible = False
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label49.Location = New System.Drawing.Point(608, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(48, 24)
        Me.Label49.TabIndex = 1103
        Me.Label49.Text = "49"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label49.Visible = False
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label50.Location = New System.Drawing.Point(672, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(88, 24)
        Me.Label50.TabIndex = 1104
        Me.Label50.Text = "50"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label50.Visible = False
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label51.Location = New System.Drawing.Point(560, 88)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(64, 24)
        Me.Label51.TabIndex = 1105
        Me.Label51.Text = "Label51"
        Me.Label51.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Location = New System.Drawing.Point(152, 448)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(152, 32)
        Me.GroupBox2.TabIndex = 135
        Me.GroupBox2.TabStop = False
        '
        'RadioButton3
        '
        Me.RadioButton3.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton3.Location = New System.Drawing.Point(8, 12)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.Text = "B"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'RadioButton4
        '
        Me.RadioButton4.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(84, 12)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton4.TabIndex = 1
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Y"
        Me.RadioButton4.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.RadioButton5)
        Me.GroupBox3.Controls.Add(Me.RadioButton6)
        Me.GroupBox3.Location = New System.Drawing.Point(152, 496)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(152, 32)
        Me.GroupBox3.TabIndex = 155
        Me.GroupBox3.TabStop = False
        '
        'RadioButton5
        '
        Me.RadioButton5.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton5.Location = New System.Drawing.Point(8, 12)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton5.TabIndex = 0
        Me.RadioButton5.Text = "B"
        Me.RadioButton5.UseVisualStyleBackColor = False
        '
        'RadioButton6
        '
        Me.RadioButton6.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton6.Checked = True
        Me.RadioButton6.Location = New System.Drawing.Point(84, 12)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton6.TabIndex = 1
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "Y"
        Me.RadioButton6.UseVisualStyleBackColor = False
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label55.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(304, 456)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(40, 24)
        Me.Label55.TabIndex = 1110
        Me.Label55.Text = "Label55"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label55.Visible = False
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.Black
        Me.Label66.Location = New System.Drawing.Point(304, 504)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(40, 24)
        Me.Label66.TabIndex = 1111
        Me.Label66.Text = ".Label66"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label66.Visible = False
        '
        'Date7
        '
        Me.Date7.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date7.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date7.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date7.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date7.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date7.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date7.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date7.Location = New System.Drawing.Point(736, 384)
        Me.Date7.Name = "Date7"
        Me.Date7.Size = New System.Drawing.Size(112, 24)
        Me.Date7.TabIndex = 331
        Me.Date7.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.DarkBlue
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label52.Location = New System.Drawing.Point(640, 384)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 24)
        Me.Label52.TabIndex = 1113
        Me.Label52.Text = "取込処理日"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label53.Location = New System.Drawing.Point(648, 88)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(64, 24)
        Me.Label53.TabIndex = 1114
        Me.Label53.Text = "Label53"
        Me.Label53.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(898, 607)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Date7)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label83)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Number5)
        Me.Controls.Add(Me.Label84)
        Me.Controls.Add(Me.Date5)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Number10)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.Label82)
        Me.Controls.Add(Me.Label81)
        Me.Controls.Add(Me.Edit4)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Label80)
        Me.Controls.Add(Me.Label79)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label78)
        Me.Controls.Add(Me.Label77)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Label74)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Date6)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.Date4)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ComboBox7)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Number3)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.ComboBox11)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.ComboBox8)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Number8)
        Me.Controls.Add(Me.Number9)
        Me.Controls.Add(Me.Number7)
        Me.Controls.Add(Me.Number6)
        Me.Controls.Add(Me.Date3)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.ComboBox12)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請求データ登録／修正  Ver 2.0"
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Date7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************
    '** 起動時
    '**********************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        objMutex = New System.Threading.Mutex(False, "best_ivc_input")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If

        Call DB_INIT()
        Call DsSet()    '** data set
        Call CmbSet()   '** ComboBox
        Call inz()      '** 初期処理
        Call DspClr1()  '** クリア
        inz_F = "1"

    End Sub

    '**********************************
    '** data set
    '**********************************
    Sub DsSet()
        DB_OPEN("best_wrn")

        '保険会社
        strSQL = "SELECT insurance_co_sub.*, insurance_co_mtr.insurance_name"
        strSQL += " FROM insurance_co_sub INNER JOIN"
        strSQL += " insurance_co_mtr ON"
        strSQL += " insurance_co_sub.insurance_code = insurance_co_mtr.insurance_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "insurance_co_sub")

        '店舗
        strSQL = "SELECT Shop_mtr.*"
        strSQL += " FROM Shop_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Shop_mtr")

        '品種
        strSQL = "SELECT Cat_mtr.*"
        strSQL += " FROM Cat_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Cat_mtr")

        'メーカー
        strSQL = "SELECT vdr_mtr.*"
        strSQL += " FROM vdr_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "vdr_mtr")

        'メーカー（過去分）
        strSQL = "SELECT vdr_mtr2.*"
        strSQL += " FROM vdr_mtr2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "vdr_mtr2")

        '区分
        strSQL = "SELECT CLS_CODE.*"
        strSQL += " FROM CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "CLS_CODE")

        DB_CLOSE()
    End Sub

    '**********************************
    '** ComboBox
    '**********************************
    Sub CmbSet()
        DB_OPEN("best_wrn")

        '事故場所
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '001')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_001")

        ComboBox1.DataSource = DsCMB.Tables("CLS_CODE_001")
        ComboBox1.DisplayMember = "CLS_CODE_NAME"
        ComboBox1.ValueMember = "CLS_CODE"

        '事故状況ﾌﾗｸﾞ
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '002')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_002")

        ComboBox2.DataSource = DsCMB.Tables("CLS_CODE_002")
        ComboBox2.DisplayMember = "CLS_CODE_NAME"
        ComboBox2.ValueMember = "CLS_CODE"

        '項目有無ﾌﾗｸﾞ
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '003')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_003")

        ComboBox3.DataSource = DsCMB.Tables("CLS_CODE_003")
        ComboBox3.DisplayMember = "CLS_CODE_NAME"
        ComboBox3.ValueMember = "CLS_CODE"

        '全損ﾌﾗｸﾞ
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '004')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_004")

        ComboBox4.DataSource = DsCMB.Tables("CLS_CODE_004")
        ComboBox4.DisplayMember = "CLS_CODE_NAME"
        ComboBox4.ValueMember = "CLS_CODE"

        '伝票区分
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '005')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_005")

        ComboBox8.DataSource = DsCMB.Tables("CLS_CODE_005")
        ComboBox8.DisplayMember = "CLS_CODE_NAME"
        ComboBox8.ValueMember = "CLS_CODE"

        '請求区分
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '007')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_007")

        ComboBox11.DataSource = DsCMB.Tables("CLS_CODE_007")
        ComboBox11.DisplayMember = "CLS_CODE_NAME"
        ComboBox11.ValueMember = "CLS_CODE"

        '掛種コード
        strSQL = "SELECT kakesyu, kakesyu + ':' + insurance_code AS insurance_code"
        strSQL += " FROM insurance_co_decision"
        strSQL += " GROUP BY kakesyu, kakesyu + ':' + insurance_code"
        strSQL += " ORDER BY kakesyu, insurance_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "kakesyu")

        ComboBox12.DataSource = DsCMB.Tables("kakesyu")
        ComboBox12.DisplayMember = "insurance_code"
        ComboBox12.ValueMember = "kakesyu"

        DB_CLOSE()
        CmbSet6()
        CmbSet7()

    End Sub
    Sub CmbSet6()
        DsCMB6.Clear()
        '店舗
        strSQL = "SELECT shop_code, shop_code + ' : ' + RTRIM([店舗名(漢字)]) AS 店舗名"
        strSQL += " FROM Shop_mtr"
        strSQL += " WHERE (BY_cls = '" & Label55.Text & "')"
        strSQL += " ORDER BY shop_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(DsCMB6, "Shop_mtr")
        DB_CLOSE()

        ComboBox6.DataSource = DsCMB6.Tables("Shop_mtr")
        ComboBox6.DisplayMember = "店舗名"
        ComboBox6.ValueMember = "shop_code"
    End Sub
    Sub CmbSet7()
        DsCMB7.Clear()
        '店舗
        strSQL = "SELECT shop_code, shop_code + ' : ' + RTRIM([店舗名(漢字)]) AS 店舗名"
        strSQL += " FROM Shop_mtr"
        strSQL += " WHERE (BY_cls = '" & Label66.Text & "')"
        strSQL += " ORDER BY shop_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(DsCMB7, "Shop_mtr")
        DB_CLOSE()

        ComboBox7.DataSource = DsCMB7.Tables("Shop_mtr")
        ComboBox7.DisplayMember = "店舗名"
        ComboBox7.ValueMember = "shop_code"
    End Sub

    '**********************************
    '** 初期処理
    '**********************************
    Sub inz()
        DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='999' AND CLS_CODE='1'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label71.Text = DateAdd(DateInterval.Month, +1, DtView1(0)("CLS_CODE_NAME"))
            Date6.Text = Format(CDate(Label71.Text), "yyyy.MM")
            Label74.Text = DtView1(0)("CLS_CODE_NAME")  '手入力締日
        End If

        DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='999' AND CLS_CODE='0'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label73.Text = DtView1(0)("CLS_CODE_NAME")  '受信締日
        End If

        If Label71.Text <= Label73.Text Then
            Label64.Text = "受信データの締め処理は完了しています。"
        Else
            Label64.Text = Nothing
        End If
        If Label71.Text <= Label74.Text Then
            Label65.Text = "手入力データの締め処理は完了しています。"
        Else
            Label65.Text = Nothing
        End If
    End Sub

    '**********************************
    '** クリア
    '**********************************
    Sub DspClr1()

        Edit1.Text = Nothing        '保証番号
        Edit3.Text = Nothing        '型式
        Edit4.Text = Nothing        '顧客名称(ｶﾅ)

        Edit1.ReadOnly = False : Edit1.TabStop = True '保証番号
        Edit3.ReadOnly = False : Edit3.TabStop = True '型式
        Edit4.ReadOnly = False : Edit4.TabStop = True '顧客名称(ｶﾅ)
        Date6.ReadOnly = False : Date6.TabStop = True '処理日

        Label6.Text = Nothing       '申込日
        Label7.Text = Nothing       '購入日
        Label8.Text = Nothing       '購入価格
        Label53.Text = Nothing      '購入価格 TAX   '消費税8%対応　2014/04/22
        Label9.Text = Nothing       '保証限度額
        Label10.Text = Nothing      '契約状況
        Label70.Text = Nothing      '全損
        Label78.Text = Nothing      '期間区分
        ComboBox12.Text = Nothing

        Label57.Text = Nothing      '修理品購入店名
        Label58.Text = Nothing      'メーカー名
        Label59.Text = Nothing      '品種名
        Label60.Text = Nothing      '修理品購入店コード
        Label61.Text = Nothing      'メーカーコード
        Label62.Text = Nothing      '品種コード

        Label15.Text = Nothing      '行No
        Label17.Text = Nothing      'seq

        Label75.Text = Nothing      '姓
        Label76.Text = Nothing      '名

        Label11.Text = Nothing      'inp_seq
        ComboBox11.Text = Nothing   '請求区分
        Number1.Value = 0           '請求番号
        ComboBox2.Text = Nothing    '事故状況ﾌﾗｸﾞ
        TextBox3.Text = Nothing     '修理品製造番号
        CheckBox2.Checked = False   '修理品製造番号不一致ﾁｪｯｸ
        TextBox4.Text = Nothing     '顧客名称(ｶﾅ)
        Date1.Number = 0            '事故日
        ComboBox1.Text = Nothing    '事故場所
        ComboBox4.Text = Nothing    '全損ﾌﾗｸﾞ
        Number3.Value = 0           '承認番号
        ComboBox3.Text = Nothing    '項目有無ﾌﾗｸﾞ
        ComboBox6.Text = Nothing    '修理受付店
        ComboBox7.Text = Nothing    '修理完了店
        ComboBox8.Text = Nothing    '伝票区分
        Edit5.Text = Nothing        '修理伝票番号
        Edit2.Text = Nothing        '電話番号
        Date2.Number = 0            '修理受付日
        Date3.Number = 0            '修理完了日
        Number6.Value = 0           '出張料
        Number7.Value = 0           '作業料
        Number8.Value = 0           '部品計料
        Number9.Value = 0           '値引き額
        Number10.Value = 0          '請求除外金額
        Label13.Text = 0            '請求額
        Number5.Value = 0            '請求額
        CheckBox1.Checked = False   '限度額ﾁｪｯｸ
        Number2.Value = 0           '見積額
        TextBox5.Text = Nothing     '修理番号
        Date4.Number = 0            '処理日
        ComboBox12.Text = Nothing   '掛種ｺｰﾄﾞ
        Date5.Number = 0            '取消日
        Date7.Number = 0            '取込処理日

        BR_date2 = Nothing

        Label12.Visible = True      '目隠し

        ComboBox11.Visible = False  '請求区分
        Number1.Visible = False     '請求番号
        ComboBox2.Visible = False   '事故状況ﾌﾗｸﾞ
        TextBox3.Visible = False    '修理品製造番号
        TextBox4.Visible = False    '顧客名称(ｶﾅ)
        Date1.Visible = False       '事故日
        ComboBox1.Visible = False   '事故場所
        ComboBox4.Visible = False   '全損ﾌﾗｸﾞ
        Number3.Visible = False     '承認番号
        ComboBox3.Visible = False   '項目有無ﾌﾗｸﾞ
        GroupBox2.Visible = False
        ComboBox6.Visible = False   '修理受付店
        GroupBox3.Visible = False
        ComboBox7.Visible = False   '修理完了店
        ComboBox8.Visible = False   '伝票区分
        Edit5.Visible = False       '修理伝票番号
        Edit2.Visible = False       '電話番号
        Date2.Visible = False       '修理受付日
        Date3.Visible = False       '修理完了日
        Number6.Visible = False     '出張料
        Number7.Visible = False     '作業料
        Number8.Visible = False     '部品計料
        Number9.Visible = False     '値引き額
        Number10.Visible = False    '請求除外金額
        Number5.Visible = False     '請求金額
        Number2.Visible = False     '見積額
        TextBox5.Visible = False    '修理番号
        Date4.Visible = False       '処理日
        ComboBox12.Visible = False  '掛種ｺｰﾄﾞ
        Date5.Visible = False       '取消日
        Date7.Visible = False       '取込処理日
        CheckBox1.Visible = False   '限度額ﾁｪｯｸをしない
        CheckBox2.Visible = False   '前回不一致ﾁｪｯｸをしない

        Button1.Visible = False     '登録
        Button2.Visible = True      '検索
        Button3.Visible = False     'クリア
        Button4.Visible = False     '削除
        Button5.Visible = False     '故障状況入力
        Edit1.Focus()

        P_trbl_code = Nothing
        P_trbl_memo = Nothing
        P_rpar_mome = Nothing
        P_Remarks = Nothing

        Label51.Text = Nothing      'BY
        'Label53.Text = Nothing      'BY
        Label55.Text = Nothing      'BY
        Label66.Text = Nothing      'BY
    End Sub

    Sub dsp1()
        Label12.Visible = False
        ComboBox11.Visible = True : ComboBox11.Text = Nothing '請求区分
        Number1.Visible = True     '請求番号
        ComboBox2.Visible = True : ComboBox2.Text = Nothing '事故状況ﾌﾗｸﾞ
        TextBox3.Visible = True    '修理品製造番号
        TextBox4.Visible = True    '顧客名称(ｶﾅ)
        Date1.Visible = True       '事故日
        ComboBox1.Visible = True : ComboBox1.Text = Nothing '事故場所
        ComboBox4.Visible = True : ComboBox4.Text = Nothing '全損ﾌﾗｸﾞ
        Number3.Visible = True     '承認番号
        ComboBox3.Visible = True : ComboBox3.Text = Nothing '項目有無ﾌﾗｸﾞ
        GroupBox2.Visible = True
        ComboBox6.Visible = True : ComboBox6.Text = Nothing '修理受付店
        GroupBox3.Visible = True
        ComboBox7.Visible = True : ComboBox7.Text = Nothing '修理完了店
        ComboBox8.Visible = True : ComboBox8.Text = Nothing '伝票区分
        Edit5.Visible = True       '修理伝票番号
        Edit2.Visible = True       '電話番号
        Date2.Visible = True       '修理受付日
        Date3.Visible = True       '修理完了日
        Number6.Visible = True     '出張料
        Number7.Visible = True     '作業料
        Number8.Visible = True     '部品計料
        Number9.Visible = True     '値引き額
        Number10.Visible = True    '請求除外金額
        Number5.Visible = True     '請求金額
        Number2.Visible = True     '見積額
        Date4.Visible = True       '処理日
        TextBox5.Visible = True    '修理番号
        ComboBox12.Visible = True : ComboBox12.Text = Nothing '掛種ｺｰﾄﾞ
        Date5.Visible = True       '取消日
        Date7.Visible = True       '取込処理日
        CheckBox1.Visible = True   '限度額ﾁｪｯｸをしない
        CheckBox2.Visible = True   '前回不一致ﾁｪｯｸをしない

    End Sub

    '入力後
    Private Sub Edit4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit4.Leave
        Dim pos As Integer

        pos = Edit4.Text.LastIndexOf(" ")

        If Trim(Edit4.Text) = Nothing Then
            Label75.Text = Nothing
            Label76.Text = Nothing
        Else
            If pos < 0 Then
                Label75.Text = Trim(Edit4.Text)
                Label76.Text = Nothing
            Else
                Label75.Text = Trim(Mid(Edit4.Text, 1, pos))
                Label76.Text = Trim(Mid(Edit4.Text, pos + 1, 100))
            End If
        End If

    End Sub

    '**********************************
    '** 検索入力チェック
    '**********************************
    Sub DspChk1()
        Dim AND_F As String
        Err_F = "0"

        '入力チェック
        If Trim(Edit1.Text) = Nothing _
           And Trim(Edit3.Text) = Nothing _
           And Trim(Edit4.Text) = Nothing Then
            MsgBox("データを絞り込むため、何れかをわかる範囲で入力してください。", MsgBoxStyle.Critical, "Error")
            Edit1.Focus()
            Err_F = "1"
            Exit Sub
        End If

        'データチェック
        P_DsList1.Clear()
        'New Data
        strSQL = "SELECT Wrn_mtr.ordr_no, Wrn_sub.line_no, Wrn_sub.seq, Wrn_sub.model_name"
        strSQL += ", RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS cust_name"
        strSQL += ", Wrn_mtr.shop_code, Wrn_sub.corp_flg, Wrn_sub.prch_price, Wrn_sub.prch_tax, Wrn_sub.prch_date"
        strSQL += ", Wrn_sub.cont_flg, Wrn_sub.bend_code, Wrn_sub.total_loss_flg, Wrn_sub.op_date"
        strSQL += ", Wrn_mtr.srch_phn, Wrn_sub.item_cat_code, Wrn_sub.ser_no, Wrn_sub.cxl_date"
        strSQL += ", Wrn_mtr.s_flg, Wrn_mtr.b_flg, Wrn_sub.b_flg AS b_flg2, Wrn_sub.wrn_prod"
        strSQL += ", Wrn_sub_2.wrn_prod2, V_Cat_mtr.GRP, Cat_mtr.GRP AS GRP2, Wrn_mtr.entry_date"
        strSQL += ", Wrn_sub.BY_cls, Wrn_sub.fin_date"
        strSQL += " FROM Wrn_mtr INNER JOIN"
        strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no LEFT OUTER JOIN"
        strSQL += " Wrn_sub_2 ON Wrn_sub.ordr_no = Wrn_sub_2.ordr_no AND Wrn_sub.line_no = Wrn_sub_2.line_no AND"
        strSQL += " Wrn_sub.seq = Wrn_sub_2.seq LEFT OUTER JOIN"
        strSQL += " Cat_mtr ON Wrn_sub_2.item_cat_code3 = Cat_mtr.cd3 AND Wrn_sub.BY_cls = Cat_mtr.BY_cls AND"
        strSQL += " Wrn_sub.item_cat_code = Cat_mtr.cd12 LEFT OUTER JOIN"
        strSQL += " V_Cat_mtr ON Wrn_sub.BY_cls = V_Cat_mtr.BY_cls AND Wrn_sub.item_cat_code = V_Cat_mtr.cd12"
        strSQL += " WHERE"
        AND_F = "0"
        If Trim(Edit1.Text) <> Nothing Then
            strSQL += " (Wrn_mtr.ordr_no LIKE '" & Edit1.Text & "%')"
            AND_F = "1"
        End If
        If Trim(Edit3.Text) <> Nothing Then
            If AND_F = "1" Then
                strSQL += " AND (Wrn_sub.model_name LIKE '" & Edit3.Text & "%')"
            Else
                strSQL += " (Wrn_sub.model_name LIKE '" & Edit3.Text & "%')"
            End If
            AND_F = "1"
        End If
        If Trim(Label75.Text) <> Nothing Then
            If AND_F = "1" Then
                strSQL += " AND (Wrn_mtr.cust_lname LIKE '" & Label75.Text & "%')"
            Else
                strSQL += " (Wrn_mtr.cust_lname LIKE '" & Label75.Text & "%')"
            End If
            AND_F = "1"
        End If
        If Trim(Label76.Text) <> Nothing Then
            If AND_F = "1" Then
                strSQL += " AND (Wrn_mtr.cust_fname LIKE '" & Label76.Text & "%')"
            Else
                strSQL += " (Wrn_mtr.cust_fname LIKE '" & Label76.Text & "%')"
            End If
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)

        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsList1, "Wrn")
        DB_CLOSE()

        'Old Data
        strSQL = "SELECT wrn_data.ordr_no, wrn_data.line_no, 0 AS seq, wrn_data.model_name"
        strSQL += ", wrn_data.cust_name, wrn_data.shop_code, wrn_data_corp.corp_flg"
        strSQL += ", wrn_data.prch_price, 0 AS prch_tax, wrn_data.prch_date, wrn_data.cont_flg"
        strSQL += ", wrn_data.vend_code AS bend_code, wrn_data.total_loss_flg, wrn_data.op_date"
        strSQL += ", wrn_data.srch_phn, wrn_data.item_cat_code, ' ' AS ser_no, wrn_data.cxl_date"
        strSQL += ", wrn_data.s_flg, wrn_data.b_flg, wrn_data.b_flg AS b_flg2"
        strSQL += ", '60' AS wrn_prod, '60' AS wrn_prod2"
        strSQL += ", 'A' AS GRP, 'A' AS GRP2, wrn_data.op_date AS entry_date, 'B' AS BY_cls"
        strSQL += " FROM wrn_data LEFT OUTER JOIN"
        strSQL += " wrn_data_corp ON wrn_data.ordr_no = wrn_data_corp.ordr_no WHERE"
        AND_F = "0"
        If Trim(Edit1.Text) <> Nothing Then
            strSQL += " (wrn_data.ordr_no LIKE '" & Edit1.Text & "%')"
            AND_F = "1"
        End If
        If Trim(Edit3.Text) <> Nothing Then
            If AND_F = "1" Then
                strSQL += " AND (wrn_data.model_name LIKE '" & Edit3.Text & "%')"
            Else
                strSQL += " (wrn_data.model_name LIKE '" & Edit3.Text & "%')"
            End If
            AND_F = "1"
        End If
        If Trim(Edit4.Text) <> Nothing Then
            If AND_F = "1" Then
                strSQL += " AND (wrn_data.cust_name LIKE '" & Edit4.Text & "%')"
            Else
                strSQL += " (wrn_data.cust_name LIKE '" & Edit4.Text & "%')"
            End If
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)

        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn_data2")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsList1, "Wrn")
        DB_CLOSE()

        DtView1 = New DataView(P_DsList1.Tables("Wrn"), "", "ordr_no, line_no, seq", DataViewRowState.CurrentRows)

        Select Case DtView1.Count
            Case Is = 0
                MsgBox("該当する加入データがありません。", MsgBoxStyle.Critical, "Error")
                Edit1.Focus()
                Err_F = "1"
                Exit Sub
            Case Is = 1
            Case Is <= 100
            Case Else
                str_ANS = MsgBox("該当する加入データが " & Format(DtView1.Count, "##,##0") & "件あります。" & Chr(13) & "処理を続けますか？", MsgBoxStyle.OkCancel, "確認")
                If str_ANS <> "1" Then   'OK
                    Edit1.Focus()
                    Err_F = "1"
                    Exit Sub
                End If
        End Select

    End Sub

    Sub DspSet1(ByVal no)

        NO_MNT_F = "0"
        Call dsp1()
        Label82.Text = Nothing
        If Not IsDBNull(DtView1(no)("s_flg")) Then
            If DtView1(no)("s_flg") = "1" Then
                Label82.Text = "1"
                MsgBox("ソニア引受分")
            End If
        End If
        If Not IsDBNull(DtView1(no)("b_flg")) Then
            If DtView1(no)("b_flg") = "1" Then
                Label82.Text = "2"
                MsgBox("ベスト引受分")
            End If
        End If
        If Not IsDBNull(DtView1(no)("b_flg2")) Then
            If DtView1(no)("b_flg2") = "1" Then
                If DtView1(no)("corp_flg") = "0" Then
                    Label82.Text = "3"
                    'MsgBox("ベスト引受分")
                End If
            End If
        End If

        'Label51.Text = DtView1(no)("BY_cls")

        Edit1.Text = Trim(DtView1(no)("ordr_no"))
        Edit3.Text = Trim(DtView1(no)("model_name"))
        Label15.Text = DtView1(no)("line_no")
        Label17.Text = DtView1(no)("seq")
        Edit4.Text = Trim(DtView1(no)("cust_name"))
        TextBox4.Text = Trim(DtView1(no)("cust_name"))
        Label6.Text = DtView1(no)("op_date")
        '↓↓↓↓↓2018/03/08 購入日のセットを受注日から完了日に変更
        'If Not IsDBNull(DtView1(no)("prch_date")) Then
        '    Label7.Text = DtView1(no)("prch_date")
        'Else
        '    Label7.Text = Nothing
        'End If
        If Not IsDBNull(DtView1(no)("fin_date")) Then
            Label7.Text = DtView1(no)("fin_date")
        Else
            Label7.Text = Nothing
        End If
        '↑↑↑↑↑2018/03/08 購入日のセットを受注日から完了日に変更
        Label8.Text = Format(DtView1(no)("prch_price"), "##,##0")
        Label53.Text = DtView1(no)("prch_tax")                          '消費税8%対応　2014/04/22
        Label10.Text = DtView1(no)("cont_flg")
        If Label10.Text = "C" Then
            Label10.ForeColor = System.Drawing.Color.Red
            Label81.Text = DtView1(no)("cxl_date")
        Else
            Label10.ForeColor = System.Drawing.Color.Black
            Label81.Text = Nothing
        End If

        If Not IsDBNull(DtView1(no)("total_loss_flg")) Then
            If DtView1(no)("total_loss_flg") = "1" Then
                'Label10.Text = "Z"
                Label70.Text = "全損"
                NO_MNT_F = "1"
            End If
        End If

        Label60.Text = DtView1(no)("shop_code")     '修理品購入店
        DtView3 = New DataView(DsList1.Tables("Shop_mtr"), "shop_code='" & Label60.Text & "' AND BY_cls='" & Label51.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView3.Count <> 0 Then
            Label57.Text = Label60.Text & " : " & DtView3(0)("店舗名(漢字)")
        Else
            Label57.Text = Label60.Text
        End If

        Label61.Text = DtView1(no)("bend_code")     'メーカー
        DtView3 = New DataView(DsList1.Tables("vdr_mtr"), "vdr_code='" & Label61.Text & "' AND BY_cls='" & Label51.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView3.Count <> 0 Then
            Label58.Text = Label61.Text & " : " & DtView3(0)("vdr_name")
        Else
            DtView3 = New DataView(DsList1.Tables("vdr_mtr2"), "vdr_code='" & Label61.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView3.Count <> 0 Then
                Label58.Text = RTrim(Label61.Text) & " : " & DtView3(0)("vdr_kana")
            Else
                Label58.Text = Label61.Text
            End If
        End If

        Label62.Text = DtView1(no)("item_cat_code") '品種
        If LenB(Label62.Text) = 4 Then
            DtView3 = New DataView(DsList1.Tables("cat_mtr"), "cd1='" & Mid(Label62.Text, 1, 2) & "' AND cd2='" & Mid(Label62.Text, 3, 2) & "' AND cd3='00' AND BY_cls='" & Label51.Text & "'", "", DataViewRowState.CurrentRows)
        Else
            DtView3 = New DataView(DsList1.Tables("cat_mtr"), "cd1='" & Mid(Label62.Text, 1, 4) & "' AND cd2='" & Mid(Label62.Text, 5, 2) & "' AND cd3='00' AND BY_cls='" & Label51.Text & "'", "", DataViewRowState.CurrentRows)
        End If
        If DtView3.Count <> 0 Then
            Label59.Text = Label62.Text & " : " & DtView3(0)("品種名(漢字)")
        Else
            Label59.Text = Label62.Text
        End If

        Edit2.Text = Trim(DtView1(no)("srch_phn"))
        If Not IsDBNull(DtView1(no)("ser_no")) Then
            TextBox3.Text = Trim(DtView1(no)("ser_no"))
        Else
            TextBox3.Text = Nothing
        End If
        'Date1.Text = Now.Date

        'If Label7.Text <> Nothing Then
        '    Call up_line(Label7.Text)   '保証限度額
        'End If

        If Not IsDBNull(DtView1(no)("corp_flg")) Then
            Label79.Text = DtView1(no)("corp_flg")
        Else
            Label79.Text = "0"
        End If
        If Label79.Text = "1" Then
            Call A_YYYY(Label7.Text)  '加入期間
        End If
        Label83.Text = "0"  '受信ﾃﾞｰﾀﾌﾗｸﾞ

        If Not IsDBNull(DtView1(no)("wrn_prod2")) Then
            Label46.Text = DtView1(no)("wrn_prod2")
        Else
            Label46.Text = DtView1(no)("wrn_prod")
        End If
        If Not IsDBNull(DtView1(no)("GRP2")) Then
            Label49.Text = DtView1(no)("GRP2")
        Else
            ' Label49.Text = DtView1(no)("GRP")
        End If
        If Not IsDBNull(DtView1(no)("entry_date")) Then
            Label50.Text = DtView1(no)("entry_date")
        Else
            Label50.Text = Nothing
        End If

        '請求データ
        DsSearch2.Clear()
        strSQL = "SELECT Wrn_ivc.*"
        strSQL += " FROM Wrn_ivc"
        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
        strSQL += " AND (line_no = '" & Label15.Text & "')"
        strSQL += " AND (seq = " & Label17.Text & ")"
        strSQL += " AND (close_date = CONVERT(DATETIME, '" & Label71.Text & "', 102))"   '同一締め内
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsSearch2, "Wrn")
        DB_CLOSE()
        DtView2 = New DataView(DsSearch2.Tables("Wrn"), "", "", DataViewRowState.CurrentRows)

        If DtView2.Count = 0 Then
            Button1.Text = "登録"
            ComboBox11.SelectedValue = "1" '請求区分
            ComboBox11.Enabled = False
            CheckBox1.Enabled = True        '限度内ﾁｪｯｸ
            Label21.Visible = False         '取消日
            Date5.Visible = False
            Label19.Visible = False         '請求番号
            Number1.Value = 0
            Label55.Text = "Y" 'Label51.Text
            If Label55.Text = "Y" Then
                RadioButton4.Checked = True
            Else
                RadioButton3.Checked = True
            End If
            CmbSet6()
            ComboBox6.Text = Nothing
            Label66.Text = "Y" 'Label51.Text
            If Label66.Text = "Y" Then
                RadioButton6.Checked = True
            Else
                RadioButton5.Checked = True
            End If
            CmbSet7()
            ComboBox7.Text = Nothing
            Number1.Visible = False
            Label36.Visible = False         '修理番号
            TextBox5.Visible = False
            TextBox5.Text = "000000000000"
            If Label65.Text <> Nothing Then
                NO_MNT_F = "1"
            End If
            If Label7.Text = Nothing Then
                NO_MNT_F = "1"
            End If
        Else
            Button1.Text = "修正"
            ComboBox11.Enabled = True
            CheckBox1.Enabled = True        '限度内ﾁｪｯｸ
            Call DspSet1_2()
            If Label11.Text = Nothing Then  '受信
                Button4.Visible = False
                Label19.Visible = True         '請求番号
                Number1.Visible = True
                Label36.Visible = True         '修理番号
                TextBox5.Visible = True
            Else
                Button4.Visible = True
                Label19.Visible = False         '請求番号
                Number1.Visible = False
                Number1.Value = 0
                Label36.Visible = False         '修理番号
                TextBox5.Visible = False
                TextBox5.Text = "000000000000"
            End If
            If DtView2(0)("close_flg") = "1" Then
                NO_MNT_F = "1"
            Else
                NO_MNT_F = "0"
            End If
            If IsDBNull(DtView2(0)("inp_seq")) Then
                Label83.Text = "1"
            End If
        End If
        If Label83.Text = "1" Then  '受信ﾃﾞｰﾀﾌﾗｸﾞ
            Number6.Enabled = False
            Number7.Enabled = False
            Number8.Enabled = False
            Number9.Enabled = False
            Number10.Enabled = False
            Number5.Enabled = False
            Number2.Enabled = False
            Number1.Enabled = False
            TextBox5.Enabled = False
        Else
            Number6.Enabled = True
            Number7.Enabled = True
            Number8.Enabled = True
            Number9.Enabled = True
            Number10.Enabled = True
            Number5.Enabled = True
            Number2.Enabled = True
            Number1.Enabled = True
            TextBox5.Enabled = True
        End If

        If NO_MNT_F = "1" Then  '登録・修正不可
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = True
            Button4.Visible = False
            Button5.Visible = True
        Else
            Button1.Visible = True
            Button2.Visible = False
            Button3.Visible = True
            Button5.Visible = True
        End If

    End Sub

    Sub DspSet1_2()
        Label9.Text = Format(DtView2(0)("Limit_money"), "##,##0")

        If Not IsDBNull(DtView2(0)("inp_seq")) Then
            Label11.Text = DtView2(0)("inp_seq")            'inp_seq
        Else
            Label11.Text = Nothing
        End If
        ComboBox11.SelectedValue = DtView2(0)("FLD032") '請求区分
        'Label53.Text = DtView2(0)("BY_cls")
        'If Label53.Text = "Y" Then
        '    RadioButton2.Checked = True
        'Else
        '    RadioButton1.Checked = True
        'End If
        Number1.Value = DtView2(0)("FLD002")            '請求番号
        ComboBox2.SelectedValue = DtView2(0)("FLD007")  '事故状況ﾌﾗｸﾞ
        TextBox3.Text = Trim(DtView2(0)("FLD020"))      '修理品製造番号
        If DtView2(0)("FLD020_off") = "True" Then CheckBox2.Checked = True Else CheckBox2.Checked = False '修理品製造番号不一致チェック
        TextBox4.Text = Trim(DtView2(0)("FLD015"))      '顧客名称(ｶﾅ)
        Date1.Text = DtView2(0)("FLD005")               '事故日
        Call A_YYYY(Label7.Text)                        '加入後の期間
        ComboBox1.SelectedValue = DtView2(0)("FLD006") '事故場所
        ComboBox4.SelectedValue = DtView2(0)("FLD009")  '全損ﾌﾗｸﾞ
        Number3.Value = DtView2(0)("FLD004")            '承認番号
        ComboBox3.SelectedValue = DtView2(0)("FLD008")  '項目有無ﾌﾗｸﾞ
        Label55.Text = DtView2(0)("ent_BY_cls")
        If Label55.Text = "Y" Then
            RadioButton4.Checked = True
        Else
            RadioButton3.Checked = True
        End If
        CmbSet6()
        ComboBox6.SelectedValue = DtView2(0)("FLD011")  '修理受付店
        Label66.Text = DtView2(0)("fin_BY_cls")
        If Label66.Text = "Y" Then
            RadioButton6.Checked = True
        Else
            RadioButton5.Checked = True
        End If
        CmbSet7()
        ComboBox7.SelectedValue = DtView2(0)("FLD012")  '修理完了店
        ComboBox8.SelectedValue = DtView2(0)("FLD013")  '伝票区分
        Edit5.Text = DtView2(0)("FLD014")               '修理伝票番号
        Edit2.Text = Trim(DtView2(0)("FLD016"))         '電話番号
        Date2.Text = DtView2(0)("FLD021")               '修理受付日
        Date3.Text = DtView2(0)("FLD022")               '修理完了日
        Number6.Value = DtView2(0)("FLD023")            '出張料
        Number7.Value = DtView2(0)("FLD024")            '作業料
        Number8.Value = DtView2(0)("FLD025")            '部品計料
        Number9.Value = DtView2(0)("FLD026")            '値引き額
        Number10.Value = DtView2(0)("FLD027")           '請求除外金額
        Label13.Text = Format(DtView2(0)("FLD028"), "##,##0")   '請求額
        Number5.Value = DtView2(0)("FLD028")             '請求額
        Number2.Value = DtView2(0)("FLD029")            '見積額
        TextBox5.Text = DtView2(0)("FLD030")           '修理番号
        Date4.Text = DtView2(0)("FLD031")               '処理日
        If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = DtView2(0)("FLD033") '掛種ｺｰﾄﾞ
        If DtView2(0)("FLD032") = "1" Then
            Label21.Visible = False         '取消日
            Date5.Visible = False           '取消日
        Else
            Label21.Visible = True          '取消日
            Date5.Visible = True            '取消日
            If Not IsDBNull(DtView2(0)("Cancel_date")) Then
                Date5.Text = DtView2(0)("Cancel_date")      '取消日
            End If
        End If
        If Not IsDBNull(DtView2(0)("imp_date")) Then Date7.Text = DtView2(0)("imp_date") Else Date7.Text = Nothing '取込処理日
        If DtView2(0)("Limit_money_off") = "1" Then CheckBox1.Checked = True Else CheckBox1.Checked = False '限度額チェック

        If Not IsDBNull(DtView2(0)("trbl_code")) Then P_trbl_code = DtView2(0)("trbl_code") '故障状況
        If Not IsDBNull(DtView2(0)("trbl_memo")) Then P_trbl_memo = Trim(DtView2(0)("trbl_memo")) '故障状況
        If Not IsDBNull(DtView2(0)("rpar_mome")) Then P_rpar_mome = Trim(DtView2(0)("rpar_mome")) '修理内容
        If Not IsDBNull(DtView2(0)("Remarks")) Then P_Remarks = Trim(DtView2(0)("Remarks")) '連絡事項

        If Label7.Text <> Nothing Then
            Call KbnNo()                        '期間区分
            'Call up_line(Label7.Text)           '保証限度額
        End If

        ComboBox11.Focus()
    End Sub

    Sub DspChk2()
        Err_F = "0"

        '請求区分
        DtView3 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='007' AND CLS_CODE='" & ComboBox11.SelectedValue & "'", "", DataViewRowState.CurrentRows)
        If DtView3.Count = 0 Then
            MsgBox("請求区分エラー", MsgBoxStyle.Critical, "Error")
            ComboBox11.Focus()
            Err_F = "1" : Exit Sub
        End If

        If Mid(ComboBox11.Text, 1, 1) = "1" Then '請求

            ''請求番号チェック
            'If Number1.Value = 0 Then
            '    MsgBox("請求番号は入力必須", MsgBoxStyle.Critical, "Error")
            '    Number1.Focus()
            '    Err_F = "1" : Exit Sub
            'End If

            '事故状況フラグチェック
            DtView3 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='002' AND CLS_CODE='" & ComboBox2.SelectedValue & "'", "", DataViewRowState.CurrentRows)
            If DtView3.Count = 0 Then
                MsgBox("事故状況フラグエラー", MsgBoxStyle.Critical, "Error")
                ComboBox2.Focus()
                Err_F = "1" : Exit Sub
            End If

            '修理品製造番号チェック
            Select Case Trim(ComboBox2.SelectedValue)
                Case Is = "0", "4"
                    If Trim(TextBox3.Text) = Nothing Then
                        MsgBox("修理品製造番号は延長修理、破損の時は入力必須", MsgBoxStyle.Critical, "Error")
                        TextBox3.Focus()
                        Err_F = "1" : Exit Sub
                    Else
                        If CheckBox2.Checked = False Then
                            WK_DsList1.Clear()
                            strSQL = "SELECT close_date, seq_sub, FLD020 FROM Wrn_ivc"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                            strSQL += " AND (line_no = '" & Label15.Text & "')"
                            strSQL += " AND (seq = " & Label17.Text & ")"
                            strSQL += " AND (close_date <> CONVERT(DATETIME, '" & Label71.Text & "', 102))"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("best_wrn")
                            DaList1.Fill(WK_DsList1, "Wrn_ivc")
                            DB_CLOSE()
                            DtView2 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "close_date DESC, seq_sub DESC", DataViewRowState.CurrentRows)
                            If DtView2.Count <> 0 Then
                                If Trim(DtView2(0)("FLD020")) <> Trim(TextBox3.Text) Then
                                    MsgBox("修理品製造番号が前回と不一致", MsgBoxStyle.Critical, "Error")
                                    TextBox3.Focus()
                                    Err_F = "1" : Exit Sub
                                End If
                            End If
                        End If
                    End If
            End Select
            'If Trim(ComboBox2.SelectedValue) = "1" Then    '盗難の場合はnullでもOK
            'Else
            '    If Trim(TextBox3.Text) = Nothing Then
            '        MsgBox("修理品製造番号は盗難の時を除き入力必須", MsgBoxStyle.Critical, "Error")
            '        TextBox3.Focus()
            '        Err_F = "1" : Exit Sub
            '    End If
            'End If

            '顧客名チェック
            '2014/11/05 加入情報の顧客名（姓）登録なしデータも登録可に変更 start
            namedif_f = False   '顧客名チェックフラグ初期化
            If Trim(TextBox4.Text) = Nothing Then
                MsgBox("顧客名は入力必須", MsgBoxStyle.Critical, "Error")
                TextBox4.Focus()
                Err_F = "1" : Exit Sub
            Else
                Dim Lname, Lname2 As String
                If Edit4.Text.IndexOf(" ") > 0 Then
                    Lname = Mid(Edit4.Text, 1, Edit4.Text.IndexOf(" "))   '姓名分割
                Else
                    Lname = Trim(Edit4.Text)
                End If
                If TextBox4.Text.IndexOf(" ") > 0 Then
                    Lname2 = Mid(TextBox4.Text, 1, TextBox4.Text.IndexOf(" "))   '姓名分割
                Else
                    Lname2 = Trim(TextBox4.Text)
                End If

                If Lname <> Lname2 Then
                    'MsgBox("加入データの姓と違っています", MsgBoxStyle.Critical, "Error")
                    'TextBox4.Focus()
                    namedif_f = True
                    'Err_F = "1" : Exit Sub
                End If
                '2014/11/05 加入情報の顧客名（姓）登録なしデータも登録可に変更 end
            End If

            '事故日チェック
            Data_F05 = "0"
            If Date1.Number = "0" Then    '延長保証の場合はnullでもOK
                Data_F05 = "1"
                'If Trim(ComboBox2.SelectedValue) <> "0" Then
                'MsgBox("事故日は延長保証の時を除き入力必須", MsgBoxStyle.Critical, "Error")
                MsgBox("事故日は入力必須", MsgBoxStyle.Critical, "Error")
                Date1.Focus()
                Err_F = "1" : Exit Sub
                'End If
            Else
                If Date1.Text > Now.Date Then
                    MsgBox("事故日エラー(未来日付)", MsgBoxStyle.Critical, "Error")
                    Date1.Focus()
                    Err_F = "1" : Exit Sub
                End If
                If Label10.Text = "C" Then
                    If Date1.Text > Label81.Text Then
                        MsgBox("キャンセル日以降の日付エラー（キャンセル日：" & Label81.Text & "）", MsgBoxStyle.Critical, "Error")
                        Date1.Focus()
                        Err_F = "1" : Exit Sub
                    End If
                End If
            End If

            '保障期間チェック
            WK_nen = Round(CInt(Label46.Text) / 12, 0)
            If DateAdd(DateInterval.Year, WK_nen, CDate(Label7.Text)) <= Date1.Text Then
                MsgBox(WK_nen & "年間の保証期限切れ", MsgBoxStyle.Critical, "Error")
                Date1.Focus()
                Err_F = "1" : Exit Sub
            End If

            Select Case Trim(ComboBox2.SelectedValue)
                Case Is = "0"   '故障
                    If DateAdd(DateInterval.Year, 1, CDate(Label7.Text)) > Date1.Text Then
                        MsgBox("延長保障は2年目から対象", MsgBoxStyle.Critical, "Error")
                        ComboBox2.Focus()
                        Err_F = "1" : Exit Sub
                    End If
                Case Is = "4"   '破損
                    If DateAdd(DateInterval.Year, 1, CDate(Label7.Text)) <= Date1.Text Then
                        MsgBox("破損は1年目のみ対象", MsgBoxStyle.Critical, "Error")
                        ComboBox2.Focus()
                        Err_F = "1" : Exit Sub
                    End If
            End Select

            '該当保険会社チェック
            If Trim(Label78.Text) = Nothing Then
                MsgBox("該当する保険会社なし（マスタを確認）", MsgBoxStyle.Critical, "Error")
                ComboBox2.Focus()
                Err_F = "1" : Exit Sub
            End If

            '全損フラグチェック
            DtView3 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='004' AND CLS_CODE='" & ComboBox4.SelectedValue & "'", "", DataViewRowState.CurrentRows)
            If DtView3.Count = 0 Then
                MsgBox("全損フラグエラー", MsgBoxStyle.Critical, "Error")
                ComboBox4.Focus()
                Err_F = "1" : Exit Sub
            End If

            '承認番号チェック
            '2014/09/24 承認番号不要のためコメントアウト
            'If Mid(Label78.Text, 1, 1) <> "A" Then
            'If Number5.Value > 105000 Then
            'If Number3.Value = 0 Then
            'MsgBox("承認番号は100,000円以上の時は入力必須", MsgBoxStyle.Critical, "Error")
            'Number3.Focus()
            'Err_F = "1" : Exit Sub
            'End If
            'End If
            'If Trim(ComboBox4.SelectedValue) = "0" Then  '修理
            '    'If CInt(Label13.Text) > 100000 Then
            '    If Number5.Value > 105000 Then
            '        If Number3.Value = 0 Then
            '            MsgBox("承認番号は修理で100,000円以上の時は入力必須", MsgBoxStyle.Critical, "Error")
            '            Number3.Focus()
            '            Err_F = "1" : Exit Sub
            '        End If
            '    End If
            'Else                                    '全損
            '    'If CInt(Label13.Text) > 50000 Then
            '    If Number5.Value > 52500 Then
            '        If Number3.Value = 0 Then
            '            MsgBox("承認番号は全損で50,000円以上の時は入力必須", MsgBoxStyle.Critical, "Error")
            '            Number3.Focus()
            '            Err_F = "1" : Exit Sub
            '        End If
            '    End If
            'End If
            'End If

            '事故場所チェック
            If ComboBox1.Text = Nothing And Trim(ComboBox2.SelectedValue) = "0" Then    '延長保証の場合はnullでもOK
            Else
                DtView3 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='001' AND CLS_CODE='" & ComboBox1.SelectedValue & "'", "", DataViewRowState.CurrentRows)
                If DtView3.Count = 0 Then
                    MsgBox("事故場所は延長保証の時を除き入力必須", MsgBoxStyle.Critical, "Error")
                    ComboBox1.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '項目有無フラグチェック
            DtView3 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='003' AND CLS_CODE='" & ComboBox3.SelectedValue & "'", "", DataViewRowState.CurrentRows)
            If DtView3.Count = 0 Then
                MsgBox("項目有無エラー", MsgBoxStyle.Critical, "Error")
                ComboBox3.Focus()
                Err_F = "1" : Exit Sub
            End If

            '修理受付店チェック
            If ComboBox6.Text = Nothing Then
                MsgBox("修理受付店は入力必須", MsgBoxStyle.Critical, "Error")
                ComboBox6.Focus()
                Err_F = "1" : Exit Sub
            Else
                DtView3 = New DataView(DsCMB6.Tables("Shop_mtr"), "shop_code = '" & ComboBox6.SelectedValue & "'", "", DataViewRowState.CurrentRows)
                If DtView3.Count = 0 Then
                    MsgBox("修理受付店舗該当なし", MsgBoxStyle.Critical, "Error")
                    ComboBox6.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '修理完了店チェック
            If ComboBox7.Text = Nothing Then
                MsgBox("修理完了店は入力必須", MsgBoxStyle.Critical, "Error")
                ComboBox7.Focus()
                Err_F = "1" : Exit Sub
            Else
                DtView3 = New DataView(DsCMB7.Tables("Shop_mtr"), "shop_code = '" & ComboBox7.SelectedValue & "'", "", DataViewRowState.CurrentRows)
                If DtView3.Count = 0 Then
                    MsgBox("修理完了店舗該当なし", MsgBoxStyle.Critical, "Error")
                    ComboBox7.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '伝票区分チェック
            DtView3 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='005' AND CLS_CODE='" & ComboBox8.SelectedValue & "'", "", DataViewRowState.CurrentRows)
            If DtView3.Count = 0 Then
                MsgBox("伝票区分エラー", MsgBoxStyle.Critical, "Error")
                ComboBox8.Focus()
                Err_F = "1" : Exit Sub
            End If

            '修理伝票番号チェック
            Edit5.Text = Trim(Edit5.Text)
            If Edit5.Text = Nothing Then
                MsgBox("修理伝票番号は入力必須", MsgBoxStyle.Critical, "Error")
                Edit5.Focus()
                Err_F = "1" : Exit Sub
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT ordr_no, line_no, seq, close_date, seq_sub, FLD028"
                strSQL += " FROM Wrn_ivc"
                strSQL += " WHERE (FLD032 = N'1')"
                strSQL += " AND (FLD014 = N'" & Edit5.Text & "')"
                strSQL += " AND (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (close_date <> CONVERT(DATETIME, '" & Label71.Text & "', 102))"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("best_wrn")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "Wrn_ivc")
                DB_CLOSE()
                DtView3 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
                If DtView3.Count <> 0 Then
                    MsgBox("修理伝票番号重複", MsgBoxStyle.Critical, "Error")
                    Edit5.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '電話番号チェック
            If Trim(Edit2.Text) = Nothing Then
                MsgBox("電話番号は入力必須", MsgBoxStyle.Critical, "Error")
                Edit2.Focus()
                Err_F = "1" : Exit Sub
            End If

            '修理受付日チェック
            If Date2.Number = 0 Then
                MsgBox("修理受付日は入力必須", MsgBoxStyle.Critical, "Error")
                Date2.Focus()
                Err_F = "1" : Exit Sub
            Else
                If Date2.Text > Now.Date Then
                    MsgBox("修理受付日エラー(未来日付)", MsgBoxStyle.Critical, "Error")
                    Date2.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '修理完了日チェック
            If Date3.Number = 0 Then
                MsgBox("修理完了日は入力必須", MsgBoxStyle.Critical, "Error")
                Date3.Focus()
                Err_F = "1" : Exit Sub
            Else
                If Date3.Text > Now.Date Then
                    MsgBox("修理完了日エラー(未来日付)", MsgBoxStyle.Critical, "Error")
                    Date3.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '日付相関チェック
            If Data_F05 = "0" Then
                If Date1.Text > Date2.Text Then
                    MsgBox("事故日＞修理受付日エラー", MsgBoxStyle.Critical, "Error")
                    Date2.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If
            If Data_F05 = "0" Then
                If Date1.Text < CDate(Label7.Text) Then
                    MsgBox("事故日が購入日前エラー", MsgBoxStyle.Critical, "Error")
                    Date1.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If
            If Data_F05 = "0" Then
                If Date1.Text > Date3.Text Then
                    MsgBox("事故日＞修理完了日エラー", MsgBoxStyle.Critical, "Error")
                    Date3.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If
            If Date2.Text > Date3.Text Then
                MsgBox("修理受付日＞修理完了日エラー", MsgBoxStyle.Critical, "Error")
                Date3.Focus()
                Err_F = "1" : Exit Sub
            End If

            '出張料チェック

            '作業料チェック

            '部品料計チェック

            '値引き額チェック

            '請求除外金額チェック

            '請求額チェック
            'If CInt(Label13.Text) < 1 Then
            '    MsgBox("請求額がプラスになっていません", MsgBoxStyle.Critical, "Error")
            '    Number6.Focus()
            '    Err_F = "1" : Exit Sub
            'End If
            If Number5.Value < 1 Then
                MsgBox("請求額がプラスになっていません", MsgBoxStyle.Critical, "Error")
                Number5.Focus()
                Err_F = "1" : Exit Sub
            End If
            If CheckBox1.Checked = False Then   '限度額ﾁｪｯｸ
                If Trim(ComboBox4.SelectedValue) = "1" Then
                    'If CInt(Label9.Text) < CInt(Label13.Text) * 100 / 103 Then
                    If CInt(Label9.Text) < Number5.Value * 100 / 103 Then
                        MsgBox("修理限度額エラー", MsgBoxStyle.Critical, "Error")
                        Number5.Focus()
                        Err_F = "1" : Exit Sub
                    End If
                Else
                    'If CInt(Label9.Text) < CInt(Label13.Text) Then
                    If CInt(Label9.Text) < Number5.Value Then
                        MsgBox("修理限度額エラー", MsgBoxStyle.Critical, "Error")
                        Number5.Focus()
                        Err_F = "1" : Exit Sub
                    End If
                End If
            End If

            '見積額チェック

            '修理番号チェック
            If Trim(TextBox5.Text) = Nothing Then
                MsgBox("修理番号は入力必須", MsgBoxStyle.Critical, "Error")
                TextBox5.Focus()
                Err_F = "1" : Exit Sub
            End If

            '処理日チェック
            If Date4.Number = 0 Then
                MsgBox("処理日は入力必須", MsgBoxStyle.Critical, "Error")
                Date4.Focus()
                Err_F = "1" : Exit Sub
            Else
                If Date4.Text > Now.Date Then
                    MsgBox("処理日エラー(未来日付)", MsgBoxStyle.Critical, "Error")
                    Date4.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '掛種コードチェック
            DtView3 = New DataView(DsCMB.Tables("kakesyu"), "kakesyu='" & ComboBox12.SelectedValue & "'", "", DataViewRowState.CurrentRows)
            If DtView3.Count = 0 Then
                MsgBox("掛種コードエラー", MsgBoxStyle.Critical, "Error")
                ComboBox12.Focus()
                Err_F = "1" : Exit Sub
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT kakesyu FROM insurance_co_decision WHERE (kbn_No = '" & Label78.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("best_wrn")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "insurance_co_decision")
                DB_CLOSE()
                DtView3 = New DataView(WK_DsList1.Tables("insurance_co_decision"), "", "", DataViewRowState.CurrentRows)
                If DtView3.Count <> 0 Then
                    If ComboBox12.SelectedValue <> DtView3(0)("kakesyu") Then
                        MsgBox("掛種コードと期間区分の組合せエラー", MsgBoxStyle.Critical, "Error")
                        ComboBox12.Focus()
                        Err_F = "1" : Exit Sub
                    End If
                End If
            End If

            '取込処理日チェック
            If Date7.Number = 0 Then
                MsgBox("取込処理日は入力必須", MsgBoxStyle.Critical, "Error")
                Date7.Focus()
                Err_F = "1" : Exit Sub
            Else
                If Date7.Text > Now.Date Then
                    MsgBox("取込処理日エラー(未来日付)", MsgBoxStyle.Critical, "Error")
                    Date7.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

        Else                                    '取消

            '取消日チェック
            If Date5.Number = 0 Then
                MsgBox("取消日は入力必須", MsgBoxStyle.Critical, "Error")
                Date5.Focus()
                Err_F = "1" : Exit Sub
            Else
                If Date5.Text > Now.Date Then
                    MsgBox("取消日エラー(未来日付)", MsgBoxStyle.Critical, "Error")
                    Date5.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If
        End If

    End Sub

    '保証限度額
    Sub up_line(ByVal DT As Date)

        '2014/11/05 保証限度額対応(期間区分に依存せず税込商品価格とする) start
        If Trim(ComboBox2.SelectedValue) = "0" Then
            Label9.Text = Format(CInt(Label8.Text) + CInt(Label53.Text), "##,##0")
            '2014/11/05 保証限度額対応 end
        Else
            If DateAdd(DateInterval.Year, 1, DT) > Date1.Text Then  '1年以下
                Label9.Text = Format(CInt(Label8.Text) + CInt(Label53.Text), "##,##0")                                                          '消費税8%対応　2014/04/22
            Else
                If DateAdd(DateInterval.Year, 2, DT) > Date1.Text Then  '2年以下
                    Label9.Text = Format(Round((CInt(Label8.Text) + CInt(Label53.Text)) * 0.8, 0), "##,##0")                                    '消費税8%対応　2014/04/22
                Else
                    If DateAdd(DateInterval.Year, 3, DT) > Date1.Text Then  '3年以下
                        Label9.Text = Format(Round((CInt(Label8.Text) + CInt(Label53.Text)) * 0.6, 0), "##,##0")                                '消費税8%対応　2014/04/22
                    Else
                        If DateAdd(DateInterval.Year, 4, DT) > Date1.Text Then  '4年以下
                            Label9.Text = Format(Round((CInt(Label8.Text) + CInt(Label53.Text)) * 0.4, 0), "##,##0")                            '消費税8%対応　2014/04/22
                        Else
                            If DateAdd(DateInterval.Year, 5, DT) > Date1.Text Then  '5年以下
                                Label9.Text = Format(Round((CInt(Label8.Text) + CInt(Label53.Text)) * 0.2, 0), "##,##0")                        '消費税8%対応　2014/04/22
                            Else
                                Label9.Text = 0
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Sub A_YYYY(ByVal DT As Date)
        If DateAdd(DateInterval.Year, 1, DT) > Date1.Text Then  '1年以下
            Label80.Text = "0"
        Else
            If DateAdd(DateInterval.Year, 2, DT) > Date1.Text Then  '2年以下
                Label80.Text = "1"
            Else
                If DateAdd(DateInterval.Year, 3, DT) > Date1.Text Then  '3年以下
                    Label80.Text = "2"
                Else
                    If DateAdd(DateInterval.Year, 4, DT) > Date1.Text Then  '4年以下
                        Label80.Text = "3"
                    Else
                        If DateAdd(DateInterval.Year, 5, DT) > Date1.Text Then  '5年以下
                            Label80.Text = "4"
                        Else
                            Label80.Text = "9"
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Sub KbnNo() '期間区分
        Select Case Label82.Text
            Case Is = "1"
                Label78.Text = "S01"
                If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label78.Text)
                Exit Sub
            Case Is = "2"
                Label78.Text = "BS1"
                If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label78.Text)
                Exit Sub
            Case Is = "3"
                If Date2.Number <> 0 Then

                    If Label79.Text <> "1" Then   '個人   
                        If DateAdd(DateInterval.Year, 3, CDate(Label7.Text)) <= Date2.Text Then
                            Label78.Text = "BS1"
                            If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label78.Text)
                            If BR_date2 <> Date2.Text Then
                                BR_date2 = Date2.Text
                                MsgBox("ベスト引受分")
                            End If
                            Exit Sub
                        End If
                    End If
                End If
        End Select

        '** 臨時処理 2012/08/01
        If Label7.Text >= "2007/11/01" Then                 '購入日
            If Label50.Text <= "2007/10/31" Then            '申込日
                If Label49.Text = "A" Then                  'Ａ品種
                    If ComboBox2.SelectedValue >= "0" Then  '０：延長修理
                        If Date1.Text >= DateAdd(DateInterval.Year, 3, CDate(Label7.Text)) Then '修理受付日　購入日から３年超
                            Label78.Text = "BS1"
                            If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label78.Text)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If

        If Label79.Text <> "1" Then  '個人 、無料保証  
            DtView3 = New DataView(DsList1.Tables("insurance_co_sub"), "start_date <= '" & CDate(Label7.Text) & "' AND end_date >= '" & CDate(Label7.Text) & "' AND accident_flg = '" & Trim(ComboBox2.SelectedValue) & "' AND corp_flg = '0'", "", DataViewRowState.CurrentRows)
        Else                        '法人
            DtView3 = New DataView(DsList1.Tables("insurance_co_sub"), "start_date <= '" & CDate(Label7.Text) & "' AND end_date >= '" & CDate(Label7.Text) & "' AND accident_flg = '" & Trim(ComboBox2.SelectedValue) & "' AND corp_flg = '1' AND years_later = " & CInt(Label80.Text), "", DataViewRowState.CurrentRows)
        End If
        If DtView3.Count = 0 Then
            Label78.Text = Nothing
            ComboBox12.Text = Nothing : ComboBox12.Text = Nothing
        Else
            Label78.Text = DtView3(0)("kbn_No")
            If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label78.Text)
        End If

        '** 臨時処理 2012/08/31
        If Label79.Text = "0" Then  '個人  
            If Trim(ComboBox2.SelectedValue) = "2" Or Trim(ComboBox2.SelectedValue) = "4" Then  '火災・破損
                Select Case Label78.Text     '期間区分
                    Case Is = "BF1"
                        If Label50.Text >= "2012/02/01" Then
                            Label78.Text = Nothing
                            ComboBox12.Text = Nothing : ComboBox12.Text = Nothing
                        End If
                    Case Is = "F04"
                        If Label7.Text >= "2012/02/01" And Label7.Text < "2012/03/01" Then                '購入日
                            If Label50.Text >= "2012/02/01" Then
                                Label78.Text = Nothing
                                ComboBox12.Text = Nothing : ComboBox12.Text = Nothing
                            End If
                        End If
                End Select
            End If
        End If

    End Sub

    Sub kbn1()  '請求用画面
        Number1.Enabled = True      '請求番号
        ComboBox2.Enabled = True    '事故状況ﾌﾗｸﾞ
        TextBox3.Enabled = True     '修理品製造番号
        TextBox4.Enabled = True     '顧客名称(ｶﾅ)
        Date1.Enabled = True        '事故日
        ComboBox1.Enabled = True    '事故場所
        ComboBox4.Enabled = True    '全損ﾌﾗｸﾞ
        Number3.Enabled = True      '承認番号
        ComboBox3.Enabled = True    '項目有無ﾌﾗｸﾞ
        ComboBox6.Enabled = True    '修理受付店
        ComboBox7.Enabled = True    '修理完了店
        ComboBox8.Enabled = True    '伝票区分
        Edit5.Enabled = True        '修理伝票番号
        Edit2.Enabled = True        '電話番号
        Date2.Enabled = True        '修理受付日
        Date3.Enabled = True        '修理完了日
        If Label83.Text = "1" Then  '受信ﾃﾞｰﾀﾌﾗｸﾞ
            Number6.Enabled = False      '出張料
            Number7.Enabled = False      '作業料
            Number8.Enabled = False      '部品計料
            Number9.Enabled = False      '値引き額
            Number10.Enabled = False     '請求除外金額
            Number5.Enabled = False      '請求金額
            Number2.Enabled = False      '見積額
            'CheckBox1.Enabled = False    '限度内ﾁｪｯｸ
        Else
            Number6.Enabled = True      '出張料
            Number7.Enabled = True      '作業料
            Number8.Enabled = True      '部品計料
            Number9.Enabled = True      '値引き額
            Number10.Enabled = True     '請求除外金額
            Number5.Enabled = True      '請求金額
            Number2.Enabled = True      '見積額
            'CheckBox1.Enabled = True    '限度内ﾁｪｯｸ
        End If
        CheckBox1.Enabled = True    '限度内ﾁｪｯｸ
        CheckBox2.Enabled = True    '修理品製造番号不一致ﾁｪｯｸ

        TextBox5.Enabled = True     '修理番号
        Date4.Enabled = True        '処理日
        ComboBox12.Enabled = True   '掛種ｺｰﾄﾞ
        Date5.Enabled = False       '取消日
        Label21.Visible = False     '取消日
        Date5.Visible = False       '取消日
        Date7.Enabled = True        '取込処理日
    End Sub

    Sub kbn2()  '取消用画面
        Number1.Enabled = False     '請求番号
        ComboBox2.Enabled = False   '事故状況ﾌﾗｸﾞ
        TextBox3.Enabled = False    '修理品製造番号
        TextBox4.Enabled = False    '顧客名称(ｶﾅ)
        Date1.Enabled = False       '事故日
        ComboBox1.Enabled = False   '事故場所
        ComboBox4.Enabled = False   '全損ﾌﾗｸﾞ
        Number3.Enabled = False     '承認番号
        ComboBox3.Enabled = False   '項目有無ﾌﾗｸﾞ
        ComboBox6.Enabled = False   '修理受付店
        ComboBox7.Enabled = False   '修理完了店
        ComboBox8.Enabled = False   '伝票区分
        Edit5.Enabled = False       '修理伝票番号
        Edit2.Enabled = False       '電話番号
        Date2.Enabled = False       '修理受付日
        Date3.Enabled = False       '修理完了日
        Number6.Enabled = False     '出張料
        Number7.Enabled = False     '作業料
        Number8.Enabled = False     '部品計料
        Number9.Enabled = False     '値引き額
        Number10.Enabled = False    '請求除外金額
        Number5.Enabled = False     '請求金額
        Number2.Enabled = False     '見積額
        CheckBox1.Enabled = False   '限度内ﾁｪｯｸ
        CheckBox2.Enabled = False   '修理品製造番号不一致ﾁｪｯｸ
        TextBox5.Enabled = False    '修理番号
        Date4.Enabled = False       '処理日
        ComboBox12.Enabled = False  '掛種ｺｰﾄﾞ
        Date5.Enabled = True        '取消日
        Label21.Visible = True      '取消日
        Date5.Visible = True        '取消日
        Date7.Enabled = False       '取込処理日
    End Sub

    '入力後
    Private Sub Date6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date6.Leave
        Label71.Text = Mid(Date6.Text, 1, 4) & "/" & Mid(Date6.Text, 6, 2) & "/20"

        If Label71.Text <= Label73.Text Then
            Label64.Text = "受信データの締め処理は完了しています。"
        Else
            Label64.Text = Nothing
        End If
        If Label71.Text <= Label74.Text Then
            Label65.Text = "手入力データの締め処理は完了しています。"
        Else
            Label65.Text = Nothing
        End If
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox11.SelectedIndexChanged
        If Mid(ComboBox11.Text, 1, 1) = "2" Then
            Call kbn2()
        Else
            Call kbn1()
        End If
    End Sub

    Private Sub Date1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.Leave
        If Date1.Number <> 0 Then
            If Label7.Text <> Nothing Then
                'If Label79.Text = "1" Then
                Call A_YYYY(Label7.Text)        '加入後の期間
                Call KbnNo()                    '期間区分
                Call up_line(Label7.Text)       '保証限度額
                'End If
            End If
        End If
    End Sub

    Private Sub Date2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.Leave
        If Date2.Number <> 0 Then
            If Label7.Text <> Nothing Then
                'If Label79.Text = "1" Then
                Call KbnNo()                    '期間区分
                'End If
            End If
        End If
    End Sub

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        If Label7.Text <> Nothing Then
            Call KbnNo()                    '期間区分
            Call up_line(Label7.Text)       '保証限度額
        End If
    End Sub

    Private Sub Number6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number6.Leave
        Call TTL()
    End Sub

    Private Sub Number7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number7.Leave
        Call TTL()
    End Sub

    Private Sub Number8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number8.Leave
        Call TTL()
    End Sub

    Private Sub Number9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number9.Leave
        Call TTL()
    End Sub

    Private Sub Number10_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number10.Leave
        Call TTL()
    End Sub

    Sub TTL()
        Label13.Text = Format(Number6.Value + Number7.Value + Number8.Value - Number9.Value - Number10.Value, "##,##0")
        Number5.Value = Format(Number6.Value + Number7.Value + Number8.Value - Number9.Value - Number10.Value, "##,##0")
    End Sub

    Sub P_Set()
        P_close_date = Label71.Text

        P_01 = Nothing
        P_02 = Number1.Value
        P_03 = Edit1.Text
        P_04 = Format(Number3.Value, "0000")
        P_05 = Nothing
        If Date1.Number <> 0 Then
            P_05_date = Date1.Text
        Else
            P_05_date = Nothing
        End If
        P_06 = Trim(ComboBox1.SelectedValue)
        P_07 = Trim(ComboBox2.SelectedValue)
        P_08 = Trim(ComboBox3.SelectedValue)
        P_09 = Trim(ComboBox4.SelectedValue)
        P_10 = Trim(Label60.Text)
        P_11 = Trim(ComboBox6.SelectedValue)
        P_12 = Trim(ComboBox7.SelectedValue)
        P_13 = Trim(ComboBox8.SelectedValue)
        P_14 = Edit5.Text
        P_15 = Edit4.Text
        P_16 = Edit2.Text
        P_17 = Trim(Label61.Text)
        P_18 = Trim(Label62.Text)
        P_19 = Edit3.Text
        P_20 = TextBox3.Text
        P_21 = Nothing
        If Date2.Number <> 0 Then
            P_21_date = Date2.Text
        Else
            P_21_date = Nothing
        End If
        P_22 = Nothing
        If Date3.Number <> 0 Then
            P_22_date = Date3.Text
        Else
            P_22_date = Nothing
        End If
        P_23 = Number6.Value
        P_24 = Number7.Value
        P_25 = Number8.Value
        P_26 = Number9.Value
        P_27 = Number10.Value
        'P_28 = CInt(Label13.Text)
        P_28 = Number5.Value
        P_29 = Number2.Value
        P_30 = TextBox5.Text
        P_31 = Nothing
        If Date4.Number <> 0 Then
            P_31_date = Date4.Text
        Else
            P_31_date = Nothing
        End If
        P_32 = Trim(ComboBox11.SelectedValue)
        P_33 = Trim(ComboBox12.SelectedValue)
        P_34 = Nothing
    End Sub

    '**********************************
    '登録ボタン（請求データ）
    '**********************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Call DspChk2()

        '2014/11/05 加入情報の顧客名（姓）登録なしデータも登録可に変更 start
        If namedif_f = True Then
            str_ANS = MsgBox("顧客名称が加入情報と異なります。よろしいですか？", MsgBoxStyle.OkCancel, "確認")
            If str_ANS = DialogResult.Cancel Then
                Me.Cursor = System.Windows.Forms.Cursors.Default
                TextBox4.Focus()
                Exit Sub
            End If
        End If
        '2014/11/05 加入情報の顧客名（姓）登録なしデータも登録可に変更 end

        If Err_F = "0" Then
            If Button1.Text = "登録" Then
                strSQL = "INSERT INTO Wrn_ivc"
                strSQL += " (ordr_no, line_no, seq, FLD002, FLD004, FLD005, FLD006, FLD007, FLD008"
                strSQL += ", FLD009, FLD010, FLD011, FLD012, FLD013, FLD014, FLD015, FLD016, FLD017"
                strSQL += ", FLD018, FLD019, FLD020, FLD021, FLD022, FLD023, FLD024, FLD025, FLD026"
                strSQL += ", FLD027, FLD028, FLD029, FLD030, FLD031, FLD032, FLD033, FLD034"
                strSQL += ", trbl_code, trbl_memo, rpar_mome, Remarks"
                strSQL += ", kbn_No, Limit_money, Cancel_flg"
                strSQL += ", close_flg, seq_sub, close_date, inp_seq, Limit_money_off, FLD020_off"
                strSQL += ", BY_cls, entry_flg, buy_BY_cls, ent_BY_cls, fin_BY_cls, pos_code, imp_date)"
                strSQL += " VALUES ('" & Edit1.Text & "'"
                strSQL += ", '" & Label15.Text & "'"
                strSQL += ", " & Label17.Text & ""
                strSQL += ", N'" & Format(Number1.Value, "000000") & "'"
                strSQL += ", N'" & Format(Number3.Value, "0000") & "'"
                strSQL += ", '" & Date1.Text & "'"
                strSQL += ", N'" & Trim(ComboBox1.SelectedValue) & "'"
                strSQL += ", N'" & Trim(ComboBox2.SelectedValue) & "'"
                strSQL += ", N'" & Trim(ComboBox3.SelectedValue) & "'"
                strSQL += ", N'" & Trim(ComboBox4.SelectedValue) & "'"
                strSQL += ", N'" & Trim(Label60.Text) & "'"
                strSQL += ", N'" & Trim(ComboBox6.SelectedValue) & "'"
                strSQL += ", N'" & Trim(ComboBox7.SelectedValue) & "'"
                '2014/08/01 SQL見直し対応 start
                '                strSQL += ", '" & ComboBox8.SelectedValue & "'"
                strSQL += ", '" & Trim(ComboBox8.SelectedValue) & "'"
                '2014/08/01 SQL見直し対応 end
                strSQL += ", N'" & Edit5.Text & "'"
                strSQL += ", '" & TextBox4.Text & "'"
                strSQL += ", '" & Edit2.Text & "'"
                strSQL += ", N'" & Trim(Label61.Text) & "'"
                strSQL += ", N'" & Trim(Label62.Text) & "'"
                strSQL += ", '" & Edit3.Text & "'"
                strSQL += ", '" & TextBox3.Text & "'"
                strSQL += ", '" & Date2.Text & "'"
                strSQL += ", '" & Date3.Text & "'"
                strSQL += ", " & Number6.Value & ""
                strSQL += ", " & Number7.Value & ""
                strSQL += ", " & Number8.Value & ""
                strSQL += ", " & Number9.Value & ""
                strSQL += ", " & Number10.Value & ""
                strSQL += ", " & Number5.Value & ""
                strSQL += ", " & Number2.Value & ""
                strSQL += ", '" & TextBox5.Text & "'"
                strSQL += ", '" & Date4.Text & "'"
                strSQL += ", N'" & Trim(ComboBox11.SelectedValue) & "'"
                strSQL += ", '" & ComboBox12.SelectedValue & "'"
                strSQL += ", '    '"
                If P_trbl_code <> Nothing Then
                    strSQL += ", '" & P_trbl_code & "'"
                Else
                    strSQL += ", ' '"
                End If
                strSQL += ", '" & P_trbl_memo & "'"
                strSQL += ", '" & P_rpar_mome & "'"
                strSQL += ", '" & P_Remarks & "'"
                strSQL += ", '" & Label78.Text & "'"
                strSQL += ", " & CInt(Label9.Text) & ""
                strSQL += ", '0'"
                strSQL += ", '0'"
                strSQL += ", 1"
                strSQL += ", CONVERT(DATETIME, '" & Label71.Text & "', 102)"
                strSQL += ", " & Count_Get("004") & ""
                If CheckBox1.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                If CheckBox2.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                strSQL += ", '" & Label51.Text & "'"
                strSQL += ", '00'"
                strSQL += ", '" & Label51.Text & "'"
                strSQL += ", '" & Label55.Text & "'"
                strSQL += ", '" & Label66.Text & "'"
                strSQL += ", ''"
                strSQL += ", '" & Date7.Text & "'"
                strSQL += ")"

                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                If Trim(ComboBox4.SelectedValue) = "1" Then '全損
                    If Label17.Text <> "0" Then             '新データ
                        strSQL = "UPDATE Wrn_sub"
                        strSQL += " SET total_loss_flg = '1'"
                        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                        strSQL += " AND (line_no = '" & Label15.Text & "')"
                        strSQL += " AND (seq = " & Label17.Text & ")"
                        strSQL += " AND (total_loss_flg IS NULL)"
                        DB_OPEN("best_wrn")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        strSQL = "INSERT INTO total_loss"
                        strSQL += " (ordr_no, line_no, seq, total_loss_date)"
                        strSQL += " VALUES ('" & Edit1.Text & "'"
                        strSQL += ", '" & Label15.Text & "'"
                        strSQL += ", " & Label17.Text & ""
                        strSQL += ", '" & Date4.Text & "')"
                        DB_OPEN("best_wrn")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    Else                                    '旧データ
                        strSQL = "UPDATE Wrn_data"
                        strSQL += " SET total_loss_flg = '1'"
                        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                        strSQL += " AND (line_no = '" & Label15.Text & "')"
                        strSQL += " AND (total_loss_flg IS NULL OR total_loss_flg = '0')"
                        DB_OPEN("best_wrn_data2")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        strSQL = "INSERT INTO total_loss"
                        strSQL += " (ordr_no, line_no, total_loss_date)"
                        strSQL += " VALUES ('" & Edit1.Text & "'"
                        strSQL += ", '" & Label15.Text & "'"
                        strSQL += ", '" & Date4.Text & "')"
                        DB_OPEN("best_wrn_data2")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                End If
                MsgBox("登録しました。", , "")

            Else    '修正

                If Mid(ComboBox11.Text, 1, 1) = "1" Then    '請求
                    strSQL = "UPDATE Wrn_ivc"
                    strSQL += " SET FLD002 = N'" & Format(Number1.Value, "000000") & "'"
                    strSQL += ", FLD004 = N'" & Format(Number3.Value, "0000") & "'"
                    strSQL += ", FLD005 = '" & Date1.Text & "'"
                    strSQL += ", FLD006 = N'" & Trim(ComboBox1.SelectedValue) & "'"
                    strSQL += ", FLD007 = N'" & Trim(ComboBox2.SelectedValue) & "'"
                    strSQL += ", FLD008 = N'" & Trim(ComboBox3.SelectedValue) & "'"
                    strSQL += ", FLD009 = N'" & Trim(ComboBox4.SelectedValue) & "'"
                    strSQL += ", FLD010 = N'" & Trim(Label60.Text) & "'"
                    strSQL += ", FLD011 = N'" & Trim(ComboBox6.SelectedValue) & "'"
                    strSQL += ", FLD012 = N'" & Trim(ComboBox7.SelectedValue) & "'"
                    '2014/08/01 SQL見直し対応 start
                    '                    strSQL += ", FLD013 = '" & ComboBox8.SelectedValue & "'"
                    strSQL += ", FLD013 = '" & Trim(ComboBox8.SelectedValue) & "'"
                    '2014/08/01 SQL見直し対応 end
                    strSQL += ", FLD014 = N'" & Edit5.Text & "'"
                    strSQL += ", FLD015 = '" & TextBox4.Text & "'"
                    strSQL += ", FLD016 = '" & Edit2.Text & "'"
                    strSQL += ", FLD017 = N'" & Trim(Label61.Text) & "'"
                    strSQL += ", FLD018 = N'" & Trim(Label62.Text) & "'"
                    strSQL += ", FLD019 = '" & Edit3.Text & "'"
                    strSQL += ", FLD020 = '" & TextBox3.Text & "'"
                    strSQL += ", FLD021 = '" & Date2.Text & "'"
                    strSQL += ", FLD022 = '" & Date3.Text & "'"
                    strSQL += ", FLD023 = " & Number6.Value & ""
                    strSQL += ", FLD024 = " & Number7.Value & ""
                    strSQL += ", FLD025 = " & Number8.Value & ""
                    strSQL += ", FLD026 = " & Number9.Value & ""
                    strSQL += ", FLD027 = " & Number10.Value & ""
                    strSQL += ", FLD028 = " & Number5.Value & ""
                    strSQL += ", FLD029 = " & Number2.Value & ""
                    strSQL += ", FLD030 = '" & TextBox5.Text & "'"
                    strSQL += ", FLD031 = '" & Date4.Text & "'"
                    strSQL += ", FLD032 = N'" & Trim(ComboBox11.SelectedValue) & "'"
                    strSQL += ", FLD033 = '" & ComboBox12.SelectedValue & "'"
                    If P_trbl_code <> Nothing Then
                        strSQL += ", trbl_code = '" & P_trbl_code & "'"
                    Else
                        strSQL += ", trbl_code = ' '"
                    End If
                    strSQL += ", trbl_memo = '" & P_trbl_memo & "'"
                    strSQL += ", rpar_mome = '" & P_rpar_mome & "'"
                    strSQL += ", Remarks = '" & P_Remarks & "'"

                    strSQL += ", kbn_No = '" & Label78.Text & "'"
                    strSQL += ", Limit_money = '" & CInt(Label9.Text) & "'"
                    strSQL += ", Cancel_flg = '0'"
                    strSQL += ", Cancel_date = NULL"
                    If CheckBox1.Checked = True Then strSQL += ", Limit_money_off = 1" Else strSQL += ", Limit_money_off = 0"
                    If CheckBox2.Checked = True Then strSQL += ", FLD020_off = 1" Else strSQL += ", FLD020_off = 0"
                    strSQL += ", BY_cls = '" & Label51.Text & "'"
                    strSQL += ", entry_flg = '00'"
                    strSQL += ", buy_BY_cls = '" & Label51.Text & "'"
                    strSQL += ", ent_BY_cls = '" & Label55.Text & "'"
                    strSQL += ", fin_BY_cls = '" & Label66.Text & "'"
                    strSQL += ", pos_code = ''"
                    strSQL += ", imp_date = '" & Date7.Text & "'"
                    strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                    strSQL += " AND (line_no = '" & Label15.Text & "')"
                    strSQL += " AND (seq = " & Label17.Text & ")"
                    strSQL += " AND (close_date = CONVERT(DATETIME, '" & Label71.Text & "', 102))"   '同一締め内
                    DB_OPEN("best_wrn")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    If Trim(ComboBox4.SelectedValue) = "1" Then '全損
                        If Label17.Text <> "0" Then             '新データ
                            strSQL = "UPDATE Wrn_sub"
                            strSQL += " SET total_loss_flg = '1'"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                            strSQL += " AND (line_no = '" & Label15.Text & "')"
                            strSQL += " AND (seq = " & Label17.Text & ")"
                            strSQL += " AND (total_loss_flg IS NULL)"
                            DB_OPEN("best_wrn")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            WK_DsList1.Clear()
                            strSQL = "SELECT ordr_no, line_no, seq FROM total_loss"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "') AND (line_no = '" & Label15.Text & "') AND (seq = " & Label17.Text & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("best_wrn")
                            SqlCmd1.CommandTimeout = 600
                            DaList1.Fill(WK_DsList1, "total_loss")
                            DB_CLOSE()
                            DtView1 = New DataView(WK_DsList1.Tables("total_loss"), "", "", DataViewRowState.CurrentRows)
                            If DtView1.Count = 0 Then
                                strSQL = "INSERT INTO total_loss"
                                strSQL += " (ordr_no, line_no, seq, total_loss_date)"
                                strSQL += " VALUES ('" & Edit1.Text & "'"
                                strSQL += ", '" & Label15.Text & "'"
                                strSQL += ", " & Label17.Text & ""
                                strSQL += ", '" & Date4.Text & "')"
                                DB_OPEN("best_wrn")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()
                            Else
                                strSQL = "UPDATE total_loss"
                                strSQL += " SET total_loss_date = '" & Date4.Text & "'"
                                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "') AND (line_no = '" & Label15.Text & "') AND (seq = " & Label17.Text & ")"
                                DB_OPEN("best_wrn")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()
                            End If
                        Else                                    '旧データ
                            strSQL = "UPDATE Wrn_data"
                            strSQL += " SET total_loss_flg = '1'"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                            strSQL += " AND (line_no = '" & Label15.Text & "')"
                            strSQL += " AND (total_loss_flg IS NULL OR total_loss_flg = '0')"
                            DB_OPEN("best_wrn_data2")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            WK_DsList1.Clear()
                            strSQL = "SELECT ordr_no, line_no FROM total_loss"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "') AND (line_no = '" & Label15.Text & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("best_wrn_data2")
                            SqlCmd1.CommandTimeout = 600
                            DaList1.Fill(WK_DsList1, "total_loss")
                            DB_CLOSE()
                            DtView1 = New DataView(WK_DsList1.Tables("total_loss"), "", "", DataViewRowState.CurrentRows)
                            If DtView1.Count = 0 Then
                                strSQL = "INSERT INTO total_loss"
                                strSQL += " (ordr_no, line_no, total_loss_date)"
                                strSQL += " VALUES ('" & Edit1.Text & "'"
                                strSQL += ", '" & Label15.Text & "'"
                                strSQL += ", '" & Date4.Text & "')"
                                DB_OPEN("best_wrn_data2")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()
                            Else
                                strSQL = "UPDATE total_loss"
                                strSQL += " SET total_loss_date = '" & Date4.Text & "'"
                                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "') AND (line_no = '" & Label15.Text & "')"
                                DB_OPEN("best_wrn_data2")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()
                            End If
                        End If
                    Else                                        '修理
                        If Label17.Text <> "0" Then             '新データ
                            strSQL = "UPDATE Wrn_sub"
                            strSQL += " SET total_loss_flg = NULL"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                            strSQL += " AND (line_no = '" & Label15.Text & "')"
                            strSQL += " AND (seq = " & Label17.Text & ")"
                            strSQL += " AND (total_loss_flg IS NOT NULL)"
                            DB_OPEN("best_wrn")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            strSQL = "DELETE FROM total_loss"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                            strSQL += " AND (line_no = '" & Label15.Text & "')"
                            strSQL += " AND (seq = " & Label17.Text & ")"
                            DB_OPEN("best_wrn")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()
                        Else                                    '旧データ
                            strSQL = "UPDATE Wrn_data"
                            strSQL += " SET total_loss_flg = NULL"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                            strSQL += " AND (line_no = '" & Label15.Text & "')"
                            strSQL += " AND (total_loss_flg IS NOT NULL)"
                            DB_OPEN("best_wrn_data2")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            strSQL = "DELETE FROM total_loss"
                            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                            strSQL += " AND (line_no = '" & Label15.Text & "')"
                            DB_OPEN("best_wrn_data2")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()
                        End If
                    End If

                Else                                        '取消
                    strSQL = "UPDATE Wrn_ivc"
                    strSQL += " SET Cancel_flg = '1'"
                    strSQL += ", Cancel_date = '" & Date5.Text & "'"
                    strSQL += ", FLD032  = N'" & Trim(ComboBox11.SelectedValue) & "'"
                    strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                    strSQL += " AND (line_no = '" & Label15.Text & "')"
                    strSQL += " AND (seq = " & Label17.Text & ")"
                    strSQL += " AND (close_date = CONVERT(DATETIME, '" & Label71.Text & "', 102))"   '同一締め内
                    DB_OPEN("best_wrn")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    If Label17.Text <> "0" Then             '新データ
                        strSQL = "UPDATE Wrn_sub"
                        strSQL += " SET total_loss_flg = NULL"
                        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                        strSQL += " AND (line_no = '" & Label15.Text & "')"
                        strSQL += " AND (seq = " & Label17.Text & ")"
                        strSQL += " AND (total_loss_flg IS NOT NULL)"
                        DB_OPEN("best_wrn")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        strSQL = "DELETE FROM total_loss"
                        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                        strSQL += " AND (line_no = '" & Label15.Text & "')"
                        strSQL += " AND (seq = " & Label17.Text & ")"
                        DB_OPEN("best_wrn")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    Else                                    '旧データ
                        strSQL = "UPDATE Wrn_data"
                        strSQL += " SET total_loss_flg = NULL"
                        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                        strSQL += " AND (line_no = '" & Label15.Text & "')"
                        strSQL += " AND (total_loss_flg IS NOT NULL)"
                        DB_OPEN("best_wrn_data2")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        strSQL = "DELETE FROM total_loss"
                        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                        strSQL += " AND (line_no = '" & Label15.Text & "')"
                        DB_OPEN("best_wrn_data2")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If

                End If
                MsgBox("修正しました。", , "")
            End If

            Button1.Text = "登録"
            Button3_Click(sender, e)
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '検索ボタン
    '**********************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call DspChk1()
        If Err_F = "0" Then
            If DtView1.Count = 1 Then
                Call DspSet1(0)
            Else
                'Me.Hide()
                Dim Form2 As New Form2
                Form2.ShowDialog()
                'Me.Show()

                If P_rtn = "9" Then Me.Cursor = System.Windows.Forms.Cursors.Default : Exit Sub
                DtView1 = New DataView(P_DsList1.Tables("Wrn"), "ordr_no = '" & P_PRAM1 & "' AND line_no = '" & P_PRAM2 & "' AND seq =" & P_PRAM3, "", DataViewRowState.CurrentRows)
                Call DspSet1(0)
            End If
            Edit1.ReadOnly = True : Edit1.TabStop = False '保証番号
            Edit3.ReadOnly = True : Edit3.TabStop = False '型式
            Edit4.ReadOnly = True : Edit4.TabStop = False '顧客名称(ｶﾅ)
            Date6.ReadOnly = True : Date6.TabStop = False '処理日

            ComboBox2.Focus()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Label64_Click(sender As Object, e As EventArgs) Handles Label64.Click

    End Sub

    '**********************************
    'クリアボタン
    '**********************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call DspClr1()
        Edit1.Focus()
    End Sub

    '**********************************
    '削除ボタン
    '**********************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        str_ANS = MsgBox("削除します。よろしいですか？", MsgBoxStyle.OKCancel, "確認")
        If str_ANS = "1" Then   'OK
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            strSQL = "DELETE FROM Wrn_ivc"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (line_no = '" & Label15.Text & "')"
            strSQL += " AND (seq = " & Label17.Text & ")"
            strSQL += " AND (close_date = CONVERT(DATETIME, '" & Label71.Text & "', 102))"   '同一締め内
            DB_OPEN("best_wrn")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            '全損だったら戻す
            If Label17.Text <> "0" Then             '新データ
                strSQL = "UPDATE Wrn_sub"
                strSQL += " SET total_loss_flg = NULL"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Label15.Text & "')"
                strSQL += " AND (seq = " & Label17.Text & ")"
                strSQL += " AND (total_loss_flg IS NOT NULL)"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "DELETE FROM total_loss"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Label15.Text & "')"
                strSQL += " AND (seq = " & Label17.Text & ")"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Else                                    '旧データ
                strSQL = "UPDATE Wrn_data"
                strSQL += " SET total_loss_flg = NULL"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Label15.Text & "')"
                strSQL += " AND (total_loss_flg IS NOT NULL)"
                DB_OPEN("best_wrn_data2")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "DELETE FROM total_loss"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (line_no = '" & Label15.Text & "')"
                DB_OPEN("best_wrn_data2")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            End If

            MsgBox("削除しました。", MsgBoxStyle.Information, "")
            Call Button3_Click(sender, e)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    '**********************************
    '故障状況入力ボタン
    '**********************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Form3 As New Form3
        Form3.ShowDialog()
    End Sub

    '**********************************
    '終了ボタン
    '**********************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        objMutex.Close()
        Application.Exit()
    End Sub

    'Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
    '    Label53.Text = "B"
    'End Sub
    'Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
    '    Label53.Text = "Y"
    'End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Label55.Text = "B"
        If inz_F = "1" Then CmbSet6() : ComboBox6.Text = Nothing
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Label55.Text = "Y"
        If inz_F = "1" Then CmbSet6() : ComboBox6.Text = Nothing
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Label66.Text = "B"
        If inz_F = "1" Then CmbSet7() : ComboBox7.Text = Nothing
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        Label66.Text = "Y"
        If inz_F = "1" Then CmbSet7() : ComboBox7.Text = Nothing
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub
End Class