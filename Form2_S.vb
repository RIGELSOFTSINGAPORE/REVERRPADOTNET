Public Class Form2_S
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, WK_ADRS As String
    Dim i, line_no, r As Integer
    Dim label(9999, 9) As label

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
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button11 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Panel1.Location = New System.Drawing.Point(24, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(904, 592)
        Me.Panel1.TabIndex = 0
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button11.Location = New System.Drawing.Point(816, 640)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(96, 30)
        Me.Button11.TabIndex = 142
        Me.Button11.TabStop = False
        Me.Button11.Text = "閉じる"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(164, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 22)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "電話番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(34, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 22)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "氏 名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(264, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 22)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "生年月日"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(344, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 22)
        Me.Label4.TabIndex = 146
        Me.Label4.Text = "メーカー名"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(494, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 22)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "部門名"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(782, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 22)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "加入日"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(642, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 22)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "商 品"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form2_S
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(938, 679)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form2_S"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "選択"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_S_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        line_no = 0

        For i = 0 To DtTbl0.Rows.Count - 1
            label(i, 1) = New Label
            If line_no Mod 2 = 0 Then
                label(i, 1).BackColor = System.Drawing.Color.White
            Else
                label(i, 1).BackColor = System.Drawing.Color.DarkGray
            End If
            label(i, 1).Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, 1).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, 1).Location = New System.Drawing.Point(10, 22 * line_no)
            label(i, 1).Size = New System.Drawing.Size(130, 22)
            label(i, 1).Text = DtTbl0.Rows(i)("CUST_NAME")
            label(i, 1).Tag = i
            Panel1.Controls.Add(label(i, 1))
            AddHandler label(i, 1).Click, AddressOf Label_Click

            label(i, 2) = New Label
            If line_no Mod 2 = 0 Then
                label(i, 2).BackColor = System.Drawing.Color.White
            Else
                label(i, 2).BackColor = System.Drawing.Color.DarkGray
            End If
            label(i, 2).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, 2).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, 2).Location = New System.Drawing.Point(140, 22 * line_no)
            label(i, 2).Size = New System.Drawing.Size(100, 22)
            label(i, 2).Text = DtTbl0.Rows(i)("TEL_NO").ToString
            label(i, 2).Tag = i
            Panel1.Controls.Add(label(i, 2))
            AddHandler label(i, 2).Click, AddressOf Label_Click

            label(i, 3) = New Label
            If line_no Mod 2 = 0 Then
                label(i, 3).BackColor = System.Drawing.Color.White
            Else
                label(i, 3).BackColor = System.Drawing.Color.DarkGray
            End If
            label(i, 3).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, 3).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, 3).Location = New System.Drawing.Point(240, 22 * line_no)
            label(i, 3).Size = New System.Drawing.Size(80, 22)
            If IsDBNull(DtTbl0.Rows(i)("BRTH_DATE")) = False Then
                label(i, 3).Text = Format(DtTbl0.Rows(i)("BRTH_DATE"), "yyyy/MM/dd")
            End If
            label(i, 3).Tag = i
            Panel1.Controls.Add(label(i, 3))
            AddHandler label(i, 3).Click, AddressOf Label_Click

            label(i, 4) = New Label
            If line_no Mod 2 = 0 Then
                label(i, 4).BackColor = System.Drawing.Color.White
            Else
                label(i, 4).BackColor = System.Drawing.Color.DarkGray
            End If
            label(i, 4).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, 4).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, 4).Location = New System.Drawing.Point(320, 22 * line_no)
            label(i, 4).Size = New System.Drawing.Size(150, 22)
            label(i, 4).Text = DtTbl0.Rows(i)("MKR_NAME").ToString
            label(i, 4).Tag = i
            Panel1.Controls.Add(label(i, 4))
            AddHandler label(i, 4).Click, AddressOf Label_Click

            label(i, 5) = New Label
            If line_no Mod 2 = 0 Then
                label(i, 5).BackColor = System.Drawing.Color.White
            Else
                label(i, 5).BackColor = System.Drawing.Color.DarkGray
            End If
            label(i, 5).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, 5).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, 5).Location = New System.Drawing.Point(470, 22 * line_no)
            label(i, 5).Size = New System.Drawing.Size(150, 22)
            label(i, 5).Text = DtTbl0.Rows(i)("CAT_NAME").ToString
            label(i, 5).Tag = i
            Panel1.Controls.Add(label(i, 5))
            AddHandler label(i, 5).Click, AddressOf Label_Click

            label(i, 6) = New Label
            If line_no Mod 2 = 0 Then
                label(i, 6).BackColor = System.Drawing.Color.White
            Else
                label(i, 6).BackColor = System.Drawing.Color.DarkGray
            End If
            label(i, 6).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, 6).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, 6).Location = New System.Drawing.Point(620, 22 * line_no)
            label(i, 6).Size = New System.Drawing.Size(140, 22)
            label(i, 6).Text = DtTbl0.Rows(i)("MODEL").ToString
            label(i, 6).Tag = i
            Panel1.Controls.Add(label(i, 6))
            AddHandler label(i, 6).Click, AddressOf Label_Click

            label(i, 7) = New Label
            If line_no Mod 2 = 0 Then
                label(i, 7).BackColor = System.Drawing.Color.White
            Else
                label(i, 7).BackColor = System.Drawing.Color.DarkGray
            End If
            label(i, 7).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(i, 7).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(i, 7).Location = New System.Drawing.Point(760, 22 * line_no)
            label(i, 7).Size = New System.Drawing.Size(100, 22)
            If IsDBNull(DtTbl0.Rows(i)("WRN_DATE")) = False Then
                label(i, 7).Text = Format(DtTbl0.Rows(i)("WRN_DATE"), "yyyy/MM/dd")
            End If
            label(i, 7).Tag = i
            Panel1.Controls.Add(label(i, 7))
            AddHandler label(i, 7).Click, AddressOf Label_Click

            label(i, 8) = New Label
            If IsDBNull(DtTbl0.Rows(i)("WRN_NO")) = False Then
                label(i, 8).Text = DtTbl0.Rows(i)("WRN_NO")
            End If

            line_no = line_no + 1
        Next

    End Sub

    Private Sub Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor.Current = Cursors.WaitCursor

        Dim lbl As Label
        lbl = DirectCast(sender, Label)
        DtTbl0 = DataSet0.Tables("WRN_DATA")
        pWrn_no = label(lbl.Tag, 8).Text

        DsList1.Clear()
        strSQL = "SELECT ICDT_DATA.ICDT_NO, ICDT_DATA.ID"
        strSQL = strSQL & " FROM ICDT_DATA RIGHT OUTER JOIN WRN_DATA ON ICDT_DATA.WRN_NO = WRN_DATA.WRN_NO"
        strSQL = strSQL & " WHERE ICDT_DATA.STATUS <> '004' AND ICDT_DATA.FIN_FLAG <> '1' AND WRN_DATA.WRN_NO = '" & pWrn_no & "'"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "SELECT_DATA")

        DtView1 = New DataView(DsList1.Tables("SELECT_DATA"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 1 Then
            MsgBox("現在、この保証番号には未完了のインシデントがあります。", MsgBoxStyle.OKOnly, "Warranty System")
            pPROC = "r1"
            'pIcdt_no = DtView1(0)("ICDT_NO")
            pID = DtView1(0)("ID")
        Else
            pPROC = "n1"
        End If

        Dim frmform3 As New Form3
        frmform3.ShowDialog()

        Me.Cursor.Current = Cursors.Default
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        DsList1.Clear()
        Me.Close()
    End Sub
End Class
