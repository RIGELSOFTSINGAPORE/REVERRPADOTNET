Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Public Class ApplePartsEntryControl

    Public Function AddPartsEntry(ApplePartsEntry As List(Of ApplePartsEntryModel), queryParams As ApplePartsInventoryModel, TranFlg As String) As Boolean
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Return Status 
        Dim flag As Boolean = False
        'Ship Code
        Dim strShipCode As String = ""
        Try

            Dim strDate As String = ""

            'Define Database 
            Dim DateTimeNow As DateTime = DateTime.Now
            Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
            Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("cnstr").ConnectionString)
            'Open Database

            con.Open()
            Dim trn As SqlTransaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
            Try
                Dim newData As Integer
                Dim add As Integer
                For i = 0 To ApplePartsEntry.Count - 1


                    'Bydefault Assing Zero
                    add = 0
                    newData = 0
                    'Query 
                    'If Record is exit then it will update otherwise it will create new records
                    Dim select_sql1 As String = ""
                    select_sql1 = "SELECT * FROM AC_PARTS_ENTRY WHERE DELFG = 0 "
                    select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & queryParams.SHIP_TO_BRANCH_CODE & "' "
                    select_sql1 &= "AND INVENTORY_NO = '" & queryParams.INVENTORY_NO & "' "
                    select_sql1 &= "AND SR_NO = '" & ApplePartsEntry.Item(i).SR_NO & "' "

                    'DataAdpater and DataSet Define
                    Dim sqlSelect1 As New SqlCommand(select_sql1, con, trn)
                    Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
                    Dim Builder1 As New SqlCommandBuilder(Adapter1)
                    Dim ds1 As New DataSet
                    Dim dr1 As DataRow
                    Adapter1.Fill(ds1)
                    'If Record exist update otherwise insert as new record
                    If ds1.Tables(0).Rows.Count = 1 Then
                        dr1 = ds1.Tables(0).Rows(0)
                        add = 1
                    Else
                        dr1 = ds1.Tables(0).NewRow
                        newData = 1
                    End If

                    If newData = 1 Then
                        dr1("CRTDT") = dtNow
                        dr1("CRTCD") = queryParams.UserId
                    End If

                    If add = 1 Then
                        dr1("UPDDT") = dtNow
                        dr1("UPDCD") = queryParams.UserId
                    End If


                    dr1("UPDPG") = "ApplePartsEntryControl.vb"
                    dr1("DELFG") = 0
                    dr1("UPLOAD_USER") = queryParams.UploadUser
                    dr1("UPLOAD_DATE") = dtNow

                    dr1("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                    dr1("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH

                    'Prabu add part tax
                    dr1("PART_TAX") = ApplePartsEntry.Item(i).PART_TAX
                    dr1("INVENTORY_NO") = queryParams.INVENTORY_NO
                    dr1("INVENTORY_DATE") = queryParams.INVENTORY_DATE
                    dr1("SR_NO") = ApplePartsEntry.Item(i).SR_NO
                    dr1("PART_NO") = ApplePartsEntry.Item(i).PART_NO
                    dr1("UPC_EAN") = ApplePartsEntry.Item(i).UPC_EAN
                    dr1("DESCRIPTION") = ApplePartsEntry.Item(i).DESCRIPTION
                    dr1("IN_STOCK") = ApplePartsEntry.Item(i).IN_STOCK
                    dr1("BALANCE") = ApplePartsEntry.Item(i).BALANCE
                    dr1("SALES_PRICE") = ApplePartsEntry.Item(i).SALES_PRICE
                    dr1("PURCHASE_PRICE") = ApplePartsEntry.Item(i).PURCHASE_PRICE


                    If newData = 1 Then
                        ds1.Tables(0).Rows.Add(dr1)
                    End If
                    Adapter1.Update(ds1)

                Next i

                If TranFlg = "commit" Then
                    'Update Edit Mode False
                    Dim sqldelcmd As New SqlCommand("UPDATE AC_PARTS_INVENTORY SET EDIT_MODE=1 WHERE INVENTORY_NO='" & queryParams.INVENTORY_NO & "'", con, trn)
                    sqldelcmd.CommandType = CommandType.Text
                    sqldelcmd.ExecuteNonQuery()

                    'Update Stock Master Table
                    For i = 0 To ApplePartsEntry.Count - 1
                        add = 0
                        newData = 0
                        'Query 
                        'If Record is exit then  it will update otherwise it will create new records
                        Dim select_sql1 As String = ""
                        select_sql1 = "SELECT * FROM AC_PARTS_MST WHERE DELFG = 0 "
                        select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & queryParams.SHIP_TO_BRANCH_CODE & "' "
                        select_sql1 &= "AND PART_NO = '" & ApplePartsEntry.Item(i).PART_NO & "' "
                        If Not String.IsNullOrEmpty(ApplePartsEntry.Item(i).UPC_EAN) Then
                            select_sql1 &= "AND UPC_EAN = '" & ApplePartsEntry.Item(i).UPC_EAN & "' "
                        End If

                        select_sql1 &= "AND DESCRIPTION = '" & ApplePartsEntry.Item(i).DESCRIPTION & "' "

                        'DataAdpater and DataSet Define
                        Dim sqlSelect2 As New SqlCommand(select_sql1, con, trn)
                        Dim Adapter2 As New SqlDataAdapter(sqlSelect2)
                        Dim Builder2 As New SqlCommandBuilder(Adapter2)
                        Dim ds2 As New DataSet
                        Dim dr2 As DataRow
                        Adapter2.Fill(ds2)
                        'If Record exist update otherwise insert as new record
                        If ds2.Tables(0).Rows.Count = 1 Then
                            dr2 = ds2.Tables(0).Rows(0)
                            add = 1
                        Else
                            dr2 = ds2.Tables(0).NewRow
                            newData = 1
                        End If

                        If newData = 1 Then
                            dr2("CRTDT") = dtNow
                            dr2("CRTCD") = queryParams.UserId
                            dr2("CURRENT_IN_STOCK") = ApplePartsEntry.Item(i).IN_STOCK
                        End If

                        If add = 1 Then
                            dr2("UPDDT") = dtNow
                            dr2("UPDCD") = queryParams.UserId
                            dr2("CURRENT_IN_STOCK") = dr2("CURRENT_IN_STOCK") + ApplePartsEntry.Item(i).IN_STOCK
                        End If

                        dr2("LAST_IN_DATE") = queryParams.INVENTORY_DATE

                        dr2("UPDPG") = "ApplePartsEntryControl.vb"
                        dr2("DELFG") = 0
                        dr2("UPLOAD_USER") = queryParams.UploadUser
                        dr2("UPLOAD_DATE") = dtNow

                        dr2("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                        dr2("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH



                        dr2("PART_NO") = ApplePartsEntry.Item(i).PART_NO
                        dr2("UPC_EAN") = ApplePartsEntry.Item(i).UPC_EAN
                        dr2("DESCRIPTION") = ApplePartsEntry.Item(i).DESCRIPTION

                        'dr1("SAP_PART_DESCRIPTION") = ""
                        dr2("PURCHASE_PRICE") = ApplePartsEntry.Item(i).PURCHASE_PRICE
                        dr2("SALES_PRICE") = ApplePartsEntry.Item(i).SALES_PRICE
                        'Prabu add part tax
                        dr2("PART_TAX") = ApplePartsEntry.Item(i).PART_TAX


                        If newData = 1 Then
                            ds2.Tables(0).Rows.Add(dr2)
                        End If
                        Adapter2.Update(ds2)

                    Next i

                    'Update Stock Master Table
                    Dim strStockTran As String = ""
                    For i = 0 To ApplePartsEntry.Count - 1
                        Dim select_sql3 As String = ""
                        select_sql3 = "SELECT * FROM AC_STOCK_TRAN "
                        'DataAdpater and DataSet Define
                        Dim sqlSelect3 As New SqlCommand(select_sql3, con, trn)
                        Dim Adapter3 As New SqlDataAdapter(sqlSelect3)
                        Dim Builder3 As New SqlCommandBuilder(Adapter3)
                        Dim ds3 As New DataSet
                        Dim dr3 As DataRow
                        Adapter3.Fill(ds3)

                        dr3 = ds3.Tables(0).NewRow

                        dr3("CRTDT") = dtNow
                        dr3("CRTCD") = queryParams.UserId
                        dr3("UPDDT") = dtNow
                        dr3("UPDCD") = queryParams.UserId
                        dr3("UPDPG") = "ApplePartsEntryControl.vb"
                        dr3("DELFG") = 0
                        dr3("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                        dr3("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH
                        dr3("PART_NO") = ApplePartsEntry.Item(i).PART_NO
                        dr3("DESCRIPTION") = ApplePartsEntry.Item(i).DESCRIPTION
                        dr3("QUANTITY") = ApplePartsEntry.Item(i).IN_STOCK
                        dr3("TRAN_TYPE") = "1" '1- Instock / 2-OutStock
                        dr3("TRAN_REF") = queryParams.INVENTORY_NO
                        ds3.Tables(0).Rows.Add(dr3)
                        Adapter3.Update(ds3)
                    Next

                End If
                trn.Commit()
                'Transaction Successful, return true
                flag = True
            Catch ex As Exception
                trn.Rollback()
                Log4NetControl.ComErrorLogWrite(ex.ToString())
                'Failure, return as false
                flag = False
            Finally
                If con.State <> ConnectionState.Closed Then
                    con.Close()
                End If
            End Try

        Catch ex As Exception
            flag = False
            Log4NetControl.ComErrorLogWrite(ex.ToString())
        End Try
        'Return Transaction Status 
        Return flag
    End Function



    Public Function SelectInventery(queryParams As ApplePartsInventoryModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        'Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & "acpe.UNQ_NO,ROW_NUMBER() OVER (ORDER BY INVENTORY_NO) RowNumber, "
        'sqlStr = sqlStr & "acpe.PART_NO,acpe.UPC_EAN,acpe.DESCRIPTION,acpe.BALANCE, "
        'sqlStr = sqlStr & "acpe.IN_STOCK,acpe.PURCHASE_PRICE,acpe.SALES_PRICE,acpe.SAP_PART_DESCRIPTION, "
        'sqlStr = sqlStr & "acpe.INVENTORY_DATE,acpm.PART_TAX "
        ''sqlStr = sqlStr & " "
        'sqlStr = sqlStr & "FROM "
        'sqlStr = sqlStr & "AC_PARTS_ENTRY as acpe join AC_PARTS_MST as acpm on  acpe.PART_NO = acpm.PART_NO "
        'sqlStr = sqlStr & "WHERE "
        'sqlStr = sqlStr & "acpe.DELFG=0 "

        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "UNQ_NO,ROW_NUMBER() OVER (ORDER BY INVENTORY_NO) RowNumber, "
        sqlStr = sqlStr & "PART_NO,UPC_EAN,DESCRIPTION,BALANCE, IN_STOCK,PURCHASE_PRICE,SALES_PRICE,SAP_PART_DESCRIPTION,INVENTORY_DATE,PART_TAX "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AC_PARTS_ENTRY "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.INVENTORY_NO) Then
            sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.INVENTORY_NO))
        End If

        'If Not String.IsNullOrEmpty(queryParams.INVENTORY_NO) Then
        '    sqlStr = sqlStr & "and acpe.INVENTORY_NO = @INVENTORY_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.INVENTORY_NO))
        'End If

        'sqlStr = sqlStr & "ORDER BY SR_NO "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable


    End Function
    Public Function DeletePartsRow(queryParams As ApplePartsEntryModel) As Boolean
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim sqlStr As String = ""
        Dim flag As Boolean = True

        Dim dbConn As DBUtility = New DBUtility()
        '   dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()

        sqlStr = "DELETE FROM AC_PARTS_ENTRY "
        sqlStr = sqlStr & "WHERE INVENTORY_NO=@INVENTORY_NO "
        sqlStr = sqlStr & "AND SR_NO=@SR_NO "
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.INVENTORY_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SR_NO", queryParams.SR_NO))
        flag = dbConn.ExecSQL(sqlStr)

        dbConn.CloseConnection()
        Return flag
    End Function

    Public Function SelectPartsnStockAppConsignment(queryParams As ApplePartsEntryModel) As DataTable
        'SELECT top 1 *,  ( SELECT SUM(CURRENT_IN_STOCK)     FROM AP_PARTS_STOCK WHERE DELFG=0   AND AP_PARTS.PARTS_NO = AP_PARTS_STOCK.PART_NO  ) AS BALANCE   FROM AP_PARTS WHERE DELFG=0 AND AP_PARTS.PARTS_NO = '' 
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "top 1 "
        sqlStr = sqlStr & "*  "
        ' sqlStr = sqlStr & " BALANCE AS BALANCE   "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_MST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 AND BALANCE !=0 "
        If Not String.IsNullOrEmpty(queryParams.PART_NO) Then
            sqlStr = sqlStr & "AND PARTS_NO = @PART_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        End If

        If Not String.IsNullOrEmpty(queryParams.SERIAL_TYPE) Then
            sqlStr = sqlStr & "AND SERIAL_TYPE = @SERIAL_TYPE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_TYPE", queryParams.SERIAL_TYPE))
        Else
            sqlStr = sqlStr & "AND SERIAL_TYPE = 'N' "
            ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_TYPE", queryParams.SERIAL_TYPE))
        End If

        sqlStr = sqlStr & " ORDER BY BALANCE DESC "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectPartsnStockAppStock(queryParams As ApplePartsEntryModel) As DataTable
        'SELECT top 1 *,  ( SELECT SUM(CURRENT_IN_STOCK)     FROM AP_PARTS_STOCK WHERE DELFG=0   AND AP_PARTS.PARTS_NO = AP_PARTS_STOCK.PART_NO  ) AS BALANCE   FROM AP_PARTS WHERE DELFG=0 AND AP_PARTS.PARTS_NO = '' 
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "top 1 "
        sqlStr = sqlStr & "*  "
        'sqlStr = sqlStr & " BALANCE AS BALANCE   "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS_STOCK_MST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 AND BALANCE !=0 "
        If Not String.IsNullOrEmpty(queryParams.PART_NO) Then
            sqlStr = sqlStr & "AND PARTS_NO = @PART_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        End If

        If Not String.IsNullOrEmpty(queryParams.SERIAL_TYPE) Then
            sqlStr = sqlStr & "AND SERIAL_TYPE = @SERIAL_TYPE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_TYPE", queryParams.SERIAL_TYPE))
        Else
            sqlStr = sqlStr & "AND SERIAL_TYPE = 'N' "
            ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_TYPE", queryParams.SERIAL_TYPE))
        End If
        sqlStr = sqlStr & " ORDER BY BALANCE DESC "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
    Public Function SelectPartsnStock(queryParams As ApplePartsEntryModel) As DataTable
        'SELECT top 1 *,  ( SELECT SUM(CURRENT_IN_STOCK)     FROM AP_PARTS_STOCK WHERE DELFG=0   AND AP_PARTS.PARTS_NO = AP_PARTS_STOCK.PART_NO  ) AS BALANCE   FROM AP_PARTS WHERE DELFG=0 AND AP_PARTS.PARTS_NO = '' 
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "top 1 "

        sqlStr = sqlStr & "*,  "
        'sqlStr = sqlStr & "( SELECT SUM(CURRENT_IN_STOCK)     FROM AP_PARTS_STOCK WHERE DELFG=0   "
        ' If Not String.IsNullOrEmpty(queryParams.PART_NO) Then
        'sqlStr = sqlStr & "AND AP_PARTS.PARTS_NO = AP_PARTS_STOCK.PART_NO "
        ' End If
        'If Not String.IsNullOrEmpty(queryParams.UPC_EAN) Then
        '    sqlStr = sqlStr & "AND AP_PARTS.HSN_SAC = AP_PARTS_STOCK.UPC_EAN "
        'End If
        'If Not String.IsNullOrEmpty(queryParams.DESCRIPTION) Then
        '    sqlStr = sqlStr & "AND AP_PARTS.PARTS_DETAIL = AP_PARTS_STOCK.DESCRIPTION "
        'End If
        sqlStr = sqlStr & " CURRENT_IN_STOCK AS BALANCE   "
        'sqlStr = sqlStr & "*,  (SELECT SUM(CURRENT_IN_STOCK)     FROM AP_PARTS_STOCK WHERE AP_PARTS_STOCK.PART_NO = AC_PARTS_ENTRY.PART_NO) AS BALANCE  "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AC_PARTS_MST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PART_NO) Then
            sqlStr = sqlStr & "AND PART_NO = @PART_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
End Class
