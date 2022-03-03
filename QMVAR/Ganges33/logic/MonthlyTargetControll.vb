﻿Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class MonthlyTargetControll
    Public Function MonthlytargetInsert(ByVal queryParams As Monthlytargetmodel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False

        ' Dim sqlStr1 As String = "SELECT "
        'sqlStr1 = sqlStr1 & "SHIP_TO_BRANCH,Target_Month,Target_Year from SSC_TARGET_SET where SHIP_TO_BRANCH= '" & queryParams.SHIP_TO_BRANCH & "' and Target_Month = '" & queryParams.TARGET_MONTH & "' and Target_Year = '" & queryParams.TARGET_YEAR & "'  "
        'Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr1)
        'Dim selectdata = dbConn.GetDataSet(sqlStr1)
        'If (selectdata Is Nothing) Or (selectdata.Rows.Count = 0) Then

        Dim sqlStr As String = "INSERT "
            sqlStr = sqlStr & " INTO "
            sqlStr = sqlStr & "SSC_TARGET_SET ("
            sqlStr = sqlStr & "CRTDT, "
            sqlStr = sqlStr & "CRTCD, "
            'sqlStr = sqlStr & "UPDDT, "
            'sqlStr = sqlStr & "UPDCD, "
            sqlStr = sqlStr & "UPDPG, "
            sqlStr = sqlStr & "DELFG, "
            'sqlStr = sqlStr & "UPLOAD_USER, "
            'sqlStr = sqlStr & "UPLOAD_DATE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH, "

            sqlStr = sqlStr & "TARGET_MONTH, "
            sqlStr = sqlStr & "TARGET_YEAR, "
            sqlStr = sqlStr & "TARGET_MONTH_AMOUNT, "
            sqlStr = sqlStr & "TARGET_DAY_AMOUNT, "
            sqlStr = sqlStr & "TARGET_CALLLOAD_COUNT, "  'Callload
            sqlStr = sqlStr & "TARGET_DAY_COUNT "  'Callload

            'sqlStr = sqlStr & "FILE_NAME "
            'sqlStr = sqlStr & "SRC_FILE_NAME "
            sqlStr = sqlStr & " ) "

            sqlStr = sqlStr & " values ( "
            sqlStr = sqlStr & "@CRTDT, "
            sqlStr = sqlStr & "@CRTCD, "
            'sqlStr = sqlStr & "@UPDDT, "
            'sqlStr = sqlStr & "@UPDCD, "
            sqlStr = sqlStr & "@UPDPG, "
            sqlStr = sqlStr & "@DELFG, "
            'sqlStr = sqlStr & "@UPLOAD_USER, "
            'sqlStr = sqlStr & "@UPLOAD_DATE, "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH, "

            sqlStr = sqlStr & "@TARGET_MONTH, "
            sqlStr = sqlStr & "@TARGET_YEAR, "
            sqlStr = sqlStr & "@TARGET_MONTH_AMOUNT, "
            sqlStr = sqlStr & "@TARGET_DAY_AMOUNT, "
            sqlStr = sqlStr & "@TARGET_CALLLOAD_COUNT, " 'Callload
            sqlStr = sqlStr & "@TARGET_DAY_COUNT " 'Callload

            'sqlStr = sqlStr & "@FILE_NAME "
            'sqlStr = sqlStr & "@SRC_FILE_NAME "
            sqlStr = sqlStr & " )"

            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_MONTH", queryParams.TARGET_MONTH))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_YEAR", queryParams.TARGET_YEAR))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_MONTH_AMOUNT", queryParams.TARGET_MONTH_AMOUNT))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_DAY_AMOUNT", queryParams.TARGET_DAY_AMOUNT))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_CALLLOAD_COUNT", queryParams.TARGET_CALLLOAD_COUNT)) 'Call load
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_DAY_COUNT", queryParams.TARGET_DAY_COUNT)) 'Call load
            flag = dbConn.ExecSQL(sqlStr)
        ' Else

        ' End If


        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag

    End Function


    Public Function ShowMonthlytargetGrid(queryParams As Monthlytargetmodel) As DataTable

        Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel() 'Added for Monthly search
        Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()

        '_Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
        '_Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedValue
        '_Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & " top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT from SSC_TARGET_SET where delfg=0 "  'Added for Weekly Revenue Report
        sqlStr = sqlStr & " top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET "
        sqlStr = sqlStr & " where delfg = 0 "

        'sqlStr = sqlStr & " where delfg = 0 and Target_Year = '" & queryParams.TARGET_YEAR & "' "



        If Not String.IsNullOrEmpty(queryParams.TARGET_YEAR) Then 'Added for Monthly search
            sqlStr = sqlStr & "AND  Target_Year = @Target_Year "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Target_Year", queryParams.TARGET_YEAR))
        End If

        If Not String.IsNullOrEmpty(queryParams.TARGET_MONTH) Then 'Added for Monthly search
            sqlStr = sqlStr & "AND  Target_Month = @Target_Month "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Target_Month", queryParams.TARGET_MONTH))
        End If
        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH) Then 'Added for Monthly search
            sqlStr = sqlStr & "AND  SHIP_TO_BRANCH = @SHIP_TO_BRANCH "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        End If


        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function
    Public Function ShowMonthlytargetGrid_1(queryParams As Monthlytargetmodel) As DataTable

        Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel() 'Added for Monthly search
        Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()

        '_Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
        '_Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedValue
        '_Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & " top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT from SSC_TARGET_SET where delfg=0 "  'Added for Weekly Revenue Report
        sqlStr = sqlStr & " top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET "
        sqlStr = sqlStr & " where delfg = 0 "

        'sqlStr = sqlStr & " where delfg = 0 and Target_Year = '" & queryParams.TARGET_YEAR & "' "



        If Not String.IsNullOrEmpty(queryParams.TARGET_YEAR_1) Then 'Added for Monthly search
            sqlStr = sqlStr & "AND  Target_Year = @Target_Year "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Target_Year", queryParams.TARGET_YEAR))
        End If

        'If Not String.IsNullOrEmpty(queryParams.TARGET_YEAR) Then 'Added for Monthly search
        '    sqlStr = sqlStr & "AND  Target_Year = @Target_Year "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Target_Year", queryParams.TARGET_YEAR))
        'End If

        If Not String.IsNullOrEmpty(queryParams.TARGET_MONTH_1) Then 'Added for Monthly search
            sqlStr = sqlStr & "AND  Target_Month = @Target_Month "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Target_Month", queryParams.TARGET_MONTH))
        End If
        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_1) Then 'Added for Monthly search
            sqlStr = sqlStr & "AND  SHIP_TO_BRANCH = @SHIP_TO_BRANCH "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function SearchMonthlytargetGrid(queryParams As Monthlytargetmodel) As DataTable 'Added for Search button

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET where delfg=0 and SHIP_TO_BRANCH= '" & queryParams.SHIP_TO_BRANCH & "' and Target_Month = '" & queryParams.TARGET_MONTH & "' and Target_Year = '" & queryParams.TARGET_YEAR & "' "





        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function SearchMonthlytargetGrid1(queryParams As Monthlytargetmodel) As DataTable 'Added for Search button

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET where delfg=0  and Target_Year = '" & queryParams.TARGET_YEAR & "' "


        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function SearchMonthlytargetGrid2(queryParams As Monthlytargetmodel) As DataTable 'Added for Search button

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        Dim sqlStr As String = "SELECT "

        sqlStr = sqlStr & "top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET where delfg=0 and SHIP_TO_BRANCH= '" & queryParams.SHIP_TO_BRANCH & "'  and Target_Year = '" & queryParams.TARGET_YEAR & "' "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function SearchMonthlytargetGrid3(queryParams As Monthlytargetmodel) As DataTable 'Added for Search button

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        Dim sqlStr As String = "SELECT "

        sqlStr = sqlStr & "top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET where delfg=0 and Target_Month = '" & queryParams.TARGET_MONTH & "' and Target_Year = '" & queryParams.TARGET_YEAR & "' "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function SearchMonthlytargetGrid4(queryParams As Monthlytargetmodel) As DataTable 'Added for Search button

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        Dim sqlStr As String = "SELECT "

        sqlStr = sqlStr & "top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET where delfg=0 and SHIP_TO_BRANCH= '" & queryParams.SHIP_TO_BRANCH & "' "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function SearchMonthlytargetGrid5(queryParams As Monthlytargetmodel) As DataTable 'Added for Search button

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        Dim sqlStr As String = "SELECT "

        sqlStr = sqlStr & "top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET where delfg=0 and Target_Month = '" & queryParams.TARGET_MONTH & "' and SHIP_TO_BRANCH= '" & queryParams.SHIP_TO_BRANCH & "' "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function SearchMonthlytargetGrid6(queryParams As Monthlytargetmodel) As DataTable 'Added for Search button

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()

        Dim sqlStr As String = "SELECT "

        sqlStr = sqlStr & "top 100 unq_no, crtdt as CREATED_DATE,SHIP_TO_BRANCH as TargetSSC,Target_Month,Target_Year,TARGET_MONTH_AMOUNT,TARGET_CALLLOAD_COUNT from SSC_TARGET_SET where delfg=0 and Target_Month = '" & queryParams.TARGET_MONTH & "' "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function





    Public Function UpdatemonthlyFromGrid(ByVal queryParams As Monthlytargetmodel) As Boolean
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "UPDATE "
        sqlStr = sqlStr & " SSC_TARGET_SET "
        sqlStr = sqlStr & "SET "

        sqlStr = sqlStr & "SHIP_TO_BRANCH=@SHIP_TO_BRANCH, "

        sqlStr = sqlStr & "TARGET_MONTH=@TARGET_MONTH, "
        sqlStr = sqlStr & "TARGET_YEAR=@TARGET_YEAR, "
        sqlStr = sqlStr & "TARGET_MONTH_AMOUNT=@TARGET_MONTH_AMOUNT, "
        sqlStr = sqlStr & "TARGET_DAY_AMOUNT=@TARGET_DAY_AMOUNT, "
        sqlStr = sqlStr & "TARGET_CALLLOAD_COUNT=@TARGET_CALLLOAD_COUNT, " 'Call load
        sqlStr = sqlStr & "TARGET_DAY_COUNT=@TARGET_DAY_COUNT " 'Call load

        sqlStr = sqlStr & " where unq_no= @UNQ_NO and  DELFG=0  "



        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_YEAR", queryParams.TARGET_YEAR))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_MONTH", queryParams.TARGET_MONTH))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_MONTH_AMOUNT", queryParams.TARGET_MONTH_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_DAY_AMOUNT", queryParams.TARGET_DAY_AMOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_CALLLOAD_COUNT", queryParams.TARGET_CALLLOAD_COUNT)) 'Call load
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TARGET_DAY_COUNT", queryParams.TARGET_DAY_COUNT)) 'Call load
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag
    End Function
End Class
