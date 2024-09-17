Imports MySql.Data.MySqlClient
Imports System.Configuration
Module Module_DB

    'Private myConnectionString As String = "server=localhost;database=expirationnotice;uid=root;pwd=123@r"
    Private myConnectionString As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
    Public cnn As MySqlConnection = New MySqlConnection(myConnectionString)
    'Public cnn As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
    Public Function DB_OPEN() As Boolean
        DB_OPEN = False

        '*****  接続文字列を作成して接続を開始する  *****
        ' Dim cnn As MySqlConnection = New MySqlConnection("cnstr")
        Try
            'If cnn.State = ConnectionState.Open Then
            'cnn.Close()
            ' Else
            cnn.Open()
            'End If

        Catch ex As Exception
            MessageBox.Show("Cannot open connection!")
            DB_OPEN = False
            DB_CLOSE()
            Exit Function
        End Try


        DB_OPEN = True
    End Function
    Public Sub DB_CLOSE()
        'Dim cnn As MySqlConnection = New MySqlConnection("cnstr")
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
        End If

    End Sub
End Module
