Public Class f_CNT_MTR
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL As String
    Dim i, j, en As Integer

    Dim H_LTR As String
    Dim cnt As Integer

    Private label(9, 4) As label

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(464, 176)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 32)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Close"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(352, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Submit"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Panel1.Location = New System.Drawing.Point(24, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 132)
        Me.Panel1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(204, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "マスターの値"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(316, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "実際の最大値"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(428, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "調整値"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(24, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 23)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "カウンタの種類"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_CNT_MTR
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 18)
        Me.ClientSize = New System.Drawing.Size(582, 216)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "f_CNT_MTR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "カウンター調整"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '起動時
    Private Sub f_CNT_MTR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call pnl_Set()
    End Sub

    Sub pnl_Set()
        Panel1.Controls.Clear()
        Button1.Enabled = False
        DB_OPEN()

        DsList1.Clear()
        strSQL = "SELECT * FROM CNT_MTR WHERE (CNT_NO <> '002' AND CNT_NO <> '003')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "CNT_MTR")
        DtView1 = New DataView(DsList1.Tables("CNT_MTR"), "", "CNT_NO", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1

                'カウンタの種類
                en = 0
                label(i, en) = New Label
                label(i, en).Location = New System.Drawing.Point(0, 23 * i)
                label(i, en).Size = New System.Drawing.Size(180, 23)
                label(i, en).BorderStyle = BorderStyle.Fixed3D
                label(i, en).Text = Trim(DtView1(i)("CNT_RMRKS"))
                Panel1.Controls.Add(label(i, en))

                'マスターの値
                en = 1
                label(i, en) = New Label
                label(i, en).Location = New System.Drawing.Point(180, 23 * i)
                label(i, en).Size = New System.Drawing.Size(112, 23)
                label(i, en).BorderStyle = BorderStyle.Fixed3D
                Select Case DtView1(i)("CNT_NO")
                    Case Is = "001" '受付番号
                        label(i, en).Text = Trim(DtView1(i)("H_LTR")) & Format(DtView1(i)("CNT"), "0000")
                    Case Is = "004" '修理受付番号（引取）
                        label(i, en).Text = "8099" & Format(DtView1(i)("CNT"), "0000")
                    Case Is = "005" '修理受付番号（出張）
                        label(i, en).Text = "8999" & Format(DtView1(i)("CNT"), "0000")
                    Case Is = "006" '問合番号
                        label(i, en).Text = Trim(DtView1(i)("H_LTR")) & Format(DtView1(i)("CNT"), "0000")
                End Select
                Panel1.Controls.Add(label(i, en))

                '実際の最大値
                DsList2.Clear()
                Select Case DtView1(i)("CNT_NO")
                    Case Is = "001" '受付番号
                        strSQL = "SELECT MAX(ICDT_NO) AS [MAX] FROM ICDT_DATA"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(DsList2, "MAX_001")
                        DtView2 = New DataView(DsList2.Tables("MAX_001"), "", "", DataViewRowState.CurrentRows)
                    Case Is = "004" '修理受付番号（引取）
                        strSQL = "SELECT MAX(REPAIR_CODE) AS [MAX] FROM REPAIR_DATA WHERE (REPAIR_CODE LIKE '8099%')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(DsList2, "MAX_004")
                        DtView2 = New DataView(DsList2.Tables("MAX_004"), "", "", DataViewRowState.CurrentRows)
                    Case Is = "005" '修理受付番号（出張）
                        strSQL = "SELECT MAX(REPAIR_CODE) AS [MAX] FROM REPAIR_DATA WHERE (REPAIR_CODE LIKE '8999%')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(DsList2, "MAX_005")
                        DtView2 = New DataView(DsList2.Tables("MAX_005"), "", "", DataViewRowState.CurrentRows)
                    Case Is = "006" '問合番号
                        strSQL = "SELECT MAX(Q_NO) AS [MAX] FROM INQUIRY_DATA"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(DsList2, "MAX_006")
                        DtView2 = New DataView(DsList2.Tables("MAX_006"), "", "", DataViewRowState.CurrentRows)
                End Select

                en = 2
                label(i, en) = New Label
                label(i, en).Location = New System.Drawing.Point(292, 23 * i)
                label(i, en).Size = New System.Drawing.Size(112, 23)
                label(i, en).BorderStyle = BorderStyle.Fixed3D
                If DtView2.Count <> 0 Then
                    If Not IsDBNull(DtView2(0)("MAX")) Then
                        label(i, en).Text = Trim(DtView2(0)("MAX"))
                    Else
                        label(i, en).Text = Nothing
                    End If
                Else
                    label(i, en).Text = Nothing
                End If
                Panel1.Controls.Add(label(i, en))

                '調整値
                en = 3
                label(i, en) = New Label
                label(i, en).Location = New System.Drawing.Point(404, 23 * i)
                label(i, en).Size = New System.Drawing.Size(112, 23)
                label(i, en).BorderStyle = BorderStyle.Fixed3D
                If label(i, 1).Text < label(i, 2).Text Then
                    label(i, en).Text = label(i, 2).Text
                    Button1.Enabled = True
                Else
                    label(i, en).Text = Nothing
                End If
                Panel1.Controls.Add(label(i, en))

                'CNT_NO
                en = 4
                label(i, en) = New Label
                'label(i, en).Location = New System.Drawing.Point(516, 23 * i)
                'label(i, en).Size = New System.Drawing.Size(100, 23)
                label(i, en).Text = Trim(DtView1(i)("CNT_NO"))
                Panel1.Controls.Add(label(i, en))

            Next
        Else
            en = 0
            label(i, en) = New Label
            label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            label(i, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(0, 150)
            label(i, en).Size = New System.Drawing.Size(350, 22)
            label(i, en).Text = "対象なし"
            Panel1.Controls.Add(label(i, en))

        End If

        DB_CLOSE()
    End Sub

    'Submit
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()

        For j = 0 To i - 1
            If label(j, 3).Text <> Nothing Then   '修正

                strSQL = "UPDATE CNT_MTR"
                Select Case label(j, 4).Text
                    Case Is = "001" '受付番号
                        strSQL = strSQL & " SET CNT = " & Mid(label(j, 3).Text, 2, 4) * 1 & ""
                        strSQL = strSQL & ", H_LTR = '" & Mid(label(j, 3).Text, 1, 1) & "'"

                    Case Is = "004" '修理受付番号（引取）
                        strSQL = strSQL & " SET CNT = " & Mid(label(j, 3).Text, 5, 4) * 1 & ""
                        strSQL = strSQL & ", H_LTR = NULL"

                    Case Is = "005" '修理受付番号（出張）
                        strSQL = strSQL & " SET CNT = " & Mid(label(j, 3).Text, 5, 4) * 1 & ""
                        strSQL = strSQL & ", H_LTR = NULL"

                    Case Is = "006" '問合番号
                        strSQL = strSQL & " SET CNT = " & Mid(label(j, 3).Text, 2, 4) * 1 & ""
                        strSQL = strSQL & ", H_LTR = '" & Mid(label(j, 3).Text, 1, 1) & "'"

                End Select

                strSQL = strSQL & " WHERE (CNT_NO = '" & label(j, 4).Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()

            End If
        Next

        DB_CLOSE()
        Call pnl_Set()
        MsgBox("調整しました。")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'Close
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Dim f_menu As New f_menu
        f_menu.ShowDialog()
    End Sub
End Class
