Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class AppleStockTransactionModel

        Public Sub ApplePartsStockModel()
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
            GetValue = String.Empty
            DropdownSearch_1 = String.Empty
            DropdownSearch_2 = String.Empty
            DropdownSearch_3 = String.Empty
            Search_From_Date = String.Empty
            Search_To_Date = String.Empty



            PART_NO = String.Empty
            QUANTITY = String.Empty
            DESCRIPTION = String.Empty

            TRAN_TYPE = String.Empty
            TRAN_REF = String.Empty



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
        Public Property Comments As String
        Public Property SHIP_TO_BRANCH_CODE As String
        Public Property SHIP_TO_BRANCH As String
        Public Property DropdownSearch_1 As String
        Public Property DropdownSearch_2 As String
        Public Property DropdownSearch_3 As String
        Public Property Search_From_Date As String
        Public Property Search_To_Date As String

        Public Property GetValue As String
        Public Property ORIGINAL_PART_NO As String
        Public Property CHANGED_VALUE As String
        Public Property ACTUAL_STOCK As String
        Public Property SR_NO As String

        Public Property QUANTITY As String


        Public Property TRAN_TYPE As String
        Public Property TRAN_REF As String
        Public Property PART_NO As String

        Public Property DESCRIPTION As String

        Public Property UserId As String
        Public Property UploadUser As String

    End Class
End Namespace