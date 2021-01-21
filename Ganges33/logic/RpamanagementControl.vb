Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class RpamanagementControl

    Public Function Get_info(queryParams As RpamanagementModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim RpamanagementModel As RpamanagementModel = New RpamanagementModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT * from RPA_TASK_MST "
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
    Public Function Insert_Rpa(queryParams As RpamanagementModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "INSERT "
        sqlStr = sqlStr & " INTO "
        sqlStr = sqlStr & "RPA_TASK_MST ("
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "CRTCD, "
        'sqlStr = sqlStr & "UPDDT,"
        'sqlStr = sqlStr & "UPDCD,"
        'sqlStr = sqlStr & "UPDPG,"
        sqlStr = sqlStr & "DELFG, "
        sqlStr = sqlStr & "TASK_NAME, "
        sqlStr = sqlStr & "FILE_NAME,"
        sqlStr = sqlStr & "PATH, "
        sqlStr = sqlStr & "TEST_STATUS, "
        sqlStr = sqlStr & "STATUS, "
        sqlStr = sqlStr & "RUN_DURATION, "
        sqlStr = sqlStr & "IP_ADDRESS "
        sqlStr = sqlStr & " ) "

        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@CRTCD, "
        'sqlStr = sqlStr & "@UPDDT, "
        'sqlStr = sqlStr & "@UPDCD, "
        'sqlStr = sqlStr & "@UPDPG,"
        sqlStr = sqlStr & "@DELFG, "
        sqlStr = sqlStr & "@TASK_NAME, "
        sqlStr = sqlStr & "@FILE_NAME, "
        sqlStr = sqlStr & "@PATH, "
        sqlStr = sqlStr & "@TEST_STATUS, "
        sqlStr = sqlStr & "@STATUS, "
        sqlStr = sqlStr & "@RUN_DURATION, "
        sqlStr = sqlStr & "@IP_ADDRESS"
        sqlStr = sqlStr & " )"


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", dtNow))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", queryParams.DELFG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TASK_NAME", queryParams.TASK_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FILE_NAME", queryParams.FILE_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PATH", queryParams.PATH))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TEST_STATUS", queryParams.TEST_STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@STATUS", queryParams.STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@RUN_DURATION", queryParams.RUN_DURATION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))



        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag
    End Function
End Class
