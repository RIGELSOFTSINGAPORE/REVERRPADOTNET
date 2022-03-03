Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Web.UI.WebControls
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Analysis_Servicecenter_popup
    Inherits System.Web.UI.Page

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
            'AddUser.Visible = False
            'Header.Text = "User Management"
            ''show grid
            'ShowGrid()
            'Dim MuserUserid As String = Convert.ToString(Request.QueryString("user_id"))
            'Dim cstype As Type = Me.GetType()
            'Dim str2 As String = "window.open('Analysis_Servicecenter_popup.aspx?UserId=" & MuserUserid & "','myWindow','width=800,height=500,left=100,top=100,resizable=yes')"
            ''Client.RegisterStartupScript(This.GetType(), "script", str2, True)
            'ClientScript.RegisterStartupScript(cstype, "script", str2, True)

            GetUserDetails()
        End If
    End Sub

    Private Sub GetUserDetails()

        'Dim MuserUserid1 As String = Convert.ToString(Request.QueryString("user_id"))

        Dim MUsermodel As New MUserModel
        Dim MUsercontrol As New MUserControl
        'MUsermodel.UserId = MuserUserid1
        'ID.Text = MuserUserid1

        Dim _MUsermodel As MUserModel = New MUserModel()
        Dim _MUsercontrol As MUserControl = New MUserControl()

        Dim value As String = Request.QueryString("rowIndex").ToString
        _MUsermodel.UserId = value.ToString
        lblUseid.Text = value.ToString

        Dim _Datatble As DataTable = _MUsercontrol.ViewMUserInfo(_MUsermodel)
        'If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
        '    delflag.Text = _Datatble.Rows(0)("DELFG")
        'End If
        If Not IsDBNull(_Datatble.Rows(0)("user_id")) Then
            lblUseid.Text = _Datatble.Rows(0)("user_id")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("password")) Then
            lblPassword.Text = _Datatble.Rows(0)("password")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("eng_id")) Then
            lblEngId.Text = _Datatble.Rows(0)("eng_id")
        End If


        If Not IsDBNull(_Datatble.Rows(0)("user_level")) Then
            lblUserlvl.Text = _Datatble.Rows(0)("user_level")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("ship_1")) Then
            lblbranchcode1.Text = _Datatble.Rows(0)("ship_1")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_2")) Then
            lblbranchcode2.Text = _Datatble.Rows(0)("ship_2")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_3")) Then
            lblbranchcode3.Text = _Datatble.Rows(0)("ship_3")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_4")) Then
            lblbranchcode4.Text = _Datatble.Rows(0)("ship_4")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("ship_5")) Then
            lblbranchcode5.Text = _Datatble.Rows(0)("ship_5")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("surname")) Then
            lblSurname.Text = _Datatble.Rows(0)("surname")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("name")) Then
            lblName.Text = _Datatble.Rows(0)("name")
        End If


        'If Not IsDBNull(_Datatble.Rows(0)("mid_name")) Then
        '    lblMiddleName.Text = _Datatble.Rows(0)("mid_name")
        'End If
        If Not IsDBNull(_Datatble.Rows(0)("birthday")) Then
            lblDOB.Text = _Datatble.Rows(0)("birthday")
        End If


        If Not IsDBNull(_Datatble.Rows(0)("sex")) Then
            If _Datatble.Rows(0)("sex") = 0 Then
                lblSex.Text = "FeMale"
            Else
                lblSex.Text = "Male"
            End If
        End If

        If Not IsDBNull(_Datatble.Rows(0)("superior")) Then
            lblSuperior.Text = _Datatble.Rows(0)("superior")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("add_1")) Then
            lblAddressLine1.Text = _Datatble.Rows(0)("add_1")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("add_2")) Then
            lblAddressLine2.Text = _Datatble.Rows(0)("add_2")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("add_3")) Then
            lblAddressLine3.Text = _Datatble.Rows(0)("add_3")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("zip")) Then
            lblZipCode.Text = _Datatble.Rows(0)("zip")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("tel")) Then
            lblTelephoneNo1.Text = _Datatble.Rows(0)("tel")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("mobile")) Then
            lblMobileNo.Text = _Datatble.Rows(0)("mobile")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("e_mail")) Then
            lblEmailID.Text = _Datatble.Rows(0)("e_mail")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("em_tel")) Then
            lblTelephoneNo2.Text = _Datatble.Rows(0)("em_tel")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("DELFG")) Then
            If _Datatble.Rows(0)("DELFG") = 0 Then
                lblDeleteflag.Text = "0"
            Else
                lblDeleteflag.Text = "1"
            End If
        End If
        If Not IsDBNull(_Datatble.Rows(0)("admin_flg")) Then
            If _Datatble.Rows(0)("admin_flg") = 0 Then
                lblDeleteflag.Text = "0"
            Else
                lblDeleteflag.Text = "1"
            End If
        End If
        If Not IsDBNull(_Datatble.Rows(0)("CRTDT")) Then
            lblCRTDT.Text = _Datatble.Rows(0)("CRTDT")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("CRTCD")) Then
            lblCRTCD.Text = _Datatble.Rows(0)("CRTCD")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("UPDDT")) Then
            lblUpddt.Text = _Datatble.Rows(0)("UPDDT")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("UPDCD")) Then
            lblUPDCD.Text = _Datatble.Rows(0)("UPDCD")
        End If

        If Not IsDBNull(_Datatble.Rows(0)("em_surname")) Then
            lblemSurname.Text = _Datatble.Rows(0)("em_surname")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("Gua_name")) Then
            lblGuaName.Text = _Datatble.Rows(0)("Gua_name")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("gua_tel")) Then
            lblgua_tel.Text = _Datatble.Rows(0)("gua_tel")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("gua_add1")) Then
            lblGuaAddressLine1.Text = _Datatble.Rows(0)("gua_add1")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("gua_add2")) Then
            lblGuaAddressLine2.Text = _Datatble.Rows(0)("gua_add2")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("gua_zip")) Then
            lblGuaZipCode.Text = _Datatble.Rows(0)("gua_zip")
        End If
        If Not IsDBNull(_Datatble.Rows(0)("gua_email")) Then
            lblGuaEmailID.Text = _Datatble.Rows(0)("gua_email")
        End If


        If Not IsDBNull(_Datatble.Rows(0)("hire_date")) Then
            lblHireDate.Text = _Datatble.Rows(0)("hire_date")
        End If
        'If Not IsDBNull(_Datatble.Rows(0)("dep_date")) Then
        '    lblDepDate.Text = _Datatble.Rows(0)("dep_date")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("class")) Then
        '    lblClass.Text = _Datatble.Rows(0)("class")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("position")) Then
        '    lblPosition.Text = _Datatble.Rows(0)("position")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("work_location")) Then
        '    lblWorkLocation.Text = _Datatble.Rows(0)("work_location")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("comm_time")) Then
        '    lblTime.Text = _Datatble.Rows(0)("comm_time").ToString
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("high_date1")) Then
        '    lblHigherDate1.Text = _Datatble.Rows(0)("high_date1")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("high_date2")) Then
        '    lblHigherDate2.Text = _Datatble.Rows(0)("high_date2")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("high_name")) Then
        '    lblHigherName.Text = _Datatble.Rows(0)("high_name")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("uni_date1")) Then
        '    lblunidate1.Text = _Datatble.Rows(0)("uni_date1")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("uni_date2")) Then
        '    lblunidate2.Text = _Datatble.Rows(0)("uni_date2")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("uni_name")) Then
        '    lbluni_name.Text = _Datatble.Rows(0)("uni_name")
        'End If


        'If Not IsDBNull(_Datatble.Rows(0)("emp_h1")) Then
        '    lblEmployeeh1.Text = _Datatble.Rows(0)("emp_h1")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("emp_h2")) Then
        '    lblEmployeeh2.Text = _Datatble.Rows(0)("emp_h2")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("emp_name1")) Then
        '    lblEmployeeName1.Text = _Datatble.Rows(0)("emp_name1")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("emp_h3")) Then
        '    lblEmployeeh3.Text = _Datatble.Rows(0)("emp_h3")
        'End If

        'If Not IsDBNull(_Datatble.Rows(0)("emp_h4")) Then
        '    lblEmployeeH4.Text = _Datatble.Rows(0)("emp_h4")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("emp_name2")) Then
        '    lblEmployeeName2.Text = _Datatble.Rows(0)("emp_name2")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("qua_name1")) Then
        '    lblQUAName1.Text = _Datatble.Rows(0)("qua_name1")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("qua_name2")) Then
        '    lblQUAName2.Text = _Datatble.Rows(0)("qua_name2")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("qua_name3")) Then
        '    lblQUAName3.Text = _Datatble.Rows(0)("qua_name3")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("qua_date1")) Then
        '    lblDate.Text = _Datatble.Rows(0)("qua_date1")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("qua_date2")) Then
        '    lblQUADate2.Text = _Datatble.Rows(0)("qua_date2")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("qua_date3")) Then
        '    lblQUADate3.Text = _Datatble.Rows(0)("qua_date3")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("paid_h1")) Then
        '    lblPaidH1.Text = _Datatble.Rows(0)("paid_h1")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("paid_h2")) Then
        '    lblPaidH2.Text = _Datatble.Rows(0)("paid_h2")
        'End If
        'If Not IsDBNull(_Datatble.Rows(0)("reg_work_time")) Then
        '    lblWorkTime.Text = _Datatble.Rows(0)("reg_work_time")
        'End If

        ''btnUpload.Visible = False
        'btnEdit.Visible = True
        ''filename.Visible = False
        ''Textfilename.Visible = True
        'btnAdd.Visible = False
        'GridSetupUser.Visible = False
        'AddUser.Visible = True

        'Header.Text = "User Management-Edit"

    End Sub


End Class