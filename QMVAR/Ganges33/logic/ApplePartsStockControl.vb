Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient


Public Class ApplePartsStockControl

    Public Function PartNoExist(queryParams As ApplePartsStockModel) As DataTable

        'Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & " * from AC_PARTS_MST "
        sqlStr = sqlStr & "Where DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If
        If Not String.IsNullOrEmpty(queryParams.PART_NO) Then
            sqlStr = sqlStr & "AND PART_NO = @PART_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function PartsInsert(ByVal queryParams As ApplePartsStockModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "INSERT "
        sqlStr = sqlStr & " INTO "
        sqlStr = sqlStr & "AC_PARTS_MST ("
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "CRTCD, "
        sqlStr = sqlStr & "UPDDT, "
        sqlStr = sqlStr & "UPDCD, "
        sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG, "

        sqlStr = sqlStr & "SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "

        sqlStr = sqlStr & "PART_NO, "
        sqlStr = sqlStr & "UPC_EAN, "
        sqlStr = sqlStr & "DESCRIPTION, "
        sqlStr = sqlStr & "SAP_PART_DESCRIPTION, "
        sqlStr = sqlStr & "PURCHASE_PRICE, "
        sqlStr = sqlStr & "SALES_PRICE, "
        sqlStr = sqlStr & "PART_TAX "
        'sqlStr = sqlStr & "LAST_IN_DATE, "
        'sqlStr = sqlStr & "LAST_OUT_DATE "

        ' sqlStr = sqlStr & "IsShipCodeChanged "
        sqlStr = sqlStr & " ) "

        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@CRTCD, "
        sqlStr = sqlStr & "@UPDDT, "
        sqlStr = sqlStr & "@UPDCD, "
        sqlStr = sqlStr & "@UPDPG, "

        sqlStr = sqlStr & "@DELFG, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "

        sqlStr = sqlStr & "@PART_NO, "
        sqlStr = sqlStr & "@UPC_EAN, "
        sqlStr = sqlStr & "@DESCRIPTION, "
        sqlStr = sqlStr & "@SAP_PART_DESCRIPTION, "
        sqlStr = sqlStr & "@PURCHASE_PRICE, "
        sqlStr = sqlStr & "@SALES_PRICE, "
        sqlStr = sqlStr & "@PART_TAX "
        'sqlStr = sqlStr & "@LAST_IN_DATE, "
        'sqlStr = sqlStr & "@LAST_OUT_DATE "

        ' sqlStr = sqlStr & "@IsShipCodeChanged "


        sqlStr = sqlStr & " )"

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPC_EAN", queryParams.UPC_EAN))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.DESCRIPTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SAP_PART_DESCRIPTION", queryParams.SAP_PART_DESCRIPTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PURCHASE_PRICE", queryParams.PURCHASE_PRICE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SALES_PRICE", queryParams.SALES_PRICE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_TAX", queryParams.PART_TAX))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_IN_DATE", queryParams.LAST_IN_DATE))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_OUT_DATE", queryParams.LAST_OUT_DATE))

        ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IsShipCodeChanged", 0))

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag

    End Function


    Public Function InsertStockComments(ByVal queryParams As ApplePartsStockModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "INSERT "
        sqlStr = sqlStr & " INTO "
        sqlStr = sqlStr & "AC_STOCK_COMMENT ("
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "CRTCD, "
        sqlStr = sqlStr & "UPDDT, "
        sqlStr = sqlStr & "UPDCD, "
        sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG, "

        sqlStr = sqlStr & "SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "

        sqlStr = sqlStr & "PART_NO, "
        'sqlStr = sqlStr & "IN_STOCK, "
        sqlStr = sqlStr & "COMMENTS, "
        'sqlStr = sqlStr & "ORIGINAL_PART_NO, "
        sqlStr = sqlStr & "ACTUAL_STOCK, "
        sqlStr = sqlStr & "CHANGED_VALUE "
        'sqlStr = sqlStr & "CURRENT_IN_STOCK, "
        'sqlStr = sqlStr & "LAST_IN_DATE, "
        'sqlStr = sqlStr & "LAST_OUT_DATE "

        ' sqlStr = sqlStr & "IsShipCodeChanged "
        sqlStr = sqlStr & " ) "

        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@CRTCD, "
        sqlStr = sqlStr & "@UPDDT, "
        sqlStr = sqlStr & "@UPDCD, "
        sqlStr = sqlStr & "@UPDPG, "

        sqlStr = sqlStr & "@DELFG, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "

        sqlStr = sqlStr & "@PART_NO, "
        'sqlStr = sqlStr & "@IN_STOCK, "
        sqlStr = sqlStr & "@COMMENTS, "
        'sqlStr = sqlStr & "@ORIGINAL_PART_NO, "
        sqlStr = sqlStr & "@ACTUAL_STOCK, "
        sqlStr = sqlStr & "@CHANGED_VALUE "
        'sqlStr = sqlStr & "@CURRENT_IN_STOCK, "
        'sqlStr = sqlStr & "@LAST_IN_DATE, "
        'sqlStr = sqlStr & "@LAST_OUT_DATE "

        ' sqlStr = sqlStr & "@IsShipCodeChanged "
        sqlStr = sqlStr & " )"

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.CURRENT_IN_STOCK))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMMENTS", queryParams.Comments))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ORIGINAL_PART_NO", queryParams.ORIGINAL_PART_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ACTUAL_STOCK", queryParams.ACTUAL_STOCK))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CHANGED_VALUE", queryParams.CURRENT_IN_STOCK))


        ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IsShipCodeChanged", 0))

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag

    End Function


    Public Function UpdateParts(ByVal queryParams As ApplePartsStockModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "UPDATE "

        sqlStr = sqlStr & "AC_PARTS_MST "
        sqlStr = sqlStr & "SET "
        'sqlStr = sqlStr & "CRTDT =@CRTDT, "
        'sqlStr = sqlStr & "CRTCD =@CRTCD, "
        sqlStr = sqlStr & "UPDDT =@UPDDT, "
        sqlStr = sqlStr & "UPDCD =@UPDCD, "
        sqlStr = sqlStr & "UPDPG =@UPDPG, "




        sqlStr = sqlStr & "UPC_EAN=@UPC_EAN, "
        sqlStr = sqlStr & "DESCRIPTION=@DESCRIPTION, "
        sqlStr = sqlStr & "SAP_PART_DESCRIPTION=@SAP_PART_DESCRIPTION, "
        sqlStr = sqlStr & "PURCHASE_PRICE=@PURCHASE_PRICE, "
        sqlStr = sqlStr & "SALES_PRICE=@SALES_PRICE, "
        sqlStr = sqlStr & "CURRENT_IN_STOCK=@CURRENT_IN_STOCK, "
        sqlStr = sqlStr & "LAST_IN_DATE=@LAST_IN_DATE, "
        sqlStr = sqlStr & "LAST_OUT_DATE=@LAST_OUT_DATE, "
        sqlStr = sqlStr & "PART_TAX=@PART_TAX "


        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPC_EAN", queryParams.UPC_EAN))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.DESCRIPTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SAP_PART_DESCRIPTION", queryParams.SAP_PART_DESCRIPTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PURCHASE_PRICE", queryParams.PURCHASE_PRICE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SALES_PRICE", queryParams.SALES_PRICE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.CURRENT_IN_STOCK))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_IN_DATE", queryParams.LAST_IN_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_OUT_DATE", queryParams.LAST_OUT_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_TAX", queryParams.PART_TAX))


        If Not String.IsNullOrEmpty(queryParams.PART_NO) Then
            sqlStr = sqlStr & "Where PART_NO = @PART_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        End If

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag

    End Function

    Public Function GetPartsEdit(queryParams As ApplePartsStockModel) As DataTable

        'Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & " * from AC_PARTS_MST "
        If Not String.IsNullOrEmpty(queryParams.PART_NO) Then
            sqlStr = sqlStr & "Where @PART_NO = PART_NO"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        End If
        'If Not String.IsNullOrEmpty(queryParams.SHIP_NAME_1) Then
        '    sqlStr = sqlStr & "Where  SHIP_NAME LIKE @SHIP_NAME + '%'"
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.SHIP_NAME_1))
        'End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function GetPartsStock(ByVal queryParams As ApplePartsStockModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "ROW_NUMBER() OVER(ORDER BY UNQ_NO) As RowNumber,PART_NO, "
        sqlStr = sqlStr & "UPC_EAN,DESCRIPTION,SAP_PART_DESCRIPTION,PURCHASE_PRICE,SALES_PRICE,CURRENT_IN_STOCK,FORMAT(LAST_OUT_DATE, 'yyyy/MM/dd') as LAST_OUT_DATE,FORMAT(LAST_IN_DATE, 'yyyy/MM/dd') as LAST_IN_DATE,PART_TAX,NUMBER_PURCHASED_SO_FAR,NUMBER_SOLD_SO_FAR "
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
        sqlStr = sqlStr & "AC_PARTS_MST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.DropdownSearch_1) Then
            If (queryParams.DropdownSearch_1 = "01") Then
                'sqlStr = sqlStr & " AND LAST_IN_DATE = @LAST_IN_DATE "
                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_IN_DATE", queryParams.LAST_IN_DATE))
                If (Not (String.IsNullOrEmpty(queryParams.Search_From_Date)) And (Not (String.IsNullOrEmpty(queryParams.Search_To_Date)))) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, LAST_IN_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, LAST_IN_DATE, 111), 10) <= @DateTo "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.Search_From_Date))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.Search_To_Date))
                ElseIf Not String.IsNullOrEmpty(queryParams.Search_From_Date) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, LAST_IN_DATE, 111), 10) = @DateFrom "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.Search_From_Date))
                ElseIf Not String.IsNullOrEmpty(queryParams.Search_To_Date) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, LAST_IN_DATE, 111), 10) = @DateTo "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.Search_To_Date))
                End If

            ElseIf (queryParams.DropdownSearch_1 = "02") Then
                If (Not (String.IsNullOrEmpty(queryParams.Search_From_Date)) And (Not (String.IsNullOrEmpty(queryParams.Search_To_Date)))) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, LAST_OUT_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, LAST_OUT_DATE, 111), 10) <= @DateTo "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.Search_From_Date))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.Search_To_Date))
                ElseIf Not String.IsNullOrEmpty(queryParams.Search_From_Date) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, LAST_OUT_DATE, 111), 10) = @DateFrom "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.Search_From_Date))
                ElseIf Not String.IsNullOrEmpty(queryParams.Search_To_Date) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, LAST_OUT_DATE, 111), 10) = @DateTo "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.Search_To_Date))
                End If
            End If
            'sqlStr = sqlStr & " AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If


        If Not String.IsNullOrEmpty(queryParams.DropdownSearch_2) Then
            If (queryParams.DropdownSearch_2 = "01") Then

                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND PART_NO like N'" + queryParams.GetValue + "%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.GetValue))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND PART_NO like '%' + @PART_NO + '%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND PART_NO like N'%" + queryParams.GetValue + "'"
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND PART_NO like  @PART_NO "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.GetValue))
                    End If
                End If

            ElseIf (queryParams.DropdownSearch_2 = "02") Then
                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND UPC_EAN like N'" + queryParams.GetValue + "%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPC_EAN", queryParams.GetValue))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND UPC_EAN like '%' + @UPC_EAN + '%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPC_EAN", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND UPC_EAN like N'%" + queryParams.GetValue + "'"
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPC_EAN", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND UPC_EAN like  @UPC_EAN "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPC_EAN", queryParams.GetValue))
                    End If
                End If
            ElseIf (queryParams.DropdownSearch_2 = "03") Then
                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND DESCRIPTION like N'" + queryParams.GetValue + "%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.GetValue))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND DESCRIPTION like '%' + @DESCRIPTION + '%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND DESCRIPTION like N'%" + queryParams.GetValue + "' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND DESCRIPTION like  @DESCRIPTION "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.GetValue))
                    End If
                End If

            ElseIf (queryParams.DropdownSearch_2 = "04") Then
                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND SAP_PART_DESCRIPTION like N'" + queryParams.GetValue + "%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SAP_PART_DESCRIPTION", queryParams.GetValue))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND SAP_PART_DESCRIPTION like '%' + @SAP_PART_DESCRIPTION + '%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SAP_PART_DESCRIPTION", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND SAP_PART_DESCRIPTION like N'%" + queryParams.GetValue + "' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SAP_PART_DESCRIPTION", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND SAP_PART_DESCRIPTION like  @SAP_PART_DESCRIPTION "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SAP_PART_DESCRIPTION", queryParams.GetValue))
                    End If
                End If

            ElseIf (queryParams.DropdownSearch_2 = "05") Then '<>0
                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK NOT IN (@CURRENT_IN_STOCK)"
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK NOT IN (@CURRENT_IN_STOCK)"
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK NOT IN (@CURRENT_IN_STOCK)"
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK NOT IN (@CURRENT_IN_STOCK)"
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                End If
            ElseIf (queryParams.DropdownSearch_2 = "06") Then '0
                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND (CURRENT_IN_STOCK in ('0') or CURRENT_IN_STOCK is null) "
                        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND (CURRENT_IN_STOCK in ('0') or CURRENT_IN_STOCK is null) "
                        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND (CURRENT_IN_STOCK in ('0') or CURRENT_IN_STOCK is null) "
                        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND (CURRENT_IN_STOCK in ('0') or CURRENT_IN_STOCK is null) "
                        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                End If
            ElseIf (queryParams.DropdownSearch_2 = "07") Then 'all

                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                        'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                        'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                        'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                        ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND CURRENT_IN_STOCK like  @CURRENT_IN_STOCK "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                    Else
                        'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK) "
                        'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                        'bConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                    End If
                End If

            End If
        End If


        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function



    Public Function GetParts_Stock(queryParams As ApplePartsStockModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        ' sqlStr = sqlStr & ""

        sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY UNQ_NO) RowNumber,PART_NO,UPC_EAN,DESCRIPTION, "
        sqlStr = sqlStr & "SAP_PART_DESCRIPTION,PURCHASE_PRICE,SALES_PRICE,CURRENT_IN_STOCK,LEFT(CONVERT(VARCHAR, LAST_OUT_DATE, 111), 10) as LAST_OUT_DATE,LEFT(CONVERT(VARCHAR, LAST_IN_DATE, 111), 10) as LAST_IN_DATE,PART_TAX,NUMBER_PURCHASED_SO_FAR,NUMBER_SOLD_SO_FAR "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AC_PARTS_MST "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        'sqlStr = sqlStr & "order by UNQ_NO desc "
        'If Not String.IsNullOrEmpty(queryParams.inventry_no) Then
        '    sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))
        'End If

        'If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
        '    sqlStr = sqlStr & "AND PO_NO = @PO_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        'End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

        'dt = dbConn.GetDataSet(sqlStr)
        'dbConn.CloseConnection()
        'If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
        '    flag = False
        'Else
        '    'PoNo = dt.Rows(0)("PO_no").ToString()
        '    flag = True
        'End If
        'Return flag

    End Function

End Class
