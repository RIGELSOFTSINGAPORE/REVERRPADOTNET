Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic

Public Class LoginControl



    Public Function SelectUser(ByVal queryParams As LoginModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & " * "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "M_USER "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.USER_ID) Then
            sqlStr = sqlStr & "AND USER_ID = @USER_ID "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@USER_ID", queryParams.USER_ID))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
End Class
