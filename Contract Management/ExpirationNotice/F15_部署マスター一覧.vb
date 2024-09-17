Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class F15_部署マスター一覧
    Private Sub F15_部署マスター一覧_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MaximizeBox = False
        ' Me. = False;
        Del.Visible = False
        Label3.Visible = False
        binddata()
    End Sub
    Private Sub binddata()
        Try


            Dim data = New DataTable()
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim query As String = "select id,Department_number as 部署番号,Management_department as 管理部署 ,Remarks as 備考, `delete` as 削除 "
            query += "from tm15_department_master where `delete`=0"

            command.CommandText = query
            Reader = command.ExecuteReader()
            Dim dt = New DataTable()
            data.Load(Reader)
            DB_CLOSE()

            dt.Columns.Add("部署番号", GetType(Integer))
            dt.Columns.Add("管理部署", GetType(String))
            dt.Columns.Add("備考", GetType(String))
            dt.Columns.Add("削除", GetType(Boolean))
            dt.Columns.Add("Id", GetType(Integer))

            For i As Integer = 0 To data.Rows.Count - 1
                Dim col1 As Integer
                Dim col5 As Integer
                Dim col2 As String
                Dim col3 As String
                Dim col4 As Boolean

                If Not IsDBNull(data.Rows(i)("部署番号")) Then
                    col1 = Convert.ToInt32(data.Rows(i)("部署番号"))
                Else
                    col1 = 0
                End If

                If Not IsDBNull(data.Rows(i)("管理部署")) Then
                    col2 = Convert.ToString(data.Rows(i)("管理部署"))
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
                If Not IsDBNull(data.Rows(i)("Id")) Then
                    col5 = Convert.ToInt32(data.Rows(i)("Id"))
                Else
                    col5 = 0
                End If
                dt.Rows.Add(col1, col2, col3, col4, col5)
            Next
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.DataSource = dt
            DataGridView1.Columns(0).ReadOnly = True
            DataGridView1.Columns(1).ReadOnly = True
            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).Visible = True
            DataGridView1.Columns(4).Visible = False
        Catch ex As Exception

        End Try
    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            Departmentnumber.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            MgtDpt.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
            Remarks.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
            P_PRAM1 = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString()
            P_PRAM2 = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
        End If

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Departmentnumber.Text = ""
        MgtDpt.Text = ""
        Remarks.Text = ""
        Del.Checked = False
        Me.Close()


    End Sub

    Private Sub Ok_Click(sender As Object, e As EventArgs) Handles Ok.Click
        Try


            Dim delfg = 0
            If Del.Checked = True Then
                'MessageBoxButtons.Yes = "Alright"
                'MessageBoxManager.Yes = "Yep!"
                'MessageBoxManager.No = "Nope"
                'MessageBoxManager.Register()
                Dim newButton = New Button()

                newButton.Text = "Created Button"

                Dim dialogResult As DialogResult = MessageBox.Show("選択したレコードを削除してもよろしいですか？", "確認", MessageBoxButtons.YesNo)

                If dialogResult = DialogResult1.はい Then
                    delfg = 1
                ElseIf dialogResult = DialogResult1.いいえ Then
                    Del.Checked = False
                    Exit Sub
                End If
            End If
            DB_OPEN()
            Dim account = ""
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim query3 As String = "SELECT Count(*) as cnt FROM tm15_department_master where Department_number<>@oldId and  Department_number=@newId "
            command.CommandText = query3
            command.Parameters.AddWithValue("newId", Departmentnumber.Text)
            command.Parameters.AddWithValue("oldId", P_PRAM2)
            Reader = command.ExecuteReader()
            While Reader.Read
                account = Reader("cnt")
            End While
            DB_CLOSE()
            If (account <> 0) Then
                MessageBox.Show("部門番号はすでに存在します")
                Exit Sub
            End If
            DB_OPEN()

            Dim query As String = "Update tm15_department_master  set "
            query += "Department_number = @DepartNo, "
            query += "Management_department=@Mgtdep, "
            query += "Remarks = @remarks, "
            query += " `delete`=@delfg"
            query += " Where Id=@id"



            command.Parameters.AddWithValue("DepartNo", Departmentnumber.Text)
            command.Parameters.AddWithValue("Mgtdep", MgtDpt.Text)
            command.Parameters.AddWithValue("remarks", Remarks.Text)
            command.Parameters.AddWithValue("id", P_PRAM1)
            command.Parameters.AddWithValue("delfg", delfg)
            command.CommandText = query
            P_PRAM1 = ""
            Dim result As Int16 = command.ExecuteNonQuery()
            DB_CLOSE()
            Departmentnumber.Text = ""
            MgtDpt.Text = ""
            Remarks.Text = ""
            Del.Checked = False
            If Del.Checked = True Then
                MessageBox.Show("データが正常に削除されました")
                binddata()
            End If
            If (result = 1) Then
                MessageBox.Show("データが正常に更新されました")
                binddata()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Departmentnumber_TextChanged(sender As Object, e As EventArgs) Handles Departmentnumber.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(Departmentnumber.Text, "[^0-9]") Then
            MessageBox.Show("数字のみを入力してください。")
            Departmentnumber.Text = Departmentnumber.Text.Remove(Departmentnumber.Text.Length - 1)
        End If
        If Departmentnumber.Text.Length > 5 Then
            Departmentnumber.Text = Departmentnumber.Text.Remove(Departmentnumber.Text.Length - 1)

            MessageBox.Show("数字のみを入力してください。")

        End If
    End Sub

    Private Sub Departmentnumber_Validating(sender As Object, e As CancelEventArgs) Handles Departmentnumber.Validating
        If System.Text.RegularExpressions.Regex.IsMatch(Departmentnumber.Text, "[^0-9]") Then
            MessageBox.Show("数字のみを入力してください。")
            Departmentnumber.Text = Departmentnumber.Text.Remove(Departmentnumber.Text.Length - 1)
        End If
    End Sub



    Private Sub MgtDpt_Validating(sender As Object, e As CancelEventArgs) Handles MgtDpt.Validating
        If String.IsNullOrEmpty(MgtDpt.Text.Trim) Then
            ErrorProvider1.SetError(MgtDpt, "管理部門が必要です。")
        Else
            ErrorProvider1.SetError(MgtDpt, String.Empty)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 3 Then

            Dim delete = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString()
            Dim Id = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString()
            DataGridView1.Rows(e.RowIndex).Cells(3).Value = True
            DataGridView1.Refresh()
            If delete = False Then
                DoSomethingAsync(Id)
            End If
        End If

    End Sub
    Private Async Function DoSomethingAsync(Id As String) As Task
        Await Task.Delay(5)
        Dim dialogResult As DialogResult = MessageBox.Show("選択したレコードを削除してもよろしいですか？", "確認", MessageBoxButtons.YesNo)

        If dialogResult = DialogResult.Yes Then
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim query As String = "Update tm15_department_master set "
            query += "`delete` =1  where ID = " + Id + " "
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

    Public Enum DialogResult1
        はい = 6
        いいえ = 7
    End Enum
    Public Enum MessageBoxButtons1
        はいいいえ = 1
    End Enum

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Me.MinimizeBox = True
    End Sub
    'Private Const CP_DISABLE_CLOSE_BUTTON As Integer = &H200
    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ClassStyle = cp.ClassStyle Or CP_DISABLE_CLOSE_BUTTON
    '        Return cp
    '    End Get
    'End Property
End Class

