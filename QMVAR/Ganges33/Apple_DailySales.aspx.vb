Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection

Public Class Apple_DailySales
    Inherits System.Web.UI.Page
    Dim clsSet As New Class_money
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

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

            txtFrom.Text = Trim(strYear & "/" & strMon & "/" & strDay)
            txtTo.Text = Trim(txtFrom.Text)

            'Load Daily Sales
            LoadDailySales()

        End If

        '        Select Case
        '(select count(UNQ_NO)  from [AP_PO] where LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') as GeneratedPo,
        '(select count(UNQ_NO) from AP_RCPT_WAIT_LIST where TOKEN_TYPE=1 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') NewToken,
        '(select count(UNQ_NO) from AP_RCPT_WAIT_LIST where TOKEN_TYPE=2 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') PickupToken,
        '(select count(UNQ_NO)  from AP_RCPT_WAIT_LIST  where TOKEN_TYPE in (1,2) And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') TotalToken



        '--ServiceType
        '-- 1 - IW-In Warranty
        '-- 2 - OOW-Out Of Warranty
        '-- 3 - AC+-AppleCareProtectionPlan
        '--Complete
        '-- 0 - Select
        '-- 1 - Complete
        '-- 2 - Reception only
        '--Delivery_Date 


        'Select Case
        '(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And COMP_STATUS=0 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') CustodayIW,
        '(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And COMP_STATUS=0 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') CustodayOOW,
        '(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And COMP_STATUS=0 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') CustodayAC,
        '(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) And COMP_STATUS=0 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') CustodayTotal,
        '(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=1 And LEN(DELIVERY_DATE) > 6 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') DeliveredIW,
        '(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=2 And LEN(DELIVERY_DATE) > 6 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') DeliveredOOW,
        '(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE=3 And LEN(DELIVERY_DATE) > 6 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') DeliveredAC,
        '(select count(UNQ_NO) from [AP_QMV_ORD] where SERVICE_TYPE in (1,2,3) And LEN(DELIVERY_DATE) > 6 And LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) ='2021/07/08') DeliveredTotal






    End Sub

    ''Protected Sub btnImgExcel_Click(sender As Object, e As EventArgs) Handles btnImgExcel.Click
    ''    Response.ContentType = "application/vnd.ms-excel"
    ''    Response.AddHeader("Content-Disposition", "attachment;filename=" & ExportFileName)
    ''    Response.AddHeader("Pragma", "no-cache")
    ''    Response.AddHeader("Cache-Control", "no-cache")
    ''    Dim myData As Byte() = System.Text.Encoding.UTF8.GetBytes(result)
    ''    Response.BinaryWrite(myData)
    ''    Response.Flush()
    ''    Response.SuppressContent = True
    ''    HttpContext.Current.ApplicationInstance.CompleteRequest()
    ''End Sub




    Sub LoadDailySales()
        Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
        Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
        Dim shipCode As String = Session("ship_code")
        If shipCode = "" Then
            Response.Redirect("Login.aspx")
        End If
        _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode


        _AppleQmvOrdModel.DateFrom = txtFrom.Text
        _AppleQmvOrdModel.DateTo = txtTo.Text

        Dim tmpInt As Integer = 0


        'Comment on 20211231
        'Dim dtAppleQmv As DataTable = _AppleQmvOrdControl.SelectSummary(_AppleQmvOrdModel)
        Dim dtAppleQmv As DataTable = LoadDailySalesData()
        If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then


        Else



            If Not IsDBNull(dtAppleQmv.Rows(0)("NewToken")) Then
                lblNewToken.Text = dtAppleQmv.Rows(0)("NewToken")
            Else
                lblNewToken.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PickupToken")) Then
                lblPickupToken.Text = dtAppleQmv.Rows(0)("PickupToken")
            Else
                lblPickupToken.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("TotalToken")) Then
                lblTotalToken.Text = dtAppleQmv.Rows(0)("TotalToken")
            Else
                lblTotalToken.Text = 0
            End If




            If Not IsDBNull(dtAppleQmv.Rows(0)("GeneratedPo")) Then
                tmpInt = dtAppleQmv.Rows(0)("GeneratedPo")
                'Need to compate with Token machine and assign maximum one
                'Take the larger one compared to Token Machine
                If tmpInt > Val(lblTotalToken.Text) Then
                    lblGeneratePo.Text = tmpInt
                Else
                    lblGeneratePo.Text = lblTotalToken.Text
                End If
            Else
                lblGeneratePo.Text = lblTotalToken.Text 'If no Po Generated, then Token numbers higher
            End If

            'Under Process
            If Not IsDBNull(dtAppleQmv.Rows(0)("UnderRepairIW")) Then
                lblUnderRepairIW.Text = dtAppleQmv.Rows(0)("UnderRepairIW")
            Else
                lblUnderRepairIW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("UnderRepairOOW")) Then
                lblUnderRepairOOW.Text = dtAppleQmv.Rows(0)("UnderRepairOOW")
            Else
                lblUnderRepairOOW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("UnderRepairAC")) Then
                lblUnderRepairAC.Text = dtAppleQmv.Rows(0)("UnderRepairAC")
            Else
                lblUnderRepairAC.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("UnderRepairTotal")) Then
                lblUnderRepairTotal.Text = dtAppleQmv.Rows(0)("UnderRepairTotal")
            Else
                lblUnderRepairTotal.Text = 0
            End If


            'Custody
            If Not IsDBNull(dtAppleQmv.Rows(0)("CustodayIW")) Then
                lblCustodyIW.Text = dtAppleQmv.Rows(0)("CustodayIW")
            Else
                lblCustodyIW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("CustodayOOW")) Then
                lblCustodyOOW.Text = dtAppleQmv.Rows(0)("CustodayOOW")
            Else
                lblCustodyOOW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("CustodayAC")) Then
                lblCustodyAC.Text = dtAppleQmv.Rows(0)("CustodayAC")
            Else
                lblCustodyAC.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("CustodayTotal")) Then
                lblCustodyTotal.Text = dtAppleQmv.Rows(0)("CustodayTotal")
            Else
                lblCustodyTotal.Text = 0
            End If

            'GSX Completed
            If Not IsDBNull(dtAppleQmv.Rows(0)("GsxIW")) Then
                lblGSXCompIW.Text = dtAppleQmv.Rows(0)("GsxIW")
            Else
                lblGSXCompIW.Text = 0
            End If
            If Not IsDBNull(dtAppleQmv.Rows(0)("GsxOOW")) Then
                lblGSXCompOOW.Text = dtAppleQmv.Rows(0)("GsxOOW")
            Else
                lblGSXCompOOW.Text = 0
            End If
            If Not IsDBNull(dtAppleQmv.Rows(0)("GsxAC")) Then
                lblGSXCompAC.Text = dtAppleQmv.Rows(0)("GsxAC")
            Else
                lblGSXCompAC.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("GsxTotal")) Then
                lblGSXCompTotal.Text = dtAppleQmv.Rows(0)("GsxTotal")
            Else
                lblGSXCompTotal.Text = 0
            End If

            'Delivered
            If Not IsDBNull(dtAppleQmv.Rows(0)("DeliveredIW")) Then
                lblDeliveredIW.Text = dtAppleQmv.Rows(0)("DeliveredIW")
            Else
                lblDeliveredIW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("DeliveredOOW")) Then
                lblDeliveredOOW.Text = dtAppleQmv.Rows(0)("DeliveredOOW")
            Else
                lblDeliveredOOW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("DeliveredAC")) Then
                lblDeliveredAC.Text = dtAppleQmv.Rows(0)("DeliveredAC")
            Else
                lblDeliveredAC.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("DeliveredTotal")) Then
                lblDeliveredTotal.Text = dtAppleQmv.Rows(0)("DeliveredTotal")
            Else
                lblDeliveredTotal.Text = 0
            End If


            'Sales
            If Not IsDBNull(dtAppleQmv.Rows(0)("SalesCount")) Then
                lblSalesCount.Text = dtAppleQmv.Rows(0)("SalesCount")
            Else
                lblSalesCount.Text = 0
            End If

            'Net Count
            lblNetCount.Text = Val(lblUnderRepairTotal.Text) + Val(lblCustodyTotal.Text) + Val(lblGSXCompTotal.Text) + Val(lblDeliveredTotal.Text) + Val(lblSalesCount.Text)


            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourIW")) Then
                lblLabourIW.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourIW"))
            Else
                lblLabourIW.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsIW")) Then
                lblPartsIW.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsIW"))
            Else
                lblPartsIW.Text = "0.00"
            End If
            lblTotalIW.Text = clsSet.setINR(Val(lblLabourIW.Text) + Val(lblPartsIW.Text))
            lblNetIW.Text = lblTotalIW.Text

            'lblLabourIW.Text = "0.00"
            'lblPartsIW.Text = "0.00"
            'lblTotalIW.Text = "0.00"
            'lblNetIW.Text = "0.00"


            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourOOWCash")) Then
                lblLabourOOWCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourOOWCash"))
            Else
                lblLabourOOWCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourOOWCard")) Then
                lblLabourOOWCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourOOWCard"))
            Else
                lblLabourOOWCard.Text = "0.00"
            End If


            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsOOWCash")) Then
                lblPartsOOWCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsOOWCash"))
            Else
                lblPartsOOWCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsOOWCard")) Then
                lblPartsOOWCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsOOWCard"))
            Else
                lblPartsOOWCard.Text = "0.00"
            End If


            lblTotalOOWCash.Text = clsSet.setINR(Val(lblLabourOOWCash.Text) + Val(lblPartsOOWCash.Text))
            lblTotalOOWCard.Text = clsSet.setINR(Val(lblLabourOOWCard.Text) + Val(lblPartsOOWCard.Text))
            lblNetOOW.Text = clsSet.setINR(Val(lblTotalOOWCash.Text) + Val(lblTotalOOWCard.Text))


            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourACCash")) Then
                lblLabourACCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourACCash"))
            Else
                lblLabourACCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourACCard")) Then
                lblLabourACCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourACCard"))
            Else
                lblLabourACCard.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsACCash")) Then
                lblPartsACCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsACCash"))
            Else
                lblPartsACCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsACCard")) Then
                lblPartsACCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsACCard"))
            Else
                lblPartsACCard.Text = "0.00"
            End If

            lblTotalACCash.Text = clsSet.setINR(Val(lblLabourACCash.Text) + Val(lblPartsACCash.Text))
            lblTotalACCard.Text = clsSet.setINR(Val(lblLabourACCard.Text) + Val(lblPartsACCard.Text))
            lblNetAC.Text = clsSet.setINR(Val(lblTotalACCash.Text) + Val(lblTotalACCard.Text))



            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourSalesCash")) Then
                lblLabourSalesCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourSalesCash"))
            Else
                lblLabourSalesCash.Text = "0.00"
            End If
            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourSalesCard")) Then
                lblLabourSalesCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourSalesCard"))
            Else
                lblLabourSalesCard.Text = "0.00"
            End If


            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsASalesCash")) Then
                lblPartsSalesCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsASalesCash"))
            Else
                lblPartsSalesCash.Text = "0.00"
            End If
            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsSalesCard")) Then
                lblPartsSalesCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsSalesCard"))
            Else
                lblPartsSalesCard.Text = "0.00"
            End If

            lblTotalSalesCash.Text = clsSet.setINR(Val(lblLabourSalesCash.Text) + Val(lblPartsSalesCash.Text))
            lblTotalSalesCard.Text = clsSet.setINR(Val(lblLabourSalesCard.Text) + Val(lblPartsSalesCard.Text))
            lblNetSales.Text = clsSet.setINR(Val(lblTotalSalesCash.Text) + Val(lblTotalSalesCard.Text))




            'If Not IsDBNull(dtAppleQmv.Rows(0)("LabourTotalCash")) Then
            '    lblLabourTotalCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourTotalCash"))
            'Else
            '    lblLabourTotalCash.Text = "0.00"
            'End If

            'If Not IsDBNull(dtAppleQmv.Rows(0)("LabourTotalCard")) Then
            '    lblLabourTotalCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourTotalCard"))
            'Else
            '    lblLabourTotalCard.Text = "0.00"
            'End If

            lblLabourTotalCash.Text = clsSet.setINR(Val(lblLabourOOWCash.Text) + Val(lblLabourACCash.Text) + Val(lblLabourSalesCash.Text))
            lblLabourTotalCard.Text = clsSet.setINR(Val(lblLabourOOWCard.Text) + Val(lblLabourACCard.Text) + Val(lblLabourSalesCard.Text))


            'If Not IsDBNull(dtAppleQmv.Rows(0)("PartsTotalCash")) Then
            '    lblPartsTotalCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsTotalCash"))
            'Else
            '    lblPartsTotalCash.Text = "0.00"
            'End If

            'If Not IsDBNull(dtAppleQmv.Rows(0)("PartsTotalCard")) Then
            '    lblPartsTotalCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsTotalCard"))
            'Else
            '    lblPartsTotalCard.Text = "0.00"
            'End If

            lblPartsTotalCash.Text = clsSet.setINR(Val(lblPartsOOWCash.Text) + Val(lblPartsACCash.Text) + Val(lblPartsSalesCash.Text))
            lblPartsTotalCard.Text = clsSet.setINR(Val(lblPartsOOWCard.Text) + Val(lblPartsACCard.Text) + Val(lblPartsSalesCard.Text))



            lblTotalTotalCash.Text = clsSet.setINR(Val(lblTotalOOWCash.Text) + Val(lblTotalACCash.Text) + Val(lblTotalSalesCash.Text))
            lblTotalTotalCard.Text = clsSet.setINR(Val(lblTotalOOWCard.Text) + Val(lblTotalACCard.Text) + Val(lblTotalSalesCard.Text))
            lblNetTotal.Text = clsSet.setINR(Val(lblTotalTotalCash.Text) + Val(lblTotalTotalCard.Text))


            lblLabourNet.Text = clsSet.setINR(Val(lblLabourTotalCash.Text) + Val(lblLabourTotalCard.Text) + Val(lblLabourIW.Text))
            lblPartsNet.Text = clsSet.setINR(Val(lblPartsTotalCash.Text) + Val(lblPartsTotalCard.Text) + Val(lblPartsIW.Text))

            lblTotalTotal.Text = clsSet.setINR(Val(lblLabourNet.Text) + Val(lblPartsNet.Text))

            lblNet.Text = clsSet.setINR(Val(lblTotalTotal.Text))


        End If
    End Sub


    Public Shared Function ToDataTable(Of T)(ByVal items As List(Of T)) As DataTable
        Dim dataTable As DataTable = New DataTable(GetType(T).Name)
        Dim Props As PropertyInfo() = GetType(T).GetProperties(BindingFlags.[Public] Or BindingFlags.Instance)

        For Each prop As PropertyInfo In Props
            Dim type = (If(prop.PropertyType.IsGenericType AndAlso prop.PropertyType.GetGenericTypeDefinition() = GetType(Nullable(Of)), Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
            dataTable.Columns.Add(prop.Name, type)
        Next

        For Each item As T In items
            Dim values = New Object(Props.Length - 1) {}

            For i As Integer = 0 To Props.Length - 1
                values(i) = Props(i).GetValue(item, Nothing)
            Next

            dataTable.Rows.Add(values)
        Next

        Return dataTable
    End Function


    Public Function LoadDailySalesData() As DataTable
        Dim _AppleSalesModel As AppleSalesModel = New AppleSalesModel()
        _AppleSalesModel.GeneratedPo = 0
        _AppleSalesModel.NewToken = 0
        _AppleSalesModel.PickupToken = 0
        _AppleSalesModel.TotalToken = 0
        _AppleSalesModel.UnderRepairIW = 0
        _AppleSalesModel.UnderRepairOOW = 0
        _AppleSalesModel.UnderRepairAC = 0
        _AppleSalesModel.UnderRepairTotal = 0
        _AppleSalesModel.CustodayIW = 0
        _AppleSalesModel.CustodayOOW = 0
        _AppleSalesModel.CustodayAC = 0
        _AppleSalesModel.CustodayTotal = 0
        _AppleSalesModel.GsxIW = 0
        _AppleSalesModel.GsxOOW = 0
        _AppleSalesModel.GsxAC = 0
        _AppleSalesModel.GsxTotal = 0
        _AppleSalesModel.DeliveredIW = 0
        _AppleSalesModel.DeliveredOOW = 0
        _AppleSalesModel.DeliveredAC = 0
        _AppleSalesModel.DeliveredTotal = 0
        _AppleSalesModel.SalesCount = 0
        _AppleSalesModel.LabourIW = 0
        _AppleSalesModel.LabourIWCash = 0
        _AppleSalesModel.LabourIWCard = 0
        _AppleSalesModel.LabourOOWCash = 0
        _AppleSalesModel.LabourOOWCard = 0
        _AppleSalesModel.LabourACCash = 0
        _AppleSalesModel.LabourACCard = 0
        _AppleSalesModel.LabourSalesCash = 0
        _AppleSalesModel.LabourSalesCard = 0
        _AppleSalesModel.LabourTotalCash = 0
        _AppleSalesModel.LabourTotalCard = 0
        _AppleSalesModel.PartsIW = 0
        _AppleSalesModel.PartsIWCash = 0
        _AppleSalesModel.PartsIWCard = 0
        _AppleSalesModel.PartsOOWCash = 0
        _AppleSalesModel.PartsOOWCard = 0
        _AppleSalesModel.PartsACCash = 0
        _AppleSalesModel.PartsACCard = 0
        _AppleSalesModel.PartsASalesCash = 0
        _AppleSalesModel.PartsSalesCard = 0
        _AppleSalesModel.PartsTotalCash = 0
        _AppleSalesModel.PartsTotalCard = 0


        Dim GeneratedPo As Integer = 0
        Dim NewToken As Integer = 0
        Dim PickupToken As Integer = 0
        Dim TotalToken As Integer = 0
        Dim UnderRepairIW As Integer = 0
        Dim UnderRepairOOW As Integer = 0
        Dim UnderRepairAC As Integer = 0
        Dim UnderRepairTotal As Integer = 0
        Dim CustodayIW As Integer = 0
        Dim CustodayOOW As Integer = 0
        Dim CustodayAC As Integer = 0
        Dim CustodayTotal As Integer = 0
        Dim GsxIW As Integer = 0
        Dim GsxOOW As Integer = 0
        Dim GsxAC As Integer = 0
        Dim GsxTotal As Integer = 0
        Dim DeliveredIW As Integer = 0
        Dim DeliveredOOW As Integer = 0
        Dim DeliveredAC As Integer = 0
        Dim DeliveredTotal As Integer = 0
        Dim SalesCount As Integer = 0

        Dim LabourIW As Decimal = 0.00

        Dim LabourIWCash As Decimal = 0.00
        Dim LabourIWCard As Decimal = 0.00
        Dim LabourOOWCash As Decimal = 0.00
        Dim LabourOOWCard As Decimal = 0.00
        Dim LabourACCash As Decimal = 0.00

        Dim LabourACCard As Decimal = 0.00
        Dim LabourSalesCash As Decimal = 0.00
        Dim LabourSalesCard As Decimal = 0.00
        Dim LabourTotalCash As Decimal = 0.00
        Dim LabourTotalCard As Decimal = 0.00
        Dim PartsIW As Decimal = 0.00
        Dim PartsIWCash As Decimal = 0.00
        Dim PartsIWCard As Decimal = 0.00
        Dim PartsOOWCash As Decimal = 0.00
        Dim PartsOOWCard As Decimal = 0.00
        Dim PartsACCash As Decimal = 0.00
        Dim PartsACCard As Decimal = 0.00
        Dim PartsASalesCash As Decimal = 0.00
        Dim PartsSalesCard As Decimal = 0.00
        Dim PartsTotalCash As Decimal = 0.00
        Dim PartsTotalCard As Decimal = 0.00

        Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()

        Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
            Dim shipCode As String = Session("ship_code")

            _AppleQmvOrdModel.UserId = "" 'userid
            _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode '"1019756" 'DropListLocation.SelectedItem.Value
            _AppleQmvOrdModel.SHIP_TO_BRANCH = "ASP1" '"SID1" 'DropListLocation.SelectedItem.Text
            _AppleQmvOrdModel.DateFrom = txtFrom.Text 'DropDownYear.SelectedValue & "/" & DropDownMonth.SelectedValue & "/" & "01"
            _AppleQmvOrdModel.DateTo = txtTo.Text 'CommonControl.GetLastDayOfMonth(DropDownMonth.SelectedValue, DropDownYear.SelectedValue)

            GeneratedPo = _AppleQmvOrdControl.SelectPoGenerated(_AppleQmvOrdModel)


            Dim dtApRcptWaitLst As DataTable = _AppleQmvOrdControl.SelectPLRcptWaitLst(_AppleQmvOrdModel)
            If (dtApRcptWaitLst Is Nothing) Or (dtApRcptWaitLst.Rows.Count = 0) Then
                NewToken = 0
                PickupToken = 0
                TotalToken = 0
            Else
                For DsetRow = 0 To dtApRcptWaitLst.Rows.Count - 1
                    If dtApRcptWaitLst.Rows(DsetRow).Item("TOKEN_TYPE") IsNot DBNull.Value Then
                        Select Case UCase(dtApRcptWaitLst.Rows(DsetRow).Item("TOKEN_TYPE").ToString())
                            Case "1" 'New Token
                                NewToken = NewToken + 1

                            Case "2" 'Pickup Tokeb
                                PickupToken = PickupToken + 1
                        End Select
                    End If
                Next
                TotalToken = NewToken + PickupToken
            End If


            Dim dtApQmvOrd As DataTable = _AppleQmvOrdControl.SelectPLOrder(_AppleQmvOrdModel)
        If (dtApQmvOrd Is Nothing) Or (dtApQmvOrd.Rows.Count = 0) Then
            UnderRepairIW = 0
            UnderRepairOOW = 0
            UnderRepairAC = 0
            UnderRepairTotal = 0
            CustodayIW = 0
            CustodayOOW = 0
            CustodayAC = 0
            CustodayTotal = 0
            GsxIW = 0
            GsxOOW = 0
            GsxAC = 0
            GsxTotal = 0
            DeliveredIW = 0
            DeliveredOOW = 0
            DeliveredAC = 0
            DeliveredTotal = 0
            SalesCount = 0

            LabourIW = 0.00

            LabourIWCash = 0.00
            LabourIWCard = 0.00
            LabourOOWCash = 0.00
            LabourOOWCard = 0.00
            LabourACCash = 0.00

            LabourACCard = 0.00
            LabourSalesCash = 0.00
            LabourSalesCard = 0.00
            LabourTotalCash = 0.00
            LabourTotalCard = 0.00
            PartsIW = 0.00
            PartsIWCash = 0.00
            PartsIWCard = 0.00
            PartsOOWCash = 0.00
            PartsOOWCard = 0.00
            PartsACCash = 0.00
            PartsACCard = 0.00
            PartsASalesCash = 0.00
            PartsSalesCard = 0.00
            PartsTotalCash = 0.00
            PartsTotalCard = 0.00

        Else

            For DsetRow = 0 To dtApQmvOrd.Rows.Count - 1
                If dtApQmvOrd.Rows(DsetRow).Item("SERVICE_TYPE") IsNot DBNull.Value Then
                    Select Case UCase(dtApQmvOrd.Rows(DsetRow).Item("SERVICE_TYPE").ToString())
                        Case "1" 'IW
                            If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") IsNot DBNull.Value Then
                                If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") = "0" Then
                                    UnderRepairIW = UnderRepairIW + 1
                                    If Not ((dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_1") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_2") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_3") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_4") Is DBNull.Value)) Then
                                        CustodayIW = CustodayIW + 1
                                    End If
                                End If

                                If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") = "1" Then
                                    GsxIW = GsxIW + 1
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("DELIVERY_DATE") IsNot DBNull.Value Then
                                    If Len(dtApQmvOrd.Rows(DsetRow).Item("DELIVERY_DATE")) >= 6 Then
                                        DeliveredIW = DeliveredIW + 1
                                    End If
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("LABOR_COST") IsNot DBNull.Value Then  'IW
                                    LabourIW = LabourIW + dtApQmvOrd.Rows(DsetRow).Item("LABOR_COST")
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                    If Len(dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION")) = "2" Then 'Cash
                                        If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                            LabourIWCash = LabourIWCash + dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES")
                                        End If
                                    End If
                                    If (Len(dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION")) = "1") Or (Len(dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION")) = "4") Then 'Card / Bank Transfer
                                        If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                            LabourIWCard = LabourIWCard + dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES")
                                        End If
                                    End If
                                End If

                                'PartsIW
                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_1") IsNot DBNull.Value Then  'IW
                                    PartsIW = PartsIW + dtApQmvOrd.Rows(DsetRow).Item("PART_COST_1")
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_2") IsNot DBNull.Value Then  'IW
                                    PartsIW = PartsIW + dtApQmvOrd.Rows(DsetRow).Item("PART_COST_2")
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_3") IsNot DBNull.Value Then  'IW
                                    PartsIW = PartsIW + dtApQmvOrd.Rows(DsetRow).Item("PART_COST_3")
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("PART_COST_4") IsNot DBNull.Value Then  'IW
                                    PartsIW = PartsIW + dtApQmvOrd.Rows(DsetRow).Item("PART_COST_4")
                                End If
                                If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then  'IW
                                    PartsIW = PartsIW + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                End If
                                'PartsIWCash
                                If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                    If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "2" Then 'Cash
                                        If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                            PartsIWCash = PartsIWCash + dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT")
                                        End If
                                        If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                            PartsIWCash = PartsIWCash + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                        End If
                                    End If
                                End If

                                'PartsIWCard
                                If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                    If (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "1") Or (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "4") Then 'Card
                                        If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                            PartsIWCard = PartsIWCard + dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT")
                                        End If
                                        If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                            PartsIWCard = PartsIWCard + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                        End If
                                    End If
                                End If
                            End If


                        Case "2" 'OW
                            If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") IsNot DBNull.Value Then
                                If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") = "0" Then
                                    UnderRepairOOW = UnderRepairOOW + 1
                                    If Not ((dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_1") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_2") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_3") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_4") Is DBNull.Value)) Then
                                        CustodayOOW = CustodayOOW + 1
                                    End If
                                End If
                            End If

                            If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") = "1" Then
                                GsxOOW = GsxOOW + 1
                            End If
                            If dtApQmvOrd.Rows(DsetRow).Item("DELIVERY_DATE") IsNot DBNull.Value Then
                                If Len(dtApQmvOrd.Rows(DsetRow).Item("DELIVERY_DATE")) >= 6 Then
                                    DeliveredOOW = DeliveredOOW + 1
                                End If
                            End If
                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "2" Then 'Cash
                                    If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                        LabourOOWCash = LabourOOWCash + dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES")
                                    End If
                                End If
                                If (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "1") Or (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "4") Then 'Card / Bank Transfer
                                    If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                        LabourOOWCard = LabourOOWCard + dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES")
                                    End If
                                End If
                            End If

                            'PartsOOWCash
                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "2" Then 'Cash
                                    If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                        PartsOOWCash = PartsOOWCash + dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT")
                                    End If
                                    If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                        PartsOOWCash = PartsOOWCash + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                    End If
                                End If
                            End If

                            'PartsOOWCard
                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "1") Or (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "4") Then 'Card
                                    If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                        PartsOOWCard = PartsOOWCard + dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT")
                                    End If
                                    If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                        PartsOOWCard = PartsOOWCard + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                    End If
                                End If
                            End If


                        Case "3" 'AC+
                            If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") IsNot DBNull.Value Then
                                If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") = "0" Then
                                    UnderRepairAC = UnderRepairAC + 1
                                    If Not ((dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_1") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_2") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_3") Is DBNull.Value) And (dtApQmvOrd.Rows(DsetRow).Item("PART_QTY_4") Is DBNull.Value)) Then
                                        CustodayAC = CustodayAC + 1
                                    End If
                                End If
                            End If

                            If dtApQmvOrd.Rows(DsetRow).Item("COMP_STATUS") = "1" Then
                                GsxAC = GsxAC + 1
                            End If
                            If dtApQmvOrd.Rows(DsetRow).Item("DELIVERY_DATE") IsNot DBNull.Value Then
                                If Len(dtApQmvOrd.Rows(DsetRow).Item("DELIVERY_DATE")) >= 6 Then
                                    DeliveredAC = DeliveredAC + 1
                                End If
                            End If
                            If dtApQmvOrd.Rows(DsetRow).Item("LABOR_COST") IsNot DBNull.Value Then  'IW
                                LabourACCash = LabourACCash + dtApQmvOrd.Rows(DsetRow).Item("LABOR_COST")
                            End If
                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "1") Or (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "4") Then 'Card / Bank Transfer
                                    If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                        LabourACCard = LabourACCard + dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES")
                                    End If
                                End If
                            End If
                            'PartsACCash
                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "2" Then 'Cash
                                    If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                        PartsACCash = PartsACCash + dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT")
                                    End If
                                    If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                        PartsACCash = PartsACCash + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                    End If
                                End If
                            End If

                            'PartsACCard
                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "1") Or (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "4") Then 'Card
                                    If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                        PartsACCard = PartsACCard + dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT")
                                    End If
                                    If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                        PartsACCard = PartsACCard + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                    End If
                                End If
                            End If


                        Case "4" 'Sales
                            SalesCount = SalesCount + 1

                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If Len(dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION")) = "2" Then 'Cash
                                    If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                        LabourSalesCash = LabourSalesCash + dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES")
                                    End If
                                End If
                                If (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "1") Or (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "4") Then 'Card / Bank Transfer
                                    If dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES") IsNot DBNull.Value Then
                                        LabourSalesCard = LabourSalesCard + dtApQmvOrd.Rows(DsetRow).Item("LABOR_SALES")
                                    End If
                                End If
                            End If
                            'PartsASalesCash
                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "2" Then 'Cash
                                    If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                        PartsASalesCash = PartsASalesCash + dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT")
                                    End If
                                    If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                        PartsASalesCash = PartsASalesCash + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                    End If
                                End If
                            End If

                            'PartsSalesCard
                            If dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") IsNot DBNull.Value Then
                                If (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "1") Or (dtApQmvOrd.Rows(DsetRow).Item("DENOMINATION") = "4") Then 'Card
                                    If dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT") IsNot DBNull.Value Then
                                        PartsSalesCard = PartsSalesCard + dtApQmvOrd.Rows(DsetRow).Item("PART_SALES_AMOUNT")
                                    End If
                                    If dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES") IsNot DBNull.Value Then
                                        PartsSalesCard = PartsSalesCard + dtApQmvOrd.Rows(DsetRow).Item("OTHER_SALES")
                                    End If
                                End If
                            End If

                            'Case (1,2,3,4)
                            'LabourTotalCash
                            'LabourTotalCard

                            'PartsTotalCash
                            'PartsTotalCard

                    End Select
                End If
            Next

            UnderRepairTotal = UnderRepairIW + UnderRepairOOW + UnderRepairAC
            CustodayTotal = CustodayIW + CustodayOOW + CustodayAC
            GsxTotal = GsxIW + GsxOOW + GsxAC
            DeliveredTotal = DeliveredIW + DeliveredOOW + DeliveredAC
        End If

        _AppleSalesModel.GeneratedPo = GeneratedPo
        _AppleSalesModel.NewToken = NewToken
        _AppleSalesModel.PickupToken = PickupToken
        _AppleSalesModel.TotalToken = TotalToken
        _AppleSalesModel.UnderRepairIW = UnderRepairIW
        _AppleSalesModel.UnderRepairOOW = UnderRepairOOW
        _AppleSalesModel.UnderRepairAC = UnderRepairAC
        _AppleSalesModel.UnderRepairTotal = UnderRepairTotal
        _AppleSalesModel.CustodayIW = CustodayIW
        _AppleSalesModel.CustodayOOW = CustodayOOW
        _AppleSalesModel.CustodayAC = CustodayAC
        _AppleSalesModel.CustodayTotal = CustodayTotal
        _AppleSalesModel.GsxIW = GsxIW
        _AppleSalesModel.GsxOOW = GsxOOW
        _AppleSalesModel.GsxAC = GsxAC
        _AppleSalesModel.GsxTotal = GsxTotal
        _AppleSalesModel.DeliveredIW = DeliveredIW
        _AppleSalesModel.DeliveredOOW = DeliveredOOW
        _AppleSalesModel.DeliveredAC = DeliveredAC
        _AppleSalesModel.DeliveredTotal = DeliveredTotal
        _AppleSalesModel.SalesCount = SalesCount
        _AppleSalesModel.LabourIW = LabourIW
        _AppleSalesModel.LabourIWCash = LabourIWCash
        _AppleSalesModel.LabourIWCard = LabourIWCard
        _AppleSalesModel.LabourOOWCash = LabourOOWCash
        _AppleSalesModel.LabourOOWCard = LabourOOWCard
        _AppleSalesModel.LabourACCash = LabourACCash
        _AppleSalesModel.LabourACCard = LabourACCard
        _AppleSalesModel.LabourSalesCash = LabourSalesCash
        _AppleSalesModel.LabourSalesCard = LabourSalesCard
        _AppleSalesModel.LabourTotalCash = LabourTotalCash
        _AppleSalesModel.LabourTotalCard = LabourTotalCard
        _AppleSalesModel.PartsIW = PartsIW
        _AppleSalesModel.PartsIWCash = PartsIWCash
        _AppleSalesModel.PartsIWCard = PartsIWCard
        _AppleSalesModel.PartsOOWCash = PartsOOWCash
        _AppleSalesModel.PartsOOWCard = PartsOOWCard
        _AppleSalesModel.PartsACCash = PartsACCash
        _AppleSalesModel.PartsACCard = PartsACCard
        _AppleSalesModel.PartsASalesCash = PartsASalesCash
        _AppleSalesModel.PartsSalesCard = PartsSalesCard
        _AppleSalesModel.PartsTotalCash = PartsTotalCash
        _AppleSalesModel.PartsTotalCard = PartsTotalCard


        Dim _AppleSalesModel1 As List(Of AppleSalesModel) = New List(Of AppleSalesModel)
        _AppleSalesModel1.Add(_AppleSalesModel)
        Dim dt As New DataTable
        dt = ToDataTable(_AppleSalesModel1)
        Return dt
    End Function


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        txtFrom.Text = Trim(txtFrom.Text)
        txtTo.Text = Trim(txtTo.Text)
        'LoadDailySalesOld
        'Load Daily Sales
        LoadDailySales()
    End Sub


    Sub LoadDailySalesOld()
        Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
        Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
        Dim shipCode As String = Session("ship_code")
        If shipCode = "" Then
            Response.Redirect("Login.aspx")
        End If
        _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode


        _AppleQmvOrdModel.DateFrom = txtFrom.Text
        _AppleQmvOrdModel.DateTo = txtTo.Text

        Dim tmpInt As Integer = 0



        Dim dtAppleQmv As DataTable = _AppleQmvOrdControl.SelectSummary(_AppleQmvOrdModel)
        If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then
        Else



            If Not IsDBNull(dtAppleQmv.Rows(0)("NewToken")) Then
                lblNewToken.Text = dtAppleQmv.Rows(0)("NewToken")
            Else
                lblNewToken.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PickupToken")) Then
                lblPickupToken.Text = dtAppleQmv.Rows(0)("PickupToken")
            Else
                lblPickupToken.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("TotalToken")) Then
                lblTotalToken.Text = dtAppleQmv.Rows(0)("TotalToken")
            Else
                lblTotalToken.Text = 0
            End If




            If Not IsDBNull(dtAppleQmv.Rows(0)("GeneratedPo")) Then
                tmpInt = dtAppleQmv.Rows(0)("GeneratedPo")
                'Need to compate with Token machine and assign maximum one
                'Take the larger one compared to Token Machine
                If tmpInt > Val(lblTotalToken.Text) Then
                    lblGeneratePo.Text = tmpInt
                Else
                    lblGeneratePo.Text = lblTotalToken.Text
                End If
            Else
                lblGeneratePo.Text = lblTotalToken.Text 'If no Po Generated, then Token numbers higher
            End If

            'Under Process
            If Not IsDBNull(dtAppleQmv.Rows(0)("UnderRepairIW")) Then
                lblUnderRepairIW.Text = dtAppleQmv.Rows(0)("UnderRepairIW")
            Else
                lblUnderRepairIW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("UnderRepairOOW")) Then
                lblUnderRepairOOW.Text = dtAppleQmv.Rows(0)("UnderRepairOOW")
            Else
                lblUnderRepairOOW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("UnderRepairAC")) Then
                lblUnderRepairAC.Text = dtAppleQmv.Rows(0)("UnderRepairAC")
            Else
                lblUnderRepairAC.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("UnderRepairTotal")) Then
                lblUnderRepairTotal.Text = dtAppleQmv.Rows(0)("UnderRepairTotal")
            Else
                lblUnderRepairTotal.Text = 0
            End If


            'Custody
            If Not IsDBNull(dtAppleQmv.Rows(0)("CustodayIW")) Then
                lblCustodyIW.Text = dtAppleQmv.Rows(0)("CustodayIW")
            Else
                lblCustodyIW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("CustodayOOW")) Then
                lblCustodyOOW.Text = dtAppleQmv.Rows(0)("CustodayOOW")
            Else
                lblCustodyOOW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("CustodayAC")) Then
                lblCustodyAC.Text = dtAppleQmv.Rows(0)("CustodayAC")
            Else
                lblCustodyAC.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("CustodayTotal")) Then
                lblCustodyTotal.Text = dtAppleQmv.Rows(0)("CustodayTotal")
            Else
                lblCustodyTotal.Text = 0
            End If

            'GSX Completed
            If Not IsDBNull(dtAppleQmv.Rows(0)("GsxIW")) Then
                lblGSXCompIW.Text = dtAppleQmv.Rows(0)("GsxIW")
            Else
                lblGSXCompIW.Text = 0
            End If
            If Not IsDBNull(dtAppleQmv.Rows(0)("GsxOOW")) Then
                lblGSXCompOOW.Text = dtAppleQmv.Rows(0)("GsxOOW")
            Else
                lblGSXCompOOW.Text = 0
            End If
            If Not IsDBNull(dtAppleQmv.Rows(0)("GsxAC")) Then
                lblGSXCompAC.Text = dtAppleQmv.Rows(0)("GsxAC")
            Else
                lblGSXCompAC.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("GsxTotal")) Then
                lblGSXCompTotal.Text = dtAppleQmv.Rows(0)("GsxTotal")
            Else
                lblGSXCompTotal.Text = 0
            End If

            'Delivered
            If Not IsDBNull(dtAppleQmv.Rows(0)("DeliveredIW")) Then
                lblDeliveredIW.Text = dtAppleQmv.Rows(0)("DeliveredIW")
            Else
                lblDeliveredIW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("DeliveredOOW")) Then
                lblDeliveredOOW.Text = dtAppleQmv.Rows(0)("DeliveredOOW")
            Else
                lblDeliveredOOW.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("DeliveredAC")) Then
                lblDeliveredAC.Text = dtAppleQmv.Rows(0)("DeliveredAC")
            Else
                lblDeliveredAC.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("DeliveredTotal")) Then
                lblDeliveredTotal.Text = dtAppleQmv.Rows(0)("DeliveredTotal")
            Else
                lblDeliveredTotal.Text = 0
            End If


            'Sales
            If Not IsDBNull(dtAppleQmv.Rows(0)("SalesCount")) Then
                lblSalesCount.Text = dtAppleQmv.Rows(0)("SalesCount")
            Else
                lblSalesCount.Text = 0
            End If

            'Net Count
            lblNetCount.Text = Val(lblUnderRepairTotal.Text) + Val(lblCustodyTotal.Text) + Val(lblGSXCompTotal.Text) + Val(lblDeliveredTotal.Text) + Val(lblSalesCount.Text)


            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourIW")) Then
                lblLabourIW.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourIW"))
            Else
                lblLabourIW.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsIW")) Then
                lblPartsIW.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsIW"))
            Else
                lblPartsIW.Text = "0.00"
            End If
            lblTotalIW.Text = clsSet.setINR(Val(lblLabourIW.Text) + Val(lblPartsIW.Text))
            lblNetIW.Text = lblTotalIW.Text

            'lblLabourIW.Text = "0.00"
            'lblPartsIW.Text = "0.00"
            'lblTotalIW.Text = "0.00"
            'lblNetIW.Text = "0.00"


            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourOOWCash")) Then
                lblLabourOOWCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourOOWCash"))
            Else
                lblLabourOOWCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourOOWCard")) Then
                lblLabourOOWCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourOOWCard"))
            Else
                lblLabourOOWCard.Text = "0.00"
            End If


            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsOOWCash")) Then
                lblPartsOOWCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsOOWCash"))
            Else
                lblPartsOOWCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsOOWCard")) Then
                lblPartsOOWCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsOOWCard"))
            Else
                lblPartsOOWCard.Text = "0.00"
            End If


            lblTotalOOWCash.Text = clsSet.setINR(Val(lblLabourOOWCash.Text) + Val(lblPartsOOWCash.Text))
            lblTotalOOWCard.Text = clsSet.setINR(Val(lblLabourOOWCard.Text) + Val(lblPartsOOWCard.Text))
            lblNetOOW.Text = clsSet.setINR(Val(lblTotalOOWCash.Text) + Val(lblTotalOOWCard.Text))







            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourACCash")) Then
                lblLabourACCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourACCash"))
            Else
                lblLabourACCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourACCard")) Then
                lblLabourACCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourACCard"))
            Else
                lblLabourACCard.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsACCash")) Then
                lblPartsACCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsACCash"))
            Else
                lblPartsACCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsACCard")) Then
                lblPartsACCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsACCard"))
            Else
                lblPartsACCard.Text = "0.00"
            End If

            lblTotalACCash.Text = clsSet.setINR(Val(lblLabourACCash.Text) + Val(lblPartsACCash.Text))
            lblTotalACCard.Text = clsSet.setINR(Val(lblLabourACCard.Text) + Val(lblPartsACCard.Text))
            lblNetAC.Text = clsSet.setINR(Val(lblTotalACCash.Text) + Val(lblTotalACCard.Text))



            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourSalesCash")) Then
                lblLabourSalesCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourSalesCash"))
            Else
                lblLabourSalesCash.Text = "0.00"
            End If
            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourSalesCard")) Then
                lblLabourSalesCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourSalesCard"))
            Else
                lblLabourSalesCard.Text = "0.00"
            End If


            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsASalesCash")) Then
                lblPartsSalesCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsASalesCash"))
            Else
                lblPartsSalesCash.Text = "0.00"
            End If
            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsSalesCard")) Then
                lblPartsSalesCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsSalesCard"))
            Else
                lblPartsSalesCard.Text = "0.00"
            End If

            lblTotalSalesCash.Text = clsSet.setINR(Val(lblLabourSalesCash.Text) + Val(lblPartsSalesCash.Text))
            lblTotalSalesCard.Text = clsSet.setINR(Val(lblLabourSalesCard.Text) + Val(lblPartsSalesCard.Text))
            lblNetSales.Text = clsSet.setINR(Val(lblTotalSalesCash.Text) + Val(lblTotalSalesCard.Text))




            'If Not IsDBNull(dtAppleQmv.Rows(0)("LabourTotalCash")) Then
            '    lblLabourTotalCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourTotalCash"))
            'Else
            '    lblLabourTotalCash.Text = "0.00"
            'End If

            'If Not IsDBNull(dtAppleQmv.Rows(0)("LabourTotalCard")) Then
            '    lblLabourTotalCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourTotalCard"))
            'Else
            '    lblLabourTotalCard.Text = "0.00"
            'End If

            lblLabourTotalCash.Text = clsSet.setINR(Val(lblLabourOOWCash.Text) + Val(lblLabourACCash.Text) + Val(lblLabourSalesCash.Text))
            lblLabourTotalCard.Text = clsSet.setINR(Val(lblLabourOOWCard.Text) + Val(lblLabourACCard.Text) + Val(lblLabourSalesCard.Text))


            'If Not IsDBNull(dtAppleQmv.Rows(0)("PartsTotalCash")) Then
            '    lblPartsTotalCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsTotalCash"))
            'Else
            '    lblPartsTotalCash.Text = "0.00"
            'End If

            'If Not IsDBNull(dtAppleQmv.Rows(0)("PartsTotalCard")) Then
            '    lblPartsTotalCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsTotalCard"))
            'Else
            '    lblPartsTotalCard.Text = "0.00"
            'End If

            lblPartsTotalCash.Text = clsSet.setINR(Val(lblPartsOOWCash.Text) + Val(lblPartsACCash.Text) + Val(lblPartsSalesCash.Text))
            lblPartsTotalCard.Text = clsSet.setINR(Val(lblPartsOOWCard.Text) + Val(lblPartsACCard.Text) + Val(lblPartsSalesCard.Text))



            lblTotalTotalCash.Text = clsSet.setINR(Val(lblTotalOOWCash.Text) + Val(lblTotalACCash.Text) + Val(lblTotalSalesCash.Text))
            lblTotalTotalCard.Text = clsSet.setINR(Val(lblTotalOOWCard.Text) + Val(lblTotalACCard.Text) + Val(lblTotalSalesCard.Text))
            lblNetTotal.Text = clsSet.setINR(Val(lblTotalTotalCash.Text) + Val(lblTotalTotalCard.Text))


            lblLabourNet.Text = clsSet.setINR(Val(lblLabourTotalCash.Text) + Val(lblLabourTotalCard.Text) + Val(lblLabourIW.Text))
            lblPartsNet.Text = clsSet.setINR(Val(lblPartsTotalCash.Text) + Val(lblPartsTotalCard.Text) + Val(lblPartsIW.Text))

            lblTotalTotal.Text = clsSet.setINR(Val(lblLabourNet.Text) + Val(lblPartsNet.Text))

            lblNet.Text = clsSet.setINR(Val(lblTotalTotal.Text))


        End If
    End Sub
End Class