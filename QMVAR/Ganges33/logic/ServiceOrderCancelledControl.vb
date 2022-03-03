Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient

Public Class ServiceOrderCancelledControl


    Public Function AddModifyServiceOrderCancelledControl(ByVal csvData()() As String, queryParams As ServiceOrderCancelledModel) As Boolean
        ' Row 0 - Header 1
        '0 ServiceOrderNo
        '1 AscJobNo
        '2 AscCode
        '3 Created
        '4 Assigned 
        '5 Model
        '6 Serial
        '7 WtyStatus
        '8 Voc
        '9 CustomerName
        '10 City
        '11 AppDate
        '12 ServiceType
        '13 StatusD
        '14 Reason
        '15 B2b 


        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Return Status 
        Dim flag As Boolean = False
        'Ship Code
        Dim strShipCode As String = ""
        Try
            'Reading ShipCode from database to Datatable 
            Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
            Dim dtShipCode As DataTable = _ShipBaseControl.SelectBranchCode()

            Dim blShipCodeExist As Boolean = False
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
                For i = 0 To csvData.Length - 1
                    If i <> 0 And csvData(i)(0) <> "" Then

                        'blShipCodeExist = False
                        '''Ship Code
                        'strShipCode = CommonControl.ConvertShipCode(csvData(i)(0))
                        'blShipCodeExist = CommonControl.CheckDataTable(dtShipCode, Function(x) x("ship_code") = strShipCode)

                        'If blShipCodeExist = False Then
                        '    Log4NetControl.ComErrorLogWrite(strShipCode & " is not exist")
                        '    flag = False
                        '    trn.Rollback()
                        '    Return flag
                        '    Exit Function
                        'End If

                        'Bydefault Assing Zero
                        add = 0
                        newData = 0
                        'Query 
                        'If Record is exit then it will update otherwise it will create new records
                        Dim select_sql1 As String = ""
                        select_sql1 = "SELECT * FROM SERVICE_ORDER_CANCELLED WHERE DELFG = 0 "
                        select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & queryParams.ShipToBranchCode & "' "
                        select_sql1 &= "AND SERVICE_ORDER_NO = '" & csvData(i)(0) & "' "
                        select_sql1 &= "AND ASC_JOB_NO = '" & csvData(i)(1) & "' "

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
                            dr1("UPDDT") = dtNow
                            dr1("UPDCD") = queryParams.UserId
                        End If

                        If add = 1 Then
                            dr1("UPDDT") = dtNow
                            dr1("UPDCD") = queryParams.UserId
                        End If


                        dr1("UPDPG") = "ServiceOrderCancelledControl.vb"
                        dr1("DELFG") = 0
                        dr1("UPLOAD_USER") = queryParams.UploadUser
                        dr1("UPLOAD_DATE") = dtNow

                        dr1("SHIP_TO_BRANCH_CODE") = queryParams.ShipToBranchCode ''csvData(i)(0)
                        dr1("SHIP_TO_BRANCH") = queryParams.ShipToBranch

                        'strDate = Left(csvData(i)(2), 4) & "/" & Mid(csvData(i)(2), 5, 2) & "/" & Right(csvData(i)(2), 2)

                        dr1("SERVICE_ORDER_NO") = csvData(i)(0)
                        dr1("ASC_JOB_NO") = csvData(i)(1)
                        dr1("CREATED") = csvData(i)(2)
                        dr1("ASSIGNED") = csvData(i)(3)
                        dr1("MODEL") = csvData(i)(4)
                        dr1("SERIAL") = csvData(i)(5)
                        dr1("WTY_STATUS") = csvData(i)(6)
                        dr1("VOC") = csvData(i)(7)
                        dr1("CUSTOMER_NAME") = csvData(i)(8)
                        dr1("CITY") = csvData(i)(9)
                        dr1("APP_DATE") = csvData(i)(10)
                        dr1("SERVICE_TYPE") = csvData(i)(11)
                        dr1("STATUS") = csvData(i)(12)
                        dr1("REASON") = csvData(i)(13)
                        dr1("B2B") = csvData(i)(14)


                        dr1("FILE_NAME") = queryParams.FileName
                        dr1("SRC_FILE_NAME") = queryParams.SrcFileName

                        If newData = 1 Then
                            ds1.Tables(0).Rows.Add(dr1)
                        End If
                        Adapter1.Update(ds1)
                    End If
                Next i

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



    Public Function SelectServiceOrderCancelled(ByVal queryParams As ServiceOrderCancelledModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & "DELFG,UPLOAD_USER,UPLOAD_DATE,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,INVOICE_DATE,INVOICE_NO,LOCAL_INVOICE_NO,DELIVERY_NO,ITEMS,AMOUNT,SGST_UTGST,CGST,IGST,CESS,TAX,TOTAL,GR_STATUS,FILE_NAME "
        sqlStr = sqlStr & "SERVICE_ORDER_NO,ASC_JOB_NO,CREATED,ASSIGNED,MODEL,SERIAL,WTY_STATUS,VOC,CUSTOMER_NAME,CITY,APP_DATE,SERVICE_TYPE,STATUS,REASON,B2B "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "SERVICE_ORDER_CANCELLED "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.ShipToBranch) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ShipToBranchCode))
        End If



        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) <= @DateTo "
            'sqlStr = sqlStr & "AND INVOICE_DATE >= @DateFrom and INVOICE_DATE <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateFrom "
            sqlStr = sqlStr & "AND UPDDT = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND UPDDT = @DateTo "
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
End Class
