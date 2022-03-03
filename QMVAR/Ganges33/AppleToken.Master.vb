Public Class AppleToken
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

            'If adminFlg Then
            '    divAdmin.Visible = True
            'Else
            '    divAdmin.Visible = False
            'End If
        End If

    End Sub



    Private Sub btnTicket_ServerClick(sender As Object, e As EventArgs) Handles btnTicket.ServerClick
        Response.Redirect("Apple_Token_Ticketing.aspx")
    End Sub

    Private Sub btnWaiting_ServerClick(sender As Object, e As EventArgs) Handles btnWaiting.ServerClick
        Response.Redirect("Apple_Token_WaitingI.aspx")
    End Sub

    'Private Sub btnCustomerInformation_ServerClick(sender As Object, e As EventArgs) Handles btnCustomerInformation.ServerClick
    '    Response.Redirect("Apple_Customer_Information.aspx")
    'End Sub

    'Private Sub btnCustomerInformation_temp_ServerClick(sender As Object, e As EventArgs) Handles btnCustomerInformation_temp.ServerClick
    '    Response.Redirect("Apple_Customer_Information_temp.aspx")
    'End Sub





    Protected Sub BtnLogof_Click(sender As Object, e As EventArgs)
        Response.Redirect("token/Login.aspx")
    End Sub

    'Private Sub btnLabour_ServerClick(sender As Object, e As EventArgs) Handles btnLabour.ServerClick
    '    Response.Redirect("Apple_Labour_search.aspx")
    'End Sub

    'Private Sub btnParts_ServerClick(sender As Object, e As EventArgs) Handles btnParts.ServerClick
    '    Response.Redirect("Apple_Parts_search.aspx")
    'End Sub

End Class