Module Module1
    Public cnsqlclient As New System.Data.SqlClient.SqlConnection
    Public source(3), catalog(3), uid(3), pwd(3) As String

    Public Function DB_INIT()
        Call DB_INIT_sub(1) 'nMVAR.ini
        Call DB_INIT_sub(2) 'nQGCare.ini
        Call DB_INIT_sub(3) 'Fujitsu.ini

        ''Dim soce As String = "(local)\sqlexpress"
        'Dim soce As String = "10.10.1.88"

        'source(1) = soce
        'source(2) = soce
        'catalog(1) = "nMVAR"
        'catalog(2) = "QGCare"
    End Function

    Function DB_INIT_sub(ByVal seq) As String
        On Error GoTo TAG_Err
        Dim sr As System.io.StreamReader
        Select Case seq
            Case Is = 1
                sr = New System.IO.StreamReader("nMVAR.ini")
            Case Is = 2
                sr = New System.IO.StreamReader("nQGCare.ini")
            Case Is = 3
                sr = New System.IO.StreamReader("Fujitsu.ini")
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
                Select Case line_key
                    Case Is = "source"
                        source(seq) = Mid(line, eq_pos + 1, line_len - eq_pos)
                    Case Is = "catalog"
                        catalog(seq) = Mid(line, eq_pos + 1, line_len - eq_pos)
                    Case Is = "uid"
                        uid(seq) = Mid(line, eq_pos + 1, line_len - eq_pos)
                    Case Is = "pwd"
                        pwd(seq) = Mid(line, eq_pos + 1, line_len - eq_pos)
                End Select
            End If
        Loop Until line Is Nothing
        sr.Close()

        Exit Function

TAG_Err:
        MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Application.Exit()
    End Function

    Public Function DB_OPEN(ByVal file) As Boolean
        DB_OPEN = False

        '*****  接続文字列を作成して接続を開始する  *****
        Select Case file
            Case Is = "nMVAR"
                If Trim(uid(1)) <> Nothing Then
                    cnsqlclient.ConnectionString = "integrated security=false; uid=" & uid(1) & "; pwd=" & pwd(1) & "; data source=" & source(1) & ";persist security info=False; initial catalog=" & catalog(1)
                Else
                    cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source(1) & ";persist security info=False;initial catalog=" & catalog(1)
                End If
            Case Is = "QGCare"
                If Trim(uid(2)) <> Nothing Then
                    cnsqlclient.ConnectionString = "integrated security=false; uid=" & uid(2) & "; pwd=" & pwd(2) & "; data source=" & source(2) & ";persist security info=False; initial catalog=" & catalog(2)
                Else
                    cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source(2) & ";persist security info=False;initial catalog=" & catalog(2)
                End If
            Case Is = "Fujitsu"
                If Trim(uid(3)) <> Nothing Then
                    cnsqlclient.ConnectionString = "integrated security=false; uid=" & uid(3) & "; pwd=" & pwd(3) & "; data source=" & source(3) & ";persist security info=False; initial catalog=" & catalog(3)
                Else
                    cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source(3) & ";persist security info=False;initial catalog=" & catalog(3)
                End If
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

    'Public Function DB_OPEN(ByVal file) As Boolean
    '    DB_OPEN = False

    '    '*****  接続文字列を作成して接続を開始する  *****
    '    Select Case file
    '        Case Is = "nMVAR"
    '            If Trim(uid(1)) <> Nothing Then
    '                cnsqlclient.ConnectionString = "integrated security=false; uid=" & uid(1) & "; pwd=" & pwd(1) & "; data source=" & source(1) & ";persist security info=False; initial catalog=" & catalog(1)
    '            Else
    '                Dim con As New ADODB.Connection
    '                con.ConnectionString = "Provider=SQLNCLI10;" _
    '                         & "Server=" & source(1) & ";" _
    '                         & "Database=" & catalog(1) & ";" _
    '                         & "Integrated Security=SSPI;" _
    '                         & "DataTypeCompatibility=80;" _
    '                         & "MARS Connection=True;"
    '                con.Open()
    '            End If
    '        Case Is = "QGCare"
    '            If Trim(uid(2)) <> Nothing Then
    '                cnsqlclient.ConnectionString = "integrated security=false; uid=" & uid(2) & "; pwd=" & pwd(2) & "; data source=" & source(2) & ";persist security info=False; initial catalog=" & catalog(2)
    '            Else
    '                cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source(2) & ";persist security info=False;initial catalog=" & catalog(2)
    '            End If
    '    End Select

    '    Try
    '        '*****  Connectionが接続されているかチェック  *****
    '        If cnsqlclient.State = ConnectionState.Closed Then
    '            cnsqlclient.Open()
    '        End If
    '    Catch
    '        MsgBox(Err.Description, 16, "接続エラー")
    '        DB_OPEN = False
    '        Exit Function
    '    End Try

    '    DB_OPEN = True
    'End Function

    Public Sub DB_CLOSE()
        cnsqlclient.Close()     '接続を終了する
    End Sub
End Module
