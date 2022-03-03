Public Class F00_Form13
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL, Err_F As String
    Dim i, j, en, Line_No, cnt As Integer

    Private label(2, 3) As Label
    Private nbrBox(2, 1) As GrapeCity.Win.Input.Number
    Private chkBox(2, 2) As CheckBox

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(304, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 36)
        Me.Label2.TabIndex = 1812
        Me.Label2.Text = "枚数"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(284, 36)
        Me.Label1.TabIndex = 1811
        Me.Label1.Text = "報告書パターン"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 156)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(524, 24)
        Me.msg.TabIndex = 1810
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(20, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 108)
        Me.Panel1.TabIndex = 1807
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(20, 184)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(84, 32)
        Me.Button5.TabIndex = 1808
        Me.Button5.Text = "印刷"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(432, 180)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(80, 32)
        Me.Button98.TabIndex = 1809
        Me.Button98.Text = "ｷｬﾝｾﾙ"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(360, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 36)
        Me.Label3.TabIndex = 1813
        Me.Label3.Text = "部品番号印字"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(436, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 36)
        Me.Label4.TabIndex = 1814
        Me.Label4.Text = "保証期間印字"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F00_Form13
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(566, 224)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F00_Form13"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "作業報告書印刷"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msg.Text = Nothing
        DsSET()

        Line_No = 0

        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            DtView2 = New DataView(DsList1.Tables("CLS_CODE_024"), "cls_code ='" & DtView1(0)("rpr_rprt_ptn") & "'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then

                '印刷物
                en = 1
                label(Line_No, en) = New Label
                label(Line_No, en).Location = New System.Drawing.Point(0, 24 * Line_No)
                label(Line_No, en).Size = New System.Drawing.Size(284, 24)
                label(Line_No, en).TextAlign = ContentAlignment.MiddleLeft
                label(Line_No, en).BorderStyle = BorderStyle.Fixed3D
                label(Line_No, en).Text = DtView2(0)("cls_code_name")
                Panel1.Controls.Add(label(Line_No, en))

                '枚数
                en = 1
                nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
                nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "Null")
                nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                nbrBox(Line_No, en).Location = New System.Drawing.Point(284, 24 * Line_No)
                nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {9, 0, 0, 0})
                nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
                nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).Size = New System.Drawing.Size(56, 24)
                nbrBox(Line_No, en).HighlightText = True
                nbrBox(Line_No, en).TabIndex = Line_No
                nbrBox(Line_No, en).Tag = Line_No
                If DtView1(0)("grup_code") = "63" Then
                    nbrBox(Line_No, en).Value = 2
                Else
                    nbrBox(Line_No, en).Value = 1
                End If
                Panel1.Controls.Add(nbrBox(Line_No, en))
                AddHandler nbrBox(Line_No, en).GotFocus, AddressOf nbrBox_GotFocus
                AddHandler nbrBox(Line_No, en).LostFocus, AddressOf nbrBox_LostFocus

                '部品番号印字
                en = 1
                chkBox(Line_No, en) = New CheckBox
                chkBox(Line_No, en).Location = New System.Drawing.Point(340, 24 * Line_No)
                chkBox(Line_No, en).Size = New System.Drawing.Size(76, 25)
                chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
                chkBox(Line_No, en).Text = Nothing
                chkBox(Line_No, en).TabIndex = Line_No
                chkBox(Line_No, en).Tag = Line_No
                chkBox(Line_No, en).Checked = True
                Panel1.Controls.Add(chkBox(Line_No, en))
                AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK2_GotFocus
                AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK2_LostFocus

                '保証期間印字
                en = 2
                chkBox(Line_No, en) = New CheckBox
                chkBox(Line_No, en).Location = New System.Drawing.Point(416, 24 * Line_No)
                chkBox(Line_No, en).Size = New System.Drawing.Size(76, 25)
                chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
                chkBox(Line_No, en).Text = Nothing
                chkBox(Line_No, en).TabIndex = Line_No
                chkBox(Line_No, en).Tag = Line_No
                chkBox(Line_No, en).Checked = True
                Panel1.Controls.Add(chkBox(Line_No, en))
                AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK3_GotFocus
                AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK3_LostFocus

                ''枚
                'en = 2
                'label(Line_No, en) = New Label
                'label(Line_No, en).Location = New System.Drawing.Point(340, 24 * Line_No)
                'label(Line_No, en).Size = New System.Drawing.Size(30, 24)
                'label(Line_No, en).TextAlign = ContentAlignment.MiddleLeft
                'label(Line_No, en).Text = "枚"
                'Panel1.Controls.Add(label(Line_No, en))

                '印刷物CD
                en = 3
                label(Line_No, en) = New Label
                'label(Line_No, en).Location = New System.Drawing.Point(370, 24 * Line_No)
                'label(Line_No, en).Size = New System.Drawing.Size(30, 24)
                label(Line_No, en).Text = DtView1(0)("rpr_rprt_ptn")
                Panel1.Controls.Add(label(Line_No, en))

            Else
                Line_No = Line_No - 1
            End If

            If DtView1(0)("rpr_rprt_ptn") <> "00" Then '通常
                Line_No = Line_No + 1
                DtView2 = New DataView(DsList1.Tables("CLS_CODE_024"), "cls_code ='00'", "", DataViewRowState.CurrentRows)
                If DtView2.Count <> 0 Then

                    '印刷物
                    en = 1
                    label(Line_No, en) = New Label
                    label(Line_No, en).Location = New System.Drawing.Point(0, 24 * Line_No)
                    label(Line_No, en).Size = New System.Drawing.Size(284, 24)
                    label(Line_No, en).TextAlign = ContentAlignment.MiddleLeft
                    label(Line_No, en).BorderStyle = BorderStyle.Fixed3D
                    label(Line_No, en).Text = DtView2(0)("cls_code_name")
                    Panel1.Controls.Add(label(Line_No, en))

                    '枚数
                    en = 1
                    nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
                    nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "Null")
                    nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                    nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                    nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###,##0", "", "", "-", "", "", "")
                    nbrBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    nbrBox(Line_No, en).Location = New System.Drawing.Point(284, 24 * Line_No)
                    nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {9, 0, 0, 0})
                    nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
                    nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                    nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                    nbrBox(Line_No, en).Size = New System.Drawing.Size(56, 24)
                    nbrBox(Line_No, en).HighlightText = True
                    nbrBox(Line_No, en).TabIndex = Line_No
                    nbrBox(Line_No, en).Tag = Line_No
                    If DtView1(0)("grup_code") = "63" Then
                        nbrBox(Line_No, en).Value = 0
                    Else
                        nbrBox(Line_No, en).Value = 1
                    End If
                    Panel1.Controls.Add(nbrBox(Line_No, en))
                    AddHandler nbrBox(Line_No, en).GotFocus, AddressOf nbrBox_GotFocus
                    AddHandler nbrBox(Line_No, en).LostFocus, AddressOf nbrBox_LostFocus

                    '部品番号印字
                    en = 1
                    chkBox(Line_No, en) = New CheckBox
                    chkBox(Line_No, en).Location = New System.Drawing.Point(340, 24 * Line_No)
                    chkBox(Line_No, en).Size = New System.Drawing.Size(76, 25)
                    chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
                    chkBox(Line_No, en).Text = Nothing
                    chkBox(Line_No, en).TabIndex = Line_No
                    chkBox(Line_No, en).Tag = Line_No
                    chkBox(Line_No, en).Checked = True
                    Panel1.Controls.Add(chkBox(Line_No, en))
                    AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK2_GotFocus
                    AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK2_LostFocus

                    '保証期間印字
                    en = 2
                    chkBox(Line_No, en) = New CheckBox
                    chkBox(Line_No, en).Location = New System.Drawing.Point(416, 24 * Line_No)
                    chkBox(Line_No, en).Size = New System.Drawing.Size(76, 25)
                    chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
                    chkBox(Line_No, en).Text = Nothing
                    chkBox(Line_No, en).TabIndex = Line_No
                    chkBox(Line_No, en).Tag = Line_No
                    chkBox(Line_No, en).Checked = True
                    Panel1.Controls.Add(chkBox(Line_No, en))
                    AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK3_GotFocus
                    AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK3_LostFocus

                    ''枚
                    'en = 2
                    'label(Line_No, en) = New Label
                    'label(Line_No, en).Location = New System.Drawing.Point(340, 24 * Line_No)
                    'label(Line_No, en).Size = New System.Drawing.Size(30, 24)
                    'label(Line_No, en).TextAlign = ContentAlignment.MiddleLeft
                    'label(Line_No, en).Text = "枚"
                    'Panel1.Controls.Add(label(Line_No, en))

                    '印刷物CD
                    en = 3
                    label(Line_No, en) = New Label
                    'label(Line_No, en).Location = New System.Drawing.Point(370, 24 * Line_No)
                    'label(Line_No, en).Size = New System.Drawing.Size(30, 24)
                    label(Line_No, en).Text = "00"
                    Panel1.Controls.Add(label(Line_No, en))

                End If
            End If
        End If

    End Sub

    Sub DsSET()
        DsList1.Clear()
        DB_OPEN("nMVAR")

        strSQL = "SELECT store_code, rpr_rprt_ptn, grup_code FROM  M08_STORE WHERE (store_code = '" & P_PRAM2 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "M08_STORE")

        strSQL = "SELECT cls_code, cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '024') AND (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "CLS_CODE_024")

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub F_Check()
        Err_F = "0"
        cnt = 0

        '数量
        For i = 0 To Line_No
            cnt = cnt + nbrBox(i, 1).Value
        Next

        If cnt <= 0 Then
            nbrBox(0, 1).Focus()
            msg.Text = "枚数が指定されていません。"
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub nbrBox_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(nbr.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 2).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub nbrBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(nbr.Tag, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub CHK2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        chkBox(Lin.Tag, 1).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CHK3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        chkBox(Lin.Tag, 2).BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  印刷
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  項目チェック
        If Err_F = "0" Then

            For i = 0 To Line_No
                If nbrBox(i, 1).Value <> 0 Then
                    For j = 1 To nbrBox(i, 1).Value

                        PRT_PRAM1 = "Print_R_Sagyou_Report" '作業報告書印刷
                        PRT_PRAM2 = P_PRAM1
                        PRT_PRAM3 = label(i, 3).Text
                        PRT_PRAM4 = chkBox(i, 1).Checked
                        PRT_PRAM5 = chkBox(i, 2).Checked
                        Dim F70_Form01 As New F70_Form01
                        F70_Form01.ShowDialog()

                    Next
                End If
            Next
        End If
        Cursor = System.Windows.Forms.Cursors.Default
        P_RTN = "1"
        DsList1.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_RTN = "0"
        DsList1.Clear()
        Close()
    End Sub
End Class