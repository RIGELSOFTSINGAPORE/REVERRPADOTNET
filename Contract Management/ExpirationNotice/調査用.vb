Public Class 調査用
    Public Shared SurveyFromDate As String = ""
    Public Shared SurveyToDate As String = ""


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'MessageBox.Show("From Date" & FromDate.Text)
            'MessageBox.Show("To Date" & ToDate.Text)
            'MessageBox.Show("click")
            'Dim expendStartdt As Date = Date.ParseExact(FromDate.Text, "yyyy/MM/dd",
            '    System.Globalization.DateTimeFormatInfo.InvariantInfo)
            'Dim expendEnddt As Date = Date.ParseExact(ToDate.Text, "yyyy/MM/dd",
            '    System.Globalization.DateTimeFormatInfo.InvariantInfo)
            If FromDate.Text.Trim = "" Then
                MessageBox.Show("開始日は必須です")
                Return
            End If
            Dim expendStartdt As Date = Convert.ToDateTime(FromDate.Text).ToString("yyyy/MM/dd")
            Dim expendEnddt As Date
            If ToDate.Text.Trim <> "" Then
                expendEnddt = Convert.ToDateTime(ToDate.Text).ToString("yyyy/MM/dd")
                If expendStartdt > expendEnddt Then
                    MessageBox.Show("無効な日付範囲")
                    Return
                End If
            End If


            'SurveyFromDate = FromDate.Value.Date
            'SurveyToDate = ToDate.Value.Date
            SurveyFromDate = FromDate.Text
            If ToDate.Text.Trim <> "" Then
                SurveyToDate = ToDate.Text
            Else
                SurveyToDate = FromDate.Text
            End If

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

    Private Sub ToDate_KeyDown(sender As Object, e As KeyEventArgs) Handles ToDate.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            ToDate.Format = DateTimePickerFormat.Custom
            ToDate.CustomFormat = " "
        End If
    End Sub

    Private Sub 調査用_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToDate.Format = DateTimePickerFormat.Custom
        ToDate.CustomFormat = " "
        FromDate.Format = DateTimePickerFormat.Custom
        FromDate.CustomFormat = " "
    End Sub

    'Private Sub ToDate_Click(sender As Object, e As EventArgs) Handles ToDate.Click
    '    ToDate.Format = DateTimePickerFormat.Custom
    '    ToDate.CustomFormat = "yyyy-MM-dd"
    'End Sub

    Private Sub ToDate_CloseUp(sender As Object, e As EventArgs) Handles ToDate.CloseUp
        ToDate.Format = DateTimePickerFormat.Custom
        ToDate.CustomFormat = "yyyy/MM/dd"
    End Sub

    Private Sub FromDate_CloseUp(sender As Object, e As EventArgs) Handles FromDate.CloseUp
        FromDate.Format = DateTimePickerFormat.Custom
        FromDate.CustomFormat = "yyyy/MM/dd"
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub
End Class