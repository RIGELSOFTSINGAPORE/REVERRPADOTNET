Public Class Form3
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, DtView3 As DataView
    Dim WK_DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim inz_F As String = "0"

    Dim Dataadp1 As New SqlClient.SqlDataAdapter
    Dim Dataadp2 As New SqlClient.SqlDataAdapter
    Dim Dataadp3 As New SqlClient.SqlDataAdapter
    Dim Dataadp4 As New SqlClient.SqlDataAdapter
    Dim Dataadp5 As New SqlClient.SqlDataAdapter
    Dim Dataadp6 As New SqlClient.SqlDataAdapter
    Dim Dataadp7 As New SqlClient.SqlDataAdapter
    Dim Dataadp8 As New SqlClient.SqlDataAdapter
    Dim Dataadp9 As New SqlClient.SqlDataAdapter
    Dim Dataadp10 As New SqlClient.SqlDataAdapter
    Dim Dataadp11 As New SqlClient.SqlDataAdapter
    Dim Dataset1 As New DataSet
    Dim Dttbl1, Dttbl11 As DataTable
    Dim r, r2, get_no, upd_no As Integer
    Dim clm_flg, fst_empl_code, icdt_no, fin_flg, upd_flg, head_ltr As String
    Dim s_date, e_date As Date
    Dim Now_date As Date
    Dim label(999, 50) As label
    Dim txtbox(999, 50) As TextBox

    Dim line_no, en, i, i2 As Integer
    Dim LEAVE_CHG As String

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1_17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents T_ComboBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents ComboBox12 As System.Windows.Forms.ComboBox
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents ComboBox11 As System.Windows.Forms.ComboBox
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents ComboBox10 As System.Windows.Forms.ComboBox
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label3_4 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label3_3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3_4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3_3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label3_2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox3_2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3_1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents T_ComboBox19 As System.Windows.Forms.TextBox
    Friend WithEvents T_ComboBox17 As System.Windows.Forms.TextBox
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Date4 As GrapeCity.Win.Input.Date
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents ComboBox18 As System.Windows.Forms.ComboBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_4 As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_6 As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_3 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4_1 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_1 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Edit1_6 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_7 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_9 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_10 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_18 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_11 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_12 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_13 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_14 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_15 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_21 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_2_0 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_2_1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_2_2 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_3 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit1_4 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit50 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3_5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form3))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button11 = New System.Windows.Forms.Button
        Me.Label47 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Edit50 = New GrapeCity.Win.Input.Edit
        Me.Edit1_4 = New GrapeCity.Win.Input.Edit
        Me.Edit1_3 = New GrapeCity.Win.Input.Edit
        Me.Edit1_2_2 = New GrapeCity.Win.Input.Edit
        Me.Edit1_2_1 = New GrapeCity.Win.Input.Edit
        Me.Edit1_2_0 = New GrapeCity.Win.Input.Edit
        Me.Edit1_1 = New GrapeCity.Win.Input.Edit
        Me.Edit1_21 = New GrapeCity.Win.Input.Edit
        Me.Edit1_15 = New GrapeCity.Win.Input.Edit
        Me.Label126 = New System.Windows.Forms.Label
        Me.Edit1_14 = New GrapeCity.Win.Input.Edit
        Me.Edit1_13 = New GrapeCity.Win.Input.Edit
        Me.Edit1_12 = New GrapeCity.Win.Input.Edit
        Me.Edit1_11 = New GrapeCity.Win.Input.Edit
        Me.Edit1_18 = New GrapeCity.Win.Input.Edit
        Me.Label59 = New System.Windows.Forms.Label
        Me.Edit1_10 = New GrapeCity.Win.Input.Edit
        Me.Edit1_9 = New GrapeCity.Win.Input.Edit
        Me.Edit1_7 = New GrapeCity.Win.Input.Edit
        Me.Edit1_6 = New GrapeCity.Win.Input.Edit
        Me.Label105 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1_17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Edit5 = New GrapeCity.Win.Input.Edit
        Me.Label30 = New System.Windows.Forms.Label
        Me.Edit4 = New GrapeCity.Win.Input.Edit
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox3_5 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.T_ComboBox5 = New System.Windows.Forms.TextBox
        Me.Label142 = New System.Windows.Forms.Label
        Me.Label141 = New System.Windows.Forms.Label
        Me.Label140 = New System.Windows.Forms.Label
        Me.Label139 = New System.Windows.Forms.Label
        Me.Label138 = New System.Windows.Forms.Label
        Me.Label137 = New System.Windows.Forms.Label
        Me.Label136 = New System.Windows.Forms.Label
        Me.Label134 = New System.Windows.Forms.Label
        Me.Label131 = New System.Windows.Forms.Label
        Me.Label124 = New System.Windows.Forms.Label
        Me.Label123 = New System.Windows.Forms.Label
        Me.Label122 = New System.Windows.Forms.Label
        Me.ComboBox12 = New System.Windows.Forms.ComboBox
        Me.Label106 = New System.Windows.Forms.Label
        Me.Label107 = New System.Windows.Forms.Label
        Me.ComboBox11 = New System.Windows.Forms.ComboBox
        Me.Label108 = New System.Windows.Forms.Label
        Me.Label109 = New System.Windows.Forms.Label
        Me.ComboBox10 = New System.Windows.Forms.ComboBox
        Me.Label110 = New System.Windows.Forms.Label
        Me.ComboBox9 = New System.Windows.Forms.ComboBox
        Me.Label111 = New System.Windows.Forms.Label
        Me.ComboBox8 = New System.Windows.Forms.ComboBox
        Me.ComboBox7 = New System.Windows.Forms.ComboBox
        Me.Label112 = New System.Windows.Forms.Label
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.Label113 = New System.Windows.Forms.Label
        Me.Label114 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label115 = New System.Windows.Forms.Label
        Me.Label117 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.RadioButton8 = New System.Windows.Forms.RadioButton
        Me.RadioButton9 = New System.Windows.Forms.RadioButton
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label3_4 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label3_3 = New System.Windows.Forms.Label
        Me.ComboBox3_4 = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.ComboBox3_3 = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label3_2 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.ComboBox3_2 = New System.Windows.Forms.ComboBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3_1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.T_ComboBox19 = New System.Windows.Forms.TextBox
        Me.T_ComboBox17 = New System.Windows.Forms.TextBox
        Me.Label120 = New System.Windows.Forms.Label
        Me.Label104 = New System.Windows.Forms.Label
        Me.Date4 = New GrapeCity.Win.Input.Date
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label70 = New System.Windows.Forms.Label
        Me.Label69 = New System.Windows.Forms.Label
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label66 = New System.Windows.Forms.Label
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label64 = New System.Windows.Forms.Label
        Me.Label63 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.ComboBox18 = New System.Windows.Forms.ComboBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.Label57 = New System.Windows.Forms.Label
        Me.TextBox4_4 = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Edit3 = New GrapeCity.Win.Input.Edit
        Me.Label54 = New System.Windows.Forms.Label
        Me.Edit2 = New GrapeCity.Win.Input.Edit
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label44 = New System.Windows.Forms.Label
        Me.TextBox4_6 = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.TextBox4_3 = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TextBox4_2 = New System.Windows.Forms.TextBox
        Me.Label4_1 = New System.Windows.Forms.Label
        Me.TextBox4_1 = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Edit01 = New GrapeCity.Win.Input.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Edit
        Me.TabPage1.SuspendLayout()
        CType(Me.Edit50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_2_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_2_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_2_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1_6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(4, 504)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(920, 3)
        Me.PictureBox1.TabIndex = 143
        Me.PictureBox1.TabStop = False
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(808, 512)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(96, 30)
        Me.Button11.TabIndex = 9
        Me.Button11.Text = "戻　る"
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label47.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(332, 4)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(264, 28)
        Me.Label47.TabIndex = 199
        Me.Label47.Text = "MrMax 安心5年保証"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Edit50)
        Me.TabPage1.Controls.Add(Me.Edit1_4)
        Me.TabPage1.Controls.Add(Me.Edit1_3)
        Me.TabPage1.Controls.Add(Me.Edit1_2_2)
        Me.TabPage1.Controls.Add(Me.Edit1_2_1)
        Me.TabPage1.Controls.Add(Me.Edit1_2_0)
        Me.TabPage1.Controls.Add(Me.Edit1_1)
        Me.TabPage1.Controls.Add(Me.Edit1_21)
        Me.TabPage1.Controls.Add(Me.Edit1_15)
        Me.TabPage1.Controls.Add(Me.Label126)
        Me.TabPage1.Controls.Add(Me.Edit1_14)
        Me.TabPage1.Controls.Add(Me.Edit1_13)
        Me.TabPage1.Controls.Add(Me.Edit1_12)
        Me.TabPage1.Controls.Add(Me.Edit1_11)
        Me.TabPage1.Controls.Add(Me.Edit1_18)
        Me.TabPage1.Controls.Add(Me.Label59)
        Me.TabPage1.Controls.Add(Me.Edit1_10)
        Me.TabPage1.Controls.Add(Me.Edit1_9)
        Me.TabPage1.Controls.Add(Me.Edit1_7)
        Me.TabPage1.Controls.Add(Me.Edit1_6)
        Me.TabPage1.Controls.Add(Me.Label105)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.Label52)
        Me.TabPage1.Controls.Add(Me.Label49)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label1_17)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(896, 455)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "基本情報"
        '
        'Edit50
        '
        Me.Edit50.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit50.Location = New System.Drawing.Point(520, 48)
        Me.Edit50.Name = "Edit50"
        Me.Edit50.ReadOnly = True
        Me.Edit50.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit50.Size = New System.Drawing.Size(280, 23)
        Me.Edit50.TabIndex = 11
        Me.Edit50.Text = "Edit50"
        '
        'Edit1_4
        '
        Me.Edit1_4.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_4.Location = New System.Drawing.Point(520, 244)
        Me.Edit1_4.Name = "Edit1_4"
        Me.Edit1_4.ReadOnly = True
        Me.Edit1_4.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_4.Size = New System.Drawing.Size(188, 23)
        Me.Edit1_4.TabIndex = 17
        Me.Edit1_4.Text = "Edit1_4"
        '
        'Edit1_3
        '
        Me.Edit1_3.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_3.Location = New System.Drawing.Point(520, 216)
        Me.Edit1_3.Name = "Edit1_3"
        Me.Edit1_3.ReadOnly = True
        Me.Edit1_3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_3.Size = New System.Drawing.Size(188, 23)
        Me.Edit1_3.TabIndex = 16
        Me.Edit1_3.Text = "Edit1_3"
        '
        'Edit1_2_2
        '
        Me.Edit1_2_2.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_2_2.Location = New System.Drawing.Point(520, 172)
        Me.Edit1_2_2.Name = "Edit1_2_2"
        Me.Edit1_2_2.ReadOnly = True
        Me.Edit1_2_2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_2_2.Size = New System.Drawing.Size(368, 40)
        Me.Edit1_2_2.TabIndex = 15
        Me.Edit1_2_2.Text = "Edit1_2_2"
        '
        'Edit1_2_1
        '
        Me.Edit1_2_1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_2_1.Location = New System.Drawing.Point(520, 132)
        Me.Edit1_2_1.Name = "Edit1_2_1"
        Me.Edit1_2_1.ReadOnly = True
        Me.Edit1_2_1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_2_1.Size = New System.Drawing.Size(368, 40)
        Me.Edit1_2_1.TabIndex = 14
        Me.Edit1_2_1.Text = "Edit1_2_1"
        '
        'Edit1_2_0
        '
        Me.Edit1_2_0.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_2_0.Location = New System.Drawing.Point(520, 104)
        Me.Edit1_2_0.Name = "Edit1_2_0"
        Me.Edit1_2_0.ReadOnly = True
        Me.Edit1_2_0.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_2_0.Size = New System.Drawing.Size(104, 20)
        Me.Edit1_2_0.TabIndex = 13
        Me.Edit1_2_0.Text = "Edit1_2_0"
        '
        'Edit1_1
        '
        Me.Edit1_1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_1.Location = New System.Drawing.Point(520, 76)
        Me.Edit1_1.Name = "Edit1_1"
        Me.Edit1_1.ReadOnly = True
        Me.Edit1_1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_1.Size = New System.Drawing.Size(280, 23)
        Me.Edit1_1.TabIndex = 12
        Me.Edit1_1.Text = "Edit1_1"
        '
        'Edit1_21
        '
        Me.Edit1_21.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_21.Location = New System.Drawing.Point(336, 272)
        Me.Edit1_21.Name = "Edit1_21"
        Me.Edit1_21.ReadOnly = True
        Me.Edit1_21.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_21.Size = New System.Drawing.Size(56, 23)
        Me.Edit1_21.TabIndex = 1065
        Me.Edit1_21.Text = "Edit1_21"
        '
        'Edit1_15
        '
        Me.Edit1_15.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_15.Location = New System.Drawing.Point(140, 300)
        Me.Edit1_15.Name = "Edit1_15"
        Me.Edit1_15.ReadOnly = True
        Me.Edit1_15.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_15.Size = New System.Drawing.Size(192, 23)
        Me.Edit1_15.TabIndex = 10
        Me.Edit1_15.Text = "Edit1_15"
        '
        'Label126
        '
        Me.Label126.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label126.Location = New System.Drawing.Point(396, 192)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(56, 23)
        Me.Label126.TabIndex = 1046
        Me.Label126.Text = "Label126"
        Me.Label126.Visible = False
        '
        'Edit1_14
        '
        Me.Edit1_14.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_14.Location = New System.Drawing.Point(140, 272)
        Me.Edit1_14.Name = "Edit1_14"
        Me.Edit1_14.ReadOnly = True
        Me.Edit1_14.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_14.Size = New System.Drawing.Size(192, 23)
        Me.Edit1_14.TabIndex = 8
        Me.Edit1_14.Text = "Edit1_14"
        '
        'Edit1_13
        '
        Me.Edit1_13.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_13.Location = New System.Drawing.Point(140, 244)
        Me.Edit1_13.Name = "Edit1_13"
        Me.Edit1_13.ReadOnly = True
        Me.Edit1_13.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_13.Size = New System.Drawing.Size(192, 23)
        Me.Edit1_13.TabIndex = 7
        Me.Edit1_13.Text = "Edit1_13"
        '
        'Edit1_12
        '
        Me.Edit1_12.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_12.Location = New System.Drawing.Point(140, 216)
        Me.Edit1_12.Name = "Edit1_12"
        Me.Edit1_12.ReadOnly = True
        Me.Edit1_12.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_12.Size = New System.Drawing.Size(192, 23)
        Me.Edit1_12.TabIndex = 6
        Me.Edit1_12.Text = "Edit1_12"
        '
        'Edit1_11
        '
        Me.Edit1_11.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_11.Location = New System.Drawing.Point(140, 188)
        Me.Edit1_11.Name = "Edit1_11"
        Me.Edit1_11.ReadOnly = True
        Me.Edit1_11.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_11.Size = New System.Drawing.Size(252, 23)
        Me.Edit1_11.TabIndex = 5
        Me.Edit1_11.Text = "Edit1_11"
        '
        'Edit1_18
        '
        Me.Edit1_18.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_18.Location = New System.Drawing.Point(140, 160)
        Me.Edit1_18.Name = "Edit1_18"
        Me.Edit1_18.ReadOnly = True
        Me.Edit1_18.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_18.Size = New System.Drawing.Size(252, 23)
        Me.Edit1_18.TabIndex = 4
        Me.Edit1_18.Text = "Edit1_18"
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Location = New System.Drawing.Point(396, 132)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(56, 23)
        Me.Label59.TabIndex = 224
        Me.Label59.Text = "Label59"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label59.Visible = False
        '
        'Edit1_10
        '
        Me.Edit1_10.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_10.Location = New System.Drawing.Point(140, 132)
        Me.Edit1_10.Name = "Edit1_10"
        Me.Edit1_10.ReadOnly = True
        Me.Edit1_10.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_10.Size = New System.Drawing.Size(252, 23)
        Me.Edit1_10.TabIndex = 3
        Me.Edit1_10.Text = "Edit1_10"
        '
        'Edit1_9
        '
        Me.Edit1_9.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_9.Location = New System.Drawing.Point(140, 104)
        Me.Edit1_9.Name = "Edit1_9"
        Me.Edit1_9.ReadOnly = True
        Me.Edit1_9.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_9.Size = New System.Drawing.Size(252, 23)
        Me.Edit1_9.TabIndex = 2
        Me.Edit1_9.Text = "Edit1_9"
        '
        'Edit1_7
        '
        Me.Edit1_7.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_7.Location = New System.Drawing.Point(140, 76)
        Me.Edit1_7.Name = "Edit1_7"
        Me.Edit1_7.ReadOnly = True
        Me.Edit1_7.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_7.Size = New System.Drawing.Size(252, 23)
        Me.Edit1_7.TabIndex = 1
        Me.Edit1_7.Text = "Edit1_7"
        '
        'Edit1_6
        '
        Me.Edit1_6.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Edit1_6.Location = New System.Drawing.Point(140, 48)
        Me.Edit1_6.Name = "Edit1_6"
        Me.Edit1_6.ReadOnly = True
        Me.Edit1_6.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1_6.Size = New System.Drawing.Size(252, 23)
        Me.Edit1_6.TabIndex = 0
        Me.Edit1_6.Text = "Edit1_6"
        '
        'Label105
        '
        Me.Label105.ForeColor = System.Drawing.Color.Navy
        Me.Label105.Location = New System.Drawing.Point(184, 20)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(128, 20)
        Me.Label105.TabIndex = 226
        Me.Label105.Text = "保証終了日"
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label105.Visible = False
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(808, 68)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 30)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "ﾌﾘｶﾞﾅ入力"
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.SystemColors.Control
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(320, 20)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 20)
        Me.Label52.TabIndex = 221
        Me.Label52.Text = "Label52"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label52.Visible = False
        '
        'Label49
        '
        Me.Label49.ForeColor = System.Drawing.Color.Navy
        Me.Label49.Location = New System.Drawing.Point(400, 104)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(116, 23)
        Me.Label49.TabIndex = 214
        Me.Label49.Text = "郵便番号"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Navy
        Me.Label18.Location = New System.Drawing.Point(20, 160)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 23)
        Me.Label18.TabIndex = 211
        Me.Label18.Text = "型　式"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(20, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 23)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "加入状況"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1_17
        '
        Me.Label1_17.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_17.ForeColor = System.Drawing.Color.Black
        Me.Label1_17.Location = New System.Drawing.Point(144, 20)
        Me.Label1_17.Name = "Label1_17"
        Me.Label1_17.Size = New System.Drawing.Size(40, 20)
        Me.Label1_17.TabIndex = 208
        Me.Label1_17.Text = "Label1_17"
        Me.Label1_17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(20, 300)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(116, 23)
        Me.Label16.TabIndex = 191
        Me.Label16.Text = "延長保証料"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Navy
        Me.Label15.Location = New System.Drawing.Point(20, 272)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 23)
        Me.Label15.TabIndex = 190
        Me.Label15.Text = "延長保証期間"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(20, 244)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 23)
        Me.Label14.TabIndex = 189
        Me.Label14.Text = "メーカー保証期間"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(20, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 23)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "商品購入金額"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(20, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 23)
        Me.Label8.TabIndex = 187
        Me.Label8.Text = "購入店舗"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(20, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 23)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "商品カテゴリー"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(20, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 23)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "品　名"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(20, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 23)
        Me.Label9.TabIndex = 183
        Me.Label9.Text = "保証加入日"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(20, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 23)
        Me.Label7.TabIndex = 182
        Me.Label7.Text = "保証番号"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(400, 244)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 23)
        Me.Label4.TabIndex = 179
        Me.Label4.Text = "連絡先番号"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(400, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 23)
        Me.Label3.TabIndex = 178
        Me.Label3.Text = "電話番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(400, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 23)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "住　所"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(400, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 23)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "氏　名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Edit02)
        Me.TabPage3.Controls.Add(Me.Edit01)
        Me.TabPage3.Controls.Add(Me.Edit5)
        Me.TabPage3.Controls.Add(Me.Label30)
        Me.TabPage3.Controls.Add(Me.Edit4)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.ComboBox3_5)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.T_ComboBox5)
        Me.TabPage3.Controls.Add(Me.Label142)
        Me.TabPage3.Controls.Add(Me.Label141)
        Me.TabPage3.Controls.Add(Me.Label140)
        Me.TabPage3.Controls.Add(Me.Label139)
        Me.TabPage3.Controls.Add(Me.Label138)
        Me.TabPage3.Controls.Add(Me.Label137)
        Me.TabPage3.Controls.Add(Me.Label136)
        Me.TabPage3.Controls.Add(Me.Label134)
        Me.TabPage3.Controls.Add(Me.Label131)
        Me.TabPage3.Controls.Add(Me.Label124)
        Me.TabPage3.Controls.Add(Me.Label123)
        Me.TabPage3.Controls.Add(Me.Label122)
        Me.TabPage3.Controls.Add(Me.ComboBox12)
        Me.TabPage3.Controls.Add(Me.Label106)
        Me.TabPage3.Controls.Add(Me.Label107)
        Me.TabPage3.Controls.Add(Me.ComboBox11)
        Me.TabPage3.Controls.Add(Me.Label108)
        Me.TabPage3.Controls.Add(Me.Label109)
        Me.TabPage3.Controls.Add(Me.ComboBox10)
        Me.TabPage3.Controls.Add(Me.Label110)
        Me.TabPage3.Controls.Add(Me.ComboBox9)
        Me.TabPage3.Controls.Add(Me.Label111)
        Me.TabPage3.Controls.Add(Me.ComboBox8)
        Me.TabPage3.Controls.Add(Me.ComboBox7)
        Me.TabPage3.Controls.Add(Me.Label112)
        Me.TabPage3.Controls.Add(Me.ComboBox6)
        Me.TabPage3.Controls.Add(Me.Label113)
        Me.TabPage3.Controls.Add(Me.Label114)
        Me.TabPage3.Controls.Add(Me.ComboBox4)
        Me.TabPage3.Controls.Add(Me.Label115)
        Me.TabPage3.Controls.Add(Me.Label117)
        Me.TabPage3.Controls.Add(Me.Panel4)
        Me.TabPage3.Controls.Add(Me.Label46)
        Me.TabPage3.Controls.Add(Me.Label3_4)
        Me.TabPage3.Controls.Add(Me.Label45)
        Me.TabPage3.Controls.Add(Me.Label3_3)
        Me.TabPage3.Controls.Add(Me.ComboBox3_4)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.ComboBox3_3)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.Label3_2)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.ComboBox3_2)
        Me.TabPage3.Controls.Add(Me.ComboBox1)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.CheckBox1)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Label3_1)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 21)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(896, 455)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "LOG"
        '
        'Edit5
        '
        Me.Edit5.HighlightText = True
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit5.LengthAsByte = True
        Me.Edit5.Location = New System.Drawing.Point(552, 216)
        Me.Edit5.MaxLength = 12
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit5.Size = New System.Drawing.Size(112, 23)
        Me.Edit5.TabIndex = 1066
        Me.Edit5.Text = "123456789012"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(448, 216)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(104, 23)
        Me.Label30.TabIndex = 1067
        Me.Label30.Text = "修理受付№"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit4
        '
        Me.Edit4.Format = "9"
        Me.Edit4.HighlightText = True
        Me.Edit4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit4.Location = New System.Drawing.Point(152, 428)
        Me.Edit4.MaxLength = 20
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit4.Size = New System.Drawing.Size(120, 23)
        Me.Edit4.TabIndex = 18
        Me.Edit4.Text = "1"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(40, 428)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 23)
        Me.Label29.TabIndex = 1065
        Me.Label29.Text = "連絡先電話番号"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 23)
        Me.Label6.TabIndex = 1064
        Me.Label6.Text = "Label6"
        Me.Label6.Visible = False
        '
        'ComboBox3_5
        '
        Me.ComboBox3_5.Location = New System.Drawing.Point(152, 216)
        Me.ComboBox3_5.Name = "ComboBox3_5"
        Me.ComboBox3_5.Size = New System.Drawing.Size(288, 23)
        Me.ComboBox3_5.TabIndex = 14
        Me.ComboBox3_5.Text = "ComboBox3_5"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(40, 216)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 23)
        Me.Label17.TabIndex = 1063
        Me.Label17.Text = "修理依頼先"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'T_ComboBox5
        '
        Me.T_ComboBox5.AutoSize = False
        Me.T_ComboBox5.ImeMode = System.Windows.Forms.ImeMode.On
        Me.T_ComboBox5.Location = New System.Drawing.Point(152, 104)
        Me.T_ComboBox5.MaxLength = 50
        Me.T_ComboBox5.Name = "T_ComboBox5"
        Me.T_ComboBox5.Size = New System.Drawing.Size(288, 23)
        Me.T_ComboBox5.TabIndex = 5
        Me.T_ComboBox5.Text = "T_ComboBox5"
        '
        'Label142
        '
        Me.Label142.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label142.Location = New System.Drawing.Point(848, 160)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(36, 23)
        Me.Label142.TabIndex = 1061
        Me.Label142.Text = "Label142"
        Me.Label142.Visible = False
        '
        'Label141
        '
        Me.Label141.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label141.Location = New System.Drawing.Point(4, 160)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(36, 23)
        Me.Label141.TabIndex = 1060
        Me.Label141.Text = "Label141"
        Me.Label141.Visible = False
        '
        'Label140
        '
        Me.Label140.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label140.Location = New System.Drawing.Point(848, 132)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(36, 23)
        Me.Label140.TabIndex = 1059
        Me.Label140.Text = "Label140"
        Me.Label140.Visible = False
        '
        'Label139
        '
        Me.Label139.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label139.Location = New System.Drawing.Point(848, 104)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(36, 23)
        Me.Label139.TabIndex = 1058
        Me.Label139.Text = "Label139"
        Me.Label139.Visible = False
        '
        'Label138
        '
        Me.Label138.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label138.Location = New System.Drawing.Point(508, 24)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(36, 23)
        Me.Label138.TabIndex = 1057
        Me.Label138.Text = "Label138"
        Me.Label138.Visible = False
        '
        'Label137
        '
        Me.Label137.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label137.Location = New System.Drawing.Point(408, 24)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(36, 23)
        Me.Label137.TabIndex = 1056
        Me.Label137.Text = "Label137"
        Me.Label137.Visible = False
        '
        'Label136
        '
        Me.Label136.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label136.Location = New System.Drawing.Point(4, 132)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(36, 23)
        Me.Label136.TabIndex = 1055
        Me.Label136.Text = "Label136"
        Me.Label136.Visible = False
        '
        'Label134
        '
        Me.Label134.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label134.Location = New System.Drawing.Point(4, 76)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(36, 23)
        Me.Label134.TabIndex = 1053
        Me.Label134.Text = "Label134"
        Me.Label134.Visible = False
        '
        'Label131
        '
        Me.Label131.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label131.Location = New System.Drawing.Point(4, 48)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(36, 23)
        Me.Label131.TabIndex = 1050
        Me.Label131.Text = "Label131"
        Me.Label131.Visible = False
        '
        'Label124
        '
        Me.Label124.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label124.Location = New System.Drawing.Point(4, 324)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(36, 23)
        Me.Label124.TabIndex = 1043
        Me.Label124.Text = "Label124"
        Me.Label124.Visible = False
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label123.Location = New System.Drawing.Point(664, 188)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(36, 23)
        Me.Label123.TabIndex = 1042
        Me.Label123.Text = "Label123"
        Me.Label123.Visible = False
        '
        'Label122
        '
        Me.Label122.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label122.Location = New System.Drawing.Point(4, 188)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(36, 23)
        Me.Label122.TabIndex = 1041
        Me.Label122.Text = "Label122"
        Me.Label122.Visible = False
        '
        'ComboBox12
        '
        Me.ComboBox12.Location = New System.Drawing.Point(552, 160)
        Me.ComboBox12.MaxDropDownItems = 12
        Me.ComboBox12.Name = "ComboBox12"
        Me.ComboBox12.Size = New System.Drawing.Size(296, 23)
        Me.ComboBox12.TabIndex = 10
        Me.ComboBox12.Text = "ComboBox12"
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label106.ForeColor = System.Drawing.Color.White
        Me.Label106.Location = New System.Drawing.Point(448, 160)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(104, 23)
        Me.Label106.TabIndex = 1040
        Me.Label106.Text = "対応結果２"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label107
        '
        Me.Label107.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.White
        Me.Label107.Location = New System.Drawing.Point(448, 76)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(136, 23)
        Me.Label107.TabIndex = 1039
        Me.Label107.Text = "コール内容"
        Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox11
        '
        Me.ComboBox11.Location = New System.Drawing.Point(152, 160)
        Me.ComboBox11.MaxDropDownItems = 12
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(288, 23)
        Me.ComboBox11.TabIndex = 9
        Me.ComboBox11.Text = "ComboBox11"
        '
        'Label108
        '
        Me.Label108.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.White
        Me.Label108.Location = New System.Drawing.Point(40, 160)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(112, 23)
        Me.Label108.TabIndex = 1038
        Me.Label108.Text = "対応結果１"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label109
        '
        Me.Label109.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label109.ForeColor = System.Drawing.Color.White
        Me.Label109.Location = New System.Drawing.Point(464, 48)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(40, 23)
        Me.Label109.TabIndex = 1037
        Me.Label109.Text = "月"
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox10
        '
        Me.ComboBox10.Location = New System.Drawing.Point(584, 132)
        Me.ComboBox10.MaxDropDownItems = 12
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(264, 23)
        Me.ComboBox10.TabIndex = 8
        Me.ComboBox10.Text = "ComboBox10"
        '
        'Label110
        '
        Me.Label110.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.White
        Me.Label110.Location = New System.Drawing.Point(480, 132)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(104, 23)
        Me.Label110.TabIndex = 1036
        Me.Label110.Text = "意見・要望系"
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox9
        '
        Me.ComboBox9.Location = New System.Drawing.Point(584, 104)
        Me.ComboBox9.MaxDropDownItems = 12
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(264, 23)
        Me.ComboBox9.TabIndex = 7
        Me.ComboBox9.Text = "ComboBox9"
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.White
        Me.Label111.Location = New System.Drawing.Point(480, 104)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(104, 23)
        Me.Label111.TabIndex = 1035
        Me.Label111.Text = "不具合系"
        Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox8
        '
        Me.ComboBox8.Location = New System.Drawing.Point(504, 48)
        Me.ComboBox8.MaxDropDownItems = 12
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(48, 23)
        Me.ComboBox8.TabIndex = 2
        Me.ComboBox8.Text = "ComboBox8"
        '
        'ComboBox7
        '
        Me.ComboBox7.Location = New System.Drawing.Point(408, 48)
        Me.ComboBox7.MaxDropDownItems = 12
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(48, 23)
        Me.ComboBox7.TabIndex = 1
        Me.ComboBox7.Text = "ComboBox7"
        '
        'Label112
        '
        Me.Label112.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.White
        Me.Label112.Location = New System.Drawing.Point(304, 48)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(104, 23)
        Me.Label112.TabIndex = 1034
        Me.Label112.Text = "購入後　年"
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox6
        '
        Me.ComboBox6.Location = New System.Drawing.Point(152, 132)
        Me.ComboBox6.MaxDropDownItems = 26
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(288, 23)
        Me.ComboBox6.TabIndex = 6
        Me.ComboBox6.Text = "ComboBox6"
        '
        'Label113
        '
        Me.Label113.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label113.ForeColor = System.Drawing.Color.White
        Me.Label113.Location = New System.Drawing.Point(40, 132)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(112, 23)
        Me.Label113.TabIndex = 1033
        Me.Label113.Text = "購入店舗"
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label114
        '
        Me.Label114.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.White
        Me.Label114.Location = New System.Drawing.Point(40, 104)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(112, 23)
        Me.Label114.TabIndex = 1032
        Me.Label114.Text = "品　名"
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(152, 76)
        Me.ComboBox4.MaxDropDownItems = 26
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(288, 23)
        Me.ComboBox4.TabIndex = 4
        Me.ComboBox4.Text = "ComboBox4"
        '
        'Label115
        '
        Me.Label115.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label115.ForeColor = System.Drawing.Color.White
        Me.Label115.Location = New System.Drawing.Point(40, 76)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(112, 23)
        Me.Label115.TabIndex = 1031
        Me.Label115.Text = "商品ｶﾃｺﾞﾘｰ"
        Me.Label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label117
        '
        Me.Label117.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label117.ForeColor = System.Drawing.Color.White
        Me.Label117.Location = New System.Drawing.Point(560, 48)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(104, 23)
        Me.Label117.TabIndex = 1029
        Me.Label117.Text = "性　別"
        Me.Label117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.RadioButton8)
        Me.Panel4.Controls.Add(Me.RadioButton9)
        Me.Panel4.Location = New System.Drawing.Point(664, 48)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(128, 24)
        Me.Panel4.TabIndex = 3
        Me.Panel4.TabStop = True
        '
        'RadioButton8
        '
        Me.RadioButton8.Location = New System.Drawing.Point(64, 0)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(40, 24)
        Me.RadioButton8.TabIndex = 1
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Text = "女"
        '
        'RadioButton9
        '
        Me.RadioButton9.Checked = True
        Me.RadioButton9.Location = New System.Drawing.Point(8, 0)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(48, 24)
        Me.RadioButton9.TabIndex = 0
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Text = "男"
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.DimGray
        Me.Label46.Location = New System.Drawing.Point(48, 28)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(48, 16)
        Me.Label46.TabIndex = 219
        Me.Label46.Text = "氏名"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3_4
        '
        Me.Label3_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_4.ForeColor = System.Drawing.Color.Black
        Me.Label3_4.Location = New System.Drawing.Point(96, 28)
        Me.Label3_4.Name = "Label3_4"
        Me.Label3_4.Size = New System.Drawing.Size(248, 16)
        Me.Label3_4.TabIndex = 218
        Me.Label3_4.Text = "Label3_4"
        Me.Label3_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.DimGray
        Me.Label45.Location = New System.Drawing.Point(600, 8)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(80, 16)
        Me.Label45.TabIndex = 217
        Me.Label45.Text = "受付担当"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3_3
        '
        Me.Label3_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_3.ForeColor = System.Drawing.Color.Black
        Me.Label3_3.Location = New System.Drawing.Point(688, 8)
        Me.Label3_3.Name = "Label3_3"
        Me.Label3_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3_3.Size = New System.Drawing.Size(144, 16)
        Me.Label3_3.TabIndex = 216
        Me.Label3_3.Text = "Label3_3"
        Me.Label3_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox3_4
        '
        Me.ComboBox3_4.Location = New System.Drawing.Point(152, 324)
        Me.ComboBox3_4.Name = "ComboBox3_4"
        Me.ComboBox3_4.Size = New System.Drawing.Size(200, 23)
        Me.ComboBox3_4.TabIndex = 16
        Me.ComboBox3_4.Text = "ComboBox3_4"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(40, 324)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 23)
        Me.Label25.TabIndex = 214
        Me.Label25.Text = "回答区分"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox3_3
        '
        Me.ComboBox3_3.Location = New System.Drawing.Point(552, 188)
        Me.ComboBox3_3.Name = "ComboBox3_3"
        Me.ComboBox3_3.Size = New System.Drawing.Size(112, 23)
        Me.ComboBox3_3.TabIndex = 12
        Me.ComboBox3_3.Text = "ComboBox3_3"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(448, 188)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 23)
        Me.Label24.TabIndex = 212
        Me.Label24.Text = "ステイタス"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DimGray
        Me.Label23.Location = New System.Drawing.Point(360, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 16)
        Me.Label23.TabIndex = 211
        Me.Label23.Text = "受付番号"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3_2
        '
        Me.Label3_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_2.ForeColor = System.Drawing.Color.Black
        Me.Label3_2.Location = New System.Drawing.Point(448, 8)
        Me.Label3_2.Name = "Label3_2"
        Me.Label3_2.Size = New System.Drawing.Size(96, 16)
        Me.Label3_2.TabIndex = 210
        Me.Label3_2.Text = "Label3_2"
        Me.Label3_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(788, 352)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 30)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "履歴表示"
        '
        'ComboBox3_2
        '
        Me.ComboBox3_2.Location = New System.Drawing.Point(152, 188)
        Me.ComboBox3_2.Name = "ComboBox3_2"
        Me.ComboBox3_2.Size = New System.Drawing.Size(288, 23)
        Me.ComboBox3_2.TabIndex = 11
        Me.ComboBox3_2.Text = "ComboBox3_2"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(152, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 23)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(44, 352)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 72)
        Me.Label22.TabIndex = 205
        Me.Label22.Text = "回答内容"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(40, 244)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 76)
        Me.Label21.TabIndex = 203
        Me.Label21.Text = "問合せ内容"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(704, 188)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(112, 23)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = "クレーム"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(40, 188)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 23)
        Me.Label20.TabIndex = 201
        Me.Label20.Text = "問合せ区分"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(40, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 23)
        Me.Label19.TabIndex = 200
        Me.Label19.Text = "相手先"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(48, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 16)
        Me.Label12.TabIndex = 199
        Me.Label12.Text = "受付開始時刻"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3_1
        '
        Me.Label3_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_1.ForeColor = System.Drawing.Color.Black
        Me.Label3_1.Location = New System.Drawing.Point(152, 8)
        Me.Label3_1.Name = "Label3_1"
        Me.Label3_1.Size = New System.Drawing.Size(192, 16)
        Me.Label3_1.TabIndex = 198
        Me.Label3_1.Text = "Label3_1"
        Me.Label3_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(788, 392)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 30)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "追  加"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.RadioButton3)
        Me.TabPage4.Controls.Add(Me.T_ComboBox19)
        Me.TabPage4.Controls.Add(Me.T_ComboBox17)
        Me.TabPage4.Controls.Add(Me.Label120)
        Me.TabPage4.Controls.Add(Me.Label104)
        Me.TabPage4.Controls.Add(Me.Date4)
        Me.TabPage4.Controls.Add(Me.RadioButton2)
        Me.TabPage4.Controls.Add(Me.RadioButton1)
        Me.TabPage4.Controls.Add(Me.Label70)
        Me.TabPage4.Controls.Add(Me.Label69)
        Me.TabPage4.Controls.Add(Me.Label68)
        Me.TabPage4.Controls.Add(Me.Label67)
        Me.TabPage4.Controls.Add(Me.Label66)
        Me.TabPage4.Controls.Add(Me.Label65)
        Me.TabPage4.Controls.Add(Me.Label64)
        Me.TabPage4.Controls.Add(Me.Label63)
        Me.TabPage4.Controls.Add(Me.Label62)
        Me.TabPage4.Controls.Add(Me.Label61)
        Me.TabPage4.Controls.Add(Me.ComboBox18)
        Me.TabPage4.Controls.Add(Me.Button7)
        Me.TabPage4.Controls.Add(Me.Label57)
        Me.TabPage4.Controls.Add(Me.TextBox4_4)
        Me.TabPage4.Controls.Add(Me.Label56)
        Me.TabPage4.Controls.Add(Me.Label55)
        Me.TabPage4.Controls.Add(Me.Edit3)
        Me.TabPage4.Controls.Add(Me.Label54)
        Me.TabPage4.Controls.Add(Me.Edit2)
        Me.TabPage4.Controls.Add(Me.Edit1)
        Me.TabPage4.Controls.Add(Me.CheckBox4)
        Me.TabPage4.Controls.Add(Me.Label53)
        Me.TabPage4.Controls.Add(Me.Label48)
        Me.TabPage4.Controls.Add(Me.Button4)
        Me.TabPage4.Controls.Add(Me.Label44)
        Me.TabPage4.Controls.Add(Me.TextBox4_6)
        Me.TabPage4.Controls.Add(Me.Label42)
        Me.TabPage4.Controls.Add(Me.Button3)
        Me.TabPage4.Controls.Add(Me.Label28)
        Me.TabPage4.Controls.Add(Me.Label27)
        Me.TabPage4.Controls.Add(Me.TextBox4_3)
        Me.TabPage4.Controls.Add(Me.Label26)
        Me.TabPage4.Controls.Add(Me.TextBox4_2)
        Me.TabPage4.Controls.Add(Me.Label4_1)
        Me.TabPage4.Controls.Add(Me.TextBox4_1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 21)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(896, 455)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "変更"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(644, 16)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(68, 23)
        Me.RadioButton3.TabIndex = 14
        Me.RadioButton3.Text = "解約"
        Me.RadioButton3.Visible = False
        '
        'T_ComboBox19
        '
        Me.T_ComboBox19.ImeMode = System.Windows.Forms.ImeMode.On
        Me.T_ComboBox19.Location = New System.Drawing.Point(160, 308)
        Me.T_ComboBox19.MaxLength = 50
        Me.T_ComboBox19.Name = "T_ComboBox19"
        Me.T_ComboBox19.Size = New System.Drawing.Size(336, 22)
        Me.T_ComboBox19.TabIndex = 110
        Me.T_ComboBox19.Text = "T_ComboBox19"
        '
        'T_ComboBox17
        '
        Me.T_ComboBox17.ImeMode = System.Windows.Forms.ImeMode.On
        Me.T_ComboBox17.Location = New System.Drawing.Point(160, 252)
        Me.T_ComboBox17.MaxLength = 50
        Me.T_ComboBox17.Name = "T_ComboBox17"
        Me.T_ComboBox17.Size = New System.Drawing.Size(336, 22)
        Me.T_ComboBox17.TabIndex = 90
        Me.T_ComboBox17.Text = "T_ComboBox17"
        '
        'Label120
        '
        Me.Label120.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label120.Location = New System.Drawing.Point(712, 280)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(56, 23)
        Me.Label120.TabIndex = 933
        Me.Label120.Text = "Label120"
        Me.Label120.Visible = False
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.White
        Me.Label104.Location = New System.Drawing.Point(280, 16)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(112, 23)
        Me.Label104.TabIndex = 931
        Me.Label104.Text = "保証終了日"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label104.Visible = False
        '
        'Date4
        '
        Me.Date4.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date4.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date4.DropDownCalendar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date4.DropDownCalendar.Size = New System.Drawing.Size(179, 195)
        Me.Date4.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date4.Location = New System.Drawing.Point(392, 16)
        Me.Date4.Name = "Date4"
        Me.Date4.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date4.Size = New System.Drawing.Size(96, 23)
        Me.Date4.TabIndex = 11
        Me.Date4.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date4.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date4.Value = Nothing
        Me.Date4.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(576, 16)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(68, 23)
        Me.RadioButton2.TabIndex = 13
        Me.RadioButton2.Text = "取消"
        Me.RadioButton2.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(508, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(68, 23)
        Me.RadioButton1.TabIndex = 12
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "全損"
        Me.RadioButton1.Visible = False
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label70.Location = New System.Drawing.Point(500, 308)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(208, 23)
        Me.Label70.TabIndex = 930
        Me.Label70.Text = "Label70"
        Me.Label70.Visible = False
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label69.Location = New System.Drawing.Point(500, 280)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(208, 23)
        Me.Label69.TabIndex = 929
        Me.Label69.Text = "Label69"
        Me.Label69.Visible = False
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label68.Location = New System.Drawing.Point(500, 252)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(208, 23)
        Me.Label68.TabIndex = 928
        Me.Label68.Text = "Label68"
        Me.Label68.Visible = False
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label67.Location = New System.Drawing.Point(284, 224)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(208, 23)
        Me.Label67.TabIndex = 927
        Me.Label67.Text = "Label67"
        Me.Label67.Visible = False
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label66.Location = New System.Drawing.Point(284, 196)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(208, 23)
        Me.Label66.TabIndex = 926
        Me.Label66.Text = "Label66"
        Me.Label66.Visible = False
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label65.Location = New System.Drawing.Point(620, 168)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(208, 23)
        Me.Label65.TabIndex = 925
        Me.Label65.Text = "Label65"
        Me.Label65.Visible = False
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label64.Location = New System.Drawing.Point(620, 140)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(208, 23)
        Me.Label64.TabIndex = 924
        Me.Label64.Text = "Label64"
        Me.Label64.Visible = False
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label63.Location = New System.Drawing.Point(284, 112)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(208, 23)
        Me.Label63.TabIndex = 923
        Me.Label63.Text = "Label63"
        Me.Label63.Visible = False
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label62.Location = New System.Drawing.Point(356, 84)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(208, 23)
        Me.Label62.TabIndex = 922
        Me.Label62.Text = "Label62"
        Me.Label62.Visible = False
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label61.Location = New System.Drawing.Point(356, 56)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(208, 23)
        Me.Label61.TabIndex = 921
        Me.Label61.Text = "Label61"
        Me.Label61.Visible = False
        '
        'ComboBox18
        '
        Me.ComboBox18.Location = New System.Drawing.Point(160, 280)
        Me.ComboBox18.Name = "ComboBox18"
        Me.ComboBox18.Size = New System.Drawing.Size(336, 23)
        Me.ComboBox18.TabIndex = 100
        Me.ComboBox18.Text = "ComboBox18"
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(788, 312)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(96, 30)
        Me.Button7.TabIndex = 900
        Me.Button7.Text = "クリア"
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.White
        Me.Label57.Location = New System.Drawing.Point(48, 56)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(112, 23)
        Me.Label57.TabIndex = 28
        Me.Label57.Text = "氏名（ｶﾅ）"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_4
        '
        Me.TextBox4_4.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.TextBox4_4.Location = New System.Drawing.Point(160, 56)
        Me.TextBox4_4.MaxLength = 30
        Me.TextBox4_4.Name = "TextBox4_4"
        Me.TextBox4_4.Size = New System.Drawing.Size(192, 22)
        Me.TextBox4_4.TabIndex = 20
        Me.TextBox4_4.Text = "TextBox4_4"
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.White
        Me.Label56.Location = New System.Drawing.Point(48, 308)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(112, 23)
        Me.Label56.TabIndex = 23
        Me.Label56.Text = "型　式"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.White
        Me.Label55.Location = New System.Drawing.Point(48, 280)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(112, 23)
        Me.Label55.TabIndex = 22
        Me.Label55.Text = "商品カテゴリー"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit3
        '
        Me.Edit3.Format = "9"
        Me.Edit3.HighlightText = True
        Me.Edit3.Location = New System.Drawing.Point(160, 224)
        Me.Edit3.MaxLength = 20
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(120, 23)
        Me.Edit3.TabIndex = 80
        Me.Edit3.Text = "1"
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.White
        Me.Label54.Location = New System.Drawing.Point(48, 224)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(112, 23)
        Me.Label54.TabIndex = 20
        Me.Label54.Text = "連絡先電話番号"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit2
        '
        Me.Edit2.Format = "9"
        Me.Edit2.HighlightText = True
        Me.Edit2.Location = New System.Drawing.Point(160, 196)
        Me.Edit2.MaxLength = 20
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(120, 23)
        Me.Edit2.TabIndex = 70
        Me.Edit2.Text = "1"
        '
        'Edit1
        '
        Me.Edit1.Format = "9"
        Me.Edit1.HighlightText = True
        Me.Edit1.Location = New System.Drawing.Point(160, 112)
        Me.Edit1.MaxLength = 7
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(120, 23)
        Me.Edit1.TabIndex = 40
        Me.Edit1.Text = "1"
        '
        'CheckBox4
        '
        Me.CheckBox4.Location = New System.Drawing.Point(176, 16)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(104, 23)
        Me.CheckBox4.TabIndex = 10
        Me.CheckBox4.Text = """F"" に変更"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.White
        Me.Label53.Location = New System.Drawing.Point(48, 16)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(112, 23)
        Me.Label53.TabIndex = 16
        Me.Label53.Text = "加入状況"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(48, 112)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(112, 23)
        Me.Label48.TabIndex = 14
        Me.Label48.Text = "郵便番号"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(788, 352)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 30)
        Me.Button4.TabIndex = 910
        Me.Button4.Text = "履歴表示"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(48, 336)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(112, 112)
        Me.Label44.TabIndex = 11
        Me.Label44.Text = "変更理由"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_6
        '
        Me.TextBox4_6.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox4_6.Location = New System.Drawing.Point(160, 336)
        Me.TextBox4_6.MaxLength = 300
        Me.TextBox4_6.Multiline = True
        Me.TextBox4_6.Name = "TextBox4_6"
        Me.TextBox4_6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox4_6.Size = New System.Drawing.Size(456, 112)
        Me.TextBox4_6.TabIndex = 120
        Me.TextBox4_6.Text = "TextBox4_6"
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(48, 252)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(112, 23)
        Me.Label42.TabIndex = 9
        Me.Label42.Text = "品　名"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(788, 392)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 30)
        Me.Button3.TabIndex = 920
        Me.Button3.Text = "変 更"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(48, 196)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(112, 23)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "電話番号"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(48, 168)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 23)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "住所2"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_3
        '
        Me.TextBox4_3.AutoSize = False
        Me.TextBox4_3.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox4_3.Location = New System.Drawing.Point(160, 168)
        Me.TextBox4_3.MaxLength = 60
        Me.TextBox4_3.Name = "TextBox4_3"
        Me.TextBox4_3.Size = New System.Drawing.Size(456, 23)
        Me.TextBox4_3.TabIndex = 60
        Me.TextBox4_3.Text = "TextBox4_3"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(48, 140)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 23)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "住所1"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_2
        '
        Me.TextBox4_2.AutoSize = False
        Me.TextBox4_2.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox4_2.Location = New System.Drawing.Point(160, 140)
        Me.TextBox4_2.MaxLength = 60
        Me.TextBox4_2.Name = "TextBox4_2"
        Me.TextBox4_2.Size = New System.Drawing.Size(456, 23)
        Me.TextBox4_2.TabIndex = 50
        Me.TextBox4_2.Text = "TextBox4_2"
        '
        'Label4_1
        '
        Me.Label4_1.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label4_1.ForeColor = System.Drawing.Color.White
        Me.Label4_1.Location = New System.Drawing.Point(48, 84)
        Me.Label4_1.Name = "Label4_1"
        Me.Label4_1.Size = New System.Drawing.Size(112, 23)
        Me.Label4_1.TabIndex = 1
        Me.Label4_1.Text = "氏名（漢字）"
        Me.Label4_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_1
        '
        Me.TextBox4_1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox4_1.Location = New System.Drawing.Point(160, 84)
        Me.TextBox4_1.MaxLength = 30
        Me.TextBox4_1.Name = "TextBox4_1"
        Me.TextBox4_1.Size = New System.Drawing.Size(192, 22)
        Me.TextBox4_1.TabIndex = 30
        Me.TextBox4_1.Text = "TextBox4_1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.ItemSize = New System.Drawing.Size(60, 17)
        Me.TabControl1.Location = New System.Drawing.Point(16, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(904, 480)
        Me.TabControl1.TabIndex = 0
        '
        'Edit01
        '
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.On
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(64, 244)
        Me.Edit01.MaxLength = 2000
        Me.Edit01.Multiline = True
        Me.Edit01.Name = "Edit01"
        Me.Edit01.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit01.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(700, 76)
        Me.Edit01.TabIndex = 15
        Me.Edit01.Text = "Edit01"
        '
        'Edit02
        '
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.On
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(68, 352)
        Me.Edit02.MaxLength = 2000
        Me.Edit02.Multiline = True
        Me.Edit02.Name = "Edit02"
        Me.Edit02.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit02.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(696, 72)
        Me.Edit02.TabIndex = 17
        Me.Edit02.Text = "Edit02"
        '
        'Form3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(938, 547)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form3"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MrMax 安心5年保証"
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Edit50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_2_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_2_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_2_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1_6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Call dsp_tag1()     '基本情報  SET
        Call dsp_tag4()     '変更　    SET

        Select Case pPROC
            Case Is = "n1"  '新規　加入検索
                Call dsp_tag3_n() 'Log　SET （登録）
            Case Is = "r1"  '対応中　加入検索
                Call dsp_tag3_r() 'Log　SET （追加）（照会）
        End Select

        TabControl1.SelectedTab = TabPage1
        inz_F = "1"
    End Sub

    Sub CmbSet()
        TabControl1.SelectedTab = TabPage3

        '相手先
        ComboBox1.DataSource = P_DsCMB.Tables("CUST_CLS")
        ComboBox1.DisplayMember = "NAME"
        ComboBox1.ValueMember = "CLS_CODE"
        ComboBox1.Text = Nothing

        '問合せ区分
        ComboBox3_2.DataSource = P_DsCMB.Tables("ICDT_CLS")
        ComboBox3_2.DisplayMember = "NAME"
        ComboBox3_2.ValueMember = "CLS_CODE"

        'ステイタス
        ComboBox3_3.DataSource = P_DsCMB.Tables("STS_CLS")
        ComboBox3_3.DisplayMember = "NAME"
        ComboBox3_3.ValueMember = "CLS_CODE"

        '回答区分
        ComboBox3_4.DataSource = P_DsCMB.Tables("STS_RPLY")
        ComboBox3_4.DisplayMember = "NAME"
        ComboBox3_4.ValueMember = "CLS_CODE"

        '修理依頼先
        ComboBox3_5.DataSource = P_DsCMB.Tables("CLS_002")
        ComboBox3_5.DisplayMember = "NAME"
        ComboBox3_5.ValueMember = "CLS_CODE"

        '商品ｶﾃｺﾞﾘｰ
        ComboBox4.DataSource = P_DsCMB.Tables("M_category2")
        ComboBox4.DisplayMember = "CAT_NAME"
        ComboBox4.ValueMember = "CAT_CODE"
        ComboBox4.Text = Nothing

        '店舗
        ComboBox6.DataSource = P_DsCMB.Tables("SHOP2")
        ComboBox6.DisplayMember = "SHOP_NAME"
        ComboBox6.ValueMember = "SHOP_CODE"
        ComboBox6.Text = Nothing

        '年
        ComboBox7.DataSource = P_DsCMB.Tables("YEAR_CLS")
        ComboBox7.DisplayMember = "NAME"
        ComboBox7.ValueMember = "CLS_CODE"
        ComboBox7.Text = Nothing

        '月
        ComboBox8.DataSource = P_DsCMB.Tables("MONTHS_CLS")
        ComboBox8.DisplayMember = "NAME"
        ComboBox8.ValueMember = "CLS_CODE"
        ComboBox8.Text = Nothing

        '不具合
        ComboBox9.DataSource = P_DsCMB.Tables("CALL1_CLS")
        ComboBox9.DisplayMember = "NAME"
        ComboBox9.ValueMember = "CLS_CODE"
        ComboBox9.Text = Nothing

        '意見
        ComboBox10.DataSource = P_DsCMB.Tables("CALL2_CLS")
        ComboBox10.DisplayMember = "NAME"
        ComboBox10.ValueMember = "CLS_CODE"
        ComboBox10.Text = Nothing

        '結果１
        ComboBox11.DataSource = P_DsCMB.Tables("RPLY_CLS1")
        ComboBox11.DisplayMember = "NAME"
        ComboBox11.ValueMember = "CLS_CODE"
        ComboBox11.Text = Nothing

        '結果２
        ComboBox12.DataSource = P_DsCMB.Tables("RPLY_CLS2")
        ComboBox12.DisplayMember = "NAME"
        ComboBox12.ValueMember = "CLS_CODE"
        ComboBox12.Text = Nothing

        TabControl1.SelectedTab = TabPage4

        '商品ｶﾃｺﾞﾘｰ
        ComboBox18.DataSource = P_DsCMB.Tables("M_category")
        ComboBox18.DisplayMember = "CAT_NAME"
        ComboBox18.ValueMember = "CAT_CODE"
        ComboBox18.Text = Nothing

        TabControl1.SelectedTab = TabPage1
    End Sub

    '*************************************************
    '** 基本情報 SET
    '*************************************************
    Private Sub dsp_tag1()

        TabControl1.SelectedTab = TabPage1

        strSQL = "SELECT *"
        strSQL = strSQL & " FROM WRN_DATA"
        strSQL = strSQL & " WHERE WRN_NO = '" & pWrn_no & "'"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "WRN_DATA")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("WRN_DATA"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Call CmbSet()
            If IsDBNull(DtView1(0)("SALE_STS")) = False Then
                Select Case DtView1(0)("SALE_STS")
                    Case Is = "00"
                        Label1_17.Text = "A"
                    Case Is = "09"
                        Label1_17.Text = "C"
                    Case Else
                        Label1_17.Text = "F"
                        Label105.Visible = True
                        Label52.Visible = True

                        strSQL = "SELECT END_DATE"
                        strSQL = strSQL & " FROM STTS_F_UPD"
                        strSQL = strSQL & " WHERE (UPD_F = '1')"
                        strSQL = strSQL & " AND (WRN_NO = '" & pWrn_no & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(DsList1, "STTS_F_UPD")
                        DB_CLOSE()
                        DtView2 = New DataView(DsList1.Tables("STTS_F_UPD"), "", "", DataViewRowState.CurrentRows)
                        If DtView2.Count <> 0 Then
                            Label52.Text = Format(DtView2(0)("END_DATE"), "yyyy/MM/dd")
                        Else
                            Label52.Text = Nothing
                        End If
                End Select
            Else
                Label1_17.Text = Nothing
            End If

            Edit1_6.Text = Mid(DtView1(0)("WRN_NO"), 1, 4) & "  " & Mid(DtView1(0)("WRN_NO"), 5, 2) & "  " & Mid(DtView1(0)("WRN_NO"), 7, 7) & "  " & Mid(DtView1(0)("WRN_NO"), 14, 4)

            Edit1_7.Text = DtView1(0)("WRN_DATE")
            If Not IsDBNull(DtView1(0)("MKR_NAME")) Then Edit1_9.Text = DtView1(0)("MKR_NAME") Else Edit1_9.Text = Nothing
            If Not IsDBNull(DtView1(0)("CAT_NAME")) Then Edit1_10.Text = DtView1(0)("CAT_NAME") Else Edit1_10.Text = Nothing
            Edit1_18.Text = DtView1(0)("MODEL")
            If Not IsDBNull(DtView1(0)("CAT_CODE")) Then Label59.Text = Trim(DtView1(0)("CAT_CODE")) Else Label59.Text = Nothing

            strSQL = "SELECT SHOP_NAME"
            strSQL = strSQL & " FROM SHOP"
            strSQL = strSQL & " WHERE SHOP_CODE = '" & DtView1(0)("SHOP_CODE") & "'"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "SHOP")
            DB_CLOSE()
            DtView2 = New DataView(DsList1.Tables("SHOP"), "", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                Edit1_11.Text = DtView2(0)("SHOP_NAME")
                Label126.Text = DtView1(0)("SHOP_CODE")
            Else
                Edit1_11.Text = "不明"
                Label126.Text = Nothing
            End If

            Edit1_12.Text = FormatCurrency(DtView1(0)("PRICE"), 0, True, TriState.True)

            Edit1_13.Text = DtView1(0)("WRN_DATE") & " - " & DateAdd("d", -1, DateAdd("yyyy", 1, DtView1(0)("WRN_DATE")))

            If DateAdd("d", -1, DateAdd("yyyy", 1, DtView1(0)("WRN_DATE"))) >= Now.Date() Then
                Edit1_13.BackColor = System.Drawing.Color.Blue
                Edit1_13.ForeColor = System.Drawing.Color.White
            End If

            If DtView1(0)("WRN_PRD") = "00" Then
                Edit1_14.Text = "None"
                Me.Edit1_14.ForeColor = System.Drawing.Color.Black
                Edit1_21.Text = Nothing
            Else
                Dim WK_prd As Integer = DtView1(0)("WRN_PRD")
                Edit1_14.Text = DateAdd("yyyy", 1, DtView1(0)("WRN_DATE")) & " - " & DateAdd("d", -1, DateAdd("yyyy", WK_prd, DtView1(0)("WRN_DATE")))
                e_date = DateAdd("d", -1, DateAdd("yyyy", WK_prd, DtView1(0)("WRN_DATE")))
                Edit1_21.Text = WK_prd & "年"
            End If
            If DateAdd("d", -1, DateAdd("yyyy", 1, DtView1(0)("WRN_DATE"))) < Now.Date() And e_date > Now.Date() Then
                Edit1_14.BackColor = System.Drawing.Color.Blue
                Edit1_14.ForeColor = System.Drawing.Color.White
            End If

            If DtView1(0)("WRN_PRD") = "00" Then
                Edit1_15.Text = "None"
            Else
                Edit1_15.Text = FormatCurrency(DtView1(0)("WRN_PRICE"), 0, True, TriState.True)
            End If

            If Not IsDBNull(DtView1(0)("CUST_NAME_KANA")) Then
                Edit50.Text = DtView1(0)("CUST_NAME_KANA")
            Else
                Edit50.Text = Nothing
            End If

            Edit1_1.Text = DtView1(0)("CUST_NAME")
            Edit1_2_0.Text = DtView1(0)("ZIP1") & "-" & DtView1(0)("ZIP2")
            Edit1_2_1.Text = DtView1(0)("ADRS1")
            Edit1_2_2.Text = DtView1(0)("ADRS2")
            Edit1_3.Text = DtView1(0)("TEL_NO")
            If Not IsDBNull(DtView1(0)("CNT_NO")) Then Edit1_4.Text = DtView1(0)("CNT_NO") Else Edit1_4.Text = Nothing

        End If

    End Sub

    '*************************************************
    '** 変更　SET
    '*************************************************
    Private Sub dsp_tag4()

        TabControl1.SelectedTab = TabPage4

        TextBox4_4.Text = Trim(Edit50.Text)
        TextBox4_1.Text = Trim(Edit1_1.Text)
        Edit1.Text = Mid(Edit1_2_0.Text, 1, 3) & Mid(Edit1_2_0.Text, 5, 4)
        TextBox4_2.Text = Trim(Edit1_2_1.Text)
        TextBox4_3.Text = Trim(Edit1_2_2.Text)
        Edit2.Text = Trim(Edit1_3.Text)
        Edit3.Text = Trim(Edit1_4.Text)
        TextBox4_6.Text = Nothing
        T_ComboBox17.Text = Trim(Edit1_9.Text)
        ComboBox18.SelectedValue = Label59.Text
        T_ComboBox19.Text = Trim(Edit1_18.Text)

        Label61.Text = Trim(Edit50.Text)
        Label62.Text = Trim(Edit1_1.Text)
        Label63.Text = Mid(Edit1_2_0.Text, 1, 3) & Mid(Edit1_2_0.Text, 5, 4)
        Label64.Text = Trim(Edit1_2_1.Text)
        Label65.Text = Trim(Edit1_2_2.Text)
        Label66.Text = Trim(Edit1_3.Text)
        Label67.Text = Trim(Edit1_4.Text)
        Label68.Text = Trim(Edit1_9.Text)
        Label69.Text = Label59.Text
        Label70.Text = Trim(Edit1_18.Text)

        Label120.Text = Label59.Text

        strSQL = "SELECT STTS_F_UPD.*"
        strSQL = strSQL & " FROM STTS_F_UPD"
        strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "') AND (UPD_F IS NULL) OR"
        strSQL = strSQL & " (WRN_NO = '" & pWrn_no & "') AND (UPD_F = '1')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "STTS_F_UPD2")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("STTS_F_UPD2"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            CheckBox4.Enabled = False
            CheckBox4.Checked = True
            RadioButton1.Visible = True
            RadioButton1.Enabled = False
            RadioButton2.Visible = True
            RadioButton2.Enabled = False
            RadioButton3.Visible = True
            RadioButton3.Enabled = False
            Select Case DtView1(0)("RSN_CODE")
                Case Is = "001"
                    RadioButton1.Checked = True
                Case Is = "002"
                    RadioButton2.Checked = True
                Case Is = "003"
                    RadioButton3.Checked = True
            End Select
            If Not IsDBNull(DtView1(0)("END_DATE")) Then
                Label104.Visible = True
                Date4.Visible = True
                Date4.Enabled = False
                Date4.Text = DtView1(0)("END_DATE")
            Else
                Date4.Visible = False
            End If
        End If

        If pEmpl_cls = "0" Then
            CheckBox4.Enabled = False
            Date4.Enabled = False
            RadioButton1.Enabled = False : RadioButton2.Enabled = False : RadioButton3.Enabled = False
            T_ComboBox17.Enabled = False
            ComboBox18.Enabled = False
            T_ComboBox19.Enabled = False
        End If

    End Sub

    '*************************************************
    '** Log　SET （登録）
    '*************************************************
    Private Sub dsp_tag3_n()

        TabControl1.SelectedTab = TabPage3

        Label3_1.Text = Format(Now(), "yyyy/MM/dd HH:mm")
        s_date = Now()
        Label3_2.Text = Nothing
        Label3_3.Text = pName
        Label3_4.Text = Edit1_1.Text
        Button1.Text = "登  録"

        Dim SqlSelectCommand As New SqlClient.SqlCommand

        Edit01.Text = Nothing
        Edit02.Text = Nothing
        CheckBox1.Checked = False

        RadioButton8.Checked = False
        RadioButton9.Checked = False

        Label134.Text = Label59.Text
        If Edit1_10.Text <> Nothing Then
            ComboBox4.SelectedValue = Label59.Text
        Else
            ComboBox4.SelectedValue = ""
            ComboBox4.Text = Nothing
        End If
        T_ComboBox5.Text = Trim(Edit1_9.Text)
        ComboBox6.SelectedValue = Label126.Text

        Dim R_YYYYMM As String = A_YYYYMM(Edit1_7.Text)
        Dim POS As Integer = R_YYYYMM.LastIndexOf("/")
        If Mid(R_YYYYMM, 1, POS) <= 4 Then
            ComboBox7.SelectedValue = "00" & Mid(R_YYYYMM, 1, POS)
        Else
            Label137.Text = Nothing
            Label138.Text = Nothing
        End If

        Select Case CInt(Mid(R_YYYYMM, POS + 2, Len(R_YYYYMM) - POS - 1))
            Case Is <= 9
                ComboBox8.SelectedValue = "00" & Mid(R_YYYYMM, POS + 2, Len(R_YYYYMM) - POS - 1)
            Case Is <= 12
                ComboBox8.SelectedValue = "0" & Mid(R_YYYYMM, POS + 2, Len(R_YYYYMM) - POS - 1)
            Case Else
                Label137.Text = Nothing
                Label138.Text = Nothing
        End Select

        Label139.Text = Nothing
        Label140.Text = Nothing
        Label141.Text = Nothing
        Label142.Text = Nothing

        Label122.Text = Nothing
        Label123.Text = Nothing
        Label124.Text = Nothing
        Label6.Text = Nothing
        Edit4.Text = Trim(Edit1_4.Text)
        Edit5.Text = Nothing

        If Label1_17.Text <> "A" Then
            Call Enabled_TAB3()
        End If

    End Sub

    '*************************************************
    '** Log　SET （追加）（照会）
    '*************************************************
    Private Sub dsp_tag3_r()

        TabControl1.SelectedTab = TabPage3

        Label3_1.Text = Format(Now(), "yyyy/MM/dd HH:mm")
        s_date = Now()
        Label3_2.Text = pIcdt_no

        Dim SqlSelectCommand As New SqlClient.SqlCommand

        SqlSelectCommand.CommandText = "SELECT ICDT_DATA.*, EMPL.EMPL_NAME, WRN_DATA.CUST_NAME, ICDT_DTL.RPLY, ICDT_DTL.RPLY_CLS FROM ICDT_DTL RIGHT OUTER JOIN ICDT_DATA ON ICDT_DTL.ICDT_NO = ICDT_DATA.ICDT_NO LEFT OUTER JOIN WRN_DATA ON ICDT_DATA.WRN_NO = WRN_DATA.WRN_NO LEFT OUTER JOIN EMPL ON ICDT_DATA.EMPL_CODE = EMPL.EMPL_CODE WHERE ICDT_DATA.ICDT_NO = '" & pIcdt_no & "' ORDER BY ICDT_DTL.RCV_DATE DESC"
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        Dataadp1.SelectCommand = SqlSelectCommand

        DB_OPEN()
        Dataadp1.Fill(Dataset1, "ICDT_DATA")
        DB_CLOSE()

        Dttbl1 = Dataset1.Tables("ICDT_DATA")

        If Dttbl1.Rows(0)("CLM_FLG").ToString = "1" Then
            CheckBox1.Checked = True
        End If

        fst_empl_code = RTrim(Dttbl1.Rows(0)("EMPL_CODE"))
        Label3_3.Text = Dttbl1.Rows(0)("EMPL_NAME")
        Label3_4.Text = Dttbl1.Rows(0)("CUST_NAME").ToString
        Edit01.Text = RTrim(Dttbl1.Rows(0)("ASKING"))
        Edit02.Text = RTrim(Dttbl1.Rows(0)("RPLY"))

        ComboBox1.SelectedValue = Dttbl1.Rows(0)("CUST_CLS")
        ComboBox3_2.SelectedValue = Dttbl1.Rows(0)("ICDT_CLS")
        ComboBox3_3.SelectedValue = Dttbl1.Rows(0)("STATUS")
        ComboBox3_4.SelectedValue = Dttbl1.Rows(0)("RPLY_CLS")
        ComboBox3_5.SelectedValue = Dttbl1.Rows(0)("REP_IRAI")
        Label131.Text = Dttbl1.Rows(0)("CUST_CLS")
        Label122.Text = Dttbl1.Rows(0)("ICDT_CLS")
        Label123.Text = Dttbl1.Rows(0)("STATUS")
        Label124.Text = Dttbl1.Rows(0)("RPLY_CLS")
        Label6.Text = Dttbl1.Rows(0)("REP_IRAI")

        If Not IsDBNull(Dttbl1.Rows(0)("SEX")) Then
            If Dttbl1.Rows(0)("SEX") = "1" Then
                RadioButton9.Checked = True
            Else
                RadioButton8.Checked = True
            End If
        Else
            RadioButton9.Checked = True
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("CAT_CODE")) Then
            ComboBox4.SelectedValue = Dttbl1.Rows(0)("CAT_CODE")
        Else
            Label134.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("MKR_NAME")) Then
            T_ComboBox5.Text = Trim(Dttbl1.Rows(0)("MKR_NAME"))
        Else
            T_ComboBox5.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("SHOP_CODE")) Then
            ComboBox6.SelectedValue = Dttbl1.Rows(0)("SHOP_CODE")
        Else
            Label136.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("YEAR_CLS")) Then
            ComboBox7.SelectedValue = Dttbl1.Rows(0)("YEAR_CLS")
        Else
            Label137.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("MONTHS_CLS")) Then
            ComboBox8.SelectedValue = Dttbl1.Rows(0)("MONTHS_CLS")
        Else
            Label138.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("CALL1_CLS")) Then
            ComboBox9.SelectedValue = Dttbl1.Rows(0)("CALL1_CLS")
        Else
            Label139.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("CALL2_CLS")) Then
            ComboBox10.SelectedValue = Dttbl1.Rows(0)("CALL2_CLS")
        Else
            Label140.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("RPLY_CLS1")) Then
            ComboBox11.SelectedValue = Dttbl1.Rows(0)("RPLY_CLS1")
        Else
            Label141.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("RPLY_CLS2")) Then
            ComboBox12.SelectedValue = Dttbl1.Rows(0)("RPLY_CLS2")
        Else
            Label142.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("CNT_NO")) Then
            Edit4.Text = Trim(Dttbl1.Rows(0)("CNT_NO"))
        Else
            Edit4.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("REP_NO")) Then
            Edit5.Text = Trim(Dttbl1.Rows(0)("REP_NO"))
        Else
            Edit5.Text = Nothing
        End If

        If Dttbl1.Rows(0)("FIN_FLAG") = "1" Then    '完了済み
            Call Enabled_TAB3()
        End If

    End Sub

    '*************************************************
    '** 基本情報の処理
    '*************************************************

    'ﾌﾘｶﾞﾅ入力
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        pKANA = Trim(Edit50.Text)
        Dim KANA_input As New KANA_input
        KANA_input.ShowDialog()
        If pKANA <> Nothing Then
            Edit50.Text = pKANA
            TextBox4_4.Text = pKANA
            Label61.Text = pKANA
        End If
    End Sub

    '*************************************************
    '** ｌｏｇの処理
    '*************************************************

    '入力後

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        If RTrim(ComboBox1.Text) = Nothing Then
            Label131.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("CUST_CLS"), "NAME='" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label131.Text = Nothing
            Else
                Label131.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.Leave
        If RTrim(ComboBox4.Text) = Nothing Then
            Label134.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_category2"), "CAT_NAME='" & ComboBox4.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label134.Text = Nothing
            Else
                Label134.Text = DtView1(0)("CAT_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.Leave
        If RTrim(ComboBox6.Text) = Nothing Then
            Label136.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("SHOP2"), "SHOP_NAME='" & ComboBox6.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label136.Text = Nothing
            Else
                Label136.Text = DtView1(0)("SHOP_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox7_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox7.Leave
        If RTrim(ComboBox7.Text) = Nothing Then
            Label137.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("YEAR_CLS"), "NAME='" & ComboBox7.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label137.Text = Nothing
            Else
                Label137.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox8_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.Leave
        If RTrim(ComboBox8.Text) = Nothing Then
            Label138.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("MONTHS_CLS"), "NAME='" & ComboBox8.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label138.Text = Nothing
            Else
                Label138.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox9_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.Leave
        If RTrim(ComboBox9.Text) = Nothing Then
            Label139.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("CALL1_CLS"), "NAME='" & ComboBox9.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label139.Text = Nothing
            Else
                Label139.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.Leave
        If RTrim(ComboBox10.Text) = Nothing Then
            Label140.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("CALL2_CLS"), "NAME='" & ComboBox10.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label140.Text = Nothing
            Else
                Label140.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox11_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox11.Leave
        If RTrim(ComboBox11.Text) = Nothing Then
            Label141.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("RPLY_CLS1"), "NAME='" & ComboBox11.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label141.Text = Nothing
            Else
                Label141.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox12_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.Leave
        If RTrim(ComboBox12.Text) = Nothing Then
            Label142.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("RPLY_CLS2"), "NAME='" & ComboBox12.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label142.Text = Nothing
            Else
                Label142.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox3_2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3_2.Leave
        If RTrim(ComboBox3_2.Text) = Nothing Then
            Label122.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("ICDT_CLS"), "NAME='" & ComboBox3_2.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label122.Text = Nothing
            Else
                Label122.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox3_3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3_3.Leave
        If RTrim(ComboBox3_3.Text) = Nothing Then
            Label123.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("STS_CLS"), "NAME='" & ComboBox3_3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label123.Text = Nothing
            Else
                Label123.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox3_4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3_4.Leave
        If RTrim(ComboBox3_4.Text) = Nothing Then
            Label124.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("STS_RPLY"), "NAME='" & ComboBox3_4.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label124.Text = Nothing
            Else
                Label124.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox3_5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3_5.Leave
        If RTrim(ComboBox3_5.Text) = Nothing Then
            Label6.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("CLS_002"), "NAME='" & ComboBox3_5.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label6.Text = Nothing
            Else
                Label6.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    '対応履歴表示
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor.Current = Cursors.WaitCursor
        dsp_mode = "w"
        Dim frmform4 As New Form4
        frmform4.ShowDialog()
        Me.Cursor.Current = Cursors.Default
    End Sub

    '登録／追加／完了
    'TAG3
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Call Err_Chk3()
        If Err_F = "0" Then

            If CheckBox1.Checked = True Then
                clm_flg = "1"
            Else
                clm_flg = "0"
            End If

            If ComboBox3_3.SelectedValue = "004" Then
                fin_flg = "1"
            Else
                fin_flg = "0"
            End If

            Dim SqlInsertCommand As New SqlClient.SqlCommand

            If RTrim(Label3_2.Text) <> Nothing Then

                Dim SqlUpdateCommand As New SqlClient.SqlCommand
                strSQL = "UPDATE ICDT_DATA"
                strSQL = strSQL & " SET CLM_FLG = '" & clm_flg & "'"
                strSQL = strSQL & ", FIN_FLAG = '" & fin_flg & "'"
                strSQL = strSQL & ", CUST_CLS = '" & ComboBox1.SelectedValue & "'"
                strSQL = strSQL & ", ICDT_CLS = '" & ComboBox3_2.SelectedValue & "'"
                strSQL = strSQL & ", ASKING = '" & Edit01.Text & "'"
                strSQL = strSQL & ", STATUS = '" & ComboBox3_3.SelectedValue & "'"
                strSQL = strSQL & ", REP_IRAI = '" & ComboBox3_5.SelectedValue & "'"
                If RadioButton9.Checked = True Then
                    strSQL = strSQL & ", SEX = '1'"
                Else
                    strSQL = strSQL & ", SEX = '2'"
                End If
                If Trim(ComboBox4.Text) <> Nothing Then
                    strSQL = strSQL & ", CAT_CODE = '" & ComboBox4.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", CAT_CODE = NULL"
                End If
                If Trim(T_ComboBox5.Text) <> Nothing Then
                    strSQL = strSQL & ", MKR_NAME = '" & T_ComboBox5.Text & "'"
                Else
                    strSQL = strSQL & ", MKR_NAME = NULL"
                End If
                If Trim(ComboBox6.Text) <> Nothing Then
                    strSQL = strSQL & ", SHOP_CODE = '" & ComboBox6.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", SHOP_CODE = NULL"
                End If
                If Trim(ComboBox7.Text) <> Nothing Then
                    strSQL = strSQL & ", YEAR_CLS = '" & ComboBox7.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", YEAR_CLS = NULL"
                End If
                If Trim(ComboBox8.Text) <> Nothing Then
                    strSQL = strSQL & ", MONTHS_CLS = '" & ComboBox8.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", MONTHS_CLS = NULL"
                End If
                If Trim(ComboBox9.Text) <> Nothing Then
                    strSQL = strSQL & ", CALL1_CLS = '" & ComboBox9.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", CALL1_CLS = NULL"
                End If
                If Trim(ComboBox10.Text) <> Nothing Then
                    strSQL = strSQL & ", CALL2_CLS = '" & ComboBox10.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", CALL2_CLS = NULL"
                End If
                strSQL = strSQL & ", RPLY_CLS1 = '" & ComboBox11.SelectedValue & "'"
                strSQL = strSQL & ", RPLY_CLS2 = '" & ComboBox12.SelectedValue & "'"
                strSQL = strSQL & ", CNT_NO = '" & Edit4.Text & "'"
                strSQL = strSQL & ", REP_NO = '" & Edit5.Text & "'"

                strSQL = strSQL & " WHERE ICDT_NO = '" & pIcdt_no & "'"
                SqlUpdateCommand.CommandText = strSQL
                SqlUpdateCommand.CommandType = CommandType.Text
                SqlUpdateCommand.Connection = cnsqlclient

                SqlInsertCommand.CommandText = "INSERT INTO ICDT_DTL(ICDT_NO, RCV_DATE, RPLY, EMPL_CODE, RPLY_CLS, END_DATE, STATUS) " & _
                                                "VALUES ('" & Label3_2.Text & "', '" & s_date & "', '" & Edit02.Text & "', '" & pEmpl_code & "', '" & ComboBox3_4.SelectedValue & "', '" & Now() & "', '" & ComboBox3_3.SelectedValue & "')"
                SqlInsertCommand.CommandType = CommandType.Text
                SqlInsertCommand.Connection = cnsqlclient

                Try
                    DB_OPEN()
                    SqlUpdateCommand.ExecuteNonQuery()
                    SqlInsertCommand.ExecuteNonQuery()
                    DB_CLOSE()
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message)
                    DB_CLOSE()
                End Try
                MsgBox("対応ログを追加しました。", MsgBoxStyle.OKOnly, "Warranty System")
                Button1.Enabled = False
            Else

                Label3_2.Text = Count_Get_001()
                pIcdt_no = Label3_2.Text

                strSQL = "INSERT INTO ICDT_DATA (ICDT_NO, WRN_NO, CLM_FLG, FIN_FLAG, CUST_CLS, ICDT_CLS, ASKING, STATUS, REP_IRAI, SEX, CAT_CODE, MKR_NAME, SHOP_CODE, YEAR_CLS, MONTHS_CLS, CALL1_CLS, CALL2_CLS, RPLY_CLS1, RPLY_CLS2, CNT_NO, REP_NO, EMPL_CODE)"
                strSQL = strSQL & " VALUES ('" & pIcdt_no & "'"
                strSQL = strSQL & ", '" & pWrn_no & "'"
                strSQL = strSQL & ", '" & clm_flg & "'"
                strSQL = strSQL & ", '" & fin_flg & "'"
                strSQL = strSQL & ", '" & ComboBox1.SelectedValue & "'"
                strSQL = strSQL & ", '" & ComboBox3_2.SelectedValue & "'"
                strSQL = strSQL & ", '" & Edit01.Text & "'"
                strSQL = strSQL & ", '" & ComboBox3_3.SelectedValue & "'"
                strSQL = strSQL & ", '" & ComboBox3_5.SelectedValue & "'"
                If RadioButton9.Checked = True Then
                    strSQL = strSQL & ", '1'"
                Else
                    strSQL = strSQL & ", '2'"
                End If
                If Trim(ComboBox4.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox4.SelectedValue & "'"
                End If
                If Trim(T_ComboBox5.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & Trim(T_ComboBox5.Text) & "'"
                End If
                If Trim(ComboBox6.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox6.SelectedValue & "'"
                End If
                If Trim(ComboBox7.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox7.SelectedValue & "'"
                End If
                If Trim(ComboBox8.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox8.SelectedValue & "'"
                End If
                If Trim(ComboBox9.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox9.SelectedValue & "'"
                End If
                If Trim(ComboBox10.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox10.SelectedValue & "'"
                End If
                strSQL = strSQL & ", '" & ComboBox11.SelectedValue & "'"
                strSQL = strSQL & ", '" & ComboBox12.SelectedValue & "'"
                strSQL = strSQL & ", '" & Trim(Edit4.Text) & "'"
                strSQL = strSQL & ", '" & Trim(Edit5.Text) & "'"
                strSQL = strSQL & ", '" & pEmpl_code & "')"
                SqlInsertCommand.CommandText = strSQL
                SqlInsertCommand.CommandType = CommandType.Text
                SqlInsertCommand.Connection = cnsqlclient

                Dim SqlInsertCommand2 As New SqlClient.SqlCommand
                SqlInsertCommand2.CommandText = "INSERT INTO ICDT_DTL(ICDT_NO, RCV_DATE, RPLY, EMPL_CODE, RPLY_CLS, END_DATE, STATUS)  " & _
                                                "VALUES ('" & pIcdt_no & "', '" & s_date & "', '" & Edit02.Text & "', '" & pEmpl_code & "', '" & ComboBox3_4.SelectedValue & "', '" & Now() & "', '" & ComboBox3_3.SelectedValue & "')"
                SqlInsertCommand2.CommandType = CommandType.Text
                SqlInsertCommand2.Connection = cnsqlclient

                Try
                    DB_OPEN()
                    SqlInsertCommand.ExecuteNonQuery()
                    SqlInsertCommand2.ExecuteNonQuery()
                    DB_CLOSE()
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message)
                    DB_CLOSE()
                End Try
                MsgBox("受付番号:" & pIcdt_no & "で登録しました。", MsgBoxStyle.OKOnly, "Warranty System")
                Button1.Enabled = False
            End If

        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub Err_Chk3()
        Err_F = "0"

        '権限
        If RTrim(Label3_2.Text) <> Nothing Then
            If RTrim(Dttbl1.Rows(0)("EMPL_CODE")) <> pEmpl_code And ComboBox3_3.SelectedValue = "004" Then
                MsgBox("ステイタスを「対応済み」にする権限がありません。" & vbCrLf & "「対応済み」をチェックしてください。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox3_3.SelectedValue = Dttbl1.Rows(0)("STATUS")
                Err_F = "1" : Exit Sub
            End If
        End If

        ''内容
        'If LenB(Edit01.Text) > 2000 Then
        '    MessageBox.Show("問合せ内容が2000バイトを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Err_F = "1" : Exit Sub
        'ElseIf LenB(Edit02.Text) > 2000 Then
        '    MessageBox.Show("回答内容が2000バイトを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Err_F = "1" : Exit Sub
        'End If


        '相手先属性
        If Trim(ComboBox1.Text) = Nothing Then
            MsgBox("相手先を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox1.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("CUST_CLS"), "NAME='" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する相手先がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox1.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox1.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '商品ｶﾃｺﾞﾘｰ
        If Trim(ComboBox4.Text) = Nothing Then
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_category2"), "CAT_NAME='" & ComboBox4.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する商品ｶﾃｺﾞﾘｰがありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox4.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox4.SelectedValue = DtView1(0)("CAT_CODE")
            End If
        End If

        'メーカー

        '購入店舗
        If Trim(ComboBox6.Text) = Nothing Then
        Else
            DtView1 = New DataView(P_DsCMB.Tables("SHOP2"), "SHOP_NAME='" & ComboBox6.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する購入店舗がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox6.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox6.SelectedValue = DtView1(0)("SHOP_CODE")
            End If
        End If

        '購入後　年
        If Trim(ComboBox7.Text) = Nothing Then
        Else
            DtView1 = New DataView(P_DsCMB.Tables("YEAR_CLS"), "NAME='" & ComboBox7.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する購入後　年がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox7.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox7.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '購入後　月
        If Trim(ComboBox8.Text) = Nothing Then
        Else
            DtView1 = New DataView(P_DsCMB.Tables("MONTHS_CLS"), "NAME='" & ComboBox8.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する購入後　月がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox8.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox8.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '性別
        If RadioButton8.Checked = False And RadioButton9.Checked = False Then
            MsgBox("性別を選択してください。", MsgBoxStyle.Exclamation, "Warranty System")
            RadioButton9.Focus()
            Err_F = "1" : Exit Sub
        End If

        'コール内容
        If Trim(ComboBox9.Text) = Nothing Then
            If Trim(ComboBox10.Text) = Nothing Then
                MsgBox("コール内容を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox9.Focus()
                Err_F = "1" : Exit Sub
            Else
                '意見・要望系
                If Trim(ComboBox10.Text) = Nothing Then
                Else
                    DtView1 = New DataView(P_DsCMB.Tables("CALL2_CLS"), "NAME='" & ComboBox10.Text & "'", "", DataViewRowState.CurrentRows)
                    If DtView1.Count = 0 Then
                        MsgBox("該当する意見・要望系がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                        ComboBox10.Focus()
                        Err_F = "1" : Exit Sub
                    Else
                        ComboBox10.SelectedValue = DtView1(0)("CLS_CODE")
                    End If
                End If
            End If
        Else
            If Trim(ComboBox10.Text) = Nothing Then
                '不具合系
                If Trim(ComboBox9.Text) = Nothing Then
                Else
                    DtView1 = New DataView(P_DsCMB.Tables("CALL1_CLS"), "NAME='" & ComboBox9.Text & "'", "", DataViewRowState.CurrentRows)
                    If DtView1.Count = 0 Then
                        MsgBox("該当する不具合系がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                        ComboBox9.Focus()
                        Err_F = "1" : Exit Sub
                    Else
                        ComboBox9.SelectedValue = DtView1(0)("CLS_CODE")
                    End If
                End If
            Else
                MsgBox("コール内容は不具合系か意見・要望系の一方しか入力できません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox9.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '対応結果１
        If Trim(ComboBox11.Text) = Nothing Then
            MsgBox("対応結果１を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox11.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("RPLY_CLS1"), "NAME='" & ComboBox11.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する対応結果１がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox11.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox11.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '対応結果２
        If Trim(ComboBox12.Text) = Nothing Then
            MsgBox("対応結果２を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox12.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("RPLY_CLS2"), "NAME='" & ComboBox12.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する対応結果２がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox12.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox12.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '問合せ区分
        If Trim(ComboBox3_2.Text) = Nothing Then
            MsgBox("問合せ区分を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox3_2.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("ICDT_CLS"), "NAME='" & ComboBox3_2.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する問合せ区分がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox3_2.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox3_2.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        'ステイタス
        If Trim(ComboBox3_3.Text) = Nothing Then
            MsgBox("ステイタスを入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox3_3.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("STS_CLS"), "NAME='" & ComboBox3_3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当するステイタスがありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox3_3.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox3_3.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '修理依頼先
        If Trim(ComboBox3_5.Text) = Nothing Then
            MsgBox("修理依頼先を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox3_5.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("CLS_002"), "NAME='" & ComboBox3_5.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する修理依頼先がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox3_5.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox3_5.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '修理受付№
        If Trim(Edit5.Text) = Nothing Then
            MsgBox("修理受付№を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            Edit5.Focus()
            Err_F = "1" : Exit Sub
        End If

        '回答区分
        If Trim(ComboBox3_4.Text) = Nothing Then
            MsgBox("回答区分を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox3_4.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("STS_RPLY"), "NAME='" & ComboBox3_4.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する回答区分がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox3_4.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox3_4.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '連絡先電話番号
        If Trim(Edit4.Text) = Nothing Then
            MsgBox("連絡先電話番号を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            Edit4.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '*************************************************
    '** 変更の処理
    '*************************************************

    '入力後
    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            RadioButton1.Visible = True
            RadioButton2.Visible = True
            RadioButton3.Visible = True
            Label104.Visible = True
            Date4.Visible = True
            Date4.Focus()
        Else
            RadioButton1.Visible = False
            RadioButton2.Visible = False
            RadioButton3.Visible = False
            Label104.Visible = False
            Date4.Visible = False
        End If
    End Sub

    Private Sub ComboBox18_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox18.Leave
        If RTrim(ComboBox18.Text) = Nothing Then
            Label120.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_category"), "CAT_NAME='" & ComboBox18.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label120.Text = Nothing
            Else
                Label120.Text = DtView1(0)("CAT_CODE")
            End If
        End If
    End Sub

    'クリア
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Edit1.Text = Nothing
        Edit2.Text = Nothing
        Edit3.Text = Nothing
        TextBox4_1.Text = Nothing
        TextBox4_2.Text = Nothing
        TextBox4_3.Text = Nothing
        TextBox4_4.Text = Nothing
        TextBox4_6.Text = Nothing
        If Label1_17.Text = "A" Then
            CheckBox4.Focus()
        Else
            CheckBox4.Enabled = False
            TextBox4_4.Focus()
        End If
    End Sub

    '変更履歴表示
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor.Current = Cursors.WaitCursor
        Dim frmform5 As New Form5
        frmform5.ShowDialog()
        Me.Cursor.Current = Cursors.Default
    End Sub

    '変更
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor.Current = Cursors.WaitCursor
        Now_date = Now

        Call F_Check()
        If Err_F = "0" Then
            upd_flg = Nothing

            '加入状況
            If CheckBox4.Checked = True And CheckBox4.Enabled = True Then
                strSQL = "INSERT INTO STTS_F_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_DATE, RSN_CODE, END_DATE)"
                strSQL = strSQL & "VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                If RadioButton1.Checked = True Then
                    strSQL = strSQL & ", '001'"
                Else
                    If RadioButton2.Checked = True Then
                        strSQL = strSQL & ", '002'"
                    Else
                        strSQL = strSQL & ", '003'"
                    End If
                End If
                strSQL = strSQL & ", '" & Date4.Text & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", 'F'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '008'"
                strSQL = strSQL & ", '" & RTrim(Label1_17.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                CheckBox4.Enabled = False
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False
                RadioButton3.Enabled = False
                Date4.Enabled = False
                upd_flg = "1"
            End If

            '氏名（カナ）
            If RTrim(TextBox4_4.Text) <> RTrim(Label61.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET CUST_NAME_KANA = '" & RTrim(TextBox4_4.Text) & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_4.Text) & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '009'"
                strSQL = strSQL & ", '" & RTrim(Label61.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label61.Text = RTrim(TextBox4_4.Text)
                Edit50.Text = RTrim(TextBox4_4.Text)
                upd_flg = "1"
            End If

            '氏名（漢字）
            If RTrim(TextBox4_1.Text) <> RTrim(Label62.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET CUST_NAME = '" & RTrim(TextBox4_1.Text) & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_1.Text) & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '001'"
                strSQL = strSQL & ", '" & RTrim(Label62.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label62.Text = RTrim(TextBox4_1.Text)
                Edit1_1.Text = RTrim(TextBox4_1.Text)
                Label3_4.Text = RTrim(TextBox4_1.Text)
                upd_flg = "1"
            End If

            '郵便番号
            If RTrim(Edit1.Text) <> RTrim(Label63.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET ZIP1 = '" & Mid(Edit1.Text, 1, 3) & "'"
                strSQL = strSQL & ", ZIP2 = '" & Mid(Edit1.Text, 4, 4) & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & RTrim(Edit1.Text) & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '006'"
                strSQL = strSQL & ", '" & RTrim(Label63.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label63.Text = RTrim(Edit1.Text)
                Edit1_2_0.Text = RTrim(Edit1.Text)
                upd_flg = "1"
            End If

            '住所1
            If RTrim(TextBox4_2.Text) <> RTrim(Label64.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET ADRS1 = '" & RTrim(TextBox4_2.Text) & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_2.Text) & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '002'"
                strSQL = strSQL & ", '" & RTrim(Label64.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label64.Text = RTrim(TextBox4_2.Text)
                Edit1_2_1.Text = RTrim(TextBox4_2.Text)
                upd_flg = "1"
            End If

            '住所2
            If RTrim(TextBox4_3.Text) <> RTrim(Label65.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET ADRS2 = '" & RTrim(TextBox4_3.Text) & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_3.Text) & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '003'"
                strSQL = strSQL & ", '" & RTrim(Label65.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label65.Text = RTrim(TextBox4_3.Text)
                Edit1_2_2.Text = RTrim(TextBox4_3.Text)
                upd_flg = "1"
            End If

            '電話番号
            If RTrim(Edit2.Text) <> RTrim(Label66.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET TEL_NO = '" & RTrim(Edit2.Text) & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & RTrim(Edit2.Text) & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '004'"
                strSQL = strSQL & ", '" & RTrim(Label66.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label66.Text = RTrim(Edit2.Text)
                Edit1_3.Text = RTrim(Edit2.Text)
                upd_flg = "1"
            End If

            '連絡先番号
            If RTrim(Edit3.Text) <> RTrim(Label67.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET CNT_NO = '" & RTrim(Edit3.Text) & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & RTrim(Edit3.Text) & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '010'"
                strSQL = strSQL & ", '" & RTrim(Label67.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label67.Text = RTrim(Edit3.Text)
                Edit1_4.Text = RTrim(Edit3.Text)
                Edit4.Text = RTrim(Edit3.Text)
                upd_flg = "1"
            End If

            '品名
            T_ComboBox17.Text = Trim(T_ComboBox17.Text)
            If T_ComboBox17.Text <> Label68.Text Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET MKR_NAME = '" & T_ComboBox17.Text & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & T_ComboBox17.Text & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '011'"
                strSQL = strSQL & ", '" & RTrim(Edit1_9.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label68.Text = T_ComboBox17.Text
                Edit1_9.Text = T_ComboBox17.Text
                upd_flg = "1"
            End If

            '部門
            If Trim(Label120.Text) <> Trim(Label69.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET CAT_CODE = '" & ComboBox18.SelectedValue & "'"
                strSQL = strSQL & ", CAT_NAME = '" & ComboBox18.Text & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & ComboBox18.Text & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '012'"
                strSQL = strSQL & ", '" & RTrim(Edit1_10.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label69.Text = ComboBox18.SelectedValue
                Label59.Text = ComboBox18.SelectedValue
                Edit1_10.Text = ComboBox18.Text
                upd_flg = "1"
            End If

            '型式
            T_ComboBox19.Text = Trim(T_ComboBox19.Text)
            If T_ComboBox19.Text <> Label70.Text Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET MODEL = '" & T_ComboBox19.Text & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & T_ComboBox19.Text & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '013'"
                strSQL = strSQL & ", '" & RTrim(Edit1_18.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label70.Text = T_ComboBox19.Text
                Edit1_18.Text = T_ComboBox19.Text
                upd_flg = "1"
            End If
        End If

        If upd_flg = "1" Then
            MsgBox("変更しました。", MsgBoxStyle.OKOnly, "Warranty System")
        End If

        Me.Cursor.Current = Cursors.Default
    End Sub

    Sub F_Check()
        Err_F = "0"

        '補償／保証終了日
        If CheckBox4.Checked = True Then
            If Date4.Number = 0 Then
                MsgBox("加入状況:F の場合、補償／保証終了日は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
                Date4.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '氏名（カナ）

        '氏名（漢字）
        If RTrim(TextBox4_1.Text) = Nothing Then
            MsgBox("氏名（漢字）は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            TextBox4_1.Focus()
            Err_F = "1" : Exit Sub
        End If

        '品名
        If Trim(T_ComboBox17.Text) = Nothing Then
            MsgBox("品名は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            T_ComboBox17.Focus()
            Err_F = "1" : Exit Sub
        End If

        '商品カテゴリー
        If RTrim(ComboBox18.Text) = Nothing Then
            MsgBox("商品カテゴリーは入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox18.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_category2"), "CAT_NAME='" & ComboBox18.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する商品カテゴリーがありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox18.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox18.SelectedValue = DtView1(0)("CAT_CODE")
            End If
        End If

        '型式
        If Trim(T_ComboBox19.Text) = Nothing Then
            MsgBox("型式は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            T_ComboBox19.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '*************************************************
    '** 戻る
    '*************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        DsList1.Clear()
        DsList2.Clear()
        WK_DsList1.Clear()
        Me.Close()
    End Sub

    'Tab Select
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        If Label131.Text = Nothing Then ComboBox1.Text = Nothing

        WK_DtView1 = New DataView(P_DsCMB.Tables("M_category"), "CAT_CODE='" & Label134.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then ComboBox4.Text = Nothing

        If Label136.Text = Nothing Then ComboBox6.Text = Nothing
        If Label137.Text = Nothing Then ComboBox7.Text = Nothing
        If Label138.Text = Nothing Then ComboBox8.Text = Nothing
        If Label139.Text = Nothing Then ComboBox9.Text = Nothing
        If Label140.Text = Nothing Then ComboBox10.Text = Nothing
        If Label141.Text = Nothing Then ComboBox11.Text = Nothing
        If Label142.Text = Nothing Then ComboBox12.Text = Nothing

        WK_DtView1 = New DataView(P_DsCMB.Tables("M_category2"), "CAT_CODE='" & Label120.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then ComboBox18.Text = Nothing

        If Label122.Text = Nothing Then ComboBox3_2.Text = Nothing
        If Label123.Text = Nothing Then ComboBox3_3.Text = Nothing
        If Label124.Text = Nothing Then ComboBox3_4.Text = Nothing
        If Label6.Text = Nothing Then ComboBox3_5.Text = Nothing

    End Sub

    'Tab Enabled
    Sub Enabled_TAB3()  'LOG
        CheckBox1.Enabled = False
        Edit01.Enabled = False
        Edit02.Enabled = False
        ComboBox1.Enabled = False
        ComboBox4.Enabled = False
        T_ComboBox5.Enabled = False
        ComboBox6.Enabled = False
        ComboBox7.Enabled = False
        ComboBox8.Enabled = False
        ComboBox9.Enabled = False
        ComboBox10.Enabled = False
        ComboBox11.Enabled = False
        ComboBox12.Enabled = False
        RadioButton8.Enabled = False
        RadioButton9.Enabled = False
        ComboBox3_2.Enabled = False
        ComboBox3_3.Enabled = False
        ComboBox3_4.Enabled = False
        ComboBox3_5.Enabled = False
        Edit4.Enabled = False
        Edit5.Enabled = False
        Button1.Visible = False
    End Sub
End Class
