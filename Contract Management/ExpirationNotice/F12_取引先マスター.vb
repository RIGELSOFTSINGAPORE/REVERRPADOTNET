Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class F12_取引先マスター
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Try


            Dim account As String = ""
            Dim F14_取引先マスター一覧 As New F14_取引先マスター一覧
            If CustomerName.Text.Trim() = "" Then
                Exit Sub
            End If
            If Yomigana.Text.Trim() = "" Then
                Exit Sub
            End If

            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            If P_PRAM4 = "Edit" Then
                DB_OPEN()
                Dim query As String = "Update tm14_account_master set "
                query += "Customer_name =@Customer , Yomigana=@Yomigana "
                query += "where Account_number=@Account "

                command.Parameters.AddWithValue("Account", P_PRAM1)
                command.Parameters.AddWithValue("Customer", CustomerName.Text)
                command.Parameters.AddWithValue("Yomigana", Yomigana.Text)
                command.CommandText = query
                Dim result As Int16 = command.ExecuteNonQuery()

                If (result = 1) Then
                    MessageBox.Show("データが正常に更新されました")
                End If
                DB_CLOSE()
                P_PRAM1 = ""
                P_PRAM2 = ""
                P_PRAM3 = ""
                P_PRAM4 = ""
                Me.Close()

            Else

                DB_OPEN()

                Dim query1 As String = "SELECT MAX(Account_number)+1 as acc FROM tm14_account_master "
                command.CommandText = query1
                Reader = command.ExecuteReader()
                While Reader.Read
                    account = Reader("acc")
                End While
                DB_CLOSE()
                DB_OPEN()
                Dim query As String = "insert into tm14_account_master "
                query += "(Account_number,Customer_name,Yomigana,`Delete`) values"
                query += " (@Account,@Customer ,@Yomigana,0);"

                command.Parameters.AddWithValue("Account", account)
                command.Parameters.AddWithValue("Customer", CustomerName.Text)
                command.Parameters.AddWithValue("Yomigana", Yomigana.Text)
                command.CommandText = query
                Dim result As Int16 = command.ExecuteNonQuery()

                If (result = 1) Then
                    MessageBox.Show("データが正常に登録されました。")
                End If
                DB_CLOSE()

                CustomerName.Text = ""
                Yomigana.Text = ""
                Me.Hide()
                F14_取引先マスター一覧.ShowDialog()
                Me.Show()

            End If
        Catch ex As Exception

        End Try
    End Sub
    'Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    'Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim myCp As CreateParams = MyBase.CreateParams
    '        myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
    '        Return myCp
    '    End Get
    'End Property

    Private Sub Customername_Validating(sender As Object, e As CancelEventArgs) Handles Yomigana.Validating
        If String.IsNullOrEmpty(CustomerName.Text.Trim) Then
            EP_name.SetError(CustomerName, "顧客名が必要です。")
        Else
            EP_name.SetError(CustomerName, String.Empty)
        End If

    End Sub

    Private Sub Yomigana_Validating(sender As Object, e As CancelEventArgs) Handles CustomerName.Validating
        If String.IsNullOrEmpty(Yomigana.Text.Trim) Then
            EP_name.SetError(Yomigana, "振り仮名が必要です。")
        Else
            EP_name.SetError(Yomigana, String.Empty)
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub F12_取引先マスター_Load(sender As Object, e As EventArgs) Handles Me.Load
        If P_PRAM4 = "Edit" Then
            'P_PRAM1=
            CustomerName.Text = P_PRAM2
            Yomigana.Text = P_PRAM3
            Newlbl.Visible = False
            P_PRAM2 = ""
            P_PRAM3 = ""
            'Prabu Comment 2021-12-31
            'P_PRAM4 = ""
        Else
            Newlbl.Visible = True
        End If
        Me.MaximizeBox = False
    End Sub
End Class