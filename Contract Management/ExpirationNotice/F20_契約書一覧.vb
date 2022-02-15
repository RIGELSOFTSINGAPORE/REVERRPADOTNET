Imports System.IO
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Text
Imports ClosedXML.Excel

Public Class F20_契約書一覧

    'Dim connection As SqlConnection
    Dim command As MySqlCommand
    Dim adapter As New MySqlDataAdapter()
    Dim ds, ds1 As New DataSet()
    Dim boolbtn As Boolean
    'Dim SqlCmd1 As mysqlcl
    'Dim connection As MySqlConnection
    Dim sql As String = Nothing

    Private Sub F20_契約書一覧_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.MaximizeBox = False

        ComboBox()
        'inz()
        'If r <> 0 Then
        '    Me.BindGrid()
        boolbtn = True
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = " "
    End Sub

    Sub ComboBox()
        Dim strSQL As String = Nothing
        Dim BindValues As String = Nothing
        sql = "SELECT Update_code, CONCAT(Update_code,' : ',Update_code_details) as Update_code_details , ID "
        sql += "FROM tm19_update_code_master"
        Try
            DB_OPEN()
            Dim command As MySqlCommand = cnn.CreateCommand()
            command.CommandText = sql
            Dim Reader As MySqlDataReader
            Dim dt = New DataTable()

            command.CommandText = sql
            Reader = command.ExecuteReader()
            dt.Load(Reader)
            DB_CLOSE()

            ComboBox1.ValueMember = "Update_code"
            ComboBox1.DisplayMember = "Update_code_details"
            ComboBox1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.BindGrid()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        DateTimePicker1.Text = String.Empty
        DateTimePicker1.CustomFormat = " "
        CheckBox1.Checked = False
        ComboBox1.SelectedIndex = -1
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        'Me.BindGrid()
        TextBox8.Text = "0"
        ds.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Me.Hide()
        'Dim F00_Form23 As New F23_枝番入力画面
        'F00_Form23.ShowDialog()
        ''Me.Show()
        'Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim strFile, strData As String
            Dim DtView1 As DataView

            Dim sfd As New SaveFileDialog
            'sfd.FileName = "入金確認" & Format(Now, "yyyyMMddHHmmss") & ".csv"
            sfd.FileName = "契約書一覧.xlsx"
            sfd.Filter = "(*.xlsx)|*.xlsx"
            sfd.FilterIndex = 2
            sfd.Title = "保存先のファイルを選択してください"
            sfd.RestoreDirectory = True

            sfd.OverwritePrompt = True
            sfd.CheckPathExists = True

            ' If Not ds.Tables(1).Rows.CountCount = 0 Then
            If sfd.ShowDialog() = DialogResult.OK Then     'ダイアログを表示する
                    strFile = sfd.FileName   'OKボタンがクリックされたとき

                    'Dim swFile As New System.IO.StreamWriter(strFile, False, Encoding.UTF8)
                    'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

                    'データを書き込む
                    'strData = "ID,管理番号,仮番号,枝番,旧番号,契約日,契約期間開始,契約期間終了予定日,終了日,更新コード,自動更新間隔,取引先番号_全,"
                    'strData += "取引先名_全,ヨミガナ_全,契約書名,部署番号,管理部署,契約担当,備考,削除,インド"
                    'swFile.WriteLine(strData)
                    Dim ExportCSV = New DataTable("契約書一覧")
                    ExportCSV.Columns.Add("ID").ToString()
                    ExportCSV.Columns.Add("管理番号")
                    ExportCSV.Columns.Add("仮番号")
                    ExportCSV.Columns.Add("枝番")
                    ExportCSV.Columns.Add("旧番号")
                    ExportCSV.Columns.Add("契約日")
                    ExportCSV.Columns.Add("契約期間開始")
                    ExportCSV.Columns.Add("契約期間終了予定日")
                    ExportCSV.Columns.Add("終了日")
                    ExportCSV.Columns.Add("更新コード")
                    ExportCSV.Columns.Add("自動更新間隔")
                    ExportCSV.Columns.Add("取引先番号_全")
                    ExportCSV.Columns.Add("取引先名_全")
                    ExportCSV.Columns.Add("ヨミガナ_全")
                    ExportCSV.Columns.Add("契約書名")
                    ExportCSV.Columns.Add("部署番号")
                    ExportCSV.Columns.Add("管理部署")
                    ExportCSV.Columns.Add("契約担当")
                    ExportCSV.Columns.Add("備考")
                    ExportCSV.Columns.Add("削除")
                    ExportCSV.Columns.Add("インド")
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    'ds.Clear()
                    DtView1 = New DataView(ds.Tables("T20_契約書管理"), "", "", DataViewRowState.CurrentRows)
                    For i = 0 To DtView1.Count - 1
                        Dim _dr As DataRow = ExportCSV.NewRow()
                        _dr("ID") = Convert.ToString(DtView1(i)("ID"))
                        _dr("管理番号") = Convert.ToString(DtView1(i)("管理番号"))
                        _dr("仮番号") = Convert.ToString(DtView1(i)("仮番号"))
                        _dr("枝番") = Convert.ToString(DtView1(i)("枝番"))
                        _dr("旧番号") = Convert.ToString(DtView1(i)("旧番号"))
                        If Not IsDBNull(DtView1(i)("契約日")) Then
                        _dr("契約日") = Convert.ToDateTime(DtView1(i)("契約日")).ToString("yyyy-MM-dd")
                    End If
                        If Not IsDBNull(DtView1(i)("契約開始")) Then
                        _dr("契約期間開始") = Convert.ToDateTime(DtView1(i)("契約開始")).ToString("yyyy-MM-dd")
                    End If
                        If Not IsDBNull(DtView1(i)("契約終了予定日")) Then
                        _dr("契約期間終了予定日") = Convert.ToDateTime(DtView1(i)("契約終了予定日")).ToString("yyyy-MM-dd")
                    End If


                    If Not IsDBNull(DtView1(i)("終了日")) Then
                        _dr("終了日") = Convert.ToDateTime(DtView1(i)("終了日")).ToString("yyyy-MM-dd")
                    End If

                    _dr("更新コード") = Convert.ToString(DtView1(i)("更新コード"))
                        _dr("自動更新間隔") = Convert.ToString(DtView1(i)("自動更新間隔"))
                        _dr("取引先番号_全") = Convert.ToString(DtView1(i)("取引先番号_全"))
                        _dr("取引先名_全") = Convert.ToString(DtView1(i)("取引先名"))
                        _dr("ヨミガナ_全") = Convert.ToString(DtView1(i)("ヨミガナ_全"))
                        _dr("契約書名") = Convert.ToString(DtView1(i)("契約書名"))
                        _dr("部署番号") = Convert.ToString(DtView1(i)("部署番号"))
                        _dr("管理部署") = Convert.ToString(DtView1(i)("管理部署"))
                        _dr("契約担当") = Convert.ToString(DtView1(i)("契約担当"))
                        _dr("備考") = Convert.ToString(DtView1(i)("備考"))
                        _dr("削除") = Convert.ToString(DtView1(i)("削除"))
                        _dr("インド") = Convert.ToString(DtView1(i)("インド"))





                        'strData = DtView1(i)("ID")                       '取扱店
                        'strData = strData & "," & DtView1(i)("管理番号")       '申込日
                        'strData = strData & "," & DtView1(i)("仮番号")            '加入番号
                        'strData = strData & "," & DtView1(i)("枝番")       '氏名
                        ''strData = strData & "," & Combo01.Text                  '加入者状況
                        'strData = strData & "," & DtView1(i)("旧番号")         '加入者請求金額
                        'strData = strData & "," & DtView1(i)("契約日")       '加入者請求日
                        'strData = strData & "," & DtView1(i)("契約開始")       '加入者入金日
                        'strData = strData & "," & DtView1(i)("契約終了予定日")                       '取扱店
                        'strData = strData & "," & DtView1(i)("終了日")       '申込日
                        'strData = strData & "," & DtView1(i)("更新コード").ToString().Replace(vbCr, "").Replace(vbLf, "")            '加入番号
                        'strData = strData & "," & DtView1(i)("自動更新間隔").ToString().Replace(vbCr, "").Replace(vbLf, "")      '氏名
                        'strData = strData & "," & DtView1(i)("取引先番号_全").ToString().Replace(vbCr, "").Replace(vbLf, "")
                        'strData = strData & "," & (DtView1(i)("取引先名").ToString().Replace(vbCr, "").Replace(vbLf, "")) ' prabu column name chaned
                        'strData = strData & "," & (DtView1(i)("ヨミガナ_全").ToString().Replace(vbCr, "").Replace(vbLf, ""))
                        'strData = strData & "," & (DtView1(i)("契約書名").ToString().Replace(vbCr, "").Replace(vbLf, ""))
                        ''strData = strData & "," & Combo01.Text                  
                        'strData = strData & "," & DtView1(i)("部署番号").ToString().Replace(vbCr, "").Replace(vbLf, "")
                        'strData = strData & "," & DtView1(i)("管理部署").ToString().Replace(vbCr, "").Replace(vbLf, "")
                        'strData = strData & "," & DtView1(i)("契約担当").ToString().Replace(vbCr, "").Replace(vbLf, "")
                        'strData = strData & "," & DtView1(i)("備考").ToString().Replace(vbCr, "").Replace(vbLf, "")
                        'strData = strData & "," & DtView1(i)("削除").ToString().Replace(vbCr, "").Replace(vbLf, "")
                        'strData = strData & "," & DtView1(i)("インド").ToString().Replace(vbCr, "").Replace(vbLf, "")
                        'strData = Replace(strData, System.Environment.NewLine, "")
                        ExportCSV.Rows.Add(_dr)
                        'swFile.WriteLine(strData)
                    Next



                    'swFile.Close()
                    Using wb = New XLWorkbook

                        Dim Filaname = strFile

                        wb.Worksheets.Add(ExportCSV)
                        wb.Worksheet("契約書一覧").Columns().AdjustToContents()


                        wb.SaveAs(Filaname)
                        'System.IO.File.Move(Filaname, filaneme1)


                        'wb.SaveAs(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnameYREA);                    
                    End Using

                'ファイルを閉じる
                MessageBox.Show("ファイルのエクスポートが成功しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ' MessageBox.Show("ファイルのエクスポートが成功しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            ' End If





            Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim strFile, strData As String
        Dim DtView1 As DataView
        Dim sfd As New SaveFileDialog
        'Dim sfd As New SaveFileDialog                           
        'sfd.FileName = "加入者リスト" & Format(Now, "yyyyMMddHHmmss") & ".CSV"
        sfd.FileName = "契約書_全データ.xlsx"
        sfd.Filter = "(*.xlsx)|*.xlsx"
        sfd.FilterIndex = 2
        sfd.Title = "保存先のファイルを選択してください"
        sfd.RestoreDirectory = True
        sfd.OverwritePrompt = True
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then
            strFile = sfd.FileName
            'Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.GetEncoding("utf-8"))
            'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)
            'strData = "ID,管理番号,仮番号,枝番,旧番号,契約日,契約期間開始,契約期間終了予定日,終了日,更新コード,自動更新間隔,取引先番号_全,"
            'strData += "取引先名_全,ヨミガナ_全,契約書名,部署番号,管理部署,契約担当,備考,削除,インド"
            'swFile.WriteLine(strData)
            Dim ExportCSV = New DataTable("契約書_全データ")
            ExportCSV.Columns.Add("ID").ToString()
            ExportCSV.Columns.Add("管理番号")
            ExportCSV.Columns.Add("仮番号")
            ExportCSV.Columns.Add("枝番")
            ExportCSV.Columns.Add("旧番号")
            ExportCSV.Columns.Add("契約日")
            ExportCSV.Columns.Add("契約期間開始")
            ExportCSV.Columns.Add("契約期間終了予定日")
            ExportCSV.Columns.Add("終了日")
            ExportCSV.Columns.Add("更新コード")
            ExportCSV.Columns.Add("自動更新間隔")
            ExportCSV.Columns.Add("取引先番号_全")
            ExportCSV.Columns.Add("取引先名_全")
            ExportCSV.Columns.Add("ヨミガナ_全")
            ExportCSV.Columns.Add("契約書名")
            ExportCSV.Columns.Add("部署番号")
            ExportCSV.Columns.Add("管理部署")
            ExportCSV.Columns.Add("契約担当")
            ExportCSV.Columns.Add("備考")
            ExportCSV.Columns.Add("削除")
            ExportCSV.Columns.Add("インド")
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            ds1.Clear()
            Try
                DB_OPEN()
                sql = "Select   t20_contract_management.ID, t20_contract_management.Control_number, t20_contract_management.Temporary_number, t20_contract_management.India_contract, t20_contract_management.Branch_number, "
                sql += "t20_contract_management.Old_number, t20_contract_management.Contract_date, t20_contract_management.Contract_period_starts, t20_contract_management.Scheduled_end_date_of_contract_period, t20_contract_management.End_date, "
                sql += "t20_contract_management.Update_code, t20_contract_management.Automatic_update_interval, t20_contract_management.Account_number_all,t20_contract_management.Account_name_all, "
                sql += "t20_contract_management.Yomigana_All, t20_contract_management.Contract_name, t20_contract_management.Department_number, tm15_department_master.Management_department, t20_contract_management.Contractor, "
                sql += "t20_contract_management.remarks, t20_contract_management.End, t20_contract_management.India, tm15_department_master.Delete, t20_contract_management.Delete As 削除_1 "
                'sql += "FROM tm15_department_master RIGHT JOIN (t20_contract_management LEFT JOIN tm19_update_code_master On t20_contract_management.Update_code = tm19_update_code_master.Update_code) "
                'sql += "On tm15_department_master.Department_number = t20_contract_management.Department_number "
                sql += " FROM t20_contract_management LEFT JOIN tm15_department_master ON  "
                sql += " t20_contract_management.Department_number = tm15_department_master.Department_number "
                sql += "WHERE t20_contract_management.Delete= 0 "
                'sql += "WHERE (((tm15_department_master.Delete) Is Null Or (tm15_department_master.Delete)=False)) "
                'sql += "WHERE t20_contract_management.Delete= 0 ORDER BY t20_contract_management.ID"
                sql += "ORDER BY t20_contract_management.ID "
                Dim command As MySqlCommand = cnn.CreateCommand()
                command.CommandText = sql
                'command = cnn.CreateCommand()
                adapter.SelectCommand = command
                'DB_OPEN()
                adapter.Fill(ds1, "T21_契約書管理")
                DB_CLOSE()

                DtView1 = New DataView(ds1.Tables("T21_契約書管理"), "", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    For i = 0 To DtView1.Count - 1
                        Dim _dr As DataRow = ExportCSV.NewRow()
                        _dr("ID") = Convert.ToString(DtView1(i)("ID"))
                        _dr("管理番号") = Convert.ToString(DtView1(i)("Control_number"))
                        _dr("仮番号") = Convert.ToString(DtView1(i)("Temporary_number"))
                        _dr("枝番") = Convert.ToString(DtView1(i)("Branch_number"))
                        _dr("旧番号") = Convert.ToString(DtView1(i)("Old_number"))
                        If Not IsDBNull(DtView1(i)("Contract_date")) Then
                            _dr("契約日") = Convert.ToDateTime(DtView1(i)("Contract_date")).ToString("yyyy-MM-dd")
                        End If
                        If Not IsDBNull(DtView1(i)("Contract_period_starts")) Then
                            _dr("契約期間開始") = Convert.ToDateTime(DtView1(i)("Contract_period_starts")).ToString("yyyy-MM-dd")
                        End If
                        If Not IsDBNull(DtView1(i)("Scheduled_end_date_of_contract_period")) Then
                            _dr("契約期間終了予定日") = Convert.ToDateTime(DtView1(i)("Scheduled_end_date_of_contract_period")).ToString("yyyy-MM-dd")
                        End If


                        If Not IsDBNull(DtView1(i)("End_date")) Then
                            _dr("終了日") = Convert.ToDateTime(DtView1(i)("End_date")).ToString("yyyy-MM-dd")

                        End If


                        _dr("更新コード") = Convert.ToString(DtView1(i)("Update_code"))
                        _dr("自動更新間隔") = Convert.ToString(DtView1(i)("Automatic_update_interval"))
                        _dr("取引先番号_全") = Convert.ToString(DtView1(i)("Account_number_all"))
                        _dr("取引先名_全") = Convert.ToString(DtView1(i)("Account_name_all"))
                        _dr("ヨミガナ_全") = Convert.ToString(DtView1(i)("Yomigana_All"))
                        _dr("契約書名") = Convert.ToString(DtView1(i)("Contract_name"))
                        _dr("部署番号") = Convert.ToString(DtView1(i)("Department_number"))
                        _dr("管理部署") = Convert.ToString(DtView1(i)("Management_department"))
                        _dr("契約担当") = Convert.ToString(DtView1(i)("Contractor"))
                        _dr("備考") = Convert.ToString(DtView1(i)("remarks"))
                        _dr("削除") = Convert.ToString(DtView1(i)("Delete"))
                        _dr("インド") = Convert.ToString(DtView1(i)("India"))


                        'strData = DtView1(i)("ID")                       '取扱店
                        'strData = strData & "," & DtView1(i)("Control_number")       '申込日
                        'strData = strData & "," & DtView1(i)("Temporary_number")            '加入番号
                        'strData = strData & "," & DtView1(i)("Branch_number")       '氏名
                        ''strData = strData & "," & Combo01.Text                  '加入者状況
                        'strData = strData & "," & DtView1(i)("Old_number")         '加入者請求金額
                        'strData = strData & "," & DtView1(i)("Contract_date")       '加入者請求日
                        'strData = strData & "," & DtView1(i)("Contract_period_starts")       '加入者入金日
                        'strData = strData & "," & DtView1(i)("Scheduled_end_date_of_contract_period")                       '取扱店
                        'strData = strData & "," & DtView1(i)("End_date")       '申込日
                        'strData = strData & "," & DtView1(i)("Update_code")            '加入番号
                        'strData = strData & "," & DtView1(i)("Automatic_update_interval")       '氏名
                        'strData = strData & "," & DtView1(i)("Account_number_all")
                        'strData = strData & "," & DtView1(i)("Account_name_all")
                        'strData = strData & "," & DtView1(i)("Yomigana_All")
                        'strData = strData & "," & DtView1(i)("Contract_name")
                        ''strData = strData & "," & Combo01.Text                  
                        'strData = strData & "," & DtView1(i)("Department_number")
                        'strData = strData & "," & DtView1(i)("Management_department")
                        'strData = strData & "," & DtView1(i)("Contractor")
                        'strData = strData & "," & DtView1(i)("remarks")
                        'strData = strData & "," & DtView1(i)("Delete")
                        'strData = strData & "," & DtView1(i)("India")
                        'strData = Replace(strData, System.Environment.NewLine, "")
                        'swFile.WriteLine(strData)
                        ExportCSV.Rows.Add(_dr)

                    Next
                    Using wb = New XLWorkbook

                        Dim Filaname = strFile
                        wb.Worksheets.Add(ExportCSV)
                        wb.Worksheet("契約書_全データ").Columns().AdjustToContents()
                        wb.SaveAs(Filaname)
                    End Using
                    'swFile.Close()
                    MessageBox.Show("ファイルのエクスポートが成功しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("レコードが見つかりません", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                Cursor = System.Windows.Forms.Cursors.Default
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim filename As String
        Dim t20id As Integer = 0
        Dim dptnum As Integer = 0
        Dim dptnum1 As Integer = 0

        'If System.IO.File.Exists(filenamget) Then

        'Else
        '    MsgBox("Import file doesn't exist")
        'End If

        With OpenFileDialog1
            '.InitialDirectory = filename
            .CheckFileExists = True     'ファイルが存在するか確認
            .RestoreDirectory = True    'ディレクトリの復元
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "CSV ﾌｧｲﾙ(*.csv)|*.csv"
            .FilterIndex = 0
            'ダイアログボックスを表示し、［開く]をクリックした場合
            If .ShowDialog = DialogResult.OK Then
                Try
                    Dim srFile As New System.IO.StreamReader(.FileName, System.Text.Encoding.Default)
                    Dim strLine As String = srFile.ReadLine()
                Catch ex As Exception
                    If TypeOf ex Is IO.IOException Then
                        MsgBox("ファイルはすでに開いています。閉じてください")
                        Cursor = System.Windows.Forms.Cursors.Default
                        Exit Sub
                    End If
                End Try
                filename = .FileName
                Dim filenamget As String = System.IO.Path.GetFileName(filename)
                Dim filenamgetext As String = System.IO.Path.GetExtension(filename)

                If filenamget <> "契約書管理.csv" Then
                    MsgBox("ファイル名InValid !")
                    Exit Sub
                Else
                    Dim csvData As String = System.IO.File.ReadAllText(Path.Combine(filename))
                    Dim bool As Boolean = False
                    'If csvData.Split(vbLf).Length > 1 Then
                    '    'bool = checkColheader(csvData.Split(vbLf)(0))
                    '    'ConvertCSVtoDataTable(filename)
                    'End If

                    Dim dtNew As DataTable = New DataTable()
                    dtNew = ConvertCSVtoDataTable(filename)

                    'If Convert.ToString(dtNew.Columns(0)).ToLower() <> "lookupcode" Then
                    '    MessageBox.Show("Invalid Items File")
                    'End If

                    Try

                        Dim dtItem As DataTable = CType((dtNew), DataTable)
                        Dim ID As Integer
                        Dim Mgt_num, Temp_num, Bran_num, Old_number, Contract_Date, Contr_pe_comm, ScheduledEndDate, EndDate, Update_code, AutomaUpdateinter,
                        Accountnumber_all, Customer_name_all, Yomigana_All, Contract_name, Department_number, Management_department, Contractor, Remarks As String

                        Dim Delete, India As Boolean


                        Dim sqlupd As String = Nothing
                        Dim sqlins As String = Nothing
                        Dim count As Integer = 0
                        Dim dt As New DataTable
                        For Each dr As DataRow In dtItem.Rows
                            ID = Convert.ToString(dr("ID"))
                            Mgt_num = Convert.ToString(dr("Mgt number"))
                            Temp_num = Convert.ToString(dr("Temporary number"))
                            Bran_num = Convert.ToString(dr("Branch number"))
                            Old_number = Convert.ToString(dr("Old number"))
                            Contract_Date = Convert.ToString(dr("Contract date"))
                            Contr_pe_comm = Convert.ToString(dr("Contract period commencement"))
                            ScheduledEndDate = Convert.ToString(dr("Scheduled end date of contract period"))
                            EndDate = Convert.ToString(dr("End date"))
                            Update_code = Convert.ToString(dr("Update code"))
                            AutomaUpdateinter = Convert.ToString(dr("Automatic update interval"))
                            Accountnumber_all = Convert.ToString(dr("Account number_all"))
                            Customer_name_all = Convert.ToString(dr("Customer name_all"))
                            Yomigana_All = Convert.ToString(dr("Yomigana_All"))
                            Contract_name = Convert.ToString(dr("Contract name"))
                            Department_number = Convert.ToString(dr("Department Number"))
                            'Tm15_部署マスター.管理部署 tbl column
                            Management_department = Convert.ToString(dr("Management department"))
                            Contractor = Convert.ToString(dr("Contractor"))
                            Remarks = Convert.ToString(dr("Remarks"))

                            Delete = Convert.ToBoolean(dr("Delete"))
                            India = Convert.ToBoolean(dr("India"))

                            'IF ID Exists in table update information else insert information
                            Try
                                DB_OPEN()
                                Dim command As MySqlCommand = cnn.CreateCommand()
                                Dim Reader As MySqlDataReader
                                Dim query1 As String = "select tm15_department_master.Department_number from tm15_department_master where tm15_department_master.Department_number= '" & Department_number & "' "
                                command.CommandText = query1
                                Reader = command.ExecuteReader()
                                While Reader.Read
                                    dptnum = Reader("Department_number")
                                End While
                                DB_CLOSE()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try

                            If dptnum > 0 Then
                                Try
                                    DB_OPEN()
                                    Dim query1 As String = "UPDATE tm15_department_master SET tm15_department_master.Management_department = '" & Management_department & "' "
                                    query1 += " WHERE (tm15_department_master.Department_number = '" & Department_number & "')"
                                    Dim command As MySqlCommand = cnn.CreateCommand()
                                    command.CommandText = query1
                                    command.ExecuteNonQuery()
                                    DB_CLOSE()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message)
                                End Try
                            Else
                                Try
                                    DB_OPEN()
                                    Dim query1 As String = "insert into tm15_department_master (id, Management_department, Department_number  ) values "
                                    query1 += " ('" & Department_number & "','" & Management_department & "', '" & Department_number & "')"
                                    Dim command As MySqlCommand = cnn.CreateCommand()
                                    command.CommandText = query1
                                    command.ExecuteNonQuery()
                                    DB_CLOSE()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message)
                                End Try
                            End If
                            Try
                                DB_OPEN()
                                Dim command As MySqlCommand = cnn.CreateCommand()
                                Dim Reader As MySqlDataReader
                                Dim query1 As String = "select * from  tm14_account_master where Account_number= '" & Accountnumber_all & "' "
                                command.CommandText = query1
                                Reader = command.ExecuteReader()
                                dptnum = 0
                                While Reader.Read
                                    dptnum = Reader("Account_number")
                                End While
                                DB_CLOSE()

                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                            If dptnum > 0 Then
                                Try

                                    DB_OPEN()
                                    Dim query1 As String = "UPDATE tm14_account_master SET Account_number = '" & Accountnumber_all & "', "
                                    query1 += " Customer_name = '" & Customer_name_all & "', "
                                    query1 += " Yomigana = '" & Yomigana_All & "' "
                                    query1 += " WHERE (Account_number = '" & Accountnumber_all & "')"
                                    Dim command As MySqlCommand = cnn.CreateCommand()
                                    command.CommandText = query1
                                    command.ExecuteNonQuery()
                                    DB_CLOSE()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message)
                                End Try
                            Else
                                Try
                                    DB_OPEN()
                                    Dim query1 As String = "insert into tm14_account_master (Customer_name, Yomigana, Account_number,`delete`) values "
                                    query1 += " ('" & Customer_name_all & "','" & Yomigana_All & "', '" & Accountnumber_all & "',0)"
                                    Dim command As MySqlCommand = cnn.CreateCommand()
                                    command.CommandText = query1
                                    command.ExecuteNonQuery()
                                    DB_CLOSE()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message)
                                End Try
                            End If

                            Try
                                DB_OPEN()
                                Dim command As MySqlCommand = cnn.CreateCommand()

                                Dim Reader1 As MySqlDataReader
                                'Reader.Close()
                                Dim query22 As String = "select Count(ID) as cnt from t20_contract_management where t20_contract_management.ID= '" & Convert.ToString(dr("ID")) & "' "
                                command.CommandText = query22
                                Reader1 = command.ExecuteReader()
                                'If Reader.Depth > 0 Then

                                While Reader1.Read
                                    dptnum1 = Reader1("cnt")
                                End While
                                'End If
                                DB_CLOSE()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                            If dptnum1 > 0 Then
                                DB_OPEN()
                                sqlupd = "UPDATE t20_contract_management"
                                sqlupd += " SET t20_contract_management.Control_number = '" & Mgt_num & "'"

                                'sqlupd += ", t20_contract_management.管理番号 = '" & Mgt_num & "'"
                                sqlupd += ", t20_contract_management.Temporary_number = '" & Temp_num & "'"
                                sqlupd += ", t20_contract_management.Branch_number = '" & Bran_num & "'"
                                sqlupd += ", t20_contract_management.Old_number = '" & Old_number & "'"
                                sqlupd += ", t20_contract_management.Contract_date = '" & Contract_Date & "'"
                                sqlupd += ", t20_contract_management.Contract_period_starts = '" & Contr_pe_comm & "'"
                                sqlupd += ", t20_contract_management.Scheduled_end_date_of_contract_period = '" & ScheduledEndDate & "'"

                                If Not String.IsNullOrEmpty(EndDate) Then
                                    sqlupd += ", t20_contract_management.End_date = '" & EndDate & "'"
                                Else
                                    sqlupd += ", t20_contract_management.End_date = NULL"
                                End If

                                sqlupd += ", t20_contract_management.Update_code = '" & Update_code & "'"
                                sqlupd += ", t20_contract_management.Automatic_update_interval= '" & AutomaUpdateinter & "'"
                                sqlupd += ", t20_contract_management.Account_number_all = '" & Accountnumber_all & "'"
                                sqlupd += ", t20_contract_management.Temporary_company_number_1 = '" & Accountnumber_all & "'"

                                sqlupd += ", t20_contract_management.Account_name_all = '" & Customer_name_all & "'"

                                sqlupd += ", t20_contract_management.Yomigana_All = '" & Yomigana_All & "'"
                                sqlupd += ", t20_contract_management.Contract_name = '" & Contract_name & "'"

                                sqlupd += ", t20_contract_management.Department_number = '" & Department_number & "'"

                                'Tm15_部署マスター.管理部署 tbl column
                                'sqlupd += ", t20_contract_management.管理部署 = '" & Management_department & "'"
                                sqlupd += ", t20_contract_management.Contractor = '" & Contractor & "'"

                                sqlupd += ", t20_contract_management.Remarks = '" & Remarks & "'"
                                sqlupd += ", t20_contract_management.Delete = " & Delete & ""
                                sqlupd += ", t20_contract_management.India = " & India & ""
                                'sqlupd += " SET t20_contract_management.インド = " & Delete & ""

                                sqlupd += " WHERE (t20_contract_management.ID = '" & ID & "')"
                                Dim command As MySqlCommand = cnn.CreateCommand()
                                command.CommandText = sqlupd
                                command.ExecuteNonQuery()
                                DB_CLOSE()
                            Else
                                DB_OPEN()
                                Dim command As MySqlCommand = cnn.CreateCommand()
                                Dim query As String = "INSERT INTO `t20_contract_management`"
                                query += "(`ID`,"
                                query += "`Control_number`,"
                                'query += "`管理番号`,"
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
                                query += "`Temporary_company_number_1`,"
                                query += "`Account_name_all`,"
                                query += "`Yomigana_All`,"
                                query += "`Contract_name`,"
                                query += "`Department_number`,"
                                'query += "`部署番号`,"
                                'Tm15_部署マスター.管理部署 tbl column
                                'query += "`管理部署`,"

                                query += "`Contractor`,"
                                query += "`remarks`,"
                                query += "`Delete`,"
                                'query += "`削除`,"
                                'query += "`インド`,"
                                'query += "`仮社番1`,"
                                'query += "`仮社番2`,"
                                'query += "`仮社番3`,"
                                'query += "`仮社番4`,"
                                query += "`India`)"

                                query += "VALUES"
                                query += "(@ID,"
                                query += "@mgtnumber,"
                                'query += "@Indiacontract,"
                                query += "@Temporarynumber,"
                                query += "@Branchnumber,"
                                query += "@Oldnumber,"
                                query += "@Contractdate,"
                                query += "@Contractperiodcommencement,"
                                query += "@Scheduledenddateofcontractperiod,"
                                query += "@Enddate,"
                                query += "@Updatecode,"
                                query += "@Automaticupdateinterval,"
                                query += "@Accountnumber_all,"
                                query += "@Temporary_company_number_1,"
                                query += "@Customername_all,"
                                query += "@Yomigana_All,"
                                query += "@Contractname,"
                                query += "@Departmentnumber,"


                                't15_tbl
                                'query += "@mgtdept,"
                                'query += "@Accountnumber,"
                                query += "@Contractor,"
                                query += "@remarks,"
                                'query += "@end,"
                                query += "@Delete,"
                                query += "@India);"
                                command.Parameters.AddWithValue("ID", ID)
                                command.Parameters.AddWithValue("mgtnumber", Mgt_num)
                                command.Parameters.AddWithValue("Temporarynumber", Temp_num)
                                command.Parameters.AddWithValue("Branchnumber", Bran_num)
                                command.Parameters.AddWithValue("Oldnumber", Old_number)
                                command.Parameters.AddWithValue("Contractdate", Contract_Date)
                                command.Parameters.AddWithValue("Contractperiodcommencement", Contr_pe_comm)
                                command.Parameters.AddWithValue("Scheduledenddateofcontractperiod", ScheduledEndDate)

                                If Not String.IsNullOrEmpty(EndDate) Then
                                    command.Parameters.AddWithValue("Enddate", EndDate)
                                Else
                                    command.Parameters.AddWithValue("Enddate", DBNull.Value)
                                    'sqlupd += ", Enddate = NULL"
                                End If
                                command.Parameters.AddWithValue("Updatecode", Update_code)
                                command.Parameters.AddWithValue("Automaticupdateinterval", AutomaUpdateinter)
                                command.Parameters.AddWithValue("Accountnumber_all", Accountnumber_all)
                                command.Parameters.AddWithValue("Temporary_company_number_1", Accountnumber_all)
                                command.Parameters.AddWithValue("Customername_all", Customer_name_all)
                                command.Parameters.AddWithValue("Yomigana_All", Yomigana_All)
                                command.Parameters.AddWithValue("Contractname", Contract_name)
                                command.Parameters.AddWithValue("Departmentnumber", Department_number)
                                't15_tbl
                                'command.Parameters.AddWithValue("mgtdept", Management_department)
                                command.Parameters.AddWithValue("Contractor", Contractor)
                                command.Parameters.AddWithValue("remarks", Remarks)
                                command.Parameters.AddWithValue("Delete", Delete)
                                command.Parameters.AddWithValue("India", India)

                                'sqlins = "UPDATE t20_契約書管理"
                                'sqlins += " SET t20_契約書管理.削除 = " & bool & ""
                                'sqlins += " WHERE (T20_契約書管理.管理番号 = '" & Convert.ToString(dr("ID")) & "')"
                                'Dim command22 As MySqlCommand = cnn.CreateCommand()
                                command.CommandText = query
                                command.ExecuteNonQuery()
                                DB_CLOSE()
                            End If
                            ' If Lookup <> "" AndAlso description <> "" AndAlso dept <> "" AndAlso UnitPrice <> "" Then
                            count += 1

                        Next
                        ' If InsertItemQry.Length > 5 Then
                        'DBAccess.ExecuteQuery(InsertItemQry)

                        'If isSuccess Then
                        MessageBox.Show("アイテムが正常にインポートされました, インポートされたレコードの合計 : " & count & "", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Cursor = System.Windows.Forms.Cursors.Default
                        Exit Sub
                        ' Cursor = System.Windows.Forms.Cursors.Default
                        ' dgItems.DataSource = Nothing
                        ' End If
                        ' End If

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End If

            End If

        End With
    End Sub

    'Public Shared Function ConvertCSVtoDataTable1(ByVal dt1 As DataTable) As DataTable
    '    Dim sql As String
    '    Dim adapter As MySqlDataAdapter
    '    Dim ds As DataSet
    '    Try
    '        Dim dtas As DataTable
    '        DB_OPEN()
    '        sql = "select ID from T20_契約書管理 "

    '        Dim command As MySqlCommand = cnn.CreateCommand()
    '        command.CommandText = sql
    '        'command = cnn.CreateCommand()
    '        adapter.SelectCommand = command
    '        Dim dt As New DataTable
    '        dtas = ds.Tables("T22_契約書管理")
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    '    Return dtas
    'End Function



    'Public Shared Function GetDataTabletFromCSVFile(ByVal csv_file_path As String) As DataTable
    '    Dim csvData As DataTable = New DataTable()

    '    Try

    '        If csv_file_path.EndsWith(".xlsx") Then

    '            Using csvReader As Microsoft.VisualBasic.FileIO.TextFieldParser = New Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path)
    '                csvReader.SetDelimiters(New String() {","})
    '                csvReader.HasFieldsEnclosedInQuotes = True
    '                Dim colFields As String() = csvReader.ReadFields()

    '                For Each column As String In colFields
    '                    Dim datecolumn As DataColumn = New DataColumn(column)
    '                    datecolumn.AllowDBNull = True
    '                    csvData.Columns.Add(datecolumn)
    '                Next

    '                While Not csvReader.EndOfData
    '                    Dim fieldData As String() = csvReader.ReadFields()

    '                    For i As Integer = 0 To fieldData.Length - 1

    '                        If fieldData(i) = "" Then
    '                            fieldData(i) = Nothing
    '                        End If
    '                    Next

    '                    csvData.Rows.Add(fieldData)
    '                End While
    '            End Using
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    '    Return csvData
    'End Function

    Public Shared Function ConvertCSVtoDataTable(ByVal strFilePath As String) As DataTable
        Dim dt As DataTable = New DataTable()
        Dim flag As Boolean = False
        Dim i As Integer = 0
        Try


            Using sr As StreamReader = New StreamReader(strFilePath)
                Dim headers As String() = sr.ReadLine().Split(","c)

                If headers(0).ToUpper() = "ID".ToUpper() Then
                    i += 1
                End If
                If headers(1).ToUpper() = "Mgt number".ToUpper() Then
                    i += 1
                End If

                If headers(2).ToUpper() = "Temporary number".ToUpper() Then
                    i += 1
                End If

                If headers(3).ToUpper() = "Branch number".ToUpper() Then
                    i += 1
                End If

                If headers(4).ToUpper() = "Old number".ToUpper() Then
                    i += 1
                End If

                If headers(5).ToUpper() = "Contract date".ToUpper() Then
                    i += 1
                End If

                If headers(6).ToUpper() = "Contract period commencement".ToUpper() Then
                    i += 1
                End If

                If headers(7).ToUpper() = "Scheduled end date of contract period".ToUpper() Then
                    i += 1
                End If

                If headers(8).ToUpper() = "End date".ToUpper() Then
                    i += 1
                End If

                If headers(9).ToUpper() = "Update code".ToUpper() Then
                    i += 1
                End If

                If headers(10).ToUpper() = "Automatic update interval".ToUpper() Then
                    i += 1
                End If

                If headers(11).ToUpper() = "Account number_all".ToUpper() Then
                    i += 1
                End If
                If headers(12).ToUpper() = "Customer name_all".ToUpper() Then
                    i += 1
                End If

                If headers(13).ToUpper() = "Yomigana_All".ToUpper() Then
                    i += 1
                End If

                If headers(14).ToUpper() = "Contract name".ToUpper() Then
                    i += 1
                End If

                If headers(15).ToUpper() = "Department number".ToUpper() Then
                    i += 1
                End If

                If headers(16).ToUpper() = "Management department".ToUpper() Then
                    i += 1
                End If

                If headers(17).ToUpper() = "Contractor".ToUpper() Then
                    i += 1
                End If

                If headers(18).ToUpper() = "Remarks".ToUpper() Then
                    i += 1
                End If

                If headers(19).ToUpper() = "Delete".ToUpper() Then
                    i += 1
                End If

                If headers(20).ToUpper() = "India".ToUpper() Then
                    i += 1
                End If

                If i = 21 Then
                    flag = True
                Else
                    flag = False
                End If

                If flag = False Then
                    MessageBox.Show("ヘッダーが一致しません", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Function
                End If

                'For Each row As String In headers(i)

                '    '    If row.Split(","c)(0).ToUpper() = "ID".ToUpper() Then
                '    '        i += 1
                '    '    End If

                '    '    'If row.Split(","c)(1).ToUpper() = "管理番号".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(2).ToUpper() = "仮番号".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(3).ToUpper() = "枝番".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(4).ToUpper() = "旧番号".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(5).ToUpper() = "契約日".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(6).ToUpper() = "契約期間開始".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(7).ToUpper() = "契約期間終了予定日".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(8).ToUpper() = "終了日".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(9).ToUpper() = "更新コード".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(10).ToUpper() = "自動更新間隔".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(11).ToUpper() = "取引先番号_全".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If
                '    '    'If row.Split(","c)(12).ToUpper() = "取引先名_全".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(13).ToUpper() = "ヨミガナ_全".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(14).ToUpper() = "契約書名".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(15).ToUpper() = "部署番号".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(16).ToUpper() = "管理部署".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(17).ToUpper() = "契約担当".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(18).ToUpper() = "備考".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(19).ToUpper() = "削除".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                '    '    'If row.Split(","c)(20).ToUpper() = "インド".ToUpper() Then
                '    '    '    i += 1
                '    '    'End If

                'Next
                For Each header As String In headers
                    dt.Columns.Add(header)
                Next

                While Not sr.EndOfStream
                    Dim rows As String() = sr.ReadLine().Split(","c)
                    Dim dr As DataRow = dt.NewRow()

                    For j As Integer = 0 To headers.Length - 1
                        dr(j) = rows(j)
                    Next

                    dt.Rows.Add(dr)
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'Exit Function
        End Try

        Return dt

    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ds.Clear()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Close()
        'Dim F00_Form30 As New F01_メニュー
        'F00_Form30.ShowDialog()
        'Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try

            Dim senderGrid = CType(sender, DataGridView)
        Dim bool As Boolean = True
        If e.RowIndex <> -1 Then
                If DataGridView1.RowCount > rowcolor Then
                    DataGridView1.Rows(rowcolor).DefaultCellStyle.BackColor = Color.White
                End If

                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                    rowcolor = e.RowIndex
                End If

                If (DataGridView1.Columns(e.ColumnIndex).Name = "Delete") Then
                If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
                    Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    If MessageBox.Show(String.Format("選択したレコードを削除してもよろしいですか", row.Cells("ID").Value.ToString), "確認", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                        DB_OPEN()
                        sql = "UPDATE t20_contract_management"
                        sql += " SET t20_contract_management.Delete = " & bool & ""
                        sql += " WHERE (t20_contract_management.ID = '" & row.Cells("ID").Value.ToString & "')"
                        Dim command As MySqlCommand = cnn.CreateCommand()
                        command.CommandText = sql
                        r = command.ExecuteNonQuery()
                        DB_CLOSE()

                        If r <> 0 Then
                            MessageBox.Show("レコードを正常に削除", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        Me.BindGrid()
                    End If
                End If
                'ElseIf

            Else
                If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
                    Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

                    DB_OPEN()
                    Dim command As MySqlCommand = cnn.CreateCommand()
                    Dim Reader As MySqlDataReader
                    Dim query As String = "SELECT * from t20_contract_management where Control_number = @Mgt_number"
                    command.Parameters.AddWithValue("Mgt_number", row.Cells("管理番号").Value.ToString)
                    command.CommandText = query
                    Reader = command.ExecuteReader()
                    Dim dt = New DataTable()
                    dt.Load(Reader)

                    DB_CLOSE()
                    If dt.Rows.Count > 0 Then

                        If Not DBNull.Value.Equals(dt.Rows(0)("Control_number")) Then
                            Mgt_number = dt.Rows(0)("Control_number")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("India")) Then
                            ind = dt.Rows(0)("India")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Branch_number")) Then
                            Branch_number = dt.Rows(0)("Branch_number")
                        End If

                        If Not DBNull.Value.Equals(dt.Rows(0)("Old_number")) Then
                            Old_number = dt.Rows(0)("Old_number")
                        End If

                        If Not DBNull.Value.Equals(dt.Rows(0)("Contract_date")) Then

                            Contract_date = dt.Rows(0)("Contract_date")
                        End If

                        If Not DBNull.Value.Equals(dt.Rows(0)("Contract_period_starts")) Then

                            Contract_p_co = dt.Rows(0)("Contract_period_starts")
                        End If

                        If Not DBNull.Value.Equals(dt.Rows(0)("Scheduled_end_date_of_contract_period")) Then
                            Scheduled_Prd_end_Date = dt.Rows(0)("Scheduled_end_date_of_contract_period")

                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("End_date")) Then
                            End_date = dt.Rows(0)("End_date")
                        End If



                        If Not DBNull.Value.Equals(dt.Rows(0)("end")) Then
                            ends = dt.Rows(0)("end")
                        End If


                        If Not DBNull.Value.Equals(dt.Rows(0)("Update_code")) Then
                            Update_code = dt.Rows(0)("Update_code")
                        End If


                        If Not DBNull.Value.Equals(dt.Rows(0)("Automatic_update_interval")) Then
                            Auto_upd_intr = dt.Rows(0)("Automatic_update_interval")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Account_name_all")) Then
                            Customer_name = dt.Rows(0)("Account_name_all")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Contract_name")) Then
                            Contract_name = dt.Rows(0)("Contract_name")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Department_number")) Then
                            Mgt_dpt = dt.Rows(0)("Department_number")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Contractor")) Then
                            Contractor = dt.Rows(0)("Contractor")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("remarks")) Then
                            Remarks = dt.Rows(0)("remarks")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Temporary_company_number_1")) Then
                            Temporarycompanynumber1 = dt.Rows(0)("Temporary_company_number_1")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Temporary_company_number_2")) Then

                            Temporarycompanynumber2 = dt.Rows(0)("Temporary_company_number_2")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Temporary_company_number_3")) Then

                            Temporarycompanynumber3 = dt.Rows(0)("Temporary_company_number_3")

                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Temporary_company_number_4")) Then
                            Temporarycompanynumber4 = dt.Rows(0)("Temporary_company_number_4")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Temporary_company_number_5")) Then
                            Temporarycompanynumber5 = dt.Rows(0)("Temporary_company_number_5")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("Survey_date")) Then
                            Surveydate = dt.Rows(0)("Survey_date")
                        End If
                        If Not DBNull.Value.Equals(dt.Rows(0)("company_Number_all")) Then
                            companynumber_all = dt.Rows(0)("company_Number_all")
                        End If
                        bool = row.Cells("インド").Value.ToString
                    End If

                    'DtView1(i)("インド")

                    Me.Hide()
                    Dim F23_Form As New F21_契約書入力画面
                    F23_Form.ShowDialog()
                    Me.Show()
                    Me.BindGrid()
                    Cursor = System.Windows.Forms.Cursors.Default
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateTimePicker1_MouseUp(sender As Object, e As MouseEventArgs) Handles DateTimePicker1.MouseUp
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
    End Sub

    Sub BindGrid()

        Dim strChckbox As Boolean = False
        Dim str1 As String = Nothing
        Dim strdatetimepicker As String
        If DateTimePicker1.Text = " " Then
            strdatetimepicker = ""
        Else
            strdatetimepicker = Convert.ToDateTime(DateTimePicker1.Text).ToString("yyyy-MM-dd")
        End If
        Dim strCombo As String = ComboBox1.SelectedValue '更新コード
        'Dim strExtractCombo As String = strCombo.Substring(strCombo.IndexOf(":  "c) + 2)
        If ComboBox1.SelectedIndex <> -1 Then
            Dim strExtractCombo1 As String = strCombo.ToCharArray()
            str1 = ComboBox1.SelectedValue '更新コード
        End If

        'Dim charse() As Char
        If (CheckBox1.Checked = True) Then
            strChckbox = True
        Else
            strChckbox = False
        End If
        Dim strtxtbox2 As String = TextBox2.Text ' 備考(関連書面・特記事項等)
        Dim strtxtbox3 As String = TextBox3.Text '取引先名
        Dim strtxtbox4 As String = TextBox4.Text '契約書名
        Dim strtxtbox5 As String = TextBox5.Text
        Dim strtxtbox6 As String = TextBox6.Text '旧番号
        Dim strtxtbox7 As String = TextBox7.Text 'Column 管理番号
        Try
            ds.Clear()
            DB_OPEN()
            sql = "SELECT   t20_contract_management.ID as ID, t20_contract_management.Control_number as 管理番号, t20_contract_management.Temporary_number as 仮番号, t20_contract_management.India_contract as インド契約, t20_contract_management.Branch_number as 枝番, "
            sql += "t20_contract_management.Old_number as 旧番号, DATE_FORMAT(t20_contract_management.Contract_date, '%Y-%m-%d')  as 契約日, DATE_FORMAT(t20_contract_management.Contract_period_starts,  '%Y-%m-%d')   as 契約開始, DATE_FORMAT(t20_contract_management.Scheduled_end_date_of_contract_period, '%Y-%m-%d') as 契約終了予定日, DATE_FORMAT(t20_contract_management.End_date, '%Y-%m-%d') as 終了日, "
            sql += "t20_contract_management.Update_code as 更新コード, t20_contract_management.Automatic_update_interval as 自動更新間隔, t20_contract_management.Account_number_all  as 取引先番号_全, t20_contract_management.Account_name_all  as 取引先名, "
            sql += "t20_contract_management.Yomigana_All as ヨミガナ_全, t20_contract_management.Contract_name as 契約書名, t20_contract_management.Department_number as 部署番号, tm15_department_master.Management_department as 管理部署, t20_contract_management.Contractor as 契約担当, "
            sql += "t20_contract_management.remarks as 備考, t20_contract_management.end as 終了, t20_contract_management.India as インド, tm15_department_master.Delete as 削除, t20_contract_management.Delete as 削除_1 "
            'sql += "FROM tm15_department_master RIGHT JOIN (t20_contract_management LEFT JOIN tm19_update_code_master ON t20_contract_management.Update_code = tm19_update_code_master.Update_code) "
            'sql += "ON tm15_department_master.Department_number = t20_contract_management.Department_number "
            sql += " FROM t20_contract_management LEFT JOIN tm15_department_master ON  "
            sql += " t20_contract_management.Department_number = tm15_department_master.Department_number "
            'sql += "WHERE (((tm15_department_master.Delete) Is Null Or (tm15_department_master.Delete)=False) AND ((t20_contract_management.削除)=False)) "

            sql += "WHERE t20_contract_management.Delete= 0 "
            'sql += "WHERE t20_contract_management.契約期間終了予定日= '" & strdatetimepicker & "' "
            'End If
            If Not String.IsNullOrEmpty(strdatetimepicker) Then
                'sql += "t20_contract_management.インド= 0 "
                sql += "AND t20_contract_management.Scheduled_end_date_of_contract_period like '%" & strdatetimepicker & "%' "
                'sql += "AND t20_contract_management.Scheduled_end_date_of_contract_period= '" & strdatetimepicker & "' "
            End If
            If strChckbox Then
                'If Not String.IsNullOrEmpty(str1) Then
                sql += "AND t20_contract_management.Update_code IN ('0','1','2') "
                'End If
            Else
                If Not String.IsNullOrEmpty(str1) Then
                    sql += "AND t20_contract_management.Update_code = '" & str1 & "' "
                End If
            End If

            If Not String.IsNullOrEmpty(strtxtbox2) Then
                'sql += "AND t20_contract_management.備考 = '" & strtxtbox2 & "' "
                sql += "AND t20_contract_management.remarks LIKE N'" + strtxtbox2 + "%' "
            End If
            If Not String.IsNullOrEmpty(strtxtbox3) Then
                'sql += "AND t20_contract_management.取引先名_全 = '" & strtxtbox3 & "' "
                sql += "AND t20_contract_management.Account_name_all LIKE N'%" + strtxtbox3 + "%' "
            End If
            If Not String.IsNullOrEmpty(strtxtbox4) Then
                'sql += "AND t20_contract_management.契約書名 = '" & strtxtbox4 & "' "
                sql += "AND t20_contract_management.Contract_name LIKE N'" + strtxtbox4 + "%' "
            End If
            'doubt yomikada
            If Not String.IsNullOrEmpty(strtxtbox5) Then
                'sql += "AND t20_contract_management.契約書名 = '" & strtxtbox4 & "' "
                sql += "AND t20_contract_management.Contract_name LIKE N'" + strtxtbox5 + "%' "
            End If
            'If Not String.IsNullOrEmpty(strdatetimepicker) Then
            'sql += "AND '" & strtxtbox5 & "' "
            ' End If
            If Not String.IsNullOrEmpty(strtxtbox6) Then
                'sql += "AND t20_contract_management.旧番号='" & strtxtbox6 & "' "
                sql += "AND t20_contract_management.Old_number LIKE N'" + strtxtbox6 + "%' "
            End If
            If Not String.IsNullOrEmpty(strtxtbox7) Then
                'sql += "AND t20_contract_management.管理番号='" & strtxtbox7 & "' "
                sql += "AND t20_contract_management.Control_number LIKE N'" + strtxtbox7 + "%' "
            End If
            sql += "ORDER BY t20_contract_management.ID "
            'Dim command As MySqlCommand = cnn.CreateCommand()
            'Dim Reader As MySqlDataReader
            'command.CommandText = sql
            'Reader = command.ExecuteReader()
            'Dim dt = New DataTable()
            'dt.Load(Reader)
            'DB_CLOSE()
            'DataGridView1.DataSource = dt
            'Dim DtView1 As DataView
            Dim command As MySqlCommand = cnn.CreateCommand()
            command.CommandText = sql
            'command = cnn.CreateCommand()
            adapter.SelectCommand = command
            'DB_OPEN()
            adapter.Fill(ds, "T20_契約書管理")
            DB_CLOSE()
            Dim dt As New DataTable
            dt = ds.Tables("T20_契約書管理")
            'Dim Id As DataGridViewLinkColumn = New DataGridViewLinkColumn()
            'Id.UseColumnTextForLinkValue = True
            'Id.HeaderText = "編集"
            'Id.DataPropertyName = "取引先番号"
            'Id.LinkBehavior = LinkBehavior.SystemDefault
            DataGridView1.DataSource = dt

            DataGridView1.Columns("ID").Visible = False
            DataGridView1.Columns("仮番号").Visible = False
            DataGridView1.Columns("インド契約").Visible = False
            DataGridView1.Columns("インド").Visible = False
            DataGridView1.Columns("終了").Visible = False
            DataGridView1.Columns("削除").Visible = False
            ' DataGridView1.Columns("契約期間開始").Visible = False '契約開始
            'DataGridView1.Columns("契約期間終了予定日").Visible = False '契約終了予定日
            DataGridView1.Columns("取引先番号_全").Visible = False
            DataGridView1.Columns("ヨミガナ_全").Visible = False
            'DataGridView1.Columns("部署番号").Visible = False 管理部署
            'DataGridView1.Columns("契約担当").Visible = False
            DataGridView1.Columns("枝番").Visible = False
            DataGridView1.Columns("インド").Visible = False
            DataGridView1.Columns("削除_1").Visible = False

            If (dt.Rows.Count > 0) Then
                TextBox8.Text = dt.Rows.Count
            Else
                TextBox8.Text = "0"
            End If

            DataGridView1.Columns.Item("管理番号").Width = 60
            DataGridView1.Columns.Item("旧番号").Width = 60
            DataGridView1.Columns.Item("契約開始").Width = 100
            DataGridView1.Columns.Item("契約日").Width = 100
            DataGridView1.Columns.Item("契約終了予定日").Width = 100
            DataGridView1.Columns.Item("終了日").Width = 100
            DataGridView1.Columns.Item("更新コード").Width = 60
            DataGridView1.Columns.Item("自動更新間隔").Width = 60
            DataGridView1.Columns.Item("取引先名").Width = 100
            DataGridView1.Columns.Item("契約書名").Width = 60
            DataGridView1.Columns.Item("管理部署").Width = 60
            DataGridView1.Columns.Item("備考").Width = 60
            DataGridView1.Columns.Item("部署番号").Width = 60


            If boolbtn = True Then
                boolbtn = False
                Dim buttonColumn As DataGridViewButtonColumn = New DataGridViewButtonColumn()
                buttonColumn.HeaderText = ""
                buttonColumn.Width = 60
                buttonColumn.Name = "Edit"
                buttonColumn.CellTemplate.Style.BackColor = Color.Green
                buttonColumn.Text = "編集"
                buttonColumn.UseColumnTextForButtonValue = True

                Dim buttonColumn1 As DataGridViewButtonColumn = New DataGridViewButtonColumn()
                buttonColumn1.HeaderText = ""
                buttonColumn1.Width = 60
                buttonColumn.CellTemplate.Style.ForeColor = Color.Red
                buttonColumn1.Name = "Delete"
                buttonColumn1.Text = "消去"
                buttonColumn1.UseColumnTextForButtonValue = True
                DataGridView1.Columns.Add(buttonColumn)
                DataGridView1.Columns.Add(buttonColumn1)

            End If
            'DataGridView1.Columns(0).Width = 50
            'DataGridView1.Columns(1).Width = 50
            'DataGridView1.Columns(2).Width = 50
            'DataGridView1.Columns(3).Width = 50



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If e.RowIndex <> -1 Then
                If DataGridView1.RowCount > rowcolor Then
                    DataGridView1.Rows(rowcolor).DefaultCellStyle.BackColor = Color.White
                End If

                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                rowcolor = e.RowIndex
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles Button3.ContextMenuStripChanged

    End Sub
    'Private Sub DataGridView1_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    'End Sub
End Class