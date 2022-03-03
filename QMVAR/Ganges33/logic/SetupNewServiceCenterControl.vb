Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class SetupNewServiceCenterControl
    Public Function SetupNewServiceCenterInsert(ByVal queryParams As SetupNewServiceCenterModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "INSERT "
        sqlStr = sqlStr & " INTO "
        sqlStr = sqlStr & "M_SHIP_BASE ("
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "CRTCD, "
        sqlStr = sqlStr & "UPDDT, "
        sqlStr = sqlStr & "UPDCD, "
        sqlStr = sqlStr & "UPDPG, "

        sqlStr = sqlStr & "DELFG, "
        sqlStr = sqlStr & "SHIP_NAME, "
        sqlStr = sqlStr & "SHIP_INFO, "
        sqlStr = sqlStr & "SHIP_MANAGER, "
        sqlStr = sqlStr & "SHIP_TEL, "
        sqlStr = sqlStr & "SHIP_ADD1, "
        sqlStr = sqlStr & "SHIP_ADD2, "
        sqlStr = sqlStr & "SHIP_ADD3, "
        sqlStr = sqlStr & "ZIP, "
        sqlStr = sqlStr & "E_MAIL, "
        sqlStr = sqlStr & "SHIP_SERVICE, "
        sqlStr = sqlStr & "OPEN_TIME, "
        sqlStr = sqlStr & "CLOSE_TIME, "
        sqlStr = sqlStr & "OPENING_DATE, "
        sqlStr = sqlStr & "CLOSING_DATE, "
        sqlStr = sqlStr & "SHIP_CODE, "
        sqlStr = sqlStr & "SHIP_MARK, "
        sqlStr = sqlStr & "ITEM_1, "
        sqlStr = sqlStr & "ITEM_2, "
        sqlStr = sqlStr & "MESS_1, "
        sqlStr = sqlStr & "MESS_2, "
        sqlStr = sqlStr & "MESS_3, "
        sqlStr = sqlStr & "REGI_DEPOSIT, "
        sqlStr = sqlStr & "PO_NO "
        ' sqlStr = sqlStr & "IsShipCodeChanged "
        sqlStr = sqlStr & " ) "

        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@CRTCD, "
        sqlStr = sqlStr & "@UPDDT, "
        sqlStr = sqlStr & "@UPDCD, "
        sqlStr = sqlStr & "@UPDPG, "

        sqlStr = sqlStr & "@DELFG, "
        sqlStr = sqlStr & "@SHIP_NAME, "
        sqlStr = sqlStr & "@SHIP_INFO, "
        sqlStr = sqlStr & "@SHIP_MANAGER, "
        sqlStr = sqlStr & "@SHIP_TEL, "
        sqlStr = sqlStr & "@SHIP_ADD1, "
        sqlStr = sqlStr & "@SHIP_ADD2, "
        sqlStr = sqlStr & "@SHIP_ADD3, "
        sqlStr = sqlStr & "@ZIP, "
        sqlStr = sqlStr & "@E_MAIL, "
        sqlStr = sqlStr & "@SHIP_SERVICE, "
        sqlStr = sqlStr & "@OPEN_TIME, "
        sqlStr = sqlStr & "@CLOSE_TIME, "
        sqlStr = sqlStr & "@OPENING_DATE, "
        sqlStr = sqlStr & "@CLOSING_DATE, "
        sqlStr = sqlStr & "@SHIP_CODE,"
        sqlStr = sqlStr & "@SHIP_MARK, "
        sqlStr = sqlStr & "@ITEM_1, "
        sqlStr = sqlStr & "@ITEM_2, "
        sqlStr = sqlStr & "@MESS_1, "
        sqlStr = sqlStr & "@MESS_2, "
        sqlStr = sqlStr & "@MESS_3, "
        sqlStr = sqlStr & "@REGI_DEPOSIT, "
        sqlStr = sqlStr & "@PO_NO "
        ' sqlStr = sqlStr & "@IsShipCodeChanged "


        sqlStr = sqlStr & " )"

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.SHIP_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_INFO", queryParams.SHIP_INFO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_MANAGER", queryParams.SHIP_MANAGER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TEL", queryParams.SHIP_TEL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_ADD1", queryParams.SHIP_ADD1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_ADD2", queryParams.SHIP_ADD2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_ADD3", queryParams.SHIP_ADD3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ZIP", queryParams.ZIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@E_MAIL", queryParams.E_MAIL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_SERVICE", queryParams.SHIP_SERVICE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OPEN_TIME", queryParams.OPEN_TIME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CLOSE_TIME", queryParams.CLOSE_TIME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OPENING_DATE", queryParams.OPENING_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CLOSING_DATE", queryParams.CLOSING_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_CODE", queryParams.SHIP_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_MARK", queryParams.SHIP_MARK))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ITEM_1", queryParams.ITEM_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ITEM_2", queryParams.ITEM_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MESS_1", queryParams.MESS_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MESS_2", queryParams.MESS_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MESS_3", queryParams.MESS_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REGI_DEPOSIT", queryParams.REGI_DEPOSIT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        ' dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IsShipCodeChanged", 0))

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag

    End Function

    Public Function ShowSetupNewServiceCenterGrid(queryParams As SetupNewServiceCenterModel) As DataTable

        'Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & " * from M_SHIP_BASE "
        If queryParams.SHIP_CODE <> 0 Then
            sqlStr = sqlStr & "Where @SHIP_CODE = ship_code"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_CODE", queryParams.SHIP_CODE))
        End If
        If Not String.IsNullOrEmpty(queryParams.SHIP_NAME_1) Then
            sqlStr = sqlStr & "Where  SHIP_NAME LIKE @SHIP_NAME + '%'"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.SHIP_NAME_1))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function UpdateSetupNewServiceCenterGrid(ByVal queryParams As SetupNewServiceCenterModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "UPDATE "

        sqlStr = sqlStr & " M_SHIP_BASE "
        sqlStr = sqlStr & "SET "
        'sqlStr = sqlStr & "CRTDT =@CRTDT, "
        'sqlStr = sqlStr & "CRTCD =@CRTCD, "
        sqlStr = sqlStr & "UPDDT =@UPDDT, "
        sqlStr = sqlStr & "UPDCD =@UPDCD, "
        sqlStr = sqlStr & "UPDPG =@UPDPG, "




        sqlStr = sqlStr & "SHIP_NAME=@SHIP_NAME, "
        sqlStr = sqlStr & "SHIP_INFO=@SHIP_INFO, "
        sqlStr = sqlStr & "SHIP_MANAGER=@SHIP_MANAGER, "
        sqlStr = sqlStr & "SHIP_TEL=@SHIP_TEL, "
        sqlStr = sqlStr & "SHIP_ADD1=@SHIP_ADD1, "
        sqlStr = sqlStr & "SHIP_ADD2=@SHIP_ADD2, "
        sqlStr = sqlStr & "SHIP_ADD3=@SHIP_ADD3, "
        sqlStr = sqlStr & "ZIP=@ZIP, "
        sqlStr = sqlStr & "E_MAIL=@E_MAIL, "
        sqlStr = sqlStr & "SHIP_SERVICE=@SHIP_SERVICE, "
        sqlStr = sqlStr & "OPEN_TIME=@OPEN_TIME, "
        sqlStr = sqlStr & "CLOSE_TIME=@CLOSE_TIME, "
        sqlStr = sqlStr & "OPENING_DATE=@OPENING_DATE, "
        sqlStr = sqlStr & "CLOSING_DATE=@CLOSING_DATE, "
        sqlStr = sqlStr & "SHIP_CODE=@SHIP_CODE, "
        sqlStr = sqlStr & "SHIP_MARK=@SHIP_MARK, "
        sqlStr = sqlStr & "ITEM_1=@ITEM_1, "
        sqlStr = sqlStr & "ITEM_2=@ITEM_2, "
        sqlStr = sqlStr & "MESS_1=@MESS_1, "
        sqlStr = sqlStr & "MESS_2=@MESS_2, "
        sqlStr = sqlStr & "MESS_3=@MESS_3, "
        sqlStr = sqlStr & "REGI_DEPOSIT=@REGI_DEPOSIT, "
        sqlStr = sqlStr & "PO_NO=@PO_NO, "

        sqlStr = sqlStr & "DELFG=@DELFG  "


        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))




        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", queryParams.DELFG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_NAME", queryParams.SHIP_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_INFO", queryParams.SHIP_INFO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_MANAGER", queryParams.SHIP_MANAGER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TEL", queryParams.SHIP_TEL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_ADD1", queryParams.SHIP_ADD1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_ADD2", queryParams.SHIP_ADD2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_ADD3", queryParams.SHIP_ADD3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ZIP", queryParams.ZIP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@E_MAIL", queryParams.E_MAIL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_SERVICE", queryParams.SHIP_SERVICE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OPEN_TIME", queryParams.OPEN_TIME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CLOSE_TIME", queryParams.CLOSE_TIME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OPENING_DATE", queryParams.OPENING_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CLOSING_DATE", queryParams.CLOSING_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_CODE", queryParams.SHIP_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_MARK", queryParams.SHIP_MARK))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ITEM_1", queryParams.ITEM_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ITEM_2", queryParams.ITEM_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MESS_1", queryParams.MESS_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MESS_2", queryParams.MESS_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MESS_3", queryParams.MESS_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REGI_DEPOSIT", queryParams.REGI_DEPOSIT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))

        If queryParams.SHIP_CODE <> 0 Then
            sqlStr = sqlStr & "Where SHIP_CODE = @SHIP_CODE1 "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_CODE1", queryParams.SHIP_CODE))
        End If

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag

    End Function

    ' Public Function Get_info(queryParams As SetupNewServiceCenterModel) As DataTable
    ' Dim DateTimeNow As DateTime = DateTime.Now
    '   Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
    '   Dim SetupNewServiceCenterModel As SetupNewServiceCenterModel = New SetupNewServiceCenterModel()
    '   Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
    '  Dim dbConn As DBUtility = New DBUtility()
    '  Dim sqlStr As String = "SELECT * from M_SHIP_BASE "
    '   If queryParams.SHIP_CODE <> 0 Then
    '       sqlStr = sqlStr & "Where @SHIP_CODE = SHIP_CODE "
    '        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_CODE", queryParams.SHIP_CODE))
    '    End If
    '    Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
    '     dbConn.CloseConnection()
    '    Return _DataTable
    'End Function

End Class
