Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Imports System
Imports System.Collections
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.Collections.Specialized

Public Class Apple_App_Inventory_Grid
    Inherits System.Web.UI.Page
    Dim clsSet As New Class_money
    Dim inv_Date As Integer = 1


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim flag As Boolean = False
        Dim userid As String = Session("user_id")
        If userid = "" Then
            Response.Redirect("Login.aspx")
        End If

        Dim setShipname As String = Session("ship_Name")
        Dim userName As String = Session("user_Name")
        Dim userLevel As String = Session("user_level")
        Dim adminFlg As Boolean = Session("admin_Flg")

        If IsPostBack = False Then
            pageload()
        End If
    End Sub

    Public Sub pageload(Optional ByVal sortExpression As String = Nothing)
        Dim _AppleAppPartsInventoryModel As New AppleAppPartsInventoryModel
        Dim AppleAppPartsInventoryControl As AppleAppPartsInventoryControl = New AppleAppPartsInventoryControl()
        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
        If inv_Date = 1 Then
            Dim dtBegin As DateTime = thisMonth.ToString("yyyy-MM-dd")

            'last day of the month
            Dim dtEnd As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
            txtdatefrom.Text = thisMonth.ToString("yyyy/MM/dd")
            txtdateto.Text = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd")

            _AppleAppPartsInventoryModel.inventry_date_from = txtdatefrom.Text
            _AppleAppPartsInventoryModel.inventry_date = txtdateto.Text
        Else
            Dim strDateFrom As String
            Dim strDateTo As String
            strDateFrom = CDate(txtdatefrom.Text).ToString("yyyy/MM/dd")
            strDateTo = CDate(txtdateto.Text).ToString("yyyy/MM/dd")
            _AppleAppPartsInventoryModel.inventry_date_from = strDateFrom

            _AppleAppPartsInventoryModel.inventry_date = strDateTo
        End If

        _AppleAppPartsInventoryModel.SHIP_TO_BRANCH_CODE = Session("ship_code")

        Dim _Datatble As DataTable = AppleAppPartsInventoryControl.GetInventry(_AppleAppPartsInventoryModel)

        'If _Datatble.Rows.Count <> 0 Then
        '    If Not IsDBNull(_Datatble.Rows(0)("PARTS_TYPE")) Then
        '        Session("PartsType") = _Datatble.Rows(0)("PARTS_TYPE")
        '    End If
        'End If

        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            gridship.DataSource = dv
            'data.Visible = True

            grid1.Visible = True
            grid2.Visible = False
            Div1.Visible = True
        Else

            gridship.DataSource = _Datatble
        End If
        gridship.DataBind()

        lblApplePartsEntry.Visible = False
        lblAppleInventry.Visible = True
        btninventryhome.Visible = False
        lblinvenrtry.Visible = False
        txtinventrtdate.Visible = False
        btnnewparts.Visible = True
        btnPartsStock.Visible = True
        btnTransView.Visible = True
        lblInfoInvNo.Visible = False
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
        'pageload()
        grid2.Visible = True
        LoadDB()
    End Sub

    Public Sub LoadDB(Optional ByVal sortExpression As String = Nothing)

        Dim _AppleAppPartsInventoryModel As New AppleAppPartsInventoryModel
        Dim AppleAppPartsInventoryControl As AppleAppPartsInventoryControl = New AppleAppPartsInventoryControl()
        _AppleAppPartsInventoryModel.inventry_no = Session("index")
        _AppleAppPartsInventoryModel.PARTS_TYPE = Session("PartsTypeView")
        Dim _Datatble As DataTable = AppleAppPartsInventoryControl.GetpartsEntry(_AppleAppPartsInventoryModel)

        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection

            getdata.DataSource = dv
        Else
            getdata.DataSource = _Datatble
        End If
        getdata.DataBind()

        grid1.Visible = False
        grid2.Visible = True
        lblApplePartsEntry.Visible = True
        lblAppleInventry.Visible = False
        btninventryhome.Visible = True
        txtinventrtdate.Visible = True
        lblinvenrtry.Visible = True
        Div1.Visible = False

    End Sub

    Protected Sub getdata_Sorting(sender As Object, e As GridViewSortEventArgs)
        Me.LoadDB(e.SortExpression)
        inv_Date = 0
    End Sub

    Protected Sub getdata_RowCommand1(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "goto" Then

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

    Protected Sub gridship_RowCommand(sender As Object, e As GridViewCommandEventArgs, Optional ByVal sortExpression As String = Nothing)

        If e.CommandName = "goto1" Then
            Dim index As String = Convert.ToString(e.CommandArgument)

            Dim rowIdx As GridViewRow = CType(CType(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
            'Dim RowIndex As Integer = row111.RowIndex
            Dim row As GridViewRow = gridship.Rows(rowIdx.RowIndex)
            Dim PartsType As String = TryCast(row.FindControl("PARTSTYPE"), Label).Text
            Session("PartsTypeView") = PartsType
            Dim _AppleAppPartsInventoryModel As New AppleAppPartsInventoryModel
            Dim AppleAppPartsInventoryControl As AppleAppPartsInventoryControl = New AppleAppPartsInventoryControl()
            _AppleAppPartsInventoryModel.inventry_no = index
            Session("index") = index
            _AppleAppPartsInventoryModel.PARTS_TYPE = PartsType

            lblInfoInvNo.Text = "Inventory No: " & Session("index")
            Dim _Datatble As DataTable = AppleAppPartsInventoryControl.GetpartsEntry(_AppleAppPartsInventoryModel)
            If _Datatble.Rows.Count <> 0 Then
                If Not IsDBNull(_Datatble.Rows(0)("INVENTORY_DATE")) Then
                    'Dim parts_no As TextBox = dt.Rows(0)("PARTS_NO")
                    txtinventrtdate.Text = _Datatble.Rows(0)("INVENTORY_DATE")
                    'box2.ReadOnly = True
                End If
            End If

            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = _Datatble.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                getdata.DataSource = dv
            Else
                getdata.DataSource = _Datatble
            End If
            getdata.DataBind()

            grid1.Visible = False
            grid2.Visible = True
            lblApplePartsEntry.Visible = True
            lblAppleInventry.Visible = False
            btninventryhome.Visible = True
            lblinvenrtry.Visible = True
            lblApplePartsEntry.Text = "APP Parts View (" & Session("index") & ")"
            txtinventrtdate.Visible = True
            Div1.Visible = False
            btnnewparts.Visible = False
            btnPartsStock.Visible = False
            btnTransView.Visible = False
            lblInfoInvNo.Visible = True
        Else
            If e.CommandName = "goto2" Then

                Dim InventoryNo As String = Convert.ToString(e.CommandArgument)
                Dim rowIdx As GridViewRow = CType(CType(e.CommandSource, LinkButton).NamingContainer, GridViewRow)
                'Dim RowIndex As Integer = row111.RowIndex
                Dim row As GridViewRow = gridship.Rows(rowIdx.RowIndex)
                Dim PartsType As String = TryCast(row.FindControl("PARTSTYPE"), Label).Text
                Session("PartsType") = PartsType
                Dim _AppleAppPartsInventoryModel As AppleAppPartsInventoryModel = New AppleAppPartsInventoryModel()
                _AppleAppPartsInventoryModel.INVENTORY_NO = InventoryNo

                Dim _AppleAppPartsInventoryControl As AppleAppPartsInventoryControl = New AppleAppPartsInventoryControl()
                Dim _dtApplePartsInventory As DataTable = _AppleAppPartsInventoryControl.SelectInventoryEdit(_AppleAppPartsInventoryModel)
                If (_dtApplePartsInventory Is Nothing) Or (_dtApplePartsInventory.Rows.Count = 0) Then
                    Call showMsg(InventoryNo & " - Not Allowed To Edit!!!", "")
                    Exit Sub
                Else
                    Response.Redirect("Apple_APP_Parts_Entry.aspx?ino=" + Server.UrlEncode(InventoryNo))

                End If

            End If
        End If
    End Sub

    Protected Sub txtSearch1_Click(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing)
        Dim _AppleAppPartsInventoryModel As New AppleAppPartsInventoryModel
        Dim AppleAppPartsInventoryControl As AppleAppPartsInventoryControl = New AppleAppPartsInventoryControl()

        Dim strDateFrom As String = txtdatefrom.Text
        Dim strTodate As String = txtdateto.Text
        strDateFrom = CDate(strDateFrom).ToString("yyyy/MM/dd")
        strTodate = CDate(strTodate).ToString("yyyy/MM/dd")

        _AppleAppPartsInventoryModel.inventry_date_from = strDateFrom
        _AppleAppPartsInventoryModel.inventry_date = strTodate

        _AppleAppPartsInventoryModel.SHIP_TO_BRANCH_CODE = Session("ship_code")

        Dim _Datatble As DataTable = AppleAppPartsInventoryControl.GetInventry(_AppleAppPartsInventoryModel)

        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView

            gridship.DataSource = dv

            grid1.Visible = True
            Div1.Visible = True

            grid2.Visible = False

        Else
            gridship.DataSource = _Datatble

        End If
        gridship.DataBind()

        lblApplePartsEntry.Visible = False
        lblAppleInventry.Visible = True
        btninventryhome.Visible = False
        txtinventrtdate.Visible = False
        lblinvenrtry.Visible = False

    End Sub

    Protected Sub btnShiphome_Click(sender As Object, e As EventArgs)
        grid1.Visible = True
        grid2.Visible = False
        Div1.Visible = True

        lblApplePartsEntry.Visible = False
        lblAppleInventry.Visible = True
        btninventryhome.Visible = False
        txtinventrtdate.Visible = False
        lblinvenrtry.Visible = False
        inv_Date = 0
        pageload()
    End Sub

    Protected Sub btnnewparts_Click(sender As Object, e As EventArgs)
        inv_Date = 0
        Response.Redirect("Apple_APP_parts_entry.aspx")
    End Sub

    Protected Sub gridship_pageindexchanging(sender As Object, e As GridViewPageEventArgs)
        gridship.PageIndex = e.NewPageIndex
        inv_Date = 0
        pageload()
    End Sub

    Protected Sub btnPartsStock_Click(sender As Object, e As EventArgs)
        Response.Redirect("Apple_APP_parts_stock.aspx")
    End Sub

    Protected Sub btnTransView_Click(sender As Object, e As EventArgs)
        Response.Redirect("Apple_APP_Stock_Transaction.aspx")
    End Sub
End Class