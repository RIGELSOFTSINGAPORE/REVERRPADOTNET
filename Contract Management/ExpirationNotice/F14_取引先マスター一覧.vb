Imports MySql.Data.MySqlClient


Public Class F14_取引先マスター一覧
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim cmd As MySqlCommand
    Private Sub F14_取引先マスター一覧_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        binddata()

    End Sub


    Private Sub binddata()
        Try
            Dim Data = New DataTable()
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim query As String = "SELECT Account_number as 取引先番号, Customer_name as 取引先名, Yomigana as ヨミガナ,`delete` as 削除 "
            query += "From tm14_account_master where  `delete`=0"
            If CName.Text.Trim() <> "" Then
                query += " and  Customer_name LIKE  @cname"
                command.Parameters.AddWithValue("cname", CName.Text + "%")
            End If
            command.CommandText = query
            Reader = command.ExecuteReader()
            Dim dt = New DataTable()
            Data.Load(Reader)

            DB_CLOSE()

            dt.Columns.Add("取引先番号", GetType(Integer))
            dt.Columns.Add("取引先名", GetType(String))
            dt.Columns.Add("ヨミガナ", GetType(String))
            dt.Columns.Add("削除", GetType(Boolean))

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim col1 As Integer
                Dim col2 As String
                Dim col3 As String
                Dim col4 As Boolean

                If Not IsDBNull(Data.Rows(i)("取引先番号")) Then
                    col1 = Convert.ToInt32(Data.Rows(i)("取引先番号"))
                Else
                    col1 = 0
                End If

                If Not IsDBNull(Data.Rows(i)("取引先名")) Then
                    col2 = Convert.ToString(Data.Rows(i)("取引先名"))
                Else
                    col2 = ""
                End If

                If Not IsDBNull(Data.Rows(i)("ヨミガナ")) Then
                    col3 = Convert.ToString(Data.Rows(i)("ヨミガナ"))
                Else
                    col3 = ""
                End If

                If Not IsDBNull(Data.Rows(i)("削除")) Then
                    col4 = Convert.ToBoolean(Data.Rows(i)("削除"))
                Else
                    col4 = 0
                End If
                dt.Rows.Add(col1, col2, col3, col4)
            Next

            DataGridView2.Columns.Clear()
            DataGridView2.AllowUserToAddRows = False
            DataGridView2.DataSource = dt
            Dim Editlink As DataGridViewLinkColumn = New DataGridViewLinkColumn()
            Editlink.UseColumnTextForLinkValue = True
            Editlink.HeaderText = "編集
"
            Editlink.DataPropertyName = "取引先番号"
            Editlink.LinkBehavior = LinkBehavior.SystemDefault
            Editlink.Text = "編集
"



            DataGridView2.Columns.Add(Editlink)

            DataGridView2.Columns(0).ReadOnly = True
            DataGridView2.Columns(1).ReadOnly = True
            DataGridView2.Columns(2).ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex <> -1 Then

            If e.ColumnIndex = 4 Then
                P_PRAM1 = DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString()
                P_PRAM2 = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString()
                P_PRAM3 = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString()
                P_PRAM4 = "Edit"
                'Dim id = DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString()
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Dim F12_取引先マスター As New F12_取引先マスター
                Me.Hide()
                F12_取引先マスター.ShowDialog()
                binddata()
                Me.Show()
                Cursor = System.Windows.Forms.Cursors.Default

            End If
            'If e.ColumnIndex = 3 Then

            '    Dim delete = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString()
            '    Dim Id = DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString()
            '    DataGridView2.Rows(e.RowIndex).Cells(3).Value = True
            '    DataGridView2.Refresh()
            '    If delete = False Then
            '        DoSomethingAsync(Id)
            '        'Dim dialogResult As DialogResult = MessageBox.Show("選択したレコードを削除してもよろしいですか？", "確認", MessageBoxButtons.YesNo)

            '        'If dialogResult = DialogResult.Yes Then
            '        '    'DB_OPEN()
            '        '    'Dim command As MySqlCommand = cnn.CreateCommand()
            '        '    'Dim query As String = "Update Tm14_取引先マスター set "
            '        '    'query += "削除 =1  where 取引先番号 = " + Id + " "
            '        '    'command.CommandText = query
            '        '    'Dim result As Int16 = Command.ExecuteNonQuery()

            '        '    'If (result = 1) Then
            '        '    '    MessageBox.Show("データが正常に削除されました")
            '        '    'End If
            '        '    'DB_CLOSE()
            '        '    'binddata()
            '        'ElseIf dialogResult = DialogResult.No Then
            '        '    'binddata()

            '        'End If
            '    End If
            'End If
        End If

    End Sub
    Private Async Function DoSomethingAsync(Id As String) As Task
        Await Task.Delay(5)
        Dim dialogResult As DialogResult = MessageBox.Show("選択したレコードを削除してもよろしいですか？", "確認", MessageBoxButtons.YesNo)

        If dialogResult = DialogResult.Yes Then
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim query As String = "Update tm14_account_master set "
            query += "`delete` =1  where Account_number = " + Id + " "
            command.CommandText = query
            Dim result As Int16 = command.ExecuteNonQuery()

            If (result = 1) Then
                MessageBox.Show("データが正常に削除されました")
            End If
            DB_CLOSE()
            binddata()
        ElseIf dialogResult = DialogResult.No Then
            binddata()

        End If
    End Function

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        binddata()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.ColumnIndex = 3 Then

            Dim delete = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString()
            Dim Id = DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString()
            DataGridView2.Rows(e.RowIndex).Cells(3).Value = True
            DataGridView2.Refresh()
            If delete = False Then
                DoSomethingAsync(Id)
                'Dim dialogResult As DialogResult = MessageBox.Show("選択したレコードを削除してもよろしいですか？", "確認", MessageBoxButtons.YesNo)

                'If dialogResult = DialogResult.Yes Then
                '    'DB_OPEN()
                '    'Dim command As MySqlCommand = cnn.CreateCommand()
                '    'Dim query As String = "Update Tm14_取引先マスター set "
                '    'query += "削除 =1  where 取引先番号 = " + Id + " "
                '    'command.CommandText = query
                '    'Dim result As Int16 = Command.ExecuteNonQuery()

                '    'If (result = 1) Then
                '    '    MessageBox.Show("データが正常に削除されました")
                '    'End If
                '    'DB_CLOSE()
                '    'binddata()
                'ElseIf dialogResult = DialogResult.No Then
                '    'binddata()

                'End If
            End If
        End If
    End Sub
End Class