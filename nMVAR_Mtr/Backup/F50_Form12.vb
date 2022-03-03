Public Class F50_Form12
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Private daClnd As New SqlClient.SqlDataAdapter
    Private dsClnd As New DataSet
    Private label(99) As Label
    Dim selectdate As Object
    Dim PF, strtwk, i, j, k, r, x, y As Integer
    Dim dttbl As DataTable
    Private dtrow As DataRow

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
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents sat As System.Windows.Forms.Label
    Friend WithEvents fri As System.Windows.Forms.Label
    Friend WithEvents thu As System.Windows.Forms.Label
    Friend WithEvents wed As System.Windows.Forms.Label
    Friend WithEvents tue As System.Windows.Forms.Label
    Friend WithEvents mon As System.Windows.Forms.Label
    Friend WithEvents sun As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents nowym As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.sat = New System.Windows.Forms.Label
        Me.fri = New System.Windows.Forms.Label
        Me.thu = New System.Windows.Forms.Label
        Me.wed = New System.Windows.Forms.Label
        Me.tue = New System.Windows.Forms.Label
        Me.mon = New System.Windows.Forms.Label
        Me.sun = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.nowym = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Olive
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Location = New System.Drawing.Point(240, 392)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(68, 32)
        Me.Button7.TabIndex = 151
        Me.Button7.TabStop = False
        Me.Button7.Text = "次　へ"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Olive
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(128, 392)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(68, 32)
        Me.Button6.TabIndex = 150
        Me.Button6.TabStop = False
        Me.Button6.Text = "前　へ"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(72, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(304, 200)
        Me.Panel1.TabIndex = 147
        '
        'sat
        '
        Me.sat.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sat.ForeColor = System.Drawing.Color.Blue
        Me.sat.Location = New System.Drawing.Point(336, 56)
        Me.sat.Name = "sat"
        Me.sat.Size = New System.Drawing.Size(24, 24)
        Me.sat.TabIndex = 146
        Me.sat.Text = "土"
        '
        'fri
        '
        Me.fri.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fri.Location = New System.Drawing.Point(296, 56)
        Me.fri.Name = "fri"
        Me.fri.Size = New System.Drawing.Size(24, 24)
        Me.fri.TabIndex = 145
        Me.fri.Text = "金"
        '
        'thu
        '
        Me.thu.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thu.Location = New System.Drawing.Point(256, 56)
        Me.thu.Name = "thu"
        Me.thu.Size = New System.Drawing.Size(24, 24)
        Me.thu.TabIndex = 144
        Me.thu.Text = "木"
        '
        'wed
        '
        Me.wed.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wed.Location = New System.Drawing.Point(216, 56)
        Me.wed.Name = "wed"
        Me.wed.Size = New System.Drawing.Size(24, 24)
        Me.wed.TabIndex = 143
        Me.wed.Text = "水"
        '
        'tue
        '
        Me.tue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tue.Location = New System.Drawing.Point(176, 56)
        Me.tue.Name = "tue"
        Me.tue.Size = New System.Drawing.Size(24, 24)
        Me.tue.TabIndex = 142
        Me.tue.Text = "火"
        '
        'mon
        '
        Me.mon.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mon.Location = New System.Drawing.Point(136, 56)
        Me.mon.Name = "mon"
        Me.mon.Size = New System.Drawing.Size(24, 24)
        Me.mon.TabIndex = 141
        Me.mon.Text = "月"
        '
        'sun
        '
        Me.sun.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sun.ForeColor = System.Drawing.Color.Red
        Me.sun.Location = New System.Drawing.Point(88, 56)
        Me.sun.Name = "sun"
        Me.sun.Size = New System.Drawing.Size(24, 24)
        Me.sun.TabIndex = 140
        Me.sun.Text = "日"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 288)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(400, 24)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "日付をクリックして休日設定を行います。（休日は赤色）"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.Location = New System.Drawing.Point(8, 376)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(448, 3)
        Me.PictureBox2.TabIndex = 137
        Me.PictureBox2.TabStop = False
        '
        'nowym
        '
        Me.nowym.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nowym.Location = New System.Drawing.Point(168, 16)
        Me.nowym.Name = "nowym"
        Me.nowym.Size = New System.Drawing.Size(112, 24)
        Me.nowym.TabIndex = 136
        Me.nowym.Text = "年月"
        Me.nowym.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 336)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(440, 24)
        Me.msg.TabIndex = 135
        Me.msg.Text = "msg"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 392)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1262
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(360, 392)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 1263
        Me.Button98.Text = "戻る"
        '
        'F50_Form12
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(474, 439)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.sat)
        Me.Controls.Add(Me.fri)
        Me.Controls.Add(Me.thu)
        Me.Controls.Add(Me.wed)
        Me.Controls.Add(Me.tue)
        Me.Controls.Add(Me.mon)
        Me.Controls.Add(Me.sun)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.nowym)
        Me.Controls.Add(Me.msg)
        Me.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "カレンダ"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        selectdate = Now()
        nowym.Text = Year(selectdate) & "年" & Month(selectdate) & "月"
        msg.Text() = Nothing
    End Sub

    '********************************************************************
    '**  権限チェック
    '********************************************************************
    Sub ACES()

        SqlCmd1 = New SqlClient.SqlCommand("sp_ACES_CHK", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram1.Value = P_ACES_brch_code
        Pram2.Value = P_ACES_post_code
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ACES_CHK")
        DB_CLOSE()

        Button1.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='512'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "3", "4"
                Button1.Enabled = True
        End Select

    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()

        msg.Text() = Nothing

        'SqlSelectCommand
        Dim SqlSelectCommand As New SqlClient.SqlCommand
        SqlSelectCommand.CommandText = "SELECT CLND_DATE, hldy_flg FROM M22_CLND WHERE Year(CLND_DATE) = '" & Year(selectdate) & "' AND Month(CLND_DATE) = '" & Month(selectdate) & "' "
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        daClnd.SelectCommand = SqlSelectCommand

        Try
            dsClnd.Clear()
            DB_OPEN("nMVAR")
            r = daClnd.Fill(dsClnd, "M22_CLND")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            DB_CLOSE()
        End Try

        If r = 0 Then
            msg.Text = "データが登録されていません。"
        Else
            dttbl = dsClnd.Tables("M22_CLND")
            strtwk = DatePart("ww", dttbl.Rows(0)(0))

            For k = 1 To dttbl.Rows.Count
                i = DatePart("w", dttbl.Rows(k - 1)(0)) - 1
                j = DatePart("ww", dttbl.Rows(k - 1)(0)) - strtwk
                label(k) = New Label
                label(k).Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(k).TextAlign = System.Windows.Forms.HorizontalAlignment.Center
                label(k).Location = New System.Drawing.Point(18 + i * 41, 10 + j * 32)
                label(k).Size = New System.Drawing.Size(24, 16)
                label(k).Text = DatePart("d", dttbl.Rows(k - 1)(0))
                label(k).Cursor = System.Windows.Forms.Cursors.Hand

                If dttbl.Rows(k - 1)(1) = "True" Then
                    label(k).ForeColor = System.Drawing.Color.Red
                End If
                label(k).Tag = k
                Panel1.Controls.Add(label(k))
                AddHandler label(k).Click, AddressOf m_label_Click
            Next
        End If
    End Sub

    '********************************************************************
    '**  クリック
    '********************************************************************
    Private Sub m_label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim lbl As Label
        lbl = DirectCast(sender, Label)
        dtrow = dttbl.Rows(lbl.Tag - 1)

        msg.Text() = Nothing
        dtrow.BeginEdit()
        If dtrow(1) = 0 Then
            dtrow(1) = 1
            label(lbl.Tag).ForeColor = System.Drawing.Color.Red
        Else
            dtrow(1) = 0
            label(lbl.Tag).ForeColor = System.Drawing.Color.Black
        End If
        dtrow.EndEdit()
    End Sub

    Sub modify_data()

        Dim lbl As Label

        'SqlUpdateCommand()
        Dim SqlUpdateCommand As New SqlClient.SqlCommand
        SqlUpdateCommand.CommandText = "UPDATE M22_CLND SET hldy_flg = @HLDY_FLAG WHERE CLND_DATE = @CLND_DATE"
        Dim Pram1 As SqlClient.SqlParameter = SqlUpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HLDY_FLAG", System.Data.SqlDbType.Bit, 1, "hldy_flg"))
        Dim Pram2 As SqlClient.SqlParameter = SqlUpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CLND_DATE", System.Data.SqlDbType.DateTime, 8, "CLND_DATE"))
        SqlUpdateCommand.CommandType = CommandType.Text
        SqlUpdateCommand.Connection = cnsqlclient
        daClnd.UpdateCommand = SqlUpdateCommand

        If Not dsClnd.HasChanges(DataRowState.Modified) Then
            msg.Text = "変更されたデータはありません。"
            Exit Sub
        Else
            Dim xdsClnd As DataSet
            xdsClnd = dsClnd.GetChanges(DataRowState.Modified)
            Pram1.Value = dtrow(1)
            Pram2.Value = Year(selectdate) & "/" & Month(selectdate) & "/" & dtrow(1)
        End If

        Try
            DB_OPEN("nMVAR")
            daClnd.Update(dttbl)
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            DB_CLOSE()
        End Try
        msg.Text = Year(selectdate) & "年" & Month(selectdate) & "月分を設定しました。"
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        msg.Text() = Nothing
        Call modify_data()
    End Sub

    '********************************************************************
    '**  前へ
    '********************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim ans As String

        If Button1.Enabled = True Then
            If dsClnd.HasChanges(DataRowState.Modified) Then
                ans = MessageBox.Show("変更されたデータがあります。設定を行いますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ans = DialogResult.Yes Then
                    Call modify_data()
                    x = x - 1
                    selectdate = DateAdd("m", x, Now())
                    nowym.Text = (Year(selectdate) & "年" & Month(selectdate) & "月")
                    Panel1.Controls.Clear()
                    Call DspSet()
                End If
            Else
                x = x - 1
                selectdate = DateAdd("m", x, Now())
                nowym.Text = (Year(selectdate) & "年" & Month(selectdate) & "月")
                Panel1.Controls.Clear()
                Call DspSet()
            End If
        Else
            x = x - 1
            selectdate = DateAdd("m", x, Now())
            nowym.Text = (Year(selectdate) & "年" & Month(selectdate) & "月")
            Panel1.Controls.Clear()
            Call DspSet()
        End If
    End Sub

    '********************************************************************
    '**  次へ
    '********************************************************************
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim ans As String

        If Button1.Enabled = True Then
            If dsClnd.HasChanges(DataRowState.Modified) Then
                ans = MessageBox.Show("変更されたデータがあります。設定を行いますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ans = DialogResult.Yes Then
                    Call modify_data()
                    x = x + 1
                    selectdate = DateAdd("m", x, Now())
                    nowym.Text = (Year(selectdate) & "年" & Month(selectdate) & "月")
                    Panel1.Controls.Clear()
                    Call DspSet()
                End If
            Else
                x = x + 1
                selectdate = DateAdd("m", x, Now())
                nowym.Text = (Year(selectdate) & "年" & Month(selectdate) & "月")
                Panel1.Controls.Clear()
                Call DspSet()
            End If
        Else
            x = x + 1
            selectdate = DateAdd("m", x, Now())
            nowym.Text = (Year(selectdate) & "年" & Month(selectdate) & "月")
            Panel1.Controls.Clear()
            Call DspSet()
        End If
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        dsClnd.Clear()
        Close()
    End Sub
End Class
