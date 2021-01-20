Imports Excel = Microsoft.Office.Interop.Excel
Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objMutex As System.Threading.Mutex
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2, DsExp As New DataSet
    Dim DsCMB, WK_DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim DtTbl1 As DataTable
    Dim WK_DtView1, WK_DtView2 As DataView

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim strSQL, WKstr As String
    Dim strFLD, strFile As String
    Dim strData As String
    Dim i, prc_cnt, r As Integer
    Dim WK_prch_price, WK_prch_date, WK_vdr_name As String

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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button99 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Date1 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Date2 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button99.Location = New System.Drawing.Point(480, 376)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 10
        Me.Button99.Text = "終了"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(136, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 24)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(64, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 24)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "処理日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(280, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "CSV出力"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("MS PGothic", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(16, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(584, 80)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "受信データCSV出力"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("MS PGothic", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(16, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(584, 152)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "ﾍﾞｽﾄｻｰﾋﾞｽ用CSV出力"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(56, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 23)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Label6"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(160, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 24)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "月処理分"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy.MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date1.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date1.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy.MM", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(64, 136)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(96, 24)
        Me.Date1.TabIndex = 3
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 24, 11, 17, 5, 0))
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(280, 168)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 40)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "データ出力"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(280, 216)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 40)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "データ出力"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(208, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 24)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "NDI"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(184, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 24)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "ACE , BPS"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(280, 296)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 32)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "データ出力"
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy.MM", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date2.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date2.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date2.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy.MM", "", "")
        Me.Date2.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date2.Location = New System.Drawing.Point(64, 296)
        Me.Date2.Name = "Date2"
        Me.Date2.Size = New System.Drawing.Size(96, 24)
        Me.Date2.TabIndex = 8
        Me.Date2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date2.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 24, 11, 17, 5, 0))
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(56, 320)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 23)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "Label16"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(160, 296)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 24)
        Me.Label17.TabIndex = 123
        Me.Label17.Text = "月処理分"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("MS PGothic", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Navy
        Me.Label18.Location = New System.Drawing.Point(16, 272)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(584, 88)
        Me.Label18.TabIndex = 122
        Me.Label18.Text = "1年超データCSV出力"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(424, 40)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(128, 32)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "XLS出力"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(136, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 23)
        Me.Label12.TabIndex = 128
        Me.Label12.Text = "Label12"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label12.Visible = False
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(424, 168)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(160, 40)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "データ出力(RE)     名前+J"
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Location = New System.Drawing.Point(424, 216)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(160, 40)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "データ出力(RE以外)     名前+J"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(610, 423)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "データ出力 Var 2.0"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '起動時
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_ivc_export")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If

        Call DB_INIT()
        Call DsSet()
        Call DateSet()
        Call CmbSet()
    End Sub

    Sub DsSet()
        DB_OPEN("best_wrn")

        '区分
        strSQL = "SELECT CLS_CODE.*"
        strSQL = strSQL & " FROM CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList2, "CLS_CODE")

        '保険会社期間区分
        strSQL = "SELECT insurance_co_decision.*"
        strSQL = strSQL & " FROM insurance_co_decision"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList2, "insurance_co_decision")

        '店舗
        strSQL = "SELECT shop_code, [店舗名(漢字)], 会社GRP"
        strSQL = strSQL & " FROM Shop_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList2, "Shop_mtr")

        'メーカー
        strSQL = "SELECT vdr_code, vdr_name"
        strSQL = strSQL & " FROM vdr_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList2, "vdr_mtr")

        '旧メーカー
        strSQL = "SELECT vdr_mtr2.*"
        strSQL = strSQL & " FROM vdr_mtr2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList2, "vdr_mtr2")

        '品種
        strSQL = "SELECT cd12, [品種名(漢字)]"
        strSQL = strSQL & " FROM Cat_mtr"
        strSQL = strSQL & " WHERE (cd3 = '00')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList2, "Cat_mtr")

        DB_CLOSE()
    End Sub

    Sub DateSet()
        WK_DtView1 = New DataView(DsList2.Tables("CLS_CODE"), "CLS_NO='999' AND CLS_CODE='0'", "CLS_CODE_NAME", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            Label6.Text = DateAdd(DateInterval.Month, 1, CDate(Trim(WK_DtView1(0)("CLS_CODE_NAME"))))
        Else
            Label6.Text = Year(Now) & "/" & Month(Now) & "/20"
        End If
        Date1.Text = Format(CDate(Label6.Text), "yyyy.MM")
        Label16.Text = Label6.Text
        Date2.Text = Format(CDate(Label16.Text), "yyyy.MM")
    End Sub

    Sub CmbSet()
        DB_OPEN("best_wrn")

        '処理日
        strSQL = "SELECT '20' + SUBSTRING(A_Data, 4, 2) + '/' + SUBSTRING(A_Data, 6, 2) + '/' + SUBSTRING(A_Data, 8, 2) AS proc_date"
        strSQL = strSQL & " FROM inp_log"
        strSQL = strSQL & " ORDER BY A_Data DESC"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "inp_log")

        ComboBox1.DataSource = DsCMB.Tables("inp_log")
        ComboBox1.DisplayMember = "proc_date"
        ComboBox1.ValueMember = "proc_date"

        Label12.Text = Mid(ComboBox1.Text, 1, 4) & Mid(ComboBox1.Text, 6, 2) & Mid(ComboBox1.Text, 9, 2)

        DB_CLOSE()
    End Sub

    '入力後
    Private Sub Date1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.Leave
        Label6.Text = Mid(Date1.Text, 1, 4) & "/" & Mid(Date1.Text, 6, 2) & "/20"
    End Sub

    Private Sub Date2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.Leave
        Label16.Text = Mid(Date2.Text, 1, 4) & "/" & Mid(Date2.Text, 6, 2) & "/20"
    End Sub

    '正常リスト（加入データと合致した正常データ）
    Sub normal_data()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "正常リスト分データ出力実行中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        DsExp.Clear()
        strSQL = "SELECT Wrn_ivc.*, Wrn_sub.prch_date"
        strSQL = strSQL & " FROM Wrn_ivc LEFT OUTER JOIN"
        strSQL = strSQL & " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND"
        strSQL = strSQL & " Wrn_ivc.line_no = Wrn_sub.line_no AND Wrn_ivc.seq = Wrn_sub.seq"
        strSQL = strSQL & " WHERE (Wrn_ivc.imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        strSQL = strSQL & " AND (Wrn_ivc.inp_seq IS NULL)"
        strSQL = strSQL & " ORDER BY Wrn_ivc.ordr_no, Wrn_ivc.line_no, Wrn_ivc.seq"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()
        DtTbl1 = DsExp.Tables("Wrn_ivc")

        'strFile = "\ivc_" & Format(CDate(ComboBox1.Text), "yyyyMMdd") & "_1.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "保証番号,行番号,SEQ,請求番号,承認番号,事故日,事故場所,事故状況フラグ,項目有無フラグ,全損フラグ,修理品購入店,修理受付店,修理完了店,伝票区分,修理伝票番号,顧客名,電話番号,メーカー名,品種,型式,修理品製造番号,修理受付日,修理完了日,出張料,作業料,部品料計,値引き額,請求除外金額,請求額,見積額,修理番号,処理日,請求区分,掛種コード,余白,保険会社コード,証券番号,取消フラグ,取消日,購入日"
        sw.WriteLine(strData)

        If DtTbl1.Rows.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtTbl1.Rows.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtTbl1.Rows.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtTbl1.Rows.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtTbl1.Rows.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtTbl1.Rows.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = DtTbl1.Rows(i)("ordr_no")
                strData = strData & "," & DtTbl1.Rows(i)("line_no")
                strData = strData & "," & DtTbl1.Rows(i)("seq")
                strData = strData & "," & DtTbl1.Rows(i)("FLD002")
                strData = strData & "," & DtTbl1.Rows(i)("FLD004")
                strData = strData & "," & DtTbl1.Rows(i)("FLD005")
                strData = strData & "," & DtTbl1.Rows(i)("FLD006")
                strData = strData & "," & DtTbl1.Rows(i)("FLD007")
                strData = strData & "," & DtTbl1.Rows(i)("FLD008")
                strData = strData & "," & DtTbl1.Rows(i)("FLD009")
                strData = strData & "," & DtTbl1.Rows(i)("FLD010")
                strData = strData & "," & DtTbl1.Rows(i)("FLD011")
                strData = strData & "," & DtTbl1.Rows(i)("FLD012")
                strData = strData & "," & DtTbl1.Rows(i)("FLD013")
                strData = strData & "," & DtTbl1.Rows(i)("FLD014")
                strData = strData & "," & DtTbl1.Rows(i)("FLD015")
                strData = strData & "," & DtTbl1.Rows(i)("FLD016")
                strData = strData & "," & DtTbl1.Rows(i)("FLD017")
                strData = strData & "," & DtTbl1.Rows(i)("FLD018")
                strData = strData & "," & DtTbl1.Rows(i)("FLD019")
                strData = strData & "," & DtTbl1.Rows(i)("FLD020")
                strData = strData & "," & DtTbl1.Rows(i)("FLD021")
                strData = strData & "," & DtTbl1.Rows(i)("FLD022")
                strData = strData & "," & DtTbl1.Rows(i)("FLD023")
                strData = strData & "," & DtTbl1.Rows(i)("FLD024")
                strData = strData & "," & DtTbl1.Rows(i)("FLD025")
                strData = strData & "," & DtTbl1.Rows(i)("FLD026")
                strData = strData & "," & DtTbl1.Rows(i)("FLD027")
                strData = strData & "," & DtTbl1.Rows(i)("FLD028")
                strData = strData & "," & DtTbl1.Rows(i)("FLD029")
                strData = strData & "," & DtTbl1.Rows(i)("FLD030")
                strData = strData & "," & DtTbl1.Rows(i)("FLD031")
                strData = strData & "," & DtTbl1.Rows(i)("FLD032")
                strData = strData & "," & DtTbl1.Rows(i)("FLD033")
                strData = strData & "," & DtTbl1.Rows(i)("FLD034")
                DtView1 = New DataView(DsList2.Tables("insurance_co_decision"), "kbn_No = '" & DtTbl1.Rows(i)("kbn_No") & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    strData = strData & "," & DtView1(0)("insurance_code")
                    strData = strData & "," & DtView1(0)("Securities_no")
                Else
                    strData = strData & ", "
                    strData = strData & ", "
                End If
                strData = strData & "," & DtTbl1.Rows(i)("Cancel_flg")
                strData = strData & "," & DtTbl1.Rows(i)("Cancel_date")

                If Not IsDBNull(DtTbl1.Rows(i)("prch_date")) Then
                    strData = strData & "," & DtTbl1.Rows(i)("prch_date")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtTbl1.Rows(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtTbl1.Rows(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView1 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView1.Count <> 0 Then
                        strData = strData & "," & DtView1(0)("prch_date")
                    Else
                        strData = strData & ","
                    End If
                End If

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "ivc_" & Format(CDate(ComboBox1.Text), "yyyyMMdd") & "_1.csv"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    '不備リスト1（加入データと保証番号が一致しないデータ）
    Sub Deficiency_data1()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "不備リスト1データ出力実行中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                              ' メッセージ処理を促して表示を更新する

        DsExp.Clear()
        strSQL = "SELECT Error_data_ivc.*"
        strSQL = strSQL & " FROM Error_data_ivc"
        strSQL = strSQL & " WHERE (imp_date  = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        strSQL = strSQL & " AND (Error_no <= '02') AND (Fixed_flg = '0')"
        strSQL = strSQL & " ORDER BY FLD012, ordr_no"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Error_data_ivc")
        DB_CLOSE()
        DtTbl1 = DsExp.Tables("Error_data_ivc")

        'strFile = "\ivc_" & Format(CDate(ComboBox1.Text), "yyyyMMdd") & "_2.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp2", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "保証番号,請求番号,承認番号,事故日,事故場所,事故状況フラグ,項目有無フラグ,全損フラグ,修理品購入店,修理受付店,修理完了店,伝票区分,修理伝票番号,顧客名,電話番号,メーカー名,品種,型式,修理品製造番号,修理受付日,修理完了日,出張料,作業料,部品料計,値引き額,請求除外金額,請求額,見積額,修理番号,処理日,請求区分,掛種コード,余白,エラー内容"
        sw.WriteLine(strData)

        If DtTbl1.Rows.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtTbl1.Rows.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtTbl1.Rows.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtTbl1.Rows.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtTbl1.Rows.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtTbl1.Rows.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = DtTbl1.Rows(i)("ordr_no")
                strData = strData & "," & DtTbl1.Rows(i)("FLD002")
                strData = strData & "," & DtTbl1.Rows(i)("FLD004")
                strData = strData & "," & DtTbl1.Rows(i)("FLD005")
                strData = strData & "," & DtTbl1.Rows(i)("FLD006")
                strData = strData & "," & DtTbl1.Rows(i)("FLD007")
                strData = strData & "," & DtTbl1.Rows(i)("FLD008")
                strData = strData & "," & DtTbl1.Rows(i)("FLD009")
                strData = strData & "," & DtTbl1.Rows(i)("FLD010")
                strData = strData & "," & DtTbl1.Rows(i)("FLD011")
                strData = strData & "," & DtTbl1.Rows(i)("FLD012")
                strData = strData & "," & DtTbl1.Rows(i)("FLD013")
                strData = strData & "," & DtTbl1.Rows(i)("FLD014")
                strData = strData & "," & DtTbl1.Rows(i)("FLD015")
                strData = strData & "," & DtTbl1.Rows(i)("FLD016")
                strData = strData & "," & DtTbl1.Rows(i)("FLD017")
                strData = strData & "," & DtTbl1.Rows(i)("FLD018")
                strData = strData & "," & DtTbl1.Rows(i)("FLD019")
                strData = strData & "," & DtTbl1.Rows(i)("FLD020")
                strData = strData & "," & DtTbl1.Rows(i)("FLD021")
                strData = strData & "," & DtTbl1.Rows(i)("FLD022")
                strData = strData & "," & DtTbl1.Rows(i)("FLD023")
                strData = strData & "," & DtTbl1.Rows(i)("FLD024")
                strData = strData & "," & DtTbl1.Rows(i)("FLD025")
                strData = strData & "," & DtTbl1.Rows(i)("FLD026")
                strData = strData & "," & DtTbl1.Rows(i)("FLD027")
                strData = strData & "," & DtTbl1.Rows(i)("FLD028")
                strData = strData & "," & DtTbl1.Rows(i)("FLD029")
                strData = strData & "," & DtTbl1.Rows(i)("FLD030")
                strData = strData & "," & DtTbl1.Rows(i)("FLD031")
                strData = strData & "," & DtTbl1.Rows(i)("FLD032")
                strData = strData & "," & DtTbl1.Rows(i)("FLD033")
                strData = strData & "," & DtTbl1.Rows(i)("FLD034")
                strData = strData & "," & DtTbl1.Rows(i)("error_msg")
                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "ivc_" & Format(CDate(ComboBox1.Text), "yyyyMMdd") & "_2.csv"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp2")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp2") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    '不備リスト2（加入データと保証番号は一致するが他の照合項目が一致しないデータ）
    Sub Deficiency_data2()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "不備リスト2データ出力実行中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                              ' メッセージ処理を促して表示を更新する

        DsExp.Clear()
        strSQL = "SELECT Error_data_ivc.*, Wrn_sub.prch_date"
        strSQL = strSQL & " FROM Error_data_ivc LEFT OUTER JOIN"
        strSQL = strSQL & " Wrn_sub ON Error_data_ivc.ordr_no = Wrn_sub.ordr_no AND"
        strSQL = strSQL & " Error_data_ivc.line_no = Wrn_sub.line_no AND"
        strSQL = strSQL & " Error_data_ivc.seq = Wrn_sub.seq"
        strSQL = strSQL & " WHERE (Error_data_ivc.imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        strSQL = strSQL & " AND (Error_data_ivc.Error_no >= '03') AND (Fixed_flg = '0')"
        strSQL = strSQL & " ORDER BY Error_data_ivc.FLD012, Error_data_ivc.ordr_no"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Error_data_ivc")
        DB_CLOSE()
        DtTbl1 = DsExp.Tables("Error_data_ivc")

        'strFile = "\ivc_" & Format(CDate(ComboBox1.Text), "yyyyMMdd") & "_3.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp3", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "保証番号,請求番号,承認番号,事故日,事故場所,事故状況フラグ,項目有無フラグ,全損フラグ,修理品購入店,修理受付店,修理完了店,伝票区分,修理伝票番号,顧客名,電話番号,メーカー名,品種,型式,修理品製造番号,修理受付日,修理完了日,出張料,作業料,部品料計,値引き額,請求除外金額,請求額,見積額,修理番号,処理日,請求区分,掛種コード,余白,購入日,エラー内容"
        sw.WriteLine(strData)

        If DtTbl1.Rows.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtTbl1.Rows.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtTbl1.Rows.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtTbl1.Rows.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtTbl1.Rows.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtTbl1.Rows.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = DtTbl1.Rows(i)("ordr_no")
                strData = strData & "," & DtTbl1.Rows(i)("FLD002")
                strData = strData & "," & DtTbl1.Rows(i)("FLD004")
                strData = strData & "," & DtTbl1.Rows(i)("FLD005")
                strData = strData & "," & DtTbl1.Rows(i)("FLD006")
                strData = strData & "," & DtTbl1.Rows(i)("FLD007")
                strData = strData & "," & DtTbl1.Rows(i)("FLD008")
                strData = strData & "," & DtTbl1.Rows(i)("FLD009")
                strData = strData & "," & DtTbl1.Rows(i)("FLD010")
                strData = strData & "," & DtTbl1.Rows(i)("FLD011")
                strData = strData & "," & DtTbl1.Rows(i)("FLD012")
                strData = strData & "," & DtTbl1.Rows(i)("FLD013")
                strData = strData & "," & DtTbl1.Rows(i)("FLD014")
                strData = strData & "," & DtTbl1.Rows(i)("FLD015")
                strData = strData & "," & DtTbl1.Rows(i)("FLD016")
                strData = strData & "," & DtTbl1.Rows(i)("FLD017")
                strData = strData & "," & DtTbl1.Rows(i)("FLD018")
                strData = strData & "," & DtTbl1.Rows(i)("FLD019")
                strData = strData & "," & DtTbl1.Rows(i)("FLD020")
                strData = strData & "," & DtTbl1.Rows(i)("FLD021")
                strData = strData & "," & DtTbl1.Rows(i)("FLD022")
                strData = strData & "," & DtTbl1.Rows(i)("FLD023")
                strData = strData & "," & DtTbl1.Rows(i)("FLD024")
                strData = strData & "," & DtTbl1.Rows(i)("FLD025")
                strData = strData & "," & DtTbl1.Rows(i)("FLD026")
                strData = strData & "," & DtTbl1.Rows(i)("FLD027")
                strData = strData & "," & DtTbl1.Rows(i)("FLD028")
                strData = strData & "," & DtTbl1.Rows(i)("FLD029")
                strData = strData & "," & DtTbl1.Rows(i)("FLD030")
                strData = strData & "," & DtTbl1.Rows(i)("FLD031")
                strData = strData & "," & DtTbl1.Rows(i)("FLD032")
                strData = strData & "," & DtTbl1.Rows(i)("FLD033")
                strData = strData & "," & DtTbl1.Rows(i)("FLD034")

                If Not IsDBNull(DtTbl1.Rows(i)("prch_date")) Then
                    strData = strData & "," & DtTbl1.Rows(i)("prch_date")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtTbl1.Rows(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtTbl1.Rows(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView1 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView1.Count <> 0 Then
                        strData = strData & "," & DtView1(0)("prch_date")
                    Else
                        strData = strData & ","
                    End If
                End If

                strData = strData & "," & DtTbl1.Rows(i)("error_msg")
                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "ivc_" & Format(CDate(ComboBox1.Text), "yyyyMMdd") & "_3.csv"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp3")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp3") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub best_data()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "ベスト電器分データ出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        Application.DoEvents()                              ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_4", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄ電器.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                strData = strData & "," & DtView1(i)("FLD015")
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄ電器.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub best_S_data()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "ベストサービス分データ出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        waitDlg.ProgressValue = 0                               ' 最初の件数を設定
        waitDlg.Text = "実行中・・・"
        Application.DoEvents()                                  ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_5", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄｻｰﾋﾞｽ.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp2", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                strData = strData & "," & DtView1(i)("FLD015")
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄｻｰﾋﾞｽ.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp2")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp2") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub kakoi_data()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "カコイエレクトロ分データ出力実行中"      ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        waitDlg.ProgressValue = 0                                   ' 最初の件数を設定
        waitDlg.Text = "実行中・・・"
        Application.DoEvents()                                      ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_6", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ｶｺｲｴﾚｸﾄﾛ.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp3", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                strData = strData & "," & DtView1(i)("FLD015")
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ｶｺｲｴﾚｸﾄﾛ.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp3")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp3") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub best_data2()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "ベスト電器分データ(ACE,BPS)出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        Application.DoEvents()                              ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_11", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_14", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄ電器_ACE_BPS.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                strData = strData & "," & DtView1(i)("FLD015")
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄ電器_ACE_BPS.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp3") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub best_S_data2()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "ベストサービス分データ(ACE,BPS)出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        waitDlg.ProgressValue = 0                               ' 最初の件数を設定
        waitDlg.Text = "実行中・・・"
        Application.DoEvents()                                  ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_12", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_15", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄｻｰﾋﾞｽ_ACE_BPS.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp2", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                strData = strData & "," & DtView1(i)("FLD015")
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄｻｰﾋﾞｽ_ACE_BPS.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp2")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp2") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub kakoi_data2()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "カコイエレクトロ分データ(ACE,BPS)出力実行中"      ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        waitDlg.ProgressValue = 0                                   ' 最初の件数を設定
        waitDlg.Text = "実行中・・・"
        Application.DoEvents()                                      ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_13", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_16", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ｶｺｲｴﾚｸﾄﾛ_ACE_BPS.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp3", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                strData = strData & "," & DtView1(i)("FLD015")
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ｶｺｲｴﾚｸﾄﾛ_ACE_BPS.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp3")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp3") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub best_data3()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "ベスト電器分データ(ACE,BPS)出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        Application.DoEvents()                              ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_31", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_34", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄ電器_ACE_BPS_J_RE.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                If Mid(DtView1(i)("kbn_No"), 1, 2) = "BZ" Or Mid(DtView1(i)("kbn_No"), 1, 2) = "BD" Then
                    WKstr = Trim(DtView1(i)("FLD015")) & " J"
                    strData = strData & "," & WKstr.PadRight(30, " ")
                Else
                    strData = strData & "," & DtView1(i)("FLD015")
                End If
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄ電器_ACE_BPS_J_RE.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub best_S_data3()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "ベストサービス分データ(ACE,BPS)出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        waitDlg.ProgressValue = 0                               ' 最初の件数を設定
        waitDlg.Text = "実行中・・・"
        Application.DoEvents()                                  ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_32", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_35", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄｻｰﾋﾞｽ_ACE_BPS_J_RE.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp2", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                If Mid(DtView1(i)("kbn_No"), 1, 2) = "BZ" Or Mid(DtView1(i)("kbn_No"), 1, 2) = "BD" Then
                    WKstr = Trim(DtView1(i)("FLD015")) & " J"
                    strData = strData & "," & WKstr.PadRight(30, " ")
                Else
                    strData = strData & "," & DtView1(i)("FLD015")
                End If
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄｻｰﾋﾞｽ_ACE_BPS_J_RE.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp2")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp2") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub kakoi_data3()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "カコイエレクトロ分データ(ACE,BPS)出力実行中"      ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        waitDlg.ProgressValue = 0                                   ' 最初の件数を設定
        waitDlg.Text = "実行中・・・"
        Application.DoEvents()                                      ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_33", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_36", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ｶｺｲｴﾚｸﾄﾛ_ACE_BPS_J_RE.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp3", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                If Mid(DtView1(i)("kbn_No"), 1, 2) = "BZ" Or Mid(DtView1(i)("kbn_No"), 1, 2) = "BD" Then
                    WKstr = Trim(DtView1(i)("FLD015")) & " J"
                    strData = strData & "," & WKstr.PadRight(30, " ")
                Else
                    strData = strData & "," & DtView1(i)("FLD015")
                End If
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ｶｺｲｴﾚｸﾄﾛ_ACE_BPS_J_RE.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp3")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp3") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub best_data4()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "ベスト電器分データ(ACE,BPS)出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        Application.DoEvents()                              ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_41", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_44", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄ電器_ACE_BPS_J_nRE.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                If Mid(DtView1(i)("kbn_No"), 1, 2) = "BZ" Or Mid(DtView1(i)("kbn_No"), 1, 2) = "BD" Then
                    WKstr = Trim(DtView1(i)("FLD015")) & " J"
                    strData = strData & "," & WKstr.PadRight(30, " ")
                Else
                    strData = strData & "," & DtView1(i)("FLD015")
                End If
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄ電器_ACE_BPS_J_nRE.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub best_S_data4()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "ベストサービス分データ(ACE,BPS)出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        waitDlg.ProgressValue = 0                               ' 最初の件数を設定
        waitDlg.Text = "実行中・・・"
        Application.DoEvents()                                  ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_42", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_45", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄｻｰﾋﾞｽ_ACE_BPS_J_nRE.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp2", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                If Mid(DtView1(i)("kbn_No"), 1, 2) = "BZ" Or Mid(DtView1(i)("kbn_No"), 1, 2) = "BD" Then
                    WKstr = Trim(DtView1(i)("FLD015")) & " J"
                    strData = strData & "," & WKstr.PadRight(30, " ")
                Else
                    strData = strData & "," & DtView1(i)("FLD015")
                End If
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ﾍﾞｽﾄｻｰﾋﾞｽ_ACE_BPS_J_nRE.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp2")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp2") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp2", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp2") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub kakoi_data4()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "カコイエレクトロ分データ(ACE,BPS)出力実行中"      ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        waitDlg.ProgressValue = 0                                   ' 最初の件数を設定
        waitDlg.Text = "実行中・・・"
        Application.DoEvents()                                      ' メッセージ処理を促して表示を更新する

        '現在分
        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_43", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram1.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '過去分
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_46", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Pram2.Value = Label6.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ｶｺｲｴﾚｸﾄﾛ_ACE_BPS_J_nRE.CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp3", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "区分,証券番号,加入日,購入日,保証番号,保証番号(上12桁),顧客名,商品ｺｰﾄﾞ,ﾒｰｶｰ名,購入価格,型式,製造番号,受付日,事故日,場所,状況,全損,保証限度額,請求額,消費税,承認番号,修理伝票番号,完了店舗ｺｰﾄﾞ,完了店舗名"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "Securities_no,ordr_no", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    WK_prch_date = DtView1(i)("prch_date")
                    WK_prch_price = DtView1(i)("prch_price")
                Else
                    DsList1.Clear()
                    strSQL = "SELECT prch_date, prch_price"
                    strSQL = strSQL & " FROM wrn_data"
                    strSQL = strSQL & " WHERE (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList1, "Wrn_sub")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        WK_prch_date = DtView2(0)("prch_date")
                        WK_prch_price = DtView2(0)("prch_price")
                    Else
                        WK_prch_date = Nothing
                        WK_prch_price = Nothing
                    End If
                End If

                If Not IsDBNull(DtView1(i)("vdr_name")) Then
                    WK_vdr_name = DtView1(i)("vdr_name")
                Else
                    If Not IsDBNull(DtView1(i)("vdr_name2")) Then
                        WK_vdr_name = DtView1(i)("vdr_name2")
                    Else
                        WK_vdr_name = DtView1(i)("FLD017")
                    End If
                End If

                strData = DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Securities_no")
                strData = strData & "," & WK_prch_date
                strData = strData & ","
                strData = strData & "," & DtView1(i)("ordr_no")
                strData = strData & "," & Mid(DtView1(i)("ordr_no"), 1, 12)
                If Mid(DtView1(i)("kbn_No"), 1, 2) = "BZ" Or Mid(DtView1(i)("kbn_No"), 1, 2) = "BD" Then
                    WKstr = Trim(DtView1(i)("FLD015")) & " J"
                    strData = strData & "," & WKstr.PadRight(30, " ")
                Else
                    strData = strData & "," & DtView1(i)("FLD015")
                End If
                strData = strData & "," & DtView1(i)("FLD018")
                strData = strData & "," & WK_vdr_name
                strData = strData & "," & WK_prch_price
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD005")
                strData = strData & "," & DtView1(i)("FLD006")
                strData = strData & "," & DtView1(i)("FLD007")
                strData = strData & "," & DtView1(i)("FLD009")
                strData = strData & "," & DtView1(i)("Limit_money")
                strData = strData & "," & DtView1(i)("請求額")
                strData = strData & "," & DtView1(i)("TAX")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD012")
                strData = strData & "," & DtView1(i)("店舗名(ｶﾅ)")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "請求明細" & Format(CDate(Label6.Text), "yyyyMM") & "_ｶｺｲｴﾚｸﾄﾛ_ACE_BPS_J_nRE.CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp3")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp3") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp3", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp3") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub one_year()
        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        waitDlg.MainMsg = "１年超データ出力実行中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"
        Application.DoEvents()                              ' メッセージ処理を促して表示を更新する
        Dim p_date As Date

        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_export_21", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime, 8)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime, 8)
        Pram1.Value = Label16.Text
        p_date = DateAdd(DateInterval.Year, -1, CDate(Label16.Text))
        p_date = Year(p_date) & "/" & Month(p_date) & "/01"
        Pram2.Value = DateAdd(DateInterval.Day, -1, p_date)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        'strFile = "\１年超" & Format(CDate(Label6.Text), "yyyyMM") & ".CSV"
        'Dim swFile As New System.IO.StreamWriter(strFLD & strFile, False, System.Text.Encoding.Default)
        'swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        'データを書き込む
        strData = "証券番号,行No,SEQ,請求番号,承認番号,事故日,事故場所,事故状況,項目有無,全損,購入店舗,会社グループ,修理受付店舗,修理完了店舗,伝票区分,修理伝票番号,顧客名,電話番号,メーカー,品種,型式,製造番号,受付日,完了日,出張料,作業料,部品料計,値引き額,請求除外金額,請求額,見積額,修理番号,処理日,請求区分,掛種,期間区分,保証限度額,手入力SEQ"
        sw.WriteLine(strData)

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)

        If DtView1.Count <> 0 Then
            prc_cnt = 0
            waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = DtView1(i)("ordr_no")
                strData = strData & "," & DtView1(i)("line_no")
                strData = strData & "," & DtView1(i)("seq")
                strData = strData & "," & DtView1(i)("FLD002")
                strData = strData & "," & DtView1(i)("FLD004")
                strData = strData & "," & DtView1(i)("FLD005")
                WK_DtView1 = New DataView(DsList2.Tables("CLS_CODE"), "CLS_NO='001' AND CLS_CODE='" & DtView1(i)("FLD006") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("CLS_CODE_NAME"))
                Else
                    strData = strData & ","
                End If
                WK_DtView1 = New DataView(DsList2.Tables("CLS_CODE"), "CLS_NO='002' AND CLS_CODE='" & DtView1(i)("FLD007") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("CLS_CODE_NAME"))
                Else
                    strData = strData & ","
                End If
                WK_DtView1 = New DataView(DsList2.Tables("CLS_CODE"), "CLS_NO='003' AND CLS_CODE='" & DtView1(i)("FLD008") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("CLS_CODE_NAME"))
                Else
                    strData = strData & ","
                End If
                WK_DtView1 = New DataView(DsList2.Tables("CLS_CODE"), "CLS_NO='004' AND CLS_CODE='" & DtView1(i)("FLD009") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("CLS_CODE_NAME"))
                Else
                    strData = strData & ","
                End If
                WK_DtView1 = New DataView(DsList2.Tables("Shop_mtr"), "shop_code='" & DtView1(i)("FLD010") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("店舗名(漢字)"))
                    strData = strData & "," & RTrim(WK_DtView1(0)("会社GRP"))
                Else
                    strData = strData & ",,"
                End If
                WK_DtView1 = New DataView(DsList2.Tables("Shop_mtr"), "shop_code='" & DtView1(i)("FLD011") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("店舗名(漢字)"))
                Else
                    strData = strData & ","
                End If
                WK_DtView1 = New DataView(DsList2.Tables("Shop_mtr"), "shop_code='" & DtView1(i)("FLD012") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("店舗名(漢字)"))
                Else
                    strData = strData & ","
                End If
                WK_DtView1 = New DataView(DsList2.Tables("CLS_CODE"), "CLS_NO='005' AND CLS_CODE='" & DtView1(i)("FLD013") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("CLS_CODE_NAME"))
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("FLD014")
                strData = strData & "," & DtView1(i)("FLD015")
                strData = strData & "," & DtView1(i)("FLD016")
                WK_DtView1 = New DataView(DsList2.Tables("vdr_mtr"), "vdr_code='" & DtView1(i)("FLD017") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("vdr_name"))
                Else
                    WK_DtView1 = New DataView(DsList2.Tables("vdr_mtr2"), "vdr_code='" & DtView1(i)("FLD017") & "'", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        strData = strData & "," & RTrim(WK_DtView1(0)("vdr_kana"))
                    Else
                        strData = strData & ","
                    End If
                End If
                WK_DtView1 = New DataView(DsList2.Tables("Cat_mtr"), "cd12='" & DtView1(i)("FLD018") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("品種名(漢字)"))
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("FLD019")
                strData = strData & "," & DtView1(i)("FLD020")
                strData = strData & "," & DtView1(i)("FLD021")
                strData = strData & "," & DtView1(i)("FLD022")
                strData = strData & "," & DtView1(i)("FLD023")
                strData = strData & "," & DtView1(i)("FLD024")
                strData = strData & "," & DtView1(i)("FLD025")
                strData = strData & "," & DtView1(i)("FLD026")
                strData = strData & "," & DtView1(i)("FLD027")
                strData = strData & "," & DtView1(i)("FLD028")
                strData = strData & "," & DtView1(i)("FLD029")
                strData = strData & "," & DtView1(i)("FLD030")
                strData = strData & "," & DtView1(i)("FLD031")
                WK_DtView1 = New DataView(DsList2.Tables("CLS_CODE"), "CLS_NO='007' AND CLS_CODE='" & DtView1(i)("FLD032") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("CLS_CODE_NAME"))
                Else
                    strData = strData & ","
                End If
                WK_DtView1 = New DataView(DsList2.Tables("CLS_CODE"), "CLS_NO='008' AND CLS_CODE='" & DtView1(i)("FLD033") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    strData = strData & "," & RTrim(WK_DtView1(0)("CLS_CODE_NAME"))
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("kbn_No")
                strData = strData & "," & DtView1(i)("Limit_money")

                strData = strData & "," & DtView1(i)("inp_seq")

                sw.WriteLine(strData)
            Next
        End If
        sw.Close()  'ファイルを閉じる

        '［名前を付けて保存］ダイアログボックスを表示
        SaveFileDialog1.FileName = "１年超" & Format(CDate(Label6.Text), "yyyyMM") & ".CSV"
        SaveFileDialog1.Filter = "CSVファイル|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp3") = False Then
                MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    '受信データXLS
    Sub XLS1()

        '延長修理OK分
        waitDlg.MainMsg = "延長修理OK分"            ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()
        '旧加入分
        strSQL = "SELECT Wrn_ivc.kbn_No AS 区分, Wrn_ivc.ordr_no AS 保証番号, Wrn_ivc.line_no AS 行番号"
        strSQL = strSQL & ", Wrn_sub.prch_date AS 購入日, Wrn_ivc.FLD007 AS 事故状況"
        strSQL = strSQL & ", Wrn_ivc.FLD012 AS 完了店CD, Shop_mtr.[店舗名(漢字)] AS 完了店名"
        strSQL = strSQL & ", Wrn_ivc.FLD014 AS 修理伝票番号, Wrn_ivc.FLD020 AS 製造番号"
        strSQL = strSQL & ", Wrn_ivc.FLD015 AS 顧客名, Wrn_ivc.FLD019 AS 型式"
        strSQL = strSQL & ", Wrn_ivc.FLD028 AS 請求額, insurance_co_decision.insurance_code AS 保険会社"
        strSQL = strSQL & ", '' AS 状況, '' AS 処理日"
        strSQL = strSQL & " FROM Wrn_ivc LEFT OUTER JOIN"
        strSQL = strSQL & " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND"
        strSQL = strSQL & " Wrn_ivc.line_no = Wrn_sub.line_no AND"
        strSQL = strSQL & " Wrn_ivc.seq = Wrn_sub.seq LEFT OUTER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code LEFT OUTER JOIN"
        strSQL = strSQL & " insurance_co_decision ON"
        strSQL = strSQL & " Wrn_ivc.kbn_No = insurance_co_decision.kbn_No"
        strSQL = strSQL & " WHERE (Wrn_ivc.imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        strSQL = strSQL & " AND (Wrn_ivc.inp_seq IS NULL)"
        strSQL = strSQL & " AND (Wrn_ivc.FLD007 = N'0')"
        strSQL = strSQL & " AND (Wrn_sub.prch_date IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '旧加入分の購入日をSET
        WK_DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_DsList1.Clear()
                strSQL = "SELECT prch_date FROM wrn_data"
                strSQL = strSQL & " WHERE (ordr_no = '" & WK_DtView1(i)("保証番号") & "')"
                strSQL = strSQL & " AND (line_no = '" & WK_DtView1(i)("行番号") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("best_wrn_data2")
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "wrn_data")
                DB_CLOSE()
                WK_DtView2 = New DataView(WK_DsList1.Tables("wrn_data"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView2.Count <> 0 Then
                    If Not IsDBNull(WK_DtView2(0)("prch_date")) Then WK_DtView1(i)("購入日") = WK_DtView2(0)("prch_date")
                End If
            Next
        End If

        '現加入分
        strSQL = "SELECT Wrn_ivc.kbn_No AS 区分, Wrn_ivc.ordr_no AS 保証番号, Wrn_ivc.line_no AS 行番号"
        strSQL = strSQL & ", Wrn_sub.prch_date AS 購入日, Wrn_ivc.FLD007 AS 事故状況"
        strSQL = strSQL & ", Wrn_ivc.FLD012 AS 完了店CD, Shop_mtr.[店舗名(漢字)] AS 完了店名"
        strSQL = strSQL & ", Wrn_ivc.FLD014 AS 修理伝票番号, Wrn_ivc.FLD020 AS 製造番号"
        strSQL = strSQL & ", Wrn_ivc.FLD015 AS 顧客名, Wrn_ivc.FLD019 AS 型式"
        strSQL = strSQL & ", Wrn_ivc.FLD028 AS 請求額, insurance_co_decision.insurance_code AS 保険会社"
        strSQL = strSQL & ", '' AS 状況, '' AS 処理日"
        strSQL = strSQL & " FROM Wrn_ivc INNER JOIN"
        strSQL = strSQL & " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND"
        strSQL = strSQL & " Wrn_ivc.line_no = Wrn_sub.line_no AND"
        strSQL = strSQL & " Wrn_ivc.seq = Wrn_sub.seq LEFT OUTER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code LEFT OUTER JOIN"
        strSQL = strSQL & " insurance_co_decision ON"
        strSQL = strSQL & " Wrn_ivc.kbn_No = insurance_co_decision.kbn_No"
        strSQL = strSQL & " WHERE (Wrn_ivc.imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        strSQL = strSQL & " AND (Wrn_ivc.inp_seq IS NULL)"
        strSQL = strSQL & " AND (Wrn_ivc.FLD007 = N'0')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        ''テスト用
        'strSQL = "SELECT kbn_No AS 区分, ordr_no AS 保証番号, line_no AS 行番号, '2007/01/01' AS 購入日, FLD007 AS 事故状況, FLD012 AS 完了店CD, '店舗名' AS 完了店名, FLD014 AS 修理伝票番号, FLD020 AS 製造番号, FLD015 AS 顧客名, FLD019 AS 型式, FLD028 AS 請求額, 'NDI' AS 保険会社, '' AS 状況, '' AS 処理日"
        'strSQL = strSQL & " FROM Wrn_ivc"
        'strSQL = strSQL & " WHERE (FLD031 = CONVERT(DATETIME, '2007/05/26', 102)) AND (inp_seq IS NULL) AND (FLD007 = N'0') AND (ordr_no < '007152311253')"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("best_wrn")
        'SqlCmd1.CommandTimeout = 3600
        'DaList1.Fill(DsExp, "Wrn_ivc")
        'DB_CLOSE()

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "完了店CD, 顧客名, 保証番号", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        '完了店CDが変わったら件数と合計印字して、改ページ

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Add
        Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(1), Excel.Worksheet)
        Dim xlCells As Excel.Range
        Dim xlRange As Excel.Range = xlSheet.Rows

        xlCells = xlSheet.Cells
        xlRange = xlCells(1, 1) : xlRange.Value = "No." : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 2) : xlRange.Value = "区分" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 3) : xlRange.Value = "保証番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 4) : xlRange.Value = "顧客名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 5) : xlRange.Value = "製造番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 6) : xlRange.Value = "型式" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 7) : xlRange.Value = "請求額" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 8) : xlRange.Value = "購入日" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 9) : xlRange.Value = "事故状況" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 10) : xlRange.Value = "修理伝票番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 11) : xlRange.Value = "保険会社" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 12) : xlRange.Value = "修理完了店ｺｰﾄﾞ" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 13) : xlRange.Value = "修理完了店名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 14) : xlRange.Value = "状況" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 15) : xlRange.Value = "処理日" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)

        Dim shop_code As String
        Dim j, j2, k As Integer
        Dim Hs As Excel.HPageBreaks = xlSheet.HPageBreaks
        Dim H As Excel.HPageBreak

        j = 2   'セル行
        j2 = 2  '開始セル行/店舗
        k = 1   '件数/店舗
        prc_cnt = 0
        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If k <> 1 And DtView1(i)("完了店CD") <> shop_code Then   '店舗コード比較
                    xlRange = xlCells(j, 6) : xlRange.Value = k - 1 '合計件数セット
                    xlRange = xlCells(j, 7) : xlRange.Value = "=Sum(G" & j2 & ":G" & j2 + k - 2 & ")" : MRComObject(xlRange) '請求額合計セット
                    xlRange = xlCells(j + 1, 8)
                    H = Hs.Add(xlRange) '改行
                    j2 = j + 1  '開始セル行/店舗セット
                    j = j + 1
                    k = 1       '件数リセット
                End If

                xlRange = xlCells(j, 1) : xlRange.Value = k : MRComObject(xlRange) 'No.
                xlRange = xlCells(j, 2) : xlRange.Value = DtView1(i)("区分").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 3) : xlRange.Value = Chr(39) & DtView1(i)("保証番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 4) : xlRange.Value = DtView1(i)("顧客名").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 5) : xlRange.Value = Chr(39) & DtView1(i)("製造番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 6) : xlRange.Value = Chr(39) & DtView1(i)("型式").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 7) : xlRange.Value = Format(DtView1(i)("請求額"), "##0,00").ToString : MRComObject(xlRange)

                If IsDBNull(DtView1(i)("購入日")) = False Then
                    xlRange = xlCells(j, 8) : xlRange.Value = DtView1(i)("購入日") : MRComObject(xlRange)
                End If
                xlRange = xlCells(j, 9) : xlRange.Value = DtView1(i)("事故状況").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 10) : xlRange.Value = Chr(39) & DtView1(i)("修理伝票番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 11) : xlRange.Value = DtView1(i)("保険会社").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 12) : xlRange.Value = Chr(39) & DtView1(i)("完了店CD").ToString : MRComObject(xlRange)
                shop_code = DtView1(i)("完了店CD").ToString
                xlRange = xlCells(j, 13) : xlRange.Value = DtView1(i)("完了店名").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 14) : xlRange.Value = DtView1(i)("状況").ToString : MRComObject(xlRange)
                If IsDBNull(DtView1(i)("処理日")) = False Then
                    xlRange = xlCells(j, 15) : xlRange.Value = DtView1(i)("処理日") : MRComObject(xlRange)
                End If
                k = k + 1
                j = j + 1
            Next
            xlRange = xlCells(j, 6) : xlRange.Value = k - 1 '合計件数セット
            xlRange = xlCells(j, 7) : xlRange.Value = "=Sum(G" & j2 & ":G" & j2 + k - 2 & ")" : MRComObject(xlRange) '請求額合計セット

            '線を引く
            'xlRange = xlSheet.Range("A1:O" & j) : xlRange.Borders.LineStyle = 3
            xlRange = DirectCast(xlSheet.UsedRange, Excel.Range)
            xlRange.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 2
            xlRange.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 2
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange)

        End If

        xlCells.EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

        With xlSheet.PageSetup
            .PaperSize = Excel.XlPaperSize.xlPaperA4           '用紙サイズをＡ４
            .Orientation = Excel.XlPageOrientation.xlLandscape '横
            .Zoom = 75
            .PrintTitleRows = "$1:$1"

            .LeftMargin = xlApp.CentimetersToPoints(1)
            .RightMargin = xlApp.CentimetersToPoints(0.4)
            .TopMargin = xlApp.CentimetersToPoints(1.1)
            .BottomMargin = xlApp.CentimetersToPoints(0.8)
            .HeaderMargin = xlApp.CentimetersToPoints(0.6)
            .FooterMargin = xlApp.CentimetersToPoints(0.3)
        End With

        MRComObject(xlCells)

        'Me.Activate()
        'waitDlg.Close()

        '［名前を付けて保存］ダイアログボックスを表示
        'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
        SaveFileDialog1.FileName = "受信データ" & Label12.Text & "_1.xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
        Try
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            GoTo end_prc
        End Try

        Me.Enabled = True

        ' 終了処理　
        MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)              'xlApp を開放

