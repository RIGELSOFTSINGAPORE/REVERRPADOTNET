Public Class F40_Form03
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Date
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form03))
        Me.msg = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Date2 = New GrapeCity.Win.Input.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(28, 92)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(328, 16)
        Me.msg.TabIndex = 1767
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(228, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 24)
        Me.Label2.TabIndex = 1764
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
        Me.Label35.TabIndex = 1763
        Me.Label35.Text = "範囲指定"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(304, 8)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1771
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
        Me.Combo001.Value = "Combo1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(28, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 1770
        Me.Label1.Text = "QG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F40_Form03
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
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form03"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "担当者別集計"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F40_Form03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Dim isTable As String = "0"
        For i = 0 To P_DsPRT.Tables.Count - 1
            If P_DsPRT.Tables(i).TableName = "Print01" Then
                isTable = "1"
                Exit For
            End If
        Next

        'DataTable作成()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_03", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 2)
        Pram1.Value = Date1.Text
        Pram2.Value = DateAdd(DateInterval.Day, 1, CDate(Date2.Text))
        Pram3.Value = CL001.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN(ini)
        DaList1.Fill(P_DsPRT, "Print01")
        DB_CLOSE()

        DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            msg.Text = "対象データがありません。"
            Err_F = "1" : Date1.Focus() : Exit Sub
        Else
            For i = 0 To DtView1.Count - 1
                DtView1(i)("keika") = DateDiff(DateInterval.Day, DtView1(i)("accp_date"), DtView1(i)("comp_date"))
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
            PRT_PRAM1 = "R_Sals_Empl_Report"
            P_PRAM1 = Date1.Text & " ～ " & Date2.Text
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
