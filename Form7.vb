Public Class Form7
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView3 As DataView

    Dim strSQL As String
    Dim line_no, en, i As Integer
    Dim label(999, 50) As Label
    Dim txtbox(999, 50) As TextBox

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
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button12 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button12.Location = New System.Drawing.Point(816, 640)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(96, 30)
        Me.Button12.TabIndex = 147
        Me.Button12.TabStop = False
        Me.Button12.Text = "閉じる"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Location = New System.Drawing.Point(8, 632)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(920, 3)
        Me.PictureBox1.TabIndex = 148
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(16, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(912, 608)
        Me.Panel1.TabIndex = 146
        '
        'Form7
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(938, 679)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form7"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "進行状況"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Call pnl_set()

    End Sub

    Sub pnl_set()
        line_no = 0

        strSQL = "SELECT REPAIR_DATA.*, xa.LOCATION_NAME, EMPL.EMPL_NAME, xb.TIME1, xc.TIME2, xd.TIME3"
        strSQL = strSQL & " FROM REPAIR_DATA LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME3 FROM CLS_CODE WHERE (CLS_NO = '023')) xd ON"
        strSQL = strSQL & " REPAIR_DATA.HOPE_TIME1 = xd.CLS_CODE COLLATE Japanese_CI_AS LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME2 FROM CLS_CODE WHERE (CLS_NO = '023')) xc ON"
        strSQL = strSQL & " REPAIR_DATA.HOPE_TIME2 = xc.CLS_CODE COLLATE Japanese_CI_AS LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS TIME1 FROM CLS_CODE WHERE (CLS_NO = '022')) xb ON"
        strSQL = strSQL & " REPAIR_DATA.HOPE_TIME1 = xb.CLS_CODE COLLATE Japanese_CI_AS LEFT OUTER JOIN"
        strSQL = strSQL & " EMPL ON REPAIR_DATA.EMPL_CODE = EMPL.EMPL_CODE LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT CLS_CODE, CLS_CODE_NAME AS LOCATION_NAME FROM CLS_CODE WHERE (CLS_NO = '013')) xa ON"
        strSQL = strSQL & " REPAIR_DATA.LOCATION = xa.CLS_CODE COLLATE Japanese_CI_AS"
        strSQL = strSQL & " WHERE (REPAIR_DATA.REPAIR_CODE = '" & pREPAIR_CODE & "')"
        strSQL = strSQL & " ORDER BY REPAIR_DATA.PROC_DATE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "REPAIR_DATA")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("REPAIR_DATA"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1
            line_no = line_no + 1

            '変更日時
            en = 1
            label(line_no, en) = New Label
            label(line_no, en).BackColor = System.Drawing.Color.LightBlue
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(10, 20 * line_no)
            label(line_no, en).Size = New System.Drawing.Size(200, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = "変更日時: " & Format(DtView1(i)("PROC_DATE"), "yyyy.MM.dd HH:mm")
            Panel1.Controls.Add(label(line_no, en))

            '担当
            en = 2
            label(line_no, en) = New Label
            label(line_no, en).BackColor = System.Drawing.Color.LightBlue
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(210, 20 * line_no)
            label(line_no, en).Size = New System.Drawing.Size(190, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = "担当: " & DtView1(i)("EMPL_NAME")
            Panel1.Controls.Add(label(line_no, en))

            '修理受付番号
            en = 3
            label(line_no, en) = New Label
            label(line_no, en).BackColor = System.Drawing.Color.LightBlue
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * line_no)
            label(line_no, en).Size = New System.Drawing.Size(200, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = "修理受付番号: " & DtView1(i)("REPAIR_CODE_FST")
            Panel1.Controls.Add(label(line_no, en))

            '状況
            en = 4
            label(line_no, en) = New Label
            label(line_no, en).BackColor = System.Drawing.Color.LightBlue
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(600, 20 * line_no)
            label(line_no, en).Size = New System.Drawing.Size(250, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = "状況: " & DtView1(i)("LOCATION_NAME")
            Panel1.Controls.Add(label(line_no, en))

            '症状
            en = 7
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(10, 20 * (line_no + 1))
            label(line_no, en).Size = New System.Drawing.Size(150, 60)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "症状: "
            Panel1.Controls.Add(label(line_no, en))

            en = 8
            txtbox(line_no, en) = New TextBox
            txtbox(line_no, en).AutoSize = False
            txtbox(line_no, en).BackColor = System.Drawing.Color.White
            txtbox(line_no, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            txtbox(line_no, en).Multiline = True
            txtbox(line_no, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
            txtbox(line_no, en).ReadOnly = True
            txtbox(line_no, en).TabStop = False
            txtbox(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            txtbox(line_no, en).Location = New System.Drawing.Point(160, 20 * (line_no + 1))
            txtbox(line_no, en).Size = New System.Drawing.Size(240, 60)
            txtbox(line_no, en).Text = RTrim(DtView1(i)("SYMPTOM"))
            Panel1.Controls.Add(txtbox(line_no, en))

            'その他ご要望事項
            en = 9
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(10, 20 * (line_no + 4))
            label(line_no, en).Size = New System.Drawing.Size(150, 60)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "その他ご要望事項: "
            Panel1.Controls.Add(label(line_no, en))

            en = 11
            txtbox(line_no, en) = New TextBox
            txtbox(line_no, en).AutoSize = False
            txtbox(line_no, en).BackColor = System.Drawing.Color.White
            txtbox(line_no, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            txtbox(line_no, en).Multiline = True
            txtbox(line_no, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
            txtbox(line_no, en).ReadOnly = True
            txtbox(line_no, en).TabStop = False
            txtbox(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            txtbox(line_no, en).Location = New System.Drawing.Point(160, 20 * (line_no + 4))
            txtbox(line_no, en).Size = New System.Drawing.Size(240, 60)
            txtbox(line_no, en).Text = RTrim(DtView1(i)("DEMAND"))
            Panel1.Controls.Add(txtbox(line_no, en))

            'お預り品（付属品等）
            en = 11
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(10, 20 * (line_no + 7))
            label(line_no, en).Size = New System.Drawing.Size(150, 60)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "お預り品（付属品等）: "
            Panel1.Controls.Add(label(line_no, en))

            en = 12
            txtbox(line_no, en) = New TextBox
            txtbox(line_no, en).AutoSize = False
            txtbox(line_no, en).BackColor = System.Drawing.Color.White
            txtbox(line_no, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            txtbox(line_no, en).Multiline = True
            txtbox(line_no, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
            txtbox(line_no, en).ReadOnly = True
            txtbox(line_no, en).TabStop = False
            txtbox(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            txtbox(line_no, en).Location = New System.Drawing.Point(160, 20 * (line_no + 7))
            txtbox(line_no, en).Size = New System.Drawing.Size(240, 60)
            txtbox(line_no, en).Text = RTrim(DtView1(i)("CUSTODY"))
            Panel1.Controls.Add(txtbox(line_no, en))

            'ログ
            en = 13
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(10, 20 * (line_no + 10))
            label(line_no, en).Size = New System.Drawing.Size(150, 60)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "ログ: "
            Panel1.Controls.Add(label(line_no, en))

            en = 14
            txtbox(line_no, en) = New TextBox
            txtbox(line_no, en).AutoSize = False
            txtbox(line_no, en).BackColor = System.Drawing.Color.White
            txtbox(line_no, en).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            txtbox(line_no, en).Multiline = True
            txtbox(line_no, en).ScrollBars = System.Windows.Forms.ScrollBars.Both
            txtbox(line_no, en).ReadOnly = True
            txtbox(line_no, en).TabStop = False
            txtbox(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            txtbox(line_no, en).Location = New System.Drawing.Point(160, 20 * (line_no + 10))
            txtbox(line_no, en).Size = New System.Drawing.Size(240, 60)
            txtbox(line_no, en).Text = RTrim(DtView1(i)("LOG_DATA"))
            Panel1.Controls.Add(txtbox(line_no, en))

            '修理対象
            en = 15
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 1))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "修理対象: "
            Panel1.Controls.Add(label(line_no, en))

            en = 16
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 1))
            label(line_no, en).Size = New System.Drawing.Size(200, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            If DtView1(i)("LEAVE") = "1" Then
                label(line_no, en).Text = "引取"
            Else
                label(line_no, en).Text = "出張"
            End If
            Panel1.Controls.Add(label(line_no, en))

            '顧客情報
            en = 17
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 2))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "顧客情報: "
            Panel1.Controls.Add(label(line_no, en))

            en = 18
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 2))
            label(line_no, en).Size = New System.Drawing.Size(200, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            If DtView1(i)("CUST_CHG") = "1" Then
                label(line_no, en).Text = "変更なし"
            Else
                label(line_no, en).Text = "今回のみ"
            End If
            Panel1.Controls.Add(label(line_no, en))

            'お客様名
            en = 19
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 3))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "お客様名: "
            Panel1.Controls.Add(label(line_no, en))

            en = 20
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 3))
            label(line_no, en).Size = New System.Drawing.Size(200, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = RTrim(DtView1(i)("CUST_NAME"))
            If RTrim(DtView1(i)("CUST_NAME_KANA")) <> Nothing Then
                label(line_no, en).Text = label(line_no, en).Text & "（ " & RTrim(DtView1(i)("CUST_NAME_KANA")) & " ）"
            End If
            Panel1.Controls.Add(label(line_no, en))

            '郵便番号
            en = 21
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 4))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "郵便番号: "
            Panel1.Controls.Add(label(line_no, en))

            en = 22
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 4))
            label(line_no, en).Size = New System.Drawing.Size(200, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = DtView1(i)("ZIP1") & "-" & DtView1(i)("ZIP2")
            Panel1.Controls.Add(label(line_no, en))

            '住所
            en = 23
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 5))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "住所: "
            Panel1.Controls.Add(label(line_no, en))

            en = 24
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 5))
            label(line_no, en).Size = New System.Drawing.Size(350, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = DtView1(i)("ADRS1")
            Panel1.Controls.Add(label(line_no, en))

            en = 25
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 6))
            label(line_no, en).Size = New System.Drawing.Size(350, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = DtView1(i)("ADRS2")
            Panel1.Controls.Add(label(line_no, en))

            '電話番号
            en = 26
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 7))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "電話番号: "
            Panel1.Controls.Add(label(line_no, en))

            en = 27
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 7))
            label(line_no, en).Size = New System.Drawing.Size(140, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = DtView1(i)("TEL_NO")
            Panel1.Controls.Add(label(line_no, en))

            '連絡先
            en = 28
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(640, 20 * (line_no + 7))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "連絡先: "
            Panel1.Controls.Add(label(line_no, en))

            en = 29
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(740, 20 * (line_no + 7))
            label(line_no, en).Size = New System.Drawing.Size(120, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = DtView1(i)("CNT_NO")
            Panel1.Controls.Add(label(line_no, en))

            '連絡可能時間
            en = 30
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 8))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "連絡可能時間: "
            Panel1.Controls.Add(label(line_no, en))

            en = 31
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 8))
            label(line_no, en).Size = New System.Drawing.Size(300, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = RTrim(DtView1(i)("CALL_TIME"))
            Panel1.Controls.Add(label(line_no, en))

            '第一希望日時
            en = 32
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(400, 20 * (line_no + 9))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "第一希望日時: "
            Panel1.Controls.Add(label(line_no, en))

            en = 33
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 9))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            label(line_no, en).Text = Format(DtView1(i)("HOPE_DATE1"), "yyyy.MM.dd")
            Panel1.Controls.Add(label(line_no, en))

            en = 34
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(500, 20 * (line_no + 10))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            If DtView1(i)("LEAVE") = "1" Then
                label(line_no, en).Text = DtView1(i)("TIME1")
            Else
                label(line_no, en).Text = DtView1(i)("TIME3")
            End If
            Panel1.Controls.Add(label(line_no, en))

            '第二希望日時
            en = 35
            label(line_no, en) = New Label
            label(line_no, en).ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(640, 20 * (line_no + 9))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopRight
            label(line_no, en).Text = "第二希望日時: "
            Panel1.Controls.Add(label(line_no, en))

            en = 36
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(740, 20 * (line_no + 9))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            If Not IsDBNull(DtView1(i)("HOPE_DATE2")) Then
                label(line_no, en).Text = Format(DtView1(i)("HOPE_DATE2"), "yyyy.MM.dd")
            End If
            Panel1.Controls.Add(label(line_no, en))

            en = 37
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(740, 20 * (line_no + 10))
            label(line_no, en).Size = New System.Drawing.Size(100, 20)
            label(line_no, en).TextAlign = System.Drawing.ContentAlignment.TopLeft
            If Not IsDBNull(DtView1(i)("TIME2")) Then
                label(line_no, en).Text = DtView1(i)("TIME2")
            End If
            Panel1.Controls.Add(label(line_no, en))

            line_no = line_no + 12

        Next

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        DsList1.Clear()
        Me.Close()
    End Sub
End Class
