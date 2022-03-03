Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Public Class SetupNewServiceCenter
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
        Header.Text = "Service Center"
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
        Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        'SetupNewServiceCenterModel.SHIP_NAME_1 = txtSearch.Text
        Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        Dim _dataview As New DataView(_Datatble)
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

    Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        data.Visible = False
        addfile.Visible = True
        btnAddNew.Visible = True
        Edit.Visible = False
        del.Visible = False
        ShipCode1.Visible = True
        lblshipcode.Visible = True


        Header.Text = "Create New- Service Center"
        '' Exit Sub
        'Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        'Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        'SetupNewServiceCenterModel.SHIP_NAME = ShipName.Text
        'SetupNewServiceCenterModel.SHIP_INFO = ShipInfo.Text
        'SetupNewServiceCenterModel.SHIP_MANAGER = ShipManager.Text
        'SetupNewServiceCenterModel.SHIP_TEL = ShipTel.Text
        'SetupNewServiceCenterModel.SHIP_ADD1 = ShipAdd1.Text
        'SetupNewServiceCenterModel.SHIP_ADD2 = ShipAdd2.Text
        'SetupNewServiceCenterModel.SHIP_ADD3 = ShipAdd3.Text
        'SetupNewServiceCenterModel.ZIP = Zip.Text
        'SetupNewServiceCenterModel.E_MAIL = Email.Text
        'SetupNewServiceCenterModel.SHIP_SERVICE = ShipService.Text
        'SetupNewServiceCenterModel.OPEN_TIME = OpenTime.Text
        'SetupNewServiceCenterModel.CLOSE_TIME = CloseTime.Text
        'SetupNewServiceCenterModel.OPENING_DATE = OpeningDate.Text
        'SetupNewServiceCenterModel.CLOSING_DATE = ClosingDate.Text
        'SetupNewServiceCenterModel.SHIP_CODE = ShipCode.Text
        'SetupNewServiceCenterModel.SHIP_MARK = ShipMark.Text
        'SetupNewServiceCenterModel.ITEM_1 = Item1.Text
        'SetupNewServiceCenterModel.ITEM_2 = Item2.Text
        'SetupNewServiceCenterModel.MESS_1 = Mess1.Text
        'SetupNewServiceCenterModel.MESS_2 = Mess2.Text
        'SetupNewServiceCenterModel.MESS_3 = Mess3.Text
        'SetupNewServiceCenterModel.REGI_DEPOSIT = RegiDeposit.Text
        'SetupNewServiceCenterModel.PO_NO = PO_NO.Text
        '' Dim delflg As String
        'If delfld.Checked = True Then
        '    SetupNewServiceCenterModel.DELFG = 1
        'Else
        '    SetupNewServiceCenterModel.DELFG = 0
        'End If
        ''SetupNewServiceCenterModel.DELFG = delfld.Text

        ''  Rpamanagementmodel.   = Session("ship_Name")
        'SetupNewServiceCenterModel.CRTCD = Session("user_Name")
        ''Rpamanagementmodel.= Session("user_level")
        ''Rpamanagementmodel.= Session("admin_Flg")
        'Dim insertCredit As Boolean = SetupNewServiceCentercontrol.SetupNewServiceCenterInsert(SetupNewServiceCenterModel)
        'If (insertCredit = True) Then
        '    Call showMsg("Success updated", "")
        '    'Exit Sub
        'Else
        '    Call showMsg("updated failed", "")
        'End If
        'data.Visible = True
        ''addfile.Visible = False
        ''pageload()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'data.Visible = True
        'addfile.Visible = False
        Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        SetupNewServiceCenterModel.SHIP_NAME = ShipName.Text
        SetupNewServiceCenterModel.SHIP_INFO = ShipInfo.Text
        SetupNewServiceCenterModel.SHIP_MANAGER = ShipManager.Text
        SetupNewServiceCenterModel.SHIP_TEL = ShipTel.Text
        SetupNewServiceCenterModel.SHIP_ADD1 = ShipAdd1.Text
        SetupNewServiceCenterModel.SHIP_ADD2 = ShipAdd2.Text
        SetupNewServiceCenterModel.SHIP_ADD3 = ShipAdd3.Text
        SetupNewServiceCenterModel.ZIP = Zip.Text
        SetupNewServiceCenterModel.E_MAIL = Email.Text
        SetupNewServiceCenterModel.SHIP_SERVICE = ShipService.Text
        Dim starttime = OpenTime.Text
        Dim optime = starttime.Substring(0, 5)
        SetupNewServiceCenterModel.OPEN_TIME = optime
        If CloseTime.Text = "" Then

            SetupNewServiceCenterModel.CLOSE_TIME = CloseTime.Text
        Else
            Dim endtime = CloseTime.Text
            Dim cltime = endtime.Substring(0, 5)
            SetupNewServiceCenterModel.CLOSE_TIME = cltime
        End If

        SetupNewServiceCenterModel.OPENING_DATE = OpeningDate.Text
        SetupNewServiceCenterModel.CLOSING_DATE = ClosingDate.Text
        SetupNewServiceCenterModel.SHIP_CODE = ShipCode1.Text
        SetupNewServiceCenterModel.SHIP_MARK = ShipMark.Text
        SetupNewServiceCenterModel.ITEM_1 = Item1.Text
        SetupNewServiceCenterModel.ITEM_2 = Item2.Text
        SetupNewServiceCenterModel.MESS_1 = Mess1.Text
        SetupNewServiceCenterModel.MESS_2 = Mess2.Text
        SetupNewServiceCenterModel.MESS_3 = Mess3.Text
        SetupNewServiceCenterModel.REGI_DEPOSIT = RegiDeposit.Text
        SetupNewServiceCenterModel.PO_NO = PO_NO.Text
        ' Dim delflg As String
        If delfld.Checked = True Then
            SetupNewServiceCenterModel.DELFG = 1
        Else
            SetupNewServiceCenterModel.DELFG = 0
        End If
        'SetupNewServiceCenterModel.DELFG = delfld.Text

        '  Rpamanagementmodel.   = Session("ship_Name")
        SetupNewServiceCenterModel.CRTCD = Session("user_Name")
        SetupNewServiceCenterModel.UPDCD = Session("user_Name")
        SetupNewServiceCenterModel.UPDPG = "Test"
        Dim dt As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        If dt.Rows.Count <> 0 Then
            Call showMsg("Ship code already exists ", "")
            addfile.Visible = True
            data.Visible = False
            Header.Text = "Create New - Service Center"
            Exit Sub
        End If
        'Rpamanagementmodel.= Session("user_level")
        'Rpamanagementmodel.= Session("admin_Flg")
        Dim insertCredit As Boolean = SetupNewServiceCentercontrol.SetupNewServiceCenterInsert(SetupNewServiceCenterModel)
        'Dim insertCredit As Boolean = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        If (insertCredit = True) Then
            Call showMsg(" Service center successfully created", "")
            clearvalue()

            'Exit Sub
        Else
            Call showMsg("updated failed", "")
            data.Visible = False
            addfile.Visible = True
            Exit Sub
        End If
        data.Visible = True
        addfile.Visible = False
        pageload()
    End Sub



    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        data.Visible = True
        addfile.Visible = False
        clearvalue()
        Header.Text = "Service Center"
    End Sub

    Protected Sub Edit_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        ' Dim row As GridViewRow = CType((TryCast(sender, Button)).NamingContainer, GridViewRow)
        ' Dim id = getdata.DataKeys(row.RowIndex).Values(0).ToString()
        ' Dim updateCredit As Boolean = SetupNewServiceCentercontrol.UpdateSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        ' getdata.EditIndex = e.neweditindex

        'Dim id2 = row.Cells(1).Text
        SetupNewServiceCenterModel.SHIP_NAME = ShipName.Text
        SetupNewServiceCenterModel.SHIP_INFO = ShipInfo.Text
        SetupNewServiceCenterModel.SHIP_MANAGER = ShipManager.Text
        SetupNewServiceCenterModel.SHIP_TEL = ShipTel.Text
        SetupNewServiceCenterModel.SHIP_ADD1 = ShipAdd1.Text
        SetupNewServiceCenterModel.SHIP_ADD2 = ShipAdd2.Text
        SetupNewServiceCenterModel.SHIP_ADD3 = ShipAdd3.Text
        SetupNewServiceCenterModel.ZIP = Zip.Text
        SetupNewServiceCenterModel.E_MAIL = Email.Text
        SetupNewServiceCenterModel.SHIP_SERVICE = ShipService.Text
        Dim starttime = OpenTime.Text
        Dim optime = starttime.Substring(0, 5)
        SetupNewServiceCenterModel.OPEN_TIME = optime
        If CloseTime.Text = "" Then

            SetupNewServiceCenterModel.CLOSE_TIME = CloseTime.Text
        Else
            Dim endtime = CloseTime.Text
            Dim cltime = endtime.Substring(0, 5)
            SetupNewServiceCenterModel.CLOSE_TIME = cltime
        End If

        SetupNewServiceCenterModel.OPENING_DATE = OpeningDate.Text
        SetupNewServiceCenterModel.CLOSING_DATE = ClosingDate.Text
        SetupNewServiceCenterModel.SHIP_CODE = ShipCode1.Text
        SetupNewServiceCenterModel.SHIP_MARK = ShipMark.Text
        SetupNewServiceCenterModel.ITEM_1 = Item1.Text
        SetupNewServiceCenterModel.ITEM_2 = Item2.Text
        SetupNewServiceCenterModel.MESS_1 = Mess1.Text
        SetupNewServiceCenterModel.MESS_2 = Mess2.Text
        SetupNewServiceCenterModel.MESS_3 = Mess3.Text
        SetupNewServiceCenterModel.REGI_DEPOSIT = RegiDeposit.Text
        SetupNewServiceCenterModel.PO_NO = PO_NO.Text
        ' Dim delflg As String
        If delfld.Checked = True Then
            SetupNewServiceCenterModel.DELFG = 1
        Else
            SetupNewServiceCenterModel.DELFG = 0
        End If

        SetupNewServiceCenterModel.CRTCD = Session("user_Name")
        SetupNewServiceCenterModel.UPDCD = Session("user_Name")
        SetupNewServiceCenterModel.UPDPG = "Test"

        Dim updated As Boolean = SetupNewServiceCentercontrol.UpdateSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        If (updated = True) Then
            Call showMsg(" Service center successfully Updated", "")
            clearvalue()
        Else
            Call showMsg("updated failed", "")
            data.Visible = False
            addfile.Visible = True
            Exit Sub
        End If

        data.Visible = True
        addfile.Visible = False
        pageload()
    End Sub

    Protected Sub getdata_RowCommand1(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "goto" Then
            Dim index As String = Convert.ToString(e.CommandArgument)


            Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
            Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
            SetupNewServiceCenterModel.SHIP_CODE = index
            ShipCode1.Text = index
            Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Name")) Then
                ShipName.Text = _Datatble.Rows(0)("Ship_Name")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Info")) Then
                ShipInfo.Text = _Datatble.Rows(0)("Ship_Info")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Manager")) Then
                ShipManager.Text = _Datatble.Rows(0)("Ship_Manager")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Tel")) Then
                ShipTel.Text = _Datatble.Rows(0)("Ship_Tel")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Add1")) Then
                ShipAdd1.Text = _Datatble.Rows(0)("Ship_Add1")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Add2")) Then
                ShipAdd2.Text = _Datatble.Rows(0)("Ship_Add2")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Add3")) Then
                ShipAdd3.Text = _Datatble.Rows(0)("Ship_Add3")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Zip")) Then
                Zip.Text = _Datatble.Rows(0)("Zip")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("e_mail")) Then
                Email.Text = _Datatble.Rows(0)("e_mail")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Service")) Then
                ShipService.Text = _Datatble.Rows(0)("Ship_Service")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("open_time")) Then
                OpenTime.Text = _Datatble.Rows(0)("open_time")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("close_time")) Then
                CloseTime.Text = _Datatble.Rows(0)("close_time")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("opening_date")) Then
                OpeningDate.Text = _Datatble.Rows(0)("opening_date")
                'Dim starttime = OpenTime.Text
                'Dim optime = starttime.Substring(0, 5)
                'SetupNewServiceCenterModel.OPEN_TIME = optime
                'Dim endtime = OpenTime.Text
                'Dim cltime = endtime.Substring(0, 5)
                'SetupNewServiceCenterModel.CLOSE_TIME = cltime

            End If
            If Not IsDBNull(_Datatble.Rows(0)("closing_date")) Then
                ClosingDate.Text = _Datatble.Rows(0)("closing_date")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("ship_code")) Then
                ShipCode1.Text = _Datatble.Rows(0)("ship_code")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Ship_Mark")) Then
                ShipMark.Text = _Datatble.Rows(0)("Ship_Mark")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Item_1")) Then
                Item1.Text = _Datatble.Rows(0)("Item_1")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("Item_2")) Then
                Item2.Text = _Datatble.Rows(0)("Item_2")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("mess_1")) Then
                Mess1.Text = _Datatble.Rows(0)("mess_1")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("mess_2")) Then
                Mess2.Text = _Datatble.Rows(0)("mess_2")
            End If
            If Not IsDBNull(_Datatble.Rows(0)("mess_3")) Then
                Mess3.Text = _Datatble.Rows(0)("mess_3")
            End If

            If Not IsDBNull(_Datatble.Rows(0)("Regi_Deposit")) Then
                RegiDeposit.Text = _Datatble.Rows(0)("Regi_Deposit")
            End If

            If Not IsDBNull(_Datatble.Rows(0)("PO_no")) Then
                PO_NO.Text = _Datatble.Rows(0)("PO_no")
            End If

            If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
                    If _Datatble.Rows(0)("DELFG") = 0 Then
                        delfld.Checked = False
                    Else
                        delfld.Checked = True
                    End If
                End If
            ShipCode1.Visible = False
            lblshipcode.Visible = False
                btnAddNew.Visible = False
                Edit.Visible = True
                'filename.Visible = False
                'Textfilename.Visible = True
                data.Visible = False
            addfile.Visible = True
            del.Visible = True

            Header.Text = "Edit - Service Center"
        End If

    End Sub

    Protected Sub getdata_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        getdata.PageIndex = e.NewPageIndex
        pageload()
    End Sub

    ' Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs)
    '' GridView1.EditIndex = e.NewEditIndex
    ''Me.BindGrid()
    ' Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
    ' Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
    'Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
    'Dim _dataview As New DataView(_Datatble)
    ' getdata.DataSource = _dataview
    ' getdata.DataBind()
    'End Sub

    Public Sub clearvalue()
        ShipName.Text = ""
        ShipInfo.Text = ""
        ShipManager.Text = ""
        ShipTel.Text = ""
        ShipAdd1.Text = ""
        ShipAdd2.Text = ""
        ShipAdd3.Text = ""
        Zip.Text = ""
        Email.Text = ""
        ShipService.Text = ""
        OpenTime.Text = ""
        CloseTime.Text = ""
        OpeningDate.Text = ""
        ClosingDate.Text = ""
        ShipCode1.Text = ""
        ShipMark.Text = ""
        Item1.Text = ""
        Item2.Text = ""
        Mess1.Text = ""
        Mess2.Text = ""
        Mess3.Text = ""
        RegiDeposit.Text = ""
        PO_NO.Text = ""
        delfld.Checked = False
    End Sub

    Protected Sub getdata_Sorting(sender As Object, e As GridViewSortEventArgs)
        Me.pageload(e.SortExpression)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Me.pageload()
    End Sub

    'Private Sub Search_Click(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing) Handles Search.Click

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

    Protected Sub Search_Click1(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing)
        Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        SetupNewServiceCenterModel.SHIP_NAME_1 = txtSearch.Text
        Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        Dim _dataview As New DataView(_Datatble)
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
        pageload()
    End Sub
End Class