Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection


Imports iFont = iTextSharp.text.Font
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.Font.FontFamily
Public Class Apple_Labour_Create
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            ClearTextbox()

            'Load Labor DropDownlist.
            'Dim _AppleLabourModel As AppleLabourModel = New AppleLabourModel()
            'Dim _AppleLabourControl As AppleLabourControl = New AppleLabourControl()
            'Dim dtAppleLabour As DataTable = _AppleLabourControl.SelectLabourAll(_AppleLabourModel)
            'If (dtAppleLabour Is Nothing) Or (dtAppleLabour.Rows.Count = 0) Then

            'Else
            '    'Dim dr As DataRow
            '    'dr = dtAppleLabour.NewRow()
            '    'dr(0) = "--Select--"
            '    'dr(1) = "-1"
            '    'dtAppleLabour.Rows.InsertAt(dr, 0)
            '    ''  drpLabourAmount.Items.Add("--Select--")
            '    'drpLabourAmount.DataTextField = "LABOUR_DESCRIPTION"
            '    'drpLabourAmount.DataValueField = "UNQ_NO"

            '    'drpLabourAmount.DataSource = dtAppleLabour
            '    'drpLabourAmount.DataBind()
            'End If

            Dim PoNo As String = ""
            Dim GNo As String = ""
            PoNo = Request.QueryString("UNQ_NO")
            '  GNo = Request.QueryString("GNo")

            If (Trim(PoNo) = "") Then
                'pass

            Else

                Dim _AppleLabourModel As AppleLabourModel = New AppleLabourModel()
                Dim _AppleLabourControl As AppleLabourControl = New AppleLabourControl()
                _AppleLabourModel.UNQ_NO = PoNo

                Dim dtAppleQmv As DataTable = _AppleLabourControl.Selectdetails(_AppleLabourModel)

                If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then
                    '  Call showMsg("The corporate number does not exist (" & txtCorpNumberEdit.Text.Trim & ") !!!")
                    'Exit Sub
                Else

                    If Not IsDBNull(dtAppleQmv.Rows(0)("UPLOAD_USER")) Then
                        txtUploadUser.Text = dtAppleQmv.Rows(0)("UPLOAD_USER")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("UPLOAD_DATE")) Then
                        txtUploadDate.Text = dtAppleQmv.Rows(0)("UPLOAD_DATE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("SHIP_TO_BRANCH_CODE")) Then
                        txtShiptobranchcode.Text = dtAppleQmv.Rows(0)("SHIP_TO_BRANCH_CODE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_CODE")) Then
                        txtLabourcode.Text = dtAppleQmv.Rows(0)("LABOUR_CODE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("SHIP_TO_BRANCH")) Then
                        txtShiptobranch.Text = dtAppleQmv.Rows(0)("SHIP_TO_BRANCH")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_TYPE")) Then
                        txtLabourtype.Text = dtAppleQmv.Rows(0)("LABOUR_TYPE")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_DESCRIPTION")) Then
                        txtLabourdescription.Text = dtAppleQmv.Rows(0)("LABOUR_DESCRIPTION")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_DETAILS")) Then
                        txtLabourdetails.Text = dtAppleQmv.Rows(0)("LABOUR_DETAILS")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("AMOUNT_100")) Then
                        txtAmount100.Text = dtAppleQmv.Rows(0)("AMOUNT_100")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("AMOUNT_150")) Then
                        txtAmount150.Text = dtAppleQmv.Rows(0)("AMOUNT_150")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("AMOUNT_170")) Then
                        txtAmount170.Text = dtAppleQmv.Rows(0)("AMOUNT_170")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("AMOUNT_180")) Then
                        txtAmount180.Text = dtAppleQmv.Rows(0)("AMOUNT_180")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("HSN_SAC")) Then
                        txtHSNSAC.Text = dtAppleQmv.Rows(0)("HSN_SAC")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("IP_ADDRESS")) Then
                        txtIPAddress.Text = dtAppleQmv.Rows(0)("IP_ADDRESS")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("FILE_NAME")) Then
                        txtFileName.Text = dtAppleQmv.Rows(0)("FILE_NAME")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("SRC_FILE_NAME")) Then
                        txtSRCFilename.Text = dtAppleQmv.Rows(0)("SRC_FILE_NAME")
                    End If




                End If
                ' servicedrop()
            End If
        End If
    End Sub


    Sub ClearTextbox()
        txtAmount100.Text = ""
        txtAmount150.Text = ""
        txtAmount170.Text = ""
        txtAmount180.Text = ""
        txtFileName.Text = ""
        txtHSNSAC.Text = ""
        txtIPAddress.Text = ""
        txtLabourdescription.Text = ""
        txtLabourdetails.Text = ""
        ' txtStateCode.Text = ""
        txtLabourtype.Text = ""
        txtShiptobranch.Text = ""
        txtShiptobranchcode.Text = ""
        txtSRCFilename.Text = ""
        txtUploadDate.Text = ""
        txtUploadUser.Text = ""

    End Sub

    Private Sub create_Click(sender As Object, e As EventArgs) Handles create.Click
        Dim _AppleLabourModel As AppleLabourModel = New AppleLabourModel()
        Dim _AppleLabourControl As AppleLabourControl = New AppleLabourControl()
        _AppleLabourModel.AMOUNT_100 = txtAmount100.Text
        _AppleLabourModel.AMOUNT_150 = txtAmount150.Text
        _AppleLabourModel.AMOUNT_170 = txtAmount170.Text
        _AppleLabourModel.AMOUNT_180 = txtAmount180.Text
        _AppleLabourModel.FILE_NAME = txtFileName.Text
        _AppleLabourModel.HSN_SAC = txtHSNSAC.Text
        _AppleLabourModel.IP_ADDRESS = txtIPAddress.Text
        _AppleLabourModel.LABOUR_DESCRIPTION = txtLabourdescription.Text
        _AppleLabourModel.LABOUR_DETAILS = txtLabourdetails.Text
        _AppleLabourModel.LABOUR_TYPE = txtLabourtype.Text
        _AppleLabourModel.LABOUR_CODE = txtLabourcode.Text
        _AppleLabourModel.SHIP_TO_BRANCH = txtShiptobranch.Text
        _AppleLabourModel.SHIP_TO_BRANCH_CODE = txtShiptobranchcode.Text
        _AppleLabourModel.SRC_FILE_NAME = txtSRCFilename.Text
        _AppleLabourModel.LABOUR_CODE = txtLabourcode.Text
        _AppleLabourModel.UNQ_NO = Request.QueryString("UNQ_NO")


        Dim blStatus As Boolean = False

        blStatus = _AppleLabourControl.AddQmvOrd_parts(_AppleLabourModel)

    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Response.Redirect("Apple_Labour_search.aspx")
    End Sub
End Class