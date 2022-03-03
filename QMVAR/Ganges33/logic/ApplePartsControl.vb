Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient

Public Class ApplePartsControl
    Public Function SelectPrice(ByVal queryParams As ApplePartsModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT * "
        ' sqlStr = sqlStr & "claim_no, "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_PARTS "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
            sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
            sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
    Public Function SelectPriceTop1(ByVal queryParams As ApplePartsModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT TOP 1 * "
        ' sqlStr = sqlStr & "claim_no, "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_PARTS "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
            sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.PRICE_OPTION) Then
            sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectPart(ByVal queryParams As ApplePartsModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT * "
        ' sqlStr = sqlStr & "claim_no, "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_PARTS "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
            sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.PRODUCT_NAME) Then
            sqlStr = sqlStr & "AND PRODUCT_NAME = @PRODUCT_NAME "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.PRODUCT_NAME))
        End If
        If Not String.IsNullOrEmpty(queryParams.PRICE_OPTION) Then
            sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        End If
        If Not String.IsNullOrEmpty(queryParams.UNQ_NO) Then
            sqlStr = sqlStr & "AND UNQ_NO = @UNQ_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function AddQmvOrd_parts(queryParams As ApplePartsModel) As Boolean
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


        sqlStr = "SELECT * FROM AP_parts WHERE DELFG = 0 "
        'sqlStr &= "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        sqlStr &= "AND UNQ_NO = @UNQ_NO "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dtQmv = dbConn.GetDataSet(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        'if exist then need to update delfg=1 then insert the record as new
        If (dtQmv Is Nothing) Or (dtQmv.Rows.Count = 0) Then



            sqlStr = "Insert into AP_parts ("
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
            sqlStr = sqlStr & "PO_NO, "
            sqlStr = sqlStr & "STATUS, "
            sqlStr = sqlStr & "PRODUCT_NAME, "
            sqlStr = sqlStr & "PARTS_NO, "
            sqlStr = sqlStr & "PARTS_DETAIL, "
            sqlStr = sqlStr & "PARTS_TYPE, "
            'sqlStr = sqlStr & "HSN_SAC, "
            sqlStr = sqlStr & "TIER, "
            sqlStr = sqlStr & "CURRENCY, "
            sqlStr = sqlStr & "PRICE_OPTION, "
            sqlStr = sqlStr & "PRICE_COST, "
            sqlStr = sqlStr & "EEE_EEEE, "
            sqlStr = sqlStr & "ALTNATIVE_PARTS, "
            sqlStr = sqlStr & "COMPONENT_GROUP, "
            ' sqlStr = sqlStr & "PRICE_OPTION, "
            sqlStr = sqlStr & "SERIAL_NO, "
            sqlStr = sqlStr & "DIAG_REQ, "
            sqlStr = sqlStr & "SALES_PRICE, "
            sqlStr = sqlStr & "HSN_SAC, "
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
            sqlStr = sqlStr & "@PO_NO, "
            sqlStr = sqlStr & "@STATUS, "
            sqlStr = sqlStr & "@PRODUCT_NAME, "
            sqlStr = sqlStr & "@PARTS_NO, "
            sqlStr = sqlStr & "@PARTS_DETAIL, "
            sqlStr = sqlStr & "@PARTS_TYPE, "
            sqlStr = sqlStr & "@TIER, "


            sqlStr = sqlStr & "@CURRENCY, "
            sqlStr = sqlStr & "@PRICE_OPTION, "
            sqlStr = sqlStr & "@PRICE_COST ,"



            sqlStr = sqlStr & "@EEE_EEEE, "
            sqlStr = sqlStr & "@ALTNATIVE_PARTS, "
            sqlStr = sqlStr & "@COMPONENT_GROUP, "

            sqlStr = sqlStr & "@SERIAL_NO, "
            sqlStr = sqlStr & "@DIAG_REQ, "
            sqlStr = sqlStr & "@SALES_PRICE, "


            sqlStr = sqlStr & "@HSN_SAC, "
            sqlStr = sqlStr & "@IP_ADDRESS, "
            sqlStr = sqlStr & "@FILE_NAME, "

            sqlStr = sqlStr & "@SRC_FILE_NAME "

            'sqlStr = sqlStr & "@IP_ADDRESS "
            sqlStr = sqlStr & " )"
        Else
            sqlStr = "UPDATE AP_parts SET  "

            sqlStr = sqlStr & "UPDDT = @UPDDT, "
            sqlStr = sqlStr & "UPDCD = @UPDCD, "

            ' sqlStr = sqlStr & "UNQ_NO = @UNQ_NO, "
            sqlStr = sqlStr & "UPLOAD_USER = @UPLOAD_USER, "
            sqlStr = sqlStr & "UPLOAD_DATE = @UPLOAD_DATE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH = @SHIP_TO_BRANCH, "
            sqlStr = sqlStr & "PO_NO = @PO_NO, "
            sqlStr = sqlStr & "STATUS = @STATUS, "
            sqlStr = sqlStr & "PRODUCT_NAME = @PRODUCT_NAME, "
            sqlStr = sqlStr & "PARTS_NO = @PARTS_NO, "
            sqlStr = sqlStr & "PARTS_DETAIL = @PARTS_DETAIL, "
            sqlStr = sqlStr & "PARTS_TYPE = @PARTS_TYPE, "
            sqlStr = sqlStr & "TIER = @TIER, "
            sqlStr = sqlStr & "CURRENCY = @CURRENCY , "
            sqlStr = sqlStr & "PRICE_OPTION = @PRICE_OPTION, "
            sqlStr = sqlStr & "PRICE_COST = @PRICE_COST , "
            sqlStr = sqlStr & "EEE_EEEE = @EEE_EEEE, "
            sqlStr = sqlStr & "ALTNATIVE_PARTS = @ALTNATIVE_PARTS, "
            sqlStr = sqlStr & "SERIAL_NO = @SERIAL_NO, "
            sqlStr = sqlStr & "DIAG_REQ = @DIAG_REQ, "
            sqlStr = sqlStr & "SALES_PRICE = @SALES_PRICE, "
            sqlStr = sqlStr & "HSN_SAC = @HSN_SAC, "
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
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME   ", queryParams.PRODUCT_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.PARTS_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.PARTS_DETAIL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.PARTS_TYPE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TIER", queryParams.TIER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CURRENCY ", queryParams.CURRENCY))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_COST", queryParams.PRICE_COST))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@EEE_EEEE", queryParams.EEE_EEEE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ALTNATIVE_PARTS", queryParams.ALTNATIVE_PARTS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMPONENT_GROUP", queryParams.COMPONENT_GROUP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DIAG_REQ", queryParams.DIAG_REQ))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SALES_PRICE", queryParams.SALES_PRICE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HSN_SAC", queryParams.HSN_SAC))
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
