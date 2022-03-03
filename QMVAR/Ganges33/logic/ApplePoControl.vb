Imports System
Imports System.Data
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic


Public Class ApplePoControl

    Public Function SelectPoNo(queryParams As ApplePoModel) As String
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
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "MAX(CAST(SUBSTRING(PO_NO, 3, len(PO_NO) - 2) AS int)) AS PO_NO "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PO "
        'sqlStr = sqlStr & "WHERE "
        'sqlStr = sqlStr & "DELFG=0 "
        'If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
        '    sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
        '    dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        'End If
        dt = dbConn.GetDataSet(sqlStr)
        If (dt Is Nothing) Or (dt.Rows.Count = 0) Then
            PoNo = "GA00000001"
        Else
            PoNo = dt.Rows(0)("PO_no").ToString()
            If Trim(PoNo) = "" Then
                PoNo = "GA00000001"
            Else
                'No = Right(PoNo, Len(PoNo) - 2)
                If Int32.TryParse(PoNo, PoNoTmp1) = False Then
                    PoNo = "-1"
                Else
                    PoNoTmp1 = PoNoTmp1 + 1
                    No = Trim(Str(PoNoTmp1))
                    ' PoNoTmp2 = Len(Str(PoNoTmp1))
                    Select Case Len(No)
                        Case 1
                            PoNo = "GA0000000" & No
                        Case 2
                            PoNo = "GA000000" & No
                        Case 3
                            PoNo = "GA00000" & No
                        Case 4
                            PoNo = "GA0000" & No
                        Case 5
                            PoNo = "GA000" & No
                        Case 6
                            PoNo = "GA00" & No
                        Case 7
                            PoNo = "GA0" & No
                        Case Else
                            PoNo = "GA" & No
                            'PoNo = "-1"
                    End Select
                End If

            End If
        End If


        If PoNo <> "-1" Then
            dbConn.sqlCmd.Parameters.Clear()
            sqlStr = "Insert into AP_PO ("
            sqlStr = sqlStr & "CRTDT, "
            sqlStr = sqlStr & "CRTCD, "
            ' sqlStr = sqlStr & "UPDDT, "
            sqlStr = sqlStr & "UPDCD, "
            sqlStr = sqlStr & "UPDPG, "
            sqlStr = sqlStr & "DELFG, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH_CODE, "
            sqlStr = sqlStr & "SHIP_TO_BRANCH, "
            sqlStr = sqlStr & "PO_NO, "
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
            sqlStr = sqlStr & "@PO_NO, "
            sqlStr = sqlStr & "@IP_ADDRESS "
            sqlStr = sqlStr & " )"
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTDT", dtNow))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@CRTCD", queryParams.UserId))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDCD", "")) '?????????????????????????
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@UPDPG", queryParams.UPDPG))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@DELFG", 0))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH", queryParams.SHIP_TO_BRANCH))
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", PoNo))
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

    Public Function PoNoExist(queryParams As ApplePoModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "* "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PO "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If

        If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
            sqlStr = sqlStr & "AND PO_NO = @PO_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        End If

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


    Public Function SelectSummary(queryParams As ApplePoModel) As DataTable
        Dim DateTimeNow As DateTime = DateTime.Now
        Dim dtNow As DateTime = DateTimeNow.AddMinutes(ConfigurationManager.AppSettings("TimeDiff"))
        Dim flag As Boolean = False

        Dim dbConn As DBUtility = New DBUtility()
        Dim dt As DataTable = New DataTable()
        Dim sqlStr As String = "SELECT "
        sqlStr = sqlStr & "* "
        sqlStr = sqlStr & "FROM "
        sqlStr = sqlStr & "AP_PO "
        sqlStr = sqlStr & "WHERE "
        sqlStr = sqlStr & "DELFG=0 "
        If Not String.IsNullOrEmpty(queryParams.SHIP_TO_BRANCH_CODE) Then
            sqlStr = sqlStr & "AND SHIP_TO_BRANCH_CODE = @SHIP_TO_BRANCH_CODE "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@SHIP_TO_BRANCH_CODE", queryParams.SHIP_TO_BRANCH_CODE))
        End If

        If Not String.IsNullOrEmpty(queryParams.PO_NO) Then
            sqlStr = sqlStr & "AND PO_NO = @PO_NO "
            dbConn.sqlCmd.Parameters.Add(CommonControl.GetNullableParameter("@PO_NO", queryParams.PO_NO))
        End If

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
