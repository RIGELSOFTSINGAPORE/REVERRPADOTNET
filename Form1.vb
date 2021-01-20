Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL, WK_MSG As String
    Dim i, j, k, cnt As Integer
    Dim str_date As Date
    Dim WK_MODEL As String

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 52)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "S5 web data 抽出中"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(368, 81)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("BEST web START", "データコピーを開始しました。", System.Diagnostics.EventLogEntryType.Information)
        Call DB_INIT()

        '****************
        '** 店舗マスタ
        '****************
        strSQL = "DELETE FROM shop_mtr"
        DB_OPEN("s5")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "SELECT BY_cls, shop_code, [店舗名(漢字)] FROM Shop_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(DsList1, "Shop_mtr")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("Shop_mtr"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            DB_OPEN("s5")
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO shop_mtr (BY_cls, shop_code, shop_name)"
                strSQL += " VALUES ('" & DtView1(i)("BY_cls") & "'"
                strSQL += ", '" & DtView1(i)("shop_code") & "'"
                strSQL += ", '" & DtView1(i)("店舗名(漢字)") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Next
            DB_CLOSE()
        End If
        System.Diagnostics.EventLog.WriteEntry("BEST web shop END " & DtView1.Count & " 件", "データコピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)

        '****************
        '** 旧加入データ
        '****************
        str_date = Format(Now.Date, "yyyy/MM" & "/01")

        strSQL = "DELETE FROM wrn_data"
        DB_OPEN("s5")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 3600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        cnt = 0
        k = -6

        DsList1.Clear()
        strSQL = "SELECT wrn_data.ordr_no, wrn_data.line_no, wrn_data.model_name, wrn_data_corp.corp_flg, wrn_data.prch_date"
        strSQL = strSQL & " FROM wrn_data LEFT OUTER JOIN wrn_data_corp ON wrn_data.ordr_no = wrn_data_corp.ordr_no"
        strSQL = strSQL & " WHERE (wrn_data.prch_date >= CONVERT(DATETIME, '" & DateAdd(DateInterval.Year, k, str_date) & "', 102))"
        strSQL = strSQL & " AND (wrn_data.cont_flg = 'A')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn_data2")
        SqlCmd1.CommandTimeout = 7200
        DaList1.Fill(DsList1, "wrn_data")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("wrn_data"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            DB_OPEN("s5")
            For i = 0 To DtView1.Count - 1
                WK_MODEL = Trim(DtView1(i)("model_name"))
                WK_MODEL = WK_MODEL.Replace("'", " ")

                strSQL = "INSERT INTO wrn_data (ordr_no, line, seq, model, corp_flg, prch_date, wrn_prod, BY_cls)"
                strSQL = strSQL & " VALUES ('" & DtView1(i)("ordr_no") & "'"
                strSQL = strSQL & ", '" & DtView1(i)("line_no") & "'"
                strSQL = strSQL & ", 0"
                strSQL = strSQL & ", '" & Trim(WK_MODEL) & "'"
                If Not IsDBNull(DtView1(i)("corp_flg")) Then
                    strSQL = strSQL & ", '" & DtView1(i)("corp_flg") & "'"
                Else
                    strSQL = strSQL & ", '0'"
                End If
                strSQL = strSQL & ", '" & DtView1(i)("prch_date") & "'"
                strSQL = strSQL & ", '60', 'B')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                cnt = cnt + 1
            Next
            DB_CLOSE()
        End If
        System.Diagnostics.EventLog.WriteEntry("BEST web wrn2 END " & cnt & " 件", "データコピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)

        '****************
        '** 新加入データ
        '****************
        str_date = Format(Now.Date, "yyyy/MM" & "/01")
        cnt = 0
        For k = -6 To -1
            If k = -1 Then
                WK_MSG = "新加入データ " & DateAdd(DateInterval.Year, k, str_date) & "～"
            Else
                WK_MSG = "新加入データ " & DateAdd(DateInterval.Year, k, str_date) & "～" & DateAdd(DateInterval.Year, k + 1, str_date)
            End If
            DsList1.Clear()
            strSQL = "SELECT ordr_no, line_no, seq, model_name, corp_flg, prch_date, wrn_prod, BY_cls"
            strSQL += " FROM Wrn_sub"
            strSQL += " WHERE (prch_date >= CONVERT(DATETIME, '" & DateAdd(DateInterval.Year, k, str_date) & "', 102)"
            If k = -1 Then
                strSQL += ")"
            Else
                strSQL += " AND prch_date < CONVERT(DATETIME, '" & DateAdd(DateInterval.Year, k + 1, str_date) & "', 102))"
            End If
            strSQL += " AND (cont_flg = 'A')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 10800  '３時間待ってみる
            DaList1.Fill(DsList1, "wrn_data")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("wrn_data"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                DB_OPEN("s5")
                For i = 0 To DtView1.Count - 1
                    strSQL = "INSERT INTO wrn_data (ordr_no, line, seq, model, corp_flg, prch_date, wrn_prod, BY_cls)"
                    strSQL += " VALUES ('" & DtView1(i)("ordr_no") & "'"
                    strSQL += ", '" & DtView1(i)("line_no") & "'"
                    strSQL += ", " & DtView1(i)("seq") & ""
                    strSQL += ", '" & Trim(DtView1(i)("model_name")) & "'"
                    strSQL += ", '" & DtView1(i)("corp_flg") & "'"
                    strSQL += ", '" & DtView1(i)("prch_date") & "'"
                    strSQL += ", '" & DtView1(i)("wrn_prod") & "'"
                    strSQL += ", '" & DtView1(i)("BY_cls") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    cnt = cnt + 1
                Next
                DB_CLOSE()
                System.Diagnostics.EventLog.WriteEntry("BEST web new wrn END " & Format(DateAdd(DateInterval.Year, k, str_date), "yyyy") & " " & DtView1.Count & " 件", WK_MSG & "　コピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)
            End If
        Next
        System.Diagnostics.EventLog.WriteEntry("BEST web new wrn END ALL " & cnt & " 件", "データコピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)

        '****************
        '** 修理データ
        '****************
        strSQL = "DELETE FROM ivc_data"
        DB_OPEN("s5")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 3600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        cnt = 0
        For k = 0 To 9
            DsList1.Clear()
            strSQL = "SELECT * FROM wrn_data WHERE (ordr_no LIKE '" & k & "%')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("s5")
            SqlCmd1.CommandTimeout = 7200
            DaList1.Fill(DsList1, "wrn_data")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("wrn_data"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                For i = 0 To DtView1.Count - 1
                    DsList2.Clear()
                    strSQL = "SELECT ordr_no, line_no, seq, FLD020, close_date, FLD028, FLD012"
                    strSQL = strSQL & " FROM Wrn_ivc"
                    strSQL = strSQL & " WHERE (FLD032 = N'1')"
                    strSQL = strSQL & " AND (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line") & "')"
                    strSQL = strSQL & " AND (seq = '" & DtView1(i)("seq") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList2, "Wrn_ivc")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList2.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        DB_OPEN("s5")
                        For j = 0 To DtView2.Count - 1
                            strSQL = "INSERT INTO ivc_data (ordr_no, line, seq, ser_no, close_date, price, fin_shop_code, BY_cls)"
                            strSQL = strSQL & " VALUES ('" & DtView2(j)("ordr_no") & "'"
                            strSQL = strSQL & ", '" & DtView2(j)("line_no") & "'"
                            strSQL = strSQL & ", " & DtView2(j)("seq") & ""
                            If Not IsDBNull(DtView2(j)("FLD020")) Then strSQL = strSQL & ", '" & DtView2(j)("FLD020") & "'" Else strSQL = strSQL & ", NULL"
                            strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView2(j)("close_date") & "', 102)"
                            strSQL = strSQL & ", " & DtView2(j)("FLD028") & ""
                            strSQL = strSQL & ", '" & DtView2(j)("FLD012") & "'"
                            strSQL = strSQL & ", '" & DtView1(i)("BY_cls") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                            cnt = cnt + 1
                        Next
                        DB_CLOSE()
                    End If
                Next
            End If
        Next
        System.Diagnostics.EventLog.WriteEntry("BEST web ivc END " & cnt & " 件", "データコピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)

        System.Diagnostics.EventLog.WriteEntry("BEST web END", "データコピーを終了しました。", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub

End Class
