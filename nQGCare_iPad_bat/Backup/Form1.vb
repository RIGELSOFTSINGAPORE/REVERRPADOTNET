Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    ' Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    'Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(448, 65)
        Me.Name = "Form1"
        Me.Text = "iPad �v��f�[�^�쐬"

    End Sub

#End Region

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL As String
    Dim i, j, r1, r2, n As Integer
    Dim WK_date2 As String
    Dim WK_IHD, WK_IHD2, loop_n, WK_amt, WK_dep As Integer

    '******************************************************************
    '** �N����
    '******************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("QG-Care ipad START", "QG-Care ipad START", System.Diagnostics.EventLogEntryType.Information)

        'WK_date1 = Format(DateAdd(DateInterval.Month, -2, Now.Date), "yyyyMM")
        WK_date2 = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyyMM")

        ''�e�X�g�p
        'WK_date1 = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyyMM")
        'WK_date2 = Format(Now.Date, "yyyyMM")

        Call DB_INIT()
        DB_OPEN("nQGCare")

        '�N���`�F�b�N(�挎���̌v��f�[�^�����邩�H)
        DsList1.Clear()
        strSQL = "SELECT �v�㌎ FROM T40_�v�� WHERE (�v�㌎ = N'" & WK_date2 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r1 = DaList1.Fill(DsList1, "chk")

        If r1 <> 0 Then
            System.Diagnostics.EventLog.WriteEntry("QG-Care ipad ABEND", "�����ς̂��ߏI��", System.Diagnostics.EventLogEntryType.Information)

        Else
            'QG-Care iPad HD(BSS��)
            DsList1.Clear()
            strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'IHD')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            r1 = DaList1.Fill(DsList1, "cls_IHD")
            If r1 <> 0 Then
                DtView1 = New DataView(DsList1.Tables("cls_IHD"), "", "", DataViewRowState.CurrentRows)
                WK_IHD = DtView1(0)("cls_code_name")
            Else
                WK_IHD = 0
            End If

            '�Ώۃf�[�^���o
            DsList1.Clear()
            strSQL = "SELECT T01_member.code, T01_member.Part_date, T01_member.wrn_fee, T05_iPad.cxl_amnt"
            strSQL += ", T05_iPad.add_flg, T05_iPad.add_date, V_T40_GLP.�a�����, V_T40_GLP.�v���"
            strSQL += " FROM T01_member INNER JOIN"
            strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
            strSQL += " V_T40_GLP ON T01_member.code = V_T40_GLP.�����ԍ�"
            strSQL += " WHERE (T01_member.delt_flg = 0)"
            strSQL += " AND (V_T40_GLP.�a����� <> 0)"
            strSQL += " AND (V_T40_GLP.�v��� < 36)"
            strSQL += " OR (V_T40_GLP.�a����� IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            r1 = DaList1.Fill(DsList1, "T40")

            If r1 <> 0 Then
                DtView1 = New DataView(DsList1.Tables("T40"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    If IsDBNull(DtView1(i)("�v���")) Then        '�V�K�o�^

                        'T40_�v��(�w���v�f�X�N��)
                        strSQL = "INSERT INTO T40_�v��"
                        strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���)"
                        strSQL += " VALUES ('" & DtView1(i)("code") & "'"                           '�����ԍ�
                        strSQL += ", N'" & WK_date2 & "'"                                           '�v�㌎
                        strSQL += ", 2"                                                             '�v��敪
                        strSQL += ", " & WK_IHD                                                     '�v����z
                        strSQL += ", 0"                                                             '�a�����
                        strSQL += ", 1"                                                             '�v���
                        strSQL += ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        WK_dep = DtView1(i)("wrn_fee") - WK_IHD

                        'T40_�v��(�ۏؕ�)
                        loop_n = DateDiff(DateInterval.Month, CDate(DtView1(i)("Part_date")), Now.Date)
                        n = 0
                        For j = 0 To loop_n - 1
                            If j = 0 Then
                                n = n + 1
                                strSQL = "INSERT INTO T40_�v��"
                                strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���)"
                                strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '�����ԍ�
                                strSQL += ", N'" & WK_date2 & "'"                                   '�v�㌎
                                strSQL += ", 1"                                                     '�v��敪
                                If DtView1(i)("wrn_fee") = 6600 Then
                                    WK_amt = 200
                                Else
                                    WK_amt = (DtView1(i)("wrn_fee") - WK_IHD) - Round((DtView1(i)("wrn_fee") - WK_IHD) / 36, 0) * 35
                                End If
                                WK_dep = WK_dep - WK_amt
                                strSQL += ", " & WK_amt                                             '�v����z
                                strSQL += ", " & WK_dep                                             '�a�����
                                strSQL += ", " & n                                                  '�v���
                                strSQL += ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                            Else
                                n = n + 1
                                strSQL = "INSERT INTO T40_�v��"
                                strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���)"
                                strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '�����ԍ�
                                strSQL += ", N'" & WK_date2 & "'"                                   '�v�㌎
                                strSQL += ", 1"                                                     '�v��敪
                                If DtView1(i)("wrn_fee") = 6600 Then
                                    WK_amt = 180
                                Else
                                    WK_amt = Round((DtView1(i)("wrn_fee") - WK_IHD) / 36, 0)
                                End If
                                WK_dep = WK_dep - WK_amt
                                strSQL += ", " & WK_amt                                             '�v����z
                                strSQL += ", " & WK_dep                                             '�a�����
                                strSQL += ", " & n                                                  '�v���
                                strSQL += ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                            End If
                        Next

                        '�o�^���ɑS��
                        If DtView1(i)("cxl_amnt") <> 0 Then         '�S��
                            n = n + 1
                            strSQL = "INSERT INTO T40_�v��"
                            strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���, �S��flg)"
                            strSQL += " VALUES ('" & DtView1(i)("code") & "'"                       '�����ԍ�
                            strSQL += ", N'" & WK_date2 & "'"                                       '�v�㌎
                            strSQL += ", 1"                                                         '�v��敪
                            strSQL += ", " & WK_dep                                                 '�v����z
                            strSQL += ", 0"                                                         '�a�����
                            strSQL += ", " & n                                                      '�v���
                            strSQL += ", 1"                                                         '�S��flg
                            strSQL += ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            '����
                            n = n + 1
                            strSQL = "INSERT INTO T40_�v��"
                            strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���, �S��flg)"
                            strSQL += " VALUES ('" & DtView1(i)("code") & "'"                       '�����ԍ�
                            strSQL += ", N'" & WK_date2 & "'"                                       '�v�㌎
                            strSQL += ", 1"                                                         '�v��敪
                            strSQL += ", " & DtView1(i)("cxl_amnt") * -1                            '�v����z
                            strSQL += ", 0"                                                         '�a�����
                            strSQL += ", " & n                                                      '�v���
                            strSQL += ", 1"                                                         '�S��flg
                            strSQL += ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                        End If
                    Else                                            '�ǉ�

                        If DtView1(i)("cxl_amnt") <> 0 Then         '�S��
                            '���v�㕪���ׂČv��
                            strSQL = "INSERT INTO T40_�v��"
                            strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���, �S��flg)"
                            strSQL += " VALUES ('" & DtView1(i)("code") & "'"                       '�����ԍ�
                            strSQL += ", N'" & WK_date2 & "'"                                       '�v�㌎
                            strSQL += ", 1"                                                         '�v��敪
                            strSQL += ", " & DtView1(i)("�a�����")                                 '�v����z
                            strSQL += ", 0"                                                         '�a�����
                            strSQL += ", " & DtView1(i)("�v���") + 1                             '�v���
                            strSQL += ", 1"                                                         '�S��flg
                            strSQL += ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            '����
                            strSQL = "INSERT INTO T40_�v��"
                            strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���, �S��flg)"
                            strSQL += " VALUES ('" & DtView1(i)("code") & "'"                       '�����ԍ�
                            strSQL += ", N'" & WK_date2 & "'"                                       '�v�㌎
                            strSQL += ", 1"                                                         '�v��敪
                            strSQL += ", " & DtView1(i)("cxl_amnt") * -1                            '�v����z
                            strSQL += ", 0"                                                         '�a�����
                            strSQL += ", " & DtView1(i)("�v���") + 2                             '�v���
                            strSQL += ", 1"                                                         '�S��flg
                            strSQL += ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                        Else

                            'QG-Care iPad HD(BSS��)
                            WK_DsList1.Clear()
                            strSQL = "SELECT �v����z FROM T40_�v�� WHERE (�v��敪 = 2) AND (�����ԍ� = '" & DtView1(i)("code") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            SqlCmd1.CommandTimeout = 600
                            r1 = DaList1.Fill(WK_DsList1, "WK_IHD2")
                            If r1 <> 0 Then
                                WK_DtView1 = New DataView(WK_DsList1.Tables("WK_IHD2"), "", "", DataViewRowState.CurrentRows)
                                WK_IHD2 = WK_DtView1(0)("�v����z")
                            Else
                                WK_IHD2 = 0
                            End If

                            If DtView1(i)("Part_date") >= "2014/04/01" Then         '2014/04/01�ȍ~�i�ʏ�j
                                strSQL = "INSERT INTO T40_�v��"
                                strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���)"
                                strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '�����ԍ�
                                strSQL += ", N'" & WK_date2 & "'"                                   '�v�㌎
                                strSQL += ", 1"                                                     '�v��敪
                                If DtView1(i)("wrn_fee") = 6600 Then
                                    WK_amt = 180
                                Else
                                    WK_amt = Round((DtView1(i)("wrn_fee") - WK_IHD2) / 36, 0)
                                End If
                                strSQL += ", " & WK_amt                                             '�v����z
                                strSQL += ", " & DtView1(i)("�a�����") - WK_amt                    '�a�����
                                strSQL += ", " & DtView1(i)("�v���") + 1                         '�v���
                                strSQL += ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()

                            Else                                                    '2014/03/31�ȑO�i�ǒ��j

                                If DtView1(i)("add_flg") = "True" Then              '�ǒ�����
                                    strSQL = "INSERT INTO T40_�v��"
                                    strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���)"
                                    strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '�����ԍ�
                                    strSQL += ", N'" & WK_date2 & "'"                                   '�v�㌎
                                    strSQL += ", 1"                                                     '�v��敪
                                    WK_amt = Round(DtView1(i)("�a�����") / (36 - DtView1(i)("�v���")), 0)
                                    strSQL += ", " & WK_amt                                             '�v����z
                                    strSQL += ", " & DtView1(i)("�a�����") - WK_amt                    '�a�����
                                    strSQL += ", " & DtView1(i)("�v���") + 1                         '�v���
                                    strSQL += ")"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    SqlCmd1.CommandTimeout = 600
                                    SqlCmd1.ExecuteNonQuery()

                                Else                                                '�ǒ��Ȃ�
                                    strSQL = "INSERT INTO T40_�v��"
                                    strSQL += " (�����ԍ�, �v�㌎, �v��敪, �v����z, �a�����, �v���)"
                                    strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '�����ԍ�
                                    strSQL += ", N'" & WK_date2 & "'"                                   '�v�㌎
                                    strSQL += ", 1"                                                     '�v��敪
                                    If DtView1(i)("wrn_fee") = 6600 Then
                                        WK_amt = 175
                                    Else
                                        WK_amt = Round((DtView1(i)("wrn_fee") - WK_IHD2) / 36 * 1.05 / 1.08, 0)
                                    End If
                                    strSQL += ", " & WK_amt                                             '�v����z
                                    strSQL += ", " & DtView1(i)("�a�����") - WK_amt                    '�a�����
                                    strSQL += ", " & DtView1(i)("�v���") + 1                         '�v���
                                    strSQL += ")"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    SqlCmd1.CommandTimeout = 600
                                    SqlCmd1.ExecuteNonQuery()

                                End If
                            End If
                        End If
                    End If
                Next
            End If

            System.Diagnostics.EventLog.WriteEntry("QG-Care ipad END", "QG-Care ipad END", System.Diagnostics.EventLogEntryType.Information)
        End If
        DB_CLOSE()
        Application.Exit()
    End Sub
End Class
