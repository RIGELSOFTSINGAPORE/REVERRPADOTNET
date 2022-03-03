Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sagyou_Report_KS_EU
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        TextBox1.Text = Format(Now.Date, "yyyyîNMMåéddì˙")

        'èCóùì‡óe
        TextBox19.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox19.Text = DtView1(i)("cmnt")
                Else
                    TextBox19.Text = TextBox19.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        'èCóùì‡óe
        TextBox6.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print06"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox6.Text = DtView1(i)("cmnt")
                Else
                    TextBox6.Text = TextBox6.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Label53 As DataDynamics.ActiveReports.Label = Nothing
	Private Label54 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Label56 As DataDynamics.ActiveReports.Label = Nothing
	Private Label57 As DataDynamics.ActiveReports.Label = Nothing
	Private Label58 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label59 As DataDynamics.ActiveReports.Label = Nothing
	Private Label60 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label61 As DataDynamics.ActiveReports.Label = Nothing
	Private Label62 As DataDynamics.ActiveReports.Label = Nothing
	Private Label63 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox49 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Sagyou_Report_KS_EU.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox1 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Line)
		Me.Label = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Line6 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Line)
		Me.TextBox3 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label51 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Line11 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Line)
		Me.Label53 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label54 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.TextBox29 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Line)
		Me.Label56 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label57 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label58 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.Label59 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Label)
		Me.Label60 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.Label61 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label62 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label63 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.TextBox)
		Me.Label20 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Label)
		Me.TextBox42 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.TextBox)
		Me.Label21 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.TextBox44 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.TextBox)
		Me.Label8 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.TextBox47 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.TextBox)
		Me.TextBox49 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox19.Text) <> Nothing Then
                TextBox19.Text = TextBox19.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox19.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox49.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & TextBox49.Text
            Else
                TextBox6.Text = TextBox49.Text
            End If
        End If

        If TextBox2.Text = "OW" Then
            TextBox42.Text = "óLèû"
        Else
            TextBox42.Text = "ï€èÿ"
        End If

    End Sub
End Class
