Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class R30_調査用
    Private CS As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
    Private query As String = ""
    Private Sub R30_調査用_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dsExp_Not4 As xsdR30_調査用 = GetData_R30_4(調査用.SurveyFromDate, 調査用.SurveyToDate)
        Dim datasource As New ReportDataSource("DataSet1", dsExp_Not4.Tables(0))
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(datasource)


        ReportViewer1.LocalReport.DisplayName = "R30_調査用"
        'AddHandler Me.ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler1
        Me.ReportViewer1.LocalReport.Refresh()

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Function GetData_R30_4(surStdate As String, surEddate As String) As xsdR30_調査用
        'Dim constr As String = "Data Source=DESKTOP-9I48ETB\SQLEXPRESS;Initial Catalog=MujiStore;Integrated Security=True;Connection Timeout=60;Pooling=True;Min Pool Size=1;Max Pool Size=5"
        Using con As New MySqlConnection(CS)
            Using cmd As New MySqlCommand()
                Using sda As New MySqlDataAdapter("Q30_Survey_Date_Report", con)

                    sda.SelectCommand.Parameters.AddWithValue("@surStdate", surStdate)
                    sda.SelectCommand.Parameters.AddWithValue("@surEddate", surEddate)
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure

                    'sda.SelectCommand = cmd
                    Using dsR30_4 As New xsdR30_調査用()
                        sda.Fill(dsR30_4, "dtR30_4")
                        Return dsR30_4
                    End Using
                End Using
            End Using
        End Using
    End Function


End Class