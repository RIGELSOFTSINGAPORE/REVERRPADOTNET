Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient

Public Class ApplePriceControl


    Public Function AddModifyPriceUpdate(ByVal csvData()() As String, queryParams As ApplePriceModel) As String
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Return Status 
        Dim flag As Boolean = False
        'Ship Code
        ' Dim strShipCode As String = ""
        'Dim strShip As String = ""

        Dim finalStatus As String = ""
        Dim LastUpdatedRecord As String = ""



        Try
            'Reading ShipCode from database to Datatable 
            Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
            ' Dim dtShipCode As DataTable = _ShipBaseControl.SelectBranchCode()

            Dim blShipCodeExist As Boolean = False
            Dim strDate As String = ""

            Dim ProductName As String = ""
            Dim _ProductName As String = ""

            Dim PartsDetail As String = ""
            Dim _PartsDetail As String = ""


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

                    ' If i <> 0 Then
                    blShipCodeExist = False
                    ''Ship Code
                    'strShipCode = CommonControl.ConvertShipCode(csvData(i)(0))
                    'blShipCodeExist = CommonControl.CheckDataTable(dtShipCode, Function(x) x("ship_code") = strShipCode)

                    'If blShipCodeExist = False Then
                    '    Log4NetControl.ComErrorLogWrite(strShipCode & " is not exist")
                    '    flag = False
                    '    trn.Rollback()
                    '    Return flag
                    '    Exit Function
                    'End If



                    'Bydefault Assing Zero
                    ProductName = csvData(i)(0)
                    _ProductName = Replace(ProductName, "'", "")

                    PartsDetail = csvData(i)(2)
                    _PartsDetail = Replace(PartsDetail, "'", "")

                    add = 0
                    newData = 0
                    'Query 
                    'If Record is exit then it will update otherwise it will create new records
                    Dim select_sql1 As String = ""
                    select_sql1 = "Select * FROM AP_PARTS WHERE DELFG = 0 "
                    select_sql1 &= "And SHIP_TO_BRANCH_CODE = '" & queryParams.ShipToBranchCode & "' "
                    select_sql1 &= "AND SHIP_TO_BRANCH = '" & queryParams.ShipToBranch & "' "
                    select_sql1 &= "And PRICE_OPTION = '" & queryParams.PriceOption & "' "

                    select_sql1 &= "AND PRODUCT_NAME = '" & _ProductName & "' "
                    select_sql1 &= "And PARTS_NO = '" & csvData(i)(1) & "' "
                    select_sql1 &= "And PARTS_DETAIL = '" & _PartsDetail & "' "

                    'PRODUCT_NAME, PARTS_NO, PARTS_DETAIL, PART_TAX_PERCENTAGE, PRICE_COST
                    'PRODUCT_NAME, PARTS_NO, PARTS_DETAIL, PART_TAX_PERCENTAGE, SALES_PRICE


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
                        dr1("UPDDT") = dtNow
                        dr1("UPDCD") = queryParams.UserId
                    End If

                    If add = 1 Then
                        dr1("UPDDT") = dtNow
                        dr1("UPDCD") = queryParams.UserId
                    End If


                    dr1("UPDPG") = "ApplePriceControl.vb"
                    dr1("DELFG") = 0
                    dr1("UPLOAD_USER") = queryParams.UploadUser
                    dr1("UPLOAD_DATE") = dtNow

                    dr1("SHIP_TO_BRANCH_CODE") = queryParams.ShipToBranchCode ''csvData(i)(0)
                    dr1("SHIP_TO_BRANCH") = queryParams.ShipToBranch

                    strDate = Left(csvData(i)(2), 4) & "/" & Mid(csvData(i)(2), 5, 2) & "/" & Right(csvData(i)(2), 2)

                    dr1("PRODUCT_NAME") = _ProductName
                    dr1("PARTS_NO") = csvData(i)(1)
                    dr1("PARTS_DETAIL") = _PartsDetail
                    dr1("PRICE_OPTION") = queryParams.PriceOption

                    LastUpdatedRecord = "Row=" & i & "  PRODUCT_NAME=" & csvData(i)(0) & "  PARTS_NO=" & csvData(i)(1) & "  PARTS_DETAIL=" & csvData(i)(2)

                    Dim PartTaxPercentage As Decimal = 0.00
                    If Trim(csvData(i)(3)) <> "" Then
                        If Decimal.TryParse(csvData(i)(3), PartTaxPercentage) Then
                            dr1("PART_TAX_PERCENTAGE") = csvData(i)(3)
                            Dim PartTax As Decimal = 0.00
                            If Trim(csvData(i)(3)) <> "" Then
                                If Decimal.TryParse(csvData(i)(3), PartTax) Then
                                    PartTax = PartTax * 100 / 2
                                Else
                                    PartTax = 9
                                End If
                            End If
                            dr1("PART_TAX") = Replace(PartTax, ".00", "")
                        Else
                            'No Need to update for N/A
                        End If
                    End If












                    If queryParams.PriceType = "PRICE_COST" Then
                        Dim PriceCostAmount As Decimal = 0.00
                        If Trim(csvData(i)(4)) <> "" Then
                            If Decimal.TryParse(csvData(i)(4), PriceCostAmount) Then
                                dr1("PRICE_COST") = csvData(i)(4)
                            Else
                                'If Empty No need to update
                            End If
                        End If
                    ElseIf queryParams.PriceType = "SALES_PRICE" Then
                        Dim SalesPriceAmount As Decimal = 0.00
                        If Trim(csvData(i)(4)) <> "" Then
                            If Decimal.TryParse(csvData(i)(4), SalesPriceAmount) Then
                                dr1("SALES_PRICE") = csvData(i)(4)
                            Else
                                'If Empty No need to update
                            End If
                        End If
                    ElseIf queryParams.PriceType = "Both" Then
                        Dim PriceCostAmount As Decimal = 0.00
                        If Trim(csvData(i)(4)) <> "" Then
                            If Decimal.TryParse(csvData(i)(4), PriceCostAmount) Then
                                dr1("PRICE_COST") = csvData(i)(4)
                            Else
                                'If Empty No need to update
                            End If
                        End If
                        Dim SalesPriceAmount As Decimal = 0.00
                        If Trim(csvData(i)(5)) <> "" Then
                            If Decimal.TryParse(csvData(i)(5), SalesPriceAmount) Then
                                dr1("SALES_PRICE") = csvData(i)(5)
                            Else
                                'If Empty No need to update
                            End If
                        End If
                    End If


                    dr1("FILE_NAME") = queryParams.FileName
                    dr1("SRC_FILE_NAME") = queryParams.SrcFileName

                    If newData = 1 Then
                        ds1.Tables(0).Rows.Add(dr1)
                    End If

                    Adapter1.Update(ds1)
                    ' End If

                Next i

                trn.Commit()
                finalStatus = "0," & LastUpdatedRecord
                'Transaction Successful, return true
                flag = True
            Catch ex As Exception
                finalStatus = "1," & LastUpdatedRecord & "=====>" & ex.ToString()
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
            finalStatus = "1," & LastUpdatedRecord & "=====>" & ex.ToString()
            Log4NetControl.ComErrorLogWrite(ex.ToString())
        End Try
        'Return Transaction Status 
        Return finalStatus
    End Function




End Class
