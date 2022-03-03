Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic

Public Class SonyDailyReceivesetControl
    Public Function AddModifyDailyReceiveset(ByVal csvData()() As String, queryParams As SonyDailyReceivesetModel) As Boolean
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Mandatory Column 39 from CSV
        Dim flag As Boolean = True
        If csvData(0).Length < 29 Then
            Return False
        End If

        '       Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn
        '       Dim flag As Boolean = True
        Dim flagAll As Boolean = True
        Dim sqlStr As String = ""
        Dim dtSawDiscountExist As DataTable

        Dim isExist As Integer = 0
        Dim COUNTRY As String = ""
        Dim REGION As String = ""
        Dim ASC_NAME As String = ""
        Dim ASC_CODE As String = ""
        Dim JOB_NUMBER As String = ""
        Dim MODEL_CODE As String = ""
        Dim MODEL_NAME As String = ""
        Dim SERIAL_NUMBER As String = ""
        Dim D4D_CODE As String = ""
        Dim D4D_DESC As String = ""
        Dim D6D_CODE As String = ""
        Dim PRODUCT_CATEGORY As String = ""
        Dim PRODUCT_SUB_CATEGORY As String = ""
        Dim BOOKED_IN_DATE As String = ""
        Dim TECHNICIAN As String = ""
        Dim WARRANTY_TYPE As String = ""
        Dim CR90 As String = ""
        Dim REPAIR_FLAG As String = ""
        Dim REPAIR_STATUS As String = ""
        Dim REPAIR_COMPLETED_DATE As String = ""
        Dim ESTIMATED_REPAIR_DATE As String = ""
        Dim CUSTOMER_NAME As String = ""
        Dim CONTACT_PERSON As String = ""
        Dim ST_TYPE As String = ""
        Dim CUSTOMER_GROUP As String = ""
        Dim SERVICE_TYPE As String = ""
        Dim TRANSFER_FLAG As String = ""
        Dim TRANSFER_REPAIRNO_OUT As String = ""
        Dim TRANSFER_REPAIRNO_IN As String = ""
        '1st check PARTS_NO
        sqlStr = "SELECT TOP 1 COUNTRY FROM SONY_DAILY_RECEIVESET "
        sqlStr = sqlStr & " WHERE DELFG = 0 AND SRC_FILE_NAME='" & queryParams.SRC_FILE_NAME & "'"
        'sqlStr = sqlStr & " AND SHIP_TO_BRANCH_CODE='" & queryParams.ShipToBranchCode & "'"
        dtSawDiscountExist = dbConn.GetDataSet(sqlStr)
        'if exist then need to update delfg=1 then insert the record as new
        If (dtSawDiscountExist Is Nothing) Or (dtSawDiscountExist.Rows.Count = 0) Then
            'isExist = 0
        Else 'The records is already exist, need to update DELFg=0
            ' isExist = 1
            sqlStr = "UPDATE SONY_DAILY_RECEIVESET SET DELFG=1  "
            sqlStr = sqlStr & "WHERE DELFG=0 "
            sqlStr = sqlStr & "AND SRC_FILE_NAME = @SRC_FILE_NAME"
            'sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SRC_FILE_NAME))
            flag = dbConn.ExecSQL(sqlStr)
            dbConn.sqlCmd.Parameters.Clear()
            'If Error occurs then will store the flag as false
            If Not flag Then
                flagAll = False
            End If
        End If
        Dim intColCount As Integer = 0
        For i = 0 To csvData.Length - 1
            If i > 0 Then '0  Header


                intColCount = csvData(i).Length
                If intColCount = 29 Then
                    COUNTRY = csvData(i)(0)
                    REGION = csvData(i)(1)
                    ASC_NAME = csvData(i)(2)
                    ASC_CODE = csvData(i)(3)
                    JOB_NUMBER = csvData(i)(4)
                    MODEL_CODE = csvData(i)(5)
                    MODEL_NAME = csvData(i)(6)
                    SERIAL_NUMBER = csvData(i)(7)
                    D4D_CODE = csvData(i)(8)
                    D4D_DESC = csvData(i)(9)
                    D6D_CODE = csvData(i)(10)
                    PRODUCT_CATEGORY = csvData(i)(11)
                    PRODUCT_SUB_CATEGORY = csvData(i)(12)
                    BOOKED_IN_DATE = csvData(i)(13)
                    TECHNICIAN = csvData(i)(14)
                    WARRANTY_TYPE = csvData(i)(15)
                    CR90 = csvData(i)(16)
                    REPAIR_FLAG = csvData(i)(17)
                    REPAIR_STATUS = csvData(i)(18)
                    REPAIR_COMPLETED_DATE = csvData(i)(19)
                    ESTIMATED_REPAIR_DATE = csvData(i)(20)
                    CUSTOMER_NAME = csvData(i)(21)
                    CONTACT_PERSON = csvData(i)(22)
                    ST_TYPE = csvData(i)(23)
                    CUSTOMER_GROUP = csvData(i)(24)
                    SERVICE_TYPE = csvData(i)(25)
                    TRANSFER_FLAG = csvData(i)(26)
                    TRANSFER_REPAIRNO_OUT = csvData(i)(27)
                    TRANSFER_REPAIRNO_IN = csvData(i)(28)

                ElseIf intColCount = 25 Then
                    COUNTRY = csvData(i)(0)
                    REGION = csvData(i)(1)
                    ASC_NAME = csvData(i)(2)
                    ASC_CODE = csvData(i)(3)
                    JOB_NUMBER = csvData(i)(4)
                    MODEL_CODE = csvData(i)(5)
                    MODEL_NAME = csvData(i)(6)
                    SERIAL_NUMBER = csvData(i)(7)
                    D4D_CODE = ""
                    D4D_DESC = ""
                    D6D_CODE = ""
                    PRODUCT_CATEGORY = ""
                    PRODUCT_SUB_CATEGORY = ""
                    BOOKED_IN_DATE = csvData(i)(9)
                    TECHNICIAN = csvData(i)(10)
                    WARRANTY_TYPE = csvData(i)(11)
                    CR90 = csvData(i)(12)
                    REPAIR_FLAG = csvData(i)(13)
                    REPAIR_STATUS = csvData(i)(14)
                    REPAIR_COMPLETED_DATE = csvData(i)(15)
                    ESTIMATED_REPAIR_DATE = csvData(i)(16)
                    CUSTOMER_NAME = csvData(i)(17)
                    CONTACT_PERSON = csvData(i)(18)
                    ST_TYPE = csvData(i)(19)
                    CUSTOMER_GROUP = csvData(i)(20)
                    SERVICE_TYPE = csvData(i)(21)
                    TRANSFER_FLAG = csvData(i)(22)
                    TRANSFER_REPAIRNO_OUT = csvData(i)(23)
                    TRANSFER_REPAIRNO_IN = csvData(i)(24)
                    'SERVICE_TYPE = csvData(i)(25)
                    'TRANSFER_FLAG = csvData(i)(26)
                    'TRANSFER_REPAIRNO_OUT = csvData(i)(27)
                    'TRANSFER_REPAIRNO_IN = csvData(i)(28)

                End If

                'If isExist = 1 Then
                sqlStr = "Insert into SONY_DAILY_RECEIVESET ("
                sqlStr = sqlStr & "CRTDT, "
                sqlStr = sqlStr & "CRTCD, "
                ' sqlStr = sqlStr & "UPDDT, "
                sqlStr = sqlStr & "UPDCD, "
                sqlStr = sqlStr & "UPDPG, "
                sqlStr = sqlStr & "DELFG, "
                '             sqlStr = sqlStr & "UNQ_NO, "
                sqlStr = sqlStr & "UPLOAD_USER, "
                sqlStr = sqlStr & "UPLOAD_DATE, "
                sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
                sqlStr = sqlStr & "SHIP_TO_BRANCH, "


                sqlStr = sqlStr & "COUNTRY, "
                sqlStr = sqlStr & "REGION, "
                sqlStr = sqlStr & "ASC_NAME, "
                sqlStr = sqlStr & "ASC_CODE, "
                sqlStr = sqlStr & "JOB_NUMBER, "
                sqlStr = sqlStr & "MODEL_CODE, "
                sqlStr = sqlStr & "MODEL_NAME, "
                sqlStr = sqlStr & "SERIAL_NUMBER, "
                sqlStr = sqlStr & "D4D_CODE, "
                sqlStr = sqlStr & "D4D_DESC, "
                sqlStr = sqlStr & "D6D_CODE, "
                sqlStr = sqlStr & "PRODUCT_CATEGORY, "
                sqlStr = sqlStr & "PRODUCT_SUB_CATEGORY, "
                sqlStr = sqlStr & "BOOKED_IN_DATE, "
                sqlStr = sqlStr & "TECHNICIAN, "
                sqlStr = sqlStr & "WARRANTY_TYPE, "
                sqlStr = sqlStr & "CR90, "
                sqlStr = sqlStr & "REPAIR_FLAG, "
                sqlStr = sqlStr & "REPAIR_STATUS, "
                sqlStr = sqlStr & "REPAIR_COMPLETED_DATE, "
                sqlStr = sqlStr & "ESTIMATED_REPAIR_DATE, "
                sqlStr = sqlStr & "CUSTOMER_NAME, "
                sqlStr = sqlStr & "CONTACT_PERSON, "
                sqlStr = sqlStr & "ST_TYPE, "
                sqlStr = sqlStr & "CUSTOMER_GROUP, "
                sqlStr = sqlStr & "SERVICE_TYPE, "
                sqlStr = sqlStr & "TRANSFER_FLAG, "
                sqlStr = sqlStr & "TRANSFER_REPAIRNO_OUT, "
                sqlStr = sqlStr & "TRANSFER_REPAIRNO_IN, "






                sqlStr = sqlStr & "FILE_NAME, "
                sqlStr = sqlStr & "SRC_FILE_NAME "
                sqlStr = sqlStr & " ) "
                sqlStr = sqlStr & " values ( "
                sqlStr = sqlStr & "@CRTDT, "
                sqlStr = sqlStr & "@CRTCD, "
                'sqlStr = sqlStr & "@UPDDT, "
                sqlStr = sqlStr & "@UPDCD, "
                sqlStr = sqlStr & "@UPDPG, "
                sqlStr = sqlStr & "@DELFG, "
                '              sqlStr = sqlStr & " (select max(UNQ_NO)+1 from SAW_DISCOUNT) , "
                sqlStr = sqlStr & "@UPLOAD_USER, "
                sqlStr = sqlStr & "@UPLOAD_DATE, "
                sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
                sqlStr = sqlStr & "@SHIP_TO_BRANCH, "



                sqlStr = sqlStr & "@COUNTRY, "
                sqlStr = sqlStr & "@REGION, "
                sqlStr = sqlStr & "@ASC_NAME, "
                sqlStr = sqlStr & "@ASC_CODE, "
                sqlStr = sqlStr & "@JOB_NUMBER, "
                sqlStr = sqlStr & "@MODEL_CODE, "
                sqlStr = sqlStr & "@MODEL_NAME, "
                sqlStr = sqlStr & "@SERIAL_NUMBER, "
                sqlStr = sqlStr & "@D4D_CODE, "
                sqlStr = sqlStr & "@D4D_DESC, "
                sqlStr = sqlStr & "@D6D_CODE, "
                sqlStr = sqlStr & "@PRODUCT_CATEGORY, "
                sqlStr = sqlStr & "@PRODUCT_SUB_CATEGORY, "
                sqlStr = sqlStr & "@BOOKED_IN_DATE, "
                sqlStr = sqlStr & "@TECHNICIAN, "
                sqlStr = sqlStr & "@WARRANTY_TYPE, "
                sqlStr = sqlStr & "@CR90, "
                sqlStr = sqlStr & "@REPAIR_FLAG, "
                sqlStr = sqlStr & "@REPAIR_STATUS, "
                sqlStr = sqlStr & "@REPAIR_COMPLETED_DATE, "
                sqlStr = sqlStr & "@ESTIMATED_REPAIR_DATE, "
                sqlStr = sqlStr & "@CUSTOMER_NAME, "
                sqlStr = sqlStr & "@CONTACT_PERSON, "
                sqlStr = sqlStr & "@ST_TYPE, "
                sqlStr = sqlStr & "@CUSTOMER_GROUP, "
                sqlStr = sqlStr & "@SERVICE_TYPE, "
                sqlStr = sqlStr & "@TRANSFER_FLAG, "
                sqlStr = sqlStr & "@TRANSFER_REPAIRNO_OUT, "
                sqlStr = sqlStr & "@TRANSFER_REPAIRNO_IN, "


                sqlStr = sqlStr & "@FILE_NAME, "
                sqlStr = sqlStr & "@SRC_FILE_NAME "
                sqlStr = sqlStr & " )"
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", "")) '?????????????????????????
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_USER", queryParams.UPLOAD_USER))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_DATE", dtNow))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))

                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COUNTRY", COUNTRY)) 'csvData(i)(0)
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REGION", REGION)) 'csvData(i)(1)
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ASC_NAME", ASC_NAME)) 'csvData(i)(2)
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ASC_CODE", ASC_CODE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@JOB_NUMBER", JOB_NUMBER))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MODEL_CODE", MODEL_CODE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MODEL_NAME", MODEL_NAME))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NUMBER", SERIAL_NUMBER))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@D4D_CODE", D4D_CODE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@D4D_DESC", D4D_DESC))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@D6D_CODE", D6D_CODE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_CATEGORY", PRODUCT_CATEGORY))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_SUB_CATEGORY", PRODUCT_SUB_CATEGORY))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BOOKED_IN_DATE", BOOKED_IN_DATE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TECHNICIAN", TECHNICIAN))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@WARRANTY_TYPE", WARRANTY_TYPE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CR90", CR90))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REPAIR_FLAG", REPAIR_FLAG))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REPAIR_STATUS", REPAIR_STATUS))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REPAIR_COMPLETED_DATE", REPAIR_COMPLETED_DATE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ESTIMATED_REPAIR_DATE", ESTIMATED_REPAIR_DATE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_NAME", CUSTOMER_NAME))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CONTACT_PERSON", CONTACT_PERSON))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ST_TYPE", ST_TYPE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_GROUP", CUSTOMER_GROUP)) 'csvData(i)(24)
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERVICE_TYPE", SERVICE_TYPE)) 'csvData(i)(25)
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRANSFER_FLAG", TRANSFER_FLAG)) 'csvData(i)(26)
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRANSFER_REPAIRNO_OUT", TRANSFER_REPAIRNO_OUT)) 'csvData(i)(27)
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRANSFER_REPAIRNO_IN", TRANSFER_REPAIRNO_IN)) 'csvData(i)(28)



                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FILE_NAME", queryParams.FILE_NAME))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SRC_FILE_NAME))

                flag = dbConn.ExecSQL(sqlStr)
                dbConn.sqlCmd.Parameters.Clear()
                'If Error occurs then will store the flag as false
                If Not flag Then
                    flagAll = False
                    Exit For
                End If
                'End If
            End If 'Other than header - End
        Next
        If flagAll Then
            flag = True
            dbConn.sqlTrn.Commit()
        Else
            flag = False
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()
        Return flag
    End Function


    Public Function SelectDailyReceiveset(ByVal queryParams As SonyDailyReceivesetModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "COUNTRY as 'Country', "
        sqlStr = sqlStr & "REGION as 'Region', "
        sqlStr = sqlStr & "ASC_NAME as 'ASC Name', "
        sqlStr = sqlStr & "ASC_CODE as'ASC Code', "
        sqlStr = sqlStr & "JOB_NUMBER as 'Job Number', "
        sqlStr = sqlStr & "MODEL_CODE as 'Model Code', "
        sqlStr = sqlStr & "MODEL_NAME as 'Model Name', "
        sqlStr = sqlStr & "SERIAL_NUMBER as 'Serial Number', "
        sqlStr = sqlStr & "D4D_CODE as '4D Code', "
        sqlStr = sqlStr & "D4D_DESC as '4D Desc', "
        sqlStr = sqlStr & "D6D_CODE as '6D Code', "
        sqlStr = sqlStr & "PRODUCT_CATEGORY as 'Prod Category', "
        sqlStr = sqlStr & "PRODUCT_SUB_CATEGORY as 'Product Sub Cat', "
        sqlStr = sqlStr & "BOOKED_IN_DATE as 'Booked In Date', "
        sqlStr = sqlStr & "TECHNICIAN as 'Technician', "
        sqlStr = sqlStr & "WARRANTY_TYPE as 'Warranty Type', "
        sqlStr = sqlStr & "CR90 as 'CR90', "
        sqlStr = sqlStr & "REPAIR_FLAG as 'Repair Flag', "
        sqlStr = sqlStr & "REPAIR_STATUS as 'Repair Status', "
        sqlStr = sqlStr & "REPAIR_COMPLETED_DATE as 'Repair Completed Date', "
        sqlStr = sqlStr & "ESTIMATED_REPAIR_DATE as 'Estimated Repair Date', "
        sqlStr = sqlStr & "CUSTOMER_NAME as 'Customer Name', "
        sqlStr = sqlStr & "CONTACT_PERSON as 'Contact Person', "
        sqlStr = sqlStr & "ST_TYPE as 'st_type', "
        sqlStr = sqlStr & "CUSTOMER_GROUP as 'Customer Group', "
        sqlStr = sqlStr & "SERVICE_TYPE as 'Service Type', "
        sqlStr = sqlStr & "TRANSFER_FLAG as 'Transfer Flag', "
        sqlStr = sqlStr & "TRANSFER_REPAIRNO_OUT as 'Transfer Repair No(Out)', "
        sqlStr = sqlStr & "TRANSFER_REPAIRNO_IN as 'Transfer Repair No (In)' "




        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "SONY_DAILY_RECEIVESET "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If

        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH = @SHIP_TO_BRANCH "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        End If

        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) <= @DateTo "
            'sqlStr = sqlStr & "AND INVOICE_DATE >= @DateFrom and INVOICE_DATE <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateFrom "
            sqlStr = sqlStr & "AND CRTDT = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND CRTDT = @DateTo "
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


End Class

