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


            'Dim comctrl As CommonControl = New CommonControl()
            '''''''''***拠点名称の設定***

            'Dim ssclist As List(Of CodeMasterModel) = New List(Of CodeMasterModel)
            'ssclist = comctrl.InitDropDownList(userName, userid)
            'ssclist.RemoveAt(0)
            'listShipBranch.DataSource = ssclist
            'listShipBranch.DataTextField = "CodeDispValue"
            'listShipBranch.DataValueField = "CodeValue"
            'listShipBranch.DataBind()
            'Dim locationSelect As Boolean = False

            'If System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("ImpStroreDtl") Then
            '    ' Do Something
            '    Dim SSCDtlAll As String = ConfigurationManager.AppSettings("ImpStroreDtl")

            '    Dim SSCDtlInd As String() = SSCDtlAll.Split(New Char() {","c})

            '    ' Use For Each loop over words and display them

            '    Dim SSC As String
            '    For Each SSC In SSCDtlInd
            '        For Each item As ListItem In listShipBranch.Items
            '            If item.Text.ToUpper() = SSC.ToUpper() Then
            '                item.Selected = True
            '                locationSelect = True
            '            End If
            '        Next
            '    Next
            'End If
        End If

    End Sub



    Protected Sub GridSetupUser_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridSetupUser.PageIndex = e.NewPageIndex
        ShowGrid()
    End Sub

    Private Sub ShowGrid(Optional ByVal sortExpression As String = Nothing)
        Dim MUserModel As New MUserModel
        Dim _MUserControl As MUserControl = New MUserControl()
        'MUserModel.User_id = txtSearch.Text
        Dim dt As DataTable = _MUserControl.ShowMUserGrid(MUserModel)

        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = dt.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection
            GridSetupUser.DataSource = dv
        Else
            GridSetupUser.DataSource = dt
        End If

        GridSetupUser.DataBind()
    End Sub

    Private Sub InitDropDownList1()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropDownList1.Items.Clear()
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

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        'Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        'codeMaster1.CodeValue = "Select Branch"
        'codeMaster1.CodeDispValue = "Select Branch"
        'codeMasterList.Insert(0, codeMaster1)

        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        codeMaster2.CodeValue = "All"
        codeMaster2.CodeDispValue = "All"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropDownList1.DataSource = codeMasterList
        Me.DropDownList1.DataTextField = "CodeDispValue"
        Me.DropDownList1.DataValueField = "CodeValue"
        Me.DropDownList1.DataBind()
        Me.DropDownList1.Items.Remove("All")
    End Sub


    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        InitDropDownList1()
        search.Visible = False
        AddUser.Visible = True
        btnCreate.Visible = True
        btnAdd.Visible = False
        lblUsername.Visible = True
        txtUserId.Visible = True
        txtUserId.ReadOnly = False
        listShipBranch.Visible = False
        'txtBranchCode1.Visible = True
        DropDownList1.Visible = True
        Edit.Visible = False
        txtUserId.Text = ""
        delflag.Checked = False
        admindelflg.Checked = False
        radionGender.Visible = True
        del.Visible = False
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
        'txtBranchCode1.Text = ""
        txtUserlvl.SelectedValue = "-1"
        txtSurname.Text = ""
        txtPassword.Text = ""
        txtBranchCode5.Text = ""
        txtUserId.Text = ""
        txtEnggId.Text = ""
        Header.Text = "Create New - User Management"
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
        Try
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
            MuserModel.user_level = txtUserlvl.SelectedValue
            MuserModel.ship_1 = DropDownList1.SelectedValue
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

            MuserModel.em_surname = "GSS"
            MuserModel.gua_name = "aoshima"
            MuserModel.gua_tel = "300"
            MuserModel.gua_add1 = "nishigotanda"
            MuserModel.Class1 = "1"
            MuserModel.position = "5"
            MuserModel.work_location = "1"
            MuserModel.paid_h1 = "10"
            MuserModel.reg_work_time = "8"
            'MuserModel.UserId = Session("user_id").ToString

            Dim dt As DataTable = MUserControl.ShowMUserGrid(MuserModel)

            If dt.Rows.Count <> 0 Then
                Call showMsg("User name already exists", "")
                search.Visible = False
                btnAdd.Visible = False
                AddUser.Visible = True
                Exit Sub
            End If


            Dim isInserted As Boolean = MUserControl.MUserInsert(MuserModel)

            'Dim MUserDataInserted As Boolean

            If (isInserted = True) Then

                Dim MUserDataInserted As Boolean = MUserControl.MUserDataInsert(MuserModel)

                If (MUserDataInserted = True) Then
                    Call showMsg("User created  Successfully", "")

                    txtUserId.Text = ""
                    delflag.Checked = False
                    admindelflg.Checked = False
                    radionGender.ClearSelection()
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
                    ' txtBranchCode1.Text = ""
                    txtUserlvl.SelectedValue = -1
                    txtSurname.Text = ""
                    txtPassword.Text = ""
                    txtBranchCode5.Text = ""
                    txtUserId.Text = ""
                    txtEnggId.Text = ""

                    ShowGrid()

                Else
                    Call showMsg("User Created Failed", "")
                    search.Visible = False
                    btnAdd.Visible = False
                    AddUser.Visible = True
                    Exit Sub
                End If

            Else
                Call showMsg("User Created Failed", "")
                search.Visible = False
                btnAdd.Visible = False
                AddUser.Visible = True
                Exit Sub

            End If
            search.Visible = True
            AddUser.Visible = False
            btnAdd.Visible = True
            Header.Text = "User Management"
            'Response.Redirect("")
            ShowGrid()

        Catch ex As Exception
            lblMsg.Text = ex.Message

            'ClientScript.RegisterStartupScript(Me.GetType(), "startup", msg, True)
            Exit Sub
        End Try
    End Sub

    Protected Sub GridSetupUser_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            If e.CommandName = "goto" Then
                Dim userName As String = Session("user_Name")
                Dim userid As String = Session("user_id")
                Dim index As String = Convert.ToString(e.CommandArgument)

                Dim comctrl As CommonControl = New CommonControl()
                ''''''''***拠点名称の設定***

                Dim ssclist As List(Of CodeMasterModel) = New List(Of CodeMasterModel)
                ssclist = comctrl.InitDropDownList(userName, userid)
                ssclist.RemoveAt(0)
                listShipBranch.DataSource = ssclist
                listShipBranch.DataTextField = "CodeDispValue"
                listShipBranch.DataValueField = "CodeValue"
                listShipBranch.DataBind()
                Dim locationSelect As Boolean = False

                'Dim SSCDtlInd1 As String()
                'If System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("ImpStroreDtl") Then
                '    ' Do Something
                '    Dim SSCDtlAll As String = ConfigurationManager.AppSettings("ImpStroreDtl")

                '    SSCDtlInd1 = SSCDtlAll.Split(New Char() {","c})

                '    ' Use For Each loop over words and display them


                '    'For Each SSC In SSCDtlInd1
                '    '    For Each item As ListItem In listShipBranch.Items
                '    '        If item.Value. =  Then
                '    '            item.Selected = True
                '    '            locationSelect = True
                '    '        End If
                '    '    Next
                '    'Next

                'End If


                Dim MuserModel As MUserModel = New MUserModel()
                Dim MUserControl As MUserControl = New MUserControl()
                MuserModel.UserId = index
                id.Text = index


                Dim _Datatble As DataTable = MUserControl.GetUserInfo(MuserModel)
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
                    txtUserlvl.SelectedValue = _Datatble.Rows(0)("user_level")
                End If



                'Dim shipCode As List(Of MUserModel) = New List(Of MUserModel)
                ''ssclist = comctrl.InitDropDownList(userName, userid)
                ''ssclist.RemoveAt(0)
                'listShipBranch.DataSource = shipBranch
                'listShipBranch.DataBind()

                ' Dim code As Int16 = 0
                ' Dim SSCDtlInd As String() = SSCDtlAll.Split(New Char() {","c})
                'Dim SSC As String
                'For Each SSC In SSCDtlInd
                '    For Each item As ListItem In lstLocation.Items
                '        If item.Text.ToUpper() = SSC.ToUpper() Then
                '            item.Selected = True
                '            sslSelect = True
                '        End If
                '    Next
                'Next

                '    If Not IsDBNull(_Datatble.Rows(0)("ship_1")) Then
                '    shipBranch = _Datatble.Rows(0)("ship_1")
                '    listShipBranch.DataSource = shipBranch
                '    listShipBranch.DataBind()
                '    Dim elements As String() = shipBranch.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                '    Dim location As String
                '    For Each location In elements
                '        For Each item As ListItem In listShipBranch.Items
                '            If item.Selected = True Then
                '                item.Selected = True
                '                locationSelect = True
                '            End If

                '        Next

                '        'listShipBranch.Items.Add(New ListItem(element, ""))
                '    Next
                'End If
                Dim shipBranch As String
                If Not IsDBNull(_Datatble.Rows(0)("ship_1")) Then
                    shipBranch = _Datatble.Rows(0)("ship_1")
                    Dim elements() As String = shipBranch.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                    'For Each ssc In SSCDtlInd1
                    For Each item As ListItem In listShipBranch.Items
                        For Each element As String In elements
                            If item.Value = element Then
                                item.Selected = True
                                locationSelect = True

                            End If

                            'Exit For Each
                            ' listShipBranch.Items.Add(New ListItem(element, ""))
                        Next
                    Next
                    'Next
                End If
                'Dim SSC As String
                'For Each SSC In SSCDtlInd1
                '    For Each item As ListItem In listShipBranch.Items
                '        For Each list In ()

                '            If item.Value =  Then
                '                item.Selected = True
                '                locationSelect = True
                '            End If
                '        Next
                '    Next
                'Next


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
                'txtBranchCode1.Visible = False
                DropDownList1.Visible = False
                'txtUserId.Visible = False
                'lblUsername.Visible = False
                txtUserId.ReadOnly = True
                'filename.Visible = False
                'Textfilename.Visible = True
                btnAdd.Visible = False
                listShipBranch.Visible = True
                search.Visible = False
                AddUser.Visible = True
                btnCreate.Visible = False
                del.Visible = True
                Header.Text = "Edit - User Management"
                'Dim cstype As Type = Me.GetType()
                'Dim str2 As String = "window.open('Analysis_Servicecenter.aspx?UserId=" & index & "','myWindow','width=800,height=500,left=100,top=100,resizable=yes')"
                ''Client.RegisterStartupScript(This.GetType(), "script", str2, True)
                'ClientScript.RegisterStartupScript(cstype, "script", str2, True)

            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message

            'ClientScript.RegisterStartupScript(Me.GetType(), "startup", msg, True)
            Exit Sub
        End Try

    End Sub

    Protected Sub Edit_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Try
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
            MuserModel.user_level = txtUserlvl.SelectedValue

            'For i As Integer = 0 To listShipBranch.Items.Count - 1

            '    If listShipBranch.Items(i).Selected Then
            '        getvalue = getvalue + listShipBranch.Items(i).Value & ","

            '    End If
            'Next
            Dim get_value As String = ""

            For i As Integer = 0 To listShipBranch.Items.Count - 1

                If listShipBranch.Items(i).Selected Then
                    get_value = get_value + listShipBranch.Items(i).Value & ","

                End If

            Next
            get_value = Left(get_value, Len(get_value) - 1)
            ' get_value.TrimEnd(",")
            'For Each item As ListBox In listShipBranch.Items
            '    If item.SelectedValue Then
            '        If selectedIndex = "" Then
            '            selectedIndex = item.
            '        Else
            '            selectedIndex = selectedIndex & ", " & item.Value
            '        End If

            '    End If
            'Next
            'Dim chkbox_selected As String

            'For i As Integer = 0 To listShipBranch.Items.Count - 1

            '    If listShipBranch.Items(i).Selected = True Then
            '        chkbox_selected += listShipBranch.Items(i).Value & ","
            '    End If
            'Next

            'chkbox_selected = chkbox_selected.Remove(chkbox_selected.Length - 1, 1)
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

            Dim isUpdated As Boolean = MUserControl.UpdateMUser(MuserModel)

            'Dim MUserDataInserted As Boolean

            If (isUpdated = True) Then
                Dim MUserDataInserted As Boolean = MUserControl.UpdateDataMUser(MuserModel)

                If (MUserDataInserted = True) Then
                    Call showMsg("User updated successfully", "")

                    txtUserId.Text = ""
                    delflag.Checked = False
                    admindelflg.Checked = False

                    txtBranchCode2.Text = ""
                    txtSuperior.Text = ""
                    txtZipCode.Text = ""
                    txtMobile.Text = ""
                    listShipBranch.Items.Clear()
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
                    'txtBranchCode1.Text = ""
                    txtUserlvl.SelectedValue = -1
                    txtSurname.Text = ""
                    txtPassword.Text = ""
                    txtBranchCode5.Text = ""
                    txtUserId.Text = ""
                    txtEnggId.Text = ""
                    radionGender.ClearSelection()

                Else
                    Call showMsg("Update Failed", "")
                    search.Visible = False
                    btnAdd.Visible = False
                    AddUser.Visible = True

                End If




            End If
            search.Visible = True

            AddUser.Visible = False
            btnAdd.Visible = True
            Header.Text = "Edit - User Management"
            'Response.Redirect("")
            ShowGrid()
        Catch ex As Exception
            lblMsg.Text = ex.Message

            'ClientScript.RegisterStartupScript(Me.GetType(), "startup", msg, True)
            Exit Sub
        End Try
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
        search.Visible = True
        AddUser.Visible = False
        btnAdd.Visible = True
        radionGender.Visible = True
        radionGender.ClearSelection()
        listShipBranch.Items.Clear()
        Header.Text = "User Management"
        'Response.Redirect("")
        ShowGrid()



    End Sub

    Protected Sub GridSetupUser_Sorting(sender As Object, e As GridViewSortEventArgs)
        Me.ShowGrid(e.SortExpression)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Me.ShowGrid()
    End Sub

    'Private Sub txtSearch1_Click(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing) Handles txtSearch1.Click

    'End Sub

    'Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click

    'End Sub

    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Protected Sub txtSearch1_Click1(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing)
        Dim MUserModel As New MUserModel
        Dim _MUserControl As MUserControl = New MUserControl()
        MUserModel.User_id = txtSearch.Text
        Dim dt As DataTable = _MUserControl.ShowMUserGrid(MUserModel)

        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = dt.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection
            GridSetupUser.DataSource = dv
        Else
            GridSetupUser.DataSource = dt
        End If

        GridSetupUser.DataBind()
    End Sub

    Protected Sub Clear_Click1(sender As Object, e As EventArgs)
        txtSearch.Text = ""
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