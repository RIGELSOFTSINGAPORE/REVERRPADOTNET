Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Mitsumori_Seikyo_QGCARE

    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '�C�����e
        TextBox43.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox43.Text = DtView1(i)("cmnt")
                Else
                    TextBox43.Text = TextBox43.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '���ϓ��e
        TextBox44.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox44.Text = DtView1(i)("cmnt")
                Else
                    TextBox44.Text = TextBox44.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '���i
        TextBox30.Text = Nothing : TextBox31.Text = Nothing
        TextBox40.Text = Nothing : TextBox32.Text = Nothing
        TextBox42.Text = Nothing : TextBox35.Text = Nothing
        TextBox41.Text = Nothing : TextBox34.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox30.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Is = 1
                        TextBox40.Text = DtView1(i)("part_name")
                        TextBox32.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Is = 2
                        TextBox42.Text = DtView1(i)("part_name")
                        TextBox35.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Else
                        TextBox41.Text = DtView1(i)("part_name")
                        TextBox34.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("part_amnt") * DtView1(i)("use_qty")
                End Select

                If DtView1.Count > 4 Then
                    TextBox41.Text = "���̑����i"
                    TextBox34.Text = Nothing
                End If
            Next
        End If

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

        '�C���M�����[�����i2010/04�܂ł͌��x�z�c����\�����Ȃ��j
        If TextBox28.Text < "2010/04/01" Then
            Label5.Visible = False
            Label16.Visible = False
            Label17.Visible = False
            Label18.Visible = False
            TextBox6.Visible = False
            Line6.Visible = False
            Line16.Visible = False
            Line17.Visible = False
            Line18.Visible = False
            Line19.Visible = False
        End If

        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox43.Text) <> Nothing Then
                TextBox43.Text = TextBox43.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox43.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox44.Text) <> Nothing Then
                TextBox44.Text = TextBox44.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox44.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox11.Text) <> Nothing Then
            If Trim(TextBox44.Text) <> Nothing Then
                TextBox44.Text = TextBox44.Text & System.Environment.NewLine & TextBox11.Text
            Else
                TextBox44.Text = TextBox11.Text
            End If
        End If

        Select Case Mid(TextBox27.Text, 1, 1)
            Case Is = "A", "E"
                'TextBox6.Text = Format(CInt(TextBox26.Text) - (CInt(TextBox25.Text) + CInt(TextBox24.Text) + CInt(TextBox8.Text) + CInt(TextBox7.Text) + CInt(TextBox62.Text)), "##,##0")
                TextBox6.Text = Format(CInt(TextBox26.Text) - (CInt(TextBox29.Text) + CInt(TextBox62.Text)), "##,##0")
            Case Else
                TextBox6.Text = Format(CInt(TextBox26.Text), "##,##0")
        End Select

        Label4.Text = "���ϗL�����ԁF ���ό�" & TextBox101.Text & "����"
        Label21.Text = "�E �������i�̕ۏ؊��Ԃ́A�C�����������" & TextBox100.Text & "���Ԃł��B"

    End Sub
End Class
