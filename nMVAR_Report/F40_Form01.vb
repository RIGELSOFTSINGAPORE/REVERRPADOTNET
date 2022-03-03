Public Class F40_Form01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

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
    Friend WithEvents Date001 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form01))
        Me.Date001 = New GrapeCity.Win.Input.Interop.Date
        Me.Label007 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/MM", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyy/MM", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(108, 16)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(72, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 0
        Me.Date001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(28, 16)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(80, 20)
        Me.Label007.TabIndex = 1757
        Me.Label007.Text = "対象年月"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "ﾌﾟﾚﾋﾞｭｰ"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 44)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(192, 16)
        Me.msg.TabIndex = 1759
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(116, 68)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "戻る"
        '
        'F40_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(218, 100)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "売上集計"
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F40_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Date001.MaxDate = "9999/12/31 23:59:59"
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date001.Text = Format(Now.Date, "yyyy/MM")
        msg.Text = Nothing
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        '対象年月
        If Date001.Number = 0 Then
            msg.Text = "対象年月を入力してください。"
            Err_F = "1" : Date001.Focus() : Exit Sub
        End If

        'DataTable作成()
        P_DsPRT.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = Date001.Text & "/01"
        Pram2.Value = DateAdd(DateInterval.Month, 1, CDate(Date001.Text & "/01"))
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN(ini)
        DaList1.Fill(P_DsPRT, "WK_Print01")
        DB_CLOSE()

        DtView1 = New DataView(P_DsPRT.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            msg.Text = "対象データがありません。"
            Err_F = "1" : Date001.Focus() : Exit Sub
        Else
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("bocs_target")) Then DtView1(i)("bocs_target") = 0
                If IsDBNull(DtView1(i)("amnt")) Then DtView1(i)("amnt") = 0
                If IsDBNull(DtView1(i)("aka_cnt")) Then DtView1(i)("aka_cnt") = 0
                If IsDBNull(DtView1(i)("comp_cnt")) Then DtView1(i)("comp_cnt") = 0
                DtView1(i)("comp_cnt") = DtView1(i)("comp_cnt") - DtView1(i)("aka_cnt")
                If IsDBNull(DtView1(i)("accp_cnt")) Then DtView1(i)("accp_cnt") = 0
                If IsDBNull(DtView1(i)("back_log_cnt")) Then DtView1(i)("back_log_cnt") = 0
                If DtView1(i)("bocs_target") + DtView1(i)("amnt") + DtView1(i)("comp_cnt") + DtView1(i)("accp_cnt") + DtView1(i)("back_log_cnt") <> 0 Then

                    strSQL = "SELECT '" & DtView1(i)("area_code") & "' AS area_code"
                    Select Case DtView1(i)("area_code")
                        Case Is = "01"
                            strSQL += ", '東日本担当計' AS area_name"
                        Case Is = "02"
                            strSQL += ", '西日本担当計' AS area_name"
                        Case Else
                            strSQL += ", '' AS area_name"
                    End Select
                    strSQL += ", '" & DtView1(i)("brch_code") & "' AS brch_code"
                    strSQL += ", '" & DtView1(i)("name") & "' AS name"
                    strSQL += ", " & DtView1(i)("bocs_target") & " AS bocs_target"
                    strSQL += ", " & DtView1(i)("amnt") & " AS amnt"
                    If DtView1(i)("bocs_target") = 0 Then
                        strSQL += ", '0%' AS par"
                    Else
                        strSQL += ", '" & Format(Round(DtView1(i)("amnt") / DtView1(i)("bocs_target") * 100, 1), "###.0") & "%' AS par"
                    End If
                    strSQL += ", " & DtView1(i)("comp_cnt") & " AS comp_cnt"
                    strSQL += ", " & DtView1(i)("accp_cnt") & " AS accp_cnt"
                    strSQL += ", " & DtView1(i)("back_log_cnt") & " AS back_log_cnt"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DaList1.Fill(P_DsPRT, "Print01")

                End If
            Next
            DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                msg.Text = "対象データがありません。"
                Err_F = "1" : Date001.Focus() : Exit Sub
            End If
        End If

        P_PRAM1 = Date001.Text
    End Sub

    '********************************************************************
    '**  ﾌﾟﾚﾋﾞｭｰ
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            PRT_PRAM1 = "R_Sals_Report"
            'PRT_PRAM1 = "SectionReport5"
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
