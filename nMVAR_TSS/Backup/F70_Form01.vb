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
        Me.ClientSize = New System.Drawing.Size(166, 23)
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
            strSQL = strSQL & " (rcpt_no, Azukari_Sheet)"
            strSQL = strSQL & " VALUES ('" & rcpt_no & "'"
            strSQL = strSQL & ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Azukari_Sheet")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL = strSQL & " SET Azukari_Sheet = '" & P_HSTY_DATE & "'"
                strSQL = strSQL & " WHERE (rcpt_no = '" & rcpt_no & "')"
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
            MessageBox.Show(Err.Number & ":" & Err.Description, "Error_預かりシート", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function
End Class
