Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_NEVA_DEODEO
    Inherits ActiveReport
    Public Sub New()
        MyBase.New()
        InitializeReport()

        '�o�ד�
        TextBox.Text = Format(Now(), "yy")
        TextBox2.Text = Format(Now(), "MM")
        TextBox4.Text = Format(Now(), "dd")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
	Private TextBox5_1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9_1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13_1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox52 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_NEVA_DEODEO.rpx")
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.TextBox5_1 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9_1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13_1 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox52 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Label)
		Me.TextBox10 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.Label8 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
	End Sub

#End Region
End Class
