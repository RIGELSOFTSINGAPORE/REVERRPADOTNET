Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Data.SqlClient
Public Class ApplePartsInventoryControl


    Public Function SelectInventoryNo(queryParams As ApplePartsInventoryModel) As String
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = True
        Dim InventoryNo As String = ""
        Dim No As String = ""
        Dim PoNo As String = ""



        Dim PoNoTmp1 As Integer = 0
        Dim PoNoTmp2 As Integer = 0
        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        dbConn.sqlTrn = dbConn.sqlConn.BeginTransaction()
        dbConn.sqlCmd.Transaction = dbConn.sqlTrn
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "MAX(CAST(SUBSTRING(INVENTORY_NO, 5, len(INVENTORY_NO) - 4) AS int)) AS INVENTORY_NO "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AC_PARTS_INVENTORY "
        'sqlStr = sqlStr & "WHERE "
        'sqlStr = sqlStr & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
        '    sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        'End If
        dt = dbConn.GetDataSet(sqlStr)
        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
            PoNo = "Y21-1001"
        Else
            PoNo = dt.Rows(0)("INVENTORY_NO").ToString()
            If Trim(PoNo) = "" Then
                PoNo = "Y21-1001"
            Else
                'No = Right(PoNo, Len(PoNo) - 2)
                If Int32.TryParse(PoNo, PoNoTmp1) = False Then
                    PoNo = "-1"
                Else
                    PoNoTmp1 = PoNoTmp1 + 1
                    No = Trim(Str(PoNoTmp1))
                    PoNo = "Y21-" & No
                    'Select Case Len(No)
                    '        Case 1
                    '            PoNo = "GA0000000" & No
                    '        Case 2
                    '            PoNo = "GA000000" & No
                    '        Case 3
                    '            PoNo = "GA00000" & No
                    '        Case 4
                    '            PoNo = "GA0000" & No
                    '        Case 5
                    '            PoNo = "GA000" & No
                    '        Case 6
                    '            PoNo = "GA00" & No
                    '        Case 7
                    '            PoNo = "GA0" & No
                    '        Case Else
                    '            PoNo = "GA" & No
                    '            'PoNo = "-1"
                    '    End Select
                End If

            End If
        End If


        If PoNo <> "-1" Then
            dbConn.sqlCmd.Parameters.Clear()
            sqlStr = "Insert into AC_PARTS_INVENTORY ("
            sqlStr = sqlStr & "CRTDT, "
            sqlStr = sqlStr & "CRTCD, "
            sqlStr = sqlStr & "UPDDT, "
            sqlStr = sqlStr & "UPDCD, "
            sqlStr = sqlStr & "UPDPG, "
            sqlStr = sqlStr & "DELFG, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH, "

            sqlStr = sqlStr & "INVENTORY_NO, "
            sqlStr = sqlStr & "INVENTORY_DATE, "
            sqlStr = sqlStr & "EDIT_MODE, "
            sqlStr = sqlStr & "IP_ADDRESS "
            sqlStr = sqlStr & " ) "
            sqlStr = sqlStr & " values ( "
            sqlStr = sqlStr & "@CRTDT, "
            sqlStr = sqlStr & "@CRTCD, "
            sqlStr = sqlStr & "@UPDDT, "
            sqlStr = sqlStr & "@UPDCD, "
            sqlStr = sqlStr & "@UPDPG, "
            sqlStr = sqlStr & "@DELFG, "
            '         sqlStr = sqlStr & " (select max(UNQ_NO)+1 from G_RECEIVED) , "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "@SHIP_TO_BRANCH, "

            sqlStr = sqlStr & "@INVENTORY_NO, "
            sqlStr = sqlStr & "@INVENTORY_DATE, "
            sqlStr = sqlStr & "@EDIT_MODE, "
            sqlStr = sqlStr & "@IP_ADDRESS "
            sqlStr = sqlStr & " )"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDDT", dtNow)) '?????????????????????????
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", queryParams.UserId)) '?????????????????????????
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))

            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", PoNo))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.INVENTORY_DATE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@EDIT_MODE", 0))
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
        Else
            'Incase of PoNo = -1
            dbConn.CloseConnection()
        End If
        Return PoNo
    End Function


    Public Function SelectInventoryEdit(queryParams As ApplePartsInventoryModel) As DataTable
        Log4NetControl.ComInfoLogWrite(Log4NetControl.UserID)
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "INVENTORY_NO "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AC_PARTS_INVENTORY "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        sqlStr = sqlStr & "AND EDIT_MODE=0 "
        If Not String.IsNullOrEmpty(queryParams.INVENTORY_NO) Then
            sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.INVENTORY_NO))
        End If
        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable
    End Function


    Public Function GetInventry(queryParams As ApplePartsInventoryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        ' sqlStr = sqlStr & ""

        sqlStr = sqlStr & "INVENTORY_NO,FORMAT(INVENTORY_DATE, 'yyyy/MM/dd') as INVENTORY_DATE,FORMAT(UPDDT, 'yyyy/MM/dd') as UPDDT "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AC_PARTS_INVENTORY "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If

        If Not ((String.IsNullOrEmpty(queryParams.inventry_date_from)) And (String.IsNullOrEmpty(queryParams.inventry_date))) Then
            sqlStr = sqlStr & "AND INVENTORY_DATE between @DateFrom and @DateTo"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateFrom", queryParams.inventry_date_from))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DateTo", queryParams.inventry_date))
            '''''' End If
            ''
        End If
        'If Not String.IsNullOrEmpty(queryParams.inventry_date) Then
        sqlStr = sqlStr & " order by INVENTORY_NO desc "
        'dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_DATE", queryParams.inventry_date))
        '    End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)



        dbConn.CloseConnection()
        Return _DataTable

        'dt = dbConn.GetDataSet(sqlStr)
        'dbConn.CloseConnection()
        'If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
        '    flag = False
        'Else
        '    'PoNo = dt.Rows(0)("PO_no").ToString()
        '    flag = True
        'End If
        'Return flag

    End Function

    Public Function GetpartsEntry(queryParams As ApplePartsInventoryModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        ' sqlStr = sqlStr & ""

        sqlStr = sqlStr & "ROW_NUMBER() OVER (ORDER BY INVENTORY_NO) RowNumber,PART_NO,UPC_EAN,DESCRIPTION,BALANCE,PURCHASE_PRICE,IN_STOCK,SALES_PRICE,FORMAT(INVENTORY_DATE, 'yyyy/MM/dd') as INVENTORY_DATE,SAP_PART_DESCRIPTION,PART_TAX "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AC_PARTS_ENTRY "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.inventry_no) Then
            sqlStr = sqlStr & "AND INVENTORY_NO = @INVENTORY_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@INVENTORY_NO", queryParams.inventry_no))
        End If

        'If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
        '    sqlStr = sqlStr & "AND PO_NO = @PO_NO "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        'End If

        Dim _DataTable As DataTable = dbConn.GetDataSet(sqlStr)
        dbConn.CloseConnection()
        Return _DataTable

        'dt = dbConn.GetDataSet(sqlStr)
        'dbConn.CloseConnection()
        'If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
        '    flag = False
        'Else
        '    'PoNo = dt.Rows(0)("PO_no").ToString()
        '    flag = True
        'End If
        'Return flag

    End Function
End Class
