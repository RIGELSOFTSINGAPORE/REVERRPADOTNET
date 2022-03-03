Public Class F10_Form22
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
    Friend WithEvents Button0 As System.Windows.Forms.Button
    Friend WithEvents Edit000 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button0 = New System.Windows.Forms.Button
        Me.Edit000 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button0
        '
        Me.Button0.BackColor = System.Drawing.SystemColors.Control
        Me.Button0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button0.Location = New System.Drawing.Point(168, 24)
        Me.Button0.Name = "Button0"
        Me.Button0.Size = New System.Drawing.Size(28, 20)
        Me.Button0.TabIndex = 1457
        Me.Button0.TabStop = False
        Me.Button0.Text = "？"
        '
        'Edit000
        '
        Me.Edit000.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit000.Format = "A9"
        Me.Edit000.HighlightText = True
        Me.Edit000.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit000.LengthAsByte = True
        Me.Edit000.Location = New System.Drawing.Point(96, 24)
        Me.Edit000.MaxLength = 9
        Me.Edit000.Name = "Edit000"
        Me.Edit000.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit000.Size = New System.Drawing.Size(68, 20)
        Me.Edit000.TabIndex = 1456
        Me.Edit000.Text = "AS1234567"
        Me.Edit000.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit000.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 1458
        Me.Label1.Text = "受付番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(116, 80)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(76, 24)
        Me.Button6.TabIndex = 1776
        Me.Button6.TabStop = False
        Me.Button6.Text = "Hｐ 報告書"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(16, 80)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(76, 24)
        Me.Button5.TabIndex = 1775
        Me.Button5.TabStop = False
        Me.Button5.Text = "IBM 報告書"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(216, 80)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(72, 24)
        Me.Button98.TabIndex = 1774
        Me.Button98.Text = "戻る"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 56)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(276, 16)
        Me.msg.TabIndex = 1777
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F10_Form22
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(306, 120)
        Me.ControlBox = False
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button0)
        Me.Controls.Add(Me.Edit000)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F10_Form22"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IBM/Hｐ報告書"
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F10_Form22_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()

        msg.Text = Nothing
        Edit000.Text = Nothing

    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub F_Check(ByVal btn)
        Err_F = "0"
        msg.Text = Nothing

        Edit000.Text = Trim(Edit000.Text)

        If Edit000.Text = Nothing Then
            Edit000.Focus()
            msg.Text = "受付番号が入力されていません。"
            Err_F = "1" : Exit Sub
        End If

        DsList1.Clear()
        strSQL = "SELECT rcpt_no, vndr_code, comp_date FROM T01_REP_MTR"
        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "T01_REP_MTR")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Edit000.Focus()
            msg.Text = "該当する受付番号がありません。"
            Err_F = "1" : Exit Sub
        Else
            If IsDBNull(DtView1(0)("comp_date")) Then
                Edit000.Focus()
                msg.Text = "完了していません。"
                Err_F = "1" : Exit Sub
            Else
                If btn = "1" Then   'IBM
                    If DtView1(0)("vndr_code") <> "02" Then
                        Edit000.Focus()
                        msg.Text = "IBMの修理品ではありません。"
                        Err_F = "1" : Exit Sub
                    End If
                Else                'HP
                    If DtView1(0)("vndr_code") <> "03" Then
                        Edit000.Focus()
                        msg.Text = "HPの修理品ではありません。"
                        Err_F = "1" : Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit000_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.GotFocus
        Edit000.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit000_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.LostFocus
        Edit000.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '** ？受付番号検索
    '********************************************************************
    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form04 As New F00_Form04
        F00_Form04.ShowDialog()

        If P_RTN = "1" Then
            Edit000.Text = P_PRAM1
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check("1")   '**  項目チェック
        If Err_F = "0" Then
            PRT_PRAM1 = "Print_R_IBM_IW_Report"
            PRT_PRAM2 = Edit000.Text

            Dim Print_View As New Print_View
            Print_View.ShowDialog()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check("2")   '**  項目チェック
        If Err_F = "0" Then
            PRT_PRAM1 = "Print_R_HP_Exc_TAG"
            PRT_PRAM2 = Edit000.Text

            Dim Print_View As New Print_View
            Print_View.ShowDialog()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        Close()
    End Sub
End Class
