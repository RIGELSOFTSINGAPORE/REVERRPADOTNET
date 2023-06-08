Imports System.Data
Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class F21_契約書入力画面
    Dim command As MySqlCommand
    Dim adapter As New MySqlDataAdapter()
    Dim ds As New DataSet()
    Dim DtView1 As DataView
    Dim sql As String = Nothing
    Dim dtnow As Date = Today
    Dim flag As Boolean = False
    Dim insert As Boolean = True
    Dim flagbool As Boolean = True
    Dim P_PRAM6 As String

    Private Sub F23_枝番入力画面_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.MaximizeBox = False
        ComboBox008()

        ComboBox001()
        cmbremove()
        Label2.Text = "キー番号"
        Label4.Text = "信用調査日"
        'Label3.Text = "管理番号"
        ' binddata()
        inz()
        'Me.TextBox1t = 100
        Me.TextBox1.AutoSize = False
        Me.TextBox1.Size = New System.Drawing.Size(369, 21)
        If F21pageload = True Then
            ComboBox2_Enter(sender, e)
            ComboBox3_Enter(sender, e)
            ComboBox4_Enter(sender, e)
            ComboBox5_Enter(sender, e)
            ComboBox6_Enter(sender, e)
            ComboBox7_Enter(sender, e)
            ComboBox9_Enter(sender, e)
            F21pageload = False
        End If
    End Sub
    'Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    'Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim myCp As CreateParams = MyBase.CreateParams
    '        myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
    '        Return myCp
    '    End Get
    'End Property
    Private Sub binddata()


        'ComboBox002()
        'ComboBox003()
        'ComboBox004()
        'ComboBox005()
        'ComboBox006()
        ComboBox007()
        ComboBox008()
        ComboBox009()
        cmbremove()
    End Sub
    Sub inz()
        'If Not String.IsNullOrEmpty(contractid) Then
        'If contractid <> 0 Then
        '    If Not String.IsNullOrEmpty(Mgt_number) Then
        '        TextBox3.Text = Mgt_number
        '        Mgt_number = ""
        '        OK.Text = "更新"
        '        Label6.Text = contractid
        '        contractid = 0
        '        insert = False
        '    Else
        '        TextBox3.Text = ""
        '        Mgt_number = ""
        '        Label6.Text = contractid
        '        Label6.Visible = False
        '        contractid = 0
        '        OK.Text = "更新"
        '        insert = False
        '    End If
        'Else
        '    getID()
        '    insert = True
        '    OK.Text = "OK"
        'End If
        If contractid <> 0 Then
            TextBox3.Text = contractid
            Label6.Text = contractid
            contractid = 0
            insert = False
            flagbool = False
            OK.Text = "更新"
        Else
            getID()
            insert = True
            flagbool = True
            OK.Text = "OK"
        End If


        ' End If

        'If Not String.IsNullOrEmpty(contractid) Then
        '    If contractid <> 0 Then
        '        Label6.Text = contractid
        '        contractid = 0
        '        insert = False
        '    End If
        'End If

        If Not String.IsNullOrEmpty(Branch_number) Then
            TextBox5.Text = Branch_number
            Branch_number = ""
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber1) Then

            ComboBox2.SelectedValue = Temporarycompanynumber1
            'Temporarycompanynumber1 = 0
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber2) Then
            ComboBox3.SelectedValue = Temporarycompanynumber2
            'Temporarycompanynumber2 = 0
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber3) Then
            ComboBox4.SelectedValue = Temporarycompanynumber3
            ' Temporarycompanynumber3 = 0
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber4) Then
            ComboBox5.SelectedValue = Temporarycompanynumber4
            ' Temporarycompanynumber4 = 0
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber5) Then
            ComboBox6.SelectedValue = Temporarycompanynumber5
            'Temporarycompanynumber5 = 0
        End If
        If Not String.IsNullOrEmpty(Old_number) Then
            TextBox4.Text = Old_number
            Old_number = ""
        End If
        If Not String.IsNullOrEmpty(Contract_date) Then
            If Contract_date > "31-12-9998 00:00:00" Then
                'DateTimePicker1.Format = DateTimePickerFormat.Custom
                'DateTimePicker1.CustomFormat = "yyyy/MM/dd"
                'DateTimePicker1.Value = dtnow
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = " "
            Else
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "yyyy/MM/dd"
                DateTimePicker1.Value = Contract_date
                Contract_date = ""
            End If

        Else
            'DateTimePicker1.Value = dtnow
            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = " "
        End If

        If Not String.IsNullOrEmpty(Contract_p_co) Then
            If Scheduled_Prd_end_Date > "31-12-9998 00:00:00" Then
                'DateTimePicker2.Format = DateTimePickerFormat.Custom
                'DateTimePicker2.CustomFormat = "yyyy/MM/dd"
                'DateTimePicker2.Value = dtnow
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = " "
            Else
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "yyyy/MM/dd"
                DateTimePicker2.Value = Contract_p_co
                Contract_p_co = ""
            End If

        Else
            'DateTimePicker2.Value = dtnow
            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = " "

        End If
        If Not String.IsNullOrEmpty(Scheduled_Prd_end_Date) Then
            If Scheduled_Prd_end_Date > "31-12-9998 00:00:00" Then
                'DateTimePicker4.Format = DateTimePickerFormat.Custom
                'DateTimePicker4.CustomFormat = "yyyy/MM/dd"
                'DateTimePicker4.Value = dtnow
                DateTimePicker4.Format = DateTimePickerFormat.Custom
                DateTimePicker4.CustomFormat = " "
            Else
                DateTimePicker4.Format = DateTimePickerFormat.Custom
                DateTimePicker4.CustomFormat = "yyyy/MM/dd"
                DateTimePicker4.Value = Scheduled_Prd_end_Date
                Scheduled_Prd_end_Date = ""
            End If

        Else
            DateTimePicker4.Format = DateTimePickerFormat.Custom
            DateTimePicker4.CustomFormat = " "

        End If

        If Not String.IsNullOrEmpty(End_date) Then
            If End_date > "31-12-9998 00:00:00" Then
                DateTimePicker3.Format = DateTimePickerFormat.Custom
                DateTimePicker3.CustomFormat = " "
            Else
                DateTimePicker3.Format = DateTimePickerFormat.Custom
                DateTimePicker3.CustomFormat = "yyyy/MM/dd"
                DateTimePicker3.Value = End_date
                End_date = ""
            End If
        Else
            'DateTimePicker3.Value = dtnow
            DateTimePicker3.Format = DateTimePickerFormat.Custom
            DateTimePicker3.CustomFormat = " "
        End If

        If Not String.IsNullOrEmpty(Surveydate) Then
            If Surveydate > "31-12-9998 00:00:00" Then
                DateTimePicker5.Format = DateTimePickerFormat.Custom
                DateTimePicker5.CustomFormat = "yyyy/MM/dd"
                Surveydate = ""
            Else
                DateTimePicker5.Format = DateTimePickerFormat.Custom
                DateTimePicker5.CustomFormat = "yyyy/MM/dd"
                DateTimePicker5.Value = Surveydate
                Surveydate = ""
            End If
        Else
            'DateTimePicker3.Value = dtnow
            DateTimePicker5.Format = DateTimePickerFormat.Custom
            DateTimePicker5.CustomFormat = " "
        End If

        If Not String.IsNullOrEmpty(Update_code) Then
            'doubt
            'ComboBox7.SelectedValue = Update_code
            'Update_code = ""
        End If
        If Not String.IsNullOrEmpty(Auto_upd_intr) Then
            ComboBox8.SelectedValue = Auto_upd_intr
            Auto_upd_intr = ""
        End If
        If Not String.IsNullOrEmpty(Contract_name) Then
            TextBox21.Text = Contract_name
            Contract_name = ""
        End If
        'If Not String.IsNullOrEmpty(Mgt_dpt) Then
        '    ComboBox9.SelectedValue = Mgt_dpt
        '    Mgt_dpt = ""
        'End If
        If Not String.IsNullOrEmpty(Contractor) Then
            TextBox27.Text = Contractor
            Contractor = ""
        End If
        If Not String.IsNullOrEmpty(Remarks) Then
            TextBox24.Text = Remarks
            Remarks = ""
        End If
        If Not String.IsNullOrEmpty(ind) Then
            If ind = True Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
        End If
        If Not String.IsNullOrEmpty(ends) Then
            If ends = True Then
                CheckBox7.Checked = True
            Else
                CheckBox7.Checked = False
            End If
        End If
        If Not String.IsNullOrEmpty(companynumber_all) Then
            sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0  "

            Dim count1 = companynumber_all.Split(",").Length - 1
            Dim ids = companynumber_all.Substring(0, 1)

            Dim companynumber_all_1 = companynumber_all
            For count1 = 1 To count1
                DB_OPEN()
                Dim command1 As MySqlCommand = cnn.CreateCommand()
                Dim Reader1 As MySqlDataReader
                Dim dt1 = New DataTable()
                dt1.Columns.Add("Account_number")
                dt1.Columns.Add("Customer_name")
                dt1.Rows.Add("0", "")
                command1.CommandText = sql
                Reader1 = command1.ExecuteReader()
                dt1.Load(Reader1)
                DB_CLOSE()
                Panel2.AutoScroll = True
                Panel2.AutoScrollPosition = New Point(Panel2.AutoScrollPosition.X, Panel2.VerticalScroll.Maximum)

                companynumber_all_1 = companynumber_all_1.Remove(0, companynumber_all_1.IndexOf(","))
                companynumber_all_1 = companynumber_all_1.Remove(0, 1)
                If companynumber_all_1 Like "*,*" Then
                    ids = companynumber_all_1.Substring(0, companynumber_all_1.IndexOf(","))
                Else
                    ids = companynumber_all_1
                End If
                Dim ComboBox As ComboBox = New ComboBox

                Dim count As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
                'textbox.Location = New System.Drawing.Point(10, (25 * count))

                If count = 1 Then
                    ComboBox.Location = New System.Drawing.Point(85, 80)
                ElseIf count = 2 Then
                    ComboBox.Location = New System.Drawing.Point(85, (70 + (23 * count)))
                ElseIf count = 3 Then
                    ComboBox.Location = New System.Drawing.Point(85, (70 + (25 * count)))
                ElseIf count = 6 Then
                    ComboBox.Location = New System.Drawing.Point(85, 185)
                Else
                    ComboBox.Location = New System.Drawing.Point(85, 210)
                End If

                ComboBox.Size = New System.Drawing.Size(515, 24)
                ComboBox.Name = "drp" & (count + 1)
                ComboBox.DataSource = dt1
                ComboBox.ValueMember = "Account_number"
                ComboBox.DisplayMember = "Customer_name"
                ComboBox.SelectedValue = ids

                P_PRAM1 = ComboBox.Name
                Panel2.Controls.Add(ComboBox)
                Dim txt As ComboBox = CType(Panel2.Controls.Find(("drp" & (count + 1)), True)(0), ComboBox)
                txt.SelectedValue = ids

                Dim CheckBox As CheckBox = New CheckBox
                If count = 1 Then
                    CheckBox.Location = New System.Drawing.Point(620, 80)
                ElseIf count = 2 Then
                    CheckBox.Location = New System.Drawing.Point(620, (70 + (23 * count)))
                ElseIf count = 3 Then
                    CheckBox.Location = New System.Drawing.Point(620, (70 + (25 * count)))
                ElseIf count = 6 Then
                    CheckBox.Location = New System.Drawing.Point(620, 185)
                Else
                    CheckBox.Location = New System.Drawing.Point(620, 210)
                End If
                CheckBox.Name = "btnDelete_" & (count + 1)
                CheckBox.Size = New System.Drawing.Size(20, 20)
                CheckBox.Text = ""

                'AddHandler CheckBox.Click, AddressOf Me.btnDelete_Click
                Panel2.Controls.Add(CheckBox)

            Next
            Dim i = 1
            ids = companynumber_all.Substring(0, 1)

            companynumber_all_1 = companynumber_all


            companynumber_all = ""
        End If
    End Sub
    Sub getID()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT MAX(id)+1 as id FROM t20_contract_management  "

        Try
            'DB_OPEN()
            flag = DB_OPEN()
            If flag = True Then
                Dim command As MySqlCommand = cnn.CreateCommand()
                command.CommandText = sql
                Dim Reader As MySqlDataReader
                Reader = command.ExecuteReader()
                Dim dt = New DataTable()
                dt.Load(Reader)
                DB_CLOSE()

                If Not IsDBNull(dt.Rows(0)("id")) Then
                    TextBox3.Text = dt.Rows(0)("id")
                    Label6.Text = dt.Rows(0)("id")
                Else
                    TextBox3.Text = 1
                    Label6.Text = 1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Sub ComboBox001()
    '    Dim strSQL As String = Nothing
    '    Dim BindValues As String = Nothing
    '    sql = "SELECT 取引先名, 取引先番号 "
    '    sql += "FROM Tm14_取引先マスター"
    '    Try
    '        DB_OPEN()
    '        Dim command As MySqlCommand = cnn.CreateCommand()
    '        command.CommandText = sql
    '        adapter.SelectCommand = command
    '        adapter.Fill(ds)
    '        adapter.Dispose()
    '        command.Dispose()
    '        DB_CLOSE()
    '        For Each drDealer In ds.Tables(0).Rows
    '            BindValues = drDealer("取引先名") & " : " & drDealer("取引先番号")
    '            ComboBox1.Items.Add(BindValues)
    '        Next
    '        'ComboBox1.DataSource = ds.Tables(0)
    '        ComboBox1.ValueMember = "取引先番号"
    '        ComboBox1.DisplayMember = BindValues
    '        'ComboBox1.DisplayMember = "ID"
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Sub ComboBox002()
        'Dim strSQL As String = Nothing
        'Dim BindValues As String = Nothing
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "

        'Try
        '    DB_OPEN()
        '    Dim command As MySqlCommand = cnn.CreateCommand()
        '    'command.CommandText = sql
        '    'adapter.SelectCommand = command
        '    'adapter.Fill(ds)
        '    'adapter.Dispose()
        '    'command.Dispose()
        '    Dim Reader As MySqlDataReader
        '    Dim dt = New DataTable()
        '    dt.Columns.Add("Account_number")
        '    dt.Columns.Add("Customer_name")
        '    dt.Rows.Add("0", "")
        '    command.CommandText = sql
        '    Reader = command.ExecuteReader()
        '    dt.Load(Reader)
        '    DB_CLOSE()
        '    If Not String.IsNullOrEmpty(Temporarycompanynumber1) Then
        '        ComboBox2.SelectedValue = Temporarycompanynumber1
        '        Temporarycompanynumber1 = 0
        '    End If
        '    ComboBox2.DataSource = dt
        '    ComboBox2.ValueMember = "Account_number"
        '    ComboBox2.DisplayMember = "Customer_name"
        '    'ComboBox1.DisplayMember = "ID"
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        'If ComboBox1.SelectedValue <> 0 Then
        'P_PRAM1 = ComboBox1.SelectedValue
        'Else
        If flagbool = False Then
            If ComboBox2.SelectedValue <> 0 Then
                P_PRAM1 = ComboBox2.SelectedValue
            Else
                P_PRAM1 = ComboBox1.SelectedValue
            End If
        Else
            P_PRAM1 = ComboBox1.SelectedValue
        End If
        'End If
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        'dt.Rows.Add("0", "")

        Try
            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 "
                If Temporarycompanynumber1 <> "0" Then
                    sql += "and`Account_number`=" + Convert.ToString(Temporarycompanynumber1)
                End If
            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where  `Delete`=0"

            End If

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox2.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox2.SelectedValue, ComboBox2.Text)
                'End If
            End If
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM1 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM1 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox2.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox2.SelectedValue, ComboBox2.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If

            ComboBox2.DataSource = Nothing
            ComboBox2.Items.Clear()
            ComboBox2.DataSource = dt
            ComboBox2.ValueMember = "Account_number"
            ComboBox2.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
            If (P_PRAM1 <> Nothing) Then
                ComboBox2.SelectedValue = P_PRAM1
            Else
                ComboBox2.SelectedValue = ""
                ComboBox2.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber1) Then
                    ComboBox2.SelectedValue = Temporarycompanynumber1
                    Temporarycompanynumber1 = 0
                End If
            Else
                'ComboBox2.SelectedValue = ""
                'ComboBox2.Text = ""
            End If

            'If dt.Rows.Count = 1 Then
            '    MessageBox.Show("指定された検索条件に一致するものが見つかりませんでした。")
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ComboBox003()
        'Dim strSQL As String = Nothing
        'Dim BindValues As String = Nothing
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "

        'Try
        '    DB_OPEN()
        '    Dim command As MySqlCommand = cnn.CreateCommand()
        '    'command.CommandText = sql
        '    'adapter.SelectCommand = command
        '    'adapter.Fill(ds)
        '    'adapter.Dispose()
        '    'command.Dispose()
        '    Dim Reader As MySqlDataReader
        '    Dim dt = New DataTable()
        '    dt.Columns.Add("Account_number")
        '    dt.Columns.Add("Customer_name")
        '    dt.Rows.Add("0", "")
        '    command.CommandText = sql
        '    Reader = command.ExecuteReader()
        '    dt.Load(Reader)
        '    DB_CLOSE()

        '    ComboBox3.DataSource = dt
        '    ComboBox3.ValueMember = "Account_number"
        '    ComboBox3.DisplayMember = "Customer_name"
        '    'ComboBox1.DisplayMember = "ID"
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        'P_PRAM2 = ComboBox3.SelectedValue
        If flagbool = False Then
            If ComboBox3.SelectedValue <> 0 Then
                P_PRAM2 = ComboBox3.SelectedValue
            Else
                P_PRAM2 = ComboBox1.SelectedValue
            End If
        Else
            P_PRAM2 = ComboBox1.SelectedValue
        End If
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        ' dt.Rows.Add("0", "")
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0"

        Try

            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 and `Account_number`=" + Convert.ToString(Temporarycompanynumber2)

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0"

            End If
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                ' command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox3.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox3.SelectedValue, ComboBox3.Text)
                'End If
            End If
            'command.CommandText = sql
            'adapter.SelectCommand = command
            'adapter.Fill(ds)
            'adapter.Dispose()
            'command.Dispose()
            Dim Reader As MySqlDataReader


            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM2 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM2 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox3.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox3.SelectedValue, ComboBox3.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If
            ComboBox3.DataSource = dt
            ComboBox3.ValueMember = "Account_number"
            ComboBox3.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
            If (P_PRAM2 <> Nothing) Then
                ComboBox3.SelectedValue = P_PRAM2
            Else
                ComboBox3.SelectedValue = ""
                ComboBox3.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber2) Then
                    ComboBox3.SelectedValue = Temporarycompanynumber2
                    Temporarycompanynumber2 = 0
                End If
            Else
                'ComboBox3.SelectedValue = ""
                'ComboBox3.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ComboBox004()
        'Dim strSQL As String = Nothing
        'Dim BindValues As String = Nothing
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "

        'Try
        '    DB_OPEN()
        '    Dim command As MySqlCommand = cnn.CreateCommand()
        '    Dim Reader As MySqlDataReader
        '    Dim dt = New DataTable()
        '    dt.Columns.Add("Account_number")
        '    dt.Columns.Add("Customer_name")
        '    dt.Rows.Add("0", "")
        '    command.CommandText = sql
        '    Reader = command.ExecuteReader()
        '    dt.Load(Reader)
        '    DB_CLOSE()

        '    ComboBox4.DataSource = dt
        '    ComboBox4.ValueMember = "Account_number"
        '    ComboBox4.DisplayMember = "Customer_name"
        '    'ComboBox1.DisplayMember = "ID"
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        If flagbool = False Then
            If ComboBox4.SelectedValue <> 0 Then
                P_PRAM3 = ComboBox4.SelectedValue
            Else
                P_PRAM3 = ComboBox1.SelectedValue
            End If
        Else
            P_PRAM3 = ComboBox1.SelectedValue
        End If

        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        'dt.Rows.Add("0", "")
        'P_PRAM3 = ComboBox4.SelectedValue

        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0"

        Try
            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 and `Account_number`=" + Convert.ToString(Temporarycompanynumber3)

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0"

            End If

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox4.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox4.SelectedValue, ComboBox4.Text)
                'End If
            End If
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM3 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM3 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox4.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox4.SelectedValue, ComboBox4.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If
            ComboBox4.DataSource = dt
            ComboBox4.ValueMember = "Account_number"
            ComboBox4.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
            If (P_PRAM3 <> Nothing) Then
                ComboBox4.SelectedValue = P_PRAM3
            Else
                ComboBox4.SelectedValue = ""
                ComboBox4.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber3) Then
                    ComboBox4.SelectedValue = Temporarycompanynumber3
                    Temporarycompanynumber3 = 0
                End If
            Else
                'ComboBox4.SelectedValue = ""
                'ComboBox4.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox005()
        'Dim strSQL As String = Nothing
        'Dim BindValues As String = Nothing
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "

        'Try
        '    DB_OPEN()
        '    Dim command As MySqlCommand = cnn.CreateCommand()
        '    Dim Reader As MySqlDataReader
        '    Dim dt = New DataTable()
        '    dt.Columns.Add("Account_number")
        '    dt.Columns.Add("Customer_name")
        '    dt.Rows.Add("0", "")
        '    command.CommandText = sql
        '    Reader = command.ExecuteReader()
        '    dt.Load(Reader)
        '    DB_CLOSE()

        '    ComboBox5.DataSource = dt
        '    ComboBox5.ValueMember = "Account_number"
        '    ComboBox5.DisplayMember = "Customer_name"
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        If flagbool = False Then
            If ComboBox5.SelectedValue <> 0 Then
                P_PRAM4 = ComboBox5.SelectedValue
            Else
                P_PRAM4 = ComboBox1.SelectedValue
            End If
        Else
            P_PRAM4 = ComboBox1.SelectedValue
        End If
        'P_PRAM4 = ComboBox4.SelectedValue
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        ' dt.Rows.Add("0", "")

        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0"

        Try
            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 and `Account_number`=" + Convert.ToString(Temporarycompanynumber4)

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0"

            End If
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox5.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox5.SelectedValue, ComboBox5.Text)
                'End If
            End If
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM4 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM4 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox5.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox5.SelectedValue, ComboBox5.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If
            ComboBox5.DataSource = dt
            ComboBox5.ValueMember = "Account_number"
            ComboBox5.DisplayMember = "Customer_name"
            If (P_PRAM4 <> Nothing) Then
                ComboBox5.SelectedValue = P_PRAM4
            Else
                ComboBox5.SelectedValue = ""
                ComboBox5.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber4) Then
                    ComboBox5.SelectedValue = Temporarycompanynumber4
                    Temporarycompanynumber4 = 0
                End If
            Else
                'ComboBox5.SelectedValue = ""
                'ComboBox5.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox006()
        'Dim strSQL As String = Nothing
        'Dim BindValues As String = Nothing
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "

        'Try
        '    DB_OPEN()
        '    Dim command As MySqlCommand = cnn.CreateCommand()
        '    Dim Reader As MySqlDataReader
        '    Dim dt = New DataTable()
        '    dt.Columns.Add("Account_number")
        '    dt.Columns.Add("Customer_name")
        '    dt.Rows.Add("0", "")
        '    command.CommandText = sql
        '    Reader = command.ExecuteReader()
        '    dt.Load(Reader)
        '    DB_CLOSE()

        '    ComboBox6.DataSource = dt
        '    ComboBox6.ValueMember = "Account_number"
        '    ComboBox6.DisplayMember = "Customer_name"
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        If flagbool = False Then
            If ComboBox6.SelectedValue <> 0 Then
                P_PRAM5 = ComboBox6.SelectedValue
            Else
                P_PRAM5 = ComboBox1.SelectedValue
            End If
        Else
            P_PRAM5 = ComboBox1.SelectedValue
        End If
        'P_PRAM5 = ComboBox6.SelectedValue
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        'dt.Rows.Add("0", "")
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0 "

        Try
            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 and `Account_number`=" + Convert.ToString(Temporarycompanynumber5)

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0"

            End If
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                ' command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox6.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox6.SelectedValue, ComboBox6.Text)
                'End If
            End If
            Dim Reader As MySqlDataReader


            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM5 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM5 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox6.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox6.SelectedValue, ComboBox6.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If
            ComboBox6.DataSource = dt
            ComboBox6.ValueMember = "Account_number"
            ComboBox6.DisplayMember = "Customer_name"
            If (P_PRAM5 <> Nothing) Then
                ComboBox6.SelectedValue = P_PRAM5
            Else
                ComboBox6.SelectedValue = ""
                ComboBox6.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber5) Then
                    ComboBox6.SelectedValue = Temporarycompanynumber5
                    Temporarycompanynumber5 = 0
                End If
            Else
                'ComboBox6.SelectedValue = ""
                'ComboBox6.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Try
            If ComboBox2.SelectedValue = 0 Then
                ComboBox2.Focus()
                MessageBox.Show("取引先名を入力してください。")
                Exit Sub
            End If
            If TextBox21.Text.Trim = "" Then
                TextBox21.Focus()
                MessageBox.Show("契約書名を入力してください。")
                Exit Sub
            End If
            If DateTimePicker1.Text.Trim = "" Then
                DateTimePicker1.Focus()
                MessageBox.Show("契約日を入力してください。")
                Exit Sub
            End If
            If ComboBox7.SelectedValue = "none" Then
                ComboBox7.Focus()

                MessageBox.Show("更新コードを入力してください。")

                Exit Sub
            End If
            If ComboBox7.SelectedValue = Nothing Then
                ComboBox7.Focus()

                MessageBox.Show("更新コードを入力してください。")

                Exit Sub
            End If
            If insert = True Then
                insertdata()

                Exit Sub
            End If
            Dim Msg As String = ""
            Msg = CheckIsEmpty()
            If Msg <> "" Then
                MessageBox.Show(Msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Updatedata()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            DB_CLOSE()
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()

        'Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'F12_取引先マスター
        Dim F12_取引先マスター As New F12_取引先マスター
        Me.Hide()
        F12_取引先マスター.ShowDialog()
        'ComboBox002()
        'ComboBox003()
        'ComboBox004()
        'ComboBox005()
        'ComboBox006()
        cmbremove()
        Me.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim F14_取引先マスター一覧 As New F14_取引先マスター一覧
        Me.Hide()
        F14_取引先マスター一覧.ShowDialog()
        'ComboBox002()
        'ComboBox003()
        'ComboBox004()
        'ComboBox005()
        'ComboBox006()

        cmbremove()
        Me.Show()
    End Sub
    Private Sub Updatedata()

        If ComboBox2.SelectedValue = 0 Then
            ComboBox2.Focus()
            MessageBox.Show("取引先名を入力してください。")
            Exit Sub
        End If
        If TextBox21.Text.Trim = "" Then
            TextBox21.Focus()
            MessageBox.Show("契約書名を入力してください。")
            Exit Sub
        End If

        If ComboBox7.SelectedValue = "none" Then
            ComboBox7.Focus()
            MessageBox.Show("更新コードを入力してください。")

            Exit Sub
        End If
        getdropvalue()

        DB_OPEN()
        Dim command As MySqlCommand = cnn.CreateCommand()
        Dim id = 0
        Dim Reader As MySqlDataReader
        Dim query1 As String = "select MAX(Id) as Id FROM t20_contract_management "
        command.CommandText = query1
        Reader = command.ExecuteReader()
        While Reader.Read
            id = Reader("id")
        End While
        DB_CLOSE()
        DB_OPEN()
        Dim Yomigana = ""
        query1 = ""
        query1 = "select *   FROM tm14_account_master where  `Account_number`=@Account_number1 "
        command.Parameters.AddWithValue("Account_number1", ComboBox2.SelectedValue)
        command.CommandText = query1
        Reader = command.ExecuteReader()
        While Reader.Read
            If Not IsDBNull(Reader("Yomigana")) Then
                Yomigana = Reader("Yomigana")
            Else
                Yomigana = ""
            End If


        End While

        DB_CLOSE()
        DB_OPEN()

        Dim query As String = "Update t20_contract_management set "

        query += "`Control_number`=@Controlnumber,"
        query += "`India_contract`=@Indiacontract,"
        query += "`Temporary_number`=@Temporarynumber,"
        query += "`Branch_number`=@Branchnumber,"
        query += "`Old_number`=@Oldnumber,"
        query += "`Contract_date`=@Contractdate,"
        query += "`Contract_period_starts`=@Contractperiodstarts,"
        query += "`Scheduled_end_date_of_contract_period`=@Scheduledenddateofcontractperiod,"
        query += "`End_date`=@Enddate,"
        query += "`Update_code`=@Updatecode,"
        query += "`Automatic_update_interval`=@Automaticupdateinterval,"
        query += "`Account_number_all`=@customerNumber,"
        query += "`Account_name_all`=@customername_all,"
        query += "`Yomigana_All`=@Yomigana_All,"
        query += "`Account_number`=@Accountnumber,"
        query += "`Contract_name`=@Contractname,"
        query += "`Department_number`=@Departmentnumber,"
        query += "`Contractor`=@Contractor,"
        query += "`remarks`=@remarks,"
        query += "`End`=@end,"
        query += "`Delete`=@Delete,"
        query += "`India`=@India,"
        query += "`Temporary_company_number_1`=@Temporarycompanynumber1,"
        query += "`Temporary_company_number_2`=@Temporarycompanynumber2,"
        query += "`Temporary_company_number_3`=@Temporarycompanynumber3,"
        query += "`Temporary_company_number_4`=@Temporarycompanynumber4,"
        query += "`Temporary_company_number_5`=@Temporarycompanynumber5, "
        query += "`Survey_Date`=@Surveydate, "
        query += "`company_Number_all`=@company_Number_all "
        query += "where ID=@ID"


        command.Parameters.AddWithValue("ID", TextBox3.Text)
        command.Parameters.AddWithValue("company_Number_all", P_PRAM2)
        If Not String.IsNullOrEmpty(Mgt_number) Then
            command.Parameters.AddWithValue("Controlnumber", Mgt_number)
        Else
            command.Parameters.AddWithValue("Controlnumber", DBNull.Value)
        End If

        command.Parameters.AddWithValue("Indiacontract", "")
        command.Parameters.AddWithValue("Temporarynumber", id)
        command.Parameters.AddWithValue("Branchnumber", TextBox5.Text)
        command.Parameters.AddWithValue("Oldnumber", TextBox4.Text)
        If DateTimePicker1.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Contractdate", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Contractdate", Convert.ToDateTime(DateTimePicker1.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker2.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Contractperiodstarts", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Contractperiodstarts", Convert.ToDateTime(DateTimePicker2.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker3.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Enddate", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Enddate", Convert.ToDateTime(DateTimePicker3.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker4.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", Convert.ToDateTime(DateTimePicker4.Text).ToString("yyyy-MM-dd"))
        End If
        command.Parameters.AddWithValue("Updatecode", ComboBox7.SelectedValue)
        command.Parameters.AddWithValue("Automaticupdateinterval", ComboBox8.SelectedValue)
        command.Parameters.AddWithValue("customerNumber", ComboBox2.SelectedValue)
        command.Parameters.AddWithValue("customername_all", P_PRAM3)
        command.Parameters.AddWithValue("Yomigana_All", P_PRAM4)
        command.Parameters.AddWithValue("Accountnumber", ComboBox2.SelectedValue)
        command.Parameters.AddWithValue("Contractname", TextBox21.Text)
        command.Parameters.AddWithValue("Departmentnumber", ComboBox9.SelectedValue)
        command.Parameters.AddWithValue("Contractor", TextBox27.Text)
        command.Parameters.AddWithValue("remarks", TextBox24.Text)
        If CheckBox7.Checked = True Then
            command.Parameters.AddWithValue("end", 1)
        Else
            command.Parameters.AddWithValue("end", 0)
        End If

        command.Parameters.AddWithValue("Delete", 0)
        Dim delindia = 0
        If (CheckBox1.Checked = True) Then
            delindia = 1
        End If
        command.Parameters.AddWithValue("India", delindia)
        If CheckBox3.Checked = True Then
            command.Parameters.AddWithValue("Temporarycompanynumber2", 0)
        Else

            command.Parameters.AddWithValue("Temporarycompanynumber2", ComboBox3.SelectedValue)
        End If
        If CheckBox4.Checked = True Then
            command.Parameters.AddWithValue("Temporarycompanynumber3", 0)
        Else
            command.Parameters.AddWithValue("Temporarycompanynumber3", ComboBox4.SelectedValue)
        End If
        If CheckBox5.Checked = True Then
            command.Parameters.AddWithValue("Temporarycompanynumber4", 0)
        Else
            command.Parameters.AddWithValue("Temporarycompanynumber4", ComboBox5.SelectedValue)


        End If
        If CheckBox6.Checked = True Then

            command.Parameters.AddWithValue("Temporarycompanynumber5", 0)
        Else

            command.Parameters.AddWithValue("Temporarycompanynumber5", ComboBox6.SelectedValue)

        End If

        command.Parameters.AddWithValue("Temporarycompanynumber1", ComboBox2.SelectedValue)

        If DateTimePicker5.Text.Trim() = "" Then

            command.Parameters.AddWithValue("Surveydate", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Surveydate", DateTimePicker5.Text)
        End If

        command.CommandText = query
        Dim result As Int16 = command.ExecuteNonQuery()
        DB_CLOSE()
        If (result > 0) Then
            Me.Controls.Clear()
            Me.InitializeComponent()
            P_PRAM3 = ""
            P_PRAM2 = ""
            binddata()
            'ComboBox008()
            getID()
            Label2.Text = "キー番号"
            MessageBox.Show("データが正常に更新されました")
            Mgt_number = ""
            Me.Close()
        End If


    End Sub
    Private Sub insertdata()


        If ComboBox2.SelectedValue = 0 Then
            ComboBox2.Focus()
            MessageBox.Show("取引先名を入力してください。")
            Exit Sub
        End If
        If TextBox21.Text.Trim = "" Then
            TextBox21.Focus()
            MessageBox.Show("契約書名を入力してください。")
            Exit Sub
        End If
        If ComboBox7.SelectedValue = "none" Then
            ComboBox7.Focus()
            MessageBox.Show("更新コードを入力してください。")

            Exit Sub
        End If
        getdropvalue()
        DB_OPEN()
        Dim command As MySqlCommand = cnn.CreateCommand()
        Dim id = 0
        Dim Reader As MySqlDataReader
        Dim query1 As String = "select MAX(Id)+1 as Id FROM t20_contract_management "
        command.CommandText = query1
        Reader = command.ExecuteReader()
        While Reader.Read
            If Not IsDBNull(Reader("id")) Then
                id = Reader("id")
            Else
                id = 1
            End If


        End While

        DB_CLOSE()
        DB_OPEN()
        Dim Yomigana = ""
        query1 = ""
        query1 = "select *   FROM tm14_account_master where  `Account_number`=@Accountnumber1 "
        command.Parameters.AddWithValue("Accountnumber1", ComboBox2.SelectedValue)
        command.CommandText = query1
        Reader = command.ExecuteReader()
        While Reader.Read
            If Not IsDBNull(Reader("Yomigana")) Then
                Yomigana = Reader("Yomigana")
            Else
                Yomigana = ""
            End If


        End While

        DB_CLOSE()
        DB_OPEN()
        Dim query As String = "INSERT INTO t20_contract_management"
        query += "(`ID`,"
        query += "`Control_number`,"
        query += "`India_contract`,"
        query += "`Temporary_number`,"
        query += "`Branch_number`,"
        query += "`Old_number`,"
        query += "`Contract_date`,"
        query += "`Contract_period_starts`,"
        query += "`Scheduled_end_date_of_contract_period`,"
        query += "`End_date`,"
        query += "`Update_code`,"
        query += "`Automatic_update_interval`,"
        query += "`Account_number_all`,"
        query += "`Account_name_all`,"
        query += "`Yomigana_All`,"
        query += "`Account_number`,"
        query += "`Contract_name`,"
        query += "`Department_number`,"
        query += "`Contractor`,"
        query += "`remarks`,"
        query += "`End`,"
        query += "`Delete`,"
        query += "`India`,"
        query += "`Temporary_company_number_1`,"
        query += "`Temporary_company_number_2`,"
        query += "`Temporary_company_number_3`,"
        query += "`Temporary_company_number_4`,"
        query += "`Temporary_company_number_5`,"
        query += "`Survey_Date`,"
        query += "`company_Number_all`)"


        query += "VALUES"
        query += "(@ID,"
        query += "@Controlnumber,"
        query += "@Indiacontract,"
        query += "@Temporarynumber,"
        query += "@Branchnumber,"
        query += "@Oldnumber,"
        query += "@Contractdate,"
        query += "@Contractperiodstarts,"
        query += "@Scheduledenddateofcontractperiod,"
        query += "@Enddate,"
        query += "@Updatecode,"
        query += "@Automaticupdateinterval,"
        query += "@customerNumber,"
        query += "@customername_all,"
        query += "@Yomigana_All,"
        query += "@Accountnumber,"
        query += "@Contractname,"
        query += "@Departmentnumber,"
        query += "@Contractor,"
        query += "@remarks,"
        query += "@end,"
        query += "@Delete,"
        query += "@India,"
        query += "@Temporarycompanynumber1,"
        query += "@Temporarycompanynumber2,"
        query += "@Temporarycompanynumber3,"
        query += "@Temporarycompanynumber4,"
        query += "@Temporarycompanynumber5,"
        query += "@Surveydate,"
        query += "@company_Number_all);"

        command.Parameters.AddWithValue("company_Number_all", P_PRAM2)
        command.Parameters.AddWithValue("ID", TextBox3.Text)
        'command.Parameters.AddWithValue("Controlnumber", TextBox3.Text)
        command.Parameters.AddWithValue("Controlnumber", DBNull.Value)
        command.Parameters.AddWithValue("Indiacontract", "")
        command.Parameters.AddWithValue("Temporarynumber", id)
        command.Parameters.AddWithValue("Branchnumber", TextBox5.Text)
        command.Parameters.AddWithValue("Oldnumber", TextBox4.Text)
        If DateTimePicker1.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Contractdate", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Contractdate", Convert.ToDateTime(DateTimePicker1.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker2.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Contractperiodstarts", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Contractperiodstarts", Convert.ToDateTime(DateTimePicker2.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker3.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Enddate", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Enddate", Convert.ToDateTime(DateTimePicker3.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker4.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", Convert.ToDateTime(DateTimePicker4.Text).ToString("yyyy-MM-dd"))
        End If

        command.Parameters.AddWithValue("Updatecode", ComboBox7.SelectedValue)
        command.Parameters.AddWithValue("Automaticupdateinterval", ComboBox8.SelectedValue)
        command.Parameters.AddWithValue("customerNumber", ComboBox2.SelectedValue)
        'Dim cname As String = ComboBox2.Text + "," + ComboBox3.Text + "," + ComboBox4.Text + "," + ComboBox5.Text + "," + ComboBox6.Text + "," + P_PRAM3
        command.Parameters.AddWithValue("customername_all", P_PRAM3)
        P_PRAM3 = ""
        command.Parameters.AddWithValue("Yomigana_All", P_PRAM4)
        P_PRAM4 = ""
        command.Parameters.AddWithValue("Accountnumber", ComboBox2.SelectedValue)
        command.Parameters.AddWithValue("Contractname", TextBox21.Text)
        command.Parameters.AddWithValue("Departmentnumber", ComboBox9.SelectedValue)
        command.Parameters.AddWithValue("Contractor", TextBox27.Text)
        command.Parameters.AddWithValue("remarks", TextBox24.Text)
        If CheckBox7.Checked = True Then
            command.Parameters.AddWithValue("end", 1)
        Else
            command.Parameters.AddWithValue("end", 0)
        End If
        command.Parameters.AddWithValue("Delete", 0)
        Dim delindia = 0
        If (CheckBox1.Checked = True) Then
            delindia = 1
        End If
        command.Parameters.AddWithValue("India", delindia)
        If CheckBox3.Checked = True Then
            command.Parameters.AddWithValue("Temporarycompanynumber2", 0)
        Else

            command.Parameters.AddWithValue("Temporarycompanynumber2", ComboBox3.SelectedValue)
        End If
        If CheckBox4.Checked = True Then
            command.Parameters.AddWithValue("Temporarycompanynumber3", 0)
        Else
            command.Parameters.AddWithValue("Temporarycompanynumber3", ComboBox4.SelectedValue)
        End If
        If CheckBox5.Checked = True Then
            command.Parameters.AddWithValue("Temporarycompanynumber4", 0)


        Else
            command.Parameters.AddWithValue("Temporarycompanynumber4", ComboBox5.SelectedValue)


        End If
        If CheckBox6.Checked = True Then

            command.Parameters.AddWithValue("Temporarycompanynumber5", 0)
        Else

            command.Parameters.AddWithValue("Temporarycompanynumber5", ComboBox6.SelectedValue)

        End If

        command.Parameters.AddWithValue("Temporarycompanynumber1", ComboBox2.SelectedValue)
        If DateTimePicker5.Text.Trim() = "" Then

            command.Parameters.AddWithValue("Surveydate", DBNull.Value)
        Else
            command.Parameters.AddWithValue("Surveydate", DateTimePicker5.Text)
        End If

        command.CommandText = query
        Dim result As Int16 = command.ExecuteNonQuery()
        DB_CLOSE()
        If (result = 1) Then
            Me.Controls.Clear()
            Me.InitializeComponent()
            P_PRAM3 = ""
            P_PRAM2 = ""
            inz()
            binddata()
            'ComboBox008()
            getID()
            Label2.Text = "キー番号"
            MessageBox.Show("データが正常に登録されました。")

        End If
    End Sub
    Sub ComboBox007()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        'sql = "SELECT * from tm19_update_code_master"
        sql = "SELECT Update_code, CONCAT(Update_code,' : ',Update_code_details) as Update_code_details , ID "
        sql += "FROM tm19_update_code_master"
        Try

            DB_OPEN()

            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("ID")
            dt.Columns.Add("Update_code")
            dt.Columns.Add("Update_code_details")
            dt.Rows.Add("none", "none", "")
            command.CommandText = sql
            Reader = command.ExecuteReader()

            dt.Load(Reader)
            DB_CLOSE()


            ComboBox7.ValueMember = "Update_code"
            ComboBox7.DisplayMember = "Update_code_details"
            ComboBox7.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox008()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing


        Try
            Dim dt = New DataTable()
            dt.Columns.Add("ID")
            dt.Columns.Add("month")

            'dt.Rows.Add("0", "")

            dt.Rows.Add("３か月", "３か月")
            dt.Rows.Add("１年", "１年")
            dt.Rows.Add("２年", "２年")
            dt.Rows.Add("３年", "３年")
            dt.Rows.Add("協議", "協議")
            dt.Rows.Add("その他：備考欄に記入", "その他：備考欄に記入")



            ComboBox8.ValueMember = "ID"
            ComboBox8.DisplayMember = "month"
            ComboBox8.DataSource = dt
            ComboBox8.SelectedValue = ""
            ComboBox8.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox009()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT ID ,Department_number, Management_department "
        sql += "FROM tm15_department_master "
        sql += "WHERE (((`Delete` ) Is Null Or (`Delete` )=False));"

        Try
            Dim dt = New DataTable()
            dt.Columns.Add("Department_number")
            dt.Columns.Add("Management_department")
            dt.Rows.Add("0", "")
            DB_OPEN()

            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()

            dt.Load(Reader)
            DB_CLOSE()


            ComboBox9.ValueMember = "Department_number"
            ComboBox9.DisplayMember = "Management_department"
            ComboBox9.DataSource = dt
        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function CheckIsEmpty() As String
        Dim Msg As String = ""
        'If TextBox3.Text.Trim() = "" Then
        '    Msg = "管理番号を入力してください。"
        '    TextBox3.Focus()
        '    Return Msg
        'ElseIf ComboBox2.SelectedIndex = -1 Then
        '    Msg = "Please select DropDown"
        '    ComboBox2.Focus()
        '    Return Msg
        If TextBox21.Text.Trim() = "" Then
            Msg = "契約書名を入力してください。"
            TextBox21.Focus()
            Return Msg
        ElseIf DateTimePicker1.CustomFormat = " " Then
            Msg = "契約日を入力してください。"
            DateTimePicker1.Focus()
            Return Msg
            'ElseIf ComboBox7.SelectedIndex = -1 Then
            '    Msg = "Please select DropDown"
            '    ComboBox7.Focus()
            '    Return Msg
        Else
            Return Msg
        End If


    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'P_PRAM1 = ComboBox2.SelectedValue
        'P_PRAM2 = ComboBox3.SelectedValue
        'P_PRAM3 = ComboBox4.SelectedValue
        'P_PRAM4 = ComboBox5.SelectedValue
        'P_PRAM5 = ComboBox6.SelectedValue
        'ComboBox02_1()
        'ComboBox03_1()
        'ComboBox04_1()
        'ComboBox05_1()
        'ComboBox06_1()
        'If (P_PRAM1 <> Nothing) Then
        '    ComboBox2.SelectedValue = P_PRAM1
        'End If
        'If (P_PRAM2 <> Nothing) Then
        '    ComboBox3.SelectedValue = P_PRAM2
        'End If
        'If (P_PRAM3 <> Nothing) Then
        '    ComboBox4.SelectedValue = P_PRAM3
        'End If
        'If (P_PRAM4 <> Nothing) Then
        '    ComboBox5.SelectedValue = P_PRAM4
        'End If
        'If (P_PRAM5 <> Nothing) Then
        '    ComboBox6.SelectedValue = P_PRAM5
        'End If


        'ComboBox2_Enter(sender, e)
        checkdata()

        cmbAdd()
    End Sub
    Sub cmbAdd()
        Dim i = 6
        Dim Index As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
        sql += " and Customer_name like @CSearch "
        Try



            For Index = 7 To Index

                DB_OPEN()
                Dim command As MySqlCommand = cnn.CreateCommand()

                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim Reader As MySqlDataReader
                Dim dt = New DataTable()
                dt.Columns.Add("Account_number")
                dt.Columns.Add("Customer_name")
                i += 1
                Dim cmb = "drp" + Convert.ToString(i)
                If cmb <> "drp1" Then
                    Dim txt As ComboBox = CType(Panel2.Controls.Find((cmb), True)(0), ComboBox)
                    Dim selectedvalue = txt.SelectedValue
                    Dim selectedtext = txt.Text


                    'If selectedtext.Trim <> "" Or IsDBNull(selectedtext) Then
                    '    dt.Rows.Add(selectedvalue, selectedtext)
                    'End If


                    command.CommandText = sql
                    Reader = command.ExecuteReader()
                    dt.Load(Reader)
                    DB_CLOSE()

                    If selectedtext.Trim <> "" Or IsDBNull(selectedtext) Then
                        Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) selectedvalue = row.Field(Of String)("Account_number"))
                        If exists = False Then
                            dt.Rows.Add(selectedvalue, selectedtext)
                        End If
                    End If
                    If dt.Rows.Count < 1 Then
                        dt.Rows.Add("", "")
                    End If
                    txt.DataSource = dt
                    txt.ValueMember = "Account_number"
                    txt.DisplayMember = "Customer_name"
                    If selectedtext.Trim <> "" Or IsDBNull(selectedtext) Then
                        txt.SelectedValue = selectedvalue
                    Else
                        txt.SelectedValue = ""
                        txt.Text = ""
                    End If
                End If


            Next

        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub cmbremove()
        Dim i = 6
        Dim Index As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
        'sql += "FROM Tm14_取引先マスター"
        Try

            For Index = 7 To Index

                DB_OPEN()
                Dim command As MySqlCommand = cnn.CreateCommand()
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
                Dim Reader As MySqlDataReader
                Dim dt = New DataTable()
                dt.Columns.Add("Account_number")
                dt.Columns.Add("Customer_name")
                i += 1
                Dim cmb = "drp" + Convert.ToString(i)
                If cmb <> "drp1" Then
                    Dim txt As ComboBox = CType(Panel2.Controls.Find((cmb), True)(0), ComboBox)
                    Dim selectedvalue = txt.SelectedValue
                    Dim selectedtext = txt.Text
                    'dt.Rows.Add("0", "")
                    command.CommandText = sql
                    Reader = command.ExecuteReader()
                    dt.Load(Reader)
                    DB_CLOSE()
                    txt.DataSource = dt
                    txt.ValueMember = "Account_number"
                    txt.DisplayMember = "Customer_name"
                    If (selectedtext.Trim <> "") Then
                        txt.SelectedValue = selectedvalue
                    Else
                        txt.SelectedValue = ""
                        txt.Text = ""

                    End If

                End If


            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox02_1()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
        sql += " and Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
            If textinput <> "" Then
                command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
            Else
                command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
            End If
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "")
            If ComboBox2.SelectedValue <> 0 Then
                dt.Rows.Add(ComboBox2.SelectedValue, ComboBox2.Text)
            End If
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox2.DataSource = dt
            ComboBox2.ValueMember = "Account_number"
            ComboBox2.DisplayMember = "Customer_name"

        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox03_1()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
        sql += " and Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
            If textinput <> "" Then
                command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
            Else
                command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
            End If
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "")
            If ComboBox3.SelectedValue <> 0 Then
                dt.Rows.Add(ComboBox3.SelectedValue, ComboBox3.Text)
            End If
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox3.DataSource = dt
            ComboBox3.ValueMember = "Account_number"
            ComboBox3.DisplayMember = "Customer_name"

        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox04_1()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
        sql += " and Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
            If textinput <> "" Then
                command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
            Else
                command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
            End If
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "")
            If ComboBox4.SelectedValue <> 0 Then
                dt.Rows.Add(ComboBox4.SelectedValue, ComboBox4.Text)
            End If
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox4.DataSource = dt
            ComboBox4.ValueMember = "Account_number"
            ComboBox4.DisplayMember = "Customer_name"

        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox05_1()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
        sql += " and Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
            If textinput <> "" Then
                command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
            Else
                command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
            End If
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "")
            If ComboBox5.SelectedValue <> 0 Then
                dt.Rows.Add(ComboBox5.SelectedValue, ComboBox5.Text)
            End If
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox5.DataSource = dt
            ComboBox5.ValueMember = "Account_number"
            ComboBox5.DisplayMember = "Customer_name"

        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox06_1()
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
        sql += " and Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
            If textinput <> "" Then
                command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
            Else
                command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
            End If
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "")
            If ComboBox6.SelectedValue <> 0 Then
                dt.Rows.Add(ComboBox6.SelectedValue, ComboBox6.Text)
            End If
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox6.DataSource = dt
            ComboBox6.ValueMember = "Account_number"
            ComboBox6.DisplayMember = "Customer_name"

        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Dim cmb1 = ComboBox2.SelectedValue
        'Dim cmb2 = ComboBox3.SelectedValue
        'Dim cmb3 = ComboBox4.SelectedValue
        'Dim cmb4 = ComboBox5.SelectedValue
        'Dim cmb5 = ComboBox6.SelectedValue
        'binddata()
        'ComboBox2.SelectedValue = cmb1
        'ComboBox3.SelectedValue = cmb2
        'ComboBox4.SelectedValue = cmb3
        'ComboBox5.SelectedValue = cmb4
        'ComboBox6.SelectedValue = cmb5
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox1.Focus()
        SendKeys.Send("{ENTER}")
        cmbremove()
    End Sub

    'Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    '    If (DateTimePicker1.Value = DateTimePicker.MinimumDateTime) Then

    '        DateTimePicker1.Value = DateTime.Now
    '        DateTimePicker1.Format = DateTimePickerFormat.Custom
    '        DateTimePicker1.CustomFormat = " "

    '    Else
    '        DateTimePicker1.Value = DateTime.Now
    '        DateTimePicker1.Format = DateTimePickerFormat.Custom
    '        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
    '    End If
    'End Sub

    'Private Sub DateTimePicker1_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.TextChanged
    '    If (DateTimePicker1.Value = DateTimePicker.MinimumDateTime) Then

    '        DateTimePicker1.Format = DateTimePickerFormat.Custom
    '        DateTimePicker1.CustomFormat = " "

    '    Else

    '        DateTimePicker1.Format = DateTimePickerFormat.Custom
    '        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
    '    End If
    'End Sub

    'Private Sub DateTimePicker2_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.TextChanged
    '    If (DateTimePicker2.Value = DateTimePicker.MinimumDateTime) Then

    '        DateTimePicker2.Format = DateTimePickerFormat.Custom
    '        DateTimePicker2.CustomFormat = " "
    '    Else

    '        DateTimePicker2.Format = DateTimePickerFormat.Custom
    '        DateTimePicker2.CustomFormat = "yyyy/MM/dd"
    '    End If
    'End Sub

    'Private Sub DateTimePicker3_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.TextChanged
    '    If (DateTimePicker3.Value = DateTimePicker.MinimumDateTime) Then

    '        DateTimePicker3.Format = DateTimePickerFormat.Custom
    '        DateTimePicker3.CustomFormat = " "
    '    Else

    '        DateTimePicker3.Format = DateTimePickerFormat.Custom
    '        DateTimePicker3.CustomFormat = "yyyy/MM/dd"
    '    End If
    'End Sub

    'Private Sub DateTimePicker4_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.TextChanged
    '    If (DateTimePicker4.Value = DateTimePicker.MinimumDateTime) Then

    '        DateTimePicker4.Format = DateTimePickerFormat.Custom
    '        DateTimePicker4.CustomFormat = " "
    '    Else

    '        DateTimePicker4.Format = DateTimePickerFormat.Custom
    '        DateTimePicker4.CustomFormat = "yyyy/MM/dd"
    '    End If
    'End Sub

    'Private Sub DateTimePicker5_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker5.TextChanged
    '    If (DateTimePicker5.Value = DateTimePicker.MinimumDateTime) Then

    '        DateTimePicker5.Format = DateTimePickerFormat.Custom
    '        DateTimePicker5.CustomFormat = " "
    '    Else

    '        DateTimePicker5.Format = DateTimePickerFormat.Custom
    '        DateTimePicker5.CustomFormat = "yyyy/MM/dd"
    '    End If
    'End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Panel2.AutoScroll = True
            Panel2.AutoScrollPosition = New Point(Panel2.AutoScrollPosition.X, Panel2.VerticalScroll.Maximum)

            Dim strSQL As String = Nothing
            Dim BindValues As String = Nothing
            Dim command As MySqlCommand = cnn.CreateCommand()
            sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                ' command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If

            End If
            DB_OPEN()


            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            'dt.Rows.Add("0", "")
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            Dim ComboBox As ComboBox = New ComboBox

            Dim count As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
            If count <> 25 Then
                If count = 1 Then
                    ComboBox.Location = New System.Drawing.Point(85, 80)

                ElseIf count = 2 Then
                    ComboBox.Location = New System.Drawing.Point(85, (70 + (23 * count)))
                ElseIf count = 3 Then
                    ComboBox.Location = New System.Drawing.Point(85, (70 + (25 * count)))
                ElseIf count = 6 Then
                    ComboBox.Location = New System.Drawing.Point(85, 185)
                Else
                    ComboBox.Location = New System.Drawing.Point(85, 210)
                End If

                ComboBox.Size = New System.Drawing.Size(520, 24)
                ComboBox.Name = "drp" & (count + 1)
                ComboBox.DataSource = dt
                ComboBox.ValueMember = "Account_number"
                ComboBox.DisplayMember = "Customer_name"
                P_PRAM1 = ComboBox.Name

                Panel2.Controls.Add(ComboBox)

                ComboBox.SelectedValue = ""
                Dim CheckBox As CheckBox = New CheckBox


                If count = 1 Then
                    CheckBox.Location = New System.Drawing.Point(620, 80)

                ElseIf count = 2 Then
                    CheckBox.Location = New System.Drawing.Point(620, (70 + (23 * count)))
                ElseIf count = 3 Then
                    CheckBox.Location = New System.Drawing.Point(620, (70 + (25 * count)))
                ElseIf count = 6 Then
                    CheckBox.Location = New System.Drawing.Point(620, 185)
                Else
                    CheckBox.Location = New System.Drawing.Point(620, 210)
                End If
                CheckBox.Name = "btnDelete_" & (count + 1)
                CheckBox.Size = New System.Drawing.Size(20, 20)
                CheckBox.Text = ""

                'AddHandler CheckBox.Click, AddressOf Me.btnDelete_Click
                Panel2.Controls.Add(CheckBox)
            Else
                MessageBox.Show("最大25フィールド")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub getdropvalue()
        Dim Yomigana = ""
        Dim Customer_name = ""
        Dim query1 = ""
        P_PRAM4 = ""
        Dim bol = False
        Dim Index As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count

        'Dim cname As String = ComboBox2.Text + "," + ComboBox3.Text + "," + ComboBox4.Text + "," + ComboBox5.Text + "," + ComboBox6.Text + "," + P_PRAM3

        DB_OPEN()
        Dim command As MySqlCommand = cnn.CreateCommand()
        Dim Reader As MySqlDataReader
        query1 = "select *   FROM tm14_account_master where  `Account_number`=@Account_number1 "
        command.Parameters.AddWithValue("Account_number1", ComboBox2.SelectedValue)
        command.CommandText = query1
        Reader = command.ExecuteReader()
        While Reader.Read
            If Not IsDBNull(Reader("Yomigana")) Then
                Yomigana = ""
                Customer_name = ""
                Yomigana = Reader("Yomigana")
                Customer_name = Reader("Customer_name")
                If (Yomigana.Trim <> "") Then
                    If bol = False Then
                        P_PRAM3 = Customer_name
                        P_PRAM4 += Yomigana
                        bol = True
                    Else
                        P_PRAM4 += ", " + Yomigana
                        P_PRAM3 += ", " + Customer_name
                    End If

                End If

            Else
                Yomigana = ""
            End If
        End While
        DB_CLOSE()
        If (ComboBox3.SelectedValue <> 0) Then
            'P_PRAM3 += ", " + ComboBox3.Text
            DB_OPEN()
            query1 = "select *   FROM tm14_account_master where  `Account_number`=@Account_number2 "
            command.Parameters.AddWithValue("Account_number2", ComboBox3.SelectedValue)
            command.CommandText = query1
            Reader = command.ExecuteReader()
            While Reader.Read
                If Not IsDBNull(Reader("Yomigana")) Then
                    Yomigana = ""
                    Customer_name = ""
                    Yomigana = Reader("Yomigana")
                    Customer_name = Reader("Customer_name")
                    If (Yomigana.Trim <> "") Then
                        If (Yomigana.Trim <> "") Then
                            If bol = False Then
                                P_PRAM4 += Yomigana
                                P_PRAM3 += Customer_name
                                bol = True
                            Else
                                P_PRAM4 += ", " + Yomigana
                                P_PRAM3 += ", " + Customer_name
                            End If

                        End If
                    End If

                Else
                    Yomigana = ""
                End If
            End While
            DB_CLOSE()
        End If
        If (ComboBox4.SelectedValue <> "0") Then
            'P_PRAM3 += ", " + ComboBox4.Text
            DB_OPEN()
            query1 = "select *   FROM tm14_account_master where  `Account_number`=@Account_number3 "
            command.Parameters.AddWithValue("Account_number3", ComboBox4.SelectedValue)
            command.CommandText = query1
            Reader = command.ExecuteReader()
            While Reader.Read
                If Not IsDBNull(Reader("Yomigana")) Then
                    Yomigana = ""
                    Customer_name = ""
                    Yomigana = Reader("Yomigana")
                    Customer_name = Reader("Customer_name")
                    If (Yomigana.Trim <> "") Then
                        If (Yomigana.Trim <> "") Then
                            If bol = False Then
                                P_PRAM4 += Yomigana
                                P_PRAM3 += Customer_name
                                bol = True
                            Else
                                P_PRAM4 += ", " + Yomigana
                                P_PRAM3 += ", " + Customer_name
                            End If

                        End If
                    End If
                    Yomigana = ""
                End If
            End While
            DB_CLOSE()
        End If

        If (ComboBox5.SelectedValue <> 0) Then
            'P_PRAM3 += ", " + ComboBox5.Text

            DB_OPEN()
            query1 = "select *   FROM tm14_account_master where  `Account_number`=@Account_number4 "
            command.Parameters.AddWithValue("Account_number4", ComboBox5.SelectedValue)
            command.CommandText = query1
            Reader = command.ExecuteReader()
            While Reader.Read
                If Not IsDBNull(Reader("Yomigana")) Then
                    Yomigana = ""
                    Customer_name = ""
                    Yomigana = Reader("Yomigana")
                    Customer_name = Reader("Customer_name")
                    If (Yomigana.Trim <> "") Then
                        If (Yomigana.Trim <> "") Then
                            If bol = False Then
                                P_PRAM4 += Yomigana
                                P_PRAM3 += Customer_name
                                bol = True
                            Else
                                P_PRAM4 += ", " + Yomigana
                                P_PRAM3 += ", " + Customer_name
                            End If

                        End If
                    End If
                    Yomigana = ""
                Else
                    Yomigana = ""
                End If
            End While
            DB_CLOSE()
        End If

        If (ComboBox6.SelectedValue <> 0) Then
            'P_PRAM3 += ", " + ComboBox6.Text
            DB_OPEN()
            query1 = "select *   FROM tm14_account_master where  `Account_number`=@Account_number5 "
            command.Parameters.AddWithValue("Account_number5", ComboBox5.SelectedValue)
            command.CommandText = query1
            Reader = command.ExecuteReader()
            While Reader.Read
                If Not IsDBNull(Reader("Yomigana")) Then
                    Yomigana = ""
                    Customer_name = ""
                    Yomigana = Reader("Yomigana")
                    Customer_name = Reader("Yomigana")
                    If (Yomigana.Trim <> "") Then
                        If (Yomigana.Trim <> "") Then
                            If bol = False Then
                                P_PRAM4 += Yomigana
                                P_PRAM3 += Customer_name
                                bol = True
                            Else
                                P_PRAM4 += ", " + Yomigana
                                P_PRAM3 += ", " + Customer_name
                            End If

                        End If
                    End If
                    Yomigana = ""

                Else
                    Yomigana = ""
                End If
            End While
            DB_CLOSE()
        End If

        Dim ij = 7
        Dim i = 6
        For Index = 7 To Index
            i += 1
            Dim cmb = "drp" + Convert.ToString(i)
            Dim chk = "btnDelete_" + Convert.ToString(i)
            If cmb <> "drp1" Then
                Dim txt As ComboBox = CType(Panel2.Controls.Find((cmb), True)(0), ComboBox)
                Dim chkbox As CheckBox = CType(Panel2.Controls.Find((chk), True)(0), CheckBox)
                If chkbox.Checked = False Then
                    If txt.SelectedValue <> 0 Then
                        ij += 1
                        P_PRAM2 += "," + txt.SelectedValue
                        'P_PRAM3 += ", " + txt.Text

                        Dim command1 As MySqlCommand = cnn.CreateCommand()
                        Dim Reader1 As MySqlDataReader
                        DB_OPEN()
                        Dim query2 = ""
                        query2 = "select *   FROM tm14_account_master where  `Account_number`=@Account_number5" + Convert.ToString(ij).ToString() + ""
                        command.Parameters.AddWithValue("Account_number5" + Convert.ToString(ij), txt.SelectedValue)
                        command.CommandText = query2
                        Reader1 = command.ExecuteReader()
                        While Reader1.Read
                            If Not IsDBNull(Reader1("Customer_name")) Then
                                Customer_name = ""
                                Customer_name = Reader1("Customer_name")
                                If (Customer_name.Trim <> "") Then
                                    If (Customer_name.Trim <> "") Then
                                        If bol = False Then
                                            P_PRAM3 += Customer_name
                                            bol = True
                                        Else
                                            P_PRAM3 += ", " + Customer_name
                                        End If

                                    End If
                                End If
                                Customer_name = ""
                            Else
                                Customer_name = ""
                            End If
                            If Not IsDBNull(Reader1("Yomigana")) Then
                                Yomigana = ""
                                Yomigana = Reader1("Yomigana")
                                If (Yomigana.Trim <> "") Then
                                    If (Yomigana.Trim <> "") Then
                                        If bol = False Then
                                            P_PRAM4 += Yomigana
                                            bol = True
                                        Else
                                            P_PRAM4 += ", " + Yomigana
                                        End If

                                    End If
                                End If
                                Yomigana = ""
                            Else
                                Yomigana = ""
                            End If
                        End While
                        DB_CLOSE()
                    End If
                End If


            End If
        Next

    End Sub



    Private Sub DateTimePicker1_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker1.CloseUp
        If (DateTimePicker1.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = " "
        Else

            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        End If
    End Sub

    Private Sub DateTimePicker2_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker2.CloseUp
        If (DateTimePicker2.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = " "
        Else

            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = "yyyy/MM/dd"
        End If
    End Sub

    Private Sub DateTimePicker3_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker3.CloseUp
        Dim checkdate = False
        If (DateTimePicker3.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker3.Format = DateTimePickerFormat.Custom
            DateTimePicker3.CustomFormat = " "
        Else

            DateTimePicker3.Format = DateTimePickerFormat.Custom
            DateTimePicker3.CustomFormat = "yyyy/MM/dd"
            'If checkdate = False Then
            '    If DateTimePicker3.Text.Trim <> "" Then

            '        If DateTimePicker1.Text.Trim = "" Then
            '            checkdate = True
            '            MessageBox.Show("有効な日付を入力してください")
            '            DateTimePicker3.Format = DateTimePickerFormat.Custom
            '            DateTimePicker3.CustomFormat = " "
            '        End If
            '    End If
            'End If

            'If checkdate = False Then
            '    If DateTimePicker3.Text < DateTimePicker1.Text Then
            '        checkdate = True
            '        MessageBox.Show("有効な日付を入力してください")
            '        DateTimePicker3.Format = DateTimePickerFormat.Custom
            '        DateTimePicker3.CustomFormat = " "
            '    End If
            'End If

            'If checkdate = False Then
            '    If DateTimePicker3.Text.Trim <> "" Then

            '        If DateTimePicker2.Text.Trim = "" Then
            '            checkdate = True
            '            MessageBox.Show("有効な日付を入力してください")
            '            DateTimePicker3.Format = DateTimePickerFormat.Custom
            '            DateTimePicker3.CustomFormat = " "

            '        End If
            '    End If
            'End If

            'If checkdate = False Then
            '    If DateTimePicker3.Text < DateTimePicker2.Text Then
            '        checkdate = True
            '        MessageBox.Show("有効な日付を入力してください")
            '        DateTimePicker3.Format = DateTimePickerFormat.Custom
            '        DateTimePicker3.CustomFormat = " "
            '    End If
            'End If
        End If
    End Sub
    Private Sub DateTimePicker4_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker4.CloseUp
        Dim checkdate = False
        If (DateTimePicker4.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker4.Format = DateTimePickerFormat.Custom
            DateTimePicker4.CustomFormat = " "
        Else

            DateTimePicker4.Format = DateTimePickerFormat.Custom
            DateTimePicker4.CustomFormat = "yyyy/MM/dd"
            'If checkdate = False Then
            '    If DateTimePicker4.Text.Trim <> "" Then

            '        If DateTimePicker1.Text.Trim = "" Then
            '            checkdate = True
            '            MessageBox.Show("有効な日付を入力してください")
            '            DateTimePicker4.Format = DateTimePickerFormat.Custom
            '            DateTimePicker4.CustomFormat = " "
            '        End If
            '    End If
            'End If

            'If checkdate = False Then
            '    If DateTimePicker4.Text < DateTimePicker1.Text Then
            '        checkdate = True
            '        MessageBox.Show("有効な日付を入力してください")
            '        DateTimePicker4.Format = DateTimePickerFormat.Custom
            '        DateTimePicker4.CustomFormat = " "
            '    End If
            'End If

            If checkdate = False Then
                If DateTimePicker4.Text.Trim <> "" Then

                    If DateTimePicker2.Text.Trim = "" Then
                        checkdate = True
                        MessageBox.Show("有効な日付を入力してください")
                        DateTimePicker4.Format = DateTimePickerFormat.Custom
                        DateTimePicker4.CustomFormat = " "

                    End If
                End If
            End If

            If checkdate = False Then
                If DateTimePicker4.Text < DateTimePicker2.Text Then
                    checkdate = True
                    MessageBox.Show("有効な日付を入力してください")
                    DateTimePicker4.Format = DateTimePickerFormat.Custom
                    DateTimePicker4.CustomFormat = " "
                End If
            End If

        End If


    End Sub

    Private Sub DateTimePicker5_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker5.CloseUp
        If (DateTimePicker5.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker5.Format = DateTimePickerFormat.Custom
            DateTimePicker5.CustomFormat = " "
        Else

            DateTimePicker5.Format = DateTimePickerFormat.Custom
            DateTimePicker5.CustomFormat = "yyyy/MM/dd"
        End If
    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = " "
        End If
    End Sub

    Private Sub DateTimePicker2_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker2.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = " "
        End If
    End Sub

    Private Sub DateTimePicker3_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker3.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            DateTimePicker3.Format = DateTimePickerFormat.Custom
            DateTimePicker3.CustomFormat = " "
        End If
    End Sub

    Private Sub DateTimePicker4_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker4.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            DateTimePicker4.Format = DateTimePickerFormat.Custom
            DateTimePicker4.CustomFormat = " "
        End If
    End Sub

    Private Sub DateTimePicker5_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker5.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            DateTimePicker5.Format = DateTimePickerFormat.Custom
            DateTimePicker5.CustomFormat = " "
        End If
    End Sub

    'Private Sub ComboBox2_Enter(sender As Object, e As EventArgs) Handles ComboBox2.Enter
    '    Dim strSQL As String = Nothing
    '    Dim BindValues As String = Nothing
    '    P_PRAM1 = ComboBox2.SelectedValue
    '    Dim dt = New DataTable()
    '    dt.Columns.Add("Account_number")
    '    dt.Columns.Add("Customer_name")
    '    'dt.Rows.Add("0", "")
    '    sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0 and `Account_number`=" + Temporarycompanynumber1

    '    Try
    '        If (F21pageload = True) Then

    '            If Not String.IsNullOrEmpty(Temporarycompanynumber1) Then
    '                ComboBox2.SelectedValue = Temporarycompanynumber1
    '                Temporarycompanynumber1 = 0
    '            End If
    '        Else
    '            DB_OPEN()
    '            Dim command As MySqlCommand = cnn.CreateCommand()
    '            If (TextBox1.Text.Trim() <> "") Then
    '                sql += " and Customer_name like @CSearch "
    '                command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
    '                'If ComboBox2.SelectedValue <> 0 Then
    '                '    dt.Rows.Add(ComboBox2.SelectedValue, ComboBox2.Text)
    '                'End If
    '            End If
    '            Dim Reader As MySqlDataReader
    '            command.CommandText = sql
    '            Reader = command.ExecuteReader()
    '            dt.Load(Reader)
    '            DB_CLOSE()
    '        End If
    '        If (P_PRAM1 <> Nothing) Then
    '            Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM1 = row.Field(Of String)("Account_number"))
    '            If exists = False Then
    '                If ComboBox2.SelectedValue <> 0 Then
    '                    dt.Rows.Add(ComboBox2.SelectedValue, ComboBox2.Text)
    '                End If
    '            End If
    '        End If
    '        If dt.Rows.Count < 1 Then
    '            dt.Rows.Add("", "")
    '        End If

    '        ComboBox2.DataSource = Nothing
    '        ComboBox2.Items.Clear()
    '        ComboBox2.DataSource = dt
    '        ComboBox2.ValueMember = "Account_number"
    '        ComboBox2.DisplayMember = "Customer_name"

    '        'ComboBox1.DisplayMember = "ID"
    '        If (P_PRAM1 <> Nothing) Then
    '            ComboBox2.SelectedValue = P_PRAM1
    '        Else
    '            ComboBox2.SelectedValue = ""
    '            ComboBox2.Text = ""
    '        End If

    '        'If dt.Rows.Count = 1 Then
    '        '    MessageBox.Show("指定された検索条件に一致するものが見つかりませんでした。")
    '        'End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub ComboBox2_Enter(sender As Object, e As EventArgs) Handles ComboBox2.Enter
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        P_PRAM1 = ComboBox2.SelectedValue
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        'dt.Rows.Add("0", "")

        Try
            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 "
                If Temporarycompanynumber1 <> "0" Then
                    sql += "and`Account_number`=" + Convert.ToString(Temporarycompanynumber1)
                End If

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where  `Delete`=0"

            End If

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox2.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox2.SelectedValue, ComboBox2.Text)
                'End If
            End If
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM1 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM1 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox2.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox2.SelectedValue, ComboBox2.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If


            ComboBox2.DataSource = Nothing
            ComboBox2.Items.Clear()
            ComboBox2.DataSource = dt
            ComboBox2.ValueMember = "Account_number"
            ComboBox2.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
            If (P_PRAM1 <> Nothing) Then
                ComboBox2.SelectedValue = P_PRAM1
            Else
                ComboBox2.SelectedValue = ""
                ComboBox2.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber1) Then
                    ComboBox2.SelectedValue = Temporarycompanynumber1
                    Temporarycompanynumber1 = 0
                End If
            Else
                'ComboBox2.SelectedValue = ""
                'ComboBox2.Text = ""
            End If

            'If dt.Rows.Count = 1 Then
            '    MessageBox.Show("指定された検索条件に一致するものが見つかりませんでした。")
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox3_Enter(sender As Object, e As EventArgs) Handles ComboBox3.Enter
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        P_PRAM2 = ComboBox3.SelectedValue
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        ' dt.Rows.Add("0", "")
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0"

        Try

            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 and `Account_number`=" + Convert.ToString(Temporarycompanynumber2)

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0"

            End If
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                ' command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox3.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox3.SelectedValue, ComboBox3.Text)
                'End If
            End If
            'command.CommandText = sql
            'adapter.SelectCommand = command
            'adapter.Fill(ds)
            'adapter.Dispose()
            'command.Dispose()
            Dim Reader As MySqlDataReader


            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM2 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM2 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox3.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox3.SelectedValue, ComboBox3.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If
            ComboBox3.DataSource = dt
            ComboBox3.ValueMember = "Account_number"
            ComboBox3.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
            If (P_PRAM2 <> Nothing) Then
                ComboBox3.SelectedValue = P_PRAM2
            Else
                ComboBox3.SelectedValue = ""
                ComboBox3.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber2) Then
                    ComboBox3.SelectedValue = Temporarycompanynumber2
                    Temporarycompanynumber2 = 0
                End If
            Else
                'ComboBox3.SelectedValue = ""
                'ComboBox3.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox4_Enter(sender As Object, e As EventArgs) Handles ComboBox4.Enter
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        'dt.Rows.Add("0", "")
        P_PRAM3 = ComboBox4.SelectedValue

        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0"

        Try
            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 and `Account_number`=" + Convert.ToString(Temporarycompanynumber3)

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0"

            End If

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox4.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox4.SelectedValue, ComboBox4.Text)
                'End If
            End If
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM3 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM3 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox4.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox4.SelectedValue, ComboBox4.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If
            ComboBox4.DataSource = dt
            ComboBox4.ValueMember = "Account_number"
            ComboBox4.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
            If (P_PRAM3 <> Nothing) Then
                ComboBox4.SelectedValue = P_PRAM3
            Else
                ComboBox4.SelectedValue = ""
                ComboBox4.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber3) Then
                    ComboBox4.SelectedValue = Temporarycompanynumber3
                    Temporarycompanynumber3 = 0
                End If
            Else
                'ComboBox4.SelectedValue = ""
                'ComboBox4.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox5_Enter(sender As Object, e As EventArgs) Handles ComboBox5.Enter
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        P_PRAM4 = ComboBox5.SelectedValue
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        ' dt.Rows.Add("0", "")

        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0"

        Try
            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 and `Account_number`=" + Convert.ToString(Temporarycompanynumber4)

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0"

            End If
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox5.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox5.SelectedValue, ComboBox5.Text)
                'End If
            End If
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM4 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM4 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox5.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox5.SelectedValue, ComboBox5.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If
            ComboBox5.DataSource = dt
            ComboBox5.ValueMember = "Account_number"
            ComboBox5.DisplayMember = "Customer_name"
            If (P_PRAM4 <> Nothing) Then
                ComboBox5.SelectedValue = P_PRAM4
            Else
                ComboBox5.SelectedValue = ""
                ComboBox5.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber4) Then
                    ComboBox5.SelectedValue = Temporarycompanynumber4
                    Temporarycompanynumber4 = 0
                End If
            Else
                'ComboBox5.SelectedValue = ""
                'ComboBox5.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox6_Enter(sender As Object, e As EventArgs) Handles ComboBox6.Enter
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        P_PRAM5 = ComboBox6.SelectedValue
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")
        'dt.Rows.Add("0", "")
        'sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0 "

        Try
            If (F21pageload = True) Then
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0 and `Account_number`=" + Convert.ToString(Temporarycompanynumber5)

            Else
                sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete`=0"

            End If
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                ' command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If
                'If ComboBox6.SelectedValue <> 0 Then
                '    dt.Rows.Add(ComboBox6.SelectedValue, ComboBox6.Text)
                'End If
            End If
            Dim Reader As MySqlDataReader


            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()
            If (P_PRAM5 <> Nothing) Then
                Dim exists As Boolean = dt.AsEnumerable().Any(Function(row) P_PRAM5 = row.Field(Of String)("Account_number"))
                If exists = False Then
                    If ComboBox6.SelectedValue <> 0 Then
                        dt.Rows.Add(ComboBox6.SelectedValue, ComboBox6.Text)
                    End If
                End If
            End If
            If dt.Rows.Count < 1 Then
                dt.Rows.Add("", "")
            End If
            ComboBox6.DataSource = dt
            ComboBox6.ValueMember = "Account_number"
            ComboBox6.DisplayMember = "Customer_name"
            If (P_PRAM5 <> Nothing) Then
                ComboBox6.SelectedValue = P_PRAM5
            Else
                ComboBox6.SelectedValue = ""
                ComboBox6.Text = ""
            End If
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Temporarycompanynumber5) Then
                    ComboBox6.SelectedValue = Temporarycompanynumber5
                    Temporarycompanynumber5 = 0
                End If
            Else
                'ComboBox6.SelectedValue = ""
                'ComboBox6.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox7_Enter(sender As Object, e As EventArgs) Handles ComboBox7.Enter
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT Update_code, CONCAT(Update_code,' : ',Update_code_details) as Update_code_details , ID "
        sql += "FROM tm19_update_code_master"

        Try

            DB_OPEN()

            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("ID")
            dt.Columns.Add("Update_code")
            dt.Columns.Add("Update_code_details")
            'dt.Rows.Add("none", "none", "")
            command.CommandText = sql
            Reader = command.ExecuteReader()

            dt.Load(Reader)
            DB_CLOSE()
            ComboBox7.ValueMember = "Update_code"
            ComboBox7.DisplayMember = "Update_code_details"
            ComboBox7.DataSource = dt
            ComboBox7.SelectedValue = ""
            ComboBox7.Text = ""
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Update_code) Then
                    ComboBox7.SelectedValue = Update_code
                    Update_code = ""
                Else
                    ComboBox7.SelectedValue = ""
                    ComboBox7.Text = ""
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox9_Enter(sender As Object, e As EventArgs) Handles ComboBox9.Enter
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT ID ,Department_number, Management_department "
        sql += "FROM tm15_department_master "
        sql += "WHERE (((`Delete` ) Is Null Or (`Delete` )=False));"

        Try
            Dim dt = New DataTable()
            dt.Columns.Add("Department_number")
            dt.Columns.Add("Management_department")
            'dt.Rows.Add("0", "")
            DB_OPEN()

            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()

            dt.Load(Reader)
            DB_CLOSE()


            ComboBox9.ValueMember = "Department_number"
            ComboBox9.DisplayMember = "Management_department"
            ComboBox9.DataSource = dt
            ComboBox9.SelectedValue = ""
            ComboBox9.Text = ""
            If (F21pageload = True) Then
                If Not String.IsNullOrEmpty(Mgt_dpt) Then
                    ComboBox9.SelectedValue = Mgt_dpt
                    Mgt_dpt = ""
                Else
                    ComboBox9.SelectedValue = ""
                    ComboBox9.Text = ""
                End If
            End If

        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub checkdata()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        P_PRAM4 = ComboBox4.SelectedValue
        Dim dt = New DataTable()
        dt.Columns.Add("Account_number")
        dt.Columns.Add("Customer_name")


        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where `Delete` =0"

        Try
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            If (TextBox1.Text.Trim() <> "") Then
                sql += " and Customer_name like @CSearch "
                'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                If textinput <> "" Then
                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                Else
                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                End If

            End If
            Dim Reader As MySqlDataReader

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            If dt.Rows.Count < 1 Then
                MessageBox.Show("指定された検索条件に一致するものが見つかりませんでした。")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        BindValues = ComboBox1.Text
        sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where  `Delete`=0"
        sql += " and Customer_name like @CSearch"
        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
            Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
            If textinput <> "" Then
                command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
            Else
                command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
            End If
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")

            dt.Rows.Add("0", "")

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox1.DataSource = dt
            ComboBox1.ValueMember = "Account_number"
            ComboBox1.DisplayMember = "Customer_name"
            cmbAdd()
        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
        If (TextBox1.Text <> "") Then
            Me.ComboBox1.DroppedDown = True
            Me.Cursor = DefaultCursor
        End If
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Dim item As DataRowView = TryCast(Me.ComboBox1.SelectedItem, DataRowView)
        If ComboBox1.Text <> "" Then
            If item.IsEdit = False Then
                If (ComboBox1.SelectedValue <> 0) Then
                    TextBox1.Text = ComboBox1.Text
                    cmbAdd()
                    If ComboBox2.SelectedValue = 0 Then
                        ComboBox002()
                    ElseIf ComboBox3.SelectedValue = 0 Then
                        ComboBox003()
                    ElseIf ComboBox4.SelectedValue = 0 Then
                        ComboBox004()
                    ElseIf ComboBox5.SelectedValue = 0 Then
                        ComboBox005()
                    ElseIf ComboBox6.SelectedValue = 0 Then
                        ComboBox006()
                    Else
                        'Dim count As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
                        'If count <> 25 Then
                        '    If count = 7 Then
                        ComboBoxDynamic()
                        '    Else

                        '    End If

                        'End If
                    End If
                End If
            End If
        End If

    End Sub
    Sub ComboBoxDynamic()
        ' Try
        'Edit
        If flagbool = False Then
                Try
                    Dim Index As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
                    Dim i = 6
                    For Index = 7 To Index
                        i += 1
                        Dim cmb = "drp" + Convert.ToString(i)
                        Dim chk = "btnDelete_" + Convert.ToString(i)
                        If cmb <> "drp1" Then
                            Dim txt As ComboBox = CType(Panel2.Controls.Find((cmb), True)(0), ComboBox)
                            ' If txt.SelectedValue <> 0 Then
                            If flagbool = False Then
                                If txt.SelectedValue <> 0 Then
                                    P_PRAM6 = txt.SelectedValue
                                Else
                                    P_PRAM6 = ComboBox1.SelectedValue
                                End If
                            Else
                                P_PRAM6 = ComboBox1.SelectedValue
                            End If

                            Dim strSQL As String = Nothing
                            Dim BindValues As String = Nothing

                            Dim command As MySqlCommand = cnn.CreateCommand()
                            sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
                            If (TextBox1.Text.Trim() <> "") Then
                                sql += " and Customer_name like @CSearch "
                                ' command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                                Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                                If textinput <> "" Then
                                    command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                                Else
                                    command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                                End If
                            End If

                            DB_OPEN()
                            Dim ComboBox As ComboBox = New ComboBox
                            Dim Reader As MySqlDataReader
                            Dim dt = New DataTable()
                            dt.Columns.Add("Account_number")
                            dt.Columns.Add("Customer_name")
                            'dt.Rows.Add("0", "")
                            command.CommandText = sql
                            Reader = command.ExecuteReader()
                            dt.Load(Reader)
                            DB_CLOSE()
                            If Index <> 25 Then
                                'If count = 1 Then
                                '    ComboBox.Location = New System.Drawing.Point(85, 80)
                                'ElseIf count = 2 Then
                                '    ComboBox.Location = New System.Drawing.Point(85, (70 + (23 * count)))
                                'ElseIf count = 3 Then
                                '    ComboBox.Location = New System.Drawing.Point(85, (70 + (25 * count)))
                                'ElseIf count = 6 Then
                                '    'ComboBox.Location = New System.Drawing.Point(85, 185)
                                'Else
                                '    'ComboBox.Location = New System.Drawing.Point(85, 210)
                                'End If

                                'ComboBox.Size = New System.Drawing.Size(520, 24)
                                ComboBox.Name = "drp" & (Index)
                                ComboBox.DataSource = dt
                                ComboBox.ValueMember = "Account_number"
                                ComboBox.DisplayMember = "Customer_name"
                                'ComboBox.SelectedValue = P_PRAM6
                                P_PRAM1 = ComboBox.Name
                                'Panel2.Controls.Add(ComboBox)
                                Dim txt1 As ComboBox = CType(Panel2.Controls.Find(("drp" & (Index)), True)(0), ComboBox)
                                txt1.SelectedValue = P_PRAM6
                                'Panel2.Controls.Add(ComboBox)

                                'ComboBox.SelectedValue = ""
                            Else
                                MessageBox.Show("最大25フィールド")
                            End If

                            '  End If
                        End If

                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            'create
        Else
                Try
                    'Panel2.AutoScroll = True
                    ' Panel2.AutoScrollPosition = New Point(Panel2.AutoScrollPosition.X, Panel2.VerticalScroll.Maximum)
                    Dim ComboBox As ComboBox = New ComboBox
                    Dim strSQL As String = Nothing
                    Dim BindValues As String = Nothing

                    If flagbool = False Then
                        If ComboBox.SelectedValue <> 0 Then
                            P_PRAM6 = ComboBox.SelectedValue
                        Else
                            P_PRAM6 = ComboBox1.SelectedValue
                        End If
                    Else
                        P_PRAM6 = ComboBox1.SelectedValue
                    End If
                    Dim command As MySqlCommand = cnn.CreateCommand()
                    sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master  where `Delete` =0 "
                    If (TextBox1.Text.Trim() <> "") Then
                        sql += " and Customer_name like @CSearch "
                        ' command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text + "%")
                        Dim textinput = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf(" :") + 1)
                        If textinput <> "" Then
                            command.Parameters.AddWithValue("CSearch", "%" + textinput.Trim() + "%")
                        Else
                            command.Parameters.AddWithValue("CSearch", "%" + TextBox1.Text.Trim() + "%")
                        End If
                    End If
                    DB_OPEN()

                    Dim Reader As MySqlDataReader
                    Dim dt = New DataTable()
                    dt.Columns.Add("Account_number")
                    dt.Columns.Add("Customer_name")
                    'dt.Rows.Add("0", "")
                    command.CommandText = sql
                    Reader = command.ExecuteReader()
                    dt.Load(Reader)
                    DB_CLOSE()

                    Dim count As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
                    If count <> 25 Then
                        'If count = 1 Then
                        '    ComboBox.Location = New System.Drawing.Point(85, 80)
                        'ElseIf count = 2 Then
                        '    ComboBox.Location = New System.Drawing.Point(85, (70 + (23 * count)))
                        'ElseIf count = 3 Then
                        '    ComboBox.Location = New System.Drawing.Point(85, (70 + (25 * count)))
                        'ElseIf count = 6 Then
                        '    'ComboBox.Location = New System.Drawing.Point(85, 185)
                        'Else
                        '    'ComboBox.Location = New System.Drawing.Point(85, 210)
                        'End If

                        'ComboBox.Size = New System.Drawing.Size(520, 24)
                        ComboBox.Name = "drp" & (count)
                        ComboBox.DataSource = dt
                        ComboBox.ValueMember = "Account_number"
                        ComboBox.DisplayMember = "Customer_name"
                        'ComboBox.SelectedValue = P_PRAM6
                        P_PRAM1 = ComboBox.Name
                        'Panel2.Controls.Add(ComboBox)
                        Dim txt As ComboBox = CType(Panel2.Controls.Find(("drp" & (count)), True)(0), ComboBox)
                        txt.SelectedValue = P_PRAM6
                        'Panel2.Controls.Add(ComboBox)
                        'ComboBox.SelectedValue = ""
                    Else
                        MessageBox.Show("最大25フィールド")
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

        End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Sub ComboBox001()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master where  `Delete`=0"

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.Parameters.AddWithValue("CSearch", "%" + ComboBox1.Text + "%")
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")

            dt.Rows.Add("0", "")

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            'ComboBox1.DataSource = dt
            'ComboBox1.ValueMember = "Account_number"
            'ComboBox1.DisplayMember = "Customer_name"

            Dim ds1 = New DataSet()
            ds1.Tables.Add(dt)
            ComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
            ComboBox1.AutoCompleteSource = AutoCompleteSource.ListItems
            Dim combData As New AutoCompleteStringCollection()
            For Each row As DataRow In ds1.Tables(0).Rows
                combData.Add(row(1).ToString())
            Next

            ComboBox1.AutoCompleteCustomSource = combData

            'ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
            'ComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend


            'Dim Data = New AutoCompleteStringCollection()
            '' Data = dt.TableName()
            'ComboBox1.AutoCompleteCustomSource = Data



        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    
End Class