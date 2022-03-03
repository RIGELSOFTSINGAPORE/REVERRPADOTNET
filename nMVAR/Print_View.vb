Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Export.Pdf
Public Class Print_View
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, printer, WK_str As String

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
    'Friend WithEvents Viewer1 As DataDynamics.ActiveReports.Viewer.Viewer
    Friend WithEvents Viewer1 As GrapeCity.ActiveReports.Viewer.Win.Viewer
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        'Me.Viewer1 = New DataDynamics.ActiveReports.Viewer.Viewer
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.PdfExport1 = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
        Me.SuspendLayout()
        '
        'Viewer1
        '
        Me.Viewer1.BackColor = System.Drawing.SystemColors.Control
        Me.Viewer1.Location = New System.Drawing.Point(8, 8)
        Me.Viewer1.Name = "Viewer1"
        Me.Viewer1.ReportViewer.CurrentPage = 0
        Me.Viewer1.ReportViewer.MultiplePageCols = 3
        Me.Viewer1.ReportViewer.MultiplePageRows = 2
        'Me.Viewer1.ReportViewer.RulerVisible = False
        Me.Viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal
        Me.Viewer1.Size = New System.Drawing.Size(984, 632)
        Me.Viewer1.TabIndex = 33
        Me.Viewer1.TableOfContents.Text = "Table Of Contents"
        Me.Viewer1.TableOfContents.Width = 200
        Me.Viewer1.Toolbar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.Viewer1.Toolbar.Visible = False
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(924, 648)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 34
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 652)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "印刷"
        '
        'Print_View
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Viewer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Print_View"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print_View"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Print_View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()
        DS_CRT(PRT_PRAM2)
        Select Case PRT_PRAM1
            Case Is = "Print_R_IBM_IW_Report"       '**  IBM保証報告書 (R_IBM_IW_Report)

                'データビューでプレビュー
                Dim rpt As New SectionReport_R_IBM_IW_Report
                Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                With rpt.Document.Printer
                    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                    ' .PaperKind = Printing.PaperKind.A4
                    .PaperSize = p1
                    ' .Landscape = True
                End With
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "Print_R_HP_Exc_TAG"          '**  Hp TAG印刷 (R_HP_Exc_TAG)

                'データビューでプレビュー
                Dim rpt As New SectionReport_R_HP_Exc_TAG
                Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                With rpt.Document.Printer
                    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                    ' .PaperKind = Printing.PaperKind.A4
                    .PaperSize = p1
                    ' .Landscape = True
                End With
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)
        End Select
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)
    End Sub

    '********************************************************************
    '**  DS作成
    '********************************************************************
    Public Function DS_CRT(ByVal rcpt_no)
        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_IBM_IW_Report_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        Dim myCI As New System.Globalization.CultureInfo("ja-JP", True)
        myCI.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        P_DtView1(0)("adrs1") = P_DtView1(0)("adrs1") & " " & P_DtView1(0)("adrs2")
        If PRT_PRAM1 = "Print_R_IBM_IW_Report" Then
            P_DtView1(0)("accp_date2_y") = CDate(P_DtView1(0)("accp_date")).ToString("yy", myCI)
        Else
            P_DtView1(0)("accp_date2_y") = Format(CDate(P_DtView1(0)("accp_date")), "yyyy")
        End If
        P_DtView1(0)("accp_date2_m") = CDate(P_DtView1(0)("accp_date")).ToString("MM", myCI)
        P_DtView1(0)("accp_date2_d") = CDate(P_DtView1(0)("accp_date")).ToString("dd", myCI)
        If Not IsDBNull(P_DtView1(0)("vndr_wrn_date")) Then
            If PRT_PRAM1 = "Print_R_IBM_IW_Report" Then
                P_DtView1(0)("vndr_wrn_date2_y") = CDate(P_DtView1(0)("vndr_wrn_date")).ToString("yy", myCI)
            Else
                P_DtView1(0)("vndr_wrn_date2_y") = Format(CDate(P_DtView1(0)("vndr_wrn_date")), "yyyy")
            End If
            P_DtView1(0)("vndr_wrn_date2_m") = CDate(P_DtView1(0)("vndr_wrn_date")).ToString("MM", myCI)
            P_DtView1(0)("vndr_wrn_date2_d") = CDate(P_DtView1(0)("vndr_wrn_date")).ToString("dd", myCI)
        End If
        If PRT_PRAM1 = "Print_R_IBM_IW_Report" Then
            P_DtView1(0)("comp_date2_y") = CDate(P_DtView1(0)("comp_date")).ToString("yy", myCI)
        Else
            P_DtView1(0)("comp_date2_y") = Format(CDate(P_DtView1(0)("comp_date")), "yyyy")
        End If
        P_DtView1(0)("comp_date2_m") = CDate(P_DtView1(0)("comp_date")).ToString("MM", myCI)
        P_DtView1(0)("comp_date2_d") = CDate(P_DtView1(0)("comp_date")).ToString("dd", myCI)

        '受付内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '修理内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram6 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram6.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print06")

        '部品データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print05")
        DB_CLOSE()
    End Function

    '********************************************************************
    '**  印刷
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        P_HSTY_DATE = Now

        Select Case PRT_PRAM1
            Case Is = "Print_R_IBM_IW_Report"       '**  IBM保証報告書 (R_IBM_IW_Report)

                '印刷日付
                DB_OPEN("nMVAR")
                strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & PRT_PRAM2 & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(DsList1, "T06_PRNT_DATE")
                DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    strSQL = "INSERT INTO T06_PRNT_DATE"
                    strSQL += " (rcpt_no, IBM_IW)"
                    strSQL += " VALUES ('" & PRT_PRAM2 & "'"
                    strSQL += ", '" & P_HSTY_DATE & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                Else
                    If IsDBNull(DtView1(0)("IBM_IW")) Then
                        strSQL = "UPDATE T06_PRNT_DATE"
                        strSQL += " SET IBM_IW = '" & P_HSTY_DATE & "'"
                        strSQL += " WHERE (rcpt_no = '" & PRT_PRAM2 & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                    End If
                End If
                DB_CLOSE()

                printer = PRT_GET("06")   '**  プリンタ名取得

                Dim rpt As New R_IBM_IW_Report
                Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                With rpt.Document.Printer
                    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                    ' .PaperKind = Printing.PaperKind.A4
                    .PaperSize = p1
                    ' .Landscape = True
                End With
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    'Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                    'p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "IBM保証報告書"
                    rpt.Document.Print(False, False, False)
                End If

                add_hsty(PRT_PRAM2, "IBM保証報告書印刷", "", "")

            Case Is = "Print_R_HP_Exc_TAG"          '**  Hp TAG印刷 (R_HP_Exc_TAG)

                '印刷日付
                DB_OPEN("nMVAR")
                strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & PRT_PRAM2 & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(DsList1, "T06_PRNT_DATE")
                DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    strSQL = "INSERT INTO T06_PRNT_DATE"
                    strSQL += " (rcpt_no, HP_TAG)"
                    strSQL += " VALUES ('" & PRT_PRAM2 & "'"
                    strSQL += ", '" & P_HSTY_DATE & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                Else
                    If IsDBNull(DtView1(0)("HP_TAG")) Then
                        strSQL = "UPDATE T06_PRNT_DATE"
                        strSQL += " SET HP_TAG = '" & P_HSTY_DATE & "'"
                        strSQL += " WHERE (rcpt_no = '" & PRT_PRAM2 & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                    End If
                End If
                DB_CLOSE()

                printer = PRT_GET("07")   '**  プリンタ名取得

                Dim rpt As New R_HP_Exc_TAG
                Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                With rpt.Document.Printer
                    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                    ' .PaperKind = Printing.PaperKind.A4
                    .PaperSize = p1
                    ' .Landscape = True
                End With
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    'Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                    'p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss"))
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "Hp TAG"
                    rpt.Document.Print(False, False, False)
                End If

                add_hsty(PRT_PRAM2, "Hp TAG印刷", "", "")

                Exit Sub
        End Select
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        P_DsPRT.Clear()
        Close()
    End Sub
End Class
