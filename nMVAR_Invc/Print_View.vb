Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Export.Pdf
Public Class Print_View
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim strSQL, printer As String

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
    'Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    Friend WithEvents msg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Print_View))
        'Me.Viewer1 = New DataDynamics.ActiveReports.Viewer.Viewer
        Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        'Me.PdfExport1 = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
        Me.msg = New System.Windows.Forms.Label
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
        Me.Button1.Location = New System.Drawing.Point(40, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "印刷"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 648)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(892, 32)
        Me.msg.TabIndex = 1765
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Print_View
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Viewer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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

        'データビューでプレビュー
        Select Case P_PView

            Case Is = "ivc" '請求書
                Select Case P_F60_9
                    Case Is = "02"  'ラオックス
                        Dim rpt As New R_Invc_LAOX_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)
                    Case Is = "03"  'パナソニック
                        Dim rpt As New R_Invc_Pana_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)
                    Case Is = "04"  'ケーズデンキ
                        Dim rpt As New R_Invc_Ks_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)
                    Case Is = "05"  'コジマ
                        Dim rpt As New R_Invc_Kojima_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)
                    Case Else   '通常
                        Dim rpt As New R_Invc_Normal_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)
                End Select

            Case Is = "DTL" '請求明細
                Select Case P_F60_10
                    Case Is = "02"  '汎用2
                        Dim rpt As New R_Invc_Dtl_Normal2_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)

                    Case Is = "03"  'ジョーシンサービス
                        Dim rpt As New R_Invc_Dtl_Joshin_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)

                    Case Is = "04"  'ケーズデンキ
                        Dim rpt As New R_Invc_Dtl_Ks_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)

                    Case Is = "05"  'デオデオ
                        Dim rpt As New R_Invc_Dtl_Deodeo_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)

                    Case Is = "06"  'ベスト電器
                        Dim rpt As New R_Invc_Dtl_Best_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)

                    Case Is = "07"  'ヨドバシカメラ
                        Dim rpt As New R_Invc_Dtl_Yodo_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)

                    Case Is = "08"  'コジマ
                        Dim rpt As New R_Invc_Dtl_Kojima_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1250, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)

                    Case Is = "09"  '汎用3
                        Dim rpt As New R_Invc_Dtl_Normal3_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)

                    Case Else       '汎用
                        Dim rpt As New R_Invc_Dtl_Normal_SectionReport
                        'Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                        'With rpt.Document.Printer
                        '    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        '    .PaperKind = Printing.PaperKind.A4
                        '    .PaperSize = p1
                        '    '.Landscape = True
                        'End With
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        Viewer1.Document = rpt.Document
                        rpt.Run(False)
                End Select

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

        printer = PRT_GET("01")   '**  プリンタ名取得
        msg.Text = "出力プリンタは " & printer & " です。"
    End Sub

    '********************************************************************
    '**  印刷
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        printer = PRT_GET("01")   '**  プリンタ名取得
        Select Case P_PView
            Case Is = "ivc" '請求書
                Select Case P_F60_9
                    Case Is = "02"        'Laox        

                        Dim rpt As New R_Invc_LAOX_SectionReport

                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")

                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求書LAOX"
                            rpt.Document.Print(False, False, False)
                            'If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            '    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            'End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")

                        End If

                    Case Is = "03"        'pana        

                        Dim rpt As New R_Invc_Pana_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求書Pana"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "04"  'ケーズデンキ

                        Dim rpt As New R_Invc_Ks_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求書ケーズ"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "05"  'コジマ

                        Dim rpt As New R_Invc_Kojima_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求書ｺｼﾞﾏ"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Else           '通常

                        Dim rpt As New R_Invc_Normal_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求書Normal"
                            rpt.Document.Print(False, False, False)
                        End If

                End Select

            Case Is = "DTL" '請求明細
                Select Case P_F60_10
                    Case Is = "02"  '汎用2
                        Dim rpt As New R_Invc_Dtl_Normal2_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_汎用2"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "03"  'ジョーシンサービス
                        Dim rpt As New R_Invc_Dtl_Joshin_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_ジョーシン"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "04"  'ケーズデンキ
                        Dim rpt As New R_Invc_Dtl_Ks_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            ' PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_ケーズ"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "05"  'デオデオ
                        Dim rpt As New R_Invc_Dtl_Deodeo_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_デオデオ"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "06"  'ベスト電器
                        Dim rpt As New R_Invc_Dtl_Best_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_ベスト"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "07"  'ヨドバシカメラ
                        Dim rpt As New R_Invc_Dtl_Yodo_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_ヨドバシ"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "08"  'コジマ
                        Dim rpt As New R_Invc_Dtl_Kojima_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            ' PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_コジマ"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Is = "09"  '汎用3
                        Dim rpt As New R_Invc_Dtl_Normal3_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_汎用3"
                            rpt.Document.Print(False, False, False)
                        End If

                    Case Else       '汎用
                        Dim rpt As New R_Invc_Dtl_Normal_SectionReport
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "prt"
                        rpt.Run(False)

                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            'PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                            p.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "請求明細表_汎用"
                            rpt.Document.Print(False, False, False)
                        End If

                End Select
        End Select

        msg.Text = printer & " に印刷しました。"
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        'P_DsPRT.Clear()
        Close()
    End Sub
End Class
