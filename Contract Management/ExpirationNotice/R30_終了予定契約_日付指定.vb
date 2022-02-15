Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class R30_終了予定契約_日付指定
    Private CS As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
    Private query As String = ""
    Private Sub R30_終了予定契約_日付指定_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show(F30_満了レポート.SetValueForText1)
        Dim dsExp_Not3 As xsdR30_終了予定契約_日付指定 = GetData_R30_3(F30_満了レポート.SetValueForText1)
        Dim datasource As New ReportDataSource("DataSet1", dsExp_Not3.Tables(0))
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(datasource)


        ReportViewer1.LocalReport.DisplayName = "R30_終了予定契約_日付指定"
        'AddHandler Me.ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler1
        Me.ReportViewer1.LocalReport.Refresh()

        Me.ReportViewer1.RefreshReport()

    End Sub
    Private Function GetData_R30_3(repdate As String) As xsdR30_終了予定契約_日付指定
        'Dim constr As String = "Data Source=DESKTOP-9I48ETB\SQLEXPRESS;Initial Catalog=MujiStore;Integrated Security=True;Connection Timeout=60;Pooling=True;Min Pool Size=1;Max Pool Size=5"
        Using con As New MySqlConnection(CS)
            Using cmd As New MySqlCommand()
                Using sda As New MySqlDataAdapter("Q30_Scheduled_termination_contract_date_specification", con)

                    sda.SelectCommand.Parameters.AddWithValue("@expdate", repdate)

                    sda.SelectCommand.CommandType = CommandType.StoredProcedure

                    'sda.SelectCommand = cmd
                    Using dsR30_3 As New xsdR30_終了予定契約_日付指定()
                        sda.Fill(dsR30_3, "dtR30_3")
                        Return dsR30_3
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class