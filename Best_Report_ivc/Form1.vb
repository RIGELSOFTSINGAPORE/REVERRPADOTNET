Imports System.Globalization


Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objMutex As System.Threading.Mutex

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsExp As New DataSet
    Dim DtView1 As DataView
    Dim DtView2 As DataView
    Dim reader As SqlClient.SqlDataReader
    Dim fromdate As DateTime
    Dim todate As DateTime
    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim From_date, To_date As Date
    Dim strSQL, Err_F, ptn_F, inz_F As String
    'Dim i, j As Integer
    Friend WithEvents ラベル4 As Label
    Friend WithEvents 会計年度 As TextBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ラベル2 As Label
    Dim dformat As String
    Friend WithEvents lblFromDate As Label
    Friend WithEvents lblToDate As Label
    Dim dateval As DateTime



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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button99 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ラベル4 = New System.Windows.Forms.Label()
        Me.会計年度 = New System.Windows.Forms.TextBox()
        Me.ラベル2 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button99.Location = New System.Drawing.Point(225, 73)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 104
        Me.Button99.Text = "終了"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(57, 73)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 32)
        Me.Button5.TabIndex = 103
        Me.Button5.Text = "集計"
        '
        'ラベル4
        '
        Me.ラベル4.AutoSize = True
        Me.ラベル4.Location = New System.Drawing.Point(372, 36)
        Me.ラベル4.Name = "ラベル4"
        Me.ラベル4.Size = New System.Drawing.Size(24, 16)
        Me.ラベル4.TabIndex = 103
        Me.ラベル4.Text = "～"
        '
        '会計年度
        '
        Me.会計年度.Location = New System.Drawing.Point(162, 29)
        Me.会計年度.MaxLength = 4
        Me.会計年度.Name = "会計年度"
        Me.会計年度.Size = New System.Drawing.Size(116, 23)
        Me.会計年度.TabIndex = 102
        Me.会計年度.Text = "会計年度"
        '
        'ラベル2
        '
        Me.ラベル2.AutoSize = True
        Me.ラベル2.Location = New System.Drawing.Point(21, 36)
        Me.ラベル2.Name = "ラベル2"
        Me.ラベル2.Size = New System.Drawing.Size(72, 16)
        Me.ラベル2.TabIndex = 101
        Me.ラベル2.Text = "処理年度"
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Location = New System.Drawing.Point(289, 36)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(75, 16)
        Me.lblFromDate.TabIndex = 104
        Me.lblFromDate.Text = "FromDate"
        '
        'lblToDate
        '
        Me.lblToDate.AutoSize = True
        Me.lblToDate.Location = New System.Drawing.Point(402, 36)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(57, 16)
        Me.lblToDate.TabIndex = 105
        Me.lblToDate.Text = "ToDate"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(520, 139)
        Me.Controls.Add(Me.lblToDate)
        Me.Controls.Add(Me.lblFromDate)
        Me.Controls.Add(Me.ラベル4)
        Me.Controls.Add(Me.会計年度)
        Me.Controls.Add(Me.ラベル2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "品種別事故伏況別策計"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "Bic_Report_soukatsu")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        Call DB_INIT()
        'Dim Year_in_Digits = Year(Now)
        会計年度.Text = Year(Now)
        lblFromDate.Text = Year(Now) & "/" & "03"
        lblToDate.Text = Year(Now) + 1 & "/" & "02"
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

    '新規登録ボタン




    'データ出力ボタン
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'waitDlg = New WaitDialog        ' 進行状況ダイアログ
        'waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        'waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        'waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        'waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        'waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        'waitDlg.ProgressValue = 0       ' 最初の件数を設定
        'Me.Enabled = False              ' オーナーのフォームを無効にする
        'waitDlg.Show()                  ' 進行状況ダイアログを表示する

        dformat = "yyyy/MM/dd"

        If ValidateYear(会計年度.Text.Trim()) = False Then

            Exit Sub

        End If

        'Dim xlp() As Process = Process.GetProcessesByName("EXCEL")

        'For Each Process As Process In xlp
        '    Process.Kill()

        'Next

        'Call XLS_OUT()
        'If (Not System.IO.Directory.Exists("C:\BIC集計")) Then
        '    System.IO.Directory.CreateDirectory("C:\BIC集計")
        'End If


        'waitDlg.Close()                 ' 進行状況ダイアログを閉じる

        fromdate = CDate(lblFromDate.Text & "/01".ToString())
        todate = CDate(lblToDate.Text & "/" & Date.DaysInMonth(CInt(会計年度.Text) + 1, 2))
        'Call コマンド0Main()
        ' 進行状況ダイアログの初期化処理
        'waitDlg = New WaitDialog        ' 進行状況ダイアログ
        'waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        'waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        'waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        'waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        'waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        'waitDlg.ProgressValue = 0       ' 最初の件数を設定
        'Me.Enabled = False              ' オーナーのフォームを無効にする
        'waitDlg.Show()                  ' 進行状況ダイアログを表示する


        'Call Update_MainTable()
        Call update_Feb_Month()
        Call update_Mar_Month()
        Call update_Apr_Month()
        Call update_May_Month()
        Call update_Jun_Month()
        Call update_Jul_Month()
        Call update_Aug_Month()
        Call update_Sep_Month()
        Call update_Oct_Month()
        Call update_Nov_Month()
        Call update_Dec_Month()
        Call update_Jan_Month()

        Call update_Fin_Summery()
        Call GenerateReport()

        'waitDlg.Close()                 ' 進行状況ダイアログを閉じる



        Me.Activate()                   ' いったんオーナーをアクティブにする
        Me.Enabled = True               ' オーナーのフォームを有効にする

        MsgBox("出力しました。", , "")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '終了ボタン
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub

    Public Function ValidateYear(ByVal year As String) As Boolean
        ' Confirm that the email address string is not empty.
        Button5.Enabled = False
        If (year.Length = 0) Then
            MessageBox.Show("年を入力する必要があります")
            lblFromDate.Text = ""
            lblToDate.Text = ""
            Button5.Enabled = False
            Return False
        End If

        If IsNumeric(year) = True Then

            Select Case Convert.ToInt32(year)
                Case 1900 To Date.Now.Year
                    'errorMessage = ""
                    '会計年度.Text = year(Now)
                    lblFromDate.Text = 会計年度.Text & "/" & "03"
                    lblToDate.Text = CInt(会計年度.Text) + 1 & "/" & "02"
                    Button5.Enabled = True
                    Return True
                Case Else
                    MessageBox.Show("有効な年を入力する必要があります")
                    'errorMessage = "Valid year should be enter"
                    lblFromDate.Text = ""
                    lblToDate.Text = ""
                    Button5.Enabled = False
                    Return False
            End Select
        Else
            MessageBox.Show("有効な年を入力する必要があります")
            lblFromDate.Text = ""
            lblToDate.Text = ""
            Button5.Enabled = False
            Return False


        End If

        'Return True
    End Function

    Sub Update_MainTable()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_00_Cat_mtr", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_00_wrn_ivc", cnsqlclient)
        SqlCmd1.Parameters.Add("@FromDate", fromdate)
        SqlCmd1.Parameters.Add("@ToDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    'Sub update_Feb_Month()

    '    DB_OPEN("best_wrn_new")
    '    SqlCmd1 = New SqlClient.SqlCommand("Q_0602_0", cnsqlclient)
    '    SqlCmd1.Parameters.Add("@RepDate", fromdate)
    '    SqlCmd1.CommandType = CommandType.StoredProcedure
    '    SqlCmd1.CommandTimeout = 10000
    '    SqlCmd1.ExecuteNonQuery()
    '    DB_CLOSE()

    '    DB_OPEN("best_wrn_new")
    '    SqlCmd1 = New SqlClient.SqlCommand("Q_0602_1", cnsqlclient)
    '    SqlCmd1.Parameters.Add("@RepDate", fromdate)
    '    SqlCmd1.CommandType = CommandType.StoredProcedure
    '    SqlCmd1.CommandTimeout = 10000
    '    SqlCmd1.ExecuteNonQuery()
    '    DB_CLOSE()

    '    DB_OPEN("best_wrn_new")
    '    SqlCmd1 = New SqlClient.SqlCommand("Q_0602_2", cnsqlclient)
    '    SqlCmd1.Parameters.Add("@RepDate", fromdate)
    '    SqlCmd1.CommandType = CommandType.StoredProcedure
    '    SqlCmd1.CommandTimeout = 10000
    '    SqlCmd1.ExecuteNonQuery()
    '    DB_CLOSE()

    '    DB_OPEN("best_wrn_new")
    '    SqlCmd1 = New SqlClient.SqlCommand("Q_0602_3", cnsqlclient)
    '    SqlCmd1.Parameters.Add("@RepDate", fromdate)
    '    SqlCmd1.CommandType = CommandType.StoredProcedure
    '    SqlCmd1.CommandTimeout = 10000
    '    SqlCmd1.ExecuteNonQuery()
    '    DB_CLOSE()

    '    DB_OPEN("best_wrn_new")
    '    SqlCmd1 = New SqlClient.SqlCommand("Q_0602_4", cnsqlclient)
    '    SqlCmd1.Parameters.Add("@RepDate", fromdate)
    '    SqlCmd1.CommandType = CommandType.StoredProcedure
    '    SqlCmd1.CommandTimeout = 10000
    '    SqlCmd1.ExecuteNonQuery()
    '    DB_CLOSE()

    '    DB_OPEN("best_wrn_new")
    '    SqlCmd1 = New SqlClient.SqlCommand("Q_0602_9", cnsqlclient)
    '    SqlCmd1.Parameters.Add("@RepDate", fromdate)
    '    SqlCmd1.CommandType = CommandType.StoredProcedure
    '    SqlCmd1.CommandTimeout = 10000
    '    SqlCmd1.ExecuteNonQuery()
    '    DB_CLOSE()

    'End Sub

    Sub update_Mar_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0603_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0603_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0603_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0603_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0603_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0603_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Apr_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0604_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0604_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0604_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0604_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0604_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0604_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_May_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0605_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0605_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0605_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0605_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0605_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0605_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Jun_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0606_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0606_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0606_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0606_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0606_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0606_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Jul_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0607_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0607_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0607_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0607_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0607_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0607_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Aug_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0608_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0608_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0608_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0608_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0608_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0608_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Sep_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0609_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0609_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0609_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0609_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0609_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0609_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Oct_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0610_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0610_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0610_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0610_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0610_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0610_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Nov_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0611_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0611_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0611_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0611_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0611_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0611_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Dec_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0612_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0612_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0612_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0612_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0612_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0612_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub update_Jan_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0701_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0701_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0701_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0701_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0701_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0701_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub









    Private Sub 会計年度_Leave(sender As Object, e As EventArgs) Handles 会計年度.Leave
        ValidateYear(会計年度.Text.Trim())
        'MessageBox.Show("textbox leave")
    End Sub

    Sub update_Feb_Month()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0602_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0602_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0602_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0602_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0602_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_0602_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@RepDate", fromdate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub
    Sub update_Fin_Summery()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_06AA_0", cnsqlclient)
        SqlCmd1.Parameters.Add("@FromDate", fromdate)
        SqlCmd1.Parameters.Add("@ToDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_06AA_1", cnsqlclient)
        SqlCmd1.Parameters.Add("@FromDate", fromdate)
        SqlCmd1.Parameters.Add("@ToDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_06AA_2", cnsqlclient)
        SqlCmd1.Parameters.Add("@FromDate", fromdate)
        SqlCmd1.Parameters.Add("@ToDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_06AA_3", cnsqlclient)
        SqlCmd1.Parameters.Add("@FromDate", fromdate)
        SqlCmd1.Parameters.Add("@ToDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_06AA_4", cnsqlclient)
        SqlCmd1.Parameters.Add("@FromDate", fromdate)
        SqlCmd1.Parameters.Add("@ToDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand("Q_06AA_9", cnsqlclient)
        SqlCmd1.Parameters.Add("@FromDate", fromdate)
        SqlCmd1.Parameters.Add("@ToDate", todate)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Sub GenerateReport()



        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)

        'xlApp.Visible = True
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Add
        Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
        Dim xlSheet As Excel.Worksheet
        Dim i As Integer
        For i = 0 To 13 - 1
            If i = 0 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年3月支払分"
                AddContentToSheet(xlSheet, 2)
                'With xlApp
                '    With .Worksheets(xlSheet.Name)
                '        .cells(0, 1) = "ｼｽﾃﾑ区分"
                '        .cells(0, 2) = "品種コード"
                '        .cells(0, 3) = "品種名"

                '        .cells(0, 4) = "延長修理"
                '        xlSheet.Range("D1:E1").Merge()
                '        .cells(0, 6) = "盗難"
                '        xlSheet.Range("F1:G1").Merge()
                '        .cells(0, 8) = "火災"
                '        xlSheet.Range("H1:I1").Merge()
                '        .cells(0, 10) = "水害・落雷"
                '        xlSheet.Range("J1:K1").Merge()
                '        .cells(0, 12) = "破損"
                '        xlSheet.Range("L1:M1").Merge()
                '        .cells(0, 14) = "合計"
                '        xlSheet.Range("N1:O1").Merge()
                '        .cells(1, 4) = "件数"
                '        .cells(1, 5) = "金額"
                '        .cells(1, 6) = "件数"
                '        .cells(1, 7) = "金額"
                '        .cells(1, 8) = "件数"
                '        .cells(1, 9) = "金額"
                '        .cells(1, 10) = "件数"
                '        .cells(1, 11) = "金額"
                '        .cells(1, 12) = "件数"
                '        .cells(1, 13) = "金額"
                '        .cells(1, 14) = "件数"
                '        .cells(1, 15) = "金額"
                '        xlSheet.Range("A1:A2").Merge()
                '        xlSheet.Range("B1:B1").Merge()
                '        xlSheet.Range("C1:C1").Merge()
                '        xlSheet.Application.ActiveWindow.ScrollRow = 1
                '        xlSheet.Application.ActiveWindow.FreezePanes = True
                '    End With
                'End With
            ElseIf i = 1 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年4月支払分"
                AddContentToSheet(xlSheet, 3)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 2 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年5月支払分"
                AddContentToSheet(xlSheet, 4)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 3 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年6月支払分"
                AddContentToSheet(xlSheet, 5)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 4 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年7月支払分"
                AddContentToSheet(xlSheet, 6)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 5 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年8月支払分"
                AddContentToSheet(xlSheet, 7)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 6 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年9月支払分"
                AddContentToSheet(xlSheet, 8)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 7 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年10月支払分"
                AddContentToSheet(xlSheet, 9)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 8 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年11月支払分"
                AddContentToSheet(xlSheet, 10)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 9 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年12月支払分"
                AddContentToSheet(xlSheet, 11)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 10 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = CInt(会計年度.Text) + 1 & "年1月支払分"
                AddContentToSheet(xlSheet, 12)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 11 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = CInt(会計年度.Text) + 1 & "年2月支払分"
                AddContentToSheet(xlSheet, 1)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            ElseIf i = 12 Then
                xlSheet = xlBook.Sheets.Add(After:=
                xlBook.Sheets(xlBook.Sheets.Count))
                xlSheet.Name = 会計年度.Text & "年3月～" & CInt(会計年度.Text) + 1 & "年2月支払分"
                AddContentToSheet(xlSheet, 13)
                'AddContentToSheet(xlSheet, DtView1, DtView2)
            End If
            'xlSheet = DirectCast(xlSheets(i + 1), Excel.Worksheet)
        Next
        xlBook.Sheets("Sheet1").Delete
        '品種別事故状況別集計YYYYMM_YYYYMM支払分.xlsx
        'SaveFileDialog1.FileName = 会計年度.Text & "年3月～" & CInt(会計年度.Text) + 1 & "年2月支払分" & ".xlsx"
        SaveFileDialog1.FileName = "品種別事故状況別集計" & 会計年度.Text & "03_" & CInt(会計年度.Text) + 1 & "02支払分.xlsx"
        SaveFileDialog1.Filter = "Excelファイル|*.xlsx"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Try
            'xlBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal)
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            'Dim xlpe() As Process = Process.GetProcessesByName("EXCEL")

            'For Each Process As Process In xlpe
            '    Process.Kill()
            'Next
            Exit Sub
        Finally

        End Try


        Me.Enabled = True

        ' 終了処理　
        'MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)              'xlApp を開放
        'Dim xlp() As Process = Process.GetProcessesByName("EXCEL")

        'For Each Process As Process In xlp
        '    Process.Kill()
        'Next

    End Sub
    Sub AddContentToSheet(ByVal ws As Excel.Worksheet, ByVal mon As Int16)
        'a.Cells(1, 1) = "abc"
        'a.Cells(1, 2) = "abc"
        ' AddContentToSheet(xlSheet, DtView1, DtView2)
        Dim repmname As String
        Dim repmcntname As String
        Dim reccount As Integer
        Dim i As Integer
        Select Case mon
            Case 1
                repmname = "Q_070" & mon & "_集計"
                repmcntname = "Q_070" & mon & "_集計_Count"
            Case 2 To 9
                repmname = "Q_060" & mon & "_集計"
                repmcntname = "Q_060" & mon & "_集計_Count"
            Case 10 To 12
                repmname = "Q_06" & mon & "_集計"
                repmcntname = "Q_06" & mon & "_集計_Count"
            Case 13
                repmname = "Q_06AA_集計"
                repmcntname = "Q_06AA_集計_Count"
        End Select
        DsExp.Clear()
        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand(repmname, cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        DaList1.Fill(DsExp)
        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)
        DB_CLOSE()

        reccount = DtView1.Count

        ws.Cells(1, 1) = "ｼｽﾃﾑ区分"
        ws.Cells(1, 2) = "品種コード"
        ws.Cells(1, 3) = "品種名"

        ws.Cells(1, 4) = "延長修理"
        ws.Range("D1:E1").Merge()
        ws.Cells(1, 6) = "盗難"
        ws.Range("F1:G1").Merge()
        ws.Cells(1, 8) = "火災"
        ws.Range("H1:I1").Merge()
        ws.Cells(1, 10) = "水害・落雷"
        ws.Range("J1:K1").Merge()
        ws.Cells(1, 12) = "破損"
        ws.Range("L1:M1").Merge()
        ws.Cells(1, 14) = "合計"
        ws.Range("N1:O1").Merge()
        ws.Cells(2, 4) = "件数"
        ws.Cells(2, 5) = "金額"
        ws.Cells(2, 6) = "件数"
        ws.Cells(2, 7) = "金額"
        ws.Cells(2, 8) = "件数"
        ws.Cells(2, 9) = "金額"
        ws.Cells(2, 10) = "件数"
        ws.Cells(2, 11) = "金額"
        ws.Cells(2, 12) = "件数"
        ws.Cells(2, 13) = "金額"
        ws.Cells(2, 14) = "件数"
        ws.Cells(2, 15) = "金額"

        ws.Range("A1:A2").Merge()
        ws.Range("B1:B2").Merge()
        ws.Range("C1:C2").Merge()
        ws.Range("A1:O1").HorizontalAlignment = Excel.Constants.xlCenter
        ws.Application.ActiveWindow.ScrollRow = 1
        ws.Application.ActiveWindow.SplitRow = 2
        ws.Application.ActiveWindow.FreezePanes = True
        'ws.Columns("B:B").NumberFormat = "@"
        'ws.Columns("B:B").cells.Ignore = True
        'ws.Columns("B:B").Application.ErrorCheckingOptions.NumberAsText = True

        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0
        waitDlg.Show()

        waitDlg.MainMsg = "テキストマスター"              ' 進行状況ダイアログのメーターを設定 Need to change based on report
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        Dim rw As Integer
        rw = 2
        For i = 0 To DtView1.Count - 1
            waitDlg.ProgressMsg = ws.Name & "   " & Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
            'Application.DoEvents()
            rw += 1
            ws.Cells(rw, 1) = DtView1(i)("BY_cls")
            'ws.Cells(rw, 2) = DtView1(i)("cd12")
            ws.Cells(rw, 2) = "=CONCAT(""" & DtView1(i)("cd12") & """)"
            ws.Cells(rw, 3) = DtView1(i)("品種名(漢字)")
            ws.Cells(rw, 4) = DtView1(i)("式1")
            ws.Cells(rw, 5) = DtView1(i)("式2")
            ws.Cells(rw, 6) = DtView1(i)("式3")
            ws.Cells(rw, 7) = DtView1(i)("式4")
            ws.Cells(rw, 8) = DtView1(i)("式5")
            ws.Cells(rw, 9) = DtView1(i)("式6")
            ws.Cells(rw, 10) = DtView1(i)("式7")
            ws.Cells(rw, 11) = DtView1(i)("式8")
            ws.Cells(rw, 12) = DtView1(i)("式9")
            ws.Cells(rw, 13) = DtView1(i)("式10")
            ws.Cells(rw, 14) = DtView1(i)("式11")
            ws.Cells(rw, 15) = DtView1(i)("式12")
            waitDlg.ProgressValue = i
        Next

        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める


        Me.Activate()
        waitDlg.Close()

        DsExp.Clear()
        DB_OPEN("best_wrn_new")
        SqlCmd1 = New SqlClient.SqlCommand(repmcntname, cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        DaList1.Fill(DsExp)
        DtView2 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)
        DB_CLOSE()

        For i = 0 To DtView2.Count - 1

            rw += 2
            ws.Cells(rw, 1) = DtView1(i)("BY_cls")
            'ws.Cells(rw, 2) = DtView1(i)("cd12").ToString()
            ws.Cells(rw, 2) = "=CONCAT(""" & DtView1(i)("cd12") & """)"
            'ws.Cells(rw, 2) = "=CONCAT(""" & DtView1(i)("cd12") & """)"
            'ws.Cells(rw, 2).Errors(3).Ignore = True
            'Dim j As Integer
            'For j = 1 To 8
            '    ws.Cells("B3").Errors(j).Ignore = True
            '    'ws.Cells(rw, 2).Errors.Item(3).Ignore = True
            'Next
            ws.Cells(rw, 3) = DtView1(i)("品種名(漢字)")
            ws.Cells(rw, 4) = DtView1(i)("式1")
            ws.Cells(rw, 5) = DtView1(i)("式2")
            ws.Cells(rw, 6) = DtView1(i)("式3")
            ws.Cells(rw, 7) = DtView1(i)("式4")
            ws.Cells(rw, 8) = DtView1(i)("式5")
            ws.Cells(rw, 9) = DtView1(i)("式6")
            ws.Cells(rw, 10) = DtView1(i)("式7")
            ws.Cells(rw, 11) = DtView1(i)("式8")
            ws.Cells(rw, 12) = DtView1(i)("式9")
            ws.Cells(rw, 13) = DtView1(i)("式10")
            ws.Cells(rw, 14) = DtView1(i)("式11")
            ws.Cells(rw, 15) = DtView1(i)("式12")
        Next

        'Dim formatRange As Excel.Range
        'formatRange = ws.Range("A1:O" & CStr(reccount + 4))
        'formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
        'ws.Range("A1:O" & CStr(reccount + 4)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
        ws.Range("A1:O" & CStr(reccount + 4)).Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        ws.Range("A3:B" & CStr(reccount + 4)).HorizontalAlignment = Excel.Constants.xlCenter
        ws.Range("E3:E" & CStr(reccount + 4)).NumberFormat = "###,##"
        ws.Range("G3:G" & CStr(reccount + 4)).NumberFormat = "###,##"
        ws.Range("I3:I" & CStr(reccount + 4)).NumberFormat = "###,##"
        ws.Range("K3:K" & CStr(reccount + 4)).NumberFormat = "###,##"
        ws.Range("M3:M" & CStr(reccount + 4)).NumberFormat = "###,##"
        ws.Range("O3:O" & CStr(reccount + 4)).NumberFormat = "###,##"
        ws.Range("A1:O" & CStr(reccount + 4)).Font.Name = "ＭＳ Ｐゴシック"
        ws.Range("A1:O" & CStr(reccount + 4)).Font.Size = 11
        ws.Range("A1:O" & CStr(reccount + 4)).RowHeight = 13.5
        ws.Columns().AutoFit()
        'ws.Rows().AutoFit()
        'ws.Cells("A1:O" & CStr(reccount + 4))
        'ws.Columns("B:B").Errors.Item(Excel.XlErrorChecks.xlNumberAsText).Ignore = True
        'ws.Cells().Columns.NumberFormat = "@"
        'ws.Cells("A1:O" & CStr(reccount + 4)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        'ws.Cells("A1:O" & CStr(reccount + 4)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        'ws.Cells("A1:O3992").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        'ws.Range("A1:C1").HorizontalAlignment = Excel.Constants.xlCenter
        'ws.Application.ActiveWindow.ScrollRow = 2
        'ws.Application.ActiveWindow.FreezePanes = True
    End Sub

    'Private Sub PlaceBordersOnEachCell(pRange As Range)
    '    pRange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous
    'End Sub
    Sub AddContentToSheet1(ByVal a As Excel.Worksheet)
        a.Cells(4, 6) = "abc"
        a.Cells(7, 8) = "abc"
    End Sub
End Class

