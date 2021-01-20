Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objMutex As System.Threading.Mutex
    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList3, DsCMB1, DsCMB2, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, DtView3 As DataView
    Dim DtTbl1 As DataTable

    Dim strSQL, Err_F, ptn_F As String
    Dim inz_F1 As String = "0"
    Dim inz_F2 As String = "0"
    Dim PF, i, r As Integer

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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label3N As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button99 = New System.Windows.Forms.Button()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label3N = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS PGothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(280, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(352, 16)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("MS PGothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(280, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(352, 16)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Label10"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(776, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Blue
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "処理日"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(144, 8)
        Me.ComboBox1.MaxDropDownItems = 20
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 24)
        Me.ComboBox1.TabIndex = 10
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 24)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "エラーメッセージ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(144, 40)
        Me.ComboBox2.MaxDropDownItems = 20
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(488, 24)
        Me.ComboBox2.TabIndex = 20
        Me.ComboBox2.Text = "ComboBox2"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button99.Location = New System.Drawing.Point(768, 608)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 90
        Me.Button99.Text = "終了"
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 72)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 120
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(864, 528)
        Me.DataGrid1.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 608)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 24)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Label4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(112, 608)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 24)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Label5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Blue
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 24)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "保証番号"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit1.Format = "9#"
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit1.Location = New System.Drawing.Point(144, 8)
        Me.Edit1.MaxLength = 14
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Size = New System.Drawing.Size(128, 25)
        Me.Edit1.TabIndex = 0
        Me.Edit1.Text = "99999999999999"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(712, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 32)
        Me.Button1.TabIndex = 94
        Me.Button1.Text = "切替"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.ForeColor = System.Drawing.Color.Blue
        Me.Button5.Location = New System.Drawing.Point(464, 608)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 32)
        Me.Button5.TabIndex = 80
        Me.Button5.Text = "印刷"
        '
        'Label3N
        '
        Me.Label3N.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3N.Location = New System.Drawing.Point(664, 48)
        Me.Label3N.Name = "Label3N"
        Me.Label3N.Size = New System.Drawing.Size(88, 24)
        Me.Label3N.TabIndex = 95
        Me.Label3N.Text = "Label3N"
        Me.Label3N.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3N.Visible = False
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(632, 608)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 98
        Me.Button2.Text = "CSV出力"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(882, 647)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3N)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "エラーデータ修正 Ver 2.0"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        objMutex = New System.Threading.Mutex(False, "best_ivc_err_mnt")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If

        Call DB_INIT()
        Call inz()
        Call ptn1()
        Call DsSet()
        Call CmbSet1()
        Call CmbSet2()
        Call DspSet1()
        inz_F1 = "1"
        inz_F2 = "1"
    End Sub

    Sub inz()
        Edit1.Text = Nothing
    End Sub

    Sub DsSet()
        DB_OPEN("best_wrn")
        P_DsList1.Clear()

        '保険会社
        strSQL = "SELECT insurance_co_sub.*, insurance_co_mtr.insurance_name"
        strSQL += " FROM insurance_co_sub INNER JOIN"
        strSQL += " insurance_co_mtr ON"
        strSQL += " insurance_co_sub.insurance_code = insurance_co_mtr.insurance_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsList1, "insurance_co_sub")

        '区分
        strSQL = "SELECT CLS_CODE.*"
        strSQL += " FROM CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsList1, "CLS_CODE")

        'コンボボックス用
        P_DsCMB.Clear()
        '事故場所
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '001')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CLS_CODE_001")

        '事故状況ﾌﾗｸﾞ
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '002')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CLS_CODE_002")

        '項目有無ﾌﾗｸﾞ
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '003')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CLS_CODE_003")

        '全損ﾌﾗｸﾞ
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '004')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CLS_CODE_004")

        '伝票区分
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '005')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CLS_CODE_005")

        '請求区分
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '007')"
        strSQL += " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CLS_CODE_007")

        '掛種コード
        strSQL = "SELECT kakesyu, kakesyu + ':' + insurance_code AS insurance_code"
        strSQL += " FROM insurance_co_decision"
        strSQL += " GROUP BY kakesyu, kakesyu + ':' + insurance_code"
        strSQL += " ORDER BY kakesyu, insurance_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "kakesyu")
        DB_CLOSE()
    End Sub

    Sub CmbSet1()
        '処理日
        DsCMB1.Clear()
        strSQL = " SELECT CONVERT (VARCHAR, imp_date, 111) AS proc_date1, CONVERT (VARCHAR, imp_date, 111) AS proc_date"
        strSQL += " FROM Error_data_ivc"
        strSQL += " WHERE (Fixed_flg = '0')"
        strSQL += " GROUP BY imp_date"
        strSQL += " ORDER BY imp_date DESC"

        'strSQL = " SELECT CONVERT (VARCHAR, close_date, 111) AS proc_date1, CONVERT (VARCHAR, close_date, 111) AS proc_date"
        'strSQL += " FROM Error_data_ivc"
        'strSQL += " WHERE (Fixed_flg = '0')"
        'strSQL += " GROUP BY close_date"
        'strSQL += " ORDER BY close_date DESC"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_CLOSE()
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 2000
        DaList1.Fill(DsCMB1, "inp_log")
        DB_CLOSE()

        ComboBox1.DataSource = DsCMB1.Tables("inp_log")
            ComboBox1.DisplayMember = "proc_date"
            ComboBox1.ValueMember = "proc_date1"
        Label4.Text = ComboBox1.Text

    End Sub

    Sub CmbSet2()
        'エラーメッセージ
        DsCMB2.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_err_mnt_6", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 10)
        Pram1.Value = ComboBox1.SelectedValue
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 10000
            DB_OPEN("best_wrn")
            DaList1.Fill(DsCMB2, "Error_data_ivc")
        DB_CLOSE()
        ComboBox2.DataSource = DsCMB2.Tables("Error_data_ivc")
                ComboBox2.DisplayMember = "Error_msg"
                ComboBox2.ValueMember = "Error_no"
        Label5.Text = ComboBox2.Text
    End Sub

    Sub DspSet1()
        P_DsList2.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_err_mnt_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 15)
        Pram1.Value = Edit1.Text & "%"
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(P_DsList2, "Error_data_ivc")
        DB_CLOSE()

        DtView1 = New DataView(P_DsList2.Tables("Error_data_ivc"), "", "", DataViewRowState.CurrentRows)
        Label3.Text = Format(DtView1.Count, "##,##0") & "件" : Label3N.Text = DtView1.Count
        If Label3.Text = "0件" Then
            Button5.Visible = False
        Else
            Button5.Visible = True
            'For i = 0 To DtView1.Count - 1
            '    DtView1(i)("ID") = i
            'Next
        End If

        'テーブルスタイルを作成してデータグリッドに追加する
        Dim ts As DataGridTableStyle
        ts = New DataGridTableStyle
        ts.MappingName = "Error_data_ivc"

        DataGrid1.TableStyles.Clear()

        Dim clmStyle0, clmStyle1, clmStyle2, clmStyle3, clmStyle4, clmStyle5, clmStyle6, clmStyle7, clmStyle8, clmStyle9 As DataGridColumnStyle
        ts.GridColumnStyles.Clear()
        '列スタイルを作成してテーブルスタイルに追加する
        clmStyle1 = New DataGridTextBoxColumn
        clmStyle1.MappingName = "Error_seq"
        clmStyle1.HeaderText = "ｴﾗｰSEQ"
        clmStyle1.Alignment = HorizontalAlignment.Right
        clmStyle1.Width = 80
        ts.GridColumnStyles.Add(clmStyle1)

        clmStyle2 = New DataGridTextBoxColumn
        clmStyle2.MappingName = "FLD012"
        clmStyle2.HeaderText = "完了店舗"
        clmStyle2.Alignment = HorizontalAlignment.Center
        clmStyle2.Width = 80
        ts.GridColumnStyles.Add(clmStyle2)

        clmStyle3 = New DataGridTextBoxColumn
        clmStyle3.MappingName = "ordr_no"
        clmStyle3.HeaderText = "保証番号"
        clmStyle3.Width = 120
        ts.GridColumnStyles.Add(clmStyle3)

        clmStyle4 = New DataGridTextBoxColumn
        clmStyle4.MappingName = "FLD019"
        clmStyle4.HeaderText = "型式"
        clmStyle4.Width = 140
        ts.GridColumnStyles.Add(clmStyle4)

        clmStyle5 = New DataGridTextBoxColumn
        clmStyle5.MappingName = "FLD015"
        clmStyle5.HeaderText = "顧客名"
        clmStyle5.Width = 130
        ts.GridColumnStyles.Add(clmStyle5)

        clmStyle6 = New DataGridTextBoxColumn
        clmStyle6.MappingName = "FLD020"
        clmStyle6.HeaderText = "製造番号"
        clmStyle6.Width = 150
        ts.GridColumnStyles.Add(clmStyle6)

        clmStyle7 = New DataGridTextBoxColumn
        clmStyle7.MappingName = "CLS_CODE_NAME"
        clmStyle7.HeaderText = "事故状況"
        clmStyle7.Width = 100
        ts.GridColumnStyles.Add(clmStyle7)

        clmStyle8 = New DataGridTextBoxColumn
        clmStyle8.MappingName = "Error_msg"
        clmStyle8.Width = 0
        ts.GridColumnStyles.Add(clmStyle8)

        clmStyle9 = New DataGridTextBoxColumn
        clmStyle9.MappingName = "FLD031"
        clmStyle9.Width = 0
        ts.GridColumnStyles.Add(clmStyle9)

        clmStyle0 = New DataGridTextBoxColumn
        clmStyle0.MappingName = "ID"
        clmStyle0.HeaderText = "ID"
        clmStyle0.Width = 0
        ts.GridColumnStyles.Add(clmStyle0)

        ts.ReadOnly = True
        DataGrid1.TableStyles.Add(ts)
        DataGrid1.SetDataBinding(P_DsList2, "Error_data_ivc")

    End Sub

    Sub DspSet2()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_DsList2.Clear()

        Call DspChk()
        If Err_F = "0" Then
            '締め日
            If Mid(ComboBox1.SelectedValue, 9, 2) > 20 Then
                If Mid(ComboBox1.SelectedValue, 6, 2) < 12 Then
                    P_close_date = CDate(Mid(ComboBox1.SelectedValue, 1, 4) & "/" & Mid(ComboBox1.SelectedValue, 6, 2) + 1 & "/20")
                Else
                    P_close_date = CDate(Mid(ComboBox1.SelectedValue, 1, 4) + 1 & "/01/20")
                End If
            Else
                P_close_date = CDate(Mid(ComboBox1.SelectedValue, 1, 4) & "/" & Mid(ComboBox1.SelectedValue, 6, 2) & "/20")
            End If

            Label10.Text = Nothing
            Label11.Text = Nothing
            DtView2 = New DataView(P_DsList1.Tables("CLS_CODE"), "CLS_NO='999' AND CLS_CODE='0'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                If P_close_date <= CDate(DtView2(0)("CLS_CODE_NAME")) Then
                    Label10.Text = "既に" & Format(CDate(DtView2(0)("CLS_CODE_NAME")), "yyyy年MM月度まで") & "締め処理を行っていますので、"
                    Label11.Text = "修正データは" & Format(DateAdd(DateInterval.Month, 1, CDate(DtView2(0)("CLS_CODE_NAME"))), "yyyy年MM月度") & "で処理されます。"
                    P_close_date = DateAdd(DateInterval.Month, 1, CDate(DtView2(0)("CLS_CODE_NAME")))
                End If
            End If

            SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_err_mnt_5", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 10)
            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.VarChar, 2)
            Pram1.Value = ComboBox1.SelectedValue
            Pram2.Value = ComboBox2.SelectedValue
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            DaList1.Fill(P_DsList2, "Error_data_ivc")
            DB_CLOSE()

            DtView1 = New DataView(P_DsList2.Tables("Error_data_ivc"), "", "", DataViewRowState.CurrentRows)
            Label3.Text = Format(DtView1.Count, "##,##0") & "件" : Label3N.Text = DtView1.Count
            If Label3.Text = "0件" Then
                Button5.Visible = False
            Else
                Button5.Visible = True
                For i = 0 To DtView1.Count - 1
                    DtView1(i)("ID") = i
                Next
            End If

            'テーブルスタイルを作成してデータグリッドに追加する
            Dim ts As DataGridTableStyle
            ts = New DataGridTableStyle
            ts.MappingName = "Error_data_ivc"

            DataGrid1.TableStyles.Clear()

            Dim clmStyle0, clmStyle1, clmStyle2, clmStyle3, clmStyle4, clmStyle5, clmStyle6, clmStyle7, clmStyle8, clmStyle9 As DataGridColumnStyle
            ts.GridColumnStyles.Clear()
            '列スタイルを作成してテーブルスタイルに追加する
            clmStyle1 = New DataGridTextBoxColumn
            clmStyle1.MappingName = "Error_seq"
            clmStyle1.HeaderText = "ｴﾗｰSEQ"
            clmStyle1.Alignment = HorizontalAlignment.Right
            clmStyle1.Width = 80
            ts.GridColumnStyles.Add(clmStyle1)

            clmStyle2 = New DataGridTextBoxColumn
            clmStyle2.MappingName = "FLD012"
            clmStyle2.HeaderText = "完了店舗"
            clmStyle2.Alignment = HorizontalAlignment.Center
            clmStyle2.Width = 80
            ts.GridColumnStyles.Add(clmStyle2)

            clmStyle3 = New DataGridTextBoxColumn
            clmStyle3.MappingName = "ordr_no"
            clmStyle3.HeaderText = "保証番号"
            clmStyle3.Width = 120
            ts.GridColumnStyles.Add(clmStyle3)

            clmStyle4 = New DataGridTextBoxColumn
            clmStyle4.MappingName = "FLD019"
            clmStyle4.HeaderText = "型式"
            clmStyle4.Width = 140
            ts.GridColumnStyles.Add(clmStyle4)

            clmStyle5 = New DataGridTextBoxColumn
            clmStyle5.MappingName = "FLD015"
            clmStyle5.HeaderText = "顧客名"
            clmStyle5.Width = 130
            ts.GridColumnStyles.Add(clmStyle5)

            clmStyle6 = New DataGridTextBoxColumn
            clmStyle6.MappingName = "FLD020"
            clmStyle6.HeaderText = "製造番号"
            clmStyle6.Width = 150
            ts.GridColumnStyles.Add(clmStyle6)

            clmStyle7 = New DataGridTextBoxColumn
            clmStyle7.MappingName = "CLS_CODE_NAME"
            clmStyle7.HeaderText = "事故状況"
            clmStyle7.Width = 100
            ts.GridColumnStyles.Add(clmStyle7)

            clmStyle8 = New DataGridTextBoxColumn
            clmStyle8.MappingName = "Error_msg"
            clmStyle8.Width = 0
            ts.GridColumnStyles.Add(clmStyle8)

            clmStyle9 = New DataGridTextBoxColumn
            clmStyle9.MappingName = "FLD031"
            clmStyle9.Width = 0
            ts.GridColumnStyles.Add(clmStyle9)

            clmStyle0 = New DataGridTextBoxColumn
            clmStyle0.MappingName = "ID"
            clmStyle0.HeaderText = "ID"
            clmStyle0.Width = 0
            ts.GridColumnStyles.Add(clmStyle0)

            ts.ReadOnly = True
            DataGrid1.TableStyles.Add(ts)
            DataGrid1.SetDataBinding(P_DsList2, "Error_data_ivc")

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Sub DspChk()
        Err_F = "0"

        DtView3 = New DataView(DsCMB1.Tables("inp_log"), "proc_date='" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView3.Count = 0 Then
            Err_F = "1"
        Else
            ComboBox1.SelectedValue = DtView3(0)("proc_date1")
        End If
    End Sub

    '入力後
    Private Sub Edit1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit1.TextChanged
        If inz_F1 = "1" Then
            Call DspSet1()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If inz_F1 = "1" Then
            inz_F2 = "0"
            Call CmbSet2()
            Call DspSet2()
            inz_F2 = "1"
        End If
        Label4.Text = ComboBox1.Text
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        If Label4.Text <> ComboBox1.Text Then
            Call DspChk()
            If Err_F = "0" Then
                Call ComboBox1_SelectedIndexChanged(sender, e)
                Label4.Text = ComboBox1.Text
            Else
                ComboBox1.Focus()
                MsgBox("該当する処理日がありません。", MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If inz_F2 = "1" Then
            Call DspSet2()
        End If
        Label5.Text = ComboBox2.Text
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        If Label5.Text <> ComboBox2.Text Then
            Call ComboBox2_SelectedIndexChanged(sender, e)
            Label5.Text = ComboBox2.Text
        End If
    End Sub

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim hitinfo As DataGrid.HitTestInfo

        Dim a1 As String

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                P_Error_seq = DataGrid1(hitinfo.Row, 0)
                P_Error_msg = DataGrid1(hitinfo.Row, 7)
                P_FLD031 = DataGrid1(hitinfo.Row, 8)
                a1 = DataGrid1(hitinfo.Row, 9)

                Dim frmform2 As New Form2
                frmform2.ShowDialog()

                Select Case P_Rtn
                    Case Is = "1"
                        If ptn_F = "1" Then
                            Call DspSet2()
                        ElseIf ptn_F = "0" Then
                            Call DspSet1()
                        Else
                            Call CmbSet1()
                            Call CmbSet2()
                        End If




                        'P_DsList2.Tables(0).Rows(DataGrid1(hitinfo.Row, 9)).Delete()
                        'Label3N.Text = Label3N.Text - 1
                        'Label3.Text = Format(CInt(Label3N.Text), "##,##0") & "件"
                    Case Is = "2"
                        If ptn_F = "1" Then
                            ' Call CmbSet1()
                            Call DspSet2()
                        ElseIf ptn_F = "0" Then
                            Call DspSet1()
                        Else
                            Call CmbSet1()
                            Call CmbSet2()
                        End If
                        Call DspSet2()
                        'P_DsList2.Tables(0).Rows(DataGrid1(hitinfo.Row, 9)).Delete()
                        'Label3N.Text = Label3N.Text - 1
                        'Label3.Text = Format(CInt(Label3N.Text), "##,##0") & "件"
                End Select
                Button5.Visible = False
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '切替ボタン
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If ptn_F = "1" Then
            Call ptn1()
            Button2.Enabled = False
        Else
            Call ptn2()
            Button2.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub ptn1()
        If inz_F1 = "1" Then
            Call DspSet1()
        End If
        Button1.Text = "ｴﾗｰﾃﾞｰﾀから検索"
        Label6.Visible = True
        Edit1.Visible = True

        Label1.Visible = False
        Label2.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        ComboBox1.Visible = False
        ComboBox2.Visible = False
        ptn_F = "0"
        Edit1.Focus()
    End Sub

    Sub ptn2()
        Call DspSet2()
        Button1.Text = "保証番号から検索"
        Label6.Visible = False
        Edit1.Visible = False

        Label1.Visible = True
        Label2.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        ComboBox1.Visible = True
        ComboBox2.Visible = True
        ptn_F = "1"
        ComboBox1.Focus()
        If ComboBox1.Text = Nothing Or ComboBox2.Text = Nothing Then
            Label10.Text = "該当する処理日がありません。"
            Label11.Text = Nothing
            Label3.Text = Nothing
        End If

    End Sub

    '印刷ボタン
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim frmform3P As New Form3P
        frmform3P.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '終了ボタン
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub

    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    '***************************************************************************
    '** CSV出力
    '***************************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        Dim i As Integer                  'カウンタ
        Dim sbuf As String                'ファイルに出力するデータ

        Me.Enabled = False                      ' オーナーのフォームを無効にする

        waitDlg = New WaitDialog                ' 進行状況ダイアログ
        waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = "エラーデータ"        ' 処理の概要を表示
        waitDlg.ProgressMsg = "データ出力中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0               ' 最初の件数を設定
        waitDlg.Show()                          ' 進行状況ダイアログを表示する
        Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

        WK_DsList1.Clear()
        strSQL = "SELECT * FROM Error_data_ivc"
        strSQL += " WHERE (imp_date = CONVERT(DATETIME, '" & ComboBox1.SelectedValue & "', 102)) AND (Fixed_flg = '0')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        r = DaList1.Fill(WK_DsList1, "Error_data_ivc")
        DB_CLOSE()

        DtView1 = New DataView(WK_DsList1.Tables("Error_data_ivc"), "", "", DataViewRowState.CurrentRows)
        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

        waitDlg.MainMsg = "データ出力中"            ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = DtView1.Count               ' 全体の処理件数を設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

        sbuf = "Error_seq,エラーメッセージ,システム区分,請求番号,伝票番号,承認番号,事故日,事故所,事故状況フラグ,項目有無フラグ"
        sbuf += ",全損フラグ,修理購入店コード体系,修理品購入店,修理受付店コード体系,修理受付店,修理完了店コード体系"
        sbuf += ",修理完了店,伝票区分,修理伝票番号,顧客名,電話番号,商品コード,型式,修理品製造番号,修理受付日,修理完了日,出張料"
        sbuf += ",作業料,部品料計,値引き額,請求除外金額,請求額,見積額,修理番号,処理日,請求区分"
        sw.WriteLine(sbuf)

        For i = 0 To DtView1.Count - 1

            waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            sbuf = DtView1(i)("Error_seq")
            sbuf += "," & DtView1(i)("Error_msg")
            sbuf += "," & DtView1(i)("BY_cls")
            sbuf += "," & DtView1(i)("FLD002")
            sbuf += "," & DtView1(i)("ordr_no")
            sbuf += "," & DtView1(i)("FLD004")
            sbuf += "," & DtView1(i)("FLD005")
            sbuf += "," & DtView1(i)("FLD006")
            sbuf += "," & DtView1(i)("FLD007")
            sbuf += "," & DtView1(i)("FLD008")
            sbuf += "," & DtView1(i)("FLD009")
            sbuf += "," & DtView1(i)("buy_BY_cls")
            sbuf += "," & DtView1(i)("FLD010")
            sbuf += "," & DtView1(i)("ent_BY_cls")
            sbuf += "," & DtView1(i)("FLD011")
            sbuf += "," & DtView1(i)("fin_BY_cls")
            sbuf += "," & DtView1(i)("FLD012")
            sbuf += "," & DtView1(i)("FLD013")
            sbuf += "," & DtView1(i)("FLD014")
            sbuf += "," & DtView1(i)("FLD015")
            sbuf += "," & DtView1(i)("FLD016")
            sbuf += "," & DtView1(i)("pos_code")
            sbuf += "," & DtView1(i)("FLD019")
            sbuf += "," & DtView1(i)("FLD020")
            sbuf += "," & DtView1(i)("FLD021")
            sbuf += "," & DtView1(i)("FLD022")
            sbuf += "," & DtView1(i)("FLD023")
            sbuf += "," & DtView1(i)("FLD024")
            sbuf += "," & DtView1(i)("FLD025")
            sbuf += "," & DtView1(i)("FLD026")
            sbuf += "," & DtView1(i)("FLD027")
            sbuf += "," & DtView1(i)("FLD028")
            sbuf += "," & DtView1(i)("FLD029")
            sbuf += "," & DtView1(i)("FLD030")
            sbuf += "," & DtView1(i)("FLD031")
            sbuf += "," & DtView1(i)("FLD032")
            sw.WriteLine(sbuf)
        Next

        sw.Close()
        Me.Activate()
        waitDlg.Close()

        '［名前を付けて保存］ダイアログボックスを表示
        If ComboBox1.Text <> "" Then
            SaveFileDialog1.FileName = "請求Error_data_" & Format(CDate(ComboBox1.Text), "yyyyMMddhhmmss") & ".csv"
        Else
            SaveFileDialog1.FileName = "請求Error_data_.csv"
        End If
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

        Me.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class