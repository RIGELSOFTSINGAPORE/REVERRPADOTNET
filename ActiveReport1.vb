Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ActiveReport1
    Inherits ActiveReport

    Dim WK_DtView1 As DataView
    Dim i As Integer
    Dim WK_sum1, WK_sum2 As Decimal

    Public Sub New()
        MyBase.New()
		'InitializeReport()
		'hed02.Text = Format(Now(), "yyyy”NMMŒŽdd“ú")

	End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As DataDynamics.ActiveReports.ReportHeader = Nothing
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader = Nothing
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader = Nothing
    Private WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter = Nothing
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter = Nothing
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
    Private WithEvents ReportFooter As DataDynamics.ActiveReports.ReportFooter = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private hed01 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox38 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox39 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox40 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private hed02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox37 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "best_ivc_report.ActiveReport1.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.GroupHeader1 = CType(Me.Sections("GroupHeader1"),DataDynamics.ActiveReports.GroupHeader)
		Me.GroupHeader2 = CType(Me.Sections("GroupHeader2"),DataDynamics.ActiveReports.GroupHeader)
		Me.GroupHeader3 = CType(Me.Sections("GroupHeader3"),DataDynamics.ActiveReports.GroupHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.GroupFooter3 = CType(Me.Sections("GroupFooter3"),DataDynamics.ActiveReports.GroupFooter)
		Me.GroupFooter2 = CType(Me.Sections("GroupFooter2"),DataDynamics.ActiveReports.GroupFooter)
		Me.GroupFooter1 = CType(Me.Sections("GroupFooter1"),DataDynamics.ActiveReports.GroupFooter)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.TextBox47 = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.TextBox21 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.TextBox20 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.hed01 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.PageHeader.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageHeader.Controls(19),DataDynamics.ActiveReports.Line)
		Me.Label12 = CType(Me.PageHeader.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.PageHeader.Controls(21),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.PageHeader.Controls(22),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.PageHeader.Controls(23),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.PageHeader.Controls(24),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.PageHeader.Controls(25),DataDynamics.ActiveReports.Label)
		Me.TextBox19 = CType(Me.PageHeader.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.PageHeader.Controls(27),DataDynamics.ActiveReports.Line)
		Me.Label31 = CType(Me.PageHeader.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label32 = CType(Me.PageHeader.Controls(29),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.PageHeader.Controls(30),DataDynamics.ActiveReports.Label)
		Me.TextBox43 = CType(Me.PageHeader.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.TextBox44 = CType(Me.PageHeader.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.PageHeader.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.Label34 = CType(Me.PageHeader.Controls(34),DataDynamics.ActiveReports.Label)
		Me.TextBox46 = CType(Me.GroupHeader1.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.GroupHeader2.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.GroupHeader2.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.GroupHeader2.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox48 = CType(Me.GroupHeader2.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.TextBox38 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.Label28 = CType(Me.GroupFooter3.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox26 = CType(Me.GroupFooter3.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.GroupFooter3.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox30 = CType(Me.GroupFooter3.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label20 = CType(Me.GroupFooter3.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.GroupFooter3.Controls(5),DataDynamics.ActiveReports.Label)
		Me.TextBox39 = CType(Me.GroupFooter3.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.GroupFooter3.Controls(7),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.GroupFooter3.Controls(8),DataDynamics.ActiveReports.Line)
		Me.TextBox28 = CType(Me.GroupFooter2.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox29 = CType(Me.GroupFooter2.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.GroupFooter2.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Label21 = CType(Me.GroupFooter2.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label25 = CType(Me.GroupFooter2.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.GroupFooter2.Controls(5),DataDynamics.ActiveReports.Label)
		Me.TextBox40 = CType(Me.GroupFooter2.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.Line4 = CType(Me.GroupFooter2.Controls(7),DataDynamics.ActiveReports.Line)
		Me.Label22 = CType(Me.GroupFooter1.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox32 = CType(Me.GroupFooter1.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.GroupFooter1.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox34 = CType(Me.GroupFooter1.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label24 = CType(Me.GroupFooter1.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Line5 = CType(Me.GroupFooter1.Controls(5),DataDynamics.ActiveReports.Line)
		Me.hed02 = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Line6 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.Line)
		Me.TextBox41 = CType(Me.PageFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.PageFooter.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label30 = CType(Me.PageFooter.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox35 = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.ReportFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox37 = CType(Me.ReportFooter.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label27 = CType(Me.ReportFooter.Controls(4),DataDynamics.ActiveReports.Label)
	End Sub

#End Region

    Private Sub GroupHeader2_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.AfterPrint
        TextBox20.Text = TextBox23.Text
        TextBox21.Text = TextBox24.Text
        TextBox22.Text = TextBox25.Text
        TextBox47.Text = TextBox48.Text
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        If TextBox13.Text = "True" Then TextBox38.Text = "S" Else TextBox38.Text = Nothing
    End Sub

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format
        WK_DtView1 = New DataView(P_DsPrint.Tables("Wrn_ivc"), "kbn_No1='" & TextBox46.Text & "'", "", DataViewRowState.CurrentRows)

        TextBox43.Text = WK_DtView1.Count
        WK_sum1 = 0
        WK_sum2 = 0

        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_sum1 = WK_sum1 + WK_DtView1(i)("¿‹Šz")
                WK_sum2 = WK_sum2 + WK_DtView1(i)("TAX")
            Next
        End If
        TextBox44.Text = "\" & Format(WK_sum1, "#,##0")
        TextBox45.Text = "\" & Format(WK_sum2, "#,##0")
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.BeforePrint
        If CInt(TextBox41.Text) > CInt(TextBox42.Text) Then
            TextBox41.Text = TextBox42.Text
        End If
    End Sub

    Private Sub ActiveReport1_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DataInitialize
		Me.Fields.Add("kbn_No1")
	End Sub

    Private Sub GroupHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.BeforePrint
        GroupHeader1.AddBookmark(Me.Fields("kbn_No1").Value.ToString())
    End Sub

    Private Sub GroupHeader2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.BeforePrint
        GroupHeader2.AddBookmark(Me.Fields("kbn_No1").Value.ToString() + "\" + Me.Fields("kbn_No").Value.ToString())
    End Sub

	Private Sub ActiveReport1_ReportStart(sender As Object, e As EventArgs) Handles Me.ReportStart

	End Sub
End Class
