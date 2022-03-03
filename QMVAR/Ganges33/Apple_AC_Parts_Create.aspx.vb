Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection

Public Class Apple_AC_Parts_Create
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
            Dim PartNO As String = ""
            PartNO = Request.QueryString("PART_NO")
            If (Trim(PartNO) = "") Then

            Else

                Dim _ApplePartsStock As New ApplePartsStockModel
                Dim _ApplePartsStockcontrol As New ApplePartsStockControl
                _ApplePartsStock.PART_NO = PartNO

                Dim _Datatble As DataTable = _ApplePartsStockcontrol.GetPartsEdit(_ApplePartsStock)

                If (_Datatble Is Nothing) Or (_Datatble.Rows.Count = 0) Then

                Else
                    If Not IsDBNull(_Datatble.Rows(0)("PART_NO")) Then
                        txtpartno.Text = _Datatble.Rows(0)("PART_NO")
                        txtpartno.ReadOnly = True
                        txtpartno.BackColor = System.Drawing.Color.AliceBlue
                    End If
                    If Not IsDBNull(_Datatble.Rows(0)("UPC_EAN")) Then
                        txtUPCEAN.Text = _Datatble.Rows(0)("UPC_EAN")
                    End If
                    If Not IsDBNull(_Datatble.Rows(0)("DESCRIPTION")) Then
                        txtDescription.Text = _Datatble.Rows(0)("DESCRIPTION")
                    End If
                    If Not IsDBNull(_Datatble.Rows(0)("SAP_PART_DESCRIPTION")) Then
                        txtSAPDESCRIPTION.Text = _Datatble.Rows(0)("SAP_PART_DESCRIPTION")
                    End If
                    If Not IsDBNull(_Datatble.Rows(0)("PURCHASE_PRICE")) Then
                        txtPURCHASEPRICE.Text = _Datatble.Rows(0)("PURCHASE_PRICE")
                    End If
                    If Not IsDBNull(_Datatble.Rows(0)("SALES_PRICE")) Then
                        txtsalesPrice.Text = _Datatble.Rows(0)("SALES_PRICE")
                    End If
                    If Not IsDBNull(_Datatble.Rows(0)("CURRENT_IN_STOCK")) Then
                        txtCURRENTINSTOCK.Text = _Datatble.Rows(0)("CURRENT_IN_STOCK")
                    Else
                        txtCURRENTINSTOCK.Text = 0
                    End If
                    Session("CurrentInStock") = txtCURRENTINSTOCK.Text
                    If Not IsDBNull(_Datatble.Rows(0)("LAST_IN_DATE")) Then
                        txtlastindate.Text = _Datatble.Rows(0)("LAST_IN_DATE")
                        txtlastindate.ReadOnly = True
                        txtlastindate.BackColor = System.Drawing.Color.AliceBlue
                    End If
                    If Not IsDBNull(_Datatble.Rows(0)("LAST_OUT_DATE")) Then
                        txtLASTOUTDATE.Text = _Datatble.Rows(0)("LAST_OUT_DATE")
                        txtLASTOUTDATE.ReadOnly = True
                        txtLASTOUTDATE.BackColor = System.Drawing.Color.AliceBlue
                    End If
                    If Not IsDBNull(_Datatble.Rows(0)("PART_TAX")) Then
                        txtParttax.Text = _Datatble.Rows(0)("PART_TAX")
                        'txtLASTOUTDATE.ReadOnly = True
                        'txtLASTOUTDATE.BackColor = System.Drawing.Color.AliceBlue
                    End If
                    ButtonVisible()
                End If
            End If

        End If

    End Sub

    Public Sub ButtonVisible()
        Edit.Visible = True
        btnAddNew.Visible = False
        CurrentInStock.Visible = True
        LastInDate.Visible = True
        LastOutDate.Visible = True
        Header.Text = "Edit - ACC Parts Management (Inventory)"
    End Sub

    Public Sub ClearTextbox()
        txtpartno.Text = ""
        txtUPCEAN.Text = ""
        txtDescription.Text = ""
        txtSAPDESCRIPTION.Text = ""
        txtPURCHASEPRICE.Text = ""
        txtsalesPrice.Text = ""
        txtCURRENTINSTOCK.Text = ""
        txtlastindate.Text = ""
        txtParttax.Text = ""
        txtLASTOUTDATE.Text = ""
        txtpartno.Text = ""
        txtComments.Text = ""
        Header.Text = "Create New - ACC Parts Management (Inventory)"
        Edit.Visible = False
        CurrentInStock.Visible = False
        LastInDate.Visible = False
        LastOutDate.Visible = False
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim _ApplePartsStock As New ApplePartsStockModel
        Dim _ApplePartsStockcontrol As New ApplePartsStockControl

        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")

        _ApplePartsStock.PART_NO = txtpartno.Text
        _ApplePartsStock.UPC_EAN = txtUPCEAN.Text
        _ApplePartsStock.DESCRIPTION = txtDescription.Text
        _ApplePartsStock.SAP_PART_DESCRIPTION = txtSAPDESCRIPTION.Text
        _ApplePartsStock.PURCHASE_PRICE = txtPURCHASEPRICE.Text
        _ApplePartsStock.SALES_PRICE = txtsalesPrice.Text
        _ApplePartsStock.PART_TAX = txtParttax.Text
        '_ApplePartsStock.LAST_IN_DATE = txtlastindate.Text
        '_ApplePartsStock.LAST_OUT_DATE = txtLASTOUTDATE.Text
        _ApplePartsStock.SHIP_TO_BRANCH = ShipName
        _ApplePartsStock.SHIP_TO_BRANCH_CODE = shipCode
        'SetupNewServiceCenterModel.CRTCD = Session("user_Name")
        _ApplePartsStock.UPDCD = userName
        _ApplePartsStock.UPDPG = "ApplePartsEntryControl.vb"

        Dim dt As DataTable = _ApplePartsStockcontrol.PartNoExist(_ApplePartsStock)
        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then

            Dim Insert As Boolean = _ApplePartsStockcontrol.PartsInsert(_ApplePartsStock)
            If (Insert = True) Then
                Call showMsg(txtpartno.Text & " has been successfully Created", "")
                ClearTextbox()
            Else
                Call showMsg("Insert failed", "")
                Exit Sub
            End If
        Else
            Call showMsg("Parts already exists ", "")
        End If

    End Sub

    Private Sub Edit_Click(sender As Object, e As EventArgs) Handles Edit.Click
        Dim _ApplePartsStock As New ApplePartsStockModel
        Dim _ApplePartsStockcontrol As New ApplePartsStockControl

        _ApplePartsStock.PART_NO = txtpartno.Text
        _ApplePartsStock.UPC_EAN = txtUPCEAN.Text
        _ApplePartsStock.DESCRIPTION = txtDescription.Text
        _ApplePartsStock.SAP_PART_DESCRIPTION = txtSAPDESCRIPTION.Text
        _ApplePartsStock.PURCHASE_PRICE = txtPURCHASEPRICE.Text
        _ApplePartsStock.SALES_PRICE = txtsalesPrice.Text
        _ApplePartsStock.CURRENT_IN_STOCK = txtCURRENTINSTOCK.Text
        _ApplePartsStock.LAST_IN_DATE = txtlastindate.Text
        _ApplePartsStock.LAST_OUT_DATE = txtLASTOUTDATE.Text
        _ApplePartsStock.PART_TAX = txtParttax.Text
        _ApplePartsStock.ACTUAL_STOCK = Session("CurrentInStock")
        _ApplePartsStock.Comments = txtComments.Text
        _ApplePartsStock.SHIP_TO_BRANCH = Session("ship_Name")
        _ApplePartsStock.SHIP_TO_BRANCH_CODE = Session("ship_code")
        'SetupNewServiceCenterModel.CRTCD = Session("user_Name")
        _ApplePartsStock.UPDCD = Session("user_Name")
        _ApplePartsStock.UPDPG = "ApplePartsEntryControl.vb"
        If txtCURRENTINSTOCK.Text = "0" Then
            Call showMsg("Stock Must greate then zero ", "")
            Exit Sub
        End If

        If Session("CurrentInStock") <> Trim(txtCURRENTINSTOCK.Text) Then
            If String.IsNullOrEmpty(txtComments.Text) Then
                Call showMsg("You are trying change the stock, please provide necessary comments ", "")
                Exit Sub
            End If
        End If

        Dim Insert As Boolean = _ApplePartsStockcontrol.InsertStockComments(_ApplePartsStock)

        If (Insert = True) Then
            Dim updated As Boolean = _ApplePartsStockcontrol.UpdateParts(_ApplePartsStock)
            If (updated = True) Then
                Call showMsg(txtpartno.Text & " has been successfully Updated", "")

            Else
                Call showMsg("updated failed", "")
                Exit Sub
            End If
        Else
            Call showMsg("Insert Failed Stock", "")
            Exit Sub
        End If


    End Sub
    Protected Sub showMsg(ByVal Msg As String, ByVal msgChk As String)

        lblMsg.Text = Msg
        Dim sScript As String

        If msgChk = "CancelMsg" Then
            'OKとキャンセルボタン
            sScript = "$(Function () {$(""#dialog"" ).dialog({width: 400,buttons:{""OK"": function () {$(this).dialog('close');$('[id$=""BtnOK""]').click();},""CANCEL"": function () {$(this).dialog('close');$('[id$=""BtnCancel""]').click();}}});});"
        Else
            'OKボタンのみ
            sScript = "$(function () { $( ""#dialog"" ).dialog({width: 400, buttons: {""OK"": function () {$(this).dialog('close');}}});});"
        End If

        'JavaScriptの埋め込み
        ClientScript.RegisterStartupScript(Me.GetType(), "startup", sScript, True)

    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Response.Redirect("Apple_parts_Stock.aspx")
    End Sub
End Class