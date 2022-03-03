Public Class F90_Form04_01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DsCMB1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim i, r As Integer

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents cmb08 As System.Windows.Forms.Label
    Friend WithEvents cmb07 As System.Windows.Forms.Label
    Friend WithEvents Combo08 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Combo07 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Number01 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Number02 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb01 As System.Windows.Forms.Label
    Friend WithEvents Combo01 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents CheckBox02 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.cmb08 = New System.Windows.Forms.Label
        Me.cmb07 = New System.Windows.Forms.Label
        Me.Combo08 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo07 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label17 = New System.Windows.Forms.Label
        Me.Number01 = New GrapeCity.Win.Input.Interop.Number
        Me.Label1 = New System.Windows.Forms.Label
        Me.Number02 = New GrapeCity.Win.Input.Interop.Number
        Me.Label21 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.cmb01 = New System.Windows.Forms.Label
        Me.Combo01 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox02 = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.Combo08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 260)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "更新"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(420, 260)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 7
        Me.Button99.Text = "閉じる"
        '
        'cmb08
        '
        Me.cmb08.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb08.Location = New System.Drawing.Point(328, 144)
        Me.cmb08.Name = "cmb08"
        Me.cmb08.Size = New System.Drawing.Size(52, 16)
        Me.cmb08.TabIndex = 1359
        Me.cmb08.Text = "cmb08"
        Me.cmb08.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb08.Visible = False
        '
        'cmb07
        '
        Me.cmb07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb07.Location = New System.Drawing.Point(252, 128)
        Me.cmb07.Name = "cmb07"
        Me.cmb07.Size = New System.Drawing.Size(52, 16)
        Me.cmb07.TabIndex = 1358
        Me.cmb07.Text = "cmb07"
        Me.cmb07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb07.Visible = False
        '
        'Combo08
        '
        Me.Combo08.AutoSelect = True
        Me.Combo08.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Combo08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo08.Location = New System.Drawing.Point(148, 160)
        Me.Combo08.MaxDropDownItems = 20
        Me.Combo08.Name = "Combo08"
        Me.Combo08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo08.Size = New System.Drawing.Size(232, 24)
        Me.Combo08.TabIndex = 4
        Me.Combo08.Value = "Combo08"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(28, 160)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 24)
        Me.Label18.TabIndex = 1357
        Me.Label18.Text = "保証範囲"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo07
        '
        Me.Combo07.AutoSelect = True
        Me.Combo07.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Combo07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo07.Location = New System.Drawing.Point(148, 128)
        Me.Combo07.MaxDropDownItems = 20
        Me.Combo07.Name = "Combo07"
        Me.Combo07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo07.Size = New System.Drawing.Size(104, 24)
        Me.Combo07.TabIndex = 3
        Me.Combo07.Value = "Combo07"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(28, 128)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(116, 24)
        Me.Label17.TabIndex = 1356
        Me.Label17.Text = "保証期間"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number01
        '
        Me.Number01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number01.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number01.Enabled = False
        Me.Number01.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number01.Location = New System.Drawing.Point(20, 12)
        Me.Number01.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01.Name = "Number01"
        Me.Number01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number01.Size = New System.Drawing.Size(64, 24)
        Me.Number01.TabIndex = 0
        Me.Number01.TabStop = False
        Me.Number01.Value = Nothing
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 24)
        Me.Label1.TabIndex = 1360
        Me.Label1.Text = "年度"
        '
        'Number02
        '
        Me.Number02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number02.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number02.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number02.HighlightText = True
        Me.Number02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number02.Location = New System.Drawing.Point(148, 192)
        Me.Number02.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02.Name = "Number02"
        Me.Number02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number02.Size = New System.Drawing.Size(104, 24)
        Me.Number02.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.TabIndex = 5
        Me.Number02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number02.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(28, 192)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(116, 24)
        Me.Label21.TabIndex = 1363
        Me.Label21.Text = "加入料金(税別)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 228)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(496, 28)
        Me.msg.TabIndex = 1364
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb01
        '
        Me.cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb01.Location = New System.Drawing.Point(252, 96)
        Me.cmb01.Name = "cmb01"
        Me.cmb01.Size = New System.Drawing.Size(52, 16)
        Me.cmb01.TabIndex = 1367
        Me.cmb01.Text = "cmb01"
        Me.cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb01.Visible = False
        '
        'Combo01
        '
        Me.Combo01.AutoSelect = True
        Me.Combo01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Combo01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo01.Location = New System.Drawing.Point(148, 96)
        Me.Combo01.MaxDropDownItems = 20
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo01.Size = New System.Drawing.Size(104, 24)
        Me.Combo01.TabIndex = 2
        Me.Combo01.Value = "Combo01"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(28, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 24)
        Me.Label3.TabIndex = 1366
        Me.Label3.Text = "Apple"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBox02
        '
        Me.CheckBox02.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox02.Location = New System.Drawing.Point(152, 64)
        Me.CheckBox02.Name = "CheckBox02"
        Me.CheckBox02.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox02.Size = New System.Drawing.Size(20, 24)
        Me.CheckBox02.TabIndex = 1
        Me.CheckBox02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(28, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 24)
        Me.Label2.TabIndex = 1368
        Me.Label2.Text = "一般"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'F90_Form04_01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(526, 295)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBox02)
        Me.Controls.Add(Me.cmb01)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Number02)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Number01)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb08)
        Me.Controls.Add(Me.cmb07)
        Me.Controls.Add(Me.Combo08)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Combo07)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F90_Form04_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入料金"
        CType(Me.Combo08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F90_Form04_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call dsp_set()  '** 画面セット
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Number01.Value = P_proc_y
        msg.Text = Nothing

    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()
        DB_OPEN("nQGCare")

        'Apple
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'APL') ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "cls_APL")
        Combo01.DataSource = DsCMB1.Tables("cls_APL")
        Combo01.DisplayMember = "cls_code_name"
        Combo01.ValueMember = "cls_code"

        '保証期間
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSK') ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "cls_HSK")
        Combo07.DataSource = DsCMB1.Tables("cls_HSK")
        Combo07.DisplayMember = "cls_code_name"
        Combo07.ValueMember = "cls_code"

        '保証範囲
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSY') ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "cls_HSY")
        Combo08.DataSource = DsCMB1.Tables("cls_HSY")
        Combo08.DisplayMember = "cls_code_name"
        Combo08.ValueMember = "cls_code"

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 画面セット
    '******************************************************************
    Sub dsp_set()
        If P_PRAM1 = Nothing Then   '新規
            Call clr()  '** 項目クリア
        Else                        '更新
            DsList1.Clear()
            strSQL = "SELECT M03_amnt.*, V_M02_APL.cls_code_name AS apple_name, V_M02_HSK.cls_code_name AS wrn_tem_name"
            strSQL += ", V_M02_HSY.cls_code_name AS wrn_range_name"
            strSQL += " FROM M03_amnt INNER JOIN"
            strSQL += " V_M02_HSK ON M03_amnt.wrn_tem = V_M02_HSK.cls_code INNER JOIN"
            strSQL += " V_M02_HSY ON M03_amnt.wrn_range = V_M02_HSY.cls_code INNER JOIN"
            strSQL += " V_M02_APL ON M03_amnt.apple = V_M02_APL.cls_code"
            strSQL += " WHERE (M03_amnt.nendo = " & P_proc_y & ")"
            strSQL += " AND (M03_amnt.ittpan = '" & P_PRAM1 & "')"
            strSQL += " AND (M03_amnt.apple = '" & P_PRAM2 & "')"
            strSQL += " AND (M03_amnt.wrn_tem = " & P_PRAM3 & ")"
            strSQL += " AND (M03_amnt.wrn_range = " & P_PRAM4 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "M03_amnt")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M03_amnt"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                If DtView1(0)("ittpan") = "True" Then CheckBox02.Checked = True Else CheckBox02.Checked = False
                CheckBox02.Enabled = False
                Combo01.Text = DtView1(0)("apple_name") : cmb01.Text = P_PRAM2 : Combo01.Enabled = False
                Combo07.Text = DtView1(0)("wrn_tem_name") : cmb07.Text = P_PRAM3 : Combo07.Enabled = False
                Combo08.Text = DtView1(0)("wrn_range_name") : cmb08.Text = P_PRAM4 : Combo08.Enabled = False
                Number02.Value = DtView1(0)("amnt")
            Else
                Call clr()  '** 項目クリア
            End If
        End If
    End Sub

    '******************************************************************
    '** 項目クリア
    '******************************************************************
    Sub clr()
        CheckBox02.Checked = False : CheckBox02.Enabled = True
        Combo01.Text = Nothing : Combo01.BackColor = System.Drawing.SystemColors.Window : cmb01.Text = Nothing : Combo01.Enabled = True
        Combo07.Text = Nothing : Combo07.BackColor = System.Drawing.SystemColors.Window : cmb07.Text = Nothing : Combo07.Enabled = True
        Combo08.Text = Nothing : Combo08.BackColor = System.Drawing.SystemColors.Window : cmb08.Text = Nothing : Combo08.Enabled = True
        Number02.Value = 0 : Number02.BackColor = System.Drawing.SystemColors.Window
        msg.Text = Nothing
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        If P_PRAM1 = Nothing Then   '新規

            Call CK_Combo01()
            If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

            Call CK_Combo07()
            If msg.Text <> Nothing Then Err_F = "1" : Combo07.Focus() : Exit Sub

            Call CK_Combo08()
            If msg.Text <> Nothing Then Err_F = "1" : Combo08.Focus() : Exit Sub

            Call CK_key()
            If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

        End If

        Call CK_Number02()
        If msg.Text <> Nothing Then Err_F = "1" : Number02.Focus() : Exit Sub

    End Sub
    Sub CK_Combo01()
        msg.Text = Nothing
        cmb01.Text = Nothing
        Combo01.Text = Trim(Combo01.Text)

        If Combo01.Text = Nothing Then
            msg.Text = "Appleの入力がありません。"
            Combo01.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            DtView1 = New DataView(DsCMB1.Tables("cls_APL"), "cls_code_name ='" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb01.Text = DtView1(0)("cls_code")
            Else
                msg.Text = "該当のAppleはありません。"
                Combo01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo07()
        msg.Text = Nothing
        cmb07.Text = Nothing
        Combo07.Text = Trim(Combo07.Text)

        If Combo07.Text = Nothing Then
            msg.Text = "保証期間の入力がありません。"
            Combo07.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            DtView1 = New DataView(DsCMB1.Tables("cls_HSK"), "cls_code_name ='" & Combo07.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb07.Text = DtView1(0)("cls_code")
            Else
                msg.Text = "該当の保証期間はありません。"
                Combo07.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo08()
        msg.Text = Nothing
        cmb08.Text = Nothing
        Combo08.Text = Trim(Combo08.Text)

        If Combo08.Text = Nothing Then
            msg.Text = "保証範囲の入力がありません。"
            Combo08.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            DtView1 = New DataView(DsCMB1.Tables("cls_HSY"), "cls_code_name ='" & Combo08.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb08.Text = DtView1(0)("cls_code")
            Else
                msg.Text = "該当の保証範囲はありません。"
                Combo08.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo08.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_key()
        msg.Text = Nothing

        If cmb01.Text <> Nothing And cmb07.Text <> Nothing And cmb08.Text <> Nothing Then
            WK_DsList1.Clear()
            strSQL = "SELECT nendo, wrn_tem, wrn_range"
            strSQL += " FROM M03_amnt"
            strSQL += " WHERE (nendo = " & P_proc_y & ")"
            If CheckBox02.Checked = True Then strSQL += " AND (ittpan = 1)" Else strSQL += " AND (ittpan = 0)"
            strSQL += " AND (apple = '" & cmb01.Text & "')"
            strSQL += " AND (wrn_tem = " & cmb07.Text & ")"
            strSQL += " AND (wrn_range = " & cmb08.Text & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "M03_amnt")
            DB_CLOSE()

            If r <> 0 Then
                msg.Text = "指定の年度、一般、Apple、保証期間、保証範囲は既に登録済みです。"
                CheckBox02.BackColor = System.Drawing.Color.Red
                Combo01.BackColor = System.Drawing.Color.Red
                Combo07.BackColor = System.Drawing.Color.Red
                Combo08.BackColor = System.Drawing.Color.Red
            Else
                CheckBox02.BackColor = System.Drawing.SystemColors.Window
                Combo01.BackColor = System.Drawing.SystemColors.Window
                Combo07.BackColor = System.Drawing.SystemColors.Window
                Combo08.BackColor = System.Drawing.SystemColors.Window
            End If
        End If
    End Sub
    Sub CK_Number02()
        msg.Text = Nothing

        If Number02.Value = 0 Then
            msg.Text = "加入料金の入力がありません。"
            Number02.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Number02.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub CheckBox02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox02.Click
        Call CK_key()
    End Sub
    Private Sub Combo01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.LostFocus
        Call CK_Combo01()
        If msg.Text = Nothing Then Call CK_key()
    End Sub
    Private Sub Combo07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo07.LostFocus
        Call CK_Combo07()
        If msg.Text = Nothing Then Call CK_key()
    End Sub
    Private Sub Combo08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo08.LostFocus
        Call CK_Combo08()
        If msg.Text = Nothing Then Call CK_key()
    End Sub
    Private Sub Number02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.LostFocus
        If msg.Text = Nothing Then Call CK_Number02()
    End Sub

    '******************************************************************
    '**更新
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** 項目チェック
        If Err_F = "0" Then

            DB_OPEN("nQGCare")
            If P_PRAM1 = Nothing Then   '新規
                strSQL = "INSERT INTO M03_amnt"
                strSQL += " (nendo, apple, wrn_tem, wrn_range, ittpan, amnt)"
                strSQL += " VALUES (" & Number01.Value
                strSQL += ", " & cmb01.Text
                strSQL += ", " & cmb07.Text
                strSQL += ", " & cmb08.Text
                If CheckBox02.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                strSQL += ", " & Number02.Value & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Else                        '更新
                strSQL = "UPDATE M03_amnt"
                strSQL += " SET amnt = " & Number02.Value
                strSQL += " WHERE (M03_amnt.nendo = " & P_proc_y & ")"
                strSQL += " AND (M03_amnt.ittpan = '" & P_PRAM1 & "')"
                strSQL += " AND (M03_amnt.apple = " & P_PRAM2 & ")"
                strSQL += " AND (M03_amnt.wrn_tem = " & P_PRAM3 & ")"
                strSQL += " AND (M03_amnt.wrn_range = " & P_PRAM4 & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
            DB_CLOSE()

            P_RTN = "1"
            DsList1.Clear()
            DsCMB1.Clear()
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        P_RTN = "0"
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB1.Clear()
        Close()
    End Sub
End Class
