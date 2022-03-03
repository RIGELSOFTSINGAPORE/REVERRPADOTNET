
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


Public Class Apple_Customer_Information
    Inherits System.Web.UI.Page
    Dim clsSet As New Class_money
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




        ''Enable / Disable of Shipping address is same as billing address
        Call EnableDisableShip()



        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If


            ClearTextbox()

            'Load Labor DropDownlist.
            Dim _AppleLabourModel As AppleLabourModel = New AppleLabourModel()
            Dim _AppleLabourControl As AppleLabourControl = New AppleLabourControl()
            Dim dtAppleLabour As DataTable = _AppleLabourControl.SelectLabourAll(_AppleLabourModel)
            If (dtAppleLabour Is Nothing) Or (dtAppleLabour.Rows.Count = 0) Then

            Else
                Dim dr As DataRow
                dr = dtAppleLabour.NewRow()
                dr(0) = "--Select--"
                dr(1) = "-1"
                dtAppleLabour.Rows.InsertAt(dr, 0)
                '  drpLabourAmount.Items.Add("--Select--")
                drpLabourAmount.DataTextField = "LABOUR_DESCRIPTION"
                drpLabourAmount.DataValueField = "UNQ_NO"

                drpLabourAmount.DataSource = dtAppleLabour
                drpLabourAmount.DataBind()
            End If

            Dim PoNo As String = ""
            Dim GNo As String = ""
            Dim Editable As String = ""
            PoNo = Request.QueryString("PoNo")
            GNo = Request.QueryString("GNo")
            Editable = Request.QueryString("E")

            If Editable = "yes" Then
                EditableAction()
            End If

            If (Trim(PoNo) = "") And (Trim(GNo) = "") Then
                'pass

            Else

                Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
                Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
                _AppleQmvOrdModel.PO_NO = PoNo
                _AppleQmvOrdModel.G_NO = GNo
                '''Dim ClaimNumExistCnt As String = _AppleQmvOrdControl.SelectPo(_AppleQmvOrdModel)
                ''''if No Datas found, then show the error message to the user
                '''If ClaimNumExistCnt = "0" Then
                '''    Call showMsg("The ASC Claim number does not exist / Incomplete (" & txtCorpNumberEdit.Text.Trim & ") !!!")
                '''    Exit Sub
                '''End If
                Dim dtAppleQmv As DataTable = _AppleQmvOrdControl.SelectPo(_AppleQmvOrdModel)

                If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then
                    '  Call showMsg("The corporate number does not exist (" & txtCorpNumberEdit.Text.Trim & ") !!!")
                    'Exit Sub
                    Dim _ApplePoModel As ApplePoModel = New ApplePoModel()
                    Dim _ApplePoControl As ApplePoControl = New ApplePoControl()
                    _ApplePoModel.PO_NO = PoNo
                    Dim blPoNoExist As DataTable = _ApplePoControl.PoNoExist(_ApplePoModel)
                    If (blPoNoExist Is Nothing) Or (blPoNoExist.Rows.Count = 0) Then
                        txtPoNo.Enabled = False
                        Call showMsg("PO No Doest Not Exist", "")
                        Exit Sub
                    Else
                        txtPoNo.Text = PoNo
                        txtPoNo.Enabled = False
                        If Not IsDBNull(blPoNoExist.Rows(0)("CRTDT")) Then
                            lblhidPoDate.Text = blPoNoExist.Rows(0)("CRTDT")
                        End If
                    End If


                Else

                    'ByDefault st Checkbox checked as false
                    chkst1.Checked = False
                    chkst2.Checked = False
                    chkst3.Checked = False
                    chkst4.Checked = False

                    drpSt1.SelectedItem.Value = 0
                    drpSt2.SelectedItem.Value = 0
                    drpSt3.SelectedItem.Value = 0
                    drpSt4.SelectedItem.Value = 0


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PO_NO")) Then
                        txtPoNo.Text = dtAppleQmv.Rows(0)("PO_NO")
                        txtPoNo.Enabled = False
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PO_DATE")) Then
                        lblhidPoDate.Text = dtAppleQmv.Rows(0)("PO_DATE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("G_NO")) Then
                        txtGNo.Text = dtAppleQmv.Rows(0)("G_NO")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("CUSTOMER_NAME")) Then
                        txtCustomerName.Text = dtAppleQmv.Rows(0)("CUSTOMER_NAME")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("ZIP_CODE")) Then
                        txtZip.Text = dtAppleQmv.Rows(0)("ZIP_CODE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("MOBLIE_PHONE")) Then
                        txtMobile.Text = dtAppleQmv.Rows(0)("MOBLIE_PHONE")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("TELEPHONE")) Then
                        txtTelephone.Text = dtAppleQmv.Rows(0)("TELEPHONE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("ADD_1")) Then
                        txtAddressLine1.Text = dtAppleQmv.Rows(0)("ADD_1")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("ADD_2")) Then
                        txtAddressLine2.Text = dtAppleQmv.Rows(0)("ADD_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("CITY")) Then
                        txtCity.Text = dtAppleQmv.Rows(0)("CITY")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("STATE")) Then
                        txtState.Text = dtAppleQmv.Rows(0)("STATE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("GSTIN")) Then
                        txtGstin.Text = dtAppleQmv.Rows(0)("GSTIN")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("E_MAIL")) Then
                        txtEmail.Text = dtAppleQmv.Rows(0)("E_MAIL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("IS_SHIP_DIFF")) Then
                        chkShipped.Checked = dtAppleQmv.Rows(0)("IS_SHIP_DIFF")
                        ''Enable / Disable of Shipping address is same as billing address
                        Call EnableDisableShip()
                        'If chkShipped.Checked Then
                        '    divShip.Visible = False
                        'Else
                        '    divShip.Visible = True
                        'End If


                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("CUSTOMER_NAME_SHIP")) Then
                        txtCustomerNameShip.Text = dtAppleQmv.Rows(0)("CUSTOMER_NAME_SHIP")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("ZIP_CODE_SHIP")) Then
                        txtZipShip.Text = dtAppleQmv.Rows(0)("ZIP_CODE_SHIP")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("MOBLIE_PHONE_SHIP")) Then
                        txtMobileShip.Text = dtAppleQmv.Rows(0)("MOBLIE_PHONE_SHIP")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("TELEPHONE_SHIP")) Then
                        txtTelephoneShip.Text = dtAppleQmv.Rows(0)("TELEPHONE_SHIP")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("ADD_1_SHIP")) Then
                        txtAddressLine1Ship.Text = dtAppleQmv.Rows(0)("ADD_1_SHIP")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("ADD_2_SHIP")) Then
                        txtAddressLine2Ship.Text = dtAppleQmv.Rows(0)("ADD_2_SHIP")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("CITY_SHIP")) Then
                        txtCityShip.Text = dtAppleQmv.Rows(0)("CITY_SHIP")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("STATE_SHIP")) Then
                        txtStateShip.Text = dtAppleQmv.Rows(0)("STATE_SHIP")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("E_MAIL_SHIP")) Then
                        txtEmailShip.Text = dtAppleQmv.Rows(0)("E_MAIL_SHIP")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("MODEL_NAME")) Then
                        txtModel.Text = dtAppleQmv.Rows(0)("MODEL_NAME")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRODUCT_NAME")) Then
                        txtProduct.Text = dtAppleQmv.Rows(0)("PRODUCT_NAME")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("SERIAL_NO")) Then
                        txtSerialNo.Text = dtAppleQmv.Rows(0)("SERIAL_NO")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("IMEI_1")) Then
                        txtImei1.Text = dtAppleQmv.Rows(0)("IMEI_1")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("IMEI_2")) Then
                        txtImei2.Text = dtAppleQmv.Rows(0)("IMEI_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("DATE_OF_PURCHASE")) Then
                        txtDateOfPurchase.Text = dtAppleQmv.Rows(0)("DATE_OF_PURCHASE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("SERVICE_TYPE")) Then
                        'drpServiceType.SelectedItem.Value = dtAppleQmv.Rows(0)("SERVICE_TYPE")
                        drpServiceType.SelectedIndex = drpServiceType.Items.IndexOf(drpServiceType.Items.FindByValue(dtAppleQmv.Rows(0)("SERVICE_TYPE")))
                        ChangeColor(dtAppleQmv.Rows(0)("SERVICE_TYPE"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("COMPTIA")) Then
                        txtCompTia.Text = dtAppleQmv.Rows(0)("COMPTIA")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("COMPTIA_MODIFIER")) Then
                        txtCompTiaModifier.Text = dtAppleQmv.Rows(0)("COMPTIA_MODIFIER")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("ACCESSORY_NOTE")) Then
                        txtAccessoryNote.Text = dtAppleQmv.Rows(0)("ACCESSORY_NOTE")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_NO1")) Then
                        txtPartNo1.Text = dtAppleQmv.Rows(0)("PART_NO1")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_NO2")) Then
                        txtPartNo2.Text = dtAppleQmv.Rows(0)("PART_NO2")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_NO3")) Then
                        txtPartNo3.Text = dtAppleQmv.Rows(0)("PART_NO3")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_NO4")) Then
                        txtPartNo4.Text = dtAppleQmv.Rows(0)("PART_NO4")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DETAIL_1")) Then
                        txtPartDetails1.Text = dtAppleQmv.Rows(0)("PART_DETAIL_1")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DETAIL_2")) Then
                        txtPartDetails2.Text = dtAppleQmv.Rows(0)("PART_DETAIL_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DETAIL_3")) Then
                        txtPartDetails3.Text = dtAppleQmv.Rows(0)("PART_DETAIL_3")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DETAIL_4")) Then
                        txtPartDetails4.Text = dtAppleQmv.Rows(0)("PART_DETAIL_4")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_QTY_1")) Then
                        txtQty1.Text = dtAppleQmv.Rows(0)("PART_QTY_1")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_QTY_2")) Then
                        txtQty2.Text = dtAppleQmv.Rows(0)("PART_QTY_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_QTY_3")) Then
                        txtQty3.Text = dtAppleQmv.Rows(0)("PART_QTY_3")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_QTY_4")) Then
                        txtQty4.Text = dtAppleQmv.Rows(0)("PART_QTY_4")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("SERIAL_STOCK_USED_1")) Then
                        chkSerialPart1.Checked = dtAppleQmv.Rows(0)("SERIAL_STOCK_USED_1")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("SERIAL_STOCK_USED_2")) Then
                        chkSerialPart2.Checked = dtAppleQmv.Rows(0)("SERIAL_STOCK_USED_2")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("SERIAL_STOCK_USED_3")) Then
                        chkSerialPart3.Checked = dtAppleQmv.Rows(0)("SERIAL_STOCK_USED_3")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("SERIAL_STOCK_USED_4")) Then
                        chkSerialPart4.Checked = dtAppleQmv.Rows(0)("SERIAL_STOCK_USED_4")
                    End If





                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_1")) Then
                        txtDiscount1.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_DISCOUNT_1"))
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_2")) Then
                        txtDiscount2.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_DISCOUNT_2"))
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_3")) Then
                        txtDiscount3.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_DISCOUNT_3"))
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_4")) Then
                        txtDiscount4.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_DISCOUNT_4"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_AMOUNT")) Then
                        drpLabourAmount.SelectedItem.Value = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_AMOUNT")) Then
                        txtLabourAmount.Text = dtAppleQmv.Rows(0)("LABOR_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_DETAIL")) Then
                        txtLabourDetail.Text = dtAppleQmv.Rows(0)("LABOR_DETAIL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_COST")) Then
                        txtLabourCost.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_COST"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_DISCOUNT")) Then
                        txtLabourDiscount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_DISCOUNT"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_SALES")) Then
                        txtLabourSales.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_SALES"))
                        'txtLabourSalesActual.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_SALES"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_SGST")) Then
                        txtLabourSGST.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_SGST"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_CGST")) Then
                        txtLabourCGST.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_CGST"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_IGST")) Then
                        txtLabourIGST.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_IGST"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_TOTAL")) Then
                        txtLabourTotal.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOR_TOTAL"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_1")) Then
                        txtCost1.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_1"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_2")) Then
                        txtCost2.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_2"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_3")) Then
                        txtCost3.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_3"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_4")) Then
                        txtCost4.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_4"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_SALES_1")) Then
                        txtSalesPrice1.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_SALES_1"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_SALES_2")) Then
                        txtSalesPrice2.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_SALES_2"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_SALES_3")) Then
                        txtSalesPrice3.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_SALES_3"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_SALES_4")) Then
                        txtSalesPrice4.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_SALES_4"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_1")) Then
                        txtSGST1.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_SGST_1"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_2")) Then
                        txtSGST2.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_SGST_2"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_3")) Then
                        txtSGST3.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_SGST_3"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_4")) Then
                        txtSGST4.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_SGST_4"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_1")) Then
                        txtCGST1.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_CGST_1"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_2")) Then
                        txtCGST2.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_CGST_2"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_3")) Then
                        txtCGST3.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_CGST_3"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_4")) Then
                        txtCGST4.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_CGST_4"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_1")) Then
                        txtIGST1.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_IGST_1"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_2")) Then
                        txtIGST2.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_IGST_2"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_3")) Then
                        txtIGST3.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_IGST_3"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART1_TAX")) Then
                        txtPart1Tax.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART1_TAX"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART2_TAX")) Then
                        txtPart2Tax.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART2_TAX"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART3_TAX")) Then
                        txtPart3Tax.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART3_TAX"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART4_TAX")) Then
                        txtPart4Tax.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART4_TAX"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOUR_TAX")) Then
                        txtLabourTax.Text = clsSet.setINR(dtAppleQmv.Rows(0)("LABOUR_TAX"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_TAX")) Then
                        txtOtherTax.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_TAX"))
                    End If





                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_4")) Then
                        txtIGST4.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_IGST_4"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL_1")) Then
                        txtTotal1.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_TOTAL_1"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL_2")) Then
                        txtTotal2.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_TOTAL_2"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL_3")) Then
                        txtTotal3.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_TOTAL_3"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL_4")) Then
                        txtTotal4.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_TOTAL_4"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_QTY_AMOUNT")) Then
                        txtPartQtyAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_QTY_AMOUNT"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_AMOUNT")) Then
                        txtPartCostAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_COST_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_AMOUNT")) Then
                        txtPartDiscountAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_DISCOUNT_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SALES_AMOUNT")) Then
                        txtPartSalesAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_SALES_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_AMOUNT")) Then
                        txtPartSGSTAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_SGST_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_AMOUNT")) Then
                        txtPartCGSTAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_CGST_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_AMOUNT")) Then
                        txtPartIGSTAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_IGST_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL")) Then
                        txtPartTotal.Text = clsSet.setINR(dtAppleQmv.Rows(0)("PART_TOTAL"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_QTY_AMOUNT")) Then
                        txtOtherQtyAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_QTY_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_DETAIL")) Then
                        txtOtherDetail.Text = dtAppleQmv.Rows(0)("OTHER_DETAIL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_COST")) Then
                        txtOtherCost.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_COST"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_DISCOUNT")) Then
                        txtOtherDiscount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_DISCOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_SALES")) Then
                        txtOtherSales.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_SALES"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_SGST")) Then
                        txtOtherSGST.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_SGST"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_CGST")) Then
                        txtOtherCGST.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_CGST"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_IGST")) Then
                        txtOtherIGST.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_IGST"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_TOTAL")) Then
                        txtOtherTotal.Text = clsSet.setINR(dtAppleQmv.Rows(0)("OTHER_TOTAL"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_QTY")) Then
                        txtTotalQty.Text = dtAppleQmv.Rows(0)("TOTAL_QTY")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_COST_AMOUNT")) Then
                        txtTotalCostAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("TOTAL_COST_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_DISCOUNT_AMOUNT")) Then
                        txtDiscountAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("TOTAL_DISCOUNT_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_SALES_AMOUNT")) Then
                        txtTotalSalesAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("TOTAL_SALES_AMOUNT"))
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_SGST_AMOUNT")) Then
                        txtTotalSGSTAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("TOTAL_SGST_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_CGST_AMOUNT")) Then
                        txtTotalCGSTAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("TOTAL_CGST_AMOUNT"))
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_IGST_AMOUNT")) Then
                        txtTotalIGSTAmount.Text = clsSet.setINR(dtAppleQmv.Rows(0)("TOTAL_IGST_AMOUNT"))
                    End If
                    Dim TotalAmount As Decimal = 0.00
                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_AMOUNT")) Then
                        TotalAmount = dtAppleQmv.Rows(0)("TOTAL_AMOUNT")
                        txtTotalAmount.Text = clsSet.setINR(TotalAmount)
                        'Dim TotValue As Double = 0.00
                        'If Trim(txtTotalAmount.Text) <> "" Then
                        '    'Validate Total Amount decimal 
                        '    If Decimal.TryParse(txtTotalAmount.Text, TotValue) Then
                        '        txtTotalAmount.Text = Math.Round(TotValue, MidpointRounding.ToEven) ' MidpointRounding.ToEven
                        '    Else
                        '        'Call showMsg("Total Amount is invalid ", "")
                        '        '  Exit Sub
                        '    End If
                        'End If
                    End If




                    If Not IsDBNull(dtAppleQmv.Rows(0)("COMP_STATUS")) Then
                        'drpCompStatus.SelectedItem.Text = dtAppleQmv.Rows(0)("COMP_STATUS")
                        drpCompStatus.SelectedIndex = drpCompStatus.Items.IndexOf(drpCompStatus.Items.FindByValue(dtAppleQmv.Rows(0)("COMP_STATUS")))


                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("COMP_DATE")) Then
                        txtCompDate.Text = dtAppleQmv.Rows(0)("COMP_DATE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("DENOMINATION")) Then
                        'txtDenomination.Text = dtAppleQmv.Rows(0)("DENOMINATION")
                        drpDenomination.SelectedIndex = drpDenomination.Items.IndexOf(drpDenomination.Items.FindByValue(dtAppleQmv.Rows(0)("DENOMINATION")))

                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("ESTIMATE_DATE")) Then
                        txtEstimatedDate.Text = dtAppleQmv.Rows(0)("ESTIMATE_DATE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("GSX_CLOSE_DATE")) Then
                        txtGSXCloseDate.Text = dtAppleQmv.Rows(0)("GSX_CLOSE_DATE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("INVOICE_NOTE")) Then
                        txtInvoiceNote.Text = dtAppleQmv.Rows(0)("INVOICE_NOTE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("GSX_NOTE")) Then
                        txtGsxNote.Text = dtAppleQmv.Rows(0)("GSX_NOTE")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("UPDCD")) Then
                        txtLastUser.Text = dtAppleQmv.Rows(0)("UPDCD")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("UPDDT")) Then
                        txtLastUpdate.Text = dtAppleQmv.Rows(0)("UPDDT")
                        If Len(txtLastUpdate.Text) >= 10 Then
                            txtLastUpdate.Text = Left(txtLastUpdate.Text, 10)
                        End If
                        'txtCompDate
                    End If

                    Dim PRICE_OPTIONS As Boolean

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTIONS_1_TYPE")) Then
                        'PRICE_OPTIONS = dtAppleQmv.Rows(0)("PRICE_OPTIONS_1")
                        'chkst1.Checked = PRICE_OPTIONS
                        drpSt1.SelectedIndex = drpSt1.Items.IndexOf(drpSt1.Items.FindByValue(dtAppleQmv.Rows(0)("PRICE_OPTIONS_1_TYPE")))
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTIONS_2_TYPE")) Then
                        'PRICE_OPTIONS = dtAppleQmv.Rows(0)("PRICE_OPTIONS_2")
                        'chkst2.Checked = PRICE_OPTIONS
                        drpSt2.SelectedIndex = drpSt2.Items.IndexOf(drpSt2.Items.FindByValue(dtAppleQmv.Rows(0)("PRICE_OPTIONS_2_TYPE")))
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTIONS_3_TYPE")) Then
                        'PRICE_OPTIONS = dtAppleQmv.Rows(0)("PRICE_OPTIONS_3")
                        ' chkst3.Checked = PRICE_OPTIONS
                        drpSt3.SelectedIndex = drpSt3.Items.IndexOf(drpSt3.Items.FindByValue(dtAppleQmv.Rows(0)("PRICE_OPTIONS_3_TYPE")))
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTIONS_4_TYPE")) Then
                        'PRICE_OPTIONS = dtAppleQmv.Rows(0)("PRICE_OPTIONS_4")
                        'chkst4.Checked = PRICE_OPTIONS
                        drpSt4.SelectedIndex = drpSt4.Items.IndexOf(drpSt4.Items.FindByValue(dtAppleQmv.Rows(0)("PRICE_OPTIONS_4_TYPE")))
                    End If


                    Dim OPT As Boolean
                    If Not IsDBNull(dtAppleQmv.Rows(0)("TRANSFER_REPAIR_CENTER")) Then
                        OPT = dtAppleQmv.Rows(0)("TRANSFER_REPAIR_CENTER")
                        chkRepairCenter.Checked = OPT
                        If OPT Then
                            chkRepairCenter.Text = "<font color=red><b>Currently being transferred to the repair center</b></font>"
                        End If
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("ACTION_TAKEN")) Then
                        txtActionTaken.Text = dtAppleQmv.Rows(0)("ACTION_TAKEN")
                    End If



                    If Not IsDBNull(dtAppleQmv.Rows(0)("RECEPTION")) Then
                        OPT = dtAppleQmv.Rows(0)("RECEPTION")
                        chkReception.Checked = OPT
                        If OPT Then
                            chkReception.Text = "<font color=green>Reception</font>"
                        Else
                            chkReception.Text = "<font color=red>Reception</font>"
                        End If
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("INTERNAL_INSPECTION")) Then
                        OPT = dtAppleQmv.Rows(0)("INTERNAL_INSPECTION")
                        chkInternalInspection.Checked = OPT
                        If OPT Then
                            chkInternalInspection.Text = "<font color=green>Internal inspection</font>"
                        Else
                            chkInternalInspection.Text = "<font color=red>Internal inspection</font>"
                        End If

                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("SIGNATURE_INSERVICE_ESTIMATE")) Then
                        OPT = dtAppleQmv.Rows(0)("SIGNATURE_INSERVICE_ESTIMATE")
                        chkSignatureInServiceEstimate.Checked = OPT
                        If OPT Then
                            chkSignatureInServiceEstimate.Text = "<font color=green>Signature in service estimate</font>"
                        Else
                            chkSignatureInServiceEstimate.Text = "<font color=red>Signature in service estimate</font>"
                        End If

                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("WHOLE_SERVICE_FEE_ADR_COLLECTION")) Then
                        OPT = dtAppleQmv.Rows(0)("WHOLE_SERVICE_FEE_ADR_COLLECTION")
                        chkWholeServiceFeeCollection.Checked = OPT
                        If OPT Then
                            chkWholeServiceFeeCollection.Text = "<font color=green>Whole service fee(or ADR) collection</font>"
                        Else
                            chkWholeServiceFeeCollection.Text = "<font color=red>Whole service fee(or ADR) collection</font>"
                        End If

                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("GSX_ORDER")) Then
                        OPT = dtAppleQmv.Rows(0)("GSX_ORDER")
                        chkGsxOrder.Checked = OPT
                        If OPT Then
                            chkGsxOrder.Text = "<font color=green>GSX Order</font>"
                        Else
                            chkGsxOrder.Text = "<font color=red>GSX Order</font>"
                        End If

                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("REPAIR")) Then
                        OPT = dtAppleQmv.Rows(0)("REPAIR")
                        chkRepair.Checked = OPT
                        If OPT Then
                            chkRepair.Text = "<font color=green>Repair</font>"
                        Else
                            chkRepair.Text = "<font color=red>Repair</font>"
                        End If

                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("REMAINING_AMOUNT_COLLECTION")) Then
                        OPT = dtAppleQmv.Rows(0)("REMAINING_AMOUNT_COLLECTION")
                        chkRemainingAmountCollection.Checked = OPT
                        If OPT Then
                            chkRemainingAmountCollection.Text = "<font color=green>Remaining amount collection</font>"
                        Else
                            chkRemainingAmountCollection.Text = "<font color=red>Remaining amount collection</font>"
                        End If

                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("LOANER_COLLECTION")) Then
                        OPT = dtAppleQmv.Rows(0)("LOANER_COLLECTION")
                        chkLoanerCollection.Checked = OPT
                        If OPT Then
                            chkLoanerCollection.Text = "<font color=green>Loaner collection </font>"
                        Else
                            chkLoanerCollection.Text = "<font color=red>Loaner collection </font>"
                        End If

                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("SEVICE_REPORT")) Then
                        OPT = dtAppleQmv.Rows(0)("SEVICE_REPORT")
                        chkServiceReport.Checked = OPT
                        If OPT Then
                            chkServiceReport.Text = "<font color=green>Sevice report </font>"
                        Else
                            chkServiceReport.Text = "<font color=red>Sevice report</font>"
                        End If

                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("TAX_INVOICE")) Then
                        OPT = dtAppleQmv.Rows(0)("TAX_INVOICE")
                        chkTaxInvoice.Checked = OPT
                        If OPT Then
                            chkTaxInvoice.Text = "<font color=green>Tax Invoice</font>"
                        Else
                            chkTaxInvoice.Text = "<font color=red>Tax Invoice</font>"
                        End If

                    End If






                    Dim ADVANCE_PAYMENT As Decimal = 0.00
                    If Not IsDBNull(dtAppleQmv.Rows(0)("ADVANCE_PAYMENT")) Then
                        ADVANCE_PAYMENT = dtAppleQmv.Rows(0)("ADVANCE_PAYMENT")
                        txtAdvance.Text = clsSet.setINR(ADVANCE_PAYMENT)
                        txtBalance.Text = clsSet.setINR(TotalAmount - ADVANCE_PAYMENT)
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("DELIVERY_DATE")) Then
                        txtDeliveryDate.Text = dtAppleQmv.Rows(0)("DELIVERY_DATE")
                        DisableAction()
                        Btninvoice.Enabled = True
                        ' Btndiagonis.Enabled = True
                    Else
                        If drpCompStatus.SelectedItem.Value = "1" Then ' Complete
                            DisableAction()
                            txtDeliveryDate.Enabled = True
                            btnDelivered.Enabled = True
                            drpDenomination.Enabled = True
                            Btninvoice.Enabled = True
                            'Btndiagonis.Enabled = True
                            btnEstimate.Enabled = True
                        ElseIf drpCompStatus.SelectedItem.Value = "2" Then 'Reception only
                            DisableAction()
                        End If
                    End If



                End If
                servicedrop()
            End If
        End If




    End Sub


    Sub EnableDisableShip()
        If chkShipped.Checked Then
            'divShip.Visible = False
            txtCustomerNameShip.Enabled = False
            txtAddressLine1Ship.Enabled = False
            txtAddressLine2Ship.Enabled = False
            txtCityShip.Enabled = False
            txtStateShip.Enabled = False
            txtZipShip.Enabled = False
            txtEmailShip.Enabled = False
            txtTelephoneShip.Enabled = False
            txtMobileShip.Enabled = False


        Else
            ' divShip.Visible = True
            txtCustomerNameShip.Enabled = True
            txtAddressLine1Ship.Enabled = True
            txtAddressLine2Ship.Enabled = True
            txtCityShip.Enabled = True
            txtStateShip.Enabled = True
            txtZipShip.Enabled = True
            txtEmailShip.Enabled = True
            txtTelephoneShip.Enabled = True
            txtMobileShip.Enabled = True
        End If
    End Sub


    Sub EditableAction()
        txtLabourAmount.Enabled = True
        txtLabourHsnSacCode.Enabled = True
        txtLabourCost.Enabled = True
        txtLabourDiscount.Enabled = True
        ' txtLabourSales.Enabled = True
        txtLabourTax.Enabled = True
        txtPartNo1.Enabled = True
        txtQty1.Enabled = True
        txtPartDetails1.Enabled = True
        txtHsnSac1.Enabled = True
        txtCost1.Enabled = True
        txtDiscount1.Enabled = True
        'txtSalesPrice1.Enabled = True
        txtPart1Tax.Enabled = True
        txtPartNo2.Enabled = True
        txtQty2.Enabled = True
        txtPartDetails2.Enabled = True
        txtHsnSac2.Enabled = True
        txtCost2.Enabled = True
        txtDiscount2.Enabled = True
        'txtSalesPrice2.Enabled = True
        txtPart2Tax.Enabled = True
        txtPartNo3.Enabled = True
        txtQty3.Enabled = True
        txtPartDetails3.Enabled = True
        txtHsnSac3.Enabled = True
        txtCost3.Enabled = True
        txtDiscount3.Enabled = True
        'txtSalesPrice3.Enabled = True
        txtPart3Tax.Enabled = True
        txtPartNo4.Enabled = True
        txtQty4.Enabled = True
        txtPartDetails4.Enabled = True
        txtHsnSac4.Enabled = True
        txtCost4.Enabled = True
        txtDiscount4.Enabled = True
        'txtSalesPrice4.Enabled = True
        txtPart4Tax.Enabled = True


        txtOtherTax.Enabled = True

        chkSerialPart1.Enabled = True
        chkSerialPart2.Enabled = True
        chkSerialPart3.Enabled = True
        chkSerialPart4.Enabled = True

    End Sub


    Sub DisableAction()
        txtPoNo.Enabled=False 
txtGNo.Enabled=False 
drpServiceType.Enabled=False 
txtInvoiceNote.Enabled=False 
txtGsxNote.Enabled=False 
txtCustomerName.Enabled=False 
txtAddressLine1.Enabled=False 
txtAddressLine2.Enabled=False 
txtCity.Enabled=False 
txtState.Enabled=False 
txtZip.Enabled=False 
txtEmail.Enabled=False 
txtTelephone.Enabled=False
        txtMobile.Enabled = False


        txtCustomerNameShip.Enabled = False
        txtAddressLine1Ship.Enabled = False
        txtAddressLine2Ship.Enabled = False
        txtCityShip.Enabled = False
        txtStateShip.Enabled = False
        txtZipShip.Enabled = False
        txtEmailShip.Enabled = False
        txtTelephoneShip.Enabled = False
        txtMobileShip.Enabled = False
        chkShipped.Enabled = False


        txtGstin.Enabled=False
        txtProduct.Enabled = False
        txtModel.Enabled = False
        txtSerialNo.Enabled=False 
