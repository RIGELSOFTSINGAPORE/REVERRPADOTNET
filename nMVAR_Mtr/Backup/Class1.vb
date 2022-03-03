Public Class MyDataGridTextBoxColumn
    Inherits DataGridTextBoxColumn
    Dim myDataRowView As DataRowView

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

        '現在行の各列の値を取得 
        myDataRowView = CType(source.List(rowNum), DataRowView)

        '現在行より取得したい列のアイテムの値を取得し条件判断
        If CType(myDataRowView.Item("aka"), String) = "1" Then
            foreBrush = New SolidBrush(Color.Red)
        End If

        '基本クラスのPaintメソッドを呼び出す
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class
