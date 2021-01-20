Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WKDsList As New DataSet
    Dim DtView1 As DataView

    Private objMutex As System.Threading.Mutex
    Dim strSQL, str_ANS As String

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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.Maroon
        Me.Button99.Location = New System.Drawing.Point(384, 144)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(96, 40)
        Me.Button99.TabIndex = 30
        Me.Button99.Text = "終了"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(224, 32)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "取込みデータの締め処理戻し"
        'Me.Button1.Text = "Returning the closing process of the captured data"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(24, 88)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(224, 32)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "手入力データの締め処理戻し"
        'Me.Button2.Text = "Manual input data closing process return"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(256, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 32)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(256, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 32)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Label4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label1.Location = New System.Drawing.Point(248, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label2.Location = New System.Drawing.Point(248, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(490, 199)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請求締め処理戻し Ver 2.0"
        'Me.Text = "Invoice closing process Ver 2.0"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '起動時
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_ivc_close_return")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
            Exit Sub
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call DB_INIT()
        Call DsSet()
        Call DspSet()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub DsSet()
        DB_OPEN("best_wrn")

        '区分
        strSQL = "SELECT * FROM CLS_CODE WHERE (CLS_NO = '999')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3000
        DaList1.Fill(DsList1, "CLS_CODE")
        DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_CODE='0'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label1.Text = DtView1(0)("CLS_CODE_NAME")
            Label3.Text = Format(CDate(Label1.Text), "yyyy年MM月度")
        End If
        DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_CODE='1'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label2.Text = DtView1(0)("CLS_CODE_NAME")
            Label4.Text = Format(CDate(Label2.Text), "yyyy年MM月度")
        End If

        '請求データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_best_ivc_close_return_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = Label1.Text
        SqlCmd1.CommandTimeout = 3000
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Wrn_ivc1")

        SqlCmd1 = New SqlClient.SqlCommand("sp_best_ivc_close_return_02", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram2.Value = Label2.Text
        SqlCmd1.CommandTimeout = 3000
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Wrn_ivc2")

        DB_CLOSE()
    End Sub

    Sub DspSet()

        DtView1 = New DataView(DsList1.Tables("Wrn_ivc1"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label3.Text = Label3.Text & "  (" & Format(DtView1(0)("cnt"), "##,##0") & "件)"
        Else
            Label3.Text = Label3.Text & "  (0件)"
            Button1.Enabled = False
        End If

        DtView1 = New DataView(DsList1.Tables("Wrn_ivc2"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label4.Text = Label4.Text & "  (" & Format(DtView1(0)("cnt"), "##,##0") & "件)"
        Else
            Label4.Text = Label4.Text & "  (0件)"
            Button2.Enabled = False
        End If

    End Sub

    '**********************************
    '取込みデータの締め処理戻しボタン
    '**********************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        str_ANS = MsgBox("取込みデータの締め処理戻しを行います。よろしいですか？", MsgBoxStyle.OKCancel, "確認")
        If str_ANS = "1" Then   'OK
            DB_OPEN("best_wrn")

            strSQL = "UPDATE Wrn_ivc"
            strSQL = strSQL & " SET close_flg = '0'"
            strSQL = strSQL & " WHERE (close_flg = '1') AND (inp_seq IS NULL)"
            strSQL = strSQL & " AND (close_date = CONVERT(DATETIME, '" & Label1.Text & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE CLS_CODE"
            strSQL = strSQL & " SET CLS_CODE_NAME = '" & DateAdd(DateInterval.Month, -1, CDate(Label1.Text)) & "'"
            strSQL = strSQL & " WHERE (CLS_NO = '999') AND (CLS_CODE = '0')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            DB_CLOSE()
            MsgBox("締め処理を戻しました。", MsgBoxStyle.Information, "終了")
            Button1.Enabled = False
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '手入力データの締め処理戻しボタン
    '**********************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        str_ANS = MsgBox("手入力データの締め処理戻しを行います。よろしいですか？", MsgBoxStyle.OKCancel, "確認")
        If str_ANS = "1" Then   'OK
            DB_OPEN("best_wrn")

            strSQL = "UPDATE Wrn_ivc"
            strSQL = strSQL & " SET close_flg = '0'"
            strSQL = strSQL & " WHERE (close_flg = '1') AND (inp_seq IS NOT NULL)"
            strSQL = strSQL & " AND (close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE CLS_CODE"
            strSQL = strSQL & " SET CLS_CODE_NAME = '" & DateAdd(DateInterval.Month, -1, CDate(Label2.Text)) & "'"
            strSQL = strSQL & " WHERE (CLS_NO = '999') AND (CLS_CODE = '1')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            DB_CLOSE()
            MsgBox("締め処理を戻しました。", MsgBoxStyle.Information, "終了")
            Button2.Enabled = False
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '終了ボタン
    '**********************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub
End Class
