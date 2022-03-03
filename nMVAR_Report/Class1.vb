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
            P_keika = CType(cellValue, Integer)
            '値が">=9"のセルの前景色を変える
            If CType(cellValue, Integer) >= 9 Then
                foreBrush = New SolidBrush(Color.Red)
            End If
        End If
        '基本クラスのPaintメソッドを呼び出す
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
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
        Dim cellValue2 As Object = Me.GetColumnValueAtRow(source, rowNum)

        If P_keika > 2 Then
            If P_rpar_cls = "01" Then
                If IsDBNull(cellValue) Then
                    '経過が">2"で未見積のセルの前景色と背景色を変える
                    foreBrush = New SolidBrush(Color.White)
                    backBrush = New SolidBrush(Color.Red)
                End If
            End If
        End If
        '基本クラスのPaintメソッドを呼び出す
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class

Public Class MyDataGridTextBoxColumn3
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
            P_rpar_cls = cellValue
        End If
        '基本クラスのPaintメソッドを呼び出す
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class

