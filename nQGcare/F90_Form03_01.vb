Public Class F90_Form03_01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 144)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(384, 20)
        Me.msg.TabIndex = 1372
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 172)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "更新"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(328, 172)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 4
        Me.Button99.Text = "閉じる"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 24)
        Me.Label6.TabIndex = 1371
        Me.Label6.Text = "表示順"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 24)
        Me.Label7.TabIndex = 1370
        Me.Label7.Text = "名称"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(100, 80)
        Me.Edit02.MaxLength = 50
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(300, 24)
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
        Me.Edit01.Location = New System.Drawing.Point(100, 48)
        Me.Edit01.MaxLength = 8
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
        Me.Label2.Location = New System.Drawing.Point(20, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 1369
        Me.Label2.Text = "コード"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number1
        '
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number1.Location = New System.Drawing.Point(100, 112)
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(100, 24)
        Me.Number1.TabIndex = 2
        Me.Number1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 1374
        Me.Label1.Text = "項目"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit03
        '
        Me.Edit03.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Edit03.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit03.Enabled = False
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(100, 16)
        Me.Edit03.MaxLength = 50
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(300, 24)
        Me.Edit03.TabIndex = 1375
        Me.Edit03.Text = "Edit03"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'F90_Form03_01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(414, 207)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F90_Form03_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "テーブル・マスタ"
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F90_Form03_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If P_PRAM3 = Nothing Then '新規
            Button1.Text = "登録"
            Edit01.Enabled = True

            Edit01.Text = Nothing
            Edit02.Text = Nothing
            Edit03.Text = P_PRAM2
            Number1.Value = 0

        Else                    '更新
            Button1.Text = "更新"
            Edit01.Enabled = False

            DsList1.Clear()
            strSQL = "SELECT * FROM M02_cls WHERE (cls = '" & P_PRAM1 & "') AND (cls_code = " & P_PRAM3 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "M02_cls")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M02_cls"), "", "", DataViewRowState.CurrentRows)
            Edit01.Text = DtView1(0)("cls_code")
            Edit02.Text = DtView1(0)("cls_code_name")
            Edit03.Text = DtView1(0)("cls_name")
            Number1.Value = DtView1(0)("dsp_seq")
        End If

    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_CHK()
        Err_F = "0"

        Call CK_Edit01() 'ｺｰﾄﾞ
        If msg.Text <> Nothing Then Err_F = "1" : Edit01.Focus() : Exit Sub

        Call CK_Edit02() '名称
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

    End Sub
    Sub CK_Edit01() 'ｺｰﾄﾞ
        msg.Text = Nothing

        If P_PRAM3 = Nothing Then '新規
            Edit01.Text = Trim(Edit01.Text)
            If Edit01.Text = Nothing Then
                msg.Text = "ｺｰﾄﾞの入力がありません。"
                Edit01.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DsList1.Clear()
                strSQL = "SELECT * FROM M02_cls WHERE (cls = '" & P_PRAM1 & "') AND (cls_code = " & Edit01.Text & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nQGCare")
                r = DaList1.Fill(DsList1, "M02_cls")
                DB_CLOSE()
                If r <> 0 Then
                    msg.Text = "入力のｺｰﾄﾞは登録済みです。"
                    Edit01.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
            Edit01.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Sub CK_Edit02() '名称
        msg.Text = Nothing
        Edit02.Text = Trim(Edit02.Text)
        If Edit02.Text = Nothing Then
            msg.Text = "名称の入力がありません。"
            Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
            'Else
            '    DsList1.Clear()
            '    strSQL = "SELECT * FROM M02_cls"
            '    strSQL += " WHERE (cls_code_name = '" & Edit02.Text & "')"
            '    strSQL += " AND (cls = '" & P_PRAM1 & "')"
            '    If P_PRAM3 <> Nothing Then strSQL += " AND (cls_code <> " & P_PRAM3 & ")"
            '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            '    DaList1.SelectCommand = SqlCmd1
            '    DB_OPEN("nQGCare")
            '    r = DaList1.Fill(DsList1, "M02_cls")
            '    DB_CLOSE()
            '    If r <> 0 Then
            '        msg.Text = "入力の名称は登録済みです。"
            '        Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
            '    End If
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
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

    '******************************************************************
    '** 更新
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_CHK()    '** 項目チェック
        If Err_F = "0" Then

            DB_OPEN("nQGCare")
            If P_PRAM3 = Nothing Then   '新規
                'crt_date = Now.Date
                P_PRAM3 = Edit01.Text

                strSQL = "INSERT INTO M02_cls"
                strSQL += " (cls, cls_code, cls_code_name, cls_name, dsp_seq)"
                strSQL += " VALUES ('" & P_PRAM1 & "'"
                strSQL += ", " & Edit01.Text
                strSQL += ", '" & Edit02.Text & "'"
                strSQL += ", '" & P_PRAM2 & "'"
                strSQL += ", " & Number1.Value & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                MessageBox.Show("登録しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else                        '更新
                strSQL = "UPDATE M02_cls"
                strSQL += " SET cls_code_name = '" & Edit02.Text & "'"
                strSQL += ", dsp_seq = " & Number1.Value
                strSQL += " WHERE (cls = '" & P_PRAM1 & "')"
                strSQL += " AND (cls_code = " & P_PRAM3 & ")"
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
