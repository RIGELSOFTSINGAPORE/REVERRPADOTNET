Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection

Public Class Apple_Dashboard
    Inherits System.Web.UI.Page
    Dim clsSet As New Class_money
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If
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


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        '''''''''''''''''''''''''GridViewBind()

        txtFrom.Text = Trim(txtFrom.Text)
        txtTo.Text = Trim(txtTo.Text)


        Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
        Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
        Dim shipCode As String = Session("ship_code")
        If shipCode = "" Then
            Response.Redirect("Login.aspx")
        End If
        _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode


        _AppleQmvOrdModel.DateFrom = txtFrom.Text
        _AppleQmvOrdModel.DateTo = txtTo.Text




        Dim dtAppleQmv As DataTable = _AppleQmvOrdControl.SelectSummary(_AppleQmvOrdModel)
        If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then
        Else

            If Not IsDBNull(dtAppleQmv.Rows(0)("GeneratedPo")) Then
                lblGeneratePo.Text = dtAppleQmv.Rows(0)("GeneratedPo")
            Else
                lblGeneratePo.Text = 0
            End If

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


            lblTotalToken.Text = Val(lblTotalToken.Text) + Val(lblPickupToken.Text)




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
                lblDeliveredTotal.Text = clsSet.setINR(dtAppleQmv.Rows(0)("DeliveredTotal"))
            Else
                lblDeliveredTotal.Text = 0
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourIWCash")) Then
                lblLabourIWCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourIWCash"))
            Else
                lblLabourIWCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourIWCard")) Then
                lblLabourIWCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourIWCard"))
            Else
                lblLabourIWCard.Text = "0.00"
            End If

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

            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourTotalCash")) Then
                lblLabourTotalCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourTotalCash"))
            Else
                lblLabourTotalCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("LabourTotalCard")) Then
                lblLabourTotalCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LabourTotalCard"))
            Else
                lblLabourTotalCard.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsIWCash")) Then
                lblPartsIWCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsIWCash"))
            Else
                lblPartsIWCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsIWCard")) Then
                lblPartsIWCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsIWCard"))
            Else
                lblPartsIWCard.Text = "0.00"
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

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsTotalCash")) Then
                lblPartsTotalCash.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsTotalCash"))
            Else
                lblPartsTotalCash.Text = "0.00"
            End If

            If Not IsDBNull(dtAppleQmv.Rows(0)("PartsTotalCard")) Then
                lblPartsTotalCard.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PartsTotalCard"))
            Else
                lblPartsTotalCard.Text = "0.00"
            End If







        End If


    End Sub

End Class