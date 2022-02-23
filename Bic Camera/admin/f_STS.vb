Public Class f_STS
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F, inz_F, UPD_F As String
    Dim i, j, en, line_no As Integer

    Private label(999, 2) As label
    Private panel(999, 1) As Panel
    Private Rbtn(999, 1) As RadioButton

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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(264, 432)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 32)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Close"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Panel1.Location = New System.Drawing.Point(16, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(352, 320)
        Me.Panel1.TabIndex = 2
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(186, 197)
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(80, 8)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(112, 24)
        Me.Date1.TabIndex = 1
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = Nothing
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "変更日"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(126, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "保証番号"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "OK"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(56, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "ｷｬﾝｾﾙ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(24, 432)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Submit"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(16, 400)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(352, 24)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Label5"
        '
        'f_STS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(386, 471)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "f_STS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ｽﾃｰﾀｽ変更確認"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '起動時
    Private Sub f_STS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()
        Call pnl_Set()
        Call msg()
    End Sub

    Sub inz()

        Date1.Text = Format(Now.Date, "yyyy/MM/dd")
        Err_F = DateAdd(DateInterval.Day, 1, CDate(Date1.Text))
        inz_F = "1"

    End Sub

    Sub pnl_Set()
        Panel1.Controls.Clear()

        DsList1.Clear()
        strSQL = "SELECT WRN_NO, UPD_DATE"
        strSQL = strSQL & " FROM STTS_F_UPD"
        strSQL = strSQL & " WHERE (UPD_DATE >= CONVERT(DATETIME, '" & Date1.Text & "', 102)"
        strSQL = strSQL & " AND UPD_DATE < CONVERT(DATETIME, '" & DateAdd(DateInterval.Day, 1, CDate(Date1.Text)) & "', 102))"
        strSQL = strSQL & " AND (UPD_F IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "STTS_F_UPD")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("STTS_F_UPD"), "", "WRN_NO", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1

                en = 0
                panel(i, en) = New Panel
                If i Mod 2 = 0 Then panel(i, en).BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
                panel(i, en).Location = New System.Drawing.Point(0, 22 * i)
                panel(i, en).Name = "Panel2"
                panel(i, en).Size = New System.Drawing.Size(110, 22)
                panel(i, en).TabIndex = 0
                Panel1.Controls.Add(panel(i, en))

                'OK
                en = 0
                Rbtn(i, en) = New RadioButton
                Rbtn(i, en).CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
                Rbtn(i, en).Location = New System.Drawing.Point(0, 0)
                Rbtn(i, en).Name = "RadioButton1"
                Rbtn(i, en).Size = New System.Drawing.Size(40, 22)
                Rbtn(i, en).TabIndex = 1
                panel(i, 0).Controls.Add(Rbtn(i, en))

                'ｷｬﾝｾﾙ
                en = 1
                Rbtn(i, en) = New RadioButton
                Rbtn(i, en).CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
                Rbtn(i, en).Location = New System.Drawing.Point(40, 0)
                Rbtn(i, en).Name = "RadioButton2"
                Rbtn(i, en).Size = New System.Drawing.Size(70, 22)
                Rbtn(i, en).TabIndex = 2
                panel(i, 0).Controls.Add(Rbtn(i, en))

                '保証番号
                en = 0
                label(i, en) = New Label
                If i Mod 2 = 0 Then label(i, en).BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
                label(i, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(i, en).Location = New System.Drawing.Point(110, 22 * i)
                label(i, en).Size = New System.Drawing.Size(220, 22)
                label(i, en).Text = Mid(DtView1(i)("WRN_NO"), 1, 4) & " " & Mid(DtView1(i)("WRN_NO"), 5, 4) & " " & Mid(DtView1(i)("WRN_NO"), 9, 4) & " " & Mid(DtView1(i)("WRN_NO"), 13, 4) & " " & Mid(DtView1(i)("WRN_NO"), 17, 4)
                Panel1.Controls.Add(label(i, en))

                en = 1
                label(i, en) = New Label
                label(i, en).Text = DtView1(i)("WRN_NO")

                en = 2
                label(i, en) = New Label
                label(i, en).Text = DtView1(i)("UPD_DATE")

            Next
            Button1.Visible = True
        Else
            en = 0
            label(i, en) = New Label
            label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            label(i, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(0, 150)
            label(i, en).Size = New System.Drawing.Size(350, 22)
            label(i, en).Text = "対象なし"
            Panel1.Controls.Add(label(i, en))

            Button1.Visible = False
        End If
        Date1.Focus()

    End Sub

    Sub msg()
        strSQL = "SELECT WRN_NO, UPD_DATE"
        strSQL = strSQL & " FROM STTS_F_UPD"
        strSQL = strSQL & " WHERE (UPD_F IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "STTS_F_UPD_cnt")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("STTS_F_UPD_cnt"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label5.Text = "現在、未確認データが　" & Format(DtView1.Count, "##,##0") & "件あります。"
        Else
            Label5.Text = "現在、未確認のデータはありません。"
        End If

    End Sub

    '入力後
    Private Sub Date1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date1.TextChanged
        If inz_F = "1" Then Call pnl_Set()
    End Sub

    'Submit
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        For j = 0 To i - 1
            If Rbtn(j, 0).Checked = True Then   'OK
                UPD_F = "1"
            Else
                If Rbtn(j, 1).Checked = True Then   'ｷｬﾝｾﾙ
                    UPD_F = "0"
                Else
                    UPD_F = ""
                End If
            End If

            If UPD_F <> "" Then
                strSQL = "UPDATE STTS_F_UPD"
                strSQL = strSQL & " SET UPD_DATE1 = CONVERT(DATETIME, '" & Now & "', 102)"
                strSQL = strSQL & ", UPD_F = '" & UPD_F & "'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & label(j, 1).Text & "')"
                strSQL = strSQL & " AND (UPD_DATE = CONVERT(DATETIME, '" & label(j, 2).Text & "', 102))"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            End If

            If UPD_F = "1" Then
                strSQL = "UPDATE WRN_DATA"
                strSQL = strSQL & " SET SALE_STS = '05'"
                strSQL = strSQL & " WHERE (WRN_NO = '" & label(j, 1).Text & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            End If
        Next

        Call pnl_Set()
        Call msg()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'Close
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DsList1.Clear()
        Me.Close()
        Dim f_menu As New f_menu
        f_menu.ShowDialog()
    End Sub
End Class
