Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient

Public Class AppleQmvOrdControl

    'SelectClaimDetails

    Public Function SelectPo(ByVal queryParams As AppleQmvOrdModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT TOP 1 * "
        ' sqlStr = sqlStr & "claim_no, "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_QMV_ORD "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
            sqlStr = sqlStr & "AND PO_NO = @PO_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.G_NO) Then
            sqlStr = sqlStr & "AND G_NO = @G_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@G_NO", queryParams.G_NO))
        End If
        'Commnet by Mohan on 20211220
        'sqlStr = sqlStr & " ORDER BY UPDDT DESC"
        sqlStr = sqlStr & " ORDER BY UNQ_NO DESC"


        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
    Public Function SelectDetails(ByVal queryParams As AppleQmvOrdModel) As DataTable


        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & "PO_NO  as PO_NO_1, "
        'sqlStr = sqlStr & "PO_NO, "
        'sqlStr = sqlStr & "G_NO, "
        'sqlStr = sqlStr & "CUSTOMER_NAME, "
        sqlStr = sqlStr & "PO_NO, "
        sqlStr = sqlStr & "LEFT(CONVERT(VARCHAR, PO_DATE, 111), 10) as PO_DATE, "
        sqlStr = sqlStr & "(case when COMP_STATUS = 1 then CASE WHEN DELIVERY_DATE='' then 'Complete' WHEN DELIVERY_DATE<>'' then 'Handed Over' end  when COMP_STATUS = 2 then 'Reception only'  when COMP_STATUS = 0 then 'Incomplete' when COMP_STATUS = null then 'Incomplete' end) COMP_STATUS, "
        sqlStr = sqlStr & "G_NO,CUSTOMER_NAME,ZIP_CODE,MOBLIE_PHONE,TELEPHONE,ADD_1,ADD_2,CITY,STATE,STATE_CODE,E_MAIL,IS_SHIP_DIFF,CUSTOMER_NAME_SHIP,ZIP_CODE_SHIP,MOBLIE_PHONE_SHIP,TELEPHONE_SHIP,ADD_1_SHIP,ADD_2_SHIP,CITY_SHIP,STATE_SHIP,STATE_CODE_SHIP,E_MAIL_SHIP,MODEL_NAME,PRODUCT_NAME,SERIAL_NO,IMEI_1,IMEI_2,DATE_OF_PURCHASE,SERVICE_TYPE,COMPTIA,COMPTIA_MODIFIER,PART_NO1,PART_NO2,PART_NO3,PART_NO4,PART_DETAIL_1,PART_DETAIL_2,PART_DETAIL_3,PART_DETAIL_4,PART_QTY_1,PART_QTY_2,PART_QTY_3,PART_QTY_4,PART_DISCOUNT_1,PART_DISCOUNT_2,PART_DISCOUNT_3,PART_DISCOUNT_4,LABOR_AMOUNT,LABOR_DETAIL,LABOR_COST,LABOR_DISCOUNT,LABOR_SALES,LABOR_SGST,LABOR_CGST,LABOR_IGST,LABOR_TOTAL,PART_COST_1,PART_COST_2,PART_COST_3,PART_COST_4,PART_COST_SALES_1,PART_COST_SALES_2,PART_COST_SALES_3,PART_COST_SALES_4,PART1_TAX,PART2_TAX,PART3_TAX,PART4_TAX,LABOUR_TAX,OTHER_TAX,PART_SGST_1,PART_SGST_2,PART_SGST_3,PART_SGST_4,PART_CGST_1,PART_CGST_2,PART_CGST_3,PART_CGST_4,PART_IGST_1,PART_IGST_2,PART_IGST_3,PART_IGST_4,PART_TOTAL_1,PART_TOTAL_2,PART_TOTAL_3,PART_TOTAL_4,PART_QTY_AMOUNT,PART_COST_AMOUNT,PART_SALES_AMOUNT,PART_DISCOUNT_AMOUNT,PART_SGST_AMOUNT,PART_CGST_AMOUNT,PART_IGST_AMOUNT,PART_TOTAL,OTHER_QTY_AMOUNT,OTHER_DETAIL,OTHER_COST,OTHER_DISCOUNT,OTHER_SALES,OTHER_SGST,OTHER_CGST,OTHER_IGST,OTHER_TOTAL,TOTAL_QTY,TOTAL_COST_AMOUNT,TOTAL_DISCOUNT_AMOUNT,TOTAL_SALES_AMOUNT,TOTAL_SGST_AMOUNT,TOTAL_CGST_AMOUNT,TOTAL_IGST_AMOUNT,TOTAL_AMOUNT,DELIVERY_DATE,COMP_STATUS,COMP_DATE,DENOMINATION,ESTIMATE_DATE,ESTIMATE_TIME,GSX_CLOSE_DATE,USE_SERVICE_TYPE,INVOICE_NOTE,GSX_NOTE,HSN_SAC_CODE,GSTIN,IP_ADDRESS,FILE_NAME,SRC_FILE_NAME,PART_HSN_ASC_1,PART_HSN_ASC_2,PART_HSN_ASC_3,PART_HSN_ASC_4,PRICE_OPTIONS_1,PRICE_OPTIONS_2,PRICE_OPTIONS_3,PRICE_OPTIONS_4,PRICE_OPTIONS_1_TYPE,PRICE_OPTIONS_2_TYPE,PRICE_OPTIONS_3_TYPE,PRICE_OPTIONS_4_TYPE,ADVANCE_PAYMENT,INVOICE_NO,INVOICE_DATE,TRANSFER_REPAIR_CENTER,ACTION_TAKEN,RECEPTION,INTERNAL_INSPECTION,SIGNATURE_INSERVICE_ESTIMATE,WHOLE_SERVICE_FEE_ADR_COLLECTION,GSX_ORDER,REPAIR,REMAINING_AMOUNT_COLLECTION,LOANER_COLLECTION,SEVICE_REPORT,TAX_INVOICE,SERIAL_STOCK_USED_1,SERIAL_STOCK_USED_2,SERIAL_STOCK_USED_3,SERIAL_STOCK_USED_4 "

        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_QMV_ORD "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & " AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If

        If Not String.IsNullOrEmpty(queryParams.CUSTOMER_NAME) Then
            sqlStr = sqlStr & " AND CUSTOMER_NAME like '%' + @CUSTOMER_NAME + '%'"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_NAME", queryParams.CUSTOMER_NAME))
        End If
        If Not String.IsNullOrEmpty(queryParams.SERIAL_NO) Then
            sqlStr = sqlStr & " AND SERIAL_NO = @SERIAL_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.PRODUCT_NAME) Then
            sqlStr = sqlStr & " AND PRODUCT_NAME like '%' + @PRODUCT_NAME + '%' "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.PRODUCT_NAME))
        End If
        'If Not String.IsNullOrEmpty(queryParams.STATUS) Then
        '    sqlStr = sqlStr & " AND po.status = @STATUS"
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
        'End If
        'If Not ((String.IsNullOrEmpty(queryParams.DateFrom)) And (String.IsNullOrEmpty(queryParams.DateTo))) Then
        '    sqlStr = sqlStr & " AND DELIVERY_DATE between @DateFrom and @DateTo"
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        'End If

        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If

        If Not String.IsNullOrEmpty(queryParams.TELEPHONE) Then
            sqlStr = sqlStr & " AND telephone = @telephone "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@telephone", queryParams.TELEPHONE))
        End If
        If Not String.IsNullOrEmpty(queryParams.PART_NO1) Then
            sqlStr = sqlStr & " AND PART_NO1 = @PART_NO1 "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO1", queryParams.PART_NO1))
        End If

        If Not String.IsNullOrEmpty(queryParams.COMP_STATUS) Then
            If (queryParams.COMP_STATUS = "Complete") Then
                sqlStr = sqlStr & " AND COMP_STATUS = 1 AND DELIVERY_DATE = '' "
            ElseIf (queryParams.COMP_STATUS = "Handed over") Then
                sqlStr = sqlStr & " AND COMP_STATUS = 1 AND DELIVERY_DATE <> '' "
            ElseIf (queryParams.COMP_STATUS = "Reception only") Then
                sqlStr = sqlStr & " AND COMP_STATUS = 2 "
            ElseIf (queryParams.COMP_STATUS = "Incomplete") Then
                sqlStr = sqlStr & " AND COMP_STATUS = 0 or COMP_STATUS IS NULL  and DELIVERY_DATE  = '' "
            End If
        End If

        If Not String.IsNullOrEmpty(queryParams.SortText) Then
            sqlStr = sqlStr & " " & queryParams.SortText
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectDetailsExcel(ByVal queryParams As AppleQmvOrdModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & "PO_NO  as PO_NO_1, "
        'sqlStr = sqlStr & "PO_NO, "
        'sqlStr = sqlStr & "G_NO, "
        'sqlStr = sqlStr & "CUSTOMER_NAME, "
        sqlStr = sqlStr & "(case when COMP_STATUS = 1 then CASE WHEN DELIVERY_DATE='' then 'Complete' WHEN DELIVERY_DATE<>'' then 'Handed Over' end  when COMP_STATUS = 2 then 'Reception only'  when COMP_STATUS = 0 then 'Incomplete' when COMP_STATUS = null then 'Incomplete' end) COMP_STATUS, "
        'sqlStr = sqlStr & "SERIAL_NO, "
        'sqlStr = sqlStr & "PRODUCT_NAME, "
        'sqlStr = sqlStr & "part_no1, "
        'sqlStr = sqlStr & "DELIVERY_DATE, "
        sqlStr = sqlStr & "LEFT(CONVERT(VARCHAR, PO_DATE, 111), 10) as PO_DATE, "
        sqlStr = sqlStr & "(case when COMP_STATUS = 1 then CASE WHEN DELIVERY_DATE='' then 'Complete' WHEN DELIVERY_DATE<>'' then 'Handed Over' end  when COMP_STATUS = 2 then 'Reception only'  when COMP_STATUS = 0 then 'Incomplete' when COMP_STATUS = null then 'Incomplete' end) COMP_STATUS, "
        sqlStr = sqlStr & "PO_NO,PO_DATE,G_NO,CUSTOMER_NAME,ZIP_CODE,MOBLIE_PHONE,TELEPHONE,ADD_1,ADD_2,CITY,STATE,STATE_CODE,E_MAIL,IS_SHIP_DIFF,CUSTOMER_NAME_SHIP,ZIP_CODE_SHIP,MOBLIE_PHONE_SHIP,TELEPHONE_SHIP,ADD_1_SHIP,ADD_2_SHIP,CITY_SHIP,STATE_SHIP,STATE_CODE_SHIP,E_MAIL_SHIP,MODEL_NAME,PRODUCT_NAME,SERIAL_NO,IMEI_1,IMEI_2,DATE_OF_PURCHASE,SERVICE_TYPE,COMPTIA,COMPTIA_MODIFIER,PART_NO1,PART_NO2,PART_NO3,PART_NO4,PART_DETAIL_1,PART_DETAIL_2,PART_DETAIL_3,PART_DETAIL_4,PART_QTY_1,PART_QTY_2,PART_QTY_3,PART_QTY_4,PART_DISCOUNT_1,PART_DISCOUNT_2,PART_DISCOUNT_3,PART_DISCOUNT_4,LABOR_AMOUNT,LABOR_DETAIL,LABOR_COST,LABOR_DISCOUNT,LABOR_SALES,LABOR_SGST,LABOR_CGST,LABOR_IGST,LABOR_TOTAL,PART_COST_1,PART_COST_2,PART_COST_3,PART_COST_4,PART_COST_SALES_1,PART_COST_SALES_2,PART_COST_SALES_3,PART_COST_SALES_4,PART1_TAX,PART2_TAX,PART3_TAX,PART4_TAX,LABOUR_TAX,OTHER_TAX,PART_SGST_1,PART_SGST_2,PART_SGST_3,PART_SGST_4,PART_CGST_1,PART_CGST_2,PART_CGST_3,PART_CGST_4,PART_IGST_1,PART_IGST_2,PART_IGST_3,PART_IGST_4,PART_TOTAL_1,PART_TOTAL_2,PART_TOTAL_3,PART_TOTAL_4,PART_QTY_AMOUNT,PART_COST_AMOUNT,PART_SALES_AMOUNT,PART_DISCOUNT_AMOUNT,PART_SGST_AMOUNT,PART_CGST_AMOUNT,PART_IGST_AMOUNT,PART_TOTAL,OTHER_QTY_AMOUNT,OTHER_DETAIL,OTHER_COST,OTHER_DISCOUNT,OTHER_SALES,OTHER_SGST,OTHER_CGST,OTHER_IGST,OTHER_TOTAL,TOTAL_QTY,TOTAL_COST_AMOUNT,TOTAL_DISCOUNT_AMOUNT,TOTAL_SALES_AMOUNT,TOTAL_SGST_AMOUNT,TOTAL_CGST_AMOUNT,TOTAL_IGST_AMOUNT,TOTAL_AMOUNT,DELIVERY_DATE,COMP_STATUS,COMP_DATE,DENOMINATION,ESTIMATE_DATE,ESTIMATE_TIME,GSX_CLOSE_DATE,USE_SERVICE_TYPE,INVOICE_NOTE,GSX_NOTE,HSN_SAC_CODE,GSTIN,IP_ADDRESS,FILE_NAME,SRC_FILE_NAME,PART_HSN_ASC_1,PART_HSN_ASC_2,PART_HSN_ASC_3,PART_HSN_ASC_4,PRICE_OPTIONS_1,PRICE_OPTIONS_2,PRICE_OPTIONS_3,PRICE_OPTIONS_4,ADVANCE_PAYMENT,INVOICE_NO,INVOICE_DATE,TRANSFER_REPAIR_CENTER,ACTION_TAKEN,RECEPTION,INTERNAL_INSPECTION,SIGNATURE_INSERVICE_ESTIMATE,WHOLE_SERVICE_FEE_ADR_COLLECTION,GSX_ORDER,REPAIR,REMAINING_AMOUNT_COLLECTION,LOANER_COLLECTION,SEVICE_REPORT,TAX_INVOICE "

        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_QMV_ORD "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & " AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If

        If Not String.IsNullOrEmpty(queryParams.CUSTOMER_NAME) Then
            sqlStr = sqlStr & " AND CUSTOMER_NAME like '%' + @CUSTOMER_NAME + '%'"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_NAME", queryParams.CUSTOMER_NAME))
        End If
        If Not String.IsNullOrEmpty(queryParams.SERIAL_NO) Then
            sqlStr = sqlStr & " AND SERIAL_NO = @SERIAL_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.PRODUCT_NAME) Then
            sqlStr = sqlStr & " AND PRODUCT_NAME like '%' + @PRODUCT_NAME + '%' "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.PRODUCT_NAME))
        End If
        'If Not String.IsNullOrEmpty(queryParams.STATUS) Then
        '    sqlStr = sqlStr & " AND po.status = @STATUS"
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
        'End If
        'If Not ((String.IsNullOrEmpty(queryParams.DateFrom)) And (String.IsNullOrEmpty(queryParams.DateTo))) Then
        '    sqlStr = sqlStr & " AND DELIVERY_DATE between @DateFrom and @DateTo"
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        'End If

        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If

        If Not String.IsNullOrEmpty(queryParams.TELEPHONE) Then
            sqlStr = sqlStr & " AND telephone = @telephone "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@telephone", queryParams.TELEPHONE))
        End If
        If Not String.IsNullOrEmpty(queryParams.PART_NO1) Then
            sqlStr = sqlStr & " AND PART_NO1 = @PART_NO1 "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO1", queryParams.PART_NO1))
        End If

        If Not String.IsNullOrEmpty(queryParams.COMP_STATUS) Then
            If (queryParams.COMP_STATUS = "Complete") Then
                sqlStr = sqlStr & " AND COMP_STATUS = 1 AND DELIVERY_DATE = '' "
            ElseIf (queryParams.COMP_STATUS = "Handed over") Then
                sqlStr = sqlStr & " AND COMP_STATUS = 1 AND DELIVERY_DATE <> '' "
            ElseIf (queryParams.COMP_STATUS = "Reception only") Then
                sqlStr = sqlStr & " AND COMP_STATUS = 2 "
            ElseIf (queryParams.COMP_STATUS = "Incomplete") Then
                sqlStr = sqlStr & " AND COMP_STATUS = 0 or COMP_STATUS IS NULL "
            End If
        End If

        If Not String.IsNullOrEmpty(queryParams.SortText) Then
            sqlStr = sqlStr & " " & queryParams.SortText
        End If


        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function SelectSummary(ByVal queryParams As AppleQmvOrdModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT "
        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            queryParams.DateTo = queryParams.DateFrom
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            queryParams.DateFrom = queryParams.DateTo
        End If

        Dim dtCRTDT As String = ""
        Dim dtDeliveryDate As String = ""

        dtCRTDT = " LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) <= @DateTo "
        dtDeliveryDate = " LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) <= @DateTo "

        'Token
        sqlStr = sqlStr & "(select count(UNQ_NO)  from [AP_PO] where " & dtCRTDT & " ) as GeneratedPo, "

        sqlStr = sqlStr & "(select count(UNQ_NO) from AP_RCPT_WAIT_LIST where TOKEN_TYPE=1 And " & dtCRTDT & " ) NewToken,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from AP_RCPT_WAIT_LIST where TOKEN_TYPE=2 And " & dtCRTDT & " ) PickupToken,  "
        sqlStr = sqlStr & "(select count(UNQ_NO)  from AP_RCPT_WAIT_LIST  where TOKEN_TYPE in (1,2) And  " & dtCRTDT & " ) TotalToken,  "


        'UnderRepair Count
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And COMP_STATUS=0 And " & dtDeliveryDate & " ) UnderRepairIW,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And COMP_STATUS=0 And " & dtDeliveryDate & " ) UnderRepairOOW,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And COMP_STATUS=0 And " & dtDeliveryDate & " ) UnderRepairAC,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) AND COMP_STATUS=0 And " & dtDeliveryDate & " ) UnderRepairTotal,  "


        'Custody Count IW/OOW/AC+
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And COMP_STATUS=0 And " & dtDeliveryDate & " AND NOT (PART_QTY_1 IS NULL  AND PART_QTY_2 IS NULL AND PART_QTY_3 IS NULL AND PART_QTY_4 IS NULL) ) CustodayIW,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And COMP_STATUS=0 And " & dtDeliveryDate & " AND NOT (PART_QTY_1 IS NULL  AND PART_QTY_2 IS NULL AND PART_QTY_3 IS NULL AND PART_QTY_4 IS NULL) ) CustodayOOW,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And COMP_STATUS=0 And " & dtDeliveryDate & " AND NOT (PART_QTY_1 IS NULL  AND PART_QTY_2 IS NULL AND PART_QTY_3 IS NULL AND PART_QTY_4 IS NULL) ) CustodayAC,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) And COMP_STATUS=0 And " & dtDeliveryDate & " AND NOT (PART_QTY_1 IS NULL  AND PART_QTY_2 IS NULL AND PART_QTY_3 IS NULL AND PART_QTY_4 IS NULL) ) CustodayTotal,  "

        'GSX Completed Count IW/OOW/AC+
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And COMP_STATUS=1 And " & dtDeliveryDate & " ) GsxIW,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And COMP_STATUS=1 And " & dtDeliveryDate & " ) GsxOOW,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And COMP_STATUS=1 And " & dtDeliveryDate & "  ) GsxAC,  "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) And COMP_STATUS=0 And " & dtDeliveryDate & " ) GsxTotal,  "

        'Delivered Count IW/OOW/AC+
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And LEN(DELIVERY_DATE) > 6 And " & dtDeliveryDate & " ) DeliveredIW,   "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And LEN(DELIVERY_DATE) > 6 And " & dtDeliveryDate & " ) DeliveredOOW,   "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And LEN(DELIVERY_DATE) > 6 And " & dtDeliveryDate & " ) DeliveredAC,   "
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) And LEN(DELIVERY_DATE) > 6 And " & dtDeliveryDate & " ) DeliveredTotal,   "

        'Sales
        sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=4 And " & dtDeliveryDate & " ) SalesCount,  "



        'Labour 
        'IW -Not billed
        'Commented on 2021/12/15
        'sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION in (2,1) And " & dtCRTDT & " ) LabourIW,   "
        sqlStr = sqlStr & "(select sum(LABOR_COST) from [AP_QMV_ORD] where SERVICE_TYPE=1 And  " & dtDeliveryDate & " ) LabourIW,   "
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION=2 And " & dtDeliveryDate & " ) LabourIWCash,   "
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) LabourIWCard,   "
        'OOW
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE=2 And DENOMINATION=2 And " & dtDeliveryDate & " ) LabourOOWCash,   "
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE=2 And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) LabourOOWCard,   "
        'AC+
        'Modified on 2021/12/15
        'sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=3 And DENOMINATION=2 And " & dtCRTDT & " ) LabourACCash,   "
        sqlStr = sqlStr & "(select sum(LABOR_COST) from [AP_QMV_ORD] where SERVICE_TYPE=3 And  " & dtDeliveryDate & " ) LabourACCash,   "
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE=3 And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) LabourACCard,   "
        'Sales
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE=4 And DENOMINATION=2 And " & dtDeliveryDate & " ) LabourSalesCash,   "
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE=4 And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) LabourSalesCard,   "
        'IW - Not Billed
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3,4) And DENOMINATION=2 And " & dtDeliveryDate & " ) LabourTotalCash,   "
        sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3,4) And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) LabourTotalCard,   "


        'Parts
        'IW
        'Comments on 2021/12/15
        'sqlStr = sqlStr & "(select sum(PART_TOTAL)+sum(OTHER_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION in (2,1) And " & dtCRTDT & " ) PartsIW,   "
        sqlStr = sqlStr & "(select isnull(sum(PART_COST_1),0)+isnull(sum(PART_COST_2),0)+isnull(sum(PART_COST_3),0)+isnull(sum(PART_COST_4),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE=1 And  " & dtDeliveryDate & " ) PartsIW,   "
        ' isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0)
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsIWCash,   "
        'isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) 
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) PartsIWCard,   "
        'OOW
        'isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0)
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(abs(OTHER_SALES)),0) from [AP_QMV_ORD] where SERVICE_TYPE=2 And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsOOWCash,   "
        'isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0)
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(abs(OTHER_SALES)),0) from [AP_QMV_ORD] where SERVICE_TYPE=2 And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) PartsOOWCard,   "
        'AC+
        'isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0)
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE=3 And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsACCash,   "
        'isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0)
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE=3 And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) PartsACCard,   "
        'Sales
        'isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) 
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE=4 And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsASalesCash,   "
        'isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0)
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE=4 And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) PartsSalesCard,   "
        'Total
        'isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0)
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3,4) And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsTotalCash,   "
        '
        sqlStr = sqlStr & "(select isnull(sum(PART_SALES_AMOUNT),0)+isnull(sum(OTHER_SALES),0) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3,4) And DENOMINATION IN (1,4) And " & dtDeliveryDate & " ) PartsTotalCard   "


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function



    'Public Function SelectSummary(ByVal queryParams As AppleQmvOrdModel) As DataTable
    '    Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
    '    Dim dbConn As DBUtility = New DBUtility()
    '    Dim sqlStr As String = "SELECT "
    '    If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
    '    ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
    '        queryParams.DateTo = queryParams.DateFrom
    '    ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
    '        queryParams.DateFrom = queryParams.DateTo
    '    End If

    '    Dim dtCRTDT As String = ""
    '    Dim dtDeliveryDate As String = ""

    '    dtCRTDT = " LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) <= @DateTo "
    '    dtDeliveryDate = " LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) <= @DateTo "

    '    'Token
    '    sqlStr = sqlStr & "(select count(UNQ_NO)  from [AP_PO] where " & dtCRTDT & " ) as GeneratedPo, "

    '    sqlStr = sqlStr & "(select count(UNQ_NO) from AP_RCPT_WAIT_LIST where TOKEN_TYPE=1 And " & dtCRTDT & " ) NewToken,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from AP_RCPT_WAIT_LIST where TOKEN_TYPE=2 And " & dtCRTDT & " ) PickupToken,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO)  from AP_RCPT_WAIT_LIST  where TOKEN_TYPE in (1,2) And  " & dtCRTDT & " ) TotalToken,  "


    '    'UnderRepair Count
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And COMP_STATUS=0 And " & dtDeliveryDate & " ) UnderRepairIW,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And COMP_STATUS=0 And " & dtDeliveryDate & " ) UnderRepairOOW,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And COMP_STATUS=0 And " & dtDeliveryDate & " ) UnderRepairAC,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) AND COMP_STATUS=0 And " & dtDeliveryDate & " ) UnderRepairTotal,  "


    '    'Custody Count IW/OOW/AC+
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And COMP_STATUS=0 And " & dtDeliveryDate & " AND NOT (PART_QTY_1 IS NULL  AND PART_QTY_2 IS NULL AND PART_QTY_3 IS NULL AND PART_QTY_4 IS NULL) ) CustodayIW,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And COMP_STATUS=0 And " & dtDeliveryDate & " AND NOT (PART_QTY_1 IS NULL  AND PART_QTY_2 IS NULL AND PART_QTY_3 IS NULL AND PART_QTY_4 IS NULL) ) CustodayOOW,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And COMP_STATUS=0 And " & dtDeliveryDate & " AND NOT (PART_QTY_1 IS NULL  AND PART_QTY_2 IS NULL AND PART_QTY_3 IS NULL AND PART_QTY_4 IS NULL) ) CustodayAC,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) And COMP_STATUS=0 And " & dtDeliveryDate & " AND NOT (PART_QTY_1 IS NULL  AND PART_QTY_2 IS NULL AND PART_QTY_3 IS NULL AND PART_QTY_4 IS NULL) ) CustodayTotal,  "

    '    'GSX Completed Count IW/OOW/AC+
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And COMP_STATUS=1 And " & dtDeliveryDate & " ) GsxIW,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And COMP_STATUS=1 And " & dtDeliveryDate & " ) GsxOOW,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And COMP_STATUS=1 And " & dtDeliveryDate & "  ) GsxAC,  "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) And COMP_STATUS=0 And " & dtDeliveryDate & " ) GsxTotal,  "

    '    'Delivered Count IW/OOW/AC+
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And LEN(DELIVERY_DATE) > 6 And " & dtDeliveryDate & " ) DeliveredIW,   "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And LEN(DELIVERY_DATE) > 6 And " & dtDeliveryDate & " ) DeliveredOOW,   "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And LEN(DELIVERY_DATE) > 6 And " & dtDeliveryDate & " ) DeliveredAC,   "
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) And LEN(DELIVERY_DATE) > 6 And " & dtDeliveryDate & " ) DeliveredTotal,   "

    '    'Sales
    '    sqlStr = sqlStr & "(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=4 And " & dtDeliveryDate & " ) SalesCount,  "



    '    'Labour 
    '    'IW -Not billed
    '    'Commented on 2021/12/15
    '    'sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION in (2,1) And " & dtCRTDT & " ) LabourIW,   "
    '    sqlStr = sqlStr & "(select sum(LABOR_COST) from [AP_QMV_ORD] where SERVICE_TYPE=1 And  " & dtDeliveryDate & " ) LabourIW,   "
    '    sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION=2 And " & dtDeliveryDate & " ) LabourIWCash,   "
    '    sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION=1 And " & dtDeliveryDate & " ) LabourIWCard,   "
    '    'OOW
    '    sqlStr = sqlStr & "(select sum(LABOR_SALES) from [AP_QMV_ORD] where SERVICE_TYPE=2 And DENOMINATION=2 And " & dtDeliveryDate & " ) LabourOOWCash,   "
    '    sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=2 And DENOMINATION=1 And " & dtDeliveryDate & " ) LabourOOWCard,   "
    '    'AC+
    '    'Modified on 2021/12/15
    '    'sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=3 And DENOMINATION=2 And " & dtCRTDT & " ) LabourACCash,   "
    '    sqlStr = sqlStr & "(select sum(LABOR_COST) from [AP_QMV_ORD] where SERVICE_TYPE=3 And  " & dtDeliveryDate & " ) LabourACCash,   "
    '    sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=3 And DENOMINATION=1 And " & dtDeliveryDate & " ) LabourACCard,   "
    '    'Sales
    '    sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=4 And DENOMINATION=2 And " & dtDeliveryDate & " ) LabourSalesCash,   "
    '    sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=4 And DENOMINATION=1 And " & dtDeliveryDate & " ) LabourSalesCard,   "
    '    'IW - Not Billed
    '    sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3,4) And DENOMINATION=2 And " & dtDeliveryDate & " ) LabourTotalCash,   "
    '    sqlStr = sqlStr & "(select sum(LABOR_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3,4) And DENOMINATION=1 And " & dtDeliveryDate & " ) LabourTotalCard,   "


    '    'Parts
    '    'IW
    '    'Comments on 2021/12/15
    '    'sqlStr = sqlStr & "(select sum(PART_TOTAL)+sum(OTHER_TOTAL) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION in (2,1) And " & dtCRTDT & " ) PartsIW,   "
    '    sqlStr = sqlStr & "(select isnull(sum(PART_COST_1),0)+isnull(sum(PART_COST_2),0)+isnull(sum(PART_COST_3),0)+isnull(sum(PART_COST_4),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=1 And  " & dtDeliveryDate & " ) PartsIW,   "
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsIWCash,   "
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=1 And DENOMINATION=1 And " & dtDeliveryDate & " ) PartsIWCard,   "
    '    'OOW
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=2 And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsOOWCash,   "
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=2 And DENOMINATION=1 And " & dtDeliveryDate & " ) PartsOOWCard,   "
    '    'AC+
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=3 And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsACCash,   "
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=3 And DENOMINATION=1 And " & dtDeliveryDate & " ) PartsACCard,   "
    '    'Sales
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=4 And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsASalesCash,   "
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE=4 And DENOMINATION=1 And " & dtDeliveryDate & " ) PartsSalesCard,   "
    '    'Total
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3,4) And DENOMINATION=2 And " & dtDeliveryDate & " ) PartsTotalCash,   "
    '    sqlStr = sqlStr & "(select isnull(sum(PART_TOTAL),0)+isnull(sum(OTHER_TOTAL),0) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3,4) And DENOMINATION=1 And " & dtDeliveryDate & " ) PartsTotalCard   "


    '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
    '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))

    '    Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
    '    dbConn.CloseConnection()
    '    Return _DataTable
    'End Function
    Public Function SelectPoDate(ByVal queryParams As AppleQmvOrdModel) As String
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "TOP 1 CRTDT "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PO "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0  "
        If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
            sqlStr = sqlStr & "AND PO_NO = @PO_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        End If
        dt = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return dt.Rows(0)("CRTDT").ToString()
    End Function

    Public Function SelectPLOrder(ByVal queryParams As AppleQmvOrdModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & "REGION, ASC_LEVEL, ASC_CODE, ASC_NAME, JOB_ID, CUSTOMER_GROUP , MANUFACTURE, WARRANTY_TYPE, WARRANTY_CATEGORY, SERVICE_TYPE, PRODUCT_CATEGORY_NAME, PRODUCT_SUB_CATEGORY_NAME, SET_MODEL, MODEL_NAME, SERIAL_NO, DEALER_NAME, PURCHASED_DATE, RESERVATION_CREATE_DATE, APPOINTMENT_DATE, BOOKED_IN_DATE, REPAIR_COMPLETED_DATE, REPAIR_STATUS, COLLECT_DATE, RECEPTIONIST, TECHNICIAN, ONSITE_PEOPLE, DISPATCHED_BY, LOT_NO, WARRANTY_NO, REPAIR_LEVEL, TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, ACCOUNT_PAYABLE_BY_CUSTOMER, SONY_NEEDS_TO_PAY, ACCOUNT_PAYABLE_BY_ASC, CUSTOMER_NAME, CONTACT_NO, MOBILE_NO, CITY, STATE, POSTAL_CODE, PENDIND_DELIVERT_AGE, TOTAL_PART_FEE, LABOUR_FEE, INSPECTION_FEE, HANDLING_FEE, TRANSPORT_FEE, HOMESERVICE_FEE, LONGDISTANCE_FEE, TRAVELALLOWANCE_FEE, DA_FEE, DEMO_CHARGE, INSTALLATION_FEE, ECALL_CHARGE, COMBAT_FEE, ADDRESS, FAX_NO, EMAIL_ID, LAST_CONTACT_UPDATE_DATE, LAST_CONTACT_UPDATE_CONTENT, REPAIR_SET_BIN_LOCATION, HSN_CODE_OF_MODEL, PLACE_OF_SUPPLY "
        sqlStr = sqlStr & "* "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_QMV_ORD "
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
        'DELIVERY_DATE

        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) <= @DateTo "
            'sqlStr = sqlStr & "AND INVOICE_DATE >= @DateFrom and INVOICE_DATE <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateFrom "
            sqlStr = sqlStr & "AND DELIVERY_DATE = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND DELIVERY_DATE = @DateTo "
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function SelectPLRcptWaitLst(ByVal queryParams As AppleQmvOrdModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & "REGION, ASC_LEVEL, ASC_CODE, ASC_NAME, JOB_ID, CUSTOMER_GROUP , MANUFACTURE, WARRANTY_TYPE, WARRANTY_CATEGORY, SERVICE_TYPE, PRODUCT_CATEGORY_NAME, PRODUCT_SUB_CATEGORY_NAME, SET_MODEL, MODEL_NAME, SERIAL_NO, DEALER_NAME, PURCHASED_DATE, RESERVATION_CREATE_DATE, APPOINTMENT_DATE, BOOKED_IN_DATE, REPAIR_COMPLETED_DATE, REPAIR_STATUS, COLLECT_DATE, RECEPTIONIST, TECHNICIAN, ONSITE_PEOPLE, DISPATCHED_BY, LOT_NO, WARRANTY_NO, REPAIR_LEVEL, TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, ACCOUNT_PAYABLE_BY_CUSTOMER, SONY_NEEDS_TO_PAY, ACCOUNT_PAYABLE_BY_ASC, CUSTOMER_NAME, CONTACT_NO, MOBILE_NO, CITY, STATE, POSTAL_CODE, PENDIND_DELIVERT_AGE, TOTAL_PART_FEE, LABOUR_FEE, INSPECTION_FEE, HANDLING_FEE, TRANSPORT_FEE, HOMESERVICE_FEE, LONGDISTANCE_FEE, TRAVELALLOWANCE_FEE, DA_FEE, DEMO_CHARGE, INSTALLATION_FEE, ECALL_CHARGE, COMBAT_FEE, ADDRESS, FAX_NO, EMAIL_ID, LAST_CONTACT_UPDATE_DATE, LAST_CONTACT_UPDATE_CONTENT, REPAIR_SET_BIN_LOCATION, HSN_CODE_OF_MODEL, PLACE_OF_SUPPLY "
        sqlStr = sqlStr & "* "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_RCPT_WAIT_LIST "
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
        'DELIVERY_DATE

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


    Public Function SelectPoGenerated(ByVal queryParams As AppleQmvOrdModel) As String
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "count(*) GeneratedPo "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PO "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0  "

        'If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
        '    sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        'End If

        'If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH) Then
        '    sqlStr = sqlStr & "AND SHIP_TO_BRANCH = @SHIP_TO_BRANCH "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        'End If


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
        dt = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return dt.Rows(0)("GeneratedPo").ToString()
    End Function

    Public Function AddQmvOrd(queryParams As AppleQmvOrdModel) As Boolean
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


        sqlStr = "SELECT * FROM AP_QMV_ORD WHERE DELFG = 0 "
        'Comment on 20211220 - Investigation
        'sqlStr &= "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        sqlStr &= "AND PO_NO = @PO_NO "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dtQmv = dbConn.GetDataSet(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        'if exist then need to update delfg=1 then insert the record as new
        If (dtQmv Is Nothing) Or (dtQmv.Rows.Count = 0) Then

            sqlStr = " "
            sqlStr = sqlStr & "declare @PART1_STATUS bit "
            sqlStr = sqlStr & "declare @PART2_STATUS bit "
            sqlStr = sqlStr & "declare @PART3_STATUS bit "
            sqlStr = sqlStr & "declare @PART4_STATUS bit "
            sqlStr = sqlStr & " "
            sqlStr = sqlStr & "set @PART1_STATUS='true' "
            sqlStr = sqlStr & "set @PART2_STATUS='true' "
            sqlStr = sqlStr & "set @PART3_STATUS='true' "
            sqlStr = sqlStr & "set @PART4_STATUS='true' "
            sqlStr = sqlStr & " "
            sqlStr = sqlStr & "declare @GlobalStatus bit "
            sqlStr = sqlStr & "set @GlobalStatus='true' "
            sqlStr = sqlStr & " "



            sqlStr = sqlStr & "Insert into AP_QMV_ORD ("
            sqlStr = sqlStr & "CRTDT, "
            sqlStr = sqlStr & "CRTCD, "
            sqlStr = sqlStr & "UPDDT, "
            sqlStr = sqlStr & "UPDCD, "
            sqlStr = sqlStr & "UPDPG, "
            sqlStr = sqlStr & "DELFG, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH, "
            sqlStr = sqlStr & "PO_NO, "
            sqlStr = sqlStr & "PO_DATE, "
            sqlStr = sqlStr & "G_NO, "
            sqlStr = sqlStr & "CUSTOMER_NAME, "
            sqlStr = sqlStr & "ZIP_CODE, "
            sqlStr = sqlStr & "MOBLIE_PHONE, "
            sqlStr = sqlStr & "TELEPHONE, "
            sqlStr = sqlStr & "ADD_1, "
            sqlStr = sqlStr & "ADD_2, "
            sqlStr = sqlStr & "CITY, "
            sqlStr = sqlStr & "STATE, "
            sqlStr = sqlStr & "STATE_CODE, "
            sqlStr = sqlStr & "E_MAIL, "


            sqlStr = sqlStr & "IS_SHIP_DIFF, "
            sqlStr = sqlStr & "CUSTOMER_NAME_SHIP, "
            sqlStr = sqlStr & "ZIP_CODE_SHIP, "
            sqlStr = sqlStr & "MOBLIE_PHONE_SHIP, "
            sqlStr = sqlStr & "TELEPHONE_SHIP, "
            sqlStr = sqlStr & "ADD_1_SHIP, "
            sqlStr = sqlStr & "ADD_2_SHIP, "
            sqlStr = sqlStr & "CITY_SHIP, "
            sqlStr = sqlStr & "STATE_SHIP, "
            sqlStr = sqlStr & "E_MAIL_SHIP, "




            sqlStr = sqlStr & "MODEL_NAME, "
            sqlStr = sqlStr & "PRODUCT_NAME, "
            sqlStr = sqlStr & "SERIAL_NO, "
            sqlStr = sqlStr & "IMEI_1, "
            sqlStr = sqlStr & "IMEI_2, "
            sqlStr = sqlStr & "DATE_OF_PURCHASE, "
            sqlStr = sqlStr & "SERVICE_TYPE, "
            sqlStr = sqlStr & "COMPTIA, "
            sqlStr = sqlStr & "COMPTIA_MODIFIER, "
            sqlStr = sqlStr & "ACCESSORY_NOTE, "

            sqlStr = sqlStr & "PART_NO1, "
            sqlStr = sqlStr & "PART_NO2, "
            sqlStr = sqlStr & "PART_NO3, "
            sqlStr = sqlStr & "PART_NO4, "
            sqlStr = sqlStr & "PART_DETAIL_1, "
            sqlStr = sqlStr & "PART_DETAIL_2, "
            sqlStr = sqlStr & "PART_DETAIL_3, "
            sqlStr = sqlStr & "PART_DETAIL_4, "
            sqlStr = sqlStr & "PART_QTY_1, "
            sqlStr = sqlStr & "PART_QTY_2, "
            sqlStr = sqlStr & "PART_QTY_3, "
            sqlStr = sqlStr & "PART_QTY_4, "

            sqlStr = sqlStr & "SERIAL_STOCK_USED_1, "
            sqlStr = sqlStr & "SERIAL_STOCK_USED_2, "
            sqlStr = sqlStr & "SERIAL_STOCK_USED_3, "
            sqlStr = sqlStr & "SERIAL_STOCK_USED_4, "

            sqlStr = sqlStr & "PART_DISCOUNT_1, "
            sqlStr = sqlStr & "PART_DISCOUNT_2, "
            sqlStr = sqlStr & "PART_DISCOUNT_3, "
            sqlStr = sqlStr & "PART_DISCOUNT_4, "

            'sqlStr = sqlStr & "PRICE_OPTIONS_1, "
            'sqlStr = sqlStr & "PRICE_OPTIONS_2, "
            'sqlStr = sqlStr & "PRICE_OPTIONS_3, "
            'sqlStr = sqlStr & "PRICE_OPTIONS_4, "

            sqlStr = sqlStr & "PRICE_OPTIONS_1_TYPE, "
            sqlStr = sqlStr & "PRICE_OPTIONS_2_TYPE, "
            sqlStr = sqlStr & "PRICE_OPTIONS_3_TYPE, "
            sqlStr = sqlStr & "PRICE_OPTIONS_4_TYPE, "


            sqlStr = sqlStr & "TRANSFER_REPAIR_CENTER, "
            sqlStr = sqlStr & "ACTION_TAKEN, "
            sqlStr = sqlStr & "RECEPTION, "
            sqlStr = sqlStr & "INTERNAL_INSPECTION, "
            sqlStr = sqlStr & "SIGNATURE_INSERVICE_ESTIMATE, "
            sqlStr = sqlStr & "WHOLE_SERVICE_FEE_ADR_COLLECTION, "
            sqlStr = sqlStr & "GSX_ORDER, "
            sqlStr = sqlStr & "REPAIR, "
            sqlStr = sqlStr & "REMAINING_AMOUNT_COLLECTION, "
            sqlStr = sqlStr & "LOANER_COLLECTION, "
            sqlStr = sqlStr & "SEVICE_REPORT, "
            sqlStr = sqlStr & "TAX_INVOICE, "





            sqlStr = sqlStr & "ADVANCE_PAYMENT, "


            sqlStr = sqlStr & "LABOR_AMOUNT, "
            sqlStr = sqlStr & "LABOR_DETAIL, "
            sqlStr = sqlStr & "LABOR_COST, "
            sqlStr = sqlStr & "LABOR_DISCOUNT, "
            sqlStr = sqlStr & "LABOR_SALES, "
            sqlStr = sqlStr & "LABOR_SGST, "
            sqlStr = sqlStr & "LABOR_CGST, "
            sqlStr = sqlStr & "LABOR_IGST, "
            sqlStr = sqlStr & "LABOR_TOTAL, "
            sqlStr = sqlStr & "PART_COST_1, "
            sqlStr = sqlStr & "PART_COST_2, "
            sqlStr = sqlStr & "PART_COST_3, "
            sqlStr = sqlStr & "PART_COST_4, "
            sqlStr = sqlStr & "PART_COST_SALES_1, "
            sqlStr = sqlStr & "PART_COST_SALES_2, "
            sqlStr = sqlStr & "PART_COST_SALES_3, "
            sqlStr = sqlStr & "PART_COST_SALES_4, "
            sqlStr = sqlStr & "PART_SGST_1, "
            sqlStr = sqlStr & "PART_SGST_2, "
            sqlStr = sqlStr & "PART_SGST_3, "
            sqlStr = sqlStr & "PART_SGST_4, "
            sqlStr = sqlStr & "PART_CGST_1, "
            sqlStr = sqlStr & "PART_CGST_2, "
            sqlStr = sqlStr & "PART_CGST_3, "
            sqlStr = sqlStr & "PART_CGST_4, "
            sqlStr = sqlStr & "PART_IGST_1, "
            sqlStr = sqlStr & "PART_IGST_2, "
            sqlStr = sqlStr & "PART_IGST_3, "
            sqlStr = sqlStr & "PART_IGST_4, "

            sqlStr = sqlStr & "PART1_TAX, "
            sqlStr = sqlStr & "PART2_TAX, "
            sqlStr = sqlStr & "PART3_TAX, "
            sqlStr = sqlStr & "PART4_TAX, "
            sqlStr = sqlStr & "LABOUR_TAX, "
            sqlStr = sqlStr & "OTHER_TAX, "


            sqlStr = sqlStr & "PART_TOTAL_1, "
            sqlStr = sqlStr & "PART_TOTAL_2, "
            sqlStr = sqlStr & "PART_TOTAL_3, "
            sqlStr = sqlStr & "PART_TOTAL_4, "
            sqlStr = sqlStr & "PART_QTY_AMOUNT, "
            sqlStr = sqlStr & "PART_COST_AMOUNT, "
            sqlStr = sqlStr & "PART_SALES_AMOUNT, "
            sqlStr = sqlStr & "PART_DISCOUNT_AMOUNT, "
            sqlStr = sqlStr & "PART_SGST_AMOUNT, "
            sqlStr = sqlStr & "PART_CGST_AMOUNT, "
            sqlStr = sqlStr & "PART_IGST_AMOUNT, "
            sqlStr = sqlStr & "PART_TOTAL, "
            sqlStr = sqlStr & "OTHER_QTY_AMOUNT, "
            sqlStr = sqlStr & "OTHER_DETAIL, "
            sqlStr = sqlStr & "OTHER_COST, "
            sqlStr = sqlStr & "OTHER_DISCOUNT, "

            sqlStr = sqlStr & "OTHER_SALES, "
            sqlStr = sqlStr & "OTHER_SGST, "
            sqlStr = sqlStr & "OTHER_CGST, "
            sqlStr = sqlStr & "OTHER_IGST, "
            sqlStr = sqlStr & "OTHER_TOTAL, "
            sqlStr = sqlStr & "TOTAL_QTY, "
            sqlStr = sqlStr & "TOTAL_COST_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_DISCOUNT_AMOUNT, "

            sqlStr = sqlStr & "TOTAL_SALES_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_SGST_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_CGST_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_IGST_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_AMOUNT, "
            sqlStr = sqlStr & "DELIVERY_DATE, "
            sqlStr = sqlStr & "COMP_STATUS, "
            sqlStr = sqlStr & "COMP_DATE, "
            sqlStr = sqlStr & "DENOMINATION, "
            sqlStr = sqlStr & "ESTIMATE_DATE, "
            sqlStr = sqlStr & "ESTIMATE_TIME, "
            sqlStr = sqlStr & "GSX_CLOSE_DATE, "
            sqlStr = sqlStr & "USE_SERVICE_TYPE, "
            sqlStr = sqlStr & "INVOICE_NOTE, "
            sqlStr = sqlStr & "GSX_NOTE, "
            sqlStr = sqlStr & "HSN_SAC_CODE, "
            sqlStr = sqlStr & "GSTIN, "


            sqlStr = sqlStr & "IP_ADDRESS "
            sqlStr = sqlStr & " ) "
            sqlStr = sqlStr & " values ( "
            sqlStr = sqlStr & "@CRTDT, "
            sqlStr = sqlStr & "@CRTCD, "
            sqlStr = sqlStr & "@UPDDT, "
            sqlStr = sqlStr & "@UPDCD, "
            sqlStr = sqlStr & "@UPDPG, "
            sqlStr = sqlStr & "@DELFG, "
            '         sqlStr = sqlStr & " (select max(UNQ_NO)+1 from G_RECEIVED) , "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH, "



            sqlStr = sqlStr & "@PO_NO, "
            sqlStr = sqlStr & "@PO_DATE, "
            sqlStr = sqlStr & "@G_NO, "
            sqlStr = sqlStr & "@CUSTOMER_NAME, "
            sqlStr = sqlStr & "@ZIP_CODE, "
            sqlStr = sqlStr & "@MOBLIE_PHONE, "
            sqlStr = sqlStr & "@TELEPHONE, "
            sqlStr = sqlStr & "@ADD_1, "
            sqlStr = sqlStr & "@ADD_2, "
            sqlStr = sqlStr & "@CITY, "
            sqlStr = sqlStr & "@STATE, "
            sqlStr = sqlStr & "@STATE_CODE, "
            sqlStr = sqlStr & "@E_MAIL, "


            sqlStr = sqlStr & "@IS_SHIP_DIFF, "
            sqlStr = sqlStr & "@CUSTOMER_NAME_SHIP, "
            sqlStr = sqlStr & "@ZIP_CODE_SHIP, "
            sqlStr = sqlStr & "@MOBLIE_PHONE_SHIP, "
            sqlStr = sqlStr & "@TELEPHONE_SHIP, "
            sqlStr = sqlStr & "@ADD_1_SHIP, "
            sqlStr = sqlStr & "@ADD_2_SHIP, "
            sqlStr = sqlStr & "@CITY_SHIP, "
            sqlStr = sqlStr & "@STATE_SHIP, "
            sqlStr = sqlStr & "@E_MAIL_SHIP, "





            sqlStr = sqlStr & "@MODEL_NAME, "
            sqlStr = sqlStr & "@PRODUCT_NAME, "
            sqlStr = sqlStr & "@SERIAL_NO, "
            sqlStr = sqlStr & "@IMEI_1, "
            sqlStr = sqlStr & "@IMEI_2, "
            sqlStr = sqlStr & "@DATE_OF_PURCHASE, "
            sqlStr = sqlStr & "@SERVICE_TYPE, "
            sqlStr = sqlStr & "@COMPTIA, "
            sqlStr = sqlStr & "@COMPTIA_MODIFIER, "
            sqlStr = sqlStr & "@ACCESSORY_NOTE, "

            sqlStr = sqlStr & "@PART_NO1, "
            sqlStr = sqlStr & "@PART_NO2, "
            sqlStr = sqlStr & "@PART_NO3, "
            sqlStr = sqlStr & "@PART_NO4, "
            sqlStr = sqlStr & "@PART_DETAIL_1, "
            sqlStr = sqlStr & "@PART_DETAIL_2, "
            sqlStr = sqlStr & "@PART_DETAIL_3, "
            sqlStr = sqlStr & "@PART_DETAIL_4, "
            sqlStr = sqlStr & "@PART_QTY_1, "
            sqlStr = sqlStr & "@PART_QTY_2, "
            sqlStr = sqlStr & "@PART_QTY_3, "
            sqlStr = sqlStr & "@PART_QTY_4, "

            sqlStr = sqlStr & "@SERIAL_STOCK_USED_1, "
            sqlStr = sqlStr & "@SERIAL_STOCK_USED_2, "
            sqlStr = sqlStr & "@SERIAL_STOCK_USED_3, "
            sqlStr = sqlStr & "@SERIAL_STOCK_USED_4, "


            sqlStr = sqlStr & "@PART_DISCOUNT_1, "
            sqlStr = sqlStr & "@PART_DISCOUNT_2, "
            sqlStr = sqlStr & "@PART_DISCOUNT_3, "
            sqlStr = sqlStr & "@PART_DISCOUNT_4, "

            'sqlStr = sqlStr & "@PRICE_OPTIONS_1, "
            'sqlStr = sqlStr & "@PRICE_OPTIONS_2, "
            'sqlStr = sqlStr & "@PRICE_OPTIONS_3, "
            'sqlStr = sqlStr & "@PRICE_OPTIONS_4, "


            sqlStr = sqlStr & "@PRICE_OPTIONS_1_TYPE, "
            sqlStr = sqlStr & "@PRICE_OPTIONS_2_TYPE, "
            sqlStr = sqlStr & "@PRICE_OPTIONS_3_TYPE, "
            sqlStr = sqlStr & "@PRICE_OPTIONS_4_TYPE, "


            sqlStr = sqlStr & "@TRANSFER_REPAIR_CENTER, "
            sqlStr = sqlStr & "@ACTION_TAKEN, "
            sqlStr = sqlStr & "@RECEPTION, "
            sqlStr = sqlStr & "@INTERNAL_INSPECTION, "
            sqlStr = sqlStr & "@SIGNATURE_INSERVICE_ESTIMATE, "
            sqlStr = sqlStr & "@WHOLE_SERVICE_FEE_ADR_COLLECTION, "
            sqlStr = sqlStr & "@GSX_ORDER, "
            sqlStr = sqlStr & "@REPAIR, "
            sqlStr = sqlStr & "@REMAINING_AMOUNT_COLLECTION, "
            sqlStr = sqlStr & "@LOANER_COLLECTION, "
            sqlStr = sqlStr & "@SEVICE_REPORT, "
            sqlStr = sqlStr & "@TAX_INVOICE, "




            sqlStr = sqlStr & "@ADVANCE_PAYMENT, "

            sqlStr = sqlStr & "@LABOR_AMOUNT, "
            sqlStr = sqlStr & "@LABOR_DETAIL, "
            sqlStr = sqlStr & "@LABOR_COST, "
            sqlStr = sqlStr & "@LABOR_DISCOUNT, "
            sqlStr = sqlStr & "@LABOR_SALES, "
            sqlStr = sqlStr & "@LABOR_SGST, "
            sqlStr = sqlStr & "@LABOR_CGST, "
            sqlStr = sqlStr & "@LABOR_IGST, "

            sqlStr = sqlStr & "@PART1_TAX, "
            sqlStr = sqlStr & "@PART2_TAX, "
            sqlStr = sqlStr & "@PART3_TAX, "
            sqlStr = sqlStr & "@PART4_TAX, "
            sqlStr = sqlStr & "@LABOUR_TAX, "
            sqlStr = sqlStr & "@OTHER_TAX, "



            sqlStr = sqlStr & "@LABOR_TOTAL, "
            sqlStr = sqlStr & "@PART_COST_1, "
            sqlStr = sqlStr & "@PART_COST_2, "
            sqlStr = sqlStr & "@PART_COST_3, "
            sqlStr = sqlStr & "@PART_COST_4, "
            sqlStr = sqlStr & "@PART_COST_SALES_1, "
            sqlStr = sqlStr & "@PART_COST_SALES_2, "
            sqlStr = sqlStr & "@PART_COST_SALES_3, "
            sqlStr = sqlStr & "@PART_COST_SALES_4, "
            sqlStr = sqlStr & "@PART_SGST_1, "
            sqlStr = sqlStr & "@PART_SGST_2, "
            sqlStr = sqlStr & "@PART_SGST_3, "
            sqlStr = sqlStr & "@PART_SGST_4, "
            sqlStr = sqlStr & "@PART_CGST_1, "
            sqlStr = sqlStr & "@PART_CGST_2, "
            sqlStr = sqlStr & "@PART_CGST_3, "
            sqlStr = sqlStr & "@PART_CGST_4, "
            sqlStr = sqlStr & "@PART_IGST_1, "
            sqlStr = sqlStr & "@PART_IGST_2, "
            sqlStr = sqlStr & "@PART_IGST_3, "
            sqlStr = sqlStr & "@PART_IGST_4, "
            sqlStr = sqlStr & "@PART_TOTAL_1, "
            sqlStr = sqlStr & "@PART_TOTAL_2, "
            sqlStr = sqlStr & "@PART_TOTAL_3, "
            sqlStr = sqlStr & "@PART_TOTAL_4, "
            sqlStr = sqlStr & "@PART_QTY_AMOUNT, "
            sqlStr = sqlStr & "@PART_COST_AMOUNT, "
            sqlStr = sqlStr & "@PART_DISCOUNT_AMOUNT, "
            sqlStr = sqlStr & "@PART_SALES_AMOUNT, "
            sqlStr = sqlStr & "@PART_SGST_AMOUNT, "
            sqlStr = sqlStr & "@PART_CGST_AMOUNT, "
            sqlStr = sqlStr & "@PART_IGST_AMOUNT, "
            sqlStr = sqlStr & "@PART_TOTAL, "
            sqlStr = sqlStr & "@OTHER_QTY_AMOUNT, "
            sqlStr = sqlStr & "@OTHER_DETAIL, "
            sqlStr = sqlStr & "@OTHER_COST, "
            sqlStr = sqlStr & "@OTHER_DISCOUNT, "
            sqlStr = sqlStr & "@OTHER_SALES, "
            sqlStr = sqlStr & "@OTHER_SGST, "
            sqlStr = sqlStr & "@OTHER_CGST, "
            sqlStr = sqlStr & "@OTHER_IGST, "
            sqlStr = sqlStr & "@OTHER_TOTAL, "
            sqlStr = sqlStr & "@TOTAL_QTY, "
            sqlStr = sqlStr & "@TOTAL_COST_AMOUNT, "
            sqlStr = sqlStr & "@TOTAL_DISCOUNT_AMOUNT, "

            sqlStr = sqlStr & "@TOTAL_SALES_AMOUNT, "
            sqlStr = sqlStr & "@TOTAL_SGST_AMOUNT, "
            sqlStr = sqlStr & "@TOTAL_CGST_AMOUNT, "
            sqlStr = sqlStr & "@TOTAL_IGST_AMOUNT, "
            sqlStr = sqlStr & "@TOTAL_AMOUNT, "
            sqlStr = sqlStr & "@DELIVERY_DATE, "
            sqlStr = sqlStr & "@COMP_STATUS, "
            sqlStr = sqlStr & "@COMP_DATE, "
            sqlStr = sqlStr & "@DENOMINATION, "
            sqlStr = sqlStr & "@ESTIMATE_DATE, "
            sqlStr = sqlStr & "@ESTIMATE_TIME, "
            sqlStr = sqlStr & "@GSX_CLOSE_DATE, "
            sqlStr = sqlStr & "@USE_SERVICE_TYPE, "
            sqlStr = sqlStr & "@INVOICE_NOTE, "
            sqlStr = sqlStr & "@GSX_NOTE, "
            sqlStr = sqlStr & "@HSN_SAC_CODE, "
            sqlStr = sqlStr & "@GSTIN, "

            sqlStr = sqlStr & "@IP_ADDRESS "
            sqlStr = sqlStr & " )"



        Else
            sqlStr = " "
            sqlStr = sqlStr & "declare @PART1_STATUS bit "
            sqlStr = sqlStr & "declare @PART2_STATUS bit "
            sqlStr = sqlStr & "declare @PART3_STATUS bit "
            sqlStr = sqlStr & "declare @PART4_STATUS bit "
            sqlStr = sqlStr & " "
            sqlStr = sqlStr & "set @PART1_STATUS='true' "
            sqlStr = sqlStr & "set @PART2_STATUS='true' "
            sqlStr = sqlStr & "set @PART3_STATUS='true' "
            sqlStr = sqlStr & "set @PART4_STATUS='true' "
            sqlStr = sqlStr & " "
            sqlStr = sqlStr & "declare @GlobalStatus bit "
            sqlStr = sqlStr & "set @GlobalStatus='true' "
            sqlStr = sqlStr & " "
            sqlStr = sqlStr & "UPDATE AP_QMV_ORD SET  "

            sqlStr = sqlStr & "UPDDT = @UPDDT, "
            sqlStr = sqlStr & "UPDCD = @UPDCD, "
            sqlStr = sqlStr & "G_NO = @G_NO, "
            sqlStr = sqlStr & "CUSTOMER_NAME = @CUSTOMER_NAME, "
            sqlStr = sqlStr & "ZIP_CODE = @ZIP_CODE, "
            sqlStr = sqlStr & "MOBLIE_PHONE = @MOBLIE_PHONE, "
            sqlStr = sqlStr & "TELEPHONE = @TELEPHONE, "
            sqlStr = sqlStr & "ADD_1 = @ADD_1, "
            sqlStr = sqlStr & "ADD_2 = @ADD_2, "
            sqlStr = sqlStr & "CITY = @CITY, "
            sqlStr = sqlStr & "STATE = @STATE, "
            sqlStr = sqlStr & "STATE_CODE = @STATE_CODE, "
            sqlStr = sqlStr & "E_MAIL = @E_MAIL, "


            sqlStr = sqlStr & "IS_SHIP_DIFF = @IS_SHIP_DIFF, "
            sqlStr = sqlStr & "CUSTOMER_NAME_SHIP = @CUSTOMER_NAME_SHIP, "
            sqlStr = sqlStr & "ZIP_CODE_SHIP = @ZIP_CODE_SHIP, "
            sqlStr = sqlStr & "MOBLIE_PHONE_SHIP = @MOBLIE_PHONE_SHIP, "
            sqlStr = sqlStr & "TELEPHONE_SHIP = @TELEPHONE_SHIP, "
            sqlStr = sqlStr & "ADD_1_SHIP = @ADD_1_SHIP, "
            sqlStr = sqlStr & "ADD_2_SHIP = @ADD_2_SHIP, "
            sqlStr = sqlStr & "CITY_SHIP = @CITY_SHIP, "
            sqlStr = sqlStr & "STATE_SHIP = @STATE_SHIP, "
            sqlStr = sqlStr & "E_MAIL_SHIP = @E_MAIL_SHIP, "




            sqlStr = sqlStr & "MODEL_NAME = @MODEL_NAME, "
            sqlStr = sqlStr & "PRODUCT_NAME = @PRODUCT_NAME, "
            sqlStr = sqlStr & "SERIAL_NO = @SERIAL_NO, "
            sqlStr = sqlStr & "IMEI_1 = @IMEI_1, "
            sqlStr = sqlStr & "IMEI_2 = @IMEI_2, "
            sqlStr = sqlStr & "DATE_OF_PURCHASE = @DATE_OF_PURCHASE, "
            sqlStr = sqlStr & "SERVICE_TYPE = @SERVICE_TYPE, "
            sqlStr = sqlStr & "COMPTIA = @COMPTIA, "
            sqlStr = sqlStr & "COMPTIA_MODIFIER = @COMPTIA_MODIFIER, "
            sqlStr = sqlStr & "ACCESSORY_NOTE = @ACCESSORY_NOTE, "

            sqlStr = sqlStr & "PART_NO1 = @PART_NO1, "
            sqlStr = sqlStr & "PART_NO2 = @PART_NO2, "
            sqlStr = sqlStr & "PART_NO3 = @PART_NO3, "
            sqlStr = sqlStr & "PART_NO4 = @PART_NO4, "
            sqlStr = sqlStr & "PART_DETAIL_1 = @PART_DETAIL_1, "
            sqlStr = sqlStr & "PART_DETAIL_2 = @PART_DETAIL_2, "
            sqlStr = sqlStr & "PART_DETAIL_3 = @PART_DETAIL_3, "
            sqlStr = sqlStr & "PART_DETAIL_4 = @PART_DETAIL_4, "
            sqlStr = sqlStr & "PART_QTY_1 = @PART_QTY_1, "
            sqlStr = sqlStr & "PART_QTY_2 = @PART_QTY_2, "
            sqlStr = sqlStr & "PART_QTY_3 = @PART_QTY_3, "
            sqlStr = sqlStr & "PART_QTY_4 = @PART_QTY_4, "



            sqlStr = sqlStr & "SERIAL_STOCK_USED_1 = @SERIAL_STOCK_USED_1, "
            sqlStr = sqlStr & "SERIAL_STOCK_USED_2 = @SERIAL_STOCK_USED_2, "
            sqlStr = sqlStr & "SERIAL_STOCK_USED_3 = @SERIAL_STOCK_USED_3, "
            sqlStr = sqlStr & "SERIAL_STOCK_USED_4 = @SERIAL_STOCK_USED_4, "

            'sqlStr = sqlStr & "PRICE_OPTIONS_1 = @PRICE_OPTIONS_1, "
            'sqlStr = sqlStr & "PRICE_OPTIONS_2 = @PRICE_OPTIONS_2, "
            'sqlStr = sqlStr & "PRICE_OPTIONS_3 = @PRICE_OPTIONS_3, "
            'sqlStr = sqlStr & "PRICE_OPTIONS_4 = @PRICE_OPTIONS_4, "

            sqlStr = sqlStr & "PRICE_OPTIONS_1_TYPE = @PRICE_OPTIONS_1_TYPE, "
            sqlStr = sqlStr & "PRICE_OPTIONS_2_TYPE = @PRICE_OPTIONS_2_TYPE, "
            sqlStr = sqlStr & "PRICE_OPTIONS_3_TYPE = @PRICE_OPTIONS_3_TYPE, "
            sqlStr = sqlStr & "PRICE_OPTIONS_4_TYPE = @PRICE_OPTIONS_4_TYPE, "


            sqlStr = sqlStr & "TRANSFER_REPAIR_CENTER = @TRANSFER_REPAIR_CENTER, "
            sqlStr = sqlStr & "ACTION_TAKEN = @ACTION_TAKEN, "
            sqlStr = sqlStr & "RECEPTION = @RECEPTION, "
            sqlStr = sqlStr & "INTERNAL_INSPECTION = @INTERNAL_INSPECTION, "
            sqlStr = sqlStr & "SIGNATURE_INSERVICE_ESTIMATE = @SIGNATURE_INSERVICE_ESTIMATE, "
            sqlStr = sqlStr & "WHOLE_SERVICE_FEE_ADR_COLLECTION = @WHOLE_SERVICE_FEE_ADR_COLLECTION, "
            sqlStr = sqlStr & "GSX_ORDER = @GSX_ORDER, "
            sqlStr = sqlStr & "REPAIR = @REPAIR, "
            sqlStr = sqlStr & "REMAINING_AMOUNT_COLLECTION = @REMAINING_AMOUNT_COLLECTION, "
            sqlStr = sqlStr & "LOANER_COLLECTION = @LOANER_COLLECTION, "
            sqlStr = sqlStr & "SEVICE_REPORT = @SEVICE_REPORT, "
            sqlStr = sqlStr & "TAX_INVOICE = @TAX_INVOICE, "

            sqlStr = sqlStr & "ADVANCE_PAYMENT = @ADVANCE_PAYMENT, "

            sqlStr = sqlStr & "LABOR_AMOUNT = @LABOR_AMOUNT, "
            sqlStr = sqlStr & "LABOR_DETAIL = @LABOR_DETAIL, "
            sqlStr = sqlStr & "LABOR_COST = @LABOR_COST, "
            sqlStr = sqlStr & "LABOR_DISCOUNT = @LABOR_DISCOUNT, "
            sqlStr = sqlStr & "LABOR_SALES = @LABOR_SALES, "
            sqlStr = sqlStr & "LABOR_SGST = @LABOR_SGST, "
            sqlStr = sqlStr & "LABOR_CGST = @LABOR_CGST, "
            sqlStr = sqlStr & "LABOR_IGST = @LABOR_IGST, "

            sqlStr = sqlStr & "PART1_TAX = @PART1_TAX, "
            sqlStr = sqlStr & "PART2_TAX = @PART2_TAX, "
            sqlStr = sqlStr & "PART3_TAX = @PART3_TAX, "
            sqlStr = sqlStr & "PART4_TAX = @PART4_TAX, "
            sqlStr = sqlStr & "LABOUR_TAX = @LABOUR_TAX, "
            sqlStr = sqlStr & "OTHER_TAX = @OTHER_TAX, "


            sqlStr = sqlStr & "LABOR_TOTAL = @LABOR_TOTAL, "
            sqlStr = sqlStr & "PART_COST_1 = @PART_COST_1, "
            sqlStr = sqlStr & "PART_COST_2 = @PART_COST_2, "
            sqlStr = sqlStr & "PART_COST_3 = @PART_COST_3, "
            sqlStr = sqlStr & "PART_COST_4 = @PART_COST_4, "
            sqlStr = sqlStr & "PART_COST_SALES_1 = @PART_COST_SALES_1, "
            sqlStr = sqlStr & "PART_COST_SALES_2 = @PART_COST_SALES_2, "
            sqlStr = sqlStr & "PART_COST_SALES_3 = @PART_COST_SALES_3, "
            sqlStr = sqlStr & "PART_COST_SALES_4 = @PART_COST_SALES_4, "
            sqlStr = sqlStr & "PART_SGST_1 = @PART_SGST_1, "
            sqlStr = sqlStr & "PART_SGST_2 = @PART_SGST_2, "
            sqlStr = sqlStr & "PART_SGST_3 = @PART_SGST_3, "
            sqlStr = sqlStr & "PART_SGST_4 = @PART_SGST_4, "
            sqlStr = sqlStr & "PART_CGST_1 = @PART_CGST_1, "
            sqlStr = sqlStr & "PART_CGST_2 = @PART_CGST_2, "
            sqlStr = sqlStr & "PART_CGST_3 = @PART_CGST_3, "
            sqlStr = sqlStr & "PART_CGST_4 = @PART_CGST_4, "
            sqlStr = sqlStr & "PART_IGST_1 = @PART_IGST_1, "
            sqlStr = sqlStr & "PART_IGST_2 = @PART_IGST_2, "
            sqlStr = sqlStr & "PART_IGST_3 = @PART_IGST_3, "
            sqlStr = sqlStr & "PART_IGST_4 = @PART_IGST_4, "
            sqlStr = sqlStr & "PART_TOTAL_1 = @PART_TOTAL_1, "
            sqlStr = sqlStr & "PART_TOTAL_2 = @PART_TOTAL_2, "
            sqlStr = sqlStr & "PART_TOTAL_3 = @PART_TOTAL_3, "
            sqlStr = sqlStr & "PART_TOTAL_4 = @PART_TOTAL_4, "
            sqlStr = sqlStr & "PART_QTY_AMOUNT = @PART_QTY_AMOUNT, "
            sqlStr = sqlStr & "PART_COST_AMOUNT = @PART_COST_AMOUNT, "
            sqlStr = sqlStr & "PART_DISCOUNT_AMOUNT = @PART_DISCOUNT_AMOUNT, "
            sqlStr = sqlStr & "PART_SALES_AMOUNT = @PART_SALES_AMOUNT, "
            sqlStr = sqlStr & "PART_SGST_AMOUNT = @PART_SGST_AMOUNT, "
            sqlStr = sqlStr & "PART_CGST_AMOUNT = @PART_CGST_AMOUNT, "
            sqlStr = sqlStr & "PART_IGST_AMOUNT = @PART_IGST_AMOUNT, "
            sqlStr = sqlStr & "PART_TOTAL = @PART_TOTAL, "
            sqlStr = sqlStr & "OTHER_QTY_AMOUNT = @OTHER_QTY_AMOUNT, "
            sqlStr = sqlStr & "OTHER_DETAIL = @OTHER_DETAIL, "
            sqlStr = sqlStr & "OTHER_COST = @OTHER_COST, "
            sqlStr = sqlStr & "OTHER_DISCOUNT = @OTHER_DISCOUNT, "


            sqlStr = sqlStr & "OTHER_SALES = @OTHER_SALES, "
            sqlStr = sqlStr & "OTHER_SGST = @OTHER_SGST, "
            sqlStr = sqlStr & "OTHER_CGST = @OTHER_CGST, "
            sqlStr = sqlStr & "OTHER_IGST = @OTHER_IGST, "
            sqlStr = sqlStr & "OTHER_TOTAL = @OTHER_TOTAL, "
            sqlStr = sqlStr & "TOTAL_QTY = @TOTAL_QTY, "
            sqlStr = sqlStr & "TOTAL_COST_AMOUNT = @TOTAL_COST_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_DISCOUNT_AMOUNT = @TOTAL_DISCOUNT_AMOUNT, "

            sqlStr = sqlStr & "TOTAL_SALES_AMOUNT = @TOTAL_SALES_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_SGST_AMOUNT = @TOTAL_SGST_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_CGST_AMOUNT = @TOTAL_CGST_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_IGST_AMOUNT = @TOTAL_IGST_AMOUNT, "
            sqlStr = sqlStr & "TOTAL_AMOUNT = @TOTAL_AMOUNT, "
            sqlStr = sqlStr & "DELIVERY_DATE = @DELIVERY_DATE, "
            sqlStr = sqlStr & "COMP_STATUS = @COMP_STATUS, "
            sqlStr = sqlStr & "COMP_DATE = @COMP_DATE, "
            sqlStr = sqlStr & "DENOMINATION = @DENOMINATION, "
            sqlStr = sqlStr & "ESTIMATE_DATE = @ESTIMATE_DATE, "
            sqlStr = sqlStr & "ESTIMATE_TIME = @ESTIMATE_TIME, "
            sqlStr = sqlStr & "GSX_CLOSE_DATE = @GSX_CLOSE_DATE, "
            sqlStr = sqlStr & "USE_SERVICE_TYPE = @USE_SERVICE_TYPE, "
            sqlStr = sqlStr & "INVOICE_NOTE = @INVOICE_NOTE, "
            sqlStr = sqlStr & "GSX_NOTE = @GSX_NOTE, "
            sqlStr = sqlStr & "HSN_SAC_CODE = @HSN_SAC_CODE, "
            sqlStr = sqlStr & "GSTIN = @GSTIN, "
            sqlStr = sqlStr & "IP_ADDRESS = @IP_ADDRESS, "
            sqlStr = sqlStr & "PART_HSN_ASC_1 = @PART_HSN_ASC_1, "
            sqlStr = sqlStr & "PART_HSN_ASC_2 = @PART_HSN_ASC_2, "
            sqlStr = sqlStr & "PART_HSN_ASC_3 = @PART_HSN_ASC_3, "
            sqlStr = sqlStr & "PART_HSN_ASC_4 = @PART_HSN_ASC_4 "


            sqlStr = sqlStr & " WHERE PO_NO = @PO_NO "
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE"





        End If

        If queryParams.INVENTORY_FLG Then
            If (queryParams.COMP_STATUS <> 0) Then
                'PART1
                If (queryParams.PART_QTY_1 <> "") And (queryParams.PART_NO1 <> "") And (queryParams.PART_DETAIL_1 <> "") Then
                    sqlStr = sqlStr & " "
                    sqlStr = sqlStr & " "

                    If queryParams.SERVICE_TYPE = "5" Then 'Acc Accessories
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty1 int "
                        sqlStr = sqlStr & "set @DeductQty1=" & queryParams.PART_QTY_1 & " "
                        sqlStr = sqlStr & "declare @BalanceQty1 int "
                        sqlStr = sqlStr & "set @BalanceQty1=(SELECT TOP 1 isnull(CURRENT_IN_STOCK,0) AS BALANCE FROM AC_PARTS_MST WHERE DELFG=0 AND PART_NO=@PART_NO1 ORDER BY BALANCE DESC) "
                        sqlStr = sqlStr & "if (@DeductQty1 > @BalanceQty1) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART1_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "

                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "declare @StockImp1 int "
                        sqlStr = sqlStr & "set @StockImp1= (SELECT COUNT(UNQ_NO) FROM AC_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO1 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp1=0) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "INSERT INTO AC_STOCK_TRAN  "
                        sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF) "
                        sqlStr = sqlStr & "VALUES "
                        sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO1,@PART_DETAIL_1,@PART_QTY_1,2,@PO_NO ) "
                        sqlStr = sqlStr & "UPDATE AC_PARTS_MST SET CURRENT_IN_STOCK=(isnull(CURRENT_IN_STOCK,0) - @PART_QTY_1),LAST_OUT_DATE=@CRTDT,NUMBER_SOLD_SO_FAR=(isnull(NUMBER_SOLD_SO_FAR,0) + @PART_QTY_1 ) WHERE PART_NO=@PART_NO1 AND DESCRIPTION=@PART_DETAIL_1  "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "

                    ElseIf (queryParams.SERVICE_TYPE = "1") Or (queryParams.SERVICE_TYPE = "3") Then '(1) IW-In Warranty /  (3) AC+-AppleCareProtectionPlan
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty1 int "
                        sqlStr = sqlStr & "set @DeductQty1=" & queryParams.PART_QTY_1 & " "
                        sqlStr = sqlStr & "declare @BalanceQty1 int "
                        If queryParams.SERIAL_STOCK_USED_1 Then
                            sqlStr = sqlStr & "declare @SerialNo1 nvarchar(100) "
                            sqlStr = sqlStr & "set @BalanceQty1=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO1 ORDER BY BALANCE DESC) "
                            sqlStr = sqlStr & "set @SerialNo1=(SELECT TOP 1 SERIAL_NO FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO1 ORDER BY BALANCE DESC) "
                        Else
                            sqlStr = sqlStr & "set @BalanceQty1=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y'  AND PARTS_NO=@PART_NO1  ORDER BY BALANCE DESC) "
                        End If
                        sqlStr = sqlStr & "if (@DeductQty1 > @BalanceQty1) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "

                        sqlStr = sqlStr & "set @PART1_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "

                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "declare @StockImp1 int "
                        sqlStr = sqlStr & "set @StockImp1= (SELECT COUNT(UNQ_NO) FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO1 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp1=0) "
                        sqlStr = sqlStr & "begin "
                        If queryParams.SERIAL_STOCK_USED_1 Then
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE,SERIAL_NO) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO1,@PART_DETAIL_1,@PART_QTY_1,2,@PO_NO,'1',@SerialNo1 ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_CONSIGNMENT_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_1) WHERE  DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y'  AND  PARTS_NO=@PART_NO1 AND PARTS_DETAIL=@PART_DETAIL_1 AND SERIAL_NO=@SerialNo1 "
                        Else
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO1,@PART_DETAIL_1,@PART_QTY_1,2,@PO_NO,'1' ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_CONSIGNMENT_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_1) WHERE  DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N'  AND PARTS_NO=@PART_NO1 AND PARTS_DETAIL=@PART_DETAIL_1  "
                        End If

                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "


                    ElseIf (queryParams.SERVICE_TYPE = "2") Then 'OOW-Out Of Warranty
                            sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty1 int "
                        sqlStr = sqlStr & "set @DeductQty1=" & queryParams.PART_QTY_1 & " "
                        sqlStr = sqlStr & "declare @BalanceQty1 int "
                        If queryParams.SERIAL_STOCK_USED_1 Then
                            sqlStr = sqlStr & "declare @SerialNo1 nvarchar(100) "
                            sqlStr = sqlStr & "set @BalanceQty1=(SELECT isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO1) "
                            sqlStr = sqlStr & "set @SerialNo1=(SELECT TOP 1 SERIAL_NO FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO1) "
                        Else
                            sqlStr = sqlStr & "set @BalanceQty1=(SELECT isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO1) "
                        End If
                        sqlStr = sqlStr & "if (@DeductQty1 > @BalanceQty1) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART1_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "

                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "declare @StockImp1 int "
                        sqlStr = sqlStr & "set @StockImp1= (SELECT COUNT(UNQ_NO) FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO1 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp1=0) "
                        sqlStr = sqlStr & "begin "
                        If queryParams.SERIAL_STOCK_USED_1 Then
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE,SERIAL_NO) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO1,@PART_DETAIL_1,@PART_QTY_1,2,@PO_NO,'2',@SerialNo1 ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_STOCK_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_1) WHERE DELFG=0  AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO1 AND PARTS_DETAIL=@PART_DETAIL_1 AND SERIAL_NO=@SerialNo1 "
                        Else
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO1,@PART_DETAIL_1,@PART_QTY_1,2,@PO_NO,'2' ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_STOCK_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_1) WHERE DELFG=0  AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO1 AND PARTS_DETAIL=@PART_DETAIL_1  "
                        End If

                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "


                    End If

                End If

                'PART2
                If (queryParams.PART_QTY_2 <> "") And (queryParams.PART_NO2 <> "") And (queryParams.PART_DETAIL_2 <> "") Then
                    sqlStr = sqlStr & " "
                    sqlStr = sqlStr & " "
                    If queryParams.SERVICE_TYPE = "5" Then 'Acc Accessories
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty2 int "
                        sqlStr = sqlStr & "set @DeductQty2=" & queryParams.PART_QTY_2 & " "
                        sqlStr = sqlStr & "declare @BalanceQty2 int "
                        sqlStr = sqlStr & "set @BalanceQty2=(SELECT TOP 1 isnull(CURRENT_IN_STOCK,0) AS BALANCE FROM AC_PARTS_MST WHERE DELFG=0 AND PART_NO=@PART_NO2 ORDER BY BALANCE DESC) "
                        sqlStr = sqlStr & "if (@DeductQty2 > @BalanceQty2) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART2_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & " "

                        sqlStr = sqlStr & "declare @StockImp2 int "
                        sqlStr = sqlStr & "set @StockImp2= (SELECT COUNT(UNQ_NO) FROM AC_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO2 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp2=0) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "INSERT INTO AC_STOCK_TRAN  "
                        sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF) "
                        sqlStr = sqlStr & "VALUES "
                        sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO2,@PART_DETAIL_2,@PART_QTY_2,2,@PO_NO ) "
                        sqlStr = sqlStr & "UPDATE AC_PARTS_MST SET CURRENT_IN_STOCK=(isnull(CURRENT_IN_STOCK,0) - @PART_QTY_2),LAST_OUT_DATE=@CRTDT,NUMBER_SOLD_SO_FAR=(isnull(NUMBER_SOLD_SO_FAR,0) + @PART_QTY_2 ) WHERE PART_NO=@PART_NO2 AND DESCRIPTION=@PART_DETAIL_2  "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "

                    ElseIf (queryParams.SERVICE_TYPE = "1") Or (queryParams.SERVICE_TYPE = "3") Then '(1) IW-In Warranty /  (3) AC+-AppleCareProtectionPlan
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty2 int "
                        sqlStr = sqlStr & "set @DeductQty2=" & queryParams.PART_QTY_2 & " "
                        sqlStr = sqlStr & "declare @BalanceQty2 int "
                        If queryParams.SERIAL_STOCK_USED_2 Then
                            sqlStr = sqlStr & "declare @SerialNo2 nvarchar(100) "
                            sqlStr = sqlStr & "set @BalanceQty2=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND  BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO2 ORDER BY BALANCE DESC) "
                            sqlStr = sqlStr & "set @SerialNo2=(SELECT TOP 1 SERIAL_NO FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND  BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO2 ORDER BY BALANCE DESC) "
                        Else
                            sqlStr = sqlStr & "set @BalanceQty2=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO2 ORDER BY BALANCE DESC) "
                        End If
                        sqlStr = sqlStr & "if (@DeductQty2 > @BalanceQty2) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART2_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "

                        sqlStr = sqlStr & " "

                        sqlStr = sqlStr & "declare @StockImp2 int "
                        sqlStr = sqlStr & "set @StockImp2= (SELECT COUNT(UNQ_NO) FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO2 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp2=0) "
                        sqlStr = sqlStr & "begin "
                        If queryParams.SERIAL_STOCK_USED_2 Then
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE,SERIAL_NO) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO2,@PART_DETAIL_2,@PART_QTY_2,2,@PO_NO,'1',@SerialNo2 ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_CONSIGNMENT_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_2) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO2 AND PARTS_DETAIL=@PART_DETAIL_2 AND SERIAL_NO=@SerialNo2 "
                            sqlStr = sqlStr & "end "
                            sqlStr = sqlStr & "end "
                            sqlStr = sqlStr & "end "
                            sqlStr = sqlStr & " "
                        Else
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO2,@PART_DETAIL_2,@PART_QTY_2,2,@PO_NO,'1' ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_CONSIGNMENT_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_2) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO2 AND PARTS_DETAIL=@PART_DETAIL_2  "
                            sqlStr = sqlStr & "end "
                            sqlStr = sqlStr & "end "
                            sqlStr = sqlStr & "end "
                            sqlStr = sqlStr & " "
                        End If






                    ElseIf (queryParams.SERVICE_TYPE = "2") Then 'OOW-Out Of Warranty
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty2 int "
                        sqlStr = sqlStr & "set @DeductQty2=" & queryParams.PART_QTY_1 & " "
                        sqlStr = sqlStr & "declare @BalanceQty2 int "
                        If queryParams.SERIAL_STOCK_USED_2 Then
                            sqlStr = sqlStr & "declare @SerialNo2 nvarchar(100) "
                            sqlStr = sqlStr & "set @BalanceQty2=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO2 ORDER BY BALANCE DESC) "
                            sqlStr = sqlStr & "set @SerialNo2=(SELECT TOP 1 SERIAL_NO FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO2 ORDER BY BALANCE DESC) "
                        Else
                            sqlStr = sqlStr & "set @BalanceQty2=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO2 ORDER BY BALANCE DESC) "
                        End If
                        sqlStr = sqlStr & "if (@DeductQty2 > @BalanceQty2) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART2_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @StockImp2 int "
                        sqlStr = sqlStr & "set @StockImp2= (SELECT COUNT(UNQ_NO) FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO2 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp2=0) "
                        sqlStr = sqlStr & "begin "

                        If queryParams.SERIAL_STOCK_USED_2 Then
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE,SERIAL_NO) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO2,@PART_DETAIL_2,@PART_QTY_2,2,@PO_NO,'2',@SerialNo2 ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_STOCK_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_2) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO2 AND PARTS_DETAIL=@PART_DETAIL_2 AND SERIAL_NO=@SerialNo2 "
                        Else
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO2,@PART_DETAIL_2,@PART_QTY_2,2,@PO_NO,'2' ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_STOCK_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_2) WHERE DELFG=0  AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO2 AND PARTS_DETAIL=@PART_DETAIL_2  "
                        End If


                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "
                    End If
                End If
                'PART3
                If (queryParams.PART_QTY_3 <> "") And (queryParams.PART_NO3 <> "") And (queryParams.PART_DETAIL_3 <> "") Then
                    sqlStr = sqlStr & " "
                    sqlStr = sqlStr & " "
                    If queryParams.SERVICE_TYPE = "5" Then 'Acc Accessories
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty3 int "
                        sqlStr = sqlStr & "set @DeductQty3=" & queryParams.PART_QTY_3 & " "
                        sqlStr = sqlStr & "declare @BalanceQty3 int "
                        sqlStr = sqlStr & "set @BalanceQty3=(SELECT TOP 1 isnull(CURRENT_IN_STOCK,0) AS BALANCE FROM AC_PARTS_MST WHERE DELFG=0 AND PART_NO=@PART_NO3 ORDER BY BALANCE DESC) "
                        sqlStr = sqlStr & "if (@DeductQty3 > @BalanceQty3) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART3_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "declare @StockImp3 int "
                        sqlStr = sqlStr & "set @StockImp3= (SELECT COUNT(UNQ_NO) FROM AC_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO3 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp3=0) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "INSERT INTO AC_STOCK_TRAN  "
                        sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF) "
                        sqlStr = sqlStr & "VALUES "
                        sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO3,@PART_DETAIL_3,@PART_QTY_3,2,@PO_NO ) "
                        sqlStr = sqlStr & "UPDATE AC_PARTS_MST SET CURRENT_IN_STOCK=(isnull(CURRENT_IN_STOCK,0) - @PART_QTY_3),LAST_OUT_DATE=@CRTDT,NUMBER_SOLD_SO_FAR=(isnull(NUMBER_SOLD_SO_FAR,0) + @PART_QTY_3 ) WHERE PART_NO=@PART_NO3 AND DESCRIPTION=@PART_DETAIL_3  "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "


                    ElseIf (queryParams.SERVICE_TYPE = "1") Or (queryParams.SERVICE_TYPE = "3") Then '(1) IW-In Warranty /  (3) AC+-AppleCareProtectionPlan
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty3 int "
                        sqlStr = sqlStr & "set @DeductQty3=" & queryParams.PART_QTY_3 & " "
                        sqlStr = sqlStr & "declare @BalanceQty3 int "
                        If queryParams.SERIAL_STOCK_USED_3 Then
                            sqlStr = sqlStr & "declare @SerialNo3 nvarchar(100) "
                            sqlStr = sqlStr & "set @BalanceQty3=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND  BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO3 ORDER BY BALANCE DESC) "
                            sqlStr = sqlStr & "set @SerialNo3=(SELECT TOP 1 SERIAL_NO FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND  BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO3 ORDER BY BALANCE DESC) "

                        Else
                            sqlStr = sqlStr & "set @BalanceQty3=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO3 ORDER BY BALANCE DESC) "
                        End If
                        sqlStr = sqlStr & "if (@DeductQty3 > @BalanceQty3) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART3_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "

                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "declare @StockImp3 int "
                        sqlStr = sqlStr & "set @StockImp3= (SELECT COUNT(UNQ_NO) FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO3 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp3=0) "
                        sqlStr = sqlStr & "begin "
                        If queryParams.SERIAL_STOCK_USED_3 Then
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE,SERIAL_NO) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO3,@PART_DETAIL_3,@PART_QTY_3,2,@PO_NO,'1',@SerialNo3 ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_CONSIGNMENT_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_3) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO3 AND PARTS_DETAIL=@PART_DETAIL_3 AND SERIAL_NO=@SerialNo3 "

                        Else
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO3,@PART_DETAIL_3,@PART_QTY_3,2,@PO_NO,'1' ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_CONSIGNMENT_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_3) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO3 AND PARTS_DETAIL=@PART_DETAIL_3  "

                        End If
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "

                    ElseIf (queryParams.SERVICE_TYPE = "2") Then 'OOW-Out Of Warranty
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty3 int "
                        sqlStr = sqlStr & "set @DeductQty3=" & queryParams.PART_QTY_3 & " "
                        sqlStr = sqlStr & "declare @BalanceQty3 int "
                        If queryParams.SERIAL_STOCK_USED_3 Then
                            sqlStr = sqlStr & "declare @SerialNo3 nvarchar(100) "
                            sqlStr = sqlStr & "set @BalanceQty3=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO3 ORDER BY BALANCE DESC) "
                            sqlStr = sqlStr & "set @SerialNo3=(SELECT TOP 1 SERIAL_NO FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO3 ORDER BY BALANCE DESC) "
                        Else
                            sqlStr = sqlStr & "set @BalanceQty3=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO3 ORDER BY BALANCE DESC) "
                        End If
                        sqlStr = sqlStr & "if (@DeductQty3 > @BalanceQty3) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART3_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "

                        sqlStr = sqlStr & "declare @StockImp3 int "
                        sqlStr = sqlStr & "set @StockImp3= (SELECT COUNT(UNQ_NO) FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO3 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp3=0) "
                        sqlStr = sqlStr & "begin "
                        If queryParams.SERIAL_STOCK_USED_3 Then
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE,SERIAL_NO) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO3,@PART_DETAIL_3,@PART_QTY_3,2,@PO_NO,'2',@SerialNo3 ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_STOCK_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_3) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO3 AND PARTS_DETAIL=@PART_DETAIL_3 AND SERIAL_NO=@SerialNo3 "

                        Else
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO3,@PART_DETAIL_3,@PART_QTY_3,2,@PO_NO,'2' ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_STOCK_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_3) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO3 AND PARTS_DETAIL=@PART_DETAIL_3  "

                        End If
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "
                    End If
                End If
                'PART4
                If (queryParams.PART_QTY_4 <> "") And (queryParams.PART_NO4 <> "") And (queryParams.PART_DETAIL_4 <> "") Then
                    sqlStr = sqlStr & " "
                    sqlStr = sqlStr & " "
                    If queryParams.SERVICE_TYPE = "5" Then 'Acc Accessories
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty4 int "
                        sqlStr = sqlStr & "set @DeductQty4=" & queryParams.PART_QTY_4 & " "
                        sqlStr = sqlStr & "declare @BalanceQty4 int "
                        sqlStr = sqlStr & "set @BalanceQty4=(SELECT TOP 1 isnull(CURRENT_IN_STOCK,0) AS BALANCE FROM AC_PARTS_MST WHERE DELFG=0 AND PART_NO=@PART_NO4 ORDER BY BALANCE DESC ) "
                        sqlStr = sqlStr & "if (@DeductQty4 > @BalanceQty4) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART4_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "declare @StockImp4 int "
                        sqlStr = sqlStr & "set @StockImp4= (SELECT COUNT(UNQ_NO) FROM AC_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO4 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp4=0) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "INSERT INTO AC_STOCK_TRAN  "
                        sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF) "
                        sqlStr = sqlStr & "VALUES "
                        sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO4,@PART_DETAIL_4,@PART_QTY_4,2,@PO_NO ) "
                        sqlStr = sqlStr & "UPDATE AC_PARTS_MST SET CURRENT_IN_STOCK=(isnull(CURRENT_IN_STOCK,0) - @PART_QTY_4),LAST_OUT_DATE=@CRTDT,NUMBER_SOLD_SO_FAR=(isnull(NUMBER_SOLD_SO_FAR,0) + @PART_QTY_4 ) WHERE PART_NO=@PART_NO4 AND DESCRIPTION=@PART_DETAIL_4  "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "
                    ElseIf (queryParams.SERVICE_TYPE = "1") Or (queryParams.SERVICE_TYPE = "3") Then '(1) IW-In Warranty /  (3) AC+-AppleCareProtectionPlan
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty4 int "
                        sqlStr = sqlStr & "set @DeductQty4=" & queryParams.PART_QTY_3 & " "
                        sqlStr = sqlStr & "declare @BalanceQty4 int "
                        If queryParams.SERIAL_STOCK_USED_4 Then
                            sqlStr = sqlStr & "declare @SerialNo4 nvarchar(100) "
                            sqlStr = sqlStr & "set @BalanceQty4=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND  BALANCE !=0 AND SERIAL_TYPE = 'Y' ANDD PARTS_NO=@PART_NO4 ORDER BY BALANCE DESC ) "
                            sqlStr = sqlStr & "set @SerialNo4=(SELECT TOP 1 SERIAL_NO FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND  BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO4 ORDER BY BALANCE DESC ) "
                        Else
                            sqlStr = sqlStr & "set @BalanceQty4=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_CONSIGNMENT_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO4 ORDER BY BALANCE DESC ) "
                        End If
                        sqlStr = sqlStr & "if (@DeductQty4 > @BalanceQty4) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART4_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "

                        sqlStr = sqlStr & " "

                        sqlStr = sqlStr & "declare @StockImp4 int "
                        sqlStr = sqlStr & "set @StockImp4= (SELECT COUNT(UNQ_NO) FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO4 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp4=0) "
                        sqlStr = sqlStr & "begin "
                        If queryParams.SERIAL_STOCK_USED_4 Then
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE,SERIAL_NO) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO4,@PART_DETAIL_4,@PART_QTY_4,2,@PO_NO,'1',@SerialNo4 ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_CONSIGNMENT_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_4) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO4 AND PARTS_DETAIL=@PART_DETAIL_4 AND SERIAL_NO=@SerialNo4 "
                        Else
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO4,@PART_DETAIL_4,@PART_QTY_4,2,@PO_NO,'1' ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_CONSIGNMENT_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_4) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO4 AND PARTS_DETAIL=@PART_DETAIL_4  "

                        End If
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "

                    ElseIf (queryParams.SERVICE_TYPE = "2") Then 'OOW-Out Of Warranty
                        sqlStr = sqlStr & " "
                        sqlStr = sqlStr & "if (@GlobalStatus='true') "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @DeductQty4 int "
                        sqlStr = sqlStr & "set @DeductQty4=" & queryParams.PART_QTY_4 & " "
                        sqlStr = sqlStr & "declare @BalanceQty4 int "
                        If queryParams.SERIAL_STOCK_USED_4 Then
                            sqlStr = sqlStr & "declare @SerialNo4 nvarchar(100) "
                            sqlStr = sqlStr & "set @BalanceQty4=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_STOCK_MST WHERE  DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO4 ORDER BY BALANCE DESC ) "
                            sqlStr = sqlStr & "set @SerialNo4=(SELECT TOP 1 SERIAL_NO FROM AP_PARTS_STOCK_MST WHERE  DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO4 ORDER BY BALANCE DESC ) "
                        Else
                            sqlStr = sqlStr & "set @BalanceQty4=(SELECT TOP 1 isnull(BALANCE,0) AS BALANCE FROM AP_PARTS_STOCK_MST WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO4 ORDER BY BALANCE DESC ) "
                        End If
                        sqlStr = sqlStr & "if (@DeductQty4 > @BalanceQty4) "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "set @GlobalStatus='false' "
                        sqlStr = sqlStr & "set @PART4_STATUS='false' "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "else "
                        sqlStr = sqlStr & "begin "
                        sqlStr = sqlStr & "declare @StockImp4 int "
                        sqlStr = sqlStr & "set @StockImp4= (SELECT COUNT(UNQ_NO) FROM AP_PARTS_CONSIGNMENT_STOCK_TRAN WHERE  TRAN_TYPE=2 AND PART_NO=@PART_NO4 AND TRAN_REF=@PO_NO ) "
                        sqlStr = sqlStr & "if  ( @StockImp4=0) "
                        sqlStr = sqlStr & "begin "
                        If queryParams.SERIAL_STOCK_USED_4 Then
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE,SERIAL_NO) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO4,@PART_DETAIL_4,@PART_QTY_4,2,@PO_NO,'2',@SerialNo4 ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_STOCK_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_4) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'Y' AND PARTS_NO=@PART_NO4 AND PARTS_DETAIL=@PART_DETAIL_4 AND SERIAL_NO=@SerialNo4 "
                        Else
                            sqlStr = sqlStr & "INSERT INTO AP_PARTS_CONSIGNMENT_STOCK_TRAN  "
                            sqlStr = sqlStr & "(CRTDT,CRTCD,UPDDT,UPDCD,UPDPG,DELFG,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,PART_NO,DESCRIPTION,QUANTITY,TRAN_TYPE,TRAN_REF,STOCK_TYPE) "
                            sqlStr = sqlStr & "VALUES "
                            sqlStr = sqlStr & "(@CRTDT,@CRTCD,@UPDDT,@UPDCD,@UPDPG,0,@SHIP_TO_BRANCH_CODE,@SHIP_TO_BRANCH,@PART_NO4,@PART_DETAIL_4,@PART_QTY_4,2,@PO_NO,'2' ) "
                            sqlStr = sqlStr & "UPDATE AP_PARTS_STOCK_MST SET BALANCE=(isnull(BALANCE,0) - @PART_QTY_4) WHERE DELFG=0 AND BALANCE !=0 AND SERIAL_TYPE = 'N' AND PARTS_NO=@PART_NO4 AND PARTS_DETAIL=@PART_DETAIL_4  "
                        End If
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & "end "
                        sqlStr = sqlStr & " "
                    End If
                End If
            End If
        End If




        sqlStr = sqlStr & " "
        sqlStr = sqlStr & "IF  ((@PART1_STATUS=1) AND (@PART2_STATUS=1) AND (@PART3_STATUS=1) AND (@PART4_STATUS=1)) "
        sqlStr = sqlStr & "BEGIN "
        sqlStr = sqlStr & "SELECT '0' AS STATUS "
        sqlStr = sqlStr & "END "
        sqlStr = sqlStr & "ELSE "
        sqlStr = sqlStr & "BEGIN "
        sqlStr = sqlStr & "SELECT '1' AS STATUS "
        sqlStr = sqlStr & "END "
        sqlStr = sqlStr & " "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UserId)) '?????????????????????????
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", "999999999")) 'queryParams.SHIP_TO_BRANCH_CODE
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", "ASP1")) 'queryParams.SHIP_TO_BRANCH



        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_DATE", queryParams.PO_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@G_NO", queryParams.G_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_NAME", queryParams.CUSTOMER_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ZIP_CODE", queryParams.ZIP_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MOBLIE_PHONE", queryParams.MOBLIE_PHONE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TELEPHONE", queryParams.TELEPHONE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ADD_1", queryParams.ADD_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ADD_2", queryParams.ADD_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CITY", queryParams.CITY))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATE", queryParams.STATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATE_CODE", queryParams.STATE_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@E_MAIL", queryParams.E_MAIL))



        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IS_SHIP_DIFF", queryParams.IS_SHIP_DIFF))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_NAME_SHIP", queryParams.CUSTOMER_NAME_SHIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ZIP_CODE_SHIP", queryParams.ZIP_CODE_SHIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MOBLIE_PHONE_SHIP", queryParams.MOBLIE_PHONE_SHIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TELEPHONE_SHIP", queryParams.TELEPHONE_SHIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ADD_1_SHIP", queryParams.ADD_1_SHIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ADD_2_SHIP", queryParams.ADD_2_SHIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CITY_SHIP", queryParams.CITY_SHIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATE_SHIP", queryParams.STATE_SHIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@E_MAIL_SHIP", queryParams.E_MAIL_SHIP))






        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MODEL_NAME", queryParams.MODEL_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.PRODUCT_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IMEI_1", queryParams.IMEI_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IMEI_2", queryParams.IMEI_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DATE_OF_PURCHASE", queryParams.DATE_OF_PURCHASE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERVICE_TYPE", queryParams.SERVICE_TYPE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMPTIA", queryParams.COMPTIA))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMPTIA_MODIFIER", queryParams.COMPTIA_MODIFIER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ACCESSORY_NOTE", queryParams.ACCESSORY_NOTE))



        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO1", queryParams.PART_NO1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO2", queryParams.PART_NO2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO3", queryParams.PART_NO3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO4", queryParams.PART_NO4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DETAIL_1", queryParams.PART_DETAIL_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DETAIL_2", queryParams.PART_DETAIL_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DETAIL_3", queryParams.PART_DETAIL_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DETAIL_4", queryParams.PART_DETAIL_4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_QTY_1", queryParams.PART_QTY_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_QTY_2", queryParams.PART_QTY_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_QTY_3", queryParams.PART_QTY_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_QTY_4", queryParams.PART_QTY_4))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_STOCK_USED_1", queryParams.SERIAL_STOCK_USED_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_STOCK_USED_2", queryParams.SERIAL_STOCK_USED_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_STOCK_USED_3", queryParams.SERIAL_STOCK_USED_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_STOCK_USED_4", queryParams.SERIAL_STOCK_USED_4))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_1", queryParams.PART_DISCOUNT_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_2", queryParams.PART_DISCOUNT_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_3", queryParams.PART_DISCOUNT_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_4", queryParams.PART_DISCOUNT_4))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTIONS_1", queryParams.PRICE_OPTIONS_1))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTIONS_2", queryParams.PRICE_OPTIONS_2))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTIONS_3", queryParams.PRICE_OPTIONS_3))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTIONS_4", queryParams.PRICE_OPTIONS_4))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTIONS_1_TYPE", queryParams.PRICE_OPTIONS_1_TYPE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTIONS_2_TYPE", queryParams.PRICE_OPTIONS_2_TYPE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTIONS_3_TYPE", queryParams.PRICE_OPTIONS_3_TYPE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTIONS_4_TYPE", queryParams.PRICE_OPTIONS_4_TYPE))



        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRANSFER_REPAIR_CENTER", queryParams.TRANSFER_REPAIR_CENTER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ACTION_TAKEN", queryParams.ACTION_TAKEN))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@RECEPTION", queryParams.RECEPTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INTERNAL_INSPECTION", queryParams.INTERNAL_INSPECTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SIGNATURE_INSERVICE_ESTIMATE", queryParams.SIGNATURE_INSERVICE_ESTIMATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@WHOLE_SERVICE_FEE_ADR_COLLECTION", queryParams.WHOLE_SERVICE_FEE_ADR_COLLECTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@GSX_ORDER", queryParams.GSX_ORDER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REPAIR", queryParams.REPAIR))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REMAINING_AMOUNT_COLLECTION", queryParams.REMAINING_AMOUNT_COLLECTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LOANER_COLLECTION", queryParams.LOANER_COLLECTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SEVICE_REPORT", queryParams.SEVICE_REPORT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TAX_INVOICE", queryParams.TAX_INVOICE))



        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ADVANCE_PAYMENT", queryParams.ADVANCE_PAYMENT))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_AMOUNT", queryParams.LABOR_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_DETAIL", queryParams.LABOR_DETAIL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_COST", queryParams.LABOR_COST))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_DISCOUNT", queryParams.LABOR_DISCOUNT))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_SALES", queryParams.LABOR_SALES))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_SGST", queryParams.LABOR_SGST))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_CGST", queryParams.LABOR_CGST))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_IGST", queryParams.LABOR_IGST))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART1_TAX", queryParams.PART1_TAX))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART2_TAX", queryParams.PART2_TAX))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART3_TAX", queryParams.PART3_TAX))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART4_TAX", queryParams.PART4_TAX))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOUR_TAX", queryParams.LABOUR_TAX))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_TAX", queryParams.OTHER_TAX))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOR_TOTAL", queryParams.LABOR_TOTAL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_1", queryParams.PART_COST_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_2", queryParams.PART_COST_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_3", queryParams.PART_COST_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_4", queryParams.PART_COST_4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_SALES_1", queryParams.PART_COST_SALES_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_SALES_2", queryParams.PART_COST_SALES_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_SALES_3", queryParams.PART_COST_SALES_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_SALES_4", queryParams.PART_COST_SALES_4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_SGST_1", queryParams.PART_SGST_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_SGST_2", queryParams.PART_SGST_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_SGST_3", queryParams.PART_SGST_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_SGST_4", queryParams.PART_SGST_4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_CGST_1", queryParams.PART_CGST_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_CGST_2", queryParams.PART_CGST_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_CGST_3", queryParams.PART_CGST_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_CGST_4", queryParams.PART_CGST_4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_IGST_1", queryParams.PART_IGST_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_IGST_2", queryParams.PART_IGST_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_IGST_3", queryParams.PART_IGST_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_IGST_4", queryParams.PART_IGST_4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_TOTAL_1", queryParams.PART_TOTAL_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_TOTAL_2", queryParams.PART_TOTAL_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_TOTAL_3", queryParams.PART_TOTAL_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_TOTAL_4", queryParams.PART_TOTAL_4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_QTY_AMOUNT", queryParams.PART_QTY_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_COST_AMOUNT", queryParams.PART_COST_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_SALES_AMOUNT", queryParams.PART_SALES_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_AMOUNT", queryParams.PART_DISCOUNT_AMOUNT))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_SGST_AMOUNT", queryParams.PART_SGST_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_CGST_AMOUNT", queryParams.PART_CGST_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_IGST_AMOUNT", queryParams.PART_IGST_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_TOTAL", queryParams.PART_TOTAL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_QTY_AMOUNT", queryParams.OTHER_QTY_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_DETAIL", queryParams.OTHER_DETAIL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_COST", queryParams.OTHER_COST))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_DISCOUNT", queryParams.OTHER_DISCOUNT))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_SALES", queryParams.OTHER_SALES))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_SGST", queryParams.OTHER_SGST))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_CGST", queryParams.OTHER_CGST))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_IGST", queryParams.OTHER_IGST))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_TOTAL", queryParams.OTHER_TOTAL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOTAL_QTY", queryParams.TOTAL_QTY))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOTAL_COST_AMOUNT", queryParams.TOTAL_COST_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOTAL_DISCOUNT_AMOUNT", queryParams.TOTAL_DISCOUNT_AMOUNT))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOTAL_SALES_AMOUNT", queryParams.TOTAL_SALES_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOTAL_SGST_AMOUNT", queryParams.TOTAL_SGST_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOTAL_CGST_AMOUNT", queryParams.TOTAL_CGST_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOTAL_IGST_AMOUNT", queryParams.TOTAL_IGST_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TOTAL_AMOUNT", queryParams.TOTAL_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELIVERY_DATE", queryParams.DELIVERY_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMP_STATUS", queryParams.COMP_STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMP_DATE", queryParams.COMP_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DENOMINATION", queryParams.DENOMINATION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ESTIMATE_DATE", queryParams.ESTIMATE_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ESTIMATE_TIME", queryParams.ESTIMATE_TIME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@GSX_CLOSE_DATE", queryParams.GSX_CLOSE_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@USE_SERVICE_TYPE", queryParams.USE_SERVICE_TYPE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVOICE_NOTE", queryParams.INVOICE_NOTE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@GSX_NOTE", queryParams.GSX_NOTE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HSN_SAC_CODE", queryParams.HSN_SAC_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@GSTIN", queryParams.GSTIN))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_HSN_ASC_1", queryParams.PART_HSN_ASC_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_HSN_ASC_2", queryParams.PART_HSN_ASC_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_HSN_ASC_3", queryParams.PART_HSN_ASC_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_HSN_ASC_4", queryParams.PART_HSN_ASC_4))



        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))
        'flag = dbConn.ExecSQL(sqlStr)
        'dbConn.sqlCmd.Parameters.Clear()
        'If flag Then
        '    dbConn.sqlTrn.Commit()
        'Else
        '    PoNo = "-1"
        '    dbConn.sqlTrn.Rollback()
        'End If
        'dbConn.CloseConnection()
        Dim strResult As String = ""
        strResult = dbConn.ExecuteScalarSQLStr(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()

        If strResult = "0" Then
            dbConn.sqlTrn.Commit()
            flag = True
        ElseIf strResult = "1" Then
            ' PoNo = "-1"
            flag = False
            dbConn.sqlTrn.Rollback()
        ElseIf strResult = "-99" Then
            PoNo = "-1"
            flag = False
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()



        Return flag
    End Function
    Public Function UpdateEstimate(queryParams As AppleQmvOrdModel) As Boolean



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


        sqlStr = "SELECT * FROM AP_QMV_ORD WHERE DELFG = 0 "
        sqlStr &= "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        sqlStr &= "AND PO_NO = @PO_NO "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dtQmv = dbConn.GetDataSet(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        'if exist then need to update delfg=1 then insert the record as new
        If (dtQmv Is Nothing) Or (dtQmv.Rows.Count = 0) Then

        Else
            sqlStr = "UPDATE AP_QMV_ORD SET  "

            sqlStr = sqlStr & "UPDDT = @UPDDT, "
            sqlStr = sqlStr & "UPDCD = @UPDCD, "
            sqlStr = sqlStr & "ESTIMATE_DATE = @ESTIMATE_DATE, "
            sqlStr = sqlStr & "ESTIMATE_TIME = @ESTIMATE_TIME  "
            sqlStr = sqlStr & " WHERE PO_NO = @PO_NO "
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE"
        End If
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UserId)) '?????????????????????????
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ESTIMATE_DATE", queryParams.ESTIMATE_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ESTIMATE_TIME", queryParams.ESTIMATE_TIME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@G_NO", queryParams.G_NO))

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

    Public Function UpdateComplete(queryParams As AppleQmvOrdModel) As Boolean
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

        'sqlStr = sqlStr & "MAX(CAST(SUBSTRING(PO_NO, 3, len(PO_NO) - 2) AS int)) AS PO_NO "
        sqlStr = "SELECT  "
        sqlStr &= "* "
        sqlStr &= "FROM AP_QMV_ORD WHERE DELFG = 0 "
        sqlStr &= "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        sqlStr &= "AND PO_NO = @PO_NO "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dtQmv = dbConn.GetDataSet(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        'if exist then need to update delfg=1 then insert the record as new
        If (dtQmv Is Nothing) Or (dtQmv.Rows.Count = 0) Then

        Else



            sqlStr = "UPDATE AP_QMV_ORD SET  "
            sqlStr = sqlStr & "UPDDT = @UPDDT, "
            sqlStr = sqlStr & "UPDCD = @UPDCD, "
            sqlStr = sqlStr & "COMP_STATUS = @COMP_STATUS, "
            sqlStr = sqlStr & "GSX_CLOSE_DATE = @GSX_CLOSE_DATE "
            sqlStr = sqlStr & " WHERE PO_NO = @PO_NO "
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE"
        End If
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UserId)) '?????????????????????????
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMP_STATUS", queryParams.COMP_STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@GSX_CLOSE_DATE", queryParams.GSX_CLOSE_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@G_NO", queryParams.G_NO))

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


    Public Function SelectPoNo(queryParams As ApplePoModel) As String
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
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "MAX(CAST(SUBSTRING(PO_NO, 3, len(PO_NO) - 2) AS int)) AS PO_NO "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PO "
        'sqlStr = sqlStr & "WHERE "
        'sqlStr = sqlStr & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
        '    sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        'End If
        dt = dbConn.GetDataSet(sqlStr)
        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
            PoNo = "GA00000001"
        Else
            PoNo = dt.Rows(0)("PO_no").ToString()
            If Trim(PoNo) = "" Then
                PoNo = "GA00000001"
            Else
                'No = Right(PoNo, Len(PoNo) - 2)
                If Int32.TryParse(PoNo, PoNoTmp1) = False Then
                    PoNo = "-1"
                Else
                    PoNoTmp1 = PoNoTmp1 + 1
                    No = Trim(Str(PoNoTmp1))
                    ' PoNoTmp2 = Len(Str(PoNoTmp1))
                    Select Case Len(No)
                        Case 1
                            PoNo = "GA0000000" & No
                        Case 2
                            PoNo = "GA000000" & No
                        Case 3
                            PoNo = "GA00000" & No
                        Case 4
                            PoNo = "GA0000" & No
                        Case 5
                            PoNo = "GA000" & No
                        Case 6
                            PoNo = "GA00" & No
                        Case 7
                            PoNo = "GA0" & No
                        Case Else
                            PoNo = "GA" & No
                            'PoNo = "-1"
                    End Select
                End If

            End If
        End If


        If PoNo <> "-1" Then
            dbConn.sqlCmd.Parameters.Clear()
            sqlStr = "Insert into AP_PO ("
            sqlStr = sqlStr & "CRTDT, "
            sqlStr = sqlStr & "CRTCD, "
            ' sqlStr = sqlStr & "UPDDT, "
            sqlStr = sqlStr & "UPDCD, "
            sqlStr = sqlStr & "UPDPG, "
            sqlStr = sqlStr & "DELFG, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH, "
            sqlStr = sqlStr & "PO_NO, "
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
            sqlStr = sqlStr & "@PO_NO, "
            sqlStr = sqlStr & "@IP_ADDRESS "
            sqlStr = sqlStr & " )"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", "")) '?????????????????????????
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", PoNo))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))
            flag = dbConn.ExecSQL(sqlStr)
            dbConn.sqlCmd.Parameters.Clear()
            If flag Then
                dbConn.sqlTrn.Commit()
            Else
                PoNo = "-1"
                dbConn.sqlTrn.Rollback()
            End If
            dbConn.CloseConnection()
        Else
            'Incase of PoNo = -1
            dbConn.CloseConnection()
        End If
        Return PoNo
    End Function

    Public Function UpdateDelivered(queryParams As AppleQmvOrdModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = True
        Dim PoNo As String = ""
        Dim InvoiceNo As String = ""
        Dim No As String = ""
        Dim PoNoTmp1 As Integer = 0
        Dim PoNoTmp2 As Integer = 0
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim dtQmv As DataTable

        Dim sqlStr As String = ""





        sqlStr = "SELECT MAX(CAST(SUBSTRING(INVOICE_NO, 3, Len(INVOICE_NO) - 2) As int)) As INVOICE_NO FROM AP_QMV_ORD WHERE DELFG = 0 "
        sqlStr &= "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        'sqlStr &= "AND PO_NO = @PO_NO "

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dtQmv = dbConn.GetDataSet(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        'if exist then need to update delfg=1 then insert the record as new
        If (dtQmv Is Nothing) Or (dtQmv.Rows.Count = 0) Then

        Else

            If Not String.IsNullOrEmpty(dtQmv.Rows(0)("INVOICE_NO").ToString().Trim()) Then
                InvoiceNo = dtQmv.Rows(0)("INVOICE_NO").ToString()
            End If

            If Len(InvoiceNo) > 1 Then
                InvoiceNo = InvoiceNo + 1
                InvoiceNo = "SO" & InvoiceNo
            Else
                InvoiceNo = "SO10001"
            End If

            sqlStr = "UPDATE AP_QMV_ORD SET  "

            sqlStr = sqlStr & "UPDDT = @UPDDT, "
            sqlStr = sqlStr & "UPDCD = @UPDCD, "
            sqlStr = sqlStr & "INVOICE_NO = @INVOICE_NO, "
            sqlStr = sqlStr & "INVOICE_DATE = @INVOICE_DATE, "
            sqlStr = sqlStr & "DENOMINATION = @DENOMINATION, "
            sqlStr = sqlStr & "DELIVERY_DATE = @DELIVERY_DATE "

            sqlStr = sqlStr & " WHERE PO_NO = @PO_NO "
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE"
        End If
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UserId)) '?????????????????????????
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVOICE_NO", InvoiceNo))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVOICE_DATE", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DENOMINATION", queryParams.DENOMINATION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELIVERY_DATE", queryParams.DELIVERY_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@G_NO", queryParams.G_NO))

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



    '''''''Public Function SelectDetailsExport(ByVal queryParams As AppleQmvOrdModel) As DataTable
    '''''''    Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
    '''''''    Dim dbConn As DBUtility = New DBUtility()
    '''''''    Dim sqlStr As String = "SELECT "
    '''''''    sqlStr = sqlStr & "PO_NO, "
    '''''''    sqlStr = sqlStr & "G_NO, "
    '''''''    sqlStr = sqlStr & "CUSTOMER_NAME, "
    '''''''    sqlStr = sqlStr & "(case when COMP_STATUS = 1 then CASE WHEN DELIVERY_DATE='' then 'Complete' WHEN DELIVERY_DATE<>'' then 'Hand Over' end  when COMP_STATUS = 2 then 'Reception only'  when COMP_STATUS = 0 then 'Incomplete' when COMP_STATUS = null then 'Incomplete' end) status, "
    '''''''    sqlStr = sqlStr & "SERIAL_NO, "
    '''''''    sqlStr = sqlStr & "PRODUCT_NAME, "
    '''''''    sqlStr = sqlStr & "part_no1, "
    '''''''    sqlStr = sqlStr & "DELIVERY_DATE, "
    '''''''    sqlStr = sqlStr & "LEFT(CONVERT(VARCHAR, PO_DATE, 111), 10) as PO_DATE, "
    '''''''    sqlStr = sqlStr & " PO_NO,PO_DATE,G_NO,CUSTOMER_NAME,ZIP_CODE,MOBLIE_PHONE,TELEPHONE,ADD_1,ADD_2,CITY,STATE,STATE_CODE,E_MAIL,IS_SHIP_DIFFL,CUSTOMER_NAME_SHIP,ZIP_CODE_SHIP,MOBLIE_PHONE_SHIP,TELEPHONE_SHIP,ADD_1_SHIP,ADD_2_SHIP,CITY_SHIP,STATE_SHIP,STATE_CODE_SHIP,E_MAIL_SHIP,MODEL_NAME,PRODUCT_NAME,SERIAL_NO,IMEI_1,IMEI_2,DATE_OF_PURCHASE,SERVICE_TYPE,COMPTIA,COMPTIA_MODIFIER,PART_NO1,PART_NO2,PART_NO3,PART_NO4,PART_DETAIL_1,PART_DETAIL_2,PART_DETAIL_3,PART_DETAIL_4,PART_QTY_1,PART_QTY_2,PART_QTY_3,PART_QTY_4,PART_DISCOUNT_1,PART_DISCOUNT_2,PART_DISCOUNT_3,PART_DISCOUNT_4,LABOR_AMOUNT,LABOR_DETAIL,LABOR_COST,LABOR_DISCOUNT,LABOR_SALES,LABOR_SGST,LABOR_CGST,LABOR_IGST,LABOR_TOTAL,PART_COST_1,PART_COST_2,PART_COST_3,PART_COST_4,PART_COST_SALES_1,PART_COST_SALES_2,PART_COST_SALES_3,PART_COST_SALES_4,PART1_TAX,PART2_TAX,PART3_TAX,PART4_TAX,LABOUR_TAX,OTHER_TAX,PART_SGST_1,PART_SGST_2,PART_SGST_3,PART_SGST_4,PART_CGST_1,PART_CGST_2,PART_CGST_3,PART_CGST_4,PART_IGST_1,PART_IGST_2,PART_IGST_3,PART_IGST_4,PART_TOTAL_1,PART_TOTAL_2,PART_TOTAL_3,PART_TOTAL_4,PART_QTY_AMOUNT,PART_COST_AMOUNT,PART_SALES_AMOUNT,PART_DISCOUNT_AMOUNT,PART_SGST_AMOUNT,PART_CGST_AMOUNT,PART_IGST_AMOUNT,PART_TOTAL,OTHER_QTY_AMOUNT,OTHER_DETAIL,OTHER_COST,OTHER_DISCOUNT,OTHER_SALES,OTHER_SGST,OTHER_CGST,OTHER_IGST,OTHER_TOTAL,TOTAL_QTY,TOTAL_COST_AMOUNT,TOTAL_DISCOUNT_AMOUNT,TOTAL_SALES_AMOUNT,TOTAL_SGST_AMOUNT,TOTAL_CGST_AMOUNT,TOTAL_IGST_AMOUNT,TOTAL_AMOUNT,DELIVERY_DATE,COMP_STATUS,COMP_DATE,DENOMINATION,ESTIMATE_DATE,ESTIMATE_TIME,GSX_CLOSE_DATE,USE_SERVICE_TYPE,INVOICE_NOTE,GSX_NOTE,HSN_SAC_CODE,GSTIN,IP_ADDRESS,FILE_NAME,SRC_FILE_NAME,PART_HSN_ASC_1,PART_HSN_ASC_2,PART_HSN_ASC_3,PART_HSN_ASC_4,PRICE_OPTIONS_1L,PRICE_OPTIONS_2L,PRICE_OPTIONS_3L,PRICE_OPTIONS_4L,ADVANCE_PAYMENT,INVOICE_NO,INVOICE_DATE "
    '''''''    sqlStr = sqlStr & " from "
    '''''''    sqlStr = sqlStr & "AP_QMV_ORD "
    '''''''    sqlStr = sqlStr & "WHERE "
    '''''''    sqlStr = sqlStr & "DELFG=0 "



    '''''''    If Not String.IsNullOrEmpty(queryParams.CUSTOMER_NAME) Then
    '''''''        sqlStr = sqlStr & " AND CUSTOMER_NAME like '%' + @CUSTOMER_NAME + '%'"
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_NAME", queryParams.CUSTOMER_NAME))
    '''''''    End If
    '''''''    If Not String.IsNullOrEmpty(queryParams.SERIAL_NO) Then
    '''''''        sqlStr = sqlStr & " AND SERIAL_NO = @SERIAL_NO "
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))
    '''''''    End If
    '''''''    If Not String.IsNullOrEmpty(queryParams.PRODUCT_NAME) Then
    '''''''        sqlStr = sqlStr & " AND PRODUCT_NAME like '%' + @PRODUCT_NAME + '%' "
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.PRODUCT_NAME))
    '''''''    End If
    '''''''    'If Not String.IsNullOrEmpty(queryParams.STATUS) Then
    '''''''    '    sqlStr = sqlStr & " AND po.status = @STATUS"
    '''''''    '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
    '''''''    'End If
    '''''''    'If Not ((String.IsNullOrEmpty(queryParams.DateFrom)) And (String.IsNullOrEmpty(queryParams.DateTo))) Then
    '''''''    '    sqlStr = sqlStr & " AND DELIVERY_DATE between @DateFrom and @DateTo"
    '''''''    '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
    '''''''    '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
    '''''''    'End If

    '''''''    If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
    '''''''        sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) <= @DateTo "
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
    '''''''    ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
    '''''''        sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) = @DateFrom "
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
    '''''''    ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
    '''''''        sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, DELIVERY_DATE, 111), 10) = @DateTo "
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
    '''''''    End If

    '''''''    If Not String.IsNullOrEmpty(queryParams.TELEPHONE) Then
    '''''''        sqlStr = sqlStr & " AND telephone = @telephone"
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@telephone", queryParams.TELEPHONE))
    '''''''    End If
    '''''''    If Not String.IsNullOrEmpty(queryParams.PART_NO1) Then
    '''''''        sqlStr = sqlStr & " AND PART_NO1 = @PART_NO1"
    '''''''        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO1", queryParams.PART_NO1))
    '''''''    End If

    '''''''    If Not String.IsNullOrEmpty(queryParams.SortText) Then
    '''''''        sqlStr = sqlStr & " " & queryParams.SortText
    '''''''    End If


    '''''''    Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
    '''''''    dbConn.CloseConnection()
    '''''''    Return _DataTable
    '''''''End Function
End Class
