
Public Class F30_満了レポート

    Public Shared SetValueForText1 As String = ""
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Dim F01_メニュー As New F01_メニュー
        'Me.Hide()
        'F01_メニュー.ShowDialog()
        'Me.Show()
        Me.Close()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim R30_終了予定契約 As New R30_終了予定契約
        Me.Hide()
        R30_終了予定契約.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim R30_終了予定契約_テスト用 As New R30_終了予定契約_テスト用
        Me.Hide()
        R30_終了予定契約_テスト用.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub F30_満了レポート_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.MinDate = Now.Date
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DateTimePicker1.Value = Now.Date

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SetValueForText1 = DateTimePicker1.Value.Date
        Dim R30_終了予定契約_日付指定 As New R30_終了予定契約_日付指定
        Me.Hide()
        R30_終了予定契約_日付指定.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class