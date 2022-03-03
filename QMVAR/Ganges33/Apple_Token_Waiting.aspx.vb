
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Imports System.Drawing
Public Class Apple_Token_Waiting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            '***セッションなしログインユーザの対応***            Dim userid As String = Session("user_id")
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If
            'Verify Valid User to use this page 
            'Dim adminFlg As Boolean = Session("admin_Flg")
            'If adminFlg = False Then
            '    Response.Redirect("Login.aspx")
            'End If

            GridViewBind()
        End If

    End Sub
    Private Sub gvPart_PageIndexChanged(sender As Object, e As EventArgs) Handles gvPart.PageIndexChanged

    End Sub


    Protected Sub gvPart_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        gvPart.PageIndex = e.NewPageIndex
        GridViewBind()
    End Sub

    Protected Sub gvPart_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gvPart.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lnkEdit As Button = e.Row.FindControl("btnAction")
            Dim lblStatus As Label = e.Row.FindControl("lblStatus")
            Dim lnkPause As ImageButton = e.Row.FindControl("btnPause")

            Dim lblTokenType As Label = e.Row.FindControl("lblTokenType")

            'Dim lblCRTDT As Label = e.Row.FindControl("lblCRTDT")
            'Dim lblPoNo As Label = e.Row.FindControl("lblPoNo")

            'If lblStatus.Text = "Waiting" Then

            Select Case lblStatus.Text
                Case ""
                    lnkEdit.Text = "     "
                Case "NotStarted"
                    lnkEdit.Text = "     "
                Case "START"
                    lnkEdit.Text = "START"
                    lnkEdit.Attributes.Add("style", "background-color:Green;")
                    lnkPause.Visible = False
                Case "END"
                    lnkEdit.Text = "END"
                    lnkEdit.Attributes.Add("style", "background-color:Orange;")
                Case "PAUSE"
                    lnkEdit.Text = "RESUME"
                    lnkEdit.Attributes.Add("style", "background-color:Purple;")
                    lnkPause.Visible = False

            End Select

            If Trim(lblTokenType.Text) = "2" Then
                Dim ColCount As Integer = 1
                For Each cell As TableCell In e.Row.Cells
                    If ColCount <= 3 Then
                        cell.BackColor = Color.Yellow
                    End If
                    ColCount = ColCount + 1
                Next
                'lblCRTDT.Attributes.Add("style", "background-color:yellow;")
                'lblPoNo.Attributes.Add("style", "background-color:yellow;")
            End If


            'End If



        End If
    End Sub

    Protected Sub gvPart_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim _AppleRcptModel As AppleRcptModel = New AppleRcptModel()
        Dim _AppleRcptControl As AppleRcptControl = New AppleRcptControl()
        'Determine the RowIndex of the Row whose Button was clicked.
        'Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
        Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument) Mod gvPart.PageSize
        'Reference the GridView Row.
        Dim row As GridViewRow = gvPart.Rows(rowIndex)
        'Fetch value of Name.
        'Dim name As String = TryCast(row.FindControl("lblPoNo"), Label).Text
        'Fetch value of Country.
        'Dim country As String = row.Cells(1).Text
        'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Name: " & name & "\nCountry: " & country + "');", True)
        Dim UNQ_NO As String = TryCast(row.FindControl("lblUNQ_NO"), Label).Text
        Dim lblStatus As String = TryCast(row.FindControl("lblStatus"), Label).Text


        If e.CommandName = "Select" Then
            _AppleRcptModel.STATUS = "END"
            Select Case UCase(lblStatus)
                Case "START"
                    _AppleRcptModel.START_DATETIME = Now
                Case "END"
                    _AppleRcptModel.END_DATETIIME = Now
                    _AppleRcptModel.STATUS = "COMPLETED"
            End Select


        ElseIf e.CommandName = "Close" Then
            _AppleRcptModel.END_DATETIIME = Now
            _AppleRcptModel.STATUS = "COMPLETED"
            _AppleRcptModel.COMMENTS = "Closed"
        ElseIf e.CommandName = "Pause" Then
            _AppleRcptModel.END_DATETIIME = Now
            _AppleRcptModel.STATUS = "PAUSE"
            _AppleRcptModel.COMMENTS = "Pause"
        End If

        _AppleRcptModel.UNQ_NO = UNQ_NO
        Dim dtStatus As Boolean = _AppleRcptControl.UpdateStatus(_AppleRcptModel)
        If dtStatus Then

            If UCase(lblStatus) = "START" Then
                Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
                Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
                Dim ShipName As String = Session("ship_Name")
                Dim shipCode As String = Session("ship_code")
                Dim userName As String = Session("user_Name")
                Dim userid As String = Session("user_id")

                _AppleQmvOrdModel.UserId = userid
                _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode
                _AppleQmvOrdModel.SHIP_TO_BRANCH = ShipName
                Dim lblText As String = TryCast(row.FindControl("lblPoNo"), Label).Text
                _AppleQmvOrdModel.PO_NO = lblText

                Dim PoDate As String = ""
                PoDate = _AppleQmvOrdControl.SelectPoDate(_AppleQmvOrdModel)
                _AppleQmvOrdModel.PO_DATE = PoDate

                lblText = TryCast(row.FindControl("lblName"), Label).Text
                _AppleQmvOrdModel.CUSTOMER_NAME = lblText

                lblText = TryCast(row.FindControl("lblMobile"), Label).Text
                _AppleQmvOrdModel.MOBLIE_PHONE = lblText

                lblText = TryCast(row.FindControl("lblPartsType"), Label).Text
                _AppleQmvOrdModel.PRODUCT_NAME = lblText
                Dim blStatus As Boolean = False
                blStatus = _AppleQmvOrdControl.AddQmvOrd(_AppleQmvOrdModel)
                If blStatus Then
                    Response.Redirect("Apple_Customer_Information.aspx?PoNo=" & _AppleQmvOrdModel.PO_NO)
                Else
                    Call showMsg("Error!!! Customer Updation...", "")
                End If

            Else
                Call showMsg("Successfully updated", "")
                GridViewBind()
                Exit Sub
            End If





        End If








    End Sub



    Protected Sub GridViewBind(ByVal Optional Location As String = "")


        Dim _AppleRcptModel As AppleRcptModel = New AppleRcptModel()
        Dim _AppleRcptControl As AppleRcptControl = New AppleRcptControl()

        '_AppleRcptModel.PO_NO = Trim(txtPoNo.Text)
        '_AppleRcptModel.NAME = Trim(txtName.Text)

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
        ' _AppleRcptModel.CRTDT = "2021/05/03"


        Dim dtAppleRcpt As DataTable = _AppleRcptControl.SelectWaiting(_AppleRcptModel)

        lblCount.Text = dtAppleRcpt.Rows.Count
        gvPart.DataSource = dtAppleRcpt
        gvPart.DataBind()

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

    'Cannot insert duplicate key row in object 'dbo.AP_PARTS' with unique index 'NonClusteredIndex-20210419-230730'. The duplicate key value is (111, ProductName1, partno1, PartsType1, Exchange Price).The statement has been terminated.
End Class