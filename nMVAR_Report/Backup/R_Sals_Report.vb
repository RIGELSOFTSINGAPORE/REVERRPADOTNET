Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sals_Report
    Inherits ActiveReport

    Dim date1, date2, date3 As Date
    Dim int1, int2, int3 As Integer
    Dim WK_sum1, WK_sum2, WK_sum3, WK_sum4, WK_sum5 As Decimal
    Dim WK_sumG1, WK_sumG2, WK_sumG3, WK_sumG4, WK_sumG5 As Decimal

    Public Sub New()
        MyBase.New()

        InitializeReport()

        date1 = CDate(P_PRAM1 & "/01")                                                  'äJén
        If ini = "nMVAR" Then
            date2 = Now.Date                                                            'åªç›
        Else
            date2 = DateAdd(DateInterval.Day, -1, Now.Date)                             'ëOì˙
        End If
        date3 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, date1))    'èIóπ

        int1 = Microsoft.VisualBasic.Day(date2) 'åªç›ÇÃì˙
        int2 = Microsoft.VisualBasic.Day(date3) 'ëŒè€åéÇÃì˙êî
        If date2 >= date3 Then
            int3 = int2                         'Actì˙êî
        Else
            If date1 > date2 Then
                int3 = 0                        'Actì˙êî
            Else
                int3 = int1                     'Actì˙êî
            End If
        End If

        TextBox01.Text = Format(date1, "MMåéddì˙")
        TextBox02.Text = Format(date2, "MMåéddì˙")
        If date2 >= date3 Then
            TextBox03.Text = "100%"
        Else
            TextBox03.Text = Round((int1 - 1) / int2 * 100, 1) & "%"
        End If
        TextBox04.Text = Format(date3, "MMåéddì˙")
        TextBox05.Text = Format(date1, "yyyyîNMMåé")

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As DataDynamics.ActiveReports.ReportHeader = Nothing
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
    Private WithEvents ReportFooter As DataDynamics.ActiveReports.ReportFooter = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox05 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox01 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox03 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox04 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox53 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox56 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox54 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox52 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox37 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox57 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR_Report.R_Sals_Report.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.GroupHeader1 = CType(Me.Sections("GroupHeader1"),DataDynamics.ActiveReports.GroupHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.GroupFooter1 = CType(Me.Sections("GroupFooter1"),DataDynamics.ActiveReports.GroupFooter)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.Label = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox05 = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label2 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.TextBox01 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox02 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox03 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox04 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.GroupFooter1.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.GroupFooter1.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.GroupFooter1.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.GroupFooter1.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.GroupFooter1.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.GroupFooter1.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.GroupFooter1.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox32 = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.ReportFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox34 = CType(Me.ReportFooter.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.ReportFooter.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.ReportFooter.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.ReportFooter.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox53 = CType(Me.ReportFooter.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox55 = CType(Me.ReportFooter.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox56 = CType(Me.ReportFooter.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox43 = CType(Me.ReportFooter.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.ReportFooter.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox46 = CType(Me.ReportFooter.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox44 = CType(Me.ReportFooter.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox54 = CType(Me.ReportFooter.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox52 = CType(Me.ReportFooter.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.ReportFooter.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.ReportFooter.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.ReportFooter.Controls(18),DataDynamics.ActiveReports.Label)
		Me.TextBox37 = CType(Me.ReportFooter.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.TextBox57 = CType(Me.ReportFooter.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.TextBox47 = CType(Me.ReportFooter.Controls(21),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        WK_sum1 = WK_sum1 + TextBox12.Text
        WK_sum2 = WK_sum2 + TextBox13.Text
        WK_sum3 = WK_sum3 + TextBox15.Text
        WK_sum4 = WK_sum4 + TextBox16.Text
        WK_sum5 = WK_sum5 + TextBox17.Text
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        TextBox22.Text = Format(WK_sum1, "##,##0")
        TextBox23.Text = Format(WK_sum2, "##,##0")
        If WK_sum1 = 0 Then
            TextBox24.Text = "0%"
        Else
            TextBox24.Text = Format(Round(WK_sum2 / WK_sum1 * 100, 1), "##,##0.0") & "%"
        End If
        TextBox25.Text = Format(WK_sum3, "##,##0")
        TextBox26.Text = Format(WK_sum4, "##,##0")
        TextBox27.Text = Format(WK_sum5, "##,##0")

        WK_sumG1 = WK_sumG1 + WK_sum1
        WK_sumG2 = WK_sumG2 + WK_sum2
        WK_sumG3 = WK_sumG3 + WK_sum3
        WK_sumG4 = WK_sumG4 + WK_sum4
        WK_sumG5 = WK_sumG5 + WK_sum5

        WK_sum1 = 0 : WK_sum2 = 0 : WK_sum3 = 0 : WK_sum4 = 0 : WK_sum5 = 0
    End Sub

    Private Sub ReportFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter.Format
        TextBox31.Text = "ÇpÇfÇrÇrçáåv"
        TextBox32.Text = Format(WK_sumG1, "##,##0")
        TextBox33.Text = Format(WK_sumG2, "##,##0")
        If WK_sumG1 = 0 Then
            TextBox34.Text = "0%"
        Else
            TextBox34.Text = Format(Round(WK_sumG2 / WK_sumG1 * 100, 1), "##,##0.0") & "%"
        End If
        TextBox35.Text = Format(WK_sumG3, "##,##0")
        TextBox36.Text = Format(WK_sumG4, "##,##0")
        TextBox37.Text = Format(WK_sumG5, "##,##0")

        TextBox41.Text = "Act " & int3 & "ì˙"

        If int3 = 0 Then
            TextBox42.Text = ""
            TextBox43.Text = "0"
            TextBox44.Text = ""
            TextBox45.Text = "0"
            TextBox46.Text = "0"
            TextBox47.Text = ""
        Else
            TextBox42.Text = ""
            TextBox43.Text = Format(Round(WK_sumG2 / int3, 0), "##,##0")
            TextBox44.Text = ""
            TextBox45.Text = Format(Round(WK_sumG3 / int3, 1), "##,##0.0")
            TextBox46.Text = Format(Round(WK_sumG4 / int3, 1), "##,##0.0")
            TextBox47.Text = ""
        End If

        TextBox52.Text = ""
        TextBox53.Text = Format(CDec(TextBox43.Text) * int2, "##,##0")
        TextBox54.Text = ""
        TextBox55.Text = Format(CInt(TextBox45.Text) * int2, "##,##0")
        TextBox56.Text = Format(CInt(TextBox46.Text) * int2, "##,##0")
        TextBox57.Text = ""
    End Sub
End Class
