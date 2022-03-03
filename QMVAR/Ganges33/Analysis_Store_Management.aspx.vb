Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Imports System.Configuration
Imports GemBox.Spreadsheet
Imports GemBox.Spreadsheet.Charts

Imports System.Web.Configuration


Public Class Analysis_Store_Management
    Inherits System.Web.UI.Page
    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property
    Dim prevmonth As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            '***ログインユーザ情報表示***
            Dim setShipname As String = Session("ship_Name")
            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            Dim adminFlg As Boolean = Session("admin_Flg")

            lblLoc.Text = setShipname
            lblName.Text = userName



            DefaultDisplay()
            Stored.Visible = False
            Credit.Visible = False
            Getdta.Visible = False
            Label3.Visible = False
            Label43.Visible = False
            LblINFO.Visible = False
            Label40.Visible = False
            P1.Visible = False
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            Table1.Visible = False
            Table2.Visible = False
            Table3.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False
            Label104.Visible = False
            P2.Visible = False
            Label91.Visible = False
            Label32.Visible = True
            lblmontlytaget.Visible = False
            Monthytarget.Visible = False


            'PO_Collection
            Label200.Visible = False
            TableCollections.Visible = False

            Table6.Visible = False
            tblPaymentGrid.Visible = False

            InitDropDownList()
            InitDropDownList1()
            InitDropDownList2()
            InitDropDownList3()
            InitDropDownList5()
            'PO_Collection
            InitDropDownList6()
            InitDropDownList7()


            TextFromDate.Text = ""
            TextToDate.Text = ""



            'Dim dDate As DateTime = Date.Today


            'TextBox2.Text = dDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)

            'TextBox8.Text = dDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)



            ''Default Year
            'DropDownYear.SelectedValue = Now.Year
            ''Default Month
            'DropDownMonth.SelectedValue = DateTime.Now.AddMonths(-1).Month 'Now.Month


            'drpManagementFunc.
            LoadDB()


            Dim creditInfoModel As New CreditModel
            Dim CreditInfocontrol As New CreditControl

            If DropdownList1.SelectedValue = "Select" Then
                TextBox5.Text = "0.00"
                TextBox6.Text = "0.00"

            Else
                creditInfoModel.BRANCH_NO = DropdownList1.SelectedItem.Text
                Dim _Datatable As DataTable = CreditInfocontrol.Get_Credit_info(creditInfoModel)
                If (_Datatable Is Nothing) Or (_Datatable.Rows.Count = 0) Then
                    Exit Sub
                Else
                    If Not IsDBNull(_Datatable.Rows(0)("CREDIT_LIMIT")) Then
                        TextBox5.Text = _Datatable.Rows(0)("CREDIT_LIMIT")
                    End If
                    If Not IsDBNull(_Datatable.Rows(0)("PER_DAY")) Then
                        TextBox6.Text = _Datatable.Rows(0)("PER_DAY")
                    End If
                End If
            End If
            LoadDB1()

            If DropDownList2.SelectedValue = "Select" Then
                TextBox1.Text = "0.00"


            Else
                creditInfoModel.ship_Name = DropDownList2.SelectedItem.Text
                Dim _Dtable As DataTable = CreditInfocontrol.Get_GSTIN(creditInfoModel)
                If (_Dtable Is Nothing) Or (_Dtable.Rows.Count = 0) Then
                    Exit Sub
                Else
                    If Not IsDBNull(_Dtable.Rows(0)("GSTIN")) Then
                        TextBox1.Text = _Dtable.Rows(0)("GSTIN")
                    End If
                End If
            End If
            pageload() 'Added for Call load
        End If
    End Sub
    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow AndAlso gvDisplayPaymentValue.EditIndex = e.Row.RowIndex Then
            'Dim ddlCities As DropDownList = CType(e.Row.FindControl("ddlCities"), DropDownList)
            'Dim sql As String = "SELECT DISTINCT City FROM Customers"
            'Dim conString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            'Using con As SqlConnection = New SqlConnection(conString)
            '    Using sda As SqlDataAdapter = New SqlDataAdapter(sql, con)
            '        Using dt As DataTable = New DataTable()
            '            sda.Fill(dt)
            '            ddlCities.DataSource = dt
            '            ddlCities.DataTextField = "City"
            '            ddlCities.DataValueField = "City"
            '            ddlCities.DataBind()
            '            Dim selectedCity As String = DataBinder.Eval(e.Row.DataItem, "City").ToString()
            '            ddlCities.Items.FindByValue(selectedCity).Selected = True
            '        End Using
            '    End Using
            'End Using
        End If
    End Sub

    Protected Sub txtPageSize_TextChanged(sender As Object, e As EventArgs) Handles txtPageSize.TextChanged

        Dim intValue As Integer
        If Integer.TryParse(txtPageSize.Text, intValue) AndAlso intValue > 0 AndAlso intValue <= 9999 Then
            lblErrorMessage.Visible = False

            'Dim dt As DataTable = CType(exfiledtl.ExportAnalysisDetails(Session("Exportinputdtl"), "R"), DataTable)
            Dim _PaymentVlaueControl As PaymentValueControl = New PaymentValueControl()
            Dim dt As DataTable = _PaymentVlaueControl.ShowPaymentValueGrid()
            Dim dv As DataView = New DataView(dt)
            If ViewState("SortExpression") Is Nothing Then
                'dgColdtl.DefaultView.Sort = "unq_no ASC"
                'dv.Sort = gvDisplayPaymentValue.Columns(0).SortExpression & " " & Me.SortDirection
                dv.Sort = "unq_no Desc"

            Else
                dv.Sort = ViewState("SortExpression") & " " & Me.SortDirection
            End If

            txtPageSize.Text = Convert.ToInt16(txtPageSize.Text)
            gvDisplayPaymentValue.PageSize = Convert.ToInt16(txtPageSize.Text)
            gvDisplayPaymentValue.PageIndex = 0
            gvDisplayPaymentValue.DataSource = dv
            gvDisplayPaymentValue.DataBind()

        Else
            lblErrorMessage.Visible = True
            txtPageSize.Text = gvDisplayPaymentValue.PageSize

        End If

    End Sub

    Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs)
        gvDisplayPaymentValue.EditIndex = e.NewEditIndex
        Dim _PaymentVlaueControl As PaymentValueControl = New PaymentValueControl()
        Dim dtDisplayPaymentValue As DataTable = _PaymentVlaueControl.ShowPaymentValueGrid()
        dtDisplayPaymentValue = dtDisplayPaymentValue.DefaultView.ToTable()
        If Not dtDisplayPaymentValue Is Nothing Then
            If dtDisplayPaymentValue.Rows.Count > 0 Then



                gvDisplayPaymentValue.Visible = True
                gvDisplayPaymentValue.DataSource = dtDisplayPaymentValue
                gvDisplayPaymentValue.DataBind()


                Dim row As GridViewRow = gvDisplayPaymentValue.Rows(e.NewEditIndex)
                Dim dd1 As DropDownList = row.FindControl("drpdowntargetssc")
                Dim calander As TextBox = row.FindControl("txttargetdate1")
                ' calander.EndDate = DateTime.Now.Date

                dd1.DataSource = Session("codeMasterList")
                dd1.DataTextField = "CodeDispValue"
                dd1.DataValueField = "CodeValue"
                dd1.DataBind()
                Dim row2 As GridViewRow = gvDisplayPaymentValue.Rows(e.NewEditIndex)
                Dim hdn As HiddenField = row.FindControl("HiddenField1")
                dd1.Items.FindByText(hdn.Value).Selected = True

                'Dim unq_no As Integer = Convert.ToInt32(gvDisplayPaymentValue.DataKeys(e.RowIndex).Values(0))
                'Dim CreatedDate As String = (TryCast(row.FindControl("txtcreateddate1"), TextBox)).Text


            End If
        End If
    End Sub

    Protected Sub OnRowCancelingEdit(sender As Object, e As EventArgs)
        gvDisplayPaymentValue.EditIndex = -1
        Dim _PaymentVlaueControl As PaymentValueControl = New PaymentValueControl()
        Dim dtDisplayPaymentValue As DataTable = _PaymentVlaueControl.ShowPaymentValueGrid()
        dtDisplayPaymentValue = dtDisplayPaymentValue.DefaultView.ToTable()
        If Not dtDisplayPaymentValue Is Nothing Then
            If dtDisplayPaymentValue.Rows.Count > 0 Then
                gvDisplayPaymentValue.Visible = True
                gvDisplayPaymentValue.DataSource = dtDisplayPaymentValue
                gvDisplayPaymentValue.DataBind()
            End If
        End If
    End Sub
    Protected Sub OnRowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim _PaymentVlaueControl As PaymentValueControl = New PaymentValueControl()
        Dim row As GridViewRow = gvDisplayPaymentValue.Rows(e.RowIndex)
        Dim unq_no As Integer = Convert.ToInt32(gvDisplayPaymentValue.DataKeys(e.RowIndex).Values(0))
        Dim CreatedDate As String = (TryCast(row.FindControl("txtcreateddate1"), TextBox)).Text
        'Dim TargetSSC As String = (TryCast(row.FindControl("txttargetssc1"), TextBox)).Text
        Dim TargetSSC As String = (TryCast(row.FindControl("drpdowntargetssc"), DropDownList)).SelectedItem.Text
        Dim PaymentAmount As String = (TryCast(row.FindControl("txtpaymentamount1"), TextBox)).Text
        Dim TargetDate As String = (TryCast(row.FindControl("txttargetdate1"), TextBox)).Text
        'query
        Dim _PaymentVlaueModel As PaymentValueModel = New PaymentValueModel()

        _PaymentVlaueModel.UNQ_NO = Convert.ToString(unq_no)
        '_PaymentVlaueModel.SHIP_TO_BRANCH_CODE = DropdownList5.SelectedItem.Value
        _PaymentVlaueModel.CRTCD = CreatedDate
        _PaymentVlaueModel.SHIP_TO_BRANCH = TargetSSC
        _PaymentVlaueModel.VALUE = PaymentAmount
        _PaymentVlaueModel.TARGET_DATE = TargetDate
        '_PaymentVlaueModel.UserId = Session("user_id").ToString

        Dim dtUpdatePaymentValue As Boolean = _PaymentVlaueControl.UpdatePaymentValueFromGrid(_PaymentVlaueModel)

        gvDisplayPaymentValue.EditIndex = -1

        Dim dtDisplayPaymentValue As DataTable = _PaymentVlaueControl.ShowPaymentValueGrid()
        dtDisplayPaymentValue = dtDisplayPaymentValue.DefaultView.ToTable()
        If Not dtDisplayPaymentValue Is Nothing Then
            If dtDisplayPaymentValue.Rows.Count > 0 Then
                gvDisplayPaymentValue.Visible = True
                gvDisplayPaymentValue.DataSource = dtDisplayPaymentValue
                gvDisplayPaymentValue.DataBind()
            End If
        End If
    End Sub

    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gvDisplayPaymentValue.PageIndex = e.NewPageIndex
        Dim _PaymentVlaueControl As PaymentValueControl = New PaymentValueControl()
        Dim dt As DataTable = _PaymentVlaueControl.ShowPaymentValueGrid()
        'Dim dt As DataTable = CType(exfiledtl.ExportAnalysisDetails(Session("Exportinputdtl"), "R"), DataTable)

        Dim dv As DataView = New DataView(dt)
        If ViewState("SortExpression") Is Nothing Then
            'dv.Sort = gvDisplayPaymentValue.Columns(0).SortExpression & " " & Me.SortDirection
            dv.Sort = "unq_no Desc"
        Else
            dv.Sort = ViewState("SortExpression") & " " & Me.SortDirection
        End If
        ' dv.Sort = "ServiceOrder_No " & Me.SortDirection
        gvDisplayPaymentValue.DataSource = dv
        gvDisplayPaymentValue.DataBind()
        '_ScDsrControl.ExportScDsr(Session("Exportinputdtl"))
        ' Me.BindGrid()
    End Sub

    Protected Sub OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        If IsPostBack = True Then
            Dim _PaymentVlaueControl As PaymentValueControl = New PaymentValueControl()
            Dim dt As DataTable = _PaymentVlaueControl.ShowPaymentValueGrid()
            'Dim dt As DataTable = CType(exfiledtl.ExportAnalysisDetails(Session("Exportinputdtl"), "R"), DataTable)
            If (Not (dt) Is Nothing) Then
                Dim dv As DataView = New DataView(dt)
                ViewState("SortExpression") = e.SortExpression

                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = e.SortExpression & " " & Me.SortDirection
                gvDisplayPaymentValue.DataSource = dv
                gvDisplayPaymentValue.DataBind()
                '
            End If
        End If
        'https://www.aspsnippets.com/Articles/Ascending-Descending-Sorting-using-Columns-Header-in-ASPNet-GridView.aspx
        'https://www.codeproject.com/Articles/1195569/Angular-Data-Grid-with-Sorting-Filtering-Export-to
        'https://forums.asp.net/t/1412788.aspx?How+to+Export+GridView+To+Word+Excel+PDF+CSV+in+ASP+Net

    End Sub
    Private Function ConvertSortDirectionToSql(ByVal sortDirection As SortDirection) As String
        Dim newSortDirection As String = String.Empty
        Select Case (sortDirection)
            Case SortDirection.Ascending
                newSortDirection = "ASC"
            Case SortDirection.Descending
                newSortDirection = "DESC"
        End Select

        Return newSortDirection
    End Function




    ''' <summary>
    ''' Loading All branches
    ''' </summary>
    Private Sub InitDropDownList()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropListLocation.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchSSC(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        'Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        'codeMaster1.CodeValue = "Select Branch"
        'codeMaster1.CodeDispValue = "Select Branch"
        'codeMasterList.Insert(0, codeMaster1)

        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        codeMaster2.CodeValue = "ALL"
        codeMaster2.CodeDispValue = "ALL"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropListLocation.DataSource = codeMasterList
        Me.DropListLocation.DataTextField = "CodeDispValue"
        Me.DropListLocation.DataValueField = "CodeValue"
        Me.DropListLocation.DataBind()
    End Sub

    ''' <summary>
    ''' Loading All branches
    ''' </summary>
    Private Sub InitDropDownList1()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropdownList1.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchSSCCreditInfo(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        'Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        'codeMaster1.CodeValue = "Select Branch"
        'codeMaster1.CodeDispValue = "Select Branch"
        'codeMasterList.Insert(0, codeMaster1)

        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        codeMaster2.CodeValue = "Select"
        codeMaster2.CodeDispValue = "Select"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropdownList1.DataSource = codeMasterList
        Me.DropdownList1.DataTextField = "CodeDispValue"
        Me.DropdownList1.DataValueField = "CodeValue"
        Me.DropdownList1.DataBind()
    End Sub
    Private Sub InitDropDownList2()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropDownList2.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchSSC(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        'Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        'codeMaster1.CodeValue = "Select Branch"
        'codeMaster1.CodeDispValue = "Select Branch"
        'codeMasterList.Insert(0, codeMaster1)

        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        codeMaster2.CodeValue = "Select"
        codeMaster2.CodeDispValue = "Select"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropDownList2.DataSource = codeMasterList
        Me.DropDownList2.DataTextField = "CodeDispValue"
        Me.DropDownList2.DataValueField = "CodeValue"
        Me.DropDownList2.DataBind()
    End Sub

    Private Sub InitDropDownList3()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropdownList3.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchSSC(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        'Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        'codeMaster1.CodeValue = "Select Branch"
        'codeMaster1.CodeDispValue = "Select Branch"
        'codeMasterList.Insert(0, codeMaster1)

        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()

        codeMaster2.CodeValue = "ALL"
        codeMaster2.CodeDispValue = "ALL"
        'codeMaster2.CodeValue = "Select"
        'codeMaster2.CodeDispValue = "Select"

        codeMasterList.Insert(0, codeMaster2) '


        Me.DropdownList3.DataSource = codeMasterList
        Me.DropdownList3.DataTextField = "CodeDispValue"
        Me.DropdownList3.DataValueField = "CodeValue"
        Me.DropdownList3.DataBind()

        If DropdownList3.SelectedItem.Text = "ALL" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC1" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC2" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC3" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC4" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC5" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC6" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC7" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC8" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
        If DropdownList3.SelectedItem.Text = "SSC9" Then
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            TextDateTo.Text = ""
            TextFromDate.Text = ""
        End If
    End Sub
    Private Sub InitDropDownList5()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropdownList5.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchSSC(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        'Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        'codeMaster1.CodeValue = "Select Branch"
        'codeMaster1.CodeDispValue = "Select Branch"
        'codeMasterList.Insert(0, codeMaster1)

        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        codeMaster2.CodeValue = "Select"
        codeMaster2.CodeDispValue = "Select"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropdownList5.DataSource = codeMasterList
        Me.DropdownList5.DataTextField = "CodeDispValue"
        Me.DropdownList5.DataValueField = "CodeValue"
        Me.DropdownList5.DataBind()

        codeMasterList.RemoveAt(0)
        Session("codeMasterList") = codeMasterList
    End Sub

    'PO_Collection
    Private Sub InitDropDownList6()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropdownList6.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchSSC(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        'Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        'codeMaster1.CodeValue = "Select Branch"
        'codeMaster1.CodeDispValue = "Select Branch"
        'codeMasterList.Insert(0, codeMaster1)

        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        codeMaster2.CodeValue = "Select"
        codeMaster2.CodeDispValue = "Select"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropdownList6.DataSource = codeMasterList
        Me.DropdownList6.DataTextField = "CodeDispValue"
        Me.DropdownList6.DataValueField = "CodeValue"
        Me.DropdownList6.DataBind()
    End Sub
    Private Sub InitDropDownList7()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropdownList7.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchSSC(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        'Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        'codeMaster1.CodeValue = "Select Branch"
        'codeMaster1.CodeDispValue = "Select Branch"
        'codeMasterList.Insert(0, codeMaster1)

        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        codeMaster2.CodeValue = "Select"
        codeMaster2.CodeDispValue = "Select"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropdownList7.DataSource = codeMasterList
        Me.DropdownList7.DataTextField = "CodeDispValue"
        Me.DropdownList7.DataValueField = "CodeValue"
        Me.DropdownList7.DataBind()
    End Sub

    Protected Sub showMsg(ByVal Msg As String, ByVal msgChk As String)

        lblMsg.Text = Msg
        Dim sScript As String

        If msgChk = "CancelMsg" Then
            'OKとキャンセルボタン
            sScript = "$(function () {$(""#dialog"" ).dialog({width: 400,buttons:{""OK"": function () {$(this).dialog('close');$('[id$=""BtnOK""]').click();},""CANCEL"": function () {$(this).dialog('close');$('[id$=""BtnCancel""]').click();}}});});"
        ElseIf msgChk = "CancelMsg2" Then 'Added for Weekly Revenue Report
            'OKとキャンセルボタン 
            sScript = "$(function () {$(""#dialog"" ).dialog({width: 400,buttons:{""OK"": function () {$(this).dialog('close');$('[id$=""Btn2OK""]').click();},""CANCEL"": function () {$(this).dialog('close');$('[id$=""BtnCancel""]').click();}}});});"
        ElseIf msgChk = "CancelMsg3" Then 'Added for Call Load Report
            'OKとキャンセルボタン 
            sScript = "$(function () {$(""#dialog"" ).dialog({width: 400,buttons:{""OK"": function () {$(this).dialog('close');$('[id$=""Btn3OK""]').click();},""CANCEL"": function () {$(this).dialog('close');$('[id$=""BtnCancel""]').click();}}});});"
        Else
            'OKボタンのみ
            sScript = "$(function () { $( ""#dialog"" ).dialog({width: 400, buttons: {""OK"": function () {$(this).dialog('close');}}});});"
        End If

        'JavaScriptの埋め込み
        ClientScript.RegisterStartupScript(Me.GetType(), "startup", sScript, True)

    End Sub

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click


        'Dim _dtPlReprt As New DataTable

        '_dtPlReprt.Columns.Add("CustomerVisit", GetType(Integer))
        '_dtPlReprt.Columns.Add("CallRegistered", GetType(Integer))
        '_dtPlReprt.Columns.Add("RepairCompleted", GetType(Integer))
        '_dtPlReprt.Columns.Add("GoodsDelivered", GetType(Integer))
        '_dtPlReprt.Columns.Add("Pending", GetType(Integer))
        '_dtPlReprt.Columns.Add("Warranty", GetType(Integer))
        '_dtPlReprt.Columns.Add("InWarranty", GetType(Integer))
        '_dtPlReprt.Columns.Add("OutWarranty", GetType(Integer))
        '_dtPlReprt.Columns.Add("InWarrantyAmount", GetType(Decimal))
        '_dtPlReprt.Columns.Add("InWarrantyLabour", GetType(Decimal))
        '_dtPlReprt.Columns.Add("InWarrantyParts", GetType(Decimal))
        '_dtPlReprt.Columns.Add("InWarrantyTransport", GetType(Decimal))
        '_dtPlReprt.Columns.Add("InWarrantyOthers", GetType(Decimal))
        '_dtPlReprt.Columns.Add("OutWarrantyAmount", GetType(Decimal))
        '_dtPlReprt.Columns.Add("OutWarrantyLabour", GetType(Decimal))
        '_dtPlReprt.Columns.Add("OutWarrantyParts", GetType(Decimal))
        '_dtPlReprt.Columns.Add("OutWarrantyTransport", GetType(Decimal))
        '_dtPlReprt.Columns.Add("OutWarrantyOthers", GetType(Decimal))
        '_dtPlReprt.Columns.Add("SawDiscountLabour", GetType(Decimal))
        '_dtPlReprt.Columns.Add("SawDiscountParts", GetType(Decimal))
        '_dtPlReprt.Columns.Add("OutWarrantyLabourwSawDisc", GetType(Decimal))
        '_dtPlReprt.Columns.Add("OutWarrantyPartswSawDisc", GetType(Decimal))
        '_dtPlReprt.Columns.Add("RevenueWithoutTax", GetType(Decimal))
        '_dtPlReprt.Columns.Add("IwPartsConsumed", GetType(Decimal))
        '_dtPlReprt.Columns.Add("TotalPartsConsumed", GetType(Decimal))
        '_dtPlReprt.Columns.Add("PrimeCostTotal", GetType(Decimal))
        '_dtPlReprt.Columns.Add("GrossProfit", GetType(Decimal))

        '_dtPlReprt.Rows.Add(0, 0, 0, 0, 0, 570, 255, 315, 44375, 44375, 621928, 0, 0, 822336.7, 77437.49, 693913.75, 0, 0, 3850, 47135.46, 81287.49, 741049.21, 866711.7, 547296.66, 1199419.94, 652123.28, 214588.42)

        'Validation 
        If Not (CommonControl.isNumberCT_CC(txtGM.Text)) Then
            Call showMsg("The GM value is invalid...", "")
            Exit Sub
        End If

        If DrpType.SelectedItem.Value = "0" Then
            Call showMsg("Please select the type", "")
            Exit Sub
        End If

        'For Month Selected or Not
        If DrpType.SelectedItem.Value = "02" Then
            If DropDownMonth.SelectedItem.Value = "0" Then
                Call showMsg("Please select the month", "")
                Exit Sub
            End If
        End If

        'For Month Selected or Not
        If DrpType.SelectedItem.Value = "03" Then
            'TextDateFrom
            'TextDateTo
            Dim dt As DateTime
            If TextDateFrom.Text <> "" Then
                If DateTime.TryParse(TextDateFrom.Text, dt) Then
                Else
                    Call showMsg("The from date specification is incorrect.", "")
                    Exit Sub
                End If
            Else
                Call showMsg("Please enter from date.", "")
                Exit Sub
            End If
            If TextDateTo.Text <> "" Then
                If DateTime.TryParse(TextDateTo.Text, dt) Then
                Else
                    Call showMsg("The to date specification is incorrect.", "")
                    Exit Sub
                End If
            Else
                Call showMsg("Please enter to date.", "")
                Exit Sub
            End If
        End If


        'Define Variables
        Dim comcontrol As New CommonControl
        Dim _dtPlReprt As New DataTable

        Dim intNumberOfCounters As Integer = 0
        Dim intNumberOfBusinessDat As Integer = 0
        Dim intNumberOfStaffs As Integer = 0


        Dim intCustomerVisit As Integer = 0
        Dim intCallRegistered As Integer = 0
        Dim intRepairCompleted As Integer = 0
        Dim intGoodsDelivered As Integer = 0
        Dim intPending As Integer = 0
        Dim intWarranty As Integer = 0
        Dim intInWarranty As Integer = 0
        Dim intOutWarranty As Integer = 0
        Dim decInWarrantyAmount As Decimal = 0.00
        Dim decInWarrantyLabour As Decimal = 0.00
        Dim decInWarrantyParts As Decimal = 0.00
        Dim decInWarrantyTransport As Decimal = 0.00
        Dim decInWarrantyOthers As Decimal = 0.00
        Dim decOutWarrantyAmount As Decimal = 0.00
        Dim decOutWarrantyLabour As Decimal = 0.00
        Dim decOutWarrantyParts As Decimal = 0.00
        Dim decOutWarrantyTransport As Decimal = 0.00
        Dim decOutWarrantyOthers As Decimal = 0.00
        Dim decSawDiscountLabour As Decimal = 0.00
        Dim decSawDiscountParts As Decimal = 0.00
        Dim decOutWarrantyLabourwSawDisc As Decimal = 0.00
        Dim decOutWarrantyPartswSawDisc As Decimal = 0.00
        Dim decRevenueWithoutTax As Decimal = 0.00
        Dim decIwPartsConsumed As Decimal = 0.00
        Dim decTotalPartsConsumed As Decimal = 0.00
        Dim decPrimeCostTotal As Decimal = 0.00
        Dim decGrossProfit As Decimal = 0.00
        Dim decFinalPercentage As Decimal = 0.00

        Dim intNumberOfCountersTot As Integer = 0
        Dim intNumberOfBusinessDatTot As Integer = 0
        Dim intNumberOfStaffsTot As Integer = 0

        Dim intCustomerVisitTot As Integer = 0
        Dim intCallRegisteredTot As Integer = 0
        Dim intRepairCompletedTot As Integer = 0
        Dim intGoodsDeliveredTot As Integer = 0
        Dim intPendingTot As Integer = 0
        Dim intWarrantyTot As Integer = 0
        Dim intInWarrantyTot As Integer = 0
        Dim intOutWarrantyTot As Integer = 0
        Dim decInWarrantyAmountTot As Decimal = 0.00
        Dim decInWarrantyLabourTot As Decimal = 0.00
        Dim decInWarrantyPartsTot As Decimal = 0.00
        Dim decInWarrantyTransportTot As Decimal = 0.00
        Dim decInWarrantyOthersTot As Decimal = 0.00
        Dim decOutWarrantyAmountTot As Decimal = 0.00
        Dim decOutWarrantyLabourTot As Decimal = 0.00
        Dim decOutWarrantyPartsTot As Decimal = 0.00
        Dim decOutWarrantyTransportTot As Decimal = 0.00
        Dim decOutWarrantyOthersTot As Decimal = 0.00
        Dim decSawDiscountLabourTot As Decimal = 0.00
        Dim decSawDiscountPartsTot As Decimal = 0.00
        Dim decOutWarrantyLabourwSawDiscTot As Decimal = 0.00
        Dim decOutWarrantyPartswSawDiscTot As Decimal = 0.00
        Dim decRevenueWithoutTaxTot As Decimal = 0.00
        Dim decIwPartsConsumedTot As Decimal = 0.00
        Dim decTotalPartsConsumedTot As Decimal = 0.00
        Dim decPrimeCostTotalTot As Decimal = 0.00
        Dim decGrossProfitTot As Decimal = 0.00
        Dim decFinalPercentageTot As Decimal = 0.00

        'GM
        Dim Gm As Decimal = 0.88
        Gm = txtGM.Text

        'For Temporary
        Dim FinalPercentage1 As Decimal = 0.00
        Dim SscTotals031 As Decimal = 0.00
        Dim SscTotals131 As Decimal = 0.00
        Dim SscTotals231 As Decimal = 0.00
        Dim SscTotals331 As Decimal = 0.00


        Dim _FinalPercentage As Decimal = 0.00



        'Today Date
        Dim strDay As String = ""
        Dim strMon As String = ""
        Dim strYear As String = ""

        Dim strDate As String = ""

        strDay = Now.Day()
        strMon = Now.Month
        strYear = Now.Year

        If Len(strDay) < 1 Then
            strDay = "0" & strDay
        End If
        If Len(strMon) < 1 Then
            strMon = "0" & strMon
        End If
        strDate = strYear & "/" & strMon & "/" & strDay

        Dim clsSet As New Class_analysis


        Dim csvContents = New List(Of String)
        '****************************************
        '4week 
        'Begin
        '****************************************
        If DrpType.SelectedItem.Value = "01" Then ' 4week
            'For FileName
            Dim PeriodFrom As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)

            Dim Sunday4Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            If (Sunday4Week.DayOfWeek = 1) Then
                'Monday
                Sunday4Week = Sunday4Week.AddDays(-1)
            ElseIf (Sunday4Week.DayOfWeek = 2) Then
                'Tuesday
                Sunday4Week = Sunday4Week.AddDays(-2)
            ElseIf (Sunday4Week.DayOfWeek = 3) Then
                'Wednesday
                Sunday4Week = Sunday4Week.AddDays(-3)
            ElseIf (Sunday4Week.DayOfWeek = 4) Then
                'Thursday
                Sunday4Week = Sunday4Week.AddDays(-4)
            ElseIf (Sunday4Week.DayOfWeek = 5) Then
                'Friday
                Sunday4Week = Sunday4Week.AddDays(-5)
            ElseIf (Sunday4Week.DayOfWeek = 6) Then
                'Saturday
                Sunday4Week = Sunday4Week.AddDays(-6)
            ElseIf (Sunday4Week.DayOfWeek = 7) Then
                'Sunday
                'No change
            End If



            Dim Monday4Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            'Find Last Monday from Last Sunday
            Monday4Week = Sunday4Week.AddDays(-6)

            'Define Date
            Dim Monday3Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim Sunday3Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Monday3Week = Monday4Week.AddDays(-7)
            Sunday3Week = Sunday4Week.AddDays(-7)
            Dim Monday2Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim Sunday2Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Monday2Week = Monday3Week.AddDays(-7)
            Sunday2Week = Sunday3Week.AddDays(-7)
            Dim Monday1Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim Sunday1Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Monday1Week = Monday2Week.AddDays(-7)
            Sunday1Week = Sunday2Week.AddDays(-7)



            '1st Find day of week
            'lblText.Text = "1st Week From: " & Monday1Week & "  To: " & Sunday1Week
            'lblText.Text = lblText.Text & "<br>2nd Week From: " & Monday2Week & "  To: " & Sunday2Week
            'lblText.Text = lblText.Text & "<br>3rd Week From: " & Monday3Week & "  To: " & Sunday3Week
            'lblText.Text = lblText.Text & "<br>4th  Week From: " & Monday4Week & "  To: " & Sunday4Week



            Dim row0 As String = ""

            If DropListLocation.SelectedItem.Text = "ALL" Then
                row0 = ""
            Else
                row0 = DropListLocation.SelectedItem.Text
            End If
            Dim rowTitle As String = " "

            Dim rowNumberOfCounters As String = "Number of counters"
            Dim rowNumberOfBusinessDat As String = "Number of Business dat"
            Dim rowNumberOfStaffs As String = "Number of Staffs"

            Dim rowCustomerVisit As String = "Customer Visit"
            Dim rowCallRegistered As String = "Call Registered"
            Dim rowRepairCompleted As String = "Repair Completed"
            Dim rowGoodsDelivered As String = "Goods Delivered"
            Dim rowPending As String = "Pending"
            Dim rowWarranty As String = "Warranty"
            Dim rowInWarranty As String = "InWarranty"
            Dim rowOutWarranty As String = "OutWarranty"
            Dim rowInWarrantyAmount As String = "InWarrantyAmount"
            Dim rowInWarrantyLabour As String = "InWarrantyLabour"
            Dim rowInWarrantyParts As String = "InWarrantyParts"
            Dim rowInWarrantyTransport As String = "InWarrantyTransport"
            Dim rowInWarrantyOthers As String = "InWarrantyOthers"
            Dim rowOutWarrantyAmount As String = "OutWarrantyAmount"
            Dim rowOutWarrantyLabour As String = "OutWarrantyLabour"
            Dim rowOutWarrantyParts As String = "OutWarrantyParts"
            Dim rowOutWarrantyTransport As String = "OutWarrantyTransport"
            Dim rowOutWarrantyOthers As String = "OutWarrantyOthers"
            Dim rowSawDiscountLabour As String = "SawDiscountLabour"
            Dim rowSawDiscountParts As String = "SawDiscountParts"
            Dim rowOutWarrantyLabourwSawDisc As String = "OutWarrantyLabourwSawDisc"
            Dim rowOutWarrantyPartswSawDisc As String = "OutWarrantyPartswSawDisc"
            Dim rowRevenueWithoutTax As String = "RevenueWithoutTax"
            Dim rowIwPartsConsumed As String = "IwPartsConsumed"
            Dim rowTotalPartsConsumed As String = "OutTotalPartsConsumed"
            Dim rowPrimeCostTotal As String = "PrimeCostTotal"
            Dim rowGrossProfit As String = "GrossProfit"

            Dim rowFinalPercentage As String = " "





            'For all ssc total 
            Dim SscTotals(6, 31) As String



            For Each item As ListItem In DropListLocation.Items
                If DropListLocation.SelectedItem.Text = "ALL" Then

                    If item.Text = "ALL" Then 'Skip 1st List when  "ALL" in the loop
                        Continue For
                    Else
                        'lblLoc.Text = lblLoc.Text & "<br>" & item.Text

                        'Monday1Week & Sunday1Week
                        strDay = Monday1Week.Day()
                        strMon = Monday1Week.Month
                        strYear = Monday1Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay


                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(Monday1Week, Sunday1Week, item.Text, item.Value, Gm)

                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                            row0 = row0 & "," & item.Text
                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & ","
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & ","
                            rowNumberOfStaffs = rowNumberOfStaffs & ","

                            rowCustomerVisit = rowCustomerVisit & ",0"
                            rowCallRegistered = rowCallRegistered & ",0"
                            rowRepairCompleted = rowRepairCompleted & ",0"
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit

                            'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")
                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit

                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                                row0 = row0 & "," & item.Text
                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit

                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                                'For Adding Final Report 
                                SscTotals(0, 0) = strDate 'Date

                                SscTotals(0, 1) = SscTotals(0, 1) + intNumberOfCounters 'rowNumberOfCounters
                                SscTotals(0, 2) = SscTotals(0, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                SscTotals(0, 3) = SscTotals(0, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                SscTotals(0, 4) = SscTotals(0, 4) + intCustomerVisit 'rowCustomerVisit
                                SscTotals(0, 5) = SscTotals(0, 5) + intCallRegistered 'rowCallRegistered
                                SscTotals(0, 6) = SscTotals(0, 6) + intRepairCompleted 'rowRepairCompleted
                                SscTotals(0, 7) = SscTotals(0, 7) + intGoodsDelivered 'rowGoodsDelivered
                                SscTotals(0, 8) = SscTotals(0, 8) + intPending 'rowPending
                                SscTotals(0, 9) = SscTotals(0, 9) + intWarranty 'rowWarranty
                                SscTotals(0, 10) = SscTotals(0, 10) + intInWarranty 'rowInWarranty
                                SscTotals(0, 11) = SscTotals(0, 11) + intOutWarranty 'rowOutWarranty
                                SscTotals(0, 12) = SscTotals(0, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                SscTotals(0, 13) = SscTotals(0, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                SscTotals(0, 14) = SscTotals(0, 14) + decInWarrantyParts 'rowInWarrantyParts
                                SscTotals(0, 15) = SscTotals(0, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                SscTotals(0, 16) = SscTotals(0, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                SscTotals(0, 17) = SscTotals(0, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                SscTotals(0, 18) = SscTotals(0, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                SscTotals(0, 19) = SscTotals(0, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                SscTotals(0, 20) = SscTotals(0, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                SscTotals(0, 21) = SscTotals(0, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                SscTotals(0, 22) = SscTotals(0, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                SscTotals(0, 23) = SscTotals(0, 23) + decSawDiscountParts 'rowSawDiscountParts
                                SscTotals(0, 24) = SscTotals(0, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                SscTotals(0, 25) = SscTotals(0, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                SscTotals(0, 26) = SscTotals(0, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                SscTotals(0, 27) = SscTotals(0, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                SscTotals(0, 28) = SscTotals(0, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                SscTotals(0, 29) = SscTotals(0, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                SscTotals(0, 30) = SscTotals(0, 30) + decGrossProfit 'rowGrossProfit 
                                SscTotals(0, 31) = SscTotals(0, 31) + decFinalPercentage 'rowFinalPercentage 


                            Next row
                        End If

                        'Monday2Week & Sunday2Week
                        strDay = Monday2Week.Day()
                        strMon = Monday2Week.Month
                        strYear = Monday2Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'strWeek2Tot
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(Monday2Week, Sunday2Week, item.Text, item.Value, Gm)
                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")

                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit

                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage


                                row0 = row0 & "," & item.Text
                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100




                                'For Adding Final Report 
                                SscTotals(1, 0) = strDate 'Date

                                SscTotals(1, 1) = SscTotals(1, 1) + intNumberOfCounters 'rowNumberOfCounters
                                SscTotals(1, 2) = SscTotals(1, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                SscTotals(1, 3) = SscTotals(1, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                SscTotals(1, 4) = SscTotals(1, 4) + intCustomerVisit 'rowCustomerVisit
                                SscTotals(1, 5) = SscTotals(1, 5) + intCallRegistered 'rowCallRegistered
                                SscTotals(1, 6) = SscTotals(1, 6) + intRepairCompleted 'rowRepairCompleted
                                SscTotals(1, 7) = SscTotals(1, 7) + intGoodsDelivered 'rowGoodsDelivered
                                SscTotals(1, 8) = SscTotals(1, 8) + intPending 'rowPending
                                SscTotals(1, 9) = SscTotals(1, 9) + intWarranty 'rowWarranty
                                SscTotals(1, 10) = SscTotals(1, 10) + intInWarranty 'rowInWarranty
                                SscTotals(1, 11) = SscTotals(1, 11) + intOutWarranty 'rowOutWarranty
                                SscTotals(1, 12) = SscTotals(1, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                SscTotals(1, 13) = SscTotals(1, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                SscTotals(1, 14) = SscTotals(1, 14) + decInWarrantyParts 'rowInWarrantyParts
                                SscTotals(1, 15) = SscTotals(1, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                SscTotals(1, 16) = SscTotals(1, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                SscTotals(1, 17) = SscTotals(1, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                SscTotals(1, 18) = SscTotals(1, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                SscTotals(1, 19) = SscTotals(1, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                SscTotals(1, 20) = SscTotals(1, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                SscTotals(1, 21) = SscTotals(1, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                SscTotals(1, 22) = SscTotals(1, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                SscTotals(1, 23) = SscTotals(1, 23) + decSawDiscountParts 'rowSawDiscountParts
                                SscTotals(1, 24) = SscTotals(1, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                SscTotals(1, 25) = SscTotals(1, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                SscTotals(1, 26) = SscTotals(1, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                SscTotals(1, 27) = SscTotals(1, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                SscTotals(1, 28) = SscTotals(1, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                SscTotals(1, 29) = SscTotals(1, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                SscTotals(1, 30) = SscTotals(1, 30) + decGrossProfit 'rowGrossProfit
                                SscTotals(1, 31) = SscTotals(1, 31) + decFinalPercentage 'rowFinalPercentage


                            Next row
                        End If


                        'Monday3Week & Sunday3Week
                        strDay = Monday3Week.Day()
                        strMon = Monday3Week.Month
                        strYear = Monday3Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(Monday3Week, Sunday3Week, item.Text, item.Value, Gm)

                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")

                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage


                                row0 = row0 & "," & item.Text
                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100



                                'For Adding Final Report 
                                SscTotals(2, 0) = strDate 'Date

                                SscTotals(2, 1) = SscTotals(2, 1) + intNumberOfCounters 'rowNumberOfCounters
                                SscTotals(2, 2) = SscTotals(2, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                SscTotals(2, 3) = SscTotals(2, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                SscTotals(2, 4) = SscTotals(2, 4) + intCustomerVisit 'rowCustomerVisit
                                SscTotals(2, 5) = SscTotals(2, 5) + intCallRegistered 'rowCallRegistered
                                SscTotals(2, 6) = SscTotals(2, 6) + intRepairCompleted 'rowRepairCompleted
                                SscTotals(2, 7) = SscTotals(2, 7) + intGoodsDelivered 'rowGoodsDelivered
                                SscTotals(2, 8) = SscTotals(2, 8) + intPending 'rowPending
                                SscTotals(2, 9) = SscTotals(2, 9) + intWarranty 'rowWarranty
                                SscTotals(2, 10) = SscTotals(2, 10) + intInWarranty 'rowInWarranty
                                SscTotals(2, 11) = SscTotals(2, 11) + intOutWarranty 'rowOutWarranty
                                SscTotals(2, 12) = SscTotals(2, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                SscTotals(2, 13) = SscTotals(2, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                SscTotals(2, 14) = SscTotals(2, 14) + decInWarrantyParts 'rowInWarrantyParts
                                SscTotals(2, 15) = SscTotals(2, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                SscTotals(2, 16) = SscTotals(2, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                SscTotals(2, 17) = SscTotals(2, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                SscTotals(2, 18) = SscTotals(2, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                SscTotals(2, 19) = SscTotals(2, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                SscTotals(2, 20) = SscTotals(2, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                SscTotals(2, 21) = SscTotals(2, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                SscTotals(2, 22) = SscTotals(2, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                SscTotals(2, 23) = SscTotals(2, 23) + decSawDiscountParts 'rowSawDiscountParts
                                SscTotals(2, 24) = SscTotals(2, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                SscTotals(2, 25) = SscTotals(2, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                SscTotals(2, 26) = SscTotals(2, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                SscTotals(2, 27) = SscTotals(2, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                SscTotals(2, 28) = SscTotals(2, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                SscTotals(2, 29) = SscTotals(2, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                SscTotals(2, 30) = SscTotals(2, 30) + decGrossProfit 'rowGrossProfit 
                                SscTotals(2, 31) = SscTotals(2, 31) + decFinalPercentage 'rowFinalPercentage

                            Next row
                        End If


                        'Monday4Week & Sunday4Week
                        strDay = Monday4Week.Day()
                        strMon = Monday4Week.Month
                        strYear = Monday4Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(Monday4Week, Sunday4Week, item.Text, item.Value, Gm)
                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")
                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage


                                row0 = row0 & "," & item.Text
                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage & "%"
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100



                                'For Adding Final Report 
                                SscTotals(3, 0) = strDate 'Date

                                SscTotals(3, 1) = SscTotals(3, 1) + intNumberOfCounters 'rowNumberOfCounters
                                SscTotals(3, 2) = SscTotals(3, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                SscTotals(3, 3) = SscTotals(3, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                SscTotals(3, 4) = SscTotals(3, 4) + intCustomerVisit 'rowCustomerVisit
                                SscTotals(3, 5) = SscTotals(3, 5) + intCallRegistered 'rowCallRegistered
                                SscTotals(3, 6) = SscTotals(3, 6) + intRepairCompleted 'rowRepairCompleted
                                SscTotals(3, 7) = SscTotals(3, 7) + intGoodsDelivered 'rowGoodsDelivered
                                SscTotals(3, 8) = SscTotals(3, 8) + intPending 'rowPending
                                SscTotals(3, 9) = SscTotals(3, 9) + intWarranty 'rowWarranty
                                SscTotals(3, 10) = SscTotals(3, 10) + intInWarranty 'rowInWarranty
                                SscTotals(3, 11) = SscTotals(3, 11) + intOutWarranty 'rowOutWarranty
                                SscTotals(3, 12) = SscTotals(3, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                SscTotals(3, 13) = SscTotals(3, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                SscTotals(3, 14) = SscTotals(3, 14) + decInWarrantyParts 'rowInWarrantyParts
                                SscTotals(3, 15) = SscTotals(3, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                SscTotals(3, 16) = SscTotals(3, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                SscTotals(3, 17) = SscTotals(3, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                SscTotals(3, 18) = SscTotals(3, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                SscTotals(3, 19) = SscTotals(3, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                SscTotals(3, 20) = SscTotals(3, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                SscTotals(3, 21) = SscTotals(3, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                SscTotals(3, 22) = SscTotals(3, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                SscTotals(3, 23) = SscTotals(3, 23) + decSawDiscountParts 'rowSawDiscountParts
                                SscTotals(3, 24) = SscTotals(3, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                SscTotals(3, 25) = SscTotals(3, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                SscTotals(3, 26) = SscTotals(3, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                SscTotals(3, 27) = SscTotals(3, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                SscTotals(3, 28) = SscTotals(3, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                SscTotals(3, 29) = SscTotals(3, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                SscTotals(3, 30) = SscTotals(3, 30) + decGrossProfit 'rowGrossProfit 
                                SscTotals(3, 31) = SscTotals(3, 31) + decFinalPercentage 'rowFinalPercentage


                            Next row
                        End If

                    End If


                Else
                    'lblLoc.Text = lblLoc.Text & "<br>" & DropListLocation.SelectedItem.Text

                    'Monday1Week & Sunday1Week
                    strDay = Monday1Week.Day()
                    strMon = Monday1Week.Month
                    strYear = Monday1Week.Year

                    If Len(strDay) <= 1 Then
                        strDay = "0" & strDay
                    End If
                    If Len(strMon) <= 1 Then
                        strMon = "0" & strMon
                    End If
                    strDate = strYear & strMon & strDay
                    'Read from 
                    _dtPlReprt = comcontrol.SelectPlReport(Monday1Week, Sunday1Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                    If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                    Else
                        For Each row As DataRow In _dtPlReprt.Rows

                            intNumberOfCounters = row.Item("NumberOfCounters")
                            intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                            intNumberOfStaffs = row.Item("NumberOfStaffs")

                            intCustomerVisit = row.Item("CustomerVisit")
                            intCallRegistered = row.Item("CallRegistered")
                            intRepairCompleted = row.Item("RepairCompleted")
                            intGoodsDelivered = row.Item("GoodsDelivered")
                            intPending = row.Item("Pending")
                            intWarranty = row.Item("Warranty")
                            intInWarranty = row.Item("InWarranty")
                            intOutWarranty = row.Item("OutWarranty")
                            decInWarrantyAmount = row.Item("InWarrantyAmount")
                            decInWarrantyLabour = row.Item("InWarrantyLabour")
                            decInWarrantyParts = row.Item("InWarrantyParts")
                            decInWarrantyTransport = row.Item("InWarrantyTransport")
                            decInWarrantyOthers = row.Item("InWarrantyOthers")
                            decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                            decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                            decOutWarrantyParts = row.Item("OutWarrantyParts")
                            decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                            decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                            decSawDiscountLabour = row.Item("SawDiscountLabour")
                            decSawDiscountParts = row.Item("SawDiscountParts")
                            decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                            decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                            decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                            decIwPartsConsumed = row.Item("IwPartsConsumed")
                            decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                            decPrimeCostTotal = row.Item("PrimeCostTotal")
                            decGrossProfit = row.Item("GrossProfit")
                            decFinalPercentage = row.Item("FinalPercentage")

                            intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                            intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                            intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                            intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                            intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                            intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                            intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                            intPendingTot = intPendingTot + intPending
                            intWarrantyTot = intWarrantyTot + intWarranty
                            intInWarrantyTot = intInWarrantyTot + intInWarranty
                            intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                            decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                            decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                            decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                            decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                            decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                            decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                            decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                            decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                            decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                            decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                            decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                            decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                            decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                            decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                            decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                            decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                            decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                            decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                            decGrossProfitTot = decGrossProfitTot + decGrossProfit

                            decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                            rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100

                        Next row
                    End If

                    'Monday2Week & Sunday2Week
                    strDay = Monday2Week.Day()
                    strMon = Monday2Week.Month
                    strYear = Monday2Week.Year

                    If Len(strDay) <= 1 Then
                        strDay = "0" & strDay
                    End If
                    If Len(strMon) <= 1 Then
                        strMon = "0" & strMon
                    End If
                    strDate = strYear & strMon & strDay
                    'Read from 
                    _dtPlReprt = comcontrol.SelectPlReport(Monday2Week, Sunday2Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)
                    If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                    Else
                        For Each row As DataRow In _dtPlReprt.Rows

                            intNumberOfCounters = row.Item("NumberOfCounters")
                            intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                            intNumberOfStaffs = row.Item("NumberOfStaffs")

                            intCustomerVisit = row.Item("CustomerVisit")
                            intCallRegistered = row.Item("CallRegistered")
                            intRepairCompleted = row.Item("RepairCompleted")
                            intGoodsDelivered = row.Item("GoodsDelivered")
                            intPending = row.Item("Pending")
                            intWarranty = row.Item("Warranty")
                            intInWarranty = row.Item("InWarranty")
                            intOutWarranty = row.Item("OutWarranty")
                            decInWarrantyAmount = row.Item("InWarrantyAmount")
                            decInWarrantyLabour = row.Item("InWarrantyLabour")
                            decInWarrantyParts = row.Item("InWarrantyParts")
                            decInWarrantyTransport = row.Item("InWarrantyTransport")
                            decInWarrantyOthers = row.Item("InWarrantyOthers")
                            decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                            decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                            decOutWarrantyParts = row.Item("OutWarrantyParts")
                            decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                            decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                            decSawDiscountLabour = row.Item("SawDiscountLabour")
                            decSawDiscountParts = row.Item("SawDiscountParts")
                            decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                            decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                            decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                            decIwPartsConsumed = row.Item("IwPartsConsumed")
                            decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                            decPrimeCostTotal = row.Item("PrimeCostTotal")
                            decGrossProfit = row.Item("GrossProfit")
                            decFinalPercentage = row.Item("FinalPercentage")

                            intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                            intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                            intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                            intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                            intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                            intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                            intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                            intPendingTot = intPendingTot + intPending
                            intWarrantyTot = intWarrantyTot + intWarranty
                            intInWarrantyTot = intInWarrantyTot + intInWarranty
                            intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                            decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                            decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                            decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                            decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                            decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                            decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                            decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                            decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                            decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                            decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                            decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                            decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                            decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                            decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                            decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                            decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                            decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                            decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                            decGrossProfitTot = decGrossProfitTot + decGrossProfit
                            decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                            rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100
                        Next row
                    End If


                    'Monday3Week & Sunday3Week
                    strDay = Monday3Week.Day()
                    strMon = Monday3Week.Month
                    strYear = Monday3Week.Year

                    If Len(strDay) <= 1 Then
                        strDay = "0" & strDay
                    End If
                    If Len(strMon) <= 1 Then
                        strMon = "0" & strMon
                    End If
                    strDate = strYear & strMon & strDay
                    'Read from 
                    _dtPlReprt = comcontrol.SelectPlReport(Monday3Week, Sunday3Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)
                    If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                    Else
                        For Each row As DataRow In _dtPlReprt.Rows

                            intNumberOfCounters = row.Item("NumberOfCounters")
                            intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                            intNumberOfStaffs = row.Item("NumberOfStaffs")

                            intCustomerVisit = row.Item("CustomerVisit")
                            intCallRegistered = row.Item("CallRegistered")
                            intRepairCompleted = row.Item("RepairCompleted")
                            intGoodsDelivered = row.Item("GoodsDelivered")
                            intPending = row.Item("Pending")
                            intWarranty = row.Item("Warranty")
                            intInWarranty = row.Item("InWarranty")
                            intOutWarranty = row.Item("OutWarranty")
                            decInWarrantyAmount = row.Item("InWarrantyAmount")
                            decInWarrantyLabour = row.Item("InWarrantyLabour")
                            decInWarrantyParts = row.Item("InWarrantyParts")
                            decInWarrantyTransport = row.Item("InWarrantyTransport")
                            decInWarrantyOthers = row.Item("InWarrantyOthers")
                            decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                            decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                            decOutWarrantyParts = row.Item("OutWarrantyParts")
                            decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                            decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                            decSawDiscountLabour = row.Item("SawDiscountLabour")
                            decSawDiscountParts = row.Item("SawDiscountParts")
                            decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                            decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                            decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                            decIwPartsConsumed = row.Item("IwPartsConsumed")
                            decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                            decPrimeCostTotal = row.Item("PrimeCostTotal")
                            decGrossProfit = row.Item("GrossProfit")
                            decFinalPercentage = row.Item("FinalPercentage")

                            intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                            intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                            intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                            intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                            intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                            intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                            intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                            intPendingTot = intPendingTot + intPending
                            intWarrantyTot = intWarrantyTot + intWarranty
                            intInWarrantyTot = intInWarrantyTot + intInWarranty
                            intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                            decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                            decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                            decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                            decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                            decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                            decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                            decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                            decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                            decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                            decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                            decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                            decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                            decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                            decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                            decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                            decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                            decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                            decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                            decGrossProfitTot = decGrossProfitTot + decGrossProfit
                            decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                            rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100
                        Next row
                    End If


                    'Monday4Week & Sunday4Week
                    strDay = Monday4Week.Day()
                    strMon = Monday4Week.Month
                    strYear = Monday4Week.Year

                    If Len(strDay) <= 1 Then
                        strDay = "0" & strDay
                    End If
                    If Len(strMon) <= 1 Then
                        strMon = "0" & strMon
                    End If
                    strDate = strYear & strMon & strDay
                    'Read from 
                    _dtPlReprt = comcontrol.SelectPlReport(Monday4Week, Sunday4Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                    If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                    Else
                        For Each row As DataRow In _dtPlReprt.Rows
                            intNumberOfCounters = row.Item("NumberOfCounters")
                            intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                            intNumberOfStaffs = row.Item("NumberOfStaffs")

                            intCustomerVisit = row.Item("CustomerVisit")
                            intCallRegistered = row.Item("CallRegistered")
                            intRepairCompleted = row.Item("RepairCompleted")
                            intGoodsDelivered = row.Item("GoodsDelivered")
                            intPending = row.Item("Pending")
                            intWarranty = row.Item("Warranty")
                            intInWarranty = row.Item("InWarranty")
                            intOutWarranty = row.Item("OutWarranty")
                            decInWarrantyAmount = row.Item("InWarrantyAmount")
                            decInWarrantyLabour = row.Item("InWarrantyLabour")
                            decInWarrantyParts = row.Item("InWarrantyParts")
                            decInWarrantyTransport = row.Item("InWarrantyTransport")
                            decInWarrantyOthers = row.Item("InWarrantyOthers")
                            decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                            decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                            decOutWarrantyParts = row.Item("OutWarrantyParts")
                            decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                            decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                            decSawDiscountLabour = row.Item("SawDiscountLabour")
                            decSawDiscountParts = row.Item("SawDiscountParts")
                            decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                            decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                            decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                            decIwPartsConsumed = row.Item("IwPartsConsumed")
                            decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                            decPrimeCostTotal = row.Item("PrimeCostTotal")
                            decGrossProfit = row.Item("GrossProfit")
                            decFinalPercentage = row.Item("FinalPercentage")

                            intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                            intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                            intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                            intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                            intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                            intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                            intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                            intPendingTot = intPendingTot + intPending
                            intWarrantyTot = intWarrantyTot + intWarranty
                            intInWarrantyTot = intInWarrantyTot + intInWarranty
                            intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                            decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                            decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                            decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                            decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                            decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                            decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                            decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                            decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                            decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                            decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                            decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                            decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                            decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                            decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                            decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                            decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                            decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                            decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                            decGrossProfitTot = decGrossProfitTot + decGrossProfit
                            decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                            rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100
                        Next row
                    End If


                    Exit For
                End If
            Next

            If DropListLocation.SelectedItem.Text = "ALL" Then
                'For Total Displa
                row0 = row0 & ",ALL SSC,ALL SSC,ALL SSC,ALL SSC"
                rowTitle = rowTitle & "," & SscTotals(0, 0) & "," & SscTotals(1, 0) & "," & SscTotals(2, 0) & "," & SscTotals(3, 0) & ",Total"

                rowNumberOfCounters = rowNumberOfCounters & "," & SscTotals(0, 1) & "," & SscTotals(1, 1) & "," & SscTotals(2, 1) & "," & SscTotals(3, 1) & "," & intNumberOfCountersTot
                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," & SscTotals(0, 2) & "," & SscTotals(1, 2) & "," & SscTotals(2, 2) & "," & SscTotals(3, 2) & "," & intNumberOfBusinessDatTot
                rowNumberOfStaffs = rowNumberOfStaffs & "," & SscTotals(0, 3) & "," & SscTotals(1, 3) & "," & SscTotals(2, 3) & "," & SscTotals(3, 3) & "," & intNumberOfStaffsTot

                rowCustomerVisit = rowCustomerVisit & "," & SscTotals(0, 4) & "," & SscTotals(1, 4) & "," & SscTotals(2, 4) & "," & SscTotals(3, 4) & "," & intCustomerVisitTot
                rowCallRegistered = rowCallRegistered & "," & SscTotals(0, 5) & "," & SscTotals(1, 5) & "," & SscTotals(2, 5) & "," & SscTotals(3, 5) & "," & intCallRegisteredTot
                rowRepairCompleted = rowRepairCompleted & "," & SscTotals(0, 6) & "," & SscTotals(1, 6) & "," & SscTotals(2, 6) & "," & SscTotals(3, 6) & "," & intRepairCompletedTot
                rowGoodsDelivered = rowGoodsDelivered & "," & SscTotals(0, 7) & "," & SscTotals(1, 7) & "," & SscTotals(2, 7) & "," & SscTotals(3, 7) & "," & intGoodsDeliveredTot
                rowPending = rowPending & "," & SscTotals(0, 8) & "," & SscTotals(1, 8) & "," & SscTotals(2, 8) & "," & SscTotals(3, 8) & "," & intPendingTot
                rowWarranty = rowWarranty & "," & SscTotals(0, 9) & "," & SscTotals(1, 9) & "," & SscTotals(2, 9) & "," & SscTotals(3, 9) & "," & intWarrantyTot
                rowInWarranty = rowInWarranty & "," & SscTotals(0, 10) & "," & SscTotals(1, 10) & "," & SscTotals(2, 10) & "," & SscTotals(3, 10) & "," & intInWarrantyTot
                rowOutWarranty = rowOutWarranty & "," & SscTotals(0, 11) & "," & SscTotals(1, 11) & "," & SscTotals(2, 11) & "," & SscTotals(3, 11) & "," & intOutWarrantyTot
                rowInWarrantyAmount = rowInWarrantyAmount & "," & SscTotals(0, 12) & "," & SscTotals(1, 12) & "," & SscTotals(2, 12) & "," & SscTotals(3, 12) & "," & decInWarrantyAmountTot
                rowInWarrantyLabour = rowInWarrantyLabour & "," & SscTotals(0, 13) & "," & SscTotals(1, 13) & "," & SscTotals(2, 13) & "," & SscTotals(3, 13) & "," & decInWarrantyLabourTot
                rowInWarrantyParts = rowInWarrantyParts & "," & SscTotals(0, 14) & "," & SscTotals(1, 14) & "," & SscTotals(2, 14) & "," & SscTotals(3, 14) & "," & decInWarrantyPartsTot
                rowInWarrantyTransport = rowInWarrantyTransport & "," & SscTotals(0, 15) & "," & SscTotals(1, 15) & "," & SscTotals(2, 15) & "," & SscTotals(3, 15) & "," & decInWarrantyTransportTot
                rowInWarrantyOthers = rowInWarrantyOthers & "," & SscTotals(0, 16) & "," & SscTotals(1, 16) & "," & SscTotals(2, 16) & "," & SscTotals(3, 16) & "," & decInWarrantyOthersTot
                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & SscTotals(0, 17) & "," & SscTotals(1, 17) & "," & SscTotals(2, 17) & "," & SscTotals(3, 17) & "," & decOutWarrantyAmountTot
                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & SscTotals(0, 18) & "," & SscTotals(1, 18) & "," & SscTotals(2, 18) & "," & SscTotals(3, 18) & "," & decOutWarrantyLabourTot
                rowOutWarrantyParts = rowOutWarrantyParts & "," & SscTotals(0, 19) & "," & SscTotals(1, 19) & "," & SscTotals(2, 19) & "," & SscTotals(3, 19) & "," & decOutWarrantyPartsTot
                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & SscTotals(0, 20) & "," & SscTotals(1, 20) & "," & SscTotals(2, 20) & "," & SscTotals(3, 20) & "," & decOutWarrantyTransportTot
                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & SscTotals(0, 21) & "," & SscTotals(1, 21) & "," & SscTotals(2, 21) & "," & SscTotals(3, 21) & "," & decOutWarrantyOthersTot
                rowSawDiscountLabour = rowSawDiscountLabour & "," & SscTotals(0, 22) & "," & SscTotals(1, 22) & "," & SscTotals(2, 22) & "," & SscTotals(3, 22) & "," & decSawDiscountLabourTot
                rowSawDiscountParts = rowSawDiscountParts & "," & SscTotals(0, 23) & "," & SscTotals(1, 23) & "," & SscTotals(2, 23) & "," & SscTotals(3, 23) & "," & decSawDiscountPartsTot
                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & SscTotals(0, 24) & "," & SscTotals(1, 24) & "," & SscTotals(2, 24) & "," & SscTotals(3, 24) & "," & decOutWarrantyLabourwSawDiscTot
                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & SscTotals(0, 25) & "," & SscTotals(1, 25) & "," & SscTotals(2, 25) & "," & SscTotals(3, 25) & "," & decOutWarrantyPartswSawDiscTot
                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & SscTotals(0, 26) & "," & SscTotals(1, 26) & "," & SscTotals(2, 26) & "," & SscTotals(3, 26) & "," & decRevenueWithoutTaxTot
                rowIwPartsConsumed = rowIwPartsConsumed & "," & SscTotals(0, 27) & "," & SscTotals(1, 27) & "," & SscTotals(2, 27) & "," & SscTotals(3, 27) & "," & decIwPartsConsumedTot
                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & SscTotals(0, 28) & "," & SscTotals(1, 28) & "," & SscTotals(2, 28) & "," & SscTotals(3, 28) & "," & decTotalPartsConsumedTot
                rowPrimeCostTotal = rowPrimeCostTotal & "," & SscTotals(0, 29) & "," & SscTotals(1, 29) & "," & SscTotals(2, 29) & "," & SscTotals(3, 29) & "," & decPrimeCostTotalTot
                rowGrossProfit = rowGrossProfit & "," & SscTotals(0, 30) & "," & SscTotals(1, 30) & "," & SscTotals(2, 30) & "," & SscTotals(3, 30) & "," & decGrossProfitTot
                'rowFinalPercentage = rowFinalPercentage & "," & SscTotals(0, 31) & "," & SscTotals(1, 31) & "," & SscTotals(2, 31) & "," & SscTotals(3, 31) & "," & decGrossProfitTot



                If SscTotals(0, 26) = 0 Then ' RevenueWithoutTax = 0
                    SscTotals031 = SscTotals(0, 30) 'GrossProfit
                Else
                    SscTotals031 = comcontrol.Money_Round((SscTotals(0, 30) / SscTotals(0, 26)) * 100, 2)
                End If
                If SscTotals(1, 26) = 0 Then ' RevenueWithoutTax = 0
                    SscTotals131 = SscTotals(1, 30) 'GrossProfit
                Else
                    SscTotals131 = comcontrol.Money_Round((SscTotals(1, 30) / SscTotals(1, 26)) * 100, 2)
                End If
                If SscTotals(2, 26) = 0 Then ' RevenueWithoutTax = 0
                    SscTotals231 = SscTotals(2, 30) 'GrossProfit
                Else
                    SscTotals231 = comcontrol.Money_Round((SscTotals(2, 30) / SscTotals(2, 26)) * 100, 2)
                End If
                If SscTotals(3, 26) = 0 Then ' RevenueWithoutTax = 0
                    SscTotals331 = SscTotals(3, 30) 'GrossProfit
                Else
                    SscTotals331 = comcontrol.Money_Round((SscTotals(3, 30) / SscTotals(3, 26)) * 100, 2)
                End If
                If decRevenueWithoutTaxTot = 0 Then ' RevenueWithoutTax = 0
                    _FinalPercentage = decGrossProfitTot 'GrossProfit
                Else
                    _FinalPercentage = comcontrol.Money_Round((decGrossProfitTot / decRevenueWithoutTaxTot) * 100, 2)
                End If
                rowFinalPercentage = rowFinalPercentage & "," & SscTotals031 & "%" & "," & SscTotals131 & "%" & "," & SscTotals231 & "%" & "," & SscTotals331 & "%" & "," & _FinalPercentage & "%"

                'For Display End of Label
                rowTitle = rowTitle & ","

                rowNumberOfCounters = rowNumberOfCounters & "," & "Number of counters"
                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," & "Number of Business dat"
                rowNumberOfStaffs = rowNumberOfStaffs & "," & "Number of Staffs"

                rowCustomerVisit = rowCustomerVisit & "," & "CustomerVisit"
                rowCallRegistered = rowCallRegistered & "," & "CallRegistered"
                rowRepairCompleted = rowRepairCompleted & "," & "RepairCompleted"
                rowGoodsDelivered = rowGoodsDelivered & "," & "GoodsDelivered"
                rowPending = rowPending & "," & "Pending"
                rowWarranty = rowWarranty & "," & "Warranty"
                rowInWarranty = rowInWarranty & "," & "InWarranty"
                rowOutWarranty = rowOutWarranty & "," & "OutWarranty"
                rowInWarrantyAmount = rowInWarrantyAmount & "," & "InWarrantyAmount"
                rowInWarrantyLabour = rowInWarrantyLabour & "," & "InWarrantyLabour"
                rowInWarrantyParts = rowInWarrantyParts & "," & "InWarrantyParts"
                rowInWarrantyTransport = rowInWarrantyTransport & "," & "InWarrantyTransport"
                rowInWarrantyOthers = rowInWarrantyOthers & "," & "InWarrantyOthers"
                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & "OutWarrantyAmount"
                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & "OutWarrantyLabour"
                rowOutWarrantyParts = rowOutWarrantyParts & "," & "OutWarrantyParts"
                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & "OutWarrantyTransport"
                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & "OutWarrantyOthers"
                rowSawDiscountLabour = rowSawDiscountLabour & "," & "SawDiscountLabour"
                rowSawDiscountParts = rowSawDiscountParts & "," & "SawDiscountParts"
                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & "OutWarrantyLabourwSawDisc"
                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & "OutWarrantyPartswSawDisc"
                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & "RevenueWithoutTax"
                rowIwPartsConsumed = rowIwPartsConsumed & "," & "IwPartsConsumed"
                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & "TotalPartsConsumed"
                rowPrimeCostTotal = rowPrimeCostTotal & "," & "PrimeCostTotal"
                rowGrossProfit = rowGrossProfit & "," & "GrossProfit"
                rowFinalPercentage = rowFinalPercentage & "," & " "

            Else
                'For Total Displa
                rowTitle = rowTitle & ",Total"

                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisitTot
                rowCallRegistered = rowCallRegistered & "," & intCallRegisteredTot
                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompletedTot
                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDeliveredTot
                rowPending = rowPending & "," & intPendingTot
                rowWarranty = rowWarranty & "," & intWarrantyTot
                rowInWarranty = rowInWarranty & "," & intInWarrantyTot
                rowOutWarranty = rowOutWarranty & "," & intOutWarrantyTot
                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmountTot
                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabourTot
                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyPartsTot
                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransportTot
                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthersTot
                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmountTot
                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabourTot
                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyPartsTot
                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransportTot
                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthersTot
                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabourTot
                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountPartsTot
                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDiscTot
                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDiscTot
                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTaxTot
                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumedTot
                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumedTot
                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotalTot
                rowGrossProfit = rowGrossProfit & "," & decGrossProfitTot
                rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage

                'For Display End of Label
                rowTitle = rowTitle & ","
                rowNumberOfCounters = rowNumberOfCounters & "," & "Number of counters"
                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," & "Number of Business dat"
                rowNumberOfStaffs = rowNumberOfStaffs & "," & "Number of Staffs"

                rowCustomerVisit = rowCustomerVisit & "," & "CustomerVisit"
                rowCallRegistered = rowCallRegistered & "," & "CallRegistered"
                rowRepairCompleted = rowRepairCompleted & "," & "RepairCompleted"
                rowGoodsDelivered = rowGoodsDelivered & "," & "GoodsDelivered"
                rowPending = rowPending & "," & "Pending"
                rowWarranty = rowWarranty & "," & "Warranty"
                rowInWarranty = rowInWarranty & "," & "InWarranty"
                rowOutWarranty = rowOutWarranty & "," & "OutWarranty"
                rowInWarrantyAmount = rowInWarrantyAmount & "," & "InWarrantyAmount"
                rowInWarrantyLabour = rowInWarrantyLabour & "," & "InWarrantyLabour"
                rowInWarrantyParts = rowInWarrantyParts & "," & "InWarrantyParts"
                rowInWarrantyTransport = rowInWarrantyTransport & "," & "InWarrantyTransport"
                rowInWarrantyOthers = rowInWarrantyOthers & "," & "InWarrantyOthers"
                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & "OutWarrantyAmount"
                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & "OutWarrantyLabour"
                rowOutWarrantyParts = rowOutWarrantyParts & "," & "OutWarrantyParts"
                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & "OutWarrantyTransport"
                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & "OutWarrantyOthers"
                rowSawDiscountLabour = rowSawDiscountLabour & "," & "SawDiscountLabour"
                rowSawDiscountParts = rowSawDiscountParts & "," & "SawDiscountParts"
                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & "OutWarrantyLabourwSawDisc"
                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & "OutWarrantyPartswSawDisc"
                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & "RevenueWithoutTax"
                rowIwPartsConsumed = rowIwPartsConsumed & "," & "IwPartsConsumed"
                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & "TotalPartsConsumed"
                rowPrimeCostTotal = rowPrimeCostTotal & "," & "PrimeCostTotal"
                rowGrossProfit = rowGrossProfit & "," & "GrossProfit"

                rowFinalPercentage = rowFinalPercentage & "," & " "


            End If



            csvContents.Add(row0)
            csvContents.Add(rowTitle)

            csvContents.Add(rowNumberOfCounters)
            csvContents.Add(rowNumberOfBusinessDat)
            csvContents.Add(rowNumberOfStaffs)

            csvContents.Add(rowCustomerVisit)
            csvContents.Add(rowCallRegistered)
            csvContents.Add(rowRepairCompleted)
            csvContents.Add(rowGoodsDelivered)
            csvContents.Add(rowPending)
            csvContents.Add(rowWarranty)
            csvContents.Add(rowInWarranty)
            csvContents.Add(rowOutWarranty)
            csvContents.Add(rowInWarrantyAmount)
            csvContents.Add(rowInWarrantyLabour)
            csvContents.Add(rowInWarrantyParts)
            csvContents.Add(rowInWarrantyTransport)
            csvContents.Add(rowInWarrantyOthers)
            csvContents.Add(rowOutWarrantyAmount)
            csvContents.Add(rowOutWarrantyLabour)
            csvContents.Add(rowOutWarrantyParts)
            csvContents.Add(rowOutWarrantyTransport)
            csvContents.Add(rowOutWarrantyOthers)
            csvContents.Add(rowSawDiscountLabour)
            csvContents.Add(rowSawDiscountParts)
            csvContents.Add(rowOutWarrantyLabourwSawDisc)
            csvContents.Add(rowOutWarrantyPartswSawDisc)
            csvContents.Add(rowRevenueWithoutTax)
            csvContents.Add(rowIwPartsConsumed)
            csvContents.Add(rowTotalPartsConsumed)
            csvContents.Add(rowPrimeCostTotal)
            csvContents.Add(rowGrossProfit)
            csvContents.Add(rowFinalPercentage)

            Dim csvFileName As String

            Dim clsSetCommon As New Class_common
            Dim dtNow As DateTime = clsSetCommon.dtIndia
            Dim exportFile As String = ""

            Dim outputPath As String

            'PeriodFrom = Replace(PeriodFrom, "/", "")
            'PeriodTo = Replace(PeriodTo, "/", "")

            strDay = Now.Day()
            strMon = Now.Month
            strYear = Now.Year

            If Len(strDay) <= 1 Then
                strDay = "0" & strDay
            End If
            If Len(strMon) <= 1 Then
                strMon = "0" & strMon
            End If

            If DropListLocation.SelectedItem.Text = "ALL" Then
                csvFileName = "SM_4WEEK_PL_ALL_" & strYear & strMon & strDay & ".csv"
            Else
                csvFileName = "SM_4WEEK_PL_" & DropListLocation.SelectedItem.Text & "_" & strYear & strMon & strDay & ".csv"
            End If



            outputPath = clsSet.CsvFilePass & csvFileName

            ' outputPath = csvFileName

            Using writer As New StreamWriter(outputPath, False, Encoding.Default)
                writer.WriteLine(String.Join(Environment.NewLine, csvContents))
            End Using

            Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)
            If outputPath <> "" Then
                If System.IO.File.Exists(outputPath) = True Then
                    System.IO.File.Delete(outputPath)
                End If
            End If
            Response.Clear()
            Response.Clear()
            Response.ClearHeaders()
            Response.Buffer = True
            Response.ContentType = "application/text/csv"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)

            'Response.Write("<b>File Contents: </b>")
            Response.BinaryWrite(Buffer)

            Response.Flush()
            'Response.WriteFile(outputPath) 'if not required dialog box to user, then make comment this line
            Response.End()








            '****************************************
            'Monthly 
            'Begin
            '****************************************
        ElseIf DrpType.SelectedItem.Value = "02" Then ' Monthly


            strDay = 1
            strMon = DropDownMonth.SelectedItem.Value
            strYear = DropDownYear.SelectedItem.Text

            'For FileName
            Dim PeriodFrom As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)

            Dim mon As Integer
            'De
            Dim monMonday1Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)

            'lblText.Text = monMonday1Week & "<br>" & monMonday1Week.DayOfWeek

            If (monMonday1Week.DayOfWeek = 0) Then
                'Sunday
                monMonday1Week = monMonday1Week.AddDays(-6) 'Need to start Monday from previous month
            ElseIf (monMonday1Week.DayOfWeek = 1) Then
                'Monday

            ElseIf (monMonday1Week.DayOfWeek = 2) Then
                'Tuesday
                monMonday1Week = monMonday1Week.AddDays(-1)
            ElseIf (monMonday1Week.DayOfWeek = 3) Then
                'Wednesday
                monMonday1Week = monMonday1Week.AddDays(-2)
            ElseIf (monMonday1Week.DayOfWeek = 4) Then
                'Thursday
                monMonday1Week = monMonday1Week.AddDays(-3)
            ElseIf (monMonday1Week.DayOfWeek = 5) Then
                'Friday
                monMonday1Week = monMonday1Week.AddDays(-4)
            ElseIf (monMonday1Week.DayOfWeek = 6) Then
                'Saturday
                monMonday1Week = monMonday1Week.AddDays(-5)
            End If

            Dim monSunday1Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            monSunday1Week = monMonday1Week.AddDays(6)

            Dim monMonday2Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim monSunday2Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            monMonday2Week = monSunday1Week.AddDays(1)
            monSunday2Week = monMonday2Week.AddDays(6)

            Dim monMonday3Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim monSunday3Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            monMonday3Week = monSunday2Week.AddDays(1)
            monSunday3Week = monMonday3Week.AddDays(6)

            Dim monMonday4Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim monSunday4Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            monMonday4Week = monSunday3Week.AddDays(1)
            monSunday4Week = monMonday4Week.AddDays(6)

            Dim monMonday5Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim monSunday5Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)

            Dim LastDayOfMonth As Integer
            LastDayOfMonth = System.DateTime.DaysInMonth(monMonday4Week.Year, monMonday4Week.Month)

            Dim blWeek5 As Boolean = False

            'Verify that date is more than from current date 
            If monSunday4Week.Day > monMonday4Week.Day Then
                If monSunday4Week.Day = LastDayOfMonth Then
                    'No need Next date
                ElseIf monSunday4Week.Day < LastDayOfMonth Then
                    monMonday5Week = monSunday4Week.AddDays(1)
                    monSunday5Week = monMonday5Week.AddDays(6)
                    blWeek5 = True
                End If
            End If

            Dim monMonday6Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim monSunday6Week As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            'lblText.Text = monSunday5Week.Day & " < " & LastDayOfMonth
            Dim blWeek6 As Boolean = False
            If monSunday5Week.Day > monMonday5Week.Day Then

                If monSunday5Week.Day = LastDayOfMonth Then
                    'No need Next date
                ElseIf monSunday5Week.Day < LastDayOfMonth Then
                    monMonday6Week = monSunday5Week.AddDays(1)
                    monSunday6Week = monMonday6Week.AddDays(6)
                    blWeek6 = True
                End If
            End If

            'For all ssc total 
            Dim SscTotals(6, 31) As String

            ''2nd Month
            'lblLoc.Text = "1st Week From: " & monMonday1Week & "  To: " & monSunday1Week
            'lblLoc.Text = lblLoc.Text & "<br>2nd Week From: " & monMonday2Week & "  To: " & monSunday2Week
            'lblLoc.Text = lblLoc.Text & "<br>3rd Week From: " & monMonday3Week & "  To: " & monSunday3Week
            'lblLoc.Text = lblLoc.Text & "<br>4th  Week From: " & monMonday4Week & "  To: " & monSunday4Week
            'If blWeek5 Then
            '    lblLoc.Text = lblLoc.Text & "<br>5th  Week From: " & monMonday5Week & "  To: " & monSunday5Week
            'End If
            'If blWeek6 Then
            '    lblLoc.Text = lblLoc.Text & "<br>6th  Week From: " & monMonday6Week & "  To: " & monSunday6Week
            'End If
            Dim row0 As String = ""

            If DropListLocation.SelectedItem.Text = "ALL" Then
                row0 = ""
            Else
                row0 = DropListLocation.SelectedItem.Text
            End If
            Dim rowTitle As String = " "
            Dim rowNumberOfCounters As String = "Number of counters"
            Dim rowNumberOfBusinessDat As String = "Number of Business dat"
            Dim rowNumberOfStaffs As String = "Number of Staffs"

            Dim rowCustomerVisit As String = "Customer Visit"
            Dim rowCallRegistered As String = "Call Registered"
            Dim rowRepairCompleted As String = "Repair Completed"
            Dim rowGoodsDelivered As String = "Goods Delivered"
            Dim rowPending As String = "Pending"
            Dim rowWarranty As String = "Warranty"
            Dim rowInWarranty As String = "InWarranty"
            Dim rowOutWarranty As String = "OutWarranty"
            Dim rowInWarrantyAmount As String = "InWarrantyAmount"
            Dim rowInWarrantyLabour As String = "InWarrantyLabour"
            Dim rowInWarrantyParts As String = "InWarrantyParts"
            Dim rowInWarrantyTransport As String = "InWarrantyTransport"
            Dim rowInWarrantyOthers As String = "InWarrantyOthers"
            Dim rowOutWarrantyAmount As String = "OutWarrantyAmount"
            Dim rowOutWarrantyLabour As String = "OutWarrantyLabour"
            Dim rowOutWarrantyParts As String = "OutWarrantyParts"
            Dim rowOutWarrantyTransport As String = "OutWarrantyTransport"
            Dim rowOutWarrantyOthers As String = "OutWarrantyOthers"
            Dim rowSawDiscountLabour As String = "SawDiscountLabour"
            Dim rowSawDiscountParts As String = "SawDiscountParts"
            Dim rowOutWarrantyLabourwSawDisc As String = "OutWarrantyLabourwSawDisc"
            Dim rowOutWarrantyPartswSawDisc As String = "OutWarrantyPartswSawDisc"
            Dim rowRevenueWithoutTax As String = "RevenueWithoutTax"
            Dim rowIwPartsConsumed As String = "IwPartsConsumed"
            Dim rowTotalPartsConsumed As String = "OutTotalPartsConsumed"
            Dim rowPrimeCostTotal As String = "PrimeCostTotal"
            Dim rowGrossProfit As String = "GrossProfit"
            Dim rowFinalPercentage As String = " "


            For Each item As ListItem In DropListLocation.Items
                If DropListLocation.SelectedItem.Text = "ALL" Then

                    If item.Text = "ALL" Then 'Skip 1st List when  "ALL" in the loop
                        Continue For
                    Else
                        'monMonday1Week & monSunday1Week
                        strDay = monMonday1Week.Day()
                        strMon = monMonday1Week.Month
                        strYear = monMonday1Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(monMonday1Week, monSunday1Week, item.Text, item.Value, Gm)

                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows
                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")
                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                                row0 = row0 & "," & item.Text
                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                                'For Adding Final Report 
                                SscTotals(0, 0) = strDate 'Date

                                SscTotals(0, 1) = SscTotals(0, 1) + intNumberOfCounters 'rowNumberOfCounters
                                SscTotals(0, 2) = SscTotals(0, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                SscTotals(0, 3) = SscTotals(0, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                SscTotals(0, 4) = SscTotals(0, 4) + intCustomerVisit 'rowCustomerVisit
                                SscTotals(0, 5) = SscTotals(0, 5) + intCallRegistered 'rowCallRegistered
                                SscTotals(0, 6) = SscTotals(0, 6) + intRepairCompleted 'rowRepairCompleted
                                SscTotals(0, 7) = SscTotals(0, 7) + intGoodsDelivered 'rowGoodsDelivered
                                SscTotals(0, 8) = SscTotals(0, 8) + intPending 'rowPending
                                SscTotals(0, 9) = SscTotals(0, 9) + intWarranty 'rowWarranty
                                SscTotals(0, 10) = SscTotals(0, 10) + intInWarranty 'rowInWarranty
                                SscTotals(0, 11) = SscTotals(0, 11) + intOutWarranty 'rowOutWarranty
                                SscTotals(0, 12) = SscTotals(0, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                SscTotals(0, 13) = SscTotals(0, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                SscTotals(0, 14) = SscTotals(0, 14) + decInWarrantyParts 'rowInWarrantyParts
                                SscTotals(0, 15) = SscTotals(0, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                SscTotals(0, 16) = SscTotals(0, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                SscTotals(0, 17) = SscTotals(0, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                SscTotals(0, 18) = SscTotals(0, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                SscTotals(0, 19) = SscTotals(0, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                SscTotals(0, 20) = SscTotals(0, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                SscTotals(0, 21) = SscTotals(0, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                SscTotals(0, 22) = SscTotals(0, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                SscTotals(0, 23) = SscTotals(0, 23) + decSawDiscountParts 'rowSawDiscountParts
                                SscTotals(0, 24) = SscTotals(0, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                SscTotals(0, 25) = SscTotals(0, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                SscTotals(0, 26) = SscTotals(0, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                SscTotals(0, 27) = SscTotals(0, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                SscTotals(0, 28) = SscTotals(0, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                SscTotals(0, 29) = SscTotals(0, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                SscTotals(0, 30) = SscTotals(0, 30) + decGrossProfit 'rowGrossProfit 
                                SscTotals(0, 31) = SscTotals(0, 31) + decFinalPercentage 'rowFinalPercentage 



                            Next row
                        End If

                        'monMonday2Week & monSunday2Week
                        strDay = monMonday2Week.Day()
                        strMon = monMonday2Week.Month
                        strYear = monMonday2Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(monMonday2Week, monSunday2Week, item.Text, item.Value, Gm)
                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")
                                decFinalPercentage = row.Item("FinalPercentage")


                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                                row0 = row0 & "," & item.Text
                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                                'For Adding Final Report 
                                SscTotals(1, 0) = strDate 'Date

                                SscTotals(1, 1) = SscTotals(1, 1) + intNumberOfCounters 'rowNumberOfCounters
                                SscTotals(1, 2) = SscTotals(1, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                SscTotals(1, 3) = SscTotals(1, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                SscTotals(1, 4) = SscTotals(1, 4) + intCustomerVisit 'rowCustomerVisit
                                SscTotals(1, 5) = SscTotals(1, 5) + intCallRegistered 'rowCallRegistered
                                SscTotals(1, 6) = SscTotals(1, 6) + intRepairCompleted 'rowRepairCompleted
                                SscTotals(1, 7) = SscTotals(1, 7) + intGoodsDelivered 'rowGoodsDelivered
                                SscTotals(1, 8) = SscTotals(1, 8) + intPending 'rowPending
                                SscTotals(1, 9) = SscTotals(1, 9) + intWarranty 'rowWarranty
                                SscTotals(1, 10) = SscTotals(1, 10) + intInWarranty 'rowInWarranty
                                SscTotals(1, 11) = SscTotals(1, 11) + intOutWarranty 'rowOutWarranty
                                SscTotals(1, 12) = SscTotals(1, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                SscTotals(1, 13) = SscTotals(1, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                SscTotals(1, 14) = SscTotals(1, 14) + decInWarrantyParts 'rowInWarrantyParts
                                SscTotals(1, 15) = SscTotals(1, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                SscTotals(1, 16) = SscTotals(1, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                SscTotals(1, 17) = SscTotals(1, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                SscTotals(1, 18) = SscTotals(1, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                SscTotals(1, 19) = SscTotals(1, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                SscTotals(1, 20) = SscTotals(1, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                SscTotals(1, 21) = SscTotals(1, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                SscTotals(1, 22) = SscTotals(1, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                SscTotals(1, 23) = SscTotals(1, 23) + decSawDiscountParts 'rowSawDiscountParts
                                SscTotals(1, 24) = SscTotals(1, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                SscTotals(1, 25) = SscTotals(1, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                SscTotals(1, 26) = SscTotals(1, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                SscTotals(1, 27) = SscTotals(1, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                SscTotals(1, 28) = SscTotals(1, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                SscTotals(1, 29) = SscTotals(1, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                SscTotals(1, 30) = SscTotals(1, 30) + decGrossProfit 'rowGrossProfit
                                SscTotals(1, 31) = SscTotals(1, 31) + decFinalPercentage 'rowFinalPercentage


                            Next row
                        End If



                        'monMonday3Week & monSunday3Week
                        strDay = monMonday3Week.Day()
                        strMon = monMonday3Week.Month
                        strYear = monMonday3Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(monMonday3Week, monSunday3Week, item.Text, item.Value, Gm)
                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")
                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage


                                row0 = row0 & "," & item.Text
                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                                'For Adding Final Report 
                                SscTotals(2, 0) = strDate 'Date

                                SscTotals(2, 1) = SscTotals(2, 1) + intNumberOfCounters 'rowNumberOfCounters
                                SscTotals(2, 2) = SscTotals(2, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                SscTotals(2, 3) = SscTotals(2, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                SscTotals(2, 4) = SscTotals(2, 4) + intCustomerVisit 'rowCustomerVisit
                                SscTotals(2, 5) = SscTotals(2, 5) + intCallRegistered 'rowCallRegistered
                                SscTotals(2, 6) = SscTotals(2, 6) + intRepairCompleted 'rowRepairCompleted
                                SscTotals(2, 7) = SscTotals(2, 7) + intGoodsDelivered 'rowGoodsDelivered
                                SscTotals(2, 8) = SscTotals(2, 8) + intPending 'rowPending
                                SscTotals(2, 9) = SscTotals(2, 9) + intWarranty 'rowWarranty
                                SscTotals(2, 10) = SscTotals(2, 10) + intInWarranty 'rowInWarranty
                                SscTotals(2, 11) = SscTotals(2, 11) + intOutWarranty 'rowOutWarranty
                                SscTotals(2, 12) = SscTotals(2, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                SscTotals(2, 13) = SscTotals(2, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                SscTotals(2, 14) = SscTotals(2, 14) + decInWarrantyParts 'rowInWarrantyParts
                                SscTotals(2, 15) = SscTotals(2, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                SscTotals(2, 16) = SscTotals(2, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                SscTotals(2, 17) = SscTotals(2, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                SscTotals(2, 18) = SscTotals(2, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                SscTotals(2, 19) = SscTotals(2, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                SscTotals(2, 20) = SscTotals(2, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                SscTotals(2, 21) = SscTotals(2, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                SscTotals(2, 22) = SscTotals(2, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                SscTotals(2, 23) = SscTotals(2, 23) + decSawDiscountParts 'rowSawDiscountParts
                                SscTotals(2, 24) = SscTotals(2, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                SscTotals(2, 25) = SscTotals(2, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                SscTotals(2, 26) = SscTotals(2, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                SscTotals(2, 27) = SscTotals(2, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                SscTotals(2, 28) = SscTotals(2, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                SscTotals(2, 29) = SscTotals(2, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                SscTotals(2, 30) = SscTotals(2, 30) + decGrossProfit 'rowGrossProfit 
                                SscTotals(2, 31) = SscTotals(2, 31) + decFinalPercentage 'rowFinalPercentage


                            Next row
                        End If

                        'monMonday4Week & monSunday4Week
                        strDay = monMonday4Week.Day()
                        strMon = monMonday4Week.Month
                        strYear = monMonday4Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(monMonday4Week, monSunday4Week, item.Text, item.Value, Gm)
                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")
                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                                row0 = row0 & "," & item.Text
                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                                'For Adding Final Report 
                                SscTotals(3, 0) = strDate 'Date

                                SscTotals(3, 1) = SscTotals(3, 1) + intNumberOfCounters 'rowNumberOfCounters
                                SscTotals(3, 2) = SscTotals(3, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                SscTotals(3, 3) = SscTotals(3, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                SscTotals(3, 4) = SscTotals(3, 4) + intCustomerVisit 'rowCustomerVisit
                                SscTotals(3, 5) = SscTotals(3, 5) + intCallRegistered 'rowCallRegistered
                                SscTotals(3, 6) = SscTotals(3, 6) + intRepairCompleted 'rowRepairCompleted
                                SscTotals(3, 7) = SscTotals(3, 7) + intGoodsDelivered 'rowGoodsDelivered
                                SscTotals(3, 8) = SscTotals(3, 8) + intPending 'rowPending
                                SscTotals(3, 9) = SscTotals(3, 9) + intWarranty 'rowWarranty
                                SscTotals(3, 10) = SscTotals(3, 10) + intInWarranty 'rowInWarranty
                                SscTotals(3, 11) = SscTotals(3, 11) + intOutWarranty 'rowOutWarranty
                                SscTotals(3, 12) = SscTotals(3, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                SscTotals(3, 13) = SscTotals(3, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                SscTotals(3, 14) = SscTotals(3, 14) + decInWarrantyParts 'rowInWarrantyParts
                                SscTotals(3, 15) = SscTotals(3, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                SscTotals(3, 16) = SscTotals(3, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                SscTotals(3, 17) = SscTotals(3, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                SscTotals(3, 18) = SscTotals(3, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                SscTotals(3, 19) = SscTotals(3, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                SscTotals(3, 20) = SscTotals(3, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                SscTotals(3, 21) = SscTotals(3, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                SscTotals(3, 22) = SscTotals(3, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                SscTotals(3, 23) = SscTotals(3, 23) + decSawDiscountParts 'rowSawDiscountParts
                                SscTotals(3, 24) = SscTotals(3, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                SscTotals(3, 25) = SscTotals(3, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                SscTotals(3, 26) = SscTotals(3, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                SscTotals(3, 27) = SscTotals(3, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                SscTotals(3, 28) = SscTotals(3, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                SscTotals(3, 29) = SscTotals(3, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                SscTotals(3, 30) = SscTotals(3, 30) + decGrossProfit 'rowGrossProfit 
                                SscTotals(3, 31) = SscTotals(3, 31) + decFinalPercentage 'rowFinalPercentage



                            Next row
                        End If

                        'monMonday5Week & monSunday5Week
                        If blWeek5 Then
                            ' lblLoc.Text = lblLoc.Text & "<br>5th  Week From: " & monMonday5Week & "  To: " & monSunday5Week
                            strDay = monMonday5Week.Day()
                            strMon = monMonday5Week.Month
                            strYear = monMonday5Week.Year

                            If Len(strDay) <= 1 Then
                                strDay = "0" & strDay
                            End If
                            If Len(strMon) <= 1 Then
                                strMon = "0" & strMon
                            End If
                            strDate = strYear & strMon & strDay
                            'Read from 
                            _dtPlReprt = comcontrol.SelectPlReport(monMonday5Week, monSunday5Week, item.Text, item.Value, Gm)

                            If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                            Else
                                For Each row As DataRow In _dtPlReprt.Rows

                                    intNumberOfCounters = row.Item("NumberOfCounters")
                                    intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                    intNumberOfStaffs = row.Item("NumberOfStaffs")

                                    intCustomerVisit = row.Item("CustomerVisit")
                                    intCallRegistered = row.Item("CallRegistered")
                                    intRepairCompleted = row.Item("RepairCompleted")
                                    intGoodsDelivered = row.Item("GoodsDelivered")
                                    intPending = row.Item("Pending")
                                    intWarranty = row.Item("Warranty")
                                    intInWarranty = row.Item("InWarranty")
                                    intOutWarranty = row.Item("OutWarranty")
                                    decInWarrantyAmount = row.Item("InWarrantyAmount")
                                    decInWarrantyLabour = row.Item("InWarrantyLabour")
                                    decInWarrantyParts = row.Item("InWarrantyParts")
                                    decInWarrantyTransport = row.Item("InWarrantyTransport")
                                    decInWarrantyOthers = row.Item("InWarrantyOthers")
                                    decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                    decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                    decOutWarrantyParts = row.Item("OutWarrantyParts")
                                    decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                    decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                    decSawDiscountLabour = row.Item("SawDiscountLabour")
                                    decSawDiscountParts = row.Item("SawDiscountParts")
                                    decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                    decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                    decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                    decIwPartsConsumed = row.Item("IwPartsConsumed")
                                    decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                    decPrimeCostTotal = row.Item("PrimeCostTotal")
                                    decGrossProfit = row.Item("GrossProfit")
                                    decFinalPercentage = row.Item("FinalPercentage")

                                    intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                    intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                    intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                    intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                    intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                    intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                    intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                    intPendingTot = intPendingTot + intPending
                                    intWarrantyTot = intWarrantyTot + intWarranty
                                    intInWarrantyTot = intInWarrantyTot + intInWarranty
                                    intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                    decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                    decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                    decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                    decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                    decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                    decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                    decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                    decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                    decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                    decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                    decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                    decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                    decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                    decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                    decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                    decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                    decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                    decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                    decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                    decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                                    row0 = row0 & "," & item.Text
                                    rowTitle = rowTitle & "," & strDate

                                    rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                    rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                    rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                    rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                    rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                    rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                    rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                    rowPending = rowPending & "," & intPending
                                    rowWarranty = rowWarranty & "," & intWarranty
                                    rowInWarranty = rowInWarranty & "," & intInWarranty
                                    rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                    rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                    rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                    rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                    rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                    rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                    rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                    rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                    rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                    rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                    rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                    rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                    rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                    rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                    rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                    rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                    rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                    rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                    rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                    rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                    'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                                    If decRevenueWithoutTax = 0 Then
                                        FinalPercentage1 = decGrossProfit
                                    Else
                                        FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                    End If
                                    rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                                    'For Adding Final Report 
                                    SscTotals(4, 0) = strDate 'Date

                                    SscTotals(4, 1) = SscTotals(4, 1) + intNumberOfCounters 'rowNumberOfCounters
                                    SscTotals(4, 2) = SscTotals(4, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                    SscTotals(4, 3) = SscTotals(4, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                    SscTotals(4, 4) = SscTotals(4, 4) + intCustomerVisit 'rowCustomerVisit
                                    SscTotals(4, 5) = SscTotals(4, 5) + intCallRegistered 'rowCallRegistered
                                    SscTotals(4, 6) = SscTotals(4, 6) + intRepairCompleted 'rowRepairCompleted
                                    SscTotals(4, 7) = SscTotals(4, 7) + intGoodsDelivered 'rowGoodsDelivered
                                    SscTotals(4, 8) = SscTotals(4, 8) + intPending 'rowPending
                                    SscTotals(4, 9) = SscTotals(4, 9) + intWarranty 'rowWarranty
                                    SscTotals(4, 10) = SscTotals(4, 10) + intInWarranty 'rowInWarranty
                                    SscTotals(4, 11) = SscTotals(4, 11) + intOutWarranty 'rowOutWarranty
                                    SscTotals(4, 12) = SscTotals(4, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                    SscTotals(4, 13) = SscTotals(4, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                    SscTotals(4, 14) = SscTotals(4, 14) + decInWarrantyParts 'rowInWarrantyParts
                                    SscTotals(4, 15) = SscTotals(4, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                    SscTotals(4, 16) = SscTotals(4, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                    SscTotals(4, 17) = SscTotals(4, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                    SscTotals(4, 18) = SscTotals(4, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                    SscTotals(4, 19) = SscTotals(4, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                    SscTotals(4, 20) = SscTotals(4, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                    SscTotals(4, 21) = SscTotals(4, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                    SscTotals(4, 22) = SscTotals(4, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                    SscTotals(4, 23) = SscTotals(4, 23) + decSawDiscountParts 'rowSawDiscountParts
                                    SscTotals(4, 24) = SscTotals(4, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                    SscTotals(4, 25) = SscTotals(4, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                    SscTotals(4, 26) = SscTotals(4, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                    SscTotals(4, 27) = SscTotals(4, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                    SscTotals(4, 28) = SscTotals(4, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                    SscTotals(4, 29) = SscTotals(4, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                    SscTotals(4, 30) = SscTotals(4, 30) + decGrossProfit 'rowGrossProfit 
                                    SscTotals(4, 31) = SscTotals(4, 31) + decFinalPercentage 'rowFinalPercentage



                                Next row
                            End If


                        End If

                        'monMonday6Week & monSunday6Week
                        If blWeek6 Then
                            'lblLoc.Text = lblLoc.Text & "<br>6th  Week From: " & monMonday6Week & "  To: " & monSunday6Week
                            strDay = monMonday6Week.Day()
                            strMon = monMonday6Week.Month
                            strYear = monMonday6Week.Year

                            If Len(strDay) <= 1 Then
                                strDay = "0" & strDay
                            End If
                            If Len(strMon) <= 1 Then
                                strMon = "0" & strMon
                            End If
                            strDate = strYear & strMon & strDay
                            'Read from 
                            _dtPlReprt = comcontrol.SelectPlReport(monMonday6Week, monSunday6Week, item.Text, item.Value, Gm)

                            If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                            Else
                                For Each row As DataRow In _dtPlReprt.Rows

                                    intNumberOfCounters = row.Item("NumberOfCounters")
                                    intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                    intNumberOfStaffs = row.Item("NumberOfStaffs")

                                    intCustomerVisit = row.Item("CustomerVisit")
                                    intCallRegistered = row.Item("CallRegistered")
                                    intRepairCompleted = row.Item("RepairCompleted")
                                    intGoodsDelivered = row.Item("GoodsDelivered")
                                    intPending = row.Item("Pending")
                                    intWarranty = row.Item("Warranty")
                                    intInWarranty = row.Item("InWarranty")
                                    intOutWarranty = row.Item("OutWarranty")
                                    decInWarrantyAmount = row.Item("InWarrantyAmount")
                                    decInWarrantyLabour = row.Item("InWarrantyLabour")
                                    decInWarrantyParts = row.Item("InWarrantyParts")
                                    decInWarrantyTransport = row.Item("InWarrantyTransport")
                                    decInWarrantyOthers = row.Item("InWarrantyOthers")
                                    decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                    decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                    decOutWarrantyParts = row.Item("OutWarrantyParts")
                                    decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                    decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                    decSawDiscountLabour = row.Item("SawDiscountLabour")
                                    decSawDiscountParts = row.Item("SawDiscountParts")
                                    decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                    decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                    decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                    decIwPartsConsumed = row.Item("IwPartsConsumed")
                                    decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                    decPrimeCostTotal = row.Item("PrimeCostTotal")
                                    decGrossProfit = row.Item("GrossProfit")
                                    decFinalPercentage = row.Item("FinalPercentage")

                                    intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                    intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                    intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                    intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                    intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                    intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                    intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                    intPendingTot = intPendingTot + intPending
                                    intWarrantyTot = intWarrantyTot + intWarranty
                                    intInWarrantyTot = intInWarrantyTot + intInWarranty
                                    intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                    decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                    decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                    decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                    decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                    decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                    decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                    decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                    decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                    decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                    decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                    decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                    decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                    decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                    decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                    decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                    decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                    decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                    decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                    decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                    decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                                    row0 = row0 & "," & item.Text
                                    rowTitle = rowTitle & "," & strDate

                                    rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                    rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                    rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                    rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                    rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                    rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                    rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                    rowPending = rowPending & "," & intPending
                                    rowWarranty = rowWarranty & "," & intWarranty
                                    rowInWarranty = rowInWarranty & "," & intInWarranty
                                    rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                    rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                    rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                    rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                    rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                    rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                    rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                    rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                    rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                    rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                    rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                    rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                    rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                    rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                    rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                    rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                    rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                    rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                    rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                    rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                    'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                                    If decRevenueWithoutTax = 0 Then
                                        FinalPercentage1 = decGrossProfit
                                    Else
                                        FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                    End If
                                    rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                                    'For Adding Final Report 
                                    SscTotals(5, 0) = strDate 'Date

                                    SscTotals(5, 1) = SscTotals(5, 1) + intNumberOfCounters 'rowNumberOfCounters
                                    SscTotals(5, 2) = SscTotals(5, 2) + intNumberOfBusinessDat 'rowNumberOfBusinessDat
                                    SscTotals(5, 3) = SscTotals(5, 3) + intNumberOfStaffs 'rowNumberOfStaffs

                                    SscTotals(5, 4) = SscTotals(5, 4) + intCustomerVisit 'rowCustomerVisit
                                    SscTotals(5, 5) = SscTotals(5, 5) + intCallRegistered 'rowCallRegistered
                                    SscTotals(5, 6) = SscTotals(5, 6) + intRepairCompleted 'rowRepairCompleted
                                    SscTotals(5, 7) = SscTotals(5, 7) + intGoodsDelivered 'rowGoodsDelivered
                                    SscTotals(5, 8) = SscTotals(5, 8) + intPending 'rowPending
                                    SscTotals(5, 9) = SscTotals(5, 9) + intWarranty 'rowWarranty
                                    SscTotals(5, 10) = SscTotals(5, 10) + intInWarranty 'rowInWarranty
                                    SscTotals(5, 11) = SscTotals(5, 11) + intOutWarranty 'rowOutWarranty
                                    SscTotals(5, 12) = SscTotals(5, 12) + decInWarrantyAmount 'rowInWarrantyAmount
                                    SscTotals(5, 13) = SscTotals(5, 13) + decInWarrantyLabour 'rowInWarrantyLabour
                                    SscTotals(5, 14) = SscTotals(5, 14) + decInWarrantyParts 'rowInWarrantyParts
                                    SscTotals(5, 15) = SscTotals(5, 15) + decInWarrantyTransport 'rowInWarrantyTransport
                                    SscTotals(5, 16) = SscTotals(5, 16) + decInWarrantyOthers 'rowInWarrantyOthers
                                    SscTotals(5, 17) = SscTotals(5, 17) + decOutWarrantyAmount 'rowOutWarrantyAmount
                                    SscTotals(5, 18) = SscTotals(5, 18) + decOutWarrantyLabour 'rowOutWarrantyLabour
                                    SscTotals(5, 19) = SscTotals(5, 19) + decOutWarrantyParts 'rowOutWarrantyParts
                                    SscTotals(5, 20) = SscTotals(5, 20) + decOutWarrantyTransport 'rowOutWarrantyTransport
                                    SscTotals(5, 21) = SscTotals(5, 21) + decOutWarrantyOthers 'rowOutWarrantyOthers
                                    SscTotals(5, 22) = SscTotals(5, 22) + decSawDiscountLabour 'rowSawDiscountLabour
                                    SscTotals(5, 23) = SscTotals(5, 23) + decSawDiscountParts 'rowSawDiscountParts
                                    SscTotals(5, 24) = SscTotals(5, 24) + decOutWarrantyLabourwSawDisc 'rowOutWarrantyLabourwSawDisc
                                    SscTotals(5, 25) = SscTotals(5, 25) + decOutWarrantyPartswSawDisc 'rowOutWarrantyPartswSawDisc
                                    SscTotals(5, 26) = SscTotals(5, 26) + decRevenueWithoutTax 'rowRevenueWithoutTax
                                    SscTotals(5, 27) = SscTotals(5, 27) + decIwPartsConsumed 'rowIwPartsConsumed
                                    SscTotals(5, 28) = SscTotals(5, 28) + decTotalPartsConsumed 'rowTotalPartsConsumed
                                    SscTotals(5, 29) = SscTotals(5, 29) + decPrimeCostTotal 'rowPrimeCostTotal
                                    SscTotals(5, 30) = SscTotals(5, 30) + decGrossProfit 'rowGrossProfit 
                                    SscTotals(5, 31) = SscTotals(5, 31) + decFinalPercentage 'rowFinalPercentage

                                Next row
                            End If


                        End If
                    End If
                Else 'Selected SSC
                    'monMonday1Week & monSunday1Week
                    strDay = monMonday1Week.Day()
                    strMon = monMonday1Week.Month
                    strYear = monMonday1Week.Year

                    If Len(strDay) <= 1 Then
                        strDay = "0" & strDay
                    End If
                    If Len(strMon) <= 1 Then
                        strMon = "0" & strMon
                    End If
                    strDate = strYear & strMon & strDay
                    'Read from 
                    _dtPlReprt = comcontrol.SelectPlReport(monMonday1Week, monMonday1Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                    If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                    Else
                        For Each row As DataRow In _dtPlReprt.Rows

                            intNumberOfCounters = row.Item("NumberOfCounters")
                            intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                            intNumberOfStaffs = row.Item("NumberOfStaffs")

                            intCustomerVisit = row.Item("CustomerVisit")
                            intCallRegistered = row.Item("CallRegistered")
                            intRepairCompleted = row.Item("RepairCompleted")
                            intGoodsDelivered = row.Item("GoodsDelivered")
                            intPending = row.Item("Pending")
                            intWarranty = row.Item("Warranty")
                            intInWarranty = row.Item("InWarranty")
                            intOutWarranty = row.Item("OutWarranty")
                            decInWarrantyAmount = row.Item("InWarrantyAmount")
                            decInWarrantyLabour = row.Item("InWarrantyLabour")
                            decInWarrantyParts = row.Item("InWarrantyParts")
                            decInWarrantyTransport = row.Item("InWarrantyTransport")
                            decInWarrantyOthers = row.Item("InWarrantyOthers")
                            decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                            decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                            decOutWarrantyParts = row.Item("OutWarrantyParts")
                            decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                            decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                            decSawDiscountLabour = row.Item("SawDiscountLabour")
                            decSawDiscountParts = row.Item("SawDiscountParts")
                            decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                            decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                            decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                            decIwPartsConsumed = row.Item("IwPartsConsumed")
                            decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                            decPrimeCostTotal = row.Item("PrimeCostTotal")
                            decGrossProfit = row.Item("GrossProfit")
                            decFinalPercentage = row.Item("FinalPercentage")

                            intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                            intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                            intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                            intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                            intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                            intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                            intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                            intPendingTot = intPendingTot + intPending
                            intWarrantyTot = intWarrantyTot + intWarranty
                            intInWarrantyTot = intInWarrantyTot + intInWarranty
                            intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                            decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                            decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                            decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                            decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                            decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                            decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                            decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                            decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                            decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                            decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                            decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                            decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                            decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                            decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                            decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                            decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                            decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                            decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                            decGrossProfitTot = decGrossProfitTot + decGrossProfit
                            decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                            rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                            'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                        Next row
                    End If
                    'monMonday2Week & monSunday2Week
                    strDay = monMonday2Week.Day()
                    strMon = monMonday2Week.Month
                    strYear = monMonday2Week.Year

                    If Len(strDay) <= 1 Then
                        strDay = "0" & strDay
                    End If
                    If Len(strMon) <= 1 Then
                        strMon = "0" & strMon
                    End If
                    strDate = strYear & strMon & strDay
                    'Read from 
                    _dtPlReprt = comcontrol.SelectPlReport(monMonday2Week, monSunday2Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                    If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                    Else
                        For Each row As DataRow In _dtPlReprt.Rows

                            intNumberOfCounters = row.Item("NumberOfCounters")
                            intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                            intNumberOfStaffs = row.Item("NumberOfStaffs")

                            intCustomerVisit = row.Item("CustomerVisit")
                            intCallRegistered = row.Item("CallRegistered")
                            intRepairCompleted = row.Item("RepairCompleted")
                            intGoodsDelivered = row.Item("GoodsDelivered")
                            intPending = row.Item("Pending")
                            intWarranty = row.Item("Warranty")
                            intInWarranty = row.Item("InWarranty")
                            intOutWarranty = row.Item("OutWarranty")
                            decInWarrantyAmount = row.Item("InWarrantyAmount")
                            decInWarrantyLabour = row.Item("InWarrantyLabour")
                            decInWarrantyParts = row.Item("InWarrantyParts")
                            decInWarrantyTransport = row.Item("InWarrantyTransport")
                            decInWarrantyOthers = row.Item("InWarrantyOthers")
                            decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                            decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                            decOutWarrantyParts = row.Item("OutWarrantyParts")
                            decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                            decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                            decSawDiscountLabour = row.Item("SawDiscountLabour")
                            decSawDiscountParts = row.Item("SawDiscountParts")
                            decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                            decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                            decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                            decIwPartsConsumed = row.Item("IwPartsConsumed")
                            decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                            decPrimeCostTotal = row.Item("PrimeCostTotal")
                            decGrossProfit = row.Item("GrossProfit")
                            decFinalPercentage = row.Item("FinalPercentage")

                            intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                            intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                            intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                            intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                            intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                            intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                            intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                            intPendingTot = intPendingTot + intPending
                            intWarrantyTot = intWarrantyTot + intWarranty
                            intInWarrantyTot = intInWarrantyTot + intInWarranty
                            intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                            decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                            decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                            decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                            decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                            decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                            decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                            decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                            decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                            decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                            decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                            decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                            decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                            decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                            decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                            decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                            decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                            decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                            decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                            decGrossProfitTot = decGrossProfitTot + decGrossProfit
                            decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                            rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                            'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                        Next row
                    End If
                    'monMonday3Week & monSunday3Week
                    strDay = monMonday3Week.Day()
                    strMon = monMonday3Week.Month
                    strYear = monMonday3Week.Year

                    If Len(strDay) <= 1 Then
                        strDay = "0" & strDay
                    End If
                    If Len(strMon) <= 1 Then
                        strMon = "0" & strMon
                    End If
                    strDate = strYear & strMon & strDay
                    'Read from 
                    _dtPlReprt = comcontrol.SelectPlReport(monMonday3Week, monSunday3Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                    If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                    Else
                        For Each row As DataRow In _dtPlReprt.Rows
                            intNumberOfCounters = row.Item("NumberOfCounters")
                            intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                            intNumberOfStaffs = row.Item("NumberOfStaffs")

                            intCustomerVisit = row.Item("CustomerVisit")
                            intCallRegistered = row.Item("CallRegistered")
                            intRepairCompleted = row.Item("RepairCompleted")
                            intGoodsDelivered = row.Item("GoodsDelivered")
                            intPending = row.Item("Pending")
                            intWarranty = row.Item("Warranty")
                            intInWarranty = row.Item("InWarranty")
                            intOutWarranty = row.Item("OutWarranty")
                            decInWarrantyAmount = row.Item("InWarrantyAmount")
                            decInWarrantyLabour = row.Item("InWarrantyLabour")
                            decInWarrantyParts = row.Item("InWarrantyParts")
                            decInWarrantyTransport = row.Item("InWarrantyTransport")
                            decInWarrantyOthers = row.Item("InWarrantyOthers")
                            decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                            decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                            decOutWarrantyParts = row.Item("OutWarrantyParts")
                            decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                            decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                            decSawDiscountLabour = row.Item("SawDiscountLabour")
                            decSawDiscountParts = row.Item("SawDiscountParts")
                            decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                            decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                            decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                            decIwPartsConsumed = row.Item("IwPartsConsumed")
                            decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                            decPrimeCostTotal = row.Item("PrimeCostTotal")
                            decGrossProfit = row.Item("GrossProfit")
                            decFinalPercentage = row.Item("FinalPercentage")

                            intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                            intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                            intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                            intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                            intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                            intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                            intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                            intPendingTot = intPendingTot + intPending
                            intWarrantyTot = intWarrantyTot + intWarranty
                            intInWarrantyTot = intInWarrantyTot + intInWarranty
                            intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                            decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                            decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                            decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                            decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                            decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                            decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                            decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                            decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                            decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                            decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                            decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                            decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                            decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                            decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                            decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                            decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                            decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                            decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                            decGrossProfitTot = decGrossProfitTot + decGrossProfit
                            decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                            rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                            'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                        Next row
                    End If
                    'monMonday4Week & monSunday4Week
                    strDay = monMonday4Week.Day()
                    strMon = monMonday4Week.Month
                    strYear = monMonday4Week.Year

                    If Len(strDay) <= 1 Then
                        strDay = "0" & strDay
                    End If
                    If Len(strMon) <= 1 Then
                        strMon = "0" & strMon
                    End If
                    strDate = strYear & strMon & strDay
                    'Read from 
                    _dtPlReprt = comcontrol.SelectPlReport(monMonday4Week, monMonday4Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                    If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                    Else
                        For Each row As DataRow In _dtPlReprt.Rows

                            intNumberOfCounters = row.Item("NumberOfCounters")
                            intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                            intNumberOfStaffs = row.Item("NumberOfStaffs")

                            intCustomerVisit = row.Item("CustomerVisit")
                            intCallRegistered = row.Item("CallRegistered")
                            intRepairCompleted = row.Item("RepairCompleted")
                            intGoodsDelivered = row.Item("GoodsDelivered")
                            intPending = row.Item("Pending")
                            intWarranty = row.Item("Warranty")
                            intInWarranty = row.Item("InWarranty")
                            intOutWarranty = row.Item("OutWarranty")
                            decInWarrantyAmount = row.Item("InWarrantyAmount")
                            decInWarrantyLabour = row.Item("InWarrantyLabour")
                            decInWarrantyParts = row.Item("InWarrantyParts")
                            decInWarrantyTransport = row.Item("InWarrantyTransport")
                            decInWarrantyOthers = row.Item("InWarrantyOthers")
                            decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                            decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                            decOutWarrantyParts = row.Item("OutWarrantyParts")
                            decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                            decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                            decSawDiscountLabour = row.Item("SawDiscountLabour")
                            decSawDiscountParts = row.Item("SawDiscountParts")
                            decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                            decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                            decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                            decIwPartsConsumed = row.Item("IwPartsConsumed")
                            decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                            decPrimeCostTotal = row.Item("PrimeCostTotal")
                            decGrossProfit = row.Item("GrossProfit")
                            decFinalPercentage = row.Item("FinalPercentage")


                            intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                            intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                            intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                            intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                            intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                            intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                            intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                            intPendingTot = intPendingTot + intPending
                            intWarrantyTot = intWarrantyTot + intWarranty
                            intInWarrantyTot = intInWarrantyTot + intInWarranty
                            intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                            decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                            decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                            decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                            decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                            decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                            decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                            decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                            decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                            decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                            decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                            decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                            decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                            decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                            decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                            decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                            decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                            decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                            decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                            decGrossProfitTot = decGrossProfitTot + decGrossProfit
                            decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage


                            rowTitle = rowTitle & "," & strDate

                            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                            rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                            rowPending = rowPending & "," & intPending
                            rowWarranty = rowWarranty & "," & intWarranty
                            rowInWarranty = rowInWarranty & "," & intInWarranty
                            rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                            rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                            'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                            If decRevenueWithoutTax = 0 Then
                                FinalPercentage1 = decGrossProfit
                            Else
                                FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                            End If
                            rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                        Next row
                    End If
                    'monMonday5Week & monSunday5Week
                    If blWeek5 Then
                        '     lblLoc.Text = lblLoc.Text & "<br>5th  Week From: " & monMonday5Week & "  To: " & monSunday5Week
                        strDay = monMonday5Week.Day()
                        strMon = monMonday5Week.Month
                        strYear = monMonday5Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(monMonday5Week, monSunday5Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")
                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100


                            Next row
                        End If
                    End If

                    'monMonday6Week & monSunday6Week
                    If blWeek6 Then
                        '   lblLoc.Text = lblLoc.Text & "<br>6th  Week From: " & monMonday6Week & "  To: " & monSunday6Week
                        strDay = monMonday6Week.Day()
                        strMon = monMonday6Week.Month
                        strYear = monMonday6Week.Year

                        If Len(strDay) <= 1 Then
                            strDay = "0" & strDay
                        End If
                        If Len(strMon) <= 1 Then
                            strMon = "0" & strMon
                        End If
                        strDate = strYear & strMon & strDay
                        'Read from 
                        _dtPlReprt = comcontrol.SelectPlReport(monMonday6Week, monSunday6Week, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                        If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then
                        Else
                            For Each row As DataRow In _dtPlReprt.Rows

                                intNumberOfCounters = row.Item("NumberOfCounters")
                                intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                                intNumberOfStaffs = row.Item("NumberOfStaffs")

                                intCustomerVisit = row.Item("CustomerVisit")
                                intCallRegistered = row.Item("CallRegistered")
                                intRepairCompleted = row.Item("RepairCompleted")
                                intGoodsDelivered = row.Item("GoodsDelivered")
                                intPending = row.Item("Pending")
                                intWarranty = row.Item("Warranty")
                                intInWarranty = row.Item("InWarranty")
                                intOutWarranty = row.Item("OutWarranty")
                                decInWarrantyAmount = row.Item("InWarrantyAmount")
                                decInWarrantyLabour = row.Item("InWarrantyLabour")
                                decInWarrantyParts = row.Item("InWarrantyParts")
                                decInWarrantyTransport = row.Item("InWarrantyTransport")
                                decInWarrantyOthers = row.Item("InWarrantyOthers")
                                decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                                decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                                decOutWarrantyParts = row.Item("OutWarrantyParts")
                                decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                                decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                                decSawDiscountLabour = row.Item("SawDiscountLabour")
                                decSawDiscountParts = row.Item("SawDiscountParts")
                                decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                                decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                                decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                                decIwPartsConsumed = row.Item("IwPartsConsumed")
                                decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                                decPrimeCostTotal = row.Item("PrimeCostTotal")
                                decGrossProfit = row.Item("GrossProfit")
                                decFinalPercentage = row.Item("FinalPercentage")

                                intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                                intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                                intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                                intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                                intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                                intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                                intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                                intPendingTot = intPendingTot + intPending
                                intWarrantyTot = intWarrantyTot + intWarranty
                                intInWarrantyTot = intInWarrantyTot + intInWarranty
                                intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                                decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                                decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                                decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                                decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                                decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                                decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                                decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                                decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                                decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                                decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                                decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                                decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                                decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                                decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                                decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                                decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                                decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                                decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                                decGrossProfitTot = decGrossProfitTot + decGrossProfit
                                decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage

                                rowTitle = rowTitle & "," & strDate

                                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                                rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                                rowPending = rowPending & "," & intPending
                                rowWarranty = rowWarranty & "," & intWarranty
                                rowInWarranty = rowInWarranty & "," & intInWarranty
                                rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                                rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                                'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage
                                If decRevenueWithoutTax = 0 Then
                                    FinalPercentage1 = decGrossProfit
                                Else
                                    FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                                End If
                                rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100

                            Next row
                        End If
                    End If


                    'lblLoc.Text = lblLoc.Text & "<br>" & DropListLocation.SelectedItem.Text
                    Exit For
                End If
            Next


            If DropListLocation.SelectedItem.Text = "ALL" Then
                'For Total Displa
                Dim strTmp1 As String = ""
                Dim strTmp2 As String = ""
                Dim strTmp3 As String = ""
                Dim strTmp4 As String = ""
                Dim strTmp5 As String = ""
                Dim strTmp6 As String = ""
                Dim strTmp7 As String = ""
                Dim strTmp8 As String = ""
                Dim strTmp9 As String = ""
                Dim strTmp10 As String = ""
                Dim strTmp11 As String = ""
                Dim strTmp12 As String = ""
                Dim strTmp13 As String = ""
                Dim strTmp14 As String = ""
                Dim strTmp15 As String = ""
                Dim strTmp16 As String = ""
                Dim strTmp17 As String = ""
                Dim strTmp18 As String = ""
                Dim strTmp19 As String = ""
                Dim strTmp20 As String = ""
                Dim strTmp21 As String = ""
                Dim strTmp22 As String = ""
                Dim strTmp23 As String = ""
                Dim strTmp24 As String = ""
                Dim strTmp25 As String = ""
                Dim strTmp26 As String = ""
                Dim strTmp27 As String = ""

                Dim strTmp28 As String = ""
                Dim strTmp29 As String = ""
                Dim strTmp30 As String = ""
                Dim strTmp31 As String = ""
                Dim strTmp32 As String = ""



                If blWeek5 Then
                    strTmp1 = "," & SscTotals(4, 0)
                    strTmp2 = "," & SscTotals(4, 1)
                    strTmp3 = "," & SscTotals(4, 2)
                    strTmp4 = "," & SscTotals(4, 3)
                    strTmp5 = "," & SscTotals(4, 4)
                    strTmp6 = "," & SscTotals(4, 5)
                    strTmp7 = "," & SscTotals(4, 6)
                    strTmp8 = "," & SscTotals(4, 7)
                    strTmp9 = "," & SscTotals(4, 8)
                    strTmp10 = "," & SscTotals(4, 9)
                    strTmp11 = "," & SscTotals(4, 10)
                    strTmp12 = "," & SscTotals(4, 11)
                    strTmp13 = "," & SscTotals(4, 12)
                    strTmp14 = "," & SscTotals(4, 13)
                    strTmp15 = "," & SscTotals(4, 14)
                    strTmp16 = "," & SscTotals(4, 15)
                    strTmp17 = "," & SscTotals(4, 16)
                    strTmp18 = "," & SscTotals(4, 17)
                    strTmp19 = "," & SscTotals(4, 18)
                    strTmp20 = "," & SscTotals(4, 19)
                    strTmp21 = "," & SscTotals(4, 20)
                    strTmp22 = "," & SscTotals(4, 21)
                    strTmp23 = "," & SscTotals(4, 22)
                    strTmp24 = "," & SscTotals(4, 23)
                    strTmp25 = "," & SscTotals(4, 24)
                    strTmp26 = "," & SscTotals(4, 25)
                    strTmp27 = "," & SscTotals(4, 26) 'rowRevenueWithoutTax

                    strTmp28 = "," & SscTotals(4, 27)
                    strTmp29 = "," & SscTotals(4, 28)
                    strTmp30 = "," & SscTotals(4, 29)
                    strTmp31 = "," & SscTotals(4, 30) 'rowGrossProfit 
                    If SscTotals(4, 26) = 0 Then
                        FinalPercentage1 = SscTotals(4, 30)
                    Else
                        FinalPercentage1 = comcontrol.Money_Round((SscTotals(4, 30) / SscTotals(4, 26)) * 100, 2)
                    End If
                    strTmp32 = "," & FinalPercentage1 & "%"

                End If
                If blWeek6 Then
                    strTmp1 = strTmp1 & "," & SscTotals(5, 0)
                    strTmp2 = strTmp2 & "," & SscTotals(5, 1)
                    strTmp3 = strTmp3 & "," & SscTotals(5, 2)
                    strTmp4 = strTmp4 & "," & SscTotals(5, 3)
                    strTmp5 = strTmp5 & "," & SscTotals(5, 4)
                    strTmp6 = strTmp6 & "," & SscTotals(5, 5)
                    strTmp7 = strTmp7 & "," & SscTotals(5, 6)
                    strTmp8 = strTmp8 & "," & SscTotals(5, 7)
                    strTmp9 = strTmp9 & "," & SscTotals(5, 8)
                    strTmp10 = strTmp10 & "," & SscTotals(5, 9)
                    strTmp11 = strTmp11 & "," & SscTotals(5, 10)
                    strTmp12 = strTmp12 & "," & SscTotals(5, 11)
                    strTmp13 = strTmp13 & "," & SscTotals(5, 12)
                    strTmp14 = strTmp14 & "," & SscTotals(5, 13)
                    strTmp15 = strTmp15 & "," & SscTotals(5, 14)
                    strTmp16 = strTmp16 & "," & SscTotals(5, 15)
                    strTmp17 = strTmp17 & "," & SscTotals(5, 16)
                    strTmp18 = strTmp18 & "," & SscTotals(5, 17)
                    strTmp19 = strTmp19 & "," & SscTotals(5, 18)
                    strTmp20 = strTmp20 & "," & SscTotals(5, 19)
                    strTmp21 = strTmp21 & "," & SscTotals(5, 20)
                    strTmp22 = strTmp22 & "," & SscTotals(5, 21)
                    strTmp23 = strTmp23 & "," & SscTotals(5, 22)
                    strTmp24 = strTmp24 & "," & SscTotals(5, 23)
                    strTmp25 = strTmp25 & "," & SscTotals(5, 24)
                    strTmp26 = strTmp26 & "," & SscTotals(5, 25)
                    strTmp27 = strTmp27 & "," & SscTotals(5, 26) 'rowRevenueWithoutTax

                    strTmp28 = strTmp28 & "," & SscTotals(5, 27)
                    strTmp29 = strTmp29 & "," & SscTotals(5, 28)
                    strTmp30 = strTmp30 & "," & SscTotals(5, 29)
                    strTmp31 = strTmp31 & "," & SscTotals(5, 30) 'rowGrossProfit 
                    '                    strTmp32 = strTmp32 & "," & SscTotals(5, 31)
                    If SscTotals(5, 26) = 0 Then
                        FinalPercentage1 = SscTotals(5, 30)
                    Else
                        FinalPercentage1 = comcontrol.Money_Round((SscTotals(5, 30) / SscTotals(5, 26)) * 100, 2)
                    End If
                    strTmp32 = strTmp32 & "," & FinalPercentage1 & "%"



                End If
                'For Total Displa
                '        row0 = row0 & ",ALL SSC,ALL SSC,ALL SSC,ALL SSC"
                rowTitle = rowTitle & "," & SscTotals(0, 0) & "," & SscTotals(1, 0) & "," & SscTotals(2, 0) & "," & SscTotals(3, 0) & strTmp1 & ",Total"

                rowNumberOfCounters = rowNumberOfCounters & "," & SscTotals(0, 1) & "," & SscTotals(1, 1) & "," & SscTotals(2, 1) & "," & SscTotals(3, 1) & strTmp2 & "," & intNumberOfCountersTot
                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," & SscTotals(0, 2) & "," & SscTotals(1, 2) & "," & SscTotals(2, 2) & "," & SscTotals(3, 2) & strTmp3 & "," & intNumberOfBusinessDatTot
                rowNumberOfStaffs = rowNumberOfStaffs & "," & SscTotals(0, 3) & "," & SscTotals(1, 3) & "," & SscTotals(2, 3) & "," & SscTotals(3, 3) & strTmp4 & "," & intNumberOfStaffsTot



                rowCustomerVisit = rowCustomerVisit & "," & SscTotals(0, 4) & "," & SscTotals(1, 4) & "," & SscTotals(2, 4) & "," & SscTotals(3, 4) & strTmp5 & "," & intCustomerVisitTot
                rowCallRegistered = rowCallRegistered & "," & SscTotals(0, 5) & "," & SscTotals(1, 5) & "," & SscTotals(2, 5) & "," & SscTotals(3, 5) & strTmp6 & "," & intCallRegisteredTot
                rowRepairCompleted = rowRepairCompleted & "," & SscTotals(0, 6) & "," & SscTotals(1, 6) & "," & SscTotals(2, 6) & "," & SscTotals(3, 6) & strTmp7 & "," & intRepairCompletedTot
                rowGoodsDelivered = rowGoodsDelivered & "," & SscTotals(0, 7) & "," & SscTotals(1, 7) & "," & SscTotals(2, 7) & "," & SscTotals(3, 7) & strTmp8 & "," & intGoodsDeliveredTot
                rowPending = rowPending & "," & SscTotals(0, 8) & "," & SscTotals(1, 8) & "," & SscTotals(2, 8) & "," & SscTotals(3, 8) & strTmp9 & "," & intPendingTot
                rowWarranty = rowWarranty & "," & SscTotals(0, 9) & "," & SscTotals(1, 9) & "," & SscTotals(2, 9) & "," & SscTotals(3, 9) & strTmp10 & "," & intWarrantyTot
                rowInWarranty = rowInWarranty & "," & SscTotals(0, 10) & "," & SscTotals(1, 10) & "," & SscTotals(2, 10) & "," & SscTotals(3, 10) & strTmp11 & "," & intInWarrantyTot
                rowOutWarranty = rowOutWarranty & "," & SscTotals(0, 11) & "," & SscTotals(1, 11) & "," & SscTotals(2, 11) & "," & SscTotals(3, 11) & strTmp12 & "," & intOutWarrantyTot
                rowInWarrantyAmount = rowInWarrantyAmount & "," & SscTotals(0, 12) & "," & SscTotals(1, 12) & "," & SscTotals(2, 12) & "," & SscTotals(3, 12) & strTmp13 & "," & decInWarrantyAmountTot
                rowInWarrantyLabour = rowInWarrantyLabour & "," & SscTotals(0, 13) & "," & SscTotals(1, 13) & "," & SscTotals(2, 13) & "," & SscTotals(3, 13) & strTmp14 & "," & decInWarrantyLabourTot
                rowInWarrantyParts = rowInWarrantyParts & "," & SscTotals(0, 14) & "," & SscTotals(1, 14) & "," & SscTotals(2, 14) & "," & SscTotals(3, 14) & strTmp15 & "," & decInWarrantyPartsTot
                rowInWarrantyTransport = rowInWarrantyTransport & "," & SscTotals(0, 15) & "," & SscTotals(1, 15) & "," & SscTotals(2, 15) & "," & SscTotals(3, 15) & strTmp16 & "," & decInWarrantyTransportTot
                rowInWarrantyOthers = rowInWarrantyOthers & "," & SscTotals(0, 16) & "," & SscTotals(1, 16) & "," & SscTotals(2, 16) & "," & SscTotals(3, 16) & strTmp17 & "," & decInWarrantyOthersTot
                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & SscTotals(0, 17) & "," & SscTotals(1, 17) & "," & SscTotals(2, 17) & "," & SscTotals(3, 17) & strTmp18 & "," & decOutWarrantyAmountTot
                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & SscTotals(0, 18) & "," & SscTotals(1, 18) & "," & SscTotals(2, 18) & "," & SscTotals(3, 18) & strTmp19 & "," & decOutWarrantyLabourTot
                rowOutWarrantyParts = rowOutWarrantyParts & "," & SscTotals(0, 19) & "," & SscTotals(1, 19) & "," & SscTotals(2, 19) & "," & SscTotals(3, 19) & strTmp20 & "," & decOutWarrantyPartsTot
                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & SscTotals(0, 20) & "," & SscTotals(1, 20) & "," & SscTotals(2, 20) & "," & SscTotals(3, 20) & strTmp21 & "," & decOutWarrantyTransportTot
                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & SscTotals(0, 21) & "," & SscTotals(1, 21) & "," & SscTotals(2, 21) & "," & SscTotals(3, 21) & strTmp22 & "," & decOutWarrantyOthersTot
                rowSawDiscountLabour = rowSawDiscountLabour & "," & SscTotals(0, 22) & "," & SscTotals(1, 22) & "," & SscTotals(2, 22) & "," & SscTotals(3, 22) & strTmp23 & "," & decSawDiscountLabourTot
                rowSawDiscountParts = rowSawDiscountParts & "," & SscTotals(0, 23) & "," & SscTotals(1, 23) & "," & SscTotals(2, 23) & "," & SscTotals(3, 23) & strTmp24 & "," & decSawDiscountPartsTot
                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & SscTotals(0, 24) & "," & SscTotals(1, 24) & "," & SscTotals(2, 24) & "," & SscTotals(3, 24) & strTmp25 & "," & decOutWarrantyLabourwSawDiscTot
                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & SscTotals(0, 25) & "," & SscTotals(1, 25) & "," & SscTotals(2, 25) & "," & SscTotals(3, 25) & strTmp26 & "," & decOutWarrantyPartswSawDiscTot
                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & SscTotals(0, 26) & "," & SscTotals(1, 26) & "," & SscTotals(2, 26) & "," & SscTotals(3, 26) & strTmp27 & "," & decRevenueWithoutTaxTot
                rowIwPartsConsumed = rowIwPartsConsumed & "," & SscTotals(0, 27) & "," & SscTotals(1, 27) & "," & SscTotals(2, 27) & "," & SscTotals(3, 27) & strTmp28 & "," & decIwPartsConsumedTot
                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & SscTotals(0, 28) & "," & SscTotals(1, 28) & "," & SscTotals(2, 28) & "," & SscTotals(3, 28) & strTmp29 & "," & decTotalPartsConsumedTot
                rowPrimeCostTotal = rowPrimeCostTotal & "," & SscTotals(0, 29) & "," & SscTotals(1, 29) & "," & SscTotals(2, 29) & "," & SscTotals(3, 29) & strTmp30 & "," & decPrimeCostTotalTot
                rowGrossProfit = rowGrossProfit & "," & SscTotals(0, 30) & "," & SscTotals(1, 30) & "," & SscTotals(2, 30) & "," & SscTotals(3, 30) & strTmp31 & "," & decGrossProfitTot
                'rowFinalPercentage = rowFinalPercentage & "," & SscTotals(0, 31) & "," & SscTotals(1, 31) & "," & SscTotals(2, 31) & "," & SscTotals(3, 31) & strTmp32 & "," & decFinalPercentage
                If SscTotals(0, 26) = 0 Then ' RevenueWithoutTax = 0
                    SscTotals031 = SscTotals(0, 30) 'GrossProfit
                Else
                    SscTotals031 = comcontrol.Money_Round((SscTotals(0, 30) / SscTotals(0, 26)) * 100, 2)
                End If
                If SscTotals(1, 26) = 0 Then ' RevenueWithoutTax = 0
                    SscTotals131 = SscTotals(1, 30) 'GrossProfit
                Else
                    SscTotals131 = comcontrol.Money_Round((SscTotals(1, 30) / SscTotals(1, 26)) * 100, 2)
                End If
                If SscTotals(2, 26) = 0 Then ' RevenueWithoutTax = 0
                    SscTotals231 = SscTotals(2, 30) 'GrossProfit
                Else
                    SscTotals231 = comcontrol.Money_Round((SscTotals(2, 30) / SscTotals(2, 26)) * 100, 2)
                End If
                If SscTotals(3, 26) = 0 Then ' RevenueWithoutTax = 0
                    SscTotals331 = SscTotals(3, 30) 'GrossProfit
                Else
                    SscTotals331 = comcontrol.Money_Round((SscTotals(3, 30) / SscTotals(3, 26)) * 100, 2)
                End If
                If decRevenueWithoutTaxTot = 0 Then ' RevenueWithoutTax = 0
                    _FinalPercentage = decGrossProfitTot 'GrossProfit
                Else
                    _FinalPercentage = comcontrol.Money_Round((decGrossProfitTot / decRevenueWithoutTaxTot) * 100, 2)
                End If
                rowFinalPercentage = rowFinalPercentage & "," & SscTotals031 & "%" & "," & SscTotals131 & "%" & "," & SscTotals231 & "%" & "," & SscTotals331 & "%" & strTmp32 & "," & _FinalPercentage & "%"



                'For Display End of Label
                rowTitle = rowTitle & ","

                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs


                rowCustomerVisit = rowCustomerVisit & "," & "CustomerVisit"
                rowCallRegistered = rowCallRegistered & "," & "CallRegistered"
                rowRepairCompleted = rowRepairCompleted & "," & "RepairCompleted"
                rowGoodsDelivered = rowGoodsDelivered & "," & "GoodsDelivered"
                rowPending = rowPending & "," & "Pending"
                rowWarranty = rowWarranty & "," & "Warranty"
                rowInWarranty = rowInWarranty & "," & "InWarranty"
                rowOutWarranty = rowOutWarranty & "," & "OutWarranty"
                rowInWarrantyAmount = rowInWarrantyAmount & "," & "InWarrantyAmount"
                rowInWarrantyLabour = rowInWarrantyLabour & "," & "InWarrantyLabour"
                rowInWarrantyParts = rowInWarrantyParts & "," & "InWarrantyParts"
                rowInWarrantyTransport = rowInWarrantyTransport & "," & "InWarrantyTransport"
                rowInWarrantyOthers = rowInWarrantyOthers & "," & "InWarrantyOthers"
                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & "OutWarrantyAmount"
                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & "OutWarrantyLabour"
                rowOutWarrantyParts = rowOutWarrantyParts & "," & "OutWarrantyParts"
                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & "OutWarrantyTransport"
                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & "OutWarrantyOthers"
                rowSawDiscountLabour = rowSawDiscountLabour & "," & "SawDiscountLabour"
                rowSawDiscountParts = rowSawDiscountParts & "," & "SawDiscountParts"
                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & "OutWarrantyLabourwSawDisc"
                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & "OutWarrantyPartswSawDisc"
                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & "RevenueWithoutTax"
                rowIwPartsConsumed = rowIwPartsConsumed & "," & "IwPartsConsumed"
                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & "TotalPartsConsumed"
                rowPrimeCostTotal = rowPrimeCostTotal & "," & "PrimeCostTotal"
                rowGrossProfit = rowGrossProfit & "," & "GrossProfit"
                rowFinalPercentage = rowFinalPercentage & "," & " "


            Else
                'For Total Displa
                rowTitle = rowTitle & ",Total"

                rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCountersTot
                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDatTot
                rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffsTot

                rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisitTot
                rowCallRegistered = rowCallRegistered & "," & intCallRegisteredTot
                rowRepairCompleted = rowRepairCompleted & "," & intRepairCompletedTot
                rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDeliveredTot
                rowPending = rowPending & "," & intPendingTot
                rowWarranty = rowWarranty & "," & intWarrantyTot
                rowInWarranty = rowInWarranty & "," & intInWarrantyTot
                rowOutWarranty = rowOutWarranty & "," & intOutWarrantyTot
                rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmountTot
                rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabourTot
                rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyPartsTot
                rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransportTot
                rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthersTot
                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmountTot
                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabourTot
                rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyPartsTot
                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransportTot
                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthersTot
                rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabourTot
                rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountPartsTot
                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDiscTot
                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDiscTot
                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTaxTot
                rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumedTot
                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumedTot
                rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotalTot
                rowGrossProfit = rowGrossProfit & "," & decGrossProfitTot

                If decRevenueWithoutTaxTot = 0 Then ' RevenueWithoutTax = 0
                    _FinalPercentage = decGrossProfitTot 'GrossProfit
                Else
                    _FinalPercentage = comcontrol.Money_Round((decGrossProfitTot / decRevenueWithoutTaxTot) * 100, 2)
                End If
                rowFinalPercentage = rowFinalPercentage & "," & _FinalPercentage & "%"


                'For Display End of Label
                rowTitle = rowTitle & ","

                rowNumberOfCounters = rowNumberOfCounters & "," & "Number of counters"
                rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," & "Number of Business dat"
                rowNumberOfStaffs = rowNumberOfStaffs & "," & "Number of Staffs"

                rowCustomerVisit = rowCustomerVisit & "," & "CustomerVisit"
                rowCallRegistered = rowCallRegistered & "," & "CallRegistered"
                rowRepairCompleted = rowRepairCompleted & "," & "RepairCompleted"
                rowGoodsDelivered = rowGoodsDelivered & "," & "GoodsDelivered"
                rowPending = rowPending & "," & "Pending"
                rowWarranty = rowWarranty & "," & "Warranty"
                rowInWarranty = rowInWarranty & "," & "InWarranty"
                rowOutWarranty = rowOutWarranty & "," & "OutWarranty"
                rowInWarrantyAmount = rowInWarrantyAmount & "," & "InWarrantyAmount"
                rowInWarrantyLabour = rowInWarrantyLabour & "," & "InWarrantyLabour"
                rowInWarrantyParts = rowInWarrantyParts & "," & "InWarrantyParts"
                rowInWarrantyTransport = rowInWarrantyTransport & "," & "InWarrantyTransport"
                rowInWarrantyOthers = rowInWarrantyOthers & "," & "InWarrantyOthers"
                rowOutWarrantyAmount = rowOutWarrantyAmount & "," & "OutWarrantyAmount"
                rowOutWarrantyLabour = rowOutWarrantyLabour & "," & "OutWarrantyLabour"
                rowOutWarrantyParts = rowOutWarrantyParts & "," & "OutWarrantyParts"
                rowOutWarrantyTransport = rowOutWarrantyTransport & "," & "OutWarrantyTransport"
                rowOutWarrantyOthers = rowOutWarrantyOthers & "," & "OutWarrantyOthers"
                rowSawDiscountLabour = rowSawDiscountLabour & "," & "SawDiscountLabour"
                rowSawDiscountParts = rowSawDiscountParts & "," & "SawDiscountParts"
                rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & "OutWarrantyLabourwSawDisc"
                rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & "OutWarrantyPartswSawDisc"
                rowRevenueWithoutTax = rowRevenueWithoutTax & "," & "RevenueWithoutTax"
                rowIwPartsConsumed = rowIwPartsConsumed & "," & "IwPartsConsumed"
                rowTotalPartsConsumed = rowTotalPartsConsumed & "," & "TotalPartsConsumed"
                rowPrimeCostTotal = rowPrimeCostTotal & "," & "PrimeCostTotal"
                rowGrossProfit = rowGrossProfit & "," & "GrossProfit"
                rowFinalPercentage = rowFinalPercentage & "," & " "

            End If



            csvContents.Add(row0)
            csvContents.Add(rowTitle)

            csvContents.Add(rowNumberOfCounters)
            csvContents.Add(rowNumberOfBusinessDat)
            csvContents.Add(rowNumberOfStaffs)

            csvContents.Add(rowCustomerVisit)
            csvContents.Add(rowCallRegistered)
            csvContents.Add(rowRepairCompleted)
            csvContents.Add(rowGoodsDelivered)
            csvContents.Add(rowPending)
            csvContents.Add(rowWarranty)
            csvContents.Add(rowInWarranty)
            csvContents.Add(rowOutWarranty)
            csvContents.Add(rowInWarrantyAmount)
            csvContents.Add(rowInWarrantyLabour)
            csvContents.Add(rowInWarrantyParts)
            csvContents.Add(rowInWarrantyTransport)
            csvContents.Add(rowInWarrantyOthers)
            csvContents.Add(rowOutWarrantyAmount)
            csvContents.Add(rowOutWarrantyLabour)
            csvContents.Add(rowOutWarrantyParts)
            csvContents.Add(rowOutWarrantyTransport)
            csvContents.Add(rowOutWarrantyOthers)
            csvContents.Add(rowSawDiscountLabour)
            csvContents.Add(rowSawDiscountParts)
            csvContents.Add(rowOutWarrantyLabourwSawDisc)
            csvContents.Add(rowOutWarrantyPartswSawDisc)
            csvContents.Add(rowRevenueWithoutTax)
            csvContents.Add(rowIwPartsConsumed)
            csvContents.Add(rowTotalPartsConsumed)
            csvContents.Add(rowPrimeCostTotal)
            csvContents.Add(rowGrossProfit)
            csvContents.Add(rowFinalPercentage)

            Dim csvFileName As String

            Dim clsSetCommon As New Class_common
            Dim dtNow As DateTime = clsSetCommon.dtIndia
            Dim exportFile As String = Session("export_File")

            Dim outputPath As String

            'PeriodFrom = Replace(PeriodFrom, "/", "")
            'PeriodTo = Replace(PeriodTo, "/", "")

            strDay = 0
            strMon = DropDownMonth.SelectedItem.Value
            strYear = DropDownYear.SelectedItem.Value

            If Len(strDay) <= 1 Then
                strDay = "0" & strDay
            End If
            If Len(strMon) <= 1 Then
                strMon = "0" & strMon
            End If

            If DropListLocation.SelectedItem.Text = "ALL" Then
                csvFileName = "SM_MONTHLY_PL_ALL_" & strYear & strMon & ".csv"
            Else
                csvFileName = "SM_MONTHLY_PL_" & DropListLocation.SelectedItem.Text & "_" & strYear & strMon & ".csv"
            End If
            ''csvFileName = exportFile & "_ " & DropListLocation.SelectedItem.Text & "_" & PeriodFrom.Year & PeriodFrom.Month & PeriodFrom.Day & ".csv"

            outputPath = clsSet.CsvFilePass & csvFileName

            Using writer As New StreamWriter(outputPath, False, Encoding.Default)
                writer.WriteLine(String.Join(Environment.NewLine, csvContents))
            End Using

            Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)
            If outputPath <> "" Then
                If System.IO.File.Exists(outputPath) = True Then
                    System.IO.File.Delete(outputPath)
                End If
            End If
            Response.ContentType = "application/text/csv"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)
            Response.Flush()
            'Response.Write("<b>File Contents: </b>")
            Response.BinaryWrite(Buffer)
            'Response.WriteFile(outputPath) 'if not required dialog box to user, then make comment this line
            Response.End()












            '****************************************
            'Specified period 
            'Begin
            '****************************************
        ElseIf DrpType.SelectedItem.Value = "03" Then ' Specified period
            '3rd Period
            Dim PeriodFrom As New System.DateTime(strYear, 9, 30, 0, 0, 0)
            Dim PeriodTo As New System.DateTime(strYear, 10, 13, 0, 0, 0)

            PeriodFrom = TextDateFrom.Text
            PeriodTo = TextDateTo.Text

            '1st Condition - From date must Monday
            '2nd Condition - To date must Sunday

            lblLoc.Text = PeriodFrom

            Dim PeriodCurrentFrom As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)
            Dim PeriodCurrentTo As New System.DateTime(strYear, strMon, strDay, 0, 0, 0)


            'Verify that From must 1 (Monday)
            'Verify that To must 0 (Sunday)
            'Allowed maximum 50 weeks
            'Only one SSC


            If PeriodFrom.DayOfWeek <> 1 Then
                'Show the error message
                Call showMsg("There is an error in the from date specification (Monday)", "")
                Exit Sub
            End If

            If PeriodTo.DayOfWeek <> 0 Then
                'Show the error message
                Call showMsg("There is an error in the to date specification (Sunday)", "")
                Exit Sub
            End If
            'Only Allowed One SSC
            If DropListLocation.SelectedItem.Text = "ALL" Then
                Call showMsg("Only one SSC must select", "")
                Exit Sub
            End If

            Dim lpContinue As Boolean = True
            'Initially move currentfrom previous monday then loop will assign
            PeriodCurrentFrom = PeriodFrom.AddDays(-7)

            Dim intMaxCount As Integer = 0
            Dim strText As String = ""
            ' lblText.Text = ""
            While (lpContinue = True)
                intMaxCount = intMaxCount + 1
                PeriodCurrentFrom = PeriodCurrentFrom.AddDays(7)
                PeriodCurrentTo = PeriodCurrentFrom.AddDays(6)
                ' lblText.Text = lblText.Text & "intMaxCount = " & intMaxCount & "    PeriodCurrentFrom =" & PeriodCurrentFrom & " PeriodCurrentTo = " & PeriodCurrentTo & "<br>"
                If PeriodTo <= PeriodCurrentTo Then
                    lpContinue = False
                End If
                If intMaxCount >= 51 Then
                    lpContinue = False
                End If
            End While

            If intMaxCount >= 51 Then
                Call showMsg("Maximum allowed 50 weeks", "")
                Exit Sub
            End If


            PeriodFrom = TextDateFrom.Text
            PeriodTo = TextDateTo.Text

            PeriodCurrentFrom = PeriodFrom.AddDays(-7)

            lpContinue = True
            intMaxCount = 0
            Dim row0 As String = DropListLocation.SelectedItem.Text & ","
            Dim rowTitle As String = " "

            Dim rowNumberOfCounters As String = "Number of counters"
            Dim rowNumberOfBusinessDat As String = "Number of Business dat"
            Dim rowNumberOfStaffs As String = "Number of Staffs"

            Dim rowCustomerVisit As String = "Customer Visit"
            Dim rowCallRegistered As String = "Call Registered"
            Dim rowRepairCompleted As String = "Repair Completed"
            Dim rowGoodsDelivered As String = "Goods Delivered"
            Dim rowPending As String = "Pending"
            Dim rowWarranty As String = "Warranty"
            Dim rowInWarranty As String = "InWarranty"
            Dim rowOutWarranty As String = "OutWarranty"
            Dim rowInWarrantyAmount As String = "InWarrantyAmount"
            Dim rowInWarrantyLabour As String = "InWarrantyLabour"
            Dim rowInWarrantyParts As String = "InWarrantyParts"
            Dim rowInWarrantyTransport As String = "InWarrantyTransport"
            Dim rowInWarrantyOthers As String = "InWarrantyOthers"
            Dim rowOutWarrantyAmount As String = "OutWarrantyAmount"
            Dim rowOutWarrantyLabour As String = "OutWarrantyLabour"
            Dim rowOutWarrantyParts As String = "OutWarrantyParts"
            Dim rowOutWarrantyTransport As String = "OutWarrantyTransport"
            Dim rowOutWarrantyOthers As String = "OutWarrantyOthers"
            Dim rowSawDiscountLabour As String = "SawDiscountLabour"
            Dim rowSawDiscountParts As String = "SawDiscountParts"
            Dim rowOutWarrantyLabourwSawDisc As String = "OutWarrantyLabourwSawDisc"
            Dim rowOutWarrantyPartswSawDisc As String = "OutWarrantyPartswSawDisc"
            Dim rowRevenueWithoutTax As String = "RevenueWithoutTax"
            Dim rowIwPartsConsumed As String = "IwPartsConsumed"
            Dim rowTotalPartsConsumed As String = "OutTotalPartsConsumed"
            Dim rowPrimeCostTotal As String = "PrimeCostTotal"
            Dim rowGrossProfit As String = "GrossProfit"
            Dim rowFinalPercentage As String = " "

            While (lpContinue = True)
                intMaxCount = intMaxCount + 1
                PeriodCurrentFrom = PeriodCurrentFrom.AddDays(7)
                PeriodCurrentTo = PeriodCurrentFrom.AddDays(6)



                strDay = PeriodCurrentFrom.Day()
                strMon = PeriodCurrentFrom.Month
                strYear = PeriodCurrentFrom.Year

                If Len(strDay) <= 1 Then
                    strDay = "0" & strDay
                End If
                If Len(strMon) <= 1 Then
                    strMon = "0" & strMon
                End If
                strDate = strYear & strMon & strDay


                'Read from 
                _dtPlReprt = comcontrol.SelectPlReport(PeriodCurrentFrom, PeriodCurrentTo, DropListLocation.SelectedItem.Text, DropListLocation.SelectedItem.Value, Gm)

                If (_dtPlReprt Is Nothing) Or (_dtPlReprt.Rows.Count = 0) Then

                Else






                    For Each row As DataRow In _dtPlReprt.Rows

                        intNumberOfCounters = row.Item("NumberOfCounters")
                        intNumberOfBusinessDat = row.Item("NumberOfBusinessDat")
                        intNumberOfStaffs = row.Item("NumberOfStaffs")

                        intCustomerVisit = row.Item("CustomerVisit")
                        intCallRegistered = row.Item("CallRegistered")
                        intRepairCompleted = row.Item("RepairCompleted")
                        intGoodsDelivered = row.Item("GoodsDelivered")
                        intPending = row.Item("Pending")
                        intWarranty = row.Item("Warranty")
                        intInWarranty = row.Item("InWarranty")
                        intOutWarranty = row.Item("OutWarranty")
                        decInWarrantyAmount = row.Item("InWarrantyAmount")
                        decInWarrantyLabour = row.Item("InWarrantyLabour")
                        decInWarrantyParts = row.Item("InWarrantyParts")
                        decInWarrantyTransport = row.Item("InWarrantyTransport")
                        decInWarrantyOthers = row.Item("InWarrantyOthers")
                        decOutWarrantyAmount = row.Item("OutWarrantyAmount")
                        decOutWarrantyLabour = row.Item("OutWarrantyLabour")
                        decOutWarrantyParts = row.Item("OutWarrantyParts")
                        decOutWarrantyTransport = row.Item("OutWarrantyTransport")
                        decOutWarrantyOthers = row.Item("OutWarrantyOthers")
                        decSawDiscountLabour = row.Item("SawDiscountLabour")
                        decSawDiscountParts = row.Item("SawDiscountParts")
                        decOutWarrantyLabourwSawDisc = row.Item("OutWarrantyLabourwSawDisc")
                        decOutWarrantyPartswSawDisc = row.Item("OutWarrantyPartswSawDisc")
                        decRevenueWithoutTax = row.Item("RevenueWithoutTax")
                        decIwPartsConsumed = row.Item("IwPartsConsumed")
                        decTotalPartsConsumed = row.Item("TotalPartsConsumed")
                        decPrimeCostTotal = row.Item("PrimeCostTotal")
                        decGrossProfit = row.Item("GrossProfit")
                        decFinalPercentage = row.Item("FinalPercentage")

                        intNumberOfCountersTot = intNumberOfCountersTot + intNumberOfCounters
                        intNumberOfBusinessDatTot = intNumberOfBusinessDatTot + intNumberOfBusinessDat
                        intNumberOfStaffsTot = intNumberOfStaffsTot + intNumberOfStaffs

                        intCustomerVisitTot = intCustomerVisitTot + intCustomerVisit
                        intCallRegisteredTot = intCallRegisteredTot + intCallRegistered
                        intRepairCompletedTot = intRepairCompletedTot + intRepairCompleted
                        intGoodsDeliveredTot = intGoodsDeliveredTot + intGoodsDelivered
                        intPendingTot = intPendingTot + intPending
                        intWarrantyTot = intWarrantyTot + intWarranty
                        intInWarrantyTot = intInWarrantyTot + intInWarranty
                        intOutWarrantyTot = intOutWarrantyTot + intOutWarranty
                        decInWarrantyAmountTot = decInWarrantyAmountTot + decInWarrantyAmount
                        decInWarrantyLabourTot = decInWarrantyLabourTot + decInWarrantyLabour
                        decInWarrantyPartsTot = decInWarrantyPartsTot + decInWarrantyParts
                        decInWarrantyTransportTot = decInWarrantyTransportTot + decInWarrantyTransport
                        decInWarrantyOthersTot = decInWarrantyOthersTot + decInWarrantyOthers
                        decOutWarrantyAmountTot = decOutWarrantyAmountTot + decOutWarrantyAmount
                        decOutWarrantyLabourTot = decOutWarrantyLabourTot + decOutWarrantyLabour
                        decOutWarrantyPartsTot = decOutWarrantyPartsTot + decOutWarrantyParts
                        decOutWarrantyTransportTot = decOutWarrantyTransportTot + decOutWarrantyTransport
                        decOutWarrantyOthersTot = decOutWarrantyOthersTot + decOutWarrantyOthers
                        decSawDiscountLabourTot = decSawDiscountLabourTot + decSawDiscountLabour
                        decSawDiscountPartsTot = decSawDiscountPartsTot + decSawDiscountParts
                        decOutWarrantyLabourwSawDiscTot = decOutWarrantyLabourwSawDiscTot + decOutWarrantyLabourwSawDisc
                        decOutWarrantyPartswSawDiscTot = decOutWarrantyPartswSawDiscTot + decOutWarrantyPartswSawDisc
                        decRevenueWithoutTaxTot = decRevenueWithoutTaxTot + decRevenueWithoutTax
                        decIwPartsConsumedTot = decIwPartsConsumedTot + decIwPartsConsumed
                        decTotalPartsConsumedTot = decTotalPartsConsumedTot + decTotalPartsConsumed
                        decPrimeCostTotalTot = decPrimeCostTotalTot + decPrimeCostTotal
                        decGrossProfitTot = decGrossProfitTot + decGrossProfit
                        decFinalPercentageTot = decFinalPercentageTot + decFinalPercentage


                        rowTitle = rowTitle & "," & strDate

                        rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCounters
                        rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDat
                        rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffs

                        rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisit
                        rowCallRegistered = rowCallRegistered & "," & intCallRegistered
                        rowRepairCompleted = rowRepairCompleted & "," & intRepairCompleted
                        rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDelivered
                        rowPending = rowPending & "," & intPending
                        rowWarranty = rowWarranty & "," & intWarranty
                        rowInWarranty = rowInWarranty & "," & intInWarranty
                        rowOutWarranty = rowOutWarranty & "," & intOutWarranty
                        rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmount
                        rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabour
                        rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyParts
                        rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransport
                        rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthers
                        rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmount
                        rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabour
                        rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyParts
                        rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransport
                        rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthers
                        rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabour
                        rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountParts
                        rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDisc
                        rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDisc
                        rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTax
                        rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumed
                        rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumed
                        rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotal
                        rowGrossProfit = rowGrossProfit & "," & decGrossProfit
                        'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentage

                        If decRevenueWithoutTax = 0 Then
                            FinalPercentage1 = decGrossProfit
                        Else
                            FinalPercentage1 = comcontrol.Money_Round((decGrossProfit / decRevenueWithoutTax) * 100, 2)
                        End If
                        rowFinalPercentage = rowFinalPercentage & "," & FinalPercentage1 & "%" 'decFinalPercentage / 100
                    Next row
                End If

                ' lblText.Text = lblText.Text & "intMaxCount = " & intMaxCount & "    PeriodCurrentFrom =" & PeriodCurrentFrom & " PeriodCurrentTo = " & PeriodCurrentTo & "<br>"
                If PeriodTo <= PeriodCurrentTo Then
                    lpContinue = False
                End If
                If intMaxCount >= 51 Then
                    lpContinue = False
                End If
            End While

            'For Total Displa
            rowTitle = rowTitle & ",Total"

            rowNumberOfCounters = rowNumberOfCounters & "," '& intNumberOfCountersTot
            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," '& intNumberOfBusinessDatTot
            rowNumberOfStaffs = rowNumberOfStaffs & "," '& intNumberOfStaffsTot

            rowCustomerVisit = rowCustomerVisit & "," & intCustomerVisitTot
            rowCallRegistered = rowCallRegistered & "," & intCallRegisteredTot
            rowRepairCompleted = rowRepairCompleted & "," & intRepairCompletedTot
            rowGoodsDelivered = rowGoodsDelivered & "," & intGoodsDeliveredTot
            rowPending = rowPending & "," & intPendingTot
            rowWarranty = rowWarranty & "," & intWarrantyTot
            rowInWarranty = rowInWarranty & "," & intInWarrantyTot
            rowOutWarranty = rowOutWarranty & "," & intOutWarrantyTot
            rowInWarrantyAmount = rowInWarrantyAmount & "," & decInWarrantyAmountTot
            rowInWarrantyLabour = rowInWarrantyLabour & "," & decInWarrantyLabourTot
            rowInWarrantyParts = rowInWarrantyParts & "," & decInWarrantyPartsTot
            rowInWarrantyTransport = rowInWarrantyTransport & "," & decInWarrantyTransportTot
            rowInWarrantyOthers = rowInWarrantyOthers & "," & decInWarrantyOthersTot
            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & decOutWarrantyAmountTot
            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & decOutWarrantyLabourTot
            rowOutWarrantyParts = rowOutWarrantyParts & "," & decOutWarrantyPartsTot
            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & decOutWarrantyTransportTot
            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & decOutWarrantyOthersTot
            rowSawDiscountLabour = rowSawDiscountLabour & "," & decSawDiscountLabourTot
            rowSawDiscountParts = rowSawDiscountParts & "," & decSawDiscountPartsTot
            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & decOutWarrantyLabourwSawDiscTot
            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & decOutWarrantyPartswSawDiscTot
            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & decRevenueWithoutTaxTot
            rowIwPartsConsumed = rowIwPartsConsumed & "," & decIwPartsConsumedTot
            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & decTotalPartsConsumedTot
            rowPrimeCostTotal = rowPrimeCostTotal & "," & decPrimeCostTotalTot
            rowGrossProfit = rowGrossProfit & "," & decGrossProfitTot
            'rowFinalPercentage = rowFinalPercentage & "," & decFinalPercentageTot
            If decRevenueWithoutTaxTot = 0 Then ' RevenueWithoutTax = 0
                _FinalPercentage = decGrossProfitTot 'GrossProfit
            Else
                _FinalPercentage = comcontrol.Money_Round((decGrossProfitTot / decRevenueWithoutTaxTot) * 100, 2)
            End If
            rowFinalPercentage = rowFinalPercentage & "," & _FinalPercentage & "%"


            'For Display End of Label
            rowTitle = rowTitle & ","

            rowNumberOfCounters = rowNumberOfCounters & "," & "Number of counters"
            rowNumberOfBusinessDat = rowNumberOfBusinessDat & "," & "Number of Business dat"
            rowNumberOfStaffs = rowNumberOfStaffs & "," & "Number of Staffs"

            rowCustomerVisit = rowCustomerVisit & "," & "CustomerVisit"
            rowCallRegistered = rowCallRegistered & "," & "CallRegistered"
            rowRepairCompleted = rowRepairCompleted & "," & "RepairCompleted"
            rowGoodsDelivered = rowGoodsDelivered & "," & "GoodsDelivered"
            rowPending = rowPending & "," & "Pending"
            rowWarranty = rowWarranty & "," & "Warranty"
            rowInWarranty = rowInWarranty & "," & "InWarranty"
            rowOutWarranty = rowOutWarranty & "," & "OutWarranty"
            rowInWarrantyAmount = rowInWarrantyAmount & "," & "InWarrantyAmount"
            rowInWarrantyLabour = rowInWarrantyLabour & "," & "InWarrantyLabour"
            rowInWarrantyParts = rowInWarrantyParts & "," & "InWarrantyParts"
            rowInWarrantyTransport = rowInWarrantyTransport & "," & "InWarrantyTransport"
            rowInWarrantyOthers = rowInWarrantyOthers & "," & "InWarrantyOthers"
            rowOutWarrantyAmount = rowOutWarrantyAmount & "," & "OutWarrantyAmount"
            rowOutWarrantyLabour = rowOutWarrantyLabour & "," & "OutWarrantyLabour"
            rowOutWarrantyParts = rowOutWarrantyParts & "," & "OutWarrantyParts"
            rowOutWarrantyTransport = rowOutWarrantyTransport & "," & "OutWarrantyTransport"
            rowOutWarrantyOthers = rowOutWarrantyOthers & "," & "OutWarrantyOthers"
            rowSawDiscountLabour = rowSawDiscountLabour & "," & "SawDiscountLabour"
            rowSawDiscountParts = rowSawDiscountParts & "," & "SawDiscountParts"
            rowOutWarrantyLabourwSawDisc = rowOutWarrantyLabourwSawDisc & "," & "OutWarrantyLabourwSawDisc"
            rowOutWarrantyPartswSawDisc = rowOutWarrantyPartswSawDisc & "," & "OutWarrantyPartswSawDisc"
            rowRevenueWithoutTax = rowRevenueWithoutTax & "," & "RevenueWithoutTax"
            rowIwPartsConsumed = rowIwPartsConsumed & "," & "IwPartsConsumed"
            rowTotalPartsConsumed = rowTotalPartsConsumed & "," & "TotalPartsConsumed"
            rowPrimeCostTotal = rowPrimeCostTotal & "," & "PrimeCostTotal"
            rowGrossProfit = rowGrossProfit & "," & "GrossProfit"
            rowFinalPercentage = rowFinalPercentage & "," & " "


            csvContents.Add(row0)
            csvContents.Add(rowTitle)

            csvContents.Add(rowNumberOfCounters)
            csvContents.Add(rowNumberOfBusinessDat)
            csvContents.Add(rowNumberOfStaffs)

            csvContents.Add(rowCustomerVisit)
            csvContents.Add(rowCallRegistered)
            csvContents.Add(rowRepairCompleted)
            csvContents.Add(rowGoodsDelivered)
            csvContents.Add(rowPending)
            csvContents.Add(rowWarranty)
            csvContents.Add(rowInWarranty)
            csvContents.Add(rowOutWarranty)
            csvContents.Add(rowInWarrantyAmount)
            csvContents.Add(rowInWarrantyLabour)
            csvContents.Add(rowInWarrantyParts)
            csvContents.Add(rowInWarrantyTransport)
            csvContents.Add(rowInWarrantyOthers)
            csvContents.Add(rowOutWarrantyAmount)
            csvContents.Add(rowOutWarrantyLabour)
            csvContents.Add(rowOutWarrantyParts)
            csvContents.Add(rowOutWarrantyTransport)
            csvContents.Add(rowOutWarrantyOthers)
            csvContents.Add(rowSawDiscountLabour)
            csvContents.Add(rowSawDiscountParts)
            csvContents.Add(rowOutWarrantyLabourwSawDisc)
            csvContents.Add(rowOutWarrantyPartswSawDisc)
            csvContents.Add(rowRevenueWithoutTax)
            csvContents.Add(rowIwPartsConsumed)
            csvContents.Add(rowTotalPartsConsumed)
            csvContents.Add(rowPrimeCostTotal)
            csvContents.Add(rowGrossProfit)
            csvContents.Add(rowFinalPercentage)

            Dim csvFileName As String
            'Dim dateFrom As String
            'Dim dateTo As String
            Dim clsSetCommon As New Class_common
            Dim dtNow As DateTime = clsSetCommon.dtIndia
            Dim exportFile As String = Session("export_File")

            Dim outputPath As String

            'PeriodFrom = Replace(PeriodFrom, "/", "")
            'PeriodTo = Replace(PeriodTo, "/", "")

            strDay = PeriodFrom.Day()
            strMon = PeriodFrom.Month
            strYear = PeriodFrom.Year

            If Len(strDay) <= 1 Then
                strDay = "0" & strDay
            End If
            If Len(strMon) <= 1 Then
                strMon = "0" & strMon
            End If

            Dim strDay1 As String = ""
            Dim strMon1 As String = ""
            Dim strYear1 As String = ""

            strDay1 = PeriodTo.Day()
            strMon1 = PeriodTo.Month
            strYear1 = PeriodTo.Year

            If Len(strDay1) <= 1 Then
                strDay = "0" & strDay1
            End If
            If Len(strMon1) <= 1 Then
                strMon = "0" & strMon1
            End If


            csvFileName = "SM_SPECIFIED_PERIOD_PL_" & DropListLocation.SelectedItem.Text & "_" & strYear & strMon & strDay & "_" & strYear1 & strMon1 & strDay1 & ".csv"

            ' csvFileName = exportFile & "_ " & DropListLocation.SelectedItem.Text & "_" & PeriodFrom.Year & PeriodFrom.Month & PeriodFrom.Day & "_" & PeriodTo.Year & PeriodTo.Month & PeriodTo.Day & ".csv"

            outputPath = clsSet.CsvFilePass & csvFileName

            Using writer As New StreamWriter(outputPath, False, Encoding.Default)
                writer.WriteLine(String.Join(Environment.NewLine, csvContents))
            End Using

            Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)
            If outputPath <> "" Then
                If System.IO.File.Exists(outputPath) = True Then
                    System.IO.File.Delete(outputPath)
                End If
            End If
            Response.ContentType = "application/text/csv"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)
            Response.Flush()
            'Response.Write("<b>File Contents: </b>")
            Response.BinaryWrite(Buffer)
            'Response.WriteFile(outputPath) 'if not required dialog box to user, then make comment this line
            Response.End()

        End If





        'Dim _SalesReportModel As SalesReportModel = New SalesReportModel()
        'Dim _SalesReportControl As SalesReportControl = New SalesReportControl()


        'Dim dtSalesReportView As DataTable = _SalesReportControl.SelectSalesReport(_SalesReportModel)
        'If (dtSalesReportView Is Nothing) Or (dtSalesReportView.Rows.Count = 0) Then
        '    'If no Records
        '    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
        '    Exit Sub
        'Else
        '    Response.ContentType = "text/csv"
        '    Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
        '    Response.AddHeader("Pragma", "no-cache")
        '    Response.AddHeader("Cache-Control", "no-cache")
        '    Dim myData As Byte() = CommonControl.csvBytesWriter(dtSalesReportView)
        '    Response.BinaryWrite(myData)
        '    Response.Flush()
        '    Response.SuppressContent = True
        '    HttpContext.Current.ApplicationInstance.CompleteRequest()
        'End If


    End Sub
    Public Shared Function StrToByteArray(ByVal str As String) As Byte()
        Dim encoding As System.Text.UTF8Encoding = New System.Text.UTF8Encoding()
        Return encoding.GetBytes(str)
    End Function

    'Protected Sub btnExport_Click(sender As Object, e As ImageClickEventArgs) Handles btnExport.Click


    'If DropListLocation.Text = "Select Branch" Then
    '    Call showMsg("Please specify Branch.", "")
    '    Exit Sub
    'End If


    'Dim ShipName As String = Session("ship_Name")
    'Dim shipCode As String = Session("ship_code")
    'Dim userName As String = Session("user_Name")
    'Dim userid As String = Session("user_id")
    'Dim uploadShipname As String = DropListLocation.Text
    'Dim listHistoryMsg() As String = Session("list_History_Msg")

    'Dim _StockOverviewModel As StockOverviewModel = New StockOverviewModel()
    'Dim _StockOverviewControl As StockOverviewControl = New StockOverviewControl()
    'Dim strFileName As String = DropListLocation.SelectedItem.Text & "_" & DropDownYear.SelectedItem.Value & DropDownMonth.SelectedItem.Value & ".csv"
    '_StockOverviewModel.UserId = userid
    '_StockOverviewModel.UserName = userName
    '_StockOverviewModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
    '_StockOverviewModel.strMonth = DropDownYear.SelectedItem.Value & "/" & DropDownMonth.SelectedItem.Value

    'Dim dtStockOverview As DataTable = _StockOverviewControl.SelectStockOverviewCountExport(_StockOverviewModel)
    'If (dtStockOverview Is Nothing) Or (dtStockOverview.Rows.Count = 0) Then
    '    'If no Records
    '    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
    '    Exit Sub
    'Else

    '    Response.ContentType = "text/csv"
    '    Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
    '    Response.AddHeader("Pragma", "no-cache")
    '    Response.AddHeader("Cache-Control", "no-cache")
    '    Dim myData As Byte() = CommonControl.csvBytesWriter(dtStockOverview)
    '    Response.BinaryWrite(myData)
    '    Response.Flush()
    '    Response.SuppressContent = True
    '    HttpContext.Current.ApplicationInstance.CompleteRequest()
    'End If
    '   End Sub



    Sub DefaultDisplay()
        lblMonth.Visible = False
        DropDownMonth.Visible = False
        DropDownYear.Visible = False

        lblDateFrom.Visible = False
        TextDateFrom.Visible = False
        lblDateTo.Visible = False
        TextDateTo.Visible = False
        WeeklyRevenue.Visible = False
        CallLoad.Visible = False 'Added for Call Load

    End Sub

    Protected Sub DrpType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrpType.SelectedIndexChanged
        DefaultDisplay()
        If DrpType.SelectedValue = "0" Then

        ElseIf DrpType.SelectedValue = "01" Then

        ElseIf DrpType.SelectedValue = "02" Then
            lblMonth.Visible = True
            DropDownMonth.Visible = True
            DropDownYear.Visible = True

        ElseIf DrpType.SelectedValue = "03" Then
            lblDateFrom.Visible = True
            TextDateFrom.Visible = True
            lblDateTo.Visible = True
            TextDateTo.Visible = True
        End If
    End Sub
    Protected Sub DropdownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropdownList1.SelectedIndexChanged


        If DropdownList1.SelectedValue = "Select" Then

            TextBox5.Text = "0.00"
            TextBox6.Text = "0.00"

        Else

            Dim cnstr As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
            Using Con As SqlConnection = New SqlConnection(cnstr)
                Using cmd As SqlCommand = New SqlCommand("Select  SUM(CREDIT_LIMIT) CREDIT_LIMIT,SUM (PER_DAY) PER_DAY  from R_CREDIT_I Where BRANCH_NO='" & DropdownList1.SelectedItem.Text & "'; ")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = Con
                    Con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        sdr.Read()
                        TextBox5.Text = sdr("CREDIT_LIMIT").ToString
                        TextBox6.Text = sdr("PER_DAY").ToString
                    End Using
                    Con.Close()
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                End Using
            End Using

        End If
    End Sub


    Protected Sub drpManagementFunc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpManagementFunc.SelectedIndexChanged

        DefaultDisplay()
        Stored.Visible = False
        Credit.Visible = False
        Getdta.Visible = False
        Label3.Visible = False
        Label43.Visible = False
        LblINFO.Visible = False
        Label40.Visible = False
        P1.Visible = False
        Table1.Visible = False
        Table5.Visible = False
        Table7.Visible = False
        Table9.Visible = False
        Label91.Visible = False
        lblmontlytaget.Visible = False


        'PO_Collection
        Label200.Visible = False
        TableCollections.Visible = False

        tblSingle.Visible = False
        tblSingleRWT.Visible = False
        tblSingleSDT.Visible = False
        Table2.Visible = False
        Table3.Visible = False
        Label104.Visible = False
        TextFromDate.Text = ""
        Table6.Visible = False
        tblPaymentGrid.Visible = False
        TextToDate.Text = ""
        P2.Visible = False
        Label32.Visible = True
        Monthytarget.Visible = False
        lblmontlytaget.Visible = False
        LoadDB()

        If drpManagementFunc.SelectedValue = "01" Then
            Stored.Visible = True
            Credit.Visible = False
            Getdta.Visible = False
            Label3.Visible = True
            Label43.Visible = False
            Label91.Visible = False

            'PO_Collection
            Label200.Visible = False
            TableCollections.Visible = False

            LblINFO.Visible = False
            Label40.Visible = False
            P1.Visible = False
            Table1.Visible = False
            Table2.Visible = False
            Table3.Visible = False
            Label104.Visible = False
            P2.Visible = False
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False
            TextFromDate.Text = ""
            Table6.Visible = False
            tblPaymentGrid.Visible = False
            TextToDate.Text = ""

            Label32.Visible = False
            Monthytarget.Visible = False
            lblmontlytaget.Visible = False
            LoadDB1()
            LoadDB()
        End If
        If drpManagementFunc.SelectedValue = "02" Then
            Stored.Visible = False
            Credit.Visible = True
            Getdta.Visible = True
            Label3.Visible = False
            Label43.Visible = True
            LblINFO.Visible = True
            Label40.Visible = False
            Label91.Visible = False

            'PO_Collection
            Label200.Visible = False
            TableCollections.Visible = False

            P1.Visible = False
            Table1.Visible = False
            Table2.Visible = False
            Table3.Visible = False
            Label104.Visible = False
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False
            TextFromDate.Text = ""
            TextToDate.Text = ""
            P2.Visible = False
            Table6.Visible = False
            tblPaymentGrid.Visible = False

            Label32.Visible = False
            Monthytarget.Visible = False
            lblmontlytaget.Visible = False
            LoadDB()


        End If
        If drpManagementFunc.SelectedValue = "00" Then
            Stored.Visible = False
            Credit.Visible = False
            Getdta.Visible = False
            Label3.Visible = False
            Label43.Visible = False
            Label91.Visible = False

            'PO_Collection
            Label200.Visible = False
            TableCollections.Visible = False

            LblINFO.Visible = False
            Label40.Visible = False
            P1.Visible = False
            Table1.Visible = False
            Table2.Visible = False
            Table3.Visible = False
            Label104.Visible = False
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False

            TextFromDate.Text = ""
            TextToDate.Text = ""
            P2.Visible = False
            Table5.Visible = False
            Table7.Visible = False

            Table6.Visible = False
            tblPaymentGrid.Visible = False

            Label32.Visible = False
            Monthytarget.Visible = False
            lblmontlytaget.Visible = False
            LoadDB()
            LoadDB1()
        End If
        If drpManagementFunc.SelectedValue = "03" Then
            Stored.Visible = False
            Credit.Visible = False
            Getdta.Visible = False
            Label3.Visible = False
            Label43.Visible = False
            LblINFO.Visible = False
            Label40.Visible = True
            TextFromDate.Text = ""
            TextToDate.Text = ""
            Label91.Visible = False

            'PO_Collection
            Label200.Visible = False
            TableCollections.Visible = False
            Label32.Visible = False


            P1.Visible = True
            Table1.Visible = True
            Table2.Visible = True
            Table3.Visible = False
            Label104.Visible = False
            P2.Visible = False
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False


            Table6.Visible = False
            tblPaymentGrid.Visible = False

            Label32.Visible = False
            Monthytarget.Visible = False
            lblmontlytaget.Visible = False
            LoadDB()
            LoadDB1()
        End If

        If drpManagementFunc.SelectedValue = "04" Then
            Stored.Visible = False
            Credit.Visible = False
            Getdta.Visible = False
            Label3.Visible = False
            Label43.Visible = False
            LblINFO.Visible = False
            Label40.Visible = False
            Label91.Visible = False
            Label32.Visible = False

            'PO_Collection
            Label200.Visible = False
            TableCollections.Visible = False

            TextFromDate.Text = ""
            TextToDate.Text = ""
            P1.Visible = False
            Table1.Visible = False
            Table2.Visible = False
            Table3.Visible = True
            P2.Visible = False
            Label104.Visible = True
            Table6.Visible = False
            tblPaymentGrid.Visible = False
            Table5.Visible = False
            Table7.Visible = False

            Label32.Visible = False
            Table9.Visible = False
            Monthytarget.Visible = False
            lblmontlytaget.Visible = False

            LoadDB()
            LoadDB1()

        End If

        If drpManagementFunc.SelectedValue = "05" Then
            Stored.Visible = False
            Credit.Visible = False
            Getdta.Visible = False
            Label3.Visible = False
            Label43.Visible = False
            LblINFO.Visible = False
            Label40.Visible = False
            P1.Visible = False
            Table1.Visible = False
            Label91.Visible = True
            Label32.Visible = False

            'PO_Collection
            Label200.Visible = False
            TableCollections.Visible = False

            Table2.Visible = False
            Table3.Visible = False
            Label104.Visible = False
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False
            TextFromDate.Text = ""
            TextToDate.Text = ""
            txtPaymentAmount.Text = ""
            txtTargetDate.Text = ""
            P2.Visible = False
            Table6.Visible = True
            tblPaymentGrid.Visible = True

            Label32.Visible = False
            Monthytarget.Visible = False
            lblmontlytaget.Visible = False
            LoadDB()
            Dim _PaymentVlaueControl As PaymentValueControl = New PaymentValueControl()
            Dim dtDisplayPaymentValue As DataTable = _PaymentVlaueControl.ShowPaymentValueGrid()
            'dtDisplayPaymentValue.DefaultView.Sort = "Id ASC"
            dtDisplayPaymentValue = dtDisplayPaymentValue.DefaultView.ToTable()
            If Not dtDisplayPaymentValue Is Nothing Then
                If dtDisplayPaymentValue.Rows.Count > 0 Then
                    txtPageSize.Visible = True
                    lblPagesize.Visible = True
                    txtPageSize.Text = 10
                    gvDisplayPaymentValue.PageSize = Convert.ToInt16(txtPageSize.Text)
                    gvDisplayPaymentValue.Visible = True
                    gvDisplayPaymentValue.AllowSorting = True
                    gvDisplayPaymentValue.PageIndex = 0
                    gvDisplayPaymentValue.DataSource = dtDisplayPaymentValue
                    gvDisplayPaymentValue.DataBind()

                    'btnExport.Visible = True
                    'lblErrorMessage.Visible = True
                    lblErrorMessage.Visible = False
                    lbltotal.Text = "Total No of Records : " & dtDisplayPaymentValue.Rows.Count
                    'lblTitle.Text = drpTaskExport.SelectedItem.Text
                Else
                    gvDisplayPaymentValue.AllowSorting = False
                    gvDisplayPaymentValue.DataBind()
                    gvDisplayPaymentValue.Visible = False
                    lblErrorMessage.Visible = False
                    'btnExport.Visible = False
                    txtPageSize.Visible = False
                    lblPagesize.Visible = False
                End If
            End If


        End If


        'PO_Collection
        If drpManagementFunc.SelectedValue = "06" Then
            Stored.Visible = False
            Credit.Visible = False
            Getdta.Visible = False
            Label3.Visible = False
            Label43.Visible = False
            LblINFO.Visible = False
            Label40.Visible = False
            P1.Visible = False
            Table1.Visible = False
            Label91.Visible = False
            Label32.Visible = False
            'PO_Collection
            Label200.Visible = True
            Table2.Visible = False
            Table3.Visible = False
            Label104.Visible = False
            Table5.Visible = False
            Table7.Visible = False

            Table9.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False

            TextFromDate.Text = ""
            TextToDate.Text = ""
            TextBoxDeposit.Text = ""
            TextBoxCreditSales.Text = ""
            TextBoxTargetDate.Text = ""
            P2.Visible = False
            Table6.Visible = False
            tblPaymentGrid.Visible = False
            TableCollections.Visible = True
            Monthytarget.Visible = False
            lblmontlytaget.Visible = False
            LoadDB()

        End If


        If drpManagementFunc.SelectedValue = "07" Then
            Stored.Visible = False
            Credit.Visible = False
            Getdta.Visible = False
            Label3.Visible = False
            Label43.Visible = False
            LblINFO.Visible = False
            Label40.Visible = False
            P1.Visible = False
            Table1.Visible = False
            Label91.Visible = False
            Label200.Visible = False
            Table2.Visible = False
            Table3.Visible = False
            Label104.Visible = False
            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False
            TextFromDate.Text = ""
            TextToDate.Text = ""
            TextBoxDeposit.Text = ""
            TextBoxCreditSales.Text = ""
            TextBoxTargetDate.Text = ""
            P2.Visible = False
            Table6.Visible = False
            tblPaymentGrid.Visible = False
            TableCollections.Visible = False
            Monthytarget.Visible = True
            lblmontlytaget.Visible = True
            DropdownList7.SelectedIndex = 0
            DropDownMonth2.SelectedIndex = 0
            DropDownYear2.SelectedIndex = 0
            targetamtbox.Text = ""
            targetcallload.Text = ""
            LoadDB()

            Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()
            Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
            '_Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text
            Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid(_Monthlytargetmodel)
            ' If dtDisplaymonthlytarget.Rows(5) Then

            'End If

            ' Dim dr As DataRow = dtDisplaymonthlytarget.Select["TARGET_CALLLOAD_COUNT"]
            ' var name = dr[0]["NAME"].ToString();
            'var contact = dr[0]["CONTACT"].ToString();



            dtDisplaymonthlytarget = dtDisplaymonthlytarget.DefaultView.ToTable()
            If Not dtDisplaymonthlytarget Is Nothing Then
                If dtDisplaymonthlytarget.Rows.Count > 0 Then
                    txtPageSize1.Visible = True
                    lblPagesize1.Visible = True
                    txtPageSize1.Text = 10
                    gvMonthlytarget.PageSize = Convert.ToInt16(txtPageSize1.Text)
                    gvMonthlytarget.Visible = True
                    gvMonthlytarget.AllowSorting = True
                    gvMonthlytarget.PageIndex = 0
                    gvMonthlytarget.DataSource = dtDisplaymonthlytarget
                    gvMonthlytarget.DataBind()

                    'btnExport.Visible = True
                    'lblErrorMessage.Visible = True
                    lblErrorMessage1.Visible = False
                    lbltotal.Text = "Total No of Records : " & dtDisplaymonthlytarget.Rows.Count
                    'lblTitle.Text = drpTaskExport.SelectedItem.Text
                    indata.Visible = True
                    nodata.Visible = False

                Else
                    gvMonthlytarget.AllowSorting = False
                    gvMonthlytarget.DataBind()
                    gvMonthlytarget.Visible = False
                    lblErrorMessage.Visible = False
                    'btnExport.Visible = False
                    txtPageSize1.Visible = False
                    lblPagesize1.Visible = False
                    indata.Visible = False
                    nodata.Visible = True
                End If
            End If
        End If

        If drpManagementFunc.SelectedValue = "08" Then
            WeeklyRevenue.Visible = True

        End If

        If drpManagementFunc.SelectedValue = "09" Then 'Added for Call Load
            CallLoad.Visible = True

        End If


    End Sub


    Protected Sub ImageButton2_Click(sender As Object, e As EventArgs)
        If IsPostBack Then

            Dim Droplistlocation1 As String = DropdownList1.SelectedItem.Text
            Dim CREDIT_LIMIT As String = Trim(TextBox3.Text)
            Dim PERDAY As String = Trim(TextBox4.Text)
            If DropdownList1.SelectedItem.Text = "select" Then
                Call showMsg("Please select a branch.", "")
                Exit Sub
            End If
            If (CREDIT_LIMIT = "") And (PERDAY = "") Then
                Call showMsg("Please enter Any one value.", "")
                Exit Sub
            End If
            If Not (CommonControl.isNumberDR(TextBox3.Text) And
                    CommonControl.isNumberDR(TextBox4.Text)) Then
                Call showMsg("Only enter cash...", "")
                Exit Sub
            End If

            Dim creditInfoModel As New CreditModel

            Dim CreditInfocontrol As New CreditControl
            creditInfoModel.BRANCH_NO = DropdownList1.SelectedItem.Text
            creditInfoModel.CREDIT_LIMIT = TextBox3.Text
            creditInfoModel.PER_DAY = TextBox4.Text
            Dim insertCredit As Boolean = CreditInfocontrol.Insert_Credit_info(creditInfoModel)
            If (insertCredit = True) Then
                Call showMsg("Data updated successfully in " & DropdownList1.SelectedItem.Text, "")

            End If
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = "0.00"
            TextBox6.Text = "0.00"
            LoadDB()
            DropdownList1.Text = "Select"

        End If
    End Sub



    Public Sub LoadDB()

        Dim creditInfoModel As New CreditModel
        Dim CreditInfocontrol As New CreditControl
        Dim _Datatble As DataTable = CreditInfocontrol.Get_Credit_info(creditInfoModel)
        Dim _dataview As New DataView(_Datatble)
        CreitInfo.DataSource = _dataview
        CreitInfo.DataBind()
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = "0.00"
        TextBox6.Text = "0.00"

    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As EventArgs)
        Dim GSTIN As String = Trim(TextBox3.Text)

        If DropDownList2.SelectedItem.Text = "Select" Then
            Call showMsg("Please select a branch.", "")
            Exit Sub
        End If
        If (TextBox7.Text = "") Then
            Call showMsg("Please enter the value.", "")
            Exit Sub
        End If


        Dim creditInfoModel As New CreditModel
        Dim CreditIcontrol As New CreditControl
        creditInfoModel.ship_Name = DropDownList2.SelectedItem.Text
        creditInfoModel.GSTIN = TextBox7.Text
        Dim InsertGSTIN As Boolean = CreditIcontrol.Insert_GSTIN(creditInfoModel)
        If (InsertGSTIN = True) Then
            Call showMsg("Data updated successfully in " & DropDownList2.SelectedItem.Text, "")
        End If
        LoadDB1()
        TextBox7.Text = ""
        TextBox1.Text = "0.00"
        DropDownList2.Text = "Select"

    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs)

        If DropDownList2.SelectedValue = "Select" Then

            TextBox7.Text = ""
            TextBox1.Text = "0.00"

        Else

            Dim cnstr As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
            Using Con As SqlConnection = New SqlConnection(cnstr)
                Using cmd As SqlCommand = New SqlCommand("select GSTIN From M_ship_base Where ship_Name='" & DropDownList2.SelectedItem.Text & "'; ")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = Con
                    Con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        sdr.Read()
                        TextBox1.Text = sdr("GSTIN").ToString
                    End Using
                    Con.Close()
                End Using
            End Using
        End If
    End Sub

    Public Sub LoadDB1()
        Dim creditInfoModel As New CreditModel
        Dim CreditInfocontrol As New CreditControl
        Dim _Datatble As DataTable = CreditInfocontrol.Get_GSTIN(creditInfoModel)
        Dim _dataview As New DataView(_Datatble)
        GridView2.DataSource = _dataview
        GridView2.DataBind()
        TextBox1.Text = "0.00"
        TextBox7.Text = ""
        DropdownList1.SelectedItem.Text = "select"

    End Sub

    Protected Sub ImageButton4_Click(sender As Object, e As EventArgs) Handles ImageButton4.Click

        If TextFromDate.Text = "" And TextToDate.Text = "" Then
            Call showMsg("Please Select The Date", "")
            Exit Sub
            'ElseIf TextToDate.Text = "" Then
            '    Call showMsg("Please Select To Date", "")
            '    Exit Sub
        ElseIf DropDownList4.SelectedItem.Text = "Select" Then
            Call showMsg("Please Select To Type", "")
            Exit Sub
        ElseIf DropdownList3.SelectedItem.Text = "ALL" Then
            Table5.Visible = False
            Table7.Visible = False

            Table9.Visible = False
            tblSingle.Visible = False
            tblSingleRWT.Visible = False
            tblSingleSDT.Visible = False

        ElseIf DropdownList3.SelectedItem.Text = "" Then
            tblSingle.Visible = True
            tblSingleRWT.Visible = True

            Table5.Visible = False
            Table7.Visible = False
            Table9.Visible = False
        End If

        'viewdata()

        Dim DtFrom As String = ""
        Dim DtTo As String = ""
        DtFrom = Trim(TextFromDate.Text)
        DtTo = Trim(TextToDate.Text)
        Dim chkValidDate
        chkValidDate = CommonControl.ChkIsDate(DtFrom)
        If chkValidDate = False Then
            Call showMsg("From Date is not valid Date", "")
            Exit Sub
        End If
        chkValidDate = CommonControl.ChkIsDate(DtTo)
        If chkValidDate = False Then
            Call showMsg("To Date is not valid Date", "")
            Exit Sub
        End If

        Dim dateresult As Int16 = DateTime.Compare(DtFrom, DtTo)

        If (dateresult < 0) Then
            ' Console.WriteLine("First date is earlier")
        ElseIf (dateresult = 0) Then
            'Console.WriteLine("Both dates are same")
        Else
            Call showMsg("From date should be less then or equal To date", "")
            Exit Sub
            'Console.WriteLine("First date is later")
        End If
        ' Task = 1 'Assign From or To or both filter
        If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
            Dim date1, date2 As Date
            date1 = Date.Parse(TextFromDate.Text)
            date2 = Date.Parse(TextToDate.Text)
            If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                Call showMsg("Please verify from date and to date", "")
                Exit Sub
            End If
        End If



        If Len(DtFrom) > 5 And DtTo = "" Then
            DtTo = DtFrom
        End If
        If DtFrom = "" And Len(DtTo) > 5 Then
            DtFrom = DtTo
        End If


        Dim dtTbl1, dtTbl2 As DateTime
        If (Trim(DtFrom) <> "") Then
            If DateTime.TryParse(DtFrom, dtTbl1) Then
                dtTbl1 = DateTime.Parse(Trim(DtFrom)).ToShortDateString
            Else
                Call showMsg("There is an error in the date specification", "")
                Exit Sub
            End If
        End If
        If (Trim(DtTo) <> "") Then
            If DateTime.TryParse(DtTo, dtTbl2) Then
                dtTbl2 = DateTime.Parse(Trim(DtTo)).ToShortDateString
            Else
                Call showMsg("There is an error in the date specification", "")
                Exit Sub
            End If
        End If
        'End If


        Try
            Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
            Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

            Sc_Drs_Model.BranchName = DropdownList3.SelectedItem.Text
            Sc_Drs_Model.DateFrom = TextFromDate.Text
            Sc_Drs_Model.DateTo = TextToDate.Text




            'Dim dtScDsrViewCount As DataTable = Sc_Drs_Control.StoreManagement_drsCounts(Sc_Drs_Model)

            'Sc_Drs_Control.StoreManagement_drsCounts(Sc_Drs_Model)

            Dim PositionStart As Integer = 0
            If Len(Trim(DtFrom)) > 7 Then
                PositionStart = InStr(1, DtFrom, "/")
                If PositionStart = 0 Then ' There is no _ symbol in the file name
                    Call showMsg("Please verify date format (MM/DD/YYYY)", "")
                    Exit Sub
                End If
            End If
            If Len(Trim(DtTo)) > 7 Then
                PositionStart = InStr(1, DtTo, "/")
                If PositionStart = 0 Then ' There is no _ symbol in the file name
                    Call showMsg("Please verify date format(MM/DD/YYYY)", "")
                    Exit Sub
                End If
            End If

            'DateConversion
            Dim DtConvFrom() As String
            DtConvFrom = Split(DtFrom, "/")
            If Len(DtConvFrom(0)) = 1 Then
                DtConvFrom(0) = "0" & DtConvFrom(0)
            End If
            If Len(DtConvFrom(1)) = 1 Then
                DtConvFrom(1) = "0" & DtConvFrom(1)
            End If
            Sc_Drs_Model.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
            'DateConversion
            Dim DtConvTo() As String
            DtConvTo = Split(DtTo, "/")
            If Len(DtConvTo(0)) = 1 Then
                DtConvTo(0) = "0" & DtConvTo(0)
            End If
            If Len(DtConvTo(1)) = 1 Then
                DtConvTo(1) = "0" & DtConvTo(1)
            End If

            Sc_Drs_Model.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)

            If DropdownList3.SelectedItem.Text = "ALL" Then
                Dim AllBranches As String
                For i As Integer = 1 To DropdownList3.Items.Count - 1
                    AllBranches = AllBranches + "'" + DropdownList3.Items(i).Text + "',"
                Next
                AllBranches = Left(AllBranches, Len(AllBranches) - 1)
                Sc_Drs_Model.BranchName = AllBranches
            Else
                Dim Branche As String
                Branche = DropdownList3.SelectedItem.Text
                Sc_Drs_Model.BranchName = "'" & Branche & "'"
            End If


            'Export started

            'Dim userName As String = Session("user_Name")
            'Dim userid As String = Session("user_id")

            If DropDownList4.SelectedItem.Text = "CSV" Then
                Dim _ScDsrModel As ScDsrModel = New ScDsrModel()
                Dim _ScDsrControl As ScDsrControl = New ScDsrControl()
                Dim strFileName As String = ""
                '_ScDsrModel.UserId = userid
                '_ScDsrModel.UserName = userName

                If DropdownList3.SelectedItem.Text = "ALL" Then
                    'Dim AllBranches As String
                    'For i As Integer = 1 To DropdownList3.Items.Count - 1
                    '    AllBranches = AllBranches + "'" + DropdownList3.Items(i).Text + "',"
                    'Next
                    'AllBranches = Left(AllBranches, Len(AllBranches) - 1)
                    'Sc_Drs_Model.BranchName = AllBranches
                    'strFileName = _ScDsrModel.BranchName & "rajatest" & ".csv"
                    Dim dtScDsrView As DataTable

                    If chkCancellation.Checked Then
                        dtScDsrView = Sc_Drs_Control.StoreManagement_drsCountsCancellation(Sc_Drs_Model)
                    Else
                        dtScDsrView = Sc_Drs_Control.StoreManagement_drsCounts(Sc_Drs_Model)
                    End If

                    Dim dtScDsrRevWoTaxView As DataTable = Sc_Drs_Control.StoreManagement_RevWoTax(Sc_Drs_Model)
                    'Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
                    If (dtScDsrView Is Nothing) Or (dtScDsrView.Rows.Count = 0) Then
                        Table5.Visible = False
                        tblSingle.Visible = False
                        tblSingleRWT.Visible = False
                        tblSingleSDT.Visible = False
                        'If no Records
                        Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                        Exit Sub
                    Else
                        'for multi export
                        ExportExcel(dtScDsrView, dtScDsrRevWoTaxView, "ALL", "", DtConvFrom(2) & "" & DtConvFrom(0) & "" & DtConvFrom(1), DtConvTo(2) & "" & DtConvTo(0) & "" & DtConvTo(1))
                    End If
                    If (dtScDsrRevWoTaxView Is Nothing) Or (dtScDsrRevWoTaxView.Rows.Count = 0) Then
                        Table7.Visible = False

                        Table9.Visible = False
                        '   tblSingle.Visible = False
                        tblSingleRWT.Visible = False
                        tblSingleSDT.Visible = False
                        'If no Records
                        Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                        Exit Sub
                    Else
                        'for multi export
                        ' ExportExcel(dtScDsrRevWoTaxView, "ALL", "", DtConvFrom(2) & "" & DtConvFrom(0) & "" & DtConvFrom(1), DtConvTo(2) & "" & DtConvTo(0) & "" & DtConvTo(1))
                    End If
                Else
                    'for single
                    Dim Branche As String
                    Branche = DropdownList3.SelectedItem.Text
                    Sc_Drs_Model.BranchName = "'" & Branche & "'"
                    Dim _DataTable As DataTable
                    If chkCancellation.Checked Then
                        _DataTable = Sc_Drs_Control.StoreManagement_drsCountsCancellation(Sc_Drs_Model)
                    Else
                        _DataTable = Sc_Drs_Control.StoreManagement_drsCounts(Sc_Drs_Model)
                    End If
                    Dim dtScDsrRevWoTaxView As DataTable = Sc_Drs_Control.StoreManagement_RevWoTax(Sc_Drs_Model)
                    ' Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)

                    If (_DataTable Is Nothing) Or (_DataTable.Rows.Count = 0) Then
                        Table5.Visible = False
                        tblSingle.Visible = False
                        'tblSingleRWT.Visible = False
                        Call showMsg("No Record Found", "")
                        Exit Sub
                    Else
                        'for single export
                        ExportExcel(_DataTable, dtScDsrRevWoTaxView, "", Branche, DtConvFrom(2) & "" & DtConvFrom(0) & "" & DtConvFrom(1), DtConvTo(2) & "" & DtConvTo(0) & "" & DtConvTo(1))
                    End If
                    If (dtScDsrRevWoTaxView Is Nothing) Or (dtScDsrRevWoTaxView.Rows.Count = 0) Then
                        Table7.Visible = False

                        Table9.Visible = False
                        'tblSingle.Visible = False
                        tblSingleRWT.Visible = False
                        tblSingleSDT.Visible = False

                        Call showMsg("No Record Found", "")
                        Exit Sub
                    Else
                        'for single export
                        'ExportExcel(dtScDsrRevWoTaxView, "", Branche, DtConvFrom(2) & "" & DtConvFrom(0) & "" & DtConvFrom(1), DtConvTo(2) & "" & DtConvTo(0) & "" & DtConvTo(1))
                    End If
                End If

            End If

            If DropDownList4.SelectedItem.Text = "Output" Then
                If DropdownList3.SelectedItem.Text = "ALL" Then


                    Dim _DataTable As DataTable
                    If chkCancellation.Checked Then
                        _DataTable = Sc_Drs_Control.StoreManagement_drsCountsCancellation(Sc_Drs_Model)
                    Else
                        _DataTable = Sc_Drs_Control.StoreManagement_drsCounts(Sc_Drs_Model)
                    End If
                    Dim dtScDsrRevWoTaxView As DataTable = Sc_Drs_Control.StoreManagement_RevWoTax(Sc_Drs_Model)
                    'Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
                    If (_DataTable Is Nothing) Or (_DataTable.Rows.Count = 0) Then
                        tblSingle.Visible = False
                        Table5.Visible = False
                        Call showMsg("No Record Found", "")
                        Exit Sub
                        Table5.Visible = False
                    Else
                        Table3.Visible = True
                        Table5.Visible = False

                        lblSSC1IW.Text = "0"
                        lblSSC1OW.Text = "0"
                        lblIO1.Text = "0"

                        lblSSC2IW.Text = "0"
                        lblSSC2OW.Text = "0"
                        lblIO2.Text = "0"

                        lblSSC3IW.Text = "0"
                        lblSSC3OW.Text = "0"
                        lblIO3.Text = "0"

                        lblSSC4IW.Text = "0"
                        lblSSC4OW.Text = "0"
                        lblIO4.Text = "0"

                        lblSSC5IW.Text = "0"
                        lblSSC5OW.Text = "0"
                        lblIO5.Text = "0"

                        lblSSC6IW.Text = "0"
                        lblSSC6OW.Text = "0"
                        lblIO6.Text = "0"

                        lblSSC7IW.Text = "0"
                        lblSSC7OW.Text = "0"
                        lblIO7.Text = "0"


                        lblSSC8IW.Text = "0"
                        lblSSC8OW.Text = "0"
                        lblIO8.Text = "0"


                        lblSSC9IW.Text = "0"
                        lblSSC9OW.Text = "0"
                        lblIO9.Text = "0"

                        'SSC10
                        lblSSC10IW.Text = "0"
                        lblSSC10OW.Text = "0"
                        lblI10.Text = "0"

                        'SSC11
                        lblSSC11IW.Text = "0"
                        lblSSC11OW.Text = "0"




                        lblI11.Text = "0"



                        Dim rwIndex As String
                        For Each item As DataRow In _DataTable.Rows
                            If (item.Item("Branch_name").ToString = "SSC1") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString
                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC1IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC1IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC1OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC1OW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO1.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO1.Text = 0
                                End If


                            ElseIf (item.Item("Branch_name").ToString = "SSC2") Then

                                rwIndex = item.Table.Rows.IndexOf(item).ToString
                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC2IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC2IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC2OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC2OW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO2.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO2.Text = 0
                                End If


                            ElseIf (item.Item("Branch_name").ToString = "SSC3") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC3IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC3IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC3OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC3OW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO3.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO3.Text = 0
                                End If

                            ElseIf (item.Item("Branch_name").ToString = "SSC4") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString
                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC4IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC4IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC4OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC4OW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO4.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO4.Text = 0
                                End If

                            ElseIf (item.Item("Branch_name").ToString = "SSC5") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC5IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC5IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC5OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC5OW.Text = 0
                                End If

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO5.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO5.Text = 0
                                End If

                            ElseIf (item.Item("Branch_name").ToString = "SSC6") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC6IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC6IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC6OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC6OW.Text = 0
                                End If

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO6.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO6.Text = 0
                                End If


                            ElseIf (item.Item("Branch_name").ToString = "SSC7") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString
                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC7IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC7IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC7OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC7OW.Text = 0
                                End If

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO7.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO7.Text = 0
                                End If

                            ElseIf (item.Item("Branch_name").ToString = "SSC8") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC8IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC8IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC8OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC8OW.Text = 0
                                End If

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO8.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO8.Text = 0
                                End If

                            ElseIf (item.Item("Branch_name").ToString = "SSC9") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString
                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC9IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC9IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC9OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC9OW.Text = 0
                                End If

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblIO9.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblIO9.Text = 0
                                End If

                                'SSC10
                            ElseIf (item.Item("Branch_name").ToString = "SSC10") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC10IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC10IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC10OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC10OW.Text = 0
                                End If

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblI10.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblI10.Text = 0
                                End If
                            ElseIf (item.Item("Branch_name").ToString = "SSC11") Then
                                rwIndex = item.Table.Rows.IndexOf(item).ToString

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total").ToString().Length > 0 Then
                                    lblSSC11IW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("IW_goods_total")
                                Else
                                    lblSSC11IW.Text = 0
                                End If


                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total").ToString().Length > 0 Then
                                    lblSSC11OW.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("OW_goods_total")
                                Else
                                    lblSSC11OW.Text = 0
                                End If

                                If _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods").ToString().Length > 0 Then
                                    lblI11.Text = _DataTable.Rows(Convert.ToInt32(rwIndex))("TotalGoods")
                                Else
                                    lblI11.Text = 0
                                End If
                            End If

                        Next
                        Table5.Visible = True
                        'Table5.Visible = False
                    End If
                    If (dtScDsrRevWoTaxView Is Nothing) Or (dtScDsrRevWoTaxView.Rows.Count = 0) Then
                        'tblSingle.Visible = False
                        tblSingleRWT.Visible = False
                        tblSingleSDT.Visible = False
                        Table7.Visible = False
                        Table9.Visible = False
                        Call showMsg("No Record Found", "")
                        Exit Sub
                        Table7.Visible = False
                        Table9.Visible = False
                    Else
                        Table3.Visible = True
                        Table7.Visible = False
                        Table9.Visible = False



                        Dim rwIndex As String
                        For Each item As DataRow In dtScDsrRevWoTaxView.Rows
                            If (item.Item("Branch_name").ToString = "SSC1") Then
                                lblRWTSSC1.Text = item.Item("RevWoTax").ToString
                                lblSDSSC1L.Text = item.Item("Labor").ToString
                                lblSDSSC1P.Text = item.Item("Parts").ToString
                                lblSDSSC1T.Text = Convert.ToDecimal(lblSDSSC1L.Text) + Convert.ToDecimal(lblSDSSC1P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC2") Then
                                lblRWTSSC2.Text = item.Item("RevWoTax").ToString
                                lblSDSSC2L.Text = item.Item("Labor").ToString
                                lblSDSSC2P.Text = item.Item("Parts").ToString
                                lblSDSSC2T.Text = Convert.ToDecimal(lblSDSSC2L.Text) + Convert.ToDecimal(lblSDSSC2P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC3") Then
                                lblRWTSSC3.Text = item.Item("RevWoTax").ToString
                                lblSDSSC3L.Text = item.Item("Labor").ToString
                                lblSDSSC3P.Text = item.Item("Parts").ToString
                                lblSDSSC3T.Text = Convert.ToDecimal(lblSDSSC3L.Text) + Convert.ToDecimal(lblSDSSC3P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC4") Then
                                lblRWTSSC4.Text = item.Item("RevWoTax").ToString
                                lblSDSSC4L.Text = item.Item("Labor").ToString
                                lblSDSSC4P.Text = item.Item("Parts").ToString
                                lblSDSSC4T.Text = Convert.ToDecimal(lblSDSSC4L.Text) + Convert.ToDecimal(lblSDSSC4P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC5") Then
                                lblRWTSSC5.Text = item.Item("RevWoTax").ToString
                                lblSDSSC5L.Text = item.Item("Labor").ToString
                                lblSDSSC5P.Text = item.Item("Parts").ToString
                                lblSDSSC5T.Text = Convert.ToDecimal(lblSDSSC5L.Text) + Convert.ToDecimal(lblSDSSC5P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC6") Then
                                lblRWTSSC6.Text = item.Item("RevWoTax").ToString
                                lblSDSSC6L.Text = item.Item("Labor").ToString
                                lblSDSSC6P.Text = item.Item("Parts").ToString
                                lblSDSSC6T.Text = Convert.ToDecimal(lblSDSSC6L.Text) + Convert.ToDecimal(lblSDSSC6P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC7") Then
                                lblRWTSSC7.Text = item.Item("RevWoTax").ToString
                                lblSDSSC7L.Text = item.Item("Labor").ToString
                                lblSDSSC7P.Text = item.Item("Parts").ToString
                                lblSDSSC7T.Text = Convert.ToDecimal(lblSDSSC7L.Text) + Convert.ToDecimal(lblSDSSC7P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC8") Then
                                lblRWTSSC8.Text = item.Item("RevWoTax").ToString
                                lblSDSSC8L.Text = item.Item("Labor").ToString
                                lblSDSSC8P.Text = item.Item("Parts").ToString
                                lblSDSSC8T.Text = Convert.ToDecimal(lblSDSSC8L.Text) + Convert.ToDecimal(lblSDSSC8P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC9") Then
                                lblRWTSSC9.Text = item.Item("RevWoTax").ToString
                                lblSDSSC9L.Text = item.Item("Labor").ToString
                                lblSDSSC9P.Text = item.Item("Parts").ToString
                                lblSDSSC9T.Text = Convert.ToDecimal(lblSDSSC9L.Text) + Convert.ToDecimal(lblSDSSC9P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC10") Then
                                lblRWTSSC10.Text = item.Item("RevWoTax").ToString
                                lblSDSSC10L.Text = item.Item("Labor").ToString
                                lblSDSSC10P.Text = item.Item("Parts").ToString
                                lblSDSSC10T.Text = Convert.ToDecimal(lblSDSSC10L.Text) + Convert.ToDecimal(lblSDSSC10P.Text)

                            ElseIf (item.Item("Branch_name").ToString = "SSC11") Then
                                lblRWTSSC11.Text = item.Item("RevWoTax").ToString
                                lblSDSSC11L.Text = item.Item("Labor").ToString
                                lblSDSSC11P.Text = item.Item("Parts").ToString
                                lblSDSSC11T.Text = Convert.ToDecimal(lblSDSSC11L.Text) + Convert.ToDecimal(lblSDSSC11P.Text)

                            End If

                        Next
                        Table7.Visible = True
                        'Table9.Visible = True Commented VJ 20201006
                        'Table5.Visible = False
                    End If
                Else

                    Dim _DataTable As DataTable

                    If chkCancellation.Checked Then
                        _DataTable = Sc_Drs_Control.StoreManagement_drsCountsCancellation(Sc_Drs_Model)
                    Else
                        _DataTable = Sc_Drs_Control.StoreManagement_drsCounts(Sc_Drs_Model)
                    End If
                    Dim dtScDsrRevWoTaxView As DataTable = Sc_Drs_Control.StoreManagement_RevWoTax(Sc_Drs_Model)
                    'Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
                    If (_DataTable Is Nothing) Or (_DataTable.Rows.Count = 0) Then
                        tblSingle.Visible = False

                        Table5.Visible = False
                        'Call showMsg("No Record Found", "")
                        'Exit Sub
                    Else
                        tblSingle.Visible = True
                        If _DataTable.Rows.Count = 0 Then
                        Else
                            lblBranchname.Text = _DataTable.Rows(0)("Branch_name")

                            If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                                lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                            Else
                                lblSSCSIW.Text = 0
                            End If



                            If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                                lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                            Else
                                lblSSCSOW.Text = 0
                            End If


                            If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                                lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                            Else
                                lblTotalSingle.Text = 0
                            End If
                        End If
                        'If _DataTable.Rows(0)("Branch_name") = "SSC1" Then

                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")

                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If



                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If


                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If

                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC2" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")
                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If




                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If


                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If

                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC3" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")
                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If





                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If
                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If


                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC4" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")
                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If

                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If




                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If

                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC5" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")
                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If

                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If




                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If


                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC6" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")
                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If

                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If
                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If

                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC7" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")
                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If

                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If
                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If

                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC8" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")
                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If

                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If
                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If
                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC9" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")
                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If

                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If
                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If
                        '        'SSC10
                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC10" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")

                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If


                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If

                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If
                        '    ElseIf _DataTable.Rows(0)("Branch_name") = "SSC11" Then
                        '        lblBranchname.Text = _DataTable.Rows(0)("Branch_name")

                        '        If _DataTable.Rows(0)("IW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSIW.Text = _DataTable.Rows(0)("IW_goods_total")
                        '        Else
                        '            lblSSCSIW.Text = 0
                        '        End If


                        '        If _DataTable.Rows(0)("OW_goods_total").ToString().Length > 0 Then
                        '            lblSSCSOW.Text = _DataTable.Rows(0)("OW_goods_total")
                        '        Else
                        '            lblSSCSOW.Text = 0
                        '        End If

                        '        If _DataTable.Rows(0)("TotalGoods").ToString().Length > 0 Then
                        '            lblTotalSingle.Text = _DataTable.Rows(0)("TotalGoods")
                        '        Else
                        '            lblTotalSingle.Text = 0
                        '        End If
                        '    End If
                        Table3.Visible = True
                        Table5.Visible = False
                        'tblSingle.Visible = False
                    End If
                    If (dtScDsrRevWoTaxView Is Nothing) Or (dtScDsrRevWoTaxView.Rows.Count = 0) Then
                        'tblSingle.Visible = False
                        tblSingleRWT.Visible = False
                        tblSingleSDT.Visible = False
                        Table7.Visible = False
                        Table9.Visible = False
                        Call showMsg("No Record Found", "")
                        Exit Sub
                    Else
                        'tblSingle.Visible = True
                        tblSingleRWT.Visible = True
                        'tblSingleSDT.Visible = True Commented VJ 20201006
                        lblSSCName.Text = dtScDsrRevWoTaxView.Rows(0)("Branch_name")
                        lblSSCNameRWT.Text = dtScDsrRevWoTaxView.Rows(0)("RevWoTax")

                        lblSDSSCName.Text = dtScDsrRevWoTaxView.Rows(0)("Branch_name")
                        lblSDSSCLabour.Text = dtScDsrRevWoTaxView.Rows(0)("Labor")
                        lblSDSSCPart.Text = dtScDsrRevWoTaxView.Rows(0)("Parts")
                        lblSDSSCLabourPartTotal.Text = Convert.ToDecimal(lblSDSSCLabour.Text) + Convert.ToDecimal(lblSDSSCPart.Text)

                        Table3.Visible = True
                        Table7.Visible = False
                        Table9.Visible = False
                        tblSingleRWT.Visible = True
                        'tblSingleSDT.Visible = True Commented VJ 20201006
                        'tblSingle.Visible = False
                    End If
                End If
            End If

            If DropDownList4.SelectedItem.Text = "Excel" Then
                Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
                DailyRevenueExcel(dtDailyRevenue, Sc_Drs_Model)
            End If



        Catch ex As Exception
            Call showMsg(ex.Message, "")
        End Try

    End Sub

    Public Sub DailyRevenueExcel(ByVal dtDailyRevenue As DataTable, ByVal Sc_Drs_Model As ScDsrModel)
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)

        If Sc_Drs_Model.BranchName.Contains(",") Then
            Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
        End If

        Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})

        Log4NetControl.ComInfoLogWrite("1")
        Dim misValue As Object = System.Reflection.Missing.Value
        Log4NetControl.ComInfoLogWrite("2")
        Dim xlApp As Excel.Application
        Log4NetControl.ComInfoLogWrite("3")

        Dim xlWorkBook As Excel.Workbook
        Log4NetControl.ComInfoLogWrite("4")

        Dim xlWorkSheet As Excel.Worksheet
        Log4NetControl.ComInfoLogWrite("5")
        xlApp = New Excel.Application
        Log4NetControl.ComInfoLogWrite("6")

        xlWorkBook = xlApp.Workbooks.Add(misValue)
        Log4NetControl.ComInfoLogWrite("7")

        xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        Log4NetControl.ComInfoLogWrite("8")

        Dim rowblock As Integer
        rowblock = 0
        Dim BranchPos As Integer
        BranchPos = 0

        Dim modpos As Integer
        Dim gra As Integer
        gra = 20
        Dim head As Integer
        head = 1
        Dim total As Integer
        total = 0

        Dim noofrec As Integer
        noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())
        Dim footer As Integer
        footer = 1
        Dim blanspa As Integer
        blanspa = 5
        Dim noofcol As Integer
        noofcol = 4
        Dim crow As Integer
        crow = 1
        Dim rowblk As Boolean
        rowblk = False
        Dim ExistRow As Integer
        ExistRow = 0
        Dim rowgrp As Integer
        rowgrp = 0
        For Each branch As String In SplitBrances
            Dim filter As String
            filter = "SSCNAME = " & branch
            Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

            Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
            Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
            Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

            BranchPos += 1
            modpos = BranchPos Mod 4

            If modpos = 1 Then
                rowblock += 1
                rowblk = True
                ExistRow = crow
            Else
                rowblk = False
            End If

            If modpos = 0 Then
                modpos = 4
            End If

            If rowblk = True Then
                crow += gra 'Graph
                crow += head
                xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 1) = ""
                xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 2) = branch.Replace("'", "") & " Target".Trim()
                xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 3) = "Total"
                xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 4) = "Day"
                crow += total
                'xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 1) = ""
                'xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 2) = tagtDayAmt
                'xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 3) = DayTgtAmt
                'xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 4) = ""

                For Each row As DataRow In tabresult
                    'Dim rw As Integer
                    'rw = gra + ((noofrec * rowblock) - noofrec) + 2
                    crow += 1
                    xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 1) = row(0)
                    xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 2) = row(5)
                    xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 3) = row(6)
                    xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 4) = row(4)
                    'Console.WriteLine("{0}, {1}", row(0), row(1))
                Next
                crow += footer
                xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 1) = ""
                xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 2) = ""
                xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 3) = ActDayAmt
                xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 4) = ""

                For a = 1 To blanspa
                    crow += 1
                    xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 1) = ""
                    xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 2) = ""
                    xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 3) = ""
                    xlWorkSheet.Cells(crow, ((modpos * 4) - 4) + 4) = ""
                    'Console.WriteLine("value of a: {0}", a)
                Next

                ''create chart

                Dim chartPage As Excel.Chart

                Dim xlCharts As Excel.ChartObjects

                Dim myChart As Excel.ChartObject

                Dim chartRange As Excel.Range



                xlCharts = xlWorkSheet.ChartObjects

                myChart = xlCharts.Add(10, 80, 195, 250)
                'myChart.Width = "11 CM"
                'myChart.Width = "7 cm"

                chartPage = myChart.Chart

                chartRange = xlWorkSheet.Range("A" & (crow - blanspa - tabresult.Count() - 1), "C" & (crow - blanspa) - 1)



                chartPage.SetSourceData(Source:=chartRange)


                chartPage.Legend.Delete()
                'chartPage.HasTitle = True

                'chartPage.ChartTitle.Characters.Text = "TEST MESSAGE1"
                'chartPage.ChartType = Excel.XlChartType.xlLineMarkers
                chartPage.ChartType = Excel.XlChartType.xlLine
                'chartPage.HasAxis = True
                'chartPage.ChartArea.Top = xlWorkSheet.Rows((gra + head + total + noofrec + footer + blanspa) * rowblock - (gra + head + total + noofrec + footer + blanspa) + 1)
                'With xlCharts
                '    .Top = chartRange(1).Top
                '    .Left = chartRange(1).Left
                '    '.Width = chartRange.Width
                '    '.Height = chartRange.Height
                'End With
                myChart.Left = 0
                If rowblock = 1 Then
                    rowgrp = 15
                Else
                    'rowgrp = (rowblock - 1) * ((gra + head + total + noofrec + footer + blanspa) * 15) - (5 * rowgrp)
                    rowgrp = (rowblock - 1) * ((gra + head + total + noofrec + footer + blanspa) * 15) + (11 * rowblock)
                End If
                myChart.Top = rowgrp
                'myChart.Top = (rowblock - 1) * ((gra + head + total + noofrec + footer + blanspa) * 15) + 15
                'myChart.Top = xlWorkSheet.Rows((gra + head + total + noofrec + footer + blanspa) * rowblock - (gra + head + total + noofrec + footer + blanspa) + 1)
            Else
                'ExistRow += gra 'Graph
                'crow += head
                xlWorkSheet.Cells(ExistRow + gra + head, ((modpos * 4) - 4) + 1) = ""
                xlWorkSheet.Cells(ExistRow + gra + head, ((modpos * 4) - 4) + 2) = branch.Replace("'", "") & " Target"
                xlWorkSheet.Cells(ExistRow + gra + head, ((modpos * 4) - 4) + 3) = "Total"
                xlWorkSheet.Cells(ExistRow + gra + head, ((modpos * 4) - 4) + 4) = "Day"
                crow += total
                'xlWorkSheet.Cells(ExistRow + gra + head + total, ((modpos * 4) - 4) + 1) = ""
                'xlWorkSheet.Cells(ExistRow + gra + head + total, ((modpos * 4) - 4) + 2) = tagtDayAmt
                'xlWorkSheet.Cells(ExistRow + gra + head + total, ((modpos * 4) - 4) + 3) = DayTgtAmt
                'xlWorkSheet.Cells(ExistRow + gra + head + total, ((modpos * 4) - 4) + 4) = ""
                Dim Rowid As Integer
                Rowid = 1
                For Each row As DataRow In tabresult
                    'Dim rw As Integer
                    'rw = gra + ((noofrec * rowblock) - noofrec) + 2
                    'crow += 1
                    xlWorkSheet.Cells(ExistRow + gra + head + total + Rowid, ((modpos * 4) - 4) + 1) = row(0)
                    xlWorkSheet.Cells(ExistRow + gra + head + total + Rowid, ((modpos * 4) - 4) + 2) = row(5)
                    xlWorkSheet.Cells(ExistRow + gra + head + total + Rowid, ((modpos * 4) - 4) + 3) = row(6)
                    xlWorkSheet.Cells(ExistRow + gra + head + total + Rowid, ((modpos * 4) - 4) + 4) = row(4)
                    Rowid += 1
                    'Console.WriteLine("{0}, {1}", row(0), row(1))
                Next
                'crow += 1
                xlWorkSheet.Cells(ExistRow + gra + head + total + noofrec + footer, ((modpos * 4) - 4) + 1) = ""
                xlWorkSheet.Cells(ExistRow + gra + head + total + noofrec + footer, ((modpos * 4) - 4) + 2) = ""
                xlWorkSheet.Cells(ExistRow + gra + head + total + noofrec + footer, ((modpos * 4) - 4) + 3) = ActDayAmt
                xlWorkSheet.Cells(ExistRow + gra + head + total + noofrec + footer, ((modpos * 4) - 4) + 4) = ""

                For a = 1 To blanspa
                    'crow += 1
                    xlWorkSheet.Cells(ExistRow + gra + head + total + noofrec + footer + a, ((modpos * 4) - 4) + 1) = ""
                    xlWorkSheet.Cells(ExistRow + gra + head + total + noofrec + footer + a, ((modpos * 4) - 4) + 2) = ""
                    xlWorkSheet.Cells(ExistRow + gra + head + total + noofrec + footer + a, ((modpos * 4) - 4) + 3) = ""
                    xlWorkSheet.Cells(ExistRow + gra + head + total + noofrec + footer + a, ((modpos * 4) - 4) + 4) = ""
                    'Console.WriteLine("value of a: {0}", a)
                Next


                Dim chartPage As Excel.Chart



                Dim xlCharts As Excel.ChartObjects

                Dim myChart As Excel.ChartObject

                Dim chartRange As Excel.Range



                xlCharts = xlWorkSheet.ChartObjects

                myChart = xlCharts.Add(10, 80, 185, 250)
                'myChart.Width = "11 CM"
                'myChart.Width = "7 cm"

                chartPage = myChart.Chart
                If modpos = 2 Then
                    chartRange = xlWorkSheet.Range("E" & (crow - blanspa - tabresult.Count() - 1), "G" & (crow - (blanspa + 1)))
                    myChart.Top = rowgrp
                    'myChart.Top = (rowblock - 1) * ((gra + head + total + noofrec + footer + blanspa) * 15) + 15
                    myChart.Left = 200
                ElseIf modpos = 3 Then
                    chartRange = xlWorkSheet.Range("I" & (crow - blanspa - tabresult.Count() - 1), "K" & (crow - (blanspa + 1)))
                    myChart.Top = rowgrp
                    'myChart.Top = (rowblock - 1) * ((gra + head + total + noofrec + footer + blanspa) * 15) + 15
                    myChart.Left = 400
                ElseIf modpos = 4 Then
                    chartRange = xlWorkSheet.Range("M" & (crow - blanspa - tabresult.Count() - 1), "O" & (crow - (blanspa + 1)))
                    myChart.Top = rowgrp
                    'myChart.Top = (rowblock - 1) * ((gra + head + total + noofrec + footer + blanspa) * 15) + 15
                    myChart.Left = 600
                End If





                chartPage.SetSourceData(Source:=chartRange)

                chartPage.Legend.Delete()

                'chartPage.HasTitle = True

                'chartPage.ChartTitle.Characters.Text = "TEST MESSAGE1"
                'chartPage.ChartType = Excel.XlChartType.xlLineMarkers
                chartPage.ChartType = Excel.XlChartType.xlLine
                'chartPage.HasAxis = True
                'chartPage.ChartArea.Top = xlWorkSheet.Rows((gra + head + total + noofrec + footer + blanspa) * rowblock - (gra + head + total + noofrec + footer + blanspa) + 1)
                'With xlCharts
                '    .Top = chartRange(1).Top
                '    .Left = chartRange(1).Left
                '    '.Width = chartRange.Width
                '    '.Height = chartRange.Height
                'End With
                'myChart.Top = (rowblock - 1) * ((gra + head + total + noofrec + footer + blanspa) * 15) + 15
                'myChart.Left = 125 * modpos
                'myChart.Left = 0


            End If

            xlWorkSheet.Cells(1, 1) = "From Date :"
            xlWorkSheet.Cells(1, 2) = Sc_Drs_Model.DateFrom
            xlWorkSheet.Cells(1, 3) = "To Date :"
            xlWorkSheet.Cells(1, 4) = Sc_Drs_Model.DateTo

        Next





        xlWorkSheet.Cells.EntireColumn.AutoFit()

        'xlWorkSheet.Columns(5).delete()
        'xlWorkSheet.Columns(8).delete()
        'xlWorkSheet.Columns(11).delete()


        Dim fname As String
        fname = "C:\DailyRevenue\" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".xlsx"
        Log4NetControl.ComInfoLogWrite("Path: Being" & fname)
        xlWorkSheet.SaveAs(fname)
        Log4NetControl.ComInfoLogWrite("Path: End" & fname)
        xlWorkBook.Close()

        'xlWorkSheet = xlApp.Workbooks.Open("C:\DailyRevenue" & DateTime.Now.ToString("ddMMyyyyHHmmss000") & ".xls")

        'xlApp.Quit()


        Dim xlsApp As Excel.Application = Nothing
        Dim xlsWorkBooks As Excel.Workbooks = Nothing
        Dim xlsWB As Excel.Workbook = Nothing

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsWorkBooks = xlsApp.Workbooks
        xlsWB = xlsWorkBooks.Open(fname)

        releaseObject(xlApp)

        releaseObject(xlWorkBook)

        releaseObject(xlWorkSheet)
    End Sub



    Function SonyPlTracking(strYear As String, strMonth As String) As DataTable

        'Return Table
        Dim tblSIDSales As DataTable
        tblSIDSales = New DataTable("SIDSALES")
        Dim column1 As DataColumn = New DataColumn("SalesDate")
        column1.DataType = System.Type.GetType("System.String")

        Dim column2 As DataColumn = New DataColumn("SalesAmount")
        column2.DataType = System.Type.GetType("System.String")

        tblSIDSales.Columns.Add(column1)
        tblSIDSales.Columns.Add(column2)




        Dim strDate As String = ""
        Dim strMaxDay As String = ""
        strMaxDay = Date.DaysInMonth(strYear, strMonth)

        Dim strBranchName As String = ""
        Dim clsSetCommon As New Class_common
        Dim comcontrol As New CommonControl

        Dim csvContents = New List(Of String)

        '1st Left Column begin
        ''Dim rowWork1 As String = strBranchName & ","
        ''Dim rowWork2 As String = "Repair,"
        ''Dim rowWork3 As String = "DEMO,"
        ''Dim rowWork4 As String = "Installation,"
        ''Dim rowWork5 As String = ","
        ''Dim rowWork6 As String = "Warranty (Number),"
        ''Dim rowWork7 As String = "In Warranty (Number),"
        ''Dim rowWork8 As String = "Out Warranty (Number),"
        ''Dim rowWork9 As String = "Total Amount IW,"
        ''Dim rowWork10 As String = "Total Amount of Account Payable IW,"
        ''Dim rowWork11 As String = "Account Payable By ASC,"
        ''Dim rowWork12 As String = "Account Payable By Customer,"
        ''Dim rowWork13 As String = "SONY Needs To Pay/IW,"
        ''Dim rowWork14 As String = "SONY Needs To Pay/OW,"
        ''Dim rowWork15 As String = "Total Parts Fee,"
        ''Dim rowWork16 As String = "Labour Fee,"
        ''Dim rowWork17 As String = "Inspection Fee,"
        ''Dim rowWork18 As String = "Handling Fee,"
        ''Dim rowWork19 As String = "Transport Fee,"
        ''Dim rowWork20 As String = "HomeService Fee,"
        ''Dim rowWork21 As String = "Longdistans Fee,"
        ''Dim rowWork22 As String = "Travelallowance Fee,"
        ''Dim rowWork23 As String = "Da Fee,"
        ''Dim rowWork24 As String = "Demo Charge,"
        ''Dim rowWork25 As String = "Installation Fee,"
        ''Dim rowWork26 As String = "Ecall Charge,"
        ''Dim rowWork27 As String = "Combat Fee,"
        ''Dim rowWork28 As String = "Total Amount OW,"
        ''Dim rowWork29 As String = "Total Amount of Account Payable OW,"
        ''Dim rowWork30 As String = "Account Payable By ASC,"
        ''Dim rowWork31 As String = "Account Payable By Customer,"
        ''Dim rowWork32 As String = "SONY Needs To Pay,"
        ''Dim rowWork33 As String = "Total Parts Fee,"
        ''Dim rowWork34 As String = "Labour Fee,"
        ''Dim rowWork35 As String = "Inspection Fee,"
        ''Dim rowWork36 As String = "Handling Fee,"
        ''Dim rowWork37 As String = "Transport Fee,"
        ''Dim rowWork38 As String = "HomeService Fee,"
        ''Dim rowWork39 As String = "Longdistans Fee,"
        ''Dim rowWork40 As String = "Travelallowance Fee,"
        ''Dim rowWork41 As String = "Da Fee,"
        ''Dim rowWork42 As String = "Demo Charge,"
        ''Dim rowWork43 As String = "Installation Fee,"
        ''Dim rowWork44 As String = "Ecall Charge,"
        ''Dim rowWork45 As String = "Combat Fee,"
        ''Dim rowWork46 As String = "Revenue without Tax,"
        ''Dim rowWork47 As String = ","
        ''Dim rowWork48 As String = "IW parts consumed,"
        ''Dim rowWork49 As String = "Total parts consumed,"
        ''Dim rowWork50 As String = "Prime Cost Total,"
        ''Dim rowWork51 As String = "Gross Profit,"
        ''Dim rowWork52 As String = ","
        '1st Left Column End

        'Middles Start




        Dim Repair As Decimal = 0.00 ' C-1 - C-2
        Dim DEMO As Decimal = 0.00 ' Marked as C-1 DEMO_CHARGE
        Dim Installation As Decimal = 0.00 ' Marked as C-2 INSTALLATION_FEE

        Dim WarrantyNumber As Int16 = 0
        Dim InWarrantyNumber As Int16 = 0
        Dim OutWarrantyNumber As Int16 = 0

        Dim IW_TotalAmountIW As Decimal = 0.00
        Dim IW_TotalAmountOfAccountPayableIW As Decimal = 0.00
        Dim IW_AccountPayableByASC As Decimal = 0.00
        Dim IW_AccountPayableByCustomer As Decimal = 0.00
        Dim IW_SONYNeedsToPayIW As Decimal = 0.00
        Dim IW_SONYNeedsToPayOW As Decimal = 0.00
        Dim IW_TotalPartsFee As Decimal = 0.00
        Dim IW_LabourFee As Decimal = 0.00
        Dim IW_InspectionFee As Decimal = 0.00
        Dim IW_HandlingFee As Decimal = 0.00
        Dim IW_TransportFee As Decimal = 0.00
        Dim IW_HomeServiceFee As Decimal = 0.00
        Dim IW_LongdistansFee As Decimal = 0.00
        Dim IW_TravelallowanceFee As Decimal = 0.00
        Dim IW_DaFee As Decimal = 0.00
        Dim IW_DemoCharge As Decimal = 0.00
        Dim IW_InstallationFee As Decimal = 0.00
        Dim IW_EcallCharge As Decimal = 0.00
        Dim IW_CombatFee As Decimal = 0.00


        Dim OW_TotalAmountOW As Decimal = 0.00
        Dim OW_TotalAmountOfAccountPayableOW As Decimal = 0.00
        Dim OW_AccountPayableByASC As Decimal = 0.00
        Dim OW_AccountPayableByCustomer As Decimal = 0.00
        Dim OW_SONYNeedsToPay As Decimal = 0.00
        Dim OW_TotalPartsFee As Decimal = 0.00
        Dim OW_LabourFee As Decimal = 0.00
        Dim OW_InspectionFee As Decimal = 0.00
        Dim OW_HandlingFee As Decimal = 0.00
        Dim OW_TransportFee As Decimal = 0.00
        Dim OW_HomeServiceFee As Decimal = 0.00
        Dim OW_LongdistansFee As Decimal = 0.00
        Dim OW_TravelallowanceFee As Decimal = 0.00
        Dim OW_DaFee As Decimal = 0.00
        Dim OW_DemoCharge As Decimal = 0.00
        Dim OW_InstallationFee As Decimal = 0.00
        Dim OW_EcallCharge As Decimal = 0.00
        Dim OW_CombatFee As Decimal = 0.00



        Dim RevenuewithoutTax As Decimal = 0.00
        Dim IWpartsconsumed As Decimal = 0.00
        Dim Totalpartsconsumed As Decimal = 0.00
        Dim PrimeCostTotal As Decimal = 0.00
        Dim GrossProfit As Decimal = 0.00

        'Total
        Dim TOT_Repair As Decimal = 0.00 ' C-1 - C-2
        Dim TOT_DEMO As Decimal = 0.00 ' Marked as C-1 DEMO_CHARGE
        Dim TOT_Installation As Decimal = 0.00 ' Marked as C-2 INSTALLATION_FEE

        Dim TOT_WarrantyNumber As Decimal = 0.00
        Dim TOT_InWarrantyNumber As Decimal = 0.00
        Dim TOT_OutWarrantyNumber As Decimal = 0.00

        Dim TOT_IW_TotalAmountIW As Decimal = 0.00
        Dim TOT_IW_TotalAmountOfAccountPayableIW As Decimal = 0.00
        Dim TOT_IW_AccountPayableByASC As Decimal = 0.00
        Dim TOT_IW_AccountPayableByCustomer As Decimal = 0.00
        Dim TOT_IW_SONYNeedsToPayIW As Decimal = 0.00
        Dim TOT_IW_SONYNeedsToPayOW As Decimal = 0.00
        Dim TOT_IW_TotalPartsFee As Decimal = 0.00
        Dim TOT_IW_LabourFee As Decimal = 0.00
        Dim TOT_IW_InspectionFee As Decimal = 0.00
        Dim TOT_IW_HandlingFee As Decimal = 0.00
        Dim TOT_IW_TransportFee As Decimal = 0.00
        Dim TOT_IW_HomeServiceFee As Decimal = 0.00
        Dim TOT_IW_LongdistansFee As Decimal = 0.00
        Dim TOT_IW_TravelallowanceFee As Decimal = 0.00
        Dim TOT_IW_DaFee As Decimal = 0.00
        Dim TOT_IW_DemoCharge As Decimal = 0.00
        Dim TOT_IW_InstallationFee As Decimal = 0.00
        Dim TOT_IW_EcallCharge As Decimal = 0.00
        Dim TOT_IW_CombatFee As Decimal = 0.00


        Dim TOT_OW_TotalAmountOW As Decimal = 0.00
        Dim TOT_OW_TotalAmountOfAccountPayableOW As Decimal = 0.00
        Dim TOT_OW_AccountPayableByASC As Decimal = 0.00
        Dim TOT_OW_AccountPayableByCustomer As Decimal = 0.00
        Dim TOT_OW_SONYNeedsToPay As Decimal = 0.00
        Dim TOT_OW_TotalPartsFee As Decimal = 0.00
        Dim TOT_OW_LabourFee As Decimal = 0.00
        Dim TOT_OW_InspectionFee As Decimal = 0.00
        Dim TOT_OW_HandlingFee As Decimal = 0.00
        Dim TOT_OW_TransportFee As Decimal = 0.00
        Dim TOT_OW_HomeServiceFee As Decimal = 0.00
        Dim TOT_OW_LongdistansFee As Decimal = 0.00
        Dim TOT_OW_TravelallowanceFee As Decimal = 0.00
        Dim TOT_OW_DaFee As Decimal = 0.00
        Dim TOT_OW_DemoCharge As Decimal = 0.00
        Dim TOT_OW_InstallationFee As Decimal = 0.00
        Dim TOT_OW_EcallCharge As Decimal = 0.00
        Dim TOT_OW_CombatFee As Decimal = 0.00



        Dim TOT_RevenuewithoutTax As Decimal = 0.00
        Dim TOT_IWpartsconsumed As Decimal = 0.00
        Dim TOT_Totalpartsconsumed As Decimal = 0.00
        Dim TOT_PrimeCostTotal As Decimal = 0.00
        Dim TOT_GrossProfit As Decimal = 0.00

        Dim SONYNeedsToPayIW As Decimal = 0.00
        Dim SONYNeedsToPayOW As Decimal = 0.00

        Dim TOT_SONYNeedsToPayIW As Decimal = 0.00
        Dim TOT_SONYNeedsToPayOW As Decimal = 0.00


        Dim OW_TotalAmountOfAccountPayableIW As Decimal = 0.00
        Dim TOT_OW_TotalAmountOfAccountPayableIW As Decimal = 0.00
        Dim TOT_Percentage As Decimal = 0.00




        'Final For a Day 
        Dim NET_TOT_Repair As Decimal = 0.00
        Dim NET_TOT_DEMO As Decimal = 0.00
        Dim NET_TOT_Installation As Decimal = 0.00

        '# Warranty (Number) = (In Warranty (Number) + Out Warranty (Number)
        Dim NET_TOT_WarrantyNumber As Int16 = 0
        Dim NET_TOT_InWarrantyNumber As Int16 = 0
        Dim NET_TOT_OutWarrantyNumber As Int16 = 0


        '#Total Amount IW (SONY Needs To Pay/IW + SONY Needs To Pay/OW ) /1.18
        Dim NET_TOT_IW_TotalAmountIW As Decimal = 0.00
        Dim NET_TOT_IW_TotalAmountOfAccountPayableIW As Decimal = 0.00
        Dim NET_TOT_IW_AccountPayableByASC As Decimal = 0.00
        Dim NET_TOT_IW_AccountPayableByCustomer As Decimal = 0.00
        Dim NET_TOT_SONYNeedsToPayIW As Decimal = 0.00

        Dim NET_TOT_IW_TotalPartsFee As Decimal = 0.00
        Dim NET_TOT_IW_LabourFee As Decimal = 0.00
        Dim NET_TOT_IW_InspectionFee As Decimal = 0.00
        Dim NET_TOT_IW_HandlingFee As Decimal = 0.00
        Dim NET_TOT_IW_TransportFee As Decimal = 0.00
        Dim NET_TOT_IW_HomeServiceFee As Decimal = 0.00
        Dim NET_TOT_IW_LongdistansFee As Decimal = 0.00
        Dim NET_TOT_IW_TravelallowanceFee As Decimal = 0.00
        Dim NET_TOT_IW_DaFee As Decimal = 0.00
        Dim NET_TOT_IW_DemoCharge As Decimal = 0.00
        Dim NET_TOT_IW_InstallationFee As Decimal = 0.00
        Dim NET_TOT_IW_EcallCharge As Decimal = 0.00
        Dim NET_TOT_IW_CombatFee As Decimal = 0.00


        Dim NET_TOT_OW_TotalAmountOW As Decimal = 0.00
        Dim NET_TOT_OW_TotalAmountOfAccountPayableOW As Decimal = 0.00
        Dim NET_TOT_OW_AccountPayableByASC As Decimal = 0.00
        Dim NET_TOT_OW_AccountPayableByCustomer As Decimal = 0.00
        Dim NET_TOT_SONYNeedsToPayOW As Decimal = 0.00
        Dim NET_TOT_OW_TotalPartsFee As Decimal = 0.00
        Dim NET_TOT_OW_LabourFee As Decimal = 0.00
        Dim NET_TOT_OW_InspectionFee As Decimal = 0.00

        Dim NET_TOT_OW_HandlingFee As Decimal = 0.00
        Dim NET_TOT_OW_TransportFee As Decimal = 0.00
        Dim NET_TOT_OW_HomeServiceFee As Decimal = 0.00
        Dim NET_TOT_OW_LongdistansFee As Decimal = 0.00
        Dim NET_TOT_OW_TravelallowanceFee As Decimal = 0.00
        Dim NET_TOT_OW_DaFee As Decimal = 0.00
        Dim NET_TOT_OW_DemoCharge As Decimal = 0.00
        Dim NET_TOT_OW_InstallationFee As Decimal = 0.00
        Dim NET_TOT_OW_EcallCharge As Decimal = 0.00
        Dim NET_TOT_OW_CombatFee As Decimal = 0.00


        Dim NET_TOT_RevenuewithoutTax As Decimal = 0.00
        Dim NET_TOT_IWpartsconsumed As Decimal = 0.00
        Dim NET_TOT_Totalpartsconsumed As Decimal = 0.00
        Dim NET_TOT_PrimeCostTotal As Decimal = 0.00
        Dim NET_TOT_GrossProfit As Decimal = 0.00
        Dim NET_TOT_Percentage As Decimal = 0.00


        Dim strDay As String = ""
        Dim i As Integer

        For i = 1 To strMaxDay

            strDay = i
            If Len(strDay) = 1 Then
                strDay = "0" & strDay
            End If

            strDate = strYear & "/" & strMonth & "/" & strDay

            Repair = 0.0
            DEMO = 0.0
            Installation = 0.00


            WarrantyNumber = 0
            InWarrantyNumber = 0
            OutWarrantyNumber = 0

            IW_TotalAmountIW = 0.00
            IW_TotalAmountOfAccountPayableIW = 0.00
            IW_AccountPayableByASC = 0.00
            IW_AccountPayableByCustomer = 0.00
            IW_SONYNeedsToPayIW = 0.00
            IW_SONYNeedsToPayOW = 0.00
            IW_TotalPartsFee = 0.00
            IW_LabourFee = 0.00
            IW_InspectionFee = 0.00
            IW_HandlingFee = 0.00
            IW_TransportFee = 0.00
            IW_HomeServiceFee = 0.00
            IW_LongdistansFee = 0.00
            IW_TravelallowanceFee = 0.00
            IW_DaFee = 0.00
            IW_DemoCharge = 0.00
            IW_InstallationFee = 0.00
            IW_EcallCharge = 0.00
            IW_CombatFee = 0.00


            OW_TotalAmountOW = 0.00
            OW_TotalAmountOfAccountPayableOW = 0.00
            OW_AccountPayableByASC = 0.00
            OW_AccountPayableByCustomer = 0.00
            OW_SONYNeedsToPay = 0.00
            OW_TotalPartsFee = 0.00
            OW_LabourFee = 0.00
            OW_InspectionFee = 0.00
            OW_HandlingFee = 0.00
            OW_TransportFee = 0.00
            OW_HomeServiceFee = 0.00
            OW_LongdistansFee = 0.00
            OW_TravelallowanceFee = 0.00
            OW_DaFee = 0.00
            OW_DemoCharge = 0.00
            OW_InstallationFee = 0.00
            OW_EcallCharge = 0.00
            OW_CombatFee = 0.00



            RevenuewithoutTax = 0.00
            IWpartsconsumed = 0.00
            Totalpartsconsumed = 0.00
            PrimeCostTotal = 0.00
            GrossProfit = 0.00

            SONYNeedsToPayIW = 0.0
            SONYNeedsToPayOW = 0.0

            IW_TotalAmountOfAccountPayableIW = 0.0
            OW_TotalAmountOfAccountPayableIW = 0.0


            TOT_Repair = 0
            TOT_DEMO = 0
            TOT_Installation = 0



            TOT_WarrantyNumber = 0
            TOT_WarrantyNumber = 0
            TOT_InWarrantyNumber = 0
            TOT_OutWarrantyNumber = 0


            TOT_IW_TotalAmountIW = 0
            TOT_IW_TotalAmountIW = 0
            TOT_IW_TotalAmountOfAccountPayableIW = 0
            TOT_IW_AccountPayableByASC = 0
            TOT_IW_AccountPayableByCustomer = 0
            TOT_SONYNeedsToPayIW = 0
            TOT_SONYNeedsToPayOW = 0
            TOT_IW_TotalPartsFee = 0
            TOT_IW_LabourFee = 0
            TOT_IW_InspectionFee = 0
            TOT_IW_HandlingFee = 0
            TOT_IW_TransportFee = 0
            TOT_IW_HomeServiceFee = 0
            TOT_IW_LongdistansFee = 0
            TOT_IW_TravelallowanceFee = 0
            TOT_IW_DaFee = 0
            TOT_IW_DemoCharge = 0
            TOT_IW_InstallationFee = 0
            TOT_IW_EcallCharge = 0
            TOT_IW_CombatFee = 0

            TOT_OW_TotalAmountOW = 0
            TOT_OW_TotalAmountOW = 0
            TOT_OW_TotalAmountOfAccountPayableOW = 0
            TOT_OW_AccountPayableByASC = 0
            TOT_OW_AccountPayableByCustomer = 0
            TOT_SONYNeedsToPayOW = 0
            TOT_OW_TotalPartsFee = 0
            TOT_OW_LabourFee = 0
            TOT_OW_InspectionFee = 0
            TOT_OW_HandlingFee = 0
            TOT_OW_TransportFee = 0
            TOT_OW_HomeServiceFee = 0
            TOT_OW_LongdistansFee = 0
            TOT_OW_TravelallowanceFee = 0
            TOT_OW_DaFee = 0
            TOT_OW_DemoCharge = 0
            TOT_OW_InstallationFee = 0
            TOT_OW_EcallCharge = 0
            TOT_OW_CombatFee = 0

            TOT_RevenuewithoutTax = 0
            TOT_IWpartsconsumed = 0
            TOT_Totalpartsconsumed = 0
            TOT_PrimeCostTotal = 0
            TOT_GrossProfit = 0
            TOT_Percentage = 0




            Dim _SonyDeliveredSetModel As SonyDeliveredSetModel = New SonyDeliveredSetModel()
            Dim _SonyDeliveredSetControl As SonyDeliveredSetControl = New SonyDeliveredSetControl()
            _SonyDeliveredSetModel.UserId = "" 'userid
            _SonyDeliveredSetModel.SHIP_TO_BRANCH_CODE = "1019756" 'DropListLocation.SelectedItem.Value
            _SonyDeliveredSetModel.SHIP_TO_BRANCH = "SID1" 'DropListLocation.SelectedItem.Text
            _SonyDeliveredSetModel.DateFrom = strDate 'DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
            _SonyDeliveredSetModel.DateTo = strDate 'CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
            _SonyDeliveredSetModel.FILE_NAME = _SonyDeliveredSetModel.SHIP_TO_BRANCH & "_DS" & strYear & strMonth & ".csv" '_SonyDeliveredSetModel.SHIP_TO_BRANCH & "_DS" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
            Dim dtDeliveredSet As DataTable = _SonyDeliveredSetControl.SelectPLDeliveredSet(_SonyDeliveredSetModel)

            If (dtDeliveredSet Is Nothing) Or (dtDeliveredSet.Rows.Count = 0) Then
                'BYDefauly 
                Repair = 0.0
                DEMO = 0.0
                Installation = 0.00


                WarrantyNumber = 0
                InWarrantyNumber = 0
                OutWarrantyNumber = 0

                IW_TotalAmountIW = 0.00
                IW_TotalAmountOfAccountPayableIW = 0.00
                IW_AccountPayableByASC = 0.00
                IW_AccountPayableByCustomer = 0.00
                IW_SONYNeedsToPayIW = 0.00
                IW_SONYNeedsToPayOW = 0.00
                IW_TotalPartsFee = 0.00
                IW_LabourFee = 0.00
                IW_InspectionFee = 0.00
                IW_HandlingFee = 0.00
                IW_TransportFee = 0.00
                IW_HomeServiceFee = 0.00
                IW_LongdistansFee = 0.00
                IW_TravelallowanceFee = 0.00
                IW_DaFee = 0.00
                IW_DemoCharge = 0.00
                IW_InstallationFee = 0.00
                IW_EcallCharge = 0.00
                IW_CombatFee = 0.00


                OW_TotalAmountOW = 0.00
                OW_TotalAmountOfAccountPayableOW = 0.00
                OW_AccountPayableByASC = 0.00
                OW_AccountPayableByCustomer = 0.00
                OW_SONYNeedsToPay = 0.00
                OW_TotalPartsFee = 0.00
                OW_LabourFee = 0.00
                OW_InspectionFee = 0.00
                OW_HandlingFee = 0.00
                OW_TransportFee = 0.00
                OW_HomeServiceFee = 0.00
                OW_LongdistansFee = 0.00
                OW_TravelallowanceFee = 0.00
                OW_DaFee = 0.00
                OW_DemoCharge = 0.00
                OW_InstallationFee = 0.00
                OW_EcallCharge = 0.00
                OW_CombatFee = 0.00



                RevenuewithoutTax = 0.00
                IWpartsconsumed = 0.00
                Totalpartsconsumed = 0.00
                PrimeCostTotal = 0.00
                GrossProfit = 0.00

                SONYNeedsToPayIW = 0.0
                SONYNeedsToPayOW = 0.0

                IW_TotalAmountOfAccountPayableIW = 0.0
                OW_TotalAmountOfAccountPayableIW = 0.0


                TOT_Repair = 0
                TOT_DEMO = 0
                TOT_Installation = 0



                TOT_WarrantyNumber = 0
                TOT_WarrantyNumber = 0
                TOT_InWarrantyNumber = 0
                TOT_OutWarrantyNumber = 0


                TOT_IW_TotalAmountIW = 0
                TOT_IW_TotalAmountIW = 0
                TOT_IW_TotalAmountOfAccountPayableIW = 0
                TOT_IW_AccountPayableByASC = 0
                TOT_IW_AccountPayableByCustomer = 0
                TOT_SONYNeedsToPayIW = 0
                TOT_SONYNeedsToPayOW = 0
                TOT_IW_TotalPartsFee = 0
                TOT_IW_LabourFee = 0
                TOT_IW_InspectionFee = 0
                TOT_IW_HandlingFee = 0
                TOT_IW_TransportFee = 0
                TOT_IW_HomeServiceFee = 0
                TOT_IW_LongdistansFee = 0
                TOT_IW_TravelallowanceFee = 0
                TOT_IW_DaFee = 0
                TOT_IW_DemoCharge = 0
                TOT_IW_InstallationFee = 0
                TOT_IW_EcallCharge = 0
                TOT_IW_CombatFee = 0

                TOT_OW_TotalAmountOW = 0
                TOT_OW_TotalAmountOW = 0
                TOT_OW_TotalAmountOfAccountPayableOW = 0
                TOT_OW_AccountPayableByASC = 0
                TOT_OW_AccountPayableByCustomer = 0
                TOT_SONYNeedsToPayOW = 0
                TOT_OW_TotalPartsFee = 0
                TOT_OW_LabourFee = 0
                TOT_OW_InspectionFee = 0
                TOT_OW_HandlingFee = 0
                TOT_OW_TransportFee = 0
                TOT_OW_HomeServiceFee = 0
                TOT_OW_LongdistansFee = 0
                TOT_OW_TravelallowanceFee = 0
                TOT_OW_DaFee = 0
                TOT_OW_DemoCharge = 0
                TOT_OW_InstallationFee = 0
                TOT_OW_EcallCharge = 0
                TOT_OW_CombatFee = 0

                TOT_RevenuewithoutTax = 0
                TOT_IWpartsconsumed = 0
                TOT_Totalpartsconsumed = 0
                TOT_PrimeCostTotal = 0
                TOT_GrossProfit = 0
                TOT_Percentage = 0

            Else


                For DsetRow = 0 To dtDeliveredSet.Rows.Count - 1

                    'BYDefauly 
                    Repair = 0.0
                    DEMO = 0.0
                    Installation = 0.00

                    WarrantyNumber = 0
                    InWarrantyNumber = 0
                    OutWarrantyNumber = 0

                    IW_TotalAmountIW = 0.00
                    IW_TotalAmountOfAccountPayableIW = 0.00
                    IW_AccountPayableByASC = 0.00
                    IW_AccountPayableByCustomer = 0.00
                    IW_SONYNeedsToPayIW = 0.00
                    IW_SONYNeedsToPayOW = 0.00
                    IW_TotalPartsFee = 0.00
                    IW_LabourFee = 0.00
                    IW_InspectionFee = 0.00
                    IW_HandlingFee = 0.00
                    IW_TransportFee = 0.00
                    IW_HomeServiceFee = 0.00
                    IW_LongdistansFee = 0.00
                    IW_TravelallowanceFee = 0.00
                    IW_DaFee = 0.00
                    IW_DemoCharge = 0.00
                    IW_InstallationFee = 0.00
                    IW_EcallCharge = 0.00
                    IW_CombatFee = 0.00

                    OW_TotalAmountOW = 0.00
                    OW_TotalAmountOfAccountPayableOW = 0.00
                    OW_AccountPayableByASC = 0.00
                    OW_AccountPayableByCustomer = 0.00
                    OW_SONYNeedsToPay = 0.00
                    OW_TotalPartsFee = 0.00
                    OW_LabourFee = 0.00
                    OW_InspectionFee = 0.00
                    OW_HandlingFee = 0.00
                    OW_TransportFee = 0.00
                    OW_HomeServiceFee = 0.00
                    OW_LongdistansFee = 0.00
                    OW_TravelallowanceFee = 0.00
                    OW_DaFee = 0.00
                    OW_DemoCharge = 0.00
                    OW_InstallationFee = 0.00
                    OW_EcallCharge = 0.00
                    OW_CombatFee = 0.00


                    RevenuewithoutTax = 0.00
                    IWpartsconsumed = 0.00
                    Totalpartsconsumed = 0.00
                    PrimeCostTotal = 0.00
                    GrossProfit = 0.00


                    SONYNeedsToPayIW = 0.0
                    SONYNeedsToPayOW = 0.0


                    IW_TotalAmountOfAccountPayableIW = 0.0
                    OW_TotalAmountOfAccountPayableIW = 0.0



                    'TOT_Repair = 0
                    'TOT_DEMO = 0
                    'TOT_Installation = 0

                    'TOT_WarrantyNumber = 0
                    'TOT_WarrantyNumber = 0
                    'TOT_InWarrantyNumber = 0
                    'TOT_OutWarrantyNumber = 0

                    'TOT_IW_TotalAmountIW = 0
                    'TOT_IW_TotalAmountIW = 0
                    'TOT_IW_TotalAmountOfAccountPayableIW = 0
                    'TOT_IW_AccountPayableByASC = 0
                    'TOT_IW_AccountPayableByCustomer = 0
                    'TOT_SONYNeedsToPayIW = 0
                    'TOT_SONYNeedsToPayOW = 0
                    'TOT_IW_TotalPartsFee = 0
                    'TOT_IW_LabourFee = 0
                    'TOT_IW_InspectionFee = 0
                    'TOT_IW_HandlingFee = 0
                    'TOT_IW_TransportFee = 0
                    'TOT_IW_HomeServiceFee = 0
                    'TOT_IW_LongdistansFee = 0
                    'TOT_IW_TravelallowanceFee = 0
                    'TOT_IW_DaFee = 0
                    'TOT_IW_DemoCharge = 0
                    'TOT_IW_InstallationFee = 0
                    'TOT_IW_EcallCharge = 0
                    'TOT_IW_CombatFee = 0

                    'TOT_OW_TotalAmountOW = 0
                    'TOT_OW_TotalAmountOW = 0
                    'TOT_OW_TotalAmountOfAccountPayableOW = 0
                    'TOT_OW_AccountPayableByASC = 0
                    'TOT_OW_AccountPayableByCustomer = 0
                    'TOT_SONYNeedsToPayOW = 0
                    'TOT_OW_TotalPartsFee = 0
                    'TOT_OW_LabourFee = 0
                    'TOT_OW_InspectionFee = 0
                    'TOT_OW_HandlingFee = 0
                    'TOT_OW_TransportFee = 0
                    'TOT_OW_HomeServiceFee = 0
                    'TOT_OW_LongdistansFee = 0
                    'TOT_OW_TravelallowanceFee = 0
                    'TOT_OW_DaFee = 0
                    'TOT_OW_DemoCharge = 0
                    'TOT_OW_InstallationFee = 0
                    'TOT_OW_EcallCharge = 0
                    'TOT_OW_CombatFee = 0

                    'TOT_RevenuewithoutTax = 0
                    'TOT_IWpartsconsumed = 0
                    'TOT_Totalpartsconsumed = 0
                    'TOT_PrimeCostTotal = 0
                    'TOT_GrossProfit = 0



                    If dtDeliveredSet.Rows(DsetRow).Item("DEMO_CHARGE") IsNot DBNull.Value Then
                        DEMO = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("DEMO_CHARGE"), 2)
                        TOT_DEMO = TOT_DEMO + DEMO
                    End If

                    If dtDeliveredSet.Rows(DsetRow).Item("INSTALLATION_FEE") IsNot DBNull.Value Then
                        Installation = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("INSTALLATION_FEE"), 2)
                        TOT_Installation = TOT_Installation + Installation
                    End If

                    '# C-3 =  C-1 - C - 2
                    TOT_Repair = DEMO - Installation


                    If dtDeliveredSet.Rows(DsetRow).Item("WARRANTY_TYPE") IsNot DBNull.Value Then
                        Select Case UCase(dtDeliveredSet.Rows(DsetRow).Item("WARRANTY_TYPE").ToString())
                            Case "IW"

                                InWarrantyNumber = 1

                                If dtDeliveredSet.Rows(DsetRow).Item("SONY_NEEDS_TO_PAY") IsNot DBNull.Value Then
                                    SONYNeedsToPayIW = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("SONY_NEEDS_TO_PAY"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE") IsNot DBNull.Value Then
                                    IW_TotalAmountOfAccountPayableIW = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE"), 2)
                                End If


                                If dtDeliveredSet.Rows(DsetRow).Item("ACCOUNT_PAYABLE_BY_ASC") IsNot DBNull.Value Then
                                    IW_AccountPayableByASC = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("ACCOUNT_PAYABLE_BY_ASC"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("ACCOUNT_PAYABLE_BY_CUSTOMER") IsNot DBNull.Value Then
                                    IW_AccountPayableByCustomer = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("ACCOUNT_PAYABLE_BY_CUSTOMER"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("TOTAL_PART_FEE") IsNot DBNull.Value Then
                                    IW_TotalPartsFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("TOTAL_PART_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("LABOUR_FEE") IsNot DBNull.Value Then
                                    IW_LabourFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("LABOUR_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("INSPECTION_FEE") IsNot DBNull.Value Then
                                    IW_InspectionFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("INSPECTION_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("HANDLING_FEE") IsNot DBNull.Value Then
                                    IW_HandlingFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("HANDLING_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("TRANSPORT_FEE") IsNot DBNull.Value Then
                                    IW_TransportFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("TRANSPORT_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("HOMESERVICE_FEE") IsNot DBNull.Value Then
                                    IW_HomeServiceFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("HOMESERVICE_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("LONGDISTANCE_FEE") IsNot DBNull.Value Then
                                    IW_LongdistansFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("LONGDISTANCE_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("TRAVELALLOWANCE_FEE") IsNot DBNull.Value Then
                                    IW_TravelallowanceFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("TRAVELALLOWANCE_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("DA_FEE") IsNot DBNull.Value Then
                                    IW_DaFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("DA_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("DEMO_CHARGE") IsNot DBNull.Value Then
                                    IW_DemoCharge = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("DEMO_CHARGE"), 2)
                                End If


                                If dtDeliveredSet.Rows(DsetRow).Item("INSTALLATION_FEE") IsNot DBNull.Value Then
                                    IW_InstallationFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("INSTALLATION_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("ECALL_CHARGE") IsNot DBNull.Value Then
                                    IW_EcallCharge = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("ECALL_CHARGE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("COMBAT_FEE") IsNot DBNull.Value Then
                                    IW_CombatFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("COMBAT_FEE"), 2)
                                End If



                            Case "OW"


                                OutWarrantyNumber = 1

                                If dtDeliveredSet.Rows(DsetRow).Item("SONY_NEEDS_TO_PAY") IsNot DBNull.Value Then
                                    SONYNeedsToPayOW = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("SONY_NEEDS_TO_PAY"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE") IsNot DBNull.Value Then
                                    OW_TotalAmountOfAccountPayableOW = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE"), 2)
                                End If


                                If dtDeliveredSet.Rows(DsetRow).Item("ACCOUNT_PAYABLE_BY_ASC") IsNot DBNull.Value Then
                                    OW_AccountPayableByASC = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("ACCOUNT_PAYABLE_BY_ASC"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("ACCOUNT_PAYABLE_BY_CUSTOMER") IsNot DBNull.Value Then
                                    OW_AccountPayableByCustomer = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("ACCOUNT_PAYABLE_BY_CUSTOMER"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("TOTAL_PART_FEE") IsNot DBNull.Value Then
                                    OW_TotalPartsFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("TOTAL_PART_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("LABOUR_FEE") IsNot DBNull.Value Then
                                    OW_LabourFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("LABOUR_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("INSPECTION_FEE") IsNot DBNull.Value Then
                                    OW_InspectionFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("INSPECTION_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("HANDLING_FEE") IsNot DBNull.Value Then
                                    OW_HandlingFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("HANDLING_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("TRANSPORT_FEE") IsNot DBNull.Value Then
                                    OW_TransportFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("TRANSPORT_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("HOMESERVICE_FEE") IsNot DBNull.Value Then
                                    OW_HomeServiceFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("HOMESERVICE_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("LONGDISTANCE_FEE") IsNot DBNull.Value Then
                                    OW_LongdistansFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("LONGDISTANCE_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("TRAVELALLOWANCE_FEE") IsNot DBNull.Value Then
                                    OW_TravelallowanceFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("TRAVELALLOWANCE_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("DA_FEE") IsNot DBNull.Value Then
                                    OW_DaFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("DA_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("DEMO_CHARGE") IsNot DBNull.Value Then
                                    OW_DemoCharge = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("DEMO_CHARGE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("INSTALLATION_FEE") IsNot DBNull.Value Then
                                    OW_InstallationFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("INSTALLATION_FEE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("ECALL_CHARGE") IsNot DBNull.Value Then
                                    OW_EcallCharge = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("ECALL_CHARGE"), 2)
                                End If

                                If dtDeliveredSet.Rows(DsetRow).Item("COMBAT_FEE") IsNot DBNull.Value Then
                                    OW_CombatFee = comcontrol.Money_Round(dtDeliveredSet.Rows(DsetRow).Item("COMBAT_FEE"), 2)
                                End If

                        End Select

                    End If

                    TOT_InWarrantyNumber = TOT_InWarrantyNumber + InWarrantyNumber
                    TOT_OutWarrantyNumber = TOT_OutWarrantyNumber + OutWarrantyNumber

                    TOT_IW_TotalAmountOfAccountPayableIW = TOT_IW_TotalAmountOfAccountPayableIW + IW_TotalAmountOfAccountPayableIW
                    TOT_OW_TotalAmountOfAccountPayableOW = TOT_OW_TotalAmountOfAccountPayableOW + OW_TotalAmountOfAccountPayableOW

                    TOT_IW_AccountPayableByASC = TOT_IW_AccountPayableByASC + IW_AccountPayableByASC
                    TOT_OW_AccountPayableByASC = TOT_OW_AccountPayableByASC + OW_AccountPayableByASC

                    TOT_IW_AccountPayableByCustomer = TOT_IW_AccountPayableByCustomer + IW_AccountPayableByCustomer
                    TOT_OW_AccountPayableByCustomer = TOT_OW_AccountPayableByCustomer + OW_AccountPayableByCustomer

                    TOT_SONYNeedsToPayIW = TOT_SONYNeedsToPayIW + SONYNeedsToPayIW
                    TOT_SONYNeedsToPayOW = TOT_SONYNeedsToPayOW + SONYNeedsToPayOW

                    TOT_IW_TotalPartsFee = TOT_IW_TotalPartsFee + IW_TotalPartsFee
                    TOT_OW_TotalPartsFee = TOT_OW_TotalPartsFee + OW_TotalPartsFee

                    TOT_IW_LabourFee = TOT_IW_LabourFee + IW_LabourFee
                    TOT_OW_LabourFee = TOT_OW_LabourFee + OW_LabourFee

                    TOT_IW_InspectionFee = TOT_IW_InspectionFee + IW_InspectionFee
                    TOT_OW_InspectionFee = TOT_OW_InspectionFee + OW_InspectionFee

                    TOT_IW_HandlingFee = TOT_IW_HandlingFee + IW_HandlingFee
                    TOT_OW_HandlingFee = TOT_OW_HandlingFee + OW_HandlingFee

                    TOT_IW_TransportFee = TOT_IW_TransportFee + IW_TransportFee
                    TOT_OW_TransportFee = TOT_OW_TransportFee + OW_TransportFee

                    TOT_IW_HomeServiceFee = TOT_IW_HomeServiceFee + IW_HomeServiceFee
                    TOT_OW_HomeServiceFee = TOT_OW_HomeServiceFee + OW_HomeServiceFee

                    TOT_IW_LongdistansFee = TOT_IW_LongdistansFee + IW_LongdistansFee
                    TOT_OW_LongdistansFee = TOT_OW_LongdistansFee + OW_LongdistansFee

                    TOT_IW_TravelallowanceFee = TOT_IW_TravelallowanceFee + IW_TravelallowanceFee
                    TOT_OW_TravelallowanceFee = TOT_OW_TravelallowanceFee + OW_TravelallowanceFee

                    TOT_IW_DaFee = TOT_IW_DaFee + IW_DaFee
                    TOT_OW_DaFee = TOT_OW_DaFee + OW_DaFee

                    TOT_IW_DemoCharge = TOT_IW_DemoCharge + IW_DemoCharge
                    TOT_OW_DemoCharge = TOT_OW_DemoCharge + OW_DemoCharge

                    TOT_IW_InstallationFee = TOT_IW_InstallationFee + IW_InstallationFee
                    TOT_OW_InstallationFee = TOT_OW_InstallationFee + OW_InstallationFee

                    TOT_IW_EcallCharge = TOT_IW_EcallCharge + IW_EcallCharge
                    TOT_OW_EcallCharge = TOT_OW_EcallCharge + OW_EcallCharge

                    TOT_IW_CombatFee = TOT_IW_CombatFee + IW_CombatFee
                    TOT_OW_CombatFee = TOT_OW_CombatFee + OW_CombatFee

                Next


            End If


            'Final For a Day 
            '# Warranty (Number) = (In Warranty (Number) + Out Warranty (Number)
            'rowWork1 &= "," & strDate
            'rowWork2 &= "," & TOT_Repair
            'rowWork3 &= "," & TOT_DEMO
            'rowWork4 &= "," & TOT_Installation
            'rowWork5 &= ","

            TOT_WarrantyNumber = TOT_InWarrantyNumber + TOT_OutWarrantyNumber
            'rowWork6 &= "," & TOT_WarrantyNumber
            'rowWork7 &= "," & TOT_InWarrantyNumber
            'rowWork8 &= "," & TOT_OutWarrantyNumber


            '#Total Amount IW (SONY Needs To Pay/IW + SONY Needs To Pay/OW ) /1.18
            TOT_IW_TotalAmountIW = (TOT_SONYNeedsToPayIW + TOT_SONYNeedsToPayOW) / 1.18
            TOT_IW_TotalAmountOfAccountPayableIW = TOT_IW_TotalPartsFee + TOT_IW_LabourFee + TOT_IW_InspectionFee + TOT_IW_HandlingFee + TOT_IW_TransportFee + TOT_IW_HomeServiceFee + TOT_IW_LongdistansFee + TOT_IW_TravelallowanceFee + TOT_IW_DaFee + TOT_IW_DemoCharge + TOT_IW_InstallationFee + TOT_IW_EcallCharge + TOT_IW_CombatFee
            'rowWork9 &= "," & Math.Floor(TOT_IW_TotalAmountIW)
            'rowWork10 &= "," & Math.Floor(TOT_IW_TotalAmountOfAccountPayableIW)
            'rowWork11 &= "," & Math.Floor(TOT_IW_AccountPayableByASC)
            'rowWork12 &= "," & Math.Floor(TOT_IW_AccountPayableByCustomer)
            'rowWork13 &= "," & Math.Floor(TOT_SONYNeedsToPayIW)
            'rowWork14 &= "," & Math.Floor(TOT_SONYNeedsToPayOW)
            'rowWork15 &= "," & Math.Floor(TOT_IW_TotalPartsFee)
            'rowWork16 &= "," & Math.Floor(TOT_IW_LabourFee)
            'rowWork17 &= "," & Math.Floor(TOT_IW_InspectionFee)
            'rowWork18 &= "," & Math.Floor(TOT_IW_HandlingFee)
            'rowWork19 &= "," & Math.Floor(TOT_IW_TransportFee)
            'rowWork20 &= "," & Math.Floor(TOT_IW_HomeServiceFee)
            'rowWork21 &= "," & Math.Floor(TOT_IW_LongdistansFee)
            'rowWork22 &= "," & Math.Floor(TOT_IW_TravelallowanceFee)
            'rowWork23 &= "," & Math.Floor(TOT_IW_DaFee)
            'rowWork24 &= "," & Math.Floor(TOT_IW_DemoCharge)
            'rowWork25 &= "," & Math.Floor(TOT_IW_InstallationFee)
            'rowWork26 &= "," & Math.Floor(TOT_IW_EcallCharge)
            'rowWork27 &= "," & Math.Floor(TOT_IW_CombatFee)

            '#Total Amount OW (Total Amount of Account Payable OW - Account Payable By ASC - SONY Needs To Pay ) / 1.18
            TOT_OW_TotalAmountOW = (TOT_OW_TotalAmountOfAccountPayableOW - TOT_OW_AccountPayableByASC - TOT_SONYNeedsToPayOW) / 1.18
            'rowWork28 &= "," & Math.Floor(TOT_OW_TotalAmountOW) '& ":" & TOT_OW_TotalAmountOfAccountPayableOW & ":" & TOT_IW_AccountPayableByASC & ":" & TOT_SONYNeedsToPayOW
            'rowWork29 &= "," & Math.Floor(TOT_OW_TotalAmountOfAccountPayableOW)
            'rowWork30 &= "," & Math.Floor(TOT_OW_AccountPayableByASC)
            'rowWork31 &= "," & Math.Floor(TOT_OW_AccountPayableByCustomer)
            'rowWork32 &= "," & Math.Floor(TOT_SONYNeedsToPayOW)
            'rowWork33 &= "," & Math.Floor(TOT_OW_TotalPartsFee)
            'rowWork34 &= "," & Math.Floor(TOT_OW_LabourFee)
            'rowWork35 &= "," & Math.Floor(TOT_OW_InspectionFee)
            '#Handling Fees = =D32+D36 (Account Payable By ASC + Labour Fee )
            'TOT_OW_HandlingFee = TOT_OW_AccountPayableByASC + TOT_OW_LabourFee

            'rowWork36 &= "," & Math.Floor(TOT_OW_HandlingFee)
            'rowWork37 &= "," & Math.Floor(TOT_OW_TransportFee)
            'rowWork38 &= "," & Math.Floor(TOT_OW_HomeServiceFee)
            'rowWork39 &= "," & Math.Floor(TOT_OW_LongdistansFee)
            'rowWork40 &= "," & Math.Floor(TOT_OW_TravelallowanceFee)
            'rowWork41 &= "," & Math.Floor(TOT_OW_DaFee)
            'rowWork42 &= "," & Math.Floor(TOT_OW_DemoCharge)
            'rowWork43 &= "," & Math.Floor(TOT_OW_InstallationFee)
            'rowWork44 &= "," & Math.Floor(TOT_OW_EcallCharge)
            'rowWork45 &= "," & Math.Floor(TOT_OW_CombatFee)


            '#RevenuewithoutTax = Total Amount IW + Total Amount OW
            TOT_RevenuewithoutTax = TOT_IW_TotalAmountIW + TOT_OW_TotalAmountOW
            'rowWork46 &= "," & Math.Floor(TOT_RevenuewithoutTax)
            'rowWork47 &= ","
            '#IW parts consumed = Total Parts Fee * 0.88
            TOT_IWpartsconsumed = TOT_IW_TotalPartsFee * 0.88
            'rowWork48 &= "," & Math.Floor(TOT_IWpartsconsumed)

            '#Total parts consumed =   Total Parts Fee (IW)  + Total Parts Fee (OW)
            TOT_Totalpartsconsumed = TOT_IW_TotalPartsFee + TOT_OW_TotalPartsFee
            'rowWork49 &= "," & Math.Floor(TOT_Totalpartsconsumed)
            '#Prime Cost Total =  Totalpartsconsumed -  IWpartsconsumed
            TOT_PrimeCostTotal = TOT_Totalpartsconsumed - TOT_IWpartsconsumed
            'rowWork50 &= "," & Math.Floor(TOT_PrimeCostTotal)
            '#Gross Profit = Revenue without Tax - Prime Cost Total
            TOT_GrossProfit = TOT_RevenuewithoutTax - TOT_PrimeCostTotal
            'rowWork51 &= "," & Math.Floor(TOT_GrossProfit)
            Try
                TOT_Percentage = (TOT_GrossProfit / TOT_RevenuewithoutTax) * 100
            Catch ex As Exception
                TOT_Percentage = 0
            End Try


            'rowWork52 &= "," & Math.Floor(TOT_Percentage) & "%"



            '**************************************
            'Add Single Day Value
            Dim Row1 As DataRow
            Row1 = tblSIDSales.NewRow()

            Row1.Item("SalesDate") = strDate
            Row1.Item("SalesAmount") = "" & Math.Floor(TOT_GrossProfit)
            tblSIDSales.Rows.Add(Row1)
            '***********************************************



            NET_TOT_Repair = NET_TOT_Repair + TOT_Repair
            NET_TOT_DEMO = NET_TOT_DEMO + TOT_DEMO
            NET_TOT_Installation = NET_TOT_Installation + TOT_Installation

            NET_TOT_WarrantyNumber = NET_TOT_WarrantyNumber + TOT_WarrantyNumber
            NET_TOT_InWarrantyNumber = NET_TOT_InWarrantyNumber + TOT_InWarrantyNumber
            NET_TOT_OutWarrantyNumber = NET_TOT_OutWarrantyNumber + TOT_OutWarrantyNumber


            '#Total Amount IW (SONY Needs To Pay/IW + SONY Needs To Pay/OW ) /1.18
            NET_TOT_IW_TotalAmountIW = NET_TOT_IW_TotalAmountIW + TOT_IW_TotalAmountIW
            NET_TOT_IW_TotalAmountOfAccountPayableIW = NET_TOT_IW_TotalAmountOfAccountPayableIW + TOT_IW_TotalAmountOfAccountPayableIW
            NET_TOT_IW_AccountPayableByASC = NET_TOT_IW_AccountPayableByASC + TOT_IW_AccountPayableByASC
            NET_TOT_IW_AccountPayableByCustomer = NET_TOT_IW_AccountPayableByCustomer + TOT_IW_AccountPayableByCustomer
            NET_TOT_SONYNeedsToPayIW = NET_TOT_SONYNeedsToPayIW + TOT_SONYNeedsToPayIW
            NET_TOT_SONYNeedsToPayOW = NET_TOT_SONYNeedsToPayOW + TOT_SONYNeedsToPayOW
            NET_TOT_IW_TotalPartsFee = NET_TOT_IW_TotalPartsFee + TOT_IW_TotalPartsFee
            NET_TOT_IW_LabourFee = NET_TOT_IW_LabourFee + TOT_IW_LabourFee
            NET_TOT_IW_InspectionFee = NET_TOT_IW_InspectionFee + TOT_IW_InspectionFee
            NET_TOT_IW_HandlingFee = NET_TOT_IW_HandlingFee + TOT_IW_HandlingFee
            NET_TOT_IW_TransportFee = NET_TOT_IW_TransportFee + TOT_IW_TransportFee
            NET_TOT_IW_HomeServiceFee = NET_TOT_IW_HomeServiceFee + TOT_IW_HomeServiceFee
            NET_TOT_IW_LongdistansFee = NET_TOT_IW_LongdistansFee + TOT_IW_LongdistansFee
            NET_TOT_IW_TravelallowanceFee = NET_TOT_IW_TravelallowanceFee + TOT_IW_TravelallowanceFee
            NET_TOT_IW_DaFee = NET_TOT_IW_DaFee + TOT_IW_DaFee
            NET_TOT_IW_DemoCharge = NET_TOT_IW_DemoCharge + TOT_IW_DemoCharge
            NET_TOT_IW_InstallationFee = NET_TOT_IW_InstallationFee + TOT_IW_InstallationFee
            NET_TOT_IW_EcallCharge = NET_TOT_IW_EcallCharge + TOT_IW_EcallCharge
            NET_TOT_IW_CombatFee = NET_TOT_IW_CombatFee + TOT_IW_CombatFee

            '#Total Amount OW (Total Amount of Account Payable OW - Account Payable By ASC - SONY Needs To Pay ) / 1.18
            NET_TOT_OW_TotalAmountOW = NET_TOT_OW_TotalAmountOW + TOT_OW_TotalAmountOW
            NET_TOT_OW_TotalAmountOfAccountPayableOW = NET_TOT_OW_TotalAmountOfAccountPayableOW + TOT_OW_TotalAmountOfAccountPayableOW
            NET_TOT_OW_AccountPayableByASC = NET_TOT_OW_AccountPayableByASC + TOT_OW_AccountPayableByASC
            NET_TOT_OW_AccountPayableByCustomer = NET_TOT_OW_AccountPayableByCustomer + TOT_OW_AccountPayableByCustomer
            NET_TOT_SONYNeedsToPayOW = NET_TOT_SONYNeedsToPayOW + TOT_SONYNeedsToPayOW
            NET_TOT_OW_TotalPartsFee = NET_TOT_OW_TotalPartsFee + TOT_OW_TotalPartsFee
            NET_TOT_OW_LabourFee = NET_TOT_OW_LabourFee + TOT_OW_LabourFee
            NET_TOT_OW_InspectionFee = NET_TOT_OW_InspectionFee + TOT_OW_InspectionFee

            '#Handling Fees = =D32+D36 (Account Payable By ASC + Labour Fee )
            NET_TOT_OW_HandlingFee = NET_TOT_OW_HandlingFee + TOT_OW_HandlingFee
            NET_TOT_OW_TransportFee = NET_TOT_OW_TransportFee + TOT_OW_TransportFee
            NET_TOT_OW_HomeServiceFee = NET_TOT_OW_HomeServiceFee + TOT_OW_HomeServiceFee
            NET_TOT_OW_LongdistansFee = NET_TOT_OW_LongdistansFee + TOT_OW_LongdistansFee
            NET_TOT_OW_TravelallowanceFee = NET_TOT_OW_TravelallowanceFee + TOT_OW_TravelallowanceFee
            NET_TOT_OW_DaFee = NET_TOT_OW_DaFee + TOT_OW_DaFee
            NET_TOT_OW_DemoCharge = NET_TOT_OW_DemoCharge + TOT_OW_DemoCharge
            NET_TOT_OW_InstallationFee = NET_TOT_OW_InstallationFee + TOT_OW_InstallationFee
            NET_TOT_OW_EcallCharge = NET_TOT_OW_EcallCharge + TOT_OW_EcallCharge
            NET_TOT_OW_CombatFee = NET_TOT_OW_CombatFee + TOT_OW_CombatFee


            NET_TOT_RevenuewithoutTax = NET_TOT_RevenuewithoutTax + TOT_RevenuewithoutTax
            NET_TOT_IWpartsconsumed = NET_TOT_IWpartsconsumed + TOT_IWpartsconsumed
            NET_TOT_Totalpartsconsumed = NET_TOT_Totalpartsconsumed + TOT_Totalpartsconsumed
            NET_TOT_PrimeCostTotal = NET_TOT_PrimeCostTotal + TOT_PrimeCostTotal
            NET_TOT_GrossProfit = NET_TOT_GrossProfit + TOT_GrossProfit

            '********************************
            'NetTotal
            '*******************************
        Next


        'Final For a Day 
        '# Warranty (Number) = (In Warranty (Number) + Out Warranty (Number)
        'rowWork1 &= "," & "Total"
        'rowWork2 &= "," & NET_TOT_Repair
        'rowWork3 &= "," & NET_TOT_DEMO
        'rowWork4 &= "," & NET_TOT_Installation
        'rowWork5 &= ","


        'rowWork6 &= "," & NET_TOT_WarrantyNumber
        'rowWork7 &= "," & NET_TOT_InWarrantyNumber
        'rowWork8 &= "," & NET_TOT_OutWarrantyNumber


        '#Total Amount IW (SONY Needs To Pay/IW + SONY Needs To Pay/OW ) /1.18

        'rowWork9 &= "," & Math.Floor(NET_TOT_IW_TotalAmountIW)
        'rowWork10 &= "," & Math.Floor(NET_TOT_IW_TotalAmountOfAccountPayableIW)
        'rowWork11 &= "," & Math.Floor(NET_TOT_IW_AccountPayableByASC)
        'rowWork12 &= "," & Math.Floor(NET_TOT_IW_AccountPayableByCustomer)
        'rowWork13 &= "," & Math.Floor(NET_TOT_SONYNeedsToPayIW)
        'rowWork14 &= "," & Math.Floor(NET_TOT_SONYNeedsToPayOW)
        'rowWork15 &= "," & Math.Floor(NET_TOT_IW_TotalPartsFee)
        'rowWork16 &= "," & Math.Floor(NET_TOT_IW_LabourFee)
        'rowWork17 &= "," & Math.Floor(NET_TOT_IW_InspectionFee)
        'rowWork18 &= "," & Math.Floor(NET_TOT_IW_HandlingFee)
        'rowWork19 &= "," & Math.Floor(NET_TOT_IW_TransportFee)
        'rowWork20 &= "," & Math.Floor(NET_TOT_IW_HomeServiceFee)
        'rowWork21 &= "," & Math.Floor(NET_TOT_IW_LongdistansFee)
        'rowWork22 &= "," & Math.Floor(NET_TOT_IW_TravelallowanceFee)
        'rowWork23 &= "," & Math.Floor(NET_TOT_IW_DaFee)
        'rowWork24 &= "," & Math.Floor(NET_TOT_IW_DemoCharge)
        'rowWork25 &= "," & Math.Floor(NET_TOT_IW_InstallationFee)
        'rowWork26 &= "," & Math.Floor(NET_TOT_IW_EcallCharge)
        'rowWork27 &= "," & Math.Floor(NET_TOT_IW_CombatFee)

        '#Total Amount OW (Total Amount of Account Payable OW - Account Payable By ASC - SONY Needs To Pay ) / 1.18

        'rowWork28 &= "," & Math.Floor(NET_TOT_OW_TotalAmountOW)
        'rowWork29 &= "," & Math.Floor(NET_TOT_OW_TotalAmountOfAccountPayableOW)
        'rowWork30 &= "," & Math.Floor(NET_TOT_OW_AccountPayableByASC)
        'rowWork31 &= "," & Math.Floor(NET_TOT_OW_AccountPayableByCustomer)
        'rowWork32 &= "," & Math.Floor(NET_TOT_SONYNeedsToPayOW)
        'rowWork33 &= "," & Math.Floor(NET_TOT_OW_TotalPartsFee)
        'rowWork34 &= "," & Math.Floor(NET_TOT_OW_LabourFee)
        'rowWork35 &= "," & Math.Floor(NET_TOT_OW_InspectionFee)
        '#Handling Fees = =D32+D36 (Account Payable By ASC + Labour Fee )

        'rowWork36 &= "," & Math.Floor(NET_TOT_OW_HandlingFee)
        'rowWork37 &= "," & Math.Floor(NET_TOT_OW_TransportFee)
        'rowWork38 &= "," & Math.Floor(NET_TOT_OW_HomeServiceFee)
        'rowWork39 &= "," & Math.Floor(NET_TOT_OW_LongdistansFee)
        'rowWork40 &= "," & Math.Floor(NET_TOT_OW_TravelallowanceFee)
        'rowWork41 &= "," & Math.Floor(NET_TOT_OW_DaFee)
        'rowWork42 &= "," & Math.Floor(NET_TOT_OW_DemoCharge)
        'rowWork43 &= "," & Math.Floor(NET_TOT_OW_InstallationFee)
        'rowWork44 &= "," & Math.Floor(NET_TOT_OW_EcallCharge)
        'rowWork45 &= "," & Math.Floor(NET_TOT_OW_CombatFee)


        '#RevenuewithoutTax = Total Amount IW + Total Amount OW

        'rowWork46 &= "," & Math.Floor(NET_TOT_RevenuewithoutTax)
        'rowWork47 &= ","
        '#IW parts consumed = Total Parts Fee * 0.88
        'rowWork48 &= "," & Math.Floor(NET_TOT_IWpartsconsumed)
        '#Total parts consumed =   Total Parts Fee (IW)  + Total Parts Fee (OW)
        'rowWork49 &= "," & Math.Floor(NET_TOT_Totalpartsconsumed)
        '#Prime Cost Total =  Totalpartsconsumed -  IWpartsconsumed
        'rowWork50 &= "," & Math.Floor(NET_TOT_PrimeCostTotal)
        '#Gross Profit = Revenue without Tax - Prime Cost Total
        'rowWork51 &= "," & Math.Floor(NET_TOT_GrossProfit)

        Try
            NET_TOT_Percentage = (NET_TOT_GrossProfit / NET_TOT_RevenuewithoutTax) * 100
        Catch ex As Exception
            NET_TOT_Percentage = 0
        End Try


        'rowWork52 &= "," & Math.Floor(NET_TOT_Percentage) & "%"
        '********************************
        'End
        '***********************************
        'Last Left Column Begin
        'rowWork1 &= ",SID1"
        'rowWork2 &= ",Repair"
        'rowWork3 &= ",DEMO"
        'rowWork4 &= ",Installation"
        'rowWork5 &= ","
        'rowWork6 &= ",Warranty (Number)"
        'rowWork7 &= ",In Warranty (Number)"
        'rowWork8 &= ",Out Warranty (Number)"
        'rowWork9 &= ",Total Amount IW"
        'rowWork10 &= ",Total Amount of Account Payable IW"
        'rowWork11 &= ",Account Payable By ASC"
        'rowWork12 &= ",Account Payable By Customer"
        'rowWork13 &= ",SONY Needs To Pay/IW"
        'rowWork14 &= ",SONY Needs To Pay/OW"
        'rowWork15 &= ",Total Parts Fee"
        'rowWork16 &= ",Labour Fee"
        'rowWork17 &= ",Inspection Fee"
        'rowWork18 &= ",Handling Fee"
        'rowWork19 &= ",Transport Fee"
        'rowWork20 &= ",HomeService Fee"
        'rowWork21 &= ",Longdistans Fee"
        'rowWork22 &= ",Travelallowance Fee"
        'rowWork23 &= ",Da Fee"
        'rowWork24 &= ",Demo Charge"
        'rowWork25 &= ",Installation Fee"
        'rowWork26 &= ",Ecall Charge"
        'rowWork27 &= ",Combat Fee"
        'rowWork28 &= ",Total Amount OW"
        'rowWork29 &= ",Total Amount of Account Payable OW"
        'rowWork30 &= ",Account Payable By ASC"
        'rowWork31 &= ",Account Payable By Customer"
        'rowWork32 &= ",SONY Needs To Pay"
        'rowWork33 &= ",Total Parts Fee"
        'rowWork34 &= ",Labour Fee"
        'rowWork35 &= ",Inspection Fee"
        'rowWork36 &= ",Handling Fee"
        'rowWork37 &= ",Transport Fee"
        'rowWork38 &= ",HomeService Fee"
        'rowWork39 &= ",Longdistans Fee"
        'rowWork40 &= ",Travelallowance Fee"
        'rowWork41 &= ",Da Fee"
        'rowWork42 &= ",Demo Charge"
        'rowWork43 &= ",Installation Fee"
        'rowWork44 &= ",Ecall Charge"
        'rowWork45 &= ",Combat Fee"
        'rowWork46 &= ",Revenue without Tax"
        'rowWork47 &= ","
        'rowWork48 &= ",IW parts consumed"
        'rowWork49 &= ",Total parts consumed"
        'rowWork50 &= ",Prime Cost Total"
        'rowWork51 &= ",Gross Profit"
        'rowWork52 &= ","
        'Last Left Column End


        'csvContents.Add(rowWork1)
        'csvContents.Add(rowWork2)
        'csvContents.Add(rowWork3)
        'csvContents.Add(rowWork4)
        'csvContents.Add(rowWork5)
        'csvContents.Add(rowWork6)
        'csvContents.Add(rowWork7)
        'csvContents.Add(rowWork8)
        'csvContents.Add(rowWork9)
        'csvContents.Add(rowWork10)
        'csvContents.Add(rowWork11)
        'csvContents.Add(rowWork12)
        'csvContents.Add(rowWork13)
        'csvContents.Add(rowWork14)
        'csvContents.Add(rowWork15)
        'csvContents.Add(rowWork16)
        'csvContents.Add(rowWork17)
        'csvContents.Add(rowWork18)
        'csvContents.Add(rowWork19)
        'csvContents.Add(rowWork20)
        'csvContents.Add(rowWork21)
        'csvContents.Add(rowWork22)
        'csvContents.Add(rowWork23)
        'csvContents.Add(rowWork24)
        'csvContents.Add(rowWork25)
        'csvContents.Add(rowWork26)
        'csvContents.Add(rowWork27)
        'csvContents.Add(rowWork28)
        'csvContents.Add(rowWork29)
        'csvContents.Add(rowWork30)
        'csvContents.Add(rowWork31)
        'csvContents.Add(rowWork32)
        'csvContents.Add(rowWork33)
        'csvContents.Add(rowWork34)
        'csvContents.Add(rowWork35)
        'csvContents.Add(rowWork36)
        'csvContents.Add(rowWork37)
        'csvContents.Add(rowWork38)
        'csvContents.Add(rowWork39)
        'csvContents.Add(rowWork40)
        'csvContents.Add(rowWork41)
        'csvContents.Add(rowWork42)
        'csvContents.Add(rowWork43)
        'csvContents.Add(rowWork44)
        'csvContents.Add(rowWork45)
        'csvContents.Add(rowWork46)
        'csvContents.Add(rowWork47)
        'csvContents.Add(rowWork48)
        'csvContents.Add(rowWork49)
        'csvContents.Add(rowWork50)
        'csvContents.Add(rowWork51)
        'csvContents.Add(rowWork52)

        'Dim clsSet As New Class_analysis
        'Dim outputPath As String
        'Dim csvFileName As String
        'Dim dateFrom As String = strYear & "/" & strMonth & "/01"
        'Dim dateTo As String = strYear & "/" & strMonth & "/" & strMaxDay
        'Dim exportFile As String = ""
        'Dim setMon As String = ""
        'Dim exportShipName As String = "SID1"
        'Dim dtNow As DateTime = clsSetCommon.dtIndia


        'exportFile = "0.PL_Tracking_Sheet"

        'dateFrom = Replace(dateFrom, "/", "")
        'dateTo = Replace(dateTo, "/", "")

        ''exportFile名の頭、数値を除く
        ''0.PL_Tracking_Sheet
        'exportFile = Right(exportFile, exportFile.Length - 2)

        'If setMon = "00" Then
        '    If dateTo <> "" And dateFrom <> "" Then
        '        csvFileName = exportFile & "_ " & exportShipName & "_" & dateFrom & "_" & dateTo & ".csv"
        '    Else
        '        If dateTo <> "" Then
        '            csvFileName = exportFile & "_ " & exportShipName & "_" & dateTo & ".csv"
        '        End If
        '        If dateFrom <> "" Then
        '            csvFileName = exportFile & "_ " & exportShipName & "_" & dateFrom & ".csv"
        '        End If
        '    End If
        'Else
        '    '月指定のとき
        '    csvFileName = exportFile & "_ " & exportShipName & "_" & dtNow.ToString("yyyy") & "_" & setMon & ".csv"
        'End If

        'outputPath = clsSet.CsvFilePass & csvFileName

        'Using writer As New StreamWriter(outputPath, False, Encoding.Default)
        '    writer.WriteLine(String.Join(Environment.NewLine, csvContents))
        'End Using

        ''ファイルの内容をバイト配列にすべて読み込む 
        'Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)

        ''サーバに保存されたCSVファイルを削除
        ''※Response.End以降、ファイル削除処理ができないため、ファイルのダウンロードではなく、一旦ファイルの内容を
        ''上記、Bufferに保存し、ダウンロード処理を行う。

        'If outputPath <> "" Then
        '    If System.IO.File.Exists(outputPath) = True Then
        '        System.IO.File.Delete(outputPath)
        '    End If
        'End If

        '' ダウンロード
        'Response.ContentType = "application/text/csv"
        'Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)
        'Response.Flush()
        ''Response.Write("<b>File Contents: </b>")
        'Response.BinaryWrite(Buffer)
        ''Response.WriteFile(outputPath)
        'Response.End()
        Return tblSIDSales

    End Function


    Public Sub ExportExcel(ByVal dtScDsrView As DataTable, ByVal dtScDsrRevWoTaxView As DataTable, targetType As String, branch As String, fromdate As String, todate As String)

        Dim sb As StringBuilder = New StringBuilder()
        Dim arrayListIWOW As ArrayList = New ArrayList()
        Dim arrayListTotal As ArrayList = New ArrayList()

        For value As Integer = 0 To 21
            arrayListIWOW.Add(0)
        Next

        For values As Integer = 1 To 22
            If (values Mod 2 = 0) Then
                arrayListTotal.Add("0")
            Else
                arrayListTotal.Add("total")
            End If
        Next

        'Revenue Without Tax
        Dim arrayListRWT As ArrayList = New ArrayList()

        Dim TotalRWT As Decimal
        TotalRWT = 0.00


        For value As Integer = 0 To 10
            arrayListRWT.Add(0)
        Next

        For Each item As DataRow In dtScDsrRevWoTaxView.Rows
            If item.Item("Branch_name").ToString = "SSC1" Then
                arrayListRWT(0) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC2" Then
                arrayListRWT(1) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC3" Then
                arrayListRWT(2) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC4" Then
                arrayListRWT(3) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC5" Then
                arrayListRWT(4) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC6" Then
                arrayListRWT(5) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC7" Then
                arrayListRWT(6) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC8" Then
                arrayListRWT(7) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC9" Then
                arrayListRWT(8) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC10" Then
                arrayListRWT(9) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            ElseIf item.Item("Branch_name").ToString = "SSC11" Then
                arrayListRWT(10) = item.Item("RevWoTax").ToString
                TotalRWT += Convert.ToDecimal(item.Item("RevWoTax").ToString)
            End If

        Next
        'Revenue Without Tax
        'Total IW, OW and sum of IW & OW
        Dim sumIW As Integer
        Dim sumOW As Integer

        If dtScDsrView.Compute("SUM(IW_goods_total)", String.Empty).ToString().Length > 0 Then
            sumIW = Convert.ToInt32(dtScDsrView.Compute("SUM(IW_goods_total)", String.Empty))
        Else
            sumIW = 0
        End If

        If dtScDsrView.Compute("SUM(OW_goods_total)", String.Empty).ToString().Length > 0 Then
            sumOW = Convert.ToInt32(dtScDsrView.Compute("SUM(OW_goods_total)", String.Empty))
        Else
            sumOW = 0
        End If
        Dim sumIOW As Integer = (sumIW + sumOW)

        sb.Append(String.Format("{0},{1},{2},{3},{4},{5}", "", "", "", "", "", "") + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4}", drpManagementFunc.SelectedItem.Text, DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("HH:mm"), "User:", Convert.ToString(Session("user_Name"))) + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5}", "", "", "", "", "", "") + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5}", "total IW", sumIW, "total OW", sumOW, "total", sumIOW) + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5}", "", "", "", "", "", "") + Environment.NewLine)

        sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "SSC1", "", "SSC2", "", "SSC3", "", "SSC4", "", "SSC5", "", "SSC6", "", "SSC7", "", "SSC8", "", "SSC9", "", "SSC10", "", "SSC11", "") + Environment.NewLine)
        'sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}", "SSC1", "", "SSC2", "", "SSC3", "", "SSC4", "", "SSC5", "", "SSC6", "", "SSC7", "", "SSC8", "", "SSC9", "") + Environment.NewLine)
        'sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW") + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW", "IW", "OW") + Environment.NewLine)



        Dim rowIndex As String
        Dim rowIWOWIndex As Integer
        Dim rowTotalIndex As Integer
        Dim incValue As Integer
        Dim incTotal As Integer
        incValue = 1
        incTotal = 1
        rowIWOWIndex = 0
        rowTotalIndex = 0

        'for IW_goods_total & OW_goods_total

        For Each item As DataRow In dtScDsrView.Rows
            If targetType = "ALL" Then

                'If (item.Item("Branch_name").ToString = "SSC" + incValue.ToString) Then
                rowIndex = item.Table.Rows.IndexOf(item).ToString
                If item.Item("Branch_name").ToString = "SSC1" Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(0) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(0) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(1) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(1) = 0
                    End If

                ElseIf (item.Item("Branch_name").ToString = "SSC2") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(2) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(2) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(3) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(3) = 0
                    End If

                ElseIf (item.Item("Branch_name").ToString = "SSC3") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(4) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(4) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then

                        arrayListIWOW(5) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(5) = 0
                    End If

                ElseIf (item.Item("Branch_name").ToString = "SSC4") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(6) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(6) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(7) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(7) = 0
                    End If

                ElseIf (item.Item("Branch_name").ToString = "SSC5") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(8) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(8) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(9) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(9) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC6") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(10) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(10) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(11) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(11) = 0
                    End If

                ElseIf (item.Item("Branch_name").ToString = "SSC7") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(12) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(12) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(13) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(13) = 0
                    End If

                ElseIf (item.Item("Branch_name").ToString = "SSC8") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(14) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(14) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(15) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(15) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC9") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(16) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(16) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(17) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(17) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC10") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(18) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(18) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(19) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(19) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC11") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(20) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                    Else
                        arrayListIWOW(20) = 0
                    End If
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString().Length > 0 Then
                        arrayListIWOW(21) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString()
                    Else
                        arrayListIWOW(21) = 0
                    End If
                End If
                'arrayListIWOW(rowIWOWIndex) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                'rowIWOWIndex = rowIWOWIndex + 1
                'arrayListIWOW(rowIWOWIndex) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString


            Else
                Dim IW_goods_total As String
                Dim OW_goods_total As String
                rowIndex = item.Table.Rows.IndexOf(item).ToString
                'arrayListIWOW(rowIWOWIndex) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString


                If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString.Length > 0 Then
                    IW_goods_total = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("IW_goods_total").ToString
                Else
                    IW_goods_total = 0
                End If


                If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString.Length > 0 Then
                    OW_goods_total = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString
                Else
                    OW_goods_total = 0
                End If



                rowIWOWIndex = rowIWOWIndex + 1
                ' arrayListIWOW(rowIWOWIndex) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("OW_goods_total").ToString

                If branch = "SSC1" Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", IW_goods_total, OW_goods_total, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0") + Environment.NewLine)
                ElseIf (branch = "SSC2") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", IW_goods_total, OW_goods_total, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0") + Environment.NewLine)
                    'note: {0},{1}=ssc1,{2}{3}=ssc2
                ElseIf (branch = "SSC3") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", IW_goods_total, OW_goods_total, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0") + Environment.NewLine)
                    'do  it for up to ssc8. but {} is added.ok
                ElseIf (branch = "SSC4") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", "0", "0", IW_goods_total, OW_goods_total, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0") + Environment.NewLine)
                ElseIf (branch = "SSC5") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", "0", "0", "0", "0", IW_goods_total, OW_goods_total, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0") + Environment.NewLine)
                ElseIf (branch = "SSC6") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", IW_goods_total, OW_goods_total, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0") + Environment.NewLine)
                ElseIf (branch = "SSC7") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", IW_goods_total, OW_goods_total, "0", "0", "0", "0", "0", "0", "0", "0") + Environment.NewLine)
                ElseIf (branch = "SSC8") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", IW_goods_total, OW_goods_total, "0", "0", "0", "0", "0", "0") + Environment.NewLine)
                ElseIf (branch = "SSC9") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", IW_goods_total, OW_goods_total, "0", "0", "0", "0") + Environment.NewLine)
                ElseIf (branch = "SSC10") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", IW_goods_total, OW_goods_total, "0", "0") + Environment.NewLine)
                ElseIf (branch = "SSC11") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", IW_goods_total, OW_goods_total) + Environment.NewLine)
                End If


            End If
            'incValue = incValue + 1
            'rowIWOWIndex = rowIWOWIndex + 1
        Next

        If targetType = "ALL" Then
            sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", arrayListIWOW(0), arrayListIWOW(1), arrayListIWOW(2), arrayListIWOW(3), arrayListIWOW(4), arrayListIWOW(5), arrayListIWOW(6), arrayListIWOW(7), arrayListIWOW(8), arrayListIWOW(9), arrayListIWOW(10), arrayListIWOW(11), arrayListIWOW(12), arrayListIWOW(13), arrayListIWOW(14), arrayListIWOW(15), arrayListIWOW(16), arrayListIWOW(17), arrayListIWOW(18), arrayListIWOW(19), arrayListIWOW(20), arrayListIWOW(21)) + Environment.NewLine)
        End If

        'for TotalGoods
        For Each item As DataRow In dtScDsrView.Rows

            If targetType = "ALL" Then

                'If (item.Item("Branch_name").ToString = "SSC" + incTotal.ToString) Then
                rowIndex = item.Table.Rows.IndexOf(item).ToString
                '    rowTotalIndex = rowTotalIndex + 1
                '    arrayListTotal(rowTotalIndex) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                'End If
                If item.Item("Branch_name").ToString = "SSC1" Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(1) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(1) = 0
                    End If


                ElseIf (item.Item("Branch_name").ToString = "SSC2") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(3) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(3) = 0
                    End If

                ElseIf (item.Item("Branch_name").ToString = "SSC3") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(5) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(5) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC4") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(7) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(7) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC5") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(9) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(9) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC6") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(11) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(11) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC7") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(13) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(13) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC8") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(15) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(15) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC9") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(17) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(17) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC10") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(19) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(19) = 0
                    End If
                ElseIf (item.Item("Branch_name").ToString = "SSC11") Then
                    If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                        arrayListTotal(21) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString
                    Else
                        arrayListTotal(21) = 0
                    End If
                End If

            Else

                rowIndex = item.Table.Rows.IndexOf(item).ToString
                'rowTotalIndex = rowTotalIndex + 1
                'arrayListTotal(rowTotalIndex) = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString

                Dim Total As String
                If dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString.Length > 0 Then
                    Total = dtScDsrView.Rows(Convert.ToInt32(rowIndex))("TotalGoods").ToString()
                Else
                    Total = "0"
                End If

                If branch = "SSC1" Then
                    sb.Append(String.Format("{0},{1}", "total", Total, "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0") + Environment.NewLine)
                    'note:{0}{1}=ssc
                ElseIf (branch = "SSC2") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", Total, "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC3") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", Total, "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC4") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", "0", "total", Total, "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC5") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", "0", "total", "0", "total", Total, "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC6") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", Total, "total", "0", "total", "0", "total", "0", "total", "0", "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC7") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", Total, "total", "0", "total", "0", "total", "0", "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC8") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", Total, "total", "0", "total", "0", "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC9") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", Total, "total", "0", "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC10") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", Total, "total", "0") + Environment.NewLine)
                ElseIf (branch = "SSC11") Then
                    sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", "0", "total", Total) + Environment.NewLine)
                End If

            End If
            'incTotal = incTotal + 1
            ' rowTotalIndex = rowTotalIndex + 1
        Next
        If targetType = "ALL" Then
            sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", arrayListTotal(0).ToString, arrayListTotal(1).ToString, arrayListTotal(2).ToString, arrayListTotal(3).ToString, arrayListTotal(4).ToString, arrayListTotal(5).ToString, arrayListTotal(6).ToString, arrayListTotal(7).ToString, arrayListTotal(8).ToString, arrayListTotal(9).ToString, arrayListTotal(10).ToString, arrayListTotal(11).ToString, arrayListTotal(12).ToString, arrayListTotal(13).ToString, arrayListTotal(14).ToString, arrayListTotal(15).ToString, arrayListTotal(16).ToString, arrayListTotal(17).ToString, arrayListTotal(18).ToString, arrayListTotal(19).ToString, arrayListTotal(20).ToString, arrayListTotal(21).ToString) + Environment.NewLine)
        End If
        'Revenue Without Tax

        sb.Append(String.Format("{0},{1},{2},{3},{4},{5}", "", "", "", "", "", "") + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5}", "", "", "", "", "", "") + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5}", "Revenue Without Tax", "", "", "", "", "") + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", "SSC1", "SSC2", "SSC3", "SSC4", "SSC5", "SSC6", "SSC7", "SSC8", "SSC9", "SSC10", "SSC11") + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", arrayListRWT(0), arrayListRWT(1), arrayListRWT(2), arrayListRWT(3), arrayListRWT(4), arrayListRWT(5), arrayListRWT(6), arrayListRWT(7), arrayListRWT(8), arrayListRWT(9), arrayListRWT(10)) + Environment.NewLine)
        sb.Append(String.Format("{0},{1},{2},{3},{4},{5}", "Total", TotalRWT, "", "", "", "") + Environment.NewLine)
        'Revenue Without Tax
        'export to csv
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(sb.ToString)
        If bytes IsNot Nothing Then
            Response.ClearHeaders()
            Response.Buffer = True
            Response.ContentType = "application/text/csv"
            Response.AddHeader("Content-Length", bytes.Length.ToString())
            'Response.AddHeader("Content-disposition", "attachment; filename=""sample.csv" & """")
            'Response.AddHeader("Content-disposition", "attachment; filename=""sample.csv")


            'SSC1_DRS_COUNT_20191207_20200122
            'SSC1-SS8_DRS_COUNT_20191207_20200122
            Dim csvfileName As String
            If targetType = "ALL" Then
                csvfileName = "SSC1_SS11_DRS_COUNT_" & fromdate & "_" & todate & ".csv"
            Else
                csvfileName = branch & "_" & "DRS_COUNT_" & fromdate & "_" & todate & ".csv"
            End If

            Response.AddHeader("Content-disposition", "attachment; filename=" & csvfileName)
            Response.BinaryWrite(bytes)
            Response.Flush()
            HttpContext.Current.ApplicationInstance.CompleteRequest()
            Exit Sub
        Else
            Call showMsg("Unable to export...", "")
            Exit Sub
        End If
    End Sub





    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBox1.Checked Then
            TextFromDate.Text = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            TextToDate.ReadOnly = True
            TextToDate.Text = ""
        Else
            TextFromDate.Text = ""
            TextToDate.ReadOnly = False

        End If
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As EventArgs) Handles ImageButton1.Click
        If DropdownList5.SelectedItem.Text = "Select" Then
            Call showMsg("Please Select SSC", "")
            Exit Sub
        ElseIf txtPaymentAmount.Text = "" Then
            Call showMsg("Please Enter The Payment Amount", "")
            Exit Sub
        ElseIf txtTargetDate.Text = "" Then
            Call showMsg("Please Select The Date", "")
            Exit Sub
        End If

        Dim _PaymentVlaueModel As PaymentValueModel = New PaymentValueModel()
        Dim _PaymentVlaueControl As PaymentValueControl = New PaymentValueControl()

        _PaymentVlaueModel.UPDPG = "Class_Store.vb"
        _PaymentVlaueModel.SHIP_TO_BRANCH_CODE = DropdownList5.SelectedItem.Value
        _PaymentVlaueModel.SHIP_TO_BRANCH = DropdownList5.SelectedItem.Text
        _PaymentVlaueModel.VALUE = txtPaymentAmount.Text
        _PaymentVlaueModel.TARGET_DATE = txtTargetDate.Text
        _PaymentVlaueModel.UserId = Session("user_id").ToString

        Dim isInserted As Boolean = _PaymentVlaueControl.PaymentValueInsert(_PaymentVlaueModel)

        If (isInserted = True) Then
            Call showMsg("Success" & "<br/> " & txtTargetDate.Text & ", " & DropdownList5.SelectedItem.Text & "<br/> " & ", " & "Payment Value " & txtPaymentAmount.Text, "")
            'Exit Sub

        End If
        txtPaymentAmount.Text = ""
        txtTargetDate.Text = ""
        Dim dtDisplayPaymentValue As DataTable = _PaymentVlaueControl.ShowPaymentValueGrid()
        'dtDisplayPaymentValue.DefaultView.Sort = "Id ASC"
        dtDisplayPaymentValue = dtDisplayPaymentValue.DefaultView.ToTable()
        If Not dtDisplayPaymentValue Is Nothing Then
            If dtDisplayPaymentValue.Rows.Count > 0 Then
                txtPageSize.Visible = True
                lblPagesize.Visible = True
                txtPageSize.Text = 10
                gvDisplayPaymentValue.PageSize = Convert.ToInt16(txtPageSize.Text)
                gvDisplayPaymentValue.Visible = True
                gvDisplayPaymentValue.AllowSorting = True
                gvDisplayPaymentValue.PageIndex = 0
                gvDisplayPaymentValue.DataSource = dtDisplayPaymentValue
                gvDisplayPaymentValue.DataBind()
                'btnExport.Visible = True
                lbltotal.Text = "Total No of Records : " & dtDisplayPaymentValue.Rows.Count
                'lblTitle.Text = drpTaskExport.SelectedItem.Text
            Else
                gvDisplayPaymentValue.AllowSorting = False
                gvDisplayPaymentValue.DataBind()
                gvDisplayPaymentValue.Visible = False
                'btnExport.Visible = False
                txtPageSize.Visible = False
                lblPagesize.Visible = False
            End If
        End If

    End Sub


    'PO_Collection
    Protected Sub ImageButton5_Click(sender As Object, e As EventArgs) Handles ImageButton5.Click
        If DropdownList6.SelectedItem.Text = "Select" Then
            Call showMsg("Please Select SSC", "")
            Exit Sub
        ElseIf TextBoxDeposit.Text = "" Then
            Call showMsg("Please Enter The Daily Deposit", "")
            Exit Sub
        ElseIf TextBoxCreditSales.Text = "" Then
            Call showMsg("Please Enter The Credit Sales", "")
            Exit Sub
        ElseIf TextBoxTargetDate.Text = "" Then
            Call showMsg("Please Select The Date", "")
            Exit Sub
        End If

        If System.Text.RegularExpressions.Regex.IsMatch(TextBoxDeposit.Text, "[^0-9]") Then
            Call showMsg("Please Enter The Number for Deposit", "")
            TextBoxDeposit.Text = ""
            Exit Sub
        End If


        If TextBoxDeposit.Text.Length > 6 Then
            Call showMsg("Enter upto 6 Numbers for Deposit", "")
            TextBoxDeposit.Text = ""
            Exit Sub
        End If

        If System.Text.RegularExpressions.Regex.IsMatch(TextBoxCreditSales.Text, "[^0-9]") Then
            Call showMsg("Please Enter The Number for Credit Sales", "")
            TextBoxCreditSales.Text = ""
            Exit Sub
        End If

        If TextBoxCreditSales.Text.Length > 6 Then
            Call showMsg("Enter upto 6 Numbers for Credit Sales", "")
            TextBoxCreditSales.Text = ""
            Exit Sub
        End If


        Dim _CollectionModel As CollectionModel = New CollectionModel()
        Dim _CollectionControl As CollectionControl = New CollectionControl()

        _CollectionModel.UPDPG = "Class_Store.vb"
        _CollectionModel.SHIP_TO_BRANCH_CODE = DropdownList6.SelectedItem.Value
        _CollectionModel.SHIP_TO_BRANCH = DropdownList6.SelectedItem.Text
        _CollectionModel.DEPOSIT = TextBoxDeposit.Text
        _CollectionModel.SALES = TextBoxCreditSales.Text
        _CollectionModel.TARGET_DATE = TextBoxTargetDate.Text
        _CollectionModel.UserId = Session("user_id").ToString

        Dim isInserted As Boolean = _CollectionControl.CollectionInsert(_CollectionModel)

        If (isInserted = True) Then
            Call showMsg("Success" & "<br/> " & TextBoxTargetDate.Text & ", " & DropdownList6.SelectedItem.Text & "<br/> " & ", " & "Daily Deposit " & TextBoxDeposit.Text & "," & "Credit Sales " & TextBoxCreditSales.Text, "")
            'Exit Sub

        End If
        TextBoxDeposit.Text = ""
        TextBoxCreditSales.Text = ""
        TextBoxTargetDate.Text = ""
    End Sub

    Protected Sub TextBoxDeposit_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDeposit.TextChanged



    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        viewdata()
    End Sub
    Public Sub viewdata()
        Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
        Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

        Dim DtFrom As String = ""
        Dim DtTo As String = ""
        DtFrom = Trim(TextFromDate.Text)
        DtTo = Trim(TextToDate.Text)



        ' Task = 1 'Assign From or To or both filter
        If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
            Dim date1, date2 As Date
            date1 = Date.Parse(TextFromDate.Text)
            date2 = Date.Parse(TextToDate.Text)
            If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                Call showMsg("Please verify from date and to date", "")
                Exit Sub
            End If
        End If





        If Len(DtFrom) > 5 And DtTo = "" Then
            DtTo = DtFrom



        End If
        If DtFrom = "" And Len(DtTo) > 5 Then
            DtFrom = DtTo




        End If




        Dim dtTbl1, dtTbl2 As DateTime
        If (Trim(DtFrom) <> "") Then
            If DateTime.TryParse(DtFrom, dtTbl1) Then
                dtTbl1 = DateTime.Parse(Trim(DtFrom)).ToShortDateString




            Else
                Call showMsg("There is an error in the date specification", "")
                Exit Sub





            End If
        End If
        If (Trim(DtTo) <> "") Then
            If DateTime.TryParse(DtTo, dtTbl2) Then
                dtTbl2 = DateTime.Parse(Trim(DtTo)).ToShortDateString


            Else
                Call showMsg("There is an error in the date specification", "")
                Exit Sub
            End If

        End If
        'End If

        Sc_Drs_Model.BranchName = DropdownList3.SelectedItem.Text
        Sc_Drs_Model.DateFrom = TextFromDate.Text
        Sc_Drs_Model.DateTo = TextToDate.Text

        Dim AllBranches As String
        For i As Integer = 1 To DropdownList3.Items.Count - 1
            AllBranches = AllBranches + "'" + DropdownList3.Items(i).Text + "',"
        Next
        AllBranches = Left(AllBranches, Len(AllBranches) - 1)
        Sc_Drs_Model.BranchName = AllBranches
        Dim _DataTable As DataTable = Sc_Drs_Control.StoreManagement_drsCounts(Sc_Drs_Model)
        Dim dtScDsrRevWoTaxView As DataTable = Sc_Drs_Control.StoreManagement_RevWoTax(Sc_Drs_Model)

        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "Customers"
        cell.ColumnSpan = 2
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 2
        cell.Text = "Employees"
        row.Controls.Add(cell)


        GridView1.HeaderRow.Parent.Controls.AddAt(0, row)

    End Sub
    Private Sub releaseObject(ByVal obj As Object)

        Try

            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)


            obj = Nothing

        Catch ex As Exception

            obj = Nothing

        Finally

            GC.Collect()

        End Try

    End Sub

    'Protected Sub ImageButton6_Click(sender As Object, e As ImageClickEventArgs) 'Comment for Weekly Revenue Report
    '    If DropdownList7.SelectedItem.Text = "Select" Then
    '        Call showMsg("Please Select SSC", "")
    '        Exit Sub
    '    ElseIf DropDownMonth2.SelectedItem.Text = "" Then
    '        Call showMsg("Please Select the month", "")
    '        Exit Sub

    '    ElseIf targetamtbox.Text = "" Then
    '        Call showMsg("Please Select The Date", "")
    '        Exit Sub
    '    End If
    '    Dim targetday As String
    '    If (DropDownMonth2.SelectedItem.Value = 4 Or 6 Or 9 Or 11) Then
    '        targetday = targetamtbox.Text / 30
    '    ElseIf (DropDownMonth2.SelectedItem.Value = 2) Then
    '        If (DropDownYear2.SelectedItem.Value Mod 4 = 0) Then
    '            targetday = targetamtbox.Text / 29
    '        Else
    '            targetday = targetamtbox.Text / 28
    '        End If
    '    Else
    '        targetday = targetamtbox.Text / 31
    '    End If
    '    Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
    '    Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()

    '    _Monthlytargetmodel.UPDPG = "Class_Store.vb"
    '    _Monthlytargetmodel.SHIP_TO_BRANCH_CODE = DropdownList7.SelectedItem.Value
    '    _Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
    '    _Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedItem.Value
    '    _Monthlytargetmodel.TARGET_MONTH_AMOUNT = targetamtbox.Text
    '    _Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Value
    '    _Monthlytargetmodel.TARGET_DAY_AMOUNT = targetday
    '    _Monthlytargetmodel.UserId = Session("user_id").ToString

    '    Dim isInserted As Boolean = _MonthlyTargetControll.MonthlytargetInsert(_Monthlytargetmodel)
    '    If (isInserted = True) Then
    '        Call showMsg("Successfully saved in " & DropdownList7.SelectedItem.Text, "")
    '    Else
    '        Call showMsg("Already Saved in " & DropdownList7.SelectedItem.Text, "")
    '    End If

    '    DropdownList7.Text = "Select"
    '    DropDownMonth2.Text = "0"

    '    targetamtbox.Text = ""



    '    Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid()

    '    dtDisplaymonthlytarget = dtDisplaymonthlytarget.DefaultView.ToTable()
    '    If Not dtDisplaymonthlytarget Is Nothing Then
    '        If dtDisplaymonthlytarget.Rows.Count > 0 Then
    '            txtPageSize1.Visible = True
    '            lblPagesize1.Visible = True
    '            txtPageSize1.Text = 10
    '            gvMonthlytarget.PageSize = Convert.ToInt16(txtPageSize1.Text)
    '            gvMonthlytarget.Visible = True
    '            gvMonthlytarget.AllowSorting = True
    '            gvMonthlytarget.PageIndex = 0
    '            gvMonthlytarget.DataSource = dtDisplaymonthlytarget
    '            gvMonthlytarget.DataBind()

    '            'btnExport.Visible = True
    '            'lblErrorMessage.Visible = True
    '            lblErrorMessage1.Visible = False
    '            lbltotal.Text = "Total No of Records : " & dtDisplaymonthlytarget.Rows.Count
    '            'lblTitle.Text = drpTaskExport.SelectedItem.Text
    '        Else
    '            gvMonthlytarget.AllowSorting = False
    '            gvMonthlytarget.DataBind()
    '            gvMonthlytarget.Visible = False
    '            lblErrorMessage1.Visible = False
    '            'btnExport.Visible = False
    '            txtPageSize1.Visible = False
    '            lblPagesize1.Visible = False
    '        End If
    '    End If
    'End Sub





    Sub DeleteOldFiles(fileName As String)
        Try
            File.Delete(fileName)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub gvMonthlytarget_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gvMonthlytarget.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso gvMonthlytarget.EditIndex = e.Row.RowIndex Then

        End If
    End Sub

    Protected Sub txtPageSize1_TextChanged(sender As Object, e As EventArgs) Handles txtPageSize1.TextChanged
        Dim intValue As Integer
        If Integer.TryParse(txtPageSize1.Text, intValue) AndAlso intValue > 0 AndAlso intValue <= 9999 Then
            lblErrorMessage1.Visible = False

            Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()
            Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
            Dim dt As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid(_Monthlytargetmodel)
            Dim dv As DataView = New DataView(dt)
            If ViewState("SortExpression") Is Nothing Then
                'dgColdtl.DefaultView.Sort = "unq_no ASC"
                'dv.Sort = gvDisplayPaymentValue.Columns(0).SortExpression & " " & Me.SortDirection
                dv.Sort = "unq_no Desc"

            Else
                dv.Sort = ViewState("SortExpression") & " " & Me.SortDirection

            End If

            txtPageSize1.Text = Convert.ToInt16(txtPageSize1.Text)
            gvMonthlytarget.PageSize = Convert.ToInt16(txtPageSize1.Text)
            gvMonthlytarget.PageIndex = 0
            gvMonthlytarget.DataSource = dv
            gvMonthlytarget.DataBind()

        Else
            lblErrorMessage.Visible = True
            txtPageSize1.Text = gvMonthlytarget.PageSize

        End If


    End Sub

    Protected Sub gvMonthlytarget_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvMonthlytarget.EditIndex = e.NewEditIndex
        'gvMonthlytarget.PageIndex = e.

        Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()
        Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
        ' _Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text

        If (DropDownYear2.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text
        End If

        If (DropdownList7.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
        End If

        If (DropDownMonth2.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedValue
        End If

        '_Monthlytargetmodel.SHIP_TO_BRANCH = "SSC4" 'DropdownList7.SelectedItem.Text
        '_Monthlytargetmodel.TARGET_MONTH = "12" ''DropDownMonth2.SelectedValue
        '_Monthlytargetmodel.TARGET_YEAR = "2020" ''DropDownYear2.SelectedItem.Text

        Dim dt As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid(_Monthlytargetmodel)

        dt = dt.DefaultView.ToTable()
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then


                gvMonthlytarget.Visible = True
                gvMonthlytarget.DataSource = dt
                gvMonthlytarget.DataBind()




                Dim row As GridViewRow = gvMonthlytarget.Rows(e.NewEditIndex)
                Dim dd1 As DropDownList = row.FindControl("drpdowntargetssc")
                Dim dd2 As DropDownList = row.FindControl("DropDownMonth3")
                Dim dd3 As DropDownList = row.FindControl("DropDownYear3")
                'Dim dd4 As TextBox = row.FindControl("txtunq_no1")

                dd1.DataSource = Session("codeMasterList")
                dd1.DataTextField = "CodeDispValue"
                dd1.DataValueField = "CodeValue"
                dd1.DataBind()

                Dim row2 As GridViewRow = gvMonthlytarget.Rows(e.NewEditIndex)
                Dim hdn As HiddenField = row.FindControl("HiddenField1")
                Dim hdn2 As HiddenField = row.FindControl("HiddenField2")
                Dim hdn3 As HiddenField = row.FindControl("HiddenField3")
                'Dim hdn4 As HiddenField = row.FindControl("HiddenField4")

                dd1.Items.FindByText(hdn.Value).Selected = True
                dd2.Items.FindByValue(hdn2.Value).Selected = True
                dd3.Items.FindByText(hdn3.Value).Selected = True
                'dd4.Text.FindByText(hdn4.Value).Selected = True






            End If
        End If
    End Sub

    Protected Sub gvMonthlytarget_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvMonthlytarget.EditIndex = -1
        Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()
        Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
        '_Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text
        If (DropDownYear2.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text
        End If

        If (DropdownList7.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
        End If

        If (DropDownMonth2.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedValue
        End If
        Dim dt As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid(_Monthlytargetmodel)
        dt = dt.DefaultView.ToTable()
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                gvMonthlytarget.Visible = True
                gvMonthlytarget.DataSource = dt
                gvMonthlytarget.DataBind()
            End If
        End If
    End Sub

    Protected Sub gvMonthlytarget_Sorting(sender As Object, e As GridViewSortEventArgs)
        If IsPostBack = True Then
            Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()
            Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
            '_Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text
            If (DropDownYear2.SelectedItem.Text <> "Select") Then
                _Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text
            End If

            If (DropdownList7.SelectedItem.Text <> "Select") Then
                _Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
            End If

            If (DropDownMonth2.SelectedItem.Text <> "Select") Then
                _Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedValue
            End If
            Dim dt As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid(_Monthlytargetmodel)
            If (Not (dt) Is Nothing) Then
                Dim dv As DataView = New DataView(dt)
                ViewState("SortExpression") = e.SortExpression

                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = e.SortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
                gvMonthlytarget.DataBind()
                '
            End If
        End If
        'https://www.aspsnippets.com/Articles/Ascending-Descending-Sorting-using-Columns-Header-in-ASPNet-GridView.aspx
        'https://www.codeproject.com/Articles/1195569/Angular-Data-Grid-with-Sorting-Filtering-Export-to
        'https://forums.asp.net/t/1412788.aspx?How+to+Export+GridView+To+Word+Excel+PDF+CSV+in+ASP+Net
    End Sub

    Protected Sub gvMonthlytarget_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvMonthlytarget.PageIndex = e.NewPageIndex

        Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll() 'Added for MonthlyTarget Search
        Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
        If (DropDownYear2.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text
        End If

        If (DropdownList7.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
        End If

        If (DropDownMonth2.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedValue
        End If
        '_Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text

        ' Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()
        Dim dt As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid(_Monthlytargetmodel)

        Dim dv As DataView = New DataView(dt)
        ' If ViewState("SortExpression") Is Nothing Then
        'dv.Sort = gvDisplayPaymentValue.Columns(0).SortExpression & " " & Me.SortDirection
        'dv.Sort = "unq_no Desc"
        'Else
        'dv.Sort = ViewState("SortExpression") & " " & Me.SortDirection
        'End If
        ' dv.Sort = "ServiceOrder_No " & Me.SortDirection
        gvMonthlytarget.DataSource = dv
        gvMonthlytarget.DataBind()
    End Sub
    Public Sub pageload(Optional ByVal sortExpression As String = Nothing) 'Added for MonthlyTarget Search
        If IsPostBack = True Then
            Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()
            Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
            '_Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text
            Dim dt As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid(_Monthlytargetmodel)


            Dim _dataview As New DataView(dt)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dt.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
            Else
                gvMonthlytarget.DataSource = dt
            End If
            gvMonthlytarget.DataBind()
        End If
    End Sub




    Protected Sub gvMonthlytarget_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()

        Dim row As GridViewRow = gvMonthlytarget.Rows(e.RowIndex)
        Dim unq_no As Integer = Convert.ToInt32(gvMonthlytarget.DataKeys(e.RowIndex).Values(0))

        Dim TargetSSC As String = (TryCast(row.FindControl("drpdowntargetssc"), DropDownList)).SelectedItem.Text
        'Dim TargetAmount As String = (TryCast(row.FindControl("lblTargetMonthAmount"), TextBox)).Text
        'Dim TotalCount As String = (TryCast(row.FindControl("lblTargetCallloadCount"), TextBox)).Text 'Call load

        Dim TargetAmount As String = (TryCast(row.FindControl("txtTargetMonthAmount"), TextBox)).Text
        Dim TotalCount As String = (TryCast(row.FindControl("txtTargetCallloadCount"), TextBox)).Text 'Call load

        Dim TargetMonth As String = (TryCast(row.FindControl("DropDownMonth3"), DropDownList)).SelectedItem.Value
        Dim Targetyear As String = (TryCast(row.FindControl("DropDownYear3"), DropDownList)).SelectedItem.Value
        'query
        Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()

        Dim targetday As String
        Dim targetdaycount As String

        If (TargetMonth = 4 Or 6 Or 9 Or 11) Then
            If targetamtbox.Text <> "" Then
                targetday = TargetAmount / 30
            End If
            If targetcallload.Text <> "" Then
                targetdaycount = TotalCount / 30
            End If
        ElseIf (TargetMonth = 2) Then
                If (Targetyear Mod 4 = 0) Then
                If targetamtbox.Text <> "" Then
                    targetday = TargetAmount / 29
                End If
                If targetcallload.Text <> "" Then
                    targetdaycount = TotalCount / 29
                End If
            Else
                If targetamtbox.Text <> "" Then
                    targetday = TargetAmount / 28
                End If
                If targetcallload.Text <> "" Then
                    targetdaycount = TotalCount / 28
                End If
            End If
                Else
            If targetamtbox.Text <> "" Then
                targetday = TargetAmount / 31
            End If
            If targetcallload.Text <> "" Then
                targetdaycount = TotalCount / 31
            End If
        End If



            _Monthlytargetmodel.UNQ_NO = Convert.ToString(unq_no)
        _Monthlytargetmodel.SHIP_TO_BRANCH = TargetSSC
        _Monthlytargetmodel.TARGET_MONTH_AMOUNT = TargetAmount
        _Monthlytargetmodel.TARGET_MONTH = TargetMonth
        _Monthlytargetmodel.TARGET_YEAR = Targetyear
        _Monthlytargetmodel.TARGET_DAY_AMOUNT = targetday
        _Monthlytargetmodel.TARGET_CALLLOAD_COUNT = TotalCount 'Call load
        _Monthlytargetmodel.TARGET_DAY_COUNT = targetdaycount 'Call load
        '_PaymentVlaueModel.UserId = Session("user_id").ToString

        Dim dtUpdatePaymentValue As Boolean = _MonthlyTargetControll.UpdatemonthlyFromGrid(_Monthlytargetmodel)

        gvMonthlytarget.EditIndex = -1

        If (DropDownYear2.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.TARGET_YEAR_1 = DropDownYear2.SelectedItem.Text
        End If

        If (DropdownList7.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.SHIP_TO_BRANCH_1 = DropdownList7.SelectedItem.Text
        End If

        If (DropDownMonth2.SelectedItem.Text <> "Select") Then
            _Monthlytargetmodel.TARGET_MONTH_1 = DropDownMonth2.SelectedValue
        End If

        Dim dt As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid_1(_Monthlytargetmodel)
        dt = dt.DefaultView.ToTable()
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                gvMonthlytarget.Visible = True
                gvMonthlytarget.DataSource = dt
                gvMonthlytarget.DataBind()
            End If
        End If
    End Sub



    Protected Sub imagebutton71(selectedYear As String, selectedMonth As String, selectedSheet As Integer, fileName As String, templateFileName As String, tmpDirector As String)
        'Dim WeeklyGraphMode As String = "old"
        'Try
        '    WeeklyGraphMode = ConfigurationManager.AppSettings("WeeklyGraph")
        'Catch ex As Exception
        'End Try
        'If LCase(WeeklyGraphMode) = "new" Then
        '    Call WeeklyGraphNew(selectedYear, selectedMonth, selectedSheet, fileName, templateFileName, tmpDirector)
        'Else
        '    Call WeeklyGraphOld(selectedYear, selectedMonth, selectedSheet, fileName, templateFileName, tmpDirector)
        'End If
        Call WeeklyGraphNew(selectedYear, selectedMonth, selectedSheet, fileName, templateFileName, tmpDirector)
    End Sub


    Sub WeeklyGraphNew(selectedYear As String, selectedMonth As String, selectedSheet As Integer, fileName As String, templateFileName As String, tmpDirector As String)
        If (DropDownList9.SelectedItem.Text = "") Or (DropDownList9.SelectedItem.Value = "0") Then
            Call showMsg("Please Select the month", "")
            Exit Sub
        End If

        Dim strMaxDay As String = ""
        Dim DtFrom As String = ""
        Dim DtTo As String = ""
        Dim strYear As String = selectedYear
        Dim strMonth As String = selectedMonth

        If Len(strMonth) = 1 Then
            strMonth = "0" & strMonth
        End If

        strMaxDay = Date.DaysInMonth(strYear, strMonth)


        'Added for date 
        ' Dim workbook1
        ' Dim worksheet3 = workbook1.Worksheets(0)
        'worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
        'Added for date





        Dim _SalesControl1 As SalesControl = New SalesControl()
        Dim dtSIDSales2 As DataTable = _SalesControl1.SelectTargetSales(strYear, strMonth)
        Dim targetAmount As Decimal
        'Add for Weekly Revenue Report
        If (dtSIDSales2.Rows.Count > 0 Or dtSIDSales2.Rows.Count = 0) Then

            Dim SSC1 As String

            Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")

            If (exists = False And exists2 = False) Then
                ' exists = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
                exists2 = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
                SSC1 += "SSC2,"
            End If

            ' Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            'Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
            Dim exists3 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC3")
            'Dim exists4 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC4")
            Dim exists5 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC6")
            Dim exists6 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC7")
            Dim exists7 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC8")
            Dim exists8 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC9")
            Dim exists9 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC10")
            Dim exists10 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC11")
            Dim exists11 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SID1")


            'If exists = False Then
            'SSC1 = "SSC1,"

            'End If

            'If exists2 = False Then
            'SSC1 += "SSC2,"

            'End If

            If exists3 = False Then
                SSC1 += "SSC3,"

            End If

            'If exists4 = False Then
            'SSC1 += "SSC4,"

            'End If
            If exists5 = False Then
                SSC1 += "SSC6,"

            End If
            If exists6 = False Then
                SSC1 += "SSC7,"

            End If
            If exists7 = False Then
                SSC1 += "SSC8,"

            End If
            If exists8 = False Then
                SSC1 += "SSC9,"

            End If
            If exists9 = False Then
                SSC1 += "SSC10,"

            End If
            If exists10 = False Then
                SSC1 += "SSC11,"
            End If
            If exists11 = False Then
                SSC1 += "SID1,"
            End If

            Dim Flag As Boolean = True
            If Not String.IsNullOrEmpty(SSC1) Then

                Dim BtnCancelChk As String = ""
                Dim BtnOK2Chk As String = ""
                'Call showMsg("Target Amount is not available for ('" & SSC1 & "'). Do you want to continue, it is ok?", "CancelMsg2")
                'Exit Sub
                Flag = False


                DtFrom = strYear & "/" & strMonth & "/" & "01"
                DtTo = strYear & "/" & strMonth & "/" & strMaxDay

                Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
                Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

                Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
                'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
                'Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
                Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

                Sc_Drs_Model.DateFrom = DtFrom
                Sc_Drs_Model.DateTo = DtTo

                Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
                Dim str As String = ""
                Dim strMaxDayCount As Integer = 0

                If Sc_Drs_Model.BranchName.Contains(",") Then
                    Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
                End If

                Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
                Dim noofrec As Integer
                noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())

                If dtDailyRevenue.Rows.Count > 1 Then

                    'Dim tmpDirector As String = tmpDirector
                    'Try
                    '    If (Not System.IO.Directory.Exists("C:\temp\")) Then
                    '        System.IO.Directory.CreateDirectory("C:\temp\")
                    '    End If
                    '    If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
                    '        System.IO.Directory.CreateDirectory("C:\temp\gembox\")
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    'For Each fileName As String In Directory.EnumerateFiles(tmpDirector, "*.xlsx")
                    '    DeleteOldFiles(fileName)
                    'Next

                    Dim dateAndTime As Date
                    dateAndTime = Now
                    Dim xlsFileName As String = ""
                    xlsFileName = fileName

                    ' If using Professional version, put your serial key below.
                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

                    Dim workbook

                    workbook = ExcelFile.Load(templateFileName)
                    'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



                    If strMaxDay = "31" Then
                        'workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "30" Then
                        'workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
                        strMaxDayCount = -1
                    ElseIf strMaxDay = "29" Then
                        'workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
                        'strMaxDayCount = -2
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "28" Then
                        'workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
                        'strMaxDayCount = -3
                        strMaxDayCount = 0
                    End If

                    'For date added
                    ' Dim worksheet2 = workbook.Worksheets(0)
                    ' Dim worksheet3 = workbook.Worksheets(0)
                    'Dim currentRow2 = worksheet3.rows(5)
                    'currentRow2 = DropDownList9.SelectedItem.Value
                    'Dim currentrow = DropDownList9.SelectedItem.Value
                    ' Dim rng As Excel.Range
                    'shXL.Range("A2").Value
                    'rng = CType(worksheet3.Cells(5, 6), Excel.Range("A5"))
                    'worksheet3.cells("A5").value = "<font size=20px> '" & strMaxDay & "'  " - "  '" & DropDownList9.SelectedItem.Text & "' </font>"
                    'worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
                    'LblINFO.Text = "<font size=20px>There is no status transaction log found</font>"
                    ' Dim currentRow2 = rng.Value
                    'Dim currentRow3 = worksheet3.Rows(20)
                    'currentRow2 = DropDownList9.SelectedItem.Value
                    'currentRow3 = DropDownList9.SelectedItem.Value
                    'For date added



                    'Added for date 
                    If prevmonth = True Then
                        Dim worksheet3 = workbook.Worksheets(0)
                        worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
                    End If
                    'Added for date





                    Dim workingDays As Integer = 8

                    Dim startDate = DateTime.Now.AddDays(-workingDays)
                    Dim endDate = DateTime.Now
                    Dim worksheet = workbook.Worksheets(selectedSheet)

                    Dim worksheet1 = workbook.Worksheets(selectedSheet)
                    Dim currentRow1 = worksheet1.Rows(23)

                    Dim XlDayRow As Integer = 0
                    Dim XlDayCol As Integer = 0
                    Dim xlTargetRow As Integer = 0
                    Dim xlTargetCol As Integer = 0

                    For Each branch As String In SplitBrances
                        Dim filter As String
                        filter = "SSCNAME = " & branch
                        Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

                        Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
                        Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
                        ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

                        XlDayRow = 0
                        XlDayCol = 0
                        xlTargetRow = 0
                        xlTargetCol = 0

                        branch = branch.Replace("'", "")

                        Dim blChangeValue As Boolean = False

                        'If branch = "SSC1" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 2

                        '    XlDayRow = 24
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC2" Then
                        '    xlTargetRow = 0
                        '    xlTargetCol = 0

                        '    XlDayRow = 0
                        '    XlDayCol = 0

                        '    blChangeValue = False
                        'ElseIf branch = "SSC3" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 6

                        '    XlDayRow = 24
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC4" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 10

                        '    XlDayRow = 24
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC6" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 14

                        '    XlDayRow = 24
                        '    XlDayCol = 15

                        '    blChangeValue = True
                        'ElseIf branch = "SSC7" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 19

                        '    XlDayRow = 24
                        '    XlDayCol = 19

                        '    blChangeValue = True
                        'ElseIf branch = "SSC8" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 2

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC9" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 6

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC10" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 10

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC11" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 14

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 15

                        '    blChangeValue = True

                        'ElseIf branch = "SSC ALL" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 18

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 19

                        '    blChangeValue = True

                        'ElseIf branch = "SID1" Then

                        '    xlTargetRow = 79
                        '    xlTargetCol = 23

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 24

                        '    blChangeValue = False

                        'End If

                        'Added for SSC4 Service center
                        'If branch = "SSC1" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 2

                        '    XlDayRow = 24
                        '    XlDayCol = 3

                        '    blChangeValue = True 'Removed for SSC4

                        'ElseIf branch = "SSC2" Then
                        '    xlTargetRow = 0
                        '    xlTargetCol = 0

                        '    XlDayRow = 0
                        '    XlDayCol = 0

                        '    blChangeValue = False

                        'ElseIf branch = "SSC3" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 6

                        '    XlDayRow = 24
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC4" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 10

                        '    XlDayRow = 24
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC6" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 14

                        '    XlDayRow = 24
                        '    XlDayCol = 15

                        '    blChangeValue = True
                        'ElseIf branch = "SSC7" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 18

                        '    XlDayRow = 24
                        '    XlDayCol = 19

                        '    blChangeValue = True
                        'ElseIf branch = "SSC8" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 2

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC9" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 6

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC10" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 10

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC11" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 14

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 15

                        '    blChangeValue = True

                        'ElseIf branch = "SSC ALL" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 18

                        '    ' XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 19

                        '    blChangeValue = True

                        'ElseIf branch = "SID1" Then

                        '    xlTargetRow = 79
                        '    xlTargetCol = 23

                        '    ' XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 24

                        '    blChangeValue = False

                        'End If

                        'Removed for SSC4 Service center

                        If branch = "SSC1" Then
                            xlTargetRow = 23
                            xlTargetCol = 2

                            XlDayRow = 24
                            XlDayCol = 3

                            blChangeValue = True

                        ElseIf branch = "SSC2" Then
                            xlTargetRow = 0
                            xlTargetCol = 0

                            XlDayRow = 0
                            XlDayCol = 0

                            blChangeValue = False

                        ElseIf branch = "SSC3" Then
                            xlTargetRow = 23
                            xlTargetCol = 6

                            XlDayRow = 24
                            XlDayCol = 7

                            blChangeValue = True

                        ElseIf branch = "SSC6" Then
                            xlTargetRow = 23
                            xlTargetCol = 10

                            XlDayRow = 24
                            XlDayCol = 11

                            blChangeValue = True

                        ElseIf branch = "SSC7" Then
                            xlTargetRow = 23
                            xlTargetCol = 14

                            XlDayRow = 24
                            XlDayCol = 15

                            blChangeValue = True

                        ElseIf branch = "SSC8" Then
                            xlTargetRow = 23 '79
                            'xlTargetRow = 80
                            xlTargetCol = 18 '2

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 24 '80
                            XlDayCol = 19 '3
                            'XlDayCol = 2

                            blChangeValue = True
                        ElseIf branch = "SSC9" Then
                            xlTargetRow = 79
                            xlTargetCol = 2 '6

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 3 '7

                            blChangeValue = True
                        ElseIf branch = "SSC10" Then
                            xlTargetRow = 79
                            xlTargetCol = 6 ' 10

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 7 '11

                            blChangeValue = True
                        ElseIf branch = "SSC11" Then
                            xlTargetRow = 79
                            xlTargetCol = 10 '14

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 11 '15

                            blChangeValue = True

                        ElseIf branch = "SSC ALL" Then
                            xlTargetRow = 79
                            xlTargetCol = 14 '18

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 15 '19

                            blChangeValue = True

                        ElseIf branch = "SID1" Then

                            xlTargetRow = 79
                            xlTargetCol = 18 '23

                            ' XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 19 ' 24

                            blChangeValue = False

                        End If



                        If blChangeValue Then
                            currentRow1 = worksheet1.Rows(xlTargetRow)
                            'currentRow1.Cells(xlTargetCol).SetValue(12345)
                            If dtSIDSales2.Rows.Count > 0 Then
                                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
                                targetAmount = 0 'Added for Weekly Revenue Report
                                For Each dtSIDSales2Row As DataRow In result
                                    targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
                                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                                Next
                            End If
                            currentRow1.Cells(xlTargetCol).SetValue(targetAmount)

                            Dim _XlDayRow As Integer = XlDayRow
                            Dim _XlDayCol As Integer = 0
                            Dim SscSalesAmount As Decimal

                            For Each row As DataRow In tabresult
                                'row(0)
                                'SscSalesAmount = row(4)
                                SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for weekly Revenue Report
                                currentRow1 = worksheet1.Rows(_XlDayRow)
                                currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

                                _XlDayRow = _XlDayRow + 1

                            Next
                        End If

                    Next


                    Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTracking(strYear, strMonth)


                    xlTargetRow = 79
                    xlTargetCol = 23

                    ' XlDayRow = 80 + strMaxDayCount
                    XlDayRow = 80
                    XlDayCol = 24

                    Dim _XlDayRow2 As Integer = 0
                    _XlDayRow2 = XlDayRow
                    Dim _XlDayCol2 As Integer = 0

                    If dtSIDSales2.Rows.Count > 0 Then
                        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
                        For Each dtSIDSales2Row As DataRow In result
                            targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
                            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                        Next
                    End If
                    currentRow1 = worksheet1.Rows(xlTargetRow)
                    'currentRow1.Cells(xlTargetCol).SetValue(12345)
                    currentRow1.Cells(xlTargetCol).SetValue(targetAmount) 'tagtDayAmt


                    Dim SalesAmount As Decimal
                    'For Each row As DataRow In dtSIDSales
                    For Each row As DataRow In dtSIDSales1.Rows
                        'row(0)
                        currentRow1 = worksheet1.Rows(_XlDayRow2)
                        ' SalesAmount = row(1)
                        SalesAmount = Convert.ToDecimal(row(1)) 'Added for Weekly Revenue Report
                        currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

                        _XlDayRow2 = _XlDayRow2 + 1
                    Next





                    worksheet1.Calculate()


                    workbook.Save(tmpDirector & xlsFileName & ".xlsx")


                    'Response.Clear()
                    'Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirector & xlsFileName & ".xlsx"))
                    'Response.ContentType = "application/vnd.ms-excel"
                    ''Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    'Response.WriteFile(tmpDirector & xlsFileName & ".xlsx")
                    'Response.End()

                End If
            End If
            'End for Weekly Revenue Report
            If Flag = True Then 'Add for Weekly Revenue Report


                Dim targetAmount1 As Decimal

                DtFrom = strYear & "/" & strMonth & "/" & "01"
                DtTo = strYear & "/" & strMonth & "/" & strMaxDay

                Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
                Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

                Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
                'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
                'Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
                Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

                Sc_Drs_Model.DateFrom = DtFrom
                Sc_Drs_Model.DateTo = DtTo

                Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
                Dim str As String = ""
                Dim strMaxDayCount As Integer = 0

                If Sc_Drs_Model.BranchName.Contains(",") Then
                    Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
                End If

                Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
                Dim noofrec As Integer
                noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())

                If dtDailyRevenue.Rows.Count > 1 Then
                    'If dtDailyRevenue.Rows.Count > 1 And dtSIDSales2.Rows.Count > 1 Then 'Added for Weekly Revenue Report

                    'Uncomment for june
                    'Dim tmpdirector1 As String = "c:\temp\gembox\"
                    'Try
                    '    If (Not System.IO.Directory.Exists("c:\temp\")) Then
                    '        System.IO.Directory.CreateDirectory("c:\temp\")
                    '    End If
                    '    If (Not System.IO.Directory.Exists("c:\temp\gembox\")) Then
                    '        System.IO.Directory.CreateDirectory("c:\temp\gembox\")
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    'For Each filename1 As String In Directory.EnumerateFiles(tmpdirector, "*.xlsx")
                    '    DeleteOldFiles(fileName)
                    'Next
                    'Uncomment for june

                    Dim dateAndTime As Date
                    dateAndTime = Now
                    Dim xlsFileName As String = ""
                    xlsFileName = fileName

                    ' If using Professional version, put your serial key below.
                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

                    Dim workbook

                    workbook = ExcelFile.Load(templateFileName)
                    'workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                    'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



                    If strMaxDay = "31" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "30" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
                        strMaxDayCount = -1
                    ElseIf strMaxDay = "29" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
                        'strMaxDayCount = -2
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "28" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
                        'strMaxDayCount = -3
                        strMaxDayCount = 0
                    End If


                    'Added for date 
                    If prevmonth = True Then
                        Dim worksheet3 = workbook.Worksheets(0)
                        worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
                    End If
                    ' worksheet3.cells("A3").value = strYear + " - " + DropDownList9.SelectedItem.Text
                    'worksheet3.cells("A3").value = DtTo + " - " + DropDownList9.SelectedItem.Text
                    'Added for date


                    Dim workingDays As Integer = 8

                    Dim startDate = DateTime.Now.AddDays(-workingDays)
                    Dim endDate = DateTime.Now
                    Dim worksheet = workbook.Worksheets(selectedSheet)

                    Dim worksheet1 = workbook.Worksheets(selectedSheet)
                    Dim currentRow1 = worksheet1.Rows(23)

                    Dim XlDayRow As Integer = 0
                    Dim XlDayCol As Integer = 0
                    Dim xlTargetRow As Integer = 0
                    Dim xlTargetCol As Integer = 0

                    For Each branch As String In SplitBrances
                        Dim filter As String
                        filter = "SSCNAME = " & branch
                        Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

                        Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
                        Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
                        ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

                        XlDayRow = 0
                        XlDayCol = 0
                        xlTargetRow = 0
                        xlTargetCol = 0

                        branch = branch.Replace("'", "")

                        Dim blChangeValue As Boolean = False

                        'If branch = "SSC1" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 2

                        '    XlDayRow = 24
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC2" Then
                        '    xlTargetRow = 0
                        '    xlTargetCol = 0

                        '    XlDayRow = 0
                        '    XlDayCol = 0

                        '    blChangeValue = False
                        'ElseIf branch = "SSC3" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 6

                        '    XlDayRow = 24
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC4" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 10

                        '    XlDayRow = 24
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC6" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 14

                        '    XlDayRow = 24
                        '    XlDayCol = 15

                        '    blChangeValue = True
                        'ElseIf branch = "SSC7" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 19

                        '    XlDayRow = 24
                        '    XlDayCol = 19

                        '    blChangeValue = True
                        'ElseIf branch = "SSC8" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 2

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC9" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 6

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC10" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 10

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC11" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 14

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 15

                        '    blChangeValue = True

                        'ElseIf branch = "SSC ALL" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 18

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 19

                        '    blChangeValue = True

                        'ElseIf branch = "SID1" Then

                        '    xlTargetRow = 79
                        '    xlTargetCol = 23

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 24

                        '    blChangeValue = False

                        'End If

                        'Added for SSC4

                        'If branch = "SSC1" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 2

                        '    XlDayRow = 24
                        '    XlDayCol = 3

                        '    blChangeValue = True 'Removed for SSC4

                        'ElseIf branch = "SSC2" Then
                        '    xlTargetRow = 0
                        '    xlTargetCol = 0

                        '    XlDayRow = 0
                        '    XlDayCol = 0

                        '    blChangeValue = False

                        'ElseIf branch = "SSC3" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 6

                        '    XlDayRow = 24
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC4" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 10

                        '    XlDayRow = 24
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC6" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 14

                        '    XlDayRow = 24
                        '    XlDayCol = 15

                        '    blChangeValue = True
                        'ElseIf branch = "SSC7" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 18

                        '    XlDayRow = 24
                        '    XlDayCol = 19

                        '    blChangeValue = True
                        'ElseIf branch = "SSC8" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 2

                        '    ' XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC9" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 6

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC10" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 10

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC11" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 14

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 15

                        '    blChangeValue = True

                        'ElseIf branch = "SSC ALL" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 18

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 19

                        '    blChangeValue = True

                        'ElseIf branch = "SID1" Then

                        '    xlTargetRow = 79
                        '    xlTargetCol = 23

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 24

                        '    blChangeValue = False

                        'End If

                        'Removed for SSC4

                        If branch = "SSC1" Then
                            xlTargetRow = 23
                            xlTargetCol = 2

                            XlDayRow = 24
                            XlDayCol = 3

                            blChangeValue = True

                        ElseIf branch = "SSC2" Then
                            xlTargetRow = 0
                            xlTargetCol = 0

                            XlDayRow = 0
                            XlDayCol = 0

                            blChangeValue = False

                        ElseIf branch = "SSC3" Then
                            xlTargetRow = 23
                            xlTargetCol = 6

                            XlDayRow = 24
                            XlDayCol = 7

                            blChangeValue = True

                        ElseIf branch = "SSC6" Then
                            xlTargetRow = 23
                            xlTargetCol = 10

                            XlDayRow = 24
                            XlDayCol = 11

                            blChangeValue = True

                        ElseIf branch = "SSC7" Then
                            xlTargetRow = 23
                            xlTargetCol = 14

                            XlDayRow = 24
                            XlDayCol = 15

                            blChangeValue = True

                        ElseIf branch = "SSC8" Then
                            xlTargetRow = 23 '79
                            'xlTargetRow = 80
                            xlTargetCol = 18 '2

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 24 '80
                            XlDayCol = 19 '3
                            ' XlDayCol = 2

                            blChangeValue = True
                        ElseIf branch = "SSC9" Then
                            xlTargetRow = 79
                            xlTargetCol = 2 '6

                            ' XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 3 '7

                            blChangeValue = True
                        ElseIf branch = "SSC10" Then
                            xlTargetRow = 79
                            xlTargetCol = 6 '10

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 7 '11

                            blChangeValue = True
                        ElseIf branch = "SSC11" Then
                            xlTargetRow = 79
                            xlTargetCol = 10 '14

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 11 '15

                            blChangeValue = True

                        ElseIf branch = "SSC ALL" Then
                            xlTargetRow = 79
                            xlTargetCol = 14 '18

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 15 '19

                            blChangeValue = True

                        ElseIf branch = "SID1" Then

                            xlTargetRow = 79
                            xlTargetCol = 18 '23

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 19 ' 24

                            blChangeValue = False

                        End If

                        If blChangeValue Then
                            currentRow1 = worksheet1.Rows(xlTargetRow)
                            'currentRow1.Cells(xlTargetCol).SetValue(12345)
                            If dtSIDSales2.Rows.Count > 0 Then
                                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
                                targetAmount1 = 0 'Added for Weekly Revenue Report
                                For Each dtSIDSales2Row As DataRow In result
                                    targetAmount1 = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
                                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                                Next
                            End If
                            currentRow1.Cells(xlTargetCol).SetValue(targetAmount1)

                            Dim _XlDayRow As Integer = XlDayRow
                            Dim _XlDayCol As Integer = 0
                            Dim SscSalesAmount As Decimal

                            For Each row As DataRow In tabresult
                                'row(0)
                                ' SscSalesAmount = row(4)
                                SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for weekly Revenue Report
                                currentRow1 = worksheet1.Rows(_XlDayRow)
                                currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

                                _XlDayRow = _XlDayRow + 1

                            Next
                        End If

                    Next


                    Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTracking(strYear, strMonth)


                    xlTargetRow = 79
                    xlTargetCol = 18 '23

                    'XlDayRow = 80 + strMaxDayCount
                    XlDayRow = 80
                    XlDayCol = 19 '24

                    Dim _XlDayRow2 As Integer = 0
                    _XlDayRow2 = XlDayRow
                    Dim _XlDayCol2 As Integer = 0

                    If dtSIDSales2.Rows.Count > 0 Then
                        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
                        For Each dtSIDSales2Row As DataRow In result
                            targetAmount1 = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
                            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                        Next
                    End If
                    currentRow1 = worksheet1.Rows(xlTargetRow)
                    'currentRow1.Cells(xlTargetCol).SetValue(12345)
                    currentRow1.Cells(xlTargetCol).SetValue(targetAmount1) 'tagtDayAmt


                    Dim SalesAmount As Decimal
                    'For Each row As DataRow In dtSIDSales
                    For Each row As DataRow In dtSIDSales1.Rows
                        'row(0)
                        currentRow1 = worksheet1.Rows(_XlDayRow2)
                        'SalesAmount = row(1)
                        SalesAmount = Convert.ToDecimal(row(1)) 'Added for Weekly Revenue Report
                        currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

                        _XlDayRow2 = _XlDayRow2 + 1
                    Next

                    worksheet1.Calculate()



                    workbook.Save(tmpDirector & xlsFileName & ".xlsx")


                    'Response.Clear()
                    'Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirector & xlsFileName & ".xlsx"))
                    'Response.ContentType = "application/vnd.ms-excel"
                    ''Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    'Response.WriteFile(tmpDirector & xlsFileName & ".xlsx")
                    'Response.End()

                End If
            End If

        End If



    End Sub


    Sub WeeklyGraphOld(selectedYear As String, selectedMonth As String, selectedSheet As Integer, fileName As String, templateFileName As String, tmpDirector As String)
        If (DropDownList9.SelectedItem.Text = "") Or (DropDownList9.SelectedItem.Value = "0") Then
            Call showMsg("Please Select the month", "")
            Exit Sub
        End If

        Dim strMaxDay As String = ""
        Dim DtFrom As String = ""
        Dim DtTo As String = ""
        Dim strYear As String = selectedYear
        Dim strMonth As String = selectedMonth

        If Len(strMonth) = 1 Then
            strMonth = "0" & strMonth
        End If

        strMaxDay = Date.DaysInMonth(strYear, strMonth)


        'Added for date 
        ' Dim workbook1
        ' Dim worksheet3 = workbook1.Worksheets(0)
        'worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
        'Added for date





        Dim _SalesControl1 As SalesControl = New SalesControl()
        Dim dtSIDSales2 As DataTable = _SalesControl1.SelectTargetSales(strYear, strMonth)
        Dim targetAmount As Decimal
        'Add for Weekly Revenue Report
        If (dtSIDSales2.Rows.Count > 0 Or dtSIDSales2.Rows.Count = 0) Then

            Dim SSC1 As String

            Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")

            If (exists = False And exists2 = False) Then
                ' exists = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
                exists2 = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
                SSC1 += "SSC2,"
            End If

            ' Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            'Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
            Dim exists3 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC3")
            'Dim exists4 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC4")
            Dim exists5 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC6")
            Dim exists6 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC7")
            Dim exists7 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC8")
            Dim exists8 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC9")
            Dim exists9 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC10")
            Dim exists10 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC11")
            Dim exists11 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SID1")


            'If exists = False Then
            'SSC1 = "SSC1,"

            'End If

            'If exists2 = False Then
            'SSC1 += "SSC2,"

            'End If

            If exists3 = False Then
                SSC1 += "SSC3,"

            End If

            'If exists4 = False Then
            'SSC1 += "SSC4,"

            'End If
            If exists5 = False Then
                SSC1 += "SSC6,"

            End If
            If exists6 = False Then
                SSC1 += "SSC7,"

            End If
            If exists7 = False Then
                SSC1 += "SSC8,"

            End If
            If exists8 = False Then
                SSC1 += "SSC9,"

            End If
            If exists9 = False Then
                SSC1 += "SSC10,"

            End If
            If exists10 = False Then
                SSC1 += "SSC11,"
            End If
            If exists11 = False Then
                SSC1 += "SID1,"
            End If

            Dim Flag As Boolean = True
            If Not String.IsNullOrEmpty(SSC1) Then

                Dim BtnCancelChk As String = ""
                Dim BtnOK2Chk As String = ""
                'Call showMsg("Target Amount is not available for ('" & SSC1 & "'). Do you want to continue, it is ok?", "CancelMsg2")
                'Exit Sub
                Flag = False


                DtFrom = strYear & "/" & strMonth & "/" & "01"
                DtTo = strYear & "/" & strMonth & "/" & strMaxDay

                Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
                Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

                Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
                'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
                'Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
                Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

                Sc_Drs_Model.DateFrom = DtFrom
                Sc_Drs_Model.DateTo = DtTo

                Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
                Dim str As String = ""
                Dim strMaxDayCount As Integer = 0

                If Sc_Drs_Model.BranchName.Contains(",") Then
                    Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
                End If

                Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
                Dim noofrec As Integer
                noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())

                If dtDailyRevenue.Rows.Count > 1 Then

                    'Dim tmpDirector As String = tmpDirector
                    'Try
                    '    If (Not System.IO.Directory.Exists("C:\temp\")) Then
                    '        System.IO.Directory.CreateDirectory("C:\temp\")
                    '    End If
                    '    If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
                    '        System.IO.Directory.CreateDirectory("C:\temp\gembox\")
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    'For Each fileName As String In Directory.EnumerateFiles(tmpDirector, "*.xlsx")
                    '    DeleteOldFiles(fileName)
                    'Next

                    Dim dateAndTime As Date
                    dateAndTime = Now
                    Dim xlsFileName As String = ""
                    xlsFileName = fileName

                    ' If using Professional version, put your serial key below.
                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

                    Dim workbook

                    workbook = ExcelFile.Load(templateFileName)
                    'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



                    If strMaxDay = "31" Then
                        'workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "30" Then
                        'workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
                        strMaxDayCount = -1
                    ElseIf strMaxDay = "29" Then
                        'workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
                        'strMaxDayCount = -2
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "28" Then
                        'workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
                        'strMaxDayCount = -3
                        strMaxDayCount = 0
                    End If

                    'For date added
                    ' Dim worksheet2 = workbook.Worksheets(0)
                    ' Dim worksheet3 = workbook.Worksheets(0)
                    'Dim currentRow2 = worksheet3.rows(5)
                    'currentRow2 = DropDownList9.SelectedItem.Value
                    'Dim currentrow = DropDownList9.SelectedItem.Value
                    ' Dim rng As Excel.Range
                    'shXL.Range("A2").Value
                    'rng = CType(worksheet3.Cells(5, 6), Excel.Range("A5"))
                    'worksheet3.cells("A5").value = "<font size=20px> '" & strMaxDay & "'  " - "  '" & DropDownList9.SelectedItem.Text & "' </font>"
                    'worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
                    'LblINFO.Text = "<font size=20px>There is no status transaction log found</font>"
                    ' Dim currentRow2 = rng.Value
                    'Dim currentRow3 = worksheet3.Rows(20)
                    'currentRow2 = DropDownList9.SelectedItem.Value
                    'currentRow3 = DropDownList9.SelectedItem.Value
                    'For date added



                    'Added for date 
                    If prevmonth = True Then
                        Dim worksheet3 = workbook.Worksheets(0)
                        worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
                    End If
                    'Added for date





                    Dim workingDays As Integer = 8

                    Dim startDate = DateTime.Now.AddDays(-workingDays)
                    Dim endDate = DateTime.Now
                    Dim worksheet = workbook.Worksheets(selectedSheet)

                    Dim worksheet1 = workbook.Worksheets(selectedSheet)
                    Dim currentRow1 = worksheet1.Rows(23)

                    Dim XlDayRow As Integer = 0
                    Dim XlDayCol As Integer = 0
                    Dim xlTargetRow As Integer = 0
                    Dim xlTargetCol As Integer = 0

                    For Each branch As String In SplitBrances
                        Dim filter As String
                        filter = "SSCNAME = " & branch
                        Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

                        Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
                        Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
                        ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

                        XlDayRow = 0
                        XlDayCol = 0
                        xlTargetRow = 0
                        xlTargetCol = 0

                        branch = branch.Replace("'", "")

                        Dim blChangeValue As Boolean = False

                        'If branch = "SSC1" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 2

                        '    XlDayRow = 24
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC2" Then
                        '    xlTargetRow = 0
                        '    xlTargetCol = 0

                        '    XlDayRow = 0
                        '    XlDayCol = 0

                        '    blChangeValue = False
                        'ElseIf branch = "SSC3" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 6

                        '    XlDayRow = 24
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC4" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 10

                        '    XlDayRow = 24
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC6" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 14

                        '    XlDayRow = 24
                        '    XlDayCol = 15

                        '    blChangeValue = True
                        'ElseIf branch = "SSC7" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 19

                        '    XlDayRow = 24
                        '    XlDayCol = 19

                        '    blChangeValue = True
                        'ElseIf branch = "SSC8" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 2

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC9" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 6

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC10" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 10

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC11" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 14

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 15

                        '    blChangeValue = True

                        'ElseIf branch = "SSC ALL" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 18

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 19

                        '    blChangeValue = True

                        'ElseIf branch = "SID1" Then

                        '    xlTargetRow = 79
                        '    xlTargetCol = 23

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 24

                        '    blChangeValue = False

                        'End If

                        'Added for SSC4 Service center
                        'If branch = "SSC1" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 2

                        '    XlDayRow = 24
                        '    XlDayCol = 3

                        '    blChangeValue = True 'Removed for SSC4

                        'ElseIf branch = "SSC2" Then
                        '    xlTargetRow = 0
                        '    xlTargetCol = 0

                        '    XlDayRow = 0
                        '    XlDayCol = 0

                        '    blChangeValue = False

                        'ElseIf branch = "SSC3" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 6

                        '    XlDayRow = 24
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC4" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 10

                        '    XlDayRow = 24
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC6" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 14

                        '    XlDayRow = 24
                        '    XlDayCol = 15

                        '    blChangeValue = True
                        'ElseIf branch = "SSC7" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 18

                        '    XlDayRow = 24
                        '    XlDayCol = 19

                        '    blChangeValue = True
                        'ElseIf branch = "SSC8" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 2

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC9" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 6

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC10" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 10

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC11" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 14

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 15

                        '    blChangeValue = True

                        'ElseIf branch = "SSC ALL" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 18

                        '    ' XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 19

                        '    blChangeValue = True

                        'ElseIf branch = "SID1" Then

                        '    xlTargetRow = 79
                        '    xlTargetCol = 23

                        '    ' XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 24

                        '    blChangeValue = False

                        'End If

                        'Removed for SSC4 Service center

                        If branch = "SSC1" Then
                            xlTargetRow = 23
                            xlTargetCol = 2

                            XlDayRow = 24
                            XlDayCol = 3

                            blChangeValue = True

                        ElseIf branch = "SSC2" Then
                            xlTargetRow = 0
                            xlTargetCol = 0

                            XlDayRow = 0
                            XlDayCol = 0

                            blChangeValue = False

                        ElseIf branch = "SSC3" Then
                            xlTargetRow = 23
                            xlTargetCol = 6

                            XlDayRow = 24
                            XlDayCol = 7

                            blChangeValue = True

                        ElseIf branch = "SSC6" Then
                            xlTargetRow = 23
                            xlTargetCol = 10

                            XlDayRow = 24
                            XlDayCol = 11

                            blChangeValue = True

                        ElseIf branch = "SSC7" Then
                            xlTargetRow = 23
                            xlTargetCol = 14

                            XlDayRow = 24
                            XlDayCol = 15

                            blChangeValue = True

                        ElseIf branch = "SSC8" Then
                            xlTargetRow = 79
                            'xlTargetRow = 80
                            xlTargetCol = 2

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 3
                            'XlDayCol = 2

                            blChangeValue = True
                        ElseIf branch = "SSC9" Then
                            xlTargetRow = 79
                            xlTargetCol = 6

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 7

                            blChangeValue = True
                        ElseIf branch = "SSC10" Then
                            xlTargetRow = 79
                            xlTargetCol = 10

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 11

                            blChangeValue = True
                        ElseIf branch = "SSC11" Then
                            xlTargetRow = 79
                            xlTargetCol = 14

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 15

                            blChangeValue = True

                        ElseIf branch = "SSC ALL" Then
                            xlTargetRow = 79
                            xlTargetCol = 18

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 19

                            blChangeValue = True

                        ElseIf branch = "SID1" Then

                            xlTargetRow = 79
                            xlTargetCol = 23

                            ' XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 24

                            blChangeValue = False

                        End If



                        If blChangeValue Then
                            currentRow1 = worksheet1.Rows(xlTargetRow)
                            'currentRow1.Cells(xlTargetCol).SetValue(12345)
                            If dtSIDSales2.Rows.Count > 0 Then
                                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
                                targetAmount = 0 'Added for Weekly Revenue Report
                                For Each dtSIDSales2Row As DataRow In result
                                    targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
                                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                                Next
                            End If
                            currentRow1.Cells(xlTargetCol).SetValue(targetAmount)

                            Dim _XlDayRow As Integer = XlDayRow
                            Dim _XlDayCol As Integer = 0
                            Dim SscSalesAmount As Decimal

                            For Each row As DataRow In tabresult
                                'row(0)
                                'SscSalesAmount = row(4)
                                SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for weekly Revenue Report
                                currentRow1 = worksheet1.Rows(_XlDayRow)
                                currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

                                _XlDayRow = _XlDayRow + 1

                            Next
                        End If

                    Next


                    Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTracking(strYear, strMonth)


                    xlTargetRow = 79
                    xlTargetCol = 23

                    ' XlDayRow = 80 + strMaxDayCount
                    XlDayRow = 80
                    XlDayCol = 24

                    Dim _XlDayRow2 As Integer = 0
                    _XlDayRow2 = XlDayRow
                    Dim _XlDayCol2 As Integer = 0

                    If dtSIDSales2.Rows.Count > 0 Then
                        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
                        For Each dtSIDSales2Row As DataRow In result
                            targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
                            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                        Next
                    End If
                    currentRow1 = worksheet1.Rows(xlTargetRow)
                    'currentRow1.Cells(xlTargetCol).SetValue(12345)
                    currentRow1.Cells(xlTargetCol).SetValue(targetAmount) 'tagtDayAmt


                    Dim SalesAmount As Decimal
                    'For Each row As DataRow In dtSIDSales
                    For Each row As DataRow In dtSIDSales1.Rows
                        'row(0)
                        currentRow1 = worksheet1.Rows(_XlDayRow2)
                        ' SalesAmount = row(1)
                        SalesAmount = Convert.ToDecimal(row(1)) 'Added for Weekly Revenue Report
                        currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

                        _XlDayRow2 = _XlDayRow2 + 1
                    Next





                    worksheet1.Calculate()


                    workbook.Save(tmpDirector & xlsFileName & ".xlsx")


                    'Response.Clear()
                    'Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirector & xlsFileName & ".xlsx"))
                    'Response.ContentType = "application/vnd.ms-excel"
                    ''Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    'Response.WriteFile(tmpDirector & xlsFileName & ".xlsx")
                    'Response.End()

                End If
            End If
            'End for Weekly Revenue Report
            If Flag = True Then 'Add for Weekly Revenue Report


                Dim targetAmount1 As Decimal

                DtFrom = strYear & "/" & strMonth & "/" & "01"
                DtTo = strYear & "/" & strMonth & "/" & strMaxDay

                Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
                Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

                Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
                'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
                'Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
                Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

                Sc_Drs_Model.DateFrom = DtFrom
                Sc_Drs_Model.DateTo = DtTo

                Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
                Dim str As String = ""
                Dim strMaxDayCount As Integer = 0

                If Sc_Drs_Model.BranchName.Contains(",") Then
                    Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
                End If

                Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
                Dim noofrec As Integer
                noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())

                If dtDailyRevenue.Rows.Count > 1 Then
                    'If dtDailyRevenue.Rows.Count > 1 And dtSIDSales2.Rows.Count > 1 Then 'Added for Weekly Revenue Report

                    'Uncomment for june
                    'Dim tmpdirector1 As String = "c:\temp\gembox\"
                    'Try
                    '    If (Not System.IO.Directory.Exists("c:\temp\")) Then
                    '        System.IO.Directory.CreateDirectory("c:\temp\")
                    '    End If
                    '    If (Not System.IO.Directory.Exists("c:\temp\gembox\")) Then
                    '        System.IO.Directory.CreateDirectory("c:\temp\gembox\")
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    'For Each filename1 As String In Directory.EnumerateFiles(tmpdirector, "*.xlsx")
                    '    DeleteOldFiles(fileName)
                    'Next
                    'Uncomment for june

                    Dim dateAndTime As Date
                    dateAndTime = Now
                    Dim xlsFileName As String = ""
                    xlsFileName = fileName

                    ' If using Professional version, put your serial key below.
                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

                    Dim workbook

                    workbook = ExcelFile.Load(templateFileName)
                    'workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                    'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



                    If strMaxDay = "31" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "30" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
                        strMaxDayCount = -1
                    ElseIf strMaxDay = "29" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
                        'strMaxDayCount = -2
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "28" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
                        'strMaxDayCount = -3
                        strMaxDayCount = 0
                    End If


                    'Added for date 
                    If prevmonth = True Then
                        Dim worksheet3 = workbook.Worksheets(0)
                        worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
                    End If
                    ' worksheet3.cells("A3").value = strYear + " - " + DropDownList9.SelectedItem.Text
                    'worksheet3.cells("A3").value = DtTo + " - " + DropDownList9.SelectedItem.Text
                    'Added for date


                    Dim workingDays As Integer = 8

                    Dim startDate = DateTime.Now.AddDays(-workingDays)
                    Dim endDate = DateTime.Now
                    Dim worksheet = workbook.Worksheets(selectedSheet)

                    Dim worksheet1 = workbook.Worksheets(selectedSheet)
                    Dim currentRow1 = worksheet1.Rows(23)

                    Dim XlDayRow As Integer = 0
                    Dim XlDayCol As Integer = 0
                    Dim xlTargetRow As Integer = 0
                    Dim xlTargetCol As Integer = 0

                    For Each branch As String In SplitBrances
                        Dim filter As String
                        filter = "SSCNAME = " & branch
                        Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

                        Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
                        Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
                        ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

                        XlDayRow = 0
                        XlDayCol = 0
                        xlTargetRow = 0
                        xlTargetCol = 0

                        branch = branch.Replace("'", "")

                        Dim blChangeValue As Boolean = False

                        'If branch = "SSC1" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 2

                        '    XlDayRow = 24
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC2" Then
                        '    xlTargetRow = 0
                        '    xlTargetCol = 0

                        '    XlDayRow = 0
                        '    XlDayCol = 0

                        '    blChangeValue = False
                        'ElseIf branch = "SSC3" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 6

                        '    XlDayRow = 24
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC4" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 10

                        '    XlDayRow = 24
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC6" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 14

                        '    XlDayRow = 24
                        '    XlDayCol = 15

                        '    blChangeValue = True
                        'ElseIf branch = "SSC7" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 19

                        '    XlDayRow = 24
                        '    XlDayCol = 19

                        '    blChangeValue = True
                        'ElseIf branch = "SSC8" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 2

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC9" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 6

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC10" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 10

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC11" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 14

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 15

                        '    blChangeValue = True

                        'ElseIf branch = "SSC ALL" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 18

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 19

                        '    blChangeValue = True

                        'ElseIf branch = "SID1" Then

                        '    xlTargetRow = 79
                        '    xlTargetCol = 23

                        '    XlDayRow = 80 + strMaxDayCount
                        '    XlDayCol = 24

                        '    blChangeValue = False

                        'End If

                        'Added for SSC4

                        'If branch = "SSC1" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 2

                        '    XlDayRow = 24
                        '    XlDayCol = 3

                        '    blChangeValue = True 'Removed for SSC4

                        'ElseIf branch = "SSC2" Then
                        '    xlTargetRow = 0
                        '    xlTargetCol = 0

                        '    XlDayRow = 0
                        '    XlDayCol = 0

                        '    blChangeValue = False

                        'ElseIf branch = "SSC3" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 6

                        '    XlDayRow = 24
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC4" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 10

                        '    XlDayRow = 24
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC6" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 14

                        '    XlDayRow = 24
                        '    XlDayCol = 15

                        '    blChangeValue = True
                        'ElseIf branch = "SSC7" Then
                        '    xlTargetRow = 23
                        '    xlTargetCol = 18

                        '    XlDayRow = 24
                        '    XlDayCol = 19

                        '    blChangeValue = True
                        'ElseIf branch = "SSC8" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 2

                        '    ' XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 3

                        '    blChangeValue = True
                        'ElseIf branch = "SSC9" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 6

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 7

                        '    blChangeValue = True
                        'ElseIf branch = "SSC10" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 10

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 11

                        '    blChangeValue = True
                        'ElseIf branch = "SSC11" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 14

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 15

                        '    blChangeValue = True

                        'ElseIf branch = "SSC ALL" Then
                        '    xlTargetRow = 79
                        '    xlTargetCol = 18

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 19

                        '    blChangeValue = True

                        'ElseIf branch = "SID1" Then

                        '    xlTargetRow = 79
                        '    xlTargetCol = 23

                        '    'XlDayRow = 80 + strMaxDayCount
                        '    XlDayRow = 80
                        '    XlDayCol = 24

                        '    blChangeValue = False

                        'End If

                        'Removed for SSC4

                        If branch = "SSC1" Then
                            xlTargetRow = 23
                            xlTargetCol = 2

                            XlDayRow = 24
                            XlDayCol = 3

                            blChangeValue = True

                        ElseIf branch = "SSC2" Then
                            xlTargetRow = 0
                            xlTargetCol = 0

                            XlDayRow = 0
                            XlDayCol = 0

                            blChangeValue = False

                        ElseIf branch = "SSC3" Then
                            xlTargetRow = 23
                            xlTargetCol = 6

                            XlDayRow = 24
                            XlDayCol = 7

                            blChangeValue = True

                        ElseIf branch = "SSC6" Then
                            xlTargetRow = 23
                            xlTargetCol = 10

                            XlDayRow = 24
                            XlDayCol = 11

                            blChangeValue = True

                        ElseIf branch = "SSC7" Then
                            xlTargetRow = 23
                            xlTargetCol = 14

                            XlDayRow = 24
                            XlDayCol = 15

                            blChangeValue = True

                        ElseIf branch = "SSC8" Then
                            xlTargetRow = 79
                            'xlTargetRow = 80
                            xlTargetCol = 2

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 3
                            ' XlDayCol = 2

                            blChangeValue = True
                        ElseIf branch = "SSC9" Then
                            xlTargetRow = 79
                            xlTargetCol = 6

                            ' XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 7

                            blChangeValue = True
                        ElseIf branch = "SSC10" Then
                            xlTargetRow = 79
                            xlTargetCol = 10

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 11

                            blChangeValue = True
                        ElseIf branch = "SSC11" Then
                            xlTargetRow = 79
                            xlTargetCol = 14

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 15

                            blChangeValue = True

                        ElseIf branch = "SSC ALL" Then
                            xlTargetRow = 79
                            xlTargetCol = 18

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 19

                            blChangeValue = True

                        ElseIf branch = "SID1" Then

                            xlTargetRow = 79
                            xlTargetCol = 23

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 24

                            blChangeValue = False

                        End If

                        If blChangeValue Then
                            currentRow1 = worksheet1.Rows(xlTargetRow)
                            'currentRow1.Cells(xlTargetCol).SetValue(12345)
                            If dtSIDSales2.Rows.Count > 0 Then
                                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
                                targetAmount1 = 0 'Added for Weekly Revenue Report
                                For Each dtSIDSales2Row As DataRow In result
                                    targetAmount1 = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
                                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                                Next
                            End If
                            currentRow1.Cells(xlTargetCol).SetValue(targetAmount1)

                            Dim _XlDayRow As Integer = XlDayRow
                            Dim _XlDayCol As Integer = 0
                            Dim SscSalesAmount As Decimal

                            For Each row As DataRow In tabresult
                                'row(0)
                                ' SscSalesAmount = row(4)
                                SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for weekly Revenue Report
                                currentRow1 = worksheet1.Rows(_XlDayRow)
                                currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

                                _XlDayRow = _XlDayRow + 1

                            Next
                        End If

                    Next


                    Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTracking(strYear, strMonth)


                    xlTargetRow = 79
                    xlTargetCol = 23

                    'XlDayRow = 80 + strMaxDayCount
                    XlDayRow = 80
                    XlDayCol = 24

                    Dim _XlDayRow2 As Integer = 0
                    _XlDayRow2 = XlDayRow
                    Dim _XlDayCol2 As Integer = 0

                    If dtSIDSales2.Rows.Count > 0 Then
                        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
                        For Each dtSIDSales2Row As DataRow In result
                            targetAmount1 = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
                            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                        Next
                    End If
                    currentRow1 = worksheet1.Rows(xlTargetRow)
                    'currentRow1.Cells(xlTargetCol).SetValue(12345)
                    currentRow1.Cells(xlTargetCol).SetValue(targetAmount1) 'tagtDayAmt


                    Dim SalesAmount As Decimal
                    'For Each row As DataRow In dtSIDSales
                    For Each row As DataRow In dtSIDSales1.Rows
                        'row(0)
                        currentRow1 = worksheet1.Rows(_XlDayRow2)
                        'SalesAmount = row(1)
                        SalesAmount = Convert.ToDecimal(row(1)) 'Added for Weekly Revenue Report
                        currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

                        _XlDayRow2 = _XlDayRow2 + 1
                    Next

                    worksheet1.Calculate()



                    workbook.Save(tmpDirector & xlsFileName & ".xlsx")


                    'Response.Clear()
                    'Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirector & xlsFileName & ".xlsx"))
                    'Response.ContentType = "application/vnd.ms-excel"
                    ''Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    'Response.WriteFile(tmpDirector & xlsFileName & ".xlsx")
                    'Response.End()

                End If
            End If

        End If



    End Sub

    Protected Sub ImageButton7_Click(sender As Object, e As EventArgs) Handles ImageButton7.Click

        'Added for 3rd graph

        If (DropDownList9.SelectedItem.Text = "") Or (DropDownList9.SelectedItem.Value = "0") Then
            Call showMsg("Please Select the month", "")
            Exit Sub
        End If

        Dim selectedYear As String
        Dim selectedMonth As String
        Dim strMaxDay As String = ""
        Dim DtFrom As String = ""
        Dim DtTo As String = ""
        Dim strYear As String = DropDownList10.SelectedItem.Text
        Dim strMonth As String = DropDownList9.SelectedItem.Value
        Dim xlsFileName As String
        Dim tmpFileName As String
        Dim tmpDirectory As String

        If Len(strMonth) = 1 Then
            strMonth = "0" & strMonth
        End If

        strMaxDay = Date.DaysInMonth(strYear, strMonth)
        Dim _SalesControl1 As SalesControl = New SalesControl()
        Dim dtSIDSales2 As DataTable = _SalesControl1.SelectTargetSales(strYear, strMonth)
        ' Dim targetAmount As Decimal
        'Add for Weekly Revenue Report
        If (dtSIDSales2.Rows.Count > 0 Or dtSIDSales2.Rows.Count = 0) Then

            Dim SSC1 As String

            Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")

            If (exists = False And exists2 = False) Then
                ' exists = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
                exists2 = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
                SSC1 += "SSC2,"
            End If

            ' Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            'Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
            Dim exists3 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC3")
            'Dim exists4 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC4")
            Dim exists5 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC6")
            Dim exists6 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC7")
            Dim exists7 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC8")
            Dim exists8 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC9")
            Dim exists9 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC10")
            Dim exists10 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC11")
            Dim exists11 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SID1")


            'If exists = False Then
            'SSC1 = "SSC1,"

            'End If

            'If exists2 = False Then
            'SSC1 += "SSC2,"

            'End If

            If exists3 = False Then
                SSC1 += "SSC3,"

            End If

            'If exists4 = False Then
            'SSC1 += "SSC4,"

            'End If
            If exists5 = False Then
                SSC1 += "SSC6,"

            End If
            If exists6 = False Then
                SSC1 += "SSC7,"

            End If
            If exists7 = False Then
                SSC1 += "SSC8,"

            End If
            If exists8 = False Then
                SSC1 += "SSC9,"

            End If
            If exists9 = False Then
                SSC1 += "SSC10,"

            End If
            If exists10 = False Then
                SSC1 += "SSC11,"
            End If
            If exists11 = False Then
                SSC1 += "SID1,"
            End If

            Dim Flag As Boolean = True
            If Not String.IsNullOrEmpty(SSC1) Then

                Dim BtnCancelChk As String = ""
                Dim BtnOK2Chk As String = ""
                Call showMsg("Target Amount is not available for ('" & SSC1 & "'). Do you want to continue, it is ok?", "CancelMsg2")
                Exit Sub
            Else
                'Btn2OK(Null, Null)
                genericreport()
            End If

            ' imagebutton71(strYear, strMonth, 1, xlsFileName, tmpFileName, tmpDirectory)

            'Dim currentDate As DateTime = DateTime.Parse(strMonth + "/1/" + strYear)
            'Dim previousDate As DateTime = currentDate.AddMonths(-1)
            'If (File.Exists(tmpDirectory & xlsFileName & ".xlsx")) Then
            '    tmpFileName = tmpDirectory & xlsFileName & ".xlsx"
            'End If

            'imagebutton71(previousDate.Year, previousDate.Month, 2, xlsFileName, tmpFileName, tmpDirectory)
        End If

        'End for 3rd graph

        'Add

        'If (DropDownList9.SelectedItem.Text = "") Or (DropDownList9.SelectedItem.Value = "0") Then
        '    Call showMsg("Please Select the month", "")
        '    Exit Sub
        'End If

        'Dim tmpDirectory As String = "C:\temp\gembox\"
        'Try
        '    If (Not System.IO.Directory.Exists("C:\temp\")) Then
        '        System.IO.Directory.CreateDirectory("C:\temp\")
        '    End If
        '    If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
        '        System.IO.Directory.CreateDirectory("C:\temp\gembox\")
        '    End If
        'Catch ex As Exception
        'End Try
        'For Each fileName As String In Directory.EnumerateFiles(tmpDirectory, "*.xlsx")
        '    DeleteOldFiles(fileName)
        'Next
        'Dim xlsFileName As String = "Weekly" & Format(DateTime.Now, "yyyyMMddHHmmss").ToString
        ''Dim tmpDirector As String = "C:\temp\gembox\"
        'Dim tmpFileName As String = "C:\temp\wk31.xlsx"
        'Dim strYear As String = DropDownList10.SelectedItem.Text
        'Dim strMonth As String = DropDownList9.SelectedItem.Value
        'Dim strMaxDay As String = Date.DaysInMonth(strYear, strMonth)
        ''If strMaxDay = "31" Then
        ''    tmpFileName = "C:\temp\wk31.xlsx"
        ''    'strMaxDayCount = 0
        ''ElseIf strMaxDay = "30" Then
        ''    tmpFileName = "C:\temp\wk30.xlsx"
        ''    'strMaxDayCount = -1
        ''ElseIf strMaxDay = "29" Then
        ''    tmpFileName = "C:\temp\wk29.xlsx"
        ''    'strMaxDayCount = -2
        ''    'strMaxDayCount = 0
        ''ElseIf strMaxDay = "28" Then
        ''    tmpFileName = "C:\temp\wk28.xlsx"
        ''    'strMaxDayCount = -3
        ''    'strMaxDayCount = 0
        ''End If
        'imagebutton71(strYear, strMonth, 1, xlsFileName, tmpFileName, tmpDirectory)

        'Dim currentDate As DateTime = DateTime.Parse(strMonth + "/1/" + strYear)
        'Dim previousDate As DateTime = currentDate.AddMonths(-1)
        'If (File.Exists(tmpDirectory & xlsFileName & ".xlsx")) Then
        '    tmpFileName = tmpDirectory & xlsFileName & ".xlsx"
        'End If

        'imagebutton71(previousDate.Year, previousDate.Month, 2, xlsFileName, tmpFileName, tmpDirectory)

        'Response.Clear()
        'Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirectory & xlsFileName & ".xlsx"))
        'Response.ContentType = "application/vnd.ms-excel"
        ''Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        'Response.WriteFile(tmpDirectory & xlsFileName & ".xlsx")
        'Response.End()

        'End


        ''public not empty
        ''call dialog


        'Dim strMaxDay As String = ""
        'Dim DtFrom As String = ""
        'Dim DtTo As String = ""
        'Dim strYear As String = DropDownList10.SelectedItem.Text
        'Dim strMonth As String = DropDownList9.SelectedItem.Value

        'If Len(strMonth) = 1 Then
        '    strMonth = "0" & strMonth
        'End If

        'strMaxDay = Date.DaysInMonth(strYear, strMonth)
        'Dim _SalesControl1 As SalesControl = New SalesControl()
        'Dim dtSIDSales2 As DataTable = _SalesControl1.SelectTargetSales(strYear, strMonth)
        'Dim targetAmount As Decimal
        ''Add for Weekly Revenue Report
        'If (dtSIDSales2.Rows.Count > 0 Or dtSIDSales2.Rows.Count = 0) Then

        '    Dim SSC1 As String

        '    Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
        '    Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")

        '    If (exists = False And exists2 = False) Then
        '        ' exists = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
        '        exists2 = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
        '        SSC1 += "SSC2,"
        '    End If

        '    ' Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
        '    'Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
        '    Dim exists3 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC3")
        '    'Dim exists4 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC4")
        '    Dim exists5 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC6")
        '    Dim exists6 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC7")
        '    Dim exists7 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC8")
        '    Dim exists8 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC9")
        '    Dim exists9 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC10")
        '    Dim exists10 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC11")
        '    Dim exists11 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SID1")


        '    'If exists = False Then
        '    'SSC1 = "SSC1,"

        '    'End If

        '    'If exists2 = False Then
        '    'SSC1 += "SSC2,"

        '    'End If

        '    If exists3 = False Then
        '        SSC1 += "SSC3,"

        '    End If

        '    'If exists4 = False Then
        '    'SSC1 += "SSC4,"

        '    'End If
        '    If exists5 = False Then
        '        SSC1 += "SSC6,"

        '    End If
        '    If exists6 = False Then
        '        SSC1 += "SSC7,"

        '    End If
        '    If exists7 = False Then
        '        SSC1 += "SSC8,"

        '    End If
        '    If exists8 = False Then
        '        SSC1 += "SSC9,"

        '    End If
        '    If exists9 = False Then
        '        SSC1 += "SSC10,"

        '    End If
        '    If exists10 = False Then
        '        SSC1 += "SSC11,"
        '    End If
        '    If exists11 = False Then
        '        SSC1 += "SID1,"
        '    End If

        '    Dim Flag As Boolean = True
        '    If Not String.IsNullOrEmpty(SSC1) Then

        '        Dim BtnCancelChk As String = ""
        '        Dim BtnOK2Chk As String = ""
        '        Call showMsg("Target Amount is not available for ('" & SSC1 & "'). Do you want to continue, it is ok?", "CancelMsg2")
        '        Exit Sub
        '        Flag = False


        '        DtFrom = strYear & "/" & strMonth & "/" & "01"
        '        DtTo = strYear & "/" & strMonth & "/" & strMaxDay

        '        Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
        '        Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

        '        Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
        '        'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
        '        'Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
        '        Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

        '        Sc_Drs_Model.DateFrom = DtFrom
        '        Sc_Drs_Model.DateTo = DtTo

        '        Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
        '        Dim str As String = ""
        '        Dim strMaxDayCount As Integer = 0

        '        If Sc_Drs_Model.BranchName.Contains(",") Then
        '            Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
        '        End If

        '        Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
        '        Dim noofrec As Integer
        '        noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())

        '        If dtDailyRevenue.Rows.Count > 1 Then

        '            Dim tmpDirector As String = "C:\temp\gembox\"
        '            Try
        '                If (Not System.IO.Directory.Exists("C:\temp\")) Then
        '                    System.IO.Directory.CreateDirectory("C:\temp\")
        '                End If
        '                If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
        '                    System.IO.Directory.CreateDirectory("C:\temp\gembox\")
        '                End If
        '            Catch ex As Exception
        '            End Try
        '            For Each fileName As String In Directory.EnumerateFiles(tmpDirector, "*.xlsx")
        '                DeleteOldFiles(fileName)
        '            Next

        '            Dim dateAndTime As Date
        '            dateAndTime = Now
        '            Dim xlsFileName As String = ""
        '            xlsFileName = "Weekly" & Format(dateAndTime, "yyyyMMddHHmmss").ToString

        '            ' If using Professional version, put your serial key below.
        '            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

        '            Dim workbook

        '            workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
        '            'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



        '            If strMaxDay = "31" Then
        '                workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
        '                strMaxDayCount = 0
        '            ElseIf strMaxDay = "30" Then
        '                workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
        '                strMaxDayCount = -1
        '            ElseIf strMaxDay = "29" Then
        '                workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
        '                'strMaxDayCount = -2
        '                strMaxDayCount = 0
        '            ElseIf strMaxDay = "28" Then
        '                workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
        '                'strMaxDayCount = -3
        '                strMaxDayCount = 0
        '            End If


        '            Dim workingDays As Integer = 8

        '            Dim startDate = DateTime.Now.AddDays(-workingDays)
        '            Dim endDate = DateTime.Now
        '            Dim worksheet = workbook.Worksheets(1)

        '            Dim worksheet1 = workbook.Worksheets(1)
        '            Dim currentRow1 = worksheet1.Rows(23)

        '            Dim XlDayRow As Integer = 0
        '            Dim XlDayCol As Integer = 0
        '            Dim xlTargetRow As Integer = 0
        '            Dim xlTargetCol As Integer = 0

        '            For Each branch As String In SplitBrances
        '                Dim filter As String
        '                filter = "SSCNAME = " & branch
        '                Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

        '                Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
        '                Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
        '                ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

        '                XlDayRow = 0
        '                XlDayCol = 0
        '                xlTargetRow = 0
        '                xlTargetCol = 0

        '                branch = branch.Replace("'", "")

        '                Dim blChangeValue As Boolean = False

        '                'If branch = "SSC1" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 2

        '                '    XlDayRow = 24
        '                '    XlDayCol = 3

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC2" Then
        '                '    xlTargetRow = 0
        '                '    xlTargetCol = 0

        '                '    XlDayRow = 0
        '                '    XlDayCol = 0

        '                '    blChangeValue = False
        '                'ElseIf branch = "SSC3" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 6

        '                '    XlDayRow = 24
        '                '    XlDayCol = 7

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC4" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 10

        '                '    XlDayRow = 24
        '                '    XlDayCol = 11

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC6" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 14

        '                '    XlDayRow = 24
        '                '    XlDayCol = 15

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC7" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 19

        '                '    XlDayRow = 24
        '                '    XlDayCol = 19

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC8" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 2

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 3

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC9" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 6

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 7

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC10" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 10

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 11

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC11" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 14

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 15

        '                '    blChangeValue = True

        '                'ElseIf branch = "SSC ALL" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 18

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 19

        '                '    blChangeValue = True

        '                'ElseIf branch = "SID1" Then

        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 23

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 24

        '                '    blChangeValue = False

        '                'End If

        '                'Added for SSC4 Service center
        '                'If branch = "SSC1" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 2

        '                '    XlDayRow = 24
        '                '    XlDayCol = 3

        '                '    blChangeValue = True 'Removed for SSC4

        '                'ElseIf branch = "SSC2" Then
        '                '    xlTargetRow = 0
        '                '    xlTargetCol = 0

        '                '    XlDayRow = 0
        '                '    XlDayCol = 0

        '                '    blChangeValue = False

        '                'ElseIf branch = "SSC3" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 6

        '                '    XlDayRow = 24
        '                '    XlDayCol = 7

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC4" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 10

        '                '    XlDayRow = 24
        '                '    XlDayCol = 11

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC6" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 14

        '                '    XlDayRow = 24
        '                '    XlDayCol = 15

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC7" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 18

        '                '    XlDayRow = 24
        '                '    XlDayCol = 19

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC8" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 2

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 3

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC9" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 6

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 7

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC10" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 10

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 11

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC11" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 14

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 15

        '                '    blChangeValue = True

        '                'ElseIf branch = "SSC ALL" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 18

        '                '    ' XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 19

        '                '    blChangeValue = True

        '                'ElseIf branch = "SID1" Then

        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 23

        '                '    ' XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 24

        '                '    blChangeValue = False

        '                'End If

        '                'Removed for SSC4 Service center

        '                If branch = "SSC1" Then
        '                    xlTargetRow = 23
        '                    xlTargetCol = 2

        '                    XlDayRow = 24
        '                    XlDayCol = 3

        '                    blChangeValue = True

        '                ElseIf branch = "SSC2" Then
        '                    xlTargetRow = 0
        '                    xlTargetCol = 0

        '                    XlDayRow = 0
        '                    XlDayCol = 0

        '                    blChangeValue = False

        '                ElseIf branch = "SSC3" Then
        '                    xlTargetRow = 23
        '                    xlTargetCol = 6

        '                    XlDayRow = 24
        '                    XlDayCol = 7

        '                    blChangeValue = True

        '                ElseIf branch = "SSC6" Then
        '                    xlTargetRow = 23
        '                    xlTargetCol = 10

        '                    XlDayRow = 24
        '                    XlDayCol = 11

        '                    blChangeValue = True

        '                ElseIf branch = "SSC7" Then
        '                    xlTargetRow = 23
        '                    xlTargetCol = 14

        '                    XlDayRow = 24
        '                    XlDayCol = 15

        '                    blChangeValue = True

        '                ElseIf branch = "SSC8" Then
        '                    xlTargetRow = 79
        '                    'xlTargetRow = 80
        '                    xlTargetCol = 2

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 3
        '                    'XlDayCol = 2

        '                    blChangeValue = True
        '                ElseIf branch = "SSC9" Then
        '                    xlTargetRow = 79
        '                    xlTargetCol = 6

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 7

        '                    blChangeValue = True
        '                ElseIf branch = "SSC10" Then
        '                    xlTargetRow = 79
        '                    xlTargetCol = 10

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 11

        '                    blChangeValue = True
        '                ElseIf branch = "SSC11" Then
        '                    xlTargetRow = 79
        '                    xlTargetCol = 14

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 15

        '                    blChangeValue = True

        '                ElseIf branch = "SSC ALL" Then
        '                    xlTargetRow = 79
        '                    xlTargetCol = 18

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 19

        '                    blChangeValue = True

        '                ElseIf branch = "SID1" Then

        '                    xlTargetRow = 79
        '                    xlTargetCol = 23

        '                    ' XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 24

        '                    blChangeValue = False

        '                End If



        '                If blChangeValue Then
        '                    currentRow1 = worksheet1.Rows(xlTargetRow)
        '                    'currentRow1.Cells(xlTargetCol).SetValue(12345)
        '                    If dtSIDSales2.Rows.Count > 0 Then
        '                        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
        '                        targetAmount = 0 'Added for Weekly Revenue Report
        '                        For Each dtSIDSales2Row As DataRow In result
        '                            targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
        '                            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
        '                        Next
        '                    End If
        '                    currentRow1.Cells(xlTargetCol).SetValue(targetAmount)

        '                    Dim _XlDayRow As Integer = XlDayRow
        '                    Dim _XlDayCol As Integer = 0
        '                    Dim SscSalesAmount As Decimal

        '                    For Each row As DataRow In tabresult
        '                        'row(0)
        '                        'SscSalesAmount = row(4)
        '                        SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for weekly Revenue Report
        '                        currentRow1 = worksheet1.Rows(_XlDayRow)
        '                        currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

        '                        _XlDayRow = _XlDayRow + 1

        '                    Next
        '                End If

        '            Next


        '            Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTracking(strYear, strMonth)


        '            xlTargetRow = 79
        '            xlTargetCol = 23

        '            ' XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 24

        '            Dim _XlDayRow2 As Integer = 0
        '            _XlDayRow2 = XlDayRow
        '            Dim _XlDayCol2 As Integer = 0

        '            If dtSIDSales2.Rows.Count > 0 Then
        '                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
        '                For Each dtSIDSales2Row As DataRow In result
        '                    targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
        '                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
        '                Next
        '            End If
        '            currentRow1 = worksheet1.Rows(xlTargetRow)
        '            'currentRow1.Cells(xlTargetCol).SetValue(12345)
        '            currentRow1.Cells(xlTargetCol).SetValue(targetAmount) 'tagtDayAmt


        '            Dim SalesAmount As Decimal
        '            'For Each row As DataRow In dtSIDSales
        '            For Each row As DataRow In dtSIDSales1.Rows
        '                'row(0)
        '                currentRow1 = worksheet1.Rows(_XlDayRow2)
        '                'SalesAmount = row(1)
        '                SalesAmount = Convert.ToDecimal(row(1)) 'Added for Weekly Revenue Report
        '                currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

        '                _XlDayRow2 = _XlDayRow2 + 1
        '            Next





        '            worksheet1.Calculate()



        '            workbook.Save(tmpDirector & xlsFileName & ".xlsx")


        '            Response.Clear()
        '            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirector & xlsFileName & ".xlsx"))
        '            Response.ContentType = "application/vnd.ms-excel"
        '            'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        '            Response.WriteFile(tmpDirector & xlsFileName & ".xlsx")
        '            Response.End()

        '        End If
        '    End If
        '    'End for Weekly Revenue Report
        '    If Flag = True Then 'Add for Weekly Revenue Report


        '        Dim targetAmount1 As Decimal

        '        DtFrom = strYear & "/" & strMonth & "/" & "01"
        '        DtTo = strYear & "/" & strMonth & "/" & strMaxDay

        '        Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
        '        Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

        '        Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
        '        'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
        '        'Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
        '        Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

        '        Sc_Drs_Model.DateFrom = DtFrom
        '        Sc_Drs_Model.DateTo = DtTo

        '        Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
        '        Dim str As String = ""
        '        Dim strMaxDayCount As Integer = 0

        '        If Sc_Drs_Model.BranchName.Contains(",") Then
        '            Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
        '        End If

        '        Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
        '        Dim noofrec As Integer
        '        noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())

        '        If dtDailyRevenue.Rows.Count > 1 Then
        '            'If dtDailyRevenue.Rows.Count > 1 And dtSIDSales2.Rows.Count > 1 Then 'Added for Weekly Revenue Report

        '            Dim tmpDirector As String = "C:\temp\gembox\"
        '            Try
        '                If (Not System.IO.Directory.Exists("C:\temp\")) Then
        '                    System.IO.Directory.CreateDirectory("C:\temp\")
        '                End If
        '                If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
        '                    System.IO.Directory.CreateDirectory("C:\temp\gembox\")
        '                End If
        '            Catch ex As Exception
        '            End Try
        '            For Each fileName As String In Directory.EnumerateFiles(tmpDirector, "*.xlsx")
        '                DeleteOldFiles(fileName)
        '            Next

        '            Dim dateAndTime As Date
        '            dateAndTime = Now
        '            Dim xlsFileName As String = ""
        '            xlsFileName = "Weekly" & Format(dateAndTime, "yyyyMMddHHmmss").ToString

        '            ' If using Professional version, put your serial key below.
        '            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

        '            Dim workbook

        '            workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
        '            'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



        '            If strMaxDay = "31" Then
        '                workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
        '                strMaxDayCount = 0
        '            ElseIf strMaxDay = "30" Then
        '                workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
        '                strMaxDayCount = -1
        '            ElseIf strMaxDay = "29" Then
        '                workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
        '                'strMaxDayCount = -2
        '                strMaxDayCount = 0
        '            ElseIf strMaxDay = "28" Then
        '                workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
        '                'strMaxDayCount = -3
        '                strMaxDayCount = 0
        '            End If


        '            Dim workingDays As Integer = 8

        '            Dim startDate = DateTime.Now.AddDays(-workingDays)
        '            Dim endDate = DateTime.Now
        '            Dim worksheet = workbook.Worksheets(1)

        '            Dim worksheet1 = workbook.Worksheets(1)
        '            Dim currentRow1 = worksheet1.Rows(23)

        '            Dim XlDayRow As Integer = 0
        '            Dim XlDayCol As Integer = 0
        '            Dim xlTargetRow As Integer = 0
        '            Dim xlTargetCol As Integer = 0

        '            For Each branch As String In SplitBrances
        '                Dim filter As String
        '                filter = "SSCNAME = " & branch
        '                Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

        '                Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
        '                Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
        '                ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

        '                XlDayRow = 0
        '                XlDayCol = 0
        '                xlTargetRow = 0
        '                xlTargetCol = 0

        '                branch = branch.Replace("'", "")

        '                Dim blChangeValue As Boolean = False

        '                'If branch = "SSC1" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 2

        '                '    XlDayRow = 24
        '                '    XlDayCol = 3

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC2" Then
        '                '    xlTargetRow = 0
        '                '    xlTargetCol = 0

        '                '    XlDayRow = 0
        '                '    XlDayCol = 0

        '                '    blChangeValue = False
        '                'ElseIf branch = "SSC3" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 6

        '                '    XlDayRow = 24
        '                '    XlDayCol = 7

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC4" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 10

        '                '    XlDayRow = 24
        '                '    XlDayCol = 11

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC6" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 14

        '                '    XlDayRow = 24
        '                '    XlDayCol = 15

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC7" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 19

        '                '    XlDayRow = 24
        '                '    XlDayCol = 19

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC8" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 2

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 3

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC9" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 6

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 7

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC10" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 10

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 11

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC11" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 14

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 15

        '                '    blChangeValue = True

        '                'ElseIf branch = "SSC ALL" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 18

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 19

        '                '    blChangeValue = True

        '                'ElseIf branch = "SID1" Then

        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 23

        '                '    XlDayRow = 80 + strMaxDayCount
        '                '    XlDayCol = 24

        '                '    blChangeValue = False

        '                'End If

        '                'Added for SSC4

        '                'If branch = "SSC1" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 2

        '                '    XlDayRow = 24
        '                '    XlDayCol = 3

        '                '    blChangeValue = True 'Removed for SSC4

        '                'ElseIf branch = "SSC2" Then
        '                '    xlTargetRow = 0
        '                '    xlTargetCol = 0

        '                '    XlDayRow = 0
        '                '    XlDayCol = 0

        '                '    blChangeValue = False

        '                'ElseIf branch = "SSC3" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 6

        '                '    XlDayRow = 24
        '                '    XlDayCol = 7

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC4" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 10

        '                '    XlDayRow = 24
        '                '    XlDayCol = 11

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC6" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 14

        '                '    XlDayRow = 24
        '                '    XlDayCol = 15

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC7" Then
        '                '    xlTargetRow = 23
        '                '    xlTargetCol = 18

        '                '    XlDayRow = 24
        '                '    XlDayCol = 19

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC8" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 2

        '                '    ' XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 3

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC9" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 6

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 7

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC10" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 10

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 11

        '                '    blChangeValue = True
        '                'ElseIf branch = "SSC11" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 14

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 15

        '                '    blChangeValue = True

        '                'ElseIf branch = "SSC ALL" Then
        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 18

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 19

        '                '    blChangeValue = True

        '                'ElseIf branch = "SID1" Then

        '                '    xlTargetRow = 79
        '                '    xlTargetCol = 23

        '                '    'XlDayRow = 80 + strMaxDayCount
        '                '    XlDayRow = 80
        '                '    XlDayCol = 24

        '                '    blChangeValue = False

        '                'End If

        '                'Removed for SSC4

        '                If branch = "SSC1" Then
        '                    xlTargetRow = 23
        '                    xlTargetCol = 2

        '                    XlDayRow = 24
        '                    XlDayCol = 3

        '                    blChangeValue = True

        '                ElseIf branch = "SSC2" Then
        '                    xlTargetRow = 0
        '                    xlTargetCol = 0

        '                    XlDayRow = 0
        '                    XlDayCol = 0

        '                    blChangeValue = False

        '                ElseIf branch = "SSC3" Then
        '                    xlTargetRow = 23
        '                    xlTargetCol = 6

        '                    XlDayRow = 24
        '                    XlDayCol = 7

        '                    blChangeValue = True

        '                ElseIf branch = "SSC6" Then
        '                    xlTargetRow = 23
        '                    xlTargetCol = 10

        '                    XlDayRow = 24
        '                    XlDayCol = 11

        '                    blChangeValue = True

        '                ElseIf branch = "SSC7" Then
        '                    xlTargetRow = 23
        '                    xlTargetCol = 14

        '                    XlDayRow = 24
        '                    XlDayCol = 15

        '                    blChangeValue = True

        '                ElseIf branch = "SSC8" Then
        '                    xlTargetRow = 79
        '                    'xlTargetRow = 80
        '                    xlTargetCol = 2

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 3
        '                    ' XlDayCol = 2

        '                    blChangeValue = True
        '                ElseIf branch = "SSC9" Then
        '                    xlTargetRow = 79
        '                    xlTargetCol = 6

        '                    ' XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 7

        '                    blChangeValue = True
        '                ElseIf branch = "SSC10" Then
        '                    xlTargetRow = 79
        '                    xlTargetCol = 10

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 11

        '                    blChangeValue = True
        '                ElseIf branch = "SSC11" Then
        '                    xlTargetRow = 79
        '                    xlTargetCol = 14

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 15

        '                    blChangeValue = True

        '                ElseIf branch = "SSC ALL" Then
        '                    xlTargetRow = 79
        '                    xlTargetCol = 18

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 19

        '                    blChangeValue = True

        '                ElseIf branch = "SID1" Then

        '                    xlTargetRow = 79
        '                    xlTargetCol = 23

        '                    'XlDayRow = 80 + strMaxDayCount
        '                    XlDayRow = 80
        '                    XlDayCol = 24

        '                    blChangeValue = False

        '                End If

        '                If blChangeValue Then
        '                    currentRow1 = worksheet1.Rows(xlTargetRow)
        '                    'currentRow1.Cells(xlTargetCol).SetValue(12345)
        '                    If dtSIDSales2.Rows.Count > 0 Then
        '                        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
        '                        targetAmount1 = 0 'Added for Weekly Revenue Report
        '                        For Each dtSIDSales2Row As DataRow In result
        '                            targetAmount1 = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
        '                            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
        '                        Next
        '                    End If
        '                    currentRow1.Cells(xlTargetCol).SetValue(targetAmount1)

        '                    Dim _XlDayRow As Integer = XlDayRow
        '                    Dim _XlDayCol As Integer = 0
        '                    Dim SscSalesAmount As Decimal

        '                    For Each row As DataRow In tabresult
        '                        'row(0)
        '                        'SscSalesAmount = row(4)
        '                        SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for weekly Revenue Report
        '                        currentRow1 = worksheet1.Rows(_XlDayRow)
        '                        currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

        '                        _XlDayRow = _XlDayRow + 1

        '                    Next
        '                End If

        '            Next


        '            Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTracking(strYear, strMonth)


        '            xlTargetRow = 79
        '            xlTargetCol = 23

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 24

        '            Dim _XlDayRow2 As Integer = 0
        '            _XlDayRow2 = XlDayRow
        '            Dim _XlDayCol2 As Integer = 0

        '            If dtSIDSales2.Rows.Count > 0 Then
        '                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
        '                For Each dtSIDSales2Row As DataRow In result
        '                    targetAmount1 = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
        '                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
        '                Next
        '            End If
        '            currentRow1 = worksheet1.Rows(xlTargetRow)
        '            'currentRow1.Cells(xlTargetCol).SetValue(12345)
        '            currentRow1.Cells(xlTargetCol).SetValue(targetAmount1) 'tagtDayAmt


        '            Dim SalesAmount As Decimal
        '            'For Each row As DataRow In dtSIDSales
        '            For Each row As DataRow In dtSIDSales1.Rows
        '                'row(0)
        '                currentRow1 = worksheet1.Rows(_XlDayRow2)
        '                'SalesAmount = row(1)
        '                SalesAmount = Convert.ToDecimal(row(1)) 'Added for Weekly Revenue Report
        '                currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

        '                _XlDayRow2 = _XlDayRow2 + 1
        '            Next

        '            worksheet1.Calculate()

        '            workbook.Save(tmpDirector & xlsFileName & ".xlsx")


        '            Response.Clear()
        '            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirector & xlsFileName & ".xlsx"))
        '            Response.ContentType = "application/vnd.ms-excel"
        '            'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        '            Response.WriteFile(tmpDirector & xlsFileName & ".xlsx")
        '            Response.End()

        '        End If
        '    End If

        'End If
    End Sub

    Protected Sub ImageButton6_Click(sender As Object, e As EventArgs) Handles ImageButton6.Click 'Added for Weekly Revenue Report
        If DropdownList7.SelectedItem.Text = "Select" Then
            Call showMsg("Please Select SSC", "")
            Exit Sub
        ElseIf DropDownMonth2.SelectedItem.Text = "Select" Then
            Call showMsg("Please Select the month", "")
            'targetamtbox.Text = "0.00"
            'targetcallload.Text = "0.00"
            Exit Sub
        ElseIf DropDownYear2.SelectedItem.Text = "Select" Then
            Call showMsg("Please Select the Year", "")
            Exit Sub

        ElseIf targetamtbox.Text = "" And targetcallload.Text = "" Then
            '    Call showMsg("Please Enter The CallLoad Count", "")

            'targetcallload.Text = "0.00"
            'Exit Sub
            If targetamtbox.Text = "" Then
                targetamtbox.Text = ""
            End If
            If targetcallload.Text = "" Then
                targetcallload.Text = ""
            End If

            ' ElseIf String.IsNullOrEmpty(targetamtbox.Text) = False OrElse String.IsNullOrEmpty(targetcallload.Text) = False Then
            Call showMsg("Please Enter The Target Amount Or Target CallLoad Count", "")


            Exit Sub

        ElseIf targetamtbox.Text = "" Or targetcallload.Text = "" Then

            If targetcallload.Text = "" Then
                targetcallload.Text = ""
            End If

            If targetamtbox.Text = "" Then
                targetamtbox.Text = ""
            End If


            ' ElseIf targetcallload.Text = "" Then
            '    Call showMsg("Please Enter The CallLoad Count", "")
            ' targetcallload.Text = "0.00"
            '    Exit Sub
        End If



        Dim targetday As String
        Dim targetdaycount As String 'Call load
        If (DropDownMonth2.SelectedItem.Value = 4 Or 6 Or 9 Or 11) Then
            If targetamtbox.Text <> "" Then
                targetday = targetamtbox.Text / 30
            End If
            If targetcallload.Text <> "" Then
                targetdaycount = targetcallload.Text / 30
            End If


        ElseIf (DropDownMonth2.SelectedItem.Value = 2) Then
            If (DropDownYear2.SelectedItem.Value Mod 4 = 0) Then
                If targetamtbox.Text <> "" Then
                    targetday = targetamtbox.Text / 29
                End If
                If targetcallload.Text <> "" Then
                    targetdaycount = targetcallload.Text / 29
                End If
            Else
                If targetamtbox.Text <> "" Then
                    targetday = targetamtbox.Text / 28
                End If
                If targetcallload.Text <> "" Then
                    targetdaycount = targetcallload.Text / 28
                End If
            End If
        Else
            If targetamtbox.Text <> "" Then
                targetday = targetamtbox.Text / 31
            End If
            If targetcallload.Text <> "" Then
                targetdaycount = targetcallload.Text / 31
            End If
        End If
            Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
        Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()

        _Monthlytargetmodel.UPDPG = "Class_Store.vb"
        _Monthlytargetmodel.SHIP_TO_BRANCH_CODE = DropdownList7.SelectedItem.Value
        _Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
        _Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedItem.Value
        _Monthlytargetmodel.TARGET_MONTH_AMOUNT = targetamtbox.Text
        _Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Value
        _Monthlytargetmodel.TARGET_DAY_AMOUNT = targetday
        _Monthlytargetmodel.TARGET_CALLLOAD_COUNT = targetcallload.Text 'CALL LOAD
        _Monthlytargetmodel.TARGET_DAY_COUNT = targetdaycount 'CALL LOAD
        _Monthlytargetmodel.UserId = Session("user_id").ToString

        Dim isInserted As Boolean = _MonthlyTargetControll.MonthlytargetInsert(_Monthlytargetmodel)
        If (isInserted = True) Then
            Call showMsg("Successfully saved in " & DropdownList7.SelectedItem.Text, "")
        Else
            Call showMsg("Already Saved in " & DropdownList7.SelectedItem.Text, "")
        End If

        'DropdownList7.Text = "Select"
        'DropDownMonth2.Text = "0"

        targetamtbox.Text = ""
        targetcallload.Text = "" 'Call load



        Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.ShowMonthlytargetGrid(_Monthlytargetmodel)

        dtDisplaymonthlytarget = dtDisplaymonthlytarget.DefaultView.ToTable()
        If Not dtDisplaymonthlytarget Is Nothing Then
            If dtDisplaymonthlytarget.Rows.Count > 0 Then
                txtPageSize1.Visible = True
                lblPagesize1.Visible = True
                txtPageSize1.Text = 10
                gvMonthlytarget.PageSize = Convert.ToInt16(txtPageSize1.Text)
                gvMonthlytarget.Visible = True
                gvMonthlytarget.AllowSorting = True
                gvMonthlytarget.PageIndex = 0
                gvMonthlytarget.DataSource = dtDisplaymonthlytarget
                gvMonthlytarget.DataBind()

                'btnExport.Visible = True
                'lblErrorMessage.Visible = True
                lblErrorMessage1.Visible = False
                lbltotal.Text = "Total No of Records : " & dtDisplaymonthlytarget.Rows.Count
                'lblTitle.Text = drpTaskExport.SelectedItem.Text
            Else
                gvMonthlytarget.AllowSorting = False
                gvMonthlytarget.DataBind()
                gvMonthlytarget.Visible = False
                lblErrorMessage1.Visible = False
                'btnExport.Visible = False
                txtPageSize1.Visible = False
                lblPagesize1.Visible = False
            End If
        End If

    End Sub 'End for Weekly Revenue Report

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click 'Added for Weekly Revenue Report
        Call showMsg("The process has been aborted.", "")
        Exit Sub
    End Sub

    Private Sub Btn2OK_Click(sender As Object, e As EventArgs) Handles Btn2OK.Click 'Added for Weekly Revenue Report

        genericreport()

        'If (DropDownList9.SelectedItem.Text = "") Or (DropDownList9.SelectedItem.Value = "0") Then
        '    Call showMsg("Please Select the month", "")
        '    Exit Sub
        'End If

        'Dim tmpDirectory As String = "C:\temp\gembox\"
        'Try
        '    If (Not System.IO.Directory.Exists("C:\temp\")) Then
        '        System.IO.Directory.CreateDirectory("C:\temp\")
        '    End If
        '    If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
        '        System.IO.Directory.CreateDirectory("C:\temp\gembox\")
        '    End If
        'Catch ex As Exception
        'End Try
        'For Each fileName As String In Directory.EnumerateFiles(tmpDirectory, "*.xlsx")
        '    DeleteOldFiles(fileName)
        'Next
        'Dim xlsFileName As String = "Weekly" & Format(DateTime.Now, "yyyyMMddHHmmss").ToString
        'Dim tmpDirector As String = "C:\temp\gembox\"
        ''Dim tmpFileName As String = "C:\temp\wk31.xlsx"
        'Dim tmpFileName As String
        'Dim strYear As String = DropDownList10.SelectedItem.Text
        'Dim strMonth As String = DropDownList9.SelectedItem.Value
        'Dim strMaxDay As String = Date.DaysInMonth(strYear, strMonth)
        'If strMaxDay = "31" Then
        '    tmpFileName = "C:\temp\wk31.xlsx"
        '    '    'strMaxDayCount = 0
        'ElseIf strMaxDay = "30" Then
        '    tmpFileName = "C:\temp\wk30.xlsx"
        '    '    'strMaxDayCount = -1
        'ElseIf strMaxDay = "29" Then
        '    tmpFileName = "C:\temp\wk29.xlsx"
        '    '    'strMaxDayCount = -2
        '    '    'strMaxDayCount = 0
        'ElseIf strMaxDay = "28" Then
        '    tmpFileName = "C:\temp\wk28.xlsx"
        '    '    'strMaxDayCount = -3
        '    '    'strMaxDayCount = 0
        'End If
        'imagebutton71(strYear, strMonth, 1, xlsFileName, tmpFileName, tmpDirectory)

        'Dim currentDate As DateTime = DateTime.Parse(strMonth + "/1/" + strYear)
        'Dim previousDate As DateTime = currentDate.AddMonths(-1)
        'If (File.Exists(tmpDirectory & xlsFileName & ".xlsx")) Then
        '    tmpFileName = tmpDirectory & xlsFileName & ".xlsx"
        'End If

        'imagebutton71(previousDate.Year, previousDate.Month, 2, xlsFileName, tmpFileName, tmpDirectory)

        'Response.Clear()
        'Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirectory & xlsFileName & ".xlsx"))
        'Response.ContentType = "application/vnd.ms-excel"
        ''Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        'Response.WriteFile(tmpDirectory & xlsFileName & ".xlsx")
        'Response.End()


        'end

        'Dim strMaxDay As String = ""
        'Dim DtFrom As String = ""
        'Dim DtTo As String = ""
        'Dim strYear As String = DropDownList10.SelectedItem.Text
        'Dim strMonth As String = DropDownList9.SelectedItem.Value

        'If Len(strMonth) = 1 Then
        '    strMonth = "0" & strMonth
        'End If

        'strMaxDay = Date.DaysInMonth(strYear, strMonth)
        'Dim _SalesControl1 As SalesControl = New SalesControl()
        'Dim dtSIDSales2 As DataTable = _SalesControl1.SelectTargetSales(strYear, strMonth)

        'Dim targetAmount As Decimal

        'DtFrom = strYear & "/" & strMonth & "/" & "01"
        'DtTo = strYear & "/" & strMonth & "/" & strMaxDay

        'Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
        'Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

        'Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
        ''Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
        ''Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
        'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

        'Sc_Drs_Model.DateFrom = DtFrom
        'Sc_Drs_Model.DateTo = DtTo

        'Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
        'Dim str As String = ""
        'Dim strMaxDayCount As Integer = 0

        'If Sc_Drs_Model.BranchName.Contains(",") Then
        '    Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
        'End If

        'Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
        'Dim noofrec As Integer
        'noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())



        'If dtDailyRevenue.Rows.Count > 1 Then
        '    'If dtDailyRevenue.Rows.Count > 1 And dtSIDSales2.Rows.Count > 1 Then 'Added for Weekly Revenue Report

        '    Dim tmpDirector As String = "C:\temp\gembox\"
        '    Try
        '        If (Not System.IO.Directory.Exists("C:\temp\")) Then
        '            System.IO.Directory.CreateDirectory("C:\temp\")
        '        End If
        '        If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
        '            System.IO.Directory.CreateDirectory("C:\temp\gembox\")
        '        End If
        '    Catch ex As Exception
        '    End Try
        '    For Each fileName As String In Directory.EnumerateFiles(tmpDirector, "*.xlsx")
        '        DeleteOldFiles(fileName)
        '    Next

        '    Dim dateAndTime As Date
        '    dateAndTime = Now
        '    Dim xlsFileName As String = ""
        '    xlsFileName = "Weekly" & Format(dateAndTime, "yyyyMMddHHmmss").ToString

        '    ' If using Professional version, put your serial key below.
        '    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

        '    Dim workbook

        '    workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
        '    'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



        '    If strMaxDay = "31" Then
        '        workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
        '        strMaxDayCount = 0
        '    ElseIf strMaxDay = "30" Then
        '        workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
        '        strMaxDayCount = -1
        '    ElseIf strMaxDay = "29" Then
        '        workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
        '        'strMaxDayCount = -2
        '        strMaxDayCount = 0
        '    ElseIf strMaxDay = "28" Then
        '        workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
        '        'strMaxDayCount = -3
        '        strMaxDayCount = 0
        '    End If


        '    Dim workingDays As Integer = 8

        '    Dim startDate = DateTime.Now.AddDays(-workingDays)
        '    Dim endDate = DateTime.Now
        '    Dim worksheet = workbook.Worksheets(1)

        '    Dim worksheet1 = workbook.Worksheets(1)
        '    Dim currentRow1 = worksheet1.Rows(23)

        '    Dim XlDayRow As Integer = 0
        '    Dim XlDayCol As Integer = 0
        '    Dim xlTargetRow As Integer = 0
        '    Dim xlTargetCol As Integer = 0

        '    For Each branch As String In SplitBrances
        '        Dim filter As String
        '        filter = "SSCNAME = " & branch
        '        Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

        '        Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
        '        Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
        '        ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

        '        XlDayRow = 0
        '        XlDayCol = 0
        '        xlTargetRow = 0
        '        xlTargetCol = 0

        '        branch = branch.Replace("'", "")

        '        Dim blChangeValue As Boolean = False

        '        'If branch = "SSC1" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 2

        '        '    XlDayRow = 24
        '        '    XlDayCol = 3

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC2" Then
        '        '    xlTargetRow = 0
        '        '    xlTargetCol = 0

        '        '    XlDayRow = 0
        '        '    XlDayCol = 0

        '        '    blChangeValue = False
        '        'ElseIf branch = "SSC3" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 6

        '        '    XlDayRow = 24
        '        '    XlDayCol = 7

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC4" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 10

        '        '    XlDayRow = 24
        '        '    XlDayCol = 11

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC6" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 14

        '        '    XlDayRow = 24
        '        '    XlDayCol = 15

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC7" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 18

        '        '    XlDayRow = 24
        '        '    XlDayCol = 18

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC8" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 2

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 3

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC9" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 6

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 7

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC10" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 10

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 11

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC11" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 14

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 15

        '        '    blChangeValue = True

        '        'ElseIf branch = "SSC ALL" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 18

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 19

        '        '    blChangeValue = True

        '        'ElseIf branch = "SID1" Then

        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 23

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 24

        '        '    blChangeValue = False

        '        'End If

        '        'Added for SSC4

        '        'If branch = "SSC1" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 2

        '        '    XlDayRow = 24
        '        '    XlDayCol = 3

        '        '    blChangeValue = True 'Removed SSC4

        '        'ElseIf branch = "SSC2" Then
        '        '    xlTargetRow = 0
        '        '    xlTargetCol = 0

        '        '    XlDayRow = 0
        '        '    XlDayCol = 0

        '        '    blChangeValue = False

        '        'ElseIf branch = "SSC3" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 6

        '        '    XlDayRow = 24
        '        '    XlDayCol = 7

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC4" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 10

        '        '    XlDayRow = 24
        '        '    XlDayCol = 11

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC6" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 14

        '        '    XlDayRow = 24
        '        '    XlDayCol = 15

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC7" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 18

        '        '    XlDayRow = 24
        '        '    XlDayCol = 19

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC8" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 2

        '        '    ' XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 3

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC9" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 6

        '        '    ' XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 7

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC10" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 10

        '        '    'XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 11

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC11" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 14

        '        '    'XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 15

        '        '    blChangeValue = True

        '        'ElseIf branch = "SSC ALL" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 18

        '        '    ' XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 19

        '        '    blChangeValue = True

        '        'ElseIf branch = "SID1" Then

        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 23

        '        '    'XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 24

        '        '    blChangeValue = False

        '        'End If

        '        'Removed for SSC4

        '        If branch = "SSC1" Then
        '            xlTargetRow = 23
        '            xlTargetCol = 2

        '            XlDayRow = 24
        '            XlDayCol = 3

        '            blChangeValue = True

        '        ElseIf branch = "SSC2" Then
        '            xlTargetRow = 0
        '            xlTargetCol = 0

        '            XlDayRow = 0
        '            XlDayCol = 0

        '            blChangeValue = False

        '        ElseIf branch = "SSC3" Then
        '            xlTargetRow = 23
        '            xlTargetCol = 6

        '            XlDayRow = 24
        '            XlDayCol = 7

        '            blChangeValue = True

        '        ElseIf branch = "SSC6" Then
        '            xlTargetRow = 23
        '            xlTargetCol = 10

        '            XlDayRow = 24
        '            XlDayCol = 11

        '            blChangeValue = True

        '        ElseIf branch = "SSC7" Then
        '            xlTargetRow = 23
        '            xlTargetCol = 14

        '            XlDayRow = 24
        '            XlDayCol = 15

        '            blChangeValue = True

        '        ElseIf branch = "SSC8" Then
        '            xlTargetRow = 79
        '            'xlTargetRow = 80
        '            xlTargetCol = 2

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 3
        '            'XlDayCol = 2

        '            blChangeValue = True

        '        ElseIf branch = "SSC9" Then
        '            xlTargetRow = 79
        '            xlTargetCol = 6

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 7

        '            blChangeValue = True

        '        ElseIf branch = "SSC10" Then
        '            xlTargetRow = 79
        '            xlTargetCol = 10

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 11

        '            blChangeValue = True

        '        ElseIf branch = "SSC11" Then
        '            xlTargetRow = 79
        '            xlTargetCol = 14

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 15

        '            blChangeValue = True

        '        ElseIf branch = "SSC ALL" Then
        '            xlTargetRow = 79
        '            xlTargetCol = 18

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 19

        '            blChangeValue = True

        '        ElseIf branch = "SID1" Then

        '            xlTargetRow = 79
        '            xlTargetCol = 23

        '            ' XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 24

        '            blChangeValue = False

        '        End If


        '        If blChangeValue Then
        '            currentRow1 = worksheet1.Rows(xlTargetRow)
        '            'currentRow1.Cells(xlTargetCol).SetValue(12345)
        '            If dtSIDSales2.Rows.Count > 0 Then
        '                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
        '                targetAmount = 0 'Added for Weekly Revenue Report
        '                For Each dtSIDSales2Row As DataRow In result
        '                    targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
        '                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
        '                Next
        '            End If
        '            currentRow1.Cells(xlTargetCol).SetValue(targetAmount)

        '            Dim _XlDayRow As Integer = XlDayRow
        '            Dim _XlDayCol As Integer = 0
        '            Dim SscSalesAmount As Decimal

        '            For Each row As DataRow In tabresult
        '                'row(0)
        '                'SscSalesAmount = row(4)
        '                SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for weekly Revenue Report
        '                currentRow1 = worksheet1.Rows(_XlDayRow)
        '                currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

        '                _XlDayRow = _XlDayRow + 1

        '            Next
        '        End If

        '    Next


        '    Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTracking(strYear, strMonth)


        '    xlTargetRow = 79
        '    xlTargetCol = 23

        '    'XlDayRow = 80 + strMaxDayCount
        '    XlDayRow = 80
        '    XlDayCol = 24

        '    Dim _XlDayRow2 As Integer = 0
        '    _XlDayRow2 = XlDayRow
        '    Dim _XlDayCol2 As Integer = 0

        '    If dtSIDSales2.Rows.Count > 0 Then
        '        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
        '        For Each dtSIDSales2Row As DataRow In result
        '            targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
        '            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
        '        Next
        '    End If
        '    currentRow1 = worksheet1.Rows(xlTargetRow)
        '    'currentRow1.Cells(xlTargetCol).SetValue(12345)
        '    currentRow1.Cells(xlTargetCol).SetValue(targetAmount) 'tagtDayAmt


        '    Dim SalesAmount As Decimal
        '    'For Each row As DataRow In dtSIDSales
        '    For Each row As DataRow In dtSIDSales1.Rows
        '        'row(0)
        '        currentRow1 = worksheet1.Rows(_XlDayRow2)
        '        'SalesAmount = row(1)
        '        SalesAmount = Convert.ToDecimal(row(1)) 'Added for Weekly Revenue Report
        '        currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

        '        _XlDayRow2 = _XlDayRow2 + 1
        '    Next


        '    worksheet1.Calculate()


        '    workbook.Save(tmpDirector & xlsFileName & ".xlsx")


        '    Response.Clear()
        '    Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirector & xlsFileName & ".xlsx"))
        '    Response.ContentType = "application/vnd.ms-excel"
        '    'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        '    Response.WriteFile(tmpDirector & xlsFileName & ".xlsx")
        '    Response.End()

        'End If

    End Sub

    Private Sub genericreport() 'Added for Weekly Revenue Report

        If (DropDownList9.SelectedItem.Text = "") Or (DropDownList9.SelectedItem.Value = "0") Then
            Call showMsg("Please Select the month", "")
            Exit Sub
        End If

        Dim tmpDirectory As String = "C:\temp\gembox\"
        Try
            If (Not System.IO.Directory.Exists("C:\temp\")) Then
                System.IO.Directory.CreateDirectory("C:\temp\")
            End If
            If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
                System.IO.Directory.CreateDirectory("C:\temp\gembox\")
            End If
        Catch ex As Exception
        End Try
        For Each fileName As String In Directory.EnumerateFiles(tmpDirectory, "*.xlsx")
            DeleteOldFiles(fileName)
        Next
        Dim xlsFileName As String = "Weekly" & Format(DateTime.Now, "yyyyMMddHHmmss").ToString
        ''Dim tmpDirector As String = "C:\temp\gembox\"
        'Dim tmpFileName As String = "C:\temp\wk31.xlsx"
        Dim tmpFileName As String
        Dim strYear As String = DropDownList10.SelectedItem.Text
        Dim strMonth As String = DropDownList9.SelectedItem.Value
        Dim strMaxDay As String = Date.DaysInMonth(strYear, strMonth)

        If strMaxDay = "31" Then
            tmpFileName = "C:\temp\wk31.xlsx"
            '    'strMaxDayCount = 0
        ElseIf strMaxDay = "30" Then
            tmpFileName = "C:\temp\wk30.xlsx"
            '    'strMaxDayCount = -1
        ElseIf strMaxDay = "29" Then
            tmpFileName = "C:\temp\wk29.xlsx"
            '    'strMaxDayCount = -2
            '    'strMaxDayCount = 0
        ElseIf strMaxDay = "28" Then
            tmpFileName = "C:\temp\wk28.xlsx"
            'strMaxDayCount = -3
            '    'strMaxDayCount = 0
        End If

        'Added for date 
        ' Dim workbook
        'Dim worksheet3 = workbook.Worksheets(0)
        'worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList9.SelectedItem.Text
        'Added for date


        imagebutton71(strYear, strMonth, 1, xlsFileName, tmpFileName, tmpDirectory)

        Dim currentDate As DateTime = DateTime.Parse(strMonth + "/1/" + strYear)
        Dim previousDate As DateTime = currentDate.AddMonths(-1)
        If (File.Exists(tmpDirectory & xlsFileName & ".xlsx")) Then
            tmpFileName = tmpDirectory & xlsFileName & ".xlsx"

        End If
        prevmonth = False

        imagebutton71(previousDate.Year, previousDate.Month, 2, xlsFileName, tmpFileName, tmpDirectory)

        Dim lst As New List(Of Integer)
        For i = 1 To CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(strYear, strMonth)
            Dim d As New DateTime(strYear, strMonth, i)
            If (d.DayOfWeek = DayOfWeek.Sunday) Then
                lst.Add(d.Day)
            End If
        Next
        If Not (lst.Contains(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(strYear, strMonth))) Then
            lst.Add(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(strYear, strMonth))
        End If

        Dim workbook

        workbook = ExcelFile.Load(tmpFileName)

        Dim worksheet1 = workbook.Worksheets(1)


        'DirectCast(worksheet1.Cells("A1").Style, CellStyle).Borders.Item(0).LineStyle = LineStyle.MediumDashDot
        'DirectCast(DirectCast(worksheet1.Cells("C1").Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed

        'DirectCast(DirectCast(worksheet1.Cells(1, 3).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
        'DirectCast(DirectCast(worksheet1.Cells(2, 3).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed


        '.Style.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlDouble

        'worksheet1.Cells(1, 1).Style.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = GemBox.Spreadsheet.LineStyle.MediumDashed

        'worksheet1.Cells("B1").Style.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = GemBox.Spreadsheet.LineStyle.MediumDashed

        '(New GemBox.Spreadsheet.CellBorders.DebugView(DirectCast(worksheet1.Cells("B1").Style, GemBox.Spreadsheet.CellStyle).Borders).Bottom).LineStyle

        'worksheet1.Cells("A1").Style.Borders( Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble

        For i = 0 To lst.Count() - 1
            For j = 0 To 21 '17
                DirectCast(DirectCast(worksheet1.Cells(lst(i) + 23, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.Thick
                'DirectCast(DirectCast(worksheet1.Cells(lst(i) + 79, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
            Next

            For j = 0 To 21 '26
                'DirectCast(DirectCast(worksheet1.Cells(lst(i) + 23, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
                DirectCast(DirectCast(worksheet1.Cells(lst(i) + 79, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.Thick
            Next

        Next

        For i = 0 To lst.Count() - 1
            worksheet1.Cells("A" + (lst(i) + 24).ToString()).setValue("W" + (i + 1).ToString())

        Next
        For i = 0 To lst.Count() - 1
            worksheet1.Cells("A" + (lst(i) + 80).ToString()).setValue("W" + (i + 1).ToString())
            'DirectCast(DirectCast(worksheet1.Cells(lst(i) + 79, 17).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
        Next

        'previous month
        Dim lstPrevious As New List(Of Integer)
        For i = 1 To CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(previousDate.Year, previousDate.Month)
            Dim d As New DateTime(previousDate.Year, previousDate.Month, i)
            If (d.DayOfWeek = DayOfWeek.Sunday) Then
                lstPrevious.Add(d.Day)
            End If
        Next
        If Not (lstPrevious.Contains(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(previousDate.Year, previousDate.Month))) Then
            lstPrevious.Add(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(previousDate.Year, previousDate.Month))
        End If
        Dim worksheet2 = workbook.Worksheets(2)

        'Previous month line
        For i = 0 To lstPrevious.Count() - 1
            For j = 0 To 21 '17
                DirectCast(DirectCast(worksheet2.Cells(lstPrevious(i) + 23, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.Thick
                'DirectCast(DirectCast(worksheet2.Cells(lst(i) + 79, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
            Next
            For j = 0 To 21 '26
                'DirectCast(DirectCast(worksheet2.Cells(lstprevious(i) + 23, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
                DirectCast(DirectCast(worksheet2.Cells(lstPrevious(i) + 79, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.Thick
            Next

        Next


        For i = 0 To lstPrevious.Count() - 1
            worksheet2.Cells("A" + (lstPrevious(i) + 24).ToString()).setValue("W" + (i + 1).ToString())
        Next
        For i = 0 To lstPrevious.Count() - 1
            worksheet2.Cells("A" + (lstPrevious(i) + 80).ToString()).setValue("W" + (i + 1).ToString())
        Next

        Dim worksheet0 = workbook.Worksheets(0)

        worksheet0.Cells("D34").Formula = "=data01!F" + (lst(0) + 24).ToString()
        worksheet0.Cells("F34").Formula = "=data01!F" + (lst(1) + 24).ToString()
        worksheet0.Cells("D35").Formula = "=data01!F" + (lst(2) + 24).ToString()
        worksheet0.Cells("F35").Formula = "=data01!F" + (lst(3) + 24).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("D36").Formula = "=data01!F" + (lst(4) + 24).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("F36").Formula = "=data01!F" + (lst(5) + 24).ToString()
        End If


        worksheet0.Cells("I34").Formula = "=data01!J" + (lst(0) + 24).ToString()
        worksheet0.Cells("K34").Formula = "=data01!J" + (lst(1) + 24).ToString()
        worksheet0.Cells("I35").Formula = "=data01!J" + (lst(2) + 24).ToString()
        worksheet0.Cells("K35").Formula = "=data01!J" + (lst(3) + 24).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("I36").Formula = "=data01!J" + (lst(4) + 24).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("K36").Formula = "=data01!J" + (lst(5) + 24).ToString()
        End If


        worksheet0.Cells("N34").Formula = "=data01!N" + (lst(0) + 24).ToString()
        worksheet0.Cells("P34").Formula = "=data01!N" + (lst(1) + 24).ToString()
        worksheet0.Cells("N35").Formula = "=data01!N" + (lst(2) + 24).ToString()
        worksheet0.Cells("P35").Formula = "=data01!N" + (lst(3) + 24).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("N36").Formula = "=data01!N" + (lst(4) + 24).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("P36").Formula = "=data01!N" + (lst(5) + 24).ToString()
        End If



        worksheet0.Cells("S34").Formula = "=data01!R" + (lst(0) + 24).ToString()
        worksheet0.Cells("U34").Formula = "=data01!R" + (lst(1) + 24).ToString()
        worksheet0.Cells("S35").Formula = "=data01!R" + (lst(2) + 24).ToString()
        worksheet0.Cells("U35").Formula = "=data01!R" + (lst(3) + 24).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("S36").Formula = "=data01!R" + (lst(4) + 24).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("U36").Formula = "=data01!R" + (lst(5) + 24).ToString()
        End If


        worksheet0.Cells("D66").Formula = "=data01!F" + (lst(0) + 80).ToString()
        worksheet0.Cells("F66").Formula = "=data01!F" + (lst(1) + 80).ToString()
        worksheet0.Cells("D67").Formula = "=data01!F" + (lst(2) + 80).ToString()
        worksheet0.Cells("F67").Formula = "=data01!F" + (lst(3) + 80).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("D68").Formula = "=data01!F" + (lst(4) + 80).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("F68").Formula = "=data01!F" + (lst(5) + 80).ToString()
        End If

        worksheet0.Cells("I66").Formula = "=data01!J" + (lst(0) + 80).ToString()
        worksheet0.Cells("K66").Formula = "=data01!J" + (lst(1) + 80).ToString()
        worksheet0.Cells("I67").Formula = "=data01!J" + (lst(2) + 80).ToString()
        worksheet0.Cells("K67").Formula = "=data01!J" + (lst(3) + 80).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("I68").Formula = "=data01!J" + (lst(4) + 80).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("K68").Formula = "=data01!J" + (lst(5) + 80).ToString()
        End If


        worksheet0.Cells("N66").Formula = "=data01!N" + (lst(0) + 80).ToString()
        worksheet0.Cells("P66").Formula = "=data01!N" + (lst(1) + 80).ToString()
        worksheet0.Cells("N67").Formula = "=data01!N" + (lst(2) + 80).ToString()
        worksheet0.Cells("P67").Formula = "=data01!N" + (lst(3) + 80).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("N68").Formula = "=data01!N" + (lst(4) + 80).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("P68").Formula = "=data01!N" + (lst(5) + 80).ToString()
        End If


        worksheet0.Cells("S66").Formula = "=data01!R" + (lst(0) + 80).ToString()
        worksheet0.Cells("U66").Formula = "=data01!R" + (lst(1) + 80).ToString()
        worksheet0.Cells("S67").Formula = "=data01!R" + (lst(2) + 80).ToString()
        worksheet0.Cells("U67").Formula = "=data01!R" + (lst(3) + 80).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("S68").Formula = "=data01!R" + (lst(4) + 80).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("U68").Formula = "=data01!R" + (lst(5) + 80).ToString()
        End If


        'worksheet0.Cells("X66").Formula = "=data01!AA" + (lst(0) + 80).ToString()
        'worksheet0.Cells("Z66").Formula = "=data01!AA" + (lst(1) + 80).ToString()
        'worksheet0.Cells("X67").Formula = "=data01!AA" + (lst(2) + 80).ToString()
        'worksheet0.Cells("Z67").Formula = "=data01!AA" + (lst(3) + 80).ToString()
        'If (lst.Count >= 5) Then
        '    worksheet0.Cells("X68").Formula = "=data01!AA" + (lst(4) + 80).ToString()
        'End If
        'If (lst.Count = 6) Then
        '    worksheet0.Cells("Z68").Formula = "=data01!AA" + (lst(5) + 80).ToString()
        'End If

        worksheet0.Cells("AA71").Formula = "=data01!R" + (lst(0) + 80).ToString() 'V
        worksheet0.Cells("AA73").Formula = "=data01!R" + (lst(1) + 80).ToString() 'V
        worksheet0.Cells("AA75").Formula = "=data01!R" + (lst(2) + 80).ToString() 'V
        worksheet0.Cells("AA77").Formula = "=data01!R" + (lst(3) + 80).ToString() 'V
        If (lst.Count >= 5) Then
            worksheet0.Cells("AA79").Formula = "=data01!R" + (lst(4) + 80).ToString() 'V
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("AA81").Formula = "=data01!R" + (lst(5) + 80).ToString() 'V
        End If







        workbook.Save(tmpFileName)

        Response.Clear()
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirectory & xlsFileName & ".xlsx"))
        Response.ContentType = "application/vnd.ms-excel"
        'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.WriteFile(tmpDirectory & xlsFileName & ".xlsx")
        Response.End()

        'Dim strMaxDay As String = ""
        'Dim DtFrom As String = ""
        'Dim DtTo As String = ""
        'Dim strYear As String = DropDownList10.SelectedItem.Text
        'Dim strMonth As String = DropDownList9.SelectedItem.Value

        'If Len(strMonth) = 1 Then
        '    strMonth = "0" & strMonth
        'End If

        'strMaxDay = Date.DaysInMonth(strYear, strMonth)
        'Dim _SalesControl1 As SalesControl = New SalesControl()
        'Dim dtSIDSales2 As DataTable = _SalesControl1.SelectTargetSales(strYear, strMonth)

        'Dim targetAmount As Decimal

        'DtFrom = strYear & "/" & strMonth & "/" & "01"
        'DtTo = strYear & "/" & strMonth & "/" & strMaxDay

        'Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
        'Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

        'Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
        ''Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
        ''Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
        'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

        'Sc_Drs_Model.DateFrom = DtFrom
        'Sc_Drs_Model.DateTo = DtTo

        'Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_DailyRevenue(Sc_Drs_Model)
        'Dim str As String = ""
        'Dim strMaxDayCount As Integer = 0

        'If Sc_Drs_Model.BranchName.Contains(",") Then
        '    Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
        'End If

        'Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
        'Dim noofrec As Integer
        'noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())



        'If dtDailyRevenue.Rows.Count > 1 Then
        '    'If dtDailyRevenue.Rows.Count > 1 And dtSIDSales2.Rows.Count > 1 Then 'Added for Weekly Revenue Report

        '    Dim tmpDirector As String = "C:\temp\gembox\"
        '    Try
        '        If (Not System.IO.Directory.Exists("C:\temp\")) Then
        '            System.IO.Directory.CreateDirectory("C:\temp\")
        '        End If
        '        If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
        '            System.IO.Directory.CreateDirectory("C:\temp\gembox\")
        '        End If
        '    Catch ex As Exception
        '    End Try
        '    For Each fileName As String In Directory.EnumerateFiles(tmpDirector, "*.xlsx")
        '        DeleteOldFiles(fileName)
        '    Next

        '    Dim dateAndTime As Date
        '    dateAndTime = Now
        '    Dim xlsFileName As String = ""
        '    xlsFileName = "Weekly" & Format(dateAndTime, "yyyyMMddHHmmss").ToString

        '    ' If using Professional version, put your serial key below.
        '    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

        '    Dim workbook

        '    workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
        '    'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



        '    If strMaxDay = "31" Then
        '        workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
        '        strMaxDayCount = 0
        '    ElseIf strMaxDay = "30" Then
        '        workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
        '        strMaxDayCount = -1
        '    ElseIf strMaxDay = "29" Then
        '        workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
        '        'strMaxDayCount = -2
        '        strMaxDayCount = 0
        '    ElseIf strMaxDay = "28" Then
        '        workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
        '        'strMaxDayCount = -3
        '        strMaxDayCount = 0
        '    End If


        '    Dim workingDays As Integer = 8

        '    Dim startDate = DateTime.Now.AddDays(-workingDays)
        '    Dim endDate = DateTime.Now
        '    Dim worksheet = workbook.Worksheets(1)

        '    Dim worksheet1 = workbook.Worksheets(1)
        '    Dim currentRow1 = worksheet1.Rows(23)

        '    Dim XlDayRow As Integer = 0
        '    Dim XlDayCol As Integer = 0
        '    Dim xlTargetRow As Integer = 0
        '    Dim xlTargetCol As Integer = 0

        '    For Each branch As String In SplitBrances
        '        Dim filter As String
        '        filter = "SSCNAME = " & branch
        '        Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

        '        Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
        '        Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
        '        ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

        '        XlDayRow = 0
        '        XlDayCol = 0
        '        xlTargetRow = 0
        '        xlTargetCol = 0

        '        branch = branch.Replace("'", "")

        '        Dim blChangeValue As Boolean = False

        '        'If branch = "SSC1" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 2

        '        '    XlDayRow = 24
        '        '    XlDayCol = 3

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC2" Then
        '        '    xlTargetRow = 0
        '        '    xlTargetCol = 0

        '        '    XlDayRow = 0
        '        '    XlDayCol = 0

        '        '    blChangeValue = False
        '        'ElseIf branch = "SSC3" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 6

        '        '    XlDayRow = 24
        '        '    XlDayCol = 7

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC4" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 10

        '        '    XlDayRow = 24
        '        '    XlDayCol = 11

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC6" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 14

        '        '    XlDayRow = 24
        '        '    XlDayCol = 15

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC7" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 18

        '        '    XlDayRow = 24
        '        '    XlDayCol = 18

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC8" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 2

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 3

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC9" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 6

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 7

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC10" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 10

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 11

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC11" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 14

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 15

        '        '    blChangeValue = True

        '        'ElseIf branch = "SSC ALL" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 18

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 19

        '        '    blChangeValue = True

        '        'ElseIf branch = "SID1" Then

        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 23

        '        '    XlDayRow = 80 + strMaxDayCount
        '        '    XlDayCol = 24

        '        '    blChangeValue = False

        '        'End If

        '        'Added for SSC4

        '        'If branch = "SSC1" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 2

        '        '    XlDayRow = 24
        '        '    XlDayCol = 3

        '        '    blChangeValue = True 'Removed SSC4

        '        'ElseIf branch = "SSC2" Then
        '        '    xlTargetRow = 0
        '        '    xlTargetCol = 0

        '        '    XlDayRow = 0
        '        '    XlDayCol = 0

        '        '    blChangeValue = False

        '        'ElseIf branch = "SSC3" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 6

        '        '    XlDayRow = 24
        '        '    XlDayCol = 7

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC4" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 10

        '        '    XlDayRow = 24
        '        '    XlDayCol = 11

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC6" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 14

        '        '    XlDayRow = 24
        '        '    XlDayCol = 15

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC7" Then
        '        '    xlTargetRow = 23
        '        '    xlTargetCol = 18

        '        '    XlDayRow = 24
        '        '    XlDayCol = 19

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC8" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 2

        '        '    ' XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 3

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC9" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 6

        '        '    ' XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 7

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC10" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 10

        '        '    'XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 11

        '        '    blChangeValue = True
        '        'ElseIf branch = "SSC11" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 14

        '        '    'XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 15

        '        '    blChangeValue = True

        '        'ElseIf branch = "SSC ALL" Then
        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 18

        '        '    ' XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 19

        '        '    blChangeValue = True

        '        'ElseIf branch = "SID1" Then

        '        '    xlTargetRow = 79
        '        '    xlTargetCol = 23

        '        '    'XlDayRow = 80 + strMaxDayCount
        '        '    XlDayRow = 80
        '        '    XlDayCol = 24

        '        '    blChangeValue = False

        '        'End If

        '        'Removed for SSC4

        '        If branch = "SSC1" Then
        '            xlTargetRow = 23
        '            xlTargetCol = 2

        '            XlDayRow = 24
        '            XlDayCol = 3

        '            blChangeValue = True

        '        ElseIf branch = "SSC2" Then
        '            xlTargetRow = 0
        '            xlTargetCol = 0

        '            XlDayRow = 0
        '            XlDayCol = 0

        '            blChangeValue = False

        '        ElseIf branch = "SSC3" Then
        '            xlTargetRow = 23
        '            xlTargetCol = 6

        '            XlDayRow = 24
        '            XlDayCol = 7

        '            blChangeValue = True

        '        ElseIf branch = "SSC6" Then
        '            xlTargetRow = 23
        '            xlTargetCol = 10

        '            XlDayRow = 24
        '            XlDayCol = 11

        '            blChangeValue = True

        '        ElseIf branch = "SSC7" Then
        '            xlTargetRow = 23
        '            xlTargetCol = 14

        '            XlDayRow = 24
        '            XlDayCol = 15

        '            blChangeValue = True

        '        ElseIf branch = "SSC8" Then
        '            xlTargetRow = 79
        '            'xlTargetRow = 80
        '            xlTargetCol = 2

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 3
        '            'XlDayCol = 2

        '            blChangeValue = True

        '        ElseIf branch = "SSC9" Then
        '            xlTargetRow = 79
        '            xlTargetCol = 6

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 7

        '            blChangeValue = True

        '        ElseIf branch = "SSC10" Then
        '            xlTargetRow = 79
        '            xlTargetCol = 10

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 11

        '            blChangeValue = True

        '        ElseIf branch = "SSC11" Then
        '            xlTargetRow = 79
        '            xlTargetCol = 14

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 15

        '            blChangeValue = True

        '        ElseIf branch = "SSC ALL" Then
        '            xlTargetRow = 79
        '            xlTargetCol = 18

        '            'XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 19

        '            blChangeValue = True

        '        ElseIf branch = "SID1" Then

        '            xlTargetRow = 79
        '            xlTargetCol = 23

        '            ' XlDayRow = 80 + strMaxDayCount
        '            XlDayRow = 80
        '            XlDayCol = 24

        '            blChangeValue = False

        '        End If


        '        If blChangeValue Then
        '            currentRow1 = worksheet1.Rows(xlTargetRow)
        '            'currentRow1.Cells(xlTargetCol).SetValue(12345)
        '            If dtSIDSales2.Rows.Count > 0 Then
        '                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
        '                targetAmount = 0 'Added for Weekly Revenue Report
        '                For Each dtSIDSales2Row As DataRow In result
        '                    targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
        '                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
        '                Next
        '            End If
        '            currentRow1.Cells(xlTargetCol).SetValue(targetAmount)

        '            Dim _XlDayRow As Integer = XlDayRow
        '            Dim _XlDayCol As Integer = 0
        '            Dim SscSalesAmount As Decimal

        '            For Each row As DataRow In tabresult
        '                'row(0)
        '                'SscSalesAmount = row(4)
        '                SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for weekly Revenue Report
        '                currentRow1 = worksheet1.Rows(_XlDayRow)
        '                currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

        '                _XlDayRow = _XlDayRow + 1

        '            Next
        '        End If

        '    Next


        '    Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTracking(strYear, strMonth)


        '    xlTargetRow = 79
        '    xlTargetCol = 23

        '    'XlDayRow = 80 + strMaxDayCount
        '    XlDayRow = 80
        '    XlDayCol = 24

        '    Dim _XlDayRow2 As Integer = 0
        '    _XlDayRow2 = XlDayRow
        '    Dim _XlDayCol2 As Integer = 0

        '    If dtSIDSales2.Rows.Count > 0 Then
        '        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
        '        For Each dtSIDSales2Row As DataRow In result
        '            targetAmount = dtSIDSales2Row("TARGET_MONTH_AMOUNT")
        '            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
        '        Next
        '    End If
        '    currentRow1 = worksheet1.Rows(xlTargetRow)
        '    'currentRow1.Cells(xlTargetCol).SetValue(12345)
        '    currentRow1.Cells(xlTargetCol).SetValue(targetAmount) 'tagtDayAmt


        '    Dim SalesAmount As Decimal
        '    'For Each row As DataRow In dtSIDSales
        '    For Each row As DataRow In dtSIDSales1.Rows
        '        'row(0)
        '        currentRow1 = worksheet1.Rows(_XlDayRow2)
        '        'SalesAmount = row(1)
        '        SalesAmount = Convert.ToDecimal(row(1)) 'Added for Weekly Revenue Report
        '        currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

        '        _XlDayRow2 = _XlDayRow2 + 1
        '    Next


        '    worksheet1.Calculate()


        '    workbook.Save(tmpDirector & xlsFileName & ".xlsx")


        '    Response.Clear()
        '    Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirector & xlsFileName & ".xlsx"))
        '    Response.ContentType = "application/vnd.ms-excel"
        '    'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        '    Response.WriteFile(tmpDirector & xlsFileName & ".xlsx")
        '    Response.End()

        'End If

    End Sub

    Protected Sub Search_Click(sender As Object, e As EventArgs, Optional ByVal sortExpression As String = Nothing) Handles Search.Click 'Added for Monthly Target
        'If DropdownList7.SelectedItem.Text = "Select" Then
        'Call showMsg("Please Select SSC", "")
        'Exit Sub
        'End If

        'If DropDownMonth2.SelectedItem.Text = "Select" Then
        'Call showMsg("Please Select the month", "")
        'Exit Sub
        'End If

        'If DropDownYear2.SelectedItem.Text = "Select" Then
        'Call showMsg("Please Enter The Year", "")
        'Exit Sub
        'End If
        'If DropdownList7.SelectedItem.Text = "Select" Then
        'Call showMsg("Please Select SSC", "")
        'Exit Sub
        'ElseIf DropDownMonth2.SelectedItem.Text = "Select" Then
        'Call showMsg("Please Select the month", "")
        'targetamtbox.Text = "0.00"
        'targetcallload.Text = "0.00"
        'Exit Sub
        ' ElseIf DropDownYear2.SelectedItem.Text = "Select" Then
        'Call showMsg("Please Select the Year", "")
        'Exit Sub
        'End If

        If ((DropdownList7.SelectedIndex = 0) And (DropDownMonth2.SelectedIndex = 0) And (DropDownYear2.SelectedIndex = 0)) Then
            Call showMsg("Please Select the SSC or Month or Year", "")
            Exit Sub
        End If
        'If IsPostBack = True Then

        'gvMonthlytarget_RowCancelingEdit()
        gvMonthlytarget.EditIndex = -1
        Dim _Monthlytargetmodel As Monthlytargetmodel = New Monthlytargetmodel()
            Dim _MonthlyTargetControll As MonthlyTargetControll = New MonthlyTargetControll()

            _Monthlytargetmodel.SHIP_TO_BRANCH = DropdownList7.SelectedItem.Text
            _Monthlytargetmodel.TARGET_MONTH = DropDownMonth2.SelectedValue
            _Monthlytargetmodel.TARGET_YEAR = DropDownYear2.SelectedItem.Text


        'OnRowCancelingEdit()
        'gvMonthlytarget_RowCancelingEdit()

        If DropdownList7.SelectedIndex = 0 And DropDownMonth2.SelectedIndex <> 0 And DropDownYear2.SelectedIndex <> 0 Then

            'If gvMonthlytarget.Page.IsPostBack = True Then
            'gvMonthlytarget_RowCancelingEdit()
            'gvMonthlytarget.EditIndex = -1
            Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.SearchMonthlytargetGrid3(_Monthlytargetmodel)


            Dim _dataview As New DataView(dtDisplaymonthlytarget)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dtDisplaymonthlytarget.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
            Else
                gvMonthlytarget.DataSource = dtDisplaymonthlytarget
            End If
            gvMonthlytarget.DataBind()
            Exit Sub
        End If
        'End If

        If DropdownList7.SelectedIndex <> 0 And DropDownMonth2.SelectedIndex <> 0 And DropDownYear2.SelectedIndex <> 0 Then
            'If gvMonthlytarget.Page.IsPostBack = True Then
            Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.SearchMonthlytargetGrid(_Monthlytargetmodel)

            Dim _dataview As New DataView(dtDisplaymonthlytarget)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dtDisplaymonthlytarget.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
            Else
                gvMonthlytarget.DataSource = dtDisplaymonthlytarget
            End If
            gvMonthlytarget.DataBind()
            Exit Sub
        End If
        'End If

        If DropdownList7.SelectedIndex = 0 And DropDownMonth2.SelectedIndex = 0 And DropDownYear2.SelectedIndex <> 0 Then
            'If gvMonthlytarget.Page.IsPostBack = True Then
            Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.SearchMonthlytargetGrid1(_Monthlytargetmodel)
            ' gvMonthlytarget.EditIndex = -1
            Dim _dataview As New DataView(dtDisplaymonthlytarget)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dtDisplaymonthlytarget.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
            Else
                gvMonthlytarget.DataSource = dtDisplaymonthlytarget
            End If
            gvMonthlytarget.DataBind()
            Exit Sub

            'End If
        End If

        If DropdownList7.SelectedIndex <> 0 And DropDownMonth2.SelectedIndex = 0 And DropDownYear2.SelectedIndex <> 0 Then
            'If gvMonthlytarget.Page.IsPostBack = True Then
            Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.SearchMonthlytargetGrid2(_Monthlytargetmodel)

            Dim _dataview As New DataView(dtDisplaymonthlytarget)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dtDisplaymonthlytarget.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
            Else
                gvMonthlytarget.DataSource = dtDisplaymonthlytarget
            End If
            gvMonthlytarget.DataBind()
            Exit Sub
        End If

        If DropdownList7.SelectedIndex <> 0 And DropDownMonth2.SelectedIndex = 0 And DropDownYear2.SelectedIndex = 0 Then
            'If gvMonthlytarget.Page.IsPostBack = True Then
            Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.SearchMonthlytargetGrid4(_Monthlytargetmodel)

            Dim _dataview As New DataView(dtDisplaymonthlytarget)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dtDisplaymonthlytarget.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
            Else
                gvMonthlytarget.DataSource = dtDisplaymonthlytarget
            End If
            gvMonthlytarget.DataBind()
            Exit Sub
        End If

        If DropdownList7.SelectedIndex <> 0 And DropDownMonth2.SelectedIndex <> 0 And DropDownYear2.SelectedIndex = 0 Then
            'If gvMonthlytarget.Page.IsPostBack = True Then
            Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.SearchMonthlytargetGrid5(_Monthlytargetmodel)

            Dim _dataview As New DataView(dtDisplaymonthlytarget)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dtDisplaymonthlytarget.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
            Else
                gvMonthlytarget.DataSource = dtDisplaymonthlytarget
            End If
            gvMonthlytarget.DataBind()
            Exit Sub
        End If

        If DropdownList7.SelectedIndex = 0 And DropDownMonth2.SelectedIndex <> 0 And DropDownYear2.SelectedIndex = 0 Then
            'If gvMonthlytarget.Page.IsPostBack = True Then
            Dim dtDisplaymonthlytarget As DataTable = _MonthlyTargetControll.SearchMonthlytargetGrid6(_Monthlytargetmodel)

            Dim _dataview As New DataView(dtDisplaymonthlytarget)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dtDisplaymonthlytarget.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                gvMonthlytarget.DataSource = dv
            Else
                gvMonthlytarget.DataSource = dtDisplaymonthlytarget
            End If
            gvMonthlytarget.DataBind()
            Exit Sub
        End If
        'End If
        ' End If
    End Sub

    Protected Sub imagebutton81(selectedYear As String, selectedMonth As String, selectedSheet As Integer, fileName As String, templateFileName As String, tmpDirector As String)

        If (DropDownList8.SelectedItem.Text = "") Or (DropDownList8.SelectedItem.Value = "0") Then
            Call showMsg("Please Select the month", "")
            Exit Sub
        End If

        Dim strMaxDay As String = ""
        Dim DtFrom As String = ""
        Dim DtTo As String = ""
        Dim strYear As String = selectedYear
        Dim strMonth As String = selectedMonth

        If Len(strMonth) = 1 Then
            strMonth = "0" & strMonth
        End If

        strMaxDay = Date.DaysInMonth(strYear, strMonth)


        Dim _SalesControl1 As SalesControl = New SalesControl()
        Dim dtSIDSales2 As DataTable = _SalesControl1.SelectTargetSalesCallLoad(strYear, strMonth)
        Dim targetAmount As Decimal
        'Add for Call Load Report
        If (dtSIDSales2.Rows.Count > 0 Or dtSIDSales2.Rows.Count = 0) Then

            Dim SSC1 As String

            Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")

            If (exists = False And exists2 = False) Then
                ' exists = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
                exists2 = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
                SSC1 += "SSC2,"
            End If

            ' Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            'Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
            Dim exists3 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC3")
            'Dim exists4 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC4")
            Dim exists5 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC6")
            Dim exists6 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC7")
            Dim exists7 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC8")
            Dim exists8 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC9")
            Dim exists9 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC10")
            Dim exists10 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC11")
            Dim exists11 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SID1")




            If exists3 = False Then
                SSC1 += "SSC3,"

            End If


            If exists5 = False Then
                SSC1 += "SSC6,"

            End If
            If exists6 = False Then
                SSC1 += "SSC7,"

            End If
            If exists7 = False Then
                SSC1 += "SSC8,"

            End If
            If exists8 = False Then
                SSC1 += "SSC9,"

            End If
            If exists9 = False Then
                SSC1 += "SSC10,"

            End If
            If exists10 = False Then
                SSC1 += "SSC11,"
            End If
            If exists11 = False Then
                SSC1 += "SID1,"
            End If

            Dim Flag As Boolean = True
            If Not String.IsNullOrEmpty(SSC1) Then

                Dim BtnCancelChk As String = ""
                Dim BtnOK3Chk As String = ""

                Flag = False


                DtFrom = strYear & "/" & strMonth & "/" & "01"
                DtTo = strYear & "/" & strMonth & "/" & strMaxDay

                Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
                Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

                Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
                'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
                'Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
                Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 

                Sc_Drs_Model.DateFrom = DtFrom
                Sc_Drs_Model.DateTo = DtTo

                Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_CallLoadRevenue(Sc_Drs_Model)
                Dim str As String = ""
                Dim strMaxDayCount As Integer = 0

                If Sc_Drs_Model.BranchName.Contains(",") Then
                    Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
                End If

                Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
                Dim noofrec As Integer
                noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())

                If dtDailyRevenue.Rows.Count > 1 Then


                    Dim dateAndTime As Date
                    dateAndTime = Now
                    Dim xlsFileName As String = ""
                    xlsFileName = fileName

                    ' If using Professional version, put your serial key below.
                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

                    Dim workbook

                    workbook = ExcelFile.Load(templateFileName)
                    'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



                    If strMaxDay = "31" Then
                        'workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "30" Then
                        'workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
                        strMaxDayCount = -1
                    ElseIf strMaxDay = "29" Then
                        'workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
                        'strMaxDayCount = -2
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "28" Then
                        'workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
                        'strMaxDayCount = -3
                        strMaxDayCount = 0
                    End If

                    'Added for date 
                    If prevmonth = True Then
                        Dim worksheet3 = workbook.Worksheets(0)
                        worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList8.SelectedItem.Text
                    End If
                    'Added for date


                    Dim workingDays As Integer = 8

                    Dim startDate = DateTime.Now.AddDays(-workingDays)
                    Dim endDate = DateTime.Now
                    Dim worksheet = workbook.Worksheets(selectedSheet)

                    Dim worksheet1 = workbook.Worksheets(selectedSheet)
                    Dim currentRow1 = worksheet1.Rows(23)

                    Dim XlDayRow As Integer = 0
                    Dim XlDayCol As Integer = 0
                    Dim xlTargetRow As Integer = 0
                    Dim xlTargetCol As Integer = 0

                    For Each branch As String In SplitBrances
                        Dim filter As String
                        filter = "SSCNAME = " & branch
                        Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

                        Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
                        Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
                        ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

                        XlDayRow = 0
                        XlDayCol = 0
                        xlTargetRow = 0
                        xlTargetCol = 0

                        branch = branch.Replace("'", "")

                        Dim blChangeValue As Boolean = False



                        'Removed for SSC4 Service center

                        If branch = "SSC1" Then
                            xlTargetRow = 23
                            xlTargetCol = 2

                            XlDayRow = 24
                            XlDayCol = 3

                            blChangeValue = True

                        ElseIf branch = "SSC2" Then
                            xlTargetRow = 0
                            xlTargetCol = 0

                            XlDayRow = 0
                            XlDayCol = 0

                            blChangeValue = False

                        ElseIf branch = "SSC3" Then
                            xlTargetRow = 23
                            xlTargetCol = 6

                            XlDayRow = 24
                            XlDayCol = 7

                            blChangeValue = True

                        ElseIf branch = "SSC6" Then
                            xlTargetRow = 23
                            xlTargetCol = 10

                            XlDayRow = 24
                            XlDayCol = 11

                            blChangeValue = True

                        ElseIf branch = "SSC7" Then
                            xlTargetRow = 23
                            xlTargetCol = 14

                            XlDayRow = 24
                            XlDayCol = 15

                            blChangeValue = True

                        ElseIf branch = "SSC8" Then
                            xlTargetRow = 23 '79
                            'xlTargetRow = 80
                            xlTargetCol = 18 '2

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 24 '80
                            XlDayCol = 19 '3
                            'XlDayCol = 2

                            blChangeValue = True
                        ElseIf branch = "SSC9" Then
                            xlTargetRow = 79
                            xlTargetCol = 2 '6

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 3 '7

                            blChangeValue = True
                        ElseIf branch = "SSC10" Then
                            xlTargetRow = 79
                            xlTargetCol = 6 '10

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 7 '11

                            blChangeValue = True
                        ElseIf branch = "SSC11" Then
                            xlTargetRow = 79
                            xlTargetCol = 10 '14

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 11 '15

                            blChangeValue = True

                        ElseIf branch = "SSC ALL" Then
                            xlTargetRow = 79
                            xlTargetCol = 14 '18

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 15 '19

                            blChangeValue = True

                        ElseIf branch = "SID1" Then

                            xlTargetRow = 79
                            xlTargetCol = 18 '23

                            ' XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 19 '24

                            blChangeValue = False

                        End If



                        If blChangeValue Then
                            currentRow1 = worksheet1.Rows(xlTargetRow)
                            'currentRow1.Cells(xlTargetCol).SetValue(12345)
                            If dtSIDSales2.Rows.Count > 0 Then
                                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
                                targetAmount = 0 'Added for Weekly Revenue Report
                                For Each dtSIDSales2Row As DataRow In result
                                    'If dtSIDSales2Row("TARGET_CALLLOAD_COUNT").GetType() IsNot GetType(DBNull) Then
                                    If Not IsDBNull(dtSIDSales2Row("TARGET_CALLLOAD_COUNT")) Then
                                        targetAmount = dtSIDSales2Row("TARGET_CALLLOAD_COUNT")
                                    End If
                                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                                Next
                            End If
                            currentRow1.Cells(xlTargetCol).SetValue(targetAmount)

                            Dim _XlDayRow As Integer = XlDayRow
                            Dim _XlDayCol As Integer = 0
                            Dim SscSalesAmount As Decimal

                            For Each row As DataRow In tabresult
                                'row(0)
                                'SscSalesAmount = row(4)
                                SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for Call Load Report
                                currentRow1 = worksheet1.Rows(_XlDayRow)
                                currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

                                _XlDayRow = _XlDayRow + 1

                            Next
                        End If

                    Next


                    Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTrackingCallLoad(strYear, strMonth)


                    xlTargetRow = 79
                    xlTargetCol = 23

                    ' XlDayRow = 80 + strMaxDayCount
                    XlDayRow = 80
                    XlDayCol = 24

                    Dim _XlDayRow2 As Integer = 0
                    _XlDayRow2 = XlDayRow
                    Dim _XlDayCol2 As Integer = 0

                    If dtSIDSales2.Rows.Count > 0 Then
                        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
                        For Each dtSIDSales2Row As DataRow In result
                            If Not IsDBNull(dtSIDSales2Row("TARGET_CALLLOAD_COUNT")) Then
                                targetAmount = dtSIDSales2Row("TARGET_CALLLOAD_COUNT")
                            End If
                            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                        Next
                    End If
                    currentRow1 = worksheet1.Rows(xlTargetRow)
                    'currentRow1.Cells(xlTargetCol).SetValue(12345)
                    currentRow1.Cells(xlTargetCol).SetValue(targetAmount) 'tagtDayAmt


                    Dim SalesAmount As Decimal
                    'For Each row As DataRow In dtSIDSales
                    For Each row As DataRow In dtSIDSales1.Rows
                        'row(0)
                        currentRow1 = worksheet1.Rows(_XlDayRow2)
                        ' SalesAmount = row(1)
                        SalesAmount = Convert.ToDecimal(row(1)) 'Added for Call Load Report
                        currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

                        _XlDayRow2 = _XlDayRow2 + 1
                    Next


                    worksheet1.Calculate()


                    workbook.Save(tmpDirector & xlsFileName & ".xlsx")



                End If
            End If
            'End for Call Load Report

            If Flag = True Then 'Added for Call Load Report


                Dim targetAmount1 As Decimal

                DtFrom = strYear & "/" & strMonth & "/" & "01"
                DtTo = strYear & "/" & strMonth & "/" & strMaxDay

                Dim Sc_Drs_Model As ScDsrModel = New ScDsrModel()
                Dim Sc_Drs_Control As ScDsrControl = New ScDsrControl()

                Sc_Drs_Model.BranchName = "All" ' DropdownList3.SelectedItem.Text
                'Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'"
                'Sc_Drs_Model.BranchName = "'SSC2','SSC3','SSC4','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 
                Sc_Drs_Model.BranchName = "'SSC1','SSC2','SSC3','SSC6','SSC7','SSC8','SSC9','SSC10','SSC11'" 'Removed for ssc4 Weekly

                Sc_Drs_Model.DateFrom = DtFrom
                Sc_Drs_Model.DateTo = DtTo

                Dim dtDailyRevenue As DataTable = Sc_Drs_Control.StoreManagement_CallLoadRevenue(Sc_Drs_Model)
                Dim str As String = ""
                Dim strMaxDayCount As Integer = 0

                If Sc_Drs_Model.BranchName.Contains(",") Then
                    Sc_Drs_Model.BranchName = Sc_Drs_Model.BranchName & ",'SSC ALL'"
                End If

                Dim SplitBrances As String() = Sc_Drs_Model.BranchName.Split(New Char() {","c})
                Dim noofrec As Integer
                noofrec = dtDailyRevenue.Rows.Count / (SplitBrances.Count())

                If dtDailyRevenue.Rows.Count > 1 Then


                    Dim dateAndTime As Date
                    dateAndTime = Now
                    Dim xlsFileName As String = ""
                    xlsFileName = fileName

                    ' If using Professional version, put your serial key below.
                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")

                    Dim workbook

                    workbook = ExcelFile.Load(templateFileName)
                    'workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                    'Dim workbook = ExcelFile.Load("C:\temp\WeeklyRevenueTemplate31.xlsx")



                    If strMaxDay = "31" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk31.xlsx")
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "30" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk30.xlsx")
                        strMaxDayCount = -1
                    ElseIf strMaxDay = "29" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk29.xlsx")
                        'strMaxDayCount = -2
                        strMaxDayCount = 0
                    ElseIf strMaxDay = "28" Then
                        '    workbook = ExcelFile.Load("C:\temp\wk28.xlsx")
                        'strMaxDayCount = -3
                        strMaxDayCount = 0
                    End If


                    'Added for date 
                    If prevmonth = True Then
                        Dim worksheet3 = workbook.Worksheets(0)
                        worksheet3.cells("A3").value = strMaxDay + " - " + DropDownList8.SelectedItem.Text
                    End If

                    'Added for date


                    Dim workingDays As Integer = 8

                    Dim startDate = DateTime.Now.AddDays(-workingDays)
                    Dim endDate = DateTime.Now
                    Dim worksheet = workbook.Worksheets(selectedSheet)

                    Dim worksheet1 = workbook.Worksheets(selectedSheet)
                    Dim currentRow1 = worksheet1.Rows(23)

                    Dim XlDayRow As Integer = 0
                    Dim XlDayCol As Integer = 0
                    Dim xlTargetRow As Integer = 0
                    Dim xlTargetCol As Integer = 0

                    For Each branch As String In SplitBrances
                        Dim filter As String
                        filter = "SSCNAME = " & branch
                        Dim tabresult() As DataRow = dtDailyRevenue.Select(filter)

                        Dim tagtDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("TARGET_DAY_AMOUNT"))
                        Dim ActDayAmt As Decimal = dtDailyRevenue.Select(filter).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("DRS_AMOUNT"))
                        ' Dim DayTgtAmt As Decimal = tagtDayAmt / noofrec

                        XlDayRow = 0
                        XlDayCol = 0
                        xlTargetRow = 0
                        xlTargetCol = 0

                        branch = branch.Replace("'", "")

                        Dim blChangeValue As Boolean = False

                        'Removed for SSC4

                        If branch = "SSC1" Then
                            xlTargetRow = 23
                            xlTargetCol = 2

                            XlDayRow = 24
                            XlDayCol = 3

                            blChangeValue = True

                        ElseIf branch = "SSC2" Then
                            xlTargetRow = 0
                            xlTargetCol = 0

                            XlDayRow = 0
                            XlDayCol = 0

                            blChangeValue = False

                        ElseIf branch = "SSC3" Then
                            xlTargetRow = 23
                            xlTargetCol = 6

                            XlDayRow = 24
                            XlDayCol = 7

                            blChangeValue = True

                        ElseIf branch = "SSC6" Then
                            xlTargetRow = 23
                            xlTargetCol = 10

                            XlDayRow = 24
                            XlDayCol = 11

                            blChangeValue = True

                        ElseIf branch = "SSC7" Then
                            xlTargetRow = 23
                            xlTargetCol = 14

                            XlDayRow = 24
                            XlDayCol = 15

                            blChangeValue = True

                        ElseIf branch = "SSC8" Then
                            xlTargetRow = 23 '79
                            'xlTargetRow = 80
                            xlTargetCol = 18 '2

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 24 '80
                            XlDayCol = 19 '3
                            ' XlDayCol = 2

                            blChangeValue = True
                        ElseIf branch = "SSC9" Then
                            xlTargetRow = 79
                            xlTargetCol = 2 '6

                            ' XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 3 '7

                            blChangeValue = True
                        ElseIf branch = "SSC10" Then
                            xlTargetRow = 79
                            xlTargetCol = 6 '10

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 7 '11

                            blChangeValue = True
                        ElseIf branch = "SSC11" Then
                            xlTargetRow = 79
                            xlTargetCol = 10 '14

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 11 '15

                            blChangeValue = True

                        ElseIf branch = "SSC ALL" Then
                            xlTargetRow = 79
                            xlTargetCol = 14 '18

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 15 '19

                            blChangeValue = True

                        ElseIf branch = "SID1" Then

                            xlTargetRow = 79
                            xlTargetCol = 18 '23

                            'XlDayRow = 80 + strMaxDayCount
                            XlDayRow = 80
                            XlDayCol = 19 '24

                            blChangeValue = False

                        End If

                        If blChangeValue Then
                            currentRow1 = worksheet1.Rows(xlTargetRow)
                            'currentRow1.Cells(xlTargetCol).SetValue(12345)
                            If dtSIDSales2.Rows.Count > 0 Then
                                Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = '" & branch & "'")
                                targetAmount1 = 0 'Added for Call load  Report
                                For Each dtSIDSales2Row As DataRow In result
                                    If Not IsDBNull(dtSIDSales2Row("TARGET_CALLLOAD_COUNT")) Then
                                        targetAmount1 = dtSIDSales2Row("TARGET_CALLLOAD_COUNT")
                                    End If
                                    'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                                Next
                            End If
                            currentRow1.Cells(xlTargetCol).SetValue(targetAmount1)

                            Dim _XlDayRow As Integer = XlDayRow
                            Dim _XlDayCol As Integer = 0
                            Dim SscSalesAmount As Decimal

                            For Each row As DataRow In tabresult
                                'row(0)
                                ' SscSalesAmount = row(4)
                                SscSalesAmount = Convert.ToDecimal(row(4)) 'Added for Call Load Report
                                currentRow1 = worksheet1.Rows(_XlDayRow)
                                currentRow1.Cells(XlDayCol).SetValue(SscSalesAmount)

                                _XlDayRow = _XlDayRow + 1

                            Next
                        End If

                    Next


                    Dim dtSIDSales1 As DataTable = _SalesControl1.SonyPlTrackingCallLoad(strYear, strMonth)


                    xlTargetRow = 79
                    xlTargetCol = 18 '23

                    'XlDayRow = 80 + strMaxDayCount
                    XlDayRow = 80
                    XlDayCol = 19 '24

                    Dim _XlDayRow2 As Integer = 0
                    _XlDayRow2 = XlDayRow
                    Dim _XlDayCol2 As Integer = 0

                    If dtSIDSales2.Rows.Count > 0 Then
                        Dim result() As DataRow = dtSIDSales2.Select("SHIP_TO_BRANCH = 'SID1'")
                        For Each dtSIDSales2Row As DataRow In result
                            If Not IsDBNull(dtSIDSales2Row("TARGET_CALLLOAD_COUNT")) Then
                                targetAmount1 = dtSIDSales2Row("TARGET_CALLLOAD_COUNT")
                            End If
                            'Console.WriteLine("{0}, {1}", Row(0), Row(1))
                        Next
                    End If
                    currentRow1 = worksheet1.Rows(xlTargetRow)
                    'currentRow1.Cells(xlTargetCol).SetValue(12345)
                    currentRow1.Cells(xlTargetCol).SetValue(targetAmount1) 'tagtDayAmt


                    Dim SalesAmount As Decimal
                    'For Each row As DataRow In dtSIDSales
                    For Each row As DataRow In dtSIDSales1.Rows
                        'row(0)
                        currentRow1 = worksheet1.Rows(_XlDayRow2)
                        'SalesAmount = row(1)
                        SalesAmount = Convert.ToDecimal(row(1)) 'Added for Call Load Report
                        currentRow1.Cells(XlDayCol).SetValue(SalesAmount)

                        _XlDayRow2 = _XlDayRow2 + 1
                    Next

                    worksheet1.Calculate()

                    workbook.Save(tmpDirector & xlsFileName & ".xlsx")

                End If
            End If

        End If
    End Sub

    Protected Sub ImageButton8_Click(sender As Object, e As EventArgs) Handles ImageButton8.Click

        If (DropDownList8.SelectedItem.Text = "") Or (DropDownList8.SelectedItem.Value = "0") Then
            Call showMsg("Please Select the month", "")
            Exit Sub
        End If

        Dim selectedYear As String
        Dim selectedMonth As String
        Dim strMaxDay As String = ""
        Dim DtFrom As String = ""
        Dim DtTo As String = ""
        Dim strYear As String = DropDownList11.SelectedItem.Text
        Dim strMonth As String = DropDownList8.SelectedItem.Value
        Dim xlsFileName As String
        Dim tmpFileName As String
        Dim tmpDirectory As String

        If Len(strMonth) = 1 Then
            strMonth = "0" & strMonth
        End If

        strMaxDay = Date.DaysInMonth(strYear, strMonth)
        Dim _SalesControl1 As SalesControl = New SalesControl()
        Dim dtSIDSales2 As DataTable = _SalesControl1.SelectTargetSalesCallLoad(strYear, strMonth)
        ' Dim targetAmount As Decimal
        'Added for Call Load Report
        If (dtSIDSales2.Rows.Count > 0 Or dtSIDSales2.Rows.Count = 0) Then

            Dim SSC1 As String

            Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")

            If (exists = False And exists2 = False) Then
                ' exists = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
                exists2 = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
                SSC1 += "SSC2,"
            End If

            ' Dim exists As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC1")
            'Dim exists2 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC2")
            Dim exists3 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC3")
            'Dim exists4 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC4")
            Dim exists5 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC6")
            Dim exists6 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC7")
            Dim exists7 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC8")
            Dim exists8 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC9")
            Dim exists9 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC10")
            Dim exists10 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SSC11")
            Dim exists11 As Boolean = dtSIDSales2.Select().ToList().Exists(Function(row) row("SHIP_TO_BRANCH").ToString() = "SID1")


            If exists3 = False Then
                SSC1 += "SSC3,"

            End If


            If exists5 = False Then
                SSC1 += "SSC6,"

            End If
            If exists6 = False Then
                SSC1 += "SSC7,"

            End If
            If exists7 = False Then
                SSC1 += "SSC8,"

            End If
            If exists8 = False Then
                SSC1 += "SSC9,"

            End If
            If exists9 = False Then
                SSC1 += "SSC10,"

            End If
            If exists10 = False Then
                SSC1 += "SSC11,"
            End If
            If exists11 = False Then
                SSC1 += "SID1,"
            End If

            Dim Flag As Boolean = True
            If Not String.IsNullOrEmpty(SSC1) Then

                Dim BtnCancelChk As String = ""
                Dim BtnOK3Chk As String = ""
                Call showMsg("Target CallLoad Count is not available for ('" & SSC1 & "'). Do you want to continue, it is ok?", "CancelMsg3")
                Exit Sub
            Else
                generatereport()
            End If

        End If

    End Sub

    Private Sub Btn3OK_Click(sender As Object, e As EventArgs) Handles Btn3OK.Click
        generatereport()
    End Sub
    Private Sub generatereport() 'Added for Call Load Report

        If (DropDownList8.SelectedItem.Text = "") Or (DropDownList8.SelectedItem.Value = "0") Then
            Call showMsg("Please Select the month", "")
            Exit Sub
        End If

        Dim tmpDirectory As String = "C:\temp\gembox\"
        Try
            If (Not System.IO.Directory.Exists("C:\temp\")) Then
                System.IO.Directory.CreateDirectory("C:\temp\")
            End If
            If (Not System.IO.Directory.Exists("C:\temp\gembox\")) Then
                System.IO.Directory.CreateDirectory("C:\temp\gembox\")
            End If
        Catch ex As Exception
        End Try
        For Each fileName As String In Directory.EnumerateFiles(tmpDirectory, "*.xlsx")
            DeleteOldFiles(fileName)
        Next
        Dim xlsFileName As String = "WeeklyCload" & Format(DateTime.Now, "yyyyMMddHHmmss").ToString
        ''Dim tmpDirector As String = "C:\temp\gembox\"
        'Dim tmpFileName As String = "C:\temp\wk31.xlsx"
        Dim tmpFileName As String
        Dim strYear As String = DropDownList11.SelectedItem.Text
        Dim strMonth As String = DropDownList8.SelectedItem.Value
        Dim strMaxDay As String = Date.DaysInMonth(strYear, strMonth)

        If strMaxDay = "31" Then
            tmpFileName = "C:\temp\wkcload31.xlsx"
            '    'strMaxDayCount = 0
        ElseIf strMaxDay = "30" Then
            tmpFileName = "C:\temp\wkcload30.xlsx"
            '    'strMaxDayCount = -1
        ElseIf strMaxDay = "29" Then
            tmpFileName = "C:\temp\wkcload29.xlsx"
            '    'strMaxDayCount = -2
            '    'strMaxDayCount = 0
        ElseIf strMaxDay = "28" Then
            tmpFileName = "C:\temp\wkcload28.xlsx"
            '    'strMaxDayCount = -3
            '    'strMaxDayCount = 0
        End If




        imagebutton81(strYear, strMonth, 1, xlsFileName, tmpFileName, tmpDirectory)

        Dim currentDate As DateTime = DateTime.Parse(strMonth + "/1/" + strYear)
        Dim previousDate As DateTime = currentDate.AddMonths(-1)
        If (File.Exists(tmpDirectory & xlsFileName & ".xlsx")) Then
            tmpFileName = tmpDirectory & xlsFileName & ".xlsx"

        End If
        prevmonth = False

        imagebutton81(previousDate.Year, previousDate.Month, 2, xlsFileName, tmpFileName, tmpDirectory)

        Dim lst As New List(Of Integer)
        For i = 1 To CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(strYear, strMonth)
            Dim d As New DateTime(strYear, strMonth, i)
            If (d.DayOfWeek = DayOfWeek.Sunday) Then
                lst.Add(d.Day)
            End If
        Next
        If Not (lst.Contains(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(strYear, strMonth))) Then
            lst.Add(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(strYear, strMonth))
        End If

        Dim workbook

        workbook = ExcelFile.Load(tmpFileName)

        Dim worksheet1 = workbook.Worksheets(1)




        For i = 0 To lst.Count() - 1
            For j = 0 To 21 '17
                DirectCast(DirectCast(worksheet1.Cells(lst(i) + 23, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.Thick
                'DirectCast(DirectCast(worksheet1.Cells(lst(i) + 79, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
            Next

            For j = 0 To 21 '26
                'DirectCast(DirectCast(worksheet1.Cells(lst(i) + 23, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
                DirectCast(DirectCast(worksheet1.Cells(lst(i) + 79, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.Thick
            Next

        Next

        For i = 0 To lst.Count() - 1
            worksheet1.Cells("A" + (lst(i) + 24).ToString()).setValue("W" + (i + 1).ToString())

        Next
        For i = 0 To lst.Count() - 1
            worksheet1.Cells("A" + (lst(i) + 80).ToString()).setValue("W" + (i + 1).ToString())
            'DirectCast(DirectCast(worksheet1.Cells(lst(i) + 79, 17).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
        Next

        'previous month
        Dim lstPrevious As New List(Of Integer)
        For i = 1 To CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(previousDate.Year, previousDate.Month)
            Dim d As New DateTime(previousDate.Year, previousDate.Month, i)
            If (d.DayOfWeek = DayOfWeek.Sunday) Then
                lstPrevious.Add(d.Day)
            End If
        Next
        If Not (lstPrevious.Contains(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(previousDate.Year, previousDate.Month))) Then
            lstPrevious.Add(CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(previousDate.Year, previousDate.Month))
        End If
        Dim worksheet2 = workbook.Worksheets(2)

        'Previous month line
        For i = 0 To lstPrevious.Count() - 1
            For j = 0 To 21 '17
                DirectCast(DirectCast(worksheet2.Cells(lstPrevious(i) + 23, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.Thick
                'DirectCast(DirectCast(worksheet2.Cells(lst(i) + 79, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
            Next
            For j = 0 To 21 '26
                'DirectCast(DirectCast(worksheet2.Cells(lstprevious(i) + 23, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.MediumDashed
                DirectCast(DirectCast(worksheet2.Cells(lstPrevious(i) + 79, j).Style, GemBox.Spreadsheet.CellStyle).Borders, CellBorders).Item(1).LineStyle = LineStyle.Thick
            Next

        Next


        For i = 0 To lstPrevious.Count() - 1
            worksheet2.Cells("A" + (lstPrevious(i) + 24).ToString()).setValue("W" + (i + 1).ToString())
        Next
        For i = 0 To lstPrevious.Count() - 1
            worksheet2.Cells("A" + (lstPrevious(i) + 80).ToString()).setValue("W" + (i + 1).ToString())
        Next

        Dim worksheet0 = workbook.Worksheets(0)

        worksheet0.Cells("D34").Formula = "=data01!F" + (lst(0) + 24).ToString()
        worksheet0.Cells("F34").Formula = "=data01!F" + (lst(1) + 24).ToString()
        worksheet0.Cells("D35").Formula = "=data01!F" + (lst(2) + 24).ToString()
        worksheet0.Cells("F35").Formula = "=data01!F" + (lst(3) + 24).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("D36").Formula = "=data01!F" + (lst(4) + 24).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("F36").Formula = "=data01!F" + (lst(5) + 24).ToString()
        End If


        worksheet0.Cells("I34").Formula = "=data01!J" + (lst(0) + 24).ToString()
        worksheet0.Cells("K34").Formula = "=data01!J" + (lst(1) + 24).ToString()
        worksheet0.Cells("I35").Formula = "=data01!J" + (lst(2) + 24).ToString()
        worksheet0.Cells("K35").Formula = "=data01!J" + (lst(3) + 24).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("I36").Formula = "=data01!J" + (lst(4) + 24).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("K36").Formula = "=data01!J" + (lst(5) + 24).ToString()
        End If


        worksheet0.Cells("N34").Formula = "=data01!N" + (lst(0) + 24).ToString()
        worksheet0.Cells("P34").Formula = "=data01!N" + (lst(1) + 24).ToString()
        worksheet0.Cells("N35").Formula = "=data01!N" + (lst(2) + 24).ToString()
        worksheet0.Cells("P35").Formula = "=data01!N" + (lst(3) + 24).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("N36").Formula = "=data01!N" + (lst(4) + 24).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("P36").Formula = "=data01!N" + (lst(5) + 24).ToString()
        End If



        worksheet0.Cells("S34").Formula = "=data01!R" + (lst(0) + 24).ToString()
        worksheet0.Cells("U34").Formula = "=data01!R" + (lst(1) + 24).ToString()
        worksheet0.Cells("S35").Formula = "=data01!R" + (lst(2) + 24).ToString()
        worksheet0.Cells("U35").Formula = "=data01!R" + (lst(3) + 24).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("S36").Formula = "=data01!R" + (lst(4) + 24).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("U36").Formula = "=data01!R" + (lst(5) + 24).ToString()
        End If


        worksheet0.Cells("D66").Formula = "=data01!F" + (lst(0) + 80).ToString()
        worksheet0.Cells("F66").Formula = "=data01!F" + (lst(1) + 80).ToString()
        worksheet0.Cells("D67").Formula = "=data01!F" + (lst(2) + 80).ToString()
        worksheet0.Cells("F67").Formula = "=data01!F" + (lst(3) + 80).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("D68").Formula = "=data01!F" + (lst(4) + 80).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("F68").Formula = "=data01!F" + (lst(5) + 80).ToString()
        End If

        worksheet0.Cells("I66").Formula = "=data01!J" + (lst(0) + 80).ToString()
        worksheet0.Cells("K66").Formula = "=data01!J" + (lst(1) + 80).ToString()
        worksheet0.Cells("I67").Formula = "=data01!J" + (lst(2) + 80).ToString()
        worksheet0.Cells("K67").Formula = "=data01!J" + (lst(3) + 80).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("I68").Formula = "=data01!J" + (lst(4) + 80).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("K68").Formula = "=data01!J" + (lst(5) + 80).ToString()
        End If


        worksheet0.Cells("N66").Formula = "=data01!N" + (lst(0) + 80).ToString()
        worksheet0.Cells("P66").Formula = "=data01!N" + (lst(1) + 80).ToString()
        worksheet0.Cells("N67").Formula = "=data01!N" + (lst(2) + 80).ToString()
        worksheet0.Cells("P67").Formula = "=data01!N" + (lst(3) + 80).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("N68").Formula = "=data01!N" + (lst(4) + 80).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("P68").Formula = "=data01!N" + (lst(5) + 80).ToString()
        End If


        worksheet0.Cells("S66").Formula = "=data01!R" + (lst(0) + 80).ToString()
        worksheet0.Cells("U66").Formula = "=data01!R" + (lst(1) + 80).ToString()
        worksheet0.Cells("S67").Formula = "=data01!R" + (lst(2) + 80).ToString()
        worksheet0.Cells("U67").Formula = "=data01!R" + (lst(3) + 80).ToString()
        If (lst.Count >= 5) Then
            worksheet0.Cells("S68").Formula = "=data01!R" + (lst(4) + 80).ToString()
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("U68").Formula = "=data01!R" + (lst(5) + 80).ToString()
        End If


        'worksheet0.Cells("X66").Formula = "=data01!AA" + (lst(0) + 80).ToString()
        'worksheet0.Cells("Z66").Formula = "=data01!AA" + (lst(1) + 80).ToString()
        'worksheet0.Cells("X67").Formula = "=data01!AA" + (lst(2) + 80).ToString()
        'worksheet0.Cells("Z67").Formula = "=data01!AA" + (lst(3) + 80).ToString()
        'If (lst.Count >= 5) Then
        '    worksheet0.Cells("X68").Formula = "=data01!AA" + (lst(4) + 80).ToString()
        'End If
        'If (lst.Count = 6) Then
        '    worksheet0.Cells("Z68").Formula = "=data01!AA" + (lst(5) + 80).ToString()
        'End If

        worksheet0.Cells("AA71").Formula = "=data01!R" + (lst(0) + 80).ToString() 'V
        worksheet0.Cells("AA73").Formula = "=data01!R" + (lst(1) + 80).ToString() 'V
        worksheet0.Cells("AA75").Formula = "=data01!R" + (lst(2) + 80).ToString() 'V
        worksheet0.Cells("AA77").Formula = "=data01!R" + (lst(3) + 80).ToString() 'V
        If (lst.Count >= 5) Then
            worksheet0.Cells("AA79").Formula = "=data01!R" + (lst(4) + 80).ToString() 'V
        End If
        If (lst.Count = 6) Then
            worksheet0.Cells("AA81").Formula = "=data01!R" + (lst(5) + 80).ToString() 'V
        End If


        workbook.Save(tmpFileName)

        Response.Clear()
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", tmpDirectory & xlsFileName & ".xlsx"))
        Response.ContentType = "application/vnd.ms-excel"
        'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.WriteFile(tmpDirectory & xlsFileName & ".xlsx")
        Response.End()

    End Sub
End Class
