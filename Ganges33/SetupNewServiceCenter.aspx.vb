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
        Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        Dim _dataview As New DataView(_Datatble)
        getdata.DataSource = _dataview
        getdata.DataBind()
    End Sub

    Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        data.Visible = False
        addfile.Visible = True
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
        'SetupNewServiceCenterModel.RAGI_DEPOSIT = RagiDeposit.Text
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
        SetupNewServiceCenterModel.OPEN_TIME = OpenTime.Text
        SetupNewServiceCenterModel.CLOSE_TIME = CloseTime.Text
        SetupNewServiceCenterModel.OPENING_DATE = OpeningDate.Text
        SetupNewServiceCenterModel.CLOSING_DATE = ClosingDate.Text
        SetupNewServiceCenterModel.SHIP_CODE = ShipCode.Text
        SetupNewServiceCenterModel.SHIP_MARK = ShipMark.Text
        SetupNewServiceCenterModel.ITEM_1 = Item1.Text
        SetupNewServiceCenterModel.ITEM_2 = Item2.Text
        SetupNewServiceCenterModel.MESS_1 = Mess1.Text
        SetupNewServiceCenterModel.MESS_2 = Mess2.Text
        SetupNewServiceCenterModel.MESS_3 = Mess3.Text
        SetupNewServiceCenterModel.RAGI_DEPOSIT = RagiDeposit.Text
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
        'Rpamanagementmodel.= Session("user_level")
        'Rpamanagementmodel.= Session("admin_Flg")
        Dim insertCredit As Boolean = SetupNewServiceCentercontrol.SetupNewServiceCenterInsert(SetupNewServiceCenterModel)
        If (insertCredit = True) Then
            Call showMsg("Success updated", "")
            'Exit Sub
        Else
            Call showMsg("updated failed", "")
        End If
        data.Visible = True
        'addfile.Visible = False
        'pageload()
    End Sub



    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        data.Visible = True
        addfile.Visible = False
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        Dim row As GridViewRow = CType((TryCast(sender, Button)).NamingContainer, GridViewRow)
        Dim id = getdata.DataKeys(row.RowIndex).Values(0).ToString()
        Dim updateCredit As Boolean = SetupNewServiceCentercontrol.UpdateSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        ' getdata.EditIndex = e.neweditindex

        'Dim id2 = row.Cells(1).Text
    End Sub

    Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs)
        ' GridView1.EditIndex = e.NewEditIndex
        'Me.BindGrid()
        Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        Dim _dataview As New DataView(_Datatble)
        getdata.DataSource = _dataview
        getdata.DataBind()
    End Sub
End Class