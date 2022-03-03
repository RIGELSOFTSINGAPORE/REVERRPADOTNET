Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class ApplePartsEntryModel

        Public Sub ApplePartsEntryModel()
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


            SR_NO = String.Empty
            PART_NO = String.Empty
            UPC_EAN = String.Empty
            DESCRIPTION = String.Empty
            SAP_PART_DESCRIPTION = String.Empty
            PURCHASE_PRICE = String.Empty
            IN_STOCK = String.Empty
            SOLD = String.Empty
            BALANCE = String.Empty
            LAST_OUT_DATE = String.Empty
            LAST_IN_DATE = String.Empty
            CURRENT_IN_STOCK = String.Empty
            NUMBER_SOLD_SO_FAR = String.Empty
            NUMBER_PURCHASED_SO_FAR = String.Empty
            SALES_PRICE = String.Empty
            IP_ADDRESS = String.Empty
            FILE_NAME = String.Empty
            SRC_FILE_NAME = String.Empty
            INVENTORY_NO = String.Empty
            INVENTORY_DATE = String.Empty
            PART_TAX = String.Empty


            UserId = String.Empty
            UploadUser = String.Empty

            SERIAL_TYPE = String.Empty

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


        Public Property SR_NO As String
        Public Property PART_NO As String
        Public Property UPC_EAN As String
        Public Property DESCRIPTION As String
        Public Property SAP_PART_DESCRIPTION As String
        Public Property PURCHASE_PRICE As String
        Public Property IN_STOCK As String
        Public Property SOLD As String
        Public Property BALANCE As String
        Public Property LAST_OUT_DATE As String
        Public Property LAST_IN_DATE As String
        Public Property CURRENT_IN_STOCK As String
        Public Property NUMBER_SOLD_SO_FAR As String
        Public Property NUMBER_PURCHASED_SO_FAR As String

        Public Property SALES_PRICE As String
        Public Property IP_ADDRESS As String
        Public Property FILE_NAME As String
        Public Property SRC_FILE_NAME As String
        Public Property INVENTORY_NO As String
        Public Property INVENTORY_DATE As String

        Public Property PART_TAX As String

        Public Property UserId As String
        Public Property UploadUser As String

        Public Property SERIAL_TYPE As String


    End Class
End Namespace