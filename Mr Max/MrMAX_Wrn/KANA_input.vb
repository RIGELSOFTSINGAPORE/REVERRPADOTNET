Public Class KANA_input
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "フリガナ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.TextBox1.Location = New System.Drawing.Point(112, 32)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(256, 23)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TextBox1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(200, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 32)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "登録"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(296, 80)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 32)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "戻る"
        '
        'KANA_input
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(392, 127)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "KANA_input"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ﾌﾘｶﾞﾅ入力"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************
    '** 起動時
    '******************************************
    Private Sub KANA_input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = pKANA
    End Sub

    '******************************************
    '** 登録
    '******************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Trim(TextBox1.Text) = Nothing Then
            MsgBox("フリガナを入力してください。", MsgBoxStyle.Critical, "Error")
            TextBox1.Focus()
        Else
            If Trim(TextBox1.Text) <> pKANA Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET CUST_NAME_KANA = '" & TextBox1.Text & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & pWrn_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                strSQL = "INSERT INTO WRN_DATA_UPD"
                strSQL = strSQL & " (WRN_NO, UPD_ITEM, UPD_DATE, EMPL_CODE, ITEM_CLS, ORG_ITEM, UPD_RSN)"
                strSQL = strSQL & " VALUES ('" & pWrn_no & "'"
                strSQL = strSQL & ", '" & TextBox1.Text & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Now & "', 102)"
                strSQL = strSQL & ", '" & pEmpl_code & "'"
                strSQL = strSQL & ", '009'"
                strSQL = strSQL & ", '" & pKANA & "'"
                strSQL = strSQL & ", '')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                pKANA = TextBox1.Text
            End If
            Me.Close()
        End If
    End Sub

    '******************************************
    '** 戻る
    '******************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        pKANA = Nothing
        Me.Close()
    End Sub
End Class
