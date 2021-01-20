Public Class Menu
    Inherits System.Windows.Forms.Form

    Private objMutex As System.Threading.Mutex

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(240, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 43)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "入力フォーム"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(240, 139)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(160, 43)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "修正フォーム"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(240, 260)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(160, 43)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "終  了"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 24.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.PaleTurquoise
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 43)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "SAFETY FIVE"
        '
        'Button4
        '
        Me.Button4.ForeColor = System.Drawing.Color.Red
        Me.Button4.Location = New System.Drawing.Point(40, 78)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(160, 26)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "特別修正フォーム" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Special correction form"
        Me.Button4.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 295)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Ver.2.0"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button5.Location = New System.Drawing.Point(240, 199)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(160, 44)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "件数確認"
        '
        'Menu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(464, 365)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "延長保証データ入力"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_input")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If

    End Sub

    '入力フォーム
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim Form1 As New Form1
        Form1.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '修正フォーム
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim Form2 As New Form2_seq
        Form2.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Application.Exit()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '特別修正フォーム
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim Form3 As New Form3
        Form3.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim strSQL As String
        strSQL = "SELECT Wrn_mtr.corp_flg, COUNT(Input_Seq.ordr_no) AS CNT"
        strSQL += " FROM Input_Seq INNER JOIN Wrn_mtr ON Input_Seq.ordr_no = Wrn_mtr.ordr_no"
        strSQL += " GROUP BY Wrn_mtr.corp_flg"

        Dim SqlSelectCommand As New SqlClient.SqlCommand
        SqlSelectCommand = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dim daItem As New SqlClient.SqlDataAdapter
        daItem.SelectCommand = SqlSelectCommand

        Dim dsItem As New DataSet
        DB_OPEN("best_wrn")
        SqlSelectCommand.CommandTimeout = 600
        daItem.Fill(dsItem, "CNT")
        DB_CLOSE()

        Dim dttbl As DataTable
        dttbl = dsItem.Tables("CNT")

        Dim i, x1, y1 As Integer
        For i = 0 To dttbl.Rows.Count - 1
            If dttbl.Rows(i)("corp_flg") = "1" Then
                x1 = dttbl.Rows(i)("CNT")    '法人件数
            Else
                y1 = y1 + dttbl.Rows(i)("CNT")  '個人件数
            End If
        Next

        dsItem.Clear()
        strSQL = "SELECT Wrn_mtr.corp_flg, COUNT(Input_Seq.ordr_no) AS CNT"
        strSQL += " FROM Input_Seq INNER JOIN Wrn_mtr ON Input_Seq.ordr_no = Wrn_mtr.ordr_no INNER JOIN Wrn_sub ON Input_Seq.ordr_no = Wrn_sub.ordr_no"
        strSQL += " GROUP BY Wrn_mtr.corp_flg"

        SqlSelectCommand = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dim daItem2 As New SqlClient.SqlDataAdapter
        daItem2.SelectCommand = SqlSelectCommand


        DB_OPEN("best_wrn")
        SqlSelectCommand.CommandTimeout = 600
        daItem2.Fill(dsItem, "CNT")
        DB_CLOSE()

        Dim x2, y2 As Integer

        For i = 0 To dttbl.Rows.Count - 1
            If dttbl.Rows(i)("corp_flg") = "1" Then
                x2 = dttbl.Rows(i)("CNT")    '法人行数
            Else
                y2 = y2 + dttbl.Rows(i)("CNT")  '個人行数
            End If
        Next

        MessageBox.Show("現在登録されている件数は下記の通りです。" & vbCrLf & vbCrLf & "個人：" & y1 & "件   " & y2 & "行" & vbCrLf & "法人：" & x1 & "件   " & x2 & "行", "登録件数確認", MessageBoxButtons.OK)

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


End Class
