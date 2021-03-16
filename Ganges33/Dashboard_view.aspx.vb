Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports Ganges33.Ganges33.logic
Imports Ganges33.Ganges33.model

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
        getdata()
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

            Dim Month = Year & "/" & Mon
            If userLevel = "0" Or " 1" Or "2" Or "3" Or "4" Then
                If DropdownList1.SelectedValue = "All" Then
                    For i As Integer = 0 To DropdownList1.Items.Count - 1


                        'center1 = center1 + DropdownList1.Items(i).Value & ","
                        center1 += "'" + DropdownList1.Items(i).Value + "',"


                        center = Left(center1, Len(center1) - 1)

                    Next

                Else
                    center = DropdownList1.SelectedItem.Value
                End If
            Else
                For i As Integer = 0 To DropdownList1.Items.Count - 1


                    'center1 = center1 + DropdownList1.Items(i).Value & ","
                    center1 += "'" + DropdownList1.Items(i).Value + "',"


                    center = Left(center1, Len(center1) - 1)

                Next
            End If


            Dim strSQL = "If EXISTS (SELECT * FROM Activity_report WHERE month = '" & Month & "' and location in (" & center & "))  BEGIN"
            strSQL = strSQL & " select day   ,(Customer_Visit),(Call_Registerd),(repair_completed),(goods_delivered),(Pending_Calls),(Cancelled_Calls) from Activity_report where month = '" & Month & "' and  location in (" & center & ") order by day  END"
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

            Dim strSQLsales = "If EXISTS (SELECT * FROM Wty_Excel WHERE  year(Delivery_Date) ='" & Year & "' and month(Delivery_Date) = '" & Mon & "' and  Branch_code in (" & center & "))"
            strSQLsales = strSQLsales & " BEGIN select Day(delivery_Date)Delivery_Date,count(*)sales from Wty_Excel "
            strSQLsales = strSQLsales & " where year(Delivery_Date) = '" & Year & "' and month(Delivery_Date) = '" & Mon & "' and  Branch_code in (" & center & ") group by Delivery_Date END ELSE BEGIN SELECT "
            strSQLsales = strSQLsales & " TempTableName.Day as Delivery_Date ,TempTableName1.sales from (VALUES(1),(2),(3),(4),(5),(6),(7),(9),(10),(11),(12),(13),(14),(15),(16),(17),(18),(19),(20),(21),(22),(23),(24), "
            strSQLsales = strSQLsales & " (25),(26),(27),(28),(29),(30) ) AS TempTableName (Day),(VALUES (0)) TempTableName1 (sales) END"
            Dim sqlSelect1 As New SqlCommand(strSQLsales, con, trn)
            Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
            Dim ds2 As New DataSet
            Adapter1.Fill(ds2)
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