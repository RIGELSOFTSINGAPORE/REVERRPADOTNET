Imports GrapeCity.Win.Input

Public Class F90_Form02_01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    'Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim i, r As Integer
    Dim crt_date As Date

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        'Me.Furigana = Me.Edit02.Ime

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox01 As System.Windows.Forms.CheckBox
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox02 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents CheckBox03 As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.CheckBox01 = New System.Windows.Forms.CheckBox
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox02 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label4 = New System.Windows.Forms.Label
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit
        Me.CheckBox03 = New System.Windows.Forms.CheckBox
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(388, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 24)
        Me.Label1.TabIndex = 1361
        Me.Label1.Text = "登録日："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBox01
        '
        Me.CheckBox01.Location = New System.Drawing.Point(16, 248)
        Me.CheckBox01.Name = "CheckBox01"
        Me.CheckBox01.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox01.Size = New System.Drawing.Size(112, 24)
        Me.CheckBox01.TabIndex = 7
        Me.CheckBox01.Text = "削除"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(96, 284)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(444, 20)
        Me.msg.TabIndex = 1360
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 280)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "更新"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(552, 280)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 9
        Me.Button99.Text = "閉じる"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 24)
        Me.Label6.TabIndex = 1359
        Me.Label6.Text = "カナ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 24)
        Me.Label7.TabIndex = 1358
        Me.Label7.Text = "取扱店名"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit03
        '
        Me.Edit03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(112, 80)
        Me.Edit03.MaxLength = 100
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(512, 24)
        Me.Edit03.TabIndex = 2
        Me.Edit03.Text = "Edit03"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(112, 48)
        Me.Edit02.MaxLength = 100
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(512, 24)
        Me.Edit02.TabIndex = 1
        Me.Edit02.Text = "Edit02"
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit01
        '
        Me.Edit01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.Format = "9"
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(112, 16)
        Me.Edit01.MaxLength = 7
        Me.Edit01.Name = "Edit01"
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(104, 24)
        Me.Edit01.TabIndex = 0
        Me.Edit01.Text = "01"
        Me.Edit01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Edit01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 24)
        Me.Label2.TabIndex = 1357
        Me.Label2.Text = "コード"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBox02
        '
        Me.CheckBox02.Location = New System.Drawing.Point(16, 176)
        Me.CheckBox02.Name = "CheckBox02"
        Me.CheckBox02.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox02.Size = New System.Drawing.Size(112, 24)
        Me.CheckBox02.TabIndex = 5
        Me.CheckBox02.Text = "一般"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 24)
        Me.Label3.TabIndex = 1363
        Me.Label3.Text = "店コード"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit04
        '
        Me.Edit04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit04.HighlightText = True
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(112, 112)
        Me.Edit04.MaxLength = 6
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(100, 24)
        Me.Edit04.TabIndex = 3
        Me.Edit04.Text = "Edit04"
        Me.Edit04.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 24)
        Me.Label4.TabIndex = 1365
        Me.Label4.Text = "取引先コード"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit05
        '
        Me.Edit05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit05.HighlightText = True
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(112, 144)
        Me.Edit05.MaxLength = 6
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(100, 24)
        Me.Edit05.TabIndex = 4
        Me.Edit05.Text = "Edit05"
        Me.Edit05.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'CheckBox03
        '
        Me.CheckBox03.Location = New System.Drawing.Point(16, 212)
        Me.CheckBox03.Name = "CheckBox03"
        Me.CheckBox03.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox03.Size = New System.Drawing.Size(112, 24)
        Me.CheckBox03.TabIndex = 6
        Me.CheckBox03.Text = "旧請求方法"
        '
        'F90_Form02_01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(634, 323)
        Me.Controls.Add(Me.CheckBox03)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.CheckBox02)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox01)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F90_Form02_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "取扱店マスタ"
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F90_Form02_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        msg.Text = Nothing

    End Sub

    '********************************************************************
    '** 画面セット
    '********************************************************************
    Sub dsp_set()

        If P_PRAM1 = Nothing Then '新規
            Button1.Text = "登録"
            Edit01.Enabled = True

            Edit01.Text = Nothing
            Edit02.Text = Nothing
            Edit03.Text = Nothing
            Edit04.Text = Nothing
            Edit05.Text = Nothing
            CheckBox01.Checked = False

        Else                    '更新
            Button1.Text = "更新"
            Edit01.Enabled = False

            DsList1.Clear()
            strSQL = "SELECT * FROM M04_shop WHERE (shop_code = " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "M04_shop")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M04_shop"), "", "", DataViewRowState.CurrentRows)
            Edit01.Text = DtView1(0)("shop_code")
            Edit02.Text = DtView1(0)("shop_name")
            If Not IsDBNull(DtView1(0)("shop_name_kana")) Then Edit03.Text = DtView1(0)("shop_name_kana") Else Edit03.Text = Nothing
            If Not IsDBNull(DtView1(0)("shop_shop_code")) Then Edit04.Text = DtView1(0)("shop_shop_code") Else Edit04.Text = Nothing
            If Not IsDBNull(DtView1(0)("torihiki_code")) Then Edit05.Text = DtView1(0)("torihiki_code") Else Edit05.Text = Nothing
            If DtView1(0)("ittpan") = "True" Then CheckBox02.Checked = True Else CheckBox02.Checked = False
            If DtView1(0)("ivc_old_flg") = "True" Then CheckBox03.Checked = True Else CheckBox03.Checked = False
            If Not IsDBNull(DtView1(0)("reg_date")) Then Label1.Text = Label1.Text & DtView1(0)("reg_date")
            If DtView1(0)("delt_flg") = "True" Then CheckBox01.Checked = True Else CheckBox01.Checked = False
        End If

    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    'Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana.ResultString
    '    ' 取得したふりがなを表示します。
    '    If Edit02.ReadOnly = False Then
    '        Edit03.Text += e.ReadString
    '    End If
    'End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_CHK()
        Err_F = "0"

        Call CK_Edit01() 'ｺｰﾄﾞ
        If msg.Text <> Nothing Then Err_F = "1" : Edit01.Focus() : Exit Sub

        Call CK_Edit02() '取扱店名
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

        Call CK_Edit03() 'カナ
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

    End Sub
    Sub CK_Edit01() 'ｺｰﾄﾞ
        msg.Text = Nothing

        If P_PRAM1 = Nothing Then '新規
            Edit01.Text = Trim(Edit01.Text)
            If Edit01.Text = Nothing Then
                msg.Text = "ｺｰﾄﾞの入力がありません。"
                Edit01.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DsList1.Clear()
                strSQL = "SELECT * FROM M04_shop WHERE (shop_code = " & Edit01.Text & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nQGCare")
                r = DaList1.Fill(DsList1, "M04_shop")
                DB_CLOSE()
                If r <> 0 Then
                    msg.Text = "入力のｺｰﾄﾞは登録済みです。"
                    Edit01.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
            Edit01.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Sub CK_Edit02() '取扱店名
        msg.Text = Nothing
        Edit02.Text = Trim(Edit02.Text)
        If Edit02.Text = Nothing Then
            msg.Text = "取扱店名の入力がありません。"
            Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            DsList1.Clear()
            strSQL = "SELECT * FROM M04_shop"
            strSQL += " WHERE (shop_name = '" & Edit02.Text & "')"
            If P_PRAM1 <> Nothing Then strSQL += " AND (shop_code <> " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(DsList1, "M04_shop")
            DB_CLOSE()
            If r <> 0 Then
                msg.Text = "入力の取扱店名は登録済みです。"
                Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit03() 'カナ
        msg.Text = Nothing
        Edit03.Text = Trim(Edit03.Text)
        If Edit03.Text = Nothing Then
            'msg.Text = "カナの入力がありません。"
            'Edit03.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            DsList1.Clear()
            strSQL = "SELECT * FROM M04_shop"
            strSQL += " WHERE (shop_name = '" & Edit03.Text & "')"
            If P_PRAM1 <> Nothing Then strSQL += " AND (shop_code <> " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(DsList1, "M04_shop")
            DB_CLOSE()
            If r <> 0 Then
                msg.Text = "入力のカナは登録済みです。"
                Edit03.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.LostFocus
        Call CK_Edit01() 'ｺｰﾄﾞ
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CK_Edit02() '取扱店名
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CK_Edit03() 'カナ
    End Sub

    '******************************************************************
    '** 更新
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_CHK()    '** 項目チェック
        If Err_F = "0" Then

            DB_OPEN("nQGCare")
            If P_PRAM1 = Nothing Then   '新規
                crt_date = Now.Date
                P_PRAM1 = Edit01.Text

                strSQL = "INSERT INTO M04_shop"
                strSQL += " (shop_code, shop_name, shop_name_kana, ittpan, ivc_old_flg, shop_shop_code, torihiki_code, reg_date, delt_flg)"
                strSQL += " VALUES (" & Edit01.Text & ""
                strSQL += ", '" & Edit02.Text & "'"
                strSQL += ", '" & Edit03.Text & "'"
                If CheckBox02.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                If CheckBox03.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                strSQL += ", '" & Edit04.Text & "'"
                strSQL += ", '" & Edit05.Text & "'"

                strSQL += ", CONVERT(DATETIME, '" & crt_date & "', 102)"
                If CheckBox01.Checked = True Then strSQL += ", 1)" Else strSQL += ", 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                Label1.Text = Label1.Text & crt_date

                MessageBox.Show("登録しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else                        '更新
                strSQL = "UPDATE M04_shop"
                strSQL += " SET shop_name = '" & Edit02.Text & "'"
                strSQL += ", shop_name_kana = '" & Edit03.Text & "'"
                strSQL += ", shop_shop_code = '" & Edit04.Text & "'"
                strSQL += ", torihiki_code = '" & Edit05.Text & "'"
                If CheckBox02.Checked = True Then strSQL += ", ittpan = 1" Else strSQL += ", ittpan = 0"
                If CheckBox03.Checked = True Then strSQL += ", ivc_old_flg = 1" Else strSQL += ", ivc_old_flg = 0"
                If CheckBox01.Checked = True Then strSQL += ", delt_flg = 1" Else strSQL += ", delt_flg = 0"
                strSQL += " WHERE (shop_code = " & P_PRAM1 & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                MessageBox.Show("更新しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            DB_CLOSE()

            P_RTN = "1"
            DsList1.Clear()
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        P_RTN = "0"
        DsList1.Clear()
        Close()
    End Sub
End Class
