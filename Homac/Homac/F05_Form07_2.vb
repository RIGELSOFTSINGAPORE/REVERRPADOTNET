Public Class F05_Form07_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, WK_str As String
    Dim i, r As Integer

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F05_Form07_2))
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(140, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(464, 24)
        Me.Label4.TabIndex = 1253
        Me.Label4.Text = "Label4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 24)
        Me.Label3.TabIndex = 1252
        Me.Label3.Text = "部門"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(500, 4)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1251
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(412, 4)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1250
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(140, 180)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 1243
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(16, 180)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(124, 24)
        Me.Label52.TabIndex = 1249
        Me.Label52.Text = "削除フラグ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 212)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(596, 24)
        Me.msg.TabIndex = 1248
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 248)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 28)
        Me.Button1.TabIndex = 1244
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(528, 248)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(76, 28)
        Me.Button98.TabIndex = 1245
        Me.Button98.Text = "戻る"
        '
        'Edit03
        '
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(140, 124)
        Me.Edit03.MaxLength = 60
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(460, 24)
        Me.Edit03.TabIndex = 1242
        Me.Edit03.Text = "12"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 24)
        Me.Label2.TabIndex = 1247
        Me.Label2.Text = "クラス名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 24)
        Me.Label1.TabIndex = 1246
        Me.Label1.Text = "クラスコード"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.HighlightText = True
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(140, 96)
        Me.Edit02.MaxLength = 9
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(132, 24)
        Me.Edit02.TabIndex = 1241
        Me.Edit02.Text = "1234"
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(140, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(464, 24)
        Me.Label5.TabIndex = 1255
        Me.Label5.Text = "Label5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 24)
        Me.Label6.TabIndex = 1254
        Me.Label6.Text = "ライン"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 24)
        Me.Label7.TabIndex = 1257
        Me.Label7.Text = "料金表区分"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(140, 152)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(132, 24)
        Me.ComboBox1.TabIndex = 1258
        Me.ComboBox1.Text = "ComboBox1"
        '
        'F05_Form07_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(610, 279)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit02)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F05_Form07_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac クラスマスタメンテ"
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F05_Form07_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        '料金表区分
        strSQL = "SELECT fee_kbn, fee_name"
        strSQL = strSQL & " FROM fee_mtr"
        'strSQL = strSQL & " WHERE (fee_kbn <> 'B')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "fee_mtr")

        ComboBox1.DataSource = DsCMB.Tables("fee_mtr")
        ComboBox1.DisplayMember = "fee_kbn"
        ComboBox1.ValueMember = "fee_kbn"

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 画面セット
    '******************************************************************
    Sub dsp_set()
        Label4.Text = P_PRAM4
        Label5.Text = P_PRAM5

        If P_PRAM3 = Nothing Then   '新規
            Edit02.Enabled = True

            Edit02.Text = Nothing
            Edit03.Text = Nothing
            ComboBox1.Text = Nothing
            Label001.Text = Nothing
            CheckBox001.Checked = False

        Else                        '修正
            Edit02.Enabled = False

            strSQL = "SELECT * FROM cls_mtr"
            strSQL = strSQL & " WHERE (section_code = '" & P_PRAM1 & "')"
            strSQL = strSQL & " AND (line_code = '" & P_PRAM2 & "')"
            strSQL = strSQL & " AND (cls_code = '" & P_PRAM3 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "cls_mtr")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("cls_mtr"), "", "", DataViewRowState.CurrentRows)
            Edit02.Text = DtView1(0)("cls_code")
            Edit03.Text = DtView1(0)("cls_name")
            If Not IsDBNull(DtView1(0)("fee_kbn")) Then ComboBox1.Text = DtView1(0)("fee_kbn") Else ComboBox1.Text = Nothing
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

        If P_PRAM3 = Nothing Then   '新規
            Call CHK_Edit02()       'クラスコード
            If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub
        End If

        Call CHK_Edit03()           'クラス名
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        Call CHK_ComboBox1()        '料金表区分
        If msg.Text <> Nothing Then Err_F = "1" : ComboBox1.Focus() : Exit Sub

        Call CHK_CheckBox001()      '削除フラグ
        If msg.Text <> Nothing Then Err_F = "1" : CheckBox001.Focus() : Exit Sub

    End Sub

    Sub CHK_Edit02()        'クラスコード
        msg.Text = Nothing

        Edit02.Text = Trim(Edit02.Text)
        If Edit02.Text = Nothing Then
            Edit02.BackColor = System.Drawing.Color.Red
            msg.Text = "クラスコードが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM cls_mtr"
            strSQL = strSQL & " WHERE (section_code = '" & P_PRAM1 & "') AND (line_code = '" & P_PRAM2 & "') AND (cls_code = '" & Edit02.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(WK_DsList1, "cls_mtr")
            DB_CLOSE()
            If r <> 0 Then
                Edit02.BackColor = System.Drawing.Color.Red
                msg.Text = "既に登録済みのコードです。"
                Exit Sub
            End If
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit03()        'クラス名
        msg.Text = Nothing

        Edit03.Text = Trim(Edit03.Text)
        If Edit03.Text = Nothing Then
            Edit03.BackColor = System.Drawing.Color.Red
            msg.Text = "クラス名が入力されていません。"
            Exit Sub
        End If
        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_ComboBox1()     '料金表区分
        msg.Text = Nothing

        ComboBox1.Text = Trim(ComboBox1.Text)
        If ComboBox1.Text = Nothing Then
            ComboBox1.BackColor = System.Drawing.Color.Red
            msg.Text = "料金表区分が選択されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("fee_mtr"), "fee_kbn = '" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                ComboBox1.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する料金表区分がありません。"
                Err_F = "1" : Exit Sub
            End If
        End If
        ComboBox1.BackColor = System.Drawing.SystemColors.Window
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

            If P_PRAM3 = Nothing Then   '新規
                Label001.Text = Now.Date

                strSQL = "INSERT INTO cls_mtr"
                strSQL = strSQL & " (section_code, line_code, cls_code, cls_name, fee_kbn, reg_date, delt_flg)"
                strSQL = strSQL & " VALUES ('" & P_PRAM1 & "'"
                strSQL = strSQL & ", '" & P_PRAM2 & "'"
                strSQL = strSQL & ", '" & Edit02.Text & "'"
                strSQL = strSQL & ", '" & Edit03.Text & "'"
                strSQL = strSQL & ", '" & ComboBox1.Text & "'"
                strSQL = strSQL & ", '" & CDate(Label001.Text) & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", 1)" Else strSQL = strSQL & ", 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            Else                        '修正

                strSQL = "UPDATE cls_mtr"
                strSQL = strSQL & " SET cls_name = '" & Edit03.Text & "'"
                strSQL = strSQL & ", fee_kbn = '" & ComboBox1.Text & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", delt_flg = 1" Else strSQL = strSQL & ", delt_flg = 0"
                strSQL = strSQL & " WHERE (section_code = '" & P_PRAM1 & "')"
                strSQL = strSQL & " AND (line_code = '" & P_PRAM2 & "')"
                strSQL = strSQL & " AND (cls_code = '" & P_PRAM3 & "')"
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
        Call CHK_Edit02()       'クラスコード
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CHK_Edit03()       'クラス名
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        Call CHK_CheckBox001()  '削除フラグ
    End Sub
    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.LostFocus
        Call CHK_ComboBox1()    '料金表区分
    End Sub
End Class
