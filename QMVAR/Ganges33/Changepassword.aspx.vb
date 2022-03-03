Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Web.UI.WebControls
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Changepassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            Dim setShipname As String = Session("ship_Name")
            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            Dim adminFlg As Boolean = Session("admin_Flg")




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
    Private Sub send_Click(sender As Object, e As EventArgs) Handles send.Click
        Dim MUsermodel As New MUserModel
        Dim Changepasswordcontrol As New Changepasswordcontrol
        Dim userid As String = Session("user_id").ToString
        Dim password1 As String = newpwd.Text
        Dim confrin As String = canpwd.Text
        Dim password As String = oldpwd.Text

        If confrin <> password1 Then
            Call showMsg("New password and old password is not match", "")

            Exit Sub
        End If
        If oldpwd.Text = "" Then
            Call showMsg("Enter the old password", "")
            Exit Sub
        End If
        If newpwd.Text = "" Then
            Call showMsg("Enter the New password", "")
            Exit Sub
        End If

        If canpwd.Text = "" Then
            Call showMsg("Enter the confrim password", "")
            Exit Sub
        End If


        MUsermodel.User_Id = userid.ToString
        MUsermodel.Password = password1.ToString
        MUsermodel.oldPassword = password.ToString

        Dim _Datatble As DataTable = Changepasswordcontrol.Get_Userdata(MUsermodel)
        If _Datatble.Rows.Count <> 0 Then

            MUsermodel.User_Id = userid
            MUsermodel.Password = password1
            MUsermodel.oldPassword = password
            Dim insertCredit As Boolean = Changepasswordcontrol.Changepassword(MUsermodel)
            If (insertCredit = True) Then
                Call showMsg("Password changed succesfully", "")
                newpwd.Text = ""
                oldpwd.Text = ""
                canpwd.Text = ""


            Else
                Call showMsg("Password changed failed", "")
                newpwd.Text = ""
                oldpwd.Text = ""
                canpwd.Text = ""
            End If

        Else
            Call showMsg("password is not matching", "")
            Exit Sub
        End If

    End Sub
End Class