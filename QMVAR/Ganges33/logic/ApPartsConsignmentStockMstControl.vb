Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient


Public Class ApPartsConsignmentStockMstControl

    Public Function PartNoExist(queryParams As ApPartsConsignmentStockMstModel) As DataTable

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

    Public Function PartsInsert(ByVal queryParams As ApPartsConsignmentStockMstModel) As Boolean

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


    Public Function InsertStockComments(ByVal queryParams As ApPartsConsignmentStockMstModel) As Boolean

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


    Public Function UpdateParts(ByVal queryParams As ApPartsConsignmentStockMstModel) As Boolean

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

    Public Function GetPartsEdit(queryParams As ApPartsConsignmentStockMstModel) As DataTable

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

    Public Function GetPartsStock(ByVal queryParams As ApPartsConsignmentStockMstModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = Nothing
        If Not String.IsNullOrEmpty(queryParams.PARTS_TYPE) Then
            '1 consumtion, 2 parts
            If (queryParams.PARTS_TYPE = "1") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY UNQ_NO) RowNumber,PARTS_NO,PARTS_DETAIL,PRODUCT_NAME,PARTS_TYPE,LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) as CRTDT, "
                sqlStr = sqlStr & "LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) as UPDDT,TIER,PURCHASE_COST,EEE_EEEE,SERIAL_TYPE,SERIAL_NO,IN_STOCK,BALANCE "

                sqlStr = sqlStr & "from "
                sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_MST "
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
                                sqlStr = sqlStr & " AND PARTS_NO like N'" + queryParams.GetValue + "%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.GetValue))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_NO like '%' + @PART_NO + '%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_NO like N'%" + queryParams.GetValue + "'"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_NO like  @PARTS_NO "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.GetValue))
                            End If
                        End If

                    ElseIf (queryParams.DropdownSearch_2 = "02") Then
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_DETAIL like N'" + queryParams.GetValue + "%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.GetValue))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_DETAIL like '%' + @PARTS_DETAIL + '%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_DETAIL like N'%" + queryParams.GetValue + "'"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_DETAIL like  @PARTS_DETAIL "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.GetValue))
                            End If
                        End If
                    ElseIf (queryParams.DropdownSearch_2 = "03") Then
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PRODUCT_NAME like N'" + queryParams.GetValue + "%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.GetValue))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PRODUCT_NAME like '%' + @PRODUCT_NAME + '%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PRODUCT_NAME like N'%" + queryParams.GetValue + "' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PRODUCT_NAME like  @PRODUCT_NAME "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.GetValue))
                            End If
                        End If

                    ElseIf (queryParams.DropdownSearch_2 = "04") Then
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_TYPE like N'" + queryParams.GetValue + "%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.GetValue))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_TYPE like '%' + @PARTS_TYPE + '%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_TYPE like N'%" + queryParams.GetValue + "' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_TYPE like  @PARTS_TYPE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.GetValue))
                            End If
                        End If

                    ElseIf (queryParams.DropdownSearch_2 = "05") Then '<>0
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND IN_STOCK like  @IN_STOCK "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND IN_STOCK NOT IN (@IN_STOCK)"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", 0))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND IN_STOCK like  @IN_STOCK "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND IN_STOCK NOT IN (@IN_STOCK)"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND IN_STOCK like  @IN_STOCK "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND IN_STOCK NOT IN (@IN_STOCK)"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND IN_STOCK like  @IN_STOCK "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND IN_STOCK NOT IN (@IN_STOCK)"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", 0))
                            End If
                        End If
                    ElseIf (queryParams.DropdownSearch_2 = "06") Then '0
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND TIER like  @TIER "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TIER", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND (TIER in ('0') or TIER is null) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND TIER like  @TIER "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TIER", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND (TIER in ('0') or TIER is null) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND TIER like  @TIER "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND (TIER in ('0') or TIER is null) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND TIER like  @TIER "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND (TIER in ('0') or TIER is null) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        End If
                    ElseIf (queryParams.DropdownSearch_2 = "07") Then 'all

                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND BALANCE like  @BALANCE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.GetValue))
                            Else
                                'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                                'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND BALANCE like  @BALANCE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.GetValue))
                            Else
                                'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                                'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND BALANCE like  @BALANCE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.GetValue))
                            Else
                                'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                                'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                                ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND BALANCE like  @BALANCE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.GetValue))
                            Else
                                'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK) "
                                'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                                'bConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        End If

                    End If
                End If
            End If
            If (queryParams.PARTS_TYPE = "2") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY UNQ_NO) RowNumber,PARTS_NO,PARTS_DETAIL,PRODUCT_NAME,PARTS_TYPE,LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) as CRTDT, "
                sqlStr = sqlStr & "LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) as UPDDT,TIER,PURCHASE_COST,EEE_EEEE,SERIAL_TYPE,SERIAL_NO,IN_STOCK,BALANCE "

                sqlStr = sqlStr & "from "
                sqlStr = sqlStr & "AP_PARTS_STOCK_MST "
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
                                sqlStr = sqlStr & " AND PARTS_NO like N'" + queryParams.GetValue + "%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.GetValue))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_NO like '%' + @PART_NO + '%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_NO like N'%" + queryParams.GetValue + "'"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_NO like  @PARTS_NO "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.GetValue))
                            End If
                        End If

                    ElseIf (queryParams.DropdownSearch_2 = "02") Then
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_DETAIL like N'" + queryParams.GetValue + "%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.GetValue))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_DETAIL like '%' + @PARTS_DETAIL + '%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_DETAIL like N'%" + queryParams.GetValue + "'"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_DETAIL like  @PARTS_DETAIL "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.GetValue))
                            End If
                        End If
                    ElseIf (queryParams.DropdownSearch_2 = "03") Then
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PRODUCT_NAME like N'" + queryParams.GetValue + "%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.GetValue))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PRODUCT_NAME like '%' + @PRODUCT_NAME + '%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PRODUCT_NAME like N'%" + queryParams.GetValue + "' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PRODUCT_NAME like  @PRODUCT_NAME "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.GetValue))
                            End If
                        End If

                    ElseIf (queryParams.DropdownSearch_2 = "04") Then
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_TYPE like N'" + queryParams.GetValue + "%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.GetValue))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_TYPE like '%' + @PARTS_TYPE + '%' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_TYPE like N'%" + queryParams.GetValue + "' "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.GetValue))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND PARTS_TYPE like  @PARTS_TYPE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.GetValue))
                            End If
                        End If

                    ElseIf (queryParams.DropdownSearch_2 = "05") Then '<>0
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND IN_STOCK like  @IN_STOCK "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND IN_STOCK NOT IN (@IN_STOCK)"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", 0))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND IN_STOCK like  @IN_STOCK "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND IN_STOCK NOT IN (@IN_STOCK)"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND IN_STOCK like  @IN_STOCK "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND IN_STOCK NOT IN (@IN_STOCK)"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND IN_STOCK like  @IN_STOCK "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND IN_STOCK NOT IN (@IN_STOCK)"
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", 0))
                            End If
                        End If
                    ElseIf (queryParams.DropdownSearch_2 = "06") Then '0
                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND TIER like  @TIER "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TIER", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND (TIER in ('0') or TIER is null) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND TIER like  @TIER "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TIER", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND (TIER in ('0') or TIER is null) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND TIER like  @TIER "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND (TIER in ('0') or TIER is null) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND TIER like  @TIER "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", queryParams.GetValue))
                            Else
                                sqlStr = sqlStr & " AND (TIER in ('0') or TIER is null) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        End If
                    ElseIf (queryParams.DropdownSearch_2 = "07") Then 'all

                        If (queryParams.DropdownSearch_3 = "01") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND BALANCE like  @BALANCE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.GetValue))
                            Else
                                'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                                'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If

                        ElseIf (queryParams.DropdownSearch_3 = "02") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND BALANCE like  @BALANCE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.GetValue))
                            Else
                                'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                                'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                                'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "03") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND BALANCE like  @BALANCE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.GetValue))
                            Else
                                'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK)"
                                'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                                ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        ElseIf (queryParams.DropdownSearch_3 = "04") Then
                            If Not String.IsNullOrEmpty(queryParams.GetValue) Then
                                sqlStr = sqlStr & " AND BALANCE like  @BALANCE "
                                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.GetValue))
                            Else
                                'sqlStr = sqlStr & " AND CURRENT_IN_STOCK IN (@CURRENT_IN_STOCK) "
                                'sqlStr = sqlStr & " Select Case CURRENT_IN_STOCK FROM AC_PARTS_MST t1 ) "
                                'bConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENT_IN_STOCK", 0))
                            End If
                        End If

                    End If
                End If
            End If
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function



    Public Function GetParts_Stock(queryParams As ApPartsConsignmentStockMstModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False
        Dim sqlStr As String = Nothing
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        If Not String.IsNullOrEmpty(queryParams.PARTS_TYPE) Then
            '1 consumtion mst, 2 parts mst
            If (queryParams.PARTS_TYPE = "1") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY UNQ_NO) RowNumber,PARTS_NO,PARTS_DETAIL,PRODUCT_NAME,PARTS_TYPE,LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) as CRTDT, "
                sqlStr = sqlStr & "LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) as UPDDT,TIER,PURCHASE_COST,EEE_EEEE,SERIAL_TYPE,SERIAL_NO,IN_STOCK,BALANCE "
                sqlStr = sqlStr & "FROM "
                sqlStr = sqlStr & "AP_PARTS_CONSIGNMENT_MST "
                sqlStr = sqlStr & "WHERE "
                sqlStr = sqlStr & "DELFG=0 "
            End If

            If (queryParams.PARTS_TYPE = "2") Then
                sqlStr = "SELECT "
                sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY UNQ_NO) RowNumber,PARTS_NO,PARTS_DETAIL,PRODUCT_NAME,PARTS_TYPE,LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) as CRTDT, "
                sqlStr = sqlStr & "LEFT(CONVERT(VARCHAR, UPDDT, 111), 10) as UPDDT,TIER,PURCHASE_COST,EEE_EEEE,SERIAL_TYPE,SERIAL_NO,IN_STOCK,BALANCE "
                sqlStr = sqlStr & "FROM "
                sqlStr = sqlStr & "AP_PARTS_STOCK_MST "
                sqlStr = sqlStr & "WHERE "
                sqlStr = sqlStr & "DELFG=0 "
            End If
        End If
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
