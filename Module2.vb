Module Module2

    Public Function Round(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        Dim wkn2 As Decimal
        wkn1 = Fix(pdblX * 10 ^ keta)
        wkn2 = Fix(pdblX * 10 ^ keta * 10) / 10
        If wkn2 - wkn1 >= 0.5 Then
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

    Public Function RoundUP(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        Dim wkn2 As Decimal
        wkn1 = Fix(pdblX * 10 ^ keta)
        wkn2 = Fix(pdblX * 10 ^ keta * 10) / 10
        If wkn2 - wkn1 > 0 Then
            Return (wkn1 + 1) / 10 ^ keta
        Else
            Return wkn1 / 10 ^ keta
        End If
    End Function

    '保証料計算
    Public Function wrn_fee_comp(ByVal Date_ent As String, ByVal corp_flg As String, ByVal amnt As Integer) As Integer
        If IsDate(Date_ent) = False Then Date_ent = Nothing

        If Date_ent = Nothing Then  '申込日なし
            Return 0
        Else
            Select Case corp_flg
                Case Is = "0"   '個人
                    If Date_ent < "2012/02/01" Then         '5.5%
                        Return RoundUP(amnt * 0.055, 0)
                    Else                                    '5%
                        Return RoundUP(amnt * 0.05, 0)
                    End If
                Case Is = "1"   '法人
                    'If Date_ent < "2012/03/01" Then         '10.5%
                    Return RoundUP(amnt * 0.105, 0)
                    'Else                                    '10%
                    '    Return RoundUP(amnt * 0.1, 0)
                    'End If
                Case Else       '無料
                    Return 0
            End Select
        End If
    End Function
End Module
