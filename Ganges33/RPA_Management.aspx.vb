Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Imports System.Configuration

Public Class RPA_Management
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userid As String = Session("user_id")
        If userid = "" Then
            Response.Redirect("Login.aspx")
        End If

        '***ログインユーザ情報表示***
        Dim setShipname As String = Session("ship_Name")
        Dim userName As String = Session("user_Name")
        Dim userLevel As String = Session("user_level")
        Dim adminFlg As Boolean = Session("admin_Flg")
        addfile.Visible = False
        pageload()
    End Sub
    Public Sub pageload()
        Dim Rpamanagementmodel As New RpamanagementModel
        Dim Rpamanagementcontrol As New RpamanagementControl
        Dim _Datatble As DataTable = Rpamanagementcontrol.Get_info(Rpamanagementmodel)
        Dim _dataview As New DataView(_Datatble)
        getdata.DataSource = _dataview
        getdata.DataBind()
    End Sub

End Class