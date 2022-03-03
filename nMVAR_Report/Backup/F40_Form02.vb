Public Class F40_Form02
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim daItem As New SqlClient.SqlDataAdapter
    Dim dsItem As New DataSet
    Dim DtView1, DtView2, WK_DtView1 As DataView
    Dim dtTbl, dtTbl2 As New DataTable

    Dim strSQL, Err_F As String
    Dim i As Integer

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Date
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form02))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Date2 = New GrapeCity.Win.Input.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(228, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 24)
        Me.Label2.TabIndex = 1273
        Me.Label2.Text = "～"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(124, 56)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(104, 24)
        Me.Date1.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.TabIndex = 1
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.Value = Nothing
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date2.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date2.Location = New System.Drawing.Point(252, 56)
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(104, 24)
        Me.Date2.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.TabIndex = 2
        Me.Date2.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date2.Value = Nothing
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(28, 56)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 24)
        Me.Label35.TabIndex = 1272
        Me.Label35.Text = "範囲指定"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(272, 116)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 4
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(36, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "ﾌﾟﾚﾋﾞｭｰ"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(28, 92)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(328, 16)
        Me.msg.TabIndex = 1760
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(304, 8)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1763
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(124, 24)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(232, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 0
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(28, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 1762
        Me.Label1.Text = "QG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F40_Form02
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(378, 152)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Label35)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form02"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "日別集計"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F40_Form02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        CmbSet()    '**  コンボボックスセット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date1.Text = Format(Now.Date, "yyyy/MM/") & "01"
        Date2.Text = Format(Now.Date, "yyyy/MM/dd")

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN(ini)

        '部署
        strSQL = "SELECT brch_code, brch_code + ':' + name AS brch_name"
        strSQL += " FROM M03_BRCH"
        strSQL += " WHERE (delt_flg = 0)"
        strSQL += " ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M03_BRCH")

        Combo001.DataSource = DsCMB.Tables("M03_BRCH")
        Combo001.DisplayMember = "brch_name"
        Combo001.ValueMember = "brch_code"

        CL001.Text = P_EMPL_BRCH
        WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_code ='" & P_EMPL_BRCH & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            Combo001.Text = WK_DtView1(0)("brch_name")
        End If
        DB_CLOSE()
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        'QG
        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            msg.Text = "ＱＧが入力されていません。"
            Err_F = "1" : Combo001.Focus() : Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_name ='" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                msg.Text = "該当するＱＧがありません。"
                Err_F = "1" : Combo001.Focus() : Exit Sub
            Else
                CL001.Text = WK_DtView1(0)("brch_code")
            End If
        End If

        '範囲指定(FROM)
        If Date1.Number = 0 Then
            msg.Text = "範囲指定を入力してください。"
            Err_F = "1" : Date1.Focus() : Exit Sub
        End If

        '範囲指定(TO)
        If Date2.Number = 0 Then
            msg.Text = "範囲指定を入力してください。"
            Err_F = "1" : Date2.Focus() : Exit Sub
        End If

        'FROM > TO
        If Date1.Number > Date2.Number Then
            msg.Text = "範囲指定が間違っています。"
            Err_F = "1" : Date2.Focus() : Exit Sub
        End If

        ''同一月
        'If Format(CDate(Date1.Text), "MM") <> Format(CDate(Date2.Text), "MM") Then
        '    msg.Text = "範囲指定は同一月内で指定してください。"
        '    Err_F = "1" : Date2.Focus() : Exit Sub
        'End If

        'DataTable作成()
        P_DsPRT.Clear()
        strSQL = "SELECT '' AS comp_date, 0 AS kensu_sum, 0 AS rev_sum"
        strSQL += ", 0 AS kensu1, 0 AS rev1"
        strSQL += ", 0 AS kensu2, 0 AS rev2"
        strSQL += ", 0 AS kensu3, 0 AS rev3"
        strSQL += ", 0 AS kensu4, 0 AS rev4"
        strSQL += ", 0 AS kensu5, 0 AS rev5"
        strSQL += ", 0 AS kensu6, 0 AS rev6"
        strSQL += ", 0 AS kensu7, 0 AS rev7"
        strSQL += ", 0 AS kensu8, 0 AS rev8"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        daItem.SelectCommand = SqlCmd1
        daItem.Fill(P_DsPRT, "Print02")
        P_DsPRT.Tables("Print02").Clear()

        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_02", cnsqlclient)
        SqlCmd1.CommandTimeout = 3000
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim qgcode As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@qgcode", SqlDbType.Char, 2)
        Dim startday As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@startday", SqlDbType.DateTime)
        Dim endday As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@endday", SqlDbType.DateTime)
        qgcode.Value = CL001.Text
        startday.Value = Date1.Text
        endday.Value = DateAdd(DateInterval.Day, 1, CDate(Date2.Text))
        daItem.SelectCommand = SqlCmd1
        dsItem.Clear()
        DB_OPEN(ini)
        daItem.Fill(dsItem, "sp_daily_sum")
        DB_CLOSE()

        DtView1 = New DataView(dsItem.Tables("sp_daily_sum"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("kingaku")) Then DtView1(i)("kingaku") = 0
                If IsDBNull(DtView1(i)("kensu")) Then DtView1(i)("kensu") = 0
                If IsDBNull(DtView1(i)("aka_kensu")) Then DtView1(i)("aka_kensu") = 0
                DtView1(i)("kensu") = DtView1(i)("kensu") - DtView1(i)("aka_kensu")

                DtView2 = New DataView(P_DsPRT.Tables("Print02"), "comp_date ='" & DtView1(i)("comp_date") & "'", "", DataViewRowState.CurrentRows)
                If DtView2.Count <> 0 Then
                    Select Case DtView1(i)("vndr_code")
                        Case Is = "01"
                            DtView2(0)("rev1") = DtView1(i)("kingaku")
                            DtView2(0)("kensu1") = DtView1(i)("kensu")

                        Case Is = "02"
                            DtView2(0)("rev2") = DtView1(i)("kingaku")
                            DtView2(0)("kensu2") = DtView1(i)("kensu")

                        Case Is = "03"
                            DtView2(0)("rev3") = DtView1(i)("kingaku")
                            DtView2(0)("kensu3") = DtView1(i)("kensu")
                            'Case Is = "06"
                            '    DtView2(0)("rev4") = Int(DtView1(i)("kingaku") / 1000)
                            '    DtView2(0)("kensu4") = DtView1(i)("kensu")

                        Case Is = "04"
                            DtView2(0)("rev5") = DtView1(i)("kingaku")
                            DtView2(0)("kensu5") = DtView1(i)("kensu")

                        Case Is = "13"
                            DtView2(0)("rev6") = DtView1(i)("kingaku")
                            DtView2(0)("kensu6") = DtView1(i)("kensu")

                        Case Is = "15"
                            DtView2(0)("rev7") = DtView1(i)("kingaku")
                            DtView2(0)("kensu7") = DtView1(i)("kensu")

                        Case Else
                            If Not IsDBNull(DtView2(0)("rev8")) Then
                                DtView2(0)("rev8") = DtView2(0)("rev8") + DtView1(i)("kingaku")
                            Else
                                DtView2(0)("rev8") = DtView1(i)("kingaku")
                            End If
                            If Not IsDBNull(DtView2(0)("kensu8")) Then
                                DtView2(0)("kensu8") = DtView2(0)("kensu8") + DtView1(i)("kensu")
                            Else
                                DtView2(0)("kensu8") = DtView1(i)("kensu")
                            End If

                    End Select

                    If DtView1(i)("kingaku") = 0 Then
                        DtView2(0)("rev_sum") = DtView2(0)("rev_sum") + 0
                    Else
                        DtView2(0)("rev_sum") = DtView2(0)("rev_sum") + DtView1(i)("kingaku")
                    End If
                    DtView2(0)("kensu_sum") = DtView2(0)("kensu_sum") + DtView1(i)("kensu")

                Else
                    strSQL = "SELECT '" & DtView1(i)("comp_date") & "' AS comp_date"
                    strSQL += ", " & DtView1(i)("kensu") & " AS kensu_sum, " & DtView1(i)("kingaku") & " AS rev_sum"
                    Select Case DtView1(i)("vndr_code")
                        Case Is = "01"
                            strSQL += ", " & DtView1(i)("kensu") & " AS kensu1, " & DtView1(i)("kingaku") & " AS rev1"
                        Case Is = "02"
                            strSQL += ", " & DtView1(i)("kensu") & " AS kensu2, " & DtView1(i)("kingaku") & " AS rev2"
                        Case Is = "03"
                            strSQL += ", " & DtView1(i)("kensu") & " AS kensu3, " & DtView1(i)("kingaku") & " AS rev3"
                            'Case Is = "06"
                            '    strSQL += ", " & DtView1(i)("kensu") & " AS kensu4, " & Int(DtView1(i)("kingaku") / 1000) & " AS rev4"
                        Case Is = "04"
                            strSQL += ", " & DtView1(i)("kensu") & " AS kensu5, " & DtView1(i)("kingaku") & " AS rev5"
                        Case Is = "13"
                            strSQL += ", " & DtView1(i)("kensu") & " AS kensu6, " & DtView1(i)("kingaku") & " AS rev6"
                        Case Is = "15"
                            strSQL += ", " & DtView1(i)("kensu") & " AS kensu7, " & DtView1(i)("kingaku") & " AS rev7"
                        Case Else
                            strSQL += ", " & DtView1(i)("kensu") & " AS kensu8, " & DtView1(i)("kingaku") & " AS rev8"
                    End Select
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    daItem.SelectCommand = SqlCmd1
                    daItem.Fill(P_DsPRT, "Print02")
                End If
            Next
        End If

        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            msg.Text = "対象データがありません。"
            Err_F = "1" : Date1.Focus() : Exit Sub
        Else
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("kensu1")) Then DtView1(i)("kensu1") = 0
                If IsDBNull(DtView1(i)("kensu2")) Then DtView1(i)("kensu2") = 0
                If IsDBNull(DtView1(i)("kensu3")) Then DtView1(i)("kensu3") = 0
                If IsDBNull(DtView1(i)("kensu4")) Then DtView1(i)("kensu4") = 0
                If IsDBNull(DtView1(i)("kensu5")) Then DtView1(i)("kensu5") = 0
                If IsDBNull(DtView1(i)("kensu6")) Then DtView1(i)("kensu6") = 0
                If IsDBNull(DtView1(i)("kensu7")) Then DtView1(i)("kensu7") = 0
                If IsDBNull(DtView1(i)("kensu8")) Then DtView1(i)("kensu8") = 0
                If IsDBNull(DtView1(i)("rev1")) Then DtView1(i)("rev1") = 0
                If IsDBNull(DtView1(i)("rev2")) Then DtView1(i)("rev2") = 0
                If IsDBNull(DtView1(i)("rev3")) Then DtView1(i)("rev3") = 0
                If IsDBNull(DtView1(i)("rev4")) Then DtView1(i)("rev4") = 0
                If IsDBNull(DtView1(i)("rev5")) Then DtView1(i)("rev5") = 0
                If IsDBNull(DtView1(i)("rev6")) Then DtView1(i)("rev6") = 0
                If IsDBNull(DtView1(i)("rev7")) Then DtView1(i)("rev7") = 0
                If IsDBNull(DtView1(i)("rev8")) Then DtView1(i)("rev8") = 0
            Next
        End If
    End Sub

    '********************************************************************
    '**  ﾌﾟﾚﾋﾞｭｰ
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            PRT_PRAM1 = "R_Sals_day_Report"
            P_PRAM1 = Mid(Combo001.Text, 4, 30)
            Dim Print_View As New Print_View
            Print_View.ShowDialog()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        Close()
    End Sub
End Class
