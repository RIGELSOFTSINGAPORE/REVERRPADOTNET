Public Class F70_Form01
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, printer, WK_str As String
    Dim i As Integer

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
    Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PdfExport1 = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
        '
        'F70_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(166, 8)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F70_Form01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "印刷中"

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F70_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case PRT_PRAM1
            Case Is = "Print_R_Azukari_Sheet"       '**  お預かりシート (R_Azukari_Sheet)
                Print_R_Azukari_Sheet(PRT_PRAM2)

            Case Is = "Print_R_Mitsumori"           '**  お見積書 (R_Mitsumori)
                Print_R_Mitsumori(PRT_PRAM2, PRT_PRAM3)

            Case Is = "Print_R_NEC_Parts_Inq"       '**  NEC部品価格問合せ票 (R_NEC_Parts_Inq)
                Print_R_NEC_Parts_Inq(PRT_PRAM2)

            Case Is = "Print_R_Fujitsu_Parts_Inq"   '**  Fujitsu部品価格問合せ票 (R_Fujitsu_Parts_Inq)
                Print_R_Fujitsu_Parts_Inq(PRT_PRAM2)

            Case Is = "Print_R_Sagyou_Report"       '**  作業報告書 (R_Sagyou_Report)
                Print_R_Sagyou_Report(PRT_PRAM2, PRT_PRAM3)

            Case Is = "Print_R_Inquiry"             '**  ＦＡＸ送付状印刷 (R_Inquiry)
                Print_R_Inquiry(PRT_PRAM2, PRT_PRAM3)

            Case Is = "Print_R_QGCare"              '**  ケア情報印刷 (R_QGCare)
                Print_R_QGCare(PRT_PRAM2, PRT_PRAM3)

        End Select
        DsList1.Clear()
        P_DsPRT.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  お預かりシート (R_Azukari_Sheet)
    '********************************************************************
    Public Function Print_R_Azukari_Sheet(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        P_DtView1(0)("accp_date2") = Format(CDate(P_DtView1(0)("accp_date")).Date, "M月dd日")
        If Not IsDBNull(P_DtView1(0)("store_accp_date")) Then
            P_DtView1(0)("store_accp_date2") = Format(CDate(P_DtView1(0)("store_accp_date")).Date, "M月dd日")
        End If

        If P_DtView1(0)("idvd_flg") = "1" Then
            P_DtView1(0)("store_name") = Nothing
        End If

        '付属品データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram2.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print02")

        '受付内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        P_HSTY_DATE = Now
        '印刷日付
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Azukari_Sheet)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Azukari_Sheet")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Azukari_Sheet = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  プリンタ名取得

        Dim rpt As New R_Azukari_Sheet
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "お預かりシート"
            rpt.Document.Print(False, False, False)
        End If

        'PdfExport1.Export(rpt.Document, "C:\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")

        add_hsty(rcpt_no, "お預かりシート印刷", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  お見積書 (R_Mitsumori)
    '********************************************************************
    Public Function Print_R_Mitsumori(ByVal rcpt_no, ByVal ptn)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        Dim myCI As New System.Globalization.CultureInfo("ja-JP", True)
        myCI.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar
        If P_DtView1(0)("sub_code") = "00" Then P_DtView1(0)("sub_own_name") = P_DtView1(0)("cls_code_name")
        P_DtView1(0)("brch_zip") = "〒" & Mid(P_DtView1(0)("brch_zip"), 1, 3) & "-" & Mid(P_DtView1(0)("brch_zip"), 4, 4)

        If P_DtView1(0)("idvd_flg") = "1" Then P_DtView1(0)("store_repr_no") = ""
        'If P_DtView1(0)("note_kbn") = "01" Then P_DtView1(0)("etmt_shop_part_chrg") = 0
        'If P_DtView1(0)("note_kbn") = "01" Then P_DtView1(0)("etmt_shop_tech_chrg") = 0

        P_DtView1(0)("etmt_date2") = CDate(P_DtView1(0)("etmt_date")).ToString("yyyy年MM月dd日")
        strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '019')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "cls019")
        DtView1 = New DataView(DsList1.Tables("cls019"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            P_DtView1(0)("etmt_lmit_period") = DtView1(0)("cls_code_name")
            P_DtView1(0)("etmt_lmit_date") = DateAdd(DateInterval.Day, DtView1(0)("cls_code_name"), P_DtView1(0)("etmt_date"))
            P_DtView1(0)("etmt_lmit_date2") = CDate(P_DtView1(0)("etmt_lmit_date")).ToString("yyyy年MM月dd日")
            P_DtView1(0)("accp_date2") = CDate(P_DtView1(0)("accp_date")).ToString("yyyy年MM月dd日")
        End If
        Select Case ptn
            Case Is = "01", "11"    'ビックカメラ
            Case Is = "02"          'ジョーシン
                P_DtView1(0)("etmt_date2") = CDate(P_DtView1(0)("etmt_date")).ToString("yyyy年MM月dd日")
                P_DtView1(0)("etmt_lmit_date") = DateAdd(DateInterval.Day, 7, P_DtView1(0)("etmt_date")).ToString("yyyy年MM月dd日")
                P_DtView1(0)("etmt_lmit_date2") = CDate(P_DtView1(0)("etmt_lmit_date")).ToString("yyyy年MM月dd日")
                P_DtView1(0)("accp_date2") = CDate(P_DtView1(0)("accp_date")).ToString("yyyy年MM月dd日")
            Case Is = "03"          'ソフマップ
            Case Is = "04"          'ヨドバシカメラ
            Case Is = "05"          '大学生協
                P_DtView1(0)("etmt_date2") = CDate(P_DtView1(0)("etmt_date")).ToString("yyyy年MM月dd日")

                strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '019')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(DsList1, "cls019")
                DtView1 = New DataView(DsList1.Tables("cls019"), "", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    P_DtView1(0)("etmt_lmit_period") = DtView1(0)("cls_code_name")
                    P_DtView1(0)("etmt_lmit_date") = DateAdd(DateInterval.Day, DtView1(0)("cls_code_name"), P_DtView1(0)("etmt_date"))
                    P_DtView1(0)("etmt_lmit_date2") = CDate(P_DtView1(0)("etmt_lmit_date")).ToString("yyyy年MM月dd日")
                End If
            Case Is = "06"          'ソフマップOLC
            Case Is = "07"          '京都事業連合
                P_DtView1(0)("etmt_date2") = CDate(P_DtView1(0)("etmt_date")).ToString("yyyy年MM月dd日")
                P_DtView1(0)("etmt_lmit_date2") = CDate(P_DtView1(0)("etmt_lmit_date")).ToString("yyyy年MM月dd日")
                P_DtView1(0)("accp_date2") = CDate(P_DtView1(0)("accp_date")).ToString("yyyy年MM月dd日")
            Case Is = "13"          'コジマ
            Case Else       '通常
        End Select

        '受付内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '見積内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram4.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print04")

        '部品データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print05")

        P_HSTY_DATE = Now
        '印刷日付
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Mitsumori)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Mitsumori")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Mitsumori = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  プリンタ名取得

        P_rcpt_cls = P_DtView1(0)("rcpt_cls")

        Dim sel As String = Nothing
        'If P_DtView1(0)("arvl_cls") = "01" Then    '持込（一般）
        Select Case P_DtView1(0)("vndr_code")
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                sel = "Apple"
            Case Else
        End Select
        'End If

        Select Case ptn
            Case Is = "01"  'ビックカメラ
                Dim rpt As New R_Mitsumori_BICCamera
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "お見積書_ビックカメラ"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                End If

            Case Is = "02"  'ジョーシン
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Joshin
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_ジョーシン"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                End If

            Case Is = "03"  'ソフマップ
                Dim rpt As New R_Mitsumori_SOFMAP
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "お見積書_ソフマップ"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                End If

            Case Is = "04"  'ヨドバシカメラ
                Dim rpt As New R_Mitsumori_Yodobashi
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "お見積書_ヨドバシカメラ"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                End If

            Case Is = "05"  '大学生協
                Select Case P_DtView1(0)("rcpt_cls")
                    Case Is = "02"  'QG-Care
                        If P_DtView1(0)("menseki_amnt") = 0 And P_DtView1(0)("wrn_limt_amnt") >= P_DtView1(0)("etmt_shop_ttl") + P_DtView1(0)("etmt_shop_tax") Then
                            Dim rpt As New R_Mitsumori_Seikyo_QGCARE
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print01"
                            rpt.Run(False)
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "お見積書_大学生協_QGCare"
                                rpt.Document.Print(False, False, False)
                                add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                            End If
                        Else
                            Dim rpt As New R_Mitsumori_Seikyo_Menseki5k
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print01"
                            rpt.Run(False)
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "お見積書_大学生協_免責"
                                rpt.Document.Print(False, False, False)
                                add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                            End If
                        End If
                    Case Is = "03", "10" '延長保証(QG-Care)'生協Fujitsu保険
                        If P_DtView1(0)("menseki_amnt") <> 0 Or P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("etmt_shop_ttl") + P_DtView1(0)("etmt_shop_tax") Then    '免責あり or 富士通保険 or 限度超
                            Dim rpt As New R_Mitsumori_Seikyo_Menseki5k
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print01"
                            rpt.Run(False)
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "お見積書_大学生協_免責"
                                rpt.Document.Print(False, False, False)
                                add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                            End If
                        Else
                            Dim rpt As New R_Mitsumori_Seikyo_Normal
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print01"
                            rpt.Run(False)
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "お見積書_大学生協_通常"
                                rpt.Document.Print(False, False, False)
                                add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                            End If
                        End If
                    Case Else
                        Dim rpt As New R_Mitsumori_Seikyo_Normal
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "Print01"
                        rpt.Run(False)
                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "お見積書_大学生協_通常"
                            rpt.Document.Print(False, False, False)
                            add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                        End If
                End Select

            Case Is = "06"  'ソフマップOLC
                Dim rpt As New R_Mitsumori_SOFMAP_OLC
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "お見積書_ソフマップOLC"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                End If

            Case Is = "07"  '京都事業連合
                Dim rpt As New R_Mitsumori_kyotorengo
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "お見積書_京都事業連合"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                End If

            Case Is = "08"  '通常（販社）
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Normal_Hansya
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_通常_販社"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                End If

            Case Is = "09"  '通常（定額）
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Normal_Teigaku
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_通常_定額"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                End If

            Case Is = "10"  'エイデン
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Eiden
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_エイデン"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                End If

            Case Is = "11"  'ビックカメラ（TSS）
                Dim rpt As New R_Mitsumori_BICMK
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "お見積書_ビックカメラ(TSS)"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                End If

                Dim rpt2 As New R_Mitsumori_BicEU
                rpt2.DataSource = P_DsPRT
                rpt2.DataMember = "Print01"
                rpt2.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                    rpt2.Document.Name = "お見積書_ビックカメラ(TSS)2"
                    rpt2.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt2.Document.Name & "印刷", "", "")
                End If

            Case Is = "12"  'ビックカメラ（西梅田）
                Dim rpt As New R_Mitsumori_Bic_EU_NU
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "お見積書_ビックカメラ(西梅田)"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                End If

            Case Is = "13"  'コジマ
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_kojima
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_コジマ"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                End If

            Case Is = "14"  'ソフトバンク
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_softbank
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_ソフトバンク"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                End If

            Case Else       '通常
                'Dim sel As String = Nothing
                'If P_DtView1(0)("arvl_cls") = "01" Then    '持込（一般）
                '    Select Case P_DtView1(0)("vndr_code")
                '        Case Is = "01", "20", "21", "22", "23", "24", "25"
                '            sel = "Apple"
                '        Case Else
                '    End Select
                'End If
                If sel = "Apple" Then
                    Select Case P_DtView1(0)("price_rprt_ptn")
                        Case Is = "05", "07"
                            sel = Nothing
                    End Select
                End If
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Normal
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "お見積書_通常"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "印刷", "", "")
                    End If
                End If
        End Select

        add_hsty(rcpt_no, "お見積書印刷", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  NEC部品価格問合せ票 (R_NEC_Parts_Inq)
    '********************************************************************
    Public Function Print_R_NEC_Parts_Inq(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Parts_Inq", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        '依頼者情報
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Parts_Inq_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 9)
        Pram2.Value = P_EMPL_NO
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print02")

        '受付内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '部品データ
        DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
        Dim page As Integer
        page = RoundUP(DtView1.Count / 5, 0)

        P_HSTY_DATE = Now
        '印刷日付
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Part_amnt_Q)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Part_amnt_Q")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Part_amnt_Q = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  プリンタ名取得

        For i = 1 To page
            P_page = i
            Dim rpt As New R_NEC_Parts_Inq
            rpt.DataSource = P_DsPRT
            rpt.DataMember = "Print01"
            rpt.Run(False)
            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                End If
                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Else
                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                rpt.Document.Name = "NEC部品価格問合せ票"
                rpt.Document.Print(False, False, False)
            End If
        Next

        add_hsty(rcpt_no, "部品価格問合せ票印刷", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  Fujitsu部品価格問合せ票 (R_Fujitsu_Parts_Inq)
    '********************************************************************
    Public Function Print_R_Fujitsu_Parts_Inq(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Parts_Inq", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        '依頼者情報
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Parts_Inq_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 9)
        Pram2.Value = P_EMPL_NO
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print02")

        '部品データ
        DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
        Dim page As Integer
        page = RoundUP(DtView1.Count / 5, 0)

        P_HSTY_DATE = Now
        '印刷日付
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Part_amnt_Q)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Part_amnt_Q")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Part_amnt_Q = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  プリンタ名取得

        For i = 1 To page
            P_page = i
            Dim rpt As New R_Fujitsu_Parts_Inq
            rpt.DataSource = P_DsPRT
            rpt.DataMember = "Print01"
            rpt.Run(False)
            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                End If
                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Else
                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                rpt.Document.Name = "Fujitsu部品価格問合せ票"
                rpt.Document.Print(False, False, False)
            End If
        Next

        add_hsty(rcpt_no, "部品価格問合せ票印刷", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  作業報告書 (R_Sagyou_Report)
    '********************************************************************
    Public Function Print_R_Sagyou_Report(ByVal rcpt_no, ByVal ptn)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        Dim myCI As New System.Globalization.CultureInfo("ja-JP", True)
        myCI.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar

        WK_str = P_DtView1(0)("cls_code_name")
        WK_str = WK_str.Replace("株式会社", "㈱")
        P_DtView1(0)("cls_code_name") = WK_str

        WK_str = P_DtView1(0)("sub_own_name")
        WK_str = WK_str.Replace("株式会社", "㈱")
        P_DtView1(0)("sub_own_name") = WK_str

        If P_DtView1(0)("sub_code") = "00" Then P_DtView1(0)("sub_own_name") = P_DtView1(0)("cls_code_name")
        P_DtView1(0)("brch_zip") = Mid(P_DtView1(0)("brch_zip"), 1, 3) & "-" & Mid(P_DtView1(0)("brch_zip"), 4, 4)

        If P_DtView1(0)("idvd_flg") = "1" Then P_DtView1(0)("store_repr_no") = ""
        'P_DtView1(0)("adrs1") = P_DtView1(0)("adrs1") & " " & P_DtView1(0)("adrs2")

        'If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
        '    P_DtView1(0)("comp_shop_tech_chrg") = 0
        '    P_DtView1(0)("comp_shop_part_chrg") = 0
        '    P_DtView1(0)("comp_shop_fee") = 0
        '    P_DtView1(0)("comp_shop_pstg") = 0
        '    P_DtView1(0)("comp_shop_ttl") = 0
        '    P_DtView1(0)("comp_shop_tax") = 0
        '    P_DtView1(0)("comp_eu_tech_chrg") = 0
        '    P_DtView1(0)("comp_eu_part_chrg") = 0
        '    P_DtView1(0)("comp_eu_fee") = 0
        '    P_DtView1(0)("comp_eu_pstg") = 0
        '    P_DtView1(0)("comp_eu_ttl") = 0
        '    P_DtView1(0)("comp_eu_tax") = 0
        'End If

        '受付内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '見積内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram4.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print04")

        '修理内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram6 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram6.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print06")

        '部品データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print05")

        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)

        If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
            If DtView1.Count <> 0 Then
                For i = 0 To DtView1.Count - 1
                    DtView1(i)("shop_chrg") = 0
                    DtView1(i)("eu_chrg") = 0
                Next
            End If
        End If

        P_HSTY_DATE = Now
        '印刷日付
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Sagyou)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Sagyou")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Sagyou = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  プリンタ名取得

        'P_rcpt_cls = P_DtView1(0)("rcpt_cls")
        P_grup = P_DtView1(0)("grup_code")

        Dim sel As String = Nothing
        'Select Case P_DtView1(0)("grup_code")   '販社グループ
        '    Case Is = "02", "90", "91", "92"
        Select Case P_DtView1(0)("vndr_code")   'メーカー
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                sel = "Apple"
            Case Else
        End Select
        '    Case Else
        'End Select

        Select Case ptn
            Case Is = "01"  'ビックカメラ EU
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_Bic_EU
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "作業報告書_ビックカメラ_EU"
                    rpt.Document.Print(False, False, False)
                End If

                Dim rpt2 As New R_Sagyou_Report_BicGSS
                rpt2.DataSource = P_DsPRT
                rpt2.DataMember = "Print01"
                rpt2.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                    rpt2.Document.Name = "作業報告書_ビックカメラ_GSS"
                    rpt2.Document.Print(False, False, False)
                End If

            Case Is = "02"  'Ks
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_KS_EU
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_ケーズデンキ"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "03"  '大学生協
                'Dim sel As String = Nothing
                'Select Case P_DtView1(0)("grup_code")   '販社グループ
                '    Case Is = "02", "90", "91", "92"
                '        Select Case P_DtView1(0)("vndr_code")   'メーカー
                '            Case Is = "01", "20", "21", "22", "23", "24", "25"
                '                sel = "Apple"
                '            Case Else
                '        End Select
                '    Case Else
                'End Select
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt As New R_Sagyou_Report_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_APPLE"
                        rpt.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_Seikyo_EU
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_大学生協_QGCare"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "04"  'ソフマップ
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_SofmapStore
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "作業報告書_ソフマップ"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "05"  'ヨドバシカメラ
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_Yodobashi_EU
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "作業報告書_ヨドバシカメラ"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "06"  'ソフマップOLC
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_SofmapOLC
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "作業報告書_ソフマップOLC"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "07"  '京都事業連合
                'Dim sel As String = Nothing
                'Select Case P_DtView1(0)("grup_code")   '販社グループ
                '    Case Is = "02", "90", "91", "92"
                '        Select Case P_DtView1(0)("vndr_code")   'メーカー
                '            Case Is = "01", "20", "21", "22", "23", "24", "25"
                '                sel = "Apple"
                '            Case Else
                '        End Select
                '    Case Else
                'End Select
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt As New R_Sagyou_Report_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_APPLE"
                        rpt.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_kyotoseikyo
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_京都事業連合"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "08"  '通常（定額）
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_Normal_Teigaku
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_通常_定額"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "09"  'ビックカメラ EU(TSS)
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_BIC_EU_NMK
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "作業報告書_ビックカメラ_EU(TSS)"
                    rpt.Document.Print(False, False, False)
                End If

                Dim rpt2 As New R_Sagyou_Report_BIC_NMK
                rpt2.DataSource = P_DsPRT
                rpt2.DataMember = "Print01"
                rpt2.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                    rpt2.Document.Name = "作業報告書_ビックカメラ(TSS)"
                    rpt2.Document.Print(False, False, False)
                End If

            Case Is = "10"  '通常（定額）
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_EU_syanasi
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_EU_社名なし"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "11"  'ビックカメラ EU(西梅田)
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_BIC_EU_NU
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "作業報告書_ビックカメラ_EU(西梅田)"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "12"  'コジマ
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_Kojima
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_コジマ"
                        rpt.Document.Print(False, False, False)
                    End If

                    Dim rpt2 As New R_Sagyou_Report_Kojima_0
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_コジマ_0"
                        rpt2.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "13"  'ドスパラ
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    P_zero = "0"
                    Dim rpt As New R_Sagyou_Report_DosPara
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_ドスパラ"
                        rpt.Document.Print(False, False, False)
                    End If

                    P_zero = "1"
                    Dim rpt2 As New R_Sagyou_Report_DosPara
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_ドスパラ_0"
                        rpt2.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "14"  'ジョーシン
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_jyoshin_apple_EU
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_ジョーシン"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "15"  'ソフトバンク
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_softbank
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_ソフトバンク"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "16"  'QAC
                If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "作業報告書_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_QAC
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_QAC"
                        rpt.Document.Print(False, False, False)
                    End If

                    'Dim rpt2 As New R_Sagyou_Report_Normal
                    'rpt2.DataSource = P_DsPRT
                    'rpt2.DataMember = "Print01"
                    'rpt2.Run(False)
                    'If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    '    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                    '        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    '    End If
                    '    PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    'Else
                    '    If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                    '    rpt2.Document.Name = "作業報告書_通常"
                    '    rpt2.Document.Print(False, False, False)
                    'End If
                End If

            Case Else       '通常
                'sel = Nothing
                'If P_DtView1(0)("arvl_cls") = "01" Then    '持込（一般）
                '    Select Case P_DtView1(0)("vndr_code")
                '        Case Is = "01", "20", "21", "22", "23", "24", "25"
                '            sel = "Apple"
                '        Case Else
                '    End Select
                'End If
                If sel = "Apple" Then
                    Dim rpt As New R_Sagyou_Report_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "作業報告書_APPLE"
                        rpt.Document.Print(False, False, False)
                    End If
                Else
                    sel = Nothing
                    Select Case P_DtView1(0)("grup_code")   '販社グループ
                        Case Is = "02", "90", "91", "92"
                            Select Case P_DtView1(0)("vndr_code")   'メーカー
                                Case Is = "01", "20", "21", "22", "23", "24", "25"
                                    sel = "Apple"
                                Case Else
                            End Select
                        Case Else
                    End Select
                    If sel = "Apple" Then
                        Dim rpt As New R_Sagyou_Report_Apple
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "Print01"
                        rpt.Run(False)
                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "作業報告書_APPLE"
                            rpt.Document.Print(False, False, False)
                        End If
                    Else
                        If P_DtView1(0)("rpar_cls") <> "01" Then   '有償以外
                            P_DtView1(0)("comp_shop_tech_chrg") = 0
                            P_DtView1(0)("comp_shop_part_chrg") = 0
                            P_DtView1(0)("comp_shop_fee") = 0
                            P_DtView1(0)("comp_shop_pstg") = 0
                            P_DtView1(0)("comp_shop_ttl") = 0
                            P_DtView1(0)("comp_shop_tax") = 0
                            P_DtView1(0)("comp_eu_tech_chrg") = 0
                            P_DtView1(0)("comp_eu_part_chrg") = 0
                            P_DtView1(0)("comp_eu_fee") = 0
                            P_DtView1(0)("comp_eu_pstg") = 0
                            P_DtView1(0)("comp_eu_ttl") = 0
                            P_DtView1(0)("comp_eu_tax") = 0
                        End If
                        Dim rpt As New R_Sagyou_Report_Normal
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "Print01"
                        rpt.Run(False)
                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "作業報告書_通常"
                            rpt.Document.Print(False, False, False)
                        End If
                    End If
                End If
        End Select

        ''QG Care の場合通常も印刷
        'If P_DtView1(0)("qg_care_no") <> Nothing Then
        '    Dim rpt As New R_Sagyou_Report_Normal  '通常
        '    rpt.DataSource = P_DsPRT
        '    rpt.DataMember = "Print01"
        '    rpt.Run(False)
        '    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
        '        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
        '            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
        '        End If
        '        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
        '    Else
        '        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
        '        rpt.Document.Name = "作業報告書_通常"
        '        rpt.Document.Print(False, False, False)
        '    End If
        'End If

        add_hsty(rcpt_no, "作業報告書印刷", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  ＦＡＸ送付状印刷 (R_Inquiry)
    '********************************************************************
    Public Function Print_R_Inquiry(ByVal Key_no, ByVal ptn)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Inquiry", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
        Pram1.Value = Key_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)

        '受付内容データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram4.Value = P_DtView1(0)("rcpt_no")
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")
        DB_CLOSE()

        WK_str = P_DtView1(0)("comp_name")
        WK_str = WK_str.Replace("株式会社", "㈱")
        P_DtView1(0)("comp_name") = WK_str

        printer = PRT_GET("01")   '**  プリンタ名取得

        Select Case ptn
            Case Is = "01"  '標準
                Dim rpt As New R_Inquiry_Free_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "02"  'パスワード確認
                Dim rpt As New R_Inquiry_Password
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "03"  'データ消去確認
                Dim rpt As New R_Inquiry_Data
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "04"  '症状再現しない
                Dim rpt As New R_Inquiry_NTF
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "05"  '保証書記載漏れ
                Dim rpt As New R_Inquiry_hosyomore_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "06"  '展示機
                Dim rpt As New R_Inquiry_Tenjiki_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "07"  'シリアル番号相違
                Dim rpt As New R_Inquiry_Siriaru_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "08"  '同梱物相違
                Dim rpt As New R_Inquiry_Doukonbutu_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "09"  '終了機種
                Dim rpt As New R_Inquiry_EOS_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "10"  'Apple定額修理
                Dim rpt As New R_Inquiry_Apple_teigaku_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "11"  '添付書
                Dim rpt As New R_Inquiry_Tenpusyo_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "12"  'データリカバリー
                Dim rpt As New R_Inquiry_DataRcvy1
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX送付状"
                    rpt.Document.Print(False, False, False)
                End If

        End Select

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  ケア情報印刷 (R_QGCare)
    '********************************************************************
    Public Function Print_R_QGCare(ByVal qg_care_no, ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        P_HSTY_DATE = Now
        P_RTN = "0"

        ''メーカー
        'DsList0.Clear()
        'strSQL = "SELECT vndr_code, name FROM M05_VNDR"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nMVAR")
        'DaList1.Fill(DsList0, "M05_VNDR")
        'DB_CLOSE()

        'メインデータ
        strSQL = "SELECT T01_member.code AS 加入番号, T01_member.user_name AS 氏名, T01_member.tel AS 電話番号"
        strSQL += ", V_M02_HSY.cls_code_name AS 保証範囲, T01_member.Part_date AS 加入日"
        strSQL += ", T01_member.makr_wrn_stat AS メーカー保証開始, M01_univ.univ_name AS 大学名"
        strSQL += ", T01_member.prch_amnt AS PC購入金額, T01_member.wrn_tem AS 保証期間"
        strSQL += ", V_M02_HSK.cls_code_name AS 保証期間名, T01_member.modl_name AS PCモデル名"
        strSQL += ", T01_member.s_no AS シリアル番号, T01_member.makr_code, M05_VNDR.name AS メーカー名"
        strSQL += ", '保証期間内' AS 保証可否, M04_shop.shop_name AS 販売店名, T01_member.memo"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code LEFT OUTER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
        strSQL += " WHERE (T01_member.code = N'" & qg_care_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("QGCare")
        DaList1.Fill(P_DsPRT, "Print01")
        DB_CLOSE()

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        If P_DtView1.Count = 0 Then Exit Function

        'For i = 0 To P_DtView1.Count - 1
        '    DtView1 = New DataView(DsList0.Tables("M05_VNDR"), "vndr_code ='" & P_DtView1(i)("makr_code") & "'", "", DataViewRowState.CurrentRows)
        '    If DtView1.Count <> 0 Then
        '        P_DtView1(i)("メーカー名") = DtView1(0)("name")
        '    End If
        'Next

        If DateAdd(DateInterval.Year, P_DtView1(0)("保証期間"), P_DtView1(0)("加入日")) < P_HSTY_DATE Then
            P_DtView1(0)("保証可否") = Nothing
        End If
        If Not IsDBNull(P_DtView1(0)("memo")) Then
            P_DtView1(0)("memo") = P_DtView1(0)("memo").Replace(System.Environment.NewLine, "")
        Else
            P_DtView1(0)("memo") = ""
        End If

        printer = PRT_GET("01")   '**  プリンタ名取得

        Dim rpt As New R_QGCare
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "ケア情報"
            rpt.Document.Print(False, False, False)
        End If

        add_hsty(rcpt_no, "ケア情報印刷", qg_care_no, "")
        P_RTN = "1"

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function
End Class
