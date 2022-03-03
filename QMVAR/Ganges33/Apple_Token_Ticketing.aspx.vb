
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection


Public Class Apple_Token_Ticketing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("token/Login.aspx")
            End If


            ClearTextbox()


            'Load Labor DropDownlist.
            Dim _AppleRcptModel As AppleRcptModel = New AppleRcptModel()
            Dim _AppleRcptControl As AppleRcptControl = New AppleRcptControl()
            Dim dtAppleRcptType As DataTable = _AppleRcptControl.SelectRcptType(_AppleRcptModel)
            If (dtAppleRcptType Is Nothing) Or (dtAppleRcptType.Rows.Count = 0) Then
            Else
                Dim dr As DataRow
                dr = dtAppleRcptType.NewRow()
                dr(0) = "--Select--"
                'dr(1) = "-1"
                dtAppleRcptType.Rows.InsertAt(dr, 0)
                drpType.DataTextField = "TYPE"
                ' drpModel.DataValueField = "UNQ_NO"

                drpType.DataSource = dtAppleRcptType
                drpType.DataBind()
            End If






        End If
    End Sub

    Sub ClearTextbox()
        txtPoNo.Text = ""
        txtMobile.Text = ""
        txtName.Text = ""
        drpModel.SelectedIndex = drpModel.Items.IndexOf(drpModel.Items.FindByValue("--Select--"))
        drpType.SelectedIndex = drpType.Items.IndexOf(drpType.Items.FindByValue("--Select--"))

    End Sub


    Private Sub create_Click(sender As Object, e As EventArgs) Handles create.Click

        If Trim(txtName.Text) = "" Then
            Call showMsg("Name Is Empty", "")
            Exit Sub
        End If

        If drpType.SelectedItem.Text = "--Select--" Then
            Call showMsg("Please Select Type", "")
            Exit Sub
        End If

        If drpModel.SelectedItem.Text = "--Select--" Then
            Call showMsg("Please Select Model", "")
            Exit Sub
        End If



        If drpStatus.SelectedItem.Text = "--Select--" Then
            Call showMsg("Please Select Token Type", "")
            Exit Sub
        End If

        If drpStatus.SelectedItem.Text = "Pick up" Then
            If txtPoNo.Text = "" Then
                Call showMsg("Please Provide PO Number", "")
                Exit Sub
            End If
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

        _AppleRcptModel.NAME = Trim(txtName.Text)
        _AppleRcptModel.MOBILE = Trim(txtMobile.Text)
        _AppleRcptModel.MODEL = drpType.SelectedItem.Text & "(" & drpModel.SelectedItem.Text & ")"
        _AppleRcptModel.TOKEN_TYPE = drpStatus.SelectedItem.Value


        Dim PoNo As String = ""
        PoNo = Trim(txtPoNo.Text)

        Dim _ApplePoModel As ApplePoModel = New ApplePoModel()
        Dim _ApplePoControl As ApplePoControl = New ApplePoControl()
        _ApplePoModel.UserId = userid
        _ApplePoModel.SHIP_TO_BRANCH_CODE = shipCode
        _ApplePoModel.SHIP_TO_BRANCH = ShipName
        _ApplePoModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress

        If PoNo = "" Then
            PoNo = _ApplePoControl.SelectPoNo(_ApplePoModel)
            If PoNo = "-1" Then
                Call showMsg("PO No - Internal Server Error, Contact System Administrator", "")
                Exit Sub
            End If
        Else
            _ApplePoModel.PO_NO = PoNo
            Dim blPoNoExist As DataTable = _ApplePoControl.PoNoExist(_ApplePoModel)
            If (blPoNoExist Is Nothing) Or (blPoNoExist.Rows.Count = 0) Then
                Call showMsg("PO No Doest Not Exist", "")
                Exit Sub
            End If
        End If
        _AppleRcptModel.PO_NO = PoNo
        ' _AppleRcptModel.UNQ_NO = -1
        _AppleRcptModel.STATUS = "START"

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
        _AppleRcptModel.CRTDT = strYear & "/" & strMon & "/" & strDay

        Dim intStatus As Int16 = 0
        intStatus = _AppleRcptControl.AddToken(_AppleRcptModel)
        If intStatus = 0 Then

            ClearTextbox()

            Call showMsg("Successfully updated. Token No." & PoNo, "")
            Exit Sub
        ElseIf intStatus = 1 Then
            Call showMsg(PoNo & " - Token Is Already Generated", "")
            Exit Sub
        ElseIf intStatus = -1 Then

            Call showMsg(" Error !!!", "")
            Exit Sub
        End If


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

    Protected Sub drpType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpType.SelectedIndexChanged
        'Load Labor DropDownlist.
        Dim _AppleRcptModel As AppleRcptModel = New AppleRcptModel()
        Dim _AppleRcptControl As AppleRcptControl = New AppleRcptControl()
        _AppleRcptModel.TYPE = drpType.SelectedItem.Text
        Dim dtAppleRcptType As DataTable = _AppleRcptControl.SelectRcptModel(_AppleRcptModel)
        If (dtAppleRcptType Is Nothing) Or (dtAppleRcptType.Rows.Count = 0) Then
        Else
            Dim dr As DataRow
            dr = dtAppleRcptType.NewRow()
            dr(0) = "--Select--"
            dr(1) = "-1"
            dtAppleRcptType.Rows.InsertAt(dr, 0)
            drpModel.DataTextField = "MODEL"
            drpModel.DataValueField = "UNQ_NO"

            drpModel.DataSource = dtAppleRcptType
            drpModel.DataBind()
        End If
    End Sub
End Class