Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_Invc_Dtl_Kojima_SectionReport
	Inherits SectionReport
	Public Sub New()
		MyBase.New()
		InitializeComponent()

	End Sub
	Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

	End Sub

	Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

	Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
		TextBox.Text = CInt(TextBox.Text) + 1

		TextBox3.Text = DateDiff(DateInterval.Day, CDate(TextBox1D.Text), CDate(TextBox2D.Text))

		TextBox11.Text = Format(CInt(TextBox9.Text) + CInt(TextBox10.Text), "#,##0")

		TextBox12.Text = Format(CInt(TextBox12.Text) + CInt(TextBox9.Text), "#,##0")
		TextBox13.Text = Format(CInt(TextBox13.Text) - 1000, "#,##0")
		TextBox14.Text = Format(CInt(TextBox14.Text) + CInt(TextBox11.Text), "#,##0")
	End Sub
End Class
