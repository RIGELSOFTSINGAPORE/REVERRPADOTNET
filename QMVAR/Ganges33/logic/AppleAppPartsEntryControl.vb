Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Public Class AppleAppPartsEntryControl

    Public Function AddPartsEntry(AppleAppPartsEntry As List(Of AppleAppPartsEntryModel), queryParams As AppleAppPartsInventoryModel, TranFlg As String, ConsStockVal As String) As Boolean
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

                'If 1 then CONSIGNMENT Entry ,2 Parts Entry
                If ConsStockVal = "Consignment" Then
                    For i = 0 To AppleAppPartsEntry.Count - 1
                        'Bydefault Assing Zero
                        add = 0
                        newData = 0
                        'Query 
                        'If Record is exit then it will update otherwise it will create new records
                        Dim select_sql1 As String = ""
                        select_sql1 = "SELECT * FROM AP_PARTS_CONSIGNMENT_STOCK_ENTRY WHERE DELFG = 0 "
                        select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & queryParams.SHIP_TO_BRANCH_CODE & "' "
                        select_sql1 &= "AND INVENTORY_NO = '" & queryParams.INVENTORY_NO & "' "
                        select_sql1 &= "AND SR_NO = '" & AppleAppPartsEntry.Item(i).SR_NO & "' "

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

                        dr1("UPDPG") = "AppleAppPartsEntryControl.vb"
                        dr1("DELFG") = 0

                        dr1("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                        dr1("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH

                        'dr1("PART_TAX") = AppleAppPartsEntry.Item(i).PART_TAX
                        dr1("INVENTORY_NO") = queryParams.INVENTORY_NO
                        dr1("INVENTORY_DATE") = queryParams.INVENTORY_DATE
                        dr1("SR_NO") = AppleAppPartsEntry.Item(i).SR_NO
                        dr1("PARTS_NO") = AppleAppPartsEntry.Item(i).PARTS_NO
                        dr1("PARTS_NAME") = AppleAppPartsEntry.Item(i).PARTS_NAME
                        dr1("PARTS_DESCRIPTION") = AppleAppPartsEntry.Item(i).PARTS_DESCRIPTION
                        dr1("PARTS_TYPE") = AppleAppPartsEntry.Item(i).PARTS_TYPE
                        dr1("PURCHASE_COST") = AppleAppPartsEntry.Item(i).PARTS_COST
                        dr1("TIER") = AppleAppPartsEntry.Item(i).TIER
                        dr1("EEE_EEEE") = AppleAppPartsEntry.Item(i).EEE_EEEE
                        dr1("SERIAL_TYPE") = AppleAppPartsEntry.Item(i).SERIAL
                        dr1("SERIAL_NO") = AppleAppPartsEntry.Item(i).SERIAL_NO
                        dr1("IN_STOCK") = AppleAppPartsEntry.Item(i).IN_STOCK
                        dr1("BALANCE") = AppleAppPartsEntry.Item(i).BALANCE

                        If newData = 1 Then
                            ds1.Tables(0).Rows.Add(dr1)
                        End If
                        Adapter1.Update(ds1)

                    Next i

                    If TranFlg = "commit" Then
                        'Update Edit Mode False 
                        Dim sqldelcmd As New SqlCommand("UPDATE AP_PARTS_INVENTORY SET EDIT_MODE=1 WHERE INVENTORY_NO='" & queryParams.INVENTORY_NO & "'", con, trn)
                        sqldelcmd.CommandType = CommandType.Text
                        sqldelcmd.ExecuteNonQuery()

                        'Update Stock Master Table
                        For i = 0 To AppleAppPartsEntry.Count - 1
                            add = 0
                            newData = 0
                            'Query 
                            'If Record is exit then it will update otherwise it will create new records
                            Dim select_sql1 As String = ""
                            select_sql1 = "SELECT * FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG = 0 "
                            select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & queryParams.SHIP_TO_BRANCH_CODE & "' "
                            select_sql1 &= "AND PARTS_NO = '" & AppleAppPartsEntry.Item(i).PARTS_NO & "' "
                            select_sql1 &= "AND PRODUCT_NAME = '" & AppleAppPartsEntry.Item(i).PARTS_NAME & "' "
                            select_sql1 &= "AND PARTS_DETAIL = '" & AppleAppPartsEntry.Item(i).PARTS_DESCRIPTION & "' "
                            If AppleAppPartsEntry.Item(i).SERIAL = "N" Then
                                select_sql1 &= "AND SERIAL_TYPE = '" & AppleAppPartsEntry.Item(i).SERIAL & "' "
                            End If
                            'DataAdpater and DataSet Define
                            Dim sqlSelect2 As New SqlCommand(select_sql1, con, trn)
                            Dim Adapter2 As New SqlDataAdapter(sqlSelect2)
                            Dim Builder2 As New SqlCommandBuilder(Adapter2)
                            Dim ds2 As New DataSet
                            Dim dr2 As DataRow
                            Adapter2.Fill(ds2)
                            'If Record exist update otherwise insert as new record
                            If AppleAppPartsEntry.Item(i).SERIAL = "Y" Then
                                dr2 = ds2.Tables(0).NewRow
                                newData = 1
                            Else
                                If ds2.Tables(0).Rows.Count = 1 Then
                                    dr2 = ds2.Tables(0).Rows(0)
                                    add = 1
                                Else
                                    dr2 = ds2.Tables(0).NewRow
                                    newData = 1
                                End If
                            End If

                            If newData = 1 Then
                                dr2("CRTDT") = dtNow
                                dr2("CRTCD") = queryParams.UserId
                                dr2("IN_STOCK") = AppleAppPartsEntry.Item(i).IN_STOCK
                                If AppleAppPartsEntry.Item(i).SERIAL = "Y" Then
                                    dr2("BALANCE") = AppleAppPartsEntry.Item(i).BALANCE
                                Else
                                    dr2("BALANCE") = dr2("BALANCE") + AppleAppPartsEntry.Item(i).IN_STOCK
                                End If                              '

                            End If

                            If add = 1 Then
                                dr2("UPDDT") = dtNow
                                dr2("UPDCD") = queryParams.UserId
                                'dr2("IN_STOCK") = dr2("IN_STOCK") + AppleAppPartsEntry.Item(i).IN_STOCK
                                dr2("IN_STOCK") = AppleAppPartsEntry.Item(i).IN_STOCK
                                dr2("BALANCE") = dr2("BALANCE") + AppleAppPartsEntry.Item(i).IN_STOCK
                            End If

                            'dr2("LAST_IN_DATE") = queryParams.INVENTORY_DATE

                            dr2("UPDPG") = "AppleAppPartsEntryControl.vb"
                            dr2("DELFG") = 0
                            'dr2("UPLOAD_USER") = queryParams.UploadUser
                            'dr2("UPLOAD_DATE") = dtNow

                            dr2("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                            dr2("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH

                            dr2("PARTS_NO") = AppleAppPartsEntry.Item(i).PARTS_NO
                            dr2("PRODUCT_NAME") = AppleAppPartsEntry.Item(i).PARTS_NAME
                            dr2("PARTS_DETAIL") = AppleAppPartsEntry.Item(i).PARTS_DESCRIPTION

                            dr2("PARTS_TYPE") = AppleAppPartsEntry.Item(i).PARTS_TYPE
                            dr2("PURCHASE_COST") = AppleAppPartsEntry.Item(i).PARTS_COST

                            dr2("TIER") = AppleAppPartsEntry.Item(i).TIER
                            dr2("EEE_EEEE") = AppleAppPartsEntry.Item(i).EEE_EEEE
                            dr2("SERIAL_TYPE") = AppleAppPartsEntry.Item(i).SERIAL
                            dr2("SERIAL_NO") = AppleAppPartsEntry.Item(i).SERIAL_NO
                            'dr2("IN_STOCK") = AppleAppPartsEntry.Item(i).IN_STOCK

                            If newData = 1 Then
                                ds2.Tables(0).Rows.Add(dr2)
                            End If
                            Adapter2.Update(ds2)

                        Next i

                        'Update Stock Master Table
                        Dim strStockTran As String = ""
                        For i = 0 To AppleAppPartsEntry.Count - 1
                            Dim select_sql3 As String = ""
                            select_sql3 = "SELECT * FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN "
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
                            dr3("UPDPG") = "AppleAppPartsEntryControl.vb"
                            dr3("DELFG") = 0
                            dr3("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                            dr3("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH
                            dr3("PART_NO") = AppleAppPartsEntry.Item(i).PARTS_NO
                            dr3("DESCRIPTION") = AppleAppPartsEntry.Item(i).PARTS_DESCRIPTION
                            dr3("QUANTITY") = AppleAppPartsEntry.Item(i).IN_STOCK
                            'If ConsStockVal = "Consignment" Then
                            dr3("TRAN_TYPE") = "1" '1- Instock / 2-OutStock
                            dr3("STOCK_TYPE") = "1"
                            dr3("TRAN_REF") = queryParams.INVENTORY_NO
                            dr3("SERIAL_NO") = AppleAppPartsEntry.Item(i).SERIAL_NO
                            ds3.Tables(0).Rows.Add(dr3)
                            Adapter3.Update(ds3)
                        Next

                    End If
                Else
                    For i = 0 To AppleAppPartsEntry.Count - 1
                        'Bydefault Assing Zero
                        add = 0
                        newData = 0
                        'Query 
                        'If Record is exit then it will update otherwise it will create new records
                        Dim select_sql1 As String = ""
                        select_sql1 = "SELECT * FROM AP_PARTS_STOCK_ENTRY WHERE DELFG = 0 "
                        select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & queryParams.SHIP_TO_BRANCH_CODE & "' "
                        select_sql1 &= "AND INVENTORY_NO = '" & queryParams.INVENTORY_NO & "' "
                        select_sql1 &= "AND SR_NO = '" & AppleAppPartsEntry.Item(i).SR_NO & "' "

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

                        dr1("UPDPG") = "AppleAppPartsEntryControl.vb"
                        dr1("DELFG") = 0
                        'dr1("UPLOAD_USER") = queryParams.UploadUser
                        'dr1("UPLOAD_DATE") = dtNow

                        dr1("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                        dr1("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH

                        'dr1("PART_TAX") = AppleAppPartsEntry.Item(i).PART_TAX
                        dr1("INVENTORY_NO") = queryParams.INVENTORY_NO
                        dr1("INVENTORY_DATE") = queryParams.INVENTORY_DATE
                        dr1("SR_NO") = AppleAppPartsEntry.Item(i).SR_NO
                        dr1("PARTS_NO") = AppleAppPartsEntry.Item(i).PARTS_NO
                        dr1("PARTS_NAME") = AppleAppPartsEntry.Item(i).PARTS_NAME
                        dr1("PARTS_DESCRIPTION") = AppleAppPartsEntry.Item(i).PARTS_DESCRIPTION
                        dr1("PARTS_TYPE") = AppleAppPartsEntry.Item(i).PARTS_TYPE
                        dr1("PURCHASE_COST") = AppleAppPartsEntry.Item(i).PARTS_COST
                        dr1("TIER") = AppleAppPartsEntry.Item(i).TIER
                        dr1("EEE_EEEE") = AppleAppPartsEntry.Item(i).EEE_EEEE
                        dr1("SERIAL_TYPE") = AppleAppPartsEntry.Item(i).SERIAL
                        dr1("SERIAL_NO") = AppleAppPartsEntry.Item(i).SERIAL_NO
                        dr1("IN_STOCK") = AppleAppPartsEntry.Item(i).IN_STOCK
                        dr1("BALANCE") = AppleAppPartsEntry.Item(i).BALANCE

                        If newData = 1 Then
                            ds1.Tables(0).Rows.Add(dr1)
                        End If
                        Adapter1.Update(ds1)

                    Next i

                    If TranFlg = "commit" Then
                        'Update Edit Mode False
                        Dim sqldelcmd As New SqlCommand("UPDATE AP_PARTS_INVENTORY SET EDIT_MODE=1 WHERE INVENTORY_NO='" & queryParams.INVENTORY_NO & "'", con, trn)
                        sqldelcmd.CommandType = CommandType.Text
                        sqldelcmd.ExecuteNonQuery()

                        'Update Stock Master Table
                        For i = 0 To AppleAppPartsEntry.Count - 1
                            add = 0
                            newData = 0
                            'Query 
                            'If Record is exit then it will update otherwise it will create new records
                            Dim select_sql1 As String = ""
                            select_sql1 = "SELECT * FROM AP_PARTS_STOCK_MST WHERE DELFG = 0 "
                            select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & queryParams.SHIP_TO_BRANCH_CODE & "' "
                            select_sql1 &= "AND PARTS_NO = '" & AppleAppPartsEntry.Item(i).PARTS_NO & "' "
                            select_sql1 &= "AND PRODUCT_NAME = '" & AppleAppPartsEntry.Item(i).PARTS_NAME & "' "
                            select_sql1 &= "AND PARTS_DETAIL = '" & AppleAppPartsEntry.Item(i).PARTS_DESCRIPTION & "' "
                            If AppleAppPartsEntry.Item(i).SERIAL = "N" Then
                                select_sql1 &= "AND SERIAL_TYPE = '" & AppleAppPartsEntry.Item(i).SERIAL & "' "
                            End If
                            'DataAdpater and DataSet Define
                            Dim sqlSelect2 As New SqlCommand(select_sql1, con, trn)
                            Dim Adapter2 As New SqlDataAdapter(sqlSelect2)
                            Dim Builder2 As New SqlCommandBuilder(Adapter2)
                            Dim ds2 As New DataSet
                            Dim dr2 As DataRow
                            Adapter2.Fill(ds2)
                            'If Record exist update otherwise insert as new record
                            If AppleAppPartsEntry.Item(i).SERIAL = "Y" Then
                                dr2 = ds2.Tables(0).NewRow
                                newData = 1
                            Else
                                If ds2.Tables(0).Rows.Count = 1 Then
                                    dr2 = ds2.Tables(0).Rows(0)
                                    add = 1
                                Else
                                    dr2 = ds2.Tables(0).NewRow
                                    newData = 1
                                End If
                            End If
                            If newData = 1 Then
                                dr2("CRTDT") = dtNow
                                dr2("CRTCD") = queryParams.UserId
                                dr2("IN_STOCK") = AppleAppPartsEntry.Item(i).IN_STOCK
                                If AppleAppPartsEntry.Item(i).SERIAL = "Y" Then
                                    dr2("BALANCE") = AppleAppPartsEntry.Item(i).BALANCE
                                Else
                                    dr2("BALANCE") = dr2("BALANCE") + AppleAppPartsEntry.Item(i).IN_STOCK
                                End If
                            End If

                            If add = 1 Then
                                dr2("UPDDT") = dtNow
                                dr2("UPDCD") = queryParams.UserId
                                'dr2("IN_STOCK") = dr2("IN_STOCK") + AppleAppPartsEntry.Item(i).IN_STOCK 
                                dr2("IN_STOCK") = AppleAppPartsEntry.Item(i).IN_STOCK
                                dr2("BALANCE") = dr2("BALANCE") + AppleAppPartsEntry.Item(i).IN_STOCK
                            End If

                            'dr2("LAST_IN_DATE") = queryParams.INVENTORY_DATE

                            dr2("UPDPG") = "AppleAppPartsEntryControl.vb"
                            dr2("DELFG") = 0
                            dr2("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                            dr2("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH

                            dr2("PARTS_NO") = AppleAppPartsEntry.Item(i).PARTS_NO
                            dr2("PRODUCT_NAME") = AppleAppPartsEntry.Item(i).PARTS_NAME
                            dr2("PARTS_DETAIL") = AppleAppPartsEntry.Item(i).PARTS_DESCRIPTION
                            dr2("PARTS_TYPE") = AppleAppPartsEntry.Item(i).PARTS_TYPE
                            dr2("PURCHASE_COST") = AppleAppPartsEntry.Item(i).PARTS_COST
                            dr2("TIER") = AppleAppPartsEntry.Item(i).TIER
                            dr2("EEE_EEEE") = AppleAppPartsEntry.Item(i).EEE_EEEE
                            dr2("SERIAL_TYPE") = AppleAppPartsEntry.Item(i).SERIAL
                            dr2("SERIAL_NO") = AppleAppPartsEntry.Item(i).SERIAL_NO
                            'dr2("IN_STOCK") = AppleAppPartsEntry.Item(i).IN_STOCK

                            If newData = 1 Then
                                ds2.Tables(0).Rows.Add(dr2)
                            End If
                            Adapter2.Update(ds2)

                        Next i

                        'Update Stock Master Table
                        Dim strStockTran As String = ""
                        For i = 0 To AppleAppPartsEntry.Count - 1
                            Dim select_sql3 As String = ""
                            select_sql3 = "SELECT * FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN "
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
                            dr3("UPDPG") = "AppleAppPartsEntryControl.vb"
                            dr3("DELFG") = 0
                            dr3("SHIP_TO_BRANCH_CODE") = queryParams.SHIP_TO_BRANCH_CODE 'strShipCode ''csvData(i)(0)
                            dr3("SHIP_TO_BRANCH") = queryParams.SHIP_TO_BRANCH
                            dr3("PART_NO") = AppleAppPartsEntry.Item(i).PARTS_NO
                            dr3("DESCRIPTION") = AppleAppPartsEntry.Item(i).PARTS_DESCRIPTION
                            dr3("QUANTITY") = AppleAppPartsEntry.Item(i).IN_STOCK
                            'If ConsStockVal = "Consignment" Then
                            dr3("TRAN_TYPE") = "1" '1- Instock / 2-OutStock
                            dr3("STOCK_TYPE") = "2"
                            dr3("TRAN_REF") = queryParams.INVENTORY_NO
                            dr3("SERIAL_NO") = AppleAppPartsEntry.Item(i).SERIAL_NO
                            ds3.Tables(0).Rows.Add(dr3)
                            Adapter3.Update(ds3)
                        Next

                    End If
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
    Public Function SelectInventery(queryParams As AppleAppPartsInventoryModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim sqlStr As String = Nothing
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        If Not String.IsNullOrEmpty(queryParams.PARTS_TYPE) Then
            '1 consumtion, 2 parts
            If (queryParams.PARTS_TYPE = "Consignment") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY INVENTORY_NO) RowNumber, "
                sqlStr = sqlStr & "PARTS_NO,PARTS_NAME,PARTS_DESCRIPTION,PARTS_TYPE,PURCHASE_COST,TIER,EEE_EEEE,SERIAL_TYPE,SERIAL_NO,IN_STOCK,BALANCE,FORMAT(INVENTORY_DATE, 'yyyy/MM/dd') as INVENTORY_DATE "
                sqlStr = sqlStr & "FROM "
                sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_STOCK_ENTRY "
                sqlStr = sqlStr & "WHERE "
                sqlStr = sqlStr & "DELFG=0 "
                If Not String.IsNullOrEmpty(queryParams.INVENTORY_NO) Then
                    sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.INVENTORY_NO))
                End If
            End If
            If (queryParams.PARTS_TYPE = "Stock") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY INVENTORY_NO) RowNumber, "
                sqlStr = sqlStr & "PARTS_NO,PARTS_NAME,PARTS_DESCRIPTION,PARTS_TYPE,PURCHASE_COST,TIER,EEE_EEEE,SERIAL_TYPE,SERIAL_NO,IN_STOCK,BALANCE,FORMAT(INVENTORY_DATE, 'yyyy/MM/dd') as INVENTORY_DATE "
                sqlStr = sqlStr & "FROM "
                sqlStr = sqlStr & "AP_PARTS_STOCK_ENTRY "
                sqlStr = sqlStr & "WHERE "
                sqlStr = sqlStr & "DELFG=0 "
                If Not String.IsNullOrEmpty(queryParams.INVENTORY_NO) Then
                    sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.INVENTORY_NO))
                End If
            End If
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
    Public Function DeletePartsRow(queryParams As AppleAppPartsEntryModel) As Boolean
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim sqlStr As String = ""
        Dim flag As Boolean = True

        Dim dbConn As DBUtility = New DBUtility()
        '   dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        If Not String.IsNullOrEmpty(queryParams.PARTS_TYPE) Then
            '1 consumtion, 2 parts
            If (queryParams.PARTS_TYPE = "Consignment") Then
                sqlStr = "DELETE FROM AP_PARTS_CONSIGNMENT_STOCK_ENTRY "
                sqlStr = sqlStr & "WHERE INVENTORY_NO=@INVENTORY_NO "
                sqlStr = sqlStr & "AND SR_NO=@SR_NO "
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.INVENTORY_NO))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SR_NO", queryParams.SR_NO))
            End If
            If (queryParams.PARTS_TYPE = "Stock") Then
                sqlStr = "DELETE FROM AP_PARTS_STOCK_ENTRY "
                sqlStr = sqlStr & "WHERE INVENTORY_NO=@INVENTORY_NO "
                sqlStr = sqlStr & "AND SR_NO=@SR_NO "
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.INVENTORY_NO))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SR_NO", queryParams.SR_NO))
            End If
        End If

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.CloseConnection()
        Return flag
    End Function

    Public Function SelectConsignmentStock(queryParams As AppleAppPartsEntryModel) As DataTable
        'SELECT top 1 *,  ( SELECT SUM(CURRENT_IN_STOCK)     FROM AP_PARTS_STOCK WHERE DELFG=0   AND AP_PARTS.PARTS_NO = AP_PARTS_STOCK.PART_NO  ) AS BALANCE   FROM AP_PARTS WHERE DELFG=0 AND AP_PARTS.PARTS_NO = '' 
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "top 1 "
        sqlStr = sqlStr & "*  "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
            sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectStock(queryParams As AppleAppPartsEntryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = Nothing
        If Not String.IsNullOrEmpty(queryParams.PARTS_TYPE) Then
            '1 consumtion, 2 parts
            If (queryParams.PARTS_TYPE = "1") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "top 1 "
                sqlStr = sqlStr & "BALANCE "
                sqlStr = sqlStr & "FROM "
                sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_MST "
                sqlStr = sqlStr & "WHERE "
                sqlStr = sqlStr & "DELFG=0 "
                If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
                    sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
                End If
            End If
            If (queryParams.PARTS_TYPE = "2") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "top 1 "
                sqlStr = sqlStr & "BALANCE "
                sqlStr = sqlStr & "FROM "
                sqlStr = sqlStr & "AP_PARTS_STOCK_MST "
                sqlStr = sqlStr & "WHERE "
                sqlStr = sqlStr & "DELFG=0 "
                If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
                    sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
                End If
            End If
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectSerialExistCons(queryParams As AppleAppPartsEntryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = Nothing
        'If Not String.IsNullOrEmpty(queryParams.PARTS_TYPE) Then
        '1 consumtion, 2 parts
        'If (queryParams.PARTS_TYPE = "1") Then
        sqlStr = "SELECT "
        'sqlStr = sqlStr & "top 1 "
        sqlStr = sqlStr & "Consmst.PARTS_NO,Consmst.SERIAL_NO, ConsEntry.INVENTORY_NO FROM AP_PARTS_CONSIGNMENT_MST as Consmst INNER JOIN "
        sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_STOCK_ENTRY as ConsEntry ON Consmst.SERIAL_NO=ConsEntry.SERIAL_NO "
        'sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_MST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "Consmst.DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
            sqlStr = sqlStr & "AND Consmst.PARTS_NO = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.SERIAL_NO) Then
            sqlStr = sqlStr & "AND Consmst.SERIAL_NO = @SERIAL_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))
        End If

        If Not String.IsNullOrEmpty(queryParams.SERIAL) Then
            sqlStr = sqlStr & "AND ConsEntry.SERIAL_TYPE = @SERIAL_TYPE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_TYPE", queryParams.SERIAL))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectSerialExistStock(queryParams As AppleAppPartsEntryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = Nothing

        'sqlStr = "SELECT "
        'sqlStr = sqlStr & "top 1 "
        'sqlStr = sqlStr & "* "
        'sqlStr = sqlStr & "FROM "
        'sqlStr = sqlStr & "AP_PARTS_STOCK_MST "
        'sqlStr = sqlStr & "WHERE "
        'sqlStr = sqlStr & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        'End If
        'If Not String.IsNullOrEmpty(queryParams.SERIAL_NO) Then
        '    sqlStr = sqlStr & "AND SERIAL_NO = @SERIAL_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))
        'End If
        sqlStr = "SELECT "
        'sqlStr = sqlStr & "top 1 "
        sqlStr = sqlStr & "stockmst.PARTS_NO,stockmst.SERIAL_NO, stockEntry.INVENTORY_NO FROM AP_PARTS_STOCK_MST as stockmst "
        sqlStr = sqlStr & "INNER JOIN AP_PARTS_STOCK_ENTRY as stockEntry ON stockmst.SERIAL_NO=stockEntry.SERIAL_NO "
        'sqlStr = sqlStr & "AP_PARTS_STOCK_MST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "stockmst.DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
            sqlStr = sqlStr & "AND stockmst.PARTS_NO = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.SERIAL_NO) Then
            sqlStr = sqlStr & "AND stockmst.SERIAL_NO = @SERIAL_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))
        End If

        If Not String.IsNullOrEmpty(queryParams.SERIAL) Then
            sqlStr = sqlStr & "AND stockEntry.SERIAL_TYPE = @SERIAL_TYPE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_TYPE", queryParams.SERIAL))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectStockExist(queryParams As AppleAppPartsEntryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = Nothing
        If Not String.IsNullOrEmpty(queryParams.PARTS_TYPE) Then
            '1 consumtion, 2 parts
            If (queryParams.PARTS_TYPE = "1") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "top 1 "
                sqlStr = sqlStr & "* "
                sqlStr = sqlStr & "FROM "
                sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_MST "
                sqlStr = sqlStr & "WHERE "
                sqlStr = sqlStr & "DELFG=0 "
                If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
                    sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
                End If
                If Not String.IsNullOrEmpty(queryParams.SERIAL) Then
                    sqlStr = sqlStr & "AND SERIAL_TYPE = @SERIAL_TYPE "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_TYPE", queryParams.SERIAL))
                End If
            End If
            If (queryParams.PARTS_TYPE = "2") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "top 1 "
                sqlStr = sqlStr & "* "
                sqlStr = sqlStr & "FROM "
                sqlStr = sqlStr & "AP_PARTS_STOCK_MST "
                sqlStr = sqlStr & "WHERE "
                sqlStr = sqlStr & "DELFG=0 "
                If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
                    sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
                End If
                If Not String.IsNullOrEmpty(queryParams.SERIAL) Then
                    sqlStr = sqlStr & "AND SERIAL_TYPE = @SERIAL_TYPE "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_TYPE", queryParams.SERIAL))
                End If
            End If
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
End Class
