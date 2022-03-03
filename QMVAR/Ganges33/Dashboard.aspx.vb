﻿Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports Ganges33.Ganges33.logic

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("cnstr").ConnectionString)
            con.Open()

            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            Dim adminFlg As Boolean = Session("admin_Flg")

            'トランザクション開始＆コネクションオープン
            Dim trn As SqlTransaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
            Dim mon As String
            Dim mon1 As String
            Dim Year = Today.Year
            Dim month = Today.Month.ToString
            If month.Length = 1 Then
                mon1 = "0" & month
            End If

            mon = Year & "/" & mon1.ToString

            Dim strSQL = "If EXISTS (SELECT * FROM Activity_report WHERE month = '" & mon & "')  BEGIN"
            strSQL = strSQL & " select day   ,(Customer_Visit),(Call_Registerd),(repair_completed),(goods_delivered),(Pending_Calls),(Cancelled_Calls) from Activity_report where month = '" & mon & "' order by day  END"
            strSQL = strSQL & " ELSE BEGIN Select  TempTableName.Day, TempTableName1.Customer_Visit,TempTableName2.Call_Registerd,TempTableName3.repair_completed,TempTableName4.goods_delivered,"
            strSQL = strSQL & " TempTableName5.Pending_Calls, TempTableName6.Cancelled_Calls From "
            strSQL = strSQL & " (VALUES(1),(2),(3),(4),(5),(6),(7),(9),(10),(11),(12),(13),(14),(15),(16),(17),(18),(19),(20),(21),(22),(23),(24),(25),(26),(27),(28),(29),(30) ) AS TempTableName (Day),"
            strSQL = strSQL & " (VALUES (0)) TempTableName1 (Customer_Visit),(VALUES (0)) TempTableName2 (Call_Registerd),(VALUES (0)) TempTableName3 (repair_completed),(VALUES (0)) TempTableName4 (goods_delivered),"
            strSQL = strSQL & " (VALUES (0)) TempTableName5 (Pending_Calls), (VALUES (0)) TempTableName6 (Cancelled_Calls) END"
            Dim sqlSelect As New SqlCommand(strSQL, con, trn)
            Dim Adapter As New SqlDataAdapter(sqlSelect)
            Dim ds1 As New DataSet

            Adapter.Fill(ds1)

            Dim strSQLsales = "select Day(delivery_Date)Delivery_Date,count(*)sales from Wty_Excel where year(Delivery_Date) = '" & Year & "' and month(Delivery_Date) = '" & mon1 & "' group by Delivery_Date"
            Dim sqlSelect1 As New SqlCommand(strSQLsales, con, trn)
            Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
            Dim ds2 As New DataSet
            Adapter1.Fill(ds2)

            'Dim strSQL1 = "select day   ,(Call_Registerd),(repair_completed),(goods_delivered),(Pending_Calls),(Cancelled_Calls) from Activity_report where month = '" & Mon & "' order by day"

            'Dim sqlSelect1 As New SqlCommand(strSQL1, con, trn)
            'Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
            'Dim ds1 As New DataSet
            'Adapter.Fill(ds1)

            If userLevel = "0" Or userLevel = "1" Or userLevel = "2" Or adminFlg = True Then
                Chart1.Visible = True
                Chart2.Visible = True
                Chart3.Visible = True
                Chart4.Visible = True
                Chart5.Visible = True
                Chart6.Visible = True
                Chart7.Visible = True
                Chart18.Visible = True


                Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                '  Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

                Chart2.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Chart2.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                ' Chart2.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

                Chart3.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Chart3.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                ' Chart3.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

                Chart4.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Chart4.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                ' Chart4.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

                Chart5.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Chart5.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                ' Chart5.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

                Chart6.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Chart6.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                ' Chart6.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

                Chart7.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Chart7.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
                ' Chart7.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

                Chart18.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Chart18.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            Else
                CustomerVisit.Visible = False
                CallRegisterd.Visible = False
                Repaircompleted.Visible = False
                GoodsDelivered.Visible = False
                PendingCalls.Visible = False
                CancelledCalls.Visible = False
                Sales.Visible = False

                Chart1.Visible = False
                Chart2.Visible = False
                Chart3.Visible = False
                Chart4.Visible = False
                Chart5.Visible = False
                Chart6.Visible = False
                Chart7.Visible = False
                Chart18.Visible = False
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

        Catch ex As Exception
            Log4NetControl.ComErrorLogWrite(ex.ToString())
            Exit Sub
        End Try

    End Sub
    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click

        Response.Redirect("Dashboard_view.aspx")
    End Sub
End Class