Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class MUserControl

    Public Function MUserInsert(ByVal queryParams As MUserModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        ' Dim flag1 As Boolean = False
        Dim sqlStr As String = "INSERT "
        sqlStr = sqlStr & " INTO "
        sqlStr = sqlStr & "M_USER ("
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "CRTCD, "

        sqlStr = sqlStr & "UPDDT, "
        sqlStr = sqlStr & "UPDCD, "

        sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG, "
        sqlStr = sqlStr & "user_id, "
        sqlStr = sqlStr & "password, "
        sqlStr = sqlStr & "eng_id, "

        sqlStr = sqlStr & "last_login, "

        sqlStr = sqlStr & "admin_flg, "
        sqlStr = sqlStr & "user_level, "

        sqlStr = sqlStr & "ship_1, "
        sqlStr = sqlStr & "ship_2, "
        sqlStr = sqlStr & "ship_3, "
        sqlStr = sqlStr & "ship_4, "
        'sqlStr = sqlStr & "ship_5, "


        sqlStr = sqlStr & "ship_5 "
        sqlStr = sqlStr & " ) "

        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@CRTCD, "

        sqlStr = sqlStr & "@UPDDT, "
        sqlStr = sqlStr & "@UPDCD, "


        sqlStr = sqlStr & "@UPDPG, "
        sqlStr = sqlStr & "@DELFG, "
        sqlStr = sqlStr & "@user_id, "
        sqlStr = sqlStr & "@password, "
        sqlStr = sqlStr & "@eng_id, "

        sqlStr = sqlStr & "@last_login, "

        sqlStr = sqlStr & "@admin_flg, "

        sqlStr = sqlStr & "@user_level, "
        sqlStr = sqlStr & "@ship_1, "
        sqlStr = sqlStr & "@ship_2, "
        sqlStr = sqlStr & "@ship_3, "
        sqlStr = sqlStr & "@ship_4, "
        sqlStr = sqlStr & "@ship_5 "


        sqlStr = sqlStr & " )"

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", queryParams.DELFG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@password", queryParams.Password))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@eng_id", queryParams.eng_id))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@last_login", dtNow))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@admin_flg", queryParams.admin_flg))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_level", queryParams.user_level))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_1", queryParams.ship_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_2", queryParams.ship_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_3", queryParams.ship_3))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_4", queryParams.ship_4))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_5", queryParams.ship_5))

        flag = dbConn.ExecSQL(sqlStr)


        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag


    End Function


    Public Function MUserDataInsert(ByVal queryParams As MUserModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        ' Dim flag1 As Boolean = False




        Dim sqlStr1 As String = "INSERT "
        sqlStr1 = sqlStr1 & " INTO "
        sqlStr1 = sqlStr1 & "M_USER_data ("
        sqlStr1 = sqlStr1 & "CRTDT, "
        sqlStr1 = sqlStr1 & "CRTCD, "

        sqlStr1 = sqlStr1 & "UPDDT, "
        sqlStr1 = sqlStr1 & "UPDCD, "

        sqlStr1 = sqlStr1 & "UPDPG, "
        sqlStr1 = sqlStr1 & "DELFG, "
        sqlStr1 = sqlStr1 & "user_id, "
        sqlStr1 = sqlStr1 & "surname, "
        sqlStr1 = sqlStr1 & "name, "
        sqlStr1 = sqlStr1 & "mid_name, "
        sqlStr1 = sqlStr1 & "birthday, "

        sqlStr1 = sqlStr1 & "sex, "
        sqlStr1 = sqlStr1 & "superior, "
        sqlStr1 = sqlStr1 & "add_1, "
        sqlStr1 = sqlStr1 & "add_2, "
        sqlStr1 = sqlStr1 & "add_3, "
        sqlStr1 = sqlStr1 & "zip, "
        sqlStr1 = sqlStr1 & "tel, "
        sqlStr1 = sqlStr1 & "mobile, "
        sqlStr1 = sqlStr1 & "e_mail, "


        sqlStr1 = sqlStr1 & "em_tel, "
        sqlStr1 = sqlStr1 & "em_surname, "
        sqlStr1 = sqlStr1 & "gua_name, "
        sqlStr1 = sqlStr1 & "gua_tel, "
        sqlStr1 = sqlStr1 & "gua_add1, "
        sqlStr1 = sqlStr1 & "hire_date, "
        sqlStr1 = sqlStr1 & "class, "
        sqlStr1 = sqlStr1 & "position, "
        sqlStr1 = sqlStr1 & "work_location, "
        sqlStr1 = sqlStr1 & "paid_h1, "


        sqlStr1 = sqlStr1 & "reg_work_time "
        sqlStr1 = sqlStr1 & " ) "

        sqlStr1 = sqlStr1 & " values ( "
        sqlStr1 = sqlStr1 & "@CRTDT, "
        sqlStr1 = sqlStr1 & "@CRTCD, "

        sqlStr1 = sqlStr1 & "@UPDDT, "
        sqlStr1 = sqlStr1 & "@UPDCD, "

        sqlStr1 = sqlStr1 & "@UPDPG, "
        sqlStr1 = sqlStr1 & "@DELFG, "
        sqlStr1 = sqlStr1 & "@user_id, "
        sqlStr1 = sqlStr1 & "@surname, "
        sqlStr1 = sqlStr1 & "@name, "
        sqlStr1 = sqlStr1 & "@mid_name, "

        sqlStr1 = sqlStr1 & "@birthday, "
        sqlStr1 = sqlStr1 & "@sex, "
        sqlStr1 = sqlStr1 & "@superior, "
        sqlStr1 = sqlStr1 & "@add_1, "
        sqlStr1 = sqlStr1 & "@add_2, "
        sqlStr1 = sqlStr1 & "@add_3, "

        sqlStr1 = sqlStr1 & "@zip, "
        sqlStr1 = sqlStr1 & "@tel, "
        sqlStr1 = sqlStr1 & "@mobile, "
        sqlStr1 = sqlStr1 & "@e_mail, "
        sqlStr1 = sqlStr1 & "@em_tel, "

        sqlStr1 = sqlStr1 & "@em_surname, "
        sqlStr1 = sqlStr1 & "@gua_name, "
        sqlStr1 = sqlStr1 & "@gua_tel, "
        sqlStr1 = sqlStr1 & "@gua_add1, "
        sqlStr1 = sqlStr1 & "@hire_date, "
        sqlStr1 = sqlStr1 & "@class, "
        sqlStr1 = sqlStr1 & "@position, "
        sqlStr1 = sqlStr1 & "@work_location, "
        sqlStr1 = sqlStr1 & "@paid_h1, "


        sqlStr1 = sqlStr1 & "@reg_work_time "


        sqlStr1 = sqlStr1 & " )"

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.CRTCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", queryParams.DELFG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@surname", queryParams.Surname))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@name", queryParams.Name))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@mid_name", queryParams.Middle_Name))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@birthday", queryParams.Birth_Day))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@sex", queryParams.Sex))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@superior", queryParams.Superior))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@add_1", queryParams.Address_Line_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@add_2", queryParams.Address_Line_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@add_3", queryParams.Address_Line_3))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@zip", queryParams.Zip_Code))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@tel", queryParams.Telephone_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@mobile", queryParams.Mobile))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@e_mail", queryParams.Email_ID))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@em_tel", queryParams.Telephone_2))


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@em_surname", queryParams.em_surname))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@gua_name", queryParams.gua_name))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@gua_tel", queryParams.gua_tel))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@gua_add1", queryParams.gua_add1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@hire_date", dtNow))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@class", queryParams.Class1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@position", queryParams.position))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@work_location", queryParams.work_location))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@paid_h1", queryParams.paid_h1))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@reg_work_time", queryParams.reg_work_time))


        flag = dbConn.ExecSQL(sqlStr1)



        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag


    End Function


    Public Function ShowMUserGrid(queryParams As MUserModel) As DataTable

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "SELECT " 
        sqlStr = sqlStr & " MD.DELFG,MD.user_id, MD.password, MD.admin_flg,MD.user_level "
         sqlStr = sqlStr & " FROM [dbo].[M_USER_data] as MUD"
        sqlStr = sqlStr & " INNER JOIN [dbo].M_USER AS MD ON MUD.user_id=MD.user_id and mud.DELFG=md.DELFG "
          If queryParams.UserId <> "" Then
            sqlStr = sqlStr & "Where @User_id = MUD.user_id"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@User_id", queryParams.UserId))
        End If
        If Not String.IsNullOrEmpty(queryParams.User_id) Then
            sqlStr = sqlStr & "Where  MD.User_id LIKE @User_id + '%'"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@User_id", queryParams.User_id))
        End If
        sqlStr = sqlStr & " order by  MD.CRTDT desc "

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

    End Function

    Public Function GetUserInfo(queryParams As MUserModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim MUsermodel As MUserModel = New MUserModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & " MD.DELFG, MD.user_id, MD.password, MD.eng_id,
     MD.admin_flg, MD.user_level, MD.ship_1, MD.ship_2, MD.ship_3, MD.ship_4, MD.ship_5, mud.surname, MUD.name, MUD.mid_name
    ,MUD.birthday,MUD.sex,MUD.superior,MUD.add_1,MUD.add_2,MUD.add_3,MUD.zip,MUD.tel,MUD.mobile,MUD.e_mail,MUD.em_tel 
    From [dbo].[M_USER_data] as MUD
        left outer JOIN [dbo].M_USER AS MD ON MUD.user_id=MD.user_id And mud.DELFG=md.DELFG "
        'queryParams.UserId.Count <>0
        If Convert.ToString(queryParams.UserId.Count <> 0) Then
            sqlStr = sqlStr & "Where MD.user_id = @user_id "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function ViewMUserInfo(queryParams As MUserModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim MUsermodel As MUserModel = New MUserModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & " MD.CRTDT, MD.CRTCD, MD.UPDDT, MD.UPDCD, MD.DELFG, MD.user_id, MD.password, MD.eng_id,
     MD.admin_flg, MD.user_level, MD.ship_1, MD.ship_2, MD.ship_3, MD.ship_4, MD.ship_5, mud.surname, MUD.name, MUD.mid_name
    ,MUD.birthday,MUD.sex,MUD.superior,MUD.add_1,MUD.add_2,MUD.add_3,MUD.zip,MUD.tel,MUD.mobile,MUD.e_mail,MUD.em_tel
    ,MUD.em_surname,MUD.Gua_name,MUD.gua_tel,MUD.gua_add1,MUD.gua_add2,MUD.gua_zip,MUD.gua_email,
	MUD.hire_date,MUD.dep_date,MUD.class,MUD.position,MUD.work_location,MUD.comm_time,MUD.high_date1,MUD.high_date2,MUD.high_name
	,MUD.uni_date1,MUD.uni_date2,MUD.uni_name
	,MUD.emp_h1,MUD.emp_h2,MUD.emp_name1,MUD.emp_h3,MUD.emp_h4,MUD.emp_name2,MUD.qua_name1,MUD.qua_name2,MUD.qua_name3,
	MUD.qua_date1,MUD.qua_date2,MUD.qua_date3,MUD.paid_h1,MUD.paid_h2,MUD.reg_work_time
    From [dbo].[M_USER_data] as MUD
        inner JOIN [dbo].M_USER AS MD ON MUD.user_id=MD.user_id And mud.DELFG=md.DELFG "
        'queryParams.UserId.Count <>0
        If Convert.ToString(queryParams.UserId.Count <> 0) Then
            sqlStr = sqlStr & "Where MD.user_id = @user_id "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        End If
        'sqlStr = sqlStr & "Where MD.user_id = @user_id "
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function UpdateMUser(queryParams As MUserModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "update "

        sqlStr = sqlStr & "M_USER set "
        If Not String.IsNullOrEmpty(queryParams.DELFG) Then
            sqlStr = sqlStr & " DELFG = @DELFG, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", queryParams.DELFG))
        End If
        If Not String.IsNullOrEmpty(queryParams.UserId) Then
            sqlStr = sqlStr & " user_id = @user_id, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        End If
        If Not String.IsNullOrEmpty(queryParams.Password) Then
            sqlStr = sqlStr & " password = @password, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@password", queryParams.Password))
        End If
        If Not String.IsNullOrEmpty(queryParams.eng_id) Then
            sqlStr = sqlStr & " eng_id = @eng_id, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@eng_id", queryParams.eng_id))
        End If
        If Not String.IsNullOrEmpty(queryParams.admin_flg) Then
            sqlStr = sqlStr & " admin_flg = @admin_flg, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@admin_flg", queryParams.admin_flg))
        End If
        If Not String.IsNullOrEmpty(queryParams.user_level) Then
            sqlStr = sqlStr & " user_level = @user_level, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_level", queryParams.user_level))
        End If
        If Not String.IsNullOrEmpty(queryParams.ship_1) Then
            sqlStr = sqlStr & " ship_1 = @ship_1, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_1", queryParams.ship_1))
        End If
        If Not String.IsNullOrEmpty(queryParams.ship_2) Then
            sqlStr = sqlStr & " ship_2 = @ship_2, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_2", queryParams.ship_2))
        End If
        If Not String.IsNullOrEmpty(queryParams.ship_3) Then
            sqlStr = sqlStr & "ship_3 = @ship_3, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_3", queryParams.ship_3))
        End If
        If Not String.IsNullOrEmpty(queryParams.ship_4) Then
            sqlStr = sqlStr & " ship_4 = @ship_4, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_4", queryParams.ship_4))
        End If
        If Not String.IsNullOrEmpty(queryParams.ship_5) Then
            sqlStr = sqlStr & " ship_5 = @ship_5, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ship_5", queryParams.ship_5))
        End If
        sqlStr = sqlStr & "UPDDT= @UPDDT, "
        sqlStr = sqlStr & "UPDCD= @UPDCD "
        'sqlStr = sqlStr & "UPDPG=@UPDCD"


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'If queryParams.UserId.Count <> 0 Then
        '    sqlStr = sqlStr & " Where user_id = @user_id "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        'End If
        'If Convert.ToString(queryParams.UserId.Count <> 0) Then
        sqlStr = sqlStr & "Where user_id = @user_id1 "
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id1", queryParams.UserId))
        'End If


        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag
    End Function


    Public Function UpdateDataMUser(queryParams As MUserModel) As Boolean

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim sqlStr As String = "update "

        sqlStr = sqlStr & "M_USER_data set "

        If Not String.IsNullOrEmpty(queryParams.DELFG) Then
            sqlStr = sqlStr & " DELFG = @DELFG, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", queryParams.DELFG))
        End If
        If Not String.IsNullOrEmpty(queryParams.UserId) Then
            sqlStr = sqlStr & " user_id = @user_id, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        End If

        If Not String.IsNullOrEmpty(queryParams.Surname) Then
            sqlStr = sqlStr & " surname = @surname, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@surname", queryParams.Surname))
        End If
        If Not String.IsNullOrEmpty(queryParams.Name) Then
            sqlStr = sqlStr & " name = @name, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@name", queryParams.Name))
        End If
        If Not String.IsNullOrEmpty(queryParams.Middle_Name) Then
            sqlStr = sqlStr & " mid_name = @mid_name, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@mid_name", queryParams.Middle_Name))
        End If
        If Not String.IsNullOrEmpty(queryParams.Birth_Day) Then
            sqlStr = sqlStr & " birthday = @birthday, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@birthday", queryParams.Birth_Day))
        End If

        If Not String.IsNullOrEmpty(queryParams.Sex) Then
            sqlStr = sqlStr & " sex = @sex, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@sex", queryParams.Sex))
        End If
        If Not String.IsNullOrEmpty(queryParams.Superior) Then
            sqlStr = sqlStr & " superior = @superior, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@superior", queryParams.Superior))
        End If
        If Not String.IsNullOrEmpty(queryParams.Address_Line_1) Then
            sqlStr = sqlStr & " add_1 = @add_1, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@add_1", queryParams.Address_Line_1))
        End If
        If Not String.IsNullOrEmpty(queryParams.Address_Line_2) Then
            sqlStr = sqlStr & " add_2 = @add_2, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@add_2", queryParams.Address_Line_2))
        End If
        If Not String.IsNullOrEmpty(queryParams.Address_Line_3) Then
            sqlStr = sqlStr & " add_3 = @add_3, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@add_3", queryParams.Address_Line_3))
        End If

        If Not String.IsNullOrEmpty(queryParams.Zip_Code) Then
            sqlStr = sqlStr & " zip = @zip, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@zip", queryParams.Zip_Code))
        End If

        If Not String.IsNullOrEmpty(queryParams.Telephone_1) Then
            sqlStr = sqlStr & " tel = @tel, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@tel", queryParams.Telephone_1))
        End If
        If Not String.IsNullOrEmpty(queryParams.Mobile) Then
            sqlStr = sqlStr & " mobile = @mobile, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@mobile", queryParams.Mobile))
        End If
        If Not String.IsNullOrEmpty(queryParams.Email_ID) Then
            sqlStr = sqlStr & " e_mail = @e_mail, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@e_mail", queryParams.Email_ID))
        End If
        If Not String.IsNullOrEmpty(queryParams.Telephone_2) Then
            sqlStr = sqlStr & " em_tel = @em_tel, "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@em_tel", queryParams.Telephone_2))
        End If



        sqlStr = sqlStr & "UPDDT= @UPDDT, "
        sqlStr = sqlStr & "UPDCD= @UPDCD "
        'sqlStr = sqlStr & "UPDPG=@UPDCD"


        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UPDCD))

        'If queryParams.UserId.Count <> 0 Then
        '    sqlStr = sqlStr & " Where user_id = @user_id "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.UserId))
        'End If
        If Convert.ToString(queryParams.UserId.Count <> 0) Then
            sqlStr = sqlStr & "Where user_id = @user_id1 "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id1", queryParams.UserId))
        End If


        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag
    End Function

End Class
