Module Module2
    Public P_From_Date, P_To_Date, P_nx_Date, lP_From_Date, lP_To_Date As Date
    Public P_close As String

    Public Function Round(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        Dim wkn2 As Double
        wkn1 = Fix(pdblX * 10 ^ keta)
        wkn2 = Fix(pdblX * 10 ^ keta * 10) / 10
        If wkn2 - wkn1 >= 0.5 Then
            Return (wkn1 + 1) / 10 ^ keta
        Else
            Return wkn1 / 10 ^ keta
        End If
    End Function

    Public Function RoundUP(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        Dim wkn2 As Double
        wkn1 = Fix(pdblX * 10 ^ keta)
        wkn2 = Fix(pdblX * 10 ^ keta * 10) / 10
        If wkn2 - wkn1 > 0 Then
            Return (wkn1 + 1) / 10 ^ keta
        Else
            Return wkn1 / 10 ^ keta
        End If
    End Function

    Public Function RoundDOWN(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        wkn1 = Fix(pdblX * 10 ^ keta)
        Return wkn1 / 10 ^ keta
    End Function

    '2014/05/16 消費税対策 start
    '********************************************************************
    '**  パラメータの日付から消費税率を算出
    '********************************************************************
    Public Function GetTaxRate(ByVal targetDate As String) As Decimal

        Dim taxRate As Decimal
        Dim newTaxStartDate As String = "2014/04/01"

        taxRate = 0.08D
        If targetDate < newTaxStartDate Then
            taxRate = 0.05D
        End If

        Return taxRate

    End Function
    '2014/05/16 消費税対策 end

End Module
