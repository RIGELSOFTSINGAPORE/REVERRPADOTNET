Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class F01_メニュー
    Private Sub マスター入力_Click(sender As Object, e As EventArgs) Handles マスター入力.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form11 As New F11_マスター入力メニュー
        Me.Hide()
        F00_Form11.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    'Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    'Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim myCp As CreateParams = MyBase.CreateParams
    '        myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
    '        Return myCp
    '    End Get
    'End Property
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form30 As New F30_満了レポート
        Me.Hide()
        F00_Form30.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F20_契約書一覧 As New F20_契約書一覧_WHExcel
        Me.Hide()
        F20_契約書一覧.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F90_管理者 As New F90_管理者
        Me.Hide()
        F90_管理者.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub F01_メニュー_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MaximizeBox = False
        backup()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim 調査用 As New 調査用
        Me.Hide()
        調査用.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            'Me.Close()
            Application.Exit()
            End
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub backup()
        Dim ConnectionString1 As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
        Dim folderName As String = "C:\Backup"
        Dim pathString As String = System.IO.Path.Combine(folderName, DateTime.Now.ToString("yyyy"))
        pathString = System.IO.Path.Combine(pathString, DateTime.Now.ToString("MMMM"))
        System.IO.Directory.CreateDirectory(pathString)
        Dim filename As String = DateTime.Now.ToString("yyyy-MM-dd") & ".sql"

        Dim file As String = pathString & "\" + filename


        Dim cmd As MySqlCommand = New MySqlCommand
        cmd.Connection = cnn
        cnn.Open()
        Dim mb As MySqlBackup = New MySqlBackup(cmd)
        mb.ExportToFile(file)
        cnn.Close()
    End Sub


End Class
