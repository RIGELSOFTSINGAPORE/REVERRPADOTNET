Public Class F50_Form14
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim i, Line_No, en, chg_itm, seq, max_seq As Integer
    Dim M_CLS As String = "M41"

    Private label(99, 2) As label
    Private dateBox(99, 2) As GrapeCity.Win.Input.Date
    'Private nbrBox(99, 1) As GrapeCity.Win.Input.Number
    Private btn(99, 1) As Button

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.msg = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(23, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(356, 584)
        Me.Panel1.TabIndex = 0
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 624)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(348, 20)
        Me.msg.TabIndex = 1706
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(296, 652)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 28)
        Me.Button98.TabIndex = 1705
        Me.Button98.Text = "戻る"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(26, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 25)
        Me.Label1.TabIndex = 1707
        Me.Label1.Text = "開始日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(156, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 25)
        Me.Label2.TabIndex = 1708
        Me.Label2.Text = "終了日"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F50_Form14
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(402, 688)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form14"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ｱｯﾌﾟﾙｻｰﾋﾞｽｴｸｾﾚﾝｽ 設定"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        DspSet()    '**  画面セット
    End Sub
    Private Sub F50_Form14_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Line_No = 0 Then
            dateBox(Line_No, 1).Focus()
        Else
            dateBox(Line_No, 2).Focus()
        End If
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  権限チェック
    '********************************************************************
    Sub ACES()

        'SqlCmd1 = New SqlClient.SqlCommand("sp_ACES_CHK", cnsqlclient)
        'SqlCmd1.CommandType = CommandType.StoredProcedure
        'Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        'Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        'Pram1.Value = P_ACES_brch_code
        'Pram2.Value = P_ACES_post_code
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nMVAR")
        'SqlCmd1.CommandTimeout = 600
        'DaList1.Fill(DsList1, "ACES_CHK")
        'DB_CLOSE()

        'DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='514'", "", DataViewRowState.CurrentRows)
        'Select Case DtView1(0)("access_cls")
        '    Case Is = "2"
        '        Button1.Enabled = False
        '    Case Is = "3"
        '        Button1.Enabled = True
        '    Case Is = "4"
        '        Button1.Enabled = True
        'End Select
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        sql()

        Line_No = -1
        Panel1.Controls.Clear()

        '基準点
        en = 0
        label(0, en) = New Label
        label(0, en).Location = New System.Drawing.Point(0, 0)
        label(0, en).Size = New System.Drawing.Size(0, 0)
        label(0, en).Text = Nothing
        Panel1.Controls.Add(label(0, en))

        DtView1 = New DataView(DsList1.Tables("M41_AP_BNAS"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                add_line("1")
            Next
        End If
        add_line("0")
        dateBox(Line_No, 1).Focus()

    End Sub
    Sub sql()
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_M41_AP_BNAS", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M41_AP_BNAS")
        DB_CLOSE()
    End Sub

    Sub add_line(ByVal flg)
        Line_No = Line_No + 1

        en = 1
        dateBox(Line_No, en) = New GrapeCity.Win.Input.Date
        dateBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        dateBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        dateBox(Line_No, en).Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        dateBox(Line_No, en).Location = New System.Drawing.Point(1, 25 * Line_No + label(0, 0).Location.Y)
        dateBox(Line_No, en).MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        dateBox(Line_No, en).MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        dateBox(Line_No, en).HighlightText = GrapeCity.Win.Input.HighlightText.All
        dateBox(Line_No, en).Size = New System.Drawing.Size(100, 25)
        dateBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        dateBox(Line_No, en).TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        dateBox(Line_No, en).Tag = Line_No
        If Line_No <> 0 Then
            dateBox(Line_No, en).Enabled = False
            dateBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        End If
        If flg = "1" Then
            dateBox(Line_No, en).Text = DtView1(i)("date_from")
        Else
            If Line_No = 0 Then
                dateBox(Line_No, en).Text = Nothing
            Else
                dateBox(Line_No, en).Text = DateAdd(DateInterval.Day, 1, CDate(dateBox(Line_No - 1, 2).Text))
            End If
        End If
        Panel1.Controls.Add(dateBox(Line_No, en))
        AddHandler dateBox(Line_No, en).GotFocus, AddressOf dateBox1_GotFocus
        AddHandler dateBox(Line_No, en).LostFocus, AddressOf dateBox1_LostFocus

        en = 1
        label(Line_No, en) = New Label
        label(Line_No, en).Location = New System.Drawing.Point(101, 25 * Line_No + label(0, 0).Location.Y)
        label(Line_No, en).Size = New System.Drawing.Size(30, 25)
        label(Line_No, en).TextAlign = ContentAlignment.MiddleCenter
        label(Line_No, en).Text = "～"
        Panel1.Controls.Add(label(Line_No, en))

        en = 2
        dateBox(Line_No, en) = New GrapeCity.Win.Input.Date
        dateBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        dateBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        dateBox(Line_No, en).Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        dateBox(Line_No, en).Location = New System.Drawing.Point(131, 25 * Line_No + label(0, 0).Location.Y)
        dateBox(Line_No, en).MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        dateBox(Line_No, en).MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        dateBox(Line_No, en).HighlightText = GrapeCity.Win.Input.HighlightText.All
        dateBox(Line_No, en).Size = New System.Drawing.Size(100, 25)
        dateBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        dateBox(Line_No, en).TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        dateBox(Line_No, en).Tag = Line_No
        If flg = "1" Then
            dateBox(Line_No, en).Text = DtView1(i)("date_to")
        Else
            dateBox(Line_No, en).Text = Nothing
        End If
        Panel1.Controls.Add(dateBox(Line_No, en))
        AddHandler dateBox(Line_No, en).GotFocus, AddressOf dateBox2_GotFocus
        AddHandler dateBox(Line_No, en).LostFocus, AddressOf dateBox2_LostFocus

        'Button
        en = 1
        btn(Line_No, en) = New Button
        btn(Line_No, en).BackColor = System.Drawing.SystemColors.Control
        btn(Line_No, en).Cursor = System.Windows.Forms.Cursors.Hand
        btn(Line_No, en).Location = New System.Drawing.Point(241, 25 * Line_No + label(0, 0).Location.Y + 1)
        btn(Line_No, en).Size = New System.Drawing.Size(90, 23)
        btn(Line_No, en).Text = "掛率入力"
        btn(Line_No, en).Tag = Line_No
        Panel1.Controls.Add(btn(Line_No, en))
        AddHandler btn(Line_No, en).Click, AddressOf btn_Click
        AddHandler btn(Line_No, en).LostFocus, AddressOf btn_LostFocus

        'id
        en = 2
        label(Line_No, en) = New Label
        label(Line_No, en).Location = New System.Drawing.Point(331, 25 * Line_No + label(0, 0).Location.Y)
        label(Line_No, en).Size = New System.Drawing.Size(30, 25)
        label(Line_No, en).Visible = False
        If flg = "1" Then
            label(Line_No, en).Text = DtView1(i)("id")
        Else
            label(Line_No, en).Text = Nothing
        End If
        Panel1.Controls.Add(label(Line_No, en))

    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_dateBox1(ByVal seq As Integer) '開始日
        msg.Text = Nothing

        If dateBox(seq, 1).Text > dateBox(seq, 2).Text Then
            dateBox(seq, 1).BackColor = System.Drawing.Color.Red
            msg.Text = "開始日＞終了日　エラー"
            Exit Sub
        End If
        dateBox(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_dateBox2(ByVal seq As Integer) '終了日
        msg.Text = Nothing

        If dateBox(seq, 1).Text > dateBox(seq, 2).Text Then
            dateBox(seq, 2).BackColor = System.Drawing.Color.Red
            msg.Text = "開始日＞終了日　エラー"
            Exit Sub
        End If
        If seq <> Line_No Then
            If dateBox(seq, 2).Number = 0 Then
                If seq <> 0 Then
                    dateBox(seq, 1).Text = Nothing
                    dateBox(seq + 1, 1).Text = DateAdd(DateInterval.Day, 1, CDate(dateBox(seq - 1, 2).Text))
                End If
            Else
                dateBox(seq + 1, 1).Text = DateAdd(DateInterval.Day, 1, CDate(dateBox(seq, 2).Text))
            End If
        End If
        dateBox(seq, 2).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_dateBox2_2(ByVal seq As Integer) '終了日
        msg.Text = Nothing

        If dateBox(seq, 2).Number = 0 Then
            dateBox(seq, 2).BackColor = System.Drawing.Color.Red
            msg.Text = "終了日が入力されていません。"
            Exit Sub
        End If
        dateBox(seq, 2).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check(ByVal seq)
        Err_F = "0"

        If dateBox(seq, 2).Text <> Nothing Then

            CHK_dateBox1(seq) '開始日
            If msg.Text <> Nothing Then Err_F = "1" : dateBox(seq, 1).Focus() : Exit Sub

            CHK_dateBox2(seq) '終了日
            If msg.Text <> Nothing Then Err_F = "1" : dateBox(seq, 2).Focus() : Exit Sub

            CHK_dateBox2_2(seq) '終了日
            If msg.Text <> Nothing Then Err_F = "1" : dateBox(seq, 2).Focus() : Exit Sub
        End If
    End Sub
    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub dateBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Date
        Lin = DirectCast(sender, GrapeCity.Win.Input.Date)
        dateBox(Lin.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub dateBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Date
        Lin = DirectCast(sender, GrapeCity.Win.Input.Date)
        dateBox(Lin.Tag, 2).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub dateBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Date
        Lin = DirectCast(sender, GrapeCity.Win.Input.Date)
        CHK_dateBox1(Lin.Tag) '開始日
    End Sub
    Private Sub dateBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Date
        Lin = DirectCast(sender, GrapeCity.Win.Input.Date)
        CHK_dateBox2(Lin.Tag) '終了日
    End Sub
    Private Sub btn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As Button
        btn = DirectCast(sender, Button)
        If dateBox(btn.Tag, 2).Number <> 0 Then
            If btn.Tag = Line_No Then
                add_line("0")
                If btn.Tag <> Line_No Then
                    dateBox(Line_No, 2).Focus()
                End If
            End If
        End If
    End Sub
    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim btn As Button
        btn = DirectCast(sender, Button)

        F_Check(btn.Tag)   '**  項目チェック
        If Err_F = "0" Then

            upd(btn.Tag)


            P_PRAM1 = label(btn.Tag, 2).Text

            Dim F50_Form14_2 As New F50_Form14_2
            F50_Form14_2.ShowDialog()
            sql()

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Sub upd(ByVal seq)
        P_HSTY_DATE = Now

        '追加
        If label(seq, 2).Text = Nothing And dateBox(seq, 2).Number <> 0 Then
            WK_DsList1.Clear()
            strSQL = "SELECT MAX(id) AS max_seq FROM M41_AP_BNAS"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "M41_AP_BNAS")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("M41_AP_BNAS"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                max_seq = 0
            Else
                If Not IsDBNull(WK_DtView1(0)("max_seq")) Then
                    max_seq = WK_DtView1(0)("max_seq")
                Else
                    max_seq = 0
                End If
            End If

            max_seq = max_seq + 1
            strSQL = "INSERT INTO M41_AP_BNAS"
            strSQL += " (id, date_from, date_to)"
            strSQL += " VALUES (" & max_seq
            strSQL += ", '" & dateBox(seq, 1).Text & "'"
            strSQL += ", '" & dateBox(seq, 2).Text & "'"
            strSQL += ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            label(seq, 2).Text = max_seq
            add_MTR_hsty(M_CLS, max_seq, "開始 終了" & max_seq, "", dateBox(seq, 1).Text & "～" & dateBox(seq, 2).Text)
            Exit Sub
        End If

        '変更
        If label(seq, 2).Text <> Nothing And dateBox(seq, 2).Number <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("M41_AP_BNAS"), "id = " & label(seq, 2).Text, "", DataViewRowState.CurrentRows)
            Dim a1, a2, a3, a4, a5, a6 As String
            a1 = WK_DtView1.Count
            a2 = label(seq, 2).Text
            a3 = dateBox(seq, 1).Text
            a4 = dateBox(seq, 2).Text
            a5 = WK_DtView1(0)("date_from")
            a6 = WK_DtView1(0)("date_to")


            If dateBox(seq, 1).Text <> WK_DtView1(0)("date_from") _
                Or dateBox(seq, 2).Text <> WK_DtView1(0)("date_to") Then
                strSQL = "UPDATE M41_AP_BNAS"
                strSQL +=  " SET date_from = '" & dateBox(seq, 1).Text & "'"
                strSQL +=  ", date_to = '" & dateBox(seq, 2).Text & "'"
                strSQL +=  " WHERE (id = " & label(seq, 2).Text & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                add_MTR_hsty(M_CLS, label(seq, 2).Text, "開始 終了" & label(seq, 2).Text, WK_DtView1(0)("date_from") & "～" & WK_DtView1(0)("date_to"), dateBox(seq, 1).Text & "～" & dateBox(seq, 2).Text)
                Exit Sub
            End If
        End If

        '削除
        If label(seq, 2).Text <> Nothing And dateBox(seq, 2).Number = 0 Then
            strSQL = "DELETE FROM M41_AP_BNAS"
            strSQL +=  " WHERE (id = " & label(seq, 2).Text & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            add_MTR_hsty(M_CLS, label(seq, 2).Text, "開始 終了" & label(seq, 2).Text, WK_DtView1(0)("date_from") & "～" & WK_DtView1(0)("date_to"), "")
            Exit Sub
        End If
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class
