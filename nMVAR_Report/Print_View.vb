Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Export.Pdf

Public Class Print_View
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim strSQL, printer As String
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button

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
    ' Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Print_View))
        Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Viewer1
        '
        Me.Viewer1.BackColor = System.Drawing.SystemColors.Control
        Me.Viewer1.CurrentPage = 0
        Me.Viewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewer1.Location = New System.Drawing.Point(0, 0)
        Me.Viewer1.Name = "Viewer1"
        Me.Viewer1.PreviewPages = 0
        '
        '
        '
        '
        '
        '
        Me.Viewer1.Sidebar.ParametersPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.ParametersPanel.Width = 267
        '
        '
        '
        Me.Viewer1.Sidebar.SearchPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.SearchPanel.Width = 267
        '
        '
        '
        Me.Viewer1.Sidebar.ThumbnailsPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.ThumbnailsPanel.Width = 267
        Me.Viewer1.Sidebar.ThumbnailsPanel.Zoom = 0.1R
        '
        '
        '
        Me.Viewer1.Sidebar.TocPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.TocPanel.Expanded = True
        Me.Viewer1.Sidebar.TocPanel.Text = "Table Of Contents"
        Me.Viewer1.Sidebar.TocPanel.Width = 267
        Me.Viewer1.Sidebar.Width = 267
        Me.Viewer1.Size = New System.Drawing.Size(1002, 688)
        Me.Viewer1.TabIndex = 33
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(930, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 33)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "閉じる"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(866, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 33)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "PDF"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Print_View
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Viewer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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

        Select Case PRT_PRAM1
            Case Is = "R_Sals_Report"               '**  売上集計 (R_Sals_Report)

                'データビューでプレビュー
                'Dim rpt As New R_Sals_Report
                Dim rpt As New SectionReport5
                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_Sals_day_Report"           '**  日別集計 (R_Sals_day_Report)

                'データビューでプレビュー
                'Dim rpt As New R_Sals_day_Report
                Dim rpt As New SectionReport1

                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With

                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With

                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print02"
                'rpt.Document.Name = "Print02"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_Sals_Empl_Report"          '**  修理担当者別集計 (R_Sals_Empl_Report)

                'データビューでプレビュー
                'Dim rpt As New R_Sals_Empl_Report

                Dim rpt As New SectionReport2

                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With

                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_Sals_Report_WC"            '**  売上集計 保証/有償 (R_Sals_Report_WC)

                'データビューでプレビュー
                'Dim rpt As New R_Sals_Report_WC
                Dim rpt As New SectionReport4
                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With

                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

        End Select

        'Me.Viewer1.Toolbar.Tools.RemoveAt(2)  ' デフォルトの印刷ボタンを削除します。

        ' カスタムボタンを作成します。
        Dim btn As New DataDynamics.ActiveReports.Toolbar.Button
        btn.Caption = "印刷"
        btn.ToolTip = printer
        btn.ImageIndex = 1
        btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
        btn.Id = 333
        'Me.Viewer1.Toolbar.Tools.Insert(2, btn)

        Dim btn2 As New DataDynamics.ActiveReports.Toolbar.Button
        btn2.Caption = "閉じる"
        btn2.ToolTip = "閉じる"
        btn2.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
        btn2.Id = 334
        'Me.Viewer1.Toolbar.Tools.Insert(22, btn2)

    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        printer = PRT_GET("01")   '**  プリンタ名取得
        'msg.Text = "出力プリンタは " & printer & " です。"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        P_DsPRT.Clear()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        prt()
    End Sub





    '********************************************************************
    '**  印刷
    '********************************************************************
    Sub prt()

        printer = PRT_GET("01")   '**  プリンタ名取得
        'printer = "Pdf"

        Select Case PRT_PRAM1
            Case Is = "R_Sals_Report"               '**  売上集計 (R_Sals_Report)

                Dim rpt As New SectionReport5
                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    ' PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

                    p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    ' p.Export(rpt.Document, Application.StartupPath & "\Report.pdf")
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "売上集計"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_Sals_day_Report"           '**  日別集計 (R_Sals_day_Report)

                Dim rpt As New SectionReport1
                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With

                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print02"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

                    p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    ' p.Export(rpt.Document, Application.StartupPath & "\Report.pdf")
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "日別集計"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_Sals_Empl_Report"          '**  修理担当者別集計 (R_Sals_Empl_Report)

                ' Dim rpt As New R_Sals_Empl_Report
                Dim rpt As New SectionReport2

                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With

                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    ' PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

                    p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    ' p.Export(rpt.Document, Application.StartupPath & "\Report.pdf")
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "修理担当者別集計"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_Sals_Report_WC"            '**  売上集計 保証/有償 (R_Sals_Report_WC)

                'Dim rpt As New R_Sals_Report_WC
                Dim rpt As New SectionReport4

                'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                'With rpt.Document.Printer
                '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                '    '.PaperKind = Printing.PaperKind.A4
                '    .PaperSize = p1
                '    ' .Landscape = True
                'End With
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

                    p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    ' p.Export(rpt.Document, Application.StartupPath & "\Report.pdf")
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "売上集計 保証/有償"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

        End Select

    End Sub



    'Private Sub Viewer1_ToolClick(ByVal sender As Object, ByVal e As GrapeCity.ActiveReports.Toolbar.ToolClickEventArgs) Handles Viewer1.ToolClick
    'Private Sub Viewer1_ToolClick(ByVal sender As Object, ByVal e As DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs) Handles Viewer1.ToolClick
    '    Select Case e.Tool.Id
    '        Case Is = 333
    '            prt()

    '        Case Is = 334 '**  戻る
    '            P_DsPRT.Clear()
    '            Me.Close()
    '    End Select
    'End Sub
End Class
