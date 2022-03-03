Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
'Imports System.Threading

Public Class Apple_Analysis_Export
    Inherits System.Web.UI.Page

    Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()


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

            InitDropDownList()

            DefaultSearchSetting()

            '''''''***拠点名称の設定***
            ''''''DropListLocation.Items.Clear()
            ''''''If userLevel = "0" Or userLevel = "1" Or userLevel = "2" Or adminFlg = True Then
            ''''''    Dim shipName() As String
            ''''''    If Session("ship_name_list") IsNot Nothing Then
            ''''''        shipName = Session("ship_name_list")
            ''''''        With DropListLocation
            ''''''            .Items.Add("Select shipname")
            ''''''            For i = 0 To UBound(shipName)
            ''''''                If Trim(shipName(i)) <> "" Then
            ''''''                    .Items.Add(shipName(i))
            ''''''                End If
            ''''''            Next i
            ''''''        End With
            ''''''    End If

            ''''''Else
            ''''''    btnSend.Enabled = False
            ''''''End If

            ''''''***monthリストの設定***
            '''''DropDownMonth.Items.Clear()
            '''''    With DropDownMonth
            '''''    .Items.Add("Select the month")
            '''''    .Items.Add("January")
            '''''    .Items.Add("February")
            '''''    .Items.Add("March")
            '''''    .Items.Add("April")
            '''''    .Items.Add("May")
            '''''    .Items.Add("June")
            '''''    .Items.Add("July")
            '''''    .Items.Add("August")
            '''''    .Items.Add("September")
            '''''    .Items.Add("October")
            '''''    .Items.Add("November")
            '''''    .Items.Add("December")
            '''''End With

            '***exportFileリストの設定***
            DropDownExportFile.Items.Clear()
            With DropDownExportFile
                .Items.Add("Select Export Filename")
                .Items.Add("1.PL_Tracking_Sheet")
                .Items.Add("2.Sales_Register_from_GSPN_software_for_OOW")
                .Items.Add("3.Sales_Invoice_to_samsung_C_IW")
                .Items.Add("4.Sales_Invoiec_to_samsung_EXC_IW")
                .Items.Add("5.Sales_Register_from_GSPN_software_for_IW")
                .Items.Add("6.Sales_Register_from GSPN software_for_OthersSales")
                .Items.Add("7.SAW_Discount_Details")
                .Items.Add("8.Purchase_Register")
                .Items.Add("9.Final_Report")
            End With

        Else

            '***セッション設定***
            '月を指定
            Dim setMon As String = DropDownMonth.SelectedIndex.ToString("00")
            Dim setMonName As String = DropDownMonth.Text

            Session("set_Mon2") = setMon
            Session("set_MonName") = setMonName

            ''''''拠点を指定
            '''''Dim exportShipName As String = DropListLocation.Text
            '''''Session("export_shipName") = exportShipName

            'ダウンロードファイル種類を指定
            Dim exportFile As String = drpTaskExport.SelectedItem.Text
            Session("export_File") = exportFile

        End If


    End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")
        Dim userid As String = Session("user_id")
        Dim uploadShipname As String = DropListLocation.Text
        Dim uploadFilename As String = drpTaskExport.Text
        Dim listHistoryMsg() As String = Session("list_History_Msg")


        '***入力チェック***
        If ShipName = "" Then
            Call showMsg("The session was cleared. Please login again.", "")
            Exit Sub
        End If

        If DropListLocation.Text = "Select Branch" And drpTaskExport.SelectedValue <> "19B" Then
            Call showMsg("Please specify the Branch.", "")
            Exit Sub
        End If

        If drpTaskExport.SelectedValue = "-1" Then
            Call showMsg("Please specify the file type", "")
            Exit Sub
        End If

        If (drpTaskExport.SelectedValue = "17") Then
            'Comment on 20190828
            ''''''''''''''(drpTaskExport.SelectedValue = "1") Or
            ''(drpTaskExport.SelectedValue = "2.1") Or
            ''(drpTaskExport.SelectedValue = "2.2") Or
            ''(drpTaskExport.SelectedValue = "2.3") Or

            'Old functionaly process
            OldFunctionality()
            Exit Sub
        Else

            'Comment on 20190828
            If (drpTaskExport.SelectedValue = "1") Then

                Dim DtFrom As String = ""
                Dim DtTo As String = ""
                DtFrom = Trim(TextDateFrom.Text)
                DtTo = Trim(TextDateTo.Text)
                'Task = 0 then Month wise filter
                'Task = 1 then From & To
                If Trim(DtFrom) = "" And Trim(DtTo) = "" And DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please specify either output period by month or date", "")
                    Exit Sub
                End If
                If Trim(DtFrom) <> "" And Trim(DtTo) <> "" And DropDownMonth.SelectedValue <> "0" Then
                    Call showMsg("Please specify either output period by month or date.", "")
                    Exit Sub
                End If
                If DropDownMonth.SelectedValue <> "0" Then
                    'Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 Or Len(Trim(DtTo)) > 7 Then
                        Call showMsg("Please specify either output period by month or date.", "")
                        Exit Sub
                    End If


                Else
                    ' Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
                        Dim date1, date2 As Date
                        date1 = Date.Parse(TextDateFrom.Text)
                        date2 = Date.Parse(TextDateTo.Text)
                        If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                            Call showMsg("Please verify from date and to date", "")
                            Exit Sub
                        End If
                    End If
                    'Need to interchange 
                    'Allow for any one of From / To 
                    If Len(DtFrom) > 5 And DtTo = "" Then
                        DtTo = DtFrom
                    End If
                    If DtFrom = "" And Len(DtTo) > 5 Then
                        DtFrom = DtTo
                    End If
                End If
                'FromDate Verification 
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

                'CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                '1st Find the records available on the specified by Month
                'Pass the paramters to Update in Datatabase
                Dim _ScDsrModel As ScDsrModel = New ScDsrModel()
                Dim _ScDsrControl As ScDsrControl = New ScDsrControl()
                Dim strFileName As String = ""
                _ScDsrModel.UserId = userid
                _ScDsrModel.UserName = userName
                _ScDsrModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _ScDsrModel.ShipToBranch = DropListLocation.SelectedItem.Text
                '''''''''''''''''''   _DebitNoteModel.SrcFileName = _DebitNoteModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '''


                If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                    'Need to find it by selected month
                    _ScDsrModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                    _ScDsrModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                    '' _InvoiceUpdateModel.SrcFileName = _InvoiceUpdateModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                    strFileName = _ScDsrModel.ShipToBranch & "_" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Else


                    'Verify Date Format 
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
                    _ScDsrModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                    'DateConversion
                    Dim DtConvTo() As String
                    DtConvTo = Split(DtTo, "/")
                    If Len(DtConvTo(0)) = 1 Then
                        DtConvTo(0) = "0" & DtConvTo(0)
                    End If
                    If Len(DtConvTo(1)) = 1 Then
                        DtConvTo(1) = "0" & DtConvTo(1)
                    End If
                    _ScDsrModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                    strFileName = _ScDsrModel.ShipToBranch & "_" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".csv"
                    ''  _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                End If




                Dim dtScDsrView As DataTable = _ScDsrControl.SelectScDsr(_ScDsrModel)
                If (dtScDsrView Is Nothing) Or (dtScDsrView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtScDsrView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If









                'Modified on 20190801
                'Task No. 3A, 3B, 4, 5, 6,7,8,9,10,11,12,13,14,15,16,17
                'Dim srcFileName As String = ""
            ElseIf (drpTaskExport.SelectedValue = "2.1") Or
            (drpTaskExport.SelectedValue = "2.2") Or
            (drpTaskExport.SelectedValue = "2.3") Then

                Dim DtFrom As String = ""
                Dim DtTo As String = ""
                DtFrom = Trim(TextDateFrom.Text)
                DtTo = Trim(TextDateTo.Text)
                'Task = 0 then Month wise filter
                'Task = 1 then From & To
                If Trim(DtFrom) = "" And Trim(DtTo) = "" And DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please specify either output period by month or date", "")
                    Exit Sub
                End If
                If Trim(DtFrom) <> "" And Trim(DtTo) <> "" And DropDownMonth.SelectedValue <> "0" Then
                    Call showMsg("Please specify either output period by month or date.", "")
                    Exit Sub
                End If
                If DropDownMonth.SelectedValue <> "0" Then
                    'Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 Or Len(Trim(DtTo)) > 7 Then
                        Call showMsg("Please specify either output period by month or date.", "")
                        Exit Sub
                    End If


                Else
                    ' Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
                        Dim date1, date2 As Date
                        date1 = Date.Parse(TextDateFrom.Text)
                        date2 = Date.Parse(TextDateTo.Text)
                        If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                            Call showMsg("Please verify from date and to date", "")
                            Exit Sub
                        End If
                    End If
                    'Need to interchange 
                    'Allow for any one of From / To 
                    If Len(DtFrom) > 5 And DtTo = "" Then
                        DtTo = DtFrom
                    End If
                    If DtFrom = "" And Len(DtTo) > 5 Then
                        DtFrom = DtTo
                    End If
                End If
                'FromDate Verification 
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
                'CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                '1st Find the records available on the specified by Month
                'Pass the paramters to Update in Datatabase
                Dim _SalesReportModel As SalesReportModel = New SalesReportModel()
                Dim _SalesReportControl As SalesReportControl = New SalesReportControl()
                Dim strFileName As String = ""
                _SalesReportModel.UserId = userid
                _SalesReportModel.UserName = userName
                _SalesReportModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _SalesReportModel.ShipToBranch = DropListLocation.SelectedItem.Text
                '''''''''''''''''''   _DebitNoteModel.SrcFileName = _DebitNoteModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '''
                'Pass type to identify the data
                Select Case drpTaskExport.SelectedValue
                    Case "2.1"
                        _SalesReportModel.SalesReportType = "InWarranty"
                    Case "2.2"
                        _SalesReportModel.SalesReportType = "OutWarranty"
                    Case "2.3"
                        _SalesReportModel.SalesReportType = "OtherSales"
                End Select

                If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                    'Need to find it by selected month
                    _SalesReportModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                    _SalesReportModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                    '' _InvoiceUpdateModel.SrcFileName = _InvoiceUpdateModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                    strFileName = _SalesReportModel.ShipToBranch & "_" & _SalesReportModel.Number & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Else


                    'Verify Date Format 
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
                    _SalesReportModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                    'DateConversion
                    Dim DtConvTo() As String
                    DtConvTo = Split(DtTo, "/")
                    If Len(DtConvTo(0)) = 1 Then
                        DtConvTo(0) = "0" & DtConvTo(0)
                    End If
                    If Len(DtConvTo(1)) = 1 Then
                        DtConvTo(1) = "0" & DtConvTo(1)
                    End If
                    _SalesReportModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                    strFileName = _SalesReportModel.ShipToBranch & "_" & _SalesReportModel.Number & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".csv"
                    ''  _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                End If


                'Temporary..........If 
                ''''''''''''''''''''''''Please remove after 3C done the coding
                '=========================================================================
                '========================================================================
                ''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''
                '''
                If (drpTaskExport.SelectedValue = "2.1") Or (drpTaskExport.SelectedValue = "2.2") Then ''''Remove after 3C coding completed
                    Dim dtSalesReportView As DataTable = _SalesReportControl.SelectSalesReport(_SalesReportModel)
                    If (dtSalesReportView Is Nothing) Or (dtSalesReportView.Rows.Count = 0) Then
                        'If no Records
                        Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                        Exit Sub
                    Else
                        Response.ContentType = "text/csv"
                        Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
                        Response.AddHeader("Pragma", "no-cache")
                        Response.AddHeader("Cache-Control", "no-cache")
                        Dim myData As Byte() = CommonControl.csvBytesWriter(dtSalesReportView)
                        Response.BinaryWrite(myData)
                        Response.Flush()
                        Response.SuppressContent = True
                        HttpContext.Current.ApplicationInstance.CompleteRequest()
                    End If
                Else '''Remove after 3C completed
                    ''''Call showMsg("Coming Soon.", "")
                    ''''Exit Sub
                    '''
                    Dim dtSalesReportView As DataTable = _SalesReportControl.SelectSalesReport(_SalesReportModel)
                    If (dtSalesReportView Is Nothing) Or (dtSalesReportView.Rows.Count = 0) Then
                        'If no Records
                        Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                        Exit Sub
                    Else
                        Response.ContentType = "text/csv"
                        Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
                        Response.AddHeader("Pragma", "no-cache")
                        Response.AddHeader("Cache-Control", "no-cache")
                        Dim myData As Byte() = CommonControl.csvBytesWriter(dtSalesReportView)
                        Response.BinaryWrite(myData)
                        Response.Flush()
                        Response.SuppressContent = True
                        HttpContext.Current.ApplicationInstance.CompleteRequest()
                    End If


                End If '''Remove after 3C completed


            ElseIf (drpTaskExport.SelectedValue = "3") Or (drpTaskExport.SelectedValue = "-3") Or (drpTaskExport.SelectedValue = "4") Then
                '********** Task 3A Start
                Dim DtFrom As String = ""
                Dim DtTo As String = ""
                DtFrom = Trim(TextDateFrom.Text)
                DtTo = Trim(TextDateTo.Text)
                'Task = 0 then Month wise filter
                'Task = 1 then From & To
                If Trim(DtFrom) = "" And Trim(DtTo) = "" And DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please specify either output period by month or date", "")
                    Exit Sub
                End If
                If Trim(DtFrom) <> "" And Trim(DtTo) <> "" And DropDownMonth.SelectedValue <> "0" Then
                    Call showMsg("Please specify either output period by month or date.", "")
                    Exit Sub
                End If
                If DropDownMonth.SelectedValue <> "0" Then
                    'Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 Or Len(Trim(DtTo)) > 7 Then
                        Call showMsg("Please specify either output period by month or date.", "")
                        Exit Sub
                    End If


                Else
                    ' Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
                        Dim date1, date2 As Date
                        date1 = Date.Parse(TextDateFrom.Text)
                        date2 = Date.Parse(TextDateTo.Text)
                        If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                            Call showMsg("Please verify from date and to date", "")
                            Exit Sub
                        End If
                    End If
                    'Need to interchange 
                    'Allow for any one of From / To 
                    If Len(DtFrom) > 5 And DtTo = "" Then
                        DtTo = DtFrom
                    End If
                    If DtFrom = "" And Len(DtTo) > 5 Then
                        DtFrom = DtTo
                    End If
                End If
                'FromDate Verification 
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

                'CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                '1st Find the records available on the specified by Month
                'Pass the paramters to Update in Datatabase
                Dim _InvoiceUpdateModel As InvoiceUpdateModel = New InvoiceUpdateModel()
                Dim _InvoiceUpdateControl As InvoiceUpdateControl = New InvoiceUpdateControl()
                Dim strFileName As String = ""
                _InvoiceUpdateModel.UserId = userid
                _InvoiceUpdateModel.UserName = userName
                _InvoiceUpdateModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _InvoiceUpdateModel.ShipToBranch = DropListLocation.SelectedItem.Text
                '''''''''''''''''''   _DebitNoteModel.SrcFileName = _DebitNoteModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '''
                'Pass Number to identify the data
                Dim strType As String = ""
                Select Case drpTaskExport.SelectedValue
                    Case "3"
                        _InvoiceUpdateModel.Number = "C"
                        strType = "IW"
                    Case "-3"
                        _InvoiceUpdateModel.Number = "EXC"
                        strType = "IW"
                    Case "4"
                        _InvoiceUpdateModel.Number = "OWC"
                        strType = "OOW"
                End Select

                If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                    'Need to find it by selected month
                    _InvoiceUpdateModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                    _InvoiceUpdateModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                    '' _InvoiceUpdateModel.SrcFileName = _InvoiceUpdateModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                    strFileName = _InvoiceUpdateModel.ShipToBranch & "_" & _InvoiceUpdateModel.Number & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Else


                    'Verify Date Format 
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
                    _InvoiceUpdateModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                    'DateConversion
                    Dim DtConvTo() As String
                    DtConvTo = Split(DtTo, "/")
                    If Len(DtConvTo(0)) = 1 Then
                        DtConvTo(0) = "0" & DtConvTo(0)
                    End If
                    If Len(DtConvTo(1)) = 1 Then
                        DtConvTo(1) = "0" & DtConvTo(1)
                    End If
                    _InvoiceUpdateModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                    strFileName = _InvoiceUpdateModel.ShipToBranch & "_" & _InvoiceUpdateModel.Number & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".csv"
                    ''  _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                End If




                Dim dtInvoiceUpdateView As DataTable = _InvoiceUpdateControl.SelectInvoiceUpdate(_InvoiceUpdateModel)
                If (dtInvoiceUpdateView Is Nothing) Or (dtInvoiceUpdateView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtInvoiceUpdateView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
                '********** Task 3A End
                '************************************************************************
                'ElseIf drpTaskExport.SelectedValue = "-3" Then

                'ElseIf drpTaskExport.SelectedValue = "4" Then


            ElseIf drpTaskExport.SelectedValue = "5" Then

                '''''''''''Verify Month is selected
                ''''''''''If DropDownMonth.SelectedValue = "0" Then
                ''''''''''    Call showMsg("Please select the month", "")
                ''''''''''    Exit Sub
                ''''''''''End If
                '''''''''''CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                '''''''''''1st Find the records available on the specified by Month
                '''''''''''Pass the paramters to Update in Datatabase
                ''''''''''Dim _OtherUpdateModel As OtherUpdateModel = New OtherUpdateModel()
                ''''''''''Dim _OtherUpdateControl As OtherUpdateControl = New OtherUpdateControl()
                ''''''''''_OtherUpdateModel.UserId = userid
                ''''''''''_OtherUpdateModel.UserName = userName
                ''''''''''_OtherUpdateModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                ''''''''''_OtherUpdateModel.ShipToBranch = DropListLocation.SelectedItem.Text
                ''''''''''_OtherUpdateModel.SrcFileName = _OtherUpdateModel.ShipToBranch & "_OU" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '''''''''''_OtherUpdateModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '''''''''''_OtherUpdateModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                ''''''''''Dim dtOtherUpdateView As DataTable = _OtherUpdateControl.SelectOtherUpdate(_OtherUpdateModel)
                ''''''''''If (dtOtherUpdateView Is Nothing) Or (dtOtherUpdateView.Rows.Count = 0) Then
                ''''''''''    'If no Records
                ''''''''''    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                ''''''''''    Exit Sub
                ''''''''''Else
                ''''''''''    Response.ContentType = "text/csv"
                ''''''''''    Response.AddHeader("Content-Disposition", "attachment;filename=" & DropListLocation.SelectedItem.Text & "_OU" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv")
                ''''''''''    Response.AddHeader("Pragma", "no-cache")
                ''''''''''    Response.AddHeader("Cache-Control", "no-cache")
                ''''''''''    Dim myData As Byte() = CommonControl.csvBytesWriter(dtOtherUpdateView)
                ''''''''''    Response.BinaryWrite(myData)
                ''''''''''    Response.Flush()
                ''''''''''    Response.SuppressContent = True
                ''''''''''    HttpContext.Current.ApplicationInstance.CompleteRequest()

                ''''''''''End If
                Dim DtFrom As String = ""
                Dim DtTo As String = ""
                DtFrom = Trim(TextDateFrom.Text)
                DtTo = Trim(TextDateTo.Text)
                'Task = 0 then Month wise filter
                'Task = 1 then From & To
                If Trim(DtFrom) = "" And Trim(DtTo) = "" And DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please specify either output period by month or date", "")
                    Exit Sub
                End If
                If Trim(DtFrom) <> "" And Trim(DtTo) <> "" And DropDownMonth.SelectedValue <> "0" Then
                    Call showMsg("Please specify either output period by month or date.", "")
                    Exit Sub
                End If
                If DropDownMonth.SelectedValue <> "0" Then
                    'Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 Or Len(Trim(DtTo)) > 7 Then
                        Call showMsg("Please specify either output period by month or date.", "")
                        Exit Sub
                    End If
                Else
                    ' Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
                        Dim date1, date2 As Date
                        date1 = Date.Parse(TextDateFrom.Text)
                        date2 = Date.Parse(TextDateTo.Text)
                        If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                            Call showMsg("Please verify from date and to date", "")
                            Exit Sub
                        End If
                    End If
                    'Need to interchange 
                    'Allow for any one of From / To 
                    If Len(DtFrom) > 5 And DtTo = "" Then
                        DtTo = DtFrom
                    End If
                    If DtFrom = "" And Len(DtTo) > 5 Then
                        DtFrom = DtTo
                    End If
                End If


                '''Verify Month is selected
                ''If (Trim(TextDateFrom.Text) = "") And (Trim(TextDateTo.Text) = "") Then
                ''    If (DropDownMonth.SelectedValue = "0") Then
                ''        Call showMsg("Please select the month", "")
                ''        Exit Sub
                ''    End If
                ''End If
                'FromDate Verification 
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

                'CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                '1st Find the records available on the specified by Month
                'Pass the paramters to Update in Datatabase
                Dim _DebitNoteModel As DebitNoteModel = New DebitNoteModel()
                Dim _DebitNoteControl As DebitNoteControl = New DebitNoteControl()
                Dim strFileName As String = ""
                _DebitNoteModel.UserId = userid
                _DebitNoteModel.UserName = userName
                _DebitNoteModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _DebitNoteModel.ShipToBranch = DropListLocation.SelectedItem.Text
                '''''''''''''''''''   _DebitNoteModel.SrcFileName = _DebitNoteModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '''
                If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                    'Need to find it by selected month
                    _DebitNoteModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                    _DebitNoteModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                    _DebitNoteModel.SrcFileName = _DebitNoteModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                    strFileName = _DebitNoteModel.SrcFileName
                Else

                    'Verify Date Format 
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
                    _DebitNoteModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                    'DateConversion
                    Dim DtConvTo() As String
                    DtConvTo = Split(DtTo, "/")
                    If Len(DtConvTo(0)) = 1 Then
                        DtConvTo(0) = "0" & DtConvTo(0)
                    End If
                    If Len(DtConvTo(1)) = 1 Then
                        DtConvTo(1) = "0" & DtConvTo(1)
                    End If
                    _DebitNoteModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                    strFileName = _DebitNoteModel.ShipToBranch & "_DB" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".csv"
                    ''  _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                End If



                '_OtherUpdateModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_OtherUpdateModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtDebitNoteView As DataTable = _DebitNoteControl.SelectDebitNote(_DebitNoteModel)
                If (dtDebitNoteView Is Nothing) Or (dtDebitNoteView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & DropListLocation.SelectedItem.Text & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv")
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtDebitNoteView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If




            ElseIf drpTaskExport.SelectedValue = "6" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                If DropDownDaySub.SelectedValue = "0" Then
                    Call showMsg("Please select the day", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _PrSummaryModel As PrSummaryModel = New PrSummaryModel()
                Dim _PrSummaryControl As PrSummaryControl = New PrSummaryControl()
                _PrSummaryModel.UserId = userid
                _PrSummaryModel.UserName = userName
                _PrSummaryModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _PrSummaryModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _PrSummaryModel.SrcFileName = _PrSummaryModel.ShipToBranch & "_SM" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & DropDownDaySub.SelectedValue & ".csv"
                ' _PrSummaryModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '  _PrSummaryModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtPrSummaryView As DataTable = _PrSummaryControl.SelectPrSummary(_PrSummaryModel)
                If (dtPrSummaryView Is Nothing) Or (dtPrSummaryView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & _PrSummaryModel.SrcFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtPrSummaryView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()

                End If

            ElseIf drpTaskExport.SelectedValue = "7" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                If DropDownDaySub.SelectedValue = "0" Then
                    Call showMsg("Please select the day", "")
                    Exit Sub
                End If
                'If DropDownDTSub.SelectedValue = "0" Then VJ 2019/10/24
                '    Call showMsg("Please select the DT", "")
                '    Exit Sub
                'End If ' VJ 2019/10/24
                'Pass the paramters to Update in Datatabase
                Dim DTsub As String
                If DropDownDTSub.SelectedValue = "0" Then
                    DTsub = "DT1DT2"
                Else
                    DTsub = DropDownDTSub.SelectedValue
                End If

                Dim _PrDetailModel As PrDetailModel = New PrDetailModel()
                Dim _PrDetailControl As PrDetailControl = New PrDetailControl()
                _PrDetailModel.UserId = userid
                _PrDetailModel.UserName = userName
                _PrDetailModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _PrDetailModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _PrDetailModel.SrcFileName = _PrDetailModel.ShipToBranch & "_" & DTsub & "-" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & DropDownDaySub.SelectedValue & ".csv"
                ' _PrSummaryModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '  _PrSummaryModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtPrDetailView As DataTable = _PrDetailControl.SelectPrDetail(_PrDetailModel)
                If (dtPrDetailView Is Nothing) Or (dtPrDetailView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & _PrDetailModel.SrcFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtPrDetailView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()

                End If

            ElseIf drpTaskExport.SelectedValue = "8" Then
                Dim Task As Integer = 0
                Dim DtFrom As String = ""
                Dim DtTo As String = ""

                DtFrom = Trim(TextDateFrom.Text)
                DtTo = Trim(TextDateTo.Text)

                'Task = 0 then Month wise filter
                'Task = 1 then From & To

                If Trim(DtFrom) = "" And Trim(DtTo) = "" And DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please specify either output period by month or date", "")
                    Exit Sub
                End If

                If Trim(DtFrom) <> "" And Trim(DtTo) <> "" And DropDownMonth.SelectedValue <> "0" Then
                    Call showMsg("Please specify either output period by month or date.", "")
                    Exit Sub
                End If

                If DropDownMonth.SelectedValue <> "0" Then
                    Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 Or Len(Trim(DtTo)) > 7 Then
                        Call showMsg("Please specify either output period by month or date.", "")
                        Exit Sub
                    End If



                Else
                    Task = 1 'Assign From or To or both filter

                    If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
                        Dim date1, date2 As Date
                        date1 = Date.Parse(TextDateFrom.Text)
                        date2 = Date.Parse(TextDateTo.Text)
                        If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                            Call showMsg("Please verify from date and to date", "")
                            Exit Sub
                        End If
                    End If

                    'Need to interchange 
                    'Allow for any one of From / To 
                    If Len(DtFrom) > 5 And DtTo = "" Then
                        DtTo = DtFrom
                    End If
                    If DtFrom = "" And Len(DtTo) > 5 Then
                        DtFrom = DtTo
                    End If

                End If


                '''Verify Month is selected
                ''If (Trim(TextDateFrom.Text) = "") And (Trim(TextDateTo.Text) = "") Then
                ''    If (DropDownMonth.SelectedValue = "0") Then
                ''        Call showMsg("Please select the month", "")
                ''        Exit Sub
                ''    End If
                ''End If
                'FromDate Verification 
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



                'Pass the paramters to Update in Datatabase
                Dim _GRecievedModel As GRecievedModel = New GRecievedModel()
                Dim _GRecievedControl As GRecievedControl = New GRecievedControl()
                Dim strFileName As String = ""
                _GRecievedModel.UserId = userid
                _GRecievedModel.UserName = userName
                _GRecievedModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _GRecievedModel.ShipToBranch = DropListLocation.SelectedItem.Text

                '_GRecievedModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_GRecievedModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)

                'Assign File Name and Month 
                If DropDownGR.SelectedItem.Value = "GR" Then
                    If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                        _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                        strFileName = _GRecievedModel.SrcFileName
                    Else
                        'DateConversion
                        Dim DtConvFrom() As String
                        DtConvFrom = Split(DtFrom, "/")
                        If Len(DtConvFrom(0)) = 1 Then
                            DtConvFrom(0) = "0" & DtConvFrom(0)
                        End If
                        If Len(DtConvFrom(1)) = 1 Then
                            DtConvFrom(1) = "0" & DtConvFrom(1)
                        End If
                        _GRecievedModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                        'DateConversion
                        Dim DtConvTo() As String
                        DtConvTo = Split(DtTo, "/")
                        If Len(DtConvTo(0)) = 1 Then
                            DtConvTo(0) = "0" & DtConvTo(0)
                        End If
                        If Len(DtConvTo(1)) = 1 Then
                            DtConvTo(1) = "0" & DtConvTo(1)
                        End If
                        _GRecievedModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                        strFileName = _GRecievedModel.ShipToBranch & "_GR" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".csv"
                        ''  _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                    End If
                ElseIf DropDownGR.SelectedItem.Value = "GD" Then
                    If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                        _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GD" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                        strFileName = _GRecievedModel.SrcFileName
                    Else
                        'DateConversion
                        Dim DtConvFrom() As String
                        DtConvFrom = Split(DtFrom, "/")
                        If Len(DtConvFrom(0)) = 1 Then
                            DtConvFrom(0) = "0" & DtConvFrom(0)
                        End If
                        If Len(DtConvFrom(1)) = 1 Then
                            DtConvFrom(1) = "0" & DtConvFrom(1)
                        End If
                        _GRecievedModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                        'DateConversion
                        Dim DtConvTo() As String
                        DtConvTo = Split(DtTo, "/")
                        If Len(DtConvTo(0)) = 1 Then
                            DtConvTo(0) = "0" & DtConvTo(0)
                        End If
                        If Len(DtConvTo(1)) = 1 Then
                            DtConvTo(1) = "0" & DtConvTo(1)
                        End If
                        _GRecievedModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                        strFileName = _GRecievedModel.ShipToBranch & "_GD" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".csv"
                        ''  _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                    End If

                End If


                If DropDownGR.SelectedItem.Value = "GR" Then
                    Dim dtGRecievedView As DataTable = _GRecievedControl.SelectGRecievedNew(_GRecievedModel)
                    If (dtGRecievedView Is Nothing) Or (dtGRecievedView.Rows.Count = 0) Then
                        'If no Records
                        Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                        Exit Sub
                    Else
                        'Comment on 2022-01-13
                        'Dim dt As New DataTable()
                        'dt.Columns.Add("No", GetType(String))
                        'dt.Columns.Add("Invoice No/", GetType(String))
                        'dt.Columns.Add("Invoice Date/", GetType(String))
                        'dt.Columns.Add("Local Invoice No", GetType(String))
                        'dt.Columns.Add("Items", GetType(String))
                        'dt.Columns.Add("Total Qty", GetType(String))
                        'dt.Columns.Add("Total Amount", GetType(String))
                        'dt.Columns.Add("GR Date", GetType(String))
                        'dt.Columns.Add("Create By", GetType(String))
                        'dt.Columns.Add("G/R Status", GetType(String))
                        '' dt.Rows.Add("No", "Invoice No/", "Invoice Date/", "Local Invoice No", "Items", "Total Qty", "Total Amount", "GR Date", "Create By", "G/R Status")
                        'dt.Rows.Add("", "Delivery No", "Delivery Date", "", "", "", "", "", "", "")
                        'For Each row As DataRow In dtGRecievedView.Rows
                        '    'Comment on 20220113
                        '    ' dt.Rows.Add(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9))
                        '    dt.Rows.Add(row.Item("NO"), row.Item("INVOICE_NO"), row.Item("INVOICE_DATE"), row.Item("LOCAL_INVOICE_NO"), row.Item("ITEMS"), row.Item("TOTAL_QTY"), row.Item("TOTAL_AMOUNT"), row.Item("GR_DATE"), row.Item("CREATE_BY"), row.Item("GR_STATUS"))
                        'Next row

                        Response.ContentType = "text/csv"
                        Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
                        Response.AddHeader("Pragma", "no-cache")
                        Response.AddHeader("Cache-Control", "no-cache")
                        'Comment on 2022-01-13
                        'Dim myData As Byte() = CommonControl.csvBytesWriter(dt)
                        Dim myData As Byte() = CommonControl.csvBytesWriter(dtGRecievedView)
                        Response.BinaryWrite(myData)
                        Response.Flush()
                        Response.SuppressContent = True
                        HttpContext.Current.ApplicationInstance.CompleteRequest()
                    End If
                ElseIf DropDownGR.SelectedItem.Value = "GD" Then 'Added on 20190724 , Goods Received Details
                    Dim dtGRecievedView As DataTable = _GRecievedControl.SelectGDRecieved(_GRecievedModel)
                    If (dtGRecievedView Is Nothing) Or (dtGRecievedView.Rows.Count = 0) Then
                        'If no Records
                        Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                        Exit Sub
                    Else
                        Response.ContentType = "text/csv"
                        Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
                        Response.AddHeader("Pragma", "no-cache")
                        Response.AddHeader("Cache-Control", "no-cache")
                        Dim myData As Byte() = CommonControl.csvBytesWriter(dtGRecievedView)
                        Response.BinaryWrite(myData)
                        Response.Flush()
                        Response.SuppressContent = True
                        HttpContext.Current.ApplicationInstance.CompleteRequest()
                    End If

                End If
            ElseIf drpTaskExport.SelectedValue = "9" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _StockOverviewModel As StockOverviewModel = New StockOverviewModel()
                Dim _StockOverviewControl As StockOverviewControl = New StockOverviewControl()
                _StockOverviewModel.UserId = userid
                _StockOverviewModel.UserName = userName
                _StockOverviewModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _StockOverviewModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _StockOverviewModel.SrcFileName = _StockOverviewModel.ShipToBranch & "_SV" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtStockOverviewView As DataTable = _StockOverviewControl.SelectStockOverview(_StockOverviewModel)
                If (dtStockOverviewView Is Nothing) Or (dtStockOverviewView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & _StockOverviewModel.SrcFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtStockOverviewView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If


            ElseIf drpTaskExport.SelectedValue = "9A" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _StockOverviewModel As StockOverviewModel = New StockOverviewModel()
                Dim _StockOverviewControl As StockOverviewControl = New StockOverviewControl()
                _StockOverviewModel.UserId = userid
                _StockOverviewModel.UserName = userName
                _StockOverviewModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _StockOverviewModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _StockOverviewModel.SrcFileName = _StockOverviewModel.ShipToBranch & "_SV" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtStockOverviewView As DataTable = _StockOverviewControl.SelectStockOverviewCount(_StockOverviewModel)
                If (dtStockOverviewView Is Nothing) Or (dtStockOverviewView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & _StockOverviewModel.ShipToBranch & "_SV" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & "C.csv")
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtStockOverviewView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If


            ElseIf drpTaskExport.SelectedValue = "10" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SawDiscountModel As SawDiscountModel = New SawDiscountModel()
                Dim _SawDiscountControl As SawDiscountControl = New SawDiscountControl()
                _SawDiscountModel.UserId = userid
                _SawDiscountModel.UserName = userName
                _SawDiscountModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _SawDiscountModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _SawDiscountModel.SrcFileName = _SawDiscountModel.ShipToBranch & "_SW" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSawDiscountView As DataTable = _SawDiscountControl.SelectSawDiscount(_SawDiscountModel)
                If (dtSawDiscountView Is Nothing) Or (dtSawDiscountView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & _SawDiscountModel.SrcFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtSawDiscountView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
            ElseIf drpTaskExport.SelectedValue = "11" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _PartsIoModel As PartsIoModel = New PartsIoModel()
                Dim _PartsIoControl As PartsIoControl = New PartsIoControl()
                _PartsIoModel.UserId = userid
                _PartsIoModel.UserName = userName
                _PartsIoModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _PartsIoModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _PartsIoModel.SrcFileName = _PartsIoModel.ShipToBranch & "_PIO" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '_GRecievedModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_GRecievedModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtPartsIoView As DataTable = _PartsIoControl.SelectPartsIo(_PartsIoModel)
                If (dtPartsIoView Is Nothing) Or (dtPartsIoView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Dim dt As New DataTable()
                    dt.Columns.Add("No", GetType(String))
                    dt.Columns.Add("Branch", GetType(String))
                    dt.Columns.Add("In/Out Date", GetType(String))
                    dt.Columns.Add("Type", GetType(String))
                    dt.Columns.Add("Type Description", GetType(String))
                    dt.Columns.Add("Ref.Doc.No", GetType(String))
                    dt.Columns.Add("Parts No", GetType(String))
                    dt.Columns.Add("Description", GetType(String))
                    dt.Columns.Add("Qty", GetType(String))
                    dt.Columns.Add("MAP", GetType(String))
                    dt.Columns.Add("Engineer Code", GetType(String))
                    dt.Columns.Add("In/Out", GetType(String))
                    dt.Columns.Add("Unit", GetType(String))
                    ' dt.Rows.Add("No", "Branch", "In/Out Date", "Type", "Type Description", "Ref.Doc.No", "Parts No", "Description", "Qty", "MAP", "Engineer Code", "In/Out", "Unit")
                    dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "Warranty", "")
                    For Each row As DataRow In dtPartsIoView.Rows
                        dt.Rows.Add(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11), row.Item(12))
                    Next row
                    Response.ContentType = "text/csv"
                    'DropDownYear.SelectedValue & "_" & DropDownMonth.SelectedValue & "_" & DropDownDaySub.SelectedValue & "-" & DropDownDaySub.SelectedValue & "_" & _PartsIoModel.ShipToBranch & "_PIO" & ".csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & DropDownYear.SelectedValue & "_" & DropDownMonth.SelectedValue & "_" & DropDownDaySub.SelectedValue & "-" & DropDownDaySub.SelectedValue & "_" & _PartsIoModel.ShipToBranch & "_PIO" & ".csv")
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dt)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
            ElseIf drpTaskExport.SelectedValue = "12" Then
                Call showMsg("Coming Soon...", "")
                Exit Sub
            ElseIf drpTaskExport.SelectedValue = "13" Then
                Call showMsg("Coming Soon...", "")
                Exit Sub
            ElseIf drpTaskExport.SelectedValue = "14" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _G2sPaidModel As G2sPaidModel = New G2sPaidModel()
                Dim _G2sPaidControl As G2sPaidControl = New G2sPaidControl()
                _G2sPaidModel.UserId = userid
                _G2sPaidModel.UserName = userName
                _G2sPaidModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _G2sPaidModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _G2sPaidModel.SrcFileName = _G2sPaidModel.ShipToBranch & "_GS" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '_G2sPaidModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_G2sPaidModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtG2sPaidView As DataTable = _G2sPaidControl.SelectG2sPaid(_G2sPaidModel)
                If (dtG2sPaidView Is Nothing) Or (dtG2sPaidView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & DropListLocation.SelectedItem.Text & "_GS" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv")
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtG2sPaidView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
            ElseIf drpTaskExport.SelectedValue = "15" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _ReturnCreditModel As ReturnCreditModel = New ReturnCreditModel()
                Dim _ReturnCreditControl As ReturnCreditControl = New ReturnCreditControl()
                _ReturnCreditModel.UserId = userid
                _ReturnCreditModel.UserName = userName
                _ReturnCreditModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _ReturnCreditModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _ReturnCreditModel.SrcFileName = _ReturnCreditModel.ShipToBranch & "_RC" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '_ReturnCreditModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_ReturnCreditModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtReturnCreditView As DataTable = _ReturnCreditControl.SelectReturnCredit(_ReturnCreditModel)
                If (dtReturnCreditView Is Nothing) Or (dtReturnCreditView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & _ReturnCreditModel.SrcFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtReturnCreditView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
            ElseIf drpTaskExport.SelectedValue = "16" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                If DropDownDaySub.SelectedValue = "0" Then
                    Call showMsg("Please select the day", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SLedgerModel As SLedgerModel = New SLedgerModel()
                Dim _SLedgerControl As SLedgerControl = New SLedgerControl()
                _SLedgerModel.UserId = userid
                _SLedgerModel.UserName = userName
                _SLedgerModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _SLedgerModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _SLedgerModel.SrcFileName = _SLedgerModel.ShipToBranch & "_LG" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & DropDownDaySub.SelectedValue & ".csv"
                Dim dtSLedgerView As DataTable = _SLedgerControl.SelectSLedger(_SLedgerModel)
                If (dtSLedgerView Is Nothing) Or (dtSLedgerView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & _SLedgerModel.SrcFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(dtSLedgerView)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
            ElseIf drpTaskExport.SelectedValue = "99" Then 'VJ 2019/10/14 Begin
            ElseIf drpTaskExport.SelectedValue = "18A" Then 'VJ 2019/10/14 Begin
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _DebitNoteRegisterModel As DebitNoteRegisterModel = New DebitNoteRegisterModel()
                Dim _DebitNoteRegisterControl As DebitNoteRegisterControl = New DebitNoteRegisterControl()
                _DebitNoteRegisterModel.UserId = userid
                _DebitNoteRegisterModel.UserName = userName
                _DebitNoteRegisterModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _DebitNoteRegisterModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _DebitNoteRegisterModel.SrcFileName = _DebitNoteRegisterModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '_ReturnCreditModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_ReturnCreditModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtDebitNoteRegisterView As DataTable = _DebitNoteRegisterControl.SelectDebitNoteRegister(_DebitNoteRegisterModel)
                If (dtDebitNoteRegisterView Is Nothing) Or (dtDebitNoteRegisterView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    ExportCSV(_DebitNoteRegisterModel.SrcFileName, dtDebitNoteRegisterView)
                    'Response.ContentType = "text/csv"
                    'Response.AddHeader("Content-Disposition", "attachment;filename=" & _DebitNoteRegisterModel.SrcFileName)
                    'Response.AddHeader("Pragma", "no-cache")
                    'Response.AddHeader("Cache-Control", "no-cache")
                    'Dim myData As Byte() = CommonControl.csvBytesWriter(dtDebitNoteRegisterView)
                    'Response.BinaryWrite(myData)
                    'Response.Flush()
                    'Response.SuppressContent = True
                    'HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
            ElseIf drpTaskExport.SelectedValue = "18" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _DebitNoteRegisterModel As DebitNoteRegisterModel = New DebitNoteRegisterModel()
                Dim _DebitNoteRegisterControl As DebitNoteRegisterControl = New DebitNoteRegisterControl()
                _DebitNoteRegisterModel.UserId = userid
                _DebitNoteRegisterModel.UserName = userName
                _DebitNoteRegisterModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _DebitNoteRegisterModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _DebitNoteRegisterModel.SrcFileName = _DebitNoteRegisterModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '_ReturnCreditModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_ReturnCreditModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtDebitNoteRegisterView As DataTable = _DebitNoteRegisterControl.SelectDebitNoteRegisterImportData(_DebitNoteRegisterModel)
                If (dtDebitNoteRegisterView Is Nothing) Or (dtDebitNoteRegisterView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    ExportCSV(_DebitNoteRegisterModel.SrcFileName, dtDebitNoteRegisterView)
                    'Response.ContentType = "text/csv"
                    'Response.AddHeader("Content-Disposition", "attachment;filename=" & _DebitNoteRegisterModel.SrcFileName)
                    'Response.AddHeader("Pragma", "no-cache")
                    'Response.AddHeader("Cache-Control", "no-cache")
                    'Dim myData As Byte() = CommonControl.csvBytesWriter(dtDebitNoteRegisterView)
                    'Response.BinaryWrite(myData)
                    'Response.Flush()
                    'Response.SuppressContent = True
                    'HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
            ElseIf drpTaskExport.SelectedValue = "19" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _ServicePartsReturnModel As ServicePartsReturnModel = New ServicePartsReturnModel()
                Dim _ServicePartsReturnControl As ServicePartsReturnControl = New ServicePartsReturnControl()
                _ServicePartsReturnModel.UserId = userid
                _ServicePartsReturnModel.UserName = userName
                _ServicePartsReturnModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _ServicePartsReturnModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _ServicePartsReturnModel.SrcFileName = _ServicePartsReturnModel.ShipToBranch & "_PR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '_ReturnCreditModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_ReturnCreditModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtServicePartsReturnrView As DataTable = _ServicePartsReturnControl.SelectServicePartsReturn(_ServicePartsReturnModel)
                If (dtServicePartsReturnrView Is Nothing) Or (dtServicePartsReturnrView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    ExportCSV(_ServicePartsReturnModel.SrcFileName, dtServicePartsReturnrView)
                    'Response.ContentType = "text/csv"
                    'Response.AddHeader("Content-Disposition", "attachment;filename=" & _ServicePartsReturnModel.SrcFileName)
                    'Response.AddHeader("Pragma", "no-cache")
                    'Response.AddHeader("Cache-Control", "no-cache")
                    'Dim myData As Byte() = CommonControl.csvBytesWriter(dtServicePartsReturnrView)
                    'Response.BinaryWrite(myData)
                    'Response.Flush()
                    'Response.SuppressContent = True
                    'HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If 'VJ 2019/10/14 End
            ElseIf drpTaskExport.SelectedValue = "19B" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _HSNCodeModel As HSNCodeModel = New HSNCodeModel()
                Dim _HSNCodeControl As HSNCodeControl = New HSNCodeControl()
                _HSNCodeModel.UserId = userid
                _HSNCodeModel.UserName = userName
                _HSNCodeModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _HSNCodeModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _HSNCodeModel.SrcFileName = DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtHSNCoderView As DataTable = _HSNCodeControl.SelectHSNCode(_HSNCodeModel)
                If (dtHSNCoderView Is Nothing) Or (dtHSNCoderView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    ExportCSV("Hsn-" & _HSNCodeModel.SrcFileName, dtHSNCoderView)

                End If
            ElseIf drpTaskExport.SelectedValue = "20" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _OtherSalesExtendedWarrantyModel As OtherSalesExtendedWarrantyModel = New OtherSalesExtendedWarrantyModel()
                Dim _OtherSalesExtendedWarrantyControl As OtherSalesExtendedWarrantyControl = New OtherSalesExtendedWarrantyControl()
                _OtherSalesExtendedWarrantyModel.UserId = userid
                _OtherSalesExtendedWarrantyModel.UserName = userName
                _OtherSalesExtendedWarrantyModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _OtherSalesExtendedWarrantyModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _OtherSalesExtendedWarrantyModel.SrcFileName = _OtherSalesExtendedWarrantyModel.ShipToBranch & "_EW" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '_ReturnCreditModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_ReturnCreditModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtSOtherSalesExtendedWarrantyView As DataTable = _OtherSalesExtendedWarrantyControl.SelectOtherSalesExtendedWarranty(_OtherSalesExtendedWarrantyModel)
                If (dtSOtherSalesExtendedWarrantyView Is Nothing) Or (dtSOtherSalesExtendedWarrantyView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    ExportCSV(_OtherSalesExtendedWarrantyModel.SrcFileName, dtSOtherSalesExtendedWarrantyView)
                End If 'Added 20191114
            ElseIf drpTaskExport.SelectedValue = "21" Then
                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _PoStatusModel As PoStatusModel = New PoStatusModel()
                Dim _PoStatusControl As PoStatusControl = New PoStatusControl()
                _PoStatusModel.UserId = userid
                _PoStatusModel.UserName = userName
                _PoStatusModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _PoStatusModel.ShipToBranch = DropListLocation.SelectedItem.Text
                _PoStatusModel.SrcFileName = _PoStatusModel.ShipToBranch & "_PS" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '_ReturnCreditModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/01"
                '_ReturnCreditModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                Dim dtPoStatusView As DataTable = _PoStatusControl.SelectPoStatus(_PoStatusModel)
                If (dtPoStatusView Is Nothing) Or (dtPoStatusView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    ExportCSV(_PoStatusModel.SrcFileName, dtPoStatusView)
                End If 'Added 20191114

            ElseIf (drpTaskExport.SelectedValue = "22") Then
                Dim DtFrom As String = ""
                Dim DtTo As String = ""
                Dim strFileName As String = ""
                DtFrom = Trim(TextDateFrom.Text)
                DtTo = Trim(TextDateTo.Text)
                'Task = 0 then Month wise filter
                'Task = 1 then From & To
                If Trim(DtFrom) = "" And Trim(DtTo) = "" And DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please specify either output period by month or date", "")
                    Exit Sub
                End If
                If Trim(DtFrom) <> "" And Trim(DtTo) <> "" And DropDownMonth.SelectedValue <> "0" Then
                    Call showMsg("Please specify either output period by month or date.", "")
                    Exit Sub
                End If
                If DropDownMonth.SelectedValue <> "0" Then
                    'Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 Or Len(Trim(DtTo)) > 7 Then
                        Call showMsg("Please specify either output period by month or date.", "")
                        Exit Sub
                    End If
                Else
                    ' Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
                        Dim date1, date2 As Date
                        date1 = Date.Parse(TextDateFrom.Text)
                        date2 = Date.Parse(TextDateTo.Text)
                        If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                            Call showMsg("Please verify from date and to date", "")
                            Exit Sub
                        End If
                    End If
                    'Need to interchange 
                    'Allow for any one of From / To 
                    If Len(DtFrom) > 5 And DtTo = "" Then
                        DtTo = DtFrom
                    End If
                    If DtFrom = "" And Len(DtTo) > 5 Then
                        DtFrom = DtTo
                    End If
                End If
                'FromDate Verification 

                Dim _ActivityModel As ActivityReportModel = New ActivityReportModel()
                Dim _ActivityControl As ActivityReportControl = New ActivityReportControl()
                If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                    'Need to find it by selected month
                    _ActivityModel.Month = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue
                    _ActivityModel.ServiceCentre = DropListLocation.SelectedItem.Text
                    _ActivityModel.location = DropListLocation.SelectedItem.Value
                    strFileName = DropListLocation.SelectedItem.Text & "_" & "ar" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                    _ActivityModel.SRC_FILE_NAME = DropListLocation.SelectedItem.Text & "_" & "ar" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue
                Else
                    _ActivityModel.location = DropListLocation.SelectedItem.Value
                    _ActivityModel.ServiceCentre = DropListLocation.SelectedItem.Text
                    Dim mon As String = DateAndTime.Month(DtFrom)
                    Dim year As String = DateAndTime.Year(DtFrom)
                    Dim Frmday As String = DateAndTime.Day(DtFrom)
                    If Frmday.Length = 1 Then
                        Frmday = "0" & Frmday
                    Else
                        Frmday = Frmday
                    End If
                    Dim fromday = Frmday
                    _ActivityModel.FromDay = fromday
                    Dim monto As String = DateAndTime.Month(DtTo)
                    Dim yearto As String = DateAndTime.Year(DtTo)
                    Dim dayTo As String = DateAndTime.Day(DtTo)
                    Dim tday As String

                    If dayTo.Length = 1 Then
                        tday = "0" & dayTo
                    Else
                        tday = dayTo
                    End If
                    tday = tday

                    _ActivityModel.ToDay = tday

                    If mon.Length = 1 Then
                        mon = "0" & mon
                    Else
                        mon = mon
                    End If
                    Dim FromMonth = year & "/" & mon

                    _ActivityModel.FromMonth = FromMonth
                    If monto.Length = 1 Then
                        monto = "0" & monto
                    Else
                        monto = monto
                    End If
                    Dim ToMonth = yearto & "/" & monto
                    _ActivityModel.ToMonth = ToMonth

                    If (Trim(DtFrom) <> "") Then

                    End If
                    If (Trim(DtTo) <> "") Then

                    End If
                    'Verify Date Format 
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
                    '  _ActivityModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                    'DateConversion
                    Dim DtConvTo() As String
                    DtConvTo = Split(DtTo, "/")
                    If Len(DtConvTo(0)) = 1 Then
                        DtConvTo(0) = "0" & DtConvTo(0)
                    End If
                    If Len(DtConvTo(1)) = 1 Then
                        DtConvTo(1) = "0" & DtConvTo(1)
                    End If
                    ' _ActivityModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                    strFileName = DropListLocation.SelectedItem.Text & "_" & "ar" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".csv"
                    _ActivityModel.SRC_FILE_NAME = DropListLocation.SelectedItem.Text & "_" & "ar" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1)
                    ''  _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                End If
                Dim _Datatable As DataTable = _ActivityControl.GetAnalysis_ReportDate(_ActivityModel)
                If (_Datatable Is Nothing) Or (_Datatable.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(_Datatable)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If
            ElseIf (drpTaskExport.SelectedValue = "23") Then
                'bharathiraja START

                Dim DtFrom As String = ""
                Dim DtTo As String = ""
                DtFrom = Trim(TextDateFrom.Text)
                DtTo = Trim(TextDateTo.Text)
                'Task = 0 then Month wise filter
                'Task = 1 then From & To
                If Trim(DtFrom) = "" And Trim(DtTo) = "" And DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please specify either output period by month or date", "")
                    Exit Sub
                End If
                If Trim(DtFrom) <> "" And Trim(DtTo) <> "" And DropDownMonth.SelectedValue <> "0" Then
                    Call showMsg("Please specify either output period by month or date.", "")
                    Exit Sub
                End If
                If DropDownMonth.SelectedValue <> "0" Then
                    'Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 Or Len(Trim(DtTo)) > 7 Then
                        Call showMsg("Please specify either output period by month or date.", "")
                        Exit Sub
                    End If


                Else
                    ' Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
                        Dim date1, date2 As Date
                        date1 = Date.Parse(TextDateFrom.Text)
                        date2 = Date.Parse(TextDateTo.Text)
                        If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                            Call showMsg("Please verify from date and to date", "")
                            Exit Sub
                        End If
                    End If
                    'Need to interchange 
                    'Allow for any one of From / To 
                    If Len(DtFrom) > 5 And DtTo = "" Then
                        DtTo = DtFrom
                    End If
                    If DtFrom = "" And Len(DtTo) > 5 Then
                        DtFrom = DtTo
                    End If
                End If
                'FromDate Verification 
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

                'CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                '1st Find the records available on the specified by Month
                'Pass the paramters to Update in Datatabase
                Dim _POModel As POModel = New POModel()
                Dim _POControl As POControl = New POControl()
                Dim strFileName As String = ""
                _POModel.UserId = userid
                _POModel.UserName = userName
                _POModel.ShipToBranchCode = DropListLocation.SelectedItem.Value
                _POModel.ShipToBranch = DropListLocation.SelectedItem.Text
                '''''''''''''''''''   _DebitNoteModel.SrcFileName = _DebitNoteModel.ShipToBranch & "_DN" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                '''


                If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                    'Need to find it by selected month
                    _POModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                    _POModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                    Dim DtConvTo() As String
                    If _POModel.DateTo.Contains("-") = True Then
                        DtConvTo = Split(_POModel.DateTo, "-")
                        If Len(DtConvTo(0)) = 1 Then
                            DtConvTo(0) = "0" & DtConvTo(0)
                        End If
                        If Len(DtConvTo(1)) = 1 Then
                            DtConvTo(1) = "0" & DtConvTo(1)
                        End If
                        _POModel.DateTo = DtConvTo(2) & "/" & DtConvTo(1) & "/" & DtConvTo(0)

                    Else
                        DtConvTo = Split(_POModel.DateTo, "/")
                        If Len(DtConvTo(0)) = 1 Then
                            DtConvTo(0) = "0" & DtConvTo(0)
                        End If
                        If Len(DtConvTo(1)) = 1 Then
                            DtConvTo(1) = "0" & DtConvTo(1)
                        End If
                        ' _POModel.DateTo = DtConvTo(2) & "/" & DtConvTo(1) & "/" & DtConvTo(0)
                        _POModel.DateTo = DtConvTo(0) & "/" & DtConvTo(1) & "/" & DtConvTo(2)
                    End If
                    strFileName = _POModel.ShipToBranch & "_" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                Else


                    'Verify Date Format 
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
                    _POModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                    'DateConversion
                    Dim DtConvTo() As String
                    DtConvTo = Split(DtTo, "/")
                    If Len(DtConvTo(0)) = 1 Then
                        DtConvTo(0) = "0" & DtConvTo(0)
                    End If
                    If Len(DtConvTo(1)) = 1 Then
                        DtConvTo(1) = "0" & DtConvTo(1)
                    End If
                    '_POModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                    _POModel.DateTo = DtConvTo(0) & "/" & DtConvTo(2) & "/" & DtConvTo(1)
                    strFileName = _POModel.ShipToBranch & "_" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".xls"
                End If


                Dim DtConvFromSplit() As String
                DtConvFromSplit = Split(_POModel.DateFrom, "/")

                Dim isNotExistsRecord As Integer = 0
                'PO 1   (po_dc)
                Dim dtPurchaseAmount As DataTable = _POControl.POPurchaseAmount(_POModel)
                If (dtPurchaseAmount Is Nothing) Or (dtPurchaseAmount.Rows.Count = 0) Then
                    'If no Records
                    isNotExistsRecord = isNotExistsRecord + 1
                End If

                'Consumption GD Parts 2   (SC_DSR)
                Dim IWOWValue As String = ConfigurationManager.AppSettings("IWOWValue")
                Dim dtGDParts As DataTable = _POControl.POGDParts(_POModel, IWOWValue)
                If (dtGDParts Is Nothing) Or (dtGDParts.Rows.Count = 0) Then
                    'If no Records
                    isNotExistsRecord = isNotExistsRecord + 1
                End If

                'Return 3      (SP_RETURN)
                Dim dtReturn As DataTable = _POControl.POReturn(_POModel)
                If (dtReturn Is Nothing) Or (dtReturn.Rows.Count = 0) Then
                    'If no Records
                    isNotExistsRecord = isNotExistsRecord + 1
                End If

                'Payment
                Dim dtPayment As DataTable = _POControl.POPayment(_POModel)
                If (dtPayment Is Nothing) Or (dtPayment.Rows.Count = 0) Then
                    'If no Records
                    isNotExistsRecord = isNotExistsRecord + 1
                End If


                'Collections
                Dim dtCollections As DataTable = _POControl.POCollections(_POModel)
                If (dtCollections Is Nothing) Or (dtCollections.Rows.Count = 0) Then
                    'If no Records
                    isNotExistsRecord = isNotExistsRecord + 1
                End If


                'BillingInformations
                Dim dtBillingInformation As DataTable = _POControl.POBillingInformation(_POModel)
                If (dtBillingInformation Is Nothing) Or (dtBillingInformation.Rows.Count = 0) Then
                    'If no Records
                    isNotExistsRecord = isNotExistsRecord + 1
                End If


                If (isNotExistsRecord = 6) Then
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                End If



                Dim CurrentMonthYear As String
                CurrentMonthYear = MonthName(DateAndTime.Now.Month) + Convert.ToString(DateAndTime.Now.Year)



                Dim SelectedMonthYear As String
                SelectedMonthYear = MonthName(DtConvFromSplit(1)) + Convert.ToString(DtConvFromSplit(0))




                'Generating Dates based on Month                
                Dim Po_Confirmation_Table As DataTable = New DataTable()
                Po_Confirmation_Table = GetDates(Convert.ToInt32(DtConvFromSplit(0)), Convert.ToInt32(DtConvFromSplit(1)))

                'PO
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim drPurchaseAmount As DataRow() = dtPurchaseAmount.[Select]("PO_Date= '" & drPA.ItemArray(0) & "'")
                    If drPurchaseAmount.Length <> 0 Then
                        If drPurchaseAmount(0).ItemArray(1) IsNot DBNull.Value Then
                            If SelectedMonthYear = CurrentMonthYear Then
                                If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                                    drPA("Daily Amount") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drPurchaseAmount(0).ItemArray(1))))
                                    drPA("Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drPurchaseAmount(0).ItemArray(1)))
                                    Exit For
                                ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                                    Exit For
                                Else
                                    drPA("Daily Amount") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drPurchaseAmount(0).ItemArray(1))))
                                    drPA("Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drPurchaseAmount(0).ItemArray(1)))
                                End If

                            Else
                                drPA("Daily Amount") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drPurchaseAmount(0).ItemArray(1))))
                                drPA("Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drPurchaseAmount(0).ItemArray(1)))
                            End If

                        End If

                    End If
                Next
                Po_Confirmation_Table.AcceptChanges()


                'Return
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim drReturn As DataRow() = dtReturn.[Select]("REQUEST_DATE= '" & drPA.ItemArray(0) & "'")
                    If drReturn.Length <> 0 Then
                        If dtReturn(0).ItemArray(1) IsNot DBNull.Value Then

                            If SelectedMonthYear = CurrentMonthYear Then
                                If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                                    drPA("PO Return") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drReturn(0).ItemArray(1))))
                                    drPA("PO Return2") = Convert.ToDecimal(String.Format("{0:0.00}", drReturn(0).ItemArray(1)))
                                    Exit For
                                ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                                    Exit For
                                Else
                                    drPA("PO Return") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drReturn(0).ItemArray(1))))
                                    drPA("PO Return2") = Convert.ToDecimal(String.Format("{0:0.00}", drReturn(0).ItemArray(1)))
                                End If

                            Else
                                drPA("PO Return") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drReturn(0).ItemArray(1))))
                                drPA("PO Return2") = Convert.ToDecimal(String.Format("{0:0.00}", drReturn(0).ItemArray(1)))

                            End If
                        End If
                    End If
                Next
                Po_Confirmation_Table.AcceptChanges()

                'PO Month
                Dim Month As Decimal
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim DailyAmount As Decimal
                    Dim POReturn As Decimal
                    If SelectedMonthYear = CurrentMonthYear Then
                        If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                            If Convert.ToString(drPA("Month")) = "0.00" Then
                                DailyAmount = drPA("Daily Amount")
                                POReturn = drPA("PO Return")

                                Month = Month + DailyAmount - POReturn
                                If Month = Convert.ToDecimal(0.00) Then
                                    drPA("Month") = String.Format("{0:0.00}", Month)
                                    drPA("Month2") = String.Format("{0:0.00}", Month)
                                    Exit For
                                Else

                                    drPA("Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Month)))
                                    drPA("Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Month))
                                    Exit For
                                End If
                            End If
                        ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                            Exit For
                        Else
                            If Convert.ToString(drPA("Month")) = "0.00" Then
                                DailyAmount = drPA("Daily Amount")
                                POReturn = drPA("PO Return")

                                Month = Month + DailyAmount - POReturn
                                If Month = Convert.ToDecimal(0.00) Then
                                    drPA("Month") = String.Format("{0:0.00}", Month)
                                    drPA("Month2") = String.Format("{0:0.00}", Month)
                                Else

                                    drPA("Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Month)))
                                    drPA("Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Month))
                                End If
                            End If
                        End If
                    Else
                        If Convert.ToString(drPA("Month")) = "0.00" Then
                            DailyAmount = drPA("Daily Amount")
                            POReturn = drPA("PO Return")

                            Month = Month + DailyAmount - POReturn
                            If Month = Convert.ToDecimal(0.00) Then
                                drPA("Month") = String.Format("{0:0.00}", Month)
                                drPA("Month2") = String.Format("{0:0.00}", Month)
                            Else

                                drPA("Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Month)))
                                drPA("Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Month))
                            End If
                        End If
                    End If
                Next
                Month = 0.0
                Po_Confirmation_Table.AcceptChanges()


                'Billing Informtion Daily Amount
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim drBillingInformation As DataRow() = dtBillingInformation.[Select]("INVOICE_DATE= '" & drPA.ItemArray(0) & "'")
                    If drBillingInformation.Length <> 0 Then
                        If drBillingInformation(0).ItemArray(1) IsNot DBNull.Value Then
                            If SelectedMonthYear = CurrentMonthYear Then
                                If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                                    drPA("Billing Daily Amount") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drBillingInformation(0).ItemArray(1))))
                                    drPA("Billing Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drBillingInformation(0).ItemArray(1)))
                                    Exit For
                                ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                                    Exit For
                                Else
                                    drPA("Billing Daily Amount") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drBillingInformation(0).ItemArray(1))))
                                    drPA("Billing Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drBillingInformation(0).ItemArray(1)))
                                End If
                            Else
                                drPA("Billing Daily Amount") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drBillingInformation(0).ItemArray(1))))
                                drPA("Billing Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drBillingInformation(0).ItemArray(1)))
                            End If
                        End If
                    End If
                Next
                Po_Confirmation_Table.AcceptChanges()


                'Billing Information Month
                Dim Billing_Month As Decimal
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim Billing_Daily_Amount As Decimal
                    If SelectedMonthYear = CurrentMonthYear Then
                        If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                            If Convert.ToString(drPA("Billing Daily Amount")) = "0.00" Then
                                Billing_Daily_Amount = drPA("Billing Daily Amount")
                                Billing_Month = Billing_Month + Billing_Daily_Amount

                                If Billing_Month = Convert.ToDecimal(0.00) Then
                                    drPA("Billing Month") = String.Format("{0:0.00}", Billing_Month)
                                    drPA("Billing Month2") = String.Format("{0:0.00}", Billing_Month)
                                    Exit For
                                Else

                                    'drPA("Consumption_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                    drPA("Billing Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Billing_Month)))
                                    drPA("Billing Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Billing_Month))
                                    Exit For
                                End If
                            End If
                        ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                            Exit For
                        Else
                            If Convert.ToString(drPA("Consumption Month")) = "0.00" Then
                                Billing_Daily_Amount = drPA("Billing Daily Amount")
                                Billing_Month = Billing_Month + Billing_Daily_Amount
                                If Billing_Month = Convert.ToDecimal(0.00) Then
                                    drPA("Billing Month") = String.Format("{0:0.00}", Billing_Month)
                                    drPA("Billing Month2") = String.Format("{0:0.00}", Billing_Month)
                                Else

                                    'drPA("Consumption_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                    drPA("Billing Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Billing_Month)))
                                    drPA("Billing Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Billing_Month))
                                End If
                            End If
                        End If
                    Else
                        If Convert.ToString(drPA("Consumption Month")) = "0.00" Then
                            Billing_Daily_Amount = drPA("Billing Daily Amount")
                            Billing_Month = Billing_Month + Billing_Daily_Amount
                            If Billing_Month = Convert.ToDecimal(0.00) Then
                                drPA("Billing Month") = String.Format("{0:0.00}", Billing_Month)
                                drPA("Billing Month2") = String.Format("{0:0.00}", Billing_Month)
                            Else

                                'drPA("Consumption_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                drPA("Billing Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Billing_Month)))
                                drPA("Billing Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Billing_Month))
                            End If
                        End If
                    End If
                Next
                Billing_Month = 0.0
                Po_Confirmation_Table.AcceptChanges()


                'Consumption Daily Amount
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim drGDParts As DataRow() = dtGDParts.[Select]("Billing_date= '" & drPA.ItemArray(0) & "'")
                    If drGDParts.Length <> 0 Then
                        If drGDParts(0).ItemArray(1) IsNot DBNull.Value Then
                            If SelectedMonthYear = CurrentMonthYear Then
                                If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                                    'drPA("Consumption_Daily_Amount") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drGDParts(0).ItemArray(1))))
                                    drPA("Consumption Daily Amount") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drGDParts(0).ItemArray(1))))
                                    drPA("Consumption Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drGDParts(0).ItemArray(1)))
                                    Exit For
                                ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                                    Exit For
                                Else
                                    drPA("Consumption Daily Amount") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drGDParts(0).ItemArray(1))))
                                    drPA("Consumption Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drGDParts(0).ItemArray(1)))
                                End If
                            Else
                                drPA("Consumption Daily Amount") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drGDParts(0).ItemArray(1))))
                                drPA("Consumption Daily Amount2") = Convert.ToDecimal(String.Format("{0:0.00}", drGDParts(0).ItemArray(1)))
                            End If
                        End If
                    End If
                Next
                Po_Confirmation_Table.AcceptChanges()


                'Consumption Month
                Dim Consumption_Month As Decimal
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim Consumption_Daily_Amount As Decimal
                    If SelectedMonthYear = CurrentMonthYear Then
                        If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                            If Convert.ToString(drPA("Consumption Month")) = "0.00" Then
                                Consumption_Daily_Amount = drPA("Consumption Daily Amount")
                                Consumption_Month = Consumption_Month + Consumption_Daily_Amount

                                If Consumption_Month = Convert.ToDecimal(0.00) Then
                                    drPA("Consumption Month") = String.Format("{0:0.00}", Consumption_Month)
                                    drPA("Consumption Month2") = String.Format("{0:0.00}", Consumption_Month)
                                    Exit For
                                Else

                                    'drPA("Consumption_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                    drPA("Consumption Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                    drPA("Consumption Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month))
                                    Exit For
                                End If
                            End If
                        ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                            Exit For
                        Else
                            If Convert.ToString(drPA("Consumption Month")) = "0.00" Then
                                Consumption_Daily_Amount = drPA("Consumption Daily Amount")
                                Consumption_Month = Consumption_Month + Consumption_Daily_Amount
                                If Consumption_Month = Convert.ToDecimal(0.00) Then
                                    drPA("Consumption Month") = String.Format("{0:0.00}", Consumption_Month)
                                    drPA("Consumption Month2") = String.Format("{0:0.00}", Consumption_Month)
                                Else

                                    'drPA("Consumption_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                    drPA("Consumption Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                    drPA("Consumption Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month))
                                End If
                            End If
                        End If
                    Else
                        If Convert.ToString(drPA("Consumption Month")) = "0.00" Then
                            Consumption_Daily_Amount = drPA("Consumption Daily Amount")
                            Consumption_Month = Consumption_Month + Consumption_Daily_Amount
                            If Consumption_Month = Convert.ToDecimal(0.00) Then
                                drPA("Consumption Month") = String.Format("{0:0.00}", Consumption_Month)
                                drPA("Consumption Month2") = String.Format("{0:0.00}", Consumption_Month)
                            Else

                                'drPA("Consumption_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                drPA("Consumption Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month)))
                                drPA("Consumption Month2") = Convert.ToDecimal(String.Format("{0:0.00}", Consumption_Month))
                            End If
                        End If
                    End If
                Next
                Consumption_Month = 0.0
                Po_Confirmation_Table.AcceptChanges()



                'Collections Daily Deposit
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim drCollections As DataRow() = dtCollections.[Select]("TARGET_DATE= '" & drPA.ItemArray(0) & "'")
                    If drCollections.Length <> 0 Then
                        If drCollections(0).ItemArray(1) IsNot DBNull.Value Then
                            If SelectedMonthYear = CurrentMonthYear Then
                                If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                                    If Convert.ToString(drCollections(0).ItemArray(1)) = "0.00" Then
                                        drPA("Daily Deposit") = String.Format("{0:0.00}", drCollections(0).ItemArray(1))
                                        drPA("Daily Deposit2") = String.Format("{0:0.00}", drCollections(0).ItemArray(1))
                                        Exit For
                                    Else
                                        'drPA("Daily_Deposit") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1))))
                                        drPA("Daily Deposit") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1))))
                                        drPA("Daily Deposit2") = Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1)))
                                        Exit For

                                    End If
                                ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                                    Exit For
                                Else
                                    If Convert.ToString(drCollections(0).ItemArray(1)) = "0.00" Then
                                        drPA("Daily Deposit") = String.Format("{0:0.00}", drCollections(0).ItemArray(1))
                                        drPA("Daily Deposit2") = String.Format("{0:0.00}", drCollections(0).ItemArray(1))
                                    Else
                                        'drPA("Daily_Deposit") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1))))
                                        drPA("Daily Deposit") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1))))
                                        drPA("Daily Deposit2") = Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1)))
                                    End If
                                End If
                            Else
                                If Convert.ToString(drCollections(0).ItemArray(1)) = "0.00" Then
                                    drPA("Daily Deposit") = String.Format("{0:0.00}", drCollections(0).ItemArray(1))
                                    drPA("Daily Deposit2") = String.Format("{0:0.00}", drCollections(0).ItemArray(1))
                                Else

                                    drPA("Daily Deposit") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1))))
                                    drPA("Daily Deposit2") = Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1)))
                                End If

                            End If
                        End If
                    End If
                Next
                Po_Confirmation_Table.AcceptChanges()


                'Collection Credit Sales
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim drCollections As DataRow() = dtCollections.[Select]("TARGET_DATE= '" & drPA.ItemArray(0) & "'")
                    If drCollections.Length <> 0 Then
                        If drCollections(0).ItemArray(2) IsNot DBNull.Value Then
                            If SelectedMonthYear = CurrentMonthYear Then
                                If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then

                                    If Convert.ToString(drCollections(0).ItemArray(2)) = "0.00" Then
                                        drPA("Credit Sales") = String.Format("{0:0.00}", drCollections(0).ItemArray(2))
                                        drPA("Credit Sales2") = String.Format("{0:0.00}", drCollections(0).ItemArray(2))
                                        Exit For
                                    Else
                                        'drPA("Daily_Deposit") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1))))
                                        drPA("Credit Sales") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(2))))
                                        drPA("Credit Sales2") = Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(2)))
                                        Exit For
                                    End If
                                ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                                    Exit For
                                Else
                                    If Convert.ToString(drCollections(0).ItemArray(2)) = "0.00" Then
                                        drPA("Credit Sales") = String.Format("{0:0.00}", drCollections(0).ItemArray(2))
                                        drPA("Credit Sales2") = String.Format("{0:0.00}", drCollections(0).ItemArray(2))
                                    Else
                                        'drPA("Daily_Deposit") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(1))))
                                        drPA("Credit Sales") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(2))))
                                        drPA("Credit Sales2") = Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(2)))
                                    End If
                                End If
                            Else
                                If Convert.ToString(drCollections(0).ItemArray(2)) = "0.00" Then
                                    drPA("Credit Sales") = String.Format("{0:0.00}", drCollections(0).ItemArray(2))
                                    drPA("Credit Sales2") = String.Format("{0:0.00}", drCollections(0).ItemArray(2))
                                Else
                                    drPA("Credit Sales") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(2))))
                                    drPA("Credit Sales2") = Convert.ToDecimal(String.Format("{0:0.00}", drCollections(0).ItemArray(2)))
                                End If
                            End If
                        End If
                    End If
                Next
                Po_Confirmation_Table.AcceptChanges()




                'Collections Month
                Dim CollectionsMonth As Decimal
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim DailyDeposit As Decimal
                    Dim CreditSales As Decimal
                    If SelectedMonthYear = CurrentMonthYear Then
                        If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then

                            If Convert.ToString(drPA("Collections Month")) = "0.00" Then
                                DailyDeposit = drPA("Daily Deposit")
                                CreditSales = drPA("Credit Sales")
                                CollectionsMonth = CollectionsMonth + DailyDeposit + CreditSales
                                If CollectionsMonth = Convert.ToDecimal(0.00) Then
                                    drPA("Collections Month") = String.Format("{0:0.00}", CollectionsMonth)
                                    drPA("Collections Month2") = String.Format("{0:0.00}", CollectionsMonth)
                                    Exit For
                                Else
                                    'drPA("Collections_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth)))
                                    drPA("Collections Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth)))
                                    drPA("Collections Month2") = Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth))
                                    Exit For
                                End If
                            End If

                        ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                            Exit For
                        Else
                            If Convert.ToString(drPA("Collections Month")) = "0.00" Then
                                DailyDeposit = drPA("Daily Deposit")
                                CreditSales = drPA("Credit Sales")
                                CollectionsMonth = CollectionsMonth + DailyDeposit + CreditSales
                                If CollectionsMonth = Convert.ToDecimal(0.00) Then
                                    drPA("Collections Month") = String.Format("{0:0.00}", CollectionsMonth)
                                    drPA("Collections Month2") = String.Format("{0:0.00}", CollectionsMonth)
                                Else
                                    'drPA("Collections_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth)))
                                    drPA("Collections Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth)))
                                    drPA("Collections Month2") = Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth))
                                End If
                            End If

                        End If
                    Else
                        If Convert.ToString(drPA("Collections Month")) = "0.00" Then
                            DailyDeposit = drPA("Daily Deposit")
                            CreditSales = drPA("Credit Sales")
                            CollectionsMonth = CollectionsMonth + DailyDeposit + CreditSales
                            If CollectionsMonth = Convert.ToDecimal(0.00) Then
                                drPA("Collections Month") = String.Format("{0:0.00}", CollectionsMonth)
                                drPA("Collections Month2") = String.Format("{0:0.00}", CollectionsMonth)
                            Else
                                'drPA("Collections_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth)))
                                drPA("Collections Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth)))
                                drPA("Collections Month2") = Convert.ToDecimal(String.Format("{0:0.00}", CollectionsMonth))
                            End If
                        End If

                    End If
                Next
                CollectionsMonth = 0.0
                Po_Confirmation_Table.AcceptChanges()


                'Payment Daily
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim drPayment As DataRow() = dtPayment.[Select]("TARGET_DATE= '" & drPA.ItemArray(0) & "'")
                    If drPayment.Length <> 0 Then
                        If drPayment(0).ItemArray(1) IsNot DBNull.Value Then

                            'drPA("Daily") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", drPayment(0).ItemArray(1))))
                            If SelectedMonthYear = CurrentMonthYear Then
                                If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                                    drPA("Daily") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drPayment(0).ItemArray(1))))
                                    drPA("Daily2") = Convert.ToDecimal(String.Format("{0:0.00}", drPayment(0).ItemArray(1)))
                                    Exit For
                                Else
                                    drPA("Daily") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drPayment(0).ItemArray(1))))
                                    drPA("Daily2") = Convert.ToDecimal(String.Format("{0:0.00}", drPayment(0).ItemArray(1)))
                                End If
                            ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                                Exit For
                            Else
                                drPA("Daily") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", drPayment(0).ItemArray(1))))
                                drPA("Daily2") = Convert.ToDecimal(String.Format("{0:0.00}", drPayment(0).ItemArray(1)))
                            End If
                        End If
                    End If
                Next
                Po_Confirmation_Table.AcceptChanges()


                'Payment Month
                Dim GssPayment_Month As Decimal
                For Each drPA As DataRow In Po_Confirmation_Table.Rows
                    Dim Daily As Decimal

                    If SelectedMonthYear = CurrentMonthYear Then
                        If DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") = drPA.ItemArray(0) Then
                            If Convert.ToString(drPA("GssPayment Month")) = "0.00" Then
                                Daily = drPA("Daily")
                                GssPayment_Month = GssPayment_Month + Daily
                                If GssPayment_Month = Convert.ToDecimal(0.00) Then
                                    drPA("GssPayment Month") = String.Format("{0:0.00}", GssPayment_Month)
                                    drPA("GssPayment Month2") = String.Format("{0:0.00}", GssPayment_Month)
                                    Exit For
                                Else
                                    ' drPA("GssPayment_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month)))
                                    drPA("GssPayment Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month)))
                                    drPA("GssPayment Month2") = Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month))
                                    Exit For
                                End If
                            End If
                        ElseIf drPA.ItemArray(0) > DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/") Then
                            Exit For
                        Else
                            If Convert.ToString(drPA("GssPayment Month")) = "0.00" Then
                                Daily = drPA("Daily")
                                GssPayment_Month = GssPayment_Month + Daily
                                If GssPayment_Month = Convert.ToDecimal(0.00) Then
                                    drPA("GssPayment Month") = String.Format("{0:0.00}", GssPayment_Month)
                                    drPA("GssPayment Month2") = String.Format("{0:0.00}", GssPayment_Month)
                                Else
                                    ' drPA("GssPayment_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month)))
                                    drPA("GssPayment Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month)))
                                    drPA("GssPayment Month2") = Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month))
                                End If
                            End If
                        End If
                    Else
                        If Convert.ToString(drPA("GssPayment Month")) = "0.00" Then
                            Daily = drPA("Daily")
                            GssPayment_Month = GssPayment_Month + Daily
                            If GssPayment_Month = Convert.ToDecimal(0.00) Then
                                drPA("GssPayment Month") = String.Format("{0:0.00}", GssPayment_Month)
                                drPA("GssPayment Month2") = String.Format("{0:0.00}", GssPayment_Month)
                            Else
                                ' drPA("GssPayment_Month") = String.Format("{0:#,##0.############}", Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month)))
                                drPA("GssPayment Month") = String.Format("{0:#,0.00}", Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month)))
                                drPA("GssPayment Month2") = Convert.ToDecimal(String.Format("{0:0.00}", GssPayment_Month))
                            End If
                        End If
                    End If
                Next
                Consumption_Month = 0.0
                Po_Confirmation_Table.AcceptChanges()


                Po_Confirmation_Table.Columns.Remove("Daily Amount2")
                Po_Confirmation_Table.Columns.Remove("PO Return2")
                Po_Confirmation_Table.Columns.Remove("Month2")

                Po_Confirmation_Table.Columns.Remove("Billing Daily Amount2")
                Po_Confirmation_Table.Columns.Remove("Billing Month2")

                Po_Confirmation_Table.Columns.Remove("Consumption Daily Amount2")
                Po_Confirmation_Table.Columns.Remove("Consumption Month2")
                Po_Confirmation_Table.Columns.Remove("Daily Deposit2")
                Po_Confirmation_Table.Columns.Remove("Credit Sales2")
                Po_Confirmation_Table.Columns.Remove("Collections Month2")
                Po_Confirmation_Table.Columns.Remove("Daily2")
                Po_Confirmation_Table.Columns.Remove("GssPayment Month2")


                Po_Confirmation_Table.AcceptChanges()
                Dim strText As String = ""

                strText = ExportDatatableToHtmlForPO(Po_Confirmation_Table, strFileName)
                ExportExcel(strFileName, strText)
                'bharathiraja END

            ElseIf (drpTaskExport.SelectedValue = "24") Then
                '24.Samsung to GSS paid (BOI)

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _BoiModel As BoiModel = New BoiModel()
                Dim _BoiControl As BoiControl = New BoiControl()
                _BoiModel.UserId = userid
                _BoiModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _BoiModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _BoiModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _BoiModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtBoiModelView As DataTable = _BoiControl.SelectBoi(_BoiModel)

                If (dtBoiModelView Is Nothing) Or (dtBoiModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_BoiModel.FileName, dtBoiModelView)
                End If '

            ElseIf (drpTaskExport.SelectedValue = "25") Then
                '24.Account Report

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If

                Dim _AccountReportModel As AccountReport = New AccountReport()
                Dim _AccountReportControl As AccountReportControl = New AccountReportControl()
                'Dim strFileName As String = "Account Report_" + DropListLocation.SelectedItem.Text + "_" + DropDownMonth.SelectedItem.Text + "_" + DropDownYear.SelectedValue + ".csv"
                Dim strFileName As String = "Account Report_" + DropListLocation.SelectedItem.Text + "_" + DropDownMonth.SelectedItem.Text + "_" + DropDownYear.SelectedValue + ".xls"
                Dim strReportitle = DropListLocation.SelectedItem.Text + " " + DropDownMonth.SelectedItem.Text.Substring(0, 3) + "-" + DropDownYear.SelectedValue + " Accounting Report"
                'rw("LTitle") = Branch_Code + " " + MonthName + "-" + Year + " Accounting Report"
                _AccountReportModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _AccountReportModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _AccountReportModel.Month = DropDownMonth.SelectedItem.Value
                _AccountReportModel.Year = DropDownYear.SelectedItem.Value
                Dim dtAcctReport As DataTable = _AccountReportControl.SelectAccountReport(_AccountReportModel)

                If (dtAcctReport Is Nothing) Or (dtAcctReport.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    Dim strText As String = ""
                    strText = ExportDatatableToHtml(dtAcctReport, strReportitle)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    ExportExcel(strFileName, strText)
                    'ExportCSV(strFileName, dtAcctReport)
                End If

            ElseIf (drpTaskExport.SelectedValue = "100") Then
                '100 PL Tracking Sheet
                SonyPlTracking()

            ElseIf (drpTaskExport.SelectedValue = "101") Then
                '101 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyInBoundModel As SonyInBoundModel = New SonyInBoundModel()
                Dim _SonyInBoundControl As SonyInBoundControl = New SonyInBoundControl()
                _SonyInBoundModel.UserId = userid
                _SonyInBoundModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyInBoundModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyInBoundModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyInBoundModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyInBoundModel.FILE_NAME = _SonyInBoundModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyInBoundModelView As DataTable = _SonyInBoundControl.SelectInBound(_SonyInBoundModel)

                If (dtSonyInBoundModelView Is Nothing) Or (dtSonyInBoundModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyInBoundModel.FILE_NAME, dtSonyInBoundModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "102") Then
                '102 Out bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyOutBoundModel As SonyOutBoundModel = New SonyOutBoundModel()
                Dim _SonyOutBoundControl As SonyOutBoundControl = New SonyOutBoundControl()
                _SonyOutBoundModel.UserId = userid
                _SonyOutBoundModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyOutBoundModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyOutBoundModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyOutBoundModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyOutBoundModel.FILE_NAME = _SonyOutBoundModel.SHIP_TO_BRANCH & "_OB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyOutBoundModelView As DataTable = _SonyOutBoundControl.SelectOutBound(_SonyOutBoundModel)

                If (dt_SonyOutBoundModelView Is Nothing) Or (dt_SonyOutBoundModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyOutBoundModel.FILE_NAME, dt_SonyOutBoundModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "103") Then
                '103 PartOrderListReport

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyPartOrderModel As SonyPartOrderModel = New SonyPartOrderModel()
                Dim _SonyPartOrderControl As SonyPartOrderControl = New SonyPartOrderControl()
                _SonyPartOrderModel.UserId = userid
                _SonyPartOrderModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyPartOrderModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyPartOrderModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyPartOrderModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyPartOrderModel.FILE_NAME = _SonyPartOrderModel.SHIP_TO_BRANCH & "_PO" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyPartOrderModelView As DataTable = _SonyPartOrderControl.SelectPartOrder(_SonyPartOrderModel)

                If (dt_SonyPartOrderModelView Is Nothing) Or (dt_SonyPartOrderModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyPartOrderModel.FILE_NAME, dt_SonyPartOrderModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "104") Then
                '104 RPSI Inquiry

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyRpsiInquiryModel As SonyRpsiInquiryModel = New SonyRpsiInquiryModel()
                Dim _SonyRpsiInquiryControl As SonyRpsiInquiryControl = New SonyRpsiInquiryControl()
                _SonyRpsiInquiryModel.UserId = userid
                _SonyRpsiInquiryModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyRpsiInquiryModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyRpsiInquiryModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyRpsiInquiryModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyRpsiInquiryModel.FILE_NAME = _SonyRpsiInquiryModel.SHIP_TO_BRANCH & "_RI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyRpsiInquiryModelView As DataTable = _SonyRpsiInquiryControl.SelectRpsiInquiry(_SonyRpsiInquiryModel)

                If (dt_SonyRpsiInquiryModelView Is Nothing) Or (dt_SonyRpsiInquiryModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyRpsiInquiryModel.FILE_NAME, dt_SonyRpsiInquiryModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "105") Then
                '105 Stock Report

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyStocksModel As SonyStocksModel = New SonyStocksModel()
                Dim _SonyStocksControl As SonyStocksControl = New SonyStocksControl()
                _SonyStocksModel.UserId = userid
                _SonyStocksModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyStocksModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyStocksModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyStocksModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyStocksModel.FILE_NAME = _SonyStocksModel.SHIP_TO_BRANCH & "_RI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyStocksModelView As DataTable = _SonyStocksControl.SelectStocks(_SonyStocksModel)

                If (dt_SonyStocksModelView Is Nothing) Or (dt_SonyStocksModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyStocksModel.FILE_NAME, dt_SonyStocksModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "106") Then
                '106 Date Wise Sales Report 

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyB2bDateWiseSalesModel As SonyB2bDateWiseSalesModel = New SonyB2bDateWiseSalesModel()
                Dim _SonyB2bDateWiseSalesControl As SonyB2bDateWiseSalesControl = New SonyB2bDateWiseSalesControl()
                _SonyB2bDateWiseSalesModel.UserId = userid
                _SonyB2bDateWiseSalesModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyB2bDateWiseSalesModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyB2bDateWiseSalesModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyB2bDateWiseSalesModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyB2bDateWiseSalesModel.FILE_NAME = _SonyB2bDateWiseSalesModel.SHIP_TO_BRANCH & "_SR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyB2bDateWiseSalesModelView As DataTable = _SonyB2bDateWiseSalesControl.SelectB2bDateWiseSales(_SonyB2bDateWiseSalesModel)

                If (dt_SonyB2bDateWiseSalesModelView Is Nothing) Or (dt_SonyB2bDateWiseSalesModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyB2bDateWiseSalesModel.FILE_NAME, dt_SonyB2bDateWiseSalesModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "107") Then
                '107 Stock Available

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyB2bStockAvailableModel As SonyB2bStockAvailableModel = New SonyB2bStockAvailableModel()
                Dim _SonyB2bStockAvailableControl As SonyB2bStockAvailableControl = New SonyB2bStockAvailableControl()
                _SonyB2bStockAvailableModel.UserId = userid
                _SonyB2bStockAvailableModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyB2bStockAvailableModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyB2bStockAvailableModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyB2bStockAvailableModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyB2bStockAvailableModel.FILE_NAME = _SonyB2bStockAvailableModel.SHIP_TO_BRANCH & "_SA" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyB2bStockAvailableModelView As DataTable = _SonyB2bStockAvailableControl.SelectB2bStockAvailable(_SonyB2bStockAvailableModel)

                If (dt_SonyB2bStockAvailableModelView Is Nothing) Or (dt_SonyB2bStockAvailableModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyB2bStockAvailableModel.FILE_NAME, dt_SonyB2bStockAvailableModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "108") Then
                '108 AscGstTaxReport

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyAscGstTaxReportModel As SonyAscGstTaxReportModel = New SonyAscGstTaxReportModel()
                Dim _SonyAscGstTaxReportControl As SonyAscGstTaxReportControl = New SonyAscGstTaxReportControl()
                _SonyAscGstTaxReportModel.UserId = userid
                _SonyAscGstTaxReportModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyAscGstTaxReportModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyAscGstTaxReportModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyAscGstTaxReportModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyAscGstTaxReportModel.FILE_NAME = _SonyAscGstTaxReportModel.SHIP_TO_BRANCH & "_AT" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyAscGstTaxReportModelView As DataTable = _SonyAscGstTaxReportControl.SelectAscGstTaxReport(_SonyAscGstTaxReportModel)

                If (dt_SonyAscGstTaxReportModelView Is Nothing) Or (dt_SonyAscGstTaxReportModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyAscGstTaxReportModel.FILE_NAME, dt_SonyAscGstTaxReportModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "109") Then
                '109 ASCTaxReport

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyAscTaxReportModel As SonyAscTaxReportModel = New SonyAscTaxReportModel()
                Dim _SonyAscTaxReportControl As SonyAscTaxReportControl = New SonyAscTaxReportControl()
                _SonyAscTaxReportModel.UserId = userid
                _SonyAscTaxReportModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyAscTaxReportModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyAscTaxReportModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyAscTaxReportModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyAscTaxReportModel.FILE_NAME = _SonyAscTaxReportModel.SHIP_TO_BRANCH & "_AT" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyAscTaxReportModelView As DataTable = _SonyAscTaxReportControl.SelectAscTaxReport(_SonyAscTaxReportModel)

                If (dt_SonyAscTaxReportModelView Is Nothing) Or (dt_SonyAscTaxReportModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyAscTaxReportModel.FILE_NAME, dt_SonyAscTaxReportModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "110") Then
                '110 RMS ASC_Tax_Report

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyRmsAscTaxReport01Model As SonyRmsAscTaxReport01Model = New SonyRmsAscTaxReport01Model()
                Dim _SonyRmsAscTaxReport01Control As SonyRmsAscTaxReport01Control = New SonyRmsAscTaxReport01Control()
                _SonyRmsAscTaxReport01Model.UserId = userid
                _SonyRmsAscTaxReport01Model.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyRmsAscTaxReport01Model.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyRmsAscTaxReport01Model.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyRmsAscTaxReport01Model.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyRmsAscTaxReport01Model.FILE_NAME = _SonyRmsAscTaxReport01Model.SHIP_TO_BRANCH & "_RA" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyAscTaxReport01ModelView As DataTable = _SonyRmsAscTaxReport01Control.SelectRmsAscTaxReport01(_SonyRmsAscTaxReport01Model)

                If (dt_SonyAscTaxReport01ModelView Is Nothing) Or (dt_SonyAscTaxReport01ModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyRmsAscTaxReport01Model.FILE_NAME, dt_SonyAscTaxReport01ModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "111") Then
                '110 ClaimInvoiceDetail

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyRmsClaimInvoiceDetailModel As SonyRmsClaimInvoiceDetailModel = New SonyRmsClaimInvoiceDetailModel()
                Dim _SonyRmsClaimInvoiceDetailControl As SonyRmsClaimInvoiceDetailControl = New SonyRmsClaimInvoiceDetailControl()
                _SonyRmsClaimInvoiceDetailModel.UserId = userid
                _SonyRmsClaimInvoiceDetailModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyRmsClaimInvoiceDetailModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyRmsClaimInvoiceDetailModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyRmsClaimInvoiceDetailModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyRmsClaimInvoiceDetailModel.FILE_NAME = _SonyRmsClaimInvoiceDetailModel.SHIP_TO_BRANCH & "_RA" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyRmsClaimInvoiceDetailModelView As DataTable = _SonyRmsClaimInvoiceDetailControl.SelectRmsClaimInvoiceDetail(_SonyRmsClaimInvoiceDetailModel)

                If (dt_SonyRmsClaimInvoiceDetailModelView Is Nothing) Or (dt_SonyRmsClaimInvoiceDetailModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyRmsClaimInvoiceDetailModel.FILE_NAME, dt_SonyRmsClaimInvoiceDetailModelView)
                End If '
            ElseIf (drpTaskExport.SelectedValue = "112") Then
                '110 ClaimInvoiceDetail

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyAscInvoiceDataModel As SonyAscInvoiceDataModel = New SonyAscInvoiceDataModel()
                Dim _SonyAscInvoiceDataControl As SonyAscInvoiceDataControl = New SonyAscInvoiceDataControl()
                _SonyAscInvoiceDataModel.UserId = userid
                _SonyAscInvoiceDataModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyAscInvoiceDataModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyAscInvoiceDataModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyAscInvoiceDataModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyAscInvoiceDataModel.FILE_NAME = _SonyAscInvoiceDataModel.SHIP_TO_BRANCH & "_AI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_SonyAscInvoiceDataModelView As DataTable = _SonyAscInvoiceDataControl.SelectAscInvoiceData(_SonyAscInvoiceDataModel)

                If (dt_SonyAscInvoiceDataModelView Is Nothing) Or (dt_SonyAscInvoiceDataModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyAscInvoiceDataModel.FILE_NAME, dt_SonyAscInvoiceDataModelView)
                End If '

                'Added for Daily Abandon
            ElseIf (drpTaskExport.SelectedValue = "113") Then
                '101 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDailyAbandonModel As SonyDailyAbandonModel = New SonyDailyAbandonModel()
                Dim _SonyDailyAbandonControl As SonyDailyAbandonControl = New SonyDailyAbandonControl()
                _SonyDailyAbandonModel.UserId = userid
                _SonyDailyAbandonModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDailyAbandonModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDailyAbandonModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDailyAbandonModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDailyAbandonModel.FILE_NAME = _SonyDailyAbandonModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyAbandonModelView As DataTable = _SonyDailyAbandonControl.SelectDailyAbandon(_SonyDailyAbandonModel)

                If (dtSonyDailyAbandonModelView Is Nothing) Or (dtSonyDailyAbandonModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDailyAbandonModel.FILE_NAME, dtSonyDailyAbandonModelView)
                End If





                'Added for SonyDailyAccumulatedKPIReport

            ElseIf (drpTaskExport.SelectedValue = "114") Then
                '101 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDailyAccumulatedKPIReportModel As SonyDailyAccumulatedKPIReportModel = New SonyDailyAccumulatedKPIReportModel()
                Dim _SonyDailyAccumulatedKPIReportControl As SonyDailyAccumulatedKPIReportControl = New SonyDailyAccumulatedKPIReportControl()
                _SonyDailyAccumulatedKPIReportModel.UserId = userid
                _SonyDailyAccumulatedKPIReportModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDailyAccumulatedKPIReportModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDailyAccumulatedKPIReportModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDailyAccumulatedKPIReportModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDailyAccumulatedKPIReportModel.FILE_NAME = _SonyDailyAccumulatedKPIReportModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyAccumulatedKPIReportModelView As DataTable = _SonyDailyAccumulatedKPIReportControl.SelectDailyAccumulatedKPIReport(_SonyDailyAccumulatedKPIReportModel)

                If (dtSonyDailyAccumulatedKPIReportModelView Is Nothing) Or (dtSonyDailyAccumulatedKPIReportModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDailyAccumulatedKPIReportModel.FILE_NAME, dtSonyDailyAccumulatedKPIReportModelView)
                End If

                'Added For SonyDailyASCPartsUsed
            ElseIf (drpTaskExport.SelectedValue = "115") Then
                '101 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDailyASCPartsUsedModel As SonyDailyASCPartsUsedModel = New SonyDailyASCPartsUsedModel()
                Dim _SonyDailyASCPartsUsedControl As SonyDailyASCPartsUsedControl = New SonyDailyASCPartsUsedControl()
                _SonyDailyASCPartsUsedModel.UserId = userid
                _SonyDailyASCPartsUsedModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDailyASCPartsUsedModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDailyASCPartsUsedModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDailyASCPartsUsedModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDailyASCPartsUsedModel.FILE_NAME = _SonyDailyASCPartsUsedModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyASCPartsUsedModelView As DataTable = _SonyDailyASCPartsUsedControl.SelectDailyASCPartsUsed(_SonyDailyASCPartsUsedModel)

                If (dtSonyDailyASCPartsUsedModelView Is Nothing) Or (dtSonyDailyASCPartsUsedModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDailyASCPartsUsedModel.FILE_NAME, dtSonyDailyASCPartsUsedModelView)
                End If

                'Added For Daily Claim
            ElseIf (drpTaskExport.SelectedValue = "116") Then
                '101 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDailyClaimModel As SonyDailyClaimModel = New SonyDailyClaimModel()
                Dim _SonyDailyClaimControl As SonyDailyClaimControl = New SonyDailyClaimControl()
                _SonyDailyClaimModel.UserId = userid
                _SonyDailyClaimModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDailyClaimModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDailyClaimModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDailyClaimModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDailyClaimModel.FILE_NAME = _SonyDailyClaimModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyClaimModelView As DataTable = _SonyDailyClaimControl.SelectDailyClaim(_SonyDailyClaimModel)

                If (dtSonyDailyClaimModelView Is Nothing) Or (dtSonyDailyClaimModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDailyClaimModel.FILE_NAME, dtSonyDailyClaimModelView)
                End If


                'Added for Daily Delivered

            ElseIf (drpTaskExport.SelectedValue = "117") Then


                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDailyDeliveredModel As SonyDailyDeliveredModel = New SonyDailyDeliveredModel()
                Dim _SonyDailyDeliveredControl As SonyDailyDeliveredControl = New SonyDailyDeliveredControl()
                _SonyDailyDeliveredModel.UserId = userid
                _SonyDailyDeliveredModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDailyDeliveredModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDailyDeliveredModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDailyDeliveredModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDailyDeliveredModel.FILE_NAME = _SonyDailyDeliveredModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyDeliveredModelView As DataTable = _SonyDailyDeliveredControl.SelectDailyDelivered(_SonyDailyDeliveredModel)

                If (dtSonyDailyDeliveredModelView Is Nothing) Or (dtSonyDailyDeliveredModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDailyDeliveredModel.FILE_NAME, dtSonyDailyDeliveredModelView)
                End If


                'Added for Sony daily OS Reservation

            ElseIf (drpTaskExport.SelectedValue = "118") Then


                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDailyOSReservationModel As SonyDailyOSReservationModel = New SonyDailyOSReservationModel()
                Dim _SonyDailyOSReservationControl As SonyDailyOSReservationControl = New SonyDailyOSReservationControl()
                _SonyDailyOSReservationModel.UserId = userid
                _SonyDailyOSReservationModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDailyOSReservationModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDailyOSReservationModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDailyOSReservationModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDailyOSReservationModel.FILE_NAME = _SonyDailyOSReservationModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyOSReservationModelView As DataTable = _SonyDailyOSReservationControl.SelectDailyDelivered(_SonyDailyOSReservationModel)

                If (dtSonyDailyOSReservationModelView Is Nothing) Or (dtSonyDailyOSReservationModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDailyOSReservationModel.FILE_NAME, dtSonyDailyOSReservationModelView)
                End If

                'Added for Sony Daily Receiveset

            ElseIf (drpTaskExport.SelectedValue = "119") Then
                '101 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDailyReceivesetModel As SonyDailyReceivesetModel = New SonyDailyReceivesetModel()
                Dim _SonyDailyReceivesetControl As SonyDailyReceivesetControl = New SonyDailyReceivesetControl()
                _SonyDailyReceivesetModel.UserId = userid
                _SonyDailyReceivesetModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDailyReceivesetModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDailyReceivesetModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDailyReceivesetModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDailyReceivesetModel.FILE_NAME = _SonyDailyReceivesetModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyReceivesetModelView As DataTable = _SonyDailyReceivesetControl.SelectDailyReceiveset(_SonyDailyReceivesetModel)

                If (dtSonyDailyReceivesetModelView Is Nothing) Or (dtSonyDailyReceivesetModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDailyReceivesetModel.FILE_NAME, dtSonyDailyReceivesetModelView)
                End If

                'Added for Daily_OS_specialtreatment

            ElseIf (drpTaskExport.SelectedValue = "120") Then


                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDaily_OS_specialtreatmentModel As SonyDailyOsSpecialtreatmentModel = New SonyDailyOsSpecialtreatmentModel()
                Dim _SonyDaily_OS_specialtreatmentcontrol As SonyDailyOsSpecialtreatmentControl = New SonyDailyOsSpecialtreatmentControl()
                _SonyDaily_OS_specialtreatmentModel.UserId = userid
                _SonyDaily_OS_specialtreatmentModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDaily_OS_specialtreatmentModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDaily_OS_specialtreatmentModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDaily_OS_specialtreatmentModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDaily_OS_specialtreatmentModel.FILE_NAME = _SonyDaily_OS_specialtreatmentModel.SHIP_TO_BRANCH & "_OS" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyDeliveredModelView As DataTable = _SonyDaily_OS_specialtreatmentcontrol.SelectSony_Daily_OS_specialtreatment(_SonyDaily_OS_specialtreatmentModel)

                If (dtSonyDailyDeliveredModelView Is Nothing) Or (dtSonyDailyDeliveredModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDaily_OS_specialtreatmentModel.FILE_NAME, dtSonyDailyDeliveredModelView)
                End If

                'SONY_Acct_stmt
            ElseIf (drpTaskExport.SelectedValue = "121") Then


                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _Acct_stmtModel As SonyAcctStmtModel = New SonyAcctStmtModel()
                Dim _Acct_stmtControl As SonyAcctStmtControl = New SonyAcctStmtControl()
                _Acct_stmtModel.UserId = userid
                _Acct_stmtModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _Acct_stmtModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _Acct_stmtModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _Acct_stmtModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _Acct_stmtModel.FILE_NAME = _Acct_stmtModel.SHIP_TO_BRANCH & "_AS" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_Acct_stmtModelView As DataTable = _Acct_stmtControl.SelectAcct_stmt(_Acct_stmtModel)

                If (dt_Acct_stmtModelView Is Nothing) Or (dt_Acct_stmtModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_Acct_stmtModel.FILE_NAME, dt_Acct_stmtModelView)
                End If

                'Added for Daily_RepairsetSet_NP

            ElseIf (drpTaskExport.SelectedValue = "122") Then


                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _Daily_RepairsetSet_NPModel As SonyDailyRepairsetSetNPModel = New SonyDailyRepairsetSetNPModel()
                Dim _Daily_RepairsetSet_NPControl As SonyDailyRepairsetSetNPControl = New SonyDailyRepairsetSetNPControl()
                _Daily_RepairsetSet_NPModel.UserId = userid
                _Daily_RepairsetSet_NPModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _Daily_RepairsetSet_NPModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _Daily_RepairsetSet_NPModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _Daily_RepairsetSet_NPModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _Daily_RepairsetSet_NPModel.FILE_NAME = _Daily_RepairsetSet_NPModel.SHIP_TO_BRANCH & "_DR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dt_Daily_RepairsetSet_NPModelView As DataTable = _Daily_RepairsetSet_NPControl.SelectDailyRepairsetSetNP(_Daily_RepairsetSet_NPModel)
                If (dt_Daily_RepairsetSet_NPModelView Is Nothing) Or (dt_Daily_RepairsetSet_NPModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_Daily_RepairsetSet_NPModel.FILE_NAME, dt_Daily_RepairsetSet_NPModelView)
                End If

                'Added for Daily_UnDeliveredSet

            ElseIf (drpTaskExport.SelectedValue = "123") Then


                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _Sony_daily_UndeliveredSetModel As SonyDailyUndeliveredSetModel = New SonyDailyUndeliveredSetModel()
                Dim _SonydailyUndeliveredSetcontroll As SonydailyUndeliveredSetcontroll = New SonydailyUndeliveredSetcontroll()
                _Sony_daily_UndeliveredSetModel.UserId = userid
                _Sony_daily_UndeliveredSetModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _Sony_daily_UndeliveredSetModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _Sony_daily_UndeliveredSetModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _Sony_daily_UndeliveredSetModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _Sony_daily_UndeliveredSetModel.FILE_NAME = _Sony_daily_UndeliveredSetModel.SHIP_TO_BRANCH & "_UD" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyDeliveredModelView As DataTable = _SonydailyUndeliveredSetcontroll.SelectDailyUnRepairsetControll(_Sony_daily_UndeliveredSetModel)

                If (dtSonyDailyDeliveredModelView Is Nothing) Or (dtSonyDailyDeliveredModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_Sony_daily_UndeliveredSetModel.FILE_NAME, dtSonyDailyDeliveredModelView)
                End If

                'Added for Daily_UnRepaipairset_NP
            ElseIf (drpTaskExport.SelectedValue = "124") Then


                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDailyUnRepaipairsetNPModel As SonyDailyUnRepaipairsetNPModel = New SonyDailyUnRepaipairsetNPModel()
                Dim _SonyDailyUnRepairsetNPControll As SonyDailyUnRepairsetNPControll = New SonyDailyUnRepairsetNPControll()
                _SonyDailyUnRepaipairsetNPModel.UserId = userid
                _SonyDailyUnRepaipairsetNPModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDailyUnRepaipairsetNPModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDailyUnRepaipairsetNPModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDailyUnRepaipairsetNPModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDailyUnRepaipairsetNPModel.FILE_NAME = _SonyDailyUnRepaipairsetNPModel.SHIP_TO_BRANCH & "_UR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDailyDeliveredModelView As DataTable = _SonyDailyUnRepairsetNPControll.SelectDailyUnRepairsetNPControll(_SonyDailyUnRepaipairsetNPModel)

                If (dtSonyDailyDeliveredModelView Is Nothing) Or (dtSonyDailyDeliveredModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDailyUnRepaipairsetNPModel.FILE_NAME, dtSonyDailyDeliveredModelView)
                End If

                'Added for Sony_MONTHLY_RESERVATIONVATION

            ElseIf (drpTaskExport.SelectedValue = "125") Then
                '125 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyMonthlyReservationvationModel As SonyMonthlyReservationvationModel = New SonyMonthlyReservationvationModel()
                Dim _SonyMonthlyReservationvationControl As SonyMonthlyReservationvationControl = New SonyMonthlyReservationvationControl()
                _SonyMonthlyReservationvationModel.UserId = userid
                _SonyMonthlyReservationvationModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyMonthlyReservationvationModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyMonthlyReservationvationModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyMonthlyReservationvationModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyMonthlyReservationvationModel.FILE_NAME = _SonyMonthlyReservationvationModel.SHIP_TO_BRANCH & "_RE" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtMonthlyReservationvationModelView As DataTable = _SonyMonthlyReservationvationControl.SelectSonyMonthlyReservationvation(_SonyMonthlyReservationvationModel)

                If (dtMonthlyReservationvationModelView Is Nothing) Or (dtMonthlyReservationvationModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyMonthlyReservationvationModel.FILE_NAME, dtMonthlyReservationvationModelView)
                End If


                'Added for Sony_MONTHLY_RepairSet

            ElseIf (drpTaskExport.SelectedValue = "126") Then
                '135 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyMonthlyRepairsetModel As SonyMonthlyRepairsetModel = New SonyMonthlyRepairsetModel()
                Dim _SonyMonthlyRepairsetControl As SonyMonthlyRepairsetControl = New SonyMonthlyRepairsetControl()
                _SonyMonthlyRepairsetModel.UserId = userid
                _SonyMonthlyRepairsetModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyMonthlyRepairsetModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyMonthlyRepairsetModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyMonthlyRepairsetModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyMonthlyRepairsetModel.FILE_NAME = _SonyMonthlyRepairsetModel.SHIP_TO_BRANCH & "_RP" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtMonthlyRepairsetModelView As DataTable = _SonyMonthlyRepairsetControl.SelectSonyMonthlyRepairset(_SonyMonthlyRepairsetModel)

                If (dtMonthlyRepairsetModelView Is Nothing) Or (dtMonthlyRepairsetModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyMonthlyRepairsetModel.FILE_NAME, dtMonthlyRepairsetModelView)


                End If


                'Added for Sony_MONTHLY_Apandon

            ElseIf (drpTaskExport.SelectedValue = "127") Then
                '135 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyMonthlyAbandonModel As SonyMonthlyAbandonModel = New SonyMonthlyAbandonModel()
                Dim _SonyMonthlyAbandonControl As SonyMonthlyAbandonControl = New SonyMonthlyAbandonControl()
                _SonyMonthlyAbandonModel.UserId = userid
                _SonyMonthlyAbandonModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyMonthlyAbandonModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyMonthlyAbandonModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyMonthlyAbandonModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyMonthlyAbandonModel.FILE_NAME = _SonyMonthlyAbandonModel.SHIP_TO_BRANCH & "_MA" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtMonthlyApandonModelView As DataTable = _SonyMonthlyAbandonControl.SelectSonyMonthlyAbandon(_SonyMonthlyAbandonModel)

                If (dtMonthlyApandonModelView Is Nothing) Or (dtMonthlyApandonModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyMonthlyAbandonModel.FILE_NAME, dtMonthlyApandonModelView)


                End If


                'Added for MonthlySOMCClaim

            ElseIf (drpTaskExport.SelectedValue = "128") Then
                '101 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyMonthlySOMCClaimModel As SonyMonthlySOMCClaimModel = New SonyMonthlySOMCClaimModel()
                Dim _SonyMonthlySOMCClaimControl As SonyMonthlySOMCClaimControl = New SonyMonthlySOMCClaimControl()
                _SonyMonthlySOMCClaimModel.UserId = userid
                _SonyMonthlySOMCClaimModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyMonthlySOMCClaimModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyMonthlySOMCClaimModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyMonthlySOMCClaimModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyMonthlySOMCClaimModel.FILE_NAME = _SonyMonthlySOMCClaimModel.SHIP_TO_BRANCH & "_IB" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyMonthlySOMCClaimModelView As DataTable = _SonyMonthlySOMCClaimControl.SelectMonthlySOMCClaim(_SonyMonthlySOMCClaimModel)

                If (dtSonyMonthlySOMCClaimModelView Is Nothing) Or (dtSonyMonthlySOMCClaimModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyMonthlySOMCClaimModel.FILE_NAME, dtSonyMonthlySOMCClaimModelView)
                End If

            ElseIf (drpTaskExport.SelectedValue = "129") Then
                '101 In Bound

                'Verify Month is selected
                If DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please select the month", "")
                    Exit Sub
                End If
                'Pass the paramters to Update in Datatabase
                Dim _SonyDeliveredSetModel As SonyDeliveredSetModel = New SonyDeliveredSetModel()
                Dim _SonyDeliveredSetControl As SonyDeliveredSetControl = New SonyDeliveredSetControl()
                _SonyDeliveredSetModel.UserId = userid
                _SonyDeliveredSetModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value
                _SonyDeliveredSetModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text
                _SonyDeliveredSetModel.DateFrom = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
                _SonyDeliveredSetModel.DateTo = CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
                _SonyDeliveredSetModel.FILE_NAME = _SonyDeliveredSetModel.SHIP_TO_BRANCH & "_DS" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                Dim dtSonyDeliveredSetModelView As DataTable = _SonyDeliveredSetControl.SelectDeliveredSet(_SonyDeliveredSetModel)

                If (dtSonyDeliveredSetModelView Is Nothing) Or (dtSonyDeliveredSetModelView.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the year " & DropDownYear.SelectedValue & " and month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    'For Excel Export
                    'Dim strText As String = ""
                    'strText = ExportDatatableToHtml(dtBoiModelView)
                    '_BoiModel.FileName = _BoiModel.SHIP_TO_BRANCH & "_BOI" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".xls"
                    'ExportExcel(_BoiModel.FileName, strText)
                    ExportCSV(_SonyDeliveredSetModel.FILE_NAME, dtSonyDeliveredSetModelView)
                End If










            ElseIf (drpTaskExport.SelectedValue = "130") Then
                Dim DtFrom As String = ""
                Dim DtTo As String = ""
                Dim strFileName As String = ""
                DtFrom = Trim(TextDateFrom.Text)
                DtTo = Trim(TextDateTo.Text)
                'Task = 0 then Month wise filter
                'Task = 1 then From & To
                If Trim(DtFrom) = "" And Trim(DtTo) = "" And DropDownMonth.SelectedValue = "0" Then
                    Call showMsg("Please specify either output period by month or date", "")
                    Exit Sub
                End If
                If Trim(DtFrom) <> "" And Trim(DtTo) <> "" And DropDownMonth.SelectedValue <> "0" Then
                    Call showMsg("Please specify either output period by month or date.", "")
                    Exit Sub
                End If
                If DropDownMonth.SelectedValue <> "0" Then
                    'Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 Or Len(Trim(DtTo)) > 7 Then
                        Call showMsg("Please specify either output period by month or date.", "")
                        Exit Sub
                    End If
                Else
                    ' Task = 1 'Assign From or To or both filter
                    If Len(Trim(DtFrom)) > 7 And Len(Trim(DtTo)) > 7 Then
                        Dim date1, date2 As Date
                        date1 = Date.Parse(TextDateFrom.Text)
                        date2 = Date.Parse(TextDateTo.Text)
                        If (DateTime.Compare(date1, date2) > 0) Then ' which means ("date1 > date2") 
                            Call showMsg("Please verify from date and to date", "")
                            Exit Sub
                        End If
                    End If
                    'Need to interchange 
                    'Allow for any one of From / To 
                    If Len(DtFrom) > 5 And DtTo = "" Then
                        DtTo = DtFrom
                    End If
                    If DtFrom = "" And Len(DtTo) > 5 Then
                        DtFrom = DtTo
                    End If
                End If
                'FromDate Verification 

                Dim _SonyActivityReportModel As SonyActivityReportModel = New SonyActivityReportModel()
                Dim _SonyActivityReportControl As SonyActivityReportControl = New SonyActivityReportControl()
                If String.IsNullOrEmpty(DtFrom) Or String.IsNullOrEmpty(DtTo) Then ' Month format selected
                    'Need to find it by selected month
                    _SonyActivityReportModel.Month = DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue
                    _SonyActivityReportModel.ServiceCentre = DropListLocation.SelectedItem.Text
                    _SonyActivityReportModel.location = DropListLocation.SelectedItem.Value
                    strFileName = DropListLocation.SelectedItem.Text & "_" & "SonyAR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                    _SonyActivityReportModel.SRC_FILE_NAME = DropListLocation.SelectedItem.Text & "_" & "SonyAR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue
                Else
                    _SonyActivityReportModel.location = DropListLocation.SelectedItem.Value
                    _SonyActivityReportModel.ServiceCentre = DropListLocation.SelectedItem.Text
                    Dim mon As String = DateAndTime.Month(DtFrom)
                    Dim year As String = DateAndTime.Year(DtFrom)
                    Dim Frmday As String = DateAndTime.Day(DtFrom)
                    If Frmday.Length = 1 Then
                        Frmday = "0" & Frmday
                    Else
                        Frmday = Frmday
                    End If
                    Dim fromday = Frmday
                    _SonyActivityReportModel.FromDay = fromday
                    Dim monto As String = DateAndTime.Month(DtTo)
                    Dim yearto As String = DateAndTime.Year(DtTo)
                    Dim dayTo As String = DateAndTime.Day(DtTo)
                    Dim tday As String

                    If dayTo.Length = 1 Then
                        tday = "0" & dayTo
                    Else
                        tday = dayTo
                    End If
                    tday = tday

                    _SonyActivityReportModel.ToDay = tday

                    If mon.Length = 1 Then
                        mon = "0" & mon
                    Else
                        mon = mon
                    End If
                    Dim FromMonth = year & "/" & mon

                    _SonyActivityReportModel.FromMonth = FromMonth
                    If monto.Length = 1 Then
                        monto = "0" & monto
                    Else
                        monto = monto
                    End If
                    Dim ToMonth = yearto & "/" & monto
                    _SonyActivityReportModel.ToMonth = ToMonth

                    If (Trim(DtFrom) <> "") Then

                    End If
                    If (Trim(DtTo) <> "") Then

                    End If
                    'Verify Date Format 
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
                    '  _ActivityModel.DateFrom = DtConvFrom(2) & "/" & DtConvFrom(0) & "/" & DtConvFrom(1)
                    'DateConversion
                    Dim DtConvTo() As String
                    DtConvTo = Split(DtTo, "/")
                    If Len(DtConvTo(0)) = 1 Then
                        DtConvTo(0) = "0" & DtConvTo(0)
                    End If
                    If Len(DtConvTo(1)) = 1 Then
                        DtConvTo(1) = "0" & DtConvTo(1)
                    End If
                    ' _ActivityModel.DateTo = DtConvTo(2) & "/" & DtConvTo(0) & "/" & DtConvTo(1)
                    strFileName = DropListLocation.SelectedItem.Text & "_" & "SonyAR" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1) & ".csv"
                    _SonyActivityReportModel.SRC_FILE_NAME = DropListLocation.SelectedItem.Text & "_" & "SonyAR" & DtConvFrom(2) & DtConvFrom(0) & DtConvFrom(1) & "-" & DtConvTo(2) & DtConvTo(0) & DtConvTo(1)
                    ''  _GRecievedModel.SrcFileName = _GRecievedModel.ShipToBranch & "_GR" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
                End If
                Dim _Datatable As DataTable = _SonyActivityReportControl.GetSonyAnalysis_ReportDate(_SonyActivityReportModel)
                If (_Datatable Is Nothing) Or (_Datatable.Rows.Count = 0) Then
                    'If no Records
                    Call showMsg("No records found for the month of " & DropDownMonth.SelectedItem.Text, "")
                    Exit Sub
                Else
                    Response.ContentType = "text/csv"
                    Response.AddHeader("Content-Disposition", "attachment;filename=" & strFileName)
                    Response.AddHeader("Pragma", "no-cache")
                    Response.AddHeader("Cache-Control", "no-cache")
                    Dim myData As Byte() = CommonControl.csvBytesWriter(_Datatable)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    Response.SuppressContent = True
                    HttpContext.Current.ApplicationInstance.CompleteRequest()
                End If

            ElseIf (drpTaskExport.SelectedValue = "200") Then
                '200 PL Tracking Sheet
                ApplePlTracking()




            End If
        End If
        TextDateFrom.Text = ""
        TextDateTo.Text = ""
    End Sub
    Sub ExportCSV(ExportFileName As String, result As DataTable) 'VJ 2019/10/14 End
        Response.ContentType = "text/csv"
        Response.AddHeader("Content-Disposition", "attachment;filename=" & ExportFileName)
        Response.AddHeader("Pragma", "no-cache")
        Response.AddHeader("Cache-Control", "no-cache")
        Dim myData As Byte() = CommonControl.csvBytesWriter(result)
        Response.BinaryWrite(myData)
        Response.Flush()
        Response.SuppressContent = True
        HttpContext.Current.ApplicationInstance.CompleteRequest()
    End Sub

    Protected Overrides Sub InitializeCulture()
        'Dim ci As CultureInfo = New CultureInfo("en-IN")
        'ci.NumberFormat.CurrencySymbol = "₹"
        'Thread.CurrentThread.CurrentCulture = ci
        'MyBase.InitializeCulture()
    End Sub

    Protected Function ExportDatatableToHtmlForPO(ByVal dt As DataTable, ByVal strReportitle As String) As String

        Dim val As Double = 0.00
        Dim rowid As Int16 = 0

        Dim strHTMLBuilder As StringBuilder = New StringBuilder()
        strHTMLBuilder.Append("<html >")
        strHTMLBuilder.Append("<head>")
        strHTMLBuilder.Append("</head>")
        strHTMLBuilder.Append("<body>")

        strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='white' style='font-family:Meiryo UI; font-size:10'>")
        strHTMLBuilder.Append("<tr><td></td><td colspan=3 style='text-align: center;font-size: 13px; padding: 5px;'>PO Amount</td><td colspan=2 style='text-align: center;font-size: 13px; padding: 5px;'>Billing Information</td><td colspan=2 style='text-align: center;font-size: 13px;'>Consumption</td><td colspan=3 style='text-align: center;font-size: 13px;'>Collection</td><td colspan=2 style='text-align: center;font-size: 13px;'>GSS Payment</td></tr>")
        strHTMLBuilder.Append("<tr><td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>Date</td><td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>Daily Amount</td><td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>PO Return</td><td style='text-align: center; font-size: 13px;'>Month</td> <td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>Daily Amount</td><td style='text-align: center; font-size: 13px;   padding: 4px; width: 88px;'>Month</td>     <td style='text-align: center; font-size: 13px; width: 101px;'>Daily Amount</td><td style='text-align: center; font-size: 13px;'>Month</td><td style='text-align: center; font-size: 13px; width: 101px;'>Daily Deposit</td><td style='text-align: center; font-size: 13px;'>Credit Sales</td><td style='text-align: center; font-size: 13px; width: 62px;'>Month</td><td style='text-align: center; font-size: 13px; width: 62px;'>Daily</td><td style='text-align: center; font-size: 13px; width: 62px;'>Month</td></tr>")

        For Each myRow As DataRow In dt.Rows
            strHTMLBuilder.Append("<tr>")
            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold; padding:4px;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(0).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(1).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(2).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(3).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(4).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(5).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(6).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(7).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(8).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(9).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(10).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(11).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
            strHTMLBuilder.Append(myRow(dt.Columns(12).ColumnName).ToString())
            strHTMLBuilder.Append("</td>")

            strHTMLBuilder.Append("</tr>")
        Next


        strHTMLBuilder.Append("</table>")
        strHTMLBuilder.Append("</body>")
        strHTMLBuilder.Append("</html>")
        Dim Htmltext As String = strHTMLBuilder.ToString()
        Return Htmltext
    End Function


    Protected Function ExportDatatableToHtml(ByVal dt As DataTable, ByVal strReportitle As String) As String

        Dim val As Double = 0.00
        Dim rowid As Int16 = 0

        Dim strHTMLBuilder As StringBuilder = New StringBuilder()
        strHTMLBuilder.Append("<html >")
        strHTMLBuilder.Append("<head>")
        strHTMLBuilder.Append("</head>")
        strHTMLBuilder.Append("<body>")

        strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='white' style='font-family:Meiryo UI; font-size:10'>")
        strHTMLBuilder.Append("<tr>")
        'Not include Table Header
        'For Each myColumn As DataColumn In dt.Columns
        '    strHTMLBuilder.Append("<td >")
        '    strHTMLBuilder.Append(myColumn.ColumnName)
        '    strHTMLBuilder.Append("</td>")
        'Next
        strHTMLBuilder.Append("<td colspan='6' border='1px' cellpadding='1' cellspacing='1' bgcolor='darkblue' style=' text-align:center; color:white;  font-size:bloder' >")
        strHTMLBuilder.Append(strReportitle)
        strHTMLBuilder.Append("</td>")

        strHTMLBuilder.Append("</tr>")

        strHTMLBuilder.Append("<tr><td colspan='6'></td></tr>")
        For Each myRow As DataRow In dt.Rows
            rowid += 1
            If rowid = dt.Rows.Count - 6 Then
                strHTMLBuilder.Append("<tr><td></td><td  border='1px' cellpadding='1' cellspacing='1' bgcolor='afd6af' colspan='2'></td><td></td><td border='1px' cellpadding='1' cellspacing='1' bgcolor='peachpuff' colspan='2'></td></tr>")
            ElseIf rowid = dt.Rows.Count - 5 Then

                strHTMLBuilder.Append("<tr><td></td><td border='1px' cellpadding='1' cellspacing='1' bgcolor='afd6af'></td>")
                If dt.Columns(2).ColumnName = "LAmount" Then
                    If myRow(dt.Columns(2).ColumnName) <> "" Then
                        strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='afd6af' style='text-align:right;'>")
                        val = Convert.ToDouble(myRow(dt.Columns(2).ColumnName).ToString())
                        'VJ 20200625
                        'strHTMLBuilder.Append(val.ToString("C"))
                        'strHTMLBuilder.Append("<p>&#x20B9;")
                        strHTMLBuilder.Append(val.ToString())
                        ' strHTMLBuilder.Append("</p>")
                        strHTMLBuilder.Append("</td>")
                    Else
                        strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='afd6af' style='text-align:right;'>")
                        strHTMLBuilder.Append("</td>")
                    End If


                End If
                strHTMLBuilder.Append("<td></td><td border='1px' cellpadding='1' cellspacing='1' bgcolor='peachpuff'></td>")
                If dt.Columns(5).ColumnName = "RAmount" Then
                    If myRow(dt.Columns(5).ColumnName) <> "" Then
                        strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='peachpuff' style='text-align:right;'>")
                        val = Convert.ToDouble(myRow(dt.Columns(5).ColumnName).ToString())
                        'VJ 20200625
                        'strHTMLBuilder.Append(val.ToString("C"))
                        'strHTMLBuilder.Append("<p>&#x20B9;")
                        strHTMLBuilder.Append(val.ToString())
                        'strHTMLBuilder.Append("</p>")
                        strHTMLBuilder.Append("</td>")
                    Else
                        strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='peachpuff' style='text-align:right;'>")
                        strHTMLBuilder.Append("</td>")
                    End If

                    strHTMLBuilder.Append("</tr>")
                End If
                'For Each myColumn As DataColumn In dt.Columns

                '    strHTMLBuilder.Append("<td style='text-align:right;'>")
                '    If myColumn.ColumnName = "LTitle" Or myColumn.ColumnName = "RTitle" Then
                '        strHTMLBuilder.Append(myRow(myColumn.ColumnName).ToString())
                '    End If
                '    If dt.Columns(2).ColumnName = "LAmount" Or dt.Columns(5).ColumnName = "RAmount" Then
                '        If myRow(myColumn.ColumnName) <> "" Then
                '            val = Convert.ToDouble(myRow(myColumn.ColumnName).ToString())
                '            strHTMLBuilder.Append(val.ToString("C"))
                '        End If
                '    End If
                '    ' strHTMLBuilder.Append(String.Format(CultureInfo.InvariantCulture, "{0:N0}", myRow(myColumn.ColumnName)))

                '    'strHTMLBuilder.Append(myRow(myColumn.ColumnName)).ToString("N", New CultureInfo("en-US"))
                '    strHTMLBuilder.Append("</td>")
                'Next
            ElseIf rowid = dt.Rows.Count - 4 Or rowid = dt.Rows.Count - 3 Then
                strHTMLBuilder.Append("<tr><td colspan='6'></td></tr>")
            ElseIf rowid = dt.Rows.Count - 2 Then
                strHTMLBuilder.Append("<tr><td></td>")
                strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='navajowhite' style='text-align:right;font-weight:bold;'>")
                strHTMLBuilder.Append(myRow(dt.Columns(1).ColumnName).ToString())
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='navajowhite' style='text-align:right;font-weight:bold;'>")
                val = Convert.ToDouble(myRow(dt.Columns(2).ColumnName).ToString())
                'VJ 20200625
                'strHTMLBuilder.Append(val.ToString("C"))
                'strHTMLBuilder.Append("<p>&#x20B9;")
                strHTMLBuilder.Append(val.ToString())
                'strHTMLBuilder.Append("</p>")
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td colspan='3'></td></tr>")
            ElseIf rowid = dt.Rows.Count - 1 Then
                strHTMLBuilder.Append("<tr><td></td>")
                strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='skyblue' style='text-align:right;font-weight:bold;'>")
                strHTMLBuilder.Append(myRow(dt.Columns(1).ColumnName).ToString())
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='skyblue' style='text-align:right;font-weight:bold;'>")
                val = Convert.ToDouble(myRow(dt.Columns(2).ColumnName).ToString())
                'VJ 20200625
                'strHTMLBuilder.Append(val.ToString("C"))
                'strHTMLBuilder.Append("<p>&#x20B9;")
                strHTMLBuilder.Append(val.ToString())
                'strHTMLBuilder.Append("</p>")
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td colspan='3'></td></tr>")
            ElseIf rowid = dt.Rows.Count Then
                strHTMLBuilder.Append("<tr><td></td>")
                strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
                strHTMLBuilder.Append(myRow(dt.Columns(1).ColumnName).ToString())
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td style='text-align:right;font-weight:bold;'>")
                val = Convert.ToDouble(myRow(dt.Columns(2).ColumnName).ToString())
                'VJ 20200625
                'strHTMLBuilder.Append(val.ToString("C"))
                'strHTMLBuilder.Append("<p>&#x20B9;")
                strHTMLBuilder.Append(val.ToString())
                'strHTMLBuilder.Append("</p>")
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td colspan='3'></td></tr>")
            Else
                strHTMLBuilder.Append("<tr>")
                strHTMLBuilder.Append("<td></td>")
                strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='afd6af' style='text-align:right;'>")
                strHTMLBuilder.Append(myRow(dt.Columns(1).ColumnName.ToString()))
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='afd6af' style='text-align:right;'>")
                If myRow(dt.Columns(2).ColumnName.ToString()) <> "" Then
                    val = Convert.ToDouble(myRow(dt.Columns(2).ColumnName.ToString()))
                    'VJ 20200625
                    'strHTMLBuilder.Append(val.ToString("C"))
                    'strHTMLBuilder.Append("<p>&#x20B9;")
                    strHTMLBuilder.Append(val.ToString())
                    'strHTMLBuilder.Append("</p>")
                End If
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td></td>")
                strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='peachpuff' style='text-align:right;'>")
                strHTMLBuilder.Append(myRow(dt.Columns(4).ColumnName.ToString()))
                strHTMLBuilder.Append("</td>")
                strHTMLBuilder.Append("<td border='1px' cellpadding='1' cellspacing='1' bgcolor='peachpuff' style='text-align:right;'>")
                If myRow(dt.Columns(5).ColumnName.ToString()) <> "" Then
                    val = Convert.ToDouble(myRow(dt.Columns(5).ColumnName.ToString()))
                    'VJ 20200625
                    'strHTMLBuilder.Append(val.ToString("C"))
                    'strHTMLBuilder.Append("<p>&#x20B9;")
                    strHTMLBuilder.Append(val.ToString())
                    'strHTMLBuilder.Append("</p>")
                End If
                strHTMLBuilder.Append("</td>")

                'For Each myColumn As DataColumn In dt.Columns

                '        strHTMLBuilder.Append("<td style='text-align:right;'>")
                '        If myColumn.ColumnName = "LTitle" Or myColumn.ColumnName = "RTitle" Then
                '            strHTMLBuilder.Append(myRow(myColumn.ColumnName).ToString())
                '        End If
                '        If myColumn.ColumnName = "LAmount" Or myColumn.ColumnName = "RAmount" Then
                '            If myRow(myColumn.ColumnName) <> "" Then
                '                val = Convert.ToDouble(myRow(myColumn.ColumnName).ToString())
                '                strHTMLBuilder.Append(val.ToString("C"))
                '            End If
                '        End If
                '        ' strHTMLBuilder.Append(String.Format(CultureInfo.InvariantCulture, "{0:N0}", myRow(myColumn.ColumnName)))

                '        'strHTMLBuilder.Append(myRow(myColumn.ColumnName)).ToString("N", New CultureInfo("en-US"))
                '        strHTMLBuilder.Append("</td>")
                '    Next
                strHTMLBuilder.Append("</tr>")
            End If


            'strHTMLBuilder.Append("</tr>")
        Next

        strHTMLBuilder.Append("</table>")
        strHTMLBuilder.Append("</body>")
        strHTMLBuilder.Append("</html>")
        Dim Htmltext As String = strHTMLBuilder.ToString()
        Return Htmltext
    End Function
    Sub ExportExcel(ExportFileName As String, result As String)
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=" & ExportFileName)
        Response.AddHeader("Pragma", "no-cache")
        Response.AddHeader("Cache-Control", "no-cache")
        Dim myData As Byte() = System.Text.Encoding.UTF8.GetBytes(result)
        Response.BinaryWrite(myData)
        Response.Flush()
        Response.SuppressContent = True
        HttpContext.Current.ApplicationInstance.CompleteRequest()
    End Sub
    Sub WeeklySetting()
        Dim dDate As DateTime = Date.Today
        'dDate.AddDays(-10)
        'DropDownDaySub.SelectedValue = dDate.AddDays(-10).Date

        DropDownMonth.SelectedValue = dDate.AddDays(-10).Month
        DropDownYear.SelectedValue = dDate.AddDays(-10).Year
        If dDate.AddDays(-10).Day >= 1 And dDate.AddDays(-10).Day <= 10 Then
            DropDownDaySub.SelectedValue = "01"
        ElseIf dDate.AddDays(-10).Day >= 11 And dDate.AddDays(-10).Day <= 20 Then
            DropDownDaySub.SelectedValue = "11"
        Else
            DropDownDaySub.SelectedValue = "21"
        End If
    End Sub
    Sub MonthlySetting()
        Dim dDate As DateTime = Date.Today
        Dim mon As String
        If dDate.AddDays(-30).Month.ToString().Length = 1 Then
            mon = "0" & dDate.AddDays(-30).Month.ToString()
        Else
            mon = dDate.AddDays(-30).Month.ToString()
        End If
        DropDownMonth.SelectedValue = mon
        DropDownYear.SelectedValue = dDate.AddDays(-30).Year
    End Sub
    Sub DefaultSearchSetting(ByVal Optional SearchType As String = "init")
        Dim dDate As DateTime = Date.Today
        If SearchType = "init" Then
            DropDownMonth.Visible = True
            DropDownYear.Visible = False
            DropDownDaySub.Visible = False
            DropDownDTSub.Visible = False
            TextDateFrom.Visible = False
            Label8.Visible = False
            TextDateTo.Visible = False
            Label7.Visible = False
            DropDownGR.Visible = False
            DropDownMonth.SelectedIndex = 0
            'DropDownYear.SelectedIndex = 0
            DropDownDaySub.SelectedIndex = 0
            DropDownDTSub.SelectedIndex = 0
            TextDateFrom.Text = ""
            TextDateTo.Text = ""
        ElseIf SearchType = "old" Then
            DropDownMonth.Visible = True
            TextDateFrom.Visible = True
            Label8.Visible = True
            TextDateTo.Visible = True
            Label7.Visible = True
            DropDownYear.Visible = True
            'Comment on 20200130
            ' DropDownYear.Visible = False
            DropDownDaySub.Visible = False
            DropDownDTSub.Visible = False
            DropDownGR.Visible = False
            'Dim dt As Date
            'dt = Now.Month & "/01/" & Now.Year
            'TextDateFrom.Text = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            Dim fromDate As DateTime = New DateTime(dDate.Year, dDate.Month, 1)
            TextDateFrom.Text = fromDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            TextDateTo.Text = dDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            DropDownMonth.SelectedIndex = 0
            'DropDownYear.SelectedIndex = 1
            DropDownDaySub.SelectedIndex = 0
            DropDownDTSub.SelectedIndex = 0
        ElseIf SearchType = "yyyymm" Then
            DropDownYear.Visible = True
            DropDownMonth.Visible = True
            DropDownDaySub.Visible = False
            DropDownDTSub.Visible = False
            TextDateFrom.Visible = False
            Label8.Visible = False
            TextDateTo.Visible = False
            Label7.Visible = False
            DropDownMonth.SelectedIndex = 0
            ' DropDownYear.SelectedIndex = 0
            DropDownDaySub.SelectedIndex = 0
            DropDownDTSub.SelectedIndex = 0
            TextDateFrom.Text = ""
            TextDateTo.Text = ""
            DropDownGR.Visible = False
        ElseIf SearchType = "yyyymmdd" Then
            DropDownYear.Visible = True
            DropDownMonth.Visible = True
            DropDownDaySub.Visible = True
            DropDownDTSub.Visible = False
            TextDateFrom.Visible = False
            Label8.Visible = False
            TextDateTo.Visible = False
            Label7.Visible = False
            DropDownMonth.SelectedIndex = 0
            'DropDownYear.SelectedIndex = 0
            DropDownDaySub.SelectedIndex = 0
            DropDownDTSub.SelectedIndex = 0
            TextDateFrom.Text = ""
            TextDateTo.Text = ""
            DropDownGR.Visible = False
        ElseIf SearchType = "dtyyyymmdd" Then
            DropDownYear.Visible = True
            DropDownMonth.Visible = True
            DropDownDaySub.Visible = True
            DropDownDTSub.Visible = True
            TextDateFrom.Visible = False
            Label8.Visible = False
            TextDateTo.Visible = False
            Label7.Visible = False
            DropDownMonth.SelectedIndex = 0
            'DropDownYear.SelectedIndex = 0
            DropDownDaySub.SelectedIndex = 0
            DropDownDTSub.SelectedIndex = 0
            TextDateFrom.Text = ""
            TextDateTo.Text = ""
            DropDownGR.Visible = False
        End If

    End Sub

    'bharathiraja
    Public Shared Function GetDates(ByVal year As Integer, ByVal month As Integer) As DataTable
        Dim dataTable As DataTable = New DataTable("Po_Confirmation_Table")
        Dim Dates As DataColumn = New DataColumn("Date")
        Dates.DataType = System.Type.[GetType]("System.String")
        'PO Amount
        Dim PO1 As DataColumn = New DataColumn("Daily Amount")
        PO1.DataType = System.Type.[GetType]("System.String")
        Dim PO2 As DataColumn = New DataColumn("Daily Amount2")
        PO2.DataType = System.Type.[GetType]("System.Decimal")

        Dim Returns1 As DataColumn = New DataColumn("PO Return")
        Returns1.DataType = System.Type.[GetType]("System.String")
        Dim Returns2 As DataColumn = New DataColumn("PO Return2")
        Returns2.DataType = System.Type.[GetType]("System.Decimal")

        Dim POMonth1 As DataColumn = New DataColumn("Month")
        POMonth1.DataType = System.Type.[GetType]("System.String")
        Dim POMonth2 As DataColumn = New DataColumn("Month2")
        POMonth2.DataType = System.Type.[GetType]("System.Decimal")


        'Billing Information
        Dim Billing_Daily_Amount1 As DataColumn = New DataColumn("Billing Daily Amount")
        Billing_Daily_Amount1.DataType = System.Type.[GetType]("System.String")
        Dim Billing_Daily_Amount2 As DataColumn = New DataColumn("Billing Daily Amount2")
        Billing_Daily_Amount2.DataType = System.Type.[GetType]("System.Decimal")



        Dim Billing_Month1 As DataColumn = New DataColumn("Billing Month")
        Billing_Month1.DataType = System.Type.[GetType]("System.String")
        Dim Billing_Month2 As DataColumn = New DataColumn("Billing Month2")
        Billing_Month2.DataType = System.Type.[GetType]("System.Decimal")




        'Consumption
        Dim GDParts1 As DataColumn = New DataColumn("Consumption Daily Amount")
        GDParts1.DataType = System.Type.[GetType]("System.String")
        Dim GDParts2 As DataColumn = New DataColumn("Consumption Daily Amount2")
        GDParts2.DataType = System.Type.[GetType]("System.Decimal")

        Dim GDPartsMonth1 As DataColumn = New DataColumn("Consumption Month")
        GDPartsMonth1.DataType = System.Type.[GetType]("System.String")
        Dim GDPartsMonth2 As DataColumn = New DataColumn("Consumption Month2")
        GDPartsMonth2.DataType = System.Type.[GetType]("System.Decimal")


        'Collections
        Dim DailyDeposit1 As DataColumn = New DataColumn("Daily Deposit")
        DailyDeposit1.DataType = System.Type.[GetType]("System.String")
        Dim DailyDeposit2 As DataColumn = New DataColumn("Daily Deposit2")
        DailyDeposit2.DataType = System.Type.[GetType]("System.Decimal")

        Dim CreditSales1 As DataColumn = New DataColumn("Credit Sales")
        CreditSales1.DataType = System.Type.[GetType]("System.String")
        Dim CreditSales2 As DataColumn = New DataColumn("Credit Sales2")
        CreditSales2.DataType = System.Type.[GetType]("System.Decimal")

        Dim CollectionMonth1 As DataColumn = New DataColumn("Collections Month")
        CollectionMonth1.DataType = System.Type.[GetType]("System.String")
        Dim CollectionMonth2 As DataColumn = New DataColumn("Collections Month2")
        CollectionMonth2.DataType = System.Type.[GetType]("System.Decimal")

        'GSS Payment
        Dim Daily1 As DataColumn = New DataColumn("Daily")
        Daily1.DataType = System.Type.[GetType]("System.String")
        Dim Daily2 As DataColumn = New DataColumn("Daily2")
        Daily2.DataType = System.Type.[GetType]("System.Decimal")

        Dim GssPayment_Month1 As DataColumn = New DataColumn("GssPayment Month")
        GssPayment_Month1.DataType = System.Type.[GetType]("System.String")
        Dim GssPayment_Month2 As DataColumn = New DataColumn("GssPayment Month2")
        GssPayment_Month2.DataType = System.Type.[GetType]("System.Decimal")


        dataTable.Columns.Add(Dates)

        'PO Amount
        dataTable.Columns.Add(PO1)
        dataTable.Columns.Add(Returns1)
        dataTable.Columns.Add(POMonth1)

        'Billing Informations
        dataTable.Columns.Add(Billing_Daily_Amount1)
        dataTable.Columns.Add(Billing_Month1)

        'Consumption
        dataTable.Columns.Add(GDParts1)
        dataTable.Columns.Add(GDPartsMonth1)

        'Collections
        dataTable.Columns.Add(DailyDeposit1)
        dataTable.Columns.Add(CreditSales1)
        dataTable.Columns.Add(CollectionMonth1)

        'GSS Payment
        dataTable.Columns.Add(Daily1)
        dataTable.Columns.Add(GssPayment_Month1)


        'PO Amount
        dataTable.Columns.Add(PO2)
        dataTable.Columns.Add(Returns2)
        dataTable.Columns.Add(POMonth2)

        'Billing Informations
        dataTable.Columns.Add(Billing_Daily_Amount2)
        dataTable.Columns.Add(Billing_Month2)

        'Consumption
        dataTable.Columns.Add(GDParts2)
        dataTable.Columns.Add(GDPartsMonth2)

        'Collections
        dataTable.Columns.Add(DailyDeposit2)
        dataTable.Columns.Add(CreditSales2)
        dataTable.Columns.Add(CollectionMonth2)

        'GSS Payment
        dataTable.Columns.Add(Daily2)
        dataTable.Columns.Add(GssPayment_Month2)


        For i As Integer = 1 To DateTime.DaysInMonth(year, month)
            Dim drPA As DataRow = dataTable.NewRow()
            drPA("Date") = New DateTime(year, month, i).ToString("yyyy-MM-dd").Replace("-", "/")

            drPA("Daily Amount") = "0.00"
            drPA("PO Return") = "0.00"
            drPA("Month") = "0.00"

            drPA("Billing Daily Amount") = "0.00"
            drPA("Billing Month") = "0.00"


            drPA("Consumption Daily Amount") = "0.00"
            drPA("Consumption Month") = "0.00"

            drPA("Daily Deposit") = "0.00"
            drPA("Credit Sales") = "0.00"
            drPA("Collections Month") = "0.00"


            drPA("Daily") = "0.00"
            drPA("GssPayment Month") = "0.00"



            drPA("Daily Amount2") = "0.00"
            drPA("PO Return2") = "0.00"
            drPA("Month2") = "0.00"

            drPA("Billing Daily Amount2") = "0.00"
            drPA("Billing Month2") = "0.00"

            drPA("Consumption Daily Amount2") = "0.00"
            drPA("Consumption Month2") = "0.00"

            drPA("Daily Deposit2") = "0.00"
            drPA("Credit Sales2") = "0.00"
            drPA("Collections Month2") = "0.00"


            drPA("Daily2") = "0.00"
            drPA("GssPayment Month2") = "0.00"


            dataTable.Rows.Add(drPA)
        Next
        Return dataTable
    End Function


    Protected Sub drpTaskExport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpTaskExport.SelectedIndexChanged
        If drpTaskExport.SelectedValue = "-1" Then
            DefaultSearchSetting()
        ElseIf drpTaskExport.SelectedValue = "100" Then
            DefaultSearchSetting("yyyymm")

        ElseIf drpTaskExport.SelectedValue = "1" Then
            DefaultSearchSetting("old")
        ElseIf (drpTaskExport.SelectedValue = "2.1") Or
            (drpTaskExport.SelectedValue = "2.2") Or
             (drpTaskExport.SelectedValue = "2.3") Then
            ''''DefaultSearchSetting("old")
            DefaultSearchSetting("yyyymm")
            TextDateFrom.Visible = True
            TextDateFrom.Text = ""
            Label8.Visible = True
            TextDateTo.Visible = True
            TextDateTo.Text = ""
            Label7.Visible = True
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "3" Then
            DefaultSearchSetting("yyyymm")
            TextDateFrom.Visible = True
            TextDateFrom.Text = ""
            Label8.Visible = True
            TextDateTo.Visible = True
            TextDateTo.Text = ""
            Label7.Visible = True
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "-3" Then
            DefaultSearchSetting("yyyymm")
            TextDateFrom.Visible = True
            TextDateFrom.Text = ""
            Label8.Visible = True
            TextDateTo.Visible = True
            TextDateTo.Text = ""
            Label7.Visible = True
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "4" Then
            DefaultSearchSetting("yyyymm")
            TextDateFrom.Visible = True
            TextDateFrom.Text = ""
            Label8.Visible = True
            TextDateTo.Visible = True
            TextDateTo.Text = ""
            Label7.Visible = True
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "5" Then
            ''''''DefaultSearchSetting("yyyymm")
            '''

            DefaultSearchSetting("yyyymm")
            TextDateFrom.Visible = True
            TextDateFrom.Text = ""
            Label8.Visible = True
            TextDateTo.Visible = True
            TextDateTo.Text = ""
            Label7.Visible = True
        ElseIf drpTaskExport.SelectedValue = "6" Then
            DefaultSearchSetting("yyyymmdd")
            WeeklySetting()
        ElseIf drpTaskExport.SelectedValue = "7" Then
            DefaultSearchSetting("dtyyyymmdd")
            WeeklySetting()
        ElseIf drpTaskExport.SelectedValue = "8" Then
            DefaultSearchSetting("yyyymm")
            DropDownGR.Visible = True
            TextDateFrom.Visible = True
            TextDateFrom.Text = ""
            Label8.Visible = True
            TextDateTo.Visible = True
            TextDateTo.Text = ""
            Label7.Visible = True
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "9" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "9A" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "10" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "11" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "12" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "13" Then
            DefaultSearchSetting("init")
            Call showMsg("Coming Soon...", "")
            Exit Sub
        ElseIf drpTaskExport.SelectedValue = "14" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "15" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "16" Then
            DefaultSearchSetting("yyyymmdd")
            WeeklySetting()
        ElseIf drpTaskExport.SelectedValue = "99" Then 'VJ 2019/10/14 Begin
            DefaultSearchSetting("old")
        ElseIf drpTaskExport.SelectedValue = "18" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "18A" Then
            DefaultSearchSetting("yyyymm")
        ElseIf drpTaskExport.SelectedValue = "19" Then
            DefaultSearchSetting("yyyymm") 'VJ 2019/10/14 Begin
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "19B" Then
            DefaultSearchSetting("yyyymm") 'VJ 2019/10/18 Begin
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "20" Then
            DefaultSearchSetting("yyyymm") 'Added on 20191114
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "21" Then
            DefaultSearchSetting("yyyymm") 'Added on 20191114
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "22" Then 'VJ 20200311 Activity Report
            DefaultSearchSetting("old")
            TextDateFrom.Text = ""
            TextDateTo.Text = ""
        ElseIf drpTaskExport.SelectedValue = "23" Then 'PO_Confirmation
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "24" Then 'Samsung to GSS paid (BOI)
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "25" Then 'Account Report VJ 20200529
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "101" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "102" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "103" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "104" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "105" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "106" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "107" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "108" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "109" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "110" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "111" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "112" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "113" Then 'Added for Daily Abandon
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "114" Then 'Added for Daily Accumulated KPI Rpt
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "115" Then 'Added for Daily ASCPartsUsed
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "116" Then 'Added for Daily Claim
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "117" Then 'Added for Daily Delivered
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "118" Then 'Added for Daily OS Reservation
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "119" Then 'Added for Daily Receiveset
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "120" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "121" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "122" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "123" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "124" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "125" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "126" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        ElseIf drpTaskExport.SelectedValue = "127" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()

        ElseIf drpTaskExport.SelectedValue = "128" Then
            DefaultSearchSetting("yyyymm")
            MonthlySetting()

        ElseIf drpTaskExport.SelectedValue = "129" Then 'VJ 20200311 SonyActivity Report
            DefaultSearchSetting("old")
            TextDateFrom.Text = ""
            TextDateTo.Text = ""
        ElseIf (drpTaskExport.SelectedValue = "200") Then
            '200 PL Tracking Sheet
            DefaultSearchSetting("yyyymm")
            MonthlySetting()
        End If
    End Sub

    Sub ApplePlTracking()



        Dim strDate As String = ""

        Dim strYear As String = ""
        strYear = DropDownYear.SelectedItem.Value
        Dim strMonth As String = ""
        strMonth = DropDownMonth.SelectedItem.Value

        Dim strMaxDay As String = ""
        strMaxDay = Date.DaysInMonth(strYear, strMonth)

        Dim strBranchName As String = ""
        Dim clsSetCommon As New Class_common
        Dim comcontrol As New CommonControl

        strBranchName = DropListLocation.SelectedItem.Text

        Dim csvContents = New List(Of String)

        '1st Left Column begin
        Dim rowWork1 As String = strBranchName
        Dim rowWork2 As String = "Number of Counters"
        Dim rowWork3 As String = "Number of Business dat"
        Dim rowWork4 As String = "Number of Staffs"
        Dim rowWork5 As String = "Customer Visit"
        Dim rowWork6 As String = "Call Registered"
        Dim rowWork7 As String = "Repair Completed"
        Dim rowWork8 As String = "Goods Delivered"
        Dim rowWork9 As String = "Pending"
        Dim rowWork10 As String = "Warranty(Number)"
        Dim rowWork11 As String = "In Warranty (Number)"
        Dim rowWork12 As String = "Out Warranty (Number)"
        Dim rowWork13 As String = "AC+ (Number)"
        Dim rowWork14 As String = "In Warranty (Amount)"
        Dim rowWork15 As String = "In Warranty (Labour)"
        Dim rowWork16 As String = "In Warranty (Parts)"
        Dim rowWork17 As String = "In Warranty (Others)"
        Dim rowWork18 As String = "Out Warranty (Amount)"
        Dim rowWork19 As String = "Out Warranty (Labour)"
        Dim rowWork20 As String = "Out Warranty (Parts Sales)"
        Dim rowWork21 As String = "Out Warranty (Parts Cost)"
        Dim rowWork22 As String = "Out Warranty (Parts Margin)"
        Dim rowWork23 As String = "Out Warranty (Others)"
        Dim rowWork24 As String = "Out Warranty (Discount)"
        Dim rowWork25 As String = "AC+ (Amount)"
        Dim rowWork26 As String = "In Warranty (Labour)"
        Dim rowWork27 As String = "In Warranty (Parts)"
        Dim rowWork28 As String = "In Warranty (Others)"
        Dim rowWork29 As String = "AC+ Advanced"
        Dim rowWork30 As String = "Revenue Without Tax"
        Dim rowWork31 As String = "IW parts consumed"
        Dim rowWork32 As String = "Total parts consumed"
        Dim rowWork33 As String = "Prime Cost Total"
        Dim rowWork34 As String = "Gross Profit"
        Dim rowWork35 As String = " "
        '1st Left Column End

        'Middles Start




        Dim Repair As Decimal = 0.00 ' C-1 - C-2
        Dim DEMO As Decimal = 0.00 ' Marked as C-1 DEMO_CHARGE
        Dim Installation As Decimal = 0.00 ' Marked as C-2 INSTALLATION_FEE

        Dim NumberOfCounters As Integer = 0
        Dim NumberOfBusinessDat As Integer = 0
        Dim NumberOfStaffs As Integer = 0
        Dim CustomerVisit As Integer = 0
        Dim CallRegistered As Integer = 0
        Dim RepairCompleted As Integer = 0
        Dim GoodsDelivered As Integer = 0
        Dim Pending As Integer = 0

        Dim WarrantyNumber As Int16 = 0
        Dim InWarrantyNumber As Int16 = 0
        Dim OutWarrantyNumber As Int16 = 0
        Dim AcPlusNumber As Int16 = 0

        Dim IW_TotalAmountIW As Decimal = 0.00
        Dim IW_TotalAmountLabourIW As Decimal = 0.00

        Dim IW_TotalAmountPartsIW As Decimal = 0.00

        Dim IW_PART_COST_1 As Decimal = 0.00
        Dim IW_PART_COST_2 As Decimal = 0.00
        Dim IW_PART_COST_3 As Decimal = 0.00
        Dim IW_PART_COST_4 As Decimal = 0.00


        Dim IW_TotalAmountOthersIW As Decimal = 0.00

        Dim OW_TotalAmountOW As Decimal = 0.00
        Dim OW_TotalAmountLabourOW As Decimal = 0.00
        Dim OW_TotalAmountPartsSalesOW As Decimal = 0.00
        Dim OW_TotalAmountPartsCostOW As Decimal = 0.00
        Dim OW_TotalAmountPartsMarginOW As Decimal = 0.00
        Dim OW_TotalAmountOthersOW As Decimal = 0.00
        Dim OW_TotalAmountDiscountOW As Decimal = 0.00


        Dim AcPlus_TotalAmountAcplus As Decimal = 0.00
        Dim AcPlus_TotalAmountLabourIW As Decimal = 0.00
        Dim AcPlus_TotalAmountPartsIW As Decimal = 0.00
        Dim AcPlus_TotalAmountOthersIW As Decimal = 0.00
        Dim AcPlus_TotalAmountAdvanced As Decimal = 0.00

        Dim RevenuewithoutTax As Decimal = 0.00
        Dim IWPartsConsumed As Decimal = 0.00
        Dim TotalPartsConsumed As Decimal = 0.00
        Dim PrimtCostTotal As Decimal = 0.00
        Dim GrossProfit As Decimal = 0.00

        'Total
        Dim TOT_WarrantyNumber As Int16 = 0
        Dim TOT_InWarrantyNumber As Int16 = 0
        Dim TOT_OutWarrantyNumber As Int16 = 0
        Dim TOT_AcPlusNumber As Int16 = 0

        Dim TOT_IW_TotalAmountIW As Decimal = 0.00
        Dim TOT_IW_TotalAmountLabourIW As Decimal = 0.00
        Dim TOT_IW_TotalAmountPartsIW As Decimal = 0.00
        Dim TOT_IW_TotalAmountOthersIW As Decimal = 0.00

        Dim TOT_OW_TotalAmountOW As Decimal = 0.00
        Dim TOT_OW_TotalAmountLabourOW As Decimal = 0.00
        Dim TOT_OW_TotalAmountPartsSalesOW As Decimal = 0.00
        Dim TOT_OW_TotalAmountPartsCostOW As Decimal = 0.00
        Dim TOT_OW_TotalAmountPartsMarginOW As Decimal = 0.00
        Dim TOT_OW_TotalAmountOthersOW As Decimal = 0.00
        Dim TOT_OW_TotalAmountDiscountOW As Decimal = 0.00


        Dim TOT_AcPlus_TotalAmountAcplus As Decimal = 0.00
        Dim TOT_AcPlus_TotalAmountLabourIW As Decimal = 0.00
        Dim TOT_AcPlus_TotalAmountPartsIW As Decimal = 0.00
        Dim TOT_AcPlus_TotalAmountOthersIW As Decimal = 0.00
        Dim TOT_AcPlus_TotalAmountAdvanced As Decimal = 0.00

        Dim TOT_RevenuewithoutTax As Decimal = 0.00
        Dim TOT_IWPartsConsumed As Decimal = 0.00
        Dim TOT_TotalPartsConsumed As Decimal = 0.00
        Dim TOT_PrimtCostTotal As Decimal = 0.00
        Dim TOT_GrossProfit As Decimal = 0.00
        Dim TOT_Percentage As Decimal = 0.00


        'Final For a Day 
        Dim NET_TOT_WarrantyNumber As Int16 = 0
        Dim NET_TOT_InWarrantyNumber As Int16 = 0
        Dim NET_TOT_OutWarrantyNumber As Int16 = 0
        Dim NET_TOT_AcPlusNumber As Int16 = 0

        Dim NET_TOT_IW_TotalAmountIW As Decimal = 0.00
        Dim NET_TOT_IW_TotalAmountLabourIW As Decimal = 0.00
        Dim NET_TOT_IW_TotalAmountPartsIW As Decimal = 0.00
        Dim NET_TOT_IW_TotalAmountOthersIW As Decimal = 0.00

        Dim NET_TOT_OW_TotalAmountOW As Decimal = 0.00
        Dim NET_TOT_OW_TotalAmountLabourOW As Decimal = 0.00
        Dim NET_TOT_OW_TotalAmountPartsSalesOW As Decimal = 0.00
        Dim NET_TOT_OW_TotalAmountPartsCostOW As Decimal = 0.00
        Dim NET_TOT_OW_TotalAmountPartsMarginOW As Decimal = 0.00
        Dim NET_TOT_OW_TotalAmountOthersOW As Decimal = 0.00
        Dim NET_TOT_OW_TotalAmountDiscountOW As Decimal = 0.00


        Dim NET_TOT_AcPlus_TotalAmountAcplus As Decimal = 0.00
        Dim NET_TOT_AcPlus_TotalAmountLabourIW As Decimal = 0.00
        Dim NET_TOT_AcPlus_TotalAmountPartsIW As Decimal = 0.00
        Dim NET_TOT_AcPlus_TotalAmountOthersIW As Decimal = 0.00
        Dim NET_TOT_AcPlus_TotalAmountAdvanced As Decimal = 0.00

        Dim NET_TOT_RevenuewithoutTax As Decimal = 0.00
        Dim NET_TOT_IWPartsConsumed As Decimal = 0.00
        Dim NET_TOT_TotalPartsConsumed As Decimal = 0.00
        Dim NET_TOT_PrimtCostTotal As Decimal = 0.00



        Dim NET_TOT_GrossProfit As Decimal = 0.00
        Dim NET_TOT_Percentage As Decimal = 0.00






        Dim strDay As String = ""
        Dim i As Integer


        'For i = 6 To 6
        For i = 1 To strMaxDay

            strDay = i
            If Len(strDay) = 1 Then
                strDay = "0" & strDay
            End If
            If Len(strDay) = 16 Then
                Dim st As String = ""
            End If
            strDate = strYear & "/" & strMonth & "/" & strDay

            'Initialize
            WarrantyNumber = 0
            InWarrantyNumber = 0
            OutWarrantyNumber = 0
            AcPlusNumber = 0

            IW_TotalAmountIW = 0.00
            IW_TotalAmountLabourIW = 0.00
            IW_TotalAmountPartsIW = 0.00
            IW_TotalAmountOthersIW = 0.00

            OW_TotalAmountOW = 0.00
            OW_TotalAmountLabourOW = 0.00
            OW_TotalAmountPartsSalesOW = 0.00
            OW_TotalAmountPartsCostOW = 0.00
            OW_TotalAmountPartsMarginOW = 0.00
            OW_TotalAmountOthersOW = 0.00
            OW_TotalAmountDiscountOW = 0.00

            AcPlus_TotalAmountAcplus = 0.00
            AcPlus_TotalAmountLabourIW = 0.00
            AcPlus_TotalAmountPartsIW = 0.00
            AcPlus_TotalAmountOthersIW = 0.00
            AcPlus_TotalAmountAdvanced = 0.00

            RevenuewithoutTax = 0.00
            IWPartsConsumed = 0.00
            TotalPartsConsumed = 0.00
            PrimtCostTotal = 0.00
            GrossProfit = 0.00

            'Initialize
            TOT_WarrantyNumber = 0
            TOT_InWarrantyNumber = 0
            TOT_OutWarrantyNumber = 0
            TOT_AcPlusNumber = 0

            TOT_IW_TotalAmountIW = 0.00
            TOT_IW_TotalAmountLabourIW = 0.00
            TOT_IW_TotalAmountPartsIW = 0.00
            TOT_IW_TotalAmountOthersIW = 0.00

            TOT_OW_TotalAmountOW = 0.00
            TOT_OW_TotalAmountLabourOW = 0.00
            TOT_OW_TotalAmountPartsSalesOW = 0.00
            TOT_OW_TotalAmountPartsCostOW = 0.00
            TOT_OW_TotalAmountPartsMarginOW = 0.00
            TOT_OW_TotalAmountOthersOW = 0.00
            TOT_OW_TotalAmountDiscountOW = 0.00

            TOT_AcPlus_TotalAmountAcplus = 0.00
            TOT_AcPlus_TotalAmountLabourIW = 0.00
            TOT_AcPlus_TotalAmountPartsIW = 0.00
            TOT_AcPlus_TotalAmountOthersIW = 0.00
            TOT_AcPlus_TotalAmountAdvanced = 0.00

            TOT_RevenuewithoutTax = 0.00
            TOT_IWPartsConsumed = 0.00
            TOT_TotalPartsConsumed = 0.00
            TOT_PrimtCostTotal = 0.00
            TOT_GrossProfit = 0.00
            TOT_Percentage = 0.00

            Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
            Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
            _AppleQmvOrdModel.UserId = "" 'userid
            _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = DropListLocation.SelectedItem.Value '"1019756" 'DropListLocation.SelectedItem.Value
            _AppleQmvOrdModel.SHIP_TO_BRANCH = DropListLocation.SelectedItem.Text '"SID1" 'DropListLocation.SelectedItem.Text
            _AppleQmvOrdModel.DateFrom = strDate 'DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
            _AppleQmvOrdModel.DateTo = strDate 'CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)
            _AppleQmvOrdModel.FILE_NAME = _AppleQmvOrdModel.SHIP_TO_BRANCH & "_DS" & strYear & strMonth & ".csv" '_SonyDeliveredSetModel.SHIP_TO_BRANCH & "_DS" & DropDownYear.SelectedValue & DropDownMonth.SelectedValue & ".csv"
            Dim dtApQmvOrd As DataTable = _AppleQmvOrdControl.SelectPLOrder(_AppleQmvOrdModel)

            If (dtApQmvOrd Is Nothing) Or (dtApQmvOrd.Rows.Count = 0) Then
                'BYDefauly 
                'Initialize
                WarrantyNumber = 0
                InWarrantyNumber = 0
                OutWarrantyNumber = 0
                AcPlusNumber = 0

                IW_TotalAmountIW = 0.00
                IW_TotalAmountLabourIW = 0.00
                IW_TotalAmountPartsIW = 0.00
                IW_TotalAmountOthersIW = 0.00

                OW_TotalAmountOW = 0.00
                OW_TotalAmountLabourOW = 0.00
                OW_TotalAmountPartsSalesOW = 0.00
                OW_TotalAmountPartsCostOW = 0.00
                OW_TotalAmountPartsMarginOW = 0.00
                OW_TotalAmountOthersOW = 0.00
                OW_TotalAmountDiscountOW = 0.00

                AcPlus_TotalAmountAcplus = 0.00
                AcPlus_TotalAmountLabourIW = 0.00
                AcPlus_TotalAmountPartsIW = 0.00
                AcPlus_TotalAmountOthersIW = 0.00
                AcPlus_TotalAmountAdvanced = 0.00

                RevenuewithoutTax = 0.00
                IWPartsConsumed = 0.00
                TotalPartsConsumed = 0.00
                PrimtCostTotal = 0.00
                GrossProfit = 0.00

                'Initialize
                TOT_WarrantyNumber = 0
                TOT_InWarrantyNumber = 0
                TOT_OutWarrantyNumber = 0
                TOT_AcPlusNumber = 0

                TOT_IW_TotalAmountIW = 0.00
                TOT_IW_TotalAmountLabourIW = 0.00
                TOT_IW_TotalAmountPartsIW = 0.00
                TOT_IW_TotalAmountOthersIW = 0.00

                TOT_OW_TotalAmountOW = 0.00
                TOT_OW_TotalAmountLabourOW = 0.00
                TOT_OW_TotalAmountPartsSalesOW = 0.00
                TOT_OW_TotalAmountPartsCostOW = 0.00
                TOT_OW_TotalAmountPartsMarginOW = 0.00
                TOT_OW_TotalAmountOthersOW = 0.00
                TOT_OW_TotalAmountDiscountOW = 0.00

                TOT_AcPlus_TotalAmountAcplus = 0.00
                TOT_AcPlus_TotalAmountLabourIW = 0.00
                TOT_AcPlus_TotalAmountPartsIW = 0.00
                TOT_AcPlus_TotalAmountOthersIW = 0.00
                TOT_AcPlus_TotalAmountAdvanced = 0.00

                TOT_RevenuewithoutTax = 0.00
                TOT_IWPartsConsumed = 0.00
                TOT_TotalPartsConsumed = 0.00
                TOT_PrimtCostTotal = 0.00
                TOT_GrossProfit = 0.00
                TOT_Percentage = 0.00

            Else

                For DsetRow = 0 To dtApQmvOrd.Rows.Count - 1



                    'BYDefauly 
                    'Initialize
                    WarrantyNumber = 0
                    InWarrantyNumber = 0
                    OutWarrantyNumber = 0
                    AcPlusNumber = 0

                    IW_TotalAmountIW = 0.00
                    IW_TotalAmountLabourIW = 0.00
                    IW_TotalAmountPartsIW = 0.00
                    IW_TotalAmountOthersIW = 0.00

                    OW_TotalAmountOW = 0.00
                    OW_TotalAmountLabourOW = 0.00
                    OW_TotalAmountPartsSalesOW = 0.00
                    OW_TotalAmountPartsCostOW = 0.00
                    OW_TotalAmountPartsMarginOW = 0.00
                    OW_TotalAmountOthersOW = 0.00
                    OW_TotalAmountDiscountOW = 0.00

                    AcPlus_TotalAmountAcplus = 0.00
                    AcPlus_TotalAmountLabourIW = 0.00
                    AcPlus_TotalAmountPartsIW = 0.00
                    AcPlus_TotalAmountOthersIW = 0.00
                    AcPlus_TotalAmountAdvanced = 0.00

                    RevenuewithoutTax = 0.00
                    IWPartsConsumed = 0.00
                    TotalPartsConsumed = 0.00
                    PrimtCostTotal = 0.00
                    GrossProfit = 0.00

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


                    If dtApQmvOrd.Rows(DsetRow).Item("SERVICE_TYPE") IsNot DBNull.Value Then
                        Select Case UCase(dtApQmvOrd.Rows(DsetRow).Item("SERVICE_TYPE").ToString())
                            Case "1" 'IW
                                InWarrantyNumber = 1
                                'Comment on 20211227 - Labour cost for sales report
                                'If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                '    IW_TotalAmountLabourIW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES"), 2)
                                'End If

                                If dtApQmvOrd.Rows(DsetRow).Item("LABOR_COST") IsNot DBNull.Value Then
                                    IW_TotalAmountLabourIW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("LABOR_COST"), 2)
                                End If


                                'If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                '    IW_TotalAmountPartsIW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT"), 2)
                                'End If
                                IW_PART_COST_1 = 0.00
                                IW_PART_COST_2 = 0.00
                                IW_PART_COST_3 = 0.00
                                IW_PART_COST_4 = 0.00

                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_1") IsNot DBNull.Value Then
                                    IW_PART_COST_1 = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("PART_COST_1"), 2)
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_2") IsNot DBNull.Value Then
                                    IW_PART_COST_2 = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("PART_COST_2"), 2)
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_3") IsNot DBNull.Value Then
                                    IW_PART_COST_3 = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("PART_COST_3"), 2)
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_4") IsNot DBNull.Value Then
                                    IW_PART_COST_4 = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("PART_COST_4"), 2)
                                End If
                                IW_TotalAmountPartsIW = comcontrol.Money_Round((IW_PART_COST_1 + IW_PART_COST_2 + IW_PART_COST_3 + IW_PART_COST_4), 2)

                                'If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                '    IW_TotalAmountOthersIW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES"), 2)
                                'End If
                                If dtApQmvOrd.Rows(DsetRow).Item("OTHER_TOTAL") IsNot DBNull.Value Then
                                    IW_TotalAmountOthersIW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("OTHER_TOTAL"), 2)
                                End If
                            Case "2" 'OW
                                OutWarrantyNumber = 1

                                If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                    OW_TotalAmountLabourOW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES"), 2)
                                End If

                                If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                    OW_TotalAmountPartsSalesOW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT"), 2)
                                End If


                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_AMOUNT") IsNot DBNull.Value Then
                                    OW_TotalAmountPartsCostOW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("PART_COST_AMOUNT"), 2)
                                End If


                                OW_TotalAmountPartsMarginOW = OW_TotalAmountPartsSalesOW - OW_TotalAmountPartsCostOW

                                If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                    OW_TotalAmountOthersOW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES"), 2)
                                End If

                                If dtApQmvOrd.Rows(DsetRow).Item("TOTAL_DISCOUNT_AMOUNT") IsNot DBNull.Value Then
                                    OW_TotalAmountDiscountOW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("TOTAL_DISCOUNT_AMOUNT"), 2)
                                End If

                            Case "3" 'AC+
                                AcPlusNumber = 1

                                If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                    AcPlus_TotalAmountLabourIW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES"), 2)
                                End If

                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_AMOUNT") IsNot DBNull.Value Then
                                    AcPlus_TotalAmountPartsIW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("PART_COST_AMOUNT"), 2)
                                End If

                                If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                    AcPlus_TotalAmountOthersIW = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES"), 2)
                                End If

                                If dtApQmvOrd.Rows(DsetRow).Item("ADVANCE_PAYMENT") IsNot DBNull.Value Then
                                    AcPlus_TotalAmountAdvanced = comcontrol.Money_Round(dtApQmvOrd.Rows(DsetRow).Item("ADVANCE_PAYMENT"), 2)
                                End If

                        End Select

                    End If

                    TOT_InWarrantyNumber = TOT_InWarrantyNumber + InWarrantyNumber
                    TOT_OutWarrantyNumber = TOT_OutWarrantyNumber + OutWarrantyNumber
                    TOT_AcPlusNumber = TOT_AcPlusNumber + AcPlusNumber


                    TOT_IW_TotalAmountIW = TOT_IW_TotalAmountIW + IW_TotalAmountIW
                    TOT_IW_TotalAmountLabourIW = TOT_IW_TotalAmountLabourIW + IW_TotalAmountLabourIW
                    TOT_IW_TotalAmountPartsIW = TOT_IW_TotalAmountPartsIW + IW_TotalAmountPartsIW
                    TOT_IW_TotalAmountOthersIW = TOT_IW_TotalAmountOthersIW + IW_TotalAmountOthersIW

                    TOT_OW_TotalAmountOW = TOT_OW_TotalAmountOW + OW_TotalAmountOW
                    TOT_OW_TotalAmountLabourOW = TOT_OW_TotalAmountLabourOW + OW_TotalAmountLabourOW
                    TOT_OW_TotalAmountPartsSalesOW = TOT_OW_TotalAmountPartsSalesOW + OW_TotalAmountPartsSalesOW
                    TOT_OW_TotalAmountPartsCostOW = TOT_OW_TotalAmountPartsCostOW + OW_TotalAmountPartsCostOW
                    TOT_OW_TotalAmountPartsMarginOW = TOT_OW_TotalAmountPartsMarginOW + OW_TotalAmountPartsMarginOW
                    TOT_OW_TotalAmountOthersOW = TOT_OW_TotalAmountOthersOW + OW_TotalAmountOthersOW
                    TOT_OW_TotalAmountDiscountOW = TOT_OW_TotalAmountDiscountOW + OW_TotalAmountDiscountOW
                    TOT_AcPlus_TotalAmountAcplus = TOT_AcPlus_TotalAmountAcplus + AcPlus_TotalAmountAcplus
                    TOT_AcPlus_TotalAmountLabourIW = TOT_AcPlus_TotalAmountLabourIW + AcPlus_TotalAmountLabourIW
                    TOT_AcPlus_TotalAmountPartsIW = TOT_AcPlus_TotalAmountPartsIW + AcPlus_TotalAmountPartsIW
                    TOT_AcPlus_TotalAmountOthersIW = TOT_AcPlus_TotalAmountOthersIW + AcPlus_TotalAmountOthersIW
                    TOT_AcPlus_TotalAmountAdvanced = TOT_AcPlus_TotalAmountAdvanced + AcPlus_TotalAmountAdvanced


                    'TOT_RevenuewithoutTax = TOT_RevenuewithoutTax + RevenuewithoutTax
                    'TOT_IWPartsConsumed = TOT_IWPartsConsumed + IWPartsConsumed
                    'TOT_TotalPartsConsumed = TOT_TotalPartsConsumed + TotalPartsConsumed
                    'TOT_PrimtCostTotal = TOT_PrimtCostTotal + PrimtCostTotal
                    'TOT_GrossProfit = TOT_GrossProfit + GrossProfit
                    'TOT_Percentage = TOT_Percentage + Percentage





                Next


            End If

            NumberOfCounters = 0
            NumberOfBusinessDat = 0
            NumberOfStaffs = 0
            CustomerVisit = 0
            CallRegistered = 0
            RepairCompleted = 0
            GoodsDelivered = 0
            Pending = 0





            'Final For a Day 
            '# Warranty (Number) = (In Warranty (Number) + Out Warranty (Number)
            rowWork1 &= "," & strDate
            rowWork2 &= "," & NumberOfCounters
            rowWork3 &= "," & NumberOfBusinessDat
            rowWork4 &= "," & NumberOfStaffs
            rowWork5 &= "," & CustomerVisit
            rowWork6 &= "," & CallRegistered
            rowWork7 &= "," & RepairCompleted
            rowWork8 &= "," & GoodsDelivered
            rowWork9 &= "," & Pending



            TOT_WarrantyNumber = TOT_InWarrantyNumber + TOT_OutWarrantyNumber + TOT_AcPlusNumber
            rowWork10 &= "," & TOT_WarrantyNumber
            rowWork11 &= "," & TOT_InWarrantyNumber
            rowWork12 &= "," & TOT_OutWarrantyNumber
            rowWork13 &= "," & TOT_AcPlusNumber



            TOT_IW_TotalAmountIW = TOT_IW_TotalAmountLabourIW + TOT_IW_TotalAmountPartsIW + TOT_IW_TotalAmountOthersIW

            rowWork14 &= "," & Math.Floor(TOT_IW_TotalAmountIW)
            rowWork15 &= "," & Math.Floor(TOT_IW_TotalAmountLabourIW)
            rowWork16 &= "," & Math.Floor(TOT_IW_TotalAmountPartsIW)
            rowWork17 &= "," & Math.Floor(TOT_IW_TotalAmountOthersIW)

            TOT_OW_TotalAmountOW = TOT_OW_TotalAmountLabourOW + TOT_OW_TotalAmountPartsSalesOW + TOT_OW_TotalAmountPartsCostOW + TOT_OW_TotalAmountPartsMarginOW + TOT_OW_TotalAmountOthersOW + TOT_OW_TotalAmountDiscountOW
            rowWork18 &= "," & Math.Floor(TOT_OW_TotalAmountOW)
            rowWork19 &= "," & Math.Floor(TOT_OW_TotalAmountLabourOW)
            rowWork20 &= "," & Math.Floor(TOT_OW_TotalAmountPartsSalesOW)
            rowWork21 &= "," & Math.Floor(TOT_OW_TotalAmountPartsCostOW)
            rowWork22 &= "," & Math.Floor(TOT_OW_TotalAmountPartsMarginOW)
            rowWork23 &= "," & Math.Floor(TOT_OW_TotalAmountOthersOW)
            rowWork24 &= "," & Math.Floor(TOT_OW_TotalAmountDiscountOW)

            TOT_AcPlus_TotalAmountAcplus = TOT_AcPlus_TotalAmountLabourIW + TOT_AcPlus_TotalAmountPartsIW + TOT_AcPlus_TotalAmountOthersIW + TOT_AcPlus_TotalAmountAdvanced


            rowWork25 &= "," & Math.Floor(TOT_AcPlus_TotalAmountAcplus)
            rowWork26 &= "," & Math.Floor(TOT_AcPlus_TotalAmountLabourIW)
            rowWork27 &= "," & Math.Floor(TOT_AcPlus_TotalAmountPartsIW)
            rowWork28 &= "," & Math.Floor(TOT_AcPlus_TotalAmountOthersIW)
            rowWork29 &= "," & Math.Floor(TOT_AcPlus_TotalAmountAdvanced)

            '#RevenuewithoutTax = Total Amount IW + Total Amount OW
            TOT_RevenuewithoutTax = TOT_IW_TotalAmountIW + TOT_OW_TotalAmountOW + TOT_AcPlus_TotalAmountAcplus
            rowWork30 &= "," & Math.Floor(TOT_RevenuewithoutTax)



            '#IW parts consumed = Total Parts Fee * 0.88
            TOT_IWPartsConsumed = (TOT_IW_TotalAmountPartsIW + TOT_OW_TotalAmountPartsCostOW + TOT_AcPlus_TotalAmountPartsIW) * 0.88
            rowWork31 &= "," & Math.Floor(TOT_IWPartsConsumed)

            TOT_TotalPartsConsumed = TOT_IW_TotalAmountPartsIW + TOT_AcPlus_TotalAmountPartsIW
            rowWork32 &= "," & Math.Floor(TOT_TotalPartsConsumed)

            '#Prime Cost Total =  Totalpartsconsumed -  IWpartsconsumed
            TOT_PrimtCostTotal = TOT_TotalPartsConsumed - TOT_IWPartsConsumed
            rowWork33 &= "," & Math.Floor(TOT_TotalPartsConsumed)

            TOT_GrossProfit = TOT_RevenuewithoutTax - TOT_PrimtCostTotal
            rowWork34 &= "," & Math.Floor(TOT_GrossProfit)

            Try
                TOT_Percentage = (TOT_GrossProfit / TOT_RevenuewithoutTax) * 100
            Catch ex As Exception
                TOT_Percentage = 0
            End Try
            rowWork35 &= "," & Math.Floor(TOT_Percentage) & "%"





            NET_TOT_WarrantyNumber = NET_TOT_WarrantyNumber + TOT_WarrantyNumber
            NET_TOT_InWarrantyNumber = NET_TOT_InWarrantyNumber + TOT_InWarrantyNumber
            NET_TOT_OutWarrantyNumber = NET_TOT_OutWarrantyNumber + TOT_OutWarrantyNumber
            NET_TOT_AcPlusNumber = NET_TOT_AcPlusNumber + TOT_AcPlusNumber



            NET_TOT_IW_TotalAmountIW = NET_TOT_IW_TotalAmountIW + TOT_IW_TotalAmountIW
            NET_TOT_IW_TotalAmountLabourIW = NET_TOT_IW_TotalAmountLabourIW + TOT_IW_TotalAmountLabourIW
            NET_TOT_IW_TotalAmountPartsIW = NET_TOT_IW_TotalAmountPartsIW + TOT_IW_TotalAmountPartsIW
            NET_TOT_IW_TotalAmountOthersIW = NET_TOT_IW_TotalAmountOthersIW + TOT_IW_TotalAmountOthersIW

            NET_TOT_OW_TotalAmountOW = NET_TOT_OW_TotalAmountOW + TOT_OW_TotalAmountOW
            NET_TOT_OW_TotalAmountLabourOW = NET_TOT_OW_TotalAmountLabourOW + TOT_OW_TotalAmountLabourOW
            NET_TOT_OW_TotalAmountPartsSalesOW = NET_TOT_OW_TotalAmountPartsSalesOW + TOT_OW_TotalAmountPartsSalesOW
            NET_TOT_OW_TotalAmountPartsCostOW = NET_TOT_OW_TotalAmountPartsCostOW + TOT_OW_TotalAmountPartsCostOW
            NET_TOT_OW_TotalAmountPartsMarginOW = NET_TOT_OW_TotalAmountPartsMarginOW + TOT_OW_TotalAmountPartsMarginOW
            NET_TOT_OW_TotalAmountOthersOW = NET_TOT_OW_TotalAmountOthersOW + TOT_OW_TotalAmountOthersOW
            NET_TOT_OW_TotalAmountDiscountOW = NET_TOT_OW_TotalAmountDiscountOW + TOT_OW_TotalAmountDiscountOW
            NET_TOT_AcPlus_TotalAmountAcplus = NET_TOT_AcPlus_TotalAmountAcplus + TOT_AcPlus_TotalAmountAcplus
            NET_TOT_AcPlus_TotalAmountLabourIW = NET_TOT_AcPlus_TotalAmountLabourIW + TOT_AcPlus_TotalAmountLabourIW
            NET_TOT_AcPlus_TotalAmountPartsIW = NET_TOT_AcPlus_TotalAmountPartsIW + TOT_AcPlus_TotalAmountPartsIW
            NET_TOT_AcPlus_TotalAmountOthersIW = NET_TOT_AcPlus_TotalAmountOthersIW + TOT_AcPlus_TotalAmountOthersIW
            NET_TOT_AcPlus_TotalAmountAdvanced = NET_TOT_AcPlus_TotalAmountAdvanced + TOT_AcPlus_TotalAmountAdvanced

            NET_TOT_RevenuewithoutTax = NET_TOT_RevenuewithoutTax + TOT_RevenuewithoutTax
            NET_TOT_IWPartsConsumed = NET_TOT_IWPartsConsumed + TOT_IWPartsConsumed
            NET_TOT_TotalPartsConsumed = NET_TOT_TotalPartsConsumed + TOT_TotalPartsConsumed
            NET_TOT_PrimtCostTotal = NET_TOT_PrimtCostTotal + TOT_PrimtCostTotal
            NET_TOT_GrossProfit = NET_TOT_GrossProfit + TOT_GrossProfit
            '********************************
            'NetTotal
            '*******************************

        Next


        'Final For a Day 
        '# Warranty (Number) = (In Warranty (Number) + Out Warranty (Number)
        rowWork1 &= "," & "Total"
        rowWork2 &= "," & NumberOfCounters
        rowWork3 &= "," & NumberOfBusinessDat
        rowWork4 &= "," & NumberOfStaffs
        rowWork5 &= "," & CustomerVisit


        rowWork6 &= "," & CallRegistered
        rowWork7 &= "," & RepairCompleted
        rowWork8 &= "," & GoodsDelivered
        rowWork9 &= "," & Pending

        rowWork10 &= "," & Math.Floor(NET_TOT_WarrantyNumber)
        rowWork11 &= "," & Math.Floor(NET_TOT_InWarrantyNumber)
        rowWork12 &= "," & Math.Floor(NET_TOT_OutWarrantyNumber)
        rowWork13 &= "," & Math.Floor(NET_TOT_AcPlusNumber)
        rowWork14 &= "," & Math.Floor(NET_TOT_IW_TotalAmountIW)
        rowWork15 &= "," & Math.Floor(NET_TOT_IW_TotalAmountLabourIW)
        rowWork16 &= "," & Math.Floor(NET_TOT_IW_TotalAmountPartsIW)
        rowWork17 &= "," & Math.Floor(NET_TOT_IW_TotalAmountOthersIW)
        rowWork18 &= "," & Math.Floor(NET_TOT_OW_TotalAmountOW)
        rowWork19 &= "," & Math.Floor(NET_TOT_OW_TotalAmountLabourOW)
        rowWork20 &= "," & Math.Floor(NET_TOT_OW_TotalAmountPartsSalesOW)
        rowWork21 &= "," & Math.Floor(NET_TOT_OW_TotalAmountPartsCostOW)
        rowWork22 &= "," & Math.Floor(NET_TOT_OW_TotalAmountPartsMarginOW)
        rowWork23 &= "," & Math.Floor(NET_TOT_OW_TotalAmountOthersOW)
        rowWork24 &= "," & Math.Floor(NET_TOT_OW_TotalAmountDiscountOW)
        rowWork25 &= "," & Math.Floor(NET_TOT_AcPlus_TotalAmountAcplus)
        rowWork26 &= "," & Math.Floor(NET_TOT_AcPlus_TotalAmountLabourIW)
        rowWork27 &= "," & Math.Floor(NET_TOT_AcPlus_TotalAmountPartsIW)

        '#Total Amount OW (Total Amount of Account Payable OW - Account Payable By ASC - SONY Needs To Pay ) / 1.18

        rowWork28 &= "," & Math.Floor(NET_TOT_AcPlus_TotalAmountOthersIW)
        rowWork29 &= "," & Math.Floor(NET_TOT_AcPlus_TotalAmountAdvanced)
        rowWork30 &= "," & Math.Floor(NET_TOT_RevenuewithoutTax)
        rowWork31 &= "," & Math.Floor(NET_TOT_IWPartsConsumed)
        rowWork32 &= "," & Math.Floor(NET_TOT_TotalPartsConsumed)
        rowWork33 &= "," & Math.Floor(NET_TOT_PrimtCostTotal)
        rowWork34 &= "," & Math.Floor(NET_TOT_GrossProfit)
        Try
            NET_TOT_Percentage = (NET_TOT_GrossProfit / NET_TOT_RevenuewithoutTax) * 100
        Catch ex As Exception
            NET_TOT_Percentage = 0
        End Try


        rowWork35 &= "," & Math.Floor(NET_TOT_Percentage) & "%"
        '********************************
        'End
        '***********************************
        'Last Left Column Begin
        rowWork1 &= ",ASP1"
        rowWork2 &= ",Number of Counters"
        rowWork3 &= ",Number of Business dat"
        rowWork4 &= ",Number of Staffs"
        rowWork5 &= ",Customer Visit"
        rowWork6 &= ",Call Registered"
        rowWork7 &= ",Repair Completed"
        rowWork8 &= ",Goods Delivered"
        rowWork9 &= ",Pending"
        rowWork10 &= ",Warranty(Number)"
        rowWork11 &= ",In Warranty (Number)"
        rowWork12 &= ",Out Warranty (Number)"
        rowWork13 &= ",AC+ (Number)"
        rowWork14 &= ",In Warranty (Amount)"
        rowWork15 &= ",In Warranty (Labour)"
        rowWork16 &= ",In Warranty (Parts)"
        rowWork17 &= ",In Warranty (Others)"
        rowWork18 &= ",Out Warranty (Amount)"
        rowWork19 &= ",Out Warranty (Labour)"
        rowWork20 &= ",Out Warranty (Parts Sales)"
        rowWork21 &= ",Out Warranty (Parts Cost)"
        rowWork22 &= ",Out Warranty (Parts Margin)"
        rowWork23 &= ",Out Warranty (Others)"
        rowWork24 &= ",Out Warranty (Discount)"
        rowWork25 &= ",AC+ (Amount)"
        rowWork26 &= ",In Warranty (Labour)"
        rowWork27 &= ",In Warranty (Parts)"
        rowWork28 &= ",In Warranty (Others)"
        rowWork29 &= ",AC+ Advanced"
        rowWork30 &= ",Revenue Without Tax"
        rowWork31 &= ",IW parts consumed"
        rowWork32 &= ",Total parts consumed"
        rowWork33 &= ",Prime Cost Total"
        rowWork34 &= ",Gross Profit"
        rowWork35 &= ","



        csvContents.Add(rowWork1)
        csvContents.Add(rowWork2)
        csvContents.Add(rowWork3)
        csvContents.Add(rowWork4)
        csvContents.Add(rowWork5)
        csvContents.Add(rowWork6)
        csvContents.Add(rowWork7)
        csvContents.Add(rowWork8)
        csvContents.Add(rowWork9)
        csvContents.Add(rowWork10)
        csvContents.Add(rowWork11)
        csvContents.Add(rowWork12)
        csvContents.Add(rowWork13)
        csvContents.Add(rowWork14)
        csvContents.Add(rowWork15)
        csvContents.Add(rowWork16)
        csvContents.Add(rowWork17)
        csvContents.Add(rowWork18)
        csvContents.Add(rowWork19)
        csvContents.Add(rowWork20)
        csvContents.Add(rowWork21)
        csvContents.Add(rowWork22)
        csvContents.Add(rowWork23)
        csvContents.Add(rowWork24)
        csvContents.Add(rowWork25)
        csvContents.Add(rowWork26)
        csvContents.Add(rowWork27)
        csvContents.Add(rowWork28)
        csvContents.Add(rowWork29)
        csvContents.Add(rowWork30)
        csvContents.Add(rowWork31)
        csvContents.Add(rowWork32)
        csvContents.Add(rowWork33)
        csvContents.Add(rowWork34)
        csvContents.Add(rowWork35)


        Dim clsSet As New Class_analysis
        Dim outputPath As String
        Dim csvFileName As String
        Dim dateFrom As String = strYear & "/" & strMonth & "/01"
        Dim dateTo As String = strYear & "/" & strMonth & "/" & strMaxDay
        Dim exportFile As String = ""
        Dim setMon As String = ""
        Dim exportShipName As String = DropListLocation.SelectedItem.Text
        Dim dtNow As DateTime = clsSetCommon.dtIndia


        exportFile = "200.PL_Tracking_Sheet"

        dateFrom = Replace(dateFrom, "/", "")
        dateTo = Replace(dateTo, "/", "")

        'exportFile名の頭、数値を除く
        '0.PL_Tracking_Sheet
        exportFile = Right(exportFile, exportFile.Length - 4)

        If setMon = "00" Then
            If dateTo <> "" And dateFrom <> "" Then
                csvFileName = exportFile & "_ " & exportShipName & "_" & dateFrom & "_" & dateTo & ".csv"
            Else
                If dateTo <> "" Then
                    csvFileName = exportFile & "_ " & exportShipName & "_" & dateTo & ".csv"
                End If
                If dateFrom <> "" Then
                    csvFileName = exportFile & "_ " & exportShipName & "_" & dateFrom & ".csv"
                End If
            End If
        Else
            '月指定のとき
            csvFileName = exportFile & "_ " & exportShipName & "_" & dtNow.ToString("yyyy") & "_" & setMon & ".csv"
        End If

        outputPath = clsSet.CsvFilePass & csvFileName

        Using writer As New StreamWriter(outputPath, False, Encoding.Default)
            writer.WriteLine(String.Join(Environment.NewLine, csvContents))
        End Using

        'ファイルの内容をバイト配列にすべて読み込む 
        Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)

        'サーバに保存されたCSVファイルを削除
        '※Response.End以降、ファイル削除処理ができないため、ファイルのダウンロードではなく、一旦ファイルの内容を
        '上記、Bufferに保存し、ダウンロード処理を行う。

        If outputPath <> "" Then
            If System.IO.File.Exists(outputPath) = True Then
                System.IO.File.Delete(outputPath)
            End If
        End If

        ' ダウンロード
        Response.ContentType = "application/text/csv"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)
        Response.Flush()
        'Response.Write("<b>File Contents: </b>")
        Response.BinaryWrite(Buffer)
        'Response.WriteFile(outputPath)
        Response.End()
    End Sub

    Sub SonyPlTracking()



        Dim strDate As String = ""

        Dim strYear As String = ""
        strYear = DropDownYear.SelectedItem.Value
        Dim strMonth As String = ""
        strMonth = DropDownMonth.SelectedItem.Value

        Dim strMaxDay As String = ""
        strMaxDay = Date.DaysInMonth(strYear, strMonth)

        Dim strBranchName As String = ""
        Dim clsSetCommon As New Class_common
        Dim comcontrol As New CommonControl

        Dim csvContents = New List(Of String)

        '1st Left Column begin
        Dim rowWork1 As String = strBranchName & ","
        Dim rowWork2 As String = "Repair,"
        Dim rowWork3 As String = "DEMO,"
        Dim rowWork4 As String = "Installation,"
        Dim rowWork5 As String = ","
        Dim rowWork6 As String = "Warranty (Number),"
        Dim rowWork7 As String = "In Warranty (Number),"
        Dim rowWork8 As String = "Out Warranty (Number),"
        Dim rowWork9 As String = "Total Amount IW,"
        Dim rowWork10 As String = "Total Amount of Account Payable IW,"
        Dim rowWork11 As String = "Account Payable By ASC,"
        Dim rowWork12 As String = "Account Payable By Customer,"
        Dim rowWork13 As String = "SONY Needs To Pay/IW,"
        Dim rowWork14 As String = "SONY Needs To Pay/OW,"
        Dim rowWork15 As String = "Total Parts Fee,"
        Dim rowWork16 As String = "Labour Fee,"
        Dim rowWork17 As String = "Inspection Fee,"
        Dim rowWork18 As String = "Handling Fee,"
        Dim rowWork19 As String = "Transport Fee,"
        Dim rowWork20 As String = "HomeService Fee,"
        Dim rowWork21 As String = "Longdistans Fee,"
        Dim rowWork22 As String = "Travelallowance Fee,"
        Dim rowWork23 As String = "Da Fee,"
        Dim rowWork24 As String = "Demo Charge,"
        Dim rowWork25 As String = "Installation Fee,"
        Dim rowWork26 As String = "Ecall Charge,"
        Dim rowWork27 As String = "Combat Fee,"
        Dim rowWork28 As String = "Total Amount OW,"
        Dim rowWork29 As String = "Total Amount of Account Payable OW,"
        Dim rowWork30 As String = "Account Payable By ASC,"
        Dim rowWork31 As String = "Account Payable By Customer,"
        Dim rowWork32 As String = "SONY Needs To Pay,"
        Dim rowWork33 As String = "Total Parts Fee,"
        Dim rowWork34 As String = "Labour Fee,"
        Dim rowWork35 As String = "Inspection Fee,"
        Dim rowWork36 As String = "Handling Fee,"
        Dim rowWork37 As String = "Transport Fee,"
        Dim rowWork38 As String = "HomeService Fee,"
        Dim rowWork39 As String = "Longdistans Fee,"
        Dim rowWork40 As String = "Travelallowance Fee,"
        Dim rowWork41 As String = "Da Fee,"
        Dim rowWork42 As String = "Demo Charge,"
        Dim rowWork43 As String = "Installation Fee,"
        Dim rowWork44 As String = "Ecall Charge,"
        Dim rowWork45 As String = "Combat Fee,"
        Dim rowWork46 As String = "Revenue without Tax,"
        Dim rowWork47 As String = ","
        Dim rowWork48 As String = "IW parts consumed,"
        Dim rowWork49 As String = "Total parts consumed,"
        Dim rowWork50 As String = "Prime Cost Total,"
        Dim rowWork51 As String = "Gross Profit,"
        Dim rowWork52 As String = ","
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
            rowWork1 &= "," & strDate
            rowWork2 &= "," & TOT_Repair
            rowWork3 &= "," & TOT_DEMO
            rowWork4 &= "," & TOT_Installation
            rowWork5 &= ","

            TOT_WarrantyNumber = TOT_InWarrantyNumber + TOT_OutWarrantyNumber
            rowWork6 &= "," & TOT_WarrantyNumber
            rowWork7 &= "," & TOT_InWarrantyNumber
            rowWork8 &= "," & TOT_OutWarrantyNumber


            '#Total Amount IW (SONY Needs To Pay/IW + SONY Needs To Pay/OW ) /1.18
            TOT_IW_TotalAmountIW = (TOT_SONYNeedsToPayIW + TOT_SONYNeedsToPayOW) / 1.18
            TOT_IW_TotalAmountOfAccountPayableIW = TOT_IW_TotalPartsFee + TOT_IW_LabourFee + TOT_IW_InspectionFee + TOT_IW_HandlingFee + TOT_IW_TransportFee + TOT_IW_HomeServiceFee + TOT_IW_LongdistansFee + TOT_IW_TravelallowanceFee + TOT_IW_DaFee + TOT_IW_DemoCharge + TOT_IW_InstallationFee + TOT_IW_EcallCharge + TOT_IW_CombatFee
            rowWork9 &= "," & Math.Floor(TOT_IW_TotalAmountIW)
            rowWork10 &= "," & Math.Floor(TOT_IW_TotalAmountOfAccountPayableIW)
            rowWork11 &= "," & Math.Floor(TOT_IW_AccountPayableByASC)
            rowWork12 &= "," & Math.Floor(TOT_IW_AccountPayableByCustomer)
            rowWork13 &= "," & Math.Floor(TOT_SONYNeedsToPayIW)
            rowWork14 &= "," & Math.Floor(TOT_SONYNeedsToPayOW)
            rowWork15 &= "," & Math.Floor(TOT_IW_TotalPartsFee)
            rowWork16 &= "," & Math.Floor(TOT_IW_LabourFee)
            rowWork17 &= "," & Math.Floor(TOT_IW_InspectionFee)
            rowWork18 &= "," & Math.Floor(TOT_IW_HandlingFee)
            rowWork19 &= "," & Math.Floor(TOT_IW_TransportFee)
            rowWork20 &= "," & Math.Floor(TOT_IW_HomeServiceFee)
            rowWork21 &= "," & Math.Floor(TOT_IW_LongdistansFee)
            rowWork22 &= "," & Math.Floor(TOT_IW_TravelallowanceFee)
            rowWork23 &= "," & Math.Floor(TOT_IW_DaFee)
            rowWork24 &= "," & Math.Floor(TOT_IW_DemoCharge)
            rowWork25 &= "," & Math.Floor(TOT_IW_InstallationFee)
            rowWork26 &= "," & Math.Floor(TOT_IW_EcallCharge)
            rowWork27 &= "," & Math.Floor(TOT_IW_CombatFee)

            '#Total Amount OW (Total Amount of Account Payable OW - Account Payable By ASC - SONY Needs To Pay ) / 1.18
            TOT_OW_TotalAmountOW = (TOT_OW_TotalAmountOfAccountPayableOW - TOT_OW_AccountPayableByASC - TOT_SONYNeedsToPayOW) / 1.18
            rowWork28 &= "," & Math.Floor(TOT_OW_TotalAmountOW) '& ":" & TOT_OW_TotalAmountOfAccountPayableOW & ":" & TOT_IW_AccountPayableByASC & ":" & TOT_SONYNeedsToPayOW
            rowWork29 &= "," & Math.Floor(TOT_OW_TotalAmountOfAccountPayableOW)
            rowWork30 &= "," & Math.Floor(TOT_OW_AccountPayableByASC)
            rowWork31 &= "," & Math.Floor(TOT_OW_AccountPayableByCustomer)
            rowWork32 &= "," & Math.Floor(TOT_SONYNeedsToPayOW)
            rowWork33 &= "," & Math.Floor(TOT_OW_TotalPartsFee)
            rowWork34 &= "," & Math.Floor(TOT_OW_LabourFee)
            rowWork35 &= "," & Math.Floor(TOT_OW_InspectionFee)
            '#Handling Fees = =D32+D36 (Account Payable By ASC + Labour Fee )
            'TOT_OW_HandlingFee = TOT_OW_AccountPayableByASC + TOT_OW_LabourFee

            rowWork36 &= "," & Math.Floor(TOT_OW_HandlingFee)
            rowWork37 &= "," & Math.Floor(TOT_OW_TransportFee)
            rowWork38 &= "," & Math.Floor(TOT_OW_HomeServiceFee)
            rowWork39 &= "," & Math.Floor(TOT_OW_LongdistansFee)
            rowWork40 &= "," & Math.Floor(TOT_OW_TravelallowanceFee)
            rowWork41 &= "," & Math.Floor(TOT_OW_DaFee)
            rowWork42 &= "," & Math.Floor(TOT_OW_DemoCharge)
            rowWork43 &= "," & Math.Floor(TOT_OW_InstallationFee)
            rowWork44 &= "," & Math.Floor(TOT_OW_EcallCharge)
            rowWork45 &= "," & Math.Floor(TOT_OW_CombatFee)


            '#RevenuewithoutTax = Total Amount IW + Total Amount OW
            TOT_RevenuewithoutTax = TOT_IW_TotalAmountIW + TOT_OW_TotalAmountOW
            rowWork46 &= "," & Math.Floor(TOT_RevenuewithoutTax)
            rowWork47 &= ","
            '#IW parts consumed = Total Parts Fee * 0.88
            TOT_IWpartsconsumed = TOT_IW_TotalPartsFee * 0.88
            rowWork48 &= "," & Math.Floor(TOT_IWpartsconsumed)

            '#Total parts consumed =   Total Parts Fee (IW)  + Total Parts Fee (OW)
            TOT_Totalpartsconsumed = TOT_IW_TotalPartsFee + TOT_OW_TotalPartsFee
            rowWork49 &= "," & Math.Floor(TOT_Totalpartsconsumed)
            '#Prime Cost Total =  Totalpartsconsumed -  IWpartsconsumed
            TOT_PrimeCostTotal = TOT_Totalpartsconsumed - TOT_IWpartsconsumed
            rowWork50 &= "," & Math.Floor(TOT_PrimeCostTotal)
            '#Gross Profit = Revenue without Tax - Prime Cost Total
            TOT_GrossProfit = TOT_RevenuewithoutTax - TOT_PrimeCostTotal
            rowWork51 &= "," & Math.Floor(TOT_GrossProfit)
            Try
                TOT_Percentage = (TOT_GrossProfit / TOT_RevenuewithoutTax) * 100
            Catch ex As Exception
                TOT_Percentage = 0
            End Try


            rowWork52 &= "," & Math.Floor(TOT_Percentage) & "%"



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
        rowWork1 &= "," & "Total"
        rowWork2 &= "," & NET_TOT_Repair
        rowWork3 &= "," & NET_TOT_DEMO
        rowWork4 &= "," & NET_TOT_Installation
        rowWork5 &= ","


        rowWork6 &= "," & NET_TOT_WarrantyNumber
        rowWork7 &= "," & NET_TOT_InWarrantyNumber
        rowWork8 &= "," & NET_TOT_OutWarrantyNumber


        '#Total Amount IW (SONY Needs To Pay/IW + SONY Needs To Pay/OW ) /1.18

        rowWork9 &= "," & Math.Floor(NET_TOT_IW_TotalAmountIW)
        rowWork10 &= "," & Math.Floor(NET_TOT_IW_TotalAmountOfAccountPayableIW)
        rowWork11 &= "," & Math.Floor(NET_TOT_IW_AccountPayableByASC)
        rowWork12 &= "," & Math.Floor(NET_TOT_IW_AccountPayableByCustomer)
        rowWork13 &= "," & Math.Floor(NET_TOT_SONYNeedsToPayIW)
        rowWork14 &= "," & Math.Floor(NET_TOT_SONYNeedsToPayOW)
        rowWork15 &= "," & Math.Floor(NET_TOT_IW_TotalPartsFee)
        rowWork16 &= "," & Math.Floor(NET_TOT_IW_LabourFee)
        rowWork17 &= "," & Math.Floor(NET_TOT_IW_InspectionFee)
        rowWork18 &= "," & Math.Floor(NET_TOT_IW_HandlingFee)
        rowWork19 &= "," & Math.Floor(NET_TOT_IW_TransportFee)
        rowWork20 &= "," & Math.Floor(NET_TOT_IW_HomeServiceFee)
        rowWork21 &= "," & Math.Floor(NET_TOT_IW_LongdistansFee)
        rowWork22 &= "," & Math.Floor(NET_TOT_IW_TravelallowanceFee)
        rowWork23 &= "," & Math.Floor(NET_TOT_IW_DaFee)
        rowWork24 &= "," & Math.Floor(NET_TOT_IW_DemoCharge)
        rowWork25 &= "," & Math.Floor(NET_TOT_IW_InstallationFee)
        rowWork26 &= "," & Math.Floor(NET_TOT_IW_EcallCharge)
        rowWork27 &= "," & Math.Floor(NET_TOT_IW_CombatFee)

        '#Total Amount OW (Total Amount of Account Payable OW - Account Payable By ASC - SONY Needs To Pay ) / 1.18

        rowWork28 &= "," & Math.Floor(NET_TOT_OW_TotalAmountOW)
        rowWork29 &= "," & Math.Floor(NET_TOT_OW_TotalAmountOfAccountPayableOW)
        rowWork30 &= "," & Math.Floor(NET_TOT_OW_AccountPayableByASC)
        rowWork31 &= "," & Math.Floor(NET_TOT_OW_AccountPayableByCustomer)
        rowWork32 &= "," & Math.Floor(NET_TOT_SONYNeedsToPayOW)
        rowWork33 &= "," & Math.Floor(NET_TOT_OW_TotalPartsFee)
        rowWork34 &= "," & Math.Floor(NET_TOT_OW_LabourFee)
        rowWork35 &= "," & Math.Floor(NET_TOT_OW_InspectionFee)
        '#Handling Fees = =D32+D36 (Account Payable By ASC + Labour Fee )

        rowWork36 &= "," & Math.Floor(NET_TOT_OW_HandlingFee)
        rowWork37 &= "," & Math.Floor(NET_TOT_OW_TransportFee)
        rowWork38 &= "," & Math.Floor(NET_TOT_OW_HomeServiceFee)
        rowWork39 &= "," & Math.Floor(NET_TOT_OW_LongdistansFee)
        rowWork40 &= "," & Math.Floor(NET_TOT_OW_TravelallowanceFee)
        rowWork41 &= "," & Math.Floor(NET_TOT_OW_DaFee)
        rowWork42 &= "," & Math.Floor(NET_TOT_OW_DemoCharge)
        rowWork43 &= "," & Math.Floor(NET_TOT_OW_InstallationFee)
        rowWork44 &= "," & Math.Floor(NET_TOT_OW_EcallCharge)
        rowWork45 &= "," & Math.Floor(NET_TOT_OW_CombatFee)


        '#RevenuewithoutTax = Total Amount IW + Total Amount OW

        rowWork46 &= "," & Math.Floor(NET_TOT_RevenuewithoutTax)
        rowWork47 &= ","
        '#IW parts consumed = Total Parts Fee * 0.88
        rowWork48 &= "," & Math.Floor(NET_TOT_IWpartsconsumed)
        '#Total parts consumed =   Total Parts Fee (IW)  + Total Parts Fee (OW)
        rowWork49 &= "," & Math.Floor(NET_TOT_Totalpartsconsumed)
        '#Prime Cost Total =  Totalpartsconsumed -  IWpartsconsumed
        rowWork50 &= "," & Math.Floor(NET_TOT_PrimeCostTotal)
        '#Gross Profit = Revenue without Tax - Prime Cost Total
        rowWork51 &= "," & Math.Floor(NET_TOT_GrossProfit)

        Try
            NET_TOT_Percentage = (NET_TOT_GrossProfit / NET_TOT_RevenuewithoutTax) * 100
        Catch ex As Exception
            NET_TOT_Percentage = 0
        End Try


        rowWork52 &= "," & Math.Floor(NET_TOT_Percentage) & "%"
        '********************************
        'End
        '***********************************
        'Last Left Column Begin
        rowWork1 &= ",SID1"
        rowWork2 &= ",Repair"
        rowWork3 &= ",DEMO"
        rowWork4 &= ",Installation"
        rowWork5 &= ","
        rowWork6 &= ",Warranty (Number)"
        rowWork7 &= ",In Warranty (Number)"
        rowWork8 &= ",Out Warranty (Number)"
        rowWork9 &= ",Total Amount IW"
        rowWork10 &= ",Total Amount of Account Payable IW"
        rowWork11 &= ",Account Payable By ASC"
        rowWork12 &= ",Account Payable By Customer"
        rowWork13 &= ",SONY Needs To Pay/IW"
        rowWork14 &= ",SONY Needs To Pay/OW"
        rowWork15 &= ",Total Parts Fee"
        rowWork16 &= ",Labour Fee"
        rowWork17 &= ",Inspection Fee"
        rowWork18 &= ",Handling Fee"
        rowWork19 &= ",Transport Fee"
        rowWork20 &= ",HomeService Fee"
        rowWork21 &= ",Longdistans Fee"
        rowWork22 &= ",Travelallowance Fee"
        rowWork23 &= ",Da Fee"
        rowWork24 &= ",Demo Charge"
        rowWork25 &= ",Installation Fee"
        rowWork26 &= ",Ecall Charge"
        rowWork27 &= ",Combat Fee"
        rowWork28 &= ",Total Amount OW"
        rowWork29 &= ",Total Amount of Account Payable OW"
        rowWork30 &= ",Account Payable By ASC"
        rowWork31 &= ",Account Payable By Customer"
        rowWork32 &= ",SONY Needs To Pay"
        rowWork33 &= ",Total Parts Fee"
        rowWork34 &= ",Labour Fee"
        rowWork35 &= ",Inspection Fee"
        rowWork36 &= ",Handling Fee"
        rowWork37 &= ",Transport Fee"
        rowWork38 &= ",HomeService Fee"
        rowWork39 &= ",Longdistans Fee"
        rowWork40 &= ",Travelallowance Fee"
        rowWork41 &= ",Da Fee"
        rowWork42 &= ",Demo Charge"
        rowWork43 &= ",Installation Fee"
        rowWork44 &= ",Ecall Charge"
        rowWork45 &= ",Combat Fee"
        rowWork46 &= ",Revenue without Tax"
        rowWork47 &= ","
        rowWork48 &= ",IW parts consumed"
        rowWork49 &= ",Total parts consumed"
        rowWork50 &= ",Prime Cost Total"
        rowWork51 &= ",Gross Profit"
        rowWork52 &= ","
        'Last Left Column End


        csvContents.Add(rowWork1)
        csvContents.Add(rowWork2)
        csvContents.Add(rowWork3)
        csvContents.Add(rowWork4)
        csvContents.Add(rowWork5)
        csvContents.Add(rowWork6)
        csvContents.Add(rowWork7)
        csvContents.Add(rowWork8)
        csvContents.Add(rowWork9)
        csvContents.Add(rowWork10)
        csvContents.Add(rowWork11)
        csvContents.Add(rowWork12)
        csvContents.Add(rowWork13)
        csvContents.Add(rowWork14)
        csvContents.Add(rowWork15)
        csvContents.Add(rowWork16)
        csvContents.Add(rowWork17)
        csvContents.Add(rowWork18)
        csvContents.Add(rowWork19)
        csvContents.Add(rowWork20)
        csvContents.Add(rowWork21)
        csvContents.Add(rowWork22)
        csvContents.Add(rowWork23)
        csvContents.Add(rowWork24)
        csvContents.Add(rowWork25)
        csvContents.Add(rowWork26)
        csvContents.Add(rowWork27)
        csvContents.Add(rowWork28)
        csvContents.Add(rowWork29)
        csvContents.Add(rowWork30)
        csvContents.Add(rowWork31)
        csvContents.Add(rowWork32)
        csvContents.Add(rowWork33)
        csvContents.Add(rowWork34)
        csvContents.Add(rowWork35)
        csvContents.Add(rowWork36)
        csvContents.Add(rowWork37)
        csvContents.Add(rowWork38)
        csvContents.Add(rowWork39)
        csvContents.Add(rowWork40)
        csvContents.Add(rowWork41)
        csvContents.Add(rowWork42)
        csvContents.Add(rowWork43)
        csvContents.Add(rowWork44)
        csvContents.Add(rowWork45)
        csvContents.Add(rowWork46)
        csvContents.Add(rowWork47)
        csvContents.Add(rowWork48)
        csvContents.Add(rowWork49)
        csvContents.Add(rowWork50)
        csvContents.Add(rowWork51)
        csvContents.Add(rowWork52)

        Dim clsSet As New Class_analysis
        Dim outputPath As String
        Dim csvFileName As String
        Dim dateFrom As String = strYear & "/" & strMonth & "/01"
        Dim dateTo As String = strYear & "/" & strMonth & "/" & strMaxDay
        Dim exportFile As String = ""
        Dim setMon As String = ""
        Dim exportShipName As String = "SID1"
        Dim dtNow As DateTime = clsSetCommon.dtIndia


        exportFile = "0.PL_Tracking_Sheet"

        dateFrom = Replace(dateFrom, "/", "")
        dateTo = Replace(dateTo, "/", "")

        'exportFile名の頭、数値を除く
        '0.PL_Tracking_Sheet
        exportFile = Right(exportFile, exportFile.Length - 2)

        If setMon = "00" Then
            If dateTo <> "" And dateFrom <> "" Then
                csvFileName = exportFile & "_ " & exportShipName & "_" & dateFrom & "_" & dateTo & ".csv"
            Else
                If dateTo <> "" Then
                    csvFileName = exportFile & "_ " & exportShipName & "_" & dateTo & ".csv"
                End If
                If dateFrom <> "" Then
                    csvFileName = exportFile & "_ " & exportShipName & "_" & dateFrom & ".csv"
                End If
            End If
        Else
            '月指定のとき
            csvFileName = exportFile & "_ " & exportShipName & "_" & dtNow.ToString("yyyy") & "_" & setMon & ".csv"
        End If

        outputPath = clsSet.CsvFilePass & csvFileName

        Using writer As New StreamWriter(outputPath, False, Encoding.Default)
            writer.WriteLine(String.Join(Environment.NewLine, csvContents))
        End Using

        'ファイルの内容をバイト配列にすべて読み込む 
        Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)

        'サーバに保存されたCSVファイルを削除
        '※Response.End以降、ファイル削除処理ができないため、ファイルのダウンロードではなく、一旦ファイルの内容を
        '上記、Bufferに保存し、ダウンロード処理を行う。

        If outputPath <> "" Then
            If System.IO.File.Exists(outputPath) = True Then
                System.IO.File.Delete(outputPath)
            End If
        End If

        ' ダウンロード
        Response.ContentType = "application/text/csv"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)
        Response.Flush()
        'Response.Write("<b>File Contents: </b>")
        Response.BinaryWrite(Buffer)
        'Response.WriteFile(outputPath)
        Response.End()
    End Sub


    Private Sub OldFunctionality()
        '***セッション情報取得***
        Dim userid As String = Session("user_id")
        Dim userName As String = Session("user_Name")
        Dim userLevel As String = Session("user_level")
        Dim adminFlg As Boolean = Session("admin_Flg")

        Dim setMon As String = Session("set_Mon2")
        Dim setMonName As String = Session("set_MonName")
        Dim exportFile As String = Session("export_File")
        Dim exportShipName As String = DropListLocation.SelectedItem.Text 'Session("export_shipName")

        Dim clsSetCommon As New Class_common
        Dim dtNow As DateTime = clsSetCommon.dtIndia

        Dim comcontrol As New CommonControl
        'comcontrol.Money_Round()
        If userid Is Nothing Then
            Call showMsg("The session has expired. Please login again.", "")
            Exit Sub
        End If

        Dim i, j As Integer

        '***入力チェック***
        If exportShipName = "Select Branch" Then
            Call showMsg("Please specify the branch name.", "")
            Exit Sub
        End If

        Dim dt As DateTime
        Dim dateFrom As String
        Dim dateTo As String
        Dim outputPath As String

        If TextDateFrom.Text <> "" Then
            If exportFile = "Sales Invoice To Sony ""C""" Or exportFile = "Sales Invoice To Sony ""EXC""" Then
                Call showMsg("You can Select only the month specification.", "")
                Exit Sub
            End If
            If DateTime.TryParse(TextDateFrom.Text, dt) Then
                dateFrom = DateTime.Parse(Trim(TextDateFrom.Text)).ToShortDateString
            Else
                Call showMsg("There Is an Error In the Date specification", "")
                Exit Sub
            End If
        Else
            dateFrom = ""
        End If

        If TextDateTo.Text <> "" Then
            If exportFile = "Sales Invoice To Sony ""C""" Or exportFile = "Sales Invoice To Sony ""EXC""" Then
                Call showMsg("You can Select only the month specification.", "")
                Exit Sub
            End If
            If DateTime.TryParse(TextDateTo.Text, dt) Then
                dateTo = DateTime.Parse(Trim(TextDateTo.Text)).ToShortDateString
            Else
                'Call showMsg("The Date specification Of To Is incorrect.", "")
                'Exit Sub
                dateTo = "10-04-2020"
            End If
        Else
            dateTo = ""
        End If

        If dateFrom = "" And dateTo = "" And setMon = "00" Then
            Call showMsg("Please specify either output period by month Or Date", "")
            Exit Sub
        End If

        If dateFrom <> "" And dateTo <> "" And setMon <> "00" Then
            Call showMsg("Please specify either output period by month Or Date.", "")
            Exit Sub
        End If

        If setMon <> "00" Then
            If dateFrom <> "" Or dateTo <> "" Then
                Call showMsg("Please specify either output period by month Or Date.", "")
                Exit Sub
            End If
        End If

        If exportFile = "Select Export Filename" Then
            Call showMsg("Please specify the file type To be exported.", "")
            Exit Sub
        End If

        '***CSV出力処理***
        Dim clsSet As New Class_analysis
        Dim errFlg As Integer

        '■拠点コード取得
        Dim shipCode As String
        Dim errMsg As String

        Call clsSetCommon.setShipCode(exportShipName, shipCode, errMsg)

        If errMsg <> "" Then
            Call showMsg(errMsg, "")
            Exit Sub
        End If

        'CSVファイルの種類
        Dim kindExport As Integer = Left(exportFile, 1)

        ''Matching old Records
        ''<asp:ListItem Text = "0.PL_Tracking_Sheet" Value="0"></asp: ListItem>=> kindExport = 1
        '<asp:ListItem Text = "1.DailyRepairStatement" Value="1"></asp: ListItem>  --- ?? No functionality as of now?
        ''<asp:ListItem Text="2.Warranty Excel File" Value="2"></asp:ListItem>     --- ??  No functionality as of now
        ''<asp:ListItem Text = "3.Sales Register from GSPN IW" Value="3"></asp: ListItem>=> kindExport = 5
        ''<asp:ListItem Text = "4.Sales Register from GSPN OOW" Value="4"></asp: ListItem>=> kindExport = 2
        ''<asp:ListItem Text = "18.Sales Register from GSPN OOW" Value="4"></asp: ListItem>=> kindExport = 2

        If kindExport = "1" Then
            kindExport = "1"
        ElseIf kindExport = "0" Then
            'No funtionality as of now
            kindExport = -99
        ElseIf kindExport = "3" Then
            kindExport = "5"
        ElseIf kindExport = "4" Then
            kindExport = "2"
        ElseIf kindExport = "17" Then
            kindExport = "9"
        End If
        Dim csvContents1 = New List(Of String)
        '■PL_Tracking_Sheet出力
        If kindExport = 1 Then
            '''''''Dim TmpRate As Decimal = 0.00
            '''''''If Decimal.TryParse(txtRate.Text, TmpRate) Then
            '''''''Else
            '''''''    Call showMsg("The rate Is Not valid ", "")
            '''''''    Exit Sub
            '''''''End If

            'Comment on 20200129
            ''''''''''''''Try
            '***内容設定***
            '■Activity_reportデータ取得
            Dim activeData() As Class_analysis.SONY_ACTIVITY_REPORT
            Dim dsActivity_report As New DataSet
            Dim dsActivityReportTmp As New DataSet
            Dim strSQL2 As String = ""
            Dim strSQL4 As String = ""
            ' Dim csvContents = New List(Of String)

            If setMon <> "00" Then


                'OLD Query Comment by Balaji

                strSQL2 &= "SET ARITHABORT OFF;"
                strSQL2 &= "SET ANSI_WARNINGS OFF;"
                strSQL2 &= " With PLTrack As ("
                strSQL2 &= " Select sa.day, sa.youbi,sa.CustomerVisit,sa.CallRegistered,sa.RepairCompleted,sa.GoodsDelivered,sa.PendingCalls,sa.Total,"
                strSQL2 &= " sab.Collect_Date, sab.InWarrantyNumber, sab.OutWarrantyNumber,"
                'strSQL2 &= " CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18 as INWarrantyAmount,"
                strSQL2 &= " CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2)) as INWarrantyAmount,"
                strSQL2 &= " sab.INWarrantyLabor, sac.INWarrantyParts, sab.INWarrantyTransport, sac.INWarrantyOthers, sac.OutWarrantyAmount, sac.OutWarrantyLabor,"
                strSQL2 &= " sac.OutWarrantyParts, sac.OutWarrantyTransports, sac.OutWarrantyOthers, sac.SAWDiscountLabor, sac.SAWDiscountParts, sac.OutWarrantyLabourwSAWDisc,"
                strSQL2 &= " sac.OutLaborFee, sac.HomeServiceFee, sac.LongFee, sac.OutWarrantyPartswSAWDisc,"
                'strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18) +"
                strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2))) +"
                strSQL2 &= " (CAST(IsNULL(SAC.OutWarrantyLabor, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyParts, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyTransports, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyOthers, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountLabor, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountParts, '0') as numeric(18,2))) as RevenueWithoutTax,"
                strSQL2 &= " sac.IWPARTSCONSUMED, sac.TOTALPARTSCONSUMED, sac.PRIMECOSTTOTAL,"
                'strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18) +"
                strSQL2 &= "(CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2))) +"
                strSQL2 &= " (CAST(IsNULL(SAC.OutWarrantyLabor, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyParts, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyTransports, '0') as numeric(18,2)) + "
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyOthers, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountLabor, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountParts, '0') as numeric(18,2))) - "
                strSQL2 &= " SAC.PRIMECOSTTOTAL as GrossProfit"
                strSQL2 &= " from"
                strSQL2 &= "(SELECT (CONVERT(DATETIME, month + '/' + day)) as day , DATENAME(WEEKDAY,(CONVERT(DATETIME, month + '/' + day)) ) as youbi, sum(customer_visit_S+customer_visit_D) as CustomerVisit,sum(Call_Registerd_S+Call_Registerd_D) as CallRegistered,sum(Repair_Completed_S+Repair_Completed_D) as RepairCompleted,sum(Goods_Delivered_S+Goods_Delivered_D) as GoodsDelivered,sum(Pending_Calls_S+Pending_Calls_D) as PendingCalls,"
                strSQL2 &= "sum(Customer_Visit_S + Customer_Visit_D + Call_Registerd_S + Call_Registerd_D + Repair_Completed_S + Repair_Completed_D + Goods_Delivered_S + Goods_Delivered_D + Pending_Calls_S + Pending_Calls_D) As Total"
                'strSQL2 &= " From dbo.Sony_Activity_Report Where location = '" & shipCode & "' And (Convert(DateTime, Month() + '/' + day)) <= CONVERT(DATETIME, '2020/09/30') AND (CONVERT(DATETIME, month + '/' + day)) >= CONVERT(DATETIME, '2020/09/01') Group by(Convert(DateTime, Month + '/' + day)) ) sa"
                'strSQL2 &= " From dbo.Sony_Activity_Report Where location = '" & shipCode & "' "
                strSQL2 &= " From dbo.Sony_Activity_Report WHERE Month = '" & DropDownYear.SelectedItem.Text & "/" & setMon & "' AND DELFG =0 AND location = '" & shipCode & "'"

                strSQL2 &= " Group by(Convert(DateTime, Month + '/' + day)) ) sa"
                strSQL2 &= " left outer Join "
                strSQL2 &= "(select convert(datetime,convert(varchar(10),COLLECT_DATE,101)) COLLECT_DATE , "
                strSQL2 &= "sum(Convert(Int,case when WARRANTY_TYPE = 'IW' then 1 else 0 end)) 'INWarrantyNumber',"
                strSQL2 &= "sum(Convert(Int,case when WARRANTY_TYPE = 'OW' then 1 else 0 end)) 'OutWarrantyNumber',"
                strSQL2 &= "sum(CAST(ISNULL(TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, 0)As NUMERIC(18, 2))) As INWarrantyLabor,"
                strSQL2 &= "sum(CAST(ISNULL(SONY_NEEDS_TO_PAY, 0)As NUMERIC(18, 2))) As INWarrantyTransport"
                'strSQL2 &= " From SONY_DAILY_DELIVERED Where DELFG = 0 AND COLLECT_DATE = '" & DropDownYear.SelectedItem.Text & "/" & setMon & "' AND SHIP_TO_BRANCH_CODE= '" & shipCode & "'"
                strSQL2 &= " From dbo.SONY_DAILY_DELIVERED WHERE Convert(varchar, Convert(varchar(10), COLLECT_DATE, 111)) like '%" & DropDownYear.SelectedItem.Text & "/" & setMon & "%' AND DELFG =0 AND SHIP_TO_BRANCH_CODE = '" & shipCode & "'"
                strSQL2 &= " Group By Convert(DateTime, Convert(varchar(10), COLLECT_DATE, 101))) sab"
                strSQL2 &= " On sa.day = sab.COLLECT_DATE "
                strSQL2 &= " left outer Join"

                strSQL2 &= "(Select Convert(DateTime, Convert(varchar(10), SDD.COLLECT_DATE, 101)) As COLLECT_DATE,SUM(CAST(ISNULL(SMR.LABOR_FEE, 0)As NUMERIC(18, 2))) As INWarrantyParts,SUM(CAST(ISNULL(SMR.ASC_PAY, 0)As NUMERIC(18, 2))) As INWarrantyOthers, SUM(CAST(ISNULL(SMR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, '0') as numeric(18,2))) as OutWarrantyLabor,SUM(CAST(ISNULL(SMR.ACCOUNT_PAYABLE_BY_CUSTOMER, '0') as numeric(18,2)) ) as OutWarrantyParts,SUM(CAST(ISNULL(SMR.SONY_NEEDS_TO_PAY, '0') as numeric(18,2)) ) as OutWarrantyTransports,SUM(CAST(ISNULL(SMR.ASC_PAY, '0') as numeric(18,2))) as OutWarrantyOthers,SUM(CAST(ISNULL(SMR.PART_FEE, '0') as numeric(18,2))) AS SAWDiscountLabor,SUM(CAST(ISNULL(SMR.INSPECTION_FEE, '0') as numeric(18,2))) AS SAWDiscountParts,"
                'strSQL2 &=" SUM(CAST(ISNULL(SMR.HANDLING_FEE, '0') as numeric(18,2))) as OutWarrantyLabourwSAWDisc,"
                strSQL2 &= "SUM((CAST(ISNULL(SMR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, '0') as numeric(18,2)))+(CAST(ISNULL(SMR.PART_FEE, '0') as numeric(18,2))))  as OutWarrantyLabourwSAWDisc,"
                strSQL2 &= " SUM(CAST(ISNULL(SMR.LABOR_FEE, '0') as numeric(18,2))) as OutLaborFee,SUM(CAST(ISNULL(SMR.HOME_SERVICE_FEE, '0') as numeric(18,2))) as HomeServiceFee,SUM(CAST(ISNULL(SMR.LONG_FEE, '0') as numeric(18,2))) as LongFee,"
                'strSQL2 &= " SUM(CAST(ISNULL(SMR.INSTALL_FEE, '0') as numeric(18,2))) as OutWarrantyPartswSAWDisc,"
                strSQL2 &= " SUM((CAST(ISNULL(SMR.ACCOUNT_PAYABLE_BY_CUSTOMER, '0') as numeric(18,2)))+(CAST(ISNULL(SMR.INSPECTION_FEE, '0') as numeric(18,2))))as OutWarrantyPartswSAWDisc,"
                strSQL2 &= " SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2))* 0.88) )AS IWPARTSCONSUMED,SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2)) + CAST(IsNULL(SMR.INSTALL_FEE, '0') as numeric(18,2))*0.88)) AS TOTALPARTSCONSUMED,SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2)) + CAST(IsNULL(SMR.INSTALL_FEE, '0') as numeric(18,2))*0.88) - (CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2))* 0.88)) AS PRIMECOSTTOTAL,"

                strSQL2 &= " sum(("
                strSQL2 &= "CAST(IsNULL(SMR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, '0') as numeric(18,2)) + "
                strSQL2 &= "CAST(IsNULL(SMR.ACCOUNT_PAYABLE_BY_CUSTOMER, '0') as numeric(18,2)) +"
                strSQL2 &= "CAST(IsNULL(SMR.SONY_NEEDS_TO_PAY, '0') as numeric(18,2)) +"
                strSQL2 &= "CAST(IsNULL(SMR.ASC_PAY, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SMR.PART_FEE, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SMR.INSPECTION_FEE, '0') as numeric(18,2)) "
                strSQL2 &= " ))AS OutWarrantyAmount"
                strSQL2 &= " From SONY_DAILY_DELIVERED SDD full outer JOIN SONY_MONTHLY_REPAIRSET SMR ON SDD.JOB_ID = SMR.JOB_NUMBER And SDD.SERIAL_NO = SMR.SERIAL_NO AND "
                strSQL2 &= " SMR.DELFG = 0 And SDD.DELFG = 0 And Convert(varchar, Convert(varchar(10), COLLECT_DATE, 111)) like '%" & DropDownYear.SelectedItem.Text & "/" & setMon & "%' AND SMR.SHIP_TO_BRANCH_CODE ='" & shipCode & "'  Group BY convert(datetime, Convert(varchar(10), SDD.COLLECT_DATE, 101)) ) sac"
                strSQL2 &= " On sab.COLLECT_DATE = sac.COLLECT_DATE)"
                ' strSQL2 &= " Select *, CAST(GrossProfit/RevenueWithoutTax *100 AS varchar(20)) + '%' as TotalPercentage from PLTrack order by day"
                strSQL2 &= " Select * from PLTrack order by day"



            Else


                'old query by balaji
                strSQL2 &= "With PLTrack As("
                strSQL2 &= " Select sa.day, sa.youbi,sa.CustomerVisit,sa.CallRegistered,sa.RepairCompleted,sa.GoodsDelivered,sa.PendingCalls,sa.Total,"
                strSQL2 &= " sab.Collect_Date, sab.InWarrantyNumber, sab.OutWarrantyNumber,"
                'strSQL2 &= " CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18 as INWarrantyAmount,"
                strSQL2 &= "CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2)) as INWarrantyAmount,"
                strSQL2 &= " sab.INWarrantyLabor, sac.INWarrantyParts, sab.INWarrantyTransport, sac.INWarrantyOthers, sac.OutWarrantyAmount, sac.OutWarrantyLabor,"
                strSQL2 &= " sac.OutWarrantyParts, sac.OutWarrantyTransports, sac.OutWarrantyOthers, sac.SAWDiscountLabor, sac.SAWDiscountParts, sac.OutWarrantyLabourwSAWDisc,"
                strSQL2 &= " sac.OutLaborFee, sac.HomeServiceFee, sac.LongFee, sac.OutWarrantyPartswSAWDisc,"
                'strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18) +"
                strSQL2 &= "(CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2))) +"
                strSQL2 &= " (CAST(IsNULL(SAC.OutWarrantyLabor, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyParts, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyTransports, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyOthers, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountLabor, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountParts, '0') as numeric(18,2))) as RevenueWithoutTax,"
                strSQL2 &= " sac.IWPARTSCONSUMED, sac.TOTALPARTSCONSUMED, sac.PRIMECOSTTOTAL,"
                ' strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18) +"
                strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2))) +"
                strSQL2 &= " (CAST(IsNULL(SAC.OutWarrantyLabor, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyParts, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyTransports, '0') as numeric(18,2)) + "
                strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyOthers, '0') as numeric(18,2)) +"
                strSQL2 &= "CAST(IsNULL(SAC.SAWDiscountLabor, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountParts, '0') as numeric(18,2))) - "
                strSQL2 &= " SAC.PRIMECOSTTOTAL as GrossProfit"
                strSQL2 &= " from"
                strSQL2 &= "(SELECT (CONVERT(DATETIME, month + '/' + day)) as day , DATENAME(WEEKDAY,(CONVERT(DATETIME, month + '/' + day)) ) as youbi, sum(customer_visit_S+customer_visit_D) as CustomerVisit,sum(Call_Registerd_S+Call_Registerd_D) as CallRegistered,sum(Repair_Completed_S+Repair_Completed_D) as RepairCompleted,sum(Goods_Delivered_S+Goods_Delivered_D) as GoodsDelivered,sum(Pending_Calls_S+Pending_Calls_D) as PendingCalls,"
                strSQL2 &= "sum(Customer_Visit_S + Customer_Visit_D + Call_Registerd_S + Call_Registerd_D + Repair_Completed_S + Repair_Completed_D + Goods_Delivered_S + Goods_Delivered_D + Pending_Calls_S + Pending_Calls_D) As Total"
                'strSQL2 &= " From dbo.Sony_Activity_Report Where location = '" & shipCode & "' And (Convert(DateTime, Month() + '/' + day)) <= CONVERT(DATETIME, '2020/09/30') AND (CONVERT(DATETIME, month + '/' + day)) >= CONVERT(DATETIME, '2020/09/01') Group by(Convert(DateTime, Month + '/' + day)) ) sa"
                strSQL2 &= " From dbo.Sony_Activity_Report Where DELFG=0 and location = '" & shipCode & "' "
                If dateTo <> "" Then
                    If dateFrom <> "" Then
                        strSQL2 &= "AND (CONVERT(DATETIME, month + '/' + day)) <= CONVERT(DATETIME, '" & dateTo & "') "
                        strSQL2 &= "AND (CONVERT(DATETIME, month + '/' + day)) >= CONVERT(DATETIME, '" & dateFrom & "') "
                    Else
                        strSQL2 &= "AND (CONVERT(DATETIME, month + '/' + day)) <= CONVERT(DATETIME, '" & dateTo & "') "
                    End If
                Else
                    If dateFrom <> "" Then
                        strSQL2 &= "AND (CONVERT(DATETIME, month + '/' + day)) >= CONVERT(DATETIME, '" & dateFrom & "') "
                    End If
                End If
                strSQL2 &= " Group by(Convert(DateTime, Month + '/' + day)) ) sa"
                strSQL2 &= " full outer Join "
                strSQL2 &= "(select convert(datetime,convert(varchar(10),COLLECT_DATE,101)) COLLECT_DATE , "
                strSQL2 &= "sum(Convert(Int,case when WARRANTY_TYPE = 'IW' then 1 else 0 end)) 'INWarrantyNumber',"
                strSQL2 &= "sum(Convert(Int,case when WARRANTY_TYPE = 'OW' then 1 else 0 end)) 'OutWarrantyNumber',"
                strSQL2 &= "sum(CAST(ISNULL(TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, 0)As NUMERIC(18, 2))) As INWarrantyLabor,"
                strSQL2 &= "sum(CAST(ISNULL(SONY_NEEDS_TO_PAY, 0)As NUMERIC(18, 2))) As INWarrantyTransport"
                strSQL2 &= " From SONY_DAILY_DELIVERED Where DELFG = 0 and SHIP_TO_BRANCH_CODE='" & shipCode & "'"
                If dateTo <> "" Then
                    If dateFrom <> "" Then
                        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) <= CONVERT(DATETIME, '" & dateTo & "') "
                        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) >= CONVERT(DATETIME, '" & dateFrom & "') "
                    Else
                        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) <= CONVERT(DATETIME, '" & dateTo & "') "

                    End If
                Else
                    If dateFrom <> "" Then
                        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) >= CONVERT(DATETIME, '" & dateFrom & "') "
                    End If
                End If


                strSQL2 &= "Group By Convert(DateTime, Convert(varchar(10), COLLECT_DATE, 101))) sab"
                strSQL2 &= " On sa.day = sab.COLLECT_DATE "
                strSQL2 &= " left outer Join"

                strSQL2 &= "(Select Convert(DateTime, Convert(varchar(10), SDD.COLLECT_DATE, 101)) As COLLECT_DATE,SUM(CAST(ISNULL(SMR.LABOR_FEE, 0)As NUMERIC(18, 2))) As INWarrantyParts,SUM(CAST(ISNULL(SMR.ASC_PAY, 0)As NUMERIC(18, 2))) As INWarrantyOthers, SUM(CAST(ISNULL(SMR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, '0') as numeric(18,2))) as OutWarrantyLabor,SUM(CAST(ISNULL(SMR.ACCOUNT_PAYABLE_BY_CUSTOMER, '0') as numeric(18,2)) ) as OutWarrantyParts,SUM(CAST(ISNULL(SMR.SONY_NEEDS_TO_PAY, '0') as numeric(18,2)) ) as OutWarrantyTransports,SUM(CAST(ISNULL(SMR.ASC_PAY, '0') as numeric(18,2))) as OutWarrantyOthers,SUM(CAST(ISNULL(SMR.PART_FEE, '0') as numeric(18,2))) AS SAWDiscountLabor,SUM(CAST(ISNULL(SMR.INSPECTION_FEE, '0') as numeric(18,2))) AS SAWDiscountParts,"
                'strSQL2 &= "SUM(CAST(ISNULL(SMR.HANDLING_FEE, '0') as numeric(18,2))) as OutWarrantyLabourwSAWDisc,"
                strSQL2 &= "SUM((CAST(ISNULL(SMR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, '0') as numeric(18,2)))+(CAST(ISNULL(SMR.PART_FEE, '0') as numeric(18,2))))  as OutWarrantyLabourwSAWDisc,"
                strSQL2 &= "SUM(CAST(ISNULL(SMR.LABOR_FEE, '0') as numeric(18,2))) as OutLaborFee,SUM(CAST(ISNULL(SMR.HOME_SERVICE_FEE, '0') as numeric(18,2))) as HomeServiceFee,SUM(CAST(ISNULL(SMR.LONG_FEE, '0') as numeric(18,2))) as LongFee,"
                'strSQL2 &= "SUM(CAST(ISNULL(SMR.INSTALL_FEE, '0') as numeric(18,2))) as OutWarrantyPartswSAWDisc,"
                strSQL2 &= "SUM((CAST(ISNULL(SMR.ACCOUNT_PAYABLE_BY_CUSTOMER, '0') as numeric(18,2)))+(CAST(ISNULL(SMR.INSPECTION_FEE, '0') as numeric(18,2))))as OutWarrantyPartswSAWDisc,"
                strSQL2 &= "SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2))* 0.88) )AS IWPARTSCONSUMED,SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2)) + CAST(IsNULL(SMR.INSTALL_FEE, '0') as numeric(18,2))*0.88)) AS TOTALPARTSCONSUMED,SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2)) + CAST(IsNULL(SMR.INSTALL_FEE, '0') as numeric(18,2))*0.88) - (CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2))* 0.88)) AS PRIMECOSTTOTAL,"

                strSQL2 &= " sum(("
                strSQL2 &= "CAST(IsNULL(SMR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, '0') as numeric(18,2)) + "
                strSQL2 &= "CAST(IsNULL(SMR.ACCOUNT_PAYABLE_BY_CUSTOMER, '0') as numeric(18,2)) +"
                strSQL2 &= "CAST(IsNULL(SMR.SONY_NEEDS_TO_PAY, '0') as numeric(18,2)) +"
                strSQL2 &= "CAST(IsNULL(SMR.ASC_PAY, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SMR.PART_FEE, '0') as numeric(18,2)) +"
                strSQL2 &= " CAST(IsNULL(SMR.INSPECTION_FEE, '0') as numeric(18,2)) "
                strSQL2 &= " ))AS OutWarrantyAmount"
                strSQL2 &= " From SONY_DAILY_DELIVERED SDD full outer Join SONY_MONTHLY_REPAIRSET SMR ON SDD.JOB_ID = SMR.JOB_NUMBER And SDD.SERIAL_NO = SMR.SERIAL_NO Where SMR.DELFG = 0 And SDD.DELFG = 0 And SMR.SHIP_TO_BRANCH_CODE ='" & shipCode & "' "
                If dateTo <> "" Then
                    If dateFrom <> "" Then
                        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) <= CONVERT(DATETIME, '" & dateTo & "') "
                        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) >= CONVERT(DATETIME, '" & dateFrom & "') "
                    Else
                        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) <= CONVERT(DATETIME, '" & dateTo & "') "
                    End If
                Else
                    If dateFrom <> "" Then
                        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) >= CONVERT(DATETIME, '" & dateFrom & "') "
                    End If
                End If


                strSQL2 &= " Group BY convert(datetime, Convert(varchar(10), SDD.COLLECT_DATE, 101)) ) sac"
                strSQL2 &= " On sab.COLLECT_DATE = sac.COLLECT_DATE)"
                'strSQL2 &= " Select *, CAST(GrossProfit/RevenueWithoutTax *100 AS varchar(20)) + '%' as TotalPercentage from PLTrack order by day"
                strSQL2 &= " Select * from PLTrack order by day"

                'New Query changed by Balaji

                'strSQL2 &= "With PLTrack As("
                'strSQL2 &= " Select  sa.day, IsNull(sa.youbi,0) as youbi,sa.CustomerVisit,sa.CallRegistered,sa.RepairCompleted,sa.GoodsDelivered,sa.PendingCalls,sa.Total,"
                'strSQL2 &= " sab.Collect_Date,sab.InWarrantyNumber,sab.OutWarrantyNumber,sab.job_id,sac.job_number,"
                ''strSQL2 &= " CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18 as INWarrantyAmount,"
                'strSQL2 &= " CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2)) as INWarrantyAmount,"
                'strSQL2 &= " sab.INWarrantyLabor,sac.INWarrantyParts,sab.INWarrantyTransport,sac.INWarrantyOthers,sac.OutWarrantyAmount,sac.OutWarrantyLabor,"
                'strSQL2 &= " sac.OutWarrantyParts,sac.OutWarrantyTransports,sac.OutWarrantyOthers,sac.SAWDiscountLabor,sac.SAWDiscountParts,sac.OutWarrantyLabourwSAWDisc,"
                'strSQL2 &= " sac.OutLaborFee,sac.HomeServiceFee,sac.LongFee,sac.OutWarrantyPartswSAWDisc,"
                ''strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18) +"
                'strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2))) +"
                'strSQL2 &= " (CAST(IsNULL(SAC.OutWarrantyLabor, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyParts, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyTransports, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyOthers, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountLabor, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountParts, '0') as numeric(18,2))) as RevenueWithoutTax,"
                'strSQL2 &= " sac.IWPARTSCONSUMED,sac.TOTALPARTSCONSUMED,sac.PRIMECOSTTOTAL,"
                '' strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0')AS NUMERIC(18,2)) - CAST(ISNULL(sac.INWarrantyOthers,0)AS NUMERIC(18,2))/1.18) +"
                'strSQL2 &= " (CAST(ISNULL(sab.INWarrantyLabor,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sab.INWarrantyTransport,'0') AS NUMERIC(18,2)) + CAST(ISNULL(sac.INWarrantyOthers,'0')AS NUMERIC(18,2))) +"
                'strSQL2 &= " (CAST(IsNULL(SAC.OutWarrantyLabor, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyParts, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyTransports, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.OutWarrantyOthers, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountLabor, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SAC.SAWDiscountParts, '0') as numeric(18,2))) -"
                'strSQL2 &= " SAC.PRIMECOSTTOTAL as GrossProfit"
                'strSQL2 &= " from"
                'strSQL2 &= " (SELECT distinct (CONVERT(DATETIME, month + '/' + day)) as day , DATENAME(WEEKDAY,(CONVERT(DATETIME, month + '/' + day)) ) as youbi, sum(customer_visit_S+customer_visit_D) as CustomerVisit,sum(Call_Registerd_S+Call_Registerd_D) as CallRegistered,sum(Repair_Completed_S+Repair_Completed_D) as RepairCompleted,sum(Goods_Delivered_S+Goods_Delivered_D) as GoodsDelivered,sum(Pending_Calls_S+Pending_Calls_D) as PendingCalls,"
                'strSQL2 &= " sum(Customer_Visit_S+Customer_Visit_D+Call_Registerd_S+Call_Registerd_D+Repair_Completed_S+Repair_Completed_D+Goods_Delivered_S+Goods_Delivered_D+Pending_Calls_S+Pending_Calls_D) as Total"
                ''strSQL2 &= " From dbo.Sony_Activity_Report Where location = '" & shipCode & "' And (Convert(DateTime, Month() + '/' + day)) <= CONVERT(DATETIME, '2020/09/30') AND (CONVERT(DATETIME, month + '/' + day)) >= CONVERT(DATETIME, '2020/09/01') Group by(Convert(DateTime, Month + '/' + day)) ) sa"
                'strSQL2 &= " From dbo.Sony_Activity_Report Where DELFG=0 and location = '" & shipCode & "' "
                'If dateTo <> "" Then
                '    If dateFrom <> "" Then
                '        strSQL2 &= "AND (CONVERT(DATETIME, month + '/' + day)) <= CONVERT(DATETIME, '" & dateTo & "') "
                '        strSQL2 &= "AND (CONVERT(DATETIME, month + '/' + day)) >= CONVERT(DATETIME, '" & dateFrom & "') "
                '    Else
                '        strSQL2 &= "AND (CONVERT(DATETIME, month + '/' + day)) <= CONVERT(DATETIME, '" & dateTo & "') "
                '    End If
                'Else
                '    If dateFrom <> "" Then
                '        strSQL2 &= "AND (CONVERT(DATETIME, month + '/' + day)) >= CONVERT(DATETIME, '" & dateFrom & "') "
                '    End If
                'End If
                'strSQL2 &= " Group by(Convert(DateTime, Month + '/' + day)) ) sa"
                'strSQL2 &= " full outer Join "
                'strSQL2 &= " (select convert(datetime,convert(varchar(10),COLLECT_DATE,101)) COLLECT_DATE ,JOB_ID,"
                'strSQL2 &= " sum(convert(int,case when WARRANTY_TYPE = 'IW' then 1 else 0 end)) 'INWarrantyNumber',"
                'strSQL2 &= " sum(convert(int,case when WARRANTY_TYPE = 'OW' then 1 else 0 end)) 'OutWarrantyNumber',"
                'strSQL2 &= " sum(CAST(ISNULL(TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE,0)AS NUMERIC(18,2))) As INWarrantyLabor,"
                'strSQL2 &= " sum(CAST(ISNULL(SONY_NEEDS_TO_PAY,0)AS NUMERIC(18,2))) AS INWarrantyTransport"
                'strSQL2 &= " From SONY_DAILY_DELIVERED Where DELFG = 0 and SHIP_TO_BRANCH_CODE='" & shipCode & "'"
                'If dateTo <> "" Then
                '    If dateFrom <> "" Then
                '        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) <= CONVERT(DATETIME, '" & dateTo & "') "
                '        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) >= CONVERT(DATETIME, '" & dateFrom & "') "
                '    Else
                '        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) <= CONVERT(DATETIME, '" & dateTo & "') "
                '    End If
                'Else
                '    If dateFrom <> "" Then
                '        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) >= CONVERT(DATETIME, '" & dateFrom & "') "
                '    End If
                'End If


                'strSQL2 &= " Group By Convert(DateTime, Convert(varchar(10), COLLECT_DATE, 101)),JOB_ID) sab"
                'strSQL2 &= " On sa.day = sab.COLLECT_DATE "
                'strSQL2 &= " left outer Join"

                'strSQL2 &= " (Select Convert(DateTime, Convert(varchar(10), SDD.COLLECT_DATE, 101)) As COLLECT_DATE,JOB_NUMBER,SUM(CAST(ISNULL(SMR.LABOR_FEE, 0)As NUMERIC(18, 2))) As INWarrantyParts,"
                'strSQL2 &= " SUM(CAST(ISNULL(SMR.ASC_PAY, 0)As NUMERIC(18, 2))) As INWarrantyOthers, SUM(CAST(ISNULL(SMR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, '0') as numeric(18,2)))  as OutWarrantyLabor,"
                'strSQL2 &= " SUM(CAST(ISNULL(SMR.ACCOUNT_PAYABLE_BY_CUSTOMER, '0') as numeric(18,2)) ) as OutWarrantyParts,SUM(CAST(ISNULL(SMR.SONY_NEEDS_TO_PAY, '0') as numeric(18,2)) ) as OutWarrantyTransports,"
                'strSQL2 &= " SUM(CAST(ISNULL(SMR.ASC_PAY, '0') as numeric(18,2)))  as OutWarrantyOthers,SUM(CAST(ISNULL(SMR.PART_FEE, '0') as numeric(18,2)))  AS SAWDiscountLabor,"
                'strSQL2 &= " SUM(CAST(ISNULL(SMR.INSPECTION_FEE, '0') as numeric(18,2)))  AS SAWDiscountParts,SUM(CAST(ISNULL(SMR.HANDLING_FEE, '0') as numeric(18,2)))  as OutWarrantyLabourwSAWDisc,"
                'strSQL2 &= " SUM(CAST(ISNULL(SMR.LABOR_FEE, '0') as numeric(18,2)))  as OutLaborFee,SUM(CAST(ISNULL(SMR.HOME_SERVICE_FEE, '0') as numeric(18,2)))  as HomeServiceFee,SUM(CAST(ISNULL(SMR.LONG_FEE, '0') as numeric(18,2)))  as LongFee,SUM(CAST(ISNULL(SMR.INSTALL_FEE, '0') as numeric(18,2)))  as OutWarrantyPartswSAWDisc,"
                'strSQL2 &= " SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2)) * 0.88))AS IWPARTSCONSUMED,SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2)) + CAST(IsNULL(SMR.INSTALL_FEE, '0') as numeric(18,2))*0.88)) AS TOTALPARTSCONSUMED,"
                'strSQL2 &= " SUM((CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2)) + CAST(IsNULL(SMR.INSTALL_FEE, '0') as numeric(18,2))*0.88) - (CAST(IsNULL(SMR.LABOR_FEE, '0') as numeric(18,2)) * 0.88)) AS PRIMECOSTTOTAL,"

                'strSQL2 &= " sum(("
                'strSQL2 &= " CAST(IsNULL(SMR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE, '0') as numeric(18,2)) + "
                'strSQL2 &= " CAST(IsNULL(SMR.ACCOUNT_PAYABLE_BY_CUSTOMER, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SMR.SONY_NEEDS_TO_PAY, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SMR.ASC_PAY, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SMR.PART_FEE, '0') as numeric(18,2)) +"
                'strSQL2 &= " CAST(IsNULL(SMR.INSPECTION_FEE, '0') as numeric(18,2)) "
                'strSQL2 &= " ))AS OutWarrantyAmount"

                'strSQL2 &= " From SONY_DAILY_DELIVERED SDD full outer Join SONY_MONTHLY_REPAIRSET SMR ON SDD.JOB_ID = SMR.JOB_NUMBER And SDD.SERIAL_NO = SMR.SERIAL_NO Where SMR.DELFG = 0 And SDD.DELFG = 0 And SMR.SHIP_TO_BRANCH_CODE ='" & shipCode & "' "
                'If dateTo <> "" Then
                '    If dateFrom <> "" Then
                '        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) <= CONVERT(DATETIME, '" & dateTo & "') "
                '        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) >= CONVERT(DATETIME, '" & dateFrom & "') "
                '    Else
                '        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) <= CONVERT(DATETIME, '" & dateTo & "') "
                '    End If
                'Else
                '    If dateFrom <> "" Then
                '        strSQL2 &= "AND (CONVERT(DATETIME, Convert(varchar(10), COLLECT_DATE, 101))) >= CONVERT(DATETIME, '" & dateFrom & "') "
                '    End If
                'End If


                'strSQL2 &= " Group BY convert(datetime, Convert(varchar(10), SDD.COLLECT_DATE, 101)),JOB_NUMBER) sac"
                'strSQL2 &= " On sab.JOB_ID = sac.JOB_NUMBER)"
                ''strSQL2 &= " Select *, CAST(GrossProfit/RevenueWithoutTax *100 AS varchar(20)) + '%' as TotalPercentage from PLTrack order by day"
                'strSQL2 &= " Select MAX(Day)AS Day,MAX(Youbi)AS Youbi,MAX(Customervisit)as CustomerVisit ,MAX(CallRegistered) as CallRegistered,"
                'strSQL2 &= " MAX(RepairCompleted) as RepairCompleted,max(GoodsDelivered)as GoodsDelivered,max(PendingCalls)as PendingCalls,max(Total)as Total,collect_date,"
                'strSQL2 &= " sum(INWarrantyNumber)as INWarrantyNumber,sum(OutWarrantyNumber)as OutWarrantyNumber,SUM(INWARRANTYAMOUNT)as INWarrantyAmount, sum(INWarrantyLabor) as INWarrantyLabor,"
                'strSQL2 &= " sum(INWarrantyParts) as INWarrantyParts,sum(INWarrantyTransport)as INWarrantyTransport,sum(INWarrantyothers)as INWarrantyOthers,"
                'strSQL2 &= " sum(OutWarrantyAmount)as OutWarrantyAmount,sum(OutWarrantyLabor)as OutWarrantyLabor,sum(OutWarrantyParts)as OutWarrantyParts,"
                'strSQL2 &= " sum(OutWarrantyTransports)as OutWarrantyTransports,sum(OutWarrantyOthers)as OutWarrantyOthers,sum(SAWDiscountLabor)as SAWDiscountLabor,sum(SAWDiscountParts)as SAWDiscountParts,"
                'strSQL2 &= " sum(OutWarrantyLabourwSAWDisc) as OutWarrantyLabourwSAWDisc,sum(OutLaborFee) as OutLaborFee,sum(HomeServiceFee)as HomeServiceFee,sum(LongFee)as LongFee,"
                'strSQL2 &= " sum(OutWarrantyPartswSAWDisc)as OutWarrantyPartswSAWDisc,max(RevenueWithoutTax)as RevenueWithoutTax,sum(IWPartsConsumed)as IWPartsConsumed,"
                'strSQL2 &= " sum(TotalPartsConsumed)as TotalPartsConsumed,sum(PrimeCostTotal) as PrimeCostTotal,max(GrossProfit)as GrossProfit from PLTrack GROUP BY COLLECT_DATE,day ORDER BY day"


            End If

            dsActivity_report = DBCommon.Get_DS(strSQL2, errFlg)


            If (dsActivity_report Is Nothing) Then
                Call showMsg("There is no SonyActivity_report information.", "")
                Exit Sub
            End If
            If errFlg = 1 Then
                Call showMsg("Failed to get SonyActivity_report information.", "")
                Exit Sub
            End If

            ' Dim DtConvFromSplit As String
            'Dim Po_Confirmation_Table As DataTable = New DataTable()
            'Po_Confirmation_Table = GetDates(Convert.ToInt32(DtConvFromSplit(0)), Convert.ToInt32(DtConvFromSplit(1)))

            'Dim sa As DataTable = New DataTable("sa")
            'sa.Columns.Add("day")
            'sa.Columns.Add("youbi")
            'sa.Columns.Add("Collect_Date")
            'sa.Columns.Add("InwarrantyNumber")
            'sa.Columns.Add("Collect_Date")
            'sa.Columns.Add("InwarrantyNumber")
            'Dim tempDs As DataSet = New DataSet("report")
            'tempDs.Tables.Add(sa)

            ''for loop starting from sep 1 to sep 30

            'Dim orders As DataTable = dsActivity_report.Tables(0)
            'orders.DefaultView.RowFilter = "day = '" & sep1 & "'" Or "collectDate = '" & sep1 & "'" Or "collectDate = '" & sep1 & "'"
            'Dim dr As DataRow = orders.Rows(0)
            ''dr("day")
            'table1.Rows.Add(dr)
            ''if null

            ''end


            'dsActivity_report = tempDs

            'If errFlg <> 1 Then 'If other than Error
            '    If dsActivity_report IsNot Nothing Then
            '        If dsActivity_report.Tables(0).Rows.Count <> 0 Then
            '            Dim dr1 As DataRow
            '            For k = 0 To dsActivity_report.Tables(0).Rows.Count - 1
            '                dr1 = dsActivity_report.Tables(0).Rows(k)

            '                'If dr1("Labor") IsNot DBNull.Value Then
            '                '    activeData(i).Labor = dr1("Labor")
            '                'End If
            '                'If dr1("Parts") IsNot DBNull.Value Then
            '                '    activeData(i).Parts = dr1("Parts")
            '                'End If
            '            Next
            '        End If
            '    End If
            'Else ' If Error is occured, then default assign zero
            'End If


            'Dim csv As String = String.Empty

            'For Each column As DataColumn In dsActivity_report.Columns
            '    'Add the Header row for CSV file.
            '    csv += column.ColumnName + ","c
            'Next

            ''Add new line.
            'csv += vbCr & vbLf

            'For Each row As DataRow In dt.Rows
            '    For Each column As DataColumn In dt.Columns
            '        'Add the Data rows.
            '        csv += row(column.ColumnName).ToString().Replace(",", ";") + ","c
            '    Next

            '    'Add new line.
            '    csv += vbCr & vbLf
            'Next

            ''Download the CSV file.
            'Response.Clear()
            'Response.Buffer = True
            'Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv")
            'Response.Charset = ""
            'Response.ContentType = "application/text"
            'Response.Output.Write(csv)
            'Response.Flush()
            'Response.End()

            'If dsActivity_report IsNot Nothing Then

            '    'VJ - 2020-04-16 SSC parent child Add
            '    Dim shipName As String = "'" & DropListLocation.SelectedItem.Text & "'"

            '    Dim shipdtlParent As DataRow() = _ShipBaseControl.SelectShipBaseDetails().Select("ship_name = " & shipName & " AND IsChildShip = 1 AND DELFG = 0")
            '    Dim shipdtlChild As DataRow() = _ShipBaseControl.SelectShipBaseDetails().Select("Parent_Ship_Name = " & shipName & " AND IsChildShip = 1 AND DELFG = 0")
            '    'Dim shipname As String
            '    If (shipdtlParent.Count() > 0) Then
            '        For Each row As DataRow In shipdtlParent
            '            shipName &= ",'" & row.Item("Parent_Ship_Name").ToString() & "'"
            '            ' DataTable.ImportRow(row)
            '        Next
            '    End If
            '    If (shipdtlChild.Count() > 0) Then
            '        For Each row As DataRow In shipdtlChild
            '            shipName &= ",'" & row.Item("ship_name").ToString() & "'"
            '            'DataTable.ImportRow(row)
            '        Next

            '    End If

            If dsActivity_report.Tables(0).Rows.Count <> 0 Then

                ReDim activeData(dsActivity_report.Tables(0).Rows.Count - 1)
                Dim dr As DataRow
                For i = 0 To dsActivity_report.Tables(0).Rows.Count - 1
                    dr = dsActivity_report.Tables(0).Rows(i)
                    Dim tmpDay As DateTime
                    Dim tmpMon As String
                    Dim tmpYear As String

                    If dr("day") IsNot DBNull.Value Then

                        '項目の日付をセット　例）2018/07/01は、01-Jul-2018　
                        tmpDay = dr("day")

                        'yyyy/mm/dd
                        activeData(i).day2 = tmpDay.ToShortDateString

                        'yyyy/mm/dd
                        activeData(i).day = tmpDay.ToShortDateString

                        'Comment Added on 20200107 
                        'SAW discount calculation
                        ''''''''''''''''''''''''''strSQL4 = "SELECT sum(Invoice_update.LABOR) as Labor,sum(Invoice_update.Parts) as Parts FROM  Invoice_update  "
                        ''''''''''''''''''''''''''strSQL4 &= " where upload_Branch = '" & DropListLocation.SelectedItem.Text.Trim() & "' "
                        ''''''''''''''''''''''''''strSQL4 &= " and Your_Ref_No in (  select  distinct ASC_Claim_No from Wty_Excel where Wty_Excel.DELFG!=1  AND  Wty_Excel.Branch_Code='" & DropListLocation.SelectedItem.Value & "' and  (  (DAY('" & activeData(i).day & "') = 1 and Wty_Excel.Delivery_Date between  LEFT(CONVERT(VARCHAR, DATEADD(D,-3,'" & activeData(i).day & "'), 111), 10) and LEFT(CONVERT(VARCHAR, '" & activeData(i).day & "', 111), 10) ) or (DAY('" & activeData(i).day & "') != 1 and Wty_Excel.Delivery_Date between  LEFT(CONVERT(VARCHAR, '" & activeData(i).day & "', 111), 10) and LEFT(CONVERT(VARCHAR, '" & activeData(i).day & "', 111), 10) )))"
                        Dim DateCur As New System.DateTime(2019, 11, 10, 0, 0, 0)
                        Dim DateEnd1 As New System.DateTime(2019, 11, 10, 0, 0, 0)
                        Dim DateEnd2 As New System.DateTime(2019, 11, 10, 0, 0, 0)
                        Dim DateEnd3 As New System.DateTime(2019, 11, 10, 0, 0, 0)
                        DateCur = activeData(i).day


                        Dim intTotalDays As Integer = 0
                        intTotalDays = System.DateTime.DaysInMonth(DateCur.Year, DateCur.Month)

                        DateEnd1 = DateCur.Year & "/" & DateCur.Month & "/" & intTotalDays
                        DateEnd2 = DateEnd1.AddDays(-1)
                        DateEnd3 = DateEnd1.AddDays(-2)

                        'ByDefault Assign
                        ' activeData(i).Parts = 0
                        ' activeData(i).Labor = 0

                        If DateCur = DateEnd1 Then
                            'No need to check, assign default
                        ElseIf DateCur = DateEnd2 Then
                            'No need to check, assign default
                        ElseIf DateCur = DateEnd3 Then
                            'No need to check, assign default
                        Else




                            'strSQL4 = "SELECT sum(SonyInvoice_update.LABOR) as Labor,sum(SonyInvoice_update.Parts) as Parts FROM  SonyInvoice_update  "
                            'strSQL4 &= " where  "

                            'VJ - 2020-04-16 SSC parent child Comment

                            'If (DropListLocation.SelectedItem.Text = "SSC1") Or (DropListLocation.SelectedItem.Text = "SSC2") Then
                            '    strSQL4 &= "  upload_Branch in ( 'SSC1','SSC2') and "
                            'Else
                            '    strSQL4 &= "  upload_Branch = '" & DropListLocation.SelectedItem.Text.Trim() & "' and "
                            'End If
                            'strSQL4 &= "  upload_Branch in (" & shipName & ") and "
                            'strSQL4 &= "  Your_Ref_No in (  select  distinct ASC_Claim_No from SonyWty_Excel where SonyWty_Excel.DELFG!=1  AND  SonyWty_Excel.Branch_Code='" & DropListLocation.SelectedItem.Value & "') and "
                            'strSQL4 &= "  Your_Ref_No in (  select  distinct ServiceOrder_No from SonySC_DSR where SonySC_DSR.DELFG!=1  AND  ( (DAY('" & activeData(i).day & "') = 1 and SonySC_DSR.Billing_date between  LEFT(CONVERT(VARCHAR, DATEADD(D,-3,'" & activeData(i).day & "'), 111), 10) and LEFT(CONVERT(VARCHAR, '" & activeData(i).day & "', 111), 10) ) or (DAY('" & activeData(i).day & "') != 1 and SonySC_DSR.Billing_date between  LEFT(CONVERT(VARCHAR, '" & activeData(i).day & "', 111), 10) and LEFT(CONVERT(VARCHAR, '" & activeData(i).day & "', 111), 10) )))"
                            'strSQL4 = "Select SDD.COLLECT_DATE AS Day,SDD.WARRANTY_TYPE As WarrantyTypeIW,SDR.LINKMAN AS WarrantyTypeOW,SDD.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE As TotalAmount,SMR.LABOR_FEE as INLaborFee,SDD.SONY_NEEDS_TO_PAY As SonyNeedsToPay,SMR.ASC_PAY AS INASCPay,SDR.TOTAL_AMOUNT_OF_ACCOUNT_PAYABLE As TotalAmount,"
                            'strSQL4 &= " SDR.ACCOUNT_PAYABLE_BY_CUSTOMER as AccountPayableByCustomer,SDR.SONY_NEEDS_TO_PAY As SonyNeedsToPay,SDR.ASC_PAY as OutASCPay,SDR.PART_FEE As PartFee,SDR.INSPECTION_FEE AS InspectionFee,SDR.HANDLING_FEE As HandlingFee,SDR.LABOR_FEE as OutLaborFee,SDR.HOME_SERVICE_FEE As HomeServiceFee,"
                            'strSQL4 &= " SDR.LONG_FEE as LongFee,SDR.INSTALL_FEE as InstallFee FROM"
                            'strSQL4 &= "SONY_DAILY_DELIVERED SDD INNER JOIN SONY_DAILY_REPAIRSETSET_NP SDR ON"
                            'strSQL4 &= "SDD.JOB_ID = SDR.JOB_NUMBER And SDD.SERIAL_NO = SDR.SERIAL_NO"
                            'strSQL4 &= "INNER Join SONY_MONTHLY_REPAIRSET SMR ON"
                            'strSQL4 &= "SDR.JOB_NUMBER = SMR.JOB_NUMBER And SDR.SERIAL_NO = SMR.SERIAL_NO ORDER BY SDD.COLLECT_DATE"

                            'dsActivityReportTmp = DBCommon.Get_DS(strSQL4, errFlg)


                            'If errFlg <> 1 Then 'If other than Error
                            '    If dsActivityReportTmp IsNot Nothing Then
                            '        If dsActivityReportTmp.Tables(0).Rows.Count <> 0 Then
                            '            Dim dr1 As DataRow
                            '            For k = 0 To dsActivityReportTmp.Tables(0).Rows.Count - 1
                            '                dr1 = dsActivityReportTmp.Tables(0).Rows(k)

                            '                'If dr1("Labor") IsNot DBNull.Value Then
                            '                '    activeData(i).Labor = dr1("Labor")
                            '                'End If
                            '                'If dr1("Parts") IsNot DBNull.Value Then
                            '                '    activeData(i).Parts = dr1("Parts")
                            '                'End If
                            '            Next
                            '        End If
                            '    End If
                            'Else ' If Error is occured, then default assign zero
                            'End If
                        End If



                        'dd
                        activeData(i).day = activeData(i).day.Substring(8, 2)

                        'yyyy
                        tmpYear = activeData(i).day2.Substring(0, 4)

                        If setMonName <> "Select the month" Then

                            '月指定は、ドロップリストで指定された月をセット
                            'dd-mon-yyyy
                            ''''''Comment on 20190917
                            '''' activeData(i).day &= "-" & Left(setMonName, 3) & "-" & tmpYear
                            tmpMon = activeData(i).day2.Substring(5, 2)
                            Select Case Convert.ToInt32(tmpMon)
                                Case 1
                                    activeData(i).day &= "-" & "Jan" & "-" & tmpYear
                                Case 2
                                    activeData(i).day &= "-" & "Feb" & "-" & tmpYear
                                Case 3
                                    activeData(i).day &= "-" & "Mar" & "-" & tmpYear
                                Case 4
                                    activeData(i).day &= "-" & "Apr" & "-" & tmpYear
                                Case 5
                                    activeData(i).day &= "-" & "May" & "-" & tmpYear
                                Case 6
                                    activeData(i).day &= "-" & "Jun" & "-" & tmpYear
                                Case 7
                                    activeData(i).day &= "-" & "Jul" & "-" & tmpYear
                                Case 8
                                    activeData(i).day &= "-" & "Aug" & "-" & tmpYear
                                Case 9
                                    activeData(i).day &= "-" & "Sep" & "-" & tmpYear
                                Case 10
                                    activeData(i).day &= "-" & "Oct" & "-" & tmpYear
                                Case 11
                                    activeData(i).day &= "-" & "Nov" & "-" & tmpYear
                                Case 12
                                    activeData(i).day &= "-" & "Dec" & "-" & tmpYear
                            End Select
                        Else

                            '日付指定は、月を３文字列に変換してセット
                            tmpMon = activeData(i).day2.Substring(5, 2)
                            Select Case Convert.ToInt32(tmpMon)
                                Case 1
                                    activeData(i).day &= "-" & "Jan" & "-" & tmpYear
                                Case 2
                                    activeData(i).day &= "-" & "Feb" & "-" & tmpYear
                                Case 3
                                    activeData(i).day &= "-" & "Mar" & "-" & tmpYear
                                Case 4
                                    activeData(i).day &= "-" & "Apr" & "-" & tmpYear
                                Case 5
                                    activeData(i).day &= "-" & "May" & "-" & tmpYear
                                Case 6
                                    activeData(i).day &= "-" & "Jun" & "-" & tmpYear
                                Case 7
                                    activeData(i).day &= "-" & "Jul" & "-" & tmpYear
                                Case 8
                                    activeData(i).day &= "-" & "Aug" & "-" & tmpYear
                                Case 9
                                    activeData(i).day &= "-" & "Sep" & "-" & tmpYear
                                Case 10
                                    activeData(i).day &= "-" & "Oct" & "-" & tmpYear
                                Case 11
                                    activeData(i).day &= "-" & "Nov" & "-" & tmpYear
                                Case 12
                                    activeData(i).day &= "-" & "Dec" & "-" & tmpYear
                            End Select
                        End If

                    End If

                    If dr("youbi") IsNot DBNull.Value Then
                        activeData(i).youbi = dr("youbi")
                    End If


                    'If dr("Service") IsNot DBNull.Value Then
                    '    activeData(i).Service = dr("Service")
                    'End If


                    'If dr("D_I") IsNot DBNull.Value Then
                    '    activeData(i).D_I = dr("D_I")
                    'End If

                    If dr("CustomerVisit") IsNot DBNull.Value Then
                        activeData(i).Customer_Visit_T = dr("CustomerVisit")
                    End If

                    If dr("CallRegistered") IsNot DBNull.Value Then
                        activeData(i).Call_Registerd_T = dr("CallRegistered")
                    End If

                    If dr("RepairCompleted") IsNot DBNull.Value Then
                        activeData(i).Repair_Completed_T = dr("RepairCompleted")
                    End If

                    If dr("GoodsDelivered") IsNot DBNull.Value Then
                        activeData(i).Goods_Delivered_T = dr("GoodsDelivered")
                    End If

                    If dr("PendingCalls") IsNot DBNull.Value Then
                        activeData(i).Pending_Calls_T = dr("PendingCalls")
                    End If

                    If dr("InWarrantyNumber") IsNot DBNull.Value And dr("OutWarrantyNumber") IsNot DBNull.Value Then
                        activeData(i).WarrantyNumber = (dr("InWarrantyNumber") + dr("OutWarrantyNumber"))
                    End If

                    If dr("InWarrantyNumber") IsNot DBNull.Value Then
                        activeData(i).INWarrantyNumber = dr("InWarrantyNumber")
                    End If
                    If dr("OutWarrantyNumber") IsNot DBNull.Value Then
                        activeData(i).OutWarrantyNumber = dr("OutWarrantyNumber")
                    End If
                    If dr("INWarrantyAmount") IsNot DBNull.Value Then
                        activeData(i).InWarrantyAmount = dr("INWarrantyAmount")
                    End If
                    If dr("InWarrantyLabor") IsNot DBNull.Value Then
                        activeData(i).InWarrantyLabor = dr("InWarrantyLabor")
                    End If
                    If dr("InWarrantyparts") IsNot DBNull.Value Then
                        activeData(i).InWarrantyparts = dr("InWarrantyparts")
                    End If
                    If dr("InWarrantyTransport") IsNot DBNull.Value Then
                        activeData(i).InWarrantyTransport = dr("InWarrantyTransport")
                    End If
                    If dr("InWarrantyOthers") IsNot DBNull.Value Then
                        activeData(i).InWarrantyothers = dr("InWarrantyOthers")
                    End If
                    If dr("OutWarrantyAmount") IsNot DBNull.Value Then
                        activeData(i).OutwarrantyAmount = dr("OutWarrantyAmount")
                    End If
                    If dr("OutWarrantyLabor") IsNot DBNull.Value Then
                        activeData(i).OutwarrantyLabor = dr("OutWarrantyLabor")
                    End If
                    If dr("OutWarrantyParts") IsNot DBNull.Value Then
                        activeData(i).Outwarrantyparts = dr("OutWarrantyParts")
                    End If
                    If dr("OutWarrantyTransports") IsNot DBNull.Value Then
                        activeData(i).Outwarrantytransports = dr("OutWarrantyTransports")
                    End If
                    If dr("OutWarrantyOthers") IsNot DBNull.Value Then
                        activeData(i).Outwarrantyothers = dr("OutWarrantyOthers")
                    End If
                    If dr("SawDiscountLabor") IsNot DBNull.Value Then
                        activeData(i).Sawdiscountlabor = dr("SawDiscountLabor")
                    End If
                    If dr("Sawdiscountparts") IsNot DBNull.Value Then
                        activeData(i).Sawdiscountparts = dr("Sawdiscountparts")
                    End If
                    If dr("OutWarrantyLabourwSAWDisc") IsNot DBNull.Value Then
                        activeData(i).OutwarrantyLaborwSAWDisc = dr("OutWarrantyLabourwSAWDisc")
                    End If
                    If dr("OutlaborFee") IsNot DBNull.Value Then
                        activeData(i).OutlaborFee = dr("OutlaborFee")
                    End If
                    If dr("HomeServiceFee") IsNot DBNull.Value Then
                        activeData(i).HomeServiceFee = dr("HomeServiceFee")
                    End If
                    If dr("LongFee") IsNot DBNull.Value Then
                        activeData(i).LongFee = dr("LongFee")
                    End If
                    If dr("OutWarrantyPartswSAWDisc") IsNot DBNull.Value Then
                        activeData(i).OutWarrantyPartswSAWDisc = dr("OutWarrantyPartswSAWDisc")
                    End If
                    If dr("RevenueWithoutTax") IsNot DBNull.Value Then
                        activeData(i).RevenueWithoutTax = dr("RevenueWithoutTax")
                    End If

                    If dr("IWPartsConsumed") IsNot DBNull.Value Then
                        activeData(i).IWPartsConsumed = dr("IWPartsConsumed")
                    End If
                    If dr("TotalPartsConsumed") IsNot DBNull.Value Then
                        activeData(i).TotalPartsConsumed = dr("TotalPartsConsumed")
                    End If
                    If dr("PrimeCostTotal") IsNot DBNull.Value Then
                        activeData(i).PrimeCostTotal = dr("PrimeCostTotal")
                    End If
                    If dr("GrossProfit") IsNot DBNull.Value Then
                        activeData(i).GrossProfit = dr("GrossProfit")
                    End If
                    If dr("GrossProfit") IsNot DBNull.Value And dr("RevenueWithoutTax") IsNot DBNull.Value Then
                        activeData(i).TotalPercentage = FormatPercent(dr("GrossProfit") / dr("RevenueWithoutTax"), 2)
                    End If


                    'If dr("TotalPercentage") IsNot DBNull.Value Then
                    '    activeData(i).TotalPercentage = dr("TotalPercentage")
                    'End If

                Next i

                ' End If

            Else
                Call showMsg("There is no corresponding Sony_Activity_report information.", "")
                Exit Sub
            End If

            '***出力順にセット***
            '■Activity_reportデータ出力
            'Modified by Mohan . 2019 07 09 - Request sent by Shimada san

            '項目名設定

            Dim rowWork1 As String = exportShipName & ","
            Dim rowWork2 As String = " ,"
            'Dim rowWork3 As String = "Service,"
            'Dim rowWork4 As String = "D&I,"
            Dim rowWork3 As String = "Customer Visit,"
            Dim rowWork4 As String = "Call Registered,"
            Dim rowWork5 As String = "Repair Completed,"
            Dim rowWork6 As String = "Goods Delivered,"
            Dim rowWork7 As String = "Pending,"

            Dim rowWork9 As String = "WarrantyNumber,"
            Dim rowWork10 As String = "InWarranty Number,"
            Dim rowWork11 As String = "OutWarranty Number,"
            Dim rowWork12 As String = "InWarranty Amount,"
            Dim rowWork13 As String = "InWarranty Labor,"
            Dim rowWork14 As String = "InWarranty Parts,"
            Dim rowWork15 As String = "InWarranty Transports,"
            Dim rowWork16 As String = "InWarranty Others,"
            Dim rowWork17 As String = "OutWarranty Amount,"
            Dim rowWork18 As String = "OutWarranty Labor,"
            Dim rowWork19 As String = "OutWarranty Parts,"
            Dim rowWork20 As String = "OutWarranty Transports,"
            Dim rowWork21 As String = "OutWarranty Others,"
            Dim rowWork22 As String = "Saw Discount Labor,"
            Dim rowWork23 As String = "Saw Discount parts,"
            Dim rowWork24 As String = "OutWarranty Labor wSAWDisc,"
            Dim rowWork25 As String = "Out Labor Fee,"
            Dim rowWork26 As String = "Home Service Fee,"
            Dim rowWork27 As String = "Long Fee,"
            Dim rowWork28 As String = "OutWarranty Parts wSAWDisc,"
            Dim rowWork29 As String = "Revenue Without Tax,"
            Dim rowWork30 As String = "IW Parts Consumed,"
            Dim rowWork31 As String = "Total Parts Consumed,"
            Dim rowWork32 As String = "Prime Cost Total,"
            Dim rowWork33 As String = "Gross Profit,"
            Dim rowWork34 As String = "Total Percentage,"




            'Dim Total_Service As Integer
            'Dim Total_D_I As Integer
            Dim Total_Customer_Visit As Decimal
            '''Dim Average_Customer_Visit As Integer
            Dim Total_Call_Registerd As Decimal
            '''''Dim Average_Call_Registerd As Integer
            Dim Total_Repair_Completed As Decimal
            ''''Dim Average_Repair_Completed As Integer
            Dim Total_Goods_Delivered As Decimal
            ''''Dim Average_Goods_Delivered As Integer
            Dim Total_Pending_Calls As Decimal
            ''''Dim Average_Pending_Calls As Integer

            Dim Total_WarrantyNumber As Decimal
            Dim Total_InWarrantyNumber As Decimal
            Dim Total_OutWarranty_Number As Decimal
            Dim Total_InWarranty_Amount As Decimal
            Dim Total_InWarranty_Labor As Decimal
            Dim Total_InWarranty_Parts As Decimal
            Dim Total_InWarranty_Transports As Decimal
            Dim Total_InWarranty_Others As Decimal
            Dim Total_OutWarranty_Amount As Decimal
            Dim Total_OutWarranty_Labor As Decimal
            Dim Total_OutWarranty_Parts As Decimal
            Dim Total_OutWarranty_Transports As Decimal
            Dim Total_OutWarranty_Others As Decimal
            Dim Total_Saw_Discount_Labor As Decimal
            Dim Total_Saw_Discount_parts As Decimal
            Dim Total_OutWarranty_Labor_wSAWDisc As Decimal
            Dim Total_Out_Labor_Fee As Decimal
            Dim Total_Home_Service_Fee As Decimal
            Dim Total_Long_Fee As Decimal
            Dim Total_OutWarranty_Parts_wSAWDisc As Decimal
            Dim Total_Revenue_Without_Tax As Decimal
            Dim Total_IW_Parts_Consumed As Decimal
            Dim Total_Parts_Consumed As Decimal
            Dim Total_Prime_Cost_Total As Decimal
            Dim Total_Gross_Profit As Decimal
            Dim Total_Total_Percentage As String

            '日付項目分処理
            For i = 0 To dsActivity_report.Tables(0).Rows.Count - 1
                rowWork1 &= activeData(i).day & ","
                rowWork2 &= activeData(i).youbi & ","
                'rowWork3 &= activeData(i).Service & ","
                'rowWork4 &= activeData(i).D_I & ","
                'Total_Customer_Visit = activeData(i).Customer_Visit_S + activeData(i).Customer_Visit_D
                ' rowWork3 &= activeData(i).(Customer_Visit) & ","
                rowWork3 &= activeData(i).Customer_Visit_T & ","
                rowWork4 &= activeData(i).Call_Registerd_T & ","
                rowWork5 &= activeData(i).Repair_Completed_T & ","
                rowWork6 &= activeData(i).Goods_Delivered_T & ","
                rowWork7 &= activeData(i).Pending_Calls_T & ","

                rowWork9 &= activeData(i).WarrantyNumber & ","
                rowWork10 &= activeData(i).INWarrantyNumber & ","
                rowWork11 &= activeData(i).OutWarrantyNumber & ","
                rowWork12 &= activeData(i).InWarrantyAmount & ","
                rowWork13 &= activeData(i).InWarrantyLabor & ","
                rowWork14 &= activeData(i).InWarrantyparts & ","
                rowWork15 &= activeData(i).InWarrantyTransport & ","
                rowWork16 &= activeData(i).InWarrantyothers & ","
                rowWork17 &= activeData(i).OutwarrantyAmount & ","
                rowWork18 &= activeData(i).OutwarrantyLabor & ","
                rowWork19 &= activeData(i).Outwarrantyparts & ","
                rowWork20 &= activeData(i).Outwarrantytransports & ","
                rowWork21 &= activeData(i).Outwarrantyothers & ","
                rowWork22 &= activeData(i).Sawdiscountlabor & ","
                rowWork23 &= activeData(i).Sawdiscountparts & ","
                rowWork24 &= activeData(i).OutwarrantyLaborwSAWDisc & ","
                rowWork25 &= activeData(i).OutlaborFee & ","
                rowWork26 &= activeData(i).HomeServiceFee & ","
                rowWork27 &= activeData(i).LongFee & ","
                rowWork28 &= activeData(i).OutWarrantyPartswSAWDisc & ","
                rowWork29 &= activeData(i).RevenueWithoutTax & ","
                rowWork30 &= activeData(i).IWPartsConsumed & ","
                rowWork31 &= activeData(i).TotalPartsConsumed & ","
                rowWork32 &= activeData(i).PrimeCostTotal & ","
                If activeData(i).GrossProfit Is Nothing Then
                    rowWork33 &= 0 & ","
                Else
                    rowWork33 &= activeData(i).GrossProfit & ","
                End If
                If activeData(i).TotalPercentage Is Nothing Then
                    rowWork34 &= 0 & ","
                Else
                    rowWork34 &= activeData(i).TotalPercentage & ","
                End If












                'Total_Service = Total_Service + activeData(i).Service
                'Total_D_I = Total_D_I + activeData(i).D_I
                Total_Customer_Visit = Total_Customer_Visit + activeData(i).Customer_Visit_T
                Total_Call_Registerd = Total_Call_Registerd + activeData(i).Call_Registerd_T
                Total_Repair_Completed = Total_Repair_Completed + activeData(i).Repair_Completed_T
                Total_Goods_Delivered = Total_Goods_Delivered + activeData(i).Goods_Delivered_T
                Total_Pending_Calls = Total_Pending_Calls + activeData(i).Pending_Calls_T

                Total_WarrantyNumber = Total_WarrantyNumber + activeData(i).WarrantyNumber
                Total_InWarrantyNumber = Total_InWarrantyNumber + activeData(i).INWarrantyNumber
                Total_OutWarranty_Number = Total_OutWarranty_Number + activeData(i).OutWarrantyNumber


                Total_InWarranty_Amount = Total_InWarranty_Amount + activeData(i).InWarrantyAmount
                Total_InWarranty_Labor = Total_InWarranty_Labor + activeData(i).InWarrantyLabor
                Total_InWarranty_Parts = Total_InWarranty_Parts + activeData(i).InWarrantyparts
                Total_InWarranty_Transports = Total_InWarranty_Transports + activeData(i).InWarrantyTransport
                Total_InWarranty_Others = Total_InWarranty_Others + activeData(i).InWarrantyothers
                Total_OutWarranty_Amount = Total_OutWarranty_Amount + activeData(i).OutwarrantyAmount
                Total_OutWarranty_Labor = Total_OutWarranty_Labor + activeData(i).OutwarrantyLabor
                Total_OutWarranty_Parts = Total_OutWarranty_Parts + activeData(i).Outwarrantyparts
                Total_OutWarranty_Transports = Total_OutWarranty_Transports + activeData(i).Outwarrantytransports
                Total_OutWarranty_Others = Total_OutWarranty_Others + activeData(i).Outwarrantyothers
                Total_Saw_Discount_Labor = Total_Saw_Discount_Labor + activeData(i).Sawdiscountlabor
                Total_Saw_Discount_parts = Total_Saw_Discount_parts + activeData(i).Sawdiscountparts
                Total_OutWarranty_Labor_wSAWDisc = Total_OutWarranty_Labor_wSAWDisc + activeData(i).OutwarrantyLaborwSAWDisc
                Total_Out_Labor_Fee = Total_Out_Labor_Fee + activeData(i).OutlaborFee
                Total_Home_Service_Fee = Total_Home_Service_Fee + activeData(i).HomeServiceFee
                Total_Long_Fee = Total_Long_Fee + activeData(i).LongFee
                Total_OutWarranty_Parts_wSAWDisc = Total_OutWarranty_Parts_wSAWDisc + activeData(i).OutWarrantyPartswSAWDisc
                Total_Revenue_Without_Tax = Total_Revenue_Without_Tax + activeData(i).RevenueWithoutTax
                Total_IW_Parts_Consumed = Total_IW_Parts_Consumed + activeData(i).IWPartsConsumed
                Total_Parts_Consumed = Total_Parts_Consumed + activeData(i).TotalPartsConsumed
                Total_Prime_Cost_Total = Total_Prime_Cost_Total + activeData(i).PrimeCostTotal
                Total_Gross_Profit = Total_Gross_Profit + activeData(i).GrossProfit
                Total_Total_Percentage = activeData(i).TotalPercentage
            Next i

            ''''Average_Customer_Visit = Total_Customer_Visit / dsActivity_report.Tables(0).Rows.Count
            ''''Average_Call_Registerd = Total_Call_Registerd / dsActivity_report.Tables(0).Rows.Count
            ''''Average_Repair_Completed = Total_Repair_Completed / dsActivity_report.Tables(0).Rows.Count
            ''''Average_Goods_Delivered = Total_Goods_Delivered / dsActivity_report.Tables(0).Rows.Count
            ''''Average_Pending_Calls = Total_Pending_Calls / dsActivity_report.Tables(0).Rows.Count

            '項目
            rowWork1 &= "Total, " & exportShipName

            '曜日
            rowWork2 &= " , "
            'rowWork3 &= Total_Service & ", Service"
            'rowWork4 &= Total_D_I & ",D&I"

            rowWork3 &= Total_Customer_Visit & ",Customer Visit"
            rowWork4 &= Total_Call_Registerd & ",Call Registered"
            rowWork5 &= Total_Repair_Completed & ",Repair Completed"
            rowWork6 &= Total_Goods_Delivered & ",Goods Delivered"
            rowWork7 &= Total_Pending_Calls & ",Pending"

            rowWork9 &= Total_WarrantyNumber & ",Warranty Number"
            rowWork10 &= Total_InWarrantyNumber & ",InWarranty Number"
            rowWork11 &= Total_OutWarranty_Number & ",OutWarranty Number"
            rowWork12 &= Total_InWarranty_Amount & ",InWarranty Amount"
            rowWork13 &= Total_InWarranty_Labor & ",InWarranty Labor"
            rowWork14 &= Total_InWarranty_Parts & ",InWarranty Parts"
            rowWork15 &= Total_InWarranty_Transports & ",InWarranty Transports"
            rowWork16 &= Total_InWarranty_Others & ",InWarranty Others"
            rowWork17 &= Total_OutWarranty_Amount & ",Outwarranty Amount"
            rowWork18 &= Total_OutWarranty_Labor & ",Outwarranty Labor"
            rowWork19 &= Total_OutWarranty_Parts & ",Outwarranty Parts"
            rowWork20 &= Total_OutWarranty_Transports & ",Outwarranty Transports"
            rowWork21 &= Total_OutWarranty_Others & ",Outwarranty Others"
            rowWork22 &= Total_Saw_Discount_Labor & ",Saw Discount Labor"
            rowWork23 &= Total_Saw_Discount_parts & ",Saw Discount Parts"
            rowWork24 &= Total_OutWarranty_Labor_wSAWDisc & ",Outwarranty Labor wSaw Disc"
            rowWork25 &= Total_Out_Labor_Fee & ",Out Labor Fee"
            rowWork26 &= Total_Home_Service_Fee & ",Home Service Fee"
            rowWork27 &= Total_Long_Fee & ",Long Fee"
            rowWork28 &= Total_OutWarranty_Parts_wSAWDisc & ",OutWarranty Parts wSAW Disc "
            rowWork29 &= Total_Revenue_Without_Tax & ",Revenue Without tax"
            rowWork30 &= Total_IW_Parts_Consumed & ",IW Parts Consumed"
            rowWork31 &= Total_Parts_Consumed & ",Total Parts Consumed"
            rowWork32 &= Total_Prime_Cost_Total & ",Prime Cost Total"
            rowWork33 &= Total_Gross_Profit & ",Gross Profit"
            rowWork34 &= Total_Total_Percentage & ",Total Percentage"

            'rowWork31 &= comcontrol.Money_Round((GrossProfit / RevenuewithoutTax) * 100, 2) & "%, "


            csvContents1.Add(rowWork1)
            csvContents1.Add(rowWork2)
            csvContents1.Add(rowWork3)
            csvContents1.Add(rowWork4)
            csvContents1.Add(rowWork5)
            csvContents1.Add(rowWork6)
            csvContents1.Add(rowWork7)
            'csvcontents.Add(rowWork8)
            csvContents1.Add(rowWork9)
            csvContents1.Add(rowWork10)
            csvContents1.Add(rowWork11)
            csvContents1.Add(rowWork12)
            csvContents1.Add(rowWork13)
            csvContents1.Add(rowWork14)
            csvContents1.Add(rowWork15)
            csvContents1.Add(rowWork16)
            csvContents1.Add(rowWork17)
            csvContents1.Add(rowWork18)
            csvContents1.Add(rowWork19)
            csvContents1.Add(rowWork20)
            csvContents1.Add(rowWork21)
            csvContents1.Add(rowWork22)
            csvContents1.Add(rowWork23)
            csvContents1.Add(rowWork24)
            csvContents1.Add(rowWork25)
            csvContents1.Add(rowWork26)
            csvContents1.Add(rowWork27)
            csvContents1.Add(rowWork28)
            csvContents1.Add(rowWork29)
            csvContents1.Add(rowWork30)
            csvContents1.Add(rowWork31)
            csvContents1.Add(rowWork32)
            csvContents1.Add(rowWork33)
            csvContents1.Add(rowWork34)


            '■SC_DSR_infoデータ取得
            Dim totalDailyStatementRepartData() As Class_analysis.SONYDAILYSTATEMENTREPART


            For i = 0 To dsActivity_report.Tables(0).Rows.Count - 1





            Next i



            'rowWork11 &= WarrantyNumber & ",Warranty (Number)"
            'rowWork12 &= InWarrantyNumber & ",In Warranty (Number)"
            'rowWork13 &= OutWarrantyNumber & ",Out Warranty (Number)"
            'rowWork14 &= InWarrantyAmount & ",In Warranty (Amount)"
            'rowWork15 &= InWarrantyLabour & ",In Warranty (Labour)"
            'rowWork16 &= InWarrantyParts & ",In Warranty (Parts)"
            'rowWork17 &= InWarrantyTransport & ",In Warranty (Transport)"
            'rowWork18 &= InWarrantyOthers & ",In Warranty (Others)"

            'rowWork19 &= OutWarrantyAmount & ",Out Warranty (Amount)"
            'rowWork20 &= OutWarrantyLabour & ",Out Warranty (Labour)"
            'rowWork21 &= OutWarrantyParts & ",Out Warranty (Parts)"
            'rowWork22 &= OutWarrantyTransport & ",Out Warranty (Transport)"
            'rowWork23 &= OutWarrantyOthers & ",Out Warranty (Others)"
            'rowWork24 &= SAWDiscountLabour & ",SAW Discount (Labour)"
            'rowWork25 &= SAWDiscountParts & ",SAW Discount (Parts)"
            'rowWork26 &= OutWarrantyLabourwSAWDisc & ",Out Warranty (Labour) w/SAW Disc"
            'rowWork27 &= OutWarrantyPartswSAWDisc & ",Out Warranty (Parts) w/SAW Disc"
            'rowWork28 &= RevenuewithoutTax & ",Revenue without Tax"
            'rowWork29 &= IWpartsconsumed & ",IW parts consumed"
            'rowWork30 &= TotalPartsConsumed & ",Total parts consumed"
            'rowWork31 &= PrimeCostTotal & ",Prime Cost Total"
            'rowWork32 &= GrossProfit & ",Gross Profit"

            ''Divide by Zero Exception VJ 20191216
            'If RevenuewithoutTax = 0 Then
            '    rowWork33 &= RevenuewithoutTax & "%, "
            'Else
            '    rowWork33 &= comcontrol.Money_Round((GrossProfit / RevenuewithoutTax) * 100, 2) & "%, "
            'End If
            '//////ram
            'rowWork9 &= WarrantyNumber & ",Warranty (Number)"
            'rowWork10 &= InWarrantyNumber & ",In Warranty (Number)"
            'rowWork11 &= OutWarrantyNumber & ",Out Warranty (Number)"
            'rowWork12 &= InWarrantyAmount & ",In Warranty (Amount)"
            'rowWork13 &= InWarrantyLabour & ",In Warranty (Labour)"
            'rowWork14 &= InWarrantyParts & ",In Warranty (Parts)"
            'rowWork15 &= InWarrantyTransport & ",In Warranty (Transport)"
            'rowWork16 &= InWarrantyOthers & ",In Warranty (Others)"

            'rowWork17 &= OutWarrantyAmount & ",Out Warranty (Amount)"
            'rowWork18 &= OutWarrantyLabour & ",Out Warranty (Labour)"
            'rowWork19 &= OutWarrantyParts & ",Out Warranty (Parts)"
            'rowWork20 &= OutWarrantyTransport & ",Out Warranty (Transport)"
            'rowWork21 &= OutWarrantyOthers & ",Out Warranty (Others)"
            'rowWork22 &= SAWDiscountLabour & ",SAW Discount (Labour)"
            'rowWork23 &= SAWDiscountParts & ",SAW Discount (Parts)"
            'rowWork24 &= OutWarrantyLabourwSAWDisc & ",Out Warranty (Labour) w/SAW Disc"
            'rowWork25 &= OutWarrantyPartswSAWDisc & ",Out Warranty (Parts) w/SAW Disc"
            'rowWork26 &= RevenuewithoutTax & ",Revenue without Tax"
            'rowWork27 &= IWpartsconsumed & ",IW parts consumed"
            'rowWork28 &= TotalPartsConsumed & ",Total parts consumed"
            'rowWork29 &= PrimeCostTotal & ",Prime Cost Total"
            'rowWork30 &= GrossProfit & ",Gross Profit"

            ''Divide by Zero Exception VJ 20191216
            'If RevenuewithoutTax = 0 Then
            '    rowWork31 &= RevenuewithoutTax & "%, "
            'Else
            '    rowWork31 &= comcontrol.Money_Round((GrossProfit / RevenuewithoutTax) * 100, 2) & "%, "
            'End If



            'Dim csvcontents As String


            ' csvContents.Add(rowWork8)
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

            '/////Ram
            'csvContents1.Add(rowWork9)
            'csvContents1.Add(rowWork10)
            'csvContents1.Add(rowWork11)
            'csvContents1.Add(rowWork12)
            'csvContents1.Add(rowWork13)
            'csvContents1.Add(rowWork14)
            'csvContents1.Add(rowWork15)
            'csvContents1.Add(rowWork16)
            'csvContents1.Add(rowWork17)
            'csvContents1.Add(rowWork18)
            'csvContents1.Add(rowWork19)
            'csvContents1.Add(rowWork20)
            'csvContents1.Add(rowWork21)

            'csvContents1.Add(rowWork22)
            'csvContents1.Add(rowWork23)
            'csvContents1.Add(rowWork24)
            'csvContents1.Add(rowWork25)
            'csvContents1.Add(rowWork26)
            'csvContents1.Add(rowWork27)
            'csvContents1.Add(rowWork28)
            'csvContents1.Add(rowWork29)
            'csvContents1.Add(rowWork30)
            'csvContents1.Add(rowWork31)




            'csvContents.Add(rowWork22)
            ''Modified
            'csvContents.Add(rowWork23)
            ''Added Gross Profit
            'csvContents.Add(rowWork24)
            ''Added Gross Profit2
            'csvContents.Add(rowWork25)

        Else
            csvContents1.Add("There is no corresponding PLTrack information.")
        End If

        'ファイル名、パスの設定
        Dim csvFileName As String
        'Dim csvcontents As String
        dateFrom = Replace(dateFrom, "/", "")
        dateTo = Replace(dateTo, "/", "")

        'exportFile名の頭、数値を除く
        'exportFile = Right(exportFile, exportFile.Length - 2)
        exportFile = Right(exportFile, exportFile.Length - 3)

        If setMon = "00" Then
            If dateTo <> "" And dateFrom <> "" Then
                csvFileName = exportFile & "_ " & exportShipName & "_" & dateFrom & "_" & dateTo & ".csv"
            Else
                If dateTo <> "" Then
                    csvFileName = exportFile & "_ " & exportShipName & "_" & dateTo & ".csv"
                End If
                If dateFrom <> "" Then
                    csvFileName = exportFile & "_ " & exportShipName & "_" & dateFrom & ".csv"
                End If
            End If
        Else
            '月指定のとき
            csvFileName = exportFile & "_ " & exportShipName & "_" & dtNow.ToString("yyyy") & "_" & setMon & ".csv"
        End If

        outputPath = clsSet.CsvFilePass & csvFileName

        Using writer As New StreamWriter(outputPath, False, Encoding.Default)
            writer.WriteLine(String.Join(Environment.NewLine, csvcontents1))
        End Using

        'ファイルの内容をバイト配列にすべて読み込む 
        Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)

        'サーバに保存されたCSVファイルを削除
        '※Response.End以降、ファイル削除処理ができないため、ファイルのダウンロードではなく、一旦ファイルの内容を
        '上記、Bufferに保存し、ダウンロード処理を行う。

        If outputPath <> "" Then
            If System.IO.File.Exists(outputPath) = True Then
                System.IO.File.Delete(outputPath)
            End If
        End If

        ' ダウンロード
        Response.ContentType = "application/text/csv"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)
        Response.Flush()
        'Response.Write("<b>File Contents: </b>")
        Response.BinaryWrite(Buffer)
        'Response.WriteFile(outputPath)
        Response.End()

        'Comment on 20200129
        ''''''''''''''''''Catch ex As System.Threading.ThreadAbortException
        ''''''''''''''''''    'Response.End()の呼び出しによりエラーメッセージを出力しないようにする

        ''''''''''''''''''Catch ex As Exception
        ''''''''''''''''''    Call showMsg("CSV output processing failed.", "")
        ''''''''''''''''''End Try

        'ElseIf kindExport = 2 Then

        '    'SalesRegister_OOW
        '    '部品情報を登録して、出力対象情報を取得
        '    Dim dsWtyExcel As New DataSet
        '    Dim wtyData() As Class_analysis.SONYWTY_EXCEL
        ' Call clsSet.SonysetWtyExcelDown(dsWtyExcel, wtyData, userid, userName, shipCode, exportShipName, errFlg, setMon, dateFrom, dateTo)

        '    If dsWtyExcel Is Nothing Then
        '        Call showMsg("There is no output target of SalesRegister_OOW.", "")
        '        Exit Sub
        '    End If

        '    If errFlg = 1 Then
        '        Call showMsg("SalesRegister_OOW information acquisition failed.", "")
        '        Exit Sub
        '    End If

        'Try
        '        'ファイル名、パスの設定
        '        Dim csvFileName As String

        '        dateFrom = Replace(dateFrom, "/", "")
        '        dateTo = Replace(dateTo, "/", "")

        '        'exportFile名の頭、数値を除く
        '        exportFile = Right(exportFile, exportFile.Length - 2)

        '        If setMon = "00" Then
        '            If dateTo <> "" And dateFrom <> "" Then
        '                csvFileName = exportShipName & "_Sales_OOW" & "_" & dateFrom & "_" & dateTo & ".csv"
        '            Else
        '                If dateTo <> "" Then
        '                    csvFileName = exportShipName & "_Sales_OOW" & "_" & dateTo & ".csv"
        '                End If
        '                If dateFrom <> "" Then
        '                    csvFileName = exportShipName & "_Sales_OOW" & "_" & dateFrom & ".csv"
        '                End If
        '            End If
        '        Else
        '            '月指定のとき
        '            csvFileName = exportShipName & "_Sales_OOW" & "_" & dtNow.ToString("yyyy") & "_" & setMon & ".csv"
        '        End If

        '        outputPath = clsSet.CsvFilePass & csvFileName

        '        '項目名設定
        '        Dim csvContents = New List(Of String)(New String() {exportShipName & "-Sales Register Out warranty"})
        '        'Comment on 20190809
        '        'Dim rowWork1 As String = "ASC Code,Branch Code,ASC Claim No,Samsung Claim No,Service Type,Consumer Name,Consumer Addr1,Consumer Addr2,Consumer Telephone,Consumer Fax,Postal Code,Model,Serial No,IMEI No,Defect Type,Condition,Symptom,Defect Code,Repair Code,Defect Desc,Repair Description,Purchase Date,Repair Received Date,Completed Date,Delivery Date,Production Date,Labor Amount Ⅰ,Parts Amount Ⅰ,Tax,Total Invoice Amount Ⅰ,Remark,Tr No,Tr Type,Status,Engineer,Collection Point,Collection Point Name,Location-1,Part-1,Qty-1,Unit Price-1,Doc Num-1,Matrial Serial-1,Location-2,Part-2,Qty-2,Unit Price-2,Doc Num-2,Matrial Serial-2,Location-3,Part-3,Qty-3,Unit Price-3,Doc Num-3,Matrial Serial-3,Location-4,Part-4,Qty-4,Unit Price-4,Doc Num-4,Matrial Serial-4,Location-5,Part-5,Qty-5,Unit Price-5,Doc Num-5,Matrial Serial-5,Location-6,Part-6,Qty-6,Unit Price-6,Doc Num-6,Matrial Serial-6,Location-7,Part-7,Qty-7,Unit Price-7,Doc Num-7,Matrial Serial-7,Location-8,Part-8,Qty-8,Unit Price-8,Doc Num-8,Matrial Serial-8,Location-9,Part-9,Qty-9,Unit Price-9,Doc Num-9,Matrial Serial-9,Location-10,Part-10,Qty-10,Unit Price-10,Doc Num-10,Matrial Serial-10,Location-11,Part-11,Qty-11,Unit Price-11,Doc Num-11,Matrial Serial-11,Location-12,Part-12,Qty-12,Unit Price-12,Doc Num-12,Matrial Serial-12,Location-13,Part-13,Qty-13,Unit Price-13,Doc Num-13,Matrial Serial-13,Location-14,Part-14,Qty-14,Unit Price-14,Doc Num-14,Matrial Serial-14,Location-15,Part-15,Qty-15,Unit Price-15,Doc Num-15,Matrial Serial-15"
        '        Dim rowWork1 As String = "ASC Code,Branch Code,ASC Claim No,Parts_invoice_No,Labor_Invoice_No,Sony Claim No,Service Type,Consumer Name,Consumer Addr1,Consumer Addr2,Consumer Telephone,Consumer Fax,Postal Code,Model,Serial No,IMEI No,Defect Type,Condition,Symptom,Defect Code,Repair Code,Defect Desc,Repair Description,Purchase Date,Repair Received Date,Completed Date,Delivery Date,Production Date,Labor Amount Ⅰ,Parts Amount Ⅰ,Freight, Other, Parts_SGST, Parts_UTGST, Parts_CGST, Parts_IGST, Parts_Cess, SGST, UTGST, CGST, IGST, Cess, Total Invoice Amount Ⅰ,Remark,Tr No,Tr Type,Status,Engineer,Collection Point,Collection Point Name,Location-1,Part-1,Qty-1,Unit Price-1,Doc Num-1,Matrial Serial-1,Location-2,Part-2,Qty-2,Unit Price-2,Doc Num-2,Matrial Serial-2,Location-3,Part-3,Qty-3,Unit Price-3,Doc Num-3,Matrial Serial-3,Location-4,Part-4,Qty-4,Unit Price-4,Doc Num-4,Matrial Serial-4,Location-5,Part-5,Qty-5,Unit Price-5,Doc Num-5,Matrial Serial-5,Location-6,Part-6,Qty-6,Unit Price-6,Doc Num-6,Matrial Serial-6,Location-7,Part-7,Qty-7,Unit Price-7,Doc Num-7,Matrial Serial-7,Location-8,Part-8,Qty-8,Unit Price-8,Doc Num-8,Matrial Serial-8,Location-9,Part-9,Qty-9,Unit Price-9,Doc Num-9,Matrial Serial-9,Location-10,Part-10,Qty-10,Unit Price-10,Doc Num-10,Matrial Serial-10,Location-11,Part-11,Qty-11,Unit Price-11,Doc Num-11,Matrial Serial-11,Location-12,Part-12,Qty-12,Unit Price-12,Doc Num-12,Matrial Serial-12,Location-13,Part-13,Qty-13,Unit Price-13,Doc Num-13,Matrial Serial-13,Location-14,Part-14,Qty-14,Unit Price-14,Doc Num-14,Matrial Serial-14,Location-15,Part-15,Qty-15,Unit Price-15,Doc Num-15,Matrial Serial-15"
        '        csvContents.Add(rowWork1)

        '        For i = 0 To wtyData.Length - 1
        '            csvContents.Add(wtyData(i).ASC_Code & "," & wtyData(i).Branch_Code & "," & wtyData(i).ASC_Claim_No & "," & wtyData(i).Sony_Claim_No & "," & wtyData(i).Service_Type & "," & wtyData(i).Consumer_Name & "," & wtyData(i).Consumer_Addr1 & "," & wtyData(i).Consumer_Addr2 & "," & wtyData(i).Consumer_Telephone & "," & wtyData(i).Consumer_Fax & "," & wtyData(i).Postal_Code & "," & wtyData(i).Model & "," & wtyData(i).Serial_No & "," & wtyData(i).IMEI_No & "," & wtyData(i).Defect_Type & "," & wtyData(i).Condition & "," & wtyData(i).Symptom & "," & wtyData(i).Defect_Code & "," & wtyData(i).Repair_Code & "," & wtyData(i).Defect_Desc & "," & wtyData(i).Repair_Description & "," & wtyData(i).Purchase_Date & "," & wtyData(i).Repair_Received_Date & "," & wtyData(i).Completed_Date & "," & wtyData(i).Delivery_Date & "," & wtyData(i).Production_Date & "," & wtyData(i).Labor_Amount & "," & wtyData(i).Parts_Amount & "," & wtyData(i).Tax & "," & wtyData(i).Total_Invoice_Amount & "," & wtyData(i).Remark & "," & wtyData(i).Tr_No & "," & wtyData(i).Tr_Type & "," & wtyData(i).Status & "," & wtyData(i).Engineer & "," & wtyData(i).Collection_Point & "," & wtyData(i).Collection_Point_Name & "," & wtyData(i).Location_1 & "," & wtyData(i).Part_1 & "," & wtyData(i).Qty_1 & "," & wtyData(i).Unit_Price_1 & "," & wtyData(i).Doc_Num_1 & "," & wtyData(i).Matrial_Serial_1 & "," & wtyData(i).Location_2 & "," & wtyData(i).Part_2 & "," & wtyData(i).Qty_2 & "," & wtyData(i).Unit_Price_2 & "," & wtyData(i).Doc_Num_2 & "," & wtyData(i).Matrial_Serial_2 & "," & wtyData(i).Location_3 & "," & wtyData(i).Part_3 & "," & wtyData(i).Qty_3 & "," & wtyData(i).Unit_Price_3 & "," & wtyData(i).Doc_Num_3 & "," & wtyData(i).Matrial_Serial_3 & "," & wtyData(i).Location_4 & "," & wtyData(i).Part_4 & "," & wtyData(i).Qty_4 & "," & wtyData(i).Unit_Price_4 & "," & wtyData(i).Doc_Num_4 & "," & wtyData(i).Matrial_Serial_4 & "," & wtyData(i).Location_5 & "," & wtyData(i).Part_5 & "," & wtyData(i).Qty_5 & "," & wtyData(i).Unit_Price_5 & "," & wtyData(i).Doc_Num_5 & "," & wtyData(i).Matrial_Serial_5 & "," & wtyData(i).Location_6 & "," & wtyData(i).Part_6 & "," & wtyData(i).Qty_6 & "," & wtyData(i).Unit_Price_6 & "," & wtyData(i).Doc_Num_6 & "," & wtyData(i).Matrial_Serial_6 & "," & wtyData(i).Location_7 & "," & wtyData(i).Part_7 & "," & wtyData(i).Qty_7 & "," & wtyData(i).Unit_Price_7 & "," & wtyData(i).Doc_Num_7 & "," & wtyData(i).Matrial_Serial_7 & "," & wtyData(i).Location_8 & "," & wtyData(i).Part_8 & "," & wtyData(i).Qty_8 & "," & wtyData(i).Unit_Price_8 & "," & wtyData(i).Doc_Num_8 & "," & wtyData(i).Matrial_Serial_8 & "," & wtyData(i).Location_9 & "," & wtyData(i).Part_9 & "," & wtyData(i).Qty_9 & "," & wtyData(i).Unit_Price_9 & "," & wtyData(i).Doc_Num_9 & "," & wtyData(i).Matrial_Serial_9 & "," & wtyData(i).Location_10 & "," & wtyData(i).Part_10 & "," & wtyData(i).Qty_10 & "," & wtyData(i).Unit_Price_10 & "," & wtyData(i).Doc_Num_10 & "," & wtyData(i).Matrial_Serial_10 & "," & wtyData(i).Location_11 & "," & wtyData(i).Part_11 & "," & wtyData(i).Qty_11 & "," & wtyData(i).Unit_Price_11 & "," & wtyData(i).Doc_Num_11 & "," & wtyData(i).Matrial_Serial_11 & "," & wtyData(i).Location_12 & "," & wtyData(i).Part_12 & "," & wtyData(i).Qty_12 & "," & wtyData(i).Unit_Price_12 & "," & wtyData(i).Doc_Num_12 & "," & wtyData(i).Matrial_Serial_12 & "," & wtyData(i).Location_13 & "," & wtyData(i).Part_13 & "," & wtyData(i).Qty_13 & "," & wtyData(i).Unit_Price_13 & "," & wtyData(i).Doc_Num_13 & "," & wtyData(i).Matrial_Serial_13 & "," & wtyData(i).Location_14 & "," & wtyData(i).Part_14 & "," & wtyData(i).Qty_14 & "," & wtyData(i).Unit_Price_14 & "," & wtyData(i).Doc_Num_14 & "," & wtyData(i).Matrial_Serial_14 & "," & wtyData(i).Location_15 & "," & wtyData(i).Part_15 & "," & wtyData(i).Qty_15 & "," & wtyData(i).Unit_Price_15 & "," & wtyData(i).Doc_Num_15 & "," & wtyData(i).Matrial_Serial_15)
        '        Next i

        Using writer As New StreamWriter(outputPath, False, Encoding.Default)
            writer.WriteLine(String.Join(Environment.NewLine, csvContents1))
        End Using

        'ファイルの内容をバイト配列にすべて読み込む 
        'Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)

        'サーバに保存されたCSVファイルを削除
        '※Response.End以降、ファイル削除処理ができないため、ファイルのダウンロードではなく、一旦ファイルの内容を
        '上記、Bufferに保存し、ダウンロード処理を行う。

        If outputPath <> "" Then
            If System.IO.File.Exists(outputPath) = True Then
                System.IO.File.Delete(outputPath)
            End If
        End If

        ' ダウンロード
        Response.ContentType = "application/text/csv"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)
        Response.Flush()
        'Response.Write("<b>File Contents: </b>")
        Response.BinaryWrite(Buffer)
        'Response.WriteFile(outputPath)
        Response.End()



        Using writer As New StreamWriter(outputPath, False, Encoding.Default)
            writer.WriteLine(String.Join(Environment.NewLine, csvContents1))
        End Using

        'ファイルの内容をバイト配列にすべて読み込む 
        ' Dim Buffer As Byte() = System.IO.File.ReadAllBytes(outputPath)

        'サーバに保存されたCSVファイルを削除
        '※Response.End以降、ファイル削除処理ができないため、ファイルのダウンロードではなく、一旦ファイルの内容を
        '上記、Bufferに保存し、ダウンロード処理を行う。

        If outputPath <> "" Then
            If System.IO.File.Exists(outputPath) = True Then
                System.IO.File.Delete(outputPath)
            End If
        End If

        ' ダウンロード
        Response.ContentType = "application/text/csv"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & csvFileName)
        Response.Flush()
        'Response.Write("<b>File Contents: </b>")
        Response.BinaryWrite(Buffer)
        'Response.WriteFile(outputPath)
        Response.End()

        'Catch ex As System.Threading.ThreadAbortException
        '    'Response.End()の呼び出しによりエラーメッセージを出力しないようにする

        'Catch ex As Exception
        '    If outputPath <> "" Then
        '        If System.IO.File.Exists(outputPath) = True Then
        '            System.IO.File.Delete(outputPath)
        '        End If
        '    End If
        '    Call showMsg("CSV output processing failed.", "")
        'End Try

        ' End If
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
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMasterApple(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        codeMaster1.CodeValue = "Select Branch"
        codeMaster1.CodeDispValue = "Select Branch"
        codeMasterList.Insert(0, codeMaster1)
        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        '''''codeMaster2.CodeValue = "ALL"
        '''''codeMaster2.CodeDispValue = "ALL"
        '''''codeMasterList.Insert(1, codeMaster2)

        Me.DropListLocation.DataSource = codeMasterList
        Me.DropListLocation.DataTextField = "CodeDispValue"
        Me.DropListLocation.DataValueField = "CodeValue"
        Me.DropListLocation.DataBind()
    End Sub



End Class