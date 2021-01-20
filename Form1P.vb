Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Export.Pdf
Public Class Form1P
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim WK_DsPrint, WK_List1 As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim DtTbl1 As DataTable
    Dim DtRow1 As DataRow
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    '  Friend WithEvents PdfExport1 As GrapeCity.ActiveReports.Export.Pdf
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
    '  Friend WithEvents Viewer1 As DataDynamics.ActiveReports.Viewer.Viewer
    Friend WithEvents Viewer1 As GrapeCity.ActiveReports.Viewer.Win.Viewer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    'Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
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
        Me.Viewer1.Margin = New System.Windows.Forms.Padding(0)
        Me.Viewer1.Name = "Viewer1"
        Me.Viewer1.PreviewPages = 0
        '
        '
        '
        '
        '
        '
        Me.Viewer1.Sidebar.ParametersPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.ParametersPanel.Width = 200
        '
        '
        '
        Me.Viewer1.Sidebar.SearchPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.SearchPanel.Width = 200
        '
        '
        '
        Me.Viewer1.Sidebar.ThumbnailsPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.ThumbnailsPanel.Width = 200
        Me.Viewer1.Sidebar.ThumbnailsPanel.Zoom = 0.1R
        '
        '
        '
        Me.Viewer1.Sidebar.TocPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.TocPanel.Expanded = True
        Me.Viewer1.Sidebar.TocPanel.Text = "Table Of Contents"
        Me.Viewer1.Sidebar.TocPanel.Width = 200
        Me.Viewer1.Sidebar.Width = 200
        Me.Viewer1.Size = New System.Drawing.Size(994, 719)
        Me.Viewer1.TabIndex = 104
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(732, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 105
        Me.Button1.Text = "PDF"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(813, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 106
        Me.Button2.Text = "閉じる"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1P
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(994, 719)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Viewer1)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Name = "Form1P"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "セーフティ５ 支払報告書"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************
    '起動時
    '**********************************
    Private Sub Form1P_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DataCrt()

        Select Case P_Flg
            Case Is = "1", "2", "3"

                'データビューでプレビュー

                Dim rpt As New SectionReport1
                rpt.Document.Name = "請求レポート"
                rpt.DataSource = P_DsPrint
                rpt.DataMember = "Wrn_ivc"
                Dim p As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                With rpt.Document.Printer
                    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                    .PaperKind = Printing.PaperKind.A4
                    .PaperSize = p
                    .Landscape = True
                End With
                rpt.Document.Printer.Landscape = True
                Viewer1.Document = rpt.Document
                rpt.Run(True)

            Case Is = "4", "5", "6"

                'データビューでプレビュー
                Dim rpt As New SectionReport2
                rpt.Document.Name = "請求レポート"
                Dim p As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch
                With rpt.Document.Printer
                    .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                    .PaperKind = Printing.PaperKind.A4
                    .PaperSize = p
                    .Landscape = True
                End With
                rpt.DataSource = P_DsPrint
                rpt.DataMember = "Wrn_ivc"
                Viewer1.Document = rpt.Document
                rpt.Run(True)

        End Select

        ' カスタムボタンを作成します。
        'Dim btn As New DataDynamics.ActiveReports.Toolbar.Button
        'btn.Caption = "PDF"
        'btn.ToolTip = "PDF出力"
        'btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
        'btn.Id = 333
        ''Me.Viewer1.Toolbar.Tools.Insert(22, btn)

        'Dim btn2 As New DataDynamics.ActiveReports.Toolbar.Button
        'btn2.Caption = "閉じる"
        'btn2.ToolTip = "閉じる"
        'btn2.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
        'btn2.Id = 334
        'Me.Viewer1.Toolbar.Tools.Insert(23, btn2)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sfd As New SaveFileDialog
        Select Case P_Flg
            Case Is = "1", "2", "3"
                sfd.FileName = "セーフティ５ 支払報告書.pdf"            'はじめのファイル名を指定する
            Case Is = "4", "5", "6"
                sfd.FileName = "セーフティ５ 支払報告書 営業所毎.pdf"   'はじめのファイル名を指定する
        End Select
        sfd.Filter = "Adobe Acrobat(*.pdf)|*.pdf"               '[ファイルの種類]に表示される選択肢を指定する
        sfd.FilterIndex = 2                                     '[ファイルの種類]ではじめに 「すべてのファイル」が選択されているようにする
        sfd.Title = "保存先のファイルを選択してください"        'タイトルを設定する
        sfd.RestoreDirectory = True                             'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True

        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then     'ダイアログを表示する
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Select Case P_Flg
                Case Is = "1", "2", "3"

                    Dim rpt As New SectionReport1
                    Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                    With rpt.Document.Printer
                        .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        .PaperKind = Printing.PaperKind.A4
                        .PaperSize = p1
                        .Landscape = True
                    End With
                    rpt.Document.Name = "セーフティ５ 支払報告書"
                    rpt.DataSource = P_DsPrint
                    rpt.DataMember = "Wrn_ivc"
                    rpt.Run(False)

                    'PdfExport1.Export(rpt.Document, sfd.FileName)
                    Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                    p.Export(rpt.Document, sfd.FileName)
                  '  MsgBox("PDFを保存しました", MsgBoxStyle.Information, "")
                Case Is = "4", "5", "6"
                    Dim rpt As New SectionReport2
                    Dim p1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 1000, 1170) 'hundredths of an inch

                    With rpt.Document.Printer
                        .PrinterName = "" 'use the virtual print driver for paper sizes not supported by the local printer
                        .PaperKind = Printing.PaperKind.A4
                        .PaperSize = p1
                        .Landscape = True
                    End With
                    rpt.Document.Name = "セーフティ５ 支払報告書 営業所毎"
                    rpt.DataSource = P_DsPrint
                    rpt.DataMember = "Wrn_ivc"
                    rpt.Run(False)
                    Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                    ' p.Export(rpt.Document, Application.StartupPath)
                    p.Export(rpt.Document, sfd.FileName)
                    ' MsgBox("PDFを保存しました", MsgBoxStyle.Information, "")
            End Select
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WK_DsPrint.Clear()
        P_DsPrint.Clear()
        Me.Close()
    End Sub

    Private Sub Viewer1_Load(sender As Object, e As EventArgs) Handles Viewer1.Load

    End Sub

    Sub DataCrt()
        WK_DsPrint.Clear()
        P_DsPrint.Clear()

        Select Case P_Flg
            Case Is = "1"
                SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_report_01", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
                Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.VarChar, 50)
                Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.VarChar, 50)
                Pram1.Value = P_Date
                Pram2.Value = "セーフティ５ 支払報告書（ﾍﾞｽﾄ電器振込分）"
                Pram3.Value = Month(P_Date) & "月処理分"
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                DaList1.Fill(WK_DsPrint, "Wrn_ivc")
                DaList1.Fill(P_DsPrint, "Wrn_ivc")
                DB_CLOSE()

            Case Is = "2"
                SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_report_02", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
                Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.VarChar, 50)
                Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.VarChar, 50)
                Pram1.Value = P_Date
                Pram2.Value = "セーフティ５ 支払報告書（ﾍﾞｽﾄｻｰﾋﾞｽ振込分）"
                Pram3.Value = Month(P_Date) & "月処理分"
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                DaList1.Fill(WK_DsPrint, "Wrn_ivc")
                DaList1.Fill(P_DsPrint, "Wrn_ivc")
                DB_CLOSE()

            Case Is = "3"
                SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_report_03", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
                Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.VarChar, 50)
                Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.VarChar, 50)
                Pram1.Value = P_Date
                Pram2.Value = "セーフティ５ 支払報告書（ｶｺｲｴﾚｸﾄﾛ振込分）"
                Pram3.Value = Month(P_Date) & "月処理分"
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                DaList1.Fill(WK_DsPrint, "Wrn_ivc")
                DaList1.Fill(P_DsPrint, "Wrn_ivc")
                DB_CLOSE()

            Case Is = "4"
                Dim wk1, wk2, wk3 As String
                wk1 = P_Date
                wk2 = "セーフティ５ 支払報告書（ﾍﾞｽﾄ電器振込分）"
                wk3 = Month(P_Date) & "月処理分"
                strSQL = "SELECT '" & wk3 & "' AS PROC_MON, '" & wk2 & "' AS Title, Wrn_ivc.ordr_no, Wrn_ivc.line_no"
                strSQL += ", Wrn_ivc.seq, Wrn_ivc.FLD004, Wrn_ivc.FLD005, Wrn_ivc.FLD006, Wrn_ivc.FLD007, Wrn_ivc.FLD009"
                strSQL += ", Wrn_ivc.FLD012, Wrn_ivc.FLD014, Wrn_ivc.FLD015, Wrn_ivc.FLD017, Wrn_ivc.FLD018, Wrn_ivc.FLD019"
                strSQL += ", Wrn_ivc.FLD020, Wrn_ivc.FLD021, Wrn_ivc.FLD028 AS 請求額, Wrn_ivc.imp_date AS FLD031"
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) * 0.05, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) * 0.05, 0, 1) AS TAX"
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) * 0.08, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) * 0.08, 0, 1) AS TAX8" '消費税8%対応　2014/04/22
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.08, 0, 1))) * 0.1, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.1, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.1, 0, 1))) * 0.1, 0, 1) AS TAX10" '消費税10%対応　2019/10/18
                strSQL += ", insurance_co_decision.Securities_no, Wrn_ivc.Limit_money, Wrn_ivc.Limit_money_off"
                strSQL += ", Wrn_sub.prch_date, Wrn_sub.prch_price, vdr_mtr.vdr_kana, vdr_mtr.vdr_name, Shop_mtr.[店舗名(漢字)]"
                strSQL += ", Wrn_ivc.kbn_No, insurance_co_decision.gurp AS kbn_No1, insurance_co_decision.start_date"
                strSQL += ", insurance_co_decision.end_date, Wrn_ivc.FLD022"
                strSQL += " FROM Wrn_ivc INNER JOIN"
                strSQL += " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code AND Wrn_ivc.BY_cls = Shop_mtr.BY_cls LEFT OUTER JOIN"
                strSQL += " vdr_mtr ON Wrn_ivc.BY_cls = vdr_mtr.BY_cls AND Wrn_ivc.FLD017 = vdr_mtr.vdr_code LEFT OUTER JOIN"
                strSQL += " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND Wrn_ivc.line_no = Wrn_sub.line_no AND"
                strSQL += " Wrn_ivc.seq = Wrn_sub.seq LEFT OUTER JOIN"
                strSQL += " insurance_co_decision ON Wrn_ivc.kbn_No = insurance_co_decision.kbn_No"
                strSQL += " WHERE (Wrn_ivc.Cancel_flg = '0')"
                strSQL += " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & wk1 & "', 102))"
                strSQL += " AND (Shop_mtr.会社GRP <> 98)"
                strSQL += " AND (Shop_mtr.会社GRP <> 203)"
                strSQL += " ORDER BY kbn_No1, Wrn_ivc.FLD012, Wrn_ivc.kbn_No, FLD031, Wrn_ivc.FLD007"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                DaList1.Fill(WK_DsPrint, "Wrn_ivc")
                DaList1.Fill(P_DsPrint, "Wrn_ivc")
                DB_CLOSE()

            Case Is = "5"
                Dim wk1, wk2, wk3 As String
                wk1 = P_Date
                wk2 = "セーフティ５ 支払報告書（ﾍﾞｽﾄｻｰﾋﾞｽ振込分）"
                wk3 = Month(P_Date) & "月処理分"
                strSQL = "SELECT '" & wk3 & "' AS PROC_MON, '" & wk2 & "' AS Title, Wrn_ivc.ordr_no, Wrn_ivc.line_no"
                strSQL += ", Wrn_ivc.seq, Wrn_ivc.FLD004, Wrn_ivc.FLD005, Wrn_ivc.FLD006, Wrn_ivc.FLD007, Wrn_ivc.FLD009"
                strSQL += ", Wrn_ivc.FLD012, Wrn_ivc.FLD014, Wrn_ivc.FLD015, Wrn_ivc.FLD017, Wrn_ivc.FLD018, Wrn_ivc.FLD019"
                strSQL += ", Wrn_ivc.FLD020, Wrn_ivc.FLD021, Wrn_ivc.FLD028 AS 請求額, Wrn_ivc.imp_date AS FLD031"
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) * 0.05, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) * 0.05, 0, 1) AS TAX"
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) * 0.08, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) * 0.08, 0, 1) AS TAX8" '消費税8%対応　2014/04/22
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.1, 0, 1))) * 0.1, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.1, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.1, 0, 1))) * 0.1, 0, 1) AS TAX10" '消費税10%対応　2019/10/18
                strSQL += ", insurance_co_decision.Securities_no, Wrn_ivc.Limit_money, Wrn_ivc.Limit_money_off"
                strSQL += ", Wrn_sub.prch_date, Wrn_sub.prch_price, vdr_mtr.vdr_kana, vdr_mtr.vdr_name, Shop_mtr.[店舗名(漢字)]"
                strSQL += ", Wrn_ivc.kbn_No, insurance_co_decision.gurp AS kbn_No1, insurance_co_decision.start_date"
                strSQL += ", insurance_co_decision.end_date, Wrn_ivc.FLD022"
                strSQL += " FROM Wrn_ivc INNER JOIN"
                '2014/09/05 FC区分出力対応 start
                'strSQL += " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code AND Wrn_ivc.BY_cls = Shop_mtr.BY_cls LEFT OUTER JOIN"
                strSQL += " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code AND Wrn_ivc.fin_BY_cls = Shop_mtr.BY_cls LEFT OUTER JOIN"
                '2014/09/05 FC区分出力対応 start
                strSQL += " vdr_mtr ON Wrn_ivc.BY_cls = vdr_mtr.BY_cls AND Wrn_ivc.FLD017 = vdr_mtr.vdr_code LEFT OUTER JOIN"
                strSQL += " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND Wrn_ivc.line_no = Wrn_sub.line_no AND"
                strSQL += " Wrn_ivc.seq = Wrn_sub.seq LEFT OUTER JOIN"
                strSQL += " insurance_co_decision ON Wrn_ivc.kbn_No = insurance_co_decision.kbn_No"
                strSQL += " WHERE (Wrn_ivc.Cancel_flg = '0')"
                strSQL += " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & wk1 & "', 102))"
                strSQL += " AND (Shop_mtr.会社GRP = 98)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                DaList1.Fill(WK_DsPrint, "Wrn_ivc")
                DaList1.Fill(P_DsPrint, "Wrn_ivc")
                DB_CLOSE()

            Case Is = "6"
                Dim wk1, wk2, wk3 As String
                wk1 = P_Date
                wk2 = "セーフティ５ 支払報告書（ｶｺｲｴﾚｸﾄﾛ振込分）"
                wk3 = Month(P_Date) & "月処理分"
                strSQL = "SELECT '" & wk3 & "' AS PROC_MON, '" & wk2 & "' AS Title, Wrn_ivc.ordr_no, Wrn_ivc.line_no"
                strSQL += ", Wrn_ivc.seq, Wrn_ivc.FLD004, Wrn_ivc.FLD005, Wrn_ivc.FLD006, Wrn_ivc.FLD007, Wrn_ivc.FLD009"
                strSQL += ", Wrn_ivc.FLD012, Wrn_ivc.FLD014, Wrn_ivc.FLD015, Wrn_ivc.FLD017, Wrn_ivc.FLD018, Wrn_ivc.FLD019"
                strSQL += ", Wrn_ivc.FLD020, Wrn_ivc.FLD021, Wrn_ivc.FLD028 AS 請求額, Wrn_ivc.imp_date AS FLD031"
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) * 0.05, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.05, 0, 1) * 0.05, 0, 1))) * 0.05, 0, 1) AS TAX"
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) * 0.08, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.08, 0, 1) * 0.08, 0, 1))) * 0.08, 0, 1) AS TAX8" '消費税8%対応　2014/04/22
                strSQL += ", (ROUND(((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.1, 0, 1))) * 0.1, 0, 1) + Wrn_ivc.FLD028) - ((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.1, 0, 1))) - ROUND(((ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + Wrn_ivc.FLD028) - (ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) + ROUND(ROUND(Wrn_ivc.FLD028 / 1.1, 0, 1) * 0.1, 0, 1))) * 0.1, 0, 1) AS TAX10" '消費税10%対応　2019/10/18
                strSQL += ", insurance_co_decision.Securities_no, Wrn_ivc.Limit_money, Wrn_ivc.Limit_money_off"
                strSQL += ", Wrn_sub.prch_date, Wrn_sub.prch_price, vdr_mtr.vdr_kana, vdr_mtr.vdr_name, Shop_mtr.[店舗名(漢字)]"
                strSQL += ", Wrn_ivc.kbn_No, insurance_co_decision.gurp AS kbn_No1, insurance_co_decision.start_date"
                strSQL += ", insurance_co_decision.end_date, Wrn_ivc.FLD022"
                strSQL += " FROM Wrn_ivc INNER JOIN"
                strSQL += " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code AND Wrn_ivc.BY_cls = Shop_mtr.BY_cls LEFT OUTER JOIN"
                strSQL += " vdr_mtr ON Wrn_ivc.BY_cls = vdr_mtr.BY_cls AND Wrn_ivc.FLD017 = vdr_mtr.vdr_code LEFT OUTER JOIN"
                strSQL += " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND Wrn_ivc.line_no = Wrn_sub.line_no AND"
                strSQL += " Wrn_ivc.seq = Wrn_sub.seq LEFT OUTER JOIN"
                strSQL += " insurance_co_decision ON Wrn_ivc.kbn_No = insurance_co_decision.kbn_No"
                strSQL += " WHERE (Wrn_ivc.Cancel_flg = '0')"
                strSQL += " AND (Wrn_ivc.close_date = CONVERT(DATETIME, '" & wk1 & "', 102))"
                strSQL += " AND (Shop_mtr.会社GRP = 203)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DB_OPEN("best_wrn")
                DaList1.Fill(WK_DsPrint, "Wrn_ivc")
                DaList1.Fill(P_DsPrint, "Wrn_ivc")
                DB_CLOSE()

        End Select

        Select Case P_Flg
            Case Is = "1", "2", "3"
                DtView1 = New DataView(WK_DsPrint.Tables("Wrn_ivc"), "seq=0", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    DB_OPEN("best_wrn_data2")
                    For i = 0 To DtView1.Count - 1
                        WK_List1.Clear()
                        strSQL = "SELECT prch_date, prch_price"
                        strSQL = strSQL & " FROM Wrn_data"
                        strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                        strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        SqlCmd1.CommandTimeout = 3600
                        DaList1.Fill(WK_List1, "Wrn_data")
                        DtView2 = New DataView(WK_List1.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
                        If DtView2.Count <> 0 Then
                            DtView1(i)("prch_date") = DtView2(0)("prch_date")
                            DtView1(i)("prch_price") = DtView2(0)("prch_price")
                        End If
                    Next
                    DB_CLOSE()
                End If

                DtView1 = New DataView(WK_DsPrint.Tables("Wrn_ivc"), "", "kbn_No1, kbn_No, FLD007, prch_date, ordr_no, line_no, seq", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    P_DsPrint.Clear()
                    DtTbl1 = P_DsPrint.Tables("Wrn_ivc")
                    For i = 0 To DtView1.Count - 1
                        DtRow1 = DtTbl1.NewRow

                        DtRow1("PROC_MON") = DtView1(i)("PROC_MON")
                        DtRow1("Title") = DtView1(i)("Title")
                        DtRow1("ordr_no") = DtView1(i)("ordr_no")
                        DtRow1("line_no") = DtView1(i)("line_no")
                        DtRow1("seq") = DtView1(i)("seq")
                        DtRow1("FLD004") = DtView1(i)("FLD004")
                        DtRow1("FLD005") = DtView1(i)("FLD005")
                        DtRow1("FLD006") = DtView1(i)("FLD006")
                        DtRow1("FLD007") = DtView1(i)("FLD007")
                        DtRow1("FLD009") = DtView1(i)("FLD009")
                        DtRow1("FLD014") = DtView1(i)("FLD014")
                        DtRow1("FLD015") = DtView1(i)("FLD015")
                        DtRow1("FLD017") = DtView1(i)("FLD017")
                        DtRow1("FLD018") = DtView1(i)("FLD018")
                        DtRow1("FLD019") = DtView1(i)("FLD019")
                        DtRow1("FLD020") = DtView1(i)("FLD020")
                        DtRow1("FLD021") = DtView1(i)("FLD021")
                        DtRow1("FLD028") = DtView1(i)("FLD028")
                        DtRow1("請求額") = DtView1(i)("請求額")
                        Select Case DtView1(i)("FLD022")                '↓消費税10%対応　2019/10/18
                            Case Is >= "2019/10/01"
                                DtRow1("TAX") = DtView1(i)("TAX10")
                            Case Is >= "2014/04/01"
                                DtRow1("TAX") = DtView1(i)("TAX8")
                            Case Else
                                DtRow1("TAX") = DtView1(i)("TAX")
                        End Select                                      '↑消費税10%対応　2019/10/18
                        'If DtView1(i)("FLD022") >= "2014/04/01" Then    '↓消費税8%対応　2014/04/22
                        'Else
                        '    DtRow1("TAX") = DtView1(i)("TAX")
                        'End If                                          '↑消費税8%対応　2014/04/22
                        'If Trim(DtView1(i)("kbn_No")) <> Trim(DtView1(i)("Securities_no")) Then
                        '    DtRow1("Securities_no") = DtView1(i)("Securities_no")
                        'End If
                        DtRow1("Limit_money") = DtView1(i)("Limit_money")
                        DtRow1("Limit_money_off") = DtView1(i)("Limit_money_off")
                        DtRow1("prch_date") = DtView1(i)("prch_date")
                        DtRow1("prch_price") = DtView1(i)("prch_price")
                        If Not IsDBNull(DtView1(i)("vdr_name")) Then
                            DtRow1("vdr_name") = DtView1(i)("vdr_name")
                        Else
                            If Not IsDBNull(DtView1(i)("vdr_kana")) Then
                                DtRow1("vdr_name") = DtView1(i)("vdr_kana")
                            Else
                                DtRow1("vdr_name") = Nothing
                            End If
                        End If
                        DtRow1("kbn_No") = DtView1(i)("kbn_No")
                        DtRow1("kbn_No1") = DtView1(i)("kbn_No1")
                        DtRow1("start_date") = DtView1(i)("start_date")
                        DtRow1("end_date") = DtView1(i)("end_date")
                        DtTbl1.Rows.Add(DtRow1)
                    Next
                End If

            Case Is = "4", "5", "6"
                DtView1 = New DataView(WK_DsPrint.Tables("Wrn_ivc"), "seq=0", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    DB_OPEN("best_wrn_data2")
                    For i = 0 To DtView1.Count - 1
                        WK_List1.Clear()
                        strSQL = "SELECT prch_date, prch_price"
                        strSQL = strSQL & " FROM Wrn_data"
                        strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                        strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        SqlCmd1.CommandTimeout = 3600
                        DaList1.Fill(WK_List1, "Wrn_data")
                        DtView2 = New DataView(WK_List1.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
                        If DtView2.Count <> 0 Then
                            DtView1(i)("prch_date") = DtView2(0)("prch_date")
                            DtView1(i)("prch_price") = DtView2(0)("prch_price")
                        End If
                    Next
                    DB_CLOSE()
                End If

                DtView1 = New DataView(WK_DsPrint.Tables("Wrn_ivc"), "", "kbn_No1, FLD012, kbn_No, FLD031, FLD007, prch_date, ordr_no, line_no, seq", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    P_DsPrint.Clear()
                    DtTbl1 = P_DsPrint.Tables("Wrn_ivc")
                    For i = 0 To DtView1.Count - 1
                        DtRow1 = DtTbl1.NewRow

                        DtRow1("PROC_MON") = DtView1(i)("PROC_MON")
                        DtRow1("Title") = DtView1(i)("Title")
                        DtRow1("ordr_no") = DtView1(i)("ordr_no")
                        DtRow1("line_no") = DtView1(i)("line_no")
                        DtRow1("seq") = DtView1(i)("seq")
                        DtRow1("FLD004") = DtView1(i)("FLD004")
                        DtRow1("FLD005") = DtView1(i)("FLD005")
                        DtRow1("FLD006") = DtView1(i)("FLD006")
                        DtRow1("FLD007") = DtView1(i)("FLD007")
                        DtRow1("FLD009") = DtView1(i)("FLD009")
                        DtRow1("FLD012") = DtView1(i)("FLD012")
                        DtRow1("FLD014") = DtView1(i)("FLD014")
                        DtRow1("FLD015") = DtView1(i)("FLD015")
                        DtRow1("FLD017") = DtView1(i)("FLD017")
                        DtRow1("FLD018") = DtView1(i)("FLD018")
                        DtRow1("FLD019") = DtView1(i)("FLD019")
                        DtRow1("FLD020") = DtView1(i)("FLD020")
                        DtRow1("FLD021") = DtView1(i)("FLD021")
                        'DtRow1("FLD028") = DtView1(i)("FLD028")
                        DtRow1("FLD031") = DtView1(i)("FLD031")
                        DtRow1("請求額") = DtView1(i)("請求額")
                        Select Case DtView1(i)("FLD022")                '↓消費税10%対応　2019/10/18
                            Case Is >= "2019/10/01"
                                DtRow1("TAX") = DtView1(i)("TAX10")
                            Case Is >= "2014/04/01"
                                DtRow1("TAX") = DtView1(i)("TAX8")
                            Case Else
                                DtRow1("TAX") = DtView1(i)("TAX")
                        End Select                                      '↑消費税10%対応　2019/10/18
                        'If DtView1(i)("FLD022") >= "2014/04/01" Then    '↓消費税8%対応　2014/04/22
                        '    DtRow1("TAX") = DtView1(i)("TAX8")
                        'Else
                        '    DtRow1("TAX") = DtView1(i)("TAX")
                        'End If                                          '↑消費税8%対応　2014/04/22
                        If Trim(DtView1(i)("kbn_No")) <> Trim(DtView1(i)("Securities_no")) Then
                            DtRow1("Securities_no") = DtView1(i)("Securities_no")
                        End If
                        DtRow1("Limit_money") = DtView1(i)("Limit_money")
                        DtRow1("Limit_money_off") = DtView1(i)("Limit_money_off")
                        DtRow1("prch_date") = DtView1(i)("prch_date")
                        DtRow1("prch_price") = DtView1(i)("prch_price")
                        If Not IsDBNull(DtView1(i)("vdr_kana")) Then
                            DtRow1("vdr_kana") = DtView1(i)("vdr_kana")
                        Else
                            If Not IsDBNull(DtView1(i)("vdr_kana")) Then
                                DtRow1("vdr_kana") = DtView1(i)("vdr_name")
                            Else
                                DtRow1("vdr_kana") = Nothing
                            End If
                        End If
                        DtRow1("店舗名(漢字)") = DtView1(i)("店舗名(漢字)")
                        DtRow1("kbn_No") = DtView1(i)("kbn_No")
                        DtRow1("kbn_No1") = DtView1(i)("kbn_No1")
                        DtRow1("start_date") = DtView1(i)("start_date")
                        DtRow1("end_date") = DtView1(i)("end_date")
                        DtTbl1.Rows.Add(DtRow1)
                    Next
                End If

        End Select

    End Sub

    'Private Sub Viewer1_ToolClick(ByVal sender As Object, ByVal e As DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs) Handles Viewer1.ToolClick

    '    Select Case e.Tool.Id
    '        Case Is = 333
    '            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
    '            Select Case P_Flg
    '                Case Is = "1", "2", "3"
    '                    sfd.FileName = "セーフティ５ 支払報告書.pdf"            'はじめのファイル名を指定する
    '                Case Is = "4", "5", "6"
    '                    sfd.FileName = "セーフティ５ 支払報告書 営業所毎.pdf"   'はじめのファイル名を指定する
    '            End Select
    '            sfd.Filter = "Adobe Acrobat(*.pdf)|*.pdf"               '[ファイルの種類]に表示される選択肢を指定する
    '            sfd.FilterIndex = 2                                     '[ファイルの種類]ではじめに 「すべてのファイル」が選択されているようにする
    '            sfd.Title = "保存先のファイルを選択してください"        'タイトルを設定する
    '            sfd.RestoreDirectory = True                             'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

    '            '既に存在するファイル名を指定したとき警告する
    '            'デフォルトでTrueなので指定する必要はない
    '            sfd.OverwritePrompt = True

    '            '存在しないパスが指定されたとき警告を表示する
    '            'デフォルトでTrueなので指定する必要はない
    '            sfd.CheckPathExists = True

    '            If sfd.ShowDialog() = DialogResult.OK Then     'ダイアログを表示する
    '                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '                Select Case P_Flg
    '                    Case Is = "1", "2", "3"
    '                        Dim rpt As New ActiveReport1
    '                        rpt.Document.Name = "セーフティ５ 支払報告書"
    '                        rpt.DataSource = P_DsPrint
    '                        rpt.DataMember = "Wrn_ivc"
    '                        rpt.Run(False)
    '                        PdfExport1.Export(rpt.Document, sfd.FileName)
    '                    Case Is = "4", "5", "6"
    '                        Dim rpt As New ActiveReport2
    '                        rpt.Document.Name = "セーフティ５ 支払報告書 営業所毎"
    '                        rpt.DataSource = P_DsPrint
    '                        rpt.DataMember = "Wrn_ivc"
    '                        rpt.Run(False)
    '                        PdfExport1.Export(rpt.Document, sfd.FileName)
    '                End Select
    '                Me.Cursor = System.Windows.Forms.Cursors.Default
    '            End If

    '        Case Is = 334
    '            WK_DsPrint.Clear()
    '            P_DsPrint.Clear()
    '            Me.Close()
    '    End Select
    'End Sub


End Class
