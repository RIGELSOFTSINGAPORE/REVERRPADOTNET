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

Public Class Apple_App_Parts_Stock
    Inherits System.Web.UI.Page
    Dim clsSet As New Class_money

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            Dim setShipname As String = Session("ship_Name")
            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            If IsPostBack = False Then
                Display()
            End If

        End If
    End Sub

    Private Sub Display(Optional ByVal sortExpression As String = Nothing, Optional strText As Object = Nothing)
        Dim _ApPartsConsignmentStockMstModel As New ApPartsConsignmentStockMstModel
        Dim _ApPartsConsignmentStockMstControl As New ApPartsConsignmentStockMstControl

        _ApPartsConsignmentStockMstModel.PARTS_TYPE = drpStockType.SelectedItem.Value
        Dim _Datatble As DataTable = _ApPartsConsignmentStockMstControl.GetParts_Stock(_ApPartsConsignmentStockMstModel)
        Dim _dataview As New DataView(_Datatble)
        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection
            Gridview1.DataSource = dv
        Else
            Gridview1.DataSource = _Datatble
        End If
        Gridview1.DataBind()
    End Sub

    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Protected Sub txtSearchGrid_Click(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing)

        'If DropDownList1.SelectedItem.Text = "Select Date" And DropDownList2.SelectedItem.Text = "Select Item" Then
        '    Call showMsg("Please Select Date or Item", "")
        '    Exit Sub
        'End If

        'If DropDownList2.SelectedItem.Text <> "Select Item" Then
        '    If DropDownList3.SelectedItem.Text = "Search By" Then
        '        Call showMsg("Please Select Search By", "")
        '        Exit Sub
        '    End If
        'End If

        'If Not String.IsNullOrEmpty(txtFrom.Text) And Not String.IsNullOrEmpty(txtTodate.Text) Then
        '    If DropDownList1.SelectedItem.Text = "Select Date" Then
        '        Call showMsg("Please Select Date", "")
        '        Exit Sub
        '    End If
        'End If

        Dim strDateFrom As String
        Dim strDateTo As String

        Dim _ApPartsConsignmentStockMstModel As New ApPartsConsignmentStockMstModel
        Dim _ApPartsConsignmentStockMstControl As New ApPartsConsignmentStockMstControl
        _ApPartsConsignmentStockMstModel.PARTS_TYPE = drpStockType.SelectedItem.Value
        _ApPartsConsignmentStockMstModel.DropdownSearch_1 = DropDownList1.SelectedItem.Value
        _ApPartsConsignmentStockMstModel.DropdownSearch_2 = DropDownList2.SelectedItem.Value
        _ApPartsConsignmentStockMstModel.DropdownSearch_3 = DropDownList3.SelectedItem.Value

        If Not String.IsNullOrEmpty(txtFrom.Text) And Not String.IsNullOrEmpty(txtTodate.Text) Then
            strDateFrom = CDate(txtFrom.Text).ToString("yyyy/MM/dd")
            strDateTo = CDate(txtTodate.Text).ToString("yyyy/MM/dd")
        End If

        _ApPartsConsignmentStockMstModel.Search_From_Date = strDateFrom
        _ApPartsConsignmentStockMstModel.Search_To_Date = strDateTo
        _ApPartsConsignmentStockMstModel.GetValue = txtSearch.Text
        Dim _Datatble As DataTable = _ApPartsConsignmentStockMstControl.GetPartsStock(_ApPartsConsignmentStockMstModel)
        Dim _dataview As New DataView(_Datatble)
        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = _Datatble.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection
            Gridview1.DataSource = dv
        Else
            Gridview1.DataSource = _Datatble
        End If
        Gridview1.DataBind()

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

    Protected Sub Gridview1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Gridview1.PageIndex = e.NewPageIndex
        Display()
    End Sub

    Protected Sub Gridview1_Sorting(sender As Object, e As GridViewSortEventArgs)
        Me.Display(e.SortExpression)
    End Sub

    Protected Sub btnback_Click(sender As Object, e As EventArgs)
        Response.Redirect("Apple_App_Inventory_Grid.aspx")
    End Sub

    Private Sub btnImgExcel_Click(sender As Object, e As ImageClickEventArgs) Handles btnImgExcel.Click

        Dim _ApPartsConsignmentStockMstModel As New ApPartsConsignmentStockMstModel
        Dim _ApPartsConsignmentStockMstcontrol As New ApPartsConsignmentStockMstControl
        _ApPartsConsignmentStockMstModel.PARTS_TYPE = drpStockType.SelectedItem.Value
        Dim _Datatble As DataTable = _ApPartsConsignmentStockMstcontrol.GetParts_Stock(_ApPartsConsignmentStockMstModel)

        Try
            If (_Datatble Is Nothing) Or (_Datatble.Rows.Count = 0) Then
                Call showMsg("No Data Found", "")
            Else
                ExportExcel(_Datatble, "")
            End If
        Catch ex As Exception
            'dtAppleQmv = Display("") 
        End Try
    End Sub

    Protected Function ExportDatatableToHtmlPartsStock(ByVal dt As DataTable) As String

        Dim strHTMLBuilder As StringBuilder = New StringBuilder()
        strHTMLBuilder.Append("<html >")
        strHTMLBuilder.Append("<head>")
        strHTMLBuilder.Append("</head>")
        strHTMLBuilder.Append("<body>")

        strHTMLBuilder.Append("<table border=1>")
        'strHTMLBuilder.Append("<tr><td></td><td colspan=3 style='text-align: center;font-size: 13px; padding: 5px;'>PO Amount</td><td colspan=2 style='text-align: center;font-size: 13px; padding: 5px;'>Billing Information</td><td colspan=2 style='text-align: center;font-size: 13px;'>Consumption</td><td colspan=3 style='text-align: center;font-size: 13px;'>Collection</td><td colspan=2 style='text-align: center;font-size: 13px;'>GSS Payment</td></tr>")
        strHTMLBuilder.Append("<tr>")
        strHTMLBuilder.Append("<td>Row</td><td>PART_NO</td><td>PARTS_DETAIL</td><td>PRODUCT_NAME</td><td>PARTS_TYPE</td>")
        strHTMLBuilder.Append("<td>CRTDT</td><td>UPDDT</td><td>TIER</td><td>PURCHASE_COST</td><td>EEE_EEEE</td><td>SERIAL_TYPE</td><td>SERIAL_NO</td><td>IN_STOCK</td><td>BALANCE</td>")
        strHTMLBuilder.Append("</tr>")

        For Each myRow As DataRow In dt.Rows
            strHTMLBuilder.Append("<tr>")
            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(0).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(1).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(2).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(3).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(4).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(5).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(6).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(7).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(8).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")
            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(9).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")
            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(10).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")
            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(11).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")
            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(12).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")
            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(13).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")
            'strHTMLBuilder.Append("<td>")
            'strHTMLBuilder.Append(myRow(dt.Columns(14).ColumnName).ToString())
            'strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("</tr>")
        Next

        strHTMLBuilder.Append("</table>")
        strHTMLBuilder.Append("</body>")
        strHTMLBuilder.Append("</html>")
        Dim Htmltext As String = strHTMLBuilder.ToString()
        Return Htmltext
    End Function

    Protected Sub ExportExcel(ByVal dt As DataTable, ByVal strReportitle As String)

        Dim attachment As String = "attachment; filename=ApPartsConsignmentStock.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim myData As Byte() = System.Text.Encoding.UTF8.GetBytes(ExportDatatableToHtmlPartsStock(dt))
        Response.BinaryWrite(myData)
        Response.Flush()
        Response.SuppressContent = True
        HttpContext.Current.ApplicationInstance.CompleteRequest()
    End Sub

    Protected Sub btnnewparts_Click(sender As Object, e As EventArgs)
        Response.Redirect("Apple_Parts_search.aspx")
    End Sub

    Private Sub dropdownPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dropdownPage.SelectedIndexChanged
        If dropdownPage.SelectedItem.Value IsNot "0" Then

            Dim size = dropdownPage.SelectedItem.Value
            Gridview1.PageSize = size
            Display()
        Else
            Gridview1.PageSize = 50
            Display()
        End If
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        txtSearch.Text = ""
        txtFrom.Text = ""
        txtTodate.Text = ""
        DropDownList1.ClearSelection()
        DropDownList2.ClearSelection()
        DropDownList3.ClearSelection()
        DropDownList1.SelectedItem.Text = "Select Date"
        DropDownList2.SelectedItem.Text = "Select Item"
        DropDownList3.SelectedItem.Text = "Begin"
        Display()
    End Sub
End Class