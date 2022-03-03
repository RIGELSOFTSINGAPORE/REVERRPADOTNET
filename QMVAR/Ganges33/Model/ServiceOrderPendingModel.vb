Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class ServiceOrderPendingModel
        Public Sub ServiceOrderCancelledModel()
            CRTDT = String.Empty
            CRTCD = String.Empty
            UPDDT = String.Empty
            UPDCD = String.Empty
            UPDPG = String.Empty
            DELFG = String.Empty
            Status = String.Empty
            'UserName = String.Empty
            'TDateTime = String.Empty
            'UserId = String.Empty
            UploadUser = String.Empty
            UploadDate = String.Empty
            ShipToBranchCode = String.Empty
            ShipToBranch = String.Empty

            TRACKING_NO = String.Empty
            CP_CODE = String.Empty
            CP_NAME = String.Empty
            ASC_REF_NO = String.Empty
            REQUESTED_DATE = String.Empty
            SERVICE_TYPE = String.Empty
            MODEL_CODE = String.Empty
            SERIAL_NO = String.Empty
            CUSTOMER_NAME = String.Empty
            FIRST_ANTICIPATED_DATE = String.Empty
            DEALER_BP = String.Empty
            DEALER_NAME = String.Empty
            PHONE_NUMBER = String.Empty
            EMAIL_ID = String.Empty
            AGING_DAY = String.Empty
            Reason = String.Empty

            FileName = String.Empty
            SrcFileName = String.Empty

            DateFrom = String.Empty
            DateTo = String.Empty
        End Sub

        Public Property CRTDT As String
        Public Property CRTCD As String
        Public Property UPDDT As String
        Public Property UPDCD As String
        Public Property UPDPG As String
        Public Property DELFG As String
        Public Property Status As String
        Public Property UserName As String
        Public Property TDateTime As String
        Public Property UserId As String
        Public Property UploadUser As String
        Public Property UploadDate As String
        Public Property ShipToBranchCode As String
        Public Property ShipToBranch As String

        Public Property TRACKING_NO As String
        Public Property CP_CODE As String
        Public Property CP_NAME As String
        Public Property ASC_REF_NO As String
        Public Property REQUESTED_DATE As String
        Public Property SERVICE_TYPE As String
        Public Property MODEL_CODE As String
        Public Property SERIAL_NO As String
        Public Property CUSTOMER_NAME As String
        Public Property FIRST_ANTICIPATED_DATE As String
        Public Property DEALER_BP As String
        Public Property DEALER_NAME As String
        Public Property PHONE_NUMBER As String
        Public Property EMAIL_ID As String
        Public Property AGING_DAY As String
        Public Property Reason As String

        Public Property FileName As String
        Public Property SrcFileName As String

        Public Property DateFrom As String
        Public Property DateTo As String
    End Class
End Namespace

