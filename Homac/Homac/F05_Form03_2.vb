Imports GrapeCity.Win.Input.Interop

Public Class F05_Form03_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0
    'version issue 20200805. created Ime1 object
    'Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, WK_str As String
    Dim i, r As Integer
    Friend WithEvents Ime1 As Ime

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        ''version issue 20200805. Ime1 object is created
        'Me.Furigana = Me.Edit03.Ime
        Ime1.SetCausesImeEvent(Me.Edit03, True)
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
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label03 As System.Windows.Forms.Label
    Friend WithEvents Label04 As System.Windows.Forms.Label
    Friend WithEvents Label05 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F05_Form03_2))
        Me.Label001 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.CheckBox001 = New System.Windows.Forms.CheckBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.msg = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button98 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label01 = New System.Windows.Forms.Label()
        Me.Label02 = New System.Windows.Forms.Label()
        Me.Label03 = New System.Windows.Forms.Label()
        Me.Label04 = New System.Windows.Forms.Label()
        Me.Label05 = New System.Windows.Forms.Label()
        Me.Ime1 = New GrapeCity.Win.Input.Interop.Ime()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(688, 4)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1213
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(600, 4)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1212
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(136, 272)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 9
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(12, 272)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(124, 24)
        Me.Label52.TabIndex = 1211
        Me.Label52.Text = "削除フラグ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 304)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(784, 24)
        Me.msg.TabIndex = 1210
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 340)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 28)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(716, 340)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(76, 28)
        Me.Button98.TabIndex = 11
        Me.Button98.Text = "戻る"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 24)
        Me.Label7.TabIndex = 1209
        Me.Label7.Text = "ライン"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 24)
        Me.Label9.TabIndex = 1208
        Me.Label9.Text = "部門"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit05
        '
        Me.Edit05.HighlightText = True
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(136, 244)
        Me.Edit05.MaxLength = 30
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Size = New System.Drawing.Size(324, 24)
        Me.Edit05.TabIndex = 8
        Me.Edit05.Text = "Edit05"
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.HighlightText = True
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(136, 76)
        Me.Edit04.MaxLength = 60
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Size = New System.Drawing.Size(660, 24)
        Me.Edit04.TabIndex = 2
        Me.Edit04.Text = "1234567890123456789012345678901234567890"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit03
        '
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(136, 48)
        Me.Edit03.MaxLength = 60
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Size = New System.Drawing.Size(660, 24)
        Me.Edit03.TabIndex = 1
        Me.Edit03.Text = "12"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 244)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 24)
        Me.Label4.TabIndex = 1205
        Me.Label4.Text = "規格名（漢字）"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 24)
        Me.Label3.TabIndex = 1204
        Me.Label3.Text = "商品名（カナ）"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 24)
        Me.Label2.TabIndex = 1203
        Me.Label2.Text = "商品名（漢字）"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 24)
        Me.Label1.TabIndex = 1201
        Me.Label1.Text = "商品コード"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.HighlightText = True
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(136, 20)
        Me.Edit02.MaxLength = 14
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Size = New System.Drawing.Size(132, 24)
        Me.Edit02.TabIndex = 0
        Me.Edit02.Text = "1234"
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(136, 104)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox1.TabIndex = 3
        Me.ComboBox1.Text = "ComboBox1"
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(136, 132)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox2.TabIndex = 4
        Me.ComboBox2.Text = "ComboBox2"
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(136, 160)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox3.TabIndex = 5
        Me.ComboBox3.Text = "ComboBox3"
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(136, 188)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox4.TabIndex = 6
        Me.ComboBox4.Text = "ComboBox4"
        '
        'ComboBox5
        '
        Me.ComboBox5.Location = New System.Drawing.Point(136, 216)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox5.TabIndex = 7
        Me.ComboBox5.Text = "ComboBox5"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 24)
        Me.Label5.TabIndex = 1219
        Me.Label5.Text = "メーカー"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 24)
        Me.Label6.TabIndex = 1220
        Me.Label6.Text = "クラス"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 24)
        Me.Label8.TabIndex = 1221
        Me.Label8.Text = "サブクラス"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label01.Location = New System.Drawing.Point(460, 104)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(80, 24)
        Me.Label01.TabIndex = 1222
        Me.Label01.Text = "Label01"
        Me.Label01.Visible = False
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label02.Location = New System.Drawing.Point(460, 132)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(80, 24)
        Me.Label02.TabIndex = 1223
        Me.Label02.Text = "Label02"
        Me.Label02.Visible = False
        '
        'Label03
        '
        Me.Label03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label03.Location = New System.Drawing.Point(460, 160)
        Me.Label03.Name = "Label03"
        Me.Label03.Size = New System.Drawing.Size(80, 24)
        Me.Label03.TabIndex = 1224
        Me.Label03.Text = "Label03"
        Me.Label03.Visible = False
        '
        'Label04
        '
        Me.Label04.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label04.Location = New System.Drawing.Point(460, 188)
        Me.Label04.Name = "Label04"
        Me.Label04.Size = New System.Drawing.Size(80, 24)
        Me.Label04.TabIndex = 1225
        Me.Label04.Text = "Label04"
        Me.Label04.Visible = False
        '
        'Label05
        '
        Me.Label05.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label05.Location = New System.Drawing.Point(460, 216)
        Me.Label05.Name = "Label05"
        Me.Label05.Size = New System.Drawing.Size(80, 24)
        Me.Label05.TabIndex = 1226
        Me.Label05.Text = "Label05"
        Me.Label05.Visible = False
        '
        'Ime1
        '
        '
        'F05_Form03_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(806, 371)
        Me.Controls.Add(Me.Label05)
        Me.Controls.Add(Me.Label04)
        Me.Controls.Add(Me.Label03)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label01)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit02)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F05_Form03_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac 商品マスタメンテ"
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F05_Form03_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call dsp_set()  '** 画面セット
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        P_RTN = "0"
        msg.Text = Nothing
        DsList1.Clear()
    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN()

        'メーカー
        strSQL = "SELECT vdr_code, vdr_code + ':' + vdr_name AS vdr_name"
        strSQL = strSQL & " FROM vdr_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "vdr_mtr")

        ComboBox1.DataSource = DsCMB.Tables("vdr_mtr")
        ComboBox1.DisplayMember = "vdr_name"
        ComboBox1.ValueMember = "vdr_code"
        ComboBox1.Text = Nothing

        '部門
        strSQL = "SELECT section_code, section_code + ':' + section_name AS section_name"
        strSQL = strSQL & " FROM section_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "section_mtr")

        ComboBox2.DataSource = DsCMB.Tables("section_mtr")
        ComboBox2.DisplayMember = "section_name"
        ComboBox2.ValueMember = "section_code"
        ComboBox2.Text = Nothing

        'ライン
        strSQL = "SELECT section_code, line_code, line_code + ':' + line_name AS line_name"
        strSQL = strSQL & " FROM line_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "line_mtr")

        ComboBox3.DataSource = DsCMB.Tables("line_mtr")
        ComboBox3.DisplayMember = "line_name"
        ComboBox3.ValueMember = "line_code"
        ComboBox3.Text = Nothing

        'クラス
        strSQL = "SELECT section_code, line_code, cls_code, cls_code + ':' + cls_name AS cls_name"
        strSQL = strSQL & " FROM cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        strSQL = strSQL & " AND (line_code = '" & Label03.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "cls_mtr")

        ComboBox4.DataSource = DsCMB.Tables("cls_mtr")
        ComboBox4.DisplayMember = "cls_name"
        ComboBox4.ValueMember = "cls_code"
        ComboBox4.Text = Nothing

        'サブクラス
        strSQL = "SELECT section_code, line_code, cls_code, sub_cls_code, sub_cls_code + ':' + sub_cls_name AS sub_cls_name"
        strSQL = strSQL & " FROM sub_cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        strSQL = strSQL & " AND (line_code = '" & Label03.Text & "')"
        strSQL = strSQL & " AND (cls_code = '" & Label04.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "sub_cls_mtr")

        ComboBox5.DataSource = DsCMB.Tables("sub_cls_mtr")
        ComboBox5.DisplayMember = "sub_cls_name"
        ComboBox5.ValueMember = "sub_cls_code"
        ComboBox5.Text = Nothing

        DB_CLOSE()
    End Sub
    Sub CmbSet_3()          'ライン

        DsCMB.Tables("line_mtr").Clear()
        strSQL = "SELECT section_code, line_code, line_code + ':' + line_name AS line_name"
        strSQL = strSQL & " FROM line_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "line_mtr")
        DB_CLOSE()

    End Sub
    Sub CmbSet_4()          'クラス

        DsCMB.Tables("cls_mtr").Clear()
        strSQL = "SELECT section_code, line_code, cls_code, cls_code + ':' + cls_name AS cls_name"
        strSQL = strSQL & " FROM cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        strSQL = strSQL & " AND (line_code = '" & Label03.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "cls_mtr")
        DB_CLOSE()

    End Sub
    Sub CmbSet_5()          'サブクラス

        DsCMB.Tables("sub_cls_mtr").Clear()
        strSQL = "SELECT section_code, line_code, cls_code, sub_cls_code, sub_cls_code + ':' + sub_cls_name AS sub_cls_name"
        strSQL = strSQL & " FROM sub_cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        strSQL = strSQL & " AND (line_code = '" & Label03.Text & "')"
        strSQL = strSQL & " AND (cls_code = '" & Label04.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "sub_cls_mtr")
        DB_CLOSE()

    End Sub

    '******************************************************************
    '** 画面セット
    '******************************************************************
    Sub dsp_set()

        If P_PRAM1 = Nothing Then   '新規
            Edit02.Enabled = True

            Edit02.Text = Nothing
            Edit03.Text = Nothing
            Edit04.Text = Nothing
            Edit05.Text = Nothing
            Label001.Text = Nothing
            CheckBox001.Checked = False

        Else                        '修正
            Edit02.Enabled = False

            strSQL = "SELECT item_mtr.*, vdr_mtr.vdr_name, section_mtr.section_name, line_mtr.line_name, cls_mtr.cls_name, sub_cls_mtr.sub_cls_name"
            strSQL = strSQL & " FROM item_mtr INNER JOIN"
            strSQL = strSQL & " section_mtr ON item_mtr.section_code = section_mtr.section_code INNER JOIN"
            strSQL = strSQL & " line_mtr ON item_mtr.section_code = line_mtr.section_code AND"
            strSQL = strSQL & " item_mtr.line_code = line_mtr.line_code INNER JOIN"
            strSQL = strSQL & " cls_mtr ON item_mtr.section_code = cls_mtr.section_code AND item_mtr.line_code = cls_mtr.line_code AND"
            strSQL = strSQL & " item_mtr.cls_code = cls_mtr.cls_code LEFT OUTER JOIN"
            strSQL = strSQL & " sub_cls_mtr ON item_mtr.section_code = sub_cls_mtr.section_code AND"
            strSQL = strSQL & " item_mtr.line_code = sub_cls_mtr.line_code AND item_mtr.cls_code = sub_cls_mtr.cls_code AND"
            strSQL = strSQL & " item_mtr.sub_cls_code = sub_cls_mtr.sub_cls_code LEFT OUTER JOIN"
            strSQL = strSQL & " vdr_mtr ON item_mtr.vdr_code = vdr_mtr.vdr_code"
            strSQL = strSQL & " WHERE (item_mtr.item_code = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "item_mtr")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("item_mtr"), "", "", DataViewRowState.CurrentRows)
            Edit02.Text = DtView1(0)("item_code")
            Edit03.Text = DtView1(0)("item_name")
            If Not IsDBNull(DtView1(0)("item_name_kana")) Then Edit04.Text = DtView1(0)("item_name_kana") Else Edit04.Text = Nothing

            ComboBox1.Text = DtView1(0)("vdr_code")
            Label01.Text = DtView1(0)("vdr_code")
            If Not IsDBNull(DtView1(0)("vdr_name")) Then ComboBox1.Text = ComboBox1.Text & ":" & DtView1(0)("vdr_name")

            ComboBox2.Text = DtView1(0)("section_code")
            Label02.Text = DtView1(0)("section_code")
            If Not IsDBNull(DtView1(0)("section_name")) Then ComboBox2.Text = ComboBox2.Text & ":" & DtView1(0)("section_name")

            Label03.Text = DtView1(0)("line_code")
            Call CmbSet_3()     'ライン
            WK_DtView1 = New DataView(DsCMB.Tables("line_mtr"), "line_code = '" & Label03.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                ComboBox3.Text = WK_DtView1(0)("line_name")
            Else
                ComboBox3.Text = Nothing
            End If

            Label04.Text = DtView1(0)("cls_code")
            Call CmbSet_4()     'クラス
            WK_DtView1 = New DataView(DsCMB.Tables("cls_mtr"), "cls_code = '" & Label04.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                ComboBox4.Text = WK_DtView1(0)("cls_name")
            Else
                ComboBox4.Text = Nothing
            End If

            Label05.Text = DtView1(0)("sub_cls_code")
            Call CmbSet_5()     'サブクラス
            WK_DtView1 = New DataView(DsCMB.Tables("sub_cls_mtr"), "sub_cls_code = '" & Label05.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                ComboBox5.Text = WK_DtView1(0)("sub_cls_name")
            Else
                ComboBox5.Text = Nothing
            End If

            If Not IsDBNull(DtView1(0)("standard_name")) Then Edit05.Text = DtView1(0)("standard_name") Else Edit05.Text = Nothing
            Label001.Text = DtView1(0)("reg_date")
            If DtView1(0)("delt_flg") = "1" Then
                CheckBox001.Checked = True
            Else
                CheckBox001.Checked = False
            End If

        End If

    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        If P_PRAM1 = Nothing Then   '新規
            Call CHK_Edit02()       '商品コード
            If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub
        End If

        Call CHK_Edit03()           '商品名（漢字）
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        Call CHK_Edit04()           '商品名（カナ）
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        Call CHK_ComboBox1()        'メーカー
        If msg.Text <> Nothing Then Err_F = "1" : ComboBox1.Focus() : Exit Sub

        Call CHK_ComboBox2()        '部門
        If msg.Text <> Nothing Then Err_F = "1" : ComboBox2.Focus() : Exit Sub

        Call CHK_ComboBox3()        'ライン
        If msg.Text <> Nothing Then Err_F = "1" : ComboBox3.Focus() : Exit Sub

        Call CHK_ComboBox4()        'クラス
        If msg.Text <> Nothing Then Err_F = "1" : ComboBox4.Focus() : Exit Sub

        Call CHK_ComboBox5()        'サブクラス
        If msg.Text <> Nothing Then Err_F = "1" : ComboBox5.Focus() : Exit Sub

        Call CHK_Edit05()           '規格名
        If msg.Text <> Nothing Then Err_F = "1" : Edit05.Focus() : Exit Sub

        Call CHK_CheckBox001()      '削除フラグ
        If msg.Text <> Nothing Then Err_F = "1" : CheckBox001.Focus() : Exit Sub

    End Sub

    Sub CHK_Edit02()        '商品コード
        msg.Text = Nothing

        Edit02.Text = Trim(Edit02.Text)
        If Edit02.Text = Nothing Then
            Edit02.BackColor = System.Drawing.Color.Red
            msg.Text = "商品コードが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM item_mtr WHERE (item_code = '" & Edit02.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(WK_DsList1, "item_mtr")
            DB_CLOSE()
            If r <> 0 Then
                Edit02.BackColor = System.Drawing.Color.Red
                msg.Text = "既に登録済みのコードです。"
                Exit Sub
            End If
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit03()        '商品名（漢字）
        msg.Text = Nothing

        Edit03.Text = Trim(Edit03.Text)
        If Edit03.Text = Nothing Then
            Edit03.BackColor = System.Drawing.Color.Red
            msg.Text = "商品名（漢字）が入力されていません。"
            Exit Sub
        End If
        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit04()        '商品名（カナ）
        msg.Text = Nothing

        Edit04.Text = Trim(Edit04.Text)
        If Edit04.Text = Nothing Then
            Edit04.BackColor = System.Drawing.Color.Red
            msg.Text = "商品名（カナ）が入力されていません。"
            Exit Sub
        End If
        Edit04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_ComboBox1()     'メーカー
        msg.Text = Nothing

        ComboBox1.Text = Trim(ComboBox1.Text)
        If ComboBox1.Text = Nothing Then
            ComboBox1.BackColor = System.Drawing.Color.Red
            msg.Text = "メーカーが選択されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("vdr_mtr"), "vdr_name = '" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                ComboBox1.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するメーカーがありません。"
                Err_F = "1" : Exit Sub
            Else
                Label01.Text = WK_DtView1(0)("vdr_code")
            End If
        End If
        ComboBox1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_ComboBox2()     '部門
        msg.Text = Nothing

        ComboBox2.Text = Trim(ComboBox2.Text)
        If ComboBox2.Text = Nothing Then
            ComboBox2.BackColor = System.Drawing.Color.Red
            msg.Text = "部門が選択されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("section_mtr"), "section_name = '" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                ComboBox2.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する部門がありません。"
                Err_F = "1" : Exit Sub
            Else
                If Label02.Text <> WK_DtView1(0)("section_code") Then
                    Label02.Text = WK_DtView1(0)("section_code")
                    Call CmbSet_3()     'ライン
                    Call CmbSet_4()     'クラス
                    Call CmbSet_5()     'サブクラス
                End If
            End If
        End If
        ComboBox2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_ComboBox3()     'ライン
        msg.Text = Nothing

        ComboBox3.Text = Trim(ComboBox3.Text)
        If ComboBox3.Text = Nothing Then
            ComboBox3.BackColor = System.Drawing.Color.Red
            msg.Text = "ラインが選択されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("line_mtr"), "section_code = '" & Label02.Text & "' AND line_name = '" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                ComboBox3.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するラインがありません。"
                Err_F = "1" : Exit Sub
            Else
                If Label03.Text <> WK_DtView1(0)("line_code") Then
                    Label03.Text = WK_DtView1(0)("line_code")
                    Call CmbSet_4()     'クラス
                    Call CmbSet_5()     'サブクラス
                End If
            End If
        End If
        ComboBox3.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_ComboBox4()     'クラス
        msg.Text = Nothing

        ComboBox4.Text = Trim(ComboBox4.Text)
        If ComboBox4.Text = Nothing Then
            ComboBox4.BackColor = System.Drawing.Color.Red
            msg.Text = "クラスが選択されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("cls_mtr"), "section_code = '" & Label02.Text & "' AND line_code = '" & Label03.Text & "' AND cls_name = '" & ComboBox4.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                ComboBox4.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するクラスがありません。"
                Err_F = "1" : Exit Sub
            Else
                If Label04.Text <> WK_DtView1(0)("cls_code") Then
                    Label04.Text = WK_DtView1(0)("cls_code")
                    Call CmbSet_5()     'サブクラス
                End If
            End If
        End If
        ComboBox4.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_ComboBox5()     'サブクラス
        msg.Text = Nothing

        ComboBox5.Text = Trim(ComboBox5.Text)
        If ComboBox5.Text = Nothing Then
            ComboBox5.BackColor = System.Drawing.Color.Red
            msg.Text = "サブクラスが選択されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("sub_cls_mtr"), "section_code = '" & Label02.Text & "' AND line_code = '" & Label03.Text & "' AND cls_code = '" & Label04.Text & "' AND sub_cls_name = '" & ComboBox5.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                ComboBox5.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するサブクラスがありません。"
                Err_F = "1" : Exit Sub
            Else
                Label05.Text = WK_DtView1(0)("sub_cls_code")
            End If
        End If
        ComboBox5.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit05()        '規格名
        msg.Text = Nothing

        Edit05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_CheckBox001()   '削除フラグ
        msg.Text = Nothing
    End Sub

    '******************************************************************
    '** 更新
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** 項目チェック
        If Err_F = "0" Then

            If P_PRAM1 = Nothing Then   '新規
                Label001.Text = Now.Date

                strSQL = "INSERT INTO item_mtr"
                strSQL = strSQL & " (item_code, vdr_code, section_code, line_code, cls_code, sub_cls_code"
                strSQL = strSQL & ", item_name, item_name_kana, standard_name, reg_date, delt_flg)"
                strSQL = strSQL & " VALUES ('" & Edit02.Text & "'"
                strSQL = strSQL & ", '" & Label01.Text & "'"
                strSQL = strSQL & ", '" & Label02.Text & "'"
                strSQL = strSQL & ", '" & Label03.Text & "'"
                strSQL = strSQL & ", '" & Label04.Text & "'"
                strSQL = strSQL & ", '" & Label05.Text & "'"
                strSQL = strSQL & ", '" & Edit03.Text & "'"
                strSQL = strSQL & ", '" & Edit04.Text & "'"
                strSQL = strSQL & ", '" & Edit05.Text & "'"
                strSQL = strSQL & ", '" & CDate(Label001.Text) & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", 1)" Else strSQL = strSQL & ", 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            Else                        '修正

                strSQL = "UPDATE item_mtr"
                strSQL = strSQL & " SET vdr_code = '" & Label01.Text & "'"
                strSQL = strSQL & ", section_code = '" & Label02.Text & "'"
                strSQL = strSQL & ", line_code = '" & Label03.Text & "'"
                strSQL = strSQL & ", cls_code = '" & Label04.Text & "'"
                strSQL = strSQL & ", sub_cls_code = '" & Label05.Text & "'"
                strSQL = strSQL & ", item_name = '" & Edit03.Text & "'"
                strSQL = strSQL & ", item_name_kana = '" & Edit04.Text & "'"
                strSQL = strSQL & ", standard_name = '" & Edit05.Text & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", delt_flg = 1" Else strSQL = strSQL & ", delt_flg = 0"
                strSQL = strSQL & " WHERE (item_code = '" & P_PRAM1 & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            End If
            P_RTN = "1"
            DsList1.Clear()
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 戻る
    '******************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_RTN = "0"
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB.Clear()
        Close()
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CHK_Edit02()       '商品コード
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CHK_Edit03()       '商品名（漢字）
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Call CHK_Edit04()       '商品名（カナ）
    End Sub
    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.LostFocus
        Call CHK_ComboBox1()    'メーカー
    End Sub
    Private Sub ComboBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.LostFocus
        Call CHK_ComboBox2()    '部門
    End Sub

    Private Sub Ime1_ResultString(sender As Object, e As ResultStringEventArgs) Handles Ime1.ResultString
        ' 取得したふりがなを表示します。
        Edit04.Text += e.ReadString
    End Sub

    Private Sub ComboBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.LostFocus
        Call CHK_ComboBox3()    'ライン
    End Sub
    Private Sub ComboBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.LostFocus
        Call CHK_ComboBox4()    'クラス
    End Sub
    Private Sub ComboBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.LostFocus
        Call CHK_ComboBox5()    'サブクラス
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Call CHK_Edit05()       '規格名
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        Call CHK_CheckBox001()  '削除フラグ
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    '''version issue 20200805. Ime1 object is created
    'Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana.ResultString
    '    ' 取得したふりがなを表示します。
    '    Edit04.Text += e.ReadString
    'End Sub
End Class
