Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class AppleRewordModel
        Public Sub AppleRewordModel()
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


            LABOUR_TYPE = String.Empty
            PART_NO = String.Empty
            LABOUR_DESCRIPTION = String.Empty
            LABOUR_DETAILS = String.Empty
            LABOUR_CODE = String.Empty
            AMOUNT_100 = 0.00
            AMOUNT_150 = 0.00
            AMOUNT_170 = 0.00
            AMOUNT_180 = 0.00
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

        Public Property LABOUR_TYPE As String
        Public Property PART_NO As String
        Public Property LABOUR_DESCRIPTION As String
        Public Property LABOUR_DETAILS As String
        Public Property LABOUR_CODE As String
        Public Property AMOUNT_100 As Decimal
        Public Property AMOUNT_150 As String
        Public Property AMOUNT_170 As String
        Public Property AMOUNT_180 As String
        Public Property HSN_SAC As String



        Public Property FILE_NAME As String
        Public Property UserId As String
        Public Property SRC_FILE_NAME As String
        Public Property IP_ADDRESS As String
        Public Property DateFrom As String
        Public Property DateTo As String

    End Class

End Namespace
