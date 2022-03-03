Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Imports System.Web.Hosting
Imports Microsoft.WindowsAPICodePack.Dialogs


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
        Header.Text = "RPA Task"
        If IsPostBack = False Then
            pageload()

        End If


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

    Public Sub pageload(Optional ByVal sortExpression As String = Nothing)
        Dim Rpamanagementmodel As New RpamanagementModel
        Dim Rpamanagementcontrol As New RpamanagementControl
        ' Rpamanagementmodel.TASK_NAME = txtSearch.Text
        Dim _Datatble As DataTable = Rpamanagementcontrol.Get_info(Rpamanagementmodel)


        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection

            getdata.DataSource = dv
        Else
            getdata.DataSource = _Datatble
        End If
        getdata.DataBind()
    End Sub
    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property


    Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        TaskName.Text = ""
        Textfilename.Text = ""
        Testeddate.Text = ""
        Status.SelectedValue = 0
        Duration.Text = ""
        Source.Text = ""
        del.Visible = False
        delfld.Checked = False
        btnUpload.Visible = True
        Edit.Visible = False
        Textfilename.Visible = False
        filename.Visible = True
        data.Visible = False
        addfile.Visible = True
        sourcepath.Visible = False
        Header.Text = "Create New - RPA Task"
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        data.Visible = True
        addfile.Visible = False
        Header.Text = "RPA Management"
        TaskName.Text = ""
        Textfilename.Text = ""
        Testeddate.Text = ""
        Status.SelectedValue = 0
        Duration.Text = ""
        Source.Text = ""

    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim delflg As String
        If delfld.Checked = True Then
            delflg = 1
        Else
            delflg = 0
        End If
        If TaskName.Text = "" Then
            Call showMsg("Please enter the task name", "")
            data.Visible = False
            addfile.Visible = True
            Exit Sub
        End If

        ' Dim path = "C:\Rpa\Tasks\"
        ' Dim serverpath = path & filename.FileName.ToString
        Dim strpath = System.IO.Path.GetExtension(filename.FileName)

        Dim strRootDirectory As String = HostingEnvironment.MapPath("~/")
        Dim path As String = strRootDirectory & "rpa\task"
        Dim serverpath As String = path & "\" & filename.FileName.ToString

        If (filename.FileName = "") Then

            Call showMsg("Please select the file", "")
            data.Visible = False
            addfile.Visible = True
            Exit Sub
        Else
            If (strpath <> ".py") Then
                Call showMsg("Please select valid file", "")
                data.Visible = False
                addfile.Visible = True
                Exit Sub
            End If
            If Testeddate.Text = "" Then
                Call showMsg("Please enter the tested date", "")
                data.Visible = False
                addfile.Visible = True
                Exit Sub
            End If
            If Status.SelectedValue = 0 Then
                Call showMsg("Please select status", "")
                data.Visible = False
                addfile.Visible = True
                Exit Sub
            End If
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

                    Dim Rpamanagementmodel As New RpamanagementModel
                    Dim Rpamanagementcontrol As New RpamanagementControl
                    Rpamanagementmodel.TASK_NAME = TaskName.Text
                    Rpamanagementmodel.FILE_NAME = filename.FileName
                    Rpamanagementmodel.PATH = path
                    Rpamanagementmodel.TEST_STATUS = Testeddate.Text
                    Rpamanagementmodel.RUN_DURATION = Duration.Text
                    Rpamanagementmodel.STATUS = Status.SelectedItem.Text
                    Rpamanagementmodel.DELFG = delflg

                    Rpamanagementmodel.CRTCD = Session("user_Name")

                    Dim insertCredit As Boolean = Rpamanagementcontrol.Insert_Rpa(Rpamanagementmodel)
                    If (insertCredit = True) Then
                        Call showMsg("RPA task created successfully", "")
                        filename.SaveAs(serverpath)
                        TaskName.Text = ""
                        Textfilename.Text = ""
                        Testeddate.Text = ""
                        Status.SelectedItem.Value = "0"
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

                End If

            End If

        End If



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
            If Not IsDBNull(_Datatble.Rows(0)("Path")) Then
                Source.Text = _Datatble.Rows(0)("Path")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("TEST_STATUS")) Then
                Testeddate.Text = _Datatble.Rows(0)("TEST_STATUS")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("STATUS")) Then
                If _Datatble.Rows(0)("STATUS") = "Active" Then
                    Status.SelectedItem.Value = 1
                ElseIf _Datatble.Rows(0)("STATUS") = "Inactive" Then
                    Status.SelectedItem.Value = 2

                Else

                    Status.SelectedItem.Value = 0
                End If
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
            del.Visible = True


            Header.Text = "Edit - RPA Task"

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
        'Dim strpath = System.IO.Path.GetExtension(filename.FileName)

        'Dim strRootDirectory As String = HostingEnvironment.MapPath("~/")
        'Dim path As String = strRootDirectory & "rpa\task"
        'Dim serverpath As String = path & "\" & filename.FileName.ToString

        'If (filename.FileName = "") Then

        '    Call showMsg("Please select the file", "")
        '    data.Visible = False
        '    addfile.Visible = True
        '    Exit Sub
        'Else
        '    If (strpath <> ".py") Then
        '        Call showMsg("Please select valid file", "")
        '        data.Visible = False
        '        addfile.Visible = True
        '        Exit Sub
        '    End If
        '    If Testeddate.Text = "" Then
        '        Call showMsg("Please enter the tested date", "")
        '        data.Visible = False
        '        addfile.Visible = True
        '        Exit Sub
        '    End If
        '    If Status.SelectedValue = 0 Then
        '        Call showMsg("Please select status", "")
        '        data.Visible = False
        '        addfile.Visible = True
        '        Exit Sub
        '    End If
        '    If System.IO.File.Exists(serverpath) Then
        '        Call showMsg("file already exists", "")
        '        data.Visible = False
        '        addfile.Visible = True
        '        Exit Sub
        '    Else
        '        If (Not System.IO.Directory.Exists(path)) Then

        '            Call showMsg("Folder is not exists", "")
        '            data.Visible = False
        '            addfile.Visible = True
        '            Exit Sub
        '        Else
        '            filename.SaveAs(serverpath)
        '        End If

        '    End If

        'End If

        Dim Rpamanagementmodel As New RpamanagementModel
        Dim Rpamanagementcontrol As New RpamanagementControl
        Rpamanagementmodel.TASK_NAME = TaskName.Text
        'Rpamanagementmodel.FILE_NAME = filename.FileName
        'Rpamanagementmodel.PATH = path
        Rpamanagementmodel.TEST_STATUS = Testeddate.Text
        Rpamanagementmodel.RUN_DURATION = Duration.Text
        Rpamanagementmodel.STATUS = Status.SelectedItem.Value
        Rpamanagementmodel.DELFG = delflg
        Rpamanagementmodel.TASKID = id.Text

        Rpamanagementmodel.UPDCD = Session("user_Name")

        Dim updated As Boolean = Rpamanagementcontrol.update_Rpa(Rpamanagementmodel)
        If (updated = True) Then
            Call showMsg("Success updated", "")

            TaskName.Text = ""
            Textfilename.Text = ""
            Testeddate.Text = ""
            Status.SelectedItem.Value = 0
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

    Private Sub filename_Load(sender As Object, e As EventArgs) Handles filename.Load

        ' CommonOpenFileDialog dialog = New CommonOpenFileDialog()
        '        Dialog.InitialDirectory = "C:\\Users";
        'dialog.IsFolderPicker = True;
        'If (dialog.ShowDialog() == CommonFileDialogResult.Ok) Then
        '            {
        '    MessageBox.Show("You selected: " + dialog.FileName);
        '}
        Dim Dialog As New CommonOpenFileDialog
        Dialog.InitialDirectory = "C:\"
        Dialog.Title = "Open a Text File"
        'Dialog.EnsureReadOnly = "Text Files|*.txt"
        'Dialog.ShowDialog()
    End Sub

    Protected Sub getdata_Sorting(sender As Object, e As GridViewSortEventArgs)
        Me.pageload(e.SortExpression)

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Me.pageload()
    End Sub

    Private Sub filename_DataBinding(sender As Object, e As EventArgs) Handles filename.DataBinding

        'Display a Dialog Box that allows to select a single file.
        'The path for the file picked will be stored in fullpath variable
        'With Application.FileDialog(msoFileDialogFilePicker)
        '    'Makes sure the user can select only one file
        '    .AllowMultiSelect = False
        '    'Filter to just the following types of files to narrow down selection options
        '    .Filters.Add "Excel Files", "*.xlsx; *.xlsm; *.xls; *.xlsb", 1
        ''Show the dialog box
        '    .Show

        '    'Store in fullpath variable
        '    fullpath = .SelectedItems.Item(1)
        'End With

        ''It's a good idea to still check if the file type selected is accurate.
        ''Quit the procedure if the user didn't select the type of file we need.
        'If InStr(fullpath, ".xls") = 0 Then
        '    Exit Sub
        'End If

        ''Open the file selected by the user
        'Workbooks.Open fullpath


    End Sub

    Private Sub filename_PreRender(sender As Object, e As EventArgs) Handles filename.PreRender

        Dim Dialog As New CommonOpenFileDialog
        Dialog.InitialDirectory = "C:\"
        Dialog.DefaultExtension = "txt"
        'Dialog.EnsureReadOnly = "Text Files|*.txt"
        ' Dialog.ShowDialog()

    End Sub

    Private Sub filename_Disposed(sender As Object, e As EventArgs) Handles filename.Disposed
        Dim Dialog As New CommonOpenFileDialog
        Dialog.InitialDirectory = "C:\"
        Dialog.DefaultExtension = "txt"
        'Dialog.EnsureReadOnly = "Text Files|*.txt"

    End Sub

    'Private Sub txtSearch1_Click(sender As Object, e As EventArgs) Handles txtSearch1.Click

    'End Sub

    'Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click

    'End Sub

    Protected Sub txtSearch1_Click1(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing)
        Dim Rpamanagementmodel As New RpamanagementModel
        Dim Rpamanagementcontrol As New RpamanagementControl
        Rpamanagementmodel.TASK_NAME = txtSearch.Text
        Dim _Datatble As DataTable = Rpamanagementcontrol.Get_info(Rpamanagementmodel)


        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection

            getdata.DataSource = dv
        Else
            getdata.DataSource = _Datatble
        End If
        getdata.DataBind()
    End Sub

    Protected Sub Clear_Click1(sender As Object, e As EventArgs)
        txtSearch.Text = ""
        Me.pageload()
    End Sub
End Class