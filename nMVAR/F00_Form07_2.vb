Public Class F00_Form07_2
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label000 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label002 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label001 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label000 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Edit002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label002 = New System.Windows.Forms.Label
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Edit001
        '
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Format = "9A"
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(164, 52)
        Me.Edit001.MaxLength = 9
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(112, 24)
        Me.Edit001.TabIndex = 0
        Me.Edit001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Edit001.Visible = False
        '
        'Label001
        '
        Me.Label001.BackColor = System.Drawing.Color.Navy
        Me.Label001.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label001.ForeColor = System.Drawing.Color.White
        Me.Label001.Location = New System.Drawing.Point(64, 52)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(100, 24)
        Me.Label001.TabIndex = 1368
        Me.Label001.Text = "ネバ伝番号"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label001.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 32)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "はい"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(288, 152)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(80, 32)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "いいえ"
        '
        'Label000
        '
        Me.Label000.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label000.Location = New System.Drawing.Point(16, 12)
        Me.Label000.Name = "Label000"
        Me.Label000.Size = New System.Drawing.Size(320, 24)
        Me.Label000.TabIndex = 1372
        Me.Label000.Text = "納品伝票は正常に印刷されましたか。"
        Me.Label000.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 124)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(388, 24)
        Me.msg.TabIndex = 1373
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit002
        '
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.Format = "9A"
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(164, 88)
        Me.Edit002.MaxLength = 9
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(112, 24)
        Me.Edit002.TabIndex = 1
        Me.Edit002.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Edit002.Visible = False
        '
        'Label002
        '
        Me.Label002.BackColor = System.Drawing.Color.Navy
        Me.Label002.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label002.ForeColor = System.Drawing.Color.White
        Me.Label002.Location = New System.Drawing.Point(64, 88)
        Me.Label002.Name = "Label002"
        Me.Label002.Size = New System.Drawing.Size(100, 24)
        Me.Label002.TabIndex = 1375
        Me.Label002.Text = "(ﾘﾍﾞｰﾄ用)"
        Me.Label002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label002.Visible = False
        '
        'F00_Form07_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(414, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label000)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Label001)
        Me.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F00_Form07_2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "印刷確認"
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form07_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msg.Text = Nothing

        Select Case P1_F00_Form07_2
            Case Is = "00"
                Button98_Click(sender, e)
            Case Is = "10"
                Label001.Visible = True
                Edit001.Visible = True
            Case Is = "01"
                Label002.Visible = True
                Edit002.Visible = True
            Case Is = "11"
                Label001.Visible = True
                Edit001.Visible = True
                Label002.Visible = True
                Edit002.Visible = True
        End Select
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Edit001()   'ネバ伝番号
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "ネバ伝番号が入力されていません。"
            Exit Sub
        Else
            DsList1.Clear()
            strSQL = "SELECT sals_no FROM T01_REP_MTR WHERE (sals_no = '" & Edit001.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "T01_REP_MTR")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "ネバ伝番号が既に使用されています。"
                Exit Sub
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit002()   'ネバ伝番号
        msg.Text = Nothing

        Edit002.Text = Trim(Edit002.Text)
        If Edit002.Text = Nothing Then
            Edit002.BackColor = System.Drawing.Color.Red
            msg.Text = "ネバ伝番号(リベート用)が入力されていません。"
            Exit Sub
        Else
            DsList1.Clear()
            strSQL = "SELECT sals_no FROM T01_REP_MTR WHERE (sals_no = '" & Edit002.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "T01_REP_MTR")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Edit002.BackColor = System.Drawing.Color.Red
                msg.Text = "ネバ伝番号が既に使用されています。"
                Exit Sub
            End If
        End If
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        If Edit001.Visible = True Then
            CHK_Edit001()   'ネバ伝番号
            If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub
        End If

        If Edit002.Visible = True Then
            CHK_Edit002()   'ネバ伝番号
            If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub
        End If

        If Edit001.Visible = True Then
            If Edit002.Visible = True Then
                If Edit001.Text = Edit002.Text Then
                    Edit002.BackColor = System.Drawing.Color.Red
                    msg.Text = "ネバ伝番号が同じになっています。。"
                    If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub
                End If
            End If
        End If

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

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   'ネバ伝番号
    End Sub
    Private Sub Edit002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.LostFocus
        CHK_Edit002()   'ネバ伝番号
    End Sub

    '********************************************************************
    '**  はい
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        F_Check()
        If Err_F = "0" Then
            P2_F00_Form07_2 = Edit001.Text
            P3_F00_Form07_2 = Edit002.Text
            'P_PRAM3 = Edit001.Text
            P_RTN = "1"
            Close()
        End If
    End Sub

    '********************************************************************
    '**  いいえ
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_RTN = "2"
        Close()
    End Sub
End Class
