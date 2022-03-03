Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection


Imports iFont = iTextSharp.text.Font
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.Font.FontFamily
Public Class Apple_Model_Create
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            'Verify Valid User to use this page 
            Dim adminFlg As Boolean = Session("admin_Flg")
            If adminFlg = False Then
                Response.Redirect("Login.aspx")
            End If

            'Initialize
            ClearTextbox()

            Dim UnqNo As String = ""
            UnqNo = Request.QueryString("UNQ_NO")

            If (Trim(UnqNo) = "") Then
                'pass

            Else

                Dim _AppleRcptModel As AppleRcptModel = New AppleRcptModel()
                Dim _AppleRcptControl As AppleRcptControl = New AppleRcptControl()
                _AppleRcptModel.UNQ_NO = UnqNo
                Dim dtAppleQmv As DataTable = _AppleRcptControl.SelectModel(_AppleRcptModel)

                If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then

                Else
                    If Not IsDBNull(dtAppleQmv.Rows(0)("MODEL")) Then
                        txtModel.Text = dtAppleQmv.Rows(0)("MODEL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TYPE")) Then
                        'txtPriceoption.Text = dtAppleQmv.Rows(0)("PRICE_OPTION")
                        drpType.SelectedIndex = drpType.Items.IndexOf(drpType.Items.FindByValue(Trim(dtAppleQmv.Rows(0)("TYPE"))))

                    End If


                End If

            End If
        End If
    End Sub

    Sub ClearTextbox()
        txtModel.Text = ""

    End Sub

    Private Sub create_Click(sender As Object, e As EventArgs) Handles create.Click

        If Trim(txtModel.Text) = "" Then
            Call showMsg("Model Is Empty", "")
            Exit Sub
        End If


        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")
        Dim userid As String = Session("user_id")


        Dim _AppleRcptModel As AppleRcptModel = New AppleRcptModel()
        Dim _AppleRcptControl As AppleRcptControl = New AppleRcptControl()
        _AppleRcptModel.UserId = userid
        _AppleRcptModel.SHIP_TO_BRANCH_CODE = shipCode
        _AppleRcptModel.SHIP_TO_BRANCH = ShipName
        _AppleRcptModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress

        _AppleRcptModel.MODEL = txtModel.Text
        _AppleRcptModel.TYPE = drpType.SelectedItem.Value

        _AppleRcptModel.UNQ_NO = Request.QueryString("UNQ_NO")
        Dim blStatus As Boolean = False
        blStatus = _AppleRcptControl.AddModel(_AppleRcptModel)
        If blStatus Then
            Call showMsg(txtModel.Text & " has been successfully updated", "")
            If _AppleRcptModel.UNQ_NO = "" Then
                ClearTextbox()
            End If
            Exit Sub
        Else
            Call showMsg(txtModel.Text & " not updated (Verify Duplicate/Input Data ) !!!", "")
            Exit Sub
        End If


    End Sub

    Private Sub BAck_Click(sender As Object, e As EventArgs) Handles BAck.Click
        Response.Redirect("Apple_Model.aspx")
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
End Class