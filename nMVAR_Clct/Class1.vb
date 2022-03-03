Public Class Class1

End Class

Public Class MyDataGridTextBoxColumn2
    Inherits DataGridTextBoxColumn
    'Paintメソッドをオーバーライドする
    Protected Overloads Overrides Sub Paint( _
            ByVal g As Graphics, _
            ByVal bounds As Rectangle, _
            ByVal source As CurrencyManager, _
            ByVal rowNum As Integer, _
            ByVal backBrush As Brush, _
            ByVal foreBrush As Brush, _
            ByVal alignToRight As Boolean _
            )
        'セルの値を取得する
        Dim cellValue As Object = Me.GetColumnValueAtRow(source, rowNum)
        If Not cellValue Is Nothing Then
            '値が"<0"のセルの前景色を変える
            If CType(cellValue, Integer) < 0 Then
                foreBrush = New SolidBrush(Color.Red)
            End If
        End If
        '基本クラスのPaintメソッドを呼び出す
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class