end_prc:
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '受信データXLS
    Sub XLS2()

        '延長修理NG分
        waitDlg.MainMsg = "延長修理NG分"            ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()
        strSQL = "SELECT '' AS 区分, Error_data_ivc.ordr_no AS 保証番号, '' AS 行番号, NULL AS 購入日"
        strSQL = strSQL & ", Error_data_ivc.FLD007 AS 事故状況, Error_data_ivc.FLD012 AS 完了店CD"
        strSQL = strSQL & ", Shop_mtr.[店舗名(漢字)] AS 完了店名, Error_data_ivc.FLD014 AS 修理伝票番号"
        strSQL = strSQL & ", Error_data_ivc.FLD020 AS 製造番号, Error_data_ivc.FLD015 AS 顧客名"
        strSQL = strSQL & ", Error_data_ivc.FLD019 AS 型式, CONVERT(int, Error_data_ivc.FLD028) AS 請求額"
        strSQL = strSQL & ", '' AS 保険会社, Error_data_ivc.Error_msg AS 状況, '' AS 処理日"
        strSQL = strSQL & " FROM Error_data_ivc LEFT OUTER JOIN"
        strSQL = strSQL & " Shop_mtr ON Error_data_ivc.FLD012 = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (Error_data_ivc.FLD007 = '0')"
        strSQL = strSQL & " AND (Error_data_ivc.Fixed_flg <> '1')"
        strSQL = strSQL & " AND (Error_data_ivc.imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "完了店CD, 状況, 顧客名, 保証番号", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        '完了店CDが変わったら件数と合計印字して、改ページ

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        'xlApp.Visible = True
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Add
        Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(1), Excel.Worksheet)
        Dim xlCells As Excel.Range
        Dim xlRange As Excel.Range = xlSheet.Rows

        xlCells = xlSheet.Cells
        xlRange = xlCells(1, 1) : xlRange.Value = "No." : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 2) : xlRange.Value = "区分" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 3) : xlRange.Value = "保証番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 4) : xlRange.Value = "顧客名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 5) : xlRange.Value = "製造番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 6) : xlRange.Value = "型式" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 7) : xlRange.Value = "請求額" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 8) : xlRange.Value = "購入日" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 9) : xlRange.Value = "事故状況" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 10) : xlRange.Value = "修理伝票番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 11) : xlRange.Value = "保険会社" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 12) : xlRange.Value = "修理完了店ｺｰﾄﾞ" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 13) : xlRange.Value = "修理完了店名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 14) : xlRange.Value = "状況" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 15) : xlRange.Value = "処理日" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)

        Dim shop_code As String
        Dim j, j2, k As Integer
        Dim Hs As Excel.HPageBreaks = xlSheet.HPageBreaks
        Dim H As Excel.HPageBreak

        j = 2   'セル行
        j2 = 2  '開始セル行/店舗
        k = 1   '件数/店舗
        prc_cnt = 0
        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If k <> 1 And DtView1(i)("完了店CD") <> shop_code Then   '店舗コード比較
                    xlRange = xlCells(j, 6) : xlRange.Value = k - 1 '合計件数セット
                    xlRange = xlCells(j, 7) : xlRange.Value = "=Sum(G" & j2 & ":G" & j2 + k - 2 & ")" : MRComObject(xlRange) '請求額合計セット
                    xlRange = xlCells(j + 1, 8)
                    H = Hs.Add(xlRange) '改行
                    j2 = j + 1  '開始セル行/店舗セット
                    j = j + 1
                    k = 1       '件数リセット
                End If

                xlRange = xlCells(j, 1) : xlRange.Value = k : MRComObject(xlRange) 'No.
                xlRange = xlCells(j, 2) : xlRange.Value = DtView1(i)("区分").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 3) : xlRange.Value = Chr(39) & DtView1(i)("保証番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 4) : xlRange.Value = DtView1(i)("顧客名").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 5) : xlRange.Value = Chr(39) & DtView1(i)("製造番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 6) : xlRange.Value = Chr(39) & DtView1(i)("型式").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 7) : xlRange.Value = Format(DtView1(i)("請求額"), "##0,00").ToString : MRComObject(xlRange)

                If IsDBNull(DtView1(i)("購入日")) = False Then
                    xlRange = xlCells(j, 8) : xlRange.Value = DtView1(i)("購入日") : MRComObject(xlRange)
                End If
                xlRange = xlCells(j, 9) : xlRange.Value = DtView1(i)("事故状況").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 10) : xlRange.Value = Chr(39) & DtView1(i)("修理伝票番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 11) : xlRange.Value = DtView1(i)("保険会社").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 12) : xlRange.Value = Chr(39) & DtView1(i)("完了店CD").ToString : MRComObject(xlRange)
                shop_code = DtView1(i)("完了店CD").ToString
                xlRange = xlCells(j, 13) : xlRange.Value = DtView1(i)("完了店名").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 14) : xlRange.Value = DtView1(i)("状況").ToString : MRComObject(xlRange)
                If IsDBNull(DtView1(i)("処理日")) = False Then
                    xlRange = xlCells(j, 15) : xlRange.Value = DtView1(i)("処理日") : MRComObject(xlRange)
                End If
                k = k + 1
                j = j + 1
            Next

            xlRange = xlCells(j, 6) : xlRange.Value = k - 1 '合計件数セット
            xlRange = xlCells(j, 7) : xlRange.Value = "=Sum(G" & j2 & ":G" & j2 + k - 2 & ")" : MRComObject(xlRange) '請求額合計セット

            '線を引く
            'xlRange = xlSheet.Range("A1:O" & j) : xlRange.Borders.LineStyle = 3
            xlRange = DirectCast(xlSheet.UsedRange, Excel.Range)
            xlRange.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 2
            xlRange.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 2
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange)
        End If

        xlCells.EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

        With xlSheet.PageSetup
            .PaperSize = Excel.XlPaperSize.xlPaperA4           '用紙サイズをＡ４
            .Orientation = Excel.XlPageOrientation.xlLandscape '横
            .Zoom = 75
            .PrintTitleRows = "$1:$1"

            .LeftMargin = xlApp.CentimetersToPoints(1)
            .RightMargin = xlApp.CentimetersToPoints(0.4)
            .TopMargin = xlApp.CentimetersToPoints(1.1)
            .BottomMargin = xlApp.CentimetersToPoints(0.8)
            .HeaderMargin = xlApp.CentimetersToPoints(0.6)
            .FooterMargin = xlApp.CentimetersToPoints(0.3)
        End With
        MRComObject(xlCells)

        'Me.Activate()
        'waitDlg.Close()

        '［名前を付けて保存］ダイアログボックスを表示
        'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
        SaveFileDialog1.FileName = "受信データ" & Label12.Text & "_2.xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
        Try
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            GoTo end_prc
        End Try

        Me.Enabled = True

        ' 終了処理　
        MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)              'xlApp を開放

