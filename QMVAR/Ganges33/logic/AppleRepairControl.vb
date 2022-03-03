Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic


Public Class AppleRepairControl
    Public Function AddRepair(queryParams As AppleRepairModel) As Boolean
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = True
        Dim PoNo As String = ""
        Dim No As String = ""
        Dim PoNoTmp1 As Integer = 0
        Dim PoNoTmp2 As Integer = 0
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn
        Dim sqlStr As String = ""

        sqlStr = "Insert into AP_REPAIR_LOOKUP ("
        sqlStr = sqlStr & "CRTDT, "
        sqlStr = sqlStr & "CRTCD, "
        ' sqlStr = sqlStr & "UPDDT, "
        sqlStr = sqlStr & "UPDCD, "
        sqlStr = sqlStr & "UPDPG, "
        sqlStr = sqlStr & "DELFG, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "SHIP_TO_BRANCH, "


        sqlStr = sqlStr & "PENDING_SHIPMENT, "
        sqlStr = sqlStr & "PO_NO, "
        sqlStr = sqlStr & "REPAIR_STATUS, "
        sqlStr = sqlStr & "SERIAL_NO, "
        sqlStr = sqlStr & "IMEI_1, "
        sqlStr = sqlStr & "IMEI_2, "
        sqlStr = sqlStr & "SHIP_TO, "
        sqlStr = sqlStr & "UNRETURNED_MODULE, "
        sqlStr = sqlStr & "INCOMPLETE_REPAIR, "
        sqlStr = sqlStr & "REPAIR_NO, "
        sqlStr = sqlStr & "REPAIR_CATEGORY, "
        sqlStr = sqlStr & "CREATED_DATE, "
        sqlStr = sqlStr & "CUSTOMER_NAME, "
        sqlStr = sqlStr & "RETURN_TRACKING_NO, "
        sqlStr = sqlStr & "POP_UPLOADED, "
        sqlStr = sqlStr & "DISPATCH_NO, "
        sqlStr = sqlStr & "SOLD_TO_ACCOUNT, "
        sqlStr = sqlStr & "INVOICE, "
        sqlStr = sqlStr & "SHIPPING_STATUS, "
        sqlStr = sqlStr & "PART_NO, "
        sqlStr = sqlStr & "PART_DETAILS, "
        sqlStr = sqlStr & "WARRANTY_STATUS, "
        sqlStr = sqlStr & "SERVICE_LEVEL_CODE, "
        sqlStr = sqlStr & "SHIPPED, "
        sqlStr = sqlStr & "NON_RETURNABLE_DAMAGE, "
        sqlStr = sqlStr & "CONTROL_NO, "
        sqlStr = sqlStr & "RETURN_CODE, "
        sqlStr = sqlStr & "PRODUCT_NAME, "
        sqlStr = sqlStr & "PRODUCT_DETAIL, "
        sqlStr = sqlStr & "DEPOT_REPAIR_STATUS, "
        sqlStr = sqlStr & "NOTE, "
        sqlStr = sqlStr & "OTHER_THAN_REPLENISHMENT, "
        sqlStr = sqlStr & "OS_VERSION, "
        sqlStr = sqlStr & "RAM, "
        sqlStr = sqlStr & "HARD_DRIVE, "
        sqlStr = sqlStr & "COMPANY_NAME, "
        sqlStr = sqlStr & "MUNICPALITY, "
        sqlStr = sqlStr & "ZIP_CODE, "
        sqlStr = sqlStr & "PREFECTURES, "
        sqlStr = sqlStr & "LANGUAGE, "
        sqlStr = sqlStr & "COUNTRY_NAME, "
        sqlStr = sqlStr & "TYPES_OF_PARTS, "
        sqlStr = sqlStr & "NON_RETURNABLE_DAMAGE_PARTS, "
        sqlStr = sqlStr & "COMPTIA_GROUP, "
        sqlStr = sqlStr & "COMTIA_CODE, "
        sqlStr = sqlStr & "COMPTIA_MODIFIER, "
        sqlStr = sqlStr & "MEID, "
        sqlStr = sqlStr & "PRODUCT_RECEIPT_DATE, "
        sqlStr = sqlStr & "DATE_MARKED_AS_COMPLETE, "
        sqlStr = sqlStr & "PURCHASE_DATE, "
        sqlStr = sqlStr & "TECHNICIAN_NAME, "
        sqlStr = sqlStr & "BILLED, "
        sqlStr = sqlStr & "APPLECAREPLUS_CONSUMED, "
        sqlStr = sqlStr & "WARRANTY_OPTION, "
        sqlStr = sqlStr & "SHIP_THE_PRODUCT_TO_THE_USER, "
        sqlStr = sqlStr & "IP_ADDRESS "
        sqlStr = sqlStr & " ) "
        sqlStr = sqlStr & " values ( "
        sqlStr = sqlStr & "@CRTDT, "
        sqlStr = sqlStr & "@CRTCD, "
        'sqlStr = sqlStr & "@UPDDT, "
        sqlStr = sqlStr & "@UPDCD, "
        sqlStr = sqlStr & "@UPDPG, "
        sqlStr = sqlStr & "@DELFG, "
        '         sqlStr = sqlStr & " (select max(UNQ_NO)+1 from G_RECEIVED) , "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
        sqlStr = sqlStr & "@SHIP_TO_BRANCH, "



        sqlStr = sqlStr & "@PENDING_SHIPMENT, "
        sqlStr = sqlStr & "@PO_NO, "
        sqlStr = sqlStr & "@REPAIR_STATUS, "
        sqlStr = sqlStr & "@SERIAL_NO, "
        sqlStr = sqlStr & "@IMEI_1, "
        sqlStr = sqlStr & "@IMEI_2, "
        sqlStr = sqlStr & "@SHIP_TO, "
        sqlStr = sqlStr & "@UNRETURNED_MODULE, "
        sqlStr = sqlStr & "@INCOMPLETE_REPAIR, "
        sqlStr = sqlStr & "@REPAIR_NO, "
        sqlStr = sqlStr & "@REPAIR_CATEGORY, "
        sqlStr = sqlStr & "@CREATED_DATE, "
        sqlStr = sqlStr & "@CUSTOMER_NAME, "
        sqlStr = sqlStr & "@RETURN_TRACKING_NO, "
        sqlStr = sqlStr & "@POP_UPLOADED, "
        sqlStr = sqlStr & "@DISPATCH_NO, "
        sqlStr = sqlStr & "@SOLD_TO_ACCOUNT, "
        sqlStr = sqlStr & "@INVOICE, "
        sqlStr = sqlStr & "@SHIPPING_STATUS, "
        sqlStr = sqlStr & "@PART_NO, "
        sqlStr = sqlStr & "@PART_DETAILS, "
        sqlStr = sqlStr & "@WARRANTY_STATUS, "
        sqlStr = sqlStr & "@SERVICE_LEVEL_CODE, "
        sqlStr = sqlStr & "@SHIPPED, "
        sqlStr = sqlStr & "@NON_RETURNABLE_DAMAGE, "
        sqlStr = sqlStr & "@CONTROL_NO, "
        sqlStr = sqlStr & "@RETURN_CODE, "
        sqlStr = sqlStr & "@PRODUCT_NAME, "
        sqlStr = sqlStr & "@PRODUCT_DETAIL, "
        sqlStr = sqlStr & "@DEPOT_REPAIR_STATUS, "
        sqlStr = sqlStr & "@NOTE, "
        sqlStr = sqlStr & "@OTHER_THAN_REPLENISHMENT, "
        sqlStr = sqlStr & "@OS_VERSION, "
        sqlStr = sqlStr & "@RAM, "
        sqlStr = sqlStr & "@HARD_DRIVE, "
        sqlStr = sqlStr & "@COMPANY_NAME, "
        sqlStr = sqlStr & "@MUNICPALITY, "
        sqlStr = sqlStr & "@ZIP_CODE, "
        sqlStr = sqlStr & "@PREFECTURES, "
        sqlStr = sqlStr & "@LANGUAGE, "
        sqlStr = sqlStr & "@COUNTRY_NAME, "
        sqlStr = sqlStr & "@TYPES_OF_PARTS, "
        sqlStr = sqlStr & "@NON_RETURNABLE_DAMAGE_PARTS, "
        sqlStr = sqlStr & "@COMPTIA_GROUP, "
        sqlStr = sqlStr & "@COMTIA_CODE, "
        sqlStr = sqlStr & "@COMPTIA_MODIFIER, "
        sqlStr = sqlStr & "@MEID, "
        sqlStr = sqlStr & "@PRODUCT_RECEIPT_DATE, "
        sqlStr = sqlStr & "@DATE_MARKED_AS_COMPLETE, "
        sqlStr = sqlStr & "@PURCHASE_DATE, "
        sqlStr = sqlStr & "@TECHNICIAN_NAME, "
        sqlStr = sqlStr & "@BILLED, "
        sqlStr = sqlStr & "@APPLECAREPLUS_CONSUMED, "
        sqlStr = sqlStr & "@WARRANTY_OPTION, "
        sqlStr = sqlStr & "@SHIP_THE_PRODUCT_TO_THE_USER, "



        sqlStr = sqlStr & "@IP_ADDRESS "
        sqlStr = sqlStr & " )"
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", "")) '?????????????????????????
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))



        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PENDING_SHIPMENT", queryParams.PENDING_SHIPMENT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REPAIR_STATUS", queryParams.REPAIR_STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", queryParams.SERIAL_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IMEI_1", queryParams.IMEI_1))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IMEI_2", queryParams.IMEI_2))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO", queryParams.SHIP_TO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNRETURNED_MODULE", queryParams.UNRETURNED_MODULE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INCOMPLETE_REPAIR", queryParams.INCOMPLETE_REPAIR))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REPAIR_NO", queryParams.REPAIR_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REPAIR_CATEGORY", queryParams.REPAIR_CATEGORY))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CREATED_DATE", queryParams.CREATED_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_NAME", queryParams.CUSTOMER_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@RETURN_TRACKING_NO", queryParams.RETURN_TRACKING_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@POP_UPLOADED", queryParams.POP_UPLOADED))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DISPATCH_NO", queryParams.DISPATCH_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SOLD_TO_ACCOUNT", queryParams.SOLD_TO_ACCOUNT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVOICE", queryParams.INVOICE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIPPING_STATUS", queryParams.SHIPPING_STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", queryParams.PART_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DETAILS", queryParams.PART_DETAILS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@WARRANTY_STATUS", queryParams.WARRANTY_STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERVICE_LEVEL_CODE", queryParams.SERVICE_LEVEL_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIPPED", queryParams.SHIPPED))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@NON_RETURNABLE_DAMAGE", queryParams.NON_RETURNABLE_DAMAGE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CONTROL_NO", queryParams.CONTROL_NO))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@RETURN_CODE", queryParams.RETURN_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_NAME", queryParams.PRODUCT_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_DETAIL", queryParams.PRODUCT_DETAIL))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DEPOT_REPAIR_STATUS", queryParams.DEPOT_REPAIR_STATUS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@NOTE", queryParams.NOTE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OTHER_THAN_REPLENISHMENT", queryParams.OTHER_THAN_REPLENISHMENT))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@OS_VERSION", queryParams.OS_VERSION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@RAM", queryParams.RAM))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@HARD_DRIVE", queryParams.HARD_DRIVE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMPANY_NAME", queryParams.COMPANY_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MUNICPALITY", queryParams.MUNICPALITY))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ZIP_CODE", queryParams.ZIP_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PREFECTURES", queryParams.PREFECTURES))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LANGUAGE", queryParams.LANGUAGE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COUNTRY_NAME", queryParams.COUNTRY_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TYPES_OF_PARTS", queryParams.TYPES_OF_PARTS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@NON_RETURNABLE_DAMAGE_PARTS", queryParams.NON_RETURNABLE_DAMAGE_PARTS))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMPTIA_GROUP", queryParams.COMPTIA_GROUP))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMTIA_CODE", queryParams.COMTIA_CODE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COMPTIA_MODIFIER", queryParams.COMPTIA_MODIFIER))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MEID", queryParams.MEID))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_RECEIPT_DATE", queryParams.PRODUCT_RECEIPT_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DATE_MARKED_AS_COMPLETE", queryParams.DATE_MARKED_AS_COMPLETE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PURCHASE_DATE", queryParams.PURCHASE_DATE))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TECHNICIAN_NAME", queryParams.TECHNICIAN_NAME))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BILLED", queryParams.BILLED))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@APPLECAREPLUS_CONSUMED", queryParams.APPLECAREPLUS_CONSUMED))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@WARRANTY_OPTION", queryParams.WARRANTY_OPTION))
        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_THE_PRODUCT_TO_THE_USER", queryParams.SHIP_THE_PRODUCT_TO_THE_USER))

        dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IP_ADDRESS", queryParams.IP_ADDRESS))
        flag = dbConn.ExecSQL(sqlStr)
        dbConn.sqlCmd.Parameters.Clear()
        If flag Then
            dbConn.sqlTrn.Commit()
        Else
            PoNo = "-1"
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()

        Return flag
    End Function

End Class
