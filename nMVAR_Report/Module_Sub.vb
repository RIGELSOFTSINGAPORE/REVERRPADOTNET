Module Module_Sub
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL As String
    Dim i As Integer

    '********************************************************************
    '**  �v�����^���݃`�F�b�N
    '********************************************************************
    Public Function PRT_CHK(ByVal prt_name) As String
        Dim Mach_F As String = "0"
        If Mid(prt_name, 1, 1) = "\" Then
            Return "1"  'OK
        Else
            For Each p As String In Printing.PrinterSettings.InstalledPrinters
                If prt_name = p Then Mach_F = "1" : Exit For
            Next
            If Mach_F <> "1" Then
                Return "0"  'NG
            Else
                Return "1"  'OK
            End If
        End If
    End Function

    '********************************************************************
    '**  �v�����^���ҏW
    '********************************************************************
    Public Function PRT_NAME(ByVal WK_p) As String
        Dim int1 As Integer
        int1 = WK_p.LastIndexOf("(���_�C���N�g")
        If int1 <> -1 Then
            Return Trim(Mid(WK_p, 1, int1))
        Else
            Return WK_p
        End If
    End Function

    '********************************************************************
    '**  �v�����^���擾
    '********************************************************************
    Public Function PRT_GET(ByVal cls) As String
        Dim WK_str As String
        P_mojibake = Nothing
        P_uppr_mrgn = 0
        P_left_mrgn = 0
        DsList1.Clear()

        '�v�����^�ݒ�
        strSQL = "SELECT * FROM M11_PRINTER WHERE (pc_name = '" & P_PC_NAME & "') AND (print_id = '" & cls & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M11_PRINTER")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("M11_PRINTER"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            P_uppr_mrgn = DtView1(0)("uppr_mrgn")
            P_left_mrgn = DtView1(0)("left_mrgn")

            If Not IsDBNull(DtView1(0)("mojibake")) Then
                P_mojibake = DtView1(0)("mojibake")
            End If
            If Mid(DtView1(0)("printer_name"), 1, 1) = "\" Then
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    WK_str = DtView1(0)("printer_name")
                    Return WK_str.Replace("\", "!")
                Else
                    P_mojibake = "True"
                    Return DtView1(0)("printer_name")
                End If
            Else
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    If cls = "01" Then  'A4
                        Dim int1 As Integer
                        int1 = p.LastIndexOf("(���_�C���N�g")
                        If int1 <> -1 Or P_PC_NAME2 = "" Then
                            If p.IndexOf(DtView1(0)("printer_name")) <> -1 Then
                                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                    Return DtView1(0)("printer_name")
                                Else
                                    Return p
                                End If
                                Exit For
                            End If
                        End If
                    Else
                        If p = DtView1(0)("printer_name") Then
                            Return DtView1(0)("printer_name")
                            Exit For
                        End If
                    End If
                Next
            End If
        End If
        Return Nothing
    End Function

    '********************************************************************
    '**  Shift JIS�ɕϊ������Ƃ��ɕK�v�ȃo�C�g����Ԃ�
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
        '���󕶎��ɑ΂��Ă͏�ɋ󕶎���Ԃ�

        If str = "" Then
            Return ""
        End If

        '��Length�̃`�F�b�N

        'Length��0���AStart�ȍ~�̃o�C�g�����I�[�o�[����ꍇ��Start�ȍ~�̑S�o�C�g���w�肳�ꂽ���̂Ƃ݂Ȃ��B

        Dim RestLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str) - Start + 1

        If Length = 0 OrElse Length > RestLength Then
            Length = RestLength
        End If

        '���؂蔲��

        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
        Dim B() As Byte = CType(Array.CreateInstance(GetType(Byte), Length), Byte())

        Array.Copy(SJIS.GetBytes(str), Start - 1, B, 0, Length)

        Dim st1 As String = SJIS.GetString(B)

        '���؂蔲�������ʁA�Ō�̂P�o�C�g���S�p�����̔����������ꍇ�A���̔����͐؂�̂Ă�B

        Dim ResultLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(st1) - Start + 1

        If Asc(Strings.Right(st1, 1)) = 0 Then
            'VB.NET2002,2003�̏ꍇ�A�Ō�̂P�o�C�g���S�p�̔����̎�
            Return st1.Substring(0, st1.Length - 1)
        ElseIf Length = ResultLength - 1 Then
            'VB2005�̏ꍇ�ōŌ�̂P�o�C�g���S�p�̔����̎�
            Return st1.Substring(0, st1.Length - 1)
        Else
            '���̑��̏ꍇ
            Return st1
        End If
    End Function

    '********************************************************************
    '**  �l�̌ܓ�
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
    '**  �؂�グ
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
    '**  �؎̂�
    '********************************************************************
    Public Function RoundDOWN(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        wkn1 = Fix(pdblX * 10 ^ keta)
        Return wkn1 / 10 ^ keta
    End Function

    '********************************************************************
    '**  ���s�����X�y�[�X�ɒu������
    '********************************************************************
    Public Function New_Line_Cng(ByVal str As String) As String
        Dim WK As String
        WK = Trim(str.Replace(vbCr, " "))
        Return Trim(WK.Replace(vbLf, " "))
    End Function

    '********************************************************************
    '**  �J���}���X�y�[�X�ɒu������
    '********************************************************************
    Public Function comma_Cng(ByVal str As String) As String
        Return Trim(str.Replace(",", " "))
    End Function

    '********************************************************************
    '**  "��'�ɒu������
    '********************************************************************
    Public Function DQM_Cng(ByVal str As String) As String
        If str = Nothing Then
            Return ""
        Else
            Return Trim(str.Replace(Chr(34), "'"))
        End If
    End Function
End Module
