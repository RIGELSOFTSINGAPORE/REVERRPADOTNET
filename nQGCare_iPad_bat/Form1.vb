Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(448, 65)
        Me.Name = "Form1"
        Me.Text = "iPad 計上データ作成"

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
    '** 起動時
    '******************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("QG-Care ipad START", "QG-Care ipad START", System.Diagnostics.EventLogEntryType.Information)

        'WK_date1 = Format(DateAdd(DateInterval.Month, -2, Now.Date), "yyyyMM")
        WK_date2 = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyyMM")

        ''テスト用
        'WK_date1 = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyyMM")
        'WK_date2 = Format(Now.Date, "yyyyMM")

        Call DB_INIT()
        DB_OPEN("nQGCare")

        '起動チェック(先月分の計上データがあるか？)
        DsList1.Clear()
        strSQL = "SELECT 計上月 FROM T40_計上 WHERE (計上月 = N'" & WK_date2 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r1 = DaList1.Fill(DsList1, "chk")

        If r1 <> 0 Then
            System.Diagnostics.EventLog.WriteEntry("QG-Care ipad ABEND", "処理済のため終了", System.Diagnostics.EventLogEntryType.Information)

        Else
            'QG-Care iPad HD(BSS分)
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

            '対象データ抽出
            DsList1.Clear()
            strSQL = "SELECT T01_member.code, T01_member.Part_date, T01_member.wrn_fee, T05_iPad.cxl_amnt"
            strSQL += ", T05_iPad.add_flg, T05_iPad.add_date, V_T40_GLP.預かり金, V_T40_GLP.計上回数"
            strSQL += " FROM T01_member INNER JOIN"
            strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
            strSQL += " V_T40_GLP ON T01_member.code = V_T40_GLP.加入番号"
            strSQL += " WHERE (T01_member.delt_flg = 0)"
            strSQL += " AND (V_T40_GLP.預かり金 <> 0)"
            strSQL += " AND (V_T40_GLP.計上回数 < 36)"
            strSQL += " OR (V_T40_GLP.預かり金 IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            r1 = DaList1.Fill(DsList1, "T40")

            If r1 <> 0 Then
                DtView1 = New DataView(DsList1.Tables("T40"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    If IsDBNull(DtView1(i)("計上回数")) Then        '新規登録

                        'T40_計上(ヘルプデスク分)
                        strSQL = "INSERT INTO T40_計上"
                        strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                        strSQL += " VALUES ('" & DtView1(i)("code") & "'"                           '加入番号
                        strSQL += ", N'" & WK_date2 & "'"                                           '計上月
                        strSQL += ", 2"                                                             '計上区分
                        strSQL += ", " & WK_IHD                                                     '計上金額
                        strSQL += ", 0"                                                             '預かり金
                        strSQL += ", 1"                                                             '計上回数
                        strSQL += ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        WK_dep = DtView1(i)("wrn_fee") - WK_IHD

                        'T40_計上(保証分)
                        loop_n = DateDiff(DateInterval.Month, CDate(DtView1(i)("Part_date")), Now.Date)
                        n = 0
                        For j = 0 To loop_n - 1
                            If j = 0 Then
                                n = n + 1
                                strSQL = "INSERT INTO T40_計上"
                                strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                                strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '加入番号
                                strSQL += ", N'" & WK_date2 & "'"                                   '計上月
                                strSQL += ", 1"                                                     '計上区分
                                If DtView1(i)("wrn_fee") = 6600 Then
                                    WK_amt = 200
                                Else
                                    WK_amt = (DtView1(i)("wrn_fee") - WK_IHD) - Round((DtView1(i)("wrn_fee") - WK_IHD) / 36, 0) * 35
                                End If
                                WK_dep = WK_dep - WK_amt
                                strSQL += ", " & WK_amt                                             '計上金額
                                strSQL += ", " & WK_dep                                             '預かり金
                                strSQL += ", " & n                                                  '計上回数
                                strSQL += ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                            Else
                                n = n + 1
                                strSQL = "INSERT INTO T40_計上"
                                strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                                strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '加入番号
                                strSQL += ", N'" & WK_date2 & "'"                                   '計上月
                                strSQL += ", 1"                                                     '計上区分
                                If DtView1(i)("wrn_fee") = 6600 Then
                                    WK_amt = 180
                                Else
                                    WK_amt = Round((DtView1(i)("wrn_fee") - WK_IHD) / 36, 0)
                                End If
                                WK_dep = WK_dep - WK_amt
                                strSQL += ", " & WK_amt                                             '計上金額
                                strSQL += ", " & WK_dep                                             '預かり金
                                strSQL += ", " & n                                                  '計上回数
                                strSQL += ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                            End If
                        Next

                        '登録月に全損
                        If DtView1(i)("cxl_amnt") <> 0 Then         '全損
                            n = n + 1
                            strSQL = "INSERT INTO T40_計上"
                            strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数, 全損flg)"
                            strSQL += " VALUES ('" & DtView1(i)("code") & "'"                       '加入番号
                            strSQL += ", N'" & WK_date2 & "'"                                       '計上月
                            strSQL += ", 1"                                                         '計上区分
                            strSQL += ", " & WK_dep                                                 '計上金額
                            strSQL += ", 0"                                                         '預かり金
                            strSQL += ", " & n                                                      '計上回数
                            strSQL += ", 1"                                                         '全損flg
                            strSQL += ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            '解約金
                            n = n + 1
                            strSQL = "INSERT INTO T40_計上"
                            strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数, 全損flg)"
                            strSQL += " VALUES ('" & DtView1(i)("code") & "'"                       '加入番号
                            strSQL += ", N'" & WK_date2 & "'"                                       '計上月
                            strSQL += ", 1"                                                         '計上区分
                            strSQL += ", " & DtView1(i)("cxl_amnt") * -1                            '計上金額
                            strSQL += ", 0"                                                         '預かり金
                            strSQL += ", " & n                                                      '計上回数
                            strSQL += ", 1"                                                         '全損flg
                            strSQL += ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                        End If
                    Else                                            '追加

                        If DtView1(i)("cxl_amnt") <> 0 Then         '全損
                            '未計上分すべて計上
                            strSQL = "INSERT INTO T40_計上"
                            strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数, 全損flg)"
                            strSQL += " VALUES ('" & DtView1(i)("code") & "'"                       '加入番号
                            strSQL += ", N'" & WK_date2 & "'"                                       '計上月
                            strSQL += ", 1"                                                         '計上区分
                            strSQL += ", " & DtView1(i)("預かり金")                                 '計上金額
                            strSQL += ", 0"                                                         '預かり金
                            strSQL += ", " & DtView1(i)("計上回数") + 1                             '計上回数
                            strSQL += ", 1"                                                         '全損flg
                            strSQL += ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            '解約金
                            strSQL = "INSERT INTO T40_計上"
                            strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数, 全損flg)"
                            strSQL += " VALUES ('" & DtView1(i)("code") & "'"                       '加入番号
                            strSQL += ", N'" & WK_date2 & "'"                                       '計上月
                            strSQL += ", 1"                                                         '計上区分
                            strSQL += ", " & DtView1(i)("cxl_amnt") * -1                            '計上金額
                            strSQL += ", 0"                                                         '預かり金
                            strSQL += ", " & DtView1(i)("計上回数") + 2                             '計上回数
                            strSQL += ", 1"                                                         '全損flg
                            strSQL += ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                        Else

                            'QG-Care iPad HD(BSS分)
                            WK_DsList1.Clear()
                            strSQL = "SELECT 計上金額 FROM T40_計上 WHERE (計上区分 = 2) AND (加入番号 = '" & DtView1(i)("code") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            SqlCmd1.CommandTimeout = 600
                            r1 = DaList1.Fill(WK_DsList1, "WK_IHD2")
                            If r1 <> 0 Then
                                WK_DtView1 = New DataView(WK_DsList1.Tables("WK_IHD2"), "", "", DataViewRowState.CurrentRows)
                                WK_IHD2 = WK_DtView1(0)("計上金額")
                            Else
                                WK_IHD2 = 0
                            End If

                            If DtView1(i)("Part_date") >= "2014/04/01" Then         '2014/04/01以降（通常）
                                strSQL = "INSERT INTO T40_計上"
                                strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                                strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '加入番号
                                strSQL += ", N'" & WK_date2 & "'"                                   '計上月
                                strSQL += ", 1"                                                     '計上区分
                                If DtView1(i)("wrn_fee") = 6600 Then
                                    WK_amt = 180
                                Else
                                    WK_amt = Round((DtView1(i)("wrn_fee") - WK_IHD2) / 36, 0)
                                End If
                                strSQL += ", " & WK_amt                                             '計上金額
                                strSQL += ", " & DtView1(i)("預かり金") - WK_amt                    '預かり金
                                strSQL += ", " & DtView1(i)("計上回数") + 1                         '計上回数
                                strSQL += ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()

                            Else                                                    '2014/03/31以前（追徴）

                                If DtView1(i)("add_flg") = "True" Then              '追徴あり
                                    strSQL = "INSERT INTO T40_計上"
                                    strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                                    strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '加入番号
                                    strSQL += ", N'" & WK_date2 & "'"                                   '計上月
                                    strSQL += ", 1"                                                     '計上区分
                                    WK_amt = Round(DtView1(i)("預かり金") / (36 - DtView1(i)("計上回数")), 0)
                                    strSQL += ", " & WK_amt                                             '計上金額
                                    strSQL += ", " & DtView1(i)("預かり金") - WK_amt                    '預かり金
                                    strSQL += ", " & DtView1(i)("計上回数") + 1                         '計上回数
                                    strSQL += ")"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    SqlCmd1.CommandTimeout = 600
                                    SqlCmd1.ExecuteNonQuery()

                                Else                                                '追徴なし
                                    strSQL = "INSERT INTO T40_計上"
                                    strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                                    strSQL += " VALUES ('" & DtView1(i)("code") & "'"                   '加入番号
                                    strSQL += ", N'" & WK_date2 & "'"                                   '計上月
                                    strSQL += ", 1"                                                     '計上区分
                                    If DtView1(i)("wrn_fee") = 6600 Then
                                        WK_amt = 175
                                    Else
                                        WK_amt = Round((DtView1(i)("wrn_fee") - WK_IHD2) / 36 * 1.05 / 1.08, 0)
                                    End If
                                    strSQL += ", " & WK_amt                                             '計上金額
                                    strSQL += ", " & DtView1(i)("預かり金") - WK_amt                    '預かり金
                                    strSQL += ", " & DtView1(i)("計上回数") + 1                         '計上回数
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
