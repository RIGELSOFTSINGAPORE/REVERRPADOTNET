Public Class F00_Form02
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DsCMB As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL, Err_F As String

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label2 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Label3 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(516, 68)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(436, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "決定"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "グループ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(20, 32)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(208, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 0
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(228, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(356, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "販　社"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo002.Location = New System.Drawing.Point(228, 32)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(356, 24)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 1
        Me.Combo002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo002.Value = "Combo002"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(208, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 76)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(396, 24)
        Me.msg.TabIndex = 1232
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F00_Form02
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(600, 110)
        Me.ControlBox = False
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Combo001)
        Me.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form02"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "販社検索"
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        CmbSet()    '**  コンボボックスセット
        DspSet()    '** 画面セット
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
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")

        '販社グループ
        strSQL = "SELECT M08_STORE.grup_code, M08_STORE.grup_code + ':' + cls006.cls_code_name AS grup_name"
        strSQL += " FROM M08_STORE INNER JOIN"
        strSQL += "  (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '006')) cls006 ON"
        strSQL += " M08_STORE.grup_code = cls006.cls_code COLLATE Japanese_CI_AS"
        If P_PRAM2 = "一般" Then
            strSQL += " WHERE (M08_STORE.idvd_flg = 1)"
        Else
            strSQL += " WHERE (M08_STORE.idvd_flg = 0)"
        End If
        strSQL += " AND (dbo.M08_STORE.delt_flg = 0)"
        strSQL += " GROUP BY M08_STORE.grup_code, M08_STORE.grup_code + ':' + cls006.cls_code_name"
        strSQL += " ORDER BY M08_STORE.grup_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_006")

        Combo001.DataSource = DsCMB.Tables("CLS_CODE_006")
        Combo001.DisplayMember = "grup_name"
        Combo001.ValueMember = "grup_code"

        '販社
        strSQL = "SELECT store_code, store_code + ':' + name AS name, grup_code"
        strSQL += " FROM M08_STORE"
        strSQL += " WHERE (delt_flg = 0)"
        If P_PRAM2 = "一般" Then
            strSQL += " AND (idvd_flg = 1)"
        Else
            strSQL += " AND (idvd_flg = 0)"
        End If
        strSQL += " ORDER BY grup_code, name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M08_STORE")

        Combo002.DataSource = DsCMB.Tables("M08_STORE")
        Combo002.DisplayMember = "name"
        Combo002.ValueMember = "store_code"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** 画面セット
    '********************************************************************
    Sub DspSet()
        If P_PRAM1 = Nothing Then
            Combo001.Text = Nothing
            Combo002.Text = Nothing
            Label3.Text = Nothing
        Else
            DtView1 = New DataView(DsCMB.Tables("M08_STORE"), "store_code = '" & P_PRAM1 & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                DtView2 = New DataView(DsCMB.Tables("CLS_CODE_006"), "grup_code = '" & DtView1(0)("grup_code") & "'", "", DataViewRowState.CurrentRows)
                If DtView2.Count <> 0 Then
                    DsCMB.Tables("M08_STORE").Clear()
                    strSQL = "SELECT store_code, store_code + ':' + name AS name"
                    strSQL += " FROM M08_STORE"
                    strSQL += " WHERE (delt_flg = 0)"
                    If P_PRAM2 = "一般" Then
                        strSQL += " AND (idvd_flg = 1)"
                    Else
                        strSQL += " AND (idvd_flg = 0)"
                    End If
                    strSQL += " AND (grup_code = '" & DtView2(0)("grup_code") & "')"
                    strSQL += " ORDER BY grup_code, name_kana"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(DsCMB, "M08_STORE")
                    DB_CLOSE()

                    Combo001.Text = DtView2(0)("grup_name")
                    Label3.Text = Combo001.Text
                End If
                Combo002.Text = DtView1(0)("name")
            Else
                Combo001.Text = Nothing
                Combo002.Text = Nothing
            End If
        End If
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Combo001()  '販社グループ
        msg.Text = Nothing
        Combo001.Text = Trim(Combo001.Text)

        If Combo001.Text <> Label3.Text Then
            DsCMB.Tables("M08_STORE").Clear()
            If Combo001.Text <> Nothing Then
                DtView1 = New DataView(DsCMB.Tables("CLS_CODE_006"), "grup_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    strSQL = "SELECT store_code, store_code + ':' + name AS name"
                    strSQL += " FROM M08_STORE"
                    strSQL += " WHERE (delt_flg = 0)"
                    If P_PRAM2 = "一般" Then
                        strSQL += " AND (idvd_flg = 1)"
                    Else
                        strSQL += " AND (idvd_flg = 0)"
                    End If
                    strSQL += " AND (grup_code = '" & DtView1(0)("grup_code") & "')"
                    strSQL += " ORDER BY grup_code, name_kana"
                Else
                    Combo001.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当するグループがありません。"
                    Exit Sub
                End If
            Else
                strSQL = "SELECT store_code, store_code + ':' + name AS name"
                strSQL += " FROM M08_STORE"
                strSQL += " WHERE (delt_flg = 0)"
                If P_PRAM2 = "一般" Then
                    strSQL += " AND (idvd_flg = 1)"
                Else
                    strSQL += " AND (idvd_flg = 0)"
                End If
                strSQL += " ORDER BY grup_code, name_kana"

            End If

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsCMB, "M08_STORE")
            DB_CLOSE()

            Label3.Text = Combo001.Text
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo002()  '販社
        msg.Text = Nothing
        Combo002.Text = Trim(Combo002.Text)

        If Combo002.Text <> Nothing Then
            DtView1 = New DataView(DsCMB.Tables("M08_STORE"), "name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する販社がありません。"
                Exit Sub
            End If
        Else
            Combo002.BackColor = System.Drawing.Color.Red
            msg.Text = "販社が入力されていません。"
            Exit Sub
        End If

        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        CHK_Combo001()  '販社グループ
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Combo002()  '販社
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Combo001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.GotFocus
        Combo001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.GotFocus
        Combo002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()  '販社グループ
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()  '販社
    End Sub

    '********************************************************************
    '** 決定
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_Check()   '**  項目チェック
        If Err_F = "0" Then
            DsList1.Clear()
            strSQL = "SELECT M08_STORE.store_code, M08_STORE.name, M08_STORE.dlvr_code, M08_STORE_1.name AS dlvr_name"
            strSQL += ", M08_STORE.tech_rate, M08_STORE.tech_mrgn_rate, M08_STORE.part_mrgn_rate"
            strSQL += " FROM M08_STORE LEFT OUTER JOIN"
            strSQL += " M08_STORE M08_STORE_1 ON M08_STORE.dlvr_code = M08_STORE_1.store_code"
            strSQL += " WHERE (M08_STORE.store_code + ':' + M08_STORE.name = '" & Trim(Combo002.Text) & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "M08_STORE")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)

            P_PRAM1 = DtView1(0)("store_code")
            P_PRAM2 = DtView1(0)("name")
            P_PRAM3 = DtView1(0)("dlvr_code")
            P_PRAM4 = DtView1(0)("dlvr_name")
            P_PRAM5 = DtView1(0)("tech_rate")
            P_PRAM6 = DtView1(0)("tech_mrgn_rate")
            P_PRAM7 = DtView1(0)("part_mrgn_rate")
            P_RTN = "1"
            DsCMB.Clear()
            DsList1.Clear()
            Close()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_RTN = "0"
        DsCMB.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class