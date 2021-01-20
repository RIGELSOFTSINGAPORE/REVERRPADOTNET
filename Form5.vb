Public Class Form5
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim Dataadp1 As New SqlClient.SqlDataAdapter
    Dim Dataset1 As New DataSet
    Dim Dttbl1 As DataTable
    Dim i, j, line_no, cnt As Integer
    Dim en, en2 As Integer
    Dim label(9999, 99) As label
    Dim txtbox(9999, 99) As TextBox

    Dim strSQL As String

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button12 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(40, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 520)
        Me.Panel1.TabIndex = 0
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button12.Location = New System.Drawing.Point(832, 584)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(96, 30)
        Me.Button12.TabIndex = 144
        Me.Button12.TabStop = False
        Me.Button12.Text = "閉じる"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Location = New System.Drawing.Point(8, 568)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(920, 3)
        Me.PictureBox1.TabIndex = 145
        Me.PictureBox1.TabStop = False
        '
        'Form5
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(940, 621)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form5"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "変更履歴"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Dim SqlSelectCommand As New SqlClient.SqlCommand
        SqlSelectCommand.CommandText = "SELECT CLS_CODE.CLS_CODE_NAME, WRN_DATA_UPD.ORG_ITEM, " & _
                "WRN_DATA_UPD.WRN_NO, WRN_DATA_UPD.UPD_ITEM, WRN_DATA_UPD.UPD_RSN, WRN_DATA_UPD.UPD_DATE, EMPL.EMPL_NAME, CLS_CODE.CLS_CODE " & _
                "FROM EMPL RIGHT OUTER JOIN WRN_DATA_UPD ON EMPL.EMPL_CODE = WRN_DATA_UPD.EMPL_CODE LEFT OUTER JOIN " & _
                "CLS_CODE ON WRN_DATA_UPD.ITEM_CLS = CLS_CODE.CLS_CODE " & _
                "WHERE CLS_CODE.CLS_NO = '008' AND WRN_DATA_UPD.WRN_NO = '" & pWrn_no & "' ORDER BY WRN_DATA_UPD.UPD_DATE"
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        Dataadp1.SelectCommand = SqlSelectCommand

        DB_OPEN()
        Dataadp1.Fill(Dataset1, "UPD")
        DB_CLOSE()

        Dttbl1 = Dataset1.Tables("UPD")

        line_no = 0

        label(0, 0) = New Label
        label(0, 0).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        label(0, 0).Location = New System.Drawing.Point(10, 22 * line_no)
        label(0, 0).Size = New System.Drawing.Size(840, 1)
        Panel1.Controls.Add(label(0, 0))

        line_no = 0
        For i = 0 To Dttbl1.Rows.Count - 1
            en = 1
            label(i, en) = New Label
            If i Mod 2 = 0 Then
                label(i, en).BackColor = System.Drawing.Color.LightBlue
            End If
            label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(10, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(400, 22)
            label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, en).Text = "変更日時: " & Format(Dttbl1.Rows(i)("UPD_DATE"), "yyyy.MM.dd HH:mm")
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))

            en = 2
            label(i, en) = New Label
            If i Mod 2 = 0 Then
                label(i, en).BackColor = System.Drawing.Color.LightBlue
            End If
            label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(410, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(440, 22)
            label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, en).Text = "変更担当者: " & Dttbl1.Rows(i)("EMPL_NAME")
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))
            line_no = line_no + 1

            en = 3
            label(i, en) = New Label
            If i Mod 2 = 0 Then
                label(i, en).BackColor = System.Drawing.Color.LightBlue
            End If
            label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(10, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(150, 22)
            label(i, en).Text = "変更項目: " & Dttbl1.Rows(i)("CLS_CODE_NAME")
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))

            en = 4
            label(i, en) = New Label
            If i Mod 2 = 0 Then
                label(i, en).BackColor = System.Drawing.Color.LightBlue
            End If
            label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(160, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(690, 22)
            label(i, en).Text = RTrim(Dttbl1.Rows(i)("ORG_ITEM").ToString) & " → " & RTrim(Dttbl1.Rows(i)("UPD_ITEM").ToString)
            If Dttbl1.Rows(i)("CLS_CODE") = "008" Then
                strSQL = "SELECT STTS_F_UPD.UPD_DATE1, xa.CLS_CODE_NAME AS RSN_NAME, EMPL.EMPL_NAME"
                strSQL = strSQL & " FROM STTS_F_UPD LEFT OUTER JOIN"
                strSQL = strSQL & " EMPL ON STTS_F_UPD.EMPL_CODE = EMPL.EMPL_CODE LEFT OUTER JOIN"
                strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME"
                strSQL = strSQL & " FROM CLS_CODE"
                strSQL = strSQL & " WHERE (CLS_NO = '010')) xa ON"
                strSQL = strSQL & " STTS_F_UPD.RSN_CODE = xa.CLS_CODE COLLATE Japanese_CI_AS"
                strSQL = strSQL & " WHERE (STTS_F_UPD.WRN_NO = '" & pWrn_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(DsList1, "STTS_F_UPD")
                DB_CLOSE()
                DtView2 = New DataView(DsList1.Tables("STTS_F_UPD"), "", "", DataViewRowState.CurrentRows)
                If DtView2.Count <> 0 Then
                    label(i, en).Text = label(i, en).Text & "  " & DtView2(0)("RSN_NAME")

                    If Not IsDBNull(DtView2(0)("EMPL_NAME")) Then
                        en2 = 7
                        label(i, en2) = New Label
                        If i Mod 2 = 0 Then
                            label(i, en2).BackColor = System.Drawing.Color.LightBlue
                        End If
                        label(i, en2).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                        label(i, en2).Location = New System.Drawing.Point(410, 22 * line_no)
                        label(i, en2).Size = New System.Drawing.Size(440, 22)
                        label(i, en2).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                        label(i, en2).Text = "確定担当者: " & DtView2(0)("EMPL_NAME")
                        Panel1.Controls.Add(label(i, en2))
                    End If
                End If

            End If
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))
            line_no = line_no + 1

            If Trim(Dttbl1.Rows(i)("UPD_RSN").ToString) <> Nothing Then
                en = 5
                txtbox(i, en) = New TextBox
                txtbox(i, en).AutoSize = False
                txtbox(i, en).BorderStyle = System.Windows.Forms.BorderStyle.None
                txtbox(i, en).Multiline = True
                txtbox(i, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
                txtbox(i, en).ReadOnly = True
                txtbox(i, en).TabStop = False
                If i Mod 2 = 0 Then
                    txtbox(i, en).BackColor = System.Drawing.Color.LightBlue
                Else
                    txtbox(i, en).BackColor = System.Drawing.Color.White
                End If
                txtbox(i, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                txtbox(i, en).Location = New System.Drawing.Point(10, 22 * line_no)
                txtbox(i, en).Text = "変更理由: " & RTrim(Dttbl1.Rows(i)("UPD_RSN"))
                cnt = CntStr(Dttbl1.Rows(i)("UPD_RSN"), vbCrLf)
                If cnt = 0 Then
                    txtbox(i, en).Size = New System.Drawing.Size(840, 22)
                    line_no = line_no + 1
                Else
                    cnt = cnt + 1
                    txtbox(i, en).Size = New System.Drawing.Size(840, 22 * cnt)
                    line_no = line_no + cnt
                End If
                txtbox(i, en).Tag = i
                Panel1.Controls.Add(txtbox(i, en))
            End If

            en = 6
            label(i, en) = New Label
            label(i, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            label(i, en).Location = New System.Drawing.Point(10, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(840, 1)
            Panel1.Controls.Add(label(i, en))
        Next

    End Sub

    Private Sub Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim lbl As Label
        lbl = DirectCast(sender, Label)
        MsgBox(Dttbl1.Rows(lbl.Tag)("UPD_RSN"), MsgBoxStyle.OKOnly, "変更理由")

    End Sub

    '*************************************************
    '** 戻る
    '*************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        DsList1.Clear()
        Dataset1.Clear()
        Me.Close()
    End Sub
End Class
