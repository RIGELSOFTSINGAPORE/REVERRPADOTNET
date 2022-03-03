Public Class F00_Form06
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsCMB As New DataSet
    Friend WithEvents Combo1 As ComboBox
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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button99 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(525, 58)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(85, 39)
        Me.Button99.TabIndex = 2
        Me.Button99.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(425, 58)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "決定"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 29)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "コメント："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo1
        '
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(127, 19)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(483, 31)
        Me.Combo1.TabIndex = 5
        '
        'F00_Form06
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 23)
        Me.ClientSize = New System.Drawing.Size(643, 128)
        Me.ControlBox = False
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form06"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "コメント選択"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form06_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CMB_SET() '** コンボボックスセット
    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CMB_SET()
        DsCMB.Clear()

        'コメント
        strSQL = "SELECT cmnt_code, cmnt, cls_name"
        strSQL = strSQL & " FROM M10_CMNT"
        strSQL = strSQL & " WHERE (delt_flg = 0) AND (cls_code = '" & P_PRAM1 & "')"
        strSQL = strSQL & " ORDER BY cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "M10_CMNT")
        DB_CLOSE()

        Combo1.DataSource = DsCMB.Tables("M10_CMNT")
        Combo1.DisplayMember = "cmnt"
        Combo1.ValueMember = "cmnt_code"
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Combo1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  決定
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        P_RTN = "1"
        P_PRAM1 = Trim(Combo1.Text)
        DsCMB.Clear()
        Close()
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
