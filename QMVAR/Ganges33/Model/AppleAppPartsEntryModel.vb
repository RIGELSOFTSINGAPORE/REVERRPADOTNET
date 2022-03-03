Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class AppleAppPartsEntryModel

        Public Sub AppleAppPartsEntryModel()
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
            PARTS_NO = String.Empty
            PARTS_NAME = String.Empty
            PARTS_DESCRIPTION = String.Empty
            PARTS_TYPE = String.Empty
            PARTS_COST = String.Empty
            TIER = String.Empty
            EEE_EEEE = String.Empty
            TRAN_REF = String.Empty
            TRAN_TYPE = String.Empty
            SERIAL = String.Empty
            SERIAL_NO = String.Empty
            IN_STOCK = String.Empty
            BALANCE = String.Empty
            STOCK_TYPE = String.Empty
            QUANTITY = String.Empty
            INVENTORY_NO = String.Empty
            INVENTORY_DATE = String.Empty
            PART_TAX = String.Empty


            UserId = String.Empty
            UploadUser = String.Empty

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
        Public Property TRAN_TYPE As String

        Public Property SR_NO As String
        Public Property PARTS_NO As String
        Public Property PARTS_NAME As String
        Public Property PARTS_DESCRIPTION As String
        Public Property PARTS_TYPE As String
        Public Property PARTS_COST As String
        Public Property TIER As String
        Public Property EEE_EEEE As String
        Public Property SERIAL As String
        Public Property TRAN_REF As String
        Public Property SERIAL_NO As String
        Public Property IN_STOCK As String
        Public Property BALANCE As String
        Public Property STOCK_TYPE As String
        Public Property QUANTITY As String
        Public Property INVENTORY_NO As String
        Public Property INVENTORY_DATE As String

        Public Property PART_TAX As String

        Public Property UserId As String
        Public Property UploadUser As String

    End Class
End Namespace