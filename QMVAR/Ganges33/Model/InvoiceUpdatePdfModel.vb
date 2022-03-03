Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class InvoiceUpdatePdfModel
        Public Sub PrSummaryModel()
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

            FiscalMonth = String.Empty
            ReportNo = String.Empty
            Number = String.Empty
            PartsInvoiceNo = String.Empty
            LaborInvoiceNo = String.Empty
            InvoiceDate = String.Empty


            FileName = String.Empty
            SrcFileName = String.Empty
            FileNameSSC = String.Empty



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


        Public Property FiscalMonth As String
        Public Property ReportNo As String
        Public Property Number As String
        Public Property PartsInvoiceNo As String
        Public Property LaborInvoiceNo As String
        Public Property InvoiceDate As String





        Public Property FileName As String
        Public Property SrcFileName As String

        Public Property FileNameSSC As String

        Public Property DateFrom As String
        Public Property DateTo As String
    End Class
End Namespace

