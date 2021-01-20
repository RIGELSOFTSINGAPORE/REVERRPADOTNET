Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports GrapeCity.ActiveReports


Public Class ActiveReport1
	Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		'InitializeReport()
		TextBox.Text = Format(Now(), "yyyy”NMMŒŽdd“ú")

	End Sub
#Region "ActiveReports Designer generated code"
	Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
	Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "best_ivc_err_mnt.ActiveReport1.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Line)
		Me.Label1 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Line)
		Me.TextBox1 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label30 = CType(Me.PageFooter.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Line2 = CType(Me.PageFooter.Controls(3),DataDynamics.ActiveReports.Line)
	End Sub

	#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Trim(TextBox8.Text) = Nothing Then
            TextBox6.Text = Nothing
        Else
            TextBox6.Text = Format(CDate(Mid(TextBox8.Text, 1, 4) & "/" & Mid(TextBox8.Text, 5, 2) & "/" & Mid(TextBox8.Text, 7, 2)), "yyyy.MM.dd")
        End If
    End Sub
End Class
