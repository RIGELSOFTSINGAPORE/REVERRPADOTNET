Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class RpamanagementControl
    Public Function Get_info(queryParams As RpamanagementModel) As DataTable
        Dim RpamanagementModel As RpamanagementModel = New RpamanagementModel()
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim sqlStr As String = "SELECT * from RPA_TASK_MST "
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
End Class
