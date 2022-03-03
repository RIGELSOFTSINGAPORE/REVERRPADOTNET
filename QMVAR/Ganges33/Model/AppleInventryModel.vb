Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    <Serializable>
    Public Class AppleInvnetryModel
        Public Sub SonyInBoundModel()
            CRTDT = String.Empty
            CRTCD = String.Empty
            UPDDT = String.Empty
            UPDCD = String.Empty
            UPDPG = String.Empty
            DELFG = String.Empty
            inventry_date_from = String.Empty
            part_no = String.Empty
            UPCEAN = String.Empty

            description = String.Empty
            pirchase_price = String.Empty
            in_stock = String.Empty
            inventry_no = String.Empty
            inventry_date = String.Empty

            ship_to_branch_code = String.Empty
            ship_to_brance = String.Empty

            sold = String.Empty
            balance = String.Empty

            last_out_date = String.Empty


            last_in_date = String.Empty
            current_in_stock = String.Empty
            Number_sold_so_far = String.Empty

            Number_purchased_so_far = String.Empty
            sales_price = String.Empty

            UNQ_NO = String.Empty




        End Sub

        Public Property CRTDT As String
        Public Property CRTCD As String
        Public Property UPDDT As String
        Public Property UPDCD As String
        Public Property UNQ_NO As String
        Public Property UPDPG As String
        Public Property DELFG As String
        Public Property part_no As String
        Public Property UPCEAN As String
        Public Property description As String
        Public Property pirchase_price As String
        Public Property in_stock As String
        Public Property inventry_date_from As String
        Public Property inventry_no As String
        Public Property inventry_date As String


        Public Property ship_to_branch_code As String
        Public Property ship_to_brance As String

        Public Property sold As String
        Public Property balance As String

        Public Property last_out_date As String


        Public Property last_in_date As String
        Public Property current_in_stock As String
        Public Property Number_sold_so_far As String

        Public Property Number_purchased_so_far As String
        Public Property sales_price As String

    End Class

End Namespace