end_prc:
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    '受信データXLS
    Sub XLS3()

        '延長修理以外
        waitDlg.MainMsg = "延長修理以外"            ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()
        '旧加入分
        strSQL = "SELECT Wrn_ivc.kbn_No AS 区分, Wrn_ivc.ordr_no AS 保証番号, Wrn_ivc.line_no AS 行番号"
        strSQL = strSQL & ", Wrn_sub.prch_date AS 購入日, Wrn_ivc.FLD007 AS 事故状況"
        strSQL = strSQL & ", Wrn_ivc.FLD012 AS 完了店CD, Shop_mtr.[店舗名(漢字)] AS 完了店名"
        strSQL = strSQL & ", Wrn_ivc.FLD014 AS 修理伝票番号, Wrn_ivc.FLD020 AS 製造番号"
        strSQL = strSQL & ", Wrn_ivc.FLD015 AS 顧客名, Wrn_ivc.FLD019 AS 型式"
        strSQL = strSQL & ", Wrn_ivc.FLD028 AS 請求額, insurance_co_decision.insurance_code AS 保険会社"
        strSQL = strSQL & ", '' AS 状況, '' AS 処理日"
        strSQL = strSQL & " FROM Wrn_ivc LEFT OUTER JOIN"
        strSQL = strSQL & " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND"
        strSQL = strSQL & " Wrn_ivc.line_no = Wrn_sub.line_no AND"
        strSQL = strSQL & " Wrn_ivc.seq = Wrn_sub.seq LEFT OUTER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code LEFT OUTER JOIN"
        strSQL = strSQL & " insurance_co_decision ON"
        strSQL = strSQL & " Wrn_ivc.kbn_No = insurance_co_decision.kbn_No"
        strSQL = strSQL & " WHERE (Wrn_ivc.imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        strSQL = strSQL & " AND (Wrn_ivc.inp_seq IS NULL)"
        strSQL = strSQL & " AND (Wrn_ivc.FLD007 <> N'0')"
        strSQL = strSQL & " AND (Wrn_sub.prch_date IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        '旧加入分の購入日をSET
        WK_DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_DsList1.Clear()
                strSQL = "SELECT prch_date FROM wrn_data"
                strSQL = strSQL & " WHERE (ordr_no = '" & WK_DtView1(i)("保証番号") & "')"
                strSQL = strSQL & " AND (line_no = '" & WK_DtView1(i)("行番号") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("best_wrn_data2")
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "wrn_data")
                DB_CLOSE()
                WK_DtView2 = New DataView(WK_DsList1.Tables("wrn_data"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView2.Count <> 0 Then
                    If Not IsDBNull(WK_DtView2(0)("prch_date")) Then WK_DtView1(i)("購入日") = WK_DtView2(0)("prch_date")
                End If
            Next
        End If

        '現加入分
        strSQL = "SELECT Wrn_ivc.kbn_No AS 区分, Wrn_ivc.ordr_no AS 保証番号, Wrn_ivc.line_no AS 行番号"
        strSQL = strSQL & ", Wrn_sub.prch_date AS 購入日, Wrn_ivc.FLD007 AS 事故状況"
        strSQL = strSQL & ", Wrn_ivc.FLD012 AS 完了店CD, Shop_mtr.[店舗名(漢字)] AS 完了店名"
        strSQL = strSQL & ", Wrn_ivc.FLD014 AS 修理伝票番号, Wrn_ivc.FLD020 AS 製造番号"
        strSQL = strSQL & ", Wrn_ivc.FLD015 AS 顧客名, Wrn_ivc.FLD019 AS 型式"
        strSQL = strSQL & ", Wrn_ivc.FLD028 AS 請求額, insurance_co_decision.insurance_code AS 保険会社"
        strSQL = strSQL & ", '' AS 状況, '' AS 処理日"
        strSQL = strSQL & " FROM Wrn_ivc INNER JOIN"
        strSQL = strSQL & " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND"
        strSQL = strSQL & " Wrn_ivc.line_no = Wrn_sub.line_no AND"
        strSQL = strSQL & " Wrn_ivc.seq = Wrn_sub.seq LEFT OUTER JOIN"
        strSQL = strSQL & " Shop_mtr ON Wrn_ivc.FLD012 = Shop_mtr.shop_code LEFT OUTER JOIN"
        strSQL = strSQL & " insurance_co_decision ON"
        strSQL = strSQL & " Wrn_ivc.kbn_No = insurance_co_decision.kbn_No"
        strSQL = strSQL & " WHERE (Wrn_ivc.imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        strSQL = strSQL & " AND (Wrn_ivc.inp_seq IS NULL)"
        strSQL = strSQL & " AND (Wrn_ivc.FLD007 <> N'0')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        strSQL = "SELECT '' AS 区分, Error_data_ivc.ordr_no AS 保証番号, '' AS 行番号, NULL AS 購入日"
        strSQL = strSQL & ", Error_data_ivc.FLD007 AS 事故状況, Error_data_ivc.FLD012 AS 完了店CD"
        strSQL = strSQL & ", Shop_mtr.[店舗名(漢字)] AS 完了店名, Error_data_ivc.FLD014 AS 修理伝票番号"
        strSQL = strSQL & ", Error_data_ivc.FLD020 AS 製造番号, Error_data_ivc.FLD015 AS 顧客名"
        strSQL = strSQL & ", Error_data_ivc.FLD019 AS 型式, Error_data_ivc.FLD028 AS 請求額"
        strSQL = strSQL & ", '' AS 保険会社, Error_data_ivc.Error_msg AS 状況, '' AS 処理日"
        strSQL = strSQL & " FROM Error_data_ivc LEFT OUTER JOIN"
        strSQL = strSQL & " Shop_mtr ON Error_data_ivc.FLD012 = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (Error_data_ivc.FLD007 <> '0')"
        strSQL = strSQL & " AND (Error_data_ivc.Fixed_flg <> '1')"
        strSQL = strSQL & " AND (Error_data_ivc.imp_date = CONVERT(DATETIME, '" & ComboBox1.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsExp, "Wrn_ivc")
        DB_CLOSE()

        DtView1 = New DataView(DsExp.Tables("Wrn_ivc"), "", "完了店CD, 顧客名, 保証番号", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        '完了店CDが変わったら件数と合計印字して、改ページ

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        'xlApp.Visible = True
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Add
        Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
        Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(1), Excel.Worksheet)
        Dim xlCells As Excel.Range
        Dim xlRange As Excel.Range = xlSheet.Rows

        xlCells = xlSheet.Cells
        xlRange = xlCells(1, 1) : xlRange.Value = "No." : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 2) : xlRange.Value = "区分" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 3) : xlRange.Value = "保証番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 4) : xlRange.Value = "顧客名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 5) : xlRange.Value = "製造番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 6) : xlRange.Value = "型式" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 7) : xlRange.Value = "請求額" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 8) : xlRange.Value = "購入日" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 9) : xlRange.Value = "事故状況" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 10) : xlRange.Value = "修理伝票番号" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 11) : xlRange.Value = "保険会社" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 12) : xlRange.Value = "修理完了店ｺｰﾄﾞ" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 13) : xlRange.Value = "修理完了店名" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 14) : xlRange.Value = "状況" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)
        xlRange = xlCells(1, 15) : xlRange.Value = "処理日" : xlRange.Interior.Color = RGB(0, 255, 255) : MRComObject(xlRange)

        Dim shop_code As String
        Dim j, j2, k As Integer
        Dim Hs As Excel.HPageBreaks = xlSheet.HPageBreaks
        Dim H As Excel.HPageBreak

        j = 2   'セル行
        j2 = 2  '開始セル行/店舗
        k = 1   '件数/店舗
        prc_cnt = 0
        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                prc_cnt = prc_cnt + 1

                waitDlg.ProgressMsg =
                     (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　" +
                     "（" + prc_cnt.ToString() + " / " & DtView1.Count & " 件）"

                waitDlg.Text = "実行中・・・" & (CType(Fix(prc_cnt * 100 / DtView1.Count), Integer)).ToString() + "%　"

                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If k <> 1 And DtView1(i)("完了店CD") <> shop_code Then   '店舗コード比較
                    xlRange = xlCells(j, 6) : xlRange.Value = k - 1 '合計件数セット
                    xlRange = xlCells(j, 7) : xlRange.Value = "=Sum(G" & j2 & ":G" & j2 + k - 2 & ")" : MRComObject(xlRange) '請求額合計セット
                    xlRange = xlCells(j + 1, 8)
                    H = Hs.Add(xlRange) '改行
                    j2 = j + 1  '開始セル行/店舗セット
                    j = j + 1
                    k = 1       '件数リセット
                End If

                xlRange = xlCells(j, 1) : xlRange.Value = k : MRComObject(xlRange) 'No.
                xlRange = xlCells(j, 2) : xlRange.Value = DtView1(i)("区分").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 3) : xlRange.Value = Chr(39) & DtView1(i)("保証番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 4) : xlRange.Value = DtView1(i)("顧客名").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 5) : xlRange.Value = Chr(39) & DtView1(i)("製造番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 6) : xlRange.Value = Chr(39) & DtView1(i)("型式").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 7) : xlRange.Value = Format(DtView1(i)("請求額"), "##0,00").ToString : MRComObject(xlRange)

                If IsDBNull(DtView1(i)("購入日")) = False Then
                    xlRange = xlCells(j, 8) : xlRange.Value = DtView1(i)("購入日") : MRComObject(xlRange)
                End If
                xlRange = xlCells(j, 9) : xlRange.Value = DtView1(i)("事故状況").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 10) : xlRange.Value = Chr(39) & DtView1(i)("修理伝票番号").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 11) : xlRange.Value = DtView1(i)("保険会社").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 12) : xlRange.Value = Chr(39) & DtView1(i)("完了店CD").ToString : MRComObject(xlRange)
                shop_code = DtView1(i)("完了店CD").ToString
                xlRange = xlCells(j, 13) : xlRange.Value = DtView1(i)("完了店名").ToString : MRComObject(xlRange)
                xlRange = xlCells(j, 14) : xlRange.Value = DtView1(i)("状況").ToString : MRComObject(xlRange)
                If IsDBNull(DtView1(i)("処理日")) = False Then
                    xlRange = xlCells(j, 15) : xlRange.Value = DtView1(i)("処理日") : MRComObject(xlRange)
                End If
                k = k + 1
                j = j + 1
            Next

            xlRange = xlCells(j, 6) : xlRange.Value = k - 1 '合計件数セット
            xlRange = xlCells(j, 7) : xlRange.Value = "=Sum(G" & j2 & ":G" & j2 + k - 2 & ")" : MRComObject(xlRange) '請求額合計セット

            '線を引く
            'xlRange = xlSheet.Range("A1:O" & j) : xlRange.Borders.LineStyle = 3
            xlRange = DirectCast(xlSheet.UsedRange, Excel.Range)
            xlRange.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 2
            xlRange.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 2
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1
            xlRange.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange)
        End If

        xlCells.EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

        With xlSheet.PageSetup
            .PaperSize = Excel.XlPaperSize.xlPaperA4           '用紙サイズをＡ４
            .Orientation = Excel.XlPageOrientation.xlLandscape '横
            .Zoom = 75
            .PrintTitleRows = "$1:$1"

            .LeftMargin = xlApp.CentimetersToPoints(1)
            .RightMargin = xlApp.CentimetersToPoints(0.4)
            .TopMargin = xlApp.CentimetersToPoints(1.1)
            .BottomMargin = xlApp.CentimetersToPoints(0.8)
            .HeaderMargin = xlApp.CentimetersToPoints(0.6)
            .FooterMargin = xlApp.CentimetersToPoints(0.3)
        End With
        MRComObject(xlCells)

        Me.Activate()
        waitDlg.Close()

        '［名前を付けて保存］ダイアログボックスを表示
        'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
        SaveFileDialog1.FileName = "受信データ" & Label12.Text & "_3.xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
        Try
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            GoTo end_prc
        End Try

        Me.Enabled = True

        ' 終了処理　
        MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)              'xlApp を開放

