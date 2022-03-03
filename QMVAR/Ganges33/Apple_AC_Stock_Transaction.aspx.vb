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

Public Class Apple_AC_Stock_Transaction
    Inherits System.Web.UI.Page
    Dim clsSet As New Class_money

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***            Dim userid As String = Session("user_id")
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If
            'Verify Valid User to use this page 
            'Dim adminFlg As Boolean = Session("admin_Flg")
            'If adminFlg = False Then
            '    Response.Redirect("Login.aspx")
            'End If

            GridViewBind()
        End If
    End Sub

    Protected Sub GridViewBind(Optional ByVal sortExpression As String = Nothing, Optional strText As Object = Nothing)
        Dim _AppleStockTransactionModel As New AppleStockTransactionModel
        Dim _AppleStockTransactionControl As New AppleStockTransactionControl

        '_AppleStockTransactionModel.PARTS_NO = Trim(txtPartsNo.Text)
        '_AppleStockTransactionModel.PRODUCT_NAME = Trim(txtProductName.Text)
        Dim dtAppleTrans As DataTable = _AppleStockTransactionControl.GetParts_StockTransaction(_AppleStockTransactionModel)

        Dim _dataview As New DataView(dtAppleTrans)
        If (Not (sortExpression) Is Nothing) Then
            Dim dv As DataView = dtAppleTrans.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection
            Gridview1.DataSource = dv
        Else
            Gridview1.DataSource = dtAppleTrans
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
        'ScriptManager.RegisterClientScriptBlock(updatepnl, Me.GetType(), "startup", sScript, True)

    End Sub

    Protected Sub Gridview1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        'Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Gridview1.PageIndex = e.NewPageIndex
        GridViewBind()
    End Sub

    Protected Sub Gridview1_Sorting(sender As Object, e As GridViewSortEventArgs)
        Me.GridViewBind(e.SortExpression)
    End Sub

    Protected Sub txtSearchGrid_Click(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing)
        If DropDownList1.SelectedItem.Text = "Select Date" And DropDownList2.SelectedItem.Text = "Select Item" Then
            Call showMsg("Please Select Date or Item", "")
            Exit Sub
        End If

        'If DropDownList2.SelectedItem.Text <> "Select Item" Then
        '    If String.IsNullOrEmpty(txtSearch.Text) Then
        '        Call showMsg("Please Enter the Item", "")
        '        Exit Sub
        '    End If
        'End If

        If DropDownList2.SelectedItem.Text <> "Select Item" Then
            If DropDownList3.SelectedItem.Text = "Search By" Then
                Call showMsg("Please Select Search By", "")
                Exit Sub
            End If
        End If

        If Not String.IsNullOrEmpty(txtFrom.Text) And Not String.IsNullOrEmpty(txtTodate.Text) Then
            If DropDownList1.SelectedItem.Text = "Select Date" Then
                Call showMsg("Please Select Date", "")
                Exit Sub
            End If
        End If

        'If String.IsNullOrEmpty(txtFrom.Text) And String.IsNullOrEmpty(txtTodate.Text) Then
        '    'If DropDownList1.SelectedItem.Text = "Select Date" Then
        '    Call showMsg("Please Enter date", "")
        '    Exit Sub
        '    'End If
        'End If

        Dim strDateFrom As String
        Dim strDateTo As String

        Dim _AppleStockTransactionModel As New AppleStockTransactionModel
        Dim _AppleStockTransactionControl As New AppleStockTransactionControl
        _AppleStockTransactionModel.DropdownSearch_1 = DropDownList1.SelectedItem.Value
        _AppleStockTransactionModel.DropdownSearch_2 = DropDownList2.SelectedItem.Value
        _AppleStockTransactionModel.DropdownSearch_3 = DropDownList3.SelectedItem.Value

        If Not String.IsNullOrEmpty(txtFrom.Text) And Not String.IsNullOrEmpty(txtTodate.Text) Then
            strDateFrom = CDate(txtFrom.Text).ToString("yyyy/MM/dd")
            strDateTo = CDate(txtTodate.Text).ToString("yyyy/MM/dd")
        End If

        _AppleStockTransactionModel.Search_From_Date = strDateFrom
        _AppleStockTransactionModel.Search_To_Date = strDateTo
        _AppleStockTransactionModel.GetValue = txtSearch.Text
        Dim _Datatble As DataTable = _AppleStockTransactionControl.GetStockTransaction(_AppleStockTransactionModel)
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

    Protected Sub btnback_Click(sender As Object, e As EventArgs)
        Response.Redirect("Apple_parts_Grid.aspx")
    End Sub

    Private Sub dropdownPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dropdownPage.SelectedIndexChanged

        If dropdownPage.SelectedItem.Value IsNot "0" Then
            Dim size = dropdownPage.SelectedItem.Value
            Gridview1.PageSize = size
            GridViewBind()
        Else
            Gridview1.PageSize = 50
            GridViewBind()
        End If

    End Sub

    Private Sub btnImgExcel_Click(sender As Object, e As ImageClickEventArgs) Handles btnImgExcel.Click
        Dim _AppleStockTransactionModel As New AppleStockTransactionModel
        Dim _AppleStockTransactionControl As New AppleStockTransactionControl

        '_AppleStockTransactionModel.PARTS_NO = Trim(txtPartsNo.Text)
        '_AppleStockTransactionModel.PRODUCT_NAME = Trim(txtProductName.Text)
        Dim dtAppleTrans As DataTable = _AppleStockTransactionControl.GetParts_StockTransaction(_AppleStockTransactionModel)

        Try
            If (dtAppleTrans Is Nothing) Or (dtAppleTrans.Rows.Count = 0) Then
                Call showMsg("No Data Found", "")
            Else
                ExportExcel(dtAppleTrans, "")
            End If
        Catch ex As Exception
            'dtAppleQmv = Display("")
        End Try
    End Sub

    Protected Function ExportDatatableToHtmlPartsStockTransaction(ByVal dt As DataTable) As String

        Dim strHTMLBuilder As StringBuilder = New StringBuilder()
        strHTMLBuilder.Append("<html >")
        strHTMLBuilder.Append("<head>")
        strHTMLBuilder.Append("</head>")
        strHTMLBuilder.Append("<body>")

        strHTMLBuilder.Append("<table border=1>")
        'strHTMLBuilder.Append("<tr><td></td><td colspan=3 style='text-align: center;font-size: 13px; padding: 5px;'>PO Amount</td><td colspan=2 style='text-align: center;font-size: 13px; padding: 5px;'>Billing Information</td><td colspan=2 style='text-align: center;font-size: 13px;'>Consumption</td><td colspan=3 style='text-align: center;font-size: 13px;'>Collection</td><td colspan=2 style='text-align: center;font-size: 13px;'>GSS Payment</td></tr>")
        strHTMLBuilder.Append("<tr>")
        strHTMLBuilder.Append("<td>Row</td><td>CRTDT</td><td>UPDDT</td><td>PART_NO</td><td>DESCRIPTION</td>")
        strHTMLBuilder.Append("<td>QUANTITY</td><td>TRAN_TYPE</td><td>TRAN_REF</td>")
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

            strHTMLBuilder.Append("</tr>")
        Next
        strHTMLBuilder.Append("</table>")
        strHTMLBuilder.Append("</body>")
        strHTMLBuilder.Append("</html>")
        Dim Htmltext As String = strHTMLBuilder.ToString()
        Return Htmltext
    End Function

    Protected Sub ExportExcel(ByVal dt As DataTable, ByVal strReportitle As String)

        Dim attachment As String = "attachment; filename=PartsTransaction.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim myData As Byte() = System.Text.Encoding.UTF8.GetBytes(ExportDatatableToHtmlPartsStockTransaction(dt))
        Response.BinaryWrite(myData)
        Response.Flush()
        Response.SuppressContent = True
        HttpContext.Current.ApplicationInstance.CompleteRequest()
    End Sub

    Protected Sub btnnewparts_Click(sender As Object, e As EventArgs)
        Response.Redirect("Apple_AC_Parts_Create.aspx")

    End Sub

    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        txtSearch.Text = ""
        txtFrom.Text = ""
        txtTodate.Text = ""
        DropDownList1.SelectedItem.Text = "Select Date"
        DropDownList2.SelectedItem.Text = "Select Item"
        DropDownList3.SelectedItem.Text = "Begin"
        GridViewBind()

    End Sub
End Class