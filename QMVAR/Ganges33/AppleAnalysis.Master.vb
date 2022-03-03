Public Class AppleAnalysis
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim userid As String = Session("user_id")
            Dim setShipname As String = Session("ship_Name")
            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            Dim adminFlg As Boolean = Session("admin_Flg")

            If setShipname IsNot Nothing Then
                LblShipName.Text = setShipname

            End If

            If userid IsNot Nothing Then
                lblUser.Text = userid & " " & userName
            End If

            If adminFlg Then
                divAdmin.Visible = True
            Else
                divAdmin.Visible = False
            End If
        End If

    End Sub



    Private Sub btnPoGenerate_ServerClick(sender As Object, e As EventArgs) Handles btnPoGenerate.ServerClick
        Response.Redirect("Apple_PO.aspx")
    End Sub

    Private Sub btnPoSearch_ServerClick(sender As Object, e As EventArgs) Handles btnPoSearch.ServerClick
        Response.Redirect("Apple_Po_Search.aspx")
    End Sub

    'Private Sub btnCustomerInformation_ServerClick(sender As Object, e As EventArgs) Handles btnCustomerInformation.ServerClick
    '    Response.Redirect("Apple_Customer_Information.aspx")
    'End Sub

    'Private Sub btnCustomerInformation_temp_ServerClick(sender As Object, e As EventArgs) Handles btnCustomerInformation_temp.ServerClick
    '    Response.Redirect("Apple_Customer_Information_temp.aspx")
    'End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'ByDefault 
        lblInfo.Text = ""
        'Define
        Dim strQuery As String = ""
        'if both search string are empty
        txtPoNo.Text = Trim(txtPoNo.Text)
        txtGNo.Text = Trim(txtGNo.Text)
        If (txtPoNo.Text = "") And (txtGNo.Text = "") Then
            lblInfo.Text = "Po&nbsp;No&nbsp;/&nbsp;GNo&nbsp;Empty"
            Exit Sub
        End If
        If (txtPoNo.Text <> "") Then
            strQuery = "PoNo=" & txtPoNo.Text
        End If
        If (txtGNo.Text <> "") Then
            If Len(strQuery) > 1 Then
                strQuery = strQuery & "&GNo=" & txtGNo.Text
            Else
                strQuery = "GNo=" & txtGNo.Text
            End If
        End If

        If chkTemp.Checked Then
            If Len(strQuery) > 1 Then
                strQuery = strQuery & "&E=yes"
            Else
                strQuery = "E=yes"
            End If

        End If

        Response.Redirect("Apple_Customer_Information.aspx?" & strQuery)

    End Sub



    Protected Sub BtnLogof_Click(sender As Object, e As EventArgs)
        Response.Redirect("Login.aspx")
    End Sub


    Private Sub btnWaiting_ServerClick(sender As Object, e As EventArgs) Handles btnWaiting.ServerClick
        Response.Redirect("Apple_Token_Waiting.aspx")
    End Sub

    Private Sub btnDailySales_ServerClick(sender As Object, e As EventArgs) Handles btnDailySales.ServerClick
        Response.Redirect("Apple_DailySales.aspx")
    End Sub


    Private Sub btnTokenLst_ServerClick(sender As Object, e As EventArgs) Handles btnTokenLst.ServerClick
        Response.Redirect("Apple_Token_List.aspx")
    End Sub

    Private Sub btnAccInventory_ServerClick(sender As Object, e As EventArgs) Handles btnAccInventory.ServerClick
        Response.Redirect("Apple_Parts_Grid.aspx")
    End Sub

    'Private Sub btnLabour_ServerClick(sender As Object, e As EventArgs) Handles btnLabour.ServerClick
    '    Response.Redirect("Apple_Labour_search.aspx")
    'End Sub

    'Private Sub btnParts_ServerClick(sender As Object, e As EventArgs) Handles btnParts.ServerClick
    '    Response.Redirect("Apple_Parts_search.aspx")
    'End Sub
End Class