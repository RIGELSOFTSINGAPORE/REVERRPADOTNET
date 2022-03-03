Public Class F00_Form10_03
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F As String

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
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label20 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Edit01
        '
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.HighlightText = True
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(88, 12)
        Me.Edit01.MaxLength = 100
        Me.Edit01.Multiline = True
        Me.Edit01.Name = "Edit01"
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(456, 72)
        Me.Edit01.TabIndex = 0
        Me.Edit01.Text = "Edit01"
        Me.Edit01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Top
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(12, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 72)
        Me.Label20.TabIndex = 225
        Me.Label20.Text = "削除理由"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(12, 92)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 28)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "削除"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(472, 92)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 2
        Me.Button99.Text = "閉じる"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(92, 96)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(368, 20)
        Me.msg.TabIndex = 1348
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F00_Form10_03
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(558, 127)
        Me.ControlBox = False
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label20)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form10_03"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "削除理由"
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form10_03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Edit01.Text = Nothing
        msg.Text = Nothing
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        Call CK_Edit01()     '削除理由
        If msg.Text <> Nothing Then Err_F = "1" : Edit01.Focus() : Exit Sub

        If P_PRAM2 <> Nothing Then
            DsList1.Clear()
            strSQL = "SELECT upd_date FROM T01_member WHERE (code = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "T01_member")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(DtView1(0)("upd_date")) Then
                If P_PRAM2 <> DtView1(0)("upd_date") Then
                    msg.Text = "別の担当者がデータを修正しています。"
                    Err_F = "1" : Exit Sub
                End If
            End If
        End If

    End Sub
    Sub CK_Edit01()     '削除理由
        msg.Text = Nothing
        Edit01.Text = Trim(Edit01.Text)

        If Edit01.Text = Nothing Then
            msg.Text = "削除理由の入力がありません。"
            Edit01.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Edit01.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.LostFocus
        Call CK_Edit01()     '削除理由
    End Sub

    '******************************************************************
    '** 削除
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call F_chk()    '** 項目チェック
        If Err_F = "0" Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            P_PRAM3 = Edit01.Text

            DsList1.Clear()
            P_RTN = "1"
            Cursor = System.Windows.Forms.Cursors.Default
            Close()
        End If
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        P_RTN = "0"
        Close()
    End Sub
End Class
