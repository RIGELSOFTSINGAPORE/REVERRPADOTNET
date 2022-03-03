Public Class MyDataGridTextBoxColumn1
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
            P_keika = CType(cellValue, Integer)
            '�l��">=9"�̃Z���̑O�i�F��ς���
            If CType(cellValue, Integer) >= 9 Then
                foreBrush = New SolidBrush(Color.Red)
            End If
        End If
        '��{�N���X��Paint���\�b�h���Ăяo��
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
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
        Dim cellValue2 As Object = Me.GetColumnValueAtRow(source, rowNum)

        If P_keika > 2 Then
            If P_rpar_cls = "01" Then
                If IsDBNull(cellValue) Then
                    '�o�߂�">2"�Ŗ����ς̃Z���̑O�i�F�Ɣw�i�F��ς���
                    foreBrush = New SolidBrush(Color.White)
                    backBrush = New SolidBrush(Color.Red)
                End If
            End If
        End If
        '��{�N���X��Paint���\�b�h���Ăяo��
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class

Public Class MyDataGridTextBoxColumn3
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
            P_rpar_cls = cellValue
        End If
        '��{�N���X��Paint���\�b�h���Ăяo��
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub
End Class

