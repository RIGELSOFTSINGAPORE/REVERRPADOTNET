Public Class Class1

End Class

Public Class MyDataGridTextBoxColumn2
    Inherits DataGridTextBoxColumn
    'Paint���\�b�h���I�[�o�[���C�h����
    Protected Overloads Overrides Sub Paint( _
            ByVal g As Graphics, _
            ByVal bounds As Rectangle, _
            ByVal source As CurrencyManager, _
            ByVal rowNum As Integer, _
            ByVal backBrush As Brush, _
            ByVal foreBrush As Brush, _
            ByVal alignToRight As Boolean _
            )
        '�Z���̒l���擾����
        Dim cellValue As Object = Me.GetColumnValueAtRow(source, rowNum)
        If Not cellValue Is Nothing Then
            '�l��"<0"�̃Z���̑O�i�F��ς���
            If CType(cellValue, Integer) < 0 Then
                foreBrush = New SolidBrush(Color.Red)
            End If
        End If
        '��{�N���X��Paint���\�b�h���Ăяo��
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class
