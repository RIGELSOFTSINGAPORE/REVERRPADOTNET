Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Public Class Apple_PO_Search
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If
            ViewState("SortExpression") = "PO_NO"
            ViewState("SortDirection") = "DESC"

            gvPOInfo.DataSource = BindData("")
            gvPOInfo.DataBind()
        End If
    End Sub




    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        '''''''''''''''''''''''''GridViewBind()

        gvPOInfo.DataSource = BindData("")
        gvPOInfo.DataBind()


    End Sub


    Protected Sub btnImgExcel_Click(sender As Object, e As EventArgs) Handles btnImgExcel.Click
        Dim strText As String = ""
        Dim dtAppleQmv As DataTable
        Try
            strText = " Order By " & ViewState("SortExpression").ToString() & " " & ViewState("SortDirection").ToString()
            dtAppleQmv = BindData("", strText)
        Catch ex As Exception
            dtAppleQmv = BindData("")
        End Try

        If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then
        Else
            ExportExcel(dtAppleQmv, "")
        End If

    End Sub
    Protected Sub gvPOInfo_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        gvPOInfo.PageIndex = e.NewPageIndex

        Try
            '   BindData((ViewState("SortDirection").ToString()))
            gvPOInfo.DataSource = BindData((ViewState("SortDirection").ToString()))
            gvPOInfo.DataBind()
        Catch ex As Exception
            '   BindData("")
            gvPOInfo.DataSource = BindData("")
            gvPOInfo.DataBind()
        End Try

    End Sub

    Function BindData(ByVal sortExpression As String, Optional SortDefault As String = "") As DataTable
        txtCustomerName.Text = Trim(txtCustomerName.Text)
        txtSerialNo.Text = Trim(txtSerialNo.Text)
        txtProduct.Text = Trim(txtProduct.Text)
        txtFrom.Text = Trim(txtFrom.Text)
        txtTo.Text = Trim(txtTo.Text)
        txtPhoneNo.Text = Trim(txtPhoneNo.Text)
        txtPartsNo.Text = Trim(txtPartsNo.Text)

        Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
        Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
        Dim shipCode As String = Session("ship_code")
        If shipCode = "" Then
            Response.Redirect("Login.aspx")
        End If
        _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode

        _AppleQmvOrdModel.CUSTOMER_NAME = txtCustomerName.Text
        _AppleQmvOrdModel.SERIAL_NO = txtSerialNo.Text
        _AppleQmvOrdModel.PRODUCT_NAME = txtProduct.Text
        _AppleQmvOrdModel.DateFrom = txtFrom.Text
        _AppleQmvOrdModel.DateTo = txtTo.Text
        _AppleQmvOrdModel.COMP_STATUS = drpStatus.SelectedItem.Text
        _AppleQmvOrdModel.TELEPHONE = txtPhoneNo.Text
        _AppleQmvOrdModel.PART_NO1 = txtPartsNo.Text

        Try
            sortExpression = ViewState("SortExpression")
        Catch ex As Exception
            sortExpression = ""
        End Try

        Try
            SortDirection = ViewState("SortDirection")
        Catch ex As Exception
            SortDirection = "DESC"
        End Try

        If Not String.IsNullOrEmpty(SortDefault) Then
            _AppleQmvOrdModel.SortText = SortDefault
        ElseIf Not String.IsNullOrEmpty(sortExpression) Then

            _AppleQmvOrdModel.SortText = " Order By " & sortExpression & " " & SortDirection
            'Sql.Append(" Order By " & sortExpression & " " & SortDirection)
        End If
        Dim dtAppleQmv As DataTable = _AppleQmvOrdControl.SelectDetails(_AppleQmvOrdModel)

        Return dtAppleQmv
    End Function

    Protected Sub OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        ViewState("SortExpression") = e.SortExpression
        Me.SortDirection = If(Me.SortDirection = "ASC", "DESC", "ASC")
        gvPOInfo.DataSource = BindData(e.SortExpression)
        gvPOInfo.DataBind()


    End Sub

    Private Property SortDirection As String
        Get
            Return If(ViewState("SortDirection") IsNot Nothing, ViewState("SortDirection").ToString(), "ASC")
        End Get
        Set(ByVal value As String)
            ViewState("SortDirection") = value
        End Set
    End Property


    Sub ExportExcel(ExportFileName As String, result As String)
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=" & ExportFileName)
        Response.AddHeader("Pragma", "no-cache")
        Response.AddHeader("Cache-Control", "no-cache")
        Dim myData As Byte() = System.Text.Encoding.UTF8.GetBytes(result)
        Response.BinaryWrite(myData)
        Response.Flush()
        Response.SuppressContent = True
        HttpContext.Current.ApplicationInstance.CompleteRequest()
    End Sub

    Protected Function ExportDatatableToHtml(ByVal dt As DataTable, ByVal strReportitle As String) As String

        Dim val As Double = 0.00
        Dim rowid As Int16 = 0

        Dim strHTMLBuilder As StringBuilder = New StringBuilder()
        strHTMLBuilder.Append("<html >")
        strHTMLBuilder.Append("<head>")
        strHTMLBuilder.Append("</head>")
        strHTMLBuilder.Append("<body>")

        strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='white' style='font-family:Meiryo UI; font-size:10'>")
        'strHTMLBuilder.Append("<tr><td></td><td colspan=3 style='text-align: center;font-size: 13px; padding: 5px;'>PO Amount</td><td colspan=2 style='text-align: center;font-size: 13px; padding: 5px;'>Billing Information</td><td colspan=2 style='text-align: center;font-size: 13px;'>Consumption</td><td colspan=3 style='text-align: center;font-size: 13px;'>Collection</td><td colspan=2 style='text-align: center;font-size: 13px;'>GSS Payment</td></tr>")
        strHTMLBuilder.Append("<tr><td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>Date</td><td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>Daily Amount</td><td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>PO Return</td><td style='text-align: center; font-size: 13px;'>Month</td> <td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>Daily Amount</td><td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>Month</td>     <td style='text-align: center; font-size: 13px; width: 101px;'>Daily Amount</td><td style='text-align: center; font-size: 13px;'>Month</td><td style='text-align: center; font-size: 13px; width: 101px;'>Daily Deposit</td><td style='text-align: center; font-size: 13px;'>Credit Sales</td><td style='text-align: center; font-size: 13px; width: 62px;'>Month</td><td style='text-align: center; font-size: 13px; width: 62px;'>Daily</td><td style='text-align: center; font-size: 13px; width: 62px;'>Month</td></tr>")

        For Each myRow As DataRow In dt.Rows
            strHTMLBuilder.Append("<tr>")
            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold; padding:4px;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(0).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(1).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(2).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(3).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(4).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            'strHTMLBuilder.Append(myRow(dt.Columns(5).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            'strHTMLBuilder.Append(myRow(dt.Columns(6).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            ' strHTMLBuilder.Append(myRow(dt.Columns(7).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            'strHTMLBuilder.Append(myRow(dt.Columns(8).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            'strHTMLBuilder.Append(myRow(dt.Columns(9).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            ' strHTMLBuilder.Append(myRow(dt.Columns(10).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            'strHTMLBuilder.Append(myRow(dt.Columns(11).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            'strHTMLBuilder.Append(myRow(dt.Columns(12).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("</tr>")
        Next


        strHTMLBuilder.Append("</table>")
        strHTMLBuilder.Append("</body>")
        strHTMLBuilder.Append("</html>")
        Dim Htmltext As String = strHTMLBuilder.ToString()
        Return Htmltext
    End Function

    Protected Function ExportDatatableToHtmlPO(ByVal dt As DataTable) As String

        Dim val As Double = 0.00
        Dim rowid As Int16 = 0

        Dim strHTMLBuilder As StringBuilder = New StringBuilder()
        strHTMLBuilder.Append("<html >")
        strHTMLBuilder.Append("<head>")
        strHTMLBuilder.Append("</head>")
        strHTMLBuilder.Append("<body>")

        strHTMLBuilder.Append("<table border=1>")
        'strHTMLBuilder.Append("<tr><td></td><td colspan=3 style='text-align: center;font-size: 13px; padding: 5px;'>PO Amount</td><td colspan=2 style='text-align: center;font-size: 13px; padding: 5px;'>Billing Information</td><td colspan=2 style='text-align: center;font-size: 13px;'>Consumption</td><td colspan=3 style='text-align: center;font-size: 13px;'>Collection</td><td colspan=2 style='text-align: center;font-size: 13px;'>GSS Payment</td></tr>")
        strHTMLBuilder.Append("<tr>")
        strHTMLBuilder.Append("<td>PO_NO</td><td>PO_DATE</td><td>COMP_STATUS</td><td>G_NO</td>")
        strHTMLBuilder.Append("<td>CUSTOMER_NAME</td><td>ZIP_CODE</td><td>MOBLIE_PHONE</td><td>TELEPHONE</td><td>ADD_1</td><td>ADD_2</td><td>CITY</td><td>STATE</td><td>STATE_CODE</td><td>E_MAIL</td><td>IS_SHIP_DIFF</td><td>CUSTOMER_NAME_SHIP</td><td>ZIP_CODE_SHIP</td><td>MOBLIE_PHONE_SHIP</td><td>TELEPHONE_SHIP</td><td>ADD_1_SHIP</td><td>ADD_2_SHIP</td><td>CITY_SHIP</td><td>STATE_SHIP</td><td>STATE_CODE_SHIP</td><td>E_MAIL_SHIP</td><td>MODEL_NAME</td><td>PRODUCT_NAME</td><td>SERIAL_NO</td><td>IMEI_1</td><td>IMEI_2</td><td>DATE_OF_PURCHASE</td><td>SERVICE_TYPE</td><td>COMPTIA</td><td>COMPTIA_MODIFIER</td><td>PART_NO1</td><td>PART_NO2</td><td>PART_NO3</td><td>PART_NO4</td><td>PART_DETAIL_1</td><td>PART_DETAIL_2</td><td>PART_DETAIL_3</td><td>PART_DETAIL_4</td><td>PART_QTY_1</td><td>PART_QTY_2</td><td>PART_QTY_3</td><td>PART_QTY_4</td><td>PART_DISCOUNT_1</td><td>PART_DISCOUNT_2</td><td>PART_DISCOUNT_3</td><td>PART_DISCOUNT_4</td><td>LABOR_AMOUNT</td><td>LABOR_DETAIL</td><td>LABOR_COST</td><td>LABOR_DISCOUNT</td><td>LABOR_SALES</td><td>LABOR_SGST</td><td>LABOR_CGST</td><td>LABOR_IGST</td><td>LABOR_TOTAL</td><td>PART_COST_1</td><td>PART_COST_2</td><td>PART_COST_3</td><td>PART_COST_4</td><td>PART_COST_SALES_1</td><td>PART_COST_SALES_2</td><td>PART_COST_SALES_3</td><td>PART_COST_SALES_4</td><td>PART1_TAX</td><td>PART2_TAX</td><td>PART3_TAX</td><td>PART4_TAX</td><td>LABOUR_TAX</td><td>OTHER_TAX</td><td>PART_SGST_1</td><td>PART_SGST_2</td><td>PART_SGST_3</td><td>PART_SGST_4</td><td>PART_CGST_1</td><td>PART_CGST_2</td><td>PART_CGST_3</td><td>PART_CGST_4</td><td>PART_IGST_1</td><td>PART_IGST_2</td><td>PART_IGST_3</td><td>PART_IGST_4</td><td>PART_TOTAL_1</td><td>PART_TOTAL_2</td><td>PART_TOTAL_3</td><td>PART_TOTAL_4</td><td>PART_QTY_AMOUNT</td><td>PART_COST_AMOUNT</td><td>PART_SALES_AMOUNT</td><td>PART_DISCOUNT_AMOUNT</td><td>PART_SGST_AMOUNT</td><td>PART_CGST_AMOUNT</td><td>PART_IGST_AMOUNT</td><td>PART_TOTAL</td><td>OTHER_QTY_AMOUNT</td><td>OTHER_DETAIL</td><td>OTHER_COST</td><td>OTHER_DISCOUNT</td><td>OTHER_SALES</td><td>OTHER_SGST</td><td>OTHER_CGST</td><td>OTHER_IGST</td><td>OTHER_TOTAL</td><td>TOTAL_QTY</td><td>TOTAL_COST_AMOUNT</td><td>TOTAL_DISCOUNT_AMOUNT</td><td>TOTAL_SALES_AMOUNT</td><td>TOTAL_SGST_AMOUNT</td><td>TOTAL_CGST_AMOUNT</td><td>TOTAL_IGST_AMOUNT</td><td>TOTAL_AMOUNT</td><td>DELIVERY_DATE</td><td>COMP_STATUS</td><td>COMP_DATE</td><td>DENOMINATION</td><td>ESTIMATE_DATE</td><td>ESTIMATE_TIME</td><td>GSX_CLOSE_DATE</td><td>USE_SERVICE_TYPE</td><td>INVOICE_NOTE</td><td>GSX_NOTE</td><td>HSN_SAC_CODE</td><td>GSTIN</td><td>IP_ADDRESS</td><td>FILE_NAME</td><td>SRC_FILE_NAME</td><td>PART_HSN_ASC_1</td><td>PART_HSN_ASC_2</td><td>PART_HSN_ASC_3</td><td>PART_HSN_ASC_4</td><td>PRICE_OPTIONS_1</td><td>PRICE_OPTIONS_2</td><td>PRICE_OPTIONS_3</td><td>PRICE_OPTIONS_4</td><td>ADVANCE_PAYMENT</td><td>INVOICE_NO</td><td>INVOICE_DATE</td><td>TRANSFER_REPAIR_CENTER</td><td>ACTION_TAKEN</td><td>RECEPTION</td><td>INTERNAL_INSPECTION</td><td>SIGNATURE_INSERVICE_ESTIMATE</td><td>WHOLE_SERVICE_FEE_ADR_COLLECTION</td><td>GSX_ORDER</td><td>REPAIR</td><td>REMAINING_AMOUNT_COLLECTION</td><td>LOANER_COLLECTION</td><td>SEVICE_REPORT</td><td>TAX_INVOICE</td>")
        strHTMLBuilder.Append("</tr>")
        '151
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

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(14).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(15).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(16).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(17).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(18).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(19).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(20).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(21).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(22).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(23).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(24).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(25).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(26).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(27).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(28).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(29).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(30).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(31).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(32).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(33).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(34).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(35).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(36).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(37).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(38).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(39).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(40).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(41).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(42).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(43).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(44).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(45).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(46).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(47).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(48).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(49).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(50).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(51).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(52).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(53).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(54).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(55).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(56).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(57).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(58).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(59).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(60).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")



            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(61).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(62).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(63).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(64).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(65).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(66).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(67).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(68).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(69).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(70).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")




            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(71).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(72).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(73).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(74).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(75).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(76).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(77).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(78).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(79).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(80).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")



            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(81).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(82).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(83).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(84).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(85).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(86).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(87).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(88).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(89).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(90).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(91).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(92).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(93).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(94).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(95).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(96).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(97).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(98).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(99).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(100).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(101).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(102).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(103).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(104).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(105).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(106).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(107).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(108).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(109).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(110).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")



            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(111).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(112).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(113).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(114).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(115).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(116).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(117).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(118).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(119).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(120).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(121).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(122).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(123).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(124).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(125).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(126).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(127).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(128).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(129).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(130).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(131).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(132).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(133).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(134).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(135).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")


            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(136).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(137).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(138).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(139).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(140).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(141).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(142).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(143).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(144).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(145).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(146).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(147).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(148).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(149).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(150).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td>")
            strHTMLBuilder.Append(myRow(dt.Columns(151).ColumnName).ToString())
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

        'Dim attachment As String = "attachment; filename=customer.xls"
        'Response.ClearContent()
        'Response.AddHeader("content-disposition", attachment)
        'Response.ContentType = "application/vnd.ms-excel"
        'Dim tab As String = ""
        'Dim intSkip As Integer = 0
        'For Each dc As DataColumn In dt.Columns
        '    intSkip = intSkip + 1
        '    If intSkip >= 3 Then
        '        Response.Write(tab & dc.ColumnName)
        '        tab = vbTab
        '    End If

        'Next

        'Response.Write(vbLf)
        'Dim i As Integer
        'For Each dr As DataRow In dt.Rows

        '    tab = ""

        '    For i = 2 To dt.Columns.Count - 1
        '        Response.Write(tab & dr(i).ToString())
        '        tab = vbTab
        '    Next
        '    Response.Write(vbLf)
        'Next
        'Response.End()


        Dim attachment As String = "attachment; filename=customer.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim myData As Byte() = System.Text.Encoding.UTF8.GetBytes(ExportDatatableToHtmlPO(dt))
        Response.BinaryWrite(myData)
        Response.Flush()
        Response.SuppressContent = True
        HttpContext.Current.ApplicationInstance.CompleteRequest()



    End Sub

End Class