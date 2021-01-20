Public Class Form1
    Inherits System.Windows.Forms.Form

    Private objMutex As System.Threading.Mutex

    Dim SqlCmd1 As New SqlClient.SqlCommand
    Dim DaList1 As New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, str_ANS, Err_F As String
    Dim WK_close_date As Date
    Dim i, r, r1, r2 As Integer

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label



    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(32, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "締め戻し"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(192, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label2.Visible = False
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(232, 152)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 32)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "終了"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(144, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 32)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(144, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 32)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Label4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(32, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 32)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "ベスト分： "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(32, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 32)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "オール電化分： "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(32, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 32)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(192, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Label5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(330, 199)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入締め処理 戻し Var 2.0"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_close_return")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        DB_INIT()
        DB_OPEN()
        DsList1.Clear()
        Button1.Enabled = False

        '締月セット
        strSQL = "SELECT * FROM CLS_CODE WHERE (CLS_NO = '999')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3000
        DaList1.Fill(DsList1, "CLS_CODE")
        DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_CODE='2'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label2.Text = Trim(DtView1(0)("CLS_CODE_NAME"))
            Button1.Enabled = True
            Label1.Text = Format(CDate(Label2.Text), "yyyy/MM") 'VJ 2020/09/16
            Label5.Text = DateAdd(DateInterval.Day, -1, CDate(Format(CDate(Label2.Text), "yyyy/MM") & "/01"))
        End If
        'Label1.Text = DateTime.Now
        'Label5.Text = DateTime.Now
        'Label1.Text = Format(CDate(Label2.Text), "yyyy/MM") 'VJ 2020/09/16
        'Label5.Text = DateAdd(DateInterval.Day, -1, CDate(Format(CDate(Label2.Text), "yyyy/MM") & "/01"))

        '対象件数
        'ALL8
        strSQL = "SELECT ordr_no, line_no, seq, close_date, cxl_close_date"
        strSQL += " FROM All8_Wrn_sub"
        strSQL += " WHERE (close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
        strSQL += " OR (cxl_close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r1 = DaList1.Fill(DsList1, "All8_Wrn_sub")
        'BEST
        strSQL = "SELECT ordr_no, line_no, seq, close_date, cxl_close_date"
        strSQL += " FROM Wrn_sub"
        strSQL += " WHERE (close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
        strSQL += " OR (cxl_close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r2 = DaList1.Fill(DsList1, "Wrn_sub")

        If r1 <> 0 Then
            Label3.Text = Format(r1, "##,##0") & " 件"
        Else
            Label3.Text = "0 件"
        End If

        If r2 <> 0 Then
            Label4.Text = Format(r2, "##,##0") & " 件"
        Else
            Label4.Text = "0 件"
        End If

        If r1 + r2 <> 0 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If

        DB_CLOSE()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        str_ANS = MsgBox("加入データの締め処理戻しを行います。よろしいですか？", MsgBoxStyle.OKCancel, "確認")
        If str_ANS = "1" Then   'OK

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            DB_OPEN()

            strSQL = "UPDATE All8_Wrn_sub"
            strSQL = strSQL & " SET close_date = NULL"
            strSQL = strSQL & ", close_cont_flg = NULL"
            strSQL = strSQL & " WHERE (close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 3600
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE All8_Wrn_sub"
            strSQL = strSQL & " SET cxl_close_date = NULL"
            strSQL = strSQL & " WHERE (cxl_close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 3600
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE CLS_CODE"
            strSQL = strSQL & " SET CLS_CODE_NAME = '" & Label5.Text & "'"
            strSQL = strSQL & " WHERE (CLS_NO = '999') AND (CLS_CODE = '2')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE Wrn_sub"
            strSQL = strSQL & " SET close_date = NULL"
            strSQL = strSQL & ", close_cont_flg = NULL"
            strSQL = strSQL & " WHERE (close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 3600
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE Wrn_sub"
            strSQL = strSQL & " SET cxl_close_date = NULL"
            strSQL = strSQL & " WHERE (cxl_close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 3600
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE CLS_CODE"
            strSQL = strSQL & " SET CLS_CODE_NAME = '" & Label5.Text & "'"
            strSQL = strSQL & " WHERE (CLS_NO = '999') AND (CLS_CODE = '3')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            DB_CLOSE()
            Button1.Enabled = False
            MsgBox("締め処理を戻しました。", MsgBoxStyle.Information, "終了")
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()  '終了
    End Sub
End Class
