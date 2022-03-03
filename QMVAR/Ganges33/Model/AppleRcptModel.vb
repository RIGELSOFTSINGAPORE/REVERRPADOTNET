Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class AppleRcptModel
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

            MODEL = String.Empty
            TYPE = String.Empty

            TOKEN_NO = String.Empty
            NAME = String.Empty
            MOBILE = String.Empty
            PO_NO = String.Empty
            COMMENTS = String.Empty

            IP_ADDRESS = String.Empty

            STATUS = String.Empty
            FILE_NAME = String.Empty
            UserId = String.Empty

            SRC_FILE_NAME = String.Empty

            START_DATETIME = String.Empty
            END_DATETIIME = String.Empty
            SUSPENSION_DATETIME = String.Empty

            SortText = String.Empty

            TOKEN_TYPE = String.Empty

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

        Public Property MODEL As String
        Public Property TYPE As String
        Public Property TOKEN_NO As String
        Public Property NAME As String
        Public Property MOBILE As String
        Public Property PO_NO As String
        Public Property COMMENTS As String

        Public Property START_DATETIME As String
        Public Property END_DATETIIME As String
        Public Property SUSPENSION_DATETIME As String


        Public Property STATUS As String
        Public Property FILE_NAME As String
        Public Property UserId As String
        Public Property SRC_FILE_NAME As String
        Public Property IP_ADDRESS As String
        Public Property DateFrom As String
        Public Property DateTo As String

        Public Property SortText As String

        Public Property TOKEN_TYPE As String

    End Class

End Namespace
