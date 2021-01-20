
Public Class Form3
    Dim 受付日 As Integer
    Dim waitDlg As waitDlg   ''進行状況フォームクラス 
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsExp As New DataSet
    Dim DtView1 As DataView
    Dim WK_date As Date
    Dim WK_date1 As Date

    Dim strSQL, Err_F, ptn_F, inz_F As String
    Dim i, j As Integer
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button99_Click(sender As Object, e As EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Enabled = False
        waitDlg = New waitDlg
        waitDlg.Owner = Me
        waitDlg.MainMsg = Nothing
        waitDlg.ProgressMax = 0
        waitDlg.ProgressMin = 0
        waitDlg.ProgressStep = 1
        waitDlg.ProgressValue = 0

        waitDlg.Show()
        Call XLS_OUT()
        Me.Enabled = False

        Call XLS_OUT1()
        waitDlg.Close()
        Me.Enabled = True
        Application.Exit()

    End Sub
    Sub XLS_OUT()
        waitDlg.MainMsg = "商品別加入集計を出力しています"
        waitDlg.ProgressMsg = "データ出力準備中"
        Application.DoEvents()
        waitDlg.ProgressValue = 0

        WK_date = TextBox2.Text & "/03/01"
        WK_date1 = TextBox2.Text + 1 & "/03/01"

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[Wrn_sub_xls1]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[Wrn_sub_xls1]"
        strSQL = strSQL & " SELECT wrn_sub.BY_cls, Wrn_sub.item_cat_code, Wrn_sub.prch_price, Wrn_sub.close_cont_flg, Wrn_sub.close_date INTO Wrn_sub_xls1"
        strSQL = strSQL & " FROM Wrn_sub"
        strSQL = strSQL & " WHERE (((Wrn_sub.close_cont_flg)='A')"
        strSQL = strSQL & " AND Wrn_sub.close_date >='" & WK_date & "'"
        strSQL = strSQL & " And Wrn_sub.close_date <'" & WK_date1 & "'"
        strSQL = strSQL & " OR (((Wrn_sub.close_cont_flg) Is Null)"
        strSQL = strSQL & " AND ((Wrn_sub.close_date) Is Null)))"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[Cat_mtr_acc]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[Cat_mtr_acc]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code AS 商品コード INTO Cat_mtr_acc"
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub "
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/04/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerothree]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerothree]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & "  oneunderzerothree  "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date = '" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/05/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerofour]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerofour]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzerofour "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date  ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/06/01"
        WK_date = DateAdd("d", -1, WK_date)


        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerofive]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerofive] "
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzerofive "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/07/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerosix]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerosix]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzerosix "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/08/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeroseven]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeroseven]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeroseven "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/09/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeroeight]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeroeight]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeroeight "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/10/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeronine]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeronine]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeronine "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/11/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeroten]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeroten]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeroten "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/12/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeroeleven]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeroeleven]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeroeleven "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text + 1 & "/01/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerotwelve]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerotwelve]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzerotwelve "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text + 1 & "/02/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[twounderzeroone]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[twounderzeroone]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " twounderzeroone "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text + 1 & "/03/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[twounderzerotwo]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[twounderzerotwo]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " twounderzerotwo"
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()


        strSQL = "SELECT Cat_mtr_acc.商品コード, [oneunderzerothree].[カウント] AS カウント03, [oneunderzerothree].合計 AS 合計03, [oneunderzerofour].[カウント] AS カウント04, [oneunderzerofour].合計 AS 合計04, "
        strSQL = strSQL & " [oneunderzerofive].[カウント] AS カウント05, [oneunderzerofive].合計 AS 合計05, [oneunderzerosix].[カウント] AS カウント06, [oneunderzerosix].合計 AS 合計06, [oneunderzeroseven].[カウント] AS カウント07, "
        strSQL = strSQL & " [oneunderzeroseven].合計 AS 合計07, [oneunderzeroeight].[カウント] AS カウント08, [oneunderzeroeight].合計 AS 合計08, [oneunderzeronine].[カウント] AS カウント09, [oneunderzeronine].合計 AS 合計09, [oneunderzeroten].[カウント] AS カウント10, "
        strSQL = strSQL & " [oneunderzeroten].合計 AS 合計10, [oneunderzeroeleven].[カウント] AS カウント11, [oneunderzeroeleven].合計 AS 合計11, [oneunderzerotwelve].[カウント] AS カウント12, [oneunderzerotwelve].合計 AS 合計12, [twounderzeroone].[カウント] AS カウント01,  "
        strSQL = strSQL & " [twounderzeroone].合計 AS 合計01, [twounderzerotwo].[カウント] AS カウント02, [twounderzerotwo].合計 AS 合計02"
        strSQL = strSQL & " FROM (((((((((((Cat_mtr_acc LEFT JOIN oneunderzerothree ON (Cat_mtr_acc.商品コード = [oneunderzerothree].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzerothree].BY_cls)) "
        strSQL = strSQL & " LEFT JOIN oneunderzerofour ON (Cat_mtr_acc.商品コード = [oneunderzerofour].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzerofour].BY_cls)) LEFT JOIN oneunderzerofive ON (Cat_mtr_acc.商品コード = [oneunderzerofive].item_cat_code) "
        strSQL = strSQL & " AND (Cat_mtr_acc.BY_cls = [oneunderzerofive].BY_cls)) LEFT JOIN oneunderzerosix ON (Cat_mtr_acc.商品コード = [oneunderzerosix].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzerosix].BY_cls)) LEFT JOIN oneunderzeroseven"
        strSQL = strSQL & " ON (Cat_mtr_acc.商品コード = [oneunderzeroseven].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzeroseven].BY_cls)) LEFT JOIN oneunderzeroeight ON (Cat_mtr_acc.商品コード = [oneunderzeroeight].item_cat_code)  "
        strSQL = strSQL & " AND (Cat_mtr_acc.BY_cls = [oneunderzeroeight].BY_cls)) LEFT JOIN oneunderzeronine ON (Cat_mtr_acc.商品コード = [oneunderzeronine].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzeronine].BY_cls)) LEFT JOIN oneunderzeroten"
        strSQL = strSQL & " ON (Cat_mtr_acc.商品コード = [oneunderzeroten].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzeroten].BY_cls)) LEFT JOIN oneunderzeroeleven ON (Cat_mtr_acc.商品コード = [oneunderzeroeleven].item_cat_code) "
        strSQL = strSQL & " AND (Cat_mtr_acc.BY_cls = [oneunderzeroeleven].BY_cls)) LEFT JOIN oneunderzerotwelve ON (Cat_mtr_acc.商品コード = [oneunderzerotwelve].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzerotwelve].BY_cls)) LEFT JOIN twounderzeroone"
        strSQL = strSQL & " ON (Cat_mtr_acc.商品コード = [twounderzeroone].item_cat_code) AND (Cat_mtr_acc.BY_cls = [twounderzeroone].BY_cls)) LEFT JOIN twounderzerotwo ON (Cat_mtr_acc.商品コード = [twounderzerotwo].item_cat_code)"
        strSQL = strSQL & " AND (Cat_mtr_acc.BY_cls = [twounderzerotwo].BY_cls) order by 商品コード ASC"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsExp, "Q_30_集計")
        DB_CLOSE()

        DtView1 = New DataView(DsExp.Tables("Q_30_集計"), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        'xlApp.Visible = True
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Add
        Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(1), Excel.Worksheet)
        Dim xlCells As Excel.Range
        Dim xlRange As Excel.Range = xlSheet.Rows



        xlCells = xlSheet.Cells
        WK_date = TextBox2.Text & "/03/01"
        ' xlRange = xlCells(1, 2) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("B1:C1").Merge()
        xlSheet.Range("B1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("B1:C1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 4) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : xlCells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlSheet.Range("D1:E1").Merge()
        xlSheet.Range("D1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("D1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter


        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 6) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("F1:G1").Merge()
        xlSheet.Range("F1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        'xlRange = xlCells(1, 8) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("H1:I1").Merge()
        xlSheet.Range("H1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("H1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 10) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("J1:K1").Merge()
        xlSheet.Range("J1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("J1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 12) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("L1:M1").Merge()
        xlSheet.Range("L1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("L1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 14) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("N1:O1").Merge()
        xlSheet.Range("N1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("N1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        '  xlRange = xlCells(1, 16) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("P1:Q1").Merge()
        xlSheet.Range("P1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("P1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        'xlRange = xlCells(1, 18) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("R1:S1").Merge()
        xlSheet.Range("R1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("R1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter


        WK_date = DateAdd("m", 1, WK_date)
        'xlRange = xlCells(1, 20) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("T1:U1").Merge()
        xlSheet.Range("T1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("T1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 22) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("V1:W1").Merge()
        xlSheet.Range("V1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("V1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        '  xlRange = xlCells(1, 24) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("X1:Y1").Merge()
        xlSheet.Range("X1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("X1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'xlRange = xlCells(1, 26) : xlRange.Value = "合計	" : MRComObject(xlRange)
        xlSheet.Range("Z1:AA1").Merge()
        xlSheet.Range("Z1").Value = "合計"
        xlSheet.Range("Z1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter


        xlRange = xlCells(2, 1) : xlRange.Value = "商品コード" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 2) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 3) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 4) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 5) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 6) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 7) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 8) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 9) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 10) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 11) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 12) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 13) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 14) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 15) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 16) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 17) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 18) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 19) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 20) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 21) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 22) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 23) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 24) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 25) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 26) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 27) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)

        Dim Hs As Excel.HPageBreaks = xlSheet.HPageBreaks
        Dim H As Excel.HPageBreak

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        With xlApp.ActiveWindow
            If .FreezePanes Then .FreezePanes = False
            .SplitColumn = 1
            .SplitRow = 2
            .FreezePanes = True
        End With

        For i = 0 To DtView1.Count - 1

            waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
            waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"

            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            j = i + 3  'セル行

            If Not IsDBNull(DtView1(i)("商品コード")) Then xlRange = xlCells(j, 1) : xlRange.Value = Trim(DtView1(i)("商品コード")).ToString : xlRange.NumberFormat = "00###0_)" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント03")) Then xlRange = xlCells(j, 2) : xlRange.Value = Trim(DtView1(i)("カウント03")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計03")) Then xlRange = xlCells(j, 3) : xlRange.Value = Trim(DtView1(i)("合計03")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント04")) Then xlRange = xlCells(j, 4) : xlRange.Value = Trim(DtView1(i)("カウント04")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計04")) Then xlRange = xlCells(j, 5) : xlRange.Value = Trim(DtView1(i)("合計04")).ToString : xlRange.NumberFormat = "_( #,##0;_( (#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント05")) Then xlRange = xlCells(j, 6) : xlRange.Value = Trim(DtView1(i)("カウント05")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計05")) Then xlRange = xlCells(j, 7) : xlRange.Value = Trim(DtView1(i)("合計05")).ToString : xlRange.NumberFormat = "_( #,##0;_( (#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント06")) Then xlRange = xlCells(j, 8) : xlRange.Value = Trim(DtView1(i)("カウント06")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計06")) Then xlRange = xlCells(j, 9) : xlRange.Value = Trim(DtView1(i)("合計06")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント07")) Then xlRange = xlCells(j, 10) : xlRange.Value = Trim(DtView1(i)("カウント07")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計07")) Then xlRange = xlCells(j, 11) : xlRange.Value = Trim(DtView1(i)("合計07")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント08")) Then xlRange = xlCells(j, 12) : xlRange.Value = Trim(DtView1(i)("カウント08")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計08")) Then xlRange = xlCells(j, 13) : xlRange.Value = Trim(DtView1(i)("合計08")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント09")) Then xlRange = xlCells(j, 14) : xlRange.Value = Trim(DtView1(i)("カウント09")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計09")) Then xlRange = xlCells(j, 15) : xlRange.Value = Trim(DtView1(i)("合計09")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント10")) Then xlRange = xlCells(j, 16) : xlRange.Value = Trim(DtView1(i)("カウント10")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計10")) Then xlRange = xlCells(j, 17) : xlRange.Value = Trim(DtView1(i)("合計10")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント11")) Then xlRange = xlCells(j, 18) : xlRange.Value = Trim(DtView1(i)("カウント11")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計11")) Then xlRange = xlCells(j, 19) : xlRange.Value = Trim(DtView1(i)("合計11")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント12")) Then xlRange = xlCells(j, 20) : xlRange.Value = DtView1(i)("カウント12") : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計12")) Then xlRange = xlCells(j, 21) : xlRange.Value = DtView1(i)("合計12") : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント01")) Then xlRange = xlCells(j, 22) : xlRange.Value = DtView1(i)("カウント01") : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計01")) Then xlRange = xlCells(j, 23) : xlRange.Value = DtView1(i)("合計01") : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント02")) Then xlRange = xlCells(j, 24) : xlRange.Value = DtView1(i)("カウント02") : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計02")) Then xlRange = xlCells(j, 25) : xlRange.Value = DtView1(i)("合計02") : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            xlRange = xlCells(j, 26) : xlRange.Value = "=SUM(B" & j & ",D" & j & ",F" & j & ",H" & j & ",J" & j & ",L" & j & ",N" & j & ",P" & j & ",R" & j & ",T" & j & ",V" & j & ",X" & j & ")"
            xlRange = xlCells(j, 27) : xlRange.Value = "=SUM(C" & j & ",E" & j & ",G" & j & ",I" & j & ",K" & j & ",M" & j & ",O" & j & ",Q" & j & ",S" & j & ",U" & j & ",W" & j & ",Y" & j & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"

        Next

        j = j + 2
        xlRange = xlCells(j, 2) : xlRange.Value = "=SUM(B3:B" & j - 1 & ")"
        xlRange = xlCells(j, 3) : xlRange.Value = "=SUM(C3:C" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 4) : xlRange.Value = "=SUM(D3:D" & j - 1 & ")"
        xlRange = xlCells(j, 5) : xlRange.Value = "=SUM(E3:E" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 7) : xlRange.Value = "=SUM(G3:G" & j - 1 & ")"
        xlRange = xlCells(j, 8) : xlRange.Value = "=SUM(H3:H" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 9) : xlRange.Value = "=SUM(I3:I" & j - 1 & ")"
        xlRange = xlCells(j, 6) : xlRange.Value = "=SUM(F3:F" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 10) : xlRange.Value = "=SUM(J3:J" & j - 1 & ")"
        xlRange = xlCells(j, 11) : xlRange.Value = "=SUM(K3:K" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 12) : xlRange.Value = "=SUM(L3:L" & j - 1 & ")"
        xlRange = xlCells(j, 13) : xlRange.Value = "=SUM(M3:M" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 14) : xlRange.Value = "=SUM(N3:N" & j - 1 & ")"
        xlRange = xlCells(j, 15) : xlRange.Value = "=SUM(O3:O" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 16) : xlRange.Value = "=SUM(P3:P" & j - 1 & ")"
        xlRange = xlCells(j, 17) : xlRange.Value = "=SUM(Q3:Q" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 18) : xlRange.Value = "=SUM(R3:R" & j - 1 & ")"
        xlRange = xlCells(j, 19) : xlRange.Value = "=SUM(S3:S" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 20) : xlRange.Value = "=SUM(T3:T" & j - 1 & ")"
        xlRange = xlCells(j, 21) : xlRange.Value = "=SUM(U3:U" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 22) : xlRange.Value = "=SUM(V3:V" & j - 1 & ")"
        xlRange = xlCells(j, 23) : xlRange.Value = "=SUM(W3:W" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 24) : xlRange.Value = "=SUM(X3:X" & j - 1 & ")"
        xlRange = xlCells(j, 25) : xlRange.Value = "=SUM(Y3:Y" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 26) : xlRange.Value = "=SUM(Z3:Z" & j - 1 & ")"
        xlRange = xlCells(j, 27) : xlRange.Value = "=SUM(AA3:AA" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        'xlCells.EntireColumn.AutoFit()   'セル幅（列幅）の自動調整



        MRComObject(xlCells)

        Me.Activate()
        ' waitDlg.Close()

        '［名前を付けて保存］ダイアログボックスを表示
        'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
        SaveFileDialog1.FileName = "商品別加入集計" & TextBox2.Text & "03_" & TextBox2.Text + 1 & "02.xls"
        '   SaveFileDialog1.Filter = "Excelファイル|*.xlsx"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Try
            xlBook.SaveAs(SaveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal)
        Catch ex As System.Exception
            Exit Sub
        End Try

        Me.Enabled = False

        ' 終了処理　
        MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)              'xlApp を開放

        '   Call Deleteobjects()
    End Sub
    Sub XLS_OUT1()
        waitDlg.MainMsg = "商品別加入集計を出力しています"
        waitDlg.ProgressMsg = "データ出力準備中"
        Application.DoEvents()
        waitDlg.ProgressValue = 0

        WK_date = TextBox2.Text & "/03/01"
        WK_date1 = TextBox2.Text + 1 & "/03/01"

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[Wrn_sub_xls1]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[Wrn_sub_xls1]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Wrn_sub.prch_price, Wrn_sub.close_cont_flg, Wrn_sub.close_date INTO Wrn_sub_xls1"
        strSQL = strSQL & " FROM Wrn_sub INNER JOIN Wrn_mtr ON Wrn_sub.ordr_no = Wrn_mtr.ordr_no"
        strSQL = strSQL & " WHERE (((Wrn_sub.close_cont_flg)='A')"
        strSQL = strSQL & " AND Wrn_sub.close_date >='" & WK_date & "'"
        strSQL = strSQL & " And Wrn_sub.close_date <'" & WK_date1 & "'"
        strSQL = strSQL & " AND ((Wrn_mtr.corp_flg)<>'1'))"
        strSQL = strSQL & " OR (((Wrn_sub.close_cont_flg) Is Null)"
        strSQL = strSQL & " AND ((Wrn_sub.close_date) Is Null)"
        strSQL = strSQL & " AND ((Wrn_mtr.corp_flg)<>'1'))"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[Cat_mtr_acc]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[Cat_mtr_acc]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code AS 商品コード INTO Cat_mtr_acc"
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub "
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/04/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerothree]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerothree]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & "  oneunderzerothree  "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date = '" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/05/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerofour]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerofour]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzerofour "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date  ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/06/01"
        WK_date = DateAdd("d", -1, WK_date)


        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerofive]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerofive] "
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzerofive "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/07/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerosix]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerosix]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzerosix "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/08/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeroseven]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeroseven]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeroseven "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/09/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeroeight]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeroeight]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeroeight "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/10/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeronine]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeronine]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeronine "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/11/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeroten]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeroten]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeroten "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text & "/12/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzeroeleven]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzeroeleven]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzeroeleven "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text + 1 & "/01/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[oneunderzerotwelve]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[oneunderzerotwelve]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " oneunderzerotwelve "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text + 1 & "/02/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[twounderzeroone]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[twounderzeroone]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " twounderzeroone "
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        WK_date = TextBox2.Text + 1 & "/03/01"
        WK_date = DateAdd("d", -1, WK_date)

        strSQL = "if exists(select * from sys.objects"
        strSQL = strSQL & " where object_id=object_id(N'[dbo].[twounderzerotwo]')"
        strSQL = strSQL & " and type in (N'U'))"
        strSQL = strSQL & " drop table [dbo].[twounderzerotwo]"
        strSQL = strSQL & " SELECT Wrn_sub.BY_cls, Wrn_sub.item_cat_code, Count(Wrn_sub.close_date) AS カウント, Sum(Wrn_sub.prch_price) AS 合計 INTO "
        strSQL = strSQL & " twounderzerotwo"
        strSQL = strSQL & " FROM Wrn_sub_xls1 as Wrn_sub"
        strSQL = strSQL & " WHERE Wrn_sub.close_date ='" & WK_date & "'"
        strSQL = strSQL & " GROUP BY Wrn_sub.BY_cls, Wrn_sub.item_cat_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()


        strSQL = "SELECT Cat_mtr_acc.商品コード, [oneunderzerothree].[カウント] AS カウント03, [oneunderzerothree].合計 AS 合計03, [oneunderzerofour].[カウント] AS カウント04, [oneunderzerofour].合計 AS 合計04, "
        strSQL = strSQL & " [oneunderzerofive].[カウント] AS カウント05, [oneunderzerofive].合計 AS 合計05, [oneunderzerosix].[カウント] AS カウント06, [oneunderzerosix].合計 AS 合計06, [oneunderzeroseven].[カウント] AS カウント07, "
        strSQL = strSQL & " [oneunderzeroseven].合計 AS 合計07, [oneunderzeroeight].[カウント] AS カウント08, [oneunderzeroeight].合計 AS 合計08, [oneunderzeronine].[カウント] AS カウント09, [oneunderzeronine].合計 AS 合計09, [oneunderzeroten].[カウント] AS カウント10, "
        strSQL = strSQL & " [oneunderzeroten].合計 AS 合計10, [oneunderzeroeleven].[カウント] AS カウント11, [oneunderzeroeleven].合計 AS 合計11, [oneunderzerotwelve].[カウント] AS カウント12, [oneunderzerotwelve].合計 AS 合計12, [twounderzeroone].[カウント] AS カウント01,  "
        strSQL = strSQL & " [twounderzeroone].合計 AS 合計01, [twounderzerotwo].[カウント] AS カウント02, [twounderzerotwo].合計 AS 合計02"
        strSQL = strSQL & " FROM (((((((((((Cat_mtr_acc LEFT JOIN oneunderzerothree ON (Cat_mtr_acc.商品コード = [oneunderzerothree].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzerothree].BY_cls)) "
        strSQL = strSQL & " LEFT JOIN oneunderzerofour ON (Cat_mtr_acc.商品コード = [oneunderzerofour].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzerofour].BY_cls)) LEFT JOIN oneunderzerofive ON (Cat_mtr_acc.商品コード = [oneunderzerofive].item_cat_code) "
        strSQL = strSQL & " AND (Cat_mtr_acc.BY_cls = [oneunderzerofive].BY_cls)) LEFT JOIN oneunderzerosix ON (Cat_mtr_acc.商品コード = [oneunderzerosix].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzerosix].BY_cls)) LEFT JOIN oneunderzeroseven"
        strSQL = strSQL & " ON (Cat_mtr_acc.商品コード = [oneunderzeroseven].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzeroseven].BY_cls)) LEFT JOIN oneunderzeroeight ON (Cat_mtr_acc.商品コード = [oneunderzeroeight].item_cat_code)  "
        strSQL = strSQL & " AND (Cat_mtr_acc.BY_cls = [oneunderzeroeight].BY_cls)) LEFT JOIN oneunderzeronine ON (Cat_mtr_acc.商品コード = [oneunderzeronine].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzeronine].BY_cls)) LEFT JOIN oneunderzeroten"
        strSQL = strSQL & " ON (Cat_mtr_acc.商品コード = [oneunderzeroten].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzeroten].BY_cls)) LEFT JOIN oneunderzeroeleven ON (Cat_mtr_acc.商品コード = [oneunderzeroeleven].item_cat_code) "
        strSQL = strSQL & " AND (Cat_mtr_acc.BY_cls = [oneunderzeroeleven].BY_cls)) LEFT JOIN oneunderzerotwelve ON (Cat_mtr_acc.商品コード = [oneunderzerotwelve].item_cat_code) AND (Cat_mtr_acc.BY_cls = [oneunderzerotwelve].BY_cls)) LEFT JOIN twounderzeroone"
        strSQL = strSQL & " ON (Cat_mtr_acc.商品コード = [twounderzeroone].item_cat_code) AND (Cat_mtr_acc.BY_cls = [twounderzeroone].BY_cls)) LEFT JOIN twounderzerotwo ON (Cat_mtr_acc.商品コード = [twounderzerotwo].item_cat_code)"
        strSQL = strSQL & " AND (Cat_mtr_acc.BY_cls = [twounderzerotwo].BY_cls) order by 商品コード ASC"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsExp, "Q_30_集計1")
        DB_CLOSE()

        DtView1 = New DataView(DsExp.Tables("Q_30_集計1"), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        'xlApp.Visible = True
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Add
        Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(1), Excel.Worksheet)
        Dim xlCells As Excel.Range
        Dim xlRange As Excel.Range = xlSheet.Rows



        xlCells = xlSheet.Cells
        WK_date = TextBox2.Text & "/03/01"
        ' xlRange = xlCells(1, 2) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("B1:C1").Merge()
        xlSheet.Range("B1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("B1:C1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 4) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : xlCells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlSheet.Range("D1:E1").Merge()
        xlSheet.Range("D1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("D1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter


        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 6) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("F1:G1").Merge()
        xlSheet.Range("F1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        'xlRange = xlCells(1, 8) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("H1:I1").Merge()
        xlSheet.Range("H1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("H1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 10) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("J1:K1").Merge()
        xlSheet.Range("J1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("J1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 12) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("L1:M1").Merge()
        xlSheet.Range("L1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("L1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 14) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("N1:O1").Merge()
        xlSheet.Range("N1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("N1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        '  xlRange = xlCells(1, 16) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("P1:Q1").Merge()
        xlSheet.Range("P1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("P1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        'xlRange = xlCells(1, 18) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("R1:S1").Merge()
        xlSheet.Range("R1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("R1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter


        WK_date = DateAdd("m", 1, WK_date)
        'xlRange = xlCells(1, 20) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("T1:U1").Merge()
        xlSheet.Range("T1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("T1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        ' xlRange = xlCells(1, 22) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("V1:W1").Merge()
        xlSheet.Range("V1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("V1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        WK_date = DateAdd("m", 1, WK_date)
        '  xlRange = xlCells(1, 24) : xlRange.Value = Format(WK_date, "yy/MM") : xlRange.ColumnWidth = 10 : MRComObject(xlRange)
        xlSheet.Range("X1:Y1").Merge()
        xlSheet.Range("X1").Value = Format(WK_date, "yy/MM")
        xlSheet.Range("X1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'xlRange = xlCells(1, 26) : xlRange.Value = "合計	" : MRComObject(xlRange)
        xlSheet.Range("Z1:AA1").Merge()
        xlSheet.Range("Z1").Value = "合計"
        xlSheet.Range("Z1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter


        xlRange = xlCells(2, 1) : xlRange.Value = "商品コード" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 2) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 3) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 4) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 5) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 6) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 7) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 8) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 9) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 10) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 11) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 12) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 13) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 14) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 15) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 16) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 17) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 18) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 19) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 20) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 21) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 22) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 23) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 24) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 25) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)
        xlRange = xlCells(2, 26) : xlRange.Value = "件数" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
        xlRange = xlCells(2, 27) : xlRange.Value = "金額" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : xlRange.ColumnWidth = 15 : MRComObject(xlRange)

        Dim Hs As Excel.HPageBreaks = xlSheet.HPageBreaks
        Dim H As Excel.HPageBreak

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        With xlApp.ActiveWindow
            If .FreezePanes Then .FreezePanes = False
            .SplitColumn = 1
            .SplitRow = 2
            .FreezePanes = True
        End With

        For i = 0 To DtView1.Count - 1

            waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
            waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"

            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            j = i + 3  'セル行

            If Not IsDBNull(DtView1(i)("商品コード")) Then xlRange = xlCells(j, 1) : xlRange.Value = Trim(DtView1(i)("商品コード")).ToString : xlRange.NumberFormat = "00###0_)" : xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント03")) Then xlRange = xlCells(j, 2) : xlRange.Value = Trim(DtView1(i)("カウント03")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計03")) Then xlRange = xlCells(j, 3) : xlRange.Value = Trim(DtView1(i)("合計03")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント04")) Then xlRange = xlCells(j, 4) : xlRange.Value = Trim(DtView1(i)("カウント04")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計04")) Then xlRange = xlCells(j, 5) : xlRange.Value = Trim(DtView1(i)("合計04")).ToString : xlRange.NumberFormat = "_( #,##0;_( (#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント05")) Then xlRange = xlCells(j, 6) : xlRange.Value = Trim(DtView1(i)("カウント05")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計05")) Then xlRange = xlCells(j, 7) : xlRange.Value = Trim(DtView1(i)("合計05")).ToString : xlRange.NumberFormat = "_( #,##0;_( (#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント06")) Then xlRange = xlCells(j, 8) : xlRange.Value = Trim(DtView1(i)("カウント06")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計06")) Then xlRange = xlCells(j, 9) : xlRange.Value = Trim(DtView1(i)("合計06")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント07")) Then xlRange = xlCells(j, 10) : xlRange.Value = Trim(DtView1(i)("カウント07")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計07")) Then xlRange = xlCells(j, 11) : xlRange.Value = Trim(DtView1(i)("合計07")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント08")) Then xlRange = xlCells(j, 12) : xlRange.Value = Trim(DtView1(i)("カウント08")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計08")) Then xlRange = xlCells(j, 13) : xlRange.Value = Trim(DtView1(i)("合計08")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント09")) Then xlRange = xlCells(j, 14) : xlRange.Value = Trim(DtView1(i)("カウント09")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計09")) Then xlRange = xlCells(j, 15) : xlRange.Value = Trim(DtView1(i)("合計09")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント10")) Then xlRange = xlCells(j, 16) : xlRange.Value = Trim(DtView1(i)("カウント10")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計10")) Then xlRange = xlCells(j, 17) : xlRange.Value = Trim(DtView1(i)("合計10")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント11")) Then xlRange = xlCells(j, 18) : xlRange.Value = Trim(DtView1(i)("カウント11")).ToString : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計11")) Then xlRange = xlCells(j, 19) : xlRange.Value = Trim(DtView1(i)("合計11")).ToString : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント12")) Then xlRange = xlCells(j, 20) : xlRange.Value = DtView1(i)("カウント12") : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計12")) Then xlRange = xlCells(j, 21) : xlRange.Value = DtView1(i)("合計12") : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント01")) Then xlRange = xlCells(j, 22) : xlRange.Value = DtView1(i)("カウント01") : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計01")) Then xlRange = xlCells(j, 23) : xlRange.Value = DtView1(i)("合計01") : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("カウント02")) Then xlRange = xlCells(j, 24) : xlRange.Value = DtView1(i)("カウント02") : MRComObject(xlRange)
            If Not IsDBNull(DtView1(i)("合計02")) Then xlRange = xlCells(j, 25) : xlRange.Value = DtView1(i)("合計02") : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)" : MRComObject(xlRange)
            xlRange = xlCells(j, 26) : xlRange.Value = "=SUM(B" & j & ",D" & j & ",F" & j & ",H" & j & ",J" & j & ",L" & j & ",N" & j & ",P" & j & ",R" & j & ",T" & j & ",V" & j & ",X" & j & ")"
            xlRange = xlCells(j, 27) : xlRange.Value = "=SUM(C" & j & ",E" & j & ",G" & j & ",I" & j & ",K" & j & ",M" & j & ",O" & j & ",Q" & j & ",S" & j & ",U" & j & ",W" & j & ",Y" & j & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"

        Next

        j = j + 2
        xlRange = xlCells(j, 2) : xlRange.Value = "=SUM(B3:B" & j - 1 & ")"
        xlRange = xlCells(j, 3) : xlRange.Value = "=SUM(C3:C" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 4) : xlRange.Value = "=SUM(D3:D" & j - 1 & ")"
        xlRange = xlCells(j, 5) : xlRange.Value = "=SUM(E3:E" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 7) : xlRange.Value = "=SUM(G3:G" & j - 1 & ")"
        xlRange = xlCells(j, 8) : xlRange.Value = "=SUM(H3:H" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 9) : xlRange.Value = "=SUM(I3:I" & j - 1 & ")"
        xlRange = xlCells(j, 6) : xlRange.Value = "=SUM(F3:F" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 10) : xlRange.Value = "=SUM(J3:J" & j - 1 & ")"
        xlRange = xlCells(j, 11) : xlRange.Value = "=SUM(K3:K" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 12) : xlRange.Value = "=SUM(L3:L" & j - 1 & ")"
        xlRange = xlCells(j, 13) : xlRange.Value = "=SUM(M3:M" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 14) : xlRange.Value = "=SUM(N3:N" & j - 1 & ")"
        xlRange = xlCells(j, 15) : xlRange.Value = "=SUM(O3:O" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 16) : xlRange.Value = "=SUM(P3:P" & j - 1 & ")"
        xlRange = xlCells(j, 17) : xlRange.Value = "=SUM(Q3:Q" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 18) : xlRange.Value = "=SUM(R3:R" & j - 1 & ")"
        xlRange = xlCells(j, 19) : xlRange.Value = "=SUM(S3:S" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 20) : xlRange.Value = "=SUM(T3:T" & j - 1 & ")"
        xlRange = xlCells(j, 21) : xlRange.Value = "=SUM(U3:U" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 22) : xlRange.Value = "=SUM(V3:V" & j - 1 & ")"
        xlRange = xlCells(j, 23) : xlRange.Value = "=SUM(W3:W" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 24) : xlRange.Value = "=SUM(X3:X" & j - 1 & ")"
        xlRange = xlCells(j, 25) : xlRange.Value = "=SUM(Y3:Y" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        xlRange = xlCells(j, 26) : xlRange.Value = "=SUM(Z3:Z" & j - 1 & ")"
        xlRange = xlCells(j, 27) : xlRange.Value = "=SUM(AA3:AA" & j - 1 & ")" : xlRange.NumberFormat = "_( #,##0;_((#,##0);_(* ""-""??_);_(@_)"
        'xlCells.EntireColumn.AutoFit()   'セル幅（列幅）の自動調整



        MRComObject(xlCells)

        Me.Activate()
        ' waitDlg.Close()

        '［名前を付けて保存］ダイアログボックスを表示
        'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
        SaveFileDialog1.FileName = "商品別加入集計_法人除く" & TextBox2.Text & "03_" & TextBox2.Text + 1 & "02.xls"
        '   SaveFileDialog1.Filter = "Excelファイル|*.xlsx"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Try
            xlBook.SaveAs(SaveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal)
        Catch ex As System.Exception
            Exit Sub
        End Try

        Me.Enabled = True

        ' 終了処理　
        MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)              'xlApp を開放

        '   Call Deleteobjects()
    End Sub
    Sub Deleteobjects()
        strSQL = "Drop table Wrn_sub_xls1 "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table Cat_mtr_acc "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzerothree "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzerofour "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzerofive "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzerosix "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzeroseven "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzeroeight "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzeronine "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzeroten "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzeroeleven "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table oneunderzerotwelve "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table twounderzeroone "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        strSQL = "Drop table twounderzerotwo "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub

    Private Sub MRComObject(ByVal objXl As Object)
        'Excel 終了処理時のプロシージャ
        Try
            '提供されたランタイム呼び出し可能ラッパーの参照カウントをデクリメントします
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objXl)
        Catch
        Finally
            objXl = Nothing
        End Try
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call DB_INIT()
        受付日 = Date.Today.Year
        Label4.Text = 受付日 & "/03"

        Label6.Text = 受付日 + 1 & "/02"
        TextBox2.Text = 受付日
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        'Label4.Text = TextBox2.Text & "/03"
        'Label6.Text = TextBox2.Text + 1 & "/02"
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text = Nothing Then
            MSG.Text = "処理年を入力してください。"
            Label4.Visible = False
            Label6.Visible = False
            Label5.Visible = False
            Button5.Enabled = False
        ElseIf TextBox2.Text.Length <> 4 Then
            MSG.Text = "処理年を入力してください。"
            Label4.Visible = False
            Label6.Visible = False
            Label5.Visible = False
            Button5.Enabled = False

        Else
            MSG.Text = ""
            Label4.Visible = True
            Label6.Visible = True
            Label5.Visible = True
            Button5.Enabled = True
            Button5.Select()

        End If
        If TextBox2.Text <> "" Then
            Label4.Text = TextBox2.Text & "/03"
            Label6.Text = TextBox2.Text + 1 & "/02"
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class

