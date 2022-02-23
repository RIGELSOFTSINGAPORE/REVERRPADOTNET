Imports GrapeCity.Win.Input.Interop

Public Class F05_Form02_2
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
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F05_Form02_2))
        Me.Label001 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.CheckBox001 = New System.Windows.Forms.CheckBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.msg = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button98 = New System.Windows.Forms.Button()
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Ime1 = New GrapeCity.Win.Input.Interop.Ime()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(496, 7)
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
        Me.Label51.Location = New System.Drawing.Point(408, 7)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1212
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(136, 108)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 3
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(12, 108)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(124, 24)
        Me.Label52.TabIndex = 1211
        Me.Label52.Text = "削除フラグ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(4, 140)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(596, 24)
        Me.msg.TabIndex = 1210
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(4, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 28)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(524, 176)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(76, 28)
        Me.Button98.TabIndex = 5
        Me.Button98.Text = "戻る"
        '
        'Edit04
        '
        Me.Edit04.HighlightText = True
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(136, 80)
        Me.Edit04.MaxLength = 60
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Size = New System.Drawing.Size(460, 24)
        Me.Edit04.TabIndex = 2
        Me.Edit04.Text = "1234567890123456789012345678901234567890"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit03
        '
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(136, 52)
        Me.Edit03.MaxLength = 60
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Size = New System.Drawing.Size(460, 24)
        Me.Edit03.TabIndex = 1
        Me.Edit03.Text = "12"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 24)
        Me.Label3.TabIndex = 1204
        Me.Label3.Text = "メーカー名（カナ）"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 24)
        Me.Label2.TabIndex = 1203
        Me.Label2.Text = "メーカー名（漢字）"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 24)
        Me.Label1.TabIndex = 1201
        Me.Label1.Text = "メーカーコード"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.HighlightText = True
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(136, 24)
        Me.Edit02.MaxLength = 9
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Size = New System.Drawing.Size(132, 24)
        Me.Edit02.TabIndex = 0
        Me.Edit02.Text = "1234"
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Ime1
        '
        '
        'F05_Form02_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(610, 211)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit02)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F05_Form02_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac メーカーマスタメンテ"
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F05_Form02_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Label001.Text = Nothing
            CheckBox001.Checked = False

        Else                        '修正
            Edit02.Enabled = False

            strSQL = "SELECT * FROM vdr_mtr WHERE (vdr_code = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "vdr_mtr")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("vdr_mtr"), "", "", DataViewRowState.CurrentRows)
            Edit02.Text = DtView1(0)("vdr_code")
            Edit03.Text = DtView1(0)("vdr_name")
            Edit04.Text = DtView1(0)("vdr_name_kana")
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
            Call CHK_Edit02()       'メーカーコード
            If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub
        End If

        Call CHK_Edit03()           'メーカー名（漢字）
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        Call CHK_Edit04()           'メーカー名（カナ）
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        Call CHK_CheckBox001()      '削除フラグ
        If msg.Text <> Nothing Then Err_F = "1" : CheckBox001.Focus() : Exit Sub

    End Sub

    Sub CHK_Edit02()        'メーカーコード
        msg.Text = Nothing

        Edit02.Text = Trim(Edit02.Text)
        If Edit02.Text = Nothing Then
            Edit02.BackColor = System.Drawing.Color.Red
            msg.Text = "メーカーコードが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM vdr_mtr WHERE (vdr_code = '" & Edit02.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(WK_DsList1, "vdr_mtr")
            DB_CLOSE()
            If r <> 0 Then
                Edit02.BackColor = System.Drawing.Color.Red
                msg.Text = "既に登録済みのコードです。"
                Exit Sub
            End If
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit03()        'メーカー名（漢字）
        msg.Text = Nothing

        Edit03.Text = Trim(Edit03.Text)
        If Edit03.Text = Nothing Then
            Edit03.BackColor = System.Drawing.Color.Red
            msg.Text = "メーカー名（漢字）が入力されていません。"
            Exit Sub
        End If
        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit04()        'メーカー名（カナ）
        msg.Text = Nothing

        Edit04.Text = Trim(Edit04.Text)
        If Edit04.Text = Nothing Then
            Edit04.BackColor = System.Drawing.Color.Red
            msg.Text = "メーカー名（カナ）が入力されていません。"
            Exit Sub
        End If
        Edit04.BackColor = System.Drawing.SystemColors.Window
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

                strSQL = "INSERT INTO vdr_mtr"
                strSQL = strSQL & " (vdr_code, vdr_name, vdr_name_kana, reg_date, delt_flg)"
                strSQL = strSQL & " VALUES ('" & Edit02.Text & "'"
                strSQL = strSQL & ", '" & Edit03.Text & "'"
                strSQL = strSQL & ", '" & Edit04.Text & "'"
                strSQL = strSQL & ", '" & CDate(Label001.Text) & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", 1)" Else strSQL = strSQL & ", 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            Else                        '修正

                strSQL = "UPDATE vdr_mtr"
                strSQL = strSQL & " SET vdr_name = '" & Edit03.Text & "'"
                strSQL = strSQL & ", vdr_name_kana = '" & Edit04.Text & "'"
                If CheckBox001.Checked = True Then strSQL = strSQL & ", delt_flg = 1" Else strSQL = strSQL & ", delt_flg = 0"
                strSQL = strSQL & " WHERE (vdr_code = '" & P_PRAM1 & "')"
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

    Private Sub Ime1_ResultString(sender As Object, e As ResultStringEventArgs) Handles Ime1.ResultString
        ' 取得したふりがなを表示します。
        Edit04.Text += e.ReadString
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CHK_Edit02()       'メーカーコード
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CHK_Edit03()       'メーカー名（漢字）
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Call CHK_Edit04()       'メーカー名（カナ）
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        Call CHK_CheckBox001()  '削除フラグ
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    'version issue 20200805. created Ime1 object
    'Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana.ResultString
    '    ' 取得したふりがなを表示します。
    '    Edit04.Text += e.ReadString
    'End Sub
End Class
