Public Class f_shop_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    'Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, Err_F, CSR_POS As String
    Dim chg_itm As Integer

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
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Combo1 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents f02 As System.Windows.Forms.Button
    Friend WithEvents f01 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label01 = New System.Windows.Forms.Label
        Me.Combo1 = New GrapeCity.Win.Input.Interop.Combo
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        Me.f02 = New System.Windows.Forms.Button
        Me.f01 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.f12 = New System.Windows.Forms.Button
        Me.Edit002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit003 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label47 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label01.Location = New System.Drawing.Point(288, 168)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(56, 24)
        Me.Label01.TabIndex = 1219
        Me.Label01.Text = "Label01"
        Me.Label01.Visible = False
        '
        'Combo1
        '
        Me.Combo1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Combo1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.Combo1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Combo1.Location = New System.Drawing.Point(104, 168)
        Me.Combo1.MaxDropDownItems = 30
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo1.Size = New System.Drawing.Size(176, 24)
        Me.Combo1.TabIndex = 6
        Me.Combo1.Value = "Combo1"
        '
        'Edit1
        '
        Me.Edit1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Edit1.Format = "9"
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(104, 8)
        Me.Edit1.MaxLength = 4
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(56, 24)
        Me.Edit1.TabIndex = 1
        Me.Edit1.Text = "0001"
        Me.Edit1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'f02
        '
        Me.f02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f02.Enabled = False
        Me.f02.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f02.Location = New System.Drawing.Point(112, 204)
        Me.f02.Name = "f02"
        Me.f02.Size = New System.Drawing.Size(96, 32)
        Me.f02.TabIndex = 1214
        Me.f02.TabStop = False
        Me.f02.Text = "更新"
        '
        'f01
        '
        Me.f01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f01.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f01.Location = New System.Drawing.Point(16, 204)
        Me.f01.Name = "f01"
        Me.f01.Size = New System.Drawing.Size(96, 32)
        Me.f01.TabIndex = 1213
        Me.f01.TabStop = False
        Me.f01.Text = "登録"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 24)
        Me.Label6.TabIndex = 1205
        Me.Label6.Text = "開店"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 24)
        Me.Label5.TabIndex = 1204
        Me.Label5.Text = "住所"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 1202
        Me.Label3.Text = "電話番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 1201
        Me.Label1.Text = "店舗ｺｰﾄﾞ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 1200
        Me.Label2.Text = "店舗名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f12.Location = New System.Drawing.Point(332, 204)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 1198
        Me.f12.TabStop = False
        Me.f12.Text = ":閉じる"
        '
        'Edit002
        '
        Me.Edit002.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(104, 72)
        Me.Edit002.MaxLength = 40
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(324, 24)
        Me.Edit002.TabIndex = 3
        Me.Edit002.Text = "あああああああああああああああ"
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit003
        '
        Me.Edit003.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(104, 104)
        Me.Edit003.MaxLength = 20
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(120, 24)
        Me.Edit003.TabIndex = 4
        Me.Edit003.Text = "03-1111-2222"
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit001
        '
        Me.Edit001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(104, 40)
        Me.Edit001.MaxLength = 40
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(324, 24)
        Me.Edit001.TabIndex = 2
        Me.Edit001.Text = "ああああああああああああああああああああ"
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Navy
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label47.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(16, 168)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(88, 24)
        Me.Label47.TabIndex = 1208
        Me.Label47.Text = "店舗種別"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Date1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(104, 136)
        Me.Date1.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2050, 12, 31, 23, 59, 59, 0))
        Me.Date1.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(104, 24)
        Me.Date1.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.TabIndex = 5
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.Value = Nothing
        '
        'f_shop_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(444, 249)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label01)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.f02)
        Me.Controls.Add(Me.f01)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Label47)
        Me.Name = "f_shop_2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "店舗マスタメンテ"
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub f_shop_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        CmbSet()    '**  コンボボックスセット
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
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN()

        '店舗種別
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME FROM V_cls024"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "cls024")

        Combo1.DataSource = DsCMB.Tables("cls024")
        Combo1.DisplayMember = "CLS_CODE_NAME"
        Combo1.ValueMember = "CLS_CODE"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        If P_shop_code2 = Nothing Then   '登録
            f01.Enabled = True
            f02.Enabled = False
            Edit1.Enabled = True

            Edit1.Text = Nothing
            Edit001.Text = Nothing
            Edit002.Text = Nothing
            Edit003.Text = Nothing
            Date1.Text = Nothing
            Combo1.Text = Nothing
            Label01.Text = Nothing

        Else                            '修正
            f01.Enabled = False
            f02.Enabled = True
            Edit1.Enabled = False

            '店舗マスタ
            strSQL = "SELECT SHOP.* FROM SHOP"
            strSQL += " WHERE (SHOP_CODE = '" & P_shop_code2 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "SHOP")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("SHOP"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Edit1.Text = P_shop_code2
                Edit001.Text = DtView1(0)("SHOP_NAME")
                If Not IsDBNull(DtView1(0)("SHOP_ADRS")) Then Edit002.Text = DtView1(0)("SHOP_ADRS") Else Edit002.Text = Nothing
                If Not IsDBNull(DtView1(0)("TEL_NO")) Then Edit003.Text = DtView1(0)("TEL_NO") Else Edit003.Text = Nothing
                If Not IsDBNull(DtView1(0)("OPEN_TIME")) Then Date1.Text = Mid(DtView1(0)("OPEN_TIME"), 1, 10) Else Date1.Text = Nothing
                If Not IsDBNull(DtView1(0)("bk_kbn")) Then Label01.Text = DtView1(0)("bk_kbn") Else Label01.Text = Nothing

                WK_DtView1 = New DataView(DsCMB.Tables("cls024"), "CLS_CODE='" & Label01.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Combo1.Text = WK_DtView1(0)("CLS_CODE_NAME")
                Else
                    Combo1.Text = Nothing
                End If
            End If
        End If
    End Sub

    '********************************************************************
    '** 項目チェック
    '********************************************************************
    Sub F_Check()
        Err_F = "0"

        '店舗コード
        If P_shop_code2 = Nothing Then
            If Trim(Edit1.Text) = Nothing Then
                MessageBox.Show("店舗コードが入力されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Err_F = "1" : Edit1.Focus() : Exit Sub
            Else
                If Len(Trim(Edit1.Text)) <> 4 Then
                    MessageBox.Show("店舗コードは４桁で入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Err_F = "1" : Edit1.Focus() : Exit Sub
                Else
                    WK_DsList1.Clear()
                    strSQL = "SELECT SHOP_CODE FROM SHOP WHERE (SHOP_CODE = '" & Trim(Edit1.Text) & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    DaList1.Fill(WK_DsList1, "SHOP")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("SHOP"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        MessageBox.Show("店舗コードが既に登録されています。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Err_F = "1" : Edit1.Focus() : Exit Sub
                    End If
                End If
            End If
        End If

        '店舗名
        If Trim(Edit001.Text) = Nothing Then
            MessageBox.Show("店舗名が入力されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Err_F = "1" : Edit001.Focus() : Exit Sub
        End If

        '住所
        '電話番号
        '開店

        '店舗種別
        Label01.Text = Nothing
        If Trim(Combo1.Text) = Nothing Then
            MessageBox.Show("店舗種別が入力されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Err_F = "1" : Combo1.Focus() : Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("cls024"), "CLS_CODE_NAME='" & Trim(Combo1.Text) & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                MessageBox.Show("該当する店舗種別がありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Err_F = "1" : Combo1.Focus() : Exit Sub
            Else
                Label01.Text = WK_DtView1(0)("CLS_CODE")
            End If
        End If

    End Sub

    '********************************************************************
    '** 登録ボタン
    '********************************************************************
    Private Sub f01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f01.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            strSQL = "INSERT INTO SHOP"
            strSQL += " (SHOP_CODE, SHOP_NAME, SHOP_ADRS, TEL_NO, OPEN_TIME, bk_kbn)"
            strSQL += " VALUES (N'" & Edit1.Text & "'" 'SHOP_CODE
            strSQL += ", N'" & Trim(Edit001.Text) & "'" 'SHOP_NAME
            If Trim(Edit002.Text) <> Nothing Then strSQL += ", N'" & Trim(Edit002.Text) & "'" Else strSQL += ", NULL" 'SHOP_ADRS
            If Trim(Edit003.Text) <> Nothing Then strSQL += ", N'" & Trim(Edit003.Text) & "'" Else strSQL += ", NULL" 'TEL_NO
            If Date1.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date1.Text & "', 102)" Else strSQL += ", NULL" 'OPEN_TIME
            strSQL += ", '" & Label01.Text & "'" 'bk_kbn
            strSQL += ")"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            MessageBox.Show("店舗ｺｰﾄﾞ:" & Edit1.Text & " で登録しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            P_RTN = "1"
            DsCMB.Clear() : DsList1.Clear() : WK_DsList1.Clear()
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '** 更新ボタン
    '********************************************************************
    Private Sub f02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f02.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            strSQL = "UPDATE SHOP"
            strSQL += " SET SHOP_NAME = N'" & Trim(Edit001.Text) & "'"
            If Trim(Edit002.Text) <> Nothing Then strSQL += ", SHOP_ADRS = N'" & Trim(Edit002.Text) & "'" Else strSQL += ", SHOP_ADRS = NULL"
            If Trim(Edit003.Text) <> Nothing Then strSQL += ", TEL_NO = N'" & Trim(Edit003.Text) & "'" Else strSQL += ", TEL_NO = NULL"
            If Date1.Number <> 0 Then strSQL += ", OPEN_TIME = CONVERT(DATETIME, '" & Date1.Text & "', 102)" Else strSQL += ", OPEN_TIME = NULL"
            strSQL += ", bk_kbn = '" & Label01.Text & "'"
            strSQL += " WHERE (SHOP_CODE = N'" & Edit1.Text & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            MessageBox.Show("更新しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            P_RTN = "1"
            DsCMB.Clear() : DsList1.Clear() : WK_DsList1.Clear()
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        P_RTN = "0"
        DsCMB.Clear() : DsList1.Clear() : WK_DsList1.Clear()
        Close()
    End Sub

End Class
