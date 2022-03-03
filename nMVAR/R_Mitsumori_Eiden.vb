Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Mitsumori_Eiden
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        'å©êœì‡óe
        TextBox.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox.Text = DtView1(i)("cmnt")
                Else
                    TextBox.Text = TextBox.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label52 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private Label35 As DataDynamics.ActiveReports.Label = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private Label37 As DataDynamics.ActiveReports.Label = Nothing
	Private Label38 As DataDynamics.ActiveReports.Label = Nothing
	Private Label39 As DataDynamics.ActiveReports.Label = Nothing
	Private Label40 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private Line20 As DataDynamics.ActiveReports.Line = Nothing
	Private Line21 As DataDynamics.ActiveReports.Line = Nothing
	Private Line22 As DataDynamics.ActiveReports.Line = Nothing
	Private Line23 As DataDynamics.ActiveReports.Line = Nothing
	Private Line24 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Mitsumori_Eiden.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label9 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox10 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.TextBox45 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label14 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.TextBox1 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.Label49 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label51 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Label)
		Me.TextBox8 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.Label52 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.TextBox9 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.TextBox2 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.Label22 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.TextBox3 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.Label23 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.Label5 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Label)
		Me.TextBox7 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.Label25 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.TextBox14 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.Label29 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.Label30 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.Label31 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.TextBox16 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label32 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.Label34 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Label)
		Me.Label35 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Label)
		Me.Label36 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label37 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.Label38 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Label)
		Me.Label39 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Label)
		Me.Label40 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Line)
		Me.Line20 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Line)
		Me.Line21 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Line)
		Me.Line23 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Line)
		Me.Line24 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.Line)
		Me.TextBox48 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox36 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox41 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox21 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox13 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox18 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox.Text) <> Nothing Then
                TextBox.Text = TextBox.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox27.Text) <> Nothing Then
            If Trim(TextBox.Text) <> Nothing Then
                TextBox.Text = TextBox.Text & System.Environment.NewLine & TextBox27.Text
            Else
                TextBox.Text = TextBox27.Text
            End If
        End If

        'TextBox4.Text = "\" & Format(CInt(TextBox36.Text) + CInt(TextBox41.Text) + CInt(TextBox21.Text) + CInt(TextBox13.Text), "##,##0")
    End Sub
End Class
