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
        Header.Text = "RPA Management"
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
        TaskName.Text = ""
        Textfilename.Text = ""
        Testeddate.Text = ""
        Status.Text = ""
        Duration.Text = ""
        Source.Text = ""
        delfld.Checked = False
        btnUpload.Visible = True
        Edit.Visible = False
        Textfilename.Visible = False
        filename.Visible = True
        data.Visible = False
        addfile.Visible = True
        sourcepath.Visible = False
        Header.Text = "RPA Management-Create"
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        data.Visible = True
        addfile.Visible = False
        Header.Text = "RPA Management"
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim delflg As String
        If delfld.Checked = True Then
            delflg = 1
        Else
            delflg = 0
        End If
        Dim path = "C:\Rpa\Tasks\"
        Dim serverpath = path & filename.FileName.ToString


        If (filename.FileName = "") Then

            Call showMsg("Please select the file", "")
            data.Visible = False
            addfile.Visible = True
            Exit Sub
        Else

            If System.IO.File.Exists(serverpath) Then
                Call showMsg("file already exists", "")
                data.Visible = False
                addfile.Visible = True
                Exit Sub
            Else
                If (Not System.IO.Directory.Exists(path)) Then

                    Call showMsg("Folder is not exists", "")
                    data.Visible = False
                    addfile.Visible = True
                    Exit Sub
                Else
                    filename.SaveAs(serverpath + filename.FileName)
                End If

            End If

        End If



        Dim Rpamanagementmodel As New RpamanagementModel
        Dim Rpamanagementcontrol As New RpamanagementControl
        Rpamanagementmodel.TASK_NAME = TaskName.Text
        Rpamanagementmodel.FILE_NAME = filename.FileName
        Rpamanagementmodel.PATH = path
        Rpamanagementmodel.TEST_STATUS = Testeddate.Text
        Rpamanagementmodel.RUN_DURATION = Duration.Text
        Rpamanagementmodel.STATUS = TaskName.Text
        Rpamanagementmodel.DELFG = delflg

        Rpamanagementmodel.CRTCD = Session("user_Name")

        Dim insertCredit As Boolean = Rpamanagementcontrol.Insert_Rpa(Rpamanagementmodel)
        If (insertCredit = True) Then
            Call showMsg("Success Saved", "")

            TaskName.Text = ""
            Textfilename.Text = ""
            Testeddate.Text = ""
            Status.Text = ""
            Duration.Text = ""
            delfld.Checked = False

        Else
            Call showMsg("Failed to save", "")
            data.Visible = False
            addfile.Visible = True
        End If

        data.Visible = True
        addfile.Visible = False
        pageload()
    End Sub


    Protected Sub getdata_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "goto" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)


            Dim Rpamanagementmodel As New RpamanagementModel
            Dim Rpamanagementcontrol As New RpamanagementControl
            Rpamanagementmodel.TASKID = index
            id.Text = index
            Dim _Datatble As DataTable = Rpamanagementcontrol.Get_info(Rpamanagementmodel)
            If Not IsDBNull(_Datatble.Rows(0)("TASK_NAME")) Then
                TaskName.Text = _Datatble.Rows(0)("TASK_NAME")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("FILE_NAME")) Then
                Textfilename.Text = _Datatble.Rows(0)("FILE_NAME")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("TEST_STATUS")) Then
                Testeddate.Text = _Datatble.Rows(0)("TEST_STATUS")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("STATUS")) Then
                Status.Text = _Datatble.Rows(0)("STATUS")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("RUN_DURATION")) Then
                Duration.Text = _Datatble.Rows(0)("RUN_DURATION")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
                If _Datatble.Rows(0)("DELFG") = 0 Then
                    delfld.Checked = False
                Else
                    delfld.Checked = True
                End If
            End If
            btnUpload.Visible = False
            Edit.Visible = True
            filename.Visible = False
            Textfilename.Visible = True
            data.Visible = False
            addfile.Visible = True
            sourcepath.Visible = True

            Header.Text = "RPA Management-Edit"
        End If

    End Sub

    Protected Sub getdata_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        getdata.PageIndex = e.NewPageIndex
        pageload()
    End Sub

    Private Sub Edit_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Dim delflg As String
        If delfld.Checked = True Then
            delflg = 1
        Else
            delflg = 0
        End If
        'Dim serverpath = "C:\Rpa\Tasks\" & filename.FileName
        'Dim path As String
        'Dim path1 As String
        'path = Server.MapPath("~/RPA files")


        'If (File.Exists(serverpath)) Then
        '    Call showMsg("file already exists", "")
        '    Exit Sub
        'Else
        '    filename.SaveAs(path + filename.FileName)
        '    path1 = path + filename.FileName

        '    My.Computer.FileSystem.MoveFile(path1, serverpath)
        'End If
        Dim Rpamanagementmodel As New RpamanagementModel
        Dim Rpamanagementcontrol As New RpamanagementControl
        Rpamanagementmodel.TASK_NAME = TaskName.Text
        Rpamanagementmodel.FILE_NAME = filename.FileName
        'Rpamanagementmodel.PATH = path
        Rpamanagementmodel.TEST_STATUS = Testeddate.Text
        Rpamanagementmodel.RUN_DURATION = Duration.Text
        Rpamanagementmodel.STATUS = TaskName.Text
        Rpamanagementmodel.DELFG = delflg
        Rpamanagementmodel.TASKID = id.Text

        Rpamanagementmodel.CRTCD = Session("user_Name")

        Dim updated As Boolean = Rpamanagementcontrol.update_Rpa(Rpamanagementmodel)
        If (updated = True) Then
            Call showMsg("Success updated", "")

            TaskName.Text = ""
            Textfilename.Text = ""
            Testeddate.Text = ""
            Status.Text = ""
            Duration.Text = ""
            delfld.Checked = False

        Else
            Call showMsg("updated failed", "")
            data.Visible = False
            addfile.Visible = True
        End If

        data.Visible = True
        addfile.Visible = False
        pageload()
    End Sub
End Class