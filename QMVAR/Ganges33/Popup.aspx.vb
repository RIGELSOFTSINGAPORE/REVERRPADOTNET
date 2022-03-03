'Imports System.Web.UI.Page
Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Public Class Popup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Dim value As String = Request.QueryString("rowIndex")
        'Console.WriteLine("value**** " + value)
        'Label.value = Span1.InnerText
        ' Span1.InnerText = value
        ' Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        ' Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        ' Dim _Datatble As DataTable = SetupNewServiceCenterControl.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        ' Dim _dataview As New DataView(_Datatble)


        'Dim DateTimeNow As DateTime = DateTime.Now
        'Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        'Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Dim dbConn As DBUtility = New DBUtility()
        'Dim dt As DataTable = New DataTable()
        'Dim flag As Boolean = False
        'Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & " * from M_SHIP_BASE "
        'If queryParams.SHIP_CODE <> 0 Then
        '    sqlStr = sqlStr & "Where @SHIP_CODE = ship_code "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_CODE", queryParams.SHIP_CODE))
        'End If

        'Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        'dbConn.CloseConnection()



        ' Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        'Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl
        'Dim _Datatble As DataTable = SetupNewServiceCentercontrol.ShowSetupNewServiceCenterGrid(SetupNewServiceCenterModel)
        'Dim _dataview As New DataView(_Datatble)
        'getdata.DataSource = _dataview
        'Dim index As String = Request.QueryString("rowIndex")
        '  Dim SetupNewServiceCenterModel As New SetupNewServiceCenterModel
        ' Dim SetupNewServiceCentercontrol As New SetupNewServiceCenterControl

        Dim _SetupNewServiceCenterModel As SetupNewServiceCenterModel = New SetupNewServiceCenterModel()
        Dim _SetupNewServiceCenterControl As SetupNewServiceCenterControl = New SetupNewServiceCenterControl()
        'Dim value As String = Request.QueryString("rowIndex").ToString
        '_SetupNewServiceCenterModel.SHIP_CODE = value.Substring(0, 50)
        'lblship_code.InnerText = value.Substring(0, 50)
        Dim value As String = Request.QueryString("rowIndex").ToString
        _SetupNewServiceCenterModel.SHIP_CODE = value.ToString
        lblship_code1.Text = value.ToString
        Dim _Datatble As DataTable = _SetupNewServiceCenterControl.ShowSetupNewServiceCenterGrid(_SetupNewServiceCenterModel)
        If Not IsDBNull(_Datatble.Rows(0)("CRTDT")) Then
            lblCRTDT1.Text = _Datatble.Rows(0)("CRTDT")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("CRTCD")) Then
            lblCRTCD1.Text = _Datatble.Rows(0)("CRTCD")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("UPDDT")) Then
            lblUPDDT1.Text = _Datatble.Rows(0)("UPDDT")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("UPDCD")) Then
            lblUPDCD1.Text = _Datatble.Rows(0)("UPDCD")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("UPDPG")) Then
            lblUPDPG1.Text = _Datatble.Rows(0)("UPDPG")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
            lblDELFG1.Text = _Datatble.Rows(0)("DELFG")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_name")) Then
            lblship_name1.Text = _Datatble.Rows(0)("ship_name")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_info")) Then
            lblship_info1.Text = _Datatble.Rows(0)("ship_info")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_manager")) Then
            lblship_manager1.Text = _Datatble.Rows(0)("ship_manager")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_tel")) Then
            lblship_tel1.Text = _Datatble.Rows(0)("ship_tel")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_add1")) Then
            lblship_add11.Text = _Datatble.Rows(0)("ship_add1")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_add2")) Then
            lblship_add21.Text = _Datatble.Rows(0)("ship_add2")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_add3")) Then
            lblship_add31.Text = _Datatble.Rows(0)("ship_add3")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("zip")) Then
            lblzip1.Text = _Datatble.Rows(0)("zip")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("e_mail")) Then
            lble_mail1.Text = _Datatble.Rows(0)("e_mail")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_service")) Then
            lblship_service1.Text = _Datatble.Rows(0)("ship_service")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("open_time")) Then
            lblopen_time1.Text = _Datatble.Rows(0)("open_time")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("close_time")) Then
            lblclose_time1.Text = _Datatble.Rows(0)("close_time")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("opening_date")) Then
            lblopening_date1.Text = _Datatble.Rows(0)("opening_date")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("closing_date")) Then
            lblclosing_date1.Text = _Datatble.Rows(0)("closing_date")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_code")) Then
            lblship_code1.Text = _Datatble.Rows(0)("ship_code")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_mark")) Then
            lblship_mark1.Text = _Datatble.Rows(0)("ship_mark")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("item_1")) Then
            lblitem_11.Text = _Datatble.Rows(0)("item_1")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("item_2")) Then
            lblitem_21.Text = _Datatble.Rows(0)("item_2")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("mess_1")) Then
            lblmess_11.Text = _Datatble.Rows(0)("mess_1")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("mess_2")) Then
            lblmess_21.Text = _Datatble.Rows(0)("mess_2")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("mess_3")) Then
            lblmess_31.Text = _Datatble.Rows(0)("mess_3")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("regi_deposit")) Then
            lblregi_deposit1.Text = _Datatble.Rows(0)("regi_deposit")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("PO_no")) Then
            lblPO_no1.Text = _Datatble.Rows(0)("PO_no")
        End If

        'If Not IsDBNull(_Datatble.Rows(0)("inspection1_start")) Then
        '    lblinspection1_start1.Text = _Datatble.Rows(0)("inspection1_start")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("inspection1_end")) Then
        '    lblinspection1_end1.Text = _Datatble.Rows(0)("inspection1_end")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("inspection2_start")) Then
        '    lblinspection2_start1.Text = _Datatble.Rows(0)("inspection2_start")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("inspection2_end")) Then
        '    lblinspection2_end1.Text = _Datatble.Rows(0)("inspection2_end")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("inspection3_start")) Then
        '    lblinspection3_start1.Text = _Datatble.Rows(0)("inspection3_start")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("inspection3_end")) Then
        '    lblinspection3_end1.Text = _Datatble.Rows(0)("inspection3_end")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("open_start")) Then
        '    lblopen_start1.Text = _Datatble.Rows(0)("open_start")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("open_end")) Then
        '    lblopen_end1.Text = _Datatble.Rows(0)("open_end")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("close_start")) Then
        '    lblclose_start1.Text = _Datatble.Rows(0)("close_start")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("close_end")) Then
        '    lblclose_end1.Text = _Datatble.Rows(0)("close_end")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("GSTIN")) Then
        '    lblGSTIN1.Text = _Datatble.Rows(0)("GSTIN")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("Parent_Ship_Name")) Then
        '    lblParent_Ship_Name1.Text = _Datatble.Rows(0)("Parent_Ship_Name")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("IsChildShip")) Then
        '    lblIsChildShip1.Text = _Datatble.Rows(0)("IsChildShip")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("RpaClientUserId")) Then
        '    lblRpaClientUserId1.Text = _Datatble.Rows(0)("RpaClientUserId")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("RpaClientPwd")) Then
        '    lblRpaClientPwd1.Text = _Datatble.Rows(0)("RpaClientPwd")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("pwdupdateddate")) Then
        '    lblpwdupdateddate1.Text = _Datatble.Rows(0)("pwdupdateddate")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("IsShipCodeChanged")) Then
        '    lblIsShipCodeChanged1.Text = _Datatble.Rows(0)("IsShipCodeChanged")
        'End If



        '    inspection3_start
        'CRTDT.InnerText = "server side"
    End Sub



End Class