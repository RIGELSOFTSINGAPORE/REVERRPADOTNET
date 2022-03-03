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
Public Class Apple_parts_create
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

                Dim _ApplepartsModel As ApplePartsModel = New ApplePartsModel()
                Dim _ApplepartsControl As ApplePartsControl = New ApplePartsControl()
                _ApplepartsModel.UNQ_NO = UnqNo
                Dim dtAppleQmv As DataTable = _ApplepartsControl.SelectPart(_ApplepartsModel)

                If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then

                Else
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PO_NO")) Then
                        txtPONO.Text = dtAppleQmv.Rows(0)("PO_NO")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("STATUS")) Then
                        txtStatus.Text = dtAppleQmv.Rows(0)("STATUS")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRODUCT_NAME")) Then
                        txtProductName.Text = dtAppleQmv.Rows(0)("PRODUCT_NAME")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PARTS_NO")) Then
                        txtPartNo.Text = dtAppleQmv.Rows(0)("PARTS_NO")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PARTS_DETAIL")) Then
                        txtPartsDetail.Text = dtAppleQmv.Rows(0)("PARTS_DETAIL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PARTS_TYPE")) Then
                        txtPartstype.Text = dtAppleQmv.Rows(0)("PARTS_TYPE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TIER")) Then
                        txtTier.Text = dtAppleQmv.Rows(0)("TIER")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("CURRENCY")) Then
                        txtCurrency.Text = dtAppleQmv.Rows(0)("CURRENCY")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTION")) Then
                        'txtPriceoption.Text = dtAppleQmv.Rows(0)("PRICE_OPTION")
                        drpPriceoption.SelectedIndex = drpPriceoption.Items.IndexOf(drpPriceoption.Items.FindByValue(Trim(dtAppleQmv.Rows(0)("PRICE_OPTION"))))

                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_COST")) Then
                        txtPricecost.Text = dtAppleQmv.Rows(0)("PRICE_COST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("EEE_EEEE")) Then
                        txtE.Text = dtAppleQmv.Rows(0)("EEE_EEEE")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("ALTNATIVE_PARTS")) Then
                        TxtAltNativeParts.Text = dtAppleQmv.Rows(0)("ALTNATIVE_PARTS")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("COMPONENT_GROUP")) Then
                        txtComponentGroup.Text = dtAppleQmv.Rows(0)("COMPONENT_GROUP")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("SERIAL_NO")) Then
                        txtSerialNo.Text = dtAppleQmv.Rows(0)("SERIAL_NO")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("DIAG_REQ")) Then
                        txtDiagReq.Text = dtAppleQmv.Rows(0)("DIAG_REQ")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("SALES_PRICE")) Then
                        txtSalesprice.Text = dtAppleQmv.Rows(0)("SALES_PRICE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("HSN_SAC")) Then
                        txtHSNSAC.Text = dtAppleQmv.Rows(0)("HSN_SAC")
                    End If
                End If

            End If
        End If
    End Sub

    Sub ClearTextbox()
        txtComponentGroup.Text = ""
        TxtAltNativeParts.Text = ""
        txtCurrency.Text = ""
        txtDiagReq.Text = ""
        txtE.Text = ""
        txtHSNSAC.Text = ""
        txtPartNo.Text = ""
        txtPartsDetail.Text = ""
        txtPartstype.Text = ""
        txtPONO.Text = ""
        txtPricecost.Text = ""
        txtProductName.Text = ""
        txtSalesprice.Text = ""
        txtSerialNo.Text = ""
        txtStatus.Text = ""
        txtTier.Text = ""

    End Sub

    Private Sub create_Click(sender As Object, e As EventArgs) Handles create.Click

        If Trim(txtPartNo.Text) = "" Then
            Call showMsg("Part No Is Empty", "")
            Exit Sub
        End If


        Dim PriceCost As Decimal = 0.00
        If Trim(txtPricecost.Text) <> "" Then
            If Decimal.TryParse(txtPricecost.Text, PriceCost) Then

            Else
                Call showMsg("Price Cost Is Invalid", "")
                Exit Sub
            End If
        End If

        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")
        Dim userid As String = Session("user_id")


        Dim _ApplepartsModel As ApplePartsModel = New ApplePartsModel()
        Dim _ApplepartsControl As ApplePartsControl = New ApplePartsControl()
        _ApplepartsModel.UserId = userid
        _ApplepartsModel.SHIP_TO_BRANCH_CODE = shipCode
        _ApplepartsModel.SHIP_TO_BRANCH = ShipName
        _ApplepartsModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress

        _ApplepartsModel.ALTNATIVE_PARTS = TxtAltNativeParts.Text
        _ApplepartsModel.COMPONENT_GROUP = txtComponentGroup.Text
        _ApplepartsModel.CURRENCY = txtCurrency.Text
        _ApplepartsModel.DIAG_REQ = txtDiagReq.Text
        _ApplepartsModel.EEE_EEEE = txtE.Text
        _ApplepartsModel.HSN_SAC = txtHSNSAC.Text
        _ApplepartsModel.STATUS = txtStatus.Text
        _ApplepartsModel.TIER = txtTier.Text
        _ApplepartsModel.PO_NO = txtPONO.Text
        _ApplepartsModel.PRODUCT_NAME = txtProductName.Text
        _ApplepartsModel.PARTS_NO = txtPartNo.Text
        _ApplepartsModel.PARTS_DETAIL = txtPartsDetail.Text
        _ApplepartsModel.PARTS_TYPE = txtPartstype.Text
        _ApplepartsModel.PRICE_OPTION = drpPriceoption.SelectedItem.Value
        If Trim(txtPricecost.Text) <> "" Then
            _ApplepartsModel.PRICE_COST = txtPricecost.Text
        End If

        If Trim(txtSalesprice.Text) <> "" Then
            _ApplepartsModel.SALES_PRICE = txtSalesprice.Text
        End If
        _ApplepartsModel.UNQ_NO = Request.QueryString("UNQ_NO")
        Dim blStatus As Boolean = False
        blStatus = _ApplepartsControl.AddQmvOrd_parts(_ApplepartsModel)
        If blStatus Then
            Call showMsg(txtPartNo.Text & " has been successfully updated", "")
            If _ApplepartsModel.UNQ_NO = "" Then
                ClearTextbox()
            End If
            Exit Sub
        Else
            Call showMsg(txtPartNo.Text & " not updated (Verify Duplicate/Input Data ) !!!", "")
            Exit Sub
        End If


    End Sub

    Private Sub BAck_Click(sender As Object, e As EventArgs) Handles BAck.Click
        Response.Redirect("Apple_Parts_search.aspx")
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