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
    Friend WithEvents Viewer1 As DataDynamics.ActiveReports.Viewer.Viewer
    Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Print_View))
        Me.Viewer1 = New DataDynamics.ActiveReports.Viewer.Viewer
        Me.PdfExport1 = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
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
        Me.Viewer1.Size = New System.Drawing.Size(1002, 688)
        Me.Viewer1.TabIndex = 33
        Me.Viewer1.TableOfContents.Text = "Table Of Contents"
        Me.Viewer1.TableOfContents.Width = 200
        Me.Viewer1.Toolbar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Print_View
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
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
                Dim rpt As New R_Sals_Report
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_Sals_day_Report"           '**  日別集計 (R_Sals_day_Report)

                'データビューでプレビュー
                Dim rpt As New R_Sals_day_Report
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print02"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_Sals_Empl_Report"          '**  修理担当者別集計 (R_Sals_Empl_Report)

                'データビューでプレビュー
                Dim rpt As New R_Sals_Empl_Report
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                Viewer1.Document = rpt.Document
                rpt.Run(False)

            Case Is = "R_Sals_Report_WC"            '**  売上集計 保証/有償 (R_Sals_Report_WC)

                'データビューでプレビュー
                Dim rpt As New R_Sals_Report_WC
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

        printer = PRT_GET("01")   '**  プリンタ名取得
        'msg.Text = "出力プリンタは " & printer & " です。"
    End Sub

    '********************************************************************
    '**  印刷
    '********************************************************************
    Sub prt()

        printer = PRT_GET("01")   '**  プリンタ名取得

        Select Case PRT_PRAM1
            Case Is = "R_Sals_Report"               '**  売上集計 (R_Sals_Report)

                Dim rpt As New R_Sals_Report
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
                    rpt.Document.Name = "売上集計"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_Sals_day_Report"           '**  日別集計 (R_Sals_day_Report)

                Dim rpt As New R_Sals_day_Report
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print02"
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "日別集計"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_Sals_Empl_Report"          '**  修理担当者別集計 (R_Sals_Empl_Report)

                Dim rpt As New R_Sals_Empl_Report
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
                    rpt.Document.Name = "修理担当者別集計"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

            Case Is = "R_Sals_Report_WC"            '**  売上集計 保証/有償 (R_Sals_Report_WC)

                Dim rpt As New R_Sals_Report_WC
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
                    rpt.Document.Name = "売上集計 保証/有償"
                    rpt.Document.Print(False, False, False)
                End If

                MsgBox(printer & " に印刷しました。")

        End Select

    End Sub

    Private Sub Viewer1_ToolClick(ByVal sender As Object, ByVal e As DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs) Handles Viewer1.ToolClick
        Select Case e.Tool.Id
            Case Is = 333
                prt()

            Case Is = 334 '**  戻る
                P_DsPRT.Clear()
                Me.Close()
        End Select
    End Sub
End Class
