Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Imports System
Imports System.Collections
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.Collections.Specialized


Public Class Apple_Parts_Entry
    Inherits System.Web.UI.Page
    Dim clsSet As New Class_money
    Dim isClicked As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            Dim setShipname As String = Session("ship_Name")
            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If
            Dim InvNo As String = ""
            InvNo = Request.QueryString("ino")
            If Len(InvNo) > 2 Then
                lblInventoryNo.Text = Request.QueryString("ino")
                lblInfoInvNo.Text = "&nbsp;&nbsp;Inventory No: " & lblInventoryNo.Text
                lblInfoInvNo.Visible = True
                LoadDefaultParts()
            Else
                Dim dDate As DateTime = Date.Today
                txtDate.Text = dDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture)
                setinitialrow()
            End If
        End If
    End Sub

    Private Sub LoadDefaultParts()
        Dim _ApplePartsInventoryModel As ApplePartsInventoryModel = New ApplePartsInventoryModel()
        _ApplePartsInventoryModel.INVENTORY_NO = lblInventoryNo.Text
        Dim _ApplePartsEntryControl As ApplePartsEntryControl = New ApplePartsEntryControl()
        Dim _dtApplePartsEntry As DataTable = _ApplePartsEntryControl.SelectInventery(_ApplePartsInventoryModel)
        If _dtApplePartsEntry.Rows.Count <> 0 Then
            If Not IsDBNull(_dtApplePartsEntry.Rows(0)("INVENTORY_DATE")) Then
                'Dim parts_no As TextBox = dt.Rows(0)("PARTS_NO")
                txtDate.Text = _dtApplePartsEntry.Rows(0)("INVENTORY_DATE")
                'box2.ReadOnly = True
            End If
        End If
        ViewState("CurrentTable") = _dtApplePartsEntry

        Gridview1.DataSource = _dtApplePartsEntry
        Gridview1.DataBind()
    End Sub
    Private Sub setinitialrow()

        Dim dt As DataTable = New DataTable()
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("rownumber", GetType(String)))
        dt.Columns.Add(New DataColumn("PART_NO", GetType(String)))
        dt.Columns.Add(New DataColumn("UPC_EAN", GetType(String)))
        dt.Columns.Add(New DataColumn("DESCRIPTION", GetType(String)))
        dt.Columns.Add(New DataColumn("IN_STOCK", GetType(String)))
        dt.Columns.Add(New DataColumn("BALANCE", GetType(String)))
        dt.Columns.Add(New DataColumn("PURCHASE_PRICE", GetType(String)))
        dt.Columns.Add(New DataColumn("SALES_PRICE", GetType(String)))
        dt.Columns.Add(New DataColumn("PART_TAX", GetType(String)))

        dr = dt.NewRow()
        dr("rownumber") = 1
        dr("PART_NO") = String.Empty
        dr("UPC_EAN") = String.Empty
        dr("DESCRIPTION") = String.Empty
        dr("IN_STOCK") = String.Empty
        dr("BALANCE") = String.Empty
        dr("PURCHASE_PRICE") = String.Empty
        dr("SALES_PRICE") = String.Empty
        dr("PART_TAX") = String.Empty

        dt.Rows.Add(dr)
        ViewState("CurrentTable") = dt
        Gridview1.DataSource = dt
        Gridview1.DataBind()
        'Gridview1.ColumnCount = 5
    End Sub

    Private Sub AddNewRowToGrid()
        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = CType(ViewState("CurrentTable"), DataTable)
            Dim drCurrentRow As DataRow = Nothing

            If dtCurrentTable.Rows.Count > 0 Then
                drCurrentRow = dtCurrentTable.NewRow()
                drCurrentRow("RowNumber") = dtCurrentTable.Rows.Count + 1
                dtCurrentTable.Rows.Add(drCurrentRow)
                ViewState("CurrentTable") = dtCurrentTable

                For i As Integer = 0 To dtCurrentTable.Rows.Count - 1 - 1
                    Dim box1 As TextBox = CType(Gridview1.Rows(i).Cells(1).FindControl("TextBox1"), TextBox)
                    Dim box2 As TextBox = CType(Gridview1.Rows(i).Cells(2).FindControl("TextBox2"), TextBox)
                    Dim box3 As TextBox = CType(Gridview1.Rows(i).Cells(3).FindControl("TextBox3"), TextBox)
                    Dim box4 As TextBox = CType(Gridview1.Rows(i).Cells(4).FindControl("TextBox4"), TextBox)
                    Dim box5 As TextBox = CType(Gridview1.Rows(i).Cells(5).FindControl("TextBox5"), TextBox)
                    Dim box6 As TextBox = CType(Gridview1.Rows(i).Cells(6).FindControl("TextBox6"), TextBox)
                    Dim box7 As TextBox = CType(Gridview1.Rows(i).Cells(7).FindControl("TextBox7"), TextBox)
                    Dim box8 As TextBox = CType(Gridview1.Rows(i).Cells(8).FindControl("TextBox8"), TextBox)

                    dtCurrentTable.Rows(i)("PART_NO") = box1.Text
                    dtCurrentTable.Rows(i)("UPC_EAN") = box2.Text
                    dtCurrentTable.Rows(i)("DESCRIPTION") = box3.Text
                    dtCurrentTable.Rows(i)("IN_STOCK") = box4.Text
                    dtCurrentTable.Rows(i)("BALANCE") = box5.Text
                    dtCurrentTable.Rows(i)("PURCHASE_PRICE") = box6.Text
                    dtCurrentTable.Rows(i)("SALES_PRICE") = box7.Text
                    dtCurrentTable.Rows(i)("PART_TAX") = box8.Text

                Next

                Gridview1.DataSource = dtCurrentTable
                Gridview1.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If

        SetPreviousData()

    End Sub

    Private Sub SetPreviousData()
        Dim rowIndex As Integer = 0

        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dt As DataTable = CType(ViewState("CurrentTable"), DataTable)

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim box1 As TextBox = CType(Gridview1.Rows(i).Cells(1).FindControl("TextBox1"), TextBox)
                    Dim box2 As TextBox = CType(Gridview1.Rows(i).Cells(2).FindControl("TextBox2"), TextBox)
                    Dim box3 As TextBox = CType(Gridview1.Rows(i).Cells(3).FindControl("TextBox3"), TextBox)
                    Dim box4 As TextBox = CType(Gridview1.Rows(i).Cells(4).FindControl("TextBox4"), TextBox)
                    Dim box5 As TextBox = CType(Gridview1.Rows(i).Cells(5).FindControl("TextBox5"), TextBox)
                    Dim box6 As TextBox = CType(Gridview1.Rows(i).Cells(6).FindControl("TextBox6"), TextBox)
                    Dim box7 As TextBox = CType(Gridview1.Rows(i).Cells(7).FindControl("TextBox7"), TextBox)
                    Dim box8 As TextBox = CType(Gridview1.Rows(i).Cells(8).FindControl("TextBox8"), TextBox)

                    If i < dt.Rows.Count - 1 Then
                        box1.Text = dt.Rows(i)("PART_NO").ToString()
                        box2.Text = dt.Rows(i)("UPC_EAN").ToString()
                        box3.Text = dt.Rows(i)("DESCRIPTION").ToString()
                        box4.Text = dt.Rows(i)("IN_STOCK").ToString()
                        box5.Text = dt.Rows(i)("BALANCE").ToString()
                        box6.Text = dt.Rows(i)("PURCHASE_PRICE").ToString()
                        box7.Text = dt.Rows(i)("SALES_PRICE").ToString()
                        box8.Text = dt.Rows(i)("PART_TAX").ToString()
                    End If

                    rowIndex += 1
                Next
            End If
        End If
    End Sub



    Protected Sub ButtonAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        AddNewRowToGrid()
    End Sub

    Protected Sub Gridview1_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dt As DataTable = CType(ViewState("CurrentTable"), DataTable)
            Dim lb As LinkButton = CType(e.Row.FindControl("LinkButton1"), LinkButton)

            If lb IsNot Nothing Then

                If dt.Rows.Count > 1 Then

                    If e.Row.RowIndex = dt.Rows.Count - 1 Then
                        lb.Visible = True
                    End If
                Else
                    lb.Visible = False
                End If
            End If
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Comment by Mohan on 2021/12/17
        Dim lb As LinkButton = CType(sender, LinkButton)
        Dim gvRow As GridViewRow = CType(lb.NamingContainer, GridViewRow)
        Dim rowID As Integer = gvRow.RowIndex

        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dt As DataTable = CType(ViewState("CurrentTable"), DataTable)

            If dt.Rows.Count > 1 Then

                If Len(lblInventoryNo.Text) > 2 Then
                    Dim _ApplePartsEntryModel As ApplePartsEntryModel = New ApplePartsEntryModel()
                    _ApplePartsEntryModel.SR_NO = rowID
                    _ApplePartsEntryModel.INVENTORY_NO = lblInventoryNo.Text
                    Dim _ApplePartsEntryControl As ApplePartsEntryControl = New ApplePartsEntryControl()
                    Dim blStatus As Boolean = _ApplePartsEntryControl.DeletePartsRow(_ApplePartsEntryModel)

                    LoadDefaultParts()

                    Exit Sub
                End If
                'Change < now <= 
                If gvRow.RowIndex <= dt.Rows.Count - 1 Then
                    dt.Rows.Remove(dt.Rows(rowID))
                    ResetRowID(dt)
                End If
            End If

            ViewState("CurrentTable") = dt
            Gridview1.DataSource = dt
            Gridview1.DataBind()
        End If

        SetPreviousData()


        'Dim lb As LinkButton = CType(sender, LinkButton)
        'Dim gvRow As GridViewRow = CType(lb.NamingContainer, GridViewRow)
        'Dim rowID As Integer = gvRow.RowIndex
        'If ViewState("CurrentTable") IsNot Nothing Then
        '    Dim dt As DataTable = CType(ViewState("CurrentTable"), DataTable)
        '    If dt.Rows.Count > 1 Then
        '        If gvRow.RowIndex < dt.Rows.Count - 1 Then
        '            dt.Rows.Remove(dt.Rows(rowID))
        '        End If
        '    End If
        '    ViewState("CurrentTable") = dt
        '    Gridview1.DataSource = dt
        '    Gridview1.DataBind()
        'End If

        'SetPreviousData()






    End Sub

    Private Sub ResetRowID(ByVal dt As DataTable)
        Dim rowNumber As Integer = 1

        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                row(0) = rowNumber
                rowNumber += 1
            Next
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        AddModify("save")
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs)
        Call showMsg("The process has been aborted.", "")
        Exit Sub
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Call showMsg("The process has been aborted.", "")
        Exit Sub
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        Dim _ApplePartsEntryModel As ApplePartsEntryModel = New ApplePartsEntryModel()
        Dim row As GridViewRow = TryCast((TryCast(sender, TextBox)).NamingContainer, GridViewRow)
        Dim txtPartNo As TextBox = CType(row.FindControl("Textbox1"), TextBox)
        _ApplePartsEntryModel.PART_NO = txtPartNo.Text
        Dim _ApplePartsEntryControl As ApplePartsEntryControl = New ApplePartsEntryControl()
        Dim dt As DataTable = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
        Dim txtUpcEan As TextBox = CType(row.FindControl("Textbox2"), TextBox)
        Dim txtDescription As TextBox = CType(row.FindControl("Textbox3"), TextBox)
        Dim txtInStock As TextBox = CType(row.FindControl("Textbox4"), TextBox)
        Dim txtBalance As TextBox = CType(row.FindControl("Textbox5"), TextBox)
        Dim txtPruchasePrice As TextBox = CType(row.FindControl("Textbox6"), TextBox)
        Dim txtSalesPrice As TextBox = CType(row.FindControl("Textbox7"), TextBox)
        Dim txtPartTax As TextBox = CType(row.FindControl("Textbox8"), TextBox)

        If dt.Rows.Count > 0 Then

            If Not IsDBNull(dt.Rows(0)("UPC_EAN")) Then
                txtUpcEan.Text = dt.Rows(0)("UPC_EAN")
            End If

            If Not IsDBNull(dt.Rows(0)("DESCRIPTION")) Then
                txtDescription.Text = dt.Rows(0)("DESCRIPTION")
            End If

            'No Need, User Need to enter 
            'If Not IsDBNull(dt.Rows(0)("PARTS_DETAIL")) Then
            '    txtInStock.Text = dt.Rows(0)("PARTS_DETAIL")
            'End If

            If Not IsDBNull(dt.Rows(0)("BALANCE")) Then
                txtBalance.Text = dt.Rows(0)("BALANCE")
            Else
                txtBalance.Text = 0
            End If

            If Not IsDBNull(dt.Rows(0)("PURCHASE_PRICE")) Then
                txtPruchasePrice.Text = dt.Rows(0)("PURCHASE_PRICE")
            End If

            If Not IsDBNull(dt.Rows(0)("SALES_PRICE")) Then
                txtSalesPrice.Text = dt.Rows(0)("SALES_PRICE")
            End If
            If Not IsDBNull(dt.Rows(0)("PART_TAX")) Then
                txtPartTax.Text = dt.Rows(0)("PART_TAX")
            End If
        Else
            Call showMsg(txtPartNo.Text & "- Not Found!!! ", "")
            txtUpcEan.Text = ""
            txtDescription.Text = ""
            txtBalance.Text = ""
            txtPruchasePrice.Text = ""
            txtSalesPrice.Text = ""
            txtPartTax.Text = ""
        End If
    End Sub

    Protected Sub showMsg(ByVal Msg As String, ByVal msgChk As String)

        lblMsg.Text = Msg
        Dim sScript As String

        If msgChk = "CancelMsg" Then
            'OKとキャンセルボタン
            sScript = "$(function () {$(""#dialog"" ).dialog({width: 400,buttons:{""OK"": function () {$(this).dialog('close');$('[id$=""BtnOK""]').click();},""CANCEL"": function () {$(this).dialog('close');$('[id$=""BtnCancel""]').click();}}});});"
        ElseIf msgChk = "CancelMsg2" Then
            'OKとキャンセルボタン 
            sScript = "$(function () {$(""#dialog"" ).dialog({width: 400,buttons:{""OK"": function () {$(this).dialog('close');$('[id$=""Btn2OK""]').click();},""CANCEL"": function () {$(this).dialog('close');$('[id$=""BtnCancel""]').click();}}});});"
        Else
            'OKボタンのみ
            sScript = "$(function () { $( ""#dialog"" ).dialog({width: 400, buttons: {""OK"": function () {$(this).dialog('close');}}});});"
        End If

        'JavaScriptの埋め込み
        'ClientScript.RegisterStartupScript(Me.GetType(), "startup", sScript, True)
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "startup", sScript, True)

        ScriptManager.RegisterClientScriptBlock(updatepnl, Me.GetType(), "startup", sScript, True)
        'ScriptManager.RegisterClientScriptBlock(updatepnl, Me.GetType(), "", "alert('" & lblMsg.Text & "')", True)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Response.Redirect("Apple_parts_Grid.aspx")
        'Session("id") = "0"
    End Sub

    Protected Sub btncommit_Click1(sender As Object, e As EventArgs)
        AddModify("commit")
    End Sub

    Sub AddModify(TranFlg As String)
        '1st Validate 

        '2nd Generate InventoryNo
        Dim _ApplePartsInventoryModel As ApplePartsInventoryModel = New ApplePartsInventoryModel()
        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")
        Dim userid As String = Session("user_id")
        _ApplePartsInventoryModel.UserId = userid
        _ApplePartsInventoryModel.SHIP_TO_BRANCH_CODE = shipCode
        _ApplePartsInventoryModel.SHIP_TO_BRANCH = ShipName
        _ApplePartsInventoryModel.INVENTORY_DATE = txtDate.Text
        _ApplePartsInventoryModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress
        If lblInventoryNo.Text = "" Then
            Dim _ApplePartsInventoryControl As ApplePartsInventoryControl = New ApplePartsInventoryControl()
            Dim InventoryNo As String = _ApplePartsInventoryControl.SelectInventoryNo(_ApplePartsInventoryModel)
            If InventoryNo = "-1" Then
                Call showMsg("Inventory No - Internal Server Error, Contact System Administrator", "")
                Exit Sub
            Else
                lblInventoryNo.Text = InventoryNo
                _ApplePartsInventoryModel.INVENTORY_NO = InventoryNo
            End If
        Else
            _ApplePartsInventoryModel.INVENTORY_NO = lblInventoryNo.Text
        End If

        '3rd Add Parts Values and update to database 
        Dim rowIndex As Integer = 0
        Dim IsPartsRec As Boolean = False
        Dim _ApplePartsEntryModel As List(Of ApplePartsEntryModel) = New List(Of ApplePartsEntryModel)()
        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = CType(ViewState("CurrentTable"), DataTable)
            If dtCurrentTable.Rows.Count > 0 Then
                IsPartsRec = True
                For i As Integer = 0 To dtCurrentTable.Rows.Count - 1
                    Dim _ApplePartsEntryModelTmp As ApplePartsEntryModel = New ApplePartsEntryModel()
                    Dim txtPartNo As TextBox = CType(Gridview1.Rows(i).Cells(1).FindControl("TextBox1"), TextBox)
                    Dim txtUpcEan As TextBox = CType(Gridview1.Rows(i).Cells(2).FindControl("TextBox2"), TextBox)
                    Dim txtDescription As TextBox = CType(Gridview1.Rows(i).Cells(3).FindControl("TextBox3"), TextBox)
                    Dim txtInStock As TextBox = CType(Gridview1.Rows(i).Cells(4).FindControl("TextBox4"), TextBox)
                    Dim txtBalance As TextBox = CType(Gridview1.Rows(i).Cells(5).FindControl("TextBox5"), TextBox)
                    Dim txtPruchasePrice As TextBox = CType(Gridview1.Rows(i).Cells(6).FindControl("TextBox6"), TextBox)
                    Dim txtSalesPrice As TextBox = CType(Gridview1.Rows(i).Cells(7).FindControl("TextBox7"), TextBox)
                    Dim txtPartTax As TextBox = CType(Gridview1.Rows(i).Cells(8).FindControl("TextBox8"), TextBox)

                    _ApplePartsEntryModelTmp.SR_NO = i.ToString
                    _ApplePartsEntryModelTmp.PART_NO = txtPartNo.Text
                    _ApplePartsEntryModelTmp.UPC_EAN = txtUpcEan.Text
                    _ApplePartsEntryModelTmp.DESCRIPTION = txtDescription.Text
                    _ApplePartsEntryModelTmp.IN_STOCK = txtInStock.Text
                    _ApplePartsEntryModelTmp.BALANCE = txtBalance.Text
                    _ApplePartsEntryModelTmp.PURCHASE_PRICE = txtPruchasePrice.Text
                    _ApplePartsEntryModelTmp.SALES_PRICE = txtSalesPrice.Text
                    _ApplePartsEntryModelTmp.PART_TAX = txtPartTax.Text


                    _ApplePartsEntryModel.Add(_ApplePartsEntryModelTmp)
                Next
            End If
        End If

        If IsPartsRec Then
            Dim _ApplePartsEntryControl As ApplePartsEntryControl = New ApplePartsEntryControl()
            Dim blStatus As Boolean = _ApplePartsEntryControl.AddPartsEntry(_ApplePartsEntryModel, _ApplePartsInventoryModel, TranFlg)
            ' Dm blStatus As Boolean = _PrSummaryControl.AddModifyPrSummary(strArr, _PrSummaryModel)
            'If Error Raised then show the errors 
            If Not blStatus Then
                Call showMsg("Status: Save Failed   Please check Parts Entry ", "")
                Exit Sub
            Else
                Call showMsg("Parts Items are Saved(" & lblInventoryNo.Text & ")", "")
                If TranFlg = "commit" Then
                    ClearTextbox()
                    setinitialrow()
                End If
            End If
                Else
            Call showMsg("No Parts Item Found To Save...", "")
        End If

    End Sub
    Sub ClearTextbox()
        For Each row As GridViewRow In Gridview1.Rows
            CType(row.FindControl("Textbox1"), TextBox).Text = ""
            CType(row.FindControl("TextBox2"), TextBox).Text = ""
            CType(row.FindControl("TextBox3"), TextBox).Text = ""
            CType(row.FindControl("TextBox4"), TextBox).Text = ""
            CType(row.FindControl("TextBox5"), TextBox).Text = ""
            CType(row.FindControl("TextBox6"), TextBox).Text = ""
            CType(row.FindControl("TextBox7"), TextBox).Text = ""
            CType(row.FindControl("TextBox8"), TextBox).Text = ""
        Next
    End Sub
End Class