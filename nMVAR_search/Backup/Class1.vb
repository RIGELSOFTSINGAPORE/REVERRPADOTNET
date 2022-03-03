Public Class MyDataGridTextBoxColumn
    Inherits DataGridTextBoxColumn
    Dim myDataRowView As DataRowView

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

        '���ݍs�̊e��̒l���擾 
        myDataRowView = CType(source.List(rowNum), DataRowView)

        '���ݍs���擾��������̃A�C�e���̒l���擾���������f
        If CType(myDataRowView.Item("aka"), String) = "1" Then
            foreBrush = New SolidBrush(Color.Red)
        End If

        '��{�N���X��Paint���\�b�h���Ăяo��
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class
