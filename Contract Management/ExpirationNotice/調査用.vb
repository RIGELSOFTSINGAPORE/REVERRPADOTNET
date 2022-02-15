Public Class 調査用
    Public Shared SurveyFromDate As String = ""
    Public Shared SurveyToDate As String = ""


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'MessageBox.Show("From Date" & FromDate.Text)
            'MessageBox.Show("To Date" & ToDate.Text)
            'MessageBox.Show("click")
            Dim expendStartdt As Date = Date.ParseExact(FromDate.Text, "yyyy/MM/dd",
                System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Dim expendEnddt As Date = Date.ParseExact(ToDate.Text, "yyyy/MM/dd",
                System.Globalization.DateTimeFormatInfo.InvariantInfo)

            If expendStartdt > expendEnddt Then
                MessageBox.Show("無効な日付範囲")
                Return
            End If
            SurveyFromDate = FromDate.Value.Date
            SurveyToDate = ToDate.Value.Date
            ' MessageBox.Show("Success")
            Dim R30_調査用 As New R30_調査用
            Me.Hide()
            R30_調査用.ShowDialog()
            Me.Show()
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
End Class