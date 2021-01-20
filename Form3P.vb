Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Export.Pdf

Public Class Form3P
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    'Friend WithEvents Viewer1 As DataDynamics.ActiveReports.Viewer.Viewer
    Friend WithEvents Viewer1 As GrapeCity.ActiveReports.Viewer.Win.Viewer
    '  Friend WithEvents PdfExport1 As GrapeCity.ActiveReports.Export.Pdf
    'Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3P))
        Me.Button98 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Font = New System.Drawing.Font("MS PGothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button98.Location = New System.Drawing.Point(904, 688)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(72, 24)
        Me.Button98.TabIndex = 981
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(737, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(48, 24)
        Me.Button1.TabIndex = 983
        Me.Button1.Text = "PDF"
        '
        'Viewer1
        '
        Me.Viewer1.BackColor = System.Drawing.SystemColors.Control
        Me.Viewer1.CurrentPage = 0
        Me.Viewer1.Location = New System.Drawing.Point(12, 9)
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
        Me.Viewer1.Size = New System.Drawing.Size(979, 680)
        Me.Viewer1.TabIndex = 982
        '
        'Form3P
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(994, 719)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Viewer1)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form3P"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "エラーデータ印刷"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '起動時
    Private Sub Form3P_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        'データビューでプレビュー
        '  Dim rpt As New ActiveReport1

        Try
            Dim rpt As New SectionReport1
            rpt.Document.Name = "エラーデータ"
            rpt.DataSource = P_DsList2
            rpt.DataMember = "Error_data_ivc"
            Viewer1.Document = rpt.Document

            rpt.Run(False)
            ' Button1.Visible = False
        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "エラーデータ.pdf"            'はじめのファイル名を指定する
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
            'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            '' Dim rpt As New ActiveReport1
            Dim rpt As New SectionReport1
            rpt.Document.Name = "エラーデータ"
            rpt.DataSource = P_DsList2
            rpt.DataMember = "Error_data_ivc"
            rpt.Run(False)
            ' PdfExport1.Export(rpt.Document, sfd.FileName)
            ' TiffExport1.Export(rpt.Document, sfd.FileName)
            'Dim rpt As New SectionReport1
            Dim p As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            'rpt.Run()
            'Me.Viewer1.Document = rpt.Document
            p.Export(rpt.Document, sfd.FileName)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    '戻るボタン
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        Me.Close()
    End Sub

    Private Sub Viewer1_Load(sender As Object, e As EventArgs) Handles Viewer1.Load

    End Sub
End Class
