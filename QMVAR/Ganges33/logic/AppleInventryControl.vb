Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic


Public Class AppleInventryControl


    Public Function InsertinvnentryRow(ByVal queryParams As AppleInvnetryModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim flag As Boolean = False
        ' Dim flag1 As Boolean = False

        Dim sqlStr1 As String = "select "
        sqlStr1 = sqlStr1 & " max(INVENTORY_NO)+1 from "
        sqlStr1 = sqlStr1 & "AP_PARTS_INVENTORY "
        'sqlStr1 = sqlStr1 & "CRTDT, "
        'sqlStr1 = sqlStr1 & "CRTCD, "

        sqlStr1 = sqlStr1 & "WHERE "
        sqlStr1 = sqlStr1 & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.ship_to_branch_code) Then
            sqlStr1 = sqlStr1 & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        End If

        Dim _DataTable1 As DataTable = dbConn.GetDataSet(sqlStr1)
        dbConn.sqlCmd.Parameters.Clear()
        'dbConn.CloseConnection()
        'Return _DataTable1
        Dim row1 As DataRow = _DataTable1.Rows(0)
        Dim str_INVENTORY_no As String = row1("Column1")

        '' = _DataTable1.Rows(i)(1)




        Dim sqlStr As String = "INSERT "
        sqlStr = sqlStr & " INTO "
        sqlStr = sqlStr & "AP_PARTS_INVENTORY ("
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "CRTCD, "

        sqlStr = sqlStr & "UPDDT, "
        sqlStr = sqlStr & "UPDCD, "

        'sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG, "



        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "INVENTORY_NO, "
        sqlStr = sqlStr & "INVENTORY_ENTRY, "
        sqlStr = sqlStr & "INVENTORY_DATE "
        'sqlStr = sqlStr & "ship_5, "


        'sqlStr = sqlStr & "ship_5 "
        sqlStr = sqlStr & " ) "

        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@CRTCD, "

        sqlStr = sqlStr & "@UPDDT, "
        sqlStr = sqlStr & "@UPDCD, "


        'sqlStr = sqlStr & "@UPDPG, "
        sqlStr = sqlStr & "@DELFG, "


        sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "@INVENTORY_NO, "
        sqlStr = sqlStr & "@INVENTORY_ENTRY, "
        sqlStr = sqlStr & "@INVENTORY_DATE "


        sqlStr = sqlStr & " )"

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.ship_to_brance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", str_INVENTORY_no))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_ENTRY", 1))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))



        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then

            dbConn.sqlTrn.Commit()
            dbConn.CloseConnection()
        End If
        Return flag


    End Function

    Public Function Insert_AP_PARTS_INVENTORY(ByVal queryParams As AppleInvnetryModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim flag As Boolean = False
        ' Dim flag1 As Boolean = False

        Dim sqlStr1 As String = "select "
        sqlStr1 = sqlStr1 & " max(INVENTORY_NO)+1 from "
        sqlStr1 = sqlStr1 & "AP_PARTS_INVENTORY "
        'sqlStr1 = sqlStr1 & "CRTDT, "
        'sqlStr1 = sqlStr1 & "CRTCD, "

        sqlStr1 = sqlStr1 & "WHERE "
        sqlStr1 = sqlStr1 & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.ship_to_branch_code) Then
            sqlStr1 = sqlStr1 & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        End If

        Dim _DataTable1 As DataTable = dbConn.GetDataSet(sqlStr1)
        dbConn.sqlCmd.Parameters.Clear()
        'dbConn.CloseConnection()
        'Return _DataTable1
        Dim row1 As DataRow = _DataTable1.Rows(0)
        Dim str_INVENTORY_no As String = row1("Column1")

        '' = _DataTable1.Rows(i)(1)




        Dim sqlStr As String = "INSERT "
        sqlStr = sqlStr & " INTO "
        sqlStr = sqlStr & "AP_PARTS_INVENTORY ("
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "CRTCD, "

        sqlStr = sqlStr & "UPDDT, "
        sqlStr = sqlStr & "UPDCD, "

        'sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG, "



        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "INVENTORY_NO, "
        sqlStr = sqlStr & "INVENTORY_ENTRY, "
        sqlStr = sqlStr & "INVENTORY_DATE "
        'sqlStr = sqlStr & "ship_5, "


        'sqlStr = sqlStr & "ship_5 "
        sqlStr = sqlStr & " ) "

        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@CRTCD, "

        sqlStr = sqlStr & "@UPDDT, "
        sqlStr = sqlStr & "@UPDCD, "


        'sqlStr = sqlStr & "@UPDPG, "
        sqlStr = sqlStr & "@DELFG, "


        sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "@INVENTORY_NO, "
        sqlStr = sqlStr & "@INVENTORY_ENTRY, "
        sqlStr = sqlStr & "@INVENTORY_DATE "


        sqlStr = sqlStr & " )"

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.ship_to_brance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", str_INVENTORY_no))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_ENTRY", 0))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))



        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then

            dbConn.sqlTrn.Commit()
            dbConn.CloseConnection()
        End If
        Return flag


    End Function

    Public Function invnentryRow_update(ByVal queryParams As AppleInvnetryModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim flag As Boolean = False
        ' Dim flag1 As Boolean = False

        Dim sqlStr1 As String = "select "
        sqlStr1 = sqlStr1 & " max(INVENTORY_NO) from "
        sqlStr1 = sqlStr1 & "AP_PARTS_INVENTORY "
        'sqlStr1 = sqlStr1 & "CRTDT, "
        'sqlStr1 = sqlStr1 & "CRTCD, "

        sqlStr1 = sqlStr1 & "WHERE "
        sqlStr1 = sqlStr1 & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.ship_to_branch_code) Then
            sqlStr1 = sqlStr1 & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        End If

        Dim _DataTable1 As DataTable = dbConn.GetDataSet(sqlStr1)
        dbConn.sqlCmd.Parameters.Clear()
        'dbConn.CloseConnection()
        'Return _DataTable1
        Dim row1 As DataRow = _DataTable1.Rows(0)
        Dim str_INVENTORY_no As String = row1("Column1")
        queryParams.inventry_no = str_INVENTORY_no
        '' = _DataTable1.Rows(i)(1)

        Dim sqlStr As String = "UPDATE "
        sqlStr = sqlStr & "AP_PARTS_INVENTORY "
        sqlStr = sqlStr & "SET "
        'sqlStr = sqlStr & "CRTDT= @CRTDT, "
        sqlStr = sqlStr & "CRTCD= @CRTCD, "

        sqlStr = sqlStr & "UPDDT= @UPDDT, "
        sqlStr = sqlStr & "UPDCD= @UPDCD, "

        'sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG= @DELFG, "

        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE= @SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH= @SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "INVENTORY_NO= @INVENTORY_NO, "
        sqlStr = sqlStr & "INVENTORY_ENTRY= @INVENTORY_ENTRY, "
        sqlStr = sqlStr & "INVENTORY_DATE= @INVENTORY_DATE "
        'sqlStr = sqlStr & "ship_5, "


        'sqlStr = sqlStr & "ship_5 "
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.ship_to_brance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_ENTRY", 0))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))

        If queryParams.inventry_no <> 0 Then
            sqlStr = sqlStr & " Where INVENTORY_NO = @INVENTORY_NO_ "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO_", queryParams.inventry_no))
        End If

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then

            dbConn.sqlTrn.Commit()
            dbConn.CloseConnection()
        End If
        Return flag


    End Function

    Public Function invnentryRow_update_record(ByVal queryParams As AppleInvnetryModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim flag As Boolean = False
        ' Dim flag1 As Boolean = False

        Dim sqlStr1 As String = "select "
        sqlStr1 = sqlStr1 & " max(INVENTORY_NO) from "
        sqlStr1 = sqlStr1 & "AP_PARTS_INVENTORY "
        'sqlStr1 = sqlStr1 & "CRTDT, "
        'sqlStr1 = sqlStr1 & "CRTCD, "

        sqlStr1 = sqlStr1 & "WHERE "
        sqlStr1 = sqlStr1 & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.ship_to_branch_code) Then
            sqlStr1 = sqlStr1 & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        End If

        Dim _DataTable1 As DataTable = dbConn.GetDataSet(sqlStr1)
        dbConn.sqlCmd.Parameters.Clear()
        'dbConn.CloseConnection()
        'Return _DataTable1
        Dim row1 As DataRow = _DataTable1.Rows(0)
        Dim str_INVENTORY_no As String = row1("Column1")
        queryParams.inventry_no = str_INVENTORY_no
        '' = _DataTable1.Rows(i)(1)

        Dim sqlStr As String = "UPDATE "
        sqlStr = sqlStr & "AP_PARTS_INVENTORY "
        sqlStr = sqlStr & "SET "
        'sqlStr = sqlStr & "CRTDT= @CRTDT, "
        sqlStr = sqlStr & "CRTCD= @CRTCD, "

        sqlStr = sqlStr & "UPDDT= @UPDDT, "
        sqlStr = sqlStr & "UPDCD= @UPDCD, "

        'sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG= @DELFG, "

        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE= @SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH= @SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "INVENTORY_NO= @INVENTORY_NO, "
        sqlStr = sqlStr & "INVENTORY_ENTRY= @INVENTORY_ENTRY, "
        sqlStr = sqlStr & "INVENTORY_DATE= @INVENTORY_DATE "
        'sqlStr = sqlStr & "ship_5, "


        'sqlStr = sqlStr & "ship_5 "
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.ship_to_brance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_ENTRY", 1))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))

        If queryParams.inventry_no <> 0 Then
            sqlStr = sqlStr & " Where INVENTORY_NO = @INVENTORY_NO_ "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO_", queryParams.inventry_no))
        End If

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then

            dbConn.sqlTrn.Commit()
            dbConn.CloseConnection()
        End If
        Return flag


    End Function

    Public Function invnentryRow_update_new(ByVal queryParams As AppleInvnetryModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim flag As Boolean = False
        ' Dim flag1 As Boolean = False

        'Dim sqlStr1 As String = "select "
        'sqlStr1 = sqlStr1 & " max(INVENTORY_NO) from "
        'sqlStr1 = sqlStr1 & "AP_PARTS_INVENTORY "
        ''sqlStr1 = sqlStr1 & "CRTDT, "
        ''sqlStr1 = sqlStr1 & "CRTCD, "

        'sqlStr1 = sqlStr1 & "WHERE "
        'sqlStr1 = sqlStr1 & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.ship_to_branch_code) Then
        '    sqlStr1 = sqlStr1 & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        'End If

        'Dim _DataTable1 As DataTable = dbConn.GetDataSet(sqlStr1)
        'dbConn.sqlCmd.Parameters.Clear()
        ''dbConn.CloseConnection()
        ''Return _DataTable1
        'Dim row1 As DataRow = _DataTable1.Rows(0)
        'Dim str_INVENTORY_no As String = row1("Column1")
        'queryParams.inventry_no = str_INVENTORY_no
        '' = _DataTable1.Rows(i)(1)

        Dim sqlStr As String = "UPDATE "
        sqlStr = sqlStr & "AP_PARTS_INVENTORY "
        sqlStr = sqlStr & "SET "
        'sqlStr = sqlStr & "CRTDT= @CRTDT, "
        sqlStr = sqlStr & "CRTCD= @CRTCD, "

        sqlStr = sqlStr & "UPDDT= @UPDDT, "
        sqlStr = sqlStr & "UPDCD= @UPDCD, "

        'sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG= @DELFG, "

        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE= @SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH= @SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "INVENTORY_NO= @INVENTORY_NO, "
        sqlStr = sqlStr & "INVENTORY_ENTRY= @INVENTORY_ENTRY, "
        sqlStr = sqlStr & "INVENTORY_DATE= @INVENTORY_DATE "
        'sqlStr = sqlStr & "ship_5, "


        'sqlStr = sqlStr & "ship_5 "
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.ship_to_brance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_ENTRY", 0))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))

        If queryParams.inventry_no <> 0 Then
            sqlStr = sqlStr & " Where INVENTORY_NO = @INVENTORY_NO_ "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO_", queryParams.inventry_no))
        End If

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then

            dbConn.sqlTrn.Commit()
            dbConn.CloseConnection()
        End If
        Return flag


    End Function

    Public Function invnentryRow_update_new_flag(ByVal queryParams As AppleInvnetryModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim flag As Boolean = False
        ' Dim flag1 As Boolean = False

        'Dim sqlStr1 As String = "select "
        'sqlStr1 = sqlStr1 & " max(INVENTORY_NO) from "
        'sqlStr1 = sqlStr1 & "AP_PARTS_INVENTORY "
        ''sqlStr1 = sqlStr1 & "CRTDT, "
        ''sqlStr1 = sqlStr1 & "CRTCD, "

        'sqlStr1 = sqlStr1 & "WHERE "
        'sqlStr1 = sqlStr1 & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.ship_to_branch_code) Then
        '    sqlStr1 = sqlStr1 & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        'End If

        'Dim _DataTable1 As DataTable = dbConn.GetDataSet(sqlStr1)
        'dbConn.sqlCmd.Parameters.Clear()
        ''dbConn.CloseConnection()
        ''Return _DataTable1
        'Dim row1 As DataRow = _DataTable1.Rows(0)
        'Dim str_INVENTORY_no As String = row1("Column1")
        'queryParams.inventry_no = str_INVENTORY_no
        '' = _DataTable1.Rows(i)(1)

        Dim sqlStr As String = "UPDATE "
        sqlStr = sqlStr & "AP_PARTS_INVENTORY "
        sqlStr = sqlStr & "SET "
        'sqlStr = sqlStr & "CRTDT= @CRTDT, "
        sqlStr = sqlStr & "CRTCD= @CRTCD, "

        sqlStr = sqlStr & "UPDDT= @UPDDT, "
        sqlStr = sqlStr & "UPDCD= @UPDCD, "

        'sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG= @DELFG, "

        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE= @SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH= @SHIP_TO_BRANCH, "
        sqlStr = sqlStr & "INVENTORY_NO= @INVENTORY_NO, "
        sqlStr = sqlStr & "INVENTORY_ENTRY= @INVENTORY_ENTRY, "
        sqlStr = sqlStr & "INVENTORY_DATE= @INVENTORY_DATE "
        'sqlStr = sqlStr & "ship_5, "


        'sqlStr = sqlStr & "ship_5 "
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.ship_to_brance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_ENTRY", 1))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))

        If queryParams.inventry_no <> 0 Then
            sqlStr = sqlStr & " Where INVENTORY_NO = @INVENTORY_NO_ "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO_", queryParams.inventry_no))
        End If

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then

            dbConn.sqlTrn.Commit()
            dbConn.CloseConnection()
        End If
        Return flag


    End Function




    Public Function Selectinvnentry_MaxNo(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr1 As String = "select "
        sqlStr1 = sqlStr1 & " max(INVENTORY_NO) from "
        sqlStr1 = sqlStr1 & "AP_PARTS_INVENTORY "
        'sqlStr1 = sqlStr1 & "CRTDT, "
        'sqlStr1 = sqlStr1 & "CRTCD, "

        sqlStr1 = sqlStr1 & "WHERE "
        sqlStr1 = sqlStr1 & "DELFG=0 "

        'If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
        '    sqlStr = sqlStr & "AND PO_NO = @PO_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        'End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr1)
        dbConn.CloseConnection()
        Return _DataTable



    End Function

    Public Function Selectinvnentry_No(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr1 As String = "select "
        sqlStr1 = sqlStr1 & " max(INVENTORY_NO) from "
        sqlStr1 = sqlStr1 & "AP_PARTS_INVENTORY "
        'sqlStr1 = sqlStr1 & "CRTDT, "
        'sqlStr1 = sqlStr1 & "CRTCD, "

        sqlStr1 = sqlStr1 & "WHERE "
        sqlStr1 = sqlStr1 & "DELFG=0 "

        'If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
        '    sqlStr = sqlStr & "AND PO_NO = @PO_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        'End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr1)
        dbConn.CloseConnection()
        Return _DataTable



    End Function


    Public Function UpdateinvnentryRow(queryParams As AppleInvnetryModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim sqlStr As String = ""
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        sqlStr = "UPDATE AP_PARTS_ENTRY "
        sqlStr = sqlStr & "SET "
        sqlStr = sqlStr & "UPDDT= @UPDDT,"
        sqlStr = sqlStr & "UPDPG=@UPDPG, "
        sqlStr = sqlStr & "PART_NO=@PART_NO, "
        sqlStr = sqlStr & "UPC_EAN=@UPC_EAN, "
        sqlStr = sqlStr & "DESCRIPTION=@DESCRIPTION, "
        sqlStr = sqlStr & "BALANCE=@BALANCE, "
        sqlStr = sqlStr & "IN_STOCK=@IN_STOCK, "
        sqlStr = sqlStr & "PURCHASE_PRICE=@PURCHASE_PRICE, "
        sqlStr = sqlStr & "INVENTORY_DATE=@INVENTORY_DATE, "
        sqlStr = sqlStr & "SALES_PRICE=@SALES_PRICE "

        sqlStr = sqlStr & "where PART_NO=@PART_NO "
        'sqlStr = sqlStr & "AND location=@location "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", queryParams.UPDDT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.part_no))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPC_EAN", queryParams.UPCEAN))
        '   dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@EditLog", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.description))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.balance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.in_stock))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PURCHASE_PRICE", queryParams.pirchase_price))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SALES_PRICE", queryParams.sales_price))

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()

        If flag Then
            dbConn.sqlTrn.Commit()
        Else
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()

        Return flag
    End Function

    Public Function INSERT_AP_PARTS(queryParams As AppleInvnetryModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        'Dim sqlStr As String = ""
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        Dim sqlStr As String = "INSERT "
        sqlStr = sqlStr & " INTO "
        sqlStr = sqlStr & "AP_PARTS ("
        sqlStr = sqlStr & "CRTDT, "
        'sqlStr = sqlStr & "CRTCD, "

        'sqlStr = sqlStr & "UPDDT, "
        sqlStr = sqlStr & "UPDCD, "

        'sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH, "




        sqlStr = sqlStr & "PARTS_NO, "
        sqlStr = sqlStr & "PARTS_TYPE, "
        sqlStr = sqlStr & "PARTS_DETAIL, "
        sqlStr = sqlStr & "PRICE_COST, "
        sqlStr = sqlStr & "SALES_PRICE "
        'sqlStr = sqlStr & "ship_5, "


        'sqlStr = sqlStr & "ship_5 "
        sqlStr = sqlStr & " ) "

        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@UPDCD, "

        sqlStr = sqlStr & "@DELFG, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "


        'sqlStr = sqlStr & "@UPDPG, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH, "


        sqlStr = sqlStr & "@PARTS_NO, "
        sqlStr = sqlStr & "@PARTS_TYPE, "
        sqlStr = sqlStr & "@PARTS_DETAIL, "
        sqlStr = sqlStr & "@PRICE_COST, "
        sqlStr = sqlStr & "@SALES_PRICE "


        sqlStr = sqlStr & " )"

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.ship_to_brance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.part_no))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_TYPE", queryParams.UPCEAN))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_DETAIL", queryParams.description))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRICE_COST", queryParams.pirchase_price))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SALES_PRICE", queryParams.sales_price))



        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then

            dbConn.sqlTrn.Commit()
            dbConn.CloseConnection()
        End If
        Return flag
    End Function

    Public Function Updateinvnentry(queryParams As AppleInvnetryModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim sqlStr As String = ""
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        sqlStr = "UPDATE AP_PARTS_INVENTORY "
        sqlStr = sqlStr & "SET "
        sqlStr = sqlStr & "UPDDT= @UPDDT,"
        sqlStr = sqlStr & "UPDPG=@UPDPG, "
        sqlStr = sqlStr & "INVENTORY_NO=@INVENTORY_NO, "
        'sqlStr = sqlStr & "UPC_EAN=@UPC_EAN, "
        'sqlStr = sqlStr & "DESCRIPTION=@DESCRIPTION, "
        'sqlStr = sqlStr & "BALANCE=@BALANCE, "
        'sqlStr = sqlStr & "IN_STOCK=@IN_STOCK, "
        'sqlStr = sqlStr & "PURCHASE_PRICE=@PURCHASE_PRICE, "
        'sqlStr = sqlStr & "SALES_PRICE=@SALES_PRICE "

        sqlStr = sqlStr & "where INVENTORY_NO=@INVENTORY_NO "
        'sqlStr = sqlStr & "AND location=@location "

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.part_no))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPC_EAN", queryParams.UPCEAN))
        '   dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@EditLog", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", queryParams.description))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BALANCE", queryParams.balance))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_STOCK", queryParams.in_stock))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PURCHASE_PRICE", queryParams.pirchase_price))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SALES_PRICE", queryParams.sales_price))

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()

        If flag Then
            dbConn.sqlTrn.Commit()
        Else
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()

        Return flag
    End Function

    Public Function DeleteRow(queryParams As AppleInvnetryModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim sqlStr As String = ""
        Dim flag As Boolean = True

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        sqlStr = "delete from AP_PARTS_ENTRY "


        sqlStr = sqlStr & "where PART_NO=@PART_NO "
        'sqlStr = sqlStr & "AND location=@location "
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.part_no))

        sqlStr = sqlStr & "AND UNQ_NO=@UNQ_NO "
        'sqlStr = sqlStr & "AND location=@location "
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNQ_NO", queryParams.UNQ_NO))

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()

        If flag Then
            dbConn.sqlTrn.Commit()
        Else
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()

        Return flag
    End Function

    Public Function DeletePartsRow(queryParams As AppleInvnetryModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim sqlStr As String = ""
        Dim flag As Boolean = True

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn

        sqlStr = "delete from AP_PARTS_ENTRY "


        sqlStr = sqlStr & "where PART_NO=@PART_NO "
        'sqlStr = sqlStr & "AND location=@location "
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.part_no))

        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()

        If flag Then
            dbConn.sqlTrn.Commit()
        Else
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()

        Return flag
    End Function

    Public Function ShowDatasRow(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "top 1 "

        sqlStr = sqlStr & "PARTS_DETAIL,PARTS_DETAIL,PART_TAX,PART_TAX,PRICE_COST,SALES_PRICE "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.part_no) Then
            sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.part_no))
        End If

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

    Public Function GetInventry(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        ' sqlStr = sqlStr & ""

        sqlStr = sqlStr & "INVENTORY_NO,INVENTORY_DATE,UPDDT "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS_INVENTORY "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.ship_to_branch_code) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ship_to_branch_code))
        End If

        If Not ((String.IsNullOrEmpty(queryParams.inventry_date_from)) And (String.IsNullOrEmpty(queryParams.inventry_date))) Then
            sqlStr = sqlStr & "AND INVENTORY_DATE between @DateFrom and @DateTo"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.inventry_date_from))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.inventry_date))
            '''''' End If
            ''
        End If
        'If Not String.IsNullOrEmpty(queryParams.inventry_date) Then
        sqlStr = sqlStr & " order by INVENTORY_NO desc "
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))
        '    End If

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

    Public Function GetpartsEntry(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        ' sqlStr = sqlStr & ""

        sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY INVENTORY_NO) RowNumber,PART_NO,UPC_EAN,DESCRIPTION,BALANCE,PURCHASE_PRICE,IN_STOCK,SALES_PRICE,INVENTORY_DATE,SAP_PART_DESCRIPTION "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS_ENTRY "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.inventry_no) Then
            sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))
        End If

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

    Public Function GetInventryEntry(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        ' sqlStr = sqlStr & ""

        sqlStr = sqlStr & "INVENTORY_ENTRY "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS_INVENTORY "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.inventry_no) Then
            sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))
        End If

        'If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
        '    sqlStr = sqlStr & "AND PO_NO = @PO_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        'End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable



    End Function

    Public Function SelectinvnentryRow(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        'Dim i As Integer = 0
        ' Dim store As String()

        ' For Each (queryParams.part_no(i).ToString())
        'For Each (dt.Rows(i))
        'For Each (dt.Rows(i))

        Dim sqlStr As String = "SELECT "


        sqlStr = sqlStr & "PART_NO,INVENTORY_NO "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "Ap_parts_entry "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "


        If Not String.IsNullOrEmpty(queryParams.part_no) Then
            sqlStr = sqlStr & "AND PART_NO = @PART_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.part_no))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable


    End Function

    Public Function Select_AP_PARTS(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        'Dim i As Integer = 0
        ' Dim store As String()

        ' For Each (queryParams.part_no(i).ToString())
        'For Each (dt.Rows(i))
        'For Each (dt.Rows(i))

        Dim sqlStr As String = "SELECT top 1"


        sqlStr = sqlStr & "PARTS_NO "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PARTS "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "


        If Not String.IsNullOrEmpty(queryParams.part_no) Then
            sqlStr = sqlStr & "AND PARTS_NO = @PARTS_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", queryParams.part_no))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable


    End Function



    Public Function SelectInventery(queryParams As AppleInvnetryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        'Dim i As Integer = 0
        ' Dim store As String()

        ' For Each (queryParams.part_no(i).ToString())
        'For Each (dt.Rows(i))
        'For Each (dt.Rows(i))

        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "UNQ_NO,ROW_NUMBER() OVER (ORDER BY INVENTORY_NO) RowNumber, "

        sqlStr = sqlStr & "PART_NO,UPC_EAN,DESCRIPTION,BALANCE, IN_STOCK,PURCHASE_PRICE,SALES_PRICE "
        sqlStr = sqlStr & "FROM "
            sqlStr = sqlStr & "Ap_parts_entry "
            sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "


        If Not String.IsNullOrEmpty(queryParams.inventry_no) Then
            sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
            dbConn.CloseConnection()
            Return _DataTable


    End Function

End Class
