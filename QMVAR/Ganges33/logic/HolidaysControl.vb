Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class HolidaysControl

    Public Function Get_info(queryParams As HolidaysModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim RpamanagementModel As RpamanagementModel = New RpamanagementModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT UNQ_NO,HOLIDAY_TEXT,FORMAT(HOLIDAY_DATE, 'yyyy/MM/dd') as HOLIDAY_DATE,DELFG from RPA_HOLIDAYS "
        If queryParams.UNQ_NO <> 0 Then
            sqlStr = sqlStr & "Where @UNQ_NO = UNQ_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        End If
        If Not String.IsNullOrEmpty(queryParams.HOLIDAY_TEXT) Then
            sqlStr = sqlStr & "Where  HOLIDAY_TEXT LIKE @HOLIDAY_TEXT + '%'"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HOLIDAY_TEXT", queryParams.HOLIDAY_TEXT))
        End If
        sqlStr = sqlStr & " order by HOLIDAY_DATE desc  "
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function Get_info2(queryParams As HolidaysModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim RpamanagementModel As RpamanagementModel = New RpamanagementModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT SHIP_NAME,FORMAT(HOLIDAY_DATE, 'yyyy/MM/dd') as HOLIDAY_DATE from RPA_HOLIDAYS "
        'If queryParams.SHIP_NAME <> 0 Then
        If Not String.IsNullOrEmpty(queryParams.SHIP_NAME) Then
            sqlStr = sqlStr & "Where @SHIP_NAME = SHIP_NAME "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.SHIP_NAME))
        End If
        If Not String.IsNullOrEmpty(queryParams.HOLIDAY_DATE) Then
            sqlStr = sqlStr & "AND  @HOLIDAY_DATE = HOLIDAY_DATE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HOLIDAY_DATE", queryParams.HOLIDAY_DATE))
        End If
        'sqlStr = sqlStr & " order by HOLIDAY_DATE desc  "
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
    Public Function Editinfo(queryParams As HolidaysModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim RpamanagementModel As RpamanagementModel = New RpamanagementModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT UNQ_NO,HOLIDAY_TEXT,FORMAT(HOLIDAY_DATE, 'yyyy/MM/dd') as HOLIDAY_DATE, SHIP_NAME,DELFG from RPA_HOLIDAYS "
        'If queryParams.SHIP_NAME <> Nullable Then
        sqlStr = sqlStr & "Where @SHIP_NAME = SHIP_NAME "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.SHIP_NAME))
        'End If

        If (Not (String.IsNullOrEmpty(queryParams.HOLIDAY_DATE)) And (Not (String.IsNullOrEmpty(queryParams.HOLIDAY_DATE_1)))) Then
            sqlStr = sqlStr & " AND LEFT(CONVERT(VARCHAR, HOLIDAY_DATE, 111), 10) >= @HOLIDAY_DATE and LEFT(CONVERT(VARCHAR, HOLIDAY_DATE, 111), 10) <= @HOLIDAY_DATE_1 "
            'sqlStr = sqlStr & "AND INVOICE_DATE >= @DateFrom and INVOICE_DATE <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HOLIDAY_DATE", queryParams.HOLIDAY_DATE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HOLIDAY_DATE_1", queryParams.HOLIDAY_DATE_1))
        End If

        'sqlStr = sqlStr & " and @HOLIDAY_DATE BETWEEN HOLIDAY_DATE AND HOLIDAY_DATE_1  "
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.HOLIDAY_DATE))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.HOLIDAY_DATE_1))
        sqlStr = sqlStr & " order by UPDDT desc  "
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function Editinfo1(queryParams As HolidaysModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim RpamanagementModel As RpamanagementModel = New RpamanagementModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT UNQ_NO,HOLIDAY_TEXT,FORMAT(HOLIDAY_DATE, 'yyyy/MM/dd') as HOLIDAY_DATE,SHIP_NAME,DELFG from RPA_HOLIDAYS "
        If queryParams.UNQ_NO <> 0 Then
            sqlStr = sqlStr & "Where @UNQ_NO = UNQ_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        End If
        sqlStr = sqlStr & " order by UNQ_NO asc  "
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function insert_holidays(queryparams As HolidaysModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim datetimenow As DateTime = DateTime.Now
        Dim dtnow As DateTime = datetimenow.AddMinutes(ConfigurationManager.AppSettings("timediff"))

        Dim dbconn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlstr As String = "insert "
        sqlstr = sqlstr & " into "
        sqlstr = sqlstr & "RPA_HOLIDAYS ("
        sqlstr = sqlstr & "crtdt, "
        sqlstr = sqlstr & "crtcd, "
        sqlstr = sqlstr & "upddt,"
        sqlstr = sqlstr & "updcd,"
        sqlstr = sqlstr & "updpg,"
        sqlstr = sqlstr & "delfg, "
        sqlstr = sqlstr & "HOLIDAY_TEXT, "
        sqlstr = sqlstr & "HOLIDAY_DATE,"
        sqlstr = sqlstr & "SHIP_NAME "
        'sqlstr = sqlstr & "test_status, "
        'sqlstr = sqlstr & "status, "
        'sqlstr = sqlstr & "run_duration, "
        'sqlstr = sqlstr & "ip_address "
        sqlstr = sqlstr & " ) "

        sqlstr = sqlstr & " values ( "
        sqlstr = sqlstr & "@crtdt, "
        sqlstr = sqlstr & "@crtcd, "
        sqlstr = sqlstr & "@upddt, "
        sqlstr = sqlstr & "@updcd, "
        sqlstr = sqlstr & "@updpg,"
        sqlstr = sqlstr & "@delfg, "
        sqlstr = sqlstr & "@HOLIDAY_TEXT, "
        sqlstr = sqlstr & "@HOLIDAY_DATE, "
        sqlstr = sqlstr & "@SHIP_NAME "
        'sqlstr = sqlstr & "@test_status, "
        'sqlstr = sqlstr & "@status, "
        'sqlstr = sqlstr & "@run_duration, "
        'sqlstr = sqlstr & "@ip_address"
        sqlstr = sqlstr & " )"


        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@crtdt", dtnow))
        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@crtcd", queryparams.CRTCD))
        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@upddt", dtnow))
        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@updcd", queryparams.UPDCD))
        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@updpg", queryparams.UPDPG))
        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@delfg", 0))
        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HOLIDAY_TEXT", queryparams.HOLIDAY_TEXT))
        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HOLIDAY_DATE", queryparams.HOLIDAY_DATE))
        dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryparams.SHIP_NAME))
        'dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@test_status", queryparams.test_status))
        'dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@status", queryparams.status))
        'dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@run_duration", queryparams.run_duration))
        'dbconn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ip_address", queryparams.ip_address))



        flag = dbconn.ExecSQL(sqlstr)
        dbconn.sqlCmd.Parameters.Clear()
        dbconn.CloseConnection()
        Return flag
    End Function

    Public Function update_Holidays(queryParams As HolidaysModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "update "

        sqlStr = sqlStr & "RPA_HOLIDAYS set "
        If Not String.IsNullOrEmpty(queryParams.HOLIDAY_TEXT) Then
            sqlStr = sqlStr & " HOLIDAY_TEXT = @HOLIDAY_TEXT, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HOLIDAY_TEXT", queryParams.HOLIDAY_TEXT))
        End If
        If Not String.IsNullOrEmpty(queryParams.HOLIDAY_DATE) Then
            sqlStr = sqlStr & " HOLIDAY_DATE = @HOLIDAY_DATE, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HOLIDAY_DATE", queryParams.HOLIDAY_DATE))
        End If
        If Not String.IsNullOrEmpty(queryParams.SHIP_NAME) Then
            sqlStr = sqlStr & " SHIP_NAME = @SHIP_NAME, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.SHIP_NAME))
        End If
        'If Not String.IsNullOrEmpty(queryParams.STATUS) Then
        '    sqlStr = sqlStr & "STATUS = @STATUS, "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
        'End If
        If Not String.IsNullOrEmpty(queryParams.DELFG) Then
            sqlStr = sqlStr & " DELFG = @DELFG, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", queryParams.DELFG))
        End If

        sqlStr = sqlStr & "UPDDT= @UPDDT, "
        sqlStr = sqlStr & "UPDCD= @UPDCD "
        'sqlStr = sqlStr & "UPDPG=@UPDCD"


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        If queryParams.UNQ_NO <> 0 Then
            sqlStr = sqlStr & " Where UNQ_NO = @UNQ_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        End If


        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag
    End Function


    Public Function Get_infoShip(queryParams As HolidaysModel) As DataTable
        Dim Credit_Info_Model As CreditModel = New CreditModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT ship_name FROM M_ship_base "
        'sqlStr = sqlStr & " From M_ship_base SB "
        'sqlStr = sqlStr & " Left Join R_CREDIT_I CI on SB.ship_name = CI.BRANCH_NO "
        sqlStr = sqlStr & " WHERE DELFG = 0 ORDER BY ship_code "

        'If Not String.IsNullOrEmpty(queryParams.BRANCH_NO) Then
        '    sqlStr = sqlStr & "AND BRANCH_NO = @BRANCH_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BRANCH_NO", queryParams.BRANCH_NO))
        'End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

End Class
