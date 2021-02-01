Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class Changepasswordcontrol
    Public Function Get_Userdata(queryParams As MUserModel) As DataTable
        Dim MUserModel As MUserModel = New MUserModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT * From  M_User"

        If Not String.IsNullOrEmpty(queryParams.Password) Then
            sqlStr = sqlStr & " where user_id=@user_id AND Password = @Password "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Password", queryParams.oldPassword))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@user_id", queryParams.User_Id))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function

    Public Function Changepassword(queryParams As MUserModel) As Boolean
        Dim flag As Boolean
        Dim MUserModel As MUserModel = New MUserModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "update M_User set   "
        If Not String.IsNullOrEmpty(queryParams.Password) Then
            sqlStr = sqlStr & " Password = @Password where user_id=@user_id and Password=@Password1"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@User_id", queryParams.User_Id))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Password1", queryParams.oldPassword))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Password", queryParams.Password))

        End If


        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        dbConn.CloseConnection()
        Return flag
    End Function
End Class
