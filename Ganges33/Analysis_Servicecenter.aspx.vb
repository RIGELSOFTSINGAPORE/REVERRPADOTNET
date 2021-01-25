Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Web.UI.WebControls
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Admin
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
            ' Dim MuserUserid As String = Convert.ToString(Request.QueryString("UserId"))
            GetUserDetails()
        End If
    End Sub

    Private Sub GetUserDetails()

        Dim MuserUserid As String = Convert.ToString(Request.QueryString("UserId"))

        Dim MUsermodel As New MUserModel
        Dim MUsercontrol As New MUserControl
        MUsermodel.UserId = MuserUserid
        'ID.Text = Index


        Dim _Datatble As DataTable = MUsercontrol.ViewMUserInfo(MUsermodel)
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


        If Not IsDBNull(_Datatble.Rows(0)("mid_name")) Then
            lblMiddleName.Text = _Datatble.Rows(0)("mid_name")
        End If
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