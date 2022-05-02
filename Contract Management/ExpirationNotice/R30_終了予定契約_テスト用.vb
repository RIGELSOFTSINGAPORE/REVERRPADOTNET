Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class R30_終了予定契約_テスト用
    Private CS As String = ConfigurationManager.ConnectionStrings("cnstr").ConnectionString
    Private query As String = ""
    Private Sub R30_終了予定契約_テスト用_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dsExp_Not2 As xsdR30_終了予定契約_テスト用 = GetData_R30_2()
        Dim datasource As New ReportDataSource("xsdR30_終了予定契約_テスト用", dsExp_Not2.Tables(0))
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(datasource)


        ReportViewer1.LocalReport.DisplayName = "R30_終了予定契約_テスト用"
        'AddHandler Me.ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler1
        Me.ReportViewer1.LocalReport.Refresh()

        Me.ReportViewer1.RefreshReport()


    End Sub
    Private Function GetData_R30_2() As xsdR30_終了予定契約_テスト用
        'Dim constr As String = "Data Source=DESKTOP-9I48ETB\SQLEXPRESS;Initial Catalog=MujiStore;Integrated Security=True;Connection Timeout=60;Pooling=True;Min Pool Size=1;Max Pool Size=5"
        Using con As New MySqlConnection(CS)
            Using cmd As New MySqlCommand()
                Using sda As New MySqlDataAdapter("Q30_ExpectedTerminationContract_ForTesting", con)
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure

                    'sda.SelectCommand = cmd
                    Using dsR30_2 As New xsdR30_終了予定契約_テスト用()
                        sda.Fill(dsR30_2, "dtR30_2")
                        Return dsR30_2
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class