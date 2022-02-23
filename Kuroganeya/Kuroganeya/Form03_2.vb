Public Class Form03_2
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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Number001 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form03_2))
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Number001 = New GrapeCity.Win.Input.Interop.Number
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 236)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(800, 24)
        Me.msg.TabIndex = 1290
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 268)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1279
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(736, 268)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 1281
        Me.Button98.Text = "戻る"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(584, 24)
        Me.Label1.TabIndex = 1289
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit1
        '
        Me.Edit1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit1.Format = "9"
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(104, 44)
        Me.Edit1.MaxLength = 4
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(56, 24)
        Me.Edit1.TabIndex = 1274
        Me.Edit1.Text = "1"
        Me.Edit1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 88)
        Me.Label6.TabIndex = 1288
        Me.Label6.Text = "CLS名称"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(8, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 24)
        Me.Label7.TabIndex = 1287
        Me.Label7.Text = "CLSｺｰﾄﾞ"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(104, 76)
        Me.Edit001.MaxLength = 50
        Me.Edit001.Multiline = True
        Me.Edit001.Name = "Edit001"
        Me.Edit001.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit001.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(720, 88)
        Me.Edit001.TabIndex = 1275
        Me.Edit001.Text = "ああああああああああ"
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Top
        '
        'Number001
        '
        Me.Number001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        'Me.Number001.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        'Me.Number001.Format = New GrapeCity.Win.Input.Interop.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(104, 172)
        Me.Number001.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(80, 24)
        Me.Number001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1277
        Me.Number001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number001.Value = Nothing
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(104, 204)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 1278
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(712, 12)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1285
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(8, 204)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 24)
        Me.Label52.TabIndex = 1284
        Me.Label52.Text = "削除ﾌﾗｸﾞ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(624, 12)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1283
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Navy
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(8, 172)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(96, 24)
        Me.Label50.TabIndex = 1282
        Me.Label50.Text = "表示順"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form03_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(842, 307)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label50)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form03_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "区分マスタ"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form03_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        strSQL = "SELECT cls_no + ':' + cls_name AS cls_name"
        strSQL +=  " FROM CLS"
        strSQL +=  " WHERE (cls_no = '" & P_PRAM1 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "CLS")
        DB_CLOSE()

        cls_DtView1 = New DataView(DsList1.Tables("CLS"), "", "", DataViewRowState.CurrentRows)
        If cls_DtView1.Count <> 0 Then
            Label1.Text = Trim(cls_DtView1(0)("cls_name"))
        End If

        If P_PRAM2 = Nothing Then   '新規
            Button1.Text = "登録"
            Edit1.Enabled = True
            Edit1.Text = Nothing
            Edit001.Text = Nothing
            Number001.Value = 0
            CheckBox001.Checked = False
            Label001.Text = Nothing

        Else                        '修正
            Button1.Text = "更新"
            Edit1.Enabled = False

            'CLS_CODE
            strSQL = "SELECT * FROM CLS_CODE"
            strSQL +=  " WHERE (cls_no = '" & P_PRAM1 & "')"
            strSQL +=  " AND (cls_code = '" & P_PRAM2 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "CLS_CODE")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Edit1.Text = P_PRAM2
                Edit001.Text = Trim(DtView1(0)("cls_code_name"))
                If Not IsDBNull(DtView1(0)("dsp_seq")) Then Number001.Value = DtView1(0)("dsp_seq") Else Number001.Value = 0
                If DtView1(0)("delt_flg") = "1" Then
                    CheckBox001.Checked = True
                Else
                    CheckBox001.Checked = False
                End If
                Label001.Text = Format(DtView1(0)("reg_date"), "yyyy/MM/dd")
            End If
        End If
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Edit1()   'CLSｺｰﾄﾞ
        msg.Text = Nothing

        Edit1.Text = Trim(Edit1.Text)
        If Edit1.Text = Nothing Then
            Edit1.BackColor = System.Drawing.Color.Red
            msg.Text = "CLSコードが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM CLS_CODE"
            strSQL +=  " WHERE (cls_no = '" & P_PRAM1 & "')"
            strSQL +=  " AND (cls_code = '" & Trim(Edit1.Text) & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "CLS_CODE")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("CLS_CODE"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                Edit1.BackColor = System.Drawing.Color.Red
                msg.Text = "CLSコードが既に登録されています。"
                Exit Sub
            End If
        End If
        Edit1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit001()   'CLS名称
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "CLS名称が入力されていません。"
            Exit Sub
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        If P_PRAM2 = Nothing Then   '新規
            CHK_Edit1() '修理会社コード
            If msg.Text <> Nothing Then Err_F = "1" : Edit1.Focus() : Exit Sub
        End If

        CHK_Edit001() '名前
        If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub

    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.GotFocus
        Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001.GotFocus
        Number001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.GotFocus
        CheckBox001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        CHK_Edit1()     'コード
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '名前
    End Sub
    Private Sub Number001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001.LostFocus
        Number001.BackColor = System.Drawing.SystemColors.Window
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
            If P_PRAM2 = Nothing Then   '新規
                Label001.Text = Now.Date

                strSQL = "INSERT INTO CLS_CODE"
                strSQL +=  " (cls_no, cls_code, cls_code_name, dsp_seq, reg_date, delt_flg)"
                strSQL +=  " VALUES ('" & P_PRAM1 & "'"
                strSQL +=  ", '" & Edit1.Text & "'"
                strSQL +=  ", '" & Trim(Edit001.Text) & "'"
                strSQL +=  ", " & Number001.Value & ""
                strSQL += ", CONVERT(DATETIME, '" & Now & "', 102)"
                If CheckBox001.Checked = True Then strSQL += ", 1)" Else strSQL += ", 0)"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                msg.Text = "登録しました。"
                P_RTN = "1"
                P_PRAM2 = Edit1.Text
                DspSet()    '**  画面セット
            Else                        '修正

                strSQL = "UPDATE CLS_CODE"
                strSQL +=  " SET cls_code_name = '" & Trim(Edit001.Text) & "'"
                strSQL +=  ", dsp_seq = " & Number001.Value & ""
                If CheckBox001.Checked = True Then strSQL +=  ", delt_flg = 1" Else strSQL +=  ", delt_flg = 0"
                strSQL +=  " WHERE (cls_no = '" & P_PRAM1 & "')"
                strSQL +=  " AND (cls_code = '" & P_PRAM2 & "')"
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