end_prc:
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub MRComObject(ByVal objXl As Object)
        'Excel 終了処理時のプロシージャ
        Try
            '提供されたランタイム呼び出し可能ラッパーの参照カウントをデクリメントします
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objXl)
        Catch
        Finally
            objXl = Nothing
        End Try
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        Label12.Text = Mid(ComboBox1.Text, 1, 4) & Mid(ComboBox1.Text, 6, 2) & Mid(ComboBox1.Text, 9, 2)
    End Sub

    '**********************************
    'データ出力ボタン
    '**********************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        Call normal_data()      '正常リスト（加入データと合致した正常データ）
        Call Deficiency_data1() '不備リスト1（加入データと保証番号が一致しないデータ）
        Call Deficiency_data2() '不備リスト2（加入データと保証番号は一致するが他の照合項目が一致しないデータ）

        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True               ' オーナーのフォームを有効にする

        MsgBox("出力しました。", , "")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    'データ出力ボタン
    '**********************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        Call best_data()    'ﾍﾞｽﾄ電器分
        Call best_S_data()  'ﾍﾞｽﾄｻｰﾋﾞｽ分
        Call kakoi_data()   'ｶｺｲ分

        MsgBox("出力しました。", , "")

        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True               ' オーナーのフォームを有効にする
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    'データ出力ボタン
    '**********************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        Call best_data2()    'ﾍﾞｽﾄ電器分
        Call best_S_data2()  'ﾍﾞｽﾄｻｰﾋﾞｽ分
        Call kakoi_data2()   'ｶｺｲ分

        MsgBox("出力しました。", , "")

        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True               ' オーナーのフォームを有効にする
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    'データ出力ボタン データ出力(RE)名前+J
    '**********************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        Call best_data3()    'ﾍﾞｽﾄ電器分
        Call best_S_data3()  'ﾍﾞｽﾄｻｰﾋﾞｽ分
        Call kakoi_data3()   'ｶｺｲ分

        MsgBox("出力しました。", , "")

        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True               ' オーナーのフォームを有効にする
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    'データ出力ボタン データ出力(RE以外)名前+J
    '**********************************
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        Call best_data4()    'ﾍﾞｽﾄ電器分
        Call best_S_data4()  'ﾍﾞｽﾄｻｰﾋﾞｽ分
        Call kakoi_data4()   'ｶｺｲ分

        MsgBox("出力しました。", , "")

        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True               ' オーナーのフォームを有効にする
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    'データ出力ボタン
    '**********************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        Call one_year()

        MsgBox("出力しました。", , "")

        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True               ' オーナーのフォームを有効にする
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    'データ出力ボタン
    '**********************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        Call XLS1()                     '延長修理ＯＫ分
        Call XLS2()                     '延長修理ＮＧ分
        Call XLS3()                     '延長修理以外

        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True               ' オーナーのフォームを有効にする

        MsgBox("出力しました。", , "")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '終了ボタン
    '**********************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub
End Class
