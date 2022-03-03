Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient

Public Class AppleRcptControl
    'Public Function SelectRcptModel(ByVal queryParams As AppleRcptModel) As DataTable
    '    Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
    '    Dim dbConn As DBUtility = New DBUtility()
    '    Dim sqlStr As String = "SELECT  "
    '    sqlStr = sqlStr & "MODEL "
    '    ' sqlStr = sqlStr & "claim_no, "
    '    sqlStr = sqlStr & "from "
    '    sqlStr = sqlStr & "AP_RCPT_MODEL "
    '    sqlStr = sqlStr & "WHERE "
    '    sqlStr = sqlStr & "DELFG=0 "
    '    'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
    '    '    sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
    '    '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
    '    'End If
    '    'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
    '    '    sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
    '    '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
    '    'End If
    '    Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
    '    dbConn.CloseConnection()
    '    Return _DataTable
    'End Function

    Public Function SelectRcpt(ByVal queryParams As AppleRcptModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT  "
        sqlStr = sqlStr & "MODEL +'( ' + TYPE +' )' AS MODEL, "
        sqlStr = sqlStr & "UNQ_NO "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_RCPT_MODEL "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        'End If
        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        'End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function SelectRcptType(ByVal queryParams As AppleRcptModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT  "
        sqlStr = sqlStr & "DISTINCT TYPE "
        'sqlStr = sqlStr & "UNQ_NO "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_RCPT_MODEL "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        'End If
        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        'End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function





    Public Function SelectRcptModel(ByVal queryParams As AppleRcptModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT  "
        sqlStr = sqlStr & "DISTINCT MODEL, "
        sqlStr = sqlStr & "UNQ_NO "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_RCPT_MODEL "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.TYPE) Then
            sqlStr = sqlStr & "AND TYPE = @TYPE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TYPE", queryParams.TYPE))
        End If
        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        'End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function SelectModel(ByVal queryParams As AppleRcptModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT  "
        sqlStr = sqlStr & "MODEL, "
        sqlStr = sqlStr & "TYPE, "
        sqlStr = sqlStr & "DELFG, "
        sqlStr = sqlStr & "UNQ_NO "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_RCPT_MODEL "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.MODEL) Then
            sqlStr = sqlStr & "AND MODEL = @MODEL "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MODEL", queryParams.MODEL))
        End If
        If Not String.IsNullOrEmpty(queryParams.TYPE) Then
            sqlStr = sqlStr & "AND TYPE = @TYPE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TYPE", queryParams.TYPE))
        End If
        If Not String.IsNullOrEmpty(queryParams.UNQ_NO) Then
            sqlStr = sqlStr & "AND UNQ_NO = @UNQ_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectTokenList(ByVal queryParams As AppleRcptModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & " * "
        'sqlStr = sqlStr & "PO_NO  as PO_NO_1, "
        'sqlStr = sqlStr & "PO_NO, "
        'sqlStr = sqlStr & "G_NO, "
        'sqlStr = sqlStr & "CUSTOMER_NAME, "
        ' sqlStr = sqlStr & "(case when COMP_STATUS = 1 then CASE WHEN DELIVERY_DATE='' then 'Complete' WHEN DELIVERY_DATE<>'' then 'Handed Over' end  when COMP_STATUS = 2 then 'Reception only'  when COMP_STATUS = 0 then 'Incomplete' when COMP_STATUS = null then 'Incomplete' end) COMP_STATUS, "
        'sqlStr = sqlStr & "SERIAL_NO, "
        'sqlStr = sqlStr & "PRODUCT_NAME, "
        'sqlStr = sqlStr & "part_no1, "
        'sqlStr = sqlStr & "DELIVERY_DATE, "
        'sqlStr = sqlStr & "LEFT(CONVERT(VARCHAR, PO_DATE, 111), 10) as PO_DATE, "
        'sqlStr = sqlStr & "PO_NO,PO_DATE,G_NO,CUSTOMER_NAME,ZIP_CODE,MOBLIE_PHONE,TELEPHONE,ADD_1,ADD_2,CITY,STATE,STATE_CODE,E_MAIL,IS_SHIP_DIFF,CUSTOMER_NAME_SHIP,ZIP_CODE_SHIP,MOBLIE_PHONE_SHIP,TELEPHONE_SHIP,ADD_1_SHIP,ADD_2_SHIP,CITY_SHIP,STATE_SHIP,STATE_CODE_SHIP,E_MAIL_SHIP,MODEL_NAME,PRODUCT_NAME,SERIAL_NO,IMEI_1,IMEI_2,DATE_OF_PURCHASE,SERVICE_TYPE,COMPTIA,COMPTIA_MODIFIER,PART_NO1,PART_NO2,PART_NO3,PART_NO4,PART_DETAIL_1,PART_DETAIL_2,PART_DETAIL_3,PART_DETAIL_4,PART_QTY_1,PART_QTY_2,PART_QTY_3,PART_QTY_4,PART_DISCOUNT_1,PART_DISCOUNT_2,PART_DISCOUNT_3,PART_DISCOUNT_4,LABOR_AMOUNT,LABOR_DETAIL,LABOR_COST,LABOR_DISCOUNT,LABOR_SALES,LABOR_SGST,LABOR_CGST,LABOR_IGST,LABOR_TOTAL,PART_COST_1,PART_COST_2,PART_COST_3,PART_COST_4,PART_COST_SALES_1,PART_COST_SALES_2,PART_COST_SALES_3,PART_COST_SALES_4,PART1_TAX,PART2_TAX,PART3_TAX,PART4_TAX,LABOUR_TAX,OTHER_TAX,PART_SGST_1,PART_SGST_2,PART_SGST_3,PART_SGST_4,PART_CGST_1,PART_CGST_2,PART_CGST_3,PART_CGST_4,PART_IGST_1,PART_IGST_2,PART_IGST_3,PART_IGST_4,PART_TOTAL_1,PART_TOTAL_2,PART_TOTAL_3,PART_TOTAL_4,PART_QTY_AMOUNT,PART_COST_AMOUNT,PART_SALES_AMOUNT,PART_DISCOUNT_AMOUNT,PART_SGST_AMOUNT,PART_CGST_AMOUNT,PART_IGST_AMOUNT,PART_TOTAL,OTHER_QTY_AMOUNT,OTHER_DETAIL,OTHER_COST,OTHER_DISCOUNT,OTHER_SALES,OTHER_SGST,OTHER_CGST,OTHER_IGST,OTHER_TOTAL,TOTAL_QTY,TOTAL_COST_AMOUNT,TOTAL_DISCOUNT_AMOUNT,TOTAL_SALES_AMOUNT,TOTAL_SGST_AMOUNT,TOTAL_CGST_AMOUNT,TOTAL_IGST_AMOUNT,TOTAL_AMOUNT,DELIVERY_DATE,COMP_STATUS,COMP_DATE,DENOMINATION,ESTIMATE_DATE,ESTIMATE_TIME,GSX_CLOSE_DATE,USE_SERVICE_TYPE,INVOICE_NOTE,GSX_NOTE,HSN_SAC_CODE,GSTIN,IP_ADDRESS,FILE_NAME,SRC_FILE_NAME,PART_HSN_ASC_1,PART_HSN_ASC_2,PART_HSN_ASC_3,PART_HSN_ASC_4,PRICE_OPTIONS_1,PRICE_OPTIONS_2,PRICE_OPTIONS_3,PRICE_OPTIONS_4,ADVANCE_PAYMENT,INVOICE_NO,INVOICE_DATE "

        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_RCPT_WAIT_LIST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & " AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If

        If Not String.IsNullOrEmpty(queryParams.NAME) Then
            sqlStr = sqlStr & " AND NAME like '%' + @NAME + '%'"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@NAME", queryParams.NAME))
        End If
        If Not String.IsNullOrEmpty(queryParams.MOBILE) Then
            sqlStr = sqlStr & " AND MOBILE = @MOBILE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MOBILE", queryParams.MOBILE))
        End If
        If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
            sqlStr = sqlStr & " AND PO_NO = @PO_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        End If
        'If Not String.IsNullOrEmpty(queryParams.PRODUCT_NAME) Then
        '    sqlStr = sqlStr & " AND PRODUCT_NAME like '%' + @PRODUCT_NAME + '%' "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.PRODUCT_NAME))
        'End If
        If Not String.IsNullOrEmpty(queryParams.STATUS) Then
            If UCase(queryParams.STATUS) <> "ALL" Then
                sqlStr = sqlStr & "AND STATUS = @STATUS "
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
            End If
        End If
            'If Not ((String.IsNullOrEmpty(queryParams.DateFrom)) And (String.IsNullOrEmpty(queryParams.DateTo))) Then
            '    sqlStr = sqlStr & " AND DELIVERY_DATE between @DateFrom and @DateTo"
            '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
            'End If

            If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If

        'If Not String.IsNullOrEmpty(queryParams.TELEPHONE) Then
        '    sqlStr = sqlStr & " AND telephone = @telephone "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@telephone", queryParams.TELEPHONE))
        'End If
        'If Not String.IsNullOrEmpty(queryParams.PART_NO1) Then
        '    sqlStr = sqlStr & " AND PART_NO1 = @PART_NO1 "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO1", queryParams.PART_NO1))
        'End If

        'If Not String.IsNullOrEmpty(queryParams.COMP_STATUS) Then
        '    If (queryParams.COMP_STATUS = "Complete") Then
        '        sqlStr = sqlStr & " AND COMP_STATUS = 1 AND DELIVERY_DATE = '' "
        '    ElseIf (queryParams.COMP_STATUS = "Handed over") Then
        '        sqlStr = sqlStr & " AND COMP_STATUS = 1 AND DELIVERY_DATE <> '' "
        '    ElseIf (queryParams.COMP_STATUS = "Reception only") Then
        '        sqlStr = sqlStr & " AND COMP_STATUS = 2 "
        '    ElseIf (queryParams.COMP_STATUS = "Incomplete") Then
        '        sqlStr = sqlStr & " AND COMP_STATUS = 0 or COMP_STATUS IS NULL "
        '    End If
        'End If

        If Not String.IsNullOrEmpty(queryParams.SortText) Then
            sqlStr = sqlStr & " " & queryParams.SortText
        End If


        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function AddToken(queryParams As AppleRcptModel) As Int16
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim ret As Integer = 0
        Dim PoNo As String = ""
        Dim No As String = ""
        Dim PoNoTmp1 As Integer = 0
        Dim PoNoTmp2 As Integer = 0
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim dtQmv As DataTable

        Dim sqlStr As String = ""


        sqlStr = "SELECT * FROM AP_RCPT_WAIT_LIST WHERE DELFG = 0 "
        If Not String.IsNullOrEmpty(queryParams.UNQ_NO) Then
            sqlStr = sqlStr & "AND UNQ_NO = @UNQ_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
            sqlStr = sqlStr & "AND PO_NO = @PO_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.CRTDT) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) = @CRTDT "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", queryParams.CRTDT))
        End If

        dtQmv = dbConn.GetDataSet(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        'if exist then need to update delfg=1 then insert the record as new
        If (dtQmv Is Nothing) Or (dtQmv.Rows.Count = 0) Then
            sqlStr = "Insert into AP_RCPT_WAIT_LIST ("
            sqlStr = sqlStr & "CRTDT, "
            sqlStr = sqlStr & "CRTCD, "
            ' sqlStr = sqlStr & "UPDDT, "
            sqlStr = sqlStr & "UPDCD, "
            sqlStr = sqlStr & "UPDPG, "
            sqlStr = sqlStr & "DELFG, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH, "
            'sqlStr = sqlStr & "PO_NO, "
            sqlStr = sqlStr & "NAME, "
            sqlStr = sqlStr & "MOBILE, "
            sqlStr = sqlStr & "MODEL, "
            sqlStr = sqlStr & "PO_NO, "
            sqlStr = sqlStr & "STATUS, "
            sqlStr = sqlStr & "TOKEN_TYPE, "
            sqlStr = sqlStr & "COMMENTS, "
            sqlStr = sqlStr & "IP_ADDRESS "
            sqlStr = sqlStr & " ) "
            sqlStr = sqlStr & " values ( "
            sqlStr = sqlStr & "@CRTDT, "
            sqlStr = sqlStr & "@CRTCD, "
            'sqlStr = sqlStr & "@UPDDT, "
            sqlStr = sqlStr & "@UPDCD, "
            sqlStr = sqlStr & "@UPDPG, "
            sqlStr = sqlStr & "@DELFG, "
            '         sqlStr = sqlStr & " (select max(UNQ_NO)+1 from G_RECEIVED) , "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH, "
            'sqlStr = sqlStr & " (select max(UNQ_NO)+1 from G_RECEIVED) ,"
            sqlStr = sqlStr & "@NAME, "
            sqlStr = sqlStr & "@MOBILE, "
            sqlStr = sqlStr & "@MODEL, "
            sqlStr = sqlStr & "@PO_NO, "
            sqlStr = sqlStr & "@STATUS, "
            sqlStr = sqlStr & "@TOKEN_TYPE, "
            sqlStr = sqlStr & "@COMMENTS, "
            sqlStr = sqlStr & "@IP_ADDRESS  "
            sqlStr = sqlStr & " )"

            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UserId)) '?????????????????????????
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))

            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOKEN_NO", queryParams.TOKEN_NO))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@NAME", queryParams.NAME))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MOBILE", queryParams.MOBILE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MODEL", queryParams.MODEL))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOKEN_TYPE", queryParams.TOKEN_TYPE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMMENTS", queryParams.COMMENTS))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))

            ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))
            flag = dbConn.ExecSQL(sqlStr)
            dbConn.sqlCmd.Parameters.Clear()
            If flag Then
                ret = 0
                dbConn.sqlTrn.Commit()
            Else
                PoNo = "-1"
                dbConn.sqlTrn.Rollback()
                ret = -1
            End If
            dbConn.CloseConnection()
        Else
            ret = 1
        End If
        Return ret
    End Function


    Public Function SelectWaiting(ByVal queryParams As AppleRcptModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT  "
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "TOKEN_NO, "
        sqlStr = sqlStr & "NAME, "
        sqlStr = sqlStr & "MOBILE, "
        sqlStr = sqlStr & "MODEL, "
        sqlStr = sqlStr & "PO_NO, "
        sqlStr = sqlStr & "STATUS, "
        sqlStr = sqlStr & "TOKEN_TYPE, "
        sqlStr = sqlStr & "UNQ_NO "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_RCPT_WAIT_LIST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 AND STATUS not in ( 'COMPLETED') "
        If Not String.IsNullOrEmpty(queryParams.STATUS) Then
            sqlStr = sqlStr & "AND STATUS = @STATUS "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
        End If
        'If (Not (String.IsNullOrEmpty(queryParams.CRTCD)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
        '    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) <= @DateTo "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        'ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
        '    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) = @DateFrom "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        'ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
        sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) = @CRTDT "
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", queryParams.CRTDT))
        'End If

        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        'End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function UpdateStatus(queryParams As AppleRcptModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim sqlStr As String = ""
        Dim flag As Boolean = True

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        sqlStr = "UPDATE AP_RCPT_WAIT_LIST "
        sqlStr = sqlStr & "SET "
        If Not String.IsNullOrEmpty(queryParams.START_DATETIME) Then
            sqlStr = sqlStr & "START_DATETIME=@START_DATETIME, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@START_DATETIME", dtNow))
        End If
        If Not String.IsNullOrEmpty(queryParams.END_DATETIIME) Then
            sqlStr = sqlStr & "END_DATETIIME=@END_DATETIIME, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@END_DATETIIME", dtNow))
        End If
        If Not String.IsNullOrEmpty(queryParams.SUSPENSION_DATETIME) Then
            sqlStr = sqlStr & "SUSPENSION_DATETIME=@SUSPENSION_DATETIME, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SUSPENSION_DATETIME", queryParams.SUSPENSION_DATETIME))
        End If

        If Not String.IsNullOrEmpty(queryParams.STATUS) Then
            sqlStr = sqlStr & "STATUS=@STATUS, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
        End If

        If Not String.IsNullOrEmpty(queryParams.COMMENTS) Then
            sqlStr = sqlStr & "COMMENTS=@COMMENTS, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMMENTS", queryParams.COMMENTS))
        End If

        sqlStr = sqlStr & "UPDDT=@UPDDT "
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))

        sqlStr = sqlStr & "WHERE UNQ_NO = @UNQ_NO "
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))


        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()

        If flag Then
            dbConn.sqlTrn.Commit()
        Else
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()

        Return flag
    End Function



    Public Function AddModel(queryParams As AppleRcptModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = True
        Dim PoNo As String = ""
        Dim No As String = ""
        Dim PoNoTmp1 As Integer = 0
        Dim PoNoTmp2 As Integer = 0
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim dtQmv As DataTable

        Dim sqlStr As String = ""


        sqlStr = "SELECT * FROM AP_RCPT_MODEL WHERE DELFG = 0 "
        'sqlStr &= "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        sqlStr &= "AND UNQ_NO = @UNQ_NO "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dtQmv = dbConn.GetDataSet(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        'if exist then need to update delfg=1 then insert the record as new
        If (dtQmv Is Nothing) Or (dtQmv.Rows.Count = 0) Then



            sqlStr = "Insert into AP_RCPT_MODEL ("
            sqlStr = sqlStr & "CRTDT, "
            sqlStr = sqlStr & "CRTCD, "
            ' sqlStr = sqlStr & "UPDDT, "
            sqlStr = sqlStr & "UPDCD, "
            sqlStr = sqlStr & "UPDPG, "
            sqlStr = sqlStr & "DELFG, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH, "
            'sqlStr = sqlStr & "PO_NO, "
            sqlStr = sqlStr & "UPLOAD_USER, "
            sqlStr = sqlStr & "UPLOAD_DATE, "

            sqlStr = sqlStr & "MODEL, "
            sqlStr = sqlStr & "TYPE, "

            sqlStr = sqlStr & "IP_ADDRESS, "
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
            '         sqlStr = sqlStr & " (select max(UNQ_NO)+1 from G_RECEIVED) , "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH, "

            'sqlStr = sqlStr & " (select max(UNQ_NO)+1 from G_RECEIVED) ,"
            sqlStr = sqlStr & "@UPLOAD_USER, "
            sqlStr = sqlStr & "@UPLOAD_DATE, "

            sqlStr = sqlStr & "@MODEL, "
            sqlStr = sqlStr & "@TYPE, "

            sqlStr = sqlStr & "@IP_ADDRESS, "
            sqlStr = sqlStr & "@FILE_NAME, "
            sqlStr = sqlStr & "@SRC_FILE_NAME "

            'sqlStr = sqlStr & "@IP_ADDRESS "
            sqlStr = sqlStr & " )"
        Else
            sqlStr = "UPDATE AP_RCPT_MODEL SET  "

            sqlStr = sqlStr & "UPDDT = @UPDDT, "
            sqlStr = sqlStr & "UPDCD = @UPDCD, "

            ' sqlStr = sqlStr & "UNQ_NO = @UNQ_NO, "
            sqlStr = sqlStr & "UPLOAD_USER = @UPLOAD_USER, "
            sqlStr = sqlStr & "UPLOAD_DATE = @UPLOAD_DATE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH = @SHIP_TO_BRANCH, "

            sqlStr = sqlStr & "MODEL = @MODEL, "
            sqlStr = sqlStr & "TYPE = @TYPE, "

            sqlStr = sqlStr & "FILE_NAME = @FILE_NAME, "
            sqlStr = sqlStr & "SRC_FILE_NAME = @SRC_FILE_NAME "

            sqlStr = sqlStr & " WHERE UNQ_NO = @UNQ_NO "
            'sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE"
        End If


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UserId)) '?????????????????????????
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_USER", queryParams.UPLOAD_USER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_DATE", queryParams.UPLOAD_DATE))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MODEL   ", queryParams.MODEL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TYPE", queryParams.TYPE))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FILE_NAME", queryParams.FILE_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SRC_FILE_NAME))
        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then
            dbConn.sqlTrn.Commit()
        Else
            PoNo = "-1"
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()

        Return flag
    End Function
End Class
