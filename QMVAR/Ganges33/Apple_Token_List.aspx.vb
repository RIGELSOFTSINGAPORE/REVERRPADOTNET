Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Public Class Apple_Token_List
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            'Today Date
            Dim strDay As String = ""
            Dim strMon As String = ""
            Dim strYear As String = ""
            strDay = Now.Day()
            strMon = Now.Month
            strYear = Now.Year
            If Len(strDay) < 2 Then
                strDay = "0" & strDay
            End If
            If Len(strMon) < 2 Then
                strMon = "0" & strMon
            End If

            txtFrom.Text = Trim(strYear & "/" & strMon & "/" & strDay)
            txtTo.Text = Trim(txtFrom.Text)

            ViewState("SortExpression") = "CRTDT"
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

    Private Sub drpPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpPage.SelectedIndexChanged
        If drpPage.SelectedItem.Value IsNot "0" Then

            Dim size = drpPage.SelectedItem.Value
            gvPOInfo.PageSize = size
            gvPOInfo.DataSource = BindData("")
            gvPOInfo.DataBind()
        Else
            gvPOInfo.PageSize = 5
            gvPOInfo.DataSource = BindData("")
            gvPOInfo.DataBind()
        End If
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
        txtName.Text = Trim(txtName.Text)
        txtPhoneNo.Text = Trim(txtPhoneNo.Text)
        txtModel.Text = Trim(txtModel.Text)
        txtFrom.Text = Trim(txtFrom.Text)
        txtTo.Text = Trim(txtTo.Text)
        txtPoNo.Text = Trim(txtPoNo.Text)
        'txtPartsNo.Text = Trim(txtPartsNo.Text)

        Dim _AppleRcptModel As AppleRcptModel = New AppleRcptModel()
        Dim _AppleRcptControl As AppleRcptControl = New AppleRcptControl()
        Dim shipCode As String = Session("ship_code")
        If shipCode = "" Then
            Response.Redirect("Login.aspx")
        End If
        _AppleRcptModel.SHIP_TO_BRANCH_CODE = shipCode

        _AppleRcptModel.NAME = txtName.Text
        _AppleRcptModel.MOBILE = txtPhoneNo.Text
        _AppleRcptModel.MODEL = txtModel.Text
        _AppleRcptModel.DateFrom = txtFrom.Text
        _AppleRcptModel.DateTo = txtTo.Text
        _AppleRcptModel.STATUS = drpStatus.SelectedItem.Text
        _AppleRcptModel.PO_NO = txtPoNo.Text

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
            _AppleRcptModel.SortText = SortDefault
        ElseIf Not String.IsNullOrEmpty(sortExpression) Then

            _AppleRcptModel.SortText = " Order By " & sortExpression & " " & SortDirection
            'Sql.Append(" Order By " & sortExpression & " " & SortDirection)
        End If
        Dim dtAppleQmv As DataTable = _AppleRcptControl.SelectTokenList(_AppleRcptModel)

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



    Protected Sub ExportExcel(ByVal dt As DataTable, ByVal strReportitle As String)

        Dim attachment As String = "attachment; filename=customer.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim tab As String = ""
        Dim intSkip As Integer = 0
        For Each dc As DataColumn In dt.Columns
            intSkip = intSkip + 1
            If intSkip >= 3 Then
                Response.Write(tab & dc.ColumnName)
                tab = vbTab
            End If

        Next

        Response.Write(vbLf)
        Dim i As Integer
        For Each dr As DataRow In dt.Rows

            tab = ""

            For i = 2 To dt.Columns.Count - 1
                Response.Write(tab & dr(i).ToString())
                tab = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.End()

    End Sub

End Class