Public Class F11_マスター入力メニュー
    Private Sub マスター入力_Click(sender As Object, e As EventArgs) Handles マスター入力.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Dim F21_契約書入力画面 As New F21_契約書入力画面
        Dim F21_契約書入力画面 As New F21_契約書入力画面
        Me.Hide()
        F21_契約書入力画面.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F12_取引先マスター As New F12_取引先マスター
        Me.Hide()
        F12_取引先マスター.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F14_取引先マスター一覧 As New F14_取引先マスター一覧
        Me.Hide()
        F14_取引先マスター一覧.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F13_部署マスター As New F13_部署マスター
        Me.Hide()
        F13_部署マスター.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F15_部署マスター一覧 As New F15_部署マスター一覧
        Me.Hide()
        F15_部署マスター一覧.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub F11_マスター入力メニュー_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MaximizeBox = False
    End Sub
End Class