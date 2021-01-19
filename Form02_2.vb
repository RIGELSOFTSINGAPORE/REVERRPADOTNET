Public Class Form02_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim WK_DtView1, cls_DtView1 As DataView

    Dim strSQL, Err_F As String

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
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Interop.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Edit003 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit004 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Edit005 = New GrapeCity.Win.Input.Interop.Edit
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(404, 4)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1310
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(316, 4)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1309
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 224)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(500, 24)
        Me.msg.TabIndex = 1308
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 256)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(444, 256)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 7
        Me.Button98.Text = "戻る"
        '
        'CheckBox001
        '
        Me.CheckBox001.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(108, 192)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 5
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(12, 192)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 24)
        Me.Label52.TabIndex = 1306
        Me.Label52.Text = "削除ﾌﾗｸﾞ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 24)
        Me.Label9.TabIndex = 1305
        Me.Label9.Text = "住所"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit003
        '
        Me.Edit003.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(108, 96)
        Me.Edit003.MaxLength = 100
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(404, 24)
        Me.Edit003.TabIndex = 2
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 24)
        Me.Label6.TabIndex = 1304
        Me.Label6.Text = "店舗名"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(12, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 24)
        Me.Label11.TabIndex = 1303
        Me.Label11.Text = "店舗ｺｰﾄﾞ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Format = "9"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(108, 32)
        Me.Edit001.MaxLength = 5
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(92, 24)
        Me.Edit001.TabIndex = 0
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit002
        '
        Me.Edit002.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(108, 64)
        Me.Edit002.MaxLength = 50
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(404, 24)
        Me.Edit002.TabIndex = 1
        Me.Edit002.Text = "ああああああああああ"
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 1312
        Me.Label1.Text = "電話番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit004
        '
        Me.Edit004.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit004.LengthAsByte = True
        Me.Edit004.Location = New System.Drawing.Point(108, 128)
        Me.Edit004.MaxLength = 13
        Me.Edit004.Name = "Edit004"
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(140, 24)
        Me.Edit004.TabIndex = 3
        Me.Edit004.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 24)
        Me.Label2.TabIndex = 1314
        Me.Label2.Text = "FAX番号"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit005
        '
        Me.Edit005.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(108, 160)
        Me.Edit005.MaxLength = 13
        Me.Edit005.Name = "Edit005"
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(140, 24)
        Me.Edit005.TabIndex = 4
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Form02_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(522, 295)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit002)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "Form02_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "店舗"
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form02_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
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

        P_RTN = "0"
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        DsList1.Clear()

        If P_PRAM1 = Nothing Then   '新規
            Button1.Text = "登録"
            Edit001.Enabled = True

            Edit001.Text = Nothing
            Edit002.Text = Nothing
            Edit003.Text = Nothing
            Edit004.Text = Nothing
            Edit005.Text = Nothing
            CheckBox001.Checked = False
            Label001.Text = Nothing

        Else                        '修正
            Button1.Text = "更新"
            Edit001.Enabled = False

            '店舗
            strSQL = "SELECT * FROM SHOP"
            strSQL = strSQL & " WHERE (SHOP_CODE = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "SHOP")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("SHOP"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Edit001.Text = P_PRAM1
                Edit002.Text = Trim(DtView1(0)("SHOP_NAME"))
                Edit003.Text = Trim(DtView1(0)("SHOP_ADRS"))
                Edit004.Text = Trim(DtView1(0)("TEL_NO"))
                Edit005.Text = Trim(DtView1(0)("FAX_NO"))
                If DtView1(0)("delt_flg") = "1" Then
                    CheckBox001.Checked = True
                Else
                    CheckBox001.Checked = False
                End If
                Label001.Text = DtView1(0)("reg_date")
            End If
        End If
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Edit001()   '店舗ｺｰﾄﾞ
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "店舗ｺｰﾄﾞが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM SHOP"
            strSQL = strSQL & " WHERE (SHOP_CODE = '" & Edit001.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "SHOP")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("SHOP"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "店舗ｺｰﾄﾞが既に登録されています。"
                Exit Sub
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit002()   '店舗名
        msg.Text = Nothing

        Edit002.Text = Trim(Edit002.Text)
        If Edit002.Text = Nothing Then
            Edit002.BackColor = System.Drawing.Color.Red
            msg.Text = "店舗名が入力されていません。"
            Exit Sub
        End If
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit003()   '住所
        msg.Text = Nothing

        Edit003.Text = Trim(Edit003.Text)
        'If Edit003.Text = Nothing Then
        '    Edit003.BackColor = System.Drawing.Color.Red
        '    msg.Text = "住所が入力されていません。"
        '    Exit Sub
        'End If
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit004()   '電話番号
        msg.Text = Nothing

        Edit004.Text = Trim(Edit004.Text)
        'If Edit004.Text = Nothing Then
        '    Edit004.BackColor = System.Drawing.Color.Red
        '    msg.Text = "電話番号が入力されていません。"
        '    Exit Sub
        'End If
        Edit004.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit005()   'FAX番号
        msg.Text = Nothing

        Edit005.Text = Trim(Edit005.Text)
        'If Edit005.Text = Nothing Then
        '    Edit005.BackColor = System.Drawing.Color.Red
        '    msg.Text = "FAX番号が入力されていません。"
        '    Exit Sub
        'End If
        Edit005.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        If P_PRAM1 = Nothing Then   '新規
            CHK_Edit001() '店舗ｺｰﾄﾞ
            If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub
        End If

        CHK_Edit002() '店舗名
        If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub

        CHK_Edit003() '住所
        If msg.Text <> Nothing Then Err_F = "1" : Edit003.Focus() : Exit Sub

        CHK_Edit004() '電話番号
        If msg.Text <> Nothing Then Err_F = "1" : Edit004.Focus() : Exit Sub

        CHK_Edit005() 'FAX番号
        If msg.Text <> Nothing Then Err_F = "1" : Edit005.Focus() : Exit Sub

    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.GotFocus
        Edit002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.GotFocus
        Edit004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.GotFocus
        Edit005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.GotFocus
        CheckBox001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()
    End Sub
    Private Sub Edit002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.LostFocus
        CHK_Edit002()
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        CHK_Edit003()
    End Sub
    Private Sub Edit004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.LostFocus
        CHK_Edit004()
    End Sub
    Private Sub Edit005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.LostFocus
        CHK_Edit005()
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        CheckBox001.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  項目チェック
        If Err_F = "0" Then
            If P_PRAM1 = Nothing Then   '新規
                Label001.Text = Now.Date

                strSQL = "INSERT INTO SHOP"
                strSQL = strSQL & " (SHOP_CODE, SHOP_CODE_int, SHOP_NAME, SHOP_ADRS, TEL_NO, FAX_NO, reg_date, delt_flg)"
                strSQL = strSQL & " VALUES ('" & Edit001.Text & "'"
                strSQL = strSQL & ", " & CInt(Edit001.Text)
                strSQL = strSQL & ", '" & Edit002.Text & "'"
                strSQL = strSQL & ", '" & Edit003.Text & "'"
                strSQL = strSQL & ", '" & Edit004.Text & "'"
                strSQL = strSQL & ", '" & Edit005.Text & "'"
                strSQL = strSQL & ", '" & CDate(Label001.Text) & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", 1)" Else strSQL = strSQL & ", 0)"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                msg.Text = "登録しました。"
                P_RTN = "1"
                P_PRAM1 = Edit001.Text
                DspSet()    '**  画面セット
            Else                        '修正

                strSQL = "UPDATE SHOP"
                strSQL = strSQL & " SET SHOP_NAME = '" & Edit002.Text & "'"
                strSQL = strSQL & ", SHOP_ADRS = '" & Edit003.Text & "'"
                strSQL = strSQL & ", TEL_NO = '" & Edit004.Text & "'"
                strSQL = strSQL & ", FAX_NO = '" & Edit005.Text & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", delt_flg = 1" Else strSQL = strSQL & ", delt_flg = 0"
                strSQL = strSQL & " WHERE (SHOP_CODE = '" & P_PRAM1 & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                msg.Text = "更新しました。"
                DspSet()    '**  画面セット
                P_RTN = "1"
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
