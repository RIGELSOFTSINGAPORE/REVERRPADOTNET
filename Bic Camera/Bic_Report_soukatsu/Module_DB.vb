Module Module_DB
    Public cnsqlclient As New System.Data.SqlClient.SqlConnection
    Public source(2) As String
    Public catalog(2) As String

    Public Sub DB_INIT()
        Call DB_INIT_sub(1)
        Call DB_INIT_sub(2)
    End Sub

    Sub DB_INIT_sub(ByVal seq As Integer)
        Dim sr As System.IO.StreamReader
        Select Case seq
            Case Is = 1
                sr = New System.IO.StreamReader("bicdb.ini")
            Case Is = 2
                sr = New System.IO.StreamReader("bicdb_WK.ini")
        End Select

        Dim line As String
        Dim line_len As Integer
        Dim eq_pos As Integer
        Dim line_key As String
        Do
            line = sr.ReadLine()
            line_len = Len(line)
            If line_len = 0 Then
            Else
                eq_pos = InStr(1, line, "=", 1)
                line_key = Mid(line, 1, eq_pos - 1)
                If line_key = "source" Then
                    source(seq) = Mid(line, eq_pos + 1, line_len - eq_pos)
                End If
                If line_key = "catalog" Then
                    catalog(seq) = Mid(line, eq_pos + 1, line_len - eq_pos)
                End If
            End If
        Loop Until line Is Nothing
        sr.Close()
    End Sub

    Public Function DB_OPEN(ByVal file As String) As Boolean
        DB_OPEN = False

        '*****  接続文字列を作成して接続を開始する  *****
        Select Case file
            Case Is = "bicdb"
                cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source(1) & ";" &
                                               "persist security info=False;Connection Timeout=1000000;initial catalog=" & catalog(1)
            Case Is = "bicdb_WK"
                cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source(2) & ";" &
                                               "persist security info=False;Connection Timeout=1000000;initial catalog=" & catalog(2)
        End Select

        Try
            '*****  Connectionが接続されているかチェック  *****
            If cnsqlclient.State = ConnectionState.Closed Then
                cnsqlclient.Open()
            End If
        Catch
            MsgBox(Err.Description, 16, "接続エラー")
            DB_OPEN = False
            Exit Function
        End Try

        DB_OPEN = True
    End Function

    Public Sub DB_CLOSE()
        '接続を終了する
        cnsqlclient.Close()
    End Sub
End Module
