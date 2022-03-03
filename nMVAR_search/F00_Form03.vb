Public Class F00_Form03
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim WK_DsList1 As New DataSet
    Dim WK_DtView1, WK_DtView2 As DataView

    Dim DtView1, DtView2 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, Err_F, ANS, tbl_name As String
    Dim i, en, Line_No1 As Integer
    Dim WK_SEQ, WK_ID As Integer

    '部品
    Private label(99, 1) As Label
    Private edit(99, 4) As GrapeCity.Win.Input.Interop.Edit
    Private nbrBox(99, 8) As GrapeCity.Win.Input.Interop.Number
    Private chkBox(99, 2) As CheckBox

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.msg = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 388)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(952, 20)
        Me.msg.TabIndex = 1235
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(980, 392)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 28)
        Me.Button98.TabIndex = 30
        Me.Button98.Text = "戻る"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(10, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1046, 336)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 32)
        Me.Label9.TabIndex = 1721
        Me.Label9.Text = "部品番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(188, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 32)
        Me.Label1.TabIndex = 1722
        Me.Label1.Text = "部品名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(416, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 32)
        Me.Label2.TabIndex = 1723
        Me.Label2.Text = "単価"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(480, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 32)
        Me.Label3.TabIndex = 1724
        Me.Label3.Text = "数量"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(980, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 32)
        Me.Label4.TabIndex = 1726
        Me.Label4.Text = "在庫使用"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(524, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 32)
        Me.Label5.TabIndex = 1727
        Me.Label5.Text = "GSS    計上"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(588, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 32)
        Me.Label6.TabIndex = 1728
        Me.Label6.Text = "EU価"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(716, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 32)
        Me.Label7.TabIndex = 1729
        Me.Label7.Text = "発注番号"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(824, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 32)
        Me.Label8.TabIndex = 1730
        Me.Label8.Text = "発受注番"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(652, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 32)
        Me.Label15.TabIndex = 1763
        Me.Label15.Text = "コスト"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(932, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 32)
        Me.Label10.TabIndex = 1764
        Me.Label10.Text = "IBM 緊急"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F00_Form03
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(1066, 428)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form03"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "部品入力"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
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

        If P_PRAM2 = "1" Then   '見積
            Label4.Visible = False
            tbl_name = "T04_REP_PART"
        Else                        '完了
            Label4.Visible = True
            tbl_name = "T04_REP_PART_2"
        End If

        msg.Text = Nothing
        P_RTN = "0"
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()

        '基準点
        label(0, 0) = New Label
        label(0, 0).Location = New System.Drawing.Point(0, 0)
        label(0, 0).Size = New System.Drawing.Size(0, 0)
        label(0, 0).Text = Nothing
        Panel1.Controls.Add(label(0, 0))

        DtView1 = New DataView(P_DsList1.Tables(tbl_name), "", "seq", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For Line_No1 = 0 To DtView1.Count - 1
                add_line("1")    '使用部品
            Next
            Line_No1 = Line_No1 - 1
        Else
            Line_No1 = -1
        End If
    End Sub

    '見積内容
    Sub add_line(ByVal flg)
        If flg = "0" Then Line_No1 = Line_No1 + 1

        '部品コード
        en = 1
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(1, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(176, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 20
        edit(Line_No1, en).Enabled = False
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            edit(Line_No1, en).Text = DtView1(Line_No1)("part_code")
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))

        '部品名
        en = 2
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(176, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(228, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 100
        edit(Line_No1, en).Enabled = False
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            edit(Line_No1, en).Text = DtView1(Line_No1)("part_name")
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))

        '単価
        en = 1
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberFormat("##,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberFormat("##,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(404, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(64, 25)
        nbrBox(Line_No1, en).Enabled = False
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("part_amnt")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        '数量
        en = 2
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberFormat("#0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberFormat("#0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(468, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(44, 25)
        nbrBox(Line_No1, en).Enabled = False
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("use_qty")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        'GSS計上
        en = 4
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(512, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(64, 25)
        nbrBox(Line_No1, en).Enabled = False
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("shop_chrg")) Then
                nbrBox(Line_No1, en).Value = DtView1(Line_No1)("shop_chrg")
            Else
                nbrBox(Line_No1, en).Value = 0
            End If
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        'EU価
        en = 5
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(576, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(64, 25)
        nbrBox(Line_No1, en).Enabled = False
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("eu_chrg")) Then
                nbrBox(Line_No1, en).Value = DtView1(Line_No1)("eu_chrg")
            Else
                nbrBox(Line_No1, en).Value = 0
            End If
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        'コスト
        en = 8
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(640, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(64, 25)
        nbrBox(Line_No1, en).Enabled = False
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("cost_chrg")) Then
                nbrBox(Line_No1, en).Value = DtView1(Line_No1)("cost_chrg")
            Else
                nbrBox(Line_No1, en).Value = 0
            End If
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        '発注番号
        en = 3
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(704, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(108, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).Enabled = False
        edit(Line_No1, en).MaxLength = 10
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("ordr_no")) Then
                edit(Line_No1, en).Text = DtView1(Line_No1)("ordr_no")
            Else
                edit(Line_No1, en).Text = Nothing
            End If
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))

        '発受注番
        en = 4
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(812, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(108, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).Enabled = False
        edit(Line_No1, en).MaxLength = 10
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("ordr_no2")) Then
                edit(Line_No1, en).Text = DtView1(Line_No1)("ordr_no2")
            Else
                edit(Line_No1, en).Text = Nothing
            End If
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))

        'IBM緊急
        en = 2
        chkBox(Line_No1, en) = New CheckBox
        chkBox(Line_No1, en).Location = New System.Drawing.Point(920, 25 * Line_No1)
        chkBox(Line_No1, en).Size = New System.Drawing.Size(48, 25)
        chkBox(Line_No1, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No1, en).Text = Nothing
        chkBox(Line_No1, en).TabIndex = Line_No1
        chkBox(Line_No1, en).Tag = Line_No1
        chkBox(Line_No1, en).AutoCheck = False
        If P1_F00_Form03 = "02" Then    'IBM
            chkBox(Line_No1, en).Visible = True
            If flg = "1" Then
                If Not IsDBNull(DtView1(Line_No1)("ibm_flg")) Then
                    If DtView1(Line_No1)("ibm_flg") = "True" Then
                        chkBox(Line_No1, en).Checked = True
                    Else
                        chkBox(Line_No1, en).Checked = False
                    End If
                Else
                    chkBox(Line_No1, en).Checked = False
                End If
            Else
                chkBox(Line_No1, en).Checked = False
            End If
        Else
            chkBox(Line_No1, en).Visible = False
            chkBox(Line_No1, en).Checked = False
        End If
        Panel1.Controls.Add(chkBox(Line_No1, en))

        '在庫使用
        en = 1
        chkBox(Line_No1, en) = New CheckBox
        chkBox(Line_No1, en).Location = New System.Drawing.Point(968, 25 * Line_No1)
        chkBox(Line_No1, en).Size = New System.Drawing.Size(48, 25)
        chkBox(Line_No1, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No1, en).Text = Nothing
        chkBox(Line_No1, en).AutoCheck = False
        chkBox(Line_No1, en).TabIndex = Line_No1
        chkBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("zaiko_flg")) Then
                If DtView1(Line_No1)("zaiko_flg") = "True" Then
                    chkBox(Line_No1, en).Checked = True
                Else
                    chkBox(Line_No1, en).Checked = False
                End If
            Else
                chkBox(Line_No1, en).Checked = False
            End If
        Else
            chkBox(Line_No1, en).Checked = False
        End If
        If P_PRAM2 = "1" Then   '見積
            chkBox(Line_No1, en).Visible = False
        Else
            chkBox(Line_No1, en).Visible = True
        End If
        Panel1.Controls.Add(chkBox(Line_No1, en))

        'ID
        en = 3
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(661, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(25, 25)
        nbrBox(Line_No1, en).Visible = False
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("ID_NO")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        'SEQ
        en = 1
        label(Line_No1, en) = New Label
        label(Line_No1, en).Location = New System.Drawing.Point(686, 25 * Line_No1 + label(0, 0).Location.Y)
        label(Line_No1, en).Size = New System.Drawing.Size(25, 25)
        label(Line_No1, en).Visible = False
        If flg = "1" Then
            label(Line_No1, en).Text = DtView1(Line_No1)("seq")
        Else
            label(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(label(Line_No1, en))
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
