Imports System.Runtime.InteropServices

Public Class MENU00
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim r As Integer

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents user As System.Windows.Forms.Label
    Friend WithEvents Number01 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button30 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button40 As System.Windows.Forms.Button
    Friend WithEvents Button50 As System.Windows.Forms.Button
    Friend WithEvents Button90 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button41 As System.Windows.Forms.Button
    Friend WithEvents Button31 As System.Windows.Forms.Button
    Friend WithEvents Button51 As System.Windows.Forms.Button
    Friend WithEvents Button60 As System.Windows.Forms.Button
    Friend WithEvents Button61 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button20 = New System.Windows.Forms.Button
        Me.Button40 = New System.Windows.Forms.Button
        Me.Button50 = New System.Windows.Forms.Button
        Me.Button90 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.user = New System.Windows.Forms.Label
        Me.Number01 = New GrapeCity.Win.Input.Interop.Number
        Me.msg = New System.Windows.Forms.Label
        Me.Button30 = New System.Windows.Forms.Button
        Me.Button21 = New System.Windows.Forms.Button
        Me.Button22 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button41 = New System.Windows.Forms.Button
        Me.Button31 = New System.Windows.Forms.Button
        Me.Button51 = New System.Windows.Forms.Button
        Me.Button60 = New System.Windows.Forms.Button
        Me.Button61 = New System.Windows.Forms.Button
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Location = New System.Drawing.Point(44, 40)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(184, 36)
        Me.Button10.TabIndex = 1
        Me.Button10.Text = "加入者データ更新"
        '
        'Button20
        '
        Me.Button20.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button20.Location = New System.Drawing.Point(44, 92)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(184, 36)
        Me.Button20.TabIndex = 2
        Me.Button20.Text = "加入者データ取込"
        '
        'Button40
        '
        Me.Button40.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button40.Location = New System.Drawing.Point(44, 284)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(184, 36)
        Me.Button40.TabIndex = 6
        Me.Button40.Text = "加入者リスト印刷"
        '
        'Button50
        '
        Me.Button50.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button50.Location = New System.Drawing.Point(44, 332)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(184, 36)
        Me.Button50.TabIndex = 7
        Me.Button50.Text = "入金管理"
        '
        'Button90
        '
        Me.Button90.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button90.Location = New System.Drawing.Point(44, 380)
        Me.Button90.Name = "Button90"
        Me.Button90.Size = New System.Drawing.Size(184, 36)
        Me.Button90.TabIndex = 8
        Me.Button90.Text = "マスタ・メンテナンス"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(452, 380)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(160, 36)
        Me.Button99.TabIndex = 16
        Me.Button99.Text = "終了"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "年度"
        '
        'user
        '
        Me.user.Location = New System.Drawing.Point(260, 4)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(352, 28)
        Me.user.TabIndex = 9
        Me.user.Text = "user"
        Me.user.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number01
        '
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####", "", "", "-", "", "", "")
        Me.Number01.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number01.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number01.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####", "", "", "-", "", "", "")
        Me.Number01.Location = New System.Drawing.Point(12, 4)
        Me.Number01.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01.Name = "Number01"
        Me.Number01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number01.Size = New System.Drawing.Size(64, 28)
        Me.Number01.TabIndex = 0
        Me.Number01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Number01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number01.Value = Nothing
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(36, 428)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(576, 20)
        Me.msg.TabIndex = 1365
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button30
        '
        Me.Button30.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button30.Location = New System.Drawing.Point(44, 236)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(184, 36)
        Me.Button30.TabIndex = 5
        Me.Button30.Text = "加入証印刷"
        '
        'Button21
        '
        Me.Button21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button21.Location = New System.Drawing.Point(44, 140)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(184, 36)
        Me.Button21.TabIndex = 3
        Me.Button21.Text = "取込エラー修正"
        '
        'Button22
        '
        Me.Button22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button22.Location = New System.Drawing.Point(44, 188)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(184, 36)
        Me.Button22.TabIndex = 4
        Me.Button22.Text = "取込データ一括修正"
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Location = New System.Drawing.Point(236, 40)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(184, 36)
        Me.Button11.TabIndex = 9
        Me.Button11.Text = "加入者データ更新(iPad)"
        '
        'Button41
        '
        Me.Button41.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button41.Location = New System.Drawing.Point(236, 284)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(184, 36)
        Me.Button41.TabIndex = 14
        Me.Button41.Text = "加入者リスト(iPad)"
        '
        'Button31
        '
        Me.Button31.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button31.Location = New System.Drawing.Point(236, 236)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(184, 36)
        Me.Button31.TabIndex = 13
        Me.Button31.Text = "加入証印刷(iPad)"
        '
        'Button51
        '
        Me.Button51.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button51.Location = New System.Drawing.Point(236, 332)
        Me.Button51.Name = "Button51"
        Me.Button51.Size = New System.Drawing.Size(184, 36)
        Me.Button51.TabIndex = 15
        Me.Button51.Text = "iPad計上リスト"
        '
        'Button60
        '
        Me.Button60.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button60.Location = New System.Drawing.Point(236, 92)
        Me.Button60.Name = "Button60"
        Me.Button60.Size = New System.Drawing.Size(184, 36)
        Me.Button60.TabIndex = 10
        Me.Button60.Text = "加入者データ取込(iPad)"
        '
        'Button61
        '
        Me.Button61.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button61.Location = New System.Drawing.Point(236, 140)
        Me.Button61.Name = "Button61"
        Me.Button61.Size = New System.Drawing.Size(184, 36)
        Me.Button61.TabIndex = 1366
        Me.Button61.Text = "取込エラー修正(iPad)"
        '
        'MENU00
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(622, 455)
        Me.Controls.Add(Me.Button61)
        Me.Controls.Add(Me.Button60)
        Me.Controls.Add(Me.Button51)
        Me.Controls.Add(Me.Button31)
        Me.Controls.Add(Me.Button41)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button22)
        Me.Controls.Add(Me.Button21)
        Me.Controls.Add(Me.Button30)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Number01)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button90)
        Me.Controls.Add(Me.Button50)
        Me.Controls.Add(Me.Button40)
        Me.Controls.Add(Me.Button20)
        Me.Controls.Add(Me.Button10)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MENU00"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QG-Care Academy Pack"
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub MENU00_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        pc_name()   '**  ローカルＰＣ名取得
        If Err_F = "1" Then Application.Exit() : Exit Sub
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Call DB_INIT()

        Err_F = "0"
        P_EMPL = System.Environment.UserName
        If P_EMPL = "otsuki" Then P_EMPL = "administrator" '大槻テスト用

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_Login_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 20)
        Pram1.Value = P_EMPL
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M01_EMPL")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Err_F = "1"
            MessageBox.Show("ユーザーが登録されていません。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DtView1(0)("delt_flg") = "1" Then
                Err_F = "1"
                MessageBox.Show("ユーザー登録が無効です。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                P_EMPL_NO = DtView1(0)("empl_code")
                P_EMPL_NAME = Trim(DtView1(0)("name"))
                user.Text = P_EMPL_NAME
            End If
        End If

        msg.Text = Nothing
        Call proc_ck()

    End Sub

    '********************************************************************
    '**  ローカルＰＣ名取得
    '********************************************************************
    Sub pc_name()
        Dim serverName As String
        Dim clientInfo As New WTS_CLIENT_INFO
        ReDim clientInfo.Address(20)
        serverName = ""
        If GetSessions(serverName, clientInfo) = True Then
            If clientInfo.WTSClientName = "" Then
                P_PC_NAME = clientInfo.WTSDomainName
            Else
                P_PC_NAME = clientInfo.WTSClientName
            End If
            P_PC_NAME2 = clientInfo.WTSClientName
        End If
    End Sub

    Sub proc_ck()
        Number01.Value = proc_y()
        If Number01.Value = 0 Then
            Button10.Enabled = False
            Button20.Enabled = False
            Button30.Enabled = False
            Button40.Enabled = False
            msg.Text = "加入料金テーブルを登録してください。"
            Number01.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            Number01.Value = 0
            Button10.Enabled = True
            Button20.Enabled = True
            Button30.Enabled = True
            Button40.Enabled = True
            msg.Text = Nothing
        End If
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk(ByVal ck)
        Err_F = "0"

        Select Case ck
            Case Is = "1"
                Call CK_Number01()
                If msg.Text <> Nothing Then Err_F = "1" : Number01.Focus() : Exit Sub
            Case Is = "2"
                Call CK_Number01_2()
                If msg.Text <> Nothing Then Err_F = "1" : Number01.Focus() : Exit Sub
        End Select

    End Sub

    Sub CK_Number01()
        msg.Text = Nothing
        P_proc_y = 0

        If Number01.Value = 0 Then
            DsList1.Clear()
            msg.Text = "年度の入力がありません。"
            Number01.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT nendo FROM M03_amnt WHERE (nendo = " & Number01.Text & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "M03_amnt")
            DB_CLOSE()
            If r = 0 Then
                msg.Text = Number01.Text & "年度の加入料金テーブルを登録してください。"
                Number01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If

            WK_DsList1.Clear()
            strSQL = "SELECT cls_code_name FROM M02_cls WHERE (cls = 'SUI') AND (cls_code = " & Number01.Text & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "cls_SUI")
            DB_CLOSE()
            If r = 0 Then
                msg.Text = Number01.Text & "年度の推薦加入料金を登録してください。"
                Number01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If

            WK_DsList1.Clear()
            strSQL = "SELECT cls_code_name FROM M02_cls WHERE (cls = 'SOU') AND (cls_code = " & Number01.Text & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "cls_SOU")
            DB_CLOSE()
            If r = 0 Then
                msg.Text = Number01.Text & "年度の早期加入料金を登録してください。"
                Number01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If

        P_proc_y = Number01.Value
        P_proc_y1 = Mid(P_proc_y, Len(P_proc_y), 1)
        Number01.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CK_Number01_2()
        msg.Text = Nothing
        P_proc_y = 0

        If Number01.Value = 0 Then
            DsList1.Clear()
            msg.Text = "年度の入力がありません。"
            Number01.BackColor = System.Drawing.Color.Red : Exit Sub
        End If

        P_proc_y = Number01.Value
        P_proc_y1 = Mid(P_proc_y, Len(P_proc_y), 1)
        Number01.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Number01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.LostFocus
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call CK_Number01_2()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 加入者データ入力
    '******************************************************************
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.Hide()
        Dim F00_Form10 As New F00_Form10
        F00_Form10.ShowDialog()
        Me.Show()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 加入者データ入力(iPad)
    '******************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.Hide()
        Dim F00_Form11 As New F00_Form11
        F00_Form11.ShowDialog()
        Me.Show()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 加入者データ取込
    '******************************************************************
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk("1")    '** 項目チェック
        If Err_F = "0" Then

            Me.Hide()
            Dim F00_Form20 As New F00_Form20
            F00_Form20.ShowDialog()
            Me.Show()

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 取込エラー修正
    '******************************************************************
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.Hide()
        Dim F00_Form21 As New F00_Form21
        F00_Form21.ShowDialog()
        Me.Show()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '↓↓↓↓↓↓ 2021/10/15 修正
    '******************************************************************
    '** 取込データ一括修正
    '******************************************************************
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.Hide()
        Dim F00_Form22 As New F00_Form22
        F00_Form22.ShowDialog()
        Me.Show()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 加入者データ取込(iPad)
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button60.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk("1")    '** 項目チェック
        If Err_F = "0" Then

            Me.Hide()
            Dim F00_Form60 As New F00_Form60
            F00_Form60.ShowDialog()
            Me.Show()

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    '↑↑↑↑↑↑ 2021/10/15 修正

    '******************************************************************
    '** 取込エラー修正(iPad)
    '******************************************************************
    Private Sub Button61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button61.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.Hide()
        Dim F00_Form61 As New F00_Form61
        F00_Form61.ShowDialog()
        Me.Show()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 加入証印刷
    '******************************************************************
    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk("2")    '** 項目チェック
        If Err_F = "0" Then

            Me.Hide()
            Dim F00_Form30 As New F00_Form30
            F00_Form30.ShowDialog()
            Me.Show()

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 加入証印刷(iPad)
    '******************************************************************
    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk("2")    '** 項目チェック
        If Err_F = "0" Then

            Me.Hide()
            Dim F00_Form31 As New F00_Form31
            F00_Form31.ShowDialog()
            Me.Show()

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 加入者リスト印刷
    '******************************************************************
    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk("2")    '** 項目チェック
        If Err_F = "0" Then

            Me.Hide()
            Dim F00_Form40 As New F00_Form40
            F00_Form40.ShowDialog()
            Me.Show()

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk("2")    '** 項目チェック
        If Err_F = "0" Then

            Me.Hide()
            Dim F00_Form41 As New F00_Form41
            F00_Form41.ShowDialog()
            Me.Show()

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 入金管理
    '******************************************************************
    Private Sub Button50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Menu50 As New MENU50
        Menu50.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** iPad計上リスト
    '******************************************************************
    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F00_Form51 As New F00_Form51
        F00_Form51.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** マスタメンテナンス
    '******************************************************************
    Private Sub Button90_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button90.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.Hide()
        Dim Menu90 As New MENU90
        Menu90.ShowDialog()
        Me.Show()

        If Number01.Value = 0 Then
            Call proc_ck()
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 終了
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Dim i As Decimal
        For i = 1 To 0 Step -0.005
            Me.Opacity = i
        Next
        Application.Exit()
    End Sub

    Private Enum WTS_CONNECTSTATE_CLASS
        WTSActive
        WTSConnected
        WTSConnectQuery
        WTSShadow
        WTSDisconnected
        WTSIdle
        WTSListen
        WTSReset
        WTSDown
        WTSInit
    End Enum

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Private Structure WTS_SESSION_INFO
        Dim SessionID As Int32 'DWORD integer
        Dim pWinStationName As String ' integer LPTSTR - Pointer to a null-terminated string containing the name of the WinStation for this session
        Dim State As WTS_CONNECTSTATE_CLASS
    End Structure

    Friend Structure strSessionsInfo
        Dim SessionID As Integer
        Dim StationName As String
        Dim ConnectionState As String
    End Structure

    Private Enum WTS_INFO_CLASS
        WTSInitialProgram
        WTSApplicationName
        WTSWorkingDirectory
        WTSOEMId
        WTSSessionId
        WTSUserName
        WTSWinStationName
        WTSDomainName
        WTSConnectState
        WTSClientBuildNumber
        WTSClientName
        WTSClientDirectory
        WTSClientProductId
        WTSClientHardwareId
        WTSClientAddress
        WTSClientDisplay
        WTSClientProtocolType
        WTSIdleTime
        WTSLogonTime
        WTSIncomingBytes
        WTSOutgoingBytes
        WTSIncomingFrames
        WTSOutgoingFrames
    End Enum

    'Structure for TS Client IP Address
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure _WTS_CLIENT_ADDRESS
        Public AddressFamily As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=20)> _
        Public Address As Byte()
    End Structure

    'Structure for TS Client Information
    Friend Structure WTS_CLIENT_INFO
        Public WTSStatus As Boolean
        Public WTSUserName As String
        Public WTSStationName As String
        Public WTSDomainName As String
        Public WTSClientName As String
        Public AddressFamily As Integer
        Public Address As Byte()
    End Structure

    'Function for TS Session Information excluding Client IP address
    Private Declare Function WTSQuerySessionInformation Lib "WtsApi32.dll" Alias "WTSQuerySessionInformationW" (ByVal hServer As Int64,
    ByVal SessionId As Int32, ByVal WTSInfoClass As Int32, <MarshalAs(UnmanagedType.LPWStr)> ByRef ppBuffer As String, ByRef pCount As Int32) As Boolean

    'Function for TS Client IP Address
    Private Declare Function WTSQuerySessionInformation2 Lib "WtsApi32.dll" Alias "WTSQuerySessionInformationW" (ByVal hServer As Int64,
    ByVal SessionId As Int32, ByVal WTSInfoClass As Int32, ByRef ppBuffer As IntPtr, ByRef pCount As Int32) As Boolean

    Private Declare Function GetCurrentProcessId Lib "Kernel32.dll" Alias "GetCurrentProcessId" () As Int64
    Private Declare Function ProcessIdToSessionId Lib "Kernel32.dll" Alias "ProcessIdToSessionId" (ByVal processID As Int32, ByRef sessionID As Int32) As Boolean
    Private Declare Function WTSGetActiveConsoleSessionId Lib "Kernel32.dll" Alias "WTSGetActiveConsoleSessionId" () As Int32

    <DllImport("wtsapi32.dll", _
    bestfitmapping:=True, _
    CallingConvention:=CallingConvention.StdCall, _
    CharSet:=CharSet.Auto, _
    EntryPoint:="WTSEnumerateSessions", _
    setlasterror:=True, _
    ThrowOnUnmappableChar:=True)> _
    Private Shared Function WTSEnumerateSessions( _
    ByVal hServer As IntPtr, _
    <MarshalAs(UnmanagedType.U4)> _
    ByVal Reserved As Int32, _
    <MarshalAs(UnmanagedType.U4)> _
    ByVal Vesrion As Int32, _
    ByRef ppSessionInfo As IntPtr, _
    <MarshalAs(UnmanagedType.U4)> _
    ByRef pCount As Int32) As Int32
    End Function

    <DllImport("wtsapi32.dll")> _
    Private Shared Sub WTSFreeMemory(ByVal pMemory As IntPtr)
    End Sub

    <DllImport("wtsapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
     Private Shared Function WTSOpenServer(ByVal pServerName As String) As IntPtr
    End Function

    <DllImport("wtsapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
     Private Shared Sub WTSCloseServer(ByVal hServer As IntPtr)
    End Sub

    Friend Function GetSessions(ByVal ServerName As String, ByRef ClientInfo As WTS_CLIENT_INFO) As Boolean
        Dim ptrOpenedServer As IntPtr
        Try
            ptrOpenedServer = WTSOpenServer(ServerName)
            If ptrOpenedServer.ToInt64 = vbNull Then
                MessageBox.Show("Terminal Services not running on : " & ServerName)
                GetSessions = False
                Exit Function
            End If
            Dim FRetVal As Int32
            Dim ppSessionInfo As IntPtr = IntPtr.Zero
            Dim Count As Int32 = 0
            Try
                FRetVal = WTSEnumerateSessions(ptrOpenedServer, 0, 1, ppSessionInfo, Count)
                If FRetVal <> 0 Then
                    Dim sessionInfo() As WTS_SESSION_INFO = New WTS_SESSION_INFO(Count) {}
                    Dim i As Integer
                    Dim session_ptr As IntPtr
                    For i = 0 To Count - 1
                        'session_ptr = ppSessionInfo.ToInt32() + (i * Marshal.SizeOf(sessionInfo(i)))
                        sessionInfo(i) = CType(Marshal.PtrToStructure(session_ptr, GetType(WTS_SESSION_INFO)), WTS_SESSION_INFO)
                    Next
                    WTSFreeMemory(ppSessionInfo)
                    Dim tmpArr(sessionInfo.GetUpperBound(0)) As strSessionsInfo
                    For i = 0 To tmpArr.GetUpperBound(0)
                        tmpArr(i).SessionID = sessionInfo(i).SessionID
                        tmpArr(i).StationName = sessionInfo(i).pWinStationName
                        tmpArr(i).ConnectionState = GetConnectionState(sessionInfo(i).State)
                        'MessageBox.Show(tmpArr(i).StationName & "  " & tmpArr(i).SessionID & "  " & tmpArr(i).ConnectionState)
                    Next
                    ReDim sessionInfo(-1)
                Else
                    Throw New ApplicationException("No data retruned")
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message & vbCrLf & System.Runtime.InteropServices.Marshal.GetLastWin32Error)
            End Try
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        Finally
        End Try
        'Get ProcessID of TS Session that executed this TS Session
        Dim active_process As Int32 = GetCurrentProcessId()
        Dim active_session As Int32 = 0
        Dim success1 As Boolean = ProcessIdToSessionId(active_process, active_session)
        If success1 = False Then
            MessageBox.Show("Error: ProcessIdToSessionId")
        End If
        Dim returned As Integer
        Dim str As String = ""
        Dim success As Boolean = False
        ClientInfo.WTSStationName = ""
        ClientInfo.WTSClientName = ""
        ClientInfo.Address(2) = 0
        ClientInfo.Address(3) = 0
        ClientInfo.Address(4) = 0
        ClientInfo.Address(5) = 0

        'Get User Name of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSUserName, str, returned) = True Then
            ClientInfo.WTSUserName = str
        End If

        'Get StationName of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSWinStationName, str, returned) = True Then
            ClientInfo.WTSStationName = str
        End If

        'Get Domain Name of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSDomainName, str, returned) = True Then
            ClientInfo.WTSDomainName = str
        End If

        'Skip client name and client address if this is a console session
        If ClientInfo.WTSStationName <> "Console" Then
            If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSClientName, str, returned) = True Then
                ClientInfo.WTSClientName = str
            End If

            'Get client IP address
            Dim addr As IntPtr
            If WTSQuerySessionInformation2(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSClientAddress, addr, returned) = True Then
                Dim obj As New _WTS_CLIENT_ADDRESS
                obj = CType(Marshal.PtrToStructure(addr, obj.GetType()), _WTS_CLIENT_ADDRESS)
                ClientInfo.Address(2) = obj.Address(2)
                ClientInfo.Address(3) = obj.Address(3)
                ClientInfo.Address(4) = obj.Address(4)
                ClientInfo.Address(5) = obj.Address(5)
            End If
        End If
        WTSCloseServer(ptrOpenedServer)
        Return True
    End Function

    Private Function GetConnectionState(ByVal State As WTS_CONNECTSTATE_CLASS) As String
        Dim RetVal As String
        Select Case State
            Case WTS_CONNECTSTATE_CLASS.WTSActive
                RetVal = "Active"
            Case WTS_CONNECTSTATE_CLASS.WTSConnected
                RetVal = "Connected"
            Case WTS_CONNECTSTATE_CLASS.WTSConnectQuery
                RetVal = "Query"
            Case WTS_CONNECTSTATE_CLASS.WTSDisconnected
                RetVal = "Disconnected"
            Case WTS_CONNECTSTATE_CLASS.WTSDown
                RetVal = "Down"
            Case WTS_CONNECTSTATE_CLASS.WTSIdle
                RetVal = "Idle"
            Case WTS_CONNECTSTATE_CLASS.WTSInit
                RetVal = "Initializing."
            Case WTS_CONNECTSTATE_CLASS.WTSListen
                RetVal = "Listen"
            Case WTS_CONNECTSTATE_CLASS.WTSReset
                RetVal = "reset"
            Case WTS_CONNECTSTATE_CLASS.WTSShadow
                RetVal = "Shadowing"
            Case Else
                RetVal = "Unknown connect state"
        End Select
        Return RetVal
    End Function
End Class
