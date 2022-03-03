Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Inquiry_Free_Inq
    Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        TextBox1.Text = Format(Now.Date, "yyyyîNMMåéddì˙")

        'èCóùì‡óe
        TextBox12.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox12.Text = DtView1(i)("cmnt")
                Else
                    TextBox12.Text = TextBox12.Text & System.Environment.NewLine & DtView1(i)("cmnt")
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
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private Label50 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Shape As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape1 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape2 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape3 As DataDynamics.ActiveReports.Shape = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private Label38 As DataDynamics.ActiveReports.Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Inquiry_Free_Inq.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox1 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.TextBox9 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Label)
		Me.TextBox21 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.TextBox3 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label49 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label50 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.TextBox13 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.Label51 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.Label7 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Line)
		Me.Label9 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.TextBox7 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.Label11 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.TextBox8 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.Label14 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.Label16 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.TextBox16 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.TextBox)
		Me.Label17 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.Shape = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Shape)
		Me.Shape1 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Shape)
		Me.Shape2 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Shape)
		Me.Shape3 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Shape)
		Me.Label22 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.Line5 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Line)
		Me.TextBox12 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.TextBox)
		Me.Label2 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.TextBox17 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.TextBox)
		Me.TextBox47 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.TextBox)
		Me.Label36 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.Label38 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox12.Text) <> Nothing Then
                TextBox12.Text = TextBox12.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox12.Text = TextBox47.Text
            End If
        End If
    End Sub
End Class
