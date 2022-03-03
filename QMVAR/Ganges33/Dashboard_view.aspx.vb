Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports Ganges33.Ganges33.logic
Imports Ganges33.Ganges33.model
Imports System.Web.UI.DataVisualization.Charting

Public Class Dashboard_view
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim userName As String = Session("user_Name")
        Dim userLevel As String = Session("user_level")
        Dim adminFlg As Boolean = Session("admin_Flg")
        'CustomerVisit.Visible = False
        'CallRegisterd.Visible = False
        'Repaircompleted.Visible = False
        'GoodsDelivered.Visible = False
        'PendingCalls.Visible = False
        'CancelledCalls.Visible = False
        'Sales.Visible = False
        'Chart1.Visible = False
        'Chart2.Visible = False
        'Chart3.Visible = False
        'Chart4.Visible = False
        'Chart5.Visible = False
        'Chart6.Visible = False
        'Chart7.Visible = False
        'Chart18.Visible = False
        Dim userid As String = Session("user_id")
        If userid = "" Then
            Response.Redirect("Login.aspx")
        End If

        If IsPostBack = False Then
            Dim servicecode As String = Session("ship_code")

            DropdownList1.SelectedValue = servicecode
            DropDownYear.SelectedValue = Today.Year
            Dim month = Today.Month.ToString
            Dim mon1 As String
            If month.Length = 1 Then
                mon1 = "0" & month
            End If
            InitDropDownList1()
            DropDownMonth.SelectedValue = mon1
            getdata()
        Else

            getdata()
        End If
    End Sub
    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        'getdata()
    End Sub
    Public Sub getdata()
        Try
            Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("cnstr").ConnectionString)
            con.Open()

            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            Dim adminFlg As Boolean = Session("admin_Flg")


            'トランザクション開始＆コネクションオープン
            Dim trn As SqlTransaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
            'Dim mon As String
            'Dim mon1 As String
            'Dim Year = Today.Year
            'Dim month = Today.Month.ToString
            'If month.Length = 1 Then
            '    mon1 = "0" & month
            'End If

            'mon = Year & "/" & mon1.ToString
            ' Dim list = DropdownList1.
            Dim Year = DropDownYear.SelectedValue
            Dim Mon = DropDownMonth.SelectedValue
            Dim center As String
            Dim center1 As String
            Dim centerName As String
            centerName = ""

            Dim Month = Year & "/" & Mon
            If userLevel = "0" Or " 1" Or "2" Or "3" Or "4" Then
                If DropdownList1.SelectedValue = "All" Then
                    For i As Integer = 0 To DropdownList1.Items.Count - 1


                        'center1 = center1 + DropdownList1.Items(i).Value & ","
                        center1 += "'" + DropdownList1.Items(i).Value + "',"


                        center = Left(center1, Len(center1) - 1)
                        centerName += "'" + DropdownList1.Items(i).Text + "',"
                    Next
                    centerName = Left(centerName, Len(centerName) - 1)
                Else
                    center = DropdownList1.SelectedItem.Value
                    centerName = "'" + DropdownList1.SelectedItem.Text + "'"
                End If
            Else
                For i As Integer = 0 To DropdownList1.Items.Count - 1


                    'center1 = center1 + DropdownList1.Items(i).Value & ","
                    center1 += "'" + DropdownList1.Items(i).Value + "',"


                    center = Left(center1, Len(center1) - 1)
                    centerName += "'" + DropdownList1.Items(i).Text + "',"
                    centerName = Left(centerName, Len(centerName) - 1)
                Next
            End If


            Dim strSQL = "If EXISTS (SELECT * FROM Activity_report WHERE month = '" & Month & "' and location in (" & center & "))  BEGIN"
            strSQL = strSQL & " select day   ,sum(Customer_Visit) Customer_Visit,sum(Call_Registerd) Call_Registerd,sum(repair_completed) repair_completed,sum(goods_delivered) goods_delivered,sum(Pending_Calls) Pending_Calls,sum(Cancelled_Calls) Cancelled_Calls from Activity_report where month = '" & Month & "' and  location in (" & center & ") Group by day order by day  END"
            strSQL = strSQL & " ELSE BEGIN Select  TempTableName.Day, TempTableName1.Customer_Visit,TempTableName2.Call_Registerd,TempTableName3.repair_completed,TempTableName4.goods_delivered,"
            strSQL = strSQL & " TempTableName5.Pending_Calls, TempTableName6.Cancelled_Calls From "
            strSQL = strSQL & " (VALUES(1),(2),(3),(4),(5),(6),(7),(9),(10),(11),(12),(13),(14),(15),(16),(17),(18),(19),(20),(21),(22),(23),(24),(25),(26),(27),(28),(29),(30) ) AS TempTableName (Day),"
            strSQL = strSQL & " (VALUES (0)) TempTableName1 (Customer_Visit),(VALUES (0)) TempTableName2 (Call_Registerd),(VALUES (0)) TempTableName3 (repair_completed),(VALUES (0)) TempTableName4 (goods_delivered),"
            strSQL = strSQL & " (VALUES (0)) TempTableName5 (Pending_Calls), (VALUES (0)) TempTableName6 (Cancelled_Calls) END"
            Dim sqlSelect As New SqlCommand(strSQL, con, trn)
            Dim Adapter As New SqlDataAdapter(sqlSelect)
            Dim ds1 As New DataSet

            Adapter.Fill(ds1)

            'Dim strSQL1 = "select day   ,(Call_Registerd),(repair_completed),(goods_delivered),(Pending_Calls),(Cancelled_Calls) from Activity_report where month = '" & Mon & "' order by day"

            'Dim sqlSelect1 As New SqlCommand(strSQL1, con, trn)
            'Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
            'Dim ds1 As New DataSet
            'Adapter.Fill(ds1)

            'Dim strSQLsales = "select Day(delivery_Date)Delivery_Date,count(*)sales from Wty_Excel where year(Delivery_Date) = '" & Year & "' and month(Delivery_Date) = '" & Mon & "' group by Delivery_Date"
            'Dim sqlSelect1 As New SqlCommand(strSQLsales, con, trn)
            'Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
            'Dim ds2 As New DataSet
            'Adapter1.Fill(ds2)
            'VJ Need to Work 2021/09/11

            '    Declare @UploadBranchName varchar(20)
            '    Declare @UploadBranchCode varchar(20)
            '    Declare @Date varchar(20)
            '    Declare @Bill_From_Date varchar(20)
            '    Declare @Bill_To_Date varchar(20)
            '    Declare @mon_FirstDate varchar(20)

            '    Set @UploadBranchName = 'SSC1'
            'Set @UploadBranchCode = '0001907621'
            'Set @Date= '2021/01'
            'Set @Bill_From_Date = '2020/12/29'
            'Set @Bill_To_Date = '2021/01/28'
            'Set @mon_FirstDate = '2021-01-01'

            'Select Case
            'Billing_date,Branch_name,IW_Count,OW_Count,IW_Labor_total,
            'IW_Parts_total,IW_Transport_total,IW_Others_total,IW_Tax_total,
            'IW_Total_total,OW_Labor_total,OW_Parts_total,OW_Transport_total,
            'OW_Others_total,OW_Tax_total,OW_Total_total,IW_goods_total,
            'OW_goods_total,isnull(LABOR,0) LABOR,isnull(Parts,0) Parts,
            '(IW_Labor_total+IW_Transport_total+IW_Others_total) InWarrantyAmount,
            '(
            '		OW_Labor_total+OW_Parts_total+OW_Transport_total+
            '		OW_Others_total+isnull(LABOR,0)+isnull(Parts,0)
            '		) OutWarrantyAmount,
            'Cast( (
            'IW_Labor_total+IW_Transport_total+IW_Others_total+
            'OW_Labor_total+OW_Parts_total+OW_Transport_total+
            'OW_Others_total+isnull(LABOR,0)+isnull(Parts,0)
            ') as decimal(18,2)) as SalesAmount
            'From dbo.SC_DSR_info 
            'left join
            '(
            '	Select Case ModNewBilling_date, sum(LABOR) LABOR, sum(Parts) Parts
            '	From
            '	(
            '	Select Case distinct ServiceOrder_No,--SC_DSR.Billing_date,
            '	Case when MONTH(SC_DSR.Billing_date) != month(@Bill_To_Date) then
            '	convert(datetime,@mon_FirstDate)
            '	Else SC_DSR.Billing_date End ModNewBilling_date,Invoice_update.LABOR,Invoice_update.Parts
            '	from SC_DSR 
            '	Join Wty_Excel On Wty_Excel.ASC_Claim_No = SC_DSR.ServiceOrder_No
            '	Join Invoice_update On Invoice_update.Your_Ref_No = SC_DSR.ServiceOrder_No
            '	where SC_DSR.DELFG!=1 And Wty_Excel.DELFG!=1
            '	And  Wty_Excel.Branch_Code=@UploadBranchCode
            '	And Invoice_update.upload_Branch in (@UploadBranchName) And Number = 'OWC'
            '	And CONVERT(VARCHAR, SC_DSR.Billing_date, 111) between @Bill_From_Date And @Bill_To_Date
            '	) INVUPD group by ModNewBilling_date

            ') SAWDISCOUNT ON SAWDISCOUNT.ModNewBilling_date = SC_DSR_info.Billing_date
            'WHERE SC_DSR_info.DELFG = 0 
            'And SC_DSR_info.Branch_name = @UploadBranchName
            'And LEFT(CONVERT(VARCHAR, Billing_date,111),7) = @Date


            'Dim strSQLsales = "If EXISTS (SELECT * FROM Wty_Excel WHERE  year(Delivery_Date) ='" & Year & "' and month(Delivery_Date) = '" & Mon & "' and  Branch_code in (" & center & "))"
            'strSQLsales = strSQLsales & " BEGIN select Day(delivery_Date)Delivery_Date,count(*)sales from Wty_Excel "
            'strSQLsales = strSQLsales & " where year(Delivery_Date) = '" & Year & "' and month(Delivery_Date) = '" & Mon & "' and  Branch_code in (" & center & ") group by Delivery_Date END ELSE BEGIN SELECT "
            'strSQLsales = strSQLsales & " TempTableName.Day as Delivery_Date ,TempTableName1.sales from (VALUES(1),(2),(3),(4),(5),(6),(7),(9),(10),(11),(12),(13),(14),(15),(16),(17),(18),(19),(20),(21),(22),(23),(24), "
            'strSQLsales = strSQLsales & " (25),(26),(27),(28),(29),(30) ) AS TempTableName (Day),(VALUES (0)) TempTableName1 (sales) END"

            Dim Mon_FirstDate As DateTime
            Mon_FirstDate = Year & "-" & Mon & "-01"
            Dim Bill_FromDate As DateTime
            Dim Bill_ToDate As DateTime
            'Dim Mod_Bill_FromDate As String
            'Dim Mod_Bill_ToDate As String
            Bill_FromDate = Mon_FirstDate.AddDays(-3)
            Bill_ToDate = Year & "-" & Mon & "-" & DateTime.DaysInMonth(Year, Mon)
            Bill_ToDate = Bill_ToDate.AddDays(-3)
            'Mod_Bill_FromDate = Bill_FromDate.Year & "/" & Bill_FromDate.Month & "/" & Bill_FromDate.Day
            'Mod_Bill_ToDate = Bill_ToDate.Year & "/" & Bill_ToDate.Month & "/" & Bill_ToDate.Day


            Dim strSQLsales = "If EXISTS (SELECT * FROM Wty_Excel WHERE  year(Delivery_Date) ='" & Year & "' and month(Delivery_Date) = '" & Mon & "' and  Branch_code in (" & center & "))"
            'strSQLsales = strSQLsales & " BEGIN select Day(delivery_Date)Delivery_Date,count(*)sales from Wty_Excel "
            'strSQLsales = strSQLsales & " where year(Delivery_Date) = '" & Year & "' and month(Delivery_Date) = '" & Mon & "' and  Branch_code in (" & center & ") group by Delivery_Date END ELSE BEGIN SELECT "
            strSQLsales = strSQLsales & " BEGIN "
            strSQLsales = strSQLsales & " Select Delivery_Date,sum(sales) sales from "
            strSQLsales = strSQLsales & " ( "
            strSQLsales = strSQLsales & " select Day(Billing_date) Delivery_Date "
            'strSQLsales = strSQLsales & " ,Branch_name,IW_Count,OW_Count,IW_Labor_total, "
            'strSQLsales = strSQLsales & " IW_Parts_total,IW_Transport_total,IW_Others_total,IW_Tax_total, "
            'strSQLsales = strSQLsales & " IW_Total_total,OW_Labor_total,OW_Parts_total,OW_Transport_total, "
            'strSQLsales = strSQLsales & " OW_Others_total,OW_Tax_total,OW_Total_total,IW_goods_total, "
            'strSQLsales = strSQLsales & " OW_goods_total,isnull(LABOR,0) LABOR,isnull(Parts,0) Parts, "
            'strSQLsales = strSQLsales & " (IW_Labor_total+IW_Transport_total+IW_Others_total) InWarrantyAmount, "
            'strSQLsales = strSQLsales & " ( "
            'strSQLsales = strSQLsales & "       OW_Labor_total+OW_Parts_total+OW_Transport_total+ "
            'strSQLsales = strSQLsales & "       OW_Others_total+isnull(LABOR,0)+isnull(Parts,0) "
            'strSQLsales = strSQLsales & " ) OutWarrantyAmount "
            strSQLsales = strSQLsales & " ,Cast( ( "
            strSQLsales = strSQLsales & " IW_Labor_total+IW_Transport_total+IW_Others_total+ "
            strSQLsales = strSQLsales & " OW_Labor_total+OW_Parts_total+OW_Transport_total+ "
            strSQLsales = strSQLsales & " OW_Others_total+isnull(LABOR,0)+isnull(Parts,0) "
            strSQLsales = strSQLsales & " ) as decimal(18,2)) as sales "
            strSQLsales = strSQLsales & " From dbo.SC_DSR_info "
            strSQLsales = strSQLsales & " left join "
            strSQLsales = strSQLsales & " ( "
            strSQLsales = strSQLsales & " select ModNewBilling_date, sum(LABOR) LABOR, sum(Parts) Parts "
            strSQLsales = strSQLsales & " From "
            strSQLsales = strSQLsales & " ( "
            strSQLsales = strSQLsales & " select  distinct ServiceOrder_No, "
            strSQLsales = strSQLsales & " case when MONTH(SC_DSR.Billing_date) != month('" & Bill_ToDate & "' ) then "
            strSQLsales = strSQLsales & " convert(datetime,'" & Mon_FirstDate & "') "
            strSQLsales = strSQLsales & " else SC_DSR.Billing_date End ModNewBilling_date,Invoice_update.LABOR,Invoice_update.Parts "
            strSQLsales = strSQLsales & " from SC_DSR "
            strSQLsales = strSQLsales & " Join Wty_Excel on Wty_Excel.ASC_Claim_No = SC_DSR.ServiceOrder_No "
            strSQLsales = strSQLsales & " Join Invoice_update on Invoice_update.Your_Ref_No = SC_DSR.ServiceOrder_No "
            strSQLsales = strSQLsales & " where SC_DSR.DELFG!=1 AND Wty_Excel.DELFG!=1 "
            strSQLsales = strSQLsales & " AND  Wty_Excel.Branch_Code in (" & center & ") "
            strSQLsales = strSQLsales & " AND Invoice_update.upload_Branch in (" & centerName & ") AND Number = 'OWC' "
            strSQLsales = strSQLsales & " and CONVERT(VARCHAR, SC_DSR.Billing_date, 111) between '" & Bill_FromDate & "' and '" & Bill_ToDate & "'"
            strSQLsales = strSQLsales & " ) INVUPD group by ModNewBilling_date "
            strSQLsales = strSQLsales & " ) SAWDISCOUNT ON SAWDISCOUNT.ModNewBilling_date = SC_DSR_info.Billing_date "
            strSQLsales = strSQLsales & " WHERE SC_DSR_info.DELFG = 0 "
            strSQLsales = strSQLsales & " And SC_DSR_info.Branch_name in (" & centerName & ")"
            strSQLsales = strSQLsales & " AND LEFT(CONVERT(VARCHAR, Billing_date,111),7) = '" & Year & "/" & Mon & "'"
            strSQLsales = strSQLsales & " ) SalesRep group by Delivery_Date "
            strSQLsales = strSQLsales & " End Else BEGIN Select "

            strSQLsales = strSQLsales & " TempTableName.Day as Delivery_Date ,TempTableName1.sales from (VALUES(1),(2),(3),(4),(5),(6),(7),(9),(10),(11),(12),(13),(14),(15),(16),(17),(18),(19),(20),(21),(22),(23),(24), "
            strSQLsales = strSQLsales & " (25),(26),(27),(28),(29),(30) ) AS TempTableName (Day),(VALUES (0)) TempTableName1 (sales) END"

            Dim sqlSelect1 As New SqlCommand(strSQLsales, con, trn)
            Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
            Dim ds2 As New DataSet
            Adapter1.Fill(ds2)
            Dim days As Byte
            Dim salsDays As Integer
            Dim isExists As Boolean
            Dim maxValue As Integer
            maxValue = 0
            For days = 1 To DateTime.DaysInMonth(Year, Mon)
                isExists = False

                For salsDays = 0 To ds2.Tables(0).Rows.Count - 1
                    If (days = Convert.ToInt16(ds2.Tables(0).Rows(salsDays).ItemArray(0).ToString())) Then
                        isExists = True
                        Exit For
                    End If
                Next
                If (isExists = False) Then
                    ds2.Tables(0).Rows.Add(days, 0)
                End If
            Next
            'Dim x As Integer = 724

            'Dim y As Double = Math.Ceiling(x / 100) * 100

            Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False

            '  Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            Chart2.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart2.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            'Chart2.ChartAreas("ChartArea1").AxisY.Maximum = 500
            ' Chart2.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            Chart3.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart3.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            'Chart3.ChartAreas("ChartArea1").AxisY.Maximum = 500
            ' Chart3.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            Chart4.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart4.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            'Chart4.ChartAreas("ChartArea1").AxisY.Maximum = 500
            ' Chart4.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            Chart5.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart5.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            'Chart5.ChartAreas("ChartArea1").AxisY.Maximum = 500
            ' Chart5.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            Chart6.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart6.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            'Chart6.ChartAreas("ChartArea1").AxisY.Maximum = 500

            ' Chart6.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            Chart7.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart7.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            'Chart7.ChartAreas("ChartArea1").AxisY.Maximum = 500
            ' Chart7.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            Chart18.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart18.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            Chart18.ChartAreas("ChartArea1").AxisY.LabelStyle.Format = "₹" & "0.00"
            Chart18.ChartAreas("ChartArea1").AxisY.Interval = 100000
            'Chart2.Visible = False
            If userLevel = "0" Or userLevel = "1" Or userLevel = "2" Or userLevel = "3" Or userLevel = "4" Or adminFlg = True Then

                CustomerVisit.Visible = True
                CallRegisterd.Visible = True
                Repaircompleted.Visible = True
                GoodsDelivered.Visible = True
                PendingCalls.Visible = True
                CancelledCalls.Visible = True
                Sales.Visible = True
                DropdownList1.Visible = True
                servicecenter.Visible = True
                Chart1.Visible = True
                Chart2.Visible = True
                Chart3.Visible = True
                Chart4.Visible = True
                Chart5.Visible = True
                Chart6.Visible = True
                Chart7.Visible = True
                Chart18.Visible = True
            ElseIf (userLevel = 9 Or userLevel = 7) Then
                CustomerVisit.Visible = True
                CallRegisterd.Visible = True
                Repaircompleted.Visible = True
                GoodsDelivered.Visible = True
                PendingCalls.Visible = True
                CancelledCalls.Visible = True
                DropdownList1.Visible = False
                servicecenter.Visible = False

                Chart1.Visible = True
                Chart2.Visible = True
                Chart3.Visible = True
                Chart4.Visible = True
                Chart5.Visible = True
                Chart6.Visible = True
                Chart7.Visible = True

                Sales.Visible = False
                Chart18.Visible = False
            Else
                CustomerVisit.Visible = False
                CallRegisterd.Visible = False
                Repaircompleted.Visible = False
                GoodsDelivered.Visible = False
                PendingCalls.Visible = False
                CancelledCalls.Visible = False
                Sales.Visible = False

                DropdownList1.Visible = False
                servicecenter.Visible = False
                Chart1.Visible = False
                Chart2.Visible = False
                Chart3.Visible = False
                Chart4.Visible = False
                Chart5.Visible = False
                Chart6.Visible = False
                Chart7.Visible = False
                Chart18.Visible = False

                Label1.Visible = False
                DropDownMonth.Visible = False
                DropDownYear.Visible = False
                btnSend.Visible = False



            End If


            Chart1.DataSource = ds1
            Chart2.DataSource = ds1
            Chart3.DataSource = ds1
            Chart4.DataSource = ds1
            Chart5.DataSource = ds1
            Chart6.DataSource = ds1
            Chart7.DataSource = ds1
            Chart18.DataSource = ds2



            con.Close()

            If maxValue < ds1.Tables(0).Compute("Max(Customer_Visit)", String.Empty) Then
                maxValue = ds1.Tables(0).Compute("Max(Customer_Visit)", String.Empty)
            End If
            If maxValue < ds1.Tables(0).Compute("Max(Call_Registerd)", String.Empty) Then
                maxValue = ds1.Tables(0).Compute("Max(Call_Registerd)", String.Empty)
            End If
            If maxValue < ds1.Tables(0).Compute("Max(repair_completed)", String.Empty) Then
                maxValue = ds1.Tables(0).Compute("Max(repair_completed)", String.Empty)
            End If
            If maxValue < ds1.Tables(0).Compute("Max(goods_delivered)", String.Empty) Then
                maxValue = ds1.Tables(0).Compute("Max(goods_delivered)", String.Empty)
            End If
            If maxValue < ds1.Tables(0).Compute("Max(Pending_Calls)", String.Empty) Then
                maxValue = ds1.Tables(0).Compute("Max(Pending_Calls)", String.Empty)
            End If
            If maxValue < ds1.Tables(0).Compute("Max(Cancelled_Calls)", String.Empty) Then
                maxValue = ds1.Tables(0).Compute("Max(Cancelled_Calls)", String.Empty)
            End If
            Dim y As Double = 0
            If maxValue > 0 Then
                y = Math.Ceiling(maxValue / 100) * 100
                '    ' y = y + 100
                'Else
                '    y = 100
            End If
            Chart1.ChartAreas("ChartArea1").AxisY.Maximum = y
            Chart2.ChartAreas("ChartArea1").AxisY.Maximum = y
            Chart3.ChartAreas("ChartArea1").AxisY.Maximum = y
            Chart4.ChartAreas("ChartArea1").AxisY.Maximum = y
            Chart5.ChartAreas("ChartArea1").AxisY.Maximum = y
            Chart6.ChartAreas("ChartArea1").AxisY.Maximum = y
            Chart7.ChartAreas("ChartArea1").AxisY.Maximum = y

            'ds1.Tables(0).Compute("Sum(Customer_Visit)", String.Empty)
            Dim annotation As System.Web.UI.DataVisualization.Charting.TextAnnotation = New System.Web.UI.DataVisualization.Charting.TextAnnotation
            annotation.Text = "No data for this period"
            annotation.X = 25
            annotation.Y = 40
            annotation.Font = New System.Drawing.Font("Arial", 12)
            annotation.ForeColor = System.Drawing.Color.White

            Dim annotationSales As System.Web.UI.DataVisualization.Charting.TextAnnotation = New System.Web.UI.DataVisualization.Charting.TextAnnotation
            annotationSales.Text = "No data for this period"
            annotationSales.X = 40
            annotationSales.Y = 40
            annotationSales.Font = New System.Drawing.Font("Arial", 12)
            annotationSales.ForeColor = System.Drawing.Color.White

            If ds1.Tables(0).Compute("Sum(Customer_Visit)", String.Empty) = 0 Then
                Chart1.Annotations.Add(annotation)
            End If
            If ds1.Tables(0).Compute("Sum(Customer_Visit)", String.Empty) = 0 Then
                Chart2.Annotations.Add(annotation)
            End If
            If ds1.Tables(0).Compute("Sum(Call_Registerd)", String.Empty) = 0 Then
                Chart3.Annotations.Add(annotation)
            End If
            If ds1.Tables(0).Compute("Sum(repair_completed)", String.Empty) = 0 Then
                Chart4.Annotations.Add(annotation)
            End If
            If ds1.Tables(0).Compute("Sum(goods_delivered)", String.Empty) = 0 Then
                Chart5.Annotations.Add(annotation)
            End If
            If ds1.Tables(0).Compute("Sum(Pending_Calls)", String.Empty) = 0 Then
                Chart6.Annotations.Add(annotation)
            End If
            If ds1.Tables(0).Compute("Sum(Cancelled_Calls)", String.Empty) = 0 Then
                Chart7.Annotations.Add(annotation)
            End If
            If ds2.Tables(0).Compute("Sum(sales)", String.Empty) = 0 Then
                Chart18.Annotations.Add(annotationSales)
            End If
        Catch ex As Exception
            Log4NetControl.ComErrorLogWrite(ex.ToString())
            Exit Sub
        End Try
    End Sub



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
        codeMaster2.CodeValue = "All"
        codeMaster2.CodeDispValue = "All"
        codeMasterList.Insert(0, codeMaster2)



        Me.DropdownList1.DataSource = codeMasterList
        Me.DropdownList1.DataTextField = "CodeDispValue"
        Me.DropdownList1.DataValueField = "CodeValue"
        Me.DropdownList1.DataBind()
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