Public Class MyDataGridTextBoxColumn1
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
            '値が"<> null"のセルの背景色を変える
            If Not IsDBNull(cellValue) Then
                'foreBrush = New SolidBrush(Color.White)
                backBrush = New SolidBrush(Color.Khaki)
            Else
                backBrush = New SolidBrush(Color.Silver)
            End If
        End If
        '基本クラスのPaintメソッドを呼び出す
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class
