Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Public Class Apple_Labour_search
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            '***セッションなしログインユーザの対応***            Dim userid As String = Session("user_id")
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            GridViewBind()
        End If
    End Sub
    Private Sub gvCashTrack_PageIndexChanged(sender As Object, e As EventArgs) Handles gvCashTrack.PageIndexChanged

    End Sub



    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("Apple_Labour_Create.aspx")
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        GridViewBind()
    End Sub
    Protected Sub grvCashTracking_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        gvCashTrack.PageIndex = e.NewPageIndex
        GridViewBind()
    End Sub
    Protected Sub GridViewBind(ByVal Optional Location As String = "")
        'txtCustomerName.Text = Trim(txtCustomerName.Text)
        'txtSerialNo.Text = Trim(txtSerialNo.Text)
        'txtProduct.Text = Trim(txtProduct.Text)
        'txtFrom.Text = Trim(txtFrom.Tex
        'txtTo.Text = Trim(txtFrom.Text)
        'txtPhoneNo.Text = Trim(txtPhoneNo.Text)


        Dim _AppleLabourModel As AppleLabourModel = New AppleLabourModel()
        Dim _AppleLabourControl As AppleLabourControl = New AppleLabourControl()
        '_AppleQmvOrdModel.CUSTOMER_NAME = txtCustomerName.Text
        '_AppleQmvOrdModel.SERIAL_NO = txtSerialNo.Text
        '_AppleQmvOrdModel.PRODUCT_NAME = txtProduct.Text
        ''_AppleQmvOrdModel.DELIVERY_DATE = txtFrom.Text
        ''_AppleQmvOrdModel.ESTIMATE_DATE = txtTo.Text
        '_AppleQmvOrdModel.STATUS = drpStatus.SelectedValue
        _AppleLabourModel.LABOUR_TYPE = DropDownList2.SelectedValue
        _AppleLabourModel.LABOUR_CODE = Trim(Labourcode.Text)
        Dim dtAppleQmv As DataTable = _AppleLabourControl.SelectLabourAll(_AppleLabourModel)

        gvCashTrack.DataSource = dtAppleQmv
        '   ViewState("dtCashTrackCount") = dtAppleQmv
        gvCashTrack.DataBind()

    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        If DropDownList1.SelectedItem.Value IsNot "0" Then

            Dim size = DropDownList1.SelectedItem.Value
            gvCashTrack.PageSize = size
            GridViewBind()
        Else
            gvCashTrack.PageSize = 5
            GridViewBind()
        End If
    End Sub

End Class