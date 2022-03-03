Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class ApplePartsModel
        Public Sub ApplePartsModel()
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
            PRODUCT_NAME = String.Empty
            PARTS_NO = String.Empty
            PARTS_DETAIL = String.Empty
            PARTS_TYPE = String.Empty
            TIER = String.Empty
            CURRENCY = String.Empty
            PRICE_OPTION = String.Empty
            PRICE_COST = 0.00
            EEE_EEEE = String.Empty
            ALTNATIVE_PARTS = String.Empty
            COMPONENT_GROUP = String.Empty
            SERIAL_NO = String.Empty
            DIAG_REQ = String.Empty
            SALES_PRICE = 0.00
            HSN_SAC = String.Empty


            IP_ADDRESS = String.Empty



            FILE_NAME = String.Empty
            UserId = String.Empty

            SRC_FILE_NAME = String.Empty

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
        Public Property STATUS As String
        Public Property PRODUCT_NAME As String
        Public Property PARTS_NO As String
        Public Property PARTS_DETAIL As String
        Public Property PARTS_TYPE As String
        Public Property TIER As String
        Public Property CURRENCY As String
        Public Property PRICE_OPTION As String
        Public Property PRICE_COST As Decimal
        Public Property EEE_EEEE As String
        Public Property ALTNATIVE_PARTS As String
        Public Property COMPONENT_GROUP As String
        Public Property SERIAL_NO As String
        Public Property DIAG_REQ As String
        Public Property SALES_PRICE As Decimal
        Public Property HSN_SAC As String


        Public Property FILE_NAME As String
        Public Property UserId As String
        Public Property SRC_FILE_NAME As String
        Public Property IP_ADDRESS As String
        Public Property DateFrom As String
        Public Property DateTo As String

    End Class

End Namespace
