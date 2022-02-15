Imports System.Data
Imports MySql.Data.MySqlClient

Public Class F21_契約書入力画面
    Dim command As MySqlCommand
    Dim adapter As New MySqlDataAdapter()
    Dim ds As New DataSet()
    Dim DtView1 As DataView
    Dim sql As String = Nothing
    Dim dtnow As Date = Today
    Dim insert As Boolean = True

    Private Sub F23_枝番入力画面_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.MaximizeBox = False

        binddata()
        inz()

    End Sub
    Private Sub binddata()
        'ComboBox001()
        ComboBox002()
        ComboBox003()
        ComboBox004()
        ComboBox005()
        ComboBox006()
        ComboBox007()
        ComboBox008()
        ComboBox009()
        cmbremove()
    End Sub
    Sub inz()
        If Not String.IsNullOrEmpty(Mgt_number) Then
            TextBox3.Text = Mgt_number
            Label6.Text = Mgt_number
            Mgt_number = ""
            insert = False
        Else
            getID()
            insert = True
        End If
        If Not String.IsNullOrEmpty(Branch_number) Then
            TextBox5.Text = Branch_number
            Branch_number = ""
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber1) Then
            ComboBox2.SelectedValue = Temporarycompanynumber1
            Temporarycompanynumber1 = 0
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber2) Then
            ComboBox3.SelectedValue = Temporarycompanynumber2
            Temporarycompanynumber2 = 0
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber3) Then
            ComboBox4.SelectedValue = Temporarycompanynumber3
            Temporarycompanynumber3 = 0
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber4) Then
            ComboBox5.SelectedValue = Temporarycompanynumber4
            Temporarycompanynumber4 = 0
        End If
        If Not String.IsNullOrEmpty(Temporarycompanynumber5) Then
            ComboBox6.SelectedValue = Temporarycompanynumber5
            Temporarycompanynumber5 = 0
        End If
        If Not String.IsNullOrEmpty(Old_number) Then
            TextBox4.Text = Old_number
            Old_number = ""
        End If
        If Not String.IsNullOrEmpty(Contract_date) Then
            If Contract_date > "31-12-9998 00:00:00" Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "yyyy/MM/dd"
                DateTimePicker1.Value = dtnow
            Else
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "yyyy/MM/dd"
                DateTimePicker1.Value = Contract_date
                Contract_date = ""
            End If

        Else
            DateTimePicker1.Value = dtnow

        End If

        If Not String.IsNullOrEmpty(Contract_p_co) Then
            If Scheduled_Prd_end_Date > "31-12-9998 00:00:00" Then
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "yyyy/MM/dd"
                DateTimePicker2.Value = dtnow
            Else
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "yyyy/MM/dd"
                DateTimePicker2.Value = Contract_p_co
                Contract_p_co = ""
            End If

        Else
            DateTimePicker2.Value = dtnow

        End If
        If Not String.IsNullOrEmpty(Scheduled_Prd_end_Date) Then
            If Scheduled_Prd_end_Date > "31-12-9998 00:00:00" Then
                DateTimePicker4.Format = DateTimePickerFormat.Custom
                DateTimePicker4.CustomFormat = "yyyy/MM/dd"
                DateTimePicker4.Value = dtnow
            Else
                DateTimePicker4.Format = DateTimePickerFormat.Custom
                DateTimePicker4.CustomFormat = "yyyy/MM/dd"
                DateTimePicker4.Value = Scheduled_Prd_end_Date
                Scheduled_Prd_end_Date = ""
            End If

        Else


        End If

        If Not String.IsNullOrEmpty(End_date) Then
            If End_date > "31-12-9998 00:00:00" Then
                End_date = ""
            Else
                DateTimePicker3.Format = DateTimePickerFormat.Custom
                DateTimePicker3.CustomFormat = "yyyy/MM/dd"
                DateTimePicker3.Value = End_date
                End_date = ""
            End If
        Else
            DateTimePicker3.Value = dtnow
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
            End If
        Else
            DateTimePicker3.Value = dtnow
        End If

        If Not String.IsNullOrEmpty(Update_code) Then
            'doubt
            ComboBox7.SelectedValue = Update_code
            Update_code = ""
        End If
        If Not String.IsNullOrEmpty(Auto_upd_intr) Then
            ComboBox8.SelectedValue = Auto_upd_intr
            Auto_upd_intr = ""
        End If
        If Not String.IsNullOrEmpty(Contract_name) Then
            TextBox21.Text = Contract_name
            Contract_name = ""
        End If
        If Not String.IsNullOrEmpty(Mgt_dpt) Then
            ComboBox9.SelectedValue = Mgt_dpt
            Mgt_dpt = ""
        End If
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
            sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "


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
                dt1.Rows.Add("0", "選択する")
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
                ElseIf count = 5 Then
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
                ElseIf count = 5 Then
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
            DB_OPEN()
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
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "

        Try
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.CommandText = sql
            'adapter.SelectCommand = command
            'adapter.Fill(ds)
            'adapter.Dispose()
            'command.Dispose()
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox2.DataSource = dt
            ComboBox2.ValueMember = "Account_number"
            ComboBox2.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ComboBox003()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "

        Try
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            'command.CommandText = sql
            'adapter.SelectCommand = command
            'adapter.Fill(ds)
            'adapter.Dispose()
            'command.Dispose()
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox3.DataSource = dt
            ComboBox3.ValueMember = "Account_number"
            ComboBox3.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ComboBox004()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "

        Try
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox4.DataSource = dt
            ComboBox4.ValueMember = "Account_number"
            ComboBox4.DisplayMember = "Customer_name"
            'ComboBox1.DisplayMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Sub ComboBox005()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "

        Try
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox5.DataSource = dt
            ComboBox5.ValueMember = "Account_number"
            ComboBox5.DisplayMember = "Customer_name"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox006()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "

        Try
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox6.DataSource = dt
            ComboBox6.ValueMember = "Account_number"
            ComboBox6.DisplayMember = "Customer_name"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Try
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
        binddata()
        Me.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim F14_取引先マスター一覧 As New F14_取引先マスター一覧
        Me.Hide()
        F14_取引先マスター一覧.ShowDialog()
        binddata()
        Me.Show()
    End Sub
    Private Sub Updatedata()


        If ComboBox2.SelectedValue = 0 Then
            ComboBox2.Focus()
            MessageBox.Show("会社名を選択")
            Exit Sub
        End If
        If TextBox21.Text.Trim = "" Then
            TextBox21.Focus()
            MessageBox.Show("契約名を選択")
            Exit Sub
        End If

        If ComboBox7.SelectedValue = "none" Then
            ComboBox7.Focus()
            MessageBox.Show("[コードの更新]を選択します")

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
            id = Reader("id")
        End While
        DB_CLOSE()
        DB_OPEN()

        Dim query As String = "Update t20_contract_management set "


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
        query += "where Control_number=@Controlnumber"





        command.Parameters.AddWithValue("company_Number_all", P_PRAM2)
        command.Parameters.AddWithValue("Controlnumber", TextBox3.Text)
        command.Parameters.AddWithValue("Indiacontract", "")
        command.Parameters.AddWithValue("Temporarynumber", id)
        command.Parameters.AddWithValue("Branchnumber", TextBox5.Text)
        command.Parameters.AddWithValue("Oldnumber", TextBox4.Text)
        If DateTimePicker1.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Contractdate", "0000-00-00")
        Else
            command.Parameters.AddWithValue("Contractdate", Convert.ToDateTime(DateTimePicker1.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker2.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Contractperiodstarts", "0000-00-00")
        Else
            command.Parameters.AddWithValue("Contractperiodstarts", Convert.ToDateTime(DateTimePicker2.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker3.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Enddate", "0000-0-00")
        Else
            command.Parameters.AddWithValue("Enddate", Convert.ToDateTime(DateTimePicker3.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker4.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", "0000-00-00")
        Else
            command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", Convert.ToDateTime(DateTimePicker4.Text).ToString("yyyy-MM-dd"))
        End If
        command.Parameters.AddWithValue("Updatecode", ComboBox7.SelectedValue)
        command.Parameters.AddWithValue("Automaticupdateinterval", ComboBox8.SelectedValue)
        command.Parameters.AddWithValue("customerNumber", ComboBox2.SelectedValue)
        command.Parameters.AddWithValue("customername_all", P_PRAM3)
        command.Parameters.AddWithValue("Yomigana_All", "")
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

            command.Parameters.AddWithValue("Surveydate", "0000/00/00")
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
            getID()
            MessageBox.Show("データが正常に更新されました")
            Me.Close()
        End If


    End Sub
    Private Sub insertdata()


        If ComboBox2.SelectedValue = 0 Then
            ComboBox2.Focus()
            MessageBox.Show("会社名を選択")
            Exit Sub
        End If
        If TextBox21.Text.Trim = "" Then
            TextBox21.Focus()
            MessageBox.Show("契約名を選択")
            Exit Sub
        End If
        If ComboBox7.SelectedValue = "none" Then
            ComboBox7.Focus()

            MessageBox.Show("[コードの更新]を選択します")

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
        command.Parameters.AddWithValue("ID", id)
        command.Parameters.AddWithValue("Controlnumber", TextBox3.Text)
        command.Parameters.AddWithValue("Indiacontract", "")
        command.Parameters.AddWithValue("Temporarynumber", id)
        command.Parameters.AddWithValue("Branchnumber", TextBox5.Text)
        command.Parameters.AddWithValue("Oldnumber", TextBox4.Text)
        If DateTimePicker1.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Contractdate", "0000-00-00")
        Else
            command.Parameters.AddWithValue("Contractdate", Convert.ToDateTime(DateTimePicker1.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker2.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Contractperiodstarts", "0000-00-00")
        Else
            command.Parameters.AddWithValue("Contractperiodstarts", Convert.ToDateTime(DateTimePicker2.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker3.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Enddate", "0000-0-00")
        Else
            command.Parameters.AddWithValue("Enddate", Convert.ToDateTime(DateTimePicker3.Text).ToString("yyyy-MM-dd"))
        End If

        If DateTimePicker4.Text.Trim() = "" Then
            command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", "0000-00-00")
        Else
            command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", Convert.ToDateTime(DateTimePicker4.Text).ToString("yyyy-MM-dd"))
        End If

        command.Parameters.AddWithValue("Updatecode", ComboBox7.SelectedValue)
        command.Parameters.AddWithValue("Automaticupdateinterval", ComboBox8.SelectedValue)
        command.Parameters.AddWithValue("customerNumber", ComboBox2.SelectedValue)
        Dim cname As String = ComboBox2.Text + "," + ComboBox3.Text + "," + ComboBox4.Text + "," + ComboBox5.Text + "," + ComboBox6.Text + "," + P_PRAM3
        command.Parameters.AddWithValue("customername_all", cname)
        command.Parameters.AddWithValue("Yomigana_All", "")
        command.Parameters.AddWithValue("Accountnumber", 11)
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

            command.Parameters.AddWithValue("Surveydate", "0000/00/00")
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
            binddata()
            getID()
            MessageBox.Show("データが正常に挿入されました")
        End If


    End Sub
    Sub ComboBox007()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT * from tm19_update_code_master"

        Try

            DB_OPEN()

            Dim command As MySqlCommand = cnn.CreateCommand()
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("ID")
            dt.Columns.Add("Update_code")
            dt.Columns.Add("Update_code_details")
            dt.Rows.Add("none", "none", "選択する")
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

            dt.Rows.Add("0", "選択する")

            dt.Rows.Add("３か月", "３か月")
            dt.Rows.Add("１年", "１年")
            dt.Rows.Add("２年", "２年")
            dt.Rows.Add("３年", "３年")
            dt.Rows.Add("協議", "協議")
            dt.Rows.Add("その他：備考欄に記入", "その他：備考欄に記入")



            ComboBox8.ValueMember = "ID"
            ComboBox8.DisplayMember = "month"
            ComboBox8.DataSource = dt
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
            dt.Rows.Add("0", "選択する")
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
        If TextBox3.Text.Trim() = "" Then
            Msg = "管理番号 Empty Not Allowed"
            TextBox3.Focus()
            Return Msg
            'ElseIf ComboBox2.SelectedIndex = -1 Then
            '    Msg = "Please select DropDown"
            '    ComboBox2.Focus()
            '    Return Msg
        ElseIf TextBox21.Text.Trim() = "" Then
            Msg = "契約書名 Empty Not Allowed"
            TextBox21.Focus()
            Return Msg
        ElseIf DateTimePicker1.CustomFormat = " " Then
            Msg = "Please select Date"
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
        P_PRAM1 = ComboBox2.SelectedValue
        P_PRAM2 = ComboBox3.SelectedValue
        P_PRAM3 = ComboBox4.SelectedValue
        P_PRAM4 = ComboBox5.SelectedValue
        P_PRAM5 = ComboBox6.SelectedValue
        ComboBox02_1()
        ComboBox03_1()
        ComboBox04_1()
        ComboBox05_1()
        ComboBox06_1()
        ComboBox2.SelectedValue = P_PRAM1
        ComboBox3.SelectedValue = P_PRAM2
        ComboBox4.SelectedValue = P_PRAM3
        ComboBox5.SelectedValue = P_PRAM4
        ComboBox6.SelectedValue = P_PRAM5
        cmbAdd()
    End Sub
    Sub cmbAdd()
        Dim i = 5
        Dim Index As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "
        sql += "WHERE Customer_name like @CSearch "
        Try



            For Index = 6 To Index

                DB_OPEN()
                Dim command As MySqlCommand = cnn.CreateCommand()
                command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
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
                    If selectedvalue <> 0 Then
                        dt.Rows.Add("0", "選択する")
                    End If

                    dt.Rows.Add(selectedvalue, selectedtext)
                    command.CommandText = sql
                    Reader = command.ExecuteReader()
                    dt.Load(Reader)
                    DB_CLOSE()
                    txt.DataSource = dt
                    txt.ValueMember = "Account_number"
                    txt.DisplayMember = "Customer_name"
                    txt.SelectedValue = selectedvalue
                End If


            Next

        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub cmbremove()
        Dim i = 5
        Dim Index As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "
        'sql += "FROM Tm14_取引先マスター"
        Try

            For Index = 6 To Index

                DB_OPEN()
                Dim command As MySqlCommand = cnn.CreateCommand()
                command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
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
                    dt.Rows.Add("0", "選択する")
                    command.CommandText = sql
                    Reader = command.ExecuteReader()
                    dt.Load(Reader)
                    DB_CLOSE()
                    txt.DataSource = dt
                    txt.ValueMember = "Account_number"
                    txt.DisplayMember = "Customer_name"
                    txt.SelectedValue = selectedvalue
                End If


            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ComboBox02_1()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "
        sql += "WHERE Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
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
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "
        sql += "WHERE Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
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
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "
        sql += "WHERE Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
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
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "
        sql += "WHERE Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
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
        sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "
        sql += "WHERE Customer_name like @CSearch "

        Try

            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            command.Parameters.AddWithValue("CSearch", TextBox1.Text + "%")
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
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
        TextBox1.Text = ""
        Dim cmb1 = ComboBox2.SelectedValue
        Dim cmb2 = ComboBox3.SelectedValue
        Dim cmb3 = ComboBox4.SelectedValue
        Dim cmb4 = ComboBox5.SelectedValue
        Dim cmb5 = ComboBox6.SelectedValue
        binddata()
        ComboBox2.SelectedValue = cmb1
        ComboBox3.SelectedValue = cmb2
        ComboBox4.SelectedValue = cmb3
        ComboBox5.SelectedValue = cmb4
        ComboBox6.SelectedValue = cmb5
        cmbremove()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

        'If (DateTimePicker1.Value = DateTimePicker.MinimumDateTime) Then

        '    DateTimePicker1.Value = DateTime.Now
        '    DateTimePicker1.Format = DateTimePickerFormat.Custom
        '    DateTimePicker1.CustomFormat = " "

        'Else
        '    DateTimePicker1.Value = DateTime.Now
        '    DateTimePicker1.Format = DateTimePickerFormat.Custom
        '    DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        'End If
    End Sub

    Private Sub DateTimePicker1_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.TextChanged
        If (DateTimePicker1.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = " "
        Else

            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        End If
    End Sub

    Private Sub DateTimePicker2_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.TextChanged
        If (DateTimePicker2.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = " "
        Else

            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = "yyyy/MM/dd"
        End If
    End Sub

    Private Sub DateTimePicker3_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.TextChanged
        If (DateTimePicker3.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker3.Format = DateTimePickerFormat.Custom
            DateTimePicker3.CustomFormat = " "
        Else

            DateTimePicker3.Format = DateTimePickerFormat.Custom
            DateTimePicker3.CustomFormat = "yyyy/MM/dd"
        End If
    End Sub

    Private Sub DateTimePicker4_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.TextChanged
        If (DateTimePicker4.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker4.Format = DateTimePickerFormat.Custom
            DateTimePicker4.CustomFormat = " "
        Else

            DateTimePicker4.Format = DateTimePickerFormat.Custom
            DateTimePicker4.CustomFormat = "yyyy/MM/dd"
        End If
    End Sub

    Private Sub DateTimePicker5_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker5.TextChanged
        If (DateTimePicker5.Value = DateTimePicker.MinimumDateTime) Then

            DateTimePicker5.Format = DateTimePickerFormat.Custom
            DateTimePicker5.CustomFormat = " "
        Else

            DateTimePicker5.Format = DateTimePickerFormat.Custom
            DateTimePicker5.CustomFormat = "yyyy/MM/dd"
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Panel2.AutoScroll = True
            Panel2.AutoScrollPosition = New Point(Panel2.AutoScrollPosition.X, Panel2.VerticalScroll.Maximum)

            Dim strSQL As String = Nothing
            Dim BindValues As String = Nothing

            sql = "SELECT  CONCAT(Customer_name,' : ',Account_number) as Customer_name,Account_number  FROM tm14_account_master "
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()

            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()
            dt.Columns.Add("Account_number")
            dt.Columns.Add("Customer_name")
            dt.Rows.Add("0", "選択する")
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
                ElseIf count = 5 Then
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

                Dim CheckBox As CheckBox = New CheckBox


                If count = 1 Then
                    CheckBox.Location = New System.Drawing.Point(620, 80)

                ElseIf count = 2 Then
                    CheckBox.Location = New System.Drawing.Point(620, (70 + (23 * count)))
                ElseIf count = 3 Then
                    CheckBox.Location = New System.Drawing.Point(620, (70 + (25 * count)))
                ElseIf count = 5 Then
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

        Dim Index As Integer = Panel2.Controls.OfType(Of ComboBox).ToList.Count
        Dim cname As String = ComboBox2.Text + "," + ComboBox3.Text + "," + ComboBox4.Text + "," + ComboBox5.Text + "," + ComboBox6.Text + "," + P_PRAM3
        P_PRAM3 = ComboBox2.Text
        If (ComboBox3.SelectedValue <> 0) Then
            P_PRAM3 += ", " + ComboBox3.Text
        End If
        If (ComboBox4.SelectedValue <> 0) Then
            P_PRAM3 += ", " + ComboBox4.Text
        End If
        If (ComboBox5.SelectedValue <> 0) Then
            P_PRAM3 += ", " + ComboBox5.Text
        End If
        If (ComboBox6.SelectedValue <> 0) Then
            P_PRAM3 += ", " + ComboBox6.Text
        End If

        Dim i = 5
        For Index = 6 To Index
            i += 1
            Dim cmb = "drp" + Convert.ToString(i)
            Dim chk = "btnDelete_" + Convert.ToString(i)
            If cmb <> "drp1" Then
                Dim txt As ComboBox = CType(Panel2.Controls.Find((cmb), True)(0), ComboBox)
                Dim chkbox As CheckBox = CType(Panel2.Controls.Find((chk), True)(0), CheckBox)
                If chkbox.Checked = False Then
                    If txt.SelectedValue <> 0 Then
                        P_PRAM2 += "," + txt.SelectedValue
                        P_PRAM3 += ", " + txt.Text
                    End If
                End If


            End If
        Next

    End Sub


End Class