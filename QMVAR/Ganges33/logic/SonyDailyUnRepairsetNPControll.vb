﻿Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class SonyDailyUnRepairsetNPControll


    Public Function AddDailyUnRepairsetNPControll(ByVal csvData()() As String, queryParams As SonyDailyUnRepaipairsetNPModel) As Boolean
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)

        Dim flag As Boolean = True
        If csvData(0).Length < 17 Then
            Return False
        End If

        '       Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn
        '       Dim flag As Boolean = True
        Dim flagAll As Boolean = True
        Dim sqlStr As String = ""
        Dim dtSawDiscountExist As DataTable
        Dim strCommaRepl As String = ""

        Dim isExist As Integer = 0
        '1st check COUNTRY
        sqlStr = "SELECT TOP 1 COUNTRY FROM SONY_DAILY_UNREPAIPAIRSET_NP "
        sqlStr = sqlStr & " WHERE DELFG = 0 AND SRC_FILE_NAME='" & queryParams.SRC_FILE_NAME & "'"
        'sqlStr = sqlStr & " AND SHIP_TO_BRANCH_CODE='" & queryParams.ShipToBranchCode & "'"
        dtSawDiscountExist = dbConn.GetDataSet(sqlStr)
        'if exist then need to update delfg=1 then insert the record as new
        If (dtSawDiscountExist Is Nothing) Or (dtSawDiscountExist.Rows.Count = 0) Then
            'isExist = 0
        Else 'The records is already exist, need to update DELFg=0
            ' isExist = 1
            sqlStr = "UPDATE SONY_DAILY_UNREPAIPAIRSET_NP SET DELFG=1  "
            sqlStr = sqlStr & "WHERE DELFG=0 "
            sqlStr = sqlStr & "AND SRC_FILE_NAME = @SRC_FILE_NAME"
            'sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SRC_FILE_NAME))
            flag = dbConn.ExecSQL(sqlStr)
            dbConn.sqlCmd.Parameters.Clear()
            'If Error occurs then will store the flag as false
            If Not flag Then
                flagAll = False
            End If
        End If
        Dim strReplaceText As String

        For i = 0 To csvData.Length - 1
            If i > 0 Then '0  Header
                'If isExist = 1 Then
                sqlStr = "Insert into SONY_DAILY_UNREPAIPAIRSET_NP ("
                sqlStr = sqlStr & "CRTDT, "
                sqlStr = sqlStr & "CRTCD, "
                ' sqlStr = sqlStr & "UPDDT, "
                sqlStr = sqlStr & "UPDCD, "
                sqlStr = sqlStr & "UPDPG, "
                sqlStr = sqlStr & "DELFG, "
                '             sqlStr = sqlStr & "UNQ_NO, "
                sqlStr = sqlStr & "UPLOAD_USER, "
                sqlStr = sqlStr & "UPLOAD_DATE, "
                sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
                sqlStr = sqlStr & "SHIP_TO_BRANCH, "


                sqlStr = sqlStr & "COUNTRY, "
                sqlStr = sqlStr & "SEQ, "
                sqlStr = sqlStr & "REGION, "
                sqlStr = sqlStr & "REGIONName, "
                sqlStr = sqlStr & "ASC_CODE, "
                sqlStr = sqlStr & "ASC_NAME, "
                sqlStr = sqlStr & "JOB_NO, "
                sqlStr = sqlStr & "CUSTOMER_GROUP, "
                sqlStr = sqlStr & "CUSTOMER_NAME, "
                sqlStr = sqlStr & "EMAIL, "
                sqlStr = sqlStr & "LINKMAN, "
                sqlStr = sqlStr & "PHONE, "
                sqlStr = sqlStr & "MOBILE, "
                sqlStr = sqlStr & "ADDRESS, "
                sqlStr = sqlStr & "CITY, "
                sqlStr = sqlStr & "PROVINCE, "
                sqlStr = sqlStr & "POST_CODE, "
                sqlStr = sqlStr & "WARRANTY_TYPE, "
                sqlStr = sqlStr & "WARRANTY_CATEGORY, "
                sqlStr = sqlStr & "SERVICE_TYPE, "
                sqlStr = sqlStr & "PRODUCT_CATEGORY_NAME, "
                sqlStr = sqlStr & "PRODUCT_SUB_CATEGORY_NAME, "
                sqlStr = sqlStr & "SET_MODEL, "
                sqlStr = sqlStr & "MODEL_NAME, "
                sqlStr = sqlStr & "SERIAL_NO, "
                sqlStr = sqlStr & "PURCHASED_SHOP, "
                sqlStr = sqlStr & "PURCHASED_DATE, "
                sqlStr = sqlStr & "RESERVATION_CREATE_DATE, "
                sqlStr = sqlStr & "APPOINTMENT_DATE, "
                sqlStr = sqlStr & "JOB_CREATE_DATE, "
                sqlStr = sqlStr & "PENDING_REPAIR_AGE, "
                sqlStr = sqlStr & "CUSTOMER_REQUIRE_DATE, "
                sqlStr = sqlStr & "JOB_STATUS, "
                sqlStr = sqlStr & "JOB_SUB_STATUS, "
                sqlStr = sqlStr & "TECHNICIAN, "
                sqlStr = sqlStr & "PART_NO, "
                sqlStr = sqlStr & "PART_DESC, "
                sqlStr = sqlStr & "QTY, "
                sqlStr = sqlStr & "PARTCHARGETYPE, "
                sqlStr = sqlStr & "FIRST_ESTIMATION_CREATE_DATE, "
                sqlStr = sqlStr & "LAST_ESTIMATION_DATE, "
                sqlStr = sqlStr & "LATEST_ESTIMATE_STATUS, "
                sqlStr = sqlStr & "PARTS_REQUEST_DATE, "
                sqlStr = sqlStr & "ASC_PO_NUMBER, "
                sqlStr = sqlStr & "ASC_PO_DATE, "
                sqlStr = sqlStr & "SAP_ORDER_NO, "
                sqlStr = sqlStr & "SAP_ORDER_DATE, "
                sqlStr = sqlStr & "PO_STATUS, "
                sqlStr = sqlStr & "NPC_SHIPPING_STATUS, "
                sqlStr = sqlStr & "PART_INVOICE_DATE, "
                sqlStr = sqlStr & "Part_Received_Date, "
                sqlStr = sqlStr & "CR90, "
                sqlStr = sqlStr & "LAST_STATUS_UPDATE_DATE, "
                sqlStr = sqlStr & "LAST_CONTACT_UPDATE_DATE, "
                sqlStr = sqlStr & "D4, "
                sqlStr = sqlStr & "D6, "
                sqlStr = sqlStr & "D6_DESC, "
                sqlStr = sqlStr & "D4_Desc, "
                sqlStr = sqlStr & "St_type, "
                sqlStr = sqlStr & "Part_6D, "
                sqlStr = sqlStr & "FIRST_ALLOCATION_DATE, "
                sqlStr = sqlStr & "LAST_ALLOCATION_DATE, "
                sqlStr = sqlStr & "BEGIN_REPAIR_DATE, "
                sqlStr = sqlStr & "SRPC_PO_No, "
                sqlStr = sqlStr & "Carton_NO, "
                sqlStr = sqlStr & "Call_Customer, "
                sqlStr = sqlStr & "Customer_Complaint, "
                sqlStr = sqlStr & "Symptom_Confirmed_By_Technician, "
                sqlStr = sqlStr & "Condition_of_Set, "
                sqlStr = sqlStr & "GUARANTEE_CODE, "




                sqlStr = sqlStr & "FILE_NAME, "
                sqlStr = sqlStr & "SRC_FILE_NAME "
                sqlStr = sqlStr & " ) "
                sqlStr = sqlStr & " values ( "
                sqlStr = sqlStr & "@CRTDT, "
                sqlStr = sqlStr & "@CRTCD, "
                'sqlStr = sqlStr & "@UPDDT, "
                sqlStr = sqlStr & "@UPDCD, "
                sqlStr = sqlStr & "@UPDPG, "
                sqlStr = sqlStr & "@DELFG, "
                '              sqlStr = sqlStr & " (select max(UNQ_NO)+1 from SAW_DISCOUNT) , "
                sqlStr = sqlStr & "@UPLOAD_USER, "
                sqlStr = sqlStr & "@UPLOAD_DATE, "
                sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
                sqlStr = sqlStr & "@SHIP_TO_BRANCH, "


                sqlStr = sqlStr & "@COUNTRY, "
                sqlStr = sqlStr & "@SEQ, "
                sqlStr = sqlStr & "@REGION, "
                sqlStr = sqlStr & "@REGIONName, "
                sqlStr = sqlStr & "@ASC_CODE, "
                sqlStr = sqlStr & "@ASC_NAME, "
                sqlStr = sqlStr & "@JOB_NO, "
                sqlStr = sqlStr & "@CUSTOMER_GROUP, "
                sqlStr = sqlStr & "@CUSTOMER_NAME, "
                sqlStr = sqlStr & "@EMAIL, "
                sqlStr = sqlStr & "@LINKMAN, "
                sqlStr = sqlStr & "@PHONE, "
                sqlStr = sqlStr & "@MOBILE, "
                sqlStr = sqlStr & "@ADDRESS, "
                sqlStr = sqlStr & "@CITY, "
                sqlStr = sqlStr & "@PROVINCE, "
                sqlStr = sqlStr & "@POST_CODE, "
                sqlStr = sqlStr & "@WARRANTY_TYPE, "
                sqlStr = sqlStr & "@WARRANTY_CATEGORY, "
                sqlStr = sqlStr & "@SERVICE_TYPE, "
                sqlStr = sqlStr & "@PRODUCT_CATEGORY_NAME, "
                sqlStr = sqlStr & "@PRODUCT_SUB_CATEGORY_NAME, "
                sqlStr = sqlStr & "@SET_MODEL, "
                sqlStr = sqlStr & "@MODEL_NAME, "
                sqlStr = sqlStr & "@SERIAL_NO, "
                sqlStr = sqlStr & "@PURCHASED_SHOP, "
                sqlStr = sqlStr & "@PURCHASED_DATE, "
                sqlStr = sqlStr & "@RESERVATION_CREATE_DATE, "
                sqlStr = sqlStr & "@APPOINTMENT_DATE, "
                sqlStr = sqlStr & "@JOB_CREATE_DATE, "
                sqlStr = sqlStr & "@PENDING_REPAIR_AGE, "
                sqlStr = sqlStr & "@CUSTOMER_REQUIRE_DATE, "
                sqlStr = sqlStr & "@JOB_STATUS, "
                sqlStr = sqlStr & "@JOB_SUB_STATUS, "
                sqlStr = sqlStr & "@TECHNICIAN, "
                sqlStr = sqlStr & "@PART_NO, "
                sqlStr = sqlStr & "@PART_DESC, "
                sqlStr = sqlStr & "@QTY, "
                sqlStr = sqlStr & "@PARTCHARGETYPE, "
                sqlStr = sqlStr & "@FIRST_ESTIMATION_CREATE_DATE, "
                sqlStr = sqlStr & "@LAST_ESTIMATION_DATE, "
                sqlStr = sqlStr & "@LATEST_ESTIMATE_STATUS, "
                sqlStr = sqlStr & "@PARTS_REQUEST_DATE, "
                sqlStr = sqlStr & "@ASC_PO_NUMBER, "
                sqlStr = sqlStr & "@ASC_PO_DATE, "
                sqlStr = sqlStr & "@SAP_ORDER_NO, "
                sqlStr = sqlStr & "@SAP_ORDER_DATE, "
                sqlStr = sqlStr & "@PO_STATUS, "
                sqlStr = sqlStr & "@NPC_SHIPPING_STATUS, "
                sqlStr = sqlStr & "@PART_INVOICE_DATE, "
                sqlStr = sqlStr & "@Part_Received_Date, "
                sqlStr = sqlStr & "@CR90, "
                sqlStr = sqlStr & "@LAST_STATUS_UPDATE_DATE, "
                sqlStr = sqlStr & "@LAST_CONTACT_UPDATE_DATE, "
                sqlStr = sqlStr & "@D4, "
                sqlStr = sqlStr & "@D6, "
                sqlStr = sqlStr & "@D6_DESC, "
                sqlStr = sqlStr & "@D4_Desc, "
                sqlStr = sqlStr & "@St_type, "
                sqlStr = sqlStr & "@Part_6D, "
                sqlStr = sqlStr & "@FIRST_ALLOCATION_DATE, "
                sqlStr = sqlStr & "@LAST_ALLOCATION_DATE, "
                sqlStr = sqlStr & "@BEGIN_REPAIR_DATE, "
                sqlStr = sqlStr & "@SRPC_PO_No, "
                sqlStr = sqlStr & "@Carton_NO, "
                sqlStr = sqlStr & "@Call_Customer, "
                sqlStr = sqlStr & "@Customer_Complaint, "
                sqlStr = sqlStr & "@Symptom_Confirmed_By_Technician, "
                sqlStr = sqlStr & "@Condition_of_Set, "
                sqlStr = sqlStr & "@GUARANTEE_CODE, "


                sqlStr = sqlStr & "@FILE_NAME, "
                sqlStr = sqlStr & "@SRC_FILE_NAME "
                sqlStr = sqlStr & " )"
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", "")) '?????????????????????????
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_USER", queryParams.UPLOAD_USER))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_DATE", dtNow))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
                strReplaceText = Trim(Replace(csvData(i)(0), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@COUNTRY", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(1), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SEQ", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(2), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REGION", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(3), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REGIONName", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(4), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ASC_CODE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(5), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ASC_NAME", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(6), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@JOB_NO", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(7), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_GROUP", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(8), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_NAME", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(9), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@EMAIL", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(10), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LINKMAN", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(11), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PHONE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(12), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MOBILE", strReplaceText))

                'Modified on 20210723
                strCommaRepl = Trim(csvData(i)(13))
                strCommaRepl = Replace(strCommaRepl, """", "")
                strCommaRepl = Replace(strCommaRepl, ",", " ")
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ADDRESS", strCommaRepl))
                strReplaceText = Trim(Replace(csvData(i)(14), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CITY", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(15), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PROVINCE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(16), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@POST_CODE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(17), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@WARRANTY_TYPE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(18), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@WARRANTY_CATEGORY", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(19), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERVICE_TYPE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(20), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_CATEGORY_NAME", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(21), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PRODUCT_SUB_CATEGORY_NAME", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(22), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SET_MODEL", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(23), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MODEL_NAME", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(24), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SERIAL_NO", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(25), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PURCHASED_SHOP", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(26), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PURCHASED_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(27), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@RESERVATION_CREATE_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(28), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@APPOINTMENT_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(29), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@JOB_CREATE_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(30), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PENDING_REPAIR_AGE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(31), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CUSTOMER_REQUIRE_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(32), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@JOB_STATUS", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(33), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@JOB_SUB_STATUS", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(34), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TECHNICIAN", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(35), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_NO", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(36), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_DESC", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(37), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@QTY", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(38), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTCHARGETYPE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(39), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FIRST_ESTIMATION_CREATE_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(40), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_ESTIMATION_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(41), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LATEST_ESTIMATE_STATUS", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(42), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_REQUEST_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(43), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ASC_PO_NUMBER", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(44), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ASC_PO_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(45), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SAP_ORDER_NO", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(46), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SAP_ORDER_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(47), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_STATUS", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(48), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@NPC_SHIPPING_STATUS", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(49), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PART_INVOICE_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(50), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Part_Received_Date", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(51), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CR90", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(52), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_STATUS_UPDATE_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(53), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_CONTACT_UPDATE_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(54), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@D4", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(55), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@D6", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(56), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@D6_DESC", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(57), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@D4_Desc", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(58), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@St_type", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(59), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Part_6D", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(60), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FIRST_ALLOCATION_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(61), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@LAST_ALLOCATION_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(62), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@BEGIN_REPAIR_DATE", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(63), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRPC_PO_No", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(64), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Carton_NO", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(65), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Call_Customer", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(66), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Customer_Complaint", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(67), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Symptom_Confirmed_By_Technician", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(68), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Condition_of_Set", strReplaceText))
                strReplaceText = Trim(Replace(csvData(i)(69), """", ""))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@GUARANTEE_CODE", strReplaceText))



                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FILE_NAME", queryParams.FILE_NAME))
                dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SRC_FILE_NAME))

                flag = dbConn.ExecSQL(sqlStr)
                dbConn.sqlCmd.Parameters.Clear()
                'If Error occurs then will store the flag as false
                If Not flag Then
                    flagAll = False
                    Exit For
                End If
                'End If
            End If 'Other than header - End
        Next
        If flagAll Then
            flag = True
            dbConn.sqlTrn.Commit()
        Else
            flag = False
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()
        Return flag
    End Function

    Public Function SelectDailyUnRepairsetNPControll(ByVal queryParams As SonyDailyUnRepaipairsetNPModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "Country as 'Country', SEQ as 'SEQ', REGION as 'REGION', REGIONName as 'REGIONName', ASC_CODE as 'ASC_CODE', ASC_NAME as 'ASC_NAME', JOB_NO as 'JOB_NO', CUSTOMER_GROUP as 'CUSTOMER_GROUP', CUSTOMER_NAME as 'CUSTOMER_NAME', EMAIL as 'EMAIL', LINKMAN as 'LINKMAN', PHONE as 'PHONE', MOBILE as 'MOBILE', ADDRESS as 'ADDRESS', CITY as 'CITY', PROVINCE as 'PROVINCE', POST_CODE as 'POST_CODE', WARRANTY_TYPE as 'WARRANTY_TYPE', WARRANTY_CATEGORY as 'WARRANTY_CATEGORY', SERVICE_TYPE as 'SERVICE_TYPE', PRODUCT_CATEGORY_NAME as 'PRODUCT_CATEGORY_NAME', PRODUCT_SUB_CATEGORY_NAME as 'PRODUCT_SUB_CATEGORY_NAME', SET_MODEL as 'SET_MODEL', MODEL_NAME as 'MODEL_NAME', SERIAL_NO as 'SERIAL_NO', PURCHASED_SHOP as 'PURCHASED_SHOP', PURCHASED_DATE as 'PURCHASED_DATE', RESERVATION_CREATE_DATE as 'RESERVATION_CREATE_DATE', APPOINTMENT_DATE as 'APPOINTMENT_DATE', JOB_CREATE_DATE as 'JOB_CREATE_DATE', PENDING_REPAIR_AGE as 'PENDING_REPAIR_AGE', CUSTOMER_REQUIRE_DATE as 'CUSTOMER_REQUIRE_DATE', JOB_STATUS as 'JOB_STATUS', JOB_SUB_STATUS as 'JOB_SUB_STATUS', TECHNICIAN as 'TECHNICIAN', PART_NO as 'PART_NO', PART_DESC as 'PART_DESC', QTY as 'QTY', PARTCHARGETYPE as 'PARTCHARGETYPE', FIRST_ESTIMATION_CREATE_DATE as 'FIRST_ESTIMATION_CREATE_DATE', LAST_ESTIMATION_DATE as 'LAST_ESTIMATION_DATE', LATEST_ESTIMATE_STATUS as 'LATEST_ESTIMATE_STATUS', PARTS_REQUEST_DATE as 'PARTS_REQUEST_DATE', ASC_PO_NUMBER as 'ASC_PO_NUMBER', ASC_PO_DATE as 'ASC_PO_DATE', SAP_ORDER_NO as 'SAP_ORDER_NO', SAP_ORDER_DATE as 'SAP_ORDER_DATE', PO_STATUS as 'PO_STATUS', NPC_SHIPPING_STATUS as 'NPC_SHIPPING_STATUS', PART_INVOICE_DATE as 'PART_INVOICE_DATE', Part_Received_Date as 'Part_Received_Date', CR90 as 'CR90', LAST_STATUS_UPDATE_DATE as 'LAST_STATUS_UPDATE_DATE', LAST_CONTACT_UPDATE_DATE as 'LAST_CONTACT_UPDATE_DATE', D4 as '4D', D6 as '6D', D6_DESC as '6D_DESC', D4_Desc as '4D Desc', St_type as 'St_type', Part_6D as 'Part 6D', FIRST_ALLOCATION_DATE as 'FIRST_ALLOCATION_DATE', LAST_ALLOCATION_DATE as 'LAST_ALLOCATION_DATE', BEGIN_REPAIR_DATE as 'BEGIN_REPAIR_DATE', SRPC_PO_No as 'SRPC_PO_No', Carton_NO as 'Carton_NO', Call_Customer as 'Call Customer', Customer_Complaint as 'Customer_Complaint', Symptom_Confirmed_By_Technician as 'Symptom_Confirmed_By_Technician', Condition_of_Set as 'Condition Of Set', GUARANTEE_CODE as 'GUARANTEE_CODE' "
                sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "SONY_DAILY_UNREPAIPAIRSET_NP "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If

        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH = @SHIP_TO_BRANCH "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
        End If

        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, CRTDT, 111), 10) <= @DateTo "
            'sqlStr = sqlStr & "AND INVOICE_DATE >= @DateFrom and INVOICE_DATE <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateFrom "
            sqlStr = sqlStr & "AND CRTDT = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND CRTDT = @DateTo "
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function



End Class
