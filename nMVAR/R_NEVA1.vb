Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_NEVA
    Inherits ActiveReport
    Public Sub New()
        MyBase.New()
        InitializeReport()

        'èoâ◊ì˙
        TextBox01.Text = Format(Now(), "yy")
        TextBox02.Text = Format(Now(), "MM")
        TextBox03.Text = Format(Now(), "dd")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
	Private Expr13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox01 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox03 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr07 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr08 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label01 As DataDynamics.ActiveReports.Label = Nothing
	Private Expr14_2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label02 As DataDynamics.ActiveReports.Label = Nothing
	Private Expr14_3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr03 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr01 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr05 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr09 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr04 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Expr06 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_NEVA.rpx")
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.Expr13 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Expr14 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox01 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox02 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox03 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.Expr07 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.Expr10 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.Expr08 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.Label01 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Expr14_2 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.Label02 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Expr14_3 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.Expr19 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.Expr17 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.Expr03 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.Expr11 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.Expr01 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.Expr05 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.Expr09 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.Expr04 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.Expr02 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.Expr12 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.Expr15 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.Expr16 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.Expr18 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.Expr06 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region
End Class
