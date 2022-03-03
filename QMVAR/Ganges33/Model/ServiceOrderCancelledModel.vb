Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class ServiceOrderCancelledModel
        Public Sub ServiceOrderCancelledModel()
            CRTDT = String.Empty
            CRTCD = String.Empty
            UPDDT = String.Empty
            UPDCD = String.Empty
            UPDPG = String.Empty
            DELFG = String.Empty
            Status = String.Empty
            UserName = String.Empty
            TDateTime = String.Empty
            UserId = String.Empty
            UploadUser = String.Empty
            UploadDate = String.Empty
            ShipToBranchCode = String.Empty
            ShipToBranch = String.Empty

            ServiceOrderNo = String.Empty
            AscJobNo = String.Empty
            AscCode = String.Empty
            Created = String.Empty
            Assigned = String.Empty
            Model = String.Empty
            Serial = String.Empty
            WtyStatus = String.Empty
            Voc = String.Empty
            CustomerName = String.Empty
            City = String.Empty
            AppDate = String.Empty
            ServiceType = String.Empty
            StatusD = String.Empty
            Reason = String.Empty
            B2b = String.Empty

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

        Public Property ServiceOrderNo As String
        Public Property AscJobNo As String
        Public Property AscCode As String
        Public Property Created As String
        Public Property Assigned As String
        Public Property Model As String
        Public Property Serial As String
        Public Property WtyStatus As String
        Public Property Voc As String
        Public Property CustomerName As String
        Public Property City As String
        Public Property AppDate As String
        Public Property ServiceType As String
        Public Property StatusD As String
        Public Property Reason As String
        Public Property B2b As String

        Public Property FileName As String
        Public Property SrcFileName As String

        Public Property DateFrom As String
        Public Property DateTo As String
    End Class
End Namespace

