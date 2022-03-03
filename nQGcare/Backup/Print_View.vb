Public Class Print_View
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, printer As String
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
    Private WithEvents Viewer1 As DataDynamics.ActiveReports.Viewer.Viewer
    Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Viewer1 = New DataDynamics.ActiveReports.Viewer.Viewer
        Me.PdfExport1 = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Viewer1
        '
        Me.Viewer1.BackColor = System.Drawing.SystemColors.Control
        Me.Viewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewer1.Location = New System.Drawing.Point(0, 0)
        Me.Viewer1.Name = "Viewer1"
        Me.Viewer1.ReportViewer.CurrentPage = 0
        Me.Viewer1.ReportViewer.MultiplePageCols = 3
        Me.Viewer1.ReportViewer.MultiplePageRows = 2
        Me.Viewer1.ReportViewer.RulerVisible = False
        Me.Viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal
        Me.Viewer1.Size = New System.Drawing.Size(1002, 683)
        Me.Viewer1.TabIndex = 34
        Me.Viewer1.TableOfContents.Text = "Table Of Contents"
        Me.Viewer1.TableOfContents.Width = 200
        Me.Viewer1.Toolbar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(852, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Print_View
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Viewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Print_View"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "印刷プレビュー"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub Print_View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()              '**  初期処理

        Select Case PRT_PRAM1
            Case Is = "R_Kanyu_Normal"              '加入証
                printer = PRT_GET("01")

                'データビューでプレビュー
                Dim rpt As New R_Kanyu_Normal
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_Kanyu_iPad"                '加入証(iPad)
                printer = PRT_GET("01")

                'データビューでプレビュー
                Dim rpt As New R_Kanyu_iPad
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_member_list"               '加入者リスト
                printer = PRT_GET("01")

                Dim rpt As New R_member_list
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_member_list_iPad"          '加入者リストiPad
                printer = PRT_GET("01")

                Dim rpt As New R_member_list_iPad
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_neva"                      'ネバ伝
                printer = PRT_GET("02")

                Dim rpt As New R_neva
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_kakunin"                   '加入申込確認表
                printer = PRT_GET("01")

                Dim rpt As New R_kakunin
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

        End Select

        Me.Viewer1.Toolbar.Tools.RemoveAt(2)  ' デフォルトの印刷ボタンを削除します。

        ' カスタムボタンを作成します。
        Dim btn As New DataDynamics.ActiveReports.Toolbar.Button
        btn.Caption = "印刷"
        btn.ToolTip = printer
        btn.ImageIndex = 1
        btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
        btn.Id = 333
        Me.Viewer1.Toolbar.Tools.Insert(2, btn)

        Dim btn2 As New DataDynamics.ActiveReports.Toolbar.Button
        btn2.Caption = "閉じる"
        btn2.ToolTip = "閉じる"
        btn2.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
        btn2.Id = 334
        Me.Viewer1.Toolbar.Tools.Insert(22, btn2)

    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Label1.Text = P_PC_NAME
    End Sub

    '********************************************************************
    '**  ツールボタンクリック
    '********************************************************************
    Private Sub Viewer1_ToolClick(ByVal sender As Object, ByVal e As DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs) Handles Viewer1.ToolClick
        Select Case e.Tool.Id
            Case Is = 333
                prt()
            Case Is = 334 '**  戻る
                'P_DsPRT.Clear()
                Me.Close()
        End Select
    End Sub

    '********************************************************************
    '**  印刷
    '********************************************************************
    Sub prt()
        Select Case PRT_PRAM1
            Case Is = "R_Kanyu_Normal"              '加入証

                Dim rpt As New R_Kanyu_Normal
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "加入証"
                    rpt.Document.Print(False, False, False)
                End If

                '加入証印刷日付更新
                DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    strSQL = "UPDATE T01_member"
                    strSQL += " SET Part_prt = 1"
                    strSQL += ", Part_prt_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                    strSQL += " WHERE (code = '" & DtView1(i)("code") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN("nQGCare")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                Next

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_Kanyu_iPad"              '加入証(iPad)

                Dim rpt As New R_Kanyu_iPad
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "加入証(iPad)"
                    rpt.Document.Print(False, False, False)
                End If

                '加入証印刷日付更新
                DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    strSQL = "UPDATE T01_member"
                    strSQL += " SET Part_prt = 1"
                    strSQL += ", Part_prt_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                    strSQL += " WHERE (code = '" & DtView1(i)("code") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN("nQGCare")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                Next

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_member_list" '加入者リスト

                Dim rpt As New R_member_list
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "加入者リスト"
                    rpt.Document.Print(False, False, False)
                End If

                '請求日更新
                DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    WK_DsList1.Clear()
                    strSQL = "SELECT code, invc_date, invc_amnt FROM T02_clct WHERE (code = '" & DtView1(i)("code") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nQGCare")
                    DaList1.Fill(WK_DsList1, "T02_clct")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T02_clct"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count = 0 Then

                        strSQL = "INSERT INTO T02_clct"
                        strSQL += " (code, invc_date, invc_amnt, neva_arr_date, clct_stts)"
                        strSQL += " VALUES ('" & DtView1(i)("code") & "'"
                        strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
                        strSQL += ", " & DtView1(i)("wrn_fee")
                        strSQL += ", CONVERT(DATETIME, '" & neva_arr_date_Get(DtView1(i)("reg_date")) & "', 102)"
                        strSQL += ", '2')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nQGCare")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                    Else
                        If IsDBNull(WK_DtView1(0)("invc_date")) Then
                            strSQL = "UPDATE T02_clct"
                            strSQL += " SET invc_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                            strSQL += ", invc_amnt = " & DtView1(i)("wrn_fee")
                            strSQL += ", clct_stts = '2'"
                            strSQL += " WHERE (code = '" & DtView1(i)("code") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DB_OPEN("nQGCare")
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()
                        End If
                    End If

                Next
                MsgBox(printer & " に印刷しました。")

            Case Is = "R_member_list_iPad" '加入者リスト(iPad)

                Dim rpt As New R_member_list_iPad
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "加入者リスト"
                    rpt.Document.Print(False, False, False)
                End If

                '請求日更新
                DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    WK_DsList1.Clear()
                    strSQL = "SELECT code, invc_date, invc_amnt FROM T02_clct WHERE (code = '" & DtView1(i)("code") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nQGCare")
                    DaList1.Fill(WK_DsList1, "T02_clct")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T02_clct"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count = 0 Then

                        strSQL = "INSERT INTO T02_clct"
                        strSQL += " (code, invc_date, invc_amnt, neva_arr_date, clct_stts)"
                        strSQL += " VALUES ('" & DtView1(i)("code") & "'"
                        strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
                        strSQL += ", " & DtView1(i)("wrn_fee")
                        strSQL += ", CONVERT(DATETIME, '" & neva_arr_date_Get(DtView1(i)("reg_date")) & "', 102)"
                        strSQL += ", '2')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nQGCare")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                    Else
                        If IsDBNull(WK_DtView1(0)("invc_date")) Then
                            strSQL = "UPDATE T02_clct"
                            strSQL += " SET invc_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                            strSQL += ", invc_amnt = " & DtView1(i)("wrn_fee")
                            strSQL += ", clct_stts = '2'"
                            strSQL += " WHERE (code = '" & DtView1(i)("code") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DB_OPEN("nQGCare")
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()
                        End If
                    End If

                Next
                MsgBox(printer & " に印刷しました。")

            Case Is = "R_neva"             'ネバ伝

                Dim rpt As New R_neva
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "ネバ伝"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_kakunin"           '加入申込確認表

                Dim rpt As New R_kakunin
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "加入申込確認表"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

        End Select

    End Sub
End Class
