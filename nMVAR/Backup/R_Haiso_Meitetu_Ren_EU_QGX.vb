Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Haiso_Meitetu_Ren_EU_QGX
    Inherits ActiveReport
    Public Sub New()
        MyBase.New()
        InitializeReport()

        TextBox01.Text = Format(Now(), "yy")
        TextBox02.Text = Format(Now(), "MM")
        TextBox03.Text = Format(Now(), "dd")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
	Private TextBox01 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox03 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Haiso_Meitetu_Ren_EU_QGX.rpx")
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.TextBox01 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox02 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox03 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
	End Sub

#End Region
End Class
