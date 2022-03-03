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

Public Class Apple_App_Parts_Entry
    Inherits System.Web.UI.Page
    Dim clsSet As New Class_money
    Dim isClicked As Boolean = False
    'bool  = False;
    Dim ifExist As Boolean = False
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
    Private Function GetDummyData() As ArrayList
            Dim arr As ArrayList = New ArrayList()
            arr.Add(New ListItem("Y", "1"))
            arr.Add(New ListItem("N", "2"))
        'arr.Add(New ListItem("Item3", "3"))
        Return arr
    End Function

        Private Sub FillDropDownList(ByVal ddl As DropDownList)
        Dim arr As ArrayList = GetDummyData()
        For Each item As ListItem In arr
                ddl.Items.Add(item)
            Next
        End Sub
    ' End Class 

    Private Sub LoadDefaultParts()
        Dim _AppleAppPartsInventoryModel As AppleAppPartsInventoryModel = New AppleAppPartsInventoryModel()
        Dim PartType As String = Nothing
        PartType = Session("PartsType")
        _AppleAppPartsInventoryModel.INVENTORY_NO = lblInventoryNo.Text
        _AppleAppPartsInventoryModel.PARTS_TYPE = PartType
        Dim _AppleAppPartsEntryControl As AppleAppPartsEntryControl = New AppleAppPartsEntryControl()
        Dim _dtApplePartsEntry As DataTable = _AppleAppPartsEntryControl.SelectInventery(_AppleAppPartsInventoryModel)
        If _dtApplePartsEntry.Rows.Count <> 0 Then
            If Not IsDBNull(_dtApplePartsEntry.Rows(0)("INVENTORY_DATE")) Then
                txtDate.Text = _dtApplePartsEntry.Rows(0)("INVENTORY_DATE")
                'box2.ReadOnly = True
            End If
        End If
        ViewState("CurrentTable") = _dtApplePartsEntry
        Gridview1.DataSource = _dtApplePartsEntry
        Gridview1.DataBind()
        SetDropDown1(_dtApplePartsEntry)
        DropDownStockType()
    End Sub

    Private Sub DropDownStockType()
        drpStockType.ClearSelection()
        If Session("PartsType") = "Consignment" Then
            drpStockType.Items.FindByValue("1").Selected = True
        Else
            drpStockType.Items.FindByValue("2").Selected = True
        End If
    End Sub

    Private Sub SetDropDown1(dt As DataTable)
        Dim rowIndex As Integer = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim ddl1 As DropDownList = CType(Gridview1.Rows(i).Cells(8).FindControl("DropDownList1"), DropDownList)
                FillDropDownList(ddl1)
                If i <= dt.Rows.Count - 1 Then
                    ddl1.ClearSelection()                        '
                    If ddl1.Items.FindByText(dt.Rows(i)("SERIAL_TYPE").ToString()) IsNot Nothing Then
                        ddl1.Items.FindByText(dt.Rows(i)("SERIAL_TYPE").ToString()).Selected = True
                    End If
                End If
                rowIndex += 1
            Next
        End If

    End Sub

    Private Sub setinitialrow()

        Dim dt As DataTable = New DataTable()
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("rownumber", GetType(String)))
        dt.Columns.Add(New DataColumn("PARTS_NO", GetType(String)))
        dt.Columns.Add(New DataColumn("PARTS_NAME", GetType(String)))
        dt.Columns.Add(New DataColumn("PARTS_DESCRIPTION", GetType(String)))
        dt.Columns.Add(New DataColumn("PARTS_TYPE", GetType(String)))
        dt.Columns.Add(New DataColumn("PURCHASE_COST", GetType(String)))
        dt.Columns.Add(New DataColumn("TIER", GetType(String)))
        dt.Columns.Add(New DataColumn("EEE_EEEE", GetType(String)))
        dt.Columns.Add(New DataColumn("SERIAL_TYPE", GetType(String)))
        dt.Columns.Add(New DataColumn("SERIAL_NO", GetType(String)))
        dt.Columns.Add(New DataColumn("IN_STOCK", GetType(String)))
        dt.Columns.Add(New DataColumn("BALANCE", GetType(String)))

        dr = dt.NewRow()
        dr("rownumber") = 1
        dr("PARTS_NO") = String.Empty
        dr("PARTS_NAME") = String.Empty
        dr("PARTS_DESCRIPTION") = String.Empty
        dr("PARTS_TYPE") = String.Empty
        dr("PURCHASE_COST") = String.Empty
        dr("TIER") = String.Empty
        dr("EEE_EEEE") = String.Empty
        dr("SERIAL_TYPE") = String.Empty
        dr("SERIAL_NO") = String.Empty
        dr("IN_STOCK") = String.Empty
        dr("BALANCE") = String.Empty
        dt.Rows.Add(dr)
        ViewState("CurrentTable") = dt
        Gridview1.DataSource = dt
        Gridview1.DataBind()
        'Gridview1.ColumnCount = 5

        Dim ddl1 As DropDownList = CType(Gridview1.Rows(0).Cells(8).FindControl("DropDownList1"), DropDownList)
        FillDropDownList(ddl1)
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
                    Dim ddl1 As DropDownList = CType(Gridview1.Rows(i).Cells(8).FindControl("DropDownList1"), DropDownList)
                    'Dim box8 As TextBox = CType(Gridview1.Rows(i).Cells(8).FindControl("TextBox8"), TextBox)
                    Dim box9 As TextBox = CType(Gridview1.Rows(i).Cells(9).FindControl("TextBox9"), TextBox)
                    Dim box10 As TextBox = CType(Gridview1.Rows(i).Cells(10).FindControl("TextBox10"), TextBox)
                    Dim box11 As TextBox = CType(Gridview1.Rows(i).Cells(11).FindControl("TextBox11"), TextBox)
                    dtCurrentTable.Rows(i)("PARTS_NO") = box1.Text
                    dtCurrentTable.Rows(i)("PARTS_NAME") = box2.Text
                    dtCurrentTable.Rows(i)("PARTS_DESCRIPTION") = box3.Text
                    dtCurrentTable.Rows(i)("PARTS_TYPE") = box4.Text
                    dtCurrentTable.Rows(i)("PURCHASE_COST") = box5.Text
                    dtCurrentTable.Rows(i)("TIER") = box6.Text
                    dtCurrentTable.Rows(i)("EEE_EEEE") = box7.Text
                    dtCurrentTable.Rows(i)("SERIAL_TYPE") = ddl1.SelectedItem.Text
                    'dtCurrentTable.Rows(i)("SERIAL") = box8.Text
                    dtCurrentTable.Rows(i)("SERIAL_NO") = box9.Text
                    dtCurrentTable.Rows(i)("IN_STOCK") = box10.Text
                    dtCurrentTable.Rows(i)("BALANCE") = box11.Text
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
                    'Dim box8 As TextBox = CType(Gridview1.Rows(i).Cells(8).FindControl("TextBox8"), TextBox)
                    Dim ddl1 As DropDownList = CType(Gridview1.Rows(i).Cells(8).FindControl("DropDownList1"), DropDownList)
                    Dim box9 As TextBox = CType(Gridview1.Rows(i).Cells(9).FindControl("TextBox9"), TextBox)
                    Dim box10 As TextBox = CType(Gridview1.Rows(i).Cells(10).FindControl("TextBox10"), TextBox)
                    Dim box11 As TextBox = CType(Gridview1.Rows(i).Cells(11).FindControl("TextBox11"), TextBox)

                    FillDropDownList(ddl1)
                    'change < now <=
                    If i <= dt.Rows.Count - 1 Then
                        box1.Text = dt.Rows(i)("PARTS_NO").ToString()
                        box2.Text = dt.Rows(i)("PARTS_NAME").ToString()
                        box3.Text = dt.Rows(i)("PARTS_DESCRIPTION").ToString()
                        box4.Text = dt.Rows(i)("PARTS_TYPE").ToString()
                        box5.Text = dt.Rows(i)("PURCHASE_COST").ToString()
                        box6.Text = dt.Rows(i)("TIER").ToString()
                        box7.Text = dt.Rows(i)("EEE_EEEE").ToString()
                        'box8.Text = dt.Rows(i)("SERIAL").ToString()
                        ddl1.ClearSelection()                        '
                        If ddl1.Items.FindByText(dt.Rows(i)("SERIAL_TYPE").ToString()) IsNot Nothing Then
                            ddl1.Items.FindByText(dt.Rows(i)("SERIAL_TYPE").ToString()).Selected = True
                            If ddl1.Items.FindByText(dt.Rows(i)("SERIAL_TYPE").ToString()).Value = 1 Then 'yes
                                'box9.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6ffff")
                                box10.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6ffff")
                                box11.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6ffff")
                                box11.Enabled = False
                                box10.Enabled = False
                            ElseIf ddl1.Items.FindByText(dt.Rows(i)("SERIAL_TYPE").ToString()).Value = 2 Then
                                box9.Enabled = False
                                box9.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6ffff")
                                box10.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
                                box10.Enabled = True
                            Else
                                box11.Enabled = True
                                box10.Enabled = True
                                box10.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
                                box11.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
                            End If
                        End If
                        box9.Text = dt.Rows(i)("SERIAL_NO").ToString()
                        box10.Text = dt.Rows(i)("IN_STOCK").ToString()
                        box11.Text = dt.Rows(i)("BALANCE").ToString()
                        'SerialType(ddl1.Items.FindByText(dt.Rows(i)("SERIAL_TYPE").ToString())
                    End If

                    rowIndex += 1
                Next
            End If
        End If
    End Sub

    Private Sub SerialType(Drop As DropDownList)
        drpStockType.ClearSelection()
        If Session("PartsType") = "Consignment" Then
            drpStockType.Items.FindByValue("1").Selected = True
        Else
            drpStockType.Items.FindByValue("2").Selected = True
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
                    Dim _AppleAppPartsEntryModel As AppleAppPartsEntryModel = New AppleAppPartsEntryModel()
                    _AppleAppPartsEntryModel.SR_NO = rowID
                    _AppleAppPartsEntryModel.INVENTORY_NO = lblInventoryNo.Text
                    _AppleAppPartsEntryModel.PARTS_TYPE = Session("PartsType")
                    Dim _AppleAppPartsEntryControl As AppleAppPartsEntryControl = New AppleAppPartsEntryControl()
                    Dim blStatus As Boolean = _AppleAppPartsEntryControl.DeletePartsRow(_AppleAppPartsEntryModel)

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
        AddModify("save", drpStockType.SelectedItem.Text)
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
        Dim _AppleAppPartsEntryModel As AppleAppPartsEntryModel = New AppleAppPartsEntryModel()
        Dim row As GridViewRow = TryCast((TryCast(sender, TextBox)).NamingContainer, GridViewRow)
        Dim txtPartsNo As TextBox = CType(row.FindControl("Textbox1"), TextBox)
        _AppleAppPartsEntryModel.PARTS_NO = txtPartsNo.Text
        Dim _AppleAppPartsEntryControl As AppleAppPartsEntryControl = New AppleAppPartsEntryControl()
        Dim dt As DataTable
        Dim txtPartsName As TextBox = CType(row.FindControl("Textbox2"), TextBox)
        Dim txtPartsDescription As TextBox = CType(row.FindControl("Textbox3"), TextBox)
        Dim txtPartsType As TextBox = CType(row.FindControl("Textbox4"), TextBox)
        Dim txtPartsCost As TextBox = CType(row.FindControl("Textbox5"), TextBox)
        Dim txtTier As TextBox = CType(row.FindControl("Textbox6"), TextBox)
        Dim txtEeeEeee As TextBox = CType(row.FindControl("Textbox7"), TextBox)

        If String.IsNullOrEmpty(txtPartsNo.Text) Then
            Call showMsg("Please Enter Parts No", "")
            'ClearTextbox()
            txtPartsName.Text = ""
            txtPartsCost.Text = ""
            txtPartsType.Text = ""
            txtEeeEeee.Text = ""
            txtTier.Text = ""
            txtPartsDescription.Text = ""
            Exit Sub
        Else
            dt = _AppleAppPartsEntryControl.SelectConsignmentStock(_AppleAppPartsEntryModel)

            'Dim txtSerial As TextBox = CType(row.FindControl("Textbox8"), TextBox)

            'Dim txtSerialNo As TextBox = CType(row.FindControl("Textbox9"), TextBox)
            ' Dim txtInStock As TextBox = CType(row.FindControl("Textbox10"), TextBox)
            'Dim txtBalance As TextBox = CType(row.FindControl("TextBox11"), TextBox)

            If dt.Rows.Count > 0 Then

                If Not IsDBNull(dt.Rows(0)("PRODUCT_NAME")) Then
                    txtPartsName.Text = dt.Rows(0)("PRODUCT_NAME")

                End If

                If Not IsDBNull(dt.Rows(0)("PARTS_DETAIL")) Then

                    txtPartsDescription.Text = dt.Rows(0)("PARTS_DETAIL")
                End If

                If Not IsDBNull(dt.Rows(0)("PARTS_TYPE")) Then

                    txtPartsType.Text = dt.Rows(0)("PARTS_TYPE")
                End If
                If Not IsDBNull(dt.Rows(0)("PRICE_COST")) Then

                    txtPartsCost.Text = dt.Rows(0)("PRICE_COST")
                End If

                If Not IsDBNull(dt.Rows(0)("TIER")) Then

                    txtTier.Text = dt.Rows(0)("TIER")
                End If

                If Not IsDBNull(dt.Rows(0)("EEE_EEEE")) Then

                    txtEeeEeee.Text = dt.Rows(0)("EEE_EEEE")
                End If

                'If Not IsDBNull(dt.Rows(0)("PARTS_NAME")) Then
                '    txtPartsName.Text = dt.Rows(0)("PARTS_NAME")
                'End If

                'If Not IsDBNull(dt.Rows(0)("PARTS_DESCRIPTION")) Then
                '    txtPartsDescription.Text = dt.Rows(0)("PARTS_DESCRIPTION")
                'End If
                'If Not IsDBNull(dt.Rows(0)("PARTS_DETAIL")) Then
                '    txtPartsType.Text = dt.Rows(0)("PARTS_DETAIL")
                'End If
                'If Not IsDBNull(dt.Rows(0)("PARTS_TYPE")) Then
                '    txtPartsCost.Text = dt.Rows(0)("PARTS_TYPE")
                'End If

                'If Not IsDBNull(dt.Rows(0)("PARTS_COST")) Then
                '    txtTier.Text = dt.Rows(0)("PARTS_COST")
                'End If
                'If Not IsDBNull(dt.Rows(0)("TIER")) Then
                '    txtTier.Text = dt.Rows(0)("TIER")
                'End If

                'If Not IsDBNull(dt.Rows(0)("EEE_EEEE")) Then
                '    txtEeeEeee.Text = dt.Rows(0)("EEE_EEEE")
                'End If
                'No Need, User Need to enter 
                'If Not IsDBNull(dt.Rows(0)("SERIAL")) Then
                '    txtSerial.Text = dt.Rows(0)("SERIAL")
                'End If

                'If Not IsDBNull(dt.Rows(0)("SERIAL_NO")) Then
                '    txtSerialNo.Text = dt.Rows(0)("SERIAL_NO")
                'End If

                'If Not IsDBNull(dt.Rows(0)("IN_STOCK")) Then
                '    txtInStock.Text = dt.Rows(0)("IN_STOCK")
                'End If


                'If Not IsDBNull(dt.Rows(0)("BALANCE")) Then
                '    txtBalance.Text = dt.Rows(0)("BALANCE")
                'Else
                '    txtBalance.Text = 0
                'End If
            Else
                Call showMsg(txtPartsNo.Text & "- Not Found!!! ", "")
                ' txtPartsName.Text = ""
                'txtPartsDescription.Text = ""
                ClearTextbox()
                ' txtBalance.Text = ""
                'txtPartsType.Text = ""
                'txtPartsCost.Text = ""
                'txtTier.Text = ""
                'txtEeeEeee.Text = ""
                'txtSerial.Text = ""
                '   txtSerialNo.Text = ""
                '   txtInStock.Text = ""
                'txtBalance.Text = ""

            End If
        End If

        'If drpStockType.SelectedItem.Value = 1 Then

        'If (dt Is Nothing) Or (dt.Rows.Count = 0) Then

        'End If
        'ElseIf drpStockType.SelectedItem.Value = 2 Then
        ' dt = _AppleAppPartsEntryControl.SelectStock(_AppleAppPartsEntryModel)
        'If (dt Is Nothing) Or (dt.Rows.Count = 0) Then

        'End If
        ' Else
        'Call showMsg("Please Select Stock Type ", "")
        'Exit Sub
        'End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = TryCast((TryCast(sender, DropDownList)).NamingContainer, GridViewRow)
        Dim drpdown As DropDownList = CType(row.FindControl("DropDownList1"), DropDownList)
        Dim txtpartsNo As TextBox = CType(row.FindControl("TextBox1"), TextBox)
        Dim txtSerialNo As TextBox = CType(row.FindControl("TextBox9"), TextBox)
        Dim txtInStock As TextBox = CType(row.FindControl("TextBox10"), TextBox)
        Dim txtBalance As TextBox = CType(row.FindControl("TextBox11"), TextBox)
        Dim _AppleAppPartsEntryModel As AppleAppPartsEntryModel = New AppleAppPartsEntryModel()
        Dim _AppleAppPartsEntryControl As AppleAppPartsEntryControl = New AppleAppPartsEntryControl()
        Dim dt As DataTable
        _AppleAppPartsEntryModel.SERIAL = drpdown.SelectedItem.Text
        Dim stockTypeVal As Integer = drpStockType.SelectedItem.Value
        _AppleAppPartsEntryModel.PARTS_NO = txtpartsNo.Text
        _AppleAppPartsEntryModel.PARTS_TYPE = stockTypeVal

        'if 1 consumtion, 2 stock, 0 then exit
        If stockTypeVal = 0 Then
            ' drpdown.ClearSelection()
            drpdown.SelectedIndex = 0
            Call showMsg("Please Select Stock Type", "")
            Exit Sub
        End If
        If txtpartsNo.Text = "" Then
            drpdown.SelectedIndex = 0
            Call showMsg("Please Enter Parts No", "")
            Exit Sub
        End If
        If drpdown.SelectedItem.Value = 1 Then
            'Dim txtSerialNo As TextBox = CType(row.FindControl("TextBox9"), TextBox)
            'Dim txtInStock As TextBox = CType(row.FindControl("TextBox10"), TextBox)
            txtInStock.Text = "1"
            txtInStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6ffff")
            txtSerialNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
            txtInStock.Enabled = False
            txtSerialNo.Text = ""
            txtSerialNo.Enabled = True
            txtBalance.Text = "1"
            txtBalance.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6ffff")
            txtBalance.Enabled = False
            txtBalance.ReadOnly = False
            'dt = _AppleAppPartsEntryControl.SelectStock(_AppleAppPartsEntryModel)

            'If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
            '    txtBalance.Text = ""
            '    Call showMsg("No Parts Please Enter the Balance", "")
            'Else 
            '    If Not IsDBNull(dt.Rows(0)("BALANCE")) Then
            '        txtBalance.Text = dt.Rows(0)("BALANCE")
            '        'txtBalance.ReadOnly = True
            '    End If
            '    Exit Sub
            'End If
        ElseIf drpdown.SelectedItem.Value = 2 Then
            ' Dim txtSerialNo As TextBox = CType(row.FindControl("TextBox9"), TextBox)
            'Dim txtInStock As TextBox = CType(row.FindControl("TextBox10"), TextBox)

            txtSerialNo.Text = ""
            txtSerialNo.Enabled = False
            txtSerialNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6ffff")
            txtInStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
            txtInStock.Text = ""
            txtInStock.Enabled = True
            dt = _AppleAppPartsEntryControl.SelectStockExist(_AppleAppPartsEntryModel)

            If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
                txtBalance.Text = "0"
                txtBalance.ReadOnly = True
                '    txtBalance.Text = ""
                '    Call showMsg("Please Enter the Balance", "")
            Else
                If Not IsDBNull(dt.Rows(0)("BALANCE")) Then
                    txtBalance.Text = dt.Rows(0)("BALANCE")
                    txtBalance.ReadOnly = True
                End If
                'Exit Sub
            End If
        Else
                Call showMsg("Please Select Serial Type ", "")
            'Dim txtSerialNo As TextBox = CType(row.FindControl("TextBox9"), TextBox)
            ' Dim txtInStock As TextBox = CType(row.FindControl("TextBox10"), TextBox)
            txtInStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
            'txtBalance.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
            txtSerialNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
            txtSerialNo.Text = ""
            'txtBalance.Enabled = True
            txtBalance.Text = ""
            txtInStock.Text = ""
            Exit Sub
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
        Response.Redirect("Apple_App_Inventory_Grid.aspx")
        'Session("id") = "0"
    End Sub

    Protected Sub btncommit_Click1(sender As Object, e As EventArgs)
        AddModify("commit", drpStockType.SelectedItem.Text)
    End Sub

    Sub AddModify(TranFlg As String, ConsStockVal As String)
        '1st Validate 
        If drpStockType.SelectedItem.Value = 0 Then
            Call showMsg("Please Select Stock Type", "")
            Exit Sub
        End If
        '3rd Add Parts Values and update to database 
        Dim rowIndex As Integer = 0
        Dim IsPartsRec As Boolean = False
        Dim _AppleAppPartsEntryModel As List(Of AppleAppPartsEntryModel) = New List(Of AppleAppPartsEntryModel)()
        Dim _AppleAppPartsInventoryModel As AppleAppPartsInventoryModel = New AppleAppPartsInventoryModel()
        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = CType(ViewState("CurrentTable"), DataTable)
            'existcheck row
            ExistRowCheck(dtCurrentTable)
            If ifExist = True Then
                Exit Sub
            End If
            '2nd Generate InventoryNo

            Dim ShipName As String = Session("ship_Name")
            Dim shipCode As String = Session("ship_code")
            Dim userName As String = Session("user_Name")
            Dim userid As String = Session("user_id")
            _AppleAppPartsInventoryModel.UserId = userid
            _AppleAppPartsInventoryModel.SHIP_TO_BRANCH_CODE = shipCode
            _AppleAppPartsInventoryModel.SHIP_TO_BRANCH = ShipName
            _AppleAppPartsInventoryModel.INVENTORY_DATE = txtDate.Text
            _AppleAppPartsInventoryModel.PARTS_TYPE = ConsStockVal

            '_AppleAppPartsInventoryModel.StockVal = StockVal
            _AppleAppPartsInventoryModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress
            If lblInventoryNo.Text = "" Then
                Dim _AppleAppPartsInventoryControl As AppleAppPartsInventoryControl = New AppleAppPartsInventoryControl()
                Dim InventoryNo As String = _AppleAppPartsInventoryControl.SelectInventoryNo(_AppleAppPartsInventoryModel)
                If InventoryNo = "-1" Then
                    Call showMsg("Inventory No - Internal Server Error, Contact System Administrator", "")
                    Exit Sub
                Else
                    lblInventoryNo.Text = InventoryNo
                    _AppleAppPartsInventoryModel.INVENTORY_NO = InventoryNo
                End If
            Else
                _AppleAppPartsInventoryModel.INVENTORY_NO = lblInventoryNo.Text
            End If

            If dtCurrentTable.Rows.Count > 0 Then
                IsPartsRec = True
                For i As Integer = 0 To dtCurrentTable.Rows.Count - 1
                    Dim _AppleAppPartsEntryModelTmp As AppleAppPartsEntryModel = New AppleAppPartsEntryModel()
                    Dim txtPartsNo As TextBox = CType(Gridview1.Rows(i).Cells(1).FindControl("TextBox1"), TextBox)
                    Dim txtPartsName As TextBox = CType(Gridview1.Rows(i).Cells(2).FindControl("TextBox2"), TextBox)
                    Dim txtPartsDescription As TextBox = CType(Gridview1.Rows(i).Cells(3).FindControl("TextBox3"), TextBox)
                    Dim txtPartsType As TextBox = CType(Gridview1.Rows(i).Cells(4).FindControl("TextBox4"), TextBox)
                    Dim txtPartsCost As TextBox = CType(Gridview1.Rows(i).Cells(5).FindControl("TextBox5"), TextBox)
                    Dim txtTier As TextBox = CType(Gridview1.Rows(i).Cells(6).FindControl("TextBox6"), TextBox)
                    Dim txtEeeEeee As TextBox = CType(Gridview1.Rows(i).Cells(7).FindControl("TextBox7"), TextBox)
                    'Dim txtSerial As TextBox = CType(Gridview1.Rows(i).Cells(8).FindControl("TextBox8"), TextBox)
                    Dim ddl1 As DropDownList = CType(Gridview1.Rows(i).Cells(8).FindControl("DropDownList1"), DropDownList)
                    Dim txtSerialNo As TextBox = CType(Gridview1.Rows(i).Cells(9).FindControl("TextBox9"), TextBox)
                    Dim txtInStock As TextBox = CType(Gridview1.Rows(i).Cells(10).FindControl("TextBox10"), TextBox)
                    Dim txtBalance As TextBox = CType(Gridview1.Rows(i).Cells(11).FindControl("TextBox11"), TextBox)

                    _AppleAppPartsEntryModelTmp.SR_NO = i.ToString
                    _AppleAppPartsEntryModelTmp.PARTS_NO = txtPartsNo.Text
                    _AppleAppPartsEntryModelTmp.PARTS_NAME = txtPartsName.Text
                    _AppleAppPartsEntryModelTmp.PARTS_DESCRIPTION = txtPartsDescription.Text
                    _AppleAppPartsEntryModelTmp.PARTS_TYPE = txtPartsType.Text
                    _AppleAppPartsEntryModelTmp.PARTS_COST = txtPartsCost.Text
                    _AppleAppPartsEntryModelTmp.TIER = txtTier.Text
                    _AppleAppPartsEntryModelTmp.EEE_EEEE = txtEeeEeee.Text
                    _AppleAppPartsEntryModelTmp.SERIAL = ddl1.SelectedItem.Text
                    _AppleAppPartsEntryModelTmp.SERIAL_NO = txtSerialNo.Text
                    _AppleAppPartsEntryModelTmp.IN_STOCK = txtInStock.Text
                    _AppleAppPartsEntryModelTmp.BALANCE = txtBalance.Text

                    _AppleAppPartsEntryModel.Add(_AppleAppPartsEntryModelTmp)
                Next
            End If
        End If

        If IsPartsRec Then
            Dim _AppleAppPartsEntryControl As AppleAppPartsEntryControl = New AppleAppPartsEntryControl()
            Dim blStatus As Boolean = _AppleAppPartsEntryControl.AddPartsEntry(_AppleAppPartsEntryModel, _AppleAppPartsInventoryModel, TranFlg, ConsStockVal)
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
                    Response.Redirect("Apple_App_Inventory_Grid.aspx")
                End If
            End If
        Else
            Call showMsg("No Parts Item Found To Save...", "")
        End If

    End Sub
    Sub ExistRowCheck(dt As DataTable)
        Dim _AppleAppPartsEntryModel As AppleAppPartsEntryModel = New AppleAppPartsEntryModel()
        Dim _AppleAppPartsEntryControl As AppleAppPartsEntryControl = New AppleAppPartsEntryControl()
        Dim _dtCons As DataTable
        Dim _dtStock As DataTable
        Dim strinvNo As String = Nothing

        Dim rowIndex As Integer = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim ddl1 As DropDownList = CType(Gridview1.Rows(i).Cells(8).FindControl("DropDownList1"), DropDownList)
                Dim txtpartsNo As TextBox = CType(Gridview1.Rows(i).Cells(1).FindControl("TextBox1"), TextBox)
                Dim txtSerialNo As TextBox = CType(Gridview1.Rows(i).Cells(9).FindControl("TextBox9"), TextBox)
                If ddl1.SelectedItem.Value = 1 Then 'yes
                    If String.IsNullOrEmpty(txtSerialNo.Text) Then
                        Call showMsg("Please Enter Serial No", "")
                        ifExist = True
                        Exit Sub
                    Else
                        _AppleAppPartsEntryModel.SERIAL = ddl1.SelectedItem.Text
                        _AppleAppPartsEntryModel.PARTS_NO = txtpartsNo.Text
                        _AppleAppPartsEntryModel.SERIAL_NO = txtSerialNo.Text
                        _dtCons = _AppleAppPartsEntryControl.SelectSerialExistCons(_AppleAppPartsEntryModel)

                        If (_dtCons Is Nothing) Or (_dtCons.Rows.Count = 0) Then
                        Else
                            If Not IsDBNull(_dtCons.Rows(0)("INVENTORY_NO")) Then
                                strinvNo = _dtCons.Rows(0)("INVENTORY_NO")
                            End If
                            Call showMsg("Serial No Already exist Parts No " + txtpartsNo.Text + "(" & strinvNo & ")", "")
                            ifExist = True
                            Exit Sub
                        End If
                        _AppleAppPartsEntryModel.SERIAL = ddl1.SelectedItem.Text
                        _AppleAppPartsEntryModel.PARTS_NO = txtpartsNo.Text
                        _AppleAppPartsEntryModel.SERIAL_NO = txtSerialNo.Text
                        _dtStock = _AppleAppPartsEntryControl.SelectSerialExistStock(_AppleAppPartsEntryModel)

                        If (_dtStock Is Nothing) Or (_dtStock.Rows.Count = 0) Then
                        Else
                            If Not IsDBNull(_dtStock.Rows(0)("INVENTORY_NO")) Then
                                strinvNo = _dtStock.Rows(0)("INVENTORY_NO")
                            End If
                            Call showMsg("Serial No Already exist Parts No " + txtpartsNo.Text + "(" & strinvNo & ")", "")
                            ifExist = True
                            Exit Sub
                        End If
                    End If
                End If
                For j As Integer = 1 To dt.Rows.Count - 1
                    Dim txtpartsNoDup As TextBox = CType(Gridview1.Rows(j).Cells(1).FindControl("TextBox1"), TextBox)
                    Dim txtSerialNoDup As TextBox = CType(Gridview1.Rows(j).Cells(9).FindControl("TextBox9"), TextBox)
                    If i <> j Then
                        If txtpartsNoDup.Text.Trim() = txtpartsNo.Text.Trim() Then
                            ' If txtSerialNo.Text <> "" Then
                            If txtSerialNoDup.Text = txtSerialNo.Text Then
                                '_AppleAppPartsEntryModel.STOCK_TYPE = drpStockType.SelectedItem.Value
                                '_AppleAppPartsEntryModel.PARTS_NO = txtpartsNo.Text.Trim()
                                '_AppleAppPartsEntryModel.SERIAL_NO = txtSerialNo.Text
                                ifExist = True
                                Call showMsg("Parts No " + txtpartsNo.Text + " Part Type " + txtSerialNo.Text + " already Exist!", "")
                                Exit Sub
                            End If
                            'End If
                        End If
                    End If
                    rowIndex += 1
                Next
                ' Dim As TextBox = CType(Row.FindControl("TextBox9"), TextBox)

                rowIndex += 1
            Next
        End If
        'Return ifExist
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
            'CType(row.FindControl("TextBox8"), TextBox).Text = ""
            CType(row.FindControl("DropDownList1"), DropDownList).SelectedItem.Text = "Select"
            CType(row.FindControl("TextBox9"), TextBox).Text = ""
            CType(row.FindControl("TextBox10"), TextBox).Text = ""
            CType(row.FindControl("TextBox11"), TextBox).Text = ""
        Next
    End Sub
End Class