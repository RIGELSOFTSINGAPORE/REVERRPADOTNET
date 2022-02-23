Imports GrapeCity.Win.Input.Interop

Public Class F05_Form01_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0
    'version issue 20200805. created Ime1 object
    'Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
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
        'version issue 20200805. Ime1 object is created
        ' Me.Furigana = Me.Edit03.Ime
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Edit08 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Mask05 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F05_Form01_2))
        Me.Edit08 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit07 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Mask05 = New GrapeCity.Win.Input.Interop.Mask()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.msg = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button98 = New System.Windows.Forms.Button()
        Me.CheckBox001 = New System.Windows.Forms.CheckBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label001 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Ime1 = New GrapeCity.Win.Input.Interop.Ime()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask05, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Edit08
        '
        Me.Edit08.Format = "9@"
        Me.Edit08.HighlightText = True
        Me.Edit08.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit08.LengthAsByte = True
        Me.Edit08.Location = New System.Drawing.Point(136, 224)
        Me.Edit08.MaxLength = 13
        Me.Edit08.Name = "Edit08"
        Me.Edit08.Size = New System.Drawing.Size(124, 24)
        Me.Edit08.TabIndex = 7
        Me.Edit08.Text = "08"
        Me.Edit08.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit07
        '
        Me.Edit07.HighlightText = True
        Me.Edit07.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(136, 196)
        Me.Edit07.MaxLength = 100
        Me.Edit07.Name = "Edit07"
        Me.Edit07.Size = New System.Drawing.Size(656, 24)
        Me.Edit07.TabIndex = 6
        Me.Edit07.Text = "12345678901"
        Me.Edit07.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit06
        '
        Me.Edit06.HighlightText = True
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(136, 168)
        Me.Edit06.MaxLength = 100
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Size = New System.Drawing.Size(656, 24)
        Me.Edit06.TabIndex = 5
        Me.Edit06.Text = "Edit06"
        Me.Edit06.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.HighlightText = True
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(136, 112)
        Me.Edit04.MaxLength = 40
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Size = New System.Drawing.Size(328, 24)
        Me.Edit04.TabIndex = 3
        Me.Edit04.Text = "1234567890123456789012345678901234567890"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit03
        '
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(136, 84)
        Me.Edit03.MaxLength = 40
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Size = New System.Drawing.Size(328, 24)
        Me.Edit03.TabIndex = 2
        Me.Edit03.Text = "12"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 24)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "電話番号"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 24)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "住所2"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 24)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "住所１"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 24)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "店舗名（カナ）"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 24)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "店舗名（漢字）"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 24)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "店舗コード"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.HighlightText = True
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(136, 56)
        Me.Edit02.MaxLength = 6
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Size = New System.Drawing.Size(100, 24)
        Me.Edit02.TabIndex = 1
        Me.Edit02.Text = "123456"
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Mask05
        '
        Me.Mask05.Format = New GrapeCity.Win.Input.Interop.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask05.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Mask05.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask05.Location = New System.Drawing.Point(136, 140)
        Me.Mask05.Name = "Mask05"
        Me.Mask05.Size = New System.Drawing.Size(100, 24)
        Me.Mask05.TabIndex = 4
        Me.Mask05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Mask05.Value = "0900006"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 24)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "郵便番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 284)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(784, 24)
        Me.msg.TabIndex = 1186
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 320)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 28)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(712, 320)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(76, 28)
        Me.Button98.TabIndex = 10
        Me.Button98.Text = "戻る"
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(136, 252)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 8
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(12, 252)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(124, 24)
        Me.Label52.TabIndex = 1188
        Me.Label52.Text = "削除フラグ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(688, 8)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1190
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(600, 8)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1189
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Ime1
        '
        '
        'F05_Form01_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(798, 355)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Mask05)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Edit08)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit02)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F05_Form01_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac 店舗マスタメンテ"
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask05, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F05_Form01_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
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

    '******************************************************************
    '** 画面セット
    '******************************************************************
    Sub dsp_set()

        If P_PRAM1 = Nothing Then   '新規
            Edit02.Enabled = True

            Edit02.Text = Nothing
            Edit03.Text = Nothing
            Edit04.Text = Nothing
            Mask05.Value = Nothing
            Edit06.Text = Nothing
            Edit07.Text = Nothing
            Edit08.Text = Nothing
            Label001.Text = Nothing
            CheckBox001.Checked = False

        Else                        '修正
            Edit02.Enabled = False

            strSQL = "SELECT * FROM Shop_mtr WHERE (shop_code = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "Shop_mtr")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("Shop_mtr"), "", "", DataViewRowState.CurrentRows)
            Edit02.Text = DtView1(0)("shop_code")
            Edit03.Text = DtView1(0)("shop_name")
            Edit04.Text = DtView1(0)("shop_name_kana")
            If Not IsDBNull(DtView1(0)("zip")) Then Mask05.Value = DtView1(0)("zip") Else Mask05.Value = Nothing
            If Not IsDBNull(DtView1(0)("adrs1")) Then Edit06.Text = DtView1(0)("adrs1") Else Edit06.Text = Nothing
            If Not IsDBNull(DtView1(0)("adrs2")) Then Edit07.Text = DtView1(0)("adrs2") Else Edit07.Text = Nothing
            If Not IsDBNull(DtView1(0)("tel")) Then Edit08.Text = DtView1(0)("tel") Else Edit08.Text = Nothing
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
            Call CHK_Edit02()       '店舗コード
            If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub
        End If

        Call CHK_Edit03()           '店舗名（漢字）
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        Call CHK_Edit04()           '店舗名（カナ）
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        Call CHK_Mask05()           '郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask05.Focus() : Exit Sub

        Call CHK_Edit06()           '住所１
        If msg.Text <> Nothing Then Err_F = "1" : Edit06.Focus() : Exit Sub

        Call CHK_Edit07()           '住所2
        If msg.Text <> Nothing Then Err_F = "1" : Edit07.Focus() : Exit Sub

        Call CHK_Edit08()           '電話番号
        If msg.Text <> Nothing Then Err_F = "1" : Edit08.Focus() : Exit Sub

        Call CHK_CheckBox001()      '削除フラグ
        If msg.Text <> Nothing Then Err_F = "1" : CheckBox001.Focus() : Exit Sub

    End Sub

    Sub CHK_Edit02()        '店舗コード
        msg.Text = Nothing

        Edit02.Text = Trim(Edit02.Text)
        If Edit02.Text = Nothing Then
            Edit02.BackColor = System.Drawing.Color.Red
            msg.Text = "店舗コードが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM Shop_mtr WHERE (shop_code = '" & Edit02.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(WK_DsList1, "Shop_mtr")
            DB_CLOSE()
            If r <> 0 Then
                Edit02.BackColor = System.Drawing.Color.Red
                msg.Text = "既に登録済みのコードです。"
                Exit Sub
            End If
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit03()        '店舗名（漢字）
        msg.Text = Nothing

        Edit03.Text = Trim(Edit03.Text)
        If Edit03.Text = Nothing Then
            Edit03.BackColor = System.Drawing.Color.Red
            msg.Text = "店舗名（漢字）が入力されていません。"
            Exit Sub
        End If
        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit04()        '店舗名（カナ）
        msg.Text = Nothing

        Edit04.Text = Trim(Edit04.Text)
        If Edit04.Text = Nothing Then
            Edit04.BackColor = System.Drawing.Color.Red
            msg.Text = "店舗名（カナ）が入力されていません。"
            Exit Sub
        End If
        Edit04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Mask05()        '郵便番号
        msg.Text = Nothing
        If Mask05.Value = Nothing Then
        Else
            If Len(Mask05.Value) <> 7 Then
                Mask05.BackColor = System.Drawing.Color.Red
                msg.Text = "郵便番号は7桁入力してください。"
                Exit Sub
            End If
        End If
        Mask05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit06()        '住所１
        msg.Text = Nothing

        Edit06.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit07()        '住所2
        msg.Text = Nothing

        Edit07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit08()        '電話番号
        msg.Text = Nothing

        Edit08.BackColor = System.Drawing.SystemColors.Window
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

                strSQL = "INSERT INTO Shop_mtr"
                strSQL = strSQL & " (shop_code, shop_name, shop_name_kana, adrs1, adrs2, zip, tel, reg_date, delt_flg)"
                strSQL = strSQL & " VALUES ('" & Edit02.Text & "'"
                strSQL = strSQL & ", '" & Edit03.Text & "'"
                strSQL = strSQL & ", '" & Edit04.Text & "'"
                strSQL = strSQL & ", '" & Edit06.Text & "'"
                strSQL = strSQL & ", '" & Edit07.Text & "'"
                strSQL = strSQL & ", '" & Mask05.Value & "'"
                strSQL = strSQL & ", '" & Edit08.Text & "'"
                strSQL = strSQL & ", '" & CDate(Label001.Text) & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", 1)" Else strSQL = strSQL & ", 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            Else                        '修正

                strSQL = "UPDATE Shop_mtr"
                strSQL = strSQL & " SET shop_name = '" & Edit03.Text & "'"
                strSQL = strSQL & ", shop_name_kana = '" & Edit04.Text & "'"
                strSQL = strSQL & ", adrs1 = '" & Edit06.Text & "'"
                strSQL = strSQL & ", adrs2 = '" & Edit07.Text & "'"
                strSQL = strSQL & ", zip = '" & Mask05.Value & "'"
                strSQL = strSQL & ", tel = '" & Edit08.Text & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", delt_flg = 1" Else strSQL = strSQL & ", delt_flg = 0"
                strSQL = strSQL & " WHERE (shop_code = '" & P_PRAM1 & "')"
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
        Close()
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CHK_Edit02()       '店舗コード
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CHK_Edit03()       '店舗名（漢字）
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Call CHK_Edit04()       '店舗名（カナ）
    End Sub
    Private Sub Mask05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask05.LostFocus
        Call CHK_Mask05()       '郵便番号
    End Sub

    Private Sub Ime1_ResultString(sender As Object, e As ResultStringEventArgs) Handles Ime1.ResultString
        ' 取得したふりがなを表示します。
        Edit04.Text += e.ReadString
    End Sub

    Private Sub Edit06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit06.LostFocus
        Call CHK_Edit06()       '住所１
    End Sub
    Private Sub Edit07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit07.LostFocus
        Call CHK_Edit07()       '住所2
    End Sub
    Private Sub Edit08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit08.LostFocus
        Call CHK_Edit08()       '電話番号
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        Call CHK_CheckBox001()  '削除フラグ
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    'version issue 20200805. ime1 object is created
    'Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana.ResultString
    '    ' 取得したふりがなを表示します。
    '    Edit04.Text += e.ReadString
    'End Sub
End Class
