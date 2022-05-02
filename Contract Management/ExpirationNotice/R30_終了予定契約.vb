Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient
Public Class R30_終了予定契約
    Private CS As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
    Private query As String = ""
    Private Sub R30_終了予定契約_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Dim myCountryList As New ArrayList() { New { Id = 1, Name = "India" }, New { Id = 2, Name = "Canada" }, New { Id = 2, Name = "USA" }, New { Id = 2, Name = "Singapore" } }.ToList()


        'Dim dict As New Dictionary(Of String, String)
        'dict.Add()


        ReportViewer1.LocalReport.EnableHyperlinks = True
        Dim dsExpNotRep1 As xsd_R30_終了予定契約 = GetData_R30_1()
        Dim datasource As New ReportDataSource("xsd_R30_終了予定契約", dsExpNotRep1.Tables(0))
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(datasource)


        ReportViewer1.LocalReport.DisplayName = "満了のお知らせ"
        'AddHandler Me.ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler1
        Me.ReportViewer1.LocalReport.Refresh()

        Me.ReportViewer1.RefreshReport()
        'Using sqlCon As MySqlConnection = New MySqlConnection(CS)
        '    sqlCon.Open()
        '    Dim Cmnd As MySqlCommand = New MySqlCommand()


        '    'Dim reader As MySqlDataReader
        '    'reader = Cmnd.ExecuteReader()
        '    ''While reader.Read()
        '    ''    MsgBox(reader.Item(0))
        '    ''End While
        '    'reader.Close()
        '    'Using r30_1datadt As New MySqlDataAdapter()
        '    '    Cmnd.Connection = sqlCon
        '    '    Cmnd.CommandText = "Q30_終了予定契約"
        '    '    Cmnd.CommandType = CommandType.StoredProcedure
        '    '    Using dsCustomers As New R30_終了予定契約()
        '    '        r30_1datadt.Fill(dsCustomers, "DataTable1")
        '    '        Return dsCustomers
        '    '    End Using
        '    'End Using
        '    'Dim result As Integer = Cmnd.ExecuteNonQuery()
        '    sqlCon.Close()
        'End Using

    End Sub


    Private Function GetData_R30_1() As xsd_R30_終了予定契約
        'Dim constr As String = "Data Source=DESKTOP-9I48ETB\SQLEXPRESS;Initial Catalog=MujiStore;Integrated Security=True;Connection Timeout=60;Pooling=True;Min Pool Size=1;Max Pool Size=5"
        Using con As New MySqlConnection(CS)
            Using cmd As New MySqlCommand()
                Using sda As New MySqlDataAdapter("Q30_Contracttobeterminated", con)
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure

                    'sda.SelectCommand = cmd
                    Using dsR30_1 As New xsd_R30_終了予定契約()
                        sda.Fill(dsR30_1, "dtR30_1終了予定契約")
                        Return dsR30_1
                    End Using
                End Using
            End Using
        End Using
    End Function


    Private Sub SubreportProcessing(sender As Object, e As SubreportProcessingEventArgs)
        Dim stateid As Integer = Integer.Parse(e.Parameters("ID").Values(0).ToString())
        Dim dt As DataTable = New System.Data.DataTable()
        Dim adp As New MySqlDataAdapter("GetDistrictPopulation", CS)
        adp.SelectCommand.CommandType = CommandType.StoredProcedure
        adp.SelectCommand.Parameters.AddWithValue("@stateid", stateid)
        adp.Fill(dt)
        Dim dts As New ReportDataSource("DataSet1", dt)
        e.DataSources.Add(dts)
    End Sub
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        'Try
        '    e.DataSources.Add(GetSubreportDataSource)
        'Catch ex As Exception
        '    ' MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Public Sub SubreportProcessingEventHandler1(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        'Try
        '    e.DataSources.Add(GetSubreportDataSource)
        'Catch ex As Exception
        '    ' MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub ReportViewer1_Drillthrough(sender As Object, e As DrillthroughEventArgs) Handles ReportViewer1.Drillthrough

        'LocalReport LocalReport = (LocalReport)e.Report;
        Dim localreport As LocalReport
        localreport = e.Report

        'Dim ID As ReportParameter
        'ID = New ReportParameter("ID", 1479)
        'ReportViewer1.LocalReport.SetParameters(ID)
        'ReportViewer1.LocalReport.Refresh()

        'Dim DrillThroughValues As ReportParameterInfoCollection = e.Report.GetParameters()
        'Dim repID As String
        'Dim paramStoreNo As New ReportParameter("ID", 1479)
        'Dim repparam() As ReportParameter


        'repID = New System.Linq.SystemCore_EnumerableDebugView((New System.Collections.Generic.Mscorlib_CollectionDebugView(Of Microsoft.Reporting.WinForms.ReportParameter)(DirectCast(e.Report, Microsoft.Reporting.WinForms.LocalReport).OriginalParametersToDrillthrough).Items(0)).Values).Items(0)

        'Dim localreport = ReportViewer1.LocalReport
        ''Me.Sp_get_testaccountsTableAdapter1.Fill(Me.Retreival.sp_get_testaccounts)

        ''Dim od As New RetreivalTableAdapters.sp_get_testaccountsTableAdapter

        ''Dim myReportDataSource = New ReportDataSource("Retreival", Me.Retreival.sp_get_testaccounts.DataSet.Tables(0))
        ''localreport.DataSources.Add(myReportDataSource)
        'Dim dsCustomers As xsd_R30_終了予定契約 = GetData_R30_1()
        'Dim datasource As New ReportDataSource("xsd_R30_終了予定契約", dsCustomers.Tables(0))
        'Me.ReportViewer1.LocalReport.DataSources.Clear()
        'Me.ReportViewer1.LocalReport.DataSources.Add(datasource)



        '' AddHandler Me.ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler1
        'Me.ReportViewer1.LocalReport.Refresh()

        'Me.ReportViewer1.RefreshReport()
    End Sub
End Class