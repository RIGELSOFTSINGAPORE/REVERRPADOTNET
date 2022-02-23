Public Class Form04_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DsCMB As New DataSet
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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 140)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(500, 24)
        Me.msg.TabIndex = 1308
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 172)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(444, 172)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "戻る"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 24)
        Me.Label6.TabIndex = 1304
        Me.Label6.Text = "品種名"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(12, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 24)
        Me.Label11.TabIndex = 1303
        Me.Label11.Text = "品種ｺｰﾄﾞ"
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
        Me.Edit001.Location = New System.Drawing.Point(108, 36)
        Me.Edit001.MaxLength = 6
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
        Me.Edit002.Location = New System.Drawing.Point(108, 68)
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
        Me.Label1.Location = New System.Drawing.Point(12, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 1309
        Me.Label1.Text = "分類"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(108, 100)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(152, 24)
        Me.ComboBox1.TabIndex = 1310
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Form04_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(530, 215)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit002)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "Form04_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "商品ｶﾃｺﾞﾘｰ"
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form04_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        CmbSet()    '** ComboBox
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

    '**********************************
    '** ComboBox
    '**********************************
    Sub CmbSet()
        DB_OPEN()

        '故障状況
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE (CLS_NO = '022')"
        strSQL = strSQL & " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_022")

        ComboBox1.DataSource = DsCMB.Tables("CLS_CODE_022")
        ComboBox1.DisplayMember = "CLS_CODE_NAME"
        ComboBox1.ValueMember = "CLS_CODE"

        DB_CLOSE()
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
            ComboBox1.Text = Nothing

        Else                        '修正
            Button1.Text = "更新"
            Edit001.Enabled = False

            'M_category
            strSQL = "SELECT * FROM M08_KBN_CAT"
            strSQL = strSQL & " WHERE (CAT_CODE = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "M08_KBN_CAT")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M08_KBN_CAT"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Edit001.Text = P_PRAM1
                Edit002.Text = Trim(DtView1(0)("ITEM_NAME"))
                ComboBox1.SelectedValue = DtView1(0)("KBN_CODE")
            End If
        End If
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Edit001()   '品種ｺｰﾄﾞ
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "品種ｺｰﾄﾞが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM M08_KBN_CAT"
            strSQL = strSQL & " WHERE (CAT_CODE = '" & Edit001.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "M08_KBN_CAT")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("M08_KBN_CAT"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "品種ｺｰﾄﾞが既に登録されています。"
                Exit Sub
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit002()   '品種名
        msg.Text = Nothing

        Edit002.Text = Trim(Edit002.Text)
        If Edit002.Text = Nothing Then
            Edit002.BackColor = System.Drawing.Color.Red
            msg.Text = "品種名が入力されていません。"
            Exit Sub
        End If
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_ComboBox1()   '分類
        msg.Text = Nothing

        If Trim(ComboBox1.Text) = Nothing Then
            ComboBox1.BackColor = System.Drawing.Color.Red
            msg.Text = "分類が選択されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_022"), "CLS_CODE='" & ComboBox1.SelectedValue & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                ComboBox1.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する分類がありません。"
                Exit Sub
            End If
        End If
    End Sub

    Sub F_Check()
        Err_F = "0"

        If P_PRAM1 = Nothing Then   '新規
            CHK_Edit001() '品種ｺｰﾄﾞ
            If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub
        End If

        CHK_Edit002() '品種名
        If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub

        CHK_ComboBox1()   '分類
        If msg.Text <> Nothing Then Err_F = "1" : ComboBox1.Focus() : Exit Sub

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
    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.LostFocus
        CHK_ComboBox1()
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  項目チェック
        If Err_F = "0" Then
            If P_PRAM1 = Nothing Then   '新規

                strSQL = "INSERT INTO M08_KBN_CAT"
                strSQL = strSQL & " (CAT_CODE, ITEM_NAME, KBN_CODE)"
                strSQL = strSQL & " VALUES ('" & Edit001.Text & "'"
                strSQL = strSQL & ", '" & Edit002.Text & "'"
                strSQL = strSQL & ", '" & ComboBox1.SelectedValue & "')"
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

                strSQL = "UPDATE M08_KBN_CAT"
                strSQL = strSQL & " SET ITEM_NAME = '" & Edit002.Text & "'"
                strSQL = strSQL & ", KBN_CODE = '" & ComboBox1.SelectedValue & "'"
                strSQL = strSQL & " WHERE (CAT_CODE = '" & P_PRAM1 & "')"
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
