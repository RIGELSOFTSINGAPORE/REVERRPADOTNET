Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Public Class Popup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim value As String = Request.QueryString("rowIndex")

        Console.WriteLine("value**** " + value)
        '   Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        '' Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        'Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        'Dim _dataview As New DataView(_Datatble)


        'Dim DateTimeNow As DateTime = DateTime.Now
        'Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        'Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Dim dbConn As DBUtility = New DBUtility()
        'Dim dt As DataTable = New DataTable()
        'Dim flag As Boolean = False
        'Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & " * from M_SHIP_BASE "
        'If queryParams.SHIP_CODE <> 0 Then
        '    sqlStr = sqlStr & "Where @SHIP_CODE = ship_code "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_CODE", queryParams.SHIP_CODE))
        'End If

        'Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        'dbConn.CloseConnection()



        Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        Dim _dataview As New DataView(_Datatble)
        ' getdata.DataSource = _dataview



        '    inspection3_start
        CRTDT.InnerText = "server side"
    End Sub

End Class