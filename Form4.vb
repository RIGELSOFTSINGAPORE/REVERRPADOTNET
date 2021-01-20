Public Class Form4
    Inherits System.Windows.Forms.Form

    Dim Dataadp1 As New SqlClient.SqlDataAdapter
    Dim Dataset1 As New DataSet
    Dim Dttbl1 As DataTable
    Dim i, j, line_no, cnt As Integer
    Dim en As Integer
    Dim label(9999, 99) As label
    Dim txtbox(9999, 99) As TextBox

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
        'Form4
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(940, 621)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form4"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "対応履歴"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        If dsp_mode = "w" Then
            Call w_dsp()  '加入データ
        ElseIf dsp_mode = "q" Then
            Call q_dsp()    '問い合わせ
        End If

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dataset1.Clear()
        Me.Close()
    End Sub

    Private Sub w_dsp()

        Dim SqlSelectCommand As New SqlClient.SqlCommand
        SqlSelectCommand.CommandText = "SELECT ICDT_DATA.*, ICDT_DTL.RCV_DATE, ICDT_DTL.END_DATE, ICDT_DTL.ID, ICDT_DTL.RPLY, EMPL.EMPL_NAME, CLS_CODE.CLS_CODE_NAME FROM ICDT_DTL RIGHT OUTER JOIN ICDT_DATA ON ICDT_DTL.ID = ICDT_DATA.ID LEFT OUTER JOIN CLS_CODE ON ICDT_DTL.STATUS = CLS_CODE.CLS_CODE LEFT OUTER JOIN EMPL ON ICDT_DTL.EMPL_CODE = EMPL.EMPL_CODE WHERE CLS_CODE.CLS_NO = '001' AND ICDT_DATA.WRN_NO = '" & pWrn_no & "' ORDER BY ICDT_DTL.ID, ICDT_DTL.RCV_DATE"
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        Dataadp1.SelectCommand = SqlSelectCommand

        DB_OPEN()
        Dataadp1.Fill(Dataset1, "ICDT_DTL")
        DB_CLOSE()

        Dttbl1 = Dataset1.Tables("ICDT_DTL")

        line_no = 0
        If Dttbl1.Rows.Count <> 0 Then
            For i = 0 To Dttbl1.Rows.Count - 1
                If i = 0 Then
                    en = 0
                    txtbox(i, en) = New TextBox
                    txtbox(i, en).AutoSize = False
                    txtbox(i, en).BackColor = System.Drawing.Color.White
                    txtbox(i, en).BorderStyle = System.Windows.Forms.BorderStyle.None
                    txtbox(i, en).Multiline = True
                    txtbox(i, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
                    txtbox(i, en).ReadOnly = True
                    txtbox(i, en).TabStop = False
                    txtbox(i, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                    txtbox(i, en).ForeColor = System.Drawing.Color.Navy
                    txtbox(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                    cnt = CntStr(Dttbl1.Rows(i)("ASKING"), vbCrLf)
                    If cnt = 0 Then
                        txtbox(i, en).Size = New System.Drawing.Size(840, 18)
                        txtbox(i, en).Text = "●問合せ内容: " & RTrim(Format(Dttbl1.Rows(i)("ASKING")))
                        txtbox(i, en).Tag = i
                        Panel1.Controls.Add(txtbox(i, en))
                        line_no = line_no + 1
                        en = 7
                        label(i, en) = New Label
                        label(i, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                        label(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                        label(i, en).Size = New System.Drawing.Size(840, 1)
                        Panel1.Controls.Add(label(i, en))
                    Else
                        cnt = cnt + 1
                        txtbox(i, en).Size = New System.Drawing.Size(840, 18 * cnt)
                        txtbox(i, en).Text = "●問合せ内容: " & RTrim(Format(Dttbl1.Rows(i)("ASKING")))
                        txtbox(i, en).Tag = i
                        Panel1.Controls.Add(txtbox(i, en))
                        line_no = line_no + cnt
                        en = 7
                        label(i, en) = New Label
                        label(i, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                        label(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                        label(i, en).Size = New System.Drawing.Size(840, 1)
                        Panel1.Controls.Add(label(i, en))
                    End If
                Else
                    If Format(Dttbl1.Rows(i)("ID")) <> Format(Dttbl1.Rows(i - 1)("ID")) Then
                        line_no = line_no + 1
                        en = 0
                        txtbox(i, en) = New TextBox
                        txtbox(i, en).AutoSize = False
                        txtbox(i, en).BackColor = System.Drawing.Color.White
                        txtbox(i, en).BorderStyle = System.Windows.Forms.BorderStyle.None
                        txtbox(i, en).Multiline = True
                        txtbox(i, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
                        txtbox(i, en).ReadOnly = True
                        txtbox(i, en).TabStop = False
                        txtbox(i, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                        txtbox(i, en).ForeColor = System.Drawing.Color.Navy
                        txtbox(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                        cnt = CntStr(Dttbl1.Rows(i)("ASKING"), vbCrLf)
                        If cnt = 0 Then
                            txtbox(i, en).Size = New System.Drawing.Size(840, 18)
                            txtbox(i, en).Text = "●問合せ内容: " & RTrim(Format(Dttbl1.Rows(i)("ASKING")))
                            txtbox(i, en).Tag = i
                            Panel1.Controls.Add(txtbox(i, en))
                            line_no = line_no + 1
                            en = 7
                            label(i, en) = New Label
                            label(i, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                            label(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                            label(i, en).Size = New System.Drawing.Size(840, 1)
                            Panel1.Controls.Add(label(i, en))
                        Else
                            cnt = cnt + 1
                            txtbox(i, en).Size = New System.Drawing.Size(840, 18 * cnt)
                            txtbox(i, en).Text = "●問合せ内容: " & RTrim(Format(Dttbl1.Rows(i)("ASKING")))
                            txtbox(i, en).Tag = i
                            Panel1.Controls.Add(txtbox(i, en))
                            line_no = line_no + cnt
                            en = 7
                            label(i, en) = New Label
                            label(i, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                            label(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                            label(i, en).Size = New System.Drawing.Size(840, 1)
                            Panel1.Controls.Add(label(i, en))
                        End If
                    End If
                End If

                Dim a1 As String
                a1 = Dttbl1.Rows(i)("RCV_DATE")

                en = 1
                label(i, en) = New Label
                label(i, en).BackColor = System.Drawing.Color.LightBlue
                label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                label(i, en).Size = New System.Drawing.Size(200, 18)
                label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                label(i, en).Text = "受付日時: " & Format(Dttbl1.Rows(i)("RCV_DATE"), "yyyy.MM.dd HH:mm")
                label(i, en).Tag = i
                Panel1.Controls.Add(label(i, en))

                en = 2
                label(i, en) = New Label
                label(i, en).BackColor = System.Drawing.Color.LightBlue
                label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(i, en).Location = New System.Drawing.Point(210, 18 * line_no)
                label(i, en).Size = New System.Drawing.Size(200, 18)
                label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                label(i, en).Text = "終了日時: " & Format(Dttbl1.Rows(i)("END_DATE"), "yyyy.MM.dd HH:mm")
                label(i, en).Tag = i
                Panel1.Controls.Add(label(i, en))

                en = 3
                label(i, en) = New Label
                label(i, en).BackColor = System.Drawing.Color.LightBlue
                label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(i, en).Location = New System.Drawing.Point(410, 18 * line_no)
                label(i, en).Size = New System.Drawing.Size(200, 18)
                label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                label(i, en).Text = "受付担当者: " & Dttbl1.Rows(i)("EMPL_NAME")
                label(i, en).Tag = i
                Panel1.Controls.Add(label(i, en))

                en = 4
                label(i, en) = New Label
                label(i, en).BackColor = System.Drawing.Color.LightBlue
                label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(i, en).Location = New System.Drawing.Point(610, 18 * line_no)
                label(i, en).Size = New System.Drawing.Size(240, 18)
                label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                label(i, en).Text = "ステイタス: " & Dttbl1.Rows(i)("CLS_CODE_NAME")
                label(i, en).Tag = i
                Panel1.Controls.Add(label(i, en))
                line_no = line_no + 1

                en = 5
                txtbox(i, en) = New TextBox
                txtbox(i, en).AutoSize = False
                txtbox(i, en).BackColor = System.Drawing.Color.LightBlue
                txtbox(i, en).BorderStyle = System.Windows.Forms.BorderStyle.None
                txtbox(i, en).Multiline = True
                txtbox(i, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
                txtbox(i, en).ReadOnly = True
                txtbox(i, en).TabStop = False
                txtbox(i, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                txtbox(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                cnt = CntStr(Dttbl1.Rows(i)("RPLY"), vbCrLf)
                If cnt = 0 Then
                    txtbox(i, en).Size = New System.Drawing.Size(840, 18)
                    line_no = line_no + 1
                Else
                    cnt = cnt + 1
                    txtbox(i, en).Size = New System.Drawing.Size(840, 18 * cnt)
                    line_no = line_no + cnt
                End If
                txtbox(i, en).Text = RTrim(Dttbl1.Rows(i)("RPLY"))
                txtbox(i, en).Tag = i
                Panel1.Controls.Add(txtbox(i, en))

                en = 6
                label(i, en) = New Label
                label(i, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                label(i, en).Location = New System.Drawing.Point(10, 18 * line_no)
                label(i, en).Size = New System.Drawing.Size(840, 1)
                Panel1.Controls.Add(label(i, en))
            Next
        Else
            en = 1
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 200)
            label(line_no, en).Size = New System.Drawing.Size(200, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = "履歴はありません。"
            Panel1.Controls.Add(label(line_no, en))
        End If

    End Sub

    Private Sub q_dsp()

        Dim SqlSelectCommand As New SqlClient.SqlCommand
        SqlSelectCommand.CommandText = "SELECT Q_DTL.RCV_DATE, Q_DTL.END_DATE, Q_DTL.Q_NO, Q_DTL.RPLY, EMPL.EMPL_NAME, CLS_CODE.CLS_CODE_NAME FROM Q_DTL LEFT OUTER JOIN CLS_CODE ON Q_DTL.STATUS = CLS_CODE.CLS_CODE LEFT OUTER JOIN EMPL ON Q_DTL.EMPL_CODE = EMPL.EMPL_CODE WHERE CLS_CODE.CLS_NO = '001' AND Q_DTL.Q_NO = '" & pq_no & "' ORDER BY Q_DTL.RCV_DATE DESC"
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        Dataadp1.SelectCommand = SqlSelectCommand

        DB_OPEN()
        Dataadp1.Fill(Dataset1, "Q_DTL")
        DB_CLOSE()

        Dttbl1 = Dataset1.Tables("Q_DTL")

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
            label(i, en).Size = New System.Drawing.Size(200, 22)
            label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, en).Text = "受付日時: " & Format(Dttbl1.Rows(i)("RCV_DATE"), "yyyy.MM.dd HH:mm")
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))

            en = 2
            label(i, en) = New Label
            If i Mod 2 = 0 Then
                label(i, en).BackColor = System.Drawing.Color.LightBlue
            End If
            label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(210, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(200, 22)
            label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, en).Text = "終了日時: " & Format(Dttbl1.Rows(i)("END_DATE"), "yyyy.MM.dd HH:mm")
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))

            en = 3
            label(i, en) = New Label
            If i Mod 2 = 0 Then
                label(i, en).BackColor = System.Drawing.Color.LightBlue
            End If
            label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(410, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(200, 22)
            label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, en).Text = "受付担当者: " & Dttbl1.Rows(i)("EMPL_NAME")
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))

            en = 4
            label(i, en) = New Label
            If i Mod 2 = 0 Then
                label(i, en).BackColor = System.Drawing.Color.LightBlue
            End If
            label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(610, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(240, 22)
            label(i, en).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, en).Text = "ステイタス: " & Dttbl1.Rows(i)("CLS_CODE_NAME")
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))
            line_no = line_no + 1

            en = 5
            label(i, en) = New Label
            If i Mod 2 = 0 Then
                label(i, en).BackColor = System.Drawing.Color.LightBlue
            End If
            label(i, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, en).Location = New System.Drawing.Point(10, 22 * line_no)
            cnt = CntStr(Dttbl1.Rows(i)("RPLY"), vbCrLf)
            If cnt = 0 Then
                label(i, en).Size = New System.Drawing.Size(840, 22)
                line_no = line_no + 1
            Else
                cnt = cnt + 1
                label(i, en).Size = New System.Drawing.Size(840, 22 * cnt)
                line_no = line_no + cnt
            End If
            label(i, en).Text = Dttbl1.Rows(i)("RPLY")
            label(i, en).Tag = i
            Panel1.Controls.Add(label(i, en))

            en = 6
            label(i, en) = New Label
            label(i, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            label(i, en).Location = New System.Drawing.Point(10, 22 * line_no)
            label(i, en).Size = New System.Drawing.Size(840, 1)
            Panel1.Controls.Add(label(i, en))
        Next

    End Sub

End Class
