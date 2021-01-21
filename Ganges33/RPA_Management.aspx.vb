Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient

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
    Protected Sub showMsg(ByVal Msg As String, ByVal msgChk As String)

        lblMsg.Text = Msg
        Dim sScript As String

        If msgChk = "CancelMsg" Then
            'OKとキャンセルボタン
            sScript = "$(function () {$(""#dialog"" ).dialog({width: 400,buttons:{""OK"": function () {$(this).dialog('close');$('[id$=""BtnOK""]').click();},""CANCEL"": function () {$(this).dialog('close');$('[id$=""BtnCancel""]').click();}}});});"
        Else
            'OKボタンのみ
            sScript = "$(function () { $( ""#dialog"" ).dialog({width: 400, buttons: {""OK"": function () {$(this).dialog('close');}}});});"
        End If

        'JavaScriptの埋め込み
        ClientScript.RegisterStartupScript(Me.GetType(), "startup", sScript, True)

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
        Dim delflg As String
        If delfld.Checked = True Then
            delflg = 1
        Else
            delflg = 0
        End If
        Dim serverpath = "C:\Rpa\Tasks\" & filename.FileName
        Dim path As String
        Dim path1 As String
        path = Server.MapPath("~/RPA files")


        If (File.Exists(serverpath)) Then
            Call showMsg("file already exists", "")
            Exit Sub
        Else
            filename.SaveAs(path + filename.FileName)
            path1 = path + filename.FileName

            My.Computer.FileSystem.MoveFile(path1, serverpath)
        End If
        Dim Rpamanagementmodel As New RpamanagementModel
        Dim Rpamanagementcontrol As New RpamanagementControl
        Rpamanagementmodel.TASK_NAME = TaskName.Text
        ' Rpamanagementmodel.FILE_NAME = filename.Text
        'Rpamanagementmodel.PATH = Source.Text
        Rpamanagementmodel.TEST_STATUS = Testeddate.Text
        Rpamanagementmodel.RUN_DURATION = Duration.Text
        Rpamanagementmodel.STATUS = TaskName.Text
        Rpamanagementmodel.DELFG = delflg
        Rpamanagementmodel.IP_ADDRESS = Ipaddress.Text
        '  Rpamanagementmodel.   = Session("ship_Name")
        Rpamanagementmodel.CRTCD = Session("user_Name")
        'Rpamanagementmodel.= Session("user_level")
        'Rpamanagementmodel.= Session("admin_Flg")
        Dim insertCredit As Boolean = Rpamanagementcontrol.Insert_Rpa(Rpamanagementmodel)
        If (insertCredit = True) Then
            Call showMsg("Success updated", "")
            'Exit Sub
        Else
            Call showMsg("updated failed", "")
        End If
        data.Visible = True
        addfile.Visible = False
        pageload()
    End Sub

    'Protected Sub getdata_RowEditing(sender As Object, e As GridViewEditEventArgs)
    '    Dim iID = Convert.ToInt32((getdata.DataKeys[e.NewEditIndex].Value))

    'End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Dim row As GridViewRow = CType((TryCast(sender, Button)).NamingContainer, GridViewRow)
        Dim id = getdata.DataKeys(row.RowIndex).Values(0).ToString()
        Dim id2 = row.Cells(1).Text
    End Sub

    'Protected Sub getdata_RowCommand(sender As Object, e As GridViewCommandEventArgs)


    '    If (e.CommandName = "goto") Then


    '    End If
    'End Sub
End Class