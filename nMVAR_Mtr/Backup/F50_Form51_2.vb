Public Class F50_Form51_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList2, WK_DsList3 As New DataSet
    Dim DtView1, WK_DtView2, WK_DtView3 As DataView

    Dim strSQL, Err_F As String
    Dim en, Line_No, i, j As Integer
    Dim M_CLS As String = "M31"

    Dim WK_shinki As String
    Dim WK_HSTY_BF, WK_HSTY_AF As String

    Private nbrBox(99, 4) As GrapeCity.Win.Input.Number

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
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pos = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Navy
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(296, 24)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(90, 24)
        Me.Label33.TabIndex = 1286
        Me.Label33.Text = "調整額"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Navy
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(208, 24)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(88, 24)
        Me.Label32.TabIndex = 1285
        Me.Label32.Text = "利益率"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(24, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(184, 24)
        Me.Label12.TabIndex = 1284
        Me.Label12.Text = "金額範囲"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.pos)
        Me.Panel1.Location = New System.Drawing.Point(24, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 208)
        Me.Panel1.TabIndex = 1287
        '
        'pos
        '
        Me.pos.Location = New System.Drawing.Point(0, 0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(0, 0)
        Me.pos.TabIndex = 0
        Me.pos.Text = "pos"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(24, 268)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(392, 24)
        Me.msg.TabIndex = 1291
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(260, 300)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(68, 32)
        Me.Button80.TabIndex = 1289
        Me.Button80.Text = "履歴"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 300)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1288
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(348, 300)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 1290
        Me.Button98.Text = "戻る"
        '
        'F50_Form51_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(442, 344)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form51_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部品掛率マスタ"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form51_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        P_RTN3 = "0"
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        Panel1.Controls.Clear()
        DsList1.Clear()
        Line_No = 0

        '部品掛率マスタ
        strSQL = "SELECT strt_amnt, end_amnt, part_rate, part_amnt"
        strSQL +=  " FROM M31_PART_RATE"
        strSQL +=  " WHERE (store_code = '" & P_PRAM2 & "')"
        strSQL +=  " AND (vndr_code = '" & P_PRAM3 & "')"
        strSQL +=  " AND (note_kbn = '" & P_PRAM4 & "')"
        strSQL +=  " AND (own_rpat_kbn = '" & P_PRAM5 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M31_PART_RATE")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("M31_PART_RATE"), "", "strt_amnt", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For Line_No = 0 To DtView1.Count - 1

                '開始金額
                en = 1
                nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
                nbrBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                If Line_No = 0 Then nbrBox(Line_No, en).Enabled = False
                nbrBox(Line_No, en).HighlightText = True
                nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).Location = New System.Drawing.Point(0, 24 * Line_No + pos.Location.Y)
                nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
                nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
                nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).Size = New System.Drawing.Size(90, 24)
                nbrBox(Line_No, en).Value = DtView1(Line_No)("strt_amnt")
                nbrBox(Line_No, en).Tag = Line_No
                Panel1.Controls.Add(nbrBox(Line_No, en))
                AddHandler nbrBox(Line_No, en).KeyDown, AddressOf QTY1_KeyDown
                AddHandler nbrBox(Line_No, en).Leave, AddressOf QTY1_Leave
                AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY1_GotFocus
                AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY1_LostFocus

                '終了金額
                en = 2
                nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
                nbrBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                nbrBox(Line_No, en).Enabled = False
                nbrBox(Line_No, en).HighlightText = True
                nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).Location = New System.Drawing.Point(90, 24 * Line_No + pos.Location.Y)
                nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
                nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
                nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).Size = New System.Drawing.Size(90, 24)
                nbrBox(Line_No, en).Value = DtView1(Line_No)("end_amnt")
                nbrBox(Line_No, en).Tag = Line_No
                Panel1.Controls.Add(nbrBox(Line_No, en))

                '利益率
                en = 3
                nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
                nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00", "", "", "-", "", "", "")
                nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                nbrBox(Line_No, en).HighlightText = True
                nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("0.00", "", "", "-", "", "", "")
                nbrBox(Line_No, en).Location = New System.Drawing.Point(180, 24 * Line_No + pos.Location.Y)
                nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {9.99, 0, 0, 0})
                nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
                nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).Size = New System.Drawing.Size(90, 24)
                nbrBox(Line_No, en).Value = DtView1(Line_No)("part_rate")
                nbrBox(Line_No, en).Tag = Line_No
                Panel1.Controls.Add(nbrBox(Line_No, en))
                AddHandler nbrBox(Line_No, en).KeyDown, AddressOf QTY3_KeyDown
                AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY3_GotFocus
                AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY3_LostFocus

                '調整額
                en = 4
                nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
                nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                nbrBox(Line_No, en).HighlightText = True
                nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).Location = New System.Drawing.Point(270, 24 * Line_No + pos.Location.Y)
                nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
                nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
                nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).Size = New System.Drawing.Size(90, 24)
                nbrBox(Line_No, en).Value = DtView1(Line_No)("part_amnt")
                nbrBox(Line_No, en).Tag = Line_No
                Panel1.Controls.Add(nbrBox(Line_No, en))
                AddHandler nbrBox(Line_No, en).KeyDown, AddressOf QTY4_KeyDown
                AddHandler nbrBox(Line_No, en).Leave, AddressOf QTY4_Leave
                AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY4_GotFocus
                AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY4_LostFocus

            Next
        End If
        PNL_ADD()
    End Sub

    '********************************************************************
    '**  パネル追加
    '********************************************************************
    Sub PNL_ADD()

        '開始金額
        en = 1
        nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
        nbrBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
        If Line_No = 0 Then nbrBox(Line_No, en).Enabled = False
        nbrBox(Line_No, en).HighlightText = True
        nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).Location = New System.Drawing.Point(0, 24 * Line_No + pos.Location.Y)
        nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).Size = New System.Drawing.Size(90, 24)
        If Line_No = 0 Then nbrBox(Line_No, en).Value = 1 Else nbrBox(Line_No, en).Value = 0
        nbrBox(Line_No, en).Tag = Line_No
        Panel1.Controls.Add(nbrBox(Line_No, en))
        AddHandler nbrBox(Line_No, en).KeyDown, AddressOf QTY1_KeyDown
        AddHandler nbrBox(Line_No, en).Leave, AddressOf QTY1_Leave
        AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY1_GotFocus
        AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY1_LostFocus

        '終了金額
        en = 2
        nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
        nbrBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
        nbrBox(Line_No, en).Enabled = False
        nbrBox(Line_No, en).HighlightText = True
        nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).Location = New System.Drawing.Point(90, 24 * Line_No + pos.Location.Y)
        nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).Size = New System.Drawing.Size(90, 24)
        nbrBox(Line_No, en).Value = 0
        nbrBox(Line_No, en).Tag = Line_No
        Panel1.Controls.Add(nbrBox(Line_No, en))

        '利益率
        en = 3
        nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
        nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00", "", "", "-", "", "", "")
        nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
        nbrBox(Line_No, en).HighlightText = True
        nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("0.00", "", "", "-", "", "", "")
        nbrBox(Line_No, en).Location = New System.Drawing.Point(180, 24 * Line_No + pos.Location.Y)
        nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {9.99, 0, 0, 0})
        nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).Size = New System.Drawing.Size(90, 24)
        nbrBox(Line_No, en).Value = 0
        nbrBox(Line_No, en).Tag = Line_No
        Panel1.Controls.Add(nbrBox(Line_No, en))
        AddHandler nbrBox(Line_No, en).KeyDown, AddressOf QTY3_KeyDown
        AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY3_GotFocus
        AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY3_LostFocus

        '調整額
        en = 4
        nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
        nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
        nbrBox(Line_No, en).HighlightText = True
        nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).Location = New System.Drawing.Point(270, 24 * Line_No + pos.Location.Y)
        nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).Size = New System.Drawing.Size(90, 24)
        nbrBox(Line_No, en).Value = 0
        nbrBox(Line_No, en).Tag = Line_No
        Panel1.Controls.Add(nbrBox(Line_No, en))
        AddHandler nbrBox(Line_No, en).KeyDown, AddressOf QTY4_KeyDown
        AddHandler nbrBox(Line_No, en).Leave, AddressOf QTY4_Leave
        AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY4_GotFocus
        AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY4_LostFocus

        Line_No = Line_No + 1
    End Sub

    '********************************************************************
    '**  KeyDown
    '********************************************************************
    Private Sub QTY1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        If e.KeyCode = Keys.Enter Then
            QTY1_Leave(sender, e)
            nbrBox(nbr.Tag, 3).Focus()
        End If
    End Sub
    Private Sub QTY3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        If e.KeyCode = Keys.Enter Then
            nbrBox(nbr.Tag, 4).Focus()
        End If
    End Sub
    Private Sub QTY4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        If e.KeyCode = Keys.Enter Then
            QTY4_Leave(sender, e)
            If nbr.Tag = Line_No - 1 Then
                Button1.Focus()
            Else
                nbrBox(nbr.Tag + 1, 1).Focus()
            End If
        End If
    End Sub

    '********************************************************************
    '**  Leave
    '********************************************************************
    Private Sub QTY1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        If nbrBox(nbr.Tag, 1).Value = 0 Then
            nbrBox(nbr.Tag, 2).Value = 0
            nbrBox(nbr.Tag, 3).Value = 0
            nbrBox(nbr.Tag, 4).Value = 0

            If nbr.Tag = Line_No - 1 Then       '最後
                For i = nbr.Tag To 0 Step -1
                    If nbrBox(i, 1).Value <> 0 Then
                        nbrBox(i, 2).Value = 999999
                        Exit For
                    End If
                Next
            Else                                '中間
                For i = nbr.Tag To 0 Step -1
                    If nbrBox(i, 1).Value <> 0 Then
                        For j = nbr.Tag To Line_No - 1
                            If nbrBox(j, 1).Value <> 0 Then
                                nbrBox(i, 2).Value = nbrBox(j, 1).Value - 1
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                Next
            End If
        Else
            For i = nbr.Tag - 1 To 0 Step -1
                If nbrBox(i, 1).Value <> 0 Then
                    nbrBox(i, 2).Value = nbrBox(nbr.Tag, 1).Value - 1
                    Exit For
                End If
            Next
            If nbr.Tag = Line_No - 1 Then       '最後
            Else                                '中間
                For j = nbr.Tag + 1 To Line_No - 1
                    If nbrBox(j, 1).Value <> 0 Then
                        nbrBox(nbr.Tag, 2).Value = nbrBox(j, 1).Value - 1
                        Exit For
                    End If
                Next
            End If

        End If
    End Sub
    Private Sub QTY4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        If nbrBox(nbr.Tag, 1).Value <> 0 Then
            If nbr.Tag = Line_No - 1 Then
                PNL_ADD()
                nbrBox(nbr.Tag + 1, 1).Focus()
            End If
        End If
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub QTY1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(nbr.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub QTY3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(nbr.Tag, 3).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub QTY4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(nbr.Tag, 4).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub QTY1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(nbr.Tag, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub QTY3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(nbr.Tag, 3).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub QTY4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(nbr.Tag, 4).BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        msg.Text = Nothing
        Err_F = "0"

        For i = Line_No - 1 To 0 Step -1
            '開始金額
            If nbrBox(i, 1).Value <> 0 Then
                nbrBox(i, 2).Value = 999999
                Exit For
            End If
        Next
        For i = 1 To Line_No - 1
            '開始金額
            If nbrBox(i, 1).Value <> 0 Then
                If nbrBox(i, 1).Value <= nbrBox(i - 1, 1).Value Then
                    msg.Text = "金額範囲の設定が正しくありません。"
                    nbrBox(i, 1).Focus()
                    Err_F = "1"
                    Exit For
                End If
                'If nbrBox(i, 1).Value <> 0 And nbrBox(i - 1, 1).Value = 0 Then
                '    msg.Text = "金額範囲の設定が正しくありません。"
                '    nbrBox(i, 1).Focus()
                '    Err_F = "1"
                '    Exit For
                'End If
            End If
        Next
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_HSTY_DATE = Now
        F_Check()   '**  項目チェック
        If Err_F = "0" Then

            WK_DsList2.Clear()
            If P_PRAM6 = "0" Then
                strSQL = "SELECT store_code FROM M08_STORE WHERE (store_code = '" & P_PRAM2 & "')"
            Else
                strSQL = "SELECT M08_STORE_1.store_code"
                strSQL +=  " FROM M08_STORE INNER JOIN M08_STORE M08_STORE_1 ON M08_STORE.grup_code = M08_STORE_1.grup_code"
                strSQL +=  " WHERE (M08_STORE.store_code = '" & P_PRAM2 & "')"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList2, "M08_STORE")
            DB_CLOSE()
            WK_DtView2 = New DataView(WK_DsList2.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To WK_DtView2.Count - 1

                '部品掛率マスタ
                WK_DsList3.Clear()
                strSQL = "SELECT strt_amnt, end_amnt, part_rate, part_amnt"
                strSQL +=  " FROM M31_PART_RATE"
                strSQL +=  " WHERE (store_code = '" & WK_DtView2(j)("store_code") & "')"
                strSQL +=  " AND (vndr_code = '" & P_PRAM3 & "')"
                strSQL +=  " AND (note_kbn = '" & P_PRAM4 & "')"
                strSQL +=  " AND (own_rpat_kbn = '" & P_PRAM5 & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList3, "M31_PART_RATE")
                DB_CLOSE()
                WK_DtView3 = New DataView(WK_DsList3.Tables("M31_PART_RATE"), "", "strt_amnt", DataViewRowState.CurrentRows)
                If WK_DtView3.Count <> 0 Then
                    WK_HSTY_BF = Nothing
                    For i = 0 To WK_DtView3.Count - 1
                        If i > 0 Then
                            WK_HSTY_BF = WK_HSTY_BF & System.Environment.NewLine
                        End If
                        WK_HSTY_BF = WK_HSTY_BF & Format(WK_DtView3(i)("strt_amnt"), "###,##0").PadLeft(9, " ")
                        WK_HSTY_BF = WK_HSTY_BF & Format(WK_DtView3(i)("end_amnt"), "###,##0").PadLeft(9, " ")
                        WK_HSTY_BF = WK_HSTY_BF & Format(WK_DtView3(i)("part_rate"), "##0.00").PadLeft(8, " ")
                        WK_HSTY_BF = WK_HSTY_BF & Format(WK_DtView3(i)("part_amnt"), "###,##0").PadLeft(9, " ")
                    Next

                    strSQL = "DELETE FROM M31_PART_RATE"
                    strSQL +=  " WHERE (store_code = '" & WK_DtView2(j)("store_code") & "')"
                    strSQL +=  " AND (vndr_code = '" & P_PRAM3 & "')"
                    strSQL +=  " AND (note_kbn = '" & P_PRAM4 & "')"
                    strSQL +=  " AND (own_rpat_kbn = '" & P_PRAM5 & "')"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                    WK_shinki = "0"
                Else
                    WK_shinki = "1"
                End If

                For i = 0 To Line_No - 1
                    If nbrBox(i, 1).Value <> 0 Then
                        strSQL = "INSERT INTO M31_PART_RATE"
                        strSQL +=  " (store_code, vndr_code, note_kbn, own_rpat_kbn, strt_amnt, end_amnt, part_rate, part_amnt, reg_date, delt_flg)"
                        strSQL +=  " VALUES ('" & WK_DtView2(j)("store_code") & "'"
                        strSQL +=  ", '" & P_PRAM3 & "'"
                        strSQL +=  ", '" & P_PRAM4 & "'"
                        strSQL +=  ", '" & P_PRAM5 & "'"
                        strSQL +=  ", " & nbrBox(i, 1).Value
                        strSQL +=  ", " & nbrBox(i, 2).Value
                        strSQL +=  ", " & nbrBox(i, 3).Value
                        strSQL +=  ", " & nbrBox(i, 4).Value
                        strSQL +=  ", '" & Now.Date & "'"
                        strSQL += ", 0"
                        strSQL += ")"
                        DB_OPEN("nMVAR")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                Next

                If WK_shinki = "1" Then     '新規
                    add_MTR_hsty(M_CLS, WK_DtView2(j)("store_code") & P_PRAM3 & P_PRAM4 & P_PRAM5, "新規登録", "", "")
                Else                        '修正
                    DsList1.Clear()
                    strSQL = "SELECT strt_amnt, end_amnt, part_rate, part_amnt"
                    strSQL +=  " FROM M31_PART_RATE"
                    strSQL +=  " WHERE (store_code = '" & WK_DtView2(j)("store_code") & "')"
                    strSQL +=  " AND (vndr_code = '" & P_PRAM3 & "')"
                    strSQL +=  " AND (note_kbn = '" & P_PRAM4 & "')"
                    strSQL +=  " AND (own_rpat_kbn = '" & P_PRAM5 & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(DsList1, "M31_PART_RATE")
                    DB_CLOSE()
                    DtView1 = New DataView(DsList1.Tables("M31_PART_RATE"), "", "strt_amnt", DataViewRowState.CurrentRows)
                    If DtView1.Count <> 0 Then
                        WK_HSTY_AF = Nothing
                        For i = 0 To DtView1.Count - 1
                            If i > 0 Then
                                WK_HSTY_AF = WK_HSTY_AF & System.Environment.NewLine
                            End If
                            WK_HSTY_AF = WK_HSTY_AF & Format(DtView1(i)("strt_amnt"), "###,##0").PadLeft(9, " ")
                            WK_HSTY_AF = WK_HSTY_AF & Format(DtView1(i)("end_amnt"), "###,##0").PadLeft(9, " ")
                            WK_HSTY_AF = WK_HSTY_AF & Format(DtView1(i)("part_rate"), "##0.00").PadLeft(8, " ")
                            WK_HSTY_AF = WK_HSTY_AF & Format(DtView1(i)("part_amnt"), "###,##0").PadLeft(9, " ")
                        Next
                    End If
                    If WK_HSTY_BF <> WK_HSTY_AF Then
                        add_MTR_hsty(M_CLS, WK_DtView2(j)("store_code") & P_PRAM3 & P_PRAM4 & P_PRAM5, "部品掛率", WK_HSTY_BF, WK_HSTY_AF)
                    End If

                End If
            Next
            MessageBox.Show("更新しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

            P_RTN3 = "1"
            Button98_Click(sender, e)
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  履歴
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '変更履歴
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L02_MTR_HSTY", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 3)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 20)
        Pram3.Value = M_CLS
        Pram4.Value = P_PRAM2 & P_PRAM3 & P_PRAM4 & P_PRAM5
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        Close()
    End Sub
End Class
