Public Class F01_メニュー
    Private Sub マスター入力_Click(sender As Object, e As EventArgs) Handles マスター入力.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form11 As New F11_マスター入力メニュー
        Me.Hide()
        F00_Form11.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

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

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim 調査用 As New 調査用
        Me.Hide()
        調査用.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class
