Public Class F00_Form01
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsCMB As New DataSet
    Dim DtView1 As DataView

    Dim strSQL As String

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
    Friend WithEvents Combo1 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Combo1 = New GrapeCity.Win.Input.Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Combo1
        '
        Me.Combo1.AutoSelect = True
        Me.Combo1.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo1.Location = New System.Drawing.Point(92, 24)
        Me.Combo1.MaxDropDownItems = 25
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo1.Size = New System.Drawing.Size(356, 24)
        Me.Combo1.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo1.TabIndex = 0
        Me.Combo1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo1.Value = "Combo1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "部署："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(300, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "決定"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(380, 64)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(68, 32)
        Me.Button99.TabIndex = 2
        Me.Button99.Text = "戻る"
        '
        'F00_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(466, 104)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Combo1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F00_Form01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部署選択"
        Me.TopMost = True
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CMB_SET() '** コンボボックスセット
    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CMB_SET()
        DsCMB.Clear()

        '部署
        strSQL = "SELECT M03_BRCH.brch_code, RTRIM(M03_BRCH.brch_code) + ':' + M03_BRCH.name AS name, M03_BRCH.area_code, M06_RPAR_COMP.rpar_comp_code"
        strSQL += " FROM M03_BRCH LEFT OUTER JOIN M06_RPAR_COMP ON M03_BRCH.brch_code = M06_RPAR_COMP.brch_code"
        strSQL += " WHERE (M03_BRCH.comp_code = '" & P_comp_code & "')"
        If P_full = "False" Then
            strSQL += " AND (M03_BRCH.full_cntl = 0)"
        End If
        strSQL += " AND (M03_BRCH.delt_flg = 0)"
        strSQL += " ORDER BY M03_BRCH.name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "M03_BRCH")
        DB_CLOSE()

        Combo1.DataSource = DsCMB.Tables("M03_BRCH")
        Combo1.DisplayMember = "name"
        Combo1.ValueMember = "brch_code"
        DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_code = '" & P_EMPL_BRCH & "'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Combo1.Text = DtView1(0)("name")
        End If
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
        Combo1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  決定
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Check
        DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "name = '" & Combo1.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            P_EMPL_BRCH = Mid(Combo1.Text, 1, 2)
            P_EMPL_BRCH_name = Trim(Mid(Combo1.Text, 4, 50))
            P_area_code = DtView1(0)("area_code")
            If Not IsDBNull(DtView1(0)("rpar_comp_code")) Then P_rpar_comp_code = DtView1(0)("rpar_comp_code") Else P_rpar_comp_code = Nothing
            DsCMB.Clear()
            Close()
        Else
            Combo1.Focus()
            MessageBox.Show("部署の入力に誤りがあります。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsCMB.Clear()
        Close()
    End Sub
End Class
