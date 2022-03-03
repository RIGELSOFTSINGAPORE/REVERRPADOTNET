Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient

Public Class InvoiceUpdatePdfControl




    Public Function AddModifyInvoiceUpdatePdf(queryParams As InvoiceUpdatePdfModel) As Boolean
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        'Return Status 
        Dim flag As Boolean = False
        'Ship Code
        ' Dim strShipCode As String = ""
        Try
            'Reading ShipCode from database to Datatable 
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
                add = 0
                newData = 0
                'Query 
                'If Record is exit then it will update otherwise it will create new records
                Dim select_sql1 As String = ""
                select_sql1 = "SELECT * FROM INVOICE_UPDATE_PDF WHERE DELFG = 0 "
                select_sql1 &= "AND SHIP_TO_BRANCH_CODE = '" & queryParams.ShipToBranchCode & "' "
                select_sql1 &= "AND REPORT_NO = '" & queryParams.ReportNo & "' "

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
                dr1("UPDPG") = "InvoiceUpdatePdfControl.vb"
                dr1("DELFG") = 0
                dr1("UPLOAD_USER") = queryParams.UploadUser
                dr1("UPLOAD_DATE") = dtNow
                dr1("SHIP_TO_BRANCH_CODE") = queryParams.ShipToBranchCode ''csvData(i)(0)
                dr1("SHIP_TO_BRANCH") = queryParams.ShipToBranch
                dr1("FISCAL_MONTH") = queryParams.FiscalMonth
                dr1("REPORT_NO") = queryParams.ReportNo
                dr1("NUMBER") = queryParams.Number
                dr1("PARTS_INVOICE_NO") = queryParams.PartsInvoiceNo
                dr1("LABOR_INVOICE_NO") = queryParams.LaborInvoiceNo
                dr1("INVOICE_DATE") = queryParams.InvoiceDate
                dr1("FILE_NAME") = queryParams.FileName
                dr1("SRC_FILE_NAME") = queryParams.SrcFileName
                If newData = 1 Then
                    ds1.Tables(0).Rows.Add(dr1)
                End If
                Adapter1.Update(ds1)
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



    Public Function SelectInvoiceUpdatePdf(ByVal queryParams As InvoiceUpdatePdfModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        'sqlStr = sqlStr & "DELFG,UPLOAD_USER,UPLOAD_DATE,SHIP_TO_BRANCH_CODE,SHIP_TO_BRANCH,INVOICE_DATE,INVOICE_NO,LOCAL_INVOICE_NO,DELIVERY_NO,ITEMS,AMOUNT,SGST_UTGST,CGST,IGST,CESS,TAX,TOTAL,GR_STATUS,FILE_NAME "
        sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE as 'Ship-to-Branch-Code',SHIP_TO_BRANCH as 'Ship-to-Branch',FISCAL_MONTH,REPORT_NO,number,PARTS_INVOICE_NO,LABOR_INVOICE_NO,INVOICE_DATE,FILE_NAME,SRC_FILE_NAME "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "INVOICE_UPDATE_PDF "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "

        If Not String.IsNullOrEmpty(queryParams.ShipToBranch) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.ShipToBranchCode))
        End If


        'If Not String.IsNullOrEmpty(queryParams.ReportNo) Then
        '    sqlStr = sqlStr & "AND REPORT_NO = @ReportNo "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@ReportNo", queryParams.ReportNo))
        'End If

        'If Not String.IsNullOrEmpty(queryParams.FiscalMonth) Then
        '    sqlStr = sqlStr & "AND FISCAL_MONTH = @FiscalMonth "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@FiscalMonth", queryParams.FiscalMonth))
        'End If

        If Not String.IsNullOrEmpty(queryParams.Number) Then
            sqlStr = sqlStr & "AND NUMBER = @Number "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@Number", queryParams.Number))
        End If

        If (Not (String.IsNullOrEmpty(queryParams.DateFrom)) And (Not (String.IsNullOrEmpty(queryParams.DateTo)))) Then
            sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) >= @DateFrom and LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) <= @DateTo "
            'sqlStr = sqlStr & "AND INVOICE_DATE >= @DateFrom and INVOICE_DATE <= @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateFrom) Then
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateFrom "
            sqlStr = sqlStr & "AND INVOICE_DATE = @DateFrom "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.DateFrom))
        ElseIf Not String.IsNullOrEmpty(queryParams.DateTo) Then
            sqlStr = sqlStr & "AND INVOICE_DATE = @DateTo "
            'sqlStr = sqlStr & "AND LEFT(CONVERT(VARCHAR, INVOICE_DATE, 111), 10) = @DateTo "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.DateTo))
        End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function
End Class
