
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


Public Class Apple_Customer_Information_temp
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
            PoNo = Request.QueryString("PoNo")
            GNo = Request.QueryString("GNo")

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
                Else

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PO_NO")) Then
                        txtPoNo.Text = dtAppleQmv.Rows(0)("PO_NO")
                        txtPoNo.Enabled = False
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

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_1")) Then
                        txtDiscount1.Text = dtAppleQmv.Rows(0)("PART_DISCOUNT_1")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_2")) Then
                        txtDiscount2.Text = dtAppleQmv.Rows(0)("PART_DISCOUNT_2")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_3")) Then
                        txtDiscount3.Text = dtAppleQmv.Rows(0)("PART_DISCOUNT_3")
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_4")) Then
                        txtDiscount4.Text = dtAppleQmv.Rows(0)("PART_DISCOUNT_4")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_AMOUNT")) Then
                        drpLabourAmount.SelectedItem.Value = dtAppleQmv.Rows(0)("LABOR_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_AMOUNT")) Then
                        txtLabourAmount.Text = dtAppleQmv.Rows(0)("LABOR_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_DETAIL")) Then
                        txtLabourDetail.Text = dtAppleQmv.Rows(0)("LABOR_DETAIL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_COST")) Then
                        txtLabourCost.Text = dtAppleQmv.Rows(0)("LABOR_COST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_DISCOUNT")) Then
                        txtLabourDiscount.Text = dtAppleQmv.Rows(0)("LABOR_DISCOUNT")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_SALES")) Then
                        txtLabourSales.Text = dtAppleQmv.Rows(0)("LABOR_SALES")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_SGST")) Then
                        txtLabourSGST.Text = dtAppleQmv.Rows(0)("LABOR_SGST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_CGST")) Then
                        txtLabourCGST.Text = dtAppleQmv.Rows(0)("LABOR_CGST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_IGST")) Then
                        txtLabourIGST.Text = dtAppleQmv.Rows(0)("LABOR_IGST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("LABOR_TOTAL")) Then
                        txtLabourTotal.Text = dtAppleQmv.Rows(0)("LABOR_TOTAL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_1")) Then
                        txtCost1.Text = dtAppleQmv.Rows(0)("PART_COST_1")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_2")) Then
                        txtCost2.Text = dtAppleQmv.Rows(0)("PART_COST_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_3")) Then
                        txtCost3.Text = dtAppleQmv.Rows(0)("PART_COST_3")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_4")) Then
                        txtCost4.Text = dtAppleQmv.Rows(0)("PART_COST_4")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_SALES_1")) Then
                        txtSalesPrice1.Text = dtAppleQmv.Rows(0)("PART_COST_SALES_1")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_SALES_2")) Then
                        txtSalesPrice2.Text = dtAppleQmv.Rows(0)("PART_COST_SALES_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_SALES_3")) Then
                        txtSalesPrice3.Text = dtAppleQmv.Rows(0)("PART_COST_SALES_3")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_SALES_4")) Then
                        txtSalesPrice4.Text = dtAppleQmv.Rows(0)("PART_COST_SALES_4")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_1")) Then
                        txtSGST1.Text = dtAppleQmv.Rows(0)("PART_SGST_1")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_2")) Then
                        txtSGST2.Text = dtAppleQmv.Rows(0)("PART_SGST_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_3")) Then
                        txtSGST3.Text = dtAppleQmv.Rows(0)("PART_SGST_3")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_4")) Then
                        txtSGST4.Text = dtAppleQmv.Rows(0)("PART_SGST_4")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_1")) Then
                        txtCGST1.Text = dtAppleQmv.Rows(0)("PART_CGST_1")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_2")) Then
                        txtCGST2.Text = dtAppleQmv.Rows(0)("PART_CGST_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_3")) Then
                        txtCGST3.Text = dtAppleQmv.Rows(0)("PART_CGST_3")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_4")) Then
                        txtCGST4.Text = dtAppleQmv.Rows(0)("PART_CGST_4")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_1")) Then
                        txtIGST1.Text = dtAppleQmv.Rows(0)("PART_IGST_1")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_2")) Then
                        txtIGST2.Text = dtAppleQmv.Rows(0)("PART_IGST_2")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_3")) Then
                        txtIGST3.Text = dtAppleQmv.Rows(0)("PART_IGST_3")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_4")) Then
                        txtIGST4.Text = dtAppleQmv.Rows(0)("PART_IGST_4")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL_1")) Then
                        txtTotal1.Text = dtAppleQmv.Rows(0)("PART_TOTAL_1")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL_2")) Then
                        txtTotal2.Text = dtAppleQmv.Rows(0)("PART_TOTAL_2")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL_3")) Then
                        txtTotal3.Text = dtAppleQmv.Rows(0)("PART_TOTAL_3")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL_4")) Then
                        txtTotal4.Text = dtAppleQmv.Rows(0)("PART_TOTAL_4")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_QTY_AMOUNT")) Then
                        txtPartQtyAmount.Text = dtAppleQmv.Rows(0)("PART_QTY_AMOUNT")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_COST_AMOUNT")) Then
                        txtPartCostAmount.Text = dtAppleQmv.Rows(0)("PART_COST_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_DISCOUNT_AMOUNT")) Then
                        txtPartDiscountAmount.Text = dtAppleQmv.Rows(0)("PART_DISCOUNT_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SALES_AMOUNT")) Then
                        txtPartSalesAmount.Text = dtAppleQmv.Rows(0)("PART_SALES_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_SGST_AMOUNT")) Then
                        txtPartSGSTAmount.Text = dtAppleQmv.Rows(0)("PART_SGST_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_CGST_AMOUNT")) Then
                        txtPartCGSTAmount.Text = dtAppleQmv.Rows(0)("PART_CGST_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_IGST_AMOUNT")) Then
                        txtPartIGSTAmount.Text = dtAppleQmv.Rows(0)("PART_IGST_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PART_TOTAL")) Then
                        txtPartTotal.Text = dtAppleQmv.Rows(0)("PART_TOTAL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_QTY_AMOUNT")) Then
                        txtOtherQtyAmount.Text = dtAppleQmv.Rows(0)("OTHER_QTY_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_DETAIL")) Then
                        txtOtherDetail.Text = dtAppleQmv.Rows(0)("OTHER_DETAIL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_COST")) Then
                        txtOtherCost.Text = dtAppleQmv.Rows(0)("OTHER_COST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_DISCOUNT")) Then
                        txtOtherDiscount.Text = dtAppleQmv.Rows(0)("OTHER_DISCOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_SALES")) Then
                        txtOtherSales.Text = dtAppleQmv.Rows(0)("OTHER_SALES")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_SGST")) Then
                        txtOtherSGST.Text = dtAppleQmv.Rows(0)("OTHER_SGST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_CGST")) Then
                        txtOtherCGST.Text = dtAppleQmv.Rows(0)("OTHER_CGST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_IGST")) Then
                        txtOtherIGST.Text = dtAppleQmv.Rows(0)("OTHER_IGST")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("OTHER_TOTAL")) Then
                        txtOtherTotal.Text = dtAppleQmv.Rows(0)("OTHER_TOTAL")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_QTY")) Then
                        txtTotalQty.Text = dtAppleQmv.Rows(0)("TOTAL_QTY")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_COST_AMOUNT")) Then
                        txtTotalCostAmount.Text = dtAppleQmv.Rows(0)("TOTAL_COST_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_DISCOUNT_AMOUNT")) Then
                        txtDiscountAmount.Text = dtAppleQmv.Rows(0)("TOTAL_DISCOUNT_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_SALES_AMOUNT")) Then
                        txtTotalSalesAmount.Text = dtAppleQmv.Rows(0)("TOTAL_SALES_AMOUNT")
                    End If


                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_SGST_AMOUNT")) Then
                        txtTotalSGSTAmount.Text = dtAppleQmv.Rows(0)("TOTAL_SGST_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_CGST_AMOUNT")) Then
                        txtTotalCGSTAmount.Text = dtAppleQmv.Rows(0)("TOTAL_CGST_AMOUNT")
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_IGST_AMOUNT")) Then
                        txtTotalIGSTAmount.Text = dtAppleQmv.Rows(0)("TOTAL_IGST_AMOUNT")
                    End If
                    Dim TotalAmount As Decimal = 0.00
                    If Not IsDBNull(dtAppleQmv.Rows(0)("TOTAL_AMOUNT")) Then
                        TotalAmount = dtAppleQmv.Rows(0)("TOTAL_AMOUNT")
                        txtTotalAmount.Text = TotalAmount
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

                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTIONS_1")) Then
                        PRICE_OPTIONS = dtAppleQmv.Rows(0)("PRICE_OPTIONS_1")
                        chkst1.Checked = PRICE_OPTIONS
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTIONS_2")) Then
                        PRICE_OPTIONS = dtAppleQmv.Rows(0)("PRICE_OPTIONS_2")
                        chkst2.Checked = PRICE_OPTIONS
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTIONS_3")) Then
                        PRICE_OPTIONS = dtAppleQmv.Rows(0)("PRICE_OPTIONS_3")
                        chkst3.Checked = PRICE_OPTIONS
                    End If
                    If Not IsDBNull(dtAppleQmv.Rows(0)("PRICE_OPTIONS_4")) Then
                        PRICE_OPTIONS = dtAppleQmv.Rows(0)("PRICE_OPTIONS_4")
                        chkst4.Checked = PRICE_OPTIONS
                    End If
                    Dim ADVANCE_PAYMENT As Decimal = 0.00
                    If Not IsDBNull(dtAppleQmv.Rows(0)("ADVANCE_PAYMENT")) Then
                        ADVANCE_PAYMENT = dtAppleQmv.Rows(0)("ADVANCE_PAYMENT")
                        txtAdvance.Text = ADVANCE_PAYMENT
                        txtBalance.Text = TotalAmount - ADVANCE_PAYMENT
                    End If

                    If Not IsDBNull(dtAppleQmv.Rows(0)("DELIVERY_DATE")) Then
                        txtDeliveryDate.Text = dtAppleQmv.Rows(0)("DELIVERY_DATE")
                        DisableAction()
                        Btninvoice.Enabled = True
                        Btndiagonis.Enabled = True
                    Else
                        If drpCompStatus.SelectedItem.Value = "1" Then ' Complete
                            DisableAction()
                            txtDeliveryDate.Enabled = True
                            btnDelivered.Enabled = True
                            drpDenomination.Enabled = True
                        ElseIf drpCompStatus.SelectedItem.Value = "2" Then 'Reception only
                            DisableAction()
                        End If
                    End If



                End If
                servicedrop()
            End If
        End If




    End Sub

    Sub DisableAction()
        txtPoNo.Enabled = False
        txtGNo.Enabled = False
        drpServiceType.Enabled = False
        txtInvoiceNote.Enabled = False
        txtGsxNote.Enabled = False
        txtCustomerName.Enabled = False
        txtAddressLine1.Enabled = False
        txtAddressLine2.Enabled = False
        txtCity.Enabled = False
        txtState.Enabled = False
        txtZip.Enabled = False
        txtEmail.Enabled = False
        txtTelephone.Enabled = False
        txtMobile.Enabled = False
        txtGstin.Enabled = False
        txtProduct.Enabled = False
        txtSerialNo.Enabled = False
        txtImei1.Enabled = False
        txtImei2.Enabled = False
        txtDateOfPurchase.Enabled = False
        txtCompTia.Enabled = False
        txtCompTiaModifier.Enabled = False
        btnCalculation.Enabled = False
        drpLabourAmount.Enabled = False
        txtLabourAmount.Enabled = False
        txtLabourAmountTemp.Enabled = False
        txtLabourDetail.Enabled = False
        txtLabourHsnSacCode.Enabled = False
        txtLabourCost.Enabled = False
        txtLabourDiscount.Enabled = False
        txtLabourSales.Enabled = False
        txtLabourSGST.Enabled = False
        txtLabourCGST.Enabled = False
        txtLabourIGST.Enabled = False
        txtLabourTotal.Enabled = False
        txtPartNo1.Enabled = False
        txtQty1.Enabled = False
        chkst1.Enabled = False
        txtPartDetails1.Enabled = False
        txtHsnSac1.Enabled = False
        txtCost1.Enabled = False
        txtDiscount1.Enabled = False
        txtSalesPrice1.Enabled = False
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
        Btndiagonis.Enabled = False
        drpDenomination.Enabled = False
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
        txtGstin.Text = ""
        txtProduct.Text = ""
        txtSerialNo.Text = ""
        txtImei1.Text = ""
        txtImei2.Text = ""
        txtDateOfPurchase.Text = ""
        'drpServiceType.Text = ""
        txtCompTia.Text = ""
        txtCompTiaModifier.Text = ""
        'drpLabourAmount.Text = ""
        txtLabourAmount.Text = ""
        txtLabourDetail.Text = ""
        txtLabourHsnSacCode.Text = ""
        txtLabourCost.Text = ""
        txtLabourSales.Text = ""
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
        End Select

    End Sub
    Protected Sub btnEstimate_Click(sender As Object, e As EventArgs) Handles btnEstimate.Click
        '1st Check PO
        '1st Check PO
        txtPoNo.Text = Trim(txtPoNo.Text)
        If txtPoNo.Text = "" Then
            Call showMsg("PO No is not allowed empty", "")
            Exit Sub
        End If


        '2nd Check G No
        txtGNo.Text = Trim(txtGNo.Text)
        If txtGNo.Text = "" Then
            Call showMsg("G No is not allowed empty", "")
            Exit Sub
        End If


        txtCustomerName.Text = Trim(txtCustomerName.Text)
        If txtCustomerName.Text = "" Then
            Call showMsg("CustomerName is not allowed empty", "")
            Exit Sub
        End If


        Dim fileStream As FileStream
        Dim logoQuickGarage As String = "C:\money\gssi_logo.jpg"

        Dim saveCsvPass As String = "C:\money\CSV\"
        Dim savePDFPass As String = "C:\money\PDF\"

        Dim fnt4 As New Font(BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, True), 16, iTextSharp.text.Font.UNDERLINE)

        Dim fnt5 As New Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False))
        Dim bf As BaseFont = BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, False)

        Dim Font1 As Font = New Font(bf, 14, Font.BOLD)
        Dim Font2 As Font = New Font(bf, 11, Font.NORMAL)
        Dim Font3 As Font = New Font(bf, 9, Font.NORMAL)
        Dim fname = txtPoNo.Text & "_" & System.DateTime.Now.Millisecond.ToString() & ".pdf"

        Dim filename As String = savePDFPass & fname


        Try
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
            psam.Add(".")

            psam.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(psam)

            Dim psam1 As New Paragraph()
            psam1.Add(".")

            psam1.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(psam1)

            image1.ScaleAbsolute(80.0F, 50.0F)
            Dim p As New Paragraph()
            p.Add(New Chunk(image1, 0, 0))

            p.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(p)

            Dim table As PdfPTable = New PdfPTable(6)
            table.WidthPercentage = 100

            Dim table41 As PdfPTable = New PdfPTable(2)
            table41.WidthPercentage = 100
            Dim header41 As PdfPCell = New PdfPCell()
            header41.Colspan = 2
            table.AddCell(header41) 'No pf Row
            cell = New PdfPCell(New Paragraph("GSS Quick Qarage Pvt Ltd", Font2))
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

            cell = New PdfPCell(New Paragraph("Paragon Plaza,Phoenix Market City,", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Trim(txtGNo.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("L B S Marg,Kurla west,Munbai 400070", Font2))
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
            cell = New PdfPCell(New Paragraph("Telephone: 123-456-7890", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("2021/03/21"))
            cell = New PdfPCell(New Paragraph(Now.Date, Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)
            cell = New PdfPCell(New Paragraph("E-mail: quickgarage@quickgarage.co.in", Font2))
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
            cell = New PdfPCell(New Paragraph("GSTIN: 27AAGCG5356G1ZH  CIN: U74999TN2016FTC112554", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)
            'table41.AddCell("GSS quick garage pvt.LTD")
            'table41.AddCell("1234567891023450")
            'table41.AddCell("address:Paragon Plaza,Phoenix Market City, ")
            'table41.AddCell("GA1234567897890")
            'table41.AddCell("L B S Marg,Kurla west,Munbai 400070 ")
            'table41.AddCell("Create Date")
            'table41.AddCell("telephone:123-456-7890")
            'table41.AddCell("2021/03/21")
            'table41.AddCell("e-mail:quickgarage@quickgarage.co.in")
            'table41.AddCell("")
            'table41.AddCell("GSTIN 123456789")
            'table41.AddCell("")
            doc.Add(table41)

            'Dim p3 As New Paragraph()
            'p3.Alignment = Element.ALIGN_LEFT
            'p3.Add("GSS quick garage pvt.LTD ")
            'doc.Add(p3)

            'Dim p4 As New Paragraph()
            'p4.Alignment = Element.ALIGN_LEFT
            'p4.Add("address:Paragon Plaza,Phoenix Market City, ")
            'doc.Add(p4)

            'Dim p5 As New Paragraph()
            'p5.Alignment = Element.ALIGN_LEFT
            'p5.Add("L B S Marg,Kurla west,Munbai 400070")
            'doc.Add(p5)

            'Dim p6 As New Paragraph()
            'p6.Alignment = Element.ALIGN_LEFT
            'p6.Add("telephone:123-456-7890")
            'doc.Add(p6)


            'Dim P7 As New Paragraph()
            'P7.Alignment = Element.ALIGN_LEFT
            'P7.Add("e-mail:quickgarage@quickgarage.co.in")
            'doc.Add(P7)

            'Dim P8 As New Paragraph()
            'P8.Alignment = Element.ALIGN_LEFT
            'P8.Add("GSTIN")
            'doc.Add(P8)




            Dim P9 As New Paragraph("", Font1)

            P9.Alignment = Element.ALIGN_CENTER
            P9.Add("Service Estimate")
            P9.Font = FontFactory.GetFont("Segoe UI", 18.0, BaseColor.ORANGE)
            doc.Add(P9)


            Dim P10 As New Paragraph()
            P10.Alignment = Element.ALIGN_LEFT
            P10.Add("Customer Information")

            doc.Add(P10)

            'Dim P100 As New Paragraph()
            'P100.Alignment = Element.ALIGN_LEFT
            'P100.Add("" & vbLf)
            'P100.Add("")
            'doc.Add(P100)

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
            cell = New PdfPCell(New Paragraph("Receipt Date", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'Doubt
            'cell = New PdfPCell(New Paragraph(txtEstimatedDate.Text))
            cell = New PdfPCell(New Paragraph((Now.Date), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)



            'header = New PdfPCell()

            'table.AddCell(header)
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

            'header = New PdfPCell()

            'table.AddCell(header)
            cell = New PdfPCell(New Paragraph(" "))
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




            cell = New PdfPCell(New Paragraph("City", Font2))
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
            cell = New PdfPCell(New Paragraph("Date of Purchase ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("2020/12/10 "))
            cell = New PdfPCell(New Paragraph((Now.Date), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)




            'cell = New PdfPCell(New Paragraph("State "))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph((txtState.Text), Font2))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)

            'cell = New PdfPCell(New Paragraph("Serial No "))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(txtSerialNo.Text))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table.AddCell(cell)



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
            cell = New PdfPCell(New Paragraph("Serial No"))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'Dim fntBa2 As New Font(BaseFont.CreateFont("c:\money\CODE39.ttf", BaseFont.IDENTITY_H, True), 12) 'バ
            ' cell = New PdfPCell(New Paragraph("*" & Right(otherData.po_no, Len(otherData.po_no) - 2) & "*", fntBa2))
            'cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", fntBa2))
            cell = New PdfPCell(New Paragraph(txtSerialNo.Text))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)


            cell = New PdfPCell(New Paragraph(" ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((" "), Font2))
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
            Dim fntBa2 As New Font(BaseFont.CreateFont("c:\money\CODE39.ttf", BaseFont.IDENTITY_H, True), 12) 'バ
            ' cell = New PdfPCell(New Paragraph("*" & Right(otherData.po_no, Len(otherData.po_no) - 2) & "*", fntBa2))
            If Len(txtSerialNo.Text) > 2 Then
                cell = New PdfPCell(New Paragraph("*" & Right(txtSerialNo.Text, Len(txtSerialNo.Text) - 2) & "*", fntBa2))
            Else
                cell = New PdfPCell(New Paragraph(" "))
            End If

            'cell = New PdfPCell(New Paragraph(txtSerialNo.Text))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)







            ''''''''cell = New PdfPCell(New Paragraph("GSTIN/Unique ID ", Font2))
            ''''''''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''table.AddCell(cell)
            ''''''''cell = New PdfPCell(New Paragraph((txtGstin.Text), Font2))
            ''''''''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''table.AddCell(cell)
            ''''''''cell = New PdfPCell(New Paragraph(" "))
            ''''''''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''table.AddCell(cell)
            ''''''''cell = New PdfPCell(New Paragraph(" "))
            ''''''''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''table.AddCell(cell)
            ''''''''cell = New PdfPCell(New Paragraph(" "))
            ''''''''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''table.AddCell(cell)
            ''''''''cell = New PdfPCell(New Paragraph(" "))
            ''''''''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''''''''table.AddCell(cell)





            doc.Add(table)


            'Dim P11 As New Paragraph()
            'P11.Alignment = Element.ALIGN_LEFT
            'P11.Add("Symptoms reported by the customer" & vbLf)


            'doc.Add(P11)

            Dim table51 As PdfPTable = New PdfPTable(1)
            table51.WidthPercentage = 100
            Dim header51 As PdfPCell = New PdfPCell()
            header51.Colspan = 1
            table.AddCell(header51) 'No pf Row

            cell = New PdfPCell(New Paragraph("Symptoms reported by the customer"))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table51.AddCell(cell)


            doc.Add(table51)


            Dim P12 As New Paragraph()
            P12.Alignment = Element.ALIGN_LEFT
            P12.Add("Details")
            doc.Add(P12)

            Dim P13 As New Paragraph()
            P13.Alignment = Element.ALIGN_LEFT
            P13.Add(" ")
            doc.Add(P13)

            Dim tableDetails As PdfPTable = New PdfPTable(1)
            tableDetails.WidthPercentage = 100
            Dim tableDetailsheader As PdfPCell = New PdfPCell()
            tableDetailsheader.Colspan = 1
            tableDetails.AddCell(tableDetailsheader) 'No pf Row
            cell = New PdfPCell(New Paragraph(Trim(txtInvoiceNote.Text), Font2))
            tableDetails.AddCell(cell)
            doc.Add(tableDetails)

            'Dim P14 As New Paragraph()
            'P14.Alignment = Element.ALIGN_LEFT
            'P14.Add("The customer's declaration is summarized in these five lines. Describe the declaration briefly, including both the reception table and verbal.")
            'doc.Add(P14)

            ''Dim table53 As PdfPTable = New PdfPTable(4)
            ''table53.WidthPercentage = 100
            ''Dim header53 As PdfPCell = New PdfPCell()
            ''header53.Colspan = 4
            ''table.AddCell(header53) 'No pf Row

            ''cell = New PdfPCell(New Paragraph("The customer's declaration is reception table and verbal. ", Font2))
            '''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            '''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            '''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''table53.AddCell(cell)
            ''cell = New PdfPCell(New Paragraph("summarized in these five lines. ", Font2))
            ''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''table53.AddCell(cell)
            ''cell = New PdfPCell(New Paragraph("Describe the declaration", Font2))
            ''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''table53.AddCell(cell)
            ''cell = New PdfPCell(New Paragraph("briefly, including both the ", Font2))
            '''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            '''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''table53.AddCell(cell)
            ''doc.Add(table53)

            P13 = New Paragraph()
            P13.Alignment = Element.ALIGN_LEFT
            P13.Add(" ")
            doc.Add(P13)

            Dim P15 As New Paragraph()
            P15.Alignment = Element.ALIGN_LEFT
            P15.Add("Parts and service charges used for repairs " & vbLf)
            doc.Add(P15)

            P13 = New Paragraph()
            P13.Alignment = Element.ALIGN_LEFT
            P13.Add(" ")
            doc.Add(P13)

            Dim table2 As PdfPTable = New PdfPTable(8)
            table2.WidthPercentage = 100
            Dim header2 As PdfPCell = New PdfPCell()
            header2.Colspan = 9
            table.AddCell(header2) 'No pf Row

            cell = New PdfPCell(New Paragraph("Parts No.", Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Parts Detail", Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Unit Price", Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Total", Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("TaxableValue", Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("CGST 9%", Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("SGST 9%", Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Total", Font2))
            table2.AddCell(cell)


            'Labour
            cell = New PdfPCell(New Paragraph(Trim(txtLabourAmount.Text), Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Trim(txtLabourDetail.Text), Font3))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Trim(""), Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Trim(txtLabourSales.Text), Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Trim(txtLabourSales.Text), Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Trim(txtLabourCGST.Text), Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Trim(txtLabourSGST.Text), Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Trim(txtLabourTotal.Text), Font2))
            table2.AddCell(cell)




            cell = New PdfPCell(New Paragraph(txtPartNo1.Text, Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtPartDetails1.Text, Font3))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtCost1.Text, Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtSalesPrice1.Text, Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtSalesPrice1.Text, Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtCGST1.Text, Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtSGST1.Text, Font2))
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph(txtTotal1.Text, Font2))
            table2.AddCell(cell)


            cell = New PdfPCell(New Paragraph(txtPartNo2.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartDetails2.Text, Font3))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtCost2.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSalesPrice2.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSalesPrice2.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtCGST2.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSGST2.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotal2.Text, Font2))
            table2.AddCell(cell)


            'table2.AddCell(txtPartNo2.Text)
            'table2.AddCell(txtPartDetails2.Text)
            'table2.AddCell(txtCost2.Text)
            'table2.AddCell(txtSalesPrice2.Text)
            'table2.AddCell(txtSalesPrice2.Text)
            'table2.AddCell(txtCGST2.Text)
            'table2.AddCell(txtSGST2.Text)
            'table2.AddCell(txtTotal2.Text)

            cell = New PdfPCell(New Paragraph(txtPartNo3.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartDetails3.Text, Font3))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtCost3.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSalesPrice3.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSalesPrice3.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtCGST3.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSGST3.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotal3.Text, Font2))
            table2.AddCell(cell)
            'table2.AddCell(txtPartNo3.Text)
            'table2.AddCell(txtPartDetails3.Text)
            'table2.AddCell(txtCost3.Text)
            'table2.AddCell(txtSalesPrice3.Text)
            'table2.AddCell(txtSalesPrice3.Text)
            'table2.AddCell(txtCGST3.Text)
            'table2.AddCell(txtSGST3.Text)
            'table2.AddCell(txtTotal3.Text)
            cell = New PdfPCell(New Paragraph(txtPartNo4.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartDetails4.Text, Font3))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtCost4.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSalesPrice4.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSalesPrice4.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtCGST4.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtSGST4.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotal4.Text, Font2))
            table2.AddCell(cell)

            'table2.AddCell(txtPartNo4.Text)
            'table2.AddCell(txtPartDetails4.Text)
            'table2.AddCell(txtCost4.Text)
            'table2.AddCell(txtSalesPrice4.Text)
            'table2.AddCell(txtSalesPrice4.Text)
            'table2.AddCell(txtCGST4.Text)
            'table2.AddCell(txtSGST4.Text)
            'table2.AddCell(txtTotal4.Text)

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
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            doc.Add(table2)

            Dim table3 As PdfPTable = New PdfPTable(4)
            table3.WidthPercentage = 100
            Dim header3 As PdfPCell = New PdfPCell()
            header3.Colspan = 4
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
            cell = New PdfPCell(New Paragraph("Total Invoice", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table3.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotalAmount.Text))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table3.AddCell(cell)

            doc.Add(table3)

            Dim table4 As PdfPTable = New PdfPTable(4)
            table4.WidthPercentage = 100
            Dim header4 As PdfPCell = New PdfPCell()
            header4.Colspan = 4
            table.AddCell(header4) 'No pf Row
            cell = New PdfPCell(New Paragraph("Advance Received(In Word)", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table4.AddCell(cell)
            Dim strMoneyText As String = ""
            strMoneyText = NumberToText(txtAdvance.Text)

            cell = New PdfPCell(New Paragraph(strMoneyText))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table4.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Total Invoice(In Word)", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table4.AddCell(cell)

            'Dim strMoneyText As String = ""
            strMoneyText = NumberToText(txtTotalAmount.Text)

            cell = New PdfPCell(New Paragraph(strMoneyText))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table4.AddCell(cell)

            doc.Add(table4)



            'Dim P17 As New Paragraph()
            'P17.Alignment = Element.ALIGN_LEFT
            'P17.Add("Estimate deadline and terms of use")
            'doc.Add(P17)

            Dim table52 As PdfPTable = New PdfPTable(1)
            table52.WidthPercentage = 100
            Dim header52 As PdfPCell = New PdfPCell()
            header52.Colspan = 1
            table.AddCell(header52) 'No pf Row

            cell = New PdfPCell(New Paragraph("Estimate deadline and terms of use"))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table52.AddCell(cell)


            doc.Add(table52)


            Dim P18 As New Paragraph("", Font3)
            P18.Alignment = Element.ALIGN_LEFT
            P18.Add("Description of the deadline for quotation")
            doc.Add(P18)

            Dim P19 As New Paragraph("", Font3)
            P19.Alignment = Element.ALIGN_LEFT
            P19.Add("That this quote does not mean that all repairs are guaranteed")
            doc.Add(P19)

            Dim P20 As New Paragraph("", Font3)
            P20.Alignment = Element.ALIGN_LEFT
            P20.Add("Please note that different symptoms may be confirmed during the repair process and the repair details may change.")
            doc.Add(P20)

            Dim P21 As New Paragraph("", Font3)
            P21.Alignment = Element.ALIGN_LEFT
            P21.Add("Please note that the billing amount may change due to the above reasons.")
            doc.Add(P21)

            Dim P22 As New Paragraph("", Font3)
            P22.Alignment = Element.ALIGN_LEFT
            P22.Add("If the billing amount changes, you need to check with the customer again in advance.")
            doc.Add(P22)

            Dim P23 As New Paragraph("", Font3)
            P23.Alignment = Element.ALIGN_LEFT
            P23.Add("We may call you directly regarding the details of the repair.")
            doc.Add(P23)

            'Dim P24 As New Paragraph()
            'P24.Alignment = Element.ALIGN_RIGHT
            'P24.Add("We may call you directly regarding the details of the repair.")
            'doc.Add(P24)

            Dim P24 As New Paragraph()
            'P24.Alignment = Element.ALIGN_LEFT
            'P24.Add(" ")
            'doc.Add(P24)

            P24 = New Paragraph("", Font3)
            P24.Alignment = Element.ALIGN_RIGHT
            P24.Add("And so on, I'll add statements like above convention here")
            doc.Add(P24)

            P24 = New Paragraph("", Font2)
            P24.Alignment = Element.ALIGN_LEFT
            P24.Add(" ")
            doc.Add(P24)

            Dim table5 As PdfPTable = New PdfPTable(2)
            table5.WidthPercentage = 100
            Dim header5 As PdfPCell = New PdfPCell()
            header5.Colspan = 1
            table.AddCell(header5) 'No pf Row

            cell = New PdfPCell(New Paragraph("  Received by", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)
            cell = New PdfPCell(New Paragraph("                 Signature of Customer", Font2))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)

            doc.Add(table5)





            Dim P25 As New Paragraph()
            P25.Alignment = Element.ALIGN_LEFT
            P25.Add("For AppleAuthorizedSaerviceProvider GSS quickgarage")
            doc.Add(P25)

            'Dim P26 As New Paragraph()
            'P26.Alignment = Element.ALIGN_LEFT
            'P26.Add(" ")
            'doc.Add(P26)

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

            cell = New PdfPCell(New Paragraph("Authorized Signatory                                                                                                             E.&O.E.", Font2))
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
            _AppleQmvOrdModel.ESTIMATE_DATE = Now.Date
            _AppleQmvOrdModel.ESTIMATE_TIME = Now.ToShortTimeString


            Dim blStatus As Boolean = False

            blStatus = _AppleQmvOrdControl.UpdateEstimate(_AppleQmvOrdModel)

            If blStatus = False Then
                Call showMsg("Estimate Date updation Error", "")
                Exit Sub
            End If

        Catch ex As Exception
            'errFlg = 1
        Finally
            If fileStream IsNot Nothing Then
                fileStream.Close()
            End If
        End Try

        Call FileDownload(fname, "application/pdf")
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
        If Trim(txtDeliveryDate.Text) = "" Then
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
            Dim blStatus As Boolean = False
            blStatus = _AppleQmvOrdControl.UpdateComplete(_AppleQmvOrdModel)
            If blStatus = False Then
                Call showMsg("Delevered Status updation Error", "")
                Exit Sub
            End If
        Else
            Call showMsg("Delivery Date Is Empty", "")
            Exit Sub
        End If

    End Sub

    Protected Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click

        Select Case drpCompStatus.SelectedItem.Value
            Case "0" '--Select
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
        _AppleQmvOrdModel.GSX_CLOSE_DATE = txtGSXCloseDate.Text
        _AppleQmvOrdModel.COMP_STATUS = drpCompStatus.SelectedItem.Value


        Dim blStatus As Boolean = False

        blStatus = _AppleQmvOrdControl.UpdateComplete(_AppleQmvOrdModel)

        If blStatus = False Then
            Call showMsg("Complete updation Error", "")
            Exit Sub
        End If
        If drpCompStatus.SelectedItem.Value <> "0" Then
            DisableAction()
        End If


    End Sub

    Protected Sub btnCalculation_Click(sender As Object, e As EventArgs) Handles btnCalculation.Click

        If Trim(txtPoNo.Text) = "" Then
            Call showMsg("Po No is invalid ", "")
            Exit Sub
        End If

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



        Dim Qtys As Decimal = 0.00
        Dim Discounts As Decimal = 0.00
        Dim SalesPrices As Decimal = 0.00
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
        strLabourValue = txtLabourAmount.Text
        If Trim(txtLabourAmount.Text) = "" Then
            'if LabourCost not entered 
            ' If (txtLabourCost.Text = "") Then 'And (txtLabourSales.Text = "")
            Call showMsg("Labour Parts No is not entered", "")
            Exit Sub
            'End If

        Else

            'Validate Labour cost is decimal 
            'If Decimal.TryParse(txtLabourAmount.Text, LabourCost) Then
            'Else
            '    Call showMsg("Labour cost is invalid ", "")
            '    Exit Sub
            'End If

            'txtLabourCost.Text = LabourCost

            Dim _AppleLabourModel As AppleLabourModel = New AppleLabourModel()
            Dim _AppleLabourControl As AppleLabourControl = New AppleLabourControl()
            _AppleLabourModel.PART_NO = strLabourValue
            dtApple = _AppleLabourControl.SelectLabourPrice(_AppleLabourModel)
            If (dtApple Is Nothing) Or (dtApple.Rows.Count = 0) Then
                Call showMsg("Labour Price Not Defined ( " & txtLabourAmount.Text & ")", "")
                Exit Sub
            Else
                If Not IsDBNull(dtApple.Rows(0)("amount_150")) Then
                    txtLabourCost.Text = dtApple.Rows(0)("amount_150")
                End If
                'Validate Labour cost is decimal 
                If Decimal.TryParse(txtLabourCost.Text, LabourCost) Then
                Else
                    Call showMsg("Labour cost is invalid ", "")
                    Exit Sub
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
            txtLabourDiscount.Text = LabourDiscount
        End If




        LabourCost = LabourCost - LabourDiscount
        LabourSales = LabourCost
        LabourSgst = LabourSales / 100 * Sgst
        LabourIgst = LabourSales / 100 * Igst
        LabourCgst = LabourSales / 100 * Cgst
        LabourTotal = LabourSales + LabourSgst + LabourIgst + LabourCgst

        txtLabourCost.Text = LabourCost
        txtLabourSales.Text = LabourSales
        txtLabourSGST.Text = LabourSgst
        txtLabourCGST.Text = LabourCgst
        txtLabourIGST.Text = LabourIgst
        txtLabourTotal.Text = LabourTotal



        Dim _ApplePartsModel As ApplePartsModel = New ApplePartsModel()
        Dim _ApplePartsControl As ApplePartsControl = New ApplePartsControl()
        Dim dtApplePart As DataTable

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
            End If


            blPartEntered = True
            _ApplePartsModel.PARTS_NO = Trim(txtPartNo1.Text)

            If chkst1.Checked Then
                _ApplePartsModel.PRICE_OPTION = "Stock Price"
            Else
                _ApplePartsModel.PRICE_OPTION = "Exchange Price"
            End If

            dtApplePart = _ApplePartsControl.SelectPrice(_ApplePartsModel)
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
                End If
                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                    txtSalesPrice1.Text = dtApplePart.Rows(0)("SALES_PRICE")
                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                End If
                tmpSalesPrice = (Qty * PriceCost) - Discount

                txtSalesPrice1.Text = tmpSalesPrice

                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSalesPrice1.Text = tmpSalesPrice

                txtSGST1.Text = PartSgst
                txtCGST1.Text = PartCgst
                txtIGST1.Text = PartIgst
                txtTotal1.Text = PartTotal

                SalesPrices = tmpSalesPrice
                PartSgsts = PartSgst
                PartIgsts = PartIgst
                PartCgsts = PartCgst
                PartTotals = PartTotal

            End If
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
            End If

            blPartEntered = True
            _ApplePartsModel.PARTS_NO = Trim(txtPartNo2.Text)
            If chkst2.Checked Then
                _ApplePartsModel.PRICE_OPTION = "Stock Price"
            Else
                _ApplePartsModel.PRICE_OPTION = "Exchange Price"
            End If
            dtApplePart = _ApplePartsControl.SelectPrice(_ApplePartsModel)
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
                End If
                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                    txtSalesPrice2.Text = dtApplePart.Rows(0)("SALES_PRICE")
                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                End If
                tmpSalesPrice = (Qty * PriceCost) - Discount
                txtSalesPrice2.Text = tmpSalesPrice


                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST2.Text = PartSgst
                txtCGST2.Text = PartCgst
                txtIGST2.Text = PartIgst
                txtTotal2.Text = PartTotal

                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartCgst
                PartCgsts = PartCgsts + PartIgst
                PartTotals = PartTotals + PartTotal

            End If
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
            End If

            blPartEntered = True
            _ApplePartsModel.PARTS_NO = Trim(txtPartNo3.Text)
            If chkst3.Checked Then
                _ApplePartsModel.PRICE_OPTION = "Stock Price"
            Else
                _ApplePartsModel.PRICE_OPTION = "Exchange Price"
            End If
            dtApplePart = _ApplePartsControl.SelectPrice(_ApplePartsModel)
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
                End If
                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                    txtSalesPrice3.Text = dtApplePart.Rows(0)("SALES_PRICE")
                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                End If

                tmpSalesPrice = (Qty * PriceCost) - Discount
                txtSalesPrice3.Text = tmpSalesPrice
                txtDiscount3.Text = Discount

                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST3.Text = PartSgst
                txtCGST3.Text = PartCgst
                txtIGST3.Text = PartIgst
                txtTotal3.Text = PartTotal

                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartIgst
                PartCgsts = PartCgsts + PartCgst
                PartTotals = PartTotals + PartTotal

            End If
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
            End If

            blPartEntered = True
            _ApplePartsModel.PARTS_NO = Trim(txtPartNo4.Text)
            If chkst4.Checked Then
                _ApplePartsModel.PRICE_OPTION = "Stock Price"
            Else
                _ApplePartsModel.PRICE_OPTION = "Exchange Price"
            End If
            dtApplePart = _ApplePartsControl.SelectPrice(_ApplePartsModel)
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
                End If
                If Not IsDBNull(dtApplePart.Rows(0)("SALES_PRICE")) Then
                    txtSalesPrice4.Text = dtApplePart.Rows(0)("SALES_PRICE")
                    SalesPrice = dtApplePart.Rows(0)("SALES_PRICE")
                End If
                tmpSalesPrice = (Qty * PriceCost) - Discount
                txtSalesPrice4.Text = tmpSalesPrice



                PartSgst = tmpSalesPrice / 100 * Sgst
                PartIgst = tmpSalesPrice / 100 * Igst
                PartCgst = tmpSalesPrice / 100 * Cgst
                PartTotal = tmpSalesPrice + PartSgst + PartIgst + PartCgst
                txtSGST4.Text = PartSgst
                txtCGST4.Text = PartCgst
                txtIGST4.Text = PartIgst
                txtTotal4.Text = PartTotal


                SalesPrices = SalesPrices + tmpSalesPrice
                PartSgsts = PartSgsts + PartSgst
                PartIgsts = PartIgsts + PartIgst
                PartCgsts = PartCgsts + PartCgst
                PartTotals = PartTotals + PartTotal
            End If
        End If

        If blPartEntered = False Then
            Call showMsg("Please enter parts no  ", "")
            Exit Sub
        End If


        If blPriceCheckFailure = True Then
            Call showMsg("The price does not exist !!! <br>" & FailureText, "")
            Exit Sub
        End If


        'Assign Final Amount to Part
        txtPartQtyAmount.Text = Qtys
        txtPartDiscountAmount.Text = Discounts
        txtPartSalesAmount.Text = SalesPrices
        txtPartSGSTAmount.Text = PartSgsts
        txtPartCGSTAmount.Text = PartCgsts
        txtPartIGSTAmount.Text = PartIgst
        txtPartTotal.Text = PartTotals




        '3rd Other Amount
        Dim OtherQty As Decimal = 0.00
        Dim OtherDiscount As Decimal = 0.00
        Dim OtherCost As Decimal = 0.00
        Dim OtherSale As Decimal = 0.00
        Dim OtherSgst As Decimal = 0.00
        Dim OtherIgst As Decimal = 0.00
        Dim OtherCgst As Decimal = 0.00
        Dim OtherTotal As Decimal = 0.00

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


            OtherSale = (OtherQty * OtherCost) - OtherDiscount
            txtOtherSales.Text = OtherSale

            OtherSgst = OtherSale / 100 * Sgst
            OtherIgst = OtherSale / 100 * Igst
            OtherCgst = OtherSale / 100 * Cgst
            OtherTotal = OtherSale + OtherSgst + OtherIgst + OtherCgst

            txtOtherSGST.Text = OtherSgst
            txtOtherCGST.Text = OtherCgst
            txtOtherIGST.Text = OtherIgst
            txtOtherTotal.Text = OtherTotal
        End If


        txtTotalQty.Text = Qtys + OtherQty
        'txtTotalCostAmount.text =""
        txtDiscountAmount.Text = LabourDiscount + Discounts + OtherDiscount
        txtTotalSalesAmount.Text = LabourSales + SalesPrices + OtherSale
        txtTotalSGSTAmount.Text = LabourSgst + PartSgsts + OtherSgst
        txtTotalCGSTAmount.Text = LabourCgst + PartCgsts + OtherCgst
        txtTotalIGSTAmount.Text = LabourIgst + PartIgsts + OtherIgst
        txtTotalAmount.Text = LabourTotal + PartTotals + OtherTotal

        Dim AdvanceAmount As Decimal = 0.00

        If Trim(txtAdvance.Text) <> "" Then
            'Validate Labour cost is decimal 
            If Decimal.TryParse(txtAdvance.Text, AdvanceAmount) Then
            Else
                Call showMsg("Advance Amount is invalid ", "")
                Exit Sub
            End If
        End If

        txtBalance.Text = (LabourTotal + PartTotals + OtherTotal) - AdvanceAmount

        UpdateInfo()
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

        '2nd Check G No
        txtGNo.Text = Trim(txtGNo.Text)
        If txtGNo.Text = "" Then
            Call showMsg("G No is not allowed empty", "")
            Exit Sub
        End If


        txtCustomerName.Text = Trim(txtCustomerName.Text)
        If txtCustomerName.Text = "" Then
            Call showMsg("CustomerName is not allowed empty", "")
            Exit Sub
        End If


        Dim fileStream As FileStream
        Dim logoQuickGarage As String = "C:\money\gssi_logo.jpg"

        Dim saveCsvPass As String = "C:\money\CSV\"
        Dim savePDFPass As String = "C:\money\PDF\"

        Dim fname = txtPoNo.Text & "_" & System.DateTime.Now.Millisecond.ToString() & ".pdf"
        Dim filename As String = savePDFPass & fname

        Try
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
            psam.Add(".")

            psam.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(psam)

            Dim psam1 As New Paragraph()
            psam1.Add(".")

            psam1.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(psam1)

            image1.ScaleAbsolute(80.0F, 50.0F)
            Dim p As New Paragraph()
            p.Add(New Chunk(image1, 0, 0))

            p.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(p)

            Dim table As PdfPTable = New PdfPTable(6)
            table.WidthPercentage = 100

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

            cell = New PdfPCell(New Paragraph("1234567891023450", Font2))
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

            cell = New PdfPCell(New Paragraph("GA1234567897890	", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("L B S Marg,Kurla west,Munbai 400070", Font2))
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
            cell = New PdfPCell(New Paragraph("telephone:123-456-7890", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("2021/03/21	", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)
            cell = New PdfPCell(New Paragraph("e-mail:quickgarage@quickgarage.co.in", Font2))
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
            cell = New PdfPCell(New Paragraph("GSTIN 123456789", Font2))
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
            'table41.AddCell("GSS quick garage pvt.LTD")
            'table41.AddCell("1234567891023450")
            'table41.AddCell("address:Paragon Plaza,Phoenix Market City, ")
            'table41.AddCell("GA1234567897890")
            'table41.AddCell("L B S Marg,Kurla west,Munbai 400070 ")
            'table41.AddCell("Create Date")
            'table41.AddCell("telephone:123-456-7890")
            'table41.AddCell("2021/03/21")
            'table41.AddCell("e-mail:quickgarage@quickgarage.co.in")
            'table41.AddCell("")
            'table41.AddCell("GSTIN 123456789")
            'table41.AddCell("")
            doc.Add(table41)

            'Dim p3 As New Paragraph()
            'p3.Alignment = Element.ALIGN_LEFT
            'p3.Add("GSS quick garage pvt.LTD ")
            'doc.Add(p3)

            'Dim p4 As New Paragraph()
            'p4.Alignment = Element.ALIGN_LEFT
            'p4.Add("address:Paragon Plaza,Phoenix Market City, ")
            'doc.Add(p4)

            'Dim p5 As New Paragraph()
            'p5.Alignment = Element.ALIGN_LEFT
            'p5.Add("L B S Marg,Kurla west,Munbai 400070")
            'doc.Add(p5)

            'Dim p6 As New Paragraph()
            'p6.Alignment = Element.ALIGN_LEFT
            'p6.Add("telephone:123-456-7890")
            'doc.Add(p6)


            'Dim P7 As New Paragraph()
            'P7.Alignment = Element.ALIGN_LEFT
            'P7.Add("e-mail:quickgarage@quickgarage.co.in")
            'doc.Add(P7)

            'Dim P8 As New Paragraph()
            'P8.Alignment = Element.ALIGN_LEFT
            'P8.Add("GSTIN")
            'doc.Add(P8)




            Dim P9 As New Paragraph("", Font1)
            P9.Alignment = Element.ALIGN_CENTER
            P9.Alignment = Font.BOLD
            P9.Add("Service Report")
            P9.Font = Font1
            P9.Font = FontFactory.GetFont("Segoe UI", 26.0, BaseColor.ORANGE)

            doc.Add(P9)


            Dim P10 As New Paragraph()
            P10.Alignment = Element.ALIGN_LEFT
            P10.Add("Customer Information")

            doc.Add(P10)

            'Dim P100 As New Paragraph()
            'P100.Alignment = Element.ALIGN_LEFT
            'P100.Add("" & vbLf)
            'P100.Add("")
            'doc.Add(P100)

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
            cell = New PdfPCell(New Paragraph("Receipt Date", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'Doubt
            cell = New PdfPCell(New Paragraph((Now.Date), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)



            'header = New PdfPCell()

            'table.AddCell(header)
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
            cell = New PdfPCell(New Paragraph(""))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)

            'header = New PdfPCell()

            'table.AddCell(header)
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




            cell = New PdfPCell(New Paragraph("City", Font2))
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
            cell = New PdfPCell(New Paragraph("Date of Purchase ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("2020/12/10 "))
            cell = New PdfPCell(New Paragraph(" "))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)




            cell = New PdfPCell(New Paragraph("State ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtState.Text), Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Postal Code ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtZip.Text), Font2))
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



            cell = New PdfPCell(New Paragraph("e-mail", Font2))
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


            'Dim P11 As New Paragraph()
            'P11.Alignment = Element.ALIGN_LEFT
            'P11.Add("Symptoms reported by the customer" & vbLf)


            'doc.Add(P11)

            Dim table51 As PdfPTable = New PdfPTable(1)
            table51.WidthPercentage = 100
            Dim header51 As PdfPCell = New PdfPCell()
            header51.Colspan = 1
            table.AddCell(header51) 'No pf Row

            cell = New PdfPCell(New Paragraph("Symptoms reported by the customer"))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table51.AddCell(cell)


            doc.Add(table51)


            Dim P12 As New Paragraph()
            P12.Alignment = Element.ALIGN_LEFT
            P12.Add("Details")
            doc.Add(P12)

            Dim P13 As New Paragraph()
            P13.Alignment = Element.ALIGN_LEFT
            P13.Add("")
            doc.Add(P13)



            'Dim P14 As New Paragraph()
            'P14.Alignment = Element.ALIGN_LEFT
            'P14.Add("The customer's declaration is summarized in these five lines. Describe the declaration briefly, including both the reception table and verbal.")
            'doc.Add(P14)

            Dim table53 As PdfPTable = New PdfPTable(4)
            table53.WidthPercentage = 100
            Dim header53 As PdfPCell = New PdfPCell()
            header53.Colspan = 4
            table.AddCell(header53) 'No pf Row

            cell = New PdfPCell(New Paragraph("The customer's declaration is reception table and verbal. ", Font2))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table53.AddCell(cell)
            cell = New PdfPCell(New Paragraph("summarized in these five lines. ", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table53.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Describe the declaration", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table53.AddCell(cell)
            cell = New PdfPCell(New Paragraph("briefly, including both the ", Font2))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table53.AddCell(cell)
            doc.Add(table53)

            Dim P15 As New Paragraph()
            P15.Alignment = Element.ALIGN_LEFT
            P15.Add("Parts and Details " & vbLf)

            doc.Add(P15)

            Dim table2 As PdfPTable = New PdfPTable(4)
            table2.WidthPercentage = 100
            Dim header2 As PdfPCell = New PdfPCell()
            header2.Colspan = 4
            table.AddCell(header2) 'No pf Row

            table2.AddCell("")
            table2.AddCell("Parts")
            table2.AddCell("Parts No")
            table2.AddCell("Qty")
            'table2.AddCell("TaxableValue")
            'table2.AddCell("CGST 9%")
            'table2.AddCell("SGST 9%")
            'table2.AddCell("Total")
            cell = New PdfPCell(New Paragraph("1", Font1))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartDetails1.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartNo1.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtQty1.Text, Font2))
            table2.AddCell(cell)

            'table2.AddCell(txtPartDetails1.Text)
            'table2.AddCell(txtPartNo1.Text)
            'table2.AddCell(txtQty1.Text)



            cell = New PdfPCell(New Paragraph("2", Font1))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartDetails2.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartNo2.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtQty2.Text, Font2))
            table2.AddCell(cell)
            'table2.AddCell(txtPartDetails2.Text)
            'table2.AddCell(txtPartNo2.Text)
            'table2.AddCell(txtQty2.Text)

            cell = New PdfPCell(New Paragraph("3", Font1))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartDetails3.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtPartNo3.Text, Font2))
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtQty3.Text, Font2))
            table2.AddCell(cell)
            'table2.AddCell(txtPartDetails3.Text)
            'table2.AddCell(txtPartNo3.Text)
            'table2.AddCell(txtQty3.Text)

            cell = New PdfPCell(New Paragraph("4", Font1))
            table2.AddCell(cell)
            table2.AddCell(txtPartDetails4.Text)
            table2.AddCell(txtPartNo4.Text)
            table2.AddCell(txtQty4.Text)



            doc.Add(table2)

            Dim table3 As PdfPTable = New PdfPTable(4)
            table3.WidthPercentage = 100
            Dim header3 As PdfPCell = New PdfPCell()
            header3.Colspan = 4
            table.AddCell(header3) 'No pf Row
            cell = New PdfPCell(New Paragraph("Advance Received", Font2))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table3.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table3.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Total Invoice, Font2"))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table3.AddCell(cell)





            'Dim P17 As New Paragraph()
            'P17.Alignment = Element.ALIGN_LEFT
            'P17.Add("Estimate deadline and terms of use")
            'doc.Add(P17)

            Dim table52 As PdfPTable = New PdfPTable(1)
            table52.WidthPercentage = 100
            Dim header52 As PdfPCell = New PdfPCell()
            header52.Colspan = 1
            table.AddCell(header52) 'No pf Row

            cell = New PdfPCell(New Paragraph("Report of repair details", Font2))
            ' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table52.AddCell(cell)


            doc.Add(table52)






            Dim P24 As New Paragraph()
            P24.Alignment = Element.ALIGN_RIGHT
            P24.Add("")
            doc.Add(P24)





            Dim table5 As PdfPTable = New PdfPTable(4)
            table5.WidthPercentage = 100
            Dim header5 As PdfPCell = New PdfPCell()
            header5.Colspan = 4
            table.AddCell(header5) 'No pf Row

            cell = New PdfPCell(New Paragraph("Description of new serial when replacing the main unit (repair product)", Font2))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Report that the declared symptom was confirmed and describe", Font2))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Report that the declared symptom was confirmed and describe ", Font2))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Described that successful operation was confirmed with apple's test tool after completion", Font2))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)

            doc.Add(table5)





            Dim P25 As New Paragraph()
            P25.Alignment = Element.ALIGN_LEFT
            P25.Add("")
            doc.Add(P25)

            Dim P26 As New Paragraph()
            P26.Alignment = Element.ALIGN_LEFT
            P26.Add(" ")
            doc.Add(P26)

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

            cell = New PdfPCell(New Paragraph("Authorized Signatory                                                                                                             E.&O.E."))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)
            doc.Add(table6)



            doc.Close()

            'Response.ClearContent()
            'Response.ClearHeaders()
            'Response.AddHeader("Content-Disposition", "inline;filename=" & filename)
            'Response.ContentType = "application/pdf"
            ''Response.WriteFile(filename)
            'Response.TransmitFile(filename)
            'Response.Flush()
            'Response.Clear()

            'Response.ContentType = "application/pdf"
            'Response.AddHeader("content-disposition", "attachment;filename=" & filename)
            'Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Response.Write(doc)
            'Response.End()



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
        UpdateInfo()
    End Sub

    Protected Sub save2_Click(sender As Object, e As EventArgs) Handles save2.Click
        UpdateInfo()
    End Sub


    Sub UpdateInfo()


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
        _AppleQmvOrdModel.MODEL_NAME = txtModel.Text
        _AppleQmvOrdModel.PRODUCT_NAME = txtProduct.Text
        _AppleQmvOrdModel.SERIAL_NO = txtSerialNo.Text
        _AppleQmvOrdModel.IMEI_1 = txtImei1.Text
        _AppleQmvOrdModel.IMEI_2 = txtImei2.Text
        _AppleQmvOrdModel.DATE_OF_PURCHASE = txtDateOfPurchase.Text
        _AppleQmvOrdModel.SERVICE_TYPE = drpServiceType.SelectedItem.Value
        _AppleQmvOrdModel.COMPTIA = txtCompTia.Text
        _AppleQmvOrdModel.COMPTIA_MODIFIER = txtCompTiaModifier.Text
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

        _AppleQmvOrdModel.PART_DISCOUNT_1 = txtDiscount1.Text
        _AppleQmvOrdModel.PART_DISCOUNT_2 = txtDiscount2.Text
        _AppleQmvOrdModel.PART_DISCOUNT_3 = txtDiscount3.Text
        _AppleQmvOrdModel.PART_DISCOUNT_4 = txtDiscount4.Text

        _AppleQmvOrdModel.PRICE_OPTIONS_1 = chkst1.Checked
        _AppleQmvOrdModel.PRICE_OPTIONS_2 = chkst1.Checked
        _AppleQmvOrdModel.PRICE_OPTIONS_3 = chkst1.Checked
        _AppleQmvOrdModel.PRICE_OPTIONS_4 = chkst1.Checked




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
        _AppleQmvOrdModel.ESTIMATE_DATE = txtEstimatedDate.Text
        _AppleQmvOrdModel.ESTIMATE_TIME = ""
        _AppleQmvOrdModel.GSX_CLOSE_DATE = txtGSXCloseDate.Text
        _AppleQmvOrdModel.USE_SERVICE_TYPE = ""
        _AppleQmvOrdModel.INVOICE_NOTE = txtInvoiceNote.Text
        _AppleQmvOrdModel.GSX_NOTE = txtGsxNote.Text
        ''''''''''' _AppleQmvOrdModel.HSN_SAC_CODE = ""
        _AppleQmvOrdModel.GSTIN = txtGstin.Text




        _AppleQmvOrdModel.IP_ADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress

        Dim blStatus As Boolean = False

        blStatus = _AppleQmvOrdControl.AddQmvOrd(_AppleQmvOrdModel)

        If blStatus Then
            'ClearTextbox()
            'drpServiceType.SelectedIndex = drpServiceType.Items.IndexOf(drpServiceType.Items.FindByValue(0))
            'ChangeColor(0)

            txtPoNo.Enabled = False

            Call showMsg("Successfully Saved...", "")
            Exit Sub
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
        txtGNo.Text = Trim(txtGNo.Text)
        If txtGNo.Text = "" Then
            Call showMsg("G No is not allowed empty", "")
            Exit Sub
        End If


        txtCustomerName.Text = Trim(txtCustomerName.Text)
        If txtCustomerName.Text = "" Then
            Call showMsg("CustomerName is not allowed empty", "")
            Exit Sub
        End If


        Dim fileStream As FileStream
        Dim logoQuickGarage As String = "C:\money\gssi_logo.jpg"

        Dim saveCsvPass As String = "C:\money\CSV\"
        Dim savePDFPass As String = "C:\money\PDF\"

        Dim fname = txtPoNo.Text & "_" & System.DateTime.Now.Millisecond.ToString() & ".pdf"

        Dim filename As String = savePDFPass & fname

        Try
            Dim doc As Document
            Dim pdfWriter As PdfWriter
            Dim image1 As Image = Image.GetInstance(logoQuickGarage) '画像
            image1.ScalePercent(7) '大きさ
            fileStream = New FileStream(filename, FileMode.Create)

            doc = New Document(PageSize.A4, 5, 5, 5, 5)
            Dim bf As BaseFont = BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.CP1252, False)
            Dim Font3 As Font = New Font(bf, 10, Font.NORMAL)

            pdfWriter = PdfWriter.GetInstance(doc, fileStream)
            doc.Open()

            Dim pcb As PdfContentByte = pdfWriter.DirectContent

            Dim cell As PdfPCell

            Dim psam As New Paragraph()
            psam.Add(".")

            psam.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(psam)

            Dim psam1 As New Paragraph()
            psam1.Add(".")

            psam1.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(psam1)

            image1.ScaleAbsolute(80.0F, 50.0F)
            Dim p As New Paragraph()
            p.Add(New Chunk(image1, 0, 0))

            p.Alignment = Element.ALIGN_LEFT
            'p.Add(" ")
            doc.Add(p)

            Dim table As PdfPTable = New PdfPTable(5)
            table.WidthPercentage = 100
            Dim intTblWidth() As Integer = {15, 40, 1, 15, 40}
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

            cell = New PdfPCell(New Paragraph("1234567891023450", Font3))
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

            cell = New PdfPCell(New Paragraph("GA1234567897890	", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("L B S Marg,Kurla west,Munbai 400070", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Create Date	", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)
            cell = New PdfPCell(New Paragraph("telephone:123-456-7890", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table41.AddCell(cell)

            cell = New PdfPCell(New Paragraph(Now.Date, Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table41.AddCell(cell)
            cell = New PdfPCell(New Paragraph("quickgarage@quickgarage.co.in", Font3))
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
            cell = New PdfPCell(New Paragraph("GSTIN ", Font3))
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
            'table41.AddCell("GSS quick garage pvt.LTD")
            'table41.AddCell("1234567891023450")
            'table41.AddCell("address:Paragon Plaza,Phoenix Market City, ")
            'table41.AddCell("GA1234567897890")
            'table41.AddCell("L B S Marg,Kurla west,Munbai 400070 ")
            'table41.AddCell("Create Date")
            'table41.AddCell("telephone:123-456-7890")
            'table41.AddCell("2021/03/21")
            'table41.AddCell("e-mail:quickgarage@quickgarage.co.in")
            'table41.AddCell("")
            'table41.AddCell("GSTIN 123456789")
            'table41.AddCell("")
            doc.Add(table41)

            'Dim p3 As New Paragraph()
            'p3.Alignment = Element.ALIGN_LEFT
            'p3.Add("GSS quick garage pvt.LTD ")
            'doc.Add(p3)

            'Dim p4 As New Paragraph()
            'p4.Alignment = Element.ALIGN_LEFT
            'p4.Add("address:Paragon Plaza,Phoenix Market City, ")
            'doc.Add(p4)

            'Dim p5 As New Paragraph()
            'p5.Alignment = Element.ALIGN_LEFT
            'p5.Add("L B S Marg,Kurla west,Munbai 400070")
            'doc.Add(p5)

            'Dim p6 As New Paragraph()
            'p6.Alignment = Element.ALIGN_LEFT
            'p6.Add("telephone:123-456-7890")
            'doc.Add(p6)


            'Dim P7 As New Paragraph()
            'P7.Alignment = Element.ALIGN_LEFT
            'P7.Add("e-mail:quickgarage@quickgarage.co.in")
            'doc.Add(P7)

            'Dim P8 As New Paragraph()
            'P8.Alignment = Element.ALIGN_LEFT
            'P8.Add("GSTIN")
            'doc.Add(P8)

            Dim fnt4 As New Font(BaseFont.CreateFont("c:\windows\fonts\msgothic.ttc,1", BaseFont.IDENTITY_H, True), 16, iTextSharp.text.Font.UNDERLINE)

            Dim fnt5 As New Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False))


            Dim Font1 As Font = New Font(bf, 14, Font.BOLD)

            Dim Font2 As Font = New Font(bf, 10, Font.BOLD)



            Dim P9 As New Paragraph("", Font1)
            P9.Alignment = Element.ALIGN_CENTER
            P9.Add("Tax Invoice")
            P9.Font = FontFactory.GetFont("Segoe UI", 18.0, BaseColor.ORANGE)
            doc.Add(P9)


            Dim P10 As New Paragraph()
            P10.Alignment = Element.ALIGN_LEFT
            P10.Add("" & vbLf)

            doc.Add(P10)

            'Dim P100 As New Paragraph()
            'P100.Alignment = Element.ALIGN_LEFT
            'P100.Add("" & vbLf)
            'P100.Add("")
            'doc.Add(P100)

            Dim header As PdfPCell = New PdfPCell()

            header.Colspan = 4

            table.AddCell(header)

            cell = New PdfPCell(New Paragraph("Invoice No.			", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPoNo.Text), Font3))
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
            cell = New PdfPCell(New Paragraph((Date.Now), Font3))
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
            cell = New PdfPCell(New Paragraph(" ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
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
            cell = New PdfPCell(New Paragraph("Mode Of Payment			 ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table.AddCell(cell)
            cell = New PdfPCell(New Paragraph(drpDenomination.SelectedItem.Text, Font3))
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
            cell = New PdfPCell(New Paragraph((txtCustomerName.Text), Font3))
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



            cell = New PdfPCell(New Paragraph((txtAddressLine1.Text), Font3))
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
            cell = New PdfPCell(New Paragraph((txtCity.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph("State		 ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtState.Text), Font3))
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




            cell = New PdfPCell(New Paragraph("Postal Code		 ", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtZip.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph("GSTIN/Unique ID					 ", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtGstin.Text, Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)
            cell = New PdfPCell(New Paragraph("GSTIN/Unique ID			", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)



            cell = New PdfPCell(New Paragraph(txtGstin.Text, Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            tables.AddCell(cell)




            doc.Add(tables)
            'doc.Add(table)


            Dim P11 As New Paragraph()
            P11.Alignment = Element.ALIGN_LEFT
            P11.Add("" & vbLf)


            doc.Add(P11)

            'Dim table51 As PdfPTable = New PdfPTable(1)
            'table51.WidthPercentage = 100
            'Dim header51 As PdfPCell = New PdfPCell()
            'header51.Colspan = 1
            'table.AddCell(header51) 'No pf Row

            'cell = New PdfPCell(New Paragraph("Symptoms reported by the customer"))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table51.AddCell(cell)


            'doc.Add(table51)


            'Dim P12 As New Paragraph()
            'P12.Alignment = Element.ALIGN_LEFT
            'P12.Add("Details")
            'doc.Add(P12)

            'Dim P13 As New Paragraph()
            'P13.Alignment = Element.ALIGN_LEFT
            'P13.Add("")
            'doc.Add(P13)



            ''Dim P14 As New Paragraph()
            ''P14.Alignment = Element.ALIGN_LEFT
            ''P14.Add("The customer's declaration is summarized in these five lines. Describe the declaration briefly, including both the reception table and verbal.")
            ''doc.Add(P14)

            'Dim table53 As PdfPTable = New PdfPTable(4)
            'table53.WidthPercentage = 100
            'Dim header53 As PdfPCell = New PdfPCell()
            'header53.Colspan = 4
            'table.AddCell(header53) 'No pf Row

            'cell = New PdfPCell(New Paragraph("The customer's declaration is summarized"))
            ''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table53.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("in these five lines. Describe the"))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table53.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("declaration briefly, including both "))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table53.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("both the reception table and verbal."))
            ''cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            '' cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table53.AddCell(cell)
            'doc.Add(table53)

            'Dim P15 As New Paragraph()
            'P15.Alignment = Element.ALIGN_LEFT
            'P15.Add("Parts and service charges used for repairs " & vbLf)

            'doc.Add(P15)


            'table.WriteSelectedRows(0, -1, doc.Left, doc.Top, writer.DirectContent)

            Dim table2 As PdfPTable = New PdfPTable(10)
            table2.WidthPercentage = 100
            Dim header2 As PdfPCell = New PdfPCell()
            header2.Colspan = 2
            table.AddCell(header2) 'No pf Row

            Dim intTblWidth10() As Integer = {4, 15, 50, 5, 10, 10, 10, 10, 10, 10}
            table2.SetWidths(intTblWidth10)

            'table2.AddCell("Sr No..")
            cell = New PdfPCell(New Paragraph("Sr No", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Item No", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Description", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("Qty", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Unit Price", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Total", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("Discount", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("TaxableValue", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("CGST", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("SGST", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)


            cell = New PdfPCell(New Paragraph("", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("HSN/SAC", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph("Serial No.", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            ' table2.AddCell("											")
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
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
            cell = New PdfPCell(New Paragraph("Rate%	Amount", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph("Rate%	Amount", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)


            cell = New PdfPCell(New Paragraph("1", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPartNo1.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPartDetails1.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtQty1.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSalesPrice1.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtTotal1.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(("0"), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtIGST1.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtCGST1.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSGST1.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)


            cell = New PdfPCell(New Paragraph("", Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("0", Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph((txtSerialNo.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            ' table2.AddCell("											")
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
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
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("2", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPartNo2.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPartDetails2.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtQty2.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSalesPrice2.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtTotal2.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(("0"), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtIGST2.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtCGST2.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSGST2.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)


            cell = New PdfPCell(New Paragraph("", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph(txtSerialNo.Text, Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            ' table2.AddCell("											")
            cell = New PdfPCell(New Paragraph("", Font3))

            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
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
            cell = New PdfPCell(New Paragraph("", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph("", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("3", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPartNo3.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPartDetails3.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtQty3.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSalesPrice3.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtTotal3.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(("0"), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtIGST3.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtCGST3.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSGST3.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)


            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("0", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph((txtSerialNo.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            ' table2.AddCell("											")
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
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
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph("4", Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPartNo4.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtPartDetails4.Text), Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtQty4.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSalesPrice4.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtTotal4.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(("0"), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtIGST4.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

            cell = New PdfPCell(New Paragraph((txtCGST4.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph((txtSGST4.Text), Font3))
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)


            cell = New PdfPCell(New Paragraph("", Font3))

            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("0", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph(txtSerialNo.Text, Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            ' table2.AddCell("											")
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ' cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph("", Font3))
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
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            'table2.AddCell("	")
            cell = New PdfPCell(New Paragraph("", Font3))
            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)

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
            cell = New PdfPCell(New Paragraph("Total", Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotalIGSTAmount.Text, Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotalCGSTAmount.Text, Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)
            cell = New PdfPCell(New Paragraph(txtTotalSGSTAmount.Text, Font3))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table2.AddCell(cell)





            'table2.AddCell(txtPartNo1.Text)
            'table2.AddCell(txtPartDetails1.Text)
            'table2.AddCell(txtSalesPrice1.Text)
            'table2.AddCell(txtTotal1.Text)
            'table2.AddCell(txtTotalAmount.Text)
            'table2.AddCell(txtCGST1.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)

            'table2.AddCell(txtPartNo2.Text)
            'table2.AddCell(txtPartDetails2.Text)
            'table2.AddCell(txtSalesPrice2.Text)
            'table2.AddCell(txtTotal2.Text)
            'table2.AddCell(txtTotalAmount.Text)
            'table2.AddCell(txtCGST2.Text)
            'table2.AddCell(txtSGST2.Text)
            'table2.AddCell(txtTotal2.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)

            'table2.AddCell(txtPartNo3.Text)
            'table2.AddCell(txtPartDetails3.Text)
            'table2.AddCell(txtSalesPrice3.Text)
            'table2.AddCell(txtTotal3.Text)
            'table2.AddCell(txtTotalAmount.Text)
            'table2.AddCell(txtCGST3.Text)
            'table2.AddCell(txtSGST3.Text)
            'table2.AddCell(txtTotal3.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)

            'table2.AddCell(txtPartNo4.Text)
            'table2.AddCell(txtPartDetails4.Text)
            'table2.AddCell(txtSalesPrice4.Text)
            'table2.AddCell(txtTotal4.Text)
            'table2.AddCell(txtTotalAmount.Text)
            'table2.AddCell(txtCGST4.Text)
            'table2.AddCell(txtSGST4.Text)
            'table2.AddCell(txtTotal4.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)

            'table2.AddCell(txtPartNo1.Text)
            'table2.AddCell(txtPartDetails1.Text)
            'table2.AddCell(txtSalesPrice1.Text)
            'table2.AddCell(txtTotal1.Text)
            'table2.AddCell(txtTotalAmount.Text)
            'table2.AddCell(txtCGST1.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)

            'table2.AddCell(txtPartNo2.Text)
            'table2.AddCell(txtPartDetails2.Text)
            'table2.AddCell(txtSalesPrice2.Text)
            'table2.AddCell(txtTotal2.Text)
            'table2.AddCell(txtTotalAmount.Text)
            'table2.AddCell(txtCGST2.Text)
            'table2.AddCell(txtSGST2.Text)
            'table2.AddCell(txtTotal2.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)

            'table2.AddCell(txtPartNo3.Text)
            'table2.AddCell(txtPartDetails3.Text)
            'table2.AddCell(txtSalesPrice3.Text)
            'table2.AddCell(txtTotal3.Text)
            'table2.AddCell(txtTotalAmount.Text)
            'table2.AddCell(txtCGST3.Text)
            'table2.AddCell(txtSGST3.Text)
            'table2.AddCell(txtTotal3.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)

            'table2.AddCell(txtPartNo4.Text)
            'table2.AddCell(txtPartDetails4.Text)
            'table2.AddCell(txtSalesPrice4.Text)
            'table2.AddCell(txtTotal4.Text)
            'table2.AddCell(txtTotalAmount.Text)
            'table2.AddCell(txtCGST4.Text)
            'table2.AddCell(txtSGST4.Text)
            'table2.AddCell(txtTotal4.Text)
            'table2.AddCell(txtSGST1.Text)
            'table2.AddCell(txtTotal1.Text)


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


            Dim P15 As New Paragraph("", Font3)
            P15.Alignment = Element.ALIGN_LEFT
            P15.Add("* Please make a note and proviso in this item.It is necessary to say that you agree to this
It's only within a few days that we can talk  about guarantees and refunds. " & vbLf)

            doc.Add(P15)

            'Dim table4 As PdfPTable = New PdfPTable(3)
            'table4.WidthPercentage = 100
            'Dim header4 As PdfPCell = New PdfPCell()
            'header4.Colspan = 3
            'table.AddCell(header4) 'No pf Row
            ''            cell = New PdfPCell(New Paragraph("※この項目に、注意書き、但し書きをしておいて
            ''この事に同意した事としますという文言が必要
            ''保証とか返金とかそういう話ができるのも何日以内しかないよという
            ''文言を用意してもらいここに入れておく
            ''* Please make a note and proviso in this item.
            ''It is necessary to say that you agree to this
            ''It's only within a few days that we can talk about guarantees and refunds.
            ''Have the wording prepared and put it here"))
            ''            cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''            table4.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("									"))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table4.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table4.AddCell(cell)
            ''cell = New PdfPCell(New Paragraph(""))
            ''' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            ''cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            ''table4.AddCell(cell)

            'doc.Add(table4)


            Dim table30 As PdfPTable = New PdfPTable(3)
            table30.WidthPercentage = 50

            Dim intTblWidth1() As Integer = {1, 15, 10}
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
            table3.WidthPercentage = 50
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
            strMoneyText = NumberToText(txtTotalAmount.Text)

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
            table31.WidthPercentage = 50
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
            cell = New PdfPCell(New Paragraph("No Data", Font3))
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
            table32.WidthPercentage = 50
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
            cell = New PdfPCell(New Paragraph(""))
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
            table33.WidthPercentage = 50
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
            cell = New PdfPCell(New Paragraph("No Data", Font3))
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
            table34.WidthPercentage = 50
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
            cell = New PdfPCell(New Paragraph(""))
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

            'Dim table4 As PdfPTable = New PdfPTable(4)
            'table4.WidthPercentage = 100
            'Dim header4 As PdfPCell = New PdfPCell()
            'header4.Colspan = 4
            'table.AddCell(header4) 'No pf Row
            'cell = New PdfPCell(New Paragraph("Advance Received(In Word)"))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table4.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table4.AddCell(cell)
            'cell = New PdfPCell(New Paragraph("Total Invoice(In Word)"))
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table4.AddCell(cell)
            'cell = New PdfPCell(New Paragraph(""))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table4.AddCell(cell)

            'doc.Add(table4)



            'Dim P17 As New Paragraph()
            'P17.Alignment = Element.ALIGN_LEFT
            'P17.Add("Estimate deadline And terms Of use")
            'doc.Add(P17)

            'Dim table52 As PdfPTable = New PdfPTable(1)
            'table52.WidthPercentage = 100
            'Dim header52 As PdfPCell = New PdfPCell()
            'header52.Colspan = 1
            'table.AddCell(header52) 'No pf Row

            'cell = New PdfPCell(New Paragraph("Estimate deadline And terms Of use"))
            '' cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'table52.AddCell(cell)


            'doc.Add(table52)


            'Dim P18 As New Paragraph()
            'P18.Alignment = Element.ALIGN_LEFT
            'P18.Add("Description Of the deadline For quotation")
            'doc.Add(P18)

            'Dim P19 As New Paragraph()
            'P19.Alignment = Element.ALIGN_LEFT
            'P19.Add("That this quote does Not mean that all repairs are guaranteed")
            'doc.Add(P19)

            'Dim P20 As New Paragraph()
            'P20.Alignment = Element.ALIGN_LEFT
            'P20.Add("Please note that different symptoms may be confirmed during the repair process And the repair details may change.")
            'doc.Add(P20)

            'Dim P21 As New Paragraph()
            'P21.Alignment = Element.ALIGN_LEFT
            'P21.Add("Please note that the billing amount may change due To the above reasons.")
            'doc.Add(P21)

            'Dim P22 As New Paragraph()
            'P22.Alignment = Element.ALIGN_LEFT
            'P22.Add("If the billing amount changes, you need To check With the customer again In advance.")
            'doc.Add(P22)

            'Dim P23 As New Paragraph()
            'P23.Alignment = Element.ALIGN_LEFT
            'P23.Add("We may Call you directly regarding the details Of the repair.")
            'doc.Add(P23)

            'Dim P24 As New Paragraph()
            'P24.Alignment = Element.ALIGN_RIGHT
            'P24.Add("We may Call you directly regarding the details Of the repair.")
            'doc.Add(P24)

            'Dim P24 As New Paragraph("I understand the above")
            'P24.Alignment = Element.ALIGN_LEFT
            'P24.Add(" ")
            'doc.Add(P24)

            'Dim P25 As New Paragraph()
            'P25.Alignment = Element.ALIGN_LEFT
            'P25.Add("I received the main body and confirmed the repair contents")
            'doc.Add(P25)
            ''P24 = New Paragraph()
            ''P24.Alignment = Element.ALIGN_LEFT
            ''P24.Add(" ")
            ''doc.Add(P24)

            Dim P17 As New Paragraph("", Font3)
            P17.Alignment = Element.ALIGN_LEFT
            P17.Add("I understand the above")
            doc.Add(P17)

            Dim P25 As New Paragraph("", Font3)
            P25.Alignment = Element.ALIGN_LEFT
            P25.Add("I received the main body and confirmed the repair contents")
            doc.Add(P25)


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
            cell = New PdfPCell(New Paragraph("Signature", Font3))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            table5.AddCell(cell)

            doc.Add(table5)







            Dim P26 As New Paragraph()
            P26.Alignment = Element.ALIGN_LEFT
            P26.Add(" ")
            doc.Add(P26)

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
            cell = New PdfPCell(New Paragraph("Authorized Signatory                                                                                                             E.&O.E.", Font3))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            cell.BorderWidthTop = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthLeft = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthRight = iTextSharp.text.Rectangle.NO_BORDER
            'cell.BorderWidthBottom = iTextSharp.text.Rectangle.NO_BORDER
            table6.AddCell(cell)
            doc.Add(table6)



            doc.Close()

            'Response.ClearContent()
            'Response.ClearHeaders()
            'Response.AddHeader("Content-Disposition", "inline;filename=" & filename)
            'Response.ContentType = "application/pdf"
            'Response.WriteFile(filename)
            'Response.TransmitFile(filename)
            'Response.Flush()
            'Response.Clear()

            ''Response.ContentType = "application/pdf"
            ''Response.AddHeader("content-disposition", "attachment;filename=" & filename)
            ''Response.Cache.SetCacheability(HttpCacheability.NoCache)
            ''Response.Write(doc)
            'Response.End()

            'Call showMsg("Invoice Downloaded Sucessfully", "Sucess")

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
    End Function
End Class