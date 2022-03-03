Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Imports System.Web.Hosting
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class Holidays
    Inherits System.Web.UI.Page
    Dim flag As Boolean = False
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
        search.Visible = False
        Create.Visible = False
        btnShiphome.Visible = False
        Header.Text = "Holidays"
        If IsPostBack = False Then
            pageload()
            LoadDB()
            grid1.Visible = True
            grid2.Visible = False


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
        Dim Holidaysmodel As New HolidaysModel
        Dim Holidayscontrol As New HolidaysControl
        Holidaysmodel.SHIP_NAME = Session("id")
        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
        If (flag = True) Then
            ' Dim thisMonth1 As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)

            'beginning day of the month
            Dim dtBegin As DateTime = thisMonth.ToString("yyyy-MM-dd")

            'last day of the month
            Dim dtEnd As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
            txtSearch.Text = thisMonth.ToString("yyyy/MM/dd")
            txtSearch2.Text = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd")
            Holidaysmodel.HOLIDAY_DATE = txtSearch.Text
            Holidaysmodel.HOLIDAY_DATE_1 = txtSearch2.Text
        Else
            Dim dtBegin As DateTime = thisMonth.ToString("yyyy-MM-dd")


            Dim dtEnd As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
            Holidaysmodel.HOLIDAY_DATE = thisMonth.ToString("yyyy/MM/dd")
            Holidaysmodel.HOLIDAY_DATE_1 = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd")
        End If




        Dim _Datatble As DataTable = Holidayscontrol.Editinfo(Holidaysmodel)


        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection

            getdata.DataSource = dv

            data.Visible = True
            addfile.Visible = False
            Header.Text = "Holiday-Grid / " + Session("id")
            txtHoliday.Text = ""
            txtdate.Text = ""
            TextBox1.Visible = False
            grid2.Visible = True
            'Testeddate.Text = ""
            'Status.SelectedValue = 0
            Create.Visible = True
            btnShiphome.Visible = True
            'filename.Visible = False
            'Textfilename.Visible = True
            'data.Visible = False
            'addfile.Visible = False
            search.Visible = True
            'sourcepath.Visible = True
            del.Visible = False
        Else
            getdata.DataSource = _Datatble

        End If
        getdata.DataBind()

        'pageload()

    End Sub



    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Protected Sub getdata_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        getdata.PageIndex = e.NewPageIndex
        pageload()
        data.Visible = True
        addfile.Visible = False
        Header.Text = "Holiday-Grid / " + Session("id")
        txtHoliday.Text = ""
        txtdate.Text = ""
        TextBox1.Visible = False
        grid2.Visible = True
        'Testeddate.Text = ""
        'Status.SelectedValue = 0
        Create.Visible = True
        btnShiphome.Visible = True
        'filename.Visible = False
        'Textfilename.Visible = True
        'data.Visible = False
        'addfile.Visible = False
        search.Visible = True
        'sourcepath.Visible = True
        del.Visible = False
    End Sub
    Protected Sub getdata_Sorting(sender As Object, e As GridViewSortEventArgs)
        Me.pageload(e.SortExpression)

    End Sub

    Protected Sub txtSearch1_Click(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing)
        'Public Sub pageload(Optional ByVal sortExpression As String = Nothing)
        Dim Holidaysmodel As New HolidaysModel
        Dim Holidayscontrol As New HolidaysControl

        Dim strDateFrom As String = txtSearch.Text
        Dim strTodate As String = txtSearch2.Text
        strDateFrom = CDate(strDateFrom).ToString("yyyy/MM/dd")
        strTodate = CDate(strTodate).ToString("yyyy/MM/dd")


        Holidaysmodel.HOLIDAY_DATE = strDateFrom
        Holidaysmodel.HOLIDAY_DATE_1 = strTodate
        Holidaysmodel.SHIP_NAME = id.Text
        Dim _Datatble As DataTable = Holidayscontrol.Editinfo(Holidaysmodel)


        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection

            getdata.DataSource = dv
        Else
            getdata.DataSource = _Datatble
        End If
        getdata.DataBind()

        Create.Visible = True
        btnShiphome.Visible = True
        Header.Text = "Holidays " + Session("id")
        'filename.Visible = False
        'Textfilename.Visible = True
        'data.Visible = False
        'addfile.Visible = False
        search.Visible = True
        'sourcepath.Visible = True
        del.Visible = False
        'End Sub
    End Sub


    Public Sub LoadDB()

        Dim HolidaysModel As New HolidaysModel
        Dim Holidayscontrol As New HolidaysControl
        Dim _Datatble As DataTable = Holidayscontrol.Get_infoShip(HolidaysModel)
        Dim _dataview As New DataView(_Datatble)
        gridship.DataSource = _dataview
        gridship.DataBind()

    End Sub




    'Protected Sub Clear_Click(sender As Object, e As EventArgs)

    '    data.Visible = True
    '    addfile.Visible = False
    '    pageload()
    '    data.Visible = True
    '    addfile.Visible = False
    '    Header.Text = "Holidays " + Session("id")
    '    txtHoliday.Text = ""
    '    txtdate.Text = ""
    '    TextBox1.Visible = False
    '    grid2.Visible = True
    '    'Testeddate.Text = ""
    '    'Status.SelectedValue = 0
    '    Create.Visible = True
    '    btnShiphome.Visible = True
    '    'filename.Visible = False
    '    'Textfilename.Visible = True
    '    'data.Visible = False
    '    'addfile.Visible = False
    '    search.Visible = True
    '    'sourcepath.Visible = True
    '    del.Visible = False
    '    flag = True
    '    Me.pageload()
    'End Sub

    Private Sub InitDropDownList1()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropdownList1.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchSSCCreditInfo(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")


        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        codeMaster2.CodeValue = "Select"
        codeMaster2.CodeDispValue = "Select"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropdownList1.DataSource = codeMasterList
        Me.DropdownList1.DataTextField = "CodeDispValue"
        Me.DropdownList1.DataValueField = "CodeValue"
        Me.DropdownList1.DataBind()
        'Me.DropdownList1.Items.Remove("All")
    End Sub

    Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        'InitDropDownList1()
        txtHoliday.Text = ""
        txtdate.Text = ""
        TextBox1.Visible = True
        TextBox1.Text = Session("id")
        DropdownList1.Visible = False
        'Testeddate.Text = ""
        'DropDownList1.Items.Clear()
        addfile.Visible = True
        'Status.SelectedValue = 0
        'Duration.Text = ""
        'Source.Text = ""
        del.Visible = False
        delfld.Checked = False
        btnUpload.Visible = True
        btnShiphome.Visible = True
        Edit.Visible = False
        'Textfilename.Visible = False
        'filename.Visible = True
        data.Visible = False
        addfile.Visible = True
        'sourcepath.Visible = False
        Header.Text = "Create New - Holiday " + Session("id")
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        data.Visible = True
        addfile.Visible = False
        Header.Text = "Holiday-Grid / " + Session("id")
        txtHoliday.Text = ""
        txtdate.Text = ""
        TextBox1.Visible = False
        grid2.Visible = True
        'Testeddate.Text = ""
        'Status.SelectedValue = 0
        Create.Visible = True
        btnShiphome.Visible = True
        'filename.Visible = False
        'Textfilename.Visible = True
        'data.Visible = False
        'addfile.Visible = False
        search.Visible = True
        'sourcepath.Visible = True
        del.Visible = False
        'Duration.Text = ""
        'Source.Text = ""
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim delflg As String
        If delfld.Checked = True Then
            delflg = 1
        Else
            delflg = 0
        End If


        If txtHoliday.Text = "" Then
            Call showMsg("Please enter the Holiday name", "")
            data.Visible = False
            addfile.Visible = True
            Exit Sub
        End If

        If txtdate.Text = "" Then
            Call showMsg("Please Select the date", "")
            data.Visible = False
            addfile.Visible = True
            Exit Sub
        End If

        'If DropdownList1.SelectedItem.Text = "Select" Then
        '    Call showMsg("Please Select Branch Name", "")
        '    data.Visible = False
        '    addfile.Visible = True
        '    Exit Sub
        'End If




        Dim Holidaysmodel As New HolidaysModel
        Dim Holidayscontrol As New HolidaysControl
        Holidaysmodel.HOLIDAY_TEXT = txtHoliday.Text
        Holidaysmodel.HOLIDAY_DATE = txtdate.Text



        Holidaysmodel.SHIP_NAME = TextBox1.Text


        Holidaysmodel.DELFG = delflg

        Holidaysmodel.CRTCD = Session("user_Name")
        Holidaysmodel.UPDCD = Session("user_Name")
        Holidaysmodel.UPDPG = "StoreName"

        Dim dataVal As DataTable = Holidayscontrol.Get_info2(Holidaysmodel)

        If dataVal.Rows.Count <> 0 Then
            Call showMsg("Unable to create <br/> Date already exist", "")
            pageload()
            data.Visible = True
            addfile.Visible = False
            Header.Text = "Holiday-Grid / " + Session("id")
            txtHoliday.Text = ""
            txtdate.Text = ""
            TextBox1.Visible = False
            grid2.Visible = True
            'Testeddate.Text = ""
            'Status.SelectedValue = 0
            Create.Visible = True
            btnShiphome.Visible = True
            'filename.Visible = False
            'Textfilename.Visible = True
            'data.Visible = False
            'addfile.Visible = False
            search.Visible = True
            'sourcepath.Visible = True
            del.Visible = False
            Exit Sub
        End If
        'If Not IsDBNull(dataVal.Rows(0)("HOLIDAY_DATE")) Then
        '    If txtdate.Text = dataVal.Rows(0)("HOLIDAY_DATE") Then
        '        Call showMsg("Date already exist", "")
        '        Exit Sub

        '    End If

        'End If

        Dim insertHolidays As Boolean = Holidayscontrol.insert_holidays(Holidaysmodel)
        If (insertHolidays = True) Then
            Call showMsg("Holiday created successfully", "")
            'filename.SaveAs(serverpath)
            txtHoliday.Text = ""
            txtdate.Text = ""
            'Testeddate.Text = ""
            'Status.SelectedItem.Value = "0"
            ' Duration.Text = ""
            delfld.Checked = False

        Else
            Call showMsg("Failed to save Holiday", "")
            data.Visible = False
                        addfile.Visible = True
                    End If

                    data.Visible = True
                    addfile.Visible = False
        pageload()
        data.Visible = True
        addfile.Visible = False
        Header.Text = "Holiday-Grid / " + Session("id")
        txtHoliday.Text = ""
        txtdate.Text = ""
        TextBox1.Visible = False
        grid2.Visible = True
        'Testeddate.Text = ""
        'Status.SelectedValue = 0
        Create.Visible = True
        btnShiphome.Visible = True
        'filename.Visible = False
        'Textfilename.Visible = True
        'data.Visible = False
        'addfile.Visible = False
        search.Visible = True
        'sourcepath.Visible = True
        del.Visible = False

        'End If

        'End If

        'End If
    End Sub

    Private Sub Edit_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Dim delflg As String
        If delfld.Checked = True Then
            delflg = 1
        Else
            delflg = 0
        End If


        Dim Holidaysmodel As New HolidaysModel
        Dim Holidayscontrol As New HolidaysControl
        Holidaysmodel.HOLIDAY_TEXT = txtHoliday.Text
        'Rpamanagementmodel.FILE_NAME = filename.FileName
        'Rpamanagementmodel.PATH = path
        Holidaysmodel.HOLIDAY_DATE = txtdate.Text
        Holidaysmodel.SHIP_NAME = TextBox1.Text
        'Holidaysmodel.STATUS = Status.SelectedItem.Value
        Holidaysmodel.DELFG = delflg
        Holidaysmodel.UNQ_NO = id.Text

        Holidaysmodel.UPDCD = Session("user_Name")

        Dim updated As Boolean = Holidayscontrol.update_Holidays(Holidaysmodel)
        If (updated = True) Then
            Call showMsg("Holiday updated successfully", "")

            txtHoliday.Text = ""
            txtdate.Text = ""
            TextBox1.Visible = False
            ' Status.SelectedItem.Value = 0
            'Duration.Text = ""
            delfld.Checked = False


        Else
            Call showMsg("Holiday Updated failed", "")
            data.Visible = False
            addfile.Visible = True
        End If

        'search.Visible = True
        'addfile.Visible = False

        ''Header.Text = 
        'grid2.Visible = True
        'grid1.Visible = False

        data.Visible = True
        addfile.Visible = False
        pageload()
        data.Visible = True
        addfile.Visible = False
        Header.Text = "Holiday-Grid / " + Session("id")
        txtHoliday.Text = ""
        txtdate.Text = ""
        TextBox1.Visible = False
        grid2.Visible = True
        'Testeddate.Text = ""
        'Status.SelectedValue = 0
        Create.Visible = True
        btnShiphome.Visible = True
        'filename.Visible = False
        'Textfilename.Visible = True
        'data.Visible = False
        'addfile.Visible = False
        search.Visible = True
        'sourcepath.Visible = True
        del.Visible = False

        'pageload()

    End Sub

    Protected Sub gridship_RowCommand(sender As Object, e As GridViewCommandEventArgs, Optional ByVal sortExpression As String = Nothing)
        'Dim dt As DateTime = DateTime.Now
        'Dim dtBegin As DateTime = dt.AddDays(-(dt.Day - 1))
        'Dim dtEnd As DateTime = dtBegin.AddMonths(1).AddDays(-1)

        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)

        'beginning day of the month
        Dim dtBegin As DateTime = thisMonth.ToString("yyyy-MM-dd")

        'last day of the month
        Dim dtEnd As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
        txtSearch.Text = thisMonth.ToString("yyyy/MM/dd")
        txtSearch2.Text = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd")

        'Dim dDate As DateTime = Date.Today
        If e.CommandName = "goto1" Then
            Dim index As String = Convert.ToString(e.CommandArgument)


            Dim Holidaysmodel As New HolidaysModel
            Dim Holidayscontrol As New HolidaysControl
            Holidaysmodel.SHIP_NAME = index
            id.Text = index
            Holidaysmodel.HOLIDAY_DATE = dtBegin
            Holidaysmodel.HOLIDAY_DATE_1 = dtEnd

            Dim _Datatble As DataTable = Holidayscontrol.Editinfo(Holidaysmodel)

            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = _Datatble.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection

                getdata.DataSource = dv
            Else
                getdata.DataSource = _Datatble
            End If
            getdata.DataBind()



            DropdownList1.Visible = False
            TextBox1.Visible = False
            btnUpload.Visible = False
            ' btnShiphome.Visible = False
            Edit.Visible = False
            grid1.Visible = False
            grid2.Visible = True

            Create.Visible = True
            btnShiphome.Visible = True
            'filename.Visible = False
            'Textfilename.Visible = True
            'data.Visible = False
            'addfile.Visible = False
            search.Visible = True
            'sourcepath.Visible = True
            del.Visible = False
            Header.Text = "Holiday-Grid / " + id.Text
            Session("id") = id.Text
        End If


    End Sub




    Protected Sub getdata_RowCommand1(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "goto" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)


            Dim Holidaysmodel As New HolidaysModel
            Dim Holidayscontrol As New HolidaysControl
            Holidaysmodel.UNQ_NO = index
            id.Text = index
            Dim _Datatble As DataTable = Holidayscontrol.Editinfo1(Holidaysmodel)
            If Not IsDBNull(_Datatble.Rows(0)("HOLIDAY_TEXT")) Then
                txtHoliday.Text = _Datatble.Rows(0)("HOLIDAY_TEXT")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("HOLIDAY_DATE")) Then
                txtdate.Text = _Datatble.Rows(0)("HOLIDAY_DATE")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("SHIP_NAME")) Then
                TextBox1.Text = _Datatble.Rows(0)("SHIP_NAME")
            End If


            'End If
            If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
                If _Datatble.Rows(0)("DELFG") = 0 Then
                    delfld.Checked = False
                Else
                    delfld.Checked = True
                End If
            End If

            DropdownList1.Visible = False
            TextBox1.Visible = True
            btnUpload.Visible = False
            'btnShiphome.Visible = False
            search.Visible = False
            Create.Visible = True
            btnShiphome.Visible = True
            Edit.Visible = True
            grid1.Visible = False
            grid2.Visible = False
            Back.Visible = True
            'Textfilename.Visible = True
            data.Visible = False
            addfile.Visible = True
            'sourcepath.Visible = True
            del.Visible = True


            Header.Text = "Edit - Holiday " + Session("id")
        End If

    End Sub

    Private Sub btnShiphome_Click(sender As Object, e As EventArgs) Handles btnShiphome.Click
        addfile.Visible = False
        search.Visible = False
        Create.Visible = False
        grid1.Visible = True
        grid2.Visible = False
        LoadDB()
    End Sub

    Protected Sub txtSearch1_Click1(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing)
        Dim Holidaysmodel As New HolidaysModel
        Dim Holidayscontrol As New HolidaysControl
        Dim strDateFrom As String = txtSearch.Text
        Dim strTodate As String = txtSearch2.Text
        strDateFrom = CDate(strDateFrom).ToString("yyyy/MM/dd")
        strTodate = CDate(strTodate).ToString("yyyy/MM/dd")


        Holidaysmodel.HOLIDAY_DATE = strDateFrom
        Holidaysmodel.HOLIDAY_DATE_1 = strTodate
        Holidaysmodel.SHIP_NAME = id.Text
        Dim _Datatble As DataTable = Holidayscontrol.Editinfo(Holidaysmodel)


        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection

            getdata.DataSource = dv
        Else
            getdata.DataSource = _Datatble
        End If
        getdata.DataBind()

        Create.Visible = True
        btnShiphome.Visible = True
        Header.Text = "Holiday-Grid / " + Session("id")
        'filename.Visible = False
        'Textfilename.Visible = True
        'data.Visible = False
        'addfile.Visible = False
        search.Visible = True
        'sourcepath.Visible = True
        del.Visible = False
    End Sub

    Private Sub gridship_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gridship.PageIndexChanging
        gridship.PageIndex = e.NewPageIndex
        LoadDB()
    End Sub
End Class