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
    Dim clm_flg, fst_empl_code, ID, fin_flg, upd_flg, head_ltr As String
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1_1 As System.Windows.Forms.Label
    Friend WithEvents Label1_3 As System.Windows.Forms.Label
    Friend WithEvents Label1_4 As System.Windows.Forms.Label
    Friend WithEvents Label1_5 As System.Windows.Forms.Label
    Friend WithEvents Label1_7 As System.Windows.Forms.Label
    Friend WithEvents Label1_9 As System.Windows.Forms.Label
    Friend WithEvents Label1_10 As System.Windows.Forms.Label
    Friend WithEvents Label1_12 As System.Windows.Forms.Label
    Friend WithEvents Label1_13 As System.Windows.Forms.Label
    Friend WithEvents Label1_14 As System.Windows.Forms.Label
    Friend WithEvents Label1_15 As System.Windows.Forms.Label
    Friend WithEvents Label1_16 As System.Windows.Forms.Label
    Friend WithEvents Label1_11 As System.Windows.Forms.Label
    Friend WithEvents Label1_17 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1_18 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label3_1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label3_2 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label1_2_1 As System.Windows.Forms.Label
    Friend WithEvents Label1_2_2 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4_1 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_3 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ComboBox3_4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3_3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3_2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_6 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label3_3 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label3_4 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label1_2_0 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Button_txt As System.Windows.Forms.Button
    Friend WithEvents TextBox_CSV As System.Windows.Forms.TextBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label1_6 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents TextBox4_4 As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit6 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date3 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Date4 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label105 As System.Windows.Forms.Label
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
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox16 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox18 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox17 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents RadioButton10 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents ComboBox13 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox14 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox15 As System.Windows.Forms.ComboBox
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents Label146 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents Label149 As System.Windows.Forms.Label
    Friend WithEvents Label1_19 As System.Windows.Forms.Label
    Friend WithEvents Label1_20 As System.Windows.Forms.Label
    Friend WithEvents Label152 As System.Windows.Forms.Label
    Friend WithEvents Label1_21 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ComboBox19 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1_22 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form3))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button11 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label1_21 = New System.Windows.Forms.Label
        Me.Label1_20 = New System.Windows.Forms.Label
        Me.Label152 = New System.Windows.Forms.Label
        Me.Label1_19 = New System.Windows.Forms.Label
        Me.Label149 = New System.Windows.Forms.Label
        Me.Label127 = New System.Windows.Forms.Label
        Me.Label126 = New System.Windows.Forms.Label
        Me.Label125 = New System.Windows.Forms.Label
        Me.Label105 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label1_6 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.TextBox_CSV = New System.Windows.Forms.TextBox
        Me.Button_txt = New System.Windows.Forms.Button
        Me.Label1_2_0 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label1_2_2 = New System.Windows.Forms.Label
        Me.Label1_18 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1_11 = New System.Windows.Forms.Label
        Me.Label1_17 = New System.Windows.Forms.Label
        Me.Label1_16 = New System.Windows.Forms.Label
        Me.Label1_15 = New System.Windows.Forms.Label
        Me.Label1_14 = New System.Windows.Forms.Label
        Me.Label1_13 = New System.Windows.Forms.Label
        Me.Label1_12 = New System.Windows.Forms.Label
        Me.Label1_10 = New System.Windows.Forms.Label
        Me.Label1_9 = New System.Windows.Forms.Label
        Me.Label1_7 = New System.Windows.Forms.Label
        Me.Label1_5 = New System.Windows.Forms.Label
        Me.Label1_4 = New System.Windows.Forms.Label
        Me.Label1_3 = New System.Windows.Forms.Label
        Me.Label1_2_1 = New System.Windows.Forms.Label
        Me.Label1_1 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label142 = New System.Windows.Forms.Label
        Me.Label141 = New System.Windows.Forms.Label
        Me.Label140 = New System.Windows.Forms.Label
        Me.Label139 = New System.Windows.Forms.Label
        Me.Label138 = New System.Windows.Forms.Label
        Me.Label137 = New System.Windows.Forms.Label
        Me.Label136 = New System.Windows.Forms.Label
        Me.Label135 = New System.Windows.Forms.Label
        Me.Label134 = New System.Windows.Forms.Label
        Me.Label133 = New System.Windows.Forms.Label
        Me.Label132 = New System.Windows.Forms.Label
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
        Me.ComboBox5 = New System.Windows.Forms.ComboBox
        Me.Label114 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label115 = New System.Windows.Forms.Label
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label116 = New System.Windows.Forms.Label
        Me.Label117 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label118 = New System.Windows.Forms.Label
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
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3_1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label121 = New System.Windows.Forms.Label
        Me.Label120 = New System.Windows.Forms.Label
        Me.Label119 = New System.Windows.Forms.Label
        Me.Label104 = New System.Windows.Forms.Label
        Me.Date4 = New GrapeCity.Win.Input.Interop.Date
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
        Me.ComboBox19 = New System.Windows.Forms.ComboBox
        Me.ComboBox18 = New System.Windows.Forms.ComboBox
        Me.ComboBox17 = New System.Windows.Forms.ComboBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.Label57 = New System.Windows.Forms.Label
        Me.TextBox4_4 = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Edit3 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label54 = New System.Windows.Forms.Label
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
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
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.Label148 = New System.Windows.Forms.Label
        Me.Label147 = New System.Windows.Forms.Label
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Label145 = New System.Windows.Forms.Label
        Me.Label146 = New System.Windows.Forms.Label
        Me.ComboBox15 = New System.Windows.Forms.ComboBox
        Me.Label144 = New System.Windows.Forms.Label
        Me.ComboBox14 = New System.Windows.Forms.ComboBox
        Me.ComboBox13 = New System.Windows.Forms.ComboBox
        Me.Label143 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label130 = New System.Windows.Forms.Label
        Me.Label129 = New System.Windows.Forms.Label
        Me.Label128 = New System.Windows.Forms.Label
        Me.Label103 = New System.Windows.Forms.Label
        Me.Label102 = New System.Windows.Forms.Label
        Me.Label87 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton10 = New System.Windows.Forms.RadioButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.ComboBox16 = New System.Windows.Forms.ComboBox
        Me.Date3 = New GrapeCity.Win.Input.Interop.Date
        Me.Date2 = New GrapeCity.Win.Input.Interop.Date
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.Edit6 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit5 = New GrapeCity.Win.Input.Interop.Edit
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Edit4 = New GrapeCity.Win.Input.Interop.Edit
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label101 = New System.Windows.Forms.Label
        Me.Label100 = New System.Windows.Forms.Label
        Me.Label99 = New System.Windows.Forms.Label
        Me.Label98 = New System.Windows.Forms.Label
        Me.Label97 = New System.Windows.Forms.Label
        Me.Label96 = New System.Windows.Forms.Label
        Me.Label95 = New System.Windows.Forms.Label
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Label94 = New System.Windows.Forms.Label
        Me.Label93 = New System.Windows.Forms.Label
        Me.Label92 = New System.Windows.Forms.Label
        Me.Label91 = New System.Windows.Forms.Label
        Me.Label90 = New System.Windows.Forms.Label
        Me.Label89 = New System.Windows.Forms.Label
        Me.Label88 = New System.Windows.Forms.Label
        Me.Label86 = New System.Windows.Forms.Label
        Me.Label85 = New System.Windows.Forms.Label
        Me.Label84 = New System.Windows.Forms.Label
        Me.Label83 = New System.Windows.Forms.Label
        Me.Label82 = New System.Windows.Forms.Label
        Me.Label81 = New System.Windows.Forms.Label
        Me.Label80 = New System.Windows.Forms.Label
        Me.Label79 = New System.Windows.Forms.Label
        Me.Label78 = New System.Windows.Forms.Label
        Me.Label77 = New System.Windows.Forms.Label
        Me.Label76 = New System.Windows.Forms.Label
        Me.Label75 = New System.Windows.Forms.Label
        Me.Label74 = New System.Windows.Forms.Label
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label71 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label1_22 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(8, 624)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(920, 3)
        Me.PictureBox1.TabIndex = 143
        Me.PictureBox1.TabStop = False
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(816, 640)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(96, 30)
        Me.Button11.TabIndex = 9
        Me.Button11.Text = "戻　る"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(16, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(904, 568)
        Me.TabControl1.TabIndex = 174
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1_21)
        Me.TabPage1.Controls.Add(Me.Label1_20)
        Me.TabPage1.Controls.Add(Me.Label152)
        Me.TabPage1.Controls.Add(Me.Label1_19)
        Me.TabPage1.Controls.Add(Me.Label149)
        Me.TabPage1.Controls.Add(Me.Label127)
        Me.TabPage1.Controls.Add(Me.Label126)
        Me.TabPage1.Controls.Add(Me.Label125)
        Me.TabPage1.Controls.Add(Me.Label105)
        Me.TabPage1.Controls.Add(Me.Label60)
        Me.TabPage1.Controls.Add(Me.Label59)
        Me.TabPage1.Controls.Add(Me.Label58)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.Label1_6)
        Me.TabPage1.Controls.Add(Me.Label52)
        Me.TabPage1.Controls.Add(Me.Label50)
        Me.TabPage1.Controls.Add(Me.TextBox_CSV)
        Me.TabPage1.Controls.Add(Me.Button_txt)
        Me.TabPage1.Controls.Add(Me.Label1_2_0)
        Me.TabPage1.Controls.Add(Me.Label49)
        Me.TabPage1.Controls.Add(Me.Label1_2_2)
        Me.TabPage1.Controls.Add(Me.Label1_18)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label1_11)
        Me.TabPage1.Controls.Add(Me.Label1_17)
        Me.TabPage1.Controls.Add(Me.Label1_16)
        Me.TabPage1.Controls.Add(Me.Label1_15)
        Me.TabPage1.Controls.Add(Me.Label1_14)
        Me.TabPage1.Controls.Add(Me.Label1_13)
        Me.TabPage1.Controls.Add(Me.Label1_12)
        Me.TabPage1.Controls.Add(Me.Label1_10)
        Me.TabPage1.Controls.Add(Me.Label1_9)
        Me.TabPage1.Controls.Add(Me.Label1_7)
        Me.TabPage1.Controls.Add(Me.Label1_5)
        Me.TabPage1.Controls.Add(Me.Label1_4)
        Me.TabPage1.Controls.Add(Me.Label1_3)
        Me.TabPage1.Controls.Add(Me.Label1_2_1)
        Me.TabPage1.Controls.Add(Me.Label1_1)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label51)
        Me.TabPage1.Controls.Add(Me.Label1_22)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(896, 543)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "基本情報"
        '
        'Label1_21
        '
        Me.Label1_21.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_21.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_21.ForeColor = System.Drawing.Color.Black
        Me.Label1_21.Location = New System.Drawing.Point(352, 376)
        Me.Label1_21.Name = "Label1_21"
        Me.Label1_21.Size = New System.Drawing.Size(40, 24)
        Me.Label1_21.TabIndex = 1052
        Me.Label1_21.Text = "5年"
        Me.Label1_21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_20
        '
        Me.Label1_20.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_20.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_20.ForeColor = System.Drawing.Color.Black
        Me.Label1_20.Location = New System.Drawing.Point(160, 408)
        Me.Label1_20.Name = "Label1_20"
        Me.Label1_20.Size = New System.Drawing.Size(184, 24)
        Me.Label1_20.TabIndex = 1051
        Me.Label1_20.Text = "あり"
        Me.Label1_20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label152
        '
        Me.Label152.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label152.ForeColor = System.Drawing.Color.Navy
        Me.Label152.Location = New System.Drawing.Point(24, 408)
        Me.Label152.Name = "Label152"
        Me.Label152.Size = New System.Drawing.Size(128, 24)
        Me.Label152.TabIndex = 1050
        Me.Label152.Text = "総合補償"
        Me.Label152.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1_19
        '
        Me.Label1_19.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_19.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_19.ForeColor = System.Drawing.Color.Black
        Me.Label1_19.Location = New System.Drawing.Point(520, 72)
        Me.Label1_19.Name = "Label1_19"
        Me.Label1_19.Size = New System.Drawing.Size(136, 24)
        Me.Label1_19.TabIndex = 1049
        Me.Label1_19.Text = "Label1_19"
        Me.Label1_19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label149
        '
        Me.Label149.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label149.ForeColor = System.Drawing.Color.Navy
        Me.Label149.Location = New System.Drawing.Point(432, 72)
        Me.Label149.Name = "Label149"
        Me.Label149.Size = New System.Drawing.Size(80, 24)
        Me.Label149.TabIndex = 1048
        Me.Label149.Text = "生年月日"
        Me.Label149.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label127
        '
        Me.Label127.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label127.Location = New System.Drawing.Point(712, 96)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(96, 24)
        Me.Label127.TabIndex = 1047
        Me.Label127.Text = "Label127"
        Me.Label127.Visible = False
        '
        'Label126
        '
        Me.Label126.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label126.Location = New System.Drawing.Point(408, 280)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(32, 24)
        Me.Label126.TabIndex = 1046
        Me.Label126.Text = "Label126"
        Me.Label126.Visible = False
        '
        'Label125
        '
        Me.Label125.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label125.Location = New System.Drawing.Point(640, 96)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(32, 24)
        Me.Label125.TabIndex = 1045
        Me.Label125.Text = "Label125"
        Me.Label125.Visible = False
        '
        'Label105
        '
        Me.Label105.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.ForeColor = System.Drawing.Color.Navy
        Me.Label105.Location = New System.Drawing.Point(200, 16)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(128, 24)
        Me.Label105.TabIndex = 226
        Me.Label105.Text = "保証/補償終了日"
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label105.Visible = False
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label60.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(352, 248)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(64, 24)
        Me.Label60.TabIndex = 225
        Me.Label60.Text = "Label60"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label60.Visible = False
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label59.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Location = New System.Drawing.Point(352, 216)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(64, 24)
        Me.Label59.TabIndex = 224
        Me.Label59.Text = "Label59"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label59.Visible = False
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label58.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(352, 184)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(64, 24)
        Me.Label58.TabIndex = 223
        Me.Label58.Text = "Label58"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label58.Visible = False
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(808, 40)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 30)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "ﾌﾘｶﾞﾅ入力"
        '
        'Label1_6
        '
        Me.Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_6.ForeColor = System.Drawing.Color.Black
        Me.Label1_6.Location = New System.Drawing.Point(160, 80)
        Me.Label1_6.Name = "Label1_6"
        Me.Label1_6.Size = New System.Drawing.Size(248, 24)
        Me.Label1_6.TabIndex = 222
        Me.Label1_6.Text = "Label1_6"
        Me.Label1_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.SystemColors.Control
        Me.Label52.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(336, 16)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 24)
        Me.Label52.TabIndex = 221
        Me.Label52.Text = "Label52"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label52.Visible = False
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.SystemColors.Control
        Me.Label50.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(520, 32)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(280, 16)
        Me.Label50.TabIndex = 219
        Me.Label50.Text = "Label50"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox_CSV
        '
        Me.TextBox_CSV.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TextBox_CSV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_CSV.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_CSV.Location = New System.Drawing.Point(520, 280)
        Me.TextBox_CSV.Multiline = True
        Me.TextBox_CSV.Name = "TextBox_CSV"
        Me.TextBox_CSV.ReadOnly = True
        Me.TextBox_CSV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_CSV.Size = New System.Drawing.Size(312, 216)
        Me.TextBox_CSV.TabIndex = 218
        Me.TextBox_CSV.TabStop = False
        Me.TextBox_CSV.Text = ""
        '
        'Button_txt
        '
        Me.Button_txt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_txt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_txt.Location = New System.Drawing.Point(784, 504)
        Me.Button_txt.Name = "Button_txt"
        Me.Button_txt.Size = New System.Drawing.Size(96, 30)
        Me.Button_txt.TabIndex = 217
        Me.Button_txt.Text = "TEXT"
        '
        'Label1_2_0
        '
        Me.Label1_2_0.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_2_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_2_0.ForeColor = System.Drawing.Color.Black
        Me.Label1_2_0.Location = New System.Drawing.Point(520, 104)
        Me.Label1_2_0.Name = "Label1_2_0"
        Me.Label1_2_0.Size = New System.Drawing.Size(104, 24)
        Me.Label1_2_0.TabIndex = 215
        Me.Label1_2_0.Text = "Label1_2_0"
        Me.Label1_2_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Navy
        Me.Label49.Location = New System.Drawing.Point(432, 104)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(80, 24)
        Me.Label49.TabIndex = 214
        Me.Label49.Text = "郵便番号"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1_2_2
        '
        Me.Label1_2_2.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_2_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_2_2.ForeColor = System.Drawing.Color.Black
        Me.Label1_2_2.Location = New System.Drawing.Point(520, 176)
        Me.Label1_2_2.Name = "Label1_2_2"
        Me.Label1_2_2.Size = New System.Drawing.Size(368, 32)
        Me.Label1_2_2.TabIndex = 213
        Me.Label1_2_2.Text = "Label1_2_2"
        '
        'Label1_18
        '
        Me.Label1_18.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_18.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_18.ForeColor = System.Drawing.Color.Black
        Me.Label1_18.Location = New System.Drawing.Point(160, 248)
        Me.Label1_18.Name = "Label1_18"
        Me.Label1_18.Size = New System.Drawing.Size(248, 24)
        Me.Label1_18.TabIndex = 212
        Me.Label1_18.Text = "Label1_18"
        Me.Label1_18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Navy
        Me.Label18.Location = New System.Drawing.Point(24, 248)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 24)
        Me.Label18.TabIndex = 211
        Me.Label18.Text = "商  品"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(24, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 24)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "加入状況"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1_11
        '
        Me.Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_11.ForeColor = System.Drawing.Color.Black
        Me.Label1_11.Location = New System.Drawing.Point(160, 280)
        Me.Label1_11.Name = "Label1_11"
        Me.Label1_11.Size = New System.Drawing.Size(248, 24)
        Me.Label1_11.TabIndex = 209
        Me.Label1_11.Text = "Label1_11"
        Me.Label1_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_17
        '
        Me.Label1_17.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_17.ForeColor = System.Drawing.Color.Black
        Me.Label1_17.Location = New System.Drawing.Point(160, 16)
        Me.Label1_17.Name = "Label1_17"
        Me.Label1_17.Size = New System.Drawing.Size(40, 24)
        Me.Label1_17.TabIndex = 208
        Me.Label1_17.Text = "Label1_17"
        Me.Label1_17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_16
        '
        Me.Label1_16.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_16.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_16.ForeColor = System.Drawing.Color.Black
        Me.Label1_16.Location = New System.Drawing.Point(160, 472)
        Me.Label1_16.Name = "Label1_16"
        Me.Label1_16.Size = New System.Drawing.Size(248, 24)
        Me.Label1_16.TabIndex = 207
        Me.Label1_16.Text = "Label1_16"
        Me.Label1_16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_15
        '
        Me.Label1_15.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_15.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_15.ForeColor = System.Drawing.Color.Black
        Me.Label1_15.Location = New System.Drawing.Point(160, 440)
        Me.Label1_15.Name = "Label1_15"
        Me.Label1_15.Size = New System.Drawing.Size(248, 24)
        Me.Label1_15.TabIndex = 206
        Me.Label1_15.Text = "Label1_15"
        Me.Label1_15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_14
        '
        Me.Label1_14.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_14.ForeColor = System.Drawing.Color.Black
        Me.Label1_14.Location = New System.Drawing.Point(160, 376)
        Me.Label1_14.Name = "Label1_14"
        Me.Label1_14.Size = New System.Drawing.Size(184, 24)
        Me.Label1_14.TabIndex = 205
        Me.Label1_14.Text = "Label1_14"
        Me.Label1_14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_13
        '
        Me.Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_13.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_13.ForeColor = System.Drawing.Color.Black
        Me.Label1_13.Location = New System.Drawing.Point(160, 344)
        Me.Label1_13.Name = "Label1_13"
        Me.Label1_13.Size = New System.Drawing.Size(184, 24)
        Me.Label1_13.TabIndex = 204
        Me.Label1_13.Text = "Label1_13"
        Me.Label1_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_12
        '
        Me.Label1_12.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_12.ForeColor = System.Drawing.Color.Black
        Me.Label1_12.Location = New System.Drawing.Point(160, 312)
        Me.Label1_12.Name = "Label1_12"
        Me.Label1_12.Size = New System.Drawing.Size(248, 24)
        Me.Label1_12.TabIndex = 203
        Me.Label1_12.Text = "Label1_12"
        Me.Label1_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_10
        '
        Me.Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_10.ForeColor = System.Drawing.Color.Black
        Me.Label1_10.Location = New System.Drawing.Point(160, 216)
        Me.Label1_10.Name = "Label1_10"
        Me.Label1_10.Size = New System.Drawing.Size(248, 24)
        Me.Label1_10.TabIndex = 202
        Me.Label1_10.Text = "Label1_10"
        Me.Label1_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_9
        '
        Me.Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_9.ForeColor = System.Drawing.Color.Black
        Me.Label1_9.Location = New System.Drawing.Point(160, 184)
        Me.Label1_9.Name = "Label1_9"
        Me.Label1_9.Size = New System.Drawing.Size(248, 24)
        Me.Label1_9.TabIndex = 201
        Me.Label1_9.Text = "Label1_9"
        Me.Label1_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_7
        '
        Me.Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_7.ForeColor = System.Drawing.Color.Black
        Me.Label1_7.Location = New System.Drawing.Point(160, 144)
        Me.Label1_7.Name = "Label1_7"
        Me.Label1_7.Size = New System.Drawing.Size(248, 24)
        Me.Label1_7.TabIndex = 199
        Me.Label1_7.Text = "Label1_7"
        Me.Label1_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_5
        '
        Me.Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_5.ForeColor = System.Drawing.Color.Black
        Me.Label1_5.Location = New System.Drawing.Point(160, 112)
        Me.Label1_5.Name = "Label1_5"
        Me.Label1_5.Size = New System.Drawing.Size(248, 24)
        Me.Label1_5.TabIndex = 197
        Me.Label1_5.Text = "Label1_5"
        Me.Label1_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_4
        '
        Me.Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_4.ForeColor = System.Drawing.Color.Black
        Me.Label1_4.Location = New System.Drawing.Point(520, 248)
        Me.Label1_4.Name = "Label1_4"
        Me.Label1_4.Size = New System.Drawing.Size(312, 24)
        Me.Label1_4.TabIndex = 196
        Me.Label1_4.Text = "Label1_4"
        Me.Label1_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_3
        '
        Me.Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_3.ForeColor = System.Drawing.Color.Black
        Me.Label1_3.Location = New System.Drawing.Point(520, 216)
        Me.Label1_3.Name = "Label1_3"
        Me.Label1_3.Size = New System.Drawing.Size(312, 24)
        Me.Label1_3.TabIndex = 195
        Me.Label1_3.Text = "Label1_3"
        Me.Label1_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1_2_1
        '
        Me.Label1_2_1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_2_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_2_1.ForeColor = System.Drawing.Color.Black
        Me.Label1_2_1.Location = New System.Drawing.Point(520, 136)
        Me.Label1_2_1.Name = "Label1_2_1"
        Me.Label1_2_1.Size = New System.Drawing.Size(368, 32)
        Me.Label1_2_1.TabIndex = 194
        Me.Label1_2_1.Text = "Label1_2_1"
        '
        'Label1_1
        '
        Me.Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1_1.ForeColor = System.Drawing.Color.Black
        Me.Label1_1.Location = New System.Drawing.Point(520, 48)
        Me.Label1_1.Name = "Label1_1"
        Me.Label1_1.Size = New System.Drawing.Size(280, 24)
        Me.Label1_1.TabIndex = 193
        Me.Label1_1.Text = "Label1_1"
        Me.Label1_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(24, 472)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 24)
        Me.Label17.TabIndex = 192
        Me.Label17.Text = "修理限度額"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(24, 440)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 24)
        Me.Label16.TabIndex = 191
        Me.Label16.Text = "延長保証料"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Navy
        Me.Label15.Location = New System.Drawing.Point(24, 376)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 24)
        Me.Label15.TabIndex = 190
        Me.Label15.Text = "延長保証期間"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(24, 344)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 24)
        Me.Label14.TabIndex = 189
        Me.Label14.Text = "メーカー保証期間"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(24, 312)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 24)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "商品購入金額"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(24, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 24)
        Me.Label8.TabIndex = 187
        Me.Label8.Text = "購入店舗"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(24, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 24)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "商品カテゴリー"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(24, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 24)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "メーカー"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(24, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 24)
        Me.Label9.TabIndex = 183
        Me.Label9.Text = "保証加入日"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(24, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 24)
        Me.Label7.TabIndex = 182
        Me.Label7.Text = "保証番号"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(24, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 24)
        Me.Label6.TabIndex = 181
        Me.Label6.Text = "ﾎﾟｲﾝﾄｶｰﾄﾞNO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(432, 248)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 24)
        Me.Label4.TabIndex = 179
        Me.Label4.Text = "連絡先番号"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(432, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 24)
        Me.Label3.TabIndex = 178
        Me.Label3.Text = "電話番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(432, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 24)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "住  所"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(432, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 24)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "氏名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(408, 328)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(72, 16)
        Me.Label51.TabIndex = 220
        Me.Label51.Text = "Label51"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label51.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label142)
        Me.TabPage3.Controls.Add(Me.Label141)
        Me.TabPage3.Controls.Add(Me.Label140)
        Me.TabPage3.Controls.Add(Me.Label139)
        Me.TabPage3.Controls.Add(Me.Label138)
        Me.TabPage3.Controls.Add(Me.Label137)
        Me.TabPage3.Controls.Add(Me.Label136)
        Me.TabPage3.Controls.Add(Me.Label135)
        Me.TabPage3.Controls.Add(Me.Label134)
        Me.TabPage3.Controls.Add(Me.Label133)
        Me.TabPage3.Controls.Add(Me.Label132)
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
        Me.TabPage3.Controls.Add(Me.ComboBox5)
        Me.TabPage3.Controls.Add(Me.Label114)
        Me.TabPage3.Controls.Add(Me.ComboBox4)
        Me.TabPage3.Controls.Add(Me.Label115)
        Me.TabPage3.Controls.Add(Me.ComboBox3)
        Me.TabPage3.Controls.Add(Me.Label116)
        Me.TabPage3.Controls.Add(Me.Label117)
        Me.TabPage3.Controls.Add(Me.ComboBox2)
        Me.TabPage3.Controls.Add(Me.Label118)
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
        Me.TabPage3.Controls.Add(Me.TextBox2)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.TextBox1)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.CheckBox1)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Label3_1)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 21)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(896, 543)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "LOG"
        '
        'Label142
        '
        Me.Label142.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label142.Location = New System.Drawing.Point(848, 232)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(32, 24)
        Me.Label142.TabIndex = 1061
        Me.Label142.Text = "Label142"
        Me.Label142.Visible = False
        '
        'Label141
        '
        Me.Label141.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label141.Location = New System.Drawing.Point(16, 232)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(32, 24)
        Me.Label141.TabIndex = 1060
        Me.Label141.Text = "Label141"
        Me.Label141.Visible = False
        '
        'Label140
        '
        Me.Label140.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label140.Location = New System.Drawing.Point(848, 200)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(32, 24)
        Me.Label140.TabIndex = 1059
        Me.Label140.Text = "Label140"
        Me.Label140.Visible = False
        '
        'Label139
        '
        Me.Label139.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label139.Location = New System.Drawing.Point(848, 168)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(32, 24)
        Me.Label139.TabIndex = 1058
        Me.Label139.Text = "Label139"
        Me.Label139.Visible = False
        '
        'Label138
        '
        Me.Label138.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label138.Location = New System.Drawing.Point(552, 72)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(32, 24)
        Me.Label138.TabIndex = 1057
        Me.Label138.Text = "Label138"
        Me.Label138.Visible = False
        '
        'Label137
        '
        Me.Label137.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label137.Location = New System.Drawing.Point(408, 48)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(32, 24)
        Me.Label137.TabIndex = 1056
        Me.Label137.Text = "Label137"
        Me.Label137.Visible = False
        '
        'Label136
        '
        Me.Label136.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label136.Location = New System.Drawing.Point(16, 200)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(32, 24)
        Me.Label136.TabIndex = 1055
        Me.Label136.Text = "Label136"
        Me.Label136.Visible = False
        '
        'Label135
        '
        Me.Label135.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label135.Location = New System.Drawing.Point(16, 168)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(32, 24)
        Me.Label135.TabIndex = 1054
        Me.Label135.Text = "Label135"
        Me.Label135.Visible = False
        '
        'Label134
        '
        Me.Label134.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label134.Location = New System.Drawing.Point(16, 136)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(32, 24)
        Me.Label134.TabIndex = 1053
        Me.Label134.Text = "Label134"
        Me.Label134.Visible = False
        '
        'Label133
        '
        Me.Label133.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label133.Location = New System.Drawing.Point(648, 104)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(32, 24)
        Me.Label133.TabIndex = 1052
        Me.Label133.Text = "Label133"
        Me.Label133.Visible = False
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label132.Location = New System.Drawing.Point(440, 104)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(32, 24)
        Me.Label132.TabIndex = 1051
        Me.Label132.Text = "Label132"
        Me.Label132.Visible = False
        '
        'Label131
        '
        Me.Label131.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label131.Location = New System.Drawing.Point(16, 72)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(32, 24)
        Me.Label131.TabIndex = 1050
        Me.Label131.Text = "Label131"
        Me.Label131.Visible = False
        '
        'Label124
        '
        Me.Label124.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label124.Location = New System.Drawing.Point(16, 400)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(32, 24)
        Me.Label124.TabIndex = 1043
        Me.Label124.Text = "Label124"
        Me.Label124.Visible = False
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label123.Location = New System.Drawing.Point(664, 264)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(32, 24)
        Me.Label123.TabIndex = 1042
        Me.Label123.Text = "Label123"
        Me.Label123.Visible = False
        '
        'Label122
        '
        Me.Label122.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label122.Location = New System.Drawing.Point(16, 264)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(32, 24)
        Me.Label122.TabIndex = 1041
        Me.Label122.Text = "Label122"
        Me.Label122.Visible = False
        '
        'ComboBox12
        '
        Me.ComboBox12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox12.Location = New System.Drawing.Point(552, 232)
        Me.ComboBox12.MaxDropDownItems = 12
        Me.ComboBox12.Name = "ComboBox12"
        Me.ComboBox12.Size = New System.Drawing.Size(296, 24)
        Me.ComboBox12.TabIndex = 130
        Me.ComboBox12.Text = "ComboBox12"
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.Color.Blue
        Me.Label106.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.ForeColor = System.Drawing.Color.White
        Me.Label106.Location = New System.Drawing.Point(448, 232)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(104, 24)
        Me.Label106.TabIndex = 1040
        Me.Label106.Text = "対応結果２"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label107
        '
        Me.Label107.BackColor = System.Drawing.Color.Blue
        Me.Label107.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.White
        Me.Label107.Location = New System.Drawing.Point(448, 136)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(136, 24)
        Me.Label107.TabIndex = 1039
        Me.Label107.Text = "コール内容"
        Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox11
        '
        Me.ComboBox11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox11.Location = New System.Drawing.Point(152, 232)
        Me.ComboBox11.MaxDropDownItems = 12
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(288, 24)
        Me.ComboBox11.TabIndex = 120
        Me.ComboBox11.Text = "ComboBox11"
        '
        'Label108
        '
        Me.Label108.BackColor = System.Drawing.Color.Blue
        Me.Label108.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.White
        Me.Label108.Location = New System.Drawing.Point(48, 232)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(104, 24)
        Me.Label108.TabIndex = 1038
        Me.Label108.Text = "対応結果１"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label109
        '
        Me.Label109.BackColor = System.Drawing.Color.Blue
        Me.Label109.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.ForeColor = System.Drawing.Color.White
        Me.Label109.Location = New System.Drawing.Point(464, 72)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(40, 24)
        Me.Label109.TabIndex = 1037
        Me.Label109.Text = "月"
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox10
        '
        Me.ComboBox10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox10.Location = New System.Drawing.Point(584, 200)
        Me.ComboBox10.MaxDropDownItems = 12
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(264, 24)
        Me.ComboBox10.TabIndex = 110
        Me.ComboBox10.Text = "ComboBox10"
        '
        'Label110
        '
        Me.Label110.BackColor = System.Drawing.Color.Blue
        Me.Label110.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.White
        Me.Label110.Location = New System.Drawing.Point(480, 200)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(104, 24)
        Me.Label110.TabIndex = 1036
        Me.Label110.Text = "意見・要望系"
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox9
        '
        Me.ComboBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox9.Location = New System.Drawing.Point(584, 168)
        Me.ComboBox9.MaxDropDownItems = 12
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(264, 24)
        Me.ComboBox9.TabIndex = 100
        Me.ComboBox9.Text = "ComboBox9"
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.Color.Blue
        Me.Label111.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.White
        Me.Label111.Location = New System.Drawing.Point(480, 168)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(104, 24)
        Me.Label111.TabIndex = 1035
        Me.Label111.Text = "不具合系"
        Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox8
        '
        Me.ComboBox8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox8.Location = New System.Drawing.Point(504, 72)
        Me.ComboBox8.MaxDropDownItems = 12
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(48, 24)
        Me.ComboBox8.TabIndex = 30
        Me.ComboBox8.Text = "ComboBox8"
        '
        'ComboBox7
        '
        Me.ComboBox7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox7.Location = New System.Drawing.Point(408, 72)
        Me.ComboBox7.MaxDropDownItems = 12
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(48, 24)
        Me.ComboBox7.TabIndex = 20
        Me.ComboBox7.Text = "ComboBox7"
        '
        'Label112
        '
        Me.Label112.BackColor = System.Drawing.Color.Blue
        Me.Label112.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.White
        Me.Label112.Location = New System.Drawing.Point(304, 72)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(104, 24)
        Me.Label112.TabIndex = 1034
        Me.Label112.Text = "購入後　年"
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox6
        '
        Me.ComboBox6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox6.Location = New System.Drawing.Point(152, 200)
        Me.ComboBox6.MaxDropDownItems = 26
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(288, 24)
        Me.ComboBox6.TabIndex = 90
        Me.ComboBox6.Text = "ComboBox6"
        '
        'Label113
        '
        Me.Label113.BackColor = System.Drawing.Color.Blue
        Me.Label113.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label113.ForeColor = System.Drawing.Color.White
        Me.Label113.Location = New System.Drawing.Point(48, 200)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(104, 24)
        Me.Label113.TabIndex = 1033
        Me.Label113.Text = "購入店舗"
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox5
        '
        Me.ComboBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.Location = New System.Drawing.Point(152, 168)
        Me.ComboBox5.MaxDropDownItems = 26
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(288, 24)
        Me.ComboBox5.TabIndex = 80
        Me.ComboBox5.Text = "ComboBox5"
        '
        'Label114
        '
        Me.Label114.BackColor = System.Drawing.Color.Blue
        Me.Label114.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.White
        Me.Label114.Location = New System.Drawing.Point(48, 168)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(104, 24)
        Me.Label114.TabIndex = 1032
        Me.Label114.Text = "メーカー"
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.Location = New System.Drawing.Point(152, 136)
        Me.ComboBox4.MaxDropDownItems = 26
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(288, 24)
        Me.ComboBox4.TabIndex = 70
        Me.ComboBox4.Text = "ComboBox4"
        '
        'Label115
        '
        Me.Label115.BackColor = System.Drawing.Color.Blue
        Me.Label115.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label115.ForeColor = System.Drawing.Color.White
        Me.Label115.Location = New System.Drawing.Point(48, 136)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(104, 24)
        Me.Label115.TabIndex = 1031
        Me.Label115.Text = "商品ｶﾃｺﾞﾘｰ"
        Me.Label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.Location = New System.Drawing.Point(536, 104)
        Me.ComboBox3.MaxDropDownItems = 12
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(112, 24)
        Me.ComboBox3.TabIndex = 60
        Me.ComboBox3.Text = "ComboBox3"
        '
        'Label116
        '
        Me.Label116.BackColor = System.Drawing.Color.Blue
        Me.Label116.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label116.ForeColor = System.Drawing.Color.White
        Me.Label116.Location = New System.Drawing.Point(472, 104)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(64, 24)
        Me.Label116.TabIndex = 1030
        Me.Label116.Text = "地　域"
        Me.Label116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label117
        '
        Me.Label117.BackColor = System.Drawing.Color.Blue
        Me.Label117.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label117.ForeColor = System.Drawing.Color.White
        Me.Label117.Location = New System.Drawing.Point(48, 104)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(104, 24)
        Me.Label117.TabIndex = 1029
        Me.Label117.Text = "性　別"
        Me.Label117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.Location = New System.Drawing.Point(344, 104)
        Me.ComboBox2.MaxDropDownItems = 12
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(96, 24)
        Me.ComboBox2.TabIndex = 50
        Me.ComboBox2.Text = "ComboBox2"
        '
        'Label118
        '
        Me.Label118.BackColor = System.Drawing.Color.Blue
        Me.Label118.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.ForeColor = System.Drawing.Color.White
        Me.Label118.Location = New System.Drawing.Point(280, 104)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(64, 24)
        Me.Label118.TabIndex = 1028
        Me.Label118.Text = "年齢層"
        Me.Label118.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.RadioButton8)
        Me.Panel4.Controls.Add(Me.RadioButton9)
        Me.Panel4.Location = New System.Drawing.Point(152, 104)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(128, 24)
        Me.Panel4.TabIndex = 40
        '
        'RadioButton8
        '
        Me.RadioButton8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton8.Location = New System.Drawing.Point(64, 0)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(40, 24)
        Me.RadioButton8.TabIndex = 42
        Me.RadioButton8.Text = "女"
        '
        'RadioButton9
        '
        Me.RadioButton9.Checked = True
        Me.RadioButton9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton9.Location = New System.Drawing.Point(8, 0)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(48, 24)
        Me.RadioButton9.TabIndex = 41
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Text = "男"
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.DimGray
        Me.Label46.Location = New System.Drawing.Point(48, 48)
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
        Me.Label3_4.Location = New System.Drawing.Point(96, 48)
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
        Me.Label45.Location = New System.Drawing.Point(600, 24)
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
        Me.Label3_3.Location = New System.Drawing.Point(688, 24)
        Me.Label3_3.Name = "Label3_3"
        Me.Label3_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3_3.Size = New System.Drawing.Size(144, 16)
        Me.Label3_3.TabIndex = 216
        Me.Label3_3.Text = "Label3_3"
        Me.Label3_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox3_4
        '
        Me.ComboBox3_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3_4.Location = New System.Drawing.Point(152, 400)
        Me.ComboBox3_4.Name = "ComboBox3_4"
        Me.ComboBox3_4.Size = New System.Drawing.Size(200, 24)
        Me.ComboBox3_4.TabIndex = 180
        Me.ComboBox3_4.Text = "ComboBox3_4"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Blue
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(48, 400)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 24)
        Me.Label25.TabIndex = 214
        Me.Label25.Text = "回答区分"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox3_3
        '
        Me.ComboBox3_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3_3.Location = New System.Drawing.Point(552, 264)
        Me.ComboBox3_3.Name = "ComboBox3_3"
        Me.ComboBox3_3.Size = New System.Drawing.Size(112, 24)
        Me.ComboBox3_3.TabIndex = 150
        Me.ComboBox3_3.Text = "ComboBox3_3"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Blue
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(448, 264)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 24)
        Me.Label24.TabIndex = 212
        Me.Label24.Text = "ステイタス"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DimGray
        Me.Label23.Location = New System.Drawing.Point(360, 24)
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
        Me.Label3_2.Location = New System.Drawing.Point(448, 24)
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
        Me.Button2.Location = New System.Drawing.Point(784, 456)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 30)
        Me.Button2.TabIndex = 200
        Me.Button2.Text = "履歴表示"
        '
        'ComboBox3_2
        '
        Me.ComboBox3_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3_2.Location = New System.Drawing.Point(152, 264)
        Me.ComboBox3_2.Name = "ComboBox3_2"
        Me.ComboBox3_2.Size = New System.Drawing.Size(288, 24)
        Me.ComboBox3_2.TabIndex = 140
        Me.ComboBox3_2.Text = "ComboBox3_2"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.Location = New System.Drawing.Point(152, 72)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 24)
        Me.ComboBox1.TabIndex = 10
        Me.ComboBox1.Text = "ComboBox1"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox2.Location = New System.Drawing.Point(72, 432)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(696, 96)
        Me.TextBox2.TabIndex = 190
        Me.TextBox2.Text = "TextBox2"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Blue
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(48, 432)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 96)
        Me.Label22.TabIndex = 205
        Me.Label22.Text = "回答内容"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox1.Location = New System.Drawing.Point(72, 296)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(696, 96)
        Me.TextBox1.TabIndex = 170
        Me.TextBox1.Text = "TextBox1"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Blue
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(48, 296)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 96)
        Me.Label21.TabIndex = 203
        Me.Label21.Text = "問合せ内容"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(704, 264)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(112, 24)
        Me.CheckBox1.TabIndex = 160
        Me.CheckBox1.Text = "クレーム"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Blue
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(48, 264)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 24)
        Me.Label20.TabIndex = 201
        Me.Label20.Text = "問合せ区分"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Blue
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(48, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 24)
        Me.Label19.TabIndex = 200
        Me.Label19.Text = "相手先"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(48, 24)
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
        Me.Label3_1.Location = New System.Drawing.Point(152, 24)
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
        Me.Button1.Location = New System.Drawing.Point(784, 496)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 30)
        Me.Button1.TabIndex = 210
        Me.Button1.Text = "追  加"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Button5)
        Me.TabPage4.Controls.Add(Me.Label121)
        Me.TabPage4.Controls.Add(Me.Label120)
        Me.TabPage4.Controls.Add(Me.Label119)
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
        Me.TabPage4.Controls.Add(Me.ComboBox19)
        Me.TabPage4.Controls.Add(Me.ComboBox18)
        Me.TabPage4.Controls.Add(Me.ComboBox17)
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
        Me.TabPage4.Size = New System.Drawing.Size(896, 543)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "変更"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(496, 344)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(96, 24)
        Me.Button5.TabIndex = 935
        Me.Button5.Text = "全商品表示"
        '
        'Label121
        '
        Me.Label121.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label121.Location = New System.Drawing.Point(704, 344)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(56, 24)
        Me.Label121.TabIndex = 934
        Me.Label121.Text = "Label121"
        Me.Label121.Visible = False
        '
        'Label120
        '
        Me.Label120.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label120.Location = New System.Drawing.Point(704, 312)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(56, 24)
        Me.Label120.TabIndex = 933
        Me.Label120.Text = "Label120"
        Me.Label120.Visible = False
        '
        'Label119
        '
        Me.Label119.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label119.Location = New System.Drawing.Point(704, 280)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(56, 24)
        Me.Label119.TabIndex = 932
        Me.Label119.Text = "Label119"
        Me.Label119.Visible = False
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.Blue
        Me.Label104.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.White
        Me.Label104.Location = New System.Drawing.Point(280, 16)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(128, 23)
        Me.Label104.TabIndex = 931
        Me.Label104.Text = "補償／保証終了日"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label104.Visible = False
        '
        'Date4
        '
        Me.Date4.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date4.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date4.DropDownCalendar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date4.DropDownCalendar.Size = New System.Drawing.Size(179, 195)
        Me.Date4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date4.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date4.Location = New System.Drawing.Point(408, 16)
        Me.Date4.Name = "Date4"
        Me.Date4.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date4.Size = New System.Drawing.Size(96, 22)
        Me.Date4.TabIndex = 11
        Me.Date4.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date4.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date4.Value = Nothing
        Me.Date4.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.RadioButton2.Location = New System.Drawing.Point(648, 16)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(120, 24)
        Me.RadioButton2.TabIndex = 13
        Me.RadioButton2.Text = "総合補償適用"
        Me.RadioButton2.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.RadioButton1.Location = New System.Drawing.Point(528, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(120, 24)
        Me.RadioButton1.TabIndex = 12
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "代替品提供"
        Me.RadioButton1.Visible = False
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label70.Location = New System.Drawing.Point(592, 344)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(104, 24)
        Me.Label70.TabIndex = 930
        Me.Label70.Text = "Label70"
        Me.Label70.Visible = False
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label69.Location = New System.Drawing.Point(592, 312)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(104, 24)
        Me.Label69.TabIndex = 929
        Me.Label69.Text = "Label69"
        Me.Label69.Visible = False
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label68.Location = New System.Drawing.Point(592, 280)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(104, 24)
        Me.Label68.TabIndex = 928
        Me.Label68.Text = "Label68"
        Me.Label68.Visible = False
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label67.Location = New System.Drawing.Point(280, 248)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(168, 24)
        Me.Label67.TabIndex = 927
        Me.Label67.Text = "Label67"
        Me.Label67.Visible = False
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label66.Location = New System.Drawing.Point(280, 216)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(168, 24)
        Me.Label66.TabIndex = 926
        Me.Label66.Text = "Label66"
        Me.Label66.Visible = False
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label65.Location = New System.Drawing.Point(616, 184)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(168, 24)
        Me.Label65.TabIndex = 925
        Me.Label65.Text = "Label65"
        Me.Label65.Visible = False
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label64.Location = New System.Drawing.Point(616, 152)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(168, 24)
        Me.Label64.TabIndex = 924
        Me.Label64.Text = "Label64"
        Me.Label64.Visible = False
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label63.Location = New System.Drawing.Point(280, 120)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(168, 24)
        Me.Label63.TabIndex = 923
        Me.Label63.Text = "Label63"
        Me.Label63.Visible = False
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label62.Location = New System.Drawing.Point(352, 88)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(168, 24)
        Me.Label62.TabIndex = 922
        Me.Label62.Text = "Label62"
        Me.Label62.Visible = False
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label61.Location = New System.Drawing.Point(352, 56)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(168, 24)
        Me.Label61.TabIndex = 921
        Me.Label61.Text = "Label61"
        Me.Label61.Visible = False
        '
        'ComboBox19
        '
        Me.ComboBox19.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ComboBox19.Location = New System.Drawing.Point(160, 344)
        Me.ComboBox19.Name = "ComboBox19"
        Me.ComboBox19.Size = New System.Drawing.Size(336, 24)
        Me.ComboBox19.TabIndex = 110
        Me.ComboBox19.Text = "ComboBox19"
        '
        'ComboBox18
        '
        Me.ComboBox18.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ComboBox18.Location = New System.Drawing.Point(160, 312)
        Me.ComboBox18.Name = "ComboBox18"
        Me.ComboBox18.Size = New System.Drawing.Size(336, 24)
        Me.ComboBox18.TabIndex = 100
        Me.ComboBox18.Text = "ComboBox18"
        '
        'ComboBox17
        '
        Me.ComboBox17.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ComboBox17.Location = New System.Drawing.Point(160, 280)
        Me.ComboBox17.Name = "ComboBox17"
        Me.ComboBox17.Size = New System.Drawing.Size(336, 24)
        Me.ComboBox17.TabIndex = 90
        Me.ComboBox17.Text = "ComboBox17"
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(768, 344)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(96, 30)
        Me.Button7.TabIndex = 900
        Me.Button7.Text = "クリア"
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Blue
        Me.Label57.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.TextBox4_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Label56.BackColor = System.Drawing.Color.Blue
        Me.Label56.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.White
        Me.Label56.Location = New System.Drawing.Point(48, 344)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(112, 23)
        Me.Label56.TabIndex = 23
        Me.Label56.Text = "商　品"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Blue
        Me.Label55.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.White
        Me.Label55.Location = New System.Drawing.Point(48, 312)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(112, 23)
        Me.Label55.TabIndex = 22
        Me.Label55.Text = "商品カテゴリー"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit3
        '
        Me.Edit3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Edit3.Format = "9"
        Me.Edit3.HighlightText = True
        Me.Edit3.Location = New System.Drawing.Point(160, 248)
        Me.Edit3.MaxLength = 20
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(120, 22)
        Me.Edit3.TabIndex = 80
        Me.Edit3.Text = "1"
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Blue
        Me.Label54.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.White
        Me.Label54.Location = New System.Drawing.Point(48, 248)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(112, 23)
        Me.Label54.TabIndex = 20
        Me.Label54.Text = "連絡先電話番号"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit2
        '
        Me.Edit2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Edit2.Format = "9"
        Me.Edit2.HighlightText = True
        Me.Edit2.Location = New System.Drawing.Point(160, 216)
        Me.Edit2.MaxLength = 20
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(120, 22)
        Me.Edit2.TabIndex = 70
        Me.Edit2.Text = "1"
        '
        'Edit1
        '
        Me.Edit1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Edit1.Format = "9"
        Me.Edit1.HighlightText = True
        Me.Edit1.Location = New System.Drawing.Point(160, 120)
        Me.Edit1.MaxLength = 7
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(120, 22)
        Me.Edit1.TabIndex = 40
        Me.Edit1.Text = "1"
        '
        'CheckBox4
        '
        Me.CheckBox4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox4.Location = New System.Drawing.Point(176, 16)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.TabIndex = 10
        Me.CheckBox4.Text = """F"" に変更"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Blue
        Me.Label53.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Label48.BackColor = System.Drawing.Color.Blue
        Me.Label48.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(48, 120)
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
        Me.Button4.Location = New System.Drawing.Point(768, 384)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 30)
        Me.Button4.TabIndex = 910
        Me.Button4.Text = "履歴表示"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Blue
        Me.Label44.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(48, 376)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(112, 72)
        Me.Label44.TabIndex = 11
        Me.Label44.Text = "変更理由"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_6
        '
        Me.TextBox4_6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4_6.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox4_6.Location = New System.Drawing.Point(160, 376)
        Me.TextBox4_6.MaxLength = 300
        Me.TextBox4_6.Multiline = True
        Me.TextBox4_6.Name = "TextBox4_6"
        Me.TextBox4_6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox4_6.Size = New System.Drawing.Size(456, 72)
        Me.TextBox4_6.TabIndex = 120
        Me.TextBox4_6.Text = "TextBox4_6"
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Blue
        Me.Label42.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(48, 280)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(112, 23)
        Me.Label42.TabIndex = 9
        Me.Label42.Text = "メーカー"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(768, 424)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 30)
        Me.Button3.TabIndex = 920
        Me.Button3.Text = "変 更"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Blue
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(48, 216)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(112, 23)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "電話番号"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Blue
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(48, 184)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 23)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "住所2"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_3
        '
        Me.TextBox4_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4_3.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox4_3.Location = New System.Drawing.Point(160, 184)
        Me.TextBox4_3.MaxLength = 60
        Me.TextBox4_3.Name = "TextBox4_3"
        Me.TextBox4_3.Size = New System.Drawing.Size(456, 22)
        Me.TextBox4_3.TabIndex = 60
        Me.TextBox4_3.Text = "TextBox4_3"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Blue
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(48, 152)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 23)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "住所1"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_2
        '
        Me.TextBox4_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4_2.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox4_2.Location = New System.Drawing.Point(160, 152)
        Me.TextBox4_2.MaxLength = 60
        Me.TextBox4_2.Name = "TextBox4_2"
        Me.TextBox4_2.Size = New System.Drawing.Size(456, 22)
        Me.TextBox4_2.TabIndex = 50
        Me.TextBox4_2.Text = "TextBox4_2"
        '
        'Label4_1
        '
        Me.Label4_1.BackColor = System.Drawing.Color.Blue
        Me.Label4_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4_1.ForeColor = System.Drawing.Color.White
        Me.Label4_1.Location = New System.Drawing.Point(48, 88)
        Me.Label4_1.Name = "Label4_1"
        Me.Label4_1.Size = New System.Drawing.Size(112, 23)
        Me.Label4_1.TabIndex = 1
        Me.Label4_1.Text = "氏名（漢字）"
        Me.Label4_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4_1
        '
        Me.TextBox4_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4_1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox4_1.Location = New System.Drawing.Point(160, 88)
        Me.TextBox4_1.MaxLength = 30
        Me.TextBox4_1.Name = "TextBox4_1"
        Me.TextBox4_1.Size = New System.Drawing.Size(192, 22)
        Me.TextBox4_1.TabIndex = 30
        Me.TextBox4_1.Text = "TextBox4_1"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label148)
        Me.TabPage5.Controls.Add(Me.Label147)
        Me.TabPage5.Controls.Add(Me.TextBox11)
        Me.TabPage5.Controls.Add(Me.Label145)
        Me.TabPage5.Controls.Add(Me.Label146)
        Me.TabPage5.Controls.Add(Me.ComboBox15)
        Me.TabPage5.Controls.Add(Me.Label144)
        Me.TabPage5.Controls.Add(Me.ComboBox14)
        Me.TabPage5.Controls.Add(Me.ComboBox13)
        Me.TabPage5.Controls.Add(Me.Label143)
        Me.TabPage5.Controls.Add(Me.TextBox10)
        Me.TabPage5.Controls.Add(Me.Label130)
        Me.TabPage5.Controls.Add(Me.Label129)
        Me.TabPage5.Controls.Add(Me.Label128)
        Me.TabPage5.Controls.Add(Me.Label103)
        Me.TabPage5.Controls.Add(Me.Label102)
        Me.TabPage5.Controls.Add(Me.Label87)
        Me.TabPage5.Controls.Add(Me.Panel2)
        Me.TabPage5.Controls.Add(Me.PictureBox2)
        Me.TabPage5.Controls.Add(Me.ComboBox16)
        Me.TabPage5.Controls.Add(Me.Date3)
        Me.TabPage5.Controls.Add(Me.Date2)
        Me.TabPage5.Controls.Add(Me.Date1)
        Me.TabPage5.Controls.Add(Me.Edit6)
        Me.TabPage5.Controls.Add(Me.Edit5)
        Me.TabPage5.Controls.Add(Me.TextBox9)
        Me.TabPage5.Controls.Add(Me.TextBox8)
        Me.TabPage5.Controls.Add(Me.Edit4)
        Me.TabPage5.Controls.Add(Me.TextBox7)
        Me.TabPage5.Controls.Add(Me.TextBox6)
        Me.TabPage5.Controls.Add(Me.TextBox5)
        Me.TabPage5.Controls.Add(Me.TextBox4)
        Me.TabPage5.Controls.Add(Me.TextBox3)
        Me.TabPage5.Controls.Add(Me.Label101)
        Me.TabPage5.Controls.Add(Me.Label100)
        Me.TabPage5.Controls.Add(Me.Label99)
        Me.TabPage5.Controls.Add(Me.Label98)
        Me.TabPage5.Controls.Add(Me.Label97)
        Me.TabPage5.Controls.Add(Me.Label96)
        Me.TabPage5.Controls.Add(Me.Label95)
        Me.TabPage5.Controls.Add(Me.Button10)
        Me.TabPage5.Controls.Add(Me.Button8)
        Me.TabPage5.Controls.Add(Me.Label94)
        Me.TabPage5.Controls.Add(Me.Label93)
        Me.TabPage5.Controls.Add(Me.Label92)
        Me.TabPage5.Controls.Add(Me.Label91)
        Me.TabPage5.Controls.Add(Me.Label90)
        Me.TabPage5.Controls.Add(Me.Label89)
        Me.TabPage5.Controls.Add(Me.Label88)
        Me.TabPage5.Controls.Add(Me.Label86)
        Me.TabPage5.Controls.Add(Me.Label85)
        Me.TabPage5.Controls.Add(Me.Label84)
        Me.TabPage5.Controls.Add(Me.Label83)
        Me.TabPage5.Controls.Add(Me.Label82)
        Me.TabPage5.Controls.Add(Me.Label81)
        Me.TabPage5.Controls.Add(Me.Label80)
        Me.TabPage5.Controls.Add(Me.Label79)
        Me.TabPage5.Controls.Add(Me.Label78)
        Me.TabPage5.Controls.Add(Me.Label77)
        Me.TabPage5.Controls.Add(Me.Label76)
        Me.TabPage5.Controls.Add(Me.Label75)
        Me.TabPage5.Controls.Add(Me.Label74)
        Me.TabPage5.Controls.Add(Me.Label73)
        Me.TabPage5.Controls.Add(Me.Label72)
        Me.TabPage5.Controls.Add(Me.Label71)
        Me.TabPage5.Controls.Add(Me.Panel1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 21)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(896, 543)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "修理情報"
        '
        'Label148
        '
        Me.Label148.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label148.Location = New System.Drawing.Point(264, 8)
        Me.Label148.Name = "Label148"
        Me.Label148.Size = New System.Drawing.Size(88, 24)
        Me.Label148.TabIndex = 1064
        Me.Label148.Text = "Label148"
        Me.Label148.Visible = False
        '
        'Label147
        '
        Me.Label147.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label147.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label147.Location = New System.Drawing.Point(8, 448)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(136, 20)
        Me.Label147.TabIndex = 1063
        Me.Label147.Text = "連絡可能時間"
        Me.Label147.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox11.Location = New System.Drawing.Point(152, 448)
        Me.TextBox11.MaxLength = 20
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(344, 22)
        Me.TextBox11.TabIndex = 155
        Me.TextBox11.Text = "TextBox11"
        '
        'Label145
        '
        Me.Label145.BackColor = System.Drawing.SystemColors.Control
        Me.Label145.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label145.ForeColor = System.Drawing.Color.Black
        Me.Label145.Location = New System.Drawing.Point(152, 88)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(336, 20)
        Me.Label145.TabIndex = 1062
        Me.Label145.Text = "Label145"
        '
        'Label146
        '
        Me.Label146.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label146.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label146.Location = New System.Drawing.Point(8, 88)
        Me.Label146.Name = "Label146"
        Me.Label146.Size = New System.Drawing.Size(136, 20)
        Me.Label146.TabIndex = 1061
        Me.Label146.Text = "商品カテゴリー"
        Me.Label146.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ComboBox15
        '
        Me.ComboBox15.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox15.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ComboBox15.Location = New System.Drawing.Point(376, 496)
        Me.ComboBox15.MaxDropDownItems = 26
        Me.ComboBox15.Name = "ComboBox15"
        Me.ComboBox15.Size = New System.Drawing.Size(120, 24)
        Me.ComboBox15.TabIndex = 200
        Me.ComboBox15.Text = "ComboBox15"
        '
        'Label144
        '
        Me.Label144.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label144.Location = New System.Drawing.Point(496, 496)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(32, 24)
        Me.Label144.TabIndex = 1060
        Me.Label144.Text = "Label144"
        Me.Label144.Visible = False
        '
        'ComboBox14
        '
        Me.ComboBox14.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox14.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ComboBox14.Location = New System.Drawing.Point(152, 496)
        Me.ComboBox14.MaxDropDownItems = 26
        Me.ComboBox14.Name = "ComboBox14"
        Me.ComboBox14.Size = New System.Drawing.Size(120, 24)
        Me.ComboBox14.TabIndex = 190
        Me.ComboBox14.Text = "ComboBox14"
        '
        'ComboBox13
        '
        Me.ComboBox13.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox13.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ComboBox13.Location = New System.Drawing.Point(152, 496)
        Me.ComboBox13.MaxDropDownItems = 26
        Me.ComboBox13.Name = "ComboBox13"
        Me.ComboBox13.Size = New System.Drawing.Size(120, 24)
        Me.ComboBox13.TabIndex = 180
        Me.ComboBox13.Text = "ComboBox13"
        '
        'Label143
        '
        Me.Label143.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label143.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label143.Location = New System.Drawing.Point(600, 192)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(56, 20)
        Me.Label143.TabIndex = 1057
        Me.Label143.Text = "ログ入力"
        Me.Label143.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox10.Location = New System.Drawing.Point(656, 184)
        Me.TextBox10.MaxLength = 500
        Me.TextBox10.Multiline = True
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox10.Size = New System.Drawing.Size(224, 296)
        Me.TextBox10.TabIndex = 230
        Me.TextBox10.Text = "TextBox10"
        '
        'Label130
        '
        Me.Label130.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label130.Location = New System.Drawing.Point(312, 496)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(32, 24)
        Me.Label130.TabIndex = 1055
        Me.Label130.Text = "Label130"
        Me.Label130.Visible = False
        '
        'Label129
        '
        Me.Label129.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label129.Location = New System.Drawing.Point(272, 496)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(32, 24)
        Me.Label129.TabIndex = 1054
        Me.Label129.Text = "Label129"
        Me.Label129.Visible = False
        '
        'Label128
        '
        Me.Label128.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label128.Location = New System.Drawing.Point(840, 64)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(32, 24)
        Me.Label128.TabIndex = 1053
        Me.Label128.Text = "Label128"
        Me.Label128.Visible = False
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label103.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.Black
        Me.Label103.Location = New System.Drawing.Point(488, 88)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(80, 20)
        Me.Label103.TabIndex = 955
        Me.Label103.Text = "Label103"
        Me.Label103.Visible = False
        '
        'Label102
        '
        Me.Label102.BackColor = System.Drawing.SystemColors.Control
        Me.Label102.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.ForeColor = System.Drawing.Color.Black
        Me.Label102.Location = New System.Drawing.Point(696, 120)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(152, 20)
        Me.Label102.TabIndex = 954
        Me.Label102.Text = "Label102"
        '
        'Label87
        '
        Me.Label87.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label87.Location = New System.Drawing.Point(608, 120)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(80, 20)
        Me.Label87.TabIndex = 953
        Me.Label87.Text = "完了日"
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButton4)
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Controls.Add(Me.RadioButton10)
        Me.Panel2.Location = New System.Drawing.Point(152, 280)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(296, 24)
        Me.Panel2.TabIndex = 53
        Me.Panel2.TabStop = True
        '
        'RadioButton4
        '
        Me.RadioButton4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RadioButton4.Location = New System.Drawing.Point(80, 0)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton4.TabIndex = 50
        Me.RadioButton4.Text = "出張"
        '
        'RadioButton3
        '
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RadioButton3.Location = New System.Drawing.Point(8, 0)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(64, 24)
        Me.RadioButton3.TabIndex = 40
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "引取"
        '
        'RadioButton10
        '
        Me.RadioButton10.Enabled = False
        Me.RadioButton10.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RadioButton10.Location = New System.Drawing.Point(160, 0)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(56, 24)
        Me.RadioButton10.TabIndex = 81
        Me.RadioButton10.Text = "持込"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.PictureBox2.Location = New System.Drawing.Point(608, 32)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(160, 2)
        Me.PictureBox2.TabIndex = 951
        Me.PictureBox2.TabStop = False
        '
        'ComboBox16
        '
        Me.ComboBox16.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox16.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ComboBox16.Location = New System.Drawing.Point(696, 88)
        Me.ComboBox16.Name = "ComboBox16"
        Me.ComboBox16.Size = New System.Drawing.Size(176, 24)
        Me.ComboBox16.TabIndex = 220
        Me.ComboBox16.Text = "ComboBox16"
        '
        'Date3
        '
        Me.Date3.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date3.DropDownCalendar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date3.DropDownCalendar.Size = New System.Drawing.Size(179, 195)
        Me.Date3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date3.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date3.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date3.Location = New System.Drawing.Point(696, 64)
        Me.Date3.Name = "Date3"
        Me.Date3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date3.Size = New System.Drawing.Size(96, 22)
        Me.Date3.TabIndex = 210
        Me.Date3.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date3.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date3.Value = Nothing
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.DropDownCalendar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(179, 195)
        Me.Date2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date2.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date2.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date2.Location = New System.Drawing.Point(376, 472)
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(120, 22)
        Me.Date2.TabIndex = 170
        Me.Date2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date2.Value = Nothing
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(179, 195)
        Me.Date1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(152, 472)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(120, 22)
        Me.Date1.TabIndex = 160
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = Nothing
        '
        'Edit6
        '
        Me.Edit6.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Edit6.Format = "9"
        Me.Edit6.HighlightText = True
        Me.Edit6.Location = New System.Drawing.Point(376, 424)
        Me.Edit6.MaxLength = 20
        Me.Edit6.Name = "Edit6"
        Me.Edit6.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit6.Size = New System.Drawing.Size(120, 22)
        Me.Edit6.TabIndex = 150
        Me.Edit6.Text = "1"
        '
        'Edit5
        '
        Me.Edit5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Edit5.Format = "9"
        Me.Edit5.HighlightText = True
        Me.Edit5.Location = New System.Drawing.Point(152, 424)
        Me.Edit5.MaxLength = 20
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit5.Size = New System.Drawing.Size(120, 22)
        Me.Edit5.TabIndex = 140
        Me.Edit5.Text = "1"
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox9.Location = New System.Drawing.Point(152, 400)
        Me.TextBox9.MaxLength = 60
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(344, 22)
        Me.TextBox9.TabIndex = 130
        Me.TextBox9.Text = "TextBox9"
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox8.Location = New System.Drawing.Point(152, 376)
        Me.TextBox8.MaxLength = 60
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(344, 22)
        Me.TextBox8.TabIndex = 120
        Me.TextBox8.Text = "TextBox8"
        '
        'Edit4
        '
        Me.Edit4.DropDownShadow = True
        Me.Edit4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Edit4.Format = "9"
        Me.Edit4.HighlightText = True
        Me.Edit4.Location = New System.Drawing.Point(152, 352)
        Me.Edit4.MaxLength = 7
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit4.Size = New System.Drawing.Size(80, 22)
        Me.Edit4.TabIndex = 110
        Me.Edit4.Text = "1"
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox7.Location = New System.Drawing.Point(152, 328)
        Me.TextBox7.MaxLength = 30
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(192, 22)
        Me.TextBox7.TabIndex = 90
        Me.TextBox7.Text = "TextBox7"
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.TextBox6.Location = New System.Drawing.Point(408, 328)
        Me.TextBox6.MaxLength = 30
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(192, 22)
        Me.TextBox6.TabIndex = 100
        Me.TextBox6.Text = "TextBox6"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox5.Location = New System.Drawing.Point(152, 232)
        Me.TextBox5.MaxLength = 100
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox5.Size = New System.Drawing.Size(416, 40)
        Me.TextBox5.TabIndex = 30
        Me.TextBox5.Text = "TextBox5"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox4.Location = New System.Drawing.Point(152, 184)
        Me.TextBox4.MaxLength = 100
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox4.Size = New System.Drawing.Size(416, 40)
        Me.TextBox4.TabIndex = 20
        Me.TextBox4.Text = "TextBox4"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox3.Location = New System.Drawing.Point(152, 136)
        Me.TextBox3.MaxLength = 100
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox3.Size = New System.Drawing.Size(416, 40)
        Me.TextBox3.TabIndex = 10
        Me.TextBox3.Text = "TextBox3"
        '
        'Label101
        '
        Me.Label101.BackColor = System.Drawing.SystemColors.Control
        Me.Label101.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.Black
        Me.Label101.Location = New System.Drawing.Point(432, 112)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(152, 20)
        Me.Label101.TabIndex = 930
        Me.Label101.Text = "Label101"
        '
        'Label100
        '
        Me.Label100.BackColor = System.Drawing.SystemColors.Control
        Me.Label100.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.ForeColor = System.Drawing.Color.Black
        Me.Label100.Location = New System.Drawing.Point(432, 64)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(152, 20)
        Me.Label100.TabIndex = 929
        Me.Label100.Text = "Label100"
        '
        'Label99
        '
        Me.Label99.BackColor = System.Drawing.SystemColors.Control
        Me.Label99.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.ForeColor = System.Drawing.Color.Black
        Me.Label99.Location = New System.Drawing.Point(432, 16)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(64, 20)
        Me.Label99.TabIndex = 928
        Me.Label99.Text = "Label99"
        '
        'Label98
        '
        Me.Label98.BackColor = System.Drawing.SystemColors.Control
        Me.Label98.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.ForeColor = System.Drawing.Color.Black
        Me.Label98.Location = New System.Drawing.Point(152, 112)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(208, 20)
        Me.Label98.TabIndex = 927
        Me.Label98.Text = "Label98"
        '
        'Label97
        '
        Me.Label97.BackColor = System.Drawing.SystemColors.Control
        Me.Label97.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.ForeColor = System.Drawing.Color.Black
        Me.Label97.Location = New System.Drawing.Point(152, 64)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(208, 20)
        Me.Label97.TabIndex = 926
        Me.Label97.Text = "Label97"
        '
        'Label96
        '
        Me.Label96.BackColor = System.Drawing.SystemColors.Control
        Me.Label96.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.ForeColor = System.Drawing.Color.Black
        Me.Label96.Location = New System.Drawing.Point(152, 40)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(432, 20)
        Me.Label96.TabIndex = 925
        Me.Label96.Text = "Label96"
        '
        'Label95
        '
        Me.Label95.BackColor = System.Drawing.SystemColors.Control
        Me.Label95.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.ForeColor = System.Drawing.Color.Black
        Me.Label95.Location = New System.Drawing.Point(152, 16)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(112, 20)
        Me.Label95.TabIndex = 924
        Me.Label95.Text = "Label95"
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(584, 144)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(96, 30)
        Me.Button10.TabIndex = 923
        Me.Button10.Text = "進行状況"
        '
        'Button8
        '
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(776, 496)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(96, 30)
        Me.Button8.TabIndex = 921
        Me.Button8.Text = "登録"
        '
        'Label94
        '
        Me.Label94.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label94.Location = New System.Drawing.Point(608, 96)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(80, 20)
        Me.Label94.TabIndex = 235
        Me.Label94.Text = "状　況"
        Me.Label94.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label93
        '
        Me.Label93.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label93.Location = New System.Drawing.Point(608, 64)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(80, 20)
        Me.Label93.TabIndex = 234
        Me.Label93.Text = "受付日"
        Me.Label93.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label92
        '
        Me.Label92.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label92.Location = New System.Drawing.Point(608, 16)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(172, 16)
        Me.Label92.TabIndex = 233
        Me.Label92.Text = "状況ステータス表示欄"
        '
        'Label91
        '
        Me.Label91.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label91.Location = New System.Drawing.Point(272, 472)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(96, 24)
        Me.Label91.TabIndex = 232
        Me.Label91.Text = "第２希望日時"
        Me.Label91.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label90
        '
        Me.Label90.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label90.Location = New System.Drawing.Point(8, 472)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(136, 20)
        Me.Label90.TabIndex = 231
        Me.Label90.Text = "第１希望日時"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label89
        '
        Me.Label89.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label89.Location = New System.Drawing.Point(280, 424)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(88, 24)
        Me.Label89.TabIndex = 230
        Me.Label89.Text = "連絡先"
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label88
        '
        Me.Label88.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label88.Location = New System.Drawing.Point(8, 424)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(136, 20)
        Me.Label88.TabIndex = 229
        Me.Label88.Text = "電話番号"
        Me.Label88.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label86
        '
        Me.Label86.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label86.Location = New System.Drawing.Point(8, 376)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(136, 20)
        Me.Label86.TabIndex = 227
        Me.Label86.Text = "住　所"
        Me.Label86.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label85
        '
        Me.Label85.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label85.Location = New System.Drawing.Point(8, 352)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(136, 20)
        Me.Label85.TabIndex = 226
        Me.Label85.Text = "郵便番号"
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label84
        '
        Me.Label84.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label84.Location = New System.Drawing.Point(8, 328)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(136, 20)
        Me.Label84.TabIndex = 225
        Me.Label84.Text = "お客先名（漢字）"
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label83
        '
        Me.Label83.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label83.Location = New System.Drawing.Point(352, 328)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(48, 20)
        Me.Label83.TabIndex = 224
        Me.Label83.Text = "（カナ）"
        Me.Label83.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label82
        '
        Me.Label82.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label82.Location = New System.Drawing.Point(8, 304)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(136, 20)
        Me.Label82.TabIndex = 223
        Me.Label82.Text = "顧客情報"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label81.Location = New System.Drawing.Point(8, 232)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(136, 20)
        Me.Label81.TabIndex = 222
        Me.Label81.Text = "お預り品（付属品等）"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label80
        '
        Me.Label80.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label80.Location = New System.Drawing.Point(8, 184)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(136, 20)
        Me.Label80.TabIndex = 221
        Me.Label80.Text = "その他ご要望事項"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label79.Location = New System.Drawing.Point(8, 280)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(136, 20)
        Me.Label79.TabIndex = 220
        Me.Label79.Text = "修理対象"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label78
        '
        Me.Label78.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label78.Location = New System.Drawing.Point(8, 136)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(136, 20)
        Me.Label78.TabIndex = 219
        Me.Label78.Text = "症　状"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label77
        '
        Me.Label77.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label77.Location = New System.Drawing.Point(368, 112)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(56, 24)
        Me.Label77.TabIndex = 218
        Me.Label77.Text = "メーカー"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label76
        '
        Me.Label76.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label76.Location = New System.Drawing.Point(368, 64)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(56, 24)
        Me.Label76.TabIndex = 217
        Me.Label76.Text = "購入日"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label75
        '
        Me.Label75.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label75.Location = New System.Drawing.Point(352, 16)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(72, 20)
        Me.Label75.TabIndex = 216
        Me.Label75.Text = "加入状況"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label74
        '
        Me.Label74.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label74.Location = New System.Drawing.Point(8, 112)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(136, 20)
        Me.Label74.TabIndex = 215
        Me.Label74.Text = "商　品"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label73
        '
        Me.Label73.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label73.Location = New System.Drawing.Point(8, 64)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(136, 20)
        Me.Label73.TabIndex = 214
        Me.Label73.Text = "購入店舗"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label72.Location = New System.Drawing.Point(8, 40)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(136, 20)
        Me.Label72.TabIndex = 213
        Me.Label72.Text = "保証番号"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label71.Location = New System.Drawing.Point(8, 16)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(136, 20)
        Me.Label71.TabIndex = 212
        Me.Label71.Text = "受付番号"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton5)
        Me.Panel1.Controls.Add(Me.RadioButton6)
        Me.Panel1.Controls.Add(Me.RadioButton7)
        Me.Panel1.Location = New System.Drawing.Point(152, 296)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 32)
        Me.Panel1.TabIndex = 55
        Me.Panel1.TabStop = True
        '
        'RadioButton5
        '
        Me.RadioButton5.Checked = True
        Me.RadioButton5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RadioButton5.Location = New System.Drawing.Point(8, 8)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton5.TabIndex = 60
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "変更なし"
        '
        'RadioButton6
        '
        Me.RadioButton6.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RadioButton6.Location = New System.Drawing.Point(88, 8)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton6.TabIndex = 70
        Me.RadioButton6.Text = "変更あり"
        '
        'RadioButton7
        '
        Me.RadioButton7.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RadioButton7.Location = New System.Drawing.Point(168, 8)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton7.TabIndex = 80
        Me.RadioButton7.Text = "今回のみ"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Panel3)
        Me.TabPage6.Location = New System.Drawing.Point(4, 21)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(896, 543)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "修理LOG"
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(8, 8)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(880, 528)
        Me.Panel3.TabIndex = 0
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Blue
        Me.Label47.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(336, 16)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(264, 28)
        Me.Label47.TabIndex = 199
        Me.Label47.Text = "総合補償/延長保証"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1_22
        '
        Me.Label1_22.BackColor = System.Drawing.SystemColors.Control
        Me.Label1_22.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1_22.ForeColor = System.Drawing.Color.Black
        Me.Label1_22.Location = New System.Drawing.Point(392, 376)
        Me.Label1_22.Name = "Label1_22"
        Me.Label1_22.Size = New System.Drawing.Size(128, 24)
        Me.Label1_22.TabIndex = 1053
        Me.Label1_22.Text = "満５年経過"
        Me.Label1_22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(938, 679)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form3"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Warranty System"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
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
                'Case Is = "n2"  '新規　修理検索
                '    Call dsp_tag3_n() 'Log　SET （登録）
                '    TabControl1.SelectedTab = TabPage5
            Case Is = "r1"  '対応中　加入検索
                Call dsp_tag3_r() 'Log　SET （追加）（照会）
            Case Is = "r2"  '対応中　修理検索
                Call dsp_tag3_n() 'Log　SET （登録）
                TabControl1.SelectedTab = TabPage5
        End Select

        Call dsp_tag5()     '修理情報  SET 
        Call dsp_tag6()     '修理log   SET 

        inz_F = "1"
    End Sub

    Sub CmbSet()

        ''受付店舗
        'ComboBox2_1.DataSource = P_DsCMB.Tables("SHOP")
        'ComboBox2_1.DisplayMember = "SHOP_NAME"
        'ComboBox2_1.ValueMember = "SHOP_CODE"

        ''事故形態
        'ComboBox2_2.DataSource = P_DsCMB.Tables("ACDT_CLS")
        'ComboBox2_2.DisplayMember = "NAME"
        'ComboBox2_2.ValueMember = "CLS_CODE"

        ''審査結果
        'ComboBox2_3.DataSource = P_DsCMB.Tables("RSLT_CLS")
        'ComboBox2_3.DisplayMember = "NAME"
        'ComboBox2_3.ValueMember = "CLS_CODE"

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

        'メーカー
        ComboBox17.DataSource = P_DsCMB.Tables("M_maker")
        ComboBox17.DisplayMember = "MKR_NAME"
        ComboBox17.ValueMember = "MKR_CODE"

        '部門
        ComboBox18.DataSource = P_DsCMB.Tables("M_category")
        ComboBox18.DisplayMember = "CAT_NAME"
        ComboBox18.ValueMember = "CAT_CODE"

        '商品
        P_DsCMB.Tables("M_item").Clear()
        strSQL = "SELECT ITEM_CODE, RTRIM(MODEL) AS MODEL"
        strSQL = strSQL & " FROM M_item"
        strSQL = strSQL & " WHERE (ITEM_CODE = '" & DtView1(0)("ITEM_CODE") & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsCMB, "M_item")

        '商品
        ComboBox19.DataSource = P_DsCMB.Tables("M_item")
        ComboBox19.DisplayMember = "MODEL"
        ComboBox19.ValueMember = "ITEM_CODE"

        '所在
        ComboBox16.DataSource = P_DsCMB.Tables("LOCATION")
        ComboBox16.DisplayMember = "NAME"
        ComboBox16.ValueMember = "CLS_CODE"

        '年齢層
        ComboBox2.DataSource = P_DsCMB.Tables("AGE_CLS")
        ComboBox2.DisplayMember = "NAME"
        ComboBox2.ValueMember = "CLS_CODE"
        ComboBox2.Text = Nothing

        '地域
        ComboBox3.DataSource = P_DsCMB.Tables("AREA_CLS")
        ComboBox3.DisplayMember = "NAME"
        ComboBox3.ValueMember = "CLS_CODE"
        ComboBox3.Text = Nothing

        '部門
        ComboBox4.DataSource = P_DsCMB.Tables("M_category2")
        ComboBox4.DisplayMember = "CAT_NAME"
        ComboBox4.ValueMember = "CAT_CODE"
        ComboBox4.Text = Nothing

        'メーカー
        ComboBox5.DataSource = P_DsCMB.Tables("M_maker2")
        ComboBox5.DisplayMember = "MKR_NAME"
        ComboBox5.ValueMember = "MKR_CODE"
        ComboBox5.Text = Nothing

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

        '引取希望時間帯
        ComboBox13.DataSource = P_DsCMB.Tables("HOPE_TIME_H1")
        ComboBox13.DisplayMember = "NAME"
        ComboBox13.ValueMember = "CLS_CODE"
        ComboBox13.Text = Nothing

        '出張希望時間帯
        ComboBox14.DataSource = P_DsCMB.Tables("HOPE_TIME_S1")
        ComboBox14.DisplayMember = "NAME"
        ComboBox14.ValueMember = "CLS_CODE"
        ComboBox14.Text = Nothing

        ComboBox15.DataSource = P_DsCMB.Tables("HOPE_TIME_S2")
        ComboBox15.DisplayMember = "NAME"
        ComboBox15.ValueMember = "CLS_CODE"
        ComboBox15.Text = Nothing

    End Sub

    '*************************************************
    '** 基本情報 SET
    '*************************************************
    Private Sub dsp_tag1()

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

            Label1_6.Text = Mid(DtView1(0)("WRN_NO"), 1, 4) & "  " & Mid(DtView1(0)("WRN_NO"), 5, 4) & "  " & Mid(DtView1(0)("WRN_NO"), 9, 4) & "  " & Mid(DtView1(0)("WRN_NO"), 13, 4) & "  " & Mid(DtView1(0)("WRN_NO"), 17, 4)
            If Not IsDBNull(DtView1(0)("PNT_NO")) Then Label1_5.Text = DtView1(0)("PNT_NO") Else Label1_5.Text = Nothing
            Label1_7.Text = DtView1(0)("WRN_DATE")
            If Not IsDBNull(DtView1(0)("MKR_NAME")) Then Label1_9.Text = DtView1(0)("MKR_NAME") Else Label1_9.Text = Nothing
            If Not IsDBNull(DtView1(0)("CAT_NAME")) Then Label1_10.Text = DtView1(0)("CAT_NAME") Else Label1_10.Text = Nothing
            Label1_18.Text = DtView1(0)("MODEL")
            If Not IsDBNull(DtView1(0)("MKR_CODE")) Then Label58.Text = DtView1(0)("MKR_CODE") Else Label58.Text = Nothing
            Label59.Text = DtView1(0)("CAT_CODE")
            Label60.Text = DtView1(0)("ITEM_CODE")

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
                Label1_11.Text = DtView2(0)("SHOP_NAME")
                Label126.Text = DtView1(0)("SHOP_CODE")
            Else
                Label1_11.Text = "不明"
                Label126.Text = Nothing
            End If

            Label1_12.Text = FormatCurrency(DtView1(0)("PRICE"), 0, True, TriState.True)

            Label1_13.Text = DtView1(0)("WRN_DATE") & " - " & DateAdd("d", -1, DateAdd("yyyy", 1, DtView1(0)("WRN_DATE")))

            If DateAdd("d", -1, DateAdd("yyyy", 1, DtView1(0)("WRN_DATE"))) >= Now.Date() Then
                Label1_13.BackColor = System.Drawing.Color.Blue
                Label1_13.ForeColor = System.Drawing.Color.White
            End If

            Label1_22.Visible = False
            If DtView1(0)("WRN_PRD") = "00" Then
                Label1_14.Text = "None"                                 '延長保証期間
                Me.Label1_14.ForeColor = System.Drawing.Color.Black
                Label1_21.Text = Nothing
            Else
                Dim WK_prd As Integer = DtView1(0)("WRN_PRD")
                Label1_14.Text = DateAdd("yyyy", 1, DtView1(0)("WRN_DATE")) & " - " & DateAdd("d", -1, DateAdd("yyyy", WK_prd, DtView1(0)("WRN_DATE")))
                e_date = DateAdd("d", -1, DateAdd("yyyy", WK_prd, DtView1(0)("WRN_DATE")))
                Label1_21.Text = WK_prd & "年"
                If DtView1(0)("WRN_PRD") = "10" Then
                    If DateAdd("yyyy", 5, DtView1(0)("WRN_DATE")) <= Now.Date Then
                        Label1_22.Visible = True
                    End If
                End If
            End If

            If DateAdd("d", -1, DateAdd("yyyy", 1, DtView1(0)("WRN_DATE"))) < Now.Date() And e_date > Now.Date() Then
                Label1_14.BackColor = System.Drawing.Color.Blue
                Label1_14.ForeColor = System.Drawing.Color.White
            End If

            If DtView1(0)("WRN_PRD") = "00" Then
                Label1_20.Text = "あり"
            Else
                If DtView1(0)("WRN_DATE") >= "2008/11/11" Then
                    Label1_20.Text = "なし"
                Else
                    Label1_20.Text = "あり"
                End If
            End If

            If DtView1(0)("WRN_PRD") = "00" Then
                Label1_15.Text = "None"
            Else
                Label1_15.Text = FormatCurrency(DtView1(0)("WRN_PRICE"), 0, True, TriState.True)
            End If

            If DtView1(0)("WRN_PRD") = "00" Then
                Label1_16.Text = "None"                                 '修理限度額
            Else
                If DtView1(0)("WRN_PRD") = "10" Then
                    If DateAdd("yyyy", 5, DtView1(0)("WRN_DATE")) <= Now.Date Then
                        'Label1_16.Text = FormatCurrency(DtView1(0)("PRICE") * 0.3, 0, True, TriState.True)
                        Label1_16.Text = FormatCurrency(Fix(DtView1(0)("PRICE") * 0.3), 0, True, TriState.True)
                    Else
                        'Label1_16.Text = FormatCurrency(DtView1(0)("PRICE") * 0.8, 0, True, TriState.True)
                        Label1_16.Text = FormatCurrency(Fix(DtView1(0)("PRICE") * 0.8), 0, True, TriState.True)
                    End If
                Else
                    'Label1_16.Text = FormatCurrency(DtView1(0)("PRICE") * 0.8, 0, True, TriState.True)
                    Label1_16.Text = FormatCurrency(Fix(DtView1(0)("PRICE") * 0.8), 0, True, TriState.True)
                End If
            End If

            If Not IsDBNull(DtView1(0)("CUST_NAME_KANA")) Then
                Label50.Text = DtView1(0)("CUST_NAME_KANA")
            Else
                Label50.Text = Nothing
            End If

            Label1_1.Text = DtView1(0)("CUST_NAME")
            If Not IsDBNull(DtView1(0)("BRTH_DATE")) Then
                Label1_19.Text = DtView1(0)("BRTH_DATE")
            Else
                Label1_19.Text = Nothing
            End If
            Label1_2_0.Text = DtView1(0)("ZIP1") & "-" & DtView1(0)("ZIP2")
            Label1_2_1.Text = DtView1(0)("ADRS1")
            Label1_2_2.Text = DtView1(0)("ADRS2")
            Label1_3.Text = DtView1(0)("TEL_NO")
            Label1_4.Text = DtView1(0)("CNT_NO")
            Label125.Text = DtView1(0)("SEX")
            If Not IsDBNull(DtView1(0)("BRTH_DATE")) Then
                Label127.Text = DtView1(0)("BRTH_DATE")
            Else
                Label127.Text = Nothing
            End If

        End If

    End Sub

    '*************************************************
    '** 変更　SET
    '*************************************************
    Private Sub dsp_tag4()

        TextBox4_4.Text = Trim(Label50.Text)
        TextBox4_1.Text = Trim(Label1_1.Text)
        Edit1.Text = Mid(Label1_2_0.Text, 1, 3) & Mid(Label1_2_0.Text, 5, 4)
        TextBox4_2.Text = Trim(Label1_2_1.Text)
        TextBox4_3.Text = Trim(Label1_2_2.Text)
        Edit2.Text = Trim(Label1_3.Text)
        Edit3.Text = Trim(Label1_4.Text)
        TextBox4_6.Text = Nothing
        ComboBox17.SelectedValue = Label58.Text
        ComboBox18.SelectedValue = Label59.Text
        ComboBox19.SelectedValue = Label60.Text

        Label61.Text = Trim(Label50.Text)
        Label62.Text = Trim(Label1_1.Text)
        Label63.Text = Mid(Label1_2_0.Text, 1, 3) & Mid(Label1_2_0.Text, 5, 4)
        Label64.Text = Trim(Label1_2_1.Text)
        Label65.Text = Trim(Label1_2_2.Text)
        Label66.Text = Trim(Label1_3.Text)
        Label67.Text = Trim(Label1_4.Text)
        Label68.Text = Label58.Text
        Label69.Text = Label59.Text
        Label70.Text = Label60.Text

        Label119.Text = Label58.Text
        Label120.Text = Label59.Text
        Label121.Text = Label60.Text

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
            If DtView1(0)("RSN_CODE") = "001" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
            If Not IsDBNull(DtView1(0)("END_DATE")) Then
                Label104.Visible = True
                Date4.Visible = True
                Date4.Enabled = False
                Date4.Text = DtView1(0)("END_DATE")
            Else
                Date4.Visible = False
            End If
        End If

    End Sub

    '*************************************************
    '** Log　SET （登録）
    '*************************************************
    Private Sub dsp_tag3_n()

        Label3_1.Text = Format(Now(), "yyyy/MM/dd HH:mm")
        s_date = Now()
        Label3_2.Text = Nothing
        Label3_3.Text = pName
        Label3_4.Text = Label1_1.Text
        Button1.Text = "登  録"

        Dim SqlSelectCommand As New SqlClient.SqlCommand

        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        CheckBox1.Checked = False

        If Label125.Text = "0" Then
            RadioButton8.Checked = True
        Else
            RadioButton9.Checked = True
        End If

        If Label127.Text = Nothing Then
            Label132.Text = Nothing
        Else
            Dim R_YYYYMM2 As String = A_YYYYMM(Label127.Text)
            Dim POS2 As Integer = R_YYYYMM2.LastIndexOf("/")

            Select Case CInt(Mid(R_YYYYMM2, 1, POS2))
                Case Is <= 9
                    Label132.Text = Nothing
                Case Is <= 19
                    ComboBox2.SelectedValue = "010"
                Case Is <= 29
                    ComboBox2.SelectedValue = "020"
                Case Is <= 39
                    ComboBox2.SelectedValue = "030"
                Case Is <= 49
                    ComboBox2.SelectedValue = "040"
                Case Is <= 59
                    ComboBox2.SelectedValue = "050"
                Case Is <= 69
                    ComboBox2.SelectedValue = "060"
                Case Is <= 79
                    ComboBox2.SelectedValue = "070"
                Case Is <= 89
                    ComboBox2.SelectedValue = "080"
                Case Is <= 99
                    ComboBox2.SelectedValue = "090"
                Case Else
                    Label132.Text = Nothing
            End Select

        End If

        Label133.Text = Nothing
        ComboBox4.SelectedValue = Label59.Text
        ComboBox5.SelectedValue = Label58.Text
        ComboBox6.SelectedValue = Label126.Text

        Dim R_YYYYMM As String = A_YYYYMM(Label1_7.Text)
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

        If Label1_17.Text <> "A" Then
            Call Enabled_TAB3()
        End If

    End Sub

    '*************************************************
    '** Log　SET （追加）（照会）
    '*************************************************
    Private Sub dsp_tag3_r()

        Label3_1.Text = Format(Now(), "yyyy/MM/dd HH:mm")
        s_date = Now()
        Label3_2.Text = pID

        Dim SqlSelectCommand As New SqlClient.SqlCommand

        SqlSelectCommand.CommandText = "SELECT ICDT_DATA.*, EMPL.EMPL_NAME, WRN_DATA.CUST_NAME, ICDT_DTL.RPLY, ICDT_DTL.RPLY_CLS FROM ICDT_DTL RIGHT OUTER JOIN ICDT_DATA ON ICDT_DTL.ID = ICDT_DATA.ID LEFT OUTER JOIN WRN_DATA ON ICDT_DATA.WRN_NO = WRN_DATA.WRN_NO LEFT OUTER JOIN EMPL ON ICDT_DATA.EMPL_CODE = EMPL.EMPL_CODE WHERE ICDT_DATA.ID = " & pID & " ORDER BY ICDT_DTL.RCV_DATE DESC"
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
        TextBox1.Text = RTrim(Dttbl1.Rows(0)("ASKING"))
        TextBox2.Text = RTrim(Dttbl1.Rows(0)("RPLY"))

        ComboBox1.SelectedValue = Dttbl1.Rows(0)("CUST_CLS")
        ComboBox3_2.SelectedValue = Dttbl1.Rows(0)("ICDT_CLS")
        ComboBox3_3.SelectedValue = Dttbl1.Rows(0)("STATUS")
        ComboBox3_4.SelectedValue = Dttbl1.Rows(0)("RPLY_CLS")
        Label131.Text = Dttbl1.Rows(0)("CUST_CLS")
        Label122.Text = Dttbl1.Rows(0)("ICDT_CLS")
        Label123.Text = Dttbl1.Rows(0)("STATUS")
        Label124.Text = Dttbl1.Rows(0)("RPLY_CLS")

        If Not IsDBNull(Dttbl1.Rows(0)("SEX")) Then
            If Dttbl1.Rows(0)("SEX") = "1" Then
                RadioButton9.Checked = True
            Else
                RadioButton8.Checked = True
            End If
        Else
            RadioButton9.Checked = True
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("AGE_CLS")) Then
            ComboBox2.SelectedValue = Dttbl1.Rows(0)("AGE_CLS")
        Else
            Label132.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("AREA_CLS")) Then
            ComboBox3.SelectedValue = Dttbl1.Rows(0)("AREA_CLS")
        Else
            Label133.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("CAT_CODE")) Then
            ComboBox4.SelectedValue = Dttbl1.Rows(0)("CAT_CODE")
        Else
            Label134.Text = Nothing
        End If
        If Not IsDBNull(Dttbl1.Rows(0)("MKR_CODE")) Then
            ComboBox5.SelectedValue = Dttbl1.Rows(0)("MKR_CODE")
        Else
            Label135.Text = Nothing
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

        If Dttbl1.Rows(0)("FIN_FLAG") = "1" Then    '完了済み
            Call Enabled_TAB3()
        End If

    End Sub

    '*************************************************
    '** 修理情報　SET 
    '*************************************************
    Private Sub dsp_tag5()

        Label96.Text = Label1_6.Text
        Label97.Text = Label1_11.Text
        Label98.Text = Label1_18.Text
        Label99.Text = Label1_17.Text
        Label100.Text = Label1_7.Text
        Label101.Text = Label1_9.Text
        Label145.Text = Label1_10.Text

        If pREPAIR_CODE <> Nothing Then '修理受付番号指定
            strSQL = "SELECT REPAIR_DATA.*, REPAIR_FIN.FIN_FLAG"
            strSQL = strSQL & " FROM REPAIR_DATA INNER JOIN REPAIR_FIN ON REPAIR_DATA.REPAIR_CODE = REPAIR_FIN.REPAIR_CODE"
            strSQL = strSQL & " WHERE (REPAIR_DATA.REPAIR_CODE = '" & pREPAIR_CODE & "')"
            strSQL = strSQL & " AND (REPAIR_DATA.PROC_DATE = CONVERT(DATETIME, '" & pPROC_DATE & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "REPAIR_DATA")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("REPAIR_DATA"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Label95.Text = RTrim(DtView1(0)("REPAIR_CODE"))
                Label148.Text = RTrim(DtView1(0)("REPAIR_CODE_BCD"))
                Label103.Text = RTrim(DtView1(0)("REPAIR_CODE"))
                TextBox3.Text = RTrim(DtView1(0)("SYMPTOM"))
                TextBox4.Text = RTrim(DtView1(0)("DEMAND"))
                TextBox5.Text = RTrim(DtView1(0)("CUSTODY"))
                Select Case DtView1(0)("LEAVE")
                    Case Is = "1"
                        RadioButton3.Checked = True
                    Case Is = "2"
                        RadioButton4.Checked = True
                    Case Is = "3"
                        RadioButton10.Checked = True
                End Select
                Select Case DtView1(0)("CUST_CHG")
                    Case Is = "1"
                        RadioButton5.Checked = True
                    Case Is = "2"
                        RadioButton6.Checked = True
                    Case Is = "3"
                        RadioButton7.Checked = True
                End Select
                If DtView1(0)("LEAVE") = "1" Then
                    TextBox6.Text = RTrim(Label50.Text)
                    TextBox7.Text = RTrim(Label1_1.Text)
                    Edit4.Text = Label1_2_0.Text
                    TextBox8.Text = RTrim(Label1_2_1.Text)
                    TextBox9.Text = RTrim(Label1_2_2.Text)
                    Edit5.Text = RTrim(Label1_3.Text)
                    Edit6.Text = RTrim(Label1_4.Text)
                Else
                    TextBox6.Text = RTrim(DtView1(0)("CUST_NAME_KANA"))
                    TextBox7.Text = RTrim(DtView1(0)("CUST_NAME"))
                    Edit4.Text = DtView1(0)("ZIP1") & DtView1(0)("ZIP2")
                    TextBox8.Text = RTrim(DtView1(0)("ADRS1"))
                    TextBox9.Text = RTrim(DtView1(0)("ADRS2"))
                    Edit5.Text = RTrim(DtView1(0)("TEL_NO"))
                    Edit6.Text = RTrim(DtView1(0)("CNT_NO"))
                End If
                If Not IsDBNull(DtView1(0)("HOPE_DATE1")) Then
                    Date1.Text = Format(DtView1(0)("HOPE_DATE1"), "yyyy/MM/dd")
                End If
                If Not IsDBNull(DtView1(0)("HOPE_DATE2")) Then
                    Date2.Text = Format(DtView1(0)("HOPE_DATE2"), "yyyy/MM/dd")
                End If
                If RadioButton3.Checked = True Then
                    If Not IsDBNull(DtView1(0)("HOPE_TIME1")) Then
                        ComboBox13.SelectedValue = DtView1(0)("HOPE_TIME1")
                    Else
                        Label129.Text = Nothing
                    End If
                    Label130.Text = Nothing
                    Label144.Text = Nothing
                Else
                    If Not IsDBNull(DtView1(0)("HOPE_TIME1")) Then
                        ComboBox14.SelectedValue = DtView1(0)("HOPE_TIME1")
                    Else
                        Label130.Text = Nothing
                    End If
                    If Not IsDBNull(DtView1(0)("HOPE_TIME2")) Then
                        ComboBox15.SelectedValue = DtView1(0)("HOPE_TIME2")
                    Else
                        Label144.Text = Nothing
                    End If
                    Label129.Text = Nothing
                End If
                Date3.Text = DtView1(0)("REPAIR_DATE")
                ComboBox16.SelectedValue = DtView1(0)("LOCATION")
                Label102.Text = Format(DtView1(0)("PROC_DATE"), "yyyy/MM/dd")
                TextBox10.Text = RTrim(DtView1(0)("LOG_DATA"))
                TextBox11.Text = RTrim(DtView1(0)("CALL_TIME"))

                If DtView1(0)("FIN_FLAG") = "1" Then    '完了済み
                    Call fin()
                Else
                    Label102.Visible = False
                    Button8.Text = "追加"
                End If
            End If
        Else
            strSQL = "SELECT REPAIR_DATA.REPAIR_CODE, MAX(REPAIR_DATA.PROC_DATE) AS PROC_DATE"
            strSQL = strSQL & " FROM REPAIR_DATA INNER JOIN REPAIR_FIN ON REPAIR_DATA.REPAIR_CODE = REPAIR_FIN.REPAIR_CODE"
            strSQL = strSQL & " WHERE (REPAIR_DATA.WRN_NO = '" & pWrn_no & "')"
            strSQL = strSQL & " AND (REPAIR_FIN.FIN_FLAG = '0')"
            strSQL = strSQL & " GROUP BY REPAIR_DATA.REPAIR_CODE"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "REPAIR_DATA2")
            DB_CLOSE()
            DtView2 = New DataView(DsList1.Tables("REPAIR_DATA2"), "", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then  '追加
                strSQL = "SELECT REPAIR_DATA.*, REPAIR_FIN.FIN_FLAG"
                strSQL = strSQL & " FROM REPAIR_DATA INNER JOIN REPAIR_FIN ON REPAIR_DATA.REPAIR_CODE = REPAIR_FIN.REPAIR_CODE"
                strSQL = strSQL & " WHERE (REPAIR_DATA.REPAIR_CODE = '" & DtView2(0)("REPAIR_CODE") & "')"
                strSQL = strSQL & " AND (REPAIR_DATA.PROC_DATE = CONVERT(DATETIME, '" & DtView2(0)("PROC_DATE") & "', 102))"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(DsList1, "REPAIR_DATA")
                DB_CLOSE()
                DtView1 = New DataView(DsList1.Tables("REPAIR_DATA"), "", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    Label95.Text = RTrim(DtView1(0)("REPAIR_CODE"))
                    Label148.Text = RTrim(DtView1(0)("REPAIR_CODE_BCD"))
                    Label103.Text = RTrim(DtView1(0)("REPAIR_CODE"))
                    TextBox3.Text = RTrim(DtView1(0)("SYMPTOM"))
                    TextBox4.Text = RTrim(DtView1(0)("DEMAND"))
                    TextBox5.Text = RTrim(DtView1(0)("CUSTODY"))
                    Select Case DtView1(0)("LEAVE")
                        Case Is = "1"
                            RadioButton3.Checked = True
                        Case Is = "2"
                            RadioButton4.Checked = True
                        Case Is = "3"
                            RadioButton10.Checked = True
                    End Select
                    Select Case DtView1(0)("CUST_CHG")
                        Case Is = "1"
                            RadioButton5.Checked = True
                        Case Is = "2"
                            RadioButton6.Checked = True
                        Case Is = "3"
                            RadioButton7.Checked = True
                    End Select
                    If DtView1(0)("LEAVE") = "1" Then
                        TextBox6.Text = RTrim(Label50.Text)
                        TextBox7.Text = RTrim(Label1_1.Text)
                        Edit4.Text = Label1_2_0.Text
                        TextBox8.Text = RTrim(Label1_2_1.Text)
                        TextBox9.Text = RTrim(Label1_2_2.Text)
                        Edit5.Text = RTrim(Label1_3.Text)
                        Edit6.Text = RTrim(Label1_4.Text)
                    Else
                        TextBox6.Text = RTrim(DtView1(0)("CUST_NAME_KANA"))
                        TextBox7.Text = RTrim(DtView1(0)("CUST_NAME"))
                        Edit4.Text = DtView1(0)("ZIP1") & DtView1(0)("ZIP2")
                        TextBox8.Text = RTrim(DtView1(0)("ADRS1"))
                        TextBox9.Text = RTrim(DtView1(0)("ADRS2"))
                        Edit5.Text = RTrim(DtView1(0)("TEL_NO"))
                        Edit6.Text = RTrim(DtView1(0)("CNT_NO"))
                    End If

                    If Not IsDBNull(DtView1(0)("HOPE_DATE1")) Then
                        Date1.Text = Format(DtView1(0)("HOPE_DATE1"), "yyyy/MM/dd")
                    End If
                    If Not IsDBNull(DtView1(0)("HOPE_DATE2")) Then
                        Date2.Text = Format(DtView1(0)("HOPE_DATE2"), "yyyy/MM/dd")
                    End If
                    If RadioButton3.Checked = True Then
                        If Not IsDBNull(DtView1(0)("HOPE_TIME1")) Then
                            ComboBox13.SelectedValue = DtView1(0)("HOPE_TIME1")
                        Else
                            Label129.Text = Nothing
                        End If
                        Label130.Text = Nothing
                        Label144.Text = Nothing
                    Else
                        If Not IsDBNull(DtView1(0)("HOPE_TIME1")) Then
                            ComboBox14.SelectedValue = DtView1(0)("HOPE_TIME1")
                        Else
                            Label130.Text = Nothing
                        End If
                        If Not IsDBNull(DtView1(0)("HOPE_TIME2")) Then
                            ComboBox15.SelectedValue = DtView1(0)("HOPE_TIME2")
                        Else
                            Label144.Text = Nothing
                        End If
                        Label129.Text = Nothing
                    End If
                    Date3.Text = DtView1(0)("REPAIR_DATE")
                    ComboBox16.SelectedValue = DtView1(0)("LOCATION")
                    TextBox10.Text = RTrim(DtView1(0)("LOG_DATA"))
                    TextBox11.Text = RTrim(DtView1(0)("CALL_TIME"))
                    Button8.Text = "追加"
                End If
            Else                        '新規
                Label95.Text = Nothing
                Label148.Text = Nothing
                Label103.Text = Nothing
                TextBox3.Text = Nothing
                TextBox4.Text = Nothing
                TextBox5.Text = Nothing
                TextBox6.Text = RTrim(Label50.Text)
                TextBox7.Text = RTrim(Label1_1.Text)

                Edit4.Text = Label1_2_0.Text
                TextBox8.Text = RTrim(Label1_2_1.Text)
                TextBox9.Text = RTrim(Label1_2_2.Text)
                Edit5.Text = RTrim(Label1_3.Text)
                Edit6.Text = RTrim(Label1_4.Text)
                Date1.Number = 0
                Date2.Number = 0
                Label129.Text = Nothing
                Label130.Text = Nothing
                Label144.Text = Nothing
                Date3.Text = Format(Now.Date, "yyyy/MM/dd")
                TextBox10.Text = Nothing
                TextBox11.Text = Nothing
                Button10.Visible = False
                If Label1_17.Text <> "A" Then
                    Call Enabled_TAB5()
                End If
            End If
            Label102.Visible = False
        End If

        If Label129.Text = Nothing Then ComboBox13.Text = Nothing : ComboBox13.Text = Nothing
        If Label130.Text = Nothing Then ComboBox14.Text = Nothing : ComboBox14.Text = Nothing
        If Label144.Text = Nothing Then ComboBox15.Text = Nothing : ComboBox15.Text = Nothing
        If Label128.Text = Nothing Then ComboBox16.Text = Nothing : ComboBox16.Text = Nothing
    End Sub

    Sub fin()
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        RadioButton3.Enabled = False
        RadioButton4.Enabled = False
        RadioButton5.Enabled = False
        RadioButton6.Enabled = False
        RadioButton7.Enabled = False
        RadioButton10.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        Edit4.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        Edit5.Enabled = False
        Edit6.Enabled = False
        Date1.Enabled = False
        Date2.Enabled = False
        Date3.Enabled = False
        ComboBox13.Enabled = False
        ComboBox14.Enabled = False
        ComboBox15.Enabled = False
        ComboBox16.Enabled = False
        Edit4.BackColor = System.Drawing.SystemColors.Control
        Edit5.BackColor = System.Drawing.SystemColors.Control
        Edit6.BackColor = System.Drawing.SystemColors.Control
        Date1.BackColor = System.Drawing.SystemColors.Control
        Date2.BackColor = System.Drawing.SystemColors.Control
        Date3.BackColor = System.Drawing.SystemColors.Control
        TextBox10.Enabled = False
        TextBox11.Enabled = False
        Button8.Visible = False
        Label102.Visible = True
    End Sub

    '*************************************************
    '** 修理log　SET 
    '*************************************************
    Private Sub dsp_tag6()

        Panel3.Controls.Clear()
        DsList2.Clear()
        line_no = 0

        strSQL = "SELECT REPAIR_DATA.*, EMPL.EMPL_NAME, REPAIR_FIN.FIN_FLAG, xb.TIME1, xc.TIME2, xd.TIME3"
        strSQL = strSQL & " FROM REPAIR_DATA INNER JOIN REPAIR_FIN ON REPAIR_DATA.REPAIR_CODE = REPAIR_FIN.REPAIR_CODE AND"
        strSQL = strSQL & " REPAIR_DATA.PROC_DATE = REPAIR_FIN.PROC_DATE INNER JOIN EMPL ON REPAIR_DATA.EMPL_CODE = EMPL.EMPL_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME3 FROM CLS_CODE WHERE (CLS_NO = '023')) xd ON"
        strSQL = strSQL & " REPAIR_DATA.HOPE_TIME1 = xd.CLS_CODE COLLATE Japanese_CI_AS LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME2 FROM CLS_CODE WHERE (CLS_NO = '023')) xc ON"
        strSQL = strSQL & " REPAIR_DATA.HOPE_TIME2 = xc.CLS_CODE COLLATE Japanese_CI_AS LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME1 FROM CLS_CODE WHERE (CLS_NO = '022')) xb ON"
        strSQL = strSQL & " REPAIR_DATA.HOPE_TIME1 = xb.CLS_CODE COLLATE Japanese_CI_AS"
        strSQL = strSQL & " WHERE (REPAIR_DATA.WRN_NO = '" & pWrn_no & "')"
        strSQL = strSQL & " ORDER BY REPAIR_DATA.REPAIR_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList2, "REPAIR_log")
        DB_CLOSE()
        DtView1 = New DataView(DsList2.Tables("REPAIR_log"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                line_no = line_no + 1

                '受付番号
                en = 1
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(10, 20 * line_no)
                label(line_no, en).Size = New System.Drawing.Size(70, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = "受付番号: "
                Panel3.Controls.Add(label(line_no, en))

                en = 2
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(80, 20 * line_no)
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = DtView1(i)("REPAIR_CODE")
                Panel3.Controls.Add(label(line_no, en))

                '受付日
                en = 3
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(180, 20 * line_no)
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "受付日: "
                Panel3.Controls.Add(label(line_no, en))

                en = 4
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(280, 20 * line_no)
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = Format(DtView1(i)("REPAIR_DATE"), "yyyy.MM.dd")
                Panel3.Controls.Add(label(line_no, en))

                'ｽﾃｰﾀｽ
                en = 5
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(480, 20 * line_no)
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "ｽﾃｰﾀｽ: "
                Panel3.Controls.Add(label(line_no, en))

                en = 6
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(580, 20 * line_no)
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                If DtView1(i)("FIN_FLAG") = "0" Then
                    label(line_no, en).Text = "対応中"
                Else
                    label(line_no, en).Text = "完了"
                End If
                Panel3.Controls.Add(label(line_no, en))

                '症状
                en = 7
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(10, 20 * (line_no + 1))
                label(line_no, en).Size = New System.Drawing.Size(150, 60)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "症状: "
                Panel3.Controls.Add(label(line_no, en))

                en = 8
                txtbox(line_no, en) = New TextBox
                txtbox(line_no, en).AutoSize = False
                txtbox(line_no, en).BackColor = System.Drawing.Color.White
                txtbox(line_no, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                txtbox(line_no, en).Multiline = True
                txtbox(line_no, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
                txtbox(line_no, en).ReadOnly = True
                txtbox(line_no, en).TabStop = False
                txtbox(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                txtbox(line_no, en).Location = New System.Drawing.Point(160, 20 * (line_no + 1))
                txtbox(line_no, en).Size = New System.Drawing.Size(240, 60)
                txtbox(line_no, en).Text = RTrim(DtView1(i)("SYMPTOM"))
                Panel3.Controls.Add(txtbox(line_no, en))

                'その他ご要望事項
                en = 9
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(10, 20 * (line_no + 4))
                label(line_no, en).Size = New System.Drawing.Size(150, 60)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "その他ご要望事項: "
                Panel3.Controls.Add(label(line_no, en))

                en = 11
                txtbox(line_no, en) = New TextBox
                txtbox(line_no, en).AutoSize = False
                txtbox(line_no, en).BackColor = System.Drawing.Color.White
                txtbox(line_no, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                txtbox(line_no, en).Multiline = True
                txtbox(line_no, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
                txtbox(line_no, en).ReadOnly = True
                txtbox(line_no, en).TabStop = False
                txtbox(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                txtbox(line_no, en).Location = New System.Drawing.Point(160, 20 * (line_no + 4))
                txtbox(line_no, en).Size = New System.Drawing.Size(240, 60)
                txtbox(line_no, en).Text = RTrim(DtView1(i)("DEMAND"))
                Panel3.Controls.Add(txtbox(line_no, en))

                'お預り品（付属品等）
                en = 11
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(10, 20 * (line_no + 7))
                label(line_no, en).Size = New System.Drawing.Size(150, 60)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "お預り品（付属品等）: "
                Panel3.Controls.Add(label(line_no, en))

                en = 12
                txtbox(line_no, en) = New TextBox
                txtbox(line_no, en).AutoSize = False
                txtbox(line_no, en).BackColor = System.Drawing.Color.White
                txtbox(line_no, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                txtbox(line_no, en).Multiline = True
                txtbox(line_no, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
                txtbox(line_no, en).ReadOnly = True
                txtbox(line_no, en).TabStop = False
                txtbox(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                txtbox(line_no, en).Location = New System.Drawing.Point(160, 20 * (line_no + 7))
                txtbox(line_no, en).Size = New System.Drawing.Size(240, 60)
                txtbox(line_no, en).Text = RTrim(DtView1(i)("CUSTODY"))
                Panel3.Controls.Add(txtbox(line_no, en))

                'ログ
                en = 13
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(10, 20 * (line_no + 10))
                label(line_no, en).Size = New System.Drawing.Size(150, 60)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "ログ: "
                Panel3.Controls.Add(label(line_no, en))

                en = 14
                txtbox(line_no, en) = New TextBox
                txtbox(line_no, en).AutoSize = False
                txtbox(line_no, en).BackColor = System.Drawing.Color.White
                txtbox(line_no, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                txtbox(line_no, en).Multiline = True
                txtbox(line_no, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
                txtbox(line_no, en).ReadOnly = True
                txtbox(line_no, en).TabStop = False
                txtbox(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                txtbox(line_no, en).Location = New System.Drawing.Point(160, 20 * (line_no + 10))
                txtbox(line_no, en).Size = New System.Drawing.Size(240, 60)
                txtbox(line_no, en).Text = RTrim(DtView1(i)("LOG_DATA"))
                Panel3.Controls.Add(txtbox(line_no, en))

                '修理対象
                en = 15
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 1))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "修理対象: "
                Panel3.Controls.Add(label(line_no, en))

                en = 16
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 1))
                label(line_no, en).Size = New System.Drawing.Size(200, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                If DtView1(i)("LEAVE") = "1" Then
                    label(line_no, en).Text = "引取"
                Else
                    label(line_no, en).Text = "出張"
                End If
                Panel3.Controls.Add(label(line_no, en))

                '顧客情報
                en = 17
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 2))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "顧客情報: "
                Panel3.Controls.Add(label(line_no, en))

                en = 18
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 2))
                label(line_no, en).Size = New System.Drawing.Size(200, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                If DtView1(i)("CUST_CHG") = "1" Then
                    label(line_no, en).Text = "変更なし"
                Else
                    label(line_no, en).Text = "今回のみ"
                End If
                Panel3.Controls.Add(label(line_no, en))

                'お客様名
                en = 19
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 3))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "お客様名: "
                Panel3.Controls.Add(label(line_no, en))

                en = 20
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 3))
                label(line_no, en).Size = New System.Drawing.Size(200, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = RTrim(DtView1(i)("CUST_NAME"))
                If RTrim(DtView1(i)("CUST_NAME_KANA")) <> Nothing Then
                    label(line_no, en).Text = label(line_no, en).Text & "（ " & RTrim(DtView1(i)("CUST_NAME_KANA")) & " ）"
                End If
                Panel3.Controls.Add(label(line_no, en))

                '郵便番号
                en = 21
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 4))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "郵便番号: "
                Panel3.Controls.Add(label(line_no, en))

                en = 22
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 4))
                label(line_no, en).Size = New System.Drawing.Size(200, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = DtView1(i)("ZIP1") & "-" & DtView1(i)("ZIP2")
                Panel3.Controls.Add(label(line_no, en))

                '住所
                en = 23
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 5))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "住所: "
                Panel3.Controls.Add(label(line_no, en))

                en = 24
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 5))
                label(line_no, en).Size = New System.Drawing.Size(350, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = DtView1(i)("ADRS1")
                Panel3.Controls.Add(label(line_no, en))

                en = 25
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 6))
                label(line_no, en).Size = New System.Drawing.Size(350, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = DtView1(i)("ADRS2")
                Panel3.Controls.Add(label(line_no, en))

                '電話番号
                en = 26
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 7))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "電話番号: "
                Panel3.Controls.Add(label(line_no, en))

                en = 27
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 7))
                label(line_no, en).Size = New System.Drawing.Size(140, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = DtView1(i)("TEL_NO")
                Panel3.Controls.Add(label(line_no, en))

                '連絡先
                en = 28
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(640, 20 * (line_no + 7))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "連絡先: "
                Panel3.Controls.Add(label(line_no, en))

                en = 29
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(740, 20 * (line_no + 7))
                label(line_no, en).Size = New System.Drawing.Size(120, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = DtView1(i)("CNT_NO")
                Panel3.Controls.Add(label(line_no, en))

                '連絡可能時間
                en = 30
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 8))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "連絡可能時間: "
                Panel3.Controls.Add(label(line_no, en))

                en = 31
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 8))
                label(line_no, en).Size = New System.Drawing.Size(300, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = RTrim(DtView1(i)("CALL_TIME"))
                Panel3.Controls.Add(label(line_no, en))

                '第一希望日時
                en = 32
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 9))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "第一希望日時: "
                Panel3.Controls.Add(label(line_no, en))

                en = 33
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 9))
                label(line_no, en).Size = New System.Drawing.Size(140, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                label(line_no, en).Text = Format(DtView1(i)("HOPE_DATE1"), "yyyy.MM.dd")
                Panel3.Controls.Add(label(line_no, en))

                en = 34
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 10))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                If DtView1(i)("LEAVE") = "1" Then
                    label(line_no, en).Text = DtView1(i)("TIME1")
                Else
                    label(line_no, en).Text = DtView1(i)("TIME3")
                End If
                Panel3.Controls.Add(label(line_no, en))

                '第二希望日時
                en = 35
                label(line_no, en) = New Label
                label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(640, 20 * (line_no + 9))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
                label(line_no, en).Text = "第二希望日時: "
                Panel3.Controls.Add(label(line_no, en))

                en = 36
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(740, 20 * (line_no + 9))
                label(line_no, en).Size = New System.Drawing.Size(120, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                If Not IsDBNull(DtView1(i)("HOPE_DATE2")) Then
                    label(line_no, en).Text = Format(DtView1(i)("HOPE_DATE2"), "yyyy.MM.dd")
                End If
                Panel3.Controls.Add(label(line_no, en))

                en = 37
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Location = New System.Drawing.Point(740, 20 * (line_no + 10))
                label(line_no, en).Size = New System.Drawing.Size(100, 20)
                label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                If Not IsDBNull(DtView1(i)("TIME2")) Then
                    label(line_no, en).Text = DtView1(i)("TIME2")
                End If
                Panel3.Controls.Add(label(line_no, en))

                line_no = line_no + 12


                strSQL = "SELECT REPAIR_DATA.REPAIR_CODE, REPAIR_DATA.PROC_DATE, EMPL.EMPL_NAME, xa.LOCATION_NAME"
                strSQL = strSQL & " FROM REPAIR_DATA LEFT OUTER JOIN EMPL ON REPAIR_DATA.EMPL_CODE = EMPL.EMPL_CODE LEFT OUTER JOIN"
                strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS LOCATION_NAME FROM CLS_CODE WHERE (CLS_NO = '013')) xa ON"
                strSQL = strSQL & " REPAIR_DATA.LOCATION = xa.CLS_CODE COLLATE Japanese_CI_AS"
                strSQL = strSQL & " WHERE (REPAIR_DATA.WRN_NO = '" & pWrn_no & "')"
                strSQL = strSQL & " ORDER BY REPAIR_DATA.PROC_DATE"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(DsList2, "REPAIR_log2")
                DB_CLOSE()
                DtView2 = New DataView(DsList2.Tables("REPAIR_log2"), "REPAIR_CODE = '" & DtView1(i)("REPAIR_CODE") & "'", "PROC_DATE", DataViewRowState.CurrentRows)
                If DtView2.Count <> 0 Then
                    For i2 = 0 To DtView2.Count - 1

                        line_no = line_no + 1

                        '変更日時
                        en = 40
                        label(line_no, en) = New Label
                        label(line_no, en).BackColor = System.Drawing.Color.LightBlue
                        label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                        label(line_no, en).Location = New System.Drawing.Point(10, 20 * line_no)
                        label(line_no, en).Size = New System.Drawing.Size(200, 20)
                        label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                        label(line_no, en).Text = "変更日時: " & Format(DtView2(i2)("PROC_DATE"), "yyyy.MM.dd HH:mm")
                        Panel3.Controls.Add(label(line_no, en))

                        '担当
                        en = 41
                        label(line_no, en) = New Label
                        label(line_no, en).BackColor = System.Drawing.Color.LightBlue
                        label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                        label(line_no, en).Location = New System.Drawing.Point(210, 20 * line_no)
                        label(line_no, en).Size = New System.Drawing.Size(200, 20)
                        label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                        label(line_no, en).Text = "担当: " & DtView2(i2)("EMPL_NAME")
                        Panel3.Controls.Add(label(line_no, en))

                        '状況
                        en = 42
                        label(line_no, en) = New Label
                        label(line_no, en).BackColor = System.Drawing.Color.LightBlue
                        label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                        label(line_no, en).Location = New System.Drawing.Point(410, 20 * line_no)
                        label(line_no, en).Size = New System.Drawing.Size(440, 20)
                        label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
                        label(line_no, en).Text = "状況: " & DtView2(i2)("LOCATION_NAME")
                        Panel3.Controls.Add(label(line_no, en))

                    Next
                    line_no = line_no + 1
                End If
            Next
        Else
            en = 1
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 200)
            label(line_no, en).Size = New System.Drawing.Size(200, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = "修理Logはありません。"
            Panel3.Controls.Add(label(line_no, en))
        End If

    End Sub

    '*************************************************
    '** 基本情報の処理
    '*************************************************

    'ﾌﾘｶﾞﾅ入力
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        pKANA = Trim(Label50.Text)
        Dim KANA_input As New KANA_input
        KANA_input.ShowDialog()
        If pKANA <> Nothing Then
            Label50.Text = pKANA
            TextBox4_4.Text = pKANA
            Label61.Text = pKANA
            If RadioButton5.Checked = True Then TextBox6.Text = pKANA
        End If
    End Sub

    'コピー用表示
    Private Sub Button_txt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_txt.Click
        TextBox_CSV.Text = Chr(39) & Label1_6.Text & vbCrLf & Label1_7.Text & vbCrLf & Trim(Label1_9.Text) & vbCrLf & Trim(Label1_10.Text) & vbCrLf & _
                        Trim(Label1_18.Text) & vbCrLf & Trim(Label1_11.Text) & vbCrLf & Label1_12.Text & vbCrLf & _
                        Trim(Label1_14.Text) & vbCrLf & Trim(Label1_1.Text) & vbCrLf & Trim(Label1_2_0.Text) & vbCrLf & _
                        Trim(Label1_2_1.Text) & vbCrLf & Trim(Label1_2_2.Text) & vbCrLf & Trim(Label1_3.Text) & vbCrLf & Trim(Label1_4.Text)
    End Sub

    '*************************************************
    '** ｌｏｇの処理
    '*************************************************

    '入力後

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
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

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        If RTrim(ComboBox2.Text) = Nothing Then
            Label132.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("AGE_CLS"), "NAME='" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label132.Text = Nothing
            Else
                Label132.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.Leave
        If RTrim(ComboBox3.Text) = Nothing Then
            Label133.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("AREA_CLS"), "NAME='" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label133.Text = Nothing
            Else
                Label133.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.Leave
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

    Private Sub ComboBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.Leave
        If RTrim(ComboBox5.Text) = Nothing Then
            Label135.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_maker2"), "MKR_NAME='" & ComboBox5.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label135.Text = Nothing
            Else
                Label135.Text = DtView1(0)("MKR_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.Leave
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

    Private Sub ComboBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.Leave
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

    Private Sub ComboBox8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox8.Leave
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

    Private Sub ComboBox9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox9.Leave
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

    Private Sub ComboBox10_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox10.Leave
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

    Private Sub ComboBox11_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox11.Leave
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

    Private Sub ComboBox12_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox12.Leave
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

    Private Sub ComboBox3_2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3_2.Leave
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

    Private Sub ComboBox3_3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3_3.Leave
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

    Private Sub ComboBox3_4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3_4.Leave
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
                If fin_flg = "0" Then
                    strSQL = strSQL & ", fin_DATE = NULL"
                Else
                    strSQL = strSQL & ", fin_DATE = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                End If
                strSQL = strSQL & ", CUST_CLS = '" & ComboBox1.SelectedValue & "'"
                strSQL = strSQL & ", ICDT_CLS = '" & ComboBox3_2.SelectedValue & "'"
                strSQL = strSQL & ", ASKING = '" & TextBox1.Text & "'"
                strSQL = strSQL & ", STATUS = '" & ComboBox3_3.SelectedValue & "'"
                If RadioButton9.Checked = True Then
                    strSQL = strSQL & ", SEX = '1'"
                Else
                    strSQL = strSQL & ", SEX = '2'"
                End If
                If Trim(ComboBox2.Text) <> Nothing Then
                    strSQL = strSQL & ", AGE_CLS = '" & ComboBox2.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", AGE_CLS = NULL"
                End If

                If Trim(ComboBox3.Text) <> Nothing Then
                    strSQL = strSQL & ", AREA_CLS = '" & ComboBox3.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", AREA_CLS = NULL"
                End If
                If Trim(ComboBox4.Text) <> Nothing Then
                    strSQL = strSQL & ", CAT_CODE = '" & ComboBox4.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", CAT_CODE = NULL"
                End If
                If Trim(ComboBox5.Text) <> Nothing Then
                    strSQL = strSQL & ", MKR_CODE = '" & ComboBox5.SelectedValue & "'"
                Else
                    strSQL = strSQL & ", MKR_CODE = NULL"
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
                strSQL = strSQL & " WHERE ID = " & pID & ""
                SqlUpdateCommand.CommandText = strSQL
                SqlUpdateCommand.CommandType = CommandType.Text
                SqlUpdateCommand.Connection = cnsqlclient

                'SqlInsertCommand.CommandText = "INSERT INTO ICDT_DTL(ID, RCV_DATE, RPLY, EMPL_CODE, RPLY_CLS, END_DATE, STATUS, ICDT_NO) " & _
                '                                "VALUES ('" & Label3_2.Text & "', '" & s_date & "', '" & TextBox2.Text & "', '" & pEmpl_code & "', '" & ComboBox3_4.SelectedValue & "', '" & Now() & "', '" & ComboBox3_3.SelectedValue & "', '-')"
                SqlInsertCommand.CommandText = "INSERT INTO ICDT_DTL(ID, RCV_DATE, RPLY, EMPL_CODE, RPLY_CLS, END_DATE, STATUS) " & _
                                                "VALUES (" & Label3_2.Text & ", '" & s_date & "', '" & TextBox2.Text & "', '" & pEmpl_code & "', '" & ComboBox3_4.SelectedValue & "', '" & Now() & "', '" & ComboBox3_3.SelectedValue & "')"
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

                Label3_2.Text = Count_Get_007()
                pID = Label3_2.Text

                'strSQL = "INSERT INTO ICDT_DATA (ID, WRN_NO, CLM_FLG, FIN_FLAG, CUST_CLS, ICDT_CLS, ASKING, STATUS, SEX, AGE_CLS, AREA_CLS, CAT_CODE, MKR_CODE, SHOP_CODE, YEAR_CLS, MONTHS_CLS, CALL1_CLS, CALL2_CLS, RPLY_CLS1, RPLY_CLS2, EMPL_CODE, ICDT_NO)"
                strSQL = "INSERT INTO ICDT_DATA (ID, WRN_NO, CLM_FLG, FIN_FLAG, fin_DATE, CUST_CLS, ICDT_CLS, ASKING, STATUS, SEX, AGE_CLS, AREA_CLS, CAT_CODE, MKR_CODE, SHOP_CODE, YEAR_CLS, MONTHS_CLS, CALL1_CLS, CALL2_CLS, RPLY_CLS1, RPLY_CLS2, EMPL_CODE)"
                strSQL = strSQL & " VALUES (" & pID & ""
                strSQL = strSQL & ", '" & pWrn_no & "'"
                strSQL = strSQL & ", '" & clm_flg & "'"
                strSQL = strSQL & ", '" & fin_flg & "'"
                If fin_flg = "0" Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
                End If
                strSQL = strSQL & ", '" & ComboBox1.SelectedValue & "'"
                strSQL = strSQL & ", '" & ComboBox3_2.SelectedValue & "'"
                strSQL = strSQL & ", '" & TextBox1.Text & "'"
                strSQL = strSQL & ", '" & ComboBox3_3.SelectedValue & "'"
                If RadioButton9.Checked = True Then
                    strSQL = strSQL & ", '1'"
                Else
                    strSQL = strSQL & ", '2'"
                End If
                If Trim(ComboBox2.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox2.SelectedValue & "'"
                End If
                If Trim(ComboBox3.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox3.SelectedValue & "'"
                End If
                If Trim(ComboBox4.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox4.SelectedValue & "'"
                End If
                If Trim(ComboBox5.Text) = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & ComboBox5.SelectedValue & "'"
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
                strSQL = strSQL & ", '" & pEmpl_code & "')"
                'strSQL = strSQL & ", '" & pEmpl_code & "'"
                'strSQL = strSQL & ", '-')"
                SqlInsertCommand.CommandText = strSQL
                SqlInsertCommand.CommandType = CommandType.Text
                SqlInsertCommand.Connection = cnsqlclient

                Dim SqlInsertCommand2 As New SqlClient.SqlCommand
                'SqlInsertCommand2.CommandText = "INSERT INTO ICDT_DTL(ID, RCV_DATE, RPLY, EMPL_CODE, RPLY_CLS, END_DATE, STATUS, ICDT_NO)  " & _
                '                                "VALUES ('" & pID & "', '" & s_date & "', '" & TextBox2.Text & "', '" & pEmpl_code & "', '" & ComboBox3_4.SelectedValue & "', '" & Now() & "', '" & ComboBox3_3.SelectedValue & "', '-')"
                SqlInsertCommand2.CommandText = "INSERT INTO ICDT_DTL(ID, RCV_DATE, RPLY, EMPL_CODE, RPLY_CLS, END_DATE, STATUS)  " & _
                                                "VALUES (" & pID & ", '" & s_date & "', '" & TextBox2.Text & "', '" & pEmpl_code & "', '" & ComboBox3_4.SelectedValue & "', '" & Now() & "', '" & ComboBox3_3.SelectedValue & "')"
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
                MsgBox("受付番号:" & pID & "で登録しました。", MsgBoxStyle.OKOnly, "Warranty System")
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

        '内容
        If LenB(TextBox1.Text) > 500 Then
            MessageBox.Show("問合せ内容が500バイトを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Err_F = "1" : Exit Sub
        ElseIf LenB(TextBox2.Text) > 500 Then
            MessageBox.Show("回答内容が500バイトを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Err_F = "1" : Exit Sub
        End If


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

        '年齢層
        If Trim(ComboBox2.Text) = Nothing Then
            'MsgBox("年齢層を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox2.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("AGE_CLS"), "NAME='" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する年齢層がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox2.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox2.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '地域
        If Trim(ComboBox3.Text) = Nothing Then
            'MsgBox("地域を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox3.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("AREA_CLS"), "NAME='" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する地域がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox3.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox3.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '商品ｶﾃｺﾞﾘｰ
        If Trim(ComboBox4.Text) = Nothing Then
            'MsgBox("商品ｶﾃｺﾞﾘｰを入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox4.Focus()
            'Err_F = "1" : Exit Sub
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
        If Trim(ComboBox5.Text) = Nothing Then
            'MsgBox("メーカーを入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox5.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_maker2"), "MKR_NAME='" & ComboBox5.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当するメーカーがありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox5.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox5.SelectedValue = DtView1(0)("MKR_CODE")
            End If
        End If

        '購入店舗
        If Trim(ComboBox6.Text) = Nothing Then
            'MsgBox("購入店舗を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox6.Focus()
            'Err_F = "1" : Exit Sub
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
            'MsgBox("購入後　年を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox7.Focus()
            'Err_F = "1" : Exit Sub
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
            'MsgBox("購入後　月を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox8.Focus()
            'Err_F = "1" : Exit Sub
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

        'コール内容
        If Trim(ComboBox9.Text) = Nothing Then
            If Trim(ComboBox10.Text) = Nothing Then
                MsgBox("コール内容を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox9.Focus()
                Err_F = "1" : Exit Sub
            Else
                '意見・要望系
                If Trim(ComboBox10.Text) = Nothing Then
                    'MsgBox("意見・要望系を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                    'ComboBox10.Focus()
                    'Err_F = "1" : Exit Sub
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
                    'MsgBox("不具合系を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                    'ComboBox9.Focus()
                    'Err_F = "1" : Exit Sub
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
    End Sub

    '*************************************************
    '** 変更の処理
    '*************************************************

    '入力後
    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            RadioButton1.Visible = True
            RadioButton2.Visible = True
            Label104.Visible = True
            Date4.Visible = True
            Date4.Focus()
        Else
            RadioButton1.Visible = False
            RadioButton2.Visible = False
            Label104.Visible = False
            Date4.Visible = False
        End If
    End Sub

    Private Sub ComboBox17_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox17.Leave
        If RTrim(ComboBox17.Text) = Nothing Then
            Label119.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_maker"), "MKR_NAME='" & ComboBox17.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label119.Text = Nothing
            Else
                Label119.Text = DtView1(0)("MKR_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox18_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox18.Leave
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

    Private Sub ComboBox19_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox19.Leave
        If RTrim(ComboBox19.Text) = Nothing Then
            Label121.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_item"), "MODEL='" & ComboBox19.Text & "'", "", DataViewRowState.CurrentRows)
            Select Case DtView1.Count
                Case Is = 0
                    Label121.Text = Nothing
                Case Is = 1
                    Label121.Text = DtView1(0)("ITEM_CODE")
                Case Else
                    For i = 0 To DtView1.Count - 1
                        If Label70.Text = DtView1(i)("ITEM_CODE") Then
                            Label121.Text = DtView1(i)("ITEM_CODE")
                            Exit Sub
                        End If
                    Next i
                    Label121.Text = DtView1(0)("ITEM_CODE")
            End Select
        End If
    End Sub

    '全商品
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor.Current = Cursors.WaitCursor

        P_DsCMB.Tables("M_item").Clear()
        strSQL = "SELECT ITEM_CODE, RTRIM(MODEL) AS MODEL"
        strSQL = strSQL & " FROM M_item"
        strSQL = strSQL & " ORDER BY RTRIM(MODEL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsCMB, "M_item")

        ComboBox19.SelectedValue = Label60.Text
        Button5.Enabled = False
        Me.Cursor.Current = Cursors.Default
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
                Label50.Text = RTrim(TextBox4_4.Text)
                If RadioButton5.Checked = True Then TextBox6.Text = RTrim(TextBox4_4.Text)
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
                Label1_1.Text = RTrim(TextBox4_1.Text)
                Label3_4.Text = RTrim(TextBox4_1.Text)
                If RadioButton5.Checked = True Then TextBox7.Text = RTrim(TextBox4_1.Text)
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
                Label1_2_0.Text = RTrim(Edit1.Text)
                If RadioButton5.Checked = True Then Edit4.Text = RTrim(Edit1.Text)
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
                Label1_2_1.Text = RTrim(TextBox4_2.Text)
                If RadioButton5.Checked = True Then TextBox8.Text = RTrim(TextBox4_2.Text)
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
                Label1_2_2.Text = RTrim(TextBox4_3.Text)
                If RadioButton5.Checked = True Then TextBox9.Text = RTrim(TextBox4_3.Text)
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
                Label1_3.Text = RTrim(Edit2.Text)
                If RadioButton5.Checked = True Then Edit5.Text = RTrim(Edit2.Text)
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
                Label1_4.Text = RTrim(Edit3.Text)
                If RadioButton5.Checked = True Then Edit6.Text = RTrim(Edit3.Text)
                upd_flg = "1"
            End If

            'メーカー
            If ComboBox17.SelectedValue <> RTrim(Label68.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET MKR_CODE = '" & ComboBox17.SelectedValue & "'"
                strSQL = strSQL & ", MKR_NAME = '" & ComboBox17.Text & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & ComboBox17.Text & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '011'"
                strSQL = strSQL & ", '" & RTrim(Label1_9.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label68.Text = ComboBox17.SelectedValue
                Label58.Text = ComboBox17.SelectedValue
                Label1_9.Text = ComboBox17.Text
                Label101.Text = ComboBox17.Text
                upd_flg = "1"
            End If

            '部門
            If ComboBox18.SelectedValue <> RTrim(Label69.Text) Then
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
                strSQL = strSQL & ", '" & RTrim(Label1_10.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label69.Text = ComboBox18.SelectedValue
                Label59.Text = ComboBox18.SelectedValue
                Label1_10.Text = ComboBox18.Text
                upd_flg = "1"
            End If

            '商品
            If ComboBox19.SelectedValue <> RTrim(Label70.Text) Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET ITEM_CODE = '" & ComboBox19.SelectedValue & "'"
                strSQL = strSQL & ", MODEL = '" & ComboBox19.Text & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & ComboBox19.Text & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '013'"
                strSQL = strSQL & ", '" & RTrim(Label1_18.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox4_6.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label70.Text = ComboBox19.SelectedValue
                Label60.Text = ComboBox19.SelectedValue
                Label1_18.Text = ComboBox19.Text
                Label98.Text = ComboBox19.Text
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
        'If RTrim(TextBox4_4.Text) = Nothing Then
        '    MsgBox("氏名（カナ）は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
        '    TextBox4_4.Focus()
        '    Err_F = "1" : Exit Sub
        'End If

        '氏名（漢字）
        If RTrim(TextBox4_1.Text) = Nothing Then
            MsgBox("氏名（漢字）は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            TextBox4_1.Focus()
            Err_F = "1" : Exit Sub
        End If

        'メーカー
        If RTrim(ComboBox17.Text) = Nothing Then
            MsgBox("メーカーは入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox17.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_maker2"), "MKR_NAME='" & ComboBox17.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当するメーカーがありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox17.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox17.SelectedValue = DtView1(0)("MKR_CODE")
            End If
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

        '商品
        If RTrim(ComboBox19.Text) = Nothing Then
            MsgBox("商品入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox19.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_item"), "MODEL='" & ComboBox19.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する商品がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox19.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox19.SelectedValue = DtView1(0)("ITEM_CODE")
            End If
        End If

    End Sub

    '*************************************************
    '** 修理情報の処理
    '*************************************************

    '入力後
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Label90.Visible = True
        Date1.Visible = True
        Label91.Visible = False
        Date2.Visible = False
        ComboBox13.Visible = True
        ComboBox14.Visible = False
        ComboBox15.Visible = False
        If Label129.Text = Nothing Then ComboBox13.Text = Nothing : ComboBox13.Text = Nothing
        If Label130.Text = Nothing Then ComboBox14.Text = Nothing : ComboBox14.Text = Nothing
        If Label144.Text = Nothing Then ComboBox15.Text = Nothing : ComboBox15.Text = Nothing
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Label90.Visible = True
        Date1.Visible = True
        Label91.Visible = True
        Date2.Visible = True
        ComboBox13.Visible = False
        ComboBox14.Visible = True
        ComboBox15.Visible = True
        If Label129.Text = Nothing Then ComboBox13.Text = Nothing : ComboBox13.Text = Nothing
        If Label130.Text = Nothing Then ComboBox14.Text = Nothing : ComboBox14.Text = Nothing
        If Label144.Text = Nothing Then ComboBox15.Text = Nothing : ComboBox15.Text = Nothing
    End Sub

    Private Sub RadioButton10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton10.CheckedChanged
        Label90.Visible = False
        Date1.Visible = False
        Label91.Visible = False
        Date2.Visible = False
        ComboBox13.Visible = False
        ComboBox14.Visible = False
        ComboBox15.Visible = False
        If Label129.Text = Nothing Then ComboBox13.Text = Nothing : ComboBox13.Text = Nothing
        If Label130.Text = Nothing Then ComboBox14.Text = Nothing : ComboBox14.Text = Nothing
        If Label144.Text = Nothing Then ComboBox15.Text = Nothing : ComboBox15.Text = Nothing
    End Sub

    Private Sub ComboBox13_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox13.Leave
        If RTrim(ComboBox13.Text) = Nothing Then
            Label129.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("HOPE_TIME_H1"), "NAME='" & ComboBox13.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label129.Text = Nothing
            Else
                Label129.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox14_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox14.Leave
        If RTrim(ComboBox14.Text) = Nothing Then
            Label130.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("HOPE_TIME_S1"), "NAME='" & ComboBox14.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label130.Text = Nothing
            Else
                Label130.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox15_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox15.Leave
        If RTrim(ComboBox15.Text) = Nothing Then
            Label144.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("HOPE_TIME_S2"), "NAME='" & ComboBox15.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label144.Text = Nothing
            Else
                Label144.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    Private Sub ComboBox16_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox16.Leave
        If RTrim(ComboBox16.Text) = Nothing Then
            Label128.Text = Nothing
        Else
            DtView1 = New DataView(P_DsCMB.Tables("LOCATION"), "NAME='" & ComboBox16.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label128.Text = Nothing
            Else
                Label128.Text = DtView1(0)("CLS_CODE")
            End If
        End If
    End Sub

    '進行状況
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Cursor.Current = Cursors.WaitCursor
        pREPAIR_CODE = Label95.Text
        Dim frmform7 As New Form7
        frmform7.ShowDialog()
        Me.Cursor.Current = Cursors.Default
    End Sub

    '登録・追加
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Cursor.Current = Cursors.WaitCursor
        Now_date = Now
        LEAVE_CHG = "0"

        Call F_Check_5()
        Select Case Err_F
            Case Is = "0"   'ｴﾗｰなし
                If Button8.Text = "登録" Then
                    If RadioButton3.Checked = True Then '引取
                        Label95.Text = Count_Get2("0")
                        Label148.Text = "2600" & Label95.Text & CD("2600" & Label95.Text)
                    Else                                '出張
                        Label95.Text = Count_Get2("9")
                        Label148.Text = "2600" & Label95.Text & CD("2600" & Label95.Text)
                    End If
                    If Label95.Text = Nothing Then GoTo proc_end
                Else            '追加
                    If RadioButton3.Checked = True Then '引取
                        If Mid(Label95.Text, 2, 1) <> "0" Then
                            Label95.Text = Count_Get2("0")
                            Label148.Text = "2600" & Label95.Text & CD("2600" & Label95.Text)
                            LEAVE_CHG = "1"
                        End If
                    Else                                '出張
                        If Mid(Label95.Text, 2, 1) <> "9" Then
                            Label95.Text = Count_Get2("9")
                            Label148.Text = "2600" & Label95.Text & CD("2600" & Label95.Text)
                            LEAVE_CHG = "1"
                        End If
                    End If
                End If

                If RadioButton6.Checked = True Then '顧客情報変更あり
                    Call wrn_data_upd()
                    RadioButton5.Checked = True
                End If

                If LEAVE_CHG = "1" Then             '再採番
                    'REPAIR_DATA
                    strSQL = "UPDATE REPAIR_DATA"
                    strSQL = strSQL & " SET REPAIR_CODE = '" & Label95.Text & "'"
                    strSQL = strSQL & ", REPAIR_CODE_BCD = '" & Label148.Text & "'"
                    strSQL = strSQL & " WHERE (REPAIR_CODE = '" & Label103.Text & "')"
                    DB_OPEN()
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    'REPAIR_FIN
                    strSQL = "UPDATE REPAIR_FIN"
                    strSQL = strSQL & " SET REPAIR_CODE = '" & Label95.Text & "'"
                    strSQL = strSQL & " WHERE (REPAIR_CODE = '" & Label103.Text & "')"
                    DB_OPEN()
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                End If

                'REPAIR_DATA
                strSQL = "INSERT INTO REPAIR_DATA"
                strSQL = strSQL & " (REPAIR_CODE, REPAIR_CODE_FST, REPAIR_CODE_BCD, WRN_NO, SYMPTOM, DEMAND, CUSTODY"
                strSQL = strSQL & ", LEAVE, CUST_CHG, CUST_NAME_KANA, CUST_NAME, ZIP1, ZIP2, ADRS1"
                strSQL = strSQL & ", ADRS2, TEL_NO, CNT_NO, CALL_TIME, HOPE_DATE1, HOPE_TIME1, HOPE_DATE2, HOPE_TIME2"
                strSQL = strSQL & ", REPAIR_DATE, LOCATION, BOX, EMPL_CODE, PROC_DATE, LOG_DATA)"
                strSQL = strSQL & " VALUES ('" & Label95.Text & "'"
                strSQL = strSQL & ", '" & Label95.Text & "'"
                strSQL = strSQL & ", '" & Label148.Text & "'"
                strSQL = strSQL & ", '" & pWrn_no & "'"
                strSQL = strSQL & ", '" & TextBox3.Text & "'"
                strSQL = strSQL & ", '" & TextBox4.Text & "'"
                strSQL = strSQL & ", '" & TextBox5.Text & "'"
                If RadioButton3.Checked = True Then strSQL = strSQL & ", '1'"
                If RadioButton4.Checked = True Then strSQL = strSQL & ", '2'"
                If RadioButton10.Checked = True Then strSQL = strSQL & ", '3'"
                If RadioButton5.Checked = True Then strSQL = strSQL & ", '1'"
                If RadioButton6.Checked = True Then strSQL = strSQL & ", '2'"
                If RadioButton7.Checked = True Then strSQL = strSQL & ", '3'"
                If RadioButton5.Checked = True Then '顧客情報変更なし
                    TextBox6.Text = RTrim(Label50.Text)
                    TextBox7.Text = RTrim(Label1_1.Text)
                    Edit4.Text = Label1_2_0.Text
                    TextBox8.Text = RTrim(Label1_2_1.Text)
                    TextBox9.Text = RTrim(Label1_2_2.Text)
                    Edit5.Text = RTrim(Label1_3.Text)
                    Edit6.Text = RTrim(Label1_4.Text)
                End If
                strSQL = strSQL & ", '" & RTrim(TextBox6.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox7.Text) & "'"
                strSQL = strSQL & ", '" & Mid(Edit4.Text, 1, 3) & "'"
                strSQL = strSQL & ", '" & Mid(Edit4.Text, 4, 4) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox8.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox9.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(Edit5.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(Edit6.Text) & "'"
                strSQL = strSQL & ", '" & RTrim(TextBox11.Text) & "'"

                If RadioButton3.Checked = True Then
                    If Date1.Number <> 0 Then
                        strSQL = strSQL & ", CONVERT(DATETIME, '" & Date1.Text & "', 102)"
                    Else
                        strSQL = strSQL & ", NULL"
                    End If
                    If RTrim(ComboBox13.Text) <> Nothing Then
                        strSQL = strSQL & ", '" & ComboBox13.SelectedValue & "'"
                    Else
                        strSQL = strSQL & ", NULL"
                    End If
                    strSQL = strSQL & ", NULL, NULL"
                End If
                If RadioButton4.Checked = True Then
                    If Date1.Number <> 0 Then
                        strSQL = strSQL & ", CONVERT(DATETIME, '" & Date1.Text & "', 102)"
                    Else
                        strSQL = strSQL & ", NULL"
                    End If
                    If RTrim(ComboBox14.Text) <> Nothing Then
                        strSQL = strSQL & ", '" & ComboBox14.SelectedValue & "'"
                    Else
                        strSQL = strSQL & ", NULL"
                    End If
                    If Date2.Number <> 0 Then
                        strSQL = strSQL & ", CONVERT(DATETIME, '" & Date2.Text & "', 102)"
                    Else
                        strSQL = strSQL & ", NULL"
                    End If
                    If RTrim(ComboBox15.Text) <> Nothing Then
                        strSQL = strSQL & ", '" & ComboBox15.SelectedValue & "'"
                    Else
                        strSQL = strSQL & ", NULL"
                    End If
                End If
                If RadioButton10.Checked = True Then
                    strSQL = strSQL & ", NULL, NULL, NULL, NULL"
                End If

                strSQL = strSQL & ", CONVERT(DATETIME, '" & Date3.Text & "', 102)"
                strSQL = strSQL & ", '" & ComboBox16.SelectedValue & "'"
                If RadioButton3.Checked = True Then '引取
                    strSQL = strSQL & ", '1'"
                Else
                    strSQL = strSQL & ", '0'"
                End If
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                strSQL = strSQL & ", '" & TextBox10.Text & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                If Button8.Text = "登録" Then

                    'REPAIR_FIN
                    strSQL = "INSERT INTO REPAIR_FIN"
                    strSQL = strSQL & " (REPAIR_CODE, PROC_DATE, WRN_NO, FIN_FLAG)"
                    strSQL = strSQL & " VALUES ('" & Label95.Text & "'"
                    strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
                    strSQL = strSQL & ", '" & pWrn_no & "'"
                    If ComboBox16.SelectedValue >= "900" Then
                        strSQL = strSQL & ", '1')"
                    Else
                        strSQL = strSQL & ", '0')"
                    End If
                    DB_OPEN()
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    MsgBox("受付番号:" & Label95.Text & "で登録しました。", MsgBoxStyle.OKOnly, "Warranty System")
                    Button10.Visible = True

                Else                            '追加

                    'REPAIR_FIN
                    strSQL = "UPDATE REPAIR_FIN"
                    strSQL = strSQL & " SET PROC_DATE = CONVERT(DATETIME, '" & Now_date & "', 102)"
                    If ComboBox16.SelectedValue >= "900" Then
                        strSQL = strSQL & ", FIN_FLAG = '1'"
                    Else
                        strSQL = strSQL & ", FIN_FLAG = '0'"
                    End If
                    strSQL = strSQL & " WHERE (REPAIR_CODE = '" & Label95.Text & "')"
                    DB_OPEN()
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    If LEAVE_CHG = "1" Then             '再採番
                        MsgBox("受付番号:" & Label95.Text & "で追加しました。", MsgBoxStyle.OKOnly, "Warranty System")
                    Else
                        MsgBox("追加しました。", MsgBoxStyle.OKOnly, "Warranty System")
                    End If

                End If

                If ComboBox16.SelectedValue >= "900" Then
                    Label102.Text = Format(Now_date, "yyyy/MM/dd")
                    Call fin()
                End If

                Call dsp_tag6()
                Button8.Enabled = False
            Case Is = "1"   'ｴﾗｰ
                GoTo proc_end
            Case Is = "2"   '変更なし　印刷のみ

        End Select


        '修理依頼票印刷
        If RadioButton3.Checked = True Then '引取
            P_DsPRT.Clear()
            strSQL = "SELECT REPAIR_DATA.LEAVE"
            strSQL = strSQL & ", REPAIR_DATA.REPAIR_CODE_BCD AS REPAIR_CODE_BCD"
            strSQL = strSQL & ", REPAIR_DATA.REPAIR_CODE, REPAIR_DATA.REPAIR_DATE"
            strSQL = strSQL & ", SUBSTRING(REPAIR_DATA.WRN_NO, 1, 4) + '  ' + SUBSTRING(REPAIR_DATA.WRN_NO, 5, 4) + '  ' + SUBSTRING(REPAIR_DATA.WRN_NO, 9, 4) + '  ' + SUBSTRING(REPAIR_DATA.WRN_NO, 13, 4) + '  ' + SUBSTRING(REPAIR_DATA.WRN_NO, 17, 4) AS WRN_NO"
            strSQL = strSQL & ", REPAIR_DATA.CUST_NAME_KANA, REPAIR_DATA.CUST_NAME"
            strSQL = strSQL & ", REPAIR_DATA.TEL_NO, REPAIR_DATA.CNT_NO, REPAIR_DATA.CALL_TIME"
            strSQL = strSQL & ", REPAIR_DATA.ZIP1 + '-' + REPAIR_DATA.ZIP2 AS ZIP, REPAIR_DATA.ADRS1"
            strSQL = strSQL & ", REPAIR_DATA.ADRS2, REPAIR_DATA.HOPE_DATE1, xa.TIME1"
            strSQL = strSQL & ", NULL AS HOPE_DATE2, NULL AS TIME2"
            strSQL = strSQL & ", '" & Label1_9.Text & "' AS MKR_NAME"
            strSQL = strSQL & ", '" & Label1_10.Text & "' AS CAT_NAME"
            strSQL = strSQL & ", '" & Label1_18.Text & "' AS MODEL"
            strSQL = strSQL & ", '" & Label1_7.Text & "' AS WRN_DATE"
            strSQL = strSQL & ", '" & Label1_12.Text & "' AS PRICE"
            strSQL = strSQL & ", '" & Label1_14.Text & "' AS WRN_PERIOD"
            strSQL = strSQL & ", '" & Label1_16.Text & "' AS MAX_PRICE"
            strSQL = strSQL & ", '" & Label1_11.Text & "' AS SHOP"
            strSQL = strSQL & ", REPAIR_DATA.SYMPTOM, REPAIR_DATA.CUSTODY"
            strSQL = strSQL & ", REPAIR_DATA.DEMAND, REPAIR_DATA.BOX, EMPL.EMPL_NAME"
            strSQL = strSQL & " FROM REPAIR_DATA INNER JOIN"
            strSQL = strSQL & " REPAIR_FIN ON REPAIR_DATA.REPAIR_CODE = REPAIR_FIN.REPAIR_CODE AND"
            strSQL = strSQL & " REPAIR_DATA.PROC_DATE = REPAIR_FIN.PROC_DATE INNER JOIN"
            strSQL = strSQL & " EMPL ON REPAIR_DATA.EMPL_CODE = EMPL.EMPL_CODE LEFT OUTER JOIN"
            strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME1 FROM CLS_CODE WHERE (CLS_NO = '022')) xa ON"
            strSQL = strSQL & " REPAIR_DATA.HOPE_TIME1 = xa.CLS_CODE COLLATE Japanese_CI_AS"
            strSQL = strSQL & " WHERE (REPAIR_DATA.REPAIR_CODE = '" & Label95.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(P_DsPRT, "Print1")
            DB_CLOSE()
            P_DtView1 = New DataView(P_DsPRT.Tables("Print1"), "", "", DataViewRowState.CurrentRows)
        Else                                '出張
            P_DsPRT.Clear()
            strSQL = "SELECT REPAIR_DATA.LEAVE"
            strSQL = strSQL & ", REPAIR_DATA.REPAIR_CODE_BCD AS REPAIR_CODE_BCD"
            strSQL = strSQL & ", REPAIR_DATA.REPAIR_CODE, REPAIR_DATA.REPAIR_DATE"
            strSQL = strSQL & ", SUBSTRING(REPAIR_DATA.WRN_NO, 1, 4) + '  ' + SUBSTRING(REPAIR_DATA.WRN_NO, 5, 4) + '  ' + SUBSTRING(REPAIR_DATA.WRN_NO, 9, 4) + '  ' + SUBSTRING(REPAIR_DATA.WRN_NO, 13, 4) + '  ' + SUBSTRING(REPAIR_DATA.WRN_NO, 17, 4) AS WRN_NO"
            strSQL = strSQL & ", REPAIR_DATA.CUST_NAME_KANA, REPAIR_DATA.CUST_NAME"
            strSQL = strSQL & ", REPAIR_DATA.TEL_NO, REPAIR_DATA.CNT_NO, REPAIR_DATA.CALL_TIME"
            strSQL = strSQL & ", REPAIR_DATA.ZIP1 + '-' + REPAIR_DATA.ZIP2 AS ZIP, REPAIR_DATA.ADRS1"
            strSQL = strSQL & ", REPAIR_DATA.ADRS2, REPAIR_DATA.HOPE_DATE1, xa.TIME1"
            strSQL = strSQL & ", REPAIR_DATA.HOPE_DATE2, xb.TIME2"
            strSQL = strSQL & ", '" & Label1_9.Text & "' AS MKR_NAME"
            strSQL = strSQL & ", '" & Label1_10.Text & "' AS CAT_NAME"
            strSQL = strSQL & ", '" & Label1_18.Text & "' AS MODEL"
            strSQL = strSQL & ", '" & Label1_7.Text & "' AS WRN_DATE"
            strSQL = strSQL & ", '" & Label1_12.Text & "' AS PRICE"
            strSQL = strSQL & ", '" & Label1_14.Text & "' AS WRN_PERIOD"
            strSQL = strSQL & ", '" & Label1_16.Text & "' AS MAX_PRICE"
            strSQL = strSQL & ", '" & Label1_11.Text & "' AS SHOP"
            strSQL = strSQL & ", REPAIR_DATA.SYMPTOM, REPAIR_DATA.CUSTODY"
            strSQL = strSQL & ", REPAIR_DATA.DEMAND, REPAIR_DATA.BOX, EMPL.EMPL_NAME"
            strSQL = strSQL & " FROM REPAIR_DATA INNER JOIN"
            strSQL = strSQL & " REPAIR_FIN ON REPAIR_DATA.REPAIR_CODE = REPAIR_FIN.REPAIR_CODE AND"
            strSQL = strSQL & " REPAIR_DATA.PROC_DATE = REPAIR_FIN.PROC_DATE INNER JOIN"
            strSQL = strSQL & " EMPL ON REPAIR_DATA.EMPL_CODE = EMPL.EMPL_CODE LEFT OUTER JOIN"
            strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME2 FROM CLS_CODE WHERE (CLS_NO = '023')) xb ON"
            strSQL = strSQL & " REPAIR_DATA.HOPE_TIME2 = xb.CLS_CODE COLLATE Japanese_CI_AS LEFT OUTER JOIN"
            strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME1 FROM CLS_CODE WHERE (CLS_NO = '023')) xa ON"
            strSQL = strSQL & " REPAIR_DATA.HOPE_TIME1 = xa.CLS_CODE COLLATE Japanese_CI_AS"
            strSQL = strSQL & " WHERE (REPAIR_DATA.REPAIR_CODE = '" & Label95.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(P_DsPRT, "Print1")
            DB_CLOSE()
            P_DtView1 = New DataView(P_DsPRT.Tables("Print1"), "", "", DataViewRowState.CurrentRows)
        End If

        Dim frmform1 As New Print1
        frmform1.ShowDialog()

proc_end:
        Me.Cursor.Current = Cursors.Default
    End Sub

    Sub F_Check_5()
        Err_F = "0"

        '症状
        If RTrim(TextBox3.Text) = Nothing Then
            MsgBox("症状は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            TextBox3.Focus()
            Err_F = "1" : Exit Sub
        Else
            If LenB(TextBox3.Text) > 100 Then
                MsgBox("症状が100バイトを超えています。", MsgBoxStyle.Exclamation, "Warranty System")
                TextBox3.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        'その他ご要望事項
        If RTrim(TextBox4.Text) = Nothing Then
            'MsgBox("その他ご要望事項は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            'TextBox4.Focus()
            'Err_F = "1" : Exit Sub
        Else
            If LenB(TextBox4.Text) > 100 Then
                MsgBox("その他ご要望事項が100バイトを超えています。", MsgBoxStyle.Exclamation, "Warranty System")
                TextBox4.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        'お預り品（付属品等）
        If RTrim(TextBox5.Text) = Nothing Then
            'MsgBox("お預り品（付属品等）は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            'TextBox5.Focus()
            'Err_F = "1" : Exit Sub
        Else
            If LenB(TextBox5.Text) > 100 Then
                MsgBox("お預り品（付属品等）が100バイトを超えています。", MsgBoxStyle.Exclamation, "Warranty System")
                TextBox5.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        ''修理対象
        'If RadioButton3.Checked = False And RadioButton4.Checked = False Then
        '    MsgBox("修理対象を選択してください。", MsgBoxStyle.Exclamation, "Warranty System")
        '    RadioButton3.Focus()
        '    Err_F = "1" : Exit Sub
        'End If

        '顧客情報
        If RadioButton6.Checked = True Or RadioButton7.Checked = True Then

            '氏名（漢字）
            If RTrim(TextBox7.Text) = Nothing Then
                MsgBox("氏名（漢字）は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
                TextBox7.Focus()
                Err_F = "1" : Exit Sub
            Else
                If LenB(TextBox7.Text) > 30 Then
                    MsgBox("氏名（漢字）が30バイトを超えています。", MsgBoxStyle.Exclamation, "Warranty System")
                    TextBox7.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '氏名（ｶﾅ）
            If RTrim(TextBox6.Text) = Nothing Then
                'MsgBox("氏名（ｶﾅ）は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
                'TextBox6.Focus()
                'Err_F = "1" : Exit Sub
            Else
                If LenB(TextBox6.Text) > 30 Then
                    MsgBox("氏名（ｶﾅ）が30バイトを超えています。", MsgBoxStyle.Exclamation, "Warranty System")
                    TextBox6.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '住所1
            If RTrim(TextBox8.Text) = Nothing Then
                MsgBox("住所は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
                TextBox8.Focus()
                Err_F = "1" : Exit Sub
            Else
                If LenB(TextBox8.Text) > 60 Then
                    MsgBox("住所が60バイトを超えています。", MsgBoxStyle.Exclamation, "Warranty System")
                    TextBox8.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

            '住所2
            If RTrim(TextBox9.Text) = Nothing Then
                'MsgBox("住所は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
                'TextBox9.Focus()
                'Err_F = "1" : Exit Sub
            Else
                If LenB(TextBox9.Text) > 60 Then
                    MsgBox("住所が60バイトを超えています。", MsgBoxStyle.Exclamation, "Warranty System")
                    TextBox9.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

        End If

        '第一希望日時
        If Date1.Number = 0 Then
            MsgBox("第一希望日時は入力必須です。", MsgBoxStyle.Exclamation, "Warranty System")
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If

        If RadioButton3.Checked = True Then
            If Trim(ComboBox13.Text) = Nothing Then
                MsgBox("第一希望時間帯を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox13.Focus()
                Err_F = "1" : Exit Sub
            Else
                DtView1 = New DataView(P_DsCMB.Tables("HOPE_TIME_H1"), "NAME='" & ComboBox13.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    MsgBox("該当する時間帯がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                    ComboBox13.Focus()
                    Err_F = "1" : Exit Sub
                Else
                    ComboBox13.SelectedValue = DtView1(0)("CLS_CODE")
                End If
            End If
        Else
            If Trim(ComboBox14.Text) = Nothing Then
                MsgBox("第一希望時間帯を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox14.Focus()
                Err_F = "1" : Exit Sub
            Else
                DtView1 = New DataView(P_DsCMB.Tables("HOPE_TIME_S1"), "NAME='" & ComboBox14.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    MsgBox("該当する時間帯がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                    ComboBox14.Focus()
                    Err_F = "1" : Exit Sub
                Else
                    ComboBox14.SelectedValue = DtView1(0)("CLS_CODE")
                End If
            End If
        End If

        '変更あり？
        If Label95.Text <> Nothing Then
            WK_DsList1.Clear()
            strSQL = "SELECT REPAIR_DATA.*, REPAIR_FIN.FIN_FLAG"
            strSQL = strSQL & " FROM REPAIR_DATA INNER JOIN REPAIR_FIN ON REPAIR_DATA.REPAIR_CODE = REPAIR_FIN.REPAIR_CODE AND REPAIR_DATA.PROC_DATE = REPAIR_FIN.PROC_DATE"
            strSQL = strSQL & " WHERE (REPAIR_DATA.REPAIR_CODE = '" & Label95.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(WK_DsList1, "REPAIR_DATA")
            DB_CLOSE()
            DtView1 = New DataView(WK_DsList1.Tables("REPAIR_DATA"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                If RTrim(TextBox3.Text) <> RTrim(DtView1(0)("SYMPTOM")) Then GoTo p1
                If RTrim(TextBox4.Text) <> RTrim(DtView1(0)("DEMAND")) Then GoTo p1
                If RTrim(TextBox5.Text) <> RTrim(DtView1(0)("CUSTODY")) Then GoTo p1

                If DtView1(0)("LEAVE") = "1" Then
                    If RadioButton3.Checked <> True Then GoTo p1
                    If ComboBox13.SelectedValue <> DtView1(0)("HOPE_TIME1") Then GoTo p1
                Else
                    If RadioButton4.Checked <> True Then GoTo p1
                    If ComboBox14.SelectedValue <> DtView1(0)("HOPE_TIME1") Then GoTo p1
                    If Not IsDBNull(DtView1(0)("HOPE_TIME2")) Then
                        If ComboBox15.SelectedValue <> DtView1(0)("HOPE_TIME2") Then GoTo p1
                    Else
                        If ComboBox15.Text <> Nothing Then GoTo p1
                    End If
                End If
                Select Case DtView1(0)("CUST_CHG")
                    Case Is = "1"
                        If RadioButton5.Checked <> True Then GoTo p1
                    Case Is = "2"
                        If RadioButton6.Checked <> True Then GoTo p1
                    Case Is = "3"
                        If RadioButton7.Checked <> True Then GoTo p1
                End Select
                If RTrim(TextBox6.Text) <> RTrim(DtView1(0)("CUST_NAME_KANA")) Then GoTo p1
                If RTrim(TextBox7.Text) <> RTrim(DtView1(0)("CUST_NAME")) Then GoTo p1
                If RTrim(Edit4.Text) <> DtView1(0)("ZIP1") & DtView1(0)("ZIP2") Then GoTo p1
                If RTrim(TextBox8.Text) <> RTrim(DtView1(0)("ADRS1")) Then GoTo p1
                If RTrim(TextBox9.Text) <> RTrim(DtView1(0)("ADRS2")) Then GoTo p1
                If RTrim(Edit5.Text) <> RTrim(DtView1(0)("TEL_NO")) Then GoTo p1
                If RTrim(Edit6.Text) <> RTrim(DtView1(0)("CNT_NO")) Then GoTo p1

                If Not IsDBNull(DtView1(0)("HOPE_DATE1")) Then
                    If Date1.Text <> Format(DtView1(0)("HOPE_DATE1"), "yyyy/MM/dd") Then GoTo p1
                Else
                    If Date1.Number <> 0 Then GoTo p1
                End If
                If Not IsDBNull(DtView1(0)("HOPE_DATE2")) Then
                    If Date2.Text <> Format(DtView1(0)("HOPE_DATE2"), "yyyy/MM/dd") Then GoTo p1
                Else
                    If Date2.Number <> 0 Then GoTo p1
                End If
                If Date3.Text <> DtView1(0)("REPAIR_DATE") Then GoTo p1
                If ComboBox16.SelectedValue <> DtView1(0)("LOCATION") Then GoTo p1

                'MsgBox("変更箇所がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                'TextBox3.Focus()
                Err_F = "2" : Exit Sub

            End If
        End If
p1:
    End Sub

    Sub wrn_data_upd()

        '氏名（カナ）
        If RTrim(TextBox6.Text) <> RTrim(Label61.Text) Then
            strSQL = "UPDATE WRN_DATA"
            strSQL = strSQL & " SET CUST_NAME_KANA = '" & RTrim(TextBox6.Text) & "'"
            strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "INSERT INTO WRN_DATA_UPD"
            strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM)"
            strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
            strSQL = strSQL & ", '" & RTrim(TextBox6.Text) & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
            strSQL = strSQL & ", '" & pEmpl_code & "'"
            strSQL = strSQL & ", '009'"
            strSQL = strSQL & ", '" & RTrim(Label61.Text) & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Label61.Text = RTrim(TextBox6.Text)
            Label50.Text = RTrim(TextBox6.Text)
            TextBox4_4.Text = RTrim(TextBox6.Text)
        End If

        '氏名（漢字）
        If RTrim(TextBox7.Text) <> RTrim(Label62.Text) Then
            strSQL = "UPDATE WRN_DATA"
            strSQL = strSQL & " SET CUST_NAME = '" & RTrim(TextBox7.Text) & "'"
            strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "INSERT INTO WRN_DATA_UPD"
            strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM)"
            strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
            strSQL = strSQL & ", '" & RTrim(TextBox7.Text) & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
            strSQL = strSQL & ", '" & pEmpl_code & "'"
            strSQL = strSQL & ", '001'"
            strSQL = strSQL & ", '" & RTrim(Label62.Text) & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Label62.Text = RTrim(TextBox7.Text)
            Label1_1.Text = RTrim(TextBox7.Text)
            Label3_4.Text = RTrim(TextBox7.Text)
            TextBox4_1.Text = RTrim(TextBox7.Text)
        End If

        '郵便番号
        If RTrim(Edit4.Text) <> RTrim(Label63.Text) Then
            strSQL = "UPDATE WRN_DATA"
            strSQL = strSQL & " SET ZIP1 = '" & Mid(Edit4.Text, 1, 3) & "'"
            strSQL = strSQL & ", ZIP2 = '" & Mid(Edit4.Text, 4, 4) & "'"
            strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "INSERT INTO WRN_DATA_UPD"
            strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM)"
            strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
            strSQL = strSQL & ", '" & RTrim(Edit4.Text) & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
            strSQL = strSQL & ", '" & pEmpl_code & "'"
            strSQL = strSQL & ", '006'"
            strSQL = strSQL & ", '" & RTrim(Label63.Text) & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Label63.Text = RTrim(Edit4.Text)
            Label1_2_0.Text = RTrim(Edit4.Text)
            Edit1.Text = RTrim(Edit4.Text)
        End If

        '住所1
        If RTrim(TextBox8.Text) <> RTrim(Label64.Text) Then
            strSQL = "UPDATE WRN_DATA"
            strSQL = strSQL & " SET ADRS1 = '" & RTrim(TextBox8.Text) & "'"
            strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "INSERT INTO WRN_DATA_UPD"
            strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM)"
            strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
            strSQL = strSQL & ", '" & RTrim(TextBox8.Text) & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
            strSQL = strSQL & ", '" & pEmpl_code & "'"
            strSQL = strSQL & ", '002'"
            strSQL = strSQL & ", '" & RTrim(Label64.Text) & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Label64.Text = RTrim(TextBox8.Text)
            Label1_2_1.Text = RTrim(TextBox8.Text)
            TextBox4_2.Text = RTrim(TextBox8.Text)
        End If

        '住所2
        If RTrim(TextBox9.Text) <> RTrim(Label65.Text) Then
            strSQL = "UPDATE WRN_DATA"
            strSQL = strSQL & " SET ADRS2 = '" & RTrim(TextBox9.Text) & "'"
            strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "INSERT INTO WRN_DATA_UPD"
            strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM)"
            strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
            strSQL = strSQL & ", '" & RTrim(TextBox9.Text) & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
            strSQL = strSQL & ", '" & pEmpl_code & "'"
            strSQL = strSQL & ", '003'"
            strSQL = strSQL & ", '" & RTrim(Label65.Text) & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Label65.Text = RTrim(TextBox9.Text)
            Label1_2_2.Text = RTrim(TextBox9.Text)
            TextBox4_3.Text = RTrim(TextBox9.Text)
        End If

        '電話番号
        If RTrim(Edit5.Text) <> RTrim(Label66.Text) Then
            strSQL = "UPDATE WRN_DATA"
            strSQL = strSQL & " SET TEL_NO = '" & RTrim(Edit5.Text) & "'"
            strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "INSERT INTO WRN_DATA_UPD"
            strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM)"
            strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
            strSQL = strSQL & ", '" & RTrim(Edit5.Text) & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
            strSQL = strSQL & ", '" & pEmpl_code & "'"
            strSQL = strSQL & ", '004'"
            strSQL = strSQL & ", '" & RTrim(Label66.Text) & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Label66.Text = RTrim(Edit5.Text)
            Label1_3.Text = RTrim(Edit5.Text)
            Edit2.Text = RTrim(Edit5.Text)
        End If

        '連絡先番号
        If RTrim(Edit6.Text) <> RTrim(Label67.Text) Then
            strSQL = "UPDATE WRN_DATA"
            strSQL = strSQL & " SET CNT_NO = '" & RTrim(Edit6.Text) & "'"
            strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "INSERT INTO WRN_DATA_UPD"
            strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM)"
            strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
            strSQL = strSQL & ", '" & RTrim(Edit6.Text) & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & Now_date & "', 102)"
            strSQL = strSQL & ", '" & pEmpl_code & "'"
            strSQL = strSQL & ", '010'"
            strSQL = strSQL & ", '" & RTrim(Label67.Text) & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Label67.Text = RTrim(Edit6.Text)
            Label1_4.Text = RTrim(Edit6.Text)
            Edit3.Text = RTrim(Edit6.Text)
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
        If Label119.Text = Nothing Then ComboBox17.Text = Nothing : ComboBox17.Text = Nothing
        If Label120.Text = Nothing Then ComboBox18.Text = Nothing : ComboBox18.Text = Nothing
        If Label121.Text = Nothing Then ComboBox19.Text = Nothing : ComboBox19.Text = Nothing

        If Label131.Text = Nothing Then ComboBox1.Text = Nothing : ComboBox1.Text = Nothing
        If Label132.Text = Nothing Then ComboBox2.Text = Nothing : ComboBox2.Text = Nothing
        If Label133.Text = Nothing Then ComboBox3.Text = Nothing : ComboBox3.Text = Nothing
        If Label134.Text = Nothing Then ComboBox4.Text = Nothing : ComboBox4.Text = Nothing
        If Label135.Text = Nothing Then ComboBox5.Text = Nothing : ComboBox5.Text = Nothing
        If Label136.Text = Nothing Then ComboBox6.Text = Nothing : ComboBox6.Text = Nothing
        If Label137.Text = Nothing Then ComboBox7.Text = Nothing : ComboBox7.Text = Nothing
        If Label138.Text = Nothing Then ComboBox8.Text = Nothing : ComboBox8.Text = Nothing
        If Label139.Text = Nothing Then ComboBox9.Text = Nothing : ComboBox9.Text = Nothing
        If Label140.Text = Nothing Then ComboBox10.Text = Nothing : ComboBox10.Text = Nothing
        If Label141.Text = Nothing Then ComboBox11.Text = Nothing : ComboBox11.Text = Nothing
        If Label142.Text = Nothing Then ComboBox12.Text = Nothing : ComboBox12.Text = Nothing

        If Label122.Text = Nothing Then ComboBox3_2.Text = Nothing : ComboBox3_2.Text = Nothing
        If Label123.Text = Nothing Then ComboBox3_3.Text = Nothing : ComboBox3_3.Text = Nothing
        If Label124.Text = Nothing Then ComboBox3_4.Text = Nothing : ComboBox3_4.Text = Nothing

        If Label129.Text = Nothing Then ComboBox13.Text = Nothing : ComboBox13.Text = Nothing
        If Label130.Text = Nothing Then ComboBox14.Text = Nothing : ComboBox14.Text = Nothing
        If Label144.Text = Nothing Then ComboBox15.Text = Nothing : ComboBox15.Text = Nothing
        If Label128.Text = Nothing Then ComboBox16.Text = Nothing : ComboBox16.Text = Nothing

    End Sub

    'Tab Enabled
    Sub Enabled_TAB3()  'LOG
        CheckBox1.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
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
        Button1.Visible = False
    End Sub

    Sub Enabled_TAB5()  '修理情報
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        RadioButton3.Enabled = False
        RadioButton4.Enabled = False
        RadioButton5.Enabled = False
        RadioButton6.Enabled = False
        RadioButton7.Enabled = False
        RadioButton10.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        Edit4.Enabled = False
        Edit4.BackColor = System.Drawing.SystemColors.Control
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        Edit5.Enabled = False
        Edit5.BackColor = System.Drawing.SystemColors.Control
        Edit6.Enabled = False
        Edit6.BackColor = System.Drawing.SystemColors.Control
        Date1.Enabled = False
        Date1.BackColor = System.Drawing.SystemColors.Control
        Date2.Enabled = False
        Date2.BackColor = System.Drawing.SystemColors.Control
        ComboBox13.Enabled = False
        ComboBox14.Enabled = False
        ComboBox15.Enabled = False
        Date3.Enabled = False
        Date3.BackColor = System.Drawing.SystemColors.Control
        ComboBox16.Enabled = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
        Button8.Visible = False
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox1.Text = TextBox1.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        TextBox2.Text = TextBox2.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        TextBox3.Text = TextBox3.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        TextBox4.Text = TextBox4.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        TextBox5.Text = TextBox5.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        TextBox6.Text = TextBox6.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        TextBox7.Text = TextBox7.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus
        TextBox8.Text = TextBox8.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.LostFocus
        TextBox9.Text = TextBox9.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.LostFocus
        TextBox10.Text = TextBox10.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox11.LostFocus
        TextBox11.Text = TextBox11.Text.Replace("'", "’")
    End Sub
    Private Sub TextBox4_6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4_6.LostFocus
        TextBox4_6.Text = TextBox4_6.Text.Replace("'", "’")
    End Sub
End Class
