Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Web.UI.WebControls
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Analysis_User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            '***ログインユーザ情報表示***
            Dim setShipname As String = Session("ship_Name")
            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            Dim adminFlg As Boolean = Session("admin_Flg")
            AddUser.Visible = False
            Header.Text = "User Management"
            'show grid
            ShowGrid()
        End If

    End Sub

    Protected Sub GridSetupUser_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridSetupUser.PageIndex = e.NewPageIndex
        ShowGrid()
    End Sub

    Private Sub ShowGrid()
        Dim _MUserControl As MUserControl = New MUserControl()
        Dim dt As DataTable = _MUserControl.ShowMUserGrid()
        Dim dv As DataView = New DataView(dt)

        ' dv.Sort = "ServiceOrder_No " & Me.SortDirection
        GridSetupUser.DataSource = dv
        GridSetupUser.DataBind()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        GridSetupUser.Visible = False
        AddUser.Visible = True
        btnCreate.Visible = True
        btnAdd.Visible = False
        lblUsername.Visible = True
        txtUserId.Visible = True
        listShipBranch.Visible = False
        txtBranchCode1.Visible = True
        Edit.Visible = False
        txtUserId.Text = ""
        delflag.Checked = False
        admindelflg.Checked = False
        'radionGender.Items.Clear()
        txtBranchCode2.Text = ""
        txtSuperior.Text = ""
        txtZipCode.Text = ""
        txtMobile.Text = ""
        txtEmailId.Text = ""
        txtTelephone1.Text = ""
        txtAddressLine1.Text = ""
        txtAddressLine2.Text = ""
        txtTelephone.Text = ""
        txtAddressLine3.Text = ""
        txtdob.Text = ""
        txtBranchCode3.Text = ""
        txtBranchCode4.Text = ""
        txtMiddleName.Text = ""
        txtName.Text = ""
        txtBranchCode1.Text = ""
        txtUserlvl.Text = ""
        txtSurname.Text = ""
        txtPassword.Text = ""
        txtBranchCode5.Text = ""
        txtUserId.Text = ""
        txtEnggId.Text = ""

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


    Protected Sub btnCreate_Click(sender As Object, e As EventArgs)
        Dim delflg As String
        If delflag.Checked = True Then
            delflg = 1
        Else
            delflg = 0
        End If

        Dim adminflag As String
        If admindelflg.Checked = True Then
            adminflag = 1
        Else
            adminflag = 0
        End If

        Dim genderid As Integer

        If radionGender.SelectedValue = "1" Then
            genderid = True
        Else
            genderid = False

        End If

        'If radionGender.SelectedItem.Value = "Male" Then

        '    genderid = radionGender.SelectedItem.Value
        'Else
        '    genderid = radionGender.SelectedItem.Value
        'End If



        Dim MuserModel As MUserModel = New MUserModel()
        Dim MUserControl As MUserControl = New MUserControl()

        MuserModel.UPDCD = Session("user_id").ToString
        MuserModel.CRTCD = Session("user_id").ToString
        MuserModel.UPDPG = "Class_Store.vb"
        MuserModel.DELFG = delflg


        MuserModel.UserId = txtUserId.Text

        'If txtUserId.Text = DataTable

        MuserModel.Password = txtPassword.Text
        MuserModel.eng_id = txtEnggId.Text
        MuserModel.admin_flg = adminflag
        MuserModel.user_level = txtUserlvl.Text
        MuserModel.ship_1 = txtBranchCode1.Text
        MuserModel.ship_2 = txtBranchCode2.Text
        MuserModel.ship_3 = txtBranchCode3.Text
        MuserModel.ship_4 = txtBranchCode4.Text

        MuserModel.ship_5 = txtBranchCode5.Text

        MuserModel.Surname = txtSurname.Text
        MuserModel.Name = txtName.Text
        MuserModel.Middle_Name = txtMiddleName.Text
        MuserModel.Birth_Day = txtdob.Text
        MuserModel.Sex = genderid
        MuserModel.Superior = txtSuperior.Text

        MuserModel.Address_Line_1 = txtAddressLine1.Text
        MuserModel.Address_Line_2 = txtAddressLine2.Text
        MuserModel.Address_Line_3 = txtAddressLine3.Text
        MuserModel.Zip_Code = txtZipCode.Text
        MuserModel.Telephone_1 = txtTelephone.Text

        MuserModel.Mobile = txtMobile.Text
        MuserModel.Email_ID = txtEmailId.Text
        MuserModel.Telephone_2 = txtTelephone1.Text

        'MuserModel.UserId = Session("user_id").ToString

        Dim isInserted As Boolean = MUserControl.MUserInsert(MuserModel)

        'Dim MUserDataInserted As Boolean

        If (isInserted = True) Then
            Dim MUserDataInserted As Boolean = MUserControl.MUserDataInsert(MuserModel)

            If (MUserDataInserted = True) Then
                Call showMsg("Create Successfully", "")

                txtUserId.Text = ""
                delflag.Checked = False
                admindelflg.Checked = False
                radionGender.Items.Clear()
                txtBranchCode2.Text = ""
                txtSuperior.Text = ""
                txtZipCode.Text = ""
                txtMobile.Text = ""
                txtEmailId.Text = ""
                txtTelephone1.Text = ""
                txtAddressLine1.Text = ""
                txtAddressLine2.Text = ""
                txtTelephone.Text = ""
                txtAddressLine3.Text = ""
                txtdob.Text = ""
                txtBranchCode3.Text = ""
                txtBranchCode4.Text = ""
                txtMiddleName.Text = ""
                txtName.Text = ""
                txtBranchCode1.Text = ""
                txtUserlvl.Text = ""
                txtSurname.Text = ""
                txtPassword.Text = ""
                txtBranchCode5.Text = ""
                txtUserId.Text = ""
                txtEnggId.Text = ""


            Else
                Call showMsg("Create Failed", "")
                GridSetupUser.Visible = False
                btnAdd.Visible = False
                AddUser.Visible = True
                Exit Sub
            End If




        End If
        GridSetupUser.Visible = True
        AddUser.Visible = False
        btnAdd.Visible = True
        Header.Text = "User Management"
        'Response.Redirect("")
        ShowGrid()
    End Sub

    Protected Sub GridSetupUser_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "goto" Then
            Dim index As String = Convert.ToString(e.CommandArgument)

            Dim shipBranch As String

            Dim MuserModel As MUserModel = New MUserModel()
            Dim MUserControl As MUserControl = New MUserControl()
            MuserModel.UserId = index
            id.Text = index


            Dim _Datatble As DataTable = MUsercontrol.GetUserInfo(MUsermodel)
            'If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
            '    delflag.Text = _Datatble.Rows(0)("DELFG")
            'End If
            If Not IsDBNull(_Datatble.Rows(0)("user_id")) Then
                txtUserId.Text = _Datatble.Rows(0)("user_id")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("password")) Then
                txtPassword.Text = _Datatble.Rows(0)("password")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("eng_id")) Then
                txtEnggId.Text = _Datatble.Rows(0)("eng_id")
            End If


            If Not IsDBNull(_Datatble.Rows(0)("user_level")) Then
                txtUserlvl.Text = _Datatble.Rows(0)("user_level")
            End If
            ' Dim code As Int16 = 0

            If Not IsDBNull(_Datatble.Rows(0)("ship_1")) Then
                shipBranch = _Datatble.Rows(0)("ship_1")
                Dim elements() As String = shipBranch.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                For Each element As String In elements
                    listShipBranch.Items.Add(New ListItem(element, ""))
                Next


            End If

            If Not IsDBNull(_Datatble.Rows(0)("ship_2")) Then
                txtBranchCode2.Text = _Datatble.Rows(0)("ship_2")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("ship_3")) Then
                txtBranchCode3.Text = _Datatble.Rows(0)("ship_3")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("ship_4")) Then
                txtBranchCode4.Text = _Datatble.Rows(0)("ship_4")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("ship_5")) Then
                txtBranchCode5.Text = _Datatble.Rows(0)("ship_5")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("surname")) Then
                txtSurname.Text = _Datatble.Rows(0)("surname")
            End If

            If Not IsDBNull(_Datatble.Rows(0)("name")) Then
                txtName.Text = _Datatble.Rows(0)("name")
            End If

            If Not IsDBNull(_Datatble.Rows(0)("mid_name")) Then
                txtMiddleName.Text = _Datatble.Rows(0)("mid_name")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("birthday")) Then
                txtdob.Text = _Datatble.Rows(0)("birthday")
            End If


            If Not IsDBNull(_Datatble.Rows(0)("sex")) Then
                If _Datatble.Rows(0)("sex") = 0 Then
                    radionGender.SelectedValue = 0
                Else
                    radionGender.SelectedValue = 1
                End If
            End If

            If Not IsDBNull(_Datatble.Rows(0)("superior")) Then
                txtSuperior.Text = _Datatble.Rows(0)("superior")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("add_1")) Then
                txtAddressLine1.Text = _Datatble.Rows(0)("add_1")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("add_2")) Then
                txtAddressLine2.Text = _Datatble.Rows(0)("add_2")
            End If

            If Not IsDBNull(_Datatble.Rows(0)("add_3")) Then
                txtAddressLine3.Text = _Datatble.Rows(0)("add_3")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("zip")) Then
                txtZipCode.Text = _Datatble.Rows(0)("zip")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("tel")) Then
                txtTelephone.Text = _Datatble.Rows(0)("tel")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("mobile")) Then
                txtMobile.Text = _Datatble.Rows(0)("mobile")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("e_mail")) Then
                txtEmailId.Text = _Datatble.Rows(0)("e_mail")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("em_tel")) Then
                txtTelephone1.Text = _Datatble.Rows(0)("em_tel")
            End If


            If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
                If _Datatble.Rows(0)("DELFG") = 0 Then
                    delflag.Checked = False
                Else
                    delflag.Checked = True
                End If
            End If
            If Not IsDBNull(_Datatble.Rows(0)("admin_flg")) Then
                If _Datatble.Rows(0)("admin_flg") = 0 Then
                    admindelflg.Checked = False
                Else
                    admindelflg.Checked = True
                End If
            End If

            'btnUpload.Visible = False
            Edit.Visible = True
            txtBranchCode1.Visible = False
            txtUserId.Visible = False
            lblUsername.Visible = False
            txtUserId.Visible = False
            'filename.Visible = False
            'Textfilename.Visible = True
            btnAdd.Visible = False
            listShipBranch.Visible = True
            GridSetupUser.Visible = False
            AddUser.Visible = True
            btnCreate.Visible = False
            Header.Text = "User Management-Edit"
            'Dim cstype As Type = Me.GetType()
            'Dim str2 As String = "window.open('Analysis_Servicecenter.aspx?UserId=" & index & "','myWindow','width=800,height=500,left=100,top=100,resizable=yes')"
            ''Client.RegisterStartupScript(This.GetType(), "script", str2, True)
            'ClientScript.RegisterStartupScript(cstype, "script", str2, True)

        End If

    End Sub

    Protected Sub Edit_Click(sender As Object, e As EventArgs) Handles Edit.Click

        'Dim index As String = Convert.ToString(e.CommandArgument)


        ''Dim MUsermodel As New MUserModel
        ''Dim MUsercontrol As New MUserControl
        'MuserModel.UserId = index
        'id.Text = index

        Dim delflg As String
        If delflag.Checked = True Then
            delflg = 1
        Else
            delflg = 0
        End If

        Dim adminflag As String
        If admindelflg.Checked = True Then
            adminflag = 1
        Else
            adminflag = 0
        End If

        Dim genderid As Integer

        If radionGender.SelectedValue = "1" Then
            genderid = True
        Else
            genderid = False

        End If






        'If radionGender.SelectedItem.Value = "Male" Then

        '    genderid = radionGender.SelectedItem.Value
        'Else
        '    genderid = radionGender.SelectedItem.Value
        'End If



        Dim MuserModel As MUserModel = New MUserModel()
        Dim MUserControl As MUserControl = New MUserControl()

        MuserModel.UPDCD = Session("user_id").ToString
        'MuserModel.CRTCD = Session("user_id").ToString
        'MuserModel.UPDPG = "Class_Store.vb"
        MuserModel.DELFG = delflg


        MuserModel.UserId = id.Text
        MuserModel.UserId = txtUserId.Text

        'If txtUserId.Text = DataTable

        MuserModel.Password = txtPassword.Text
        MuserModel.eng_id = txtEnggId.Text
        MuserModel.admin_flg = adminflag
        MuserModel.user_level = txtUserlvl.Text

        'For i As Integer = 0 To listShipBranch.Items.Count - 1

        '    If listShipBranch.Items(i).Selected Then
        '        getvalue = getvalue + listShipBranch.Items(i).Value & ","

        '    End If
        'Next

        Dim get_value As String = ""

        For i As Integer = 0 To listShipBranch.Items.Count - 1
            If listShipBranch.Items(i).Selected Then
                If listShipBranch.Items.Count > 0 Then

                    get_value = get_value + listShipBranch.Items(i).Text & ","
                End If
            End If

        Next
        For Each item As ListItem In listShipBranch.Items
            If item.Selected Then
                'messagetxt += "'" + item.Text + "',"
                'messageValue += "'" + CInt(item.Value).ToString() + "',"
                get_value = get_value.ToString() + ","
            End If
        Next

        'Dim shipcode As String = listShipBranch.SelectedValue
        'Dim elements As String = shipcode.Join(",", shipcode)
        'For Each element As String In elements
        '    listShipBranch.Items.Add(New ListItem(element, ""))
        '    MuserModel.ship_1 = element
        'Next




        MuserModel.ship_1 = get_value
        MuserModel.ship_2 = txtBranchCode2.Text
        MuserModel.ship_3 = txtBranchCode3.Text
        MuserModel.ship_4 = txtBranchCode4.Text

        MuserModel.ship_5 = txtBranchCode5.Text

        MuserModel.Surname = txtSurname.Text
        MuserModel.Name = txtName.Text
        MuserModel.Middle_Name = txtMiddleName.Text
        MuserModel.Birth_Day = txtdob.Text
        MuserModel.Sex = genderid
        MuserModel.Superior = txtSuperior.Text

        MuserModel.Address_Line_1 = txtAddressLine1.Text
        MuserModel.Address_Line_2 = txtAddressLine2.Text
        MuserModel.Address_Line_3 = txtAddressLine3.Text
        MuserModel.Zip_Code = txtZipCode.Text
        MuserModel.Telephone_1 = txtTelephone.Text

        MuserModel.Mobile = txtMobile.Text
        MuserModel.Email_ID = txtEmailId.Text
        MuserModel.Telephone_2 = txtTelephone1.Text

        'MuserModel.UserId = Session("user_id").ToString

        'Dim isUpdated As Boolean = MUserControl.UpdateMUser(MuserModel)

        'Dim MUserDataInserted As Boolean

        ''If (isUpdated = True) Then
        'Dim MUserDataInserted As Boolean = MUserControl.UpdateDataMUser(MuserModel)

        '    If (MUserDataInserted = True) Then
        '        Call showMsg("Update Successfully", "")

        '        txtUserId.Text = ""
        '        delflag.Checked = False
        '        admindelflg.Checked = False
        '        radionGender.Items.Clear()
        '        txtBranchCode2.Text = ""
        '        txtSuperior.Text = ""
        '        txtZipCode.Text = ""
        '        txtMobile.Text = ""
        '        listShipBranch.Items.Clear()
        '        txtEmailId.Text = ""
        '        txtTelephone1.Text = ""
        '        txtAddressLine1.Text = ""
        '        txtAddressLine2.Text = ""
        '        txtTelephone.Text = ""
        '        txtAddressLine3.Text = ""
        '        txtdob.Text = ""
        '        txtBranchCode3.Text = ""
        '        txtBranchCode4.Text = ""
        '        txtMiddleName.Text = ""
        '        txtName.Text = ""
        '        txtBranchCode1.Text = ""
        '        txtUserlvl.Text = ""
        '        txtSurname.Text = ""
        '        txtPassword.Text = ""
        '        txtBranchCode5.Text = ""
        '        txtUserId.Text = ""
        '        txtEnggId.Text = ""


        '    Else
        '        Call showMsg("Update Failed", "")
        '        GridSetupUser.Visible = False
        '        btnAdd.Visible = False
        '        AddUser.Visible = True
        '        Exit Sub
        '    End If




        'End If
        GridSetupUser.Visible = True

        AddUser.Visible = False
        btnAdd.Visible = True
        Header.Text = "User Management"
        'Response.Redirect("")
        ShowGrid()
    End Sub

    'Protected Sub btnEdit_Click1(sender As Object, e As EventArgs)
    '    Dim MuserUserid1 As String = Convert.ToString(Request.QueryString("User_id"))
    '    Dim MUsermodel As New MUserModel
    '    Dim MUsercontrol As New MUserControl
    '    MUsermodel.UserId = MuserUserid1
    '    'id.Text = MuserUserid1


    '    Dim _Datatble As DataTable = MUsercontrol.GetUserInfo(MUsermodel)
    '    'If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
    '    '    delflag.Text = _Datatble.Rows(0)("DELFG")
    '    'End If
    '    If Not IsDBNull(_Datatble.Rows(0)("user_id")) Then
    '        txtUserId.Text = _Datatble.Rows(0)("user_id")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("password")) Then
    '        txtPassword.Text = _Datatble.Rows(0)("password")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("eng_id")) Then
    '        txtEnggId.Text = _Datatble.Rows(0)("eng_id")
    '    End If


    '    If Not IsDBNull(_Datatble.Rows(0)("user_level")) Then
    '        txtUserlvl.Text = _Datatble.Rows(0)("user_level")
    '    End If

    '    If Not IsDBNull(_Datatble.Rows(0)("ship_1")) Then
    '        txtBranchCode1.Text = _Datatble.Rows(0)("ship_1")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("ship_2")) Then
    '        txtBranchCode2.Text = _Datatble.Rows(0)("ship_2")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("ship_3")) Then
    '        txtBranchCode3.Text = _Datatble.Rows(0)("ship_3")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("ship_4")) Then
    '        txtBranchCode4.Text = _Datatble.Rows(0)("ship_4")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("ship_5")) Then
    '        txtBranchCode5.Text = _Datatble.Rows(0)("ship_5")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("surname")) Then
    '        txtSurname.Text = _Datatble.Rows(0)("surname")
    '    End If

    '    If Not IsDBNull(_Datatble.Rows(0)("name")) Then
    '        txtName.Text = _Datatble.Rows(0)("name")
    '    End If

    '    If Not IsDBNull(_Datatble.Rows(0)("mid_name")) Then
    '        txtMiddleName.Text = _Datatble.Rows(0)("mid_name")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("birthday")) Then
    '        txtdob.Text = _Datatble.Rows(0)("birthday")
    '    End If


    '    If Not IsDBNull(_Datatble.Rows(0)("sex")) Then
    '        If _Datatble.Rows(0)("sex") = 0 Then
    '            radionGender.SelectedValue = "0"
    '        Else
    '            radionGender.SelectedValue = "1"
    '        End If
    '    End If

    '    If Not IsDBNull(_Datatble.Rows(0)("superior")) Then
    '        txtSuperior.Text = _Datatble.Rows(0)("superior")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("add_1")) Then
    '        txtAddressLine1.Text = _Datatble.Rows(0)("add_1")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("add_2")) Then
    '        txtAddressLine2.Text = _Datatble.Rows(0)("add_2")
    '    End If

    '    If Not IsDBNull(_Datatble.Rows(0)("add_3")) Then
    '        txtAddressLine3.Text = _Datatble.Rows(0)("add_3")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("zip")) Then
    '        txtZipCode.Text = _Datatble.Rows(0)("zip")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("tel")) Then
    '        txtTelephone.Text = _Datatble.Rows(0)("tel")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("mobile")) Then
    '        txtMobile.Text = _Datatble.Rows(0)("mobile")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("e_mail")) Then
    '        txtEmailId.Text = _Datatble.Rows(0)("e_mail")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("em_tel")) Then
    '        txtTelephone1.Text = _Datatble.Rows(0)("em_tel")
    '    End If


    '    If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
    '        If _Datatble.Rows(0)("DELFG") = 0 Then
    '            delflag.Checked = False
    '        Else
    '            delflag.Checked = True
    '        End If
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("admin_flg")) Then
    '        If _Datatble.Rows(0)("admin_flg") = 0 Then
    '            admindelflg.Checked = False
    '        Else
    '            admindelflg.Checked = True
    '        End If
    '    End If

    '    'btnUpload.Visible = False
    '    btnEdit.Visible = True
    '    'filename.Visible = False
    '    'Textfilename.Visible = True
    '    btnAdd.Visible = False
    '    GridSetupUser.Visible = False
    '    AddUser.Visible = True

    '    Header.Text = "User Management-Edit"
    'End Sub

    Protected Sub btnback_Click(sender As Object, e As EventArgs)
        GridSetupUser.Visible = True
        AddUser.Visible = False
        btnAdd.Visible = True
        listShipBranch.Items.Clear()
        Header.Text = "User Management"
        'Response.Redirect("")
        ShowGrid()
    End Sub



    'Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

    'End Sub

    'Protected Sub user_id_Click(sender As Object, e As EventArgs)
    '    Dim index As String = Convert.ToString(e.CommandArgument)


    '    Dim Rpamanagementmodel As New RpamanagementModel
    '    Dim Rpamanagementcontrol As New RpamanagementControl
    '    Rpamanagementmodel.TASKID = index
    '    id.Text = index
    '    Dim _Datatble As DataTable = Rpamanagementcontrol.Get_UserInfo(Rpamanagementmodel)
    '    If Not IsDBNull(_Datatble.Rows(0)("TASK_NAME")) Then
    '        TaskName.Text = _Datatble.Rows(0)("TASK_NAME")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("FILE_NAME")) Then
    '        Textfilename.Text = _Datatble.Rows(0)("FILE_NAME")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("TEST_STATUS")) Then
    '        Testeddate.Text = _Datatble.Rows(0)("TEST_STATUS")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("STATUS")) Then
    '        Status.Text = _Datatble.Rows(0)("STATUS")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("RUN_DURATION")) Then
    '        Duration.Text = _Datatble.Rows(0)("RUN_DURATION")
    '    End If
    '    If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
    '        If _Datatble.Rows(0)("DELFG") = 0 Then
    '            delfld.Checked = False
    '        Else
    '            delfld.Checked = True
    '        End If
    '    End If
    '    btnUpload.Visible = False
    '    Edit.Visible = True
    '    filename.Visible = False
    '    Textfilename.Visible = True
    '    Data.Visible = False
    '    addfile.Visible = True

    '    Header.Text = "User Management-Edit"
    'End Sub
End Class