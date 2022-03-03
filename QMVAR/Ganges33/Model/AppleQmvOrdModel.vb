Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class AppleQmvOrdModel
        Public Sub SonyInBoundModel()
            CRTDT = String.Empty
            CRTCD = String.Empty
            UPDDT = String.Empty
            UPDCD = String.Empty
            UPDPG = String.Empty
            DELFG = String.Empty
            UNQ_NO = String.Empty
            UPLOAD_USER = String.Empty
            UPLOAD_DATE = String.Empty
            SHIP_TO_BRANCH_CODE = String.Empty
            SHIP_TO_BRANCH = String.Empty


            PO_NO = String.Empty
            G_NO = String.Empty
            PO_DATE = String.Empty
            CUSTOMER_NAME = String.Empty
            ZIP_CODE = String.Empty
            MOBLIE_PHONE = String.Empty
            TELEPHONE = String.Empty
            ADD_1 = String.Empty
            ADD_2 = String.Empty
            CITY = String.Empty
            STATE = String.Empty
            STATE_CODE = String.Empty
            E_MAIL = String.Empty


            IS_SHIP_DIFF = String.Empty
            CUSTOMER_NAME_SHIP = String.Empty
            ZIP_CODE_SHIP = String.Empty
            MOBLIE_PHONE_SHIP = String.Empty
            TELEPHONE_SHIP = String.Empty
            ADD_1_SHIP = String.Empty
            ADD_2_SHIP = String.Empty
            CITY_SHIP = String.Empty
            STATE_SHIP = String.Empty
            STATE_CODE_SHIP = String.Empty
            E_MAIL_SHIP = String.Empty


            MODEL_NAME = String.Empty
            PRODUCT_NAME = String.Empty
            SERIAL_NO = String.Empty
            IMEI_1 = String.Empty
            IMEI_2 = String.Empty
            DATE_OF_PURCHASE = String.Empty
            SERVICE_TYPE = String.Empty
            COMPTIA = String.Empty
            COMPTIA_MODIFIER = String.Empty
            ACCESSORY_NOTE = String.Empty

            PART_NO1 = String.Empty
            PART_NO2 = String.Empty
            PART_NO3 = String.Empty
            PART_NO4 = String.Empty
            PART_DETAIL_1 = String.Empty
            PART_DETAIL_2 = String.Empty
            PART_DETAIL_3 = String.Empty
            PART_DETAIL_4 = String.Empty
            PART_QTY_1 = String.Empty
            PART_QTY_2 = String.Empty
            PART_QTY_3 = String.Empty
            PART_QTY_4 = String.Empty
            LABOR_AMOUNT = String.Empty
            LABOR_DETAIL = String.Empty
            LABOR_COST = String.Empty
            LABOR_DISCOUNT = String.Empty
            LABOR_SALES = String.Empty
            LABOR_SGST = String.Empty
            LABOR_CGST = String.Empty
            LABOR_IGST = String.Empty
            LABOR_TOTAL = String.Empty
            PART_COST_1 = String.Empty
            PART_COST_2 = String.Empty
            PART_COST_3 = String.Empty
            PART_COST_4 = String.Empty
            PART_COST_SALES_1 = String.Empty
            PART_COST_SALES_2 = String.Empty
            PART_COST_SALES_3 = String.Empty
            PART_COST_SALES_4 = String.Empty

            PART_DISCOUNT_1 = String.Empty
            PART_DISCOUNT_2 = String.Empty
            PART_DISCOUNT_3 = String.Empty
            PART_DISCOUNT_4 = String.Empty

            PART_SGST_1 = String.Empty
            PART_SGST_2 = String.Empty
            PART_SGST_3 = String.Empty
            PART_SGST_4 = String.Empty
            PART_CGST_1 = String.Empty
            PART_CGST_2 = String.Empty
            PART_CGST_3 = String.Empty
            PART_CGST_4 = String.Empty
            PART_IGST_1 = String.Empty
            PART_IGST_2 = String.Empty
            PART_IGST_3 = String.Empty
            PART_IGST_4 = String.Empty
            PART_TOTAL_1 = String.Empty
            PART_TOTAL_2 = String.Empty
            PART_TOTAL_3 = String.Empty
            PART_TOTAL_4 = String.Empty
            PART_QTY_AMOUNT = String.Empty
            PART_COST_AMOUNT = String.Empty
            PART_DISCOUNT_AMOUNT = String.Empty
            PART_SALES_AMOUNT = String.Empty
            PART_SGST_AMOUNT = String.Empty
            PART_CGST_AMOUNT = String.Empty
            PART_IGST_AMOUNT = String.Empty

            PART1_TAX = String.Empty
            PART2_TAX = String.Empty
            PART3_TAX = String.Empty
            PART4_TAX = String.Empty
            OTHER_TAX = String.Empty
            LABOUR_TAX = String.Empty

            PART_TOTAL = String.Empty
            OTHER_QTY_AMOUNT = String.Empty
            OTHER_DETAIL = String.Empty

            OTHER_COST = String.Empty
            OTHER_SALES = String.Empty
            OTHER_SGST = String.Empty
            OTHER_CGST = String.Empty
            OTHER_IGST = String.Empty
            OTHER_TOTAL = String.Empty
            TOTAL_QTY = String.Empty
            TOTAL_COST_AMOUNT = String.Empty
            TOTAL_DISCOUNT_AMOUNT = String.Empty
            TOTAL_SALES_AMOUNT = String.Empty
            TOTAL_SGST_AMOUNT = String.Empty
            TOTAL_CGST_AMOUNT = String.Empty
            TOTAL_IGST_AMOUNT = String.Empty
            TOTAL_AMOUNT = String.Empty
            DELIVERY_DATE = String.Empty
            COMP_STATUS = String.Empty
            COMP_DATE = String.Empty
            DENOMINATION = String.Empty
            ESTIMATE_DATE = String.Empty
            ESTIMATE_TIME = String.Empty
            GSX_CLOSE_DATE = String.Empty
            USE_SERVICE_TYPE = String.Empty
            INVOICE_NOTE = String.Empty

            INVOICE_NO = String.Empty
            INVOICE_DATE = String.Empty

            GSX_NOTE = String.Empty
            HSN_SAC_CODE = String.Empty
            GSTIN = String.Empty
            IP_ADDRESS = String.Empty

            PART_HSN_ASC_1 = String.Empty
            PART_HSN_ASC_2 = String.Empty
            PART_HSN_ASC_3 = String.Empty
            PART_HSN_ASC_4 = String.Empty

            PRICE_OPTIONS_1 = False
            PRICE_OPTIONS_2 = False
            PRICE_OPTIONS_3 = False
            PRICE_OPTIONS_4 = False


            PRICE_OPTIONS_1_TYPE = String.Empty
            PRICE_OPTIONS_2_TYPE = String.Empty
            PRICE_OPTIONS_3_TYPE = String.Empty
            PRICE_OPTIONS_4_TYPE = String.Empty

            STATUS = String.Empty
            FILE_NAME = String.Empty
            UserId = String.Empty

            SRC_FILE_NAME = String.Empty


            ADVANCE_PAYMENT = 0.00

            SortText = String.Empty

            TRANSFER_REPAIR_CENTER = False
            ACTION_TAKEN = String.Empty
            RECEPTION = False
            INTERNAL_INSPECTION = False
            SIGNATURE_INSERVICE_ESTIMATE = False
            WHOLE_SERVICE_FEE_ADR_COLLECTION = False
            GSX_ORDER = False
            REPAIR = False
            REMAINING_AMOUNT_COLLECTION = False
            LOANER_COLLECTION = False
            SEVICE_REPORT = False
            TAX_INVOICE = False

            INVENTORY_FLG = False

            SERIAL_STOCK_USED_1 = False
            SERIAL_STOCK_USED_2 = False
            SERIAL_STOCK_USED_3 = False
            SERIAL_STOCK_USED_4 = False


        End Sub

        Public Property CRTDT As String
        Public Property CRTCD As String
        Public Property UPDDT As String
        Public Property UPDCD As String
        Public Property UPDPG As String
        Public Property DELFG As String
        Public Property UNQ_NO As String
        Public Property UPLOAD_USER As String
        Public Property UPLOAD_DATE As String
        Public Property SHIP_TO_BRANCH_CODE As String
        Public Property SHIP_TO_BRANCH As String

        Public Property PO_NO As String
        Public Property G_NO As String
        Public Property PO_DATE As String
        Public Property CUSTOMER_NAME As String
        Public Property ZIP_CODE As String
        Public Property MOBLIE_PHONE As String
        Public Property TELEPHONE As String
        Public Property ADD_1 As String
        Public Property ADD_2 As String
        Public Property CITY As String
        Public Property STATE As String
        Public Property STATE_CODE As String
        Public Property E_MAIL As String

        Public Property IS_SHIP_DIFF As String
        Public Property CUSTOMER_NAME_SHIP As String
        Public Property ZIP_CODE_SHIP As String
        Public Property MOBLIE_PHONE_SHIP As String
        Public Property TELEPHONE_SHIP As String
        Public Property ADD_1_SHIP As String
        Public Property ADD_2_SHIP As String
        Public Property CITY_SHIP As String
        Public Property STATE_SHIP As String
        Public Property STATE_CODE_SHIP As String
        Public Property E_MAIL_SHIP As String


        Public Property MODEL_NAME As String
        Public Property PRODUCT_NAME As String
        Public Property SERIAL_NO As String
        Public Property IMEI_1 As String
        Public Property IMEI_2 As String
        Public Property DATE_OF_PURCHASE As String
        Public Property SERVICE_TYPE As String
        Public Property COMPTIA As String
        Public Property COMPTIA_MODIFIER As String
        Public Property ACCESSORY_NOTE As String

        Public Property PART_NO1 As String
        Public Property PART_NO2 As String
        Public Property PART_NO3 As String
        Public Property PART_NO4 As String
        Public Property PART_DETAIL_1 As String
        Public Property PART_DETAIL_2 As String
        Public Property PART_DETAIL_3 As String
        Public Property PART_DETAIL_4 As String
        Public Property PART_QTY_1 As String
        Public Property PART_QTY_2 As String
        Public Property PART_QTY_3 As String
        Public Property PART_QTY_4 As String
        Public Property LABOR_AMOUNT As String
        Public Property LABOR_DETAIL As String
        Public Property LABOR_COST As String
        Public Property LABOR_DISCOUNT As String
        Public Property LABOR_SALES As String
        Public Property LABOR_SGST As String
        Public Property LABOR_CGST As String
        Public Property LABOR_IGST As String
        Public Property LABOR_TOTAL As String
        Public Property PART_COST_1 As String
        Public Property PART_COST_2 As String
        Public Property PART_COST_3 As String
        Public Property PART_COST_4 As String
        Public Property PART_COST_SALES_1 As String
        Public Property PART_COST_SALES_2 As String
        Public Property PART_COST_SALES_3 As String
        Public Property PART_COST_SALES_4 As String


        Public Property PART_DISCOUNT_1 As String
        Public Property PART_DISCOUNT_2 As String
        Public Property PART_DISCOUNT_3 As String
        Public Property PART_DISCOUNT_4 As String


        Public Property PART_SGST_1 As String
        Public Property PART_SGST_2 As String
        Public Property PART_SGST_3 As String
        Public Property PART_SGST_4 As String
        Public Property PART_CGST_1 As String
        Public Property PART_CGST_2 As String
        Public Property PART_CGST_3 As String
        Public Property PART_CGST_4 As String
        Public Property PART_IGST_1 As String
        Public Property PART_IGST_2 As String
        Public Property PART_IGST_3 As String
        Public Property PART_IGST_4 As String
        Public Property PART_TOTAL_1 As String
        Public Property PART_TOTAL_2 As String
        Public Property PART_TOTAL_3 As String
        Public Property PART_TOTAL_4 As String
        Public Property PART_QTY_AMOUNT As String
        Public Property PART_COST_AMOUNT As String
        Public Property PART_SALES_AMOUNT As String
        Public Property PART_DISCOUNT_AMOUNT As String
        Public Property PART_SGST_AMOUNT As String
        Public Property PART_CGST_AMOUNT As String
        Public Property PART_IGST_AMOUNT As String
        Public Property PART_TOTAL As String
        Public Property OTHER_QTY_AMOUNT As String
        Public Property OTHER_DETAIL As String
        Public Property OTHER_COST As String
        Public Property OTHER_DISCOUNT As String
        Public Property OTHER_SALES As String
        Public Property OTHER_SGST As String
        Public Property OTHER_CGST As String
        Public Property OTHER_IGST As String


        Public Property PART1_TAX As String
        Public Property PART2_TAX As String
        Public Property PART3_TAX As String
        Public Property PART4_TAX As String
        Public Property LABOUR_TAX As String
        Public Property OTHER_TAX As String

        Public Property OTHER_TOTAL As String
        Public Property TOTAL_QTY As String
        Public Property TOTAL_COST_AMOUNT As String
        Public Property TOTAL_DISCOUNT_AMOUNT As String
        Public Property TOTAL_SALES_AMOUNT As String
        Public Property TOTAL_SGST_AMOUNT As String
        Public Property TOTAL_CGST_AMOUNT As String
        Public Property TOTAL_IGST_AMOUNT As String
        Public Property TOTAL_AMOUNT As String
        Public Property DELIVERY_DATE As String
        Public Property COMP_STATUS As String
        Public Property COMP_DATE As String
        Public Property DENOMINATION As String
        Public Property ESTIMATE_DATE As String
        Public Property ESTIMATE_TIME As String

        Public Property INVOICE_NO As String
        Public Property INVOICE_DATE As String

        Public Property GSX_CLOSE_DATE As String
        Public Property USE_SERVICE_TYPE As String
        Public Property INVOICE_NOTE As String
        Public Property GSX_NOTE As String
        Public Property HSN_SAC_CODE As String
        Public Property GSTIN As String

        Public Property PART_HSN_ASC_1 As String
        Public Property PART_HSN_ASC_2 As String
        Public Property PART_HSN_ASC_3 As String

        Public Property PRICE_OPTIONS_1 As Boolean
        Public Property PRICE_OPTIONS_2 As Boolean
        Public Property PRICE_OPTIONS_3 As Boolean
        Public Property PRICE_OPTIONS_4 As Boolean


        Public Property PRICE_OPTIONS_1_TYPE As String
        Public Property PRICE_OPTIONS_2_TYPE As String
        Public Property PRICE_OPTIONS_3_TYPE As String
        Public Property PRICE_OPTIONS_4_TYPE As String


        Public Property PART_HSN_ASC_4 As String

        Public Property STATUS As String
        Public Property FILE_NAME As String
        Public Property UserId As String
        Public Property SRC_FILE_NAME As String
        Public Property IP_ADDRESS As String
        Public Property DateFrom As String
        Public Property DateTo As String

        Public Property ADVANCE_PAYMENT As Decimal


        Public Property SortText As String


        Public Property TRANSFER_REPAIR_CENTER As Boolean
        Public Property ACTION_TAKEN As String
        Public Property RECEPTION As Boolean
        Public Property INTERNAL_INSPECTION As Boolean
        Public Property SIGNATURE_INSERVICE_ESTIMATE As Boolean
        Public Property WHOLE_SERVICE_FEE_ADR_COLLECTION As Boolean
        Public Property GSX_ORDER As Boolean
        Public Property REPAIR As Boolean
        Public Property REMAINING_AMOUNT_COLLECTION As Boolean
        Public Property LOANER_COLLECTION As Boolean
        Public Property SEVICE_REPORT As Boolean
        Public Property TAX_INVOICE As Boolean

        Public Property INVENTORY_FLG As Boolean

        Public Property SERIAL_STOCK_USED_1 As Boolean
        Public Property SERIAL_STOCK_USED_2 As Boolean
        Public Property SERIAL_STOCK_USED_3 As Boolean
        Public Property SERIAL_STOCK_USED_4 As Boolean
    End Class

End Namespace
