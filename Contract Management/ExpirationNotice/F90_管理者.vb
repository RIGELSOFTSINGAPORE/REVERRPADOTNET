Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class F90_管理者
    Private Sub F90_管理者_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MaximizeBox = False
        binddata()
    End Sub
    Private Sub binddata()
        Try


            Dim data = New DataTable()
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim query As String = "select Id, Win_login_name as Winログイン名, Name as 名前, Remarks as 備考,`delete` as 削除  from tm90_admin where `delete`=0"

            command.CommandText = query
            Reader = command.ExecuteReader()
            Dim dt = New DataTable()
            data.Load(Reader)
            DB_CLOSE()
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Winログイン名 ", GetType(String))
            dt.Columns.Add("名前", GetType(String))
            dt.Columns.Add("備考", GetType(String))
            dt.Columns.Add("削除", GetType(Boolean))


            For i As Integer = 0 To data.Rows.Count - 1
                Dim col1 As String
                Dim col5 As Integer
                Dim col2 As String
                Dim col3 As String
                Dim col4 As Boolean
                If Not IsDBNull(data.Rows(i)("Id")) Then
                    col5 = Convert.ToInt32(data.Rows(i)("Id"))
                Else
                    col5 = 0
                End If
                If Not IsDBNull(data.Rows(i)("Winログイン名")) Then
                    col1 = Convert.ToString(data.Rows(i)("Winログイン名"))
                Else
                    col1 = 0
                End If

                If Not IsDBNull(data.Rows(i)("名前")) Then
                    col2 = Convert.ToString(data.Rows(i)("名前"))
                Else
                    col2 = ""
                End If

                If Not IsDBNull(data.Rows(i)("備考")) Then
                    col3 = Convert.ToString(data.Rows(i)("備考"))
                Else
                    col3 = ""
                End If

                If Not IsDBNull(data.Rows(i)("削除")) Then
                    col4 = Convert.ToBoolean(data.Rows(i)("削除"))
                Else
                    col4 = 0
                End If

                dt.Rows.Add(col5, col1, col2, col3, col4)
            Next
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.DataSource = dt
            DataGridView1.Columns(0).ReadOnly = True
            DataGridView1.Columns(1).ReadOnly = True
            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        If Idtxt.Text.Trim() = "" Then
            Exit Sub
        End If
        If loginname.Text.Trim() = "" Then
            Exit Sub
        End If
        If Name.Text.Trim() = "" Then
            Exit Sub
        End If

        If (P_PRAM1 = "Update") Then
                DB_OPEN()
                Dim command As MySqlCommand = cnn.CreateCommand()
            Dim query As String = "Update tm90_admin  set "
            query += "Win_login_name = @loginName, "
            query += "id=@Id, "
            query += "Name=@name, "
            query += "Remarks = @remarks "
            query += " Where Id=@oldId"

                command.Parameters.AddWithValue("Id", Idtxt.Text)
                command.Parameters.AddWithValue("loginName", loginname.Text)
                command.Parameters.AddWithValue("name", Name.Text)
                command.Parameters.AddWithValue("remarks", Remarks.Text)
                command.Parameters.AddWithValue("oldId", P_PRAM2)
                'command.Parameters.AddWithValue("delfg", 0)

                command.CommandText = query

                Dim result As Int16 = command.ExecuteNonQuery()
                DB_CLOSE()
                P_PRAM1 = ""
                P_PRAM2 = ""
                If (result = 1) Then
                MessageBox.Show("データが正常に更新されました")
                binddata()
                End If
            Else
                DB_OPEN()
            Dim data = New DataTable()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim query1 As String = "select * from tm90_admin where `delete`=0 and id=@id"

            command.CommandText = query1
            command.Parameters.AddWithValue("Id", Idtxt.Text)
            Reader = command.ExecuteReader()
            Dim dt = New DataTable()
            data.Load(Reader)
            DB_CLOSE()
            If (data.Rows.Count > 0) Then
                MessageBox.Show("Idはすでに存在します")
                Exit Sub
            End If
            DB_OPEN()

            Dim query As String = "Insert Into tm90_admin  "
            query += "(Id,Win_login_name, Name, Remarks, `delete`) "
            query += "values "
            query += "(@Id,@loginName,@name,@remarks,0)"


            command.Parameters.AddWithValue("loginName", loginname.Text)
            command.Parameters.AddWithValue("name", Name.Text)
            command.Parameters.AddWithValue("remarks", Remarks.Text)
            'command.Parameters.AddWithValue("delfg", 0)
            command.CommandText = query

            Dim result As Int16 = command.ExecuteNonQuery()

            DB_CLOSE()
            binddata()
            If (result = 1) Then
                MessageBox.Show("データが正常に更新されました")
                binddata()
            End If
        End If
        Idtxt.Text = ""
        Name.Text = ""
        loginname.Text = ""
        Remarks.Text = ""

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' If (DataGridView1.Columns(e.ColumnIndex).Name = "ID") Then
        Dim senderGrid = CType(sender, DataGridView)
        'If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
        'DataGridView1.CurrentCell Is Nothing OrElse DataGridView1.CurrentCell.Value Is Nothing OrElse
        If Not e.RowIndex = -1 Then
            Idtxt.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            loginname.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
            Name.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
            Remarks.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString()
            P_PRAM1 = "Update"
            P_PRAM2 = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
        End If

        ' End If
        'End If
    End Sub



    Private Sub loginname_Validating(sender As Object, e As CancelEventArgs) Handles loginname.Validating
        If String.IsNullOrEmpty(loginname.Text.Trim) Then
            ErrorProvider1.SetError(loginname, "WinO名が必要です。")
        Else
            ErrorProvider1.SetError(loginname, String.Empty)
        End If
    End Sub

    Private Sub Name_Validating(sender As Object, e As CancelEventArgs) Handles Name.Validating
        If String.IsNullOrEmpty(Name.Text.Trim) Then
            ErrorProvider1.SetError(Name, "名前が必要です。")
        Else
            ErrorProvider1.SetError(Name, String.Empty)
        End If
    End Sub

    Private Sub Idtxt_Validating(sender As Object, e As CancelEventArgs) Handles Idtxt.Validating
        If String.IsNullOrEmpty(Idtxt.Text.Trim) Then
            ErrorProvider1.SetError(Idtxt, "IDが必要です。")
        Else
            ErrorProvider1.SetError(Idtxt, String.Empty)
        End If
    End Sub

    Private Sub Idtxt_TextChanged(sender As Object, e As EventArgs) Handles Idtxt.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(Idtxt.Text, "[^0-9]") Then
            MessageBox.Show("数字のみを入力してください。")
            Idtxt.Text = Idtxt.Text.Remove(Idtxt.Text.Length - 1)
        End If
    End Sub
End Class