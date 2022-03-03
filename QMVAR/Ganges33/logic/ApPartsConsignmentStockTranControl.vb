Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient


Public Class ApPartsConsignmentStockTranControl

    Public Function GetStockTransaction(ByVal queryParams As ApPartsConsignmentStockTranModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "ROW_NUMBER() OVER(ORDER BY UNQ_NO) As RowNumber,FORMAT(CRTDT, 'yyyy/MM/dd') as CRTDT, "
        sqlStr = sqlStr & "FORMAT(UPDDT, 'yyyy/MM/dd') as UPDDT,PART_NO,DESCRIPTION,QUANTITY,Case WHEN TRAN_TYPE = 1 THEN 'In' WHEN TRAN_TYPE = 2 THEN 'Out' END AS TRAN_TYPE,TRAN_REF,Case WHEN STOCK_TYPE = '1' THEN 'Consignment' WHEN STOCK_TYPE = '2' THEN 'Stock' END AS STOCK_TYPE,SERIAL_NO "
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
        sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_STOCK_TRAN "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.DropdownSearch_1) Then
            If (queryParams.DropdownSearch_1 = "01") Then
                'sqlStr = sqlStr & " AND LAST_IN_DATE = @LAST_IN_DATE "
                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_IN_DATE", queryParams.LAST_IN_DATE))
                If (Not (String.IsNullOrEmpty(queryParams.Search_From_Date)) And (Not (String.IsNullOrEmpty(queryParams.Search_To_Date)))) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) <= @DateTo "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.Search_From_Date))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.Search_To_Date))
                ElseIf Not String.IsNullOrEmpty(queryParams.Search_From_Date) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) = @DateFrom "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.Search_From_Date))
                ElseIf Not String.IsNullOrEmpty(queryParams.Search_To_Date) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) = @DateTo "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.Search_To_Date))
                End If

            ElseIf (queryParams.DropdownSearch_1 = "02") Then
                If (Not (String.IsNullOrEmpty(queryParams.Search_From_Date)) And (Not (String.IsNullOrEmpty(queryParams.Search_To_Date)))) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) <= @DateTo "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.Search_From_Date))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.Search_To_Date))
                ElseIf Not String.IsNullOrEmpty(queryParams.Search_From_Date) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) = @DateFrom "
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.Search_From_Date))
                ElseIf Not String.IsNullOrEmpty(queryParams.Search_To_Date) Then
                    sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) = @DateTo "
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
                        sqlStr = sqlStr & " AND PART_NO like N'%" + queryParams.GetValue + "' "
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
            ElseIf (queryParams.DropdownSearch_2 = "03") Then
                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND QUANTITY like N'" + queryParams.GetValue + "%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@QUANTITY", queryParams.GetValue))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND QUANTITY like '%' + @QUANTITY + '%' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND QUANTITY like N'%" + queryParams.GetValue + "' "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@QUANTITY", queryParams.GetValue))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND QUANTITY like  @QUANTITY "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@QUANTITY", queryParams.GetValue))
                    End If
                End If

            ElseIf (queryParams.DropdownSearch_2 = "04") Then
                If (queryParams.DropdownSearch_3 = "01") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND TRAN_TYPE = @TRAN_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_TYPE", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND TRAN_TYPE = @TRAN_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_TYPE", 1))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND TRAN_TYPE = @TRAN_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_TYPE", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND TRAN_TYPE = @TRAN_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_TYPE", 1))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND TRAN_TYPE = @TRAN_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_TYPE", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND TRAN_TYPE = @TRAN_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_TYPE", 1))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND TRAN_TYPE = @TRAN_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_TYPE", queryParams.GetValue))
                    Else
                        sqlStr = sqlStr & " AND TRAN_TYPE = @TRAN_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_TYPE", 1))
                    End If
                End If

            ElseIf (queryParams.DropdownSearch_2 = "05") Then
                If (queryParams.DropdownSearch_3 = "01") Then

                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", queryParams.GetValue))
                        'Else
                        '    sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", 2))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", queryParams.GetValue))
                        'Else
                        '    sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", 2))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", queryParams.GetValue))
                        'Else
                        '    sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", 2))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", queryParams.GetValue))
                        'Else
                        '    sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", 2))
                    End If
                End If


            ElseIf (queryParams.DropdownSearch_2 = "06") Then
                If (queryParams.DropdownSearch_3 = "01") Then

                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND STOCK_TYPE = @STOCK_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STOCK_TYPE", queryParams.GetValue))
                        'Else
                        '    sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", 2))
                    End If

                ElseIf (queryParams.DropdownSearch_3 = "02") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND STOCK_TYPE = @STOCK_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STOCK_TYPE", queryParams.GetValue))
                        'Else
                        '    sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", 2))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "03") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND STOCK_TYPE = @STOCK_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STOCK_TYPE", queryParams.GetValue))
                        'Else
                        '    sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", 2))
                    End If
                ElseIf (queryParams.DropdownSearch_3 = "04") Then
                    If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                        sqlStr = sqlStr & " AND STOCK_TYPE = @STOCK_TYPE "
                        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STOCK_TYPE", queryParams.GetValue))
                        'Else
                        '    sqlStr = sqlStr & " AND TRAN_REF = @TRAN_REF "
                        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TRAN_REF", 2))
                    End If
                End If
            End If
        End If


        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function GetParts_StockTransaction(queryParams As ApPartsConsignmentStockTranModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        ' sqlStr = sqlStr & ""

        sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY UNQ_NO) RowNumber,LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) as CRTDT,LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) as UPDDT,PART_NO,DESCRIPTION, "
        sqlStr = sqlStr & "QUANTITY, "
        sqlStr = sqlStr & "Case WHEN TRAN_TYPE = 1 THEN 'In' WHEN TRAN_TYPE = 2 THEN 'Out' END AS TRAN_TYPE, "
        sqlStr = sqlStr & "TRAN_REF,Case WHEN STOCK_TYPE = '1' THEN 'Consignment' WHEN STOCK_TYPE = '2' THEN 'Stock' END AS STOCK_TYPE,SERIAL_NO "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_STOCK_TRAN "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

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
