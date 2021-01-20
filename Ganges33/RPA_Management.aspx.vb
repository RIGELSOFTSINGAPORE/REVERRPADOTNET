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

    Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        data.Visible = False
        addfile.Visible = True
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        data.Visible = True
        addfile.Visible = False
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim Rpamanagementmodel As New RpamanagementModel
        Dim Rpamanagementcontrol As New RpamanagementControl
        Rpamanagementmodel.TASK_NAME = TaskName.Text
        Rpamanagementmodel.FILE_NAME = filename.Text
        Rpamanagementmodel.PATH = Source.Text
        Rpamanagementmodel.TEST_STATUS = Testeddate.Text
        Rpamanagementmodel.RUN_DURATION = Duration.Text
        Rpamanagementmodel.STATUS = TaskName.Text
        Rpamanagementmodel.DELFG = TaskName.Text
        Dim insertCredit As Boolean = Rpamanagementcontrol.Insert_Rpa(Rpamanagementmodel)
        data.Visible = True
        addfile.Visible = False
    End Sub
End Class