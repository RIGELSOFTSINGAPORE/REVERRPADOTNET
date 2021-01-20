Public Class menu1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter

    Dim DsList1 As New DataSet
    Dim WK_DsList1 As New DataSet

    Dim DtView1 As DataView
    Dim WK_DtView1 As DataView

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(menu1))
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Button99.Location = New System.Drawing.Point(488, 248)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 40)
        Me.Button99.TabIndex = 99
        Me.Button99.Text = "終了"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(48, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 40)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "ﾍﾞｽﾄ電器振込分"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "月処理分"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label2.Location = New System.Drawing.Point(240, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy.MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy.MM", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(24, 16)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(96, 32)
        Me.Date1.TabIndex = 10
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 24, 11, 17, 5, 0))
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(232, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 40)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "ﾍﾞｽﾄｻｰﾋﾞｽ振込分"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(416, 104)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(144, 40)
        Me.Button3.TabIndex = 40
        Me.Button3.Text = "ｶｺｲｴﾚｸﾄﾛ振込分"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(24, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(568, 152)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "セーフティ５ 支払報告書"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(48, 166)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(144, 42)
        Me.Button4.TabIndex = 108
        Me.Button4.Text = "ﾍﾞｽﾄ電器振込分 営業所毎"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(236, 166)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(144, 40)
        Me.Button5.TabIndex = 109
        Me.Button5.Text = "ﾍﾞｽﾄｻｰﾋﾞｽ振込分 営業所毎"
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(416, 168)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(144, 40)
        Me.Button6.TabIndex = 110
        Me.Button6.Text = "ｶｺｲｴﾚｸﾄﾛ振込分 営業所毎"
        '
        'menu1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(616, 303)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "menu1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請求レポート Var 2.0"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************
    '起動時
    '**********************************
    Private Sub menu1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_ivc_report")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If

        Call DB_INIT()
        Call DsSet()
        Call DateSet()

    End Sub

    Sub DsSet()
        DB_OPEN("best_wrn")

        '区分
        strSQL = "SELECT CLS_CODE.*"
        strSQL = strSQL & " FROM CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "CLS_CODE")

        DB_CLOSE()
    End Sub

    Sub DateSet()
        WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_NO='999'", "CLS_CODE_NAME", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            Label2.Text = DateAdd(DateInterval.Month, 1, CDate(WK_DtView1(0)("CLS_CODE_NAME")))

        Else
            Label2.Text = Year(Now) & "/" & Month(Now) & "/20"
        End If
        Date1.Text = Format(CDate(Label2.Text), "yyyy.MM")
    End Sub

    '入力後
    Private Sub Date1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.Leave
        Label2.Text = Mid(Date1.Text, 1, 4) & "/" & Mid(Date1.Text, 6, 2) & "/20"
    End Sub

    '*********************************************
    '動産保険金支払報告書(ﾍﾞｽﾄ電器振込分)ボタン
    '*********************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SearchForThis As String = "_"
        Dim FirstCharacter As Integer = Label2.Text.IndexOf(SearchForThis)
        If Label2.Text = "____/__/20" Or FirstCharacter <> -1 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
            Exit Sub
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        WK_DsList1.Clear()
        'strSQL = "select 会社GRP from Shop_mtr"
        strSQL = "SELECT Shop_mtr.会社GRP"
        strSQL = strSQL & " FROM Wrn_ivc INNER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (Wrn_ivc.Cancel_flg = '0')"
        strSQL = strSQL & " AND (Shop_mtr.会社GRP <> 98)"
        strSQL = strSQL & " AND (Shop_mtr.会社GRP <> 203)"
        strSQL = strSQL & " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & CDate(Label2.Text) & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1

        Try
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(WK_DsList1, "Wrn_ivc")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show("該当データはありません。")
            DB_CLOSE()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        DtView1 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
        Else

            P_Date = CDate(Label2.Text)
            P_Flg = "1"
            Dim frmform1 As New Form1P
            frmform1.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************
    '動産保険金支払報告書(ﾍﾞｽﾄｻｰﾋﾞｽ振込分)ボタン
    '*********************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim SearchForThis As String = "_"
        Dim FirstCharacter As Integer = Label2.Text.IndexOf(SearchForThis)
        If Label2.Text = "____/__/20" Or FirstCharacter <> -1 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
            Exit Sub
        End If
        WK_DsList1.Clear()
        strSQL = "SELECT Shop_mtr.会社GRP"
        strSQL = strSQL & " FROM Wrn_ivc INNER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (Wrn_ivc.Cancel_flg = '0')"
        strSQL = strSQL & " AND (Shop_mtr.会社GRP = 98)"
        strSQL = strSQL & " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & CDate(Label2.Text) & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1

        Try
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(WK_DsList1, "Wrn_ivc")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show("該当データはありません。")
            DB_CLOSE()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        DtView1 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
        Else

            P_Date = CDate(Label2.Text)
            P_Flg = "2"
            Dim frmform1 As New Form1P
            frmform1.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************
    '動産保険金支払報告書(ｶｺｲｴﾚｸﾄﾛ振込分)ボタン
    '*********************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim SearchForThis As String = "_"
        Dim FirstCharacter As Integer = Label2.Text.IndexOf(SearchForThis)
        If Label2.Text = "____/__/20" Or FirstCharacter <> -1 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
            Exit Sub
        End If
        WK_DsList1.Clear()
        strSQL = "SELECT Shop_mtr.会社GRP"
        strSQL = strSQL & " FROM Wrn_ivc INNER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (Wrn_ivc.Cancel_flg = '0')"
        strSQL = strSQL & " AND (Shop_mtr.会社GRP = 203)"
        strSQL = strSQL & " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & CDate(Label2.Text) & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1

        Try
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(WK_DsList1, "Wrn_ivc")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show("該当データはありません。")
            DB_CLOSE()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        DtView1 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
        Else

            P_Date = CDate(Label2.Text)
            P_Flg = "3"
            Dim frmform1 As New Form1P
            frmform1.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************
    '動産保険金支払報告書＿営業所毎(ﾍﾞｽﾄ電器振込分)ボタン
    '**********************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim SearchForThis As String = "_"
        Dim FirstCharacter As Integer = Label2.Text.IndexOf(SearchForThis)
        If Label2.Text = "____/__/20" Or FirstCharacter <> -1 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
            Exit Sub
        End If
        WK_DsList1.Clear()
        strSQL = "SELECT Shop_mtr.会社GRP"
        strSQL = strSQL & " FROM Wrn_ivc INNER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (Wrn_ivc.Cancel_flg = '0')"
        strSQL = strSQL & " AND (Shop_mtr.会社GRP <> 98)"
        strSQL = strSQL & " AND (Shop_mtr.会社GRP <> 203)"
        strSQL = strSQL & " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & CDate(Label2.Text) & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1

        Try
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(WK_DsList1, "Wrn_ivc")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show("該当データはありません。")
            DB_CLOSE()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        DtView1 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
        Else

            P_Date = CDate(Label2.Text)
            P_Flg = "4"
            Dim frmform1 As New Form1P
            frmform1.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************
    '動産保険金支払報告書＿営業所毎(ﾍﾞｽﾄｻｰﾋﾞｽ振込分)ボタン
    '**********************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim SearchForThis As String = "_"
        Dim FirstCharacter As Integer = Label2.Text.IndexOf(SearchForThis)
        If Label2.Text = "____/__/20" Or FirstCharacter <> -1 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
            Exit Sub
        End If
        WK_DsList1.Clear()
        strSQL = "SELECT Shop_mtr.会社GRP"
        strSQL = strSQL & " FROM Wrn_ivc INNER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (Wrn_ivc.Cancel_flg = '0')"
        strSQL = strSQL & " AND (Shop_mtr.会社GRP = 98)"
        strSQL = strSQL & " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & CDate(Label2.Text) & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1

        Try
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(WK_DsList1, "Wrn_ivc")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show("該当データはありません。")
            DB_CLOSE()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        DtView1 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
        Else

            P_Date = CDate(Label2.Text)
            P_Flg = "5"
            Dim frmform1 As New Form1P
            frmform1.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************************************
    '動産保険金支払報告書＿営業所毎(ｶｺｲｴﾚｸﾄﾛ振込分)ボタン
    '**********************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim SearchForThis As String = "_"
        Dim FirstCharacter As Integer = Label2.Text.IndexOf(SearchForThis)
        If Label2.Text = "____/__/20" Or FirstCharacter <> -1 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
            Exit Sub
        End If
        WK_DsList1.Clear()
        strSQL = "SELECT Shop_mtr.会社GRP"
        strSQL = strSQL & " FROM Wrn_ivc INNER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (Wrn_ivc.Cancel_flg = '0')"
        strSQL = strSQL & " AND (Shop_mtr.会社GRP = 203)"
        strSQL = strSQL & " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & CDate(Label2.Text) & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1

        Try
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(WK_DsList1, "Wrn_ivc")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show("該当データはありません。")
            DB_CLOSE()
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        DtView1 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            MsgBox("該当データはありません。", MsgBoxStyle.Critical, "")
        Else

            P_Date = CDate(Label2.Text)
            P_Flg = "6"
            Dim frmform1 As New Form1P
            frmform1.ShowDialog()
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
