Public Class F00_Form09
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsCMB As New DataSet
    Dim WK_DtView1 As DataView

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Combo1 As GrapeCity.Win.Input.Combo
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Combo1 = New GrapeCity.Win.Input.Combo
        Me.msg = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(420, 48)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(68, 32)
        Me.Button99.TabIndex = 7
        Me.Button99.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(340, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "決定"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "０円理由"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo1
        '
        Me.Combo1.AutoSelect = True
        Me.Combo1.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo1.Location = New System.Drawing.Point(96, 16)
        Me.Combo1.MaxDropDownItems = 30
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo1.Size = New System.Drawing.Size(396, 24)
        Me.Combo1.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo1.TabIndex = 5
        Me.Combo1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo1.Value = "Combo1"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 52)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(312, 28)
        Me.msg.TabIndex = 1703
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(428, 4)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(63, 16)
        Me.CL001.TabIndex = 1708
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'F00_Form09
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(502, 96)
        Me.ControlBox = False
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Combo1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form09"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "\0理由"
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form09_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msg.Text = Nothing
        CMB_SET() '** コンボボックスセット
    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CMB_SET()
        DsCMB.Clear()

        '理由
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '023') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "CLS_CODE_023")
        DB_CLOSE()

        Combo1.DataSource = DsCMB.Tables("CLS_CODE_023")
        Combo1.DisplayMember = "cls_code_name"
        Combo1.ValueMember = "cls_code"

        CL001.Text = P_PRAM1
        If P_PRAM1 = Nothing Then
            Combo1.Text = P_PRAM2
        Else
            Combo1.Text = P_PRAM2
        End If

    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Combo1()   '理由
        msg.Text = Nothing
        CL001.Text = Nothing

        Combo1.Text = Trim(Combo1.Text)
        If Combo1.Text = Nothing Then
            Combo1.BackColor = System.Drawing.Color.Red
            msg.Text = "理由が入力されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("CLS_CODE_023"), "cls_code_name = '" & Combo1.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                'Combo1.BackColor = System.Drawing.Color.Red
                'msg.Text = "該当する理由がありません。"
                'Exit Sub
            Else
                CL001.Text = WK_DtView1(0)("cls_code")
            End If
        End If
        Combo1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        CHK_Combo1()   '理由
        If msg.Text <> Nothing Then Err_F = "1" : Combo1.Focus() : Exit Sub

    End Sub
    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Combo1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo1.GotFocus
        Combo1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo1.LostFocus
        CHK_Combo1()   '理由
    End Sub

    '********************************************************************
    '**  決定
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        F_Check()   '**  項目チェック
        If Err_F = "0" Then
            P_RTN = "1"
            P_PRAM1 = CL001.Text
            P_PRAM2 = Combo1.Text
            DsCMB.Clear()
            Close()
        End If
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        P_RTN = "0"
        DsCMB.Clear()
        Close()
    End Sub
End Class
