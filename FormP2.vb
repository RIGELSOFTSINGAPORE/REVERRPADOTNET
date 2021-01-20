Imports GrapeCity.ActiveReports

Public Class FormP2
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsPrint1 As New DataSet
    Dim r As Integer
    Dim strSQL As String

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormP2))
        Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PdfExport1 = New DataDynamics.ActiveReports.Export.Pdf.PdfExport()
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
        Me.Viewer1.TabIndex = 35
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(735, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(48, 24)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "PDF"
        '
        'FormP2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(994, 719)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Viewer1)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormP2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "プレビュー"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormP2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '印刷用データセット
        strSQL = "SELECT Wrn_mtr.shop_code AS [店ｺｰﾄﾞ]"
        strSQL = strSQL & ", Shop_mtr.[店舗名(ｶﾅ)] AS 店舗名"
        If P_To_Date < "2009/06/30" Then
            strSQL = strSQL & ", COUNT(*) * 60 AS 事務手数料"
        Else
            strSQL = strSQL & ", COUNT(*) * 50 AS 事務手数料"
        End If
        strSQL = strSQL & ", COUNT(Wrn_mtr.ordr_no) AS 件数"
        strSQL = strSQL & " FROM Wrn_mtr INNER JOIN Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code"
        'strSQL = strSQL & " WHERE (Wrn_sub.op_date < '" & P_From_Date & "')"
        'strSQL = strSQL & " AND (Wrn_sub.cxl_op_date BETWEEN '" & P_From_Date & "' AND '" & P_To_Date & "')"
        strSQL = strSQL & " GROUP BY Wrn_mtr.shop_code, Shop_mtr.[店舗名(ｶﾅ)], Wrn_sub.cont_flg, Wrn_sub.corp_flg"
        strSQL = strSQL & " HAVING (Wrn_sub.cont_flg = 'C') AND (Wrn_sub.corp_flg = '0')"
        strSQL = strSQL & " ORDER BY 店ｺｰﾄﾞ"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DB_OPEN("best_wrn")
        r = DaList1.Fill(DsPrint1, "wrn_mtr")
        DB_CLOSE()

        'If r = 0 Then
        '    MessageBox.Show("該当するデータがありません", "印刷", MessageBoxButtons.OK)
        '    Me.Close()
        'End If

        'データビューでプレビュー
        Dim rpt As New SectionReport1
        rpt.Document.Name = "延長保証料総括表前月解約処理分"
        rpt.DataSource = DsPrint1
        rpt.DataMember = "wrn_mtr"
        Viewer1.Document = rpt.Document
        rpt.Run()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "延長保証料総括表前月解約処理分.pdf"     'はじめのファイル名を指定する
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

        'If sfd.ShowDialog() = DialogResult.OK Then     'ダイアログを表示する
        Dim rpt As New SectionReport1
            rpt.Document.Name = "延長保証料総括表前月解約処理分"
            rpt.DataSource = DsPrint1
            rpt.DataMember = "wrn_mtr"
            rpt.Run(False)
            'PdfExport1.Export(rpt.Document, sfd.FileName)
            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            p.Export(rpt.Document, Application.StartupPath & "\Report.pdf")
        'End If
    End Sub

    Private Sub Viewer1_Load(sender As Object, e As EventArgs) Handles Viewer1.Load

    End Sub
End Class
