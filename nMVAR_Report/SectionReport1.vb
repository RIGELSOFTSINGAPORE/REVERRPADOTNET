Imports System
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport1
    Inherits SectionReport
    Dim Page As Integer

    Public Sub New()

        InitializeComponent()
        TextBox17.Text = P_PRAM1
        TextBox18.Text = Now
        TextBox21.Text = Format(Now, "yyyy”NMMŒŽdd“ú")
    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

        Page = Page + 1
        TextBox19.Text = Page & " / "

    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        TextBox22.Text = "\" & Format(CInt(TextBox22.Text), "##,##0")
        TextBox23.Text = "\" & Format(CInt(TextBox23.Text), "##,##0")
        TextBox24.Text = "\" & Format(CInt(TextBox24.Text), "##,##0")
        TextBox25.Text = "\" & Format(CInt(TextBox25.Text), "##,##0")
        TextBox26.Text = "\" & Format(CInt(TextBox26.Text), "##,##0")
        TextBox27.Text = "\" & Format(CInt(TextBox27.Text), "##,##0")
        TextBox28.Text = "\" & Format(CInt(TextBox28.Text), "##,##0")
        TextBox29.Text = "\" & Format(CInt(TextBox29.Text), "##,##0")
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format


        TextBox30.Text = CInt(TextBox30.Text) + CInt(TextBox9.Text)
        TextBox22.Text = CInt(TextBox22.Text) + CInt(TextBox1.Text)
        TextBox31.Text = CInt(TextBox31.Text) + CInt(TextBox10.Text)
        TextBox23.Text = CInt(TextBox23.Text) + CInt(TextBox2.Text)
        TextBox32.Text = CInt(TextBox32.Text) + CInt(TextBox11.Text)
        TextBox24.Text = CInt(TextBox24.Text) + CInt(TextBox3.Text)
        TextBox33.Text = CInt(TextBox33.Text) + CInt(TextBox12.Text)
        TextBox25.Text = CInt(TextBox25.Text) + CInt(TextBox4.Text)
        TextBox34.Text = CInt(TextBox34.Text) + CInt(TextBox13.Text)
        TextBox26.Text = CInt(TextBox26.Text) + CInt(TextBox5.Text)
        TextBox35.Text = CInt(TextBox35.Text) + CInt(TextBox14.Text)
        TextBox27.Text = CInt(TextBox27.Text) + CInt(TextBox6.Text)
        TextBox36.Text = CInt(TextBox36.Text) + CInt(TextBox15.Text)
        TextBox28.Text = CInt(TextBox28.Text) + CInt(TextBox7.Text)
        TextBox37.Text = CInt(TextBox37.Text) + CInt(TextBox16.Text)
        TextBox29.Text = CInt(TextBox29.Text) + CInt(TextBox8.Text)

    End Sub
End Class
