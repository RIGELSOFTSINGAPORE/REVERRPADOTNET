Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Sagyou_Report_Apple
    Inherits SectionReport
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet

    Dim DtView1, WK_DtView1 As DataView
    Dim strSQL As String
    Dim i, r, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        TextBox1.Text = "���s�� " & Format(Now.Date, "yyyy �N MM �� dd ��")

        '�C�����e
        TextBox18.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox18.Text = DtView1(i)("cmnt")
                Else
                    TextBox18.Text += vbCrLf & DtView1(i)("cmnt")
                End If
            Next
        End If

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

        If TextBox2.Text = Nothing Then '��Г`�[�ԍ��Ȃ��̎���\��
            Label1.Visible = False
        End If

        If TextBox57.Text = Nothing Then
            TextBox6.Text = TextBox56.Text
        Else
            TextBox6.Text = TextBox56.Text & "(" & TextBox57.Text & ")"
        End If

        'TextBox8.Text = StrConv(Trim(TextBox58.Text.Replace(vbCrLf, "")), VbStrConv.Narrow) & " " & StrConv(Trim(TextBox59.Text), VbStrConv.Narrow) # ram 2020-12-10
        TextBox8.Text = Trim(TextBox58.Text.Replace(vbCrLf, "")) & " " & Trim(TextBox59.Text)
        TextBox9.Text = "TEL " & TextBox60.Text & "�@FAX " & TextBox61.Text

        Dim wk_tel As String = Nothing
        DsList1.Clear()
        strSQL = "SELECT print_tel, print_fax FROM M08_STORE WHERE (store_code = '" & TextBox78.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M08_STORE")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            If Not IsDBNull(DtView1(0)("print_tel")) Then
                If Trim(DtView1(0)("print_tel")) <> "" Then
                    wk_tel += "TEL " & Trim(DtView1(0)("print_tel"))
                End If
            End If
            If Not IsDBNull(DtView1(0)("print_fax")) Then
                If Trim(DtView1(0)("print_fax")) <> "" Then
                    wk_tel += "�@FAX " & Trim(DtView1(0)("print_fax"))
                End If
            End If
        End If
        If wk_tel <> Nothing Then
            TextBox9.Text = wk_tel
        End If

        If TextBox78.Text = "0020" Then '���
            TextBox12.Text = TextBox63.Text & "�@�l"
        Else
            TextBox12.Text = Trim(TextBox77.Text) & " / " & Trim(TextBox63.Text) & "�@�l"
            TextBox12.Text = TextBox12.Text.Replace(vbCrLf, "")
        End If

        If Trim(TextBox64.Text) <> Nothing Then
            If Trim(TextBox18.Text) <> Nothing Then
                TextBox18.Text += vbCrLf & TextBox64.Text
            Else
                TextBox18.Text = TextBox64.Text
            End If
        End If

        TextBox16.Text = Nothing
        If Trim(TextBox74.Text) <> "refused@apple.com" Then
            TextBox16.Text = Trim(TextBox74.Text)
        End If

        TextBox19.Text = "�C���敪�F" & TextBox65.Text & "�@�@�C���ԍ��F" & TextBox66.Text
        If TextBox80.Text = "True" Then
            TextBox79.Text = "�z���C��"
        Else
            TextBox79.Text = "�X���C��"
        End If

        '���i
        TextBox21.Text = Nothing : TextBox26.Text = Nothing : TextBox31.Text = Nothing : TextBox36.Text = Nothing : TextBox41.Text = Nothing
        TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox32.Text = Nothing : TextBox37.Text = Nothing : TextBox42.Text = Nothing
        TextBox23.Text = Nothing : TextBox28.Text = Nothing : TextBox33.Text = Nothing : TextBox38.Text = Nothing : TextBox43.Text = Nothing
        TextBox24.Text = Nothing : TextBox29.Text = Nothing : TextBox34.Text = Nothing : TextBox39.Text = Nothing : TextBox44.Text = Nothing
        TextBox25.Text = Nothing : TextBox30.Text = Nothing : TextBox35.Text = Nothing : TextBox40.Text = Nothing : TextBox45.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        WK_cnt = 0 : WK_amnt = 0
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("exp_flg")) Then DtView1(i)("exp_flg") = "False"
                Select Case i
                    Case Is = 0
                        TextBox21.Text = DtView1(i)("part_code")
                        TextBox26.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox31.Text = DtView1(i)("s_n")
                        TextBox36.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox41.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox41.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 1
                        TextBox22.Text = DtView1(i)("part_code")
                        TextBox27.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox32.Text = DtView1(i)("s_n")
                        TextBox37.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox42.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox42.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 2
                        TextBox23.Text = DtView1(i)("part_code")
                        TextBox28.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox33.Text = DtView1(i)("s_n")
                        TextBox38.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox43.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox43.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 3
                        TextBox24.Text = DtView1(i)("part_code")
                        TextBox29.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox34.Text = DtView1(i)("s_n")
                        TextBox39.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox44.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox44.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Else
                        TextBox25.Text = DtView1(i)("part_code")
                        TextBox30.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox35.Text = DtView1(i)("s_n")
                        TextBox40.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            ' TextBox45.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")  'Ram
                            TextBox45.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            'ram
                            ' TextBox45.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                            TextBox45.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")

                        End If
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + CInt(TextBox45.Text)
                End Select

                If DtView1.Count > 5 Then
                    TextBox25.Text = "���̑����i"
                    TextBox30.Text = Nothing
                    TextBox35.Text = Nothing
                    TextBox40.Text = WK_cnt
                    TextBox45.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If

        'prabu uncomment 2022-01-05
        If TextBox72.Text = "01" Then
            TextBox46.Text = "\" & Format(CInt(TextBox76.Text), "##,##0")
        Else
            TextBox46.Text = "\" & Format(CInt(TextBox41.Text) + CInt(TextBox42.Text) + CInt(TextBox43.Text) + CInt(TextBox44.Text) + WK_amnt, "##,##0")
        End If

        TextBox47.Text = "\" & Format(CInt(TextBox10.Text) + CInt(TextBox62.Text) + CInt(TextBox69.Text), "##,##0")
        TextBox48.Text = "\" & Format(CInt(TextBox46.Text.Replace("\", "")) + CInt(TextBox47.Text.Replace("\", "")), "##,##0")

        If TextBox72.Text = "01" Then
            'TextBox49.Text = "�Ȃ�"
            TextBox50.Text = "\0"
            TextBox51.Text = "\" & Format(CInt(TextBox73.Text), "##,##0")
        Else
            'TextBox49.Text = "����"
            TextBox50.Text = "\" & Format(CInt(TextBox48.Text) * -1, "##,##0")
            TextBox51.Text = "\0"
        End If

        TextBox49.Text = "\" & Format(CInt(TextBox81.Text), "##,##0")

        TextBox52.Text = "\" & Format(CInt(TextBox48.Text.Replace("\", "")) + CInt(TextBox50.Text.Replace("\", "")) + CInt(TextBox51.Text.Replace("\", "")) + CInt(TextBox49.Text.Replace("\", "")), "##,##0")

        TextBox20.Text = Nothing
        If IsDate(TextBox.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " ���\���̏Ǐ�����؂������܂����B"
        End If
        If IsDate(TextBox70.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox70.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " ���i�̏C�������{�������܂����B"
        End If
        If IsDate(TextBox71.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox71.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " ���a���肵�����i�̏C���Ɋւ��āA���A���������܂����B"
        End If
        If TextBox67.Text <> Nothing Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += TextBox67.Text
        End If

        TextBox53.Text = "�C����ۏ؂͌������i�ɑ΂��ēK�p����܂��B�C����ۏ؊��Ԃ͏C����������" & Trim(TextBox68.Text) & "���ł��B"
        TextBox53.Text += vbCrLf & "���C���ۏ؂͋@���Q�ɂ̂ݓK�p����A➑̂̑����₨�q�l�ߎ��ɂ��̏�Ȃǂɂ͓K�p����܂���B"
        TextBox53.Text += vbCrLf & "���A�C��/�����������i�܂��͐��i�́A�V�i�A�܂��͐��\�ƐM�����̗��ʂɉ����ĐV�i���l�ł��B"

        If TextBox78.Text = "0020" Then '���
            TextBox54.Text = "����A�̏Ⴊ�������܂����ۂɂ́A���񍐏��������Q�̏�A�ďC�������\�����݂��������B"
            TextBox54.Text += vbCrLf & "�C�����������2�T�Ԉȓ��̂��q�l�́A�D���t�Ή������Ē����܂��̂ł��\���t���������B"
            TextBox54.Text += vbCrLf & "���i�̔j���⏝�A�t�̑����Ȃǂ͏C����ۏ؁E�D���t�̑ΏۊO�ł��B"
        Else
            TextBox54.Text = "����A�̏Ⴊ�������܂����ۂɂ́A���񍐏��������Q�̏�A�ďC�������\�����݂��������B"
            TextBox54.Text += vbCrLf & "���i�̔j���⏝�A�t�̑����Ȃǂ͏C����ۏ؂̑ΏۊO�ƂȂ�܂��B"
        End If

        TextBox55.Text = "�l���̎��W�A���p�A�񋟋y�ѓo�^�Ɋւ��āA�ȉ��̂悤�Ɏ�舵���܂��B"
        TextBox55.Text += vbCrLf & "�@�C����Ƃ𕾎Ђ����O�҂Ɉϑ�����ꍇ�́A���q�l����K�v�Ȕ͈͂ŊJ�����܂����A�C���ȊO�̖ړI�ɂ͎g�p����܂���B"
        TextBox55.Text += vbCrLf & "�A���q�l���̏ڍׁi���O��d�b�ԍ��j�́AApple�Ђɂ���Ē񋟂܂��͎g�p�����ꍇ���������܂��B"
        TextBox55.Text += vbCrLf & "�B��L�̏ꍇ�������A�C���Ɩ��Œm�肦�����q�l�̌l���́A��O�҂ɘR�����A�J���������܂���B"

    End Sub
    Function part_amt_get(ByVal vndr_code As String, ByVal part_code As String, ByVal rcpt_no As String, ByVal qty As Integer, ByVal ibm_flg As String) As Integer
        Dim cost As Integer = 0
        Dim EU_rate As Decimal = 0
        Dim GSS_rate As Decimal = 0
        Dim GSS_amnt As Integer = 0
        Dim store_code As String = Nothing
        Dim grup_code As String = Nothing
        Dim GSS_kijo As Integer = 0
        Dim part_amnt As Integer = 0
        Dim own_flg As String = "0"
        Dim note_kbn As String = Nothing
        DsList1.Clear()

        '�R�X�g
        strSQL = "SELECT stc_amnt, exc_amnt"
        strSQL += " FROM M40_PART"
        strSQL += " WHERE (vndr_code = '" & vndr_code & "')"
        strSQL += " AND (part_code = '" & part_code & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "M40_PART")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("M40_PART"), "", "", DataViewRowState.CurrentRows)
            If IsDBNull(WK_DtView1(0)("exc_amnt")) Then WK_DtView1(0)("exc_amnt") = 0
            If IsDBNull(WK_DtView1(0)("stc_amnt")) Then WK_DtView1(0)("stc_amnt") = 0
            If CInt(WK_DtView1(0)("exc_amnt")) <> 0 Then
                cost = WK_DtView1(0)("exc_amnt")
            Else
                If CInt(WK_DtView1(0)("stc_amnt")) <> 0 Then
                    cost = WK_DtView1(0)("stc_amnt")
                End If
            End If
        End If

        'EU�|��
        strSQL = "SELECT T01_REP_MTR.rcpt_no, T01_REP_MTR.part_rate2, T01_REP_MTR.store_code, M08_STORE.grup_code, M06_RPAR_COMP.own_flg, T01_REP_MTR.note_kbn"
        strSQL += " FROM T01_REP_MTR INNER JOIN"
        strSQL += " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
        strSQL += " M06_RPAR_COMP ON T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "T01_REP_MTR")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView1(0)("part_rate2")) Then EU_rate = WK_DtView1(0)("part_rate2")
            If Not IsDBNull(WK_DtView1(0)("store_code")) Then store_code = WK_DtView1(0)("store_code")
            If Not IsDBNull(WK_DtView1(0)("grup_code")) Then grup_code = WK_DtView1(0)("grup_code")
            If Not IsDBNull(WK_DtView1(0)("own_flg")) Then own_flg = WK_DtView1(0)("own_flg")
            If Not IsDBNull(WK_DtView1(0)("note_kbn")) Then note_kbn = WK_DtView1(0)("note_kbn")
        End If

        '�v��|��
        strSQL = "SELECT part_rate, part_amnt"
        strSQL += " FROM M31_PART_RATE"
        strSQL += " WHERE (delt_flg = 0)"
        strSQL += " AND (vndr_code = '" & vndr_code & "')"
        strSQL += " AND (store_code = '" & store_code & "')"
        strSQL += " AND (note_kbn = '" & note_kbn & "')"
        If own_flg = "True" Then
            strSQL += " AND (own_rpat_kbn = '01')"
        Else
            strSQL += " AND (own_rpat_kbn = '02')"
        End If
        strSQL += " AND (strt_amnt <= " & cost & ")"
        strSQL += " AND (end_amnt >= " & cost & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "M31_PART_RATE")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView1(0)("part_rate")) Then GSS_rate = WK_DtView1(0)("part_rate")
            If Not IsDBNull(WK_DtView1(0)("part_amnt")) Then GSS_amnt = WK_DtView1(0)("part_amnt")
        End If

        If own_flg = "True" Then
            GSS_kijo = RoundUP(cost * GSS_rate * qty + GSS_amnt, -2)
        Else
            GSS_kijo = RoundUP(cost * GSS_rate * qty, -2)
            If (vndr_code = "01" Or vndr_code = "06") And note_kbn = "01" Then    'Apple��z
            Else
                If GSS_amnt <> 0 Then
                    If cost * qty >= 5000 Then
                        GSS_kijo = RoundUP(cost * GSS_rate * qty + GSS_amnt, -2)
                    End If
                End If
                If ibm_flg = "True" Then
                    GSS_kijo += 3000
                End If
            End If
        End If

        If grup_code = "18" Or grup_code = "52" Then  'BIC
            part_amnt = RoundUP(GSS_kijo * EU_rate, 0)
        Else
            part_amnt = RoundUP(GSS_kijo * EU_rate, -2)
        End If

        Return part_amnt
    End Function
End Class
