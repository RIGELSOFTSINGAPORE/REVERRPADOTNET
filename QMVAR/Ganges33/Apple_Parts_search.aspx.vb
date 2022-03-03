
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Public Class Apple_Parts_search
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            '***セッションなしログインユーザの対応***            Dim userid As String = Session("user_id")
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If
            'Verify Valid User to use this page 
            Dim adminFlg As Boolean = Session("admin_Flg")
            If adminFlg = False Then
                Response.Redirect("Login.aspx")
            End If

            GridViewBind()
        End If

    End Sub
    Private Sub gvPart_PageIndexChanged(sender As Object, e As EventArgs) Handles gvPart.PageIndexChanged

    End Sub



    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        GridViewBind()
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("Apple_parts_create.aspx")
    End Sub
    Protected Sub gvPart_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        gvPart.PageIndex = e.NewPageIndex
        GridViewBind()
    End Sub
    Protected Sub GridViewBind(ByVal Optional Location As String = "")


        Dim _ApplePartsModel As ApplePartsModel = New ApplePartsModel()
        Dim _ApplePartsControl As ApplePartsControl = New ApplePartsControl()

        _ApplePartsModel.PARTS_NO = Trim(txtPartsNo.Text)
        _ApplePartsModel.PRODUCT_NAME = Trim(txtProductName.Text)
        Dim dtAppleQmv As DataTable = _ApplePartsControl.SelectPart(_ApplePartsModel)

        gvPart.DataSource = dtAppleQmv
        gvPart.DataBind()

    End Sub

    Private Sub drpPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpPage.SelectedIndexChanged
        If drpPage.SelectedItem.Value IsNot "0" Then

            Dim size = drpPage.SelectedItem.Value
            gvPart.PageSize = size
            GridViewBind()
        Else
            gvPart.PageSize = 5
            GridViewBind()
        End If
    End Sub

    Private Sub btnbackToinv_Click(sender As Object, e As EventArgs) Handles btnbackToinv.Click
        Response.Redirect("Apple_App_Inventory_Grid.aspx")
    End Sub

    'Cannot insert duplicate key row in object 'dbo.AP_PARTS' with unique index 'NonClusteredIndex-20210419-230730'. The duplicate key value is (111, ProductName1, partno1, PartsType1, Exchange Price).The statement has been terminated.
End Class