txtImei1.Enabled=False 
txtImei2.Enabled=False 
txtDateOfPurchase.Enabled=False 
txtCompTia.Enabled=False
        txtCompTiaModifier.Enabled = False

        txtAccessoryNote.Enabled = False

        btnCalculation.Enabled = False
        drpLabourAmount.Enabled = False
        txtLabourAmount.Enabled = False
        txtLabourAmountTemp.Enabled = False
        txtLabourDetail.Enabled = False
        txtLabourHsnSacCode.Enabled = False
        txtLabourCost.Enabled = False
        txtLabourDiscount.Enabled = False
        txtLabourSales.Enabled = False
        txtLabourTax.Enabled = False
        txtLabourSGST.Enabled = False
        txtLabourCGST.Enabled = False
        txtLabourIGST.Enabled = False
        txtLabourTotal.Enabled = False
        txtPartNo1.Enabled = False
        txtQty1.Enabled = False
        chkst1.Enabled = False
        drpSt1.Enabled = False
        drpSt2.Enabled = False
        drpSt3.Enabled = False
        drpSt4.Enabled = False
        txtPartDetails1.Enabled = False
        txtHsnSac1.Enabled = False
        txtCost1.Enabled = False
        txtDiscount1.Enabled = False
        txtSalesPrice1.Enabled = False
        txtPart1Tax.Enabled = False
        txtSGST1.Enabled = False
        txtCGST1.Enabled = False
        txtIGST1.Enabled = False
        txtTotal1.Enabled = False
        txtPartNo2.Enabled = False
        txtQty2.Enabled = False
        chkst2.Enabled = False
        txtPartDetails2.Enabled = False
        txtHsnSac2.Enabled = False
        txtCost2.Enabled = False
        txtDiscount2.Enabled = False
        txtSalesPrice2.Enabled = False
        txtPart2Tax.Enabled = False
        txtSGST2.Enabled = False
        txtCGST2.Enabled = False
        txtIGST2.Enabled = False
        txtTotal2.Enabled = False
        txtPartNo3.Enabled = False
        txtQty3.Enabled = False
        chkst3.Enabled = False
        txtPartDetails3.Enabled = False
        txtHsnSac3.Enabled = False
        txtCost3.Enabled = False
        txtDiscount3.Enabled = False
        txtSalesPrice3.Enabled = False
        txtPart3Tax.Enabled = False
        txtSGST3.Enabled = False
        txtCGST3.Enabled = False
        txtIGST3.Enabled = False
        txtTotal3.Enabled = False
        txtPartNo4.Enabled = False
        txtQty4.Enabled = False
        chkst4.Enabled = False
        txtPartDetails4.Enabled = False
        txtHsnSac4.Enabled = False
        txtCost4.Enabled = False
        txtDiscount4.Enabled = False
        txtSalesPrice4.Enabled = False
        txtPart4Tax.Enabled = False
        txtSGST4.Enabled = False
        txtCGST4.Enabled = False
        txtIGST4.Enabled = False
        txtTotal4.Enabled = False
        txtPartQtyAmount.Enabled = False
        txtPartCostAmount.Enabled = False
        txtPartDiscountAmount.Enabled = False
        txtPartSalesAmount.Enabled = False
        txtPartSGSTAmount.Enabled = False
        txtPartCGSTAmount.Enabled = False
        txtPartIGSTAmount.Enabled = False
        txtPartTotal.Enabled = False
        txtOtherQtyAmount.Enabled = False
        txtOtherDetail.Enabled = False
        txtOtherCost.Enabled = False
        txtOtherDiscount.Enabled = False
        txtOtherSales.Enabled = False
        txtOtherTax.Enabled = False
        txtOtherSGST.Enabled = False
        txtOtherCGST.Enabled = False
        txtOtherIGST.Enabled = False
        txtOtherTotal.Enabled = False
        txtTotalQty.Enabled = False
        txtTotalCostAmount.Enabled = False
        txtDiscountAmount.Enabled = False
        txtTotalSalesAmount.Enabled = False
        txtTotalSGSTAmount.Enabled = False
        txtTotalCGSTAmount.Enabled = False
        txtTotalIGSTAmount.Enabled = False
        txtTotalAmount.Enabled = False
        txtAdvance.Enabled = False
        txtBalance.Enabled = False
        txtDeliveryDate.Enabled = False
        drpCompStatus.Enabled = False
        txtCompDate.Enabled = False
        txtLastUpdate.Enabled = False

        drpDenomination.Enabled = False
        txtLastUser.Enabled = False
        txtEstimatedDate.Enabled = False
        txtGSXCloseDate.Enabled = False
        btnDelivered.Enabled = False
        btnComplete.Enabled = False
        save2.Enabled = False
        save.Enabled = False
        Btninvoice.Enabled = False
        btnEstimate.Enabled = False
        'Btndiagonis.Enabled = False
        drpDenomination.Enabled = False


        chkRepairCenter.Enabled = False

        chkReception.Enabled = False
        chkInternalInspection.Enabled = False
        chkSignatureInServiceEstimate.Enabled = False
        chkWholeServiceFeeCollection.Enabled = False
        chkGsxOrder.Enabled = False
        chkRepair.Enabled = False
        chkRemainingAmountCollection.Enabled = False
        chkLoanerCollection.Enabled = False
        chkServiceReport.Enabled = False
        chkTaxInvoice.Enabled = False


        txtActionTaken.Enabled = False

        chkSerialPart1.Enabled = False
        chkSerialPart2.Enabled = False
        chkSerialPart3.Enabled = False
        chkSerialPart4.Enabled = False

    End Sub

    Sub ClearTextbox()
        txtPoNo.Text = ""
        txtGNo.Text = ""
        txtCustomerName.Text = ""
        txtZip.Text = ""
        txtMobile.Text = ""
        txtAddressLine1.Text = ""
        txtAddressLine2.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        'txtStateCode.Text = ""
        txtEmail.Text = ""
        txtTelephone.Text = ""

        txtCustomerNameShip.Text = ""
        txtZipShip.Text = ""
        txtMobileShip.Text = ""
        txtAddressLine1Ship.Text = ""
        txtAddressLine2Ship.Text = ""
        txtCityShip.Text = ""
        txtStateShip.Text = ""
        'txtStateCode.Text = ""
        txtEmailShip.Text = ""
        txtTelephoneShip.Text = ""
        txtMobileShip.Text = ""

        txtGstin.Text = ""
        txtProduct.Text = ""
        txtSerialNo.Text = ""
        txtImei1.Text = ""
        txtImei2.Text = ""
        txtDateOfPurchase.Text = ""
        'drpServiceType.Text = ""
        txtCompTia.Text = ""
        txtCompTiaModifier.Text = ""
        txtAccessoryNote.Text = ""
        'drpLabourAmount.Text = ""
        txtLabourAmount.Text = ""
        txtLabourDetail.Text = ""
        txtLabourHsnSacCode.Text = ""
        txtLabourCost.Text = ""
        txtLabourSales.Text = ""
        txtLabourTax.Text = ""
        txtLabourSGST.Text = ""
        txtLabourCGST.Text = ""
        txtLabourIGST.Text = ""
        txtLabourTotal.Text = ""
        txtPartNo1.Text = ""
        txtQty1.Text = ""
        txtPartDetails1.Text = ""
        txtHsnSac1.Text = ""
        txtCost1.Text = ""
        txtSalesPrice1.Text = ""
        txtPart1Tax.Text = ""
        txtSGST1.Text = ""
        txtCGST1.Text = ""
        txtIGST1.Text = ""
        txtTotal1.Text = ""
        txtPartNo2.Text = ""
        txtQty2.Text = ""
        txtPartDetails2.Text = ""
        txtHsnSac2.Text = ""
        txtCost2.Text = ""
        txtSalesPrice2.Text = ""
        txtPart2Tax.Text = ""
        txtSGST2.Text = ""
        txtCGST2.Text = ""
        txtIGST2.Text = ""
        txtTotal2.Text = ""
        txtPartNo3.Text = ""
        txtQty3.Text = ""
        txtPartDetails3.Text = ""
        txtHsnSac3.Text = ""
        txtCost3.Text = ""
        txtSalesPrice3.Text = ""
        txtPart3Tax.Text = ""
        txtSGST3.Text = ""
        txtCGST3.Text = ""
        txtIGST3.Text = ""
        txtTotal3.Text = ""
        txtPartNo4.Text = ""
        txtQty4.Text = ""
        txtPartDetails4.Text = ""
        txtHsnSac4.Text = ""
        txtCost4.Text = ""
        txtSalesPrice4.Text = ""
        txtPart4Tax.Text = ""
        txtSGST4.Text = ""
        txtCGST4.Text = ""
        txtIGST4.Text = ""
        txtTotal4.Text = ""
        txtPartQtyAmount.Text = ""
        txtPartCostAmount.Text = ""
        txtPartSalesAmount.Text = ""
        txtPartSGSTAmount.Text = ""
        txtPartCGSTAmount.Text = ""
        txtPartIGSTAmount.Text = ""
        txtPartTotal.Text = ""
        txtOtherQtyAmount.Text = ""
        txtOtherDetail.Text = ""
        txtOtherCost.Text = ""
        txtOtherSales.Text = ""
        txtOtherTax.Text = ""
        txtOtherSGST.Text = ""
        txtOtherCGST.Text = ""
        txtOtherIGST.Text = ""
        txtOtherTotal.Text = ""
        txtTotalQty.Text = ""
        txtTotalCostAmount.Text = ""
        txtTotalSalesAmount.Text = ""
        txtTotalSGSTAmount.Text = ""
        txtTotalCGSTAmount.Text = ""
        txtTotalIGSTAmount.Text = ""
        txtTotalAmount.Text = ""
        txtDeliveryDate.Text = ""
        '''drpCompStatus.Text = ""
        txtCompDate.Text = ""
        'txtDenomination.Text = ""
        txtLastUser.Text = ""
        txtEstimatedDate.Text = ""
        txtGSXCloseDate.Text = ""

        txtActionTaken.Text = ""



    End Sub

    Sub ChangeColor(ChangeClr As Integer)
        Select Case ChangeClr
            Case 0
                divCustomer.Attributes.Add("class", "card-header card-header-primary ")
                divcard.Attributes.CssStyle.Add("Background-Color", "")
            Case 1
                divCustomer.Attributes.Add("class", "InWarranty ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#eef8e9")
            Case 2
                divCustomer.Attributes.Add("class", "OutWarranty ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#03224905")
            Case 3
                divCustomer.Attributes.Add("class", "ApplecareProtechtion ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#fc261c1a")

            Case 4
                divCustomer.Attributes.Add("class", "Sales ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#EDC9AF")
            Case 5
                divCustomer.Attributes.Add("class", "Accessories")
                divcard.Attributes.CssStyle.Add("Background-Color", "#75e0d7")
        End Select

    End Sub
    Protected Sub btnEstimate_Click(sender As Object, e As EventArgs) Handles btnEstimate.Click
        'Call Estimate
        CalcEstimateSave("btnestimate")
    End Sub


    Sub CalcEstimateSave(srcFunction As String)
        'Modified on 20220128
        Dim strInventoryFlg As String = ""
        Try
            strInventoryFlg = ConfigurationManager.AppSettings("AppInv")
        Catch ex As Exception
        End Try
        Select Case UCase(Trim(strInventoryFlg))
            Case "YES"
                CalcEstimateSaveWithInventory(srcFunction)
            Case Else
                CalcEstimateSaveWithoutInventory(srcFunction)
        End Select

    End Sub

    Sub CalcEstimateSaveWithInventory(srcFunction As String)
        If (drpServiceType.SelectedItem.Value = "4") Or (drpServiceType.SelectedItem.Value = "5") Then
            If Trim(txtLabourAmount.Text) <> "" Then
                Call showMsg("Labour Is Not Allowed For Sales / Accessories", "")
                Exit Sub
            End If
            'Modified on 2021/06/08 Mandatory

            Dim strMandatoryText As String = ""

            txtCustomerName.Text = Trim(txtCustomerName.Text)
            txtAddressLine1.Text = Trim(txtAddressLine1.Text)
            txtAddressLine2.Text = Trim(txtAddressLine2.Text)
            txtCity.Text = Trim(txtCity.Text)
            txtState.Text = Trim(txtState.Text)
            txtStateShip.Text = Trim(txtStateShip.Text)
            txtEmail.Text = Trim(txtEmail.Text)
            txtMobile.Text = Trim(txtMobile.Text)
            txtGsxNote.Text = Trim(txtGsxNote.Text)





            If Len(Trim(txtCustomerName.Text)) < 3 Then
                strMandatoryText = "Customer Name <br>"
            End If
            If Len(Trim(txtAddressLine1.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "Address Line 1 <br>"
            End If
            'If Len(Trim(txtAddressLine2.Text)) < 3 Then
            '    strMandatoryText = "Address Line 2 <br>"
            'End If
            If Len(Trim(txtCity.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "City <br>"
            End If
            If Len(Trim(txtState.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "State <br>"
            End If
            If Len(Trim(txtZip.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "Postal Code <br>"
            End If

            'If Len(Trim(txtEmail.Text)) < 3 Then
            '    strMandatoryText = "Email ID <br>"
            'End If

            If Len(Trim(txtMobile.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "Mobile <br>"
            End If

            If Len(Trim(txtGsxNote.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "GSX Note <br>"
            End If


            Dim blSalesMadatory As Boolean = False
            If (Len(Trim(txtPartNo1.Text)) > 1) Then
                blSalesMadatory = True
            End If

            If blSalesMadatory = False Then
                If (Len(Trim(txtPartNo2.Text)) > 1) Then
                    blSalesMadatory = True
                End If
            End If
            If blSalesMadatory = False Then
                If (Len(Trim(txtPartNo3.Text)) > 1) Then
                    blSalesMadatory = True
                End If
            End If
            If blSalesMadatory = False Then
                If (Len(Trim(txtPartNo4.Text)) > 1) Then
                    blSalesMadatory = True
                End If
            End If
            If blSalesMadatory = False Then
                If (Len(Trim(txtOtherDetail.Text)) > 1) Then
                    blSalesMadatory = True
                End If
            End If

            If blSalesMadatory = False Then
                strMandatoryText = strMandatoryText & "Part Number is Empty <br>"
            End If


            If Len(strMandatoryText) > 3 Then
                'Call showMsg("The following is mandatory  " & strMandatoryText, "")
                'Exit Sub
                Call showMsg("The following field(s) are mandatory for Sales / Accessories ...<br><br>" & strMandatoryText, "")
                Exit Sub
            End If

        End If

        Dim strPartsSalesNotFound As String = ""
        Dim strStockUnavailable As String = ""

        If (srcFunction = "btncalc") Or (srcFunction = "btnestimate") Then
            If Trim(txtPoNo.Text) = "" Then
                Call showMsg("Po No is invalid ", "")
                Exit Sub
            End If

            Dim Editable As String = ""
            Editable = Request.QueryString("E")

            If Editable = "yes" Then
                EditableAction()
            End If

            Dim clsSet As New Class_money

            Dim blPriceCheckFailure As Boolean = False
            Dim FailureText As String = ""

            Dim blPartEntered As Boolean = False

            Dim Sgst As Decimal = 9.0
            Dim Igst As Decimal = 0.0
            Dim Cgst As Decimal = 9.0

            Dim Qty As Decimal = 0.00

            Dim PriceCost As Decimal = 0.00
            Dim Discount As Decimal = 0.00
            Dim SalesPrice As Decimal = 0.00

            Dim PartSgst As Decimal = 0.00
            Dim PartIgst As Decimal = 0.0
            Dim PartCgst As Decimal = 0.0
            Dim PartTotal As Decimal = 0.00


            Dim LabourCost As Decimal = 0.00
            Dim LabourDiscount As Decimal = 0.00
            Dim LabourSales As Decimal = 0.00
            Dim LabourSgst As Decimal = 0.00
            Dim LabourIgst As Decimal = 0.0
            Dim LabourCgst As Decimal = 0.0
            Dim LabourTotal As Decimal = 0.00
            Dim LabourTax As Decimal = 0.00

            Dim DefaultTax As Decimal = 9.0

            Dim Qtys As Decimal = 0.00
            Dim Discounts As Decimal = 0.00
            Dim SalesPrices As Decimal = 0.00
            Dim PartTax As Decimal = 0.00
            Dim PartDiscounts As Decimal = 0.00
            Dim PartSgsts As Decimal = 0.00
            Dim PartIgsts As Decimal = 0.00
            Dim PartCgsts As Decimal = 0.00
            Dim PartTotals As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00

            Dim tmpSalesPrice As Decimal = 0.00

            Dim dtApple As DataTable
            'Verify Labour Amount
            Dim strLabourValue As String = ""
            'strLabourValue = drpLabourAmount.SelectedItem.Value
            'If strLabourValue = "-1" Then
            '    'if LabourCost not entered 
            '    If (txtLabourCost.Text = "") Then 'And (txtLabourSales.Text = "")
            '        Call showMsg("Labour Price Not Selected or Not Entered In Labour Cost", "")
            '        Exit Sub
            '    End If
            '    'Validate Labour cost is decimal 
            '    If Decimal.TryParse(txtLabourCost.Text, LabourCost) Then
            '    Else
            '        Call showMsg("Labour cost is invalid ", "")
            '        Exit Sub
            '    End If



            'Empty Before Calculation 
            If Editable <> "yes" Then
                txtLabourCost.Text = ""
                txtLabourDetail.Text = ""
                'txtLabourDiscount.Text = ""
                txtLabourCost.Text = ""
                txtLabourSales.Text = ""
                txtLabourTax.Text = ""
                txtLabourSGST.Text = ""
                txtLabourCGST.Text = ""
                txtLabourIGST.Text = ""
                txtLabourTotal.Text = ""

                txtPartDetails1.Text = ""
                txtHsnSac1.Text = ""
                txtCost1.Text = ""
                txtSalesPrice1.Text = ""
                txtPart1Tax.Text = ""
                txtSGST1.Text = ""
                txtCGST1.Text = ""
                txtIGST1.Text = ""
                txtTotal1.Text = ""


                txtPartDetails2.Text = ""
                txtHsnSac2.Text = ""
                txtCost2.Text = ""
                txtSalesPrice2.Text = ""
                txtPart2Tax.Text = ""
                txtSGST2.Text = ""
                txtCGST2.Text = ""
                txtIGST2.Text = ""
                txtTotal2.Text = ""

                txtPartDetails3.Text = ""
                txtHsnSac3.Text = ""
                txtCost3.Text = ""
                txtSalesPrice3.Text = ""
                txtPart3Tax.Text = ""
                txtSGST3.Text = ""
                txtCGST3.Text = ""
                txtIGST3.Text = ""
                txtTotal3.Text = ""


                txtPartDetails4.Text = ""
                txtHsnSac4.Text = ""
                txtCost4.Text = ""
                txtSalesPrice4.Text = ""
                txtPart4Tax.Text = ""
                txtSGST4.Text = ""
                txtCGST4.Text = ""
                txtIGST4.Text = ""
                txtTotal4.Text = ""

                txtOtherSales.Text = ""
                'txtOtherTax.Text = ""
                txtOtherSGST.Text = ""
                txtOtherCGST.Text = ""
                txtOtherIGST.Text = ""
                txtOtherTotal.Text = ""
            End If


            strLabourValue = txtLabourAmount.Text
            If Trim(txtLabourAmount.Text) = "" Then
                'if LabourCost not entered 
                ' If (txtLabourCost.Text = "") Then 'And (txtLabourSales.Text = "")
                If (drpServiceType.SelectedItem.Value <> "4") And (drpServiceType.SelectedItem.Value <> "5") Then
                    Call showMsg("Labour Parts No is not entered", "")
                    Exit Sub
                End If
                'End If

            Else

                'Validate Labour cost is decimal 
                'If Decimal.TryParse(txtLabourAmount.Text, LabourCost) Then
                'Else
                '    Call showMsg("Labour cost is invalid ", "")
                '    Exit Sub
                'End If

                'txtLabourCost.Text = LabourCost

                If Editable = "yes" Then
                    If Decimal.TryParse(txtLabourCost.Text, LabourCost) Then
                    Else
                        Call showMsg("Labour cost is invalid ", "")
                        Exit Sub
                    End If
                Else



                    Dim _AppleLabourModel As AppleLabourModel = New AppleLabourModel()
                    Dim _AppleLabourControl As AppleLabourControl = New AppleLabourControl()
                    _AppleLabourModel.PART_NO = strLabourValue
                    dtApple = _AppleLabourControl.SelectLabourPrice(_AppleLabourModel)
                    If (dtApple Is Nothing) Or (dtApple.Rows.Count = 0) Then
                        Call showMsg("Labour Price Not Defined ( " & txtLabourAmount.Text & ")", "")
                        Exit Sub
                    Else

                        If Not IsDBNull(dtApple.Rows(0)("amount_150")) Then
                            txtLabourCost.Text = clsSet.setINR(dtApple.Rows(0)("amount_150"))
                        End If
                        'Validate Labour cost is decimal 
                        If Decimal.TryParse(txtLabourCost.Text, LabourCost) Then
                        Else
                            Call showMsg("Labour cost is invalid ", "")
                            Exit Sub
                        End If



                        If Not IsDBNull(dtApple.Rows(0)("amount_150")) Then
                            txtLabourSales.Text = clsSet.setINR(dtApple.Rows(0)("amount_150"))
                        End If
                        'Validate Labour Sales cost is decimal 
                        If Decimal.TryParse(txtLabourSales.Text, LabourSales) Then
                        Else
                            Call showMsg("Labour Sales cost is invalid ", "")
                            Exit Sub
                        End If

                        If (drpServiceType.SelectedItem.Value = "1") Or (drpServiceType.SelectedItem.Value = "3") Then
                            '1 IW , 3 - AppleCareProtection
                            txtLabourSales.Text = clsSet.setINR(0)
                            LabourSales = 0
                        End If


                        If Not IsDBNull(dtApple.Rows(0)("LABOUR_DETAILS")) Then
                            txtLabourDetail.Text = dtApple.Rows(0)("LABOUR_DETAILS")
                        End If

                        ''Validate Labour LabourSales is decimal 
                        'If Decimal.TryParse(txtLabourSales.Text, LabourSales) Then
                        'Else
                        '    Call showMsg("Labour sales cost is invalid ", "")
                        '    Exit Sub
                        'End If
                    End If
                End If

            End If





            If Trim(txtLabourDiscount.Text) <> "" Then
                'Validate Labour cost is decimal 
                If Decimal.TryParse(txtLabourDiscount.Text, LabourDiscount) Then
                Else
                    Call showMsg("Labour Discount is invalid ", "")
                    Exit Sub
                End If
                txtLabourDiscount.Text = clsSet.setINR(LabourDiscount)
            End If


            'Tax
            If txtLabourTax.Text = "" Then
                txtLabourTax.Text = DefaultTax
            End If


            If Trim(txtLabourTax.Text) <> "" Then
                'Validate Labour cost is decimal 
                If Decimal.TryParse(txtLabourTax.Text, LabourTax) Then
                Else
                    Call showMsg("Labour Tax is invalid ", "")
                    Exit Sub
                End If
                txtLabourTax.Text = clsSet.setINR(LabourTax)
            End If

            Sgst = LabourTax
            Cgst = LabourTax



            LabourCost = LabourCost
            LabourSales = LabourSales
            LabourSales = LabourSales - LabourDiscount
            LabourSgst = LabourSales / 100 * Sgst
            LabourIgst = LabourSales / 100 * Igst
            LabourCgst = LabourSales / 100 * Cgst
            LabourTotal = LabourSales + LabourSgst + LabourIgst + LabourCgst

            txtLabourCost.Text = clsSet.setINR(LabourCost)
            txtLabourSales.Text = clsSet.setINR(LabourSales)
            txtLabourSGST.Text = clsSet.setINR(LabourSgst)
            txtLabourCGST.Text = clsSet.setINR(LabourCgst)
            txtLabourIGST.Text = clsSet.setINR(LabourIgst)
            txtLabourTotal.Text = clsSet.setINR(LabourTotal)



            Dim _ApplePartsModel As ApplePartsModel = New ApplePartsModel()
            Dim _ApplePartsControl As ApplePartsControl = New ApplePartsControl()
            Dim dtApplePart As DataTable

            Dim _ApplePartsEntryControl As ApplePartsEntryControl = New ApplePartsEntryControl()
            Dim _ApplePartsEntryModel As ApplePartsEntryModel = New ApplePartsEntryModel()
            Dim intStock As Integer = 0
            'Part1
            If Trim(txtPartNo1.Text) <> "" Then
                '1st Validate Qty
                Qty = 0.00
                If Decimal.TryParse(txtQty1.Text, Qty) Then
                    Qtys = Qtys + Qty
                Else
                    Call showMsg("Quantity is invalid for Parts No1 ( " & txtQty1.Text & ")", "")
                    Exit Sub
                End If

                Discount = 0.00
                If Trim(txtDiscount1.Text) <> "" Then
                    If Decimal.TryParse(txtDiscount1.Text, Discount) Then
                        Discounts = Discounts + Discount
                    Else
                        Call showMsg("Discount is invalid for Parts No1 ( " & txtDiscount1.Text & ")", "")
                        Exit Sub
                    End If
                    txtDiscount1.Text = clsSet.setINR(Discount)
                End If


                blPartEntered = True

                If Editable = "yes" Then

                    If Trim(txtCost1.Text) <> "" Then
                        If Decimal.TryParse(txtCost1.Text, PriceCost) Then

                        Else
                            Call showMsg("Price Cost is invalid for Parts No1 ( " & txtCost1.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtSalesPrice1.Text) <> "" Then
                        If Decimal.TryParse(txtSalesPrice1.Text, SalesPrice) Then

                        Else
                            Call showMsg("Sales Price is invalid for Parts No1 ( " & txtSalesPrice1.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtPart1Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart1Tax.Text, PartTax) Then

                        Else
                            Call showMsg("Tax is invalid for Parts No1 ( " & txtPart1Tax.Text & ")", "")
                            Exit Sub
                        End If
                        txtPart1Tax.Text = clsSet.setINR(PartTax)
                    End If
                Else


                    '********************
                    'Apple Parts / ACC Parts
                    '*******************
                    'ACC Parts
                    If (drpServiceType.SelectedItem.Value = "5") Then

                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo1.Text)
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo1.Text)
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("CURRENT_IN_STOCK")) Then
                                intStock = dtApplePart.Rows(0)("CURRENT_IN_STOCK")
                            End If
                            If (txtQty1.Text > intStock) Then
                                Call showMsg(txtPartNo1.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("DESCRIPTION")) Then
                                txtPartDetails1.Text = dtApplePart.Rows(0)("DESCRIPTION")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("UPC_EAN")) Then
                                txtHsnSac1.Text = dtApplePart.Rows(0)("UPC_EAN")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PURCHASE_PRICE")) Then
                                txtCost1.Text = dtApplePart.Rows(0)("PURCHASE_PRICE")
                                PriceCost = dtApplePart.Rows(0)("PURCHASE_PRICE")
                            Else
                                txtCost1.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts cost is decimal 
                            If Decimal.TryParse(txtCost1.Text, PriceCost) Then
                            Else
                                Call showMsg("Part1 Cost is invalid ", "")
                                Exit Sub
                            End If
                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice1.Text = 0
                                SalesPrice = 0

                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = "* " & txtPartNo1.Text & "<br>"
                                            txtSalesPrice1.Text = txtCost1.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice1.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice1.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart1Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart1Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart1Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart1Tax.Text, PartTax) Then
                                Else
                                    Call showMsg("Tax is invalid for Parts No1 ( " & txtPart1Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart1Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    ElseIf (drpServiceType.SelectedItem.Value = "1") Then  'Consignment Table(IW)
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo1.Text)
                        If chkSerialPart1.Checked Then
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"

                        End If
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStockAppConsignment(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo1.Text)
                            strStockUnavailable = " / stock "
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("BALANCE")) Then
                                intStock = dtApplePart.Rows(0)("BALANCE")
                            End If
                            If (txtQty1.Text > intStock) Then
                                Call showMsg(txtPartNo1.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If

                        End If
                        ' Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo1.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt1.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo1.Text)
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails1.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac1.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost1.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost1.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts cost is decimal 
                            If Decimal.TryParse(txtCost1.Text, PriceCost) Then
                            Else
                                Call showMsg("Part1 Cost is invalid ", "")
                                Exit Sub
                            End If
                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice1.Text = 0
                                SalesPrice = 0

                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = "* " & txtPartNo1.Text & "<br>"
                                            txtSalesPrice1.Text = txtCost1.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice1.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice1.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart1Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart1Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart1Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart1Tax.Text, PartTax) Then
                                Else
                                    Call showMsg("Tax is invalid for Parts No1 ( " & txtPart1Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart1Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If


                    ElseIf (drpServiceType.SelectedItem.Value = "2") Then ' 'Stock Table (OOW)
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo1.Text)
                        If chkSerialPart1.Checked Then
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"

                        End If
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStockAppStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo1.Text)
                            strStockUnavailable = " / stock "
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("BALANCE")) Then
                                intStock = dtApplePart.Rows(0)("BALANCE")
                            End If
                            If (txtQty1.Text > intStock) Then
                                Call showMsg(txtPartNo1.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If

                        End If
                        ' Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo1.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt1.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo1.Text)
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails1.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac1.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost1.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost1.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts cost is decimal 
                            If Decimal.TryParse(txtCost1.Text, PriceCost) Then
                            Else
                                Call showMsg("Part1 Cost is invalid ", "")
                                Exit Sub
                            End If
                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice1.Text = 0
                                SalesPrice = 0

                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = "* " & txtPartNo1.Text & "<br>"
                                            txtSalesPrice1.Text = txtCost1.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice1.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice1.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart1Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart1Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart1Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart1Tax.Text, PartTax) Then
                                Else
                                    Call showMsg("Tax is invalid for Parts No1 ( " & txtPart1Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart1Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    Else


                        ' Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo1.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt1.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo1.Text)
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails1.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac1.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost1.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost1.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts cost is decimal 
                            If Decimal.TryParse(txtCost1.Text, PriceCost) Then
                            Else
                                Call showMsg("Part1 Cost is invalid ", "")
                                Exit Sub
                            End If
                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice1.Text = 0
                                SalesPrice = 0

                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = "* " & txtPartNo1.Text & "<br>"
                                            txtSalesPrice1.Text = txtCost1.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice1.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice1.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart1Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart1Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart1Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart1Tax.Text, PartTax) Then
                                Else
                                    Call showMsg("Tax is invalid for Parts No1 ( " & txtPart1Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart1Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If
                    End If



                End If





                Sgst = PartTax
                Cgst = PartTax
                '20210822
                'tmpSalesPrice = (Qty * PriceCost) - Discount
                tmpSalesPrice = (Qty * SalesPrice) - Discount
                txtSalesPrice1.Text = tmpSalesPrice
                txtDiscount1.Text = clsSet.setINR(Discount)

                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSalesPrice1.Text = clsSet.setINR(tmpSalesPrice)

                txtSGST1.Text = clsSet.setINR(PartSgst)
                txtCGST1.Text = clsSet.setINR(PartCgst)
                txtIGST1.Text = clsSet.setINR(PartIgst)
                txtTotal1.Text = clsSet.setINR(PartTotal)

                SalesPrices = tmpSalesPrice
                PartSgsts = PartSgst
                PartIgsts = PartIgst
                PartCgsts = PartCgst
                PartTotals = PartTotal



            End If

            'Part2
            If Trim(txtPartNo2.Text) <> "" Then
                '1st Validate Qty
                Qty = 0.00
                If Decimal.TryParse(txtQty2.Text, Qty) Then
                    Qtys = Qtys + Qty
                Else
                    Call showMsg("Quantity is invalid for Parts No2 ( " & txtQty2.Text & ")", "")
                    Exit Sub
                End If
                Discount = 0.00
                If Trim(txtDiscount2.Text) <> "" Then
                    If Decimal.TryParse(txtDiscount2.Text, Discount) Then
                        Discounts = Discounts + Discount
                    Else
                        Call showMsg("Discount is invalid for Parts No2 ( " & txtDiscount2.Text & ")", "")
                        Exit Sub
                    End If
                    txtDiscount2.Text = clsSet.setINR(Discount)
                End If

                blPartEntered = True
                If Editable = "yes" Then
                    If Trim(txtCost2.Text) <> "" Then
                        If Decimal.TryParse(txtCost2.Text, PriceCost) Then

                        Else
                            Call showMsg("Price Cost is invalid for Parts No2 ( " & txtCost2.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtSalesPrice2.Text) <> "" Then
                        If Decimal.TryParse(txtSalesPrice2.Text, SalesPrice) Then

                        Else
                            Call showMsg("Sales Price is invalid for Parts No2 ( " & txtSalesPrice2.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtPart2Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart2Tax.Text, PartTax) Then

                        Else
                            Call showMsg("Tax is invalid for Parts No2 ( " & txtPart2Tax.Text & ")", "")
                            Exit Sub
                        End If
                        txtPart2Tax.Text = clsSet.setINR(PartTax)
                    End If
                Else
                    '********************
                    'Apple Parts / ACC Parts
                    '*******************
                    'ACC Parts
                    If (drpServiceType.SelectedItem.Value = "5") Then
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo2.Text)
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo2.Text)
                            Else
                                FailureText = Trim(txtPartNo2.Text)
                            End If
                        Else

                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("CURRENT_IN_STOCK")) Then
                                intStock = dtApplePart.Rows(0)("CURRENT_IN_STOCK")
                            End If
                            If (txtQty2.Text > intStock) Then
                                Call showMsg(txtPartNo2.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If


                            If Not IsDBNull(dtApplePart.Rows(0)("DESCRIPTION")) Then
                                txtPartDetails2.Text = dtApplePart.Rows(0)("DESCRIPTION")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("UPC_EAN")) Then
                                txtHsnSac2.Text = dtApplePart.Rows(0)("UPC_EAN")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PURCHASE_PRICE")) Then
                                txtCost2.Text = dtApplePart.Rows(0)("PURCHASE_PRICE")
                                PriceCost = dtApplePart.Rows(0)("PURCHASE_PRICE")
                            Else
                                txtCost2.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 2 cost is decimal 
                            If Decimal.TryParse(txtCost2.Text, PriceCost) Then
                            Else
                                Call showMsg("Part2 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice2.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo2.Text & "<br>"
                                            txtSalesPrice2.Text = txtCost2.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice2.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice2.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart2Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart2Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart2Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart2Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No2 ( " & txtPart2Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart2Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    ElseIf (drpServiceType.SelectedItem.Value = "1") Then 'Consignment Table(IW)
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo2.Text)
                        If chkSerialPart2.Checked Then
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"

                        End If
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStockAppConsignment(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo2.Text)
                            strStockUnavailable = " / stock "
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("BALANCE")) Then
                                intStock = dtApplePart.Rows(0)("BALANCE")
                            End If
                            If (txtQty2.Text > intStock) Then
                                Call showMsg(txtPartNo2.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If

                        End If

                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo2.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt2.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo2.Text)
                            Else
                                FailureText = Trim(txtPartNo2.Text)
                            End If
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails2.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac2.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost2.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost2.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 2 cost is decimal 
                            If Decimal.TryParse(txtCost2.Text, PriceCost) Then
                            Else
                                Call showMsg("Part2 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice2.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo2.Text & "<br>"
                                            txtSalesPrice2.Text = txtCost2.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice2.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice2.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart2Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart2Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart2Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart2Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No2 ( " & txtPart2Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart2Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    ElseIf (drpServiceType.SelectedItem.Value = "2") Then 'Stock Table(IW)
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo2.Text)
                        If chkSerialPart2.Checked Then
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"
                        End If
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStockAppConsignment(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo2.Text)
                            strStockUnavailable = " / stock "
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("BALANCE")) Then
                                intStock = dtApplePart.Rows(0)("BALANCE")
                            End If
                            If (txtQty2.Text > intStock) Then
                                Call showMsg(txtPartNo2.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If

                        End If

                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo2.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt2.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo2.Text)
                            Else
                                FailureText = Trim(txtPartNo2.Text)
                            End If
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails2.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac2.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost2.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost2.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 2 cost is decimal 
                            If Decimal.TryParse(txtCost2.Text, PriceCost) Then
                            Else
                                Call showMsg("Part2 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice2.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo2.Text & "<br>"
                                            txtSalesPrice2.Text = txtCost2.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice2.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice2.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart2Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart2Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart2Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart2Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No2 ( " & txtPart2Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart2Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    Else 'Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo2.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt2.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo2.Text)
                            Else
                                FailureText = Trim(txtPartNo2.Text)
                            End If
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails2.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac2.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost2.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost2.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 2 cost is decimal 
                            If Decimal.TryParse(txtCost2.Text, PriceCost) Then
                            Else
                                Call showMsg("Part2 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice2.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo2.Text & "<br>"
                                            txtSalesPrice2.Text = txtCost2.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice2.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice2.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart2Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart2Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart2Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart2Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No2 ( " & txtPart2Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart2Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If


                    End If



                End If


                Sgst = PartTax
                Cgst = PartTax

                '20210822
                'tmpSalesPrice = (Qty * PriceCost) - Discount
                tmpSalesPrice = (Qty * SalesPrice) - Discount
                txtSalesPrice2.Text = clsSet.setINR(tmpSalesPrice)
                txtDiscount2.Text = clsSet.setINR(Discount)

                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST2.Text = clsSet.setINR(PartSgst)
                txtCGST2.Text = clsSet.setINR(PartCgst)
                txtIGST2.Text = clsSet.setINR(PartIgst)
                txtTotal2.Text = clsSet.setINR(PartTotal)

                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartCgst
                PartCgsts = PartCgsts + PartIgst
                PartTotals = PartTotals + PartTotal


            End If

            'Part3
            If Trim(txtPartNo3.Text) <> "" Then
                Qty = 0.00
                If Decimal.TryParse(txtQty3.Text, Qty) Then
                    Qtys = Qtys + Qty
                Else
                    Call showMsg("Quantity is invalid for Parts No3 ( " & txtQty3.Text & ")", "")
                    Exit Sub
                End If
                Discount = 0.00
                If Trim(txtDiscount3.Text) <> "" Then
                    If Decimal.TryParse(txtDiscount3.Text, Discount) Then
                        Discounts = Discounts + Discount
                    Else
                        Call showMsg("Discount is invalid for Parts No3 ( " & txtDiscount3.Text & ")", "")
                        Exit Sub
                    End If
                    txtDiscount3.Text = clsSet.setINR(Discount)
                End If

                blPartEntered = True
                If Editable = "yes" Then
                    If Trim(txtCost3.Text) <> "" Then
                        If Decimal.TryParse(txtCost3.Text, PriceCost) Then

                        Else
                            Call showMsg("Price Cost is invalid for Parts No3 ( " & txtCost3.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtSalesPrice3.Text) <> "" Then
                        If Decimal.TryParse(txtSalesPrice3.Text, SalesPrice) Then

                        Else
                            Call showMsg("Sales Price is invalid for Parts No3 ( " & txtSalesPrice3.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtPart3Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart3Tax.Text, PartTax) Then
                        Else
                            Call showMsg("Tax is invalid for Parts No3 ( " & txtPart3Tax.Text & ")", "")
                            Exit Sub
                        End If
                        txtPart3Tax.Text = clsSet.setINR(PartTax)
                    End If
                Else


                    '********************
                    'Apple Parts / ACC Parts
                    '*******************
                    'ACC Parts
                    If (drpServiceType.SelectedItem.Value = "5") Then
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo3.Text)
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo3.Text)
                            Else
                                FailureText = Trim(txtPartNo3.Text)
                            End If
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("CURRENT_IN_STOCK")) Then
                                intStock = dtApplePart.Rows(0)("CURRENT_IN_STOCK")
                            End If
                            If (txtQty3.Text > intStock) Then
                                Call showMsg(txtPartNo3.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("DESCRIPTION")) Then
                                txtPartDetails3.Text = dtApplePart.Rows(0)("DESCRIPTION")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("UPC_EAN")) Then
                                txtHsnSac3.Text = dtApplePart.Rows(0)("UPC_EAN")
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("PURCHASE_PRICE")) Then
                                txtCost3.Text = dtApplePart.Rows(0)("PURCHASE_PRICE")
                                PriceCost = dtApplePart.Rows(0)("PURCHASE_PRICE")
                            Else
                                txtCost3.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 3 cost is decimal 
                            If Decimal.TryParse(txtCost3.Text, PriceCost) Then
                            Else
                                Call showMsg("Part3 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice3.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo3.Text & "<br>"
                                            txtSalesPrice3.Text = txtCost3.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice3.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice3.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart3Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart3Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart3Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart3Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No3 ( " & txtPart3Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart3Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    ElseIf (drpServiceType.SelectedItem.Value = "1") Then 'Consignment Table(IW)
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo3.Text)
                        If chkSerialPart3.Checked Then
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"
                        Else
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"
                        End If
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStockAppConsignment(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo3.Text)
                            strStockUnavailable = " / stock "
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("BALANCE")) Then
                                intStock = dtApplePart.Rows(0)("BALANCE")
                            End If
                            If (txtQty3.Text > intStock) Then
                                Call showMsg(txtPartNo3.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If
                        End If
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo3.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt3.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo3.Text)
                            Else
                                FailureText = Trim(txtPartNo3.Text)
                            End If
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails3.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac3.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost3.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost3.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 3 cost is decimal 
                            If Decimal.TryParse(txtCost3.Text, PriceCost) Then
                            Else
                                Call showMsg("Part3 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice3.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo3.Text & "<br>"
                                            txtSalesPrice3.Text = txtCost3.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice3.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice3.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart3Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart3Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart3Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart3Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No3 ( " & txtPart3Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart3Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If
                    ElseIf (drpServiceType.SelectedItem.Value = "2") Then ''Stock Table(OOW)
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo3.Text)
                        If chkSerialPart3.Checked Then
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"
                        End If
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStockAppStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo3.Text)
                            strStockUnavailable = " / stock "
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("BALANCE")) Then
                                intStock = dtApplePart.Rows(0)("BALANCE")
                            End If
                            If (txtQty3.Text > intStock) Then
                                Call showMsg(txtPartNo3.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If
                        End If
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo3.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt3.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo3.Text)
                            Else
                                FailureText = Trim(txtPartNo3.Text)
                            End If
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails3.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac3.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost3.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost3.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 3 cost is decimal 
                            If Decimal.TryParse(txtCost3.Text, PriceCost) Then
                            Else
                                Call showMsg("Part3 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice3.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo3.Text & "<br>"
                                            txtSalesPrice3.Text = txtCost3.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice3.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice3.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart3Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart3Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart3Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart3Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No3 ( " & txtPart3Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart3Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If
                    Else 'Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo3.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt3.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo3.Text)
                            Else
                                FailureText = Trim(txtPartNo3.Text)
                            End If
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails3.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac3.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost3.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost3.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 3 cost is decimal 
                            If Decimal.TryParse(txtCost3.Text, PriceCost) Then
                            Else
                                Call showMsg("Part3 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice3.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo3.Text & "<br>"
                                            txtSalesPrice3.Text = txtCost3.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice3.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice3.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart3Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart3Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart3Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart3Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No3 ( " & txtPart3Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart3Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    End If

                End If


                Sgst = PartTax
                Cgst = PartTax

                '20210822
                'tmpSalesPrice = (Qty * PriceCost) - Discount

                tmpSalesPrice = (Qty * SalesPrice) - Discount
                txtSalesPrice3.Text = clsSet.setINR(tmpSalesPrice)
                txtDiscount3.Text = clsSet.setINR(Discount)

                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST3.Text = clsSet.setINR(PartSgst)
                txtCGST3.Text = clsSet.setINR(PartCgst)
                txtIGST3.Text = clsSet.setINR(PartIgst)
                txtTotal3.Text = clsSet.setINR(PartTotal)

                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartIgst
                PartCgsts = PartCgsts + PartCgst
                PartTotals = PartTotals + PartTotal
            End If




            'Part4
            If Trim(txtPartNo4.Text) <> "" Then
                Qty = 0.00
                If Decimal.TryParse(txtQty4.Text, Qty) Then
                    Qtys = Qtys + Qty
                Else
                    Call showMsg("Quantity is invalid for Parts No4 ( " & txtQty4.Text & ")", "")
                    Exit Sub
                End If
                Discount = 0.00
                If Trim(txtDiscount4.Text) <> "" Then
                    If Decimal.TryParse(txtDiscount4.Text, Discount) Then
                        Discounts = Discounts + Discount
                    Else
                        Call showMsg("Discount is invalid for Parts No4 ( " & txtDiscount4.Text & ")", "")
                        Exit Sub
                    End If
                    txtDiscount4.Text = clsSet.setINR(Discount)
                End If

                blPartEntered = True

                If Editable = "yes" Then
                    If Trim(txtCost4.Text) <> "" Then
                        If Decimal.TryParse(txtCost4.Text, PriceCost) Then

                        Else
                            Call showMsg("Price Cost is invalid for Parts No4 ( " & txtCost4.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtSalesPrice4.Text) <> "" Then
                        If Decimal.TryParse(txtSalesPrice4.Text, SalesPrice) Then

                        Else
                            Call showMsg("Sales Price is invalid for Parts No4 ( " & txtSalesPrice4.Text & ")", "")
                            Exit Sub
                        End If
                    End If

                    If Trim(txtPart4Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart4Tax.Text, PartTax) Then

                        Else
                            Call showMsg("Tax is invalid for Parts No4 ( " & txtPart4Tax.Text & ")", "")
                            Exit Sub
                        End If
                        txtPart4Tax.Text = clsSet.setINR(PartTax)
                    End If


                Else


                    '********************
                    'Apple Parts / ACC Parts
                    '*******************
                    'ACC Parts
                    If (drpServiceType.SelectedItem.Value = "5") Then
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo4.Text)
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo4.Text)
                            Else
                                FailureText = Trim(txtPartNo4.Text)
                            End If

                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("CURRENT_IN_STOCK")) Then
                                intStock = dtApplePart.Rows(0)("CURRENT_IN_STOCK")
                            End If
                            If (txtQty4.Text > intStock) Then
                                Call showMsg(txtPartNo4.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("DESCRIPTION")) Then
                                txtPartDetails4.Text = dtApplePart.Rows(0)("DESCRIPTION")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("UPC_EAN")) Then
                                txtHsnSac4.Text = dtApplePart.Rows(0)("UPC_EAN")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PURCHASE_PRICE")) Then
                                txtCost4.Text = dtApplePart.Rows(0)("PURCHASE_PRICE")
                                PriceCost = dtApplePart.Rows(0)("PURCHASE_PRICE")
                            Else
                                txtCost4.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 4 cost is decimal 
                            If Decimal.TryParse(txtCost4.Text, PriceCost) Then
                            Else
                                Call showMsg("Part4 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice4.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo4.Text & "<br>"
                                            txtSalesPrice4.Text = txtCost4.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice4.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice4.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart4Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart4Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart4Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart4Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No4 ( " & txtPart4Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart4Tax.Text = clsSet.setINR(PartTax)
                            End If

                        End If

                    ElseIf (drpServiceType.SelectedItem.Value = "1") Then 'Consignment Table(IW)
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo4.Text)
                        If chkSerialPart4.Checked Then
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"

                        End If
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStockAppConsignment(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo4.Text)
                            strStockUnavailable = " / stock "
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("BALANCE")) Then
                                intStock = dtApplePart.Rows(0)("BALANCE")
                            End If
                            If (txtQty4.Text > intStock) Then
                                Call showMsg(txtPartNo4.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If
                        End If

                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo4.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt4.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo4.Text)
                            Else
                                FailureText = Trim(txtPartNo4.Text)
                            End If

                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails4.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac4.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost4.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost4.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 4 cost is decimal 
                            If Decimal.TryParse(txtCost4.Text, PriceCost) Then
                            Else
                                Call showMsg("Part4 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice4.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo4.Text & "<br>"
                                            txtSalesPrice4.Text = txtCost4.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice4.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice4.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart4Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart4Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart4Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart4Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No4 ( " & txtPart4Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart4Tax.Text = clsSet.setINR(PartTax)
                            End If

                        End If
                    ElseIf (drpServiceType.SelectedItem.Value = "2") Then ''Stock Table(OOW)
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo4.Text)
                        If chkSerialPart4.Checked Then
                            _ApplePartsEntryModel.SERIAL_TYPE = "Y"
                        End If
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStockAppStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo4.Text)
                            strStockUnavailable = " / stock "
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("BALANCE")) Then
                                intStock = dtApplePart.Rows(0)("BALANCE")
                            End If
                            If (txtQty4.Text > intStock) Then
                                Call showMsg(txtPartNo4.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If
                        End If

                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo4.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt4.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo4.Text)
                            Else
                                FailureText = Trim(txtPartNo4.Text)
                            End If

                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails4.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac4.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost4.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost4.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 4 cost is decimal 
                            If Decimal.TryParse(txtCost4.Text, PriceCost) Then
                            Else
                                Call showMsg("Part4 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice4.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo4.Text & "<br>"
                                            txtSalesPrice4.Text = txtCost4.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice4.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice4.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart4Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart4Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart4Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart4Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No4 ( " & txtPart4Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart4Tax.Text = clsSet.setINR(PartTax)
                            End If

                        End If

                    Else 'Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo4.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt4.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo4.Text)
                            Else
                                FailureText = Trim(txtPartNo4.Text)
                            End If

                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails4.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac4.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost4.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost4.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 4 cost is decimal 
                            If Decimal.TryParse(txtCost4.Text, PriceCost) Then
                            Else
                                Call showMsg("Part4 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice4.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo4.Text & "<br>"
                                            txtSalesPrice4.Text = txtCost4.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice4.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice4.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart4Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart4Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart4Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart4Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No4 ( " & txtPart4Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart4Tax.Text = clsSet.setINR(PartTax)
                            End If

                        End If



                    End If








                End If



                Sgst = PartTax
                Cgst = PartTax

                '20210822
                'tmpSalesPrice = (Qty * PriceCost) - Discount
                tmpSalesPrice = (Qty * SalesPrice) - Discount
                txtSalesPrice4.Text = clsSet.setINR(tmpSalesPrice)
                txtDiscount4.Text = clsSet.setINR(Discount)


                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST4.Text = clsSet.setINR(PartSgst)
                txtCGST4.Text = clsSet.setINR(PartCgst)
                txtIGST4.Text = clsSet.setINR(PartIgst)
                txtTotal4.Text = clsSet.setINR(PartTotal)


                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartIgst
                PartCgsts = PartCgsts + PartCgst
                PartTotals = PartTotals + PartTotal

            End If



            If blPartEntered = False Then
                If txtLabourAmount.Text = "" Then
                    Call showMsg("Please enter parts no  ", "")
                    Exit Sub
                End If
            End If


            If blPriceCheckFailure = True Then
                Call showMsg(String.Format("The price {0} does not exist !!! <br>" & FailureText, strStockUnavailable), "")
                Exit Sub
            End If


            'Assign Final Amount to Part
            txtPartQtyAmount.Text = Qtys
            txtPartDiscountAmount.Text = clsSet.setINR(Discounts)
            txtPartSalesAmount.Text = clsSet.setINR(SalesPrices)
            txtPartSGSTAmount.Text = clsSet.setINR(PartSgsts)
            txtPartCGSTAmount.Text = clsSet.setINR(PartCgsts)
            txtPartIGSTAmount.Text = clsSet.setINR(PartIgst)
            txtPartTotal.Text = clsSet.setINR(PartTotals)




            '3rd Other Amount
            Dim OtherQty As Decimal = 0.00
            Dim OtherDiscount As Decimal = 0.00
            Dim OtherCost As Decimal = 0.00
            Dim OtherSale As Decimal = 0.00
            Dim OtherSgst As Decimal = 0.00
            Dim OtherIgst As Decimal = 0.00
            Dim OtherCgst As Decimal = 0.00
            Dim OtherTotal As Decimal = 0.00
            Dim OtherTax As Decimal = 0.00

            'Verify All Editable are empty
            If Trim(txtOtherQtyAmount.Text) = "" And Trim(txtOtherDetail.Text) = "" And Trim(txtOtherCost.Text) = "" Then
                txtOtherSales.Text = ""
                txtOtherSGST.Text = ""
                txtOtherCGST.Text = ""
                txtOtherIGST.Text = ""
                txtOtherTotal.Text = ""
            Else
                If Decimal.TryParse(txtOtherQtyAmount.Text, OtherQty) Then
                Else
                    Call showMsg("Other Quantity is invalid ", "")
                    Exit Sub
                End If
                If Decimal.TryParse(txtOtherCost.Text, OtherCost) Then
                Else
                    Call showMsg("Other Cost is invalid ", "")
                    Exit Sub
                End If

                If Trim(txtOtherDiscount.Text) <> "" Then
                    If Decimal.TryParse(txtOtherDiscount.Text, OtherDiscount) Then
                    Else
                        Call showMsg("Other Discount is invalid ", "")
                        Exit Sub
                    End If
                End If

                If Trim(txtOtherTax.Text) <> "" Then
                    If Decimal.TryParse(txtOtherTax.Text, OtherTax) Then

                    Else
                        Call showMsg("Tax is invalid for Other ( " & txtOtherTax.Text & ")", "")
                        Exit Sub
                    End If
                    txtOtherTax.Text = clsSet.setINR(OtherTax)
                End If

                Sgst = OtherTax
                Cgst = OtherTax

                OtherSale = (OtherQty * OtherCost) - OtherDiscount
                txtOtherSales.Text = clsSet.setINR(OtherSale)

                OtherSgst = OtherSale / 100 * Sgst
                OtherIgst = OtherSale / 100 * Igst
                OtherCgst = OtherSale / 100 * Cgst
                OtherTotal = OtherSale + OtherSgst + OtherIgst + OtherCgst

                txtOtherSGST.Text = clsSet.setINR(OtherSgst)
                txtOtherCGST.Text = clsSet.setINR(OtherCgst)
                txtOtherIGST.Text = clsSet.setINR(OtherIgst)
                txtOtherTotal.Text = clsSet.setINR(OtherTotal)
            End If


            txtTotalQty.Text = Qtys + OtherQty
            'txtTotalCostAmount.text =""
            txtDiscountAmount.Text = clsSet.setINR(LabourDiscount + Discounts + OtherDiscount)
            txtTotalSalesAmount.Text = clsSet.setINR(LabourSales + SalesPrices + OtherSale)
            txtTotalSGSTAmount.Text = clsSet.setINR(LabourSgst + PartSgsts + OtherSgst)
            txtTotalCGSTAmount.Text = clsSet.setINR(LabourCgst + PartCgsts + OtherCgst)
            txtTotalIGSTAmount.Text = clsSet.setINR(LabourIgst + PartIgsts + OtherIgst)
            txtTotalAmount.Text = clsSet.setINR(LabourTotal + PartTotals + OtherTotal)
            Dim TotValue As Double = 0.00
            If Trim(txtTotalAmount.Text) <> "" Then
                'Validate Total Amount decimal 
                If Decimal.TryParse(txtTotalAmount.Text, TotValue) Then
                    txtTotalAmount.Text = Math.Round(TotValue, MidpointRounding.ToEven)
                Else
                    Call showMsg("Total Amount is invalid ", "")
                    Exit Sub
                End If
            End If

            Dim AdvanceAmount As Decimal = 0.00

            If Trim(txtAdvance.Text) <> "" Then
                'Validate Labour cost is decimal 
                If Decimal.TryParse(txtAdvance.Text, AdvanceAmount) Then
                Else
                    Call showMsg("Advance Amount is invalid ", "")
                    Exit Sub
                End If
            End If

            txtBalance.Text = clsSet.setINR(((LabourTotal + PartTotals + OtherTotal) - AdvanceAmount))


        End If

        'Finally Save to the Database
        If srcFunction = "btncalc" Then
            UpdateInfo("btncalc")
            If Len(Trim(strPartsSalesNotFound)) > 4 Then
                Call showMsg("The following parts no(s) are not assigned Sales price, so assigned cost price: <br>  " & strPartsSalesNotFound, "")
            End If
        ElseIf srcFunction = "btnestimate" Then
            UpdateInfo("btnestimate")
        End If


        '*************************
        'Btn Estimate
        If (srcFunction = "btnestimate") Then
            '1st Check PO
            '1st Check PO
            txtPoNo.Text = Trim(txtPoNo.Text)
            If txtPoNo.Text = "" Then
                Call showMsg("PO No is not allowed empty", "")
                Exit Sub
            End If


            txtCustomerName.Text = Trim(txtCustomerName.Text)
            If txtCustomerName.Text = "" Then
                Call showMsg("CustomerName is not allowed empty", "")
                Exit Sub
            End If


            'Calculation


            'Save

            Dim fileStream As FileStream
            Dim logoQuickGarage As String = "C:\money\gss_asp.png"
            '  Dim logoApple As String = "C:\money\apple_logo.jpg"

            Dim saveCsvPass As String = "C:\money\CSV\"
            Dim savePDFPass As String = "C:\money\PDF\"

            Dim fnt4 As New Font(BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, True), 16, iTextSharp.text.Font.UNDERLINE)

            Dim fnt5 As New Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False))
            Dim bf As BaseFont = BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, False)


            Dim Font2 As Font = New Font(bf, 11, Font.NORMAL)
            Dim Font3 As Font = New Font(bf, 6, Font.NORMAL)
            Dim fname = txtPoNo.Text & "_" & System.DateTime.Now.Millisecond.ToString() & ".pdf"

            Dim FontTitle As Font = New Font(bf, 14, Font.NORMAL)

            Dim filename As String = savePDFPass & fname

            txtEstimatedDate.Text = Now

            Try

                Dim SingleLine As New Paragraph()
                Dim doc As Document
                Dim pdfWriter As PdfWriter
                Dim image1 As Image = Image.GetInstance(logoQuickGarage) '画像
                image1.ScalePercent(7) '大きさ

                fileStream = New FileStream(filename, FileMode.Create)
                doc = New Document(PageSize.A4, 5, 5, 5, 5)
                pdfWriter = PdfWriter.GetInstance(doc, fileStream)
                doc.Open()

                Dim pcb As PdfContentByte = pdfWriter.DirectContent
                Dim cell As PdfPCell

                Dim psam As New Paragraph()
                psam.Alignment = Element.ALIGN_LEFT
                psam.Add(" ")
                doc.Add(psam)
                Dim psam1 As New Paragraph()
                psam1.Add(".")
                psam1.Alignment = Element.ALIGN_LEFT
                doc.Add(psam1)
                image1.ScaleAbsolute(380.0F, 45.0F)
                Dim p As New Paragraph()
                p.Add(New Chunk(image1, 0, 0))
                p.Alignment = Element.ALIGN_LEFT
                doc.Add(p)

                Dim table As PdfPTable = New PdfPTable(6)
                table.WidthPercentage = 100

                Dim table41 As PdfPTable = New PdfPTable(2)
                table41.WidthPercentage = 100
                Dim header41 As PdfPCell = New PdfPCell()
                header41.Colspan = 2
                table41.AddCell(header41) 'No pf Row
                cell = New PdfPCell(New Paragraph("GSS Quick Qarage Pvt Ltd", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                Dim FntCode39 As New Font(BaseFont.CreateFont("c:\money\CODE39.ttf", BaseFont.IDENTITY_H, True), 12) 'バ
                If Len(txtSerialNo.Text) > 2 Then
                    cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", FntCode39))
                Else
                    cell = New PdfPCell(New Paragraph(" "))
                End If
                'cell = New PdfPCell(New Paragraph(Trim(txtPoNo.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Paragon Plaza,Phoenix Market City,", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph(Trim(txtPoNo.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph("L B S Marg,Kurla west,Mumbai 400070", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                'cell = New PdfPCell(New Paragraph(Trim(txtGNo.Text), Font2))
                cell = New PdfPCell(New Paragraph("Create Date	", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)


                cell = New PdfPCell(New Paragraph("Telephone: +91-9500043584", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)
                'cell = New PdfPCell(New Paragraph("2021/03/21"))

                'cell = New PdfPCell(New Paragraph("Create Date	", Font2))
                cell = New PdfPCell(New Paragraph(txtEstimatedDate.Text, Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)



                cell = New PdfPCell(New Paragraph("E-mail: gss.asc1@quickgarage.co.in", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph(" ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)

                'Comment on 20210621
                'cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1ZH  CIN: U74999TN2016FTC112554", Font2))
                cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1ZH                             ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                doc.Add(table41)


                Dim ParaB As New Paragraph("Business Hours: 10:00AM to 7:00 PM Weekly Off Sunday", Font2)
                ParaB.Alignment = Element.ALIGN_LEFT
                doc.Add(ParaB)

                Dim Font1 As Font = New Font(bf, 22, Font.BOLD)

                ' Dim P9 As New Paragraph("", Font1)
                SingleLine.Alignment = Element.ALIGN_CENTER
                SingleLine = New Paragraph("", Font1)
                SingleLine.Add("                                Service Estimate")
                SingleLine.Font = FontFactory.GetFont("Segoe UI", 18.0, BaseColor.ORANGE)
                doc.Add(SingleLine)


                SingleLine = New Paragraph("", FontTitle)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("Customer Information")
                doc.Add(SingleLine)
                'doc.Add(table)

                Dim tableCustomer As PdfPTable = New PdfPTable(4)
                Dim header As PdfPCell = New PdfPCell()
                tableCustomer.WidthPercentage = 100
                header.Colspan = 6

                Dim intTblWidth() As Integer = {10, 30, 10, 15}
                tableCustomer.SetWidths(intTblWidth)

                tableCustomer.AddCell(header)

                cell = New PdfPCell(New Paragraph("Customer name", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCustomerName.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("PO Date", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                'Doubt
                'cell = New PdfPCell(New Paragraph(txtEstimatedDate.Text))
                cell = New PdfPCell(New Paragraph((lblhidPoDate.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Address", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtAddressLine1.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Model name", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                'Doubt
                'cell = New PdfPCell(New Paragraph("IPHONE 12,NA,256GB,BLACK"))
                cell = New PdfPCell(New Paragraph(txtModel.Text, Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                'header = New PdfPCell()

                'table.AddCell(header)
                cell = New PdfPCell(New Paragraph(" "))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtAddressLine2.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Product name ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtProduct.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph(("City"), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCity.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Warranty Status ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((drpServiceType.SelectedItem.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("E-mail", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtEmail.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Date of Purchase ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                'cell = New PdfPCell(New Paragraph("2020/12/10 "))
                cell = New PdfPCell(New Paragraph((txtDateOfPurchase.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Mobile", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtMobile.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph(("Serial No"), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtSerialNo.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)


                cell = New PdfPCell(New Paragraph(" ", Font2))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((" "), Font2))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph(" "))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                If Len(txtSerialNo.Text) > 2 Then
                    cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", FntCode39))
                Else
                    cell = New PdfPCell(New Paragraph(" "))
                End If
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                doc.Add(tableCustomer)

                Dim strtxtAccessoryNote As String = ""
                strtxtAccessoryNote = Trim(txtAccessoryNote.Text)
                If Len(strtxtAccessoryNote) > 1 Then
                    strtxtAccessoryNote = strtxtAccessoryNote.Replace(vbLf, " ").Replace(vbCr, " ")
                    Dim tblAcc As PdfPTable = New PdfPTable(1)
                    tblAcc.WidthPercentage = 100
                    Dim tblAcchead As PdfPCell = New PdfPCell()
                    tblAcchead.Colspan = 1
                    table.AddCell(tblAcchead) 'No pf Row

                    cell = New PdfPCell(New Paragraph("Product Received & Condition: " & strtxtAccessoryNote, Font2))
                    cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                    cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                    cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                    cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                    tblAcc.AddCell(cell)
                    doc.Add(tblAcc)
                End If

                'SingleLine = New Paragraph("")
                SingleLine = New Paragraph("", FontTitle)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("Problems reported by the customer")
                doc.Add(SingleLine)

                'SingleLine = New Paragraph("")
                'SingleLine.Alignment = Element.ALIGN_LEFT
                'SingleLine.Add("Details")
                'doc.Add(SingleLine)

                'SingleLine = New Paragraph("")
                'SingleLine.Alignment = Element.ALIGN_LEFT
                'SingleLine.Add(" ")
                'doc.Add(SingleLine)

                Dim tableDetails As PdfPTable = New PdfPTable(1)
                tableDetails.WidthPercentage = 100
                Dim tableDetailsheader As PdfPCell = New PdfPCell()
                tableDetailsheader.Colspan = 1
                tableDetails.AddCell(tableDetailsheader) 'No pf Row
                cell = New PdfPCell(New Paragraph(Trim(txtInvoiceNote.Text), Font2))
                tableDetails.AddCell(cell)
                doc.Add(tableDetails)

                'SingleLine = New Paragraph("")
                'SingleLine.Alignment = Element.ALIGN_LEFT
                'SingleLine.Add(" ")
                'doc.Add(SingleLine)

                SingleLine = New Paragraph("")
                SingleLine.Alignment = Element.ALIGN_LEFT
                Dim strAddText As String = ""
                If Trim(txtGNo.Text) <> "" And Trim(txtGSXCloseDate.Text) <> "" Then
                    strAddText = Trim(txtGSXCloseDate.Text)
                    strAddText = strAddText.Replace("/", "")
                    strAddText = " [ " & Trim(txtGNo.Text) & " " & strAddText & " ]"
                End If

                SingleLine = New Paragraph("", FontTitle)
                SingleLine.Add("Parts and service charges used for repairs " & strAddText & vbLf)
                doc.Add(SingleLine)

                SingleLine = New Paragraph("")
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)

                Dim table2 As PdfPTable = New PdfPTable(9)
                table2.WidthPercentage = 100
                Dim header2 As PdfPCell = New PdfPCell()
                header2.Colspan = 10
                table.AddCell(header2) 'No pf Row

                cell = New PdfPCell(New Paragraph("Parts No.", Font2))
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Parts Detail", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("Sales Price", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("Total", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("TaxableValue", Font2))
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Tax %", Font2))

                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("CGST", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("SGST", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("Total", Font2))
                table2.AddCell(cell)

                Dim SrNo As Integer = 0
                Dim TmpPercentage As Decimal = 0
                'Labour
                If Trim(txtLabourAmount.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(Trim(txtLabourAmount.Text), Font2))
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourDetail.Text), Font3))
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourSales.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourSales.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourSales.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    If Trim(txtLabourTax.Text) <> "" Then
                        If Decimal.TryParse(txtLabourTax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Labour Tax is invalid ( " & txtLabourTax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourCGST.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourSGST.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourTotal.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If



                If Trim(txtPartNo1.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(txtPartNo1.Text, Font2))
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtPartDetails1.Text, Font3))
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSalesPrice1.Text, Font2)) 'txtCost1
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSalesPrice1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSalesPrice1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    If Trim(txtPart1Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart1Tax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Part 1 Tax is invalid ( " & txtPart1Tax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)


                    cell = New PdfPCell(New Paragraph(txtCGST1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSGST1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtTotal1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                End If


                If Trim(txtPartNo2.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(txtPartNo2.Text, Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtPartDetails2.Text, Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice2.Text, Font2)) 'txtCost2
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSalesPrice2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    If Trim(txtPart2Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart2Tax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Part 2 Tax is invalid ( " & txtPart2Tax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtCGST2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSGST2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtTotal2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If


                If Trim(txtPartNo3.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(txtPartNo3.Text, Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtPartDetails3.Text, Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice3.Text, Font2)) 'txtCost3
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    If Trim(txtPart3Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart3Tax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Part 3 Tax is invalid ( " & txtPart3Tax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtCGST3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSGST3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtTotal3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If

                If Trim(txtPartNo4.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(txtPartNo4.Text, Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtPartDetails4.Text, Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice4.Text, Font2)) 'txtCost4
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    If Trim(txtPart4Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart4Tax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Part 4 Tax is invalid ( " & txtPart4Tax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtCGST4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSGST4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtTotal4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If


                If Trim(txtOtherDetail.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherDetail.Text, Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherCost.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherSales.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherSales.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    If Trim(txtOtherTax.Text) <> "" Then
                        If Decimal.TryParse(txtOtherTax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Other Tax is invalid ( " & txtOtherTax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtOtherCGST.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherSGST.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherTotal.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If



                Do While SrNo < 4
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                Loop


                cell = New PdfPCell(New Paragraph(".", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' Dim test = Convert.ToInt32(txtCGST1.Text) + Convert.ToInt32(txtCGST2.Text) + Convert.ToInt32(txtCGST3.Text) + Convert.ToInt32(txtCGST4.Text)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtTotalAmount.Text), Font2))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT

                table2.AddCell(cell)

                doc.Add(table2)

                Dim table3 As PdfPTable = New PdfPTable(6)
                table3.WidthPercentage = 100
                Dim header3 As PdfPCell = New PdfPCell()
                header3.Colspan = 1
                table.AddCell(header3) 'No pf Row
                cell = New PdfPCell(New Paragraph("Advance Received", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER

                table3.AddCell(cell)
                cell = New PdfPCell(New Paragraph(Trim(txtAdvance.Text)))
                ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table3.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Discount ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table3.AddCell(cell)

                cell = New PdfPCell(New Paragraph(Trim(txtDiscountAmount.Text)))
                ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table3.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Total Invoice", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table3.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtTotalAmount.Text))
                ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table3.AddCell(cell)

                doc.Add(table3)

                SingleLine = New Paragraph("")
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)

                Dim table4 As PdfPTable = New PdfPTable(1)
                table4.WidthPercentage = 100
                Dim header4 As PdfPCell = New PdfPCell()
                header4.Colspan = 1
                table.AddCell(header4) 'No pf Row

                Dim strMoneyText As String = ""

                If Trim(txtTotalAmount.Text) <> "" Then
                    strMoneyText = NumberToText(txtTotalAmount.Text)
                    cell = New PdfPCell(New Paragraph("Total Invoice(In Word) " & strMoneyText & " Only", Font2))
                Else
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                End If
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table4.AddCell(cell)

                doc.Add(table4)

                'SingleLine = New Paragraph("")
                'SingleLine.Alignment = Element.ALIGN_LEFT
                'SingleLine.Add(" ")
                'doc.Add(SingleLine)






                ''''''''Dim tblGsxNote As PdfPTable = New PdfPTable(1)
                ''''''''tblGsxNote.WidthPercentage = 100
                ''''''''Dim tblGsxNoteheader As PdfPCell = New PdfPCell()
                ''''''''tblGsxNoteheader.Colspan = 1
                ''''''''tblGsxNote.AddCell(tblGsxNoteheader) 'No pf Row
                ''''''''cell = New PdfPCell(New Paragraph(Trim(txtGsxNote.Text), Font2))
                ''''''''tblGsxNote.AddCell(cell)
                ''''''''doc.Add(tblGsxNote)

                ''''''''Dim FontChecked As Font = New Font(bf, 7, Font.NORMAL)

                ''''''''''''''''SingleLine = New Paragraph("")
                ''''''''''''''''SingleLine.Alignment = Element.ALIGN_LEFT
                ''''''''''''''''SingleLine.Add(" ")
                ''''''''''''''''doc.Add(SingleLine)

                ''''''''Dim tblChecked As PdfPTable = New PdfPTable(17)
                ''''''''tblChecked.WidthPercentage = 100
                ''''''''Dim intTblChkWidth2() As Integer = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}
                ''''''''tblChecked.SetWidths(intTblChkWidth2)

                '''''''''Dim chkheader As PdfPCell = New PdfPCell()
                '''''''''chkheader.Colspan = 2
                '''''''''tblChecked.AddCell(chkheader)

                ''''''''cell = New PdfPCell(New Paragraph(" ", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("FireWire", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("USB", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Camera", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Speaker", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Mouse / Trackpad", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Optical Drive", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Ethernet", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Display", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("HDD", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Airport", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("RAM", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Keyboard", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Bluetooth", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Battery", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Airport", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Adaptor", FontChecked))
                ''''''''tblChecked.AddCell(cell)

                ''''''''doc.Add(tblChecked)

                ''''''''tblChecked = New PdfPTable(17)
                ''''''''tblChecked.WidthPercentage = 100
                ''''''''tblChecked.SetWidths(intTblChkWidth2)

                '''''''''Dim imgSuare As Image = Image.GetInstance(SquareImage)
                '''''''''imgSuare.ScalePercent(6)
                '''''''''Dim SquareCheckBox As New Chunk(imgSuare, 0.1F, 0.1F)

                ''''''''Dim SquareCheckBox As New Paragraph(" ")
                ''''''''Dim SquareCheckBoxHeight As Integer = 10

                ''''''''cell = New PdfPCell(New Paragraph("Inward ", FontChecked))
                '''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''tblChecked.AddCell(cell)

                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)

                ''''''''doc.Add(tblChecked)

                ''''''''tblChecked = New PdfPTable(17)
                ''''''''tblChecked.WidthPercentage = 100
                ''''''''tblChecked.SetWidths(intTblChkWidth2)
                ''''''''cell = New PdfPCell(New Paragraph("Outward", FontChecked))
                '''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''tblChecked.AddCell(cell)

                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)

                ''''''''doc.Add(tblChecked)

                'Dim P25 As New Paragraph()
                SingleLine = New Paragraph("")
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)


                Dim table52 As PdfPTable = New PdfPTable(1)
                table52.WidthPercentage = 100
                Dim header52 As PdfPCell = New PdfPCell()
                header52.Colspan = 1
                table.AddCell(header52) 'No pf Row




                cell = New PdfPCell(New Paragraph("Estimate deadline and terms of use", FontTitle))
                'cell = New PdfPCell(New Paragraph("Estimate deadline and terms of use"))
                ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table52.AddCell(cell)


                doc.Add(table52)

                SingleLine = New Paragraph("", Font3)
                'Dim P18 As New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("If there is any change in symptoms during the repair process or if there is something wrong in ")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("the service estimate, the service estimate and its estimated amount are subject to change.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("Due to the above reasons, the billing amount can change.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("If the billing amount changes, GSS Quick Garage India Private Limited needs to get new consent from customer.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("There is a possibility that GSS Quick Garage India Private Limited calls customer to proceed with repair.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("GSS Quick Garage India Private Limited will not be responsible for any data loss, thus it is highly recommended to back up the data.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("Most repairs require an OS restore, thus all data will be erased.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("")
                SingleLine = New Paragraph("", Font2)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)

                Dim table5 As PdfPTable = New PdfPTable(2)
                table5.WidthPercentage = 100
                Dim header5 As PdfPCell = New PdfPCell()
                header5.Colspan = 1
                table.AddCell(header5) 'No pf Row


                ' cell = New PdfPCell(New Paragraph("  Received by", Font2))
                cell = New PdfPCell(New Paragraph(" ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table5.AddCell(cell)
                cell = New PdfPCell(New Paragraph("                 Customer Signature", Font2))
                'cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table5.AddCell(cell)

                doc.Add(table5)

                SingleLine = New Paragraph("", Font2)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)


                Dim table6 As PdfPTable = New PdfPTable(1)
                table6.WidthPercentage = 100
                Dim header6 As PdfPCell = New PdfPCell()
                header6.Colspan = 4
                table6.AddCell(header6) 'No pf Row
                cell = New PdfPCell(New Paragraph("For GSS QuickGarage India Pvt Ltd", Font2))
                'cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table6.AddCell(cell)



                'Empty Row
                cell = New PdfPCell(New Paragraph(" "))
                'cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table6.AddCell(cell)






                'table6.AddCell("For GSS QuickGarage India Pvt Ltd")
                cell = New PdfPCell(New Paragraph("                                                                           Authorized Signatory                                                           E.&O.E.", Font2))
                ' cell = New PdfPCell(New Paragraph("                                                                                Authorized Signatory                                                                        E.&O.E.", Font2))
                'cell = New PdfPCell(New Paragraph("Authorized Signatory                                                                                                             E.&O.E.", Font2))
                'cell.HorizontalAlignment = Element.ALIGN_RIGHT
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                table6.AddCell(cell)
                doc.Add(table6)



                doc.Close()

                '*************************************
                'Esitmte Date & Time update
                '*************************************
                ''''''''''Dim str As String

                ''''''''''Dim ShipName As String = Session("ship_Name")
                ''''''''''Dim shipCode As String = Session("ship_code")
                ''''''''''Dim userName As String = Session("user_Name")
                ''''''''''Dim userid As String = Session("user_id")


                ''''''''''Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
                ''''''''''Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
                ''''''''''_AppleQmvOrdModel.UserId = userid
                ''''''''''_AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode
                ''''''''''_AppleQmvOrdModel.SHIP_TO_BRANCH = ShipName
                ''''''''''_AppleQmvOrdModel.PO_NO = txtPoNo.Text
                ''''''''''_AppleQmvOrdModel.G_NO = txtGNo.Text
                ''''''''''_AppleQmvOrdModel.ESTIMATE_DATE = txtEstimatedDate.Text
                ''''''''''_AppleQmvOrdModel.ESTIMATE_TIME = Now.ToShortTimeString


                ''''''''''Dim blStatus As Boolean = False

                ''''''''''blStatus = _AppleQmvOrdControl.UpdateEstimate(_AppleQmvOrdModel)

                ''''''''''If blStatus = False Then
                ''''''''''    Call showMsg("Estimate Date updation Error", "")
                ''''''''''    Exit Sub
                ''''''''''End If

            Catch ex As Exception
                'errFlg = 1
            Finally
                If fileStream IsNot Nothing Then
                    fileStream.Close()
                End If
            End Try

            Call FileDownload(fname, "application/pdf")

        End If

    End Sub

    Sub CalcEstimateSaveWithoutInventory(srcFunction As String)
        If (drpServiceType.SelectedItem.Value = "4") Or (drpServiceType.SelectedItem.Value = "5") Then
            If Trim(txtLabourAmount.Text) <> "" Then
                Call showMsg("Labour Is Not Allowed For Sales / Accessories", "")
                Exit Sub
            End If
            'Modified on 2021/06/08 Mandatory

            Dim strMandatoryText As String = ""

            txtCustomerName.Text = Trim(txtCustomerName.Text)
            txtAddressLine1.Text = Trim(txtAddressLine1.Text)
            txtAddressLine2.Text = Trim(txtAddressLine2.Text)
            txtCity.Text = Trim(txtCity.Text)
            txtState.Text = Trim(txtState.Text)
            txtStateShip.Text = Trim(txtStateShip.Text)
            txtEmail.Text = Trim(txtEmail.Text)
            txtMobile.Text = Trim(txtMobile.Text)
            txtGsxNote.Text = Trim(txtGsxNote.Text)





            If Len(Trim(txtCustomerName.Text)) < 3 Then
                strMandatoryText = "Customer Name <br>"
            End If
            If Len(Trim(txtAddressLine1.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "Address Line 1 <br>"
            End If
            'If Len(Trim(txtAddressLine2.Text)) < 3 Then
            '    strMandatoryText = "Address Line 2 <br>"
            'End If
            If Len(Trim(txtCity.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "City <br>"
            End If
            If Len(Trim(txtState.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "State <br>"
            End If
            If Len(Trim(txtZip.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "Postal Code <br>"
            End If

            'If Len(Trim(txtEmail.Text)) < 3 Then
            '    strMandatoryText = "Email ID <br>"
            'End If

            If Len(Trim(txtMobile.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "Mobile <br>"
            End If

            If Len(Trim(txtGsxNote.Text)) < 3 Then
                strMandatoryText = strMandatoryText & "GSX Note <br>"
            End If


            Dim blSalesMadatory As Boolean = False
            If (Len(Trim(txtPartNo1.Text)) > 1) Then
                blSalesMadatory = True
            End If

            If blSalesMadatory = False Then
                If (Len(Trim(txtPartNo2.Text)) > 1) Then
                    blSalesMadatory = True
                End If
            End If
            If blSalesMadatory = False Then
                If (Len(Trim(txtPartNo3.Text)) > 1) Then
                    blSalesMadatory = True
                End If
            End If
            If blSalesMadatory = False Then
                If (Len(Trim(txtPartNo4.Text)) > 1) Then
                    blSalesMadatory = True
                End If
            End If
            If blSalesMadatory = False Then
                If (Len(Trim(txtOtherDetail.Text)) > 1) Then
                    blSalesMadatory = True
                End If
            End If

            If blSalesMadatory = False Then
                strMandatoryText = strMandatoryText & "Part Number is Empty <br>"
            End If


            If Len(strMandatoryText) > 3 Then
                'Call showMsg("The following is mandatory  " & strMandatoryText, "")
                'Exit Sub
                Call showMsg("The following field(s) are mandatory for Sales / Accessories ...<br><br>" & strMandatoryText, "")
                Exit Sub
            End If

        End If

        Dim strPartsSalesNotFound As String = ""

        If (srcFunction = "btncalc") Or (srcFunction = "btnestimate") Then
            If Trim(txtPoNo.Text) = "" Then
                Call showMsg("Po No is invalid ", "")
                Exit Sub
            End If

            Dim Editable As String = ""
            Editable = Request.QueryString("E")

            If Editable = "yes" Then
                EditableAction()
            End If

            Dim clsSet As New Class_money

            Dim blPriceCheckFailure As Boolean = False
            Dim FailureText As String = ""

            Dim blPartEntered As Boolean = False

            Dim Sgst As Decimal = 9.0
            Dim Igst As Decimal = 0.0
            Dim Cgst As Decimal = 9.0

            Dim Qty As Decimal = 0.00

            Dim PriceCost As Decimal = 0.00
            Dim Discount As Decimal = 0.00
            Dim SalesPrice As Decimal = 0.00

            Dim PartSgst As Decimal = 0.00
            Dim PartIgst As Decimal = 0.0
            Dim PartCgst As Decimal = 0.0
            Dim PartTotal As Decimal = 0.00


            Dim LabourCost As Decimal = 0.00
            Dim LabourDiscount As Decimal = 0.00
            Dim LabourSales As Decimal = 0.00
            Dim LabourSgst As Decimal = 0.00
            Dim LabourIgst As Decimal = 0.0
            Dim LabourCgst As Decimal = 0.0
            Dim LabourTotal As Decimal = 0.00
            Dim LabourTax As Decimal = 0.00

            Dim DefaultTax As Decimal = 9.0

            Dim Qtys As Decimal = 0.00
            Dim Discounts As Decimal = 0.00
            Dim SalesPrices As Decimal = 0.00
            Dim PartTax As Decimal = 0.00
            Dim PartDiscounts As Decimal = 0.00
            Dim PartSgsts As Decimal = 0.00
            Dim PartIgsts As Decimal = 0.00
            Dim PartCgsts As Decimal = 0.00
            Dim PartTotals As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00
            'Dim partsAmountQty As Decimal = 0.00

            Dim tmpSalesPrice As Decimal = 0.00

            Dim dtApple As DataTable
            'Verify Labour Amount
            Dim strLabourValue As String = ""
            'strLabourValue = drpLabourAmount.SelectedItem.Value
            'If strLabourValue = "-1" Then
            '    'if LabourCost not entered 
            '    If (txtLabourCost.Text = "") Then 'And (txtLabourSales.Text = "")
            '        Call showMsg("Labour Price Not Selected or Not Entered In Labour Cost", "")
            '        Exit Sub
            '    End If
            '    'Validate Labour cost is decimal 
            '    If Decimal.TryParse(txtLabourCost.Text, LabourCost) Then
            '    Else
            '        Call showMsg("Labour cost is invalid ", "")
            '        Exit Sub
            '    End If



            'Empty Before Calculation 
            If Editable <> "yes" Then
                txtLabourCost.Text = ""
                txtLabourDetail.Text = ""
                'txtLabourDiscount.Text = ""
                txtLabourCost.Text = ""
                txtLabourSales.Text = ""
                txtLabourTax.Text = ""
                txtLabourSGST.Text = ""
                txtLabourCGST.Text = ""
                txtLabourIGST.Text = ""
                txtLabourTotal.Text = ""

                txtPartDetails1.Text = ""
                txtHsnSac1.Text = ""
                txtCost1.Text = ""
                txtSalesPrice1.Text = ""
                txtPart1Tax.Text = ""
                txtSGST1.Text = ""
                txtCGST1.Text = ""
                txtIGST1.Text = ""
                txtTotal1.Text = ""


                txtPartDetails2.Text = ""
                txtHsnSac2.Text = ""
                txtCost2.Text = ""
                txtSalesPrice2.Text = ""
                txtPart2Tax.Text = ""
                txtSGST2.Text = ""
                txtCGST2.Text = ""
                txtIGST2.Text = ""
                txtTotal2.Text = ""

                txtPartDetails3.Text = ""
                txtHsnSac3.Text = ""
                txtCost3.Text = ""
                txtSalesPrice3.Text = ""
                txtPart3Tax.Text = ""
                txtSGST3.Text = ""
                txtCGST3.Text = ""
                txtIGST3.Text = ""
                txtTotal3.Text = ""


                txtPartDetails4.Text = ""
                txtHsnSac4.Text = ""
                txtCost4.Text = ""
                txtSalesPrice4.Text = ""
                txtPart4Tax.Text = ""
                txtSGST4.Text = ""
                txtCGST4.Text = ""
                txtIGST4.Text = ""
                txtTotal4.Text = ""

                txtOtherSales.Text = ""
                'txtOtherTax.Text = ""
                txtOtherSGST.Text = ""
                txtOtherCGST.Text = ""
                txtOtherIGST.Text = ""
                txtOtherTotal.Text = ""
            End If


            strLabourValue = txtLabourAmount.Text
            If Trim(txtLabourAmount.Text) = "" Then
                'if LabourCost not entered 
                ' If (txtLabourCost.Text = "") Then 'And (txtLabourSales.Text = "")
                If (drpServiceType.SelectedItem.Value <> "4") And (drpServiceType.SelectedItem.Value <> "5") Then
                    Call showMsg("Labour Parts No is not entered", "")
                    Exit Sub
                End If
                'End If

            Else

                'Validate Labour cost is decimal 
                'If Decimal.TryParse(txtLabourAmount.Text, LabourCost) Then
                'Else
                '    Call showMsg("Labour cost is invalid ", "")
                '    Exit Sub
                'End If

                'txtLabourCost.Text = LabourCost

                If Editable = "yes" Then
                    If Decimal.TryParse(txtLabourCost.Text, LabourCost) Then
                    Else
                        Call showMsg("Labour cost is invalid ", "")
                        Exit Sub
                    End If
                Else



                    Dim _AppleLabourModel As AppleLabourModel = New AppleLabourModel()
                    Dim _AppleLabourControl As AppleLabourControl = New AppleLabourControl()
                    _AppleLabourModel.PART_NO = strLabourValue
                    dtApple = _AppleLabourControl.SelectLabourPrice(_AppleLabourModel)
                    If (dtApple Is Nothing) Or (dtApple.Rows.Count = 0) Then
                        Call showMsg("Labour Price Not Defined ( " & txtLabourAmount.Text & ")", "")
                        Exit Sub
                    Else

                        If Not IsDBNull(dtApple.Rows(0)("amount_150")) Then
                            txtLabourCost.Text = clsSet.setINR(dtApple.Rows(0)("amount_150"))
                        End If
                        'Validate Labour cost is decimal 
                        If Decimal.TryParse(txtLabourCost.Text, LabourCost) Then
                        Else
                            Call showMsg("Labour cost is invalid ", "")
                            Exit Sub
                        End If



                        If Not IsDBNull(dtApple.Rows(0)("amount_150")) Then
                            txtLabourSales.Text = clsSet.setINR(dtApple.Rows(0)("amount_150"))
                        End If
                        'Validate Labour Sales cost is decimal 
                        If Decimal.TryParse(txtLabourSales.Text, LabourSales) Then
                        Else
                            Call showMsg("Labour Sales cost is invalid ", "")
                            Exit Sub
                        End If

                        If (drpServiceType.SelectedItem.Value = "1") Or (drpServiceType.SelectedItem.Value = "3") Then
                            '1 IW , 3 - AppleCareProtection
                            txtLabourSales.Text = clsSet.setINR(0)
                            LabourSales = 0
                        End If


                        If Not IsDBNull(dtApple.Rows(0)("LABOUR_DETAILS")) Then
                            txtLabourDetail.Text = dtApple.Rows(0)("LABOUR_DETAILS")
                        End If

                        ''Validate Labour LabourSales is decimal 
                        'If Decimal.TryParse(txtLabourSales.Text, LabourSales) Then
                        'Else
                        '    Call showMsg("Labour sales cost is invalid ", "")
                        '    Exit Sub
                        'End If
                    End If
                End If

            End If





            If Trim(txtLabourDiscount.Text) <> "" Then
                'Validate Labour cost is decimal 
                If Decimal.TryParse(txtLabourDiscount.Text, LabourDiscount) Then
                Else
                    Call showMsg("Labour Discount is invalid ", "")
                    Exit Sub
                End If
                txtLabourDiscount.Text = clsSet.setINR(LabourDiscount)
            End If


            'Tax
            If txtLabourTax.Text = "" Then
                txtLabourTax.Text = DefaultTax
            End If


            If Trim(txtLabourTax.Text) <> "" Then
                'Validate Labour cost is decimal 
                If Decimal.TryParse(txtLabourTax.Text, LabourTax) Then
                Else
                    Call showMsg("Labour Tax is invalid ", "")
                    Exit Sub
                End If
                txtLabourTax.Text = clsSet.setINR(LabourTax)
            End If

            Sgst = LabourTax
            Cgst = LabourTax



            LabourCost = LabourCost
            LabourSales = LabourSales
            LabourSales = LabourSales - LabourDiscount
            LabourSgst = LabourSales / 100 * Sgst
            LabourIgst = LabourSales / 100 * Igst
            LabourCgst = LabourSales / 100 * Cgst
            LabourTotal = LabourSales + LabourSgst + LabourIgst + LabourCgst

            txtLabourCost.Text = clsSet.setINR(LabourCost)
            txtLabourSales.Text = clsSet.setINR(LabourSales)
            txtLabourSGST.Text = clsSet.setINR(LabourSgst)
            txtLabourCGST.Text = clsSet.setINR(LabourCgst)
            txtLabourIGST.Text = clsSet.setINR(LabourIgst)
            txtLabourTotal.Text = clsSet.setINR(LabourTotal)



            Dim _ApplePartsModel As ApplePartsModel = New ApplePartsModel()
            Dim _ApplePartsControl As ApplePartsControl = New ApplePartsControl()
            Dim dtApplePart As DataTable

            Dim _ApplePartsEntryControl As ApplePartsEntryControl = New ApplePartsEntryControl()
            Dim _ApplePartsEntryModel As ApplePartsEntryModel = New ApplePartsEntryModel()
            Dim intStock As Integer = 0
            'Part1
            If Trim(txtPartNo1.Text) <> "" Then
                '1st Validate Qty
                Qty = 0.00
                If Decimal.TryParse(txtQty1.Text, Qty) Then
                    Qtys = Qtys + Qty
                Else
                    Call showMsg("Quantity is invalid for Parts No1 ( " & txtQty1.Text & ")", "")
                    Exit Sub
                End If

                Discount = 0.00
                If Trim(txtDiscount1.Text) <> "" Then
                    If Decimal.TryParse(txtDiscount1.Text, Discount) Then
                        Discounts = Discounts + Discount
                    Else
                        Call showMsg("Discount is invalid for Parts No1 ( " & txtDiscount1.Text & ")", "")
                        Exit Sub
                    End If
                    txtDiscount1.Text = clsSet.setINR(Discount)
                End If


                blPartEntered = True

                If Editable = "yes" Then

                    If Trim(txtCost1.Text) <> "" Then
                        If Decimal.TryParse(txtCost1.Text, PriceCost) Then

                        Else
                            Call showMsg("Price Cost is invalid for Parts No1 ( " & txtCost1.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtSalesPrice1.Text) <> "" Then
                        If Decimal.TryParse(txtSalesPrice1.Text, SalesPrice) Then

                        Else
                            Call showMsg("Sales Price is invalid for Parts No1 ( " & txtSalesPrice1.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtPart1Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart1Tax.Text, PartTax) Then

                        Else
                            Call showMsg("Tax is invalid for Parts No1 ( " & txtPart1Tax.Text & ")", "")
                            Exit Sub
                        End If
                        txtPart1Tax.Text = clsSet.setINR(PartTax)
                    End If
                Else


                    '********************
                    'Apple Parts / ACC Parts
                    '*******************
                    'ACC Parts
                    If (drpServiceType.SelectedItem.Value = "5") Then

                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo1.Text)
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo1.Text)
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("CURRENT_IN_STOCK")) Then
                                intStock = dtApplePart.Rows(0)("CURRENT_IN_STOCK")
                            End If
                            If (txtQty1.Text > intStock) Then
                                Call showMsg(txtPartNo1.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("DESCRIPTION")) Then
                                txtPartDetails1.Text = dtApplePart.Rows(0)("DESCRIPTION")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("UPC_EAN")) Then
                                txtHsnSac1.Text = dtApplePart.Rows(0)("UPC_EAN")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PURCHASE_PRICE")) Then
                                txtCost1.Text = dtApplePart.Rows(0)("PURCHASE_PRICE")
                                PriceCost = dtApplePart.Rows(0)("PURCHASE_PRICE")
                            Else
                                txtCost1.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts cost is decimal 
                            If Decimal.TryParse(txtCost1.Text, PriceCost) Then
                            Else
                                Call showMsg("Part1 Cost is invalid ", "")
                                Exit Sub
                            End If
                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice1.Text = 0
                                SalesPrice = 0

                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = "* " & txtPartNo1.Text & "<br>"
                                            txtSalesPrice1.Text = txtCost1.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice1.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice1.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart1Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart1Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart1Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart1Tax.Text, PartTax) Then
                                Else
                                    Call showMsg("Tax is invalid for Parts No1 ( " & txtPart1Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart1Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    Else ' Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo1.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt1.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            blPriceCheckFailure = True
                            FailureText = Trim(txtPartNo1.Text)
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails1.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac1.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost1.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost1.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts cost is decimal 
                            If Decimal.TryParse(txtCost1.Text, PriceCost) Then
                            Else
                                Call showMsg("Part1 Cost is invalid ", "")
                                Exit Sub
                            End If
                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice1.Text = 0
                                SalesPrice = 0

                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = "* " & txtPartNo1.Text & "<br>"
                                            txtSalesPrice1.Text = txtCost1.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice1.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice1.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart1Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart1Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart1Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart1Tax.Text, PartTax) Then
                                Else
                                    Call showMsg("Tax is invalid for Parts No1 ( " & txtPart1Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart1Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If
                    End If
                End If





                Sgst = PartTax
                Cgst = PartTax
                '20210822
                'tmpSalesPrice = (Qty * PriceCost) - Discount
                tmpSalesPrice = (Qty * SalesPrice) - Discount
                txtSalesPrice1.Text = tmpSalesPrice
                txtDiscount1.Text = clsSet.setINR(Discount)

                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSalesPrice1.Text = clsSet.setINR(tmpSalesPrice)

                txtSGST1.Text = clsSet.setINR(PartSgst)
                txtCGST1.Text = clsSet.setINR(PartCgst)
                txtIGST1.Text = clsSet.setINR(PartIgst)
                txtTotal1.Text = clsSet.setINR(PartTotal)

                SalesPrices = tmpSalesPrice
                PartSgsts = PartSgst
                PartIgsts = PartIgst
                PartCgsts = PartCgst
                PartTotals = PartTotal



            End If

            'Part2
            If Trim(txtPartNo2.Text) <> "" Then
                '1st Validate Qty
                Qty = 0.00
                If Decimal.TryParse(txtQty2.Text, Qty) Then
                    Qtys = Qtys + Qty
                Else
                    Call showMsg("Quantity is invalid for Parts No2 ( " & txtQty2.Text & ")", "")
                    Exit Sub
                End If
                Discount = 0.00
                If Trim(txtDiscount2.Text) <> "" Then
                    If Decimal.TryParse(txtDiscount2.Text, Discount) Then
                        Discounts = Discounts + Discount
                    Else
                        Call showMsg("Discount is invalid for Parts No2 ( " & txtDiscount2.Text & ")", "")
                        Exit Sub
                    End If
                    txtDiscount2.Text = clsSet.setINR(Discount)
                End If

                blPartEntered = True
                If Editable = "yes" Then
                    If Trim(txtCost2.Text) <> "" Then
                        If Decimal.TryParse(txtCost2.Text, PriceCost) Then

                        Else
                            Call showMsg("Price Cost is invalid for Parts No2 ( " & txtCost2.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtSalesPrice2.Text) <> "" Then
                        If Decimal.TryParse(txtSalesPrice2.Text, SalesPrice) Then

                        Else
                            Call showMsg("Sales Price is invalid for Parts No2 ( " & txtSalesPrice2.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtPart2Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart2Tax.Text, PartTax) Then

                        Else
                            Call showMsg("Tax is invalid for Parts No2 ( " & txtPart2Tax.Text & ")", "")
                            Exit Sub
                        End If
                        txtPart2Tax.Text = clsSet.setINR(PartTax)
                    End If
                Else
                    '********************
                    'Apple Parts / ACC Parts
                    '*******************
                    'ACC Parts
                    If (drpServiceType.SelectedItem.Value = "5") Then
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo2.Text)
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo2.Text)
                            Else
                                FailureText = Trim(txtPartNo2.Text)
                            End If
                        Else

                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("CURRENT_IN_STOCK")) Then
                                intStock = dtApplePart.Rows(0)("CURRENT_IN_STOCK")
                            End If
                            If (txtQty2.Text > intStock) Then
                                Call showMsg(txtPartNo2.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If


                            If Not IsDBNull(dtApplePart.Rows(0)("DESCRIPTION")) Then
                                txtPartDetails2.Text = dtApplePart.Rows(0)("DESCRIPTION")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("UPC_EAN")) Then
                                txtHsnSac2.Text = dtApplePart.Rows(0)("UPC_EAN")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PURCHASE_PRICE")) Then
                                txtCost2.Text = dtApplePart.Rows(0)("PURCHASE_PRICE")
                                PriceCost = dtApplePart.Rows(0)("PURCHASE_PRICE")
                            Else
                                txtCost2.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 2 cost is decimal 
                            If Decimal.TryParse(txtCost2.Text, PriceCost) Then
                            Else
                                Call showMsg("Part2 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice2.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo2.Text & "<br>"
                                            txtSalesPrice2.Text = txtCost2.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice2.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice2.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart2Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart2Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart2Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart2Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No2 ( " & txtPart2Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart2Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If
                    Else 'Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo2.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt2.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo2.Text)
                            Else
                                FailureText = Trim(txtPartNo2.Text)
                            End If
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails2.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac2.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost2.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost2.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 2 cost is decimal 
                            If Decimal.TryParse(txtCost2.Text, PriceCost) Then
                            Else
                                Call showMsg("Part2 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice2.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo2.Text & "<br>"
                                            txtSalesPrice2.Text = txtCost2.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice2.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice2.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart2Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart2Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart2Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart2Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No2 ( " & txtPart2Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart2Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If


                    End If



                End If


                Sgst = PartTax
                Cgst = PartTax

                '20210822
                'tmpSalesPrice = (Qty * PriceCost) - Discount
                tmpSalesPrice = (Qty * SalesPrice) - Discount
                txtSalesPrice2.Text = clsSet.setINR(tmpSalesPrice)
                txtDiscount2.Text = clsSet.setINR(Discount)

                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST2.Text = clsSet.setINR(PartSgst)
                txtCGST2.Text = clsSet.setINR(PartCgst)
                txtIGST2.Text = clsSet.setINR(PartIgst)
                txtTotal2.Text = clsSet.setINR(PartTotal)

                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartCgst
                PartCgsts = PartCgsts + PartIgst
                PartTotals = PartTotals + PartTotal


            End If

            'Part3
            If Trim(txtPartNo3.Text) <> "" Then
                Qty = 0.00
                If Decimal.TryParse(txtQty3.Text, Qty) Then
                    Qtys = Qtys + Qty
                Else
                    Call showMsg("Quantity is invalid for Parts No3 ( " & txtQty3.Text & ")", "")
                    Exit Sub
                End If
                Discount = 0.00
                If Trim(txtDiscount3.Text) <> "" Then
                    If Decimal.TryParse(txtDiscount3.Text, Discount) Then
                        Discounts = Discounts + Discount
                    Else
                        Call showMsg("Discount is invalid for Parts No3 ( " & txtDiscount3.Text & ")", "")
                        Exit Sub
                    End If
                    txtDiscount3.Text = clsSet.setINR(Discount)
                End If

                blPartEntered = True
                If Editable = "yes" Then
                    If Trim(txtCost3.Text) <> "" Then
                        If Decimal.TryParse(txtCost3.Text, PriceCost) Then

                        Else
                            Call showMsg("Price Cost is invalid for Parts No3 ( " & txtCost3.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtSalesPrice3.Text) <> "" Then
                        If Decimal.TryParse(txtSalesPrice3.Text, SalesPrice) Then

                        Else
                            Call showMsg("Sales Price is invalid for Parts No3 ( " & txtSalesPrice3.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtPart3Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart3Tax.Text, PartTax) Then
                        Else
                            Call showMsg("Tax is invalid for Parts No3 ( " & txtPart3Tax.Text & ")", "")
                            Exit Sub
                        End If
                        txtPart3Tax.Text = clsSet.setINR(PartTax)
                    End If
                Else


                    '********************
                    'Apple Parts / ACC Parts
                    '*******************
                    'ACC Parts
                    If (drpServiceType.SelectedItem.Value = "5") Then
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo3.Text)
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo3.Text)
                            Else
                                FailureText = Trim(txtPartNo3.Text)
                            End If
                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("CURRENT_IN_STOCK")) Then
                                intStock = dtApplePart.Rows(0)("CURRENT_IN_STOCK")
                            End If
                            If (txtQty3.Text > intStock) Then
                                Call showMsg(txtPartNo3.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("DESCRIPTION")) Then
                                txtPartDetails3.Text = dtApplePart.Rows(0)("DESCRIPTION")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("UPC_EAN")) Then
                                txtHsnSac3.Text = dtApplePart.Rows(0)("UPC_EAN")
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("PURCHASE_PRICE")) Then
                                txtCost3.Text = dtApplePart.Rows(0)("PURCHASE_PRICE")
                                PriceCost = dtApplePart.Rows(0)("PURCHASE_PRICE")
                            Else
                                txtCost3.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 3 cost is decimal 
                            If Decimal.TryParse(txtCost3.Text, PriceCost) Then
                            Else
                                Call showMsg("Part3 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice3.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo3.Text & "<br>"
                                            txtSalesPrice3.Text = txtCost3.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice3.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice3.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart3Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart3Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart3Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart3Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No3 ( " & txtPart3Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart3Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    Else 'Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo3.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt3.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo3.Text)
                            Else
                                FailureText = Trim(txtPartNo3.Text)
                            End If
                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails3.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac3.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost3.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost3.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 3 cost is decimal 
                            If Decimal.TryParse(txtCost3.Text, PriceCost) Then
                            Else
                                Call showMsg("Part3 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice3.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo3.Text & "<br>"
                                            txtSalesPrice3.Text = txtCost3.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice3.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice3.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart3Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart3Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart3Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart3Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No3 ( " & txtPart3Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart3Tax.Text = clsSet.setINR(PartTax)
                            End If
                        End If

                    End If

                End If


                Sgst = PartTax
                Cgst = PartTax

                '20210822
                'tmpSalesPrice = (Qty * PriceCost) - Discount

                tmpSalesPrice = (Qty * SalesPrice) - Discount
                txtSalesPrice3.Text = clsSet.setINR(tmpSalesPrice)
                txtDiscount3.Text = clsSet.setINR(Discount)

                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST3.Text = clsSet.setINR(PartSgst)
                txtCGST3.Text = clsSet.setINR(PartCgst)
                txtIGST3.Text = clsSet.setINR(PartIgst)
                txtTotal3.Text = clsSet.setINR(PartTotal)

                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartIgst
                PartCgsts = PartCgsts + PartCgst
                PartTotals = PartTotals + PartTotal
            End If




            'Part4
            If Trim(txtPartNo4.Text) <> "" Then
                Qty = 0.00
                If Decimal.TryParse(txtQty4.Text, Qty) Then
                    Qtys = Qtys + Qty
                Else
                    Call showMsg("Quantity is invalid for Parts No4 ( " & txtQty4.Text & ")", "")
                    Exit Sub
                End If
                Discount = 0.00
                If Trim(txtDiscount4.Text) <> "" Then
                    If Decimal.TryParse(txtDiscount4.Text, Discount) Then
                        Discounts = Discounts + Discount
                    Else
                        Call showMsg("Discount is invalid for Parts No4 ( " & txtDiscount4.Text & ")", "")
                        Exit Sub
                    End If
                    txtDiscount4.Text = clsSet.setINR(Discount)
                End If

                blPartEntered = True

                If Editable = "yes" Then
                    If Trim(txtCost4.Text) <> "" Then
                        If Decimal.TryParse(txtCost4.Text, PriceCost) Then

                        Else
                            Call showMsg("Price Cost is invalid for Parts No4 ( " & txtCost4.Text & ")", "")
                            Exit Sub
                        End If
                    End If
                    If Trim(txtSalesPrice4.Text) <> "" Then
                        If Decimal.TryParse(txtSalesPrice4.Text, SalesPrice) Then

                        Else
                            Call showMsg("Sales Price is invalid for Parts No4 ( " & txtSalesPrice4.Text & ")", "")
                            Exit Sub
                        End If
                    End If

                    If Trim(txtPart4Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart4Tax.Text, PartTax) Then

                        Else
                            Call showMsg("Tax is invalid for Parts No4 ( " & txtPart4Tax.Text & ")", "")
                            Exit Sub
                        End If
                        txtPart4Tax.Text = clsSet.setINR(PartTax)
                    End If


                Else


                    '********************
                    'Apple Parts / ACC Parts
                    '*******************
                    'ACC Parts
                    If (drpServiceType.SelectedItem.Value = "5") Then
                        _ApplePartsEntryModel.PART_NO = Trim(txtPartNo4.Text)
                        dtApplePart = _ApplePartsEntryControl.SelectPartsnStock(_ApplePartsEntryModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo4.Text)
                            Else
                                FailureText = Trim(txtPartNo4.Text)
                            End If

                        Else
                            'Verify Stock in Hand
                            intStock = 0
                            If Not IsDBNull(dtApplePart.Rows(0)("CURRENT_IN_STOCK")) Then
                                intStock = dtApplePart.Rows(0)("CURRENT_IN_STOCK")
                            End If
                            If (txtQty4.Text > intStock) Then
                                Call showMsg(txtPartNo4.Text & " - Stock is available " & intStock.ToString(), "")
                                Exit Sub
                            End If

                            If Not IsDBNull(dtApplePart.Rows(0)("DESCRIPTION")) Then
                                txtPartDetails4.Text = dtApplePart.Rows(0)("DESCRIPTION")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("UPC_EAN")) Then
                                txtHsnSac4.Text = dtApplePart.Rows(0)("UPC_EAN")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PURCHASE_PRICE")) Then
                                txtCost4.Text = dtApplePart.Rows(0)("PURCHASE_PRICE")
                                PriceCost = dtApplePart.Rows(0)("PURCHASE_PRICE")
                            Else
                                txtCost4.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 4 cost is decimal 
                            If Decimal.TryParse(txtCost4.Text, PriceCost) Then
                            Else
                                Call showMsg("Part4 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice4.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo4.Text & "<br>"
                                            txtSalesPrice4.Text = txtCost4.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice4.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice4.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart4Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart4Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart4Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart4Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No4 ( " & txtPart4Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart4Tax.Text = clsSet.setINR(PartTax)
                            End If

                        End If


                    Else 'Apple Parts
                        _ApplePartsModel.PARTS_NO = Trim(txtPartNo4.Text)
                        _ApplePartsModel.PRICE_OPTION = drpSt4.SelectedItem.Text
                        dtApplePart = _ApplePartsControl.SelectPriceTop1(_ApplePartsModel)
                        If (dtApplePart Is Nothing) Or (dtApplePart.Rows.Count = 0) Then
                            'Call showMsg("The price does not exist (" & txtPartNo1.Text.Trim & ") !!!", "")
                            'Exit Sub
                            blPriceCheckFailure = True
                            If Len(FailureText) > 1 Then
                                FailureText = FailureText & "<br>" & Trim(txtPartNo4.Text)
                            Else
                                FailureText = Trim(txtPartNo4.Text)
                            End If

                        Else
                            If Not IsDBNull(dtApplePart.Rows(0)("PARTS_DETAIL")) Then
                                txtPartDetails4.Text = dtApplePart.Rows(0)("PARTS_DETAIL")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("HSN_SAC")) Then
                                txtHsnSac4.Text = dtApplePart.Rows(0)("HSN_SAC")
                            End If
                            If Not IsDBNull(dtApplePart.Rows(0)("PRICE_COST")) Then
                                txtCost4.Text = dtApplePart.Rows(0)("PRICE_COST")
                                PriceCost = dtApplePart.Rows(0)("PRICE_COST")
                            Else
                                txtCost4.Text = 0
                                PriceCost = 0
                            End If
                            'Validate Parts 4 cost is decimal 
                            If Decimal.TryParse(txtCost4.Text, PriceCost) Then
                            Else
                                Call showMsg("Part4 Cost is invalid ", "")
                                Exit Sub
                            End If

                            'Begin
                            If (drpServiceType.SelectedItem.Value = "1") Then
                                txtSalesPrice4.Text = 0
                                SalesPrice = 0
                            ElseIf (drpServiceType.SelectedItem.Value = "3") Then
                                'AC+ , Always parts Price Zero, Some of them Excluded, need to charge
                                If Not IsDBNull(dtApplePart.Rows(0)("AC_PLUS_APPLICABLE")) Then
                                    If dtApplePart.Rows(0)("AC_PLUS_APPLICABLE") = 0 Then
                                        If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                            txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                            SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                        Else
                                            strPartsSalesNotFound = strPartsSalesNotFound & "* " & txtPartNo4.Text & "<br>"
                                            txtSalesPrice4.Text = txtCost4.Text
                                            SalesPrice = PriceCost
                                        End If
                                    Else
                                        txtSalesPrice4.Text = 0
                                        SalesPrice = 0
                                    End If
                                Else
                                    txtSalesPrice4.Text = 0
                                    SalesPrice = 0
                                End If
                            Else
                                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                                    txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                                End If
                            End If
                            'End

                            If Not IsDBNull(dtApplePart.Rows(0)("PART_TAX")) Then
                                txtPart4Tax.Text = dtApplePart.Rows(0)("PART_TAX")
                            Else
                                txtPart4Tax.Text = DefaultTax
                            End If
                            If Trim(txtPart4Tax.Text) <> "" Then
                                If Decimal.TryParse(txtPart4Tax.Text, PartTax) Then

                                Else
                                    Call showMsg("Tax is invalid for Parts No4 ( " & txtPart4Tax.Text & ")", "")
                                    Exit Sub
                                End If
                                txtPart4Tax.Text = clsSet.setINR(PartTax)
                            End If

                        End If



                    End If








                End If



                Sgst = PartTax
                Cgst = PartTax

                '20210822
                'tmpSalesPrice = (Qty * PriceCost) - Discount
                tmpSalesPrice = (Qty * SalesPrice) - Discount
                txtSalesPrice4.Text = clsSet.setINR(tmpSalesPrice)
                txtDiscount4.Text = clsSet.setINR(Discount)


                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST4.Text = clsSet.setINR(PartSgst)
                txtCGST4.Text = clsSet.setINR(PartCgst)
                txtIGST4.Text = clsSet.setINR(PartIgst)
                txtTotal4.Text = clsSet.setINR(PartTotal)


                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartIgst
                PartCgsts = PartCgsts + PartCgst
                PartTotals = PartTotals + PartTotal

            End If



            If blPartEntered = False Then
                If txtLabourAmount.Text = "" Then
                    Call showMsg("Please enter parts no  ", "")
                    Exit Sub
                End If
            End If


            If blPriceCheckFailure = True Then
                Call showMsg("The price does not exist !!! <br>" & FailureText, "")
                Exit Sub
            End If


            'Assign Final Amount to Part
            txtPartQtyAmount.Text = Qtys
            txtPartDiscountAmount.Text = clsSet.setINR(Discounts)
            txtPartSalesAmount.Text = clsSet.setINR(SalesPrices)
            txtPartSGSTAmount.Text = clsSet.setINR(PartSgsts)
            txtPartCGSTAmount.Text = clsSet.setINR(PartCgsts)
            txtPartIGSTAmount.Text = clsSet.setINR(PartIgst)
            txtPartTotal.Text = clsSet.setINR(PartTotals)




            '3rd Other Amount
            Dim OtherQty As Decimal = 0.00
            Dim OtherDiscount As Decimal = 0.00
            Dim OtherCost As Decimal = 0.00
            Dim OtherSale As Decimal = 0.00
            Dim OtherSgst As Decimal = 0.00
            Dim OtherIgst As Decimal = 0.00
            Dim OtherCgst As Decimal = 0.00
            Dim OtherTotal As Decimal = 0.00
            Dim OtherTax As Decimal = 0.00

            'Verify All Editable are empty
            If Trim(txtOtherQtyAmount.Text) = "" And Trim(txtOtherDetail.Text) = "" And Trim(txtOtherCost.Text) = "" Then
                txtOtherSales.Text = ""
                txtOtherSGST.Text = ""
                txtOtherCGST.Text = ""
                txtOtherIGST.Text = ""
                txtOtherTotal.Text = ""
            Else
                If Decimal.TryParse(txtOtherQtyAmount.Text, OtherQty) Then
                Else
                    Call showMsg("Other Quantity is invalid ", "")
                    Exit Sub
                End If
                If Decimal.TryParse(txtOtherCost.Text, OtherCost) Then
                Else
                    Call showMsg("Other Cost is invalid ", "")
                    Exit Sub
                End If

                If Trim(txtOtherDiscount.Text) <> "" Then
                    If Decimal.TryParse(txtOtherDiscount.Text, OtherDiscount) Then
                    Else
                        Call showMsg("Other Discount is invalid ", "")
                        Exit Sub
                    End If
                End If

                If Trim(txtOtherTax.Text) <> "" Then
                    If Decimal.TryParse(txtOtherTax.Text, OtherTax) Then

                    Else
                        Call showMsg("Tax is invalid for Other ( " & txtOtherTax.Text & ")", "")
                        Exit Sub
                    End If
                    txtOtherTax.Text = clsSet.setINR(OtherTax)
                End If

                Sgst = OtherTax
                Cgst = OtherTax

                OtherSale = (OtherQty * OtherCost) - OtherDiscount
                txtOtherSales.Text = clsSet.setINR(OtherSale)

                OtherSgst = OtherSale / 100 * Sgst
                OtherIgst = OtherSale / 100 * Igst
                OtherCgst = OtherSale / 100 * Cgst
                OtherTotal = OtherSale + OtherSgst + OtherIgst + OtherCgst

                txtOtherSGST.Text = clsSet.setINR(OtherSgst)
                txtOtherCGST.Text = clsSet.setINR(OtherCgst)
                txtOtherIGST.Text = clsSet.setINR(OtherIgst)
                txtOtherTotal.Text = clsSet.setINR(OtherTotal)
            End If


            txtTotalQty.Text = Qtys + OtherQty
            'txtTotalCostAmount.text =""
            txtDiscountAmount.Text = clsSet.setINR(LabourDiscount + Discounts + OtherDiscount)
            txtTotalSalesAmount.Text = clsSet.setINR(LabourSales + SalesPrices + OtherSale)
            txtTotalSGSTAmount.Text = clsSet.setINR(LabourSgst + PartSgsts + OtherSgst)
            txtTotalCGSTAmount.Text = clsSet.setINR(LabourCgst + PartCgsts + OtherCgst)
            txtTotalIGSTAmount.Text = clsSet.setINR(LabourIgst + PartIgsts + OtherIgst)
            txtTotalAmount.Text = clsSet.setINR(LabourTotal + PartTotals + OtherTotal)
            Dim TotValue As Double = 0.00
            If Trim(txtTotalAmount.Text) <> "" Then
                'Validate Total Amount decimal 
                If Decimal.TryParse(txtTotalAmount.Text, TotValue) Then
                    txtTotalAmount.Text = Math.Round(TotValue, MidpointRounding.ToEven)
                Else
                    Call showMsg("Total Amount is invalid ", "")
                    Exit Sub
                End If
            End If

            Dim AdvanceAmount As Decimal = 0.00

            If Trim(txtAdvance.Text) <> "" Then
                'Validate Labour cost is decimal 
                If Decimal.TryParse(txtAdvance.Text, AdvanceAmount) Then
                Else
                    Call showMsg("Advance Amount is invalid ", "")
                    Exit Sub
                End If
            End If

            txtBalance.Text = clsSet.setINR(((LabourTotal + PartTotals + OtherTotal) - AdvanceAmount))


        End If

        'Finally Save to the Database
        If srcFunction = "btncalc" Then
            UpdateInfo("btncalc")
            If Len(Trim(strPartsSalesNotFound)) > 4 Then
                Call showMsg("The following parts no(s) are not assigned Sales price, so assigned cost price: <br>  " & strPartsSalesNotFound, "")
            End If
        ElseIf srcFunction = "btnestimate" Then
            UpdateInfo("btnestimate")
        End If


        '*************************
        'Btn Estimate
        If (srcFunction = "btnestimate") Then
            '1st Check PO
            '1st Check PO
            txtPoNo.Text = Trim(txtPoNo.Text)
            If txtPoNo.Text = "" Then
                Call showMsg("PO No is not allowed empty", "")
                Exit Sub
            End If


            txtCustomerName.Text = Trim(txtCustomerName.Text)
            If txtCustomerName.Text = "" Then
                Call showMsg("CustomerName is not allowed empty", "")
                Exit Sub
            End If


            'Calculation


            'Save

            Dim fileStream As FileStream
            Dim logoQuickGarage As String = "C:\money\gss_asp.png"
            '  Dim logoApple As String = "C:\money\apple_logo.jpg"

            Dim saveCsvPass As String = "C:\money\CSV\"
            Dim savePDFPass As String = "C:\money\PDF\"

            Dim fnt4 As New Font(BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, True), 16, iTextSharp.text.Font.UNDERLINE)

            Dim fnt5 As New Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False))
            Dim bf As BaseFont = BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, False)


            Dim Font2 As Font = New Font(bf, 11, Font.NORMAL)
            Dim Font3 As Font = New Font(bf, 6, Font.NORMAL)
            Dim fname = txtPoNo.Text & "_" & System.DateTime.Now.Millisecond.ToString() & ".pdf"

            Dim FontTitle As Font = New Font(bf, 14, Font.NORMAL)

            Dim filename As String = savePDFPass & fname

            txtEstimatedDate.Text = Now

            Try

                Dim SingleLine As New Paragraph()
                Dim doc As Document
                Dim pdfWriter As PdfWriter
                Dim image1 As Image = Image.GetInstance(logoQuickGarage) '画像
                image1.ScalePercent(7) '大きさ

                fileStream = New FileStream(filename, FileMode.Create)
                doc = New Document(PageSize.A4, 5, 5, 5, 5)
                pdfWriter = PdfWriter.GetInstance(doc, fileStream)
                doc.Open()

                Dim pcb As PdfContentByte = pdfWriter.DirectContent
                Dim cell As PdfPCell

                Dim psam As New Paragraph()
                psam.Alignment = Element.ALIGN_LEFT
                psam.Add(" ")
                doc.Add(psam)
                Dim psam1 As New Paragraph()
                psam1.Add(".")
                psam1.Alignment = Element.ALIGN_LEFT
                doc.Add(psam1)
                image1.ScaleAbsolute(380.0F, 45.0F)
                Dim p As New Paragraph()
                p.Add(New Chunk(image1, 0, 0))
                p.Alignment = Element.ALIGN_LEFT
                doc.Add(p)

                Dim table As PdfPTable = New PdfPTable(6)
                table.WidthPercentage = 100

                Dim table41 As PdfPTable = New PdfPTable(2)
                table41.WidthPercentage = 100
                Dim header41 As PdfPCell = New PdfPCell()
                header41.Colspan = 2
                table41.AddCell(header41) 'No pf Row
                cell = New PdfPCell(New Paragraph("GSS Quick Qarage Pvt Ltd", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                Dim FntCode39 As New Font(BaseFont.CreateFont("c:\money\CODE39.ttf", BaseFont.IDENTITY_H, True), 12) 'バ
                If Len(txtSerialNo.Text) > 2 Then
                    cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", FntCode39))
                Else
                    cell = New PdfPCell(New Paragraph(" "))
                End If
                'cell = New PdfPCell(New Paragraph(Trim(txtPoNo.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Paragon Plaza,Phoenix Market City,", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph(Trim(txtPoNo.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph("L B S Marg,Kurla west,Mumbai 400070", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                'cell = New PdfPCell(New Paragraph(Trim(txtGNo.Text), Font2))
                cell = New PdfPCell(New Paragraph("Create Date	", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)


                cell = New PdfPCell(New Paragraph("Telephone: +91-9500043584", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)
                'cell = New PdfPCell(New Paragraph("2021/03/21"))

                'cell = New PdfPCell(New Paragraph("Create Date	", Font2))
                cell = New PdfPCell(New Paragraph(txtEstimatedDate.Text, Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)



                cell = New PdfPCell(New Paragraph("E-mail: gss.asc1@quickgarage.co.in", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph(" ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table41.AddCell(cell)

                'Comment on 20210621
                'cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1ZH  CIN: U74999TN2016FTC112554", Font2))
                cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1ZH                             ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table41.AddCell(cell)

                doc.Add(table41)


                Dim ParaB As New Paragraph("Business Hours: 10:00AM to 7:00 PM Weekly Off Sunday", Font2)
                ParaB.Alignment = Element.ALIGN_LEFT
                doc.Add(ParaB)

                Dim Font1 As Font = New Font(bf, 22, Font.BOLD)

                ' Dim P9 As New Paragraph("", Font1)
                SingleLine.Alignment = Element.ALIGN_CENTER
                SingleLine = New Paragraph("", Font1)
                SingleLine.Add("                                Service Estimate")
                SingleLine.Font = FontFactory.GetFont("Segoe UI", 18.0, BaseColor.ORANGE)
                doc.Add(SingleLine)


                SingleLine = New Paragraph("", FontTitle)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("Customer Information")
                doc.Add(SingleLine)
                'doc.Add(table)

                Dim tableCustomer As PdfPTable = New PdfPTable(4)
                Dim header As PdfPCell = New PdfPCell()
                tableCustomer.WidthPercentage = 100
                header.Colspan = 6

                Dim intTblWidth() As Integer = {10, 30, 10, 15}
                tableCustomer.SetWidths(intTblWidth)

                tableCustomer.AddCell(header)

                cell = New PdfPCell(New Paragraph("Customer name", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCustomerName.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("PO Date", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                'Doubt
                'cell = New PdfPCell(New Paragraph(txtEstimatedDate.Text))
                cell = New PdfPCell(New Paragraph((lblhidPoDate.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Address", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtAddressLine1.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Model name", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                'Doubt
                'cell = New PdfPCell(New Paragraph("IPHONE 12,NA,256GB,BLACK"))
                cell = New PdfPCell(New Paragraph(txtModel.Text, Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                'header = New PdfPCell()

                'table.AddCell(header)
                cell = New PdfPCell(New Paragraph(" "))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtAddressLine2.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Product name ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtProduct.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph(("City"), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCity.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Warranty Status ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((drpServiceType.SelectedItem.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("E-mail", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtEmail.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Date of Purchase ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                'cell = New PdfPCell(New Paragraph("2020/12/10 "))
                cell = New PdfPCell(New Paragraph((txtDateOfPurchase.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Mobile", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtMobile.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph(("Serial No"), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtSerialNo.Text), Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)


                cell = New PdfPCell(New Paragraph(" ", Font2))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)
                cell = New PdfPCell(New Paragraph((" "), Font2))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                cell = New PdfPCell(New Paragraph(" "))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                If Len(txtSerialNo.Text) > 2 Then
                    cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", FntCode39))
                Else
                    cell = New PdfPCell(New Paragraph(" "))
                End If
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                tableCustomer.AddCell(cell)

                doc.Add(tableCustomer)

                Dim strtxtAccessoryNote As String = ""
                strtxtAccessoryNote = Trim(txtAccessoryNote.Text)
                If Len(strtxtAccessoryNote) > 1 Then
                    strtxtAccessoryNote = strtxtAccessoryNote.Replace(vbLf, " ").Replace(vbCr, " ")
                    Dim tblAcc As PdfPTable = New PdfPTable(1)
                    tblAcc.WidthPercentage = 100
                    Dim tblAcchead As PdfPCell = New PdfPCell()
                    tblAcchead.Colspan = 1
                    table.AddCell(tblAcchead) 'No pf Row

                    cell = New PdfPCell(New Paragraph("Product Received & Condition: " & strtxtAccessoryNote, Font2))
                    cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                    cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                    cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                    cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                    tblAcc.AddCell(cell)
                    doc.Add(tblAcc)
                End If

                'SingleLine = New Paragraph("")
                SingleLine = New Paragraph("", FontTitle)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("Problems reported by the customer")
                doc.Add(SingleLine)

                'SingleLine = New Paragraph("")
                'SingleLine.Alignment = Element.ALIGN_LEFT
                'SingleLine.Add("Details")
                'doc.Add(SingleLine)

                'SingleLine = New Paragraph("")
                'SingleLine.Alignment = Element.ALIGN_LEFT
                'SingleLine.Add(" ")
                'doc.Add(SingleLine)

                Dim tableDetails As PdfPTable = New PdfPTable(1)
                tableDetails.WidthPercentage = 100
                Dim tableDetailsheader As PdfPCell = New PdfPCell()
                tableDetailsheader.Colspan = 1
                tableDetails.AddCell(tableDetailsheader) 'No pf Row
                cell = New PdfPCell(New Paragraph(Trim(txtInvoiceNote.Text), Font2))
                tableDetails.AddCell(cell)
                doc.Add(tableDetails)

                'SingleLine = New Paragraph("")
                'SingleLine.Alignment = Element.ALIGN_LEFT
                'SingleLine.Add(" ")
                'doc.Add(SingleLine)

                SingleLine = New Paragraph("")
                SingleLine.Alignment = Element.ALIGN_LEFT
                Dim strAddText As String = ""
                If Trim(txtGNo.Text) <> "" And Trim(txtGSXCloseDate.Text) <> "" Then
                    strAddText = Trim(txtGSXCloseDate.Text)
                    strAddText = strAddText.Replace("/", "")
                    strAddText = " [ " & Trim(txtGNo.Text) & " " & strAddText & " ]"
                End If

                SingleLine = New Paragraph("", FontTitle)
                SingleLine.Add("Parts and service charges used for repairs " & strAddText & vbLf)
                doc.Add(SingleLine)

                SingleLine = New Paragraph("")
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)

                Dim table2 As PdfPTable = New PdfPTable(9)
                table2.WidthPercentage = 100
                Dim header2 As PdfPCell = New PdfPCell()
                header2.Colspan = 10
                table.AddCell(header2) 'No pf Row

                cell = New PdfPCell(New Paragraph("Parts No.", Font2))
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Parts Detail", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("Sales Price", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("Total", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("TaxableValue", Font2))
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Tax %", Font2))

                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("CGST", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("SGST", Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("Total", Font2))
                table2.AddCell(cell)

                Dim SrNo As Integer = 0
                Dim TmpPercentage As Decimal = 0
                'Labour
                If Trim(txtLabourAmount.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(Trim(txtLabourAmount.Text), Font2))
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourDetail.Text), Font3))
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourSales.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourSales.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourSales.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    If Trim(txtLabourTax.Text) <> "" Then
                        If Decimal.TryParse(txtLabourTax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Labour Tax is invalid ( " & txtLabourTax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourCGST.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourSGST.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(Trim(txtLabourTotal.Text), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If



                If Trim(txtPartNo1.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(txtPartNo1.Text, Font2))
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtPartDetails1.Text, Font3))
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSalesPrice1.Text, Font2)) 'txtCost1
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSalesPrice1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSalesPrice1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    If Trim(txtPart1Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart1Tax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Part 1 Tax is invalid ( " & txtPart1Tax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)


                    cell = New PdfPCell(New Paragraph(txtCGST1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSGST1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtTotal1.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                End If


                If Trim(txtPartNo2.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(txtPartNo2.Text, Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtPartDetails2.Text, Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice2.Text, Font2)) 'txtCost2
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtSalesPrice2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    If Trim(txtPart2Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart2Tax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Part 2 Tax is invalid ( " & txtPart2Tax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtCGST2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSGST2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtTotal2.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If


                If Trim(txtPartNo3.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(txtPartNo3.Text, Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtPartDetails3.Text, Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice3.Text, Font2)) 'txtCost3
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    If Trim(txtPart3Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart3Tax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Part 3 Tax is invalid ( " & txtPart3Tax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtCGST3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSGST3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtTotal3.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If

                If Trim(txtPartNo4.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(txtPartNo4.Text, Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtPartDetails4.Text, Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice4.Text, Font2)) 'txtCost4
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSalesPrice4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    If Trim(txtPart4Tax.Text) <> "" Then
                        If Decimal.TryParse(txtPart4Tax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Part 4 Tax is invalid ( " & txtPart4Tax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtCGST4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtSGST4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtTotal4.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If


                If Trim(txtOtherDetail.Text) <> "" Then
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherDetail.Text, Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherCost.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherSales.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherSales.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    If Trim(txtOtherTax.Text) <> "" Then
                        If Decimal.TryParse(txtOtherTax.Text, TmpPercentage) Then
                            TmpPercentage = TmpPercentage * 2
                        Else
                            Call showMsg("Other Tax is invalid ( " & txtOtherTax.Text & ")", "")
                            Exit Sub
                        End If
                        cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), Font2))
                    Else
                        cell = New PdfPCell(New Paragraph(Trim(" "), Font2))
                    End If
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table2.AddCell(cell)

                    cell = New PdfPCell(New Paragraph(txtOtherCGST.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherSGST.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(txtOtherTotal.Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                End If



                Do While SrNo < 4
                    SrNo = SrNo + 1
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font3))
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    table2.AddCell(cell)

                Loop


                cell = New PdfPCell(New Paragraph(".", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' Dim test = Convert.ToInt32(txtCGST1.Text) + Convert.ToInt32(txtCGST2.Text) + Convert.ToInt32(txtCGST3.Text) + Convert.ToInt32(txtCGST4.Text)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtTotalAmount.Text), Font2))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT

                table2.AddCell(cell)

                doc.Add(table2)

                Dim table3 As PdfPTable = New PdfPTable(6)
                table3.WidthPercentage = 100
                Dim header3 As PdfPCell = New PdfPCell()
                header3.Colspan = 1
                table.AddCell(header3) 'No pf Row
                cell = New PdfPCell(New Paragraph("Advance Received", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER

                table3.AddCell(cell)
                cell = New PdfPCell(New Paragraph(Trim(txtAdvance.Text)))
                ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table3.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Discount ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table3.AddCell(cell)

                cell = New PdfPCell(New Paragraph(Trim(txtDiscountAmount.Text)))
                ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table3.AddCell(cell)

                cell = New PdfPCell(New Paragraph("Total Invoice", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table3.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtTotalAmount.Text))
                ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table3.AddCell(cell)

                doc.Add(table3)

                SingleLine = New Paragraph("")
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)

                Dim table4 As PdfPTable = New PdfPTable(1)
                table4.WidthPercentage = 100
                Dim header4 As PdfPCell = New PdfPCell()
                header4.Colspan = 1
                table.AddCell(header4) 'No pf Row

                Dim strMoneyText As String = ""

                If Trim(txtTotalAmount.Text) <> "" Then
                    strMoneyText = NumberToText(txtTotalAmount.Text)
                    cell = New PdfPCell(New Paragraph("Total Invoice(In Word) " & strMoneyText & " Only", Font2))
                Else
                    cell = New PdfPCell(New Paragraph(" ", Font2))
                End If
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table4.AddCell(cell)

                doc.Add(table4)

                'SingleLine = New Paragraph("")
                'SingleLine.Alignment = Element.ALIGN_LEFT
                'SingleLine.Add(" ")
                'doc.Add(SingleLine)






                ''''''''Dim tblGsxNote As PdfPTable = New PdfPTable(1)
                ''''''''tblGsxNote.WidthPercentage = 100
                ''''''''Dim tblGsxNoteheader As PdfPCell = New PdfPCell()
                ''''''''tblGsxNoteheader.Colspan = 1
                ''''''''tblGsxNote.AddCell(tblGsxNoteheader) 'No pf Row
                ''''''''cell = New PdfPCell(New Paragraph(Trim(txtGsxNote.Text), Font2))
                ''''''''tblGsxNote.AddCell(cell)
                ''''''''doc.Add(tblGsxNote)

                ''''''''Dim FontChecked As Font = New Font(bf, 7, Font.NORMAL)

                ''''''''''''''''SingleLine = New Paragraph("")
                ''''''''''''''''SingleLine.Alignment = Element.ALIGN_LEFT
                ''''''''''''''''SingleLine.Add(" ")
                ''''''''''''''''doc.Add(SingleLine)

                ''''''''Dim tblChecked As PdfPTable = New PdfPTable(17)
                ''''''''tblChecked.WidthPercentage = 100
                ''''''''Dim intTblChkWidth2() As Integer = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}
                ''''''''tblChecked.SetWidths(intTblChkWidth2)

                '''''''''Dim chkheader As PdfPCell = New PdfPCell()
                '''''''''chkheader.Colspan = 2
                '''''''''tblChecked.AddCell(chkheader)

                ''''''''cell = New PdfPCell(New Paragraph(" ", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("FireWire", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("USB", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Camera", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Speaker", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Mouse / Trackpad", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Optical Drive", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Ethernet", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Display", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("HDD", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Airport", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("RAM", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Keyboard", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Bluetooth", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Battery", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Airport", FontChecked))
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell(New Paragraph("Adaptor", FontChecked))
                ''''''''tblChecked.AddCell(cell)

                ''''''''doc.Add(tblChecked)

                ''''''''tblChecked = New PdfPTable(17)
                ''''''''tblChecked.WidthPercentage = 100
                ''''''''tblChecked.SetWidths(intTblChkWidth2)

                '''''''''Dim imgSuare As Image = Image.GetInstance(SquareImage)
                '''''''''imgSuare.ScalePercent(6)
                '''''''''Dim SquareCheckBox As New Chunk(imgSuare, 0.1F, 0.1F)

                ''''''''Dim SquareCheckBox As New Paragraph(" ")
                ''''''''Dim SquareCheckBoxHeight As Integer = 10

                ''''''''cell = New PdfPCell(New Paragraph("Inward ", FontChecked))
                '''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''tblChecked.AddCell(cell)

                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)

                ''''''''doc.Add(tblChecked)

                ''''''''tblChecked = New PdfPTable(17)
                ''''''''tblChecked.WidthPercentage = 100
                ''''''''tblChecked.SetWidths(intTblChkWidth2)
                ''''''''cell = New PdfPCell(New Paragraph("Outward", FontChecked))
                '''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''tblChecked.AddCell(cell)

                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)
                ''''''''cell = New PdfPCell()
                ''''''''cell.FixedHeight = SquareCheckBoxHeight
                ''''''''cell.AddElement(SquareCheckBox)
                ''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
                ''''''''cell.PaddingBottom = 8
                ''''''''cell.PaddingLeft = 10
                ''''''''tblChecked.AddCell(cell)

                ''''''''doc.Add(tblChecked)

                'Dim P25 As New Paragraph()
                SingleLine = New Paragraph("")
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)


                Dim table52 As PdfPTable = New PdfPTable(1)
                table52.WidthPercentage = 100
                Dim header52 As PdfPCell = New PdfPCell()
                header52.Colspan = 1
                table.AddCell(header52) 'No pf Row




                cell = New PdfPCell(New Paragraph("Estimate deadline and terms of use", FontTitle))
                'cell = New PdfPCell(New Paragraph("Estimate deadline and terms of use"))
                ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table52.AddCell(cell)


                doc.Add(table52)

                SingleLine = New Paragraph("", Font3)
                'Dim P18 As New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("If there is any change in symptoms during the repair process or if there is something wrong in ")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("the service estimate, the service estimate and its estimated amount are subject to change.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("Due to the above reasons, the billing amount can change.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("If the billing amount changes, GSS Quick Garage India Private Limited needs to get new consent from customer.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("There is a possibility that GSS Quick Garage India Private Limited calls customer to proceed with repair.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("GSS Quick Garage India Private Limited will not be responsible for any data loss, thus it is highly recommended to back up the data.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("", Font3)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add("Most repairs require an OS restore, thus all data will be erased.")
                doc.Add(SingleLine)

                SingleLine = New Paragraph("")
                SingleLine = New Paragraph("", Font2)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)

                Dim table5 As PdfPTable = New PdfPTable(2)
                table5.WidthPercentage = 100
                Dim header5 As PdfPCell = New PdfPCell()
                header5.Colspan = 1
                table.AddCell(header5) 'No pf Row


                ' cell = New PdfPCell(New Paragraph("  Received by", Font2))
                cell = New PdfPCell(New Paragraph(" ", Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table5.AddCell(cell)
                cell = New PdfPCell(New Paragraph("                 Customer Signature", Font2))
                'cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table5.AddCell(cell)

                doc.Add(table5)

                SingleLine = New Paragraph("", Font2)
                SingleLine.Alignment = Element.ALIGN_LEFT
                SingleLine.Add(" ")
                doc.Add(SingleLine)


                Dim table6 As PdfPTable = New PdfPTable(1)
                table6.WidthPercentage = 100
                Dim header6 As PdfPCell = New PdfPCell()
                header6.Colspan = 4
                table6.AddCell(header6) 'No pf Row
                cell = New PdfPCell(New Paragraph("For GSS QuickGarage India Pvt Ltd", Font2))
                'cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table6.AddCell(cell)



                'Empty Row
                cell = New PdfPCell(New Paragraph(" "))
                'cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table6.AddCell(cell)






                'table6.AddCell("For GSS QuickGarage India Pvt Ltd")
                cell = New PdfPCell(New Paragraph("                                                                           Authorized Signatory                                                           E.&O.E.", Font2))
                ' cell = New PdfPCell(New Paragraph("                                                                                Authorized Signatory                                                                        E.&O.E.", Font2))
                'cell = New PdfPCell(New Paragraph("Authorized Signatory                                                                                                             E.&O.E.", Font2))
                'cell.HorizontalAlignment = Element.ALIGN_RIGHT
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                table6.AddCell(cell)
                doc.Add(table6)



                doc.Close()

                '*************************************
                'Esitmte Date & Time update
                '*************************************
                ''''''''''Dim str As String

                ''''''''''Dim ShipName As String = Session("ship_Name")
                ''''''''''Dim shipCode As String = Session("ship_code")
                ''''''''''Dim userName As String = Session("user_Name")
                ''''''''''Dim userid As String = Session("user_id")


                ''''''''''Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
                ''''''''''Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
                ''''''''''_AppleQmvOrdModel.UserId = userid
                ''''''''''_AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode
                ''''''''''_AppleQmvOrdModel.SHIP_TO_BRANCH = ShipName
                ''''''''''_AppleQmvOrdModel.PO_NO = txtPoNo.Text
                ''''''''''_AppleQmvOrdModel.G_NO = txtGNo.Text
                ''''''''''_AppleQmvOrdModel.ESTIMATE_DATE = txtEstimatedDate.Text
                ''''''''''_AppleQmvOrdModel.ESTIMATE_TIME = Now.ToShortTimeString


                ''''''''''Dim blStatus As Boolean = False

                ''''''''''blStatus = _AppleQmvOrdControl.UpdateEstimate(_AppleQmvOrdModel)

                ''''''''''If blStatus = False Then
                ''''''''''    Call showMsg("Estimate Date updation Error", "")
                ''''''''''    Exit Sub
                ''''''''''End If

            Catch ex As Exception
                'errFlg = 1
            Finally
                If fileStream IsNot Nothing Then
                    fileStream.Close()
                End If
            End Try

            Call FileDownload(fname, "application/pdf")

        End If

    End Sub


    Protected Sub FileDownload(FileName As String, MimeType As String)

        Dim clsSet As New Class_money

        Dim FilePath As String

        'ダウンロードするファイル名
        Dim dlFileName As String

        If Request.Browser.Browser = "IE" Then
            'IEの場合はファイル名をURLエンコード
            dlFileName = HttpUtility.UrlEncode(FileName)
        Else
            'IE以外の場合はそのままでOK
            dlFileName = FileName
        End If

        FilePath = clsSet.savePDFPass & FileName

        Try

            'ファイルの内容をバイト配列にすべて読み込む 
            Dim Buffer As Byte() = System.IO.File.ReadAllBytes(FilePath)

            'サーバに保存されたCSVファイルを削除
            '※Response.End以降、ファイル削除処理ができないため、一旦ファイルの内容を
            '上記、Bufferに保存してから削除し、ダウンロード処理を行う。

            If FilePath <> "" Then
                If System.IO.File.Exists(FilePath) = True Then
                    System.IO.File.Delete(FilePath)
                End If
            End If

            'ダウンロード処理
            'Response情報クリア
            Response.ClearContent()

            'バッファリング
            Response.Buffer = True

            'HTTPヘッダー情報・MIMEタイプ設定
            Response.AddHeader("Content-Disposition", String.Format("attachment;filename={0}", dlFileName))
            Response.ContentType = MimeType

            'ファイルを書き出し
            Response.BinaryWrite(Buffer)
            'Response.WriteFile(FilePath)
            Response.Flush()
            Response.End()

        Catch ex As System.Threading.ThreadAbortException
            'Response.End()の呼び出しによりエラーメッセージを出力しないようにする

        Catch ex As Exception
            If FilePath <> "" Then
                If System.IO.File.Exists(FilePath) = True Then
                    System.IO.File.Delete(FilePath)
                End If
            End If
            Call showMsg("Failed to download ", "")
        End Try

    End Sub

    Protected Sub btnDelivered_Click(sender As Object, e As EventArgs) Handles btnDelivered.Click
        'Dim dateTimeObj1 As DateTime = DateTime.ParseExact(txtDeliveryDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture)
        Dim dateTimeObj1 As DateTime = DateTime.ParseExact(txtDeliveryDate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture)
        If dateTimeObj1 > DateTime.Today Then
            Call showMsg("Delivery Date Is Not Allowed For Future Date", "")
            Exit Sub
        End If

        'GSX Closed
        'Dim dateTimeObj2 As DateTime = DateTime.ParseExact(txtGSXCloseDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture)
        Dim dateTimeObj2 As DateTime = DateTime.ParseExact(txtGSXCloseDate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture)
        If dateTimeObj2 > dateTimeObj1 Then
            Call showMsg("Delivery Date Should Be Greater Than GSX Close Date", "")
            Exit Sub
        End If


        If Trim(txtDeliveryDate.Text) <> "" Then
            Dim str As String

            Dim ShipName As String = Session("ship_Name")
            Dim shipCode As String = Session("ship_code")
            Dim userName As String = Session("user_Name")
            Dim userid As String = Session("user_id")


            Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
            Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
            _AppleQmvOrdModel.UserId = userid
            _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode
            _AppleQmvOrdModel.SHIP_TO_BRANCH = ShipName
            _AppleQmvOrdModel.PO_NO = txtPoNo.Text
            _AppleQmvOrdModel.G_NO = txtGNo.Text
            _AppleQmvOrdModel.DELIVERY_DATE = txtDeliveryDate.Text
            _AppleQmvOrdModel.DENOMINATION = drpDenomination.SelectedItem.Value
            Dim blStatus As Boolean = False
            blStatus = _AppleQmvOrdControl.UpdateDelivered(_AppleQmvOrdModel)
            If blStatus = False Then
                Call showMsg("Delevered Status updation Error", "")
                Exit Sub
            Else
                btnDelivered.Enabled = False
                Btninvoice.Enabled = True
                'Btndiagonis.Enabled = True
            End If
        Else
            Call showMsg("Delivery Date Is Empty", "")
            Exit Sub
        End If

    End Sub

    Protected Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click

        If Trim(txtGSXCloseDate.Text) <> "" Then
            'Dim dateTimeObj As DateTime = DateTime.ParseExact(txtGSXCloseDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture)
            Dim dateTimeObj As DateTime = DateTime.ParseExact(txtGSXCloseDate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture)
            If dateTimeObj > DateTime.Today Then
                Call showMsg("GSX Close Date Is Not Allowed For Future Date", "")
                Exit Sub
            End If
        End If




        Select Case drpCompStatus.SelectedItem.Value
            Case "0" '--Select
                Call showMsg("Select Complete", "")
                Exit Sub

            Case "1" 'Complete
                If Trim(txtGSXCloseDate.Text) = "" Then
                    Call showMsg("GSX Close Date Is Empty", "")
                    Exit Sub
                End If

            Case "2" 'Reception only
                'If Trim(txtGSXCloseDate.Text) = "" Then
                '    Call showMsg("GSX Close Date Is Empty", "")
                '    Exit Sub
                'End If

        End Select

        UpdateInfo("btncomplete")

        ''''Dim str As String

        ''''Dim ShipName As String = Session("ship_Name")
        ''''Dim shipCode As String = Session("ship_code")
        ''''Dim userName As String = Session("user_Name")
        ''''Dim userid As String = Session("user_id")


        ''''Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
        ''''Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
        ''''_AppleQmvOrdModel.UserId = userid
        ''''_AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode
        ''''_AppleQmvOrdModel.SHIP_TO_BRANCH = ShipName
        ''''_AppleQmvOrdModel.PO_NO = txtPoNo.Text
        ''''_AppleQmvOrdModel.G_NO = txtGNo.Text
        ''''_AppleQmvOrdModel.GSX_CLOSE_DATE = txtGSXCloseDate.Text
        ''''_AppleQmvOrdModel.COMP_STATUS = drpCompStatus.SelectedItem.Value


        ''''Dim blStatus As Boolean = False

        ''''blStatus = _AppleQmvOrdControl.UpdateComplete(_AppleQmvOrdModel)

        ''''If blStatus = False Then
        ''''    Call showMsg("Complete updation Error", "")
        ''''    Exit Sub
        ''''End If
        If drpCompStatus.SelectedItem.Value <> "0" Then
            DisableAction()
            If drpCompStatus.SelectedItem.Value = 1 Then
                txtDeliveryDate.Enabled = True
                drpDenomination.Enabled = True
                Btninvoice.Enabled = True
                'Btndiagonis.Enabled = True
                btnDelivered.Enabled = True
            End If
        End If


    End Sub

    Protected Sub btnCalculation_Click(sender As Object, e As EventArgs) Handles btnCalculation.Click
        'Call Calculation 
        CalcEstimateSave("btncalc")

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

    Protected Sub drpServiceType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpServiceType.SelectedIndexChanged

        servicedrop()

    End Sub
    Public Sub servicedrop()




        Select Case drpServiceType.SelectedItem.Value

            Case 0
                divCustomer.Attributes.Add("class", "card-header card-header-primary ")
                divcard.Attributes.CssStyle.Add("Background-Color", "")
            Case 1
                divCustomer.Attributes.Add("class", "InWarranty ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#eef8e9")
            Case 2
                divCustomer.Attributes.Add("class", "OutWarranty ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#fc261c1a")
            Case 3
                divCustomer.Attributes.Add("class", "ApplecareProtechtion ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#03224905")
            Case 4
                divCustomer.Attributes.Add("class", "Sales ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#EDC9AF")
            Case 5
                divCustomer.Attributes.Add("class", "Accessories ")
                divcard.Attributes.CssStyle.Add("Background-Color", "#f8fca7")

        End Select
    End Sub


    Private Sub Btndiagonis_Click(sender As Object, e As EventArgs) Handles Btndiagonis.Click


        '1st Check PO
        txtPoNo.Text = Trim(txtPoNo.Text)
        If txtPoNo.Text = "" Then
            Call showMsg("PO No is not allowed empty", "")
            Exit Sub
        End If
        Dim fnt4 As New Font(BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, True), 16, iTextSharp.text.Font.UNDERLINE)

        Dim fnt5 As New Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False))
        Dim bf As BaseFont = BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, False)

        Dim Font1 As Font = New Font(bf, 14, Font.BOLD)
        Dim Font2 As Font = New Font(bf, 11, Font.NORMAL)
        Dim Font3 As Font = New Font(bf, 9, Font.NORMAL)
        Dim FontTitle As Font = New Font(bf, 14, Font.NORMAL)

        '2nd Check G No
        'txtGNo.Text = Trim(txtGNo.Text)
        'If txtGNo.Text = "" Then
        '    Call showMsg("G No is not allowed empty", "")
        '    Exit Sub
        'End If


        txtCustomerName.Text = Trim(txtCustomerName.Text)
        If txtCustomerName.Text = "" Then
            Call showMsg("CustomerName is not allowed empty", "")
            Exit Sub
        End If


        Dim fileStream As FileStream
        Dim logoQuickGarage As String = "C:\money\gss_asp.png"
        'Dim SquareImage As String = "C:\money\square.png"
        'Dim logoApple As String = "C:\money\apple_logo.jpg"


        Dim saveCsvPass As String = "C:\money\CSV\"
        Dim savePDFPass As String = "C:\money\PDF\"

        Dim fname = txtPoNo.Text & "_" & System.DateTime.Now.Millisecond.ToString() & ".pdf"
        Dim filename As String = savePDFPass & fname

        Try

            Dim SingleLine As New Paragraph()
            Dim doc As Document
            Dim pdfWriter As PdfWriter
            Dim image1 As Image = Image.GetInstance(logoQuickGarage) '画像
            image1.ScalePercent(7) '大きさ

            'Dim image2 As Image = Image.GetInstance(logoApple) '画像
            'image2.ScalePercent(7) '大きさ

            fileStream = New FileStream(filename, FileMode.Create)

            doc = New Document(PageSize.A4, 5, 5, 5, 5)

            pdfWriter = PdfWriter.GetInstance(doc, fileStream)
            doc.Open()

            Dim pcb As PdfContentByte = pdfWriter.DirectContent

            Dim cell As PdfPCell

            Dim psam As New Paragraph()
            psam.Alignment = Element.ALIGN_LEFT
            psam.Add(" ")
            doc.Add(psam)
            Dim psam1 As New Paragraph()
            psam1.Add(".")
            psam1.Alignment = Element.ALIGN_LEFT
            doc.Add(psam1)
            image1.ScaleAbsolute(380.0F, 45.0F)
            Dim p As New Paragraph()
            p.Add(New Chunk(image1, 0, 0))
            p.Alignment = Element.ALIGN_LEFT
            doc.Add(p)

            Dim table As PdfPTable = New PdfPTable(6)
            table.WidthPercentage = 100
            Dim intTblWidth() As Integer = {25, 60, 3, 3, 25, 35}
            table.SetWidths(intTblWidth)


            Dim table41 As PdfPTable = New PdfPTable(2)
            table41.WidthPercentage = 100
            Dim header41 As PdfPCell = New PdfPCell()
            header41.Colspan = 2
            table.AddCell(header41) 'No pf Row
            cell = New PdfPCell(New Paragraph("GSS quick garage pvt.LTD", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)





            Dim FntCode39 As New Font(BaseFont.CreateFont("c:\money\CODE39.ttf", BaseFont.IDENTITY_H, True), 12) 'バ
            ' cell = New PdfPCell(New Paragraph("*" & Right(otherData.po_no, Len(otherData.po_no) - 2) & "*", fntBa2))
            If Len(txtSerialNo.Text) > 2 Then
                cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", FntCode39))
            Else
                cell = New PdfPCell(New Paragraph(" "))
            End If




            'cell = New PdfPCell(New Paragraph("1234567891023450", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Paragon Plaza,Phoenix Market City,", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtPoNo.Text, Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("L B S Marg,Kurla west,Mumbai 400070", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Create Date	", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Telephone: +919500043584", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Now, Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)
            cell = New PdfPCell(New Paragraph("E-mail:gss.asc1@quickgarage.co.in", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            'Comment on 20210621
            'cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1Z  CIN: U74999TN2016FTC112554 ", Font2))
            cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1ZH                              ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)
            doc.Add(table41)

            Dim ParaB As New Paragraph("Business Hours: 10:00AM to 7:00 PM Weekly Off Sunday", Font2)
            ParaB.Alignment = Element.ALIGN_LEFT
            doc.Add(ParaB)

            'Dim P9 As New Paragraph("", Font1)
            SingleLine = New Paragraph("", Font1)
            SingleLine.Alignment = Element.ALIGN_CENTER
            SingleLine.Alignment = Font.BOLD
            SingleLine.Add("Service Report")
            SingleLine.Font = Font1
            'SingleLine.Font = FontFactory.GetFont("Segoe UI", 26.0, BaseColor.ORANGE)
            doc.Add(SingleLine)


            'Dim P10 As New Paragraph()
            SingleLine = New Paragraph("", FontTitle)
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add("Customer Information")
            doc.Add(SingleLine)

            Dim header As PdfPCell = New PdfPCell()
            header.Colspan = 6
            table.AddCell(header)

            cell = New PdfPCell(New Paragraph("Customer name", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtCustomerName.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("PO Date", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'Doubt
            cell = New PdfPCell(New Paragraph((lblhidPoDate.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Address", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtAddressLine1.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Model name", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)


            'Doubt
            'cell = New PdfPCell(New Paragraph("IPHONE 12,NA,256GB,BLACK"))
            cell = New PdfPCell(New Paragraph(txtModel.Text))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)


            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtAddressLine2.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)

            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Product name ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtProduct.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)




            cell = New PdfPCell(New Paragraph(("City"), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtCity.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Warranty Status ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((drpServiceType.SelectedItem.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)




            cell = New PdfPCell(New Paragraph("State: " & txtState.Text & "    Postal Code: " & txtZip.Text, Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.Colspan = 2
            table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph((txtCity.Text), Font2))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Date of Purchase ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("2020/12/10 "))
            cell = New PdfPCell(New Paragraph(txtDateOfPurchase.Text))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)




            cell = New PdfPCell(New Paragraph("E-mail", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER

            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtEmail.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("Postal Code ", Font2))
            cell = New PdfPCell(New Paragraph(" ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph((txtZip.Text), Font2))
            cell = New PdfPCell(New Paragraph((" "), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Serial No ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSerialNo.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)


            'If (Trim(txtMobile.Text) <> "") And (Trim(txtEmail.Text) <> "") Then
            '    cell = New PdfPCell(New Paragraph("Mobile: " & txtMobile.Text & "E-mail: " & txtEmail.Text, Font2))
            '    'cell = New PdfPCell(New Paragraph("State: " & Trim(txtState.Text) & "    Postal Code: " & Trim(txtZip.Text), Font3))
            'ElseIf (Trim(txtMobile.Text) <> "") Then
            '    cell = New PdfPCell(New Paragraph("Mobile: " & txtMobile.Text, Font2))
            'ElseIf (Trim(txtEmail.Text) <> "") Then
            '    cell = New PdfPCell(New Paragraph("E-mail: " & txtEmail.Text, Font2))
            'Else
            '    cell = New PdfPCell(New Paragraph("Mobile: ", Font2))
            'End If

            cell = New PdfPCell(New Paragraph("Mobile", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'cell.Colspan = 2
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtMobile.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))

            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            If Len(txtSerialNo.Text) > 2 Then
                cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", FntCode39))
            Else
                cell = New PdfPCell(New Paragraph(" "))
            End If
            'cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)


            cell = New PdfPCell(New Paragraph("GSTIN/Unique ID ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtGstin.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)





            doc.Add(table)

            Dim table51 As PdfPTable = New PdfPTable(1)
            Dim header51 As PdfPCell = New PdfPCell()


            Dim strtxtAccessoryNote As String = ""
            strtxtAccessoryNote = Trim(txtAccessoryNote.Text)
            If Len(strtxtAccessoryNote) > 1 Then
                strtxtAccessoryNote = strtxtAccessoryNote.Replace(vbLf, " ").Replace(vbCr, " ")
                table51 = New PdfPTable(1)
                table51.WidthPercentage = 100
                header51 = New PdfPCell()
                header51.Colspan = 1
                table.AddCell(header51) 'No pf Row

                cell = New PdfPCell(New Paragraph("Product Received & Condition: " & strtxtAccessoryNote, Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table51.AddCell(cell)
                doc.Add(table51)
            End If








            table51 = New PdfPTable(1)
            table51.WidthPercentage = 100
            header51 = New PdfPCell()
            header51.Colspan = 1
            table.AddCell(header51) 'No pf Row

            cell = New PdfPCell(New Paragraph(("Problems reported by the customer"), FontTitle))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table51.AddCell(cell)


            doc.Add(table51)


            ''Dim P12 As New Paragraph()
            'SingleLine = New Paragraph("")
            'SingleLine.Alignment = Element.ALIGN_LEFT
            'SingleLine.Add("Details")
            'doc.Add(SingleLine)

            ''Dim P13 As New Paragraph()
            'SingleLine = New Paragraph("")
            'SingleLine.Alignment = Element.ALIGN_LEFT
            'SingleLine.Add(" ")
            'doc.Add(SingleLine)

            Dim tableDetails As PdfPTable = New PdfPTable(1)
            tableDetails.WidthPercentage = 100
            Dim tableDetailsheader As PdfPCell = New PdfPCell()
            tableDetailsheader.Colspan = 1
            tableDetails.AddCell(tableDetailsheader) 'No pf Row
            cell = New PdfPCell(New Paragraph(Trim(txtInvoiceNote.Text), Font2))
            tableDetails.AddCell(cell)
            doc.Add(tableDetails)

            ' Dim P15 As New Paragraph()
            '''''''''''''''''SingleLine = New Paragraph("", FontTitle)
            '''''''''''''''''SingleLine.Alignment = Element.ALIGN_LEFT
            '''''''''''''''''SingleLine.Add("Parts and Details " & vbLf)
            '''''''''''''''''doc.Add(SingleLine)

            '''''''''''''''''SingleLine = New Paragraph("")
            '''''''''''''''''SingleLine.Alignment = Element.ALIGN_LEFT
            '''''''''''''''''SingleLine.Add(" ")
            '''''''''''''''''doc.Add(SingleLine)




            SingleLine = New Paragraph("")
            SingleLine.Alignment = Element.ALIGN_LEFT
            Dim strAddText As String = ""
            If Trim(txtGNo.Text) <> "" And Trim(txtGSXCloseDate.Text) <> "" Then
                strAddText = Trim(txtGSXCloseDate.Text)
                strAddText = strAddText.Replace("/", "")
                strAddText = " [ " & Trim(txtGNo.Text) & " " & strAddText & " ]"
            End If

            SingleLine = New Paragraph("", FontTitle)
            SingleLine.Add("Parts and Details " & strAddText & vbLf)
            doc.Add(SingleLine)

            SingleLine = New Paragraph("")
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add(" ")
            doc.Add(SingleLine)











            Dim table2 As PdfPTable = New PdfPTable(4)
            table2.WidthPercentage = 100
            Dim intTblWidth2() As Integer = {8, 60, 60, 8}
            table2.SetWidths(intTblWidth2)

            Dim header2 As PdfPCell = New PdfPCell()
            header2.Colspan = 4
            table.AddCell(header2) 'No pf Row

            table2.AddCell("S.No")
            table2.AddCell("Parts")
            table2.AddCell("Parts No")
            table2.AddCell("Qty")

            Dim SrNo As Integer = 0

            If Trim(txtLabourDetail.Text) <> "" Then
                SrNo = SrNo + 1
                cell = New PdfPCell(New Paragraph(SrNo, Font1))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtLabourDetail.Text, Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtLabourAmount.Text, Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("1", Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
            End If

            If Trim(txtPartNo1.Text) <> "" Then
                SrNo = SrNo + 1
                cell = New PdfPCell(New Paragraph(SrNo, Font1))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtPartDetails1.Text, Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtPartNo1.Text, Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtQty1.Text, Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
            End If

            If Trim(txtPartNo2.Text) <> "" Then
                SrNo = SrNo + 1
                cell = New PdfPCell(New Paragraph(SrNo, Font1))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtPartDetails2.Text, Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtPartNo2.Text, Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtQty2.Text, Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
            End If

            If Trim(txtPartNo3.Text) <> "" Then
                SrNo = SrNo + 1
                cell = New PdfPCell(New Paragraph(SrNo, Font1))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtPartDetails3.Text, Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtPartNo3.Text, Font2))
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtQty3.Text, Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
            End If

            If Trim(txtPartNo4.Text) <> "" Then
                SrNo = SrNo + 1
                cell = New PdfPCell(New Paragraph(SrNo, Font1))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtPartDetails4.Text, Font2))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtPartNo4.Text, Font2))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtQty4.Text, Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
            End If


            If Trim(txtOtherDetail.Text) <> "" Then
                SrNo = SrNo + 1
                cell = New PdfPCell(New Paragraph(SrNo, Font1))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtOtherDetail.Text, Font2))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(txtOtherQtyAmount.Text, Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
            End If

            Do While SrNo < 4
                SrNo = SrNo + 1
                cell = New PdfPCell(New Paragraph(SrNo, Font1))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", Font2))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", Font2))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table2.AddCell(cell)
            Loop


            doc.Add(table2)

            'P13 = New Paragraph()
            SingleLine = New Paragraph("")
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add(" ")
            doc.Add(SingleLine)


            Dim table52 As PdfPTable = New PdfPTable(1)
            table52.WidthPercentage = 100
            Dim header52 As PdfPCell = New PdfPCell()
            header52.Colspan = 1
            table.AddCell(header52) 'No pf Row

            cell = New PdfPCell(New Paragraph("Service Centre Observation", FontTitle))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table52.AddCell(cell)


            doc.Add(table52)


            'P13 = New Paragraph()
            'SingleLine = New Paragraph("")
            'SingleLine.Alignment = Element.ALIGN_LEFT
            'SingleLine.Add(" ")
            'doc.Add(SingleLine)




            'Dim P24 As New Paragraph()
            'SingleLine = New Paragraph("")
            'SingleLine.Alignment = Element.ALIGN_RIGHT
            'SingleLine.Add("")
            'doc.Add(SingleLine)


            Dim tblGsxNote As PdfPTable = New PdfPTable(1)
            tblGsxNote.WidthPercentage = 100
            Dim tblGsxNoteheader As PdfPCell = New PdfPCell()
            tblGsxNoteheader.Colspan = 1
            tblGsxNote.AddCell(tblGsxNoteheader) 'No pf Row
            cell = New PdfPCell(New Paragraph(Trim(txtGsxNote.Text), Font2))
            tblGsxNote.AddCell(cell)
            doc.Add(tblGsxNote)

            '''''''''''''Dim FontChecked As Font = New Font(bf, 7, Font.NORMAL)

            '''''''''''''SingleLine = New Paragraph("")
            '''''''''''''SingleLine.Alignment = Element.ALIGN_LEFT
            '''''''''''''SingleLine.Add(" ")
            '''''''''''''doc.Add(SingleLine)

            '''''''''''''Dim tblChecked As PdfPTable = New PdfPTable(17)
            '''''''''''''tblChecked.WidthPercentage = 100
            '''''''''''''Dim intTblChkWidth2() As Integer = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}
            '''''''''''''tblChecked.SetWidths(intTblChkWidth2)

            ''''''''''''''Dim chkheader As PdfPCell = New PdfPCell()
            ''''''''''''''chkheader.Colspan = 2
            ''''''''''''''tblChecked.AddCell(chkheader)

            '''''''''''''cell = New PdfPCell(New Paragraph(" ", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("FireWire", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("USB", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Camera", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Speaker", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Mouse / Trackpad", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Optical Drive", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Ethernet", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Display", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("HDD", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Airport", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("RAM", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Keyboard", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Bluetooth", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Battery", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Airport", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell(New Paragraph("Adaptor", FontChecked))
            '''''''''''''tblChecked.AddCell(cell)

            '''''''''''''doc.Add(tblChecked)

            '''''''''''''tblChecked = New PdfPTable(17)
            '''''''''''''tblChecked.WidthPercentage = 100
            '''''''''''''tblChecked.SetWidths(intTblChkWidth2)

            ''''''''''''''Dim imgSuare As Image = Image.GetInstance(SquareImage)
            ''''''''''''''imgSuare.ScalePercent(6)
            ''''''''''''''Dim SquareCheckBox As New Chunk(imgSuare, 0.1F, 0.1F)

            '''''''''''''Dim SquareCheckBox As New Paragraph(" ")
            '''''''''''''Dim SquareCheckBoxHeight As Integer = 10

            '''''''''''''cell = New PdfPCell(New Paragraph("Inward ", FontChecked))
            ''''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''tblChecked.AddCell(cell)

            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)

            '''''''''''''doc.Add(tblChecked)

            '''''''''''''tblChecked = New PdfPTable(17)
            '''''''''''''tblChecked.WidthPercentage = 100
            '''''''''''''tblChecked.SetWidths(intTblChkWidth2)
            '''''''''''''cell = New PdfPCell(New Paragraph("Outward", FontChecked))
            ''''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''tblChecked.AddCell(cell)

            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)
            '''''''''''''cell = New PdfPCell()
            '''''''''''''cell.FixedHeight = SquareCheckBoxHeight
            '''''''''''''cell.AddElement(SquareCheckBox)
            '''''''''''''cell.HorizontalAlignment = Element.ALIGN_CENTER
            '''''''''''''cell.PaddingBottom = 8
            '''''''''''''cell.PaddingLeft = 10
            '''''''''''''tblChecked.AddCell(cell)

            '''''''''''''doc.Add(tblChecked)

            'Dim P25 As New Paragraph()
            SingleLine = New Paragraph("")
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add(" ")
            doc.Add(SingleLine)

            'SingleLine = New Paragraph("")
            'SingleLine.Alignment = Element.ALIGN_LEFT
            'SingleLine.Add(" ")
            'doc.Add(SingleLine)

            Dim table5 As PdfPTable = New PdfPTable(2)
            table5.WidthPercentage = 100
            Dim header5 As PdfPCell = New PdfPCell()
            header5.Colspan = 1
            table.AddCell(header5) 'No pf Row


            ' cell = New PdfPCell(New Paragraph("  Received by", Font2))
            cell = New PdfPCell(New Paragraph(" ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)
            cell = New PdfPCell(New Paragraph("                 Customer Signature", Font2))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)

            doc.Add(table5)



            'Dim P26 As New Paragraph()
            'SingleLine = New Paragraph("")
            'SingleLine.Alignment = Element.ALIGN_LEFT
            'SingleLine.Add(" ")
            'doc.Add(SingleLine)

            Dim table6 As PdfPTable = New PdfPTable(1)
            table6.WidthPercentage = 100
            Dim header6 As PdfPCell = New PdfPCell()
            header6.Colspan = 4
            table6.AddCell(header6) 'No pf Row
            cell = New PdfPCell(New Paragraph("For GSS QuickGarage India Pvt Ltd", Font2))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)



            'Empty Row
            cell = New PdfPCell(New Paragraph(" "))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)


            'Empty Row
            cell = New PdfPCell(New Paragraph(" "))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)



            'table6.AddCell("For GSS QuickGarage India Pvt Ltd")
            cell = New PdfPCell(New Paragraph("                                                                           Authorized Signatory                                                           E.&O.E.", Font2))
            ' cell = New PdfPCell(New Paragraph("Authorized Signatory                                                                                                             E.&O.E."))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)
            doc.Add(table6)



            doc.Close()

        Catch ex As Exception
            'errFlg = 1
        Finally
            If fileStream IsNot Nothing Then
                fileStream.Close()
            End If
        End Try

        Call FileDownload(fname, "application/pdf")

    End Sub


    Protected Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        UpdateInfo("btnsave")
    End Sub

    Protected Sub save2_Click(sender As Object, e As EventArgs) Handles save2.Click
        UpdateInfo("btnsave2")
    End Sub


    Sub UpdateInfo(srcFunction As String)


        If Trim(txtPoNo.Text) = "" Then
            Call showMsg("Po No is invalid ", "")
            Exit Sub
        End If

        Dim str As String

        Dim AdvanceAmount As Decimal = 0.00



        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")
        Dim userid As String = Session("user_id")


        Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
        Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()


        If Trim(txtAdvance.Text) <> "" Then
            'Validate Labour cost is decimal 
            If Decimal.TryParse(txtAdvance.Text, AdvanceAmount) Then
            Else
                Call showMsg("Advance Amount is invalid ", "")
                Exit Sub
            End If
            _AppleQmvOrdModel.ADVANCE_PAYMENT = AdvanceAmount
        Else
            _AppleQmvOrdModel.ADVANCE_PAYMENT = AdvanceAmount
        End If



        _AppleQmvOrdModel.UserId = userid
        _AppleQmvOrdModel.SHIP_TO_BRANCH_CODE = shipCode
        _AppleQmvOrdModel.SHIP_TO_BRANCH = ShipName


        _AppleQmvOrdModel.PO_NO = txtPoNo.Text
        _AppleQmvOrdModel.PO_DATE = lblhidPoDate.Text
        _AppleQmvOrdModel.G_NO = txtGNo.Text
        _AppleQmvOrdModel.CUSTOMER_NAME = txtCustomerName.Text
        _AppleQmvOrdModel.ZIP_CODE = txtZip.Text
        _AppleQmvOrdModel.MOBLIE_PHONE = txtMobile.Text
        _AppleQmvOrdModel.TELEPHONE = txtTelephone.Text
        _AppleQmvOrdModel.GSTIN = txtGstin.Text
        _AppleQmvOrdModel.ADD_1 = txtAddressLine1.Text
        _AppleQmvOrdModel.ADD_2 = txtAddressLine2.Text
        _AppleQmvOrdModel.CITY = txtCity.Text
        _AppleQmvOrdModel.STATE = txtState.Text
        _AppleQmvOrdModel.ZIP_CODE = txtZip.Text
        _AppleQmvOrdModel.E_MAIL = txtEmail.Text


        _AppleQmvOrdModel.IS_SHIP_DIFF = chkShipped.Checked
        If chkShipped.Checked Then
            _AppleQmvOrdModel.CUSTOMER_NAME_SHIP = txtCustomerName.Text
            _AppleQmvOrdModel.ZIP_CODE_SHIP = txtZip.Text
            _AppleQmvOrdModel.MOBLIE_PHONE_SHIP = txtMobile.Text
            _AppleQmvOrdModel.TELEPHONE_SHIP = txtTelephone.Text
            _AppleQmvOrdModel.ADD_1_SHIP = txtAddressLine1.Text
            _AppleQmvOrdModel.ADD_2_SHIP = txtAddressLine2.Text
            _AppleQmvOrdModel.CITY_SHIP = txtCity.Text
            _AppleQmvOrdModel.STATE_SHIP = txtState.Text
            _AppleQmvOrdModel.E_MAIL_SHIP = txtEmail.Text
        Else
            _AppleQmvOrdModel.CUSTOMER_NAME_SHIP = txtCustomerNameShip.Text
            _AppleQmvOrdModel.ZIP_CODE_SHIP = txtZipShip.Text
            _AppleQmvOrdModel.MOBLIE_PHONE_SHIP = txtMobileShip.Text
            _AppleQmvOrdModel.TELEPHONE_SHIP = txtTelephoneShip.Text
            _AppleQmvOrdModel.ADD_1_SHIP = txtAddressLine1Ship.Text
            _AppleQmvOrdModel.ADD_2_SHIP = txtAddressLine2Ship.Text
            _AppleQmvOrdModel.CITY_SHIP = txtCityShip.Text
            _AppleQmvOrdModel.STATE_SHIP = txtStateShip.Text
            _AppleQmvOrdModel.E_MAIL_SHIP = txtEmailShip.Text
        End If




        _AppleQmvOrdModel.MODEL_NAME = txtModel.Text
        _AppleQmvOrdModel.PRODUCT_NAME = txtProduct.Text
        _AppleQmvOrdModel.SERIAL_NO = txtSerialNo.Text
        _AppleQmvOrdModel.IMEI_1 = txtImei1.Text
        _AppleQmvOrdModel.IMEI_2 = txtImei2.Text
        _AppleQmvOrdModel.DATE_OF_PURCHASE = txtDateOfPurchase.Text
        _AppleQmvOrdModel.SERVICE_TYPE = drpServiceType.SelectedItem.Value
        _AppleQmvOrdModel.COMPTIA = txtCompTia.Text
        _AppleQmvOrdModel.COMPTIA_MODIFIER = txtCompTiaModifier.Text
        _AppleQmvOrdModel.ACCESSORY_NOTE = txtAccessoryNote.Text


        _AppleQmvOrdModel.PART_NO1 = txtPartNo1.Text
        _AppleQmvOrdModel.PART_NO2 = txtPartNo2.Text
        _AppleQmvOrdModel.PART_NO3 = txtPartNo3.Text
        _AppleQmvOrdModel.PART_NO4 = txtPartNo4.Text
        _AppleQmvOrdModel.PART_DETAIL_1 = txtPartDetails1.Text
        _AppleQmvOrdModel.PART_DETAIL_2 = txtPartDetails2.Text
        _AppleQmvOrdModel.PART_DETAIL_3 = txtPartDetails3.Text
        _AppleQmvOrdModel.PART_DETAIL_4 = txtPartDetails4.Text
        _AppleQmvOrdModel.PART_QTY_1 = txtQty1.Text
        _AppleQmvOrdModel.PART_QTY_2 = txtQty2.Text
        _AppleQmvOrdModel.PART_QTY_3 = txtQty3.Text
        _AppleQmvOrdModel.PART_QTY_4 = txtQty4.Text

        If chkSerialPart1.Checked Then
            _AppleQmvOrdModel.SERIAL_STOCK_USED_1 = True
        End If
        If chkSerialPart2.Checked Then
            _AppleQmvOrdModel.SERIAL_STOCK_USED_2 = True
        End If
        If chkSerialPart3.Checked Then
            _AppleQmvOrdModel.SERIAL_STOCK_USED_3 = True
        End If
        If chkSerialPart4.Checked Then
            _AppleQmvOrdModel.SERIAL_STOCK_USED_4 = True
        End If

        _AppleQmvOrdModel.PART_DISCOUNT_1 = txtDiscount1.Text
        _AppleQmvOrdModel.PART_DISCOUNT_2 = txtDiscount2.Text
        _AppleQmvOrdModel.PART_DISCOUNT_3 = txtDiscount3.Text
        _AppleQmvOrdModel.PART_DISCOUNT_4 = txtDiscount4.Text

        '_AppleQmvOrdModel.PRICE_OPTIONS_1 = chkst1.Checked
        '_AppleQmvOrdModel.PRICE_OPTIONS_2 = chkst2.Checked
        '_AppleQmvOrdModel.PRICE_OPTIONS_3 = chkst3.Checked
        '_AppleQmvOrdModel.PRICE_OPTIONS_4 = chkst4.Checked

        _AppleQmvOrdModel.PRICE_OPTIONS_1_TYPE = drpSt1.SelectedItem.Value
        _AppleQmvOrdModel.PRICE_OPTIONS_2_TYPE = drpSt2.SelectedItem.Value
        _AppleQmvOrdModel.PRICE_OPTIONS_3_TYPE = drpSt3.SelectedItem.Value
        _AppleQmvOrdModel.PRICE_OPTIONS_4_TYPE = drpSt4.SelectedItem.Value

        _AppleQmvOrdModel.TRANSFER_REPAIR_CENTER = chkRepairCenter.Checked
        _AppleQmvOrdModel.ACTION_TAKEN = txtActionTaken.Text
        _AppleQmvOrdModel.RECEPTION = chkReception.Checked
        _AppleQmvOrdModel.INTERNAL_INSPECTION = chkInternalInspection.Checked
        _AppleQmvOrdModel.SIGNATURE_INSERVICE_ESTIMATE = chkSignatureInServiceEstimate.Checked
        _AppleQmvOrdModel.WHOLE_SERVICE_FEE_ADR_COLLECTION = chkWholeServiceFeeCollection.Checked
        _AppleQmvOrdModel.GSX_ORDER = chkGsxOrder.Checked
        _AppleQmvOrdModel.REPAIR = chkRepair.Checked
        _AppleQmvOrdModel.REMAINING_AMOUNT_COLLECTION = chkRemainingAmountCollection.Checked
        _AppleQmvOrdModel.LOANER_COLLECTION = chkLoanerCollection.Checked
        _AppleQmvOrdModel.SEVICE_REPORT = chkServiceReport.Checked
        _AppleQmvOrdModel.TAX_INVOICE = chkTaxInvoice.Checked



        'Newly Created in Database 
        _AppleQmvOrdModel.PART_HSN_ASC_1 = txtHsnSac1.Text
        _AppleQmvOrdModel.PART_HSN_ASC_2 = txtHsnSac2.Text
        _AppleQmvOrdModel.PART_HSN_ASC_3 = txtHsnSac3.Text
        _AppleQmvOrdModel.PART_HSN_ASC_4 = txtHsnSac4.Text

        _AppleQmvOrdModel.LABOR_AMOUNT = txtLabourAmount.Text
        _AppleQmvOrdModel.LABOR_DETAIL = txtLabourDetail.Text
        _AppleQmvOrdModel.LABOR_COST = txtLabourCost.Text
        _AppleQmvOrdModel.LABOR_DISCOUNT = txtLabourDiscount.Text
        'Doubt - HSN_SAC_CODE or need to create LABOR_HSN_SAC
        _AppleQmvOrdModel.HSN_SAC_CODE = txtLabourHsnSacCode.Text
        _AppleQmvOrdModel.LABOR_SALES = txtLabourSales.Text
        _AppleQmvOrdModel.LABOR_SGST = txtLabourSGST.Text
        _AppleQmvOrdModel.LABOR_CGST = txtLabourCGST.Text
        _AppleQmvOrdModel.LABOR_IGST = txtLabourIGST.Text
        _AppleQmvOrdModel.LABOR_TOTAL = txtLabourTotal.Text
        _AppleQmvOrdModel.PART_COST_1 = txtCost1.Text
        _AppleQmvOrdModel.PART_COST_2 = txtCost2.Text
        _AppleQmvOrdModel.PART_COST_3 = txtCost3.Text
        _AppleQmvOrdModel.PART_COST_4 = txtCost4.Text
        _AppleQmvOrdModel.PART_COST_SALES_1 = txtSalesPrice1.Text
        _AppleQmvOrdModel.PART_COST_SALES_2 = txtSalesPrice2.Text
        _AppleQmvOrdModel.PART_COST_SALES_3 = txtSalesPrice3.Text
        _AppleQmvOrdModel.PART_COST_SALES_4 = txtSalesPrice4.Text
        _AppleQmvOrdModel.PART_SGST_1 = txtSGST1.Text
        _AppleQmvOrdModel.PART_SGST_2 = txtSGST2.Text
        _AppleQmvOrdModel.PART_SGST_3 = txtSGST3.Text
        _AppleQmvOrdModel.PART_SGST_4 = txtSGST4.Text
        _AppleQmvOrdModel.PART_CGST_1 = txtCGST1.Text
        _AppleQmvOrdModel.PART_CGST_2 = txtCGST2.Text
        _AppleQmvOrdModel.PART_CGST_3 = txtCGST3.Text
        _AppleQmvOrdModel.PART_CGST_4 = txtCGST4.Text
        _AppleQmvOrdModel.PART_IGST_1 = txtIGST1.Text
        _AppleQmvOrdModel.PART_IGST_2 = txtIGST2.Text
        _AppleQmvOrdModel.PART_IGST_3 = txtIGST3.Text
        _AppleQmvOrdModel.PART_IGST_4 = txtIGST4.Text

        _AppleQmvOrdModel.PART1_TAX = txtPart1Tax.Text
        _AppleQmvOrdModel.PART2_TAX = txtPart2Tax.Text
        _AppleQmvOrdModel.PART3_TAX = txtPart3Tax.Text
        _AppleQmvOrdModel.PART4_TAX = txtPart4Tax.Text
        _AppleQmvOrdModel.LABOUR_TAX = txtLabourTax.Text
        _AppleQmvOrdModel.OTHER_TAX = txtOtherTax.Text


        _AppleQmvOrdModel.PART_TOTAL_1 = txtTotal1.Text
        _AppleQmvOrdModel.PART_TOTAL_2 = txtTotal2.Text
        _AppleQmvOrdModel.PART_TOTAL_3 = txtTotal3.Text
        _AppleQmvOrdModel.PART_TOTAL_4 = txtTotal4.Text
        _AppleQmvOrdModel.PART_QTY_AMOUNT = txtPartQtyAmount.Text
        _AppleQmvOrdModel.PART_COST_AMOUNT = txtPartCostAmount.Text
        _AppleQmvOrdModel.PART_DISCOUNT_AMOUNT = txtPartDiscountAmount.Text
        _AppleQmvOrdModel.PART_SALES_AMOUNT = txtPartSalesAmount.Text
        _AppleQmvOrdModel.PART_SGST_AMOUNT = txtPartSGSTAmount.Text
        _AppleQmvOrdModel.PART_CGST_AMOUNT = txtPartCGSTAmount.Text
        _AppleQmvOrdModel.PART_IGST_AMOUNT = txtPartIGSTAmount.Text
        _AppleQmvOrdModel.PART_TOTAL = txtPartTotal.Text
        _AppleQmvOrdModel.OTHER_QTY_AMOUNT = txtOtherQtyAmount.Text
        _AppleQmvOrdModel.OTHER_DETAIL = txtOtherDetail.Text
        _AppleQmvOrdModel.OTHER_COST = txtOtherCost.Text
        _AppleQmvOrdModel.OTHER_DISCOUNT = txtOtherDiscount.Text
        _AppleQmvOrdModel.OTHER_SALES = txtOtherSales.Text
        _AppleQmvOrdModel.OTHER_SGST = txtOtherSGST.Text
        _AppleQmvOrdModel.OTHER_CGST = txtOtherCGST.Text
        _AppleQmvOrdModel.OTHER_IGST = txtOtherIGST.Text
        _AppleQmvOrdModel.OTHER_TOTAL = txtOtherTotal.Text
        _AppleQmvOrdModel.TOTAL_QTY = txtTotalQty.Text
        _AppleQmvOrdModel.TOTAL_COST_AMOUNT = txtTotalCostAmount.Text
        _AppleQmvOrdModel.TOTAL_DISCOUNT_AMOUNT = txtDiscountAmount.Text
        _AppleQmvOrdModel.TOTAL_SALES_AMOUNT = txtTotalSalesAmount.Text
        _AppleQmvOrdModel.TOTAL_SGST_AMOUNT = txtTotalSGSTAmount.Text
        _AppleQmvOrdModel.TOTAL_CGST_AMOUNT = txtTotalCGSTAmount.Text
        _AppleQmvOrdModel.TOTAL_IGST_AMOUNT = txtTotalIGSTAmount.Text
        _AppleQmvOrdModel.TOTAL_AMOUNT = txtTotalAmount.Text
        _AppleQmvOrdModel.DELIVERY_DATE = txtDeliveryDate.Text
        _AppleQmvOrdModel.COMP_STATUS = drpCompStatus.SelectedItem.Value
        '_AppleQmvOrdModel.COMP_DATE = txtCompDate.Text
        _AppleQmvOrdModel.DENOMINATION = drpDenomination.SelectedItem.Value
        If (srcFunction = "btnestimate") Then
            txtEstimatedDate.Text = Now
            _AppleQmvOrdModel.ESTIMATE_DATE = txtEstimatedDate.Text
        End If
        _AppleQmvOrdModel.ESTIMATE_TIME = ""
        _AppleQmvOrdModel.GSX_CLOSE_DATE = txtGSXCloseDate.Text
        _AppleQmvOrdModel.USE_SERVICE_TYPE = ""
        _AppleQmvOrdModel.INVOICE_NOTE = txtInvoiceNote.Text
        _AppleQmvOrdModel.GSX_NOTE = txtGsxNote.Text
        ''''''''''' _AppleQmvOrdModel.HSN_SAC_CODE = ""
        _AppleQmvOrdModel.GSTIN = txtGstin.Text




        _AppleQmvOrdModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress

        Dim blStatus As Boolean = False

        'Added 20220201
        Dim strInventoryFlg As String = ""
        Try
            strInventoryFlg = ConfigurationManager.AppSettings("AppInv")
        Catch ex As Exception
        End Try
        If strInventoryFlg = "yes" Then
            _AppleQmvOrdModel.INVENTORY_FLG = True
        End If

        blStatus = _AppleQmvOrdControl.AddQmvOrd(_AppleQmvOrdModel)


        If blStatus Then
            'ClearTextbox()
            'drpServiceType.SelectedIndex = drpServiceType.Items.IndexOf(drpServiceType.Items.FindByValue(0))
            'ChangeColor(0)

            txtPoNo.Enabled = False

            Call showMsg("Successfully Saved...", "")
            Exit Sub
        Else

            If (drpServiceType.SelectedItem.Value = "5") Then
                Call showMsg("Required Parts Is Not Sufficient!!!, Please Check ACC Parts In Stock", "")
                Exit Sub
            End If
        End If
    End Sub

    'Protected Sub drpServiceType1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpServiceType1.SelectedIndexChanged
    '    lblMsg.Text = "test"
    'End Sub



    Private Sub Btninvoice_Click(sender As Object, e As EventArgs) Handles Btninvoice.Click



        '1st Check PO
        txtPoNo.Text = Trim(txtPoNo.Text)
        If txtPoNo.Text = "" Then
            Call showMsg("PO No is not allowed empty", "")
            Exit Sub
        End If


        '2nd Check G No
        'txtGNo.Text = Trim(txtGNo.Text)
        'If txtGNo.Text = "" Then
        'Call showMsg("G No is not allowed empty", "")
        'Exit Sub
        'End If


        txtCustomerName.Text = Trim(txtCustomerName.Text)
        If txtCustomerName.Text = "" Then
            Call showMsg("CustomerName is not allowed empty", "")
            Exit Sub
        End If


        Dim fileStream As FileStream
        Dim logoQuickGarage As String = "C:\money\gss_asp.png"
        'Dim logoApple As String = "C:\money\apple_logo.jpg"

        Dim saveCsvPass As String = "C:\money\CSV\"
        Dim savePDFPass As String = "C:\money\PDF\"

        Dim fname = txtPoNo.Text & "_" & System.DateTime.Now.Millisecond.ToString() & ".pdf"

        Dim InvoiceNo As String = ""
        Dim InvoiceDate As String = ""

        Dim filename As String = savePDFPass & fname

        Try

            Dim SingleLine As New Paragraph()
            Dim doc As Document
            Dim pdfWriter As PdfWriter
            Dim image1 As Image = Image.GetInstance(logoQuickGarage) '画像
            image1.ScalePercent(7) '大きさ

            'Dim image2 As Image = Image.GetInstance(logoApple) '画像
            'image2.ScalePercent(7) '大きさ

            fileStream = New FileStream(filename, FileMode.Create)

            doc = New Document(PageSize.A4, 5, 5, 5, 5)
            Dim bf As BaseFont = BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.CP1252, False)
            Dim Font3 As Font = New Font(bf, 10, Font.NORMAL)

            pdfWriter = PdfWriter.GetInstance(doc, fileStream)
            doc.Open()

            Dim pcb As PdfContentByte = pdfWriter.DirectContent

            Dim cell As PdfPCell



            Dim psam As New Paragraph()
            psam.Alignment = Element.ALIGN_LEFT
            psam.Add(" ")
            doc.Add(psam)
            Dim psam1 As New Paragraph()
            psam1.Add(".")
            psam1.Alignment = Element.ALIGN_LEFT
            doc.Add(psam1)
            image1.ScaleAbsolute(380.0F, 45.0F)
            Dim p As New Paragraph()
            p.Add(New Chunk(image1, 0, 0))
            p.Alignment = Element.ALIGN_LEFT
            doc.Add(p)



            Dim table As PdfPTable = New PdfPTable(5)
            table.WidthPercentage = 100
            Dim intTblWidth() As Integer = {25, 40, 1, 25, 40}
            table.SetWidths(intTblWidth)

            Dim table41 As PdfPTable = New PdfPTable(2)
            table41.WidthPercentage = 100
            Dim header41 As PdfPCell = New PdfPCell()
            header41.Colspan = 2
            table.AddCell(header41) 'No pf Row
            cell = New PdfPCell(New Paragraph("GSS quick garage pvt.LTD", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)


            Dim FntCode39 As New Font(BaseFont.CreateFont("c:\money\CODE39.ttf", BaseFont.IDENTITY_H, True), 12) 'バ
            ' cell = New PdfPCell(New Paragraph("*" & Right(otherData.po_no, Len(otherData.po_no) - 2) & "*", fntBa2))
            If Len(txtSerialNo.Text) > 2 Then
                cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", FntCode39))
            Else
                cell = New PdfPCell(New Paragraph(" "))
            End If

            ' cell = New PdfPCell(New Paragraph("1234567891023450", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Paragon Plaza,Phoenix Market City,", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("PO No. " & Trim(txtPoNo.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("L B S Marg,Kurla west,Mubai 400070", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("	", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Telephone: +91-9500043584", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(" ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)
            cell = New PdfPCell(New Paragraph("gss.asc1@quickgarage.co.in", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            'Comment on 20210621
            'cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1ZH  CIN: U74999TN2016FTC112554 ", Font3))
            cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1ZH                              ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            doc.Add(table41)

            Dim ParaB As New Paragraph("Business Hours: 10:00AM to 7:00 PM Weekly Off Sunday", Font3)
            ParaB.Alignment = Element.ALIGN_LEFT
            'P9.Add("Tax Invoice")
            'P9.Font = FontFactory.GetFont("Segoe UI", 18.0, BaseColor.ORANGE)
            doc.Add(ParaB)

            Dim fnt4 As New Font(BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, True), 16, iTextSharp.text.Font.UNDERLINE)
            Dim fnt5 As New Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False))
            Dim Font1 As Font = New Font(bf, 14, Font.BOLD)
            Dim Font2 As Font = New Font(bf, 10, Font.BOLD)

            'Dim P9 As New Paragraph("", Font1)
            SingleLine = New Paragraph("", Font2)
            SingleLine.Alignment = Element.ALIGN_CENTER
            SingleLine.Add("Tax Invoice")
            SingleLine.Font = FontFactory.GetFont("Segoe UI", 18.0, BaseColor.ORANGE)
            doc.Add(SingleLine)


            'Dim P10 As New Paragraph()
            SingleLine = New Paragraph("")
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add("" & vbLf)
            doc.Add(SingleLine)

            Dim header As PdfPCell = New PdfPCell()
            header.Colspan = 4
            table.AddCell(header)



            Dim _AppleQmvOrdModel As AppleQmvOrdModel = New AppleQmvOrdModel()
            Dim _AppleQmvOrdControl As AppleQmvOrdControl = New AppleQmvOrdControl()
            _AppleQmvOrdModel.PO_NO = Trim(txtPoNo.Text)
            Dim dtAppleQmv As DataTable = _AppleQmvOrdControl.SelectPo(_AppleQmvOrdModel)
            If (dtAppleQmv Is Nothing) Or (dtAppleQmv.Rows.Count = 0) Then

            Else
                If Not IsDBNull(dtAppleQmv.Rows(0)("INVOICE_NO")) Then
                    InvoiceNo = dtAppleQmv.Rows(0)("INVOICE_NO")
                End If
                If Not IsDBNull(dtAppleQmv.Rows(0)("INVOICE_DATE")) Then
                    InvoiceDate = dtAppleQmv.Rows(0)("INVOICE_DATE")
                End If

            End If

            cell = New PdfPCell(New Paragraph("Invoice No.			", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((InvoiceNo), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderColorTop = BaseColor.LIGHT_GRAY
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Invoice Date", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((InvoiceDate), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'Doubt
            'cell = New PdfPCell(New Paragraph(txtEstimatedDate.Text))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            '' cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)



            'header = New PdfPCell()

            'table.AddCell(header)
            cell = New PdfPCell(New Paragraph("PO No.			", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPoNo.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("Place Of Supply	 ", Font3))
            cell = New PdfPCell(New Paragraph("Mode Of Payment", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(drpDenomination.SelectedItem.Text, Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'Doubt
            'cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)

            'header = New PdfPCell()

            'table.AddCell(header)
            cell = New PdfPCell(New Paragraph("Serial No.			", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSerialNo.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)

            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("GSTIN/Unique ID     ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(Trim(txtGstin.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Repair Coverage			", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)

            cell = New PdfPCell(New Paragraph((drpServiceType.SelectedItem.Text), Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" ", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" ", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)

            doc.Add(table)

            Dim tablec As PdfPTable = New PdfPTable(3)
            tablec.WidthPercentage = 100
            Dim intTblWidthc() As Integer = {20, 1, 20}
            tablec.SetWidths(intTblWidthc)

            cell = New PdfPCell(New Paragraph("	Details of Consignee(Billed to) ", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tablec.AddCell(cell)
            cell = New PdfPCell(New Paragraph("	", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tablec.AddCell(cell)




            'cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Details of Consignee(Shipped to)															", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tablec.AddCell(cell)
            doc.Add(tablec)
            'cell = New PdfPCell(New Paragraph(" ", Font3))
            ''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)
            Dim tables As PdfPTable = New PdfPTable(5)
            tables.WidthPercentage = 100
            Dim intTblWidths() As Integer = {15, 40, 1, 15, 40}
            tables.SetWidths(intTblWidths)

            cell = New PdfPCell(New Paragraph("Name		 ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtCustomerName.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)




            cell = New PdfPCell(New Paragraph("Name		 ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)


            If chkShipped.Checked Then
                cell = New PdfPCell(New Paragraph((txtCustomerName.Text), Font3))
            Else
                cell = New PdfPCell(New Paragraph((txtCustomerNameShip.Text), Font3))
            End If
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Address		 ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtAddressLine1.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Address", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)


            If chkShipped.Checked Then
                cell = New PdfPCell(New Paragraph((txtAddressLine1.Text), Font3))
            Else
                cell = New PdfPCell(New Paragraph((txtAddressLine1Ship.Text), Font3))
            End If
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))

            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)


            cell = New PdfPCell(New Paragraph("City		", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtCity.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph("City		 ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)

            If chkShipped.Checked Then
                cell = New PdfPCell(New Paragraph((txtCity.Text), Font3))
            Else
                cell = New PdfPCell(New Paragraph((txtCityShip.Text), Font3))
            End If
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)

            cell = New PdfPCell(New Paragraph("State: " & Trim(txtState.Text) & "    Postal Code: " & Trim(txtZip.Text), Font3))
            cell.Colspan = 2
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            ' cell = New PdfPCell(New Paragraph(("Postal Code: " & Trim(txtZip.Text)), Font3))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ' 'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ' tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)



            If chkShipped.Checked Then
                cell = New PdfPCell(New Paragraph("State: " & Trim(txtState.Text) & "    Postal Code: " & Trim(txtZip.Text), Font3))
            Else
                cell = New PdfPCell(New Paragraph("State: " & Trim(txtStateShip.Text) & "    Postal Code: " & Trim(txtZipShip.Text), Font3))
            End If

            cell.Colspan = 2
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            'cell = New PdfPCell(New Paragraph((txtZip.Text), Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'tables.AddCell(cell)























            If (Trim(txtMobile.Text) <> "") And (Trim(txtEmail.Text) <> "") Then
                cell = New PdfPCell(New Paragraph("Mobile: " & txtMobile.Text & "    E-mail: " & txtEmail.Text, Font3))
                'cell = New PdfPCell(New Paragraph("State: " & Trim(txtState.Text) & "    Postal Code: " & Trim(txtZip.Text), Font3))
            ElseIf (Trim(txtMobile.Text) <> "") Then
                cell = New PdfPCell(New Paragraph("Mobile: " & txtMobile.Text, Font3))
            ElseIf (Trim(txtEmail.Text) <> "") Then
                cell = New PdfPCell(New Paragraph("E-mail: " & txtEmail.Text, Font3))
            Else
                cell = New PdfPCell(New Paragraph("Mobile: ", Font3))
            End If
            'cell = New PdfPCell(New Paragraph("State: " & Trim(txtState.Text) & "    Postal Code: " & Trim(txtZip.Text), Font3))
            cell.Colspan = 2
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)


            If chkShipped.Checked Then
                If (Trim(txtMobile.Text) <> "") And (Trim(txtEmail.Text) <> "") Then
                    cell = New PdfPCell(New Paragraph("Mobile: " & txtMobile.Text & "    E-mail: " & txtEmail.Text, Font3))
                    'cell = New PdfPCell(New Paragraph("State: " & Trim(txtState.Text) & "    Postal Code: " & Trim(txtZip.Text), Font3))
                ElseIf (Trim(txtMobile.Text) <> "") Then
                    cell = New PdfPCell(New Paragraph("Mobile: " & txtMobile.Text, Font3))
                ElseIf (Trim(txtEmail.Text) <> "") Then
                    cell = New PdfPCell(New Paragraph("E-mail: " & txtEmail.Text, Font3))
                Else
                    cell = New PdfPCell(New Paragraph("Mobile: ", Font3))
                End If
            Else
                If (Trim(txtMobileShip.Text) <> "") And (Trim(txtEmailShip.Text) <> "") Then
                    cell = New PdfPCell(New Paragraph("Mobile: " & txtMobileShip.Text & "    E-mail: " & txtEmailShip.Text, Font3))
                    'cell = New PdfPCell(New Paragraph("State: " & Trim(txtState.Text) & "    Postal Code: " & Trim(txtZip.Text), Font3))
                ElseIf (Trim(txtMobileShip.Text) <> "") Then
                    cell = New PdfPCell(New Paragraph("Mobile: " & txtMobileShip.Text, Font3))
                ElseIf (Trim(txtEmailShip.Text) <> "") Then
                    cell = New PdfPCell(New Paragraph("E-mail: " & txtEmailShip.Text, Font3))
                Else
                    cell = New PdfPCell(New Paragraph("Mobile: ", Font3))
                End If
            End If



            'cell = New PdfPCell(New Paragraph("State: " & Trim(txtStateShip.Text) & "    Postal Code: " & Trim(txtZipShip.Text), Font3))
            cell.Colspan = 2
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)













            doc.Add(tables)
            'doc.Add(table)


            Dim strtxtAccessoryNote As String = ""
            strtxtAccessoryNote = Trim(txtAccessoryNote.Text)
            If Len(strtxtAccessoryNote) > 1 Then
                strtxtAccessoryNote = strtxtAccessoryNote.Replace(vbLf, " ").Replace(vbCr, " ")
                Dim table51 As PdfPTable = New PdfPTable(1)
                table51.WidthPercentage = 100
                Dim header51 As PdfPCell = New PdfPCell()
                header51.Colspan = 1
                table.AddCell(header51) 'No pf Row

                cell = New PdfPCell(New Paragraph("Product Received & Condition: " & strtxtAccessoryNote, Font2))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table51.AddCell(cell)
                doc.Add(table51)
            End If


            'Dim P11 As New Paragraph()
            SingleLine = New Paragraph("")
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add("" & vbLf)
            doc.Add(SingleLine)

            Dim tmpSales As Decimal = 0.00
            Dim tmpDiscount As Decimal = 0.00
            Dim tmpTotal As Decimal = 0.00

            Dim table2 As PdfPTable = New PdfPTable(12)
            table2.WidthPercentage = 100
            Dim header2 As PdfPCell = New PdfPCell()
            header2.Colspan = 2
            table.AddCell(header2) 'No pf Row

            Dim TmpPercentage As Decimal = 0.00

            Dim intTblWidth10() As Integer = {4, 15, 40, 5, 10, 10, 10, 12, 7, 10, 10, 13}
            table2.SetWidths(intTblWidth10)
            Dim FontInvoice As Font = New Font(bf, 7, Font.NORMAL)

            'table2.AddCell("Sr No..")
            cell = New PdfPCell(New Paragraph("Sr No", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Item No", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Description", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Qty", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Unit Price", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Total", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Discount", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("TaxableValue", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Tax %", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("CGST", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("SGST", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Total", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)




            cell = New PdfPCell(New Paragraph("", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("HSN/SAC", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph("Serial No.", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            ' table2.AddCell("											")
            cell = New PdfPCell(New Paragraph("", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Amount", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph("Amount", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            Dim intSrNo As Integer = 0

            If Trim(txtLabourAmount.Text) <> "" Then
                intSrNo = intSrNo + 1
                cell = New PdfPCell(New Paragraph(intSrNo, FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtLabourAmount.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'txtPartDetails1.Text
                cell = New PdfPCell(New Paragraph((txtLabourDetail.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'txtQty1.Text
                cell = New PdfPCell(New Paragraph((" "), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'txtSalesPrice1.Text
                cell = New PdfPCell(New Paragraph((txtLabourCost.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                If Trim(txtLabourDiscount.Text) <> "" Then
                    'Validate Labour cost is decimal 
                    If Decimal.TryParse(txtLabourDiscount.Text, tmpDiscount) Then
                    Else
                        Call showMsg("Labour Discount is invalid ", "")
                        Exit Sub
                    End If
                    If Decimal.TryParse(txtLabourSales.Text, tmpSales) Then
                    Else
                        Call showMsg("Labour Price is invalid ", "")
                        Exit Sub
                    End If
                    tmpTotal = clsSet.setINR(tmpSales + tmpDiscount)
                Else
                    tmpTotal = txtLabourSales.Text
                End If


                'txtTotal1.Text
                cell = New PdfPCell(New Paragraph((tmpTotal), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtLabourDiscount.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtLabourSales.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                If Trim(txtLabourTax.Text) <> "" Then
                    If Decimal.TryParse(txtLabourTax.Text, TmpPercentage) Then
                        TmpPercentage = TmpPercentage * 2
                    Else
                        Call showMsg("Labour Tax is invalid ( " & txtLabourTax.Text & ")", "")
                        Exit Sub
                    End If
                    cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), FontInvoice))
                Else
                    cell = New PdfPCell(New Paragraph(Trim(" "), FontInvoice))
                End If
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)



                cell = New PdfPCell(New Paragraph((txtLabourCGST.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtLabourSGST.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtLabourTotal.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph((" "), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' table2.AddCell("											")
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

            End If



            If Trim(txtPartNo1.Text) <> "" Then
                intSrNo = intSrNo + 1
                cell = New PdfPCell(New Paragraph(intSrNo, FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtPartNo1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtPartDetails1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtQty1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCost1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                If Trim(txtDiscount1.Text) <> "" Then
                    'Validate Labour cost is decimal 
                    If Decimal.TryParse(txtDiscount1.Text, tmpDiscount) Then
                    Else
                        Call showMsg("Discount1 is invalid ", "")
                        Exit Sub
                    End If
                    If Decimal.TryParse(txtSalesPrice1.Text, tmpSales) Then
                    Else
                        Call showMsg("Sales Price1 is invalid ", "")
                        Exit Sub
                    End If
                    tmpTotal = clsSet.setINR(tmpSales + tmpDiscount)
                Else
                    tmpTotal = txtSalesPrice1.Text
                End If

                cell = New PdfPCell(New Paragraph((tmpTotal), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtDiscount1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtSalesPrice1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                If Trim(txtPart1Tax.Text) <> "" Then
                    If Decimal.TryParse(txtPart1Tax.Text, TmpPercentage) Then
                        TmpPercentage = TmpPercentage * 2
                    Else
                        Call showMsg("Part 1 Tax is invalid ( " & txtPart1Tax.Text & ")", "")
                        Exit Sub
                    End If
                    cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), FontInvoice))
                Else
                    cell = New PdfPCell(New Paragraph(Trim(" "), FontInvoice))
                End If

                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtCGST1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtSGST1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtTotal1.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph((txtSerialNo.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' table2.AddCell("											")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

            End If


            If Trim(txtPartNo2.Text) <> "" Then
                intSrNo = intSrNo + 1
                cell = New PdfPCell(New Paragraph(intSrNo, FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtPartNo2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtPartDetails2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtQty2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCost2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                If Trim(txtDiscount2.Text) <> "" Then
                    'Validate Labour cost is decimal 
                    If Decimal.TryParse(txtDiscount2.Text, tmpDiscount) Then
                    Else
                        Call showMsg("Discount2 is invalid ", "")
                        Exit Sub
                    End If
                    If Decimal.TryParse(txtSalesPrice2.Text, tmpSales) Then
                    Else
                        Call showMsg("Sales Price2 is invalid ", "")
                        Exit Sub
                    End If
                    tmpTotal = clsSet.setINR(tmpSales + tmpDiscount)
                Else
                    tmpTotal = txtSalesPrice2.Text
                End If




                cell = New PdfPCell(New Paragraph((tmpTotal), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtDiscount2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtSalesPrice2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                If Trim(txtPart2Tax.Text) <> "" Then
                    If Decimal.TryParse(txtPart2Tax.Text, TmpPercentage) Then
                        TmpPercentage = TmpPercentage * 2
                    Else
                        Call showMsg("Part 2 Tax is invalid ( " & txtPart2Tax.Text & ")", "")
                        Exit Sub
                    End If
                    cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), FontInvoice))
                Else
                    cell = New PdfPCell(New Paragraph(Trim(" "), FontInvoice))
                End If

                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtCGST2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtSGST2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtTotal2.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' table2.AddCell("											")
                cell = New PdfPCell(New Paragraph("", FontInvoice))

                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
            End If


            If Trim(txtPartNo3.Text) <> "" Then
                intSrNo = intSrNo + 1
                cell = New PdfPCell(New Paragraph(intSrNo, FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtPartNo3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtPartDetails3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtQty3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCost3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                If Trim(txtDiscount3.Text) <> "" Then
                    'Validate Labour cost is decimal 
                    If Decimal.TryParse(txtDiscount3.Text, tmpDiscount) Then
                    Else
                        Call showMsg("Discount3 is invalid ", "")
                        Exit Sub
                    End If
                    If Decimal.TryParse(txtSalesPrice3.Text, tmpSales) Then
                    Else
                        Call showMsg("Sales Price3 is invalid ", "")
                        Exit Sub
                    End If
                    tmpTotal = clsSet.setINR(tmpSales + tmpDiscount)
                Else
                    tmpTotal = txtSalesPrice3.Text
                End If



                cell = New PdfPCell(New Paragraph((tmpTotal), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtDiscount3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtSalesPrice3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                If Trim(txtPart3Tax.Text) <> "" Then
                    If Decimal.TryParse(txtPart3Tax.Text, TmpPercentage) Then
                        TmpPercentage = TmpPercentage * 2
                    Else
                        Call showMsg("Part 3 Tax is invalid ( " & txtPart3Tax.Text & ")", "")
                        Exit Sub
                    End If
                    cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), FontInvoice))
                Else
                    cell = New PdfPCell(New Paragraph(Trim(" "), FontInvoice))
                End If

                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtCGST3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtSGST3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtTotal3.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph((""), FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' table2.AddCell("											")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
            End If



            If Trim(txtPartNo4.Text) <> "" Then
                intSrNo = intSrNo + 1
                cell = New PdfPCell(New Paragraph(intSrNo, FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtPartNo4.Text), FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtPartDetails4.Text), FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtQty4.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCost4.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                If Trim(txtDiscount4.Text) <> "" Then
                    'Validate Labour cost is decimal 
                    If Decimal.TryParse(txtDiscount4.Text, tmpDiscount) Then
                    Else
                        Call showMsg("Discount4 is invalid ", "")
                        Exit Sub
                    End If
                    If Decimal.TryParse(txtSalesPrice4.Text, tmpSales) Then
                    Else
                        Call showMsg("Sales Price4 is invalid ", "")
                        Exit Sub
                    End If
                    tmpTotal = clsSet.setINR(tmpSales + tmpDiscount)
                Else
                    tmpTotal = txtSalesPrice4.Text
                End If

                cell = New PdfPCell(New Paragraph((tmpTotal), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtDiscount4.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtSalesPrice4.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                If Trim(txtPart4Tax.Text) <> "" Then
                    If Decimal.TryParse(txtPart4Tax.Text, TmpPercentage) Then
                        TmpPercentage = TmpPercentage * 2
                    Else
                        Call showMsg("Part 4 Tax is invalid ( " & txtPart4Tax.Text & ")", "")
                        Exit Sub
                    End If
                    cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), FontInvoice))
                Else
                    cell = New PdfPCell(New Paragraph(Trim(" "), FontInvoice))
                End If

                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtCGST4.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtSGST4.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtTotal4.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)




                cell = New PdfPCell(New Paragraph("", FontInvoice))

                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' table2.AddCell("											")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

            End If

            If Trim(txtOtherQtyAmount.Text) <> "" Then
                intSrNo = intSrNo + 1
                cell = New PdfPCell(New Paragraph(intSrNo, FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((" "), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'txtPartDetails1.Text
                cell = New PdfPCell(New Paragraph((txtOtherDetail.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'txtQty1.Text
                cell = New PdfPCell(New Paragraph((" "), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'txtSalesPrice1.Text
                cell = New PdfPCell(New Paragraph((txtOtherCost.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)


                If Trim(txtOtherDiscount.Text) <> "" Then
                    'Validate Labour cost is decimal 
                    If Decimal.TryParse(txtOtherDiscount.Text, tmpDiscount) Then
                    Else
                        Call showMsg("Other Discount is invalid ", "")
                        Exit Sub
                    End If
                    If Decimal.TryParse(txtOtherSales.Text, tmpSales) Then
                    Else
                        Call showMsg("Sales Other is invalid ", "")
                        Exit Sub
                    End If
                    tmpTotal = clsSet.setINR(tmpSales + tmpDiscount)
                Else
                    tmpTotal = txtOtherSales.Text
                End If



                'txtTotal1.Text
                cell = New PdfPCell(New Paragraph((tmpTotal), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtOtherDiscount.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtOtherSales.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                If Trim(txtOtherTax.Text) <> "" Then
                    If Decimal.TryParse(txtOtherTax.Text, TmpPercentage) Then
                        TmpPercentage = TmpPercentage * 2
                    Else
                        Call showMsg("Other Tax is invalid ( " & txtOtherTax.Text & ")", "")
                        Exit Sub
                    End If
                    cell = New PdfPCell(New Paragraph(clsSet.setINR(TmpPercentage), FontInvoice))
                Else
                    cell = New PdfPCell(New Paragraph(Trim(" "), FontInvoice))
                End If

                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph((txtOtherCGST.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtOtherSGST.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph((txtOtherTotal.Text), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)



                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph((" "), FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' table2.AddCell("											")
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

            End If

            Do While intSrNo < 4
                intSrNo = intSrNo + 1
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)

                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)




                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph(" ", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                ' table2.AddCell("											")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph(""))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                'table2.AddCell("	")
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
                cell = New PdfPCell(New Paragraph("", FontInvoice))
                cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
                cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
                'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
                table2.AddCell(cell)
            Loop

            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Total", FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotalSalesAmount.Text, FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(" ", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtTotalCGSTAmount.Text, FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotalSGSTAmount.Text, FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotalAmount.Text, FontInvoice))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("."))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            ' Dim test = Convert.ToInt32(txtCGST1.Text) + Convert.ToInt32(txtCGST2.Text) + Convert.ToInt32(txtCGST3.Text) + Convert.ToInt32(txtCGST4.Text)
            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            doc.Add(table2)

            'Dim p6 As New Paragraph()
            SingleLine = New Paragraph("")
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add(" ")
            doc.Add(SingleLine)

            'Begin
            '**********************************
            Dim table30 As PdfPTable = New PdfPTable(3)
            table30.WidthPercentage = 100

            Dim intTblWidth1() As Integer = {1, 15, 50}
            table30.SetWidths(intTblWidth1)
            table30.HorizontalAlignment = Element.ALIGN_RIGHT
            Dim header30 As PdfPCell = New PdfPCell()
            header30.Colspan = 3
            table.AddCell(header30) 'No pf Row
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table30.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Invoice Total									", Font3))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table30.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotalAmount.Text, Font3))
            table30.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table30.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table3.AddCell(cell)

            doc.Add(table30)


            Dim table3 As PdfPTable = New PdfPTable(3)
            table3.WidthPercentage = 100
            Dim header3 As PdfPCell = New PdfPCell()
            header3.Colspan = 3
            table3.SetWidths(intTblWidth1)
            table3.HorizontalAlignment = Element.ALIGN_RIGHT
            table.AddCell(header3) 'No pf Row
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table3.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Invoice Total(In Words)									", Font3))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table3.AddCell(cell)

            Dim strMoneyText As String = ""
            If Len(txtTotalAmount.Text) >= 1 Then
                'strMoneyText = NumberToText(txtTotalAmount.Text)
                strMoneyText = num2str(txtTotalAmount.Text)
                strMoneyText = strMoneyText & " Only"
            End If

            cell = New PdfPCell(New Paragraph(strMoneyText, Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table3.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table3.AddCell(cell)

            doc.Add(table3)

            Dim table31 As PdfPTable = New PdfPTable(3)
            table31.WidthPercentage = 100
            Dim header31 As PdfPCell = New PdfPCell()
            header31.Colspan = 3
            table31.SetWidths(intTblWidth1)
            table31.HorizontalAlignment = Element.ALIGN_RIGHT
            table.AddCell(header31) 'No pf Row
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table31.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Advance Received													", Font3))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table31.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtAdvance.Text, Font3))
            table31.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table31.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table3.AddCell(cell)

            doc.Add(table31)

            Dim table32 As PdfPTable = New PdfPTable(3)
            table32.WidthPercentage = 100
            Dim header32 As PdfPCell = New PdfPCell()
            header32.Colspan = 3
            table32.SetWidths(intTblWidth1)
            table32.HorizontalAlignment = Element.ALIGN_RIGHT
            table.AddCell(header32) 'No pf Row
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table32.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Advance Received(In Words))																						", Font3))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table32.AddCell(cell)
            strMoneyText = ""
            If Len(txtAdvance.Text) >= 1 Then
                If Trim(txtAdvance.Text) = "0.00" Then
                    strMoneyText = strMoneyText & "N/A"
                Else
                    'strMoneyText = NumberToText(txtAdvance.Text)
                    strMoneyText = num2str(txtAdvance.Text)
                    strMoneyText = strMoneyText & " Only"
                End If
            End If
            cell = New PdfPCell(New Paragraph(strMoneyText, Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table32.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table3.AddCell(cell)

            doc.Add(table32)

            Dim table33 As PdfPTable = New PdfPTable(3)
            table33.WidthPercentage = 100
            ' Dim intTblWidth2() As Integer = {19, 21, 15}
            table33.SetWidths(intTblWidth1)
            table33.HorizontalAlignment = Element.ALIGN_RIGHT
            Dim header33 As PdfPCell = New PdfPCell()
            header33.Colspan = 3
            table.AddCell(header33) 'No pf Row
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table33.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Payable Value																														", Font3))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table33.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtBalance.Text, Font3))
            table33.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table33.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table3.AddCell(cell)

            doc.Add(table33)

            Dim table34 As PdfPTable = New PdfPTable(3)
            table34.WidthPercentage = 100
            'Dim intTblWidth3() As Integer = {19, 21, 15}
            table34.SetWidths(intTblWidth1)
            table34.HorizontalAlignment = Element.ALIGN_RIGHT
            Dim header34 As PdfPCell = New PdfPCell()
            header34.Colspan = 3
            table.AddCell(header34) 'No pf Row
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table34.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Payable Value(In Words)									
																																							", Font3))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table34.AddCell(cell)
            If Len(txtBalance.Text) >= 1 Then
                If Trim(txtBalance.Text) = "0.00" Then
                    strMoneyText = strMoneyText & "N/A"
                Else
                    'strMoneyText = NumberToText(txtBalance.Text)
                    strMoneyText = num2str(txtBalance.Text)
                    strMoneyText = strMoneyText & " Only"
                End If
            End If
            cell = New PdfPCell(New Paragraph(strMoneyText, Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table34.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table3.AddCell(cell)

            doc.Add(table34)
            '************************
            'End


            'Dim P17 As New Paragraph("", Font3)
            SingleLine = New Paragraph("", Font3)
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add("I understand the above")
            doc.Add(SingleLine)

            'Dim P25 As New Paragraph("", Font3)
            SingleLine = New Paragraph("", Font3)
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add("I received the main body and confirmed the repair contents")
            doc.Add(SingleLine)


            Dim table5 As PdfPTable = New PdfPTable(3)
            table5.WidthPercentage = 50
            'Dim intTblWidth3() As Integer = {19, 21, 15}
            table5.SetWidths(intTblWidth1)
            table5.HorizontalAlignment = Element.ALIGN_RIGHT
            Dim header5 As PdfPCell = New PdfPCell()
            header5.Colspan = 3
            table.AddCell(header5) 'No pf Row
            cell = New PdfPCell(New Paragraph("  "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Date", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Customer Signature", Font3))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)

            doc.Add(table5)


            'Dim P26 As New Paragraph()
            SingleLine = New Paragraph("")
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add(" ")
            doc.Add(SingleLine)

            Dim table6 As PdfPTable = New PdfPTable(1)
            table6.WidthPercentage = 100
            Dim header6 As PdfPCell = New PdfPCell()
            header6.Colspan = 4
            table6.AddCell(header6) 'No pf Row
            cell = New PdfPCell(New Paragraph("For GSS QuickGarage India Pvt Ltd", Font3))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)



            'Empty Row
            cell = New PdfPCell(New Paragraph(" "))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)


            'table6.AddCell("For GSS QuickGarage India Pvt Ltd")
            '
            cell = New PdfPCell(New Paragraph("                                                                                Authorized Signatory                                                                        E.&O.E.", Font3))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)
            doc.Add(table6)

            '*************************
            'Final End



            Dim Font4 As Font = New Font(bf, 6, Font.NORMAL)
            'Dim P15 As New Paragraph("", Font4)
            SingleLine = New Paragraph("", Font4)
            SingleLine.Alignment = Element.ALIGN_LEFT
            SingleLine.Add("* Contact details provided by the customer will be shared to apple for review. " & vbLf & "* The equipment is accepted subject to repair terms and conditions mentioned our website or printed overleaf." & vbLf & "* The Service Provider will not be responsible for any data loss." & vbLf & "* Subject to Engineer’s Inspection.")
            'It's only within a few days that we can talk  about guarantees and refunds. " & vbLf)
            doc.Add(SingleLine)
            doc.Close()

        Catch ex As Exception
            'errFlg = 1
        Finally
            If fileStream IsNot Nothing Then
                fileStream.Close()
            End If
        End Try

        Call FileDownload(fname, "application/pdf")
    End Sub

    Function NumberToText(ByVal n As Integer) As String

        Try
            Select Case n
                Case 0
                    Return ""

                Case 1 To 19
                    Dim arr() As String = {"One", "Two", "Three", "Four", "Five", "Six", "Seven",
                      "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
                        "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                    Return arr(n - 1) & " "

                Case 20 To 99
                    Dim arr() As String = {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
                    Return arr(n \ 10 - 2) & " " & NumberToText(n Mod 10)

                Case 100 To 199
                    Return "One Hundred " & NumberToText(n Mod 100)

                Case 200 To 999
                    Return NumberToText(n \ 100) & "Hundreds " & NumberToText(n Mod 100)

                Case 1000 To 1999
                    Return "One Thousand " & NumberToText(n Mod 1000)

                Case 2000 To 999999
                    Return NumberToText(n \ 1000) & "Thousands " & NumberToText(n Mod 1000)

                Case 1000000 To 1999999
                    Return "One Million " & NumberToText(n Mod 1000000)

                Case 1000000 To 999999999
                    Return NumberToText(n \ 1000000) & "Millions " & NumberToText(n Mod 1000000)

                Case 1000000000 To 1999999999
                    Return "One Billion " & NumberToText(n Mod 1000000000)

                Case Else
                    Return NumberToText(n \ 1000000000) & "Billion " _
                      & NumberToText(n Mod 1000000000)
            End Select
        Catch ex As Exception

            Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
            Log4NetControl.ComErrorLogWrite("AppCustInfoPage.NumberToText: Line8688: Para" & n & ">> " & ex.ToString())
            Return ""
        End Try


    End Function


    Function readsingle(ByVal m As Byte) As String

        Dim st As String = ""
        Select Case m
            Case 1 : st = "One" : Case 2 : st = "Two"
            Case 3 : st = "Three" : Case 4 : st = "Four"
            Case 5 : st = "Five" : Case 6 : st = "Six"
            Case 7 : st = "Seven" : Case 8 : st = "Eight"
            Case 9 : st = "Nine" : Case 10 : st = "Ten"
            Case 11 : st = "Eleven" : Case 12 : st = "Twelve"
            Case 13 : st = "Thirteen" : Case 14 : st = "Fourteen"
            Case 15 : st = "Fifteen" : Case 16 : st = "Sixteen"
            Case 17 : st = "Seventeen" : Case 18 : st = "Eighteen"
            Case 19 : st = "Nineteen" : Case 20 : st = "Twenty"
        End Select
        readsingle = st
    End Function

    Function readtenths(ByVal m As Byte) As String
        Dim n As Double
        n = m \ 10
        Dim st As String = ""
        Select Case n
            Case 2 : st = "Twenty " : Case 3 : st = "Thirty "
            Case 4 : st = "Forty " : Case 5 : st = "Fifty "
            Case 6 : st = "Sixty " : Case 7 : st = "Seventy "
            Case 8 : st = "Eighty " : Case 9 : st = "Ninety "
        End Select
        readtenths = st
    End Function
    Function readcombined(ByVal m As Byte) As String
        Dim st As String = ""
        Dim n As Double
        If m < 21 Then
            st = readsingle(m)
        ElseIf m < 100 Then
            st = readtenths(m)
            n = m Mod (10)
            st = st & readsingle((n))
        End If
        readcombined = st
    End Function
    Function num2str(ByVal m As Double) As String
        'If m > 99999999999.0# Then Exit Function
        Dim n As Double
        n = Fix(m / 1000000000)
        Dim st As String = ""
        If m = 0 Or m < 0 Then
            st = " Z E R O"
            num2str = st
            Exit Function
        End If
        If n > 0 Then
            st = st & readcombined((n)) & " Arab "
        End If
        m = m - n * 1000000000
        n = m \ 10000000
        If n > 0 Then
            st = st & readcombined((n)) & " Crore "
        End If
        n = m Mod (10000000)
        n = n \ 100000
        If n > 0 Then
            st = st & readcombined((n)) & " lac "
        End If
        n = m Mod (100000)
        n = n \ 1000
        If n > 0 Then
            st = st & readcombined((n)) & " Thousand "
        End If
        n = m Mod (1000)
        n = n \ 100
        If n > 0 Then
            st = st & readsingle((n)) & " Hundred "
        End If
        n = m Mod (100)
        st = st & " " & readcombined((n))
        num2str = st
    End Function

    Private Function RoundValueAndAdd(value As Double) As Double
        Const tolerance As Double = 0.00000000000008
        'Console.WriteLine("{0,5:N1} {0,20:R}  {1,12} {2,15}",
        '                value,
        '                RoundApproximate(value, 0, tolerance, MidpointRounding.ToEven),
        '                RoundApproximate(value, 0, tolerance, MidpointRounding.AwayFromZero))
        Return value + 0.1
    End Function

    Private Function RoundApproximate(dbl As Double, digits As Integer, margin As Double,
                                     mode As MidpointRounding) As Double
        Dim fraction As Double = dbl * Math.Pow(10, digits)
        Dim value As Double = Math.Truncate(fraction)
        fraction = fraction - value
        If fraction = 0 Then Return dbl

        Dim tolerance As Double = margin * dbl
        ' Determine whether this is a midpoint value.
        If (fraction >= 0.5 - tolerance) And (fraction <= 0.5 + tolerance) Then
            If mode = MidpointRounding.AwayFromZero Then
                Return (value + 1) / Math.Pow(10, digits)
            Else
                If value Mod 2 <> 0 Then
                    Return (value + 1) / Math.Pow(10, digits)
                Else
                    Return value / Math.Pow(10, digits)
                End If
            End If
        End If
        ' Any remaining fractional value greater than .5 is not a midpoint value.
        If fraction > 0.5 Then
            Return (value + 1) / Math.Pow(10, digits)
        Else
            Return value / Math.Pow(10, digits)
        End If
    End Function



End Class