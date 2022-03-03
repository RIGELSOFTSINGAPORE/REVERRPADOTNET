Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection

Public Class Apple_PO
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If
        End If
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'lblPO.Text = ""

        'lblPO.Text = "GA000000" & Now.Second
        btnCust.Visible = False
        chkEditable.Visible = False
        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")
        Dim userid As String = Session("user_id")


        Dim _ApplePoModel As ApplePoModel = New ApplePoModel()
        Dim _ApplePoControl As ApplePoControl = New ApplePoControl()
        _ApplePoModel.UserId = userid
        _ApplePoModel.SHIP_TO_BRANCH_CODE = shipCode
        _ApplePoModel.SHIP_TO_BRANCH = ShipName
        _ApplePoModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress
        Dim PoNo As String = _ApplePoControl.SelectPoNo(_ApplePoModel)

        If PoNo = "-1" Then
            lblPO.Text = "PO No - Internal Server Error, Contact System Administrator"

        Else

            lblPO.Text = PoNo
            btnCust.Visible = True
            chkEditable.Visible = True
            'Dim strLoginPage As String = "Apple_Customer_Information.aspx?PoNo=" & PoNo & "&trn=new"
            'Dim scriptText As String = "alert('New PO No'); window.location='" & Request.ApplicationPath & strLoginPage & "'"
            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "alertMessage", scriptText, True)
        End If
    End Sub

    Protected Sub btnCust_Click(sender As Object, e As EventArgs) Handles btnCust.Click
        If chkEditable.Checked Then
            Response.Redirect("Apple_Customer_Information.aspx?PoNo=" & lblPO.Text & "&E=yes")
        Else
            Response.Redirect("Apple_Customer_Information.aspx?PoNo=" & lblPO.Text)
        End If
    End Sub
End Class