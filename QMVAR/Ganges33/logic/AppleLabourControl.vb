Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Public Class AppleLabourControl

    Public Function SelectLabourAll(ByVal queryParams As AppleLabourModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT  "
        sqlStr = sqlStr & "labour_code,LABOUR_TYPE + ' - ' + LABOUR_DESCRIPTION + '( ' + LABOUR_DETAILS + ')' AS LABOUR_DESCRIPTION, UNQ_NO "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_LABOUR "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.LABOUR_TYPE) Then
            sqlStr = sqlStr & "AND labour_type = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.LABOUR_TYPE))
        End If
        If Not String.IsNullOrEmpty(queryParams.LABOUR_CODE) Then
            sqlStr = sqlStr & "AND labour_code = @PRICE_OPTION "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.LABOUR_CODE))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectLabourPrice(ByVal queryParams As AppleLabourModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT  "
        sqlStr = sqlStr & "* "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_REWORD "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.PART_NO) Then
            sqlStr = sqlStr & "AND PART_NO = @PART_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        End If
        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        'End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function SelectAll(ByVal queryParams As AppleLabourModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT * "
        'sqlStr = sqlStr & "labour_code,LABOUR_TYPE + ' - ' + LABOUR_DESCRIPTION + '( ' + LABOUR_DETAILS + ')' AS LABOUR_DESCRIPTION, UNQ_NO "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_LABOUR "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0  order by LABOUR_DESCRIPTION"
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

    Public Function Selectdetails(ByVal queryParams As AppleLabourModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT  "
        sqlStr = sqlStr & "* "
        sqlStr = sqlStr & "from "
        sqlStr = sqlStr & "AP_LABOUR "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.UNQ_NO) Then
            sqlStr = sqlStr & "AND UNQ_NO = @UNQ_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        End If
        'If Not String.IsNullOrEmpty(queryParams.PARTS_NO) Then
        '    sqlStr = sqlStr & "AND PRICE_OPTION = @PRICE_OPTION "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_OPTION", queryParams.PRICE_OPTION))
        'End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
    Public Function AddQmvOrd_parts(queryParams As AppleLabourModel) As Boolean
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


        sqlStr = "SELECT * FROM AP_LABOUR WHERE DELFG = 0 "
        'sqlStr &= "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        sqlStr &= "AND UNQ_NO = @UNQ_NO "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dtQmv = dbConn.GetDataSet(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        'if exist then need to update delfg=1 then insert the record as new
        If (dtQmv Is Nothing) Or (dtQmv.Rows.Count = 0) Then



            sqlStr = "Insert into AP_LABOUR ("
            sqlStr = sqlStr & "CRTDT, "
            sqlStr = sqlStr & "CRTCD, "
            ' sqlStr = sqlStr & "UPDDT, "
            sqlStr = sqlStr & "UPDCD, "
            sqlStr = sqlStr & "UPDPG, "
            sqlStr = sqlStr & "DELFG, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH, "
            'sqlStr = sqlStr & "PO_NO, "
            sqlStr = sqlStr & "LABOUR_TYPE, "
            sqlStr = sqlStr & "LABOUR_DESCRIPTION, "
            sqlStr = sqlStr & "LABOUR_DETAILS, "
            sqlStr = sqlStr & "LABOUR_CODE, "
            sqlStr = sqlStr & "AMOUNT_100, "
            sqlStr = sqlStr & "AMOUNT_150, "
            sqlStr = sqlStr & "AMOUNT_170, "
            sqlStr = sqlStr & "AMOUNT_180, "
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
            sqlStr = sqlStr & "@LABOUR_TYPE, "
            sqlStr = sqlStr & "@LABOUR_DESCRIPTION, "
            sqlStr = sqlStr & "@LABOUR_DETAILS, "
            sqlStr = sqlStr & "@LABOUR_CODE, "
            sqlStr = sqlStr & "@AMOUNT_100, "
            sqlStr = sqlStr & "@AMOUNT_150, "
            sqlStr = sqlStr & "@AMOUNT_170, "
            sqlStr = sqlStr & "@AMOUNT_180, "
            sqlStr = sqlStr & "@HSN_SAC, "


            sqlStr = sqlStr & "@IP_ADDRESS, "
            sqlStr = sqlStr & "@FILE_NAME, "
            sqlStr = sqlStr & "@SRC_FILE_NAME "

            'sqlStr = sqlStr & "@IP_ADDRESS "
            sqlStr = sqlStr & " )"
        Else
            sqlStr = "UPDATE AP_labour SET  "

            sqlStr = sqlStr & "UPDDT = @UPDDT, "
            sqlStr = sqlStr & "UPDCD = @UPDCD, "

            ' sqlStr = sqlStr & "UNQ_NO = @UNQ_NO, "
            sqlStr = sqlStr & "UPLOAD_USER = @UPLOAD_USER, "
            sqlStr = sqlStr & "UPLOAD_DATE = @UPLOAD_DATE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH = @SHIP_TO_BRANCH, "
            sqlStr = sqlStr & "LABOUR_TYPE = @LABOUR_TYPE, "
            sqlStr = sqlStr & "LABOUR_DESCRIPTION = @LABOUR_DESCRIPTION, "
            sqlStr = sqlStr & "LABOUR_DETAILS = @LABOUR_DETAILS, "
            sqlStr = sqlStr & "LABOUR_CODE = @LABOUR_CODE, "
            sqlStr = sqlStr & "AMOUNT_100 = @AMOUNT_100, "
            sqlStr = sqlStr & "AMOUNT_150 = @AMOUNT_150, "
            sqlStr = sqlStr & "AMOUNT_170 = @AMOUNT_170, "
            sqlStr = sqlStr & "AMOUNT_180 = @AMOUNT_180 , "
            sqlStr = sqlStr & "HSN_SAC = @HSN_SAC, "
            sqlStr = sqlStr & "IP_ADDRESS = @IP_ADDRESS , "
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


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOUR_CODE", queryParams.LABOUR_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_USER", queryParams.UPLOAD_USER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_DATE   ", queryParams.UPLOAD_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOUR_TYPE", queryParams.LABOUR_TYPE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOUR_DESCRIPTION", queryParams.LABOUR_DESCRIPTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LABOUR_DETAILS", queryParams.LABOUR_DETAILS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@AMOUNT_100", queryParams.AMOUNT_100))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@AMOUNT_150", queryParams.AMOUNT_150))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@AMOUNT_170", queryParams.AMOUNT_170))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@AMOUNT_180", queryParams.AMOUNT_180))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HSN_SAC", queryParams.HSN_SAC))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FILE_NAME", queryParams.FILE_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SRC_FILE_NAME))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_QTY_4", queryParams.PART_QTY_4))


        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_1", queryParams.PART_DISCOUNT_1))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_2", queryParams.PART_DISCOUNT_2))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_3", queryParams.PART_DISCOUNT_3))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DISCOUNT_4", queryParams.PART_DISCOUNT_4))






        ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))
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
