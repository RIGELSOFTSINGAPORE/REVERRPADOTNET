Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_member_list_iPad
Inherits ActiveReport

    Dim WK_int1, WK_int2, WK_int3 As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        date_now.Text = Now.Date

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader = Nothing
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter = Nothing
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private date_now As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Line22 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line20 As DataDynamics.ActiveReports.Line = Nothing
	Private Line21 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private GF2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private GF1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nQGCare.R_member_list_iPad.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.GroupHeader1 = CType(Me.Sections("GroupHeader1"),DataDynamics.ActiveReports.GroupHeader)
		Me.GroupHeader2 = CType(Me.Sections("GroupHeader2"),DataDynamics.ActiveReports.GroupHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.GroupFooter2 = CType(Me.Sections("GroupFooter2"),DataDynamics.ActiveReports.GroupFooter)
		Me.GroupFooter1 = CType(Me.Sections("GroupFooter1"),DataDynamics.ActiveReports.GroupFooter)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.date_now = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Line = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Line)
		Me.Label2 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.PageHeader.Controls(17),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.PageHeader.Controls(18),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.PageHeader.Controls(19),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.PageHeader.Controls(20),DataDynamics.ActiveReports.Line)
		Me.TextBox17 = CType(Me.GroupHeader1.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.Line12 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Line)
		Me.Line20 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Line)
		Me.Line21 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Line)
		Me.TextBox10 = CType(Me.GroupFooter2.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.GroupFooter2.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.GF2 = CType(Me.GroupFooter2.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.GroupFooter2.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.GroupFooter1.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.GroupFooter1.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.GroupFooter1.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.GF1 = CType(Me.GroupFooter1.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        WK_int1 = TextBox12.Text
        WK_int2 = TextBox14.Text
        WK_int3 = RoundDOWN(WK_int2 / WK_int1, 0)
        GF2.Text = TextBox10.Text & "( " & Format(WK_int1, "##,##0") & "åèÅAÅ@ï€èÿóøíPâø:" & Format(WK_int3, "##,##0") & "â~ÅAÅ@ï€èÿã‡äz:" & Format(WK_int2, "##,##0") & "â~)"
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        WK_int1 = TextBox15.Text
        WK_int2 = TextBox16.Text
        WK_int3 = RoundDOWN(WK_int2 / WK_int1, 0)
        GF1.Text = "ìXï‹åv" & "( " & Format(WK_int1, "##,##0") & "åèÅAÅ@ï€èÿóøíPâø:" & Format(WK_int3, "##,##0") & "â~ÅAÅ@ï€èÿã‡äz:" & Format(WK_int2, "##,##0") & "â~)"
    End Sub

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format
        TextBox2.Text = TextBox17.Text
    End Sub
End Class
