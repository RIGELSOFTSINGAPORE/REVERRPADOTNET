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
Public Class Apple_Reword_Create
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


            'Initialize textbox
            ClearTextbox()
            Dim UnqNo As String = ""
            UnqNo = Request.QueryString("UNQ_NO")
            If (Trim(UnqNo) = "") Then
                'pass

            Else
                Dim _AppleRewordModel As AppleRewordModel = New AppleRewordModel()
                Dim _AppleRewordControl As AppleRewordControl = New AppleRewordControl()
                _AppleRewordModel.UNQ_NO = UnqNo

                Dim dtAppleQmv As DataTable = _AppleRewordControl.SelectReword(_AppleRewordModel)

                If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then
                    '  Call showMsg("The corporate number does not exist (" & txtCorpNumberEdit.Text.Trim & ") !!!")
                    'Exit Sub
                Else

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_NO")) Then
                        txtPartNo.Text = dtAppleQmv.Rows(0)("PART_NO")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_TYPE")) Then
                        txtLabourType.Text = dtAppleQmv.Rows(0)("LABOUR_TYPE")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_DESCRIPTION")) Then
                        txtLabourDescription.Text = dtAppleQmv.Rows(0)("LABOUR_DESCRIPTION")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_DETAILS")) Then
                        txtLabourDetails.Text = dtAppleQmv.Rows(0)("LABOUR_DETAILS")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_CODE")) Then
                        txtLabourCode.Text = dtAppleQmv.Rows(0)("LABOUR_CODE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("AMOUNT_100")) Then
                        txtAmount100.Text = dtAppleQmv.Rows(0)("AMOUNT_100")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("AMOUNT_150")) Then
                        txtAmount150.Text = dtAppleQmv.Rows(0)("AMOUNT_150")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("AMOUNT_170")) Then
                        txtAmount170.Text = dtAppleQmv.Rows(0)("AMOUNT_170")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("AMOUNT_180")) Then
                        txtAmount180.Text = dtAppleQmv.Rows(0)("AMOUNT_180")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("HSN_SAC")) Then
                        txtHsnSac.Text = dtAppleQmv.Rows(0)("HSN_SAC")
                    End If

                End If
                ' servicedrop()
            End If
        End If
    End Sub

    Sub ClearTextbox()
        txtPartNo.Text = ""
        txtLabourType.Text = ""
        txtLabourDescription.Text = ""
        txtLabourDetails.Text = ""
        txtLabourCode.Text = ""
        txtAmount100.Text = ""
        txtAmount150.Text = ""
        txtAmount170.Text = ""
        txtAmount180.Text = ""
        txtHsnSac.Text = ""


    End Sub

    Private Sub create_Click(sender As Object, e As EventArgs) Handles create.Click

        If Trim(txtPartNo.Text) = "" Then
            Call showMsg("Part No Is Empty", "")
            Exit Sub
        End If

        If Trim(txtLabourType.Text) = "" Then
            Call showMsg("Labour Type Is Empty", "")
            Exit Sub
        End If

        If Trim(txtLabourCode.Text) = "" Then
            Call showMsg("Labour Code Is Empty", "")
            Exit Sub
        End If


        Dim Amount As Decimal = 0.00
        If Trim(txtAmount100.Text) <> "" Then
            If Decimal.TryParse(txtAmount100.Text, Amount) Then

            Else
                Call showMsg("Amount_100 Is Invalid", "")
                Exit Sub
            End If
        End If

        If Trim(txtAmount150.Text) <> "" Then
            If Decimal.TryParse(txtAmount150.Text, Amount) Then

            Else
                Call showMsg("Amount_150 Is Invalid", "")
                Exit Sub
            End If
        End If

        If Trim(txtAmount170.Text) <> "" Then
            If Decimal.TryParse(txtAmount170.Text, Amount) Then

            Else
                Call showMsg("Amount_170 Is Invalid", "")
                Exit Sub
            End If
        End If

        If Trim(txtAmount180.Text) <> "" Then
            If Decimal.TryParse(txtAmount180.Text, Amount) Then

            Else
                Call showMsg("Amount_180 Is Invalid", "")
                Exit Sub
            End If
        End If


        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")
        Dim userid As String = Session("user_id")


        Dim _AppleRewordModel As AppleRewordModel = New AppleRewordModel()
        Dim _AppleRewordControl As AppleRewordControl = New AppleRewordControl()
        _AppleRewordModel.UserId = userid
        _AppleRewordModel.SHIP_TO_BRANCH_CODE = shipCode
        _AppleRewordModel.SHIP_TO_BRANCH = ShipName
        _AppleRewordModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress

        _AppleRewordModel.PART_NO = txtPartNo.Text
        _AppleRewordModel.LABOUR_TYPE = txtLabourType.Text
        _AppleRewordModel.LABOUR_DESCRIPTION = txtLabourDescription.Text
        _AppleRewordModel.LABOUR_DETAILS = txtLabourDetails.Text
        _AppleRewordModel.LABOUR_CODE = txtLabourCode.Text
        _AppleRewordModel.HSN_SAC = txtHsnSac.Text

        If Trim(txtAmount100.Text) <> "" Then
            _AppleRewordModel.AMOUNT_100 = txtAmount100.Text
        End If
        If Trim(txtAmount150.Text) <> "" Then
            _AppleRewordModel.AMOUNT_150 = txtAmount150.Text
        End If
        If Trim(txtAmount170.Text) <> "" Then
            _AppleRewordModel.AMOUNT_170 = txtAmount170.Text
        End If
        If Trim(txtAmount180.Text) <> "" Then
            _AppleRewordModel.AMOUNT_180 = txtAmount180.Text
        End If
        _AppleRewordModel.UNQ_NO = Request.QueryString("UNQ_NO")


        Dim blStatus As Boolean = False

        blStatus = _AppleRewordControl.AddQmvOrd_Reword(_AppleRewordModel)

        If blStatus Then
            Call showMsg(txtPartNo.Text & " has been successfully updated", "")

            If _AppleRewordModel.UNQ_NO = "" Then
                ClearTextbox()
            End If
            Exit Sub
        Else
                Call showMsg(txtPartNo.Text & " not updated (Verify Duplicate/Input Data ) !!!", "")
            Exit Sub
        End If
    End Sub

    Private Sub BAck_Click(sender As Object, e As EventArgs) Handles BAck.Click
        Response.Redirect("Apple_Reword.aspx")
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