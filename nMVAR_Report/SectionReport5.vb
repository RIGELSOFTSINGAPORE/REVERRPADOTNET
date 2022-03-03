Imports System
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document


Public Class SectionReport5
    Inherits SectionReport
    Dim date1, date2, date3 As Date
    Dim int1, int2, int3 As Integer
    Dim WK_sum1, WK_sum2, WK_sum3, WK_sum4, WK_sum5 As Decimal
    Dim WK_sumG1, WK_sumG2, WK_sumG3, WK_sumG4, WK_sumG5 As Decimal

    Public Sub New()


        InitializeComponent()

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

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        WK_sum1 = WK_sum1 + TextBox12.Text
        WK_sum2 = WK_sum2 + TextBox13.Text
        WK_sum3 = WK_sum3 + TextBox15.Text
        WK_sum4 = WK_sum4 + TextBox16.Text
        WK_sum5 = WK_sum5 + TextBox17.Text
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
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

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
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
