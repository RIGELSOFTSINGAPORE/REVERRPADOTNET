Imports System.Data.SqlClient
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.logic
Imports Ganges33.Ganges33.model
Public Class PartsIoControl
    Public Function AddModifyPartsIo(ByVal csvData()() As String, queryParams As PartsIoModel) As Boolean
        'Row 0 - Header1 and 1 - Header2
        '0 No
        '1 Branch
        '2 In/Out Date
        '3 Type
        '4 Type Description
        '5 Ref.Doc.No
        '6 Parts No
        '7 Description
        '8 Qty
        '9 MAP
        '10 Engineer Code
        '11 In/Out , Warranty
        '12 Unit

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Mandatory Column 12 from CSV
        Dim flag As Boolean = True
        If csvData(0).Length < 13 Then
            Return False
        End If

        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID & " - PartsIoCtr ")

        '      Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn
        '       Dim flag As Boolean = True
        Dim flagAll As Boolean = True
        Dim sqlStr As String = ""
        Dim dtPartsIoExist As DataTable

        Dim isExist As Integer = 0
        '1st check INVOICE_NO,LOCAL_INVOICE_NO exist in the table 
        sqlStr = "SELECT TOP 1 PARTS_NO FROM PARTS_IO "
        sqlStr = sqlStr & " WHERE DELFG = 0 AND SRC_FILE_NAME='" & queryParams.SrcFileName & "'"
        'sqlStr = sqlStr & " AND SHIP_TO_BRANCH_CODE='" & queryParams.ShipToBranchCode & "'"
        dtPartsIoExist = dbConn.GetDataSet(sqlStr)
        'if exist then need to update delfg=1 then insert the record as new
        If (dtPartsIoExist Is Nothing) Or (dtPartsIoExist.Rows.Count = 0) Then
            'isExist = 0
        Else 'The records is already exist, need to update DELFg=0
            ' isExist = 1
            sqlStr = "UPDATE PARTS_IO SET DELFG=1  "
            sqlStr = sqlStr & "WHERE DELFG=0 "
            sqlStr = sqlStr & "AND SRC_FILE_NAME = @SRC_FILE_NAME"
            'sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SrcFileName))
            flag = dbConn.ExecSQL(sqlStr)
            dbConn.sqlCmd.Parameters.Clear()
            'If Error occurs then will store the flag as false
            If Not flag Then
                flagAll = False
            End If
        End If
        'If there is no error
        If flagAll Then
            For i = 0 To csvData.Length - 1
                If i > 1 Then '0  Header, 1 Header
                    'If isExist = 1 Then
                    sqlStr = "Insert into PARTS_IO ("
                    sqlStr = sqlStr & "CRTDT, "
                    sqlStr = sqlStr & "CRTCD, "
                    ' sqlStr = sqlStr & "UPDDT, "
                    sqlStr = sqlStr & "UPDCD, "
                    sqlStr = sqlStr & "UPDPG, "
                    sqlStr = sqlStr & "DELFG, "
                    '         sqlStr = sqlStr & "UNQ_NO, "
                    sqlStr = sqlStr & "UPLOAD_USER, "
                    sqlStr = sqlStr & "UPLOAD_DATE, "
                    sqlStr = sqlStr & "NO, "
                    sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
                    sqlStr = sqlStr & "SHIP_TO_BRANCH, "
                    sqlStr = sqlStr & "IN_OUT_DATE, "
                    sqlStr = sqlStr & "TYPE, "
                    sqlStr = sqlStr & "TYPE_DESCRIPTION, "
                    sqlStr = sqlStr & "REF_DOC_NO, "
                    sqlStr = sqlStr & "PARTS_NO, "
                    sqlStr = sqlStr & "DESCRIPTION, "
                    sqlStr = sqlStr & "QTY, "
                    sqlStr = sqlStr & "MAP, "
                    sqlStr = sqlStr & "ENGINEER_CODE, "
                    sqlStr = sqlStr & "IN_OUT_WARRANTY, "
                    sqlStr = sqlStr & "UNIT, "
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
                    '         sqlStr = sqlStr & " (select max(UNQ_NO)+1 from G_RECEIVED) , "
                    sqlStr = sqlStr & "@UPLOAD_USER, "
                    sqlStr = sqlStr & "@UPLOAD_DATE, "
                    sqlStr = sqlStr & "@NO, "
                    sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
                    sqlStr = sqlStr & "@SHIP_TO_BRANCH, "
                    sqlStr = sqlStr & "@IN_OUT_DATE, "
                    sqlStr = sqlStr & "@TYPE, "
                    sqlStr = sqlStr & "@TYPE_DESCRIPTION, "
                    sqlStr = sqlStr & "@REF_DOC_NO, "
                    sqlStr = sqlStr & "@PARTS_NO, "
                    sqlStr = sqlStr & "@DESCRIPTION, "
                    sqlStr = sqlStr & "@QTY, "
                    sqlStr = sqlStr & "@MAP, "
                    sqlStr = sqlStr & "@ENGINEER_CODE, "
                    sqlStr = sqlStr & "@IN_OUT_WARRANTY, "
                    sqlStr = sqlStr & "@UNIT, "
                    sqlStr = sqlStr & "@FILE_NAME, "
                    sqlStr = sqlStr & "@SRC_FILE_NAME "
                    sqlStr = sqlStr & " )"
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", "")) '?????????????????????????
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_USER", queryParams.UploadUser))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPLOAD_DATE", dtNow))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@NO", csvData(i)(0)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", csvData(i)(1)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.ShipToBranch))

                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_OUT_DATE", csvData(i)(2)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TYPE", csvData(i)(3)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@TYPE_DESCRIPTION", csvData(i)(4)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@REF_DOC_NO", csvData(i)(5)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PARTS_NO", csvData(i)(6)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DESCRIPTION", csvData(i)(7)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@QTY", csvData(i)(8)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@MAP", csvData(i)(9)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ENGINEER_CODE", csvData(i)(10)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@IN_OUT_WARRANTY", csvData(i)(11)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UNIT", csvData(i)(12)))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FILE_NAME", queryParams.FileName))
                    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SrcFileName))

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
        End If
        If flagAll Then
            flag = True
            dbConn.sqlTrn.Commit()
        Else
            flag = False
            dbConn.sqlTrn.Rollback()
        End If
        dbConn.CloseConnection()
        Return flag

        'Comment on 20190829
        '2nd Way Updation
        '''''''Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        '''''''Dim DateTimeNow As DateTime = DateTime.Now
        '''''''Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        '''''''Dim dbConn As DBUtility = New DBUtility()
        '''''''Dim dt As DataTable = New DataTable()
        '''''''dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction(IsolationLevel.ReadCommitted)
        '''''''dbConn.sqlCmd.Transaction = dbConn.sqlTrn
        '''''''Dim flag As Boolean = True


        '''''''Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("cnstrTmp").ConnectionString)
        '''''''con.Open()        '
        '''''''Dim trn As SqlTransaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        '''''''Dim dt As DateTime
        '''''''Dim csvData()() As String
        '''''''csvData = strArr
        '''''''Try
        '''''''    For i = 0 To csvData.Length - 1
        '''''''        If i <> 0 Then
        '''''''            Dim newData As Integer = -1
        '''''''            Dim add As Integer = -1
        '''''''            Dim select_sql1 As String = ""
        '''''''            select_sql1 = "SELECT * FROM tbl_DomesticWbgtMaxAvg WHERE  "
        '''''''            select_sql1 &= " Region = N'" & csvData(i)(0) & "' "
        '''''''            select_sql1 &= "AND PromotionBureau = N'" & csvData(i)(1) & "' "
        '''''''            select_sql1 &= "AND Prefectures = N'" & csvData(i)(2) & "' "
        '''''''            select_sql1 &= "AND StationNameKanji = N'" & csvData(i)(3) & "' "
        '''''''            select_sql1 &= "AND ReadingHiragana = N'" & csvData(i)(4) & "' "
        '''''''            Dim sqlSelect1 As New SqlCommand(select_sql1, con, trn)
        '''''''            Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
        '''''''            Dim Builder1 As New SqlCommandBuilder(Adapter1)
        '''''''            Dim ds1 As New DataSet
        '''''''            Dim dr1 As DataRow
        '''''''            Adapter1.Fill(ds1)
        '''''''            If ds1.Tables(0).Rows.Count >= 1 Then
        '''''''                dr1 = ds1.Tables(0).Rows(0)
        '''''''                add = 1
        '''''''            Else
        '''''''                dr1 = ds1.Tables(0).NewRow
        '''''''                newData = 1
        '''''''            End If
        '''''''            If newData = 1 Then
        '''''''                dr1("CreateDate") = Now.Date
        '''''''                dr1("UpdateDate") = Now.Date
        '''''''                dr1("Region") = csvData(i)(0)
        '''''''                dr1("PromotionBureau") = csvData(i)(1)
        '''''''                dr1("Prefectures") = csvData(i)(2)
        '''''''                dr1("StationNameKanji") = csvData(i)(3)
        '''''''                dr1("ReadingHiragana") = csvData(i)(4)
        '''''''                dr1("DelFlag") = 0
        '''''''            End If
        '''''''            If add = 1 Then
        '''''''                dr1("UpdateDate") = Now.Date
        '''''''            End If
        '''''''            dr1("Max4") = csvData(i)(5)
        '''''''            dr1("Max5") = csvData(i)(6)
        '''''''            dr1("Max6") = csvData(i)(7)
        '''''''            dr1("Max7") = csvData(i)(8)
        '''''''            dr1("Max8") = csvData(i)(9)
        '''''''            dr1("Max9") = csvData(i)(10)
        '''''''            dr1("Max10") = csvData(i)(11)
        '''''''            dr1("MaxMax") = csvData(i)(12)
        '''''''            dr1("Avg4") = csvData(i)(13)
        '''''''            dr1("Avg5") = csvData(i)(14)
        '''''''            dr1("Avg6") = csvData(i)(15)
        '''''''            dr1("Avg7") = csvData(i)(16)
        '''''''            dr1("Avg8") = csvData(i)(17)
        '''''''            dr1("Avg9") = csvData(i)(18)
        '''''''            dr1("Avg10") = csvData(i)(19)
        '''''''            dr1("AvgMax") = csvData(i)(20)
        '''''''            '
        '''''''            If newData = 1 Then
        '''''''                ds1.Tables(0).Rows.Add(dr1)
        '''''''            End If
        '''''''            Adapter1.Update(ds1)
        '''''''        End If
        '''''''    Next i
        '''''''    trn.Commit()
        '''''''    Status = 0
        '''''''Catch ex As Exception
        '''''''    Status = 2
        '''''''    trn.Rollback()
        '''''''    lblInfo.Text = "<br>Satus: <font color=red>Failed <br>Error: " & ex.Message & " <br> OR <br>Please verify the datas in the CSV file..."
        '''''''Finally
        '''''''    If con.State <> ConnectionState.Closed Then
        '''''''        con.Close()
        '''''''    End If
        '''''''End Try

        ''''''''Unidentified - Ex Data's are matched with table column type
        '''''''If Status = 1 Then
        '''''''    lblInfo.Text = "<br>Status: <font color=red>Please verify the datas in the CSV file...<br>"
        '''''''ElseIf Status = 0 Then
        '''''''    lblInfo.Text = "<br>Status: <font color=Green>Successfully Updated...<br>"
        '''''''End If






    End Function


    Public Function AddModifyPartsIoNew(ByVal csvData()() As String, queryParams As PartsIoModel) As Boolean
        'Row 0 - Header1 and 1 - Header2
        '0 No
        '1 Branch
        '2 In/Out Date
        '3 Type
        '4 Type Description
        '5 Ref.Doc.No
        '6 Parts No
        '7 Description
        '8 Qty
        '9 MAP
        '10 Engineer Code
        '11 In/Out , Warranty
        '12 Unit




        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Return Status 
        Dim flag As Boolean = False
        'Ship Code
        Dim strShipCode As String = ""
        Try
            'Reading ShipCode from database to Datatable 
            Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
            Dim dtShipCode As DataTable = _ShipBaseControl.SelectBranchCode()

            Dim blShipCodeExist As Boolean = False
            Dim strDate As String = ""

            'Define Database 
            Dim DateTimeNow As DateTime = DateTime.Now
            Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
            Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("cnstr").ConnectionString)
            'Open Database

            con.Open()
            Dim trn As SqlTransaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
            Try
                Dim newData As Integer
                Dim add As Integer
                For i = 0 To csvData.Length - 1
                    If i > 1 Then
                        'blShipCodeExist = False
                        '''Ship Code
                        'strShipCode = CommonControl.ConvertShipCode(csvData(i)(0))
                        'blShipCodeExist = CommonControl.CheckDataTable(dtShipCode, Function(x) x("ship_code") = strShipCode)

                        'If blShipCodeExist = False Then
                        '    Log4NetControl.ComErrorLogWrite(strShipCode & " is not exist")
                        '    flag = False
                        '    trn.Rollback()
                        '    Return flag
                        '    Exit Function
                        'End If

                        Dim DtConvTo() As String
                        DtConvTo = Split(csvData(i)(2), "/")
                        If Len(DtConvTo(0)) = 1 Then
                            DtConvTo(0) = "0" & DtConvTo(0)
                        End If
                        If Len(DtConvTo(1)) = 1 Then
                            DtConvTo(1) = "0" & DtConvTo(1)
                        End If
                        strDate = DtConvTo(2) & "/" & DtConvTo(1) & "/" & DtConvTo(0)


                        'Bydefault Assing Zero
                        add = 0
                        newData = 0
                        'Query 
                        'If Record is exit then it will update otherwise it will create new records
                        Dim select_sql1 As String = ""
                        select_sql1 = "SELECT * FROM PARTS_I_O WHERE DELFG = 0 "
                        select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & csvData(i)(1) & "' "
                        select_sql1 &= "AND REF_DOC_NO = '" & csvData(i)(5) & "' "
                        select_sql1 &= "AND PARTS_NO = '" & csvData(i)(6) & "' "
                        select_sql1 &= "AND ENGINEER_CODE = '" & csvData(i)(10) & "' "
                        select_sql1 &= "AND QTY = '" & csvData(i)(8) & "' "
                        select_sql1 &= "AND DESCRIPTION = '" & csvData(i)(7) & "' "
                        select_sql1 &= "AND MAP = '" & csvData(i)(9) & "' "
                        select_sql1 &= "AND TYPE = '" & csvData(i)(3) & "' "
                        select_sql1 &= "AND TYPE_DESCRIPTION = '" & csvData(i)(4) & "' "
                        select_sql1 &= "AND LEFT(CONVERT(VARCHAR, IN_OUT_DATE, 111), 10) = '" & strDate & "' "

                        'Log4NetControl.ComInfoLogWrite(select_sql1)
                        'DataAdpater and DataSet Define
                        Dim sqlSelect1 As New SqlCommand(select_sql1, con, trn)
                        Dim Adapter1 As New SqlDataAdapter(sqlSelect1)
                        Dim Builder1 As New SqlCommandBuilder(Adapter1)
                        Dim ds1 As New DataSet
                        Dim dr1 As DataRow
                        Adapter1.Fill(ds1)
                        'If Record exist update otherwise insert as new record
                        If ds1.Tables(0).Rows.Count = 1 Then
                            dr1 = ds1.Tables(0).Rows(0)
                            add = 1
                        Else
                            dr1 = ds1.Tables(0).NewRow
                            newData = 1
                        End If

                        If newData = 1 Then
                            dr1("CRTDT") = dtNow
                            dr1("CRTCD") = queryParams.UserId
                        End If

                        If add = 1 Then
                            dr1("UPDDT") = dtNow
                            dr1("UPDCD") = queryParams.UserId
                        End If


                        dr1("UPDPG") = "PartsIoControl.vb"
                        dr1("DELFG") = 0
                        dr1("UPLOAD_USER") = queryParams.UploadUser
                        dr1("UPLOAD_DATE") = dtNow

                        dr1("SHIP_TO_BRANCH_CODE") = csvData(i)(1)
                        dr1("SHIP_TO_BRANCH") = queryParams.ShipToBranch

                        'strDate = Left(csvData(i)(2), 4) & "/" & Mid(csvData(i)(2), 5, 2) & "/" & Right(csvData(i)(2), 2)




                        dr1("NO") = csvData(i)(0)
                        dr1("IN_OUT_DATE") = strDate
                        dr1("TYPE") = csvData(i)(3)
                        dr1("TYPE_DESCRIPTION") = csvData(i)(4)
                        dr1("REF_DOC_NO") = csvData(i)(5)
                        dr1("PARTS_NO") = csvData(i)(6)
                        dr1("DESCRIPTION") = csvData(i)(7)
                        dr1("QTY") = csvData(i)(8)
                        dr1("MAP") = csvData(i)(9)
                        dr1("ENGINEER_CODE") = csvData(i)(10)
                        dr1("IN_OUT_WARRANTY") = csvData(i)(11)
                        dr1("UNIT") = csvData(i)(12)
                        dr1("FILE_NAME") = queryParams.FileName
                        dr1("SRC_FILE_NAME") = queryParams.SrcFileName

                        If newData = 1 Then
                            ds1.Tables(0).Rows.Add(dr1)
                        End If
                        Adapter1.Update(ds1)
                    End If
                Next i

                trn.Commit()
                'Transaction Successful, return true
                flag = True
            Catch ex As Exception
                trn.Rollback()
                Log4NetControl.ComErrorLogWrite(ex.ToString())
                'Failure, return as false
                flag = False
            Finally
                If con.State <> ConnectionState.Closed Then
                    con.Close()
                End If
            End Try

        Catch ex As Exception
            flag = False
            Log4NetControl.ComErrorLogWrite(ex.ToString())
        End Try
        'Return Transaction Status 
        Return flag
    End Function
    Public Function SelectPartsIo(ByVal queryParams As PartsIoModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & "DELFG,UNQ_NO,UPLOAD_USER,UPLOAD_DATE,NO,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,IN_OUT_DATE,TYPE,TYPE_DESCRIPTION,REF_DOC_NO,PARTS_NO,DESCRIPTION,QTY,MAP,ENGINEER_CODE,IN_OUT_WARRANTY,UNIT,FILE_NAME,SRC_FILE_NAME"
        sqlStr = sqlStr & "NO,SHIP_TO_BRANCH_CODE as 'Branch',LEFT(CONVERT(VARCHAR, IN_OUT_DATE, 111), 10) as 'In/Out Date',TYPE as 'Type',TYPE_DESCRIPTION as 'Type Description',REF_DOC_NO as 'Ref.Doc.No',PARTS_NO as 'Parts No',DESCRIPTION as 'Description',QTY as 'Qty',MAP as 'MAP',ENGINEER_CODE as 'Engineer Code',IN_OUT_WARRANTY as 'In/Out/Warranty',UNIT as 'Unit'"
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "PARTS_I_O "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.SrcFileName) Then  
        '    sqlStr = sqlStr & "AND SRC_FILE_NAME = @SRC_FILE_NAME " 
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SRC_FILE_NAME", queryParams.SrcFileName))
        'End If

        If Not String.IsNullOrEmpty(queryParams.ShipToBranchCode) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ShipToBranchCode))
        End If
        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, IN_OUT_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, IN_OUT_DATE, 111), 10) <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, IN_OUT_DATE, 111), 10) = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, IN_OUT_DATE, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If


        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
End Class
