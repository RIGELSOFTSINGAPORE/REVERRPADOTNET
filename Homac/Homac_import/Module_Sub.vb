Module Module_Sub

    '********************************************************************
    '**  Shift JISに変換したときに必要なバイト数を返す
    '********************************************************************
    Function LenB(ByVal str As String) As Integer
        Return System.Text.Encoding.GetEncoding(932).GetByteCount(str)
    End Function

    Function LeftB(ByVal Str As String, ByVal n1 As Integer) As String
        Dim i As Integer
        Dim WkStr As String
        For i = 1 To n1
            WkStr = WkStr & Mid(Str, i, 1)
            Select Case LenB(WkStr)
                Case Is = n1
                    Return WkStr
                    Exit Function
                Case Is > n1
                    Return Mid(WkStr, 1, Len(WkStr) - 1) & " "
                    Exit Function
            End Select
        Next

        For i = 1 To n1 - LenB(WkStr)
            WkStr = WkStr & " "
        Next
        Return WkStr

    End Function

    Public Function MidB(ByVal str As String, ByVal Start As Integer, Optional ByVal Length As Integer = 0) As String
        '▼空文字に対しては常に空文字を返す

        If str = "" Then
            Return ""
        End If

        '▼Lengthのチェック

        'Lengthが0か、Start以降のバイト数をオーバーする場合はStart以降の全バイトが指定されたものとみなす。

        Dim RestLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str) - Start + 1

        If Length = 0 OrElse Length > RestLength Then
            Length = RestLength
        End If

        '▼切り抜き

        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
        Dim B() As Byte = CType(Array.CreateInstance(GetType(Byte), Length), Byte())

        Array.Copy(SJIS.GetBytes(str), Start - 1, B, 0, Length)

        Dim st1 As String = SJIS.GetString(B)

        '▼切り抜いた結果、最後の１バイトが全角文字の半分だった場合、その半分は切り捨てる。

        Dim ResultLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(st1) - Start + 1

        If Asc(Strings.Right(st1, 1)) = 0 Then
            'VB.NET2002,2003の場合、最後の１バイトが全角の半分の時
            Return st1.Substring(0, st1.Length - 1)
        ElseIf Length = ResultLength - 1 Then
            'VB2005の場合で最後の１バイトが全角の半分の時
            Return st1.Substring(0, st1.Length - 1)
        Else
            'その他の場合
            Return st1
        End If
    End Function

    '********************************************************************
    '**  数値チェック
    '********************************************************************
    Public Function numeric_check(ByVal i_data)
        Dim i As Integer

        For i = 1 To Len(i_data)
            Select Case Mid(i_data, i, 1)
                Case Is = "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                Case Else
                    Return "NG" : Exit Function
            End Select
        Next
        Return "OK"

    End Function

    '********************************************************************
    '**  四捨五入
    '********************************************************************
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

    '********************************************************************
    '**  切り上げ
    '********************************************************************
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

    '********************************************************************
    '**  切捨て
    '********************************************************************
    Public Function RoundDOWN(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        wkn1 = Fix(pdblX * 10 ^ keta)
        Return wkn1 / 10 ^ keta
    End Function

    '********************************************************************
    '**  改行ををスペースに置き換え
    '********************************************************************
    Public Function New_Line_Cng(ByVal str As String) As String
        Return Trim(str.Replace(System.Environment.NewLine, " "))
    End Function

    '********************************************************************
    '**  カンマをスペースに置き換え
    '********************************************************************
    Public Function comma_Cng(ByVal str As String) As String
        Return Trim(str.Replace(",", " "))
    End Function

    '********************************************************************
    '**  検索用電話番号に編集
    '********************************************************************
    Public Function scn_tel_Cng(ByVal str As String) As String
        Dim i As Integer
        Dim out As String = Nothing

        For i = 1 To Len(str)
            Select Case Mid(str, i, 1)
                Case Is = "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    out = out & Mid(str, i, 1)
                Case Else
            End Select
        Next
        Return out
    End Function

    '********************************************************************
    '**  検索用名前に編集
    '********************************************************************
    Public Function scn_name_Cng(ByVal str As String) As String
        Dim out As String = Trim(str)
        out = out.Replace(" ", "")
        out = out.Replace("　", "")
        Return out
    End Function


End Module