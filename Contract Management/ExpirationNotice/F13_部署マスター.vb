Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class F13_部署マスター
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Ok.Click
        Try


            Dim F15_部署マスター一覧 As New F15_部署マスター一覧
            Dim account As String = ""

            'If Departmentnumber.Text.Trim() = "" Then
            '    Exit Sub
            'End If
            If Managementdepartment.Text.Trim() = "" Then
                Exit Sub
            End If
            'If remarks.Text.Trim() = "" Then
            '    Exit Sub
            'End If
            'DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            'Dim query3 As String = "SELECT Count(*) as cnt FROM tm15_department_master where Department_number=@Id "
            'command.CommandText = query3
            'command.Parameters.AddWithValue("Id", Departmentnumber.Text)
            'Reader = command.ExecuteReader()
            'While Reader.Read
            '    account = Reader("cnt")
            'End While
            'DB_CLOSE()
            'If (account <> 0) Then
            '    MessageBox.Show("部門番号はすでに存在します")
            '    Exit Sub
            'End If
            DB_OPEN()
            Dim dptno = 0
            Dim query1 As String = "SELECT MAX(Department_number)+1 as acc FROM tm15_department_master "
            command.CommandText = query1
            Reader = command.ExecuteReader()
            While Reader.Read
                dptno = Reader("acc")
            End While
            DB_CLOSE()
            DB_OPEN()
            Dim id = 0
            Dim query2 As String = "SELECT MAX(Id)+1 as Id FROM tm15_department_master "
            command.CommandText = query2
            Reader = command.ExecuteReader()
            While Reader.Read
                id = Reader("Id")
            End While
            DB_CLOSE()
            DB_OPEN()
            Dim query As String = "insert into tm15_department_master "
            query += "(Id,Department_number,Management_department,Remarks,`Delete`) values"
            query += " (@Id1,@DepartNo ,@Mgtdep,@remarks,0);"

            command.Parameters.AddWithValue("Id1", id)
            'command.Parameters.AddWithValue("Account", account)
            command.Parameters.AddWithValue("DepartNo", dptno)
            command.Parameters.AddWithValue("Mgtdep", Managementdepartment.Text)
            command.Parameters.AddWithValue("remarks", remarks.Text)
            command.CommandText = query
            Dim result As Int16 = command.ExecuteNonQuery()

            If (result = 1) Then
                MessageBox.Show("データが正常に登録されました。")
            End If
            DB_CLOSE()
            'Departmentnumber.Text = ""
            Managementdepartment.Text = ""
            remarks.Text = ""
            Me.Hide()
            F15_部署マスター一覧.ShowDialog()
            Me.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    'Private Sub Departmentnumber_Validating(sender As Object, e As CancelEventArgs) Handles Departmentnumber.Validating
    '    If String.IsNullOrEmpty(Departmentnumber.Text.Trim) Then
    '        ErrorProvider1.SetError(Departmentnumber, "部門番号が必要です。")
    '    Else
    '        ErrorProvider1.SetError(Departmentnumber, String.Empty)
    '    End If
    'End Sub

    Private Sub Managementdepartment_Validating(sender As Object, e As CancelEventArgs) Handles Managementdepartment.Validating
        If String.IsNullOrEmpty(Managementdepartment.Text.Trim) Then
            ErrorProvider1.SetError(Managementdepartment, "管理部門が必要です。")
        Else
            ErrorProvider1.SetError(Managementdepartment, String.Empty)
        End If
    End Sub

    'Private Sub Departmentnumber_TextChanged(sender As Object, e As EventArgs)
    '    If System.Text.RegularExpressions.Regex.IsMatch(Departmentnumber.Text, "[^0-9]") Then
    '        MessageBox.Show("数字のみを入力してください。")
    '        Departmentnumber.Text = Departmentnumber.Text.Remove(Departmentnumber.Text.Length - 1)
    '    End If
    '    If Departmentnumber.Text.Length > 5 Then
    '        Departmentnumber.Text = Departmentnumber.Text.Remove(Departmentnumber.Text.Length - 1)

    '        MessageBox.Show("最大5文字を入力してください。")

    '    End If
    '    If Departmentnumber.Text <> "" Then

    '        If Convert.ToInt32(Departmentnumber.Text) > Convert.ToInt32("30000") Then
    '            Departmentnumber.Text = Departmentnumber.Text.Remove(Departmentnumber.Text.Length - 1)

    '            MessageBox.Show("30000まで入力してください。")

    '        End If

    '    End If
    'End Sub

    Private Sub F13_部署マスター_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MaximizeBox = False
    End Sub


End Class