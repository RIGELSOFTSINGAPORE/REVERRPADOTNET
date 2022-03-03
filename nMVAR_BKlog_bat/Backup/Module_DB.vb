Module Module1
    Public cnsqlclient As New System.Data.SqlClient.SqlConnection
    Public source1, catalog1, source2, catalog2 As String

    Public Function DB_INIT()
        'Dim sr As System.io.StreamReader = New System.IO.StreamReader("nQGCare.ini")
        Dim sr As System.io.StreamReader = New System.IO.StreamReader("nMVAR.ini")
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
                Select Case line_key
                    Case Is = "source"
                        source1 = Mid(line, eq_pos + 1, line_len - eq_pos)
                    Case Is = "catalog"
                        catalog1 = Mid(line, eq_pos + 1, line_len - eq_pos)
                    Case Is = "source2"
                        source2 = Mid(line, eq_pos + 1, line_len - eq_pos)
                    Case Is = "catalog2"
                        catalog2 = Mid(line, eq_pos + 1, line_len - eq_pos)
                End Select
            End If
        Loop Until line Is Nothing
        sr.Close()
    End Function

    Public Function DB_OPEN(ByVal file) As Boolean
        DB_OPEN = False

        '*****  接続文字列を作成して接続を開始する  *****
        Select Case file
            Case Is = "nMVAR"
                cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source1 & ";persist security info=False;initial catalog=" & catalog1
            Case Is = "QGCare"
                cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source2 & ";persist security info=False;initial catalog=" & catalog2
        End Select

        Try
            '*****  Connectionが接続されているかチェック  *****
            If cnsqlclient.State = ConnectionState.Closed Then
                cnsqlclient.Open()
            End If
        Catch
            'MsgBox(Err.Description, 16, "接続エラー")
            DB_OPEN = False
            Exit Function
        End Try

        DB_OPEN = True
    End Function

    Public Sub DB_CLOSE()
        cnsqlclient.Close()     '接続を終了する
    End Sub
End Module
